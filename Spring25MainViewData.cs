using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020015C3 RID: 5571
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class Spring25MainViewData
{
	// Token: 0x06009D12 RID: 40210 RVA: 0x00292273 File Offset: 0x00290473
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public Spring25MainViewData()
	{
	}

	// Token: 0x04004836 RID: 18486
	[RequiredMember]
	public string TitleTextId;

	// Token: 0x04004837 RID: 18487
	[RequiredMember]
	public string InviteRemainCount;

	// Token: 0x04004838 RID: 18488
	[RequiredMember]
	public Dictionary<ESpring25RoleType, bool> CharacterInvitedMap;

	// Token: 0x04004839 RID: 18489
	public ESpring25RoleType? NewRoleType;
}
