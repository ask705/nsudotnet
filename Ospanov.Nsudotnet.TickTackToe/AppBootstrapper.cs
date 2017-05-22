using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using Caliburn.Micro;
using Caliburn.Micro.Autofac;
using TickTackToe.ViewModels;

namespace TickTackToe
{
    public class AppBootstrapper : AutofacBootstrapper<MainViewModel>
    {
        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<CellViewModel>().AsSelf();
            builder.RegisterType<SmallFieldViewModel>().AsSelf();
            builder.RegisterType<LargeFieldViewModel>().AsSelf();
            builder.Register(c => Container).As<IContainer>();
            base.ConfigureContainer(builder);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
    }
}
