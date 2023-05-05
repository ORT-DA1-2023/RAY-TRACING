﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd.Controllers;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd;
using System;
using System.Collections.Generic;
using System.Text;
using Render3D.BackEnd.Figures;

namespace Render3D.UnitTest.ControllersTests
{
    /// <summary>
    /// Summary description for ModelControllerTest
    /// </summary>
    [TestClass]
    public class ModelControllerTest
    {
        private DataWarehouse _dataWarehouse;

        private ClientController _clientController;
        private Client _clientSample;
        private Material _materialSample;
        private Figure _figure;
        private ModelController _modelController;
        private Model _modelSample;
        private Vector3D _color = new Vector3D(0, 0, 0);

        [TestInitialize]
        public void initialize()
        {
            _dataWarehouse = new DataWarehouse();
            _clientController = new ClientController() { DataWarehouse = _dataWarehouse };
            _clientSample = new Client() { Name = "clientSample1", Password = "PasswordSample1" };
            _materialSample = new LambertianMaterial() { Client = _clientSample, Name = "materialSample1", Color = _color };
            _figure = new Sphere() { Client = _clientSample, Name = "figureSample1", Radius = 5 };
            _modelController = new ModelController() { ClientController = _clientController, DataWarehouse = _dataWarehouse };
            _modelSample = new Model() { Client = _clientSample, Name = "modelSample1", Figure = _figure, Material = _materialSample };
        }
        [TestMethod]
        public void GivenANewMaterialAddsItToTheList()
        {
            _clientController.TryToSignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue(_modelController.DataWarehouse.Models.Count == 0);
            _modelController.AddAModelWithoutPreview("clientSample1", "modelSample1", _figure,_materialSample);
            Assert.IsTrue(_modelController.DataWarehouse.Models.Count == 1);
        }
        [TestMethod]
        public void GivenANewWrongMaterialFailsAddingItToTheList()
        {
            _clientController.TryToSignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue(_modelController.DataWarehouse.Models.Count == 0);
            _modelController.AddAModelWithoutPreview("clientSample1", "", _figure, _materialSample);
            Assert.IsTrue(_modelController.DataWarehouse.Models.Count == 0);
        }
        [TestMethod]
        public void GivenARepeatedMaterialFailsAddingItToTheList()
        {
            _clientController.TryToSignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue(_modelController.DataWarehouse.Models.Count == 0);
            _modelController.AddAModelWithoutPreview("clientSample1", "modelSample1", _figure, _materialSample);
            _modelController.AddAModelWithoutPreview("clientSample1", "modelSample1", _figure, _materialSample);
            Assert.IsTrue(_modelController.DataWarehouse.Models.Count == 1);
        }
        [TestMethod]
        public void givenANewMaterialNameItChanges()
        {
            _clientController.TryToSignIn("clientSample1", "PasswordExample1");
            _modelController.AddAModelWithoutPreview("clientSample1", "modelSample1", _figure, _materialSample);
            _modelController.ChangeModelName("clientSample1", "modelSample1", "modelSample2");
            Assert.IsTrue(_modelController.DataWarehouse.Models[0].Name == "modelSample2");

        }
        [TestMethod]
        public void givenANewMaterialNameItDoesNotChange()
        {
            _clientController.TryToSignIn("clientSample1", "PasswordExample1");
            _modelController.AddAModelWithoutPreview("clientSample1", "modelSample1", _figure, _materialSample);
            _modelController.AddAModelWithoutPreview("clientSample1", "modelSample2", _figure, _materialSample);
            _modelController.ChangeModelName("clientSample1", "modelSample1", "modelSample2");
            Assert.IsTrue(_modelController.DataWarehouse.Models[0].Name == "modelSample1");
            Assert.IsTrue(_modelController.DataWarehouse.Models[1].Name == "modelSample2");
        }
        [TestMethod]
        public void GivenANameDeletesTheMaterial()
        {
            _clientController.TryToSignIn("clientSample1", "PasswordExample1");
            _modelController.AddAModelWithoutPreview("clientSample1", "modelSample1", _figure, _materialSample);
            Assert.IsTrue(_modelController.DataWarehouse.Models.Count == 1);
            _modelController.deleteModelInList("clientSample1", "modelSample1");
            Assert.IsTrue(_modelController.DataWarehouse.Models.Count == 0);
        }
        [TestMethod]
        public void GivenANameDoesNotDeleteTheMaterial()
        {
            _clientController.TryToSignIn("clientSample1", "PasswordExample1");
            _modelController.AddAModelWithoutPreview("clientSample1", "modelSample1", _figure, _materialSample);
            Assert.IsTrue(_modelController.DataWarehouse.Models.Count == 1);
            _modelController.deleteModelInList("clientSample1", "modelSample2");
            Assert.IsTrue(_modelController.DataWarehouse.Models.Count == 1);
        }
    }
}

