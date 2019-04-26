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
    [RoutePrefix("api/jogo")]
    public class JogoController : ApiController
    {
        [HttpPost]
        [Route("cadastrar")]

        public HttpResponseMessage Cadastrar(JogoCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Jogo j = new Jogo();
                    j.Nome = model.Nome;
                    j.Categoria = model.Categoria;
                    j.Classificacao = model.Classificacao;
                    j.DataLancamento = model.DataLancamento;
                    j.IdDesenvolvedora = model.IdDesenvolvedora;
                    j.IdPlataforma = model.IdPlataforma;

                    JogoRepository rep = new JogoRepository();
                    rep.Insert(j);

                    return Request.CreateResponse(HttpStatusCode.OK, "Jogo cadastrado com sucesso");
                }
                catch(Exception e)
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
        public HttpResponseMessage Atualizar(JogoEdicaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Jogo j = new Jogo();
                    j.IdJogo = model.IdJogo;
                    j.Nome = model.Nome;
                    j.Categoria = model.Categoria;
                    j.Classificacao = model.Classificacao;
                    j.DataLancamento = model.DataLancamento;
                    j.IdDesenvolvedora = model.IdDesenvolvedora;
                    j.IdPlataforma = model.IdPlataforma;

                    JogoRepository rep = new JogoRepository();
                    rep.Update(j);

                    return Request.CreateResponse(HttpStatusCode.OK, "Jogo atualizado com sucesso");
                }
                catch(Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro de servidor: " + e.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Ocorreu um ou mais erros de validação nos campos enviados");
            }
        }

        [HttpDelete]
        [Route("excluir")]
        public HttpResponseMessage Excluir(int id)
        {
            try
            {
                JogoRepository rep = new JogoRepository();
                Jogo j = rep.FindById(id);

                if(j != null)
                {
                    rep.Delete(j);

                    return Request.CreateResponse(HttpStatusCode.OK, "Jogo excluído com sucesso.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent, "Jogo não foi localizado.");
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
                List<JogoConsultaViewModel> lista = new List<JogoConsultaViewModel>();
                JogoRepository rep = new JogoRepository();
                foreach( Jogo j in rep.FindAll())
                {
                    JogoConsultaViewModel model = new JogoConsultaViewModel();
                    model.IdJogo = j.IdJogo;
                    model.Nome = j.Nome;
                    model.Categoria = j.Categoria;
                    model.Classificacao = j.Classificacao;
                    model.DataLancamento = j.DataLancamento;
                    model.IdDesenvolvedora = j.IdDesenvolvedora;
                    model.IdPlataforma = j.IdPlataforma;

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
        public HttpResponseMessage ConsultarPorId(int id)
        {
            try
            {                
                JogoRepository rep = new JogoRepository();
                Jogo j = rep.FindById(id);

                if(j != null)
                {
                    JogoConsultaViewModel model = new JogoConsultaViewModel();
                    model.IdJogo = j.IdJogo;
                    model.Nome = j.Nome;
                    model.Categoria = j.Categoria;
                    model.Classificacao = j.Classificacao;
                    model.DataLancamento = j.DataLancamento;
                    model.IdDesenvolvedora = j.IdDesenvolvedora;
                    model.IdPlataforma = j.IdPlataforma;

                    return Request.CreateResponse(HttpStatusCode.OK, model);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Jogo não foi encontrado.");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
