using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Abilities.GA
{
	// Token: 0x020040C5 RID: 16581
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Start.GA_Super_Sprint_Start_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1489)]
	public class GA_Super_Sprint_Start_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B553 RID: 177491 RVA: 0x00A786CF File Offset: 0x00A768CF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Super_Sprint_Start_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Start.GA_Super_Sprint_Start_C");
			}
			return GA_Super_Sprint_Start_C._ClassPtr;
		}

		// Token: 0x0602B554 RID: 177492 RVA: 0x00A786F4 File Offset: 0x00A768F4
		public GA_Super_Sprint_Start_C() : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_Start_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B555 RID: 177493 RVA: 0x00A7871C File Offset: 0x00A7691C
		[NullableContext(1)]
		public GA_Super_Sprint_Start_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_Start_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700717E RID: 29054
		// (get) Token: 0x0602B556 RID: 177494 RVA: 0x00A78750 File Offset: 0x00A76950
		// (set) Token: 0x0602B557 RID: 177495 RVA: 0x00A78789 File Offset: 0x00A76989
		[Nullable(1)]
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Super_Sprint_Start_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700717F RID: 29055
		// (get) Token: 0x0602B558 RID: 177496 RVA: 0x00A787AA File Offset: 0x00A769AA
		// (set) Token: 0x0602B559 RID: 177497 RVA: 0x00A787BA File Offset: 0x00A769BA
		public unsafe bool 刷新当前子弹跑
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602B55A RID: 177498 RVA: 0x00A787CB File Offset: 0x00A769CB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E811D61BD8B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_C.__OnTick_5D118C384AE61F1C80292E811D61BD8B_NativeFunctionPtr, null);
		}

		// Token: 0x0602B55B RID: 177499 RVA: 0x00A787DF File Offset: 0x00A769DF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E811D61BD8B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_C.__OnCancelled_5D118C384AE61F1C80292E811D61BD8B_NativeFunctionPtr, null);
		}

		// Token: 0x0602B55C RID: 177500 RVA: 0x00A787F3 File Offset: 0x00A769F3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E811D61BD8B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_C.__OnInterrupted_5D118C384AE61F1C80292E811D61BD8B_NativeFunctionPtr, null);
		}

		// Token: 0x0602B55D RID: 177501 RVA: 0x00A78807 File Offset: 0x00A76A07
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E811D61BD8B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_C.__OnBlendOut_5D118C384AE61F1C80292E811D61BD8B_NativeFunctionPtr, null);
		}

		// Token: 0x0602B55E RID: 177502 RVA: 0x00A7881B File Offset: 0x00A76A1B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E811D61BD8B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_C.__OnCompleted_5D118C384AE61F1C80292E811D61BD8B_NativeFunctionPtr, null);
		}

		// Token: 0x0602B55F RID: 177503 RVA: 0x00A78830 File Offset: 0x00A76A30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A30E0EBC01(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Start_C.__Added_21071CB943CD992BF8EFD6A30E0EBC01_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_C.__Added_21071CB943CD992BF8EFD6A30E0EBC01_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Start_C.__Added_21071CB943CD992BF8EFD6A30E0EBC01_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_C.__Added_21071CB943CD992BF8EFD6A30E0EBC01_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_C.__Added_21071CB943CD992BF8EFD6A30E0EBC01_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B560 RID: 177504 RVA: 0x00A7887C File Offset: 0x00A76A7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A37029C5B8(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Start_C.__Added_21071CB943CD992BF8EFD6A37029C5B8_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_C.__Added_21071CB943CD992BF8EFD6A37029C5B8_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Start_C.__Added_21071CB943CD992BF8EFD6A37029C5B8_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_C.__Added_21071CB943CD992BF8EFD6A37029C5B8_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_C.__Added_21071CB943CD992BF8EFD6A37029C5B8_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B561 RID: 177505 RVA: 0x00A788C8 File Offset: 0x00A76AC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D3810B5C7265(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Start_C.__Removed_DB9F64004F8908FEAD99D3810B5C7265_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_C.__Removed_DB9F64004F8908FEAD99D3810B5C7265_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Start_C.__Removed_DB9F64004F8908FEAD99D3810B5C7265_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_C.__Removed_DB9F64004F8908FEAD99D3810B5C7265_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_C.__Removed_DB9F64004F8908FEAD99D3810B5C7265_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B562 RID: 177506 RVA: 0x00A78913 File Offset: 0x00A76B13
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B563 RID: 177507 RVA: 0x00A78927 File Offset: 0x00A76B27
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Start_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B564 RID: 177508 RVA: 0x00A7893C File Offset: 0x00A76B3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Super_Sprint_Start_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_Start_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B565 RID: 177509 RVA: 0x00A78984 File Offset: 0x00A76B84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Super_Sprint_Start_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_Start_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Start_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B566 RID: 177510 RVA: 0x00A789CC File Offset: 0x00A76BCC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Super_Sprint_Start(int EntryPoint)
		{
			GA_Super_Sprint_Start_C.__ExecuteUbergraph_GA_Super_Sprint_Start_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_C.__ExecuteUbergraph_GA_Super_Sprint_Start_FunctionParams[(UIntPtr)1111] + 15L / (long)sizeof(GA_Super_Sprint_Start_C.__ExecuteUbergraph_GA_Super_Sprint_Start_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_C.__ExecuteUbergraph_GA_Super_Sprint_Start_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Start_C.__ExecuteUbergraph_GA_Super_Sprint_Start_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B567 RID: 177511 RVA: 0x00A78A16 File Offset: 0x00A76C16
		protected GA_Super_Sprint_Start_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017C04 RID: 97284
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Start.GA_Super_Sprint_Start_C";

		// Token: 0x04017C05 RID: 97285
		private static IntPtr _ClassPtr;

		// Token: 0x04017C06 RID: 97286
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017C07 RID: 97287
		internal new static int __PropertyOffset_0;

		// Token: 0x04017C08 RID: 97288
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017C09 RID: 97289
		internal new static int __PropertyOffset_1;

		// Token: 0x04017C0A RID: 97290
		private static IntPtr __OnTick_5D118C384AE61F1C80292E811D61BD8B_NativeFunctionPtr;

		// Token: 0x04017C0B RID: 97291
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E811D61BD8B_NativeFunctionPtr;

		// Token: 0x04017C0C RID: 97292
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E811D61BD8B_NativeFunctionPtr;

		// Token: 0x04017C0D RID: 97293
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E811D61BD8B_NativeFunctionPtr;

		// Token: 0x04017C0E RID: 97294
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E811D61BD8B_NativeFunctionPtr;

		// Token: 0x04017C0F RID: 97295
		private static IntPtr __Added_21071CB943CD992BF8EFD6A30E0EBC01_NativeFunctionPtr;

		// Token: 0x04017C10 RID: 97296
		private static IntPtr __Added_21071CB943CD992BF8EFD6A37029C5B8_NativeFunctionPtr;

		// Token: 0x04017C11 RID: 97297
		private static IntPtr __Removed_DB9F64004F8908FEAD99D3810B5C7265_NativeFunctionPtr;

		// Token: 0x04017C12 RID: 97298
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017C13 RID: 97299
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017C14 RID: 97300
		private static IntPtr __ExecuteUbergraph_GA_Super_Sprint_Start_NativeFunctionPtr;

		// Token: 0x0200A374 RID: 41844
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A30E0EBC01_FunctionParams
		{
			// Token: 0x04033151 RID: 209233
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A375 RID: 41845
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A37029C5B8_FunctionParams
		{
			// Token: 0x04033152 RID: 209234
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A376 RID: 41846
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D3810B5C7265_FunctionParams
		{
			// Token: 0x04033153 RID: 209235
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A377 RID: 41847
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033154 RID: 209236
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A378 RID: 41848
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1096)]
		protected ref struct __ExecuteUbergraph_GA_Super_Sprint_Start_FunctionParams
		{
			// Token: 0x04033155 RID: 209237
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
