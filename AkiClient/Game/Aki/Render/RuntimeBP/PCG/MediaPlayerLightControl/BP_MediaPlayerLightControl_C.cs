using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interface;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MediaPlayerLightControl
{
	// Token: 0x02003BC2 RID: 15298
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MediaPlayerLightControl/BP_MediaPlayerLightControl.BP_MediaPlayerLightControl_C")]
	[UnrealStructLayout(1376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1372)]
	public class BP_MediaPlayerLightControl_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject, IBPI_SceneBp_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x0602252E RID: 140590 RVA: 0x0096213C File Offset: 0x0096033C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MediaPlayerLightControl_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MediaPlayerLightControl/BP_MediaPlayerLightControl.BP_MediaPlayerLightControl_C");
			}
			return BP_MediaPlayerLightControl_C._ClassPtr;
		}

		// Token: 0x0602252F RID: 140591 RVA: 0x00962160 File Offset: 0x00960360
		public BP_MediaPlayerLightControl_C() : this(BuiltinUtils.AllocNativeUObject(BP_MediaPlayerLightControl_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022530 RID: 140592 RVA: 0x00962188 File Offset: 0x00960388
		[NullableContext(1)]
		public BP_MediaPlayerLightControl_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MediaPlayerLightControl_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004048 RID: 16456
		// (get) Token: 0x06022531 RID: 140593 RVA: 0x009621BC File Offset: 0x009603BC
		// (set) Token: 0x06022532 RID: 140594 RVA: 0x009621F5 File Offset: 0x009603F5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_MediaPlayerLightControl_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_MediaPlayerLightControl_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004049 RID: 16457
		// (get) Token: 0x06022533 RID: 140595 RVA: 0x00962216 File Offset: 0x00960416
		// (set) Token: 0x06022534 RID: 140596 RVA: 0x0096222A File Offset: 0x0096042A
		public unsafe UTextRenderComponent Play
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextRenderComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaPlayerLightControl_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaPlayerLightControl_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700404A RID: 16458
		// (get) Token: 0x06022535 RID: 140597 RVA: 0x0096223F File Offset: 0x0096043F
		// (set) Token: 0x06022536 RID: 140598 RVA: 0x00962253 File Offset: 0x00960453
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaPlayerLightControl_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaPlayerLightControl_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700404B RID: 16459
		// (get) Token: 0x06022537 RID: 140599 RVA: 0x00962268 File Offset: 0x00960468
		// (set) Token: 0x06022538 RID: 140600 RVA: 0x0096227C File Offset: 0x0096047C
		public unsafe ULevelSequence Sequence
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ULevelSequence>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaPlayerLightControl_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaPlayerLightControl_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700404C RID: 16460
		// (get) Token: 0x06022539 RID: 140601 RVA: 0x00962291 File Offset: 0x00960491
		// (set) Token: 0x0602253A RID: 140602 RVA: 0x009622A1 File Offset: 0x009604A1
		public unsafe bool SequenceDebugCanvas
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaPlayerLightControl_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaPlayerLightControl_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700404D RID: 16461
		// (get) Token: 0x0602253B RID: 140603 RVA: 0x009622B2 File Offset: 0x009604B2
		// (set) Token: 0x0602253C RID: 140604 RVA: 0x009622C6 File Offset: 0x009604C6
		public unsafe UMaterialInstance MaterialInstance
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaPlayerLightControl_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaPlayerLightControl_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700404E RID: 16462
		// (get) Token: 0x0602253D RID: 140605 RVA: 0x009622DB File Offset: 0x009604DB
		// (set) Token: 0x0602253E RID: 140606 RVA: 0x009622EF File Offset: 0x009604EF
		public unsafe FVector World_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaPlayerLightControl_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaPlayerLightControl_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x0602253F RID: 140607 RVA: 0x00962304 File Offset: 0x00960504
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ShouldStopOnHide(ref bool ret)
		{
			BP_MediaPlayerLightControl_C.__ShouldStopOnHide_FunctionParams* ptr = stackalloc BP_MediaPlayerLightControl_C.__ShouldStopOnHide_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_MediaPlayerLightControl_C.__ShouldStopOnHide_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MediaPlayerLightControl_C.__ShouldStopOnHide_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ret = ret;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaPlayerLightControl_C.__ShouldStopOnHide_NativeFunctionPtr, (void*)ptr);
			ret = ptr->ret;
		}

		// Token: 0x06022540 RID: 140608 RVA: 0x00962354 File Offset: 0x00960554
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetAoiRange(ref int ret)
		{
			BP_MediaPlayerLightControl_C.__GetAoiRange_FunctionParams* ptr = stackalloc BP_MediaPlayerLightControl_C.__GetAoiRange_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MediaPlayerLightControl_C.__GetAoiRange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MediaPlayerLightControl_C.__GetAoiRange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ret = ret;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaPlayerLightControl_C.__GetAoiRange_NativeFunctionPtr, (void*)ptr);
			ret = ptr->ret;
		}

		// Token: 0x06022541 RID: 140609 RVA: 0x009623A3 File Offset: 0x009605A3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TickOutside()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaPlayerLightControl_C.__TickOutside_NativeFunctionPtr, null);
		}

		// Token: 0x06022542 RID: 140610 RVA: 0x009623B7 File Offset: 0x009605B7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Start()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaPlayerLightControl_C.__Start_NativeFunctionPtr, null);
		}

		// Token: 0x06022543 RID: 140611 RVA: 0x009623CB File Offset: 0x009605CB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Stop()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaPlayerLightControl_C.__Stop_NativeFunctionPtr, null);
		}

		// Token: 0x06022544 RID: 140612 RVA: 0x009623DF File Offset: 0x009605DF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Pause()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaPlayerLightControl_C.__Pause_NativeFunctionPtr, null);
		}

		// Token: 0x06022545 RID: 140613 RVA: 0x009623F3 File Offset: 0x009605F3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Resume()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaPlayerLightControl_C.__Resume_NativeFunctionPtr, null);
		}

		// Token: 0x06022546 RID: 140614 RVA: 0x00962407 File Offset: 0x00960607
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaPlayerLightControl_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022547 RID: 140615 RVA: 0x0096241B File Offset: 0x0096061B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MediaPlayerLightControl_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022548 RID: 140616 RVA: 0x00962430 File Offset: 0x00960630
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_MediaPlayerLightControl_C.__EditorTick_FunctionParams* ptr = stackalloc BP_MediaPlayerLightControl_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MediaPlayerLightControl_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MediaPlayerLightControl_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaPlayerLightControl_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022549 RID: 140617 RVA: 0x00962478 File Offset: 0x00960678
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_MediaPlayerLightControl_C.__EditorTick_FunctionParams* ptr = stackalloc BP_MediaPlayerLightControl_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MediaPlayerLightControl_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MediaPlayerLightControl_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MediaPlayerLightControl_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602254A RID: 140618 RVA: 0x009624C0 File Offset: 0x009606C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_MediaPlayerLightControl_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_MediaPlayerLightControl_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_MediaPlayerLightControl_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MediaPlayerLightControl_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaPlayerLightControl_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602254B RID: 140619 RVA: 0x0096250C File Offset: 0x0096070C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_MediaPlayerLightControl_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_MediaPlayerLightControl_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_MediaPlayerLightControl_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MediaPlayerLightControl_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MediaPlayerLightControl_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602254C RID: 140620 RVA: 0x00962558 File Offset: 0x00960758
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_MediaPlayerLightControl(int EntryPoint)
		{
			BP_MediaPlayerLightControl_C.__ExecuteUbergraph_BP_MediaPlayerLightControl_FunctionParams* ptr = stackalloc BP_MediaPlayerLightControl_C.__ExecuteUbergraph_BP_MediaPlayerLightControl_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(BP_MediaPlayerLightControl_C.__ExecuteUbergraph_BP_MediaPlayerLightControl_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MediaPlayerLightControl_C.__ExecuteUbergraph_BP_MediaPlayerLightControl_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MediaPlayerLightControl_C.__ExecuteUbergraph_BP_MediaPlayerLightControl_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602254D RID: 140621 RVA: 0x0096259F File Offset: 0x0096079F
		protected BP_MediaPlayerLightControl_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040115CF RID: 71119
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MediaPlayerLightControl/BP_MediaPlayerLightControl.BP_MediaPlayerLightControl_C";

		// Token: 0x040115D0 RID: 71120
		private static IntPtr _ClassPtr;

		// Token: 0x040115D1 RID: 71121
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040115D2 RID: 71122
		internal static int __PropertyOffset_0;

		// Token: 0x040115D3 RID: 71123
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040115D4 RID: 71124
		internal static int __PropertyOffset_1;

		// Token: 0x040115D5 RID: 71125
		internal static int __PropertyOffset_2;

		// Token: 0x040115D6 RID: 71126
		internal static int __PropertyOffset_3;

		// Token: 0x040115D7 RID: 71127
		internal static int __PropertyOffset_4;

		// Token: 0x040115D8 RID: 71128
		internal static int __PropertyOffset_5;

		// Token: 0x040115D9 RID: 71129
		internal static int __PropertyOffset_6;

		// Token: 0x040115DA RID: 71130
		private static IntPtr __ShouldStopOnHide_NativeFunctionPtr;

		// Token: 0x040115DB RID: 71131
		private static IntPtr __GetAoiRange_NativeFunctionPtr;

		// Token: 0x040115DC RID: 71132
		private static IntPtr __TickOutside_NativeFunctionPtr;

		// Token: 0x040115DD RID: 71133
		private static IntPtr __Start_NativeFunctionPtr;

		// Token: 0x040115DE RID: 71134
		private static IntPtr __Stop_NativeFunctionPtr;

		// Token: 0x040115DF RID: 71135
		private static IntPtr __Pause_NativeFunctionPtr;

		// Token: 0x040115E0 RID: 71136
		private static IntPtr __Resume_NativeFunctionPtr;

		// Token: 0x040115E1 RID: 71137
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040115E2 RID: 71138
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x040115E3 RID: 71139
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x040115E4 RID: 71140
		private static IntPtr __ExecuteUbergraph_BP_MediaPlayerLightControl_NativeFunctionPtr;

		// Token: 0x02009BC3 RID: 39875
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __ShouldStopOnHide_FunctionParams
		{
			// Token: 0x040323F7 RID: 205815
			[FieldOffset(0)]
			public bool ret;
		}

		// Token: 0x02009BC4 RID: 39876
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetAoiRange_FunctionParams
		{
			// Token: 0x040323F8 RID: 205816
			[FieldOffset(0)]
			public int ret;
		}

		// Token: 0x02009BC5 RID: 39877
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040323F9 RID: 205817
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BC6 RID: 39878
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x040323FA RID: 205818
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009BC7 RID: 39879
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __ExecuteUbergraph_BP_MediaPlayerLightControl_FunctionParams
		{
			// Token: 0x040323FB RID: 205819
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
