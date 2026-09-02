using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FB6 RID: 20406
	[NullableContext(1)]
	public interface ISheriffMainTabItemData
	{
		// Token: 0x17008A72 RID: 35442
		// (get) Token: 0x06034A65 RID: 215653
		// (set) Token: 0x06034A66 RID: 215654
		ESheriffMainTabType TabType { get; set; }

		// Token: 0x17008A73 RID: 35443
		// (get) Token: 0x06034A67 RID: 215655
		// (set) Token: 0x06034A68 RID: 215656
		string TabIcon { get; set; }

		// Token: 0x17008A74 RID: 35444
		// (get) Token: 0x06034A69 RID: 215657
		// (set) Token: 0x06034A6A RID: 215658
		string TabTxt { get; set; }

		// Token: 0x17008A75 RID: 35445
		// (get) Token: 0x06034A6B RID: 215659
		// (set) Token: 0x06034A6C RID: 215660
		bool? IsLock { get; set; }

		// Token: 0x17008A76 RID: 35446
		// (get) Token: 0x06034A6D RID: 215661
		// (set) Token: 0x06034A6E RID: 215662
		EFunctionType FunctionType { get; set; }
	}
}
