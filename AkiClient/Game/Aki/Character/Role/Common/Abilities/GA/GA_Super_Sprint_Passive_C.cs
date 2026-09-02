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
	// Token: 0x020040C4 RID: 16580
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Passive.GA_Super_Sprint_Passive_C")]
	[UnrealStructLayout(1504, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1504)]
	public class GA_Super_Sprint_Passive_C : Ga_Passive_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B548 RID: 177480 RVA: 0x00A784DF File Offset: 0x00A766DF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Super_Sprint_Passive_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Passive.GA_Super_Sprint_Passive_C");
			}
			return GA_Super_Sprint_Passive_C._ClassPtr;
		}

		// Token: 0x0602B549 RID: 177481 RVA: 0x00A78504 File Offset: 0x00A76704
		public GA_Super_Sprint_Passive_C() : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_Passive_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B54A RID: 177482 RVA: 0x00A7852C File Offset: 0x00A7672C
		[NullableContext(1)]
		public GA_Super_Sprint_Passive_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_Passive_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700717D RID: 29053
		// (get) Token: 0x0602B54B RID: 177483 RVA: 0x00A78560 File Offset: 0x00A76760
		// (set) Token: 0x0602B54C RID: 177484 RVA: 0x00A78599 File Offset: 0x00A76799
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Super_Sprint_Passive_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Super_Sprint_Passive_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602B54D RID: 177485 RVA: 0x00A785BC File Offset: 0x00A767BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D38110EAC134(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Passive_C.__Removed_DB9F64004F8908FEAD99D38110EAC134_FunctionParams* ptr = stackalloc GA_Super_Sprint_Passive_C.__Removed_DB9F64004F8908FEAD99D38110EAC134_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Passive_C.__Removed_DB9F64004F8908FEAD99D38110EAC134_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Passive_C.__Removed_DB9F64004F8908FEAD99D38110EAC134_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Passive_C.__Removed_DB9F64004F8908FEAD99D38110EAC134_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B54E RID: 177486 RVA: 0x00A78608 File Offset: 0x00A76808
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A351E99F1A(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Passive_C.__Added_21071CB943CD992BF8EFD6A351E99F1A_FunctionParams* ptr = stackalloc GA_Super_Sprint_Passive_C.__Added_21071CB943CD992BF8EFD6A351E99F1A_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Passive_C.__Added_21071CB943CD992BF8EFD6A351E99F1A_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Passive_C.__Added_21071CB943CD992BF8EFD6A351E99F1A_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Passive_C.__Added_21071CB943CD992BF8EFD6A351E99F1A_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B54F RID: 177487 RVA: 0x00A78653 File Offset: 0x00A76853
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Passive_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B550 RID: 177488 RVA: 0x00A78667 File Offset: 0x00A76867
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Passive_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B551 RID: 177489 RVA: 0x00A7867C File Offset: 0x00A7687C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Super_Sprint_Passive(int EntryPoint)
		{
			GA_Super_Sprint_Passive_C.__ExecuteUbergraph_GA_Super_Sprint_Passive_FunctionParams* ptr = stackalloc GA_Super_Sprint_Passive_C.__ExecuteUbergraph_GA_Super_Sprint_Passive_FunctionParams[(UIntPtr)215] + 15L / (long)sizeof(GA_Super_Sprint_Passive_C.__ExecuteUbergraph_GA_Super_Sprint_Passive_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Passive_C.__ExecuteUbergraph_GA_Super_Sprint_Passive_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Passive_C.__ExecuteUbergraph_GA_Super_Sprint_Passive_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B552 RID: 177490 RVA: 0x00A786C6 File Offset: 0x00A768C6
		protected GA_Super_Sprint_Passive_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017BFB RID: 97275
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Passive.GA_Super_Sprint_Passive_C";

		// Token: 0x04017BFC RID: 97276
		private static IntPtr _ClassPtr;

		// Token: 0x04017BFD RID: 97277
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017BFE RID: 97278
		internal new static int __PropertyOffset_0;

		// Token: 0x04017BFF RID: 97279
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017C00 RID: 97280
		private static IntPtr __Removed_DB9F64004F8908FEAD99D38110EAC134_NativeFunctionPtr;

		// Token: 0x04017C01 RID: 97281
		private static IntPtr __Added_21071CB943CD992BF8EFD6A351E99F1A_NativeFunctionPtr;

		// Token: 0x04017C02 RID: 97282
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017C03 RID: 97283
		private static IntPtr __ExecuteUbergraph_GA_Super_Sprint_Passive_NativeFunctionPtr;

		// Token: 0x0200A371 RID: 41841
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D38110EAC134_FunctionParams
		{
			// Token: 0x0403314E RID: 209230
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A372 RID: 41842
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A351E99F1A_FunctionParams
		{
			// Token: 0x0403314F RID: 209231
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A373 RID: 41843
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 200)]
		protected ref struct __ExecuteUbergraph_GA_Super_Sprint_Passive_FunctionParams
		{
			// Token: 0x04033150 RID: 209232
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
