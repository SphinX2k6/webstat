using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.Protocol.Summon;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using CSharpScript.Game.NewWorld.SceneItem.RefCompController;
using UnrealEngine;

// Token: 0x0200312C RID: 12588
[NullableContext(1)]
[Nullable(0)]
public class SkillBehaviorAction
{
	// Token: 0x0601A111 RID: 106769 RVA: 0x007A3F6C File Offset: 0x007A216C
	public static void BeginGroup(TArray<SSkillBehaviorAction> skillBehaviorActionGroup, IBeginSkillBehaviorActionParam param)
	{
		if (!param.Entity.GetComponent<CharacterActorComponent>().IsAutonomousProxy)
		{
			return;
		}
		for (int i = 0; i < skillBehaviorActionGroup.Num(); i++)
		{
			SkillBehaviorAction.Begin(skillBehaviorActionGroup.Get(i), param);
		}
	}

	// Token: 0x0601A112 RID: 106770 RVA: 0x007A3FAC File Offset: 0x007A21AC
	public unsafe static void Begin(SSkillBehaviorAction skillBehaviorAction, IBeginSkillBehaviorActionParam param)
	{
		CombatLog.ELogType logType = CombatLog.ELogType.Debug;
		ESkillLogType skillLogType = ESkillLogType.SkillBehavior;
		Entity entity = param.Entity;
		string message = "SkillBehaviorAction.Begin";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("技能Id", param.Skill.SkillId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("技能名", param.Skill.SkillName);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("技能行为", skillBehaviorAction.ActionType);
		SkillUtils.Log(logType, skillLogType, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		try
		{
			switch (skillBehaviorAction.ActionType)
			{
			case ESkillBehaviorActionType.设置位置:
				SkillBehaviorAction.SetLocation(skillBehaviorAction, param);
				break;
			case ESkillBehaviorActionType.设置朝向:
				SkillBehaviorAction.SetRotation(skillBehaviorAction, param);
				break;
			case ESkillBehaviorActionType.播放特效:
				SkillBehaviorAction.PlayEffect(skillBehaviorAction, param);
				break;
			case ESkillBehaviorActionType.创建子弹:
				SkillBehaviorAction.CreateBullet(skillBehaviorAction, param);
				break;
			case ESkillBehaviorActionType.镜头效果:
				SkillBehaviorAction.CameraModify(skillBehaviorAction, param);
				break;
			case ESkillBehaviorActionType.特写镜头:
				SkillBehaviorAction.CameraSequence(skillBehaviorAction, param);
				break;
			case ESkillBehaviorActionType.设置移动状态:
				SkillBehaviorAction.SetMovementMode(skillBehaviorAction, param);
				break;
			case ESkillBehaviorActionType.设置碰撞:
				SkillBehaviorAction.SetCollision(skillBehaviorAction, param);
				break;
			case ESkillBehaviorActionType.伴生物使用技能:
				SkillBehaviorAction.UseSummonSkill(skillBehaviorAction, param);
				break;
			case ESkillBehaviorActionType.Buff增删:
				SkillBehaviorAction.Buff(skillBehaviorAction, param);
				break;
			case ESkillBehaviorActionType.Tag增删:
				SkillBehaviorAction.Tag(skillBehaviorAction, param);
				break;
			case ESkillBehaviorActionType.退出脆弱:
				SkillBehaviorAction.ExitWeakTime(skillBehaviorAction, param);
				break;
			case ESkillBehaviorActionType.播放蒙太奇:
				SkillBehaviorAction.PlaySkillMontage(skillBehaviorAction, param);
				break;
			case ESkillBehaviorActionType.更新自定义数据:
				SkillBehaviorAction.UpdateCustomValue(skillBehaviorAction, param);
				break;
			case ESkillBehaviorActionType.批量生成子弹:
				SkillBehaviorAction.BatchCreate(param.Entity, skillBehaviorAction.CommonConf, param.Skill.SkillId);
				break;
			}
		}
		catch (Exception ex)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
			Entity entity2 = param.Entity;
			string message2 = "SkillBehaviorAction.Begin异常";
			Exception e = ex;
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("技能Id", param.Skill.SkillId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("技能名", param.Skill.SkillName);
			instance.ErrorWithStack(flag, entity2, message2, e, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		}
	}

	// Token: 0x0601A113 RID: 106771 RVA: 0x007A41C0 File Offset: 0x007A23C0
	private static void BatchCreate(Entity owner, TSoftObjectPtr<UPrimaryDataAsset> conf, int skillId)
	{
		SkillBehaviorBatchBulletTask.Create(owner, conf, skillId).StartAsync();
	}

	// Token: 0x0601A114 RID: 106772 RVA: 0x007A41D0 File Offset: 0x007A23D0
	public unsafe static void End(Skill skill)
	{
		List<EndSkillBehaviorParam> list;
		if (!SkillBehaviorMisc.ParamMap.TryGetValue(skill, out list) || list == null)
		{
			return;
		}
		foreach (EndSkillBehaviorParam endSkillBehaviorParam in list)
		{
			CombatLog.ELogType logType = CombatLog.ELogType.Debug;
			ESkillLogType skillLogType = ESkillLogType.SkillBehavior;
			Entity entity = endSkillBehaviorParam.Entity;
			string message = "SkillBehaviorAction.End";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("技能Id", skill.SkillId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("技能名", skill.SkillName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("技能行为", endSkillBehaviorParam.ActionType);
			SkillUtils.Log(logType, skillLogType, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			try
			{
				switch (endSkillBehaviorParam.ActionType)
				{
				case ESkillBehaviorActionType.播放特效:
				{
					CharacterGameplayCueComponent component = endSkillBehaviorParam.Entity.GetComponent<CharacterGameplayCueComponent>();
					if (endSkillBehaviorParam.GameplayCue != null)
					{
						component.RemoveCueByHandle(endSkillBehaviorParam.GameplayCue.Value);
					}
					break;
				}
				case ESkillBehaviorActionType.设置移动状态:
				{
					CharacterActorComponent component2 = endSkillBehaviorParam.Entity.GetComponent<CharacterActorComponent>();
					if (endSkillBehaviorParam.MovementMode != null)
					{
						component2.Actor.KuroSetMovementMode(new SetMovementModeInfo
						{
							Mode = endSkillBehaviorParam.MovementMode.Value,
							Context = "[SkillBehaviorAction.End]"
						});
					}
					break;
				}
				case ESkillBehaviorActionType.设置碰撞:
				{
					UCapsuleComponent capsuleComponent = endSkillBehaviorParam.Entity.GetComponent<CharacterActorComponent>().Actor.CapsuleComponent;
					if (capsuleComponent != null && endSkillBehaviorParam.CollisionChannel != null && endSkillBehaviorParam.CollisionResponse != null)
					{
						capsuleComponent.SetCollisionResponseToChannel(endSkillBehaviorParam.CollisionChannel.Value, endSkillBehaviorParam.CollisionResponse.Value);
					}
					break;
				}
				case ESkillBehaviorActionType.伴生物使用技能:
					if (endSkillBehaviorParam.SummonSkillComponent != null && endSkillBehaviorParam.SummonSkillId != null)
					{
						endSkillBehaviorParam.SummonSkillComponent.EndSkill(endSkillBehaviorParam.SummonSkillId.Value, "SkillBehaviorAction.End");
					}
					break;
				}
			}
			catch (Exception ex)
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
				Entity entity2 = endSkillBehaviorParam.Entity;
				string message2 = "SkillBehaviorAction.End异常";
				Exception e = ex;
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("技能Id", skill.SkillId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("技能名", skill.SkillName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("技能行为", endSkillBehaviorParam.ActionType);
				instance.ErrorWithStack(flag, entity2, message2, e, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			}
		}
		SkillBehaviorMisc.ParamMap.Remove(skill);
	}

	// Token: 0x0601A115 RID: 106773 RVA: 0x007A44C4 File Offset: 0x007A26C4
	public unsafe static FVectorDouble CalculateLocation(SSkillBehaviorAction action, IBeginSkillBehaviorActionParam param)
	{
		CharacterActorComponent component = param.Entity.GetComponent<CharacterActorComponent>();
		global::Vector vector = global::Vector.Create(component.ActorLocation);
		global::Vector vector2 = global::Vector.Create(component.ActorForward);
		FVectorDouble result = global::Vector.ZeroVectorDouble;
		ESkillBehaviorLocationType eskillBehaviorLocationType = action.LocationType;
		ESkillBehaviorBestSpotType eskillBehaviorBestSpotType = action.Strategy;
		FVectorDouble fvectorDouble;
		FVector fvector;
		switch (eskillBehaviorLocationType)
		{
		case ESkillBehaviorLocationType.技能施法者:
			if (!FNameUtil.IsNothing(action.BoneName))
			{
				FTransformDouble socketTransform = component.GetSocketTransform(action.BoneName);
				global::Vector vector3 = vector;
				fvectorDouble = socketTransform.GetLocation();
				vector3.FromUeVector(fvectorDouble);
				global::Vector vector4 = vector2;
				fvector = socketTransform.GetRotation().GetForwardVector();
				vector4.FromUeVector(fvector);
			}
			break;
		case ESkillBehaviorLocationType.技能目标锁定点:
			if (param.SkillComponent.SkillTarget != null)
			{
				WorldEntity entity = param.SkillComponent.SkillTarget.Entity;
				AActor aactor;
				if (entity == null)
				{
					aactor = null;
				}
				else
				{
					BaseActorComponent component2 = entity.GetComponent<BaseActorComponent>();
					aactor = ((component2 != null) ? component2.Owner : null);
				}
				AActor aactor2 = aactor;
				if (aactor2 != null)
				{
					ValueTuple<FVectorDouble, FVectorDouble> locationAndDirection = SkillBehaviorMisc.GetLocationAndDirection(aactor2);
					vector.FromUeVector(locationAndDirection.Item1);
					vector2.FromUeVector(locationAndDirection.Item2);
				}
				FVectorDouble location = param.SkillComponent.GetTargetTransform().GetLocation();
				ValueTuple<UKuroHitResult, global::Vector>? valueTuple = SkillBehaviorMisc.TraceWall(component, global::Vector.Create(vector), global::Vector.Create(location), action.DebugTrace);
				if (valueTuple != null && valueTuple.Value.Item1 != null)
				{
					CombatLog.ELogType logType = CombatLog.ELogType.Info;
					ESkillLogType skillLogType = ESkillLogType.SkillBehavior;
					Entity entity2 = param.Entity;
					string message = "SkillBehaviorAction.SetLocation技能目标胶囊体中心和技能目标锁定点之间有阻挡，设置位置失败";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("技能Id", param.Skill.SkillId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("技能名", param.Skill.SkillName);
					SkillUtils.Log(logType, skillLogType, entity2, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				else
				{
					vector.FromUeVector(location);
				}
			}
			break;
		case ESkillBehaviorLocationType.当前小队锁定目标:
		{
			SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
			object obj;
			if (instance == null)
			{
				obj = null;
			}
			else
			{
				EntityHandle getCurrentEntity = instance.GetCurrentEntity;
				if (getCurrentEntity == null)
				{
					obj = null;
				}
				else
				{
					WorldEntity entity3 = getCurrentEntity.Entity;
					if (entity3 == null)
					{
						obj = null;
					}
					else
					{
						CharacterLockOnComponent component3 = entity3.GetComponent<CharacterLockOnComponent>();
						obj = ((component3 != null) ? component3.GetCurrentTarget() : null);
					}
				}
			}
			object obj2 = obj;
			AActor aactor3;
			if (obj2 == null)
			{
				aactor3 = null;
			}
			else
			{
				WorldEntity entity4 = obj2.Entity;
				if (entity4 == null)
				{
					aactor3 = null;
				}
				else
				{
					BaseActorComponent component4 = entity4.GetComponent<BaseActorComponent>();
					aactor3 = ((component4 != null) ? component4.Owner : null);
				}
			}
			AActor aactor4 = aactor3;
			if (aactor4 != null)
			{
				ValueTuple<FVectorDouble, FVectorDouble> locationAndDirection2 = SkillBehaviorMisc.GetLocationAndDirection(aactor4);
				vector.FromUeVector(locationAndDirection2.Item1);
				vector2.FromUeVector(locationAndDirection2.Item2);
			}
			break;
		}
		case ESkillBehaviorLocationType.小队当前角色:
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter != null)
			{
				ValueTuple<FVectorDouble, FVectorDouble> locationAndDirection3 = SkillBehaviorMisc.GetLocationAndDirection(baseCharacter);
				vector.FromUeVector(locationAndDirection3.Item1);
				vector2.FromUeVector(locationAndDirection3.Item2);
			}
			break;
		}
		case ESkillBehaviorLocationType.召唤者_伴生物专用_:
		{
			EntityHandle entity5 = ModelBase<CreatureModel>.Instance.GetEntity(param.Entity.GetComponent<CreatureDataComponent>().GetSummonerId());
			BaseActorComponent baseActorComponent;
			if (entity5 == null)
			{
				baseActorComponent = null;
			}
			else
			{
				WorldEntity entity6 = entity5.Entity;
				baseActorComponent = ((entity6 != null) ? entity6.GetComponent<BaseActorComponent>() : null);
			}
			BaseActorComponent baseActorComponent2 = baseActorComponent;
			if (baseActorComponent2 != null)
			{
				ValueTuple<FVectorDouble, FVectorDouble> locationAndDirection4 = SkillBehaviorMisc.GetLocationAndDirection(baseActorComponent2.Owner);
				vector.FromUeVector(locationAndDirection4.Item1);
				vector2.FromUeVector(locationAndDirection4.Item2);
			}
			break;
		}
		case ESkillBehaviorLocationType.当前小队摄像机:
		{
			CameraModel instance2 = ModelBase<CameraModel>.Instance;
			ACameraActor acameraActor;
			if (instance2 == null)
			{
				acameraActor = null;
			}
			else
			{
				FightCamera fightCamera = instance2.MainModel.FightCamera;
				if (fightCamera == null)
				{
					acameraActor = null;
				}
				else
				{
					FightCameraDisplayComponent component5 = fightCamera.GetComponent<FightCameraDisplayComponent>();
					acameraActor = ((component5 != null) ? component5.CameraActor : null);
				}
			}
			ACameraActor acameraActor2 = acameraActor;
			if (acameraActor2 != null)
			{
				ValueTuple<FVectorDouble, FVectorDouble> locationAndDirection5 = SkillBehaviorMisc.GetLocationAndDirection(acameraActor2);
				vector.FromUeVector(locationAndDirection5.Item1);
				vector2.FromUeVector(locationAndDirection5.Item2);
			}
			break;
		}
		case ESkillBehaviorLocationType.黑板位置:
		{
			Aki.Protocol.Vector vectorValueByEntity = ControllerBase<BlackboardController>.Instance.GetVectorValueByEntity(param.Entity.Id, action.BlackboardKey);
			global::Vector vector5 = vector;
			fvectorDouble = WorldGlobal.ToUeVector(vectorValueByEntity);
			vector5.FromUeVector(fvectorDouble);
			break;
		}
		case ESkillBehaviorLocationType.子弹位置:
		{
			int? intValueByEntity = ControllerBase<BlackboardController>.Instance.GetIntValueByEntity(param.Entity.Id, action.BlackboardKey);
			if (intValueByEntity != null)
			{
				Entity entity7 = Singleton<EntitySystem>.Instance.Get(intValueByEntity.Value);
				if (entity7 != null && entity7.Valid)
				{
					BulletActorComponent component6 = entity7.GetComponent<BulletActorComponent>();
					AActor aactor5 = (component6 != null) ? component6.Owner : null;
					if (aactor5 != null)
					{
						ValueTuple<FVectorDouble, FVectorDouble> locationAndDirection6 = SkillBehaviorMisc.GetLocationAndDirection(aactor5);
						vector.FromUeVector(locationAndDirection6.Item1);
						vector2.FromUeVector(locationAndDirection6.Item2);
					}
				}
			}
			break;
		}
		case ESkillBehaviorLocationType.伴生物位置:
		{
			EntityHandle summonedEntity = PhantomUtil.GetSummonedEntity(param.Entity, ESummonType.ConcomitantCustom, action.FollowIndex);
			BaseActorComponent baseActorComponent3;
			if (summonedEntity == null)
			{
				baseActorComponent3 = null;
			}
			else
			{
				WorldEntity entity8 = summonedEntity.Entity;
				baseActorComponent3 = ((entity8 != null) ? entity8.GetComponent<BaseActorComponent>() : null);
			}
			BaseActorComponent baseActorComponent4 = baseActorComponent3;
			if (baseActorComponent4 != null)
			{
				if (!FNameUtil.IsNothing(action.BoneName))
				{
					FTransformDouble socketTransform2 = baseActorComponent4.GetSocketTransform(action.BoneName);
					global::Vector vector6 = vector;
					fvectorDouble = socketTransform2.GetLocation();
					vector6.FromUeVector(fvectorDouble);
					global::Vector vector7 = vector2;
					fvector = socketTransform2.GetRotation().GetForwardVector();
					vector7.FromUeVector(fvector);
				}
				else
				{
					ValueTuple<FVectorDouble, FVectorDouble> locationAndDirection7 = SkillBehaviorMisc.GetLocationAndDirection(baseActorComponent4.Owner);
					vector.FromUeVector(locationAndDirection7.Item1);
					vector2.FromUeVector(locationAndDirection7.Item2);
				}
			}
			break;
		}
		}
		switch (action.LocationForwardType)
		{
		case ESkillBehaviorLocationForwardType.技能施法者正方向:
		{
			global::Vector vector8 = vector2;
			fvectorDouble = component.Actor.D_GetActorForwardVector();
			vector8.FromUeVector(fvectorDouble);
			break;
		}
		case ESkillBehaviorLocationForwardType.水平面上基准目标朝向技能施法者的方向:
		{
			global::Vector vector9 = global::Vector.Create();
			component.ActorLocationProxy.Subtraction(vector, vector9);
			vector2.Set(vector9.X, vector9.Y, 0.0);
			break;
		}
		case ESkillBehaviorLocationForwardType.镜头方向:
		{
			global::Vector vector10 = global::Vector.Create();
			vector.Subtraction(global::Vector.Create(Global.CharacterCameraManager.D_GetCameraLocation()), vector10);
			vector2.Set(vector10.X, vector10.Y, 0.0);
			break;
		}
		case ESkillBehaviorLocationForwardType.水平面上基准目标朝向前台角色的方向:
		{
			TsBaseCharacter baseCharacter2 = Global.BaseCharacter;
			if (baseCharacter2 != null)
			{
				global::Vector vector11 = vector2;
				fvectorDouble = baseCharacter2.D_K2_GetActorLocation();
				vector11.FromUeVector(fvectorDouble);
				vector2.SubtractionEqual(vector);
				vector2.Set(vector2.X, vector2.Y, 0.0);
			}
			break;
		}
		}
		if (action.BestSpot && eskillBehaviorBestSpotType == ESkillBehaviorBestSpotType.编队位置)
		{
			List<EntityHandle> teamEntities = ModelBase<SceneTeamModel>.Instance.GetTeamEntities(false);
			EntityHandle handleByEntity = ModelBase<CharacterModel>.Instance.GetHandleByEntity(param.Entity);
			int num = teamEntities.IndexOf(handleByEntity);
			if (num + 1 > action.AngleOffsets.Num())
			{
				CombatLog.ELogType logType2 = CombatLog.ELogType.Error;
				ESkillLogType skillLogType2 = ESkillLogType.SkillBehavior;
				Entity entity9 = param.Entity;
				string message2 = "SkillBehaviorAction.SetLocation当前施法者所处编队位置大于配置数组";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("技能Id", param.Skill.SkillId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("技能名", param.Skill.SkillName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("index", num);
				SkillUtils.Log(logType2, skillLogType2, entity9, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			}
			else
			{
				float num2 = action.AngleOffsets.Get(num);
				vector2.RotateAngleAxis((double)num2, global::Vector.UpVectorProxy, vector2);
			}
		}
		global::Vector vector12 = global::Vector.Create(vector);
		fvectorDouble = vector2.ToUeVector(false);
		FRotator frotator = fvectorDouble.Rotation();
		fvectorDouble = vector.ToUeVector(false);
		fvector = global::Vector.OneVectorDouble;
		FTransformDouble ftransformDouble = new FTransformDouble(ref frotator, ref fvectorDouble, ref fvector);
		FVectorDouble fvectorDouble2 = UKismetMathLibrary.Conv_VectorToVectorDouble(action.LocationOffset);
		global::Vector vector13 = vector;
		fvectorDouble = ftransformDouble.TransformPositionNoScale(fvectorDouble2);
		vector13.FromUeVector(fvectorDouble);
		if (action.Restrict)
		{
			global::Vector vector14 = global::Vector.Create(component.ActorLocation);
			switch (action.RestrictType)
			{
			case ESkillBehaviorRestrictType.小队前台角色当前位置:
			{
				TsBaseCharacter baseCharacter3 = Global.BaseCharacter;
				if (baseCharacter3 != null)
				{
					global::Vector vector15 = vector14;
					fvectorDouble = baseCharacter3.D_K2_GetActorLocation();
					vector15.FromUeVector(fvectorDouble);
				}
				break;
			}
			case ESkillBehaviorRestrictType.技能施法者出生位置_怪物专用_:
				if (param.Entity.GetComponent<CreatureDataComponent>().IsMonster())
				{
					Aki.Protocol.Vector initLocation = component.GetInitLocation();
					if (initLocation != null)
					{
						vector14.Set((double)initLocation.X, (double)initLocation.Y, (double)initLocation.Z);
					}
				}
				break;
			}
			double num3 = global::Vector.Dist2D(vector, vector14);
			if (num3 > (double)action.RestrictDistance)
			{
				double num4 = (double)action.RestrictDistance / num3;
				FVectorDouble from = vector14.ToUeVector(false);
				FVectorDouble to = vector.ToUeVector(false);
				Singleton<MathUtils>.Instance.LerpVector(from, to, (float)num4, ref to);
				vector.FromUeVector(to);
			}
		}
		global::Vector vector16 = global::Vector.Create(vector);
		if (action.BestSpot)
		{
			if (eskillBehaviorBestSpotType == ESkillBehaviorBestSpotType.四向查询_前台角色不穿墙_QTE专用_)
			{
				TsBaseCharacter baseCharacter4 = Global.BaseCharacter;
				if (baseCharacter4 != null)
				{
					result = baseCharacter4.D_K2_GetActorLocation();
				}
			}
			if (!vector12.Equals(vector16, 9.999999747378752E-05))
			{
				switch (eskillBehaviorBestSpotType)
				{
				case ESkillBehaviorBestSpotType.撞墙停止:
				case ESkillBehaviorBestSpotType.撞墙停止_技能施法者不穿墙:
				case ESkillBehaviorBestSpotType.编队位置:
				{
					ValueTuple<UKuroHitResult, global::Vector>? valueTuple2 = SkillBehaviorMisc.TraceWall(component, vector12, vector16, action.DebugTrace);
					if (valueTuple2 == null)
					{
						CombatLog.ELogType logType3 = CombatLog.ELogType.Info;
						ESkillLogType skillLogType3 = ESkillLogType.SkillBehavior;
						Entity entity10 = param.Entity;
						string message3 = "SkillBehaviorAction.SetLocation撞墙停止射线起点和终点位置相同，设置位置失败";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("技能Id", param.Skill.SkillId);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("技能名", param.Skill.SkillName);
						SkillUtils.Log(logType3, skillLogType3, entity10, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
						return result;
					}
					vector16 = valueTuple2.Value.Item2;
					break;
				}
				case ESkillBehaviorBestSpotType.四向查询:
				case ESkillBehaviorBestSpotType.四向查询_技能施法者不穿墙:
				case ESkillBehaviorBestSpotType.四向查询_前台角色不穿墙_QTE专用_:
				{
					bool flag = false;
					global::Vector vector17 = global::Vector.Create();
					global::Vector vector18 = global::Vector.Create();
					vector16.Subtraction(vector12, vector17);
					foreach (int num5 in SkillBehaviorMisc.Angles)
					{
						vector17.RotateAngleAxis((double)num5, global::Vector.UpVectorProxy, vector18);
						vector12.Addition(vector18, vector16);
						ValueTuple<UKuroHitResult, global::Vector>? valueTuple3 = SkillBehaviorMisc.TraceWall(component, vector12, vector16, action.DebugTrace);
						if (valueTuple3 == null)
						{
							CombatLog.ELogType logType4 = CombatLog.ELogType.Info;
							ESkillLogType skillLogType4 = ESkillLogType.SkillBehavior;
							Entity entity11 = param.Entity;
							string message4 = "SkillBehaviorAction.SetLocation四向查询射线起点和终点位置相同，设置位置失败";
							<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray2<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("技能Id", param.Skill.SkillId);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("技能名", param.Skill.SkillName);
							SkillUtils.Log(logType4, skillLogType4, entity11, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 2));
							return result;
						}
						if (valueTuple3.Value.Item1 == null)
						{
							flag = true;
							vector16 = valueTuple3.Value.Item2;
							break;
						}
					}
					if (!flag)
					{
						CombatLog.ELogType logType5 = CombatLog.ELogType.Info;
						ESkillLogType skillLogType5 = ESkillLogType.SkillBehavior;
						Entity entity12 = param.Entity;
						string message5 = "SkillBehaviorAction.SetLocation四个方向都撞墙了，设置位置失败";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray5 = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 0) = new ValueTuple<string, object>("技能Id", param.Skill.SkillId);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 1) = new ValueTuple<string, object>("技能名", param.Skill.SkillName);
						SkillUtils.Log(logType5, skillLogType5, entity12, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray5, 2));
						return result;
					}
					break;
				}
				}
			}
			global::Vector vector19 = null;
			if (eskillBehaviorBestSpotType == ESkillBehaviorBestSpotType.四向查询_技能施法者不穿墙 || eskillBehaviorBestSpotType == ESkillBehaviorBestSpotType.撞墙停止_技能施法者不穿墙)
			{
				if (eskillBehaviorLocationType != ESkillBehaviorLocationType.技能施法者)
				{
					vector19 = global::Vector.Create(component.ActorLocation);
				}
			}
			else if (eskillBehaviorBestSpotType == ESkillBehaviorBestSpotType.四向查询_前台角色不穿墙_QTE专用_)
			{
				TsBaseCharacter baseCharacter5 = Global.BaseCharacter;
				if (baseCharacter5 != null)
				{
					vector19 = global::Vector.Create(baseCharacter5.D_K2_GetActorLocation());
				}
			}
			if (vector19 != null)
			{
				global::Vector end = global::Vector.Create(vector16);
				ValueTuple<UKuroHitResult, global::Vector>? valueTuple4 = SkillBehaviorMisc.TraceWall(component, vector19, end, action.DebugTrace);
				if (valueTuple4 == null)
				{
					CombatLog.ELogType logType6 = CombatLog.ELogType.Info;
					ESkillLogType skillLogType6 = ESkillLogType.SkillBehavior;
					Entity entity13 = param.Entity;
					string message6 = "SkillBehaviorAction.SetLocation检测空气墙射线起点和终点位置相同，设置位置失败";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray6 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray6, 0) = new ValueTuple<string, object>("技能Id", param.Skill.SkillId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray6, 1) = new ValueTuple<string, object>("技能名", param.Skill.SkillName);
					SkillUtils.Log(logType6, skillLogType6, entity13, message6, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray6, 2));
					return result;
				}
				UKuroHitResult item = valueTuple4.Value.Item1;
				if (item != null)
				{
					int hitCount = item.GetHitCount();
					for (int j = 0; j < hitCount; j++)
					{
						AActor aactor6 = item.Actors.Get(j).Get();
						if (aactor6 != null && aactor6.IsValid() && aactor6.Tags.FindIndex(RefCompAirWallController.AIR_WALL) != -1)
						{
							CombatLog.ELogType logType7 = CombatLog.ELogType.Info;
							ESkillLogType skillLogType7 = ESkillLogType.SkillBehavior;
							Entity entity14 = param.Entity;
							string message7 = "SkillBehaviorAction.SetLocation检测到空气墙";
							<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray7 = default(<>y__InlineArray2<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray7, 0) = new ValueTuple<string, object>("技能Id", param.Skill.SkillId);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray7, 1) = new ValueTuple<string, object>("技能名", param.Skill.SkillName);
							SkillUtils.Log(logType7, skillLogType7, entity14, message7, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray7, 2));
							vector16 = valueTuple4.Value.Item2;
							break;
						}
					}
				}
			}
			if (action.OnGround)
			{
				ValueTuple<bool, global::Vector> valueTuple5 = SkillBehaviorMisc.TraceGroundWithGravity(component, vector16, action.DebugTrace, 2500f);
				if (!valueTuple5.Item1 || valueTuple5.Item2 == null)
				{
					CombatLog.ELogType logType8 = CombatLog.ELogType.Info;
					ESkillLogType skillLogType8 = ESkillLogType.SkillBehavior;
					Entity entity15 = param.Entity;
					string message8 = "SkillBehaviorAction.SetLocation贴地没有找到合法的落脚点，设置位置失败";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray8 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray8, 0) = new ValueTuple<string, object>("技能Id", param.Skill.SkillId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray8, 1) = new ValueTuple<string, object>("技能名", param.Skill.SkillName);
					SkillUtils.Log(logType8, skillLogType8, entity15, message8, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray8, 2));
					return result;
				}
				vector16 = valueTuple5.Item2;
				vector16.Z += (double)action.GroundOffset;
			}
		}
		global::Vector vector20 = vector;
		fvectorDouble = vector16.ToUeVector(false);
		vector20.FromUeVector(fvectorDouble);
		int navigation = action.Navigation;
		if (navigation > 0)
		{
			BaseMoveComponent component7 = param.Entity.GetComponent<CharacterMoveComponent>();
			global::Vector vector21 = global::Vector.Create();
			component7.GravityUp.Multiply((double)navigation, vector21);
			FVectorDouble fvectorDouble3 = default(FVectorDouble);
			UObject world = GlobalData.World;
			fvectorDouble = vector.ToUeVector(false);
			if (!UNavigationSystemV1.D_K2_ProjectPointToNavigation(world, fvectorDouble, ref fvectorDouble3, null, default(TSubclassOf<UNavigationQueryFilter>), vector21.ToUeVector(false), (double)navigation))
			{
				CombatLog.ELogType logType9 = CombatLog.ELogType.Info;
				ESkillLogType skillLogType9 = ESkillLogType.SkillBehavior;
				Entity entity16 = param.Entity;
				string message9 = "SkillBehaviorAction.SetLocation没有找到合法的导航网格落点，设置位置失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray9 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray9, 0) = new ValueTuple<string, object>("技能Id", param.Skill.SkillId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray9, 1) = new ValueTuple<string, object>("技能名", param.Skill.SkillName);
				SkillUtils.Log(logType9, skillLogType9, entity16, message9, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray9, 2));
				return result;
			}
			vector.FromUeVector(fvectorDouble3);
		}
		return vector.ToUeVector(false);
	}

	// Token: 0x0601A116 RID: 106774 RVA: 0x007A5300 File Offset: 0x007A3500
	private static void SetLocation(SSkillBehaviorAction action, IBeginSkillBehaviorActionParam param)
	{
		FVectorDouble value = SkillBehaviorAction.CalculateLocation(action, param);
		if (value.Equals(global::Vector.ZeroVectorDouble, 9.999999747378752E-05))
		{
			return;
		}
		BaseActorComponent component = param.Entity.GetComponent<CharacterActorComponent>();
		CombatLog.ELogType logType = CombatLog.ELogType.Info;
		ESkillLogType skillLogType = ESkillLogType.SkillBehavior;
		Entity entity = param.Entity;
		string message = "SkillBehaviorAction.SetLocation最终点";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("位置", value.ToString());
		SkillUtils.Log(logType, skillLogType, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		component.SetActorLocation(value, "SkillBehaviorAction.SetLocation.Final", false);
	}

	// Token: 0x0601A117 RID: 106775 RVA: 0x007A5378 File Offset: 0x007A3578
	public static FRotator CalculateRotation(SSkillBehaviorAction action, IBeginSkillBehaviorActionParam param)
	{
		global::Vector vector = null;
		EntityHandle entityHandle = null;
		global::Vector vector2 = null;
		switch (action.RotationType)
		{
		case ESkillBehaviorRotationType.技能目标:
			entityHandle = param.SkillComponent.SkillTarget;
			break;
		case ESkillBehaviorRotationType.小队当前角色:
		{
			SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
			entityHandle = ((instance != null) ? instance.GetCurrentEntity : null);
			break;
		}
		case ESkillBehaviorRotationType.召唤者_伴生物专用_:
		{
			CreatureDataComponent component = param.Entity.GetComponent<CreatureDataComponent>();
			entityHandle = ModelBase<CreatureModel>.Instance.GetEntity(component.GetSummonerId());
			break;
		}
		case ESkillBehaviorRotationType.当前小队摄像机_玩家专用_:
		{
			CameraModel instance2 = ModelBase<CameraModel>.Instance;
			ACameraActor acameraActor;
			if (instance2 == null)
			{
				acameraActor = null;
			}
			else
			{
				FightCamera fightCamera = instance2.MainModel.FightCamera;
				if (fightCamera == null)
				{
					acameraActor = null;
				}
				else
				{
					FightCameraDisplayComponent component2 = fightCamera.GetComponent<FightCameraDisplayComponent>();
					acameraActor = ((component2 != null) ? component2.CameraActor : null);
				}
			}
			ACameraActor acameraActor2 = acameraActor;
			if (acameraActor2 != null)
			{
				vector = SkillBehaviorAction.TmpVector;
				global::Vector vector3 = vector;
				FVectorDouble fvectorDouble = acameraActor2.D_K2_GetActorLocation();
				vector3.FromUeVector(fvectorDouble);
			}
			break;
		}
		case ESkillBehaviorRotationType.技能目标玩家摄像机_怪物专用_:
		{
			EntityHandle skillTarget = param.SkillComponent.SkillTarget;
			SceneTeamModel instance3 = ModelBase<SceneTeamModel>.Instance;
			if (skillTarget == ((instance3 != null) ? instance3.GetCurrentEntity : null))
			{
				CameraModel instance4 = ModelBase<CameraModel>.Instance;
				ACameraActor acameraActor3;
				if (instance4 == null)
				{
					acameraActor3 = null;
				}
				else
				{
					FightCamera fightCamera2 = instance4.MainModel.FightCamera;
					if (fightCamera2 == null)
					{
						acameraActor3 = null;
					}
					else
					{
						FightCameraDisplayComponent component3 = fightCamera2.GetComponent<FightCameraDisplayComponent>();
						acameraActor3 = ((component3 != null) ? component3.CameraActor : null);
					}
				}
				ACameraActor acameraActor4 = acameraActor3;
				if (acameraActor4 != null)
				{
					vector = SkillBehaviorAction.TmpVector;
					global::Vector vector4 = vector;
					FVectorDouble fvectorDouble = acameraActor4.D_K2_GetActorLocation();
					vector4.FromUeVector(fvectorDouble);
				}
			}
			else
			{
				entityHandle = param.SkillComponent.SkillTarget;
			}
			break;
		}
		case ESkillBehaviorRotationType.技能施法者朝向:
			break;
		case ESkillBehaviorRotationType.输入朝向_玩家专用_:
		{
			CharacterActorComponent component4 = param.Entity.GetComponent<CharacterActorComponent>();
			if (component4 != null && component4.IsAutonomousProxy)
			{
				vector2 = component4.InputDirectProxy;
			}
			break;
		}
		default:
			entityHandle = ModelBase<CharacterModel>.Instance.GetHandleByEntity(param.Entity);
			break;
		}
		if (((entityHandle != null) ? entityHandle.Entity : null) != null && entityHandle.Entity != param.Entity)
		{
			vector = entityHandle.Entity.GetComponent<BaseActorComponent>().ActorLocationProxy;
		}
		CharacterActorComponent component5 = param.Entity.GetComponent<CharacterActorComponent>();
		if (vector != null)
		{
			vector.Subtraction(component5.ActorLocationProxy, SkillBehaviorAction.TmpVector);
			Singleton<MathUtils>.Instance.LookRotationUpFirst(SkillBehaviorAction.TmpVector, component5.MoveComp.GravityUp, SkillBehaviorAction.TmpQuat);
		}
		else if (vector2 != null)
		{
			Singleton<MathUtils>.Instance.LookRotationUpFirst(vector2, component5.MoveComp.GravityUp, SkillBehaviorAction.TmpQuat);
		}
		else
		{
			SkillBehaviorAction.TmpQuat.DeepCopy(component5.ActorQuatProxy);
		}
		if (action.DirectionOffset != 0f)
		{
			SkillBehaviorAction.TmpRotator.Set(0f, action.DirectionOffset, 0f);
			SkillBehaviorAction.TmpQuat.Multiply(SkillBehaviorAction.TmpRotator.Quaternion(null), SkillBehaviorAction.TmpQuat);
			SkillBehaviorAction.TmpQuat.Rotator(SkillBehaviorAction.TmpRotator);
		}
		else
		{
			SkillBehaviorAction.TmpQuat.Rotator(SkillBehaviorAction.TmpRotator);
		}
		return SkillBehaviorAction.TmpRotator.ToUeRotator();
	}

	// Token: 0x0601A118 RID: 106776 RVA: 0x007A561C File Offset: 0x007A381C
	private static void SetRotation(SSkillBehaviorAction action, IBeginSkillBehaviorActionParam param)
	{
		BaseActorComponent component = param.Entity.GetComponent<CharacterActorComponent>();
		FRotator frotator = SkillBehaviorAction.CalculateRotation(action, param);
		CombatLog.ELogType logType = CombatLog.ELogType.Info;
		ESkillLogType skillLogType = ESkillLogType.SkillBehavior;
		Entity entity = param.Entity;
		string message = "SkillBehaviorAction.SetRotation";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("朝向", frotator);
		SkillUtils.Log(logType, skillLogType, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		component.SetActorRotation(frotator, "SkillBehaviorAction.SetDirection", false);
	}

	// Token: 0x0601A119 RID: 106777 RVA: 0x007A5674 File Offset: 0x007A3874
	private static void PlayEffect(SSkillBehaviorAction action, IBeginSkillBehaviorActionParam param)
	{
		CharacterGameplayCueComponent component = param.Entity.GetComponent<CharacterGameplayCueComponent>();
		for (int i = 0; i < action.Cues.Num(); i++)
		{
			SSkillBehaviorCue sskillBehaviorCue = action.Cues.Get(i);
			int num = component.AddCue(sskillBehaviorCue.CueId, new GameplayCueParam?(new GameplayCueParam
			{
				Sync = new bool?(true)
			}));
			if (sskillBehaviorCue.Stop)
			{
				SkillBehaviorMisc.GetEndSkillBehaviorParamList(param.Skill).Add(new EndSkillBehaviorParam
				{
					Entity = param.Entity,
					ActionType = action.ActionType,
					GameplayCue = new long?((long)num)
				});
			}
		}
	}

	// Token: 0x0601A11A RID: 106778 RVA: 0x007A5728 File Offset: 0x007A3928
	private static void CreateBullet(SSkillBehaviorAction action, IBeginSkillBehaviorActionParam param)
	{
		for (int i = 0; i < action.Bullets.Num(); i++)
		{
			SSkillBehaviorBullet sskillBehaviorBullet = action.Bullets.Get(i);
			for (int j = 0; j < sskillBehaviorBullet.bulletCount; j++)
			{
				int value = -1;
				if (param.Skill.SkillBehaviorAnimNotifyMessageId != null)
				{
					TsBaseCharacter actor = param.Entity.GetComponent<CharacterActorComponent>().Actor;
					if (actor != null)
					{
						TsBaseCharacter owner = actor;
						value = BulletUtil.CreateBulletFromAN(owner, sskillBehaviorBullet.bulletRowName, new FTransformDouble?(param.Entity.GetComponent<CharacterActorComponent>().ActorTransform), param.Skill.SkillId, true, new long?(param.Skill.SkillBehaviorAnimNotifyMessageId.Value), param.Skill.ExtraTargetLocation, null, null);
					}
				}
				else
				{
					BulletEntity bulletEntity = ControllerBase<BulletController>.Instance.CreateBulletCustomTarget(param.Entity, sskillBehaviorBullet.bulletRowName, new FTransformDouble?(param.Entity.GetComponent<CharacterActorComponent>().ActorTransform), new BulletController.BulletCreateParams
					{
						SkillId = param.Skill.SkillId,
						SkillContextId = new long?(param.Skill.CombatMessageId.GetValueOrDefault()),
						SyncType = EBulletSyncType.SyncCreate,
						BattleContext = param.Skill.BattleContext,
						InitTargetLocation = param.Skill.ExtraTargetLocation
					}, param.Skill.CombatMessageId, global::EBulletCreateSource.Others);
					if (bulletEntity != null)
					{
						value = bulletEntity.Id;
					}
				}
				if (!string.IsNullOrEmpty(sskillBehaviorBullet.BlackboardKey))
				{
					ControllerBase<BlackboardController>.Instance.SetIntValueByEntity(param.Entity.Id, sskillBehaviorBullet.BlackboardKey, value);
				}
			}
		}
	}

	// Token: 0x0601A11B RID: 106779 RVA: 0x007A58E0 File Offset: 0x007A3AE0
	private static void CameraModify(SSkillBehaviorAction action, IBeginSkillBehaviorActionParam param)
	{
		if (!CameraUtility.CheckApplyCameraModifyCondition(ModelBase<CreatureModel>.Instance.GetEntityById(param.Entity.Id), action.CameraModifierSettings, action.CameraEffectiveClientType, action.CameraModifierConditions))
		{
			return;
		}
		ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.ApplyCameraModify(new FGameplayTag?(action.Tag), action.Duration, action.BlendInTime, action.BlendOutTime, action.CameraModifierSettings, null, action.BreakBlendOutTime, action.BlendInCurve, action.BlendOutCurve, default(OneOf<TsBaseCharacter, TsBaseVehicle>), action.CameraAttachSocket.ToString(), default(OneOf<TsBaseCharacter, TsBaseVehicle>));
	}

	// Token: 0x0601A11C RID: 106780 RVA: 0x007A5998 File Offset: 0x007A3B98
	private static void CameraSequence(SSkillBehaviorAction action, IBeginSkillBehaviorActionParam param)
	{
		ControllerBase<CameraController>.Instance.MainModel.SequenceCamera.PlayerComponent.PlayCameraSequence(action.CameraSequenceSettings, action.ResetLockOnCamera, action.AdditiveRotation, param.Entity.GetComponent<CharacterActorComponent>().Actor, action.CameraAttachSocket, action.CameraDetectSocket, action.ExtraSphereLocation, action.ExtraDetectSphereRadius, action.IsShowExtraSphere, false, true, true, false, false, null, new int?(param.Entity.Id), new long?((long)param.Skill.SkillId));
	}

	// Token: 0x0601A11D RID: 106781 RVA: 0x007A5A28 File Offset: 0x007A3C28
	private static void SetMovementMode(SSkillBehaviorAction action, IBeginSkillBehaviorActionParam param)
	{
		param.Entity.GetComponent<CharacterActorComponent>().Actor.KuroSetMovementMode(new SetMovementModeInfo
		{
			Mode = action.BeginMovementMode,
			Context = "[SkillBehaviorAction.SetMovementMode]"
		});
		SkillBehaviorMisc.GetEndSkillBehaviorParamList(param.Skill).Add(new EndSkillBehaviorParam
		{
			Entity = param.Entity,
			ActionType = action.ActionType,
			MovementMode = new EMovementMode?(action.EndMovementMode)
		});
	}

	// Token: 0x0601A11E RID: 106782 RVA: 0x007A5AB4 File Offset: 0x007A3CB4
	private static void SetCollision(SSkillBehaviorAction action, IBeginSkillBehaviorActionParam param)
	{
		UCapsuleComponent capsuleComponent = param.Entity.GetComponent<CharacterActorComponent>().Actor.CapsuleComponent;
		if (capsuleComponent == null)
		{
			return;
		}
		if (action.CollisionRestore)
		{
			SkillBehaviorMisc.GetEndSkillBehaviorParamList(param.Skill).Add(new EndSkillBehaviorParam
			{
				Entity = param.Entity,
				ActionType = action.ActionType,
				CollisionChannel = new ECollisionChannel?(action.CollisionChannel),
				CollisionResponse = new ECollisionResponse?(capsuleComponent.GetCollisionResponseToChannel(action.CollisionChannel))
			});
		}
		capsuleComponent.SetCollisionResponseToChannel(action.CollisionChannel, action.CollisionResponse);
	}

	// Token: 0x0601A11F RID: 106783 RVA: 0x007A5B68 File Offset: 0x007A3D68
	private static void UseSummonSkill(SSkillBehaviorAction action, IBeginSkillBehaviorActionParam param)
	{
		EntityHandle summonedEntity = PhantomUtil.GetSummonedEntity(param.Entity, ESummonType.ConcomitantCustom, action.FollowIndex);
		if (summonedEntity == null)
		{
			return;
		}
		BaseSkillComponent component = summonedEntity.Entity.GetComponent<BaseSkillComponent>();
		if (action.StopSummonSkill)
		{
			SkillBehaviorMisc.GetEndSkillBehaviorParamList(param.Skill).Add(new EndSkillBehaviorParam
			{
				Entity = param.Entity,
				ActionType = action.ActionType,
				SummonSkillComponent = component,
				SummonSkillId = new int?(action.SummonSkillId)
			});
		}
		BaseSkillComponent baseSkillComponent = component;
		int summonSkillId = action.SummonSkillId;
		SkillParam skillParam = new SkillParam();
		EntityHandle skillTarget = param.SkillComponent.SkillTarget;
		skillParam.Target = ((skillTarget != null) ? skillTarget.Entity : null);
		skillParam.Reason = "SkillBehaviorAction.UseSummonSkill";
		baseSkillComponent.BeginSkill(summonSkillId, skillParam);
	}

	// Token: 0x0601A120 RID: 106784 RVA: 0x007A5C24 File Offset: 0x007A3E24
	private static void Buff(SSkillBehaviorAction action, IBeginSkillBehaviorActionParam param)
	{
		CharacterBuffComponent characterBuffComponent = null;
		ESkillBehaviorBuffTargetType eskillBehaviorBuffTargetType = action.BuffTarget;
		if (eskillBehaviorBuffTargetType != ESkillBehaviorBuffTargetType.施法者)
		{
			if (eskillBehaviorBuffTargetType == ESkillBehaviorBuffTargetType.技能目标)
			{
				EntityHandle skillTarget = param.SkillComponent.SkillTarget;
				CharacterBuffComponent characterBuffComponent2;
				if (skillTarget == null)
				{
					characterBuffComponent2 = null;
				}
				else
				{
					WorldEntity entity = skillTarget.Entity;
					characterBuffComponent2 = ((entity != null) ? entity.GetComponent<CharacterBuffComponent>() : null);
				}
				characterBuffComponent = characterBuffComponent2;
			}
		}
		else
		{
			characterBuffComponent = param.Entity.GetComponent<CharacterBuffComponent>();
		}
		if (characterBuffComponent != null)
		{
			if (action.Add)
			{
				long? skillBehaviorAnimNotifyMessageId = param.Skill.SkillBehaviorAnimNotifyMessageId;
				long? preMessageId = (skillBehaviorAnimNotifyMessageId != null) ? skillBehaviorAnimNotifyMessageId : param.Skill.CombatMessageId;
				AddBuffParam buffParams = new AddBuffParam
				{
					InstigatorId = ModelBase<CreatureModel>.Instance.GetCreatureDataId(param.Entity.Id),
					Reason = "从技能行为添加Buff",
					PreMessageId = preMessageId
				};
				characterBuffComponent.AddBuff(action.BuffId, buffParams);
				return;
			}
			characterBuffComponent.RemoveBuff(action.BuffId, -1, "从技能行为移除Buff", null, null, null);
		}
	}

	// Token: 0x0601A121 RID: 106785 RVA: 0x007A5D20 File Offset: 0x007A3F20
	private static void Tag(SSkillBehaviorAction action, IBeginSkillBehaviorActionParam param)
	{
		BaseTagComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseTagComponent>(param.Entity.Id);
		if (component != null && component.Valid && action.Tag.TagName != "None")
		{
			if (action.Add)
			{
				component.AddTag(new int?(action.Tag.TagId()));
				return;
			}
			component.RemoveTag(new int?(action.Tag.TagId()));
		}
	}

	// Token: 0x0601A122 RID: 106786 RVA: 0x007A5DA0 File Offset: 0x007A3FA0
	private static void ExitWeakTime(SSkillBehaviorAction action, IBeginSkillBehaviorActionParam param)
	{
		BaseDamageComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseDamageComponent>(param.Entity.Id);
		if (component != null && component.Valid)
		{
			component.TryExitWeakTime();
		}
	}

	// Token: 0x0601A123 RID: 106787 RVA: 0x007A5DD4 File Offset: 0x007A3FD4
	private static void PlaySkillMontage(SSkillBehaviorAction action, IBeginSkillBehaviorActionParam param)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(param.Entity.Id);
		if (component != null && component.Valid)
		{
			component.PlaySkillMontageWithEndAbility(param.Skill, action.MontageIndex, action.StartSection, action.StartTime);
		}
	}

	// Token: 0x0601A124 RID: 106788 RVA: 0x007A5E24 File Offset: 0x007A4024
	private static void UpdateCustomValue(SSkillBehaviorAction action, IBeginSkillBehaviorActionParam param)
	{
		CharacterCustomValueComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterCustomValueComponent>(param.Entity.Id);
		if (component != null && component.Valid)
		{
			TArray<string> valueName = action.UpdateCustomValue.ValueName;
			int num = valueName.Num();
			for (int i = 0; i < num; i++)
			{
				string key = valueName.Get(i);
				component.UpdateCustomValue(key);
			}
		}
	}

	// Token: 0x0400D12A RID: 53546
	[StaticVariableRuleIgnore]
	private static readonly Stat StatOnCalculateLocation = Stat.Create("[SkillBehaviorAction]CalculateLocation", "", "");

	// Token: 0x0400D12B RID: 53547
	[StaticVariableRuleIgnore]
	private static readonly Stat StatOnCalculateRotation = Stat.Create("[SkillBehaviorAction]CalculateRotation", "", "");

	// Token: 0x0400D12C RID: 53548
	[StaticVariableRuleIgnore]
	private static readonly Stat StatOnSetLocation = Stat.Create("[SkillBehaviorAction]SetLocation", "", "");

	// Token: 0x0400D12D RID: 53549
	[StaticVariableRuleIgnore]
	private static readonly Stat StatOnSetRotation = Stat.Create("[SkillBehaviorAction]SetRotation", "", "");

	// Token: 0x0400D12E RID: 53550
	[StaticVariableRuleIgnore]
	private static readonly Stat StatOnPlayEffect = Stat.Create("[SkillBehaviorAction]PlayEffect", "", "");

	// Token: 0x0400D12F RID: 53551
	[StaticVariableRuleIgnore]
	private static readonly Stat StatOnCreateBullet = Stat.Create("[SkillBehaviorAction]CreateBullet", "", "");

	// Token: 0x0400D130 RID: 53552
	[StaticVariableRuleIgnore]
	private static readonly Stat StatOnCamera = Stat.Create("[SkillBehaviorAction]Camera", "", "");

	// Token: 0x0400D131 RID: 53553
	[StaticVariableRuleIgnore]
	private static readonly Stat StatOnBatchCreate = Stat.Create("[SkillBehaviorAction]BatchCreate", "", "");

	// Token: 0x0400D132 RID: 53554
	[StaticVariableRuleIgnore]
	private static readonly global::Vector TmpVector = global::Vector.Create();

	// Token: 0x0400D133 RID: 53555
	[StaticVariableRuleIgnore]
	private static readonly Quat TmpQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400D134 RID: 53556
	[StaticVariableRuleIgnore]
	private static readonly global::Rotator TmpRotator = global::Rotator.Create();
}
