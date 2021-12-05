using CwkEshop.Api.Registrars;

namespace CwkEshop.Api.Extensions
{
    public static class RegistrarExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder, Type scanningType)
        {
            var registrars = scanningType.Assembly.GetTypes()
                .Where(t => t.IsAssignableTo(typeof(IRegistrar)) && !t.IsAbstract && !t.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IRegistrar>();

            foreach (var registrar in registrars)
            {
                registrar.RegisterServices(builder);
            }
        }
    }
}
