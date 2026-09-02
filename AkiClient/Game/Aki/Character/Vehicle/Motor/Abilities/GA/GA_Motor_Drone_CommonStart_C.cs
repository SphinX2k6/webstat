using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Abilities.GA
{
	// Token: 0x02003FC3 RID: 16323
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Drone_CommonStart.GA_Motor_Drone_CommonStart_C")]
	[UnrealStructLayout(1528, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1528)]
	public class GA_Motor_Drone_CommonStart_C : GA_Motor_DroneBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028F9F RID: 167839 RVA: 0x00A1CD80 File Offset: 0x00A1AF80
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Drone_CommonStart_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Drone_CommonStart.GA_Motor_Drone_CommonStart_C");
			}
			return GA_Motor_Drone_CommonStart_C._ClassPtr;
		}

		// Token: 0x06028FA0 RID: 167840 RVA: 0x00A1CDA4 File Offset: 0x00A1AFA4
		public GA_Motor_Drone_CommonStart_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Drone_CommonStart_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028FA1 RID: 167841 RVA: 0x00A1CDCC File Offset: 0x00A1AFCC
		[NullableContext(1)]
		public GA_Motor_Drone_CommonStart_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Drone_CommonStart_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170064F7 RID: 25847
		// (get) Token: 0x06028FA2 RID: 167842 RVA: 0x00A1CE00 File Offset: 0x00A1B000
		// (set) Token: 0x06028FA3 RID: 167843 RVA: 0x00A1CE39 File Offset: 0x00A1B039
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Drone_CommonStart_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Drone_CommonStart_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06028FA4 RID: 167844 RVA: 0x00A1CE5A File Offset: 0x00A1B05A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Drone_CommonStart_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06028FA5 RID: 167845 RVA: 0x00A1CE6E File Offset: 0x00A1B06E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Drone_CommonStart_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06028FA6 RID: 167846 RVA: 0x00A1CE84 File Offset: 0x00A1B084
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Drone_CommonStart_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Drone_CommonStart_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Drone_CommonStart_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_CommonStart_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Drone_CommonStart_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028FA7 RID: 167847 RVA: 0x00A1CECC File Offset: 0x00A1B0CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Drone_CommonStart_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Drone_CommonStart_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Drone_CommonStart_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_CommonStart_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Drone_CommonStart_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028FA8 RID: 167848 RVA: 0x00A1CF14 File Offset: 0x00A1B114
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Drone_CommonStart(int EntryPoint)
		{
			GA_Motor_Drone_CommonStart_C.__ExecuteUbergraph_GA_Motor_Drone_CommonStart_FunctionParams* ptr = stackalloc GA_Motor_Drone_CommonStart_C.__ExecuteUbergraph_GA_Motor_Drone_CommonStart_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(GA_Motor_Drone_CommonStart_C.__ExecuteUbergraph_GA_Motor_Drone_CommonStart_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_CommonStart_C.__ExecuteUbergraph_GA_Motor_Drone_CommonStart_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Drone_CommonStart_C.__ExecuteUbergraph_GA_Motor_Drone_CommonStart_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028FA9 RID: 167849 RVA: 0x00A1CF5B File Offset: 0x00A1B15B
		protected GA_Motor_Drone_CommonStart_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015AF9 RID: 88825
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Drone_CommonStart.GA_Motor_Drone_CommonStart_C";

		// Token: 0x04015AFA RID: 88826
		private static IntPtr _ClassPtr;

		// Token: 0x04015AFB RID: 88827
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015AFC RID: 88828
		internal new static int __PropertyOffset_0;

		// Token: 0x04015AFD RID: 88829
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015AFE RID: 88830
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015AFF RID: 88831
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015B00 RID: 88832
		private static IntPtr __ExecuteUbergraph_GA_Motor_Drone_CommonStart_NativeFunctionPtr;

		// Token: 0x0200A18A RID: 41354
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032EDE RID: 208606
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A18B RID: 41355
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Drone_CommonStart_FunctionParams
		{
			// Token: 0x04032EDF RID: 208607
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
