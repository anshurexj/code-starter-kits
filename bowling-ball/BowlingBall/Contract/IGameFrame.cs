using System.Collections.Generic;

namespace BowlingBall.Contract
{
	/* Summary: 
	 * Author: Anshuman Jha
	 * 
	 * Special Requirement:
	   Correct number of rolls and frames are not needed to be checked.

	 * Syntactical contract to get all the frames required for a game play.
  
       i>   GetAllFrames to give player all frames for a game play.

	 * Note:
	   frame_count is optional parameter since for our game play its 10 everytime and we are not restricting frame numbers.

	*/

	public interface IGameFrame
	{
		List<IFrame> GetAllFrames(int frame_count = 10);
	}
}
