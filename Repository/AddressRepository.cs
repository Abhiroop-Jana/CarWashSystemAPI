using CarWashSystemAPI.Interface;
using CarWashSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarWashSystemAPI.Repository
{
    public class AddressRepository : IAddress
    {
        readonly CarWashContext _dbContext;

        public AddressRepository(CarWashContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Address> GetAddress()
        {
            try
            {
                return _dbContext.Addresses.ToList();
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

        public Address GetAddress(int id)
        {
            Address address;
            try
            {
                address = _dbContext.Addresses.Find(id);
                if (address != null)
                {
                    return address;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException();
            }
            finally
            {
                address = null;
            }
            return address;
        }

        public void AddAddress(Address address)
        {
            try
            {
                _dbContext.Addresses.Add(address);
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

        public void UpdateAddress(Address address)
        {
            try
            {
                _dbContext.Entry(address).State = EntityState.Modified;
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

        public Address DeleteAddress(int id)
        {
            Address address;
            try
            {
                address = _dbContext.Addresses.Find(id);
                if (address != null)
                {
                    _dbContext.Addresses.Remove(address);
                    _dbContext.SaveChanges();
                    return address;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException();
            }
            finally
            {
                address = null;
            }
            return address;
        }
        public bool CheckAddress(int id)
        {
            return _dbContext.Addresses.Any(e => e.Id == id);
        }
    }
}