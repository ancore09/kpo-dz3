using ActressMas;
using RestaurantMAS.Models;

namespace RestaurantMAS.Agents;

public class SupervisorAgent: Agent
{
    public override void Act(Message message)
    {
        Console.WriteLine(message.Format());

        switch (message.ContentObj)
        {
            case MenuRequest:
                Send("menu", message.ContentObj);
                break;
            case MenuResponse:
                Send(message.ContentObj.ClientId, message.ContentObj);
                break;
            case OrderRequest:
                var orderAgent = new OrderAgent();
                Environment.Add(orderAgent, $"order-{message.ContentObj.ClientId}");
                
                Send($"order-{message.ContentObj.ClientId}", message.ContentObj);
                break;
            case OrderResponse:
                Send(message.ContentObj.ClientId, message.ContentObj);
                if (message.ContentObj.Status == "done")
                {
                    Environment.Remove($"order-{message.ContentObj.ClientId}");
                }
                break;
        }
    }
}