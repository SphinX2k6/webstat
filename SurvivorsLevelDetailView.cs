using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002B47 RID: 11079
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsLevelDetailView : UiViewBase
{
	// Token: 0x0601616A RID: 90474 RVA: 0x00620ECB File Offset: 0x0061F0CB
	public SurvivorsLevelDetailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601616B RID: 90475 RVA: 0x00620F00 File Offset: 0x0061F100
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIText)),
			new ValueTuple<int, Type>(13, typeof(UUIText)),
			new ValueTuple<int, Type>(14, typeof(UUIText)),
			new ValueTuple<int, Type>(15, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(16, typeof(UUIText)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(19, typeof(UUIItem)),
			new ValueTuple<int, Type>(20, typeof(UUIText)),
			new ValueTuple<int, Type>(21, typeof(UUIItem)),
			new ValueTuple<int, Type>(22, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(23, typeof(UUIItem)),
			new ValueTuple<int, Type>(24, typeof(UUIItem)),
			new ValueTuple<int, Type>(25, typeof(UUIItem)),
			new ValueTuple<int, Type>(26, typeof(UUIItem)),
			new ValueTuple<int, Type>(27, typeof(UUITexture)),
			new ValueTuple<int, Type>(28, typeof(UUITexture)),
			new ValueTuple<int, Type>(29, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(30, typeof(UUIText)),
			new ValueTuple<int, Type>(31, typeof(UUIItem)),
			new ValueTuple<int, Type>(32, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(15, new Action<EToggleState>(this.OnClickTogEndless))
		};
	}

	// Token: 0x0601616C RID: 90476 RVA: 0x0062122C File Offset: 0x0061F42C
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsLevelDetailView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsLevelDetailView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601616D RID: 90477 RVA: 0x00621270 File Offset: 0x0061F470
	protected override void OnStart()
	{
		SurvivorsActivityDefine.SurvivorsLevelInfo selectLevelInfo = ModelBase<SurvivorsRogueModel>.Instance.SelectLevelInfo;
		SurvivorsLevel? survivorsLevel = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsLevel(selectLevelInfo.LevelId);
		this.CachedLevelId = selectLevelInfo.LevelId;
		this.InitializeCaption();
		this.UpdateLevelName(survivorsLevel.Value.Name);
		this.InitializeNormalBgAndTag(survivorsLevel.Value.Diff);
		this.RefreshLeftBottomArea(survivorsLevel.Value.GetInitRolesArray(), survivorsLevel.Value.GetInitWeaponsArray());
		ActivityFunctionalTypeA functionArea = this.FunctionArea;
		if (((functionArea != null) ? functionArea.FunctionButton : null) != null)
		{
			this.FunctionArea.FunctionButton.SetFunction(new Action(this.OnClickFunctionButton));
		}
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.SequenceFinish), false);
		this.RefreshEndlessToggle();
	}

	// Token: 0x0601616E RID: 90478 RVA: 0x00621358 File Offset: 0x0061F558
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
	}

	// Token: 0x0601616F RID: 90479 RVA: 0x00621374 File Offset: 0x0061F574
	private void InitializeNormalBgAndTag(int diff)
	{
		int[][] array = new int[][]
		{
			new int[]
			{
				0,
				5
			},
			new int[]
			{
				1,
				7
			},
			new int[]
			{
				2,
				9
			}
		};
		for (int i = 0; i < array.Length; i++)
		{
			int[] array2 = array[i];
			UUIItem item = base.GetItem(array2[0]);
			UUIItem item2 = base.GetItem(array2[1]);
			if (i == diff)
			{
				this.CachedNormalBackground = item;
				this.CachedNormalTag = item2;
			}
			if (item != null)
			{
				item.SetUIActive(i == diff);
			}
			if (item2 != null)
			{
				item2.SetUIActive(i == diff);
			}
		}
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(this.bgTexturePath[diff]);
		base.SetTextureShowUntilLoaded(resourcePath, base.GetTexture(28), null);
	}

	// Token: 0x06016170 RID: 90480 RVA: 0x00621435 File Offset: 0x0061F635
	private CommonItemSmallItemGrid CreateRewardGrid()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x06016171 RID: 90481 RVA: 0x0062143C File Offset: 0x0061F63C
	private WeaponItemComponent CreateWeaponGrid()
	{
		return new WeaponItemComponent();
	}

	// Token: 0x06016172 RID: 90482 RVA: 0x00621443 File Offset: 0x0061F643
	private void OnClickFunctionButton()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SurvivorsTeamEditView, null, null);
	}

	// Token: 0x06016173 RID: 90483 RVA: 0x00621458 File Offset: 0x0061F658
	private void OnClickTogEndless(EToggleState state)
	{
		if (!this.CachedEndlessEnable)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(15);
			if (extendToggle != null)
			{
				extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, true);
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Survivors_EndlessDisableTips", Array.Empty<object>());
			return;
		}
		if (state != EToggleState.ETT_Checked)
		{
			this.SetEndlessMode(false);
			return;
		}
		if (this.CheckIsRecordedSwitchOn())
		{
			this.SetEndlessMode(true);
			return;
		}
		UUIExtendToggle toggle = base.GetExtendToggle(15);
		UUIExtendToggle toggle3 = toggle;
		if (toggle3 != null)
		{
			toggle3.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, true);
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.SurvivorsLevelFirstEndlessConfirm);
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			UUIExtendToggle toggle2 = toggle;
			if (toggle2 != null)
			{
				toggle2.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
			}
			this.SetEndlessMode(true);
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06016174 RID: 90484 RVA: 0x00621514 File Offset: 0x0061F714
	private void OnClickClose()
	{
		base.CloseMe(null);
	}

	// Token: 0x06016175 RID: 90485 RVA: 0x00621520 File Offset: 0x0061F720
	private void InitializeCaption()
	{
		PopupCaptionItem captionComp = this.CaptionComp;
		if (captionComp != null)
		{
			captionComp.SetCloseCallBack(new Action(this.OnClickClose));
		}
		PopupCaptionItem captionComp2 = this.CaptionComp;
		if (captionComp2 != null)
		{
			captionComp2.SetHelpCallBack(delegate
			{
				ControllerBase<SurvivorsRogueController>.Instance.OpenRogueHelp();
			});
		}
		SurvivorsActivityData activityData = ModelBase<SurvivorsRogueModel>.Instance.ActivityData;
		Activity? activity = (activityData != null) ? activityData.LocalConfig : null;
		if (activity != null)
		{
			PopupCaptionItem captionComp3 = this.CaptionComp;
			if (captionComp3 == null)
			{
				return;
			}
			captionComp3.SetTitleLocalText(activity.Value.Title);
		}
	}

	// Token: 0x06016176 RID: 90486 RVA: 0x006215C4 File Offset: 0x0061F7C4
	private void SetEndlessMode(bool isEndless)
	{
		SurvivorsLevel? survivorsLevel = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsLevel(this.CachedLevelId);
		if (survivorsLevel == null)
		{
			return;
		}
		SurvivorsActivityData activityData = ModelBase<SurvivorsRogueModel>.Instance.ActivityData;
		if (activityData != null)
		{
			activityData.SaveCacheState(ESurvivorsActivitySaveFlags.EndlessMode, this.CachedLevelId, 0, (isEndless > false) ? 1 : 0);
		}
		SurvivorsActivityDefine.SurvivorsLevelInfo selectLevelInfo = ModelBase<SurvivorsRogueModel>.Instance.SelectLevelInfo;
		selectLevelInfo.IsEndless = isEndless;
		int j = (isEndless > false) ? 1 : 0;
		this.UpdateLevelDesc(survivorsLevel.Value.InstDesc(j).Value.Value);
		this.UpdateLevelTarget(survivorsLevel.Value.TargetDesc(j).Value.Value, selectLevelInfo.LevelId, isEndless);
		this.UpdateToggleTextColor(isEndless);
		this.UpdateLevelTag(isEndless);
		this.PlayEndlessSwitchAnimation(isEndless);
		this.RefreshRewardByDropPackage(survivorsLevel.Value.RewardId(j), ModelBase<SurvivorsRogueModel>.Instance.ActivityData.GetCurrentLevelInfoByLevelId(selectLevelInfo.LevelId).Info.IsFinish);
	}

	// Token: 0x06016177 RID: 90487 RVA: 0x006216C8 File Offset: 0x0061F8C8
	private void PlayEndlessSwitchAnimation(bool isEndless)
	{
		if (isEndless)
		{
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(true);
			}
		}
		else
		{
			UUIItem cachedNormalBackground = this.CachedNormalBackground;
			if (cachedNormalBackground != null)
			{
				cachedNormalBackground.SetUIActive(true);
			}
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, false);
		}
		LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
		if (levelSequencePlayer2 == null)
		{
			return;
		}
		levelSequencePlayer2.PlayLevelSequenceByName(isEndless ? "Switch1" : "Switch2", false, null, false);
	}

	// Token: 0x06016178 RID: 90488 RVA: 0x0062173C File Offset: 0x0061F93C
	private void SequenceFinish(string name)
	{
		if (!(name == "Switch1"))
		{
			if (name == "Switch2")
			{
				UUIItem item = base.GetItem(3);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(false);
			}
			return;
		}
		UUIItem cachedNormalBackground = this.CachedNormalBackground;
		if (cachedNormalBackground == null)
		{
			return;
		}
		cachedNormalBackground.SetUIActive(false);
	}

	// Token: 0x06016179 RID: 90489 RVA: 0x0062177C File Offset: 0x0061F97C
	private void UpdateLevelName(string titleId)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), titleId, Array.Empty<object>());
	}

	// Token: 0x0601617A RID: 90490 RVA: 0x00621795 File Offset: 0x0061F995
	private void UpdateEndlessToggleEnable(bool isEnable)
	{
		this.CachedEndlessEnable = isEnable;
		UUITexture texture = base.GetTexture(27);
		if (texture != null)
		{
			texture.SetUIActive(!isEnable);
		}
		UUIItem item = base.GetItem(32);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(isEnable);
	}

	// Token: 0x0601617B RID: 90491 RVA: 0x006217C8 File Offset: 0x0061F9C8
	private void RefreshLeftBottomArea(IReadOnlyList<int> survivorsRoleIdList, IReadOnlyList<int> survivorsWeaponIdList)
	{
		bool flag = this.RefreshRoleHead(survivorsRoleIdList);
		GenericScrollViewNew<WeaponItemComponent, int> weaponItemScroll = this.WeaponItemScroll;
		if (weaponItemScroll != null)
		{
			weaponItemScroll.RefreshByData(survivorsWeaponIdList.ToList<int>(), null, false);
		}
		bool uiactive = flag || survivorsWeaponIdList.Count > 0;
		UUIItem item = base.GetItem(31);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(uiactive);
	}

	// Token: 0x0601617C RID: 90492 RVA: 0x00621818 File Offset: 0x0061FA18
	private bool RefreshRoleHead(IReadOnlyList<int> survivorsRoleIdList)
	{
		for (int i = 0; i < survivorsRoleIdList.Count; i++)
		{
			int num = survivorsRoleIdList[i];
			SurvivorsActivityData activityData = ModelBase<SurvivorsRogueModel>.Instance.ActivityData;
			if (activityData != null && activityData.IsRoleIdCanShow(num))
			{
				RoleItemComponent roleHeadComp = this.RoleHeadComp;
				if (roleHeadComp != null)
				{
					roleHeadComp.SetUiActive(true);
				}
				RoleItemComponent roleHeadComp2 = this.RoleHeadComp;
				if (roleHeadComp2 != null)
				{
					roleHeadComp2.Refresh(num);
				}
				return true;
			}
		}
		RoleItemComponent roleHeadComp3 = this.RoleHeadComp;
		if (roleHeadComp3 != null)
		{
			roleHeadComp3.SetUiActive(false);
		}
		return false;
	}

	// Token: 0x0601617D RID: 90493 RVA: 0x00621890 File Offset: 0x0061FA90
	public void RefreshRewardByDropPackage(int dropPackageId, bool isCleared)
	{
		List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(dropPackageId);
		this.RewardLoopScroll.RefreshByData(dropPackagePreviewItemList, delegate
		{
			List<CommonItemSmallItemGrid> scrollItemList = this.RewardLoopScroll.GetScrollItemList();
			for (int i = 0; i < scrollItemList.Count; i++)
			{
				scrollItemList[i].SetReceivedVisible(isCleared);
			}
		}, false);
	}

	// Token: 0x0601617E RID: 90494 RVA: 0x006218D8 File Offset: 0x0061FAD8
	private void RefreshEndlessToggle()
	{
		SurvivorsActivityDefine.SurvivorsLevelInfo selectLevelInfo = ModelBase<SurvivorsRogueModel>.Instance.SelectLevelInfo;
		SurvivorsLevel? survivorsLevel = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsLevel(selectLevelInfo.LevelId);
		if (!survivorsLevel.Value.EndlessMode)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(15);
			if (extendToggle != null)
			{
				extendToggle.RootUIComp.Get().SetUIActive(false);
			}
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.SurvivorsRogueLevelDetailViewEndlessToggleRefresh, false);
		}
		else
		{
			bool levelUnlockState = ModelBase<SurvivorsRogueModel>.Instance.ActivityData.GetLevelUnlockState(selectLevelInfo.LevelId, true);
			this.UpdateEndlessToggleEnable(levelUnlockState);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.SurvivorsRogueLevelDetailViewEndlessToggleRefresh, levelUnlockState);
		}
		bool flag = ModelBase<SurvivorsRogueModel>.Instance.ActivityData.IsEndlessMode(selectLevelInfo.LevelId);
		UUIExtendToggle extendToggle2 = base.GetExtendToggle(15);
		if (extendToggle2 != null)
		{
			extendToggle2.SetToggleStateForce(flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, true);
		}
		this.SetEndlessMode(flag);
		if (survivorsLevel.Value.Diff >= 2 || flag)
		{
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_xingcunzhe_leveldetail_open_difficult");
			return;
		}
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_xingcunzhe_leveldetail_open_normal");
	}

	// Token: 0x0601617F RID: 90495 RVA: 0x006219ED File Offset: 0x0061FBED
	private void UpdateLevelDesc(string descId)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(14), descId, Array.Empty<object>());
	}

	// Token: 0x06016180 RID: 90496 RVA: 0x00621A08 File Offset: 0x0061FC08
	private void UpdateLevelTarget(string targetDescId, int levelId, bool isEndless)
	{
		List<string> list = new List<string>();
		ISurvivorsLevelInfo currentLevelInfoByLevelId = ModelBase<SurvivorsRogueModel>.Instance.ActivityData.GetCurrentLevelInfoByLevelId(levelId);
		if (isEndless)
		{
			list.Add(currentLevelInfoByLevelId.Info.KillMonsterCount.ToString());
		}
		else
		{
			int maxWaveNumByLevelId = ConfigBase<SurvivorsRogueConfig>.Instance.GetMaxWaveNumByLevelId(levelId);
			list.Add(currentLevelInfoByLevelId.Info.WaveId.ToString());
			list.Add(maxWaveNumByLevelId.ToString());
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(13), targetDescId, list.ToArray());
	}

	// Token: 0x06016181 RID: 90497 RVA: 0x00621A98 File Offset: 0x0061FC98
	private void UpdateToggleTextColor(bool bUseChangeColor)
	{
		UUIText text = base.GetText(16);
		if (text != null)
		{
			UUIItem uuiitem = text;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		}
	}

	// Token: 0x06016182 RID: 90498 RVA: 0x00621AC6 File Offset: 0x0061FCC6
	private void UpdateLevelTag(bool isEndless)
	{
		UUIItem cachedNormalTag = this.CachedNormalTag;
		if (cachedNormalTag != null)
		{
			cachedNormalTag.SetUIActive(!isEndless);
		}
		UUIItem item = base.GetItem(11);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(isEndless);
	}

	// Token: 0x06016183 RID: 90499 RVA: 0x00621AF0 File Offset: 0x0061FCF0
	private bool CheckIsRecordedSwitchOn()
	{
		return ModelBase<SurvivorsRogueModel>.Instance.ActivityData.SaveCacheState(ESurvivorsActivitySaveFlags.EndlessFirstCheck, 0, 0, 1);
	}

	// Token: 0x0400AA4D RID: 43597
	private readonly string[] bgTexturePath = new string[]
	{
		"UiTexture_SurvivorsLevelDetailBg1",
		"UiTexture_SurvivorsLevelDetailBg2",
		"UiTexture_SurvivorsLevelDetailBg3"
	};

	// Token: 0x0400AA4E RID: 43598
	private int CachedLevelId = -1;

	// Token: 0x0400AA4F RID: 43599
	private bool CachedEndlessEnable;

	// Token: 0x0400AA50 RID: 43600
	[Nullable(2)]
	private UUIItem CachedNormalBackground;

	// Token: 0x0400AA51 RID: 43601
	[Nullable(2)]
	private UUIItem CachedNormalTag;

	// Token: 0x0400AA52 RID: 43602
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400AA53 RID: 43603
	[Nullable(2)]
	private ActivityFunctionalTypeA FunctionArea;

	// Token: 0x0400AA54 RID: 43604
	[Nullable(2)]
	private PopupCaptionItem CaptionComp;

	// Token: 0x0400AA55 RID: 43605
	[Nullable(2)]
	private RoleItemComponent RoleHeadComp;

	// Token: 0x0400AA56 RID: 43606
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<WeaponItemComponent, int> WeaponItemScroll;

	// Token: 0x0400AA57 RID: 43607
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardLoopScroll;
}
