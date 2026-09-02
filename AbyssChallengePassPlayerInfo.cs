using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001AC2 RID: 6850
[NullableContext(1)]
[Nullable(0)]
public class AbyssChallengePassPlayerInfo
{
	// Token: 0x0600C4C7 RID: 50375 RVA: 0x0033EE14 File Offset: 0x0033D014
	public string GetName()
	{
		return this.Name;
	}

	// Token: 0x0600C4C8 RID: 50376 RVA: 0x0033EE1C File Offset: 0x0033D01C
	public int GetPlayerId()
	{
		return this.PlayerId;
	}

	// Token: 0x0600C4C9 RID: 50377 RVA: 0x0033EE24 File Offset: 0x0033D024
	public AbyssChallengePassRoleInfo[] GetPassRoleInfoList()
	{
		return this.PassRoleInfoList;
	}

	// Token: 0x0600C4CA RID: 50378 RVA: 0x0033EE2C File Offset: 0x0033D02C
	public void Phrase(Aki.Protocol.AbyssChallengePassPlayerInfo data)
	{
		this.Name = data.Name;
		this.PlayerId = data.PlayerId;
		this.PassRoleInfoList = Array.Empty<AbyssChallengePassRoleInfo>();
		List<AbyssChallengePassRoleInfo> list = new List<AbyssChallengePassRoleInfo>();
		int count = data.RoleInfos.Count;
		for (int i = 0; i < count; i++)
		{
			AbyssChallengePassRoleInfo abyssChallengePassRoleInfo = new AbyssChallengePassRoleInfo();
			abyssChallengePassRoleInfo.Phrase(data.RoleInfos[i]);
			list.Add(abyssChallengePassRoleInfo);
		}
		this.PassRoleInfoList = list.ToArray();
	}

	// Token: 0x04005E67 RID: 24167
	private string Name = "";

	// Token: 0x04005E68 RID: 24168
	private int PlayerId;

	// Token: 0x04005E69 RID: 24169
	private AbyssChallengePassRoleInfo[] PassRoleInfoList = Array.Empty<AbyssChallengePassRoleInfo>();
}
