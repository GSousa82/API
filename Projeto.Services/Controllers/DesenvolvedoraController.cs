using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Projeto.Entities;
using Projeto.Repositories.Persistence;
using Projeto.Services.Models;

namespace Projeto.Services.Controllers
{
    [RoutePrefix("api/desenvolvedora")]
    public class DesenvolvedoraController : ApiController
    {
        [HttpPost]
        [Route("cadastrar")]

        public HttpResponseMessage Cadastrar(DesenvolvedoraCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Desenvolvedora d = new Desenvolvedora();
                    d.Nome = model.Nome;
                    d.CNPJ = model.CNPJ.ToString();

                    DesenvolvedoraRepository rep = new DesenvolvedoraRepository();
                    rep.Insert(d);

                    return Request.CreateResponse(HttpStatusCode.OK, "Desenvolvedora cadastrada com sucesso");
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro de servidor: " + e.Message);

                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Ocorreu um ou mais erros de validação nos campos enviados");
            }
        }

        [HttpPut]
        [Route("atualizar")]
        public HttpResponseMessage Atualizar(DesenvolvedoraEdicaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Desenvolvedora d = new Desenvolvedora();
                    d.IdDesenvolvedora = model.IdDesenvolvedora;
                    d.Nome = model.Nome;
                    d.CNPJ = model.CNPJ.ToString();

                    DesenvolvedoraRepository rep = new DesenvolvedoraRepository();
                    rep.Update(d);

                    return Request.CreateResponse(HttpStatusCode.OK, "Desenvolvedora atualizada com sucesso.");
                }
                catch(Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro de servidor: " + e.Message);
                }             
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Ocorreram erros de validação nos campos enviados.");
            }
        }

        [HttpDelete]
        [Route("delete")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                DesenvolvedoraRepository rep = new DesenvolvedoraRepository();
                Desenvolvedora d = rep.FindById(id);

                if(d != null)
                {
                    rep.Delete(d);

                    return Request.CreateResponse(HttpStatusCode.OK, "Desevolvedora excluída com sucesso");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Desenvolvedora não localizada");
                }
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("consultar")]
        public HttpResponseMessage Consultar()
        {
            try
            {
                List<DesenvolvedoraConsultaViewModel> lista = new List<DesenvolvedoraConsultaViewModel>();
                DesenvolvedoraRepository rep = new DesenvolvedoraRepository();
                foreach(Desenvolvedora d in rep.FindAll())
                {
                    DesenvolvedoraConsultaViewModel model = new DesenvolvedoraConsultaViewModel();
                    model.IdDesenvolvedora = d.IdDesenvolvedora;
                    model.Nome = d.Nome;
                    model.CNPJ = Convert.ToInt32(d.CNPJ);

                    lista.Add(model);
                }

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("consultarporid")]
        public HttpResponseMessage ConsularPorId(int id)
        {
            try
            {
                DesenvolvedoraRepository rep = new DesenvolvedoraRepository();
                Desenvolvedora d = rep.FindById(id);
                if(d != null)
                {
                    DesenvolvedoraConsultaViewModel model = new DesenvolvedoraConsultaViewModel();
                    model.IdDesenvolvedora = d.IdDesenvolvedora;
                    model.Nome = d.Nome;
                    model.CNPJ = Convert.ToInt32(d.CNPJ);

                    return Request.CreateResponse(HttpStatusCode.OK, model);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Desenvolvedora não localizada");
                }
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
