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
	// Token: 0x02004075 RID: 16501
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_AimAttackSword_Passive.GA_AimAttackSword_Passive_C")]
	[UnrealStructLayout(1512, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1512)]
	public class GA_AimAttackSword_Passive_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AE10 RID: 175632 RVA: 0x00A68584 File Offset: 0x00A66784
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_AimAttackSword_Passive_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_AimAttackSword_Passive.GA_AimAttackSword_Passive_C");
			}
			return GA_AimAttackSword_Passive_C._ClassPtr;
		}

		// Token: 0x0602AE11 RID: 175633 RVA: 0x00A685A8 File Offset: 0x00A667A8
		public GA_AimAttackSword_Passive_C() : this(BuiltinUtils.AllocNativeUObject(GA_AimAttackSword_Passive_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AE12 RID: 175634 RVA: 0x00A685D0 File Offset: 0x00A667D0
		public GA_AimAttackSword_Passive_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_AimAttackSword_Passive_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007014 RID: 28692
		// (get) Token: 0x0602AE13 RID: 175635 RVA: 0x00A68604 File Offset: 0x00A66804
		// (set) Token: 0x0602AE14 RID: 175636 RVA: 0x00A6863D File Offset: 0x00A6683D
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_AimAttackSword_Passive_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_AimAttackSword_Passive_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007015 RID: 28693
		// (get) Token: 0x0602AE15 RID: 175637 RVA: 0x00A6865E File Offset: 0x00A6685E
		// (set) Token: 0x0602AE16 RID: 175638 RVA: 0x00A6866E File Offset: 0x00A6686E
		public unsafe int 当前剑意
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_AimAttackSword_Passive_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_AimAttackSword_Passive_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007016 RID: 28694
		// (get) Token: 0x0602AE17 RID: 175639 RVA: 0x00A6867F File Offset: 0x00A6687F
		// (set) Token: 0x0602AE18 RID: 175640 RVA: 0x00A6868F File Offset: 0x00A6688F
		public unsafe int 新剑意值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_AimAttackSword_Passive_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_AimAttackSword_Passive_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007017 RID: 28695
		// (get) Token: 0x0602AE19 RID: 175641 RVA: 0x00A686A0 File Offset: 0x00A668A0
		// (set) Token: 0x0602AE1A RID: 175642 RVA: 0x00A686D9 File Offset: 0x00A668D9
		public TArray<int> 剑buff特效ID
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._剑buff特效ID) == null)
				{
					result = (this._剑buff特效ID = new TArray<int>(base.NativePtr + (IntPtr)GA_AimAttackSword_Passive_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.剑buff特效ID.CopyAssign(value);
			}
		}

		// Token: 0x0602AE1B RID: 175643 RVA: 0x00A686E7 File Offset: 0x00A668E7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_AimAttackSword_Passive_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602AE1C RID: 175644 RVA: 0x00A686FB File Offset: 0x00A668FB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_AimAttackSword_Passive_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602AE1D RID: 175645 RVA: 0x00A68710 File Offset: 0x00A66910
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_AimAttackSword_Passive_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_AimAttackSword_Passive_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_AimAttackSword_Passive_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_AimAttackSword_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_AimAttackSword_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AE1E RID: 175646 RVA: 0x00A68758 File Offset: 0x00A66958
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_AimAttackSword_Passive_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_AimAttackSword_Passive_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_AimAttackSword_Passive_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_AimAttackSword_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_AimAttackSword_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AE1F RID: 175647 RVA: 0x00A687A0 File Offset: 0x00A669A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_AimAttackSword_Passive(int EntryPoint)
		{
			GA_AimAttackSword_Passive_C.__ExecuteUbergraph_GA_AimAttackSword_Passive_FunctionParams* ptr = stackalloc GA_AimAttackSword_Passive_C.__ExecuteUbergraph_GA_AimAttackSword_Passive_FunctionParams[(UIntPtr)151] + 15L / (long)sizeof(GA_AimAttackSword_Passive_C.__ExecuteUbergraph_GA_AimAttackSword_Passive_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_AimAttackSword_Passive_C.__ExecuteUbergraph_GA_AimAttackSword_Passive_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_AimAttackSword_Passive_C.__ExecuteUbergraph_GA_AimAttackSword_Passive_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AE20 RID: 175648 RVA: 0x00A687EA File Offset: 0x00A669EA
		protected GA_AimAttackSword_Passive_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040176A8 RID: 95912
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_AimAttackSword_Passive.GA_AimAttackSword_Passive_C";

		// Token: 0x040176A9 RID: 95913
		private static IntPtr _ClassPtr;

		// Token: 0x040176AA RID: 95914
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040176AB RID: 95915
		internal new static int __PropertyOffset_0;

		// Token: 0x040176AC RID: 95916
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040176AD RID: 95917
		internal new static int __PropertyOffset_1;

		// Token: 0x040176AE RID: 95918
		internal new static int __PropertyOffset_2;

		// Token: 0x040176AF RID: 95919
		internal new static int __PropertyOffset_3;

		// Token: 0x040176B0 RID: 95920
		[Nullable(2)]
		private TArray<int> _剑buff特效ID;

		// Token: 0x040176B1 RID: 95921
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x040176B2 RID: 95922
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x040176B3 RID: 95923
		private static IntPtr __ExecuteUbergraph_GA_AimAttackSword_Passive_NativeFunctionPtr;

		// Token: 0x0200A270 RID: 41584
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x0403301E RID: 208926
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A271 RID: 41585
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 136)]
		protected ref struct __ExecuteUbergraph_GA_AimAttackSword_Passive_FunctionParams
		{
			// Token: 0x0403301F RID: 208927
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
