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
	// Token: 0x02003FE4 RID: 16356
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_ShowVision.GA_Motor_ShowVision_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Motor_ShowVision_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060292B4 RID: 168628 RVA: 0x00A235C8 File Offset: 0x00A217C8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_ShowVision_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_ShowVision.GA_Motor_ShowVision_C");
			}
			return GA_Motor_ShowVision_C._ClassPtr;
		}

		// Token: 0x060292B5 RID: 168629 RVA: 0x00A235EC File Offset: 0x00A217EC
		public GA_Motor_ShowVision_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_ShowVision_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060292B6 RID: 168630 RVA: 0x00A23614 File Offset: 0x00A21814
		[NullableContext(1)]
		public GA_Motor_ShowVision_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_ShowVision_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700658A RID: 25994
		// (get) Token: 0x060292B7 RID: 168631 RVA: 0x00A23648 File Offset: 0x00A21848
		// (set) Token: 0x060292B8 RID: 168632 RVA: 0x00A23681 File Offset: 0x00A21881
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_ShowVision_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_ShowVision_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700658B RID: 25995
		// (get) Token: 0x060292B9 RID: 168633 RVA: 0x00A236A2 File Offset: 0x00A218A2
		// (set) Token: 0x060292BA RID: 168634 RVA: 0x00A236B6 File Offset: 0x00A218B6
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_ShowVision_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_ShowVision_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x060292BB RID: 168635 RVA: 0x00A236CB File Offset: 0x00A218CB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_ShowVision_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x060292BC RID: 168636 RVA: 0x00A236DF File Offset: 0x00A218DF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_ShowVision_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060292BD RID: 168637 RVA: 0x00A236F4 File Offset: 0x00A218F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_ShowVision_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_ShowVision_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_ShowVision_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_ShowVision_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_ShowVision_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060292BE RID: 168638 RVA: 0x00A2373C File Offset: 0x00A2193C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_ShowVision_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_ShowVision_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_ShowVision_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_ShowVision_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_ShowVision_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060292BF RID: 168639 RVA: 0x00A23784 File Offset: 0x00A21984
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_ShowVision(int EntryPoint)
		{
			GA_Motor_ShowVision_C.__ExecuteUbergraph_GA_Motor_ShowVision_FunctionParams* ptr = stackalloc GA_Motor_ShowVision_C.__ExecuteUbergraph_GA_Motor_ShowVision_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Motor_ShowVision_C.__ExecuteUbergraph_GA_Motor_ShowVision_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_ShowVision_C.__ExecuteUbergraph_GA_Motor_ShowVision_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_ShowVision_C.__ExecuteUbergraph_GA_Motor_ShowVision_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060292C0 RID: 168640 RVA: 0x00A237CB File Offset: 0x00A219CB
		protected GA_Motor_ShowVision_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015D46 RID: 89414
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_ShowVision.GA_Motor_ShowVision_C";

		// Token: 0x04015D47 RID: 89415
		private static IntPtr _ClassPtr;

		// Token: 0x04015D48 RID: 89416
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015D49 RID: 89417
		internal new static int __PropertyOffset_0;

		// Token: 0x04015D4A RID: 89418
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015D4B RID: 89419
		internal new static int __PropertyOffset_1;

		// Token: 0x04015D4C RID: 89420
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015D4D RID: 89421
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015D4E RID: 89422
		private static IntPtr __ExecuteUbergraph_GA_Motor_ShowVision_NativeFunctionPtr;

		// Token: 0x0200A1EB RID: 41451
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F48 RID: 208712
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1EC RID: 41452
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_GA_Motor_ShowVision_FunctionParams
		{
			// Token: 0x04032F49 RID: 208713
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
