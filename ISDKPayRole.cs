using System;
using System.Runtime.CompilerServices;

// Token: 0x02000EDB RID: 3803
[NullableContext(1)]
public interface ISDKPayRole
{
	// Token: 0x170006D2 RID: 1746
	// (get) Token: 0x06005DDB RID: 24027
	// (set) Token: 0x06005DDC RID: 24028
	string serverId { get; set; }

	// Token: 0x170006D3 RID: 1747
	// (get) Token: 0x06005DDD RID: 24029
	// (set) Token: 0x06005DDE RID: 24030
	string serverName { get; set; }

	// Token: 0x170006D4 RID: 1748
	// (get) Token: 0x06005DDF RID: 24031
	// (set) Token: 0x06005DE0 RID: 24032
	string roleId { get; set; }

	// Token: 0x170006D5 RID: 1749
	// (get) Token: 0x06005DE1 RID: 24033
	// (set) Token: 0x06005DE2 RID: 24034
	string roleName { get; set; }

	// Token: 0x170006D6 RID: 1750
	// (get) Token: 0x06005DE3 RID: 24035
	// (set) Token: 0x06005DE4 RID: 24036
	string roleLevel { get; set; }

	// Token: 0x170006D7 RID: 1751
	// (get) Token: 0x06005DE5 RID: 24037
	// (set) Token: 0x06005DE6 RID: 24038
	string vipLevel { get; set; }

	// Token: 0x170006D8 RID: 1752
	// (get) Token: 0x06005DE7 RID: 24039
	// (set) Token: 0x06005DE8 RID: 24040
	int setBalanceLevelOne { get; set; }

	// Token: 0x170006D9 RID: 1753
	// (get) Token: 0x06005DE9 RID: 24041
	// (set) Token: 0x06005DEA RID: 24042
	int setBalanceLevelTwo { get; set; }

	// Token: 0x170006DA RID: 1754
	// (get) Token: 0x06005DEB RID: 24043
	// (set) Token: 0x06005DEC RID: 24044
	string partyName { get; set; }
}
