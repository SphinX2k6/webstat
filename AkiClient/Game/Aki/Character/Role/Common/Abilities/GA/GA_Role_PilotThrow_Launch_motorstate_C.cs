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
	// Token: 0x020040B6 RID: 16566
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_PilotThrow_Launch_motorstate.GA_Role_PilotThrow_Launch_motorstate_C")]
	[UnrealStructLayout(1728, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1725)]
	public class GA_Role_PilotThrow_Launch_motorstate_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B3E9 RID: 177129 RVA: 0x00A75537 File Offset: 0x00A73737
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Role_PilotThrow_Launch_motorstate_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_PilotThrow_Launch_motorstate.GA_Role_PilotThrow_Launch_motorstate_C");
			}
			return GA_Role_PilotThrow_Launch_motorstate_C._ClassPtr;
		}

		// Token: 0x0602B3EA RID: 177130 RVA: 0x00A7555C File Offset: 0x00A7375C
		public GA_Role_PilotThrow_Launch_motorstate_C() : this(BuiltinUtils.AllocNativeUObject(GA_Role_PilotThrow_Launch_motorstate_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B3EB RID: 177131 RVA: 0x00A75584 File Offset: 0x00A73784
		[NullableContext(1)]
		public GA_Role_PilotThrow_Launch_motorstate_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Role_PilotThrow_Launch_motorstate_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007134 RID: 28980
		// (get) Token: 0x0602B3EC RID: 177132 RVA: 0x00A755B8 File Offset: 0x00A737B8
		// (set) Token: 0x0602B3ED RID: 177133 RVA: 0x00A755F1 File Offset: 0x00A737F1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007135 RID: 28981
		// (get) Token: 0x0602B3EE RID: 177134 RVA: 0x00A75612 File Offset: 0x00A73812
		// (set) Token: 0x0602B3EF RID: 177135 RVA: 0x00A75626 File Offset: 0x00A73826
		public unsafe TsBaseCharacter 施法者_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007136 RID: 28982
		// (get) Token: 0x0602B3F0 RID: 177136 RVA: 0x00A7563B File Offset: 0x00A7383B
		// (set) Token: 0x0602B3F1 RID: 177137 RVA: 0x00A7564F File Offset: 0x00A7384F
		public unsafe TsBaseVehicle 施法载具
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseVehicle>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17007137 RID: 28983
		// (get) Token: 0x0602B3F2 RID: 177138 RVA: 0x00A75664 File Offset: 0x00A73864
		// (set) Token: 0x0602B3F3 RID: 177139 RVA: 0x00A75674 File Offset: 0x00A73874
		public unsafe int Entity_Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007138 RID: 28984
		// (get) Token: 0x0602B3F4 RID: 177140 RVA: 0x00A75685 File Offset: 0x00A73885
		// (set) Token: 0x0602B3F5 RID: 177141 RVA: 0x00A75695 File Offset: 0x00A73895
		public unsafe float BlockTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007139 RID: 28985
		// (get) Token: 0x0602B3F6 RID: 177142 RVA: 0x00A756A6 File Offset: 0x00A738A6
		// (set) Token: 0x0602B3F7 RID: 177143 RVA: 0x00A756B6 File Offset: 0x00A738B6
		public unsafe float 角色胶囊体半高
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700713A RID: 28986
		// (get) Token: 0x0602B3F8 RID: 177144 RVA: 0x00A756C7 File Offset: 0x00A738C7
		// (set) Token: 0x0602B3F9 RID: 177145 RVA: 0x00A756D7 File Offset: 0x00A738D7
		public unsafe float Gravity_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700713B RID: 28987
		// (get) Token: 0x0602B3FA RID: 177146 RVA: 0x00A756E8 File Offset: 0x00A738E8
		// (set) Token: 0x0602B3FB RID: 177147 RVA: 0x00A756F8 File Offset: 0x00A738F8
		public unsafe float GravityAdd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700713C RID: 28988
		// (get) Token: 0x0602B3FC RID: 177148 RVA: 0x00A75709 File Offset: 0x00A73909
		// (set) Token: 0x0602B3FD RID: 177149 RVA: 0x00A7571D File Offset: 0x00A7391D
		public unsafe FVectorDouble LastLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700713D RID: 28989
		// (get) Token: 0x0602B3FE RID: 177150 RVA: 0x00A75732 File Offset: 0x00A73932
		// (set) Token: 0x0602B3FF RID: 177151 RVA: 0x00A75746 File Offset: 0x00A73946
		public unsafe FVector LastDirect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700713E RID: 28990
		// (get) Token: 0x0602B400 RID: 177152 RVA: 0x00A7575B File Offset: 0x00A7395B
		// (set) Token: 0x0602B401 RID: 177153 RVA: 0x00A7576F File Offset: 0x00A7396F
		public unsafe FVectorDouble LastVelocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700713F RID: 28991
		// (get) Token: 0x0602B402 RID: 177154 RVA: 0x00A75784 File Offset: 0x00A73984
		// (set) Token: 0x0602B403 RID: 177155 RVA: 0x00A75798 File Offset: 0x00A73998
		public unsafe FVectorDouble TargetLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17007140 RID: 28992
		// (get) Token: 0x0602B404 RID: 177156 RVA: 0x00A757AD File Offset: 0x00A739AD
		// (set) Token: 0x0602B405 RID: 177157 RVA: 0x00A757C1 File Offset: 0x00A739C1
		public unsafe FVectorDouble LastDirection
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17007141 RID: 28993
		// (get) Token: 0x0602B406 RID: 177158 RVA: 0x00A757D6 File Offset: 0x00A739D6
		// (set) Token: 0x0602B407 RID: 177159 RVA: 0x00A757EA File Offset: 0x00A739EA
		public unsafe FVectorDouble Direction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17007142 RID: 28994
		// (get) Token: 0x0602B408 RID: 177160 RVA: 0x00A757FF File Offset: 0x00A739FF
		// (set) Token: 0x0602B409 RID: 177161 RVA: 0x00A75813 File Offset: 0x00A73A13
		public unsafe FVectorDouble StartLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17007143 RID: 28995
		// (get) Token: 0x0602B40A RID: 177162 RVA: 0x00A75828 File Offset: 0x00A73A28
		// (set) Token: 0x0602B40B RID: 177163 RVA: 0x00A7583C File Offset: 0x00A73A3C
		public unsafe BP_KuroPortalCapture_C FixHookEnterPortalCapture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_KuroPortalCapture_C>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17007144 RID: 28996
		// (get) Token: 0x0602B40C RID: 177164 RVA: 0x00A75851 File Offset: 0x00A73A51
		// (set) Token: 0x0602B40D RID: 177165 RVA: 0x00A75861 File Offset: 0x00A73A61
		public unsafe bool 是否忽略碰撞
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007145 RID: 28997
		// (get) Token: 0x0602B40E RID: 177166 RVA: 0x00A75872 File Offset: 0x00A73A72
		// (set) Token: 0x0602B40F RID: 177167 RVA: 0x00A75882 File Offset: 0x00A73A82
		public unsafe int 当前角色穿透值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17007146 RID: 28998
		// (get) Token: 0x0602B410 RID: 177168 RVA: 0x00A75893 File Offset: 0x00A73A93
		// (set) Token: 0x0602B411 RID: 177169 RVA: 0x00A758A3 File Offset: 0x00A73AA3
		public unsafe int 速度方向遮挡帧数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17007147 RID: 28999
		// (get) Token: 0x0602B412 RID: 177170 RVA: 0x00A758B4 File Offset: 0x00A73AB4
		// (set) Token: 0x0602B413 RID: 177171 RVA: 0x00A758C4 File Offset: 0x00A73AC4
		public unsafe bool 正常结束技能
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007148 RID: 29000
		// (get) Token: 0x0602B414 RID: 177172 RVA: 0x00A758D5 File Offset: 0x00A73AD5
		// (set) Token: 0x0602B415 RID: 177173 RVA: 0x00A758E5 File Offset: 0x00A73AE5
		public unsafe int 变身特效Handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17007149 RID: 29001
		// (get) Token: 0x0602B416 RID: 177174 RVA: 0x00A758F6 File Offset: 0x00A73AF6
		// (set) Token: 0x0602B417 RID: 177175 RVA: 0x00A75906 File Offset: 0x00A73B06
		public unsafe int 变身特效2Handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x1700714A RID: 29002
		// (get) Token: 0x0602B418 RID: 177176 RVA: 0x00A75917 File Offset: 0x00A73B17
		// (set) Token: 0x0602B419 RID: 177177 RVA: 0x00A75927 File Offset: 0x00A73B27
		public unsafe int 变身材质handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x1700714B RID: 29003
		// (get) Token: 0x0602B41A RID: 177178 RVA: 0x00A75938 File Offset: 0x00A73B38
		// (set) Token: 0x0602B41B RID: 177179 RVA: 0x00A75948 File Offset: 0x00A73B48
		public unsafe bool HasTargetPoint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_motorstate_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602B41C RID: 177180 RVA: 0x00A75959 File Offset: 0x00A73B59
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void GravityOffset()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_motorstate_C.__GravityOffset_NativeFunctionPtr, null);
		}

		// Token: 0x0602B41D RID: 177181 RVA: 0x00A7596D File Offset: 0x00A73B6D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void MaxFlyTimeEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_motorstate_C.__MaxFlyTimeEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602B41E RID: 177182 RVA: 0x00A75981 File Offset: 0x00A73B81
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBegin()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_motorstate_C.__OnBegin_NativeFunctionPtr, null);
		}

		// Token: 0x0602B41F RID: 177183 RVA: 0x00A75995 File Offset: 0x00A73B95
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EndNiagara()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_motorstate_C.__EndNiagara_NativeFunctionPtr, null);
		}

		// Token: 0x0602B420 RID: 177184 RVA: 0x00A759A9 File Offset: 0x00A73BA9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void NiagaraSetting()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_motorstate_C.__NiagaraSetting_NativeFunctionPtr, null);
		}

		// Token: 0x0602B421 RID: 177185 RVA: 0x00A759BD File Offset: 0x00A73BBD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EndAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_motorstate_C.__EndAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B422 RID: 177186 RVA: 0x00A759D1 File Offset: 0x00A73BD1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void LaunchTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_motorstate_C.__LaunchTick_NativeFunctionPtr, null);
		}

		// Token: 0x0602B423 RID: 177187 RVA: 0x00A759E5 File Offset: 0x00A73BE5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void LaunchStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_motorstate_C.__LaunchStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602B424 RID: 177188 RVA: 0x00A759F9 File Offset: 0x00A73BF9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_C90BFF0B4B256F11BDA2A0982AB1E120()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_motorstate_C.__OnFinish_C90BFF0B4B256F11BDA2A0982AB1E120_NativeFunctionPtr, null);
		}

		// Token: 0x0602B425 RID: 177189 RVA: 0x00A75A0D File Offset: 0x00A73C0D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_C90BFF0B4B256F11BDA2A0982AB1E120()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_motorstate_C.__OnTick_C90BFF0B4B256F11BDA2A0982AB1E120_NativeFunctionPtr, null);
		}

		// Token: 0x0602B426 RID: 177190 RVA: 0x00A75A21 File Offset: 0x00A73C21
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_2ABF159C4E4BFE70179B40AC7FF0D2AD()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_motorstate_C.__OnFinish_2ABF159C4E4BFE70179B40AC7FF0D2AD_NativeFunctionPtr, null);
		}

		// Token: 0x0602B427 RID: 177191 RVA: 0x00A75A38 File Offset: 0x00A73C38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void MovementModeChange(ACharacter Character, EMovementMode PrevMovementMode, byte PreviousCustomMode)
		{
			GA_Role_PilotThrow_Launch_motorstate_C.__MovementModeChange_FunctionParams* ptr = stackalloc GA_Role_PilotThrow_Launch_motorstate_C.__MovementModeChange_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Role_PilotThrow_Launch_motorstate_C.__MovementModeChange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotThrow_Launch_motorstate_C.__MovementModeChange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Character = ((Character != null) ? Character.NativePtr : IntPtr.Zero);
			ptr->PrevMovementMode = PrevMovementMode;
			ptr->PreviousCustomMode = PreviousCustomMode;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_motorstate_C.__MovementModeChange_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B428 RID: 177192 RVA: 0x00A75AA0 File Offset: 0x00A73CA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Role_PilotThrow_Launch_motorstate_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_PilotThrow_Launch_motorstate_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_PilotThrow_Launch_motorstate_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotThrow_Launch_motorstate_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_motorstate_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B429 RID: 177193 RVA: 0x00A75AE8 File Offset: 0x00A73CE8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Role_PilotThrow_Launch_motorstate_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_PilotThrow_Launch_motorstate_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_PilotThrow_Launch_motorstate_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotThrow_Launch_motorstate_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_motorstate_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B42A RID: 177194 RVA: 0x00A75B2F File Offset: 0x00A73D2F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_motorstate_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B42B RID: 177195 RVA: 0x00A75B43 File Offset: 0x00A73D43
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_motorstate_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B42C RID: 177196 RVA: 0x00A75B58 File Offset: 0x00A73D58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Role_PilotThrow_Launch_motorstate(int EntryPoint)
		{
			GA_Role_PilotThrow_Launch_motorstate_C.__ExecuteUbergraph_GA_Role_PilotThrow_Launch_motorstate_FunctionParams* ptr = stackalloc GA_Role_PilotThrow_Launch_motorstate_C.__ExecuteUbergraph_GA_Role_PilotThrow_Launch_motorstate_FunctionParams[(UIntPtr)247] + 15L / (long)sizeof(GA_Role_PilotThrow_Launch_motorstate_C.__ExecuteUbergraph_GA_Role_PilotThrow_Launch_motorstate_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotThrow_Launch_motorstate_C.__ExecuteUbergraph_GA_Role_PilotThrow_Launch_motorstate_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_motorstate_C.__ExecuteUbergraph_GA_Role_PilotThrow_Launch_motorstate_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B42D RID: 177197 RVA: 0x00A75BA2 File Offset: 0x00A73DA2
		protected GA_Role_PilotThrow_Launch_motorstate_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017AFB RID: 97019
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_PilotThrow_Launch_motorstate.GA_Role_PilotThrow_Launch_motorstate_C";

		// Token: 0x04017AFC RID: 97020
		private static IntPtr _ClassPtr;

		// Token: 0x04017AFD RID: 97021
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017AFE RID: 97022
		internal new static int __PropertyOffset_0;

		// Token: 0x04017AFF RID: 97023
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017B00 RID: 97024
		internal new static int __PropertyOffset_1;

		// Token: 0x04017B01 RID: 97025
		internal new static int __PropertyOffset_2;

		// Token: 0x04017B02 RID: 97026
		internal new static int __PropertyOffset_3;

		// Token: 0x04017B03 RID: 97027
		internal static int __PropertyOffset_4;

		// Token: 0x04017B04 RID: 97028
		internal static int __PropertyOffset_5;

		// Token: 0x04017B05 RID: 97029
		internal static int __PropertyOffset_6;

		// Token: 0x04017B06 RID: 97030
		internal static int __PropertyOffset_7;

		// Token: 0x04017B07 RID: 97031
		internal static int __PropertyOffset_8;

		// Token: 0x04017B08 RID: 97032
		internal static int __PropertyOffset_9;

		// Token: 0x04017B09 RID: 97033
		internal static int __PropertyOffset_10;

		// Token: 0x04017B0A RID: 97034
		internal static int __PropertyOffset_11;

		// Token: 0x04017B0B RID: 97035
		internal static int __PropertyOffset_12;

		// Token: 0x04017B0C RID: 97036
		internal static int __PropertyOffset_13;

		// Token: 0x04017B0D RID: 97037
		internal static int __PropertyOffset_14;

		// Token: 0x04017B0E RID: 97038
		internal static int __PropertyOffset_15;

		// Token: 0x04017B0F RID: 97039
		internal static int __PropertyOffset_16;

		// Token: 0x04017B10 RID: 97040
		internal static int __PropertyOffset_17;

		// Token: 0x04017B11 RID: 97041
		internal static int __PropertyOffset_18;

		// Token: 0x04017B12 RID: 97042
		internal static int __PropertyOffset_19;

		// Token: 0x04017B13 RID: 97043
		internal static int __PropertyOffset_20;

		// Token: 0x04017B14 RID: 97044
		internal static int __PropertyOffset_21;

		// Token: 0x04017B15 RID: 97045
		internal static int __PropertyOffset_22;

		// Token: 0x04017B16 RID: 97046
		internal static int __PropertyOffset_23;

		// Token: 0x04017B17 RID: 97047
		private static IntPtr __GravityOffset_NativeFunctionPtr;

		// Token: 0x04017B18 RID: 97048
		private static IntPtr __MaxFlyTimeEnd_NativeFunctionPtr;

		// Token: 0x04017B19 RID: 97049
		private static IntPtr __OnBegin_NativeFunctionPtr;

		// Token: 0x04017B1A RID: 97050
		private static IntPtr __EndNiagara_NativeFunctionPtr;

		// Token: 0x04017B1B RID: 97051
		private static IntPtr __NiagaraSetting_NativeFunctionPtr;

		// Token: 0x04017B1C RID: 97052
		private static IntPtr __EndAbility_NativeFunctionPtr;

		// Token: 0x04017B1D RID: 97053
		private static IntPtr __LaunchTick_NativeFunctionPtr;

		// Token: 0x04017B1E RID: 97054
		private static IntPtr __LaunchStart_NativeFunctionPtr;

		// Token: 0x04017B1F RID: 97055
		private static IntPtr __OnFinish_C90BFF0B4B256F11BDA2A0982AB1E120_NativeFunctionPtr;

		// Token: 0x04017B20 RID: 97056
		private static IntPtr __OnTick_C90BFF0B4B256F11BDA2A0982AB1E120_NativeFunctionPtr;

		// Token: 0x04017B21 RID: 97057
		private static IntPtr __OnFinish_2ABF159C4E4BFE70179B40AC7FF0D2AD_NativeFunctionPtr;

		// Token: 0x04017B22 RID: 97058
		private static IntPtr __MovementModeChange_NativeFunctionPtr;

		// Token: 0x04017B23 RID: 97059
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017B24 RID: 97060
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017B25 RID: 97061
		private static IntPtr __ExecuteUbergraph_GA_Role_PilotThrow_Launch_motorstate_NativeFunctionPtr;

		// Token: 0x0200A337 RID: 41783
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __MovementModeChange_FunctionParams
		{
			// Token: 0x04033110 RID: 209168
			[FieldOffset(0)]
			public IntPtr Character;

			// Token: 0x04033111 RID: 209169
			[FieldOffset(8)]
			public TEnumAsByte<EMovementMode> PrevMovementMode;

			// Token: 0x04033112 RID: 209170
			[FieldOffset(9)]
			public byte PreviousCustomMode;
		}

		// Token: 0x0200A338 RID: 41784
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033113 RID: 209171
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A339 RID: 41785
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 232)]
		protected ref struct __ExecuteUbergraph_GA_Role_PilotThrow_Launch_motorstate_FunctionParams
		{
			// Token: 0x04033114 RID: 209172
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
