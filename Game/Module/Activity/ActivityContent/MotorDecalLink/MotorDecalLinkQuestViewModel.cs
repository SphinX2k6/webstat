using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorDecalLink
{
	// Token: 0x020066FC RID: 26364
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorDecalLinkQuestViewModel
	{
		// Token: 0x04024B5B RID: 150363
		public int TaskId;

		// Token: 0x04024B5C RID: 150364
		public int IpId;

		// Token: 0x04024B5D RID: 150365
		public int ActivityId;

		// Token: 0x04024B5E RID: 150366
		public int Current;

		// Token: 0x04024B5F RID: 150367
		public int Target = 1;

		// Token: 0x04024B60 RID: 150368
		public EActivityTaskState Status = EActivityTaskState.Active;

		// Token: 0x04024B61 RID: 150369
		public string TaskName = "";

		// Token: 0x04024B62 RID: 150370
		public Dictionary<int, int> RewardInfo = new Dictionary<int, int>();

		// Token: 0x04024B63 RID: 150371
		public int AccessId;
	}
}
