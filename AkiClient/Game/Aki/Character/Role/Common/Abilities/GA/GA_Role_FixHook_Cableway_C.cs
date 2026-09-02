using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using AkiClient.Game.Aki.GamePlay.Portal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Abilities.GA
{
	// Token: 0x020040A4 RID: 16548
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_FixHook_Cableway.GA_Role_FixHook_Cableway_C")]
	[UnrealStructLayout(1720, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1716)]
	public class GA_Role_FixHook_Cableway_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B150 RID: 176464 RVA: 0x00A6FCEB File Offset: 0x00A6DEEB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Role_FixHook_Cableway_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_FixHook_Cableway.GA_Role_FixHook_Cableway_C");
			}
			return GA_Role_FixHook_Cableway_C._ClassPtr;
		}

		// Token: 0x0602B151 RID: 176465 RVA: 0x00A6FD10 File Offset: 0x00A6DF10
		public GA_Role_FixHook_Cableway_C() : this(BuiltinUtils.AllocNativeUObject(GA_Role_FixHook_Cableway_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B152 RID: 176466 RVA: 0x00A6FD38 File Offset: 0x00A6DF38
		[NullableContext(1)]
		public GA_Role_FixHook_Cableway_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Role_FixHook_Cableway_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170070A4 RID: 28836
		// (get) Token: 0x0602B153 RID: 176467 RVA: 0x00A6FD6C File Offset: 0x00A6DF6C
		// (set) Token: 0x0602B154 RID: 176468 RVA: 0x00A6FDA5 File Offset: 0x00A6DFA5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170070A5 RID: 28837
		// (get) Token: 0x0602B155 RID: 176469 RVA: 0x00A6FDC6 File Offset: 0x00A6DFC6
		// (set) Token: 0x0602B156 RID: 176470 RVA: 0x00A6FDDA File Offset: 0x00A6DFDA
		public unsafe TsBaseCharacter 施法者_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Cableway_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Cableway_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170070A6 RID: 28838
		// (get) Token: 0x0602B157 RID: 176471 RVA: 0x00A6FDEF File Offset: 0x00A6DFEF
		// (set) Token: 0x0602B158 RID: 176472 RVA: 0x00A6FE03 File Offset: 0x00A6E003
		public unsafe FVectorDouble FixHookLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170070A7 RID: 28839
		// (get) Token: 0x0602B159 RID: 176473 RVA: 0x00A6FE18 File Offset: 0x00A6E018
		// (set) Token: 0x0602B15A RID: 176474 RVA: 0x00A6FE2C File Offset: 0x00A6E02C
		public unsafe FVectorDouble 牵引速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170070A8 RID: 28840
		// (get) Token: 0x0602B15B RID: 176475 RVA: 0x00A6FE41 File Offset: 0x00A6E041
		// (set) Token: 0x0602B15C RID: 176476 RVA: 0x00A6FE51 File Offset: 0x00A6E051
		public unsafe float BlockTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170070A9 RID: 28841
		// (get) Token: 0x0602B15D RID: 176477 RVA: 0x00A6FE62 File Offset: 0x00A6E062
		// (set) Token: 0x0602B15E RID: 176478 RVA: 0x00A6FE72 File Offset: 0x00A6E072
		public unsafe float 角色胶囊体半高
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170070AA RID: 28842
		// (get) Token: 0x0602B15F RID: 176479 RVA: 0x00A6FE83 File Offset: 0x00A6E083
		// (set) Token: 0x0602B160 RID: 176480 RVA: 0x00A6FE97 File Offset: 0x00A6E097
		public unsafe FVector LastDirect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170070AB RID: 28843
		// (get) Token: 0x0602B161 RID: 176481 RVA: 0x00A6FEAC File Offset: 0x00A6E0AC
		// (set) Token: 0x0602B162 RID: 176482 RVA: 0x00A6FEE5 File Offset: 0x00A6E0E5
		[Nullable(1)]
		public TArray<FVectorDouble> FixHookPathways
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVectorDouble> result;
				if ((result = this._FixHookPathways) == null)
				{
					result = (this._FixHookPathways = new TArray<FVectorDouble>(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.FixHookPathways.CopyAssign(value);
			}
		}

		// Token: 0x170070AC RID: 28844
		// (get) Token: 0x0602B163 RID: 176483 RVA: 0x00A6FEF3 File Offset: 0x00A6E0F3
		// (set) Token: 0x0602B164 RID: 176484 RVA: 0x00A6FF07 File Offset: 0x00A6E107
		public unsafe BP_KuroPortalCapture_C FixHookEnterPortalCapture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_KuroPortalCapture_C>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Cableway_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Cableway_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170070AD RID: 28845
		// (get) Token: 0x0602B165 RID: 176485 RVA: 0x00A6FF1C File Offset: 0x00A6E11C
		// (set) Token: 0x0602B166 RID: 176486 RVA: 0x00A6FF30 File Offset: 0x00A6E130
		public unsafe FVectorDouble LastLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170070AE RID: 28846
		// (get) Token: 0x0602B167 RID: 176487 RVA: 0x00A6FF45 File Offset: 0x00A6E145
		// (set) Token: 0x0602B168 RID: 176488 RVA: 0x00A6FF55 File Offset: 0x00A6E155
		public unsafe bool 是否忽略碰撞
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x170070AF RID: 28847
		// (get) Token: 0x0602B169 RID: 176489 RVA: 0x00A6FF66 File Offset: 0x00A6E166
		// (set) Token: 0x0602B16A RID: 176490 RVA: 0x00A6FF76 File Offset: 0x00A6E176
		public unsafe int 当前角色穿透值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170070B0 RID: 28848
		// (get) Token: 0x0602B16B RID: 176491 RVA: 0x00A6FF87 File Offset: 0x00A6E187
		// (set) Token: 0x0602B16C RID: 176492 RVA: 0x00A6FF9B File Offset: 0x00A6E19B
		public unsafe UGameplayTask_WaitDelay Async_Task
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UGameplayTask_WaitDelay>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Cableway_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Cableway_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x170070B1 RID: 28849
		// (get) Token: 0x0602B16D RID: 176493 RVA: 0x00A6FFB0 File Offset: 0x00A6E1B0
		// (set) Token: 0x0602B16E RID: 176494 RVA: 0x00A6FFC4 File Offset: 0x00A6E1C4
		public unsafe UKuroBooleanEventBinder OnCableWayMoveEndEvent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroBooleanEventBinder>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Cableway_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Cableway_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x170070B2 RID: 28850
		// (get) Token: 0x0602B16F RID: 176495 RVA: 0x00A6FFD9 File Offset: 0x00A6E1D9
		// (set) Token: 0x0602B170 RID: 176496 RVA: 0x00A6FFE9 File Offset: 0x00A6E1E9
		public unsafe int 变身材质handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170070B3 RID: 28851
		// (get) Token: 0x0602B171 RID: 176497 RVA: 0x00A6FFFA File Offset: 0x00A6E1FA
		// (set) Token: 0x0602B172 RID: 176498 RVA: 0x00A7000A File Offset: 0x00A6E20A
		public unsafe int 变身特效Handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170070B4 RID: 28852
		// (get) Token: 0x0602B173 RID: 176499 RVA: 0x00A7001B File Offset: 0x00A6E21B
		// (set) Token: 0x0602B174 RID: 176500 RVA: 0x00A7002F File Offset: 0x00A6E22F
		public unsafe FVectorDouble Transform_Location
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170070B5 RID: 28853
		// (get) Token: 0x0602B175 RID: 176501 RVA: 0x00A70044 File Offset: 0x00A6E244
		// (set) Token: 0x0602B176 RID: 176502 RVA: 0x00A70054 File Offset: 0x00A6E254
		public unsafe bool 索道被打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x170070B6 RID: 28854
		// (get) Token: 0x0602B177 RID: 176503 RVA: 0x00A70068 File Offset: 0x00A6E268
		// (set) Token: 0x0602B178 RID: 176504 RVA: 0x00A700A1 File Offset: 0x00A6E2A1
		[Nullable(1)]
		public FTimerHandle TimerHandler
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FTimerHandle result;
				if ((result = this._TimerHandler) == null)
				{
					result = (this._TimerHandler = new FTimerHandle(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_18, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FTimerHandle.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_18, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170070B7 RID: 28855
		// (get) Token: 0x0602B179 RID: 176505 RVA: 0x00A700C2 File Offset: 0x00A6E2C2
		// (set) Token: 0x0602B17A RID: 176506 RVA: 0x00A700D6 File Offset: 0x00A6E2D6
		public unsafe FVectorDouble PreviousLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170070B8 RID: 28856
		// (get) Token: 0x0602B17B RID: 176507 RVA: 0x00A700EB File Offset: 0x00A6E2EB
		// (set) Token: 0x0602B17C RID: 176508 RVA: 0x00A700FB File Offset: 0x00A6E2FB
		public unsafe int 变身特效2Handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x0602B17D RID: 176509 RVA: 0x00A7010C File Offset: 0x00A6E30C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 新增是否忽略碰撞()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__新增是否忽略碰撞_NativeFunctionPtr, null);
		}

		// Token: 0x0602B17E RID: 176510 RVA: 0x00A70120 File Offset: 0x00A6E320
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 是否继承速度()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__是否继承速度_NativeFunctionPtr, null);
		}

		// Token: 0x0602B17F RID: 176511 RVA: 0x00A70134 File Offset: 0x00A6E334
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FixHookTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__FixHookTick_NativeFunctionPtr, null);
		}

		// Token: 0x0602B180 RID: 176512 RVA: 0x00A70148 File Offset: 0x00A6E348
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FixHookStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__FixHookStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602B181 RID: 176513 RVA: 0x00A7015C File Offset: 0x00A6E35C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual AActor FindBestHookPoint()
		{
			GA_Role_FixHook_Cableway_C.__FindBestHookPoint_FunctionParams* ptr = stackalloc GA_Role_FixHook_Cableway_C.__FindBestHookPoint_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(GA_Role_FixHook_Cableway_C.__FindBestHookPoint_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_Cableway_C.__FindBestHookPoint_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__FindBestHookPoint_NativeFunctionPtr, (void*)ptr);
			return BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(ptr->__Result);
		}

		// Token: 0x0602B182 RID: 176514 RVA: 0x00A701A8 File Offset: 0x00A6E3A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EventReceived_18B59F5945020DB23C42FD886716202D(FGameplayEventData Payload)
		{
			GA_Role_FixHook_Cableway_C.__EventReceived_18B59F5945020DB23C42FD886716202D_FunctionParams* ptr = stackalloc GA_Role_FixHook_Cableway_C.__EventReceived_18B59F5945020DB23C42FD886716202D_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(GA_Role_FixHook_Cableway_C.__EventReceived_18B59F5945020DB23C42FD886716202D_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_Cableway_C.__EventReceived_18B59F5945020DB23C42FD886716202D_NativeFunctionPtr, (void*)ptr, 1);
			if (Payload != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayEventData.StaticStruct(), &ptr->Payload, Payload.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__EventReceived_18B59F5945020DB23C42FD886716202D_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Role_FixHook_Cableway_C.__EventReceived_18B59F5945020DB23C42FD886716202D_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602B183 RID: 176515 RVA: 0x00A7021D File Offset: 0x00A6E41D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E813F8A2B70()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__OnTick_5D118C384AE61F1C80292E813F8A2B70_NativeFunctionPtr, null);
		}

		// Token: 0x0602B184 RID: 176516 RVA: 0x00A70231 File Offset: 0x00A6E431
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E813F8A2B70()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__OnCancelled_5D118C384AE61F1C80292E813F8A2B70_NativeFunctionPtr, null);
		}

		// Token: 0x0602B185 RID: 176517 RVA: 0x00A70245 File Offset: 0x00A6E445
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E813F8A2B70()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__OnInterrupted_5D118C384AE61F1C80292E813F8A2B70_NativeFunctionPtr, null);
		}

		// Token: 0x0602B186 RID: 176518 RVA: 0x00A70259 File Offset: 0x00A6E459
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E813F8A2B70()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__OnBlendOut_5D118C384AE61F1C80292E813F8A2B70_NativeFunctionPtr, null);
		}

		// Token: 0x0602B187 RID: 176519 RVA: 0x00A7026D File Offset: 0x00A6E46D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E813F8A2B70()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__OnCompleted_5D118C384AE61F1C80292E813F8A2B70_NativeFunctionPtr, null);
		}

		// Token: 0x0602B188 RID: 176520 RVA: 0x00A70281 File Offset: 0x00A6E481
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E81B34355A7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__OnTick_5D118C384AE61F1C80292E81B34355A7_NativeFunctionPtr, null);
		}

		// Token: 0x0602B189 RID: 176521 RVA: 0x00A70295 File Offset: 0x00A6E495
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E81B34355A7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__OnCancelled_5D118C384AE61F1C80292E81B34355A7_NativeFunctionPtr, null);
		}

		// Token: 0x0602B18A RID: 176522 RVA: 0x00A702A9 File Offset: 0x00A6E4A9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E81B34355A7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__OnInterrupted_5D118C384AE61F1C80292E81B34355A7_NativeFunctionPtr, null);
		}

		// Token: 0x0602B18B RID: 176523 RVA: 0x00A702BD File Offset: 0x00A6E4BD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E81B34355A7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__OnBlendOut_5D118C384AE61F1C80292E81B34355A7_NativeFunctionPtr, null);
		}

		// Token: 0x0602B18C RID: 176524 RVA: 0x00A702D1 File Offset: 0x00A6E4D1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E81B34355A7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__OnCompleted_5D118C384AE61F1C80292E81B34355A7_NativeFunctionPtr, null);
		}

		// Token: 0x0602B18D RID: 176525 RVA: 0x00A702E5 File Offset: 0x00A6E4E5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E818D471EB1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__OnTick_5D118C384AE61F1C80292E818D471EB1_NativeFunctionPtr, null);
		}

		// Token: 0x0602B18E RID: 176526 RVA: 0x00A702F9 File Offset: 0x00A6E4F9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E818D471EB1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__OnCancelled_5D118C384AE61F1C80292E818D471EB1_NativeFunctionPtr, null);
		}

		// Token: 0x0602B18F RID: 176527 RVA: 0x00A7030D File Offset: 0x00A6E50D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E818D471EB1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__OnInterrupted_5D118C384AE61F1C80292E818D471EB1_NativeFunctionPtr, null);
		}

		// Token: 0x0602B190 RID: 176528 RVA: 0x00A70321 File Offset: 0x00A6E521
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E818D471EB1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__OnBlendOut_5D118C384AE61F1C80292E818D471EB1_NativeFunctionPtr, null);
		}

		// Token: 0x0602B191 RID: 176529 RVA: 0x00A70335 File Offset: 0x00A6E535
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E818D471EB1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__OnCompleted_5D118C384AE61F1C80292E818D471EB1_NativeFunctionPtr, null);
		}

		// Token: 0x0602B192 RID: 176530 RVA: 0x00A70349 File Offset: 0x00A6E549
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_22CE86984FEF14E805594B9A14FA8757()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__OnFinish_22CE86984FEF14E805594B9A14FA8757_NativeFunctionPtr, null);
		}

		// Token: 0x0602B193 RID: 176531 RVA: 0x00A7035D File Offset: 0x00A6E55D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_22CE86984FEF14E805594B9A14FA8757()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__OnTick_22CE86984FEF14E805594B9A14FA8757_NativeFunctionPtr, null);
		}

		// Token: 0x0602B194 RID: 176532 RVA: 0x00A70371 File Offset: 0x00A6E571
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B195 RID: 176533 RVA: 0x00A70385 File Offset: 0x00A6E585
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B196 RID: 176534 RVA: 0x00A7039C File Offset: 0x00A6E59C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void MovementModeChange(ACharacter Character, EMovementMode PrevMovementMode, byte PreviousCustomMode)
		{
			GA_Role_FixHook_Cableway_C.__MovementModeChange_FunctionParams* ptr = stackalloc GA_Role_FixHook_Cableway_C.__MovementModeChange_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Role_FixHook_Cableway_C.__MovementModeChange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_Cableway_C.__MovementModeChange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Character = ((Character != null) ? Character.NativePtr : IntPtr.Zero);
			ptr->PrevMovementMode = PrevMovementMode;
			ptr->PreviousCustomMode = PreviousCustomMode;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__MovementModeChange_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B197 RID: 176535 RVA: 0x00A70404 File Offset: 0x00A6E604
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void RoleTeleport(FVector Velocity)
		{
			GA_Role_FixHook_Cableway_C.__RoleTeleport_FunctionParams* ptr = stackalloc GA_Role_FixHook_Cableway_C.__RoleTeleport_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Role_FixHook_Cableway_C.__RoleTeleport_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_Cableway_C.__RoleTeleport_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Velocity = Velocity;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__RoleTeleport_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B198 RID: 176536 RVA: 0x00A7044C File Offset: 0x00A6E64C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnCableWayMoveEnd(bool bContent)
		{
			GA_Role_FixHook_Cableway_C.__OnCableWayMoveEnd_FunctionParams* ptr = stackalloc GA_Role_FixHook_Cableway_C.__OnCableWayMoveEnd_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_FixHook_Cableway_C.__OnCableWayMoveEnd_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_Cableway_C.__OnCableWayMoveEnd_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bContent = bContent;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__OnCableWayMoveEnd_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B199 RID: 176537 RVA: 0x00A70494 File Offset: 0x00A6E694
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Role_FixHook_Cableway_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_FixHook_Cableway_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_FixHook_Cableway_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_Cableway_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B19A RID: 176538 RVA: 0x00A704DC File Offset: 0x00A6E6DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Role_FixHook_Cableway_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_FixHook_Cableway_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_FixHook_Cableway_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_Cableway_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B19B RID: 176539 RVA: 0x00A70523 File Offset: 0x00A6E723
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnHookEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__OnHookEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602B19C RID: 176540 RVA: 0x00A70537 File Offset: 0x00A6E737
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCableWayEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__OnCableWayEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602B19D RID: 176541 RVA: 0x00A7054B File Offset: 0x00A6E74B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CableWayStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__CableWayStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602B19E RID: 176542 RVA: 0x00A7055F File Offset: 0x00A6E75F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PlayCableWableEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__PlayCableWableEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602B19F RID: 176543 RVA: 0x00A70573 File Offset: 0x00A6E773
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TrySaveCableLocation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__TrySaveCableLocation_NativeFunctionPtr, null);
		}

		// Token: 0x0602B1A0 RID: 176544 RVA: 0x00A70587 File Offset: 0x00A6E787
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RemoveCableTag()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__RemoveCableTag_NativeFunctionPtr, null);
		}

		// Token: 0x0602B1A1 RID: 176545 RVA: 0x00A7059C File Offset: 0x00A6E79C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Role_FixHook_Cableway(int EntryPoint)
		{
			GA_Role_FixHook_Cableway_C.__ExecuteUbergraph_GA_Role_FixHook_Cableway_FunctionParams* ptr = stackalloc GA_Role_FixHook_Cableway_C.__ExecuteUbergraph_GA_Role_FixHook_Cableway_FunctionParams[(UIntPtr)4175] + 15L / (long)sizeof(GA_Role_FixHook_Cableway_C.__ExecuteUbergraph_GA_Role_FixHook_Cableway_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_Cableway_C.__ExecuteUbergraph_GA_Role_FixHook_Cableway_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_FixHook_Cableway_C.__ExecuteUbergraph_GA_Role_FixHook_Cableway_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B1A2 RID: 176546 RVA: 0x00A705E6 File Offset: 0x00A6E7E6
		protected GA_Role_FixHook_Cableway_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017911 RID: 96529
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_FixHook_Cableway.GA_Role_FixHook_Cableway_C";

		// Token: 0x04017912 RID: 96530
		private static IntPtr _ClassPtr;

		// Token: 0x04017913 RID: 96531
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017914 RID: 96532
		internal new static int __PropertyOffset_0;

		// Token: 0x04017915 RID: 96533
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017916 RID: 96534
		internal new static int __PropertyOffset_1;

		// Token: 0x04017917 RID: 96535
		internal new static int __PropertyOffset_2;

		// Token: 0x04017918 RID: 96536
		internal new static int __PropertyOffset_3;

		// Token: 0x04017919 RID: 96537
		internal static int __PropertyOffset_4;

		// Token: 0x0401791A RID: 96538
		internal static int __PropertyOffset_5;

		// Token: 0x0401791B RID: 96539
		internal static int __PropertyOffset_6;

		// Token: 0x0401791C RID: 96540
		internal static int __PropertyOffset_7;

		// Token: 0x0401791D RID: 96541
		private TArray<FVectorDouble> _FixHookPathways;

		// Token: 0x0401791E RID: 96542
		internal static int __PropertyOffset_8;

		// Token: 0x0401791F RID: 96543
		internal static int __PropertyOffset_9;

		// Token: 0x04017920 RID: 96544
		internal static int __PropertyOffset_10;

		// Token: 0x04017921 RID: 96545
		internal static int __PropertyOffset_11;

		// Token: 0x04017922 RID: 96546
		internal static int __PropertyOffset_12;

		// Token: 0x04017923 RID: 96547
		internal static int __PropertyOffset_13;

		// Token: 0x04017924 RID: 96548
		internal static int __PropertyOffset_14;

		// Token: 0x04017925 RID: 96549
		internal static int __PropertyOffset_15;

		// Token: 0x04017926 RID: 96550
		internal static int __PropertyOffset_16;

		// Token: 0x04017927 RID: 96551
		internal static int __PropertyOffset_17;

		// Token: 0x04017928 RID: 96552
		internal static int __PropertyOffset_18;

		// Token: 0x04017929 RID: 96553
		private FTimerHandle _TimerHandler;

		// Token: 0x0401792A RID: 96554
		internal static int __PropertyOffset_19;

		// Token: 0x0401792B RID: 96555
		internal static int __PropertyOffset_20;

		// Token: 0x0401792C RID: 96556
		private static IntPtr __新增是否忽略碰撞_NativeFunctionPtr;

		// Token: 0x0401792D RID: 96557
		private static IntPtr __是否继承速度_NativeFunctionPtr;

		// Token: 0x0401792E RID: 96558
		private static IntPtr __FixHookTick_NativeFunctionPtr;

		// Token: 0x0401792F RID: 96559
		private static IntPtr __FixHookStart_NativeFunctionPtr;

		// Token: 0x04017930 RID: 96560
		private static IntPtr __FindBestHookPoint_NativeFunctionPtr;

		// Token: 0x04017931 RID: 96561
		private static IntPtr __EventReceived_18B59F5945020DB23C42FD886716202D_NativeFunctionPtr;

		// Token: 0x04017932 RID: 96562
		private static IntPtr __OnTick_5D118C384AE61F1C80292E813F8A2B70_NativeFunctionPtr;

		// Token: 0x04017933 RID: 96563
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E813F8A2B70_NativeFunctionPtr;

		// Token: 0x04017934 RID: 96564
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E813F8A2B70_NativeFunctionPtr;

		// Token: 0x04017935 RID: 96565
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E813F8A2B70_NativeFunctionPtr;

		// Token: 0x04017936 RID: 96566
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E813F8A2B70_NativeFunctionPtr;

		// Token: 0x04017937 RID: 96567
		private static IntPtr __OnTick_5D118C384AE61F1C80292E81B34355A7_NativeFunctionPtr;

		// Token: 0x04017938 RID: 96568
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E81B34355A7_NativeFunctionPtr;

		// Token: 0x04017939 RID: 96569
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E81B34355A7_NativeFunctionPtr;

		// Token: 0x0401793A RID: 96570
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E81B34355A7_NativeFunctionPtr;

		// Token: 0x0401793B RID: 96571
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E81B34355A7_NativeFunctionPtr;

		// Token: 0x0401793C RID: 96572
		private static IntPtr __OnTick_5D118C384AE61F1C80292E818D471EB1_NativeFunctionPtr;

		// Token: 0x0401793D RID: 96573
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E818D471EB1_NativeFunctionPtr;

		// Token: 0x0401793E RID: 96574
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E818D471EB1_NativeFunctionPtr;

		// Token: 0x0401793F RID: 96575
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E818D471EB1_NativeFunctionPtr;

		// Token: 0x04017940 RID: 96576
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E818D471EB1_NativeFunctionPtr;

		// Token: 0x04017941 RID: 96577
		private static IntPtr __OnFinish_22CE86984FEF14E805594B9A14FA8757_NativeFunctionPtr;

		// Token: 0x04017942 RID: 96578
		private static IntPtr __OnTick_22CE86984FEF14E805594B9A14FA8757_NativeFunctionPtr;

		// Token: 0x04017943 RID: 96579
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017944 RID: 96580
		private static IntPtr __MovementModeChange_NativeFunctionPtr;

		// Token: 0x04017945 RID: 96581
		private static IntPtr __RoleTeleport_NativeFunctionPtr;

		// Token: 0x04017946 RID: 96582
		private static IntPtr __OnCableWayMoveEnd_NativeFunctionPtr;

		// Token: 0x04017947 RID: 96583
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017948 RID: 96584
		private static IntPtr __OnHookEnd_NativeFunctionPtr;

		// Token: 0x04017949 RID: 96585
		private static IntPtr __OnCableWayEnd_NativeFunctionPtr;

		// Token: 0x0401794A RID: 96586
		private static IntPtr __CableWayStart_NativeFunctionPtr;

		// Token: 0x0401794B RID: 96587
		private static IntPtr __PlayCableWableEnd_NativeFunctionPtr;

		// Token: 0x0401794C RID: 96588
		private static IntPtr __TrySaveCableLocation_NativeFunctionPtr;

		// Token: 0x0401794D RID: 96589
		private static IntPtr __RemoveCableTag_NativeFunctionPtr;

		// Token: 0x0401794E RID: 96590
		private static IntPtr __ExecuteUbergraph_GA_Role_FixHook_Cableway_NativeFunctionPtr;

		// Token: 0x0200A2E7 RID: 41703
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __FindBestHookPoint_FunctionParams
		{
			// Token: 0x040330AA RID: 209066
			[FieldOffset(0)]
			public IntPtr __Result;
		}

		// Token: 0x0200A2E8 RID: 41704
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __EventReceived_18B59F5945020DB23C42FD886716202D_FunctionParams
		{
			// Token: 0x040330AB RID: 209067
			[FieldOffset(0)]
			public byte Payload;
		}

		// Token: 0x0200A2E9 RID: 41705
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __MovementModeChange_FunctionParams
		{
			// Token: 0x040330AC RID: 209068
			[FieldOffset(0)]
			public IntPtr Character;

			// Token: 0x040330AD RID: 209069
			[FieldOffset(8)]
			public TEnumAsByte<EMovementMode> PrevMovementMode;

			// Token: 0x040330AE RID: 209070
			[FieldOffset(9)]
			public byte PreviousCustomMode;
		}

		// Token: 0x0200A2EA RID: 41706
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __RoleTeleport_FunctionParams
		{
			// Token: 0x040330AF RID: 209071
			[FieldOffset(0)]
			public FVector Velocity;
		}

		// Token: 0x0200A2EB RID: 41707
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __OnCableWayMoveEnd_FunctionParams
		{
			// Token: 0x040330B0 RID: 209072
			[FieldOffset(0)]
			public bool bContent;
		}

		// Token: 0x0200A2EC RID: 41708
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x040330B1 RID: 209073
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A2ED RID: 41709
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4160)]
		protected ref struct __ExecuteUbergraph_GA_Role_FixHook_Cableway_FunctionParams
		{
			// Token: 0x040330B2 RID: 209074
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
