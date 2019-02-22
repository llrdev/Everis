using System;
using Microsoft.Extensions.DependencyInjection;
using Teste.Business.Contract;
using Teste.Business.Implementation;

namespace Teste.DependencyInjectionRegister
{
    public class DIR
    {
        public DIR(IServiceCollection services)
        {

            #region Mapper

            //services.AddAutoMapper();

            #endregion

            #region Words

            services.AddTransient<IWords, WordsBusiness>();

            #endregion


        }
    }
}
