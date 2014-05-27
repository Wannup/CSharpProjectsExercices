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
		private CMDLineParser.Option urlOpt;
		private CMDLineParser.Option saveOpt;
		private CMDLineParser.Option timesOpt;
		private CMDLineParser.Option avgOpt;
		private bool getOpt;
		private bool testOpt;
		
		public Command(string[] args)
		{
			//create parser
			CMDLineParser parser = new CMDLineParser();
			
			//add Options to parse
			urlOpt = parser.AddStringParameter("-url", "adress of the website", true);
			saveOpt = parser.AddStringParameter("-save", "save the content of the website", false);
			timesOpt = parser.AddIntParameter("-times", "number of time to load the website", false);
			avgOpt = parser.AddBoolSwitch("-avg", "average time to load the website");
			
			if(args.Length != 0){
				if("get".Equals(args[0]) || "test".Equals(args[0])){
					if("get".Equals(args[0])){
						getOpt=true;
					}
					if("test".Equals(args[0])){
						testOpt=true;
					}
					
					try{
					  //parse the command line
					  parser.Parse(args);
					} catch (CMDLineParser.CMDLineParserException ex){
					  //show available options      
					  Console.Write(parser.HelpMessage());
					  Console.WriteLine();
					  Console.WriteLine("Error: " + ex.Message);
					  return;
					}					
					//replace argument list with remaining arguments
					args = parser.RemainingArgs();
				} else {
					Console.Write(parser.HelpMessage());
				  	Console.WriteLine();
				  	Console.WriteLine("Error: Missing Required option: 'get' or 'set'");
				  	return;
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
			return (bool)avgOpt.Value;
		}
		
		public bool getGet(){
			return getOpt;
		}
		
		public bool getTest(){
			return testOpt;
		}
		
	}
}
