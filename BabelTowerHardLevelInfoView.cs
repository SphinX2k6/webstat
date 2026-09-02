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

// Token: 0x0200121C RID: 4636
[NullableContext(1)]
[Nullable(0)]
public class BabelTowerHardLevelInfoView : UiViewBase
{
	// Token: 0x06007B25 RID: 31525 RVA: 0x00203447 File Offset: 0x00201647
	public BabelTowerHardLevelInfoView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06007B26 RID: 31526 RVA: 0x00203450 File Offset: 0x00201650
	protected unsafe override void OnRegisterComponent()
	{
		int num = 13;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickConfirmBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickLevelDetailBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007B27 RID: 31527 RVA: 0x0020368C File Offset: 0x0020188C
	protected override UniTask OnBeforeStartAsync()
	{
		BabelTowerHardLevelInfoView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BabelTowerHardLevelInfoView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007B28 RID: 31528 RVA: 0x002036CF File Offset: 0x002018CF
	protected override void OnStart()
	{
		this.BabelTowerLevelInfo = (this.OpenParam as IBabelTowerLevelInfo);
		base.GetItem(12).SetUIActive(true);
		Singleton<EventSystem>.Instance.Add(EEventName.OnRoleChangeEnd, new Action(this.OnRoleChangeEnd));
	}

	// Token: 0x06007B29 RID: 31529 RVA: 0x0020370C File Offset: 0x0020190C
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleChangeEnd, new Action(this.OnRoleChangeEnd));
	}

	// Token: 0x06007B2A RID: 31530 RVA: 0x0020372C File Offset: 0x0020192C
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

