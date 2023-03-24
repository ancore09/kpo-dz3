using ActressMas;
using RestaurantMAS.Agents;

internal class Program
{
    public static void Main(string[] args)
    {
        var env = new EnvironmentMas(parallel: true, delayAfterTurn: 10);
        
        var visitorAgent = new VisitorAgent();
        env.Add(visitorAgent, "visitor");
        
        var menuAgent = new MenuAgent();
        env.Add(menuAgent, "menu");
        
        var supervisorAgent = new SupervisorAgent();
        env.Add(supervisorAgent, "supervisor");

        env.Start();
    }
}