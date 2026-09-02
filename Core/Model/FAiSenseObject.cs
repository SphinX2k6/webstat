using System;
using UnrealEngine;

namespace CSharpScript.Core.Model
{
	// Token: 0x02007122 RID: 28962
	public struct FAiSenseObject
	{
		// Token: 0x04027570 RID: 161136
		public int AiSenseId;

		// Token: 0x04027571 RID: 161137
		public FVector2D AiSenseHorizontalAngle;

		// Token: 0x04027572 RID: 161138
		public FVector2D AiSenseVerticalAngle;

		// Token: 0x04027573 RID: 161139
		public bool AiSenseCantBeBlock;

		// Token: 0x04027574 RID: 161140
		public int AiSenseBlockType;

		// Token: 0x04027575 RID: 161141
		public bool WithAngleHorizontal;

		// Token: 0x04027576 RID: 161142
		public bool WithAngleVertical;

		// Token: 0x04027577 RID: 161143
		public float SenseDistanceRangeMin;

		// Token: 0x04027578 RID: 161144
		public float SenseDistanceRangeMax;

		// Token: 0x04027579 RID: 161145
		public float SquaredWalkSenseRate;

		// Token: 0x0402757A RID: 161146
		public float SquaredAirSenseRate;
	}
}
