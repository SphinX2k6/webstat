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
	// Token: 0x02004078 RID: 16504
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_CommonBurst.GA_CommonBurst_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1492)]
	public class GA_CommonBurst_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AE47 RID: 175687 RVA: 0x00A68CC7 File Offset: 0x00A66EC7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_CommonBurst_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_CommonBurst.GA_CommonBurst_C");
			}
			return GA_CommonBurst_C._ClassPtr;
		}

		// Token: 0x0602AE48 RID: 175688 RVA: 0x00A68CEC File Offset: 0x00A66EEC
		public GA_CommonBurst_C() : this(BuiltinUtils.AllocNativeUObject(GA_CommonBurst_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AE49 RID: 175689 RVA: 0x00A68D14 File Offset: 0x00A66F14
		[NullableContext(1)]
		public GA_CommonBurst_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_CommonBurst_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007020 RID: 28704
		// (get) Token: 0x0602AE4A RID: 175690 RVA: 0x00A68D48 File Offset: 0x00A66F48
		// (set) Token: 0x0602AE4B RID: 175691 RVA: 0x00A68D81 File Offset: 0x00A66F81
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_CommonBurst_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_CommonBurst_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007021 RID: 28705
		// (get) Token: 0x0602AE4C RID: 175692 RVA: 0x00A68DA2 File Offset: 0x00A66FA2
		// (set) Token: 0x0602AE4D RID: 175693 RVA: 0x00A68DB2 File Offset: 0x00A66FB2
		public unsafe float 原来质量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_CommonBurst_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_CommonBurst_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x0602AE4E RID: 175694 RVA: 0x00A68DC3 File Offset: 0x00A66FC3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E81DADDF27C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonBurst_C.__OnTick_5D118C384AE61F1C80292E81DADDF27C_NativeFunctionPtr, null);
		}

		// Token: 0x0602AE4F RID: 175695 RVA: 0x00A68DD7 File Offset: 0x00A66FD7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E81DADDF27C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonBurst_C.__OnCancelled_5D118C384AE61F1C80292E81DADDF27C_NativeFunctionPtr, null);
		}

		// Token: 0x0602AE50 RID: 175696 RVA: 0x00A68DEB File Offset: 0x00A66FEB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E81DADDF27C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonBurst_C.__OnInterrupted_5D118C384AE61F1C80292E81DADDF27C_NativeFunctionPtr, null);
		}

		// Token: 0x0602AE51 RID: 175697 RVA: 0x00A68DFF File Offset: 0x00A66FFF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E81DADDF27C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonBurst_C.__OnBlendOut_5D118C384AE61F1C80292E81DADDF27C_NativeFunctionPtr, null);
		}

		// Token: 0x0602AE52 RID: 175698 RVA: 0x00A68E13 File Offset: 0x00A67013
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E81DADDF27C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonBurst_C.__OnCompleted_5D118C384AE61F1C80292E81DADDF27C_NativeFunctionPtr, null);
		}

		// Token: 0x0602AE53 RID: 175699 RVA: 0x00A68E27 File Offset: 0x00A67027
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonBurst_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602AE54 RID: 175700 RVA: 0x00A68E3B File Offset: 0x00A6703B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_CommonBurst_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602AE55 RID: 175701 RVA: 0x00A68E50 File Offset: 0x00A67050
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_CommonBurst_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_CommonBurst_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_CommonBurst_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonBurst_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonBurst_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AE56 RID: 175702 RVA: 0x00A68E98 File Offset: 0x00A67098
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_CommonBurst_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_CommonBurst_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_CommonBurst_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonBurst_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_CommonBurst_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AE57 RID: 175703 RVA: 0x00A68EE0 File Offset: 0x00A670E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_CommonBurst(int EntryPoint)
		{
			GA_CommonBurst_C.__ExecuteUbergraph_GA_CommonBurst_FunctionParams* ptr = stackalloc GA_CommonBurst_C.__ExecuteUbergraph_GA_CommonBurst_FunctionParams[(UIntPtr)775] + 15L / (long)sizeof(GA_CommonBurst_C.__ExecuteUbergraph_GA_CommonBurst_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonBurst_C.__ExecuteUbergraph_GA_CommonBurst_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_CommonBurst_C.__ExecuteUbergraph_GA_CommonBurst_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AE58 RID: 175704 RVA: 0x00A68F2A File Offset: 0x00A6712A
		protected GA_CommonBurst_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040176D1 RID: 95953
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_CommonBurst.GA_CommonBurst_C";

		// Token: 0x040176D2 RID: 95954
		private static IntPtr _ClassPtr;

		// Token: 0x040176D3 RID: 95955
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040176D4 RID: 95956
		internal new static int __PropertyOffset_0;

		// Token: 0x040176D5 RID: 95957
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040176D6 RID: 95958
		internal new static int __PropertyOffset_1;

		// Token: 0x040176D7 RID: 95959
		private static IntPtr __OnTick_5D118C384AE61F1C80292E81DADDF27C_NativeFunctionPtr;

		// Token: 0x040176D8 RID: 95960
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E81DADDF27C_NativeFunctionPtr;

		// Token: 0x040176D9 RID: 95961
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E81DADDF27C_NativeFunctionPtr;

		// Token: 0x040176DA RID: 95962
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E81DADDF27C_NativeFunctionPtr;

		// Token: 0x040176DB RID: 95963
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E81DADDF27C_NativeFunctionPtr;

		// Token: 0x040176DC RID: 95964
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x040176DD RID: 95965
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x040176DE RID: 95966
		private static IntPtr __ExecuteUbergraph_GA_CommonBurst_NativeFunctionPtr;

		// Token: 0x0200A275 RID: 41589
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033023 RID: 208931
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A276 RID: 41590
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 760)]
		protected ref struct __ExecuteUbergraph_GA_CommonBurst_FunctionParams
		{
			// Token: 0x04033024 RID: 208932
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
