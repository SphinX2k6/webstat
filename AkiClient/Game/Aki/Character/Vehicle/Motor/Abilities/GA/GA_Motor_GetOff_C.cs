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
	// Token: 0x02003FD2 RID: 16338
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_GetOff.GA_Motor_GetOff_C")]
	[UnrealStructLayout(1536, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1532)]
	public class GA_Motor_GetOff_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06029119 RID: 168217 RVA: 0x00A201A8 File Offset: 0x00A1E3A8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_GetOff_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_GetOff.GA_Motor_GetOff_C");
			}
			return GA_Motor_GetOff_C._ClassPtr;
		}

		// Token: 0x0602911A RID: 168218 RVA: 0x00A201CC File Offset: 0x00A1E3CC
		public GA_Motor_GetOff_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_GetOff_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602911B RID: 168219 RVA: 0x00A201F4 File Offset: 0x00A1E3F4
		public GA_Motor_GetOff_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_GetOff_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006553 RID: 25939
		// (get) Token: 0x0602911C RID: 168220 RVA: 0x00A20228 File Offset: 0x00A1E428
		// (set) Token: 0x0602911D RID: 168221 RVA: 0x00A20261 File Offset: 0x00A1E461
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_GetOff_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_GetOff_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006554 RID: 25940
		// (get) Token: 0x0602911E RID: 168222 RVA: 0x00A20282 File Offset: 0x00A1E482
		// (set) Token: 0x0602911F RID: 168223 RVA: 0x00A20296 File Offset: 0x00A1E496
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_GetOff_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_GetOff_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17006555 RID: 25941
		// (get) Token: 0x06029120 RID: 168224 RVA: 0x00A202AC File Offset: 0x00A1E4AC
		// (set) Token: 0x06029121 RID: 168225 RVA: 0x00A202E5 File Offset: 0x00A1E4E5
		public FMotorBoostConfig 摩托_喷射与超速配置
		{
			get
			{
				base.FastCheckIsValid();
				FMotorBoostConfig result;
				if ((result = this._摩托_喷射与超速配置) == null)
				{
					result = (this._摩托_喷射与超速配置 = new FMotorBoostConfig(base.NativePtr + (IntPtr)GA_Motor_GetOff_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FMotorBoostConfig.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_GetOff_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006556 RID: 25942
		// (get) Token: 0x06029122 RID: 168226 RVA: 0x00A20306 File Offset: 0x00A1E506
		// (set) Token: 0x06029123 RID: 168227 RVA: 0x00A20316 File Offset: 0x00A1E516
		public unsafe float 起始时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_GetOff_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_GetOff_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x06029124 RID: 168228 RVA: 0x00A20327 File Offset: 0x00A1E527
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09B6AA7AB49()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_GetOff_C.__OnTick_CF946D5D4EFE5E5564EFF09B6AA7AB49_NativeFunctionPtr, null);
		}

		// Token: 0x06029125 RID: 168229 RVA: 0x00A2033B File Offset: 0x00A1E53B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09B6AA7AB49()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_GetOff_C.__OnCancelled_CF946D5D4EFE5E5564EFF09B6AA7AB49_NativeFunctionPtr, null);
		}

		// Token: 0x06029126 RID: 168230 RVA: 0x00A2034F File Offset: 0x00A1E54F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09B6AA7AB49()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_GetOff_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09B6AA7AB49_NativeFunctionPtr, null);
		}

		// Token: 0x06029127 RID: 168231 RVA: 0x00A20363 File Offset: 0x00A1E563
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09B6AA7AB49()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_GetOff_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09B6AA7AB49_NativeFunctionPtr, null);
		}

		// Token: 0x06029128 RID: 168232 RVA: 0x00A20377 File Offset: 0x00A1E577
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09B6AA7AB49()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_GetOff_C.__OnCompleted_CF946D5D4EFE5E5564EFF09B6AA7AB49_NativeFunctionPtr, null);
		}

		// Token: 0x06029129 RID: 168233 RVA: 0x00A2038B File Offset: 0x00A1E58B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_GetOff_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602912A RID: 168234 RVA: 0x00A2039F File Offset: 0x00A1E59F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_GetOff_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602912B RID: 168235 RVA: 0x00A203B4 File Offset: 0x00A1E5B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_GetOff_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_GetOff_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_GetOff_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_GetOff_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_GetOff_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602912C RID: 168236 RVA: 0x00A203FC File Offset: 0x00A1E5FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_GetOff_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_GetOff_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_GetOff_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_GetOff_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_GetOff_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602912D RID: 168237 RVA: 0x00A20444 File Offset: 0x00A1E644
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_GetOff(int EntryPoint)
		{
			GA_Motor_GetOff_C.__ExecuteUbergraph_GA_Motor_GetOff_FunctionParams* ptr = stackalloc GA_Motor_GetOff_C.__ExecuteUbergraph_GA_Motor_GetOff_FunctionParams[(UIntPtr)431] + 15L / (long)sizeof(GA_Motor_GetOff_C.__ExecuteUbergraph_GA_Motor_GetOff_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_GetOff_C.__ExecuteUbergraph_GA_Motor_GetOff_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_GetOff_C.__ExecuteUbergraph_GA_Motor_GetOff_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602912E RID: 168238 RVA: 0x00A2048E File Offset: 0x00A1E68E
		protected GA_Motor_GetOff_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015C03 RID: 89091
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_GetOff.GA_Motor_GetOff_C";

		// Token: 0x04015C04 RID: 89092
		private static IntPtr _ClassPtr;

		// Token: 0x04015C05 RID: 89093
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015C06 RID: 89094
		internal new static int __PropertyOffset_0;

		// Token: 0x04015C07 RID: 89095
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015C08 RID: 89096
		internal new static int __PropertyOffset_1;

		// Token: 0x04015C09 RID: 89097
		internal new static int __PropertyOffset_2;

		// Token: 0x04015C0A RID: 89098
		[Nullable(2)]
		private FMotorBoostConfig _摩托_喷射与超速配置;

		// Token: 0x04015C0B RID: 89099
		internal new static int __PropertyOffset_3;

		// Token: 0x04015C0C RID: 89100
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09B6AA7AB49_NativeFunctionPtr;

		// Token: 0x04015C0D RID: 89101
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09B6AA7AB49_NativeFunctionPtr;

		// Token: 0x04015C0E RID: 89102
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09B6AA7AB49_NativeFunctionPtr;

		// Token: 0x04015C0F RID: 89103
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09B6AA7AB49_NativeFunctionPtr;

		// Token: 0x04015C10 RID: 89104
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09B6AA7AB49_NativeFunctionPtr;

		// Token: 0x04015C11 RID: 89105
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015C12 RID: 89106
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015C13 RID: 89107
		private static IntPtr __ExecuteUbergraph_GA_Motor_GetOff_NativeFunctionPtr;

		// Token: 0x0200A1C1 RID: 41409
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F1E RID: 208670
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1C2 RID: 41410
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 416)]
		protected ref struct __ExecuteUbergraph_GA_Motor_GetOff_FunctionParams
		{
			// Token: 0x04032F1F RID: 208671
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
