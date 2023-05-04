﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.GraphicMotorUtility;
using System;

namespace Render3D.UnitTest
{
    [TestClass]
    public class HitRecordTest
    {
        private HitRecord3D hitRecordSample;
        private double moduleSample;
        private Vector3D intersectionSample;
        private Vector3D normalSample;
        private Vector3D attenuationSample;

        [TestInitialize]
        public void initialize()
        {
            hitRecordSample = new HitRecord3D();
        }

        [TestMethod]
        public void givenValidAtributesItAssingsToTheHitRecord()
        {
            moduleSample = 1;
            intersectionSample = new Vector3D(0, 0, 0);
            normalSample = new Vector3D(0, 0, 0);
            hitRecordSample = new HitRecord3D(moduleSample, intersectionSample, normalSample, attenuationSample);
            Assert.AreEqual(moduleSample, hitRecordSample.Module);
            Assert.AreEqual(intersectionSample, hitRecordSample.Intersection);
            Assert.AreEqual(normalSample, hitRecordSample.Normal);
            Assert.AreEqual(attenuationSample, hitRecordSample.Attenuation);
        }

        

        [TestMethod]
        public void givenAValidAttenuationItAssingsToTheHitRecord()
        {
            attenuationSample = new Vector3D(7, 234, 34);
            hitRecordSample.Attenuation = attenuationSample;
            Assert.AreEqual(attenuationSample, hitRecordSample.Attenuation);
        }


        [TestMethod]
        public void givenAValidModuleItAssingsToTheHitRecord()
        {
            moduleSample = 1;
            hitRecordSample.Module = moduleSample;
            Assert.AreEqual(moduleSample, hitRecordSample.Module);
        }

        [TestMethod]
        public void givenAValidIntersectionItAssingsToTheHitRecord()
        {
            intersectionSample = new Vector3D(0, 0, 0);
            hitRecordSample.Intersection = intersectionSample;
            Assert.AreEqual(intersectionSample, hitRecordSample.Intersection);
        }

        [TestMethod]
        public void givenAValidNormalItAssingsToTheHitRecord()
        {
            normalSample = new Vector3D(0, 0, 0);
            hitRecordSample.Normal = normalSample;
            Assert.AreEqual(normalSample, hitRecordSample.Normal);
        }
    }
}