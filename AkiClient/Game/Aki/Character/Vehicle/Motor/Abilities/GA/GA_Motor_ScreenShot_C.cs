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
	// Token: 0x02003FE2 RID: 16354
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_ScreenShot.GA_Motor_ScreenShot_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Motor_ScreenShot_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602929A RID: 168602 RVA: 0x00A231B0 File Offset: 0x00A213B0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_ScreenShot_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_ScreenShot.GA_Motor_ScreenShot_C");
			}
			return GA_Motor_ScreenShot_C._ClassPtr;
		}

		// Token: 0x0602929B RID: 168603 RVA: 0x00A231D4 File Offset: 0x00A213D4
		public GA_Motor_ScreenShot_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_ScreenShot_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602929C RID: 168604 RVA: 0x00A231FC File Offset: 0x00A213FC
		[NullableContext(1)]
		public GA_Motor_ScreenShot_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_ScreenShot_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006586 RID: 25990
		// (get) Token: 0x0602929D RID: 168605 RVA: 0x00A23230 File Offset: 0x00A21430
		// (set) Token: 0x0602929E RID: 168606 RVA: 0x00A23269 File Offset: 0x00A21469
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_ScreenShot_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_ScreenShot_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006587 RID: 25991
		// (get) Token: 0x0602929F RID: 168607 RVA: 0x00A2328A File Offset: 0x00A2148A
		// (set) Token: 0x060292A0 RID: 168608 RVA: 0x00A2329E File Offset: 0x00A2149E
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_ScreenShot_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_ScreenShot_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x060292A1 RID: 168609 RVA: 0x00A232B3 File Offset: 0x00A214B3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_ScreenShot_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x060292A2 RID: 168610 RVA: 0x00A232C7 File Offset: 0x00A214C7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_ScreenShot_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060292A3 RID: 168611 RVA: 0x00A232DC File Offset: 0x00A214DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_ScreenShot_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_ScreenShot_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_ScreenShot_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_ScreenShot_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_ScreenShot_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060292A4 RID: 168612 RVA: 0x00A23324 File Offset: 0x00A21524
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_ScreenShot_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_ScreenShot_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_ScreenShot_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_ScreenShot_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_ScreenShot_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060292A5 RID: 168613 RVA: 0x00A2336C File Offset: 0x00A2156C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_ScreenShot(int EntryPoint)
		{
			GA_Motor_ScreenShot_C.__ExecuteUbergraph_GA_Motor_ScreenShot_FunctionParams* ptr = stackalloc GA_Motor_ScreenShot_C.__ExecuteUbergraph_GA_Motor_ScreenShot_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Motor_ScreenShot_C.__ExecuteUbergraph_GA_Motor_ScreenShot_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_ScreenShot_C.__ExecuteUbergraph_GA_Motor_ScreenShot_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_ScreenShot_C.__ExecuteUbergraph_GA_Motor_ScreenShot_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060292A6 RID: 168614 RVA: 0x00A233B3 File Offset: 0x00A215B3
		protected GA_Motor_ScreenShot_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015D34 RID: 89396
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_ScreenShot.GA_Motor_ScreenShot_C";

		// Token: 0x04015D35 RID: 89397
		private static IntPtr _ClassPtr;

		// Token: 0x04015D36 RID: 89398
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015D37 RID: 89399
		internal new static int __PropertyOffset_0;

		// Token: 0x04015D38 RID: 89400
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015D39 RID: 89401
		internal new static int __PropertyOffset_1;

		// Token: 0x04015D3A RID: 89402
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015D3B RID: 89403
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015D3C RID: 89404
		private static IntPtr __ExecuteUbergraph_GA_Motor_ScreenShot_NativeFunctionPtr;

		// Token: 0x0200A1E7 RID: 41447
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F44 RID: 208708
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1E8 RID: 41448
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_GA_Motor_ScreenShot_FunctionParams
		{
			// Token: 0x04032F45 RID: 208709
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
