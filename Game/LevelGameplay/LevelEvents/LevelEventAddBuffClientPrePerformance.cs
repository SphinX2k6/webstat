using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.NewWorld.Character.Custom.Components;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B62 RID: 27490
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class LevelEventAddBuffClientPrePerformance : LevelEventBase
	{
		// Token: 0x06043E75 RID: 278133 RVA: 0x0118F9B3 File Offset: 0x0118DBB3
		protected LevelEventAddBuffClientPrePerformance(int id) : base(id)
		{
		}

		// Token: 0x06043E76 RID: 278134
		[return: Nullable(2)]
		protected abstract EntityHandle GetTargetEntity(TriggerContext context);

		// Token: 0x06043E77 RID: 278135
		protected abstract List<long> GetBuffIds(ActionParams inParams);

		// Token: 0x06043E78 RID: 278136 RVA: 0x0118F9BC File Offset: 0x0118DBBC
		[return: Nullable(2)]
		protected EntityHandle GetTriggerEntity(TriggerContext context)
		{
			return ModelBase<CreatureModel>.Instance.GetEntityById(context.TriggerEntityId.Value);
		}

		// Token: 0x06043E79 RID: 278137 RVA: 0x0118F9D3 File Offset: 0x0118DBD3
		[return: Nullable(2)]
		protected EntityHandle GetOtherEntity(TriggerContext context)
		{
			return ModelBase<CreatureModel>.Instance.GetEntityById(context.OtherEntityId.Value);
		}

		// Token: 0x06043E7A RID: 278138 RVA: 0x0118F9EA File Offset: 0x0118DBEA
		protected string GetDebugName()
		{
			return base.GetType().Name;
		}

		// Token: 0x06043E7B RID: 278139 RVA: 0x0118F9F8 File Offset: 0x0118DBF8
		protected unsafe long GetPreMessageId(EntityHandle entityHandle)
		{
			ClientTriggerComponent component = entityHandle.Entity.GetComponent<ClientTriggerComponent>();
			if (component == null || !component.Valid)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "[" + this.GetDebugName() + "] 触发器所属实体获取ClientTriggerComponent失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("entityHandle", entityHandle);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("clientTriggerComponent", component);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return 0L;
			}
			return component.ClientPrePerformancePreMessageId;
		}

		// Token: 0x06043E7C RID: 278140 RVA: 0x0118FA90 File Offset: 0x0118DC90
		public unsafe override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (!(context.Type != EGeneralContextType.Trigger))
			{
				EntityHandle targetEntity = this.GetTargetEntity(context as TriggerContext);
				if (targetEntity == null || !targetEntity.Valid)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.LevelEvent;
					ELogAuthor author = ELogAuthor.XDW;
					string message = "[" + this.GetDebugName() + "] 加Buff的目标实体不存在或者无效";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("targetEntityHandle", targetEntity);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				EntityHandle triggerEntity = this.GetTriggerEntity(context as TriggerContext);
				if (triggerEntity == null || !triggerEntity.Valid)
				{
					global::Log instance2 = Singleton<global::Log>.Instance;
					ELogModule module2 = ELogModule.LevelEvent;
					ELogAuthor author2 = ELogAuthor.XDW;
					string message2 = "[" + this.GetDebugName() + "] 触发器组件所属实体不存在或者无效";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("triggerEntityHandle", triggerEntity);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					return;
				}
				long preMessageId = this.GetPreMessageId(triggerEntity);
				if (preMessageId == 0L)
				{
					global::Log instance3 = Singleton<global::Log>.Instance;
					ELogModule module3 = ELogModule.LevelEvent;
					ELogAuthor author3 = ELogAuthor.XDW;
					string message3 = "[" + this.GetDebugName() + "] 获取PreMessageId失败";
					ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("preMessageId", preMessageId);
					instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
					return;
				}
				BaseBuffComponent component = targetEntity.Entity.GetComponent<BaseBuffComponent>();
				if (component == null || !component.Valid)
				{
					global::Log instance4 = Singleton<global::Log>.Instance;
					ELogModule module4 = ELogModule.LevelEvent;
					ELogAuthor author4 = ELogAuthor.XDW;
					string message4 = "[" + this.GetDebugName() + "] 获取 BuffComponent失败";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffComponent", component);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("targetEntityHandle", targetEntity);
					instance4.Error(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return;
				}
				using (List<long>.Enumerator enumerator = this.GetBuffIds(inParams).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						long buffId = enumerator.Current;
						component.AddBuff(buffId, new AddBuffParam
						{
							InstigatorId = triggerEntity.CreatureDataId,
							Level = new int?(1),
							PreMessageId = new long?(preMessageId),
							Reason = "[" + this.GetDebugName() + "] ExecuteNew"
						});
					}
					return;
				}
			}
			global::Log instance5 = Singleton<global::Log>.Instance;
			ELogModule module5 = ELogModule.LevelEvent;
			ELogAuthor author5 = ELogAuthor.XDW;
			string message5 = "[" + this.GetDebugName() + "] 未支持的context.Type";
			ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("context", context);
			instance5.Error(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
		}
	}
}
