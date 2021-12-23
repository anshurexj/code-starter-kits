using BowlingBall.Contract;
using System.Collections.Generic;

namespace BowlingBall.BusinessLogic
{
	/* Summary
	 * Author: Anshuman Jha
	 *
	 * Class Implementing the syntactical contract of an GameFrame.	   
	*/

	public class GameFrame : IGameFrame
	{
		public List<IFrame> GetAllFrames(int frame_count) 
		{
			List<IFrame> frames = new List<IFrame>();     //Frame Set.

			for (int i = 1; i <= frame_count ; i++)
			{
                var individual_frame = new Frame
                {
                    Index = i,                            //Each Frame having a Index Set.
                    RollingBall = new List<int>()         //Having Ball rolled aginst pins.
                };
                frames.Add(individual_frame);             //Grame Set for Game Play.
			}
			return frames;
		}
	}
}
