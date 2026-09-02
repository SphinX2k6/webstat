using System;
using System.Runtime.CompilerServices;
using System.Text;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Utils.CombatStateMachine;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.AI.StateMachine.Task
{
	// Token: 0x020070DE RID: 28894
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineTaskSkill : AiStateMachineTask
	{
		// Token: 0x060460EF RID: 286959 RVA: 0x01266A76 File Offset: 0x01264C76
		public AiStateMachineTaskSkill(AiStateMachineBase StateMachineNode, CombatStateMachineDefine.Fsm.Task State) : base(StateMachineNode, State)
		{
		}

		// Token: 0x1700A5EF RID: 42479
		// (get) Token: 0x060460F0 RID: 286960 RVA: 0x01266A9D File Offset: 0x01264C9D
		// (set) Token: 0x060460F1 RID: 286961 RVA: 0x01266AA5 File Offset: 0x01264CA5
		public override bool IsAsyncTask { get; set; } = true;

		// Token: 0x060460F2 RID: 286962 RVA: 0x01266AB0 File Offset: 0x01264CB0
		protected unsafe override bool OnInit(CombatStateMachineDefine.Fsm.Task state)
		{
			if (this.Node.SkillId != 0L)
			{
				this.Node.Owner.PushErrorMessage("状态节点配置错误，重复配置技能，节点[" + this.Node.Name + "]]");
				return false;
			}
			if (state.TaskSkillByName != null)
			{
				this.SkillName = state.TaskSkillByName.SkillName;
				this.ConfigReplaceTagId = state.TaskSkillByName.ConfigReplaceTagId;
				this.ConfigReplaceTagName = state.TaskSkillByName.ConfigReplaceTagName;
				this.SkillId = this.Node.Entity.GetComponent<CharacterSkillComponent>().GetSkillIdByName(this.SkillName).GetValueOrDefault();
				this.Node.SkillId = (long)this.SkillId;
			}
			else if (state.TaskSkill != null)
			{
				this.SkillId = state.TaskSkill.SkillId;
				this.ConfigReplaceTagId = state.TaskSkill.ConfigReplaceTagId;
				this.ConfigReplaceTagName = state.TaskSkill.ConfigReplaceTagName;
				this.Node.SkillId = (long)state.TaskSkill.SkillId;
			}
			else
			{
				this.Node.Owner.PushErrorMessage("状态节点配置错误，技能为空，节点[" + this.Node.Name + "]]");
			}
			if (!string.IsNullOrEmpty(this.ConfigReplaceTagName) && this.ConfigReplaceTagName != "None")
			{
				this.ReplaceConfig = this.Node.FindStateRepPerfConfig(this.ConfigReplaceTagName);
				IStateRepPerfBase replaceConfig = this.ReplaceConfig;
				if (replaceConfig != null && replaceConfig.Type == EStateRepPerfType.SkillId)
				{
					IStateRepPerfSkillId stateRepPerfSkillId = this.ReplaceConfig as IStateRepPerfSkillId;
					if (stateRepPerfSkillId == null || stateRepPerfSkillId.SkillId != 0L)
					{
						int skillId = this.SkillId;
						this.SkillId = (int)stateRepPerfSkillId.SkillId;
						this.Node.SkillId = stateRepPerfSkillId.SkillId;
						CombatLog instance = Singleton<CombatLog>.Instance;
						CombatLog.EDebugModule flag = CombatLog.EDebugModule.StateMachineNew;
						AiStateMachineBase node = this.Node;
						Entity entity = (node != null) ? node.Entity : null;
						string message = "SkillTask技能替换成功";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("原SkillId", skillId);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("新SkillId", stateRepPerfSkillId.SkillId);
						instance.Info(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					}
				}
				else if (this.ReplaceConfig != null)
				{
					CombatLog instance2 = Singleton<CombatLog>.Instance;
					CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.StateMachineNew;
					AiStateMachineBase node2 = this.Node;
					Entity entity2 = (node2 != null) ? node2.Entity : null;
					string message2 = "SkillTask替换配置错误，替换配置不生效";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("节点", this.Node.Name);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("ConfigReplaceTagName", this.ConfigReplaceTagName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("配置覆盖Type", this.ReplaceConfig.Type);
					instance2.Error(flag2, entity2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				}
			}
			return true;
		}

		// Token: 0x060460F3 RID: 286963 RVA: 0x01266DA8 File Offset: 0x01264FA8
		public override void OnEnter(long? contextId = null)
		{
			if (this.SkillId == 0)
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.StateMachineNew;
				Entity entity = this.Node.Entity;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 2);
				defaultInterpolatedStringHandler.AppendLiteral("状态节点执行技能失败，技能查询失败，节点[");
				defaultInterpolatedStringHandler.AppendFormatted(this.Node.Name);
				defaultInterpolatedStringHandler.AppendLiteral("]，技能名[");
				defaultInterpolatedStringHandler.AppendFormatted(this.SkillName);
				defaultInterpolatedStringHandler.AppendLiteral("]");
				instance.Error(flag, entity, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.PreExecution = this.Node.RootNode.WaitSwitchState;
			this.Done = false;
			if (this.SkillId != 0 && (this.Node.ActorComponent.IsAutonomousProxy || this.PreExecution))
			{
				this.Node.SkillComponent.StopAllSkills("AiStateMachineTaskSkill.OnEnter");
				EntityHandle currentTarget = this.Node.AiController.AiHateList.GetCurrentTarget();
				this.Entered = true;
				this.Node.SkillComponent.BeginSkillAsync(this.SkillId, new SkillParam
				{
					Target = ((currentTarget != null) ? currentTarget.Entity : null),
					ContextId = contextId,
					Reason = "AiStateMachineTaskSkill.OnEnter"
				}).ContinueWith(delegate(bool result)
				{
					this.WaitingBeginSkill = false;
					this.Done = result;
					Singleton<CombatNet>.Instance.RemovePendingCall(contextId.GetValueOrDefault());
				});
				this.WaitingBeginSkill = true;
			}
		}

		// Token: 0x060460F4 RID: 286964 RVA: 0x01266F1C File Offset: 0x0126511C
		protected override void OnTick(float deltaSeconds, long? contextId = null)
		{
			if (this.Entered && !this.WaitingBeginSkill && !this.Done && (this.Node.ActorComponent.IsAutonomousProxy || this.PreExecution))
			{
				if (this.Node.ElapseTime < (float)this.Timeout)
				{
					this.Node.SkillComponent.BeginSkillAsync(this.SkillId, new SkillParam
					{
						ContextId = contextId,
						Reason = "AiStateMachineTaskSkill.OnTick"
					}).ContinueWith(delegate(bool result)
					{
						this.Done = result;
					});
					return;
				}
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.StateMachineNew;
				Entity entity = this.Node.Entity;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 2);
				defaultInterpolatedStringHandler.AppendLiteral("状态机技能释放失败 节点[");
				defaultInterpolatedStringHandler.AppendFormatted(this.Node.Name);
				defaultInterpolatedStringHandler.AppendLiteral("]，技能名[");
				defaultInterpolatedStringHandler.AppendFormatted(this.SkillName);
				defaultInterpolatedStringHandler.AppendLiteral("]");
				instance.Info(flag, entity, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				UseSkillFailPush useSkillFailPush = UseSkillFailPush.Create();
				useSkillFailPush.SkillId = (long)this.SkillId;
				Singleton<CombatNet>.Instance.Send(EPushMessageId.UseSkillFailPush, this.Node.Entity, useSkillFailPush, contextId, null, null);
				this.Node.TaskFinished = true;
				this.Done = true;
			}
		}

		// Token: 0x060460F5 RID: 286965 RVA: 0x01267085 File Offset: 0x01265285
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}

		// Token: 0x040274D9 RID: 160985
		public string SkillName = "";

		// Token: 0x040274DA RID: 160986
		public int SkillId;

		// Token: 0x040274DB RID: 160987
		public int ConfigReplaceTagId;

		// Token: 0x040274DC RID: 160988
		public string ConfigReplaceTagName = "";

		// Token: 0x040274DD RID: 160989
		[Nullable(2)]
		private IStateRepPerfBase ReplaceConfig;

		// Token: 0x040274DE RID: 160990
		public int Timeout;

		// Token: 0x040274DF RID: 160991
		public bool Done;

		// Token: 0x040274E0 RID: 160992
		public bool Entered;

		// Token: 0x040274E1 RID: 160993
		private bool WaitingBeginSkill;

		// Token: 0x040274E2 RID: 160994
		public bool PreExecution;
	}
}
