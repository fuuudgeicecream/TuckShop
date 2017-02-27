using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuckShop.Models;

namespace TuckShop.BusinessLogic
{
    public class ProcessOrder
    {
        public ProcessOrderResponseModel processOrderTask(List<OrderInputModel> list, User userName)
        {
            var itemList = new List<LineItem>();
            foreach(var item in list)
            {
                for(var i =0; i < item.Count; i++)
                {
                    var lineItem = new LineItem();
                    lineItem.ProductId = int.Parse(item.ProductId);
                    itemList.Add(lineItem);
                }
            }
            var order = new Order();
            order.Name = userName.Name;
            order.Size = itemList.Count.ToString();
            order.UserId = userName.Id;
            order.Status = "Pending";
            var response = new ProcessOrderResponseModel();
            response.order = order;
            response.lineItems = itemList;
            return response;
       }
    }
}
