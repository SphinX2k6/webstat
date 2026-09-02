using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001363 RID: 4963
[NullableContext(1)]
[Nullable(0)]
public class SevenHillsStageTaskView : UiViewBase
{
	// Token: 0x17000B80 RID: 2944
	// (get) Token: 0x0600881B RID: 34843 RVA: 0x0023E87B File Offset: 0x0023CA7B
	protected virtual bool IsRefreshNow
	{
		get
		{
			return true;
		}
	}

	// Token: 0x0600881C RID: 34844 RVA: 0x0023E87E File Offset: 0x0023CA7E
	public SevenHillsStageTaskView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600881D RID: 34845 RVA: 0x0023E888 File Offset: 0x0023CA88
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickPre));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickNext));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600881E RID: 34846 RVA: 0x0023EA80 File Offset: 0x0023CC80
	protected override UniTask OnBeforeStartAsync()
	{
		SevenHillsStageTaskView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SevenHillsStageTaskView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600881F RID: 34847 RVA: 0x0023EAC4 File Offset: 0x0023CCC4
	protected virtual void RefreshTitleIcon()
	{
		string stringConfig = ConfigCommonParamById.GetStringConfig("SevenHillsIconPath");
		if (!string.IsNullOrEmpty(stringConfig))
		{
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem == null)
			{
				return;
			}
			captionItem.SetTitleIcon(stringConfig);
		}
	}

	// Token: 0x06008820 RID: 34848 RVA: 0x0023EAF8 File Offset: 0x0023CCF8
	protected override void OnBeforeShow()
	{
		ControllerBase<ActivityController>.Instance.CheckIsActivityClose(null, new int?(this.ActivityBaseData.Id));
		this.RefreshView();
	}

	// Token: 0x06008821 RID: 34849 RVA: 0x0023EB2E File Offset: 0x0023CD2E
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshTasks));
		Singleton<EventSystem>.Instance.Add(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
	}

	// Token: 0x06008822 RID: 34850 RVA: 0x0023EB68 File Offset: 0x0023CD68
	protected void RefreshView()
	{
		this.PageDotLayout.GetLayoutItemByIndex(this.CurrentIndex).UpdateShow(false);
		this.CurrentIndex = this.NextSelectedIndex;
		this.PageDotLayout.GetLayoutItemByIndex(this.CurrentIndex).UpdateShow(true);
		int num = this.ActivityBaseData.StageIds[this.CurrentIndex];
		LongShanStage value = ConfigLongShanStageById.GetConfig(num, true).Value;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), value.TitleDetail, Array.Empty<object>());
		this.SetSpriteByPath(value.RomeNumSprite, base.GetSprite(2), false, null, null);
		base.SetTextureByPath(value.Picture, base.GetTexture(1), null, null);
		base.GetButton(8).RootUIComp.Get().SetUIActive(this.CurrentIndex > 0);
		base.GetButton(7).RootUIComp.Get().SetUIActive(this.CurrentIndex < this.ActivityBaseData.StageIds.Length - 1);
		this.RefreshTasks();
		this.ActivityBaseData.SaveNewStageFlag(num);
	}

	// Token: 0x06008823 RID: 34851 RVA: 0x0023EC94 File Offset: 0x0023CE94
	private void RefreshTasks()
	{
		ActivityLongShanData activityBaseData = this.ActivityBaseData;
		int id = activityBaseData.StageIds[this.CurrentIndex];
		int progress = activityBaseData.GetProgress(id);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "LongShanStage_ProgressPercentage", new <>z__ReadOnlySingleElementList<object>(progress));
		List<LongShanTaskInfo> list = activityBaseData.GetStageInfoByIdIncludeLock(id).Tasks.ToList<LongShanTaskInfo>();
		list.Sort(new Comparison<LongShanTaskInfo>(this.ActivityBaseData.TaskSort));
		this.TaskLayout.RefreshByData(list, null, true);
	}

	// Token: 0x06008824 RID: 34852 RVA: 0x0023ED14 File Offset: 0x0023CF14
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshTasks));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
	}

	// Token: 0x06008825 RID: 34853 RVA: 0x0023ED50 File Offset: 0x0023CF50
	private void OnRefreshTasks(int activityId)
	{
		ActivityLongShanData activityBaseData = this.ActivityBaseData;
		int? num = (activityBaseData != null) ? new int?(activityBaseData.Id) : null;
		if (activityId == num.GetValueOrDefault() & num != null)
		{
			this.RefreshTasks();
		}
	}

	// Token: 0x06008826 RID: 34854 RVA: 0x0023ED97 File Offset: 0x0023CF97
	private void OnClickPre()
	{
		this.NextSelectedIndex = this.CurrentIndex - 1;
		base.PlaySequence("SwitchLeft", null, false);
		if (this.IsRefreshNow)
		{
			this.RefreshView();
		}
	}

	// Token: 0x06008827 RID: 34855 RVA: 0x0023EDC4 File Offset: 0x0023CFC4
	private void OnClickNext()
	{
		int stageId = this.ActivityBaseData.StageIds[this.CurrentIndex + 1];
		if (this.ActivityBaseData.IsStageUnlock(stageId))
		{
			this.NextSelectedIndex = this.CurrentIndex + 1;
			base.PlaySequence("SwitchRight", null, false);
			if (this.IsRefreshNow)
			{
				this.RefreshView();
				return;
			}
		}
		else
		{
			ControllerBase<ActivityLongShanController>.Instance.ShowUnlockTip(stageId);
		}
	}

	// Token: 0x06008828 RID: 34856 RVA: 0x0023EE29 File Offset: 0x0023D029
	private LongShanTaskItem CreateTaskItem()
	{
		return new LongShanTaskItem();
	}

	// Token: 0x06008829 RID: 34857 RVA: 0x0023EE30 File Offset: 0x0023D030
	private PageDot<int> InitPageDot()
	{
		return new PageDot<int>();
	}

	// Token: 0x0600882A RID: 34858 RVA: 0x0023EE37 File Offset: 0x0023D037
	private void OnActivitySequenceEmitEvent(string param)
	{
		if (param == "Enter" && !this.IsRefreshNow)
		{
			this.RefreshView();
		}
	}

	// Token: 0x04004004 RID: 16388
	[Nullable(2)]
	protected ActivityLongShanData ActivityBaseData;

	// Token: 0x04004005 RID: 16389
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericLayout<LongShanTaskItem, LongShanTaskInfo> TaskLayout;

	// Token: 0x04004006 RID: 16390
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericLayout<PageDot<int>, int> PageDotLayout;

	// Token: 0x04004007 RID: 16391
	[Nullable(2)]
	protected PopupCaptionItem CaptionItem;

	// Token: 0x04004008 RID: 16392
	protected int CurrentIndex;

	// Token: 0x04004009 RID: 16393
	protected int NextSelectedIndex;

	// Token: 0x02007711 RID: 30481
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029017 RID: 167959
		public const int ItemCaption = 0;

		// Token: 0x04029018 RID: 167960
		public const int TextureImage = 1;

		// Token: 0x04029019 RID: 167961
		public const int SpriteRomeNum = 2;

		// Token: 0x0402901A RID: 167962
		public const int TextName = 3;

		// Token: 0x0402901B RID: 167963
		public const int TextProgress = 4;

		// Token: 0x0402901C RID: 167964
		public const int LayoutTask = 5;

		// Token: 0x0402901D RID: 167965
		public const int ItemTask = 6;

		// Token: 0x0402901E RID: 167966
		public const int BtnArrrowRight = 7;

		// Token: 0x0402901F RID: 167967
		public const int BtnArrrowLeft = 8;

		// Token: 0x04029020 RID: 167968
		public const int LayoutPageDot = 9;

		// Token: 0x04029021 RID: 167969
		public const int ItemPageDot = 10;
	}
}
