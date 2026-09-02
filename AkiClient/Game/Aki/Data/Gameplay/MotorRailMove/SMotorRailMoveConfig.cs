using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Gameplay.MotorRailMove.Struct;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Gameplay.MotorRailMove
{
	// Token: 0x02003EA4 RID: 16036
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/MotorRailMove/SMotorRailMoveConfig.SMotorRailMoveConfig")]
	[UnrealStructLayout(2064, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 2064)]
	public class SMotorRailMoveConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027CD2 RID: 163026 RVA: 0x009FACF5 File Offset: 0x009F8EF5
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMotorRailMoveConfig._ScriptStructPtr != 0) ? SMotorRailMoveConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Gameplay/MotorRailMove/SMotorRailMoveConfig.SMotorRailMoveConfig", ref SMotorRailMoveConfig._ScriptStructPtr);
		}

		// Token: 0x17005F05 RID: 24325
		// (get) Token: 0x06027CD3 RID: 163027 RVA: 0x009FAD19 File Offset: 0x009F8F19
		// (set) Token: 0x06027CD4 RID: 163028 RVA: 0x009FAD2D File Offset: 0x009F8F2D
		public unsafe string Remarks
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SMotorRailMoveConfig.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SMotorRailMoveConfig.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17005F06 RID: 24326
		// (get) Token: 0x06027CD5 RID: 163029 RVA: 0x009FAD42 File Offset: 0x009F8F42
		// (set) Token: 0x06027CD6 RID: 163030 RVA: 0x009FAD52 File Offset: 0x009F8F52
		public unsafe bool EnableBasicConfig
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005F07 RID: 24327
		// (get) Token: 0x06027CD7 RID: 163031 RVA: 0x009FAD64 File Offset: 0x009F8F64
		// (set) Token: 0x06027CD8 RID: 163032 RVA: 0x009FADA7 File Offset: 0x009F8FA7
		public SMotorRailMoveConfig_Basic BasicConfig
		{
			get
			{
				base.FastCheckIsValid();
				SMotorRailMoveConfig_Basic result;
				if ((result = this._BasicConfig) == null)
				{
					result = (this._BasicConfig = new SMotorRailMoveConfig_Basic(base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMotorRailMoveConfig_Basic.StaticStruct(), base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005F08 RID: 24328
		// (get) Token: 0x06027CD9 RID: 163033 RVA: 0x009FADC8 File Offset: 0x009F8FC8
		// (set) Token: 0x06027CDA RID: 163034 RVA: 0x009FADD8 File Offset: 0x009F8FD8
		public unsafe bool EnableDirectlyEnterRailConfig
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005F09 RID: 24329
		// (get) Token: 0x06027CDB RID: 163035 RVA: 0x009FADEC File Offset: 0x009F8FEC
		// (set) Token: 0x06027CDC RID: 163036 RVA: 0x009FAE2F File Offset: 0x009F902F
		public SMotorRailMoveConfig_DirectlyEnterRail DirectlyEnterRailConfig
		{
			get
			{
				base.FastCheckIsValid();
				SMotorRailMoveConfig_DirectlyEnterRail result;
				if ((result = this._DirectlyEnterRailConfig) == null)
				{
					result = (this._DirectlyEnterRailConfig = new SMotorRailMoveConfig_DirectlyEnterRail(base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMotorRailMoveConfig_DirectlyEnterRail.StaticStruct(), base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005F0A RID: 24330
		// (get) Token: 0x06027CDD RID: 163037 RVA: 0x009FAE50 File Offset: 0x009F9050
		// (set) Token: 0x06027CDE RID: 163038 RVA: 0x009FAE60 File Offset: 0x009F9060
		public unsafe bool EnableAccelerateAlongRailConfig
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005F0B RID: 24331
		// (get) Token: 0x06027CDF RID: 163039 RVA: 0x009FAE74 File Offset: 0x009F9074
		// (set) Token: 0x06027CE0 RID: 163040 RVA: 0x009FAEB7 File Offset: 0x009F90B7
		public SMotorRailMoveConfig_AccelerateAlongRail AccelerateAlongRailConfig
		{
			get
			{
				base.FastCheckIsValid();
				SMotorRailMoveConfig_AccelerateAlongRail result;
				if ((result = this._AccelerateAlongRailConfig) == null)
				{
					result = (this._AccelerateAlongRailConfig = new SMotorRailMoveConfig_AccelerateAlongRail(base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMotorRailMoveConfig_AccelerateAlongRail.StaticStruct(), base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005F0C RID: 24332
		// (get) Token: 0x06027CE1 RID: 163041 RVA: 0x009FAED8 File Offset: 0x009F90D8
		// (set) Token: 0x06027CE2 RID: 163042 RVA: 0x009FAEE8 File Offset: 0x009F90E8
		public unsafe bool EnableJumpToRailConfig
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005F0D RID: 24333
		// (get) Token: 0x06027CE3 RID: 163043 RVA: 0x009FAEFC File Offset: 0x009F90FC
		// (set) Token: 0x06027CE4 RID: 163044 RVA: 0x009FAF3F File Offset: 0x009F913F
		public SMotorRailMoveConfig_JumpToRail JumpToRailConfig
		{
			get
			{
				base.FastCheckIsValid();
				SMotorRailMoveConfig_JumpToRail result;
				if ((result = this._JumpToRailConfig) == null)
				{
					result = (this._JumpToRailConfig = new SMotorRailMoveConfig_JumpToRail(base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_8, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMotorRailMoveConfig_JumpToRail.StaticStruct(), base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005F0E RID: 24334
		// (get) Token: 0x06027CE5 RID: 163045 RVA: 0x009FAF60 File Offset: 0x009F9160
		// (set) Token: 0x06027CE6 RID: 163046 RVA: 0x009FAF70 File Offset: 0x009F9170
		public unsafe bool EnableSwitchRailConfig
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005F0F RID: 24335
		// (get) Token: 0x06027CE7 RID: 163047 RVA: 0x009FAF84 File Offset: 0x009F9184
		// (set) Token: 0x06027CE8 RID: 163048 RVA: 0x009FAFC7 File Offset: 0x009F91C7
		public SMotorRailMoveConfig_SwitchRail SwitchRailConfig
		{
			get
			{
				base.FastCheckIsValid();
				SMotorRailMoveConfig_SwitchRail result;
				if ((result = this._SwitchRailConfig) == null)
				{
					result = (this._SwitchRailConfig = new SMotorRailMoveConfig_SwitchRail(base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_10, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMotorRailMoveConfig_SwitchRail.StaticStruct(), base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005F10 RID: 24336
		// (get) Token: 0x06027CE9 RID: 163049 RVA: 0x009FAFE8 File Offset: 0x009F91E8
		// (set) Token: 0x06027CEA RID: 163050 RVA: 0x009FAFF8 File Offset: 0x009F91F8
		public unsafe bool EnableJumpOffRailConfig
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005F11 RID: 24337
		// (get) Token: 0x06027CEB RID: 163051 RVA: 0x009FB00C File Offset: 0x009F920C
		// (set) Token: 0x06027CEC RID: 163052 RVA: 0x009FB04F File Offset: 0x009F924F
		public SMotorRailMoveConfig_JumpOffRail JumpOffRailConfig
		{
			get
			{
				base.FastCheckIsValid();
				SMotorRailMoveConfig_JumpOffRail result;
				if ((result = this._JumpOffRailConfig) == null)
				{
					result = (this._JumpOffRailConfig = new SMotorRailMoveConfig_JumpOffRail(base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_12, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMotorRailMoveConfig_JumpOffRail.StaticStruct(), base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005F12 RID: 24338
		// (get) Token: 0x06027CED RID: 163053 RVA: 0x009FB070 File Offset: 0x009F9270
		// (set) Token: 0x06027CEE RID: 163054 RVA: 0x009FB080 File Offset: 0x009F9280
		public unsafe bool EnableJumpAlongRailConfig
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005F13 RID: 24339
		// (get) Token: 0x06027CEF RID: 163055 RVA: 0x009FB094 File Offset: 0x009F9294
		// (set) Token: 0x06027CF0 RID: 163056 RVA: 0x009FB0D7 File Offset: 0x009F92D7
		public SMotorRailMoveConfig_JumpAlongRail JumpAlongRailConfig
		{
			get
			{
				base.FastCheckIsValid();
				SMotorRailMoveConfig_JumpAlongRail result;
				if ((result = this._JumpAlongRailConfig) == null)
				{
					result = (this._JumpAlongRailConfig = new SMotorRailMoveConfig_JumpAlongRail(base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_14, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMotorRailMoveConfig_JumpAlongRail.StaticStruct(), base.NativePtr + (IntPtr)SMotorRailMoveConfig.__PropertyOffset_14, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06027CF1 RID: 163057 RVA: 0x009FB0F8 File Offset: 0x009F92F8
		public SMotorRailMoveConfig()
		{
		}

		// Token: 0x06027CF2 RID: 163058 RVA: 0x009FB100 File Offset: 0x009F9300
		public SMotorRailMoveConfig(string Remarks, bool EnableBasicConfig, SMotorRailMoveConfig_Basic BasicConfig, bool EnableDirectlyEnterRailConfig, SMotorRailMoveConfig_DirectlyEnterRail DirectlyEnterRailConfig, bool EnableAccelerateAlongRailConfig, SMotorRailMoveConfig_AccelerateAlongRail AccelerateAlongRailConfig, bool EnableJumpToRailConfig, SMotorRailMoveConfig_JumpToRail JumpToRailConfig, bool EnableSwitchRailConfig, SMotorRailMoveConfig_SwitchRail SwitchRailConfig, bool EnableJumpOffRailConfig, SMotorRailMoveConfig_JumpOffRail JumpOffRailConfig, bool EnableJumpAlongRailConfig, SMotorRailMoveConfig_JumpAlongRail JumpAlongRailConfig)
		{
			this.Remarks = Remarks;
			this.EnableBasicConfig = EnableBasicConfig;
			this.BasicConfig = BasicConfig;
			this.EnableDirectlyEnterRailConfig = EnableDirectlyEnterRailConfig;
			this.DirectlyEnterRailConfig = DirectlyEnterRailConfig;
			this.EnableAccelerateAlongRailConfig = EnableAccelerateAlongRailConfig;
			this.AccelerateAlongRailConfig = AccelerateAlongRailConfig;
			this.EnableJumpToRailConfig = EnableJumpToRailConfig;
			this.JumpToRailConfig = JumpToRailConfig;
			this.EnableSwitchRailConfig = EnableSwitchRailConfig;
			this.SwitchRailConfig = SwitchRailConfig;
			this.EnableJumpOffRailConfig = EnableJumpOffRailConfig;
			this.JumpOffRailConfig = JumpOffRailConfig;
			this.EnableJumpAlongRailConfig = EnableJumpAlongRailConfig;
			this.JumpAlongRailConfig = JumpAlongRailConfig;
		}

		// Token: 0x06027CF3 RID: 163059 RVA: 0x009FB188 File Offset: 0x009F9388
		protected override IntPtr GetUStructPtr()
		{
			return SMotorRailMoveConfig.StaticStruct();
		}

		// Token: 0x06027CF4 RID: 163060 RVA: 0x009FB194 File Offset: 0x009F9394
		[NullableContext(2)]
		public SMotorRailMoveConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027CF5 RID: 163061 RVA: 0x009FB19E File Offset: 0x009F939E
		public SMotorRailMoveConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027CF6 RID: 163062 RVA: 0x009FB1A9 File Offset: 0x009F93A9
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMotorRailMoveConfig(Pointer, false, true);
		}

		// Token: 0x06027CF7 RID: 163063 RVA: 0x009FB1B3 File Offset: 0x009F93B3
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMotorRailMoveConfig(Pointer, MemoryOwner);
		}

		// Token: 0x04014E22 RID: 85538
		public const string __ObjectPath = "/Game/Aki/Data/Gameplay/MotorRailMove/SMotorRailMoveConfig.SMotorRailMoveConfig";

		// Token: 0x04014E23 RID: 85539
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014E24 RID: 85540
		internal static int __PropertyOffset_0;

		// Token: 0x04014E25 RID: 85541
		internal static int __PropertyOffset_1;

		// Token: 0x04014E26 RID: 85542
		internal static int __PropertyOffset_2;

		// Token: 0x04014E27 RID: 85543
		[Nullable(2)]
		private SMotorRailMoveConfig_Basic _BasicConfig;

		// Token: 0x04014E28 RID: 85544
		internal static int __PropertyOffset_3;

		// Token: 0x04014E29 RID: 85545
		internal static int __PropertyOffset_4;

		// Token: 0x04014E2A RID: 85546
		[Nullable(2)]
		private SMotorRailMoveConfig_DirectlyEnterRail _DirectlyEnterRailConfig;

		// Token: 0x04014E2B RID: 85547
		internal static int __PropertyOffset_5;

		// Token: 0x04014E2C RID: 85548
		internal static int __PropertyOffset_6;

		// Token: 0x04014E2D RID: 85549
		[Nullable(2)]
		private SMotorRailMoveConfig_AccelerateAlongRail _AccelerateAlongRailConfig;

		// Token: 0x04014E2E RID: 85550
		internal static int __PropertyOffset_7;

		// Token: 0x04014E2F RID: 85551
		internal static int __PropertyOffset_8;

		// Token: 0x04014E30 RID: 85552
		[Nullable(2)]
		private SMotorRailMoveConfig_JumpToRail _JumpToRailConfig;

		// Token: 0x04014E31 RID: 85553
		internal static int __PropertyOffset_9;

		// Token: 0x04014E32 RID: 85554
		internal static int __PropertyOffset_10;

		// Token: 0x04014E33 RID: 85555
		[Nullable(2)]
		private SMotorRailMoveConfig_SwitchRail _SwitchRailConfig;

		// Token: 0x04014E34 RID: 85556
		internal static int __PropertyOffset_11;

		// Token: 0x04014E35 RID: 85557
		internal static int __PropertyOffset_12;

		// Token: 0x04014E36 RID: 85558
		[Nullable(2)]
		private SMotorRailMoveConfig_JumpOffRail _JumpOffRailConfig;

		// Token: 0x04014E37 RID: 85559
		internal static int __PropertyOffset_13;

		// Token: 0x04014E38 RID: 85560
		internal static int __PropertyOffset_14;

		// Token: 0x04014E39 RID: 85561
		[Nullable(2)]
		private SMotorRailMoveConfig_JumpAlongRail _JumpAlongRailConfig;
	}
}
