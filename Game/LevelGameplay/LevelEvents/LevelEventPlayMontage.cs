using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BC7 RID: 27591
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventPlayMontage : LevelEventBase
	{
		// Token: 0x0604405C RID: 278620 RVA: 0x011A362B File Offset: 0x011A182B
		public LevelEventPlayMontage(int id) : base(id)
		{
		}

		// Token: 0x0604405D RID: 278621 RVA: 0x011A3634 File Offset: 0x011A1834
		protected override void ExecuteInGm(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			base.FinishExecute(true, false, true);
		}

		// Token: 0x0604405E RID: 278622 RVA: 0x011A3640 File Offset: 0x011A1840
		public unsafe override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YJX, "[LevelEventPlayMontage]关卡事件参数为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false, false, true);
				return;
			}
			PlayMontage playMontage = (PlayMontage)inParams;
			if (playMontage.ActionMontage.MontageType != EActionMontageType.Normal || StringUtils.IsEmpty(playMontage.ActionMontage.Path))
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.YJX;
				string message = "[LevelEventPlayMontage]蒙太奇类型错误或路径为空";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MontageType", playMontage.ActionMontage.MontageType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Path", playMontage.ActionMontage.Path);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				base.FinishExecute(false, false, true);
				return;
			}
			this.EntityId = playMontage.EntityId;
			this.EventParam = playMontage;
			if (this.EntityId == 0)
			{
				EntityContext entityContext = context as EntityContext;
				if (entityContext != null)
				{
					Entity entity = Singleton<EntitySystem>.Instance.Get(entityContext.EntityId.GetValueOrDefault());
					BaseActorComponent baseActorComponent = (entity != null) ? entity.GetComponent<BaseActorComponent>() : null;
					int? num = (baseActorComponent != null) ? new int?(baseActorComponent.CreatureData.GetPbDataId()) : null;
					if (num == null)
					{
						global::Log instance2 = Singleton<global::Log>.Instance;
						ELogModule module2 = ELogModule.LevelEvent;
						ELogAuthor author2 = ELogAuthor.YJX;
						string message2 = "[LevelEventPlayMontage] 无法从行为上下文中获取PbDataId";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", entityContext.EntityId);
						instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						base.FinishExecute(false, false, true);
						return;
					}
					this.EntityId = num.Value;
				}
			}
			if (this.EntityId == 0)
			{
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module3 = ELogModule.LevelEvent;
				ELogAuthor author3 = ELogAuthor.YJX;
				string message3 = "[LevelEventPlayMontage] 无法获取执行Montage的实体";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("PbDataId", this.EntityId);
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				base.FinishExecute(false, false, true);
				return;
			}
			this.EntityHandle = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(this.EntityId);
			EntityHandle entityHandle = this.EntityHandle;
			bool flag;
			if (entityHandle == null)
			{
				flag = true;
			}
			else
			{
				WorldEntity entity2 = entityHandle.Entity;
				flag = !((entity2 != null) ? new bool?(entity2.IsInit) : null).GetValueOrDefault();
			}
			if (flag)
			{
				WaitEntityTask.CreateWithPbDataId("LevelEventPlayMontage.ExecuteNew", this.EntityId, delegate(bool? result)
				{
					if (!result.GetValueOrDefault())
					{
						global::Log instance4 = Singleton<global::Log>.Instance;
						ELogModule module4 = ELogModule.Event;
						ELogAuthor author4 = ELogAuthor.YJX;
						string message4 = "[LevelEventPlayMontage] 等待实体加载超时";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("PbDataId", this.EntityId);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Timeout", 10000);
						instance4.Error(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
						base.FinishExecute(false, false, true);
						return;
					}
					this.ExecutePlayMontageTask();
				}, 10000, false, false);
				return;
			}
			this.ExecutePlayMontageTask();
		}

		// Token: 0x0604405F RID: 278623 RVA: 0x011A3890 File Offset: 0x011A1A90
		private unsafe void ExecutePlayMontageTask()
		{
			this.EntityHandle = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(this.EntityId);
			EntityHandle entityHandle = this.EntityHandle;
			if (entityHandle == null || !entityHandle.Valid)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.YJX;
				string message = "播放蒙太奇时找不到Entity";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PbDataId", this.EntityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.FinishExecute(false, false, true);
				return;
			}
			CharacterAiComponent component = this.EntityHandle.Entity.GetComponent<CharacterAiComponent>();
			if (component != null && component.IsAiDriver)
			{
				BaseActorComponent component2 = this.EntityHandle.Entity.GetComponent<BaseActorComponent>();
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.LevelEvent;
				ELogAuthor author2 = ELogAuthor.YZH;
				string message2 = "当前实体正在由行为树AI驱动，请检查需求设计是否合理（播放蒙太奇动画）";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PbDataId", this.EntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Name", component2.Owner);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				base.FinishExecute(true, false, true);
				return;
			}
			WorldEntity entity = this.EntityHandle.Entity;
			BasePerformComponent basePerformComponent = (entity != null) ? entity.GetComponent<BasePerformComponent>() : null;
			WorldEntity entity2 = this.EntityHandle.Entity;
			BaseAnimationComponent baseAnimationComponent = (entity2 != null) ? entity2.GetComponent<BaseAnimationComponent>() : null;
			if (basePerformComponent == null && baseAnimationComponent == null)
			{
				base.FinishExecute(true, false, true);
				return;
			}
			int? duration;
			bool flag;
			if (this.EventParam.Duration != null)
			{
				duration = this.EventParam.Duration;
				int num = 0;
				if (duration.GetValueOrDefault() >= num & duration != null)
				{
					duration = this.EventParam.Duration;
					num = 20;
					flag = (duration.GetValueOrDefault() < num & duration != null);
				}
				else
				{
					flag = false;
				}
			}
			else
			{
				flag = true;
			}
			bool flag2 = flag;
			if (this.IsAsync)
			{
				if (basePerformComponent != null)
				{
					BasePerformComponent basePerformComponent2 = basePerformComponent;
					EPerformMode mode = EPerformMode.Action;
					IPlayMontageParam playMontageParam = new IPlayMontageParam();
					playMontageParam.MontagePath = this.EventParam.ActionMontage.Path;
					playMontageParam.IsLoop = new bool?(!flag2);
					duration = this.EventParam.Duration;
					playMontageParam.Duration = ((duration != null) ? new float?((float)duration.GetValueOrDefault()) : null);
					basePerformComponent2.PlayPerformMontage(mode, playMontageParam, null, null, false);
				}
				else
				{
					MontageManager montageManager = baseAnimationComponent.MontageManager;
					IPlayMontageParam playMontageParam2 = new IPlayMontageParam();
					playMontageParam2.MontagePath = this.EventParam.ActionMontage.Path;
					playMontageParam2.IsLoop = new bool?(!flag2);
					duration = this.EventParam.Duration;
					playMontageParam2.Duration = ((duration != null) ? new float?((float)duration.GetValueOrDefault()) : null);
					montageManager.PlayMontage(playMontageParam2);
				}
				base.FinishExecute(true, false, true);
				return;
			}
			Singleton<EventSystem>.Instance.AddWithTarget<ERemoveEntityType, EntityHandle>(this.EntityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
			if (basePerformComponent != null)
			{
				BasePerformComponent basePerformComponent3 = basePerformComponent;
				EPerformMode mode2 = EPerformMode.Action;
				IPlayMontageParam playMontageParam3 = new IPlayMontageParam();
				playMontageParam3.MontagePath = this.EventParam.ActionMontage.Path;
				playMontageParam3.IsLoop = new bool?(!flag2);
				duration = this.EventParam.Duration;
				playMontageParam3.Duration = ((duration != null) ? new float?((float)duration.GetValueOrDefault()) : null);
				playMontageParam3.OnEndCallback = new Action<UAnimMontage, bool>(this.OnEnd);
				basePerformComponent3.PlayPerformMontage(mode2, playMontageParam3, null, null, false);
				return;
			}
			MontageManager montageManager2 = baseAnimationComponent.MontageManager;
			IPlayMontageParam playMontageParam4 = new IPlayMontageParam();
			playMontageParam4.MontagePath = this.EventParam.ActionMontage.Path;
			playMontageParam4.IsLoop = new bool?(!flag2);
			duration = this.EventParam.Duration;
			playMontageParam4.Duration = ((duration != null) ? new float?((float)duration.GetValueOrDefault()) : null);
			playMontageParam4.OnEndCallback = new Action<UAnimMontage, bool>(this.OnEnd);
			montageManager2.PlayMontage(playMontageParam4);
		}

		// Token: 0x06044060 RID: 278624 RVA: 0x011A3C58 File Offset: 0x011A1E58
		private void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle handle)
		{
			if (this.EntityHandle != handle)
			{
				return;
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LevelEvent;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "实体被移除,PlayMontage保底结束";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PbDataId", handle.PbDataId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (Singleton<EventSystem>.Instance.HasWithTarget<ERemoveEntityType, EntityHandle>(this.EntityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<ERemoveEntityType, EntityHandle>(this.EntityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
			}
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06044061 RID: 278625 RVA: 0x011A3CF0 File Offset: 0x011A1EF0
		[NullableContext(2)]
		private void OnEnd(UAnimMontage montage, bool bInterrupted)
		{
			if (Singleton<EventSystem>.Instance.HasWithTarget<ERemoveEntityType, EntityHandle>(this.EntityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<ERemoveEntityType, EntityHandle>(this.EntityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
			}
			base.FinishExecute(true, false, true);
		}

		// Token: 0x04026050 RID: 155728
		private int EntityId;

		// Token: 0x04026051 RID: 155729
		[Nullable(2)]
		private EntityHandle EntityHandle;

		// Token: 0x04026052 RID: 155730
		[Nullable(2)]
		private PlayMontage EventParam;
	}
}
