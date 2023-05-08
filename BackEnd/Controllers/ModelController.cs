﻿using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Render3D.BackEnd.Utilities;


namespace Render3D.BackEnd.Controllers
{
    public class ModelController
    {
        private DataWarehouse _dataWarehouse;
        private ClientController _clientController;
        private GraphicMotor _graphicMotor= new GraphicMotor();

        public DataWarehouse DataWarehouse { get => _dataWarehouse; set { _dataWarehouse = value; } }
        public ClientController ClientController { get => _clientController; set => _clientController = value; }
        public void AddAModelWithoutPreview(string clientName, string modelName, Figure figure, Material material)
        {

            try
            {
                GetModelByNameAndClient(clientName, modelName);

            }
            catch (Exception)
            {
                CreateAndAddModel(ClientController.GetClientByName(clientName), modelName, figure,material);
                return;
            }
            throw new BackEndException("model already exists");
        }
        public void AddAModelWithPreview(string clientName, string modelName, Figure figure, Material material)
        {
            AddAModelWithoutPreview(clientName, modelName, figure, material);
            AddPreviewToTheModel(clientName, modelName);
        }
        private void CreateAndAddModel(Client client, string modelName, Figure figure, Material material)
        {
            Model model = new Model() { Client = client, Name = modelName, Figure = figure, Material = material };
            _dataWarehouse.Models.Add(model);
        }
        public Model GetModelByNameAndClient(string clientName, string modelName)
        {
            Client client = ClientController.GetClientByName(clientName);
            foreach (Model model in _dataWarehouse.Models)
            {
                if (model.Name == modelName && model.Client.Equals(client))
                {
                    return model;
                }
            }
            throw new BackEndException("model doesnt exist");
        }
        private void AddPreviewToTheModel(string clientName, string modelName)
        {
            Model model = GetModelByNameAndClient(clientName, modelName);
            model.Preview = _graphicMotor.RenderModelPreview(model);
        }
        public void ChangeModelName(string clientName, string oldName, string newName)
        {
            Model model;
            try
            {
                model = GetModelByNameAndClient(clientName, oldName);
            }
            catch (Exception)
            {
                return;
            }
            try
            {
                GetModelByNameAndClient(clientName, newName);
            }
            catch (Exception)
            {
                model.Name = newName;
            }
        }

        public void DeleteModelInList(string clientName, string modelName)
        {
            try
            {
                Model model = GetModelByNameAndClient(clientName, modelName);
                _dataWarehouse.Models.Remove(model);
            }
            catch (Exception)
            {
            }

        }
    }

}
