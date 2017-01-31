/*
 * Created by SharpDevelop.
 * User: SoporteSEM
 * Date: 10/01/2017
 * Time: 11:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Threading.Tasks;
using System.IO.Ports;
using System.ComponentModel;
using MetroFramework.Components;
using MetroFramework.Fonts;
using MetroFramework.Forms;



namespace Test_UI
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : MetroForm
	{


		CancellationTokenSource tokenSource;
		
		public MainForm()
		{
			
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		private void Form1_Resize(object sender, EventArgs e)
		{
			//if the form is minimized
			//hide it from the task bar
			//and show the system tray icon (represented by the NotifyIcon control)
			if (this.WindowState == FormWindowState.Minimized)
			{
				Hide();
				notifyIcon1.Visible = true;
			}
		}
		
		async Task procesar(CancellationToken token){

			int j=0;
			MessageBox.Show("INICIO_TASK");
			for(double i =0;i<100000000;i++){
				j++;
				j--;
				if (token.IsCancellationRequested)
				{
					token.ThrowIfCancellationRequested();
				}
				await Task.Delay(100);

			}
			
			MessageBox.Show("FIN_TASK");
			
		}

		


		void NotifyIcon1MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Show();
			this.WindowState = FormWindowState.Normal;
			notifyIcon1.Visible = false;
		}
		void MainFormResize(object sender, EventArgs e)
		{
			//if the form is minimized
			//hide it from the task bar
			//and show the system tray icon (represented by the NotifyIcon control)
			if (this.WindowState == FormWindowState.Minimized)
			{
				Hide();
				notifyIcon1.Visible = true;
			}
		}
		
		

		
		async void StartClick(object sender, EventArgs e)
		{

			tokenSource = new CancellationTokenSource();
			CancellationToken token = tokenSource.Token;
			
			try{
				
				
				await procesar(token);
				
			}
			catch (OperationCanceledException)
			{
				MessageBox.Show("TAREA CANCELADA");
			}
			

			
			MessageBox.Show("FIN2_TASK");
		}
		
		/*
		async void StartClick(object sender, EventArgs e)
		{

			


			
			
			
			
			tokenSource = new CancellationTokenSource();
			CancellationToken token = tokenSource.Token;
			
			try{
			await Task.Run(() =>
			               {
			               	int j=0;
			               	MessageBox.Show("INICIO_TASK");
			               	for(double i =0;i<100000000;i++){
			               		j++;
			               		j--;
			               		if (token.IsCancellationRequested)
			               		{
			               			token.ThrowIfCancellationRequested();
			               			
			               			
			               		}
			               	}
			               	MessageBox.Show("FIN_TASK");
			               }, token);
			
			}
			catch (OperationCanceledException)
			{
				MessageBox.Show("TAREA CANCELADA");
			}
			

			
			MessageBox.Show("FIN2_TASK");
		}
		 */
		
		void StopClick(object sender, EventArgs e)
		{
			if (tokenSource != null)
			{
				tokenSource.Cancel();
			}
		}
		void MainFormLoad(object sender, EventArgs e)
		{

			
			
		}
	}
	

	
}
