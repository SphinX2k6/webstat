using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.SceneInteraction.Coral
{
	// Token: 0x02003B2F RID: 15151
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/SceneInteraction/Coral/BP_CoralWindActor.BP_CoralWindActor_C")]
	[UnrealStructLayout(1848, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1844)]
	public class BP_CoralWindActor_C : ACoralWindActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020AD0 RID: 133840 RVA: 0x00933B4C File Offset: 0x00931D4C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CoralWindActor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/SceneInteraction/Coral/BP_CoralWindActor.BP_CoralWindActor_C");
			}
			return BP_CoralWindActor_C._ClassPtr;
		}

		// Token: 0x06020AD1 RID: 133841 RVA: 0x00933B70 File Offset: 0x00931D70
		public BP_CoralWindActor_C() : this(BuiltinUtils.AllocNativeUObject(BP_CoralWindActor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020AD2 RID: 133842 RVA: 0x00933B98 File Offset: 0x00931D98
		[NullableContext(1)]
		public BP_CoralWindActor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CoralWindActor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170036AB RID: 13995
		// (get) Token: 0x06020AD3 RID: 133843 RVA: 0x00933BCC File Offset: 0x00931DCC
		// (set) Token: 0x06020AD4 RID: 133844 RVA: 0x00933C05 File Offset: 0x00931E05
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CoralWindActor_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CoralWindActor_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170036AC RID: 13996
		// (get) Token: 0x06020AD5 RID: 133845 RVA: 0x00933C26 File Offset: 0x00931E26
		// (set) Token: 0x06020AD6 RID: 133846 RVA: 0x00933C36 File Offset: 0x00931E36
		public unsafe float RadiusMutiplier
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CoralWindActor_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CoralWindActor_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x06020AD7 RID: 133847 RVA: 0x00933C48 File Offset: 0x00931E48
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CoralWindActor_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CoralWindActor_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CoralWindActor_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CoralWindActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CoralWindActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020AD8 RID: 133848 RVA: 0x00933C90 File Offset: 0x00931E90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CoralWindActor_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CoralWindActor_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CoralWindActor_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CoralWindActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CoralWindActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020AD9 RID: 133849 RVA: 0x00933CD8 File Offset: 0x00931ED8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CoralWindActor(int EntryPoint)
		{
			BP_CoralWindActor_C.__ExecuteUbergraph_BP_CoralWindActor_FunctionParams* ptr = stackalloc BP_CoralWindActor_C.__ExecuteUbergraph_BP_CoralWindActor_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_CoralWindActor_C.__ExecuteUbergraph_BP_CoralWindActor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CoralWindActor_C.__ExecuteUbergraph_BP_CoralWindActor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CoralWindActor_C.__ExecuteUbergraph_BP_CoralWindActor_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020ADA RID: 133850 RVA: 0x00933D1F File Offset: 0x00931F1F
		protected BP_CoralWindActor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040105DA RID: 67034
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/SceneInteraction/Coral/BP_CoralWindActor.BP_CoralWindActor_C";

		// Token: 0x040105DB RID: 67035
		private static IntPtr _ClassPtr;

		// Token: 0x040105DC RID: 67036
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040105DD RID: 67037
		internal static int __PropertyOffset_0;

		// Token: 0x040105DE RID: 67038
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040105DF RID: 67039
		internal static int __PropertyOffset_1;

		// Token: 0x040105E0 RID: 67040
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040105E1 RID: 67041
		private static IntPtr __ExecuteUbergraph_BP_CoralWindActor_NativeFunctionPtr;

		// Token: 0x02009A10 RID: 39440
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040320FE RID: 205054
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A11 RID: 39441
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __ExecuteUbergraph_BP_CoralWindActor_FunctionParams
		{
			// Token: 0x040320FF RID: 205055
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
