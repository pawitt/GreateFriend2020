﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradeBooks.Models;
using TradeBooks.Services;

namespace TradeBooks.Web.Areas.ApiV1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FundsController : ControllerBase
    {
        private readonly App app;
        public FundsController(App app)
        {
            this.app = app;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Fund>> GetAll()
        {
            // Get /api/v1/funds
            var items = app.Funds.All().OrderBy(x => x.Code).ToList();
            return items;
        }

        [HttpGet("{code}")]
        public ActionResult<Fund> GetByCode(string code)
        {
            // Get /api/v1/funds
            var item = app.Funds.Find(code);
            //if (item == null) return NotFound();
            if (item == null) return NotFound( new ProblemDetails { Status=404, Title = "funds not fund" , Detail ="funds not fund" } );
            return item;
        }

        [HttpPost]
        public ActionResult<Fund> Post(Fund item)
        {
            // Get /api/v1/funds
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                app.Funds.Add(item);
                app.SaveChanges();
                return CreatedAtAction(nameof(GetByCode),new { code=item.Code,item });
            } catch (Exception ex)
            {
                return BadRequest( new ProblemDetails { Detail= ex.Message} );
            }

            //when success
            //1. return 201
            //2. header
            //   Location: url_to_the_new_resource
            //3. return newly created object
        }

        [HttpPut("{code}")]
        public ActionResult Put(string code, Fund item)
        {
            if (code != item.Code)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // manual
            var fund = app.Funds.Find(code);

            if (fund == null)
            {
                return NotFound();
            }

            fund.Name = item.Name;
            fund.NAV = item.NAV;
            // db.Funds.Update(item);
            app.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{code}")]
        public ActionResult<Fund> Delete(string code)
        {
            var fund = app.Funds.Find(code);
            if (fund == null) return NotFound();
            app.Funds.Remove(fund);
            app.SaveChanges();
            return fund;
        }
    }
}
