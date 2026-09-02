using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.NewbieMain
{
	// Token: 0x02006648 RID: 26184
	public class NewbieMainTabItemData
	{
		// Token: 0x0402490E RID: 149774
		[Nullable(1)]
		public NewbieMainTabData TabData;

		// Token: 0x0402490F RID: 149775
		public NewbieMainActTab TabConfig;

		// Token: 0x04024910 RID: 149776
		public NewbieMainActTask? ProgressingTask;

		// Token: 0x04024911 RID: 149777
		public int ProgressingQuestId;

		// Token: 0x04024912 RID: 149778
		public ENewbieMainTabState State;

		// Token: 0x04024913 RID: 149779
		public bool IsNew;
	}
}
