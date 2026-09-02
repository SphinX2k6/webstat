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
	// Token: 0x02003FE0 RID: 16352
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_RailMove_Slide.GA_Motor_RailMove_Slide_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1488)]
	public class GA_Motor_RailMove_Slide_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06029281 RID: 168577 RVA: 0x00A22D6F File Offset: 0x00A20F6F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_RailMove_Slide_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_RailMove_Slide.GA_Motor_RailMove_Slide_C");
			}
			return GA_Motor_RailMove_Slide_C._ClassPtr;
		}

		// Token: 0x06029282 RID: 168578 RVA: 0x00A22D94 File Offset: 0x00A20F94
		public GA_Motor_RailMove_Slide_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_RailMove_Slide_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06029283 RID: 168579 RVA: 0x00A22DBC File Offset: 0x00A20FBC
		[NullableContext(1)]
		public GA_Motor_RailMove_Slide_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_RailMove_Slide_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006583 RID: 25987
		// (get) Token: 0x06029284 RID: 168580 RVA: 0x00A22DF0 File Offset: 0x00A20FF0
		// (set) Token: 0x06029285 RID: 168581 RVA: 0x00A22E29 File Offset: 0x00A21029
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_RailMove_Slide_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_RailMove_Slide_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06029286 RID: 168582 RVA: 0x00A22E4C File Offset: 0x00A2104C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D3818F539AC4(in FGameplayTag Tag)
		{
			GA_Motor_RailMove_Slide_C.__Removed_DB9F64004F8908FEAD99D3818F539AC4_FunctionParams* ptr = stackalloc GA_Motor_RailMove_Slide_C.__Removed_DB9F64004F8908FEAD99D3818F539AC4_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Motor_RailMove_Slide_C.__Removed_DB9F64004F8908FEAD99D3818F539AC4_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_RailMove_Slide_C.__Removed_DB9F64004F8908FEAD99D3818F539AC4_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_RailMove_Slide_C.__Removed_DB9F64004F8908FEAD99D3818F539AC4_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06029287 RID: 168583 RVA: 0x00A22E97 File Offset: 0x00A21097
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_RailMove_Slide_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06029288 RID: 168584 RVA: 0x00A22EAB File Offset: 0x00A210AB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_RailMove_Slide_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06029289 RID: 168585 RVA: 0x00A22EC0 File Offset: 0x00A210C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_RailMove_Slide_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_RailMove_Slide_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_RailMove_Slide_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_RailMove_Slide_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_RailMove_Slide_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602928A RID: 168586 RVA: 0x00A22F08 File Offset: 0x00A21108
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_RailMove_Slide_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_RailMove_Slide_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_RailMove_Slide_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_RailMove_Slide_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_RailMove_Slide_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602928B RID: 168587 RVA: 0x00A22F50 File Offset: 0x00A21150
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_RailMove_Slide(int EntryPoint)
		{
			GA_Motor_RailMove_Slide_C.__ExecuteUbergraph_GA_Motor_RailMove_Slide_FunctionParams* ptr = stackalloc GA_Motor_RailMove_Slide_C.__ExecuteUbergraph_GA_Motor_RailMove_Slide_FunctionParams[(UIntPtr)135] + 15L / (long)sizeof(GA_Motor_RailMove_Slide_C.__ExecuteUbergraph_GA_Motor_RailMove_Slide_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_RailMove_Slide_C.__ExecuteUbergraph_GA_Motor_RailMove_Slide_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_RailMove_Slide_C.__ExecuteUbergraph_GA_Motor_RailMove_Slide_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602928C RID: 168588 RVA: 0x00A22F9A File Offset: 0x00A2119A
		protected GA_Motor_RailMove_Slide_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015D22 RID: 89378
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_RailMove_Slide.GA_Motor_RailMove_Slide_C";

		// Token: 0x04015D23 RID: 89379
		private static IntPtr _ClassPtr;

		// Token: 0x04015D24 RID: 89380
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015D25 RID: 89381
		internal new static int __PropertyOffset_0;

		// Token: 0x04015D26 RID: 89382
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015D27 RID: 89383
		private static IntPtr __Removed_DB9F64004F8908FEAD99D3818F539AC4_NativeFunctionPtr;

		// Token: 0x04015D28 RID: 89384
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015D29 RID: 89385
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015D2A RID: 89386
		private static IntPtr __ExecuteUbergraph_GA_Motor_RailMove_Slide_NativeFunctionPtr;

		// Token: 0x0200A1E2 RID: 41442
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D3818F539AC4_FunctionParams
		{
			// Token: 0x04032F3F RID: 208703
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A1E3 RID: 41443
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F40 RID: 208704
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1E4 RID: 41444
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 120)]
		protected ref struct __ExecuteUbergraph_GA_Motor_RailMove_Slide_FunctionParams
		{
			// Token: 0x04032F41 RID: 208705
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
