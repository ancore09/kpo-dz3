using ActressMas;
using RestaurantMAS.Models;

namespace RestaurantMAS.Agents;

public class MenuAgent: Agent
{
    public override void Act(Message message)
    {
        switch (message.ContentObj)
        {
            case MenuRequest:
                Send(message.Sender, new MenuResponse() 
                    {
                        ClientId = message.ContentObj.ClientId, 
                        Menu = new[] {"pizza", "pasta"}
                    });
                break;
        }
    }
}