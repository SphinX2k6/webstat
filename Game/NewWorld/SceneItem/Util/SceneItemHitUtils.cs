using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow;
using CSharpScript.Game.NewWorld.Vehicle.Motorcycle;

namespace CSharpScript.Game.NewWorld.SceneItem.Util
{
	// Token: 0x0200481A RID: 18458
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneItemHitUtils
	{
		// Token: 0x06030089 RID: 196745 RVA: 0x00BA3888 File Offset: 0x00BA1A88
		public static bool CheckHitDataMatchBulletType(IHitBulletType matchedBullet, HitInformation hitData, Entity victim)
		{
			switch (matchedBullet.Type)
			{
			case EHitBulletType.OnlyDropAttack:
				return SceneItemHitUtils.CheckHitDataMatchOnlyDropAttack(hitData, victim);
			case EHitBulletType.CrystalAttack:
				return SceneItemHitUtils.CheckHitDataMatchCrystalAttack(hitData);
			case EHitBulletType.PlayerAttack:
				return SceneItemHitUtils.CheckHitDataMatchPlayerAttack(hitData);
			case EHitBulletType.FixedBulletId:
				return SceneItemHitUtils.CheckHitDataMatchFixedBulletId((IHitBulletTypeFixedBulletId)matchedBullet, hitData);
			default:
				return true;
			}
		}

		// Token: 0x0603008A RID: 196746 RVA: 0x00BA38D8 File Offset: 0x00BA1AD8
		public static bool CheckHitDataMatchOnlyDropAttack(HitInformation hitData, Entity victim)
		{
			if (!hitData.ReBulletData.Logic.PresentTagIds.Contains(GameplayTagDefine.EGameplayTagId["子弹.机关触发.下落攻击触发"]))
			{
				return false;
			}
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			CharacterActorComponent characterActorComponent = (baseCharacter != null) ? baseCharacter.CharacterActorComponent : null;
			BaseActorComponent component = victim.GetComponent<BaseActorComponent>();
			return characterActorComponent != null && component != null && Vector.DistSquared2D(component.ActorLocationProxy, characterActorComponent.ActorLocationProxy) <= 28900.0;
		}

		// Token: 0x0603008B RID: 196747 RVA: 0x00BA394D File Offset: 0x00BA1B4D
		public static bool CheckHitDataMatchCrystalAttack(HitInformation hitData)
		{
			return hitData.ReBulletData.Logic.PresentTagIds.Contains(GameplayTagDefine.EGameplayTagId["子弹.机关触发.鸣晶爆炸触发"]);
		}

		// Token: 0x0603008C RID: 196748 RVA: 0x00BA3978 File Offset: 0x00BA1B78
		public static bool CheckHitDataMatchGundamBossOrPlayerAttack(HitInformation hitData)
		{
			Entity attacker = hitData.Attacker;
			if (attacker == null || !attacker.Valid)
			{
				return false;
			}
			CreatureDataComponent component = hitData.Attacker.GetComponent<CreatureDataComponent>();
			return component != null && (component.GetTemplateId() == 672000001 || SceneItemHitUtils.CheckHitDataMatchPlayerAttack(hitData));
		}

		// Token: 0x0603008D RID: 196749 RVA: 0x00BA39C0 File Offset: 0x00BA1BC0
		public static bool CheckHitDataMatchPlayerAttack(HitInformation hitData)
		{
			if (hitData.Attacker == null || !hitData.Attacker.Valid)
			{
				return false;
			}
			CreatureDataComponent component = hitData.Attacker.GetComponent<CreatureDataComponent>();
			if ((component != null && component.IsRole()) || (component != null && component.IsVision()))
			{
				return true;
			}
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(component.GetSummonerId());
			WorldEntity worldEntity = (entity != null) ? entity.Entity : null;
			CreatureDataComponent creatureDataComponent = (worldEntity != null) ? worldEntity.GetComponent<CreatureDataComponent>() : null;
			if (creatureDataComponent != null && creatureDataComponent.IsRole())
			{
				return true;
			}
			VehiclePerformComponent component2 = hitData.Attacker.GetComponent<VehiclePerformComponent>();
			bool flag;
			if (component2 == null)
			{
				flag = false;
			}
			else
			{
				Entity driver = component2.Driver;
				bool? flag2;
				if (driver == null)
				{
					flag2 = null;
				}
				else
				{
					CreatureDataComponent component3 = driver.GetComponent<CreatureDataComponent>();
					flag2 = ((component3 != null) ? new bool?(component3.IsRole()) : null);
				}
				bool? flag3 = flag2;
				flag = flag3.GetValueOrDefault();
			}
			if (flag)
			{
				return true;
			}
			if (hitData.Attacker.GetComponent<MotorcycleConfigComponent>() != null)
			{
				return true;
			}
			CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow.FollowShooterComponent component4 = hitData.Attacker.GetComponent<CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow.FollowShooterComponent>();
			return component4 != null && component4.Valid;
		}

		// Token: 0x0603008E RID: 196750 RVA: 0x00BA3ABC File Offset: 0x00BA1CBC
		public static bool CheckHitDataMatchFixedBulletId(IHitBulletTypeFixedBulletId matchedBullet, HitInformation hitData)
		{
			return hitData.Attacker != null && hitData.Attacker.Valid && (matchedBullet.BulletId == null || matchedBullet.BulletId.Count == 0 || matchedBullet.BulletId.Contains(hitData.BulletId) || (matchedBullet.PlayerAttack.GetValueOrDefault() && SceneItemHitUtils.CheckHitDataMatchPlayerAttack(hitData)));
		}

		// Token: 0x0401B947 RID: 112967
		private const int DROP_ATTACK_VALID_RANGE = 28900;

		// Token: 0x0401B948 RID: 112968
		private const int GUNDAM_BOSS_TEMPLATE_ID = 672000001;
	}
}
