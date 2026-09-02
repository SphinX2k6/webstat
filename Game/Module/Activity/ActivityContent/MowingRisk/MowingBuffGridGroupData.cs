using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x02006681 RID: 26241
	[NullableContext(1)]
	[Nullable(0)]
	public class MowingBuffGridGroupData : IMowingBuffGridGroupData
	{
		// Token: 0x17009FD2 RID: 40914
		// (get) Token: 0x060418B5 RID: 268469 RVA: 0x010D0D8C File Offset: 0x010CEF8C
		// (set) Token: 0x060418B6 RID: 268470 RVA: 0x010D0D94 File Offset: 0x010CEF94
		public string GroupNameTextId { get; set; }

		// Token: 0x17009FD3 RID: 40915
		// (get) Token: 0x060418B7 RID: 268471 RVA: 0x010D0D9D File Offset: 0x010CEF9D
		// (set) Token: 0x060418B8 RID: 268472 RVA: 0x010D0DA5 File Offset: 0x010CEFA5
		public bool ShowUnlockText { get; set; }

		// Token: 0x17009FD4 RID: 40916
		// (get) Token: 0x060418B9 RID: 268473 RVA: 0x010D0DAE File Offset: 0x010CEFAE
		// (set) Token: 0x060418BA RID: 268474 RVA: 0x010D0DB6 File Offset: 0x010CEFB6
		public IMowingBuffGridItemData[] BuffItemList { get; set; }
	}
}
