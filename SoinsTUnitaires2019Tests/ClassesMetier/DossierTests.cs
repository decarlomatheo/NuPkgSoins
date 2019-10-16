using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassesMetier;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesMetier.Tests
{
    [TestClass()]
    public class DossierTests
    {
        [TestMethod()]
        public void DossierTest()
        {
            // cette méthode sera testée implicitement lors de l'instanciation d'un dossir dans une autre méthode 
        }

        [TestMethod()]
        // Cette méthode va tester si le nombre de jours de soins est égal à 0 si ledossier n'a pas
        // de prestation. Elle permet de gérer le cas 
        public void getNbJoursSoinsV2SansPrestationTest()
        {
            Dossier unDossier = new Dossier("Robert", "Jean", new DateTime(1980, 12, 3));
            Assert.AreEqual(0, unDossier.GetNbJoursSoins(), "Le nombre de jours de soins doit être égal à 0");
        }

        [TestMethod()]
        public void getNbJoursSoinsV2AvecPrestationTest()
        {
            Dossier unDossier = new Dossier("Robert", "Jean", new DateTime(1980, 12, 3));
            unDossier.AjoutePrestation("Libelle P3", new DateTime(2015, 9, 10, 12, 0, 0), new Intervenant("Dupont", "Jean"));
            unDossier.AjoutePrestation("Libelle P1", new DateTime(2015, 9, 1, 12, 0, 0), new IntervenantExterne("Durand", "Annie", "Cardiologue", "Marseille", "0202020202"));

            Assert.AreEqual(2, unDossier.GetNbJoursSoins(), "Le nombre de jours de soins doit être égal à 2");
        }


        [TestMethod()]
        public void getNbPrestationsExternesTest()
        {
            Dossier unDossier = InitialiseDossier();
            Assert.AreEqual(2, unDossier.GetNbPrestationsExternes());

        }

        private Dossier InitialiseDossier()
        {
            Dossier unDossier = new Dossier("Robert", "Jean", new DateTime(1980, 12, 3));
            unDossier.AjoutePrestation("Libelle P3", new DateTime(2015, 9, 10, 12, 0, 0), new Intervenant("Dupont", "Jean"));
            unDossier.AjoutePrestation("Libelle P1", new DateTime(2015, 9, 1, 12, 0, 0), new IntervenantExterne("Durand", "Annie", "Cardiologue", "Marseille", "0202020202"));
            unDossier.AjoutePrestation("Libelle P2", new DateTime(2015, 9, 8, 12, 0, 0), new IntervenantExterne("Sainz", "Olivier", "Radiologue", "Toulon", "0303030303"));
            unDossier.AjoutePrestation("Libelle P4", new DateTime(2015, 9, 20, 12, 0, 0), new Intervenant("Maurin", "Joëlle"));
            unDossier.AjoutePrestation("Libelle P6", new DateTime(2015, 9, 8, 9, 0, 0), new Intervenant("Blanchard", "Michel"));
            unDossier.AjoutePrestation("Libelle P5", new DateTime(2015, 9, 10, 6, 0, 0), new Intervenant("Tournier", "Hélène"));

            return unDossier;
        }

        [TestMethod()]
        public void ToStringTest()
        {
            //throw new NotImplementedException();
        }
    }
}