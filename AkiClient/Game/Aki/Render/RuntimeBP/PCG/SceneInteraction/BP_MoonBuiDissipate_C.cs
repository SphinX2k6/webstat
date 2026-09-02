using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SceneInteraction
{
	// Token: 0x02003B8C RID: 15244
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SceneInteraction/BP_MoonBuiDissipate.BP_MoonBuiDissipate_C")]
	[UnrealStructLayout(1368, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1368)]
	public class BP_MoonBuiDissipate_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021C1E RID: 138270 RVA: 0x00952607 File Offset: 0x00950807
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MoonBuiDissipate_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SceneInteraction/BP_MoonBuiDissipate.BP_MoonBuiDissipate_C");
			}
			return BP_MoonBuiDissipate_C._ClassPtr;
		}

		// Token: 0x06021C1F RID: 138271 RVA: 0x0095262C File Offset: 0x0095082C
		public BP_MoonBuiDissipate_C() : this(BuiltinUtils.AllocNativeUObject(BP_MoonBuiDissipate_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021C20 RID: 138272 RVA: 0x00952654 File Offset: 0x00950854
		[NullableContext(1)]
		public BP_MoonBuiDissipate_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MoonBuiDissipate_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003CDE RID: 15582
		// (get) Token: 0x06021C21 RID: 138273 RVA: 0x00952688 File Offset: 0x00950888
		// (set) Token: 0x06021C22 RID: 138274 RVA: 0x009526C1 File Offset: 0x009508C1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_MoonBuiDissipate_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_MoonBuiDissipate_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003CDF RID: 15583
		// (get) Token: 0x06021C23 RID: 138275 RVA: 0x009526E2 File Offset: 0x009508E2
		// (set) Token: 0x06021C24 RID: 138276 RVA: 0x009526F6 File Offset: 0x009508F6
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MoonBuiDissipate_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MoonBuiDissipate_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003CE0 RID: 15584
		// (get) Token: 0x06021C25 RID: 138277 RVA: 0x0095270B File Offset: 0x0095090B
		// (set) Token: 0x06021C26 RID: 138278 RVA: 0x0095271F File Offset: 0x0095091F
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MoonBuiDissipate_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MoonBuiDissipate_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003CE1 RID: 15585
		// (get) Token: 0x06021C27 RID: 138279 RVA: 0x00952734 File Offset: 0x00950934
		// (set) Token: 0x06021C28 RID: 138280 RVA: 0x00952748 File Offset: 0x00950948
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MoonBuiDissipate_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MoonBuiDissipate_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003CE2 RID: 15586
		// (get) Token: 0x06021C29 RID: 138281 RVA: 0x0095275D File Offset: 0x0095095D
		// (set) Token: 0x06021C2A RID: 138282 RVA: 0x0095276D File Offset: 0x0095096D
		public unsafe float Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MoonBuiDissipate_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MoonBuiDissipate_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003CE3 RID: 15587
		// (get) Token: 0x06021C2B RID: 138283 RVA: 0x0095277E File Offset: 0x0095097E
		// (set) Token: 0x06021C2C RID: 138284 RVA: 0x0095278E File Offset: 0x0095098E
		public unsafe bool IsDone
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MoonBuiDissipate_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MoonBuiDissipate_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003CE4 RID: 15588
		// (get) Token: 0x06021C2D RID: 138285 RVA: 0x0095279F File Offset: 0x0095099F
		// (set) Token: 0x06021C2E RID: 138286 RVA: 0x009527B3 File Offset: 0x009509B3
		public unsafe UStaticMesh 模型
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MoonBuiDissipate_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MoonBuiDissipate_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x06021C2F RID: 138287 RVA: 0x009527C8 File Offset: 0x009509C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MoonBuiDissipate_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021C30 RID: 138288 RVA: 0x009527DC File Offset: 0x009509DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MoonBuiDissipate_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021C31 RID: 138289 RVA: 0x009527F4 File Offset: 0x009509F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_MoonBuiDissipate_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MoonBuiDissipate_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MoonBuiDissipate_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MoonBuiDissipate_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MoonBuiDissipate_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021C32 RID: 138290 RVA: 0x0095283C File Offset: 0x00950A3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_MoonBuiDissipate_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MoonBuiDissipate_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MoonBuiDissipate_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MoonBuiDissipate_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MoonBuiDissipate_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021C33 RID: 138291 RVA: 0x00952884 File Offset: 0x00950A84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__NewBlueprint_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_MoonBuiDissipate_C.__BndEvt__NewBlueprint_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_MoonBuiDissipate_C.__BndEvt__NewBlueprint_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_MoonBuiDissipate_C.__BndEvt__NewBlueprint_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MoonBuiDissipate_C.__BndEvt__NewBlueprint_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MoonBuiDissipate_C.__BndEvt__NewBlueprint_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021C34 RID: 138292 RVA: 0x00952940 File Offset: 0x00950B40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_MoonBuiDissipate(int EntryPoint)
		{
			BP_MoonBuiDissipate_C.__ExecuteUbergraph_BP_MoonBuiDissipate_FunctionParams* ptr = stackalloc BP_MoonBuiDissipate_C.__ExecuteUbergraph_BP_MoonBuiDissipate_FunctionParams[(UIntPtr)271] + 15L / (long)sizeof(BP_MoonBuiDissipate_C.__ExecuteUbergraph_BP_MoonBuiDissipate_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MoonBuiDissipate_C.__ExecuteUbergraph_BP_MoonBuiDissipate_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MoonBuiDissipate_C.__ExecuteUbergraph_BP_MoonBuiDissipate_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021C35 RID: 138293 RVA: 0x0095298A File Offset: 0x00950B8A
		protected BP_MoonBuiDissipate_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401106F RID: 69743
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SceneInteraction/BP_MoonBuiDissipate.BP_MoonBuiDissipate_C";

		// Token: 0x04011070 RID: 69744
		private static IntPtr _ClassPtr;

		// Token: 0x04011071 RID: 69745
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011072 RID: 69746
		internal static int __PropertyOffset_0;

		// Token: 0x04011073 RID: 69747
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011074 RID: 69748
		internal static int __PropertyOffset_1;

		// Token: 0x04011075 RID: 69749
		internal static int __PropertyOffset_2;

		// Token: 0x04011076 RID: 69750
		internal static int __PropertyOffset_3;

		// Token: 0x04011077 RID: 69751
		internal static int __PropertyOffset_4;

		// Token: 0x04011078 RID: 69752
		internal static int __PropertyOffset_5;

		// Token: 0x04011079 RID: 69753
		internal static int __PropertyOffset_6;

		// Token: 0x0401107A RID: 69754
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401107B RID: 69755
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401107C RID: 69756
		private static IntPtr __BndEvt__NewBlueprint_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401107D RID: 69757
		private static IntPtr __ExecuteUbergraph_BP_MoonBuiDissipate_NativeFunctionPtr;

		// Token: 0x02009B3C RID: 39740
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403230E RID: 205582
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B3D RID: 39741
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__NewBlueprint_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403230F RID: 205583
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032310 RID: 205584
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032311 RID: 205585
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032312 RID: 205586
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04032313 RID: 205587
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032314 RID: 205588
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009B3E RID: 39742
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 256)]
		protected ref struct __ExecuteUbergraph_BP_MoonBuiDissipate_FunctionParams
		{
			// Token: 0x04032315 RID: 205589
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
