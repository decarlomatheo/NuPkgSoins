using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassesMetier;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesMetier.Tests
{
    [TestClass()]
    public class PrestationTests
    {
        [TestMethod()]
        public void PrestationTest()
        {
            //throw new NotImplementedException();
        }

         [TestMethod()]
        public void ToStringTest()
        {
            //throw new NotImplementedException();
        }

        [TestMethod()]
        public void SommePourRienTest()
        {
            int a = 3;
            int b = 5;
            Prestation unePrestation = new Prestation("XX", new DateTime(2015, 9, 10, 12, 0, 0), new Intervenant("Dupont", "Jean"));
            Assert.AreEqual(8, unePrestation.SommePourRien(a, b), "La somme doit être égale à 8");

        }

        [TestMethod()]
        public void HeureSoinTest()
        {
            //throw new NotImplementedException();
        }

        // 2 dates identiques avec des heures différentes. Résultat attendu : 0
        [TestMethod()]
        public void compareToMemesDatesHeureDifférentesTest()
        {
            Prestation p1 = new Prestation("Libelle P1", new DateTime(2015, 9, 10, 12, 30, 0), new Intervenant("Dupont", "Jean"));
            Prestation p2 = new Prestation("Libelle P2", new DateTime(2015, 9, 10, 18, 45, 0), new Intervenant("Durand", "Annie"));
            Assert.AreEqual(0, p1.CompareTo(p2), "Résultat attendu 0");
        }

        // 2 dates identiques avec des heures identiques. 
        // la date de soins de P1 est inférieure à celle de p2
        // Résultat attendu : -1
        [TestMethod()]
        public void compareToDatesDifferentesHeureIdentiquesTest()
        {
            Prestation p1 = new Prestation("Libelle P1", new DateTime(2012, 9, 10, 12, 30, 0), new Intervenant("Dupont", "Jean"));
            Prestation p2 = new Prestation("Libelle P2", new DateTime(2015, 6, 10, 18, 45, 0), new Intervenant("Durand", "Annie"));
            Assert.AreEqual(-1, p1.CompareTo(p2), "Résultat attendu -1");
        }

        // 2 dates identiques avec des heures identiques. 
        // la date de soins de P1 est supérieure à celle de p2
        // Résultat attendu : 1
        [TestMethod()]
        public void compareToDatesDifferentesHeureDifférentesTest()
        {
            Prestation p1 = new Prestation("Libelle P1", new DateTime(2015, 9, 10, 12, 30, 0), new Intervenant("Dupont", "Jean"));
            Prestation p2 = new Prestation("Libelle P2", new DateTime(2012, 12, 10, 12, 30, 0), new Intervenant("Durand", "Annie"));
            Assert.AreEqual(1, p1.CompareTo(p2), "Résultat attendu 1");
        }

    }
}