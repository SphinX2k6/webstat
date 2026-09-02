using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020010C9 RID: 4297
[NullableContext(1)]
[Nullable(0)]
public class GolemHackingLevelMainView : UiTickViewBase
{
	// Token: 0x06006FD1 RID: 28625 RVA: 0x001D201C File Offset: 0x001D021C
	public GolemHackingLevelMainView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06006FD2 RID: 28626 RVA: 0x001D202C File Offset: 0x001D022C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06006FD3 RID: 28627 RVA: 0x001D20F8 File Offset: 0x001D02F8
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
	}

	// Token: 0x06006FD4 RID: 28628 RVA: 0x001D2116 File Offset: 0x001D0316
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
	}

	// Token: 0x06006FD5 RID: 28629 RVA: 0x001D2134 File Offset: 0x001D0334
	protected override void OnStart()
	{
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(new Action(this.OnClickedClose));
		this.CaptionItem.SetHelpCallBack(delegate
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(576);
		});
		this.LevelLayout = new GenericScrollViewNew<GolemHackingLevelGroupTab, GolemHackingLevelGroupInfo>(base.GetScrollViewWithScrollbar(3), new Func<GolemHackingLevelGroupTab>(this.CreateLevel), null, false, null);
		this.ActivityData = ControllerBase<GolemHackingController>.Instance.GetActivityData();
		this.RefreshCurSelected();
	}

	// Token: 0x06006FD6 RID: 28630 RVA: 0x001D21CC File Offset: 0x001D03CC
	protected void RefreshCurSelected()
	{
		List<GolemHackingLevelGroupInfo> levelGroupList = this.ActivityData.GetLevelGroupList();
		for (int i = levelGroupList.Count - 1; i >= 0; i--)
		{
			GolemHackingLevelGroupInfo golemHackingLevelGroupInfo = levelGroupList[i];
			if (this.ActivityData.GetGroupState(golemHackingLevelGroupInfo.Group).Item1 == EGolemHackingGroupState.Normal)
			{
				this.CurSelected = i;
				break;
			}
		}
		if (this.CurSelected == -1)
		{
			this.CurSelected = levelGroupList.Count - 1;
		}
	}

	// Token: 0x06006FD7 RID: 28631 RVA: 0x001D223C File Offset: 0x001D043C
	protected override void OnBeforeShow()
	{
		ValueTuple<int, int> groupProgressState = this.ActivityData.GetGroupProgressState();
		int item = groupProgressState.Item1;
		int item2 = groupProgressState.Item2;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "IntrusionProtocolActivity_Progress", new <>z__ReadOnlyArray<object>(new object[]
		{
			item,
			item2
		}));
		int count = this.LevelLayout.GetScrollItemList().Count;
		List<GolemHackingLevelGroupInfo> levelGroupList = this.ActivityData.GetLevelGroupList();
		if (count != levelGroupList.Count && count > 0)
		{
			this.CurSelected = levelGroupList.Count - 1;
			this.HasFirstInit = false;
		}
		this.LevelLayout.RefreshByData(levelGroupList, delegate
		{
			bool cacheRewardFocus = ControllerBase<GolemHackingController>.Instance.CacheRewardFocus;
			if (this.HasFirstInit && !cacheRewardFocus)
			{
				return;
			}
			if (cacheRewardFocus)
			{
				this.RefreshCurSelected();
				ControllerBase<GolemHackingController>.Instance.CacheRewardFocus = false;
			}
			TimerSystem.Instance.Next(delegate(float _)
			{
				this.OnLateUpdate();
			}, null, null);
		}, true);
	}

	// Token: 0x06006FD8 RID: 28632 RVA: 0x001D22F4 File Offset: 0x001D04F4
	protected override void OnTick(float delta)
	{
		foreach (GolemHackingLevelGroupTab golemHackingLevelGroupTab in this.LevelLayout.GetScrollItemList())
		{
			golemHackingLevelGroupTab.OnTick();
		}
	}

	// Token: 0x06006FD9 RID: 28633 RVA: 0x001D234C File Offset: 0x001D054C
	protected void OnLateUpdate()
	{
		base.GetScrollViewWithScrollbar(3).OnLateUpdate.Bind(delegate(float _)
		{
			this.HasFirstInit = true;
			TimerSystem.Instance.Next(delegate(float _)
			{
				List<GolemHackingLevelGroupInfo> levelGroupList = this.ActivityData.GetLevelGroupList();
				int index = (this.CurSelected + 2 < levelGroupList.Count) ? (this.CurSelected + 2) : (levelGroupList.Count - 1);
				UUIItem itemByIndex = this.LevelLayout.GetItemByIndex(index);
				if (itemByIndex == null)
				{
					return;
				}
				this.LevelLayout.ScrollTo(itemByIndex, true);
				if (Singleton<Info>.Instance.IsInGamepad())
				{
					UUIItem itemByIndex2 = this.LevelLayout.GetItemByIndex(this.CurSelected);
					ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForViewByRootItem(itemByIndex2, "Group1", true);
				}
			}, null, null);
			base.GetScrollViewWithScrollbar(3).OnLateUpdate.Unbind();
		});
	}

	// Token: 0x06006FDA RID: 28634 RVA: 0x001D236B File Offset: 0x001D056B
	private void OnClickedClose()
	{
		base.CloseMe(null);
	}

	// Token: 0x06006FDB RID: 28635 RVA: 0x001D2374 File Offset: 0x001D0574
	private void OnClickedCallback(GolemHackingLevelGroupInfo data, int gridIndex)
	{
		if (this.ActivityData.GetGroupState(data.Group).Item1 == EGolemHackingGroupState.Locked)
		{
			this.ActivityData.GetGroupLockTips(data.Group);
			return;
		}
		this.CurSelected = gridIndex;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.GolemHackingLevelDetailView, data, null);
	}

	// Token: 0x06006FDC RID: 28636 RVA: 0x001D23C3 File Offset: 0x001D05C3
	private GolemHackingLevelGroupTab CreateLevel()
	{
		return new GolemHackingLevelGroupTab
		{
			OnClickedCallback = new Action<GolemHackingLevelGroupInfo, int>(this.OnClickedCallback)
		};
	}

	// Token: 0x06006FDD RID: 28637 RVA: 0x001D23DC File Offset: 0x001D05DC
	private void OnActivityClose(IReadOnlySet<int> closeActivities)
	{
		ControllerBase<GolemHackingController>.Instance.CloseActivityView(closeActivities, false);
	}

	// Token: 0x040035D2 RID: 13778
	protected PopupCaptionItem CaptionItem;

	// Token: 0x040035D3 RID: 13779
	protected GenericScrollViewNew<GolemHackingLevelGroupTab, GolemHackingLevelGroupInfo> LevelLayout;

	// Token: 0x040035D4 RID: 13780
	protected GolemHackingActivityData ActivityData;

	// Token: 0x040035D5 RID: 13781
	protected int CurSelected = -1;

	// Token: 0x040035D6 RID: 13782
	protected bool HasFirstInit;

	// Token: 0x02007457 RID: 29783
	[NullableContext(0)]
	private enum EDefine
	{
		// Token: 0x04028379 RID: 164729
		CaptionItem,
		// Token: 0x0402837A RID: 164730
		PanelProgress,
		// Token: 0x0402837B RID: 164731
		TxtProgress,
		// Token: 0x0402837C RID: 164732
		SvList,
		// Token: 0x0402837D RID: 164733
		Item
	}
}
