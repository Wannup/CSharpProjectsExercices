/*
 * Crée par SharpDevelop.
 * Utilisateur: erwan
 * Date: 27/05/2014
 * Heure: 10:50
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using CMDLine;

namespace Nurl
{
	/// <summary>
	/// Description of Command.
	/// </summary>
	public class Command
	{
		private UrlOperations uo;
		private CMDLineParser parser;
		private CMDLineParser.Option urlOpt;
		private CMDLineParser.Option saveOpt;
		private CMDLineParser.Option timesOpt;
		private CMDLineParser.Option avgOpt;
		private bool getOpt = false;
		private bool testOpt = false;
		private string[] args;
		
		public Command(string[] _args)
		{
			uo = new UrlOperations(this);
			args = _args;
			//create parser
			parser = new CMDLineParser();
			
			if(_args.Length != 0){
				urlOpt = parser.AddStringParameter("-url", "adress of the website", true);
				if("get".Equals(_args[0]) || "test".Equals(_args[0])){
					if("get".Equals(_args[0])){
						getOpt=true;
						saveOpt = parser.AddStringParameter("-save", "save the content of the website", false);
					}
					if("test".Equals(_args[0])){
						testOpt=true;
						timesOpt = parser.AddIntParameter("-times", "number of time to load the website", true);
						avgOpt = parser.AddBoolSwitch("-avg", "average time to load the website");
					}
					try{
						//parse the command line
						parser.Parse(args);
					} catch (CMDLineParser.CMDLineParserException ex){
						getHelp();
						Console.WriteLine("Error: " + ex.Message);
						return;
					}					
					//replace argument list with remaining arguments
					args = parser.RemainingArgs();
				} else {
					getHelp();
				  	Console.WriteLine("Error: Missing Required option: 'get' or 'set'");
				  	return;
				}
			}
		}
		
		public void execute(){
			
			if(getGet() && urlOpt.isMatched){
				// 1 - Affiche dans la console le contenu du fichier sité à l'url.
				if(getUrl().Length>0 && !saveOpt.isMatched){
					uo.getContent();
				}
				// 2 - Sauvegarde le contenu de l'url dans un fichier.
				if(getUrl().Length>0 && saveOpt.isMatched){
					uo.saveContent();
				}
			}
			if(getTest() && urlOpt.isMatched && timesOpt.Value != null){
				// 3 - Teste le temps de chargement du ficher à l'url 5 fois et affiche les resultats.
				if(urlOpt.isMatched && !avgOpt.isMatched){
					uo.testLoadingTimeContent();
				}
				// 4 - Teste le temps de chargement du fichier à l'url 5 fois et affiche la moyenne des 5.
				if(urlOpt.isMatched && timesOpt.isMatched && avgOpt.isMatched){
					uo.testAverageLoadingTimeContent();
				}
			}
		}
		
		public string getUrl(){
			return (string)urlOpt.Value;
		}
		
		public string getSave(){
			return (string)saveOpt.Value;
		}
		
		public int getTime(){
			return (int)timesOpt.Value;
		}
		
		public bool getAvg(){
			return (bool)avgOpt.isMatched;
		}
		
		public bool getGet(){
			return getOpt;
		}
		
		public bool getTest(){
			return testOpt;
		}
		
		public void getHelp(){
			Console.Write(parser.HelpMessage());
			Console.WriteLine();
		}
	}
}
