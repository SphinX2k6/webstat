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
	// Token: 0x020040BC RID: 16572
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_SuperSprint_Passive.GA_SuperSprint_Passive_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1488)]
	public class GA_SuperSprint_Passive_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B495 RID: 177301 RVA: 0x00A76893 File Offset: 0x00A74A93
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_SuperSprint_Passive_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_SuperSprint_Passive.GA_SuperSprint_Passive_C");
			}
			return GA_SuperSprint_Passive_C._ClassPtr;
		}

		// Token: 0x0602B496 RID: 177302 RVA: 0x00A768B8 File Offset: 0x00A74AB8
		public GA_SuperSprint_Passive_C() : this(BuiltinUtils.AllocNativeUObject(GA_SuperSprint_Passive_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B497 RID: 177303 RVA: 0x00A768E0 File Offset: 0x00A74AE0
		[NullableContext(1)]
		public GA_SuperSprint_Passive_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_SuperSprint_Passive_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007166 RID: 29030
		// (get) Token: 0x0602B498 RID: 177304 RVA: 0x00A76914 File Offset: 0x00A74B14
		// (set) Token: 0x0602B499 RID: 177305 RVA: 0x00A7694D File Offset: 0x00A74B4D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_SuperSprint_Passive_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_SuperSprint_Passive_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602B49A RID: 177306 RVA: 0x00A76970 File Offset: 0x00A74B70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A392FC0505(in FGameplayTag Tag)
		{
			GA_SuperSprint_Passive_C.__Added_21071CB943CD992BF8EFD6A392FC0505_FunctionParams* ptr = stackalloc GA_SuperSprint_Passive_C.__Added_21071CB943CD992BF8EFD6A392FC0505_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_SuperSprint_Passive_C.__Added_21071CB943CD992BF8EFD6A392FC0505_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_SuperSprint_Passive_C.__Added_21071CB943CD992BF8EFD6A392FC0505_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SuperSprint_Passive_C.__Added_21071CB943CD992BF8EFD6A392FC0505_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B49B RID: 177307 RVA: 0x00A769BC File Offset: 0x00A74BBC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D38190205F77(in FGameplayTag Tag)
		{
			GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D38190205F77_FunctionParams* ptr = stackalloc GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D38190205F77_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D38190205F77_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D38190205F77_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D38190205F77_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B49C RID: 177308 RVA: 0x00A76A08 File Offset: 0x00A74C08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A3B2391EA2(in FGameplayTag Tag)
		{
			GA_SuperSprint_Passive_C.__Added_21071CB943CD992BF8EFD6A3B2391EA2_FunctionParams* ptr = stackalloc GA_SuperSprint_Passive_C.__Added_21071CB943CD992BF8EFD6A3B2391EA2_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_SuperSprint_Passive_C.__Added_21071CB943CD992BF8EFD6A3B2391EA2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_SuperSprint_Passive_C.__Added_21071CB943CD992BF8EFD6A3B2391EA2_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SuperSprint_Passive_C.__Added_21071CB943CD992BF8EFD6A3B2391EA2_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B49D RID: 177309 RVA: 0x00A76A54 File Offset: 0x00A74C54
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D3813E85AA71(in FGameplayTag Tag)
		{
			GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D3813E85AA71_FunctionParams* ptr = stackalloc GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D3813E85AA71_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D3813E85AA71_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D3813E85AA71_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D3813E85AA71_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B49E RID: 177310 RVA: 0x00A76AA0 File Offset: 0x00A74CA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D381D963214C(in FGameplayTag Tag)
		{
			GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D381D963214C_FunctionParams* ptr = stackalloc GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D381D963214C_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D381D963214C_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D381D963214C_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D381D963214C_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B49F RID: 177311 RVA: 0x00A76AEC File Offset: 0x00A74CEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D38102C28DD9(in FGameplayTag Tag)
		{
			GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D38102C28DD9_FunctionParams* ptr = stackalloc GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D38102C28DD9_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D38102C28DD9_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D38102C28DD9_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D38102C28DD9_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B4A0 RID: 177312 RVA: 0x00A76B38 File Offset: 0x00A74D38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D381A06BE60F(in FGameplayTag Tag)
		{
			GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D381A06BE60F_FunctionParams* ptr = stackalloc GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D381A06BE60F_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D381A06BE60F_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D381A06BE60F_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D381A06BE60F_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B4A1 RID: 177313 RVA: 0x00A76B84 File Offset: 0x00A74D84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D3811399D330(in FGameplayTag Tag)
		{
			GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D3811399D330_FunctionParams* ptr = stackalloc GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D3811399D330_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D3811399D330_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D3811399D330_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D3811399D330_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B4A2 RID: 177314 RVA: 0x00A76BD0 File Offset: 0x00A74DD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D381FA852B9F(in FGameplayTag Tag)
		{
			GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D381FA852B9F_FunctionParams* ptr = stackalloc GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D381FA852B9F_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D381FA852B9F_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D381FA852B9F_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SuperSprint_Passive_C.__Removed_DB9F64004F8908FEAD99D381FA852B9F_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B4A3 RID: 177315 RVA: 0x00A76C1B File Offset: 0x00A74E1B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_84E4D1EA47326B44391C1D810088F11A()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SuperSprint_Passive_C.__OnFinish_84E4D1EA47326B44391C1D810088F11A_NativeFunctionPtr, null);
		}

		// Token: 0x0602B4A4 RID: 177316 RVA: 0x00A76C2F File Offset: 0x00A74E2F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SuperSprint_Passive_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B4A5 RID: 177317 RVA: 0x00A76C43 File Offset: 0x00A74E43
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_SuperSprint_Passive_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B4A6 RID: 177318 RVA: 0x00A76C58 File Offset: 0x00A74E58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_SuperSprint_Passive(int EntryPoint)
		{
			GA_SuperSprint_Passive_C.__ExecuteUbergraph_GA_SuperSprint_Passive_FunctionParams* ptr = stackalloc GA_SuperSprint_Passive_C.__ExecuteUbergraph_GA_SuperSprint_Passive_FunctionParams[(UIntPtr)1087] + 15L / (long)sizeof(GA_SuperSprint_Passive_C.__ExecuteUbergraph_GA_SuperSprint_Passive_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_SuperSprint_Passive_C.__ExecuteUbergraph_GA_SuperSprint_Passive_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_SuperSprint_Passive_C.__ExecuteUbergraph_GA_SuperSprint_Passive_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B4A7 RID: 177319 RVA: 0x00A76CA2 File Offset: 0x00A74EA2
		protected GA_SuperSprint_Passive_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017B6D RID: 97133
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_SuperSprint_Passive.GA_SuperSprint_Passive_C";

		// Token: 0x04017B6E RID: 97134
		private static IntPtr _ClassPtr;

		// Token: 0x04017B6F RID: 97135
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017B70 RID: 97136
		internal new static int __PropertyOffset_0;

		// Token: 0x04017B71 RID: 97137
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017B72 RID: 97138
		private static IntPtr __Added_21071CB943CD992BF8EFD6A392FC0505_NativeFunctionPtr;

		// Token: 0x04017B73 RID: 97139
		private static IntPtr __Removed_DB9F64004F8908FEAD99D38190205F77_NativeFunctionPtr;

		// Token: 0x04017B74 RID: 97140
		private static IntPtr __Added_21071CB943CD992BF8EFD6A3B2391EA2_NativeFunctionPtr;

		// Token: 0x04017B75 RID: 97141
		private static IntPtr __Removed_DB9F64004F8908FEAD99D3813E85AA71_NativeFunctionPtr;

		// Token: 0x04017B76 RID: 97142
		private static IntPtr __Removed_DB9F64004F8908FEAD99D381D963214C_NativeFunctionPtr;

		// Token: 0x04017B77 RID: 97143
		private static IntPtr __Removed_DB9F64004F8908FEAD99D38102C28DD9_NativeFunctionPtr;

		// Token: 0x04017B78 RID: 97144
		private static IntPtr __Removed_DB9F64004F8908FEAD99D381A06BE60F_NativeFunctionPtr;

		// Token: 0x04017B79 RID: 97145
		private static IntPtr __Removed_DB9F64004F8908FEAD99D3811399D330_NativeFunctionPtr;

		// Token: 0x04017B7A RID: 97146
		private static IntPtr __Removed_DB9F64004F8908FEAD99D381FA852B9F_NativeFunctionPtr;

		// Token: 0x04017B7B RID: 97147
		private static IntPtr __OnFinish_84E4D1EA47326B44391C1D810088F11A_NativeFunctionPtr;

		// Token: 0x04017B7C RID: 97148
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017B7D RID: 97149
		private static IntPtr __ExecuteUbergraph_GA_SuperSprint_Passive_NativeFunctionPtr;

		// Token: 0x0200A343 RID: 41795
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A392FC0505_FunctionParams
		{
			// Token: 0x04033120 RID: 209184
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A344 RID: 41796
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D38190205F77_FunctionParams
		{
			// Token: 0x04033121 RID: 209185
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A345 RID: 41797
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A3B2391EA2_FunctionParams
		{
			// Token: 0x04033122 RID: 209186
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A346 RID: 41798
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D3813E85AA71_FunctionParams
		{
			// Token: 0x04033123 RID: 209187
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A347 RID: 41799
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D381D963214C_FunctionParams
		{
			// Token: 0x04033124 RID: 209188
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A348 RID: 41800
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D38102C28DD9_FunctionParams
		{
			// Token: 0x04033125 RID: 209189
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A349 RID: 41801
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D381A06BE60F_FunctionParams
		{
			// Token: 0x04033126 RID: 209190
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A34A RID: 41802
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D3811399D330_FunctionParams
		{
			// Token: 0x04033127 RID: 209191
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A34B RID: 41803
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D381FA852B9F_FunctionParams
		{
			// Token: 0x04033128 RID: 209192
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A34C RID: 41804
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1072)]
		protected ref struct __ExecuteUbergraph_GA_SuperSprint_Passive_FunctionParams
		{
			// Token: 0x04033129 RID: 209193
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
