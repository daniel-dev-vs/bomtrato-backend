using Bomtrato.Backend.Data;
using Bomtrato.Backend.Data.Interfaces;
using Bomtrato.Backend.Data.Repositories;
using Bomtrato.Backend.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Moq;
using System.Collections.Generic;

namespace Bomtrato.Backend.Data.Tests
{
    [TestClass]
    public class ProcessoRepositoryTest
    {
        BomtratoContext BomtratoContexto;

       
        private IProcessoRepository processoRepository;

        public ProcessoRepositoryTest() 
        {
           
        }

        [TestMethod]
        public void GetAprovadosTest()
        {
            IEnumerable<Processo> processos;
            using (BomtratoContext contexto = new BomtratoContext()) 
            {
                this.processoRepository = new ProcessoRepository(contexto);
                processos = processoRepository.GetProcessosAprovados();

            }


            foreach (var item in processos)
            {
                Assert.IsTrue(item.Aprovado);
            }
            Assert.IsNotNull(processos);
        }





        [TestMethod]
        public void GetProcessosPorUsuarioTest()
        {

            IEnumerable<Processo> processos;
            using (BomtratoContext contexto = new BomtratoContext())
            {


                this.processoRepository = new ProcessoRepository(contexto);

                processos = processoRepository.GetProcessosPorUsuario(1);

            }

            Assert.IsNotNull(processos);

            foreach (var item in processos)
            {
                Assert.AreEqual(item.Id, 1);
            }



        }

        [TestMethod]
        public void GetProcessosNaoAprovadosTest()
        {

            IEnumerable<Processo> processos;
            using (BomtratoContext contexto = new BomtratoContext())
            {


                this.processoRepository = new ProcessoRepository(contexto);

                processos = processoRepository.GetProcessosNaoAprovados();

            }


            foreach (var item in processos)
            {
                Assert.IsFalse(item.Aprovado);
            }

            Assert.IsNotNull(processos);
        }


     
    }
}
