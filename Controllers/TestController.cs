using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using efcore5_tpt.Data;
using efcore5_tpt.Entities;

namespace efcore5_tpt.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly MyContext _context;

        public TestController(ILogger<TestController> logger, MyContext ctx)
        {
            _logger = logger;
            _context = ctx;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var lista1 = _context.Clientes.ToList();
            var lsita2 = _context.Diaristas.ToList();
            return Ok(new {
                clientes = lista1,
                diaristas = lsita2
            });
        }

        [HttpPost("cliente")]
        public ActionResult NovoCliente()
        {
            Cliente bean = new Cliente();
            bean.Login = $"login";
            bean.Nome = $"nome";
            bean.NomeContrato = "Nome contrato";
            
            _context.Clientes.Add(bean);
            var res =  _context.SaveChanges();
            
            return Ok(new {
                status = res,
                Cliente = bean
            });
        }

        [HttpPost("diarista")]
        public ActionResult NovaDiarista()
        {
            Diarista bean = new Diarista();
            bean.Login = $"login";
            bean.Nome = $"nome";
            bean.NumeroCartao = $"cartao {Guid.NewGuid()}";

           _context.Diaristas.Add(bean);
            var res =  _context.SaveChanges();

            return Ok(new {
                status = res,
                Cliente = bean
            });
        }
    }
}
