using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Quest;
using AkiClient.Game.Aki.Render.RuntimeBP.Interaction;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020025C7 RID: 9671
[NullableContext(2)]
[Nullable(0)]
public class FightPhotoOptionPanel : UiPanelBase
{
	// Token: 0x06012E71 RID: 77425 RVA: 0x0053A820 File Offset: 0x00538A20
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUISprite))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(7, new Action<EToggleState>(this.OnHideMonsterToggleClick))
		};
	}

	// Token: 0x06012E72 RID: 77426 RVA: 0x0053A9C4 File Offset: 0x00538BC4
	protected override UniTask OnBeforeStartAsync()
	{
		FightPhotoOptionPanel.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FightPhotoOptionPanel.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012E73 RID: 77427 RVA: 0x0053AA08 File Offset: 0x00538C08
	public UniTask RefreshTabLayout()
	{
		FightPhotoOptionPanel.<RefreshTabLayout>d__15 <RefreshTabLayout>d__;
		<RefreshTabLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshTabLayout>d__.<>4__this = this;
		<RefreshTabLayout>d__.<>1__state = -1;
		<RefreshTabLayout>d__.<>t__builder.Start<FightPhotoOptionPanel.<RefreshTabLayout>d__15>(ref <RefreshTabLayout>d__);
		return <RefreshTabLayout>d__.<>t__builder.Task;
	}

	// Token: 0x06012E74 RID: 77428 RVA: 0x0053AA4C File Offset: 0x00538C4C
	private void RefreshTabContent(EFightPhotoTab tab)
	{
		ModelBase<FightPhotoModel>.Instance.SelectedTab = new EFightPhotoTab?(tab);
		FightPhotoMissionPanel missionPanel = this.MissionPanel;
		if (missionPanel != null)
		{
			missionPanel.SetUiActive(tab == EFightPhotoTab.Mission);
		}
		FightPhotoFilterPanel filterPanel = this.FilterPanel;
		if (filterPanel != null)
		{
			filterPanel.SetUiActive(tab == EFightPhotoTab.Filter);
		}
		FightPhotoSettingPanel settingPanel = this.SettingPanel;
		if (settingPanel != null)
		{
			settingPanel.SetUiActive(tab == EFightPhotoTab.Setting);
		}
		FightPhotoFramePanel framePanel = this.FramePanel;
		if (framePanel != null)
		{
			framePanel.SetUiActive(tab == EFightPhotoTab.Frame);
		}
		this.CurrentTabPanel = this.GetTabPanel(tab);
		FightPhotoTabPanelBase currentTabPanel = this.CurrentTabPanel;
		if (currentTabPanel == null)
		{
			return;
		}
		currentTabPanel.PlaySwitchAnim();
	}

	// Token: 0x06012E75 RID: 77429 RVA: 0x0053AADA File Offset: 0x00538CDA
	private FightPhotoTabPanelBase GetTabPanel(EFightPhotoTab tab)
	{
		switch (tab)
		{
		case EFightPhotoTab.Mission:
			return this.MissionPanel;
		case EFightPhotoTab.Filter:
			return this.FilterPanel;
		case EFightPhotoTab.Setting:
			return this.SettingPanel;
		case EFightPhotoTab.Frame:
			return this.FramePanel;
		default:
			return null;
		}
	}

	// Token: 0x06012E76 RID: 77430 RVA: 0x0053AB13 File Offset: 0x00538D13
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnChangeFightPhotoOption, new Action(this.OnFrameOptionChanged));
		Singleton<EventSystem>.Instance.Add(EEventName.UIViewPortSizeChanged, new Action(this.OnViewPortSizeChanged));
	}

	// Token: 0x06012E77 RID: 77431 RVA: 0x0053AB4C File Offset: 0x00538D4C
	public void RefreshMissionState()
	{
		TakePicturesWithTimeScaleChildQuestNode currentBtNode = ControllerBase<PhotographController>.Instance.CurrentBtNode;
		if (currentBtNode == null)
		{
			UUISprite sprite = base.GetSprite(15);
			if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
			if (!this.IsShowingNoMission)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "FightPhoto_NoMission", Array.Empty<object>());
				this.IsShowingNoMission = true;
				this.LastFinishedCount = -1;
				this.LastTotalCount = -1;
			}
			return;
		}
		this.IsShowingNoMission = false;
		FightPhotoModel instance = ModelBase<FightPhotoModel>.Instance;
		IPhotographCondition photographCondition = currentBtNode.PhotographCondition;
		bool flag = instance.CheckRoleInCamera(photographCondition);
		bool flag2 = instance.CheckPhotographCondition(photographCondition);
		if (currentBtNode.InProgress)
		{
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetUIActive(!flag);
			}
			UUIItem item2 = base.GetItem(5);
			if (item2 != null)
			{
				item2.SetUIActive(flag2 && this.IsDefaultFrame());
			}
		}
		int num = 0;
		int num2 = 0;
		if (photographCondition != null)
		{
			num++;
			if (flag && flag2)
			{
				num2++;
			}
		}
		ICameraCondition cameraCondition = currentBtNode.CameraCondition;
		if (cameraCondition != null)
		{
			num++;
			if (instance.CheckCameraCondition(cameraCondition))
			{
				num2++;
			}
		}
		if (num2 == this.LastFinishedCount && num == this.LastTotalCount)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "FightPhoto_Mission_Progress", new <>z__ReadOnlyArray<object>(new object[]
		{
			num2,
			num
		}));
		if (this.LastFinishedCount != -1 && num2 > this.LastFinishedCount)
		{
			this.PlaySequence("Sweep");
		}
		this.LastFinishedCount = num2;
		this.LastTotalCount = num;
	}

	// Token: 0x06012E78 RID: 77432 RVA: 0x0053ACD0 File Offset: 0x00538ED0
	[NullableContext(1)]
	private void PlaySequence(string sequenceName)
	{
		if (this.SequencePlayer == null)
		{
			this.SequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		}
		this.SequencePlayer.StopCurrentSequence(false, true);
		this.SequencePlayer.PlayLevelSequenceByName(sequenceName, false, null, false);
	}

	// Token: 0x06012E79 RID: 77433 RVA: 0x0053AD1C File Offset: 0x00538F1C
	protected override void OnBeforeHide()
	{
		this.SetAllMonsterVisible(true);
		this.LastFinishedCount = -1;
		this.LastTotalCount = -1;
		this.IsShowingNoMission = false;
		Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeFightPhotoOption, new Action(this.OnFrameOptionChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.UIViewPortSizeChanged, new Action(this.OnViewPortSizeChanged));
	}

	// Token: 0x06012E7A RID: 77434 RVA: 0x0053AD7A File Offset: 0x00538F7A
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.Clear();
		}
		this.SequencePlayer = null;
	}

	// Token: 0x06012E7B RID: 77435 RVA: 0x0053AD94 File Offset: 0x00538F94
	private void SetAllMonsterVisible(bool isVisible)
	{
		if (this.MonsterEntityHandleList.Count == 0)
		{
			int value = ConfigCommonParamById.GetIntConfig("FightPhotoHideMonsterDistance").Value;
			ModelBase<CreatureModel>.Instance.GetEntitiesInRange((float)value, EEntityTypeQuery.PasserbyNPC | EEntityTypeQuery.Boss, this.MonsterEntityHandleList, true, false);
		}
		foreach (EntityHandle entityHandle in this.MonsterEntityHandleList)
		{
			if (entityHandle != null && entityHandle.Valid && entityHandle.Entity != null && entityHandle.Entity.Valid && entityHandle.Entity.Active != isVisible)
			{
				if (isVisible)
				{
					int handle;
					if (this.HandleToDisableIdMap.TryGetValue(entityHandle, out handle))
					{
						entityHandle.Entity.Enable(handle, "FightPhotoOptionPanel.OnHideMonsterToggleClick");
						this.HandleToDisableIdMap.Remove(entityHandle);
					}
				}
				else
				{
					int value2 = entityHandle.Entity.Disable("[FightPhotoOptionPanel.OnHideMonsterToggleClick] state为false");
					this.HandleToDisableIdMap.Add(entityHandle, value2);
				}
			}
		}
	}

	// Token: 0x06012E7C RID: 77436 RVA: 0x0053AEA8 File Offset: 0x005390A8
	public void RefreshCondition()
	{
		TakePicturesWithTimeScaleChildQuestNode currentBtNode = ControllerBase<PhotographController>.Instance.CurrentBtNode;
		if (currentBtNode == null || !currentBtNode.InProgress)
		{
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(6);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
		}
		FightPhotoMissionPanel missionPanel = this.MissionPanel;
		if (missionPanel != null)
		{
			missionPanel.RefreshCondition().Forget();
		}
		this.RefreshMissionState();
	}

	// Token: 0x06012E7D RID: 77437 RVA: 0x0053AF10 File Offset: 0x00539110
	public void RefreshTip()
	{
		bool uiactive = ControllerBase<PhotographController>.Instance.IsFinishCurrentBtNode();
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(uiactive);
		}
		string textStringId = ControllerBase<PhotographController>.Instance.IsFightPhotoCanSettle() ? "PrefabTextItem_4294734977_Text" : "FightPhotoFinishTips";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), textStringId, Array.Empty<object>());
	}

	// Token: 0x06012E7E RID: 77438 RVA: 0x0053AF6B File Offset: 0x0053916B
	public void SetTipVisible(bool isVisible)
	{
		UUIItem item = base.GetItem(3);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(isVisible);
	}

	// Token: 0x06012E7F RID: 77439 RVA: 0x0053AF7F File Offset: 0x0053917F
	[NullableContext(1)]
	private FightPhotoTabItem CreateTabItem()
	{
		return new FightPhotoTabItem
		{
			OnToggleClick = new Action<EFightPhotoTab>(this.OnTabClick)
		};
	}

	// Token: 0x06012E80 RID: 77440 RVA: 0x0053AF98 File Offset: 0x00539198
	private void OnTabClick(EFightPhotoTab tab)
	{
		this.TabLayout.SelectGridProxyByKey(tab, false);
		this.RefreshTabContent(tab);
	}

	// Token: 0x06012E81 RID: 77441 RVA: 0x0053AFB3 File Offset: 0x005391B3
	private void OnHideMonsterToggleClick(EToggleState toggleState)
	{
		this.SetAllMonsterVisible(toggleState == EToggleState.ETT_UnChecked);
	}

	// Token: 0x06012E82 RID: 77442 RVA: 0x0053AFBF File Offset: 0x005391BF
	private void OnFrameSwitched()
	{
		this.PlaySequence("FrameIn");
	}

	// Token: 0x06012E83 RID: 77443 RVA: 0x0053AFCC File Offset: 0x005391CC
	public void SetHideAreaActive(bool bVisible)
	{
		UUIItem item = base.GetItem(12);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(bVisible);
	}

	// Token: 0x06012E84 RID: 77444 RVA: 0x0053AFE4 File Offset: 0x005391E4
	public void ApplyFrameStyle(FightPhotoFrameStyle config)
	{
		UUIItem item = base.GetItem(10);
		if (item != null)
		{
			item.SetUIActive(config.ShowDecoration);
		}
		bool flag = config.Mode == 2;
		UUIItem item2 = base.GetItem(11);
		if (item2 != null)
		{
			item2.SetUIActive(flag);
		}
		UUIItem item3 = base.GetItem(8);
		if (item3 != null)
		{
			item3.SetUIActive(flag);
		}
		if (!flag)
		{
			return;
		}
		ValueTuple<float, float, float, float> valueTuple = ModelBase<FightPhotoModel>.Instance.CalcFrameRect(config.AspectRatio, config.ScreenRatio);
		UUIItem item4 = base.GetItem(11);
		if (item4 != null)
		{
			item4.SetWidth(valueTuple.Item1);
			item4.SetHeight(valueTuple.Item2);
			UUIItem uuiitem = item4;
			FRotator frotator = new FRotator(0f, config.RotationAngle * 360f, 0f);
			uuiitem.SetUIRelativeRotation(frotator);
		}
		BP_CameraShot_C cameraShotActor = ControllerBase<FightPhotoController>.Instance.GetCameraShotActor();
		UUIItem item5 = base.GetItem(13);
		UUIItem item6 = base.GetItem(14);
		if (cameraShotActor != null && (item5 != null || item6 != null))
		{
			FVector2D viewportSize = UWidgetLayoutLibrary.GetViewportSize(GlobalData.World);
			float viewportScale = UWidgetLayoutLibrary.GetViewportScale(GlobalData.World);
			float num = viewportSize.X / viewportScale;
			float num2 = viewportSize.Y / viewportScale;
			if (item5 != null)
			{
				cameraShotActor.Line1X = Math.Abs(item5.RelativeLocation.X) / num;
				cameraShotActor.Line1Y = Math.Abs(item5.RelativeLocation.Y) / num2;
			}
			if (item6 != null)
			{
				cameraShotActor.Line2X = -Math.Abs(item6.RelativeLocation.X) / num;
				cameraShotActor.Line2Y = Math.Abs(item6.RelativeLocation.Y) / num2;
			}
			cameraShotActor.SetParameter();
		}
	}

	// Token: 0x06012E85 RID: 77445 RVA: 0x0053B17C File Offset: 0x0053937C
	private void OnFrameOptionChanged()
	{
		int? fightPhotoExtraOption = ModelBase<FightPhotoModel>.Instance.GetFightPhotoExtraOption(EFightPhotoExtraOptionType.Frame);
		if (fightPhotoExtraOption != null)
		{
			int? num = fightPhotoExtraOption;
			int num2 = 0;
			if (!(num.GetValueOrDefault() == num2 & num != null))
			{
				FightPhotoFrameStyle? fightPhotoFrameStyleConfigById = ConfigBase<PhotographConfig>.Instance.GetFightPhotoFrameStyleConfigById(fightPhotoExtraOption.Value);
				if (fightPhotoFrameStyleConfigById == null)
				{
					return;
				}
				this.ApplyFrameStyle(fightPhotoFrameStyleConfigById.Value);
				if (!this.IsDefaultFrame())
				{
					UUIItem item = base.GetItem(5);
					if (item == null)
					{
						return;
					}
					item.SetUIActive(false);
				}
				return;
			}
		}
	}

	// Token: 0x06012E86 RID: 77446 RVA: 0x0053B1FA File Offset: 0x005393FA
	private void OnViewPortSizeChanged()
	{
		ControllerBase<PhotographController>.Instance.ReapplyCurrentFrame();
		this.OnFrameOptionChanged();
	}

	// Token: 0x06012E87 RID: 77447 RVA: 0x0053B20C File Offset: 0x0053940C
	private bool IsDefaultFrame()
	{
		int? fightPhotoExtraOption = ModelBase<FightPhotoModel>.Instance.GetFightPhotoExtraOption(EFightPhotoExtraOptionType.Frame);
		if (fightPhotoExtraOption != null)
		{
			int? num = fightPhotoExtraOption;
			int num2 = 0;
			if (!(num.GetValueOrDefault() == num2 & num != null))
			{
				FightPhotoFrameStyle? fightPhotoFrameStyleConfigById = ConfigBase<PhotographConfig>.Instance.GetFightPhotoFrameStyleConfigById(fightPhotoExtraOption.Value);
				return fightPhotoFrameStyleConfigById == null || fightPhotoFrameStyleConfigById.Value.Mode == 0;
			}
		}
		return true;
	}

	// Token: 0x06012E88 RID: 77448 RVA: 0x0053B278 File Offset: 0x00539478
	[NullableContext(1)]
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length == 0)
		{
			return null;
		}
		if (configParams[0] == "HideEnemy")
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(7);
			UUIItem uuiitem = (extendToggle != null) ? extendToggle.GetRootComponent() : null;
			UUIItem guideUiItem = base.GetGuideUiItem("2");
			if (uuiitem != null && guideUiItem != null)
			{
				return new UUIItem[]
				{
					uuiitem,
					guideUiItem
				};
			}
		}
		if (!(configParams[0] == "FightPhotoTab"))
		{
			return null;
		}
		int num = int.Parse(configParams[1]);
		GenericLayout<FightPhotoTabItem, EFightPhotoTab> tabLayout = this.TabLayout;
		UUIItem uuiitem2 = (tabLayout != null) ? tabLayout.GetItemByIndex(num - 1) : null;
		if (uuiitem2 == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uuiitem2,
			uuiitem2
		};
	}

	// Token: 0x040093AC RID: 37804
	[Nullable(1)]
	private readonly List<EntityHandle> MonsterEntityHandleList = new List<EntityHandle>();

	// Token: 0x040093AD RID: 37805
	[Nullable(1)]
	private readonly Dictionary<EntityHandle, int> HandleToDisableIdMap = new Dictionary<EntityHandle, int>();

	// Token: 0x040093AE RID: 37806
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<FightPhotoTabItem, EFightPhotoTab> TabLayout;

	// Token: 0x040093AF RID: 37807
	private FightPhotoMissionPanel MissionPanel;

	// Token: 0x040093B0 RID: 37808
	private FightPhotoFilterPanel FilterPanel;

	// Token: 0x040093B1 RID: 37809
	private FightPhotoSettingPanel SettingPanel;

	// Token: 0x040093B2 RID: 37810
	private FightPhotoFramePanel FramePanel;

	// Token: 0x040093B3 RID: 37811
	private FightPhotoTabPanelBase CurrentTabPanel;

	// Token: 0x040093B4 RID: 37812
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x040093B5 RID: 37813
	private int LastFinishedCount = -1;

	// Token: 0x040093B6 RID: 37814
	private int LastTotalCount = -1;

	// Token: 0x040093B7 RID: 37815
	private bool IsShowingNoMission;

	// Token: 0x0200892D RID: 35117
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x0402E48A RID: 189578
		LayoutTab,
		// Token: 0x0402E48B RID: 189579
		ItemTab,
		// Token: 0x0402E48C RID: 189580
		ItemContent,
		// Token: 0x0402E48D RID: 189581
		ItemTip,
		// Token: 0x0402E48E RID: 189582
		TextTip,
		// Token: 0x0402E48F RID: 189583
		ItemFrame,
		// Token: 0x0402E490 RID: 189584
		ItemFrameTip,
		// Token: 0x0402E491 RID: 189585
		ToggleHideMonster,
		// Token: 0x0402E492 RID: 189586
		ItemPhotoFrame,
		// Token: 0x0402E493 RID: 189587
		TextTitle,
		// Token: 0x0402E494 RID: 189588
		ItemDeco,
		// Token: 0x0402E495 RID: 189589
		ItemPhotoFrameParent,
		// Token: 0x0402E496 RID: 189590
		ItemHidePanel,
		// Token: 0x0402E497 RID: 189591
		ItemPointLeft,
		// Token: 0x0402E498 RID: 189592
		ItemPointTop,
		// Token: 0x0402E499 RID: 189593
		SpriteMissionLine
	}
}
