using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Abilities.GA
{
	// Token: 0x0200407D RID: 16509
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Common_AirShot.GA_Common_AirShot_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1492)]
	public class GA_Common_AirShot_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AEB3 RID: 175795 RVA: 0x00A69F33 File Offset: 0x00A68133
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Common_AirShot_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Common_AirShot.GA_Common_AirShot_C");
			}
			return GA_Common_AirShot_C._ClassPtr;
		}

		// Token: 0x0602AEB4 RID: 175796 RVA: 0x00A69F58 File Offset: 0x00A68158
		public GA_Common_AirShot_C() : this(BuiltinUtils.AllocNativeUObject(GA_Common_AirShot_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AEB5 RID: 175797 RVA: 0x00A69F80 File Offset: 0x00A68180
		[NullableContext(1)]
		public GA_Common_AirShot_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Common_AirShot_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007033 RID: 28723
		// (get) Token: 0x0602AEB6 RID: 175798 RVA: 0x00A69FB4 File Offset: 0x00A681B4
		// (set) Token: 0x0602AEB7 RID: 175799 RVA: 0x00A69FED File Offset: 0x00A681ED
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Common_AirShot_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Common_AirShot_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007034 RID: 28724
		// (get) Token: 0x0602AEB8 RID: 175800 RVA: 0x00A6A00E File Offset: 0x00A6820E
		// (set) Token: 0x0602AEB9 RID: 175801 RVA: 0x00A6A01E File Offset: 0x00A6821E
		public unsafe int 层数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Common_AirShot_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Common_AirShot_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x0602AEBA RID: 175802 RVA: 0x00A6A030 File Offset: 0x00A68230
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_672DF730488FF3847426B2B0B4DDBA8C(in FGameplayTag Tag)
		{
			GA_Common_AirShot_C.__Removed_672DF730488FF3847426B2B0B4DDBA8C_FunctionParams* ptr = stackalloc GA_Common_AirShot_C.__Removed_672DF730488FF3847426B2B0B4DDBA8C_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Common_AirShot_C.__Removed_672DF730488FF3847426B2B0B4DDBA8C_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Common_AirShot_C.__Removed_672DF730488FF3847426B2B0B4DDBA8C_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Common_AirShot_C.__Removed_672DF730488FF3847426B2B0B4DDBA8C_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AEBB RID: 175803 RVA: 0x00A6A07C File Offset: 0x00A6827C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_8BFB30E14403CD30B6735ABFFDD5C4B2(in FGameplayTag Tag)
		{
			GA_Common_AirShot_C.__Added_8BFB30E14403CD30B6735ABFFDD5C4B2_FunctionParams* ptr = stackalloc GA_Common_AirShot_C.__Added_8BFB30E14403CD30B6735ABFFDD5C4B2_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Common_AirShot_C.__Added_8BFB30E14403CD30B6735ABFFDD5C4B2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Common_AirShot_C.__Added_8BFB30E14403CD30B6735ABFFDD5C4B2_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Common_AirShot_C.__Added_8BFB30E14403CD30B6735ABFFDD5C4B2_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AEBC RID: 175804 RVA: 0x00A6A0C8 File Offset: 0x00A682C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_FFBD6C384BB1FB51A97536A87C7A0267(in FGameplayTag Tag)
		{
			GA_Common_AirShot_C.__Added_FFBD6C384BB1FB51A97536A87C7A0267_FunctionParams* ptr = stackalloc GA_Common_AirShot_C.__Added_FFBD6C384BB1FB51A97536A87C7A0267_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Common_AirShot_C.__Added_FFBD6C384BB1FB51A97536A87C7A0267_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Common_AirShot_C.__Added_FFBD6C384BB1FB51A97536A87C7A0267_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Common_AirShot_C.__Added_FFBD6C384BB1FB51A97536A87C7A0267_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AEBD RID: 175805 RVA: 0x00A6A114 File Offset: 0x00A68314
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Common_AirShot_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Common_AirShot_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Common_AirShot_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Common_AirShot_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Common_AirShot_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AEBE RID: 175806 RVA: 0x00A6A15C File Offset: 0x00A6835C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Common_AirShot_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Common_AirShot_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Common_AirShot_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Common_AirShot_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Common_AirShot_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AEBF RID: 175807 RVA: 0x00A6A1A3 File Offset: 0x00A683A3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Common_AirShot_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602AEC0 RID: 175808 RVA: 0x00A6A1B7 File Offset: 0x00A683B7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Common_AirShot_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602AEC1 RID: 175809 RVA: 0x00A6A1CC File Offset: 0x00A683CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Common_AirShot(int EntryPoint)
		{
			GA_Common_AirShot_C.__ExecuteUbergraph_GA_Common_AirShot_FunctionParams* ptr = stackalloc GA_Common_AirShot_C.__ExecuteUbergraph_GA_Common_AirShot_FunctionParams[(UIntPtr)399] + 15L / (long)sizeof(GA_Common_AirShot_C.__ExecuteUbergraph_GA_Common_AirShot_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Common_AirShot_C.__ExecuteUbergraph_GA_Common_AirShot_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Common_AirShot_C.__ExecuteUbergraph_GA_Common_AirShot_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AEC2 RID: 175810 RVA: 0x00A6A216 File Offset: 0x00A68416
		protected GA_Common_AirShot_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017720 RID: 96032
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Common_AirShot.GA_Common_AirShot_C";

		// Token: 0x04017721 RID: 96033
		private static IntPtr _ClassPtr;

		// Token: 0x04017722 RID: 96034
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017723 RID: 96035
		internal new static int __PropertyOffset_0;

		// Token: 0x04017724 RID: 96036
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017725 RID: 96037
		internal new static int __PropertyOffset_1;

		// Token: 0x04017726 RID: 96038
		private static IntPtr __Removed_672DF730488FF3847426B2B0B4DDBA8C_NativeFunctionPtr;

		// Token: 0x04017727 RID: 96039
		private static IntPtr __Added_8BFB30E14403CD30B6735ABFFDD5C4B2_NativeFunctionPtr;

		// Token: 0x04017728 RID: 96040
		private static IntPtr __Added_FFBD6C384BB1FB51A97536A87C7A0267_NativeFunctionPtr;

		// Token: 0x04017729 RID: 96041
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x0401772A RID: 96042
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x0401772B RID: 96043
		private static IntPtr __ExecuteUbergraph_GA_Common_AirShot_NativeFunctionPtr;

		// Token: 0x0200A292 RID: 41618
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_672DF730488FF3847426B2B0B4DDBA8C_FunctionParams
		{
			// Token: 0x04033040 RID: 208960
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A293 RID: 41619
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_8BFB30E14403CD30B6735ABFFDD5C4B2_FunctionParams
		{
			// Token: 0x04033041 RID: 208961
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A294 RID: 41620
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_FFBD6C384BB1FB51A97536A87C7A0267_FunctionParams
		{
			// Token: 0x04033042 RID: 208962
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A295 RID: 41621
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033043 RID: 208963
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A296 RID: 41622
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 384)]
		protected ref struct __ExecuteUbergraph_GA_Common_AirShot_FunctionParams
		{
			// Token: 0x04033044 RID: 208964
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
