using System;

namespace CSharpScript.Game.Module.GameMainView.TrapDefense
{
	// Token: 0x02005D06 RID: 23814
	[Flags]
	public enum ETrapDefenseBuildTipsType
	{
		// Token: 0x04021BA2 RID: 138146
		None = 0,
		// Token: 0x04021BA3 RID: 138147
		Build = 1,
		// Token: 0x04021BA4 RID: 138148
		Rotate = 2,
		// Token: 0x04021BA5 RID: 138149
		Recycle = 4,
		// Token: 0x04021BA6 RID: 138150
		Pollute = 8,
		// Token: 0x04021BA7 RID: 138151
		Disable = 16
	}
}
