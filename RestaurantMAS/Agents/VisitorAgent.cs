using ActressMas;
using RestaurantMAS.Models;

namespace RestaurantMAS.Agents;

public class VisitorAgent: Agent
{
    public override void Setup()
    {
        Send("supervisor", new MenuRequest {ClientId = Name});
    }
    
    public override void Act(Message message)
    {
        Console.WriteLine(message.Format());
        switch (message.ContentObj)
        {
            case MenuResponse:
                var menu = message.ContentObj.Menu as string[];
                Send("supervisor", new OrderRequest()
                {
                    ClientId = Name,
                    Items = new []{ menu[0] }
                });
                break;
            case OrderResponse orderResponse:
                Console.WriteLine(orderResponse.Status == "done" ? "Client: got food" : "Client: waiting for food");
                break;
        }
    }
}