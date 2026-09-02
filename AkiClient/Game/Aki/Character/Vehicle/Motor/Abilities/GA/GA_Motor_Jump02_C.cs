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
	// Token: 0x02003FD3 RID: 16339
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Jump02.GA_Motor_Jump02_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Motor_Jump02_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602912F RID: 168239 RVA: 0x00A20497 File Offset: 0x00A1E697
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Jump02_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Jump02.GA_Motor_Jump02_C");
			}
			return GA_Motor_Jump02_C._ClassPtr;
		}

		// Token: 0x06029130 RID: 168240 RVA: 0x00A204BC File Offset: 0x00A1E6BC
		public GA_Motor_Jump02_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Jump02_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06029131 RID: 168241 RVA: 0x00A204E4 File Offset: 0x00A1E6E4
		[NullableContext(1)]
		public GA_Motor_Jump02_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Jump02_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006557 RID: 25943
		// (get) Token: 0x06029132 RID: 168242 RVA: 0x00A20518 File Offset: 0x00A1E718
		// (set) Token: 0x06029133 RID: 168243 RVA: 0x00A20551 File Offset: 0x00A1E751
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Jump02_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Jump02_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006558 RID: 25944
		// (get) Token: 0x06029134 RID: 168244 RVA: 0x00A20572 File Offset: 0x00A1E772
		// (set) Token: 0x06029135 RID: 168245 RVA: 0x00A20586 File Offset: 0x00A1E786
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Jump02_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Jump02_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06029136 RID: 168246 RVA: 0x00A2059B File Offset: 0x00A1E79B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09B3BD79CF4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump02_C.__OnTick_CF946D5D4EFE5E5564EFF09B3BD79CF4_NativeFunctionPtr, null);
		}

		// Token: 0x06029137 RID: 168247 RVA: 0x00A205AF File Offset: 0x00A1E7AF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09B3BD79CF4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump02_C.__OnCancelled_CF946D5D4EFE5E5564EFF09B3BD79CF4_NativeFunctionPtr, null);
		}

		// Token: 0x06029138 RID: 168248 RVA: 0x00A205C3 File Offset: 0x00A1E7C3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09B3BD79CF4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump02_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09B3BD79CF4_NativeFunctionPtr, null);
		}

		// Token: 0x06029139 RID: 168249 RVA: 0x00A205D7 File Offset: 0x00A1E7D7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09B3BD79CF4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump02_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09B3BD79CF4_NativeFunctionPtr, null);
		}

		// Token: 0x0602913A RID: 168250 RVA: 0x00A205EB File Offset: 0x00A1E7EB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09B3BD79CF4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump02_C.__OnCompleted_CF946D5D4EFE5E5564EFF09B3BD79CF4_NativeFunctionPtr, null);
		}

		// Token: 0x0602913B RID: 168251 RVA: 0x00A205FF File Offset: 0x00A1E7FF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump02_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602913C RID: 168252 RVA: 0x00A20613 File Offset: 0x00A1E813
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Jump02_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602913D RID: 168253 RVA: 0x00A20628 File Offset: 0x00A1E828
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Jump02_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Jump02_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Jump02_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Jump02_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump02_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602913E RID: 168254 RVA: 0x00A20670 File Offset: 0x00A1E870
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Jump02_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Jump02_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Jump02_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Jump02_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Jump02_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602913F RID: 168255 RVA: 0x00A206B8 File Offset: 0x00A1E8B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Jump02(int EntryPoint)
		{
			GA_Motor_Jump02_C.__ExecuteUbergraph_GA_Motor_Jump02_FunctionParams* ptr = stackalloc GA_Motor_Jump02_C.__ExecuteUbergraph_GA_Motor_Jump02_FunctionParams[(UIntPtr)375] + 15L / (long)sizeof(GA_Motor_Jump02_C.__ExecuteUbergraph_GA_Motor_Jump02_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Jump02_C.__ExecuteUbergraph_GA_Motor_Jump02_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Jump02_C.__ExecuteUbergraph_GA_Motor_Jump02_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029140 RID: 168256 RVA: 0x00A20702 File Offset: 0x00A1E902
		protected GA_Motor_Jump02_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015C14 RID: 89108
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Jump02.GA_Motor_Jump02_C";

		// Token: 0x04015C15 RID: 89109
		private static IntPtr _ClassPtr;

		// Token: 0x04015C16 RID: 89110
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015C17 RID: 89111
		internal new static int __PropertyOffset_0;

		// Token: 0x04015C18 RID: 89112
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015C19 RID: 89113
		internal new static int __PropertyOffset_1;

		// Token: 0x04015C1A RID: 89114
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09B3BD79CF4_NativeFunctionPtr;

		// Token: 0x04015C1B RID: 89115
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09B3BD79CF4_NativeFunctionPtr;

		// Token: 0x04015C1C RID: 89116
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09B3BD79CF4_NativeFunctionPtr;

		// Token: 0x04015C1D RID: 89117
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09B3BD79CF4_NativeFunctionPtr;

		// Token: 0x04015C1E RID: 89118
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09B3BD79CF4_NativeFunctionPtr;

		// Token: 0x04015C1F RID: 89119
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015C20 RID: 89120
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015C21 RID: 89121
		private static IntPtr __ExecuteUbergraph_GA_Motor_Jump02_NativeFunctionPtr;

		// Token: 0x0200A1C3 RID: 41411
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F20 RID: 208672
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1C4 RID: 41412
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 360)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Jump02_FunctionParams
		{
			// Token: 0x04032F21 RID: 208673
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
