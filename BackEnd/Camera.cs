﻿using Render3D.BackEnd.GraphicMotorUtility;
using System;

namespace Render3D.BackEnd
{
    public class Camera
    {
        private double _theta;
        private int _fov;
        private const int _minFov = 0;
        private const int _maxFov = 160;

        private const double degreesToRadians = Math.PI / 180;
        public Vector3D LookFrom { get; set; }
        public Vector3D LookAt { get; set; }

        public Vector3D VectorW { get; set; }

        public Vector3D VectorU { get; set; }

        public Vector3D VectorV { get; set; }

        public double HeightHalf { get; set; }

        public double AspectRatio { get; set; }

        public double WidthHalf { get; set; }




        public double Theta
        {
            get => _theta;
            set
            {
                _theta = value;
                HeightHalf = Math.Tan(Theta / 2);
            }

        }

        public Vector3D VectorUp { get; set; }

        public Vector3D Corner_lowerLeft { get; set; }

        public Vector3D Horizontal { get; set; }
        public Vector3D Vertical { get; set; }

        public Camera()
        {
            LookAt = new Vector3D(0, 2, 5);
            VectorUp = new Vector3D(0, 1, 0);
            Fov = 30;
            _theta = Fov * Math.PI / 180;
            HeightHalf = Math.Tan(Theta / 2);
            AspectRatio = 16.0 / 9.0;
            WidthHalf = AspectRatio * HeightHalf;
            LookFrom = new Vector3D(0, 2, 0);
            VectorW = LookFrom.Substract(LookAt).GetUnit();
            VectorU = VectorUp.CrossProduct(VectorW).GetUnit();
            VectorV = VectorW.CrossProduct(VectorU);
            Corner_lowerLeft = LookFrom.Substract(VectorU.Multiply(WidthHalf)).Substract(VectorV.Multiply(HeightHalf)).Substract(VectorW);
            Horizontal = VectorU.Multiply(WidthHalf * 2);
            Vertical = VectorV.Multiply(HeightHalf * 2);
        }

        public Camera(Vector3D vectorLookFrom, Vector3D vectorLookAt, Vector3D vectorUp, int fieldOfView, double aspectRatio)
        {
            LookAt = vectorLookAt;
            VectorUp = vectorUp;
            Fov = fieldOfView;
            AspectRatio = aspectRatio;
            Theta = fieldOfView * Math.PI / 180;
            HeightHalf = Math.Tan(Theta / 2);
            WidthHalf = AspectRatio * HeightHalf;
            LookFrom = vectorLookFrom;
            VectorW = vectorLookFrom.Substract(vectorLookAt).GetUnit();
            VectorU = vectorUp.CrossProduct(VectorW).GetUnit();
            VectorV = VectorW.CrossProduct(VectorU);
            Corner_lowerLeft = LookFrom.Substract(VectorU.Multiply(WidthHalf)).Substract(VectorV.Multiply(HeightHalf)).Substract(VectorW);
            Horizontal = VectorU.Multiply((2 * WidthHalf));
            Vertical = VectorV.Multiply((2 * HeightHalf));
        }
        public int Fov
        {
            get => _fov;

            set
            {
                ValidateName(value);
                _fov = value;
                _theta = Fov * degreesToRadians;
            }
        }

        private void ValidateName(int value)
        {
            if (!HelperValidator.IsANumberInRange(value, _minFov, _maxFov))
            {
                throw new BackEndException($"FoV must be between {_minFov} and {_maxFov}");
            }
        }

        public bool Equals(Camera other)
        {
            return this.Fov == other.Fov && this.LookFrom.Equals(other.LookFrom) && this.LookAt.Equals(other.LookAt);
        }

        public Ray GetRay(double u, double v)
        {
            Vector3D horizontalPosition = Horizontal.Multiply(u);
            Vector3D verticalPosition = Vertical.Multiply(v);
            return new Ray(LookFrom, Corner_lowerLeft.Add(horizontalPosition.Add(verticalPosition)).Substract(LookFrom));
        }

    }
}
