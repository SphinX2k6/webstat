using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonSmallAnimal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA061
{
	// Token: 0x0200411F RID: 16671
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA061/BP_NA06102.BP_NA06102_C")]
	[UnrealStructLayout(2256, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2256)]
	public class BP_NA06102_C : BP_CommonSmallAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C541 RID: 181569 RVA: 0x00A9DAAC File Offset: 0x00A9BCAC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA06102_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA061/BP_NA06102.BP_NA06102_C");
			}
			return BP_NA06102_C._ClassPtr;
		}

		// Token: 0x0602C542 RID: 181570 RVA: 0x00A9DAD0 File Offset: 0x00A9BCD0
		public BP_NA06102_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA06102_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C543 RID: 181571 RVA: 0x00A9DAF8 File Offset: 0x00A9BCF8
		public BP_NA06102_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA06102_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007751 RID: 30545
		// (get) Token: 0x0602C544 RID: 181572 RVA: 0x00A9DB2C File Offset: 0x00A9BD2C
		// (set) Token: 0x0602C545 RID: 181573 RVA: 0x00A9DB65 File Offset: 0x00A9BD65
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_NA06102_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_NA06102_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007752 RID: 30546
		// (get) Token: 0x0602C546 RID: 181574 RVA: 0x00A9DB86 File Offset: 0x00A9BD86
		// (set) Token: 0x0602C547 RID: 181575 RVA: 0x00A9DB9A File Offset: 0x00A9BD9A
		[Nullable(2)]
		public unsafe UKuroAdjustableCapsuleComponent ROOT
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroAdjustableCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA06102_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA06102_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602C548 RID: 181576 RVA: 0x00A9DBAF File Offset: 0x00A9BDAF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NA06102_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602C549 RID: 181577 RVA: 0x00A9DBC3 File Offset: 0x00A9BDC3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA06102_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C54A RID: 181578 RVA: 0x00A9DBD8 File Offset: 0x00A9BDD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_NA06102(int EntryPoint)
		{
			BP_NA06102_C.__ExecuteUbergraph_BP_NA06102_FunctionParams* ptr = stackalloc BP_NA06102_C.__ExecuteUbergraph_BP_NA06102_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_NA06102_C.__ExecuteUbergraph_BP_NA06102_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NA06102_C.__ExecuteUbergraph_BP_NA06102_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA06102_C.__ExecuteUbergraph_BP_NA06102_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C54B RID: 181579 RVA: 0x00A9DC1F File Offset: 0x00A9BE1F
		protected BP_NA06102_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401898F RID: 100751
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA061/BP_NA06102.BP_NA06102_C";

		// Token: 0x04018990 RID: 100752
		private static IntPtr _ClassPtr;

		// Token: 0x04018991 RID: 100753
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018992 RID: 100754
		internal new static int __PropertyOffset_0;

		// Token: 0x04018993 RID: 100755
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04018994 RID: 100756
		internal static int __PropertyOffset_1;

		// Token: 0x04018995 RID: 100757
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04018996 RID: 100758
		private static IntPtr __ExecuteUbergraph_BP_NA06102_NativeFunctionPtr;

		// Token: 0x0200A43C RID: 42044
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_NA06102_FunctionParams
		{
			// Token: 0x04033237 RID: 209463
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
