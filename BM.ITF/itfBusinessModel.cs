using System.Collections.Generic;
using AddressBookApp.VO;

namespace AddressBookApp.BM.ITF
{
    public interface IAddressBM
    {
        int Create(AddressVO address);
        bool Update(AddressVO address);
        bool Delete(int id);
        AddressVO GetById(int id);
        List<AddressVO> GetAll();
    }
}
