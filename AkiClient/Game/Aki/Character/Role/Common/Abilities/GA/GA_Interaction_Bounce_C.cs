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
	// Token: 0x0200408B RID: 16523
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_Bounce.GA_Interaction_Bounce_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Interaction_Bounce_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AFBA RID: 176058 RVA: 0x00A6C2C0 File Offset: 0x00A6A4C0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Interaction_Bounce_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_Bounce.GA_Interaction_Bounce_C");
			}
			return GA_Interaction_Bounce_C._ClassPtr;
		}

		// Token: 0x0602AFBB RID: 176059 RVA: 0x00A6C2E4 File Offset: 0x00A6A4E4
		public GA_Interaction_Bounce_C() : this(BuiltinUtils.AllocNativeUObject(GA_Interaction_Bounce_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AFBC RID: 176060 RVA: 0x00A6C30C File Offset: 0x00A6A50C
		[NullableContext(1)]
		public GA_Interaction_Bounce_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Interaction_Bounce_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007068 RID: 28776
		// (get) Token: 0x0602AFBD RID: 176061 RVA: 0x00A6C340 File Offset: 0x00A6A540
		// (set) Token: 0x0602AFBE RID: 176062 RVA: 0x00A6C379 File Offset: 0x00A6A579
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Interaction_Bounce_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Interaction_Bounce_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007069 RID: 28777
		// (get) Token: 0x0602AFBF RID: 176063 RVA: 0x00A6C39A File Offset: 0x00A6A59A
		// (set) Token: 0x0602AFC0 RID: 176064 RVA: 0x00A6C3AE File Offset: 0x00A6A5AE
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Interaction_Bounce_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Interaction_Bounce_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602AFC1 RID: 176065 RVA: 0x00A6C3C3 File Offset: 0x00A6A5C3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E818F2F100F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Bounce_C.__OnTick_5D118C384AE61F1C80292E818F2F100F_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFC2 RID: 176066 RVA: 0x00A6C3D7 File Offset: 0x00A6A5D7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E818F2F100F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Bounce_C.__OnCancelled_5D118C384AE61F1C80292E818F2F100F_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFC3 RID: 176067 RVA: 0x00A6C3EB File Offset: 0x00A6A5EB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E818F2F100F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Bounce_C.__OnInterrupted_5D118C384AE61F1C80292E818F2F100F_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFC4 RID: 176068 RVA: 0x00A6C3FF File Offset: 0x00A6A5FF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E818F2F100F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Bounce_C.__OnBlendOut_5D118C384AE61F1C80292E818F2F100F_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFC5 RID: 176069 RVA: 0x00A6C413 File Offset: 0x00A6A613
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E818F2F100F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Bounce_C.__OnCompleted_5D118C384AE61F1C80292E818F2F100F_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFC6 RID: 176070 RVA: 0x00A6C427 File Offset: 0x00A6A627
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Bounce_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFC7 RID: 176071 RVA: 0x00A6C43B File Offset: 0x00A6A63B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_Bounce_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602AFC8 RID: 176072 RVA: 0x00A6C450 File Offset: 0x00A6A650
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Interaction_Bounce_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Interaction_Bounce_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Interaction_Bounce_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_Bounce_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Bounce_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AFC9 RID: 176073 RVA: 0x00A6C498 File Offset: 0x00A6A698
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Interaction_Bounce_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Interaction_Bounce_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Interaction_Bounce_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_Bounce_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_Bounce_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AFCA RID: 176074 RVA: 0x00A6C4E0 File Offset: 0x00A6A6E0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void MovementModeChange(ACharacter Character, EMovementMode PrevMovementMode, byte PreviousCustomMode)
		{
			GA_Interaction_Bounce_C.__MovementModeChange_FunctionParams* ptr = stackalloc GA_Interaction_Bounce_C.__MovementModeChange_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Interaction_Bounce_C.__MovementModeChange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_Bounce_C.__MovementModeChange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Character = ((Character != null) ? Character.NativePtr : IntPtr.Zero);
			ptr->PrevMovementMode = PrevMovementMode;
			ptr->PreviousCustomMode = PreviousCustomMode;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Bounce_C.__MovementModeChange_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AFCB RID: 176075 RVA: 0x00A6C548 File Offset: 0x00A6A748
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Interaction_Bounce(int EntryPoint)
		{
			GA_Interaction_Bounce_C.__ExecuteUbergraph_GA_Interaction_Bounce_FunctionParams* ptr = stackalloc GA_Interaction_Bounce_C.__ExecuteUbergraph_GA_Interaction_Bounce_FunctionParams[(UIntPtr)887] + 15L / (long)sizeof(GA_Interaction_Bounce_C.__ExecuteUbergraph_GA_Interaction_Bounce_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_Bounce_C.__ExecuteUbergraph_GA_Interaction_Bounce_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_Bounce_C.__ExecuteUbergraph_GA_Interaction_Bounce_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AFCC RID: 176076 RVA: 0x00A6C592 File Offset: 0x00A6A792
		protected GA_Interaction_Bounce_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040177DF RID: 96223
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_Bounce.GA_Interaction_Bounce_C";

		// Token: 0x040177E0 RID: 96224
		private static IntPtr _ClassPtr;

		// Token: 0x040177E1 RID: 96225
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040177E2 RID: 96226
		internal new static int __PropertyOffset_0;

		// Token: 0x040177E3 RID: 96227
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040177E4 RID: 96228
		internal new static int __PropertyOffset_1;

		// Token: 0x040177E5 RID: 96229
		private static IntPtr __OnTick_5D118C384AE61F1C80292E818F2F100F_NativeFunctionPtr;

		// Token: 0x040177E6 RID: 96230
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E818F2F100F_NativeFunctionPtr;

		// Token: 0x040177E7 RID: 96231
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E818F2F100F_NativeFunctionPtr;

		// Token: 0x040177E8 RID: 96232
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E818F2F100F_NativeFunctionPtr;

		// Token: 0x040177E9 RID: 96233
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E818F2F100F_NativeFunctionPtr;

		// Token: 0x040177EA RID: 96234
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x040177EB RID: 96235
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x040177EC RID: 96236
		private static IntPtr __MovementModeChange_NativeFunctionPtr;

		// Token: 0x040177ED RID: 96237
		private static IntPtr __ExecuteUbergraph_GA_Interaction_Bounce_NativeFunctionPtr;

		// Token: 0x0200A2B1 RID: 41649
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033065 RID: 208997
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A2B2 RID: 41650
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __MovementModeChange_FunctionParams
		{
			// Token: 0x04033066 RID: 208998
			[FieldOffset(0)]
			public IntPtr Character;

			// Token: 0x04033067 RID: 208999
			[FieldOffset(8)]
			public TEnumAsByte<EMovementMode> PrevMovementMode;

			// Token: 0x04033068 RID: 209000
			[FieldOffset(9)]
			public byte PreviousCustomMode;
		}

		// Token: 0x0200A2B3 RID: 41651
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 872)]
		protected ref struct __ExecuteUbergraph_GA_Interaction_Bounce_FunctionParams
		{
			// Token: 0x04033069 RID: 209001
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
