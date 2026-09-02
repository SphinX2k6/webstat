using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Monster.Common.Abilities.GA
{
	// Token: 0x020041A0 RID: 16800
	[UnrealObjectPath("/Game/Aki/Character/Monster/Common/Abilities/GA/GA_Monster_Base.GA_Monster_Base_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Monster_Base_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C971 RID: 182641 RVA: 0x00AA742F File Offset: 0x00AA562F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Monster_Base_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Monster/Common/Abilities/GA/GA_Monster_Base.GA_Monster_Base_C");
			}
			return GA_Monster_Base_C._ClassPtr;
		}

		// Token: 0x0602C972 RID: 182642 RVA: 0x00AA7454 File Offset: 0x00AA5654
		public GA_Monster_Base_C() : this(BuiltinUtils.AllocNativeUObject(GA_Monster_Base_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C973 RID: 182643 RVA: 0x00AA747C File Offset: 0x00AA567C
		[NullableContext(1)]
		public GA_Monster_Base_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Monster_Base_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007830 RID: 30768
		// (get) Token: 0x0602C974 RID: 182644 RVA: 0x00AA74B0 File Offset: 0x00AA56B0
		// (set) Token: 0x0602C975 RID: 182645 RVA: 0x00AA74E9 File Offset: 0x00AA56E9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Monster_Base_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Monster_Base_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007831 RID: 30769
		// (get) Token: 0x0602C976 RID: 182646 RVA: 0x00AA750A File Offset: 0x00AA570A
		// (set) Token: 0x0602C977 RID: 182647 RVA: 0x00AA751E File Offset: 0x00AA571E
		[Nullable(2)]
		public unsafe TsBaseCharacter 施法者_0
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Monster_Base_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Monster_Base_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602C978 RID: 182648 RVA: 0x00AA7533 File Offset: 0x00AA5733
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Monster_Base_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602C979 RID: 182649 RVA: 0x00AA7547 File Offset: 0x00AA5747
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Monster_Base_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C97A RID: 182650 RVA: 0x00AA755C File Offset: 0x00AA575C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Monster_Base_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Monster_Base_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Monster_Base_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Monster_Base_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Monster_Base_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C97B RID: 182651 RVA: 0x00AA75A4 File Offset: 0x00AA57A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Monster_Base_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Monster_Base_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Monster_Base_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Monster_Base_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Monster_Base_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C97C RID: 182652 RVA: 0x00AA75EC File Offset: 0x00AA57EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Monster_Base(int EntryPoint)
		{
			GA_Monster_Base_C.__ExecuteUbergraph_GA_Monster_Base_FunctionParams* ptr = stackalloc GA_Monster_Base_C.__ExecuteUbergraph_GA_Monster_Base_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(GA_Monster_Base_C.__ExecuteUbergraph_GA_Monster_Base_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Monster_Base_C.__ExecuteUbergraph_GA_Monster_Base_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Monster_Base_C.__ExecuteUbergraph_GA_Monster_Base_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C97D RID: 182653 RVA: 0x00AA7633 File Offset: 0x00AA5833
		protected GA_Monster_Base_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018CEE RID: 101614
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Monster/Common/Abilities/GA/GA_Monster_Base.GA_Monster_Base_C";

		// Token: 0x04018CEF RID: 101615
		private static IntPtr _ClassPtr;

		// Token: 0x04018CF0 RID: 101616
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018CF1 RID: 101617
		internal new static int __PropertyOffset_0;

		// Token: 0x04018CF2 RID: 101618
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04018CF3 RID: 101619
		internal new static int __PropertyOffset_1;

		// Token: 0x04018CF4 RID: 101620
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04018CF5 RID: 101621
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04018CF6 RID: 101622
		private static IntPtr __ExecuteUbergraph_GA_Monster_Base_NativeFunctionPtr;

		// Token: 0x0200A462 RID: 42082
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033265 RID: 209509
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A463 RID: 42083
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __ExecuteUbergraph_GA_Monster_Base_FunctionParams
		{
			// Token: 0x04033266 RID: 209510
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
