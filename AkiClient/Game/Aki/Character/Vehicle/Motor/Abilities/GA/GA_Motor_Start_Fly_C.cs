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
	// Token: 0x02003FE5 RID: 16357
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Start_Fly.GA_Motor_Start_Fly_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Motor_Start_Fly_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060292C1 RID: 168641 RVA: 0x00A237D4 File Offset: 0x00A219D4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Start_Fly_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Start_Fly.GA_Motor_Start_Fly_C");
			}
			return GA_Motor_Start_Fly_C._ClassPtr;
		}

		// Token: 0x060292C2 RID: 168642 RVA: 0x00A237F8 File Offset: 0x00A219F8
		public GA_Motor_Start_Fly_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Start_Fly_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060292C3 RID: 168643 RVA: 0x00A23820 File Offset: 0x00A21A20
		[NullableContext(1)]
		public GA_Motor_Start_Fly_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Start_Fly_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700658C RID: 25996
		// (get) Token: 0x060292C4 RID: 168644 RVA: 0x00A23854 File Offset: 0x00A21A54
		// (set) Token: 0x060292C5 RID: 168645 RVA: 0x00A2388D File Offset: 0x00A21A8D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Start_Fly_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Start_Fly_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700658D RID: 25997
		// (get) Token: 0x060292C6 RID: 168646 RVA: 0x00A238AE File Offset: 0x00A21AAE
		// (set) Token: 0x060292C7 RID: 168647 RVA: 0x00A238C2 File Offset: 0x00A21AC2
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Start_Fly_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Start_Fly_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x060292C8 RID: 168648 RVA: 0x00A238D8 File Offset: 0x00A21AD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D38146F818BB(in FGameplayTag Tag)
		{
			GA_Motor_Start_Fly_C.__Removed_DB9F64004F8908FEAD99D38146F818BB_FunctionParams* ptr = stackalloc GA_Motor_Start_Fly_C.__Removed_DB9F64004F8908FEAD99D38146F818BB_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Motor_Start_Fly_C.__Removed_DB9F64004F8908FEAD99D38146F818BB_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Start_Fly_C.__Removed_DB9F64004F8908FEAD99D38146F818BB_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Start_Fly_C.__Removed_DB9F64004F8908FEAD99D38146F818BB_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060292C9 RID: 168649 RVA: 0x00A23923 File Offset: 0x00A21B23
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09B870ACD04()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Start_Fly_C.__OnTick_CF946D5D4EFE5E5564EFF09B870ACD04_NativeFunctionPtr, null);
		}

		// Token: 0x060292CA RID: 168650 RVA: 0x00A23937 File Offset: 0x00A21B37
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09B870ACD04()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Start_Fly_C.__OnCancelled_CF946D5D4EFE5E5564EFF09B870ACD04_NativeFunctionPtr, null);
		}

		// Token: 0x060292CB RID: 168651 RVA: 0x00A2394B File Offset: 0x00A21B4B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09B870ACD04()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Start_Fly_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09B870ACD04_NativeFunctionPtr, null);
		}

		// Token: 0x060292CC RID: 168652 RVA: 0x00A2395F File Offset: 0x00A21B5F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09B870ACD04()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Start_Fly_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09B870ACD04_NativeFunctionPtr, null);
		}

		// Token: 0x060292CD RID: 168653 RVA: 0x00A23973 File Offset: 0x00A21B73
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09B870ACD04()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Start_Fly_C.__OnCompleted_CF946D5D4EFE5E5564EFF09B870ACD04_NativeFunctionPtr, null);
		}

		// Token: 0x060292CE RID: 168654 RVA: 0x00A23987 File Offset: 0x00A21B87
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_A155CB1B4F6EA52B4C285081F43B5440()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Start_Fly_C.__OnFinish_A155CB1B4F6EA52B4C285081F43B5440_NativeFunctionPtr, null);
		}

		// Token: 0x060292CF RID: 168655 RVA: 0x00A2399B File Offset: 0x00A21B9B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Start_Fly_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x060292D0 RID: 168656 RVA: 0x00A239AF File Offset: 0x00A21BAF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Start_Fly_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060292D1 RID: 168657 RVA: 0x00A239C4 File Offset: 0x00A21BC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Start_Fly_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Start_Fly_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Start_Fly_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Start_Fly_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Start_Fly_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060292D2 RID: 168658 RVA: 0x00A23A0C File Offset: 0x00A21C0C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Start_Fly_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Start_Fly_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Start_Fly_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Start_Fly_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Start_Fly_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060292D3 RID: 168659 RVA: 0x00A23A54 File Offset: 0x00A21C54
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Start_Fly(int EntryPoint)
		{
			GA_Motor_Start_Fly_C.__ExecuteUbergraph_GA_Motor_Start_Fly_FunctionParams* ptr = stackalloc GA_Motor_Start_Fly_C.__ExecuteUbergraph_GA_Motor_Start_Fly_FunctionParams[(UIntPtr)519] + 15L / (long)sizeof(GA_Motor_Start_Fly_C.__ExecuteUbergraph_GA_Motor_Start_Fly_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Start_Fly_C.__ExecuteUbergraph_GA_Motor_Start_Fly_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Start_Fly_C.__ExecuteUbergraph_GA_Motor_Start_Fly_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060292D4 RID: 168660 RVA: 0x00A23A9E File Offset: 0x00A21C9E
		protected GA_Motor_Start_Fly_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015D4F RID: 89423
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Start_Fly.GA_Motor_Start_Fly_C";

		// Token: 0x04015D50 RID: 89424
		private static IntPtr _ClassPtr;

		// Token: 0x04015D51 RID: 89425
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015D52 RID: 89426
		internal new static int __PropertyOffset_0;

		// Token: 0x04015D53 RID: 89427
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015D54 RID: 89428
		internal new static int __PropertyOffset_1;

		// Token: 0x04015D55 RID: 89429
		private static IntPtr __Removed_DB9F64004F8908FEAD99D38146F818BB_NativeFunctionPtr;

		// Token: 0x04015D56 RID: 89430
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09B870ACD04_NativeFunctionPtr;

		// Token: 0x04015D57 RID: 89431
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09B870ACD04_NativeFunctionPtr;

		// Token: 0x04015D58 RID: 89432
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09B870ACD04_NativeFunctionPtr;

		// Token: 0x04015D59 RID: 89433
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09B870ACD04_NativeFunctionPtr;

		// Token: 0x04015D5A RID: 89434
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09B870ACD04_NativeFunctionPtr;

		// Token: 0x04015D5B RID: 89435
		private static IntPtr __OnFinish_A155CB1B4F6EA52B4C285081F43B5440_NativeFunctionPtr;

		// Token: 0x04015D5C RID: 89436
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015D5D RID: 89437
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015D5E RID: 89438
		private static IntPtr __ExecuteUbergraph_GA_Motor_Start_Fly_NativeFunctionPtr;

		// Token: 0x0200A1ED RID: 41453
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D38146F818BB_FunctionParams
		{
			// Token: 0x04032F4A RID: 208714
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A1EE RID: 41454
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F4B RID: 208715
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1EF RID: 41455
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 504)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Start_Fly_FunctionParams
		{
			// Token: 0x04032F4C RID: 208716
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
