using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive
{
	// Token: 0x02003CEF RID: 15599
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/BP_FluidDisplayMoveWithGrid.BP_FluidDisplayMoveWithGrid_C")]
	[UnrealStructLayout(1368, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1368)]
	public class BP_FluidDisplayMoveWithGrid_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025458 RID: 152664 RVA: 0x009B5D5B File Offset: 0x009B3F5B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FluidDisplayMoveWithGrid_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/BP_FluidDisplayMoveWithGrid.BP_FluidDisplayMoveWithGrid_C");
			}
			return BP_FluidDisplayMoveWithGrid_C._ClassPtr;
		}

		// Token: 0x06025459 RID: 152665 RVA: 0x009B5D80 File Offset: 0x009B3F80
		public BP_FluidDisplayMoveWithGrid_C() : this(BuiltinUtils.AllocNativeUObject(BP_FluidDisplayMoveWithGrid_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602545A RID: 152666 RVA: 0x009B5DA8 File Offset: 0x009B3FA8
		[NullableContext(1)]
		public BP_FluidDisplayMoveWithGrid_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FluidDisplayMoveWithGrid_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700508B RID: 20619
		// (get) Token: 0x0602545B RID: 152667 RVA: 0x009B5DDC File Offset: 0x009B3FDC
		// (set) Token: 0x0602545C RID: 152668 RVA: 0x009B5E15 File Offset: 0x009B4015
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_FluidDisplayMoveWithGrid_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_FluidDisplayMoveWithGrid_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700508C RID: 20620
		// (get) Token: 0x0602545D RID: 152669 RVA: 0x009B5E36 File Offset: 0x009B4036
		// (set) Token: 0x0602545E RID: 152670 RVA: 0x009B5E4A File Offset: 0x009B404A
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FluidDisplayMoveWithGrid_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FluidDisplayMoveWithGrid_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700508D RID: 20621
		// (get) Token: 0x0602545F RID: 152671 RVA: 0x009B5E5F File Offset: 0x009B405F
		// (set) Token: 0x06025460 RID: 152672 RVA: 0x009B5E73 File Offset: 0x009B4073
		public unsafe AActor TargetActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FluidDisplayMoveWithGrid_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FluidDisplayMoveWithGrid_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700508E RID: 20622
		// (get) Token: 0x06025461 RID: 152673 RVA: 0x009B5E88 File Offset: 0x009B4088
		// (set) Token: 0x06025462 RID: 152674 RVA: 0x009B5E9C File Offset: 0x009B409C
		public unsafe NinjaLive_C TargetNinjaLive
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<NinjaLive_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FluidDisplayMoveWithGrid_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FluidDisplayMoveWithGrid_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700508F RID: 20623
		// (get) Token: 0x06025463 RID: 152675 RVA: 0x009B5EB1 File Offset: 0x009B40B1
		// (set) Token: 0x06025464 RID: 152676 RVA: 0x009B5EC1 File Offset: 0x009B40C1
		public unsafe bool bUseGridFollow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FluidDisplayMoveWithGrid_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FluidDisplayMoveWithGrid_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005090 RID: 20624
		// (get) Token: 0x06025465 RID: 152677 RVA: 0x009B5ED2 File Offset: 0x009B40D2
		// (set) Token: 0x06025466 RID: 152678 RVA: 0x009B5EE2 File Offset: 0x009B40E2
		public unsafe bool bDisable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FluidDisplayMoveWithGrid_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FluidDisplayMoveWithGrid_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005091 RID: 20625
		// (get) Token: 0x06025467 RID: 152679 RVA: 0x009B5EF3 File Offset: 0x009B40F3
		// (set) Token: 0x06025468 RID: 152680 RVA: 0x009B5F03 File Offset: 0x009B4103
		public unsafe float ValidDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FluidDisplayMoveWithGrid_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FluidDisplayMoveWithGrid_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005092 RID: 20626
		// (get) Token: 0x06025469 RID: 152681 RVA: 0x009B5F14 File Offset: 0x009B4114
		// (set) Token: 0x0602546A RID: 152682 RVA: 0x009B5F28 File Offset: 0x009B4128
		public unsafe FVectorDouble rawPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FluidDisplayMoveWithGrid_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FluidDisplayMoveWithGrid_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x0602546B RID: 152683 RVA: 0x009B5F3D File Offset: 0x009B413D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FluidDisplayMoveWithGrid_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602546C RID: 152684 RVA: 0x009B5F51 File Offset: 0x009B4151
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FluidDisplayMoveWithGrid_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602546D RID: 152685 RVA: 0x009B5F68 File Offset: 0x009B4168
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_FluidDisplayMoveWithGrid_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FluidDisplayMoveWithGrid_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FluidDisplayMoveWithGrid_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FluidDisplayMoveWithGrid_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FluidDisplayMoveWithGrid_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602546E RID: 152686 RVA: 0x009B5FB0 File Offset: 0x009B41B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_FluidDisplayMoveWithGrid_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FluidDisplayMoveWithGrid_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FluidDisplayMoveWithGrid_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FluidDisplayMoveWithGrid_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FluidDisplayMoveWithGrid_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602546F RID: 152687 RVA: 0x009B5FF8 File Offset: 0x009B41F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_FluidDisplayMoveWithGrid_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_FluidDisplayMoveWithGrid_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_FluidDisplayMoveWithGrid_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FluidDisplayMoveWithGrid_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FluidDisplayMoveWithGrid_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025470 RID: 152688 RVA: 0x009B6044 File Offset: 0x009B4244
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_FluidDisplayMoveWithGrid_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_FluidDisplayMoveWithGrid_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_FluidDisplayMoveWithGrid_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FluidDisplayMoveWithGrid_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FluidDisplayMoveWithGrid_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025471 RID: 152689 RVA: 0x009B6090 File Offset: 0x009B4290
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_FluidDisplayMoveWithGrid(int EntryPoint)
		{
			BP_FluidDisplayMoveWithGrid_C.__ExecuteUbergraph_BP_FluidDisplayMoveWithGrid_FunctionParams* ptr = stackalloc BP_FluidDisplayMoveWithGrid_C.__ExecuteUbergraph_BP_FluidDisplayMoveWithGrid_FunctionParams[(UIntPtr)911] + 15L / (long)sizeof(BP_FluidDisplayMoveWithGrid_C.__ExecuteUbergraph_BP_FluidDisplayMoveWithGrid_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FluidDisplayMoveWithGrid_C.__ExecuteUbergraph_BP_FluidDisplayMoveWithGrid_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FluidDisplayMoveWithGrid_C.__ExecuteUbergraph_BP_FluidDisplayMoveWithGrid_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025472 RID: 152690 RVA: 0x009B60DA File Offset: 0x009B42DA
		protected BP_FluidDisplayMoveWithGrid_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013337 RID: 78647
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/BP_FluidDisplayMoveWithGrid.BP_FluidDisplayMoveWithGrid_C";

		// Token: 0x04013338 RID: 78648
		private static IntPtr _ClassPtr;

		// Token: 0x04013339 RID: 78649
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401333A RID: 78650
		internal static int __PropertyOffset_0;

		// Token: 0x0401333B RID: 78651
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401333C RID: 78652
		internal static int __PropertyOffset_1;

		// Token: 0x0401333D RID: 78653
		internal static int __PropertyOffset_2;

		// Token: 0x0401333E RID: 78654
		internal static int __PropertyOffset_3;

		// Token: 0x0401333F RID: 78655
		internal static int __PropertyOffset_4;

		// Token: 0x04013340 RID: 78656
		internal static int __PropertyOffset_5;

		// Token: 0x04013341 RID: 78657
		internal static int __PropertyOffset_6;

		// Token: 0x04013342 RID: 78658
		internal static int __PropertyOffset_7;

		// Token: 0x04013343 RID: 78659
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04013344 RID: 78660
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013345 RID: 78661
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04013346 RID: 78662
		private static IntPtr __ExecuteUbergraph_BP_FluidDisplayMoveWithGrid_NativeFunctionPtr;

		// Token: 0x02009EF2 RID: 40690
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040329E7 RID: 207335
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009EF3 RID: 40691
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x040329E8 RID: 207336
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009EF4 RID: 40692
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 896)]
		protected ref struct __ExecuteUbergraph_BP_FluidDisplayMoveWithGrid_FunctionParams
		{
			// Token: 0x040329E9 RID: 207337
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
