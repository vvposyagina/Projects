using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckProject
{
    class Check
    {
        int id;
        DateTime conclusionDate;
        string travelAgentName;
        string customerName;
        decimal orderCost;

        public int ID { get { return id; } }
        public DateTime ConclusionDate { get { return conclusionDate; } }
        public string TravelAgentName { get { return travelAgentName; } }
        public string CustomerName { get { return customerName; } }
        public decimal OrderCost { get { return orderCost; } }
        public Check(int id, DateTime conclusionDate, string travelAgentName, string customerName, decimal orderCost)
        {
            this.id = id;
            this.conclusionDate = conclusionDate;
            this.travelAgentName = travelAgentName;
            this.customerName = customerName;
            this.orderCost = orderCost;
        }
    }
}
