using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public enum ApplicationStates
    {
        LoginScreen,
        TableScreen,
        MenuScreen,
        OrderViewScreen
    }


    public class ApplicationState
    {
        public static ApplicationState Instance { get; set; }
        public static EventHandler<EventArgs> StateUpdated;

        private ApplicationStates _currentState = ApplicationStates.LoginScreen;
        public ApplicationStates CurrentState
        {
            get => _currentState;
            set
            {
                _currentState = value;
                StateUpdated?.Invoke(this, EventArgs.Empty);
            }
        }


        public ApplicationState()
        {
            Instance = this;
        }

        public void SetState(ApplicationStates newState)
        {
            CurrentState = newState; 
        }
    }
}
