using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001262 RID: 4706
[NullableContext(1)]
[Nullable(0)]
public class BeginnerCarnivalTaskView : UiViewBase
{
	// Token: 0x06007D61 RID: 32097 RVA: 0x002114F6 File Offset: 0x0020F6F6
	public BeginnerCarnivalTaskView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06007D62 RID: 32098 RVA: 0x00211500 File Offset: 0x0020F700
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickLeftBtn)),
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickRightBtn))
		};
	}

	// Token: 0x06007D63 RID: 32099 RVA: 0x00211630 File Offset: 0x0020F830
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshBeginnerCarnivalTask, new Action<int>(this.RefreshBeginnerCarnivalTask));
		Singleton<EventSystem>.Instance.Add(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
	}

	// Token: 0x06007D64 RID: 32100 RVA: 0x0021166A File Offset: 0x0020F86A
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshBeginnerCarnivalTask, new Action<int>(this.RefreshBeginnerCarnivalTask));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
	}

	// Token: 0x06007D65 RID: 32101 RVA: 0x002116A4 File Offset: 0x0020F8A4
	protected override UniTask OnBeforeStartAsync()
	{
		BeginnerCarnivalTaskView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BeginnerCarnivalTaskView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007D66 RID: 32102 RVA: 0x002116E7 File Offset: 0x0020F8E7
	private BeginnerCarnivalTaskItem CreateItem()
	{
		return new BeginnerCarnivalTaskItem();
	}

	// Token: 0x06007D67 RID: 32103 RVA: 0x002116EE File Offset: 0x0020F8EE
	protected override void OnStart()
	{
		this.TypeId = (int)this.OpenParam;
	}

	// Token: 0x06007D68 RID: 32104 RVA: 0x00211701 File Offset: 0x0020F901
	protected override void OnBeforeShow()
	{
		this.RefreshViewByType(this.TypeId);
	}

	// Token: 0x06007D69 RID: 32105 RVA: 0x00211710 File Offset: 0x0020F910
	private void RefreshViewByType(int type)
	{
		BeginnerCarnivalData data = ControllerBase<BeginnerCarnivalController>.Instance.GetBeginnerCarnivalData();
		List<int> taskIdListByTypeId = data.GetTaskIdListByTypeId(type);
		taskIdListByTypeId.Sort(delegate(int a, int b)
		{
			ActivityTaskState status = data.GetTaskDataById(a).Status;
			ActivityTaskState status2 = data.GetTaskDataById(b).Status;
			if (status == status2)
			{
				return a - b;
			}
			int num = (status == ActivityTaskState.ActivityTaskFinish) ? 0 : ((status == ActivityTaskState.ActivityTaskTaken) ? 2 : 1);
			int num2 = (status2 == ActivityTaskState.ActivityTaskFinish) ? 0 : ((status2 == ActivityTaskState.ActivityTaskTaken) ? 2 : 1);
			return num - num2;
		});
		this.ScrollView.RefreshByData(taskIdListByTypeId, null, false);
		this.ScrollView.PlayTurnAnimation();
		ValueTuple<int, int> progress = ControllerBase<BeginnerCarnivalController>.Instance.GetBeginnerCarnivalData().GetProgress(type);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "BeginnerCarnivalCurrentProgress", new <>z__ReadOnlyArray<object>(new object[]
		{
			progress.Item1,
			progress.Item2
		}));
		NewbieCarnivalTaskType? newbieCarnivalTaskType = ConfigBase<BeginnerCarnivalConfig>.Instance.GetNewbieCarnivalTaskType(type);
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem != null)
		{
			captionItem.SetTitleByTextIdAndArgNew(((newbieCarnivalTaskType != null) ? newbieCarnivalTaskType.GetValueOrDefault().Title : null) ?? string.Empty, Array.Empty<object>());
		}
		base.GetItem(6).SetUIActive(this.TypeId == 1);
		base.GetItem(7).SetUIActive(this.TypeId == 2);
		base.GetItem(8).SetUIActive(this.TypeId == 3);
		base.GetItem(9).SetUIActive(this.TypeId == 4);
	}

	// Token: 0x06007D6A RID: 32106 RVA: 0x00211858 File Offset: 0x0020FA58
	private void OnClickLeftBtn()
	{
		if (Singleton<TimeUtil>.Instance.GetServerTimeStamp() < this.NextCanClickTime)
		{
			return;
		}
		this.TypeId--;
		if (this.TypeId < 1)
		{
			this.TypeId = 4;
		}
		this.RefreshViewByType(this.TypeId);
		this.NextCanClickTime = Singleton<TimeUtil>.Instance.GetServerTimeStamp() + 100.0;
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence != null)
		{
			uiViewSequence.StopSequenceByKey("Switch", false, false);
		}
		UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
		if (uiViewSequence2 == null)
		{
			return;
		}
		uiViewSequence2.PlaySequence("Switch", false, null);
	}

	// Token: 0x06007D6B RID: 32107 RVA: 0x002118F4 File Offset: 0x0020FAF4
	private void OnClickRightBtn()
	{
		if (Singleton<TimeUtil>.Instance.GetServerTimeStamp() < this.NextCanClickTime)
		{
			return;
		}
		this.TypeId++;
		if (this.TypeId > 4)
		{
			this.TypeId = 1;
		}
		this.RefreshViewByType(this.TypeId);
		this.NextCanClickTime = Singleton<TimeUtil>.Instance.GetServerTimeStamp() + 100.0;
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence != null)
		{
			uiViewSequence.StopSequenceByKey("Switch", false, false);
		}
		UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
		if (uiViewSequence2 == null)
		{
			return;
		}
		uiViewSequence2.PlaySequence("Switch", false, null);
	}

	// Token: 0x06007D6C RID: 32108 RVA: 0x0021198F File Offset: 0x0020FB8F
	private void RefreshBeginnerCarnivalTask(int index)
	{
		this.RefreshViewByType(index);
	}

	// Token: 0x06007D6D RID: 32109 RVA: 0x00211998 File Offset: 0x0020FB98
	private void OnActivityClose(IReadOnlySet<int> closeActivities)
	{
		if (closeActivities.Contains(ControllerBase<BeginnerCarnivalController>.Instance.ActivityId))
		{
			Action value = delegate()
			{
				Singleton<UiManager>.Instance.ResetToBattleView(null);
			};
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ActivityEnd);
			confirmBoxDataNew.FunctionMap.Add(1, value);
			confirmBoxDataNew.FunctionMap.Add(0, value);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}
	}

	// Token: 0x04003C3C RID: 15420
	private const int MAX_TYPE = 4;

	// Token: 0x04003C3D RID: 15421
	private const int MIN_TYPE = 1;

	// Token: 0x04003C3E RID: 15422
	private int TypeId;

	// Token: 0x04003C3F RID: 15423
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04003C40 RID: 15424
	private double NextCanClickTime;

	// Token: 0x04003C41 RID: 15425
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<BeginnerCarnivalTaskItem, int> ScrollView;
}
