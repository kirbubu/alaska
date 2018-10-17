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
    public class ChangeViewModel : ViewModelBase
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private ICommand _updateButtonCommand;
        private ICommand _deleteButtonCommand;
        public ErrorEmailPopup errorpop;

        /// <summary>
        /// Constructor, register with the Membership View Model to 
        /// Receive selected member information
        /// </summary>
        public ChangeViewModel()
        {
            Messenger.Default.Register<Membership>(this, ReceiveMember);
        }

        /// <summary>
        /// Receives member information from MembershipViewModel
        /// To display in the edit boxes
        /// </summary>
        /// <param name="obj">Membership to be passed to this view model</param>
        private void ReceiveMember(Membership obj)
        {
            FirstName = obj.FirstName;
            LastName = obj.LastName;
            Email = obj.Email;
            RaisePropertyChanged("FirstName");
            RaisePropertyChanged("LastName");
            RaisePropertyChanged("Email");
        }

        /// <summary>
        /// Button command for the update button
        /// </summary>
        public ICommand UpdateButtonCommand
        {
            get
            {
                _updateButtonCommand = new RelayCommand<ICloseable>(OnUpdateMemberAction);
                return _updateButtonCommand;
            }
        }

        /// <summary>
        /// Button command for the delete button
        /// </summary>
        public ICommand DeleteButtonCommand
        {
            get
            {
                _deleteButtonCommand = new RelayCommand<ICloseable>(DeleteButtonAction);
                return _deleteButtonCommand;
            }
        }

        /// <summary>
        /// Sends the member to be deleted to MembershipViewModel
        /// </summary>
        /// <param name="window">Current window to be closed</param>
        private void DeleteButtonAction(ICloseable window)
        {
            try
            {
                Messenger.Default.Send<MessageMember>(new MessageMember(FirstName, LastName, Email, "Delete"));
                if (window != null)
                    window.Close();
            }
            catch (EmailInvalidException)
            {
                errorpop = new ErrorEmailPopup();
                errorpop.Show();
            }
        }

        /// <summary>
        /// Sends the member to be updated
        /// </summary>
        /// <param name="window">Current window to be closed</param>
        private void OnUpdateMemberAction(ICloseable window)
        {
            try
            {
                Messenger.Default.Send<MessageMember>(new MessageMember(FirstName, LastName, Email, "Update"));
                
                if (window!=null)
                    window.Close();
            }
            catch (EmailInvalidException)
            {
                errorpop = new ErrorEmailPopup();
                errorpop.Show();
            }
        }

        /// <summary>
        /// First name property
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
        /// Last name property
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
        /// Email property
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

