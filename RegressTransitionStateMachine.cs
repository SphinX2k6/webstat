using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001555 RID: 5461
[NullableContext(1)]
[Nullable(0)]
public class RegressTransitionStateMachine
{
	// Token: 0x06009944 RID: 39236 RVA: 0x00281F5B File Offset: 0x0028015B
	public void Start()
	{
		this.SetState(EActivityRecallTransitionStatus.Init);
	}

	// Token: 0x06009945 RID: 39237 RVA: 0x00281F64 File Offset: 0x00280164
	public void ShutDown()
	{
		Dictionary<EActivityRecallTransitionStatus, IRegressTransitionState> stateMap = this.StateMap;
		if (stateMap != null)
		{
			stateMap.Clear();
		}
		this.StateMap = null;
		this.CurrentState = null;
	}

	// Token: 0x06009946 RID: 39238 RVA: 0x00281F88 File Offset: 0x00280188
	public unsafe void PlayNextState()
	{
		if (this.CurrentState == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ActivityRegress;
			ELogAuthor author = ELogAuthor.LRX;
			string message = "回归活动->RecallTransitionStateMachine.PlayNextState->";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("无法自动播放下一个状态, 当前状态为空 State", this.CurrentState);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("当前状态", this.Status);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		this.CurrentState.End();
	}

	// Token: 0x06009947 RID: 39239 RVA: 0x00282010 File Offset: 0x00280210
	public unsafe void SetState(EActivityRecallTransitionStatus status)
	{
		if (status == EActivityRecallTransitionStatus.Finish)
		{
			return;
		}
		IRegressTransitionState state = this.GetState(status);
		if (state != null)
		{
			this.CurrentState = state;
			UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.ActivityRegressStartupView);
			if (viewByName != null)
			{
				this.Status = new EActivityRecallTransitionStatus?(status);
				state.Transition(viewByName);
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ActivityRegress;
			ELogAuthor author = ELogAuthor.LRX;
			string message = "回归活动->RecallTransitionStateMachine.SetState->";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("播放状态异常, ActivityRecallStartView界面未加载, 目标状态", status);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("当前状态", this.Status);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
	}

	// Token: 0x06009948 RID: 39240 RVA: 0x002820C3 File Offset: 0x002802C3
	private void OnEndCallBack(IRegressTransitionState state)
	{
		this.NextState(state);
	}

	// Token: 0x06009949 RID: 39241 RVA: 0x002820CC File Offset: 0x002802CC
	private unsafe void NextState(IRegressTransitionState state)
	{
		if (this.CurrentState != null && state != this.CurrentState)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ActivityRegress;
			ELogAuthor author = ELogAuthor.LRX;
			string message = "回归活动->RecallTransitionStateMachine.OnTransitionComplete->";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("状态切换异常，结束状态与当前状态不对称, EndState", state);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CurrentState", this.CurrentState);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		this.CurrentState = null;
		EActivityRecallTransitionStatus nextStatus = state.GetNextStatus();
		this.SetState(nextStatus);
	}

	// Token: 0x0600994A RID: 39242 RVA: 0x0028215C File Offset: 0x0028035C
	[NullableContext(2)]
	private unsafe IRegressTransitionState GetState(EActivityRecallTransitionStatus status)
	{
		if (this.StateMap == null)
		{
			this.StateMap = new Dictionary<EActivityRecallTransitionStatus, IRegressTransitionState>();
		}
		IRegressTransitionState regressTransitionState;
		if (!this.StateMap.TryGetValue(status, out regressTransitionState))
		{
			switch (status)
			{
			case EActivityRecallTransitionStatus.Init:
				regressTransitionState = new RecallShowRewardState(new Action<IRegressTransitionState>(this.OnEndCallBack));
				break;
			case EActivityRecallTransitionStatus.WaitToGetReward:
				regressTransitionState = new RecallRequestRewardState(new Action<IRegressTransitionState>(this.OnEndCallBack));
				break;
			case EActivityRecallTransitionStatus.ReqRewardAndJumpActivity:
				regressTransitionState = new RecallFinishState(new Action<IRegressTransitionState>(this.OnEndCallBack));
				break;
			default:
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ActivityRegress;
				ELogAuthor author = ELogAuthor.LRX;
				string message = "回归活动->RecallTransitionStateMachine.GetState->";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("播放状态异常, 在未定义对应的状态, 目标状态", status);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("当前状态", this.Status);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				break;
			}
			}
		}
		if (regressTransitionState != null)
		{
			this.StateMap[status] = regressTransitionState;
		}
		return regressTransitionState;
	}

	// Token: 0x040046CC RID: 18124
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<EActivityRecallTransitionStatus, IRegressTransitionState> StateMap;

	// Token: 0x040046CD RID: 18125
	private EActivityRecallTransitionStatus? Status;

	// Token: 0x040046CE RID: 18126
	[Nullable(2)]
	private IRegressTransitionState CurrentState;
}
