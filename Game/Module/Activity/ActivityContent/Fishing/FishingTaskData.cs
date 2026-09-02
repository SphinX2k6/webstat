using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006786 RID: 26502
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingTaskData
	{
		// Token: 0x04024D44 RID: 150852
		public int TaskId;

		// Token: 0x04024D45 RID: 150853
		public EActivityTaskState Status = EActivityTaskState.Active;

		// Token: 0x04024D46 RID: 150854
		public int JumpId;

		// Token: 0x04024D47 RID: 150855
		public int Current;

		// Token: 0x04024D48 RID: 150856
		public int Target;

		// Token: 0x04024D49 RID: 150857
		public string TitleTextId = "";

		// Token: 0x04024D4A RID: 150858
		public List<TItem> RewardList = new List<TItem>();

		// Token: 0x04024D4B RID: 150859
		[Nullable(2)]
		public Action<int> ReceiveDelegate;
	}
}
