using EntityFrameWorkCore_CodeFirst_4DBCommunication.Entities;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces
{
    public interface IOrdersRepository
    {
        Task<List<Orders>> GetOrders();
        Task<Orders> GetOrderById(int orderid);
        Task<int> AddOrder(Orders orderdetail);
        Task<bool> DeleteOrderById(int orderid);
        Task<bool> UpdateOrder(Orders orderdetail);
    }
}
