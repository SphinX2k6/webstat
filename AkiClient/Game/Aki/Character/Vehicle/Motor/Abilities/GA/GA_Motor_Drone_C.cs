using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Abilities.GA
{
	// Token: 0x02003FC2 RID: 16322
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Drone.GA_Motor_Drone_C")]
	[UnrealStructLayout(1528, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1528)]
	public class GA_Motor_Drone_C : GA_Motor_DroneBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028F94 RID: 167828 RVA: 0x00A1CB9C File Offset: 0x00A1AD9C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Drone_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Drone.GA_Motor_Drone_C");
			}
			return GA_Motor_Drone_C._ClassPtr;
		}

		// Token: 0x06028F95 RID: 167829 RVA: 0x00A1CBC0 File Offset: 0x00A1ADC0
		public GA_Motor_Drone_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Drone_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028F96 RID: 167830 RVA: 0x00A1CBE8 File Offset: 0x00A1ADE8
		[NullableContext(1)]
		public GA_Motor_Drone_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Drone_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170064F6 RID: 25846
		// (get) Token: 0x06028F97 RID: 167831 RVA: 0x00A1CC1C File Offset: 0x00A1AE1C
		// (set) Token: 0x06028F98 RID: 167832 RVA: 0x00A1CC55 File Offset: 0x00A1AE55
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Drone_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Drone_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06028F99 RID: 167833 RVA: 0x00A1CC76 File Offset: 0x00A1AE76
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Drone_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06028F9A RID: 167834 RVA: 0x00A1CC8A File Offset: 0x00A1AE8A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Drone_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06028F9B RID: 167835 RVA: 0x00A1CCA0 File Offset: 0x00A1AEA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Drone_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Drone_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Drone_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Drone_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028F9C RID: 167836 RVA: 0x00A1CCE8 File Offset: 0x00A1AEE8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Drone_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Drone_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Drone_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Drone_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028F9D RID: 167837 RVA: 0x00A1CD30 File Offset: 0x00A1AF30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Drone(int EntryPoint)
		{
			GA_Motor_Drone_C.__ExecuteUbergraph_GA_Motor_Drone_FunctionParams* ptr = stackalloc GA_Motor_Drone_C.__ExecuteUbergraph_GA_Motor_Drone_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(GA_Motor_Drone_C.__ExecuteUbergraph_GA_Motor_Drone_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_C.__ExecuteUbergraph_GA_Motor_Drone_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Drone_C.__ExecuteUbergraph_GA_Motor_Drone_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028F9E RID: 167838 RVA: 0x00A1CD77 File Offset: 0x00A1AF77
		protected GA_Motor_Drone_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015AF1 RID: 88817
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Drone.GA_Motor_Drone_C";

		// Token: 0x04015AF2 RID: 88818
		private static IntPtr _ClassPtr;

		// Token: 0x04015AF3 RID: 88819
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015AF4 RID: 88820
		internal new static int __PropertyOffset_0;

		// Token: 0x04015AF5 RID: 88821
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015AF6 RID: 88822
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015AF7 RID: 88823
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015AF8 RID: 88824
		private static IntPtr __ExecuteUbergraph_GA_Motor_Drone_NativeFunctionPtr;

		// Token: 0x0200A188 RID: 41352
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032EDC RID: 208604
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A189 RID: 41353
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Drone_FunctionParams
		{
			// Token: 0x04032EDD RID: 208605
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
