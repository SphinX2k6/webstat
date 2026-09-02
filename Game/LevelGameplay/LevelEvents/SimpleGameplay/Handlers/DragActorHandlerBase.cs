using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.SimpleGameplay.Handlers
{
	// Token: 0x02006C34 RID: 27700
	public class DragActorHandlerBase
	{
		// Token: 0x060441F1 RID: 279025 RVA: 0x011B0CA8 File Offset: 0x011AEEA8
		[NullableContext(1)]
		[return: Nullable(2)]
		protected Entity GetTargetEntity(int targetEntityId, GeneralContext context)
		{
			EntityContext entityContext = context as EntityContext;
			if (entityContext == null || entityContext.Type.GetValueOrDefault() != EGeneralContextType.Entity)
			{
				Singleton<Log>.Instance.Error(ELogModule.SceneGameplay, ELogAuthor.XDW, "DragActorHandlerBase.GetTargetEntity: context is not EntityContext", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			if (targetEntityId == -10000)
			{
				return Singleton<EntitySystem>.Instance.Get(entityContext.EntityId.Value);
			}
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(targetEntityId);
			if (entityByPbDataId == null)
			{
				return null;
			}
			return entityByPbDataId.Entity;
		}

		// Token: 0x040260A6 RID: 155814
		private const int SELF_ENTITY_PB_DATA_ID = -10000;
	}
}
