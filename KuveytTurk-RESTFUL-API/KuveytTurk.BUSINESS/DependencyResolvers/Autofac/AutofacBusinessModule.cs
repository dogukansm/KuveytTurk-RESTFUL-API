using Autofac;
using KuveytTurk.BUSINESS.Abstract;
using KuveytTurk.BUSINESS.Concrete;
using KuveytTurk.DATAACCESS.Abstract;
using KuveytTurk.DATAACCESS.Concrete.EntityFramework;
using KuveytTurk.DATAACCESS.Concrete.EntityFramework.Context;

namespace KuveytTurk.BUSINESS.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    { 
        builder.RegisterType<KuveytTurkManager>().As<IKuveytTurkService>();
        builder.RegisterType<EFKuveytTurkTransactionDAL>().As<IKuveytTurkTransactionDAL>();

        builder.RegisterType<BankContext>().InstancePerLifetimeScope();
    }
}
