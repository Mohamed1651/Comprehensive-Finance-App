namespace FinApp.Presentation
{
    public static class ConfigureCors
    {
        public static void InitializeCors(IApplicationBuilder app)
        {
            app.UseCors(builder =>
            {
                builder.WithOrigins("*");
            });
        }
    }
}
