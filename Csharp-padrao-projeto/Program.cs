
using Csharp_padrao_projeto.src;
using Csharp_padrao_projeto.src.Process;


var builder = Company.GetBuilder();
 
builder
    .SetName("Mercado Libre")
    .InArgentina()
    .SetInitialCapital(20_000_000);
 
builder
    .AddEmploye("Marquitos Guapo", 50_000)
    .AddEmploye("Paulito Pino", 20_000);
 
Company.New(builder);
 
// Me rendí, me voy a Brasil
builder = Company.GetBuilder();
 
builder
    .SetName("Mercado Livre")
    .InBrazil()
    .SetInitialCapital(1_000_000);
 
builder
    .AddEmploye("Marcos Bonito", 2_500)
    .AddEmploye("Paulo Pinheiro", 1_000);
 
Company.New(builder);
 
Employee employe = new Employee();
employe.Name = "Xispita";
employe.Wage = 2_000;
Company.Current.Contract(employe);
 
Company.Current.Dismiss("Marcos Bonito");
 
Company.Current.PayWages();

// public abstract class Process
// {
//     public abstract string Title { get; }
// }

// public class Employe
// {
//     public string Name { get; set; }
//     public decimal Wage { get; set; }
// }

// public abstract class DismissalProcess : Process
// {
//     public abstract void Apply(DismissalArgs args);
// }

// public abstract class WagePaymentProcess : Process
// {
//     public abstract void Apply(WagePaymentArgs args);
// }
// public class ProcessArgs
// {
//     private static ProcessArgs empty = new ProcessArgs();
//     public static ProcessArgs Empty => empty;
// }
 
// public class DismissalArgs : ProcessArgs
// {
//     public Company Company { get; set; }
//     public Employe Employe { get; set; }
// }
 
// public class WagePaymentArgs : ProcessArgs
// {
//     public Company Company { get; set; }
//     public Employe Employe { get; set; }
// }

// public interface IProcessFactory
// {
//     public WagePaymentProcess CreateWagePaymentProcess();
//     public DismissalProcess CreateDismissalProcess();
// }

// public class BrazilDismissalProcess : DismissalProcess
// {
//     public override string Title => "Demissão de Funcionário";

//     public override void Apply(DismissalArgs args)
//     {
//         args.Company.Money -= 2 * args.Employe.Wage;
//     }
// }
 
// public class BrazilWagePaymentProcess : WagePaymentProcess
// {
//     public override string Title => "Pagamento de Salário";
 
//     public override void Apply(WagePaymentArgs args)
//     {
//         args.Company.Money -= 1.45m * args.Employe.Wage + 500;
//     }
// }
 
// public class BrazilProcessFactory : IProcessFactory
// {
//     public DismissalProcess CreateDismissalProcess()
//         => new BrazilDismissalProcess();
 
//     public WagePaymentProcess CreateWagePaymentProcess()
//         => new BrazilWagePaymentProcess();
// }

// public class ArgentinaDismissalProcess : DismissalProcess
// {
//     public override string Title => "Despido de Empleados";
 
//     public override void Apply(DismissalArgs args)
//     {
//         args.Company.Money -= 3 * args.Employe.Wage;
//     }
// }
 
// public class ArgentinaWagePaymentProcess : WagePaymentProcess
// {
//     public override string Title => "Pago de salario";
 
//     public override void Apply(WagePaymentArgs args)
//     {
//         args.Company.Money -= 1.65m * args.Employe.Wage + 700;
//     }
// }
 
// public class ArgentinaProcessFactory : IProcessFactory
// {
//     public DismissalProcess CreateDismissalProcess()
//         => new ArgentinaDismissalProcess();
 
//     public WagePaymentProcess CreateWagePaymentProcess()
//         => new ArgentinaWagePaymentProcess();
// }
 
// public class Company
// {
//     // Estrutura Singleton
//     private Company() { }
//     private static Company crr = null;
//     public static Company Current => crr;
     
//     public string Name { get; set; }
//     public decimal Money { get; set; }
 
//     private List<Employe> employes = new List<Employe>();
//     public IEnumerable<Employe> Employes => employes;
 
//     private DismissalProcess dismissalProcess = null;
//     private WagePaymentProcess wagePaymentProcess = null;
 
//     public void Contract(Employe employe)
//     {
//         employes.Add(employe);
//     }
 
//     public void Dismiss(string name)
//     {
//         var employe = this.Employes
//             .FirstOrDefault(x => x.Name == name);
 
//         if (employe == null)
//             return;
 
//         DismissalArgs args = new DismissalArgs();
//         args.Employe = employe;
//         args.Company = this;
 
//         dismissalProcess.Apply(args);
 
//         employes.Remove(employe);
//     }
 
//     public void PayWages()
//     {
//         foreach (var employe in this.Employes)
//         {
//             WagePaymentArgs args = new WagePaymentArgs();
//             args.Employe = employe;
//             args.Company = this;
 
//             wagePaymentProcess.Apply(args);
//         }
//     }
 
//     // Classes Aninhadas: Isso permite que CompanyBuilder veja todos os campos privados de Company
//     public class CompanyBuilder
//     {
//         private Company company = new Company();
 
//         public Company Build()
//             => this.company;
         
//         public CompanyBuilder SetName(string name)
//         {
//             company.Name = name;
//             return this;
//         }
 
//         public CompanyBuilder SetFactory(IProcessFactory factory)
//         {
//             company.dismissalProcess = factory.CreateDismissalProcess();
//             company.wagePaymentProcess = factory.CreateWagePaymentProcess();
//             return this;
//         }
 
//         public CompanyBuilder SetInitialCapital(decimal money)
//         {
//             company.Money = money;
//             return this;
//         }
 
//         public CompanyBuilder AddEmploye(string name, decimal wage)
//         {
//             Employe employe = new Employe();
//             employe.Name = name;
//             employe.Wage = wage;
//             company.Contract(employe);
//             return this;
//         }
//     }
 
//     public static CompanyBuilder GetBuilder()
//         => new CompanyBuilder();
     
//     public static void New(CompanyBuilder builder)
//         => crr = builder.Build();
// }


// public static class CompanyBuilderExtension
// {
//     public static Company.CompanyBuilder InBrazil(this Company.CompanyBuilder builder)
//     {
//         builder.SetFactory(new BrazilProcessFactory());
//         return builder;
//     }
//     public static Company.CompanyBuilder InArgentina(this Company.CompanyBuilder builder)
//     {
//         builder.SetFactory(new ArgentinaProcessFactory());
//         return builder;
//     }
// }