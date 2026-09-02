using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004E9D RID: 20125
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenseRankPlayerName : ITowerDefenseRankPlayerName
	{
		// Token: 0x17008931 RID: 35121
		// (get) Token: 0x06034008 RID: 213000 RVA: 0x00D02440 File Offset: 0x00D00640
		// (set) Token: 0x06034009 RID: 213001 RVA: 0x00D02448 File Offset: 0x00D00648
		public int PlayerId { get; set; }

		// Token: 0x17008932 RID: 35122
		// (get) Token: 0x0603400A RID: 213002 RVA: 0x00D02451 File Offset: 0x00D00651
		// (set) Token: 0x0603400B RID: 213003 RVA: 0x00D02459 File Offset: 0x00D00659
		public string PlayerName { get; set; }
	}
}
