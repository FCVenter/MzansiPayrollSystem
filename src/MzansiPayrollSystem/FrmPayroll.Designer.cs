namespace MzansiPayrollSystem;

partial class FrmPayroll
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private System.Windows.Forms.Label lblHeading;
    private System.Windows.Forms.Label lblContractorName;
    private System.Windows.Forms.Label lblHoursWorked;
    private System.Windows.Forms.Label lblDependents;
    private System.Windows.Forms.TextBox txtContractorName;
    private System.Windows.Forms.TextBox txtHoursWorked;
    private System.Windows.Forms.TextBox txtDependents;

    private System.Windows.Forms.Label lblGrossPay;
    private System.Windows.Forms.Label lblPaye;
    private System.Windows.Forms.Label lblUif;
    private System.Windows.Forms.Label lblMembership;
    private System.Windows.Forms.Label lblTotalDeductions;
    private System.Windows.Forms.Label lblNetPay;

    private System.Windows.Forms.TextBox txtGrossPay;
    private System.Windows.Forms.TextBox txtPaye;
    private System.Windows.Forms.TextBox txtUif;
    private System.Windows.Forms.TextBox txtMembership;
    private System.Windows.Forms.TextBox txtTotalDeductions;
    private System.Windows.Forms.TextBox txtNetPay;

    private System.Windows.Forms.Button btnCalculate;
    private System.Windows.Forms.Button btnReset;
    private System.Windows.Forms.Button btnExit;

    private void InitializeComponent()
    {
        this.lblHeading = new System.Windows.Forms.Label();
        this.lblContractorName = new System.Windows.Forms.Label();
        this.lblHoursWorked = new System.Windows.Forms.Label();
        this.lblDependents = new System.Windows.Forms.Label();
        this.txtContractorName = new System.Windows.Forms.TextBox();
        this.txtHoursWorked = new System.Windows.Forms.TextBox();
        this.txtDependents = new System.Windows.Forms.TextBox();

        this.lblGrossPay = new System.Windows.Forms.Label();
        this.lblPaye = new System.Windows.Forms.Label();
        this.lblUif = new System.Windows.Forms.Label();
        this.lblMembership = new System.Windows.Forms.Label();
        this.lblTotalDeductions = new System.Windows.Forms.Label();
        this.lblNetPay = new System.Windows.Forms.Label();

        this.txtGrossPay = new System.Windows.Forms.TextBox();
        this.txtPaye = new System.Windows.Forms.TextBox();
        this.txtUif = new System.Windows.Forms.TextBox();
        this.txtMembership = new System.Windows.Forms.TextBox();
        this.txtTotalDeductions = new System.Windows.Forms.TextBox();
        this.txtNetPay = new System.Windows.Forms.TextBox();

        this.btnCalculate = new System.Windows.Forms.Button();
        this.btnReset = new System.Windows.Forms.Button();
        this.btnExit = new System.Windows.Forms.Button();

        this.SuspendLayout();

        var headingFont = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
        var labelFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        var inputFont = new System.Drawing.Font("Segoe UI", 10F);
        var buttonFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        var labelForeColor = System.Drawing.Color.White;
        var inputBackColor = System.Drawing.Color.White;

        // lblHeading
        this.lblHeading.AutoSize = false;
        this.lblHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.lblHeading.Dock = System.Windows.Forms.DockStyle.Top;
        this.lblHeading.Height = 70;
        this.lblHeading.Font = headingFont;
        this.lblHeading.ForeColor = labelForeColor;
        this.lblHeading.Text = "Mzansi Tech Contractors";

        // Input column
        ConfigureInputLabel(this.lblContractorName, "Contractor Name", 30, 110, labelFont, labelForeColor);
        ConfigureInputLabel(this.lblHoursWorked, "Hours Worked", 30, 160, labelFont, labelForeColor);
        ConfigureInputLabel(this.lblDependents, "Number of Dependents", 30, 210, labelFont, labelForeColor);

        ConfigureInputBox(this.txtContractorName, 210, 107, 220, inputFont, inputBackColor);
        ConfigureInputBox(this.txtHoursWorked, 210, 157, 220, inputFont, inputBackColor);
        ConfigureInputBox(this.txtDependents, 210, 207, 220, inputFont, inputBackColor);

        // Output column
        ConfigureInputLabel(this.lblGrossPay, "Gross Pay:", 480, 110, labelFont, labelForeColor);
        ConfigureInputLabel(this.lblPaye, "PAYE Deduction:", 480, 150, labelFont, labelForeColor);
        ConfigureInputLabel(this.lblUif, "UIF Deduction:", 480, 190, labelFont, labelForeColor);
        ConfigureInputLabel(this.lblMembership, "Membership Fee:", 480, 230, labelFont, labelForeColor);
        ConfigureInputLabel(this.lblTotalDeductions, "Total Deductions:", 480, 270, labelFont, labelForeColor);
        ConfigureInputLabel(this.lblNetPay, "Net Pay:", 480, 310, labelFont, labelForeColor);

        ConfigureOutputBox(this.txtGrossPay, 650, 107, inputFont);
        ConfigureOutputBox(this.txtPaye, 650, 147, inputFont);
        ConfigureOutputBox(this.txtUif, 650, 187, inputFont);
        ConfigureOutputBox(this.txtMembership, 650, 227, inputFont);
        ConfigureOutputBox(this.txtTotalDeductions, 650, 267, inputFont);
        ConfigureOutputBox(this.txtNetPay, 650, 307, inputFont);

        // Buttons
        this.btnCalculate.Text = "Calculate Net Pay";
        this.btnCalculate.Location = new System.Drawing.Point(60, 280);
        this.btnCalculate.Size = new System.Drawing.Size(140, 40);
        this.btnCalculate.Font = buttonFont;
        this.btnCalculate.BackColor = System.Drawing.SystemColors.Control;
        this.btnCalculate.Click += this.OnCalculateClick;

        this.btnReset.Text = "Reset";
        this.btnReset.Location = new System.Drawing.Point(215, 280);
        this.btnReset.Size = new System.Drawing.Size(100, 40);
        this.btnReset.Font = buttonFont;
        this.btnReset.BackColor = System.Drawing.SystemColors.Control;
        this.btnReset.Click += this.OnResetClick;

        this.btnExit.Text = "Exit";
        this.btnExit.Location = new System.Drawing.Point(330, 280);
        this.btnExit.Size = new System.Drawing.Size(100, 40);
        this.btnExit.Font = buttonFont;
        this.btnExit.BackColor = System.Drawing.SystemColors.Control;
        this.btnExit.Click += this.OnExitClick;

        // Form
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(900, 380);
        this.BackColor = System.Drawing.Color.FromArgb(20, 30, 130);
        this.Text = "Mzansi Tech Contractors Payroll System";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;

        this.Controls.Add(this.lblHeading);
        this.Controls.Add(this.lblContractorName);
        this.Controls.Add(this.lblHoursWorked);
        this.Controls.Add(this.lblDependents);
        this.Controls.Add(this.txtContractorName);
        this.Controls.Add(this.txtHoursWorked);
        this.Controls.Add(this.txtDependents);
        this.Controls.Add(this.lblGrossPay);
        this.Controls.Add(this.lblPaye);
        this.Controls.Add(this.lblUif);
        this.Controls.Add(this.lblMembership);
        this.Controls.Add(this.lblTotalDeductions);
        this.Controls.Add(this.lblNetPay);
        this.Controls.Add(this.txtGrossPay);
        this.Controls.Add(this.txtPaye);
        this.Controls.Add(this.txtUif);
        this.Controls.Add(this.txtMembership);
        this.Controls.Add(this.txtTotalDeductions);
        this.Controls.Add(this.txtNetPay);
        this.Controls.Add(this.btnCalculate);
        this.Controls.Add(this.btnReset);
        this.Controls.Add(this.btnExit);

        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private static void ConfigureInputLabel(System.Windows.Forms.Label label, string text, int x, int y, System.Drawing.Font font, System.Drawing.Color foreColor)
    {
        label.AutoSize = true;
        label.Location = new System.Drawing.Point(x, y);
        label.Text = text;
        label.Font = font;
        label.ForeColor = foreColor;
        label.BackColor = System.Drawing.Color.Transparent;
    }

    private static void ConfigureInputBox(System.Windows.Forms.TextBox box, int x, int y, int width, System.Drawing.Font font, System.Drawing.Color backColor)
    {
        box.Location = new System.Drawing.Point(x, y);
        box.Size = new System.Drawing.Size(width, 25);
        box.Font = font;
        box.BackColor = backColor;
    }

    private static void ConfigureOutputBox(System.Windows.Forms.TextBox box, int x, int y, System.Drawing.Font font)
    {
        box.Location = new System.Drawing.Point(x, y);
        box.Size = new System.Drawing.Size(170, 25);
        box.Font = font;
        box.ReadOnly = true;
        box.BackColor = System.Drawing.Color.White;
        box.TabStop = false;
    }
}
