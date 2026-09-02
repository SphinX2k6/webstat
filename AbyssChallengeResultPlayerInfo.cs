using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001ABA RID: 6842
[NullableContext(1)]
[Nullable(0)]
public class AbyssChallengeResultPlayerInfo
{
	// Token: 0x0600C485 RID: 50309 RVA: 0x0033DF04 File Offset: 0x0033C104
	public int GetPlayerId()
	{
		return this.PlayerId;
	}

	// Token: 0x0600C486 RID: 50310 RVA: 0x0033DF0C File Offset: 0x0033C10C
	public int GetLikeCount()
	{
		return this.LikeCount;
	}

	// Token: 0x0600C487 RID: 50311 RVA: 0x0033DF14 File Offset: 0x0033C114
	public global::AbyssChallengeResultRoleInfo[] GetRoleInfo()
	{
		return this.RoleInfo;
	}

	// Token: 0x0600C488 RID: 50312 RVA: 0x0033DF1C File Offset: 0x0033C11C
	public void SetLikeCount(int count)
	{
		this.LikeCount = count;
	}

	// Token: 0x0600C489 RID: 50313 RVA: 0x0033DF28 File Offset: 0x0033C128
	public void Phrase(Aki.Protocol.AbyssChallengeResultPlayerInfo data)
	{
		this.PlayerId = data.PlayerId;
		this.LikeCount = data.LikeCount;
		this.RoleInfo = Array.Empty<global::AbyssChallengeResultRoleInfo>();
		List<global::AbyssChallengeResultRoleInfo> list = new List<global::AbyssChallengeResultRoleInfo>();
		int count = data.RoleInfos.Count;
		for (int i = 0; i < count; i++)
		{
			global::AbyssChallengeResultRoleInfo abyssChallengeResultRoleInfo = new global::AbyssChallengeResultRoleInfo();
			abyssChallengeResultRoleInfo.Phrase(data.RoleInfos[i]);
			list.Add(abyssChallengeResultRoleInfo);
		}
		this.RoleInfo = list.ToArray();
	}

	// Token: 0x04005E3F RID: 24127
	private int PlayerId;

	// Token: 0x04005E40 RID: 24128
	private int LikeCount;

	// Token: 0x04005E41 RID: 24129
	private global::AbyssChallengeResultRoleInfo[] RoleInfo = Array.Empty<global::AbyssChallengeResultRoleInfo>();
}
