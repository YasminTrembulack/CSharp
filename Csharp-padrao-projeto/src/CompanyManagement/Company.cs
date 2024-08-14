using Csharp_padrao_projeto.src.Process;
using Csharp_padrao_projeto.src.Process.Dismissal;
using Csharp_padrao_projeto.src.Process.WagePayment;

namespace Csharp_padrao_projeto.src
{
    
public class Company
{
    // Estrutura Singleton
    private Company() { }
    private static Company crr = null;
    public static Company Current => crr;
     
    public string Name { get; set; }
    public decimal Money { get; set; }
 
    private List<Employee> employes = new List<Employee>();
    public IEnumerable<Employee> Employes => employes;
 
    private DismissalProcess dismissalProcess = null;
    private WagePaymentProcess wagePaymentProcess = null;
 
    public void Contract(Employee employe)
    {
        employes.Add(employe);
    }
 
    public void Dismiss(string name)
    {
        var employe = this.Employes
            .FirstOrDefault(x => x.Name == name);
 
        if (employe == null)
            return;
 
        DismissalArgs args = new DismissalArgs();
        args.Employe = employe;
        args.Company = this;
 
        dismissalProcess.Apply(args);
 
        employes.Remove(employe);
    }
 
    public void PayWages()
    {
        foreach (var employe in this.Employes)
        {
            WagePaymentArgs args = new WagePaymentArgs();
            args.Employe = employe;
            args.Company = this;
 
            wagePaymentProcess.Apply(args);
        }
    }
 
    // Classes Aninhadas: Isso permite que CompanyBuilder veja todos os campos privados de Company
    public class CompanyBuilder
    {
        private Company company = new Company();
 
        public Company Build()
            => this.company;
         
        public CompanyBuilder SetName(string name)
        {
            company.Name = name;
            return this;
        }
 
        public CompanyBuilder SetFactory(IProcessFactory factory)
        {
            company.dismissalProcess = factory.CreateDismissalProcess();
            company.wagePaymentProcess = factory.CreateWagePaymentProcess();
            return this;
        }
 
        public CompanyBuilder SetInitialCapital(decimal money)
        {
            company.Money = money;
            return this;
        }
 
        public CompanyBuilder AddEmploye(string name, decimal wage)
        {
            Employee employe = new Employee();
            employe.Name = name;
            employe.Wage = wage;
            company.Contract(employe);
            return this;
        }
    }
 
    public static CompanyBuilder GetBuilder()
        => new CompanyBuilder();
     
    public static void New(CompanyBuilder builder)
        => crr = builder.Build();
}
}