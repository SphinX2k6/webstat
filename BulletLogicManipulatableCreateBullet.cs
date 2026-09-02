using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Common.Component;
using CSharpScript.Game.NewWorld.SceneItem;
using UnrealEngine;

// Token: 0x02002DC6 RID: 11718
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class BulletLogicManipulatableCreateBullet : BulletLogicController<LogicDataManipulatableCreateBullet, object>
{
	// Token: 0x06017A03 RID: 96771 RVA: 0x00693C29 File Offset: 0x00691E29
	public BulletLogicManipulatableCreateBullet(LogicDataManipulatableCreateBullet bulletLogicBase, Entity bullet) : base(bulletLogicBase, bullet)
	{
		this.Parameter = bulletLogicBase;
	}

	// Token: 0x06017A04 RID: 96772 RVA: 0x00693C3C File Offset: 0x00691E3C
	[NullableContext(2)]
	public override void BulletLogicActionOnHitObstacles(object param = null)
	{
		BulletHitActorData bulletHitActorData = param as BulletHitActorData;
		if (bulletHitActorData != null)
		{
			Entity entity = bulletHitActorData.Entity;
			if (entity != null && entity.GetComponent<CreatureDataComponent>().IsSceneItem())
			{
				Entity entity2 = bulletHitActorData.Entity;
				if (((entity2 != null) ? entity2.GetComponent<SceneItemManipulatableComponent>() : null) == null || !this.CheckCondition(entity2))
				{
					return;
				}
				BulletInfo bulletInfo = this.Bullet.GetBulletInfo();
				Entity attacker = bulletInfo.Attacker;
				BaseActorComponent component = entity2.GetComponent<BaseActorComponent>();
				FTransformDouble value = ((component != null) ? new FTransformDouble?(component.ActorTransform) : null) ?? Singleton<MathUtils>.Instance.DefaultTransformDouble;
				int num = this.Parameter.CreateBulletRowName.Num();
				long? contextId = bulletInfo.ContextId;
				for (int i = 0; i < num; i++)
				{
					string text = this.Parameter.CreateBulletRowName.Get(i);
					HashSet<string> parentIds = BulletUtil.CollectParentsId(bulletInfo);
					BulletController instance = ControllerBase<BulletController>.Instance;
					Entity owner = attacker;
					string bulletRowName = text;
					FTransformDouble? initialTransform = new FTransformDouble?(value);
					BulletController.BulletCreateParams bulletCreateParams = new BulletController.BulletCreateParams();
					bulletCreateParams.SkillId = bulletInfo.BulletInitParams.SkillId;
					bulletCreateParams.SkillContextId = bulletInfo.BulletInitParams.SkillContextId;
					bulletCreateParams.ParentVictimId = ((entity2 != null) ? new int?(entity2.Id) : null);
					Entity target = bulletInfo.Target;
					bulletCreateParams.ParentTargetId = ((target != null) ? new int?(target.Id) : null);
					bulletCreateParams.ParentId = this.Bullet.Id;
					bulletCreateParams.BattleContext = bulletInfo.BulletInitParams.BattleContext;
					bulletCreateParams.ParentIds = parentIds;
					instance.CreateBulletCustomTarget(owner, bulletRowName, initialTransform, bulletCreateParams, contextId, EBulletCreateSource.Others);
				}
			}
		}
	}

	// Token: 0x06017A05 RID: 96773 RVA: 0x00693DE0 File Offset: 0x00691FE0
	public bool CheckCondition(Entity victim)
	{
		LogicDataManipulatableCreateBullet parameter = this.Parameter;
		LevelTagComponent levelTagComponent = (victim != null) ? victim.GetComponent<LevelTagComponent>() : null;
		if (levelTagComponent == null)
		{
			return false;
		}
		TArray<FGameplayTag> gameplayTags = parameter.ExistTagsCondition.GameplayTags;
		int num = gameplayTags.Num();
		for (int i = 0; i < num; i++)
		{
			int tagId = gameplayTags.Get(i).TagId();
			if (!levelTagComponent.HasTag(tagId))
			{
				return false;
			}
		}
		TArray<FGameplayTag> gameplayTags2 = parameter.UnExistTagsCondition.GameplayTags;
		int num2 = gameplayTags2.Num();
		for (int j = 0; j < num2; j++)
		{
			int tagId2 = gameplayTags2.Get(j).TagId();
			if (levelTagComponent.HasTag(tagId2))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400B603 RID: 46595
	private readonly LogicDataManipulatableCreateBullet Parameter;
}
