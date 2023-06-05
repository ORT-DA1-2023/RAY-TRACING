
using Render3D.RenderLogic.Controllers;
using Render3D.UserInterface.Controls;
using Render3D.UserInterface.Panels;
using RenderLogic.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace Render3D.UserInterface
{
    public partial class CreationMenu : Form
    {
        private Render3DIU render;
        private readonly ClientController clientController = ClientController.GetInstance();
        private readonly FigureController figureController = FigureController.GetInstance();
        public CreationMenu()
        {
            InitializeComponent();
        }

        public void ShowFigureList()
        {
            flObjectList.Controls.Clear();
            List<FigureDto> figureList = figureController.GetFigures();
            foreach (FigureDto figure in figureList)
            {
                    FigureControl figureControl = new FigureControl(figure);
                    flObjectList.Controls.Add(figureControl);
            }
        }

        public void ShowMaterialList()
        {
            flObjectList.Controls.Clear();
            List<MaterialDto> materialList = render.materialController.GetMaterials();
            foreach (MaterialDto material in materialList)
            {
                    MaterialControl materialControl = new MaterialControl(material);
                    flObjectList.Controls.Add(materialControl);

            }
        }
        public void ShowModelList()
        {
            flObjectList.Controls.Clear();
            List<ModelDto> models = render.modelController.GetModels();
            foreach (ModelDto model in models)
            {
                    ModelControl modelControl = new ModelControl(model);
                    flObjectList.Controls.Add(modelControl);
            }
        }

        public void ShowSceneList()
        {
            flObjectList.Controls.Clear();
            List<SceneDto> scenes = render.sceneController.GetScenes();
            scenes.Sort((scene1, scene2) => scene2.LastModificationDate.CompareTo(scene1.LastModificationDate));
            foreach (SceneDto scene in scenes)
            {  
                    SceneControl sceneControl = new SceneControl(scene);
                    flObjectList.Controls.Add(sceneControl);
            }
        }


        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            render.clientController.LogOut();
            render.UserWantsToLogIn();
        }
        private void BtnMaterial_Click(object sender, EventArgs e)
        {
            Refresh("Material");
        }

        private void BtnFigure_Click(object sender, EventArgs e)
        {
            Refresh("Figure");
        }

        private void BtnModel_Click(object sender, EventArgs e)
        {
            Refresh("Model");
        }



        private void ShowObjectCreationPanel(object formSon)
        {
            if (this.pnlObjectCreation.Controls.Count > 0)
            {
                this.pnlObjectCreation.Controls.RemoveAt(0);
            }
            Form form = formSon as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.pnlObjectCreation.Controls.Add(form);
            this.pnlObjectCreation.Tag = form;
            form.Show();
        }

        private void VariablesInitialize(object sender, EventArgs e)
        {
            render = (Render3DIU)this.Parent.Parent;
            lblShowClientName.Text = "Welcome back \n" + clientController.GetClient() + "!!";
            ShowObjectCreationPanel(new FigurePanel());
            ShowFigureList();
        }
        public void Refresh(string toShow)
        {
            if (toShow == "Material")
            {
                ShowObjectCreationPanel(new MaterialPanel());
                ShowMaterialList();
            }
            if (toShow == "Figure")
            {
                ShowObjectCreationPanel(new FigurePanel());
                ShowFigureList();
            }
            if (toShow == "Model")
            {
                ShowObjectCreationPanel(new ModelPanel());
                ShowModelList();
            }
            if (toShow == "Scene")
            {
                ShowObjectCreationPanel(new ScenePanel());
                ShowSceneList();
            }

        }
        public bool ChangeFigureName(string oldName, string newName)
        {
            try
            {
                figureController.ChangeName(oldName,newName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void DeleteFigure(FigureDto figure)
        {
            figureController.DeleteFigureInList(figure);
        }

        internal bool MaterialNameHasBeenChanged(string oldName, string newName)
        {
            render.materialController.ChangeMaterialName("", oldName, newName);

        }

        internal void DeleteMaterial(string materialName)
        {
            render.materialController.DeleteMaterialInList("", materialName);
        }

        internal bool ModelNameHasBeenChanged(string oldName, string newName)
        {
            render.modelController.ChangeModelName("", oldName, newName);
            if (render.modelController.GetModelByNameAndClient("", newName) != null)
            {
                return true;
            }
            return false;
        }

        internal void DeleteModel(string modelName)
        {
            render.modelController.DeleteModelInList(modelName);
        }

        private void BtnScene_Click(object sender, EventArgs e)
        {
            Refresh("Scene");
        }

        internal void DeleteScene(string sceneName)
        {
            render.sceneController.DeleteSceneInList("", sceneName);
        }

        internal bool FigureIsPartOfModel(string figureName)
        {
            try
            {
                List<ModelDto> models = render.modelController.GetModelsWithFigure(figureName);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        internal bool MaterialIsPartOfModel(string materialName)
        {
            try
            {
                List<ModelDto> models = render.modelController.GetModelWithMaterial(materialName);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        internal bool ModelIsPartOfScene(string modelName)
        {
            try
            {
                List<SceneDto> scene = render.sceneController.GetSceneWithModel(modelName);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
