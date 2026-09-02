using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Guide.StepInfo;
using CSharpScript.Game.LevelGamePlay;

namespace CSharpScript.Game.Guide.GroupInfo
{
	// Token: 0x02004A81 RID: 19073
	[NullableContext(2)]
	[Nullable(0)]
	public class GuideGroupInfo
	{
		// Token: 0x1700849E RID: 33950
		// (get) Token: 0x06031C57 RID: 203863 RVA: 0x00C76960 File Offset: 0x00C74B60
		public GuideStepInfo CurrentGuideStep
		{
			get
			{
				if (this.CurrentStepIndex < 0 || this.CurrentStepIndex >= this.StepInfoList.Count)
				{
					return null;
				}
				return this.StepInfoList[this.CurrentStepIndex];
			}
		}

		// Token: 0x06031C58 RID: 203864 RVA: 0x00C76994 File Offset: 0x00C74B94
		public GuideGroupInfo(int groupId)
		{
			this.Id = groupId;
			this.StateMachine = new StateMachine<GuideGroupInfo, EGuideGroupState>(this, null);
			this.StateMachine.AddState<InitState>(EGuideGroupState.Init, null);
			this.StateMachine.AddState<OpeningState>(EGuideGroupState.Opening, null);
			this.StateMachine.AddState<ExecutingState>(EGuideGroupState.Executing, null);
			this.StateMachine.AddState<PendingState>(EGuideGroupState.Pending, null);
			this.StateMachine.AddState<FinishingState>(EGuideGroupState.Finishing, null);
			this.StateMachine.Start(EGuideGroupState.Init);
		}

		// Token: 0x06031C59 RID: 203865 RVA: 0x00C76A1C File Offset: 0x00C74C1C
		public bool GetIfPreExecute()
		{
			return this.StepInfoList.Count != 0 && Math.Abs(this.StepInfoList[0].Config.TimeScale - 1f) > 1E-08f;
		}

		// Token: 0x06031C5A RID: 203866 RVA: 0x00C76A64 File Offset: 0x00C74C64
		public unsafe void SwitchState(EGuideGroupState groupState)
		{
			EGuideGroupState state = groupState;
			if (groupState == EGuideGroupState.Opening)
			{
				EGuideGroupState? currentState = this.StateMachine.CurrentState;
				EGuideGroupState eguideGroupState = EGuideGroupState.Init;
				if (!(currentState.GetValueOrDefault() == eguideGroupState & currentState != null))
				{
					Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "引导组正在执行中, 不再重复执行", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
			}
			if (groupState == EGuideGroupState.Executing && !this.CanEnterExecuting())
			{
				Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "引导组暂时无法执行, 挂起", default(ReadOnlySpan<ValueTuple<string, object>>));
				state = EGuideGroupState.Pending;
			}
			if (groupState == EGuideGroupState.Finishing && !this.IsFake)
			{
				bool? flag = ModelBase<GuideModel>.Instance.IsGroupFinished(this.Id);
				bool flag2 = ModelBase<GuideModel>.Instance.IsGroupCanRepeat(this.Id);
				if (flag.GetValueOrDefault() && !flag2)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Guide;
					ELogAuthor author = ELogAuthor.TL;
					string message = "引导组未配置为可重复完成但重复请求完成, 跳过服务端完成步骤";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("GroupId", this.Id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("isFinish", flag);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("canRepeat", flag2);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					state = EGuideGroupState.Init;
				}
			}
			this.StateMachine.Switch(state);
		}

		// Token: 0x06031C5B RID: 203867 RVA: 0x00C76BBC File Offset: 0x00C74DBC
		public void PumpStep()
		{
			if (this.StepInfoList.Count == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Guide;
				ELogAuthor author = ELogAuthor.TL;
				string message = "引导组未配置当前平台的步骤, 执行失败, 中断当前引导组";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("组Id", this.Id);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.Break();
				return;
			}
			this.EndCurrentStep();
			int num = this.CurrentStepIndex + 1;
			if (num >= this.StepInfoList.Count)
			{
				this.SwitchState(EGuideGroupState.Finishing);
				return;
			}
			this.CurrentStepIndex = num;
			GuideStepInfo guideStepInfo = this.StepInfoList[num];
			if (ConfigBase<GuideConfig>.Instance.GmMuteTutorial && guideStepInfo.Config.ContentType == 3)
			{
				guideStepInfo.SwitchState(EGuideStepState.Finish);
				return;
			}
			if (guideStepInfo.Config.BreakCondition != 0 && ControllerBase<LevelGeneralController>.Instance.CheckCondition(guideStepInfo.Config.BreakCondition.ToString(), null, false, Array.Empty<object>()))
			{
				guideStepInfo.SwitchState(EGuideStepState.Break);
				return;
			}
			if (guideStepInfo.Config.SkipCondition != 0 && ControllerBase<LevelGeneralController>.Instance.CheckCondition(guideStepInfo.Config.SkipCondition.ToString(), null, false, Array.Empty<object>()))
			{
				guideStepInfo.SwitchState(EGuideStepState.Finish);
				return;
			}
			guideStepInfo.SwitchState(EGuideStepState.Init);
			guideStepInfo.TryEnterExecuting();
		}

