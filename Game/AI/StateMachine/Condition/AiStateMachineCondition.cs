using System;
using System.Runtime.CompilerServices;
using System.Text;
using Aki.Protocol;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using CSharpScript.Game.Utils.CombatStateMachine;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.AI.StateMachine.Condition
{
	// Token: 0x020070F0 RID: 28912
	[NullableContext(2)]
	[Nullable(0)]
	public class AiStateMachineCondition
	{
		// Token: 0x1700A5F3 RID: 42483
		// (get) Token: 0x06046155 RID: 287061 RVA: 0x0126874D File Offset: 0x0126694D
		public bool Result
		{
			get
			{
				return this.ResultSelf == !this.Reverse;
			}
		}

		// Token: 0x06046156 RID: 287062 RVA: 0x01268760 File Offset: 0x01266960
		[NullableContext(1)]
		public AiStateMachineCondition(AiStateMachineTransition transition, CombatStateMachineDefine.Fsm.Condition condition, int index)
		{
			this.Node = transition.Node;
			this.Transition = transition;
			this.ConditionData = condition;
			this.Reverse = condition.Reverse;
			this.Index = new int?(index);
		}

		// Token: 0x06046157 RID: 287063 RVA: 0x0126879A File Offset: 0x0126699A
		public bool Init(AiStateMachineCondition parentCondition = null)
		{
			this.CheckForClient = this.ConditionData.IsClient.GetValueOrDefault();
			this.Inited = this.OnInit(this.ConditionData);
			this.ParentCondition = parentCondition;
			return this.Inited;
		}

		// Token: 0x06046158 RID: 287064 RVA: 0x012687D1 File Offset: 0x012669D1
		[NullableContext(1)]
		protected virtual bool OnInit(CombatStateMachineDefine.Fsm.Condition condition)
		{
			return true;
		}

		// Token: 0x06046159 RID: 287065 RVA: 0x012687D4 File Offset: 0x012669D4
		public void Enter()
		{
			this.LastResult = null;
			this.OnEnter();
		}

		// Token: 0x0604615A RID: 287066 RVA: 0x012687E8 File Offset: 0x012669E8
		protected virtual void OnEnter()
		{
		}

		// Token: 0x0604615B RID: 287067 RVA: 0x012687EA File Offset: 0x012669EA
		public void Exit()
		{
			this.LastResult = null;
			this.OnExit();
		}

		// Token: 0x0604615C RID: 287068 RVA: 0x012687FE File Offset: 0x012669FE
		protected virtual void OnExit()
		{
		}

		// Token: 0x0604615D RID: 287069 RVA: 0x01268800 File Offset: 0x01266A00
		public void Tick()
		{
			this.OnTick();
			if (this.CanReqFsmConditionPass())
			{
				this.ReqFsmConditionPass();
			}
			this.LastResult = new bool?(this.Result);
		}

		// Token: 0x0604615E RID: 287070 RVA: 0x01268828 File Offset: 0x01266A28
		protected bool CanReqFsmConditionPass()
		{
			if (!this.Node.RootNode.IsAnimStateMachine && this.CheckForClient)
			{
				bool result = this.Result;
				bool? lastResult = this.LastResult;
				return !(result == lastResult.GetValueOrDefault() & lastResult != null);
			}
			return false;
		}

		// Token: 0x0604615F RID: 287071 RVA: 0x01268874 File Offset: 0x01266A74
		protected void ReqFsmConditionPass()
		{
			FsmConditionPassPush fsmConditionPassPush = FsmConditionPassPush.Create();
			fsmConditionPassPush.FsmId = this.Node.RootNode.Uuid;
			fsmConditionPassPush.FromState = this.Transition.From;
			fsmConditionPassPush.ToState = this.Transition.To;
			fsmConditionPassPush.ConditionIndex = this.Index.Value;
			fsmConditionPassPush.Value = this.Result;
			Singleton<CombatNet>.Instance.Send(EPushMessageId.FsmConditionPassPush, this.Node.Entity, fsmConditionPassPush, null, null, null);
		}

		// Token: 0x06046160 RID: 287072 RVA: 0x01268913 File Offset: 0x01266B13
		protected virtual void OnTick()
		{
		}

		// Token: 0x06046161 RID: 287073 RVA: 0x01268915 File Offset: 0x01266B15
		public void Clear()
		{
			this.OnClear();
			this.Node = null;
			this.Transition = null;
			this.ConditionData = null;
			this.ParentCondition = null;
		}

		// Token: 0x06046162 RID: 287074 RVA: 0x01268939 File Offset: 0x01266B39
		protected virtual void OnClear()
		{
		}

		// Token: 0x06046163 RID: 287075 RVA: 0x0126893B File Offset: 0x01266B3B
		[NullableContext(1)]
		public virtual void HandleServerDebugInfo(RepeatedField<bool> conditions)
		{
			this.ResultServer = conditions[this.Index.Value];
		}

		// Token: 0x06046164 RID: 287076 RVA: 0x01268954 File Offset: 0x01266B54
		public virtual void OnSignaled()
		{
		}

		// Token: 0x06046165 RID: 287077 RVA: 0x01268958 File Offset: 0x01266B58
		public void Signaled()
		{
			if (!CharacterStateMachineNewComponent.EventDrivenOn)
			{
				return;
			}
			if (!this.CheckForClient)
			{
				return;
			}
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.StateMachineNew;
			AiStateMachineBase node = this.Node;
			Entity entity = (node != null) ? node.Entity : null;
			string message = "Signaled";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("condition", this.ConditionData.Name);
			instance.Info(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.HasSignaled = true;
			if (this.CanReqFsmConditionPass())
			{
				this.ReqFsmConditionPass();
			}
			this.LastResult = new bool?(this.Result);
			if (this.ParentCondition != null)
			{
				this.ParentCondition.OnSignaled();
				return;
			}
			if (this.Result)
			{
				AiStateMachineBase node2 = this.Node;
				if (node2 == null)
				{
					return;
				}
				node2.TrySwitch(this.Transition.To);
			}
		}

		// Token: 0x06046166 RID: 287078 RVA: 0x01268A14 File Offset: 0x01266C14
		protected virtual bool RegisterEvents()
		{
			return CharacterStateMachineNewComponent.EventDrivenOn;
		}

		// Token: 0x06046167 RID: 287079 RVA: 0x01268A1B File Offset: 0x01266C1B
		protected virtual bool UnregisterEvents()
		{
			return CharacterStateMachineNewComponent.EventDrivenOn;
		}

		// Token: 0x06046168 RID: 287080 RVA: 0x01268A24 File Offset: 0x01266C24
		[NullableContext(1)]
		public virtual void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(2, 1, outBuilder);
			appendInterpolatedStringHandler.AppendLiteral("[");
			appendInterpolatedStringHandler.AppendFormatted(this.Result ? "Y" : "N");
			appendInterpolatedStringHandler.AppendLiteral(" ");
			outBuilder.Append(ref appendInterpolatedStringHandler);
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(1, 1, outBuilder);
			appendInterpolatedStringHandler.AppendFormatted(this.ResultServer ? "Y" : "N");
			appendInterpolatedStringHandler.AppendLiteral(" ");
			outBuilder.Append(ref appendInterpolatedStringHandler);
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(2, 1, outBuilder);
			appendInterpolatedStringHandler.AppendFormatted(this.CheckForClient ? "C" : "S");
			appendInterpolatedStringHandler.AppendLiteral("] ");
			outBuilder.Append(ref appendInterpolatedStringHandler);
			if (this.Reverse)
			{
				outBuilder.Append("[取反] ");
			}
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(0, 1, outBuilder);
			appendInterpolatedStringHandler.AppendFormatted(this.ConditionData.Name);
			outBuilder.Append(ref appendInterpolatedStringHandler);
		}

		// Token: 0x04027513 RID: 161043
		protected bool Inited;

		// Token: 0x04027514 RID: 161044
		public AiStateMachineBase Node;

		// Token: 0x04027515 RID: 161045
		public AiStateMachineTransition Transition;

		// Token: 0x04027516 RID: 161046
		public AiStateMachineCondition ParentCondition;

		// Token: 0x04027517 RID: 161047
		public CombatStateMachineDefine.Fsm.Condition ConditionData;

		// Token: 0x04027518 RID: 161048
		public int? Index;

		// Token: 0x04027519 RID: 161049
		public bool CheckForClient;

		// Token: 0x0402751A RID: 161050
		public bool Reverse;

		// Token: 0x0402751B RID: 161051
		public bool ResultSelf;

		// Token: 0x0402751C RID: 161052
		public bool? LastResult;

		// Token: 0x0402751D RID: 161053
		public bool HasTaskFinishCondition;

		// Token: 0x0402751E RID: 161054
		public bool HasSignaled;

		// Token: 0x0402751F RID: 161055
		public bool ResultServer;
	}
}
