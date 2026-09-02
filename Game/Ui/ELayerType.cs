using System;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049E2 RID: 18914
	[Flags]
	public enum ELayerType
	{
		// Token: 0x0401CC54 RID: 117844
		HUD = 1,
		// Token: 0x0401CC55 RID: 117845
		Normal = 2,
		// Token: 0x0401CC56 RID: 117846
		Plot = 4,
		// Token: 0x0401CC57 RID: 117847
		ScreenEffect = 8,
		// Token: 0x0401CC58 RID: 117848
		NormalMask = 16,
		// Token: 0x0401CC59 RID: 117849
		BattleFloat = 32,
		// Token: 0x0401CC5A RID: 117850
		Pop = 64,
		// Token: 0x0401CC5B RID: 117851
		Float = 128,
		// Token: 0x0401CC5C RID: 117852
		Guide = 256,
		// Token: 0x0401CC5D RID: 117853
		Loading = 512,
		// Token: 0x0401CC5E RID: 117854
		NetWork = 1024,
		// Token: 0x0401CC5F RID: 117855
		CG = 2048,
		// Token: 0x0401CC60 RID: 117856
		Mask = 4096,
		// Token: 0x0401CC61 RID: 117857
		WaterMask = 8192,
		// Token: 0x0401CC62 RID: 117858
		Pool = 16384,
		// Token: 0x0401CC63 RID: 117859
		Debug = 32768
	}
}
