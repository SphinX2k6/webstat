using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Abilities.GA
{
	// Token: 0x02003FC5 RID: 16325
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Drone_DyEnd.GA_Motor_Drone_DyEnd_C")]
	[UnrealStructLayout(1560, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1560)]
	public class GA_Motor_Drone_DyEnd_C : GA_Motor_DroneBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028FB5 RID: 167861 RVA: 0x00A1D148 File Offset: 0x00A1B348
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Drone_DyEnd_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Drone_DyEnd.GA_Motor_Drone_DyEnd_C");
			}
			return GA_Motor_Drone_DyEnd_C._ClassPtr;
		}

		// Token: 0x06028FB6 RID: 167862 RVA: 0x00A1D16C File Offset: 0x00A1B36C
		public GA_Motor_Drone_DyEnd_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Drone_DyEnd_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028FB7 RID: 167863 RVA: 0x00A1D194 File Offset: 0x00A1B394
		public GA_Motor_Drone_DyEnd_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Drone_DyEnd_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170064F9 RID: 25849
		// (get) Token: 0x06028FB8 RID: 167864 RVA: 0x00A1D1C8 File Offset: 0x00A1B3C8
		// (set) Token: 0x06028FB9 RID: 167865 RVA: 0x00A1D201 File Offset: 0x00A1B401
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Drone_DyEnd_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Drone_DyEnd_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170064FA RID: 25850
		// (get) Token: 0x06028FBA RID: 167866 RVA: 0x00A1D224 File Offset: 0x00A1B424
		// (set) Token: 0x06028FBB RID: 167867 RVA: 0x00A1D25D File Offset: 0x00A1B45D
		public TArray<FGameplayTag> 挂点Tags
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FGameplayTag> result;
				if ((result = this._挂点Tags) == null)
				{
					result = (this._挂点Tags = new TArray<FGameplayTag>(base.NativePtr + (IntPtr)GA_Motor_Drone_DyEnd_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.挂点Tags.CopyAssign(value);
			}
		}

		// Token: 0x170064FB RID: 25851
		// (get) Token: 0x06028FBC RID: 167868 RVA: 0x00A1D26C File Offset: 0x00A1B46C
		// (set) Token: 0x06028FBD RID: 167869 RVA: 0x00A1D2A5 File Offset: 0x00A1B4A5
		public TArray<FGameplayTag> 死眼Tag
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FGameplayTag> result;
				if ((result = this._死眼Tag) == null)
				{
					result = (this._死眼Tag = new TArray<FGameplayTag>(base.NativePtr + (IntPtr)GA_Motor_Drone_DyEnd_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.死眼Tag.CopyAssign(value);
			}
		}

		// Token: 0x06028FBE RID: 167870 RVA: 0x00A1D2B3 File Offset: 0x00A1B4B3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Drone_DyEnd_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06028FBF RID: 167871 RVA: 0x00A1D2C7 File Offset: 0x00A1B4C7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Drone_DyEnd_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06028FC0 RID: 167872 RVA: 0x00A1D2DC File Offset: 0x00A1B4DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Drone_DyEnd_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Drone_DyEnd_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Drone_DyEnd_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_DyEnd_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Drone_DyEnd_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028FC1 RID: 167873 RVA: 0x00A1D324 File Offset: 0x00A1B524
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Drone_DyEnd_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Drone_DyEnd_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Drone_DyEnd_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_DyEnd_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Drone_DyEnd_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028FC2 RID: 167874 RVA: 0x00A1D36C File Offset: 0x00A1B56C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Drone_DyEnd(int EntryPoint)
		{
			GA_Motor_Drone_DyEnd_C.__ExecuteUbergraph_GA_Motor_Drone_DyEnd_FunctionParams* ptr = stackalloc GA_Motor_Drone_DyEnd_C.__ExecuteUbergraph_GA_Motor_Drone_DyEnd_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(GA_Motor_Drone_DyEnd_C.__ExecuteUbergraph_GA_Motor_Drone_DyEnd_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_DyEnd_C.__ExecuteUbergraph_GA_Motor_Drone_DyEnd_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Drone_DyEnd_C.__ExecuteUbergraph_GA_Motor_Drone_DyEnd_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028FC3 RID: 167875 RVA: 0x00A1D3B3 File Offset: 0x00A1B5B3
		protected GA_Motor_Drone_DyEnd_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015B09 RID: 88841
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Drone_DyEnd.GA_Motor_Drone_DyEnd_C";

		// Token: 0x04015B0A RID: 88842
		private static IntPtr _ClassPtr;

		// Token: 0x04015B0B RID: 88843
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015B0C RID: 88844
		internal new static int __PropertyOffset_0;

		// Token: 0x04015B0D RID: 88845
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015B0E RID: 88846
		internal new static int __PropertyOffset_1;

		// Token: 0x04015B0F RID: 88847
		[Nullable(2)]
		private TArray<FGameplayTag> _挂点Tags;

		// Token: 0x04015B10 RID: 88848
		internal new static int __PropertyOffset_2;

		// Token: 0x04015B11 RID: 88849
		[Nullable(2)]
		private TArray<FGameplayTag> _死眼Tag;

		// Token: 0x04015B12 RID: 88850
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015B13 RID: 88851
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015B14 RID: 88852
		private static IntPtr __ExecuteUbergraph_GA_Motor_Drone_DyEnd_NativeFunctionPtr;

		// Token: 0x0200A18E RID: 41358
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032EE2 RID: 208610
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A18F RID: 41359
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Drone_DyEnd_FunctionParams
		{
			// Token: 0x04032EE3 RID: 208611
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
