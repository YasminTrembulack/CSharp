using Csharp_padrao_projeto.src.County.Argentina;
using Csharp_padrao_projeto.src.County.Brazil;

namespace Csharp_padrao_projeto.src
{
    public static class CompanyBuilderExtension
    {
        public static Company.CompanyBuilder InBrazil(this Company.CompanyBuilder builder)
        {
            builder.SetFactory(new BrazilProcessFactory());
            return builder;
        }
        public static Company.CompanyBuilder InArgentina(this Company.CompanyBuilder builder)
        {
            builder.SetFactory(new ArgentinaProcessFactory());
            return builder;
        }
    }
}