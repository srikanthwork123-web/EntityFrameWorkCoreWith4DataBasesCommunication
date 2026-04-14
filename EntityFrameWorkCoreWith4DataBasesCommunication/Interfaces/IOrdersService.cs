using EntityFrameWorkCore_CodeFirst_4DBCommunication.Dtos;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces
{
    public interface IOrdersService
    {
        Task<List<OrdersDto>> GetOrders();
        Task<OrdersDto> GetOrderById(int orderid);
        Task<int> AddOrder(OrdersDto orderdetail);
        Task<bool> DeleteOrderById(int orderid);
        Task<bool> UpdateOrder(OrdersDto orderdetail);
    }
}
