using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053B3 RID: 21427
	[NullableContext(1)]
	[Nullable(0)]
	public class SubtitleConfigProxy
	{
		// Token: 0x0401F799 RID: 128921
		public float StartTime;

		// Token: 0x0401F79A RID: 128922
		public float EndTime;

		// Token: 0x0401F79B RID: 128923
		public string OriginSubtitleId = "";

		// Token: 0x0401F79C RID: 128924
		public string TranslationSubtitleId = "";

		// Token: 0x0401F79D RID: 128925
		public bool HideTranslationSubtitle;
	}
}
