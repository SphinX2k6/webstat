using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x020028DF RID: 10463
[NullableContext(2)]
public interface IOpenRoleMainViewData
{
	// Token: 0x17001B3E RID: 6974
	// (get) Token: 0x06014C7F RID: 85119
	// (set) Token: 0x06014C80 RID: 85120
	ERoleAgentType AgentType { get; set; }

	// Token: 0x17001B3F RID: 6975
	// (get) Token: 0x06014C81 RID: 85121
	// (set) Token: 0x06014C82 RID: 85122
	int? SelectRoleId { get; set; }

	// Token: 0x17001B40 RID: 6976
	// (get) Token: 0x06014C83 RID: 85123
	// (set) Token: 0x06014C84 RID: 85124
	List<int> RoleIdList { get; set; }

	// Token: 0x17001B41 RID: 6977
	// (get) Token: 0x06014C85 RID: 85125
	// (set) Token: 0x06014C86 RID: 85126
	EUiTabViewName? OpenTabView { get; set; }

	// Token: 0x17001B42 RID: 6978
	// (get) Token: 0x06014C87 RID: 85127
	// (set) Token: 0x06014C88 RID: 85128
	TOpenViewCallBack FinishCallback { get; set; }

	// Token: 0x17001B43 RID: 6979
	// (get) Token: 0x06014C89 RID: 85129
	// (set) Token: 0x06014C8A RID: 85130
	ETeamPositionType? TeamPositionType { get; set; }

	// Token: 0x17001B44 RID: 6980
	// (get) Token: 0x06014C8B RID: 85131
	// (set) Token: 0x06014C8C RID: 85132
	ERoleViewSource? Source { get; set; }
}
