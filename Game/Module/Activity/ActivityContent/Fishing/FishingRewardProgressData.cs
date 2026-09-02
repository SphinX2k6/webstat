using System;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006782 RID: 26498
	public class FishingRewardProgressData
	{
		// Token: 0x060420FF RID: 270591 RVA: 0x010F32BC File Offset: 0x010F14BC
		public FishingRewardProgressData(int id, int goal)
		{
			this.Id = id;
			this.Goal = goal;
		}

		// Token: 0x06042100 RID: 270592 RVA: 0x010F32D2 File Offset: 0x010F14D2
		public bool IsFulfilled()
		{
			return this.State == SignState.Unlock || this.State == SignState.IsReceive;
		}

		// Token: 0x06042101 RID: 270593 RVA: 0x010F32E8 File Offset: 0x010F14E8
		public bool IsReceivable()
		{
			return this.State == SignState.Unlock;
		}

		// Token: 0x06042102 RID: 270594 RVA: 0x010F32F3 File Offset: 0x010F14F3
		public bool IsDone()
		{
			return this.State == SignState.IsReceive;
		}

		// Token: 0x04024D3A RID: 150842
		public int Id;

		// Token: 0x04024D3B RID: 150843
		public int Goal;

		// Token: 0x04024D3C RID: 150844
		public SignState State;
	}
}
