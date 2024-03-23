using Microsoft.VisualStudio.TestTools.UnitTesting;
using DLLDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArgsManagerLib;

namespace DLLDriver.Tests
{
    [TestClass()]
    public class ArgsManagerLibTests
    {
        [TestMethod()]
        public void ArgsManagerLibTest()
        {
            string[] keys = new string[] { "-aaa", "-bbb", "-ccc" };
            string[] args = new string[] { "-aaa", "0", "-bbb", "1", "-ccc", "2" };
            ArgsManager test = new ArgsManager(keys, args);

            if (test.Length != args.Length)
            {
                Assert.Fail();
            }

            if (test.KeyLength != keys.Length)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void GetValueTest()
        {
            string[] keys = new string[] { "-aaa", "-bbb", "-ccc" };
            string[] args = new string[] { "-aaa", "0", "-bbb", "1", "-ccc", "2", "3", "4" };
            ArgsManager test = new ArgsManager(keys, args);

            foreach (var arg in args)
            {
                // キーが存在するかの確認
                var iskey = (from x in keys
                             where x == arg
                             select x).Any();

                // 値の取得
                string ans = test.GetValue(arg);

                // キーが存在し値が入っているか、キーが存在せず値が入っていないケースを成功とする
                if (iskey && !string.IsNullOrEmpty(ans))
                {
                    ;
                }
                else if (iskey == false && string.IsNullOrEmpty(ans))
                {
                }
                else
                {
                    Assert.Fail();
                }
            }

        }
    }
}