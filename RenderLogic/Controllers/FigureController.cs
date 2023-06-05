﻿using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Utilities;
using RenderLogic.DataTransferObjects;
using RenderLogic.Services;
using System;
using System.Collections.Generic;

namespace Render3D.RenderLogic.Controllers
{
    public class FigureController
    {
        public static FigureController figureController;
        public DataWarehouse DataWarehouse { get; set; }
        public FigureService FigureService { get; set; }
        public ClientController ClientController { get; set; }

        public static FigureController GetInstance()
        {
            if(figureController == null)
            {
                figureController = new FigureController();
            }
            return figureController;
        }
        public void AddFigure(FigureDto figureDto)
        {
            try
            {
                FigureService.GetFigureByNameAndClient(figureDto.Name,ClientController.Client);
                throw new BackEndException("figure already exists");
            }
            catch (Exception)
            {
                CreateSphere(figureDto);
                return;
            }
            

        }
        private void CreateSphere(FigureDto figureDto)
        {
            Figure figure = new Sphere() { Client = ClientController.Client, Name = figureDto.Name, Radius = figureDto.Radius };
            FigureService.AddFigure(figure);
        }
        public void DeleteFigureInList(FigureDto figureDto)
        {

        }

        public List<FigureDto> GetFigures()
        {
            List<Figure> figureList;
            try
            {
               figureList = FigureService.GetFigureOfClient(ClientController.Client);
            }
            catch
            {
                throw new Exception("The client does not have any figures");
            }
          List<FigureDto> figureDtos = new List<FigureDto>();
            foreach(Figure fig in figureList)
            {
                FigureDto figDto = new FigureDto()
                {
                    Id = fig.Id,
                    Name = fig.Name,
                    Radius = ((Sphere)fig).Radius
                };
                figureDtos.Add(figDto);
            }
            return figureDtos;
        }

        public void ChangeName(string oldName, string newName)
        {
            Figure figure=FigureService.GetFigureByNameAndClient(oldName,ClientController.Client);
            FigureService.UpdateName(figure.Id, newName);
        }
    }
}
