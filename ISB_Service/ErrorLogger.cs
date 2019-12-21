using ISB_Service.Infrastructure;
using ISB_Service.Model.Log;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Threading;

namespace ISB_Service
{
    public partial class ErrorLogger : Form
    {
        private Service _Form { get; set; }

        public ErrorLogger(Service _form)
        {
            InitializeComponent();

            _Form = _form;

            SynchronizationContext context = SynchronizationContext.Current;

            Task.Run(async() =>
            {
                IEnumerable<Logs> Logs = (await DatabaseProvider.GetDataListAsync<Logs>())
                                .OrderByDescending(x => x.LoggedOnDate).ToList();

                context.Post((x) =>
                {
                    errorLoggerGrid.DataSource = Logs;

                    errorLoggerGrid.Columns["LogId"].Visible = false;
                    errorLoggerGrid.Columns["HasBeenSeen"].Visible = false;

                    for (int i = 0; i < errorLoggerGrid.Columns.Count; i++)
                    {
                        errorLoggerGrid.Columns[i].Width = 159;
                    }

                },null);

                await DatabaseProvider.
                    UpdateDataAsync<Logs>(x => x.HasBeenSeen == false, x => x.HasBeenSeen, true);
            });
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Dispose();

            _Form.lblError.Padding = new Padding(0);
            _Form.lblError.Text = "";
           
            _Form.Show();
        }

        private void ErrorLogger_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Form.Close();
        }    

        private void errorLoggerGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in errorLoggerGrid.Rows)
            {
                bool? HasBeenSeen = Convert.ToBoolean(row.Cells["HasBeenSeen"].Value);

                if (HasBeenSeen==false || HasBeenSeen == null)
                    row.DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void errorLoggerGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0&&e.ColumnIndex>=0)
            {
                object value = errorLoggerGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                MessageBox.Show(value.ToString());
            }


        }
    }
}
