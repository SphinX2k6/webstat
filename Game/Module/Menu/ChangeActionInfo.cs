using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu
{
	// Token: 0x02005759 RID: 22361
	[NullableContext(1)]
	[Nullable(0)]
	public class ChangeActionInfo : IChangeActionInfo
	{
		// Token: 0x1700916C RID: 37228
		// (get) Token: 0x06038EAB RID: 233131 RVA: 0x00E6C78E File Offset: 0x00E6A98E
		// (set) Token: 0x06038EAC RID: 233132 RVA: 0x00E6C796 File Offset: 0x00E6A996
		public EInputControllerType InputControllerType { get; set; }

		// Token: 0x1700916D RID: 37229
		// (get) Token: 0x06038EAD RID: 233133 RVA: 0x00E6C79F File Offset: 0x00E6A99F
		// (set) Token: 0x06038EAE RID: 233134 RVA: 0x00E6C7A7 File Offset: 0x00E6A9A7
		public KeySettingRowData KeySettingRowData { get; set; }

		// Token: 0x1700916E RID: 37230
		// (get) Token: 0x06038EAF RID: 233135 RVA: 0x00E6C7B0 File Offset: 0x00E6A9B0
		// (set) Token: 0x06038EB0 RID: 233136 RVA: 0x00E6C7B8 File Offset: 0x00E6A9B8
		public Action<bool> OnConfirmCallback { get; set; }
	}
}
