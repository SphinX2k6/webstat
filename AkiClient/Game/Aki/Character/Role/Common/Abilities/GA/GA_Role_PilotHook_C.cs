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
	// Token: 0x020040B4 RID: 16564
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_PilotHook.GA_Role_PilotHook_C")]
	[UnrealStructLayout(1648, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1644)]
	public class GA_Role_PilotHook_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B367 RID: 176999 RVA: 0x00A746DB File Offset: 0x00A728DB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Role_PilotHook_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_PilotHook.GA_Role_PilotHook_C");
			}
			return GA_Role_PilotHook_C._ClassPtr;
		}

		// Token: 0x0602B368 RID: 177000 RVA: 0x00A74700 File Offset: 0x00A72900
		public GA_Role_PilotHook_C() : this(BuiltinUtils.AllocNativeUObject(GA_Role_PilotHook_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B369 RID: 177001 RVA: 0x00A74728 File Offset: 0x00A72928
		[NullableContext(1)]
		public GA_Role_PilotHook_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Role_PilotHook_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007112 RID: 28946
		// (get) Token: 0x0602B36A RID: 177002 RVA: 0x00A7475C File Offset: 0x00A7295C
		// (set) Token: 0x0602B36B RID: 177003 RVA: 0x00A74795 File Offset: 0x00A72995
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007113 RID: 28947
		// (get) Token: 0x0602B36C RID: 177004 RVA: 0x00A747B6 File Offset: 0x00A729B6
		// (set) Token: 0x0602B36D RID: 177005 RVA: 0x00A747CA File Offset: 0x00A729CA
		public unsafe BP_KuroPortalCapture_C FixHookEnterPortalCapture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_KuroPortalCapture_C>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotHook_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotHook_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007114 RID: 28948
		// (get) Token: 0x0602B36E RID: 177006 RVA: 0x00A747DF File Offset: 0x00A729DF
		// (set) Token: 0x0602B36F RID: 177007 RVA: 0x00A747F3 File Offset: 0x00A729F3
		public unsafe TsBaseCharacter 施法者_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotHook_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotHook_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17007115 RID: 28949
		// (get) Token: 0x0602B370 RID: 177008 RVA: 0x00A74808 File Offset: 0x00A72A08
		// (set) Token: 0x0602B371 RID: 177009 RVA: 0x00A7481C File Offset: 0x00A72A1C
		public unsafe FVectorDouble FixHookLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007116 RID: 28950
		// (get) Token: 0x0602B372 RID: 177010 RVA: 0x00A74831 File Offset: 0x00A72A31
		// (set) Token: 0x0602B373 RID: 177011 RVA: 0x00A74845 File Offset: 0x00A72A45
		public unsafe FVector LastDirect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007117 RID: 28951
		// (get) Token: 0x0602B374 RID: 177012 RVA: 0x00A7485A File Offset: 0x00A72A5A
		// (set) Token: 0x0602B375 RID: 177013 RVA: 0x00A7486E File Offset: 0x00A72A6E
		public unsafe FVectorDouble 牵引速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007118 RID: 28952
		// (get) Token: 0x0602B376 RID: 177014 RVA: 0x00A74883 File Offset: 0x00A72A83
		// (set) Token: 0x0602B377 RID: 177015 RVA: 0x00A74893 File Offset: 0x00A72A93
		public unsafe float BlockTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17007119 RID: 28953
		// (get) Token: 0x0602B378 RID: 177016 RVA: 0x00A748A4 File Offset: 0x00A72AA4
		// (set) Token: 0x0602B379 RID: 177017 RVA: 0x00A748B4 File Offset: 0x00A72AB4
		public unsafe float 角色胶囊体半高
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700711A RID: 28954
		// (get) Token: 0x0602B37A RID: 177018 RVA: 0x00A748C5 File Offset: 0x00A72AC5
		// (set) Token: 0x0602B37B RID: 177019 RVA: 0x00A748D9 File Offset: 0x00A72AD9
		public unsafe FVectorDouble LastLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700711B RID: 28955
		// (get) Token: 0x0602B37C RID: 177020 RVA: 0x00A748EE File Offset: 0x00A72AEE
		// (set) Token: 0x0602B37D RID: 177021 RVA: 0x00A748FE File Offset: 0x00A72AFE
		public unsafe bool hasCue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700711C RID: 28956
		// (get) Token: 0x0602B37E RID: 177022 RVA: 0x00A7490F File Offset: 0x00A72B0F
		// (set) Token: 0x0602B37F RID: 177023 RVA: 0x00A7491F File Offset: 0x00A72B1F
		public unsafe bool 是否忽略碰撞
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700711D RID: 28957
		// (get) Token: 0x0602B380 RID: 177024 RVA: 0x00A74930 File Offset: 0x00A72B30
		// (set) Token: 0x0602B381 RID: 177025 RVA: 0x00A74940 File Offset: 0x00A72B40
		public unsafe int 当前角色穿透值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x1700711E RID: 28958
		// (get) Token: 0x0602B382 RID: 177026 RVA: 0x00A74951 File Offset: 0x00A72B51
		// (set) Token: 0x0602B383 RID: 177027 RVA: 0x00A74965 File Offset: 0x00A72B65
		public unsafe UKuroAnimInstanceRole Kuro_Anim_Instance_Role
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroAnimInstanceRole>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotHook_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotHook_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x1700711F RID: 28959
		// (get) Token: 0x0602B384 RID: 177028 RVA: 0x00A7497A File Offset: 0x00A72B7A
		// (set) Token: 0x0602B385 RID: 177029 RVA: 0x00A7498E File Offset: 0x00A72B8E
		public unsafe USkeletalMeshComponent PilotSkeletal
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotHook_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotHook_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17007120 RID: 28960
		// (get) Token: 0x0602B386 RID: 177030 RVA: 0x00A749A3 File Offset: 0x00A72BA3
		// (set) Token: 0x0602B387 RID: 177031 RVA: 0x00A749B3 File Offset: 0x00A72BB3
		public unsafe int 变身材质handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17007121 RID: 28961
		// (get) Token: 0x0602B388 RID: 177032 RVA: 0x00A749C4 File Offset: 0x00A72BC4
		// (set) Token: 0x0602B389 RID: 177033 RVA: 0x00A749D4 File Offset: 0x00A72BD4
		public unsafe int 变身特效Handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17007122 RID: 28962
		// (get) Token: 0x0602B38A RID: 177034 RVA: 0x00A749E5 File Offset: 0x00A72BE5
		// (set) Token: 0x0602B38B RID: 177035 RVA: 0x00A749F5 File Offset: 0x00A72BF5
		public unsafe int 变身特效2Handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17007123 RID: 28963
		// (get) Token: 0x0602B38C RID: 177036 RVA: 0x00A74A06 File Offset: 0x00A72C06
		// (set) Token: 0x0602B38D RID: 177037 RVA: 0x00A74A16 File Offset: 0x00A72C16
		public unsafe bool ActivateAimGA
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007124 RID: 28964
		// (get) Token: 0x0602B38E RID: 177038 RVA: 0x00A74A27 File Offset: 0x00A72C27
		// (set) Token: 0x0602B38F RID: 177039 RVA: 0x00A74A37 File Offset: 0x00A72C37
		public unsafe int 钩锁ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotHook_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x0602B390 RID: 177040 RVA: 0x00A74A48 File Offset: 0x00A72C48
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void RemoveTags(ref TArray<FGameplayTag> TagsArray)
		{
			GA_Role_PilotHook_C.__RemoveTags_FunctionParams* ptr = stackalloc GA_Role_PilotHook_C.__RemoveTags_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(GA_Role_PilotHook_C.__RemoveTags_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotHook_C.__RemoveTags_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FGameplayTag> tarray = TagsArray;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->TagsArray);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotHook_C.__RemoveTags_NativeFunctionPtr, (void*)ptr);
			TArray<FGameplayTag> tarray2 = TagsArray;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->TagsArray);
			}
			UnrealReflectionUtils.DestroyStruct(GA_Role_PilotHook_C.__RemoveTags_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602B391 RID: 177041 RVA: 0x00A74AC0 File Offset: 0x00A72CC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AddTags(ref TArray<FGameplayTag> TagsArray)
		{
			GA_Role_PilotHook_C.__AddTags_FunctionParams* ptr = stackalloc GA_Role_PilotHook_C.__AddTags_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(GA_Role_PilotHook_C.__AddTags_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotHook_C.__AddTags_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FGameplayTag> tarray = TagsArray;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->TagsArray);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotHook_C.__AddTags_NativeFunctionPtr, (void*)ptr);
			TArray<FGameplayTag> tarray2 = TagsArray;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->TagsArray);
			}
			UnrealReflectionUtils.DestroyStruct(GA_Role_PilotHook_C.__AddTags_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602B392 RID: 177042 RVA: 0x00A74B38 File Offset: 0x00A72D38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EndNiagara()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotHook_C.__EndNiagara_NativeFunctionPtr, null);
		}

		// Token: 0x0602B393 RID: 177043 RVA: 0x00A74B4C File Offset: 0x00A72D4C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void NiagaraSetting()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotHook_C.__NiagaraSetting_NativeFunctionPtr, null);
		}

		// Token: 0x0602B394 RID: 177044 RVA: 0x00A74B60 File Offset: 0x00A72D60
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void onEndAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotHook_C.__onEndAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B395 RID: 177045 RVA: 0x00A74B74 File Offset: 0x00A72D74
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void blockCheck()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotHook_C.__blockCheck_NativeFunctionPtr, null);
		}

		// Token: 0x0602B396 RID: 177046 RVA: 0x00A74B88 File Offset: 0x00A72D88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void onHookEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotHook_C.__onHookEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602B397 RID: 177047 RVA: 0x00A74B9C File Offset: 0x00A72D9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void onBegin()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotHook_C.__onBegin_NativeFunctionPtr, null);
		}

		// Token: 0x0602B398 RID: 177048 RVA: 0x00A74BB0 File Offset: 0x00A72DB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 新增是否忽略碰撞()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotHook_C.__新增是否忽略碰撞_NativeFunctionPtr, null);
		}

		// Token: 0x0602B399 RID: 177049 RVA: 0x00A74BC4 File Offset: 0x00A72DC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 是否继承速度()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotHook_C.__是否继承速度_NativeFunctionPtr, null);
		}

		// Token: 0x0602B39A RID: 177050 RVA: 0x00A74BD8 File Offset: 0x00A72DD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FixHookTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotHook_C.__FixHookTick_NativeFunctionPtr, null);
		}

		// Token: 0x0602B39B RID: 177051 RVA: 0x00A74BEC File Offset: 0x00A72DEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FixHookStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotHook_C.__FixHookStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602B39C RID: 177052 RVA: 0x00A74C00 File Offset: 0x00A72E00
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EventReceived_18B59F5945020DB23C42FD88A691F034(FGameplayEventData Payload)
		{
			GA_Role_PilotHook_C.__EventReceived_18B59F5945020DB23C42FD88A691F034_FunctionParams* ptr = stackalloc GA_Role_PilotHook_C.__EventReceived_18B59F5945020DB23C42FD88A691F034_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(GA_Role_PilotHook_C.__EventReceived_18B59F5945020DB23C42FD88A691F034_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotHook_C.__EventReceived_18B59F5945020DB23C42FD88A691F034_NativeFunctionPtr, (void*)ptr, 1);
			if (Payload != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayEventData.StaticStruct(), &ptr->Payload, Payload.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotHook_C.__EventReceived_18B59F5945020DB23C42FD88A691F034_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Role_PilotHook_C.__EventReceived_18B59F5945020DB23C42FD88A691F034_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602B39D RID: 177053 RVA: 0x00A74C75 File Offset: 0x00A72E75
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E81571DEC2D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotHook_C.__OnTick_5D118C384AE61F1C80292E81571DEC2D_NativeFunctionPtr, null);
		}

		// Token: 0x0602B39E RID: 177054 RVA: 0x00A74C89 File Offset: 0x00A72E89
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E81571DEC2D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotHook_C.__OnCancelled_5D118C384AE61F1C80292E81571DEC2D_NativeFunctionPtr, null);
		}

		// Token: 0x0602B39F RID: 177055 RVA: 0x00A74C9D File Offset: 0x00A72E9D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E81571DEC2D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotHook_C.__OnInterrupted_5D118C384AE61F1C80292E81571DEC2D_NativeFunctionPtr, null);
		}

		// Token: 0x0602B3A0 RID: 177056 RVA: 0x00A74CB1 File Offset: 0x00A72EB1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E81571DEC2D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotHook_C.__OnBlendOut_5D118C384AE61F1C80292E81571DEC2D_NativeFunctionPtr, null);
		}

		// Token: 0x0602B3A1 RID: 177057 RVA: 0x00A74CC5 File Offset: 0x00A72EC5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E81571DEC2D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotHook_C.__OnCompleted_5D118C384AE61F1C80292E81571DEC2D_NativeFunctionPtr, null);
		}

		// Token: 0x0602B3A2 RID: 177058 RVA: 0x00A74CD9 File Offset: 0x00A72ED9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_734E8CD748712D282DDBD08AF57F6B5A()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotHook_C.__OnFinish_734E8CD748712D282DDBD08AF57F6B5A_NativeFunctionPtr, null);
		}

		// Token: 0x0602B3A3 RID: 177059 RVA: 0x00A74CED File Offset: 0x00A72EED
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_734E8CD748712D282DDBD08AF57F6B5A()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotHook_C.__OnTick_734E8CD748712D282DDBD08AF57F6B5A_NativeFunctionPtr, null);
		}

		// Token: 0x0602B3A4 RID: 177060 RVA: 0x00A74D01 File Offset: 0x00A72F01
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_890359DB46F2A7603B4AC88B1AA1AA06()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotHook_C.__OnFinish_890359DB46F2A7603B4AC88B1AA1AA06_NativeFunctionPtr, null);
		}

		// Token: 0x0602B3A5 RID: 177061 RVA: 0x00A74D15 File Offset: 0x00A72F15
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotHook_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B3A6 RID: 177062 RVA: 0x00A74D29 File Offset: 0x00A72F29
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_PilotHook_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B3A7 RID: 177063 RVA: 0x00A74D40 File Offset: 0x00A72F40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Role_PilotHook_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_PilotHook_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_PilotHook_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotHook_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotHook_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B3A8 RID: 177064 RVA: 0x00A74D88 File Offset: 0x00A72F88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Role_PilotHook_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_PilotHook_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_PilotHook_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotHook_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_PilotHook_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B3A9 RID: 177065 RVA: 0x00A74DD0 File Offset: 0x00A72FD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void MovementModeChange(ACharacter Character, EMovementMode PrevMovementMode, byte PreviousCustomMode)
		{
			GA_Role_PilotHook_C.__MovementModeChange_FunctionParams* ptr = stackalloc GA_Role_PilotHook_C.__MovementModeChange_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Role_PilotHook_C.__MovementModeChange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotHook_C.__MovementModeChange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Character = ((Character != null) ? Character.NativePtr : IntPtr.Zero);
			ptr->PrevMovementMode = PrevMovementMode;
			ptr->PreviousCustomMode = PreviousCustomMode;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotHook_C.__MovementModeChange_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B3AA RID: 177066 RVA: 0x00A74E38 File Offset: 0x00A73038
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CueSequence()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotHook_C.__CueSequence_NativeFunctionPtr, null);
		}

		// Token: 0x0602B3AB RID: 177067 RVA: 0x00A74E4C File Offset: 0x00A7304C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EndAbilityRequire()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotHook_C.__EndAbilityRequire_NativeFunctionPtr, null);
		}

		// Token: 0x0602B3AC RID: 177068 RVA: 0x00A74E60 File Offset: 0x00A73060
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PlayMontage()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotHook_C.__PlayMontage_NativeFunctionPtr, null);
		}

		// Token: 0x0602B3AD RID: 177069 RVA: 0x00A74E74 File Offset: 0x00A73074
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Role_PilotHook(int EntryPoint)
		{
			GA_Role_PilotHook_C.__ExecuteUbergraph_GA_Role_PilotHook_FunctionParams* ptr = stackalloc GA_Role_PilotHook_C.__ExecuteUbergraph_GA_Role_PilotHook_FunctionParams[(UIntPtr)1455] + 15L / (long)sizeof(GA_Role_PilotHook_C.__ExecuteUbergraph_GA_Role_PilotHook_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotHook_C.__ExecuteUbergraph_GA_Role_PilotHook_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_PilotHook_C.__ExecuteUbergraph_GA_Role_PilotHook_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B3AE RID: 177070 RVA: 0x00A74EBE File Offset: 0x00A730BE
		protected GA_Role_PilotHook_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017A9F RID: 96927
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_PilotHook.GA_Role_PilotHook_C";

		// Token: 0x04017AA0 RID: 96928
		private static IntPtr _ClassPtr;

		// Token: 0x04017AA1 RID: 96929
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017AA2 RID: 96930
		internal new static int __PropertyOffset_0;

		// Token: 0x04017AA3 RID: 96931
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017AA4 RID: 96932
		internal new static int __PropertyOffset_1;

		// Token: 0x04017AA5 RID: 96933
		internal new static int __PropertyOffset_2;

		// Token: 0x04017AA6 RID: 96934
		internal new static int __PropertyOffset_3;

		// Token: 0x04017AA7 RID: 96935
		internal static int __PropertyOffset_4;

		// Token: 0x04017AA8 RID: 96936
		internal static int __PropertyOffset_5;

		// Token: 0x04017AA9 RID: 96937
		internal static int __PropertyOffset_6;

		// Token: 0x04017AAA RID: 96938
		internal static int __PropertyOffset_7;

		// Token: 0x04017AAB RID: 96939
		internal static int __PropertyOffset_8;

		// Token: 0x04017AAC RID: 96940
		internal static int __PropertyOffset_9;

		// Token: 0x04017AAD RID: 96941
		internal static int __PropertyOffset_10;

		// Token: 0x04017AAE RID: 96942
		internal static int __PropertyOffset_11;

		// Token: 0x04017AAF RID: 96943
		internal static int __PropertyOffset_12;

		// Token: 0x04017AB0 RID: 96944
		internal static int __PropertyOffset_13;

		// Token: 0x04017AB1 RID: 96945
		internal static int __PropertyOffset_14;

		// Token: 0x04017AB2 RID: 96946
		internal static int __PropertyOffset_15;

		// Token: 0x04017AB3 RID: 96947
		internal static int __PropertyOffset_16;

		// Token: 0x04017AB4 RID: 96948
		internal static int __PropertyOffset_17;

		// Token: 0x04017AB5 RID: 96949
		internal static int __PropertyOffset_18;

		// Token: 0x04017AB6 RID: 96950
		private static IntPtr __RemoveTags_NativeFunctionPtr;

		// Token: 0x04017AB7 RID: 96951
		private static IntPtr __AddTags_NativeFunctionPtr;

		// Token: 0x04017AB8 RID: 96952
		private static IntPtr __EndNiagara_NativeFunctionPtr;

		// Token: 0x04017AB9 RID: 96953
		private static IntPtr __NiagaraSetting_NativeFunctionPtr;

		// Token: 0x04017ABA RID: 96954
		private static IntPtr __onEndAbility_NativeFunctionPtr;

		// Token: 0x04017ABB RID: 96955
		private static IntPtr __blockCheck_NativeFunctionPtr;

		// Token: 0x04017ABC RID: 96956
		private static IntPtr __onHookEnd_NativeFunctionPtr;

		// Token: 0x04017ABD RID: 96957
		private static IntPtr __onBegin_NativeFunctionPtr;

		// Token: 0x04017ABE RID: 96958
		private static IntPtr __新增是否忽略碰撞_NativeFunctionPtr;

		// Token: 0x04017ABF RID: 96959
		private static IntPtr __是否继承速度_NativeFunctionPtr;

		// Token: 0x04017AC0 RID: 96960
		private static IntPtr __FixHookTick_NativeFunctionPtr;

		// Token: 0x04017AC1 RID: 96961
		private static IntPtr __FixHookStart_NativeFunctionPtr;

		// Token: 0x04017AC2 RID: 96962
		private static IntPtr __EventReceived_18B59F5945020DB23C42FD88A691F034_NativeFunctionPtr;

		// Token: 0x04017AC3 RID: 96963
		private static IntPtr __OnTick_5D118C384AE61F1C80292E81571DEC2D_NativeFunctionPtr;

		// Token: 0x04017AC4 RID: 96964
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E81571DEC2D_NativeFunctionPtr;

		// Token: 0x04017AC5 RID: 96965
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E81571DEC2D_NativeFunctionPtr;

		// Token: 0x04017AC6 RID: 96966
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E81571DEC2D_NativeFunctionPtr;

		// Token: 0x04017AC7 RID: 96967
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E81571DEC2D_NativeFunctionPtr;

		// Token: 0x04017AC8 RID: 96968
		private static IntPtr __OnFinish_734E8CD748712D282DDBD08AF57F6B5A_NativeFunctionPtr;

		// Token: 0x04017AC9 RID: 96969
		private static IntPtr __OnTick_734E8CD748712D282DDBD08AF57F6B5A_NativeFunctionPtr;

		// Token: 0x04017ACA RID: 96970
		private static IntPtr __OnFinish_890359DB46F2A7603B4AC88B1AA1AA06_NativeFunctionPtr;

		// Token: 0x04017ACB RID: 96971
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017ACC RID: 96972
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017ACD RID: 96973
		private static IntPtr __MovementModeChange_NativeFunctionPtr;

		// Token: 0x04017ACE RID: 96974
		private static IntPtr __CueSequence_NativeFunctionPtr;

		// Token: 0x04017ACF RID: 96975
		private static IntPtr __EndAbilityRequire_NativeFunctionPtr;

		// Token: 0x04017AD0 RID: 96976
		private static IntPtr __PlayMontage_NativeFunctionPtr;

		// Token: 0x04017AD1 RID: 96977
		private static IntPtr __ExecuteUbergraph_GA_Role_PilotHook_NativeFunctionPtr;

		// Token: 0x0200A32C RID: 41772
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __RemoveTags_FunctionParams
		{
			// Token: 0x04033101 RID: 209153
			[FieldOffset(0)]
			public byte TagsArray;
		}

		// Token: 0x0200A32D RID: 41773
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __AddTags_FunctionParams
		{
			// Token: 0x04033102 RID: 209154
			[FieldOffset(0)]
			public byte TagsArray;
		}

		// Token: 0x0200A32E RID: 41774
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __EventReceived_18B59F5945020DB23C42FD88A691F034_FunctionParams
		{
			// Token: 0x04033103 RID: 209155
			[FieldOffset(0)]
			public byte Payload;
		}

		// Token: 0x0200A32F RID: 41775
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033104 RID: 209156
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A330 RID: 41776
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __MovementModeChange_FunctionParams
		{
			// Token: 0x04033105 RID: 209157
			[FieldOffset(0)]
			public IntPtr Character;

			// Token: 0x04033106 RID: 209158
			[FieldOffset(8)]
			public TEnumAsByte<EMovementMode> PrevMovementMode;

			// Token: 0x04033107 RID: 209159
			[FieldOffset(9)]
			public byte PreviousCustomMode;
		}

		// Token: 0x0200A331 RID: 41777
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1440)]
		protected ref struct __ExecuteUbergraph_GA_Role_PilotHook_FunctionParams
		{
			// Token: 0x04033108 RID: 209160
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
