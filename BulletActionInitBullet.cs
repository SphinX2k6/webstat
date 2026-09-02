using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Module.CombatMessage;
using UnrealEngine;

// Token: 0x02002D89 RID: 11657
[NullableContext(1)]
[Nullable(0)]
public class BulletActionInitBullet : BulletActionBase
{
	// Token: 0x06017810 RID: 96272 RVA: 0x00683F42 File Offset: 0x00682142
	public BulletActionInitBullet(EBulletAction type) : base(type)
	{
	}

	// Token: 0x06017811 RID: 96273 RVA: 0x00683F4C File Offset: 0x0068214C
	protected override void OnExecute()
	{
		BulletInfo bulletInfo = this.BulletInfo;
		BulletInitParams bulletInitParams = bulletInfo.BulletInitParams;
		BulletDataMain bulletDataMain = bulletInfo.BulletDataMain;
		bulletInfo.GenerateTime = (float)Singleton<Time>.Instance.WorldTime;
		long? num = bulletInitParams.FromRemote ? bulletInitParams.ContextId : new long?(ModelBase<CombatMessageModel>.Instance.GenMessageId());
		bulletInfo.PreContextId = (bulletInitParams.FromRemote ? new long?(0L) : bulletInitParams.ContextId);
		bulletInfo.ContextId = num;
		ModelBase<CombatMessageModel>.Instance.OnBulletAdded(bulletInitParams.SkillContextId, num, bulletInfo.BulletRowName);
		int targetId = bulletInitParams.TargetId;
		bulletInfo.SetTargetById(targetId);
		CreatureDataComponent attackerCreatureDataComp = bulletInfo.AttackerCreatureDataComp;
		if (attackerCreatureDataComp == null)
		{
			ControllerBase<BulletController>.Instance.DestroyBullet(bulletInfo.BulletEntityId, false, EBulletDestroyReason.Normal, false);
			return;
		}
		if (attackerCreatureDataComp.GetEntityType() != EEntityType.Player)
		{
			bulletInfo.AttackerCamp = attackerCreatureDataComp.GetEntityCamp();
		}
		else
		{
			bulletInfo.AttackerCamp = ECamp.Player;
		}
		bulletInfo.IsAutonomousProxy = bulletInfo.AttackerActorComp.IsAutonomousProxy;
		bulletInfo.AttackerPlayerId = attackerCreatureDataComp.GetPlayerId();
		BulletInfo bulletInfo2 = bulletInfo;
		BaseSkillComponent attackerSkillComp = bulletInfo.AttackerSkillComp;
		bulletInfo2.SkillLevel = ((attackerSkillComp != null) ? attackerSkillComp.GetSkillLevelBySkillInfoId((long)bulletInitParams.SkillId) : 0);
		BulletDataMove move = bulletDataMain.Move;
		if (move.UpDownAngleLimit > 0f)
		{
			FVectorDouble? targetLocation = BulletUtil.GetTargetLocation(bulletInfo.TargetActorComp, FNameUtil.GetDynamicFName(move.InitVelocityDirParam) ?? FName.NAME_None, bulletInfo);
			if (targetLocation != null)
			{
				global::Vector vector = BulletPool.CreateVector(false);
				global::Vector vector2 = vector;
				FVectorDouble value = targetLocation.Value;
				vector2.FromUeVector(value);
				BaseActorComponent attackerActorComp = bulletInfo.AttackerActorComp;
				global::Vector vector3 = BulletPool.CreateVector(false);
				vector3.FromUeVector(attackerActorComp.ActorLocationProxy);
				vector3.SubtractionEqual(vector);
				double num2 = vector3.Size();
				if (num2 > 0.0)
				{
					bool flag = false;
					CharacterMoveComponent attackerMoveComp = bulletInfo.AttackerMoveComp;
					if (attackerMoveComp == null || attackerMoveComp.IsStandardGravity)
					{
						double num3 = vector3.Z;
						num3 = ((num3 > 0.0) ? num3 : (num3 * -1.0));
						if ((double)move.UpDownAngleLimit < Singleton<MathUtils>.Instance.ClampedAsin(num3 / num2) * 57.295780181884766)
						{
							flag = true;
						}
					}
					else
					{
						global::Vector vector4 = vector3;
						CharacterMoveComponent attackerMoveComp2 = bulletInfo.AttackerMoveComp;
						double num4 = vector4.DotProduct(((attackerMoveComp2 != null) ? attackerMoveComp2.GravityUp : null) ?? global::Vector.UpVectorProxy);
						if ((double)move.UpDownAngleLimit < Singleton<MathUtils>.Instance.ClampedAsin(num4 / num2) * 57.295780181884766)
						{
							flag = true;
						}
					}
					if (flag)
					{
						bulletInfo.SetTargetById(0);
					}
				}
				BulletPool.RecycleVector(vector3);
				BulletPool.RecycleVector(vector);
			}
		}
		int tagId = bulletDataMain.Base.TagId;
		if (tagId > 0)
		{
			bulletInfo.AddTagId(tagId);
		}
		int[] presentTagIds = bulletDataMain.Logic.PresentTagIds;
		foreach (int tagId2 in presentTagIds)
		{
			bulletInfo.AddTagId(tagId2);
		}
		if (GlobalData.IsPlayInEditor)
		{
			if (tagId > 0)
			{
				this.CheckBulletTag(tagId, bulletInitParams.BulletRowName, "子弹的'基础设置.子弹标签'中的值必须是以[子弹.]开头的");
			}
			foreach (int num5 in presentTagIds)
			{
				if (num5 > 0)
				{
					this.CheckBulletTag(num5, bulletInitParams.BulletRowName, "子弹的'逻辑设置.预设.预设标签'中的值必须是以[子弹.]开头的");
				}
			}
		}
		global::EBulletShape shape = bulletDataMain.Base.Shape;
		global::Vector size = bulletInfo.Size;
		global::Vector size2 = bulletInitParams.Size;
		if (size2 != null)
		{
			if (shape == global::EBulletShape.Cylinder)
			{
				size.Set(size2.X, 0.0, size2.Z);
			}
			else
			{
				size.FromUeVector(size2);
			}
		}
		else
		{
			size.FromUeVector(bulletDataMain.Base.Size);
		}
		bulletInfo.Duration = bulletDataMain.Base.Duration;
		BulletAdditionInfo additionInfo = bulletInfo.AdditionInfo;
		if (additionInfo != null && additionInfo.Valid)
		{
			global::Vector sizeScale = additionInfo.SizeScale;
			if (!sizeScale.IsZero())
			{
				size.MultiplyEqual(sizeScale);
			}
			bulletInfo.Duration += additionInfo.DurationAddition;
		}
		bulletInfo.BaseSize.FromUeVector(size);
		if (bulletDataMain.Children.Length != 0)
		{
			ControllerBase<BulletController>.Instance.AddSimpleAction(bulletInfo, EBulletAction.Child);
		}
		ControllerBase<BulletController>.Instance.AddSimpleAction(bulletInfo, EBulletAction.InitHit);
		ControllerBase<BulletController>.Instance.AddSimpleAction(bulletInfo, EBulletAction.InitMove);
		ControllerBase<BulletController>.Instance.AddSimpleAction(bulletInfo, EBulletAction.InitCollision);
		if (bulletDataMain.Summon.EntityId > 0)
		{
			ControllerBase<BulletController>.Instance.AddSimpleAction(bulletInfo, EBulletAction.SummonEntity);
		}
		ControllerBase<BulletController>.Instance.AddSimpleAction(bulletInfo, EBulletAction.InitRender);
		if (bulletDataMain.Logic.DestroyOnFrozen)
		{
			ControllerBase<BulletController>.Instance.AddSimpleAction(bulletInfo, EBulletAction.UpdateAttackerFrozen);
		}
		ControllerBase<BulletController>.Instance.AddSimpleAction(bulletInfo, EBulletAction.UpdateEffect);
		if (bulletDataMain.Interact.IsSceneInteract)
		{
			ControllerBase<BulletController>.Instance.AddSimpleAction(bulletInfo, EBulletAction.SceneInteract);
		}
		ControllerBase<BulletController>.Instance.AddSimpleAction(bulletInfo, EBulletAction.UpdateLiveTime);
		ControllerBase<BulletController>.Instance.AddSimpleAction(bulletInfo, EBulletAction.TimeScale);
		ControllerBase<BulletController>.Instance.AddSimpleAction(bulletInfo, EBulletAction.AfterInit);
	}

	// Token: 0x06017812 RID: 96274 RVA: 0x00684414 File Offset: 0x00682614
	private unsafe void CheckBulletTag(int tagId, string bulletConfigId, string msg)
	{
		string nameByTagId = GameplayTagUtils.GetNameByTagId(tagId);
		if (nameByTagId == null || !nameByTagId.StartsWith("子弹."))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Bullet;
			ELogAuthor author = ELogAuthor.CFT;
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BulletId", bulletConfigId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Tag", nameByTagId);
			instance.Error(module, author, msg, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
	}

	// Token: 0x0400B45C RID: 46172
	private const string BULLET_TAG_PREFIX = "子弹.";
}
