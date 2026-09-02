using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x02006680 RID: 26240
	[NullableContext(1)]
	public interface IMowingBuffGridGroupData
	{
		// Token: 0x17009FCF RID: 40911
		// (get) Token: 0x060418AF RID: 268463
		// (set) Token: 0x060418B0 RID: 268464
		string GroupNameTextId { get; set; }

		// Token: 0x17009FD0 RID: 40912
		// (get) Token: 0x060418B1 RID: 268465
		// (set) Token: 0x060418B2 RID: 268466
		bool ShowUnlockText { get; set; }

		// Token: 0x17009FD1 RID: 40913
		// (get) Token: 0x060418B3 RID: 268467
		// (set) Token: 0x060418B4 RID: 268468
		IMowingBuffGridItemData[] BuffItemList { get; set; }
	}
}
