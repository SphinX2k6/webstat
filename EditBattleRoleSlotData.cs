using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.InstanceDungeon.Define;

// Token: 0x02001B37 RID: 6967
[NullableContext(2)]
[Nullable(0)]
public class EditBattleRoleSlotData
{
	// Token: 0x0600C8F4 RID: 51444 RVA: 0x00353AC8 File Offset: 0x00351CC8
	public EditBattleRoleSlotData(int position)
	{
		this.Position = position;
	}

	// Token: 0x0600C8F5 RID: 51445 RVA: 0x00353AD7 File Offset: 0x00351CD7
	[NullableContext(1)]
	public void SetRoleData(EditBattleRoleData editBattleRoleData)
	{
		this.RoleData = editBattleRoleData;
	}

	// Token: 0x0600C8F6 RID: 51446 RVA: 0x00353AE0 File Offset: 0x00351CE0
	[NullableContext(1)]
	public void SetRoleDataByPrewarInfo(PrewarFormationData prewarFormationData)
	{
		int configId = prewarFormationData.GetConfigId();
		int skinId = prewarFormationData.GetSkinId();
		int onlineNumber = prewarFormationData.GetOnlineNumber();
		string playerName = prewarFormationData.GetPlayerName();
		int playerId = prewarFormationData.GetPlayerId();
		int level = prewarFormationData.GetLevel();
		bool isSelf = prewarFormationData.IsSelf();
		bool isReady = prewarFormationData.GetIsReady();
		if (this.RoleData == null)
		{
			this.RoleData = new EditBattleRoleData();
		}
		this.RoleData.Init(playerId, configId, skinId, new int?(onlineNumber), playerName, level, isSelf, isReady);
		this.RoleData.ThirdPartyOnlineId = prewarFormationData.GetPlayerOnlineId();
	}

	// Token: 0x0600C8F7 RID: 51447 RVA: 0x00353B69 File Offset: 0x00351D69
	public void ResetRoleData()
	{
		this.RoleData = null;
	}

	// Token: 0x1700101B RID: 4123
	// (get) Token: 0x0600C8F8 RID: 51448 RVA: 0x00353B72 File Offset: 0x00351D72
	public EditBattleRoleData GetRoleData
	{
		get
		{
			return this.RoleData;
		}
	}

	// Token: 0x1700101C RID: 4124
	// (get) Token: 0x0600C8F9 RID: 51449 RVA: 0x00353B7C File Offset: 0x00351D7C
	public int? GetRoleConfigId
	{
		get
		{
			EditBattleRoleData getRoleData = this.GetRoleData;
			if (getRoleData == null)
			{
				return null;
			}
			return new int?(getRoleData.ConfigId);
		}
	}

	// Token: 0x1700101D RID: 4125
	// (get) Token: 0x0600C8FA RID: 51450 RVA: 0x00353BA8 File Offset: 0x00351DA8
	public bool HasRole
	{
		get
		{
			return this.GetRoleData != null;
		}
	}

	// Token: 0x1700101E RID: 4126
	// (get) Token: 0x0600C8FB RID: 51451 RVA: 0x00353BB3 File Offset: 0x00351DB3
	public int GetPosition
	{
		get
		{
			return this.Position;
		}
	}

	// Token: 0x1700101F RID: 4127
	// (get) Token: 0x0600C8FC RID: 51452 RVA: 0x00353BBC File Offset: 0x00351DBC
	public bool IsProhibit
	{
		get
		{
			EditBattleTeamModel instance = ModelBase<EditBattleTeamModel>.Instance;
			if (instance.IsMultiInstanceDungeon)
			{
				return false;
			}
			if (instance.GetLeaderIsSelf)
			{
				int getPosition = this.GetPosition;
				int maxLimitRoleCount = instance.GetMaxLimitRoleCount();
				return maxLimitRoleCount != 0 && getPosition > maxLimitRoleCount;
			}
			return !this.HasRole || !this.GetRoleData.IsSelf;
		}
	}

	// Token: 0x17001020 RID: 4128
	// (get) Token: 0x0600C8FD RID: 51453 RVA: 0x00353C11 File Offset: 0x00351E11
	public bool CanEditRoleSlot
	{
		get
		{
			if (this.IsProhibit)
			{
				return false;
			}
			if (this.HasRole)
			{
				return this.GetRoleData.IsSelf;
			}
			return ModelBase<EditBattleTeamModel>.Instance.GetLeaderIsSelf;
		}
	}

	// Token: 0x04006056 RID: 24662
	private readonly int Position;

	// Token: 0x04006057 RID: 24663
	private EditBattleRoleData RoleData;
}
