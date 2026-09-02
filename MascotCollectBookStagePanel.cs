using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F76 RID: 8054
[NullableContext(1)]
[Nullable(0)]
public class MascotCollectBookStagePanel : UiPanelBase
{
	// Token: 0x0600F15B RID: 61787 RVA: 0x0041F514 File Offset: 0x0041D714
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F15C RID: 61788 RVA: 0x0041F665 File Offset: 0x0041D865
	protected override void OnBeforeCreateImplement()
	{
		this.LevelPlaySequence = new UiBehaviorLevelSequence(this);
		base.AddUiBehavior(this.LevelPlaySequence);
	}

	// Token: 0x0600F15D RID: 61789 RVA: 0x0041F680 File Offset: 0x0041D880
	protected override void OnStart()
	{
		this.InfoLayout = new GenericLayout<MascotCollectBookStageToggle, HonamiStoryAreaData>(base.GetVerticalLayout(0), new Func<MascotCollectBookStageToggle>(this.CreateInfoItem), null, false, true);
		this.RewardScrollView = new GenericScrollViewNew<ActivitySmallItemGrid, IItemGridData>(base.GetScrollViewWithScrollbar(6), new Func<ActivitySmallItemGrid>(this.CreatePropItem), null, false, null);
		this.ConfirmButtonItem = new ButtonItem(base.GetItem(8));
		this.ConfirmButtonItem.SetFunction(new Action<int>(this.OnClickConfirm));
		Singleton<EventSystem>.Instance.Add(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
	}

	// Token: 0x0600F15E RID: 61790 RVA: 0x0041F714 File Offset: 0x0041D914
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
	}

	// Token: 0x0600F15F RID: 61791 RVA: 0x0041F732 File Offset: 0x0041D932
	private void OnActivitySequenceEmitEvent(string param)
	{
		if (param == "Stadtage_Switch_2")
		{
			this.RefreshDetailPanel();
		}
	}

	// Token: 0x0600F160 RID: 61792 RVA: 0x0041F748 File Offset: 0x0041D948
	private MascotCollectBookStageToggle CreateInfoItem()
	{
		MascotCollectBookStageToggle mascotCollectBookStageToggle = new MascotCollectBookStageToggle();
		mascotCollectBookStageToggle.BindStageToggleClick(new Action<MascotCollectBookStageToggle>(this.OnStageToggleClick));
		this.InfoToggleList.Add(mascotCollectBookStageToggle);
		return mascotCollectBookStageToggle;
	}

	// Token: 0x0600F161 RID: 61793 RVA: 0x0041F77A File Offset: 0x0041D97A
	private ActivitySmallItemGrid CreatePropItem()
	{
		return new ActivitySmallItemGrid();
	}

