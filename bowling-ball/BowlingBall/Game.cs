using BowlingBall.Contract;
using System.Collections.Generic;
using BowlingBall.BusinessLogic;

namespace BowlingBall
{
	/* Summary
	 * Author: Anshuman Jha
	  
	 * Special Requirement:
	   i>   No need to check for valid rolls.
	   ii>  No need to check for correct number of rolls & frames.
	   iii> No need to provide intermediate frame score.
	   iv>  No need to prevent bad input data.
	  
	 * Solution:
	   Game.cs file is the actual class that class libraray consumer will be using.
  
	   i>  2 Game Constructors created for normal Dependency Injection & for Test Project to Inject Dependency.

       ii> Roll method to register a roll made by player.

       iii>GetScore method to get the final game score based on frames played, for our game play frames will be 10. 
     
	 */
	public class Game
	{
		private readonly List<IFrame> frames;
		private readonly IGameScore gameScore;
		private readonly List<int> rolls;

		public Game()  
			: this(new GameFrame(), new GameScore()){ }  

		public Game(IGameFrame gameframe, IGameScore score)
		{
			frames = gameframe.GetAllFrames();
			gameScore = score;
			rolls = new List<int>();
		}

		public void Roll(int pins)
		{
			rolls.Add(pins);
		}

		public int GetScore()
		{
			return gameScore.FinalGameScore(frames, rolls);
		}

	}
}
