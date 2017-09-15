using HearthstoneNHibernate.CardClasses;
using HearthstoneNHibernate.Domain;
using HearthstoneNHibernate.Services;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneNHibernate
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {

            var session = DbService.OpenSession();
            Console.WriteLine("Session opened");
            DeleteDatabase();
            RecreateDatabase();
            log.Debug("Database recreated");
            Ability ability = new Ability()
            {
                AbilityName = "Windfury",
            };
            session.Save(ability);
            DbService.CloseSession(session);
            Console.WriteLine("Session closed");
        }

        private static void DeleteDatabase()
        {
            var config = DbService.Configure();
            var export = new SchemaExport(config);
            export.Drop(false, true);
        }
        private static void RecreateDatabase()
        {
            var config = DbService.Configure();
            var export = new SchemaExport(config);
            export.Create(true, true);
        }
    }
}
