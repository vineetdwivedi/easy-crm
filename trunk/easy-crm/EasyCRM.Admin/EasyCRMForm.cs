using System.Windows.Forms;
using EasyCRM.Model.Services;
using EasyCRM.Model.Services.Impl;
using System.Collections.Generic;
using EasyCRM.Model.Domains;
using EasyCRM.Model.Repositories;
using EasyCRM.Model.Repositories.Entity;

namespace EasyCRM.Admin
{
    public partial class EasyCRMForm : Form
    {
        private static EasyCRMForm _instance = null;

        //services
        private IMembershipService _membershipService;
        private IIndustrialSectorService _sectorService;

        //repositories
        private IUserRepository _userRepository;
        private IIndustrialSectorRepository _sectorRepository;
        private ITaskRepository _taskRepository;
        private IContactRepository _contactRepository;
        private IAccountRepository _accountRepository;
        private IOpportunityRepository _opportunityRepository;

        //
        private List<User> userComboBoxItems;

        private EasyCRMForm()
        {
            InitializeComponent();
            InitializeServices();
            InitializeRepositories();


        }

        private void InitializeServices()
        {
            _membershipService = new MembershipService(new UserService(new SimpleModelStateWrapper(new Dictionary<string, string>())));
            _sectorService = new IndustrialSectorService(new SimpleModelStateWrapper(new Dictionary<string, string>()));

        }

        private void InitializeRepositories()
        {
            _userRepository = new UserEntityRepository();
            _sectorRepository = new IndustrialSectorEntityRepository();
            _taskRepository = new TaskEntityRepository();
            _contactRepository = new ContactEntityRepository();
            _accountRepository = new AccountEntityRepository();
            _opportunityRepository = new OpportunityEntityRepository();
        }

        public static EasyCRMForm getForm()
        {
            if (_instance == null)
                _instance = new EasyCRMForm();

            return _instance;
        }

        #region EasyCRM Menu Events

        private void newUserToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.tabControl.SelectedTab = this.usersTabPage;
            CreateEditUserForm form = new CreateEditUserForm();
            form.ShowDialog(this);
        }

