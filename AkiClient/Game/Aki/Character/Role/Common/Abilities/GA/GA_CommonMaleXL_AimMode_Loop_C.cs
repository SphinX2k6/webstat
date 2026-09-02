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
	// Token: 0x0200407A RID: 16506
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_CommonMaleXL_AimMode_Loop.GA_CommonMaleXL_AimMode_Loop_C")]
	[UnrealStructLayout(1512, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1507)]
	public class GA_CommonMaleXL_AimMode_Loop_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AE78 RID: 175736 RVA: 0x00A694E3 File Offset: 0x00A676E3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_CommonMaleXL_AimMode_Loop_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_CommonMaleXL_AimMode_Loop.GA_CommonMaleXL_AimMode_Loop_C");
			}
			return GA_CommonMaleXL_AimMode_Loop_C._ClassPtr;
		}

		// Token: 0x0602AE79 RID: 175737 RVA: 0x00A69508 File Offset: 0x00A67708
		public GA_CommonMaleXL_AimMode_Loop_C() : this(BuiltinUtils.AllocNativeUObject(GA_CommonMaleXL_AimMode_Loop_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AE7A RID: 175738 RVA: 0x00A69530 File Offset: 0x00A67730
		[NullableContext(1)]
		public GA_CommonMaleXL_AimMode_Loop_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_CommonMaleXL_AimMode_Loop_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007028 RID: 28712
		// (get) Token: 0x0602AE7B RID: 175739 RVA: 0x00A69564 File Offset: 0x00A67764
		// (set) Token: 0x0602AE7C RID: 175740 RVA: 0x00A6959D File Offset: 0x00A6779D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_CommonMaleXL_AimMode_Loop_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_CommonMaleXL_AimMode_Loop_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007029 RID: 28713
		// (get) Token: 0x0602AE7D RID: 175741 RVA: 0x00A695BE File Offset: 0x00A677BE
		// (set) Token: 0x0602AE7E RID: 175742 RVA: 0x00A695D2 File Offset: 0x00A677D2
		[Nullable(2)]
		public unsafe UGameplayTask_WaitDelay Async_Task
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UGameplayTask_WaitDelay>(base.NativePtr / (IntPtr)sizeof(void*) + GA_CommonMaleXL_AimMode_Loop_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_CommonMaleXL_AimMode_Loop_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700702A RID: 28714
		// (get) Token: 0x0602AE7F RID: 175743 RVA: 0x00A695E7 File Offset: 0x00A677E7
		// (set) Token: 0x0602AE80 RID: 175744 RVA: 0x00A695F7 File Offset: 0x00A677F7
		public unsafe bool 按键抬起
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_CommonMaleXL_AimMode_Loop_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_CommonMaleXL_AimMode_Loop_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700702B RID: 28715
		// (get) Token: 0x0602AE81 RID: 175745 RVA: 0x00A69608 File Offset: 0x00A67808
		// (set) Token: 0x0602AE82 RID: 175746 RVA: 0x00A69618 File Offset: 0x00A67818
		public unsafe int 蓄力特效子弹
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_CommonMaleXL_AimMode_Loop_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_CommonMaleXL_AimMode_Loop_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700702C RID: 28716
		// (get) Token: 0x0602AE83 RID: 175747 RVA: 0x00A69629 File Offset: 0x00A67829
		// (set) Token: 0x0602AE84 RID: 175748 RVA: 0x00A69639 File Offset: 0x00A67839
		public unsafe bool 射击中
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_CommonMaleXL_AimMode_Loop_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_CommonMaleXL_AimMode_Loop_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700702D RID: 28717
		// (get) Token: 0x0602AE85 RID: 175749 RVA: 0x00A6964A File Offset: 0x00A6784A
		// (set) Token: 0x0602AE86 RID: 175750 RVA: 0x00A6965A File Offset: 0x00A6785A
		public unsafe bool 蓄力开始
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_CommonMaleXL_AimMode_Loop_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_CommonMaleXL_AimMode_Loop_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700702E RID: 28718
		// (get) Token: 0x0602AE87 RID: 175751 RVA: 0x00A6966B File Offset: 0x00A6786B
		// (set) Token: 0x0602AE88 RID: 175752 RVA: 0x00A6967B File Offset: 0x00A6787B
		public unsafe bool 已退出瞄准
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_CommonMaleXL_AimMode_Loop_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_CommonMaleXL_AimMode_Loop_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602AE89 RID: 175753 RVA: 0x00A6968C File Offset: 0x00A6788C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EventReceived_18B59F5945020DB23C42FD8813455167(FGameplayEventData Payload)
		{
			GA_CommonMaleXL_AimMode_Loop_C.__EventReceived_18B59F5945020DB23C42FD8813455167_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimMode_Loop_C.__EventReceived_18B59F5945020DB23C42FD8813455167_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(GA_CommonMaleXL_AimMode_Loop_C.__EventReceived_18B59F5945020DB23C42FD8813455167_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimMode_Loop_C.__EventReceived_18B59F5945020DB23C42FD8813455167_NativeFunctionPtr, (void*)ptr, 1);
			if (Payload != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayEventData.StaticStruct(), &ptr->Payload, Payload.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_Loop_C.__EventReceived_18B59F5945020DB23C42FD8813455167_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_CommonMaleXL_AimMode_Loop_C.__EventReceived_18B59F5945020DB23C42FD8813455167_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602AE8A RID: 175754 RVA: 0x00A69704 File Offset: 0x00A67904
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EventReceived_18B59F5945020DB23C42FD8853A2FB4C(FGameplayEventData Payload)
		{
			GA_CommonMaleXL_AimMode_Loop_C.__EventReceived_18B59F5945020DB23C42FD8853A2FB4C_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimMode_Loop_C.__EventReceived_18B59F5945020DB23C42FD8853A2FB4C_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(GA_CommonMaleXL_AimMode_Loop_C.__EventReceived_18B59F5945020DB23C42FD8853A2FB4C_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimMode_Loop_C.__EventReceived_18B59F5945020DB23C42FD8853A2FB4C_NativeFunctionPtr, (void*)ptr, 1);
			if (Payload != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayEventData.StaticStruct(), &ptr->Payload, Payload.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_Loop_C.__EventReceived_18B59F5945020DB23C42FD8853A2FB4C_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_CommonMaleXL_AimMode_Loop_C.__EventReceived_18B59F5945020DB23C42FD8853A2FB4C_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602AE8B RID: 175755 RVA: 0x00A6977C File Offset: 0x00A6797C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EventReceived_18B59F5945020DB23C42FD887623D1BB(FGameplayEventData Payload)
		{
			GA_CommonMaleXL_AimMode_Loop_C.__EventReceived_18B59F5945020DB23C42FD887623D1BB_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimMode_Loop_C.__EventReceived_18B59F5945020DB23C42FD887623D1BB_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(GA_CommonMaleXL_AimMode_Loop_C.__EventReceived_18B59F5945020DB23C42FD887623D1BB_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimMode_Loop_C.__EventReceived_18B59F5945020DB23C42FD887623D1BB_NativeFunctionPtr, (void*)ptr, 1);
			if (Payload != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayEventData.StaticStruct(), &ptr->Payload, Payload.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_Loop_C.__EventReceived_18B59F5945020DB23C42FD887623D1BB_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_CommonMaleXL_AimMode_Loop_C.__EventReceived_18B59F5945020DB23C42FD887623D1BB_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602AE8C RID: 175756 RVA: 0x00A697F4 File Offset: 0x00A679F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_1DD1C85741CD361EAE7F4B9DCD34F648(in FGameplayTag Tag)
		{
			GA_CommonMaleXL_AimMode_Loop_C.__Removed_1DD1C85741CD361EAE7F4B9DCD34F648_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimMode_Loop_C.__Removed_1DD1C85741CD361EAE7F4B9DCD34F648_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_CommonMaleXL_AimMode_Loop_C.__Removed_1DD1C85741CD361EAE7F4B9DCD34F648_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimMode_Loop_C.__Removed_1DD1C85741CD361EAE7F4B9DCD34F648_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_Loop_C.__Removed_1DD1C85741CD361EAE7F4B9DCD34F648_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AE8D RID: 175757 RVA: 0x00A69840 File Offset: 0x00A67A40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_E54B386745D796C6622339856AC999E7(in FGameplayTag Tag)
		{
			GA_CommonMaleXL_AimMode_Loop_C.__Added_E54B386745D796C6622339856AC999E7_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimMode_Loop_C.__Added_E54B386745D796C6622339856AC999E7_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_CommonMaleXL_AimMode_Loop_C.__Added_E54B386745D796C6622339856AC999E7_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimMode_Loop_C.__Added_E54B386745D796C6622339856AC999E7_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_Loop_C.__Added_E54B386745D796C6622339856AC999E7_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AE8E RID: 175758 RVA: 0x00A6988C File Offset: 0x00A67A8C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_CF1629154081ACA2BB4E2DB5CFBB1DEC(in FGameplayTag Tag)
		{
			GA_CommonMaleXL_AimMode_Loop_C.__Added_CF1629154081ACA2BB4E2DB5CFBB1DEC_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimMode_Loop_C.__Added_CF1629154081ACA2BB4E2DB5CFBB1DEC_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_CommonMaleXL_AimMode_Loop_C.__Added_CF1629154081ACA2BB4E2DB5CFBB1DEC_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimMode_Loop_C.__Added_CF1629154081ACA2BB4E2DB5CFBB1DEC_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_Loop_C.__Added_CF1629154081ACA2BB4E2DB5CFBB1DEC_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AE8F RID: 175759 RVA: 0x00A698D8 File Offset: 0x00A67AD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_A2C134B24491879E7774C49150B5709A(in FGameplayTag Tag)
		{
			GA_CommonMaleXL_AimMode_Loop_C.__Added_A2C134B24491879E7774C49150B5709A_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimMode_Loop_C.__Added_A2C134B24491879E7774C49150B5709A_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_CommonMaleXL_AimMode_Loop_C.__Added_A2C134B24491879E7774C49150B5709A_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimMode_Loop_C.__Added_A2C134B24491879E7774C49150B5709A_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_Loop_C.__Added_A2C134B24491879E7774C49150B5709A_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AE90 RID: 175760 RVA: 0x00A69924 File Offset: 0x00A67B24
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_D8B84C7B40B280C4C7DFFEAC63C9CCF3(in FGameplayTag Tag)
		{
			GA_CommonMaleXL_AimMode_Loop_C.__Added_D8B84C7B40B280C4C7DFFEAC63C9CCF3_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimMode_Loop_C.__Added_D8B84C7B40B280C4C7DFFEAC63C9CCF3_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_CommonMaleXL_AimMode_Loop_C.__Added_D8B84C7B40B280C4C7DFFEAC63C9CCF3_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimMode_Loop_C.__Added_D8B84C7B40B280C4C7DFFEAC63C9CCF3_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_Loop_C.__Added_D8B84C7B40B280C4C7DFFEAC63C9CCF3_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AE91 RID: 175761 RVA: 0x00A69970 File Offset: 0x00A67B70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_7970F50E429588213C1DCE818F152235(in FGameplayTag Tag)
		{
			GA_CommonMaleXL_AimMode_Loop_C.__Added_7970F50E429588213C1DCE818F152235_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimMode_Loop_C.__Added_7970F50E429588213C1DCE818F152235_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_CommonMaleXL_AimMode_Loop_C.__Added_7970F50E429588213C1DCE818F152235_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimMode_Loop_C.__Added_7970F50E429588213C1DCE818F152235_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_Loop_C.__Added_7970F50E429588213C1DCE818F152235_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AE92 RID: 175762 RVA: 0x00A699BC File Offset: 0x00A67BBC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_D4BA4CDF4C987EAD3860C4B25FEE65FA(in FGameplayTag Tag)
		{
			GA_CommonMaleXL_AimMode_Loop_C.__Removed_D4BA4CDF4C987EAD3860C4B25FEE65FA_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimMode_Loop_C.__Removed_D4BA4CDF4C987EAD3860C4B25FEE65FA_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_CommonMaleXL_AimMode_Loop_C.__Removed_D4BA4CDF4C987EAD3860C4B25FEE65FA_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimMode_Loop_C.__Removed_D4BA4CDF4C987EAD3860C4B25FEE65FA_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_Loop_C.__Removed_D4BA4CDF4C987EAD3860C4B25FEE65FA_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AE93 RID: 175763 RVA: 0x00A69A07 File Offset: 0x00A67C07
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_Loop_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602AE94 RID: 175764 RVA: 0x00A69A1B File Offset: 0x00A67C1B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_Loop_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602AE95 RID: 175765 RVA: 0x00A69A30 File Offset: 0x00A67C30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_CommonMaleXL_AimMode_Loop_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimMode_Loop_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_CommonMaleXL_AimMode_Loop_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimMode_Loop_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_Loop_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AE96 RID: 175766 RVA: 0x00A69A78 File Offset: 0x00A67C78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_CommonMaleXL_AimMode_Loop_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimMode_Loop_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_CommonMaleXL_AimMode_Loop_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimMode_Loop_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_Loop_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AE97 RID: 175767 RVA: 0x00A69AC0 File Offset: 0x00A67CC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_CommonMaleXL_AimMode_Loop(int EntryPoint)
		{
			GA_CommonMaleXL_AimMode_Loop_C.__ExecuteUbergraph_GA_CommonMaleXL_AimMode_Loop_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimMode_Loop_C.__ExecuteUbergraph_GA_CommonMaleXL_AimMode_Loop_FunctionParams[(UIntPtr)1935] + 15L / (long)sizeof(GA_CommonMaleXL_AimMode_Loop_C.__ExecuteUbergraph_GA_CommonMaleXL_AimMode_Loop_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimMode_Loop_C.__ExecuteUbergraph_GA_CommonMaleXL_AimMode_Loop_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_CommonMaleXL_AimMode_Loop_C.__ExecuteUbergraph_GA_CommonMaleXL_AimMode_Loop_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AE98 RID: 175768 RVA: 0x00A69B0A File Offset: 0x00A67D0A
		protected GA_CommonMaleXL_AimMode_Loop_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040176F6 RID: 95990
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_CommonMaleXL_AimMode_Loop.GA_CommonMaleXL_AimMode_Loop_C";

		// Token: 0x040176F7 RID: 95991
		private static IntPtr _ClassPtr;

		// Token: 0x040176F8 RID: 95992
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040176F9 RID: 95993
		internal new static int __PropertyOffset_0;

		// Token: 0x040176FA RID: 95994
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040176FB RID: 95995
		internal new static int __PropertyOffset_1;

		// Token: 0x040176FC RID: 95996
		internal new static int __PropertyOffset_2;

		// Token: 0x040176FD RID: 95997
		internal new static int __PropertyOffset_3;

		// Token: 0x040176FE RID: 95998
		internal static int __PropertyOffset_4;

		// Token: 0x040176FF RID: 95999
		internal static int __PropertyOffset_5;

		// Token: 0x04017700 RID: 96000
		internal static int __PropertyOffset_6;

		// Token: 0x04017701 RID: 96001
		private static IntPtr __EventReceived_18B59F5945020DB23C42FD8813455167_NativeFunctionPtr;

		// Token: 0x04017702 RID: 96002
		private static IntPtr __EventReceived_18B59F5945020DB23C42FD8853A2FB4C_NativeFunctionPtr;

		// Token: 0x04017703 RID: 96003
		private static IntPtr __EventReceived_18B59F5945020DB23C42FD887623D1BB_NativeFunctionPtr;

		// Token: 0x04017704 RID: 96004
		private static IntPtr __Removed_1DD1C85741CD361EAE7F4B9DCD34F648_NativeFunctionPtr;

		// Token: 0x04017705 RID: 96005
		private static IntPtr __Added_E54B386745D796C6622339856AC999E7_NativeFunctionPtr;

		// Token: 0x04017706 RID: 96006
		private static IntPtr __Added_CF1629154081ACA2BB4E2DB5CFBB1DEC_NativeFunctionPtr;

		// Token: 0x04017707 RID: 96007
		private static IntPtr __Added_A2C134B24491879E7774C49150B5709A_NativeFunctionPtr;

		// Token: 0x04017708 RID: 96008
		private static IntPtr __Added_D8B84C7B40B280C4C7DFFEAC63C9CCF3_NativeFunctionPtr;

		// Token: 0x04017709 RID: 96009
		private static IntPtr __Added_7970F50E429588213C1DCE818F152235_NativeFunctionPtr;

		// Token: 0x0401770A RID: 96010
		private static IntPtr __Removed_D4BA4CDF4C987EAD3860C4B25FEE65FA_NativeFunctionPtr;

		// Token: 0x0401770B RID: 96011
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x0401770C RID: 96012
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x0401770D RID: 96013
		private static IntPtr __ExecuteUbergraph_GA_CommonMaleXL_AimMode_Loop_NativeFunctionPtr;

		// Token: 0x0200A282 RID: 41602
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __EventReceived_18B59F5945020DB23C42FD8813455167_FunctionParams
		{
			// Token: 0x04033030 RID: 208944
			[FieldOffset(0)]
			public byte Payload;
		}

		// Token: 0x0200A283 RID: 41603
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __EventReceived_18B59F5945020DB23C42FD8853A2FB4C_FunctionParams
		{
			// Token: 0x04033031 RID: 208945
			[FieldOffset(0)]
			public byte Payload;
		}

		// Token: 0x0200A284 RID: 41604
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __EventReceived_18B59F5945020DB23C42FD887623D1BB_FunctionParams
		{
			// Token: 0x04033032 RID: 208946
			[FieldOffset(0)]
			public byte Payload;
		}

		// Token: 0x0200A285 RID: 41605
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_1DD1C85741CD361EAE7F4B9DCD34F648_FunctionParams
		{
			// Token: 0x04033033 RID: 208947
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A286 RID: 41606
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_E54B386745D796C6622339856AC999E7_FunctionParams
		{
			// Token: 0x04033034 RID: 208948
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A287 RID: 41607
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_CF1629154081ACA2BB4E2DB5CFBB1DEC_FunctionParams
		{
			// Token: 0x04033035 RID: 208949
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A288 RID: 41608
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_A2C134B24491879E7774C49150B5709A_FunctionParams
		{
			// Token: 0x04033036 RID: 208950
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A289 RID: 41609
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_D8B84C7B40B280C4C7DFFEAC63C9CCF3_FunctionParams
		{
			// Token: 0x04033037 RID: 208951
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A28A RID: 41610
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_7970F50E429588213C1DCE818F152235_FunctionParams
		{
			// Token: 0x04033038 RID: 208952
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A28B RID: 41611
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_D4BA4CDF4C987EAD3860C4B25FEE65FA_FunctionParams
		{
			// Token: 0x04033039 RID: 208953
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A28C RID: 41612
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x0403303A RID: 208954
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A28D RID: 41613
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1920)]
		protected ref struct __ExecuteUbergraph_GA_CommonMaleXL_AimMode_Loop_FunctionParams
		{
			// Token: 0x0403303B RID: 208955
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
