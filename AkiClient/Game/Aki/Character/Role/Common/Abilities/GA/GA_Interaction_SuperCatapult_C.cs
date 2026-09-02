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
	// Token: 0x02004096 RID: 16534
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_SuperCatapult.GA_Interaction_SuperCatapult_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Interaction_SuperCatapult_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B064 RID: 176228 RVA: 0x00A6DAD4 File Offset: 0x00A6BCD4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Interaction_SuperCatapult_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_SuperCatapult.GA_Interaction_SuperCatapult_C");
			}
			return GA_Interaction_SuperCatapult_C._ClassPtr;
		}

		// Token: 0x0602B065 RID: 176229 RVA: 0x00A6DAF8 File Offset: 0x00A6BCF8
		public GA_Interaction_SuperCatapult_C() : this(BuiltinUtils.AllocNativeUObject(GA_Interaction_SuperCatapult_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B066 RID: 176230 RVA: 0x00A6DB20 File Offset: 0x00A6BD20
		[NullableContext(1)]
		public GA_Interaction_SuperCatapult_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Interaction_SuperCatapult_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700707A RID: 28794
		// (get) Token: 0x0602B067 RID: 176231 RVA: 0x00A6DB54 File Offset: 0x00A6BD54
		// (set) Token: 0x0602B068 RID: 176232 RVA: 0x00A6DB8D File Offset: 0x00A6BD8D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Interaction_SuperCatapult_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Interaction_SuperCatapult_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700707B RID: 28795
		// (get) Token: 0x0602B069 RID: 176233 RVA: 0x00A6DBAE File Offset: 0x00A6BDAE
		// (set) Token: 0x0602B06A RID: 176234 RVA: 0x00A6DBC2 File Offset: 0x00A6BDC2
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Interaction_SuperCatapult_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Interaction_SuperCatapult_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602B06B RID: 176235 RVA: 0x00A6DBD7 File Offset: 0x00A6BDD7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E8128E8D714()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_SuperCatapult_C.__OnTick_5D118C384AE61F1C80292E8128E8D714_NativeFunctionPtr, null);
		}

		// Token: 0x0602B06C RID: 176236 RVA: 0x00A6DBEB File Offset: 0x00A6BDEB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E8128E8D714()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_SuperCatapult_C.__OnCancelled_5D118C384AE61F1C80292E8128E8D714_NativeFunctionPtr, null);
		}

		// Token: 0x0602B06D RID: 176237 RVA: 0x00A6DBFF File Offset: 0x00A6BDFF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E8128E8D714()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_SuperCatapult_C.__OnInterrupted_5D118C384AE61F1C80292E8128E8D714_NativeFunctionPtr, null);
		}

		// Token: 0x0602B06E RID: 176238 RVA: 0x00A6DC13 File Offset: 0x00A6BE13
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E8128E8D714()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_SuperCatapult_C.__OnBlendOut_5D118C384AE61F1C80292E8128E8D714_NativeFunctionPtr, null);
		}

		// Token: 0x0602B06F RID: 176239 RVA: 0x00A6DC27 File Offset: 0x00A6BE27
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E8128E8D714()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_SuperCatapult_C.__OnCompleted_5D118C384AE61F1C80292E8128E8D714_NativeFunctionPtr, null);
		}

		// Token: 0x0602B070 RID: 176240 RVA: 0x00A6DC3B File Offset: 0x00A6BE3B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_SuperCatapult_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B071 RID: 176241 RVA: 0x00A6DC4F File Offset: 0x00A6BE4F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_SuperCatapult_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B072 RID: 176242 RVA: 0x00A6DC64 File Offset: 0x00A6BE64
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Interaction_SuperCatapult_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Interaction_SuperCatapult_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Interaction_SuperCatapult_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_SuperCatapult_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_SuperCatapult_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B073 RID: 176243 RVA: 0x00A6DCAC File Offset: 0x00A6BEAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Interaction_SuperCatapult_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Interaction_SuperCatapult_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Interaction_SuperCatapult_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_SuperCatapult_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_SuperCatapult_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B074 RID: 176244 RVA: 0x00A6DCF4 File Offset: 0x00A6BEF4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void MovementModeChange(ACharacter Character, EMovementMode PrevMovementMode, byte PreviousCustomMode)
		{
			GA_Interaction_SuperCatapult_C.__MovementModeChange_FunctionParams* ptr = stackalloc GA_Interaction_SuperCatapult_C.__MovementModeChange_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Interaction_SuperCatapult_C.__MovementModeChange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_SuperCatapult_C.__MovementModeChange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Character = ((Character != null) ? Character.NativePtr : IntPtr.Zero);
			ptr->PrevMovementMode = PrevMovementMode;
			ptr->PreviousCustomMode = PreviousCustomMode;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_SuperCatapult_C.__MovementModeChange_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B075 RID: 176245 RVA: 0x00A6DD5C File Offset: 0x00A6BF5C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Interaction_SuperCatapult(int EntryPoint)
		{
			GA_Interaction_SuperCatapult_C.__ExecuteUbergraph_GA_Interaction_SuperCatapult_FunctionParams* ptr = stackalloc GA_Interaction_SuperCatapult_C.__ExecuteUbergraph_GA_Interaction_SuperCatapult_FunctionParams[(UIntPtr)887] + 15L / (long)sizeof(GA_Interaction_SuperCatapult_C.__ExecuteUbergraph_GA_Interaction_SuperCatapult_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_SuperCatapult_C.__ExecuteUbergraph_GA_Interaction_SuperCatapult_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_SuperCatapult_C.__ExecuteUbergraph_GA_Interaction_SuperCatapult_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B076 RID: 176246 RVA: 0x00A6DDA6 File Offset: 0x00A6BFA6
		protected GA_Interaction_SuperCatapult_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017865 RID: 96357
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_SuperCatapult.GA_Interaction_SuperCatapult_C";

		// Token: 0x04017866 RID: 96358
		private static IntPtr _ClassPtr;

		// Token: 0x04017867 RID: 96359
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017868 RID: 96360
		internal new static int __PropertyOffset_0;

		// Token: 0x04017869 RID: 96361
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401786A RID: 96362
		internal new static int __PropertyOffset_1;

		// Token: 0x0401786B RID: 96363
		private static IntPtr __OnTick_5D118C384AE61F1C80292E8128E8D714_NativeFunctionPtr;

		// Token: 0x0401786C RID: 96364
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E8128E8D714_NativeFunctionPtr;

		// Token: 0x0401786D RID: 96365
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E8128E8D714_NativeFunctionPtr;

		// Token: 0x0401786E RID: 96366
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E8128E8D714_NativeFunctionPtr;

		// Token: 0x0401786F RID: 96367
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E8128E8D714_NativeFunctionPtr;

		// Token: 0x04017870 RID: 96368
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017871 RID: 96369
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017872 RID: 96370
		private static IntPtr __MovementModeChange_NativeFunctionPtr;

		// Token: 0x04017873 RID: 96371
		private static IntPtr __ExecuteUbergraph_GA_Interaction_SuperCatapult_NativeFunctionPtr;

		// Token: 0x0200A2C6 RID: 41670
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033080 RID: 209024
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A2C7 RID: 41671
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __MovementModeChange_FunctionParams
		{
			// Token: 0x04033081 RID: 209025
			[FieldOffset(0)]
			public IntPtr Character;

			// Token: 0x04033082 RID: 209026
			[FieldOffset(8)]
			public TEnumAsByte<EMovementMode> PrevMovementMode;

			// Token: 0x04033083 RID: 209027
			[FieldOffset(9)]
			public byte PreviousCustomMode;
		}

		// Token: 0x0200A2C8 RID: 41672
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 872)]
		protected ref struct __ExecuteUbergraph_GA_Interaction_SuperCatapult_FunctionParams
		{
			// Token: 0x04033084 RID: 209028
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
