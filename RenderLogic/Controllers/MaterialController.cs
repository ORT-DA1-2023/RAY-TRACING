﻿using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd.Utilities;
using RenderLogic.DataTransferObjects;
using RenderLogic.Services;
using System;
using System.Collections.Generic;

namespace Render3D.RenderLogic.Controllers
{
    public class MaterialController
    {
        public DataWarehouse DataWarehouse { get; set; }
        public ClientController ClientController = ClientController.GetInstance();
        protected static MaterialController materialController;
        public MaterialService MaterialService { get; set; }
        public static MaterialController GetInstance()
        {
            if (materialController == null)
            {
                materialController = new MaterialController();
            }
            return materialController;
        }

        public void AddMaterial(MaterialDto materialDto)
        {
            try
            {
                MaterialService.GetMaterialByNameAndClient(materialDto.Name,ClientController.Client);
                throw new BackEndException("material already exists");
            }
            catch (Exception)
            {
                Colour colour = new Colour(materialDto.Red / 255f, materialDto.Green / 255f, materialDto.Blue / 255f);
                if (materialDto.Blur != 0)
                {
                    CreateMetallicMaterial(materialDto.Name, colour, materialDto.Blur);
                }
                else
                {
                    CreateLambertianMaterial(materialDto.Name, colour);
                }
            }          
        }
        private void CreateLambertianMaterial(string materialName, Colour colour)
        {
            Material material = new LambertianMaterial() 
            { 
                Client = ClientController.Client,
                Name = materialName, 
                Attenuation = colour };
            MaterialService.AddMaterial(material);
        }         

        private void CreateMetallicMaterial(string materialName, Colour colour, double blur)
        {
            Material material = new MetallicMaterial()
            {
                Client = ClientController.Client, 
                Name = materialName, 
                Attenuation = colour, 
                Blur = blur };
           MaterialService.AddMaterial(material);
        }

        public void ChangeName(MaterialDto materialDto, string newName)
        {
            try
            {
                Material material = MaterialService.GetMaterialByNameAndClient(newName, ClientController.Client);
                throw new Exception("There is already a material with that name");
            }
            catch
            {
            }
            Material tryName = new LambertianMaterial() { Name = newName };
            MaterialService.UpdateName(int.Parse(materialDto.Id), newName);
        }
        public void Delete(MaterialDto materialDto)
        {
            MaterialService.RemoveMaterial(int.Parse(materialDto.Id));
        }

        public List<MaterialDto> GetMaterials()
        {

            List<Material> MaterialList;
            try
            {
                MaterialList = MaterialService.GetMaterialsOfClient(ClientController.Client);
            }
            catch
            {
                throw new Exception("The client does not have any figures");
            }

            List<MaterialDto> materialDtos = new List<MaterialDto>();
            foreach (Material mat in MaterialList)
            {
                MaterialDto matDto = new MaterialDto()
                {
                    Id = mat.Id,
                    Name = mat.Name,
                    Red = mat.Attenuation.Red(),
                    Green = mat.Attenuation.Green(),
                    Blue = mat.Attenuation.Blue()
                };
               materialDtos.Add(matDto);
            }
            return materialDtos;
        }

     
    }
}
