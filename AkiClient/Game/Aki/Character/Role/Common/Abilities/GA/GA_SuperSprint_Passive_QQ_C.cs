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
	// Token: 0x020040BD RID: 16573
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_SuperSprint_Passive_QQ.GA_SuperSprint_Passive_QQ_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1488)]
	public class GA_SuperSprint_Passive_QQ_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B4A8 RID: 177320 RVA: 0x00A76CAB File Offset: 0x00A74EAB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_SuperSprint_Passive_QQ_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_SuperSprint_Passive_QQ.GA_SuperSprint_Passive_QQ_C");
			}
			return GA_SuperSprint_Passive_QQ_C._ClassPtr;
		}

		// Token: 0x0602B4A9 RID: 177321 RVA: 0x00A76CD0 File Offset: 0x00A74ED0
		public GA_SuperSprint_Passive_QQ_C() : this(BuiltinUtils.AllocNativeUObject(GA_SuperSprint_Passive_QQ_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B4AA RID: 177322 RVA: 0x00A76CF8 File Offset: 0x00A74EF8
		[NullableContext(1)]
		public GA_SuperSprint_Passive_QQ_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_SuperSprint_Passive_QQ_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007167 RID: 29031
		// (get) Token: 0x0602B4AB RID: 177323 RVA: 0x00A76D2C File Offset: 0x00A74F2C
		// (set) Token: 0x0602B4AC RID: 177324 RVA: 0x00A76D65 File Offset: 0x00A74F65
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_SuperSprint_Passive_QQ_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_SuperSprint_Passive_QQ_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602B4AD RID: 177325 RVA: 0x00A76D88 File Offset: 0x00A74F88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A3C99CC24B(in FGameplayTag Tag)
		{
			GA_SuperSprint_Passive_QQ_C.__Added_21071CB943CD992BF8EFD6A3C99CC24B_FunctionParams* ptr = stackalloc GA_SuperSprint_Passive_QQ_C.__Added_21071CB943CD992BF8EFD6A3C99CC24B_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_SuperSprint_Passive_QQ_C.__Added_21071CB943CD992BF8EFD6A3C99CC24B_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_SuperSprint_Passive_QQ_C.__Added_21071CB943CD992BF8EFD6A3C99CC24B_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SuperSprint_Passive_QQ_C.__Added_21071CB943CD992BF8EFD6A3C99CC24B_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B4AE RID: 177326 RVA: 0x00A76DD4 File Offset: 0x00A74FD4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D38175136BBF(in FGameplayTag Tag)
		{
			GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D38175136BBF_FunctionParams* ptr = stackalloc GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D38175136BBF_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D38175136BBF_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D38175136BBF_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D38175136BBF_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B4AF RID: 177327 RVA: 0x00A76E20 File Offset: 0x00A75020
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A3D808DB6C(in FGameplayTag Tag)
		{
			GA_SuperSprint_Passive_QQ_C.__Added_21071CB943CD992BF8EFD6A3D808DB6C_FunctionParams* ptr = stackalloc GA_SuperSprint_Passive_QQ_C.__Added_21071CB943CD992BF8EFD6A3D808DB6C_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_SuperSprint_Passive_QQ_C.__Added_21071CB943CD992BF8EFD6A3D808DB6C_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_SuperSprint_Passive_QQ_C.__Added_21071CB943CD992BF8EFD6A3D808DB6C_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SuperSprint_Passive_QQ_C.__Added_21071CB943CD992BF8EFD6A3D808DB6C_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B4B0 RID: 177328 RVA: 0x00A76E6C File Offset: 0x00A7506C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D3813DF7FC93(in FGameplayTag Tag)
		{
			GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D3813DF7FC93_FunctionParams* ptr = stackalloc GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D3813DF7FC93_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D3813DF7FC93_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D3813DF7FC93_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D3813DF7FC93_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B4B1 RID: 177329 RVA: 0x00A76EB8 File Offset: 0x00A750B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D381DD224938(in FGameplayTag Tag)
		{
			GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D381DD224938_FunctionParams* ptr = stackalloc GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D381DD224938_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D381DD224938_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D381DD224938_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D381DD224938_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B4B2 RID: 177330 RVA: 0x00A76F04 File Offset: 0x00A75104
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D381CF9139AA(in FGameplayTag Tag)
		{
			GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D381CF9139AA_FunctionParams* ptr = stackalloc GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D381CF9139AA_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D381CF9139AA_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D381CF9139AA_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D381CF9139AA_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B4B3 RID: 177331 RVA: 0x00A76F50 File Offset: 0x00A75150
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D381B50A1D09(in FGameplayTag Tag)
		{
			GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D381B50A1D09_FunctionParams* ptr = stackalloc GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D381B50A1D09_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D381B50A1D09_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D381B50A1D09_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D381B50A1D09_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B4B4 RID: 177332 RVA: 0x00A76F9C File Offset: 0x00A7519C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D381876E965F(in FGameplayTag Tag)
		{
			GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D381876E965F_FunctionParams* ptr = stackalloc GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D381876E965F_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D381876E965F_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D381876E965F_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D381876E965F_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B4B5 RID: 177333 RVA: 0x00A76FE8 File Offset: 0x00A751E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D38151948B4B(in FGameplayTag Tag)
		{
			GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D38151948B4B_FunctionParams* ptr = stackalloc GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D38151948B4B_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D38151948B4B_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D38151948B4B_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SuperSprint_Passive_QQ_C.__Removed_DB9F64004F8908FEAD99D38151948B4B_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B4B6 RID: 177334 RVA: 0x00A77033 File Offset: 0x00A75233
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_6B6877FE457CFD47135C64891F9C4C0C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SuperSprint_Passive_QQ_C.__OnFinish_6B6877FE457CFD47135C64891F9C4C0C_NativeFunctionPtr, null);
		}

		// Token: 0x0602B4B7 RID: 177335 RVA: 0x00A77047 File Offset: 0x00A75247
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SuperSprint_Passive_QQ_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B4B8 RID: 177336 RVA: 0x00A7705B File Offset: 0x00A7525B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_SuperSprint_Passive_QQ_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B4B9 RID: 177337 RVA: 0x00A77070 File Offset: 0x00A75270
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_SuperSprint_Passive_QQ(int EntryPoint)
		{
			GA_SuperSprint_Passive_QQ_C.__ExecuteUbergraph_GA_SuperSprint_Passive_QQ_FunctionParams* ptr = stackalloc GA_SuperSprint_Passive_QQ_C.__ExecuteUbergraph_GA_SuperSprint_Passive_QQ_FunctionParams[(UIntPtr)1127] + 15L / (long)sizeof(GA_SuperSprint_Passive_QQ_C.__ExecuteUbergraph_GA_SuperSprint_Passive_QQ_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_SuperSprint_Passive_QQ_C.__ExecuteUbergraph_GA_SuperSprint_Passive_QQ_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_SuperSprint_Passive_QQ_C.__ExecuteUbergraph_GA_SuperSprint_Passive_QQ_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B4BA RID: 177338 RVA: 0x00A770BA File Offset: 0x00A752BA
		protected GA_SuperSprint_Passive_QQ_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017B7E RID: 97150
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_SuperSprint_Passive_QQ.GA_SuperSprint_Passive_QQ_C";

		// Token: 0x04017B7F RID: 97151
		private static IntPtr _ClassPtr;

		// Token: 0x04017B80 RID: 97152
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017B81 RID: 97153
		internal new static int __PropertyOffset_0;

		// Token: 0x04017B82 RID: 97154
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017B83 RID: 97155
		private static IntPtr __Added_21071CB943CD992BF8EFD6A3C99CC24B_NativeFunctionPtr;

		// Token: 0x04017B84 RID: 97156
		private static IntPtr __Removed_DB9F64004F8908FEAD99D38175136BBF_NativeFunctionPtr;

		// Token: 0x04017B85 RID: 97157
		private static IntPtr __Added_21071CB943CD992BF8EFD6A3D808DB6C_NativeFunctionPtr;

		// Token: 0x04017B86 RID: 97158
		private static IntPtr __Removed_DB9F64004F8908FEAD99D3813DF7FC93_NativeFunctionPtr;

		// Token: 0x04017B87 RID: 97159
		private static IntPtr __Removed_DB9F64004F8908FEAD99D381DD224938_NativeFunctionPtr;

		// Token: 0x04017B88 RID: 97160
		private static IntPtr __Removed_DB9F64004F8908FEAD99D381CF9139AA_NativeFunctionPtr;

		// Token: 0x04017B89 RID: 97161
		private static IntPtr __Removed_DB9F64004F8908FEAD99D381B50A1D09_NativeFunctionPtr;

		// Token: 0x04017B8A RID: 97162
		private static IntPtr __Removed_DB9F64004F8908FEAD99D381876E965F_NativeFunctionPtr;

		// Token: 0x04017B8B RID: 97163
		private static IntPtr __Removed_DB9F64004F8908FEAD99D38151948B4B_NativeFunctionPtr;

		// Token: 0x04017B8C RID: 97164
		private static IntPtr __OnFinish_6B6877FE457CFD47135C64891F9C4C0C_NativeFunctionPtr;

		// Token: 0x04017B8D RID: 97165
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017B8E RID: 97166
		private static IntPtr __ExecuteUbergraph_GA_SuperSprint_Passive_QQ_NativeFunctionPtr;

		// Token: 0x0200A34D RID: 41805
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A3C99CC24B_FunctionParams
		{
			// Token: 0x0403312A RID: 209194
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A34E RID: 41806
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D38175136BBF_FunctionParams
		{
			// Token: 0x0403312B RID: 209195
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A34F RID: 41807
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A3D808DB6C_FunctionParams
		{
			// Token: 0x0403312C RID: 209196
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A350 RID: 41808
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D3813DF7FC93_FunctionParams
		{
			// Token: 0x0403312D RID: 209197
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A351 RID: 41809
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D381DD224938_FunctionParams
		{
			// Token: 0x0403312E RID: 209198
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A352 RID: 41810
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D381CF9139AA_FunctionParams
		{
			// Token: 0x0403312F RID: 209199
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A353 RID: 41811
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D381B50A1D09_FunctionParams
		{
			// Token: 0x04033130 RID: 209200
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A354 RID: 41812
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D381876E965F_FunctionParams
		{
			// Token: 0x04033131 RID: 209201
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A355 RID: 41813
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D38151948B4B_FunctionParams
		{
			// Token: 0x04033132 RID: 209202
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A356 RID: 41814
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1112)]
		protected ref struct __ExecuteUbergraph_GA_SuperSprint_Passive_QQ_FunctionParams
		{
			// Token: 0x04033133 RID: 209203
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
