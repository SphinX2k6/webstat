using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Module.CombatMessage;
using UnrealEngine;

// Token: 0x02003013 RID: 12307
[NullableContext(1)]
[Nullable(0)]
public class BaseHitComponent : EntityComponent
{
	// Token: 0x0601915C RID: 102748 RVA: 0x00720FA0 File Offset: 0x0071F1A0
	protected void HitRequest(BulletEntity bulletEntity, long attackerCreatureDataId, global::HitInformation hitData, int beHitAnim = 0, bool enterFk = false, bool isHitWeakness = false, ECounterAttackType counterAttackType = ECounterAttackType.None, FRotator? victimRotation = null, bool isChangeVictimRotation = false, int? fightState = null, [Nullable(new byte[]
	{
		2,
		1
	})] Action<HitResponse> callback = null)
	{
		Aki.Protocol.HitInformation hitInformation = Aki.Protocol.HitInformation.Create();
		long creatureDataId = base.Entity.GetComponent<CreatureDataComponent>().GetCreatureDataId();
		hitInformation.Id = attackerCreatureDataId;
		hitInformation.TargetId = Singleton<MathUtils>.Instance.NumberToLong(creatureDataId);
		hitInformation.BulletId = Singleton<MathUtils>.Instance.NumberToLong(hitData.BulletId);
		global::Vector hitPosition = hitData.HitPosition;
		hitInformation.HitEffectPos = Aki.Protocol.Vector.Create();
		hitInformation.HitEffectPos.X = (float)hitPosition.X;
		hitInformation.HitEffectPos.Y = (float)hitPosition.Y;
		hitInformation.HitEffectPos.Z = (float)hitPosition.Z;
		hitInformation.HitEffectRotate = Aki.Protocol.Rotator.Create();
		hitInformation.HitEffectRotate.Pitch = hitData.HitEffectRotation.Pitch;
		hitInformation.HitEffectRotate.Yaw = hitData.HitEffectRotation.Yaw;
		hitInformation.HitEffectRotate.Roll = hitData.HitEffectRotation.Roll;
		hitInformation.HitPos = Aki.Protocol.Vector.Create();
		hitInformation.HitPos.X = (float)hitPosition.X;
		hitInformation.HitPos.Y = (float)hitPosition.Y;
		hitInformation.HitPos.Z = (float)hitPosition.Z;
		hitInformation.BeHitAnim = beHitAnim;
		hitInformation.EnterFk = enterFk;
		hitInformation.IsHitWeakness = isHitWeakness;
		hitInformation.IsTriggerCounterattack = (counterAttackType == ECounterAttackType.Normal);
		hitInformation.IsTriggerVisionCounterAttack = (counterAttackType == ECounterAttackType.Vision);
		hitInformation.VictimRotation = Aki.Protocol.Rotator.Create();
		hitInformation.VictimRotation.Pitch = ((victimRotation != null) ? victimRotation.GetValueOrDefault().Pitch : 0f);
		hitInformation.VictimRotation.Roll = ((victimRotation != null) ? victimRotation.GetValueOrDefault().Roll : 0f);
		hitInformation.VictimRotation.Yaw = ((victimRotation != null) ? victimRotation.GetValueOrDefault().Yaw : 0f);
		bool hasBeHitData = hitData.HitEffect != null;
		hitInformation.HasBeHitData = hasBeHitData;
		hitInformation.HitPart = (((hitData.HitPart != null) ? hitData.HitPart.GetValueOrDefault().ToString() : null) ?? "");
		hitInformation.IsChangeVictimRotation = isChangeVictimRotation;
		BulletInfo bulletInfo = bulletEntity.GetBulletInfo();
		hitInformation.SkillId = (long)bulletInfo.BulletInitParams.SkillId;
		hitInformation.Source = bulletInfo.BulletInitParams.Source;
		Aki.Protocol.HitInformation hitInformation2 = hitInformation;
		ISkillBattleContext battleContext = bulletInfo.BulletInitParams.BattleContext;
		hitInformation2.PhantomSkillIdentify = ((battleContext != null) ? battleContext.VisionId : 0);
		if (fightState != null)
		{
			hitInformation.FightState = fightState.Value;
		}
		HitRequest hitRequest = Aki.Protocol.HitRequest.Create();
		hitRequest.HitInfo = hitInformation;
		if (bulletInfo.BulletInitParams.SkillContextId != null)
		{
			hitRequest.SkillMessageId = bulletInfo.BulletInitParams.SkillContextId.Value;
		}
		this.CompressData(hitRequest);
		Singleton<CombatNet>.Instance.Call<HitResponse>(ERequestMessageId.HitRequest, base.Entity, hitRequest, delegate(HitResponse response)
		{
			Action<HitResponse> callback2 = callback;
			if (callback2 == null)
			{
				return;
			}
			callback2(response);
		}, (bulletEntity != null) ? bulletEntity.GetBulletInfo().ContextId : null, null, null, null);
	}

