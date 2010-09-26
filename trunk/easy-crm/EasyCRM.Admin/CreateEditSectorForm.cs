using System;
using System.Web.Security;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EasyCRM.Model.Domains;
using EasyCRM.Model.Services;
using EasyCRM.Model.Services.Impl;

namespace EasyCRM.Admin
{
    public partial class CreateEditSectorForm : Form
    {
        bool _editMode;
        IndustrialSector _sector;

        Dictionary<string, string> _modelState;
        IIndustrialSectorService _sectorService;

        public CreateEditSectorForm()
            : this(new IndustrialSector(), false)
        {

        }

        public CreateEditSectorForm(IndustrialSector sector, bool editMode)
        {
            InitializeComponent();

            _sector = sector;
            _editMode = editMode;

            _modelState = new Dictionary<string, string>();
            _sectorService = new IndustrialSectorService(new SimpleModelStateWrapper(_modelState));

            if (_editMode)
            {
                this.Text = "Edit Sector";
                this.createEditButton.Text = "Save";
            }

            this.sectorBindingSource.DataSource = _sector;
        }

        private void showValidationErrors()
        {
            validationMessageLabel.Visible = true;

            otherErrorLabel.Text = (_modelState.ContainsKey("otherError")) ? _modelState["otherError"] : "";
            sectorErrorLabel.Text = (_modelState.ContainsKey("Sector.LastName")) ? _modelState["Sector.LastName"] : "";
           
        }

        private void createEditButton_Click(object sender, EventArgs e)
        {
            if (_editMode)
            {
                if (_sectorService.EditIndustrialSector(_sector))
                {
                    int current = EasyCRMForm.getForm().sectorsBindingSource.Position;
                    EasyCRMForm.getForm().sectorsBindingSource.List[current] = _sector;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    showValidationErrors();
                    //we clear the model state previous errors
                    _modelState.Clear();
                }
            }
            else//creating  a new sector
            {
                if (_sectorService.CreateIndustrialSector(_sector))
                {
                    EasyCRMForm.getForm().sectorsBindingSource.Add(_sector);

                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
                else
                {
                    showValidationErrors();
                    _modelState.Clear(); //we clear the model state previous errors
                }

            }
        }

    }
}
