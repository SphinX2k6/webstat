using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.Protocol.Summon;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Core.Fight;
using CSharpScript.Game;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.CombatMessage;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow;
using CSharpScript.Game.NewWorld.Common.Component;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;

// Token: 0x02002DDF RID: 11743
[NullableContext(1)]
[Nullable(0)]
public class BulletUtil
{
	// Token: 0x06017AAC RID: 96940 RVA: 0x0069AB90 File Offset: 0x00698D90
	public static FVectorDouble? GetTargetLocation([Nullable(2)] BaseActorComponent target, FName boneName, BulletInfo bulletInfo)
	{
		if (bulletInfo.BulletDataMain.Move.TrackTarget == EBulletTarget.外部传入坐标)
		{
			return bulletInfo.BulletInitParams.InitTargetLocation;
		}
		if (target == null || !target.Valid)
		{
			return null;
		}
		return new FVectorDouble?(target.GetSocketLocation(boneName));
	}

	// Token: 0x06017AAD RID: 96941 RVA: 0x0069ABE4 File Offset: 0x00698DE4
	[NullableContext(2)]
	public static bool VictimInValid(Entity victim)
	{
		return victim == null || !victim.Valid || BulletUtil.DoesEntityContainsTag(victim, GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"]) || BulletUtil.DoesEntityContainsTag(victim, GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.隐身.不被子弹命中"]);
	}

	// Token: 0x06017AAE RID: 96942 RVA: 0x0069AC30 File Offset: 0x00698E30
	public static bool AttackedCondition(BulletInfo bulletInfo, BaseActorComponent victim)
	{
		return !BulletUtil.VictimInValid((victim != null) ? victim.Entity : null) && BulletUtil.AttackedCampCondition(bulletInfo, victim);
	}

	// Token: 0x06017AAF RID: 96943 RVA: 0x0069AC50 File Offset: 0x00698E50
	public unsafe static bool AttackedCampCondition(BulletInfo bulletInfo, BaseActorComponent victim)
	{
		CreatureDataComponent component = victim.Entity.GetComponent<CreatureDataComponent>();
		if (bulletInfo.BulletCamp == 11)
		{
			if (component.GetEntityType() == EEntityType.Vision)
			{
				return component.GetPlayerId() == bulletInfo.AttackerPlayerId;
			}
			int num = ModelBase<GameModeModel>.Instance.IsMulti ? ModelBase<SceneTeamModel>.Instance.GetTeamItem((long)bulletInfo.AttackerPlayerId, new GetTeamItemOptions
			{
				ParamType = ETeamParamType.PlayerId,
				IsControl = new bool?(true)
			}).EntityHandle.Id : Global.BaseCharacter.GetEntityIdNoBlueprint();
			if (ModelBase<CharacterModel>.Instance.IsValid(num))
			{
				return num == victim.Entity.Id;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Bullet;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "子弹对小队攻击，找不到当前控制玩家";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", bulletInfo.BulletRowName);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "Attacker";
			BaseActorComponent attackerActorComp = bulletInfo.AttackerActorComp;
			ptr = new ValueTuple<string, object>(item, (attackerActorComp != null) ? attackerActorComp.Owner : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("CurrentEntityId", num);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		else
		{
			ECamp attackerCamp = bulletInfo.AttackerCamp;
			ECamp targetCamp = ECamp.Player;
			if (component.GetEntityType() != EEntityType.Player)
			{
				targetCamp = component.GetEntityCamp();
			}
			EBulletCamp ebulletCamp = (EBulletCamp)(ERelation.Enemy * CampUtils.GetCampRelationship(attackerCamp, targetCamp));
			BaseActorComponent attackerActorComp2 = bulletInfo.AttackerActorComp;
			if (victim == attackerActorComp2)
			{
				return (bulletInfo.BulletCamp & 1) != 0;
			}
			return (bulletInfo.BulletCamp & (int)ebulletCamp) != 0 && (ebulletCamp != EBulletCamp.Enemy || !BulletUtil.DoesEntityContainsTag(victim.Entity, GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.不被敌方子弹命中"]));
		}
	}

	// Token: 0x06017AB0 RID: 96944 RVA: 0x0069ADF0 File Offset: 0x00698FF0
	[NullableContext(2)]
	public static bool DoesEntityContainsTag(Entity entity, int gameplayTagId)
	{
		if (entity == null)
		{
			return false;
		}
		LevelTagComponent component = entity.GetComponent<LevelTagComponent>();
		if (component != null && component.HasTag(gameplayTagId))
		{
			return true;
		}
		BaseTagComponent component2 = entity.GetComponent<BaseTagComponent>();
		return component2 != null && component2.HasTag(gameplayTagId);
	}

	// Token: 0x06017AB1 RID: 96945 RVA: 0x0069AE2C File Offset: 0x0069902C
	[return: Nullable(2)]
	public static CharacterActorComponent GetCurrentRole(BulletInfo bulletInfo)
	{
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			EntityHandle entityHandle = ModelBase<SceneTeamModel>.Instance.GetTeamItem((long)bulletInfo.AttackerPlayerId, new GetTeamItemOptions
			{
				ParamType = ETeamParamType.PlayerId,
				IsControl = new bool?(true)
			}).EntityHandle;
			if (entityHandle == null)
			{
				return null;
			}
			WorldEntity entity = entityHandle.Entity;
			if (entity == null)
			{
				return null;
			}
			return entity.GetComponent<CharacterActorComponent>();
		}
		else
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null)
			{
				return null;
			}
			return baseCharacter.CharacterActorComponent;
		}
	}

	// Token: 0x06017AB2 RID: 96946 RVA: 0x0069AE9C File Offset: 0x0069909C
	public static bool ShakeTest(BulletInfo bulletInfo, BaseActorComponent victim)
	{
		if (!CharacterUtils.CanCharacterMonsterOrSummonedDisplayEffect(bulletInfo.AttackerHandle))
		{
			return false;
		}
		bool flag = false;
		BulletDataRender render = bulletInfo.BulletDataMain.Render;
		CharacterActorComponent characterActorComponent = victim as CharacterActorComponent;
		if (characterActorComponent != null && characterActorComponent.IsRoleAndCtrlByMe && render.VictimCameraShakeOnHit != FName.NAME_None && render.CameraShakeCountMax > bulletInfo.ShakeNumbers)
		{
			flag = true;
		}
		if (bulletInfo.Attacker != null && bulletInfo.IsAutonomousProxy && (render.AttackerCameraShakeOnHit != FName.NAME_None || render.AttackerCameraShakeOnHitWeakPoint != FName.NAME_None) && render.CameraShakeCountMax > bulletInfo.ShakeNumbers && BulletUtil.IsPlayerOrSummons(bulletInfo))
		{
			flag = true;
		}
		if (flag)
		{
			bulletInfo.ShakeNumbers++;
		}
		return flag;
	}

	// Token: 0x06017AB3 RID: 96947 RVA: 0x0069AF58 File Offset: 0x00699158
	public static bool IsPlayerOrSummons(BulletInfo bulletInfo)
	{
		if (bulletInfo.AttackerActorComp.IsRoleAndCtrlByMe)
		{
			return true;
		}
		if (!bulletInfo.AttackerActorComp.IsAutonomousProxy)
		{
			return false;
		}
		CreatureDataComponent attackerCreatureDataComp = bulletInfo.AttackerCreatureDataComp;
		int summonerPlayerId = attackerCreatureDataComp.GetSummonerPlayerId();
		if (summonerPlayerId != 0)
		{
			int num = summonerPlayerId;
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			if (num == id.GetValueOrDefault() & id != null)
			{
				if (bulletInfo.BulletDataMain.Render.CameraShakeToSummonOwner)
				{
					return true;
				}
				if (FollowUtils.IsFollowingPlayer(attackerCreatureDataComp.GetCreatureDataId(), summonerPlayerId))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06017AB4 RID: 96948 RVA: 0x0069AFD8 File Offset: 0x006991D8
	public static void SummonBullet(BulletInfo bulletInfo, global::EBulletChildrenType childrenType, Entity victim, bool isStayInCharacter, [Nullable(2)] global::Vector impactPoint = null, [Nullable(2)] global::Vector lastFramePosition = null, bool createOnAuthority = true)
	{
		if (bulletInfo.NeedDestroy)
		{
			return;
		}
		BulletActionInfoSummonBullet bulletActionInfoSummonBullet = ControllerBase<BulletController>.Instance.GetActionCenter().CreateBulletActionInfo(EBulletAction.SummonBullet) as BulletActionInfoSummonBullet;
		bulletActionInfoSummonBullet.ChildrenType = new global::EBulletChildrenType?(childrenType);
		bulletActionInfoSummonBullet.Victim = victim;
		bulletActionInfoSummonBullet.IsStayInCharacter = isStayInCharacter;
		bulletActionInfoSummonBullet.CreateOnAuthority = createOnAuthority;
		if (impactPoint != null)
		{
			bulletActionInfoSummonBullet.ParentImpactPoint = global::Vector.Create(impactPoint);
		}
		if (lastFramePosition != null)
		{
			bulletActionInfoSummonBullet.ParentLastPosition = global::Vector.Create(lastFramePosition);
		}
		ControllerBase<BulletController>.Instance.GetActionRunner().AddAction(bulletInfo, bulletActionInfoSummonBullet);
	}

	// Token: 0x06017AB5 RID: 96949 RVA: 0x0069B05C File Offset: 0x0069925C
	public static bool CheckSupport(BulletInfo bulletInfo, ECamp otherBulletCamp)
	{
		List<ECamp> supportCamp = bulletInfo.BulletDataMain.Execution.SupportCamp;
		if (supportCamp != null && supportCamp.Count > 0)
		{
			using (List<ECamp>.Enumerator enumerator = supportCamp.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current == otherBulletCamp)
					{
						return true;
					}
				}
			}
			return false;
		}
		return false;
	}

	// Token: 0x06017AB6 RID: 96950 RVA: 0x0069B0CC File Offset: 0x006992CC
	public static void ProcessHandOverEffectToSon(BulletInfo bulletInfo, [Nullable(2)] Entity sonBulletEntity)
	{
		if (sonBulletEntity != null && sonBulletEntity.Valid)
		{
			BulletInfo bulletInfo2 = (sonBulletEntity as BulletEntity).GetBulletInfo();
			if (bulletInfo2.BulletDataMain.Render.HandOverParentEffect)
			{
				BulletStaticFunction.HandOverEffects(bulletInfo, bulletInfo2);
			}
		}
	}

	// Token: 0x06017AB7 RID: 96951 RVA: 0x0069B109 File Offset: 0x00699309
	public static void FrozenBulletTime(BulletInfo bulletInfo, float time)
	{
		bulletInfo.FrozenTime = new float?(time * (float)Singleton<TimeUtil>.Instance.InverseMillisecond);
		BulletUtil.BulletFrozen(bulletInfo);
	}

	// Token: 0x06017AB8 RID: 96952 RVA: 0x0069B12C File Offset: 0x0069932C
	public static void BulletFrozen(BulletInfo bulletInfo)
	{
		bulletInfo.IsFrozen = true;
		BulletActorComponent actorComponent = bulletInfo.ActorComponent;
		if (actorComponent != null)
		{
			actorComponent.SetBulletCustomTimeDilation(0f);
			BulletStaticFunction.SetBulletEffectTimeScale(bulletInfo.EffectInfo, 0.0, false);
		}
	}

	// Token: 0x06017AB9 RID: 96953 RVA: 0x0069B16C File Offset: 0x0069936C
	public static void BulletUnfrozen(BulletInfo bulletInfo)
	{
		bulletInfo.IsFrozen = false;
		BulletActorComponent actorComponent = bulletInfo.ActorComponent;
		Entity attacker = bulletInfo.Attacker;
		float? num;
		if (attacker == null)
		{
			num = null;
		}
		else
		{
			PawnTimeScaleComponent component = attacker.GetComponent<PawnTimeScaleComponent>();
			num = ((component != null) ? new float?(component.GetTopForeverTimeScale(new ESourceEffectGroup?(ESourceEffectGroup.LogicAndView))) : null);
		}
		float bulletCustomTimeDilation = num ?? ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation;
		actorComponent.SetBulletCustomTimeDilation(bulletCustomTimeDilation);
		BulletStaticFunction.SetBulletEffectTimeScale(bulletInfo.EffectInfo, 1.0, false);
	}

	// Token: 0x06017ABA RID: 96954 RVA: 0x0069B1F8 File Offset: 0x006993F8
	[NullableContext(2)]
	public static void FrozenCharacterBullet(int entityId, string bulletRowName = null, float time = 0f)
	{
		IReadOnlyCollection<BulletEntity> bulletSetByAttacker = ModelBase<BulletModel>.Instance.GetBulletSetByAttacker(entityId);
		if (bulletSetByAttacker == null)
		{
			return;
		}
		foreach (BulletEntity bulletEntity in bulletSetByAttacker)
		{
			BulletInfo bulletInfo = bulletEntity.GetBulletInfo();
			if (StringUtils.IsEmpty(bulletRowName) || bulletInfo.BulletDataMain.BulletName == bulletRowName)
			{
				BulletUtil.FrozenBulletTime(bulletInfo, time);
			}
		}
	}

	// Token: 0x06017ABB RID: 96955 RVA: 0x0069B270 File Offset: 0x00699470
	[NullableContext(2)]
	public static void UnFrozenCharacterBullet(int entityId, string bulletRowName = null)
	{
		IReadOnlyCollection<BulletEntity> bulletSetByAttacker = ModelBase<BulletModel>.Instance.GetBulletSetByAttacker(entityId);
		if (bulletSetByAttacker == null)
		{
			return;
		}
		foreach (BulletEntity bulletEntity in bulletSetByAttacker)
		{
			BulletInfo bulletInfo = bulletEntity.GetBulletInfo();
			if (StringUtils.IsEmpty(bulletRowName) || bulletInfo.BulletDataMain.BulletName == bulletRowName)
			{
				BulletUtil.BulletUnfrozen(bulletInfo);
			}
		}
	}

	// Token: 0x06017ABC RID: 96956 RVA: 0x0069B2E8 File Offset: 0x006994E8
	public static void SetCharacterBulletTimeScale(int entityId, float timeScale, Dictionary<int, int> handleMap, ETimeScaleSourceType sourceType = ETimeScaleSourceType.InnerPauseLock)
	{
		IReadOnlyCollection<BulletEntity> bulletSetByAttacker = ModelBase<BulletModel>.Instance.GetBulletSetByAttacker(entityId);
		if (bulletSetByAttacker == null)
		{
			return;
		}
		HashSet<int> hashSet = new HashSet<int>();
		foreach (BulletEntity bulletEntity in bulletSetByAttacker)
		{
			BulletInfo bulletInfo = bulletEntity.GetBulletInfo();
			int id = bulletEntity.Id;
			hashSet.Add(id);
			if (!bulletInfo.IsFrozen && !handleMap.ContainsKey(id) && bulletInfo.TimeScaleList != null && bulletInfo.TimeScaleMap != null)
			{
				int num = BulletUtil.SetTimeScale(bulletInfo, int.MaxValue, timeScale, null, float.PositiveInfinity, sourceType, 0.0, 0);
				if (num > 0)
				{
					handleMap[id] = num;
				}
			}
		}
		List<int> list = new List<int>();
		foreach (int item in handleMap.Keys)
		{
			if (!hashSet.Contains(item))
			{
				list.Add(item);
			}
		}
		foreach (int key in list)
		{
			handleMap.Remove(key);
		}
	}

	// Token: 0x06017ABD RID: 96957 RVA: 0x0069B440 File Offset: 0x00699640
	public static void RemoveCharacterBulletTimeScale(int entityId, Dictionary<int, int> handleMap)
	{
		IReadOnlyCollection<BulletEntity> bulletSetByAttacker = ModelBase<BulletModel>.Instance.GetBulletSetByAttacker(entityId);
		if (bulletSetByAttacker != null)
		{
			foreach (BulletEntity bulletEntity in bulletSetByAttacker)
			{
				BulletInfo bulletInfo = bulletEntity.GetBulletInfo();
				int id = bulletEntity.Id;
				int id2;
				if (handleMap.TryGetValue(id, out id2) && bulletInfo.TimeScaleMap != null)
				{
					BulletUtil.RemoveTimeScale(bulletInfo, id2);
				}
			}
		}
		handleMap.Clear();
	}

	// Token: 0x06017ABE RID: 96958 RVA: 0x0069B4C0 File Offset: 0x006996C0
	public static int SetTimeScale(BulletInfo bulletInfo, int priority, float timeDilation, [Nullable(2)] UCurveFloat curve, float duration, ETimeScaleSourceType sourceType, double elapsedTime = 0.0, int timeScaleId = 0)
	{
		if (duration <= 0f || bulletInfo.BulletDataMain.TimeScale.TimeScaleWithAttacker)
		{
			return 0;
		}
		if (elapsedTime > 0.0 && elapsedTime >= (double)duration)
		{
			return 0;
		}
		double num = Singleton<Time>.Instance.WorldTimeSeconds - elapsedTime;
		double endTime = num + (double)duration;
		int num2 = timeScaleId;
		if (timeScaleId >= 0)
		{
			bulletInfo.TimeScaleId++;
			num2 = bulletInfo.TimeScaleId;
		}
		TimeScale timeScale = new TimeScale(num, endTime, priority, timeDilation, curve, duration, num2, sourceType, PawnTimeScaleComponent.getSourceGroup(sourceType), false, false);
		bulletInfo.TimeScaleList.Push(timeScale);
		bulletInfo.TimeScaleMap.Add(num2, timeScale);
		return num2;
	}

	// Token: 0x06017ABF RID: 96959 RVA: 0x0069B564 File Offset: 0x00699764
	public static void RemoveTimeScale(BulletInfo bulletInfo, int id)
	{
		TimeScale timeScale;
		if (bulletInfo.TimeScaleMap.TryGetValue(id, out timeScale))
		{
			timeScale.MarkDelete = true;
		}
	}

	// Token: 0x06017AC0 RID: 96960 RVA: 0x0069B588 File Offset: 0x00699788
	public static void SetVictimTimeScale(int bulletEntityId, int victimEntityId, PawnTimeScaleComponent victimTimeScaleComp, int priority, float timeDilation, [Nullable(2)] UCurveFloat curve, float duration, ETimeScaleSourceType sourceType, bool removeHitTimeScaleOnDestroy, bool needAddSceneItemTag = false)
	{
		if (duration <= 0f)
		{
			return;
		}
		int num = victimTimeScaleComp.SetTimeScale(priority, timeDilation, curve, duration, sourceType, needAddSceneItemTag, true);
		if (removeHitTimeScaleOnDestroy && num > 0)
		{
			BulletEntity bulletEntity = Singleton<EntitySystem>.Instance.Get<BulletEntity>(bulletEntityId);
			BulletCollisionInfo bulletCollisionInfo = (bulletEntity != null) ? bulletEntity.GetBulletInfo().CollisionInfo : null;
			if (bulletCollisionInfo != null)
			{
				bulletCollisionInfo.HitTimeScaleEntityMap.Add(victimEntityId, num);
			}
		}
	}

	// Token: 0x06017AC1 RID: 96961 RVA: 0x0069B5E8 File Offset: 0x006997E8
	public static bool GetHitRotator(BulletInfo bulletInfo, BaseActorComponent victimActorComp, global::Rotator outRotator)
	{
		outRotator.FromUeRotator(victimActorComp.ActorRotationProxy);
		global::EBulletRelativeDir relativeDirection = bulletInfo.BulletDataMain.Base.RelativeDirection;
		if (relativeDirection == global::EBulletRelativeDir.None)
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = victimActorComp as CharacterActorComponent;
		if (characterActorComponent != null)
		{
			BaseTagComponent component = characterActorComponent.Entity.GetComponent<BaseTagComponent>();
			if (component != null && component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.水中"]))
			{
				return false;
			}
		}
		BaseActorComponent attackerActorComp = bulletInfo.AttackerActorComp;
		global::Vector vector = global::Vector.Create();
		switch (relativeDirection)
		{
		case global::EBulletRelativeDir.Owner:
			vector.FromUeVector(attackerActorComp.ActorLocationProxy);
			vector.SubtractionEqual(victimActorComp.ActorLocationProxy);
			Singleton<MathUtils>.Instance.LookRotationUpFirst(vector, victimActorComp.ActorUpProxy, outRotator);
			break;
		case global::EBulletRelativeDir.BulletCenter:
			vector.FromUeVector(bulletInfo.ActorComponent.ActorLocationProxy);
			vector.SubtractionEqual(victimActorComp.ActorLocationProxy);
			Singleton<MathUtils>.Instance.LookRotationUpFirst(vector, victimActorComp.ActorUpProxy, outRotator);
			break;
		case global::EBulletRelativeDir.BulletForward:
		{
			CharacterMoveComponent attackerMoveComp = bulletInfo.AttackerMoveComp;
			bool flag = attackerMoveComp == null || attackerMoveComp.IsStandardGravity;
			if (bulletInfo.MoveInfo.BulletSpeedDir.Equals(global::Vector.ZeroVectorProxy, 9.999999747378752E-05))
			{
				if (flag)
				{
					global::Vector vector2 = vector;
					FVectorDouble actorForward = bulletInfo.ActorComponent.ActorForward;
					vector2.FromUeVector(actorForward);
					vector.Z = 0.0;
					vector.MultiplyEqual(-1.0);
				}
				else
				{
					global::Vector.VectorPlaneProject(bulletInfo.ActorComponent.ActorForwardProxy, bulletInfo.AttackerMoveComp.GravityUp, vector);
					vector.MultiplyEqual(-1.0);
				}
				Singleton<MathUtils>.Instance.LookRotationUpFirst(vector, victimActorComp.ActorUpProxy, outRotator);
			}
			else
			{
				if (flag)
				{
					vector.Set(-bulletInfo.MoveInfo.BulletSpeedDir.X, -bulletInfo.MoveInfo.BulletSpeedDir.Y, 0.0);
				}
				else
				{
					global::Vector.VectorPlaneProject(bulletInfo.MoveInfo.BulletSpeedDir, bulletInfo.AttackerMoveComp.GravityUp, vector);
					vector.MultiplyEqual(-1.0);
				}
				Singleton<MathUtils>.Instance.LookRotationUpFirst(vector, victimActorComp.ActorUpProxy, outRotator);
			}
			break;
		}
		case global::EBulletRelativeDir.BulletCenterRelative:
			if (SpaceUtils.IsLocationInSideBullet(bulletInfo, victimActorComp.ActorLocationProxy))
			{
				vector.FromUeVector(victimActorComp.ActorLocationProxy);
				vector.SubtractionEqual(bulletInfo.ActorComponent.ActorLocationProxy);
				Singleton<MathUtils>.Instance.LookRotationUpFirst(vector, victimActorComp.ActorUpProxy, outRotator);
			}
			else
			{
				vector.FromUeVector(bulletInfo.ActorComponent.ActorLocationProxy);
				vector.SubtractionEqual(victimActorComp.ActorLocationProxy);
				Singleton<MathUtils>.Instance.LookRotationUpFirst(vector, victimActorComp.ActorUpProxy, outRotator);
			}
			break;
		}
		return true;
	}

	// Token: 0x06017AC2 RID: 96962 RVA: 0x0069B878 File Offset: 0x00699A78
	public static FRotator SetHitRotator(BulletInfo bulletInfo, BaseActorComponent victimActorComp, float yawOffset)
	{
		if (!BulletUtil.GetHitRotator(bulletInfo, victimActorComp, BulletUtil.TmpRotator))
		{
			return BulletUtil.TmpRotator.ToUeRotator();
		}
		BaseTagComponent component = victimActorComp.Entity.GetComponent<BaseTagComponent>();
		if (component != null && component.HasTag(GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.霸体"]))
		{
			return BulletUtil.TmpRotator.ToUeRotator();
		}
		BulletUtil.TmpRotator2.Set(0f, yawOffset, 0f);
		BulletUtil.TmpRotator.Quaternion(BulletUtil.TmpQuat);
		BulletUtil.TmpRotator2.Quaternion(BulletUtil.TmpQuat2);
		BulletUtil.TmpQuat.Multiply(BulletUtil.TmpQuat2, BulletUtil.TmpQuat);
		BulletUtil.TmpQuat.Rotator(BulletUtil.TmpRotator);
		victimActorComp.SetActorRotation(BulletUtil.TmpRotator.ToUeRotator(), "BulletUtil", false);
		CharacterActorComponent characterActorComponent = victimActorComp as CharacterActorComponent;
		if (characterActorComponent != null)
		{
			characterActorComponent.SetInputRotator(BulletUtil.TmpRotator);
		}
		return BulletUtil.TmpRotator.ToUeRotator();
	}

	// Token: 0x06017AC3 RID: 96963 RVA: 0x0069B960 File Offset: 0x00699B60
	public static EHitAnim? GetOverrideHitAnimByAngle(BaseActorComponent victimActorComp, EHitAnim? origHitAnim, float damageFromYaw)
	{
		EHitAnim? result = origHitAnim;
		bool flag = victimActorComp is SceneItemActorComponent;
		BulletModel instance = ModelBase<BulletModel>.Instance;
		bool flag2 = result != null && instance.SelfAdaptBeHitAnim.Contains(result.Value);
		if (flag2 || flag)
		{
			float yaw = victimActorComp.ActorRotationProxy.Yaw;
			int num = (int)Math.Floor((double)(((damageFromYaw - 180f - yaw + 45f) % 360f + 360f) % 360f / 90f));
			if (flag2)
			{
				if (instance.HeavyHitAnim.Contains(result.Value))
				{
					result = new EHitAnim?(instance.Index2HeavyHitAnimMap[num]);
				}
				else
				{
					result = new EHitAnim?(instance.Index2LightHitAnimMap[num]);
				}
			}
			else if (flag)
			{
				result = new EHitAnim?(instance.Index2HeavyHitAnimMap[num]);
			}
		}
		return result;
	}

	// Token: 0x06017AC4 RID: 96964 RVA: 0x0069BA34 File Offset: 0x00699C34
	public static bool CheckBulletAttackerExist(BulletInfo bulletInfo)
	{
		EntityHandle attackerHandle = bulletInfo.AttackerHandle;
		if (attackerHandle == null || !attackerHandle.Valid)
		{
			return false;
		}
		CreatureDataComponent attackerCreatureDataComp = bulletInfo.AttackerCreatureDataComp;
		long? num = (attackerCreatureDataComp != null) ? new long?(attackerCreatureDataComp.GetCreatureDataId()) : null;
		if (num != null)
		{
			long? num2 = num;
			BulletModel instance = ModelBase<BulletModel>.Instance;
			long? num3 = (instance != null) ? new long?(instance.SceneBulletOwnerId) : null;
			if (num2.GetValueOrDefault() == num3.GetValueOrDefault() & num2 != null == (num3 != null))
			{
				return true;
			}
		}
		BaseActorComponent attackerActorComp = bulletInfo.AttackerActorComp;
		return ((attackerActorComp != null) ? attackerActorComp.Owner : null) != null;
	}

	// Token: 0x06017AC5 RID: 96965 RVA: 0x0069BAE0 File Offset: 0x00699CE0
	public static FRotator FindLookAtRotDouble(global::Vector start, FVectorDouble end, bool keepUp, FVectorDouble upVector)
	{
		global::Vector vector = BulletPool.CreateVector(false);
		vector.FromUeVector(end);
		global::Vector vector2 = BulletPool.CreateVector(false);
		vector2.FromUeVector(start);
		vector.SubtractionEqual(vector2);
		FVectorDouble fvectorDouble;
		if (keepUp)
		{
			fvectorDouble = vector.ToUeVector(false);
			FRotator result = UKismetMathLibrary.D_MakeRotFromZX(upVector, fvectorDouble);
			BulletPool.RecycleVector(vector);
			BulletPool.RecycleVector(vector2);
			return result;
		}
		vector.Normalize(9.99999993922529E-09);
		global::Vector vector3 = BulletPool.CreateVector(false);
		global::Vector vector4 = BulletPool.CreateVector(false);
		vector3.FromUeVector(upVector);
		global::Vector.CrossProduct(vector3, vector, vector4);
		vector4.Normalize(9.99999993922529E-09);
		global::Vector.CrossProduct(vector, vector4, vector3);
		fvectorDouble = vector3.ToUeVector(false);
		FVectorDouble fvectorDouble2 = vector.ToUeVector(false);
		FRotator result2 = UKismetMathLibrary.D_MakeRotFromZX(fvectorDouble, fvectorDouble2);
		BulletPool.RecycleVector(vector3);
		BulletPool.RecycleVector(vector4);
		BulletPool.RecycleVector(vector);
		BulletPool.RecycleVector(vector2);
		return result2;
	}

	// Token: 0x06017AC6 RID: 96966 RVA: 0x0069BBB0 File Offset: 0x00699DB0
	public static FRotator FindLookAtRotDoubleStandard(global::Vector start, FVectorDouble end, bool keepUp)
	{
		FVectorDouble fvectorDouble;
		if (keepUp)
		{
			global::Vector vector = BulletPool.CreateVector(false);
			vector.FromUeVector(end);
			global::Vector vector2 = BulletPool.CreateVector(false);
			vector2.FromUeVector(start);
			vector.SubtractionEqual(vector2);
			fvectorDouble = vector.ToUeVector(false);
			FRotator result = UKismetMathLibrary.D_MakeRotFromZX(global::Vector.UpVectorDouble, fvectorDouble);
			BulletPool.RecycleVector(vector);
			BulletPool.RecycleVector(vector2);
			return result;
		}
		fvectorDouble = start.ToUeVector(false);
		return UKismetMathLibrary.D_FindLookAtRotation(fvectorDouble, end);
	}

	// Token: 0x06017AC7 RID: 96967 RVA: 0x0069BC18 File Offset: 0x00699E18
	public static void ClampBeginRotator(BulletInfo bulletInfo)
	{
		Dictionary<EBulletBeginVelocityLimit, float> beginVelocityLimitMap = bulletInfo.BulletDataMain.Move.BeginVelocityLimitMap;
		if (beginVelocityLimitMap.Count <= 0)
		{
			return;
		}
		CharacterMoveComponent attackerMoveComp = bulletInfo.AttackerMoveComp;
		if (attackerMoveComp == null || attackerMoveComp.IsStandardGravity)
		{
			BulletUtil.ClampBeginRotatorStandard(bulletInfo);
			return;
		}
		bulletInfo.MoveInfo.BeginSpeedRotator.Vector(BulletUtil.TempClampVector);
		bulletInfo.AttackerActorComp.ActorQuatProxy.UnRotateVector(BulletUtil.TempClampVector, BulletUtil.TempClampVector);
		BulletUtil.TempClampVector.Rotation(BulletUtil.TempClampRotator);
		float num = -1f * beginVelocityLimitMap.GetValueOrDefault(EBulletBeginVelocityLimit.下角度范围, 90f);
		float valueOrDefault = beginVelocityLimitMap.GetValueOrDefault(EBulletBeginVelocityLimit.上角度范围, 90f);
		BulletUtil.TempClampRotator.Pitch = (float)Singleton<MathUtils>.Instance.ClampAngle((double)BulletUtil.TempClampRotator.Pitch, (double)num, (double)valueOrDefault);
		float num2 = -1f * beginVelocityLimitMap.GetValueOrDefault(EBulletBeginVelocityLimit.左角度范围, 90f);
		float valueOrDefault2 = beginVelocityLimitMap.GetValueOrDefault(EBulletBeginVelocityLimit.右下角度范围, 90f);
		BulletUtil.TempClampRotator.Yaw = (float)Singleton<MathUtils>.Instance.ClampAngle((double)BulletUtil.TempClampRotator.Yaw, (double)num2, (double)valueOrDefault2);
		BulletUtil.TempClampRotator.Vector(BulletUtil.TempClampVector);
		bulletInfo.AttackerActorComp.ActorQuatProxy.RotateVector(BulletUtil.TempClampVector, BulletUtil.TempClampVector);
		BulletUtil.TempClampVector.Rotation(bulletInfo.MoveInfo.BeginSpeedRotator);
	}

	// Token: 0x06017AC8 RID: 96968 RVA: 0x0069BD64 File Offset: 0x00699F64
	private static void ClampBeginRotatorStandard(BulletInfo bulletInfo)
	{
		Dictionary<EBulletBeginVelocityLimit, float> beginVelocityLimitMap = bulletInfo.BulletDataMain.Move.BeginVelocityLimitMap;
		if (beginVelocityLimitMap.Count <= 0)
		{
			return;
		}
		global::Rotator rotator = BulletPool.CreateRotator(false);
		rotator.FromUeRotator(bulletInfo.AttackerActorComp.ActorRotationProxy);
		global::Rotator rotator2 = BulletPool.CreateRotator(false);
		rotator2.FromUeRotator(bulletInfo.MoveInfo.BeginSpeedRotator);
		float num = 0.1f;
		float num2;
		if (!beginVelocityLimitMap.TryGetValue(EBulletBeginVelocityLimit.上角度范围, out num2))
		{
			num2 = 180f - num;
		}
		float num3;
		if (!beginVelocityLimitMap.TryGetValue(EBulletBeginVelocityLimit.下角度范围, out num3))
		{
			num3 = 180f - num;
		}
		bulletInfo.MoveInfo.BeginSpeedRotator.Pitch = (float)Singleton<MathUtils>.Instance.ClampAngle((double)rotator2.Pitch, (double)(rotator.Pitch - num3), (double)(rotator.Pitch + num2));
		float num4;
		if (!beginVelocityLimitMap.TryGetValue(EBulletBeginVelocityLimit.右下角度范围, out num4))
		{
			num4 = 180f - num;
		}
		float num5;
		if (!beginVelocityLimitMap.TryGetValue(EBulletBeginVelocityLimit.左角度范围, out num5))
		{
			num5 = 180f - num;
		}
		bulletInfo.MoveInfo.BeginSpeedRotator.Yaw = (float)Singleton<MathUtils>.Instance.ClampAngle((double)rotator2.Yaw, (double)(rotator.Yaw - num5), (double)(rotator.Yaw + num4));
		bool openMoveLog = Singleton<BulletConstant>.Instance.OpenMoveLog;
		bulletInfo.MoveInfo.BeginSpeedRotator.Roll = 0f;
		BulletPool.RecycleRotator(rotator);
		BulletPool.RecycleRotator(rotator2);
	}

	// Token: 0x06017AC9 RID: 96969 RVA: 0x0069BEAC File Offset: 0x0069A0AC
	[NullableContext(2)]
	public static long? GetSkillContextId(Entity owner, int skillId)
	{
		BaseSkillComponent baseSkillComponent = (owner != null) ? owner.GetComponent<BaseSkillComponent>() : null;
		if (baseSkillComponent == null)
		{
			return null;
		}
		long? num;
		if (baseSkillComponent == null)
		{
			num = null;
		}
		else
		{
			Skill skill = baseSkillComponent.GetSkill(skillId);
			num = ((skill != null) ? skill.CombatMessageId : null);
		}
		long? result = num;
		if (result == null && baseSkillComponent != null)
		{
			Entity entity = baseSkillComponent.Entity;
			bool flag;
			if (entity == null)
			{
				flag = false;
			}
			else
			{
				int id = entity.Id;
				flag = true;
			}
			if (flag)
			{
				EntitySystem instance = Singleton<EntitySystem>.Instance;
				int? num2;
				if (baseSkillComponent == null)
				{
					num2 = null;
				}
				else
				{
					Entity entity2 = baseSkillComponent.Entity;
					num2 = ((entity2 != null) ? new int?(entity2.Id) : null);
				}
				int? num3 = num2;
				long summonerId = instance.GetComponent<CreatureDataComponent>(num3.GetValueOrDefault()).GetSummonerId();
				if (summonerId > 0L)
				{
					EntityHandle entity3 = ModelBase<CreatureModel>.Instance.GetEntity(summonerId);
					WorldEntity worldEntity = (entity3 != null) ? entity3.Entity : null;
					BaseSkillComponent baseSkillComponent2 = (worldEntity != null) ? worldEntity.GetComponent<BaseSkillComponent>() : null;
					long? num4;
					if (baseSkillComponent2 == null)
					{
						num4 = null;
					}
					else
					{
						Skill skill2 = baseSkillComponent2.GetSkill(skillId);
						num4 = ((skill2 != null) ? skill2.CombatMessageId : null);
					}
					result = num4;
				}
				else
				{
					EntityHandle summonedEntity = PhantomUtil.GetSummonedEntity((baseSkillComponent != null) ? baseSkillComponent.Entity : null, ESummonType.ConcomitantCustom, 1);
					WorldEntity worldEntity2 = (summonedEntity != null) ? summonedEntity.Entity : null;
					BaseSkillComponent baseSkillComponent3 = (worldEntity2 != null) ? worldEntity2.GetComponent<BaseSkillComponent>() : null;
					long? num5;
					if (baseSkillComponent3 == null)
					{
						num5 = null;
					}
					else
					{
						Skill skill3 = baseSkillComponent3.GetSkill(skillId);
						num5 = ((skill3 != null) ? skill3.CombatMessageId : null);
					}
					result = num5;
				}
			}
		}
		return result;
	}

	// Token: 0x06017ACA RID: 96970 RVA: 0x0069C01C File Offset: 0x0069A21C
	public static int CreateBulletFromAN(Entity owner, string bulletRowName, FTransformDouble? initialTransform, int skillId, bool needSync, long? preContextId, FVectorDouble? targetLocation = null, FVector? locationOffset = null, FRotator? beginRotatorOffset = null)
	{
		return BulletUtil.CreateBulletFromANInternal(owner, bulletRowName, initialTransform, skillId, needSync, preContextId, targetLocation, locationOffset, beginRotatorOffset);
	}

	// Token: 0x06017ACB RID: 96971 RVA: 0x0069C03C File Offset: 0x0069A23C
	public static int CreateBulletFromAN(TsBaseCharacter owner, string bulletRowName, FTransformDouble? initialTransform, int skillId, bool needSync, long? preContextId, FVectorDouble? targetLocation = null, FVector? locationOffset = null, FRotator? beginRotatorOffset = null)
	{
		return BulletUtil.CreateBulletFromANInternal(owner.GetEntityNoBlueprint(), bulletRowName, initialTransform, skillId, needSync, preContextId, targetLocation, locationOffset, beginRotatorOffset);
	}

	// Token: 0x06017ACC RID: 96972 RVA: 0x0069C064 File Offset: 0x0069A264
	private static int CreateBulletFromANInternal(Entity owner, string bulletRowName, FTransformDouble? initialTransform, int skillId, bool needSync, long? preContextId, FVectorDouble? targetLocation = null, FVector? locationOffset = null, FRotator? beginRotatorOffset = null)
	{
		long? skillContextId = BulletUtil.GetSkillContextId(owner, skillId);
		BulletController.BulletCreateParams bulletCreateParams = new BulletController.BulletCreateParams();
		bulletCreateParams.SkillId = skillId;
		bulletCreateParams.SkillContextId = new long?(skillContextId.GetValueOrDefault());
		bulletCreateParams.SyncType = (needSync ? global::EBulletSyncType.SyncCreate : global::EBulletSyncType.Local);
		bulletCreateParams.InitTargetLocation = targetLocation;
		bulletCreateParams.LocationOffset = locationOffset;
		bulletCreateParams.BeginRotatorOffset = beginRotatorOffset;
		ISkillBattleContext battleContext;
		if (owner == null)
		{
			battleContext = null;
		}
		else
		{
			BaseSkillComponent component = owner.GetComponent<BaseSkillComponent>();
			if (component == null)
			{
				battleContext = null;
			}
			else
			{
				Skill skill = component.GetSkill(skillId);
				battleContext = ((skill != null) ? skill.BattleContext : null);
			}
		}
		bulletCreateParams.BattleContext = battleContext;
		BulletController.BulletCreateParams bulletCreateParams2 = bulletCreateParams;
		BulletEntity bulletEntity = ControllerBase<BulletController>.Instance.CreateBulletCustomTarget(owner, bulletRowName, initialTransform, bulletCreateParams2, preContextId, global::EBulletCreateSource.Skill);
		if (bulletEntity == null)
		{
			return 0;
		}
		return bulletEntity.Id;
	}

	// Token: 0x06017ACD RID: 96973 RVA: 0x0069C108 File Offset: 0x0069A308
	public static int SpawnPatternFromAN(Entity ownerEntity, UKuroBulletPatternDataAsset patternData, int skillId, long? preContextId, string assetPath)
	{
		FWorldEntityBulletParam fworldEntityBulletParam = new FWorldEntityBulletParam();
		if (preContextId != null)
		{
			BulletModel instance = ModelBase<BulletModel>.Instance;
			int num = instance.PatternHandleIdGen + 1;
			instance.PatternHandleIdGen = num;
			int num2 = num;
			int num3;
			if (!BulletUtil.PatternIdMap.TryGetValue(assetPath, out num3))
			{
				num3 = UGASBPLibrary.FnvHash(assetPath);
				BulletUtil.PatternIdMap[assetPath] = num3;
			}
			long num4 = ModelBase<CombatMessageModel>.Instance.GenMessageId();
			BulletPatternPush bulletPatternPush = BulletPatternPush.Create();
			bulletPatternPush.BulletPatternHandleId = (long)num2;
			bulletPatternPush.BulletPatternId = num3;
			Singleton<CombatNet>.Instance.Send(EPushMessageId.BulletPatternPush, ownerEntity, bulletPatternPush, new long?(preContextId.Value), new long?(num4), null);
			fworldEntityBulletParam.MessageId = num4;
		}
		else
		{
			Singleton<Log>.Instance.Error(ELogModule.Bullet, ELogAuthor.CFT, "SpawnPatternFromAN 缺少上下文", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		fworldEntityBulletParam.SkillId = skillId;
		long? skillContextId = BulletUtil.GetSkillContextId(ownerEntity, skillId);
		if (skillContextId != null)
		{
			fworldEntityBulletParam.SkillMessageId = skillContextId.Value;
		}
		return ControllerBase<BulletController>.Instance.SpawnPattern(ownerEntity, patternData, fworldEntityBulletParam);
	}

	// Token: 0x06017ACE RID: 96974 RVA: 0x0069C212 File Offset: 0x0069A412
	public static void DestroyPatternById(int patternId)
	{
		ControllerBase<BulletController>.Instance.DestroyPatternById(patternId);
	}

	// Token: 0x06017ACF RID: 96975 RVA: 0x0069C220 File Offset: 0x0069A420
	public unsafe static bool AttachParentEffectSkeleton(BulletInfo bulletInfo, AActor effectActor, int effectId)
	{
		BulletDataMove move = bulletInfo.BulletDataMain.Move;
		if (move.IsLockScale)
		{
			bulletInfo.Actor.RootComponent.SetAbsolute(false, false, true);
		}
		bulletInfo.ClearCacheLocationAndRotation();
		bulletInfo.ActorComponent.ResetAllCachedTime();
		bulletInfo.ActorComponent.NeedDetach = true;
		EffectSystem instance = Singleton<EffectSystem>.Instance;
		AActor actor = bulletInfo.Actor;
		FName? fname = new FName?(move.BoneName);
		instance.AttachToEffectSkeletalMesh(effectId, actor, fname, EAttachmentRule.KeepRelative);
		if (Singleton<BulletConstant>.Instance.OpenMoveLog)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Bullet;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "BulletUtil.AttachParentEffectSkeleton";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Bullet", bulletInfo.BulletRowName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("NeedDetach", bulletInfo.ActorComponent.NeedDetach);
			instance2.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		FHitResult fhitResult = null;
		bulletInfo.Actor.D_K2_SetActorRelativeLocation(bulletInfo.BornLocationOffset.ToUeVector(false), false, ref fhitResult, false);
		FHitResult fhitResult2 = null;
		bulletInfo.Actor.K2_SetActorRelativeRotation(global::Rotator.ZeroRotator, false, ref fhitResult2, true);
		return true;
	}

	// Token: 0x06017AD0 RID: 96976 RVA: 0x0069C33C File Offset: 0x0069A53C
	public static void AroundBulletAxisAndBeginVector(global::Vector traceParam0, global::Vector traceParam1, global::Vector roundAxis, global::Vector beginVector, [Nullable(2)] BaseActorComponent actorComp = null, [Nullable(2)] global::Vector gravityUp = null)
	{
		if (actorComp != null)
		{
			global::Vector vector = BulletPool.CreateVector(false);
			if (traceParam1.X > 0.0)
			{
				vector.Set(Math.Cos(traceParam0.Z * 0.01745329238474369), 0.0, Math.Sin(traceParam0.Z * 0.01745329238474369));
				actorComp.ActorQuatProxy.RotateVector(vector, roundAxis);
				beginVector.FromUeVector(actorComp.ActorRightProxy);
			}
			else if (traceParam1.Y > 0.0)
			{
				vector.Set(Math.Sin(traceParam0.Z * 0.01745329238474369), Math.Cos(traceParam0.Z * 0.01745329238474369), 0.0);
				actorComp.ActorQuatProxy.RotateVector(vector, roundAxis);
				beginVector.FromUeVector(actorComp.ActorUpProxy);
			}
			else
			{
				vector.Set(0.0, Math.Sin(traceParam0.Z * 0.01745329238474369), Math.Cos(traceParam0.Z * 0.01745329238474369));
				actorComp.ActorQuatProxy.RotateVector(vector, roundAxis);
				beginVector.FromUeVector(actorComp.ActorForwardProxy);
			}
			BulletPool.RecycleVector(vector);
			return;
		}
		if (gravityUp != null)
		{
			double z = traceParam0.Z;
			if (traceParam1.X > 0.0)
			{
				global::Vector.Lerp(global::Vector.ForwardVectorProxy, gravityUp, (double)((float)Singleton<MathUtils>.Instance.Clamp(z, 0.0, 180.0)), roundAxis);
				gravityUp.CrossProduct(global::Vector.ForwardVectorProxy, beginVector);
				return;
			}
			if (traceParam1.Y > 0.0)
			{
				global::Vector vector2 = BulletPool.CreateVector(false);
				gravityUp.CrossProduct(global::Vector.ForwardVectorProxy, vector2);
				global::Vector.Lerp(vector2, global::Vector.ForwardVectorProxy, (double)((float)Singleton<MathUtils>.Instance.Clamp(z, 0.0, 180.0)), roundAxis);
				BulletPool.RecycleVector(vector2);
				beginVector.FromUeVector(gravityUp);
				return;
			}
			global::Vector vector3 = BulletPool.CreateVector(false);
			gravityUp.CrossProduct(global::Vector.ForwardVectorProxy, vector3);
			global::Vector.Lerp(gravityUp, vector3, (double)((float)Singleton<MathUtils>.Instance.Clamp(z, 0.0, 180.0)), roundAxis);
			BulletPool.RecycleVector(vector3);
			beginVector.FromUeVector(global::Vector.ForwardVectorProxy);
			return;
		}
		else
		{
			if (traceParam1.X > 0.0)
			{
				roundAxis.Set(Math.Cos(traceParam0.Z * 0.01745329238474369), 0.0, Math.Sin(traceParam0.Z * 0.01745329238474369));
				beginVector.FromUeVector(global::Vector.RightVectorProxy);
				return;
			}
			if (traceParam1.Y > 0.0)
			{
				roundAxis.Set(Math.Sin(traceParam0.Z * 0.01745329238474369), Math.Cos(traceParam0.Z * 0.01745329238474369), 0.0);
				beginVector.FromUeVector(global::Vector.UpVectorProxy);
				return;
			}
			roundAxis.Set(0.0, Math.Sin(traceParam0.Z * 0.01745329238474369), Math.Cos(traceParam0.Z * 0.01745329238474369));
			beginVector.FromUeVector(global::Vector.ForwardVectorProxy);
			return;
		}
	}

	// Token: 0x06017AD1 RID: 96977 RVA: 0x0069C67C File Offset: 0x0069A87C
	public static bool TagStackCountCondition(int stackCount, string stackCountConditionConf)
	{
		string[] array = (from v in stackCountConditionConf.Split('#', StringSplitOptions.None)
		select v.Trim()).ToArray<string>();
		if (array.Length != 2)
		{
			Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.HCW, "子弹数组Tag条件 格式错误! 参数需要2个!", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		int num;
		if (!int.TryParse(array[1], out num))
		{
			Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.HCW, "子弹数组Tag条件 格式错误! 参数需要是数字!", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		string a = array[0];
		if (a == ">")
		{
			return stackCount > num;
		}
		if (a == ">=")
		{
			return stackCount >= num;
		}
		if (a == "<")
		{
			return stackCount < num;
		}
		if (a == "<=")
		{
			return stackCount <= num;
		}
		if (a == "==")
		{
			return stackCount == num;
		}
		if (!(a == "!="))
		{
			Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.HCW, "子弹数组Tag条件 格式错误! 不支持的操作符!", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		return stackCount != num;
	}

	// Token: 0x06017AD2 RID: 96978 RVA: 0x0069C7A2 File Offset: 0x0069A9A2
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public static HashSet<string> CollectParentsId(BulletInfo bulletInfo)
	{
		return null;
	}

	// Token: 0x0400B695 RID: 46741
	private const float QUARTER_PI_DEGREE = 45f;

	// Token: 0x0400B696 RID: 46742
	[StaticVariableRuleIgnore]
	protected static global::Rotator TmpRotator = global::Rotator.Create();

	// Token: 0x0400B697 RID: 46743
	[StaticVariableRuleIgnore]
	protected static global::Rotator TmpRotator2 = global::Rotator.Create();

	// Token: 0x0400B698 RID: 46744
	[StaticVariableRuleIgnore]
	protected static Quat TmpQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400B699 RID: 46745
	[StaticVariableRuleIgnore]
	protected static Quat TmpQuat2 = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400B69A RID: 46746
	[StaticVariableRuleIgnore]
	protected static global::Vector TmpVector = global::Vector.Create();

	// Token: 0x0400B69B RID: 46747
	[StaticVariableRuleIgnore]
	private static readonly global::Vector TempClampVector = global::Vector.Create();

	// Token: 0x0400B69C RID: 46748
	[StaticVariableRuleIgnore]
	private static readonly global::Rotator TempClampRotator = global::Rotator.Create();

	// Token: 0x0400B69D RID: 46749
	[StaticVariableRuleIgnore]
	private static readonly Dictionary<string, int> PatternIdMap = new Dictionary<string, int>();
}
