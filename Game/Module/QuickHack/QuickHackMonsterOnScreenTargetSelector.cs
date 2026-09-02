using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052F3 RID: 21235
	[NullableContext(1)]
	[Nullable(0)]
	public class QuickHackMonsterOnScreenTargetSelector : QuickHackBaseOnScreenTargetSelector
	{
		// Token: 0x06036373 RID: 222067 RVA: 0x00DA9E49 File Offset: 0x00DA8049
		protected override void OnInit()
		{
			this.EntityTypeQuery = (EEntityTypeQuery.PasserbyNPC | EEntityTypeQuery.Boss);
			this.TargetHackType = EQuickHackTargetType.EnemyMonster;
		}

		// Token: 0x06036374 RID: 222068 RVA: 0x00DA9E60 File Offset: 0x00DA8060
		protected override bool CheckEntityValid(EntityHandle entityHandle)
		{
			if (!entityHandle.IsInit)
			{
				return false;
			}
			WorldEntity entity = entityHandle.Entity;
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			if (component.GetRemoveState())
			{
				return false;
			}
			if (!entity.Active)
			{
				return false;
			}
			BaseTagComponent component2 = entity.GetComponent<BaseTagComponent>();
			if (component2 != null && component2.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.隐身"]))
			{
				return false;
			}
			if (CampUtils.GetCampRelationship(component.GetEntityCamp(), ECamp.Player) != ERelation.Enemy)
			{
				return false;
			}
			BaseDeathComponent component3 = entity.GetComponent<BaseDeathComponent>();
			return (component3 == null || !component3.IsDead()) && entity.GetComponent<BaseActorComponent>() != null;
		}

		// Token: 0x06036375 RID: 222069 RVA: 0x00DA9EF0 File Offset: 0x00DA80F0
		protected override bool CheckEntityRendered(EntityHandle entityHandle)
		{
			AActor owner = entityHandle.Entity.GetComponent<BaseActorComponent>().Owner;
			return owner != null && owner.WasRecentlyRenderedOnScreen(0.2f);
		}

		// Token: 0x06036376 RID: 222070 RVA: 0x00DA9F12 File Offset: 0x00DA8112
		protected override FVectorDouble GetEntityLocation(EntityHandle entityHandle)
		{
			return entityHandle.Entity.GetComponent<BaseActorComponent>().ActorLocation;
		}
	}
}
