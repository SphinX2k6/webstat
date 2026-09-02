using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;
using UnrealEngine;

// Token: 0x0200121D RID: 4637
[NullableContext(2)]
[Nullable(0)]
public class BabelTowerHardLevelInfoViewNew : UiViewBase
{
	// Token: 0x06007B3A RID: 31546 RVA: 0x00204330 File Offset: 0x00202530
	[NullableContext(1)]
	public BabelTowerHardLevelInfoViewNew(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06007B3B RID: 31547 RVA: 0x0020433C File Offset: 0x0020253C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnQuestBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnRankBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007B3C RID: 31548 RVA: 0x002044CB File Offset: 0x002026CB
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRoleSkillBranchInGamePlayChanged, new Action<int>(this.OnRoleSkillBranchChanged));
	}

	// Token: 0x06007B3D RID: 31549 RVA: 0x002044E9 File Offset: 0x002026E9
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnRoleSkillBranchInGamePlayChanged, new Action<int>(this.OnRoleSkillBranchChanged));
	}

	// Token: 0x06007B3E RID: 31550 RVA: 0x00204507 File Offset: 0x00202707
	protected override void OnAfterHide()
	{
		if (this.LevelInfo != null)
		{
			BabelTowerHardLevelRightItem rightItem = this.RightItem;
			if (rightItem == null)
			{
				return;
			}
			rightItem.RefreshTeamRole();
		}
	}

	// Token: 0x06007B3F RID: 31551 RVA: 0x00204524 File Offset: 0x00202724
	protected override UniTask OnBeforeStartAsync()
	{
		BabelTowerHardLevelInfoViewNew.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BabelTowerHardLevelInfoViewNew.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007B40 RID: 31552 RVA: 0x00204568 File Offset: 0x00202768
	private UniTask InitCaptionItem()
	{
		BabelTowerHardLevelInfoViewNew.<InitCaptionItem>d__12 <InitCaptionItem>d__;
		<InitCaptionItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCaptionItem>d__.<>4__this = this;
		<InitCaptionItem>d__.<>1__state = -1;
		<InitCaptionItem>d__.<>t__builder.Start<BabelTowerHardLevelInfoViewNew.<InitCaptionItem>d__12>(ref <InitCaptionItem>d__);
		return <InitCaptionItem>d__.<>t__builder.Task;
	}

	// Token: 0x06007B41 RID: 31553 RVA: 0x002045AC File Offset: 0x002027AC
	private UniTask InitRoleTeamItem()
	{
		BabelTowerHardLevelInfoViewNew.<InitRoleTeamItem>d__13 <InitRoleTeamItem>d__;
		<InitRoleTeamItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRoleTeamItem>d__.<>4__this = this;
		<InitRoleTeamItem>d__.<>1__state = -1;
		<InitRoleTeamItem>d__.<>t__builder.Start<BabelTowerHardLevelInfoViewNew.<InitRoleTeamItem>d__13>(ref <InitRoleTeamItem>d__);
		return <InitRoleTeamItem>d__.<>t__builder.Task;
	}

	// Token: 0x06007B42 RID: 31554 RVA: 0x002045F0 File Offset: 0x002027F0
	private UniTask InitStartItem()
	{
		BabelTowerHardLevelInfoViewNew.<InitStartItem>d__14 <InitStartItem>d__;
		<InitStartItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitStartItem>d__.<>4__this = this;
		<InitStartItem>d__.<>1__state = -1;
		<InitStartItem>d__.<>t__builder.Start<BabelTowerHardLevelInfoViewNew.<InitStartItem>d__14>(ref <InitStartItem>d__);
		return <InitStartItem>d__.<>t__builder.Task;
	}

	// Token: 0x06007B43 RID: 31555 RVA: 0x00204634 File Offset: 0x00202834
	private UniTask InitRightItem()
	{
		BabelTowerHardLevelInfoViewNew.<InitRightItem>d__15 <InitRightItem>d__;
		<InitRightItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRightItem>d__.<>4__this = this;
		<InitRightItem>d__.<>1__state = -1;
		<InitRightItem>d__.<>t__builder.Start<BabelTowerHardLevelInfoViewNew.<InitRightItem>d__15>(ref <InitRightItem>d__);
		return <InitRightItem>d__.<>t__builder.Task;
	}

	// Token: 0x06007B44 RID: 31556 RVA: 0x00204678 File Offset: 0x00202878
	private void InitSkillBranch()
	{
		if (this.LevelInfo == null)
		{
			return;
		}
		RoleModel instance = ModelBase<RoleModel>.Instance;
		instance.StartGamePlayRoleEdit(ESkillBranchCacheType.BabelTower);
		BabelActivityLevelInfo levelInfo = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData().GetLevelInfo(this.LevelInfo.BabelTowerLevelId);
		if (levelInfo == null)
		{
			return;
		}
		RepeatedField<int> roleSelection = levelInfo.RoleSelection;
		RepeatedField<int> skillBranchId = levelInfo.SkillBranchId;
		if (roleSelection.Count == 0 || roleSelection.Count != skillBranchId.Count)
		{
			return;
		}
		for (int i = 0; i < roleSelection.Count; i++)
		{
			instance.SetRoleSkillBranchGamePlayCache(roleSelection[i], skillBranchId[i], ESkillBranchCacheType.BabelTower);
		}
	}

	// Token: 0x06007B45 RID: 31557 RVA: 0x0020470C File Offset: 0x0020290C
	protected override void OnBeforeShow()
	{
		if (this.LevelInfo == null)
		{
			return;
		}
		this.RefreshHardBg();
		this.RefreshStarItem();
		BabelTowerHardLevelRightItem rightItem = this.RightItem;
		if (rightItem != null)
		{
			rightItem.SetLevelInfo(this.LevelInfo);
		}
		BabelTowerHardLevelRoleTeamPanel roleTeamItem = this.RoleTeamItem;
		if (roleTeamItem != null)
		{
			roleTeamItem.SetLevelInfo(this.LevelInfo);
		}
		BabelTowerHardLevelRoleTeamPanel roleTeamItem2 = this.RoleTeamItem;
		if (roleTeamItem2 != null)
		{
			roleTeamItem2.Refresh();
		}
		bool flag = !ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(this.LevelInfo.BabelTowerLevelId).IsDifficult;
		UUIButtonComponent button = base.GetButton(7);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(!flag);
	}

	// Token: 0x06007B46 RID: 31558 RVA: 0x002047B0 File Offset: 0x002029B0
	private void OnTeamSelectClick()
	{
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		BabelTowerHardLevelRoleTeamPanel roleTeamItem = this.RoleTeamItem;
		if (roleTeamItem != null)
		{
			roleTeamItem.SetUiActive(true);
		}
		BabelTowerHardLevelRoleTeamPanel roleTeamItem2 = this.RoleTeamItem;
		if (roleTeamItem2 != null)
		{
			roleTeamItem2.Refresh();
		}
		BabelTowerHardLevelRightItem rightItem = this.RightItem;
		if (rightItem == null)
		{
			return;
		}
		rightItem.SetRoleDetailBtnVisible(true);
	}

	// Token: 0x06007B47 RID: 31559 RVA: 0x00204804 File Offset: 0x00202A04
	private void OnRoleTeamRefresh()
	{
		BabelTowerHardLevelRightItem rightItem = this.RightItem;
		if (rightItem == null)
		{
			return;
		}
		rightItem.RefreshTeamRole();
	}

	// Token: 0x06007B48 RID: 31560 RVA: 0x00204816 File Offset: 0x00202A16
	private void OnSelectModeChange(EBabelTowerTeamTabType tabType)
	{
		BabelTowerHardLevelRightItem rightItem = this.RightItem;
		if (rightItem == null)
		{
			return;
		}
		rightItem.RefreshTeamRole();
	}

	// Token: 0x06007B49 RID: 31561 RVA: 0x00204828 File Offset: 0x00202A28
	private void OnRoleTeamPanelClose()
	{
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		BabelTowerHardLevelRightItem rightItem = this.RightItem;
		if (rightItem == null)
		{
			return;
		}
		rightItem.SetRoleDetailBtnVisible(false);
	}

	// Token: 0x06007B4A RID: 31562 RVA: 0x00204850 File Offset: 0x00202A50
	private void RefreshHardBg()
	{
		if (this.LevelInfo == null)
		{
			return;
		}
		BabelTowerLevel babelTowerLevelConfig = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(this.LevelInfo.BabelTowerLevelId);
		bool isDifficult = babelTowerLevelConfig.IsDifficult;
		UUITexture texture = base.GetTexture(2);
		if (texture != null)
		{
			texture.SetUIActive(isDifficult);
		}
		UUITexture texture2 = base.GetTexture(3);
		if (texture2 != null)
		{
			texture2.SetUIActive(isDifficult);
		}
		if (isDifficult && !string.IsNullOrEmpty(babelTowerLevelConfig.BossTexture))
		{
			base.SetTextureByPath(babelTowerLevelConfig.BossTexture, base.GetTexture(3), null, null);
		}
		string titleLocalText = isDifficult ? "BabelSelect_boss" : "BabelSelect_xiaoguai";
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem == null)
		{
			return;
		}
		captionItem.SetTitleLocalText(titleLocalText);
	}

	// Token: 0x06007B4B RID: 31563 RVA: 0x002048FC File Offset: 0x00202AFC
	private void RefreshStarItem()
	{
		if (this.StartItem == null || this.LevelInfo == null)
		{
			return;
		}
		this.StartItem.RefreshStar(this.LevelInfo.StarNumber);
		BabelTowerLevel babelTowerLevelConfig = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(this.LevelInfo.BabelTowerLevelId);
		BabelTowerDifficulty? babelTowerDifficulty = ModelBase<BabelTowerModel>.Instance.CalculateDifficultyConfigByStarNum(babelTowerLevelConfig.ActivityId, this.LevelInfo.StarNumber);
		if (babelTowerDifficulty != null)
		{
			BabelTowerDifficulty valueOrDefault = babelTowerDifficulty.GetValueOrDefault();
			this.StartItem.SetDifficultyBg(valueOrDefault.TextBgColor);
			this.StartItem.SetDifficultyText(valueOrDefault.DifficultyTextKey);
		}
		this.StartItem.SetDeBuffNum(ModelBase<BabelTowerModel>.Instance.GetSelectedDeTermCount());
		this.StartItem.SetNameText(babelTowerLevelConfig.NameText);
	}

	// Token: 0x06007B4C RID: 31564 RVA: 0x002049BF File Offset: 0x00202BBF
	private void OnQuestBtnClick()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerQuestView, null, null);
	}

	// Token: 0x06007B4D RID: 31565 RVA: 0x002049D2 File Offset: 0x00202BD2
	private void OnRankBtnClick()
	{
		if (this.LevelInfo != null)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerRankView, this.LevelInfo.BabelTowerLevelId, null);
		}
	}

	// Token: 0x06007B4E RID: 31566 RVA: 0x002049FC File Offset: 0x00202BFC
	private void OnLookBtnClick()
	{
		if (this.LevelInfo == null)
		{
			return;
		}
		BabelTowerLevel babelTowerLevelConfig = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(this.LevelInfo.BabelTowerLevelId);
		ModelBase<InstanceDungeonEntranceModel>.Instance.SelectInstanceId = babelTowerLevelConfig.InstId;
		InstanceDungeonMonsterView.InstanceDungeonMonsterViewOpenParam param = new InstanceDungeonMonsterView.InstanceDungeonMonsterViewOpenParam
		{
			InstanceId = babelTowerLevelConfig.InstId,
			InfoType = null
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.InstanceDungeonMonsterPreView, param, null);
	}

	// Token: 0x06007B4F RID: 31567 RVA: 0x00204A6C File Offset: 0x00202C6C
	private void OnRoleSkillBranchChanged(int roleId)
	{
		BabelTowerHardLevelRoleTeamPanel roleTeamItem = this.RoleTeamItem;
		if (roleTeamItem != null)
		{
			roleTeamItem.RefreshRoleSkillBranch(roleId);
		}
		BabelTowerHardLevelRightItem rightItem = this.RightItem;
		if (rightItem == null)
		{
			return;
		}
		rightItem.RefreshSkillBranchIcon();
	}

	// Token: 0x04003B0D RID: 15117
	private PopupCaptionItem CaptionItem;

	// Token: 0x04003B0E RID: 15118
	private BabelTowerHardLevelStarItem StartItem;

	// Token: 0x04003B0F RID: 15119
	private BabelTowerHardLevelRightItem RightItem;

	// Token: 0x04003B10 RID: 15120
	private BabelTowerHardLevelRoleTeamPanel RoleTeamItem;

	// Token: 0x04003B11 RID: 15121
	private IBabelTowerLevelInfo LevelInfo;

	// Token: 0x02007579 RID: 30073
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402888D RID: 166029
		public const int CaptionItem = 0;

		// Token: 0x0402888E RID: 166030
		public const int QuestBtn = 1;

		// Token: 0x0402888F RID: 166031
		public const int HardBg = 2;

		// Token: 0x04028890 RID: 166032
		public const int BossBg = 3;

		// Token: 0x04028891 RID: 166033
		public const int StartItem = 4;

		// Token: 0x04028892 RID: 166034
		public const int RightItem = 5;

		// Token: 0x04028893 RID: 166035
		public const int RoleTeamItem = 6;

		// Token: 0x04028894 RID: 166036
		public const int RankBtn = 7;
	}
}
