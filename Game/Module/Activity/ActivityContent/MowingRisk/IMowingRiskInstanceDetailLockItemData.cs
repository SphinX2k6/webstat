using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x0200668C RID: 26252
	[NullableContext(1)]
	public interface IMowingRiskInstanceDetailLockItemData
	{
		// Token: 0x17009FFB RID: 40955
		// (get) Token: 0x0604190D RID: 268557
		// (set) Token: 0x0604190E RID: 268558
		bool IsUnlock { get; set; }

		// Token: 0x17009FFC RID: 40956
		// (get) Token: 0x0604190F RID: 268559
		// (set) Token: 0x06041910 RID: 268560
		string LockDescriptionTextId { get; set; }

		// Token: 0x17009FFD RID: 40957
		// (get) Token: 0x06041911 RID: 268561
		// (set) Token: 0x06041912 RID: 268562
		string[] LockDescriptionTextArgs { get; set; }
	}
}
