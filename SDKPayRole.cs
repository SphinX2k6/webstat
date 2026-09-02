using System;
using System.Runtime.CompilerServices;

// Token: 0x02000EDC RID: 3804
[NullableContext(1)]
[Nullable(0)]
public class SDKPayRole : ISDKPayRole
{
	// Token: 0x170006DB RID: 1755
	// (get) Token: 0x06005DED RID: 24045 RVA: 0x001782EA File Offset: 0x001764EA
	// (set) Token: 0x06005DEE RID: 24046 RVA: 0x001782F2 File Offset: 0x001764F2
	public string serverId { get; set; }

	// Token: 0x170006DC RID: 1756
	// (get) Token: 0x06005DEF RID: 24047 RVA: 0x001782FB File Offset: 0x001764FB
	// (set) Token: 0x06005DF0 RID: 24048 RVA: 0x00178303 File Offset: 0x00176503
	public string serverName { get; set; }

	// Token: 0x170006DD RID: 1757
	// (get) Token: 0x06005DF1 RID: 24049 RVA: 0x0017830C File Offset: 0x0017650C
	// (set) Token: 0x06005DF2 RID: 24050 RVA: 0x00178314 File Offset: 0x00176514
	public string roleId { get; set; }

	// Token: 0x170006DE RID: 1758
	// (get) Token: 0x06005DF3 RID: 24051 RVA: 0x0017831D File Offset: 0x0017651D
	// (set) Token: 0x06005DF4 RID: 24052 RVA: 0x00178325 File Offset: 0x00176525
	public string roleName { get; set; }

	// Token: 0x170006DF RID: 1759
	// (get) Token: 0x06005DF5 RID: 24053 RVA: 0x0017832E File Offset: 0x0017652E
	// (set) Token: 0x06005DF6 RID: 24054 RVA: 0x00178336 File Offset: 0x00176536
	public string roleLevel { get; set; }

	// Token: 0x170006E0 RID: 1760
	// (get) Token: 0x06005DF7 RID: 24055 RVA: 0x0017833F File Offset: 0x0017653F
	// (set) Token: 0x06005DF8 RID: 24056 RVA: 0x00178347 File Offset: 0x00176547
	public string vipLevel { get; set; }

	// Token: 0x170006E1 RID: 1761
	// (get) Token: 0x06005DF9 RID: 24057 RVA: 0x00178350 File Offset: 0x00176550
	// (set) Token: 0x06005DFA RID: 24058 RVA: 0x00178358 File Offset: 0x00176558
	public int setBalanceLevelOne { get; set; }

	// Token: 0x170006E2 RID: 1762
	// (get) Token: 0x06005DFB RID: 24059 RVA: 0x00178361 File Offset: 0x00176561
	// (set) Token: 0x06005DFC RID: 24060 RVA: 0x00178369 File Offset: 0x00176569
	public int setBalanceLevelTwo { get; set; }

	// Token: 0x170006E3 RID: 1763
	// (get) Token: 0x06005DFD RID: 24061 RVA: 0x00178372 File Offset: 0x00176572
	// (set) Token: 0x06005DFE RID: 24062 RVA: 0x0017837A File Offset: 0x0017657A
	public string partyName { get; set; }
}
