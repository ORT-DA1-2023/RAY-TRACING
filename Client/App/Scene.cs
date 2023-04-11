﻿using System;
using System.Collections;
using System.Xml.Linq;

namespace App
{
    public class Scene
    {
        private DateTime registerDate;
        private DateTime lastModificationDate;
        private Client client;
        private String name;
        private ArrayList positionedModels;
        private decimal[] cameraPosition;
        private decimal[] objectPosition;
        private int fieldOfView;
        public Scene()
        {
            registerDate = DateTime.Now;
            cameraPosition = new decimal[3] {0,2,0};
            objectPosition= new decimal[3] { 0, 2, 5 };
            fieldOfView = 30;
        }

        public Client Client { get => client; set => client = value; }
        public string Name
        {
            get => name;
            set
            {
                if (isAValidName(value))
                {
                    name = value;
                }
            }
        }


        public ArrayList PositionedModels { get; set; }
        public decimal[] CameraPosition { get => cameraPosition; set => cameraPosition = value; }
        public decimal[] ObjectPosition { get=>objectPosition; set=>objectPosition=value; }
        public int FieldOfView { get => fieldOfView; set => fieldOfView = value; }
       

        private bool isAValidName(string value)
    {
        if (value == "")
        {
            throw new BackEndException("Name cant be empty");
        }
        if (value != value.Trim())
        {
            throw new BackEndException("Name cant start or end with blank");
        }
        return true;
    }
}
}
