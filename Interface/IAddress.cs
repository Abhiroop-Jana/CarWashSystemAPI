using CarWashSystemAPI.Models;
using System.Collections.Generic;

namespace CarWashSystemAPI.Interface
{
    public interface IAddress
    {
        public List<Address> GetAddress();
        public Address GetAddress(int id);
        public void AddAddress(Address address);
        public void UpdateAddress(Address address);
        public Address DeleteAddress(int id);
        public bool CheckAddress(int id);
    }
}
