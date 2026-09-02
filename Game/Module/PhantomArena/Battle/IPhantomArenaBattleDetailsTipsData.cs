using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle
{
	// Token: 0x0200559C RID: 21916
	[NullableContext(1)]
	public interface IPhantomArenaBattleDetailsTipsData
	{
		// Token: 0x17008FB1 RID: 36785
		// (get) Token: 0x06037C91 RID: 228497
		// (set) Token: 0x06037C92 RID: 228498
		UUIItem AttachItem { get; set; }

		// Token: 0x17008FB2 RID: 36786
		// (get) Token: 0x06037C93 RID: 228499
		// (set) Token: 0x06037C94 RID: 228500
		UUIItem TriggerItem { get; set; }

		// Token: 0x17008FB3 RID: 36787
		// (get) Token: 0x06037C95 RID: 228501
		// (set) Token: 0x06037C96 RID: 228502
		EPhantomArenaBattleDetailsPositionType PositionType { get; set; }

		// Token: 0x17008FB4 RID: 36788
		// (get) Token: 0x06037C97 RID: 228503
		// (set) Token: 0x06037C98 RID: 228504
		EPhantomArenaBattleDetailsTipsShowType ShowType { get; set; }
	}
}
