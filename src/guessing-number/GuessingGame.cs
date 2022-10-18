using System;

namespace guessing_number;

public class GuessNumber
{    
	private IRandomGenerator random;    
	public GuessNumber() : this(new DefaultRandom()){}
	public GuessNumber(IRandomGenerator obj)
	{
		this.random = obj;
	}

	//user variables
	public string? response;
	public int userValue;
	public int randomValue;


	public void Greet()
	{
		Console.WriteLine("---Bem-vindo ao Guessing Game---");
		Console.WriteLine("Para começar, tente adivinhar o número que eu pensei, entre -100 e 100!");
	}

	public void ChooseNumber()
	{
		var isParsable = false;
		do{
			response = Console.ReadLine();
			isParsable = int.TryParse(response, out userValue) && (userValue > -100 && userValue < 100);
			if(!isParsable) Console.WriteLine("Por favor, digite um número inteiro:");
		} while (!isParsable);
	}

	public void RandomNumber()
	{
		throw new NotImplementedException();
	}

	public void AnalyzePlay()
	{
		throw new NotImplementedException();
	}
}
