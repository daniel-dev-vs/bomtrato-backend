using Bomtrato.Backend.Data.Entities;
using Bomtrato.Backend.Service.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Bomtrato.Backend.Data.Interfaces;

namespace Bomtrato.Backend.Service.Tests
{
    [TestClass]
    public class ServiceTest
    {
        private IRepository<Processo> _repository;


        public ServiceTest()
        {
            Mock<IRepository<Processo>> mockProcesso = new Mock<IRepository<Processo>>();
            var listaProcessos = RetornarListaProcessos();
            mockProcesso.Setup(x => x.GetAll()).Returns(listaProcessos);
            mockProcesso.Setup(x => x.Add(new Processo()));
            mockProcesso.Setup(x => x.Find(x => x.UsuarioId == 1)).Returns(listaProcessos);
            mockProcesso.Setup(x => x.GetId(1)).Returns(listaProcessos.ToList().OrderBy(x => x.Id).FirstOrDefault());
            mockProcesso.Setup(x => x.Update(new Processo()));
            mockProcesso.Setup(x => x.Save()).Returns(1);
            mockProcesso.Setup(x => x.AddRange(listaProcessos));
            mockProcesso.Setup(x => x.Remove(listaProcessos.ToArray()[0]));
            mockProcesso.Setup(x => x.RemoveRange(listaProcessos));
            mockProcesso.Setup(x => x.SingleOrDefault(x => x.Ativo == true)).Returns(listaProcessos.ToArray()[2]);

            _repository = mockProcesso.Object;
        }


        [TestMethod]
        public void GetAllTest()
        {
            var actual = _repository.GetAll();

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count() > 0);

        }

        [TestMethod]
        public void AddTest()
        {
            _repository.Add(new Processo());
            var actual = _repository.Save();

            Assert.IsTrue(actual > 0);
            
        }

        [TestMethod]
        public void UpdateTest()
        {
            _repository.Update(new Processo());
            var actual = _repository.Save();

            Assert.IsTrue(actual > 0);
        }

        [TestMethod]
        public void AddRangeTest()
        {
            _repository.AddRange(RetornarListaProcessos());
            var actual = _repository.Save();

            Assert.IsTrue(actual > 0);
        }

        [TestMethod]
        public void RemoveTest()
        {
            _repository.Remove(new Processo());
            var actual = _repository.Save();

            Assert.IsTrue(actual > 0);
        }

        [TestMethod]
        public void RemoveRangeTest()
        {
            _repository.RemoveRange(new List<Processo>());
            var actual = _repository.Save();

            Assert.IsTrue(actual > 0);
        }

        [TestMethod]
        public void SingleOrDefaultTest()
        {
            var actual= _repository.SingleOrDefault(x => x.Ativo == true);
           

            Assert.IsTrue(actual.Ativo);
        }



        [TestMethod]
        public void FindTest()
        {

            var actual = _repository.Find(x => x.UsuarioId == 1);

            foreach (var item in actual)
            {
                Assert.AreEqual(1, item.UsuarioId);
            }
            

        }

        [TestMethod]
        public void GetIdTest()
        {

           var actual = _repository.GetId(1);

           Assert.IsNotNull(actual);
           Assert.AreEqual(1, actual.Id);
            


        }

        private ICollection<Processo> RetornarListaProcessos()
        {

            List<Processo> processos = new List<Processo>();
            Processo processo = new Processo() { Id = 1, NumeroProcesso = 123456789123, Escritorio = "São Paulo", Reclamante = "Daniel", Aprovado = true, Ativo = true, UsuarioId =1 };
            Processo processo2 = new Processo() { Id = 2, NumeroProcesso = 123456789124, Escritorio = "Pernambuco", Reclamante = "Josevilto", Aprovado = false, Ativo = true, UsuarioId = 1 };
            Processo processo3 = new Processo() { Id = 3, NumeroProcesso = 123456789125, Escritorio = "Roraima", Reclamante = "Josevaldo", Aprovado = true, Ativo = false, UsuarioId = 1 };
            processos.Add(processo3);
            processos.Add(processo2);
            processos.Add(processo);

            return processos;
        }


    }

}

