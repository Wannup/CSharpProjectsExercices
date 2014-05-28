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
		
		public double[] testLoadingTimeContent(){
			double[] elapsedTime = new double[c.getTime()];
			for(int i = 0; i<c.getTime(); i++){
				sw.Reset();
				sw.Start();
				client.DownloadString(c.getUrl());
				sw.Stop();			
				double ts = sw.ElapsedMilliseconds;
				elapsedTime[i] = ts;
				if(!c.getAvg()){
					Console.WriteLine(elapsedTime[i] + " ms");
				}
			}
			return elapsedTime;
		}
		
		public void testAverageLoadingTimeContent(){
			double[] times = testLoadingTimeContent();
			double averageTime = avg(times);
			Console.WriteLine(averageTime + " ms");
		}
		
		public double avg(double[] t){
			double moy, somme = 0;
			for(int i=0; i<t.Length; i++){
				somme=somme+t[i];
			}
			moy=somme/c.getTime();
			return moy;
		}
	}
}
