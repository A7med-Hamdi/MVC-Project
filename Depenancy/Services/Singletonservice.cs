namespace Depenancy.Services
{
    public class Singletonservice : ISingletonservice
    {
        public string msg { get; set; }
        public Singletonservice()
        {
            msg = Guid.NewGuid().ToString();
        }
    }
}
