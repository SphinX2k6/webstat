using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SceneObjFloat
{
	// Token: 0x02003B87 RID: 15239
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SceneObjFloat/BP_SceneObjFloat.BP_SceneObjFloat_C")]
	[UnrealStructLayout(1384, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1384)]
	public class BP_SceneObjFloat_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021B6A RID: 138090 RVA: 0x00950C90 File Offset: 0x0094EE90
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SceneObjFloat_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SceneObjFloat/BP_SceneObjFloat.BP_SceneObjFloat_C");
			}
			return BP_SceneObjFloat_C._ClassPtr;
		}

		// Token: 0x06021B6B RID: 138091 RVA: 0x00950CB4 File Offset: 0x0094EEB4
		public BP_SceneObjFloat_C() : this(BuiltinUtils.AllocNativeUObject(BP_SceneObjFloat_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021B6C RID: 138092 RVA: 0x00950CDC File Offset: 0x0094EEDC
		[NullableContext(1)]
		public BP_SceneObjFloat_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SceneObjFloat_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003CA7 RID: 15527
		// (get) Token: 0x06021B6D RID: 138093 RVA: 0x00950D10 File Offset: 0x0094EF10
		// (set) Token: 0x06021B6E RID: 138094 RVA: 0x00950D49 File Offset: 0x0094EF49
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SceneObjFloat_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SceneObjFloat_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003CA8 RID: 15528
		// (get) Token: 0x06021B6F RID: 138095 RVA: 0x00950D6A File Offset: 0x0094EF6A
		// (set) Token: 0x06021B70 RID: 138096 RVA: 0x00950D7E File Offset: 0x0094EF7E
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneObjFloat_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneObjFloat_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003CA9 RID: 15529
		// (get) Token: 0x06021B71 RID: 138097 RVA: 0x00950D93 File Offset: 0x0094EF93
		// (set) Token: 0x06021B72 RID: 138098 RVA: 0x00950DA7 File Offset: 0x0094EFA7
		public unsafe AActor TraceActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneObjFloat_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneObjFloat_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003CAA RID: 15530
		// (get) Token: 0x06021B73 RID: 138099 RVA: 0x00950DBC File Offset: 0x0094EFBC
		// (set) Token: 0x06021B74 RID: 138100 RVA: 0x00950DD0 File Offset: 0x0094EFD0
		public unsafe UMaterialInterface Mat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneObjFloat_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneObjFloat_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003CAB RID: 15531
		// (get) Token: 0x06021B75 RID: 138101 RVA: 0x00950DE5 File Offset: 0x0094EFE5
		// (set) Token: 0x06021B76 RID: 138102 RVA: 0x00950DF5 File Offset: 0x0094EFF5
		public unsafe float FLerpMinDist
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneObjFloat_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneObjFloat_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003CAC RID: 15532
		// (get) Token: 0x06021B77 RID: 138103 RVA: 0x00950E08 File Offset: 0x0094F008
		// (set) Token: 0x06021B78 RID: 138104 RVA: 0x00950E41 File Offset: 0x0094F041
		[Nullable(1)]
		public TArray<AStaticMeshActor> SceneObjFloat
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<AStaticMeshActor> result;
				if ((result = this._SceneObjFloat) == null)
				{
					result = (this._SceneObjFloat = new TArray<AStaticMeshActor>(base.NativePtr + (IntPtr)BP_SceneObjFloat_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SceneObjFloat.CopyAssign(value);
			}
		}

		// Token: 0x17003CAD RID: 15533
		// (get) Token: 0x06021B79 RID: 138105 RVA: 0x00950E4F File Offset: 0x0094F04F
		// (set) Token: 0x06021B7A RID: 138106 RVA: 0x00950E63 File Offset: 0x0094F063
		public unsafe FVectorDouble Pos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneObjFloat_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneObjFloat_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x06021B7B RID: 138107 RVA: 0x00950E78 File Offset: 0x0094F078
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 收集ActorTag为SceneFloat的漂浮物()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneObjFloat_C.__收集ActorTag为SceneFloat的漂浮物_NativeFunctionPtr, null);
		}

		// Token: 0x06021B7C RID: 138108 RVA: 0x00950E8C File Offset: 0x0094F08C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneObjFloat_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021B7D RID: 138109 RVA: 0x00950EA0 File Offset: 0x0094F0A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneObjFloat_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021B7E RID: 138110 RVA: 0x00950EB8 File Offset: 0x0094F0B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveActorBeginOverlap(AActor OtherActor)
		{
			BP_SceneObjFloat_C.__ReceiveActorBeginOverlap_FunctionParams* ptr = stackalloc BP_SceneObjFloat_C.__ReceiveActorBeginOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SceneObjFloat_C.__ReceiveActorBeginOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneObjFloat_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneObjFloat_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021B7F RID: 138111 RVA: 0x00950F10 File Offset: 0x0094F110
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveActorBeginOverlap_Implementation(AActor OtherActor)
		{
			BP_SceneObjFloat_C.__ReceiveActorBeginOverlap_FunctionParams* ptr = stackalloc BP_SceneObjFloat_C.__ReceiveActorBeginOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SceneObjFloat_C.__ReceiveActorBeginOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneObjFloat_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneObjFloat_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021B80 RID: 138112 RVA: 0x00950F68 File Offset: 0x0094F168
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SceneObjFloat_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SceneObjFloat_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneObjFloat_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneObjFloat_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneObjFloat_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021B81 RID: 138113 RVA: 0x00950FB0 File Offset: 0x0094F1B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SceneObjFloat_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SceneObjFloat_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneObjFloat_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneObjFloat_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneObjFloat_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021B82 RID: 138114 RVA: 0x00950FF7 File Offset: 0x0094F1F7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneObjFloat_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x06021B83 RID: 138115 RVA: 0x0095100C File Offset: 0x0094F20C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SceneObjFloat(int EntryPoint)
		{
			BP_SceneObjFloat_C.__ExecuteUbergraph_BP_SceneObjFloat_FunctionParams* ptr = stackalloc BP_SceneObjFloat_C.__ExecuteUbergraph_BP_SceneObjFloat_FunctionParams[(UIntPtr)175] + 15L / (long)sizeof(BP_SceneObjFloat_C.__ExecuteUbergraph_BP_SceneObjFloat_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneObjFloat_C.__ExecuteUbergraph_BP_SceneObjFloat_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneObjFloat_C.__ExecuteUbergraph_BP_SceneObjFloat_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021B84 RID: 138116 RVA: 0x00951056 File Offset: 0x0094F256
		protected BP_SceneObjFloat_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010FFA RID: 69626
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SceneObjFloat/BP_SceneObjFloat.BP_SceneObjFloat_C";

		// Token: 0x04010FFB RID: 69627
		private static IntPtr _ClassPtr;

		// Token: 0x04010FFC RID: 69628
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010FFD RID: 69629
		internal static int __PropertyOffset_0;

		// Token: 0x04010FFE RID: 69630
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010FFF RID: 69631
		internal static int __PropertyOffset_1;

		// Token: 0x04011000 RID: 69632
		internal static int __PropertyOffset_2;

		// Token: 0x04011001 RID: 69633
		internal static int __PropertyOffset_3;

		// Token: 0x04011002 RID: 69634
		internal static int __PropertyOffset_4;

		// Token: 0x04011003 RID: 69635
		internal static int __PropertyOffset_5;

		// Token: 0x04011004 RID: 69636
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AStaticMeshActor> _SceneObjFloat;

		// Token: 0x04011005 RID: 69637
		internal static int __PropertyOffset_6;

		// Token: 0x04011006 RID: 69638
		private static IntPtr __收集ActorTag为SceneFloat的漂浮物_NativeFunctionPtr;

		// Token: 0x04011007 RID: 69639
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011008 RID: 69640
		private static IntPtr __ReceiveActorBeginOverlap_NativeFunctionPtr;

		// Token: 0x04011009 RID: 69641
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401100A RID: 69642
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401100B RID: 69643
		private static IntPtr __ExecuteUbergraph_BP_SceneObjFloat_NativeFunctionPtr;

		// Token: 0x02009B20 RID: 39712
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ReceiveActorBeginOverlap_FunctionParams
		{
			// Token: 0x040322D8 RID: 205528
			[FieldOffset(0)]
			public IntPtr OtherActor;
		}

		// Token: 0x02009B21 RID: 39713
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040322D9 RID: 205529
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B22 RID: 39714
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 160)]
		protected ref struct __ExecuteUbergraph_BP_SceneObjFloat_FunctionParams
		{
			// Token: 0x040322DA RID: 205530
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
