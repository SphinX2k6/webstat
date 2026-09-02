using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.UI;
using CSharpScript.Game;
using UnrealEngine;

// Token: 0x02002358 RID: 9048
[NullableContext(1)]
[Nullable(0)]
public class PanelQteResultHandler
{
	// Token: 0x060114A3 RID: 70819 RVA: 0x004C1828 File Offset: 0x004BFA28
	public void Handle(PanelQteContext context)
	{
		TArray<SPanelQteAction> tarray = context.Success ? context.Config.SuccessActions : context.Config.FailActions;
		int num = tarray.Num();
		for (int i = 0; i < num; i++)
		{
			SPanelQteAction action = tarray.Get(i);
			this.HandleAction(action, context);
		}
	}

	// Token: 0x060114A4 RID: 70820 RVA: 0x004C187C File Offset: 0x004BFA7C
	private void HandleAction(SPanelQteAction action, PanelQteContext context)
	{
		Entity entity;
		if (action.Target == 0)
		{
			entity = context.GetSourceEntity();
		}
		else
		{
			entity = this.GetSelfEntity();
		}
		if (entity == null)
		{
			return;
		}
		BaseTagComponent baseTagComponent = null;
		CharacterBuffComponent characterBuffComponent = null;
		TArray<FGameplayTag> addTags = action.AddTags;
		int num = addTags.Num();
		for (int i = 0; i < num; i++)
		{
			FGameplayTag tag = addTags.Get(i);
			baseTagComponent = (baseTagComponent ?? entity.GetComponent<BaseTagComponent>());
			baseTagComponent.AddTag(new int?(tag.TagId()));
		}
		TArray<FGameplayTag> removeTags = action.RemoveTags;
		int num2 = removeTags.Num();
		for (int j = 0; j < num2; j++)
		{
			FGameplayTag tag2 = removeTags.Get(j);
			baseTagComponent = (baseTagComponent ?? entity.GetComponent<BaseTagComponent>());
			baseTagComponent.RemoveTag(new int?(tag2.TagId()));
		}
		TArray<long> addBuffs = action.AddBuffs;
		int num3 = addBuffs.Num();
		if (num3 > 0)
		{
			Entity sourceEntity = context.GetSourceEntity();
			CreatureDataComponent creatureDataComponent = (sourceEntity != null) ? sourceEntity.GetComponent<CreatureDataComponent>() : null;
			long? num4 = (creatureDataComponent != null) ? new long?(creatureDataComponent.GetCreatureDataId()) : null;
			long? preMessageId = context.PreMessageId;
			if (num4 != null && num4.Value != 0L)
			{
				if (context.BuffIndex >= 0)
				{
					long buffId = addBuffs.Get(context.BuffIndex);
					characterBuffComponent = (characterBuffComponent ?? entity.GetComponent<CharacterBuffComponent>());
					characterBuffComponent.AddBuff(buffId, new AddBuffParam
					{
						InstigatorId = num4.Value,
						Reason = "界面QTE结算时添加",
						PreMessageId = preMessageId
					});
				}
				else
				{
					for (int k = 0; k < num3; k++)
					{
						long buffId2 = addBuffs.Get(k);
						characterBuffComponent = (characterBuffComponent ?? entity.GetComponent<CharacterBuffComponent>());
						characterBuffComponent.AddBuff(buffId2, new AddBuffParam
						{
							InstigatorId = num4.Value,
							Reason = "界面QTE结算时添加",
							PreMessageId = preMessageId
						});
					}
				}
			}
		}
		TArray<TEnumAsByte<AkiClient.Game.Aki.Data.Fight.UI.EPanelQteCustomAction>> customActions = action.CustomActions;
		int num5 = customActions.Num();
		for (int l = 0; l < num5; l++)
		{
			TEnumAsByte<AkiClient.Game.Aki.Data.Fight.UI.EPanelQteCustomAction> value = customActions.Get(l);
			this.HandleCustomAction((int)value, context, entity);
		}
	}

