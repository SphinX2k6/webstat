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
	// Token: 0x02003FEC RID: 16364
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Wuzi.GA_Motor_WuZi_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Motor_WuZi_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06029355 RID: 168789 RVA: 0x00A24B87 File Offset: 0x00A22D87
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_WuZi_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Wuzi.GA_Motor_WuZi_C");
			}
			return GA_Motor_WuZi_C._ClassPtr;
		}

		// Token: 0x06029356 RID: 168790 RVA: 0x00A24BAC File Offset: 0x00A22DAC
		public GA_Motor_WuZi_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_WuZi_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06029357 RID: 168791 RVA: 0x00A24BD4 File Offset: 0x00A22DD4
		[NullableContext(1)]
		public GA_Motor_WuZi_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_WuZi_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170065A0 RID: 26016
		// (get) Token: 0x06029358 RID: 168792 RVA: 0x00A24C08 File Offset: 0x00A22E08
		// (set) Token: 0x06029359 RID: 168793 RVA: 0x00A24C41 File Offset: 0x00A22E41
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_WuZi_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_WuZi_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065A1 RID: 26017
		// (get) Token: 0x0602935A RID: 168794 RVA: 0x00A24C62 File Offset: 0x00A22E62
		// (set) Token: 0x0602935B RID: 168795 RVA: 0x00A24C76 File Offset: 0x00A22E76
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_WuZi_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_WuZi_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602935C RID: 168796 RVA: 0x00A24C8B File Offset: 0x00A22E8B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_WuZi_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602935D RID: 168797 RVA: 0x00A24C9F File Offset: 0x00A22E9F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_WuZi_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602935E RID: 168798 RVA: 0x00A24CB4 File Offset: 0x00A22EB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_WuZi_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_WuZi_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_WuZi_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_WuZi_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_WuZi_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602935F RID: 168799 RVA: 0x00A24CFC File Offset: 0x00A22EFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_WuZi_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_WuZi_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_WuZi_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_WuZi_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_WuZi_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029360 RID: 168800 RVA: 0x00A24D44 File Offset: 0x00A22F44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_WuZi(int EntryPoint)
		{
			GA_Motor_WuZi_C.__ExecuteUbergraph_GA_Motor_WuZi_FunctionParams* ptr = stackalloc GA_Motor_WuZi_C.__ExecuteUbergraph_GA_Motor_WuZi_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Motor_WuZi_C.__ExecuteUbergraph_GA_Motor_WuZi_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_WuZi_C.__ExecuteUbergraph_GA_Motor_WuZi_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_WuZi_C.__ExecuteUbergraph_GA_Motor_WuZi_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029361 RID: 168801 RVA: 0x00A24D8B File Offset: 0x00A22F8B
		protected GA_Motor_WuZi_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015DC7 RID: 89543
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Wuzi.GA_Motor_WuZi_C";

		// Token: 0x04015DC8 RID: 89544
		private static IntPtr _ClassPtr;

		// Token: 0x04015DC9 RID: 89545
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015DCA RID: 89546
		internal new static int __PropertyOffset_0;

		// Token: 0x04015DCB RID: 89547
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015DCC RID: 89548
		internal new static int __PropertyOffset_1;

		// Token: 0x04015DCD RID: 89549
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015DCE RID: 89550
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015DCF RID: 89551
		private static IntPtr __ExecuteUbergraph_GA_Motor_WuZi_NativeFunctionPtr;

		// Token: 0x0200A1FB RID: 41467
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F58 RID: 208728
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1FC RID: 41468
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_GA_Motor_WuZi_FunctionParams
		{
			// Token: 0x04032F59 RID: 208729
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
