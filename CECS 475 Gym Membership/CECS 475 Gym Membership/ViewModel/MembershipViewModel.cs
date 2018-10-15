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
    

    public class MembershipViewModel : ViewModelBase
    {
        
        private ICommand _addButtonCommand;
        private ICommand _exitButtonCommand;
        private ICommand _saveButtonCommand;
        private ICommand _updateButtonCommand;
        private ICommand _deleteButtonCommand;
        private ICommand _cancelButtonCommand;
        private ICommand _mouseDoubleClickCommand;
        private static string file = "gym members.txt";
        private BindingList<Membership> _memberships = new BindingList<Membership>(MembershipUtils.ReadMemberships(file));
        private string _firstName;
        private string _lastName;
        private string _email;
        private List<Membership> _memberslist = MembershipUtils.ReadMemberships(file);
        public AddWindowView popup;
        public ChangeWindowView cpopup;
        public ErrorEmailPopup errorpop;
        public Membership ChosenMember { get; set; }


        public  MembershipViewModel()
        {
            //Memberships.Add(bob);
            //Console.WriteLine(bob);
        }

        public BindingList<Membership> Memberships
        {
            get
            {
                return _memberships;
            }
        }

        public ICommand AddButtonCommand
        {
            get
            {
                _addButtonCommand = new RelayCommand(OnAddMemberAction);
                return _addButtonCommand;
            }
        }

        public ICommand ExitButtonCommand
        {
            get
            {
                return null;
            }
        }

        public ICommand SaveButtonCommand
        {
            get
            {
                _saveButtonCommand = new RelayCommand(OnSaveMemberAction);
                RaisePropertyChanged("Memberships");
                return _saveButtonCommand;
                
            }
        }

        public ICommand UpdateButtonCommand
        {
            get
            {
                _updateButtonCommand = new RelayCommand(OnUpdateMemberAction);
                RaisePropertyChanged("Memberships");
                return _updateButtonCommand;
            }
        }

        public ICommand CancelButtonCommand
        {
            get
            {
                _cancelButtonCommand = new RelayCommand(OnCancelButtonAction);
                return _cancelButtonCommand;
            }
        }

        public ICommand MouseDoubleClick
        {
            get
            {
                _mouseDoubleClickCommand = new RelayCommand<object>(param => OnMouseDoubleClickAction(param));
                return _mouseDoubleClickCommand;
            }
        }


        private void OnAddMemberAction()
        {
                popup = new AddWindowView();
                popup.Show();
        }

        private void OnSaveMemberAction()
        {
            try
            {
                Membership obj = new Membership(FirstName,LastName,Email);
                _memberships.Add(obj);
                _memberslist.Add(obj);
                MembershipUtils.WriteMembership(file, obj);
                
                if (popup.IsActive)
                    popup.Close();
                FirstName = "";
                LastName = "";
                Email = "";
            }
            catch (EmailInvalidException)
            {
                
            }
        }

        private void OnUpdateMemberAction()
        {
            try
            {
                Membership obj = new Membership(FirstName, LastName, Email);
                int replaceIndex = Memberships.IndexOf(ChosenMember);
                _memberslist[replaceIndex] = obj;
                _memberships = new BindingList<Membership>(_memberslist);
                RaisePropertyChanged("Memberships");
                ChosenMember = null;
                if (cpopup.IsActive)
                    cpopup.Close();
            }
            catch (EmailInvalidException)
            {
                errorpop = new ErrorEmailPopup();
                errorpop.Show();
            }
        }

        private void OnCancelButtonAction()
        {
            if (popup.IsActive)
                popup.Close();
            FirstName = "";
            LastName = "";
            Email = "";
        }

        public void OnMouseDoubleClickAction(object o)
        {
            ChosenMember = (Membership)o;
            cpopup = new ChangeWindowView();
            cpopup.Show();
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


 
            private ICommand _okButtonClose;

           

            public ICommand OkButtonClose
            {
                get
                {
                    _okButtonClose = new RelayCommand(OkButtonCloseAction);
                    return _okButtonClose;
                }
            }


            public void OkButtonCloseAction()
            {
                if (errorpop.IsActive)
                    errorpop.Close();
            }
        


    }
    

    static class MembershipUtils
    {
        public static List<Membership> ReadMemberships(string path)
        {
            List<Membership> memberships = new List<Membership>();
            string currentDirectory = Environment.CurrentDirectory.Replace("bin\\Debug", "");
            path = currentDirectory + path;
            //StreamReader reader = new StreamReader(f.ToString());
            using (StreamReader reader = new StreamReader(path))
            {
                bool moreLines = true;
                while (moreLines)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                        moreLines = false;
                    else
                    {
                        string[] parts = line.Split('|');
                        memberships.Add(new Membership(parts[0], parts[1], parts[2]));
                    }

                }
            }

            return memberships;
        }

        public static void WriteMembership(string path, Membership m)
        {
            string currentDirectory = Environment.CurrentDirectory.Replace("bin\\Debug", "");
            path = currentDirectory + path;
            using (StreamWriter writer = new StreamWriter(path,append: true))
            {
                writer.WriteLine("\n" + m.FirstName + "|" + m.LastName + "|" + m.Email);
            }
        }

        public static void DeleteMembership(string path, Membership m)
        {
            string temp = Path.GetTempFileName();
            string delete = m.FirstName + "|" + m.LastName + "|" + m.Email;
            var newFileLines = File.ReadLines(path).Where(line => line != delete);

            File.WriteAllLines(temp, newFileLines);
            File.Delete(path);
            File.Move(temp, path);

        }
    }

}
