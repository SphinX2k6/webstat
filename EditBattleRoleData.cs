using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x02001B36 RID: 6966
[NullableContext(2)]
[Nullable(0)]
public class EditBattleRoleData
{
	// Token: 0x0600C8EF RID: 51439 RVA: 0x003539EC File Offset: 0x00351BEC
	public void Init(int playerId, int configId, int skinId, int? onlineIndex, string playerName, int level, bool isSelf, bool isReady)
	{
		this.PlayerId = playerId;
		this.ConfigId = configId;
		this.SkinId = skinId;
		this.OnlineIndex = onlineIndex;
		this.PlayerName = playerName;
		this.Level = level;
		this.IsSelf = isSelf;
		this.IsReady = isReady;
	}

	// Token: 0x0600C8F0 RID: 51440 RVA: 0x00353A2C File Offset: 0x00351C2C
	[NullableContext(1)]
	public string GetName()
	{
		if (ControllerBase<KuroSdkController>.Instance.NeedShowThirdPartyId())
		{
			string thirdPartyOnlineId = this.ThirdPartyOnlineId;
			if (thirdPartyOnlineId != null && thirdPartyOnlineId != "")
			{
				return thirdPartyOnlineId;
			}
		}
		return this.PlayerName;
	}

	// Token: 0x0600C8F1 RID: 51441 RVA: 0x00353A64 File Offset: 0x00351C64
	public void SetReady(bool bReady)
	{
		this.IsReady = bReady;
	}

	// Token: 0x1700101A RID: 4122
	// (get) Token: 0x0600C8F2 RID: 51442 RVA: 0x00353A70 File Offset: 0x00351C70
	public TrialRoleInfo? GetTrialRoleConfig
	{
		get
		{
			if (this.ConfigId > 100000)
			{
				TrialRoleInfo? result = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfigByGroupId(this.ConfigId);
				if (result == null)
				{
					result = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(this.ConfigId);
				}
				return result;
			}
			return null;
		}
	}

	// Token: 0x0400604D RID: 24653
	public int ConfigId;

	// Token: 0x0400604E RID: 24654
	public int SkinId;

	// Token: 0x0400604F RID: 24655
	public int? OnlineIndex;

	// Token: 0x04006050 RID: 24656
	public string PlayerName;

	// Token: 0x04006051 RID: 24657
	public int Level;

	// Token: 0x04006052 RID: 24658
	public bool IsSelf;

	// Token: 0x04006053 RID: 24659
	public bool IsReady;

	// Token: 0x04006054 RID: 24660
	public int PlayerId;

	// Token: 0x04006055 RID: 24661
	public string ThirdPartyOnlineId;
}