	// Token: 0x0601915D RID: 102749 RVA: 0x007212D8 File Offset: 0x0071F4D8
	private void CompressData(HitRequest data)
	{
		if (!ModelBase<GameModeModel>.Instance.IsMulti)
		{
			data.HitInfo.Originator = 0L;
			data.HitInfo.TargetId = 0L;
			data.HitInfo.HasBeHitData = false;
			data.HitInfo.HitEffectPos = null;
			data.HitInfo.HitEffectRotate = null;
			data.HitInfo.IsShake = false;
			data.HitInfo.EnterFk = false;
			data.HitInfo.IsHitWeakness = false;
			data.HitInfo.VictimRotation = null;
			data.HitInfo.IsChangeVictimRotation = false;
			data.HitInfo.HitPart = "";
			data.HitInfo.BeHitAnim = 0;
		}
	}

	// Token: 0x0601915E RID: 102750 RVA: 0x0072138C File Offset: 0x0071F58C
	public static void HitEndRequest(Entity entity)
	{
		HitEndPush message = HitEndPush.Create();
		Singleton<CombatNet>.Instance.Send(EPushMessageId.HitEndPush, entity, message, null, null, null);
	}

	// Token: 0x0601915F RID: 102751 RVA: 0x007213CC File Offset: 0x0071F5CC
	[NullableContext(2)]
	[CombatPreprocess(ENotifyMessageId.HitNotify)]
	public static bool PreHitNotify(Entity entity, [Nullable(1)] HitNotify notify, CombatCommon combatCommon = null)
	{
		Aki.Protocol.HitInformation hitInfo = notify.HitInfo;
		if (hitInfo != null && hitInfo.HasBeHitData && !notify.HitInfo.EnterFk)
		{
			CharacterFightStateComponent component = entity.GetComponent<CharacterFightStateComponent>();
			if (component != null && !component.PreSwitchRemoteFightState(notify.HitInfo.FightState))
			{
				notify.HitInfo.EnterFk = true;
				notify.HitInfo.FightState = 0;
			}
		}
		return true;
	}

