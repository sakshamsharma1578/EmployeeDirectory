// wwwroot/js/locomotion.js
document.addEventListener("DOMContentLoaded", () => {
    function initLoco() {
        // wait for all three libs (gsap, ScrollTrigger, LocomotiveScroll) to exist
        // FIX — Safely register ScrollTrigger
        if (window.gsap && window.ScrollTrigger) {
            gsap.registerPlugin(ScrollTrigger);
        } else {
            console.error("ScrollTrigger NOT found when registering.");
        }

        try { gsap.registerPlugin(ScrollTrigger); } catch (e) { /* ignore */ }

        const scrollEl = document.querySelector("#js-scroll");
        if (!scrollEl) {
            console.warn("locomotion: #js-scroll not found — aborting Locomotive init");
            return;
        }

        let loco = null;
        try {
            loco = new LocomotiveScroll({
                el: scrollEl,
                smooth: true,
                multiplier: 0.4, // slightly slower, tweak to taste (0.25-0.6)
                smartphone: { smooth: true, multiplier: 0.4 },
                tablet: { smooth: true, multiplier: 0.4 }
            });
        } catch (err) {
            loco = null;
            console.warn("Locomotive failed to init:", err);
        }

        // Only create the scrollerProxy if ScrollTrigger exists
        if (typeof ScrollTrigger !== "undefined") {
            if (loco) {
                // Use the DOM element for scrollerProxy and ALWAYS use transform pinType
                ScrollTrigger.scrollerProxy(scrollEl, {
                    scrollTop(value) {
                        return arguments.length ? loco.scrollTo(value, 0, 0) : (loco && loco.scroll && loco.scroll.instance ? loco.scroll.instance.scroll.y : 0);
                    },
                    getBoundingClientRect() {
                        return { top: 0, left: 0, width: window.innerWidth, height: window.innerHeight };
                    },
                    pinType: "transform" // force transform to avoid locomotive/ScrollTrigger pin issues
                });

                // forward loco scroll updates to ScrollTrigger
                loco.on("scroll", ScrollTrigger.update);
                ScrollTrigger.addEventListener("refresh", () => { try { loco.update(); } catch (e) { } });

            } else {
                // fallback to window scrolling if loco failed
                ScrollTrigger.scrollerProxy(window, {
                    scrollTop(value) {
                        return arguments.length ? window.scrollTo(0, value) : (window.pageYOffset || document.documentElement.scrollTop);
                    },
                    getBoundingClientRect() {
                        return { top: 0, left: 0, width: window.innerWidth, height: window.innerHeight };
                    },
                    pinType: "fixed"
                });
            }

            // allow layout to settle, then refresh
            setTimeout(() => {
                try { ScrollTrigger.refresh(); } catch (e) { console.warn("ScrollTrigger.refresh failed", e); }
                try { if (loco && loco.update) loco.update(); } catch (e) { console.warn("loco.update failed", e); }
            }, 250);
        }

        // helper: returns trigger options merged with scroller if loco active
        const scrollerFor = (opts = {}) => {
            return loco ? Object.assign({}, opts, { scroller: scrollEl }) : opts;
        };

        /* -------------------------
           ANIMATIONS
        ------------------------- */

        // Hero Title
        try {
            gsap.from(".hero-title", scrollerFor({
                y: 20, opacity: 0, duration: 0.95, ease: "power2.out", delay: 0.08,
                scrollTrigger: { trigger: ".hero-title", start: "top 95%" }
            }));
        } catch (e) { console.warn("hero animation error", e); }

        // gold-text
        try {
            gsap.from(".gold-text", scrollerFor({
                y: 10, opacity: 0, duration: 0.85, ease: "power2.out", delay: 0.18,
                scrollTrigger: { trigger: ".gold-text", start: "top 95%" }
            }));
        } catch (e) { console.warn("gold-text error", e); }

        // Quick Stats
        try {
            gsap.from(".stat", scrollerFor({
                y: 30, opacity: 0, stagger: 0.12, duration: 0.85, ease: "power3.out",
                scrollTrigger: { trigger: ".stats", start: "top 90%" }
            }));
        } catch (e) { console.warn("stats error", e); }

        // Cards
        try {
            gsap.utils.toArray(".card").forEach((card) => {
                gsap.from(card, scrollerFor({
                    y: 40, opacity: 0, duration: 0.8, ease: "power2.out",
                    scrollTrigger: { trigger: card, start: "top 90%" }
                }));
            });
        } catch (e) { console.warn("cards error", e); }

        // detail close handler
        document.addEventListener("click", (e) => {
            if (e.target.closest(".detail-close")) {
                gsap.to("#detail-panel", { x: "100%", duration: 0.45, ease: "power3.in" });
            }
        });

        // responsive updates
        window.addEventListener("resize", () => {
            try { if (loco && loco.update) loco.update(); } catch (e) { }
            try { ScrollTrigger.refresh(); } catch (e) { }
        });

        console.info("locomotion.js initialized (loco:", !!loco, ", multiplier: 0.4 )");
    } // initLoco

    initLoco();
});
