using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA
{
	// Token: 0x02004375 RID: 17269
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GA/Ga_Passive.Ga_Passive_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1488)]
	public class Ga_Passive_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DBAD RID: 187309 RVA: 0x00ACA4A8 File Offset: 0x00AC86A8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (Ga_Passive_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GA/Ga_Passive.Ga_Passive_C");
			}
			return Ga_Passive_C._ClassPtr;
		}

		// Token: 0x0602DBAE RID: 187310 RVA: 0x00ACA4CC File Offset: 0x00AC86CC
		public Ga_Passive_C() : this(BuiltinUtils.AllocNativeUObject(Ga_Passive_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DBAF RID: 187311 RVA: 0x00ACA4F4 File Offset: 0x00AC86F4
		[NullableContext(1)]
		public Ga_Passive_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(Ga_Passive_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007D28 RID: 32040
		// (get) Token: 0x0602DBB0 RID: 187312 RVA: 0x00ACA528 File Offset: 0x00AC8728
		// (set) Token: 0x0602DBB1 RID: 187313 RVA: 0x00ACA561 File Offset: 0x00AC8761
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)Ga_Passive_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)Ga_Passive_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602DBB2 RID: 187314 RVA: 0x00ACA582 File Offset: 0x00AC8782
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ga_Passive_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602DBB3 RID: 187315 RVA: 0x00ACA596 File Offset: 0x00AC8796
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Ga_Passive_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602DBB4 RID: 187316 RVA: 0x00ACA5AC File Offset: 0x00AC87AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			Ga_Passive_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc Ga_Passive_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(Ga_Passive_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Ga_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ga_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DBB5 RID: 187317 RVA: 0x00ACA5F4 File Offset: 0x00AC87F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			Ga_Passive_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc Ga_Passive_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(Ga_Passive_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Ga_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Ga_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DBB6 RID: 187318 RVA: 0x00ACA63C File Offset: 0x00AC883C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_Ga_Passive(int EntryPoint)
		{
			Ga_Passive_C.__ExecuteUbergraph_Ga_Passive_FunctionParams* ptr = stackalloc Ga_Passive_C.__ExecuteUbergraph_Ga_Passive_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(Ga_Passive_C.__ExecuteUbergraph_Ga_Passive_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Ga_Passive_C.__ExecuteUbergraph_Ga_Passive_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Ga_Passive_C.__ExecuteUbergraph_Ga_Passive_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DBB7 RID: 187319 RVA: 0x00ACA683 File Offset: 0x00AC8883
		protected Ga_Passive_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019CE1 RID: 105697
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GA/Ga_Passive.Ga_Passive_C";

		// Token: 0x04019CE2 RID: 105698
		private static IntPtr _ClassPtr;

		// Token: 0x04019CE3 RID: 105699
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019CE4 RID: 105700
		internal new static int __PropertyOffset_0;

		// Token: 0x04019CE5 RID: 105701
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04019CE6 RID: 105702
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04019CE7 RID: 105703
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04019CE8 RID: 105704
		private static IntPtr __ExecuteUbergraph_Ga_Passive_NativeFunctionPtr;

		// Token: 0x0200A590 RID: 42384
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x040334E3 RID: 210147
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A591 RID: 42385
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_Ga_Passive_FunctionParams
		{
			// Token: 0x040334E4 RID: 210148
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
