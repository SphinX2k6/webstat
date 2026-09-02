using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing
{
	// Token: 0x0200673E RID: 26430
	[NullableContext(1)]
	public interface IBusinessTipsTravelData
	{
		// Token: 0x1700A0B8 RID: 41144
		// (get) Token: 0x06041EC5 RID: 270021
		// (set) Token: 0x06041EC6 RID: 270022
		List<int> RoleList { get; set; }

		// Token: 0x1700A0B9 RID: 41145
		// (get) Token: 0x06041EC7 RID: 270023
		// (set) Token: 0x06041EC8 RID: 270024
		List<int> LastLevelList { get; set; }

		// Token: 0x1700A0BA RID: 41146
		// (get) Token: 0x06041EC9 RID: 270025
		// (set) Token: 0x06041ECA RID: 270026
		int DelegateId { get; set; }
	}
}
