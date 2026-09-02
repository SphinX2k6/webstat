using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroCS.DoubleChain
{
	// Token: 0x02003BFD RID: 15357
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroCS/DoubleChain/BP_DoubleChain.BP_DoubleChain_C")]
	[UnrealStructLayout(1264, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1264)]
	public class BP_DoubleChain_C : AKuroCSDoubleChain, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022C06 RID: 142342 RVA: 0x0096DF18 File Offset: 0x0096C118
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DoubleChain_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/DoubleChain/BP_DoubleChain.BP_DoubleChain_C");
			}
			return BP_DoubleChain_C._ClassPtr;
		}

		// Token: 0x06022C07 RID: 142343 RVA: 0x0096DF3C File Offset: 0x0096C13C
		public BP_DoubleChain_C() : this(BuiltinUtils.AllocNativeUObject(BP_DoubleChain_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022C08 RID: 142344 RVA: 0x0096DF64 File Offset: 0x0096C164
		[NullableContext(1)]
		public BP_DoubleChain_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DoubleChain_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700428B RID: 17035
		// (get) Token: 0x06022C09 RID: 142345 RVA: 0x0096DF98 File Offset: 0x0096C198
		// (set) Token: 0x06022C0A RID: 142346 RVA: 0x0096DFD1 File Offset: 0x0096C1D1
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_DoubleChain_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_DoubleChain_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700428C RID: 17036
		// (get) Token: 0x06022C0B RID: 142347 RVA: 0x0096DFF2 File Offset: 0x0096C1F2
		// (set) Token: 0x06022C0C RID: 142348 RVA: 0x0096E006 File Offset: 0x0096C206
		public unsafe UBoxComponent ValidBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DoubleChain_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DoubleChain_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700428D RID: 17037
		// (get) Token: 0x06022C0D RID: 142349 RVA: 0x0096E01B File Offset: 0x0096C21B
		// (set) Token: 0x06022C0E RID: 142350 RVA: 0x0096E02F File Offset: 0x0096C22F
		public unsafe UStaticMeshComponent ClothMeshXZ
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DoubleChain_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DoubleChain_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700428E RID: 17038
		// (get) Token: 0x06022C0F RID: 142351 RVA: 0x0096E044 File Offset: 0x0096C244
		// (set) Token: 0x06022C10 RID: 142352 RVA: 0x0096E058 File Offset: 0x0096C258
		public unsafe UTextureRenderTarget2D RT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DoubleChain_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DoubleChain_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700428F RID: 17039
		// (get) Token: 0x06022C11 RID: 142353 RVA: 0x0096E06D File Offset: 0x0096C26D
		// (set) Token: 0x06022C12 RID: 142354 RVA: 0x0096E07D File Offset: 0x0096C27D
		public unsafe bool bStopSim
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DoubleChain_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DoubleChain_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004290 RID: 17040
		// (get) Token: 0x06022C13 RID: 142355 RVA: 0x0096E08E File Offset: 0x0096C28E
		// (set) Token: 0x06022C14 RID: 142356 RVA: 0x0096E09E File Offset: 0x0096C29E
		public unsafe bool bEditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DoubleChain_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DoubleChain_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004291 RID: 17041
		// (get) Token: 0x06022C15 RID: 142357 RVA: 0x0096E0AF File Offset: 0x0096C2AF
		// (set) Token: 0x06022C16 RID: 142358 RVA: 0x0096E0C3 File Offset: 0x0096C2C3
		public unsafe FVector PosOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DoubleChain_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DoubleChain_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004292 RID: 17042
		// (get) Token: 0x06022C17 RID: 142359 RVA: 0x0096E0D8 File Offset: 0x0096C2D8
		// (set) Token: 0x06022C18 RID: 142360 RVA: 0x0096E0E8 File Offset: 0x0096C2E8
		public unsafe float FadeOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DoubleChain_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DoubleChain_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17004293 RID: 17043
		// (get) Token: 0x06022C19 RID: 142361 RVA: 0x0096E0F9 File Offset: 0x0096C2F9
		// (set) Token: 0x06022C1A RID: 142362 RVA: 0x0096E109 File Offset: 0x0096C309
		public unsafe bool bFadeOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DoubleChain_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DoubleChain_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004294 RID: 17044
		// (get) Token: 0x06022C1B RID: 142363 RVA: 0x0096E11C File Offset: 0x0096C31C
		// (set) Token: 0x06022C1C RID: 142364 RVA: 0x0096E155 File Offset: 0x0096C355
		[Nullable(1)]
		public TArray<UMaterialInstanceDynamic> Mats
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._Mats) == null)
				{
					result = (this._Mats = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_DoubleChain_C.__PropertyOffset_9, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Mats.CopyAssign(value);
			}
		}

		// Token: 0x17004295 RID: 17045
		// (get) Token: 0x06022C1D RID: 142365 RVA: 0x0096E163 File Offset: 0x0096C363
		// (set) Token: 0x06022C1E RID: 142366 RVA: 0x0096E173 File Offset: 0x0096C373
		public unsafe bool bInit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DoubleChain_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DoubleChain_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004296 RID: 17046
		// (get) Token: 0x06022C1F RID: 142367 RVA: 0x0096E184 File Offset: 0x0096C384
		// (set) Token: 0x06022C20 RID: 142368 RVA: 0x0096E194 File Offset: 0x0096C394
		public unsafe bool bDrawDebug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DoubleChain_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DoubleChain_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004297 RID: 17047
		// (get) Token: 0x06022C21 RID: 142369 RVA: 0x0096E1A5 File Offset: 0x0096C3A5
		// (set) Token: 0x06022C22 RID: 142370 RVA: 0x0096E1B5 File Offset: 0x0096C3B5
		public unsafe bool InitOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DoubleChain_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DoubleChain_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004298 RID: 17048
		// (get) Token: 0x06022C23 RID: 142371 RVA: 0x0096E1C6 File Offset: 0x0096C3C6
		// (set) Token: 0x06022C24 RID: 142372 RVA: 0x0096E1D6 File Offset: 0x0096C3D6
		public unsafe bool bEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DoubleChain_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DoubleChain_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004299 RID: 17049
		// (get) Token: 0x06022C25 RID: 142373 RVA: 0x0096E1E7 File Offset: 0x0096C3E7
		// (set) Token: 0x06022C26 RID: 142374 RVA: 0x0096E1FB File Offset: 0x0096C3FB
		public unsafe UChildActorComponent editorTicker
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DoubleChain_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DoubleChain_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x06022C27 RID: 142375 RVA: 0x0096E210 File Offset: 0x0096C410
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitRT()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DoubleChain_C.__InitRT_NativeFunctionPtr, null);
		}

		// Token: 0x06022C28 RID: 142376 RVA: 0x0096E224 File Offset: 0x0096C424
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AutoXCenter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DoubleChain_C.__AutoXCenter_NativeFunctionPtr, null);
		}

		// Token: 0x06022C29 RID: 142377 RVA: 0x0096E238 File Offset: 0x0096C438
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StopSim()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DoubleChain_C.__StopSim_NativeFunctionPtr, null);
		}

		// Token: 0x06022C2A RID: 142378 RVA: 0x0096E24C File Offset: 0x0096C44C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartSim()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DoubleChain_C.__StartSim_NativeFunctionPtr, null);
		}

		// Token: 0x06022C2B RID: 142379 RVA: 0x0096E260 File Offset: 0x0096C460
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitMats()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DoubleChain_C.__InitMats_NativeFunctionPtr, null);
		}

		// Token: 0x06022C2C RID: 142380 RVA: 0x0096E274 File Offset: 0x0096C474
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DoubleChain_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022C2D RID: 142381 RVA: 0x0096E288 File Offset: 0x0096C488
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DoubleChain_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022C2E RID: 142382 RVA: 0x0096E29D File Offset: 0x0096C49D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DoubleChain_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022C2F RID: 142383 RVA: 0x0096E2B1 File Offset: 0x0096C4B1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DoubleChain_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022C30 RID: 142384 RVA: 0x0096E2C8 File Offset: 0x0096C4C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_DoubleChain_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_DoubleChain_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DoubleChain_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DoubleChain_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DoubleChain_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022C31 RID: 142385 RVA: 0x0096E310 File Offset: 0x0096C510
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_DoubleChain_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_DoubleChain_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DoubleChain_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DoubleChain_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DoubleChain_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022C32 RID: 142386 RVA: 0x0096E358 File Offset: 0x0096C558
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveActorBeginOverlap(AActor OtherActor)
		{
			BP_DoubleChain_C.__ReceiveActorBeginOverlap_FunctionParams* ptr = stackalloc BP_DoubleChain_C.__ReceiveActorBeginOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_DoubleChain_C.__ReceiveActorBeginOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DoubleChain_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DoubleChain_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022C33 RID: 142387 RVA: 0x0096E3B0 File Offset: 0x0096C5B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveActorBeginOverlap_Implementation(AActor OtherActor)
		{
			BP_DoubleChain_C.__ReceiveActorBeginOverlap_FunctionParams* ptr = stackalloc BP_DoubleChain_C.__ReceiveActorBeginOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_DoubleChain_C.__ReceiveActorBeginOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DoubleChain_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DoubleChain_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022C34 RID: 142388 RVA: 0x0096E408 File Offset: 0x0096C608
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveActorEndOverlap(AActor OtherActor)
		{
			BP_DoubleChain_C.__ReceiveActorEndOverlap_FunctionParams* ptr = stackalloc BP_DoubleChain_C.__ReceiveActorEndOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_DoubleChain_C.__ReceiveActorEndOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DoubleChain_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DoubleChain_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022C35 RID: 142389 RVA: 0x0096E460 File Offset: 0x0096C660
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveActorEndOverlap_Implementation(AActor OtherActor)
		{
			BP_DoubleChain_C.__ReceiveActorEndOverlap_FunctionParams* ptr = stackalloc BP_DoubleChain_C.__ReceiveActorEndOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_DoubleChain_C.__ReceiveActorEndOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DoubleChain_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DoubleChain_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022C36 RID: 142390 RVA: 0x0096E4B6 File Offset: 0x0096C6B6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DoubleChain_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x06022C37 RID: 142391 RVA: 0x0096E4CC File Offset: 0x0096C6CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_DoubleChain(int EntryPoint)
		{
			BP_DoubleChain_C.__ExecuteUbergraph_BP_DoubleChain_FunctionParams* ptr = stackalloc BP_DoubleChain_C.__ExecuteUbergraph_BP_DoubleChain_FunctionParams[(UIntPtr)991] + 15L / (long)sizeof(BP_DoubleChain_C.__ExecuteUbergraph_BP_DoubleChain_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DoubleChain_C.__ExecuteUbergraph_BP_DoubleChain_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DoubleChain_C.__ExecuteUbergraph_BP_DoubleChain_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022C38 RID: 142392 RVA: 0x0096E516 File Offset: 0x0096C716
		protected BP_DoubleChain_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040119FC RID: 72188
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/DoubleChain/BP_DoubleChain.BP_DoubleChain_C";

		// Token: 0x040119FD RID: 72189
		private static IntPtr _ClassPtr;

		// Token: 0x040119FE RID: 72190
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040119FF RID: 72191
		internal static int __PropertyOffset_0;

		// Token: 0x04011A00 RID: 72192
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011A01 RID: 72193
		internal static int __PropertyOffset_1;

		// Token: 0x04011A02 RID: 72194
		internal static int __PropertyOffset_2;

		// Token: 0x04011A03 RID: 72195
		internal static int __PropertyOffset_3;

		// Token: 0x04011A04 RID: 72196
		internal static int __PropertyOffset_4;

		// Token: 0x04011A05 RID: 72197
		internal static int __PropertyOffset_5;

		// Token: 0x04011A06 RID: 72198
		internal static int __PropertyOffset_6;

		// Token: 0x04011A07 RID: 72199
		internal static int __PropertyOffset_7;

		// Token: 0x04011A08 RID: 72200
		internal static int __PropertyOffset_8;

		// Token: 0x04011A09 RID: 72201
		internal static int __PropertyOffset_9;

		// Token: 0x04011A0A RID: 72202
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _Mats;

		// Token: 0x04011A0B RID: 72203
		internal static int __PropertyOffset_10;

		// Token: 0x04011A0C RID: 72204
		internal static int __PropertyOffset_11;

		// Token: 0x04011A0D RID: 72205
		internal static int __PropertyOffset_12;

		// Token: 0x04011A0E RID: 72206
		internal static int __PropertyOffset_13;

		// Token: 0x04011A0F RID: 72207
		internal static int __PropertyOffset_14;

		// Token: 0x04011A10 RID: 72208
		private static IntPtr __InitRT_NativeFunctionPtr;

		// Token: 0x04011A11 RID: 72209
		private static IntPtr __AutoXCenter_NativeFunctionPtr;

		// Token: 0x04011A12 RID: 72210
		private static IntPtr __StopSim_NativeFunctionPtr;

		// Token: 0x04011A13 RID: 72211
		private static IntPtr __StartSim_NativeFunctionPtr;

		// Token: 0x04011A14 RID: 72212
		private static IntPtr __InitMats_NativeFunctionPtr;

		// Token: 0x04011A15 RID: 72213
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011A16 RID: 72214
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011A17 RID: 72215
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011A18 RID: 72216
		private static IntPtr __ReceiveActorBeginOverlap_NativeFunctionPtr;

		// Token: 0x04011A19 RID: 72217
		private static IntPtr __ReceiveActorEndOverlap_NativeFunctionPtr;

		// Token: 0x04011A1A RID: 72218
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04011A1B RID: 72219
		private static IntPtr __ExecuteUbergraph_BP_DoubleChain_NativeFunctionPtr;

		// Token: 0x02009C21 RID: 39969
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032494 RID: 205972
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C22 RID: 39970
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ReceiveActorBeginOverlap_FunctionParams
		{
			// Token: 0x04032495 RID: 205973
			[FieldOffset(0)]
			public IntPtr OtherActor;
		}

		// Token: 0x02009C23 RID: 39971
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ReceiveActorEndOverlap_FunctionParams
		{
			// Token: 0x04032496 RID: 205974
			[FieldOffset(0)]
			public IntPtr OtherActor;
		}

		// Token: 0x02009C24 RID: 39972
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 976)]
		protected ref struct __ExecuteUbergraph_BP_DoubleChain_FunctionParams
		{
			// Token: 0x04032497 RID: 205975
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
