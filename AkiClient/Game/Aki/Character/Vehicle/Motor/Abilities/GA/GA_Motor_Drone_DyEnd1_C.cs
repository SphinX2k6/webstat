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
	// Token: 0x02003FC4 RID: 16324
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Drone_DyEnd1.GA_Motor_Drone_DyEnd1_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1488)]
	public class GA_Motor_Drone_DyEnd1_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028FAA RID: 167850 RVA: 0x00A1CF64 File Offset: 0x00A1B164
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Drone_DyEnd1_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Drone_DyEnd1.GA_Motor_Drone_DyEnd1_C");
			}
			return GA_Motor_Drone_DyEnd1_C._ClassPtr;
		}

		// Token: 0x06028FAB RID: 167851 RVA: 0x00A1CF88 File Offset: 0x00A1B188
		public GA_Motor_Drone_DyEnd1_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Drone_DyEnd1_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028FAC RID: 167852 RVA: 0x00A1CFB0 File Offset: 0x00A1B1B0
		[NullableContext(1)]
		public GA_Motor_Drone_DyEnd1_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Drone_DyEnd1_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170064F8 RID: 25848
		// (get) Token: 0x06028FAD RID: 167853 RVA: 0x00A1CFE4 File Offset: 0x00A1B1E4
		// (set) Token: 0x06028FAE RID: 167854 RVA: 0x00A1D01D File Offset: 0x00A1B21D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Drone_DyEnd1_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Drone_DyEnd1_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06028FAF RID: 167855 RVA: 0x00A1D03E File Offset: 0x00A1B23E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Drone_DyEnd1_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06028FB0 RID: 167856 RVA: 0x00A1D052 File Offset: 0x00A1B252
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Drone_DyEnd1_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06028FB1 RID: 167857 RVA: 0x00A1D068 File Offset: 0x00A1B268
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Drone_DyEnd1_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Drone_DyEnd1_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Drone_DyEnd1_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_DyEnd1_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Drone_DyEnd1_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028FB2 RID: 167858 RVA: 0x00A1D0B0 File Offset: 0x00A1B2B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Drone_DyEnd1_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Drone_DyEnd1_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Drone_DyEnd1_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_DyEnd1_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Drone_DyEnd1_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028FB3 RID: 167859 RVA: 0x00A1D0F8 File Offset: 0x00A1B2F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Drone_DyEnd1(int EntryPoint)
		{
			GA_Motor_Drone_DyEnd1_C.__ExecuteUbergraph_GA_Motor_Drone_DyEnd1_FunctionParams* ptr = stackalloc GA_Motor_Drone_DyEnd1_C.__ExecuteUbergraph_GA_Motor_Drone_DyEnd1_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(GA_Motor_Drone_DyEnd1_C.__ExecuteUbergraph_GA_Motor_Drone_DyEnd1_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_DyEnd1_C.__ExecuteUbergraph_GA_Motor_Drone_DyEnd1_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Drone_DyEnd1_C.__ExecuteUbergraph_GA_Motor_Drone_DyEnd1_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028FB4 RID: 167860 RVA: 0x00A1D13F File Offset: 0x00A1B33F
		protected GA_Motor_Drone_DyEnd1_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015B01 RID: 88833
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Drone_DyEnd1.GA_Motor_Drone_DyEnd1_C";

		// Token: 0x04015B02 RID: 88834
		private static IntPtr _ClassPtr;

		// Token: 0x04015B03 RID: 88835
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015B04 RID: 88836
		internal new static int __PropertyOffset_0;

		// Token: 0x04015B05 RID: 88837
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015B06 RID: 88838
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015B07 RID: 88839
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015B08 RID: 88840
		private static IntPtr __ExecuteUbergraph_GA_Motor_Drone_DyEnd1_NativeFunctionPtr;

		// Token: 0x0200A18C RID: 41356
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032EE0 RID: 208608
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A18D RID: 41357
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Drone_DyEnd1_FunctionParams
		{
			// Token: 0x04032EE1 RID: 208609
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