		// Token: 0x06031C5C RID: 203868 RVA: 0x00C76D00 File Offset: 0x00C74F00
		private void EndCurrentStep()
		{
			int currentStepIndex = this.CurrentStepIndex;
			if (currentStepIndex >= 0 && currentStepIndex < this.StepInfoList.Count)
			{
				this.StepInfoList[currentStepIndex].SwitchState(EGuideStepState.End);
			}
		}

		// Token: 0x06031C5D RID: 203869 RVA: 0x00C76D38 File Offset: 0x00C74F38
		public void Reset()
		{
			this.EndCurrentStep();
			this.CurrentStepIndex = -1;
			this.SwitchState(EGuideGroupState.Init);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.GuideGroupRest, this.Id);
		}

		// Token: 0x06031C5E RID: 203870 RVA: 0x00C76D64 File Offset: 0x00C74F64
		[NullableContext(1)]
		public bool HasAnyFinishedStep(HashSet<int> stepIdSet)
		{
			for (int i = 0; i < this.CurrentStepIndex; i++)
			{
				int id = this.StepInfoList[i].Id;
				if (stepIdSet.Contains(id))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06031C5F RID: 203871 RVA: 0x00C76DA0 File Offset: 0x00C74FA0
		public void Break()
		{
			EGuideGroupState? currentState = this.StateMachine.CurrentState;
			EGuideGroupState eguideGroupState = EGuideGroupState.Init;
			if (currentState.GetValueOrDefault() == eguideGroupState & currentState != null)
			{
				return;
			}
			if (!ModelBase<GuideModel>.Instance.IsGroupCanRepeat(this.Id))
			{
				this.SwitchState(EGuideGroupState.Finishing);
				return;
			}
			this.SwitchState(EGuideGroupState.Init);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.GuideGroupBreak, this.Id);
		}

		// Token: 0x06031C60 RID: 203872 RVA: 0x00C76E08 File Offset: 0x00C75008
		public bool CanEnterExecuting()
		{
			if (ModelBase<LoadingModel>.Instance.IsLoading || ModelBase<LoadingModel>.Instance.IsLoadingView)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Guide;
				ELogAuthor author = ELogAuthor.TL;
				string message = "引导组不能打开, 因为loading还没完成";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("组Id", this.Id);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			return true;
		}

		// Token: 0x06031C61 RID: 203873 RVA: 0x00C76E64 File Offset: 0x00C75064
		public bool CheckIsGuideRunning()
		{
			EGuideGroupState? currentState = this.StateMachine.CurrentState;
			EGuideGroupState eguideGroupState = EGuideGroupState.Init;
			return !(currentState.GetValueOrDefault() == eguideGroupState & currentState != null);
		}

		// Token: 0x06031C62 RID: 203874 RVA: 0x00C76E94 File Offset: 0x00C75094
		public bool CheckIsGuideRunningWithoutPending()
		{
			EGuideGroupState? currentState = this.StateMachine.CurrentState;
			GuideStepInfo currentGuideStep = this.CurrentGuideStep;
			EGuideStepState? eguideStepState;
			if (currentGuideStep == null)
			{
				eguideStepState = null;
			}
			else
			{
				StateMachine<GuideStepInfo, EGuideStepState> stateMachine = currentGuideStep.StateMachine;
				eguideStepState = ((stateMachine != null) ? stateMachine.CurrentState : null);
			}
			EGuideStepState? eguideStepState2 = eguideStepState;
			EGuideGroupState? eguideGroupState = currentState;
			EGuideGroupState eguideGroupState2 = EGuideGroupState.Init;
			if (!(eguideGroupState.GetValueOrDefault() == eguideGroupState2 & eguideGroupState != null) && currentState.GetValueOrDefault() != EGuideGroupState.Pending)
			{
				EGuideStepState? eguideStepState3 = eguideStepState2;
				EGuideStepState eguideStepState4 = EGuideStepState.Init;
				if (!(eguideStepState3.GetValueOrDefault() == eguideStepState4 & eguideStepState3 != null))
				{
					return eguideStepState2.GetValueOrDefault() != EGuideStepState.Pending;
				}
			}
			return false;
		}

		// Token: 0x0401D245 RID: 119365
		public readonly int Id;

		// Token: 0x0401D246 RID: 119366
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public readonly StateMachine<GuideGroupInfo, EGuideGroupState> StateMachine;

		// Token: 0x0401D247 RID: 119367
		[Nullable(1)]
		public readonly List<GuideStepInfo> StepInfoList = new List<GuideStepInfo>();

		// Token: 0x0401D248 RID: 119368
		public bool IsFake;

		// Token: 0x0401D249 RID: 119369
		public int CurrentStepIndex = -1;

		// Token: 0x0401D24A RID: 119370
		public CustomPromise FinishPromise;

		// Token: 0x0401D24B RID: 119371
		public HashSet<int> BreakExcludeStepIdSet;
	}
}
