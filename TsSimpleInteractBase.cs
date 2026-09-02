using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.World;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003250 RID: 12880
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/SceneItem/SimpleBlueprintItem/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/SceneItem/SimpleBlueprintItem/TsSimpleInteractBase.TsSimpleInteractBase_C")]
public class TsSimpleInteractBase : AKuroEffectActor, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700246E RID: 9326
	// (get) Token: 0x0601AD6B RID: 109931 RVA: 0x00800E3B File Offset: 0x007FF03B
	// (set) Token: 0x0601AD6C RID: 109932 RVA: 0x00800E4B File Offset: 0x007FF04B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int TypeId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsSimpleInteractBase.__PropertyOffset_TypeId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsSimpleInteractBase.__PropertyOffset_TypeId) = value;
		}
	}

	// Token: 0x1700246F RID: 9327
	// (get) Token: 0x0601AD6D RID: 109933 RVA: 0x00800E5C File Offset: 0x007FF05C
	// (set) Token: 0x0601AD6E RID: 109934 RVA: 0x00800E70 File Offset: 0x007FF070
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UTextRenderComponent Text
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UTextRenderComponent>(base.NativePtr / (IntPtr)sizeof(void*) + TsSimpleInteractBase.__PropertyOffset_Text);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsSimpleInteractBase.__PropertyOffset_Text, value);
		}
	}

	// Token: 0x0601AD6F RID: 109935 RVA: 0x00800E88 File Offset: 0x007FF088
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

	// Token: 0x0601AD70 RID: 109936 RVA: 0x00800EF8 File Offset: 0x007FF0F8
	protected virtual void ReceiveBeginPlay_Implementation()
	{
		this.OnBeginPlay();
	}

	// Token: 0x0601AD71 RID: 109937 RVA: 0x00800F00 File Offset: 0x007FF100
	protected virtual void OnBeginPlay()
	{
		ModelBase<WorldModel>.Instance.AddTsSimpleInteractItem(this);
		this.SelfTransform = Transform.Create();
		this.SelfLocation = Vector.Create();
		this.TmpResult = default(SSimpleInteractResult);
		this.ActorLocation = Vector.Create();
		this.SelfToActor = Vector.Create();
		this.MoveOffset = Vector.Create();
		this.TmpVector1 = Vector.Create();
		this.TmpVector2 = Vector.Create();
		this.TmpVector3 = Vector.Create();
		this.TmpVector4 = Vector.Create();
		this.Text.SetHiddenInGame(true, false);
		this.Text.SetComponentTickEnabled(false);
		this.InitTraceInfo();
		this.UpdateData();
	}

	// Token: 0x0601AD72 RID: 109938 RVA: 0x00800FAC File Offset: 0x007FF1AC
	protected virtual void UpdateData()
	{
		Transform selfTransform = this.SelfTransform;
		FTransformDouble ftransformDouble = base.D_GetTransform();
		selfTransform.FromUeTransform(ftransformDouble);
		this.SelfLocation.DeepCopy(this.SelfTransform.GetLocation());
	}

	// Token: 0x0601AD73 RID: 109939 RVA: 0x00800FE3 File Offset: 0x007FF1E3
	protected void InitTraceInfo()
	{
		this.LineTrace = new UTraceLineElement();
		this.LineTrace.bIsSingle = true;
		this.LineTrace.bIgnoreSelf = true;
		this.LineTrace.SetTraceTypeQuery(KuroTraceTypeQuery.Visible);
	}

	// Token: 0x0601AD74 RID: 109940 RVA: 0x00801018 File Offset: 0x007FF218
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveEndPlay"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AActor.__ReceiveEndPlay_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AActor.__ReceiveEndPlay_FunctionParams*)ptr + 15L / (long)sizeof(AActor.__ReceiveEndPlay_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(byte*)(&ptr2->EndPlayReason) = (byte)EndPlayReason;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601AD75 RID: 109941 RVA: 0x00801091 File Offset: 0x007FF291
	protected virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
	{
		ModelBase<WorldModel>.Instance.RemoveTsSimpleInteractItem(this);
	}

	// Token: 0x0601AD76 RID: 109942 RVA: 0x008010A0 File Offset: 0x007FF2A0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void EditorInit()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("EditorInit"), out num);
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

	// Token: 0x0601AD77 RID: 109943 RVA: 0x00801110 File Offset: 0x007FF310
	protected virtual void EditorInit_Implementation()
	{
		base.bEditorTickBySelected = false;
	}

	// Token: 0x0601AD78 RID: 109944 RVA: 0x0080111C File Offset: 0x007FF31C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void EditorTick(float deltaSeconds)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("EditorTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AKuroEffectActor.__EditorTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AKuroEffectActor.__EditorTick_FunctionParams*)ptr + 15L / (long)sizeof(AKuroEffectActor.__EditorTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->DeltaSeconds = deltaSeconds;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601AD79 RID: 109945 RVA: 0x00801192 File Offset: 0x007FF392
	protected virtual void EditorTick_Implementation(float deltaSeconds)
	{
		if (this.CheckDraw(deltaSeconds))
		{
			this.OnDraw();
		}
	}

	// Token: 0x0601AD7A RID: 109946 RVA: 0x008011A4 File Offset: 0x007FF3A4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual SSimpleInteractResult GetBestTransform(AActor actor, FVector moveOffset, float halfHeight, float radius)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetBestTransform"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsSimpleInteractBase.__GetBestTransform_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsSimpleInteractBase.__GetBestTransform_FunctionParams*)ptr + 15L / (long)sizeof(TsSimpleInteractBase.__GetBestTransform_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->actor) = ((actor != null) ? actor.NativePtr : ((IntPtr)0));
			ptr2->moveOffset = moveOffset;
			ptr2->halfHeight = halfHeight;
			ptr2->radius = radius;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		SSimpleInteractResult _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601AD7B RID: 109947 RVA: 0x00801244 File Offset: 0x007FF444
	[NullableContext(1)]
	protected SSimpleInteractResult GetBestTransform_Implementation(AActor actor, FVector moveOffset, float halfHeight, float radius)
	{
		return this.OnGetBestTransform(actor, moveOffset, halfHeight, radius);
	}

	// Token: 0x0601AD7C RID: 109948 RVA: 0x00801251 File Offset: 0x007FF451
	[NullableContext(1)]
	protected virtual SSimpleInteractResult OnGetBestTransform(AActor actor, FVector moveOffset, float halfHeight, float radius)
	{
		this.TmpResult.Success = false;
		return this.TmpResult;
	}

	// Token: 0x0601AD7D RID: 109949 RVA: 0x00801268 File Offset: 0x007FF468
	private bool CheckDraw(float deltaSeconds)
	{
		if (this.CheckDrawTime == 0f)
		{
			this.CheckDrawTime = 0f;
		}
		this.CheckDrawTime -= deltaSeconds;
		if (this.CheckDrawTime < 0f)
		{
			this.CheckDrawTime = 0.45f;
			FVector fvector = new FVector();
			FRotator frotator = new FRotator();
			UKuroRenderingRuntimeBPPluginBPLibrary.GetLevelEditorCameraLocationAndForward(this, ref fvector, ref frotator);
			FVectorDouble fvectorDouble = base.D_K2_GetActorLocation();
			FVector text = fvector;
			text.X -= (float)fvectorDouble.X;
			text.Y -= (float)fvectorDouble.Y;
			text.Z -= (float)fvectorDouble.Z;
			this.LastCheckDrawResult = (text.SizeSquared() < 25000000f);
			this.IsLegal = this.CheckLegal();
			this.SetText(text);
			return this.LastCheckDrawResult;
		}
		return this.LastCheckDrawResult;
	}

	// Token: 0x0601AD7E RID: 109950 RVA: 0x00801341 File Offset: 0x007FF541
	protected virtual bool CheckLegal()
	{
		return false;
	}

	// Token: 0x0601AD7F RID: 109951 RVA: 0x00801344 File Offset: 0x007FF544
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void Draw()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("Draw"), out num);
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

	// Token: 0x0601AD80 RID: 109952 RVA: 0x008013B4 File Offset: 0x007FF5B4
	protected void Draw_Implementation()
	{
		this.OnDraw();
	}

	// Token: 0x0601AD81 RID: 109953 RVA: 0x008013BC File Offset: 0x007FF5BC
	protected virtual void OnDraw()
	{
	}

	// Token: 0x0601AD82 RID: 109954 RVA: 0x008013BE File Offset: 0x007FF5BE
	protected virtual void SetText(FVector offset)
	{
	}

	// Token: 0x0601AD83 RID: 109955 RVA: 0x008013C0 File Offset: 0x007FF5C0
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsSimpleInteractBase._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/SceneItem/SimpleBlueprintItem/TsSimpleInteractBase.TsSimpleInteractBase_C");
		}
		return TsSimpleInteractBase._ClassPtr;
	}

	// Token: 0x0601AD84 RID: 109956 RVA: 0x008013E4 File Offset: 0x007FF5E4
	public TsSimpleInteractBase() : this(BuiltinUtils.AllocNativeUObject(TsSimpleInteractBase.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601AD85 RID: 109957 RVA: 0x0080140C File Offset: 0x007FF60C
	[NullableContext(1)]
	public TsSimpleInteractBase(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSimpleInteractBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601AD86 RID: 109958 RVA: 0x0080143F File Offset: 0x007FF63F
	protected TsSimpleInteractBase(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601AD87 RID: 109959 RVA: 0x00801448 File Offset: 0x007FF648
	protected virtual void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		this.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601AD88 RID: 109960 RVA: 0x00801450 File Offset: 0x007FF650
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveEndPlay_Implementation(AActor.__ReceiveEndPlay_FunctionParams* __Params)
	{
		EEndPlayReason endPlayReason = __Params->EndPlayReason;
		this.ReceiveEndPlay_Implementation(endPlayReason);
	}

	// Token: 0x0601AD89 RID: 109961 RVA: 0x00801470 File Offset: 0x007FF670
	protected virtual void __CPPCALL_EditorInit_Implementation()
	{
		this.EditorInit_Implementation();
	}

	// Token: 0x0601AD8A RID: 109962 RVA: 0x00801478 File Offset: 0x007FF678
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_EditorTick_Implementation(AKuroEffectActor.__EditorTick_FunctionParams* __Params)
	{
		this.EditorTick_Implementation(__Params->DeltaSeconds);
	}

	// Token: 0x0601AD8B RID: 109963 RVA: 0x00801488 File Offset: 0x007FF688
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetBestTransform_Implementation(TsSimpleInteractBase.__GetBestTransform_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->actor);
		__Params->__Result = this.GetBestTransform_Implementation(orCreateUObjectByNativePointer, __Params->moveOffset, __Params->halfHeight, __Params->radius);
	}

	// Token: 0x0601AD8C RID: 109964 RVA: 0x008014C0 File Offset: 0x007FF6C0
	protected virtual void __CPPCALL_Draw_Implementation()
	{
		this.Draw_Implementation();
	}

	// Token: 0x0400D994 RID: 55700
	private const float CHECK_DRAW_PERIODIC = 0.45f;

	// Token: 0x0400D995 RID: 55701
	private const float CHECK_DRAW_THREADHOLD = 25000000f;

	// Token: 0x0400D996 RID: 55702
	private float CheckDrawTime;

	// Token: 0x0400D997 RID: 55703
	private bool LastCheckDrawResult;

	// Token: 0x0400D998 RID: 55704
	protected bool IsLegal;

	// Token: 0x0400D999 RID: 55705
	protected Transform SelfTransform;

	// Token: 0x0400D99A RID: 55706
	protected Vector SelfLocation;

	// Token: 0x0400D99B RID: 55707
	protected SSimpleInteractResult TmpResult;

	// Token: 0x0400D99C RID: 55708
	protected Vector ActorLocation;

	// Token: 0x0400D99D RID: 55709
	protected Vector SelfToActor;

	// Token: 0x0400D99E RID: 55710
	protected Vector MoveOffset;

	// Token: 0x0400D99F RID: 55711
	protected Vector TmpVector1;

	// Token: 0x0400D9A0 RID: 55712
	protected Vector TmpVector2;

	// Token: 0x0400D9A1 RID: 55713
	protected Vector TmpVector3;

	// Token: 0x0400D9A2 RID: 55714
	protected Vector TmpVector4;

	// Token: 0x0400D9A3 RID: 55715
	protected UTraceLineElement LineTrace;

	// Token: 0x0400D9A4 RID: 55716
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/SceneItem/SimpleBlueprintItem/TsSimpleInteractBase.TsSimpleInteractBase_C";

	// Token: 0x0400D9A5 RID: 55717
	private static IntPtr _ClassPtr;

	// Token: 0x0400D9A6 RID: 55718
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400D9A7 RID: 55719
	private static int __PropertyOffset_TypeId;

	// Token: 0x0400D9A8 RID: 55720
	private static int __PropertyOffset_Text;

	// Token: 0x0200942A RID: 37930
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 64)]
	protected ref struct __GetBestTransform_FunctionParams
	{
		// Token: 0x0403134F RID: 201551
		[FieldOffset(0)]
		public IntPtr actor;

		// Token: 0x04031350 RID: 201552
		[FieldOffset(8)]
		public FVector moveOffset;

		// Token: 0x04031351 RID: 201553
		[FieldOffset(20)]
		public float halfHeight;

		// Token: 0x04031352 RID: 201554
		[FieldOffset(24)]
		public float radius;

		// Token: 0x04031353 RID: 201555
		[FieldOffset(28)]
		public SSimpleInteractResult __Result;
	}
}
