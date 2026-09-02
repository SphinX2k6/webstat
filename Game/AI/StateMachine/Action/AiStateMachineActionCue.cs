using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Action
{
	// Token: 0x0200710D RID: 28941
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineActionCue : AiStateMachineAction
	{
		// Token: 0x06046210 RID: 287248 RVA: 0x0126B4DF File Offset: 0x012696DF
		public AiStateMachineActionCue(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.Action action) : base(stateMachineNode, action)
		{
		}

		// Token: 0x06046211 RID: 287249 RVA: 0x0126B4F4 File Offset: 0x012696F4
		protected unsafe override bool OnInit(CombatStateMachineDefine.Fsm.Action action)
		{
			this.CueIds = new List<long>();
			foreach (long item in action.ActionCue.CueIds)
			{
				this.CueIds.Add(item);
			}
			this.ConfigReplaceTagId = action.ActionCue.ConfigReplaceTagId;
			this.ConfigReplaceTagName = action.ActionCue.ConfigReplaceTagName;
			if (!string.IsNullOrEmpty(this.ConfigReplaceTagName) && this.ConfigReplaceTagName != "None")
			{
				this.ReplaceConfig = this.Node.FindStateRepPerfConfig(this.ConfigReplaceTagName);
				IStateRepPerfBase replaceConfig = this.ReplaceConfig;
				if (replaceConfig != null && replaceConfig.Type == EStateRepPerfType.Effects)
				{
					IStateRepPerfEffects stateRepPerfEffects = this.ReplaceConfig as IStateRepPerfEffects;
					if (((stateRepPerfEffects != null) ? stateRepPerfEffects.GamePlayCues : null) != null)
					{
						List<long> cueIds = this.CueIds;
						this.CueIds = new List<long>();
						foreach (int num in stateRepPerfEffects.GamePlayCues)
						{
							this.CueIds.Add((long)num);
						}
						CombatLog instance = Singleton<CombatLog>.Instance;
						CombatLog.EDebugModule flag = CombatLog.EDebugModule.StateMachineNew;
						AiStateMachineBase node = this.Node;
						Entity entity = (node != null) ? node.Entity : null;
						string message = "ActionCue特效替换成功";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("原CueIds", cueIds);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("新CueIds", this.CueIds);
						instance.Info(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					}
				}
				else if (this.ReplaceConfig != null)
				{
					CombatLog instance2 = Singleton<CombatLog>.Instance;
					CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.StateMachineNew;
					AiStateMachineBase node2 = this.Node;
					Entity entity2 = (node2 != null) ? node2.Entity : null;
					string message2 = "ActionCue替换配置错误，替换配置不生效";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("节点", this.Node.Name);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("ConfigReplaceTagName", this.ConfigReplaceTagName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("配置覆盖Type", this.ReplaceConfig.Type);
					instance2.Error(flag2, entity2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				}
			}
			return true;
		}

		// Token: 0x06046212 RID: 287250 RVA: 0x0126B768 File Offset: 0x01269968
		public override void DoAction(long? contextId = null)
		{
			foreach (long cueId in this.CueIds)
			{
				this.Node.GameplayCueComponent.AddCue(cueId, new GameplayCueParam?(new GameplayCueParam
				{
					Instant = true
				}));
			}
		}

		// Token: 0x06046213 RID: 287251 RVA: 0x0126B7DC File Offset: 0x012699DC
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}

		// Token: 0x0402754F RID: 161103
		[Nullable(2)]
		private List<long> CueIds;

		// Token: 0x04027550 RID: 161104
		public int ConfigReplaceTagId;

		// Token: 0x04027551 RID: 161105
		public string ConfigReplaceTagName = "";

		// Token: 0x04027552 RID: 161106
		[Nullable(2)]
		private IStateRepPerfBase ReplaceConfig;
	}
}
