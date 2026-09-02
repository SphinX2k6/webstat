using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C2E RID: 7214
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchDungeonSelectView : UiViewBase
{
	// Token: 0x0600D1CF RID: 53711 RVA: 0x0037B4BD File Offset: 0x003796BD
	public FloroRanchDungeonSelectView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600D1D0 RID: 53712 RVA: 0x0037B4D4 File Offset: 0x003796D4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(USpineSkeletonAnimationComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnStartBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnCloseBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D1D1 RID: 53713 RVA: 0x0037B6EC File Offset: 0x003798EC
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchDungeonSelectView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchDungeonSelectView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D1D2 RID: 53714 RVA: 0x0037B730 File Offset: 0x00379930
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<int>>(EEventName.FloroRanchRaceRedDot, new Action<IReadOnlyList<int>>(this.RefreshRaceList));
		Singleton<EventSystem>.Instance.Add<EFloroRanchActivityDataType, int>(EEventName.FloroRanchSkillChange, new Action<EFloroRanchActivityDataType, int>(this.OnSkillChange));
		Singleton<EventSystem>.Instance.Add<EFloroRanchActivityDataType>(EEventName.FloroRanchSkillRedDotRefresh, new Action<EFloroRanchActivityDataType>(this.OnSkillRedDotRefresh));
	}

	// Token: 0x0600D1D3 RID: 53715 RVA: 0x0037B794 File Offset: 0x00379994
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.FloroRanchRaceRedDot, new Action<IReadOnlyList<int>>(this.RefreshRaceList));
		Singleton<EventSystem>.Instance.Remove(EEventName.FloroRanchSkillChange, new Action<EFloroRanchActivityDataType, int>(this.OnSkillChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.FloroRanchSkillRedDotRefresh, new Action<EFloroRanchActivityDataType>(this.OnSkillRedDotRefresh));
	}

	// Token: 0x0600D1D4 RID: 53716 RVA: 0x0037B7F5 File Offset: 0x003799F5
	private void RefreshView(FloroRanchDungeonData dungeonData)
	{
		this.RefreshView(dungeonData, null);
	}

	// Token: 0x0600D1D5 RID: 53717 RVA: 0x0037B800 File Offset: 0x00379A00
	private void RefreshView(FloroRanchDungeonData dungeonData, [Nullable(2)] FloroRanchSubDungeonData subDungeonData = null)
	{
		this.DungeonScrollLayout.LateScrollTo(this.DungeonScrollLayout.GetItemByKey(dungeonData.Id), null, false);
		GenericScrollViewNew<FloroRanchDungeonItem, FloroRanchDungeonData> dungeonScrollLayout = this.DungeonScrollLayout;
		FloroRanchDungeonItem scrollItemByKey = this.DungeonScrollLayout.GetScrollItemByKey(dungeonData.Id);
		dungeonScrollLayout.SelectGridProxy((scrollItemByKey != null) ? scrollItemByKey.GridIndex : 0, false);
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(dungeonData.IsUnLock);
		}
		FloroRanchDungeonSelectRightPanel rightPanel = this.RightPanel;
		if (rightPanel != null)
		{
			rightPanel.RefreshDungeonInfo(dungeonData, subDungeonData);
		}
		UUIButtonComponent button = base.GetButton(2);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(dungeonData.IsUnLock);
		}
		if (!dungeonData.IsUnLock)
		{
			UUIItem item2 = base.GetItem(10);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
		}
	}

	// Token: 0x0600D1D6 RID: 53718 RVA: 0x0037B8C9 File Offset: 0x00379AC9
	public void RefreshRaceList(IReadOnlyList<int> raceIds)
	{
		this.RaceIds = raceIds.ToList<int>();
		FloroRanchDungeonSelectRightPanel rightPanel = this.RightPanel;
		if (rightPanel == null)
		{
			return;
		}
		rightPanel.RefreshRaceList(raceIds);
	}

	// Token: 0x0600D1D7 RID: 53719 RVA: 0x0037B8E8 File Offset: 0x00379AE8
	public void RefreshSkillItem(int skillId)
	{
		this.SkillId = skillId;
		FloroRanchSkillItem skillItem = this.SkillItem;
		if (skillItem == null)
		{
			return;
		}
		skillItem.Refresh(skillId);
	}

	// Token: 0x0600D1D8 RID: 53720 RVA: 0x0037B902 File Offset: 0x00379B02
	public void RefreshSkillItemRedDot()
	{
		FloroRanchSkillItem skillItem = this.SkillItem;
		if (skillItem == null)
		{
			return;
		}
		skillItem.RefreshRedDot();
	}

	// Token: 0x0600D1D9 RID: 53721 RVA: 0x0037B914 File Offset: 0x00379B14
	private void OnSkillChange(EFloroRanchActivityDataType activityDataType, int skillId)
	{
		if (activityDataType != EFloroRanchActivityDataType.Normal)
		{
			return;
		}
		this.RefreshSkillItem(skillId);
	}

	// Token: 0x0600D1DA RID: 53722 RVA: 0x0037B921 File Offset: 0x00379B21
	private void OnSkillRedDotRefresh(EFloroRanchActivityDataType activityDataType)
	{
		if (activityDataType != EFloroRanchActivityDataType.Normal)
		{
			return;
		}
		this.RefreshSkillItemRedDot();
	}

	// Token: 0x0600D1DB RID: 53723 RVA: 0x0037B930 File Offset: 0x00379B30
	private void SetSubDungeonId(int subDungeonId)
	{
		this.SubDungeonId = subDungeonId;
		FloroRanchSubDungeonData floroRanchSubDungeonData = this.ActivityData.GetFloroRanchSubDungeonData(subDungeonId);
		this.RaceIds = floroRanchSubDungeonData.SelectedRaceIds;
		UUIButtonComponent button = base.GetButton(2);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(floroRanchSubDungeonData.IsUnLock);
		}
		UUIItem item = base.GetItem(10);
		if (item != null)
		{
			item.SetUIActive(!floroRanchSubDungeonData.IsUnLock);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "FloroRanchDayNum", new <>z__ReadOnlySingleElementList<object>(floroRanchSubDungeonData.MaxDays));
		int maxCoin = floroRanchSubDungeonData.MaxCoin;
		string coinText = ModelBase<FloroRanchModel>.Instance.GetCoinText(maxCoin);
		UUIText text = base.GetText(6);
		if (text != null)
		{
			text.SetText(coinText, true);
		}
		UUIItem item2 = base.GetItem(4);
		if (item2 != null)
		{
			item2.SetUIActive(floroRanchSubDungeonData.HasHistory);
		}
		if (!floroRanchSubDungeonData.IsUnLock)
		{
			string conditionGroupHintText = LevelGeneralCommons.GetConditionGroupHintText(floroRanchSubDungeonData.ConditionId);
			FunctionalPanelConditionLock panelLock = this.PanelLock;
			if (panelLock == null)
			{
				return;
			}
			panelLock.SetTextByTextId(conditionGroupHintText, Array.Empty<string>());
		}
	}

	// Token: 0x0600D1DC RID: 53724 RVA: 0x0037BA2F File Offset: 0x00379C2F
	private FloroRanchDungeonItem CreateDungeonItem()
	{
		FloroRanchDungeonItem floroRanchDungeonItem = new FloroRanchDungeonItem();
		floroRanchDungeonItem.SetToggleCallBack(new Action<FloroRanchDungeonData>(this.RefreshView));
		return floroRanchDungeonItem;
	}

	// Token: 0x0600D1DD RID: 53725 RVA: 0x0037BA48 File Offset: 0x00379C48
	private void OnCloseBtnClick()
	{
		if (this.IsStartClick)
		{
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x0600D1DE RID: 53726 RVA: 0x0037BA5C File Offset: 0x00379C5C
	private void OnStartBtnClick()
	{
		if (this.IsStartClick)
		{
			return;
		}
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Farm_ConnectBan", Array.Empty<object>());
			return;
		}
		if (this.RaceIds.Contains(0))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Farm_ChooseRace", Array.Empty<object>());
			return;
		}
		if (this.SkillId == 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Farm_ChooseSkill", Array.Empty<object>());
			return;
		}
		this.IsStartClick = true;
		UUIButtonComponent button = base.GetButton(2);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(false);
		}
		UUIItem item = base.GetItem(11);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		ControllerBase<FloroRanchController>.Instance.SendFloroRanchStartPlayRequest(this.ActivityData.Id, this.SubDungeonId, this.RaceIds.ToArray(), new int?(this.SkillId), delegate(FloroRanchStartPlayResponse _)
		{
			this.IsStartClick = false;
			UUIButtonComponent button2 = base.GetButton(2);
			if (button2 != null)
			{
				button2.RootUIComp.Get().SetUIActive(true);
			}
			UUIItem item2 = base.GetItem(11);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			base.CloseMe(null);
		});
	}

	// Token: 0x0600D1DF RID: 53727 RVA: 0x0037BB4B File Offset: 0x00379D4B
	protected override void OnBeforeDestroy()
	{
		this.IsStartClick = false;
	}

	// Token: 0x04006415 RID: 25621
	[Nullable(2)]
	private global::FloroRanchActivityData ActivityData;

	// Token: 0x04006416 RID: 25622
	private int SubDungeonId;

	// Token: 0x04006417 RID: 25623
	private int SkillId;

	// Token: 0x04006418 RID: 25624
	private List<int> RaceIds = new List<int>();

	// Token: 0x04006419 RID: 25625
	private GenericScrollViewNew<FloroRanchDungeonItem, FloroRanchDungeonData> DungeonScrollLayout;

	// Token: 0x0400641A RID: 25626
	[Nullable(2)]
	private FloroRanchDungeonSelectRightPanel RightPanel;

	// Token: 0x0400641B RID: 25627
	[Nullable(2)]
	private FunctionalPanelConditionLock PanelLock;

	// Token: 0x0400641C RID: 25628
	[Nullable(2)]
	private FloroRanchSkillItem SkillItem;

	// Token: 0x0400641D RID: 25629
	private bool IsStartClick;

	// Token: 0x02007F13 RID: 32531
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B3CA RID: 177098
		public const int TextTitle = 0;

		// Token: 0x0402B3CB RID: 177099
		public const int BtnClose = 1;

		// Token: 0x0402B3CC RID: 177100
		public const int BtnStart = 2;

		// Token: 0x0402B3CD RID: 177101
		public const int ItemRightPanel = 3;

		// Token: 0x0402B3CE RID: 177102
		public const int ItemHistoryPanel = 4;

		// Token: 0x0402B3CF RID: 177103
		public const int TextHistoryDay = 5;

		// Token: 0x0402B3D0 RID: 177104
		public const int TextHistoryCoin = 6;

		// Token: 0x0402B3D1 RID: 177105
		public const int SpineRole = 7;

		// Token: 0x0402B3D2 RID: 177106
		public const int ItemSKill = 8;

		// Token: 0x0402B3D3 RID: 177107
		public const int ScrollLayoutDungeon = 9;

		// Token: 0x0402B3D4 RID: 177108
		public const int ItemLockPanel = 10;

		// Token: 0x0402B3D5 RID: 177109
		public const int MaskPanel = 11;
	}
}
