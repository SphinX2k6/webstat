using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D38 RID: 23864
	[NullableContext(1)]
	[Nullable(0)]
	public class FlagChallengeBuffAddItemData : IFlagChallengeBuffAddItemData
	{
		// Token: 0x17009893 RID: 39059
		// (get) Token: 0x0603C2EF RID: 246511 RVA: 0x00F42BE7 File Offset: 0x00F40DE7
		// (set) Token: 0x0603C2F0 RID: 246512 RVA: 0x00F42BEF File Offset: 0x00F40DEF
		public string IconPath { get; set; }

		// Token: 0x17009894 RID: 39060
		// (get) Token: 0x0603C2F1 RID: 246513 RVA: 0x00F42BF8 File Offset: 0x00F40DF8
		// (set) Token: 0x0603C2F2 RID: 246514 RVA: 0x00F42C00 File Offset: 0x00F40E00
		public string NameKey { get; set; }

		// Token: 0x17009895 RID: 39061
		// (get) Token: 0x0603C2F3 RID: 246515 RVA: 0x00F42C09 File Offset: 0x00F40E09
		// (set) Token: 0x0603C2F4 RID: 246516 RVA: 0x00F42C11 File Offset: 0x00F40E11
		public string Value { get; set; }
	}
}
