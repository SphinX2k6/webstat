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
	// Token: 0x02003FE3 RID: 16355
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_ShengXia.GA_Motor_ShengXia_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Motor_ShengXia_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060292A7 RID: 168615 RVA: 0x00A233BC File Offset: 0x00A215BC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_ShengXia_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_ShengXia.GA_Motor_ShengXia_C");
			}
			return GA_Motor_ShengXia_C._ClassPtr;
		}

		// Token: 0x060292A8 RID: 168616 RVA: 0x00A233E0 File Offset: 0x00A215E0
		public GA_Motor_ShengXia_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_ShengXia_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060292A9 RID: 168617 RVA: 0x00A23408 File Offset: 0x00A21608
		[NullableContext(1)]
		public GA_Motor_ShengXia_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_ShengXia_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006588 RID: 25992
		// (get) Token: 0x060292AA RID: 168618 RVA: 0x00A2343C File Offset: 0x00A2163C
		// (set) Token: 0x060292AB RID: 168619 RVA: 0x00A23475 File Offset: 0x00A21675
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_ShengXia_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_ShengXia_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006589 RID: 25993
		// (get) Token: 0x060292AC RID: 168620 RVA: 0x00A23496 File Offset: 0x00A21696
		// (set) Token: 0x060292AD RID: 168621 RVA: 0x00A234AA File Offset: 0x00A216AA
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_ShengXia_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_ShengXia_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x060292AE RID: 168622 RVA: 0x00A234BF File Offset: 0x00A216BF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_ShengXia_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x060292AF RID: 168623 RVA: 0x00A234D3 File Offset: 0x00A216D3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_ShengXia_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060292B0 RID: 168624 RVA: 0x00A234E8 File Offset: 0x00A216E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_ShengXia_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_ShengXia_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_ShengXia_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_ShengXia_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_ShengXia_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060292B1 RID: 168625 RVA: 0x00A23530 File Offset: 0x00A21730
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_ShengXia_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_ShengXia_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_ShengXia_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_ShengXia_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_ShengXia_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060292B2 RID: 168626 RVA: 0x00A23578 File Offset: 0x00A21778
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_ShengXia(int EntryPoint)
		{
			GA_Motor_ShengXia_C.__ExecuteUbergraph_GA_Motor_ShengXia_FunctionParams* ptr = stackalloc GA_Motor_ShengXia_C.__ExecuteUbergraph_GA_Motor_ShengXia_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Motor_ShengXia_C.__ExecuteUbergraph_GA_Motor_ShengXia_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_ShengXia_C.__ExecuteUbergraph_GA_Motor_ShengXia_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_ShengXia_C.__ExecuteUbergraph_GA_Motor_ShengXia_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060292B3 RID: 168627 RVA: 0x00A235BF File Offset: 0x00A217BF
		protected GA_Motor_ShengXia_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015D3D RID: 89405
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_ShengXia.GA_Motor_ShengXia_C";

		// Token: 0x04015D3E RID: 89406
		private static IntPtr _ClassPtr;

		// Token: 0x04015D3F RID: 89407
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015D40 RID: 89408
		internal new static int __PropertyOffset_0;

		// Token: 0x04015D41 RID: 89409
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015D42 RID: 89410
		internal new static int __PropertyOffset_1;

		// Token: 0x04015D43 RID: 89411
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015D44 RID: 89412
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015D45 RID: 89413
		private static IntPtr __ExecuteUbergraph_GA_Motor_ShengXia_NativeFunctionPtr;

		// Token: 0x0200A1E9 RID: 41449
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F46 RID: 208710
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1EA RID: 41450
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_GA_Motor_ShengXia_FunctionParams
		{
			// Token: 0x04032F47 RID: 208711
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
