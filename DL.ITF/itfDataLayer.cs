using System.Collections.Generic;
using AddressBookApp.VO;

namespace AddressBookApp.DL.ITF
{
    public interface IAddressDL
    {
        int Insert(AddressVO address);
        bool Update(AddressVO address);
        bool Delete(int id);
        AddressVO GetById(int id);
        List<AddressVO> GetAll();
    }
}
