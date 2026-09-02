using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001230 RID: 4656
[NullableContext(1)]
[Nullable(0)]
public class BabelTowerLevelInfoView : UiViewBase
{
	// Token: 0x06007BDD RID: 31709 RVA: 0x00207E37 File Offset: 0x00206037
	public BabelTowerLevelInfoView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06007BDE RID: 31710 RVA: 0x00207E40 File Offset: 0x00206040
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIArtText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClickConfirmBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickLevelDetailBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007BDF RID: 31711 RVA: 0x00208014 File Offset: 0x00206214
	protected override UniTask OnBeforeStartAsync()
	{
		BabelTowerLevelInfoView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BabelTowerLevelInfoView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007BE0 RID: 31712 RVA: 0x00208057 File Offset: 0x00206257
	protected override void OnStart()
	{
		this.BabelTowerLevelInfo = (this.OpenParam as IBabelTowerLevelInfo);
		Singleton<EventSystem>.Instance.Add(EEventName.OnRoleChangeEnd, new Action(this.OnRoleChangeEnd));
	}

	// Token: 0x06007BE1 RID: 31713 RVA: 0x00208086 File Offset: 0x00206286
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleChangeEnd, new Action(this.OnRoleChangeEnd));
	}

	// Token: 0x06007BE2 RID: 31714 RVA: 0x002080A4 File Offset: 0x002062A4
	protected override void OnBeforeShow()
	{
		EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
		for (int i = 0; i < this.BabelTowerLevelInfo.RoleList.Count; i++)
		{
			int num = this.BabelTowerLevelInfo.RoleList[i];
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(num, true);
			int num2 = (roleDataById != null) ? roleDataById.GetRoleId() : 0;
			if (ModelBase<RoleModel>.Instance.IsMainRole(num2))
			{
				if (num < 100000 && ModelBase<RoleModel>.Instance.GetRoleInstanceById(num2) == null)
				{
					this.BabelTowerLevelInfo.RoleList[i] = 0;
				}
				TrialRoleInfo? trialRoleConfig = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(num);
				if (num > 100000 && trialRoleConfig != null && trialRoleConfig.Value.Gender != (int)playerGender)
				{
					this.BabelTowerLevelInfo.RoleList[i] = 0;
				}
			}
		}
		this.RefreshView();
	}

	// Token: 0x06007BE3 RID: 31715 RVA: 0x00208185 File Offset: 0x00206385
	private void OnClickButton()
	{
		if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.MultiTeamRoleSelectView))
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MultiTeamRoleSelectView, this.GetRoleSelectViewData(), null);
		}
	}

	// Token: 0x06007BE4 RID: 31716 RVA: 0x002081B0 File Offset: 0x002063B0
	private void OnRoleChangeEnd()
	{
		EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
		RoleModel instance = ModelBase<RoleModel>.Instance;
		bool flag = false;
		for (int i = 0; i < this.BabelTowerLevelInfo.RoleList.Count; i++)
		{
			int num = this.BabelTowerLevelInfo.RoleList[i];
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(num, true);
			int roleId = (roleDataById != null) ? roleDataById.GetRoleId() : 0;
			if (instance.IsMainRole(roleId))
			{
				TrialRoleInfo? trialRoleConfig = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(num);
				if (num < 100000 || (trialRoleConfig != null && trialRoleConfig.Value.Gender != (int)playerGender))
				{
					flag = true;
					this.BabelTowerLevelInfo.RoleList[i] = 0;
				}
			}
		}
		if (!flag)
		{
			return;
		}
		List<int> list = new List<int>();
		for (int j = 0; j < this.BabelTowerLevelInfo.RoleList.Count; j++)
		{
			int num2 = this.BabelTowerLevelInfo.RoleList[j];
			if (num2 != 0)
			{
				list.Add(num2);
			}
		}
		while (list.Count < 3)
		{
			list.Add(0);
		}
		this.BabelTowerLevelInfo.RoleList = list;
	}

	// Token: 0x06007BE5 RID: 31717 RVA: 0x002082E0 File Offset: 0x002064E0
	private MultiTeamRoleSelectData GetRoleSelectViewData()
	{
		int instanceId = this.BabelTowerLevelInfo.InstanceId;
		InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
		int fightFormationId = (config != null) ? config.Value.FightFormationId : 0;
		FightFormation? fightFormationConfig = ConfigBase<EditBattleTeamConfig>.Instance.GetFightFormationConfig(fightFormationId);
		RoleInstance[] roleList = ModelBase<RoleModel>.Instance.GetRoleList();
		List<MultiTeamRoleGridData> list = new List<MultiTeamRoleGridData>();
		List<int> list2;
		if (!ControllerBase<BabelTowerController>.Instance.GetBabelTowerData().RoleLockData.TryGetValue(this.BabelTowerLevelInfo.BabelTowerLevelId, out list2))
		{
			list2 = new List<int>();
		}
		foreach (RoleInstance roleInstance in roleList)
		{
			if (roleInstance.GetRoleId() != 0)
			{
				int weaponType = roleInstance.GetRoleConfig().WeaponType;
				MultiTeamRoleGridData item = MultiTeamRoleGridData.Phrase(roleInstance, false, false, list2.Count > 0 && !list2.Contains(weaponType), false);
				list.Add(item);
			}
		}
		List<MultiTeamRoleGridData> list3 = new List<MultiTeamRoleGridData>();
		int[] array = (fightFormationConfig != null) ? fightFormationConfig.Value.GetTrialRoleArray() : Array.Empty<int>();
		EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
		IReadOnlyList<MainRoleConfig> mainRoleByGender = ConfigBase<RoleConfig>.Instance.GetMainRoleByGender((playerGender == EPlayerGender.Male) ? LoginDefine.ELoginSex.Boy : LoginDefine.ELoginSex.Girl);
		List<int> list4 = new List<int>();
		if (mainRoleByGender != null)
		{
			for (int j = 0; j < mainRoleByGender.Count; j++)
			{
				list4.Add(mainRoleByGender[j].Id);
			}
		}
		foreach (int id in array)
		{
			TrialRoleInfo? trialRoleConfigByGroupId = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfigByGroupId(id);
			if (trialRoleConfigByGroupId != null)
			{
				if (ModelBase<RoleModel>.Instance.IsMainRole(trialRoleConfigByGroupId.Value.ParentId))
				{
					bool flag = false;
					for (int l = 0; l < list4.Count; l++)
					{
						if (list4[l] == trialRoleConfigByGroupId.Value.ParentId)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						goto IL_21A;
					}
				}
				RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(trialRoleConfigByGroupId.Value.Id, true);
				if (roleDataById != null)
				{
					list3.Add(MultiTeamRoleGridData.Phrase(roleDataById, false, false, false, false));
				}
			}
			IL_21A:;
		}
		MultiTeamRoleData item2 = MultiTeamRoleData.Phrase("BossRushNormalRole", list);
		List<MultiTeamRoleData> list5 = new List<MultiTeamRoleData>();
		if (list3.Count > 0)
		{
			MultiTeamRoleData item3 = MultiTeamRoleData.Phrase("BossRushTrailRole", list3);
			list5.Add(item3);
		}
		list5.Add(item2);
		List<int> roleList2 = this.BabelTowerLevelInfo.RoleList;
		List<int> list6 = new List<int>();
		for (int m = 0; m < roleList2.Count; m++)
		{
			int num = roleList2[m];
			if (num != 0)
			{
				list6.Add(num);
			}
		}
		MultiTeamRoleSelectData result = MultiTeamRoleSelectData.Phrase(new EFilterSortGroupId?(EFilterSortGroupId.EditFormation), 3, list6.ToArray(), null, new Func<int[], bool>(this.OnCanChangeRole), new Action<int[], int[]>(this.OnEnsureFormation), null, list5, null, "BabelTeamTips_1");
		ModelBase<EditBattleTeamModel>.Instance.SetInstanceDungeonId(new int?(instanceId));
		return result;
	}

	// Token: 0x06007BE6 RID: 31718 RVA: 0x002085E0 File Offset: 0x002067E0
	private void OnEnsureFormation(int[] roleIdList, int[] tagList)
	{
		for (int i = 0; i < 3; i++)
		{
			this.BabelTowerLevelInfo.RoleList[i] = 0;
		}
		for (int j = 0; j < roleIdList.Length; j++)
		{
			int value = roleIdList[j];
			this.BabelTowerLevelInfo.RoleList[j] = value;
		}
		this.OnSelectTeamRole();
	}

	// Token: 0x06007BE7 RID: 31719 RVA: 0x00208638 File Offset: 0x00206838
	private bool OnCanChangeRole(int[] roleIdList)
	{
		List<int> list;
		if (!ControllerBase<BabelTowerController>.Instance.GetBabelTowerData().RoleLockData.TryGetValue(this.BabelTowerLevelInfo.BabelTowerLevelId, out list))
		{
			list = new List<int>();
		}
		List<int> list2 = new List<int>();
		foreach (int num in roleIdList)
		{
			if (num != 0)
			{
				int weaponType = ConfigBase<RoleConfig>.Instance.GetRoleConfig(num).Value.WeaponType;
				if (list.Count > 0 && !list.Contains(weaponType))
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BabelTowerDebuffRoleSelectionTips", Array.Empty<object>());
					return false;
				}
				int baseRoleId = ConfigBase<RoleConfig>.Instance.GetBaseRoleId(num);
				bool flag = false;
				for (int j = 0; j < list2.Count; j++)
				{
					if (list2[j] == baseRoleId)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_SameRole_Text", Array.Empty<object>());
					return false;
				}
				list2.Add(baseRoleId);
			}
		}
		return true;
	}

	// Token: 0x06007BE8 RID: 31720 RVA: 0x00208733 File Offset: 0x00206933
	private void OnSelectTeamRole()
	{
		this.RefreshLowLevelTips();
		this.RefreshTeamRole();
	}

	// Token: 0x06007BE9 RID: 31721 RVA: 0x00208744 File Offset: 0x00206944
	private void RefreshLowLevelTips()
	{
		int instanceId = this.BabelTowerLevelInfo.InstanceId;
		bool ifLevelTooLow = ModelBase<BabelTowerModel>.Instance.GetIfLevelTooLow(instanceId, this.BabelTowerLevelInfo.RoleList.ToArray());
		base.GetItem(8).SetUIActive(ifLevelTooLow);
	}

	// Token: 0x06007BEA RID: 31722 RVA: 0x00208788 File Offset: 0x00206988
	public void RefreshTeamRole()
	{
		List<int> list;
		if (!ControllerBase<BabelTowerController>.Instance.GetBabelTowerData().RoleLockData.TryGetValue(this.BabelTowerLevelInfo.BabelTowerLevelId, out list))
		{
			list = new List<int>();
		}
		List<int> roleList = this.BabelTowerLevelInfo.RoleList;
		for (int i = 0; i < roleList.Count; i++)
		{
			int num = roleList[i];
			if (num != 0)
			{
				int weaponType = ConfigBase<RoleConfig>.Instance.GetRoleConfig(num).Value.WeaponType;
				if (list.Count > 0 && !list.Contains(weaponType))
				{
					roleList[i] = 0;
				}
			}
		}
		int instanceId = this.BabelTowerLevelInfo.InstanceId;
		this.TeamItem.RefreshItem(roleList, instanceId);
	}

	// Token: 0x06007BEB RID: 31723 RVA: 0x0020883C File Offset: 0x00206A3C
	private void RefreshBuff()
	{
		List<int> buffList = this.BabelTowerLevelInfo.BuffList;
		int buffId = (buffList != null && buffList.Count > 0) ? buffList[0] : 0;
		BabelTowerLevelBuffItem babelTowerLevelBuffItem = this.BabelTowerLevelBuffItem1;
		if (babelTowerLevelBuffItem != null)
		{
			babelTowerLevelBuffItem.RefreshItem(this.BabelTowerLevelInfo.BuffCount < 1, buffId);
		}
		int buffId2 = (buffList != null && buffList.Count > 1) ? buffList[1] : 0;
		BabelTowerLevelBuffItem babelTowerLevelBuffItem2 = this.BabelTowerLevelBuffItem2;
		if (babelTowerLevelBuffItem2 == null)
		{
			return;
		}
		babelTowerLevelBuffItem2.RefreshItem(this.BabelTowerLevelInfo.BuffCount < 2, buffId2);
	}

	// Token: 0x06007BEC RID: 31724 RVA: 0x002088C4 File Offset: 0x00206AC4
	private void RefreshStar()
	{
		base.GetArtText(2).SetText(((this.BabelTowerLevelInfo.StarNumber < 10) ? "0" : "") + this.BabelTowerLevelInfo.StarNumber.ToString());
		BabelTowerLevel babelTowerLevelConfig = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(this.BabelTowerLevelInfo.BabelTowerLevelId);
		BabelTowerDifficulty? babelTowerDifficulty = ModelBase<BabelTowerModel>.Instance.CalculateDifficultyConfigByStarNum(babelTowerLevelConfig.ActivityId, this.BabelTowerLevelInfo.StarNumber);
		if (babelTowerDifficulty == null)
		{
			return;
		}
		FColor color = FColor.FromHex(babelTowerDifficulty.Value.TextBgColor);
		base.GetItem(3).SetColor(color);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), babelTowerDifficulty.Value.DifficultyTextKey, Array.Empty<object>());
	}

	// Token: 0x06007BED RID: 31725 RVA: 0x00208996 File Offset: 0x00206B96
	private void RefreshView()
	{
		this.OnSelectTeamRole();
		this.RefreshBuff();
		this.RefreshStar();
	}

	// Token: 0x06007BEE RID: 31726 RVA: 0x002089AC File Offset: 0x00206BAC
	private void OnClickConfirmBtn()
	{
		ControllerBase<BabelTowerController>.Instance.BabelTowerStartRequest(this.BabelTowerLevelInfo.InstanceId, this.BabelTowerLevelInfo.RoleList, this.BabelTowerLevelInfo.BabelTowerLevelId, this.BabelTowerLevelInfo.BuffList, ControllerBase<BabelTowerController>.Instance.BuildSkillBranchListFromRoleList(this.BabelTowerLevelInfo.RoleList));
	}

	// Token: 0x06007BEF RID: 31727 RVA: 0x00208A04 File Offset: 0x00206C04
	private void OnClickLevelDetailBtn()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.InstanceDungeonMonsterPreView, this.BabelTowerLevelInfo.InstanceId, null);
	}

	// Token: 0x06007BF0 RID: 31728 RVA: 0x00208A28 File Offset: 0x00206C28
	private void OnClickBuffItem(int clickBuffId)
	{
		BabelTowerLevel babelTowerLevelConfig = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(this.BabelTowerLevelInfo.BabelTowerLevelId);
		bool isDifficult = babelTowerLevelConfig.IsDifficult;
		List<IBabelTowerBuffInfo> list = new List<IBabelTowerBuffInfo>();
		BabelTowerData babelTowerData = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData();
		for (int i = 0; i < babelTowerLevelConfig.OptionalBabelBuffLength; i++)
		{
			int num = babelTowerLevelConfig.OptionalBabelBuff(i);
			EBabelTowerBuffState state = EBabelTowerBuffState.Normal;
			if (isDifficult)
			{
				if (babelTowerData.GetBuffIsLock(num))
				{
					state = EBabelTowerBuffState.Lock;
				}
				else
				{
					int buffIsUse = babelTowerData.GetBuffIsUse(num);
					if (buffIsUse > 0 && buffIsUse != this.BabelTowerLevelInfo.BabelTowerLevelId)
					{
						state = EBabelTowerBuffState.Use;
					}
				}
			}
			bool isRecommend = false;
			for (int j = 0; j < babelTowerLevelConfig.RecommendBuffLength; j++)
			{
				if (babelTowerLevelConfig.RecommendBuff(j) == num)
				{
					isRecommend = true;
					break;
				}
			}
			List<IBabelTowerBuffInfo> list2 = list;
			BabelTowerBuffInfo babelTowerBuffInfo = new BabelTowerBuffInfo();
			babelTowerBuffInfo.Id = num;
			babelTowerBuffInfo.State = state;
			IBabelTowerLevelInfo babelTowerLevelInfo = this.BabelTowerLevelInfo;
			babelTowerBuffInfo.LevelId = ((babelTowerLevelInfo != null) ? new int?(babelTowerLevelInfo.BabelTowerLevelId) : null);
			babelTowerBuffInfo.IsRecommend = isRecommend;
			list2.Add(babelTowerBuffInfo);
		}
		List<int> list3 = new List<int>();
		if (this.BabelTowerLevelInfo.BuffList != null)
		{
			for (int k = 0; k < this.BabelTowerLevelInfo.BuffList.Count; k++)
			{
				list3.Add(this.BabelTowerLevelInfo.BuffList[k]);
			}
		}
		BabelTowerBuffSelectViewInfo param = new BabelTowerBuffSelectViewInfo
		{
			LevelId = this.BabelTowerLevelInfo.BabelTowerLevelId,
			CurrentSelectBuffList = list3,
			ShowBuffId = clickBuffId,
			MaxSelectBuffCount = babelTowerLevelConfig.OptionalBabelBuffNum,
			AllBuffList = list,
			OnConfirmCallBack = new Action<List<int>>(this.OnBuffSelectConfirm)
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerBuffSelectView, param, null);
	}

	// Token: 0x06007BF1 RID: 31729 RVA: 0x00208BE0 File Offset: 0x00206DE0
	private void OnBuffSelectConfirm(List<int> buffList)
	{
		this.BabelTowerLevelInfo.BuffList = buffList;
		this.RefreshBuff();
	}

	// Token: 0x04003B46 RID: 15174
	private const int ROLE_TEAM_SIZE = 3;

	// Token: 0x04003B47 RID: 15175
	[Nullable(2)]
	private IBabelTowerLevelInfo BabelTowerLevelInfo;

	// Token: 0x04003B48 RID: 15176
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04003B49 RID: 15177
	[Nullable(2)]
	private BabelTowerLevelBuffItem BabelTowerLevelBuffItem1;

	// Token: 0x04003B4A RID: 15178
	[Nullable(2)]
	private BabelTowerLevelBuffItem BabelTowerLevelBuffItem2;

	// Token: 0x04003B4B RID: 15179
	[Nullable(2)]
	private BabelTowerTeamItem TeamItem;

	// Token: 0x02007596 RID: 30102
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x04028915 RID: 166165
		public const int CaptionItem = 0;

		// Token: 0x04028916 RID: 166166
		public const int LevelDetailBtn = 1;

		// Token: 0x04028917 RID: 166167
		public const int DeTermStarText = 2;

		// Token: 0x04028918 RID: 166168
		public const int HardItem = 3;

		// Token: 0x04028919 RID: 166169
		public const int HardText = 4;

		// Token: 0x0402891A RID: 166170
		public const int BuffItem1 = 5;

		// Token: 0x0402891B RID: 166171
		public const int BuffItem2 = 6;

		// Token: 0x0402891C RID: 166172
		public const int TeamItem = 7;

		// Token: 0x0402891D RID: 166173
		public const int LowLevelItem = 8;

		// Token: 0x0402891E RID: 166174
		public const int ConfirmBtn = 9;
	}
}
