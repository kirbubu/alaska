using System.Windows;
using GalaSoft.MvvmLight.Threading;

namespace CECS_475_Assignment_4._2
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
