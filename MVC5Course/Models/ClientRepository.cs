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

        public Client Delete(Client client)
        {
            client.IsDeleted = true;

            foreach (var item in client.Order.ToList())
            {
                ((FabricsEntities)this.UnitOfWork.Context).OrderLine.RemoveRange(item.OrderLine);
            }

            ((FabricsEntities)this.UnitOfWork.Context).Order.RemoveRange(client.Order);

            return client;
        }
	}

	public  interface IClientRepository : IRepository<Client>
	{

	}
}