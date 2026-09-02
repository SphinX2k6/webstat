using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Level.KeepFollowing
{
	// Token: 0x02003E7A RID: 15994
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Level/KeepFollowing/BP_KeepFollowingConfig.BP_KeepFollowingConfig_C")]
	[UnrealStructLayout(352, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 348)]
	public class BP_KeepFollowingConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06027965 RID: 162149 RVA: 0x009F5AD2 File Offset: 0x009F3CD2
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KeepFollowingConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Level/KeepFollowing/BP_KeepFollowingConfig.BP_KeepFollowingConfig_C");
			}
			return BP_KeepFollowingConfig_C._ClassPtr;
		}

		// Token: 0x06027966 RID: 162150 RVA: 0x009F5AF8 File Offset: 0x009F3CF8
		public BP_KeepFollowingConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_KeepFollowingConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06027967 RID: 162151 RVA: 0x009F5B20 File Offset: 0x009F3D20
		public BP_KeepFollowingConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KeepFollowingConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005DB7 RID: 23991
		// (get) Token: 0x06027968 RID: 162152 RVA: 0x009F5B53 File Offset: 0x009F3D53
		// (set) Token: 0x06027969 RID: 162153 RVA: 0x009F5B67 File Offset: 0x009F3D67
		public unsafe FVector2D 步行跟随方位向量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005DB8 RID: 23992
		// (get) Token: 0x0602796A RID: 162154 RVA: 0x009F5B7C File Offset: 0x009F3D7C
		// (set) Token: 0x0602796B RID: 162155 RVA: 0x009F5B90 File Offset: 0x009F3D90
		public unsafe FVector2D 跑步跟随方位向量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005DB9 RID: 23993
		// (get) Token: 0x0602796C RID: 162156 RVA: 0x009F5BA5 File Offset: 0x009F3DA5
		// (set) Token: 0x0602796D RID: 162157 RVA: 0x009F5BB9 File Offset: 0x009F3DB9
		public unsafe FVector2D 跟随变速范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005DBA RID: 23994
		// (get) Token: 0x0602796E RID: 162158 RVA: 0x009F5BCE File Offset: 0x009F3DCE
		// (set) Token: 0x0602796F RID: 162159 RVA: 0x009F5BDE File Offset: 0x009F3DDE
		public unsafe bool 是否启用位移修正
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005DBB RID: 23995
		// (get) Token: 0x06027970 RID: 162160 RVA: 0x009F5BEF File Offset: 0x009F3DEF
		// (set) Token: 0x06027971 RID: 162161 RVA: 0x009F5BFF File Offset: 0x009F3DFF
		public unsafe int 位移修正距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005DBC RID: 23996
		// (get) Token: 0x06027972 RID: 162162 RVA: 0x009F5C10 File Offset: 0x009F3E10
		// (set) Token: 0x06027973 RID: 162163 RVA: 0x009F5C20 File Offset: 0x009F3E20
		public unsafe int 保持站立距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005DBD RID: 23997
		// (get) Token: 0x06027974 RID: 162164 RVA: 0x009F5C31 File Offset: 0x009F3E31
		// (set) Token: 0x06027975 RID: 162165 RVA: 0x009F5C41 File Offset: 0x009F3E41
		public unsafe int 走跑状态分界速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005DBE RID: 23998
		// (get) Token: 0x06027976 RID: 162166 RVA: 0x009F5C52 File Offset: 0x009F3E52
		// (set) Token: 0x06027977 RID: 162167 RVA: 0x009F5C62 File Offset: 0x009F3E62
		public unsafe int 走跑分界速度浮动
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005DBF RID: 23999
		// (get) Token: 0x06027978 RID: 162168 RVA: 0x009F5C73 File Offset: 0x009F3E73
		// (set) Token: 0x06027979 RID: 162169 RVA: 0x009F5C83 File Offset: 0x009F3E83
		public unsafe int 跑冲刺分界速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005DC0 RID: 24000
		// (get) Token: 0x0602797A RID: 162170 RVA: 0x009F5C94 File Offset: 0x009F3E94
		// (set) Token: 0x0602797B RID: 162171 RVA: 0x009F5CA4 File Offset: 0x009F3EA4
		public unsafe int 跑冲刺分界速度浮动
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005DC1 RID: 24001
		// (get) Token: 0x0602797C RID: 162172 RVA: 0x009F5CB5 File Offset: 0x009F3EB5
		// (set) Token: 0x0602797D RID: 162173 RVA: 0x009F5CC5 File Offset: 0x009F3EC5
		public unsafe int 跟随距离容差
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005DC2 RID: 24002
		// (get) Token: 0x0602797E RID: 162174 RVA: 0x009F5CD6 File Offset: 0x009F3ED6
		// (set) Token: 0x0602797F RID: 162175 RVA: 0x009F5CE6 File Offset: 0x009F3EE6
		public unsafe int 转向角度容差
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17005DC3 RID: 24003
		// (get) Token: 0x06027980 RID: 162176 RVA: 0x009F5CF7 File Offset: 0x009F3EF7
		// (set) Token: 0x06027981 RID: 162177 RVA: 0x009F5D07 File Offset: 0x009F3F07
		public unsafe int 最大转向持续时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17005DC4 RID: 24004
		// (get) Token: 0x06027982 RID: 162178 RVA: 0x009F5D18 File Offset: 0x009F3F18
		// (set) Token: 0x06027983 RID: 162179 RVA: 0x009F5D28 File Offset: 0x009F3F28
		public unsafe int 变速加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17005DC5 RID: 24005
		// (get) Token: 0x06027984 RID: 162180 RVA: 0x009F5D39 File Offset: 0x009F3F39
		// (set) Token: 0x06027985 RID: 162181 RVA: 0x009F5D49 File Offset: 0x009F3F49
		public unsafe int 转向速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17005DC6 RID: 24006
		// (get) Token: 0x06027986 RID: 162182 RVA: 0x009F5D5A File Offset: 0x009F3F5A
		// (set) Token: 0x06027987 RID: 162183 RVA: 0x009F5D6A File Offset: 0x009F3F6A
		public unsafe int 高低差允许范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17005DC7 RID: 24007
		// (get) Token: 0x06027988 RID: 162184 RVA: 0x009F5D7B File Offset: 0x009F3F7B
		// (set) Token: 0x06027989 RID: 162185 RVA: 0x009F5D8B File Offset: 0x009F3F8B
		public unsafe bool DebugDraw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005DC8 RID: 24008
		// (get) Token: 0x0602798A RID: 162186 RVA: 0x009F5D9C File Offset: 0x009F3F9C
		// (set) Token: 0x0602798B RID: 162187 RVA: 0x009F5DAC File Offset: 0x009F3FAC
		public unsafe int 位移修正速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17005DC9 RID: 24009
		// (get) Token: 0x0602798C RID: 162188 RVA: 0x009F5DBD File Offset: 0x009F3FBD
		// (set) Token: 0x0602798D RID: 162189 RVA: 0x009F5DCD File Offset: 0x009F3FCD
		public unsafe bool 是否启用超时传送
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005DCA RID: 24010
		// (get) Token: 0x0602798E RID: 162190 RVA: 0x009F5DDE File Offset: 0x009F3FDE
		// (set) Token: 0x0602798F RID: 162191 RVA: 0x009F5DEE File Offset: 0x009F3FEE
		public unsafe int 异常距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17005DCB RID: 24011
		// (get) Token: 0x06027990 RID: 162192 RVA: 0x009F5DFF File Offset: 0x009F3FFF
		// (set) Token: 0x06027991 RID: 162193 RVA: 0x009F5E0F File Offset: 0x009F400F
		public unsafe int 超时时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17005DCC RID: 24012
		// (get) Token: 0x06027992 RID: 162194 RVA: 0x009F5E20 File Offset: 0x009F4020
		// (set) Token: 0x06027993 RID: 162195 RVA: 0x009F5E59 File Offset: 0x009F4059
		public TArray<int> 传送特效buffID
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._传送特效buffID) == null)
				{
					result = (this._传送特效buffID = new TArray<int>(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_21, this));
				}
				return result;
			}
			set
			{
				this.传送特效buffID.CopyAssign(value);
			}
		}

		// Token: 0x17005DCD RID: 24013
		// (get) Token: 0x06027994 RID: 162196 RVA: 0x009F5E67 File Offset: 0x009F4067
		// (set) Token: 0x06027995 RID: 162197 RVA: 0x009F5E77 File Offset: 0x009F4077
		public unsafe int 被阻挡触发传送时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17005DCE RID: 24014
		// (get) Token: 0x06027996 RID: 162198 RVA: 0x009F5E88 File Offset: 0x009F4088
		// (set) Token: 0x06027997 RID: 162199 RVA: 0x009F5E98 File Offset: 0x009F4098
		public unsafe int StandardWalkSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17005DCF RID: 24015
		// (get) Token: 0x06027998 RID: 162200 RVA: 0x009F5EA9 File Offset: 0x009F40A9
		// (set) Token: 0x06027999 RID: 162201 RVA: 0x009F5EB9 File Offset: 0x009F40B9
		public unsafe int StandardRunSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17005DD0 RID: 24016
		// (get) Token: 0x0602799A RID: 162202 RVA: 0x009F5ECA File Offset: 0x009F40CA
		// (set) Token: 0x0602799B RID: 162203 RVA: 0x009F5EDA File Offset: 0x009F40DA
		public unsafe int StandardSprintSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17005DD1 RID: 24017
		// (get) Token: 0x0602799C RID: 162204 RVA: 0x009F5EEB File Offset: 0x009F40EB
		// (set) Token: 0x0602799D RID: 162205 RVA: 0x009F5EFB File Offset: 0x009F40FB
		public unsafe bool 只使用标准速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_26) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_26) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005DD2 RID: 24018
		// (get) Token: 0x0602799E RID: 162206 RVA: 0x009F5F0C File Offset: 0x009F410C
		// (set) Token: 0x0602799F RID: 162207 RVA: 0x009F5F1C File Offset: 0x009F411C
		public unsafe int 保持站立角色距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17005DD3 RID: 24019
		// (get) Token: 0x060279A0 RID: 162208 RVA: 0x009F5F2D File Offset: 0x009F412D
		// (set) Token: 0x060279A1 RID: 162209 RVA: 0x009F5F3D File Offset: 0x009F413D
		public unsafe int 加速延迟时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17005DD4 RID: 24020
		// (get) Token: 0x060279A2 RID: 162210 RVA: 0x009F5F4E File Offset: 0x009F414E
		// (set) Token: 0x060279A3 RID: 162211 RVA: 0x009F5F5E File Offset: 0x009F415E
		public unsafe int 移动延迟时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17005DD5 RID: 24021
		// (get) Token: 0x060279A4 RID: 162212 RVA: 0x009F5F6F File Offset: 0x009F416F
		// (set) Token: 0x060279A5 RID: 162213 RVA: 0x009F5F7F File Offset: 0x009F417F
		public unsafe bool 自动转向目标
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_30) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_30) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005DD6 RID: 24022
		// (get) Token: 0x060279A6 RID: 162214 RVA: 0x009F5F90 File Offset: 0x009F4190
		// (set) Token: 0x060279A7 RID: 162215 RVA: 0x009F5FA0 File Offset: 0x009F41A0
		public unsafe bool 非近距离同步跟随
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_31) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_31) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005DD7 RID: 24023
		// (get) Token: 0x060279A8 RID: 162216 RVA: 0x009F5FB4 File Offset: 0x009F41B4
		// (set) Token: 0x060279A9 RID: 162217 RVA: 0x009F5FED File Offset: 0x009F41ED
		public TArray<FVector2D> 跑步跟随方位备选
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector2D> result;
				if ((result = this._跑步跟随方位备选) == null)
				{
					result = (this._跑步跟随方位备选 = new TArray<FVector2D>(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_32, this));
				}
				return result;
			}
			set
			{
				this.跑步跟随方位备选.CopyAssign(value);
			}
		}

		// Token: 0x17005DD8 RID: 24024
		// (get) Token: 0x060279AA RID: 162218 RVA: 0x009F5FFC File Offset: 0x009F41FC
		// (set) Token: 0x060279AB RID: 162219 RVA: 0x009F6035 File Offset: 0x009F4235
		public TArray<FVector2D> 步行跟随方位备选
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector2D> result;
				if ((result = this._步行跟随方位备选) == null)
				{
					result = (this._步行跟随方位备选 = new TArray<FVector2D>(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_33, this));
				}
				return result;
			}
			set
			{
				this.步行跟随方位备选.CopyAssign(value);
			}
		}

		// Token: 0x17005DD9 RID: 24025
		// (get) Token: 0x060279AC RID: 162220 RVA: 0x009F6044 File Offset: 0x009F4244
		// (set) Token: 0x060279AD RID: 162221 RVA: 0x009F607D File Offset: 0x009F427D
		public SFreeFollowingConfig 自动跟随信息
		{
			get
			{
				base.FastCheckIsValid();
				SFreeFollowingConfig result;
				if ((result = this._自动跟随信息) == null)
				{
					result = (this._自动跟随信息 = new SFreeFollowingConfig(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_34, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SFreeFollowingConfig.StaticStruct(), base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_34, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005DDA RID: 24026
		// (get) Token: 0x060279AE RID: 162222 RVA: 0x009F609E File Offset: 0x009F429E
		// (set) Token: 0x060279AF RID: 162223 RVA: 0x009F60B2 File Offset: 0x009F42B2
		public unsafe SFollowSitConfig 跟随坐下信息
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KeepFollowingConfig_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x060279B0 RID: 162224 RVA: 0x009F60C7 File Offset: 0x009F42C7
		protected BP_KeepFollowingConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014C05 RID: 84997
		public new const string __ObjectPath = "/Game/Aki/Data/Level/KeepFollowing/BP_KeepFollowingConfig.BP_KeepFollowingConfig_C";

		// Token: 0x04014C06 RID: 84998
		private static IntPtr _ClassPtr;

		// Token: 0x04014C07 RID: 84999
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014C08 RID: 85000
		internal static int __PropertyOffset_0;

		// Token: 0x04014C09 RID: 85001
		internal static int __PropertyOffset_1;

		// Token: 0x04014C0A RID: 85002
		internal static int __PropertyOffset_2;

		// Token: 0x04014C0B RID: 85003
		internal static int __PropertyOffset_3;

		// Token: 0x04014C0C RID: 85004
		internal static int __PropertyOffset_4;

		// Token: 0x04014C0D RID: 85005
		internal static int __PropertyOffset_5;

		// Token: 0x04014C0E RID: 85006
		internal static int __PropertyOffset_6;

		// Token: 0x04014C0F RID: 85007
		internal static int __PropertyOffset_7;

		// Token: 0x04014C10 RID: 85008
		internal static int __PropertyOffset_8;

		// Token: 0x04014C11 RID: 85009
		internal static int __PropertyOffset_9;

		// Token: 0x04014C12 RID: 85010
		internal static int __PropertyOffset_10;

		// Token: 0x04014C13 RID: 85011
		internal static int __PropertyOffset_11;

		// Token: 0x04014C14 RID: 85012
		internal static int __PropertyOffset_12;

		// Token: 0x04014C15 RID: 85013
		internal static int __PropertyOffset_13;

		// Token: 0x04014C16 RID: 85014
		internal static int __PropertyOffset_14;

		// Token: 0x04014C17 RID: 85015
		internal static int __PropertyOffset_15;

		// Token: 0x04014C18 RID: 85016
		internal static int __PropertyOffset_16;

		// Token: 0x04014C19 RID: 85017
		internal static int __PropertyOffset_17;

		// Token: 0x04014C1A RID: 85018
		internal static int __PropertyOffset_18;

		// Token: 0x04014C1B RID: 85019
		internal static int __PropertyOffset_19;

		// Token: 0x04014C1C RID: 85020
		internal static int __PropertyOffset_20;

		// Token: 0x04014C1D RID: 85021
		internal static int __PropertyOffset_21;

		// Token: 0x04014C1E RID: 85022
		[Nullable(2)]
		private TArray<int> _传送特效buffID;

		// Token: 0x04014C1F RID: 85023
		internal static int __PropertyOffset_22;

		// Token: 0x04014C20 RID: 85024
		internal static int __PropertyOffset_23;

		// Token: 0x04014C21 RID: 85025
		internal static int __PropertyOffset_24;

		// Token: 0x04014C22 RID: 85026
		internal static int __PropertyOffset_25;

		// Token: 0x04014C23 RID: 85027
		internal static int __PropertyOffset_26;

		// Token: 0x04014C24 RID: 85028
		internal static int __PropertyOffset_27;

		// Token: 0x04014C25 RID: 85029
		internal static int __PropertyOffset_28;

		// Token: 0x04014C26 RID: 85030
		internal static int __PropertyOffset_29;

		// Token: 0x04014C27 RID: 85031
		internal static int __PropertyOffset_30;

		// Token: 0x04014C28 RID: 85032
		internal static int __PropertyOffset_31;

		// Token: 0x04014C29 RID: 85033
		internal static int __PropertyOffset_32;

		// Token: 0x04014C2A RID: 85034
		[Nullable(2)]
		private TArray<FVector2D> _跑步跟随方位备选;

		// Token: 0x04014C2B RID: 85035
		internal static int __PropertyOffset_33;

		// Token: 0x04014C2C RID: 85036
		[Nullable(2)]
		private TArray<FVector2D> _步行跟随方位备选;

		// Token: 0x04014C2D RID: 85037
		internal static int __PropertyOffset_34;

		// Token: 0x04014C2E RID: 85038
		[Nullable(2)]
		private SFreeFollowingConfig _自动跟随信息;

		// Token: 0x04014C2F RID: 85039
		internal static int __PropertyOffset_35;
	}
}
