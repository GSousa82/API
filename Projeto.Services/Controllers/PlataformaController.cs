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
    [RoutePrefix("api/plataforma")]
    public class PlataformaController : ApiController
    {
        [HttpPost]
        [Route("cadastrar")]

        public HttpResponseMessage Cadastrar(PlataformaCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Plataforma p = new Plataforma();
                    p.Nome = model.Nome;
                    p.Modelo = model.Modelo;


                    PlataformaRepository rep = new PlataformaRepository();
                    rep.Insert(p);

                    return Request.CreateResponse(HttpStatusCode.OK, "Plataforma cadastrada com sucesso");
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
        public HttpResponseMessage Atualizar(PlataformaEdicaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Plataforma p = new Plataforma();
                    p.IdPlataforma = model.IdPlataforma;
                    p.Nome = model.Nome;
                    p.Modelo = model.Modelo;

                    PlataformaRepository rep = new PlataformaRepository();
                    rep.Update(p);

                    return Request.CreateResponse(HttpStatusCode.OK, "Plataforma atualizada com sucesso.");
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro de servidor: " + e.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Ocorreu um ou mais erros de validação nos campos enviados.");
            }
            
        }

        [HttpDelete]
        [Route("delete")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                PlataformaRepository rep = new PlataformaRepository();
                Plataforma p = rep.FindById(id);

                if(p != null)
                {
                    rep.Delete(p);

                    return Request.CreateResponse(HttpStatusCode.OK, "Plataforma excluída com sucesso.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Plataforma não localizada.");
                }
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro de servidor: " + e.Message);
            }
        }

        [HttpGet]
        [Route("consultar")]
        public HttpResponseMessage Consultar()
        {
            try
            {
                List<PlataformaConsultaViewModel> lista = new List<PlataformaConsultaViewModel>();
                PlataformaRepository rep = new PlataformaRepository();

                foreach (Plataforma p in rep.FindAll())
                {
                    PlataformaConsultaViewModel model = new PlataformaConsultaViewModel();
                    model.IdPlataforma = p.IdPlataforma;
                    model.Nome = p.Nome;
                    model.Modelo = p.Modelo;

                    lista.Add(model);
                }

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro de servidor: " + e.Message);
            }
        }

        [HttpGet]
        [Route("consultarporid")]
        public HttpResponseMessage ConsultarPorId(int id)
        {
            try
            {
                PlataformaRepository rep = new PlataformaRepository();
                Plataforma p = rep.FindById(id);

                if(p != null)
                {
                    PlataformaConsultaViewModel model = new PlataformaConsultaViewModel();

                    model.IdPlataforma = p.IdPlataforma;
                    model.Nome = p.Nome;
                    model.Modelo = p.Modelo;

                    return Request.CreateResponse(HttpStatusCode.OK, model);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Plataforma não localizada.");
                }
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro de servidor: " + e.Message);
            }
        }
    }
}
