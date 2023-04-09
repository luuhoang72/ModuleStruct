namespace Microsoft.Extensions.DependencyInjection
{
    public static class MvcBuilderExtension
    {
        public static IMvcBuilder AddControllers<T>(this IMvcBuilder mvcBuilder)
        {
            mvcBuilder.AddApplicationPart(typeof(T).Assembly)
                .AddControllersAsServices();

            return mvcBuilder;
        }
    }
}
