using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonSmallAnimal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA062
{
	// Token: 0x0200411B RID: 16667
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA062/BP_NA062.BP_NA062_C")]
	[UnrealStructLayout(2256, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2256)]
	public class BP_NA062_C : BP_CommonSmallAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C528 RID: 181544 RVA: 0x00A9D76C File Offset: 0x00A9B96C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA062_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA062/BP_NA062.BP_NA062_C");
			}
			return BP_NA062_C._ClassPtr;
		}

		// Token: 0x0602C529 RID: 181545 RVA: 0x00A9D790 File Offset: 0x00A9B990
		public BP_NA062_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA062_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C52A RID: 181546 RVA: 0x00A9D7B8 File Offset: 0x00A9B9B8
		public BP_NA062_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA062_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700774E RID: 30542
		// (get) Token: 0x0602C52B RID: 181547 RVA: 0x00A9D7EC File Offset: 0x00A9B9EC
		// (set) Token: 0x0602C52C RID: 181548 RVA: 0x00A9D825 File Offset: 0x00A9BA25
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_NA062_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_NA062_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700774F RID: 30543
		// (get) Token: 0x0602C52D RID: 181549 RVA: 0x00A9D846 File Offset: 0x00A9BA46
		// (set) Token: 0x0602C52E RID: 181550 RVA: 0x00A9D85A File Offset: 0x00A9BA5A
		[Nullable(2)]
		public unsafe UKuroAdjustableCapsuleComponent ROOT
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroAdjustableCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA062_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA062_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602C52F RID: 181551 RVA: 0x00A9D86F File Offset: 0x00A9BA6F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NA062_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602C530 RID: 181552 RVA: 0x00A9D883 File Offset: 0x00A9BA83
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA062_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C531 RID: 181553 RVA: 0x00A9D898 File Offset: 0x00A9BA98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_NA062(int EntryPoint)
		{
			BP_NA062_C.__ExecuteUbergraph_BP_NA062_FunctionParams* ptr = stackalloc BP_NA062_C.__ExecuteUbergraph_BP_NA062_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_NA062_C.__ExecuteUbergraph_BP_NA062_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NA062_C.__ExecuteUbergraph_BP_NA062_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA062_C.__ExecuteUbergraph_BP_NA062_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C532 RID: 181554 RVA: 0x00A9D8DF File Offset: 0x00A9BADF
		protected BP_NA062_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401897D RID: 100733
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA062/BP_NA062.BP_NA062_C";

		// Token: 0x0401897E RID: 100734
		private static IntPtr _ClassPtr;

		// Token: 0x0401897F RID: 100735
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018980 RID: 100736
		internal new static int __PropertyOffset_0;

		// Token: 0x04018981 RID: 100737
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04018982 RID: 100738
		internal static int __PropertyOffset_1;

		// Token: 0x04018983 RID: 100739
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04018984 RID: 100740
		private static IntPtr __ExecuteUbergraph_BP_NA062_NativeFunctionPtr;

		// Token: 0x0200A43B RID: 42043
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_NA062_FunctionParams
		{
			// Token: 0x04033236 RID: 209462
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
