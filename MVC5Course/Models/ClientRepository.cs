using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ClientRepository : EFRepository<Client>, IClientRepository
	{
        public override IQueryable<Client> All()
        {
            return base.All().Where(p => p.IsDeleted == false);
        }

        public Client Find(int id)
        {

            return this.All().FirstOrDefault(p => p.ClientId == id);
        }
        
        public void Delete(Client client)
        {
            client.IsDeleted = true;

            var db = ((FabricsEntities)this.UnitOfWork.Context);
            foreach (var item in db.Order.ToList())
            {
                db.OrderLine.RemoveRange(item.OrderLine);
            }
            db.Order.RemoveRange(client.Order);
        }

        internal IQueryable<Client> SearchByGender(string gender)
        {
            return this.All().Where(p => p.Gender == gender);
        }
	}

	public  interface IClientRepository : IRepository<Client>
	{

	}
}