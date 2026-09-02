using System;

namespace CSharpScript.Game.Module.MovieMode
{
	// Token: 0x020056E7 RID: 22247
	public interface IMovieModeAspectOffset
	{
		// Token: 0x170090F4 RID: 37108
		// (get) Token: 0x060389F8 RID: 231928
		// (set) Token: 0x060389F9 RID: 231929
		bool IsFadeIn { get; set; }

		// Token: 0x170090F5 RID: 37109
		// (get) Token: 0x060389FA RID: 231930
		// (set) Token: 0x060389FB RID: 231931
		bool IsWidthBlend { get; set; }

		// Token: 0x170090F6 RID: 37110
		// (get) Token: 0x060389FC RID: 231932
		// (set) Token: 0x060389FD RID: 231933
		float Offset { get; set; }

		// Token: 0x170090F7 RID: 37111
		// (get) Token: 0x060389FE RID: 231934
		// (set) Token: 0x060389FF RID: 231935
		float Progress { get; set; }
	}
}
