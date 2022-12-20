using Microsoft.VisualStudio.TestTools.UnitTesting;
using SysTaimsal.DAL;
using SysTaimsal.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysTaimsal.DAL.Tests
{
    [TestClass()]
    public class MachineDALTests
    {
        private static Machine MachineInitial = new Machine { IdMachine = 1, NameMachine = "MachineMachine", ImageMachine = "../wwwroot/img/Product/" };
        [TestMethod()]
        public async Task T1CreateAsyncTest()
        {
            var machine = new Machine();
            machine.IdMachine = MachineInitial.IdMachine;
            machine.NameMachine = MachineInitial.NameMachine;
            machine.ImageMachine = MachineInitial.ImageMachine;
            int result = await MachineDAL.CreateAsync(machine);
            Assert.AreEqual(0, result);
        }

        [TestMethod()]
        public async Task T2ModifyAsyncTest()
        {
            var machine = new Machine();
            machine.NameMachine = "MachineMachineMod-213";
            int result = await MachineDAL.ModifyAsync(machine);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3GetByIdAsyncTest()
        {
            var machine = new Machine();
            machine.IdMachine = MachineInitial.IdMachine;
            var result = await MachineDAL.GetByIdAsync(machine);
            Assert.AreEqual(machine.IdMachine, result.IdMachine);
        }

        [TestMethod()]
        public async Task T4GetAllAsyncTest()
        {
            var result = await MachineDAL.GetAllAsync();
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async Task T5SearchAsyncTest()
        {
            var machine = new Machine();
            machine.IdMachine = MachineInitial.IdMachine;
            var result = await MachineDAL.SearchAsync(machine);
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async Task T6DeleteAsyncTest()
        {
            var machine = new Machine();
            machine.IdMachine = MachineInitial.IdMachine;
            int result = await MachineDAL.DeleteAsync(machine);
            Assert.AreNotEqual(0, result);
        }
    }
}