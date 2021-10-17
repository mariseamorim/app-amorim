using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amorim.Domain.Commands.Contracts
{
    public class CommandResult : Notifiable<Notification>, ICommandResult
    {
        public CommandResult()
        {
        }

        public CommandResult(IReadOnlyCollection<Notification> notifications)
        {
            this.AddNotifications(notifications);
        }

        private object _data;
        public object Data
        {
            get
            {
                if (!this.IsValid)
                    return this.Notifications;
                else
                    return this._data;
            }
            set
            {
                _data = value;
            }
        }

        public bool Success
        {
            get
            {
                return this.IsValid;
            }
        }

        public bool Invalid
        {
            get
            {
                return !IsValid;
            }
        }
    }
}
