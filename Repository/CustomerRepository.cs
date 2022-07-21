using CarWashSystemAPI.Interface;
using CarWashSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarWashSystemAPI.Repository
{
    public class CustomerRepository : ICustomer
    {
        readonly CarWashContext _dbContext;

        public CustomerRepository(CarWashContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Customer> GetCustomer()
        {
            try
            {
                return _dbContext.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _dbContext.Dispose();
            }
        }

        public Customer GetCustomer(int id)
        {
            Customer customer;
            try
            {
                customer = _dbContext.Customers.Find(id);
                if (customer != null)
                {
                    return customer;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException();
            }
            finally
            {
                customer = null;
            }
            return customer;
        }

        public void AddCustomer(Customer customer)
        {
            try
            {
                _dbContext.Customers.Add(customer);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _dbContext.Dispose();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            try
            {
                _dbContext.Entry(customer).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _dbContext.Dispose();
            }
        }

        public Customer DeleteCustomer(int id)
        {
            Customer customer;
            try
            {
                customer = _dbContext.Customers.Find(id);
                if (customer != null)
                {
                    _dbContext.Customers.Remove(customer);
                    _dbContext.SaveChanges();
                    return customer;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException();
            }
            finally
            {
                customer = null;
            }
            return customer;
        }
        public bool CheckCustomer(int id)
        {
            return _dbContext.Customers.Any(e => e.Id == id);
        }
    }
}
