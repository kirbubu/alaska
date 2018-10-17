using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using CECS_475_Gym_Membership.Model;
using System.Windows.Input;
using System.Windows.Data;
using CECS_475_Gym_Membership.View;
using System.ComponentModel;


namespace CECS_475_Gym_Membership.ViewModel
{
    public class EmailErrorViewModel : ViewModelBase
    {


        private ICommand _okButtonClose;
        public ICommand OkButtonClose
        {
            get
            {
                _okButtonClose = new RelayCommand<ICloseable>(OkButtonCloseAction);
                return _okButtonClose;
            }
        }


        public void OkButtonCloseAction(ICloseable window)
        {
            if (window != null)
                window.Close();
        }

    }
}
