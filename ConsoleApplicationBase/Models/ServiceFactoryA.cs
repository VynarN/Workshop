namespace ConsoleApplicationBase.Models
{
    public class ServiceFactoryA: ServiceFactory
    {
        public override Service CreateService()
        {
            return new ServiceA();
        }

        public override string ToString()
        {
            return $"Service factory A -> {this.GetHashCode()}";
        }
    }
}
