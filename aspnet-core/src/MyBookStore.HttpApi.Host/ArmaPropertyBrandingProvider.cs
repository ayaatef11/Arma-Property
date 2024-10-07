using Microsoft.Extensions.Localization;
using MyBookStore.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace MyBookStore;

[Dependency(ReplaceServices = true)]
public class ArmaPropertyBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<ArmaPropertyResource> _localizer;

    public ArmaPropertyBrandingProvider(IStringLocalizer<ArmaPropertyResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
