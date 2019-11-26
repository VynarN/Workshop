namespace ConsoleApplicationBase.Models.Factories
{
    public class ServiceFactoryB: ServiceFactory
    {
        public override Service CreateService()
        {
            return new ServiceB();
        }

        public override string ToString()
        {
            return $"Service factory A -> {this.GetHashCode()}";
        }
    }
}
