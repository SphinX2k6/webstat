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
	// Token: 0x02003FE6 RID: 16358
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Stunt.GA_Motor_Stunt_C")]
	[UnrealStructLayout(1528, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1528)]
	public class GA_Motor_Stunt_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060292D5 RID: 168661 RVA: 0x00A23AA7 File Offset: 0x00A21CA7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Stunt_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Stunt.GA_Motor_Stunt_C");
			}
			return GA_Motor_Stunt_C._ClassPtr;
		}

		// Token: 0x060292D6 RID: 168662 RVA: 0x00A23ACC File Offset: 0x00A21CCC
		public GA_Motor_Stunt_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Stunt_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060292D7 RID: 168663 RVA: 0x00A23AF4 File Offset: 0x00A21CF4
		public GA_Motor_Stunt_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Stunt_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700658E RID: 25998
		// (get) Token: 0x060292D8 RID: 168664 RVA: 0x00A23B28 File Offset: 0x00A21D28
		// (set) Token: 0x060292D9 RID: 168665 RVA: 0x00A23B61 File Offset: 0x00A21D61
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Stunt_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Stunt_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700658F RID: 25999
		// (get) Token: 0x060292DA RID: 168666 RVA: 0x00A23B82 File Offset: 0x00A21D82
		// (set) Token: 0x060292DB RID: 168667 RVA: 0x00A23B96 File Offset: 0x00A21D96
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Stunt_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Stunt_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17006590 RID: 26000
		// (get) Token: 0x060292DC RID: 168668 RVA: 0x00A23BAC File Offset: 0x00A21DAC
		// (set) Token: 0x060292DD RID: 168669 RVA: 0x00A23BE5 File Offset: 0x00A21DE5
		public FMotorBoostConfig 摩托_喷射与超速配置
		{
			get
			{
				base.FastCheckIsValid();
				FMotorBoostConfig result;
				if ((result = this._摩托_喷射与超速配置) == null)
				{
					result = (this._摩托_喷射与超速配置 = new FMotorBoostConfig(base.NativePtr + (IntPtr)GA_Motor_Stunt_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FMotorBoostConfig.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Stunt_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x060292DE RID: 168670 RVA: 0x00A23C06 File Offset: 0x00A21E06
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09B0E974C3D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_C.__OnTick_CF946D5D4EFE5E5564EFF09B0E974C3D_NativeFunctionPtr, null);
		}

		// Token: 0x060292DF RID: 168671 RVA: 0x00A23C1A File Offset: 0x00A21E1A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09B0E974C3D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_C.__OnCancelled_CF946D5D4EFE5E5564EFF09B0E974C3D_NativeFunctionPtr, null);
		}

		// Token: 0x060292E0 RID: 168672 RVA: 0x00A23C2E File Offset: 0x00A21E2E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09B0E974C3D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09B0E974C3D_NativeFunctionPtr, null);
		}

		// Token: 0x060292E1 RID: 168673 RVA: 0x00A23C42 File Offset: 0x00A21E42
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09B0E974C3D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09B0E974C3D_NativeFunctionPtr, null);
		}

		// Token: 0x060292E2 RID: 168674 RVA: 0x00A23C56 File Offset: 0x00A21E56
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09B0E974C3D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_C.__OnCompleted_CF946D5D4EFE5E5564EFF09B0E974C3D_NativeFunctionPtr, null);
		}

		// Token: 0x060292E3 RID: 168675 RVA: 0x00A23C6A File Offset: 0x00A21E6A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09BC3CB17CC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_C.__OnTick_CF946D5D4EFE5E5564EFF09BC3CB17CC_NativeFunctionPtr, null);
		}

		// Token: 0x060292E4 RID: 168676 RVA: 0x00A23C7E File Offset: 0x00A21E7E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09BC3CB17CC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_C.__OnCancelled_CF946D5D4EFE5E5564EFF09BC3CB17CC_NativeFunctionPtr, null);
		}

		// Token: 0x060292E5 RID: 168677 RVA: 0x00A23C92 File Offset: 0x00A21E92
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09BC3CB17CC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09BC3CB17CC_NativeFunctionPtr, null);
		}

		// Token: 0x060292E6 RID: 168678 RVA: 0x00A23CA6 File Offset: 0x00A21EA6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09BC3CB17CC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09BC3CB17CC_NativeFunctionPtr, null);
		}

		// Token: 0x060292E7 RID: 168679 RVA: 0x00A23CBA File Offset: 0x00A21EBA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09BC3CB17CC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_C.__OnCompleted_CF946D5D4EFE5E5564EFF09BC3CB17CC_NativeFunctionPtr, null);
		}

		// Token: 0x060292E8 RID: 168680 RVA: 0x00A23CCE File Offset: 0x00A21ECE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x060292E9 RID: 168681 RVA: 0x00A23CE2 File Offset: 0x00A21EE2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Stunt_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060292EA RID: 168682 RVA: 0x00A23CF8 File Offset: 0x00A21EF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Stunt_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Stunt_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Stunt_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Stunt_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060292EB RID: 168683 RVA: 0x00A23D40 File Offset: 0x00A21F40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Stunt_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Stunt_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Stunt_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Stunt_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Stunt_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060292EC RID: 168684 RVA: 0x00A23D88 File Offset: 0x00A21F88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Stunt(int EntryPoint)
		{
			GA_Motor_Stunt_C.__ExecuteUbergraph_GA_Motor_Stunt_FunctionParams* ptr = stackalloc GA_Motor_Stunt_C.__ExecuteUbergraph_GA_Motor_Stunt_FunctionParams[(UIntPtr)719] + 15L / (long)sizeof(GA_Motor_Stunt_C.__ExecuteUbergraph_GA_Motor_Stunt_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Stunt_C.__ExecuteUbergraph_GA_Motor_Stunt_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Stunt_C.__ExecuteUbergraph_GA_Motor_Stunt_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060292ED RID: 168685 RVA: 0x00A23DD2 File Offset: 0x00A21FD2
		protected GA_Motor_Stunt_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015D5F RID: 89439
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Stunt.GA_Motor_Stunt_C";

		// Token: 0x04015D60 RID: 89440
		private static IntPtr _ClassPtr;

		// Token: 0x04015D61 RID: 89441
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015D62 RID: 89442
		internal new static int __PropertyOffset_0;

		// Token: 0x04015D63 RID: 89443
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015D64 RID: 89444
		internal new static int __PropertyOffset_1;

		// Token: 0x04015D65 RID: 89445
		internal new static int __PropertyOffset_2;

		// Token: 0x04015D66 RID: 89446
		[Nullable(2)]
		private FMotorBoostConfig _摩托_喷射与超速配置;

		// Token: 0x04015D67 RID: 89447
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09B0E974C3D_NativeFunctionPtr;

		// Token: 0x04015D68 RID: 89448
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09B0E974C3D_NativeFunctionPtr;

		// Token: 0x04015D69 RID: 89449
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09B0E974C3D_NativeFunctionPtr;

		// Token: 0x04015D6A RID: 89450
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09B0E974C3D_NativeFunctionPtr;

		// Token: 0x04015D6B RID: 89451
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09B0E974C3D_NativeFunctionPtr;

		// Token: 0x04015D6C RID: 89452
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09BC3CB17CC_NativeFunctionPtr;

		// Token: 0x04015D6D RID: 89453
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09BC3CB17CC_NativeFunctionPtr;

		// Token: 0x04015D6E RID: 89454
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09BC3CB17CC_NativeFunctionPtr;

		// Token: 0x04015D6F RID: 89455
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09BC3CB17CC_NativeFunctionPtr;

		// Token: 0x04015D70 RID: 89456
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09BC3CB17CC_NativeFunctionPtr;

		// Token: 0x04015D71 RID: 89457
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015D72 RID: 89458
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015D73 RID: 89459
		private static IntPtr __ExecuteUbergraph_GA_Motor_Stunt_NativeFunctionPtr;

		// Token: 0x0200A1F0 RID: 41456
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F4D RID: 208717
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1F1 RID: 41457
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 704)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Stunt_FunctionParams
		{
			// Token: 0x04032F4E RID: 208718
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
