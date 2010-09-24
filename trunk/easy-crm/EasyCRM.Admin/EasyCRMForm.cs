using System.Windows.Forms;
using EasyCRM.Model.Services;
using EasyCRM.Model.Services.Impl;
using System.Collections.Generic;
using EasyCRM.Model.Domains;

namespace EasyCRM.Admin
{
    public partial class EasyCRMForm : Form
    {
        private static EasyCRMForm _instance = null;

        //services
        private IMembershipService _membershipService;
        private IUserService _userService;
        private ITaskService _taskService;
        private IContactService _contactService;
        private IAccountService _accountService;
        private IOpportunityService _opportunityService;
        private IIndustrialSectorService _sectorService;

        //
        private Dictionary<string, string> _userModelState = new Dictionary<string, string>();
        private Dictionary<string, string> _taskModelState = new Dictionary<string, string>();
        private Dictionary<string, string> _sectorModelState = new Dictionary<string, string>();

        private EasyCRMForm()
        {
            InitializeComponent();
            InitializeServices();

        }

        private void InitializeServices()
        {
            _userService = new UserService(new SimpleModelStateWrapper(_userModelState));
            _taskService = new TaskService(new SimpleModelStateWrapper(_taskModelState));
            _sectorService = new IndustrialSectorService(new SimpleModelStateWrapper(_taskModelState));
        }

        public static EasyCRMForm getForm()
        {
            if (_instance == null)
                _instance = new EasyCRMForm();

            return _instance;
        }

        private void EasyCRMForm_Load(object sender, System.EventArgs e)
        {
            this.usersBindingSource.DataSource = _userService.ListUsers();
            this.sectorsBindingSource.DataSource = _sectorService.ListIndustrialSectors();
        }


        private void userBindingNavigatorAddNewItem_Click(object sender, System.EventArgs e)
        {
            CreateEditUserForm form = new CreateEditUserForm();

            form.ShowDialog(this);
        }

        private void userBindingNavigatorDeleteItem_Click(object sender, System.EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Are you sure you want to delete this user (cannot be undo) ?",
                       "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                if (_membershipService.DeleteUser((User)this.usersBindingSource.Current))
                    this.usersBindingSource.RemoveCurrent();
                else
                    MessageBox.Show(this, "Sorry, we were unable to delete the user. Try again.",
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void userBindingNavigatorEditItem_Click(object sender, System.EventArgs e)
        {
            User userToEdit = (User)usersBindingSource.Current;
            userToEdit.ConfirmPassword = userToEdit.Password;

            CreateEditUserForm form = new CreateEditUserForm(userToEdit,true /*editMode*/);

            form.ShowDialog(this);

        }

        private void userBindingNavigatorRefresh_Click(object sender, System.EventArgs e)
        {
            this.usersBindingSource.DataSource = _userService.ListUsers();
        }



    }
}
