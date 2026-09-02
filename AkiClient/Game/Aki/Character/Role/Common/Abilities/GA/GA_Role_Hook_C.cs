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
	// Token: 0x020040AB RID: 16555
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_Hook.GA_Role_Hook_C")]
	[UnrealStructLayout(1552, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1552)]
	public class GA_Role_Hook_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B28D RID: 176781 RVA: 0x00A7224B File Offset: 0x00A7044B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Role_Hook_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_Hook.GA_Role_Hook_C");
			}
			return GA_Role_Hook_C._ClassPtr;
		}

		// Token: 0x0602B28E RID: 176782 RVA: 0x00A72270 File Offset: 0x00A70470
		public GA_Role_Hook_C() : this(BuiltinUtils.AllocNativeUObject(GA_Role_Hook_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B28F RID: 176783 RVA: 0x00A72298 File Offset: 0x00A70498
		[NullableContext(1)]
		public GA_Role_Hook_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Role_Hook_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170070F4 RID: 28916
		// (get) Token: 0x0602B290 RID: 176784 RVA: 0x00A722CC File Offset: 0x00A704CC
		// (set) Token: 0x0602B291 RID: 176785 RVA: 0x00A72305 File Offset: 0x00A70505
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Role_Hook_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_Hook_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170070F5 RID: 28917
		// (get) Token: 0x0602B292 RID: 176786 RVA: 0x00A72326 File Offset: 0x00A70526
		// (set) Token: 0x0602B293 RID: 176787 RVA: 0x00A7233A File Offset: 0x00A7053A
		[Nullable(2)]
		public unsafe TsBaseCharacter 角色
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_Hook_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_Hook_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170070F6 RID: 28918
		// (get) Token: 0x0602B294 RID: 176788 RVA: 0x00A7234F File Offset: 0x00A7054F
		// (set) Token: 0x0602B295 RID: 176789 RVA: 0x00A72363 File Offset: 0x00A70563
		public unsafe FVector Forward
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_Hook_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_Hook_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170070F7 RID: 28919
		// (get) Token: 0x0602B296 RID: 176790 RVA: 0x00A72378 File Offset: 0x00A70578
		// (set) Token: 0x0602B297 RID: 176791 RVA: 0x00A7238C File Offset: 0x00A7058C
		public unsafe FVector EndPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_Hook_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_Hook_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170070F8 RID: 28920
		// (get) Token: 0x0602B298 RID: 176792 RVA: 0x00A723A1 File Offset: 0x00A705A1
		// (set) Token: 0x0602B299 RID: 176793 RVA: 0x00A723B1 File Offset: 0x00A705B1
		public unsafe bool InWater
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_Hook_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_Hook_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x170070F9 RID: 28921
		// (get) Token: 0x0602B29A RID: 176794 RVA: 0x00A723C2 File Offset: 0x00A705C2
		// (set) Token: 0x0602B29B RID: 176795 RVA: 0x00A723D6 File Offset: 0x00A705D6
		public unsafe FVectorDouble LastLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_Hook_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_Hook_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x0602B29C RID: 176796 RVA: 0x00A723EC File Offset: 0x00A705EC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EventReceived_BE49D8B84159B3E2C93AFC8C33E21F9B(FGameplayEventData Payload)
		{
			GA_Role_Hook_C.__EventReceived_BE49D8B84159B3E2C93AFC8C33E21F9B_FunctionParams* ptr = stackalloc GA_Role_Hook_C.__EventReceived_BE49D8B84159B3E2C93AFC8C33E21F9B_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(GA_Role_Hook_C.__EventReceived_BE49D8B84159B3E2C93AFC8C33E21F9B_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Hook_C.__EventReceived_BE49D8B84159B3E2C93AFC8C33E21F9B_NativeFunctionPtr, (void*)ptr, 1);
			if (Payload != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayEventData.StaticStruct(), &ptr->Payload, Payload.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Hook_C.__EventReceived_BE49D8B84159B3E2C93AFC8C33E21F9B_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Role_Hook_C.__EventReceived_BE49D8B84159B3E2C93AFC8C33E21F9B_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602B29D RID: 176797 RVA: 0x00A72461 File Offset: 0x00A70661
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E813209EC9F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Hook_C.__OnTick_5D118C384AE61F1C80292E813209EC9F_NativeFunctionPtr, null);
		}

		// Token: 0x0602B29E RID: 176798 RVA: 0x00A72475 File Offset: 0x00A70675
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E813209EC9F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Hook_C.__OnCancelled_5D118C384AE61F1C80292E813209EC9F_NativeFunctionPtr, null);
		}

		// Token: 0x0602B29F RID: 176799 RVA: 0x00A72489 File Offset: 0x00A70689
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E813209EC9F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Hook_C.__OnInterrupted_5D118C384AE61F1C80292E813209EC9F_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2A0 RID: 176800 RVA: 0x00A7249D File Offset: 0x00A7069D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E813209EC9F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Hook_C.__OnBlendOut_5D118C384AE61F1C80292E813209EC9F_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2A1 RID: 176801 RVA: 0x00A724B1 File Offset: 0x00A706B1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E813209EC9F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Hook_C.__OnCompleted_5D118C384AE61F1C80292E813209EC9F_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2A2 RID: 176802 RVA: 0x00A724C5 File Offset: 0x00A706C5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Hook_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2A3 RID: 176803 RVA: 0x00A724D9 File Offset: 0x00A706D9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_Hook_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B2A4 RID: 176804 RVA: 0x00A724F0 File Offset: 0x00A706F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Role_Hook_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_Hook_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_Hook_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Hook_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Hook_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B2A5 RID: 176805 RVA: 0x00A72538 File Offset: 0x00A70738
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Role_Hook_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_Hook_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_Hook_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Hook_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_Hook_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B2A6 RID: 176806 RVA: 0x00A72580 File Offset: 0x00A70780
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Role_Hook(int EntryPoint)
		{
			GA_Role_Hook_C.__ExecuteUbergraph_GA_Role_Hook_FunctionParams* ptr = stackalloc GA_Role_Hook_C.__ExecuteUbergraph_GA_Role_Hook_FunctionParams[(UIntPtr)1583] + 15L / (long)sizeof(GA_Role_Hook_C.__ExecuteUbergraph_GA_Role_Hook_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Hook_C.__ExecuteUbergraph_GA_Role_Hook_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_Hook_C.__ExecuteUbergraph_GA_Role_Hook_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B2A7 RID: 176807 RVA: 0x00A725CA File Offset: 0x00A707CA
		protected GA_Role_Hook_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040179F9 RID: 96761
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_Hook.GA_Role_Hook_C";

		// Token: 0x040179FA RID: 96762
		private static IntPtr _ClassPtr;

		// Token: 0x040179FB RID: 96763
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040179FC RID: 96764
		internal new static int __PropertyOffset_0;

		// Token: 0x040179FD RID: 96765
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040179FE RID: 96766
		internal new static int __PropertyOffset_1;

		// Token: 0x040179FF RID: 96767
		internal new static int __PropertyOffset_2;

		// Token: 0x04017A00 RID: 96768
		internal new static int __PropertyOffset_3;

		// Token: 0x04017A01 RID: 96769
		internal static int __PropertyOffset_4;

		// Token: 0x04017A02 RID: 96770
		internal static int __PropertyOffset_5;

		// Token: 0x04017A03 RID: 96771
		private static IntPtr __EventReceived_BE49D8B84159B3E2C93AFC8C33E21F9B_NativeFunctionPtr;

		// Token: 0x04017A04 RID: 96772
		private static IntPtr __OnTick_5D118C384AE61F1C80292E813209EC9F_NativeFunctionPtr;

		// Token: 0x04017A05 RID: 96773
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E813209EC9F_NativeFunctionPtr;

		// Token: 0x04017A06 RID: 96774
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E813209EC9F_NativeFunctionPtr;

		// Token: 0x04017A07 RID: 96775
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E813209EC9F_NativeFunctionPtr;

		// Token: 0x04017A08 RID: 96776
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E813209EC9F_NativeFunctionPtr;

		// Token: 0x04017A09 RID: 96777
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017A0A RID: 96778
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017A0B RID: 96779
		private static IntPtr __ExecuteUbergraph_GA_Role_Hook_NativeFunctionPtr;

		// Token: 0x0200A304 RID: 41732
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __EventReceived_BE49D8B84159B3E2C93AFC8C33E21F9B_FunctionParams
		{
			// Token: 0x040330D1 RID: 209105
			[FieldOffset(0)]
			public byte Payload;
		}

		// Token: 0x0200A305 RID: 41733
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x040330D2 RID: 209106
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A306 RID: 41734
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1568)]
		protected ref struct __ExecuteUbergraph_GA_Role_Hook_FunctionParams
		{
			// Token: 0x040330D3 RID: 209107
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
