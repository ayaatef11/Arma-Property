using Microsoft.Extensions.Localization;
using MyBookStore.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace MyBookStore;

[Dependency(ReplaceServices = true)]
public class MyBookStoreBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<MyBookStoreResource> _localizer;

    public MyBookStoreBrandingProvider(IStringLocalizer<MyBookStoreResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
