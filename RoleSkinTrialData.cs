using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x0200157C RID: 5500
[NullableContext(1)]
[Nullable(0)]
public class RoleSkinTrialData : ActivityBaseData
{
	// Token: 0x06009A6D RID: 39533 RVA: 0x00287170 File Offset: 0x00285370
	protected override void PhraseEx(ActivityData data)
	{
		this.RoleSkinTrailContentDataList.Clear();
		foreach (RoleSkinTrialTask data2 in data.RoleSkinTrialInfoActivity.RoleSkinTrialTask)
		{
			RoleSkinTrailContentData roleSkinTrailContentData = new RoleSkinTrailContentData();
			roleSkinTrailContentData.Phrase(data2);
			this.RoleSkinTrailContentDataList.Add(roleSkinTrailContentData);
		}
	}

	// Token: 0x06009A6E RID: 39534 RVA: 0x002871E0 File Offset: 0x002853E0
	public void FinishRewardById(int roleId)
	{
		RoleSkinTrailContentData roleSkinTrailContentDataById = this.GetRoleSkinTrailContentDataById(roleId);
		if (roleSkinTrailContentDataById != null)
		{
			roleSkinTrailContentDataById.ChallengeState = ChallengeState.Finish;
		}
	}

	// Token: 0x06009A6F RID: 39535 RVA: 0x00287200 File Offset: 0x00285400
	[NullableContext(2)]
	public RoleSkinTrailContentData GetRoleSkinTrailContentDataByRoleId(int roleId)
	{
		return this.RoleSkinTrailContentDataList.Find((RoleSkinTrailContentData data) => data.RoleId == roleId);
	}

	// Token: 0x06009A70 RID: 39536 RVA: 0x00287234 File Offset: 0x00285434
	[NullableContext(2)]
	public RoleSkinTrailContentData GetRoleSkinTrailContentDataById(int id)
	{
		return this.RoleSkinTrailContentDataList.Find((RoleSkinTrailContentData data) => data.Id == id);
	}

	// Token: 0x06009A71 RID: 39537 RVA: 0x00287268 File Offset: 0x00285468
	public RoleSkinTrialActivity GetConfig()
	{
		return ConfigBase<RoleSkinTrialConfig>.Instance.GetRoleSkinTrialActivityByActivityId(base.Id).Value;
	}

	// Token: 0x06009A72 RID: 39538 RVA: 0x00287290 File Offset: 0x00285490
	public int GetSelectIdByIndex(int index)
	{
		List<int> roleList = this.GetRoleList();
		if (roleList.Count <= index)
		{
			return 0;
		}
		return roleList[index];
	}

	// Token: 0x06009A73 RID: 39539 RVA: 0x002872B8 File Offset: 0x002854B8
	public int? GetInstanceIdById(int id)
	{
		RoleSkinTrialInfo? roleSkinTrialInfoById = ConfigBase<RoleSkinTrialConfig>.Instance.GetRoleSkinTrialInfoById(id);
		if (roleSkinTrialInfoById == null)
		{
			return null;
		}
		return new int?(roleSkinTrialInfoById.GetValueOrDefault().InstanceId);
	}

	// Token: 0x06009A74 RID: 39540 RVA: 0x002872F8 File Offset: 0x002854F8
	public List<int> GetRoleList()
	{
		return this.GetConfig().GetRoleIdListArray().ToList<int>();
	}

	// Token: 0x06009A75 RID: 39541 RVA: 0x00287318 File Offset: 0x00285518
	public ChallengeState GetRewardStateById(int id)
	{
		RoleSkinTrailContentData roleSkinTrailContentDataById = this.GetRoleSkinTrailContentDataById(id);
		if (roleSkinTrailContentDataById != null)
		{
			return roleSkinTrailContentDataById.ChallengeState;
		}
		return ChallengeState.Running;
	}

	// Token: 0x06009A76 RID: 39542 RVA: 0x00287338 File Offset: 0x00285538
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public IItemGridData[] GetRewardDataById(int id)
	{
		RoleSkinTrailContentData roleSkinTrailContentDataById = this.GetRoleSkinTrailContentDataById(id);
		if (roleSkinTrailContentDataById != null)
		{
			return roleSkinTrailContentDataById.GetRewardData();
		}
		return null;
	}

	// Token: 0x06009A77 RID: 39543 RVA: 0x00287358 File Offset: 0x00285558
	public RoleSkinTrialInfo? GetInfoByRoleIdAndInstanceDungeonId(int roleId, int dungeonId)
	{
		foreach (RoleSkinTrailContentData roleSkinTrailContentData in this.RoleSkinTrailContentDataList)
		{
			if (roleSkinTrailContentData.RoleId == roleId)
			{
				RoleSkinTrialInfo roleSkinTrialInfo = roleSkinTrailContentData.GetRoleSkinTrialInfo();
				if (roleSkinTrialInfo.InstanceId == dungeonId)
				{
					return new RoleSkinTrialInfo?(roleSkinTrialInfo);
				}
			}
		}
		return null;
	}

	// Token: 0x06009A78 RID: 39544 RVA: 0x002873D4 File Offset: 0x002855D4
	public RoleSkinTrialUiConfig? GetRoleSkinTrialUiConfigById(int id)
	{
		RoleSkinTrailContentData roleSkinTrailContentDataById = this.GetRoleSkinTrailContentDataById(id);
		if (roleSkinTrailContentDataById != null)
		{
			return new RoleSkinTrialUiConfig?(roleSkinTrailContentDataById.GetRoleSkinTrialUiConfig());
		}
		return null;
	}

	// Token: 0x06009A79 RID: 39545 RVA: 0x00287404 File Offset: 0x00285604
	public int GetAccessIdById(int id)
	{
		RoleSkinTrailContentData roleSkinTrailContentDataById = this.GetRoleSkinTrailContentDataById(id);
		if (roleSkinTrailContentDataById != null)
		{
			return roleSkinTrailContentDataById.GetAccessId();
		}
		return 0;
	}

	// Token: 0x06009A7A RID: 39546 RVA: 0x00287424 File Offset: 0x00285624
	public override bool NeedSelfControlFirstRedPoint()
	{
		return false;
	}

	// Token: 0x06009A7B RID: 39547 RVA: 0x00287428 File Offset: 0x00285628
	public override bool GetExDataRedPointShowState()
	{
		using (List<RoleSkinTrailContentData>.Enumerator enumerator = this.RoleSkinTrailContentDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.ChallengeState == ChallengeState.WaitTakeReward)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06009A7C RID: 39548 RVA: 0x00287484 File Offset: 0x00285684
	protected override bool GetExDataFinishShowState()
	{
		using (List<RoleSkinTrailContentData>.Enumerator enumerator = this.RoleSkinTrailContentDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.ChallengeState != ChallengeState.Finish)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x0400472B RID: 18219
	public bool TrialState;

	// Token: 0x0400472C RID: 18220
	private readonly List<RoleSkinTrailContentData> RoleSkinTrailContentDataList = new List<RoleSkinTrailContentData>();
}
