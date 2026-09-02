using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x02004317 RID: 17175
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/SCamera_NewConfig.SCamera_NewConfig")]
	[UnrealStructLayout(1688, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 1684)]
	public class SCamera_NewConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D889 RID: 186505 RVA: 0x00AC2C31 File Offset: 0x00AC0E31
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCamera_NewConfig._ScriptStructPtr != 0) ? SCamera_NewConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Camera/SCamera_NewConfig.SCamera_NewConfig", ref SCamera_NewConfig._ScriptStructPtr);
		}

		// Token: 0x17007C9E RID: 31902
		// (get) Token: 0x0602D88A RID: 186506 RVA: 0x00AC2C58 File Offset: 0x00AC0E58
		// (set) Token: 0x0602D88B RID: 186507 RVA: 0x00AC2C9B File Offset: 0x00AC0E9B
		public SCamera_Setting 基础镜头
		{
			get
			{
				base.FastCheckIsValid();
				SCamera_Setting result;
				if ((result = this._基础镜头) == null)
				{
					result = (this._基础镜头 = new SCamera_Setting(base.NativePtr + (IntPtr)SCamera_NewConfig.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCamera_Setting.StaticStruct(), base.NativePtr + (IntPtr)SCamera_NewConfig.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007C9F RID: 31903
		// (get) Token: 0x0602D88C RID: 186508 RVA: 0x00AC2CBC File Offset: 0x00AC0EBC
		// (set) Token: 0x0602D88D RID: 186509 RVA: 0x00AC2CFF File Offset: 0x00AC0EFF
		public SCamera_Setting 战斗镜头
		{
			get
			{
				base.FastCheckIsValid();
				SCamera_Setting result;
				if ((result = this._战斗镜头) == null)
				{
					result = (this._战斗镜头 = new SCamera_Setting(base.NativePtr + (IntPtr)SCamera_NewConfig.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCamera_Setting.StaticStruct(), base.NativePtr + (IntPtr)SCamera_NewConfig.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007CA0 RID: 31904
		// (get) Token: 0x0602D88E RID: 186510 RVA: 0x00AC2D20 File Offset: 0x00AC0F20
		// (set) Token: 0x0602D88F RID: 186511 RVA: 0x00AC2D63 File Offset: 0x00AC0F63
		public SCamera_Setting 移动镜头
		{
			get
			{
				base.FastCheckIsValid();
				SCamera_Setting result;
				if ((result = this._移动镜头) == null)
				{
					result = (this._移动镜头 = new SCamera_Setting(base.NativePtr + (IntPtr)SCamera_NewConfig.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCamera_Setting.StaticStruct(), base.NativePtr + (IntPtr)SCamera_NewConfig.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007CA1 RID: 31905
		// (get) Token: 0x0602D890 RID: 186512 RVA: 0x00AC2D84 File Offset: 0x00AC0F84
		// (set) Token: 0x0602D891 RID: 186513 RVA: 0x00AC2DC7 File Offset: 0x00AC0FC7
		public SCamera_Setting 冲刺镜头
		{
			get
			{
				base.FastCheckIsValid();
				SCamera_Setting result;
				if ((result = this._冲刺镜头) == null)
				{
					result = (this._冲刺镜头 = new SCamera_Setting(base.NativePtr + (IntPtr)SCamera_NewConfig.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCamera_Setting.StaticStruct(), base.NativePtr + (IntPtr)SCamera_NewConfig.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007CA2 RID: 31906
		// (get) Token: 0x0602D892 RID: 186514 RVA: 0x00AC2DE8 File Offset: 0x00AC0FE8
		// (set) Token: 0x0602D893 RID: 186515 RVA: 0x00AC2E2B File Offset: 0x00AC102B
		public SCamera_Setting 攀爬镜头
		{
			get
			{
				base.FastCheckIsValid();
				SCamera_Setting result;
				if ((result = this._攀爬镜头) == null)
				{
					result = (this._攀爬镜头 = new SCamera_Setting(base.NativePtr + (IntPtr)SCamera_NewConfig.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCamera_Setting.StaticStruct(), base.NativePtr + (IntPtr)SCamera_NewConfig.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007CA3 RID: 31907
		// (get) Token: 0x0602D894 RID: 186516 RVA: 0x00AC2E4C File Offset: 0x00AC104C
		// (set) Token: 0x0602D895 RID: 186517 RVA: 0x00AC2E8F File Offset: 0x00AC108F
		public SCamera_Setting 墙壁移动镜头
		{
			get
			{
				base.FastCheckIsValid();
				SCamera_Setting result;
				if ((result = this._墙壁移动镜头) == null)
				{
					result = (this._墙壁移动镜头 = new SCamera_Setting(base.NativePtr + (IntPtr)SCamera_NewConfig.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCamera_Setting.StaticStruct(), base.NativePtr + (IntPtr)SCamera_NewConfig.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007CA4 RID: 31908
		// (get) Token: 0x0602D896 RID: 186518 RVA: 0x00AC2EB0 File Offset: 0x00AC10B0
		// (set) Token: 0x0602D897 RID: 186519 RVA: 0x00AC2EF3 File Offset: 0x00AC10F3
		public SCamera_Setting 游泳镜头
		{
			get
			{
				base.FastCheckIsValid();
				SCamera_Setting result;
				if ((result = this._游泳镜头) == null)
				{
					result = (this._游泳镜头 = new SCamera_Setting(base.NativePtr + (IntPtr)SCamera_NewConfig.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCamera_Setting.StaticStruct(), base.NativePtr + (IntPtr)SCamera_NewConfig.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007CA5 RID: 31909
		// (get) Token: 0x0602D898 RID: 186520 RVA: 0x00AC2F14 File Offset: 0x00AC1114
		// (set) Token: 0x0602D899 RID: 186521 RVA: 0x00AC2F57 File Offset: 0x00AC1157
		public SCamera_Setting 空中镜头
		{
			get
			{
				base.FastCheckIsValid();
				SCamera_Setting result;
				if ((result = this._空中镜头) == null)
				{
					result = (this._空中镜头 = new SCamera_Setting(base.NativePtr + (IntPtr)SCamera_NewConfig.__PropertyOffset_7, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCamera_Setting.StaticStruct(), base.NativePtr + (IntPtr)SCamera_NewConfig.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007CA6 RID: 31910
		// (get) Token: 0x0602D89A RID: 186522 RVA: 0x00AC2F78 File Offset: 0x00AC1178
		// (set) Token: 0x0602D89B RID: 186523 RVA: 0x00AC2FBB File Offset: 0x00AC11BB
		public SCamera_Setting 瞄准镜头
		{
			get
			{
				base.FastCheckIsValid();
				SCamera_Setting result;
				if ((result = this._瞄准镜头) == null)
				{
					result = (this._瞄准镜头 = new SCamera_Setting(base.NativePtr + (IntPtr)SCamera_NewConfig.__PropertyOffset_8, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCamera_Setting.StaticStruct(), base.NativePtr + (IntPtr)SCamera_NewConfig.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007CA7 RID: 31911
		// (get) Token: 0x0602D89C RID: 186524 RVA: 0x00AC2FDC File Offset: 0x00AC11DC
		// (set) Token: 0x0602D89D RID: 186525 RVA: 0x00AC301F File Offset: 0x00AC121F
		public SCamera_Setting 移动射击镜头
		{
			get
			{
				base.FastCheckIsValid();
				SCamera_Setting result;
				if ((result = this._移动射击镜头) == null)
				{
					result = (this._移动射击镜头 = new SCamera_Setting(base.NativePtr + (IntPtr)SCamera_NewConfig.__PropertyOffset_9, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCamera_Setting.StaticStruct(), base.NativePtr + (IntPtr)SCamera_NewConfig.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007CA8 RID: 31912
		// (get) Token: 0x0602D89E RID: 186526 RVA: 0x00AC3040 File Offset: 0x00AC1240
		// (set) Token: 0x0602D89F RID: 186527 RVA: 0x00AC3050 File Offset: 0x00AC1250
		public unsafe float 基础镜头相机臂随臂长偏移最大值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_NewConfig.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_NewConfig.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x0602D8A0 RID: 186528 RVA: 0x00AC3061 File Offset: 0x00AC1261
		public SCamera_NewConfig()
		{
		}

		// Token: 0x0602D8A1 RID: 186529 RVA: 0x00AC306C File Offset: 0x00AC126C
		public SCamera_NewConfig(SCamera_Setting 基础镜头, SCamera_Setting 战斗镜头, SCamera_Setting 移动镜头, SCamera_Setting 冲刺镜头, SCamera_Setting 攀爬镜头, SCamera_Setting 墙壁移动镜头, SCamera_Setting 游泳镜头, SCamera_Setting 空中镜头, SCamera_Setting 瞄准镜头, SCamera_Setting 移动射击镜头, float 基础镜头相机臂随臂长偏移最大值)
		{
			this.基础镜头 = 基础镜头;
			this.战斗镜头 = 战斗镜头;
			this.移动镜头 = 移动镜头;
			this.冲刺镜头 = 冲刺镜头;
			this.攀爬镜头 = 攀爬镜头;
			this.墙壁移动镜头 = 墙壁移动镜头;
			this.游泳镜头 = 游泳镜头;
			this.空中镜头 = 空中镜头;
			this.瞄准镜头 = 瞄准镜头;
			this.移动射击镜头 = 移动射击镜头;
			this.基础镜头相机臂随臂长偏移最大值 = 基础镜头相机臂随臂长偏移最大值;
		}

		// Token: 0x0602D8A2 RID: 186530 RVA: 0x00AC30D4 File Offset: 0x00AC12D4
		protected override IntPtr GetUStructPtr()
		{
			return SCamera_NewConfig.StaticStruct();
		}

		// Token: 0x0602D8A3 RID: 186531 RVA: 0x00AC30E0 File Offset: 0x00AC12E0
		[NullableContext(2)]
		public SCamera_NewConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D8A4 RID: 186532 RVA: 0x00AC30EA File Offset: 0x00AC12EA
		public SCamera_NewConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D8A5 RID: 186533 RVA: 0x00AC30F5 File Offset: 0x00AC12F5
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCamera_NewConfig(Pointer, false, true);
		}

		// Token: 0x0602D8A6 RID: 186534 RVA: 0x00AC30FF File Offset: 0x00AC12FF
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCamera_NewConfig(Pointer, MemoryOwner);
		}

		// Token: 0x04019AC2 RID: 105154
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/SCamera_NewConfig.SCamera_NewConfig";

		// Token: 0x04019AC3 RID: 105155
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019AC4 RID: 105156
		internal static int __PropertyOffset_0;

		// Token: 0x04019AC5 RID: 105157
		[Nullable(2)]
		private SCamera_Setting _基础镜头;

		// Token: 0x04019AC6 RID: 105158
		internal static int __PropertyOffset_1;

		// Token: 0x04019AC7 RID: 105159
		[Nullable(2)]
		private SCamera_Setting _战斗镜头;

		// Token: 0x04019AC8 RID: 105160
		internal static int __PropertyOffset_2;

		// Token: 0x04019AC9 RID: 105161
		[Nullable(2)]
		private SCamera_Setting _移动镜头;

		// Token: 0x04019ACA RID: 105162
		internal static int __PropertyOffset_3;

		// Token: 0x04019ACB RID: 105163
		[Nullable(2)]
		private SCamera_Setting _冲刺镜头;

		// Token: 0x04019ACC RID: 105164
		internal static int __PropertyOffset_4;

		// Token: 0x04019ACD RID: 105165
		[Nullable(2)]
		private SCamera_Setting _攀爬镜头;

		// Token: 0x04019ACE RID: 105166
		internal static int __PropertyOffset_5;

		// Token: 0x04019ACF RID: 105167
		[Nullable(2)]
		private SCamera_Setting _墙壁移动镜头;

		// Token: 0x04019AD0 RID: 105168
		internal static int __PropertyOffset_6;

		// Token: 0x04019AD1 RID: 105169
		[Nullable(2)]
		private SCamera_Setting _游泳镜头;

		// Token: 0x04019AD2 RID: 105170
		internal static int __PropertyOffset_7;

		// Token: 0x04019AD3 RID: 105171
		[Nullable(2)]
		private SCamera_Setting _空中镜头;

		// Token: 0x04019AD4 RID: 105172
		internal static int __PropertyOffset_8;

		// Token: 0x04019AD5 RID: 105173
		[Nullable(2)]
		private SCamera_Setting _瞄准镜头;

		// Token: 0x04019AD6 RID: 105174
		internal static int __PropertyOffset_9;

		// Token: 0x04019AD7 RID: 105175
		[Nullable(2)]
		private SCamera_Setting _移动射击镜头;

		// Token: 0x04019AD8 RID: 105176
		internal static int __PropertyOffset_10;
	}
}
