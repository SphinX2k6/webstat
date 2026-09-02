using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DFA RID: 19962
	[NullableContext(2)]
	public interface ITrapDefenseMarkInfo
	{
		// Token: 0x170088BC RID: 35004
		// (get) Token: 0x060339CC RID: 211404
		// (set) Token: 0x060339CD RID: 211405
		int MarkId { get; set; }

		// Token: 0x170088BD RID: 35005
		// (get) Token: 0x060339CE RID: 211406
		// (set) Token: 0x060339CF RID: 211407
		TrapDefenseDefine.ETrapDefenseMarkType MarkType { get; set; }

		// Token: 0x170088BE RID: 35006
		// (get) Token: 0x060339D0 RID: 211408
		// (set) Token: 0x060339D1 RID: 211409
		object ExtraParam { get; set; }
	}
}
