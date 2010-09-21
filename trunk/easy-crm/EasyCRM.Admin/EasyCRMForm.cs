using System.Windows.Forms;
using EasyCRM.Model.Services;
using EasyCRM.Model.Services.Impl;
using System.Collections.Generic;

namespace EasyCRM.Admin
{
    public partial class EasyCRMForm : Form
    {   
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

        public EasyCRMForm()
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

        private void EasyCRMForm_Load(object sender, System.EventArgs e)
        {
            setUsers();
            setSectors();
        }


        private void setUsers()
        {
            this.userBindingSource.DataSource = _userService.ListUsers(); 
        }

        private void setSectors()
        {
            this.sectorBindingSource.DataSource = _sectorService.ListIndustrialSectors(); 
        }



    }
}
