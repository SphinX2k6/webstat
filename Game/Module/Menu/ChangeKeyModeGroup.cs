using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu
{
	// Token: 0x02005761 RID: 22369
	[NullableContext(1)]
	[Nullable(0)]
	public class ChangeKeyModeGroup : IChangeKeyModeGroup
	{
		// Token: 0x17009180 RID: 37248
		// (get) Token: 0x06038ED6 RID: 233174 RVA: 0x00E6C87C File Offset: 0x00E6AA7C
		// (set) Token: 0x06038ED7 RID: 233175 RVA: 0x00E6C884 File Offset: 0x00E6AA84
		public string GroupName { get; set; } = "";

		// Token: 0x17009181 RID: 37249
		// (get) Token: 0x06038ED8 RID: 233176 RVA: 0x00E6C88D File Offset: 0x00E6AA8D
		// (set) Token: 0x06038ED9 RID: 233177 RVA: 0x00E6C895 File Offset: 0x00E6AA95
		public int DefaultKeyModeRowIndex { get; set; }

		// Token: 0x17009182 RID: 37250
		// (get) Token: 0x06038EDA RID: 233178 RVA: 0x00E6C89E File Offset: 0x00E6AA9E
		// (set) Token: 0x06038EDB RID: 233179 RVA: 0x00E6C8A6 File Offset: 0x00E6AAA6
		public IChangeKeyModeRow[] ChangeKeyModeRowList { get; set; } = new IChangeKeyModeRow[0];
	}
}
