using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Core.Fight;
using CSharpScript.Game.World.Model;
using UnrealEngine;

// Token: 0x02002DCA RID: 11722
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class BulletLogicShieldController : BulletLogicController<LogicDataShield, BulletInfo>
{
	// Token: 0x06017A10 RID: 96784 RVA: 0x006945B4 File Offset: 0x006927B4
	[NullableContext(1)]
	public BulletLogicShieldController(LogicDataShield logicData, Entity bullet) : base(logicData, bullet)
	{
		TArray<string> notDefenseBulletIdList = logicData.NotDefenseBulletIdList;
		if (notDefenseBulletIdList != null && notDefenseBulletIdList.Num() > 0)
		{
			this.NotDefenseBulletId = new string[notDefenseBulletIdList.Num()];
			for (int i = 0; i < notDefenseBulletIdList.Num(); i++)
			{
				this.NotDefenseBulletId[i] = notDefenseBulletIdList.Get(i);
			}
		}
		TArray<string> defenseBulletIdList = logicData.DefenseBulletIdList;
		if (defenseBulletIdList != null && defenseBulletIdList.Num() > 0)
		{
			this.DefenseBulletId = new string[defenseBulletIdList.Num()];
			for (int j = 0; j < defenseBulletIdList.Num(); j++)
			{
				this.DefenseBulletId[j] = defenseBulletIdList.Get(j);
			}
		}
		TArray<long> addBuffToEnemy = logicData.AddBuffToEnemy;
		if (addBuffToEnemy != null && addBuffToEnemy.Num() > 0)
		{
			this.AddBuffToEnemy = new long[addBuffToEnemy.Num()];
			for (int k = 0; k < addBuffToEnemy.Num(); k++)
			{
				this.AddBuffToEnemy[k] = addBuffToEnemy.Get(k);
			}
		}
		TArray<long> addBuffToSelf = logicData.AddBuffToSelf;
		if (addBuffToSelf != null && addBuffToSelf.Num() > 0)
		{
			this.AddBuffToSelf = new long[addBuffToSelf.Num()];
			for (int l = 0; l < addBuffToSelf.Num(); l++)
			{
				this.AddBuffToSelf[l] = addBuffToSelf.Get(l);
			}
		}
		TArray<int> selfCalcTypeArray = logicData.SelfCalcTypeArray;
		int num = (selfCalcTypeArray != null) ? selfCalcTypeArray.Num() : 0;
		if (num > 0)
		{
			this.SelfCalcTypes = new int[num];
			for (int m = 0; m < num; m++)
			{
				this.SelfCalcTypes[m] = selfCalcTypeArray.Get(m);
			}
		}
		TArray<int> friendCalcTypeArray = logicData.FriendCalcTypeArray;
		int num2 = (friendCalcTypeArray != null) ? friendCalcTypeArray.Num() : 0;
		if (num2 > 0)
		{
			this.FriendCalcTypes = new int[num2];
			for (int n = 0; n < num2; n++)
			{
				this.FriendCalcTypes[n] = friendCalcTypeArray.Get(n);
			}
		}
		TArray<int> enemyCalcTypeArray = logicData.EnemyCalcTypeArray;
		int num3 = (enemyCalcTypeArray != null) ? enemyCalcTypeArray.Num() : 0;
		if (num3 > 0)
		{
			this.EnemyCalcTypes = new int[num3];
			for (int num4 = 0; num4 < num3; num4++)
			{
				this.EnemyCalcTypes[num4] = enemyCalcTypeArray.Get(num4);
			}
		}
	}

	// Token: 0x06017A11 RID: 96785 RVA: 0x006947D8 File Offset: 0x006929D8
	public override void OnInit()
	{
		this.BulletInfo = this.Bullet.GetBulletInfo();
		this.BulletInfo.IsShield = true;
	}

	// Token: 0x06017A12 RID: 96786 RVA: 0x006947F8 File Offset: 0x006929F8
	public override void BulletLogicAction(BulletInfo otherBulletInfo = null)
	{
		if (!this.CheckCanDefense(otherBulletInfo))
		{
			return;
		}
		if (this.AddBuffToEnemy != null)
		{
			BaseBuffComponent attackerBuffComp = otherBulletInfo.AttackerBuffComp;
			BaseBuffComponent attackerBuffComp2 = this.BulletInfo.AttackerBuffComp;
			if (attackerBuffComp != null && attackerBuffComp2 != null)
			{
				foreach (long buffId in this.AddBuffToEnemy)
				{
					attackerBuffComp.AddBuff(buffId, new AddBuffParam
					{
						InstigatorId = attackerBuffComp2.CreatureDataId,
						Level = new int?(this.BulletInfo.SkillLevel),
						Reason = "ShieldDefense-AddBuffToEnemy",
						PreMessageId = this.BulletInfo.ContextId
					});
				}
			}
		}
		if (this.AddBuffToSelf != null)
		{
			BaseBuffComponent attackerBuffComp3 = this.BulletInfo.AttackerBuffComp;
			if (attackerBuffComp3 != null)
			{
				foreach (long buffId2 in this.AddBuffToSelf)
				{
					attackerBuffComp3.AddBuff(buffId2, new AddBuffParam
					{
						InstigatorId = attackerBuffComp3.CreatureDataId,
						Level = new int?(this.BulletInfo.SkillLevel),
						Reason = "ShieldDefense-AddBuffToSelf",
						PreMessageId = this.BulletInfo.ContextId
					});
				}
			}
		}
		int decreaseBulletHitCount = this.LogicController.DecreaseBulletHitCount;
		if (decreaseBulletHitCount > 0)
		{
			Entity attacker = this.BulletInfo.Attacker;
			for (int j = 0; j < decreaseBulletHitCount; j++)
			{
				BulletHitCountUtil.AddHitCount(otherBulletInfo, attacker);
			}
		}
		BulletHitCountUtil.AddHitCount(this.BulletInfo, otherBulletInfo.Attacker);
	}

	// Token: 0x06017A13 RID: 96787 RVA: 0x00694968 File Offset: 0x00692B68
	[NullableContext(1)]
	public bool CheckCanDefense(BulletInfo otherBulletInfo)
	{
		if (this.LogicController.DefenseCanDodgeBullet)
		{
			BulletDataMain bulletDataMain = otherBulletInfo.BulletDataMain;
			if (bulletDataMain == null || !bulletDataMain.Logic.CanDodge)
			{
				return false;
			}
		}
		bool flag = this.LogicController.DefenseCaughtTrigger && otherBulletInfo.HasTagId(GameplayTagDefine.EGameplayTagId["子弹.通用标识.抓取判定"]);
		string otherBulletId = otherBulletInfo.BulletRowName;
		if (this.DefenseBulletId != null && !Array.Exists<string>(this.DefenseBulletId, (string id) => id == otherBulletId))
		{
			return false;
		}
		if (this.NotDefenseBulletId != null && Array.Exists<string>(this.NotDefenseBulletId, (string id) => id == otherBulletId))
		{
			return false;
		}
		long damageId = otherBulletInfo.CollisionInfo.DamageId;
		Damage? damage = (damageId > 0L) ? ModelBase<DamageModel>.Instance.GetDamageConfigById(damageId) : null;
		int otherBulletCalcType = -1;
		if (damage != null)
		{
			otherBulletCalcType = damage.Value.CalculateType;
		}
		if (otherBulletInfo.AttackerId == this.BulletInfo.AttackerId)
		{
			if (!this.CheckBulletCampType(this.LogicController.SelfCampType, otherBulletInfo.BulletCamp) || (!flag && !this.CheckBulletCalcType(this.SelfCalcTypes, otherBulletCalcType)))
			{
				return false;
			}
		}
		else
		{
			ECamp attackerCamp = this.BulletInfo.AttackerCamp;
			ECamp attackerCamp2 = otherBulletInfo.AttackerCamp;
			ERelation campRelationship = CampUtils.GetCampRelationship(attackerCamp, attackerCamp2);
			if (campRelationship == ERelation.Friend)
			{
				if (!this.CheckBulletCampType(this.LogicController.FriendCampType, otherBulletInfo.BulletCamp) || (!flag && !this.CheckBulletCalcType(this.FriendCalcTypes, otherBulletCalcType)))
				{
					return false;
				}
			}
			else
			{
				if (campRelationship != ERelation.Enemy)
				{
					return false;
				}
				if (!this.CheckBulletCampType(this.LogicController.EnemyCampType, otherBulletInfo.BulletCamp) || (!flag && !this.CheckBulletCalcType(this.EnemyCalcTypes, otherBulletCalcType)))
				{
					return false;
				}
			}
		}
		if (this.LogicController.DefenseAngle > 0)
		{
			global::Vector actorLocation = this.BulletInfo.GetActorLocation();
			global::Vector actorLocation2 = otherBulletInfo.GetActorLocation();
			global::Vector vector = BulletPool.CreateVector(false);
			actorLocation2.Subtraction(actorLocation, vector);
			vector.Z = 0.0;
			if (!vector.IsZero())
			{
				vector.Normalize(9.99999993922529E-09);
				global::Vector vector2 = BulletPool.CreateVector(false);
				this.BulletInfo.GetActorForward(vector2);
				double num = vector2.DotProduct(vector);
				BulletPool.RecycleVector(vector);
				BulletPool.RecycleVector(vector2);
				double num2 = Math.Cos((double)((float)this.LogicController.DefenseAngle * 0.017453292f));
				if (num < num2)
				{
					return false;
				}
			}
			else
			{
				BulletPool.RecycleVector(vector);
			}
		}
		return true;
	}

	// Token: 0x06017A14 RID: 96788 RVA: 0x00694BE4 File Offset: 0x00692DE4
	private bool CheckBulletCampType(ECampType campTypeNeedCheck, int bulletCamp)
	{
		if (campTypeNeedCheck == ECampType.全部)
		{
			return true;
		}
		if (campTypeNeedCheck == ECampType.不生效)
		{
			return false;
		}
		int num = BulletLogicShieldController.CampTypeBitMask[(int)campTypeNeedCheck];
		return (bulletCamp & num) != 0;
	}

	// Token: 0x06017A15 RID: 96789 RVA: 0x00694C0C File Offset: 0x00692E0C
	private bool CheckBulletCalcType(int[] needCheck, int otherBulletCalcType)
	{
		if (needCheck == null)
		{
			return true;
		}
		int num = needCheck.Length;
		for (int i = 0; i < num; i++)
		{
			int num2 = needCheck[i];
			if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)otherBulletCalcType, (double)num2, null))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0400B60F RID: 46607
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly int[] CampTypeBitMask = new int[]
	{
		0,
		1,
		4,
		2,
		3,
		5
	};

	// Token: 0x0400B610 RID: 46608
	private BulletInfo BulletInfo;

	// Token: 0x0400B611 RID: 46609
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private readonly string[] NotDefenseBulletId;

	// Token: 0x0400B612 RID: 46610
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private readonly string[] DefenseBulletId;

	// Token: 0x0400B613 RID: 46611
	private readonly long[] AddBuffToEnemy;

	// Token: 0x0400B614 RID: 46612
	private readonly long[] AddBuffToSelf;

	// Token: 0x0400B615 RID: 46613
	private readonly int[] SelfCalcTypes;

	// Token: 0x0400B616 RID: 46614
	private readonly int[] FriendCalcTypes;

	// Token: 0x0400B617 RID: 46615
	private readonly int[] EnemyCalcTypes;
}
