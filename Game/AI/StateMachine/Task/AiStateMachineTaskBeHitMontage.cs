using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Task
{
	// Token: 0x020070D5 RID: 28885
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineTaskBeHitMontage : AiStateMachineTask, IAiTaskMontage
	{
		// Token: 0x1700A5E6 RID: 42470
		// (get) Token: 0x0604608A RID: 286858 RVA: 0x01263C8C File Offset: 0x01261E8C
		// (set) Token: 0x0604608B RID: 286859 RVA: 0x01263C94 File Offset: 0x01261E94
		public bool Playing { get; set; }

		// Token: 0x1700A5E7 RID: 42471
		// (get) Token: 0x0604608C RID: 286860 RVA: 0x01263C9D File Offset: 0x01261E9D
		// (set) Token: 0x0604608D RID: 286861 RVA: 0x01263CA5 File Offset: 0x01261EA5
		public float RemainedTrigger { get; set; } = -1f;

		// Token: 0x0604608E RID: 286862 RVA: 0x01263CAE File Offset: 0x01261EAE
		public AiStateMachineTaskBeHitMontage(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.Task state) : base(stateMachineNode, state)
		{
		}

		// Token: 0x1700A5E8 RID: 42472
		// (get) Token: 0x0604608F RID: 286863 RVA: 0x01263CE4 File Offset: 0x01261EE4
		public bool HasResource
		{
			get
			{
				return this.MontageHandle != null;
			}
		}

		// Token: 0x06046090 RID: 286864 RVA: 0x01263CF4 File Offset: 0x01261EF4
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Task task)
		{
			this.DefaultMontageName = task.TaskBeHitMontage.DefaultMontageName;
			foreach (ValueTuple<int, string> valueTuple in task.TaskBeHitMontage.MontageMap)
			{
				this.MontageMap[(EHitAnim)valueTuple.Item1] = valueTuple.Item2;
			}
			this.BlendInTime = task.TaskBeHitMontage.BlendInTime * 0.001f;
			return true;
		}

		// Token: 0x06046091 RID: 286865 RVA: 0x01263D88 File Offset: 0x01261F88
		private void ActivateHitStateByHitAnim(EHitAnim beHitAnim)
		{
			if (this.Node.UnifiedStateComponent.PositionState == ECharPositionState.Air)
			{
				this.Node.UnifiedStateComponent.SetMoveState(ECharMoveState.KnockUp);
				return;
			}
			switch (beHitAnim)
			{
			case EHitAnim.轻左:
			case EHitAnim.轻右:
			case EHitAnim.轻前:
			case EHitAnim.轻后:
				this.Node.UnifiedStateComponent.SetMoveState(ECharMoveState.SoftKnock);
				return;
			case EHitAnim.重左:
			case EHitAnim.重右:
			case EHitAnim.压制:
			case EHitAnim.重前:
			case EHitAnim.重后:
				this.Node.UnifiedStateComponent.SetMoveState(ECharMoveState.HeavyKnock);
				return;
			case EHitAnim.击飞:
			case EHitAnim.击倒:
				this.Node.UnifiedStateComponent.SetMoveState(ECharMoveState.KnockUp);
				return;
			case EHitAnim.被弹反:
				this.Node.UnifiedStateComponent.SetMoveState(ECharMoveState.Parry);
				return;
			case EHitAnim.被破弱:
				this.Node.UnifiedStateComponent.SetMoveState(ECharMoveState.BreakWeakness);
				return;
			default:
				return;
			}
		}

		// Token: 0x06046092 RID: 286866 RVA: 0x01263E54 File Offset: 0x01262054
		public unsafe override void OnEnter(long? contextId = null)
		{
			if (this.Node.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"]))
			{
				this.Node.TaskFinished = true;
				return;
			}
			EHitAnim beHitAnim = this.Node.HitComponent.BeHitAnim;
			this.ActivateHitStateByHitAnim(beHitAnim);
			this.MontageName = this.MontageMap.GetValueOrDefault(beHitAnim);
			if (string.IsNullOrEmpty(this.MontageName))
			{
				this.MontageName = this.DefaultMontageName;
			}
			if (string.IsNullOrEmpty(this.MontageName))
			{
				CreatureDataComponent component = this.Node.Entity.GetComponent<CreatureDataComponent>();
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Resource;
				ELogAuthor author = ELogAuthor.WCL;
				string message = "受击动画播放失败，MontageName为空";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
				string item = "actorName";
				CharacterActorComponent actorComponent = this.Node.ActorComponent;
				ptr = new ValueTuple<string, object>(item, (actorComponent != null) ? actorComponent.Actor.GetName() : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("pbDataId", component.GetPbDataId());
				ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
				string item2 = "nodeName";
				AiStateMachineBase node = this.Node;
				ptr2 = new ValueTuple<string, object>(item2, (node != null) ? node.Name : null);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
			this.Node.SkillComponent.StopGroup1Skill("AiStateMachineTaskBeHitMontage.OnEnter");
			this.Node.TaskFinished = false;
			this.Playing = false;
			CharacterMontageComponent montageComponent = this.Node.MontageComponent;
			if (this.MontageHandle == null)
			{
				this.MontageHandle = montageComponent.CreateTaskWithName(this.MontageName, null, new Action<bool>(this.OnMontageEnd), this.BlendInTime);
				if (this.MontageHandle == null && this.MontageName != this.DefaultMontageName)
				{
					if (string.IsNullOrEmpty(this.DefaultMontageName))
					{
						CombatLog instance2 = Singleton<CombatLog>.Instance;
						CombatLog.EDebugModule flag = CombatLog.EDebugModule.StateMachine;
						Entity entity = this.Node.Entity;
						string message2 = "播放空白蒙太奇路径";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("MontageName", this.MontageName);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("DefaultMontageName", this.DefaultMontageName);
						instance2.Error(flag, entity, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
					}
					this.MontageName = this.DefaultMontageName;
					this.MontageHandle = montageComponent.CreateTaskWithName(this.MontageName, null, new Action<bool>(this.OnMontageEnd), this.BlendInTime);
				}
			}
			if (this.MontageHandle != null)
			{
				CharacterHitComponent hitComponent = this.Node.HitComponent;
				if (hitComponent != null)
				{
					hitComponent.ConfirmExecutedBeHitState();
				}
				this.Playing = true;
				montageComponent.PlayMontageTaskWhenReady(this.MontageHandle.Value, (float)((double)this.Node.ElapseTime * Singleton<TimeUtil>.Instance.Millisecond), new long?(contextId.GetValueOrDefault()), -1f);
				return;
			}
			this.Node.TaskFinished = true;
		}

		// Token: 0x06046093 RID: 286867 RVA: 0x0126413C File Offset: 0x0126233C
		public override void OnExit(long? contextId = null)
		{
			if (this.MontageHandle != null)
			{
				this.Node.MontageComponent.EndMontageTask(this.MontageHandle.Value);
			}
			this.MontageHandle = null;
			this.Node.TaskFinished = false;
			this.Playing = false;
		}

		// Token: 0x06046094 RID: 286868 RVA: 0x01264190 File Offset: 0x01262390
		protected override void OnTick(float deltaSeconds, long? contextId = null)
		{
			if (this.MontageHandle != null)
			{
				this.Node.MontageComponent.GetMontageTimeRemaining(this.MontageHandle.Value);
			}
		}

		// Token: 0x06046095 RID: 286869 RVA: 0x012641BB File Offset: 0x012623BB
		protected override void OnClear()
		{
			if (this.MontageHandle != null)
			{
				this.Node.MontageComponent.EndMontageTask(this.MontageHandle.Value);
			}
			this.MontageHandle = null;
		}

		// Token: 0x06046096 RID: 286870 RVA: 0x012641F1 File Offset: 0x012623F1
		private void OnMontageEnd(bool isInterrupted)
		{
			this.Node.TaskFinished = true;
		}

		// Token: 0x06046097 RID: 286871 RVA: 0x012641FF File Offset: 0x012623FF
		public double GetTimeRemaining()
		{
			return (double)((this.MontageHandle != null) ? this.Node.MontageComponent.GetMontageTimeRemaining(this.MontageHandle.Value) : -1f);
		}

		// Token: 0x06046098 RID: 286872 RVA: 0x01264231 File Offset: 0x01262431
		public double GetTimeElapsing()
		{
			return (double)((this.MontageHandle != null) ? this.Node.MontageComponent.GetMontageTimeElapsing(this.MontageHandle.Value) : -1f);
		}

		// Token: 0x06046099 RID: 286873 RVA: 0x01264263 File Offset: 0x01262463
		public double GetTimeLength()
		{
			return (double)((this.MontageHandle != null) ? this.Node.MontageComponent.GetMontageTimeLength(this.MontageHandle.Value) : -1f);
		}

		// Token: 0x0604609A RID: 286874 RVA: 0x01264295 File Offset: 0x01262495
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}

		// Token: 0x0604609B RID: 286875 RVA: 0x0126429E File Offset: 0x0126249E
		[NullableContext(2)]
		private string GetNameByHandle(int handle)
		{
			return this.Node.MontageComponent.GetMontageTaskNameByHandle(handle);
		}

		// Token: 0x0604609C RID: 286876 RVA: 0x012642B1 File Offset: 0x012624B1
		[NullableContext(2)]
		public string GetNameByCurrentHandle()
		{
			if (this.MontageHandle != null)
			{
				return this.GetNameByHandle(this.MontageHandle.Value);
			}
			return null;
		}

		// Token: 0x04027491 RID: 160913
		private float BlendInTime;

		// Token: 0x04027492 RID: 160914
		private int? MontageHandle;

		// Token: 0x04027494 RID: 160916
		private string DefaultMontageName = "";

		// Token: 0x04027495 RID: 160917
		private readonly Dictionary<EHitAnim, string> MontageMap = new Dictionary<EHitAnim, string>();

		// Token: 0x04027496 RID: 160918
		[Nullable(2)]
		private string MontageName = "";
	}
}
