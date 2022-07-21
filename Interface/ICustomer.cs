using CarWashSystemAPI.Models;
using System.Collections.Generic;

namespace CarWashSystemAPI.Interface
{
    public interface ICustomer
    {
        public List<Customer> GetCustomer();
        public Customer GetCustomer(int id);
        public void AddCustomer(Customer customer);
        public void UpdateCustomer(Customer customer);
        public Customer DeleteCustomer(int id);
        public bool CheckCustomer(int id);
    }
}
