using Xunit;
using System.IO;
using System;
using Moq;
using guessing_number;
using FluentAssertions;

namespace guessing_number.Test;

[Collection("Sequential")]
public class TestThirdReq
{
	[Theory(DisplayName = "Deve receber a executar o fluxo completo do programa")]
	[InlineData(new object[] {new string[]{"10"}, 10})]
	public void TestFullFlow(string[] entrys, int mockValue)
	{
		{   
			string expected = "ACERTOU!";
			using var stringWriter = new StringWriter();
			{   
				using var stringReader = new StringReader(String.Join("\n", entrys));
				{   
					Console.SetOut(stringWriter);
					Console.SetIn(stringReader);

					var guessingNumber = new GuessNumber();
					guessingNumber.randomValue = mockValue;

					do
					{
						guessingNumber.ChooseNumber();
						guessingNumber.AnalyzePlay();
					}
					while(guessingNumber.randomValue != guessingNumber.userValue);     

					var response = stringWriter.ToString().Trim().Split("\n");
					response[^1].Should().Contain(expected);
				}                            
			} 
		}
	}
}
