using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;

// Token: 0x02002D81 RID: 11649
[NullableContext(1)]
[Nullable(0)]
public class BulletActionDestroyBullet : BulletActionBase
{
	// Token: 0x060177FC RID: 96252 RVA: 0x006837E8 File Offset: 0x006819E8
	public BulletActionDestroyBullet(EBulletAction type) : base(type)
	{
	}

	// Token: 0x060177FD RID: 96253 RVA: 0x006837F4 File Offset: 0x006819F4
	protected override void OnExecute()
	{
		BulletActionInfoDestroyBullet bulletActionInfoDestroyBullet = (BulletActionInfoDestroyBullet)this.ActionInfo;
		if (bulletActionInfoDestroyBullet.SummonChild)
		{
			BulletChildInfo childInfo = this.BulletInfo.ChildInfo;
			if (childInfo != null)
			{
				childInfo.SetIsActiveSummonChildBullet(true);
			}
		}
		if (bulletActionInfoDestroyBullet.DestroyReason.GetValueOrDefault() == EBulletDestroyReason.ParentDestroy)
		{
			this.OnParentDestroy();
		}
		EntityHandle attackerHandle = this.BulletInfo.AttackerHandle;
		if (attackerHandle != null && attackerHandle.Valid)
		{
			BaseActorComponent attackerActorComp = this.BulletInfo.AttackerActorComp;
			if (((attackerActorComp != null) ? attackerActorComp.Owner : null) != null)
			{
				this.SummonChildBulletOnDestroy();
				this.SendBulletDataEndEvent();
			}
		}
		this.BulletEffectOnDestroy();
		this.DestroySummon();
		if (this.BulletInfo.NeedNotifyChildrenWhenDestroy && this.BulletInfo.ChildEntityIds != null)
		{
			foreach (int id in this.BulletInfo.ChildEntityIds)
			{
				ControllerBase<BulletController>.Instance.DestroyBullet(id, false, EBulletDestroyReason.ParentDestroy, false);
			}
		}
		BulletCollisionInfo collisionInfo = this.BulletInfo.CollisionInfo;
		foreach (KeyValuePair<int, int> keyValuePair in collisionInfo.HitTimeScaleEntityMap)
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			EntityHandle handle = ModelBase<CharacterModel>.Instance.GetHandle(key);
			if (handle != null && handle.Valid)
			{
				PawnTimeScaleComponent component = handle.Entity.GetComponent<PawnTimeScaleComponent>();
				if (component != null)
				{
					component.RemoveTimeScale(value);
				}
			}
		}
		collisionInfo.HitTimeScaleEntityMap.Clear();
		foreach (BulletHitActorData bulletHitActorData in collisionInfo.LastArrayHitActorData)
		{
			if (bulletHitActorData.IsValidHit)
			{
				BulletCollisionUtil.EntityLeave(this.BulletInfo, bulletHitActorData);
			}
		}
	}

	// Token: 0x060177FE RID: 96254 RVA: 0x006839E0 File Offset: 0x00681BE0
	private void OnParentDestroy()
	{
		if (BulletHitCountUtil.CheckHitCountTotal(this.BulletInfo))
		{
			BulletStaticFunction.SpawnHitEffect(this.BulletInfo, EBulletHitEffect.次数不足时触发, "[BulletActionDestroyBullet.OnParentDestroy]");
			BulletChildInfo childInfo = this.BulletInfo.ChildInfo;
			if (childInfo == null)
			{
				return;
			}
			childInfo.SetIsNumberNotEnough(true);
		}
	}

	// Token: 0x060177FF RID: 96255 RVA: 0x00683A18 File Offset: 0x00681C18
	private void SendBulletDataEndEvent()
	{
		BaseActorComponent attackerActorComp = this.BulletInfo.AttackerActorComp;
		bool flag;
		if (attackerActorComp == null)
		{
			flag = false;
		}
		else
		{
			AActor owner = attackerActorComp.Owner;
			flag = ((owner != null) ? new bool?(owner.IsValid()) : null).GetValueOrDefault();
		}
		if (flag)
		{
			FGameplayTag sendGameplayEventTagToAttackerOnEnd = this.BulletInfo.BulletDataMain.Execution.SendGameplayEventTagToAttackerOnEnd;
			Singleton<EventSystem>.Instance.EmitWithTarget<BulletInfo>(this.BulletInfo.Attacker, EEventName.BulletDestroy, this.BulletInfo);
			if (!sendGameplayEventTagToAttackerOnEnd.TagName.IsNone())
			{
				FGameplayEventData fgameplayEventData = new FGameplayEventData();
				fgameplayEventData.OptionalObject = this.BulletInfo.Actor;
				UAbilitySystemBlueprintLibrary.SendGameplayEventToActor(this.BulletInfo.AttackerActorComp.Owner, sendGameplayEventTagToAttackerOnEnd, fgameplayEventData);
			}
		}
	}

	// Token: 0x06017800 RID: 96256 RVA: 0x00683AD4 File Offset: 0x00681CD4
	private void DestroySummon()
	{
		BulletDataMain bulletDataMain = this.BulletInfo.BulletDataMain;
		if (this.BulletInfo.SummonServerEntityId == 0L || bulletDataMain.Summon.EntityId <= 0 || !bulletDataMain.Summon.DestroyEntityOnBulletEnd)
		{
			return;
		}
		ControllerBase<CreatureController>.Instance.RemoveSummonEntityByServerIdRequest(this.BulletInfo.BulletInitParams.SkillId, this.BulletInfo.SummonAttackerId, this.BulletInfo.SummonServerEntityId);
	}

	// Token: 0x06017801 RID: 96257 RVA: 0x00683B48 File Offset: 0x00681D48
	private void SummonChildBulletOnDestroy()
	{
		BulletChildInfo childInfo = this.BulletInfo.ChildInfo;
		BulletDataChild[] children = this.BulletInfo.BulletDataMain.Children;
		int num = children.Length;
		for (int i = 0; i < num; i++)
		{
			BulletDataChild bulletDataChild = children[i];
			long num2;
			if (((bulletDataChild.Condition == global::EBulletChildrenType.OnTimeEnd && this.BulletInfo.IsTimeNotEnough) || (bulletDataChild.Condition == global::EBulletChildrenType.OnCountEnd && childInfo.IsNumberNotEnough) || (bulletDataChild.Condition == global::EBulletChildrenType.Normal && childInfo.IsActiveSummonChildBullet)) && long.TryParse(bulletDataChild.RowName.ToString(), out num2) && num2 != 0L && bulletDataChild.Num >= 1)
			{
				HashSet<string> parentIds = BulletUtil.CollectParentsId(this.BulletInfo);
				BulletController instance = ControllerBase<BulletController>.Instance;
				Entity attacker = this.BulletInfo.Attacker;
				string bulletRowName = bulletDataChild.RowName.ToString();
				FTransformDouble? initialTransform = new FTransformDouble?(this.BulletInfo.ActorComponent.ActorTransform);
				BulletController.BulletCreateParams bulletCreateParams = new BulletController.BulletCreateParams();
				bulletCreateParams.SkillId = this.BulletInfo.BulletInitParams.SkillId;
				bulletCreateParams.SkillContextId = this.BulletInfo.BulletInitParams.SkillContextId;
				Entity target = this.BulletInfo.Target;
				bulletCreateParams.ParentTargetId = ((target != null) ? new int?(target.Id) : null);
				bulletCreateParams.ParentId = this.BulletInfo.Entity.Id;
				bulletCreateParams.BattleContext = this.BulletInfo.BulletInitParams.BattleContext;
				bulletCreateParams.ParentIds = parentIds;
				BulletEntity bulletEntity = instance.CreateBulletCustomTarget(attacker, bulletRowName, initialTransform, bulletCreateParams, this.BulletInfo.ContextId, EBulletCreateSource.Others);
				if (bulletEntity != null)
				{
					BulletUtil.ProcessHandOverEffectToSon(this.BulletInfo, bulletEntity);
				}
			}
		}
	}

	// Token: 0x06017802 RID: 96258 RVA: 0x00683CF4 File Offset: 0x00681EF4
	private void BulletEffectOnDestroy()
	{
		if (this.BulletInfo.IsDestroyByCharSkillEnd)
		{
			BulletStaticFunction.SpawnHitEffect(this.BulletInfo, EBulletHitEffect.子弹打断销毁触发, "[BulletActionDestroyBullet.BulletEffectOnDestroy] 1");
		}
		if (this.BulletInfo.IsTimeNotEnough)
		{
			BulletStaticFunction.SpawnHitEffect(this.BulletInfo, EBulletHitEffect.时间销毁触发, "[BulletActionDestroyBullet.BulletEffectOnDestroy] 2");
		}
		this.BulletInfo.ActionLogicComponent.ActionDestroy();
		if ((this.ActionInfo as BulletActionInfoDestroyBullet).DestroyEffectImmediately)
		{
			this.BulletInfo.EffectInfo.IsFinishAuto = false;
		}
		BulletStaticFunction.DestroyEffect(this.BulletInfo, true);
	}

	// Token: 0x0400B42A RID: 46122
	[StaticVariableRuleIgnore]
	private static readonly Stat ChildOnDestroyStat = Stat.Create("BulletDataComp.ChildOnDestroy", "", "");

	// Token: 0x0400B42B RID: 46123
	[StaticVariableRuleIgnore]
	private static readonly Stat EffectOnDestroyStat = Stat.Create("BulletDataComp.EffectOnDestroy", "", "");

	// Token: 0x0400B42C RID: 46124
	[StaticVariableRuleIgnore]
	private static readonly Stat SpawnHitEffectStat = Stat.Create("SpawnHitEffect", "", "");

	// Token: 0x0400B42D RID: 46125
	[StaticVariableRuleIgnore]
	private static readonly Stat ActionDestroyStat = Stat.Create("ActionDestroy", "", "");

	// Token: 0x0400B42E RID: 46126
	[StaticVariableRuleIgnore]
	private static readonly Stat ActionBreakEffect = Stat.Create("ActionBreakEffect", "", "");
}