	// Token: 0x060114A5 RID: 70821 RVA: 0x004C1A8C File Offset: 0x004BFC8C
	private void HandleCustomAction(int customAction, PanelQteContext context, Entity entity)
	{
		switch (customAction)
		{
		case 0:
		{
			CharacterBuffComponent component = entity.GetComponent<CharacterBuffComponent>();
			if (component != null)
			{
				component.RemoveBuffByEffectType(EExtraEffectId.Frozen, "界面QTE解除冰冻buff");
				return;
			}
			break;
		}
		case 1:
			this.TryChangeRole();
			return;
		case 2:
		{
			Entity selfEntity = this.GetSelfEntity();
			CharacterUnifiedStateComponent characterUnifiedStateComponent = (selfEntity != null) ? selfEntity.GetComponent<CharacterUnifiedStateComponent>() : null;
			if (characterUnifiedStateComponent != null && characterUnifiedStateComponent.PositionState == ECharPositionState.Climb)
			{
				CharacterAnimationComponent characterAnimationComponent = (selfEntity != null) ? selfEntity.GetComponent<CharacterAnimationComponent>() : null;
				if (characterAnimationComponent != null && characterAnimationComponent.Valid)
				{
					characterAnimationComponent.ClimbDash();
					return;
				}
			}
			else if (selfEntity != null)
			{
				CharacterSkillComponent component2 = selfEntity.GetComponent<CharacterSkillComponent>();
				if (component2 == null)
				{
					return;
				}
				component2.BeginSkill(100001, new SkillParam
				{
					Reason = "PanelQteResultHandler.HandleCustomAction.Rush"
				});
				return;
			}
			break;
		}
		case 3:
		{
			Entity selfEntity2 = this.GetSelfEntity();
			if (selfEntity2 == null)
			{
				return;
			}
			CharacterSkillComponent component3 = selfEntity2.GetComponent<CharacterSkillComponent>();
			if (component3 == null)
			{
				return;
			}
			component3.BeginSkill(100020, new SkillParam
			{
				Reason = "PanelQteResultHandler.HandleCustomAction.Hook"
			});
			return;
		}
		case 4:
		{
			Entity selfEntity3 = this.GetSelfEntity();
			if (selfEntity3 == null)
			{
				return;
			}
			CharacterMoveComponent component4 = selfEntity3.GetComponent<CharacterMoveComponent>();
			if (component4 == null)
			{
				return;
			}
			component4.TryJumpInFreeRunning();
			break;
		}
		default:
			return;
		}
	}

	// Token: 0x060114A6 RID: 70822 RVA: 0x004C1B94 File Offset: 0x004BFD94
	private void TryChangeRole()
	{
		SceneTeamItem getCurrentTeamItem = ModelBase<SceneTeamModel>.Instance.GetCurrentTeamItem;
		BaseTagComponent baseTagComponent;
		if (getCurrentTeamItem == null)
		{
			baseTagComponent = null;
		}
		else
		{
			EntityHandle entityHandle = getCurrentTeamItem.EntityHandle;
			if (entityHandle == null)
			{
				baseTagComponent = null;
			}
			else
			{
				WorldEntity entity = entityHandle.Entity;
				baseTagComponent = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
			}
		}
		BaseTagComponent baseTagComponent2 = baseTagComponent;
		if (baseTagComponent2 != null && baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.不能切人"]))
		{
			return;
		}
		List<SceneTeamItem> teamItems = ModelBase<SceneTeamModel>.Instance.GetTeamItems(false);
		int count = teamItems.Count;
		int num = teamItems.IndexOf(getCurrentTeamItem);
		for (int i = 1; i < count; i++)
		{
			int num2 = num + i;
			if (num2 >= count)
			{
				num2 -= count;
			}
			SceneTeamItem sceneTeamItem = teamItems[num2];
			if (sceneTeamItem != null && sceneTeamItem.CanGoBattle() == EGoBattleResultType.Success)
			{
				ControllerBase<CooperationController>.Instance.TryCooperate(sceneTeamItem.GetCreatureDataId());
				return;
			}
		}
	}

	// Token: 0x060114A7 RID: 70823 RVA: 0x004C1C54 File Offset: 0x004BFE54
	[NullableContext(2)]
	private Entity GetSelfEntity()
	{
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		if (baseCharacter == null || !baseCharacter.IsValid())
		{
			return null;
		}
		CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
		if (characterActorComponent == null)
		{
			return null;
		}
		return characterActorComponent.Entity;
	}

	// Token: 0x040087D9 RID: 34777
	private const int RUSH_SKILL_ID = 100001;

	// Token: 0x040087DA RID: 34778
	private const int HOOK_SKILL_ID = 100020;
}
