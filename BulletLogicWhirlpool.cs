using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x02002DD1 RID: 11729
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class BulletLogicWhirlpool : BulletLogicController<LogicDataWhirlpool, object>
{
	// Token: 0x06017A31 RID: 96817 RVA: 0x00695D1C File Offset: 0x00693F1C
	public BulletLogicWhirlpool(LogicDataWhirlpool bulletLogicBase, Entity bullet) : base(bulletLogicBase, bullet)
	{
		base.NeedTick = true;
		this.WeightLimit = bulletLogicBase.WeightLimit;
		this.BulletInfo = (bullet as BulletEntity).GetBulletInfo();
		this.Id = WhirlpoolPoint.GenId();
		this.MoveTime = bulletLogicBase.MoveTime;
	}

	// Token: 0x06017A32 RID: 96818 RVA: 0x00695D82 File Offset: 0x00693F82
	public override void OnInit()
	{
	}

	// Token: 0x06017A33 RID: 96819 RVA: 0x00695D84 File Offset: 0x00693F84
	protected override void Update(float deltaTime)
	{
		foreach (Entity item in this.BulletInfo.CollisionInfo.CharacterEntityMap.Keys)
		{
			this.CharacterInArea.Add(item);
		}
		foreach (Entity characterEntity in this.CharacterInArea)
		{
			this.UpdateCharacterWhirlpool(characterEntity);
		}
	}

	// Token: 0x06017A34 RID: 96820 RVA: 0x00695E30 File Offset: 0x00694030
	private void UpdateCharacterWhirlpool(Entity characterEntity)
	{
		CharacterMoveComponent characterMoveComponent = (characterEntity != null) ? characterEntity.GetComponent<CharacterMoveComponent>() : null;
		if (characterMoveComponent == null || !characterMoveComponent.Valid || this.WeightLimit < characterMoveComponent.CharacterWeight)
		{
			return;
		}
		if (characterMoveComponent.GetWhirlpoolId() != this.Id)
		{
			if (!characterMoveComponent.GetWhirlpoolEnable() || characterMoveComponent.CompareWhirlpoolPriority(this.MoveTime))
			{
				this.GetToLocation();
				characterMoveComponent.BeginWhirlpool(this.Id, this.MoveTime, this.Location, characterMoveComponent.ActorComp.ActorLocationProxy, -1f, (EVelocityCurveType)this.LogicController.VelocityCurve, this.LogicController.CancelByHit, GameplayTagUtils.IsValidTag(new FGameplayTag?(this.LogicController.TagNeed)) ? GameplayTagUtils.GetTagIdByName(this.LogicController.TagNeed.TagName.ToString()) : 0);
				bool openMoveLog = Singleton<BulletConstant>.Instance.OpenMoveLog;
				return;
			}
		}
		else
		{
			this.GetToLocation();
			if (Singleton<BulletConstant>.Instance.OpenMoveLog)
			{
				UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.World, this.Location.ToUeVector(false), 10f, 10, new FLinearColor?(ColorUtils.LinearGreen), 3f, 3f);
			}
			characterMoveComponent.UpdateWhirlpoolLocation(this.Location);
		}
	}

	// Token: 0x06017A35 RID: 96821 RVA: 0x00695F78 File Offset: 0x00694178
	private void GetToLocation()
	{
		if (FNameUtil.IsNothing(this.LogicController.AttackerSocketName))
		{
			this.Location.FromUeVector(this.BulletInfo.ActorComponent.ActorLocationProxy);
			return;
		}
		Vector location = this.Location;
		FVectorDouble socketLocation = this.BulletInfo.AttackerActorComp.GetSocketLocation(this.LogicController.AttackerSocketName);
		location.FromUeVector(socketLocation);
	}

	// Token: 0x06017A36 RID: 96822 RVA: 0x00695FDC File Offset: 0x006941DC
	public override void OnBulletDestroy()
	{
		foreach (Entity entity in this.CharacterInArea)
		{
			CharacterMoveComponent characterMoveComponent = (entity != null) ? entity.GetComponent<CharacterMoveComponent>() : null;
			if (characterMoveComponent != null && characterMoveComponent.Valid && characterMoveComponent.GetWhirlpoolEnable() && characterMoveComponent.GetWhirlpoolId() == this.Id)
			{
				characterMoveComponent.EndWhirlpool("子弹销毁");
				bool openMoveLog = Singleton<BulletConstant>.Instance.OpenMoveLog;
			}
		}
		this.CharacterInArea.Clear();
	}

	// Token: 0x0400B62A RID: 46634
	private const int DEBUG_SEGMENTS = 10;

	// Token: 0x0400B62B RID: 46635
	private const float DEBUG_DURATION = 3f;

	// Token: 0x0400B62C RID: 46636
	private const float DEBUG_THICKNESS = 3f;

	// Token: 0x0400B62D RID: 46637
	private readonly float WeightLimit;

	// Token: 0x0400B62E RID: 46638
	[Nullable(2)]
	private readonly BulletInfo BulletInfo;

	// Token: 0x0400B62F RID: 46639
	private readonly int Id;

	// Token: 0x0400B630 RID: 46640
	private readonly float MoveTime;

	// Token: 0x0400B631 RID: 46641
	private readonly HashSet<Entity> CharacterInArea = new HashSet<Entity>();

	// Token: 0x0400B632 RID: 46642
	private readonly Vector Location = Vector.Create();
}
