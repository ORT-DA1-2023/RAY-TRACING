﻿using Render3D.RenderLogic.Controllers;
using RenderLogic.DataTransferObjects;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace UserInterface.Panels
{
    public partial class SceneCreation : Form
    {
        private SceneDto _sceneDto;
        public SceneController sceneController;
        public SceneCreation(SceneDto selectedScene)
        {
            InitializeComponent();
            sceneController = SceneController.GetInstance();
            _sceneDto = selectedScene;
            
            if (_sceneDto == null)
            {
                string name;
                bool valid= false;
                while (!valid)
                {
                    using (var nameChanger = new NameChanger(""))
                    {
                        var result = nameChanger.ShowDialog(this);
                        if (result == DialogResult.OK)
                        {
                            name= nameChanger.newName;
                            try
                            {
                                sceneController.AddScene(name);
                                _sceneDto= new SceneDto() { Name= name }; 
                                valid = true;
                            }
                            catch
                            {
                            }
                        }
                    }
                }
            }
            LoadScene();
        }


        private void LoadScene()
        {
            _sceneDto = sceneController.GetScene(_sceneDto.Name);
            txtSceneName.Text = _sceneDto.Name;
            txtLookAt.Text = "(" + _sceneDto.LookAt[0] + ";" + _sceneDto.LookAt[1] + ";" + _sceneDto.LookAt[2] + ")";
            txtLookFrom.Text = "(" + _sceneDto.LookFrom[0] + ";" + _sceneDto.LookFrom[1] + ";" + _sceneDto.LookFrom[2] + ")";
            nrFov.Value = _sceneDto.Fov;
            cBoxAvailableModels.DataSource =sceneController.GetAvailableModels();
            cBoxAvailableModels.DisplayMember = "Name";
            cBoxPositionedModels.DataSource =sceneController.GetPositionedModels(_sceneDto);
            cBoxPositionedModels.DisplayMember = "Name";
            pBoxRender.Image = _sceneDto.Preview;
            lblCamera.Text = "";
            lblName.Text = "";
            lblAddModel.Text = "";
            lblRemoveModel.Text = "";
            if (_sceneDto.Aperture > 0)
            {
                cmbBlur.Checked = true;
                lblAperture.Text = _sceneDto.Aperture.ToString();
            }
            LastModifcationDateRefresh();
            if (_sceneDto.LastRenderizationDate != DateTime.MinValue)
            {
                LastRenderDateRefresh();
            }
            else
            {
                lblLastRenderDate.Text = "this scene has not been rendered yet";
            }
            CheckRenderOutDated();
        }

        private void LastRenderDateRefresh()
        {
            lblLastRenderDate.Text = "" + ((DateTime)_sceneDto.LastRenderizationDate).Month + "/" + ((DateTime)_sceneDto.LastRenderizationDate).Day + "/" + ((DateTime)_sceneDto.LastRenderizationDate).Year + " " + ((DateTime)_sceneDto.LastRenderizationDate).Hour + ":" + ((DateTime)_sceneDto.LastRenderizationDate).Minute;
        }

        private void LastModifcationDateRefresh()
        {
            lblLastModificationDate.Text = "" + _sceneDto.LastModificationDate.Month + "/" + _sceneDto.LastModificationDate.Day + "/" + _sceneDto.LastModificationDate.Year + " " + _sceneDto.LastModificationDate.Hour + ":" + _sceneDto.LastModificationDate.Minute;
        }

        private void CheckRenderOutDated()
        {
            if (_sceneDto.LastRenderizationDate == null || _sceneDto.LastRenderizationDate < (_sceneDto.LastModificationDate))
            {
                lblRenderOutDated.Text = "WARNING this render is outdated";
            }
            else
            {
                lblRenderOutDated.Text = "";
            }
        }

        public bool IsValidFormatAperture(string input)
        {
            Regex vectorFormat = new Regex(@"^\d+,\d+$");
            return vectorFormat.IsMatch(input);
        }

        public bool IsValidFormat(string input)
        {
            Regex vectorFormat = new Regex(@"^\(\s*-?\d+(\,\d+)?\s*;\s*-?\d+(\,\d+)?\s*;\s*-?\d+(\,\d+)?\s*\)$");
            return vectorFormat.IsMatch(input);
        }


        private void BtnGoBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void BtnChangeCamera_Click(object sender, EventArgs e)
        {
            if (IsValidFormat(txtLookFrom.Text) && IsValidFormat(txtLookAt.Text))
            {
                
                    try
                    {
                        if (cmbBlur.Checked)
                        {
                             if(IsValidFormatAperture(txtAperture.Text))
                             {
                                sceneController.EditCamera(_sceneDto, txtLookAt.Text, txtLookFrom.Text, (int)nrFov.Value, txtAperture.Text);
                             }
                             else
                             {
                                 throw new Exception("Aperture format not valid");
                              }                      
                        }
                    else
                    {
                        string apertureNegative = "-1";
                        sceneController.EditCamera(_sceneDto, txtLookAt.Text, txtLookFrom.Text, (int)nrFov.Value, apertureNegative);
                    }           
                        LoadScene();
                        lblCamera.ForeColor = Color.Green;
                        lblCamera.Text = "Camera settings change correctly";
                    }
                    catch (Exception ex)
                    {
                        lblCamera.ForeColor = Color.Red;
                        lblCamera.Text = ex.Message;
                    }
                
              

            }
            else
            {
                lblCamera.ForeColor = Color.Red;
                lblCamera.Text = "Format not valid";
            }
        }

        private void BtnChangeName_Click(object sender, EventArgs e)
        {
            try
            {
                sceneController.ChangeSceneName(_sceneDto, txtSceneName.Text);
                _sceneDto.Name = txtSceneName.Text;
                LoadScene();
                lblName.ForeColor = Color.Green;
                lblName.Text = "Name change correctly";
            }
            catch (Exception ex)
            {
                lblName.ForeColor = Color.Red;
                lblName.Text = ex.Message;
            }
        }

        private void BtnAddModel_Click(object sender, EventArgs e)
        {

          ModelDto model = ((ModelDto)cBoxAvailableModels.SelectedItem);
          sceneController.AddModel(_sceneDto, model, txtPosition.Text);
            lblAddModel.Text = "Model Added Correctly";  
            lblAddModel.ForeColor = Color.Green;
            LoadScene();
        }

        private void BtnRemoveModel_Click(object sender, EventArgs e)
        {
            ModelDto model = ((ModelDto)cBoxPositionedModels.SelectedItem);
            sceneController.RemoveModel(model);
            lblRemoveModel.Text = "Model Removed Correctly";
            lblRemoveModel.ForeColor = Color.Green;
            LoadScene();
        }

        private void BtnRender_Click(object sender, EventArgs e)
        {
            if (cmbBlur.Checked)
            {
                sceneController.RenderScene(_sceneDto,true);
            }
            else
            {

                sceneController.RenderScene(_sceneDto,false);
            }
            LoadScene();
        }

        private void CmbBlur_CheckedChanged(object sender, EventArgs e)
        {
            LoadScene();
            if (!cmbBlur.Checked)
            {
                txtAperture.Enabled = false;
                lblAperture.Enabled = false;
            }
            else
            {
                txtAperture.Enabled = true;
                lblAperture.Enabled = true;
            }
        }
    }
}
