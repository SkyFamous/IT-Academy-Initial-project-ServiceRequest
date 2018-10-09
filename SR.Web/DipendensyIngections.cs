using BAL.Repositories;
using BAL.Services;
using DAL;
using DAL.Repositories;
using Ninject;

namespace Web
{
    public class DipendensyIngections
    {
        public static IKernel Initialize(IKernel kernel)
        {
            kernel.Bind<UnitOfWork>().ToSelf().InSingletonScope().WithConstructorArgument("SRDBContext");

            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
            kernel.Bind<ICompanyRepository>().To<CompanyRepository>();
            kernel.Bind<ICustomerRepository>().To<CustomerRepository>();
            kernel.Bind<IExecutorRepository>().To<ExecutorRepository>();
            kernel.Bind<IOfferRepository>().To<OfferRepository>();
            kernel.Bind<ICompOfferRepository>().To<CompOfferRepository>();
            kernel.Bind<ICustOfferRepository>().To<CustOfferRepository>();

            kernel.Bind<ICompanyService>().To<CompanyService>();
            kernel.Bind<ICustomerService>().To<CustomerService>();

            return kernel;
        }
    }
}