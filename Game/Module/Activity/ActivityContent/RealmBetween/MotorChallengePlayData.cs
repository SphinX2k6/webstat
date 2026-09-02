using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x0200652F RID: 25903
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorChallengePlayData
	{
		// Token: 0x17009E9A RID: 40602
		// (get) Token: 0x06040C75 RID: 265333 RVA: 0x0109C481 File Offset: 0x0109A681
		public bool HasRedDot
		{
			get
			{
				return this.CheckRedDot(this.RewardIds.ToArray());
			}
		}

		// Token: 0x17009E9B RID: 40603
		// (get) Token: 0x06040C76 RID: 265334 RVA: 0x0109C499 File Offset: 0x0109A699
		public bool IsFinished
		{
			get
			{
				return this.CheckFinished(this.RewardIds.ToArray());
			}
		}

		// Token: 0x04024526 RID: 148774
		public int TabIndex;

		// Token: 0x04024527 RID: 148775
		public int PlayId;

		// Token: 0x04024528 RID: 148776
		public int JumpId;

		// Token: 0x04024529 RID: 148777
		public string NameTextId = "";

		// Token: 0x0402452A RID: 148778
		public List<int> RewardIds = new List<int>();

		// Token: 0x0402452B RID: 148779
		public bool IsUnlock;

		// Token: 0x0402452C RID: 148780
		public bool IsNew;

		// Token: 0x0402452D RID: 148781
		public int HighestPoint;

		// Token: 0x0402452E RID: 148782
		public int ClassId;

		// Token: 0x0402452F RID: 148783
		public Func<int[], bool> CheckRedDot;

		// Token: 0x04024530 RID: 148784
		public Func<int[], bool> CheckFinished;
	}
}
