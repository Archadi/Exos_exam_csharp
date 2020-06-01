using System;
using ConsoleApp3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            String initiales = ClasseChaine.RetourneInitiales("Toms", "Jackye");
            Assert.IsTrue(initiales == "T.J",  "Attendu: T.J. Reçu: " + initiales);
        }

        [TestMethod]
        public void TestMethodNullOuVide()
        {
            String initiales = ClasseChaine.RetourneInitiales("", "");
            Assert.IsTrue(initiales == "", "Attendu: \"\" Reçu: " + initiales);
        }

    }
}
