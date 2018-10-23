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

        /// <summary>
        /// Constructor (Empty)
        /// </summary>
        public AddViewModel()
        {
            FirstName = "";
            LastName = "";
            Email = "";
        }

        /// <summary>
        /// Command for the cancel button
        /// </summary>
        public ICommand CancelButtonCommand
        {
            get
            {
                _cancelButtonCommand = new RelayCommand<ICloseable>(OnCancelButtonAction);
                return _cancelButtonCommand;
            }
        }

        /// <summary>
        /// Command for the save button
        /// </summary>
        public ICommand SaveButtonCommand
        {
            get
            {
                _saveButtonCommand = new RelayCommand<ICloseable>(OnSaveMemberAction);
                return _saveButtonCommand;

            }
        }

        /// <summary>
        /// Sends information to add the member to the list and save the member
        /// </summary>
        /// <param name="window">Current window to be closed</param>
        private void OnSaveMemberAction(ICloseable window)
        {
            try
            {
                if (FirstName.Length > 15 || LastName.Length > 15 || FirstName == "" || LastName == "")
                    throw new EmailInvalidException();
                Messenger.Default.Send<MessageMember>(new MessageMember(FirstName, LastName, Email, "Add"));
                if (window != null)
                    window.Close();
                FirstName = "";
                LastName = "";
                Email = "";
            }
            catch (EmailInvalidException)
            {
                errorpop = new ErrorEmailPopup();
                errorpop.Show();
            }
            
                
        }

        /// <summary>
        /// Closes the current window 
        /// </summary>
        /// <param name="window">Current window to be closed</param>
        private void OnCancelButtonAction(ICloseable window)
        {
           
            if (window != null)
                window.Close();
        }

        /// <summary>
        /// Property for first name
        /// </summary>
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

        /// <summary>
        /// Property for last name
        /// </summary>
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

        /// <summary>
        /// Property for email
        /// </summary>
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
