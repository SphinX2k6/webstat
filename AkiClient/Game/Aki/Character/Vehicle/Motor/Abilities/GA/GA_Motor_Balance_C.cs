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
	// Token: 0x02003FBF RID: 16319
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Balance.GA_Motor_Balance_C")]
	[UnrealStructLayout(1504, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1504)]
	public class GA_Motor_Balance_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028F54 RID: 167764 RVA: 0x00A1C2B8 File Offset: 0x00A1A4B8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Balance_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Balance.GA_Motor_Balance_C");
			}
			return GA_Motor_Balance_C._ClassPtr;
		}

		// Token: 0x06028F55 RID: 167765 RVA: 0x00A1C2DC File Offset: 0x00A1A4DC
		public GA_Motor_Balance_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Balance_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028F56 RID: 167766 RVA: 0x00A1C304 File Offset: 0x00A1A504
		[NullableContext(1)]
		public GA_Motor_Balance_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Balance_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170064ED RID: 25837
		// (get) Token: 0x06028F57 RID: 167767 RVA: 0x00A1C338 File Offset: 0x00A1A538
		// (set) Token: 0x06028F58 RID: 167768 RVA: 0x00A1C371 File Offset: 0x00A1A571
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Balance_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Balance_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170064EE RID: 25838
		// (get) Token: 0x06028F59 RID: 167769 RVA: 0x00A1C392 File Offset: 0x00A1A592
		// (set) Token: 0x06028F5A RID: 167770 RVA: 0x00A1C3A2 File Offset: 0x00A1A5A2
		public unsafe bool 是否主动结束
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_Balance_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_Balance_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x170064EF RID: 25839
		// (get) Token: 0x06028F5B RID: 167771 RVA: 0x00A1C3B3 File Offset: 0x00A1A5B3
		// (set) Token: 0x06028F5C RID: 167772 RVA: 0x00A1C3C7 File Offset: 0x00A1A5C7
		[Nullable(2)]
		public unsafe TsBaseCharacter 驾驶员
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Balance_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Balance_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x06028F5D RID: 167773 RVA: 0x00A1C3DC File Offset: 0x00A1A5DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09BE8EFD450()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Balance_C.__OnTick_CF946D5D4EFE5E5564EFF09BE8EFD450_NativeFunctionPtr, null);
		}

		// Token: 0x06028F5E RID: 167774 RVA: 0x00A1C3F0 File Offset: 0x00A1A5F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09BE8EFD450()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Balance_C.__OnCancelled_CF946D5D4EFE5E5564EFF09BE8EFD450_NativeFunctionPtr, null);
		}

		// Token: 0x06028F5F RID: 167775 RVA: 0x00A1C404 File Offset: 0x00A1A604
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09BE8EFD450()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Balance_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09BE8EFD450_NativeFunctionPtr, null);
		}

		// Token: 0x06028F60 RID: 167776 RVA: 0x00A1C418 File Offset: 0x00A1A618
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09BE8EFD450()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Balance_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09BE8EFD450_NativeFunctionPtr, null);
		}

		// Token: 0x06028F61 RID: 167777 RVA: 0x00A1C42C File Offset: 0x00A1A62C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09BE8EFD450()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Balance_C.__OnCompleted_CF946D5D4EFE5E5564EFF09BE8EFD450_NativeFunctionPtr, null);
		}

		// Token: 0x06028F62 RID: 167778 RVA: 0x00A1C440 File Offset: 0x00A1A640
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09B259AAA5B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Balance_C.__OnTick_CF946D5D4EFE5E5564EFF09B259AAA5B_NativeFunctionPtr, null);
		}

		// Token: 0x06028F63 RID: 167779 RVA: 0x00A1C454 File Offset: 0x00A1A654
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09B259AAA5B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Balance_C.__OnCancelled_CF946D5D4EFE5E5564EFF09B259AAA5B_NativeFunctionPtr, null);
		}

		// Token: 0x06028F64 RID: 167780 RVA: 0x00A1C468 File Offset: 0x00A1A668
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09B259AAA5B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Balance_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09B259AAA5B_NativeFunctionPtr, null);
		}

		// Token: 0x06028F65 RID: 167781 RVA: 0x00A1C47C File Offset: 0x00A1A67C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09B259AAA5B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Balance_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09B259AAA5B_NativeFunctionPtr, null);
		}

		// Token: 0x06028F66 RID: 167782 RVA: 0x00A1C490 File Offset: 0x00A1A690
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09B259AAA5B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Balance_C.__OnCompleted_CF946D5D4EFE5E5564EFF09B259AAA5B_NativeFunctionPtr, null);
		}

		// Token: 0x06028F67 RID: 167783 RVA: 0x00A1C4A4 File Offset: 0x00A1A6A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D381ED22EBBE(in FGameplayTag Tag)
		{
			GA_Motor_Balance_C.__Removed_DB9F64004F8908FEAD99D381ED22EBBE_FunctionParams* ptr = stackalloc GA_Motor_Balance_C.__Removed_DB9F64004F8908FEAD99D381ED22EBBE_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Motor_Balance_C.__Removed_DB9F64004F8908FEAD99D381ED22EBBE_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Balance_C.__Removed_DB9F64004F8908FEAD99D381ED22EBBE_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Balance_C.__Removed_DB9F64004F8908FEAD99D381ED22EBBE_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028F68 RID: 167784 RVA: 0x00A1C4EF File Offset: 0x00A1A6EF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Balance_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06028F69 RID: 167785 RVA: 0x00A1C503 File Offset: 0x00A1A703
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Balance_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06028F6A RID: 167786 RVA: 0x00A1C518 File Offset: 0x00A1A718
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Balance_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Balance_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Balance_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Balance_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Balance_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028F6B RID: 167787 RVA: 0x00A1C560 File Offset: 0x00A1A760
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Balance_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Balance_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Balance_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Balance_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Balance_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028F6C RID: 167788 RVA: 0x00A1C5A8 File Offset: 0x00A1A7A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Balance(int EntryPoint)
		{
			GA_Motor_Balance_C.__ExecuteUbergraph_GA_Motor_Balance_FunctionParams* ptr = stackalloc GA_Motor_Balance_C.__ExecuteUbergraph_GA_Motor_Balance_FunctionParams[(UIntPtr)767] + 15L / (long)sizeof(GA_Motor_Balance_C.__ExecuteUbergraph_GA_Motor_Balance_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Balance_C.__ExecuteUbergraph_GA_Motor_Balance_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Balance_C.__ExecuteUbergraph_GA_Motor_Balance_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028F6D RID: 167789 RVA: 0x00A1C5F2 File Offset: 0x00A1A7F2
		protected GA_Motor_Balance_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015ABF RID: 88767
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Balance.GA_Motor_Balance_C";

		// Token: 0x04015AC0 RID: 88768
		private static IntPtr _ClassPtr;

		// Token: 0x04015AC1 RID: 88769
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015AC2 RID: 88770
		internal new static int __PropertyOffset_0;

		// Token: 0x04015AC3 RID: 88771
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015AC4 RID: 88772
		internal new static int __PropertyOffset_1;

		// Token: 0x04015AC5 RID: 88773
		internal new static int __PropertyOffset_2;

		// Token: 0x04015AC6 RID: 88774
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09BE8EFD450_NativeFunctionPtr;

		// Token: 0x04015AC7 RID: 88775
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09BE8EFD450_NativeFunctionPtr;

		// Token: 0x04015AC8 RID: 88776
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09BE8EFD450_NativeFunctionPtr;

		// Token: 0x04015AC9 RID: 88777
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09BE8EFD450_NativeFunctionPtr;

		// Token: 0x04015ACA RID: 88778
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09BE8EFD450_NativeFunctionPtr;

		// Token: 0x04015ACB RID: 88779
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09B259AAA5B_NativeFunctionPtr;

		// Token: 0x04015ACC RID: 88780
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09B259AAA5B_NativeFunctionPtr;

		// Token: 0x04015ACD RID: 88781
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09B259AAA5B_NativeFunctionPtr;

		// Token: 0x04015ACE RID: 88782
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09B259AAA5B_NativeFunctionPtr;

		// Token: 0x04015ACF RID: 88783
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09B259AAA5B_NativeFunctionPtr;

		// Token: 0x04015AD0 RID: 88784
		private static IntPtr __Removed_DB9F64004F8908FEAD99D381ED22EBBE_NativeFunctionPtr;

		// Token: 0x04015AD1 RID: 88785
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015AD2 RID: 88786
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015AD3 RID: 88787
		private static IntPtr __ExecuteUbergraph_GA_Motor_Balance_NativeFunctionPtr;

		// Token: 0x0200A17F RID: 41343
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D381ED22EBBE_FunctionParams
		{
			// Token: 0x04032ED3 RID: 208595
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A180 RID: 41344
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032ED4 RID: 208596
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A181 RID: 41345
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 752)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Balance_FunctionParams
		{
			// Token: 0x04032ED5 RID: 208597
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
