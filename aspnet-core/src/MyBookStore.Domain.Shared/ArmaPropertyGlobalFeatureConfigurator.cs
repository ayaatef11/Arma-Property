using Volo.Abp.Threading;

namespace MyBookStore;

public static class ArmaPropertyGlobalFeatureConfigurator
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        OneTimeRunner.Run(() =>
        {
              
        });
    }
}
