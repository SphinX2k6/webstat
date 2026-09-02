using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using CSharpScript.Game.Module;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D77 RID: 3447
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSceneInteract.TsAnimNotifyStateSceneInteract_C")]
public class TsAnimNotifyStateSceneInteract : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000462 RID: 1122
	// (get) Token: 0x06004B33 RID: 19251 RVA: 0x000A5C59 File Offset: 0x000A3E59
	// (set) Token: 0x06004B34 RID: 19252 RVA: 0x000A5C6D File Offset: 0x000A3E6D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName SocketName
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSceneInteract.__PropertyOffset_SocketName);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSceneInteract.__PropertyOffset_SocketName) = value;
		}
	}

	// Token: 0x17000463 RID: 1123
	// (get) Token: 0x06004B35 RID: 19253 RVA: 0x000A5C84 File Offset: 0x000A3E84
	// (set) Token: 0x06004B36 RID: 19254 RVA: 0x000A5CBD File Offset: 0x000A3EBD
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<BP_SceneBattleInteract_C> DataAssetRef
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<BP_SceneBattleInteract_C> result;
			if ((result = this._DataAssetRef) == null)
			{
				result = (this._DataAssetRef = new TSoftObjectPtr<BP_SceneBattleInteract_C>(base.NativePtr + (IntPtr)TsAnimNotifyStateSceneInteract.__PropertyOffset_DataAssetRef, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)TsAnimNotifyStateSceneInteract.__PropertyOffset_DataAssetRef, 1);
		}
	}

	// Token: 0x17000464 RID: 1124
	// (get) Token: 0x06004B37 RID: 19255 RVA: 0x000A5CE2 File Offset: 0x000A3EE2
	// (set) Token: 0x06004B38 RID: 19256 RVA: 0x000A5CF2 File Offset: 0x000A3EF2
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int QualityRequire
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSceneInteract.__PropertyOffset_QualityRequire);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSceneInteract.__PropertyOffset_QualityRequire) = value;
		}
	}

	// Token: 0x17000465 RID: 1125
	// (get) Token: 0x06004B39 RID: 19257 RVA: 0x000A5D03 File Offset: 0x000A3F03
	// (set) Token: 0x06004B3A RID: 19258 RVA: 0x000A5D13 File Offset: 0x000A3F13
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IgnoreCommonWeapon
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSceneInteract.__PropertyOffset_IgnoreCommonWeapon) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSceneInteract.__PropertyOffset_IgnoreCommonWeapon) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000466 RID: 1126
	// (get) Token: 0x06004B3B RID: 19259 RVA: 0x000A5D24 File Offset: 0x000A3F24
	// (set) Token: 0x06004B3C RID: 19260 RVA: 0x000A5D34 File Offset: 0x000A3F34
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool ShieldWaterMoveEffect
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSceneInteract.__PropertyOffset_ShieldWaterMoveEffect) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSceneInteract.__PropertyOffset_ShieldWaterMoveEffect) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004B3D RID: 19261 RVA: 0x000A5D48 File Offset: 0x000A3F48
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyBegin(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyBegin"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->TotalDuration = totalDuration;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004B3E RID: 19262 RVA: 0x000A5DF0 File Offset: 0x000A3FF0
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		if (this.DataAssetRef == null)
		{
			return false;
		}
		AActor owner = meshComp.GetOwner();
		bool flag = owner is TsBaseCharacter;
		bool flag2 = owner is TsBaseVehicle;
		if (flag || flag2)
		{
			if (!ModelBase<SceneBattleInteractModel>.Instance.Open)
			{
				return false;
			}
			if (this.QualityRequire > 0)
			{
				int? currentValue = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.IMAGEQUALITY, true, true);
				if (currentValue == null || currentValue.Value < 3)
				{
					return false;
				}
			}
			BP_SceneBattleInteract_C bp_SceneBattleInteract_C = Singleton<ResourceSystem>.Instance.Load<BP_SceneBattleInteract_C>(this.DataAssetRef.ToAssetPathName(), "js_undefined");
			if (bp_SceneBattleInteract_C == null)
			{
				return false;
			}
			SceneBattleInteractEffect sceneBattleInteractEffect = ModelBase<SceneBattleInteractModel>.Instance.CreateSceneBattleInteract(bp_SceneBattleInteract_C, 0f, 0f);
			if (sceneBattleInteractEffect != null)
			{
				int id = sceneBattleInteractEffect.Id;
				sceneBattleInteractEffect.SetDispatchWeaponEventEnable(true);
				sceneBattleInteractEffect.SetUpdateLocationSocket(meshComp, FNameUtil.IsNothing(this.SocketName) ? FNameUtil.EMPTY : this.SocketName);
				sceneBattleInteractEffect.SetEnable(true, 20000f);
				sceneBattleInteractEffect.SetIgnoreCommonWeapon(this.IgnoreCommonWeapon);
				this.HandleMap[meshComp] = id;
				if (flag)
				{
					global::ESceneBattleInteractEntityType esceneBattleInteractEntityType = (global::ESceneBattleInteractEntityType)bp_SceneBattleInteract_C.EntityType;
					if (esceneBattleInteractEntityType == global::ESceneBattleInteractEntityType.Player || esceneBattleInteractEntityType == global::ESceneBattleInteractEntityType.Summoned)
					{
						TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
						Entity entity;
						if (tsBaseCharacter == null)
						{
							entity = null;
						}
						else
						{
							CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
							entity = ((characterActorComponent != null) ? characterActorComponent.Entity : null);
						}
						Entity entity2 = entity;
						if (entity2 != null && entity2.Valid)
						{
							if (esceneBattleInteractEntityType == global::ESceneBattleInteractEntityType.Summoned)
							{
								CreatureDataComponent component = entity2.GetComponent<CreatureDataComponent>();
								long? num = (component != null) ? new long?(component.GetSummonerId()) : null;
								if (num != null && num.Value != 0L)
								{
									int entityId = ModelBase<CreatureModel>.Instance.GetEntityId(num.Value);
									sceneBattleInteractEffect.BindEntityId(entityId);
								}
							}
							else
							{
								sceneBattleInteractEffect.BindEntityId(entity2.Id);
							}
						}
					}
				}
				if (this.ShieldWaterMoveEffect)
				{
					TsBaseCharacter tsBaseCharacter2 = owner as TsBaseCharacter;
					Entity entity3;
					if ((entity3 = ((tsBaseCharacter2 != null) ? tsBaseCharacter2.GetEntityNoBlueprint() : null)) == null)
					{
						TsBaseVehicle tsBaseVehicle = owner as TsBaseVehicle;
						entity3 = ((tsBaseVehicle != null) ? tsBaseVehicle.GetEntityNoBlueprint() : null);
					}
					Entity entity4 = entity3;
					if (entity4 != null && entity4.Valid)
					{
						BaseTagComponent component2 = entity4.GetComponent<BaseTagComponent>();
						if (component2 != null)
						{
							component2.TagContainer.UpdateExactTag(ETagChannel.Anim, GameplayTagDefine.EGameplayTagId["GameplayEffect.ShieldWaterMoveEffect"], 1);
							return true;
						}
					}
				}
				return true;
			}
		}
		return false;
	}

	// Token: 0x06004B3F RID: 19263 RVA: 0x000A6028 File Offset: 0x000A4228
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyEnd(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyEnd"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004B40 RID: 19264 RVA: 0x000A60C8 File Offset: 0x000A42C8
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (this.DataAssetRef == null)
		{
			return false;
		}
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		int num;
		if (tsBaseCharacter != null && this.HandleMap.TryGetValue(meshComp, out num) && num != 0)
		{
			if (ModelBase<SceneBattleInteractModel>.Instance.Open)
			{
				ModelBase<SceneBattleInteractModel>.Instance.DestroySceneBattleInteract(num);
			}
			this.HandleMap.Remove(meshComp);
			if (this.ShieldWaterMoveEffect)
			{
				CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
				Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
				if (entity != null && entity.Valid)
				{
					BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
					if (component != null)
					{
						component.TagContainer.UpdateExactTag(ETagChannel.Anim, GameplayTagDefine.EGameplayTagId["GameplayEffect.ShieldWaterMoveEffect"], -1);
						return true;
					}
				}
			}
			return true;
		}
		return false;
	}

	// Token: 0x06004B41 RID: 19265 RVA: 0x000A6180 File Offset: 0x000A4380
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotifyState.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotifyState.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotifyState.__GetNotifyName_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		string result = FString.ToString((void*)(&ptr2->__Result));
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x06004B42 RID: 19266 RVA: 0x000A61FB File Offset: 0x000A43FB
	protected override string GetNotifyName_Implementation()
	{
		return "场景物件交互";
	}

	// Token: 0x06004B43 RID: 19267 RVA: 0x000A6202 File Offset: 0x000A4402
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateSceneInteract._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSceneInteract.TsAnimNotifyStateSceneInteract_C");
		}
		return TsAnimNotifyStateSceneInteract._ClassPtr;
	}

	// Token: 0x06004B44 RID: 19268 RVA: 0x000A6228 File Offset: 0x000A4428
	public TsAnimNotifyStateSceneInteract() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSceneInteract.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004B45 RID: 19269 RVA: 0x000A6250 File Offset: 0x000A4450
	public TsAnimNotifyStateSceneInteract(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSceneInteract.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004B46 RID: 19270 RVA: 0x000A6283 File Offset: 0x000A4483
	protected TsAnimNotifyStateSceneInteract(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004B47 RID: 19271 RVA: 0x000A6298 File Offset: 0x000A4498
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004B48 RID: 19272 RVA: 0x000A62D4 File Offset: 0x000A44D4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004B49 RID: 19273 RVA: 0x000A6307 File Offset: 0x000A4507
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001576 RID: 5494
	private const float MAX_ENABLE_TIME = 20000f;

	// Token: 0x04001577 RID: 5495
	private readonly Dictionary<USkeletalMeshComponent, int> HandleMap = new Dictionary<USkeletalMeshComponent, int>();

	// Token: 0x04001578 RID: 5496
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSceneInteract.TsAnimNotifyStateSceneInteract_C";

	// Token: 0x04001579 RID: 5497
	private static IntPtr _ClassPtr;

	// Token: 0x0400157A RID: 5498
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400157B RID: 5499
	private static int __PropertyOffset_SocketName;

	// Token: 0x0400157C RID: 5500
	private static int __PropertyOffset_DataAssetRef;

	// Token: 0x0400157D RID: 5501
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<BP_SceneBattleInteract_C> _DataAssetRef;

	// Token: 0x0400157E RID: 5502
	private static int __PropertyOffset_QualityRequire;

	// Token: 0x0400157F RID: 5503
	private static int __PropertyOffset_IgnoreCommonWeapon;

	// Token: 0x04001580 RID: 5504
	private static int __PropertyOffset_ShieldWaterMoveEffect;
}
