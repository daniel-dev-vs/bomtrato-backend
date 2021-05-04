using Bomtrato.Backend.Data.Entities;
using Bomtrato.Backend.Service.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Bomtrato.Backend.ServiceTest
{
    [TestClass]
    public class ProcessoServiceTest
    {

        private IProcessoService _service;

       

        public ProcessoServiceTest() 
        {
            Mock<IProcessoService> mockProcesso = new Mock<IProcessoService>();
            var naoAprovados = RetornarListaAprovadosOuNaoAprovados(false);
            var aprovados = RetornarListaAprovadosOuNaoAprovados(true);
            var processo = RetornarListaAprovadosOuNaoAprovados(true);

            mockProcesso.Setup(x => x.GetNaoAprovados()).Returns(naoAprovados);
            mockProcesso.Setup(x => x.GetPorUsuario(1)).Returns(processo);
            mockProcesso.Setup(x => x.GetAprovados()).Returns(aprovados);


            _service = mockProcesso.Object;
        }

        [TestMethod]
        public void GetNaoAprovadoTest()
        {                                          

            var actual = _service.GetNaoAprovados();

            foreach (var item in actual)
            {
                Assert.IsFalse(item.Aprovado);
            }

        }


        [TestMethod]
        public void GetPorUsuarioTest()
        {   
           
            var actual = _service.GetPorUsuario(1).ToArray();

            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(1,actual[i].UsuarioId);
            }
               
            

           

        }

        [TestMethod]
        public void GetAprovadoTest()
        {           
            var actual = _service.GetAprovados();

            foreach (var item in actual)
            {
                Assert.IsTrue(item.Aprovado);
            }

        }

        private ICollection<Processo> RetornarListaAprovadosOuNaoAprovados(bool aprovado)
        {

            List<Processo> processos = new List<Processo>();
            Processo processo = new Processo() {Id =1, NumeroProcesso = 123456789123, Escritorio = "São Paulo",Reclamante = "Daniel",Aprovado = aprovado, Ativo = true, UsuarioId =1 };
            Processo processo2 = new Processo() { Id = 2, NumeroProcesso = 123456789124, Escritorio = "Pernambuco", Reclamante = "Josevilto", Aprovado = aprovado, Ativo = true, UsuarioId = 1 };
            Processo processo3 = new Processo() { Id = 3, NumeroProcesso = 123456789125, Escritorio = "Roraima", Reclamante = "Josevaldo", Aprovado = aprovado, Ativo = true, UsuarioId = 1 };
            processos.Add(processo3);
            processos.Add(processo2);
            processos.Add(processo);

            return processos;
        }
    }
}
