using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PayShop
{
	// Token: 0x020056B1 RID: 22193
	[NullableContext(1)]
	public interface IRemainingData
	{
		// Token: 0x170090A0 RID: 37024
		// (get) Token: 0x060387C4 RID: 231364
		// (set) Token: 0x060387C5 RID: 231365
		string TextId { get; set; }

		// Token: 0x170090A1 RID: 37025
		// (get) Token: 0x060387C6 RID: 231366
		// (set) Token: 0x060387C7 RID: 231367
		int Count { get; set; }
	}
}
