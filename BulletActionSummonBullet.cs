using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002D91 RID: 11665
[NullableContext(1)]
[Nullable(0)]
public class BulletActionSummonBullet : BulletActionBase
{
	// Token: 0x06017860 RID: 96352 RVA: 0x00689DBF File Offset: 0x00687FBF
	public BulletActionSummonBullet(EBulletAction type) : base(type)
	{
	}

	// Token: 0x06017861 RID: 96353 RVA: 0x00689DC8 File Offset: 0x00687FC8
	protected override void OnExecute()
	{
		this.ChildInfo = this.BulletInfo.ChildInfo;
		if (this.ChildInfo == null)
		{
			return;
		}
		this.ChildBulletData = this.BulletInfo.BulletDataMain.Children;
		BulletActionInfoSummonBullet bulletActionInfoSummonBullet = (BulletActionInfoSummonBullet)this.ActionInfo;
		if (bulletActionInfoSummonBullet.IsStayInCharacter)
		{
			this.SummonBulletOnCharacterStayBullet(bulletActionInfoSummonBullet);
			return;
		}
		this.SummonBulletOnHit(bulletActionInfoSummonBullet);
	}

	// Token: 0x06017862 RID: 96354 RVA: 0x00689E28 File Offset: 0x00688028
	public override void Clear()
	{
		base.Clear();
		this.ChildInfo = null;
		this.ChildBulletData = null;
	}

	// Token: 0x06017863 RID: 96355 RVA: 0x00689E40 File Offset: 0x00688040
	private void SummonBulletOnHit(BulletActionInfoSummonBullet actionInfo)
	{
		BulletDataChild[] childBulletData = this.ChildBulletData;
		int num = childBulletData.Length;
		FTransformDouble? ftransformDouble = null;
		for (int i = 0; i < num; i++)
		{
			EBulletChildrenType condition = childBulletData[i].Condition;
			EBulletChildrenType? childrenType = actionInfo.ChildrenType;
			if (condition == childrenType.GetValueOrDefault() & childrenType != null)
			{
				BulletDataChild bulletDataChild = childBulletData[i];
				if ((bulletDataChild.Num <= 0 || this.ChildInfo.HaveSummonedBulletNumber[i] < bulletDataChild.Num) && bulletDataChild.RowName != 0L)
				{
					if (ftransformDouble == null && actionInfo.ParentImpactPoint != null && actionInfo.ParentLastPosition != null)
					{
						Vector vector = BulletPool.CreateVector(false);
						Vector vector2 = BulletPool.CreateVector(false);
						vector.FromUeVector(actionInfo.ParentImpactPoint);
						vector.SubtractionEqual(actionInfo.ParentLastPosition);
						vector2.FromUeVector(this.BulletInfo.MoveInfo.BulletSpeedDir);
						vector2.Normalize(9.99999993922529E-09);
						double inB = vector.DotProduct(vector2);
						vector2.Multiply(inB, vector);
						actionInfo.ParentLastPosition.Addition(vector, vector2);
						ftransformDouble = new FTransformDouble?(this.BulletInfo.ActorComponent.ActorTransform);
						FTransformDouble value = ftransformDouble.Value;
						FVectorDouble fvectorDouble = vector2.ToUeVector(false);
						value.SetLocation(fvectorDouble);
						BulletPool.RecycleVector(vector2);
						BulletPool.RecycleVector(vector);
					}
					List<int> haveSummonedBulletNumber = this.ChildInfo.HaveSummonedBulletNumber;
					int index = i;
					int num2 = haveSummonedBulletNumber[index];
					haveSummonedBulletNumber[index] = num2 + 1;
					HashSet<string> parentIds = BulletUtil.CollectParentsId(this.BulletInfo);
					BulletController instance = ControllerBase<BulletController>.Instance;
					Entity attacker = this.BulletInfo.Attacker;
					string bulletRowName = bulletDataChild.RowName.ToString();
					FTransformDouble? initialTransform = new FTransformDouble?(ftransformDouble ?? this.BulletInfo.ActorComponent.ActorTransform);
					BulletController.BulletCreateParams bulletCreateParams = new BulletController.BulletCreateParams();
					bulletCreateParams.SkillId = this.BulletInfo.BulletInitParams.SkillId;
					bulletCreateParams.SkillContextId = this.BulletInfo.BulletInitParams.SkillContextId;
					Entity victim = actionInfo.Victim;
					bulletCreateParams.ParentVictimId = ((victim != null) ? new int?(victim.Id) : null);
					Entity target = this.BulletInfo.Target;
					bulletCreateParams.ParentTargetId = ((target != null) ? new int?(target.Id) : null);
					bulletCreateParams.ParentId = this.BulletInfo.Entity.Id;
					bulletCreateParams.CreateOnAuthority = actionInfo.CreateOnAuthority;
					bulletCreateParams.BattleContext = this.BulletInfo.BulletInitParams.BattleContext;
					bulletCreateParams.ParentIds = parentIds;
					BulletEntity bulletEntity = instance.CreateBulletCustomTarget(attacker, bulletRowName, initialTransform, bulletCreateParams, this.BulletInfo.ContextId, EBulletCreateSource.Others);
					if (bulletEntity == null)
					{
						if (bulletDataChild.BreakOnFail)
						{
							return;
						}
					}
					else
					{
						BulletUtil.ProcessHandOverEffectToSon(this.BulletInfo, bulletEntity);
					}
				}
			}
		}
	}

