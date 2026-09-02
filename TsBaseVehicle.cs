using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.CreatureTools;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x020032A1 RID: 12961
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Vehicle/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Vehicle/TsBaseVehicle.TsBaseVehicle_C")]
public class TsBaseVehicle : AKuroBaseVehicle, IBPI_CreatureInterface_C, IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject, IUnrealUObject
{
	// Token: 0x170024F5 RID: 9461
	// (get) Token: 0x0601B2B6 RID: 111286 RVA: 0x0082B08A File Offset: 0x0082928A
	// (set) Token: 0x0601B2B7 RID: 111287 RVA: 0x0082B09A File Offset: 0x0082929A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int EntityId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsBaseVehicle.__PropertyOffset_EntityId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsBaseVehicle.__PropertyOffset_EntityId) = value;
		}
	}

	// Token: 0x0601B2B8 RID: 111288 RVA: 0x0082B0AB File Offset: 0x008292AB
	public void SetEntityId(int entityId)
	{
		this.EntityId = entityId;
		base.EntityIdInternal = entityId;
	}

	// Token: 0x170024F6 RID: 9462
	// (get) Token: 0x0601B2B9 RID: 111289 RVA: 0x0082B0BB File Offset: 0x008292BB
	// (set) Token: 0x0601B2BA RID: 111290 RVA: 0x0082B0CF File Offset: 0x008292CF
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe CharRenderingComponent CharRenderingComponent
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<CharRenderingComponent>(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseVehicle.__PropertyOffset_CharRenderingComponent);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseVehicle.__PropertyOffset_CharRenderingComponent, value);
		}
	}

	// Token: 0x170024F7 RID: 9463
	// (get) Token: 0x0601B2BB RID: 111291 RVA: 0x0082B0E4 File Offset: 0x008292E4
	// (set) Token: 0x0601B2BC RID: 111292 RVA: 0x0082B0F4 File Offset: 0x008292F4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe ECharacterRenderingType RenderType
	{
		get
		{
			return (ECharacterRenderingType)(*(base.NativePtr + (IntPtr)TsBaseVehicle.__PropertyOffset_RenderType));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsBaseVehicle.__PropertyOffset_RenderType) = (byte)value;
		}
	}

	// Token: 0x170024F8 RID: 9464
	// (get) Token: 0x0601B2BD RID: 111293 RVA: 0x0082B108 File Offset: 0x00829308
	// (set) Token: 0x0601B2BE RID: 111294 RVA: 0x0082B141 File Offset: 0x00829341
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
				result = (this._InputComponentClass = new FSoftClassPath(base.NativePtr + (IntPtr)TsBaseVehicle.__PropertyOffset_InputComponentClass, this));
			}
			return result;
		}
		[NullableContext(1)]
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FSoftClassPath.StaticStruct(), base.NativePtr + (IntPtr)TsBaseVehicle.__PropertyOffset_InputComponentClass, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170024F9 RID: 9465
	// (get) Token: 0x0601B2BF RID: 111295 RVA: 0x0082B169 File Offset: 0x00829369
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe AActor PlatformActor
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseVehicle.__PropertyOffset_PlatformActor);
		}
	}

	// Token: 0x0601B2C0 RID: 111296 RVA: 0x0082B180 File Offset: 0x00829380
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual int GetEntityId()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetEntityId"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsBaseVehicle.__GetEntityId_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsBaseVehicle.__GetEntityId_FunctionParams*)ptr + 15L / (long)sizeof(TsBaseVehicle.__GetEntityId_FunctionParams) & -16L);
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

	// Token: 0x0601B2C1 RID: 111297 RVA: 0x0082B1F5 File Offset: 0x008293F5
	protected int GetEntityId_Implementation()
	{
		return ((IBPI_CreatureInterface_C)this).GetEntityId();
	}

	// Token: 0x0601B2C2 RID: 111298 RVA: 0x0082B1FD File Offset: 0x008293FD
	int IBPI_CreatureInterface_C.GetEntityId()
	{
		if (this.VehicleActorComponent != null)
		{
			return this.VehicleActorComponent.Entity.Id;
		}
		return 0;
	}

	// Token: 0x0601B2C3 RID: 111299 RVA: 0x0082B219 File Offset: 0x00829419
	public int GetEntityIdNoBlueprint()
	{
		if (this.VehicleActorComponent != null)
		{
			return this.VehicleActorComponent.Entity.Id;
		}
		return 0;
	}

	// Token: 0x0601B2C4 RID: 111300 RVA: 0x0082B235 File Offset: 0x00829435
	[NullableContext(2)]
	public Entity GetEntityNoBlueprint()
	{
		if (this.VehicleActorComponent != null)
		{
			return this.VehicleActorComponent.Entity;
		}
		return null;
	}

	// Token: 0x0601B2C5 RID: 111301 RVA: 0x0082B24C File Offset: 0x0082944C
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

	// Token: 0x0601B2C6 RID: 111302 RVA: 0x0082B2BC File Offset: 0x008294BC
	protected virtual void ReceiveDestroyed_Implementation()
	{
		if (!ObjectUtils.IsValid(this))
		{
			return;
		}
		this.InputComponentClass = null;
		this.VehicleActorComponent = null;
		this.CharRenderingComponent = null;
		this.DitherEffectControllerInternal = null;
	}

	// Token: 0x0601B2C7 RID: 111303 RVA: 0x0082B2E4 File Offset: 0x008294E4
	public void TryAddTsAbilitySystemComponent()
	{
		if (base.AbilitySystemComponent == null)
		{
			base.AbilitySystemComponent = (base.AddComponentByClass(UBaseAbilitySystemComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as UBaseAbilitySystemComponent);
		}
	}

	// Token: 0x170024FA RID: 9466
	// (get) Token: 0x0601B2C8 RID: 111304 RVA: 0x0082B329 File Offset: 0x00829529
	// (set) Token: 0x0601B2C9 RID: 111305 RVA: 0x0082B34B File Offset: 0x0082954B
	[Nullable(1)]
	public CharacterDitherEffectController DitherEffectController
	{
		[NullableContext(1)]
		get
		{
			if (this.DitherEffectControllerInternal == null)
			{
				this.DitherEffectControllerInternal = new CharacterDitherEffectController(this, this.CharRenderingComponent);
			}
			return this.DitherEffectControllerInternal;
		}
		[NullableContext(1)]
		set
		{
			this.DitherEffectControllerInternal = value;
		}
	}

	// Token: 0x170024FB RID: 9467
	// (get) Token: 0x0601B2CA RID: 111306 RVA: 0x0082B354 File Offset: 0x00829554
	public bool HasDitherEffectController
	{
		get
		{
			return this.DitherEffectControllerInternal != null;
		}
	}

	// Token: 0x0601B2CB RID: 111307 RVA: 0x0082B360 File Offset: 0x00829560
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetDitherEffect(float dither, ECharacterDitherType ditherType = ECharacterDitherType.Temporary)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetDitherEffect"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsBaseVehicle.__SetDitherEffect_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsBaseVehicle.__SetDitherEffect_FunctionParams*)ptr + 15L / (long)sizeof(TsBaseVehicle.__SetDitherEffect_FunctionParams) & -16L);
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

	// Token: 0x0601B2CC RID: 111308 RVA: 0x0082B3DF File Offset: 0x008295DF
	protected void SetDitherEffect_Implementation(float dither, ECharacterDitherType ditherType = ECharacterDitherType.Temporary)
	{
		this.DitherEffectController.SetDitherEffect((double)dither, ditherType, true);
	}

	// Token: 0x0601B2CD RID: 111309 RVA: 0x0082B3F0 File Offset: 0x008295F0
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsBaseVehicle._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Vehicle/TsBaseVehicle.TsBaseVehicle_C");
		}
		return TsBaseVehicle._ClassPtr;
	}

	// Token: 0x0601B2CE RID: 111310 RVA: 0x0082B414 File Offset: 0x00829614
	public TsBaseVehicle() : this(BuiltinUtils.AllocNativeUObject(TsBaseVehicle.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601B2CF RID: 111311 RVA: 0x0082B43C File Offset: 0x0082963C
	[NullableContext(1)]
	public TsBaseVehicle(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsBaseVehicle.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601B2D0 RID: 111312 RVA: 0x0082B46F File Offset: 0x0082966F
	protected TsBaseVehicle(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601B2D1 RID: 111313 RVA: 0x0082B478 File Offset: 0x00829678
	protected unsafe virtual void __CPPCALL_GetEntityId_Implementation(TsBaseVehicle.__GetEntityId_FunctionParams* __Params)
	{
		__Params->__Result = this.GetEntityId_Implementation();
	}

	// Token: 0x0601B2D2 RID: 111314 RVA: 0x0082B486 File Offset: 0x00829686
	protected virtual void __CPPCALL_ReceiveDestroyed_Implementation()
	{
		this.ReceiveDestroyed_Implementation();
	}

	// Token: 0x0601B2D3 RID: 111315 RVA: 0x0082B490 File Offset: 0x00829690
	protected unsafe virtual void __CPPCALL_SetDitherEffect_Implementation(TsBaseVehicle.__SetDitherEffect_FunctionParams* __Params)
	{
		ECharacterDitherType ditherType = (ECharacterDitherType)__Params->ditherType;
		this.SetDitherEffect_Implementation(__Params->dither, ditherType);
	}

	// Token: 0x0400DD50 RID: 56656
	[Nullable(2)]
	public VehicleActorComponent VehicleActorComponent;

	// Token: 0x0400DD51 RID: 56657
	[Nullable(2)]
	private CharacterDitherEffectController DitherEffectControllerInternal;

	// Token: 0x0400DD52 RID: 56658
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Vehicle/TsBaseVehicle.TsBaseVehicle_C";

	// Token: 0x0400DD53 RID: 56659
	private static IntPtr _ClassPtr;

	// Token: 0x0400DD54 RID: 56660
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400DD55 RID: 56661
	private static int __PropertyOffset_EntityId;

	// Token: 0x0400DD56 RID: 56662
	private static int __PropertyOffset_CharRenderingComponent;

	// Token: 0x0400DD57 RID: 56663
	private static int __PropertyOffset_RenderType;

	// Token: 0x0400DD58 RID: 56664
	private static int __PropertyOffset_InputComponentClass;

	// Token: 0x0400DD59 RID: 56665
	[Nullable(2)]
	private FSoftClassPath _InputComponentClass;

	// Token: 0x0400DD5A RID: 56666
	private static int __PropertyOffset_PlatformActor;

	// Token: 0x02009469 RID: 37993
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __GetEntityId_FunctionParams
	{
		// Token: 0x040313EC RID: 201708
		[FieldOffset(0)]
		public int __Result;
	}

	// Token: 0x0200946A RID: 37994
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __SetDitherEffect_FunctionParams
	{
		// Token: 0x040313ED RID: 201709
		[FieldOffset(0)]
		public float dither;

		// Token: 0x040313EE RID: 201710
		[FieldOffset(4)]
		public byte ditherType;
	}
}
