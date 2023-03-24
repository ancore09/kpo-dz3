using ActressMas;
using RestaurantMAS.Models;

namespace RestaurantMAS.Agents;

public class OrderAgent: Agent
{
    public override void Setup()
    {
        Console.WriteLine("OrderAgent: ready");
    }
    
    public override async void Act(Message message)
    {
        Console.WriteLine(message.Format());
        switch (message.ContentObj)
        {
            case OrderRequest:
                Send(message.Sender, new OrderResponse() 
                    {
                        ClientId = message.ContentObj.ClientId, 
                        Status = "received"
                    });

                await Task.Delay(5000);
                
                Send(message.Sender, new OrderResponse() 
                    {
                        ClientId = message.ContentObj.ClientId, 
                        Status = "done"
                    });
                break;
            default:
                break;
        }
    }
}