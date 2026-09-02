using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonSmallAnimal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA059
{
	// Token: 0x02004126 RID: 16678
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA059/BP_NA059_NPC_BugFinder.BP_NA059_NPC_BugFinder_C")]
	[UnrealStructLayout(2272, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2264)]
	public class BP_NA059_NPC_BugFinder_C : BP_CommonSmallAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C57D RID: 181629 RVA: 0x00A9E28C File Offset: 0x00A9C48C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA059_NPC_BugFinder_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA059/BP_NA059_NPC_BugFinder.BP_NA059_NPC_BugFinder_C");
			}
			return BP_NA059_NPC_BugFinder_C._ClassPtr;
		}

		// Token: 0x0602C57E RID: 181630 RVA: 0x00A9E2B0 File Offset: 0x00A9C4B0
		public BP_NA059_NPC_BugFinder_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA059_NPC_BugFinder_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C57F RID: 181631 RVA: 0x00A9E2D8 File Offset: 0x00A9C4D8
		[NullableContext(1)]
		public BP_NA059_NPC_BugFinder_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA059_NPC_BugFinder_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700775B RID: 30555
		// (get) Token: 0x0602C580 RID: 181632 RVA: 0x00A9E30C File Offset: 0x00A9C50C
		// (set) Token: 0x0602C581 RID: 181633 RVA: 0x00A9E345 File Offset: 0x00A9C545
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_NA059_NPC_BugFinder_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_NA059_NPC_BugFinder_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700775C RID: 30556
		// (get) Token: 0x0602C582 RID: 181634 RVA: 0x00A9E366 File Offset: 0x00A9C566
		// (set) Token: 0x0602C583 RID: 181635 RVA: 0x00A9E37A File Offset: 0x00A9C57A
		public unsafe UCapsuleComponent Capsule
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA059_NPC_BugFinder_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA059_NPC_BugFinder_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700775D RID: 30557
		// (get) Token: 0x0602C584 RID: 181636 RVA: 0x00A9E38F File Offset: 0x00A9C58F
		// (set) Token: 0x0602C585 RID: 181637 RVA: 0x00A9E3A3 File Offset: 0x00A9C5A3
		public unsafe UKuroAdjustableCapsuleComponent ROOT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroAdjustableCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA059_NPC_BugFinder_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA059_NPC_BugFinder_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x0602C586 RID: 181638 RVA: 0x00A9E3B8 File Offset: 0x00A9C5B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NA059_NPC_BugFinder_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602C587 RID: 181639 RVA: 0x00A9E3CC File Offset: 0x00A9C5CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA059_NPC_BugFinder_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C588 RID: 181640 RVA: 0x00A9E3E4 File Offset: 0x00A9C5E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_NA059_NPC_BugFinder(int EntryPoint)
		{
			BP_NA059_NPC_BugFinder_C.__ExecuteUbergraph_BP_NA059_NPC_BugFinder_FunctionParams* ptr = stackalloc BP_NA059_NPC_BugFinder_C.__ExecuteUbergraph_BP_NA059_NPC_BugFinder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_NA059_NPC_BugFinder_C.__ExecuteUbergraph_BP_NA059_NPC_BugFinder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NA059_NPC_BugFinder_C.__ExecuteUbergraph_BP_NA059_NPC_BugFinder_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA059_NPC_BugFinder_C.__ExecuteUbergraph_BP_NA059_NPC_BugFinder_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C589 RID: 181641 RVA: 0x00A9E42B File Offset: 0x00A9C62B
		protected BP_NA059_NPC_BugFinder_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040189BA RID: 100794
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA059/BP_NA059_NPC_BugFinder.BP_NA059_NPC_BugFinder_C";

		// Token: 0x040189BB RID: 100795
		private static IntPtr _ClassPtr;

		// Token: 0x040189BC RID: 100796
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040189BD RID: 100797
		internal new static int __PropertyOffset_0;

		// Token: 0x040189BE RID: 100798
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040189BF RID: 100799
		internal static int __PropertyOffset_1;

		// Token: 0x040189C0 RID: 100800
		internal static int __PropertyOffset_2;

		// Token: 0x040189C1 RID: 100801
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040189C2 RID: 100802
		private static IntPtr __ExecuteUbergraph_BP_NA059_NPC_BugFinder_NativeFunctionPtr;

		// Token: 0x0200A440 RID: 42048
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_NA059_NPC_BugFinder_FunctionParams
		{
			// Token: 0x0403323B RID: 209467
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
