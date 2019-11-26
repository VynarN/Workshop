namespace ConsoleApplicationBase.Models
{
    public class ServiceB : Service
    {
        public override string ToString()
        {
            return $"Service A -> {this.GetHashCode()}";
        }
    }
}
