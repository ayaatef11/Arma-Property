
using MyBookStore.Localization;
using Volo.Abp.Application.Services;

namespace MyBookStore;

public abstract class ArmaPropertyAppService : ApplicationService
{
    protected ArmaPropertyAppService()
    {
        LocalizationResource = typeof(ArmaPropertyResource);
    }
}
