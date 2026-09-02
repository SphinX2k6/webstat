using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x0200648C RID: 25740
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorChallengePlayData
	{
		// Token: 0x17009E5C RID: 40540
		// (get) Token: 0x0604091E RID: 264478 RVA: 0x0108D000 File Offset: 0x0108B200
		public bool HasRedDot
		{
			get
			{
				return this.CheckRedDot(this.RewardIds.ToArray());
			}
		}

		// Token: 0x17009E5D RID: 40541
		// (get) Token: 0x0604091F RID: 264479 RVA: 0x0108D018 File Offset: 0x0108B218
		public bool IsFinished
		{
			get
			{
				return this.CheckFinished(this.RewardIds.ToArray());
			}
		}

		// Token: 0x0402421D RID: 147997
		public int TabIndex;

		// Token: 0x0402421E RID: 147998
		public int PlayId;

		// Token: 0x0402421F RID: 147999
		public int JumpId;

		// Token: 0x04024220 RID: 148000
		public string NameTextId = "";

		// Token: 0x04024221 RID: 148001
		public List<int> RewardIds = new List<int>();

		// Token: 0x04024222 RID: 148002
		public bool IsUnlock;

		// Token: 0x04024223 RID: 148003
		public bool IsNew;

		// Token: 0x04024224 RID: 148004
		public int HighestPoint;

		// Token: 0x04024225 RID: 148005
		public int ClassId;

		// Token: 0x04024226 RID: 148006
		public Func<int[], bool> CheckRedDot;

		// Token: 0x04024227 RID: 148007
		public Func<int[], bool> CheckFinished;
	}
}
