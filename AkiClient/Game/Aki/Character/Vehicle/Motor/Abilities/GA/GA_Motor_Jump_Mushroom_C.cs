using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Abilities.GA
{
	// Token: 0x02003FD6 RID: 16342
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Jump_Mushroom.GA_Motor_Jump_Mushroom_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Motor_Jump_Mushroom_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602916F RID: 168303 RVA: 0x00A20CBB File Offset: 0x00A1EEBB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Jump_Mushroom_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Jump_Mushroom.GA_Motor_Jump_Mushroom_C");
			}
			return GA_Motor_Jump_Mushroom_C._ClassPtr;
		}

		// Token: 0x06029170 RID: 168304 RVA: 0x00A20CE0 File Offset: 0x00A1EEE0
		public GA_Motor_Jump_Mushroom_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Jump_Mushroom_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06029171 RID: 168305 RVA: 0x00A20D08 File Offset: 0x00A1EF08
		[NullableContext(1)]
		public GA_Motor_Jump_Mushroom_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Jump_Mushroom_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700655D RID: 25949
		// (get) Token: 0x06029172 RID: 168306 RVA: 0x00A20D3C File Offset: 0x00A1EF3C
		// (set) Token: 0x06029173 RID: 168307 RVA: 0x00A20D75 File Offset: 0x00A1EF75
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Jump_Mushroom_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Jump_Mushroom_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700655E RID: 25950
		// (get) Token: 0x06029174 RID: 168308 RVA: 0x00A20D96 File Offset: 0x00A1EF96
		// (set) Token: 0x06029175 RID: 168309 RVA: 0x00A20DAA File Offset: 0x00A1EFAA
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Jump_Mushroom_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Jump_Mushroom_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06029176 RID: 168310 RVA: 0x00A20DC0 File Offset: 0x00A1EFC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetMontageTimeScale(ref float TimeScale)
		{
			GA_Motor_Jump_Mushroom_C.__GetMontageTimeScale_FunctionParams* ptr = stackalloc GA_Motor_Jump_Mushroom_C.__GetMontageTimeScale_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(GA_Motor_Jump_Mushroom_C.__GetMontageTimeScale_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Jump_Mushroom_C.__GetMontageTimeScale_NativeFunctionPtr, (void*)ptr, 1);
			ptr->TimeScale = TimeScale;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_Mushroom_C.__GetMontageTimeScale_NativeFunctionPtr, (void*)ptr);
			TimeScale = ptr->TimeScale;
		}

		// Token: 0x06029177 RID: 168311 RVA: 0x00A20E0F File Offset: 0x00A1F00F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09B3563EE78()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_Mushroom_C.__OnTick_CF946D5D4EFE5E5564EFF09B3563EE78_NativeFunctionPtr, null);
		}

		// Token: 0x06029178 RID: 168312 RVA: 0x00A20E23 File Offset: 0x00A1F023
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09B3563EE78()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_Mushroom_C.__OnCancelled_CF946D5D4EFE5E5564EFF09B3563EE78_NativeFunctionPtr, null);
		}

		// Token: 0x06029179 RID: 168313 RVA: 0x00A20E37 File Offset: 0x00A1F037
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09B3563EE78()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_Mushroom_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09B3563EE78_NativeFunctionPtr, null);
		}

		// Token: 0x0602917A RID: 168314 RVA: 0x00A20E4B File Offset: 0x00A1F04B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09B3563EE78()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_Mushroom_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09B3563EE78_NativeFunctionPtr, null);
		}

		// Token: 0x0602917B RID: 168315 RVA: 0x00A20E5F File Offset: 0x00A1F05F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09B3563EE78()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_Mushroom_C.__OnCompleted_CF946D5D4EFE5E5564EFF09B3563EE78_NativeFunctionPtr, null);
		}

		// Token: 0x0602917C RID: 168316 RVA: 0x00A20E73 File Offset: 0x00A1F073
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_Mushroom_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602917D RID: 168317 RVA: 0x00A20E87 File Offset: 0x00A1F087
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Jump_Mushroom_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602917E RID: 168318 RVA: 0x00A20E9C File Offset: 0x00A1F09C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Jump_Mushroom_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Jump_Mushroom_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Jump_Mushroom_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Jump_Mushroom_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_Mushroom_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602917F RID: 168319 RVA: 0x00A20EE4 File Offset: 0x00A1F0E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Jump_Mushroom_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Jump_Mushroom_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Jump_Mushroom_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Jump_Mushroom_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Jump_Mushroom_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029180 RID: 168320 RVA: 0x00A20F2C File Offset: 0x00A1F12C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Jump_Mushroom(int EntryPoint)
		{
			GA_Motor_Jump_Mushroom_C.__ExecuteUbergraph_GA_Motor_Jump_Mushroom_FunctionParams* ptr = stackalloc GA_Motor_Jump_Mushroom_C.__ExecuteUbergraph_GA_Motor_Jump_Mushroom_FunctionParams[(UIntPtr)383] + 15L / (long)sizeof(GA_Motor_Jump_Mushroom_C.__ExecuteUbergraph_GA_Motor_Jump_Mushroom_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Jump_Mushroom_C.__ExecuteUbergraph_GA_Motor_Jump_Mushroom_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Jump_Mushroom_C.__ExecuteUbergraph_GA_Motor_Jump_Mushroom_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029181 RID: 168321 RVA: 0x00A20F76 File Offset: 0x00A1F176
		protected GA_Motor_Jump_Mushroom_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015C48 RID: 89160
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Jump_Mushroom.GA_Motor_Jump_Mushroom_C";

		// Token: 0x04015C49 RID: 89161
		private static IntPtr _ClassPtr;

		// Token: 0x04015C4A RID: 89162
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015C4B RID: 89163
		internal new static int __PropertyOffset_0;

		// Token: 0x04015C4C RID: 89164
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015C4D RID: 89165
		internal new static int __PropertyOffset_1;

		// Token: 0x04015C4E RID: 89166
		private static IntPtr __GetMontageTimeScale_NativeFunctionPtr;

		// Token: 0x04015C4F RID: 89167
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09B3563EE78_NativeFunctionPtr;

		// Token: 0x04015C50 RID: 89168
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09B3563EE78_NativeFunctionPtr;

		// Token: 0x04015C51 RID: 89169
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09B3563EE78_NativeFunctionPtr;

		// Token: 0x04015C52 RID: 89170
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09B3563EE78_NativeFunctionPtr;

		// Token: 0x04015C53 RID: 89171
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09B3563EE78_NativeFunctionPtr;

		// Token: 0x04015C54 RID: 89172
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015C55 RID: 89173
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015C56 RID: 89174
		private static IntPtr __ExecuteUbergraph_GA_Motor_Jump_Mushroom_NativeFunctionPtr;

		// Token: 0x0200A1C9 RID: 41417
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __GetMontageTimeScale_FunctionParams
		{
			// Token: 0x04032F26 RID: 208678
			[FieldOffset(0)]
			public float TimeScale;
		}

		// Token: 0x0200A1CA RID: 41418
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F27 RID: 208679
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1CB RID: 41419
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 368)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Jump_Mushroom_FunctionParams
		{
			// Token: 0x04032F28 RID: 208680
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
