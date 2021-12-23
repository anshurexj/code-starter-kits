using BowlingBall.Common;
using BowlingBall.Contract;
using System.Collections.Generic;

namespace BowlingBall
{
	/* Summary
	 * Author: Anshuman Jha
	 * 
	 * Class Implementing the syntactical contract of an individual frame.
     */

	public class Frame : IFrame
	{
		public int FrameScore()
		{
			int current_score = 0;

			//In a Frame Rolling Ball will be 1,2 and if its 10th Frame then 3 in Special Case

			if (RollingBall.Count <= 3 && RollingBall.Count > 0)
			{                                    
				foreach (var ball in RollingBall)   
                {
					current_score += ball;         //Score of this frame without bonus.
				}
				current_score += BonusScore;       //Score of this frame with bonus.
			}
			return current_score;
		}

		public FrameType GetFrameType()
		{
			FrameType frameType = FrameType.Open;
			int frame_pin_score = 0;

			if (RollingBall.Count > 0)
			{
				foreach(var ball in RollingBall)
                {
					frame_pin_score += ball;        //Pins made by 1st/2nd Ball for Type evaluation
				}

				if (RollingBall.Count == 1 && frame_pin_score == 10)
					frameType = FrameType.Strike;   //Fist Ball Score 10 makes it Strike.
				else if (RollingBall.Count == 2 && frame_pin_score == 10)
					frameType = FrameType.Spare;   //First + Second Ball Score 10 makes it Spare.
				else                               
					frameType = FrameType.Open;    //Normal

				//RollingBall.Count can also be 3 in Last Frame but 3rd Ball makes no difference.
			}
			return frameType;
		}

		public int Index { get; set; }

		public List<int> RollingBall { get; set; }

		public int BonusScore { get; set; }

	}
}