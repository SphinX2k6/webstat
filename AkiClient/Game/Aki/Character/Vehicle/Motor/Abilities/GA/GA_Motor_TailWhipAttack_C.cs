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
	// Token: 0x02003FEB RID: 16363
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_TailWhipAttack.GA_Motor_TailWhipAttack_C")]
	[UnrealStructLayout(1504, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1501)]
	public class GA_Motor_TailWhipAttack_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602933E RID: 168766 RVA: 0x00A2491B File Offset: 0x00A22B1B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_TailWhipAttack_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_TailWhipAttack.GA_Motor_TailWhipAttack_C");
			}
			return GA_Motor_TailWhipAttack_C._ClassPtr;
		}

		// Token: 0x0602933F RID: 168767 RVA: 0x00A24940 File Offset: 0x00A22B40
		public GA_Motor_TailWhipAttack_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_TailWhipAttack_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06029340 RID: 168768 RVA: 0x00A24968 File Offset: 0x00A22B68
		public GA_Motor_TailWhipAttack_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_TailWhipAttack_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700659D RID: 26013
		// (get) Token: 0x06029341 RID: 168769 RVA: 0x00A2499C File Offset: 0x00A22B9C
		// (set) Token: 0x06029342 RID: 168770 RVA: 0x00A249D5 File Offset: 0x00A22BD5
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_TailWhipAttack_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_TailWhipAttack_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700659E RID: 26014
		// (get) Token: 0x06029343 RID: 168771 RVA: 0x00A249F6 File Offset: 0x00A22BF6
		// (set) Token: 0x06029344 RID: 168772 RVA: 0x00A24A0A File Offset: 0x00A22C0A
		public unsafe FRotator x轴清零旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_TailWhipAttack_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_TailWhipAttack_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700659F RID: 26015
		// (get) Token: 0x06029345 RID: 168773 RVA: 0x00A24A1F File Offset: 0x00A22C1F
		// (set) Token: 0x06029346 RID: 168774 RVA: 0x00A24A2F File Offset: 0x00A22C2F
		public unsafe bool 重力不平行摩托朝向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_TailWhipAttack_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_TailWhipAttack_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x06029347 RID: 168775 RVA: 0x00A24A40 File Offset: 0x00A22C40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09B69F3D2A9()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_TailWhipAttack_C.__OnTick_CF946D5D4EFE5E5564EFF09B69F3D2A9_NativeFunctionPtr, null);
		}

		// Token: 0x06029348 RID: 168776 RVA: 0x00A24A54 File Offset: 0x00A22C54
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09B69F3D2A9()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_TailWhipAttack_C.__OnCancelled_CF946D5D4EFE5E5564EFF09B69F3D2A9_NativeFunctionPtr, null);
		}

		// Token: 0x06029349 RID: 168777 RVA: 0x00A24A68 File Offset: 0x00A22C68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09B69F3D2A9()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_TailWhipAttack_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09B69F3D2A9_NativeFunctionPtr, null);
		}

		// Token: 0x0602934A RID: 168778 RVA: 0x00A24A7C File Offset: 0x00A22C7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09B69F3D2A9()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_TailWhipAttack_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09B69F3D2A9_NativeFunctionPtr, null);
		}

		// Token: 0x0602934B RID: 168779 RVA: 0x00A24A90 File Offset: 0x00A22C90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09B69F3D2A9()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_TailWhipAttack_C.__OnCompleted_CF946D5D4EFE5E5564EFF09B69F3D2A9_NativeFunctionPtr, null);
		}

		// Token: 0x0602934C RID: 168780 RVA: 0x00A24AA4 File Offset: 0x00A22CA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09B304CB930()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_TailWhipAttack_C.__OnTick_CF946D5D4EFE5E5564EFF09B304CB930_NativeFunctionPtr, null);
		}

		// Token: 0x0602934D RID: 168781 RVA: 0x00A24AB8 File Offset: 0x00A22CB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09B304CB930()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_TailWhipAttack_C.__OnCancelled_CF946D5D4EFE5E5564EFF09B304CB930_NativeFunctionPtr, null);
		}

		// Token: 0x0602934E RID: 168782 RVA: 0x00A24ACC File Offset: 0x00A22CCC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09B304CB930()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_TailWhipAttack_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09B304CB930_NativeFunctionPtr, null);
		}

		// Token: 0x0602934F RID: 168783 RVA: 0x00A24AE0 File Offset: 0x00A22CE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09B304CB930()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_TailWhipAttack_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09B304CB930_NativeFunctionPtr, null);
		}

		// Token: 0x06029350 RID: 168784 RVA: 0x00A24AF4 File Offset: 0x00A22CF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09B304CB930()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_TailWhipAttack_C.__OnCompleted_CF946D5D4EFE5E5564EFF09B304CB930_NativeFunctionPtr, null);
		}

		// Token: 0x06029351 RID: 168785 RVA: 0x00A24B08 File Offset: 0x00A22D08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_TailWhipAttack_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06029352 RID: 168786 RVA: 0x00A24B1C File Offset: 0x00A22D1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_TailWhipAttack_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06029353 RID: 168787 RVA: 0x00A24B34 File Offset: 0x00A22D34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_TailWhipAttack(int EntryPoint)
		{
			GA_Motor_TailWhipAttack_C.__ExecuteUbergraph_GA_Motor_TailWhipAttack_FunctionParams* ptr = stackalloc GA_Motor_TailWhipAttack_C.__ExecuteUbergraph_GA_Motor_TailWhipAttack_FunctionParams[(UIntPtr)799] + 15L / (long)sizeof(GA_Motor_TailWhipAttack_C.__ExecuteUbergraph_GA_Motor_TailWhipAttack_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_TailWhipAttack_C.__ExecuteUbergraph_GA_Motor_TailWhipAttack_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_TailWhipAttack_C.__ExecuteUbergraph_GA_Motor_TailWhipAttack_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029354 RID: 168788 RVA: 0x00A24B7E File Offset: 0x00A22D7E
		protected GA_Motor_TailWhipAttack_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015DB4 RID: 89524
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_TailWhipAttack.GA_Motor_TailWhipAttack_C";

		// Token: 0x04015DB5 RID: 89525
		private static IntPtr _ClassPtr;

		// Token: 0x04015DB6 RID: 89526
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015DB7 RID: 89527
		internal new static int __PropertyOffset_0;

		// Token: 0x04015DB8 RID: 89528
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015DB9 RID: 89529
		internal new static int __PropertyOffset_1;

		// Token: 0x04015DBA RID: 89530
		internal new static int __PropertyOffset_2;

		// Token: 0x04015DBB RID: 89531
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09B69F3D2A9_NativeFunctionPtr;

		// Token: 0x04015DBC RID: 89532
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09B69F3D2A9_NativeFunctionPtr;

		// Token: 0x04015DBD RID: 89533
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09B69F3D2A9_NativeFunctionPtr;

		// Token: 0x04015DBE RID: 89534
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09B69F3D2A9_NativeFunctionPtr;

		// Token: 0x04015DBF RID: 89535
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09B69F3D2A9_NativeFunctionPtr;

		// Token: 0x04015DC0 RID: 89536
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09B304CB930_NativeFunctionPtr;

		// Token: 0x04015DC1 RID: 89537
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09B304CB930_NativeFunctionPtr;

		// Token: 0x04015DC2 RID: 89538
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09B304CB930_NativeFunctionPtr;

		// Token: 0x04015DC3 RID: 89539
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09B304CB930_NativeFunctionPtr;

		// Token: 0x04015DC4 RID: 89540
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09B304CB930_NativeFunctionPtr;

		// Token: 0x04015DC5 RID: 89541
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015DC6 RID: 89542
		private static IntPtr __ExecuteUbergraph_GA_Motor_TailWhipAttack_NativeFunctionPtr;

		// Token: 0x0200A1FA RID: 41466
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 784)]
		protected ref struct __ExecuteUbergraph_GA_Motor_TailWhipAttack_FunctionParams
		{
			// Token: 0x04032F57 RID: 208727
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
