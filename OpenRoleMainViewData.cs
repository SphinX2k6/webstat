using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x020028E0 RID: 10464
[NullableContext(2)]
[Nullable(0)]
public class OpenRoleMainViewData : IOpenRoleMainViewData
{
	// Token: 0x17001B45 RID: 6981
	// (get) Token: 0x06014C8D RID: 85133 RVA: 0x005C1EC5 File Offset: 0x005C00C5
	// (set) Token: 0x06014C8E RID: 85134 RVA: 0x005C1ECD File Offset: 0x005C00CD
	public ERoleAgentType AgentType { get; set; }

	// Token: 0x17001B46 RID: 6982
	// (get) Token: 0x06014C8F RID: 85135 RVA: 0x005C1ED6 File Offset: 0x005C00D6
	// (set) Token: 0x06014C90 RID: 85136 RVA: 0x005C1EDE File Offset: 0x005C00DE
	public int? SelectRoleId { get; set; }

	// Token: 0x17001B47 RID: 6983
	// (get) Token: 0x06014C91 RID: 85137 RVA: 0x005C1EE7 File Offset: 0x005C00E7
	// (set) Token: 0x06014C92 RID: 85138 RVA: 0x005C1EEF File Offset: 0x005C00EF
	public List<int> RoleIdList { get; set; }

	// Token: 0x17001B48 RID: 6984
	// (get) Token: 0x06014C93 RID: 85139 RVA: 0x005C1EF8 File Offset: 0x005C00F8
	// (set) Token: 0x06014C94 RID: 85140 RVA: 0x005C1F00 File Offset: 0x005C0100
	public EUiTabViewName? OpenTabView { get; set; }

	// Token: 0x17001B49 RID: 6985
	// (get) Token: 0x06014C95 RID: 85141 RVA: 0x005C1F09 File Offset: 0x005C0109
	// (set) Token: 0x06014C96 RID: 85142 RVA: 0x005C1F11 File Offset: 0x005C0111
	public TOpenViewCallBack FinishCallback { get; set; }

	// Token: 0x17001B4A RID: 6986
	// (get) Token: 0x06014C97 RID: 85143 RVA: 0x005C1F1A File Offset: 0x005C011A
	// (set) Token: 0x06014C98 RID: 85144 RVA: 0x005C1F22 File Offset: 0x005C0122
	public ETeamPositionType? TeamPositionType { get; set; }

	// Token: 0x17001B4B RID: 6987
	// (get) Token: 0x06014C99 RID: 85145 RVA: 0x005C1F2B File Offset: 0x005C012B
	// (set) Token: 0x06014C9A RID: 85146 RVA: 0x005C1F33 File Offset: 0x005C0133
	public ERoleViewSource? Source { get; set; }
}
