using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Reward;

// Token: 0x0200157B RID: 5499
[NullableContext(1)]
[Nullable(0)]
public class RoleSkinTrailContentData
{
	// Token: 0x06009A66 RID: 39526 RVA: 0x00286FCC File Offset: 0x002851CC
	public IItemGridData[] GetRewardData()
	{
		RoleSkinTrialInfo? roleSkinTrialInfoByRoleId = ConfigBase<RoleSkinTrialConfig>.Instance.GetRoleSkinTrialInfoByRoleId(this.RoleId);
		if (roleSkinTrialInfoByRoleId == null || roleSkinTrialInfoByRoleId.Value.DropId == 0)
		{
			return null;
		}
		List<IItemGridData> list = new List<IItemGridData>();
		foreach (TItem item in ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(roleSkinTrialInfoByRoleId.Value.DropId))
		{
			ItemGridData item2 = new ItemGridData
			{
				Item = item,
				HasClaimed = (this.ChallengeState == ChallengeState.Finish)
			};
			list.Add(item2);
		}
		return list.ToArray();
	}

	// Token: 0x06009A67 RID: 39527 RVA: 0x0028708C File Offset: 0x0028528C
	public RoleSkinTrialInfo GetRoleSkinTrialInfo()
	{
		return ConfigBase<RoleSkinTrialConfig>.Instance.GetRoleSkinTrialInfoByRoleId(this.RoleId).Value;
	}

	// Token: 0x06009A68 RID: 39528 RVA: 0x002870B4 File Offset: 0x002852B4
	public int GetInstanceDungeonId()
	{
		return this.GetRoleSkinTrialInfo().InstanceId;
	}

	// Token: 0x06009A69 RID: 39529 RVA: 0x002870D0 File Offset: 0x002852D0
	public int GetAccessId()
	{
		return this.GetRoleSkinTrialInfo().AccessId;
	}

	// Token: 0x06009A6A RID: 39530 RVA: 0x002870EC File Offset: 0x002852EC
	public RoleSkinTrialUiConfig GetRoleSkinTrialUiConfig()
	{
		return ConfigBase<RoleSkinTrialConfig>.Instance.GetRoleSkinTrialUiConfigById(this.GetRoleSkinTrialInfo().UiConfigId).Value;
	}

	// Token: 0x06009A6B RID: 39531 RVA: 0x0028711C File Offset: 0x0028531C
	public void Phrase(RoleSkinTrialTask data)
	{
		this.Id = data.RoleSkinTrialInfoId;
		this.RoleId = ConfigBase<RoleSkinTrialConfig>.Instance.GetRoleSkinTrialInfoById(this.Id).Value.RoleId;
		this.ChallengeState = data.ChallengeState;
	}

	// Token: 0x04004728 RID: 18216
	public int RoleId;

	// Token: 0x04004729 RID: 18217
	public int Id;

	// Token: 0x0400472A RID: 18218
	public ChallengeState ChallengeState;
}
