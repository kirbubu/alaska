using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECS_475_Gym_Membership.Model
{
    public class MessageMember : Membership
    {
        public string Message { get; set; }

        public MessageMember(string FirstName, string LastName, string Email, string Message) : base(FirstName,LastName,Email)
        {
            this.Message = Message;
        }

    }
}
