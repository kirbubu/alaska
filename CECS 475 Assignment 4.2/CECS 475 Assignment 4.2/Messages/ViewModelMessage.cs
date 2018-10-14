using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;

namespace CECS_475_Assignment_4._2.Messages
{
    class ViewModelMessage : MessageBase
    {
        public string Text { get; set; }
    }
}
