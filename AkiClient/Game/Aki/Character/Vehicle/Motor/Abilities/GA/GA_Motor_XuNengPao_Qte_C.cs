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
	// Token: 0x02003FEE RID: 16366
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_XuNengPao_Qte.GA_Motor_XuNengPao_Qte_C")]
	[UnrealStructLayout(1536, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1536)]
	public class GA_Motor_XuNengPao_Qte_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602937F RID: 168831 RVA: 0x00A250E7 File Offset: 0x00A232E7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_XuNengPao_Qte_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_XuNengPao_Qte.GA_Motor_XuNengPao_Qte_C");
			}
			return GA_Motor_XuNengPao_Qte_C._ClassPtr;
		}

		// Token: 0x06029380 RID: 168832 RVA: 0x00A2510C File Offset: 0x00A2330C
		public GA_Motor_XuNengPao_Qte_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_XuNengPao_Qte_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06029381 RID: 168833 RVA: 0x00A25134 File Offset: 0x00A23334
		[NullableContext(1)]
		public GA_Motor_XuNengPao_Qte_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_XuNengPao_Qte_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170065A7 RID: 26023
		// (get) Token: 0x06029382 RID: 168834 RVA: 0x00A25168 File Offset: 0x00A23368
		// (set) Token: 0x06029383 RID: 168835 RVA: 0x00A251A1 File Offset: 0x00A233A1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_XuNengPao_Qte_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_XuNengPao_Qte_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065A8 RID: 26024
		// (get) Token: 0x06029384 RID: 168836 RVA: 0x00A251C2 File Offset: 0x00A233C2
		// (set) Token: 0x06029385 RID: 168837 RVA: 0x00A251D6 File Offset: 0x00A233D6
		public unsafe AActor 被控物
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_XuNengPao_Qte_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_XuNengPao_Qte_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170065A9 RID: 26025
		// (get) Token: 0x06029386 RID: 168838 RVA: 0x00A251EB File Offset: 0x00A233EB
		// (set) Token: 0x06029387 RID: 168839 RVA: 0x00A251FF File Offset: 0x00A233FF
		public unsafe FVectorDouble NewVar_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_XuNengPao_Qte_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_XuNengPao_Qte_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170065AA RID: 26026
		// (get) Token: 0x06029388 RID: 168840 RVA: 0x00A25214 File Offset: 0x00A23414
		// (set) Token: 0x06029389 RID: 168841 RVA: 0x00A25228 File Offset: 0x00A23428
		public unsafe TsBaseCharacter 驾驶员
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_XuNengPao_Qte_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_XuNengPao_Qte_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170065AB RID: 26027
		// (get) Token: 0x0602938A RID: 168842 RVA: 0x00A2523D File Offset: 0x00A2343D
		// (set) Token: 0x0602938B RID: 168843 RVA: 0x00A25251 File Offset: 0x00A23451
		public unsafe TsBaseVehicle 施法载具
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseVehicle>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_XuNengPao_Qte_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_XuNengPao_Qte_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x0602938C RID: 168844 RVA: 0x00A25266 File Offset: 0x00A23466
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09B5ADA6A96()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_XuNengPao_Qte_C.__OnTick_CF946D5D4EFE5E5564EFF09B5ADA6A96_NativeFunctionPtr, null);
		}

		// Token: 0x0602938D RID: 168845 RVA: 0x00A2527A File Offset: 0x00A2347A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09B5ADA6A96()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_XuNengPao_Qte_C.__OnCancelled_CF946D5D4EFE5E5564EFF09B5ADA6A96_NativeFunctionPtr, null);
		}

		// Token: 0x0602938E RID: 168846 RVA: 0x00A2528E File Offset: 0x00A2348E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09B5ADA6A96()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_XuNengPao_Qte_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09B5ADA6A96_NativeFunctionPtr, null);
		}

		// Token: 0x0602938F RID: 168847 RVA: 0x00A252A2 File Offset: 0x00A234A2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09B5ADA6A96()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_XuNengPao_Qte_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09B5ADA6A96_NativeFunctionPtr, null);
		}

		// Token: 0x06029390 RID: 168848 RVA: 0x00A252B6 File Offset: 0x00A234B6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09B5ADA6A96()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_XuNengPao_Qte_C.__OnCompleted_CF946D5D4EFE5E5564EFF09B5ADA6A96_NativeFunctionPtr, null);
		}

		// Token: 0x06029391 RID: 168849 RVA: 0x00A252CA File Offset: 0x00A234CA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09B366C8F75()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_XuNengPao_Qte_C.__OnTick_CF946D5D4EFE5E5564EFF09B366C8F75_NativeFunctionPtr, null);
		}

		// Token: 0x06029392 RID: 168850 RVA: 0x00A252DE File Offset: 0x00A234DE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09B366C8F75()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_XuNengPao_Qte_C.__OnCancelled_CF946D5D4EFE5E5564EFF09B366C8F75_NativeFunctionPtr, null);
		}

		// Token: 0x06029393 RID: 168851 RVA: 0x00A252F2 File Offset: 0x00A234F2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09B366C8F75()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_XuNengPao_Qte_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09B366C8F75_NativeFunctionPtr, null);
		}

		// Token: 0x06029394 RID: 168852 RVA: 0x00A25306 File Offset: 0x00A23506
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09B366C8F75()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_XuNengPao_Qte_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09B366C8F75_NativeFunctionPtr, null);
		}

		// Token: 0x06029395 RID: 168853 RVA: 0x00A2531A File Offset: 0x00A2351A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09B366C8F75()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_XuNengPao_Qte_C.__OnCompleted_CF946D5D4EFE5E5564EFF09B366C8F75_NativeFunctionPtr, null);
		}

		// Token: 0x06029396 RID: 168854 RVA: 0x00A2532E File Offset: 0x00A2352E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_XuNengPao_Qte_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06029397 RID: 168855 RVA: 0x00A25342 File Offset: 0x00A23542
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_XuNengPao_Qte_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06029398 RID: 168856 RVA: 0x00A25358 File Offset: 0x00A23558
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_XuNengPao_Qte_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_XuNengPao_Qte_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_XuNengPao_Qte_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_XuNengPao_Qte_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_XuNengPao_Qte_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06029399 RID: 168857 RVA: 0x00A253A0 File Offset: 0x00A235A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_XuNengPao_Qte_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_XuNengPao_Qte_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_XuNengPao_Qte_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_XuNengPao_Qte_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_XuNengPao_Qte_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602939A RID: 168858 RVA: 0x00A253E8 File Offset: 0x00A235E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_XuNengPao_Qte(int EntryPoint)
		{
			GA_Motor_XuNengPao_Qte_C.__ExecuteUbergraph_GA_Motor_XuNengPao_Qte_FunctionParams* ptr = stackalloc GA_Motor_XuNengPao_Qte_C.__ExecuteUbergraph_GA_Motor_XuNengPao_Qte_FunctionParams[(UIntPtr)959] + 15L / (long)sizeof(GA_Motor_XuNengPao_Qte_C.__ExecuteUbergraph_GA_Motor_XuNengPao_Qte_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_XuNengPao_Qte_C.__ExecuteUbergraph_GA_Motor_XuNengPao_Qte_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_XuNengPao_Qte_C.__ExecuteUbergraph_GA_Motor_XuNengPao_Qte_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602939B RID: 168859 RVA: 0x00A25432 File Offset: 0x00A23632
		protected GA_Motor_XuNengPao_Qte_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015DE6 RID: 89574
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_XuNengPao_Qte.GA_Motor_XuNengPao_Qte_C";

		// Token: 0x04015DE7 RID: 89575
		private static IntPtr _ClassPtr;

		// Token: 0x04015DE8 RID: 89576
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015DE9 RID: 89577
		internal new static int __PropertyOffset_0;

		// Token: 0x04015DEA RID: 89578
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015DEB RID: 89579
		internal new static int __PropertyOffset_1;

		// Token: 0x04015DEC RID: 89580
		internal new static int __PropertyOffset_2;

		// Token: 0x04015DED RID: 89581
		internal new static int __PropertyOffset_3;

		// Token: 0x04015DEE RID: 89582
		internal static int __PropertyOffset_4;

		// Token: 0x04015DEF RID: 89583
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09B5ADA6A96_NativeFunctionPtr;

		// Token: 0x04015DF0 RID: 89584
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09B5ADA6A96_NativeFunctionPtr;

		// Token: 0x04015DF1 RID: 89585
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09B5ADA6A96_NativeFunctionPtr;

		// Token: 0x04015DF2 RID: 89586
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09B5ADA6A96_NativeFunctionPtr;

		// Token: 0x04015DF3 RID: 89587
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09B5ADA6A96_NativeFunctionPtr;

		// Token: 0x04015DF4 RID: 89588
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09B366C8F75_NativeFunctionPtr;

		// Token: 0x04015DF5 RID: 89589
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09B366C8F75_NativeFunctionPtr;

		// Token: 0x04015DF6 RID: 89590
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09B366C8F75_NativeFunctionPtr;

		// Token: 0x04015DF7 RID: 89591
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09B366C8F75_NativeFunctionPtr;

		// Token: 0x04015DF8 RID: 89592
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09B366C8F75_NativeFunctionPtr;

		// Token: 0x04015DF9 RID: 89593
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015DFA RID: 89594
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015DFB RID: 89595
		private static IntPtr __ExecuteUbergraph_GA_Motor_XuNengPao_Qte_NativeFunctionPtr;

		// Token: 0x0200A1FF RID: 41471
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F5C RID: 208732
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A200 RID: 41472
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 944)]
		protected ref struct __ExecuteUbergraph_GA_Motor_XuNengPao_Qte_FunctionParams
		{
			// Token: 0x04032F5D RID: 208733
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