	// Token: 0x06019160 RID: 102752 RVA: 0x00721430 File Offset: 0x0071F630
	[NullableContext(2)]
	[CombatListen(ENotifyMessageId.HitNotify, true, false)]
	public static void HitNotify(Entity entity, [Nullable(1)] HitNotify notify, CombatCommon combatCommon = null)
	{
		long id = notify.HitInfo.Id;
		EntityHandle entity2 = ModelBase<CreatureModel>.Instance.GetEntity(id);
		if (entity2 == null || !entity2.Valid)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.WCL;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(62, 1);
			defaultInterpolatedStringHandler.AppendLiteral("[ControllerHolder.CreatureController.HitNotify] 攻击者为空，不存在动态实体:");
			defaultInterpolatedStringHandler.AppendFormatted<long>(id);
			instance.Warn(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		WorldEntity entity3 = entity2.Entity;
		string text = notify.HitInfo.BulletId.ToString();
		BulletDataMain bulletData = ConfigBase<BulletConfig>.Instance.GetBulletData(entity3, text, true);
		if (bulletData == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.World, ELogAuthor.WCL, "[ControllerHolder.CreatureController.HitNotify] 子弹数据不存在;" + text + "。", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		global::HitInformation hitInformation = new global::HitInformation(entity3, entity, null, 0L, null, notify.HitInfo.IsShake, null, null, 0, bulletData, text, bulletData.Base.DamageId, null, 0, 0, false);
		if (notify.HitInfo.HitEffectRotate != null)
		{
			hitInformation.HitEffectRotation.Set(notify.HitInfo.HitEffectRotate.Pitch, notify.HitInfo.HitEffectRotate.Yaw, notify.HitInfo.HitEffectRotate.Roll);
		}
		if (notify.HitInfo.HitPos != null)
		{
			hitInformation.HitPosition.Set((double)notify.HitInfo.HitPos.X, (double)notify.HitInfo.HitPos.Y, (double)notify.HitInfo.HitPos.Z);
		}
		if (!string.IsNullOrEmpty(notify.HitInfo.HitPart))
		{
			hitInformation.HitPart = FNameUtil.GetDynamicFName(notify.HitInfo.HitPart);
		}
		FRotator victimRotation = WorldGlobal.ToUeRotator(notify.HitInfo.VictimRotation);
		BaseHitComponent baseHitComponent = (entity != null) ? entity.GetComponent<BaseHitComponent>() : null;
		if (baseHitComponent != null)
		{
			baseHitComponent.ReceiveOnHit(hitInformation, entity3, notify.HitInfo.HasBeHitData, notify.HitInfo.IsChangeVictimRotation, notify.HitInfo.EnterFk, notify.HitInfo.IsHitWeakness, notify.HitInfo.IsTriggerCounterattack, notify.HitInfo.IsTriggerVisionCounterAttack, victimRotation, notify.HitInfo.FightState, (EHitAnim)notify.HitInfo.BeHitAnim);
		}
		if (baseHitComponent == null)
		{
			return;
		}
		baseHitComponent.BroadcastRemoteEvent(entity3, notify.HitInfo);
	}

	// Token: 0x06019161 RID: 102753 RVA: 0x00721693 File Offset: 0x0071F893
	protected virtual void ReceiveOnHit(global::HitInformation hitData, Entity attackEntity, bool hasBeHitData, bool isChangeVictimRotation, bool enterFk, bool isHitWeakness, bool isTriggerCounterattack, bool isTriggerVisionCounterAttack, FRotator victimRotation, int fightState, EHitAnim beHitAnim)
	{
	}

	// Token: 0x06019162 RID: 102754 RVA: 0x00721698 File Offset: 0x0071F898
	protected virtual void BroadcastEvent(global::HitInformation hitData)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get<Entity>(hitData.Attacker.Id);
		BulletInfo bulletInfo = Singleton<EntitySystem>.Instance.Get<BulletEntity>(hitData.BulletEntityId).GetBulletInfo();
		int skillId = bulletInfo.BulletInitParams.SkillId;
		long? skillContextId = bulletInfo.BulletInitParams.SkillContextId;
		BaseSkillComponent baseSkillComponent = (entity != null) ? entity.GetComponent<BaseSkillComponent>() : null;
		List<string> list;
		if (baseSkillComponent == null)
		{
			list = null;
		}
		else
		{
			Skill skill = baseSkillComponent.GetSkill(skillId);
			if (skill == null)
			{
				list = null;
			}
			else
			{
				ISkillBattleContext battleContext = skill.BattleContext;
				list = ((battleContext != null) ? battleContext.BattleFlags : null);
			}
		}
		List<string> list2 = list;
		HitContext hitContext = new HitContext();
		hitContext.Attacker = entity;
		hitContext.Target = base.Entity;
		hitContext.BulletId = hitData.BulletId;
		hitContext.HasBeHitAnim = false;
		hitContext.BeHitAnim = EHitAnim.轻左;
		hitContext.VisionCounterAttackId = 0;
		hitContext.CounterAttackType = ECounterAttackType.None;
		hitContext.SkillId = skillId;
		hitContext.SkillHitCount = ModelBase<CombatMessageModel>.Instance.AddSkillHitCount(skillContextId);
		hitContext.SkillHitCountByVictim = ModelBase<CombatMessageModel>.Instance.AddSkillHitCountByVictim(skillContextId, base.Entity.Id);
		hitContext.BulletHitCount = new int?(bulletInfo.HitNumberAll);
		hitContext.BulletHitCountByVictim = new int?(BulletHitCountUtil.GetHitCountByVictim(bulletInfo, base.Entity.Id));
		TEnumAsByte<ESkillGenre>? tenumAsByte;
		if (baseSkillComponent == null)
		{
			tenumAsByte = null;
		}
		else
		{
			SSkillInfo skillInfo = baseSkillComponent.GetSkillInfo(skillId);
			tenumAsByte = ((skillInfo != null) ? new TEnumAsByte<ESkillGenre>?(skillInfo.SkillGenre) : null);
		}
		TEnumAsByte<ESkillGenre>? tenumAsByte2 = tenumAsByte;
		hitContext.SkillGenre = ((tenumAsByte2 != null) ? ((int)tenumAsByte2.GetValueOrDefault()) : -1);
		hitContext.BattleFlags = ((list2 != null) ? list2.ToArray() : Array.Empty<string>());
		HitContext p = hitContext;
		if (entity != null)
		{
			ControllerBase<SceneTeamController>.Instance.EmitEvent<global::HitInformation, HitContext>(entity, EEventName.CharHitLocal, hitData, p);
		}
		ControllerBase<SceneTeamController>.Instance.EmitEvent<global::HitInformation, HitContext>(base.Entity, EEventName.CharBeHitLocal, hitData, p);
	}

	// Token: 0x06019163 RID: 102755 RVA: 0x00721858 File Offset: 0x0071FA58
	[NullableContext(2)]
	protected void BroadcastRemoteEvent(Entity attackEntity, Aki.Protocol.HitInformation hitInfo)
	{
		if (attackEntity == null || hitInfo == null)
		{
			return;
		}
		if (attackEntity != null)
		{
			int skillId = (int)hitInfo.SkillId;
			BaseSkillComponent component = attackEntity.GetComponent<BaseSkillComponent>();
			List<string> list;
			if (component == null)
			{
				list = null;
			}
			else
			{
				Skill skill = component.GetSkill(skillId);
				if (skill == null)
				{
					list = null;
				}
				else
				{
					ISkillBattleContext battleContext = skill.BattleContext;
					list = ((battleContext != null) ? battleContext.BattleFlags : null);
				}
			}
			List<string> list2 = list;
			HitContext hitContext = new HitContext();
			hitContext.Attacker = attackEntity;
			hitContext.Target = base.Entity;
			hitContext.BulletId = hitInfo.BulletId;
			hitContext.HasBeHitAnim = false;
			hitContext.BeHitAnim = (EHitAnim)hitInfo.BeHitAnim;
			hitContext.VisionCounterAttackId = 0;
			hitContext.CounterAttackType = (hitInfo.IsTriggerVisionCounterAttack ? ECounterAttackType.Vision : (hitInfo.IsTriggerCounterattack ? ECounterAttackType.Normal : ECounterAttackType.None));
			hitContext.SkillId = skillId;
			hitContext.SkillHitCount = null;
			hitContext.SkillHitCountByVictim = null;
			hitContext.BulletHitCount = null;
			hitContext.BulletHitCountByVictim = null;
			TEnumAsByte<ESkillGenre>? tenumAsByte;
			if (component == null)
			{
				tenumAsByte = null;
			}
			else
			{
				SSkillInfo skillInfo = component.GetSkillInfo(skillId);
				tenumAsByte = ((skillInfo != null) ? new TEnumAsByte<ESkillGenre>?(skillInfo.SkillGenre) : null);
			}
			TEnumAsByte<ESkillGenre>? tenumAsByte2 = tenumAsByte;
			hitContext.SkillGenre = ((tenumAsByte2 != null) ? ((int)tenumAsByte2.GetValueOrDefault()) : -1);
			hitContext.BattleFlags = ((list2 != null) ? list2.ToArray() : Array.Empty<string>());
			HitContext p = hitContext;
			ControllerBase<SceneTeamController>.Instance.EmitEvent<HitContext>(attackEntity, EEventName.CharHitRemote, p);
			ControllerBase<SceneTeamController>.Instance.EmitEvent<HitContext>(base.Entity, EEventName.CharBeHitRemote, p);
		}
	}

	// Token: 0x06019164 RID: 102756 RVA: 0x007219C2 File Offset: 0x0071FBC2
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		BaseHitComponent baseHitComponent = (BaseHitComponent)componentTemplate;
		return true;
	}
}
