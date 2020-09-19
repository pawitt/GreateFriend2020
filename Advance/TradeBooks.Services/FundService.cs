using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TradeBooks.Models;

namespace TradeBooks.Services
{
    public class FundService : ServiceBase<Fund>
    {
        public FundService(App app) : base(app)
        {
            // 
        }
        public override Fund Add(Fund item) 
        { 
            //if (Query(x=>x.Code==item.Code).Any())
            if (All().Any(x=>x.Code==item.Code))
            {
                throw new Exception("Duplicate fund code");
            }
            return base.Add(item);
        }
    }
}
