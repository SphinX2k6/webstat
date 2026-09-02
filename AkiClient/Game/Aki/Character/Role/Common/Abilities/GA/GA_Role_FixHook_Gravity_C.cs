using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using AkiClient.Game.Aki.Character.Role.Common.Data.Structure;
using AkiClient.Game.Aki.GamePlay.Portal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Abilities.GA
{
	// Token: 0x020040A6 RID: 16550
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_FixHook_Gravity.GA_Role_FixHook_Gravity_C")]
	[UnrealStructLayout(2176, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2172)]
	public class GA_Role_FixHook_Gravity_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B1F5 RID: 176629 RVA: 0x00A70ED3 File Offset: 0x00A6F0D3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Role_FixHook_Gravity_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_FixHook_Gravity.GA_Role_FixHook_Gravity_C");
			}
			return GA_Role_FixHook_Gravity_C._ClassPtr;
		}

		// Token: 0x0602B1F6 RID: 176630 RVA: 0x00A70EF8 File Offset: 0x00A6F0F8
		public GA_Role_FixHook_Gravity_C() : this(BuiltinUtils.AllocNativeUObject(GA_Role_FixHook_Gravity_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B1F7 RID: 176631 RVA: 0x00A70F20 File Offset: 0x00A6F120
		[NullableContext(1)]
		public GA_Role_FixHook_Gravity_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Role_FixHook_Gravity_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170070D0 RID: 28880
		// (get) Token: 0x0602B1F8 RID: 176632 RVA: 0x00A70F54 File Offset: 0x00A6F154
		// (set) Token: 0x0602B1F9 RID: 176633 RVA: 0x00A70F8D File Offset: 0x00A6F18D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170070D1 RID: 28881
		// (get) Token: 0x0602B1FA RID: 176634 RVA: 0x00A70FAE File Offset: 0x00A6F1AE
		// (set) Token: 0x0602B1FB RID: 176635 RVA: 0x00A70FC2 File Offset: 0x00A6F1C2
		public unsafe TsBaseCharacter 施法者_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Gravity_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Gravity_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170070D2 RID: 28882
		// (get) Token: 0x0602B1FC RID: 176636 RVA: 0x00A70FD7 File Offset: 0x00A6F1D7
		// (set) Token: 0x0602B1FD RID: 176637 RVA: 0x00A70FEB File Offset: 0x00A6F1EB
		public unsafe FVectorDouble FixHookLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170070D3 RID: 28883
		// (get) Token: 0x0602B1FE RID: 176638 RVA: 0x00A71000 File Offset: 0x00A6F200
		// (set) Token: 0x0602B1FF RID: 176639 RVA: 0x00A71014 File Offset: 0x00A6F214
		public unsafe FVectorDouble 牵引速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170070D4 RID: 28884
		// (get) Token: 0x0602B200 RID: 176640 RVA: 0x00A71029 File Offset: 0x00A6F229
		// (set) Token: 0x0602B201 RID: 176641 RVA: 0x00A71039 File Offset: 0x00A6F239
		public unsafe float BlockTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170070D5 RID: 28885
		// (get) Token: 0x0602B202 RID: 176642 RVA: 0x00A7104A File Offset: 0x00A6F24A
		// (set) Token: 0x0602B203 RID: 176643 RVA: 0x00A7105A File Offset: 0x00A6F25A
		public unsafe float 角色胶囊体半高
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170070D6 RID: 28886
		// (get) Token: 0x0602B204 RID: 176644 RVA: 0x00A7106B File Offset: 0x00A6F26B
		// (set) Token: 0x0602B205 RID: 176645 RVA: 0x00A7107F File Offset: 0x00A6F27F
		public unsafe FVector LastDirect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170070D7 RID: 28887
		// (get) Token: 0x0602B206 RID: 176646 RVA: 0x00A71094 File Offset: 0x00A6F294
		// (set) Token: 0x0602B207 RID: 176647 RVA: 0x00A710CD File Offset: 0x00A6F2CD
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
					result = (this._FixHookPathways = new TArray<FVectorDouble>(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.FixHookPathways.CopyAssign(value);
			}
		}

		// Token: 0x170070D8 RID: 28888
		// (get) Token: 0x0602B208 RID: 176648 RVA: 0x00A710DB File Offset: 0x00A6F2DB
		// (set) Token: 0x0602B209 RID: 176649 RVA: 0x00A710EF File Offset: 0x00A6F2EF
		public unsafe BP_KuroPortalCapture_C FixHookEnterPortalCapture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_KuroPortalCapture_C>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Gravity_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Gravity_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170070D9 RID: 28889
		// (get) Token: 0x0602B20A RID: 176650 RVA: 0x00A71104 File Offset: 0x00A6F304
		// (set) Token: 0x0602B20B RID: 176651 RVA: 0x00A71118 File Offset: 0x00A6F318
		public unsafe FVectorDouble LastLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170070DA RID: 28890
		// (get) Token: 0x0602B20C RID: 176652 RVA: 0x00A7112D File Offset: 0x00A6F32D
		// (set) Token: 0x0602B20D RID: 176653 RVA: 0x00A7113D File Offset: 0x00A6F33D
		public unsafe bool 是否忽略碰撞
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x170070DB RID: 28891
		// (get) Token: 0x0602B20E RID: 176654 RVA: 0x00A7114E File Offset: 0x00A6F34E
		// (set) Token: 0x0602B20F RID: 176655 RVA: 0x00A7115E File Offset: 0x00A6F35E
		public unsafe int 当前角色穿透值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170070DC RID: 28892
		// (get) Token: 0x0602B210 RID: 176656 RVA: 0x00A71170 File Offset: 0x00A6F370
		// (set) Token: 0x0602B211 RID: 176657 RVA: 0x00A711A9 File Offset: 0x00A6F3A9
		[Nullable(1)]
		public SCameraModifier_Settings 进入镜头
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				SCameraModifier_Settings result;
				if ((result = this._进入镜头) == null)
				{
					result = (this._进入镜头 = new SCameraModifier_Settings(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_12, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCameraModifier_Settings.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170070DD RID: 28893
		// (get) Token: 0x0602B212 RID: 176658 RVA: 0x00A711CC File Offset: 0x00A6F3CC
		// (set) Token: 0x0602B213 RID: 176659 RVA: 0x00A71205 File Offset: 0x00A6F405
		[Nullable(1)]
		public SCameraModifier_Condition 进入镜头条件
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				SCameraModifier_Condition result;
				if ((result = this._进入镜头条件) == null)
				{
					result = (this._进入镜头条件 = new SCameraModifier_Condition(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_13, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCameraModifier_Condition.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170070DE RID: 28894
		// (get) Token: 0x0602B214 RID: 176660 RVA: 0x00A71226 File Offset: 0x00A6F426
		// (set) Token: 0x0602B215 RID: 176661 RVA: 0x00A7123A File Offset: 0x00A6F43A
		public unsafe BP_QTE_Camera_C StartCamera
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_QTE_Camera_C>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Gravity_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Gravity_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x170070DF RID: 28895
		// (get) Token: 0x0602B216 RID: 176662 RVA: 0x00A7124F File Offset: 0x00A6F44F
		// (set) Token: 0x0602B217 RID: 176663 RVA: 0x00A71263 File Offset: 0x00A6F463
		public unsafe BP_QTE_Camera_C EndCamera
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_QTE_Camera_C>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Gravity_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Gravity_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x170070E0 RID: 28896
		// (get) Token: 0x0602B218 RID: 176664 RVA: 0x00A71278 File Offset: 0x00A6F478
		// (set) Token: 0x0602B219 RID: 176665 RVA: 0x00A71288 File Offset: 0x00A6F488
		public unsafe int 锁定Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170070E1 RID: 28897
		// (get) Token: 0x0602B21A RID: 176666 RVA: 0x00A71299 File Offset: 0x00A6F499
		// (set) Token: 0x0602B21B RID: 176667 RVA: 0x00A712AD File Offset: 0x00A6F4AD
		public unsafe BP_QTE_Camera_C LockCamera
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_QTE_Camera_C>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Gravity_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Gravity_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x170070E2 RID: 28898
		// (get) Token: 0x0602B21C RID: 176668 RVA: 0x00A712C2 File Offset: 0x00A6F4C2
		// (set) Token: 0x0602B21D RID: 176669 RVA: 0x00A712D6 File Offset: 0x00A6F4D6
		public unsafe FVectorDouble 钩锁位置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170070E3 RID: 28899
		// (get) Token: 0x0602B21E RID: 176670 RVA: 0x00A712EB File Offset: 0x00A6F4EB
		// (set) Token: 0x0602B21F RID: 176671 RVA: 0x00A712FB File Offset: 0x00A6F4FB
		public unsafe float 钩锁速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170070E4 RID: 28900
		// (get) Token: 0x0602B220 RID: 176672 RVA: 0x00A7130C File Offset: 0x00A6F50C
		// (set) Token: 0x0602B221 RID: 176673 RVA: 0x00A7131C File Offset: 0x00A6F51C
		public unsafe int 最小钩锁速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170070E5 RID: 28901
		// (get) Token: 0x0602B222 RID: 176674 RVA: 0x00A7132D File Offset: 0x00A6F52D
		// (set) Token: 0x0602B223 RID: 176675 RVA: 0x00A7133D File Offset: 0x00A6F53D
		public unsafe int 最大钩锁速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Gravity_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x0602B224 RID: 176676 RVA: 0x00A7134E File Offset: 0x00A6F54E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 新增是否忽略碰撞()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Gravity_C.__新增是否忽略碰撞_NativeFunctionPtr, null);
		}

		// Token: 0x0602B225 RID: 176677 RVA: 0x00A71362 File Offset: 0x00A6F562
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 是否继承速度()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Gravity_C.__是否继承速度_NativeFunctionPtr, null);
		}

		// Token: 0x0602B226 RID: 176678 RVA: 0x00A71376 File Offset: 0x00A6F576
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FixHookTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Gravity_C.__FixHookTick_NativeFunctionPtr, null);
		}

		// Token: 0x0602B227 RID: 176679 RVA: 0x00A7138A File Offset: 0x00A6F58A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FixHookStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Gravity_C.__FixHookStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602B228 RID: 176680 RVA: 0x00A713A0 File Offset: 0x00A6F5A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual AActor FindBestHookPoint()
		{
			GA_Role_FixHook_Gravity_C.__FindBestHookPoint_FunctionParams* ptr = stackalloc GA_Role_FixHook_Gravity_C.__FindBestHookPoint_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(GA_Role_FixHook_Gravity_C.__FindBestHookPoint_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_Gravity_C.__FindBestHookPoint_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Gravity_C.__FindBestHookPoint_NativeFunctionPtr, (void*)ptr);
			return BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(ptr->__Result);
		}

		// Token: 0x0602B229 RID: 176681 RVA: 0x00A713EC File Offset: 0x00A6F5EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EventReceived_18B59F5945020DB23C42FD889945C5B7(FGameplayEventData Payload)
		{
			GA_Role_FixHook_Gravity_C.__EventReceived_18B59F5945020DB23C42FD889945C5B7_FunctionParams* ptr = stackalloc GA_Role_FixHook_Gravity_C.__EventReceived_18B59F5945020DB23C42FD889945C5B7_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(GA_Role_FixHook_Gravity_C.__EventReceived_18B59F5945020DB23C42FD889945C5B7_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_Gravity_C.__EventReceived_18B59F5945020DB23C42FD889945C5B7_NativeFunctionPtr, (void*)ptr, 1);
			if (Payload != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayEventData.StaticStruct(), &ptr->Payload, Payload.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Gravity_C.__EventReceived_18B59F5945020DB23C42FD889945C5B7_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Role_FixHook_Gravity_C.__EventReceived_18B59F5945020DB23C42FD889945C5B7_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602B22A RID: 176682 RVA: 0x00A71461 File Offset: 0x00A6F661
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_895DA4FA4DCE0F14B4D39B911C5376C1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Gravity_C.__OnFinish_895DA4FA4DCE0F14B4D39B911C5376C1_NativeFunctionPtr, null);
		}

		// Token: 0x0602B22B RID: 176683 RVA: 0x00A71475 File Offset: 0x00A6F675
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_895DA4FA4DCE0F14B4D39B911C5376C1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Gravity_C.__OnTick_895DA4FA4DCE0F14B4D39B911C5376C1_NativeFunctionPtr, null);
		}

		// Token: 0x0602B22C RID: 176684 RVA: 0x00A71489 File Offset: 0x00A6F689
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Gravity_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B22D RID: 176685 RVA: 0x00A7149D File Offset: 0x00A6F69D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_FixHook_Gravity_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B22E RID: 176686 RVA: 0x00A714B4 File Offset: 0x00A6F6B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Role_FixHook_Gravity_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_FixHook_Gravity_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_FixHook_Gravity_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_Gravity_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Gravity_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B22F RID: 176687 RVA: 0x00A714FC File Offset: 0x00A6F6FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Role_FixHook_Gravity_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_FixHook_Gravity_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_FixHook_Gravity_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_Gravity_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_FixHook_Gravity_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B230 RID: 176688 RVA: 0x00A71544 File Offset: 0x00A6F744
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void MovementModeChange(ACharacter Character, EMovementMode PrevMovementMode, byte PreviousCustomMode)
		{
			GA_Role_FixHook_Gravity_C.__MovementModeChange_FunctionParams* ptr = stackalloc GA_Role_FixHook_Gravity_C.__MovementModeChange_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Role_FixHook_Gravity_C.__MovementModeChange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_Gravity_C.__MovementModeChange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Character = ((Character != null) ? Character.NativePtr : IntPtr.Zero);
			ptr->PrevMovementMode = PrevMovementMode;
			ptr->PreviousCustomMode = PreviousCustomMode;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Gravity_C.__MovementModeChange_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B231 RID: 176689 RVA: 0x00A715AC File Offset: 0x00A6F7AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void RoleTeleport(FVector Velocity)
		{
			GA_Role_FixHook_Gravity_C.__RoleTeleport_FunctionParams* ptr = stackalloc GA_Role_FixHook_Gravity_C.__RoleTeleport_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Role_FixHook_Gravity_C.__RoleTeleport_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_Gravity_C.__RoleTeleport_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Velocity = Velocity;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Gravity_C.__RoleTeleport_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B232 RID: 176690 RVA: 0x00A715F4 File Offset: 0x00A6F7F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Role_FixHook_Gravity(int EntryPoint)
		{
			GA_Role_FixHook_Gravity_C.__ExecuteUbergraph_GA_Role_FixHook_Gravity_FunctionParams* ptr = stackalloc GA_Role_FixHook_Gravity_C.__ExecuteUbergraph_GA_Role_FixHook_Gravity_FunctionParams[(UIntPtr)1111] + 15L / (long)sizeof(GA_Role_FixHook_Gravity_C.__ExecuteUbergraph_GA_Role_FixHook_Gravity_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_Gravity_C.__ExecuteUbergraph_GA_Role_FixHook_Gravity_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_FixHook_Gravity_C.__ExecuteUbergraph_GA_Role_FixHook_Gravity_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B233 RID: 176691 RVA: 0x00A7163E File Offset: 0x00A6F83E
		protected GA_Role_FixHook_Gravity_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401798A RID: 96650
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_FixHook_Gravity.GA_Role_FixHook_Gravity_C";

		// Token: 0x0401798B RID: 96651
		private static IntPtr _ClassPtr;

		// Token: 0x0401798C RID: 96652
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401798D RID: 96653
		internal new static int __PropertyOffset_0;

		// Token: 0x0401798E RID: 96654
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401798F RID: 96655
		internal new static int __PropertyOffset_1;

		// Token: 0x04017990 RID: 96656
		internal new static int __PropertyOffset_2;

		// Token: 0x04017991 RID: 96657
		internal new static int __PropertyOffset_3;

		// Token: 0x04017992 RID: 96658
		internal static int __PropertyOffset_4;

		// Token: 0x04017993 RID: 96659
		internal static int __PropertyOffset_5;

		// Token: 0x04017994 RID: 96660
		internal static int __PropertyOffset_6;

		// Token: 0x04017995 RID: 96661
		internal static int __PropertyOffset_7;

		// Token: 0x04017996 RID: 96662
		private TArray<FVectorDouble> _FixHookPathways;

		// Token: 0x04017997 RID: 96663
		internal static int __PropertyOffset_8;

		// Token: 0x04017998 RID: 96664
		internal static int __PropertyOffset_9;

		// Token: 0x04017999 RID: 96665
		internal static int __PropertyOffset_10;

		// Token: 0x0401799A RID: 96666
		internal static int __PropertyOffset_11;

		// Token: 0x0401799B RID: 96667
		internal static int __PropertyOffset_12;

		// Token: 0x0401799C RID: 96668
		private SCameraModifier_Settings _进入镜头;

		// Token: 0x0401799D RID: 96669
		internal static int __PropertyOffset_13;

		// Token: 0x0401799E RID: 96670
		private SCameraModifier_Condition _进入镜头条件;

		// Token: 0x0401799F RID: 96671
		internal static int __PropertyOffset_14;

		// Token: 0x040179A0 RID: 96672
		internal static int __PropertyOffset_15;

		// Token: 0x040179A1 RID: 96673
		internal static int __PropertyOffset_16;

		// Token: 0x040179A2 RID: 96674
		internal static int __PropertyOffset_17;

		// Token: 0x040179A3 RID: 96675
		internal static int __PropertyOffset_18;

		// Token: 0x040179A4 RID: 96676
		internal static int __PropertyOffset_19;

		// Token: 0x040179A5 RID: 96677
		internal static int __PropertyOffset_20;

		// Token: 0x040179A6 RID: 96678
		internal static int __PropertyOffset_21;

		// Token: 0x040179A7 RID: 96679
		private static IntPtr __新增是否忽略碰撞_NativeFunctionPtr;

		// Token: 0x040179A8 RID: 96680
		private static IntPtr __是否继承速度_NativeFunctionPtr;

		// Token: 0x040179A9 RID: 96681
		private static IntPtr __FixHookTick_NativeFunctionPtr;

		// Token: 0x040179AA RID: 96682
		private static IntPtr __FixHookStart_NativeFunctionPtr;

		// Token: 0x040179AB RID: 96683
		private static IntPtr __FindBestHookPoint_NativeFunctionPtr;

		// Token: 0x040179AC RID: 96684
		private static IntPtr __EventReceived_18B59F5945020DB23C42FD889945C5B7_NativeFunctionPtr;

		// Token: 0x040179AD RID: 96685
		private static IntPtr __OnFinish_895DA4FA4DCE0F14B4D39B911C5376C1_NativeFunctionPtr;

		// Token: 0x040179AE RID: 96686
		private static IntPtr __OnTick_895DA4FA4DCE0F14B4D39B911C5376C1_NativeFunctionPtr;

		// Token: 0x040179AF RID: 96687
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x040179B0 RID: 96688
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x040179B1 RID: 96689
		private static IntPtr __MovementModeChange_NativeFunctionPtr;

		// Token: 0x040179B2 RID: 96690
		private static IntPtr __RoleTeleport_NativeFunctionPtr;

		// Token: 0x040179B3 RID: 96691
		private static IntPtr __ExecuteUbergraph_GA_Role_FixHook_Gravity_NativeFunctionPtr;

		// Token: 0x0200A2F5 RID: 41717
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __FindBestHookPoint_FunctionParams
		{
			// Token: 0x040330BC RID: 209084
			[FieldOffset(0)]
			public IntPtr __Result;
		}

		// Token: 0x0200A2F6 RID: 41718
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __EventReceived_18B59F5945020DB23C42FD889945C5B7_FunctionParams
		{
			// Token: 0x040330BD RID: 209085
			[FieldOffset(0)]
			public byte Payload;
		}

		// Token: 0x0200A2F7 RID: 41719
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x040330BE RID: 209086
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A2F8 RID: 41720
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __MovementModeChange_FunctionParams
		{
			// Token: 0x040330BF RID: 209087
			[FieldOffset(0)]
			public IntPtr Character;

			// Token: 0x040330C0 RID: 209088
			[FieldOffset(8)]
			public TEnumAsByte<EMovementMode> PrevMovementMode;

			// Token: 0x040330C1 RID: 209089
			[FieldOffset(9)]
			public byte PreviousCustomMode;
		}

		// Token: 0x0200A2F9 RID: 41721
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __RoleTeleport_FunctionParams
		{
			// Token: 0x040330C2 RID: 209090
			[FieldOffset(0)]
			public FVector Velocity;
		}

		// Token: 0x0200A2FA RID: 41722
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1096)]
		protected ref struct __ExecuteUbergraph_GA_Role_FixHook_Gravity_FunctionParams
		{
			// Token: 0x040330C3 RID: 209091
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
