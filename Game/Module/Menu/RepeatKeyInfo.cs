using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu
{
	// Token: 0x02005757 RID: 22359
	[NullableContext(1)]
	[Nullable(0)]
	public class RepeatKeyInfo : IRepeatKeyInfo
	{
		// Token: 0x17009165 RID: 37221
		// (get) Token: 0x06038E9C RID: 233116 RVA: 0x00E6C742 File Offset: 0x00E6A942
		// (set) Token: 0x06038E9D RID: 233117 RVA: 0x00E6C74A File Offset: 0x00E6A94A
		public EInputControllerType InputControllerType { get; set; }

		// Token: 0x17009166 RID: 37222
		// (get) Token: 0x06038E9E RID: 233118 RVA: 0x00E6C753 File Offset: 0x00E6A953
		// (set) Token: 0x06038E9F RID: 233119 RVA: 0x00E6C75B File Offset: 0x00E6A95B
		public KeySettingRowData CurrentKeySettingRowData { get; set; }

		// Token: 0x17009167 RID: 37223
		// (get) Token: 0x06038EA0 RID: 233120 RVA: 0x00E6C764 File Offset: 0x00E6A964
		// (set) Token: 0x06038EA1 RID: 233121 RVA: 0x00E6C76C File Offset: 0x00E6A96C
		public KeySettingRowData RepeatKeySettingRowData { get; set; }

		// Token: 0x17009168 RID: 37224
		// (get) Token: 0x06038EA2 RID: 233122 RVA: 0x00E6C775 File Offset: 0x00E6A975
		// (set) Token: 0x06038EA3 RID: 233123 RVA: 0x00E6C77D File Offset: 0x00E6A97D
		[Nullable(2)]
		public Action<bool> OnCloseCallback { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
