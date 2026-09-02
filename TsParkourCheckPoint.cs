using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game;
using CSharpScript.Game.Effect;
using CSharpScript.Game.LevelGamePlay.Parkour;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000FA1 RID: 4001
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/LevelGamePlay/Parkour/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/LevelGamePlay/Parkour/TsParkourCheckPoint.TsParkourCheckPoint_C")]
public class TsParkourCheckPoint : AActor, IUnrealUObject, IUnrealObject
{
	// Token: 0x170007EF RID: 2031
	// (get) Token: 0x06006642 RID: 26178 RVA: 0x0019C0EB File Offset: 0x0019A2EB
	// (set) Token: 0x06006643 RID: 26179 RVA: 0x0019C0FF File Offset: 0x0019A2FF
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe USphereComponent SphereComponent
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<USphereComponent>(base.NativePtr / (IntPtr)sizeof(void*) + TsParkourCheckPoint.__PropertyOffset_SphereComponent);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsParkourCheckPoint.__PropertyOffset_SphereComponent, value);
		}
	}

	// Token: 0x170007F0 RID: 2032
	// (get) Token: 0x06006644 RID: 26180 RVA: 0x0019C114 File Offset: 0x0019A314
	// (set) Token: 0x06006645 RID: 26181 RVA: 0x0019C124 File Offset: 0x0019A324
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int CheckPointIndex
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsParkourCheckPoint.__PropertyOffset_CheckPointIndex);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsParkourCheckPoint.__PropertyOffset_CheckPointIndex) = value;
		}
	}

	// Token: 0x170007F1 RID: 2033
	// (get) Token: 0x06006646 RID: 26182 RVA: 0x0019C135 File Offset: 0x0019A335
	// (set) Token: 0x06006647 RID: 26183 RVA: 0x0019C145 File Offset: 0x0019A345
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int IndexInGroup
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsParkourCheckPoint.__PropertyOffset_IndexInGroup);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsParkourCheckPoint.__PropertyOffset_IndexInGroup) = value;
		}
	}

	// Token: 0x170007F2 RID: 2034
	// (get) Token: 0x06006648 RID: 26184 RVA: 0x0019C156 File Offset: 0x0019A356
	// (set) Token: 0x06006649 RID: 26185 RVA: 0x0019C166 File Offset: 0x0019A366
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int ParkourId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsParkourCheckPoint.__PropertyOffset_ParkourId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsParkourCheckPoint.__PropertyOffset_ParkourId) = value;
		}
	}

	// Token: 0x170007F3 RID: 2035
	// (get) Token: 0x0600664A RID: 26186 RVA: 0x0019C177 File Offset: 0x0019A377
	// (set) Token: 0x0600664B RID: 26187 RVA: 0x0019C18B File Offset: 0x0019A38B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string CheckTag
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsParkourCheckPoint.__PropertyOffset_CheckTag)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsParkourCheckPoint.__PropertyOffset_CheckTag)), value);
		}
	}

	// Token: 0x170007F4 RID: 2036
	// (get) Token: 0x0600664C RID: 26188 RVA: 0x0019C1A0 File Offset: 0x0019A3A0
	// (set) Token: 0x0600664D RID: 26189 RVA: 0x0019C1B4 File Offset: 0x0019A3B4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string DestroyEffectModelBasePath
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsParkourCheckPoint.__PropertyOffset_DestroyEffectModelBasePath)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsParkourCheckPoint.__PropertyOffset_DestroyEffectModelBasePath)), value);
		}
	}

	// Token: 0x0600664E RID: 26190 RVA: 0x0019C1CC File Offset: 0x0019A3CC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveBeginPlay()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveBeginPlay"), out num);
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

	// Token: 0x0600664F RID: 26191 RVA: 0x0019C23C File Offset: 0x0019A43C
	protected virtual void ReceiveBeginPlay_Implementation()
	{
		this.FindComponents();
		this.SphereComponent.SetCollisionProfileName(TsParkourCheckPoint.PARKOUR_CHECK_POINT_PRESET, true);
		this.SphereComponent.bKuroPassiveCollisionUpdateOverlapsWhenEnterOverlap = true;
		this.SphereComponent.bKuroPassiveCollision = true;
		this.RegisterEvents();
	}

	// Token: 0x06006650 RID: 26192 RVA: 0x0019C274 File Offset: 0x0019A474
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveEndPlay(EEndPlayReason endPlayReason)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveEndPlay"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AActor.__ReceiveEndPlay_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AActor.__ReceiveEndPlay_FunctionParams*)ptr + 15L / (long)sizeof(AActor.__ReceiveEndPlay_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(byte*)(&ptr2->EndPlayReason) = (byte)endPlayReason;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06006651 RID: 26193 RVA: 0x0019C2F0 File Offset: 0x0019A4F0
	protected virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
	{
		this.RemoveEvents();
		if (this.EffectViewHandler != 0)
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.EffectViewHandler, "[TsParkourCheckPoint.ReceiveEndPlay]", false, null);
			this.EffectViewHandler = 0;
		}
		if (!StringUtils.IsEmpty(this.DestroyEffectModelBasePath))
		{
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			FTransformDouble? ftransformDouble = new FTransformDouble?(base.D_GetTransform());
			instance.SpawnUnloopedEffect(this, ftransformDouble, this.DestroyEffectModelBasePath, "[TsParkourCheckPoint.ReceiveEndPlay]", null, EEffectType.Scene, null, null, null, false, false);
		}
	}

	// Token: 0x06006652 RID: 26194 RVA: 0x0019C36C File Offset: 0x0019A56C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetDetectSphere(float inRadius)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetDetectSphere"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsParkourCheckPoint.__SetDetectSphere_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsParkourCheckPoint.__SetDetectSphere_FunctionParams*)ptr + 15L / (long)sizeof(TsParkourCheckPoint.__SetDetectSphere_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->inRadius = inRadius;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06006653 RID: 26195 RVA: 0x0019C3E2 File Offset: 0x0019A5E2
	protected void SetDetectSphere_Implementation(float inRadius)
	{
		this.SphereComponent.SetSphereRadius(inRadius, true);
	}

	// Token: 0x06006654 RID: 26196 RVA: 0x0019C3F4 File Offset: 0x0019A5F4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void GenerateFx(UEffectModelBase inModelBase)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GenerateFx"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsParkourCheckPoint.__GenerateFx_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsParkourCheckPoint.__GenerateFx_FunctionParams*)ptr + 15L / (long)sizeof(TsParkourCheckPoint.__GenerateFx_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->inModelBase) = ((inModelBase != null) ? inModelBase.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06006655 RID: 26197 RVA: 0x0019C478 File Offset: 0x0019A678
	protected void GenerateFx_Implementation(UEffectModelBase inModelBase)
	{
		string pathName = UKismetSystemLibrary.GetPathName(inModelBase);
		EffectSystem instance = Singleton<EffectSystem>.Instance;
		FTransformDouble? ftransformDouble = new FTransformDouble?(base.D_GetTransform());
		this.EffectViewHandler = instance.SpawnEffect(this, ftransformDouble, pathName, "[TsParkourCheckPoint.GenerateFx]", new EffectContext(null, this, false), EEffectType.Scene, null, null, null, false, false);
		if (!Singleton<EffectSystem>.Instance.IsValid(this.EffectViewHandler))
		{
			this.EffectViewHandler = 0;
		}
	}

	// Token: 0x06006656 RID: 26198 RVA: 0x0019C4E0 File Offset: 0x0019A6E0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void GenerateFxByPath(string effectPath)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GenerateFxByPath"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsParkourCheckPoint.__GenerateFxByPath_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsParkourCheckPoint.__GenerateFxByPath_FunctionParams*)ptr + 15L / (long)sizeof(TsParkourCheckPoint.__GenerateFxByPath_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->effectPath), effectPath);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06006657 RID: 26199 RVA: 0x0019C55C File Offset: 0x0019A75C
	protected void GenerateFxByPath_Implementation(string effectPath)
	{
		EffectSystem instance = Singleton<EffectSystem>.Instance;
		FTransformDouble? ftransformDouble = new FTransformDouble?(base.D_GetTransform());
		this.EffectViewHandler = instance.SpawnEffect(this, ftransformDouble, effectPath, "[TsParkourCheckPoint.GenerateFxByPath]", new EffectContext(null, this, false), EEffectType.Scene, null, null, null, false, false);
		if (!Singleton<EffectSystem>.Instance.IsValid(this.EffectViewHandler))
		{
			this.EffectViewHandler = 0;
		}
	}

	// Token: 0x06006658 RID: 26200 RVA: 0x0019C5BD File Offset: 0x0019A7BD
	private void FindComponents()
	{
		if (this.SphereComponent == null)
		{
			this.SphereComponent = (base.GetComponentByClass(USphereComponent.StaticClass()) as USphereComponent);
		}
	}

	// Token: 0x06006659 RID: 26201 RVA: 0x0019C5E4 File Offset: 0x0019A7E4
	private void RegisterEvents()
	{
		if (!this.EventRegistered)
		{
			this.SphereComponent.OnComponentBeginOverlapNoGcAlloc.Add(delegate(UPrimitiveComponent overlappedComponent, AActor otherActor, UPrimitiveComponent otherComp)
			{
				this.OnCollisionEnter(otherActor);
			});
			this.SphereComponent.OnComponentEndOverlap.Add(delegate(UPrimitiveComponent overlappedComponent, AActor otherActor, UPrimitiveComponent otherComp, int otherBodyIndex)
			{
				this.OnCollisionExit(otherActor);
			});
			this.EventRegistered = true;
		}
	}

	// Token: 0x0600665A RID: 26202 RVA: 0x0019C638 File Offset: 0x0019A838
	private void RemoveEvents()
	{
		if (this.SphereComponent != null)
		{
			this.SphereComponent.OnComponentBeginOverlapNoGcAlloc.Clear();
			this.SphereComponent.OnComponentEndOverlap.Clear();
		}
		this.EventRegistered = false;
	}

	// Token: 0x0600665B RID: 26203 RVA: 0x0019C66C File Offset: 0x0019A86C
	[NullableContext(2)]
	protected unsafe void OnCollisionEnter(AActor otherActor)
	{
		if (!ControllerBase<ParkourController>.Instance.MatchParkourRoleConfig(this.ParkourId))
		{
			return;
		}
		if (otherActor != ControllerBase<RoleTriggerController>.Instance.GetMyRoleTrigger())
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Level;
		ELogAuthor author = ELogAuthor.YZH;
		string message = "[ParkourCheckPoint]检测到玩家";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ParkourId", this.ParkourId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Index", this.CheckPointIndex);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		if (!StringUtils.IsEmpty(this.CheckTag))
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			Entity entity;
			if (baseCharacter == null)
			{
				entity = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
				entity = ((characterActorComponent != null) ? characterActorComponent.Entity : null);
			}
			Entity entity2 = entity;
			if (entity2 != null)
			{
				BaseTagComponent component = entity2.GetComponent<BaseTagComponent>();
				if (component != null)
				{
					int tagIdByName = GameplayTagUtils.GetTagIdByName(this.CheckTag);
					if (!component.HasTag(tagIdByName))
					{
						return;
					}
				}
			}
		}
		if (this.ParkourId != 0)
		{
			ControllerBase<ParkourController>.Instance.HandleParkourPoint(this.ParkourId, this.CheckPointIndex, this.IndexInGroup);
		}
	}

	// Token: 0x0600665C RID: 26204 RVA: 0x0019C772 File Offset: 0x0019A972
	[NullableContext(2)]
	protected void OnCollisionExit(AActor otherActor)
	{
	}

	// Token: 0x0600665D RID: 26205 RVA: 0x0019C774 File Offset: 0x0019A974
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsParkourCheckPoint._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/LevelGamePlay/Parkour/TsParkourCheckPoint.TsParkourCheckPoint_C");
		}
		return TsParkourCheckPoint._ClassPtr;
	}

	// Token: 0x0600665E RID: 26206 RVA: 0x0019C798 File Offset: 0x0019A998
	public TsParkourCheckPoint() : this(BuiltinUtils.AllocNativeUObject(TsParkourCheckPoint.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600665F RID: 26207 RVA: 0x0019C7C0 File Offset: 0x0019A9C0
	public TsParkourCheckPoint(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsParkourCheckPoint.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06006660 RID: 26208 RVA: 0x0019C7F3 File Offset: 0x0019A9F3
	protected TsParkourCheckPoint(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x170007F5 RID: 2037
	// (get) Token: 0x06006661 RID: 26209 RVA: 0x0019C7FC File Offset: 0x0019A9FC
	public unsafe FPointerToUberGraphFrame UberGraphFrame
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsParkourCheckPoint.__PropertyOffset_UberGraphFrame);
		}
	}

	// Token: 0x170007F6 RID: 2038
	// (get) Token: 0x06006662 RID: 26210 RVA: 0x0019C80C File Offset: 0x0019AA0C
	[Nullable(2)]
	public unsafe USceneComponent DefaultSceneRoot
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + TsParkourCheckPoint.__PropertyOffset_DefaultSceneRoot);
		}
	}

	// Token: 0x06006663 RID: 26211 RVA: 0x0019C820 File Offset: 0x0019AA20
	protected virtual void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		this.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x06006664 RID: 26212 RVA: 0x0019C828 File Offset: 0x0019AA28
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveEndPlay_Implementation(AActor.__ReceiveEndPlay_FunctionParams* __Params)
	{
		EEndPlayReason endPlayReason = __Params->EndPlayReason;
		this.ReceiveEndPlay_Implementation(endPlayReason);
	}

	// Token: 0x06006665 RID: 26213 RVA: 0x0019C848 File Offset: 0x0019AA48
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_SetDetectSphere_Implementation(TsParkourCheckPoint.__SetDetectSphere_FunctionParams* __Params)
	{
		this.SetDetectSphere_Implementation(__Params->inRadius);
	}

	// Token: 0x06006666 RID: 26214 RVA: 0x0019C858 File Offset: 0x0019AA58
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GenerateFx_Implementation(TsParkourCheckPoint.__GenerateFx_FunctionParams* __Params)
	{
		UEffectModelBase orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UEffectModelBase>(__Params->inModelBase);
		this.GenerateFx_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x06006667 RID: 26215 RVA: 0x0019C878 File Offset: 0x0019AA78
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GenerateFxByPath_Implementation(TsParkourCheckPoint.__GenerateFxByPath_FunctionParams* __Params)
	{
		string effectPath = FString.ToString((void*)(&__Params->effectPath));
		this.GenerateFxByPath_Implementation(effectPath);
	}

	// Token: 0x0400308E RID: 12430
	[StaticVariableRuleIgnore]
	public static readonly FName PARKOUR_CHECK_POINT_PRESET = new FName("ParkourCheckPoint");

	// Token: 0x0400308F RID: 12431
	private int EffectViewHandler;

	// Token: 0x04003090 RID: 12432
	private bool EventRegistered;

	// Token: 0x04003091 RID: 12433
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/LevelGamePlay/Parkour/TsParkourCheckPoint.TsParkourCheckPoint_C";

	// Token: 0x04003092 RID: 12434
	private static IntPtr _ClassPtr;

	// Token: 0x04003093 RID: 12435
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04003094 RID: 12436
	private static int __PropertyOffset_UberGraphFrame;

	// Token: 0x04003095 RID: 12437
	private static int __PropertyOffset_DefaultSceneRoot;

	// Token: 0x04003096 RID: 12438
	private static int __PropertyOffset_SphereComponent;

	// Token: 0x04003097 RID: 12439
	private static int __PropertyOffset_CheckPointIndex;

	// Token: 0x04003098 RID: 12440
	private static int __PropertyOffset_IndexInGroup;

	// Token: 0x04003099 RID: 12441
	private static int __PropertyOffset_ParkourId;

	// Token: 0x0400309A RID: 12442
	private static int __PropertyOffset_CheckTag;

	// Token: 0x0400309B RID: 12443
	private static int __PropertyOffset_DestroyEffectModelBasePath;

	// Token: 0x02007396 RID: 29590
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __SetDetectSphere_FunctionParams
	{
		// Token: 0x04028018 RID: 163864
		[FieldOffset(0)]
		public float inRadius;
	}

	// Token: 0x02007397 RID: 29591
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __GenerateFx_FunctionParams
	{
		// Token: 0x04028019 RID: 163865
		[FieldOffset(0)]
		public IntPtr inModelBase;
	}

	// Token: 0x02007398 RID: 29592
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GenerateFxByPath_FunctionParams
	{
		// Token: 0x0402801A RID: 163866
		[FieldOffset(0)]
		public FString effectPath;
	}
}
