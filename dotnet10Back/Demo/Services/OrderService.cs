public class OrderService : IOrderService
{
    public string GetOrder(int id)
    {
        return $"Order #{id} from service";
    }
}
