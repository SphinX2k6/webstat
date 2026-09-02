using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.Guarantee;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B8F RID: 27535
	[NullableContext(2)]
	[Nullable(0)]
	public class LevelEventEnableSplineMoveModel : LevelEventBase
	{
		// Token: 0x06043F50 RID: 278352 RVA: 0x0119AF59 File Offset: 0x01199159
		public LevelEventEnableSplineMoveModel(int Id) : base(Id)
		{
		}

		// Token: 0x06043F51 RID: 278353 RVA: 0x0119AF70 File Offset: 0x01199170
		[NullableContext(1)]
		public unsafe override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			this.InParams = (inParams as EnableSplineMoveModel);
			ISplineMoveConfig config = this.InParams.Config;
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
			bool allowInherit = false;
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
					base.FinishExecute(false, false, true);
					return;
				}
				TsBaseCharacter baseCharacter = Global.BaseCharacter;
				if (baseCharacter == null || !baseCharacter.IsValid())
				{
					this.DelayExecuteList.Add(new ValueTuple<ActionParams, GeneralContext>(inParams, context));
					if (this.DelayExecuteHandle == null)
					{
						this.DelayExecuteHandle = TimerSystem.Instance.Forever(new TTimerAction(this.OnRefreshBaseCharacter), 500f, 1f, null, null, true);
					}
					return;
				}
				entity = Global.BaseCharacter.GetEntityNoBlueprint();
				allowInherit = (((IPlayerEntity)config.Target).PlayerTargetType.GetValueOrDefault() == EPlayerTargetType.CurrentTeam);
			}
			else
			{
				if (triggerContext == null)
				{
					global::Log instance2 = Singleton<global::Log>.Instance;
					ELogModule module2 = ELogModule.LevelEvent;
					ELogAuthor author2 = ELogAuthor.LCZ;
					string message2 = "EnableSplineMoveModel: Triggered类型必须对应TriggerContext";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Type", config.Target.Type);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ContextType", context.Type);
					instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					base.FinishExecute(false, false, true);
					return;
				}
				entity = Singleton<EntitySystem>.Instance.Get(triggerContext.OtherEntityId.Value);
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
					base.FinishExecute(false, false, true);
					return;
				}
			}
			BaseSplineMoveComponent baseSplineMoveComponent = (entity != null) ? entity.GetComponent<BaseSplineMoveComponent>() : null;
			if (baseSplineMoveComponent == null || !baseSplineMoveComponent.Valid)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			if (config.Type == ESplineMoveConfigType.Open)
			{
				baseSplineMoveComponent.StartSplineMove(config.SplineEntityId, ((IOpenSplineMove)config).Pattern, allowInherit);
			}
			else
			{
				baseSplineMoveComponent.EndSplineMove(config.SplineEntityId);
			}
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06043F52 RID: 278354 RVA: 0x0119B254 File Offset: 0x01199454
		private void OnRefreshBaseCharacter(float _)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null || !baseCharacter.IsValid())
			{
				return;
			}
			TimerSystem.Instance.Remove(this.DelayExecuteHandle);
			this.DelayExecuteHandle = null;
			foreach (ValueTuple<ActionParams, GeneralContext> valueTuple in this.DelayExecuteList)
			{
				ActionParams item = valueTuple.Item1;
				GeneralContext item2 = valueTuple.Item2;
				this.ExecuteNew(item, item2, null);
			}
			this.DelayExecuteList.Clear();
		}

		// Token: 0x06043F53 RID: 278355 RVA: 0x0119B2F8 File Offset: 0x011994F8
		protected override void OnReset()
		{
			this.InParams = null;
		}

		// Token: 0x06043F54 RID: 278356 RVA: 0x0119B304 File Offset: 0x01199504
		protected override void OnUpdateGuarantee()
		{
			if (this.InParams == null)
			{
				return;
			}
			EnableSplineMoveModel @params = new EnableSplineMoveModel
			{
				Config = new ICloseSplineMove
				{
					Type = ESplineMoveConfigType.Close,
					Target = this.InParams.Config.Target,
					SplineEntityId = this.InParams.Config.SplineEntityId
				}
			};
			GuaranteeActionInfo p = new GuaranteeActionInfo
			{
				Name = EGuaranteeAction.DisableSplineMoveModel,
				Params = @params
			};
			ESplineMoveConfigType type = this.InParams.Config.Type;
			if (type == ESplineMoveConfigType.Open)
			{
				Singleton<EventSystem>.Instance.Emit<string, GeneralContext, GuaranteeActionInfo, bool?>(EEventName.AddGuaranteeAction, this.Type, this.BaseContext, p, new bool?(true));
				return;
			}
			if (type != ESplineMoveConfigType.Close)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<string, GeneralContext, GuaranteeActionInfo, bool?>(EEventName.RemGuaranteeAction, this.Type, this.BaseContext, p, new bool?(true));
		}

		// Token: 0x04026009 RID: 155657
		private const int CHECK_BASE_CHARACTER_INTERVAL = 500;

		// Token: 0x0402600A RID: 155658
		private EnableSplineMoveModel InParams;

		// Token: 0x0402600B RID: 155659
		private TimerHandle DelayExecuteHandle;

		// Token: 0x0402600C RID: 155660
		[Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})]
		private readonly List<ValueTuple<ActionParams, GeneralContext>> DelayExecuteList = new List<ValueTuple<ActionParams, GeneralContext>>();
	}
}
