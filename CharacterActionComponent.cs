using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.NewWorld.SceneItem;
using CSharpScript.Game.Utils;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002FEB RID: 12267
[NullableContext(1)]
[Nullable(0)]
public class CharacterActionComponent : EntityComponent, IComponentDependency
{
	// Token: 0x1700219B RID: 8603
	// (get) Token: 0x06018FDF RID: 102367 RVA: 0x007162A1 File Offset: 0x007144A1
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public static Type[] Dependencies
	{
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		get
		{
			return new Type[]
			{
				typeof(CharacterActorComponent),
				typeof(CharacterUnifiedStateComponent),
				typeof(BaseTagComponent)
			};
		}
	}

	// Token: 0x1700219C RID: 8604
	// (get) Token: 0x06018FE0 RID: 102368 RVA: 0x007162D0 File Offset: 0x007144D0
	public bool IsSitDown
	{
		get
		{
			return this.IsSitDownInternal;
		}
	}

	// Token: 0x06018FE1 RID: 102369 RVA: 0x007162D8 File Offset: 0x007144D8
	public unsafe void SetIsSitDown(bool isSitDown, string reason)
	{
		if (this.IsSitDownInternal != isSitDown)
		{
			this.IsSitDownInternal = isSitDown;
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.WLJ;
			string message = "SetIsSitDown";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("isSitDown", isSitDown);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("reason", reason);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (!isSitDown && this.ChairInternal != null && this.ChairNeedSetMorph)
			{
				ControllerBase<AnimController>.Instance.SetSeatMorph(this.ChairInternal, base.Entity.Id, 0.0);
			}
			if (this.IsSitDownInternal)
			{
				BaseTagComponent tagComp = this.TagComp;
				if (tagComp != null)
				{
					tagComp.AddTag(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.不能切人"]));
				}
			}
			else
			{
				BaseTagComponent tagComp2 = this.TagComp;
				if (tagComp2 != null)
				{
					tagComp2.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.不能切人"]));
				}
			}
			Singleton<EventSystem>.Instance.EmitWithTarget<ECharacterActionType, bool>(base.Entity, EEventName.CharActionStateChange, ECharacterActionType.Sit, isSitDown);
		}
	}

	// Token: 0x1700219D RID: 8605
	// (get) Token: 0x06018FE2 RID: 102370 RVA: 0x007163F4 File Offset: 0x007145F4
	// (set) Token: 0x06018FE3 RID: 102371 RVA: 0x007163FC File Offset: 0x007145FC
	[Nullable(2)]
	public Entity Chair
	{
		[NullableContext(2)]
		get
		{
			return this.ChairInternal;
		}
		[NullableContext(2)]
		set
		{
			if (this.ChairInternal != value)
			{
				if (this.ChairInternal != null && Singleton<EventSystem>.Instance.HasWithTarget(this.ChairInternal, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveChair)))
				{
					Singleton<EventSystem>.Instance.RemoveWithTarget(this.ChairInternal, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveChair));
				}
				if (value != null && !Singleton<EventSystem>.Instance.HasWithTarget(value, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveChair)))
				{
					Singleton<EventSystem>.Instance.AddWithTarget<ERemoveEntityType, EntityHandle>(value, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveChair));
				}
				this.ChairInternal = value;
				bool? flag;
				if (value == null)
				{
					flag = null;
				}
				else
				{
					SceneItemProceduralMaterialComponent component = value.GetComponent<SceneItemProceduralMaterialComponent>();
					flag = ((component != null) ? new bool?(component.HasCustomType(SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType.Chair)) : null);
				}
				bool? flag2 = flag;
				this.ChairNeedSetMorph = flag2.GetValueOrDefault();
			}
		}
	}

	// Token: 0x06018FE4 RID: 102372 RVA: 0x007164E3 File Offset: 0x007146E3
	private void OnRemoveChair(ERemoveEntityType removeType, EntityHandle handle)
	{
		this.Chair = null;
	}

	// Token: 0x06018FE5 RID: 102373 RVA: 0x007164EC File Offset: 0x007146EC
	private void OnSitDownEndChanged(int tagId, bool tagExist)
	{
		if (!tagExist)
		{
			this.LeaveSitDownAction();
		}
	}

	// Token: 0x06018FE6 RID: 102374 RVA: 0x007164F8 File Offset: 0x007146F8
	private void OnDisableTagChanged(int tagId, bool tagExist)
	{
		if (tagExist && this.IsSitDown)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
			defaultInterpolatedStringHandler.AppendLiteral("OnDisableTagChanged ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(tagId);
			this.PreLeaveSitDownAction(defaultInterpolatedStringHandler.ToStringAndClear());
		}
	}

	// Token: 0x06018FE7 RID: 102375 RVA: 0x0071653C File Offset: 0x0071473C
	protected override bool OnStart()
	{
		this.ActorComp = base.Entity.CheckGetComponent<CharacterActorComponent>();
		this.OriginCapsuleRadius = this.ActorComp.Radius;
		this.OriginCapsuleHalfHeight = this.ActorComp.HalfHeight;
		this.StateComp = base.Entity.GetComponent<CharacterUnifiedStateComponent>();
		this.MoveComp = base.Entity.GetComponent<CharacterMoveComponent>();
		this.SkillComp = base.Entity.GetComponent<CharacterSkillComponent>();
		if (this.StateComp == null)
		{
			return false;
		}
		this.TagComp = base.Entity.GetComponent<BaseTagComponent>();
		if (this.TagComp == null)
		{
			return false;
		}
		this.SetIsSitDown(false, "OnStart");
		this.Chair = null;
		this.Giant = null;
		this.MarkForResetCollision = false;
		this.IsInit = false;
		this.OnSuperJumpTask = this.TagComp.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.超级跳跃"]), new BaseTagComponent.TTagSwitchedCallback(this.OnSuperJumpStateChanged), null);
		return true;
	}

	// Token: 0x06018FE8 RID: 102376 RVA: 0x00716630 File Offset: 0x00714830
	protected override void OnActivate()
	{
		if (!this.ActorComp.IsAutonomousProxy || this.IsInit)
		{
			return;
		}
		this.OnSitDownEndChangedTask = this.TagComp.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["角色.BaseRole.状态通用标识.动作.坐下.结束"]), new BaseTagComponent.TTagSwitchedCallback(this.OnSitDownEndChanged), null);
		BaseTagComponent tagComp = this.TagComp;
		if (tagComp != null && tagComp.Valid)
		{
			foreach (int value in CharacterActionComponent.DisableTags)
			{
				this.TagListeners.Add(this.TagComp.ListenForTagAddOrRemove(new int?(value), new BaseTagComponent.TTagSwitchedCallback(this.OnDisableTagChanged), null));
			}
		}
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.TeleportStart, new Action<bool>(this.TeleportStart));
		Singleton<EventSystem>.Instance.Add<PlotInfo>(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.PlotNetworkStart));
		this.IsInit = true;
	}

	// Token: 0x06018FE9 RID: 102377 RVA: 0x00716719 File Offset: 0x00714919
	private void TeleportStart(bool b)
	{
		if (this.IsSitDown)
		{
			this.PreLeaveSitDownAction("TeleportStart");
		}
	}

	// Token: 0x06018FEA RID: 102378 RVA: 0x0071672E File Offset: 0x0071492E
	private void PlotNetworkStart(PlotInfo plotInfo)
	{
		if (this.IsSitDown && plotInfo.PlotLevel != EPlotLevel.LevelD && plotInfo.PlotLevel != EPlotLevel.LevelE && !plotInfo.KeepMainRolePose)
		{
			this.PreLeaveSitDownAction("PlotNetworkStart");
		}
	}

	// Token: 0x06018FEB RID: 102379 RVA: 0x00716760 File Offset: 0x00714960
	protected override bool OnEnd()
	{
		if (!this.IsInit)
		{
			return true;
		}
		if (this.IsSitDown)
		{
			this.PreLeaveSitDownAction("OnEnd");
		}
		this.OnSitDownEndChangedTask.EndTask();
		this.OnSitDownEndChangedTask = null;
		this.OnSuperJumpTask.EndTask();
		this.OnSuperJumpTask = null;
		foreach (ITagTask tagTask in this.TagListeners)
		{
			tagTask.EndTask();
		}
		this.TagListeners.Clear();
		Singleton<EventSystem>.Instance.Remove(EEventName.TeleportStart, new Action<bool>(this.TeleportStart));
		Singleton<EventSystem>.Instance.Remove(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.PlotNetworkStart));
		return true;
	}

	// Token: 0x06018FEC RID: 102380 RVA: 0x00716838 File Offset: 0x00714A38
	protected override void OnTick(float delta)
	{
		if (!this.ActorComp.IsAutonomousProxy)
		{
			return;
		}
		if (this.IsSitDown)
		{
			if (this.Chair != null && this.ChairNeedSetMorph)
			{
				CharacterActorComponent actorComp = this.ActorComp;
				float? num;
				if (actorComp == null)
				{
					num = null;
				}
				else
				{
					USkeletalMeshComponent mesh = actorComp.Actor.Mesh;
					if (mesh == null)
					{
						num = null;
					}
					else
					{
						UAnimInstance animInstance = mesh.GetAnimInstance();
						num = ((animInstance != null) ? new float?(animInstance.GetCurveValue(Singleton<CharacterNameDefines>.Instance.SEAT_MORPH)) : null);
					}
				}
				float? num2 = num;
				float valueOrDefault = num2.GetValueOrDefault();
				ControllerBase<AnimController>.Instance.SetSeatMorph(this.Chair, base.Entity.Id, (double)valueOrDefault);
			}
			if (this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["角色.BaseRole.状态通用标识.动作.坐下.持续"]) && this.MoveComp.HasMoveInput)
			{
				this.PreLeaveSitDownAction("HasMoveInput");
			}
		}
		if (this.MarkForResetCollision)
		{
			global::Vector actorLocationProxy = this.Chair.GetComponent<SceneItemActorComponent>().ActorLocationProxy;
			global::Vector actorLocationProxy2 = this.ActorComp.ActorLocationProxy;
			global::Vector actorForwardProxy = this.ActorComp.ActorForwardProxy;
			double num3 = Vector2D.Create(actorLocationProxy2.X - actorLocationProxy.X, actorLocationProxy2.Y - actorLocationProxy.Y).DotProduct(this.MainChairDir);
			Vector2D vector2D = Vector2D.Create(actorForwardProxy.X, actorForwardProxy.Y);
			vector2D.Normalize(9.99999993922529E-09);
			float value = (float)(Math.Acos(this.StandUpActorForward.DotProduct(vector2D)) * 57.295780181884766);
			if (num3 < 15.0 || (num3 > 50.0 && this.MoveComp.HasMoveInput) || Math.Abs(value) > 91f)
			{
				this.ResetCollision();
			}
		}
		if (this.IsRotatingBeforeManipulate && this.ActorComp.ActorRotationProxy.Equals(this.ActorComp.InputRotatorProxy, 0.0001f))
		{
			this.IsRotatingBeforeManipulate = false;
			this.TagComp.AddTag(new int?(GameplayTagDefine.EGameplayTagId["角色.BaseRole.状态通用标识.动作.操控巨物.开始"]));
			CharacterInputComponent component = base.Entity.GetComponent<CharacterInputComponent>();
			ControllerBase<InputController>.Instance.AddInputHandler(component);
			ControllerBase<CameraController>.Instance.SetInputEnable(Global.BaseCharacter, true, "MainCamera");
		}
	}

	// Token: 0x06018FED RID: 102381 RVA: 0x00716A80 File Offset: 0x00714C80
	private void IgnoreActorsCollision(SceneItemActorComponent actorComp, bool bCollision)
	{
		CreatureDataComponent component = actorComp.Entity.GetComponent<CreatureDataComponent>();
		int pbDataId = (component != null) ? component.GetPbDataId() : 0;
		int? ownerEntity = ModelBase<CreatureModel>.Instance.GetOwnerEntity(pbDataId);
		SceneItemActorComponent sceneItemActorComponent;
		if (ownerEntity != null)
		{
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(ownerEntity.Value);
			if (entityByPbDataId != null && entityByPbDataId.Valid)
			{
				sceneItemActorComponent = entityByPbDataId.Entity.GetComponent<SceneItemActorComponent>();
			}
			else
			{
				sceneItemActorComponent = actorComp;
			}
		}
		else
		{
			sceneItemActorComponent = actorComp;
		}
		TArray<AActor> tarray = new TArray<AActor>();
		sceneItemActorComponent.Owner.GetAttachedActors(ref tarray, true);
		int num = tarray.Num();
		for (int i = 0; i < num; i++)
		{
			AActor aactor = tarray.Get(i);
			TArray<AActor> tarray2 = new TArray<AActor>();
			aactor.GetAttachedActors(ref tarray2, true);
			int num2 = tarray2.Num();
			for (int j = 0; j < num2; j++)
			{
				this.ActorComp.Actor.CapsuleComponent.IgnoreActorWhenMoving(tarray2.Get(j), bCollision);
			}
		}
	}

	// Token: 0x06018FEE RID: 102382 RVA: 0x00716B70 File Offset: 0x00714D70
	public void ResetCollision()
	{
		this.MarkForResetCollision = false;
		this.ActorComp.Actor.CapsuleComponent.SetCollisionResponseToChannel(ECollisionChannel.ECC_Pawn, ECollisionResponse.ECR_Block);
		if (this.Chair == null)
		{
			return;
		}
		SceneItemActorComponent component = this.Chair.GetComponent<SceneItemActorComponent>();
		if (component != null && component.Entity != null)
		{
			this.IgnoreActorsCollision(component, false);
		}
		this.Chair = null;
	}

	// Token: 0x06018FEF RID: 102383 RVA: 0x00716BCA File Offset: 0x00714DCA
	public bool GetSitDownState()
	{
		return this.IsSitDown;
	}

	// Token: 0x06018FF0 RID: 102384 RVA: 0x00716BD4 File Offset: 0x00714DD4
	public bool EnterSitDownAction(Entity sceneItem, int type, bool limitStandUpFromOneSide = false)
	{
		if (this.TagComp.HasAnyTag(new int[]
		{
			GameplayTagDefine.EGameplayTagId["角色.BaseRole.状态通用标识.动作.坐下"],
			GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止坐下"],
			GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"]
		}))
		{
			return false;
		}
		SceneItemActorComponent component = sceneItem.GetComponent<SceneItemActorComponent>();
		if (component == null)
		{
			return false;
		}
		if (this.MarkForResetCollision && this.Chair != null)
		{
			this.ResetCollision();
		}
		this.SkillComp.StopAllSkills("CharacterActionComponent.EnterSitDownAction");
		this.SitDownTypeIndex = type;
		this.EnterSitDownIndex = this.IsChairCanInteract(sceneItem) - EChairInteractDirection.Forward;
		this.LimitStandUpFromOneSide = limitStandUpFromOneSide;
		Singleton<EventSystem>.Instance.EmitWithTarget<ECharacterActionType>(base.Entity, EEventName.OnBeforeCharActionWithTarget, ECharacterActionType.Sit);
		this.SetIsSitDown(true, "角色进入坐下动作");
		this.MarkForResetCollision = false;
		this.Chair = sceneItem;
		this.RegisterSitSpecialAnimMachineState();
		ControllerBase<HoldingHandsController>.Instance.SitOnCharCheckHoldHands(base.Entity, component);
		return true;
	}

	// Token: 0x06018FF1 RID: 102385 RVA: 0x00716CC4 File Offset: 0x00714EC4
	private void RegisterSitSpecialAnimMachineState()
	{
		this.RequestSitDownAction(null, null);
	}

	// Token: 0x06018FF2 RID: 102386 RVA: 0x00716CD0 File Offset: 0x00714ED0
	[NullableContext(2)]
	private void RequestSitDownAction(List<int> states, List<int> specialStates)
	{
		long creatureDataId = 0L;
		if (this.Chair != null)
		{
			CreatureDataComponent component = this.Chair.GetComponent<CreatureDataComponent>();
			creatureDataId = ((component != null) ? component.GetCreatureDataId() : 0L);
		}
		AnimationStateChangedRequest animationStateChangedRequest = AnimationStateChangedRequest.Create();
		if (states != null)
		{
			animationStateChangedRequest.States.AddRange(states);
			if (animationStateChangedRequest.States.Count > 600)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Interaction;
				ELogAuthor author = ELogAuthor.ZQR;
				string message = "RequestSitDownAction同步数据过大";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("States", animationStateChangedRequest.States);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}
		if (specialStates != null)
		{
			animationStateChangedRequest.SpecialStates.AddRange(specialStates);
		}
		ControllerBase<LevelGamePlayController>.Instance.RequestChairSit(creatureDataId, this.IsSitDown, animationStateChangedRequest);
	}

	// Token: 0x06018FF3 RID: 102387 RVA: 0x00716D78 File Offset: 0x00714F78
	public void OnResponseSit(bool isSitDown, int errorCode)
	{
		if (errorCode != 0)
		{
			this.SetIsSitDown(!isSitDown, "服务器返回错误");
		}
	}

	// Token: 0x06018FF4 RID: 102388 RVA: 0x00716D8C File Offset: 0x00714F8C
	public void DoSitDownAction()
	{
		if (this.Chair == null)
		{
			return;
		}
		this.TempVector.Reset();
		this.MoveComp.SetForceSpeed(this.TempVector);
		SceneItemActorComponent component = this.Chair.GetComponent<SceneItemActorComponent>();
		PawnInteractNewComponent component2 = this.Chair.GetComponent<PawnInteractNewComponent>();
		this.TempVector.DeepCopy(component2.GetInteractPoint());
		this.TempVector.Z += (double)this.OriginCapsuleHalfHeight;
		this.TempRotator.DeepCopy(component.ActorRotationProxy);
		this.TempRotator.Yaw += 90f;
		this.ActorComp.SetInputRotator(this.TempRotator);
		this.ActorComp.SetActorLocationAndRotation(this.TempVector.ToUeVector(false), this.TempRotator.ToUeRotator(), "角色坐下", false, null);
		ControllerBase<CameraController>.Instance.MainModel.FightCamera.GetComponent<FightCameraLogicComponent>().ResetArmLocation(true, 0.5f);
		this.IgnoreCollision();
	}

	// Token: 0x06018FF5 RID: 102389 RVA: 0x00716E90 File Offset: 0x00715090
	private void IgnoreCollision()
	{
		SceneItemActorComponent component = this.Chair.GetComponent<SceneItemActorComponent>();
		if (component != null && component.Entity != null)
		{
			this.IgnoreActorsCollision(component, true);
		}
		this.ActorComp.Actor.CapsuleComponent.SetCollisionResponseToChannel(ECollisionChannel.ECC_Pawn, ECollisionResponse.ECR_Ignore);
	}

	// Token: 0x06018FF6 RID: 102390 RVA: 0x00716ED4 File Offset: 0x007150D4
	public void PreLeaveSitDownAction(string reason = "")
	{
		this.SetIsSitDown(false, reason);
		this.IsStandingUp = true;
		if (this.LimitStandUpFromOneSide)
		{
			this.LeaveSitDownIndex = 0;
			this.LimitStandUpFromOneSide = false;
		}
		else
		{
			this.CalculateLeaveSitDownIndex();
		}
		this.RequestSitDownAction(null, null);
		Action onLeaveSitDown = this.OnLeaveSitDown;
		if (onLeaveSitDown == null)
		{
			return;
		}
		onLeaveSitDown();
	}

	// Token: 0x06018FF7 RID: 102391 RVA: 0x00716F28 File Offset: 0x00715128
	private void CalculateLeaveSitDownIndex()
	{
		if (this.Chair == null || this.Chair.IsEnd)
		{
			this.Chair = null;
			return;
		}
		this.ActorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
		{
			Mode = EMovementMode.MOVE_Walking,
			Context = "[CharacterActionComponent.CalculateLeaveSitDownIndex]"
		});
		this.TempVector.DeepCopy(this.ActorComp.InputDirectProxy);
		this.TempVector.Normalize(9.99999993922529E-09);
		IInteractSectorRange sectorRange = this.Chair.GetComponent<PawnInteractNewComponent>().GetInteractController().SectorRange;
		if (this.TempVector.DotProduct(this.ActorComp.ActorForwardProxy) > 0.800000011920929 || sectorRange == null)
		{
			this.LeaveSitDownIndex = 0;
			return;
		}
		this.TempVector.CrossProduct(this.ActorComp.ActorForwardProxy, this.TempVector2);
		if (this.TempVector2.Z >= 0.0)
		{
			if (sectorRange.Begin < -45f)
			{
				this.LeaveSitDownIndex = 1;
				return;
			}
			this.LeaveSitDownIndex = 0;
			return;
		}
		else
		{
			if (sectorRange.End > 45f)
			{
				this.LeaveSitDownIndex = 2;
				return;
			}
			this.LeaveSitDownIndex = 0;
			return;
		}
	}

	// Token: 0x06018FF8 RID: 102392 RVA: 0x00717051 File Offset: 0x00715251
	public void LeaveSitDownAction()
	{
		this.IsStandingUp = false;
		if (this.Chair == null)
		{
			return;
		}
		if (!this.ActorComp.IsAutonomousProxy)
		{
			return;
		}
		this.MarkForResetCollision = true;
		this.CalculateChairDir();
	}

	// Token: 0x06018FF9 RID: 102393 RVA: 0x00717080 File Offset: 0x00715280
	public void CalculateChairDir()
	{
		if (this.Chair == null || this.ActorComp == null)
		{
			return;
		}
		global::Vector actorLocationProxy = this.Chair.GetComponent<SceneItemActorComponent>().ActorLocationProxy;
		global::Vector actorLocationProxy2 = this.ActorComp.ActorLocationProxy;
		global::Vector actorForwardProxy = this.ActorComp.ActorForwardProxy;
		this.MainChairDir = Vector2D.Create(actorLocationProxy2.X - actorLocationProxy.X, actorLocationProxy2.Y - actorLocationProxy.Y);
		this.MainChairDir.Normalize(9.99999993922529E-09);
		this.StandUpActorForward = Vector2D.Create(actorForwardProxy.X, actorForwardProxy.Y);
		this.StandUpActorForward.Normalize(9.99999993922529E-09);
	}

	// Token: 0x06018FFA RID: 102394 RVA: 0x00717130 File Offset: 0x00715330
	public EChairInteractDirection IsChairCanInteract(Entity sceneItem)
	{
		SceneItemActorComponent component = sceneItem.GetComponent<SceneItemActorComponent>();
		if (component == null)
		{
			return EChairInteractDirection.None;
		}
		this.ActorComp.ActorLocationProxy.Subtraction(component.ActorLocationProxy, this.TempVector);
		this.TempVector.Z = 0.0;
		this.TempVector.Normalize(9.99999993922529E-09);
		float num = (float)(Math.Acos(this.TempVector.DotProduct(component.ActorRightProxy)) * 57.295780181884766);
		this.TempVector.CrossProduct(component.ActorRightProxy, this.TempVector2);
		if (this.TempVector2.Z < 0.0)
		{
			num *= -1f;
		}
		if (num >= -50f && num <= 50f)
		{
			return EChairInteractDirection.Forward;
		}
		if (num >= 50f && num <= 140f)
		{
			return EChairInteractDirection.Left;
		}
		if (num >= -140f && num <= -50f)
		{
			return EChairInteractDirection.Right;
		}
		return EChairInteractDirection.Backward;
	}

	// Token: 0x06018FFB RID: 102395 RVA: 0x0071721D File Offset: 0x0071541D
	public void StartCatapult(Entity entity, ICatapult config)
	{
		this.StartCatapultInternal(entity, new OneOf<ICatapult, ISuperCatapult>?(config));
	}

	// Token: 0x06018FFC RID: 102396 RVA: 0x00717231 File Offset: 0x00715431
	public void StartCatapult(Entity entity, ISuperCatapult config)
	{
		this.StartCatapultInternal(entity, new OneOf<ICatapult, ISuperCatapult>?(config));
	}

	// Token: 0x06018FFD RID: 102397 RVA: 0x00717248 File Offset: 0x00715448
	private void StartCatapultInternal(Entity entity, [Nullable(new byte[]
	{
		0,
		1,
		1
	})] OneOf<ICatapult, ISuperCatapult>? config)
	{
		if (entity == null)
		{
			return;
		}
		if (config.Value.IsT1 && config.Value.AsT1.Param == null)
		{
			return;
		}
		if (config.Value.IsT2 && config.Value.AsT2.Param == null)
		{
			return;
		}
		CharacterCatapultComponent catapultComp = base.Entity.GetComponent<CharacterCatapultComponent>();
		if (catapultComp == null)
		{
			return;
		}
		if (this.SkillComp == null)
		{
			return;
		}
		ELeisureInteract? eleisureInteract = null;
		ICatapultParam param = null;
		if (config.Value.IsT1)
		{
			eleisureInteract = new ELeisureInteract?(config.Value.AsT1.Type);
			param = config.Value.AsT1.Param;
		}
		else
		{
			eleisureInteract = new ELeisureInteract?(config.Value.AsT2.Type);
			param = config.Value.AsT2.Param;
		}
		bool isSuperCatapult = eleisureInteract.Value == ELeisureInteract.SuperCatapult;
		int skillId = isSuperCatapult ? 400107 : 400102;
		this.SkillComp.BeginSkillAsync(skillId, new SkillParam
		{
			Reason = "CharacterActionComponent.StartCatapult"
		}).ContinueWith(delegate(bool result)
		{
			if (result)
			{
				Entity entity2 = this.Entity;
				if (entity2 != null && entity2.Valid)
				{
					BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
					FTransformDouble? ftransformDouble = null;
					if (component != null && component.Valid)
					{
						AActor owner = component.Owner;
						ftransformDouble = ((owner != null) ? new FTransformDouble?(owner.D_GetTransform()) : null);
					}
					else
					{
						CreatureDataComponent component2 = entity.GetComponent<CreatureDataComponent>();
						ftransformDouble = ((component2 != null) ? new FTransformDouble?(component2.D_GetTransform()) : null);
					}
					global::Vector vector = global::Vector.Create(ftransformDouble.Value.GetLocation());
					Quat quat = Quat.Create(ftransformDouble.Value.GetRotation());
					float valueOrDefault = param.Time.GetValueOrDefault(0.6f);
					float valueOrDefault2 = param.Gravity.GetValueOrDefault(1960f);
					CharacterActionComponent.TmpVector.FromConfigVector(param.P1);
					quat.RotateVector(CharacterActionComponent.TmpVector, CharacterActionComponent.TmpVector);
					CharacterActionComponent.TmpVector.AdditionEqual(vector);
					CharacterActionComponent.TmpVector2.FromConfigVector(param.P2);
					quat.RotateVector(CharacterActionComponent.TmpVector2, CharacterActionComponent.TmpVector2);
					CharacterActionComponent.TmpVector2.AdditionEqual(vector);
					catapultComp.SetConfig(valueOrDefault, vector, global::Vector.Create(CharacterActionComponent.TmpVector), global::Vector.Create(CharacterActionComponent.TmpVector2), string.Empty, valueOrDefault2, null, (component != null) ? component.ActorGravityDirectProxy : null, isSuperCatapult);
					global::Vector vector2 = global::Vector.Create(CharacterActionComponent.TmpVector);
					vector2.SubtractionEqual(vector);
					vector2.Normalize(9.99999993922529E-09);
					global::Vector inA = global::Vector.Create(0.0, 0.0, 1.0);
					double num = Singleton<MathUtils>.Instance.DotProduct(inA, vector2);
					this.IsUseCatapultUpAnim = (num > Math.Cos((double)(this.GetAnimChangeAngle() / 2f / 180f) * 3.141592653589793));
					this.InteractionTargetLocation.DeepCopy(CharacterActionComponent.TmpVector2);
					return;
				}
			}
		});
	}

	// Token: 0x06018FFE RID: 102398 RVA: 0x007173C4 File Offset: 0x007155C4
	public void EndCatapult()
	{
	}

	// Token: 0x06018FFF RID: 102399 RVA: 0x007173C8 File Offset: 0x007155C8
	[return: Nullable(0)]
	public UniTask<bool> StartCatapultToTargetByTime(global::Vector targetLocation, global::Vector locationOffset, float time1, int skillId = 0)
	{
		CharacterActionComponent.<StartCatapultToTargetByTime>d__88 <StartCatapultToTargetByTime>d__;
		<StartCatapultToTargetByTime>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<StartCatapultToTargetByTime>d__.<>4__this = this;
		<StartCatapultToTargetByTime>d__.targetLocation = targetLocation;
		<StartCatapultToTargetByTime>d__.locationOffset = locationOffset;
		<StartCatapultToTargetByTime>d__.time1 = time1;
		<StartCatapultToTargetByTime>d__.skillId = skillId;
		<StartCatapultToTargetByTime>d__.<>1__state = -1;
		<StartCatapultToTargetByTime>d__.<>t__builder.Start<CharacterActionComponent.<StartCatapultToTargetByTime>d__88>(ref <StartCatapultToTargetByTime>d__);
		return <StartCatapultToTargetByTime>d__.<>t__builder.Task;
	}

	// Token: 0x06019000 RID: 102400 RVA: 0x0071742C File Offset: 0x0071562C
	public UniTask StartBounce(IBounce config)
	{
		CharacterActionComponent.<StartBounce>d__89 <StartBounce>d__;
		<StartBounce>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<StartBounce>d__.<>4__this = this;
		<StartBounce>d__.config = config;
		<StartBounce>d__.<>1__state = -1;
		<StartBounce>d__.<>t__builder.Start<CharacterActionComponent.<StartBounce>d__89>(ref <StartBounce>d__);
		return <StartBounce>d__.<>t__builder.Task;
	}

	// Token: 0x06019001 RID: 102401 RVA: 0x00717478 File Offset: 0x00715678
	public void StartBounceFromAns(float time, float height, string curvePath)
	{
		CharacterCatapultComponent component = base.Entity.GetComponent<CharacterCatapultComponent>();
		if (component == null)
		{
			return;
		}
		Entity entity = base.Entity;
		if (entity == null || !entity.Valid)
		{
			return;
		}
		global::Vector actorLocationProxy = this.ActorComp.ActorLocationProxy;
		CharacterActionComponent.TmpVector.DeepCopy(actorLocationProxy);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, CharacterActionComponent.TmpVector, (double)height);
		component.SetConfig((time != 0f) ? time : 2f, actorLocationProxy, CharacterActionComponent.TmpVector, CharacterActionComponent.TmpVector, curvePath, 0f, this.ActorComp.ActorRotationProxy, this.ActorComp.ActorGravityDirectProxy, false);
		this.IsUseCatapultUpAnim = false;
	}

	// Token: 0x06019002 RID: 102402 RVA: 0x00717520 File Offset: 0x00715720
	[return: Nullable(0)]
	public UniTask<bool> StartBounceWithHorizontalOffset(float height, global::Vector offset, float time, string curve)
	{
		CharacterActionComponent.<StartBounceWithHorizontalOffset>d__91 <StartBounceWithHorizontalOffset>d__;
		<StartBounceWithHorizontalOffset>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<StartBounceWithHorizontalOffset>d__.<>4__this = this;
		<StartBounceWithHorizontalOffset>d__.height = height;
		<StartBounceWithHorizontalOffset>d__.offset = offset;
		<StartBounceWithHorizontalOffset>d__.time = time;
		<StartBounceWithHorizontalOffset>d__.curve = curve;
		<StartBounceWithHorizontalOffset>d__.<>1__state = -1;
		<StartBounceWithHorizontalOffset>d__.<>t__builder.Start<CharacterActionComponent.<StartBounceWithHorizontalOffset>d__91>(ref <StartBounceWithHorizontalOffset>d__);
		return <StartBounceWithHorizontalOffset>d__.<>t__builder.Task;
	}

	// Token: 0x06019003 RID: 102403 RVA: 0x00717584 File Offset: 0x00715784
	public void EndBounce()
	{
		if (this.SkillComp == null)
		{
			return;
		}
		global::Skill currentSkill = this.SkillComp.CurrentSkill;
		if (currentSkill != null && currentSkill.SkillId != 400104)
		{
			return;
		}
		CharacterMoveComponent component = base.Entity.GetComponent<CharacterMoveComponent>();
		component.SetForceSpeed(global::Vector.ZeroVectorProxy);
		CharacterActorComponent actorComp = component.ActorComp;
		if (actorComp == null)
		{
			return;
		}
		actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
		{
			Mode = EMovementMode.MOVE_Falling,
			Context = "[CharacterActionComponent.EndBounce]"
		});
	}

	// Token: 0x06019004 RID: 102404 RVA: 0x007175F8 File Offset: 0x007157F8
	public global::Vector GetInteractionTargetLocation()
	{
		return this.InteractionTargetLocation;
	}

	// Token: 0x06019005 RID: 102405 RVA: 0x00717600 File Offset: 0x00715800
	private void OnSuperJumpStateChanged(int tagId, bool tagExist)
	{
		if (!tagExist)
		{
			this.MoveComp.JumpUpRate = 1f;
		}
	}

	// Token: 0x1700219E RID: 8606
	// (get) Token: 0x06019006 RID: 102406 RVA: 0x00717618 File Offset: 0x00715818
	public UTraceLineElement ExecutionTrace
	{
		get
		{
			if (this.ExecutionVisibleTrace == null)
			{
				this.ExecutionVisibleTrace = new UTraceLineElement();
				this.ExecutionVisibleTrace.WorldContextObject = this.ActorComp.Owner;
				this.ExecutionVisibleTrace.bIgnoreSelf = true;
				this.ExecutionVisibleTrace.bIsSingle = true;
				this.ExecutionVisibleTrace.SetTraceTypeQuery(KuroTraceTypeQuery.Visible);
				this.ExecutionVisibleTrace.SetDrawDebugTrace(EDrawDebugTrace.None);
			}
			return this.ExecutionVisibleTrace;
		}
	}

	// Token: 0x06019007 RID: 102407 RVA: 0x00717688 File Offset: 0x00715888
	public void PlayCustomCommonSkill(int inSkillId)
	{
		CharacterSkillComponent skillComp = this.SkillComp;
		if (skillComp == null || !skillComp.CheckIsLoaded())
		{
			return;
		}
		this.SkillComp.BeginSkillAsync(inSkillId, new SkillParam
		{
			Reason = "CharacterActionComponent.PlayCustomCommonSkill"
		});
	}

	// Token: 0x06019008 RID: 102408 RVA: 0x007176BF File Offset: 0x007158BF
	private float GetAnimChangeAngle()
	{
		if (this.AnimChangeAngle == null)
		{
			this.AnimChangeAngle = ConfigCommonParamById.GetFloatConfig("CatapultAnimAngle");
		}
		return this.AnimChangeAngle.Value;
	}

	// Token: 0x06019009 RID: 102409 RVA: 0x007176EC File Offset: 0x007158EC
	public void PlayFaithJumpSkill()
	{
		CharacterSkillComponent skillComp = this.SkillComp;
		if (skillComp == null || !skillComp.CheckIsLoaded())
		{
			return;
		}
		if (this.SkillComp.HasAbility(1502103))
		{
			this.SkillComp.BeginSkill(1502103, new SkillParam
			{
				Reason = "CharacterActionComponent.PlayFaithJumpSkill"
			});
			return;
		}
		if (this.SkillComp.HasAbility(1501103))
		{
			this.SkillComp.BeginSkill(1501103, new SkillParam
			{
				Reason = "CharacterActionComponent.PlayFaithJumpSkill"
			});
			return;
		}
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.Interaction;
		ELogAuthor author = ELogAuthor.CWZ;
		string message = "角色没有信仰之跃技能";
		string item = "Role";
		CharacterActorComponent actorComp = this.ActorComp;
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (actorComp != null) ? new int?(actorComp.CreatureData.GetPbDataId()) : null);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0601900A RID: 102410 RVA: 0x007177CC File Offset: 0x007159CC
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterActionComponent characterActionComponent = (CharacterActionComponent)componentTemplate;
		if (base.CanResetComponentProperty("StateComp"))
		{
			if (characterActionComponent.StateComp == null)
			{
				this.StateComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterUnifiedStateComponent>(this.StateComp), "StateComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComp"))
		{
			if (characterActionComponent.TagComp == null)
			{
				this.TagComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (characterActionComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MoveComp"))
		{
			if (characterActionComponent.MoveComp == null)
			{
				this.MoveComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterMoveComponent>(this.MoveComp), "MoveComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SkillComp"))
		{
			if (characterActionComponent.SkillComp == null)
			{
				this.SkillComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterSkillComponent>(this.SkillComp), "SkillComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("OriginCapsuleHalfHeight"))
		{
			this.OriginCapsuleHalfHeight = characterActionComponent.OriginCapsuleHalfHeight;
		}
		if (base.CanResetComponentProperty("OriginCapsuleRadius"))
		{
			this.OriginCapsuleRadius = characterActionComponent.OriginCapsuleRadius;
		}
		if (base.CanResetComponentProperty("IsSitDownInternal"))
		{
			this.IsSitDownInternal = characterActionComponent.IsSitDownInternal;
		}
		if (base.CanResetComponentProperty("IsStandingUp"))
		{
			this.IsStandingUp = characterActionComponent.IsStandingUp;
		}
		if (base.CanResetComponentProperty("ChairInternal"))
		{
			if (characterActionComponent.ChairInternal == null)
			{
				this.ChairInternal = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Entity>(this.ChairInternal), "ChairInternal"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ChairNeedSetMorph"))
		{
			this.ChairNeedSetMorph = characterActionComponent.ChairNeedSetMorph;
		}
		if (base.CanResetComponentProperty("SitDownTypeIndex"))
		{
			this.SitDownTypeIndex = characterActionComponent.SitDownTypeIndex;
		}
		if (base.CanResetComponentProperty("EnterSitDownIndex"))
		{
			this.EnterSitDownIndex = characterActionComponent.EnterSitDownIndex;
		}
		if (base.CanResetComponentProperty("LeaveSitDownIndex"))
		{
			this.LeaveSitDownIndex = characterActionComponent.LeaveSitDownIndex;
		}
		if (base.CanResetComponentProperty("IsUseCatapultUpAnim"))
		{
			this.IsUseCatapultUpAnim = characterActionComponent.IsUseCatapultUpAnim;
		}
		if (base.CanResetComponentProperty("AnimChangeAngle"))
		{
			this.AnimChangeAngle = characterActionComponent.AnimChangeAngle;
		}
		if (base.CanResetComponentProperty("ExecutionVisibleTrace"))
		{
			if (characterActionComponent.ExecutionVisibleTrace == null)
			{
				this.ExecutionVisibleTrace = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UTraceLineElement>(this.ExecutionVisibleTrace), "ExecutionVisibleTrace"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TempVector") && characterActionComponent.TempVector != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TempVector), "TempVector"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TempVector2") && characterActionComponent.TempVector2 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TempVector2), "TempVector2"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TempRotator") && characterActionComponent.TempRotator != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Rotator>(this.TempRotator), "TempRotator"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("OnSitDownEndChangedTask"))
		{
			if (characterActionComponent.OnSitDownEndChangedTask == null)
			{
				this.OnSitDownEndChangedTask = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.OnSitDownEndChangedTask), "OnSitDownEndChangedTask"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("OnSuperJumpTask"))
		{
			if (characterActionComponent.OnSuperJumpTask == null)
			{
				this.OnSuperJumpTask = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.OnSuperJumpTask), "OnSuperJumpTask"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagListeners") && characterActionComponent.TagListeners != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<ITagTask>>(this.TagListeners), "TagListeners"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("MarkForResetCollision"))
		{
			this.MarkForResetCollision = characterActionComponent.MarkForResetCollision;
		}
		if (base.CanResetComponentProperty("MainChairDir"))
		{
			if (characterActionComponent.MainChairDir == null)
			{
				this.MainChairDir = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector2D>(this.MainChairDir), "MainChairDir"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("StandUpActorForward"))
		{
			if (characterActionComponent.StandUpActorForward == null)
			{
				this.StandUpActorForward = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector2D>(this.StandUpActorForward), "StandUpActorForward"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsInit"))
		{
			this.IsInit = characterActionComponent.IsInit;
		}
		if (base.CanResetComponentProperty("Giant"))
		{
			if (characterActionComponent.Giant == null)
			{
				this.Giant = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<AActor>(this.Giant), "Giant"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsRotatingBeforeManipulate"))
		{
			this.IsRotatingBeforeManipulate = characterActionComponent.IsRotatingBeforeManipulate;
		}
		if (base.CanResetComponentProperty("InteractionTargetLocation") && characterActionComponent.InteractionTargetLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.InteractionTargetLocation), "InteractionTargetLocation"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("OnLeaveSitDown"))
		{
			if (characterActionComponent.OnLeaveSitDown == null)
			{
				this.OnLeaveSitDown = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Action>(this.OnLeaveSitDown), "OnLeaveSitDown"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("LimitStandUpFromOneSide"))
		{
			this.LimitStandUpFromOneSide = characterActionComponent.LimitStandUpFromOneSide;
		}
		return true;
	}

	// Token: 0x0400C35A RID: 50010
	private const int FOURTY_FIVE = 45;

	// Token: 0x0400C35B RID: 50011
	private const float ZERO_EIGHT = 0.8f;

	// Token: 0x0400C35C RID: 50012
	private const int FIVETY = 50;

	// Token: 0x0400C35D RID: 50013
	private const int ONE_HUNDRED_FOURTY = 140;

	// Token: 0x0400C35E RID: 50014
	private const int COLLISION_RADIUS_IN = 15;

	// Token: 0x0400C35F RID: 50015
	private const int COLLISION_RADIUS_OUT = 50;

	// Token: 0x0400C360 RID: 50016
	private const int COLLISION_RESET_ANGLE = 91;

	// Token: 0x0400C361 RID: 50017
	private const float DEFAULT_CATAPULT_TIME = 0.6f;

	// Token: 0x0400C362 RID: 50018
	private const int DEFAULT_CATAPULT_GRAVITY = 1960;

	// Token: 0x0400C363 RID: 50019
	private const int CATAPULT_SKILL_ID = 400102;

	// Token: 0x0400C364 RID: 50020
	private const int SUPER_CATAPULT_SKILL_ID = 400107;

	// Token: 0x0400C365 RID: 50021
	private const int BOUNCE_SKILL_ID = 400104;

	// Token: 0x0400C366 RID: 50022
	private const int FAITH_JUMP_SKILL_MALE = 1501103;

	// Token: 0x0400C367 RID: 50023
	private const int FAITH_JUMP_SKILL_FEMALE = 1502103;

	// Token: 0x0400C368 RID: 50024
	public const int LEAVE_VEHICLE_BOUNCE_SKILL_ID = 100035;

	// Token: 0x0400C369 RID: 50025
	private const int MAX_ANIM_STATE_CHANGE_COUNT = 600;

	// Token: 0x0400C36A RID: 50026
	private const int PI_DEG_DOUBLE = 360;

	// Token: 0x0400C36B RID: 50027
	[Nullable(2)]
	private CharacterUnifiedStateComponent StateComp;

	// Token: 0x0400C36C RID: 50028
	[Nullable(2)]
	private BaseTagComponent TagComp;

	// Token: 0x0400C36D RID: 50029
	[Nullable(2)]
	private CharacterActorComponent ActorComp;

	// Token: 0x0400C36E RID: 50030
	[Nullable(2)]
	private CharacterMoveComponent MoveComp;

	// Token: 0x0400C36F RID: 50031
	[Nullable(2)]
	private CharacterSkillComponent SkillComp;

	// Token: 0x0400C370 RID: 50032
	public float OriginCapsuleHalfHeight;

	// Token: 0x0400C371 RID: 50033
	public float OriginCapsuleRadius;

	// Token: 0x0400C372 RID: 50034
	public bool IsSitDownInternal;

	// Token: 0x0400C373 RID: 50035
	public bool IsStandingUp;

	// Token: 0x0400C374 RID: 50036
	[Nullable(2)]
	private Entity ChairInternal;

	// Token: 0x0400C375 RID: 50037
	private bool ChairNeedSetMorph;

	// Token: 0x0400C376 RID: 50038
	public int SitDownTypeIndex;

	// Token: 0x0400C377 RID: 50039
	public int EnterSitDownIndex;

	// Token: 0x0400C378 RID: 50040
	public int LeaveSitDownIndex;

	// Token: 0x0400C379 RID: 50041
	public bool IsUseCatapultUpAnim;

	// Token: 0x0400C37A RID: 50042
	private float? AnimChangeAngle;

	// Token: 0x0400C37B RID: 50043
	[Nullable(2)]
	private UTraceLineElement ExecutionVisibleTrace;

	// Token: 0x0400C37C RID: 50044
	private readonly global::Vector TempVector = global::Vector.Create();

	// Token: 0x0400C37D RID: 50045
	private readonly global::Vector TempVector2 = global::Vector.Create();

	// Token: 0x0400C37E RID: 50046
	private readonly global::Rotator TempRotator = global::Rotator.Create();

	// Token: 0x0400C37F RID: 50047
	[Nullable(2)]
	private ITagTask OnSitDownEndChangedTask;

	// Token: 0x0400C380 RID: 50048
	[Nullable(2)]
	private ITagTask OnSuperJumpTask;

	// Token: 0x0400C381 RID: 50049
	private readonly List<ITagTask> TagListeners = new List<ITagTask>();

	// Token: 0x0400C382 RID: 50050
	private bool MarkForResetCollision;

	// Token: 0x0400C383 RID: 50051
	[Nullable(2)]
	private Vector2D MainChairDir;

	// Token: 0x0400C384 RID: 50052
	[Nullable(2)]
	private Vector2D StandUpActorForward;

	// Token: 0x0400C385 RID: 50053
	private bool IsInit;

	// Token: 0x0400C386 RID: 50054
	[Nullable(2)]
	public AActor Giant;

	// Token: 0x0400C387 RID: 50055
	private bool IsRotatingBeforeManipulate;

	// Token: 0x0400C388 RID: 50056
	private readonly global::Vector InteractionTargetLocation = global::Vector.Create();

	// Token: 0x0400C389 RID: 50057
	[Nullable(2)]
	public Action OnLeaveSitDown;

	// Token: 0x0400C38A RID: 50058
	[StaticVariableRuleIgnore]
	private static readonly int[] DisableTags = new int[]
	{
		GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"],
		GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击"],
		GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"],
		GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中.全身动作"]
	};

	// Token: 0x0400C38B RID: 50059
	private bool LimitStandUpFromOneSide;

	// Token: 0x0400C38C RID: 50060
	[StaticVariableRuleIgnore]
	private static readonly global::Vector TmpVector = global::Vector.Create();

	// Token: 0x0400C38D RID: 50061
	[StaticVariableRuleIgnore]
	private static readonly global::Vector TmpVector2 = global::Vector.Create();

	// Token: 0x0400C38E RID: 50062
	[StaticVariableRuleIgnore]
	private static readonly CatapultToTargetResult CatapultResult = new CatapultToTargetResult();
}
