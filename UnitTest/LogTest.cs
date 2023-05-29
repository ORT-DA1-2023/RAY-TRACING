﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd;
using System;
using System.Collections.Generic;
using Render3D.BackEnd.Utilities;

namespace Render3D.UnitTest
{
    [TestClass]
    public class LogTest
    {
        private Scene sceneSample;
        private readonly string sceneSampleName = "sceneSampleName";
        private readonly Client clientSample = new Client() { Name = "Joe", Password = "S4fePassword" };
        private readonly List<Model> positionedModels = new List<Model>();
        private Model modelSample;
        private Material materialSample;

        [TestInitialize]
        public void Initialize()
        {
            sceneSample = new Scene() { Name = sceneSampleName };

            Vector3D origin = new Vector3D(0, 0, 0);
            Vector3D direction = new Vector3D(1, 1, 1);
            materialSample = new LambertianMaterial();
            Figure figure = new Sphere();
            modelSample = new Model();
        }


   
        [TestMethod]
        public void GivenValidSceneAssignsTheScene()
        {
            Log l = new Log(sceneSample,DateTimeProvider.Now);
            Assert.AreEqual(sceneSample, l.Scene);
        }

        [TestMethod]
        public void GivenValidPreviewAssignsTheScene()
        {
            Log l = new Log(sceneSample);
            Assert.AreEqual(sceneSample, l.Scene);
        }

        [TestMethod]
        public void GivenValidSceneAssignsTheClient()
        {
            Log l = new Log(sceneSample, DateTimeProvider.Now);
            Assert.AreEqual(sceneSample.Client, l.Client);
        }

        [TestMethod]
        public void GivenValidPreviewAssignsTheClient()
        {
            Log l = new Log(sceneSample);
            Assert.AreEqual(sceneSample.Client, l.Client);
        }



    }
}
