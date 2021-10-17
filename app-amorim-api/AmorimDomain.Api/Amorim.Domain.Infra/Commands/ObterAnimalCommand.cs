using Amorim.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amorim.Domain.Commands
{
    public class ObterAnimalCommand : Notifiable<Notification>, ICommand
    {
        public string TermoPesquisado { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract<Notifiable<Notification>>()
                .Requires()
                .IsTrue(!String.IsNullOrEmpty(TermoPesquisado), "TermoPesquisado", "Parâmetros para busca não informados"));
        }
    }
}
