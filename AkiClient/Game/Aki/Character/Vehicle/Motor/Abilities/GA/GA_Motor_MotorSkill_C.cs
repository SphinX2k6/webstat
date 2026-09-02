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
	// Token: 0x02003FDD RID: 16349
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_MotorSkill.GA_Motor_MotorSkill_C")]
	[UnrealStructLayout(1552, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1548)]
	public class GA_Motor_MotorSkill_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602922A RID: 168490 RVA: 0x00A2236B File Offset: 0x00A2056B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_MotorSkill_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_MotorSkill.GA_Motor_MotorSkill_C");
			}
			return GA_Motor_MotorSkill_C._ClassPtr;
		}

		// Token: 0x0602922B RID: 168491 RVA: 0x00A22390 File Offset: 0x00A20590
		public GA_Motor_MotorSkill_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_MotorSkill_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602922C RID: 168492 RVA: 0x00A223B8 File Offset: 0x00A205B8
		public GA_Motor_MotorSkill_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_MotorSkill_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006573 RID: 25971
		// (get) Token: 0x0602922D RID: 168493 RVA: 0x00A223EC File Offset: 0x00A205EC
		// (set) Token: 0x0602922E RID: 168494 RVA: 0x00A22425 File Offset: 0x00A20625
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_MotorSkill_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_MotorSkill_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006574 RID: 25972
		// (get) Token: 0x0602922F RID: 168495 RVA: 0x00A22446 File Offset: 0x00A20646
		// (set) Token: 0x06029230 RID: 168496 RVA: 0x00A2245A File Offset: 0x00A2065A
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_MotorSkill_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_MotorSkill_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17006575 RID: 25973
		// (get) Token: 0x06029231 RID: 168497 RVA: 0x00A22470 File Offset: 0x00A20670
		// (set) Token: 0x06029232 RID: 168498 RVA: 0x00A224A9 File Offset: 0x00A206A9
		public FMotorBoostConfig 摩托_喷射与超速配置
		{
			get
			{
				base.FastCheckIsValid();
				FMotorBoostConfig result;
				if ((result = this._摩托_喷射与超速配置) == null)
				{
					result = (this._摩托_喷射与超速配置 = new FMotorBoostConfig(base.NativePtr + (IntPtr)GA_Motor_MotorSkill_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FMotorBoostConfig.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_MotorSkill_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006576 RID: 25974
		// (get) Token: 0x06029233 RID: 168499 RVA: 0x00A224CA File Offset: 0x00A206CA
		// (set) Token: 0x06029234 RID: 168500 RVA: 0x00A224DA File Offset: 0x00A206DA
		public unsafe float 起始时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_MotorSkill_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_MotorSkill_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17006577 RID: 25975
		// (get) Token: 0x06029235 RID: 168501 RVA: 0x00A224EB File Offset: 0x00A206EB
		// (set) Token: 0x06029236 RID: 168502 RVA: 0x00A224FF File Offset: 0x00A206FF
		[Nullable(2)]
		public unsafe TsBaseCharacter 驾驶员
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_MotorSkill_C.__PropertyOffset_4);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_MotorSkill_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17006578 RID: 25976
		// (get) Token: 0x06029237 RID: 168503 RVA: 0x00A22514 File Offset: 0x00A20714
		// (set) Token: 0x06029238 RID: 168504 RVA: 0x00A22524 File Offset: 0x00A20724
		public unsafe float 起始Yaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_MotorSkill_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_MotorSkill_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x06029239 RID: 168505 RVA: 0x00A22535 File Offset: 0x00A20735
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 添加BUFF()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_MotorSkill_C.__添加BUFF_NativeFunctionPtr, null);
		}

		// Token: 0x0602923A RID: 168506 RVA: 0x00A22549 File Offset: 0x00A20749
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09BD28C5FDC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_MotorSkill_C.__OnTick_CF946D5D4EFE5E5564EFF09BD28C5FDC_NativeFunctionPtr, null);
		}

		// Token: 0x0602923B RID: 168507 RVA: 0x00A2255D File Offset: 0x00A2075D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09BD28C5FDC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_MotorSkill_C.__OnCancelled_CF946D5D4EFE5E5564EFF09BD28C5FDC_NativeFunctionPtr, null);
		}

		// Token: 0x0602923C RID: 168508 RVA: 0x00A22571 File Offset: 0x00A20771
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09BD28C5FDC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_MotorSkill_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09BD28C5FDC_NativeFunctionPtr, null);
		}

		// Token: 0x0602923D RID: 168509 RVA: 0x00A22585 File Offset: 0x00A20785
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09BD28C5FDC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_MotorSkill_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09BD28C5FDC_NativeFunctionPtr, null);
		}

		// Token: 0x0602923E RID: 168510 RVA: 0x00A22599 File Offset: 0x00A20799
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09BD28C5FDC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_MotorSkill_C.__OnCompleted_CF946D5D4EFE5E5564EFF09BD28C5FDC_NativeFunctionPtr, null);
		}

		// Token: 0x0602923F RID: 168511 RVA: 0x00A225AD File Offset: 0x00A207AD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09BE8A81557()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_MotorSkill_C.__OnTick_CF946D5D4EFE5E5564EFF09BE8A81557_NativeFunctionPtr, null);
		}

		// Token: 0x06029240 RID: 168512 RVA: 0x00A225C1 File Offset: 0x00A207C1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09BE8A81557()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_MotorSkill_C.__OnCancelled_CF946D5D4EFE5E5564EFF09BE8A81557_NativeFunctionPtr, null);
		}

		// Token: 0x06029241 RID: 168513 RVA: 0x00A225D5 File Offset: 0x00A207D5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09BE8A81557()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_MotorSkill_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09BE8A81557_NativeFunctionPtr, null);
		}

		// Token: 0x06029242 RID: 168514 RVA: 0x00A225E9 File Offset: 0x00A207E9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09BE8A81557()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_MotorSkill_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09BE8A81557_NativeFunctionPtr, null);
		}

		// Token: 0x06029243 RID: 168515 RVA: 0x00A225FD File Offset: 0x00A207FD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09BE8A81557()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_MotorSkill_C.__OnCompleted_CF946D5D4EFE5E5564EFF09BE8A81557_NativeFunctionPtr, null);
		}

		// Token: 0x06029244 RID: 168516 RVA: 0x00A22611 File Offset: 0x00A20811
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_MotorSkill_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06029245 RID: 168517 RVA: 0x00A22625 File Offset: 0x00A20825
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_MotorSkill_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06029246 RID: 168518 RVA: 0x00A2263C File Offset: 0x00A2083C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_MotorSkill_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_MotorSkill_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_MotorSkill_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_MotorSkill_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_MotorSkill_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06029247 RID: 168519 RVA: 0x00A22684 File Offset: 0x00A20884
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_MotorSkill_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_MotorSkill_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_MotorSkill_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_MotorSkill_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_MotorSkill_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029248 RID: 168520 RVA: 0x00A226CC File Offset: 0x00A208CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_MotorSkill(int EntryPoint)
		{
			GA_Motor_MotorSkill_C.__ExecuteUbergraph_GA_Motor_MotorSkill_FunctionParams* ptr = stackalloc GA_Motor_MotorSkill_C.__ExecuteUbergraph_GA_Motor_MotorSkill_FunctionParams[(UIntPtr)1247] + 15L / (long)sizeof(GA_Motor_MotorSkill_C.__ExecuteUbergraph_GA_Motor_MotorSkill_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_MotorSkill_C.__ExecuteUbergraph_GA_Motor_MotorSkill_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_MotorSkill_C.__ExecuteUbergraph_GA_Motor_MotorSkill_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029249 RID: 168521 RVA: 0x00A22716 File Offset: 0x00A20916
		protected GA_Motor_MotorSkill_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015CE0 RID: 89312
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_MotorSkill.GA_Motor_MotorSkill_C";

		// Token: 0x04015CE1 RID: 89313
		private static IntPtr _ClassPtr;

		// Token: 0x04015CE2 RID: 89314
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015CE3 RID: 89315
		internal new static int __PropertyOffset_0;

		// Token: 0x04015CE4 RID: 89316
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015CE5 RID: 89317
		internal new static int __PropertyOffset_1;

		// Token: 0x04015CE6 RID: 89318
		internal new static int __PropertyOffset_2;

		// Token: 0x04015CE7 RID: 89319
		[Nullable(2)]
		private FMotorBoostConfig _摩托_喷射与超速配置;

		// Token: 0x04015CE8 RID: 89320
		internal new static int __PropertyOffset_3;

		// Token: 0x04015CE9 RID: 89321
		internal static int __PropertyOffset_4;

		// Token: 0x04015CEA RID: 89322
		internal static int __PropertyOffset_5;

		// Token: 0x04015CEB RID: 89323
		private static IntPtr __添加BUFF_NativeFunctionPtr;

		// Token: 0x04015CEC RID: 89324
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09BD28C5FDC_NativeFunctionPtr;

		// Token: 0x04015CED RID: 89325
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09BD28C5FDC_NativeFunctionPtr;

		// Token: 0x04015CEE RID: 89326
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09BD28C5FDC_NativeFunctionPtr;

		// Token: 0x04015CEF RID: 89327
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09BD28C5FDC_NativeFunctionPtr;

		// Token: 0x04015CF0 RID: 89328
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09BD28C5FDC_NativeFunctionPtr;

		// Token: 0x04015CF1 RID: 89329
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09BE8A81557_NativeFunctionPtr;

		// Token: 0x04015CF2 RID: 89330
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09BE8A81557_NativeFunctionPtr;

		// Token: 0x04015CF3 RID: 89331
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09BE8A81557_NativeFunctionPtr;

		// Token: 0x04015CF4 RID: 89332
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09BE8A81557_NativeFunctionPtr;

		// Token: 0x04015CF5 RID: 89333
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09BE8A81557_NativeFunctionPtr;

		// Token: 0x04015CF6 RID: 89334
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015CF7 RID: 89335
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015CF8 RID: 89336
		private static IntPtr __ExecuteUbergraph_GA_Motor_MotorSkill_NativeFunctionPtr;

		// Token: 0x0200A1DC RID: 41436
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F39 RID: 208697
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1DD RID: 41437
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1232)]
		protected ref struct __ExecuteUbergraph_GA_Motor_MotorSkill_FunctionParams
		{
			// Token: 0x04032F3A RID: 208698
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
