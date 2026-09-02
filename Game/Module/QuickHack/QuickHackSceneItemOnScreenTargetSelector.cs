using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.SceneItem;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052F4 RID: 21236
	[NullableContext(1)]
	[Nullable(0)]
	public class QuickHackSceneItemOnScreenTargetSelector : QuickHackBaseOnScreenTargetSelector
	{
		// Token: 0x06036378 RID: 222072 RVA: 0x00DA9F2C File Offset: 0x00DA812C
		protected override void OnInit()
		{
			this.EntityTypeQuery = EEntityTypeQuery.SceneItem;
			this.TargetHackType = EQuickHackTargetType.SceneItem;
		}

		// Token: 0x06036379 RID: 222073 RVA: 0x00DA9F40 File Offset: 0x00DA8140
		protected override bool CheckEntityValid(EntityHandle entityHandle)
		{
			if (!entityHandle.IsInit)
			{
				return false;
			}
			WorldEntity entity = entityHandle.Entity;
			return !entity.GetComponent<CreatureDataComponent>().GetRemoveState() && entity.Active && entity.GetComponent<SceneItemQuickHackComponent>() != null && entity.GetComponent<SceneItemActorComponent>() != null;
		}

		// Token: 0x0603637A RID: 222074 RVA: 0x00DA9F8C File Offset: 0x00DA818C
		protected override bool CheckEntityRendered(EntityHandle entityHandle)
		{
			SceneItemActorComponent component = entityHandle.Entity.GetComponent<SceneItemActorComponent>();
			component.TryRefreshShowActor();
			AActor curLevelPrefabShowActor = component.CurLevelPrefabShowActor;
			return curLevelPrefabShowActor != null && curLevelPrefabShowActor.IsValid() && curLevelPrefabShowActor.WasRecentlyRenderedOnScreen(0.2f);
		}

		// Token: 0x0603637B RID: 222075 RVA: 0x00DA9FC8 File Offset: 0x00DA81C8
		protected override FVectorDouble GetEntityLocation(EntityHandle entityHandle)
		{
			SceneItemActorComponent component = entityHandle.Entity.GetComponent<SceneItemActorComponent>();
			AActor referenceActor = component.GetReferenceActor("Center");
			if (referenceActor == null || !referenceActor.IsValid())
			{
				return component.ActorLocation;
			}
			return referenceActor.D_K2_GetActorLocation();
		}
	}
}
