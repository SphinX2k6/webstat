using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Abilities.GA
{
	// Token: 0x02004079 RID: 16505
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_CommonMaleXL_AimMode.GA_CommonMaleXL_AimMode_C")]
	[UnrealStructLayout(1512, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1506)]
	public class GA_CommonMaleXL_AimMode_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AE59 RID: 175705 RVA: 0x00A68F33 File Offset: 0x00A67133
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_CommonMaleXL_AimMode_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_CommonMaleXL_AimMode.GA_CommonMaleXL_AimMode_C");
			}
			return GA_CommonMaleXL_AimMode_C._ClassPtr;
		}

		// Token: 0x0602AE5A RID: 175706 RVA: 0x00A68F58 File Offset: 0x00A67158
		public GA_CommonMaleXL_AimMode_C() : this(BuiltinUtils.AllocNativeUObject(GA_CommonMaleXL_AimMode_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AE5B RID: 175707 RVA: 0x00A68F80 File Offset: 0x00A67180
		[NullableContext(1)]
		public GA_CommonMaleXL_AimMode_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_CommonMaleXL_AimMode_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007022 RID: 28706
		// (get) Token: 0x0602AE5C RID: 175708 RVA: 0x00A68FB4 File Offset: 0x00A671B4
		// (set) Token: 0x0602AE5D RID: 175709 RVA: 0x00A68FED File Offset: 0x00A671ED
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_CommonMaleXL_AimMode_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_CommonMaleXL_AimMode_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007023 RID: 28707
		// (get) Token: 0x0602AE5E RID: 175710 RVA: 0x00A6900E File Offset: 0x00A6720E
		// (set) Token: 0x0602AE5F RID: 175711 RVA: 0x00A69022 File Offset: 0x00A67222
		[Nullable(2)]
		public unsafe UGameplayTask_WaitDelay Async_Task
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UGameplayTask_WaitDelay>(base.NativePtr / (IntPtr)sizeof(void*) + GA_CommonMaleXL_AimMode_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_CommonMaleXL_AimMode_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007024 RID: 28708
		// (get) Token: 0x0602AE60 RID: 175712 RVA: 0x00A69037 File Offset: 0x00A67237
		// (set) Token: 0x0602AE61 RID: 175713 RVA: 0x00A69047 File Offset: 0x00A67247
		public unsafe bool 蓄力完成
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_CommonMaleXL_AimMode_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_CommonMaleXL_AimMode_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007025 RID: 28709
		// (get) Token: 0x0602AE62 RID: 175714 RVA: 0x00A69058 File Offset: 0x00A67258
		// (set) Token: 0x0602AE63 RID: 175715 RVA: 0x00A69068 File Offset: 0x00A67268
		public unsafe int 蓄力特效子弹
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_CommonMaleXL_AimMode_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_CommonMaleXL_AimMode_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007026 RID: 28710
		// (get) Token: 0x0602AE64 RID: 175716 RVA: 0x00A69079 File Offset: 0x00A67279
		// (set) Token: 0x0602AE65 RID: 175717 RVA: 0x00A69089 File Offset: 0x00A67289
		public unsafe bool 射击中
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_CommonMaleXL_AimMode_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_CommonMaleXL_AimMode_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007027 RID: 28711
		// (get) Token: 0x0602AE66 RID: 175718 RVA: 0x00A6909A File Offset: 0x00A6729A
		// (set) Token: 0x0602AE67 RID: 175719 RVA: 0x00A690AA File Offset: 0x00A672AA
		public unsafe bool 是否进入自动瞄准
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_CommonMaleXL_AimMode_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_CommonMaleXL_AimMode_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602AE68 RID: 175720 RVA: 0x00A690BC File Offset: 0x00A672BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 自动瞄准处理(ref bool 是否进入自动瞄准)
		{
			GA_CommonMaleXL_AimMode_C.__自动瞄准处理_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimMode_C.__自动瞄准处理_FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(GA_CommonMaleXL_AimMode_C.__自动瞄准处理_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimMode_C.__自动瞄准处理_NativeFunctionPtr, (void*)ptr, 1);
			ptr->是否进入自动瞄准 = 是否进入自动瞄准;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_C.__自动瞄准处理_NativeFunctionPtr, (void*)ptr);
			是否进入自动瞄准 = ptr->是否进入自动瞄准;
		}

		// Token: 0x0602AE69 RID: 175721 RVA: 0x00A6910C File Offset: 0x00A6730C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EventReceived_18B59F5945020DB23C42FD88DC330F7F(FGameplayEventData Payload)
		{
			GA_CommonMaleXL_AimMode_C.__EventReceived_18B59F5945020DB23C42FD88DC330F7F_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimMode_C.__EventReceived_18B59F5945020DB23C42FD88DC330F7F_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(GA_CommonMaleXL_AimMode_C.__EventReceived_18B59F5945020DB23C42FD88DC330F7F_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimMode_C.__EventReceived_18B59F5945020DB23C42FD88DC330F7F_NativeFunctionPtr, (void*)ptr, 1);
			if (Payload != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayEventData.StaticStruct(), &ptr->Payload, Payload.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_C.__EventReceived_18B59F5945020DB23C42FD88DC330F7F_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_CommonMaleXL_AimMode_C.__EventReceived_18B59F5945020DB23C42FD88DC330F7F_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602AE6A RID: 175722 RVA: 0x00A69184 File Offset: 0x00A67384
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_1653F7D946291B91D3E713A910288372(in FGameplayTag Tag)
		{
			GA_CommonMaleXL_AimMode_C.__Removed_1653F7D946291B91D3E713A910288372_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimMode_C.__Removed_1653F7D946291B91D3E713A910288372_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_CommonMaleXL_AimMode_C.__Removed_1653F7D946291B91D3E713A910288372_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimMode_C.__Removed_1653F7D946291B91D3E713A910288372_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_C.__Removed_1653F7D946291B91D3E713A910288372_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AE6B RID: 175723 RVA: 0x00A691D0 File Offset: 0x00A673D0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EventReceived_18B59F5945020DB23C42FD8891F18A29(FGameplayEventData Payload)
		{
			GA_CommonMaleXL_AimMode_C.__EventReceived_18B59F5945020DB23C42FD8891F18A29_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimMode_C.__EventReceived_18B59F5945020DB23C42FD8891F18A29_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(GA_CommonMaleXL_AimMode_C.__EventReceived_18B59F5945020DB23C42FD8891F18A29_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimMode_C.__EventReceived_18B59F5945020DB23C42FD8891F18A29_NativeFunctionPtr, (void*)ptr, 1);
			if (Payload != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayEventData.StaticStruct(), &ptr->Payload, Payload.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_C.__EventReceived_18B59F5945020DB23C42FD8891F18A29_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_CommonMaleXL_AimMode_C.__EventReceived_18B59F5945020DB23C42FD8891F18A29_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602AE6C RID: 175724 RVA: 0x00A69248 File Offset: 0x00A67448
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_2871C22A44665795BF80D78EEE1213F4(in FGameplayTag Tag)
		{
			GA_CommonMaleXL_AimMode_C.__Added_2871C22A44665795BF80D78EEE1213F4_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimMode_C.__Added_2871C22A44665795BF80D78EEE1213F4_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_CommonMaleXL_AimMode_C.__Added_2871C22A44665795BF80D78EEE1213F4_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimMode_C.__Added_2871C22A44665795BF80D78EEE1213F4_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_C.__Added_2871C22A44665795BF80D78EEE1213F4_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AE6D RID: 175725 RVA: 0x00A69294 File Offset: 0x00A67494
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_BEBCE37F4E1B69E39F534EBBC1B1FEE7(in FGameplayTag Tag)
		{
			GA_CommonMaleXL_AimMode_C.__Added_BEBCE37F4E1B69E39F534EBBC1B1FEE7_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimMode_C.__Added_BEBCE37F4E1B69E39F534EBBC1B1FEE7_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_CommonMaleXL_AimMode_C.__Added_BEBCE37F4E1B69E39F534EBBC1B1FEE7_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimMode_C.__Added_BEBCE37F4E1B69E39F534EBBC1B1FEE7_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_C.__Added_BEBCE37F4E1B69E39F534EBBC1B1FEE7_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AE6E RID: 175726 RVA: 0x00A692E0 File Offset: 0x00A674E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_BB323FB84E3263466E0BEE98E1B3092A(in FGameplayTag Tag)
		{
			GA_CommonMaleXL_AimMode_C.__Added_BB323FB84E3263466E0BEE98E1B3092A_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimMode_C.__Added_BB323FB84E3263466E0BEE98E1B3092A_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_CommonMaleXL_AimMode_C.__Added_BB323FB84E3263466E0BEE98E1B3092A_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimMode_C.__Added_BB323FB84E3263466E0BEE98E1B3092A_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_C.__Added_BB323FB84E3263466E0BEE98E1B3092A_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AE6F RID: 175727 RVA: 0x00A6932C File Offset: 0x00A6752C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_57B8397E4602013F2C15DF852515BD1D(in FGameplayTag Tag)
		{
			GA_CommonMaleXL_AimMode_C.__Added_57B8397E4602013F2C15DF852515BD1D_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimMode_C.__Added_57B8397E4602013F2C15DF852515BD1D_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_CommonMaleXL_AimMode_C.__Added_57B8397E4602013F2C15DF852515BD1D_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimMode_C.__Added_57B8397E4602013F2C15DF852515BD1D_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_C.__Added_57B8397E4602013F2C15DF852515BD1D_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AE70 RID: 175728 RVA: 0x00A69378 File Offset: 0x00A67578
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_FDAE1367416FE117430C11803F232A8E(in FGameplayTag Tag)
		{
			GA_CommonMaleXL_AimMode_C.__Added_FDAE1367416FE117430C11803F232A8E_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimMode_C.__Added_FDAE1367416FE117430C11803F232A8E_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_CommonMaleXL_AimMode_C.__Added_FDAE1367416FE117430C11803F232A8E_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimMode_C.__Added_FDAE1367416FE117430C11803F232A8E_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_C.__Added_FDAE1367416FE117430C11803F232A8E_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AE71 RID: 175729 RVA: 0x00A693C3 File Offset: 0x00A675C3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602AE72 RID: 175730 RVA: 0x00A693D7 File Offset: 0x00A675D7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602AE73 RID: 175731 RVA: 0x00A693EC File Offset: 0x00A675EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_CommonMaleXL_AimMode_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimMode_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_CommonMaleXL_AimMode_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimMode_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AE74 RID: 175732 RVA: 0x00A69434 File Offset: 0x00A67634
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_CommonMaleXL_AimMode_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimMode_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_CommonMaleXL_AimMode_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimMode_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AE75 RID: 175733 RVA: 0x00A6947B File Offset: 0x00A6767B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomEvent_0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_C.__CustomEvent_0_NativeFunctionPtr, null);
		}

		// Token: 0x0602AE76 RID: 175734 RVA: 0x00A69490 File Offset: 0x00A67690
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_CommonMaleXL_AimMode(int EntryPoint)
		{
			GA_CommonMaleXL_AimMode_C.__ExecuteUbergraph_GA_CommonMaleXL_AimMode_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimMode_C.__ExecuteUbergraph_GA_CommonMaleXL_AimMode_FunctionParams[(UIntPtr)1567] + 15L / (long)sizeof(GA_CommonMaleXL_AimMode_C.__ExecuteUbergraph_GA_CommonMaleXL_AimMode_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimMode_C.__ExecuteUbergraph_GA_CommonMaleXL_AimMode_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_C.__ExecuteUbergraph_GA_CommonMaleXL_AimMode_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AE77 RID: 175735 RVA: 0x00A694DA File Offset: 0x00A676DA
		protected GA_CommonMaleXL_AimMode_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040176DF RID: 95967
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_CommonMaleXL_AimMode.GA_CommonMaleXL_AimMode_C";

		// Token: 0x040176E0 RID: 95968
		private static IntPtr _ClassPtr;

		// Token: 0x040176E1 RID: 95969
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040176E2 RID: 95970
		internal new static int __PropertyOffset_0;

		// Token: 0x040176E3 RID: 95971
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040176E4 RID: 95972
		internal new static int __PropertyOffset_1;

		// Token: 0x040176E5 RID: 95973
		internal new static int __PropertyOffset_2;

		// Token: 0x040176E6 RID: 95974
		internal new static int __PropertyOffset_3;

		// Token: 0x040176E7 RID: 95975
		internal static int __PropertyOffset_4;

		// Token: 0x040176E8 RID: 95976
		internal static int __PropertyOffset_5;

		// Token: 0x040176E9 RID: 95977
		private static IntPtr __自动瞄准处理_NativeFunctionPtr;

		// Token: 0x040176EA RID: 95978
		private static IntPtr __EventReceived_18B59F5945020DB23C42FD88DC330F7F_NativeFunctionPtr;

		// Token: 0x040176EB RID: 95979
		private static IntPtr __Removed_1653F7D946291B91D3E713A910288372_NativeFunctionPtr;

		// Token: 0x040176EC RID: 95980
		private static IntPtr __EventReceived_18B59F5945020DB23C42FD8891F18A29_NativeFunctionPtr;

		// Token: 0x040176ED RID: 95981
		private static IntPtr __Added_2871C22A44665795BF80D78EEE1213F4_NativeFunctionPtr;

		// Token: 0x040176EE RID: 95982
		private static IntPtr __Added_BEBCE37F4E1B69E39F534EBBC1B1FEE7_NativeFunctionPtr;

		// Token: 0x040176EF RID: 95983
		private static IntPtr __Added_BB323FB84E3263466E0BEE98E1B3092A_NativeFunctionPtr;

		// Token: 0x040176F0 RID: 95984
		private static IntPtr __Added_57B8397E4602013F2C15DF852515BD1D_NativeFunctionPtr;

		// Token: 0x040176F1 RID: 95985
		private static IntPtr __Added_FDAE1367416FE117430C11803F232A8E_NativeFunctionPtr;

		// Token: 0x040176F2 RID: 95986
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x040176F3 RID: 95987
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x040176F4 RID: 95988
		private static IntPtr __CustomEvent_0_NativeFunctionPtr;

		// Token: 0x040176F5 RID: 95989
		private static IntPtr __ExecuteUbergraph_GA_CommonMaleXL_AimMode_NativeFunctionPtr;

		// Token: 0x0200A277 RID: 41591
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __自动瞄准处理_FunctionParams
		{
			// Token: 0x04033025 RID: 208933
			[FieldOffset(0)]
			public bool 是否进入自动瞄准;
		}

		// Token: 0x0200A278 RID: 41592
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __EventReceived_18B59F5945020DB23C42FD88DC330F7F_FunctionParams
		{
			// Token: 0x04033026 RID: 208934
			[FieldOffset(0)]
			public byte Payload;
		}

		// Token: 0x0200A279 RID: 41593
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_1653F7D946291B91D3E713A910288372_FunctionParams
		{
			// Token: 0x04033027 RID: 208935
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A27A RID: 41594
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __EventReceived_18B59F5945020DB23C42FD8891F18A29_FunctionParams
		{
			// Token: 0x04033028 RID: 208936
			[FieldOffset(0)]
			public byte Payload;
		}

		// Token: 0x0200A27B RID: 41595
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_2871C22A44665795BF80D78EEE1213F4_FunctionParams
		{
			// Token: 0x04033029 RID: 208937
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A27C RID: 41596
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_BEBCE37F4E1B69E39F534EBBC1B1FEE7_FunctionParams
		{
			// Token: 0x0403302A RID: 208938
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A27D RID: 41597
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_BB323FB84E3263466E0BEE98E1B3092A_FunctionParams
		{
			// Token: 0x0403302B RID: 208939
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A27E RID: 41598
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_57B8397E4602013F2C15DF852515BD1D_FunctionParams
		{
			// Token: 0x0403302C RID: 208940
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A27F RID: 41599
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_FDAE1367416FE117430C11803F232A8E_FunctionParams
		{
			// Token: 0x0403302D RID: 208941
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A280 RID: 41600
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x0403302E RID: 208942
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A281 RID: 41601
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1552)]
		protected ref struct __ExecuteUbergraph_GA_CommonMaleXL_AimMode_FunctionParams
		{
			// Token: 0x0403302F RID: 208943
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
