﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using System.Drawing;

namespace Render3D.UnitTest
{
    [TestClass]
    public class GraphicMotorTest
    {
        private GraphicMotor graphicMotorSample;
        private readonly GraphicMotor graphicMotorDefaultSample = new GraphicMotor();
        private const int resolutionHeightSample = 500;
        private const int resolutionHeightSampleDefault = 3;
        private const int negativeResolutionHeightSample = -1;
        private const int zeroResolutionHeightSample = 0;

        private const int pixelSamplingSample = 79;
        private const int pixelSamplingSampleDefault = 50;
        private const int negativePixelSamplingSample = -1;
        private const int zeroPixelSamplingSample = 0;

        private const int maximumDepthSample = 30;
        private const int maximumDepthSampleDefault = 20;
        private const int negativeMaximumDepth = -1;
        private const int zeroMaximumDepth = 0;

        private Scene sceneSample;
        private readonly Bitmap bitmapSample;



        [TestInitialize]
        public void initialize()
        {
            graphicMotorSample = new GraphicMotor();
        }

        [TestMethod]
        public void givenAValidSceneRenderMethodReturnsABitmap()
        {
            sceneSample = new Scene();
            Assert.AreNotEqual(graphicMotorSample.Render(sceneSample), null);
        }

        [TestMethod]
        public void TestTemporaneoRender()
        {
           /*
             graphicMotorSample.ResolutionHeight = 600;
             graphicMotorSample.PixelSampling = 50;
             graphicMotorSample.MaximumDepth = 20;
             Vector3D LookAt = new Vector3D(0, 0.5, -2);
             Vector3D VectorUp = new Vector3D(0, 1, 0);
             Vector3D LookFrom = new Vector3D(4, 2, 8);

             Camera cam = new Camera(LookFrom, LookAt, VectorUp, 40, graphicMotorSample.AspectRatio());


            LambertianMaterial lm = new LambertianMaterial();
             lm.Attenuation = new Vector3D(0.1, 0.2, 0.5);
             Sphere sph = new Sphere(new Vector3D(0, 0.5, -2), 0.5);
             Model md1 = new Model();
             md1.Material = lm;
             md1.Figure = sph;



             LambertianMaterial lm2 = new LambertianMaterial();
             lm2.Attenuation = new Vector3D(0.7, 0.7, 0.1);
             Sphere tierra = new Sphere(new Vector3D(0, -2000, -1), 2000);
             Model laTIerra = new Model();
             laTIerra.Material = lm2;
             laTIerra.Figure = tierra;

             LambertianMaterial lm3 = new LambertianMaterial();
             lm3.Attenuation = new Vector3D(0.8, 0.2, 0.5);
             Sphere sph2 = new Sphere(new Vector3D(-1, 0.5, -2), 0.5);
             Model md2 = new Model();
             md2.Material = lm3;
             md2.Figure = sph2;

             LambertianMaterial lm4 = new LambertianMaterial();
             lm4.Attenuation = new Vector3D(0.8, 0.25, 0.5);
             Sphere sph3 = new Sphere(new Vector3D(-1, 2, -10), 2);
             Model md3 = new Model();
             md3.Material = lm4;
             md3.Figure = sph3;


             Scene scene = new Scene();
             scene.Camera = cam;
             scene.PositionedModels.Add(md1);
             scene.PositionedModels.Add(laTIerra);
             scene.PositionedModels.Add(md2);
             scene.PositionedModels.Add(md3);



             Assert.AreNotEqual(graphicMotorSample.Render(scene), null);

            */

        }




        [TestMethod]
        public void givenAdefaultGraphicMotorItComparesTheDefaultPixelSampling()
        {
            Assert.AreEqual(graphicMotorDefaultSample.PixelSampling, pixelSamplingSampleDefault);
        }

        [TestMethod]
        public void givenAdefaultGraphicMotorItComparesTheDefaultMaximumDepth()
        {
            Assert.AreEqual(graphicMotorDefaultSample.MaximumDepth, maximumDepthSampleDefault);
        }

        [TestMethod]
        public void givenAdefaultGraphicMotorItComparesTheDefaultResolution()
        {
            Assert.AreEqual(graphicMotorDefaultSample.ResolutionHeight, resolutionHeightSampleDefault);
        }

        [TestMethod]
        public void givenAValidResolutionItAssignsItToTheGraphicMotor()
        {
            graphicMotorSample.ResolutionHeight = resolutionHeightSample;
            Assert.AreEqual(resolutionHeightSample, graphicMotorSample.ResolutionHeight);
        }

        [TestMethod]
        public void givenAValidPixelSamplingItAssignsItToTheGraphicMotor()
        {
            graphicMotorSample.PixelSampling = pixelSamplingSample;
            Assert.AreEqual(pixelSamplingSample, graphicMotorSample.PixelSampling);
        }

        [TestMethod]
        public void givenAValidMaximumDepthItAssignsItToTheGraphicMotor()
        {
            graphicMotorSample.MaximumDepth = maximumDepthSample;
            Assert.AreEqual(maximumDepthSample, graphicMotorSample.MaximumDepth);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The maximum depth must be greater than 0.")]
        public void givenANegativeMaximumDepthItThrowsABackEndException()
        {
            graphicMotorSample.MaximumDepth = negativeMaximumDepth;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The maximum depth must be greater than 0.")]
        public void givenAZeroMaximumDepthItThrowsABackEndException()
        {
            graphicMotorSample.MaximumDepth = zeroMaximumDepth;
        }


        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The pixel sampling must be greater than 0.")]
        public void givenANegativePixelSamplingItThrowsABackEndException()
        {
            graphicMotorSample.PixelSampling = negativePixelSamplingSample;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The pixel sampling must be greater than 0.")]
        public void givenAZeroPixelSamplingItThrowsABackEndException()
        {
            graphicMotorSample.PixelSampling = zeroPixelSamplingSample;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The resolution must be greater than 0.")]
        public void givenANegativeResolutionItThrowsABackEndException()
        {
            graphicMotorSample.ResolutionHeight = negativeResolutionHeightSample;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The resolution must be greater than 0.")]
        public void givenAZeroResolutionItThrowsABackEndException()
        {
            graphicMotorSample.ResolutionHeight = zeroResolutionHeightSample;
        }

    }
}
