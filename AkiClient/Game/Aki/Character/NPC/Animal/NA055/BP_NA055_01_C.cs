using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonSmallAnimal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA055
{
	// Token: 0x02004130 RID: 16688
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA055/BP_NA055_01.BP_NA055_01_C")]
	[UnrealStructLayout(2256, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2256)]
	public class BP_NA055_01_C : BP_CommonSmallAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C5BE RID: 181694 RVA: 0x00A9EAAC File Offset: 0x00A9CCAC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA055_01_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA055/BP_NA055_01.BP_NA055_01_C");
			}
			return BP_NA055_01_C._ClassPtr;
		}

		// Token: 0x0602C5BF RID: 181695 RVA: 0x00A9EAD0 File Offset: 0x00A9CCD0
		public BP_NA055_01_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA055_01_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C5C0 RID: 181696 RVA: 0x00A9EAF8 File Offset: 0x00A9CCF8
		public BP_NA055_01_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA055_01_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007762 RID: 30562
		// (get) Token: 0x0602C5C1 RID: 181697 RVA: 0x00A9EB2C File Offset: 0x00A9CD2C
		// (set) Token: 0x0602C5C2 RID: 181698 RVA: 0x00A9EB65 File Offset: 0x00A9CD65
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_NA055_01_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_NA055_01_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007763 RID: 30563
		// (get) Token: 0x0602C5C3 RID: 181699 RVA: 0x00A9EB86 File Offset: 0x00A9CD86
		// (set) Token: 0x0602C5C4 RID: 181700 RVA: 0x00A9EB9A File Offset: 0x00A9CD9A
		[Nullable(2)]
		public unsafe UKuroAdjustableCapsuleComponent ROOT
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroAdjustableCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA055_01_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA055_01_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602C5C5 RID: 181701 RVA: 0x00A9EBAF File Offset: 0x00A9CDAF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NA055_01_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602C5C6 RID: 181702 RVA: 0x00A9EBC3 File Offset: 0x00A9CDC3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA055_01_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C5C7 RID: 181703 RVA: 0x00A9EBD8 File Offset: 0x00A9CDD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_NA055_01(int EntryPoint)
		{
			BP_NA055_01_C.__ExecuteUbergraph_BP_NA055_01_FunctionParams* ptr = stackalloc BP_NA055_01_C.__ExecuteUbergraph_BP_NA055_01_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_NA055_01_C.__ExecuteUbergraph_BP_NA055_01_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NA055_01_C.__ExecuteUbergraph_BP_NA055_01_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA055_01_C.__ExecuteUbergraph_BP_NA055_01_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C5C8 RID: 181704 RVA: 0x00A9EC1F File Offset: 0x00A9CE1F
		protected BP_NA055_01_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040189EA RID: 100842
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA055/BP_NA055_01.BP_NA055_01_C";

		// Token: 0x040189EB RID: 100843
		private static IntPtr _ClassPtr;

		// Token: 0x040189EC RID: 100844
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040189ED RID: 100845
		internal new static int __PropertyOffset_0;

		// Token: 0x040189EE RID: 100846
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040189EF RID: 100847
		internal static int __PropertyOffset_1;

		// Token: 0x040189F0 RID: 100848
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040189F1 RID: 100849
		private static IntPtr __ExecuteUbergraph_BP_NA055_01_NativeFunctionPtr;

		// Token: 0x0200A442 RID: 42050
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_NA055_01_FunctionParams
		{
			// Token: 0x0403323D RID: 209469
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
