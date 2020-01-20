using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentWiseApi;

namespace StudentWiseClient
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            timeNowTimer.Start();
            PopulateDashboard();
        }

        private void PopulateDashboard()
        {
            AddTodaysEventsToEventView();
            AddBalanceToDashboard();
        }

        private void AddTodaysEventsToEventView()
        {
            List<Event> events = Event.Enumerate(EventFilter.Today());
            todaysEventsFllpnl.Controls.Clear();

            if (events.Count == 0)
                todaysEventsFllpnl.Controls.Add(new DashboardNoEventToday());
            else
                foreach (Event ev in events)
                    todaysEventsFllpnl.Controls.Add(new EventComponent(ev));                    
        }

        private void AddBalanceToDashboard()
        {
            decimal balance = Server.CurrentSession.Info.ComputeBalance(Expense.Enumerate());
            balanceAmountLbl.Text = balance.ToString("0.00");
            balanceAmountLbl.ForeColor = balance >= 0 ? Color.Green : Color.Red;
        }

        private void TsBtn_Click(object sender, EventArgs e)
        {
            int targetTabIndex = tsMain.Items.IndexOf(sender as ToolStripItem);
            tcMain.SelectTab(targetTabIndex);
        }

        private void AddEventBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewEvent createEvent = new NewEvent();
            createEvent.Show();
        }

        private void AddEventComponentsToTodayPanel()
        {
            List<Event> events = Event.Enumerate();

            if (events.Count == 0)
                flowLayoutPanelToday.Controls.Add(new NoEventsAvailable());
            else
            {
                // Today's events
                foreach (Event ev in Event.Filter(events, EventFilter.Today()))
                    flowLayoutPanelToday.Controls.Add(new EventComponent(ev));

                // Upcoming events
                foreach (Event ev in Event.Filter(events, EventFilter.Upcoming()))
                    flowLayoutPanelUpcoming.Controls.Add(new EventComponent(ev));
            }

        }

        private void AddExpenseToExpenseListView(Expense expense)
        {
            ExpensesLv.Items.Add(new ListViewItem(new string[] { expense.Name, expense.Quantity.ToString(), expense.Price.ToString(), expense.Notes }));
        }

        private void AddMembersToExpenseListView(User participant, List<Expense> expenses)
        {
            MembersLv.Items.Add(new ListViewItem(new string[] { participant.FirstName, participant.ComputeBalance(expenses).ToString("0.00") }));

        }
        private void CalculateAndPopulateExpenses()
        {
            MembersLv.Items.Clear();
            ExpensesLv.Items.Clear();

            List<Expense> expenses = Expense.Enumerate();
            HashSet<User> users = new HashSet<User>();
            
            decimal total = 0;
            foreach (Expense expense in expenses)
            {
                total += expense.Price * expense.Quantity;
                AddExpenseToExpenseListView(expense);
                
                foreach (User participant in expense.Participants)
                {
                    users.Add(participant);
                }
            }

            foreach (User participant in users)
            {
                AddMembersToExpenseListView(participant, expenses);
            }

            ExpenseTotalPriceLbl.Text = total.ToString();
            ExpenseTotalPriceLbl.ForeColor = Color.Green;

            AddBalanceToDashboard();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            AddEventComponentsToTodayPanel();
            AddEventComponentAddParticipantToCreatedEvents();
            ReloadComplaints();
            CalculateAndPopulateExpenses();
            UserNameLbl.Text = Server.CurrentSession.Info.FirstName;
        }

        private void ReloadAgreements()
        {
            agreementsFlpnl.Controls.Clear();

            List<Agreement> agreements = Agreement.Enumerate();

            if (agreements.Count == 0)
                agreementsFlpnl.Controls.Add(new NoAgreements());
            else
                foreach (Agreement agreement in agreements)
                    agreementsFlpnl.Controls.Add(new AgreementComponent(agreement));
        }

        private void tbAgreements_Enter(object sender, EventArgs e)
        {
            ReloadAgreements();
        }

        private void AddComplaintToUI(Complaint complaint)
        {
            complaintsFllpnl.Controls.Add(new ComplaintsComponent(complaint));
            complaintsFllPanel.Controls.Add(new MiniComplaintComponent(complaint));
        }

        private void ReloadComplaints()
        {
            List<Complaint> complaints = Complaint.Enumerate();
            complaintsFllpnl.Controls.Clear();
            complaintsFllPanel.Controls.Clear();

            if (complaints.Count > 0)
            {
                foreach (Complaint complaint in complaints)
                    AddComplaintToUI(complaint);
            }
            else
            {
                complaintsFllPanel.Controls.Add(new NoComplaints());
                complaintsFllpnl.Controls.Add(new NoComplaints());
            }
        }

        private void FileComplaintBttn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(titleTbx.Text))
                throw new ApplicationException("Please, specify a title.");
            
            Complaint.Create(titleTbx.Text,
                string.IsNullOrWhiteSpace(descriptionTbx.Text) ? null : descriptionTbx.Text);

            titleTbx.Clear();
            descriptionTbx.Clear();
            ReloadComplaints();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timeNowLbl.Text = $"Today is {DateTime.Now.Date.ToString("dd/MM/yyyy")}";
        }

        private void AddExpenseBtn_Click(object sender, EventArgs e)
        {
            string expenseTitle = ExpenseTitleTbx.Text;
            string expenseNotes = ExpenseNotesRtbx.Text;

            if (string.IsNullOrEmpty(ExpenseTitleTbx.Text))
                throw new ApplicationException("Please, specify a title");
                            
            decimal expensePrice = ExpensePriceNum.Value;
            int expenseQuantity = Convert.ToInt32(ExpenseQuantityNum.Value);
            
            Expense expense = Expense.Create(expenseTitle, expensePrice, expenseQuantity,
                string.IsNullOrWhiteSpace(expenseNotes) ? null : expenseNotes);

            // Share expeses with all users by default
            foreach(User user in User.Enumerate())
            {
                if (user != Server.CurrentSession.Info)
                {
                    expense.AddParticipant(user.Id);
                }
            }

            CalculateAndPopulateExpenses();
            MessageBox.Show("You successfully created the expense!");
        }

        private void NewAgreementBttn_Click(object sender, EventArgs e)
        {
            string description = agreementDescriprionTbx.Text;
            string title = agreementTitleTbx.Text;

            if (string.IsNullOrEmpty(title))
                throw new ApplicationException("Please, specify a title.");

            Agreement agreement = Agreement.Create(title,
                string.IsNullOrWhiteSpace(description) ? null : description);

            foreach (Control control in agreementsFlpnl.Controls)
                if (control is NoAgreements)
                    agreementsFlpnl.Controls.Remove(control);

            agreementsFlpnl.Controls.Add(new AgreementComponent(agreement));
        }

        private void MyEventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tcMain.SelectTab(tpEvents);
        }

        private void CreatedEventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tcMain.SelectTab(tpCreatedEvents);
        }
        private void AddEventComponentAddParticipantToCreatedEvents()
        {
            List<Event> events = Event.Enumerate(EventFilter.Involved(EventInvolvement.Creator));
            
            if (events.Count == 0)
                CreatedEventsFllpnl.Controls.Add(new NoEventsAvailable());
            else
                foreach (Event ev in events)
                    CreatedEventsFllpnl.Controls.Add(new EventComponentAddParticipant(ev));
        }

        private void AddGroupToUI(Group group)
        {
            Control groupComponent;

            if (Server.CurrentSession.Info.Admin)
                groupComponent = new GroupDetailedComponent(group, User.Enumerate());
            else
                groupComponent = new GroupComponent(group);

            flPnlGroups.Controls.Add(groupComponent);
        }

        private void ReloadGroups()
        {
            flPnlGroups.Controls.Clear();

            List<Group> groups = Server.CurrentSession.Info.Admin ? Group.Enumerate() : new List<Group>() { Server.CurrentSession.Info.PrimaryGroup };

            if (groups.Count > 0)
            {
                foreach (Group group in groups)
                {
                    AddGroupToUI(group);
                }
            }
            else
            {
                NoGroups noGroups = new NoGroups();
                flPnlGroups.Controls.Add(noGroups);
            }
        }

        private void TpGroups_Enter(object sender, EventArgs e)
        {
            if (Server.CurrentSession.Info.Admin)
            {
                lblGroups.Text = "Groups:";
                gbNewGroup.Visible = true;
            }
            else
            {
                lblGroups.Text = "Your Group:";
                gbNewGroup.Visible = false;
            }

            ReloadGroups();
        }

        private void BtnAddGroup_Click(object sender, EventArgs e)
        {
            string name = tbxGroupName.Text;
            string description = tbxGroupDescription.Text;
            string rules = tbxGroupRules.Text;

            if (string.IsNullOrEmpty(name))
                throw new ApplicationException("Please, enter a group name.");

            Group group = Group.Create(name, description, string.IsNullOrWhiteSpace(rules) ? null : rules);
            AddGroupToUI(group);
        }

        private void AddEventBtn_Resize(object sender, EventArgs e)
        {
            lblEvents.Width = AddEventBtn.Width;
            UpcomingEventsLbl.Width = AddEventBtn.Width;
        }
    }
}
