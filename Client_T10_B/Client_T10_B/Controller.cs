using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Client_T10_B.Program;

namespace Client_T10_B
{
    public class Controller
    {
        private List<Observer> observers = new List<Observer>();  // registry of event handlers
        private User_m user;  // handles to Model objects

        public Controller(User_m u)
        {
            this.user = u;
        }

        // register(f) adds event-handler method  f  to the registry:
        public void register(Observer f) { observers.Add(f); }

        // handles request by dealing a card from the deck to the hand:
        public void handle(object sender, EventArgs e)
        {
            //TODO
            signalObservers();

        }
        // handles request by dealing TWO cards at a time:
        public void logoutHandle(object sender, EventArgs e)
        {
            // TODO
            signalObservers();
        }

        private void signalObservers() { foreach (Observer m in observers) { m(); } }
    }
}
