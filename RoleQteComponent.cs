using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Data.Fight.Struct;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.CombatMessage;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using UnrealEngine;

// Token: 0x02003200 RID: 12800
[NullableContext(1)]
[Nullable(0)]
public class RoleQteComponent : EntityComponent
{
	// Token: 0x0601A8BD RID: 108733 RVA: 0x007DB81C File Offset: 0x007D9A1C
	protected override bool OnStart()
	{
		this.ActorComponent = base.Entity.GetComponent<CharacterActorComponent>();
		this.AbilityComponent = base.Entity.CheckGetComponent<CharacterAbilityComponent>();
		this.TagComponent = base.Entity.CheckGetComponent<BaseTagComponent>();
		this.BuffComponent = base.Entity.CheckGetComponent<CharacterBuffComponent>();
		this.TeamComponent = base.Entity.CheckGetComponent<RoleTeamComponent>();
		this.SkillComponent = base.Entity.CheckGetComponent<CharacterSkillComponent>();
		this.ElementComponent = base.Entity.CheckGetComponent<RoleElementComponent>();
		this.QteTagListeners.Add(this.TagComponent.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["功能.功能制作.QTE.激活QTE"]), new BaseTagComponent.TTagSwitchedCallback(this.OnActiveQteTagChange), null));
		this.QteTagListeners.Add(this.TagComponent.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.QTE"]), new BaseTagComponent.TTagSwitchedCallback(this.OnQteSkillTagChange), null));
		Singleton<EventSystem>.Instance.Add(EEventName.OnEnterOnlineWorld, new Action(this.OnEnterOnlineWorld));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.CharQteConsume, new Action<int>(this.QteConsume));
		this.InitTriggerTags();
		return true;
	}

	// Token: 0x0601A8BE RID: 108734 RVA: 0x007DB94C File Offset: 0x007D9B4C
	protected override bool OnEnd()
	{
		foreach (ITagTask tagTask in this.QteTagListeners)
		{
			tagTask.EndTask();
		}
		Singleton<EventSystem>.Instance.Remove(EEventName.OnEnterOnlineWorld, new Action(this.OnEnterOnlineWorld));
		Singleton<EventSystem>.Instance.Remove(EEventName.CharQteConsume, new Action<int>(this.QteConsume));
		return true;
	}

	// Token: 0x0601A8BF RID: 108735 RVA: 0x007DB9D4 File Offset: 0x007D9BD4
	private void InitTriggerTags()
	{
		this.TagComponent.AddTag(new int?(this.normalQteTag));
		Dictionary<int, string>.ValueCollection values = ConfigBase<WorldConfig>.Instance.GetQteTagDataMap().Values;
		UDataTable qteTagDataTable = ConfigBase<WorldConfig>.Instance.GetQteTagDataTable();
		foreach (string text in values)
		{
			int num = DataTableUtil.GetDataTableRow<SQteTag>(qteTagDataTable, text).QteTag.TagId();
			this.QteTagListeners.Add(this.TagComponent.ListenForTagAddOrRemove(new int?(num), new BaseTagComponent.TTagSwitchedCallback(this.OnQteTagTriggerChange), null));
			if (this.TagComponent.HasTag(num))
			{
				this.QteTagMap[num] = text;
			}
		}
		this.RefreshQteTagRowName();
	}

	// Token: 0x0601A8C0 RID: 108736 RVA: 0x007DBAA8 File Offset: 0x007D9CA8
	private void OnActiveQteTagChange(int tagId, bool bTagExists)
	{
		Singleton<EventSystem>.Instance.Emit<int>(bTagExists ? EEventName.CharQteActive : EEventName.CharQteConsume, base.Entity.Id);
	}

	// Token: 0x0601A8C1 RID: 108737 RVA: 0x007DBAC9 File Offset: 0x007D9CC9
	private void QteConsume(int charId)
	{
		if (base.Entity.Id == charId)
		{
			return;
		}
		this.ConsumedQteEntitySet.Remove(charId);
	}

	// Token: 0x0601A8C2 RID: 108738 RVA: 0x007DBAE7 File Offset: 0x007D9CE7
	private void OnEnterOnlineWorld()
	{
		this.ConsumedQteEntitySet.Clear();
	}

	// Token: 0x0601A8C3 RID: 108739 RVA: 0x007DBAF4 File Offset: 0x007D9CF4
	private void OnQteSkillTagChange(int tagId, bool bTagExists)
	{
		if (!bTagExists)
		{
			this.IsInQte = false;
			this.BuffComponent.RemoveBuffByTag(new int?(GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.无敌.QTE无敌"]), "QTE结束移除", null);
			SceneTeamItem teamItem = ModelBase<SceneTeamModel>.Instance.GetTeamItem((long)base.Entity.Id, new GetTeamItemOptions
			{
				ParamType = ETeamParamType.EntityId
			});
			if (teamItem == null || !teamItem.IsControl())
			{
				this.TeamComponent.DisableRoleWithEffect();
			}
		}
		else
		{
			this.IsInQte = true;
		}
		Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.CharInQteChanged, base.Entity.Id, this.IsInQte);
	}

	// Token: 0x0601A8C4 RID: 108740 RVA: 0x007DBB98 File Offset: 0x007D9D98
	public bool IsQteReady(EntityHandle goDownPlayerHandle)
	{
		if (this.IsInQte)
		{
			return false;
		}
		if (!ControllerBase<FormationDataController>.Instance.GlobalIsInFight)
		{
			return false;
		}
		if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"]))
		{
			return false;
		}
		if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["战斗状态.技能限制.禁止QTE"]))
		{
			return false;
		}
		SQteTag qteTagData = this.GetQteTagData();
		if (qteTagData == null)
		{
			return false;
		}
		if (this.TagComponent.HasTag(qteTagData.NoTag.TagId()))
		{
			return false;
		}
		BaseTagComponent component = goDownPlayerHandle.Entity.GetComponent<BaseTagComponent>();
		if (!component.HasTag(GameplayTagDefine.EGameplayTagId["功能.功能制作.QTE.激活QTE"]) || component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"]))
		{
			return false;
		}
		if (!component.HasTag(GameplayTagDefine.EGameplayTagId["功能.功能制作.QTE.激活QTE.不消耗能量"]) && this.ConsumedQteEntitySet.Contains(goDownPlayerHandle.Id))
		{
			return false;
		}
		CharacterActorComponent component2 = goDownPlayerHandle.Entity.GetComponent<CharacterActorComponent>();
		if (ControllerBase<FormationDataController>.Instance.IsBattleMulti())
		{
			if (component2.IsAutonomousProxy)
			{
				return false;
			}
			List<SceneTeamItem> teamItemsInRange = ModelBase<SceneTeamModel>.Instance.GetTeamItemsInRange(this.ActorComponent.ActorLocationProxy, 5000f);
			bool flag = false;
			using (List<SceneTeamItem>.Enumerator enumerator = teamItemsInRange.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.EntityHandle == goDownPlayerHandle)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0601A8C5 RID: 108741 RVA: 0x007DBD18 File Offset: 0x007D9F18
	public void UseExitSkill(EntityHandle goBattlePlayerHandle)
	{
		SQteTag qteTagData = goBattlePlayerHandle.Entity.GetComponent<RoleQteComponent>().GetQteTagData();
		if (qteTagData == null || qteTagData.ExitSkillTrigger.TagName == FName.NAME_None)
		{
			return;
		}
		this.GoBattleActor = goBattlePlayerHandle.Entity.GetComponent<CharacterActorComponent>().Actor;
		FGameplayEventData fgameplayEventData = new FGameplayEventData();
		fgameplayEventData.Instigator = this.ActorComponent.Actor;
		fgameplayEventData.Target = this.GoBattleActor;
		this.AbilityComponent.SendGameplayEventToActor(qteTagData.ExitSkillTrigger, fgameplayEventData);
		this.GoBattleActor = null;
	}

	// Token: 0x0601A8C6 RID: 108742 RVA: 0x007DBDAC File Offset: 0x007D9FAC
	public bool ExecuteQte(EntityHandle goDownPlayerHandle)
	{
		SQteTag qteTagData = this.GetQteTagData();
		if (qteTagData == null || qteTagData.QteTrigger.TagName == FName.NAME_None)
		{
			return false;
		}
		long value = this.ExecuteQte2Server(goDownPlayerHandle);
		this.SelectTarget(goDownPlayerHandle);
		this.TeamComponent.InterruptDisableWithEffect();
		this.TeamComponent.SetTeamTag(ETeamState.OnStage);
		base.Entity.EnableByKey(EEntityDisableKey.GoDown, true);
		this.AbilityComponent.SendGameplayEventToActor(qteTagData.QteTrigger, null);
		for (int i = 0; i < qteTagData.QteBuffs.Num(); i++)
		{
			this.BuffComponent.AddBuff(qteTagData.QteBuffs.Get(i), new AddBuffParam
			{
				InstigatorId = this.BuffComponent.CreatureDataId,
				PreMessageId = new long?(value),
				Reason = "ExecuteQte"
			});
		}
		RoleElementComponent component = goDownPlayerHandle.Entity.GetComponent<RoleElementComponent>();
		BaseTagComponent component2 = goDownPlayerHandle.Entity.GetComponent<BaseTagComponent>();
		component.TriggerEvents(base.Entity);
		if (!component2.HasTag(GameplayTagDefine.EGameplayTagId["功能.功能制作.QTE.激活QTE.不消耗能量"]))
		{
			for (int j = 0; j < qteTagData.ConsumeBuffs.Num(); j++)
			{
				component.ClearElementEnergy(base.Entity, qteTagData.ConsumeBuffs.Get(j));
			}
		}
		Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.CharExecuteQte, base.Entity.Id, goDownPlayerHandle.Id);
		return true;
	}

	// Token: 0x0601A8C7 RID: 108743 RVA: 0x007DBF0C File Offset: 0x007DA10C
	public bool ExecuteMultiQte(EntityHandle goDownPlayerHandle)
	{
		SQteTag qteTagData = this.GetQteTagData();
		if (qteTagData == null || qteTagData.QteTrigger.TagName == FName.NAME_None)
		{
			return false;
		}
		long value = this.ExecuteQte2Server(goDownPlayerHandle);
		this.AbilityComponent.SendGameplayEventToActor(qteTagData.QteTrigger, null);
		for (int i = 0; i < qteTagData.QteBuffs.Num(); i++)
		{
			this.BuffComponent.AddBuff(qteTagData.QteBuffs.Get(i), new AddBuffParam
			{
				InstigatorId = this.BuffComponent.CreatureDataId,
				PreMessageId = new long?(value),
				Reason = "ExecuteQte"
			});
		}
		RoleElementComponent component = goDownPlayerHandle.Entity.GetComponent<RoleElementComponent>();
		BaseTagComponent component2 = goDownPlayerHandle.Entity.GetComponent<BaseTagComponent>();
		component.TriggerEvents(base.Entity);
		if (!component2.HasTag(GameplayTagDefine.EGameplayTagId["功能.功能制作.QTE.激活QTE.不消耗能量"]))
		{
			if (ModelBase<SceneTeamModel>.Instance.GetTeamPlayerSize() > 2)
			{
				component.ClearElementEnergy(base.Entity, 3026L);
			}
			else
			{
				for (int j = 0; j < qteTagData.ConsumeBuffs.Num(); j++)
				{
					component.ClearElementEnergy(base.Entity, qteTagData.ConsumeBuffs.Get(j));
				}
			}
			this.ConsumedQteEntitySet.Add(goDownPlayerHandle.Id);
		}
		Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.CharExecuteMultiQte, base.Entity.Id, goDownPlayerHandle.Id);
		return true;
	}

	// Token: 0x0601A8C8 RID: 108744 RVA: 0x007DC074 File Offset: 0x007DA274
	private void CreateSphereElement()
	{
		if (this.SphereElement == null)
		{
			this.SphereElement = new UTraceSphereElement();
			this.SphereElement.WorldContextObject = GlobalData.World;
			this.SphereElement.Radius = this.ActorComponent.ScaledRadius;
			this.SphereElement.bIsSingle = true;
			this.SphereElement.bIgnoreSelf = true;
			this.SphereElement.SetTraceTypeQuery(KuroTraceTypeQuery.IkGround);
		}
	}

	// Token: 0x0601A8C9 RID: 108745 RVA: 0x007DC0E4 File Offset: 0x007DA2E4
	private void CreateLineElement()
	{
		if (this.LineElement == null)
		{
			this.LineElement = new UTraceLineElement();
			this.LineElement.WorldContextObject = GlobalData.World;
			this.LineElement.bIsSingle = true;
			this.LineElement.bIgnoreSelf = true;
			this.LineElement.AddObjectTypeQuery(KuroObjectTypeQuery.WorldStatic);
			this.LineElement.AddObjectTypeQuery(KuroObjectTypeQuery.WorldStaticIgnoreBullet);
		}
	}

	// Token: 0x0601A8CA RID: 108746 RVA: 0x007DC14C File Offset: 0x007DA34C
	private void InitTrack(UTraceBaseElement traceElement, BaseActorComponent selectTarget, CharacterActorComponent currentRole)
	{
		UKuroHitResult hitResult = traceElement.HitResult;
		if (hitResult != null)
		{
			hitResult.Clear();
		}
		traceElement.ActorsToIgnore.Empty(true);
		traceElement.ActorsToIgnore.Add(selectTarget.Owner);
		traceElement.ActorsToIgnore.Add(currentRole.Actor);
		CharacterFollowComponent component = currentRole.Entity.GetComponent<CharacterFollowComponent>();
		TArray<AActor> tarray = (component != null) ? component.GetAttributeSharerActors() : null;
		if (tarray != null)
		{
			for (int i = 0; i < tarray.Num(); i++)
			{
				traceElement.ActorsToIgnore.Add(tarray.Get(i));
			}
		}
	}

	// Token: 0x0601A8CB RID: 108747 RVA: 0x007DC1D8 File Offset: 0x007DA3D8
	public unsafe void SetQtePosition(IOffsetParam offsetParam)
	{
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		CharacterActorComponent characterActorComponent = (baseCharacter != null) ? baseCharacter.CharacterActorComponent : null;
		if (characterActorComponent == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Character, ELogAuthor.ZQ, "GetQtePosition error, currentRole not found", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		BaseActorComponent baseActorComponent = characterActorComponent;
		global::Vector vector = global::Vector.Create();
		vector.DeepCopy(baseActorComponent.ActorLocationProxy);
		if (offsetParam.ReferenceTarget)
		{
			EntityHandle skillTarget = this.SkillComponent.SkillTarget;
			if (skillTarget != null && skillTarget.Valid)
			{
				baseActorComponent = skillTarget.Entity.GetComponent<BaseActorComponent>();
				FTransformDouble targetTransform = this.SkillComponent.GetTargetTransform();
				global::Vector vector2 = vector;
				FVectorDouble location = targetTransform.GetLocation();
				vector2.DeepCopy(location);
			}
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Character;
		ELogAuthor author = ELogAuthor.LYY;
		string message = "Qte设置位置开始";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("targetName", baseActorComponent.Owner);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("currentLocation", this.ActorComponent.ActorLocationProxy);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("targetLocation", vector);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		this.CreateSphereElement();
		this.InitTrack(this.SphereElement, baseActorComponent, characterActorComponent);
		this.CreateLineElement();
		this.InitTrack(this.LineElement, baseActorComponent, characterActorComponent);
		float radius = 0f;
		float halfHeight = 0f;
		CharacterActorComponent characterActorComponent2 = baseActorComponent as CharacterActorComponent;
		if (characterActorComponent2 != null)
		{
			radius = characterActorComponent2.ScaledRadius;
			halfHeight = characterActorComponent2.HalfHeight;
		}
		else
		{
			SceneItemActorComponent sceneItemActorComponent = baseActorComponent as SceneItemActorComponent;
			if (sceneItemActorComponent != null)
			{
				radius = (halfHeight = sceneItemActorComponent.GetRadius());
			}
		}
		ITargetParam targetParam = new ITargetParam
		{
			Location = vector,
			Radius = radius,
			HalfHeight = halfHeight
		};
		global::Vector vector3;
		string context;
		if (offsetParam.QteType == EQteType.InAir)
		{
			vector3 = this.GetQteLocationAir(characterActorComponent, offsetParam, targetParam);
			context = "Qte.设置空中位置";
		}
		else
		{
			vector3 = this.GetQteLocationLand(characterActorComponent, offsetParam, targetParam);
			context = "Qte.设置地面位置";
		}
		CharacterActorComponent actorComponent = this.ActorComponent;
		global::Vector actorLocationProxy = actorComponent.ActorLocationProxy;
		UTraceLineElement lineElement = this.LineElement;
		Singleton<TraceElementCommon>.Instance.SetStartLocation(lineElement, characterActorComponent.ActorLocationProxy);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(lineElement, vector3);
		bool flag = Singleton<TraceElementCommon>.Instance.LineTrace(lineElement, "RoleQteComponent_SetQtePosition");
		UKuroHitResult hitResult = lineElement.HitResult;
		if (flag && hitResult.bBlockingHit)
		{
			Singleton<TraceElementCommon>.Instance.GetHitLocation(hitResult, 0, vector3);
			global::Vector tempVector = this.TempVector;
			vector3.Subtraction(actorLocationProxy, tempVector);
			tempVector.Normalize(9.99999993922529E-09);
			tempVector.Multiply((double)actorComponent.ScaledRadius, tempVector);
			vector3.Subtraction(tempVector, vector3);
		}
		float scaledHalfHeight = actorComponent.ScaledHalfHeight;
		global::Vector vector4 = global::Vector.Create(vector3);
		global::Vector vector5 = global::Vector.Create(vector3);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(actorComponent, vector4, (double)scaledHalfHeight);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(actorComponent, vector5, (double)(-(double)scaledHalfHeight));
		this.SphereElement.Radius = actorComponent.ScaledRadius;
		Singleton<TraceElementCommon>.Instance.SetStartLocation(this.SphereElement, vector4);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(this.SphereElement, vector5);
		bool flag2 = Singleton<TraceElementCommon>.Instance.SphereTrace(this.SphereElement, "RoleQteComponent_SetQtePosition");
		UKuroHitResult hitResult2 = this.SphereElement.HitResult;
		if (flag2 && hitResult2.bBlockingHit)
		{
			global::Vector commonHitLocation = ModelBase<TraceElementModel>.Instance.CommonHitLocation;
			Singleton<TraceElementCommon>.Instance.GetHitLocation(hitResult2, 0, commonHitLocation);
			Singleton<GravityUtils>.Instance.AddZnInGravityForActor(actorComponent, commonHitLocation, (double)scaledHalfHeight);
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Character;
			ELogAuthor author2 = ELogAuthor.LYY;
			string message2 = "Qte设置位置，地面检测修正位置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("fixedLocation", commonHitLocation);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			actorComponent.SetActorLocation(commonHitLocation.ToUeVector(false), "Qte.修正位置", false);
			return;
		}
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module3 = ELogModule.Character;
		ELogAuthor author3 = ELogAuthor.LYY;
		string message3 = "Qte设置位置";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("location", vector3);
		instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		actorComponent.SetActorLocation(vector3.ToUeVector(false), context, false);
	}

	// Token: 0x0601A8CC RID: 108748 RVA: 0x007DC5AC File Offset: 0x007DA7AC
	private global::Vector GetQteLocationAir(CharacterActorComponent currentRole, IOffsetParam offsetParam, ITargetParam targetParam)
	{
		float num = offsetParam.Length;
		global::Vector vector = global::Vector.Create();
		currentRole.ActorLocationProxy.Subtraction(targetParam.Location, vector);
		if (vector.IsNearlyZero(9.999999747378752E-05))
		{
			vector.DeepCopy(currentRole.ActorForwardProxy);
		}
		else
		{
			num += targetParam.Radius;
		}
		Singleton<GravityUtils>.Instance.SetZnInGravityForActor(currentRole, vector, 0.0);
		vector.RotateAngleAxis((double)offsetParam.Rotate, currentRole.MoveComp.GravityUp, vector);
		vector.Normalize(9.99999993922529E-09);
		vector.Multiply((double)num, vector);
		global::Vector vector2 = global::Vector.Create();
		vector2.DeepCopy(targetParam.Location);
		vector2.Addition(vector, vector2);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(currentRole, vector2, (double)offsetParam.Height);
		global::Vector actorLocationProxy = currentRole.ActorLocationProxy;
		Singleton<TraceElementCommon>.Instance.SetStartLocation(this.SphereElement, actorLocationProxy);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(currentRole, vector2, (double)(targetParam.HalfHeight / 2f));
		Singleton<TraceElementCommon>.Instance.SetEndLocation(this.SphereElement, vector2);
		bool flag = Singleton<TraceElementCommon>.Instance.ShapeTrace(currentRole.Actor.CapsuleComponent, this.SphereElement, "RoleQteComponent_SetQtePosition", "RoleQteComponent_SetQtePosition");
		UKuroHitResult hitResult = this.SphereElement.HitResult;
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(currentRole, vector2, (double)(-(double)targetParam.HalfHeight / 2f));
		if (flag && hitResult.bBlockingHit)
		{
			global::Vector vector3 = global::Vector.Create();
			Singleton<TraceElementCommon>.Instance.GetHitLocation(this.SphereElement.HitResult, 0, vector3);
			global::Vector tempVector = this.TempVector;
			currentRole.ActorLocationProxy.Subtraction(vector3, tempVector);
			Singleton<GravityUtils>.Instance.SetZnInGravityForActor(currentRole, tempVector, 0.0);
			tempVector.Normalize(9.99999993922529E-09);
			float num2 = targetParam.Radius + currentRole.GetRadius();
			tempVector.Multiply((double)num2, tempVector);
			vector2.DeepCopy(vector3);
			vector2.Addition(tempVector, vector2);
			Singleton<GravityUtils>.Instance.AddZnInGravityForActor(currentRole, vector2, (double)offsetParam.Height);
		}
		return vector2;
	}

	// Token: 0x0601A8CD RID: 108749 RVA: 0x007DC7B8 File Offset: 0x007DA9B8
	private global::Vector GetQteLocationLand(CharacterActorComponent currentRole, IOffsetParam offsetParam, ITargetParam targetParam)
	{
		global::Vector vector = global::Vector.Create();
		vector.DeepCopy(targetParam.Location);
		float num = targetParam.HalfHeight - 5f;
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(currentRole, vector, (double)num);
		global::Vector vector2 = global::Vector.Create();
		currentRole.ActorLocationProxy.Subtraction(targetParam.Location, vector2);
		if (vector2.IsNearlyZero(9.999999747378752E-05))
		{
			vector2.DeepCopy(currentRole.ActorForwardProxy);
		}
		Singleton<GravityUtils>.Instance.SetZnInGravityForActor(currentRole, vector2, 0.0);
		vector2.RotateAngleAxis((double)offsetParam.Rotate, currentRole.MoveComp.GravityUp, vector2);
		vector2.Normalize(9.99999993922529E-09);
		float addHeight = num + offsetParam.Height - -1000f;
		float walkableFloorAngle = currentRole.Actor.CharacterMovement.K2_GetWalkableFloorAngle();
		float length = offsetParam.Length + targetParam.Radius;
		global::Vector vector3 = this.GetValidLocation(vector, vector2, length, addHeight, walkableFloorAngle);
		if (vector3 == null)
		{
			vector2.Normalize(9.99999993922529E-09);
			vector2.Multiply(-1.0, vector2);
			vector3 = this.GetValidLocation(vector, vector2, length, addHeight, walkableFloorAngle);
			if (vector3 == null)
			{
				vector3 = global::Vector.Create(currentRole.ActorLocationProxy);
			}
		}
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(currentRole, vector3, (double)offsetParam.Height);
		return vector3;
	}

	// Token: 0x0601A8CE RID: 108750 RVA: 0x007DC900 File Offset: 0x007DAB00
	[return: Nullable(2)]
	private global::Vector GetValidLocation(global::Vector startLocation, global::Vector direction, float length, float addHeight, float walkableFloorAngle)
	{
		UCapsuleComponent capsuleComponent = this.ActorComponent.Actor.CapsuleComponent;
		direction.Multiply((double)length, direction);
		global::Vector vector = global::Vector.Create();
		vector.DeepCopy(startLocation);
		global::Vector vector2 = global::Vector.Create();
		vector2.DeepCopy(vector);
		vector2.Addition(direction, vector2);
		UKuroHitResult hitResult = this.SphereElement.HitResult;
		if (hitResult != null)
		{
			hitResult.Clear();
		}
		Singleton<TraceElementCommon>.Instance.SetStartLocation(this.SphereElement, vector);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(this.SphereElement, vector2);
		bool flag = Singleton<TraceElementCommon>.Instance.ShapeTrace(capsuleComponent, this.SphereElement, "RoleQteComponent_SetQtePosition", "RoleQteComponent_SetQtePosition");
		UKuroHitResult hitResult2 = this.SphereElement.HitResult;
		global::Vector vector3 = global::Vector.Create();
		global::Vector vector4 = global::Vector.Create();
		vector.DeepCopy(vector2);
		if (flag && hitResult2.bBlockingHit)
		{
			Singleton<TraceElementCommon>.Instance.GetHitLocation(hitResult2, 0, vector3);
			Singleton<TraceElementCommon>.Instance.GetImpactNormal(hitResult2, 0, vector4);
			if (Singleton<MathUtils>.Instance.GetAngleByVectorDot(vector4, this.ActorComponent.MoveComp.GravityUp) > (double)walkableFloorAngle)
			{
				return null;
			}
			vector.DeepCopy(vector3);
		}
		double num = (double)length / Math.Tan((double)(walkableFloorAngle * 0.017453292f)) + (double)addHeight;
		vector2.DeepCopy(vector);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComponent, vector2, -num);
		UKuroHitResult hitResult3 = this.SphereElement.HitResult;
		if (hitResult3 != null)
		{
			hitResult3.Clear();
		}
		Singleton<TraceElementCommon>.Instance.SetStartLocation(this.SphereElement, vector);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(this.SphereElement, vector2);
		bool flag2 = Singleton<TraceElementCommon>.Instance.ShapeTrace(capsuleComponent, this.SphereElement, "RoleQteComponent_SetQtePosition", "RoleQteComponent_SetQtePosition");
		hitResult2 = this.SphereElement.HitResult;
		vector3.Reset();
		vector4.Reset();
		if (!flag2 || !hitResult2.bBlockingHit)
		{
			return null;
		}
		Singleton<TraceElementCommon>.Instance.GetHitLocation(hitResult2, 0, vector3);
		Singleton<TraceElementCommon>.Instance.GetImpactNormal(hitResult2, 0, vector4);
		if (Singleton<MathUtils>.Instance.GetAngleByVectorDot(vector4, this.ActorComponent.MoveComp.GravityUp) > (double)walkableFloorAngle)
		{
			return null;
		}
		return vector3;
	}

	// Token: 0x0601A8CF RID: 108751 RVA: 0x007DCAFC File Offset: 0x007DACFC
	private void SelectTarget(EntityHandle goDownPlayerHandle)
	{
		WorldEntity entity = goDownPlayerHandle.Entity;
		CharacterManipulateComponent component = entity.GetComponent<CharacterManipulateComponent>();
		bool flag = component != null && component.IsManipulating();
		CharacterSkillComponent component2 = entity.GetComponent<CharacterSkillComponent>();
		EntityHandle skillTarget = component2.SkillTarget;
		if (!flag && skillTarget != null && skillTarget.Valid)
		{
			WorldEntity entity2 = skillTarget.Entity;
			if (entity2 != null && entity2.Active)
			{
				BaseTagComponent component3 = skillTarget.Entity.GetComponent<BaseTagComponent>();
				if (component3 == null || !component3.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"]))
				{
					this.SkillComponent.SkillTarget = skillTarget;
					this.SkillComponent.SkillTargetSocket = component2.SkillTargetSocket;
					return;
				}
			}
		}
		CharacterLockOnComponent component4 = entity.GetComponent<CharacterLockOnComponent>();
		component4.DetectSoftLockTarget(new SkillTargetImpl
		{
			LockOnConfigId = new int?(4)
		}, true);
		this.SkillComponent.SkillTarget = component4.GetCurrentTarget();
		this.SkillComponent.SkillTargetSocket = component4.GetCurrentTargetSocketName();
	}

	// Token: 0x0601A8D0 RID: 108752 RVA: 0x007DCBE4 File Offset: 0x007DADE4
	private void OnQteTagTriggerChange(int tagId, bool bTagExists)
	{
		if (bTagExists)
		{
			this.QteTagMap[tagId] = ConfigBase<WorldConfig>.Instance.GetQteTagDataMap()[tagId];
			this.RefreshQteTagRowName();
			return;
		}
		string valueOrDefault = this.QteTagMap.GetValueOrDefault(tagId);
		this.QteTagMap.Remove(tagId);
		if (this.QteTagRowName == valueOrDefault)
		{
			this.RefreshQteTagRowName();
		}
	}

	// Token: 0x0601A8D1 RID: 108753 RVA: 0x007DCC48 File Offset: 0x007DAE48
	private void RefreshQteTagRowName()
	{
		UDataTable qteTagDataTable = ConfigBase<WorldConfig>.Instance.GetQteTagDataTable();
		int num = 0;
		foreach (string text in this.QteTagMap.Values)
		{
			SQteTag dataTableRow = DataTableUtil.GetDataTableRow<SQteTag>(qteTagDataTable, text);
			if ((int)dataTableRow.Priority >= num)
			{
				this.QteTagRowName = text;
				this.ElementComponent.TriggerEnergy = (float)dataTableRow.Energy;
				num = (int)dataTableRow.Priority;
			}
		}
		Singleton<EventSystem>.Instance.EmitWithTarget(base.Entity, EEventName.CharQteTagRowNameChanged);
	}

	// Token: 0x0601A8D2 RID: 108754 RVA: 0x007DCCF0 File Offset: 0x007DAEF0
	[NullableContext(2)]
	public SQteTag GetQteTagData()
	{
		if (!string.IsNullOrEmpty(this.QteTagRowName))
		{
			return DataTableUtil.GetDataTableRow<SQteTag>(ConfigBase<WorldConfig>.Instance.GetQteTagDataTable(), this.QteTagRowName);
		}
		return null;
	}

	// Token: 0x0601A8D3 RID: 108755 RVA: 0x007DCD18 File Offset: 0x007DAF18
	private long ExecuteQte2Server(EntityHandle goDownPlayerHandle)
	{
		ExecuteQtePush executeQtePush = ExecuteQtePush.Create();
		executeQtePush.DownEntityId = ModelBase<CreatureModel>.Instance.GetCreatureDataId(goDownPlayerHandle.Entity.Id);
		executeQtePush.UpEntityId = ModelBase<CreatureModel>.Instance.GetCreatureDataId(base.Entity.Id);
		executeQtePush.QteId = UGASBPLibrary.FnvHash(this.QteTagRowName);
		long num = ModelBase<CombatMessageModel>.Instance.GenMessageId();
		Singleton<CombatNet>.Instance.Send(EPushMessageId.ExecuteQtePush, base.Entity, executeQtePush, null, new long?(num), null);
		return num;
	}

	// Token: 0x0601A8D4 RID: 108756 RVA: 0x007DCDB0 File Offset: 0x007DAFB0
	[NullableContext(2)]
	[CombatListen(ENotifyMessageId.ExecuteQteNotify, true, false)]
	public static void ExecuteQteNotify(Entity entity, [Nullable(1)] ExecuteQteNotify data, CombatCommon combatCommon = null)
	{
		int entityId = ModelBase<CreatureModel>.Instance.GetEntityId(Singleton<MathUtils>.Instance.LongToNumber(data.UpEntityId));
		int entityId2 = ModelBase<CreatureModel>.Instance.GetEntityId(Singleton<MathUtils>.Instance.LongToNumber(data.DownEntityId));
		Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.CharExecuteMultiQte, entityId, entityId2);
	}

	// Token: 0x0601A8D5 RID: 108757 RVA: 0x007DCE04 File Offset: 0x007DB004
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		RoleQteComponent roleQteComponent = (RoleQteComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComponent"))
		{
			if (roleQteComponent.ActorComponent == null)
			{
				this.ActorComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComponent), "ActorComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AbilityComponent"))
		{
			if (roleQteComponent.AbilityComponent == null)
			{
				this.AbilityComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterAbilityComponent>(this.AbilityComponent), "AbilityComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComponent"))
		{
			if (roleQteComponent.TagComponent == null)
			{
				this.TagComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComponent), "TagComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("BuffComponent"))
		{
			if (roleQteComponent.BuffComponent == null)
			{
				this.BuffComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterBuffComponent>(this.BuffComponent), "BuffComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TeamComponent"))
		{
			if (roleQteComponent.TeamComponent == null)
			{
				this.TeamComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<RoleTeamComponent>(this.TeamComponent), "TeamComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SkillComponent"))
		{
			if (roleQteComponent.SkillComponent == null)
			{
				this.SkillComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterSkillComponent>(this.SkillComponent), "SkillComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ElementComponent"))
		{
			if (roleQteComponent.ElementComponent == null)
			{
				this.ElementComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<RoleElementComponent>(this.ElementComponent), "ElementComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SphereElement"))
		{
			if (roleQteComponent.SphereElement == null)
			{
				this.SphereElement = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UTraceSphereElement>(this.SphereElement), "SphereElement"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("LineElement"))
		{
			if (roleQteComponent.LineElement == null)
			{
				this.LineElement = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UTraceLineElement>(this.LineElement), "LineElement"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TempVector") && roleQteComponent.TempVector != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TempVector), "TempVector"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("ConsumedQteEntitySet") && roleQteComponent.ConsumedQteEntitySet != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<int>(this.ConsumedQteEntitySet), "ConsumedQteEntitySet"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("IsInQte"))
		{
			this.IsInQte = roleQteComponent.IsInQte;
		}
		if (base.CanResetComponentProperty("QteTagListeners") && roleQteComponent.QteTagListeners != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<ITagTask>>(this.QteTagListeners), "QteTagListeners"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("QteTagMap") && roleQteComponent.QteTagMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, string>>(this.QteTagMap), "QteTagMap"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("QteTagRowName"))
		{
			this.QteTagRowName = roleQteComponent.QteTagRowName;
		}
		if (base.CanResetComponentProperty("GoBattleActor"))
		{
			if (roleQteComponent.GoBattleActor == null)
			{
				this.GoBattleActor = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TsBaseCharacter>(this.GoBattleActor), "GoBattleActor"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400D6BD RID: 54973
	private const string PROFILE_KEY = "RoleQteComponent_SetQtePosition";

	// Token: 0x0400D6BE RID: 54974
	private const float DEFAULT_ADD_HEIGHT = -1000f;

	// Token: 0x0400D6BF RID: 54975
	private const float SUB_SIZE = 5f;

	// Token: 0x0400D6C0 RID: 54976
	private const int QTE_LOCKON_CONFIG_ID = 4;

	// Token: 0x0400D6C1 RID: 54977
	private readonly int normalQteTag = GameplayTagDefine.EGameplayTagId["功能.功能制作.QTE.普通QTE"];

	// Token: 0x0400D6C2 RID: 54978
	public const float MAX_MULTI_QTE_DISTANCE = 5000f;

	// Token: 0x0400D6C3 RID: 54979
	[Nullable(2)]
	private CharacterActorComponent ActorComponent;

	// Token: 0x0400D6C4 RID: 54980
	[Nullable(2)]
	private CharacterAbilityComponent AbilityComponent;

	// Token: 0x0400D6C5 RID: 54981
	[Nullable(2)]
	private BaseTagComponent TagComponent;

	// Token: 0x0400D6C6 RID: 54982
	[Nullable(2)]
	private CharacterBuffComponent BuffComponent;

	// Token: 0x0400D6C7 RID: 54983
	[Nullable(2)]
	private RoleTeamComponent TeamComponent;

	// Token: 0x0400D6C8 RID: 54984
	[Nullable(2)]
	private CharacterSkillComponent SkillComponent;

	// Token: 0x0400D6C9 RID: 54985
	[Nullable(2)]
	private RoleElementComponent ElementComponent;

	// Token: 0x0400D6CA RID: 54986
	[Nullable(2)]
	private UTraceSphereElement SphereElement;

	// Token: 0x0400D6CB RID: 54987
	[Nullable(2)]
	private UTraceLineElement LineElement;

	// Token: 0x0400D6CC RID: 54988
	private readonly global::Vector TempVector = global::Vector.Create();

	// Token: 0x0400D6CD RID: 54989
	private readonly HashSet<int> ConsumedQteEntitySet = new HashSet<int>();

	// Token: 0x0400D6CE RID: 54990
	public bool IsInQte;

	// Token: 0x0400D6CF RID: 54991
	private readonly List<ITagTask> QteTagListeners = new List<ITagTask>();

	// Token: 0x0400D6D0 RID: 54992
	private readonly Dictionary<int, string> QteTagMap = new Dictionary<int, string>();

	// Token: 0x0400D6D1 RID: 54993
	private string QteTagRowName = "";

	// Token: 0x0400D6D2 RID: 54994
	[Nullable(2)]
	public TsBaseCharacter GoBattleActor;
}
