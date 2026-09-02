using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x02005656 RID: 22102
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueIllustratedTabData
	{
		// Token: 0x04020234 RID: 131636
		public ERogueHandbookType TabType;

		// Token: 0x04020235 RID: 131637
		public string Icon = "";

		// Token: 0x04020236 RID: 131638
		public string TabName = "";

		// Token: 0x04020237 RID: 131639
		public int Index = 1;

		// Token: 0x04020238 RID: 131640
		public RogueResTheme? Config;
	}
}
