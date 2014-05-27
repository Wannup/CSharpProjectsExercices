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

namespace Nurl
{
	/// <summary>
	/// Description of GetUrl.
	/// </summary>
	public class UrlOperations
	{
		private WebClient client;
		private Command c;
		
		public UrlOperations(Command _c)
		{
			c = _c;
			client = new WebClient();
		}
		
		public string getContent(){
			string codeHtml = client.DownloadString(c.getUrl());
			display(codeHtml);	
			return codeHtml;						
		}
		
		public void saveContent(){

		}
		
		public void testLoadingTimeContent(){

		}
		
		public void testAverageLoadingTimeContent(){

		}
		
		public void display(string s){
			Console.WriteLine(s);
		}
	}
}
