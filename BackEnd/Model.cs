﻿using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Materials;
using System.Drawing;
using Render3D.BackEnd.Utilities;


namespace Render3D.BackEnd
{
    public class Model
    {
        private string _name;
        private Figure _figure;
        private Client _client;
        private Material _material;
        private Bitmap _preview;

        public Client Client { get => _client; set => _client = value; }

        public string Name
        {
            get => _name;
            set
            {
                ValidateName(value);
                _name = value;
            }
        }

        public Figure Figure { get => _figure; set => _figure = value; }

        public Bitmap Preview
        {
            get => _preview;
            set
            {
                if (value != null)
                {
                    _preview = value;
                }
            }
        }
        public Material Material { get => _material; set => _material = value; }

        private void ValidateName(string Name)
        {
            if (HelperValidator.IsAnEmptyString(Name)) throw new BackEndException("Name must not be empty");
            if (HelperValidator.IsTrimmable(Name)) throw new BackEndException("Name must not start or end with spaces");
        }
    }
}