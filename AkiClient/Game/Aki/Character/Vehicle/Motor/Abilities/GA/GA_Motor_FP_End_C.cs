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
	// Token: 0x02003FD1 RID: 16337
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_FP_End.GA_Motor_FP_End_C")]
	[UnrealStructLayout(1528, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1528)]
	public class GA_Motor_FP_End_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602910A RID: 168202 RVA: 0x00A1FF3F File Offset: 0x00A1E13F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_FP_End_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_FP_End.GA_Motor_FP_End_C");
			}
			return GA_Motor_FP_End_C._ClassPtr;
		}

		// Token: 0x0602910B RID: 168203 RVA: 0x00A1FF64 File Offset: 0x00A1E164
		public GA_Motor_FP_End_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_FP_End_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602910C RID: 168204 RVA: 0x00A1FF8C File Offset: 0x00A1E18C
		public GA_Motor_FP_End_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_FP_End_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006550 RID: 25936
		// (get) Token: 0x0602910D RID: 168205 RVA: 0x00A1FFC0 File Offset: 0x00A1E1C0
		// (set) Token: 0x0602910E RID: 168206 RVA: 0x00A1FFF9 File Offset: 0x00A1E1F9
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_FP_End_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_FP_End_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006551 RID: 25937
		// (get) Token: 0x0602910F RID: 168207 RVA: 0x00A2001A File Offset: 0x00A1E21A
		// (set) Token: 0x06029110 RID: 168208 RVA: 0x00A2002E File Offset: 0x00A1E22E
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FP_End_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FP_End_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17006552 RID: 25938
		// (get) Token: 0x06029111 RID: 168209 RVA: 0x00A20044 File Offset: 0x00A1E244
		// (set) Token: 0x06029112 RID: 168210 RVA: 0x00A2007D File Offset: 0x00A1E27D
		public FMotorBoostConfig 摩托_喷射与超速配置
		{
			get
			{
				base.FastCheckIsValid();
				FMotorBoostConfig result;
				if ((result = this._摩托_喷射与超速配置) == null)
				{
					result = (this._摩托_喷射与超速配置 = new FMotorBoostConfig(base.NativePtr + (IntPtr)GA_Motor_FP_End_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FMotorBoostConfig.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_FP_End_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06029113 RID: 168211 RVA: 0x00A2009E File Offset: 0x00A1E29E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FP_End_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06029114 RID: 168212 RVA: 0x00A200B2 File Offset: 0x00A1E2B2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_FP_End_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06029115 RID: 168213 RVA: 0x00A200C8 File Offset: 0x00A1E2C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_FP_End_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_FP_End_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_FP_End_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FP_End_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FP_End_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06029116 RID: 168214 RVA: 0x00A20110 File Offset: 0x00A1E310
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_FP_End_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_FP_End_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_FP_End_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FP_End_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_FP_End_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029117 RID: 168215 RVA: 0x00A20158 File Offset: 0x00A1E358
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_FP_End(int EntryPoint)
		{
			GA_Motor_FP_End_C.__ExecuteUbergraph_GA_Motor_FP_End_FunctionParams* ptr = stackalloc GA_Motor_FP_End_C.__ExecuteUbergraph_GA_Motor_FP_End_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Motor_FP_End_C.__ExecuteUbergraph_GA_Motor_FP_End_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FP_End_C.__ExecuteUbergraph_GA_Motor_FP_End_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_FP_End_C.__ExecuteUbergraph_GA_Motor_FP_End_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029118 RID: 168216 RVA: 0x00A2019F File Offset: 0x00A1E39F
		protected GA_Motor_FP_End_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015BF8 RID: 89080
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_FP_End.GA_Motor_FP_End_C";

		// Token: 0x04015BF9 RID: 89081
		private static IntPtr _ClassPtr;

		// Token: 0x04015BFA RID: 89082
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015BFB RID: 89083
		internal new static int __PropertyOffset_0;

		// Token: 0x04015BFC RID: 89084
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015BFD RID: 89085
		internal new static int __PropertyOffset_1;

		// Token: 0x04015BFE RID: 89086
		internal new static int __PropertyOffset_2;

		// Token: 0x04015BFF RID: 89087
		[Nullable(2)]
		private FMotorBoostConfig _摩托_喷射与超速配置;

		// Token: 0x04015C00 RID: 89088
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015C01 RID: 89089
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015C02 RID: 89090
		private static IntPtr __ExecuteUbergraph_GA_Motor_FP_End_NativeFunctionPtr;

		// Token: 0x0200A1BF RID: 41407
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F1C RID: 208668
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1C0 RID: 41408
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __ExecuteUbergraph_GA_Motor_FP_End_FunctionParams
		{
			// Token: 0x04032F1D RID: 208669
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
