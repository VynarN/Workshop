namespace ConsoleApplicationBase.Models
{
    public class ServiceA: Service
    {
        public override string ToString()
        {
            return $"Service A -> {this.GetHashCode()}";
        }
    }
}
