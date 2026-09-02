using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.RoadSpline
{
	// Token: 0x02003B96 RID: 15254
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/BP_PCGMeshSlider.BP_PCGMeshSlider_C")]
	[UnrealStructLayout(1408, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1408)]
	public class BP_PCGMeshSlider_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021D4D RID: 138573 RVA: 0x00954F2B File Offset: 0x0095312B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PCGMeshSlider_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/BP_PCGMeshSlider.BP_PCGMeshSlider_C");
			}
			return BP_PCGMeshSlider_C._ClassPtr;
		}

		// Token: 0x06021D4E RID: 138574 RVA: 0x00954F50 File Offset: 0x00953150
		public BP_PCGMeshSlider_C() : this(BuiltinUtils.AllocNativeUObject(BP_PCGMeshSlider_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021D4F RID: 138575 RVA: 0x00954F78 File Offset: 0x00953178
		[NullableContext(1)]
		public BP_PCGMeshSlider_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PCGMeshSlider_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003D3F RID: 15679
		// (get) Token: 0x06021D50 RID: 138576 RVA: 0x00954FAC File Offset: 0x009531AC
		// (set) Token: 0x06021D51 RID: 138577 RVA: 0x00954FE5 File Offset: 0x009531E5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PCGMeshSlider_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PCGMeshSlider_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003D40 RID: 15680
		// (get) Token: 0x06021D52 RID: 138578 RVA: 0x00955006 File Offset: 0x00953206
		// (set) Token: 0x06021D53 RID: 138579 RVA: 0x0095501A File Offset: 0x0095321A
		public unsafe USplineComponent Spline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGMeshSlider_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGMeshSlider_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003D41 RID: 15681
		// (get) Token: 0x06021D54 RID: 138580 RVA: 0x0095502F File Offset: 0x0095322F
		// (set) Token: 0x06021D55 RID: 138581 RVA: 0x00955043 File Offset: 0x00953243
		public unsafe UNiagaraComponent Niagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGMeshSlider_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGMeshSlider_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003D42 RID: 15682
		// (get) Token: 0x06021D56 RID: 138582 RVA: 0x00955058 File Offset: 0x00953258
		// (set) Token: 0x06021D57 RID: 138583 RVA: 0x0095506C File Offset: 0x0095326C
		public unsafe USkeletalMeshComponent SkeletalMeshComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGMeshSlider_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGMeshSlider_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003D43 RID: 15683
		// (get) Token: 0x06021D58 RID: 138584 RVA: 0x00955081 File Offset: 0x00953281
		// (set) Token: 0x06021D59 RID: 138585 RVA: 0x00955095 File Offset: 0x00953295
		public unsafe UStaticMeshComponent StaticMeshComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGMeshSlider_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGMeshSlider_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003D44 RID: 15684
		// (get) Token: 0x06021D5A RID: 138586 RVA: 0x009550AA File Offset: 0x009532AA
		// (set) Token: 0x06021D5B RID: 138587 RVA: 0x009550BE File Offset: 0x009532BE
		public unsafe USceneComponent SliderParent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGMeshSlider_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGMeshSlider_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003D45 RID: 15685
		// (get) Token: 0x06021D5C RID: 138588 RVA: 0x009550D3 File Offset: 0x009532D3
		// (set) Token: 0x06021D5D RID: 138589 RVA: 0x009550E7 File Offset: 0x009532E7
		public unsafe AActor 样条线Actor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGMeshSlider_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGMeshSlider_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17003D46 RID: 15686
		// (get) Token: 0x06021D5E RID: 138590 RVA: 0x009550FC File Offset: 0x009532FC
		// (set) Token: 0x06021D5F RID: 138591 RVA: 0x0095510C File Offset: 0x0095330C
		public unsafe float 速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PCGMeshSlider_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PCGMeshSlider_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003D47 RID: 15687
		// (get) Token: 0x06021D60 RID: 138592 RVA: 0x0095511D File Offset: 0x0095331D
		// (set) Token: 0x06021D61 RID: 138593 RVA: 0x00955131 File Offset: 0x00953331
		public unsafe UStaticMesh 静态模型
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGMeshSlider_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGMeshSlider_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17003D48 RID: 15688
		// (get) Token: 0x06021D62 RID: 138594 RVA: 0x00955146 File Offset: 0x00953346
		// (set) Token: 0x06021D63 RID: 138595 RVA: 0x0095515A File Offset: 0x0095335A
		public unsafe USkeletalMesh 骨骼模型
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGMeshSlider_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGMeshSlider_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17003D49 RID: 15689
		// (get) Token: 0x06021D64 RID: 138596 RVA: 0x0095516F File Offset: 0x0095336F
		// (set) Token: 0x06021D65 RID: 138597 RVA: 0x0095517F File Offset: 0x0095337F
		public unsafe float Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PCGMeshSlider_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PCGMeshSlider_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003D4A RID: 15690
		// (get) Token: 0x06021D66 RID: 138598 RVA: 0x00955190 File Offset: 0x00953390
		// (set) Token: 0x06021D67 RID: 138599 RVA: 0x009551A0 File Offset: 0x009533A0
		public unsafe float Delta_Seconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PCGMeshSlider_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PCGMeshSlider_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003D4B RID: 15691
		// (get) Token: 0x06021D68 RID: 138600 RVA: 0x009551B1 File Offset: 0x009533B1
		// (set) Token: 0x06021D69 RID: 138601 RVA: 0x009551C5 File Offset: 0x009533C5
		public unsafe UNiagaraSystem 粒子特效
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGMeshSlider_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGMeshSlider_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x06021D6A RID: 138602 RVA: 0x009551DA File Offset: 0x009533DA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 复制样条线_请根据提示操作_()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PCGMeshSlider_C.__复制样条线_请根据提示操作__NativeFunctionPtr, null);
		}

		// Token: 0x06021D6B RID: 138603 RVA: 0x009551F0 File Offset: 0x009533F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void IsEditor(ref bool IsEditor)
		{
			BP_PCGMeshSlider_C.__IsEditor_FunctionParams* ptr = stackalloc BP_PCGMeshSlider_C.__IsEditor_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(BP_PCGMeshSlider_C.__IsEditor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PCGMeshSlider_C.__IsEditor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsEditor = IsEditor;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PCGMeshSlider_C.__IsEditor_NativeFunctionPtr, (void*)ptr);
			IsEditor = ptr->IsEditor;
		}

		// Token: 0x06021D6C RID: 138604 RVA: 0x0095523F File Offset: 0x0095343F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PCGMeshSlider_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021D6D RID: 138605 RVA: 0x00955253 File Offset: 0x00953453
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PCGMeshSlider_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021D6E RID: 138606 RVA: 0x00955268 File Offset: 0x00953468
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PCGMeshSlider_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021D6F RID: 138607 RVA: 0x0095527C File Offset: 0x0095347C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PCGMeshSlider_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021D70 RID: 138608 RVA: 0x00955294 File Offset: 0x00953494
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_PCGMeshSlider_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PCGMeshSlider_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PCGMeshSlider_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PCGMeshSlider_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PCGMeshSlider_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021D71 RID: 138609 RVA: 0x009552DC File Offset: 0x009534DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_PCGMeshSlider_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PCGMeshSlider_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PCGMeshSlider_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PCGMeshSlider_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PCGMeshSlider_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021D72 RID: 138610 RVA: 0x00955324 File Offset: 0x00953524
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_PCGMeshSlider_C.__EditorTick_FunctionParams* ptr = stackalloc BP_PCGMeshSlider_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PCGMeshSlider_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PCGMeshSlider_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PCGMeshSlider_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021D73 RID: 138611 RVA: 0x0095536C File Offset: 0x0095356C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_PCGMeshSlider_C.__EditorTick_FunctionParams* ptr = stackalloc BP_PCGMeshSlider_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PCGMeshSlider_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PCGMeshSlider_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PCGMeshSlider_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021D74 RID: 138612 RVA: 0x009553B4 File Offset: 0x009535B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PCGMeshSlider(int EntryPoint)
		{
			BP_PCGMeshSlider_C.__ExecuteUbergraph_BP_PCGMeshSlider_FunctionParams* ptr = stackalloc BP_PCGMeshSlider_C.__ExecuteUbergraph_BP_PCGMeshSlider_FunctionParams[(UIntPtr)271] + 15L / (long)sizeof(BP_PCGMeshSlider_C.__ExecuteUbergraph_BP_PCGMeshSlider_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PCGMeshSlider_C.__ExecuteUbergraph_BP_PCGMeshSlider_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PCGMeshSlider_C.__ExecuteUbergraph_BP_PCGMeshSlider_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021D75 RID: 138613 RVA: 0x009553FE File Offset: 0x009535FE
		protected BP_PCGMeshSlider_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011131 RID: 69937
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/BP_PCGMeshSlider.BP_PCGMeshSlider_C";

		// Token: 0x04011132 RID: 69938
		private static IntPtr _ClassPtr;

		// Token: 0x04011133 RID: 69939
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011134 RID: 69940
		internal static int __PropertyOffset_0;

		// Token: 0x04011135 RID: 69941
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011136 RID: 69942
		internal static int __PropertyOffset_1;

		// Token: 0x04011137 RID: 69943
		internal static int __PropertyOffset_2;

		// Token: 0x04011138 RID: 69944
		internal static int __PropertyOffset_3;

		// Token: 0x04011139 RID: 69945
		internal static int __PropertyOffset_4;

		// Token: 0x0401113A RID: 69946
		internal static int __PropertyOffset_5;

		// Token: 0x0401113B RID: 69947
		internal static int __PropertyOffset_6;

		// Token: 0x0401113C RID: 69948
		internal static int __PropertyOffset_7;

		// Token: 0x0401113D RID: 69949
		internal static int __PropertyOffset_8;

		// Token: 0x0401113E RID: 69950
		internal static int __PropertyOffset_9;

		// Token: 0x0401113F RID: 69951
		internal static int __PropertyOffset_10;

		// Token: 0x04011140 RID: 69952
		internal static int __PropertyOffset_11;

		// Token: 0x04011141 RID: 69953
		internal static int __PropertyOffset_12;

		// Token: 0x04011142 RID: 69954
		private static IntPtr __复制样条线_请根据提示操作__NativeFunctionPtr;

		// Token: 0x04011143 RID: 69955
		private static IntPtr __IsEditor_NativeFunctionPtr;

		// Token: 0x04011144 RID: 69956
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011145 RID: 69957
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011146 RID: 69958
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011147 RID: 69959
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04011148 RID: 69960
		private static IntPtr __ExecuteUbergraph_BP_PCGMeshSlider_NativeFunctionPtr;

		// Token: 0x02009B5F RID: 39775
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __IsEditor_FunctionParams
		{
			// Token: 0x0403234E RID: 205646
			[FieldOffset(0)]
			public bool IsEditor;
		}

		// Token: 0x02009B60 RID: 39776
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403234F RID: 205647
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B61 RID: 39777
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032350 RID: 205648
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B62 RID: 39778
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 256)]
		protected ref struct __ExecuteUbergraph_BP_PCGMeshSlider_FunctionParams
		{
			// Token: 0x04032351 RID: 205649
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
