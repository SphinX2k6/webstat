using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Data.Qte;
using UnrealEngine;

// Token: 0x02002609 RID: 9737
[NullableContext(2)]
[Nullable(0)]
public class BattleQteContext
{
	// Token: 0x06013172 RID: 78194 RVA: 0x0054B011 File Offset: 0x00549211
	public void QteSuccess()
	{
		this.HandleAction(true);
	}

	// Token: 0x06013173 RID: 78195 RVA: 0x0054B01A File Offset: 0x0054921A
	public void QteFail()
	{
		this.HandleAction(false);
	}

	// Token: 0x06013174 RID: 78196 RVA: 0x0054B024 File Offset: 0x00549224
	private void HandleAction(bool isSuccess)
	{
		SBattleQte battleQteConfig = ModelBase<BattleQteModel>.Instance.GetBattleQteConfig(this.BattleQteId);
		if (battleQteConfig == null)
		{
			return;
		}
		EntityHandle entityHandle = this.EntityHandle;
		WorldEntity inEntity = (entityHandle != null) ? entityHandle.Entity : null;
		TArray<SBattleQteAction> actions = isSuccess ? battleQteConfig.SuccessActions : battleQteConfig.FailActions;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 2);
		defaultInterpolatedStringHandler.AppendLiteral("HandleId:");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.BattleQteHandleId);
		defaultInterpolatedStringHandler.AppendLiteral(" BattleQteId:");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.BattleQteId);
		string tips = defaultInterpolatedStringHandler.ToStringAndClear();
		BattleQteContext.HandleActionTest(actions, inEntity, this.MessageId, tips);
	}

	// Token: 0x06013175 RID: 78197 RVA: 0x0054B0C4 File Offset: 0x005492C4
	public static void HandleActionTest([Nullable(1)] TArray<SBattleQteAction> actions, Entity inEntity = null, long? messageId = null, string tips = null)
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		WorldEntity worldEntity = (getCurrentEntity != null) ? getCurrentEntity.Entity : null;
		for (int i = 0; i < actions.Num(); i++)
		{
			SBattleQteAction sbattleQteAction = actions.Get(i);
			Entity entity;
			if (sbattleQteAction.Target == 0)
			{
				entity = inEntity;
			}
			else if (sbattleQteAction.Target == 1)
			{
				entity = worldEntity;
			}
			else
			{
				entity = null;
			}
			if (entity != null)
			{
				BattleQteContext.HandleActionInternal(entity, sbattleQteAction, messageId, tips);
			}
		}
	}

	// Token: 0x06013176 RID: 78198 RVA: 0x0054B130 File Offset: 0x00549330
	[NullableContext(1)]
	private static void HandleActionInternal(Entity entity, SBattleQteAction action, long? messageId = null, [Nullable(2)] string tips = null)
	{
		if (messageId == null || messageId.Value == 0L)
		{
			return;
		}
		BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
		bool flag = true;
		if (component != null)
		{
			TArray<FGameplayTag> tagConditions = action.TagConditions;
			int num = tagConditions.Num();
			for (int i = 0; i < num; i++)
			{
				FGameplayTag tag = tagConditions.Get(i);
				if (!component.HasTag(tag.TagId()))
				{
					flag = false;
					break;
				}
			}
		}
		if (component == null || !flag)
		{
			return;
		}
		TArray<FGameplayTag> addTags = action.AddTags;
		int num2 = addTags.Num();
		for (int j = 0; j < num2; j++)
		{
			component.AddTag(new int?(addTags.Get(j).TagId()));
		}
		TArray<FGameplayTag> removeTags = action.RemoveTags;
		int num3 = removeTags.Num();
		for (int k = 0; k < num3; k++)
		{
			component.RemoveTag(new int?(removeTags.Get(k).TagId()));
		}
		CharacterBuffComponent characterBuffComponent = null;
		TArray<long> addBuffs = action.AddBuffs;
		int num4 = addBuffs.Num();
		if (num4 > 0)
		{
			if (characterBuffComponent == null)
			{
				characterBuffComponent = entity.GetComponent<CharacterBuffComponent>();
			}
			if (characterBuffComponent != null)
			{
				for (int l = 0; l < num4; l++)
				{
					long buffId = addBuffs.Get(l);
					characterBuffComponent.AddBuff(buffId, new AddBuffParam
					{
						InstigatorId = characterBuffComponent.CreatureDataId,
						Reason = "战斗Qte结束时添加buff",
						PreMessageId = new long?(messageId.Value)
					});
				}
			}
		}
		TArray<long> removeBuffs = action.RemoveBuffs;
		int num5 = removeBuffs.Num();
		if (num5 > 0)
		{
			if (characterBuffComponent == null)
			{
				characterBuffComponent = entity.GetComponent<CharacterBuffComponent>();
			}
			if (characterBuffComponent != null)
			{
				for (int m = 0; m < num5; m++)
				{
					long buffId2 = removeBuffs.Get(m);
					characterBuffComponent.RemoveBuff(buffId2, -1, "战斗Qte结束时移除buff", new long?(messageId.Value), null, null);
				}
			}
		}
		TArray<long> addBullets = action.AddBullets;
		int num6 = addBullets.Num();
		for (int n = 0; n < num6; n++)
		{
			long num7 = addBullets.Get(n);
			ControllerBase<BulletController>.Instance.CreateBulletCustomTarget(entity, num7.ToString(), null, new BulletController.BulletCreateParams(), new long?(messageId.Value), EBulletCreateSource.Others);
		}
		int useSkillId = action.UseSkillId;
		if (useSkillId != 0)
		{
			CharacterSkillComponent component2 = entity.GetComponent<CharacterSkillComponent>();
			if (component2 != null)
			{
				if (action.ChangeMainSkillPriority != -1)
				{
					Skill currentSkill = component2.CurrentSkill;
					if (currentSkill != null)
					{
						SSkillInfo skillInfo = currentSkill.SkillInfo;
						if (((skillInfo != null) ? new TEnumAsByte<ESkillGenre>?(skillInfo.SkillGenre) : null) != ESkillGenre.大招3)
						{
							component2.SetSkillPriority(currentSkill.SkillId, action.ChangeMainSkillPriority);
						}
					}
				}
				component2.BeginSkill(useSkillId, new SkillParam
				{
					Reason = "BattleQteContext.HandleActionInternal"
				});
			}
		}
		EBattleQteCustomAction ebattleQteCustomAction = action.CustomAction;
		if (ebattleQteCustomAction > EBattleQteCustomAction.无)
		{
			if (ebattleQteCustomAction == EBattleQteCustomAction.切换角色)
			{
				BattleQteCustomAction.battleQteChangeRole(null);
				return;
			}
			if (ebattleQteCustomAction != EBattleQteCustomAction.切换到指定角色)
			{
				return;
			}
			int num8;
			if (int.TryParse(action.CustomActionParam, out num8) && num8 != 0)
			{
				BattleQteCustomAction.battleQteChangeRole(new int?(num8));
			}
		}
	}

	// Token: 0x040094F6 RID: 38134
	private const int TARGET_QTE_SOURCER = 0;

	// Token: 0x040094F7 RID: 38135
	private const int TARGET_PLAYER_SELF = 1;

	// Token: 0x040094F8 RID: 38136
	public int BattleQteHandleId = -1;

	// Token: 0x040094F9 RID: 38137
	public int BattleQteId;

	// Token: 0x040094FA RID: 38138
	public int CommonQteHandleId = -1;

	// Token: 0x040094FB RID: 38139
	public int CommonQteId;

	// Token: 0x040094FC RID: 38140
	public EBattleQteSource? BattleQteSource;

	// Token: 0x040094FD RID: 38141
	public long? MessageId;

	// Token: 0x040094FE RID: 38142
	public EntityHandle EntityHandle;
}
