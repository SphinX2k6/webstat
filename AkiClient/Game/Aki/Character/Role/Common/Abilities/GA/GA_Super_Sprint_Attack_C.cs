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
	// Token: 0x020040BE RID: 16574
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Attack.GA_Super_Sprint_Attack_C")]
	[UnrealStructLayout(1504, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1497)]
	public class GA_Super_Sprint_Attack_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B4BB RID: 177339 RVA: 0x00A770C3 File Offset: 0x00A752C3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Super_Sprint_Attack_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Attack.GA_Super_Sprint_Attack_C");
			}
			return GA_Super_Sprint_Attack_C._ClassPtr;
		}

		// Token: 0x0602B4BC RID: 177340 RVA: 0x00A770E8 File Offset: 0x00A752E8
		public GA_Super_Sprint_Attack_C() : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_Attack_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B4BD RID: 177341 RVA: 0x00A77110 File Offset: 0x00A75310
		[NullableContext(1)]
		public GA_Super_Sprint_Attack_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_Attack_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007168 RID: 29032
		// (get) Token: 0x0602B4BE RID: 177342 RVA: 0x00A77144 File Offset: 0x00A75344
		// (set) Token: 0x0602B4BF RID: 177343 RVA: 0x00A7717D File Offset: 0x00A7537D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Super_Sprint_Attack_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Super_Sprint_Attack_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007169 RID: 29033
		// (get) Token: 0x0602B4C0 RID: 177344 RVA: 0x00A7719E File Offset: 0x00A7539E
		// (set) Token: 0x0602B4C1 RID: 177345 RVA: 0x00A771AE File Offset: 0x00A753AE
		public unsafe bool 是否被打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Attack_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Attack_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700716A RID: 29034
		// (get) Token: 0x0602B4C2 RID: 177346 RVA: 0x00A771BF File Offset: 0x00A753BF
		// (set) Token: 0x0602B4C3 RID: 177347 RVA: 0x00A771CF File Offset: 0x00A753CF
		public unsafe bool 是否空中打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Attack_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Attack_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700716B RID: 29035
		// (get) Token: 0x0602B4C4 RID: 177348 RVA: 0x00A771E0 File Offset: 0x00A753E0
		// (set) Token: 0x0602B4C5 RID: 177349 RVA: 0x00A771F0 File Offset: 0x00A753F0
		public unsafe float Block_Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Attack_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Attack_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700716C RID: 29036
		// (get) Token: 0x0602B4C6 RID: 177350 RVA: 0x00A77201 File Offset: 0x00A75401
		// (set) Token: 0x0602B4C7 RID: 177351 RVA: 0x00A77211 File Offset: 0x00A75411
		public unsafe bool 是否结束技能
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Attack_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Attack_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602B4C8 RID: 177352 RVA: 0x00A77224 File Offset: 0x00A75424
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A38029BF44(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Attack_C.__Added_21071CB943CD992BF8EFD6A38029BF44_FunctionParams* ptr = stackalloc GA_Super_Sprint_Attack_C.__Added_21071CB943CD992BF8EFD6A38029BF44_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Attack_C.__Added_21071CB943CD992BF8EFD6A38029BF44_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Attack_C.__Added_21071CB943CD992BF8EFD6A38029BF44_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Attack_C.__Added_21071CB943CD992BF8EFD6A38029BF44_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B4C9 RID: 177353 RVA: 0x00A77270 File Offset: 0x00A75470
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A39046F616(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Attack_C.__Added_21071CB943CD992BF8EFD6A39046F616_FunctionParams* ptr = stackalloc GA_Super_Sprint_Attack_C.__Added_21071CB943CD992BF8EFD6A39046F616_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Attack_C.__Added_21071CB943CD992BF8EFD6A39046F616_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Attack_C.__Added_21071CB943CD992BF8EFD6A39046F616_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Attack_C.__Added_21071CB943CD992BF8EFD6A39046F616_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B4CA RID: 177354 RVA: 0x00A772BC File Offset: 0x00A754BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A3E8E5B10F(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Attack_C.__Added_21071CB943CD992BF8EFD6A3E8E5B10F_FunctionParams* ptr = stackalloc GA_Super_Sprint_Attack_C.__Added_21071CB943CD992BF8EFD6A3E8E5B10F_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Attack_C.__Added_21071CB943CD992BF8EFD6A3E8E5B10F_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Attack_C.__Added_21071CB943CD992BF8EFD6A3E8E5B10F_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Attack_C.__Added_21071CB943CD992BF8EFD6A3E8E5B10F_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B4CB RID: 177355 RVA: 0x00A77307 File Offset: 0x00A75507
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E812A9F4E59()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Attack_C.__OnTick_5D118C384AE61F1C80292E812A9F4E59_NativeFunctionPtr, null);
		}

		// Token: 0x0602B4CC RID: 177356 RVA: 0x00A7731B File Offset: 0x00A7551B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E812A9F4E59()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Attack_C.__OnCancelled_5D118C384AE61F1C80292E812A9F4E59_NativeFunctionPtr, null);
		}

		// Token: 0x0602B4CD RID: 177357 RVA: 0x00A7732F File Offset: 0x00A7552F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E812A9F4E59()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Attack_C.__OnInterrupted_5D118C384AE61F1C80292E812A9F4E59_NativeFunctionPtr, null);
		}

		// Token: 0x0602B4CE RID: 177358 RVA: 0x00A77343 File Offset: 0x00A75543
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E812A9F4E59()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Attack_C.__OnBlendOut_5D118C384AE61F1C80292E812A9F4E59_NativeFunctionPtr, null);
		}

		// Token: 0x0602B4CF RID: 177359 RVA: 0x00A77357 File Offset: 0x00A75557
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E812A9F4E59()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Attack_C.__OnCompleted_5D118C384AE61F1C80292E812A9F4E59_NativeFunctionPtr, null);
		}

		// Token: 0x0602B4D0 RID: 177360 RVA: 0x00A7736B File Offset: 0x00A7556B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Attack_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B4D1 RID: 177361 RVA: 0x00A7737F File Offset: 0x00A7557F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Attack_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B4D2 RID: 177362 RVA: 0x00A77394 File Offset: 0x00A75594
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Super_Sprint_Attack_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_Attack_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_Attack_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Attack_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Attack_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B4D3 RID: 177363 RVA: 0x00A773DC File Offset: 0x00A755DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Super_Sprint_Attack_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_Attack_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_Attack_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Attack_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Attack_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B4D4 RID: 177364 RVA: 0x00A77424 File Offset: 0x00A75624
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Super_Sprint_Attack(int EntryPoint)
		{
			GA_Super_Sprint_Attack_C.__ExecuteUbergraph_GA_Super_Sprint_Attack_FunctionParams* ptr = stackalloc GA_Super_Sprint_Attack_C.__ExecuteUbergraph_GA_Super_Sprint_Attack_FunctionParams[(UIntPtr)1111] + 15L / (long)sizeof(GA_Super_Sprint_Attack_C.__ExecuteUbergraph_GA_Super_Sprint_Attack_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Attack_C.__ExecuteUbergraph_GA_Super_Sprint_Attack_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Attack_C.__ExecuteUbergraph_GA_Super_Sprint_Attack_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B4D5 RID: 177365 RVA: 0x00A7746E File Offset: 0x00A7566E
		protected GA_Super_Sprint_Attack_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017B8F RID: 97167
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Attack.GA_Super_Sprint_Attack_C";

		// Token: 0x04017B90 RID: 97168
		private static IntPtr _ClassPtr;

		// Token: 0x04017B91 RID: 97169
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017B92 RID: 97170
		internal new static int __PropertyOffset_0;

		// Token: 0x04017B93 RID: 97171
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017B94 RID: 97172
		internal new static int __PropertyOffset_1;

		// Token: 0x04017B95 RID: 97173
		internal new static int __PropertyOffset_2;

		// Token: 0x04017B96 RID: 97174
		internal new static int __PropertyOffset_3;

		// Token: 0x04017B97 RID: 97175
		internal static int __PropertyOffset_4;

		// Token: 0x04017B98 RID: 97176
		private static IntPtr __Added_21071CB943CD992BF8EFD6A38029BF44_NativeFunctionPtr;

		// Token: 0x04017B99 RID: 97177
		private static IntPtr __Added_21071CB943CD992BF8EFD6A39046F616_NativeFunctionPtr;

		// Token: 0x04017B9A RID: 97178
		private static IntPtr __Added_21071CB943CD992BF8EFD6A3E8E5B10F_NativeFunctionPtr;

		// Token: 0x04017B9B RID: 97179
		private static IntPtr __OnTick_5D118C384AE61F1C80292E812A9F4E59_NativeFunctionPtr;

		// Token: 0x04017B9C RID: 97180
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E812A9F4E59_NativeFunctionPtr;

		// Token: 0x04017B9D RID: 97181
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E812A9F4E59_NativeFunctionPtr;

		// Token: 0x04017B9E RID: 97182
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E812A9F4E59_NativeFunctionPtr;

		// Token: 0x04017B9F RID: 97183
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E812A9F4E59_NativeFunctionPtr;

		// Token: 0x04017BA0 RID: 97184
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017BA1 RID: 97185
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017BA2 RID: 97186
		private static IntPtr __ExecuteUbergraph_GA_Super_Sprint_Attack_NativeFunctionPtr;

		// Token: 0x0200A357 RID: 41815
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A38029BF44_FunctionParams
		{
			// Token: 0x04033134 RID: 209204
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A358 RID: 41816
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A39046F616_FunctionParams
		{
			// Token: 0x04033135 RID: 209205
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A359 RID: 41817
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A3E8E5B10F_FunctionParams
		{
			// Token: 0x04033136 RID: 209206
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A35A RID: 41818
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033137 RID: 209207
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A35B RID: 41819
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1096)]
		protected ref struct __ExecuteUbergraph_GA_Super_Sprint_Attack_FunctionParams
		{
			// Token: 0x04033138 RID: 209208
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
