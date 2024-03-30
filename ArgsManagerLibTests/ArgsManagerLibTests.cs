using Microsoft.VisualStudio.TestTools.UnitTesting;
using DLLDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArgsManagerLib;
using System.Diagnostics;

namespace DLLDriver.Tests
{
    [TestClass()]
    public class ArgsManagerLibTests
    {
        [TestMethod()]
        public void ArgsManagerLibTest()
        {
            string[] keys = new string[] { "-p1", "-p2", "-p3", "-p4", "-p5" };
            string[] args = new string[] { "-p1", "0", "-p2", "1", "-p3", "-p4" };
            ArgsManager test = new ArgsManager(keys, args);


            if (!test["-p1"].Equals("0")) Assert.Fail();
            if (!test["-p2"].Equals("1")) Assert.Fail();
            if (!test["-p3"].Equals("true")) Assert.Fail();
            if (!test["-p4"].Equals("true")) Assert.Fail();
            if (!test["-p5"].Equals("false")) Assert.Fail();
        }
    }
}