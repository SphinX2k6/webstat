using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.BatchedClothDynamicPin
{
	// Token: 0x02003C44 RID: 15428
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/BatchedClothDynamicPin/BP_BatchedBridgeRope.BP_BatchedBridgeRope_C")]
	[UnrealStructLayout(1616, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1609)]
	public class BP_BatchedBridgeRope_C : AKuroCSClothDynamicPinManager, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060237A1 RID: 145313 RVA: 0x009835A4 File Offset: 0x009817A4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BatchedBridgeRope_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/BatchedClothDynamicPin/BP_BatchedBridgeRope.BP_BatchedBridgeRope_C");
			}
			return BP_BatchedBridgeRope_C._ClassPtr;
		}

		// Token: 0x060237A2 RID: 145314 RVA: 0x009835C8 File Offset: 0x009817C8
		public BP_BatchedBridgeRope_C() : this(BuiltinUtils.AllocNativeUObject(BP_BatchedBridgeRope_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060237A3 RID: 145315 RVA: 0x009835F0 File Offset: 0x009817F0
		[NullableContext(1)]
		public BP_BatchedBridgeRope_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BatchedBridgeRope_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700469F RID: 18079
		// (get) Token: 0x060237A4 RID: 145316 RVA: 0x00983624 File Offset: 0x00981824
		// (set) Token: 0x060237A5 RID: 145317 RVA: 0x0098365D File Offset: 0x0098185D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_BatchedBridgeRope_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_BatchedBridgeRope_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170046A0 RID: 18080
		// (get) Token: 0x060237A6 RID: 145318 RVA: 0x0098367E File Offset: 0x0098187E
		// (set) Token: 0x060237A7 RID: 145319 RVA: 0x00983692 File Offset: 0x00981892
		[Nullable(2)]
		public unsafe UBoxComponent ValidBox
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BatchedBridgeRope_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BatchedBridgeRope_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170046A1 RID: 18081
		// (get) Token: 0x060237A8 RID: 145320 RVA: 0x009836A7 File Offset: 0x009818A7
		// (set) Token: 0x060237A9 RID: 145321 RVA: 0x009836B7 File Offset: 0x009818B7
		public unsafe bool InitOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BatchedBridgeRope_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BatchedBridgeRope_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x060237AA RID: 145322 RVA: 0x009836C8 File Offset: 0x009818C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BatchedBridgeRope_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060237AB RID: 145323 RVA: 0x009836DC File Offset: 0x009818DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BatchedBridgeRope_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060237AC RID: 145324 RVA: 0x009836F1 File Offset: 0x009818F1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BatchedBridgeRope_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060237AD RID: 145325 RVA: 0x00983705 File Offset: 0x00981905
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BatchedBridgeRope_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060237AE RID: 145326 RVA: 0x0098371C File Offset: 0x0098191C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_BatchedBridgeRope_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BatchedBridgeRope_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BatchedBridgeRope_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BatchedBridgeRope_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BatchedBridgeRope_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060237AF RID: 145327 RVA: 0x00983764 File Offset: 0x00981964
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_BatchedBridgeRope_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BatchedBridgeRope_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BatchedBridgeRope_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BatchedBridgeRope_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BatchedBridgeRope_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060237B0 RID: 145328 RVA: 0x009837AC File Offset: 0x009819AC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_BatchedBridgeRope_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_BatchedBridgeRope_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_BatchedBridgeRope_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BatchedBridgeRope_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BatchedBridgeRope_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060237B1 RID: 145329 RVA: 0x00983868 File Offset: 0x00981A68
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_BatchedBridgeRope_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_BatchedBridgeRope_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_BatchedBridgeRope_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BatchedBridgeRope_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BatchedBridgeRope_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060237B2 RID: 145330 RVA: 0x009838F4 File Offset: 0x00981AF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_BatchedBridgeRope(int EntryPoint)
		{
			BP_BatchedBridgeRope_C.__ExecuteUbergraph_BP_BatchedBridgeRope_FunctionParams* ptr = stackalloc BP_BatchedBridgeRope_C.__ExecuteUbergraph_BP_BatchedBridgeRope_FunctionParams[(UIntPtr)351] + 15L / (long)sizeof(BP_BatchedBridgeRope_C.__ExecuteUbergraph_BP_BatchedBridgeRope_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BatchedBridgeRope_C.__ExecuteUbergraph_BP_BatchedBridgeRope_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BatchedBridgeRope_C.__ExecuteUbergraph_BP_BatchedBridgeRope_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060237B3 RID: 145331 RVA: 0x0098393E File Offset: 0x00981B3E
		protected BP_BatchedBridgeRope_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040120FE RID: 73982
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/BatchedClothDynamicPin/BP_BatchedBridgeRope.BP_BatchedBridgeRope_C";

		// Token: 0x040120FF RID: 73983
		private static IntPtr _ClassPtr;

		// Token: 0x04012100 RID: 73984
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012101 RID: 73985
		internal static int __PropertyOffset_0;

		// Token: 0x04012102 RID: 73986
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012103 RID: 73987
		internal static int __PropertyOffset_1;

		// Token: 0x04012104 RID: 73988
		internal static int __PropertyOffset_2;

		// Token: 0x04012105 RID: 73989
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012106 RID: 73990
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012107 RID: 73991
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012108 RID: 73992
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012109 RID: 73993
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401210A RID: 73994
		private static IntPtr __ExecuteUbergraph_BP_BatchedBridgeRope_NativeFunctionPtr;

		// Token: 0x02009CEE RID: 40174
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032686 RID: 206470
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009CEF RID: 40175
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032687 RID: 206471
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032688 RID: 206472
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032689 RID: 206473
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403268A RID: 206474
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x0403268B RID: 206475
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x0403268C RID: 206476
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009CF0 RID: 40176
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403268D RID: 206477
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403268E RID: 206478
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403268F RID: 206479
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032690 RID: 206480
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009CF1 RID: 40177
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 336)]
		protected ref struct __ExecuteUbergraph_BP_BatchedBridgeRope_FunctionParams
		{
			// Token: 0x04032691 RID: 206481
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
