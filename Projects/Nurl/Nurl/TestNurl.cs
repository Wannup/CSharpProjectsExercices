﻿/*
 * Crée par SharpDevelop.
 * Utilisateur: erwan
 * Date: 26/05/2014
 * Heure: 15:50
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.IO;
using NUnit.Framework;

namespace Nurl
{
	[TestFixture]
	public class TestNurl
	{
		[Test]
		public void Should_show_the_content_of_a_page()
		{
			//given
			string[] arguments = {"get", "-url", "http://api.openweathermap.org/data/2.5/weather?q=paris&units=metric"};
			Command c = new Command(arguments); 

    		//when
			UrlOperations uo = new UrlOperations(c);
			string result = uo.getContent(); 

    		//then
			Assert.AreEqual(uo.getContent(), "{\"coord\":{\"lon\":2.35,\"lat\":48.85},\"sys\":{\"message\":0.0366,\"country\":\"FR\",\"sunrise\":1401162895,\"sunset\":1401219641},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"base\":\"cmc stations\",\"main\":{\"temp\":13.93,\"humidity\":85,\"pressure\":1013.1,\"temp_min\":12.78,\"temp_max\":15},\"wind\":{\"speed\":6.92,\"deg\":276.501},\"rain\":{\"3h\":1},\"clouds\":{\"all\":92},\"dt\":1401184765,\"id\":2988507,\"name\":\"Paris\",\"cod\":200}" + "\n");
		}
		
		[Test]
		public void Should_save_the_content_of_a_page()
		{
			//given
			string[] arguments = {"get", "-url", "http://api.openweathermap.org/data/2.5/weather?q=paris&units=metric", "-save", @"C:\Users\erwan\abc.json"};
    		Command c = new Command(arguments);

    		//when
    		UrlOperations uo = new UrlOperations(c);
			uo.saveContent();
			

			string line;
			string readFile = "";
			
			// Read the file
			System.IO.StreamReader file = new System.IO.StreamReader(c.getSave());
			while((line = file.ReadLine()) != null)
			{
			    readFile += line;
			}

			file.Close();

    		//then
			Assert.AreEqual(uo.getContent(), readFile + "\n");
		}
		
		[Test]
		public void Should_find_the_file_created()
		{
			//given
			string[] arguments = {"get", "-url", "http://api.openweathermap.org/data/2.5/weather?q=paris&units=metric", "-save", @"C:\Users\erwan\abc.json"};
    		Command c = new Command(arguments);

    		//when
    		UrlOperations uo = new UrlOperations(c);
			uo.saveContent();

    		//then
			Assert.AreEqual(File.Exists(c.getSave()), true);
		}
		
		[Test]
		public void Should_show_the_loading_time_of_a_page_five_times()
		{
			//given
			string[] arguments = {"test", "-url", "http://api.openweathermap.org/data/2.5/weather?q=paris&units=metric", "-times", "5"};
			Command c = new Command(arguments);

    		//when
    		UrlOperations uo = new UrlOperations(c);
			double[] times = uo.testLoadingTimeContent();
			
    		//then
			Assert.AreEqual(times.GetLength(0), c.getTime());
		}
		
		[Test]
		public void Should_show_the_average_loading_time_of_a_page()
		{
			//given
			string[] arguments = {"test", "-url", "http://api.openweathermap.org/data/2.5/weather?q=paris&units=metric", "-times", "5"};
			Command c = new Command(arguments);

    		//when
    		UrlOperations uo = new UrlOperations(c);
			double[] testTimes = {12,14,5,23,14};
			double times = uo.avg(testTimes); 

    		//then
    		Assert.AreEqual(times, 13.6);
		}
	}
}
