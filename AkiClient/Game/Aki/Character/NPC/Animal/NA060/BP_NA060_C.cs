using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonSmallAnimal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA060
{
	// Token: 0x02004122 RID: 16674
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA060/BP_NA060.BP_NA060_C")]
	[UnrealStructLayout(2272, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2264)]
	public class BP_NA060_C : BP_CommonSmallAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C55B RID: 181595 RVA: 0x00A9DE2C File Offset: 0x00A9C02C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA060_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA060/BP_NA060.BP_NA060_C");
			}
			return BP_NA060_C._ClassPtr;
		}

		// Token: 0x0602C55C RID: 181596 RVA: 0x00A9DE50 File Offset: 0x00A9C050
		public BP_NA060_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA060_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C55D RID: 181597 RVA: 0x00A9DE78 File Offset: 0x00A9C078
		[NullableContext(1)]
		public BP_NA060_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA060_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007755 RID: 30549
		// (get) Token: 0x0602C55E RID: 181598 RVA: 0x00A9DEAC File Offset: 0x00A9C0AC
		// (set) Token: 0x0602C55F RID: 181599 RVA: 0x00A9DEE5 File Offset: 0x00A9C0E5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_NA060_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_NA060_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007756 RID: 30550
		// (get) Token: 0x0602C560 RID: 181600 RVA: 0x00A9DF06 File Offset: 0x00A9C106
		// (set) Token: 0x0602C561 RID: 181601 RVA: 0x00A9DF1A File Offset: 0x00A9C11A
		public unsafe UCapsuleComponent Capsule
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA060_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA060_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007757 RID: 30551
		// (get) Token: 0x0602C562 RID: 181602 RVA: 0x00A9DF2F File Offset: 0x00A9C12F
		// (set) Token: 0x0602C563 RID: 181603 RVA: 0x00A9DF43 File Offset: 0x00A9C143
		public unsafe UKuroAdjustableCapsuleComponent ROOT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroAdjustableCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA060_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA060_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x0602C564 RID: 181604 RVA: 0x00A9DF58 File Offset: 0x00A9C158
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NA060_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602C565 RID: 181605 RVA: 0x00A9DF6C File Offset: 0x00A9C16C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA060_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C566 RID: 181606 RVA: 0x00A9DF84 File Offset: 0x00A9C184
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_NA060(int EntryPoint)
		{
			BP_NA060_C.__ExecuteUbergraph_BP_NA060_FunctionParams* ptr = stackalloc BP_NA060_C.__ExecuteUbergraph_BP_NA060_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_NA060_C.__ExecuteUbergraph_BP_NA060_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NA060_C.__ExecuteUbergraph_BP_NA060_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA060_C.__ExecuteUbergraph_BP_NA060_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C567 RID: 181607 RVA: 0x00A9DFCB File Offset: 0x00A9C1CB
		protected BP_NA060_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040189A2 RID: 100770
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA060/BP_NA060.BP_NA060_C";

		// Token: 0x040189A3 RID: 100771
		private static IntPtr _ClassPtr;

		// Token: 0x040189A4 RID: 100772
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040189A5 RID: 100773
		internal new static int __PropertyOffset_0;

		// Token: 0x040189A6 RID: 100774
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040189A7 RID: 100775
		internal static int __PropertyOffset_1;

		// Token: 0x040189A8 RID: 100776
		internal static int __PropertyOffset_2;

		// Token: 0x040189A9 RID: 100777
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040189AA RID: 100778
		private static IntPtr __ExecuteUbergraph_BP_NA060_NativeFunctionPtr;

		// Token: 0x0200A43E RID: 42046
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_NA060_FunctionParams
		{
			// Token: 0x04033239 RID: 209465
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
