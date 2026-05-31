using System;
using System.Collections.Generic;
using AddressBookApp.VO;
using AddressBookApp.DL.ITF;
using AddressBookApp.BM.ITF;

namespace AddressBookApp.BM
{
    public class AddressBM : IAddressBM
    {
        private readonly IAddressDL _dl;

        public AddressBM(IAddressDL dl)
        {
            _dl = dl;
        }

        public int Create(AddressVO address)
        {
            if (address == null) return 0;
            if (string.IsNullOrWhiteSpace(address.FullName)) return 0;
            if (string.IsNullOrWhiteSpace(address.Phone)) return 0;
            return _dl.Insert(address);
        }

        public bool Update(AddressVO address)
        {
            if (address == null) return false;
            if (address.Id <= 0) return false;
            if (string.IsNullOrWhiteSpace(address.FullName)) return false;
            if (string.IsNullOrWhiteSpace(address.Phone)) return false;
            return _dl.Update(address);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return _dl.Delete(id);
        }

        public AddressVO GetById(int id)
        {
            if (id <= 0) return null;
            return _dl.GetById(id);
        }

        public List<AddressVO> GetAll()
        {
            return _dl.GetAll();
        }
    }
}
