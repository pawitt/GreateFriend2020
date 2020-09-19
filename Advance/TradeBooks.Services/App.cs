using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TradeBooks.Services
{
    public class App
    {
        internal readonly AppDb db;

        public App(AppDb db)
        {
            this.db = db;

            Funds = new FundService(this);
            Unitholders = new UnitHolderService(this);
        }

        public FundService Funds { get; set; }
        public UnitHolderService Unitholders { get; set; }

        public int SaveChanges() => db.SaveChanges();

        public Task<int> SaveChangesAsync() => db.SaveChangesAsync();
    }

}
