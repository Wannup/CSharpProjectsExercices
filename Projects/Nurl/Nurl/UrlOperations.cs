/*
 * Crée par SharpDevelop.
 * Utilisateur: erwan
 * Date: 27/05/2014
 * Heure: 10:10
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Net;
using System.Diagnostics;

namespace Nurl
{
	/// <summary>
	/// Description of GetUrl.
	/// </summary>
	public class UrlOperations
	{
		private WebClient client;
		private Command c;
		private Stopwatch sw;
		
		public UrlOperations(Command _c)
		{
			c = _c;
			client = new WebClient();
			sw = new Stopwatch();
		}
		
		public string getContent(){
			string codeHtml = client.DownloadString(c.getUrl());
			Console.WriteLine(codeHtml);	
			return codeHtml;						
		}
		
		public void saveContent(){
			client.DownloadFile(c.getUrl(), c.getSave());
		}
		
		public string[] testLoadingTimeContent(){
			string[] elapsedTime = new string[c.getTime()];
			for(int i = 0; i<c.getTime(); i++){
				sw.Reset();
				sw.Start();
				client.DownloadString(c.getUrl());
				sw.Stop();			
				TimeSpan ts = sw.Elapsed;
				elapsedTime[i] = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",ts.Hours, ts.Minutes, ts.Seconds,ts.Milliseconds / 10);		
				Console.WriteLine(elapsedTime[i]);
			}
			return elapsedTime;
		}
		
		public void testAverageLoadingTimeContent(){
			Console.WriteLine("avg");
		}
	}
}
