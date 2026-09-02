using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Formation
{
	// Token: 0x02006628 RID: 26152
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballFormationSelectRoleViewData : IPinballFormationSelectRoleViewData
	{
		// Token: 0x17009F5E RID: 40798
		// (get) Token: 0x0604155A RID: 267610 RVA: 0x010C1ECB File Offset: 0x010C00CB
		// (set) Token: 0x0604155B RID: 267611 RVA: 0x010C1ED3 File Offset: 0x010C00D3
		public List<int> RoleList { get; set; } = new List<int>();

		// Token: 0x17009F5F RID: 40799
		// (get) Token: 0x0604155C RID: 267612 RVA: 0x010C1EDC File Offset: 0x010C00DC
		// (set) Token: 0x0604155D RID: 267613 RVA: 0x010C1EE4 File Offset: 0x010C00E4
		public List<int> RecommendRoleList { get; set; } = new List<int>();

		// Token: 0x17009F60 RID: 40800
		// (get) Token: 0x0604155E RID: 267614 RVA: 0x010C1EED File Offset: 0x010C00ED
		// (set) Token: 0x0604155F RID: 267615 RVA: 0x010C1EF5 File Offset: 0x010C00F5
		public Action<List<int>> OnConfirm { get; set; }

		// Token: 0x17009F61 RID: 40801
		// (get) Token: 0x06041560 RID: 267616 RVA: 0x010C1EFE File Offset: 0x010C00FE
		// (set) Token: 0x06041561 RID: 267617 RVA: 0x010C1F06 File Offset: 0x010C0106
		public int? OpenRole { get; set; }
	}
}
