/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:CECS_475_Gym_Membership.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using CECS_475_Gym_Membership.Model;

namespace CECS_475_Gym_Membership.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initialized Constructor 
        /// </summary>
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MembershipViewModel>();
            SimpleIoc.Default.Register<AddViewModel>();
            SimpleIoc.Default.Register<EmailErrorViewModel>();
            SimpleIoc.Default.Register<ChangeViewModel>();
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MembershipViewModel MembershipViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MembershipViewModel>();
            }
        }

        /// <summary>
        /// Gets the Add View Model
        /// </summary>
        public AddViewModel AddViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddViewModel>();
            }
        }

        /// <summary>
        /// Gets the Email Error View Model
        /// </summary>
        public EmailErrorViewModel EmailErrorViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EmailErrorViewModel>();
            }
        }

        /// <summary>
        /// Gets the Change View Model
        /// </summary>
        public ChangeViewModel ChangeViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ChangeViewModel>();
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}