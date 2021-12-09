﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Napista.Data;
using Napista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Napista.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private ApiDbConteudo _dbConteudo;

        public ComprasController(ApiDbConteudo dbConteudo) 
        {
            _dbConteudo = dbConteudo;
        }

        // POST api/<ComprasController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Compras compra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbConteudo.Compras.AddAsync(compra);
            if (compra != null)
            {
                return NotFound("Ocorreu um erro desconhecido");
            }
            await _dbConteudo.SaveChangesAsync();
            return Ok("Compra Cadastrado.");
        }
    }
}