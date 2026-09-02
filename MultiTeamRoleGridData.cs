using System;
using System.Runtime.CompilerServices;

// Token: 0x02002792 RID: 10130
[NullableContext(2)]
[Nullable(0)]
public class MultiTeamRoleGridData
{
	// Token: 0x06013FDA RID: 81882 RVA: 0x00592123 File Offset: 0x00590323
	public RoleDataBase GetRole()
	{
		return this.Role;
	}

	// Token: 0x06013FDB RID: 81883 RVA: 0x0059212B File Offset: 0x0059032B
	public bool GetIsRecommend()
	{
		return this.IsRecommend;
	}

	// Token: 0x06013FDC RID: 81884 RVA: 0x00592133 File Offset: 0x00590333
	public bool GetIsHighlight()
	{
		return this.IsHighlight;
	}

	// Token: 0x06013FDD RID: 81885 RVA: 0x0059213B File Offset: 0x0059033B
	public bool GetIsLock()
	{
		return this.IsLock;
	}

	// Token: 0x06013FDE RID: 81886 RVA: 0x00592143 File Offset: 0x00590343
	public bool GetIsUnRecommend()
	{
		return this.IsUnRecommend;
	}

	// Token: 0x06013FDF RID: 81887 RVA: 0x0059214B File Offset: 0x0059034B
	[NullableContext(1)]
	public static MultiTeamRoleGridData Phrase(RoleDataBase role, bool isRecommend, bool isHighlight, bool isLock = false, bool isUnRecommend = false)
	{
		return new MultiTeamRoleGridData
		{
			Role = role,
			IsRecommend = isRecommend,
			IsHighlight = isHighlight,
			IsLock = isLock,
			IsUnRecommend = isUnRecommend
		};
	}

	// Token: 0x04009BA6 RID: 39846
	private RoleDataBase Role;

	// Token: 0x04009BA7 RID: 39847
	private bool IsRecommend;

	// Token: 0x04009BA8 RID: 39848
	private bool IsHighlight;

	// Token: 0x04009BA9 RID: 39849
	private bool IsLock;

	// Token: 0x04009BAA RID: 39850
	private bool IsUnRecommend;
}
