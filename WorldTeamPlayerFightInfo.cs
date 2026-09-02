using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;

// Token: 0x02002337 RID: 9015
[NullableContext(1)]
[Nullable(0)]
public class WorldTeamPlayerFightInfo
{
	// Token: 0x06011327 RID: 70439 RVA: 0x004B8CB4 File Offset: 0x004B6EB4
	public WorldTeamPlayerFightInfo(string name, int playerId, int curRoleId, string playStationOnlineName, string playStationAccountId, string xboxUserId, string xboxOnlineName, List<WorldTeamRoleInfo> roleInfos)
	{
		this.NameInternal = name;
		this.PlayerIdInternal = playerId;
		this.RoleInfosInternal = roleInfos;
		this.CurRoleIdInternal = curRoleId;
		if (Singleton<Info>.Instance.IsPs5Platform())
		{
			this.ThirdPartyIdInternal = playStationAccountId;
			this.ThirdPartyOnlineNameInternal = playStationOnlineName;
			return;
		}
		this.ThirdPartyIdInternal = xboxUserId;
		this.ThirdPartyOnlineNameInternal = xboxOnlineName;
	}

	// Token: 0x17001574 RID: 5492
	// (get) Token: 0x06011328 RID: 70440 RVA: 0x004B8D11 File Offset: 0x004B6F11
	public int PlayerId
	{
		get
		{
			return this.PlayerIdInternal;
		}
	}

	// Token: 0x17001575 RID: 5493
	// (get) Token: 0x06011329 RID: 70441 RVA: 0x004B8D19 File Offset: 0x004B6F19
	// (set) Token: 0x0601132A RID: 70442 RVA: 0x004B8D21 File Offset: 0x004B6F21
	public int CurRoleId
	{
		get
		{
			return this.CurRoleIdInternal;
		}
		set
		{
			this.CurRoleIdInternal = value;
		}
	}

	// Token: 0x17001576 RID: 5494
	// (get) Token: 0x0601132B RID: 70443 RVA: 0x004B8D2A File Offset: 0x004B6F2A
	// (set) Token: 0x0601132C RID: 70444 RVA: 0x004B8D32 File Offset: 0x004B6F32
	public List<WorldTeamRoleInfo> RoleInfos
	{
		get
		{
			return this.RoleInfosInternal;
		}
		set
		{
			this.RoleInfosInternal = value;
		}
	}

	// Token: 0x0601132D RID: 70445 RVA: 0x004B8D3C File Offset: 0x004B6F3C
	[NullableContext(2)]
	public WorldTeamRoleInfo GetRoleInfoByConfigId(int configId)
	{
		foreach (WorldTeamRoleInfo worldTeamRoleInfo in this.RoleInfosInternal)
		{
			if (worldTeamRoleInfo.RoleId == configId)
			{
				return worldTeamRoleInfo;
			}
		}
		return null;
	}

	// Token: 0x17001577 RID: 5495
	// (get) Token: 0x0601132E RID: 70446 RVA: 0x004B8D98 File Offset: 0x004B6F98
	// (set) Token: 0x0601132F RID: 70447 RVA: 0x004B8DA0 File Offset: 0x004B6FA0
	public string Name
	{
		get
		{
			return this.NameInternal;
		}
		set
		{
			this.NameInternal = value;
		}
	}

	// Token: 0x17001578 RID: 5496
	// (get) Token: 0x06011330 RID: 70448 RVA: 0x004B8DA9 File Offset: 0x004B6FA9
	public string ThirdPartyOnlineName
	{
		get
		{
			return this.ThirdPartyOnlineNameInternal;
		}
	}

	// Token: 0x17001579 RID: 5497
	// (get) Token: 0x06011331 RID: 70449 RVA: 0x004B8DB1 File Offset: 0x004B6FB1
	public string ThirdPartyId
	{
		get
		{
			return this.ThirdPartyIdInternal;
		}
	}

	// Token: 0x04008727 RID: 34599
	private readonly int PlayerIdInternal;

	// Token: 0x04008728 RID: 34600
	private string NameInternal;

	// Token: 0x04008729 RID: 34601
	private int CurRoleIdInternal;

	// Token: 0x0400872A RID: 34602
	private List<WorldTeamRoleInfo> RoleInfosInternal;

	// Token: 0x0400872B RID: 34603
	private readonly string ThirdPartyIdInternal;

	// Token: 0x0400872C RID: 34604
	private readonly string ThirdPartyOnlineNameInternal;
}
