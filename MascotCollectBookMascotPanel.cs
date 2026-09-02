using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F74 RID: 8052
[NullableContext(1)]
[Nullable(0)]
public class MascotCollectBookMascotPanel : UiPanelBase
{
	// Token: 0x0600F139 RID: 61753 RVA: 0x0041EA20 File Offset: 0x0041CC20
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F13A RID: 61754 RVA: 0x0041EBD7 File Offset: 0x0041CDD7
	protected override void OnBeforeCreateImplement()
	{
		this.LevelPlaySequence = new UiBehaviorLevelSequence(this);
		base.AddUiBehavior(this.LevelPlaySequence);
	}

	// Token: 0x0600F13B RID: 61755 RVA: 0x0041EBF4 File Offset: 0x0041CDF4
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		Singleton<EventSystem>.Instance.Add(EEventName.OnCloseRewardView, new Action(this.OnCloseRewardView));
		this.MascotToggleLayout = new GenericLayout<MascotCollectBookInfoItem, IMascotCollectInfoData>(base.GetVerticalLayout(0), new Func<MascotCollectBookInfoItem>(this.CreateMascotInfoItem), null, false, true);
		this.RewardScrollView = new GenericScrollViewNew<ActivitySmallItemGrid, IItemGridData>(base.GetScrollViewWithScrollbar(7), new Func<ActivitySmallItemGrid>(this.CreatePropItem), null, false, null);
		this.ConfirmButtonItem = new ButtonItem(base.GetItem(9));
		this.ConfirmButtonItem.SetFunction(new Action<int>(this.OnClickConfirm));
	}

	// Token: 0x0600F13C RID: 61756 RVA: 0x0041ECA8 File Offset: 0x0041CEA8
	protected override void OnBeforeShow()
	{
		this.LevelPlaySequence.PlaySequence("Start", false, null);
	}

	// Token: 0x0600F13D RID: 61757 RVA: 0x0041ECCF File Offset: 0x0041CECF
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCloseRewardView, new Action(this.OnCloseRewardView));
	}

	// Token: 0x0600F13E RID: 61758 RVA: 0x0041ED0C File Offset: 0x0041CF0C
	private void OnActivitySequenceEmitEvent(string param)
	{
		if (param == "Info_Switch_2")
		{
			this.RefreshDetailPanel();
		}
		if (param == "PnlHead_Refresh" && this.CurSelectMascotData != null)
		{
			base.SetTextureShowUntilLoaded(this.CurSelectMascotData.Config.Value.Picture, base.GetTexture(11), null);
		}
	}

	// Token: 0x0600F13F RID: 61759 RVA: 0x0041ED6B File Offset: 0x0041CF6B
	private MascotCollectBookInfoItem CreateMascotInfoItem()
	{
		MascotCollectBookInfoItem mascotCollectBookInfoItem = new MascotCollectBookInfoItem();
		mascotCollectBookInfoItem.BindMascotToggleClick(new Action<MascotCollectBookMascotToggle>(this.OnMascotToggleClick));
		return mascotCollectBookInfoItem;
	}

	// Token: 0x0600F140 RID: 61760 RVA: 0x0041ED84 File Offset: 0x0041CF84
	private ActivitySmallItemGrid CreatePropItem()
	{
		return new ActivitySmallItemGrid();
	}

	// Token: 0x0600F141 RID: 61761 RVA: 0x0041ED8C File Offset: 0x0041CF8C
	public UniTask InitPanel()
	{
		MascotCollectBookMascotPanel.<InitPanel>d__20 <InitPanel>d__;
		<InitPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitPanel>d__.<>4__this = this;
		<InitPanel>d__.<>1__state = -1;
		<InitPanel>d__.<>t__builder.Start<MascotCollectBookMascotPanel.<InitPanel>d__20>(ref <InitPanel>d__);
		return <InitPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600F142 RID: 61762 RVA: 0x0041EDD0 File Offset: 0x0041CFD0
	private void InitMapData()
	{
		this.MascotDataMapByAreaId.Clear();
		foreach (HonamiStoryAreaData honamiStoryAreaData in this.ActivityData.GetHonamiStoryMascotAreaDataList())
		{
			List<HonamiStoryMascotData> honamiStoryMascotDataListByAreaId = this.ActivityData.GetHonamiStoryMascotDataListByAreaId(honamiStoryAreaData.Id);
			if (honamiStoryMascotDataListByAreaId.Count != 0)
			{
				this.MascotDataMapByAreaId[honamiStoryAreaData.Id] = honamiStoryMascotDataListByAreaId;
			}
		}
	}

	// Token: 0x0600F143 RID: 61763 RVA: 0x0041EE58 File Offset: 0x0041D058
	private UniTask InitInfoLayout()
	{
		MascotCollectBookMascotPanel.<InitInfoLayout>d__22 <InitInfoLayout>d__;
		<InitInfoLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitInfoLayout>d__.<>4__this = this;
		<InitInfoLayout>d__.<>1__state = -1;
		<InitInfoLayout>d__.<>t__builder.Start<MascotCollectBookMascotPanel.<InitInfoLayout>d__22>(ref <InitInfoLayout>d__);
		return <InitInfoLayout>d__.<>t__builder.Task;
	}

	// Token: 0x0600F144 RID: 61764 RVA: 0x0041EE9C File Offset: 0x0041D09C
	private void InitMascotToggleList()
	{
		List<MascotCollectBookInfoItem> layoutItemList = this.MascotToggleLayout.GetLayoutItemList();
		this.MascotToggleList.Clear();
		foreach (MascotCollectBookInfoItem mascotCollectBookInfoItem in layoutItemList)
		{
			foreach (MascotCollectBookMascotToggle item in mascotCollectBookInfoItem.GetMascotToggleList())
			{
				this.MascotToggleList.Add(item);
			}
		}
		if (this.MascotToggleList.Count > 0)
		{
			this.CurSelectMascotItem = this.MascotToggleList[0];
			this.CurSelectMascotItem.OnSelected(true);
		}
	}

	// Token: 0x0600F145 RID: 61765 RVA: 0x0041EF64 File Offset: 0x0041D164
	private void RefreshDetailPanel()
	{
		if (this.CurSelectMascotData == null)
		{
			return;
		}
		HonamiStoryMascotData curSelectMascotData = this.CurSelectMascotData;
		HonamiStoryAreaData honamiStoryAreaData = this.ActivityData.GetHonamiStoryAreaData(curSelectMascotData.AreaId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "HonamiStory_Mascot_Number_Text", new <>z__ReadOnlySingleElementList<object>(curSelectMascotData.Id));
		base.GetText(3).ShowTextNew(curSelectMascotData.Name);
		base.GetText(4).ShowTextNew(honamiStoryAreaData.Name);
		base.GetText(5).ShowTextNew(curSelectMascotData.FeatureDesc);
		base.GetText(6).ShowTextNew(curSelectMascotData.ClueDesc);
		List<IItemGridData> list = new List<IItemGridData>();
		foreach (TItem item in ConfigBase<RewardConfig>.Instance.GetDropPackagePreviewItemList(curSelectMascotData.DropId))
		{
			ItemGridData item2 = new ItemGridData
			{
				Item = item,
				HasClaimed = (curSelectMascotData.State == EHonamiStoryCollectState.GotReward)
			};
			list.Add(item2);
		}
		this.RewardScrollView.RefreshByData(list, null, false);
		EHonamiStoryCollectState state = curSelectMascotData.State;
		this.ConfirmButtonItem.SetUiActive(state != EHonamiStoryCollectState.GotReward);
		this.ConfirmButtonItem.SetEnableClick(state == EHonamiStoryCollectState.Finished);
		this.ConfirmButtonItem.SetRedDotVisible(state == EHonamiStoryCollectState.Finished);
		string showText;
		if (Singleton<HonamiStoryDefine>.Instance.honamiCollectStateMap.TryGetValue(state, out showText))
		{
			this.ConfirmButtonItem.SetShowText(showText);
		}
		HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.HonamiStoryMascotUnlockSet, null) ?? new HashSet<int>();
		if (hashSet.Contains(curSelectMascotData.Id))
		{
			UiBehaviorLevelSequence levelPlaySequence = this.LevelPlaySequence;
			if (levelPlaySequence != null)
			{
				levelPlaySequence.PlaySequence("PnlHead_Refresh", false, null);
			}
			hashSet.Remove(curSelectMascotData.Id);
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.HonamiStoryMascotUnlockSet, hashSet);
		}
		else if (state == EHonamiStoryCollectState.Finished || state == EHonamiStoryCollectState.GotReward)
		{
			base.SetTextureShowUntilLoaded(curSelectMascotData.Config.Value.Picture, base.GetTexture(11), null);
		}
		else
		{
			base.SetTextureShowUntilLoaded("/Game/Aki/UI/UIResources/UiActivity/Image/Activity28/HonamiStory/HonamiStoryHead/T_HonamiStoryHeadAEmpty.T_HonamiStoryHeadAEmpty", base.GetTexture(11), null);
		}
		base.GetItem(10).SetUIActive(state == EHonamiStoryCollectState.GotReward);
	}

	// Token: 0x0600F146 RID: 61766 RVA: 0x0041F19C File Offset: 0x0041D39C
	public void BindSwitchCallback(Action callback)
	{
		this.SwitchCallback = callback;
	}

	// Token: 0x0600F147 RID: 61767 RVA: 0x0041F1A8 File Offset: 0x0041D3A8
	public void CloseWithSequence()
	{
		this.LevelPlaySequence.PlaySequence("Close", false, null);
	}

	// Token: 0x0600F148 RID: 61768 RVA: 0x0041F1D0 File Offset: 0x0041D3D0
	private void OnMascotToggleClick(MascotCollectBookMascotToggle selectedMascotItem)
	{
		if (this.CurSelectMascotItem == selectedMascotItem)
		{
			return;
		}
		MascotCollectBookMascotToggle curSelectMascotItem = this.CurSelectMascotItem;
		if (curSelectMascotItem != null)
		{
			curSelectMascotItem.OnDeselected(true);
		}
		this.CurSelectMascotItem = selectedMascotItem;
		this.CurSelectMascotData = selectedMascotItem.Data;
		Action switchCallback = this.SwitchCallback;
		if (switchCallback != null)
		{
			switchCallback();
		}
		this.LevelPlaySequence.PlaySequence("Switch_2", false, null);
	}

	// Token: 0x0600F149 RID: 61769 RVA: 0x0041F238 File Offset: 0x0041D438
	private void OnClickConfirm(int _)
	{
		if (this.CurSelectMascotData == null)
		{
			return;
		}
		HonamiStoryMascotData curSelectMascotData = this.CurSelectMascotData;
		if (curSelectMascotData.State != EHonamiStoryCollectState.Finished)
		{
			return;
		}
		ControllerBase<HonamiStoryController>.Instance.SendHonamiStoryMascotRewardRequest(curSelectMascotData.Id, delegate
		{
			this.WaitRewardViewClose = true;
		});
	}

	// Token: 0x0600F14A RID: 61770 RVA: 0x0041F27C File Offset: 0x0041D47C
	private void PlayStampSequence()
	{
		this.WaitRewardViewClose = false;
		this.CurSelectMascotItem.Refresh(this.CurSelectMascotItem.Data, true, 0);
		this.RefreshDetailPanel();
		this.LevelPlaySequence.PlaySequence("Stamp", false, null);
	}

	// Token: 0x0600F14B RID: 61771 RVA: 0x0041F2C8 File Offset: 0x0041D4C8
	private void OnCloseRewardView()
	{
		if (this.WaitRewardViewClose)
		{
			this.PlayStampSequence();
		}
	}

	// Token: 0x040073D5 RID: 29653
	private HonamiStoryActivityData ActivityData;

	// Token: 0x040073D6 RID: 29654
	[Nullable(2)]
	private HonamiStoryMascotData CurSelectMascotData;

	// Token: 0x040073D7 RID: 29655
	[Nullable(2)]
	private MascotCollectBookMascotToggle CurSelectMascotItem;

	// Token: 0x040073D8 RID: 29656
	private readonly Dictionary<int, List<HonamiStoryMascotData>> MascotDataMapByAreaId = new Dictionary<int, List<HonamiStoryMascotData>>();

	// Token: 0x040073D9 RID: 29657
	private GenericLayout<MascotCollectBookInfoItem, IMascotCollectInfoData> MascotToggleLayout;

	// Token: 0x040073DA RID: 29658
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<ActivitySmallItemGrid, IItemGridData> RewardScrollView;

	// Token: 0x040073DB RID: 29659
	private ButtonItem ConfirmButtonItem;

	// Token: 0x040073DC RID: 29660
	private readonly List<MascotCollectBookMascotToggle> MascotToggleList = new List<MascotCollectBookMascotToggle>();

	// Token: 0x040073DD RID: 29661
	[Nullable(2)]
	private Action SwitchCallback;

	// Token: 0x040073DE RID: 29662
	private bool WaitRewardViewClose;

	// Token: 0x040073DF RID: 29663
	[Nullable(2)]
	private UiBehaviorLevelSequence LevelPlaySequence;

	// Token: 0x02008311 RID: 33553
	[NullableContext(0)]
	private enum EMascotCollectBookMascotPanel
	{
		// Token: 0x0402C706 RID: 182022
		InfoLayout,
		// Token: 0x0402C707 RID: 182023
		InfoItem,
		// Token: 0x0402C708 RID: 182024
		NumberText,
		// Token: 0x0402C709 RID: 182025
		NameText,
		// Token: 0x0402C70A RID: 182026
		LocationText,
		// Token: 0x0402C70B RID: 182027
		FeatureText,
		// Token: 0x0402C70C RID: 182028
		ClueText,
		// Token: 0x0402C70D RID: 182029
		RewardScrollView,
		// Token: 0x0402C70E RID: 182030
		RewardItem,
		// Token: 0x0402C70F RID: 182031
		ConfirmBtn,
		// Token: 0x0402C710 RID: 182032
		GotTagItem,
		// Token: 0x0402C711 RID: 182033
		PictureTexture
	}
}
