namespace Tarea2_SyP_Servidor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            arrancar = new Button();
            enviar = new Button();
            generarArchivo = new Button();
            textBox1 = new TextBox();
            mensajeEnvio = new TextBox();
            Apagar = new Button();
            textBox2 = new TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            SuspendLayout();
            // 
            // arrancar
            // 
            arrancar.BackColor = Color.FromArgb(128, 255, 128);
            arrancar.Location = new Point(12, 12);
            arrancar.Name = "arrancar";
            arrancar.Size = new Size(142, 23);
            arrancar.TabIndex = 0;
            arrancar.Text = "Arrancar Servidor";
            arrancar.UseVisualStyleBackColor = false;
            arrancar.Click += arrancar_Click;
            // 
            // enviar
            // 
            enviar.Location = new Point(169, 346);
            enviar.Name = "enviar";
            enviar.Size = new Size(302, 48);
            enviar.TabIndex = 1;
            enviar.Text = "enviar";
            enviar.UseVisualStyleBackColor = true;
            enviar.Click += enviar_Click;
            // 
            // generarArchivo
            // 
            generarArchivo.BackColor = Color.FromArgb(192, 192, 255);
            generarArchivo.Location = new Point(611, 279);
            generarArchivo.Name = "generarArchivo";
            generarArchivo.Size = new Size(177, 126);
            generarArchivo.TabIndex = 2;
            generarArchivo.Text = "Crear Prediccion";
            generarArchivo.UseVisualStyleBackColor = false;
            generarArchivo.Click += generarArchivo_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 41);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(776, 55);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // mensajeEnvio
            // 
            mensajeEnvio.Location = new Point(12, 279);
            mensajeEnvio.Multiline = true;
            mensajeEnvio.Name = "mensajeEnvio";
            mensajeEnvio.Size = new Size(593, 61);
            mensajeEnvio.TabIndex = 4;
            mensajeEnvio.TextChanged += mensajeEnvio_TextChanged;
            // 
            // Apagar
            // 
            Apagar.BackColor = Color.LightSalmon;
            Apagar.Location = new Point(713, 12);
            Apagar.Name = "Apagar";
            Apagar.Size = new Size(75, 23);
            Apagar.TabIndex = 5;
            Apagar.Text = "Apagar";
            Apagar.UseVisualStyleBackColor = false;
            Apagar.Click += Apagar_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 130);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(776, 118);
            textBox2.TabIndex = 6;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 414);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 7;
            label1.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(Apagar);
            Controls.Add(mensajeEnvio);
            Controls.Add(textBox1);
            Controls.Add(generarArchivo);
            Controls.Add(enviar);
            Controls.Add(arrancar);
            Name = "Form1";
            Text = "Servidor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button arrancar;
        private Button enviar;
        private Button generarArchivo;
        private TextBox textBox1;
        private TextBox mensajeEnvio;
        private Button Apagar;
        private TextBox textBox2;
        private System.Windows.Forms.Timer timer1;
        private Label label1;
    }
}
