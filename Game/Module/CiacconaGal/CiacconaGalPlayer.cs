using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EAF RID: 24239
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CiacconaGalPlayer : Singleton<CiacconaGalPlayer>
	{
		// Token: 0x17009984 RID: 39300
		// (get) Token: 0x0603CEBA RID: 249530 RVA: 0x00F79DA8 File Offset: 0x00F77FA8
		public ECiacconaGalPlayerState StatePendingToSwitch
		{
			get
			{
				return (ECiacconaGalPlayerState)this.InternalStatePendingToSwitch;
			}
		}

		// Token: 0x17009985 RID: 39301
		// (get) Token: 0x0603CEBB RID: 249531 RVA: 0x00F79DB0 File Offset: 0x00F77FB0
		[Nullable(2)]
		public ICiacconaGalTextAnimHandler AnimHandler
		{
			[NullableContext(2)]
			get
			{
				return this.InternalAnimHandler;
			}
		}

		// Token: 0x0603CEBC RID: 249532 RVA: 0x00F79DB8 File Offset: 0x00F77FB8
		public CiacconaGalPlayer()
		{
			this.StateMachine = new StateMachine<CiacconaGalPlayer, ECiacconaGalPlayerState>(this, null);
			this.StateMachine.AddState<CiacconaGalPlayerInitializingState>(ECiacconaGalPlayerState.Initializing, null);
			this.StateMachine.AddState<CiacconaGalPlayerPausingState>(ECiacconaGalPlayerState.Pausing, null);
			this.StateMachine.AddState<CiacconaGalPlayerPlayingState>(ECiacconaGalPlayerState.Playing, null);
			this.StateMachine.AddState<CiacconaGalPlayerSkippingState>(ECiacconaGalPlayerState.Skipping, null);
			this.StateMachine.AddState<CiacconaGalPlayerChoosingState>(ECiacconaGalPlayerState.Choosing, null);
			this.StateMachine.AddState<CiacconaGalPlayerSubEndingState>(ECiacconaGalPlayerState.SubEnding, null);
			this.StateMachine.AddState<CiacconaGalPlayerProtectingState>(ECiacconaGalPlayerState.Protecting, null);
			this.StateMachine.AddState<CiacconaGalPlayerBeforeSubEndingState>(ECiacconaGalPlayerState.BeforeSubEnding, null);
			this.StateMachine.AddState<CiacconaGalPlayerChoiceProtectingState>(ECiacconaGalPlayerState.ChoiceProtecting, null);
			this.StateMachine.Start(ECiacconaGalPlayerState.Initializing);
			this.StateChangeCallbacks = new List<Action<ECiacconaGalPlayerState>>();
			this.InternalStepAnimPlayRecordMap = new Dictionary<int, bool>();
		}

		// Token: 0x0603CEBD RID: 249533 RVA: 0x00F79E70 File Offset: 0x00F78070
		public void AddOnStateChange(Action<ECiacconaGalPlayerState> callback)
		{
			this.StateChangeCallbacks.Add(callback);
		}

		// Token: 0x0603CEBE RID: 249534 RVA: 0x00F79E80 File Offset: 0x00F78080
		public void RemoveOnStateChange(Action<ECiacconaGalPlayerState> callback)
		{
			int num = this.StateChangeCallbacks.IndexOf(callback);
			if (num >= 0)
			{
				this.StateChangeCallbacks.RemoveAt(num);
			}
		}

		// Token: 0x0603CEBF RID: 249535 RVA: 0x00F79EAA File Offset: 0x00F780AA
		public void SetAnimHandler(ICiacconaGalTextAnimHandler handler)
		{
			this.InternalAnimHandler = handler;
		}

		// Token: 0x0603CEC0 RID: 249536 RVA: 0x00F79EB4 File Offset: 0x00F780B4
		public bool HasPlayedStepAnim(int stepId)
		{
			bool flag;
			return this.InternalStepAnimPlayRecordMap.TryGetValue(stepId, out flag) && flag;
		}

		// Token: 0x0603CEC1 RID: 249537 RVA: 0x00F79ED4 File Offset: 0x00F780D4
		public ECiacconaGalPlayerState GetCurState()
		{
			return this.StateMachine.CurrentState.Value;
		}

		// Token: 0x0603CEC2 RID: 249538 RVA: 0x00F79EF4 File Offset: 0x00F780F4
		public void TrySwitchToState(ECiacconaGalPlayerState state)
		{
			this.InternalStatePendingToSwitch = (int)state;
		}

		// Token: 0x0603CEC3 RID: 249539 RVA: 0x00F79F00 File Offset: 0x00F78100
		public void SwitchState()
		{
			if (this.InternalStatePendingToSwitch == 0)
			{
				Singleton<Log>.Instance.Warn(ELogModule.CiacconaGal, ELogAuthor.HYF, "GalPlayer: 无状态切换请求", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (this.AnimHandler == null && this.InternalStatePendingToSwitch == 2)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.CiacconaGal;
				ELogAuthor author = ELogAuthor.HYF;
				string message = "GalPlayer: 未注册TextAnim组件, 禁止切换至播放态";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("目标状态: ", this.InternalStatePendingToSwitch);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.StateMachine.Switch((ECiacconaGalPlayerState)this.InternalStatePendingToSwitch);
		}

		// Token: 0x0603CEC4 RID: 249540 RVA: 0x00F79F8D File Offset: 0x00F7818D
		public void ClearStatePendingToSwitchByState(BaseCiacconaGalPlayerState state)
		{
			if (state == null)
			{
				return;
			}
			this.InternalStatePendingToSwitch = 0;
		}

		// Token: 0x0603CEC5 RID: 249541 RVA: 0x00F79F9C File Offset: 0x00F7819C
		public void TryContinue(int toStepId)
		{
			if (ModelBase<CiacconaGalModel>.Instance.TryPushCurStepDataById(toStepId))
			{
				this.CurHandlingStepId = toStepId;
				CiacconaGalStepData stepDataById = ModelBase<CiacconaGalModel>.Instance.GetStepDataById(toStepId);
				if (stepDataById.HasText)
				{
					this.TrySwitchToState(ECiacconaGalPlayerState.Playing);
					return;
				}
				if (stepDataById.Type == ECiacconaGalStepType.Choice)
				{
					this.TrySwitchToState(ECiacconaGalPlayerState.ChoiceProtecting);
					return;
				}
				if (stepDataById.Type == ECiacconaGalStepType.End)
				{
					this.TrySwitchToState(ECiacconaGalPlayerState.SubEnding);
					return;
				}
				this.TrySwitchToState(ECiacconaGalPlayerState.Pausing);
			}
		}

		// Token: 0x0603CEC6 RID: 249542 RVA: 0x00F7A004 File Offset: 0x00F78204
		public void OnClick(int? id = null)
		{
			(this.StateMachine.GetState(this.StateMachine.CurrentState.Value) as BaseCiacconaGalPlayerState).OnClick(id);
		}

		// Token: 0x0603CEC7 RID: 249543 RVA: 0x00F7A03C File Offset: 0x00F7823C
		public void NotifyStateChange(ECiacconaGalPlayerState state)
		{
			foreach (Action<ECiacconaGalPlayerState> action in this.StateChangeCallbacks)
			{
				action(state);
			}
		}

		// Token: 0x0603CEC8 RID: 249544 RVA: 0x00F7A090 File Offset: 0x00F78290
		public void Reset()
		{
			this.CurHandlingStepId = 0;
			this.CurHandlingChapterId = 0;
			this.InternalStatePendingToSwitch = 0;
			this.StateMachine.Switch(ECiacconaGalPlayerState.Initializing);
			this.InternalStepAnimPlayRecordMap.Clear();
		}

		// Token: 0x0603CEC9 RID: 249545 RVA: 0x00F7A0BF File Offset: 0x00F782BF
		public void Release()
		{
			this.Reset();
			this.StateChangeCallbacks.Clear();
		}

		// Token: 0x0603CECA RID: 249546 RVA: 0x00F7A0D4 File Offset: 0x00F782D4
		public void OnAnimEnd()
		{
			CiacconaGalStepData stepDataById = ModelBase<CiacconaGalModel>.Instance.GetStepDataById(this.CurHandlingStepId);
			if (stepDataById == null)
			{
				return;
			}
			this.InternalStepAnimPlayRecordMap[stepDataById.Id] = true;
			switch (stepDataById.Type)
			{
			case ECiacconaGalStepType.Normal:
				this.TrySwitchToState(ECiacconaGalPlayerState.Protecting);
				return;
			case ECiacconaGalStepType.Choice:
				this.TrySwitchToState(ECiacconaGalPlayerState.ChoiceProtecting);
				return;
			case ECiacconaGalStepType.End:
				this.TrySwitchToState(ECiacconaGalPlayerState.BeforeSubEnding);
				return;
			default:
				return;
			}
		}

		// Token: 0x0402234B RID: 140107
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private readonly StateMachine<CiacconaGalPlayer, ECiacconaGalPlayerState> StateMachine;

		// Token: 0x0402234C RID: 140108
		private readonly List<Action<ECiacconaGalPlayerState>> StateChangeCallbacks;

		// Token: 0x0402234D RID: 140109
		public int CurHandlingStepId;

		// Token: 0x0402234E RID: 140110
		public int CurHandlingChapterId;

		// Token: 0x0402234F RID: 140111
		private int InternalStatePendingToSwitch;

		// Token: 0x04022350 RID: 140112
		[Nullable(2)]
		private ICiacconaGalTextAnimHandler InternalAnimHandler;

		// Token: 0x04022351 RID: 140113
		private readonly Dictionary<int, bool> InternalStepAnimPlayRecordMap;
	}
}
