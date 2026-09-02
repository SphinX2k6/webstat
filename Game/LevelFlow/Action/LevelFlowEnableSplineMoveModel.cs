using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006F8F RID: 28559
	[NullableContext(2)]
	[Nullable(0)]
	public class LevelFlowEnableSplineMoveModel : LevelFlowActionBase
	{
		// Token: 0x06045195 RID: 283029 RVA: 0x0120621D File Offset: 0x0120441D
		[NullableContext(1)]
		public LevelFlowEnableSplineMoveModel Init(EnableSplineMoveModel inParams, [Nullable(2)] GeneralContext context)
		{
			this.InParams = inParams;
			this.Context = context;
			return this;
		}

		// Token: 0x06045196 RID: 283030 RVA: 0x01206230 File Offset: 0x01204430
		protected unsafe override void OnExecute()
		{
			ISplineMoveConfig config = this.InParams.Config;
			GeneralContext context = this.Context;
			TriggerContext triggerContext = context as TriggerContext;
			if (triggerContext != null)
			{
				if (triggerContext.TriggerEntityId != null)
				{
					Singleton<EntitySystem>.Instance.Get(triggerContext.TriggerEntityId.Value);
				}
				if (triggerContext.OtherEntityId != null)
				{
					Singleton<EntitySystem>.Instance.Get(triggerContext.OtherEntityId.Value);
				}
			}
			ETargetEntityType type = config.Target.Type;
			Entity entity;
			if (type != ETargetEntityType.Triggered)
			{
				if (type != ETargetEntityType.Player)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.LevelEvent;
					ELogAuthor author = ELogAuthor.LCZ;
					string message = "EnableSplineMoveModel不接受此对象类型";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", config.Target.Type);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					base.FinishExecute(false);
					return;
				}
				TsBaseCharacter baseCharacter = Global.BaseCharacter;
				if (baseCharacter == null || !baseCharacter.IsValid())
				{
					if (this.DelayExecuteHandle == null)
					{
						this.DelayExecuteHandle = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnRefreshBaseCharacter), 500f, 1f, null, null, true);
					}
					return;
				}
				entity = Global.BaseCharacter.GetEntityNoBlueprint();
			}
			else
			{
				TriggerContext triggerContext2 = context as TriggerContext;
				if (triggerContext2 == null)
				{
					global::Log instance2 = Singleton<global::Log>.Instance;
					ELogModule module2 = ELogModule.LevelEvent;
					ELogAuthor author2 = ELogAuthor.LCZ;
					string message2 = "EnableSplineMoveModel: Triggered类型必须对应TriggerContext";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Type", config.Target.Type);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ContextType", context.Type);
					instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					base.FinishExecute(false);
					return;
				}
				entity = Singleton<EntitySystem>.Instance.Get(triggerContext2.OtherEntityId.Value);
				if (entity == null || !entity.Valid)
				{
					global::Log instance3 = Singleton<global::Log>.Instance;
					ELogModule module3 = ELogModule.LevelEvent;
					ELogAuthor author3 = ELogAuthor.LCZ;
					string message3 = "EnableSplineMoveModel: 未找到合法的触发者实体";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Type", config.Target.Type);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("ContextType", context.Type);
					instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
					base.FinishExecute(false);
					return;
				}
			}
			BaseSplineMoveComponent baseSplineMoveComponent = (entity != null) ? entity.GetComponent<BaseSplineMoveComponent>() : null;
			if (baseSplineMoveComponent == null || !baseSplineMoveComponent.Valid)
			{
				base.FinishExecute(false);
				return;
			}
			if (config.Type == ESplineMoveConfigType.Open)
			{
				IOpenSplineMove openSplineMove = config as IOpenSplineMove;
				if (openSplineMove != null)
				{
					baseSplineMoveComponent.StartSplineMove(config.SplineEntityId, openSplineMove.Pattern, false);
					goto IL_292;
				}
			}
			baseSplineMoveComponent.EndSplineMove(config.SplineEntityId);
			IL_292:
			base.FinishExecute(true);
		}

		// Token: 0x06045197 RID: 283031 RVA: 0x012064D6 File Offset: 0x012046D6
		private void OnRefreshBaseCharacter(float _)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null || !baseCharacter.IsValid())
			{
				return;
			}
			TimerSystem.GameplayTimeInstance.Remove(this.DelayExecuteHandle);
			base.Execute();
		}

		// Token: 0x040268EE RID: 157934
		private EnableSplineMoveModel InParams;

		// Token: 0x040268EF RID: 157935
		private GeneralContext Context;

		// Token: 0x040268F0 RID: 157936
		private TimerHandle DelayExecuteHandle;

		// Token: 0x040268F1 RID: 157937
		private const int CHECK_BASE_CHARACTER_INTERVAL = 500;
	}
}
