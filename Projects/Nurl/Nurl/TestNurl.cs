/*
 * Crée par SharpDevelop.
 * Utilisateur: erwan
 * Date: 26/05/2014
 * Heure: 15:50
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using NUnit.Framework;

namespace Nurl
{
	[TestFixture]
	public class TestNurl
	{
		[Test]
		public void Should_show_the_content_of_a_page()
		{
			string[] arguments = {"get", "-url", "http://api.openweathermap.org/data/2.5/weather?q=paris&units=metric"};
			//given
			Command c = new Command(arguments); 

    		//when
			UrlOperations uo = new UrlOperations(c);
			string result = uo.getContent(); 

    		//then
			Assert.AreEqual(uo.getContent(), "{\"coord\":{\"lon\":2.35,\"lat\":48.85},\"sys\":{\"message\":0.0063,\"country\":\"FR\",\"sunrise\":1401162895,\"sunset\":1401219641},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"base\":\"cmc stations\",\"main\":{\"temp\":13.93,\"humidity\":85,\"pressure\":1013.1,\"temp_min\":12.78,\"temp_max\":15},\"wind\":{\"speed\":6.92,\"deg\":276.501},\"rain\":{\"3h\":1},\"clouds\":{\"all\":92},\"dt\":1401184765,\"id\":2988507,\"name\":\"Paris\",\"cod\":200}" + "\n");
		}
		
		[Test]
		public void Should_save_the_content_of_a_page()
		{
			//given
			string[] arguments = {"get", "-url", "http://api.openweathermap.org/data/2.5/weather?q=paris&units=metric"};
    		Command c = new Command(arguments);

    		//when
    		UrlOperations uo = new UrlOperations(c);
			uo.saveContent();

    		//then
    		Assert.That("result", Is.EqualTo(""));
		}
		
		[Test]
		public void Should_show_the_loading_time_of_a_page_five_times()
		{
			//given
    		//var command = null; 

    		//when
    		//var result = command.Show(url); 

    		//then
    		Assert.That("result", Is.EqualTo(""));
		}
		
		[Test]
		public void Should_show_the_average_loading_time_of_a_page()
		{
			//given
    		//var command = null; 

    		//when
    		//var result = command.Show(url); 

    		//then
    		Assert.That("result", Is.EqualTo(""));
		}
	}
}