        private void newSectorToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.tabControl.SelectedTab = this.sectorsTabPage;
            CreateEditSectorForm form = new CreateEditSectorForm();
            form.ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.ShowDialog(this);
        }
        #endregion

        #region EasyCRM ToolStrip Events
        private void newUserToolStripButton_Click(object sender, System.EventArgs e)
        {
            this.tabControl.SelectedTab = this.usersTabPage;
            CreateEditUserForm form = new CreateEditUserForm();
            form.ShowDialog(this);

        }

        private void newSectorToolStripButton_Click(object sender, System.EventArgs e)
        {
            this.tabControl.SelectedTab = this.sectorsTabPage;
            CreateEditSectorForm form = new CreateEditSectorForm();
            form.ShowDialog(this);
        }

        private void aboutToolStripButton_Click(object sender, System.EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.ShowDialog(this);
        }

        private void exitToolStripButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region EasyCRM Form Events
        private void EasyCRMForm_Load(object sender, System.EventArgs e)
        {
            List<User> users = (List<User>)_userRepository.ListAll();

            this.usersBindingSource.DataSource = users;
            this.accountsBindingSource.DataSource = _accountRepository.ListAll();
            this.sectorsBindingSource.DataSource = _sectorRepository.ListAll();
            this.tasksBindingSource.DataSource = _taskRepository.ListAll();
            this.contactsBindingSource.DataSource = _contactRepository.ListAll();


            this.userComboBoxItems = new List<User>(users);
            this.userComboBoxItems.Insert(0, new User()
                                            {
                                                UserName = "",
                                                Email = "All"
                                            });

            //setting combo boxes for choosing the user whose information is desired
            this.accountBindingNavigatorSelectUserItem.ComboBox.DisplayMember = "Email";
            this.accountBindingNavigatorSelectUserItem.ComboBox.ValueMember = "UserName";

            this.taskBindingNavigatorSelectUserItem.ComboBox.DisplayMember = "Email";
            this.taskBindingNavigatorSelectUserItem.ComboBox.ValueMember = "UserName";

            this.contactBindingNavigatorSelectUserItem.ComboBox.DisplayMember = "Email";
            this.contactBindingNavigatorSelectUserItem.ComboBox.ValueMember = "UserName";

            this.accountBindingNavigatorSelectUserItem.ComboBox.Items.AddRange(userComboBoxItems.ToArray());
            this.taskBindingNavigatorSelectUserItem.ComboBox.Items.AddRange(userComboBoxItems.ToArray());
            this.contactBindingNavigatorSelectUserItem.ComboBox.Items.AddRange(userComboBoxItems.ToArray());

            this.accountBindingNavigatorSelectUserItem.ComboBox.SelectedIndex = 0;
            this.taskBindingNavigatorSelectUserItem.ComboBox.SelectedIndex = 0;
            this.contactBindingNavigatorSelectUserItem.ComboBox.SelectedIndex = 0;
        }
        private void EasyCRMForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Are you sure you want to quit the application ?",
           "Confirm Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region Web browser Tab Events
        private void browserToolStripGoBackButton_Click(object sender, System.EventArgs e)
        {
            this.browserToolStripGoBackButton.Enabled = this.webBrowser.GoBack();
        }

        private void browserToolStripGoForwardButton_Click(object sender, System.EventArgs e)
        {
            this.browserToolStripGoForwardButton.Enabled = this.webBrowser.GoForward();
        }

        private void browserToolStripHomeButton_Click(object sender, System.EventArgs e)
        {
            this.webBrowser.Url = new System.Uri("http://www.google.fr", System.UriKind.Absolute);

        }

        private void browserToolStripAddressBarCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                launchAddress();
            }
        }

        private void browserToolStripGoButton_Click(object sender, System.EventArgs e)
        {
            launchAddress();
        }

        private void launchAddress()
        {
            string url = this.browserToolStripAddressBarCombo.Text;

            if (!this.browserToolStripAddressBarCombo.Items.Contains(url))
                this.browserToolStripAddressBarCombo.Items.Add(url);
            try
            {
                this.webBrowser.Url = new System.Uri(url, System.UriKind.RelativeOrAbsolute);
                this.browserToolStripAddressBarLabel.Visible = false;
            }
            catch
            {
                this.browserToolStripAddressBarLabel.Visible = true;
            }
        }
        #endregion

        #region Users Tab Events

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

            CreateEditUserForm form = new CreateEditUserForm(userToEdit, true /*editMode*/);

            form.ShowDialog(this);

        }

        private void userBindingNavigatorRefresh_Click(object sender, System.EventArgs e)
        {
            this.usersBindingSource.DataSource = _userRepository.ListAll();
        }

        #endregion

        #region Accounts Tab Events
        private void accountBindingNavigatorSelectUserItem_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            refreshUserAccounts();
        }
        private void accountBindingNavigatorRefreshItems_Click(object sender, System.EventArgs e)
        {
            refreshUserAccounts();
        }

        private void refreshUserAccounts()
        {
            int index = this.accountBindingNavigatorSelectUserItem.SelectedIndex;
            User item = this.userComboBoxItems[index];

            this.accountsBindingSource.DataSource = _accountRepository.ListAllByCriteria(
                                                user => user.Owner.UserName.Contains(item.UserName));
        }
        #endregion

        #region Tasks Tab Events
        private void taskBindingNavigatorSelectUserItem_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            refreshUserTasks();
        }
        private void taskBindingNavigatorRefreshItems_Click(object sender, System.EventArgs e)
        {
            refreshUserTasks();
        }

        private void refreshUserTasks()
        {
            int index = this.taskBindingNavigatorSelectUserItem.SelectedIndex;
            User item = this.userComboBoxItems[index];

            this.tasksBindingSource.DataSource = _taskRepository.ListAllByCriteria(
                                                user => user.ResponsibleUser.UserName.Contains(item.UserName));
        }
        #endregion

        #region Contacts Tab Events

        private void contactBindingNavigatorSelectUserItem_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            refreshUserContacts();
        }
        private void contactBindingNavigatorRefreshItems_Click(object sender, System.EventArgs e)
        {
            refreshUserContacts();
        }

        private void refreshUserContacts()
        {
            int index = this.contactBindingNavigatorSelectUserItem.SelectedIndex;
            User item = this.userComboBoxItems[index];

            this.contactsBindingSource.DataSource = _contactRepository.ListAllByCriteria(
                                                contact => contact.ResponsibleUser.UserName.Contains(item.UserName));
        }
        #endregion

        #region Sectors Tab Events
        private void sectorBindingNavigatorAddNewItem_Click(object sender, System.EventArgs e)
        {
            CreateEditSectorForm form = new CreateEditSectorForm();
            form.ShowDialog(this);
        }

        private void sectorBindingNavigatorDeleteItem_Click(object sender, System.EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Are you sure you want to delete this industrial sector (cannot be undo) ?",
           "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                if (_sectorService.DeleteIndustrialSector((IndustrialSector)this.sectorsBindingSource.Current))
                    this.sectorsBindingSource.RemoveCurrent();
                else
                    MessageBox.Show(this, "Sorry, we were unable to delete the sector. Try again.",
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sectorBindingNavigatorEditItem_Click(object sender, System.EventArgs e)
        {
            IndustrialSector sectorToEdit = (IndustrialSector)sectorsBindingSource.Current;

            CreateEditSectorForm form = new CreateEditSectorForm(sectorToEdit, true /*editMode*/);

            form.ShowDialog(this);
        }

        private void sectorBindingNavigatorRefreshItems_Click(object sender, System.EventArgs e)
        {
            this.sectorsBindingSource.DataSource = _sectorRepository.ListAll();
        }
        #endregion



    }
}
