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
	// Token: 0x02003FDE RID: 16350
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Platform_Idle.GA_Motor_Platform_Idle_C")]
	[UnrealStructLayout(1504, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1504)]
	public class GA_Motor_Platform_Idle_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602924A RID: 168522 RVA: 0x00A2271F File Offset: 0x00A2091F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Platform_Idle_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Platform_Idle.GA_Motor_Platform_Idle_C");
			}
			return GA_Motor_Platform_Idle_C._ClassPtr;
		}

		// Token: 0x0602924B RID: 168523 RVA: 0x00A22744 File Offset: 0x00A20944
		public GA_Motor_Platform_Idle_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Platform_Idle_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602924C RID: 168524 RVA: 0x00A2276C File Offset: 0x00A2096C
		[NullableContext(1)]
		public GA_Motor_Platform_Idle_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Platform_Idle_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006579 RID: 25977
		// (get) Token: 0x0602924D RID: 168525 RVA: 0x00A227A0 File Offset: 0x00A209A0
		// (set) Token: 0x0602924E RID: 168526 RVA: 0x00A227D9 File Offset: 0x00A209D9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Platform_Idle_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Platform_Idle_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700657A RID: 25978
		// (get) Token: 0x0602924F RID: 168527 RVA: 0x00A227FA File Offset: 0x00A209FA
		// (set) Token: 0x06029250 RID: 168528 RVA: 0x00A2280A File Offset: 0x00A20A0A
		public unsafe bool 是否主动结束
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_Platform_Idle_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_Platform_Idle_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700657B RID: 25979
		// (get) Token: 0x06029251 RID: 168529 RVA: 0x00A2281B File Offset: 0x00A20A1B
		// (set) Token: 0x06029252 RID: 168530 RVA: 0x00A2282F File Offset: 0x00A20A2F
		[Nullable(2)]
		public unsafe TsBaseCharacter 驾驶员
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Platform_Idle_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Platform_Idle_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x06029253 RID: 168531 RVA: 0x00A22844 File Offset: 0x00A20A44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_941A88F849D9CDDABE04B6AC6BA3F7AD()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Platform_Idle_C.__OnFinish_941A88F849D9CDDABE04B6AC6BA3F7AD_NativeFunctionPtr, null);
		}

		// Token: 0x06029254 RID: 168532 RVA: 0x00A22858 File Offset: 0x00A20A58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Platform_Idle_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06029255 RID: 168533 RVA: 0x00A2286C File Offset: 0x00A20A6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Platform_Idle_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06029256 RID: 168534 RVA: 0x00A22884 File Offset: 0x00A20A84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Platform_Idle_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Platform_Idle_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Platform_Idle_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Platform_Idle_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Platform_Idle_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06029257 RID: 168535 RVA: 0x00A228CC File Offset: 0x00A20ACC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Platform_Idle_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Platform_Idle_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Platform_Idle_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Platform_Idle_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Platform_Idle_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029258 RID: 168536 RVA: 0x00A22914 File Offset: 0x00A20B14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Platform_Idle(int EntryPoint)
		{
			GA_Motor_Platform_Idle_C.__ExecuteUbergraph_GA_Motor_Platform_Idle_FunctionParams* ptr = stackalloc GA_Motor_Platform_Idle_C.__ExecuteUbergraph_GA_Motor_Platform_Idle_FunctionParams[(UIntPtr)135] + 15L / (long)sizeof(GA_Motor_Platform_Idle_C.__ExecuteUbergraph_GA_Motor_Platform_Idle_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Platform_Idle_C.__ExecuteUbergraph_GA_Motor_Platform_Idle_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Platform_Idle_C.__ExecuteUbergraph_GA_Motor_Platform_Idle_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029259 RID: 168537 RVA: 0x00A2295E File Offset: 0x00A20B5E
		protected GA_Motor_Platform_Idle_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015CF9 RID: 89337
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Platform_Idle.GA_Motor_Platform_Idle_C";

		// Token: 0x04015CFA RID: 89338
		private static IntPtr _ClassPtr;

		// Token: 0x04015CFB RID: 89339
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015CFC RID: 89340
		internal new static int __PropertyOffset_0;

		// Token: 0x04015CFD RID: 89341
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015CFE RID: 89342
		internal new static int __PropertyOffset_1;

		// Token: 0x04015CFF RID: 89343
		internal new static int __PropertyOffset_2;

		// Token: 0x04015D00 RID: 89344
		private static IntPtr __OnFinish_941A88F849D9CDDABE04B6AC6BA3F7AD_NativeFunctionPtr;

		// Token: 0x04015D01 RID: 89345
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015D02 RID: 89346
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015D03 RID: 89347
		private static IntPtr __ExecuteUbergraph_GA_Motor_Platform_Idle_NativeFunctionPtr;

		// Token: 0x0200A1DE RID: 41438
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F3B RID: 208699
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1DF RID: 41439
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 120)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Platform_Idle_FunctionParams
		{
			// Token: 0x04032F3C RID: 208700
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
