using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.Monster.Common.Abilities.GA;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA058.Ability
{
	// Token: 0x0200412A RID: 16682
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA058/Ability/GA_SetHateTargetFromBB.GA_SetHateTargetFromBB_C")]
	[UnrealStructLayout(1512, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1512)]
	public class GA_SetHateTargetFromBB_C : GA_Monster_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C59C RID: 181660 RVA: 0x00A9E648 File Offset: 0x00A9C848
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_SetHateTargetFromBB_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA058/Ability/GA_SetHateTargetFromBB.GA_SetHateTargetFromBB_C");
			}
			return GA_SetHateTargetFromBB_C._ClassPtr;
		}

		// Token: 0x0602C59D RID: 181661 RVA: 0x00A9E66C File Offset: 0x00A9C86C
		public GA_SetHateTargetFromBB_C() : this(BuiltinUtils.AllocNativeUObject(GA_SetHateTargetFromBB_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C59E RID: 181662 RVA: 0x00A9E694 File Offset: 0x00A9C894
		public GA_SetHateTargetFromBB_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_SetHateTargetFromBB_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007761 RID: 30561
		// (get) Token: 0x0602C59F RID: 181663 RVA: 0x00A9E6C8 File Offset: 0x00A9C8C8
		// (set) Token: 0x0602C5A0 RID: 181664 RVA: 0x00A9E701 File Offset: 0x00A9C901
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_SetHateTargetFromBB_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_SetHateTargetFromBB_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602C5A1 RID: 181665 RVA: 0x00A9E722 File Offset: 0x00A9C922
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E8186A81D26()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SetHateTargetFromBB_C.__OnTick_5D118C384AE61F1C80292E8186A81D26_NativeFunctionPtr, null);
		}

		// Token: 0x0602C5A2 RID: 181666 RVA: 0x00A9E736 File Offset: 0x00A9C936
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E8186A81D26()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SetHateTargetFromBB_C.__OnCancelled_5D118C384AE61F1C80292E8186A81D26_NativeFunctionPtr, null);
		}

		// Token: 0x0602C5A3 RID: 181667 RVA: 0x00A9E74A File Offset: 0x00A9C94A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E8186A81D26()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SetHateTargetFromBB_C.__OnInterrupted_5D118C384AE61F1C80292E8186A81D26_NativeFunctionPtr, null);
		}

		// Token: 0x0602C5A4 RID: 181668 RVA: 0x00A9E75E File Offset: 0x00A9C95E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E8186A81D26()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SetHateTargetFromBB_C.__OnBlendOut_5D118C384AE61F1C80292E8186A81D26_NativeFunctionPtr, null);
		}

		// Token: 0x0602C5A5 RID: 181669 RVA: 0x00A9E772 File Offset: 0x00A9C972
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E8186A81D26()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SetHateTargetFromBB_C.__OnCompleted_5D118C384AE61F1C80292E8186A81D26_NativeFunctionPtr, null);
		}

		// Token: 0x0602C5A6 RID: 181670 RVA: 0x00A9E786 File Offset: 0x00A9C986
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SetHateTargetFromBB_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602C5A7 RID: 181671 RVA: 0x00A9E79A File Offset: 0x00A9C99A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_SetHateTargetFromBB_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C5A8 RID: 181672 RVA: 0x00A9E7B0 File Offset: 0x00A9C9B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_SetHateTargetFromBB(int EntryPoint)
		{
			GA_SetHateTargetFromBB_C.__ExecuteUbergraph_GA_SetHateTargetFromBB_FunctionParams* ptr = stackalloc GA_SetHateTargetFromBB_C.__ExecuteUbergraph_GA_SetHateTargetFromBB_FunctionParams[(UIntPtr)815] + 15L / (long)sizeof(GA_SetHateTargetFromBB_C.__ExecuteUbergraph_GA_SetHateTargetFromBB_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_SetHateTargetFromBB_C.__ExecuteUbergraph_GA_SetHateTargetFromBB_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_SetHateTargetFromBB_C.__ExecuteUbergraph_GA_SetHateTargetFromBB_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C5A9 RID: 181673 RVA: 0x00A9E7FA File Offset: 0x00A9C9FA
		protected GA_SetHateTargetFromBB_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040189CF RID: 100815
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA058/Ability/GA_SetHateTargetFromBB.GA_SetHateTargetFromBB_C";

		// Token: 0x040189D0 RID: 100816
		private static IntPtr _ClassPtr;

		// Token: 0x040189D1 RID: 100817
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040189D2 RID: 100818
		internal new static int __PropertyOffset_0;

		// Token: 0x040189D3 RID: 100819
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040189D4 RID: 100820
		private static IntPtr __OnTick_5D118C384AE61F1C80292E8186A81D26_NativeFunctionPtr;

		// Token: 0x040189D5 RID: 100821
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E8186A81D26_NativeFunctionPtr;

		// Token: 0x040189D6 RID: 100822
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E8186A81D26_NativeFunctionPtr;

		// Token: 0x040189D7 RID: 100823
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E8186A81D26_NativeFunctionPtr;

		// Token: 0x040189D8 RID: 100824
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E8186A81D26_NativeFunctionPtr;

		// Token: 0x040189D9 RID: 100825
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x040189DA RID: 100826
		private static IntPtr __ExecuteUbergraph_GA_SetHateTargetFromBB_NativeFunctionPtr;

		// Token: 0x0200A441 RID: 42049
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 800)]
		protected ref struct __ExecuteUbergraph_GA_SetHateTargetFromBB_FunctionParams
		{
			// Token: 0x0403323C RID: 209468
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
