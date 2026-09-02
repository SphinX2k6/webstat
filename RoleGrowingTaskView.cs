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

// Token: 0x0200135D RID: 4957
[NullableContext(1)]
[Nullable(0)]
public class RoleGrowingTaskView : UiViewBase
{
	// Token: 0x060087CE RID: 34766 RVA: 0x0023CD70 File Offset: 0x0023AF70
	public RoleGrowingTaskView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x060087CF RID: 34767 RVA: 0x0023CD7C File Offset: 0x0023AF7C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickPre));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickNext));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060087D0 RID: 34768 RVA: 0x0023CF30 File Offset: 0x0023B130
	protected override UniTask OnBeforeStartAsync()
	{
		RoleGrowingTaskView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleGrowingTaskView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060087D1 RID: 34769 RVA: 0x0023CF74 File Offset: 0x0023B174
	protected override void OnBeforeShow()
	{
		ControllerBase<ActivityController>.Instance.CheckIsActivityClose(null, new int?(this.ActivityBaseData.Id));
		this.RefreshView(this.CurrentIndex);
	}

	// Token: 0x060087D2 RID: 34770 RVA: 0x0023CFB0 File Offset: 0x0023B1B0
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.LongShanUpdate, new Action(this.RefreshTasks));
	}

	// Token: 0x060087D3 RID: 34771 RVA: 0x0023CFCE File Offset: 0x0023B1CE
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.LongShanUpdate, new Action(this.RefreshTasks));
	}

	// Token: 0x060087D4 RID: 34772 RVA: 0x0023CFEC File Offset: 0x0023B1EC
	protected void RefreshView(int newIndex)
	{
		this.PageDotLayout.GetLayoutItemByIndex(this.CurrentIndex).UpdateShow(false);
		this.CurrentIndex = newIndex;
		this.PageDotLayout.GetLayoutItemByIndex(this.CurrentIndex).UpdateShow(true);
		int num = this.ActivityBaseData.StageIds[this.CurrentIndex];
		LongShanStage value = ConfigLongShanStageById.GetConfig(num, true).Value;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), value.TitleDetail, Array.Empty<object>());
		this.SetSpriteByPath(value.Picture, base.GetSprite(8), false, null, null);
		base.GetButton(5).RootUIComp.Get().SetUIActive(this.CurrentIndex > 0);
		base.GetButton(6).RootUIComp.Get().SetUIActive(this.CurrentIndex < this.ActivityBaseData.StageIds.Length - 1);
		this.RefreshTasks();
		this.ActivityBaseData.SaveNewStageFlag(num);
	}

	// Token: 0x060087D5 RID: 34773 RVA: 0x0023D0F4 File Offset: 0x0023B2F4
	private void RefreshTasks()
	{
		ActivityLongShanData activity = this.ActivityBaseData;
		int id = activity.StageIds[this.CurrentIndex];
		int progress = activity.GetProgress(id);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "LongShanStage_ProgressPercentage", new <>z__ReadOnlySingleElementList<object>(progress));
		List<LongShanTaskInfo> list = activity.GetStageInfoById(id).Tasks.ToList<LongShanTaskInfo>();
		list.Sort((LongShanTaskInfo task1, LongShanTaskInfo task2) => activity.TaskSort(task1, task2));
		this.TaskScroll.RefreshByData(list, null, true);
	}

	// Token: 0x060087D6 RID: 34774 RVA: 0x0023D18B File Offset: 0x0023B38B
	private LongShanTaskItem CreateTaskItem()
	{
		return new LongShanTaskItem();
	}

	// Token: 0x060087D7 RID: 34775 RVA: 0x0023D192 File Offset: 0x0023B392
	private PageDot<int> InitPageDot()
	{
		return new PageDot<int>();
	}

	// Token: 0x060087D8 RID: 34776 RVA: 0x0023D199 File Offset: 0x0023B399
	private void OnClickPre()
	{
		this.RefreshView(this.CurrentIndex - 1);
	}

	// Token: 0x060087D9 RID: 34777 RVA: 0x0023D1AC File Offset: 0x0023B3AC
	private void OnClickNext()
	{
		int num = this.ActivityBaseData.StageIds[this.CurrentIndex + 1];
		if (this.ActivityBaseData.GetStageInfoById(num) != null)
		{
			this.RefreshView(this.CurrentIndex + 1);
			return;
		}
		ControllerBase<ActivityLongShanController>.Instance.ShowUnlockTip(num);
	}

	// Token: 0x04003FE9 RID: 16361
	[Nullable(2)]
	protected ActivityLongShanData ActivityBaseData;

	// Token: 0x04003FEA RID: 16362
	protected int CurrentIndex;

	// Token: 0x04003FEB RID: 16363
	[Nullable(2)]
	protected PopupCaptionItem CaptionItem;

	// Token: 0x04003FEC RID: 16364
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericLayout<PageDot<int>, int> PageDotLayout;

	// Token: 0x04003FED RID: 16365
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericScrollViewNew<LongShanTaskItem, LongShanTaskInfo> TaskScroll;

	// Token: 0x02007706 RID: 30470
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04028FD5 RID: 167893
		public const int CaptionItem = 0;

		// Token: 0x04028FD6 RID: 167894
		public const int TxtName = 1;

		// Token: 0x04028FD7 RID: 167895
		public const int TxtProgress = 2;

		// Token: 0x04028FD8 RID: 167896
		public const int LabelFinish = 3;

		// Token: 0x04028FD9 RID: 167897
		public const int TaskParent = 4;

		// Token: 0x04028FDA RID: 167898
		public const int BtnPre = 5;

		// Token: 0x04028FDB RID: 167899
		public const int BtnNext = 6;

		// Token: 0x04028FDC RID: 167900
		public const int PageDotLayout = 7;

		// Token: 0x04028FDD RID: 167901
		public const int SpriteIcon = 8;
	}
}
