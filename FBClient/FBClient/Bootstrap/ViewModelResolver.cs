using Microsoft.Practices.ServiceLocation;
using System.Linq;
using System.Reflection;

namespace FBClient.Bootstrap
{
    public class ViewModelResolver
    {
        public ViewModelResolver()
        {
        }

        public object Resolve(string viewModelName)
        {

            var vmtype = this.GetType()
                .GetTypeInfo()
                .Assembly
                .DefinedTypes
                .FirstOrDefault(t => t.Name.Equals(viewModelName))
                .AsType();

            return ServiceLocator.Current.GetInstance(vmtype);
        }
    }
}


