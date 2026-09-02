using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C3A RID: 7226
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchPermanentRewardView : UiViewBase
{
	// Token: 0x0600D2A2 RID: 53922 RVA: 0x0037FFC1 File Offset: 0x0037E1C1
	public FloroRanchPermanentRewardView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600D2A3 RID: 53923 RVA: 0x0037FFCC File Offset: 0x0037E1CC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D2A4 RID: 53924 RVA: 0x00380058 File Offset: 0x0037E258
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchPermanentRewardView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchPermanentRewardView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D2A5 RID: 53925 RVA: 0x0038009B File Offset: 0x0037E29B
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshTaskLayout));
	}

	// Token: 0x0600D2A6 RID: 53926 RVA: 0x003800B9 File Offset: 0x0037E2B9
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshTaskLayout));
	}

	// Token: 0x0600D2A7 RID: 53927 RVA: 0x003800D8 File Offset: 0x0037E2D8
	private void OnRefreshTaskLayout(int activityId)
	{
		FloroRanchActivityData activityData = ModelBase<FloroRanchModel>.Instance.GetActivityData(EFloroRanchActivityDataType.Normal, true);
		if (activityData.Id != activityId)
		{
			return;
		}
		List<FloroRanchTaskData> permanentTaskData = activityData.GetPermanentTaskData();
		this.TaskLayout.RefreshByData(permanentTaskData, null, true);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshActivityTab, activityData.Id);
	}

	// Token: 0x0600D2A8 RID: 53928 RVA: 0x00380127 File Offset: 0x0037E327
	private FloroRanchTaskItem CreateTaskItem()
	{
		return new FloroRanchTaskItem
		{
			OnGetBtnClick = new Action(this.OnTaskClickCallBack)
		};
	}

	// Token: 0x0600D2A9 RID: 53929 RVA: 0x00380140 File Offset: 0x0037E340
	private void OnTaskClickCallBack()
	{
		List<int> floroRanchReceivableTaskIds = ModelBase<FloroRanchModel>.Instance.GetActivityData(EFloroRanchActivityDataType.Normal, true).GetFloroRanchReceivableTaskIds(false, EFloroRanchTaskTabType.Dungeon);
		ControllerBase<FloroRanchController>.Instance.RequestTaskReward(floroRanchReceivableTaskIds.ToArray());
	}

	// Token: 0x0600D2AA RID: 53930 RVA: 0x00380171 File Offset: 0x0037E371
	private void OnCloseBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x04006459 RID: 25689
	private GenericLayout<FloroRanchTaskItem, FloroRanchTaskData> TaskLayout;

	// Token: 0x02007F38 RID: 32568
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B4C9 RID: 177353
		public const int ItemCaption = 0;

		// Token: 0x0402B4CA RID: 177354
		public const int LayoutTask = 1;

		// Token: 0x0402B4CB RID: 177355
		public const int ItemTask = 2;
	}
}
