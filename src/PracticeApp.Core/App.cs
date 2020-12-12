using MvvmCross.IoC;
using MvvmCross.ViewModels;
using PracticeApp.Core.ViewModels.Home;

namespace PracticeApp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<HomeViewModel>();
        }
    }
}
