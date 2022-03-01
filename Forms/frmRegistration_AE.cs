using CentralApplication.Classes;
using CentralApplication.Entities;
using CentralApplication.Entities.Enumerations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CentralApplication.Forms
{
    public partial class frmRegistration_AE : Form
    {
        long id;
        User user;
        FormStatus formStatus;

        public frmRegistration_AE(User user,FormStatus formStatus,long id)
        {
            InitializeComponent();

            this.id = id;
            this.user = user;
            this.formStatus = formStatus;
        }

        private void frmRegistration_AE_Load(object sender, EventArgs e)
        {
            if(this.formStatus != FormStatus.FORM_ADD)
            {
                MessageBox.Show("Only New Registration is implemented in this current version!","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
                this.Close();
            }
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var bookletCount = Convert.ToInt32(this.txtBookletCount.Value);
            var registration = new Registration()
            {
                BookletCount = bookletCount,
                CompanyType = CompanyType.COSMOS,
                DocumentType = this.rbLPA.Checked ? DocumentType.LPA : DocumentType.PR,
                User = this.user
            };


            var tmpStartingIndex = Registration.findLastSequenceRegistered(registration.DocumentType);
            var documents = Enumerable.Range(1, bookletCount)
                            .Select(i =>
                            {
                                var document = new Document()
                                {
                                    Registration = registration,
                                    SequenceFrom = tmpStartingIndex + 1,
                                    SequenceTo = tmpStartingIndex + 50
                                };

                                tmpStartingIndex = document.SequenceTo;
                                return document;
                            }
                            ).ToList();
            registration.Documents = documents;

            if (this.formStatus == FormStatus.FORM_ADD)
            {
                var result = FormHelper<Registration>.formSave(registration, new RegistrationValidator());
                if (result) this.Dispose();  this.Close();
            }
        }
    }

    class RegistrationValidator : AbstractValidator<Registration>
    {
        public RegistrationValidator()
        {
            RuleFor(p => p.BookletCount)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be empty.")
                .GreaterThan(0)
                .WithMessage("{PropertyName} cannot be less than 1");
            RuleFor(p => p.DocumentType)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be empty")
                .NotNull()
                .WithMessage("{PropertyName} cannot be null");
        }
    }
}
