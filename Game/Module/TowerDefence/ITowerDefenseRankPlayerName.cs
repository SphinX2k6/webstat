using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004E9C RID: 20124
	[NullableContext(1)]
	public interface ITowerDefenseRankPlayerName
	{
		// Token: 0x1700892F RID: 35119
		// (get) Token: 0x06034004 RID: 212996
		// (set) Token: 0x06034005 RID: 212997
		int PlayerId { get; set; }

		// Token: 0x17008930 RID: 35120
		// (get) Token: 0x06034006 RID: 212998
		// (set) Token: 0x06034007 RID: 212999
		string PlayerName { get; set; }
	}
}
