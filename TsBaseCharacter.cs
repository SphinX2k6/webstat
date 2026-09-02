using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Core.Fight.Manager;
using AkiClient.Game.Aki.CreatureTools;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000E4F RID: 3663
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Character/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Character/TsBaseCharacter.TsBaseCharacter_C")]
public class TsBaseCharacter : ABaseCharacter, IBPI_CreatureInterface_C, IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject, IUnrealUObject
{
	// Token: 0x170005F9 RID: 1529
	// (get) Token: 0x060057CC RID: 22476 RVA: 0x00105738 File Offset: 0x00103938
	// (set) Token: 0x060057CD RID: 22477 RVA: 0x0010574C File Offset: 0x0010394C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe CharRenderingComponent CharRenderingComponent
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<CharRenderingComponent>(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_CharRenderingComponent);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_CharRenderingComponent, value);
		}
	}

	// Token: 0x170005FA RID: 1530
	// (get) Token: 0x060057CE RID: 22478 RVA: 0x00105761 File Offset: 0x00103961
	// (set) Token: 0x060057CF RID: 22479 RVA: 0x00105771 File Offset: 0x00103971
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe ECharacterRenderingType RenderType
	{
		get
		{
			return (ECharacterRenderingType)(*(base.NativePtr + (IntPtr)TsBaseCharacter.__PropertyOffset_RenderType));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsBaseCharacter.__PropertyOffset_RenderType) = (byte)value;
		}
	}

	// Token: 0x170005FB RID: 1531
	// (get) Token: 0x060057D0 RID: 22480 RVA: 0x00105782 File Offset: 0x00103982
	// (set) Token: 0x060057D1 RID: 22481 RVA: 0x00105796 File Offset: 0x00103996
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe TsCharacterDebugComponent TsCharacterDebugComponent
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<TsCharacterDebugComponent>(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_TsCharacterDebugComponent);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_TsCharacterDebugComponent, value);
		}
	}

	// Token: 0x170005FC RID: 1532
	// (get) Token: 0x060057D2 RID: 22482 RVA: 0x001057AB File Offset: 0x001039AB
	// (set) Token: 0x060057D3 RID: 22483 RVA: 0x001057BF File Offset: 0x001039BF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UNavigationInvokerComponent NavigationInvoker
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UNavigationInvokerComponent>(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_NavigationInvoker);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_NavigationInvoker, value);
		}
	}

	// Token: 0x170005FD RID: 1533
	// (get) Token: 0x060057D4 RID: 22484 RVA: 0x001057D4 File Offset: 0x001039D4
	// (set) Token: 0x060057D5 RID: 22485 RVA: 0x0010580D File Offset: 0x00103A0D
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public FSoftClassPath InputComponentClass
	{
		[NullableContext(1)]
		get
		{
			base.FastCheckIsValid();
			FSoftClassPath result;
			if ((result = this._InputComponentClass) == null)
			{
				result = (this._InputComponentClass = new FSoftClassPath(base.NativePtr + (IntPtr)TsBaseCharacter.__PropertyOffset_InputComponentClass, this));
			}
			return result;
		}
		[NullableContext(1)]
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FSoftClassPath.StaticStruct(), base.NativePtr + (IntPtr)TsBaseCharacter.__PropertyOffset_InputComponentClass, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170005FE RID: 1534
	// (get) Token: 0x060057D6 RID: 22486 RVA: 0x00105835 File Offset: 0x00103A35
	// (set) Token: 0x060057D7 RID: 22487 RVA: 0x00105849 File Offset: 0x00103A49
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe BP_BasePlatform_C BasePlatform
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<BP_BasePlatform_C>(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_BasePlatform);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_BasePlatform, value);
		}
	}

	// Token: 0x170005FF RID: 1535
	// (get) Token: 0x060057D8 RID: 22488 RVA: 0x0010585E File Offset: 0x00103A5E
	// (set) Token: 0x060057D9 RID: 22489 RVA: 0x0010586E File Offset: 0x00103A6E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int EntityId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsBaseCharacter.__PropertyOffset_EntityId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsBaseCharacter.__PropertyOffset_EntityId) = value;
		}
	}

	// Token: 0x060057DA RID: 22490 RVA: 0x0010587F File Offset: 0x00103A7F
	public void SetEntityId(int entityId)
	{
		this.EntityId = entityId;
		base.EntityIdInternal = entityId;
	}

	// Token: 0x060057DB RID: 22491 RVA: 0x00105890 File Offset: 0x00103A90
	public void TryAddTsAbilitySystemComponent()
	{
		if (base.AbilitySystemComponent == null)
		{
			base.AbilitySystemComponent = (base.AddComponentByClass(UBaseAbilitySystemComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as UBaseAbilitySystemComponent);
		}
	}

	// Token: 0x17000600 RID: 1536
	// (get) Token: 0x060057DC RID: 22492 RVA: 0x001058D5 File Offset: 0x00103AD5
	// (set) Token: 0x060057DD RID: 22493 RVA: 0x001058E9 File Offset: 0x00103AE9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe BP_FightManager_C FightManager
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<BP_FightManager_C>(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_FightManager);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_FightManager, value);
		}
	}

	// Token: 0x17000601 RID: 1537
	// (get) Token: 0x060057DE RID: 22494 RVA: 0x001058FE File Offset: 0x00103AFE
	// (set) Token: 0x060057DF RID: 22495 RVA: 0x00105912 File Offset: 0x00103B12
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UDataTable DtHitEffect
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_DtHitEffect);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_DtHitEffect, value);
		}
	}

	// Token: 0x17000602 RID: 1538
	// (get) Token: 0x060057E0 RID: 22496 RVA: 0x00105927 File Offset: 0x00103B27
	// (set) Token: 0x060057E1 RID: 22497 RVA: 0x0010593B File Offset: 0x00103B3B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UDataTable DtBaseMovementSetting
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_DtBaseMovementSetting);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_DtBaseMovementSetting, value);
		}
	}

	// Token: 0x17000603 RID: 1539
	// (get) Token: 0x060057E2 RID: 22498 RVA: 0x00105950 File Offset: 0x00103B50
	// (set) Token: 0x060057E3 RID: 22499 RVA: 0x00105964 File Offset: 0x00103B64
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UDataTable DtNewBulletDataMain
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_DtNewBulletDataMain);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_DtNewBulletDataMain, value);
		}
	}

	// Token: 0x17000604 RID: 1540
	// (get) Token: 0x060057E4 RID: 22500 RVA: 0x00105979 File Offset: 0x00103B79
	// (set) Token: 0x060057E5 RID: 22501 RVA: 0x0010598D File Offset: 0x00103B8D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UDataTable DtCharacterPart
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_DtCharacterPart);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_DtCharacterPart, value);
		}
	}

	// Token: 0x17000605 RID: 1541
	// (get) Token: 0x060057E6 RID: 22502 RVA: 0x001059A2 File Offset: 0x00103BA2
	// (set) Token: 0x060057E7 RID: 22503 RVA: 0x001059B6 File Offset: 0x00103BB6
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UDataTable DtCameraConfig
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_DtCameraConfig);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_DtCameraConfig, value);
		}
	}

	// Token: 0x17000606 RID: 1542
	// (get) Token: 0x060057E8 RID: 22504 RVA: 0x001059CC File Offset: 0x00103BCC
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<FName> BattleSockets
	{
		[NullableContext(1)]
		get
		{
			base.FastCheckIsValid();
			TArray<FName> result;
			if ((result = this._BattleSockets) == null)
			{
				result = (this._BattleSockets = new TArray<FName>(base.NativePtr + (IntPtr)TsBaseCharacter.__PropertyOffset_BattleSockets, this));
			}
			return result;
		}
	}

	// Token: 0x17000607 RID: 1543
	// (get) Token: 0x060057E9 RID: 22505 RVA: 0x00105A08 File Offset: 0x00103C08
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<FName> NormalSockets
	{
		[NullableContext(1)]
		get
		{
			base.FastCheckIsValid();
			TArray<FName> result;
			if ((result = this._NormalSockets) == null)
			{
				result = (this._NormalSockets = new TArray<FName>(base.NativePtr + (IntPtr)TsBaseCharacter.__PropertyOffset_NormalSockets, this));
			}
			return result;
		}
	}

	// Token: 0x17000608 RID: 1544
	// (get) Token: 0x060057EA RID: 22506 RVA: 0x00105A41 File Offset: 0x00103C41
	// (set) Token: 0x060057EB RID: 22507 RVA: 0x00105A55 File Offset: 0x00103C55
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe PD_CharacterControllerData_C WeaponInEffect
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<PD_CharacterControllerData_C>(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_WeaponInEffect);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_WeaponInEffect, value);
		}
	}

	// Token: 0x17000609 RID: 1545
	// (get) Token: 0x060057EC RID: 22508 RVA: 0x00105A6A File Offset: 0x00103C6A
	// (set) Token: 0x060057ED RID: 22509 RVA: 0x00105A7E File Offset: 0x00103C7E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UEffectModelBase WeaponHideEffect
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UEffectModelBase>(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_WeaponHideEffect);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_WeaponHideEffect, value);
		}
	}

	// Token: 0x1700060A RID: 1546
	// (get) Token: 0x060057EE RID: 22510 RVA: 0x00105A93 File Offset: 0x00103C93
	// (set) Token: 0x060057EF RID: 22511 RVA: 0x00105AA7 File Offset: 0x00103CA7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UPrimaryDataAsset FkData
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UPrimaryDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_FkData);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_FkData, value);
		}
	}

	// Token: 0x1700060B RID: 1547
	// (get) Token: 0x060057F0 RID: 22512 RVA: 0x00105ABC File Offset: 0x00103CBC
	// (set) Token: 0x060057F1 RID: 22513 RVA: 0x00105AD0 File Offset: 0x00103CD0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UPrimaryDataAsset CharacterData
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UPrimaryDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_CharacterData);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_CharacterData, value);
		}
	}

	// Token: 0x1700060C RID: 1548
	// (get) Token: 0x060057F2 RID: 22514 RVA: 0x00105AE5 File Offset: 0x00103CE5
	// (set) Token: 0x060057F3 RID: 22515 RVA: 0x00105AF5 File Offset: 0x00103CF5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe ECamp Camp
	{
		get
		{
			return (ECamp)(*(base.NativePtr + (IntPtr)TsBaseCharacter.__PropertyOffset_Camp));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsBaseCharacter.__PropertyOffset_Camp) = (byte)value;
		}
	}

	// Token: 0x060057F4 RID: 22516 RVA: 0x00105B06 File Offset: 0x00103D06
	public void SetCamp(ECamp camp)
	{
		this.Camp = camp;
	}

	// Token: 0x1700060D RID: 1549
	// (get) Token: 0x060057F5 RID: 22517 RVA: 0x00105B0F File Offset: 0x00103D0F
	// (set) Token: 0x060057F6 RID: 22518 RVA: 0x00105B1F File Offset: 0x00103D1F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool PhysicsClothSimulateEnable
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsBaseCharacter.__PropertyOffset_PhysicsClothSimulateEnable) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsBaseCharacter.__PropertyOffset_PhysicsClothSimulateEnable) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700060E RID: 1550
	// (get) Token: 0x060057F7 RID: 22519 RVA: 0x00105B30 File Offset: 0x00103D30
	// (set) Token: 0x060057F8 RID: 22520 RVA: 0x00105B40 File Offset: 0x00103D40
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool PhysicsClothSimulateDisableOneFrame
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsBaseCharacter.__PropertyOffset_PhysicsClothSimulateDisableOneFrame) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsBaseCharacter.__PropertyOffset_PhysicsClothSimulateDisableOneFrame) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700060F RID: 1551
	// (get) Token: 0x060057F9 RID: 22521 RVA: 0x00105B51 File Offset: 0x00103D51
	// (set) Token: 0x060057FA RID: 22522 RVA: 0x00105B61 File Offset: 0x00103D61
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool CachePoseEnableOneFrame
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsBaseCharacter.__PropertyOffset_CachePoseEnableOneFrame) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsBaseCharacter.__PropertyOffset_CachePoseEnableOneFrame) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000610 RID: 1552
	// (get) Token: 0x060057FB RID: 22523 RVA: 0x00105B72 File Offset: 0x00103D72
	// (set) Token: 0x060057FC RID: 22524 RVA: 0x00105B82 File Offset: 0x00103D82
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float CacheTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsBaseCharacter.__PropertyOffset_CacheTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsBaseCharacter.__PropertyOffset_CacheTime) = value;
		}
	}

	// Token: 0x17000611 RID: 1553
	// (get) Token: 0x060057FD RID: 22525 RVA: 0x00105B93 File Offset: 0x00103D93
	// (set) Token: 0x060057FE RID: 22526 RVA: 0x00105BA7 File Offset: 0x00103DA7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UDataTable DtGameplayAbpConfig
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_DtGameplayAbpConfig);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseCharacter.__PropertyOffset_DtGameplayAbpConfig, value);
		}
	}

	// Token: 0x17000612 RID: 1554
	// (get) Token: 0x060057FF RID: 22527 RVA: 0x00105BBC File Offset: 0x00103DBC
	// (set) Token: 0x06005800 RID: 22528 RVA: 0x00105BC4 File Offset: 0x00103DC4
	public CharacterActorComponent CharacterActorComponent { get; set; }

	// Token: 0x17000613 RID: 1555
	// (get) Token: 0x06005801 RID: 22529 RVA: 0x00105BCD File Offset: 0x00103DCD
	// (set) Token: 0x06005802 RID: 22530 RVA: 0x00105BD5 File Offset: 0x00103DD5
	public SimpleNpcActorComponent SimpleNpcActorComponent { get; set; }

	// Token: 0x06005803 RID: 22531 RVA: 0x00105BE0 File Offset: 0x00103DE0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void K2_OnMovementModeChanged(EMovementMode prevMovementMode, EMovementMode newMovementMode, byte prevCustomMode, byte newCustomMode)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_OnMovementModeChanged"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		ACharacter.__K2_OnMovementModeChanged_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((ACharacter.__K2_OnMovementModeChanged_FunctionParams*)ptr + 15L / (long)sizeof(ACharacter.__K2_OnMovementModeChanged_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(byte*)(&ptr2->PrevMovementMode) = (byte)prevMovementMode;
			*(byte*)(&ptr2->NewMovementMode) = (byte)newMovementMode;
			ptr2->PrevCustomMode = prevCustomMode;
			ptr2->NewCustomMode = newCustomMode;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06005804 RID: 22532 RVA: 0x00105C74 File Offset: 0x00103E74
	protected virtual void K2_OnMovementModeChanged_Implementation(EMovementMode prevMovementMode, EMovementMode newMovementMode, byte prevCustomMode, byte newCustomMode)
	{
		if (this.CharacterActorComponent == null)
		{
			return;
		}
		this.OnMovementModeChanged = true;
		Singleton<EventSystem>.Instance.EmitWithTarget<int, EMovementMode, EMovementMode, byte, byte>(this.CharacterActorComponent.Entity, EEventName.CharMovementModeChanged, this.CharacterActorComponent.Entity.Id, prevMovementMode, newMovementMode, prevCustomMode, newCustomMode);
		this.OnMovementModeChanged = false;
	}

	// Token: 0x06005805 RID: 22533 RVA: 0x00105CC8 File Offset: 0x00103EC8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void BindGameplayEnableState(ref bool gameplayEnable)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("BindGameplayEnableState"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsBaseCharacter.__BindGameplayEnableState_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsBaseCharacter.__BindGameplayEnableState_FunctionParams*)ptr + 15L / (long)sizeof(TsBaseCharacter.__BindGameplayEnableState_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->gameplayEnable = gameplayEnable;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		gameplayEnable = ptr2->gameplayEnable;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06005806 RID: 22534 RVA: 0x00105D47 File Offset: 0x00103F47
	protected void BindGameplayEnableState_Implementation(ref bool gameplayEnable)
	{
		this.AbpGameplayEnableState = new bool?(gameplayEnable);
	}

	// Token: 0x06005807 RID: 22535 RVA: 0x00105D56 File Offset: 0x00103F56
	public void SetGameplayEnableState(bool enable)
	{
		if (this.AbpGameplayEnableState == null)
		{
			return;
		}
		this.AbpGameplayEnableState = new bool?(enable);
	}

	// Token: 0x06005808 RID: 22536 RVA: 0x00105D74 File Offset: 0x00103F74
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceivePossessed(AController newController)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceivePossessed"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		APawn.__ReceivePossessed_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((APawn.__ReceivePossessed_FunctionParams*)ptr + 15L / (long)sizeof(APawn.__ReceivePossessed_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->NewController) = ((newController != null) ? newController.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06005809 RID: 22537 RVA: 0x00105DF8 File Offset: 0x00103FF8
	protected virtual void ReceivePossessed_Implementation(AController newController)
	{
		if (this.CharacterActorComponent == null || !(newController is BP_CharacterController_C))
		{
			return;
		}
		Singleton<EventSystem>.Instance.EmitWithTarget<Entity, AController>(this.CharacterActorComponent.Entity, EEventName.CharPossessed, this.CharacterActorComponent.Entity, newController);
	}

	// Token: 0x0600580A RID: 22538 RVA: 0x00105E34 File Offset: 0x00104034
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveUnpossessed(AController oldController)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveUnpossessed"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		APawn.__ReceiveUnpossessed_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((APawn.__ReceiveUnpossessed_FunctionParams*)ptr + 15L / (long)sizeof(APawn.__ReceiveUnpossessed_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->OldController) = ((oldController != null) ? oldController.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0600580B RID: 22539 RVA: 0x00105EB8 File Offset: 0x001040B8
	protected virtual void ReceiveUnpossessed_Implementation(AController oldController)
	{
		if (this.CharacterActorComponent == null || !(oldController is BP_CharacterController_C))
		{
			return;
		}
		Singleton<EventSystem>.Instance.EmitWithTarget<Entity, AController>(this.CharacterActorComponent.Entity, EEventName.CharUnpossessed, this.CharacterActorComponent.Entity, oldController);
	}

	// Token: 0x0600580C RID: 22540 RVA: 0x00105EF4 File Offset: 0x001040F4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual int GetEntityId()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetEntityId"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsBaseCharacter.__GetEntityId_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsBaseCharacter.__GetEntityId_FunctionParams*)ptr + 15L / (long)sizeof(TsBaseCharacter.__GetEntityId_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		int _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0600580D RID: 22541 RVA: 0x00105F69 File Offset: 0x00104169
	protected int GetEntityId_Implementation()
	{
		return ((IBPI_CreatureInterface_C)this).GetEntityId();
	}

	// Token: 0x0600580E RID: 22542 RVA: 0x00105F71 File Offset: 0x00104171
	int IBPI_CreatureInterface_C.GetEntityId()
	{
		if (this.CharacterActorComponent != null)
		{
			return this.CharacterActorComponent.Entity.Id;
		}
		if (this.SimpleNpcActorComponent != null)
		{
			return this.SimpleNpcActorComponent.Entity.Id;
		}
		return 0;
	}

	// Token: 0x0600580F RID: 22543 RVA: 0x00105FA6 File Offset: 0x001041A6
	public int GetEntityIdNoBlueprint()
	{
		if (this.CharacterActorComponent != null)
		{
			return this.CharacterActorComponent.Entity.Id;
		}
		if (this.SimpleNpcActorComponent != null)
		{
			return this.SimpleNpcActorComponent.Entity.Id;
		}
		return 0;
	}

	// Token: 0x06005810 RID: 22544 RVA: 0x00105FDB File Offset: 0x001041DB
	public Entity GetEntityNoBlueprint()
	{
		if (this.CharacterActorComponent != null)
		{
			return this.CharacterActorComponent.Entity;
		}
		if (this.SimpleNpcActorComponent != null)
		{
			return this.SimpleNpcActorComponent.Entity;
		}
		return null;
	}

	// Token: 0x06005811 RID: 22545 RVA: 0x00106008 File Offset: 0x00104208
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void Initialize()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("Initialize"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06005812 RID: 22546 RVA: 0x00106078 File Offset: 0x00104278
	protected void Initialize_Implementation()
	{
	}

	// Token: 0x17000614 RID: 1556
	// (get) Token: 0x06005813 RID: 22547 RVA: 0x0010607C File Offset: 0x0010427C
	// (set) Token: 0x06005814 RID: 22548 RVA: 0x001060A8 File Offset: 0x001042A8
	[Nullable(1)]
	public CharacterDitherEffectController DitherEffectController
	{
		[NullableContext(1)]
		get
		{
			CharacterDitherEffectController result;
			if ((result = this.DitherEffectControllerInternal) == null)
			{
				result = (this.DitherEffectControllerInternal = new CharacterDitherEffectController(this, this.CharRenderingComponent));
			}
			return result;
		}
		[NullableContext(1)]
		set
		{
			this.DitherEffectControllerInternal = value;
		}
	}

	// Token: 0x17000615 RID: 1557
	// (get) Token: 0x06005815 RID: 22549 RVA: 0x001060B1 File Offset: 0x001042B1
	public bool HasDitherEffectController
	{
		get
		{
			return this.DitherEffectControllerInternal != null;
		}
	}

	// Token: 0x06005816 RID: 22550 RVA: 0x001060BC File Offset: 0x001042BC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetDitherEffect(float dither, ECharacterDitherType ditherType = ECharacterDitherType.Temporary)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetDitherEffect"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsBaseCharacter.__SetDitherEffect_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsBaseCharacter.__SetDitherEffect_FunctionParams*)ptr + 15L / (long)sizeof(TsBaseCharacter.__SetDitherEffect_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->dither = dither;
			*(&ptr2->ditherType) = (byte)ditherType;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06005817 RID: 22551 RVA: 0x0010613B File Offset: 0x0010433B
	protected void SetDitherEffect_Implementation(float dither, ECharacterDitherType ditherType = ECharacterDitherType.Temporary)
	{
		if (this.HasDitherEffectController)
		{
			CharacterDitherEffectController ditherEffectController = this.DitherEffectController;
			if (ditherEffectController == null)
			{
				return;
			}
			ditherEffectController.SetDitherEffect((double)dither, ditherType, true);
		}
	}

	// Token: 0x06005818 RID: 22552 RVA: 0x0010615C File Offset: 0x0010435C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void K2_UpdateCustomMovement(float delta)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_UpdateCustomMovement"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		ACharacter.__K2_UpdateCustomMovement_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((ACharacter.__K2_UpdateCustomMovement_FunctionParams*)ptr + 15L / (long)sizeof(ACharacter.__K2_UpdateCustomMovement_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->DeltaTime = delta;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06005819 RID: 22553 RVA: 0x001061D4 File Offset: 0x001043D4
	protected virtual void K2_UpdateCustomMovement_Implementation(float delta)
	{
		switch (base.CharacterMovement.CustomMovementMode)
		{
		case 0:
			Singleton<EventSystem>.Instance.EmitWithTarget<float>(this.CharacterActorComponent.Entity, EEventName.CustomMoveClimb, delta);
			return;
		case 1:
			Singleton<EventSystem>.Instance.EmitWithTarget<float>(this.CharacterActorComponent.Entity, EEventName.CustomMoveSwim, delta);
			return;
		case 2:
			Singleton<EventSystem>.Instance.EmitWithTarget<float>(this.CharacterActorComponent.Entity, EEventName.CustomMoveGlide, delta);
			return;
		case 3:
			Singleton<EventSystem>.Instance.EmitWithTarget<float>(this.CharacterActorComponent.Entity, EEventName.CustomMovePendulum, delta);
			return;
		case 4:
			Singleton<EventSystem>.Instance.EmitWithTarget<float>(this.CharacterActorComponent.Entity, EEventName.CustomMoveSlide, delta);
			return;
		case 5:
			Singleton<EventSystem>.Instance.EmitWithTarget<float>(this.CharacterActorComponent.Entity, EEventName.CustomMoveWalkOnWater, delta);
			return;
		case 6:
			Singleton<EventSystem>.Instance.EmitWithTarget<float>(this.CharacterActorComponent.Entity, EEventName.CustomMoveCatapult, delta);
			return;
		case 7:
			Singleton<EventSystem>.Instance.EmitWithTarget<float>(this.CharacterActorComponent.Entity, EEventName.CustomMoveSoar, delta);
			return;
		case 8:
			Singleton<EventSystem>.Instance.EmitWithTarget<float>(this.CharacterActorComponent.Entity, EEventName.CustomMoveSki, delta);
			return;
		case 9:
			Singleton<EventSystem>.Instance.EmitWithTarget<float>(this.CharacterActorComponent.Entity, EEventName.CustomMoveRoll, delta);
			return;
		case 10:
		{
			CharacterActorComponent characterActorComponent = this.CharacterActorComponent;
			if (characterActorComponent == null)
			{
				return;
			}
			CharacterKiteComponent component = characterActorComponent.Entity.GetComponent<CharacterKiteComponent>();
			if (component == null)
			{
				return;
			}
			component.KiteMove(delta);
			return;
		}
		case 11:
			Singleton<EventSystem>.Instance.EmitWithTarget<float>(this.CharacterActorComponent.Entity, EEventName.CustomMoveRide, delta);
			return;
		case 12:
			Singleton<EventSystem>.Instance.EmitWithTarget<float>(this.CharacterActorComponent.Entity, EEventName.CustomMoveRailSlide, delta);
			return;
		case 13:
			Singleton<EventSystem>.Instance.EmitWithTarget<float>(this.CharacterActorComponent.Entity, EEventName.CustomMoveSplineClimb, delta);
			break;
		case 14:
			break;
		case 15:
			Singleton<EventSystem>.Instance.EmitWithTarget<float>(this.CharacterActorComponent.Entity, EEventName.CustomMoveFloating, delta);
			return;
		default:
			return;
		}
	}

	// Token: 0x0600581A RID: 22554 RVA: 0x001063C0 File Offset: 0x001045C0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void FightCommand(bool isInAir)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("FightCommand"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsBaseCharacter.__FightCommand_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsBaseCharacter.__FightCommand_FunctionParams*)ptr + 15L / (long)sizeof(TsBaseCharacter.__FightCommand_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->isInAir = isInAir;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0600581B RID: 22555 RVA: 0x00106436 File Offset: 0x00104636
	protected void FightCommand_Implementation(bool isInAir)
	{
	}

	// Token: 0x0600581C RID: 22556 RVA: 0x00106438 File Offset: 0x00104638
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveDestroyed()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveDestroyed"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0600581D RID: 22557 RVA: 0x001064A8 File Offset: 0x001046A8
	protected virtual void ReceiveDestroyed_Implementation()
	{
		if (!ObjectUtils.IsValid(this))
		{
			return;
		}
		this.CharRenderingComponent = null;
		this.NavigationInvoker = null;
		this.InputComponentClass = null;
		this.FightManager = null;
		this.DtHitEffect = null;
		this.DtBaseMovementSetting = null;
		this.DtNewBulletDataMain = null;
		this.DtCharacterPart = null;
		this.WeaponInEffect = null;
		this.WeaponHideEffect = null;
		this.FkData = null;
		this.CharacterData = null;
		this.CharacterActorComponent = null;
		this.DitherEffectControllerInternal = null;
		TsCharacterDebugComponent tsCharacterDebugComponent = this.TsCharacterDebugComponent;
		if (tsCharacterDebugComponent != null)
		{
			tsCharacterDebugComponent.Destroy();
		}
		this.TsCharacterDebugComponent = null;
	}

	// Token: 0x17000616 RID: 1558
	// (get) Token: 0x0600581E RID: 22558 RVA: 0x00106538 File Offset: 0x00104738
	[Nullable(1)]
	private Queue<SetMovementModeInfo>[] MovementModeLayer
	{
		[NullableContext(1)]
		get
		{
			if (this.MovementModeLayerInternal == null)
			{
				this.MovementModeLayerInternal = new Queue<SetMovementModeInfo>[]
				{
					new Queue<SetMovementModeInfo>(4),
					new Queue<SetMovementModeInfo>(4),
					new Queue<SetMovementModeInfo>(4),
					new Queue<SetMovementModeInfo>(4)
				};
			}
			return this.MovementModeLayerInternal;
		}
	}

	// Token: 0x17000617 RID: 1559
	// (get) Token: 0x0600581F RID: 22559 RVA: 0x00106578 File Offset: 0x00104778
	// (set) Token: 0x06005820 RID: 22560 RVA: 0x00106580 File Offset: 0x00104780
	private SetMovementModeInfo CurrentMovementParam { get; set; }

	// Token: 0x06005821 RID: 22561 RVA: 0x0010658C File Offset: 0x0010478C
	[NullableContext(1)]
	public unsafe void KuroSetMovementMode(SetMovementModeInfo @params)
	{
		if (base.CharacterMovement == null)
		{
			return;
		}
		int num = 0;
		if (this.CharacterActorComponent != null)
		{
			num = this.CharacterActorComponent.Entity.Id;
		}
		else if (this.SimpleNpcActorComponent != null)
		{
			num = this.SimpleNpcActorComponent.Entity.Id;
		}
		if (!this.Mutex)
		{
			this.Mutex = true;
			this.Count++;
			this.CurrentMovementParam = @params;
			TEnumAsByte<EMovementMode> movementMode = base.CharacterMovement.MovementMode;
			byte customMovementMode = base.CharacterMovement.CustomMovementMode;
			if (movementMode != @params.Mode || customMovementMode != @params.CustomMode)
			{
				EMovementMode mode = @params.Mode;
			}
			base.CharacterMovement.SetMovementMode(@params.Mode, @params.CustomMode);
			if (@params.Callback != null)
			{
				try
				{
					@params.Callback();
				}
				catch (Exception ex)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Character;
					ELogAuthor author = ELogAuthor.CWZ;
					string message = "[SetMovementMode] 回调执行异常";
					Exception error = ex;
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", num);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Error", ex.Message);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Context", @params.Context);
					instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				}
			}
			this.Mutex = false;
			int count = this.Count;
			if (count <= 3)
			{
				while (!this.MovementModeLayer[count].Empty)
				{
					SetMovementModeInfo params2 = this.MovementModeLayer[count].Pop();
					this.KuroSetMovementMode(params2);
				}
			}
			this.Count--;
			this.CurrentMovementParam = null;
			return;
		}
		if (this.Count > 3)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Character;
			ELogAuthor author2 = ELogAuthor.CWZ;
			string message2 = "[SetMovementMode] 产生嵌套循环层数过高，不往后执行";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", num);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		int movementModeInfoUid = this.MovementModeInfoUid;
		this.MovementModeInfoUid = movementModeInfoUid + 1;
		@params.Uid = new long?((long)movementModeInfoUid);
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module3 = ELogModule.Character;
		ELogAuthor author3 = ELogAuthor.CWZ;
		string message3 = "[SetMovementMode] 产生嵌套设置，加入队列";
		<>y__InlineArray9<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray9<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityId", num);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("UID", @params.Uid);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Count", this.Count);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("Mode", @params.Mode);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 4) = new ValueTuple<string, object>("Context", @params.Context);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 5) = new ValueTuple<string, object>("CustomMode", @params.CustomMode);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 6);
		string item = "now Mode";
		SetMovementModeInfo currentMovementParam = this.CurrentMovementParam;
		ptr = new ValueTuple<string, object>(item, (currentMovementParam != null) ? new EMovementMode?(currentMovementParam.Mode) : null);
		ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 7);
		string item2 = "now Context";
		SetMovementModeInfo currentMovementParam2 = this.CurrentMovementParam;
		ptr2 = new ValueTuple<string, object>(item2, (currentMovementParam2 != null) ? currentMovementParam2.Context : null);
		ref ValueTuple<string, object> ptr3 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 8);
		string item3 = "now CustomMode";
		SetMovementModeInfo currentMovementParam3 = this.CurrentMovementParam;
		ptr3 = new ValueTuple<string, object>(item3, (currentMovementParam3 != null) ? new byte?(currentMovementParam3.CustomMode) : null);
		instance3.Warn(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 9));
		this.MovementModeLayer[this.Count].Push(@params);
	}

	// Token: 0x06005822 RID: 22562 RVA: 0x00106948 File Offset: 0x00104B48
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsBaseCharacter._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Character/TsBaseCharacter.TsBaseCharacter_C");
		}
		return TsBaseCharacter._ClassPtr;
	}

	// Token: 0x06005823 RID: 22563 RVA: 0x0010696C File Offset: 0x00104B6C
	public TsBaseCharacter() : this(BuiltinUtils.AllocNativeUObject(TsBaseCharacter.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005824 RID: 22564 RVA: 0x00106994 File Offset: 0x00104B94
	[NullableContext(1)]
	public TsBaseCharacter(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsBaseCharacter.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005825 RID: 22565 RVA: 0x001069C7 File Offset: 0x00104BC7
	protected TsBaseCharacter(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005826 RID: 22566 RVA: 0x001069D0 File Offset: 0x00104BD0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_OnMovementModeChanged_Implementation(ACharacter.__K2_OnMovementModeChanged_FunctionParams* __Params)
	{
		EMovementMode prevMovementMode = __Params->PrevMovementMode;
		EMovementMode newMovementMode = __Params->NewMovementMode;
		this.K2_OnMovementModeChanged_Implementation(prevMovementMode, newMovementMode, __Params->PrevCustomMode, __Params->NewCustomMode);
	}

	// Token: 0x06005827 RID: 22567 RVA: 0x00106A09 File Offset: 0x00104C09
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_BindGameplayEnableState_Implementation(TsBaseCharacter.__BindGameplayEnableState_FunctionParams* __Params)
	{
		this.BindGameplayEnableState_Implementation(ref __Params->gameplayEnable);
	}

	// Token: 0x06005828 RID: 22568 RVA: 0x00106A18 File Offset: 0x00104C18
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceivePossessed_Implementation(APawn.__ReceivePossessed_FunctionParams* __Params)
	{
		AController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AController>(__Params->NewController);
		this.ReceivePossessed_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x06005829 RID: 22569 RVA: 0x00106A38 File Offset: 0x00104C38
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveUnpossessed_Implementation(APawn.__ReceiveUnpossessed_FunctionParams* __Params)
	{
		AController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AController>(__Params->OldController);
		this.ReceiveUnpossessed_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0600582A RID: 22570 RVA: 0x00106A58 File Offset: 0x00104C58
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetEntityId_Implementation(TsBaseCharacter.__GetEntityId_FunctionParams* __Params)
	{
		__Params->__Result = this.GetEntityId_Implementation();
	}

	// Token: 0x0600582B RID: 22571 RVA: 0x00106A66 File Offset: 0x00104C66
	protected virtual void __CPPCALL_Initialize_Implementation()
	{
		this.Initialize_Implementation();
	}

	// Token: 0x0600582C RID: 22572 RVA: 0x00106A70 File Offset: 0x00104C70
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_SetDitherEffect_Implementation(TsBaseCharacter.__SetDitherEffect_FunctionParams* __Params)
	{
		ECharacterDitherType ditherType = (ECharacterDitherType)__Params->ditherType;
		this.SetDitherEffect_Implementation(__Params->dither, ditherType);
	}

	// Token: 0x0600582D RID: 22573 RVA: 0x00106A91 File Offset: 0x00104C91
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_UpdateCustomMovement_Implementation(ACharacter.__K2_UpdateCustomMovement_FunctionParams* __Params)
	{
		this.K2_UpdateCustomMovement_Implementation(__Params->DeltaTime);
	}

	// Token: 0x0600582E RID: 22574 RVA: 0x00106A9F File Offset: 0x00104C9F
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_FightCommand_Implementation(TsBaseCharacter.__FightCommand_FunctionParams* __Params)
	{
		this.FightCommand_Implementation(__Params->isInAir);
	}

	// Token: 0x0600582F RID: 22575 RVA: 0x00106AAD File Offset: 0x00104CAD
	protected virtual void __CPPCALL_ReceiveDestroyed_Implementation()
	{
		this.ReceiveDestroyed_Implementation();
	}

	// Token: 0x04001DB0 RID: 7600
	public bool OnMovementModeChanged;

	// Token: 0x04001DB3 RID: 7603
	public bool? AbpGameplayEnableState;

	// Token: 0x04001DB4 RID: 7604
	private CharacterDitherEffectController DitherEffectControllerInternal;

	// Token: 0x04001DB5 RID: 7605
	private int MovementModeInfoUid;

	// Token: 0x04001DB6 RID: 7606
	private int Count;

	// Token: 0x04001DB7 RID: 7607
	private bool Mutex;

	// Token: 0x04001DB8 RID: 7608
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Queue<SetMovementModeInfo>[] MovementModeLayerInternal;

	// Token: 0x04001DBA RID: 7610
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Character/TsBaseCharacter.TsBaseCharacter_C";

	// Token: 0x04001DBB RID: 7611
	private static IntPtr _ClassPtr;

	// Token: 0x04001DBC RID: 7612
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001DBD RID: 7613
	private static int __PropertyOffset_CharRenderingComponent;

	// Token: 0x04001DBE RID: 7614
	private static int __PropertyOffset_RenderType;

	// Token: 0x04001DBF RID: 7615
	private static int __PropertyOffset_TsCharacterDebugComponent;

	// Token: 0x04001DC0 RID: 7616
	private static int __PropertyOffset_NavigationInvoker;

	// Token: 0x04001DC1 RID: 7617
	private static int __PropertyOffset_InputComponentClass;

	// Token: 0x04001DC2 RID: 7618
	private FSoftClassPath _InputComponentClass;

	// Token: 0x04001DC3 RID: 7619
	private static int __PropertyOffset_BasePlatform;

	// Token: 0x04001DC4 RID: 7620
	private static int __PropertyOffset_EntityId;

	// Token: 0x04001DC5 RID: 7621
	private static int __PropertyOffset_FightManager;

	// Token: 0x04001DC6 RID: 7622
	private static int __PropertyOffset_DtHitEffect;

	// Token: 0x04001DC7 RID: 7623
	private static int __PropertyOffset_DtBaseMovementSetting;

	// Token: 0x04001DC8 RID: 7624
	private static int __PropertyOffset_DtNewBulletDataMain;

	// Token: 0x04001DC9 RID: 7625
	private static int __PropertyOffset_DtCharacterPart;

	// Token: 0x04001DCA RID: 7626
	private static int __PropertyOffset_DtCameraConfig;

	// Token: 0x04001DCB RID: 7627
	private static int __PropertyOffset_BattleSockets;

	// Token: 0x04001DCC RID: 7628
	private TArray<FName> _BattleSockets;

	// Token: 0x04001DCD RID: 7629
	private static int __PropertyOffset_NormalSockets;

	// Token: 0x04001DCE RID: 7630
	private TArray<FName> _NormalSockets;

	// Token: 0x04001DCF RID: 7631
	private static int __PropertyOffset_WeaponInEffect;

	// Token: 0x04001DD0 RID: 7632
	private static int __PropertyOffset_WeaponHideEffect;

	// Token: 0x04001DD1 RID: 7633
	private static int __PropertyOffset_FkData;

	// Token: 0x04001DD2 RID: 7634
	private static int __PropertyOffset_CharacterData;

	// Token: 0x04001DD3 RID: 7635
	private static int __PropertyOffset_Camp;

	// Token: 0x04001DD4 RID: 7636
	private static int __PropertyOffset_PhysicsClothSimulateEnable;

	// Token: 0x04001DD5 RID: 7637
	private static int __PropertyOffset_PhysicsClothSimulateDisableOneFrame;

	// Token: 0x04001DD6 RID: 7638
	private static int __PropertyOffset_CachePoseEnableOneFrame;

	// Token: 0x04001DD7 RID: 7639
	private static int __PropertyOffset_CacheTime;

	// Token: 0x04001DD8 RID: 7640
	private static int __PropertyOffset_DtGameplayAbpConfig;

	// Token: 0x02007290 RID: 29328
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __BindGameplayEnableState_FunctionParams
	{
		// Token: 0x04027BDA RID: 162778
		[FieldOffset(0)]
		public bool gameplayEnable;
	}

	// Token: 0x02007291 RID: 29329
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __GetEntityId_FunctionParams
	{
		// Token: 0x04027BDB RID: 162779
		[FieldOffset(0)]
		public int __Result;
	}

	// Token: 0x02007292 RID: 29330
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __SetDitherEffect_FunctionParams
	{
		// Token: 0x04027BDC RID: 162780
		[FieldOffset(0)]
		public float dither;

		// Token: 0x04027BDD RID: 162781
		[FieldOffset(4)]
		public byte ditherType;
	}

	// Token: 0x02007293 RID: 29331
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __FightCommand_FunctionParams
	{
		// Token: 0x04027BDE RID: 162782
		[FieldOffset(0)]
		public bool isInAir;
	}
}
