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
	// Token: 0x02003FD4 RID: 16340
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Jump.GA_Motor_Jump_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Motor_Jump_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06029141 RID: 168257 RVA: 0x00A2070B File Offset: 0x00A1E90B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Jump_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Jump.GA_Motor_Jump_C");
			}
			return GA_Motor_Jump_C._ClassPtr;
		}

		// Token: 0x06029142 RID: 168258 RVA: 0x00A20730 File Offset: 0x00A1E930
		public GA_Motor_Jump_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Jump_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06029143 RID: 168259 RVA: 0x00A20758 File Offset: 0x00A1E958
		[NullableContext(1)]
		public GA_Motor_Jump_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Jump_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006559 RID: 25945
		// (get) Token: 0x06029144 RID: 168260 RVA: 0x00A2078C File Offset: 0x00A1E98C
		// (set) Token: 0x06029145 RID: 168261 RVA: 0x00A207C5 File Offset: 0x00A1E9C5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Jump_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Jump_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700655A RID: 25946
		// (get) Token: 0x06029146 RID: 168262 RVA: 0x00A207E6 File Offset: 0x00A1E9E6
		// (set) Token: 0x06029147 RID: 168263 RVA: 0x00A207FA File Offset: 0x00A1E9FA
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Jump_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Jump_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06029148 RID: 168264 RVA: 0x00A2080F File Offset: 0x00A1EA0F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09B58A3A26E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_C.__OnTick_CF946D5D4EFE5E5564EFF09B58A3A26E_NativeFunctionPtr, null);
		}

		// Token: 0x06029149 RID: 168265 RVA: 0x00A20823 File Offset: 0x00A1EA23
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09B58A3A26E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_C.__OnCancelled_CF946D5D4EFE5E5564EFF09B58A3A26E_NativeFunctionPtr, null);
		}

		// Token: 0x0602914A RID: 168266 RVA: 0x00A20837 File Offset: 0x00A1EA37
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09B58A3A26E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09B58A3A26E_NativeFunctionPtr, null);
		}

		// Token: 0x0602914B RID: 168267 RVA: 0x00A2084B File Offset: 0x00A1EA4B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09B58A3A26E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09B58A3A26E_NativeFunctionPtr, null);
		}

		// Token: 0x0602914C RID: 168268 RVA: 0x00A2085F File Offset: 0x00A1EA5F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09B58A3A26E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_C.__OnCompleted_CF946D5D4EFE5E5564EFF09B58A3A26E_NativeFunctionPtr, null);
		}

		// Token: 0x0602914D RID: 168269 RVA: 0x00A20873 File Offset: 0x00A1EA73
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09BA9486D1D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_C.__OnTick_CF946D5D4EFE5E5564EFF09BA9486D1D_NativeFunctionPtr, null);
		}

		// Token: 0x0602914E RID: 168270 RVA: 0x00A20887 File Offset: 0x00A1EA87
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09BA9486D1D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_C.__OnCancelled_CF946D5D4EFE5E5564EFF09BA9486D1D_NativeFunctionPtr, null);
		}

		// Token: 0x0602914F RID: 168271 RVA: 0x00A2089B File Offset: 0x00A1EA9B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09BA9486D1D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09BA9486D1D_NativeFunctionPtr, null);
		}

		// Token: 0x06029150 RID: 168272 RVA: 0x00A208AF File Offset: 0x00A1EAAF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09BA9486D1D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09BA9486D1D_NativeFunctionPtr, null);
		}

		// Token: 0x06029151 RID: 168273 RVA: 0x00A208C3 File Offset: 0x00A1EAC3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09BA9486D1D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_C.__OnCompleted_CF946D5D4EFE5E5564EFF09BA9486D1D_NativeFunctionPtr, null);
		}

		// Token: 0x06029152 RID: 168274 RVA: 0x00A208D7 File Offset: 0x00A1EAD7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06029153 RID: 168275 RVA: 0x00A208EB File Offset: 0x00A1EAEB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Jump_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06029154 RID: 168276 RVA: 0x00A20900 File Offset: 0x00A1EB00
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Jump_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Jump_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Jump_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Jump_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06029155 RID: 168277 RVA: 0x00A20948 File Offset: 0x00A1EB48
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Jump_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Jump_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Jump_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Jump_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Jump_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029156 RID: 168278 RVA: 0x00A20990 File Offset: 0x00A1EB90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Jump(int EntryPoint)
		{
			GA_Motor_Jump_C.__ExecuteUbergraph_GA_Motor_Jump_FunctionParams* ptr = stackalloc GA_Motor_Jump_C.__ExecuteUbergraph_GA_Motor_Jump_FunctionParams[(UIntPtr)767] + 15L / (long)sizeof(GA_Motor_Jump_C.__ExecuteUbergraph_GA_Motor_Jump_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Jump_C.__ExecuteUbergraph_GA_Motor_Jump_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Jump_C.__ExecuteUbergraph_GA_Motor_Jump_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029157 RID: 168279 RVA: 0x00A209DA File Offset: 0x00A1EBDA
		protected GA_Motor_Jump_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015C22 RID: 89122
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Jump.GA_Motor_Jump_C";

		// Token: 0x04015C23 RID: 89123
		private static IntPtr _ClassPtr;

		// Token: 0x04015C24 RID: 89124
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015C25 RID: 89125
		internal new static int __PropertyOffset_0;

		// Token: 0x04015C26 RID: 89126
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015C27 RID: 89127
		internal new static int __PropertyOffset_1;

		// Token: 0x04015C28 RID: 89128
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09B58A3A26E_NativeFunctionPtr;

		// Token: 0x04015C29 RID: 89129
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09B58A3A26E_NativeFunctionPtr;

		// Token: 0x04015C2A RID: 89130
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09B58A3A26E_NativeFunctionPtr;

		// Token: 0x04015C2B RID: 89131
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09B58A3A26E_NativeFunctionPtr;

		// Token: 0x04015C2C RID: 89132
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09B58A3A26E_NativeFunctionPtr;

		// Token: 0x04015C2D RID: 89133
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09BA9486D1D_NativeFunctionPtr;

		// Token: 0x04015C2E RID: 89134
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09BA9486D1D_NativeFunctionPtr;

		// Token: 0x04015C2F RID: 89135
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09BA9486D1D_NativeFunctionPtr;

		// Token: 0x04015C30 RID: 89136
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09BA9486D1D_NativeFunctionPtr;

		// Token: 0x04015C31 RID: 89137
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09BA9486D1D_NativeFunctionPtr;

		// Token: 0x04015C32 RID: 89138
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015C33 RID: 89139
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015C34 RID: 89140
		private static IntPtr __ExecuteUbergraph_GA_Motor_Jump_NativeFunctionPtr;

		// Token: 0x0200A1C5 RID: 41413
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F22 RID: 208674
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1C6 RID: 41414
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 752)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Jump_FunctionParams
		{
			// Token: 0x04032F23 RID: 208675
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