	// Token: 0x0600F162 RID: 61794 RVA: 0x0041F784 File Offset: 0x0041D984
	public UniTask InitPanel()
	{
		MascotCollectBookStagePanel.<InitPanel>d__18 <InitPanel>d__;
		<InitPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitPanel>d__.<>4__this = this;
		<InitPanel>d__.<>1__state = -1;
		<InitPanel>d__.<>t__builder.Start<MascotCollectBookStagePanel.<InitPanel>d__18>(ref <InitPanel>d__);
		return <InitPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600F163 RID: 61795 RVA: 0x0041F7C7 File Offset: 0x0041D9C7
	private void InitAreaDataList()
	{
		this.AreaDataList = this.ActivityData.GetHonamiStoryMascotAreaDataList();
	}

	// Token: 0x0600F164 RID: 61796 RVA: 0x0041F7DC File Offset: 0x0041D9DC
	private UniTask InitInfoLayout()
	{
		MascotCollectBookStagePanel.<InitInfoLayout>d__20 <InitInfoLayout>d__;
		<InitInfoLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitInfoLayout>d__.<>4__this = this;
		<InitInfoLayout>d__.<>1__state = -1;
		<InitInfoLayout>d__.<>t__builder.Start<MascotCollectBookStagePanel.<InitInfoLayout>d__20>(ref <InitInfoLayout>d__);
		return <InitInfoLayout>d__.<>t__builder.Task;
	}

	// Token: 0x0600F165 RID: 61797 RVA: 0x0041F820 File Offset: 0x0041DA20
	private void RefreshDetailPanel()
	{
		if (this.CurSelectAreaData == null)
		{
			return;
		}
		base.GetText(2).ShowTextNew(this.CurSelectAreaData.Name);
		EHonamiStoryCollectState collectMascotState = this.CurSelectAreaData.CollectMascotState;
		base.GetItem(5).SetUIActive(collectMascotState == EHonamiStoryCollectState.Unfinished);
		base.GetText(4).SetUIActive(collectMascotState > EHonamiStoryCollectState.Unfinished);
		base.GetText(4).ShowTextNew(this.CurSelectAreaData.Desc);
		List<TItem> dropPackagePreviewItemList = ConfigBase<RewardConfig>.Instance.GetDropPackagePreviewItemList(this.CurSelectAreaData.DropId);
		List<IItemGridData> list = new List<IItemGridData>();
		foreach (TItem item in dropPackagePreviewItemList)
		{
			ItemGridData item2 = new ItemGridData
			{
				Item = item,
				HasClaimed = (collectMascotState == EHonamiStoryCollectState.GotReward)
			};
			list.Add(item2);
		}
		this.RewardScrollView.RefreshByData(list, null, false);
		this.ConfirmButtonItem.SetUiActive(collectMascotState != EHonamiStoryCollectState.GotReward);
		this.ConfirmButtonItem.SetEnableClick(collectMascotState == EHonamiStoryCollectState.Finished);
		this.ConfirmButtonItem.SetRedDotVisible(collectMascotState == EHonamiStoryCollectState.Finished);
		string showText;
		if (Singleton<HonamiStoryDefine>.Instance.honamiCollectStateMap.TryGetValue(collectMascotState, out showText))
		{
			this.ConfirmButtonItem.SetShowText(showText);
		}
	}

	// Token: 0x0600F166 RID: 61798 RVA: 0x0041F964 File Offset: 0x0041DB64
	public void BindSwitchCallback(Action callback)
	{
		this.SwitchCallback = callback;
	}

	// Token: 0x0600F167 RID: 61799 RVA: 0x0041F970 File Offset: 0x0041DB70
	public void CloseWithSequence()
	{
		this.LevelPlaySequence.PlaySequence("Close", false, null);
	}

	// Token: 0x0600F168 RID: 61800 RVA: 0x0041F998 File Offset: 0x0041DB98
	private void OnStageToggleClick(MascotCollectBookStageToggle areaSecretItem)
	{
		if (this.CurSelectAreaToggle == areaSecretItem)
		{
			return;
		}
		MascotCollectBookStageToggle curSelectAreaToggle = this.CurSelectAreaToggle;
		if (curSelectAreaToggle != null)
		{
			curSelectAreaToggle.OnDeselected(true);
		}
		this.CurSelectAreaToggle = areaSecretItem;
		this.CurSelectAreaData = areaSecretItem.Data;
		Action switchCallback = this.SwitchCallback;
		if (switchCallback != null)
		{
			switchCallback();
		}
		this.LevelPlaySequence.PlaySequence("Switch_2", false, null);
	}

	// Token: 0x0600F169 RID: 61801 RVA: 0x0041F9FF File Offset: 0x0041DBFF
	private void OnClickConfirm(int _)
	{
		if (this.CurSelectAreaData == null)
		{
			return;
		}
		ControllerBase<HonamiStoryController>.Instance.SendHonamiStoryAreaSecretRewardRequest(this.CurSelectAreaData.Id, delegate
		{
			this.CurSelectAreaToggle.Refresh(this.CurSelectAreaToggle.Data, true, 0);
			this.RefreshDetailPanel();
		});
	}

	// Token: 0x040073E3 RID: 29667
	private HonamiStoryActivityData ActivityData;

	// Token: 0x040073E4 RID: 29668
	[Nullable(2)]
	private HonamiStoryAreaData CurSelectAreaData;

	// Token: 0x040073E5 RID: 29669
	[Nullable(2)]
	private MascotCollectBookStageToggle CurSelectAreaToggle;

	// Token: 0x040073E6 RID: 29670
	private List<HonamiStoryAreaData> AreaDataList = new List<HonamiStoryAreaData>();

	// Token: 0x040073E7 RID: 29671
	private GenericLayout<MascotCollectBookStageToggle, HonamiStoryAreaData> InfoLayout;

	// Token: 0x040073E8 RID: 29672
	private readonly List<MascotCollectBookStageToggle> InfoToggleList = new List<MascotCollectBookStageToggle>();

	// Token: 0x040073E9 RID: 29673
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<ActivitySmallItemGrid, IItemGridData> RewardScrollView;

	// Token: 0x040073EA RID: 29674
	private ButtonItem ConfirmButtonItem;

	// Token: 0x040073EB RID: 29675
	[Nullable(2)]
	private UiBehaviorLevelSequence LevelPlaySequence;

	// Token: 0x040073EC RID: 29676
	[Nullable(2)]
	private Action SwitchCallback;

	// Token: 0x02008315 RID: 33557
	[NullableContext(0)]
	private enum EMascotCollectBookStagePanelComponent
	{
		// Token: 0x0402C720 RID: 182048
		InfoLayout,
		// Token: 0x0402C721 RID: 182049
		InfoItem,
		// Token: 0x0402C722 RID: 182050
		NameText,
		// Token: 0x0402C723 RID: 182051
		ScrollBar,
		// Token: 0x0402C724 RID: 182052
		DetailText,
		// Token: 0x0402C725 RID: 182053
		UnfinishPanel,
		// Token: 0x0402C726 RID: 182054
		RewardScrollView,
		// Token: 0x0402C727 RID: 182055
		RewardItem,
		// Token: 0x0402C728 RID: 182056
		ConfirmBtn
	}
}
