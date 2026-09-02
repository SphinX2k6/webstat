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
	// Token: 0x020040C1 RID: 16577
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_F.GA_Super_Sprint_F_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1489)]
	public class GA_Super_Sprint_F_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B4F8 RID: 177400 RVA: 0x00A7792F File Offset: 0x00A75B2F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Super_Sprint_F_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_F.GA_Super_Sprint_F_C");
			}
			return GA_Super_Sprint_F_C._ClassPtr;
		}

		// Token: 0x0602B4F9 RID: 177401 RVA: 0x00A77954 File Offset: 0x00A75B54
		public GA_Super_Sprint_F_C() : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_F_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B4FA RID: 177402 RVA: 0x00A7797C File Offset: 0x00A75B7C
		[NullableContext(1)]
		public GA_Super_Sprint_F_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_F_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007170 RID: 29040
		// (get) Token: 0x0602B4FB RID: 177403 RVA: 0x00A779B0 File Offset: 0x00A75BB0
		// (set) Token: 0x0602B4FC RID: 177404 RVA: 0x00A779E9 File Offset: 0x00A75BE9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Super_Sprint_F_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Super_Sprint_F_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007171 RID: 29041
		// (get) Token: 0x0602B4FD RID: 177405 RVA: 0x00A77A0A File Offset: 0x00A75C0A
		// (set) Token: 0x0602B4FE RID: 177406 RVA: 0x00A77A1A File Offset: 0x00A75C1A
		public unsafe bool 刷新子弹跑
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_F_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_F_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602B4FF RID: 177407 RVA: 0x00A77A2B File Offset: 0x00A75C2B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E8128017D05()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_F_C.__OnTick_5D118C384AE61F1C80292E8128017D05_NativeFunctionPtr, null);
		}

		// Token: 0x0602B500 RID: 177408 RVA: 0x00A77A3F File Offset: 0x00A75C3F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E8128017D05()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_F_C.__OnCancelled_5D118C384AE61F1C80292E8128017D05_NativeFunctionPtr, null);
		}

		// Token: 0x0602B501 RID: 177409 RVA: 0x00A77A53 File Offset: 0x00A75C53
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E8128017D05()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_F_C.__OnInterrupted_5D118C384AE61F1C80292E8128017D05_NativeFunctionPtr, null);
		}

		// Token: 0x0602B502 RID: 177410 RVA: 0x00A77A67 File Offset: 0x00A75C67
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E8128017D05()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_F_C.__OnBlendOut_5D118C384AE61F1C80292E8128017D05_NativeFunctionPtr, null);
		}

		// Token: 0x0602B503 RID: 177411 RVA: 0x00A77A7B File Offset: 0x00A75C7B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E8128017D05()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_F_C.__OnCompleted_5D118C384AE61F1C80292E8128017D05_NativeFunctionPtr, null);
		}

		// Token: 0x0602B504 RID: 177412 RVA: 0x00A77A90 File Offset: 0x00A75C90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A3E2664B71(in FGameplayTag Tag)
		{
			GA_Super_Sprint_F_C.__Added_21071CB943CD992BF8EFD6A3E2664B71_FunctionParams* ptr = stackalloc GA_Super_Sprint_F_C.__Added_21071CB943CD992BF8EFD6A3E2664B71_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_F_C.__Added_21071CB943CD992BF8EFD6A3E2664B71_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_F_C.__Added_21071CB943CD992BF8EFD6A3E2664B71_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_F_C.__Added_21071CB943CD992BF8EFD6A3E2664B71_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B505 RID: 177413 RVA: 0x00A77ADC File Offset: 0x00A75CDC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A3015EDD8F(in FGameplayTag Tag)
		{
			GA_Super_Sprint_F_C.__Added_21071CB943CD992BF8EFD6A3015EDD8F_FunctionParams* ptr = stackalloc GA_Super_Sprint_F_C.__Added_21071CB943CD992BF8EFD6A3015EDD8F_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_F_C.__Added_21071CB943CD992BF8EFD6A3015EDD8F_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_F_C.__Added_21071CB943CD992BF8EFD6A3015EDD8F_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_F_C.__Added_21071CB943CD992BF8EFD6A3015EDD8F_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B506 RID: 177414 RVA: 0x00A77B28 File Offset: 0x00A75D28
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A36D09B45D(in FGameplayTag Tag)
		{
			GA_Super_Sprint_F_C.__Added_21071CB943CD992BF8EFD6A36D09B45D_FunctionParams* ptr = stackalloc GA_Super_Sprint_F_C.__Added_21071CB943CD992BF8EFD6A36D09B45D_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_F_C.__Added_21071CB943CD992BF8EFD6A36D09B45D_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_F_C.__Added_21071CB943CD992BF8EFD6A36D09B45D_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_F_C.__Added_21071CB943CD992BF8EFD6A36D09B45D_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B507 RID: 177415 RVA: 0x00A77B73 File Offset: 0x00A75D73
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_F_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B508 RID: 177416 RVA: 0x00A77B87 File Offset: 0x00A75D87
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_F_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B509 RID: 177417 RVA: 0x00A77B9C File Offset: 0x00A75D9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Super_Sprint_F_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_F_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_F_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_F_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_F_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B50A RID: 177418 RVA: 0x00A77BE4 File Offset: 0x00A75DE4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Super_Sprint_F_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_F_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_F_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_F_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_F_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B50B RID: 177419 RVA: 0x00A77C2C File Offset: 0x00A75E2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Super_Sprint_F(int EntryPoint)
		{
			GA_Super_Sprint_F_C.__ExecuteUbergraph_GA_Super_Sprint_F_FunctionParams* ptr = stackalloc GA_Super_Sprint_F_C.__ExecuteUbergraph_GA_Super_Sprint_F_FunctionParams[(UIntPtr)1135] + 15L / (long)sizeof(GA_Super_Sprint_F_C.__ExecuteUbergraph_GA_Super_Sprint_F_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_F_C.__ExecuteUbergraph_GA_Super_Sprint_F_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_F_C.__ExecuteUbergraph_GA_Super_Sprint_F_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B50C RID: 177420 RVA: 0x00A77C76 File Offset: 0x00A75E76
		protected GA_Super_Sprint_F_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017BBE RID: 97214
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_F.GA_Super_Sprint_F_C";

		// Token: 0x04017BBF RID: 97215
		private static IntPtr _ClassPtr;

		// Token: 0x04017BC0 RID: 97216
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017BC1 RID: 97217
		internal new static int __PropertyOffset_0;

		// Token: 0x04017BC2 RID: 97218
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017BC3 RID: 97219
		internal new static int __PropertyOffset_1;

		// Token: 0x04017BC4 RID: 97220
		private static IntPtr __OnTick_5D118C384AE61F1C80292E8128017D05_NativeFunctionPtr;

		// Token: 0x04017BC5 RID: 97221
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E8128017D05_NativeFunctionPtr;

		// Token: 0x04017BC6 RID: 97222
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E8128017D05_NativeFunctionPtr;

		// Token: 0x04017BC7 RID: 97223
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E8128017D05_NativeFunctionPtr;

		// Token: 0x04017BC8 RID: 97224
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E8128017D05_NativeFunctionPtr;

		// Token: 0x04017BC9 RID: 97225
		private static IntPtr __Added_21071CB943CD992BF8EFD6A3E2664B71_NativeFunctionPtr;

		// Token: 0x04017BCA RID: 97226
		private static IntPtr __Added_21071CB943CD992BF8EFD6A3015EDD8F_NativeFunctionPtr;

		// Token: 0x04017BCB RID: 97227
		private static IntPtr __Added_21071CB943CD992BF8EFD6A36D09B45D_NativeFunctionPtr;

		// Token: 0x04017BCC RID: 97228
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017BCD RID: 97229
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017BCE RID: 97230
		private static IntPtr __ExecuteUbergraph_GA_Super_Sprint_F_NativeFunctionPtr;

		// Token: 0x0200A360 RID: 41824
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A3E2664B71_FunctionParams
		{
			// Token: 0x0403313D RID: 209213
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A361 RID: 41825
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A3015EDD8F_FunctionParams
		{
			// Token: 0x0403313E RID: 209214
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A362 RID: 41826
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A36D09B45D_FunctionParams
		{
			// Token: 0x0403313F RID: 209215
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A363 RID: 41827
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033140 RID: 209216
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A364 RID: 41828
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1120)]
		protected ref struct __ExecuteUbergraph_GA_Super_Sprint_F_FunctionParams
		{
			// Token: 0x04033141 RID: 209217
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