	// Token: 0x06007B2B RID: 31531 RVA: 0x0020380D File Offset: 0x00201A0D
	private void OnClickButton()
	{
		if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.MultiTeamRoleSelectView))
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MultiTeamRoleSelectView, this.GetRoleSelectViewData(), null);
		}
	}

	// Token: 0x06007B2C RID: 31532 RVA: 0x00203838 File Offset: 0x00201A38
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

	// Token: 0x06007B2D RID: 31533 RVA: 0x00203968 File Offset: 0x00201B68
	private MultiTeamRoleSelectData GetRoleSelectViewData()
	{
		int instanceId = this.BabelTowerLevelInfo.InstanceId;
		BabelTowerLevel babelTowerLevelConfig = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(this.BabelTowerLevelInfo.BabelTowerLevelId);
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
				bool isUnRecommend = false;
				for (int j = 0; j < babelTowerLevelConfig.UnRecommendRoleListLength; j++)
				{
					if (babelTowerLevelConfig.UnRecommendRoleList(j) == roleInstance.GetRoleId())
					{
						isUnRecommend = true;
						break;
					}
				}
				MultiTeamRoleGridData item = MultiTeamRoleGridData.Phrase(roleInstance, false, false, list2.Count > 0 && !list2.Contains(weaponType), isUnRecommend);
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
			for (int k = 0; k < mainRoleByGender.Count; k++)
			{
				list4.Add(mainRoleByGender[k].Id);
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
					for (int m = 0; m < list4.Count; m++)
					{
						if (list4[m] == trialRoleConfigByGroupId.Value.ParentId)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						goto IL_268;
					}
				}
				RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(trialRoleConfigByGroupId.Value.Id, true);
				if (roleDataById != null)
				{
					list3.Add(MultiTeamRoleGridData.Phrase(roleDataById, false, false, false, false));
				}
			}
			IL_268:;
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
		for (int n = 0; n < roleList2.Count; n++)
		{
			int num = roleList2[n];
			if (num != 0)
			{
				list6.Add(num);
			}
		}
		int[] array2 = new int[babelTowerLevelConfig.UnRecommendRoleListLength];
		for (int num2 = 0; num2 < babelTowerLevelConfig.UnRecommendRoleListLength; num2++)
		{
			array2[num2] = babelTowerLevelConfig.UnRecommendRoleList(num2);
		}
		MultiTeamRoleSelectData result = MultiTeamRoleSelectData.Phrase(new EFilterSortGroupId?(EFilterSortGroupId.EditFormation), 3, list6.ToArray(), null, new Func<int[], bool>(this.OnCanChangeRole), new Action<int[], int[]>(this.OnEnsureFormation), null, list5, array2, "BabelTeamTips_1");
		ModelBase<EditBattleTeamModel>.Instance.SetInstanceDungeonId(new int?(instanceId));
		return result;
	}

	// Token: 0x06007B2E RID: 31534 RVA: 0x00203CE8 File Offset: 0x00201EE8
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

	// Token: 0x06007B2F RID: 31535 RVA: 0x00203D40 File Offset: 0x00201F40
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

	// Token: 0x06007B30 RID: 31536 RVA: 0x00203E3B File Offset: 0x0020203B
	private void OnSelectTeamRole()
	{
		this.RefreshLowLevelTips();
		this.RefreshTeamRole();
	}

	// Token: 0x06007B31 RID: 31537 RVA: 0x00203E4C File Offset: 0x0020204C
	private void RefreshLowLevelTips()
	{
		int instanceId = this.BabelTowerLevelInfo.InstanceId;
		bool ifLevelTooLow = ModelBase<BabelTowerModel>.Instance.GetIfLevelTooLow(instanceId, this.BabelTowerLevelInfo.RoleList.ToArray());
		base.GetItem(5).SetUIActive(ifLevelTooLow);
	}

	// Token: 0x06007B32 RID: 31538 RVA: 0x00203E90 File Offset: 0x00202090
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

	// Token: 0x06007B33 RID: 31539 RVA: 0x00203F44 File Offset: 0x00202144
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

	// Token: 0x06007B34 RID: 31540 RVA: 0x00203FCC File Offset: 0x002021CC
	private void RefreshStar()
	{
		base.GetText(10).SetText(((this.BabelTowerLevelInfo.StarNumber < 10) ? "0" : "") + this.BabelTowerLevelInfo.StarNumber.ToString(), true);
		BabelTowerLevel babelTowerLevelConfig = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(this.BabelTowerLevelInfo.BabelTowerLevelId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), babelTowerLevelConfig.NameText, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), babelTowerLevelConfig.LevelDesText, Array.Empty<object>());
		base.SetTextureByPath(babelTowerLevelConfig.BossTexture, base.GetTexture(8), null, null);
		BabelTowerDifficulty? babelTowerDifficulty = ModelBase<BabelTowerModel>.Instance.CalculateDifficultyConfigByStarNum(babelTowerLevelConfig.ActivityId, this.BabelTowerLevelInfo.StarNumber);
		if (babelTowerDifficulty == null)
		{
			return;
		}
		base.GetItem(11).SetUIActive(babelTowerDifficulty.Value.DifficultyId >= 2);
	}

	// Token: 0x06007B35 RID: 31541 RVA: 0x002040D3 File Offset: 0x002022D3
	private void RefreshView()
	{
		this.OnSelectTeamRole();
		this.RefreshBuff();
		this.RefreshStar();
	}

	// Token: 0x06007B36 RID: 31542 RVA: 0x002040E8 File Offset: 0x002022E8
	private void OnClickConfirmBtn()
	{
		ControllerBase<BabelTowerController>.Instance.BabelTowerStartRequest(this.BabelTowerLevelInfo.InstanceId, this.BabelTowerLevelInfo.RoleList, this.BabelTowerLevelInfo.BabelTowerLevelId, this.BabelTowerLevelInfo.BuffList, ControllerBase<BabelTowerController>.Instance.BuildSkillBranchListFromRoleList(this.BabelTowerLevelInfo.RoleList));
	}

	// Token: 0x06007B37 RID: 31543 RVA: 0x00204140 File Offset: 0x00202340
	private void OnClickLevelDetailBtn()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.InstanceDungeonMonsterPreView, this.BabelTowerLevelInfo.InstanceId, null);
	}

	// Token: 0x06007B38 RID: 31544 RVA: 0x00204164 File Offset: 0x00202364
	private void OnClickBuffItem(int buffId)
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
			ShowBuffId = buffId,
			MaxSelectBuffCount = babelTowerLevelConfig.OptionalBabelBuffNum,
			AllBuffList = list,
			OnConfirmCallBack = new Action<List<int>>(this.OnBuffSelectConfirm)
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerBuffSelectView, param, null);
	}

	// Token: 0x06007B39 RID: 31545 RVA: 0x0020431C File Offset: 0x0020251C
	private void OnBuffSelectConfirm(List<int> buffList)
	{
		this.BabelTowerLevelInfo.BuffList = buffList;
		this.RefreshBuff();
	}

	// Token: 0x04003B07 RID: 15111
	private const int ROLE_TEAM_SIZE = 3;

	// Token: 0x04003B08 RID: 15112
	[Nullable(2)]
	private IBabelTowerLevelInfo BabelTowerLevelInfo;

	// Token: 0x04003B09 RID: 15113
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04003B0A RID: 15114
	[Nullable(2)]
	private BabelTowerLevelBuffItem BabelTowerLevelBuffItem1;

	// Token: 0x04003B0B RID: 15115
	[Nullable(2)]
	private BabelTowerLevelBuffItem BabelTowerLevelBuffItem2;

	// Token: 0x04003B0C RID: 15116
	[Nullable(2)]
	private BabelTowerTeamItem TeamItem;

	// Token: 0x02007577 RID: 30071
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402887C RID: 166012
		public const int CaptionItem = 0;

		// Token: 0x0402887D RID: 166013
		public const int LevelDetailBtn = 1;

		// Token: 0x0402887E RID: 166014
		public const int BuffItem1 = 2;

		// Token: 0x0402887F RID: 166015
		public const int BuffItem2 = 3;

		// Token: 0x04028880 RID: 166016
		public const int TeamItem = 4;

		// Token: 0x04028881 RID: 166017
		public const int LowLevelItem = 5;

		// Token: 0x04028882 RID: 166018
		public const int ConfirmBtn = 6;

		// Token: 0x04028883 RID: 166019
		public const int LevelTitleText = 7;

		// Token: 0x04028884 RID: 166020
		public const int BossTexture = 8;

		// Token: 0x04028885 RID: 166021
		public const int DesText = 9;

		// Token: 0x04028886 RID: 166022
		public const int StarText = 10;

		// Token: 0x04028887 RID: 166023
		public const int HighestItem = 11;

		// Token: 0x04028888 RID: 166024
		public const int NormalItem = 12;
	}
}
