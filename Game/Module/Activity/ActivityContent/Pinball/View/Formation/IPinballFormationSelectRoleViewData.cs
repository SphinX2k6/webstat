using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Formation
{
	// Token: 0x02006627 RID: 26151
	[NullableContext(1)]
	public interface IPinballFormationSelectRoleViewData
	{
		// Token: 0x17009F5A RID: 40794
		// (get) Token: 0x06041552 RID: 267602
		// (set) Token: 0x06041553 RID: 267603
		List<int> RoleList { get; set; }

		// Token: 0x17009F5B RID: 40795
		// (get) Token: 0x06041554 RID: 267604
		// (set) Token: 0x06041555 RID: 267605
		List<int> RecommendRoleList { get; set; }

		// Token: 0x17009F5C RID: 40796
		// (get) Token: 0x06041556 RID: 267606
		// (set) Token: 0x06041557 RID: 267607
		Action<List<int>> OnConfirm { get; set; }

		// Token: 0x17009F5D RID: 40797
		// (get) Token: 0x06041558 RID: 267608
		// (set) Token: 0x06041559 RID: 267609
		int? OpenRole { get; set; }
	}
}
