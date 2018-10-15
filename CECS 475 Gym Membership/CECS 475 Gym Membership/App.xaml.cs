using System.Windows;
using GalaSoft.MvvmLight.Threading;

namespace CECS_475_Gym_Membership
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }
    }
}
