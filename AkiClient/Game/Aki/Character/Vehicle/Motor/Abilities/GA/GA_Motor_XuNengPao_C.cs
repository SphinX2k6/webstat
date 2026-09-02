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
	// Token: 0x02003FED RID: 16365
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_XuNengPao.GA_Motor_XuNengPao_C")]
	[UnrealStructLayout(1536, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1536)]
	public class GA_Motor_XuNengPao_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06029362 RID: 168802 RVA: 0x00A24D94 File Offset: 0x00A22F94
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_XuNengPao_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_XuNengPao.GA_Motor_XuNengPao_C");
			}
			return GA_Motor_XuNengPao_C._ClassPtr;
		}

		// Token: 0x06029363 RID: 168803 RVA: 0x00A24DB8 File Offset: 0x00A22FB8
		public GA_Motor_XuNengPao_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_XuNengPao_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06029364 RID: 168804 RVA: 0x00A24DE0 File Offset: 0x00A22FE0
		[NullableContext(1)]
		public GA_Motor_XuNengPao_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_XuNengPao_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170065A2 RID: 26018
		// (get) Token: 0x06029365 RID: 168805 RVA: 0x00A24E14 File Offset: 0x00A23014
		// (set) Token: 0x06029366 RID: 168806 RVA: 0x00A24E4D File Offset: 0x00A2304D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_XuNengPao_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_XuNengPao_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065A3 RID: 26019
		// (get) Token: 0x06029367 RID: 168807 RVA: 0x00A24E6E File Offset: 0x00A2306E
		// (set) Token: 0x06029368 RID: 168808 RVA: 0x00A24E82 File Offset: 0x00A23082
		public unsafe AActor 被控物
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_XuNengPao_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_XuNengPao_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170065A4 RID: 26020
		// (get) Token: 0x06029369 RID: 168809 RVA: 0x00A24E97 File Offset: 0x00A23097
		// (set) Token: 0x0602936A RID: 168810 RVA: 0x00A24EAB File Offset: 0x00A230AB
		public unsafe FVectorDouble NewVar_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_XuNengPao_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_XuNengPao_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170065A5 RID: 26021
		// (get) Token: 0x0602936B RID: 168811 RVA: 0x00A24EC0 File Offset: 0x00A230C0
		// (set) Token: 0x0602936C RID: 168812 RVA: 0x00A24ED4 File Offset: 0x00A230D4
		public unsafe TsBaseCharacter 驾驶员
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_XuNengPao_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_XuNengPao_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170065A6 RID: 26022
		// (get) Token: 0x0602936D RID: 168813 RVA: 0x00A24EE9 File Offset: 0x00A230E9
		// (set) Token: 0x0602936E RID: 168814 RVA: 0x00A24EFD File Offset: 0x00A230FD
		public unsafe TsBaseVehicle 施法载具
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseVehicle>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_XuNengPao_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_XuNengPao_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x0602936F RID: 168815 RVA: 0x00A24F12 File Offset: 0x00A23112
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09B63F2FC9B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_XuNengPao_C.__OnTick_CF946D5D4EFE5E5564EFF09B63F2FC9B_NativeFunctionPtr, null);
		}

		// Token: 0x06029370 RID: 168816 RVA: 0x00A24F26 File Offset: 0x00A23126
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09B63F2FC9B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_XuNengPao_C.__OnCancelled_CF946D5D4EFE5E5564EFF09B63F2FC9B_NativeFunctionPtr, null);
		}

		// Token: 0x06029371 RID: 168817 RVA: 0x00A24F3A File Offset: 0x00A2313A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09B63F2FC9B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_XuNengPao_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09B63F2FC9B_NativeFunctionPtr, null);
		}

		// Token: 0x06029372 RID: 168818 RVA: 0x00A24F4E File Offset: 0x00A2314E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09B63F2FC9B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_XuNengPao_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09B63F2FC9B_NativeFunctionPtr, null);
		}

		// Token: 0x06029373 RID: 168819 RVA: 0x00A24F62 File Offset: 0x00A23162
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09B63F2FC9B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_XuNengPao_C.__OnCompleted_CF946D5D4EFE5E5564EFF09B63F2FC9B_NativeFunctionPtr, null);
		}

		// Token: 0x06029374 RID: 168820 RVA: 0x00A24F76 File Offset: 0x00A23176
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09BF1DC2867()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_XuNengPao_C.__OnTick_CF946D5D4EFE5E5564EFF09BF1DC2867_NativeFunctionPtr, null);
		}

		// Token: 0x06029375 RID: 168821 RVA: 0x00A24F8A File Offset: 0x00A2318A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09BF1DC2867()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_XuNengPao_C.__OnCancelled_CF946D5D4EFE5E5564EFF09BF1DC2867_NativeFunctionPtr, null);
		}

		// Token: 0x06029376 RID: 168822 RVA: 0x00A24F9E File Offset: 0x00A2319E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09BF1DC2867()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_XuNengPao_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09BF1DC2867_NativeFunctionPtr, null);
		}

		// Token: 0x06029377 RID: 168823 RVA: 0x00A24FB2 File Offset: 0x00A231B2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09BF1DC2867()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_XuNengPao_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09BF1DC2867_NativeFunctionPtr, null);
		}

		// Token: 0x06029378 RID: 168824 RVA: 0x00A24FC6 File Offset: 0x00A231C6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09BF1DC2867()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_XuNengPao_C.__OnCompleted_CF946D5D4EFE5E5564EFF09BF1DC2867_NativeFunctionPtr, null);
		}

		// Token: 0x06029379 RID: 168825 RVA: 0x00A24FDA File Offset: 0x00A231DA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_XuNengPao_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602937A RID: 168826 RVA: 0x00A24FEE File Offset: 0x00A231EE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_XuNengPao_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602937B RID: 168827 RVA: 0x00A25004 File Offset: 0x00A23204
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_XuNengPao_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_XuNengPao_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_XuNengPao_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_XuNengPao_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_XuNengPao_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602937C RID: 168828 RVA: 0x00A2504C File Offset: 0x00A2324C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_XuNengPao_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_XuNengPao_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_XuNengPao_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_XuNengPao_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_XuNengPao_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602937D RID: 168829 RVA: 0x00A25094 File Offset: 0x00A23294
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_XuNengPao(int EntryPoint)
		{
			GA_Motor_XuNengPao_C.__ExecuteUbergraph_GA_Motor_XuNengPao_FunctionParams* ptr = stackalloc GA_Motor_XuNengPao_C.__ExecuteUbergraph_GA_Motor_XuNengPao_FunctionParams[(UIntPtr)1015] + 15L / (long)sizeof(GA_Motor_XuNengPao_C.__ExecuteUbergraph_GA_Motor_XuNengPao_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_XuNengPao_C.__ExecuteUbergraph_GA_Motor_XuNengPao_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_XuNengPao_C.__ExecuteUbergraph_GA_Motor_XuNengPao_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602937E RID: 168830 RVA: 0x00A250DE File Offset: 0x00A232DE
		protected GA_Motor_XuNengPao_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015DD0 RID: 89552
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_XuNengPao.GA_Motor_XuNengPao_C";

		// Token: 0x04015DD1 RID: 89553
		private static IntPtr _ClassPtr;

		// Token: 0x04015DD2 RID: 89554
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015DD3 RID: 89555
		internal new static int __PropertyOffset_0;

		// Token: 0x04015DD4 RID: 89556
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015DD5 RID: 89557
		internal new static int __PropertyOffset_1;

		// Token: 0x04015DD6 RID: 89558
		internal new static int __PropertyOffset_2;

		// Token: 0x04015DD7 RID: 89559
		internal new static int __PropertyOffset_3;

		// Token: 0x04015DD8 RID: 89560
		internal static int __PropertyOffset_4;

		// Token: 0x04015DD9 RID: 89561
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09B63F2FC9B_NativeFunctionPtr;

		// Token: 0x04015DDA RID: 89562
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09B63F2FC9B_NativeFunctionPtr;

		// Token: 0x04015DDB RID: 89563
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09B63F2FC9B_NativeFunctionPtr;

		// Token: 0x04015DDC RID: 89564
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09B63F2FC9B_NativeFunctionPtr;

		// Token: 0x04015DDD RID: 89565
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09B63F2FC9B_NativeFunctionPtr;

		// Token: 0x04015DDE RID: 89566
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09BF1DC2867_NativeFunctionPtr;

		// Token: 0x04015DDF RID: 89567
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09BF1DC2867_NativeFunctionPtr;

		// Token: 0x04015DE0 RID: 89568
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09BF1DC2867_NativeFunctionPtr;

		// Token: 0x04015DE1 RID: 89569
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09BF1DC2867_NativeFunctionPtr;

		// Token: 0x04015DE2 RID: 89570
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09BF1DC2867_NativeFunctionPtr;

		// Token: 0x04015DE3 RID: 89571
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015DE4 RID: 89572
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015DE5 RID: 89573
		private static IntPtr __ExecuteUbergraph_GA_Motor_XuNengPao_NativeFunctionPtr;

		// Token: 0x0200A1FD RID: 41469
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F5A RID: 208730
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1FE RID: 41470
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1000)]
		protected ref struct __ExecuteUbergraph_GA_Motor_XuNengPao_FunctionParams
		{
			// Token: 0x04032F5B RID: 208731
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
