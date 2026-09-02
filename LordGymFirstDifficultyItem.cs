using System;
using Aki.Config;

// Token: 0x020021FD RID: 8701
public class LordGymFirstDifficultyItem : LordGymDifficultyItem
{
	// Token: 0x060106B2 RID: 67250 RVA: 0x0047CC32 File Offset: 0x0047AE32
	protected override void SetLevelText(LordGym config)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), config.FirstGuideGymTitle, Array.Empty<object>());
	}

	// Token: 0x020084CA RID: 33994
	private class EComponent
	{
		// Token: 0x0402CFDB RID: 184283
		public const int LordToggle = 0;

		// Token: 0x0402CFDC RID: 184284
		public const int LevelText = 1;

		// Token: 0x0402CFDD RID: 184285
		public const int LockItem = 2;

		// Token: 0x0402CFDE RID: 184286
		public const int FinishItem = 3;

		// Token: 0x0402CFDF RID: 184287
		public const int RedDotItem = 4;
	}
}
