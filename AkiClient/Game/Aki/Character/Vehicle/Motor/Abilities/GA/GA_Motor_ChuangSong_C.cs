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
	// Token: 0x02003FC0 RID: 16320
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_ChuangSong.GA_Motor_ChuangSong_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Motor_ChuangSong_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028F6E RID: 167790 RVA: 0x00A1C5FB File Offset: 0x00A1A7FB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_ChuangSong_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_ChuangSong.GA_Motor_ChuangSong_C");
			}
			return GA_Motor_ChuangSong_C._ClassPtr;
		}

		// Token: 0x06028F6F RID: 167791 RVA: 0x00A1C620 File Offset: 0x00A1A820
		public GA_Motor_ChuangSong_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_ChuangSong_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028F70 RID: 167792 RVA: 0x00A1C648 File Offset: 0x00A1A848
		[NullableContext(1)]
		public GA_Motor_ChuangSong_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_ChuangSong_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170064F0 RID: 25840
		// (get) Token: 0x06028F71 RID: 167793 RVA: 0x00A1C67C File Offset: 0x00A1A87C
		// (set) Token: 0x06028F72 RID: 167794 RVA: 0x00A1C6B5 File Offset: 0x00A1A8B5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_ChuangSong_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_ChuangSong_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170064F1 RID: 25841
		// (get) Token: 0x06028F73 RID: 167795 RVA: 0x00A1C6D6 File Offset: 0x00A1A8D6
		// (set) Token: 0x06028F74 RID: 167796 RVA: 0x00A1C6EA File Offset: 0x00A1A8EA
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_ChuangSong_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_ChuangSong_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06028F75 RID: 167797 RVA: 0x00A1C6FF File Offset: 0x00A1A8FF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_ChuangSong_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06028F76 RID: 167798 RVA: 0x00A1C713 File Offset: 0x00A1A913
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_ChuangSong_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06028F77 RID: 167799 RVA: 0x00A1C728 File Offset: 0x00A1A928
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_ChuangSong_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_ChuangSong_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_ChuangSong_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_ChuangSong_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_ChuangSong_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028F78 RID: 167800 RVA: 0x00A1C770 File Offset: 0x00A1A970
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_ChuangSong_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_ChuangSong_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_ChuangSong_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_ChuangSong_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_ChuangSong_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028F79 RID: 167801 RVA: 0x00A1C7B8 File Offset: 0x00A1A9B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_ChuangSong(int EntryPoint)
		{
			GA_Motor_ChuangSong_C.__ExecuteUbergraph_GA_Motor_ChuangSong_FunctionParams* ptr = stackalloc GA_Motor_ChuangSong_C.__ExecuteUbergraph_GA_Motor_ChuangSong_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Motor_ChuangSong_C.__ExecuteUbergraph_GA_Motor_ChuangSong_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_ChuangSong_C.__ExecuteUbergraph_GA_Motor_ChuangSong_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_ChuangSong_C.__ExecuteUbergraph_GA_Motor_ChuangSong_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028F7A RID: 167802 RVA: 0x00A1C7FF File Offset: 0x00A1A9FF
		protected GA_Motor_ChuangSong_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015AD4 RID: 88788
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_ChuangSong.GA_Motor_ChuangSong_C";

		// Token: 0x04015AD5 RID: 88789
		private static IntPtr _ClassPtr;

		// Token: 0x04015AD6 RID: 88790
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015AD7 RID: 88791
		internal new static int __PropertyOffset_0;

		// Token: 0x04015AD8 RID: 88792
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015AD9 RID: 88793
		internal new static int __PropertyOffset_1;

		// Token: 0x04015ADA RID: 88794
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015ADB RID: 88795
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015ADC RID: 88796
		private static IntPtr __ExecuteUbergraph_GA_Motor_ChuangSong_NativeFunctionPtr;

		// Token: 0x0200A182 RID: 41346
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032ED6 RID: 208598
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A183 RID: 41347
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_GA_Motor_ChuangSong_FunctionParams
		{
			// Token: 0x04032ED7 RID: 208599
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
