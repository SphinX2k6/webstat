using System;

namespace CSharpScript.Game.World.Define
{
	// Token: 0x020046DF RID: 18143
	[Flags]
	public enum EWaitEntityPreloadResult
	{
		// Token: 0x0401AE2E RID: 110126
		None = 0,
		// Token: 0x0401AE2F RID: 110127
		Fail = 1,
		// Token: 0x0401AE30 RID: 110128
		Timeout = 2,
		// Token: 0x0401AE31 RID: 110129
		Cancel = 4,
		// Token: 0x0401AE32 RID: 110130
		Finished = 8
	}
}
