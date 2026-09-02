using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BDD RID: 27613
	public class LevelEventSendAiEvent : LevelEventBase
	{
		// Token: 0x060440AE RID: 278702 RVA: 0x011A6BF1 File Offset: 0x011A4DF1
		public LevelEventSendAiEvent(int id) : base(id)
		{
		}

		// Token: 0x060440AF RID: 278703 RVA: 0x011A6BFC File Offset: 0x011A4DFC
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			SendAiEvent sendAiEvent = inParams as SendAiEvent;
			if (sendAiEvent == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Event, ELogAuthor.CJH, "参数不合法", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			EntityContext entityContext = context as EntityContext;
			if (entityContext == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Event, ELogAuthor.CJH, "上下文不合法", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			switch (sendAiEvent.EventType)
			{
			case EAiEventType.CatAndDogPlayFlow:
			case EAiEventType.AnimalRandomAction:
				this.OnPetRandomAction(entityContext.EntityId.Value);
				return;
			case EAiEventType.AnimalStandUp:
				this.OnPetStandUp(entityContext.EntityId.Value);
				return;
			case EAiEventType.AnimalSitDown:
				this.OnPetSitDown(entityContext.EntityId.Value);
				return;
			default:
				return;
			}
		}

		// Token: 0x060440B0 RID: 278704 RVA: 0x011A6CAC File Offset: 0x011A4EAC
		private void OnPetStandUp(int entityId)
		{
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(entityId);
			if (entityById == null || !entityById.Valid)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Event, ELogAuthor.CJH, "对象Entity不合法", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (entityById.Entity.GetComponent<CharacterAiComponent>() == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Event, ELogAuthor.CJH, "Entity不合法，缺少CharacterAiComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			BaseTagComponent component = entityById.Entity.GetComponent<BaseTagComponent>();
			bool flag = component != null && component.HasTag(GameplayTagDefine.EGameplayTagId["动物.Common.状态标识.交互.坐下"]);
			bool flag2 = component != null && component.HasTag(GameplayTagDefine.EGameplayTagId["动物.Common.状态标识.交互.趴下"]);
			this.RemoveAiEventTag(component);
			if (flag)
			{
				if (component != null)
				{
					component.AddTag(new int?(GameplayTagDefine.EGameplayTagId["动物.Common.状态标识.交互.站起"]));
				}
			}
			else if (flag2)
			{
				if (component != null)
				{
					component.AddTag(new int?(GameplayTagDefine.EGameplayTagId["动物.Common.状态标识.交互.趴下起身"]));
				}
			}
			else if (component != null)
			{
				component.AddTag(new int?(GameplayTagDefine.EGameplayTagId["动物.Common.状态标识.交互.站起"]));
			}
			if (component != null)
			{
				component.AddTag(new int?(GameplayTagDefine.EGameplayTagId["动物.Common.通知标识.交互"]));
			}
		}

		// Token: 0x060440B1 RID: 278705 RVA: 0x011A6DE4 File Offset: 0x011A4FE4
		private void OnPetSitDown(int entityId)
		{
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(entityId);
			if (entityById == null || !entityById.Valid)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Event, ELogAuthor.CJH, "对象Entity不合法", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (entityById.Entity.GetComponent<CharacterAiComponent>() == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Event, ELogAuthor.CJH, "Entity不合法，缺少CharacterAiComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			BaseTagComponent component = entityById.Entity.GetComponent<BaseTagComponent>();
			this.RemoveAiEventTag(component);
			if (new Random().NextDouble() < 0.5)
			{
				if (component != null)
				{
					component.AddTag(new int?(GameplayTagDefine.EGameplayTagId["动物.Common.状态标识.交互.坐下"]));
				}
			}
			else if (component != null)
			{
				component.AddTag(new int?(GameplayTagDefine.EGameplayTagId["动物.Common.状态标识.交互.趴下"]));
			}
			if (component != null)
			{
				component.AddTag(new int?(GameplayTagDefine.EGameplayTagId["动物.Common.通知标识.交互"]));
			}
		}

		// Token: 0x060440B2 RID: 278706 RVA: 0x011A6ED8 File Offset: 0x011A50D8
		private void OnPetRandomAction(int entityId)
		{
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(entityId);
			if (entityById == null || !entityById.Valid)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Event, ELogAuthor.CJH, "对象Entity不合法", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (entityById.Entity.GetComponent<CharacterAiComponent>() == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Event, ELogAuthor.CJH, "Entity不合法，缺少CharacterAiComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			BaseTagComponent component = entityById.Entity.GetComponent<BaseTagComponent>();
			this.RemoveAiEventTag(component);
			if (component != null)
			{
				component.AddTag(new int?(GameplayTagDefine.EGameplayTagId["动物.Common.状态标识.交互.随机表演"]));
			}
			if (component != null)
			{
				component.AddTag(new int?(GameplayTagDefine.EGameplayTagId["动物.Common.通知标识.交互"]));
			}
		}

		// Token: 0x060440B3 RID: 278707 RVA: 0x011A6F98 File Offset: 0x011A5198
		[NullableContext(2)]
		private void RemoveAiEventTag(BaseTagComponent gameplayTagComponent)
		{
			if (gameplayTagComponent == null || !gameplayTagComponent.Valid)
			{
				return;
			}
			gameplayTagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["动物.Common.状态标识.交互.随机表演"]));
			gameplayTagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["动物.Common.状态标识.交互.坐下"]));
			gameplayTagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["动物.Common.状态标识.交互.趴下"]));
			gameplayTagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["动物.Common.状态标识.交互.站起"]));
			gameplayTagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["动物.Common.状态标识.交互.趴下起身"]));
		}
	}
}
