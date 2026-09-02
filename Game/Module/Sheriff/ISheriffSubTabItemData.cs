using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FB9 RID: 20409
	[NullableContext(1)]
	public interface ISheriffSubTabItemData
	{
		// Token: 0x17008A7C RID: 35452
		// (get) Token: 0x06034A7A RID: 215674
		// (set) Token: 0x06034A7B RID: 215675
		ESheriffSubTabType TabType { get; set; }

		// Token: 0x17008A7D RID: 35453
		// (get) Token: 0x06034A7C RID: 215676
		// (set) Token: 0x06034A7D RID: 215677
		string TabIcon { get; set; }

		// Token: 0x17008A7E RID: 35454
		// (get) Token: 0x06034A7E RID: 215678
		// (set) Token: 0x06034A7F RID: 215679
		string TabTxt { get; set; }

		// Token: 0x17008A7F RID: 35455
		// (get) Token: 0x06034A80 RID: 215680
		// (set) Token: 0x06034A81 RID: 215681
		bool IsFinished { get; set; }
	}
}
