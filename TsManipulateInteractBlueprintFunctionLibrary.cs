using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.Data.Gameplay.MechascoutDrag;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using CSharpScript.Game.NewWorld.SceneItem;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002E34 RID: 11828
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsManipulateInteractBlueprintFunctionLibrary.TsManipulateInteractBlueprintFunctionLibrary_C")]
public class TsManipulateInteractBlueprintFunctionLibrary : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601827C RID: 98940 RVA: 0x006C0B28 File Offset: 0x006BED28
	[NullableContext(2)]
	private static CharacterManipulateInteractComponent GetManipulateInteractComp(int entityId)
	{
		CharacterManipulateInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateInteractComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return null;
		}
		return component;
	}

	// Token: 0x0601827D RID: 98941 RVA: 0x006C0B50 File Offset: 0x006BED50
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static AkiClient.Game.Aki.Data.Gameplay.MechascoutDrag.EMechascoutDragType GetMechascoutDragInteractType(int entityId)
	{
		CharacterManipulateInteractComponent manipulateInteractComp = TsManipulateInteractBlueprintFunctionLibrary.GetManipulateInteractComp(entityId);
		if (manipulateInteractComp == null)
		{
			return AkiClient.Game.Aki.Data.Gameplay.MechascoutDrag.EMechascoutDragType.EMechascoutDragType_MAX;
		}
		SceneItemExploreInteractComponent sceneItemExploreInteractComponent = manipulateInteractComp.SelectedTargetInternal ?? manipulateInteractComp.BestTargetInternal;
		if (sceneItemExploreInteractComponent == null)
		{
			return AkiClient.Game.Aki.Data.Gameplay.MechascoutDrag.EMechascoutDragType.EMechascoutDragType_MAX;
		}
		return sceneItemExploreInteractComponent.GetUeDragType();
	}

	// Token: 0x0601827E RID: 98942 RVA: 0x006C0B88 File Offset: 0x006BED88
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool StartMechascoutDragInteract(int entityId)
	{
		CharacterManipulateInteractComponent manipulateInteractComp = TsManipulateInteractBlueprintFunctionLibrary.GetManipulateInteractComp(entityId);
		if (manipulateInteractComp == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.CH, "[StartMechascoutDragInteract] 组件无效", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		SceneItemExploreInteractComponent getCurrentTarget = manipulateInteractComp.GetCurrentTarget;
		if (getCurrentTarget == null || getCurrentTarget.Type.GetValueOrDefault() != EExploreSkillInteractType.MechascoutDrag)
		{
			Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.CH, "[StartMechascoutDragInteract] 无有效交互点", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		AkiClient.Game.Aki.Data.Gameplay.MechascoutDrag.EMechascoutDragType dragType = getCurrentTarget.GetUeDragType();
		if (dragType == AkiClient.Game.Aki.Data.Gameplay.MechascoutDrag.EMechascoutDragType.EMechascoutDragType_MAX)
		{
			Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.CH, "[StartMechascoutDragInteract] 无效拉拽类型", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		CharacterActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return false;
		}
		Vector vector = getCurrentTarget.FindNearestTriggerPoint(component.ActorLocationProxy);
		if (vector == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.CH, "[StartMechascoutDragInteract] 未找到有效触发点", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		CharacterCustomActionComponent customActionComp = Singleton<EntitySystem>.Instance.GetComponent<CharacterCustomActionComponent>(entityId);
		CharacterCustomActionComponent customActionComp3 = customActionComp;
		if (customActionComp3 == null || !customActionComp3.Valid)
		{
			return false;
		}
		CharacterUnifiedStateComponent unifiedStateComp = Singleton<EntitySystem>.Instance.GetComponent<CharacterUnifiedStateComponent>(entityId);
		CharacterUnifiedStateComponent unifiedStateComp2 = unifiedStateComp;
		if (unifiedStateComp2 == null || !unifiedStateComp2.Valid)
		{
			return false;
		}
		manipulateInteractComp.StartMechascoutDragInteract();
		ModelBase<BattleInputModel>.Instance.SetAllInputEnable(false, EBattleInputReason.MechascoutDrag);
		BaseActorComponent interactActorComp = getCurrentTarget.Entity.GetComponent<BaseActorComponent>();
		Vector vector2 = Vector.Create(vector);
		vector2.Z += (double)component.ScaledHalfHeight;
		Action <>9__1;
		customActionComp.AddCustomMoveToLocation(vector2, delegate
		{
			BaseActorComponent interactActorComp = interactActorComp;
			if (interactActorComp == null || !interactActorComp.Valid)
			{
				unifiedStateComp.SetMoveState(ECharMoveState.WalkStop);
				ModelBase<BattleInputModel>.Instance.SetAllInputEnable(true, EBattleInputReason.MechascoutDrag);
				TsManipulateInteractBlueprintFunctionLibrary.TryBeginDragSkill(entityId, dragType);
				return;
			}
			CharacterCustomActionComponent customActionComp2 = customActionComp;
			BaseActorComponent interactActorComp2 = interactActorComp;
			double angle = 0.0;
			ECustomSetRotationType type = ECustomSetRotationType.FaceToTarget;
			Action callback;
			if ((callback = <>9__1) == null)
			{
				callback = (<>9__1 = delegate()
				{
					unifiedStateComp.SetMoveState(ECharMoveState.WalkStop);
					ModelBase<BattleInputModel>.Instance.SetAllInputEnable(true, EBattleInputReason.MechascoutDrag);
					TsManipulateInteractBlueprintFunctionLibrary.TryBeginDragSkill(entityId, dragType);
				});
			}
			customActionComp2.AddCustomSetTurnToTarget(interactActorComp2, angle, type, callback, null);
		}, null);
		return true;
	}

	// Token: 0x0601827F RID: 98943 RVA: 0x006C0D50 File Offset: 0x006BEF50
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool AttachMechascoutInteractActorToSocket(int entityId)
	{
		CharacterManipulateInteractComponent manipulateInteractComp = TsManipulateInteractBlueprintFunctionLibrary.GetManipulateInteractComp(entityId);
		if (manipulateInteractComp == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.CH, "[AttachMechascoutInteractActorToSocket] 组件无效", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		SceneItemExploreInteractComponent sceneItemExploreInteractComponent = manipulateInteractComp.SelectedTargetInternal ?? manipulateInteractComp.BestTargetInternal;
		if (sceneItemExploreInteractComponent == null || !sceneItemExploreInteractComponent.Valid)
		{
			Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.CH, "[AttachMechascoutInteractActorToSocket] 无有效交互点", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		CharacterActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		if (component != null && component.Valid)
		{
			TsBaseCharacter actor = component.Actor;
			if (((actor != null) ? actor.Mesh : null) != null)
			{
				BaseActorComponent component2 = sceneItemExploreInteractComponent.Entity.GetComponent<BaseActorComponent>();
				AActor aactor = (component2 != null) ? component2.Owner : null;
				if (aactor == null || !aactor.IsValid())
				{
					Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.CH, "[AttachMechascoutInteractActorToSocket] 目标Actor无效", default(ReadOnlySpan<ValueTuple<string, object>>));
					return false;
				}
				aactor.K2_AttachToComponent(component.Actor.Mesh, TsManipulateInteractBlueprintFunctionLibrary.MechascoutAttachSocket.Value, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, false, true);
				sceneItemExploreInteractComponent.SaveAndDisableActorCollision();
				return true;
			}
		}
		Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.CH, "[AttachMechascoutInteractActorToSocket] 角色Mesh无效", default(ReadOnlySpan<ValueTuple<string, object>>));
		return false;
	}

	// Token: 0x06018280 RID: 98944 RVA: 0x006C0E88 File Offset: 0x006BF088
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool DetachMechascoutInteractActor(int entityId)
	{
		CharacterManipulateInteractComponent manipulateInteractComp = TsManipulateInteractBlueprintFunctionLibrary.GetManipulateInteractComp(entityId);
		if (manipulateInteractComp == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.CH, "[DetachMechascoutInteractActor] 组件无效", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		SceneItemExploreInteractComponent sceneItemExploreInteractComponent = manipulateInteractComp.SelectedTargetInternal ?? manipulateInteractComp.BestTargetInternal;
		if (sceneItemExploreInteractComponent == null || !sceneItemExploreInteractComponent.Valid)
		{
			Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.CH, "[DetachMechascoutInteractActor] 无有效交互点", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		BaseActorComponent component = sceneItemExploreInteractComponent.Entity.GetComponent<BaseActorComponent>();
		AActor aactor = (component != null) ? component.Owner : null;
		if (aactor == null || !aactor.IsValid())
		{
			Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.CH, "[DetachMechascoutInteractActor] 目标Actor无效", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		aactor.K2_DetachFromActor(EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld);
		sceneItemExploreInteractComponent.RestoreActorCollision();
		return true;
	}

	// Token: 0x06018281 RID: 98945 RVA: 0x006C0F54 File Offset: 0x006BF154
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool AttachMechascoutManipulateActorToSocket(int entityId)
	{
		CharacterManipulateComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateComponent>(entityId);
		if (component == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.CH, "[AttachMechascoutManipulateActorToSocket] 组件无效", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		Entity holdingEntity = component.GetHoldingEntity();
		if (holdingEntity == null || !holdingEntity.Valid)
		{
			Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.CH, "[AttachMechascoutManipulateActorToSocket] 无有效交互点", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		SceneItemManipulatableComponent component2 = holdingEntity.GetComponent<SceneItemManipulatableComponent>();
		if (component2 == null || !component2.Valid)
		{
			Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.CH, "[AttachMechascoutManipulateActorToSocket] 控物组件无效", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		CharacterActorComponent component3 = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		if (component3 != null && component3.Valid)
		{
			TsBaseCharacter actor = component3.Actor;
			if (((actor != null) ? actor.Mesh : null) != null)
			{
				BaseActorComponent component4 = holdingEntity.GetComponent<BaseActorComponent>();
				AActor aactor = (component4 != null) ? component4.Owner : null;
				if (aactor == null || !aactor.IsValid())
				{
					Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.CH, "[AttachMechascoutManipulateActorToSocket] 目标Actor无效", default(ReadOnlySpan<ValueTuple<string, object>>));
					return false;
				}
				aactor.K2_AttachToComponent(component3.Actor.Mesh, TsManipulateInteractBlueprintFunctionLibrary.MechascoutManipulateAttachSocket ?? FNameUtil.NONE, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false, true);
				component2.SetEnableTargetLocationCalculation(false);
				SceneItemActorComponent actorComp = component2.ActorComp;
				if (actorComp != null && actorComp.Valid)
				{
					component2.ActorComp.PhysicsMode = SceneItemActorComponent.EPhysicsMode.Kinematic;
				}
				component.MarkCastOnDetach();
				return true;
			}
		}
		Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.CH, "[AttachMechascoutManipulateActorToSocket] 角色Mesh无效", default(ReadOnlySpan<ValueTuple<string, object>>));
		return false;
	}

	// Token: 0x06018282 RID: 98946 RVA: 0x006C10F8 File Offset: 0x006BF2F8
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool DetachMechascoutManipulateActor(int entityId)
	{
		CharacterManipulateComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateComponent>(entityId);
		if (component == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.CH, "[AttachMechascoutManipulateActorToSocket] 组件无效", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		Entity holdingEntity = component.GetHoldingEntity();
		if (holdingEntity == null || !holdingEntity.Valid)
		{
			Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.CH, "[DetachMechascoutInteractActor] 无有效交互点", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		SceneItemManipulatableComponent component2 = holdingEntity.GetComponent<SceneItemManipulatableComponent>();
		if (component2 == null || !component2.Valid)
		{
			Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.CH, "[DetachMechascoutManipulateActor] 控物组件无效", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		BaseActorComponent component3 = holdingEntity.GetComponent<BaseActorComponent>();
		AActor aactor = (component3 != null) ? component3.Owner : null;
		if (aactor == null || !aactor.IsValid())
		{
			Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.CH, "[DetachMechascoutInteractActor] 目标Actor无效", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		aactor.K2_DetachFromActor(EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld);
		component2.SetEnableTargetLocationCalculation(true);
		component.TryCastOnDetach();
		return true;
	}

	// Token: 0x06018283 RID: 98947 RVA: 0x006C11FC File Offset: 0x006BF3FC
	private static void TryBeginDragSkill(int entityId, AkiClient.Game.Aki.Data.Gameplay.MechascoutDrag.EMechascoutDragType dragType)
	{
		int num;
		if (!TsManipulateInteractBlueprintFunctionLibrary.SkillIdMap.TryGetValue(dragType, out num) || num <= 0)
		{
			return;
		}
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.BeginSkill(num, new SkillParam
			{
				Reason = "[StartMechascoutDragInteract]"
			});
		}
	}

	// Token: 0x06018284 RID: 98948 RVA: 0x006C124C File Offset: 0x006BF44C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void EndMechascoutDragInteract(int entityId, AkiClient.Game.Aki.Data.Gameplay.MechascoutDrag.EMechascoutDragType dragType)
	{
		CharacterManipulateInteractComponent manipulateInteractComp = TsManipulateInteractBlueprintFunctionLibrary.GetManipulateInteractComp(entityId);
		if (manipulateInteractComp == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.CH, "[EndMechascoutDragInteract] 组件无效", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		manipulateInteractComp.EndMechascoutDragInteract();
	}

	// Token: 0x06018285 RID: 98949 RVA: 0x006C1286 File Offset: 0x006BF486
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsManipulateInteractBlueprintFunctionLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsManipulateInteractBlueprintFunctionLibrary.TsManipulateInteractBlueprintFunctionLibrary_C");
		}
		return TsManipulateInteractBlueprintFunctionLibrary._ClassPtr;
	}

	// Token: 0x06018286 RID: 98950 RVA: 0x006C12AC File Offset: 0x006BF4AC
	public TsManipulateInteractBlueprintFunctionLibrary() : this(BuiltinUtils.AllocNativeUObject(TsManipulateInteractBlueprintFunctionLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06018287 RID: 98951 RVA: 0x006C12D4 File Offset: 0x006BF4D4
	[NullableContext(1)]
	public TsManipulateInteractBlueprintFunctionLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsManipulateInteractBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06018288 RID: 98952 RVA: 0x006C1307 File Offset: 0x006BF507
	protected TsManipulateInteractBlueprintFunctionLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06018289 RID: 98953 RVA: 0x006C1310 File Offset: 0x006BF510
	protected unsafe static void __CPPCALL_GetMechascoutDragInteractType_Implementation(TsManipulateInteractBlueprintFunctionLibrary.__GetMechascoutDragInteractType_FunctionParams* __Params)
	{
		*(&__Params->__Result) = (byte)TsManipulateInteractBlueprintFunctionLibrary.GetMechascoutDragInteractType(__Params->entityId);
	}

	// Token: 0x0601828A RID: 98954 RVA: 0x006C1325 File Offset: 0x006BF525
	protected unsafe static void __CPPCALL_StartMechascoutDragInteract_Implementation(TsManipulateInteractBlueprintFunctionLibrary.__StartMechascoutDragInteract_FunctionParams* __Params)
	{
		__Params->__Result = TsManipulateInteractBlueprintFunctionLibrary.StartMechascoutDragInteract(__Params->entityId);
	}

	// Token: 0x0601828B RID: 98955 RVA: 0x006C1338 File Offset: 0x006BF538
	protected unsafe static void __CPPCALL_AttachMechascoutInteractActorToSocket_Implementation(TsManipulateInteractBlueprintFunctionLibrary.__AttachMechascoutInteractActorToSocket_FunctionParams* __Params)
	{
		__Params->__Result = TsManipulateInteractBlueprintFunctionLibrary.AttachMechascoutInteractActorToSocket(__Params->entityId);
	}

	// Token: 0x0601828C RID: 98956 RVA: 0x006C134B File Offset: 0x006BF54B
	protected unsafe static void __CPPCALL_DetachMechascoutInteractActor_Implementation(TsManipulateInteractBlueprintFunctionLibrary.__DetachMechascoutInteractActor_FunctionParams* __Params)
	{
		__Params->__Result = TsManipulateInteractBlueprintFunctionLibrary.DetachMechascoutInteractActor(__Params->entityId);
	}

	// Token: 0x0601828D RID: 98957 RVA: 0x006C135E File Offset: 0x006BF55E
	protected unsafe static void __CPPCALL_AttachMechascoutManipulateActorToSocket_Implementation(TsManipulateInteractBlueprintFunctionLibrary.__AttachMechascoutManipulateActorToSocket_FunctionParams* __Params)
	{
		__Params->__Result = TsManipulateInteractBlueprintFunctionLibrary.AttachMechascoutManipulateActorToSocket(__Params->entityId);
	}

	// Token: 0x0601828E RID: 98958 RVA: 0x006C1371 File Offset: 0x006BF571
	protected unsafe static void __CPPCALL_DetachMechascoutManipulateActor_Implementation(TsManipulateInteractBlueprintFunctionLibrary.__DetachMechascoutManipulateActor_FunctionParams* __Params)
	{
		__Params->__Result = TsManipulateInteractBlueprintFunctionLibrary.DetachMechascoutManipulateActor(__Params->entityId);
	}

	// Token: 0x0601828F RID: 98959 RVA: 0x006C1384 File Offset: 0x006BF584
	protected unsafe static void __CPPCALL_EndMechascoutDragInteract_Implementation(TsManipulateInteractBlueprintFunctionLibrary.__EndMechascoutDragInteract_FunctionParams* __Params)
	{
		AkiClient.Game.Aki.Data.Gameplay.MechascoutDrag.EMechascoutDragType dragType = (AkiClient.Game.Aki.Data.Gameplay.MechascoutDrag.EMechascoutDragType)__Params->dragType;
		TsManipulateInteractBlueprintFunctionLibrary.EndMechascoutDragInteract(__Params->entityId, dragType);
	}

	// Token: 0x0400BA1B RID: 47643
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly Dictionary<AkiClient.Game.Aki.Data.Gameplay.MechascoutDrag.EMechascoutDragType, int> SkillIdMap = new Dictionary<AkiClient.Game.Aki.Data.Gameplay.MechascoutDrag.EMechascoutDragType, int>
	{
		{
			AkiClient.Game.Aki.Data.Gameplay.MechascoutDrag.EMechascoutDragType.Instant,
			5045003
		},
		{
			AkiClient.Game.Aki.Data.Gameplay.MechascoutDrag.EMechascoutDragType.LongPress,
			5045004
		}
	};

	// Token: 0x0400BA1C RID: 47644
	[StaticVariableRuleIgnore]
	private static readonly FName? MechascoutAttachSocket = FNameUtil.GetDynamicFName("WeaponProp04");

	// Token: 0x0400BA1D RID: 47645
	[StaticVariableRuleIgnore]
	private static readonly FName? MechascoutManipulateAttachSocket = FNameUtil.GetDynamicFName("WeaponProp05");

	// Token: 0x0400BA1E RID: 47646
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsManipulateInteractBlueprintFunctionLibrary.TsManipulateInteractBlueprintFunctionLibrary_C";

	// Token: 0x0400BA1F RID: 47647
	private static IntPtr _ClassPtr;

	// Token: 0x0400BA20 RID: 47648
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0200922A RID: 37418
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetMechascoutDragInteractType_FunctionParams
	{
		// Token: 0x04030C60 RID: 199776
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030C61 RID: 199777
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030C62 RID: 199778
		[FieldOffset(16)]
		public byte __Result;
	}

	// Token: 0x0200922B RID: 37419
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __StartMechascoutDragInteract_FunctionParams
	{
		// Token: 0x04030C63 RID: 199779
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030C64 RID: 199780
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030C65 RID: 199781
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x0200922C RID: 37420
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __AttachMechascoutInteractActorToSocket_FunctionParams
	{
		// Token: 0x04030C66 RID: 199782
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030C67 RID: 199783
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030C68 RID: 199784
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x0200922D RID: 37421
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __DetachMechascoutInteractActor_FunctionParams
	{
		// Token: 0x04030C69 RID: 199785
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030C6A RID: 199786
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030C6B RID: 199787
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x0200922E RID: 37422
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __AttachMechascoutManipulateActorToSocket_FunctionParams
	{
		// Token: 0x04030C6C RID: 199788
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030C6D RID: 199789
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030C6E RID: 199790
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x0200922F RID: 37423
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __DetachMechascoutManipulateActor_FunctionParams
	{
		// Token: 0x04030C6F RID: 199791
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030C70 RID: 199792
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030C71 RID: 199793
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x02009230 RID: 37424
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __EndMechascoutDragInteract_FunctionParams
	{
		// Token: 0x04030C72 RID: 199794
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030C73 RID: 199795
		[FieldOffset(4)]
		public byte dragType;

		// Token: 0x04030C74 RID: 199796
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}
}
