/*
 * Created by SharpDevelop.
 * User: Erwan
 * Date: 25/05/2014
 * Time: 17:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using CMDLine;

namespace Nurl
{
	class Program
	{
		public static void Main(string[] args)
		{	
			Command c = new Command(args);
			UrlOperations uo = new UrlOperations(c);
			
			// 1 - Affiche dans la console le contenu du fichier sité à l'url
			uo.getContent();
			
			// 2 -
			uo.saveContent();
			
			// 3 -
			uo.testLoadingTimeContent();
			
			// 4 -
			uo.testAverageLoadingTimeContent();
			
		}
	}
}