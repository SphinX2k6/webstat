using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball;

// Token: 0x020014AE RID: 5294
[NullableContext(1)]
public interface IPinballRoleSelectViewOpenData
{
	// Token: 0x17000C5B RID: 3163
	// (get) Token: 0x06009442 RID: 37954
	// (set) Token: 0x06009443 RID: 37955
	PinballActivityData ActivityData { get; set; }

	// Token: 0x17000C5C RID: 3164
	// (get) Token: 0x06009444 RID: 37956
	// (set) Token: 0x06009445 RID: 37957
	int SelectedRoleId { get; set; }

	// Token: 0x17000C5D RID: 3165
	// (get) Token: 0x06009446 RID: 37958
	// (set) Token: 0x06009447 RID: 37959
	List<PinballRoleDataBase> RoleDataList { get; set; }

	// Token: 0x17000C5E RID: 3166
	// (get) Token: 0x06009448 RID: 37960
	// (set) Token: 0x06009449 RID: 37961
	[Nullable(2)]
	int[] FormationRoleIds { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x17000C5F RID: 3167
	// (get) Token: 0x0600944A RID: 37962
	// (set) Token: 0x0600944B RID: 37963
	Action<int> OnSelectConfirm { get; set; }
}
