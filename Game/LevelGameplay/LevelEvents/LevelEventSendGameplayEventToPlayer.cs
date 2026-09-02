using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BDF RID: 27615
	public class LevelEventSendGameplayEventToPlayer : LevelEventBase
	{
		// Token: 0x060440B6 RID: 278710 RVA: 0x011A7128 File Offset: 0x011A5328
		public LevelEventSendGameplayEventToPlayer(int id) : base(id)
		{
		}

		// Token: 0x060440B7 RID: 278711 RVA: 0x011A7134 File Offset: 0x011A5334
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			ActionSendGameplayEvent actionSendGameplayEvent = inParams as ActionSendGameplayEvent;
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null)
			{
				return;
			}
			CharacterAbilityComponent component = baseCharacter.CharacterActorComponent.Entity.GetComponent<CharacterAbilityComponent>();
			if (component != null && actionSendGameplayEvent.Tag != null)
			{
				component.SendGameplayEventToActor(actionSendGameplayEvent.Tag.Value, null);
			}
			if (!actionSendGameplayEvent.Both)
			{
				return;
			}
			if (context.Type.GetValueOrDefault() != EGeneralContextType.Entity)
			{
				return;
			}
			EntityContext entityContext = context as EntityContext;
			Entity entity = Singleton<EntitySystem>.Instance.Get(entityContext.EntityId.Value);
			if (entity == null || !entity.Valid)
			{
				return;
			}
			CharacterAbilityComponent component2 = entity.GetComponent<CharacterAbilityComponent>();
			if (component2 == null || !component2.Valid)
			{
				return;
			}
			component2.SendGameplayEventToActor(actionSendGameplayEvent.Tag.Value, null);
		}
	}
}
