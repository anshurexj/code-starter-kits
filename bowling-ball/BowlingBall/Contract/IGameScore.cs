using System.Collections.Generic;

namespace BowlingBall.Contract
{
    /* Summary: 
     * Author: Anshuman Jha
     * 
     * Syntactical contract to get final score of the game.

       i>   FinalGameScore method to give final score to the player.

    */

    public interface IGameScore
	{
		int FinalGameScore(List<IFrame> frames, List<int> rolls);
	}
}
