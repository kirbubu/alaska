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
    public class AddViewModel : ViewModelBase
    {
        private ICommand _saveButtonCommand;
        private ICommand _cancelButtonCommand;
        private string _firstName;
        private string _lastName;
        private string _email;
        public ErrorEmailPopup errorpop;

        public AddViewModel()
        {
            
        }

        public ICommand CancelButtonCommand
        {
            get
            {
                _cancelButtonCommand = new RelayCommand<ICloseable>(OnCancelButtonAction);
                return _cancelButtonCommand;
            }
        }


        public ICommand SaveButtonCommand
        {
            get
            {
                _saveButtonCommand = new RelayCommand<ICloseable>(OnSaveMemberAction);
                return _saveButtonCommand;

            }
        }

        private void OnSaveMemberAction(ICloseable window)
        {
            try
            {
                Messenger.Default.Send<MessageMember>(new MessageMember(FirstName, LastName, Email, "Add"));
                if (window != null)
                    window.Close();
            }
            catch (EmailInvalidException)
            {
                errorpop = new ErrorEmailPopup();
                errorpop.Show();
            }
            
                
        }

        private void OnCancelButtonAction(ICloseable window)
        {
           
            if (window != null)
                window.Close();
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
    }
}
