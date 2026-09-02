using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component
{
	// Token: 0x02005544 RID: 21828
	[NullableContext(1)]
	public interface ICardCheckComponentData
	{
		// Token: 0x17008F3A RID: 36666
		// (get) Token: 0x06037A58 RID: 227928
		// (set) Token: 0x06037A59 RID: 227929
		int LeftCount { get; set; }

		// Token: 0x17008F3B RID: 36667
		// (get) Token: 0x06037A5A RID: 227930
		// (set) Token: 0x06037A5B RID: 227931
		int MaxCount { get; set; }

		// Token: 0x17008F3C RID: 36668
		// (get) Token: 0x06037A5C RID: 227932
		// (set) Token: 0x06037A5D RID: 227933
		Action OnCheckBtnClick { get; set; }
	}
}
