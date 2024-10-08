    using Microsoft.Extensions.DependencyInjection;
    namespace TempLaboClini.Application.Services
{
    public static class ValidationConfiguration
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
           // services.AddTransient<IValidator<User>, UserValidator>();
            return services;
        }
    }
 
   // public class UserValidator : AbstractValidator<User>// debe existir una entidad User
   // {src/Domain/Entities/ debe ir alla
   //     public UserValidator()
   //     {
   //         RuleFor(x => x.Email).NotEmpty().EmailAddress();
   //         RuleFor(x => x.Password).MinimumLength(8);
   //     }
   // }
}
