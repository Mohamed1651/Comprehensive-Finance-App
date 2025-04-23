namespace FinApp.Presentation
{
    public static class ConfigureCors
    {
        public static void InitializeCors(IApplicationBuilder app)
        {
            app.UseCors(policy =>
            {
                policy.WithOrigins("https://localhost:5173") // or AllowAnyOrigin() if you're okay with that
                      .AllowAnyMethod()
                      .AllowAnyHeader() // or .WithHeaders("Authorization") if you want to be strict
                      .AllowCredentials(); // only needed if using cookies or credentials
            });
        }
    }

}
