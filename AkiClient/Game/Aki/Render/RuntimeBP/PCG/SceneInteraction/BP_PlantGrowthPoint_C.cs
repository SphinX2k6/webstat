using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SceneInteraction
{
	// Token: 0x02003B8D RID: 15245
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SceneInteraction/BP_PlantGrowthPoint.BP_PlantGrowthPoint_C")]
	[UnrealStructLayout(1352, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1345)]
	public class BP_PlantGrowthPoint_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021C36 RID: 138294 RVA: 0x00952993 File Offset: 0x00950B93
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PlantGrowthPoint_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SceneInteraction/BP_PlantGrowthPoint.BP_PlantGrowthPoint_C");
			}
			return BP_PlantGrowthPoint_C._ClassPtr;
		}

		// Token: 0x06021C37 RID: 138295 RVA: 0x009529B8 File Offset: 0x00950BB8
		public BP_PlantGrowthPoint_C() : this(BuiltinUtils.AllocNativeUObject(BP_PlantGrowthPoint_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021C38 RID: 138296 RVA: 0x009529E0 File Offset: 0x00950BE0
		[NullableContext(1)]
		public BP_PlantGrowthPoint_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PlantGrowthPoint_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003CE5 RID: 15589
		// (get) Token: 0x06021C39 RID: 138297 RVA: 0x00952A14 File Offset: 0x00950C14
		// (set) Token: 0x06021C3A RID: 138298 RVA: 0x00952A4D File Offset: 0x00950C4D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PlantGrowthPoint_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PlantGrowthPoint_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003CE6 RID: 15590
		// (get) Token: 0x06021C3B RID: 138299 RVA: 0x00952A6E File Offset: 0x00950C6E
		// (set) Token: 0x06021C3C RID: 138300 RVA: 0x00952A82 File Offset: 0x00950C82
		public unsafe USphereComponent Sphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USphereComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlantGrowthPoint_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlantGrowthPoint_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003CE7 RID: 15591
		// (get) Token: 0x06021C3D RID: 138301 RVA: 0x00952A97 File Offset: 0x00950C97
		// (set) Token: 0x06021C3E RID: 138302 RVA: 0x00952AAB File Offset: 0x00950CAB
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlantGrowthPoint_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlantGrowthPoint_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003CE8 RID: 15592
		// (get) Token: 0x06021C3F RID: 138303 RVA: 0x00952AC0 File Offset: 0x00950CC0
		// (set) Token: 0x06021C40 RID: 138304 RVA: 0x00952AD0 File Offset: 0x00950CD0
		public unsafe bool IsDone
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlantGrowthPoint_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlantGrowthPoint_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x06021C41 RID: 138305 RVA: 0x00952AE4 File Offset: 0x00950CE4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_PlantGrowthPoint_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PlantGrowthPoint_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PlantGrowthPoint_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PlantGrowthPoint_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PlantGrowthPoint_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021C42 RID: 138306 RVA: 0x00952B2C File Offset: 0x00950D2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_PlantGrowthPoint_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PlantGrowthPoint_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PlantGrowthPoint_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PlantGrowthPoint_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PlantGrowthPoint_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021C43 RID: 138307 RVA: 0x00952B74 File Offset: 0x00950D74
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_FoliageGrowthPOI_Sphere_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_PlantGrowthPoint_C.__BndEvt__BP_FoliageGrowthPOI_Sphere_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_PlantGrowthPoint_C.__BndEvt__BP_FoliageGrowthPOI_Sphere_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_PlantGrowthPoint_C.__BndEvt__BP_FoliageGrowthPOI_Sphere_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PlantGrowthPoint_C.__BndEvt__BP_FoliageGrowthPOI_Sphere_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PlantGrowthPoint_C.__BndEvt__BP_FoliageGrowthPOI_Sphere_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021C44 RID: 138308 RVA: 0x00952C30 File Offset: 0x00950E30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PlantGrowthPoint(int EntryPoint)
		{
			BP_PlantGrowthPoint_C.__ExecuteUbergraph_BP_PlantGrowthPoint_FunctionParams* ptr = stackalloc BP_PlantGrowthPoint_C.__ExecuteUbergraph_BP_PlantGrowthPoint_FunctionParams[(UIntPtr)303] + 15L / (long)sizeof(BP_PlantGrowthPoint_C.__ExecuteUbergraph_BP_PlantGrowthPoint_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PlantGrowthPoint_C.__ExecuteUbergraph_BP_PlantGrowthPoint_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PlantGrowthPoint_C.__ExecuteUbergraph_BP_PlantGrowthPoint_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021C45 RID: 138309 RVA: 0x00952C7A File Offset: 0x00950E7A
		protected BP_PlantGrowthPoint_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401107E RID: 69758
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SceneInteraction/BP_PlantGrowthPoint.BP_PlantGrowthPoint_C";

		// Token: 0x0401107F RID: 69759
		private static IntPtr _ClassPtr;

		// Token: 0x04011080 RID: 69760
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011081 RID: 69761
		internal static int __PropertyOffset_0;

		// Token: 0x04011082 RID: 69762
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011083 RID: 69763
		internal static int __PropertyOffset_1;

		// Token: 0x04011084 RID: 69764
		internal static int __PropertyOffset_2;

		// Token: 0x04011085 RID: 69765
		internal static int __PropertyOffset_3;

		// Token: 0x04011086 RID: 69766
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011087 RID: 69767
		private static IntPtr __BndEvt__BP_FoliageGrowthPOI_Sphere_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011088 RID: 69768
		private static IntPtr __ExecuteUbergraph_BP_PlantGrowthPoint_NativeFunctionPtr;

		// Token: 0x02009B3F RID: 39743
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032316 RID: 205590
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B40 RID: 39744
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_FoliageGrowthPOI_Sphere_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032317 RID: 205591
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032318 RID: 205592
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032319 RID: 205593
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403231A RID: 205594
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x0403231B RID: 205595
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x0403231C RID: 205596
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009B41 RID: 39745
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 288)]
		protected ref struct __ExecuteUbergraph_BP_PlantGrowthPoint_FunctionParams
		{
			// Token: 0x0403231D RID: 205597
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
