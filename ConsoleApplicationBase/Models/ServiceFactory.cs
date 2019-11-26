using ConsoleApplicationBase.Models;

namespace ConsoleApplicationBase.Models
{ 
    public abstract class ServiceFactory
    {
        public abstract Service CreateService();
    }
}
