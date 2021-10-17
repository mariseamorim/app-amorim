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
    public class CadastrarAnimalCommand : Notifiable<Notification>, ICommand
    {

        public long Id { get;  set; }
        public string Nome { get;  set; }
        public DateTime DataNascimento { get;  set; }
        public string NomeMae { get;  set; }
        public string GTA { get;  set; }
        public void Validate()
        {
            AddNotifications(new Contract<Notifiable<Notification>>()
                .Requires()
                .IsTrue(!String.IsNullOrEmpty(Nome) , "Nome", "Informe o Nome"));
        }

       
    }
}
