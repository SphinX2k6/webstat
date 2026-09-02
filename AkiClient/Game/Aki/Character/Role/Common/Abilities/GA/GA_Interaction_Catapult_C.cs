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
	// Token: 0x0200408D RID: 16525
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_Catapult.GA_Interaction_Catapult_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Interaction_Catapult_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AFD8 RID: 176088 RVA: 0x00A6C780 File Offset: 0x00A6A980
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Interaction_Catapult_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_Catapult.GA_Interaction_Catapult_C");
			}
			return GA_Interaction_Catapult_C._ClassPtr;
		}

		// Token: 0x0602AFD9 RID: 176089 RVA: 0x00A6C7A4 File Offset: 0x00A6A9A4
		public GA_Interaction_Catapult_C() : this(BuiltinUtils.AllocNativeUObject(GA_Interaction_Catapult_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AFDA RID: 176090 RVA: 0x00A6C7CC File Offset: 0x00A6A9CC
		[NullableContext(1)]
		public GA_Interaction_Catapult_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Interaction_Catapult_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700706B RID: 28779
		// (get) Token: 0x0602AFDB RID: 176091 RVA: 0x00A6C800 File Offset: 0x00A6AA00
		// (set) Token: 0x0602AFDC RID: 176092 RVA: 0x00A6C839 File Offset: 0x00A6AA39
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Interaction_Catapult_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Interaction_Catapult_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700706C RID: 28780
		// (get) Token: 0x0602AFDD RID: 176093 RVA: 0x00A6C85A File Offset: 0x00A6AA5A
		// (set) Token: 0x0602AFDE RID: 176094 RVA: 0x00A6C86E File Offset: 0x00A6AA6E
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Interaction_Catapult_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Interaction_Catapult_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602AFDF RID: 176095 RVA: 0x00A6C883 File Offset: 0x00A6AA83
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E810BF3ED21()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Catapult_C.__OnTick_5D118C384AE61F1C80292E810BF3ED21_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFE0 RID: 176096 RVA: 0x00A6C897 File Offset: 0x00A6AA97
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E810BF3ED21()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Catapult_C.__OnCancelled_5D118C384AE61F1C80292E810BF3ED21_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFE1 RID: 176097 RVA: 0x00A6C8AB File Offset: 0x00A6AAAB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E810BF3ED21()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Catapult_C.__OnInterrupted_5D118C384AE61F1C80292E810BF3ED21_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFE2 RID: 176098 RVA: 0x00A6C8BF File Offset: 0x00A6AABF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E810BF3ED21()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Catapult_C.__OnBlendOut_5D118C384AE61F1C80292E810BF3ED21_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFE3 RID: 176099 RVA: 0x00A6C8D3 File Offset: 0x00A6AAD3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E810BF3ED21()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Catapult_C.__OnCompleted_5D118C384AE61F1C80292E810BF3ED21_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFE4 RID: 176100 RVA: 0x00A6C8E7 File Offset: 0x00A6AAE7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E81BB40C26D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Catapult_C.__OnTick_5D118C384AE61F1C80292E81BB40C26D_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFE5 RID: 176101 RVA: 0x00A6C8FB File Offset: 0x00A6AAFB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E81BB40C26D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Catapult_C.__OnCancelled_5D118C384AE61F1C80292E81BB40C26D_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFE6 RID: 176102 RVA: 0x00A6C90F File Offset: 0x00A6AB0F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E81BB40C26D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Catapult_C.__OnInterrupted_5D118C384AE61F1C80292E81BB40C26D_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFE7 RID: 176103 RVA: 0x00A6C923 File Offset: 0x00A6AB23
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E81BB40C26D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Catapult_C.__OnBlendOut_5D118C384AE61F1C80292E81BB40C26D_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFE8 RID: 176104 RVA: 0x00A6C937 File Offset: 0x00A6AB37
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E81BB40C26D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Catapult_C.__OnCompleted_5D118C384AE61F1C80292E81BB40C26D_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFE9 RID: 176105 RVA: 0x00A6C94B File Offset: 0x00A6AB4B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Catapult_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFEA RID: 176106 RVA: 0x00A6C95F File Offset: 0x00A6AB5F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_Catapult_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602AFEB RID: 176107 RVA: 0x00A6C974 File Offset: 0x00A6AB74
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Interaction_Catapult_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Interaction_Catapult_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Interaction_Catapult_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_Catapult_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Catapult_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AFEC RID: 176108 RVA: 0x00A6C9BC File Offset: 0x00A6ABBC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Interaction_Catapult_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Interaction_Catapult_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Interaction_Catapult_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_Catapult_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_Catapult_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AFED RID: 176109 RVA: 0x00A6CA04 File Offset: 0x00A6AC04
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void MovementModeChange(ACharacter Character, EMovementMode PrevMovementMode, byte PreviousCustomMode)
		{
			GA_Interaction_Catapult_C.__MovementModeChange_FunctionParams* ptr = stackalloc GA_Interaction_Catapult_C.__MovementModeChange_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Interaction_Catapult_C.__MovementModeChange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_Catapult_C.__MovementModeChange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Character = ((Character != null) ? Character.NativePtr : IntPtr.Zero);
			ptr->PrevMovementMode = PrevMovementMode;
			ptr->PreviousCustomMode = PreviousCustomMode;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Catapult_C.__MovementModeChange_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AFEE RID: 176110 RVA: 0x00A6CA6C File Offset: 0x00A6AC6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Interaction_Catapult(int EntryPoint)
		{
			GA_Interaction_Catapult_C.__ExecuteUbergraph_GA_Interaction_Catapult_FunctionParams* ptr = stackalloc GA_Interaction_Catapult_C.__ExecuteUbergraph_GA_Interaction_Catapult_FunctionParams[(UIntPtr)1703] + 15L / (long)sizeof(GA_Interaction_Catapult_C.__ExecuteUbergraph_GA_Interaction_Catapult_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_Catapult_C.__ExecuteUbergraph_GA_Interaction_Catapult_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_Catapult_C.__ExecuteUbergraph_GA_Interaction_Catapult_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AFEF RID: 176111 RVA: 0x00A6CAB6 File Offset: 0x00A6ACB6
		protected GA_Interaction_Catapult_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040177F6 RID: 96246
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_Catapult.GA_Interaction_Catapult_C";

		// Token: 0x040177F7 RID: 96247
		private static IntPtr _ClassPtr;

		// Token: 0x040177F8 RID: 96248
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040177F9 RID: 96249
		internal new static int __PropertyOffset_0;

		// Token: 0x040177FA RID: 96250
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040177FB RID: 96251
		internal new static int __PropertyOffset_1;

		// Token: 0x040177FC RID: 96252
		private static IntPtr __OnTick_5D118C384AE61F1C80292E810BF3ED21_NativeFunctionPtr;

		// Token: 0x040177FD RID: 96253
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E810BF3ED21_NativeFunctionPtr;

		// Token: 0x040177FE RID: 96254
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E810BF3ED21_NativeFunctionPtr;

		// Token: 0x040177FF RID: 96255
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E810BF3ED21_NativeFunctionPtr;

		// Token: 0x04017800 RID: 96256
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E810BF3ED21_NativeFunctionPtr;

		// Token: 0x04017801 RID: 96257
		private static IntPtr __OnTick_5D118C384AE61F1C80292E81BB40C26D_NativeFunctionPtr;

		// Token: 0x04017802 RID: 96258
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E81BB40C26D_NativeFunctionPtr;

		// Token: 0x04017803 RID: 96259
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E81BB40C26D_NativeFunctionPtr;

		// Token: 0x04017804 RID: 96260
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E81BB40C26D_NativeFunctionPtr;

		// Token: 0x04017805 RID: 96261
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E81BB40C26D_NativeFunctionPtr;

		// Token: 0x04017806 RID: 96262
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017807 RID: 96263
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017808 RID: 96264
		private static IntPtr __MovementModeChange_NativeFunctionPtr;

		// Token: 0x04017809 RID: 96265
		private static IntPtr __ExecuteUbergraph_GA_Interaction_Catapult_NativeFunctionPtr;

		// Token: 0x0200A2B6 RID: 41654
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x0403306C RID: 209004
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A2B7 RID: 41655
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __MovementModeChange_FunctionParams
		{
			// Token: 0x0403306D RID: 209005
			[FieldOffset(0)]
			public IntPtr Character;

			// Token: 0x0403306E RID: 209006
			[FieldOffset(8)]
			public TEnumAsByte<EMovementMode> PrevMovementMode;

			// Token: 0x0403306F RID: 209007
			[FieldOffset(9)]
			public byte PreviousCustomMode;
		}

		// Token: 0x0200A2B8 RID: 41656
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1688)]
		protected ref struct __ExecuteUbergraph_GA_Interaction_Catapult_FunctionParams
		{
			// Token: 0x04033070 RID: 209008
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
