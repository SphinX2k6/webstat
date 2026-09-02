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
	// Token: 0x02003FD5 RID: 16341
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Jump_Luxin.GA_Motor_Jump_Luxin_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Motor_Jump_Luxin_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06029158 RID: 168280 RVA: 0x00A209E3 File Offset: 0x00A1EBE3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Jump_Luxin_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Jump_Luxin.GA_Motor_Jump_Luxin_C");
			}
			return GA_Motor_Jump_Luxin_C._ClassPtr;
		}

		// Token: 0x06029159 RID: 168281 RVA: 0x00A20A08 File Offset: 0x00A1EC08
		public GA_Motor_Jump_Luxin_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Jump_Luxin_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602915A RID: 168282 RVA: 0x00A20A30 File Offset: 0x00A1EC30
		[NullableContext(1)]
		public GA_Motor_Jump_Luxin_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Jump_Luxin_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700655B RID: 25947
		// (get) Token: 0x0602915B RID: 168283 RVA: 0x00A20A64 File Offset: 0x00A1EC64
		// (set) Token: 0x0602915C RID: 168284 RVA: 0x00A20A9D File Offset: 0x00A1EC9D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Jump_Luxin_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Jump_Luxin_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700655C RID: 25948
		// (get) Token: 0x0602915D RID: 168285 RVA: 0x00A20ABE File Offset: 0x00A1ECBE
		// (set) Token: 0x0602915E RID: 168286 RVA: 0x00A20AD2 File Offset: 0x00A1ECD2
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Jump_Luxin_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Jump_Luxin_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602915F RID: 168287 RVA: 0x00A20AE7 File Offset: 0x00A1ECE7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09B34677F89()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_Luxin_C.__OnTick_CF946D5D4EFE5E5564EFF09B34677F89_NativeFunctionPtr, null);
		}

		// Token: 0x06029160 RID: 168288 RVA: 0x00A20AFB File Offset: 0x00A1ECFB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09B34677F89()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_Luxin_C.__OnCancelled_CF946D5D4EFE5E5564EFF09B34677F89_NativeFunctionPtr, null);
		}

		// Token: 0x06029161 RID: 168289 RVA: 0x00A20B0F File Offset: 0x00A1ED0F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09B34677F89()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_Luxin_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09B34677F89_NativeFunctionPtr, null);
		}

		// Token: 0x06029162 RID: 168290 RVA: 0x00A20B23 File Offset: 0x00A1ED23
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09B34677F89()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_Luxin_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09B34677F89_NativeFunctionPtr, null);
		}

		// Token: 0x06029163 RID: 168291 RVA: 0x00A20B37 File Offset: 0x00A1ED37
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09B34677F89()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_Luxin_C.__OnCompleted_CF946D5D4EFE5E5564EFF09B34677F89_NativeFunctionPtr, null);
		}

		// Token: 0x06029164 RID: 168292 RVA: 0x00A20B4B File Offset: 0x00A1ED4B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09B20248DFD()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_Luxin_C.__OnTick_CF946D5D4EFE5E5564EFF09B20248DFD_NativeFunctionPtr, null);
		}

		// Token: 0x06029165 RID: 168293 RVA: 0x00A20B5F File Offset: 0x00A1ED5F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09B20248DFD()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_Luxin_C.__OnCancelled_CF946D5D4EFE5E5564EFF09B20248DFD_NativeFunctionPtr, null);
		}

		// Token: 0x06029166 RID: 168294 RVA: 0x00A20B73 File Offset: 0x00A1ED73
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09B20248DFD()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_Luxin_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09B20248DFD_NativeFunctionPtr, null);
		}

		// Token: 0x06029167 RID: 168295 RVA: 0x00A20B87 File Offset: 0x00A1ED87
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09B20248DFD()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_Luxin_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09B20248DFD_NativeFunctionPtr, null);
		}

		// Token: 0x06029168 RID: 168296 RVA: 0x00A20B9B File Offset: 0x00A1ED9B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09B20248DFD()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_Luxin_C.__OnCompleted_CF946D5D4EFE5E5564EFF09B20248DFD_NativeFunctionPtr, null);
		}

		// Token: 0x06029169 RID: 168297 RVA: 0x00A20BAF File Offset: 0x00A1EDAF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_Luxin_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602916A RID: 168298 RVA: 0x00A20BC3 File Offset: 0x00A1EDC3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Jump_Luxin_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602916B RID: 168299 RVA: 0x00A20BD8 File Offset: 0x00A1EDD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Jump_Luxin_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Jump_Luxin_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Jump_Luxin_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Jump_Luxin_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_Luxin_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602916C RID: 168300 RVA: 0x00A20C20 File Offset: 0x00A1EE20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Jump_Luxin_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Jump_Luxin_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Jump_Luxin_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Jump_Luxin_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Jump_Luxin_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602916D RID: 168301 RVA: 0x00A20C68 File Offset: 0x00A1EE68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Jump_Luxin(int EntryPoint)
		{
			GA_Motor_Jump_Luxin_C.__ExecuteUbergraph_GA_Motor_Jump_Luxin_FunctionParams* ptr = stackalloc GA_Motor_Jump_Luxin_C.__ExecuteUbergraph_GA_Motor_Jump_Luxin_FunctionParams[(UIntPtr)687] + 15L / (long)sizeof(GA_Motor_Jump_Luxin_C.__ExecuteUbergraph_GA_Motor_Jump_Luxin_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Jump_Luxin_C.__ExecuteUbergraph_GA_Motor_Jump_Luxin_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Jump_Luxin_C.__ExecuteUbergraph_GA_Motor_Jump_Luxin_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602916E RID: 168302 RVA: 0x00A20CB2 File Offset: 0x00A1EEB2
		protected GA_Motor_Jump_Luxin_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015C35 RID: 89141
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Jump_Luxin.GA_Motor_Jump_Luxin_C";

		// Token: 0x04015C36 RID: 89142
		private static IntPtr _ClassPtr;

		// Token: 0x04015C37 RID: 89143
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015C38 RID: 89144
		internal new static int __PropertyOffset_0;

		// Token: 0x04015C39 RID: 89145
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015C3A RID: 89146
		internal new static int __PropertyOffset_1;

		// Token: 0x04015C3B RID: 89147
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09B34677F89_NativeFunctionPtr;

		// Token: 0x04015C3C RID: 89148
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09B34677F89_NativeFunctionPtr;

		// Token: 0x04015C3D RID: 89149
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09B34677F89_NativeFunctionPtr;

		// Token: 0x04015C3E RID: 89150
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09B34677F89_NativeFunctionPtr;

		// Token: 0x04015C3F RID: 89151
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09B34677F89_NativeFunctionPtr;

		// Token: 0x04015C40 RID: 89152
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09B20248DFD_NativeFunctionPtr;

		// Token: 0x04015C41 RID: 89153
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09B20248DFD_NativeFunctionPtr;

		// Token: 0x04015C42 RID: 89154
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09B20248DFD_NativeFunctionPtr;

		// Token: 0x04015C43 RID: 89155
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09B20248DFD_NativeFunctionPtr;

		// Token: 0x04015C44 RID: 89156
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09B20248DFD_NativeFunctionPtr;

		// Token: 0x04015C45 RID: 89157
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015C46 RID: 89158
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015C47 RID: 89159
		private static IntPtr __ExecuteUbergraph_GA_Motor_Jump_Luxin_NativeFunctionPtr;

		// Token: 0x0200A1C7 RID: 41415
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F24 RID: 208676
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1C8 RID: 41416
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 672)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Jump_Luxin_FunctionParams
		{
			// Token: 0x04032F25 RID: 208677
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
