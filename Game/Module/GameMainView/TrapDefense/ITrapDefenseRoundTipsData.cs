using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.GameMainView.TrapDefense
{
	// Token: 0x02005D11 RID: 23825
	[NullableContext(2)]
	public interface ITrapDefenseRoundTipsData
	{
		// Token: 0x17009862 RID: 39010
		// (get) Token: 0x0603C0C7 RID: 245959
		// (set) Token: 0x0603C0C8 RID: 245960
		int Round { get; set; }

		// Token: 0x17009863 RID: 39011
		// (get) Token: 0x0603C0C9 RID: 245961
		// (set) Token: 0x0603C0CA RID: 245962
		Action Callback { get; set; }
	}
}
