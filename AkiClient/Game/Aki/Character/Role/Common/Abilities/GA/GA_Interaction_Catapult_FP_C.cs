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
	// Token: 0x0200408E RID: 16526
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_Catapult_FP.GA_Interaction_Catapult_FP_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Interaction_Catapult_FP_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AFF0 RID: 176112 RVA: 0x00A6CABF File Offset: 0x00A6ACBF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Interaction_Catapult_FP_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_Catapult_FP.GA_Interaction_Catapult_FP_C");
			}
			return GA_Interaction_Catapult_FP_C._ClassPtr;
		}

		// Token: 0x0602AFF1 RID: 176113 RVA: 0x00A6CAE4 File Offset: 0x00A6ACE4
		public GA_Interaction_Catapult_FP_C() : this(BuiltinUtils.AllocNativeUObject(GA_Interaction_Catapult_FP_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AFF2 RID: 176114 RVA: 0x00A6CB0C File Offset: 0x00A6AD0C
		[NullableContext(1)]
		public GA_Interaction_Catapult_FP_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Interaction_Catapult_FP_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700706D RID: 28781
		// (get) Token: 0x0602AFF3 RID: 176115 RVA: 0x00A6CB40 File Offset: 0x00A6AD40
		// (set) Token: 0x0602AFF4 RID: 176116 RVA: 0x00A6CB79 File Offset: 0x00A6AD79
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Interaction_Catapult_FP_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Interaction_Catapult_FP_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700706E RID: 28782
		// (get) Token: 0x0602AFF5 RID: 176117 RVA: 0x00A6CB9A File Offset: 0x00A6AD9A
		// (set) Token: 0x0602AFF6 RID: 176118 RVA: 0x00A6CBAE File Offset: 0x00A6ADAE
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Interaction_Catapult_FP_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Interaction_Catapult_FP_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602AFF7 RID: 176119 RVA: 0x00A6CBC3 File Offset: 0x00A6ADC3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E818897C20D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Catapult_FP_C.__OnTick_5D118C384AE61F1C80292E818897C20D_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFF8 RID: 176120 RVA: 0x00A6CBD7 File Offset: 0x00A6ADD7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E818897C20D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Catapult_FP_C.__OnCancelled_5D118C384AE61F1C80292E818897C20D_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFF9 RID: 176121 RVA: 0x00A6CBEB File Offset: 0x00A6ADEB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E818897C20D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Catapult_FP_C.__OnInterrupted_5D118C384AE61F1C80292E818897C20D_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFFA RID: 176122 RVA: 0x00A6CBFF File Offset: 0x00A6ADFF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E818897C20D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Catapult_FP_C.__OnBlendOut_5D118C384AE61F1C80292E818897C20D_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFFB RID: 176123 RVA: 0x00A6CC13 File Offset: 0x00A6AE13
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E818897C20D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Catapult_FP_C.__OnCompleted_5D118C384AE61F1C80292E818897C20D_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFFC RID: 176124 RVA: 0x00A6CC27 File Offset: 0x00A6AE27
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Catapult_FP_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFFD RID: 176125 RVA: 0x00A6CC3B File Offset: 0x00A6AE3B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_Catapult_FP_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602AFFE RID: 176126 RVA: 0x00A6CC50 File Offset: 0x00A6AE50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Interaction_Catapult_FP_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Interaction_Catapult_FP_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Interaction_Catapult_FP_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_Catapult_FP_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Catapult_FP_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AFFF RID: 176127 RVA: 0x00A6CC98 File Offset: 0x00A6AE98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Interaction_Catapult_FP_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Interaction_Catapult_FP_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Interaction_Catapult_FP_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_Catapult_FP_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_Catapult_FP_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B000 RID: 176128 RVA: 0x00A6CCE0 File Offset: 0x00A6AEE0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void MovementModeChange(ACharacter Character, EMovementMode PrevMovementMode, byte PreviousCustomMode)
		{
			GA_Interaction_Catapult_FP_C.__MovementModeChange_FunctionParams* ptr = stackalloc GA_Interaction_Catapult_FP_C.__MovementModeChange_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Interaction_Catapult_FP_C.__MovementModeChange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_Catapult_FP_C.__MovementModeChange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Character = ((Character != null) ? Character.NativePtr : IntPtr.Zero);
			ptr->PrevMovementMode = PrevMovementMode;
			ptr->PreviousCustomMode = PreviousCustomMode;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Catapult_FP_C.__MovementModeChange_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B001 RID: 176129 RVA: 0x00A6CD48 File Offset: 0x00A6AF48
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Interaction_Catapult_FP(int EntryPoint)
		{
			GA_Interaction_Catapult_FP_C.__ExecuteUbergraph_GA_Interaction_Catapult_FP_FunctionParams* ptr = stackalloc GA_Interaction_Catapult_FP_C.__ExecuteUbergraph_GA_Interaction_Catapult_FP_FunctionParams[(UIntPtr)911] + 15L / (long)sizeof(GA_Interaction_Catapult_FP_C.__ExecuteUbergraph_GA_Interaction_Catapult_FP_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_Catapult_FP_C.__ExecuteUbergraph_GA_Interaction_Catapult_FP_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_Catapult_FP_C.__ExecuteUbergraph_GA_Interaction_Catapult_FP_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B002 RID: 176130 RVA: 0x00A6CD92 File Offset: 0x00A6AF92
		protected GA_Interaction_Catapult_FP_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401780A RID: 96266
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_Catapult_FP.GA_Interaction_Catapult_FP_C";

		// Token: 0x0401780B RID: 96267
		private static IntPtr _ClassPtr;

		// Token: 0x0401780C RID: 96268
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401780D RID: 96269
		internal new static int __PropertyOffset_0;

		// Token: 0x0401780E RID: 96270
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401780F RID: 96271
		internal new static int __PropertyOffset_1;

		// Token: 0x04017810 RID: 96272
		private static IntPtr __OnTick_5D118C384AE61F1C80292E818897C20D_NativeFunctionPtr;

		// Token: 0x04017811 RID: 96273
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E818897C20D_NativeFunctionPtr;

		// Token: 0x04017812 RID: 96274
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E818897C20D_NativeFunctionPtr;

		// Token: 0x04017813 RID: 96275
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E818897C20D_NativeFunctionPtr;

		// Token: 0x04017814 RID: 96276
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E818897C20D_NativeFunctionPtr;

		// Token: 0x04017815 RID: 96277
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017816 RID: 96278
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017817 RID: 96279
		private static IntPtr __MovementModeChange_NativeFunctionPtr;

		// Token: 0x04017818 RID: 96280
		private static IntPtr __ExecuteUbergraph_GA_Interaction_Catapult_FP_NativeFunctionPtr;

		// Token: 0x0200A2B9 RID: 41657
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033071 RID: 209009
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A2BA RID: 41658
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __MovementModeChange_FunctionParams
		{
			// Token: 0x04033072 RID: 209010
			[FieldOffset(0)]
			public IntPtr Character;

			// Token: 0x04033073 RID: 209011
			[FieldOffset(8)]
			public TEnumAsByte<EMovementMode> PrevMovementMode;

			// Token: 0x04033074 RID: 209012
			[FieldOffset(9)]
			public byte PreviousCustomMode;
		}

		// Token: 0x0200A2BB RID: 41659
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 896)]
		protected ref struct __ExecuteUbergraph_GA_Interaction_Catapult_FP_FunctionParams
		{
			// Token: 0x04033075 RID: 209013
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
