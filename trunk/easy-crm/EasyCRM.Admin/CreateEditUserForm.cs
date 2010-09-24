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
    public partial class CreateEditUserForm : Form
    {
        bool _editMode;
        User _user;
        string _oldPassword;

        Dictionary<string, string> _modelState;
        IMembershipService _membershipService;

        public CreateEditUserForm()
            : this(new User(), false)
        {

        }

        public CreateEditUserForm(User user, bool editMode)
        {
            InitializeComponent();

            _user = user;
            _editMode = editMode;
            _oldPassword = user.Password;

            _modelState = new Dictionary<string, string>();
            _membershipService = new MembershipService(new UserService(new SimpleModelStateWrapper(_modelState)));

            if (_editMode)
            {
                this.Text = "Edit User";
                this.createEditButton.Text = "Save";
                this.userNameTextBox.Enabled = false;
            }

            this.userBindingSource.DataSource = _user;
        }

        private void showValidationErrors()
        {
            validationMessageLabel.Visible = true;

            otherErrorLabel.Text = (_modelState.ContainsKey("otherError")) ? _modelState["otherError"] : "";
            lastNameErrorLabel.Text = (_modelState.ContainsKey("User.LastName")) ? _modelState["User.LastName"] : "";
            firstNameErrorLabel.Text = (_modelState.ContainsKey("User.FirstName")) ? _modelState["User.FirstName"] : "";
            userNamErrorLabel.Text = (_modelState.ContainsKey("User.UserName")) ? _modelState["User.UserName"] : "";
            passwordErrorLabel.Text = (_modelState.ContainsKey("User.Password")) ? _modelState["User.Password"] : "";
            emailErrorLabel.Text = (_modelState.ContainsKey("User.Email")) ? _modelState["User.Email"] : "";
            confirmPasswordErrorLabel.Text = (_modelState.ContainsKey("User.ConfirmPassword")) ? _modelState["User.ConfirmPassword"] : "";
        }

        private void createEditButton_Click(object sender, EventArgs e)
        {
            if (_editMode)
            {
                if (_membershipService.UpdateUser(_user, _oldPassword))
                {
                    int current = EasyCRMForm.getForm().usersBindingSource.Position;
                    EasyCRMForm.getForm().usersBindingSource.List[current] = _user;

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
            else//creating  a new user
            {
                MembershipCreateStatus status = _membershipService.CreateUser(_user);

                if (status == MembershipCreateStatus.Success)
                {
                    EasyCRMForm.getForm().usersBindingSource.Add(_user);

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
