using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Effect.BluePrint.BP_FX_Common
{
	// Token: 0x02003DEF RID: 15855
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_Fx_WayFinding.BP_Fx_WayFinding_C")]
	[UnrealStructLayout(1352, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1348)]
	public class BP_Fx_WayFinding_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026FF8 RID: 159736 RVA: 0x009E76F4 File Offset: 0x009E58F4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Fx_WayFinding_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_Fx_WayFinding.BP_Fx_WayFinding_C");
			}
			return BP_Fx_WayFinding_C._ClassPtr;
		}

		// Token: 0x06026FF9 RID: 159737 RVA: 0x009E7718 File Offset: 0x009E5918
		public BP_Fx_WayFinding_C() : this(BuiltinUtils.AllocNativeUObject(BP_Fx_WayFinding_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026FFA RID: 159738 RVA: 0x009E7740 File Offset: 0x009E5940
		[NullableContext(1)]
		public BP_Fx_WayFinding_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Fx_WayFinding_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005A78 RID: 23160
		// (get) Token: 0x06026FFB RID: 159739 RVA: 0x009E7774 File Offset: 0x009E5974
		// (set) Token: 0x06026FFC RID: 159740 RVA: 0x009E77AD File Offset: 0x009E59AD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Fx_WayFinding_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Fx_WayFinding_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005A79 RID: 23161
		// (get) Token: 0x06026FFD RID: 159741 RVA: 0x009E77CE File Offset: 0x009E59CE
		// (set) Token: 0x06026FFE RID: 159742 RVA: 0x009E77E2 File Offset: 0x009E59E2
		public unsafe UNiagaraComponent NS_Fx_WayFinding
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_WayFinding_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_WayFinding_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005A7A RID: 23162
		// (get) Token: 0x06026FFF RID: 159743 RVA: 0x009E77F7 File Offset: 0x009E59F7
		// (set) Token: 0x06027000 RID: 159744 RVA: 0x009E780B File Offset: 0x009E5A0B
		public unsafe USplineComponent Spline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_WayFinding_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_WayFinding_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005A7B RID: 23163
		// (get) Token: 0x06027001 RID: 159745 RVA: 0x009E7820 File Offset: 0x009E5A20
		// (set) Token: 0x06027002 RID: 159746 RVA: 0x009E7830 File Offset: 0x009E5A30
		public unsafe float Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_WayFinding_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_WayFinding_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005A7C RID: 23164
		// (get) Token: 0x06027003 RID: 159747 RVA: 0x009E7841 File Offset: 0x009E5A41
		// (set) Token: 0x06027004 RID: 159748 RVA: 0x009E7851 File Offset: 0x009E5A51
		public unsafe int MinFragmentsNum
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_WayFinding_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_WayFinding_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005A7D RID: 23165
		// (get) Token: 0x06027005 RID: 159749 RVA: 0x009E7862 File Offset: 0x009E5A62
		// (set) Token: 0x06027006 RID: 159750 RVA: 0x009E7872 File Offset: 0x009E5A72
		public unsafe bool Deactivating
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_WayFinding_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_WayFinding_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005A7E RID: 23166
		// (get) Token: 0x06027007 RID: 159751 RVA: 0x009E7883 File Offset: 0x009E5A83
		// (set) Token: 0x06027008 RID: 159752 RVA: 0x009E7893 File Offset: 0x009E5A93
		public unsafe float DeactiveAlpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_WayFinding_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_WayFinding_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005A7F RID: 23167
		// (get) Token: 0x06027009 RID: 159753 RVA: 0x009E78A4 File Offset: 0x009E5AA4
		// (set) Token: 0x0602700A RID: 159754 RVA: 0x009E78B4 File Offset: 0x009E5AB4
		public unsafe float DeactiveAlphaSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_WayFinding_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_WayFinding_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x0602700B RID: 159755 RVA: 0x009E78C5 File Offset: 0x009E5AC5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StopEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_WayFinding_C.__StopEffect_NativeFunctionPtr, null);
		}

		// Token: 0x0602700C RID: 159756 RVA: 0x009E78D9 File Offset: 0x009E5AD9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EnsureEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_WayFinding_C.__EnsureEffect_NativeFunctionPtr, null);
		}

		// Token: 0x0602700D RID: 159757 RVA: 0x009E78ED File Offset: 0x009E5AED
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_WayFinding_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602700E RID: 159758 RVA: 0x009E7901 File Offset: 0x009E5B01
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Fx_WayFinding_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602700F RID: 159759 RVA: 0x009E7918 File Offset: 0x009E5B18
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Fx_WayFinding_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Fx_WayFinding_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Fx_WayFinding_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_WayFinding_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_WayFinding_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06027010 RID: 159760 RVA: 0x009E7960 File Offset: 0x009E5B60
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Fx_WayFinding_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Fx_WayFinding_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Fx_WayFinding_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_WayFinding_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Fx_WayFinding_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06027011 RID: 159761 RVA: 0x009E79A8 File Offset: 0x009E5BA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Fx_WayFinding(int EntryPoint)
		{
			BP_Fx_WayFinding_C.__ExecuteUbergraph_BP_Fx_WayFinding_FunctionParams* ptr = stackalloc BP_Fx_WayFinding_C.__ExecuteUbergraph_BP_Fx_WayFinding_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_Fx_WayFinding_C.__ExecuteUbergraph_BP_Fx_WayFinding_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_WayFinding_C.__ExecuteUbergraph_BP_Fx_WayFinding_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Fx_WayFinding_C.__ExecuteUbergraph_BP_Fx_WayFinding_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06027012 RID: 159762 RVA: 0x009E79EF File Offset: 0x009E5BEF
		protected BP_Fx_WayFinding_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040145D6 RID: 83414
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_Fx_WayFinding.BP_Fx_WayFinding_C";

		// Token: 0x040145D7 RID: 83415
		private static IntPtr _ClassPtr;

		// Token: 0x040145D8 RID: 83416
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040145D9 RID: 83417
		internal static int __PropertyOffset_0;

		// Token: 0x040145DA RID: 83418
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040145DB RID: 83419
		internal static int __PropertyOffset_1;

		// Token: 0x040145DC RID: 83420
		internal static int __PropertyOffset_2;

		// Token: 0x040145DD RID: 83421
		internal static int __PropertyOffset_3;

		// Token: 0x040145DE RID: 83422
		internal static int __PropertyOffset_4;

		// Token: 0x040145DF RID: 83423
		internal static int __PropertyOffset_5;

		// Token: 0x040145E0 RID: 83424
		internal static int __PropertyOffset_6;

		// Token: 0x040145E1 RID: 83425
		internal static int __PropertyOffset_7;

		// Token: 0x040145E2 RID: 83426
		private static IntPtr __StopEffect_NativeFunctionPtr;

		// Token: 0x040145E3 RID: 83427
		private static IntPtr __EnsureEffect_NativeFunctionPtr;

		// Token: 0x040145E4 RID: 83428
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040145E5 RID: 83429
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040145E6 RID: 83430
		private static IntPtr __ExecuteUbergraph_BP_Fx_WayFinding_NativeFunctionPtr;

		// Token: 0x0200A0CC RID: 41164
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032D80 RID: 208256
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A0CD RID: 41165
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __ExecuteUbergraph_BP_Fx_WayFinding_FunctionParams
		{
			// Token: 0x04032D81 RID: 208257
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
