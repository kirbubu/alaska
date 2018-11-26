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
        public MembershipView mainview;

        /// <summary>
        /// Construcotr that initializes the register to receives messages from the popups this
        /// view model creates
        /// </summary>
        public  MembershipViewModel()
        {
            Messenger.Default.Register<MessageMember>(this, ReceiveMessage);
            //Memberships.Add(bob);
            //Console.WriteLine(bob);
        }

        /// <summary>
        /// Receives a message from a MessageMember and performs an action (add, update, delete)
        /// </summary>
        /// <param name="obj">Object to be added, updated, or deleted</param>
        public void ReceiveMessage(MessageMember obj)
        {
            if (obj.Message == "Add")
            {
                Membership mem = obj;
                _memberships.Add(obj);
                _memberslist.Add(obj);
                MembershipUtils.WriteMembership(file, obj);
                RaisePropertyChanged("Memberships");
            }
            if (obj.Message == "Update")
            {
                Membership mem = obj;
                int replaceIndex = Memberships.IndexOf(ChosenMember);
                _memberslist[replaceIndex] = obj;
                _memberships = new BindingList<Membership>(_memberslist);
                MembershipUtils.UpdateMembership(file, ChosenMember, obj);
                RaisePropertyChanged("Memberships");
                ChosenMember = null;
            }
            if(obj.Message == "Delete")
            {
                MembershipUtils.DeleteMembership(file, ChosenMember);
                //_memberships = new BindingList<Membership>(MembershipUtils.ReadMemberships(file));
                _memberslist.Remove(ChosenMember);
                _memberships = new BindingList<Membership>(_memberslist);
                ChosenMember = null;
                RaisePropertyChanged("Memberships");
            }

        }

        /// <summary>
        /// Property of Memberships that is a binding list for the list box ItemSource Binding
        /// </summary>
        public BindingList<Membership> Memberships
        {
            get
            {
                return _memberships;
            }
        }

        /// <summary>
        /// Command for the add button
        /// </summary>
        public ICommand AddButtonCommand
        {
            get
            {
                _addButtonCommand = new RelayCommand(OnAddMemberAction);
                return _addButtonCommand;
            }
        }

        /// <summary>
        /// Command for the exit button
        /// </summary>
        public ICommand ExitButtonCommand
        {
            get
            {
                _exitButtonCommand = new RelayCommand(ExitButtonAction);
                return _exitButtonCommand; 
            }
        }
        
        /// <summary>
        /// Command for the double click on a selected item in the ListBox
        /// </summary>
        public ICommand MouseDoubleClick
        {
            get
            {
                _mouseDoubleClickCommand = new RelayCommand<object>(OnMouseDoubleClickAction);
                return _mouseDoubleClickCommand;
            }
        }

        /// <summary>
        /// Creates a new popup for the adding member window menu
        /// </summary>
        private void OnAddMemberAction()
        {
                popup = new AddWindowView();
                popup.Show();
        }

        /// <summary>
        /// Exits the program
        /// </summary>
        private void ExitButtonAction()
        {
            System.Environment.Exit(0);
        }

        /// <summary>
        /// Choses the selected item from the Listbox andn then opens a new menu, passing the value to the 
        /// update/delete menu
        /// </summary>
        /// <param name="o"></param>
        public void OnMouseDoubleClickAction(object o)
        {
            ChosenMember = (Membership)o;
            cpopup = new ChangeWindowView();
            Messenger.Default.Send<Membership>(ChosenMember);
            cpopup.Show();
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
    

    static class MembershipUtils
    {

        /// <summary>
        /// Reads all lines of a textfile and parses them
        /// into Membership objects. 
        /// </summary>
        /// <param name="path">File name to read from</param>
        /// <returns>List of all the parsed memberships</returns>
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
                    else if (line == "")
                        continue;
                    else
                    {
                        string[] parts = line.Split('|');
                        memberships.Add(new Membership(parts[0], parts[1], parts[2]));
                    }

                }
            }

            return memberships;
        }

        /// <summary>
        /// Utility function that reads a file from the current directory and 
        /// writes a membership object into it.
        /// </summary>
        /// <param name="path">File to write to</param>
        /// <param name="m">Membership object to be written into the file</param>
        public static void WriteMembership(string path, Membership m)
        {
            string currentDirectory = Environment.CurrentDirectory.Replace("bin\\Debug", "");
            path = currentDirectory + path;
            using (StreamWriter writer = new StreamWriter(path,append: true))
            {
                writer.WriteLine("\n"+m.FirstName + "|" + m.LastName + "|" + m.Email);
            }
        }
        
        /// <summary>
        /// Utility function that deletes a given membership from the file designated.
        /// </summary>
        /// <param name="path">File to be modified</param>
        /// <param name="m">Membership object to be delete from the file</param>
        public static void DeleteMembership(string path, Membership m)
        {
            string currentDirectory = Environment.CurrentDirectory.Replace("bin\\Debug", "");
            path = currentDirectory + path;
            string temp = Path.GetTempFileName();
            string delete = m.FirstName + "|" + m.LastName + "|" + m.Email;
            var newFileLines = File.ReadLines(path).Where(line => line != delete);

            File.WriteAllLines(temp, newFileLines);
            File.Delete(path);
            File.Move(temp, path);

        }

        public static void UpdateMembership(string path, Membership replace, Membership update)
        {
            string currentDirectory = Environment.CurrentDirectory.Replace("bin\\Debug", "");
            path = currentDirectory + path;
            string temp = Path.GetTempFileName();
            string delete = replace.FirstName + "|" + replace.LastName + "|" + replace.Email;
            string replacestring = update.FirstName + "|" + update.LastName + "|" + update.Email;
            var newFileLines = File.ReadLines(path).Select(line => line.Replace(delete, replacestring));

            File.WriteAllLines(temp, newFileLines);
            File.Delete(path);
            File.Move(temp, path);

        }
    }

}
