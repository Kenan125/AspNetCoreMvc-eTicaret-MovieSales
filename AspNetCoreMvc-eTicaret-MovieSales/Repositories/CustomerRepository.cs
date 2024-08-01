using AspNetCoreMvc_eTicaret_MovieSales.Data;
using AspNetCoreMvc_eTicaret_MovieSales.Entities;
using AspNetCoreMvc_eTicaret_MovieSales.Interfaces;

namespace AspNetCoreMvc_eTicaret_MovieSales.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MovieDbContext _context;

        public CustomerRepository(MovieDbContext context)   //DI Container'dan nesne istiyoruz.
        {
            _context = context;
        }
        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }
        public Customer Get(int id)
        {
            return _context.Customers.Find(id);
        }
        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);     //ara katmana ekler.
            _context.SaveChanges();         //veritabanına ekler.
        }

        public void Delete(int id)
        {
            _context.Customers.Remove(Get(id));    //Önce id'den nesneyi buluyor, ardından siliyor.
            _context.SaveChanges();             //veritabanından siler.
        }

        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);      //Doğrudan nesneyi ara katmandan siliyor.
            _context.SaveChanges();
        }
        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);      //Verilen nesneyi ara katmanda günceller.
            _context.SaveChanges();             //veritabanı güncellenir.
        }
    }
}
