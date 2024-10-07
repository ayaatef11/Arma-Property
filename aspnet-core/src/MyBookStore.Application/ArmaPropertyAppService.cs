
using MyBookStore.Localization;
using Volo.Abp.Application.Services;

namespace MyBookStore;

/* Inherit your application services from this class.
 */
public abstract class ArmaPropertyAppService : ApplicationService
{
    protected ArmaPropertyAppService()
    {
        LocalizationResource = typeof(ArmaPropertyResource);
    }
}
