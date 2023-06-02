﻿using Render3D.RenderLogic.Controllers;
using Render3D.BackEnd.Utilities;
using System.Windows.Forms;
using RenderLogic;
using RenderLogic.RepoInterface;

namespace Render3D.UserInterface
{
    public partial class Render3DIU : Form
    {
        public DataWarehouse dataWarehouse = new DataWarehouse();
        public ClientController clientController = ClientController.Instance();
        public FigureController figureController = new FigureController();
        public MaterialController materialController = new MaterialController();
        public ModelController modelController = new ModelController();
        public SceneController sceneController = new SceneController();
        public Render3DIU()
        {
            figureController.DataWarehouse = dataWarehouse;
            figureController.ClientController = clientController;
            materialController.DataWarehouse = dataWarehouse;
            materialController.ClientController = clientController;
            modelController.DataWarehouse = dataWarehouse;
            modelController.ClientController = clientController;
            sceneController.DataWarehouse = dataWarehouse;
            sceneController.ClientController = clientController;
            InitializeComponent();
            UserWantsToLogIn();
        }
        public void UserWantsToLogIn()
        {
            ShowObjectCreationPanel(new Login());
        }

        public void EnterMenu()
        {
            ShowObjectCreationPanel(new CreationMenu());
        }

        public void UserWantsToSignIn()
        {
            ShowObjectCreationPanel(new SignIn());
        }

        private void ShowObjectCreationPanel(object formSon)
        {
            if (this.pnLayout.Controls.Count > 0)
            {
                this.pnLayout.Controls.RemoveAt(0);
            }
            Form form = formSon as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.pnLayout.Controls.Add(form);
            this.pnLayout.Tag = form;
            form.Show();
        }
    }
}
