using EntityFrameWorkCore_CodeFirst_4DBCommunication.DbConnect;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Entities;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Migrations.Orders;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly OrdersContext _ordersContext;
        public OrdersRepository(OrdersContext ordersContext)
        {
            _ordersContext=ordersContext;
        }
        public async Task<int> AddOrder(Orders orderdetail)
        {
            //add the record by using addasync
            await _ordersContext.orders123.AddAsync(orderdetail);

            _ordersContext.SaveChanges();//it will commit/save the data perminently in table
            return 1;
        }

        public async Task<bool> DeleteOrderById(int orderid)
        {
            var result = await _ordersContext.orders123.Where(e => e.orderid == orderid).FirstOrDefaultAsync();
            if (result != null)
            {//Here Remove() method is used for removing the data from database.
                _ordersContext.orders123.Remove(result);
                _ordersContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Orders> GetOrderById(int orderid)
        {
           var result=await _ordersContext.orders123.Where(e=>e.orderid==orderid).FirstOrDefaultAsync();
            if(result == null )
            {
                return null;
            }
            else
            {
                return result;
            }
        }

        public async Task<List<Orders>> GetOrders()
        {
            var result = _ordersContext.orders123.ToList();
            if (result.Count == 0)
            {
                return null;
            }
            else
            {
                return result;
            }
        }

        public async Task<bool> UpdateOrder(Orders orderdetail)
        {
          
            _ordersContext.orders123.Update(orderdetail);
            await _ordersContext.SaveChangesAsync();
            return true;
        }
    }
}
