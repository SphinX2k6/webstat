using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020012D8 RID: 4824
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityDangoMonopolyController : ActivityControllerBase<ActivityDangoMonopolyController>
{
	// Token: 0x06008219 RID: 33305 RVA: 0x0022645F File Offset: 0x0022465F
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		this.Data = new ActivityDangoMonopolyData();
		return this.Data;
	}

	// Token: 0x0600821A RID: 33306 RVA: 0x00226472 File Offset: 0x00224672
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x0600821B RID: 33307 RVA: 0x00226475 File Offset: 0x00224675
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x0600821C RID: 33308 RVA: 0x00226477 File Offset: 0x00224677
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_ActivityMonopoly";
	}

	// Token: 0x0600821D RID: 33309 RVA: 0x0022647E File Offset: 0x0022467E
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivitySubViewDangoMonopoly();
	}

	// Token: 0x0600821E RID: 33310 RVA: 0x00226488 File Offset: 0x00224688
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<DangoMonopolyTaskUpdateNotify>(ENotifyMessageId.DangoMonopolyTaskUpdateNotify, delegate(DangoMonopolyTaskUpdateNotify response, [Nullable(2)] Net.CallbackStatus status)
		{
			ActivityDangoMonopolyData data = this.Data;
			if (data == null)
			{
				return;
			}
			data.ProtoTaskUpdateNotify(response.TaskDatas.ToList<Aki.Protocol.DangoMonopolyTaskData>());
		});
		Singleton<Net>.Instance.Register<DangoMonopolySceneGridInfoNotify>(ENotifyMessageId.DangoMonopolySceneGridInfoNotify, delegate(DangoMonopolySceneGridInfoNotify response, [Nullable(2)] Net.CallbackStatus status)
		{
			ActivityDangoMonopolyData data = this.Data;
			if (data == null)
			{
				return;
			}
			data.ProtoSceneGridInfoNotify(response);
		});
		Singleton<Net>.Instance.Register<DangoMonopolyTaskAddNotify>(ENotifyMessageId.DangoMonopolyTaskAddNotify, delegate(DangoMonopolyTaskAddNotify response, [Nullable(2)] Net.CallbackStatus status)
		{
			ActivityDangoMonopolyData data = this.Data;
			if (data == null)
			{
				return;
			}
			data.ProtoTaskAddNotify(response.TaskDatas.ToList<Aki.Protocol.DangoMonopolyTaskData>());
		});
		Singleton<Net>.Instance.Register<DangoMonopolyTaskRemoveNotify>(ENotifyMessageId.DangoMonopolyTaskRemoveNotify, delegate(DangoMonopolyTaskRemoveNotify response, [Nullable(2)] Net.CallbackStatus status)
		{
			ActivityDangoMonopolyData data = this.Data;
			if (data == null)
			{
				return;
			}
			data.ProtoTaskRemoveNotify(response.TaskIds.ToList<int>());
		});
		Singleton<Net>.Instance.Register<DangoMonopolyRewardNotify>(ENotifyMessageId.DangoMonopolyRewardNotify, delegate(DangoMonopolyRewardNotify response, [Nullable(2)] Net.CallbackStatus status)
		{
			ActivityDangoMonopolyData data = this.Data;
			if (data == null)
			{
				return;
			}
			data.ProtoRewardNotify(response);
		});
	}

	// Token: 0x0600821F RID: 33311 RVA: 0x00226524 File Offset: 0x00224724
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.DangoMonopolyTaskUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.DangoMonopolySceneGridInfoNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.DangoMonopolyTaskAddNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.DangoMonopolyTaskRemoveNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.DangoMonopolyRewardNotify);
	}

	// Token: 0x06008220 RID: 33312 RVA: 0x00226581 File Offset: 0x00224781
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.EventWorldDone));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.EventCommonItemCountAnyChange));
	}

	// Token: 0x06008221 RID: 33313 RVA: 0x002265BB File Offset: 0x002247BB
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.EventWorldDone));
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.EventCommonItemCountAnyChange));
	}

	// Token: 0x06008222 RID: 33314 RVA: 0x002265F5 File Offset: 0x002247F5
	[NullableContext(2)]
	private static ActivityDangoMonopolyController GetController()
	{
		return ActivityManager.GetActivityController(ActivityType.DangoMonopoly) as ActivityDangoMonopolyController;
	}

	// Token: 0x06008223 RID: 33315 RVA: 0x00226603 File Offset: 0x00224803
	[NullableContext(2)]
	public ActivityDangoMonopolyData GetData()
	{
		ActivityDangoMonopolyController controller = ActivityDangoMonopolyController.GetController();
		if (controller == null)
		{
			return null;
		}
		return controller.Data;
	}

	// Token: 0x06008224 RID: 33316 RVA: 0x00226618 File Offset: 0x00224818
	public void RefreshActivityRedDot()
	{
		ActivityDangoMonopolyData data = this.Data;
		int? num = (data != null) ? new int?(data.Id) : null;
		if (num != null)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, num.Value);
		}
	}

	// Token: 0x06008225 RID: 33317 RVA: 0x00226668 File Offset: 0x00224868
	public UniTask RequestReceiveTaskReward(List<int> taskIdList)
	{
		ActivityDangoMonopolyController.<RequestReceiveTaskReward>d__13 <RequestReceiveTaskReward>d__;
		<RequestReceiveTaskReward>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestReceiveTaskReward>d__.<>4__this = this;
		<RequestReceiveTaskReward>d__.taskIdList = taskIdList;
		<RequestReceiveTaskReward>d__.<>1__state = -1;
		<RequestReceiveTaskReward>d__.<>t__builder.Start<ActivityDangoMonopolyController.<RequestReceiveTaskReward>d__13>(ref <RequestReceiveTaskReward>d__);
		return <RequestReceiveTaskReward>d__.<>t__builder.Task;
	}

	// Token: 0x06008226 RID: 33318 RVA: 0x002266B4 File Offset: 0x002248B4
	public UniTask RequestReceiveBoardReward(List<int> boardIdList)
	{
		ActivityDangoMonopolyController.<RequestReceiveBoardReward>d__14 <RequestReceiveBoardReward>d__;
		<RequestReceiveBoardReward>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestReceiveBoardReward>d__.<>4__this = this;
		<RequestReceiveBoardReward>d__.boardIdList = boardIdList;
		<RequestReceiveBoardReward>d__.<>1__state = -1;
		<RequestReceiveBoardReward>d__.<>t__builder.Start<ActivityDangoMonopolyController.<RequestReceiveBoardReward>d__14>(ref <RequestReceiveBoardReward>d__);
		return <RequestReceiveBoardReward>d__.<>t__builder.Task;
	}

	// Token: 0x06008227 RID: 33319 RVA: 0x00226700 File Offset: 0x00224900
	public UniTask RequestReceiveGridReward()
	{
		ActivityDangoMonopolyController.<RequestReceiveGridReward>d__15 <RequestReceiveGridReward>d__;
		<RequestReceiveGridReward>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestReceiveGridReward>d__.<>4__this = this;
		<RequestReceiveGridReward>d__.<>1__state = -1;
		<RequestReceiveGridReward>d__.<>t__builder.Start<ActivityDangoMonopolyController.<RequestReceiveGridReward>d__15>(ref <RequestReceiveGridReward>d__);
		return <RequestReceiveGridReward>d__.<>t__builder.Task;
	}

	// Token: 0x06008228 RID: 33320 RVA: 0x00226744 File Offset: 0x00224944
	public UniTask RequestDice()
	{
		ActivityDangoMonopolyController.<RequestDice>d__16 <RequestDice>d__;
		<RequestDice>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestDice>d__.<>4__this = this;
		<RequestDice>d__.<>1__state = -1;
		<RequestDice>d__.<>t__builder.Start<ActivityDangoMonopolyController.<RequestDice>d__16>(ref <RequestDice>d__);
		return <RequestDice>d__.<>t__builder.Task;
	}

	// Token: 0x06008229 RID: 33321 RVA: 0x00226788 File Offset: 0x00224988
	public UniTask RequestEnterNextBoard()
	{
		ActivityDangoMonopolyController.<RequestEnterNextBoard>d__17 <RequestEnterNextBoard>d__;
		<RequestEnterNextBoard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestEnterNextBoard>d__.<>4__this = this;
		<RequestEnterNextBoard>d__.<>1__state = -1;
		<RequestEnterNextBoard>d__.<>t__builder.Start<ActivityDangoMonopolyController.<RequestEnterNextBoard>d__17>(ref <RequestEnterNextBoard>d__);
		return <RequestEnterNextBoard>d__.<>t__builder.Task;
	}

	// Token: 0x0600822A RID: 33322 RVA: 0x002267CB File Offset: 0x002249CB
	private void EventWorldDone()
	{
		ActivityDangoMonopolyData data = this.Data;
		if (data != null)
		{
			data.DelayUpdateCameraMove().Forget();
		}
		ActivityDangoMonopolyData data2 = this.Data;
		if (data2 != null && data2.IsInTheDungeon())
		{
			this.Data.RecordKismetSetting();
		}
	}

	// Token: 0x0600822B RID: 33323 RVA: 0x00226804 File Offset: 0x00224A04
	private void EventCommonItemCountAnyChange(int id, int _)
	{
		ActivityDangoMonopolyData data = this.Data;
		int? num = (data != null) ? new int?(data.DiceItemId) : null;
		if (!(id == num.GetValueOrDefault() & num != null))
		{
			return;
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotUpdateDangoMonopolyNum);
		this.RefreshActivityRedDot();
	}

	// Token: 0x04003DE3 RID: 15843
	[Nullable(2)]
	public ActivityDangoMonopolyData Data;
}
