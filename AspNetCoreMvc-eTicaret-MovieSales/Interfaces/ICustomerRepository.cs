using AspNetCoreMvc_eTicaret_MovieSales.Entities;

namespace AspNetCoreMvc_eTicaret_MovieSales.Interfaces
{
    public interface ICustomerRepository
    {
        public List<Customer> GetAll();
        public Customer Get(int id);

        public void Add(Customer movie);
        public void Update(Customer movie);
        public void Delete(int id);
        public void Delete(Customer movie);
    }
}
