using System;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using CareKickOff.Pages;
using CareKickOff.Pages.Interfaces;
using CareKickOff.ViewModels;
using CareKickOff.ViewModels.Interfaces;

namespace CareKickOff
{
    internal class DependencyModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            RegisterCoreServices(builder);
            RegisterPages(builder);
            RegisterViewModels(builder);

        }

        private void RegisterCoreServices(ContainerBuilder builder)
        {
            var assembly = typeof(DependencyModule).GetTypeInfo().Assembly;
            builder.RegisterAssemblyTypes(assembly)
                   .Where(t => t.Name.EndsWith("Service", System.StringComparison.InvariantCulture))
                .AsImplementedInterfaces()
                .SingleInstance();
        }

        private void RegisterPages(ContainerBuilder builder)
        {
            var assembly = typeof(DependencyModule).GetTypeInfo().Assembly;
            builder.RegisterAssemblyTypes(assembly)
                   .Where(t => t.Name.EndsWith("Page", System.StringComparison.InvariantCulture))
                .Except<BasePage<IViewModel>>()
                .InstancePerDependency()
                .OnActivated(async obj => await InitializePage(obj));
        }

        private void RegisterViewModels(ContainerBuilder builder)
        {
            var assembly = typeof(DependencyModule).GetTypeInfo().Assembly;
            builder.RegisterAssemblyTypes(assembly)
                   .Where(t => t.Name.EndsWith("ViewModel", System.StringComparison.InvariantCulture))
                .Except<ViewModel>()
                .InstancePerDependency()
                .OnActivated(async obj => await InitializeViewModel(obj));
        }


        private Task InitializePage(IActivatedEventArgs<object> context)
        {
            object obj = context.Instance;
            if (obj is IPage<IViewModel> page)
            {
                return page.InitializeBindingContext();
            }

            return Task.FromResult(false);
        }

        private Task InitializeViewModel(IActivatedEventArgs<object> context)
        {
            object obj = context.Instance;
            if (obj is IViewModel viewModel)
            {
                return viewModel.OnInitializing();
            }

            return Task.FromResult(false);
        }
    }
}
