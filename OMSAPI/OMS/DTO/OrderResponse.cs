using OMS.Common;

namespace OMS.DTO
{
    public class OrderResponse
    {
        public int OrderId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime OrderCreateDt { get; set; }
    }
}