	// Token: 0x06017864 RID: 96356 RVA: 0x0068A118 File Offset: 0x00688318
	private void SummonBulletOnCharacterStayBullet(BulletActionInfoSummonBullet actionInfo)
	{
		int num = this.ChildBulletData.Length;
		for (int i = 0; i < num; i++)
		{
			BulletDataChild bulletDataChild = this.ChildBulletData[i];
			int num2 = i;
			if (bulletDataChild.Condition == EBulletChildrenType.OnHitVictim && (bulletDataChild.Num <= 0 || this.ChildInfo.HaveSummonedBulletNumber[num2] < bulletDataChild.Num) && this.BulletInfo.LiveTime >= (float)this.ChildInfo.HaveSummonedBulletNumber[num2] * bulletDataChild.Interval * (float)Singleton<TimeUtil>.Instance.InverseMillisecond)
			{
				List<int> haveSummonedBulletNumber = this.ChildInfo.HaveSummonedBulletNumber;
				int index = num2;
				int num3 = haveSummonedBulletNumber[index];
				haveSummonedBulletNumber[index] = num3 + 1;
				HashSet<string> parentIds = BulletUtil.CollectParentsId(this.BulletInfo);
				BulletController instance = ControllerBase<BulletController>.Instance;
				Entity attacker = this.BulletInfo.Attacker;
				string bulletRowName = bulletDataChild.RowName.ToString();
				FTransformDouble? initialTransform = new FTransformDouble?(this.BulletInfo.ActorComponent.ActorTransform);
				BulletController.BulletCreateParams bulletCreateParams = new BulletController.BulletCreateParams();
				bulletCreateParams.SkillId = this.BulletInfo.BulletInitParams.SkillId;
				bulletCreateParams.SkillContextId = this.BulletInfo.BulletInitParams.SkillContextId;
				Entity victim = actionInfo.Victim;
				bulletCreateParams.ParentVictimId = ((victim != null) ? new int?(victim.Id) : null);
				Entity target = this.BulletInfo.Target;
				bulletCreateParams.ParentTargetId = ((target != null) ? new int?(target.Id) : null);
				bulletCreateParams.ParentId = this.BulletInfo.Entity.Id;
				bulletCreateParams.CreateOnAuthority = actionInfo.CreateOnAuthority;
				bulletCreateParams.BattleContext = this.BulletInfo.BulletInitParams.BattleContext;
				bulletCreateParams.ParentIds = parentIds;
				BulletEntity bulletEntity = instance.CreateBulletCustomTarget(attacker, bulletRowName, initialTransform, bulletCreateParams, this.BulletInfo.ContextId, EBulletCreateSource.Others);
				if (bulletEntity == null)
				{
					if (bulletDataChild.BreakOnFail)
					{
						return;
					}
				}
				else
				{
					BulletUtil.ProcessHandOverEffectToSon(this.BulletInfo, bulletEntity);
				}
			}
		}
	}

	// Token: 0x0400B480 RID: 46208
	[Nullable(2)]
	public BulletChildInfo ChildInfo;

	// Token: 0x0400B481 RID: 46209
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private BulletDataChild[] ChildBulletData;
}
