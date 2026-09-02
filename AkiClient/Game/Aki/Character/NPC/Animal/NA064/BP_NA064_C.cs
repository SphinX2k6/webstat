using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonSmallAnimal;
using AkiClient.Game.Aki.Render.RuntimeBP.SnowCoverInteraction.BluePrints;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA064
{
	// Token: 0x02004117 RID: 16663
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA064/BP_NA064.BP_NA064_C")]
	[UnrealStructLayout(2272, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2272)]
	public class BP_NA064_C : BP_CommonSmallAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C50D RID: 181517 RVA: 0x00A9D404 File Offset: 0x00A9B604
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA064_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA064/BP_NA064.BP_NA064_C");
			}
			return BP_NA064_C._ClassPtr;
		}

		// Token: 0x0602C50E RID: 181518 RVA: 0x00A9D428 File Offset: 0x00A9B628
		public BP_NA064_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA064_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C50F RID: 181519 RVA: 0x00A9D450 File Offset: 0x00A9B650
		[NullableContext(1)]
		public BP_NA064_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA064_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700774A RID: 30538
		// (get) Token: 0x0602C510 RID: 181520 RVA: 0x00A9D484 File Offset: 0x00A9B684
		// (set) Token: 0x0602C511 RID: 181521 RVA: 0x00A9D4BD File Offset: 0x00A9B6BD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_NA064_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_NA064_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700774B RID: 30539
		// (get) Token: 0x0602C512 RID: 181522 RVA: 0x00A9D4DE File Offset: 0x00A9B6DE
		// (set) Token: 0x0602C513 RID: 181523 RVA: 0x00A9D4F2 File Offset: 0x00A9B6F2
		public unsafe BP_SnowTrailComponent_NPC_C BP_SnowTrailComponent_NPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_SnowTrailComponent_NPC_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA064_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA064_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700774C RID: 30540
		// (get) Token: 0x0602C514 RID: 181524 RVA: 0x00A9D507 File Offset: 0x00A9B707
		// (set) Token: 0x0602C515 RID: 181525 RVA: 0x00A9D51B File Offset: 0x00A9B71B
		public unsafe UCapsuleComponent Capsule
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA064_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA064_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700774D RID: 30541
		// (get) Token: 0x0602C516 RID: 181526 RVA: 0x00A9D530 File Offset: 0x00A9B730
		// (set) Token: 0x0602C517 RID: 181527 RVA: 0x00A9D544 File Offset: 0x00A9B744
		public unsafe UKuroAdjustableCapsuleComponent ROOT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroAdjustableCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA064_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA064_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x0602C518 RID: 181528 RVA: 0x00A9D559 File Offset: 0x00A9B759
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NA064_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602C519 RID: 181529 RVA: 0x00A9D56D File Offset: 0x00A9B76D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA064_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C51A RID: 181530 RVA: 0x00A9D584 File Offset: 0x00A9B784
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_NA064(int EntryPoint)
		{
			BP_NA064_C.__ExecuteUbergraph_BP_NA064_FunctionParams* ptr = stackalloc BP_NA064_C.__ExecuteUbergraph_BP_NA064_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_NA064_C.__ExecuteUbergraph_BP_NA064_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NA064_C.__ExecuteUbergraph_BP_NA064_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA064_C.__ExecuteUbergraph_BP_NA064_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C51B RID: 181531 RVA: 0x00A9D5CB File Offset: 0x00A9B7CB
		protected BP_NA064_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401896A RID: 100714
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA064/BP_NA064.BP_NA064_C";

		// Token: 0x0401896B RID: 100715
		private static IntPtr _ClassPtr;

		// Token: 0x0401896C RID: 100716
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401896D RID: 100717
		internal new static int __PropertyOffset_0;

		// Token: 0x0401896E RID: 100718
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401896F RID: 100719
		internal static int __PropertyOffset_1;

		// Token: 0x04018970 RID: 100720
		internal static int __PropertyOffset_2;

		// Token: 0x04018971 RID: 100721
		internal static int __PropertyOffset_3;

		// Token: 0x04018972 RID: 100722
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04018973 RID: 100723
		private static IntPtr __ExecuteUbergraph_BP_NA064_NativeFunctionPtr;

		// Token: 0x0200A43A RID: 42042
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_NA064_FunctionParams
		{
			// Token: 0x04033235 RID: 209461
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
