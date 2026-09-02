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
	// Token: 0x02003FCB RID: 16331
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Exit_Fly.GA_Motor_Exit_Fly_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Motor_Exit_Fly_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06029011 RID: 167953 RVA: 0x00A1E150 File Offset: 0x00A1C350
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Exit_Fly_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Exit_Fly.GA_Motor_Exit_Fly_C");
			}
			return GA_Motor_Exit_Fly_C._ClassPtr;
		}

		// Token: 0x06029012 RID: 167954 RVA: 0x00A1E174 File Offset: 0x00A1C374
		public GA_Motor_Exit_Fly_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Exit_Fly_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06029013 RID: 167955 RVA: 0x00A1E19C File Offset: 0x00A1C39C
		[NullableContext(1)]
		public GA_Motor_Exit_Fly_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Exit_Fly_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006509 RID: 25865
		// (get) Token: 0x06029014 RID: 167956 RVA: 0x00A1E1D0 File Offset: 0x00A1C3D0
		// (set) Token: 0x06029015 RID: 167957 RVA: 0x00A1E209 File Offset: 0x00A1C409
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Exit_Fly_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Exit_Fly_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700650A RID: 25866
		// (get) Token: 0x06029016 RID: 167958 RVA: 0x00A1E22A File Offset: 0x00A1C42A
		// (set) Token: 0x06029017 RID: 167959 RVA: 0x00A1E23E File Offset: 0x00A1C43E
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Exit_Fly_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Exit_Fly_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06029018 RID: 167960 RVA: 0x00A1E253 File Offset: 0x00A1C453
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Exit_Fly_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06029019 RID: 167961 RVA: 0x00A1E267 File Offset: 0x00A1C467
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Exit_Fly_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602901A RID: 167962 RVA: 0x00A1E27C File Offset: 0x00A1C47C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Exit_Fly_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Exit_Fly_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Exit_Fly_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Exit_Fly_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Exit_Fly_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602901B RID: 167963 RVA: 0x00A1E2C4 File Offset: 0x00A1C4C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Exit_Fly_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Exit_Fly_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Exit_Fly_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Exit_Fly_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Exit_Fly_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602901C RID: 167964 RVA: 0x00A1E30C File Offset: 0x00A1C50C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Exit_Fly(int EntryPoint)
		{
			GA_Motor_Exit_Fly_C.__ExecuteUbergraph_GA_Motor_Exit_Fly_FunctionParams* ptr = stackalloc GA_Motor_Exit_Fly_C.__ExecuteUbergraph_GA_Motor_Exit_Fly_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Motor_Exit_Fly_C.__ExecuteUbergraph_GA_Motor_Exit_Fly_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Exit_Fly_C.__ExecuteUbergraph_GA_Motor_Exit_Fly_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Exit_Fly_C.__ExecuteUbergraph_GA_Motor_Exit_Fly_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602901D RID: 167965 RVA: 0x00A1E353 File Offset: 0x00A1C553
		protected GA_Motor_Exit_Fly_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015B51 RID: 88913
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Exit_Fly.GA_Motor_Exit_Fly_C";

		// Token: 0x04015B52 RID: 88914
		private static IntPtr _ClassPtr;

		// Token: 0x04015B53 RID: 88915
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015B54 RID: 88916
		internal new static int __PropertyOffset_0;

		// Token: 0x04015B55 RID: 88917
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015B56 RID: 88918
		internal new static int __PropertyOffset_1;

		// Token: 0x04015B57 RID: 88919
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015B58 RID: 88920
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015B59 RID: 88921
		private static IntPtr __ExecuteUbergraph_GA_Motor_Exit_Fly_NativeFunctionPtr;

		// Token: 0x0200A1A1 RID: 41377
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032EF9 RID: 208633
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1A2 RID: 41378
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Exit_Fly_FunctionParams
		{
			// Token: 0x04032EFA RID: 208634
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
