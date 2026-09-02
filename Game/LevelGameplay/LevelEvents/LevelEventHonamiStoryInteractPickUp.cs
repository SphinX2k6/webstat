using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.NewWorld.Pawn.Component;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BAC RID: 27564
	public class LevelEventHonamiStoryInteractPickUp : LevelEventBase
	{
		// Token: 0x06043FE0 RID: 278496 RVA: 0x0119E519 File Offset: 0x0119C719
		public LevelEventHonamiStoryInteractPickUp(int id) : base(id)
		{
		}

		// Token: 0x06043FE1 RID: 278497 RVA: 0x0119E524 File Offset: 0x0119C724
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			EntityContext entityContext = context as EntityContext;
			if (entityContext == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.BB, "[LevelEventHonamiStoryInteractPickUp] 上下文不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			Entity entity = Singleton<EntitySystem>.Instance.Get(entityContext.EntityId.Value);
			if (entity == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.BB, "[LevelEventHonamiStoryInteractPickUp] 实体不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			CreatureDataComponent creatureDataComponent = entity.CheckGetComponent<CreatureDataComponent>();
			if (creatureDataComponent.HonamiStoryItemInfo == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.BB, "[LevelEventHonamiStoryInteractPickUp] 非HonamiStoryItem", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (ModelBase<HonamiStoryModel>.Instance.GetBackPackData(2, false) == null)
			{
				return;
			}
			if (ModelBase<HonamiStoryModel>.Instance.IsPickUpViewOpened())
			{
				return;
			}
			PawnInteractNewComponent pawnInteractNewComponent = entity.CheckGetComponent<PawnInteractNewComponent>();
			if (pawnInteractNewComponent != null)
			{
				pawnInteractNewComponent.SetInteractionState(false, "HonamiStoryPickUp");
			}
			HonamiStoryItemDataBase itemDataBase = ModelBase<HonamiStoryModel>.Instance.CreateHonamiStoryItemData(creatureDataComponent.HonamiStoryItemInfo, null);
			ModelBase<HonamiStoryModel>.Instance.TryPickUp(itemDataBase, entity);
		}
	}
}
