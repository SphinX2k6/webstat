using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.FemaleM.Xiakong.Abilities.GA
{
	// Token: 0x02003FF5 RID: 16373
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/FemaleM/Xiakong/Abilities/GA/GA_Xiakong_Burst.GA_Xiakong_Burst_C")]
	[UnrealStructLayout(1520, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1520)]
	public class GA_Xiakong_Burst_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060296C7 RID: 169671 RVA: 0x00A2DC0C File Offset: 0x00A2BE0C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Xiakong_Burst_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/FemaleM/Xiakong/Abilities/GA/GA_Xiakong_Burst.GA_Xiakong_Burst_C");
			}
			return GA_Xiakong_Burst_C._ClassPtr;
		}

		// Token: 0x060296C8 RID: 169672 RVA: 0x00A2DC30 File Offset: 0x00A2BE30
		public GA_Xiakong_Burst_C() : this(BuiltinUtils.AllocNativeUObject(GA_Xiakong_Burst_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060296C9 RID: 169673 RVA: 0x00A2DC58 File Offset: 0x00A2BE58
		[NullableContext(1)]
		public GA_Xiakong_Burst_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Xiakong_Burst_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006704 RID: 26372
		// (get) Token: 0x060296CA RID: 169674 RVA: 0x00A2DC8C File Offset: 0x00A2BE8C
		// (set) Token: 0x060296CB RID: 169675 RVA: 0x00A2DCC5 File Offset: 0x00A2BEC5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Xiakong_Burst_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Xiakong_Burst_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006705 RID: 26373
		// (get) Token: 0x060296CC RID: 169676 RVA: 0x00A2DCE6 File Offset: 0x00A2BEE6
		// (set) Token: 0x060296CD RID: 169677 RVA: 0x00A2DCF6 File Offset: 0x00A2BEF6
		public unsafe int 夏空
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Xiakong_Burst_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Xiakong_Burst_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17006706 RID: 26374
		// (get) Token: 0x060296CE RID: 169678 RVA: 0x00A2DD07 File Offset: 0x00A2BF07
		// (set) Token: 0x060296CF RID: 169679 RVA: 0x00A2DD17 File Offset: 0x00A2BF17
		public unsafe bool IsInterrupt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Xiakong_Burst_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Xiakong_Burst_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006707 RID: 26375
		// (get) Token: 0x060296D0 RID: 169680 RVA: 0x00A2DD28 File Offset: 0x00A2BF28
		// (set) Token: 0x060296D1 RID: 169681 RVA: 0x00A2DD3C File Offset: 0x00A2BF3C
		public unsafe UAkAudioEvent Ak_Event01
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Xiakong_Burst_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Xiakong_Burst_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17006708 RID: 26376
		// (get) Token: 0x060296D2 RID: 169682 RVA: 0x00A2DD51 File Offset: 0x00A2BF51
		// (set) Token: 0x060296D3 RID: 169683 RVA: 0x00A2DD65 File Offset: 0x00A2BF65
		public unsafe UAkAudioEvent 目标
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Xiakong_Burst_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Xiakong_Burst_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17006709 RID: 26377
		// (get) Token: 0x060296D4 RID: 169684 RVA: 0x00A2DD7A File Offset: 0x00A2BF7A
		// (set) Token: 0x060296D5 RID: 169685 RVA: 0x00A2DD8E File Offset: 0x00A2BF8E
		public unsafe UAkAudioEvent Ak_Event02
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Xiakong_Burst_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Xiakong_Burst_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x060296D6 RID: 169686 RVA: 0x00A2DDA3 File Offset: 0x00A2BFA3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Buff校验()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Xiakong_Burst_C.__Buff校验_NativeFunctionPtr, null);
		}

		// Token: 0x060296D7 RID: 169687 RVA: 0x00A2DDB8 File Offset: 0x00A2BFB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetIsInterrupt(bool value)
		{
			GA_Xiakong_Burst_C.__SetIsInterrupt_FunctionParams* ptr = stackalloc GA_Xiakong_Burst_C.__SetIsInterrupt_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Xiakong_Burst_C.__SetIsInterrupt_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Xiakong_Burst_C.__SetIsInterrupt_NativeFunctionPtr, (void*)ptr, 1);
			ptr->value = value;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Xiakong_Burst_C.__SetIsInterrupt_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060296D8 RID: 169688 RVA: 0x00A2DE00 File Offset: 0x00A2C000
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 判定结果(bool 是否成功, bool 是否后台自动判定, int 颜色类型)
		{
			GA_Xiakong_Burst_C.__判定结果_FunctionParams* ptr = stackalloc GA_Xiakong_Burst_C.__判定结果_FunctionParams[(UIntPtr)247] + 15L / (long)sizeof(GA_Xiakong_Burst_C.__判定结果_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Xiakong_Burst_C.__判定结果_NativeFunctionPtr, (void*)ptr, 1);
			ptr->是否成功 = 是否成功;
			ptr->是否后台自动判定 = 是否后台自动判定;
			ptr->颜色类型 = 颜色类型;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Xiakong_Burst_C.__判定结果_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060296D9 RID: 169689 RVA: 0x00A2DE57 File Offset: 0x00A2C057
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E812B331739()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Xiakong_Burst_C.__OnTick_5D118C384AE61F1C80292E812B331739_NativeFunctionPtr, null);
		}

		// Token: 0x060296DA RID: 169690 RVA: 0x00A2DE6B File Offset: 0x00A2C06B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E812B331739()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Xiakong_Burst_C.__OnCancelled_5D118C384AE61F1C80292E812B331739_NativeFunctionPtr, null);
		}

		// Token: 0x060296DB RID: 169691 RVA: 0x00A2DE7F File Offset: 0x00A2C07F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E812B331739()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Xiakong_Burst_C.__OnInterrupted_5D118C384AE61F1C80292E812B331739_NativeFunctionPtr, null);
		}

		// Token: 0x060296DC RID: 169692 RVA: 0x00A2DE93 File Offset: 0x00A2C093
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E812B331739()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Xiakong_Burst_C.__OnBlendOut_5D118C384AE61F1C80292E812B331739_NativeFunctionPtr, null);
		}

		// Token: 0x060296DD RID: 169693 RVA: 0x00A2DEA7 File Offset: 0x00A2C0A7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E812B331739()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Xiakong_Burst_C.__OnCompleted_5D118C384AE61F1C80292E812B331739_NativeFunctionPtr, null);
		}

		// Token: 0x060296DE RID: 169694 RVA: 0x00A2DEBB File Offset: 0x00A2C0BB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Xiakong_Burst_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x060296DF RID: 169695 RVA: 0x00A2DECF File Offset: 0x00A2C0CF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Xiakong_Burst_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060296E0 RID: 169696 RVA: 0x00A2DEE4 File Offset: 0x00A2C0E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Xiakong_Burst_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Xiakong_Burst_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Xiakong_Burst_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Xiakong_Burst_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Xiakong_Burst_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060296E1 RID: 169697 RVA: 0x00A2DF2C File Offset: 0x00A2C12C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Xiakong_Burst_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Xiakong_Burst_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Xiakong_Burst_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Xiakong_Burst_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Xiakong_Burst_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060296E2 RID: 169698 RVA: 0x00A2DF74 File Offset: 0x00A2C174
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Xiakong_Burst(int EntryPoint)
		{
			GA_Xiakong_Burst_C.__ExecuteUbergraph_GA_Xiakong_Burst_FunctionParams* ptr = stackalloc GA_Xiakong_Burst_C.__ExecuteUbergraph_GA_Xiakong_Burst_FunctionParams[(UIntPtr)871] + 15L / (long)sizeof(GA_Xiakong_Burst_C.__ExecuteUbergraph_GA_Xiakong_Burst_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Xiakong_Burst_C.__ExecuteUbergraph_GA_Xiakong_Burst_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Xiakong_Burst_C.__ExecuteUbergraph_GA_Xiakong_Burst_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060296E3 RID: 169699 RVA: 0x00A2DFBE File Offset: 0x00A2C1BE
		protected GA_Xiakong_Burst_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04016112 RID: 90386
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/FemaleM/Xiakong/Abilities/GA/GA_Xiakong_Burst.GA_Xiakong_Burst_C";

		// Token: 0x04016113 RID: 90387
		private static IntPtr _ClassPtr;

		// Token: 0x04016114 RID: 90388
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04016115 RID: 90389
		internal new static int __PropertyOffset_0;

		// Token: 0x04016116 RID: 90390
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04016117 RID: 90391
		internal new static int __PropertyOffset_1;

		// Token: 0x04016118 RID: 90392
		internal new static int __PropertyOffset_2;

		// Token: 0x04016119 RID: 90393
		internal new static int __PropertyOffset_3;

		// Token: 0x0401611A RID: 90394
		internal static int __PropertyOffset_4;

		// Token: 0x0401611B RID: 90395
		internal static int __PropertyOffset_5;

		// Token: 0x0401611C RID: 90396
		private static IntPtr __Buff校验_NativeFunctionPtr;

		// Token: 0x0401611D RID: 90397
		private static IntPtr __SetIsInterrupt_NativeFunctionPtr;

		// Token: 0x0401611E RID: 90398
		private static IntPtr __判定结果_NativeFunctionPtr;

		// Token: 0x0401611F RID: 90399
		private static IntPtr __OnTick_5D118C384AE61F1C80292E812B331739_NativeFunctionPtr;

		// Token: 0x04016120 RID: 90400
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E812B331739_NativeFunctionPtr;

		// Token: 0x04016121 RID: 90401
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E812B331739_NativeFunctionPtr;

		// Token: 0x04016122 RID: 90402
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E812B331739_NativeFunctionPtr;

		// Token: 0x04016123 RID: 90403
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E812B331739_NativeFunctionPtr;

		// Token: 0x04016124 RID: 90404
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04016125 RID: 90405
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04016126 RID: 90406
		private static IntPtr __ExecuteUbergraph_GA_Xiakong_Burst_NativeFunctionPtr;

		// Token: 0x0200A209 RID: 41481
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __SetIsInterrupt_FunctionParams
		{
			// Token: 0x04032F70 RID: 208752
			[FieldOffset(0)]
			public bool value;
		}

		// Token: 0x0200A20A RID: 41482
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 232)]
		protected ref struct __判定结果_FunctionParams
		{
			// Token: 0x04032F71 RID: 208753
			[FieldOffset(0)]
			public bool 是否成功;

			// Token: 0x04032F72 RID: 208754
			[FieldOffset(1)]
			public bool 是否后台自动判定;

			// Token: 0x04032F73 RID: 208755
			[FieldOffset(4)]
			public int 颜色类型;
		}

		// Token: 0x0200A20B RID: 41483
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F74 RID: 208756
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A20C RID: 41484
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 856)]
		protected ref struct __ExecuteUbergraph_GA_Xiakong_Burst_FunctionParams
		{
			// Token: 0x04032F75 RID: 208757
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
