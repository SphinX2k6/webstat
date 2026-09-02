using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200121E RID: 4638
[NullableContext(2)]
[Nullable(0)]
public class BabelTowerHardLevelRightItem : UiPanelBase
{
	// Token: 0x06007B51 RID: 31569 RVA: 0x00204A9C File Offset: 0x00202C9C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 13;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(12, new Action(this.OnStartBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(11, new Action(this.OnRoleDetailBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnRoleTagBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007B52 RID: 31570 RVA: 0x00204CFC File Offset: 0x00202EFC
	protected override UniTask OnBeforeStartAsync()
	{
		BabelTowerHardLevelRightItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BabelTowerHardLevelRightItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007B53 RID: 31571 RVA: 0x00204D40 File Offset: 0x00202F40
	private UniTask InitBuffItems()
	{
		BabelTowerHardLevelRightItem.<InitBuffItems>d__8 <InitBuffItems>d__;
		<InitBuffItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitBuffItems>d__.<>4__this = this;
		<InitBuffItems>d__.<>1__state = -1;
		<InitBuffItems>d__.<>t__builder.Start<BabelTowerHardLevelRightItem.<InitBuffItems>d__8>(ref <InitBuffItems>d__);
		return <InitBuffItems>d__.<>t__builder.Task;
	}

	// Token: 0x06007B54 RID: 31572 RVA: 0x00204D84 File Offset: 0x00202F84
	private UniTask InitTeamItem()
	{
		BabelTowerHardLevelRightItem.<InitTeamItem>d__9 <InitTeamItem>d__;
		<InitTeamItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitTeamItem>d__.<>4__this = this;
		<InitTeamItem>d__.<>1__state = -1;
		<InitTeamItem>d__.<>t__builder.Start<BabelTowerHardLevelRightItem.<InitTeamItem>d__9>(ref <InitTeamItem>d__);
		return <InitTeamItem>d__.<>t__builder.Task;
	}

	// Token: 0x06007B55 RID: 31573 RVA: 0x00204DC8 File Offset: 0x00202FC8
	[NullableContext(1)]
	public void SetLevelInfo(IBabelTowerLevelInfo levelInfo)
	{
		this.LevelInfo = levelInfo;
		BabelTowerLevel babelTowerLevelConfig = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(this.LevelInfo.BabelTowerLevelId);
		bool isDifficult = babelTowerLevelConfig.IsDifficult;
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(isDifficult);
		}
		UUIItem item2 = base.GetItem(0);
		if (item2 != null)
		{
			item2.SetUIActive(!isDifficult);
		}
		UUIItem item3 = base.GetItem(4);
		if (item3 != null)
		{
			item3.SetUIActive(isDifficult);
		}
		if (isDifficult && !string.IsNullOrEmpty(babelTowerLevelConfig.BossTitleTexture))
		{
			base.SetTextureByPath(babelTowerLevelConfig.BossTitleTexture, base.GetTexture(3), null, null);
		}
		if (isDifficult && !string.IsNullOrEmpty(babelTowerLevelConfig.BossNameText) && !StringUtils.IsBlank(babelTowerLevelConfig.BossNameText))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), babelTowerLevelConfig.BossNameText, Array.Empty<object>());
		}
		if (!string.IsNullOrEmpty(babelTowerLevelConfig.LevelDesText) && !StringUtils.IsBlank(babelTowerLevelConfig.LevelDesText))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), babelTowerLevelConfig.LevelDesText, Array.Empty<object>());
		}
		this.RefreshBuff();
		this.RefreshTeamRole();
	}

	// Token: 0x06007B56 RID: 31574 RVA: 0x00204EE8 File Offset: 0x002030E8
	public void RefreshTeamRole()
	{
		if (this.LevelInfo == null)
		{
			return;
		}
		List<int> roleList = this.LevelInfo.RoleList;
		List<int> list = new List<int>();
		int num = 0;
		for (;;)
		{
			int num2 = num;
			int? babel_TOWER_TEAM_ROLE_SLOT_COUNT = BabelTowerDefine.BABEL_TOWER_TEAM_ROLE_SLOT_COUNT;
			if (!(num2 < babel_TOWER_TEAM_ROLE_SLOT_COUNT.GetValueOrDefault() & babel_TOWER_TEAM_ROLE_SLOT_COUNT != null))
			{
				break;
			}
			int item = (num < roleList.Count) ? roleList[num] : 0;
			list.Add(item);
			num++;
		}
		this.TeamItem.RefreshItem(list, this.LevelInfo.InstanceId);
		this.RefreshLowLevelTips();
		bool uiactive = ControllerBase<BabelTowerController>.Instance.BuildSkillBranchListFromRoleList(roleList).Any((int branchId) => branchId > 0);
		base.GetButton(10).RootUIComp.Get().SetUIActive(uiactive);
	}

	// Token: 0x06007B57 RID: 31575 RVA: 0x00204FBC File Offset: 0x002031BC
	private void RefreshLowLevelTips()
	{
		if (this.LevelInfo == null)
		{
			return;
		}
		bool ifLevelTooLow = ModelBase<BabelTowerModel>.Instance.GetIfLevelTooLow(this.LevelInfo.InstanceId, this.LevelInfo.RoleList.ToArray());
		UUIItem item = base.GetItem(9);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(ifLevelTooLow);
	}

	// Token: 0x06007B58 RID: 31576 RVA: 0x0020500C File Offset: 0x0020320C
	public void SetRoleDetailBtnVisible(bool visible)
	{
		UUIButtonComponent button = base.GetButton(11);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(visible);
	}

	// Token: 0x06007B59 RID: 31577 RVA: 0x00205039 File Offset: 0x00203239
	public void RefreshSkillBranchIcon()
	{
		BabelTowerTeamItem teamItem = this.TeamItem;
		if (teamItem == null)
		{
			return;
		}
		teamItem.RefreshSkillBranchIcon();
	}

	// Token: 0x06007B5A RID: 31578 RVA: 0x0020504C File Offset: 0x0020324C
	private void RefreshBuff()
	{
		List<int> buffList = this.LevelInfo.BuffList;
		int buffId = (buffList != null && buffList.Count > 0) ? buffList[0] : 0;
		BabelTowerLevelBuffItem buffItem = this.BuffItem1;
		if (buffItem != null)
		{
			buffItem.RefreshItem(this.LevelInfo.BuffCount < 1, buffId);
		}
		int buffId2 = (buffList != null && buffList.Count > 1) ? buffList[1] : 0;
		BabelTowerLevelBuffItem buffItem2 = this.BuffItem2;
		if (buffItem2 == null)
		{
			return;
		}
		buffItem2.RefreshItem(this.LevelInfo.BuffCount < 2, buffId2);
	}

	// Token: 0x06007B5B RID: 31579 RVA: 0x002050D4 File Offset: 0x002032D4
	private void OnBuffItemClick(int buffId)
	{
		BabelTowerLevel babelTowerLevelConfig = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(this.LevelInfo.BabelTowerLevelId);
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
					if (buffIsUse > 0 && buffIsUse != this.LevelInfo.BabelTowerLevelId)
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
			BabelTowerBuffInfo babelTowerBuffInfo = new BabelTowerBuffInfo();
			babelTowerBuffInfo.Id = num;
			babelTowerBuffInfo.State = state;
			IBabelTowerLevelInfo levelInfo = this.LevelInfo;
			babelTowerBuffInfo.LevelId = ((levelInfo != null) ? new int?(levelInfo.BabelTowerLevelId) : null);
			babelTowerBuffInfo.IsRecommend = isRecommend;
			BabelTowerBuffInfo item = babelTowerBuffInfo;
			list.Add(item);
		}
		BabelTowerBuffSelectViewInfo param = new BabelTowerBuffSelectViewInfo
		{
			LevelId = this.LevelInfo.BabelTowerLevelId,
			CurrentSelectBuffList = new List<int>(this.LevelInfo.BuffList),
			ShowBuffId = buffId,
			MaxSelectBuffCount = babelTowerLevelConfig.OptionalBabelBuffNum,
			AllBuffList = list,
			OnConfirmCallBack = new Action<List<int>>(this.OnBuffSelectConfirm)
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerBuffSelectView, param, null);
	}

	// Token: 0x06007B5C RID: 31580 RVA: 0x00205252 File Offset: 0x00203452
	[NullableContext(1)]
	private void OnBuffSelectConfirm(List<int> buffList)
	{
		this.LevelInfo.BuffList = buffList;
		this.RefreshBuff();
	}

	// Token: 0x06007B5D RID: 31581 RVA: 0x00205266 File Offset: 0x00203466
	private void OnTeamBtnClick()
	{
		Action onClickBattleTeamCallBack = this.OnClickBattleTeamCallBack;
		if (onClickBattleTeamCallBack == null)
		{
			return;
		}
		onClickBattleTeamCallBack();
	}

	// Token: 0x06007B5E RID: 31582 RVA: 0x00205278 File Offset: 0x00203478
	private void OnStartBtnClick()
	{
		ControllerBase<BabelTowerController>.Instance.BabelTowerStartRequest(this.LevelInfo.InstanceId, this.LevelInfo.RoleList, this.LevelInfo.BabelTowerLevelId, this.LevelInfo.BuffList, ControllerBase<BabelTowerController>.Instance.BuildSkillBranchListFromRoleList(this.LevelInfo.RoleList));
	}

	// Token: 0x06007B5F RID: 31583 RVA: 0x002052D0 File Offset: 0x002034D0
	private void OnRoleDetailBtnClick()
	{
		IBabelTowerLevelInfo levelInfo = this.LevelInfo;
		List<int> list;
		if (levelInfo == null)
		{
			list = null;
		}
		else
		{
			list = (from id in levelInfo.RoleList
			where id > 0
			select id).ToList<int>();
		}
		List<int> list2 = list ?? new List<int>();
		int num = (list2.Count > 0) ? list2[list2.Count - 1] : 0;
		List<int> roleDetailRoleIdList = this.GetRoleDetailRoleIdList(num, list2);
		ControllerBase<RoleController>.Instance.OpenRoleMainViewByParam(new OpenRoleMainViewData
		{
			AgentType = ERoleAgentType.Normal,
			SelectRoleId = new int?(num),
			RoleIdList = roleDetailRoleIdList,
			TeamPositionType = new ETeamPositionType?(ETeamPositionType.EditFormation),
			Source = new ERoleViewSource?(ERoleViewSource.BabelTower)
		});
	}

	// Token: 0x06007B60 RID: 31584 RVA: 0x00205388 File Offset: 0x00203588
	private void OnRoleTagBtnClick()
	{
		RoleSkillBranchPopViewParams roleSkillBranchPopViewParams = new RoleSkillBranchPopViewParams();
		RoleSkillBranchPopViewParams roleSkillBranchPopViewParams2 = roleSkillBranchPopViewParams;
		int[][] array = new int[1][];
		int num = 0;
		IBabelTowerLevelInfo levelInfo = this.LevelInfo;
		array[num] = (((levelInfo != null) ? levelInfo.RoleList.ToArray() : null) ?? Array.Empty<int>());
		roleSkillBranchPopViewParams2.Load(array);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleSkillBranchPopView, roleSkillBranchPopViewParams, null);
	}

	// Token: 0x06007B61 RID: 31585 RVA: 0x002053DC File Offset: 0x002035DC
	[NullableContext(1)]
	private List<int> GetRoleDetailRoleIdList(int selectRoleId, List<int> currentRoleList)
	{
		if (selectRoleId >= 100000)
		{
			return this.CollectTrialRoleIds();
		}
		HashSet<int> hashSet = new HashSet<int>(currentRoleList);
		foreach (int item in ModelBase<RoleModel>.Instance.GetRoleIdList())
		{
			hashSet.Add(item);
		}
		return hashSet.ToList<int>();
	}

	// Token: 0x06007B62 RID: 31586 RVA: 0x00205450 File Offset: 0x00203650
	[NullableContext(1)]
	private List<int> CollectTrialRoleIds()
	{
		int fightFormationId = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(this.LevelInfo.InstanceId).Value.FightFormationId;
		FightFormation? fightFormationConfig = ConfigBase<EditBattleTeamConfig>.Instance.GetFightFormationConfig(fightFormationId);
		int[] array = (fightFormationConfig != null) ? fightFormationConfig.Value.GetTrialRoleArray() : Array.Empty<int>();
		List<int> list = new List<int>();
		foreach (int id in array)
		{
			TrialRoleInfo? trialRoleConfigByGroupId = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfigByGroupId(id);
			if (trialRoleConfigByGroupId != null)
			{
				RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(trialRoleConfigByGroupId.Value.Id, true);
				if (roleDataById != null)
				{
					list.Add(roleDataById.GetDataId());
				}
			}
		}
		return new HashSet<int>(list).ToList<int>();
	}

	// Token: 0x04003B12 RID: 15122
	public Action OnClickBattleTeamCallBack;

	// Token: 0x04003B13 RID: 15123
	private BabelTowerLevelBuffItem BuffItem1;

	// Token: 0x04003B14 RID: 15124
	private BabelTowerLevelBuffItem BuffItem2;

	// Token: 0x04003B15 RID: 15125
	private BabelTowerTeamItem TeamItem;

	// Token: 0x04003B16 RID: 15126
	private IBabelTowerLevelInfo LevelInfo;

	// Token: 0x0200757F RID: 30079
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x040288A9 RID: 166057
		public const int ActivatItem = 0;

		// Token: 0x040288AA RID: 166058
		public const int BossInfoItem = 1;

		// Token: 0x040288AB RID: 166059
		public const int BossNameText = 2;

		// Token: 0x040288AC RID: 166060
		public const int BossSprityBg = 3;

		// Token: 0x040288AD RID: 166061
		public const int MechanismItem = 4;

		// Token: 0x040288AE RID: 166062
		public const int MechanismDesText = 5;

		// Token: 0x040288AF RID: 166063
		public const int EntryOneItem = 6;

		// Token: 0x040288B0 RID: 166064
		public const int EntryTwoItem = 7;

		// Token: 0x040288B1 RID: 166065
		public const int BattleTeamItem = 8;

		// Token: 0x040288B2 RID: 166066
		public const int RedText = 9;

		// Token: 0x040288B3 RID: 166067
		public const int RoleTagBtn = 10;

		// Token: 0x040288B4 RID: 166068
		public const int RoleDetailBtn = 11;

		// Token: 0x040288B5 RID: 166069
		public const int StartBtn = 12;
	}
}
