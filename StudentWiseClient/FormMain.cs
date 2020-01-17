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
            List<Event> events = Event.Enumerate(); // TODO: filter them to be today's only
            todaysEventsFllpnl.Controls.Clear();

            if (events.Count == 0)
            {
                DashboardNoEventToday eventComponent = new DashboardNoEventToday();
                todaysEventsFllpnl.Controls.Add(eventComponent);
            } else
            {
                foreach (Event ev in events)
                {
                    DateTime startDate = Convert.ToDateTime(ev.StartsAt);
                    var date = startDate.Date;
                    var dateAndTime = DateTime.Now;
                    var dateNow = dateAndTime.Date;
                    EventComponent eventComponent = new EventComponent();
                    eventComponent.SetAllNeededProperties(ev.Id, ev.Creator, Server.CurrentSession, ev.Title, ev.Description, ev.Type, ev.StartsAt, ev.FinishesAt);
                    if (date == dateNow)
                    {
                        todaysEventsFllpnl.Controls.Add(eventComponent);
                    }
                }
            }
        }

        private void AddBalanceToDashboard()
        {
            decimal balance = Server.CurrentSession.Info.ComputeBalance(Expense.Enumerate()); // TODO: filter which expenses
            balanceAmountLbl.Text = balance.ToString();
            if (balance > 0)
            {
                balanceAmountLbl.ForeColor = Color.Green;
            }
            else
            {
                balanceAmountLbl.ForeColor = Color.Red;
            }
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

        private void AddComplaintsComponentsToDashboardView()
        {
            List<Complaint> complaints = Complaint.Enumerate();

            complaintsFllPanel.Controls.Clear();

            foreach (Complaint complaint in complaints)
            {
                MiniComplaintComponent complaintComponent = new MiniComplaintComponent();
                complaintComponent.ChangeLabels(complaint.Title, complaint.Status);
                complaintsFllPanel.Controls.Add(complaintComponent);
            }
        }

        private void AddEventComponentsToTodayPanel()
        {
            List<Event> events = Event.Enumerate();
            if (events.Count == 0)
            {
                NoEventsAvailable eventComponent = new NoEventsAvailable();
                flowLayoutPanelToday.Controls.Add(eventComponent);
            }
            else
            {
                foreach (Event ev in events)
                {
                    DateTime startDate = Convert.ToDateTime(ev.StartsAt);
                    var date = startDate.Date;
                    var dateAndTime = DateTime.Now;
                    var dateNow = dateAndTime.Date;
                    EventComponent eventComponent = new EventComponent();
                    eventComponent.SetAllNeededProperties(ev.Id, ev.Creator, Server.CurrentSession, ev.Title, ev.Description, ev.Type, ev.StartsAt, ev.FinishesAt);
                    if (date == dateNow)
                    {
                        flowLayoutPanelToday.Controls.Add(eventComponent);
                    }
                    else
                    {
                        flowLayoutPanelUpcoming.Controls.Add(eventComponent);
                    }
                }
            }

        }

        private void AddExpenseToExpenseListView(Expense expense)
        {
            ExpensesLv.Items.Add(new ListViewItem(new string[] { expense.Name, expense.Amount.ToString(), expense.Price.ToString(), expense.Notes }));

        }

        private void AddMembersToExpenseListView(User participant)
        {
            MembersLv.Items.Add(new ListViewItem(new string[] { participant.FirstName, participant.ComputeBalance(Expense.Enumerate()).ToString() }));

        }
        private void CalculateAndPopulateExpenses()
        {
            MembersLv.Items.Clear();
            ExpensesLv.Items.Clear();

            HashSet<User> users = new HashSet<User>();
            HashSet<int> userIds = new HashSet<int>();

            decimal total = 0;
            foreach (Expense expense in Expense.Enumerate())
            {
                total += expense.Price * expense.Amount;
                AddExpenseToExpenseListView(expense);
                foreach (User participant in expense.Participants)
                {
                    if (!userIds.Contains(participant.Id))
                    {
                        users.Add(participant);
                        userIds.Add(participant.Id);
                    }
                }
            }

            foreach (User participant in users)
            {
                AddMembersToExpenseListView(participant);
            }

            ExpenseTotalPriceLbl.Text = total.ToString();
            if (total > 0)
            {
                ExpenseTotalPriceLbl.ForeColor = Color.Green;
            }
            else
            {
                ExpenseTotalPriceLbl.ForeColor = Color.Red;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            AddEventComponentsToTodayPanel();
            AddComplaintsComponentsToDashboardView();
            AddEventComponentAddParticipantToCreatedEvents();
            ReloadComplaints();
            ReloadAgreements();
            CalculateAndPopulateExpenses();
        }

        private void ReloadAgreements(){
            agreementsFlpnl.Controls.Clear();

            List<Agreement> agreements = Agreement.Enumerate();

            if (agreements.Count > 0) { 
                foreach (Agreement agreement in agreements)
                {
                    AgreementComponent agreementComponent = new AgreementComponent(agreement.Title, agreement.Description, agreement.Creator.FirstName,agreement.CreatedAt);
                    agreementsFlpnl.Controls.Add(agreementComponent);
                }
            }
            else
            {
                NoAgreements noAgreements = new NoAgreements();
                agreementsFlpnl.Controls.Add(noAgreements);
            }

        }

        private void ReloadComplaints()
        {
            List<Complaint> complaints = Complaint.Enumerate();
            complaintsFllpnl.Controls.Clear();

            if (complaints.Count > 0)
            {
                foreach (Complaint complaint in complaints)
                {
                    ComplaintsComponent complaintComponent = new ComplaintsComponent();
                    complaintComponent.ChangeLabels(complaint.Title, complaint.Description, complaint.Status, complaint.CreatedAt);
                    complaintsFllpnl.Controls.Add(complaintComponent);
                }
            }
            else
            {
                NoComplaints complaintComponent = new NoComplaints();
                NoComplaints complaintComponentDashboard = new NoComplaints();

                complaintsFllPanel.Controls.Add(complaintComponentDashboard);
                complaintsFllpnl.Controls.Add(complaintComponent);

                complaintsFllPanel.AutoScroll = false;
                complaintsFllpnl.AutoScroll = false;

            }
        }

        private void FileComplaintBttn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(titleTbx.Text))
            {
                MessageBox.Show("Please enter a title for your complaint");
                return;
            }

            if (String.IsNullOrEmpty(descriptionTbx.Text))
            {
                MessageBox.Show("Please enter a description for your complaint");
                return;
            }

            Complaint.Create(titleTbx.Text, descriptionTbx.Text, Server.CurrentSession);
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
            if (String.IsNullOrEmpty(ExpenseTitleTbx.Text))
            {
                MessageBox.Show("Please enter expense title");
                return;
            }

            string expenseTitle = ExpenseTitleTbx.Text;
            string expenseNotes = ExpenseNotesRtbx.Text;

            decimal expensePrice = 0;
            int expenseQuantity = 1;

            try
            {
                expensePrice = ExpensePriceNum.Value;
                expenseQuantity = Convert.ToInt32(ExpenseQuantityNum.Value);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a correct number");
                return;
            }

            Expense expense = Expense.Create(expenseTitle, expensePrice, expenseQuantity, expenseNotes, Server.CurrentSession);
            CalculateAndPopulateExpenses();
            MessageBox.Show("You successfully created the expense!");
        }

        private void NewAgreementBttn_Click(object sender, EventArgs e)
        {
            string description = agreementDescriprionTbx.Text;
            string title = agreementTitleTbx.Text;

            if (String.IsNullOrEmpty(description))
            {
                MessageBox.Show("Add description");
                return;
            }

            if (String.IsNullOrEmpty(title))
            {
                MessageBox.Show("Add title");
                return;
            }

            Agreement.Create(title, description, Server.CurrentSession);
            ReloadAgreements();
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
            List<Event> events = Event.Enumerate();
            if (events.Count == 0)
            {
                NoEventsAvailable eventComponent = new NoEventsAvailable();
                CreatedEventsFllpnl.Controls.Add(eventComponent);
            }
            else
            {
                foreach (Event ev in events)
                {
                    EventComponentAddParticipant eventComponent = new EventComponentAddParticipant();
                    eventComponent.SetAllNeededProperties(ev.Id, ev.Creator, Server.CurrentSession, ev.Title, ev.Description, ev.Type, ev.StartsAt, ev.FinishesAt);
                    if (eventComponent.Creator.Id == eventComponent.Session.Info.Id)
                    {
                        CreatedEventsFllpnl.Controls.Add(eventComponent);
                    }
                }
            }
        }
    }
}
