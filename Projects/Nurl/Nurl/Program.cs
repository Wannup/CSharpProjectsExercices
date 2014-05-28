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
			c.execute();
		}
	}
}