using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Gameplay.MotorRailMove.Struct
{
	// Token: 0x02003EA5 RID: 16037
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMoveConfig_AccelerateAlongRail.SMotorRailMoveConfig_AccelerateAlongRail")]
	[UnrealStructLayout(176, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 176)]
	public class SMotorRailMoveConfig_AccelerateAlongRail : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027CF8 RID: 163064 RVA: 0x009FB1BC File Offset: 0x009F93BC
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMotorRailMoveConfig_AccelerateAlongRail._ScriptStructPtr != 0) ? SMotorRailMoveConfig_AccelerateAlongRail._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMoveConfig_AccelerateAlongRail.SMotorRailMoveConfig_AccelerateAlongRail", ref SMotorRailMoveConfig_AccelerateAlongRail._ScriptStructPtr);
		}

		// Token: 0x17005F14 RID: 24340
		// (get) Token: 0x06027CF9 RID: 163065 RVA: 0x009FB1E0 File Offset: 0x009F93E0
		// (set) Token: 0x06027CFA RID: 163066 RVA: 0x009FB223 File Offset: 0x009F9423
		public SMotorRailMove_CommonConfig CommonConfig
		{
			get
			{
				base.FastCheckIsValid();
				SMotorRailMove_CommonConfig result;
				if ((result = this._CommonConfig) == null)
				{
					result = (this._CommonConfig = new SMotorRailMove_CommonConfig(base.NativePtr + (IntPtr)SMotorRailMoveConfig_AccelerateAlongRail.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMotorRailMove_CommonConfig.StaticStruct(), base.NativePtr + (IntPtr)SMotorRailMoveConfig_AccelerateAlongRail.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005F15 RID: 24341
		// (get) Token: 0x06027CFB RID: 163067 RVA: 0x009FB244 File Offset: 0x009F9444
		// (set) Token: 0x06027CFC RID: 163068 RVA: 0x009FB258 File Offset: 0x009F9458
		public unsafe SMotorRailMove_LinearMove LinearMove
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMoveConfig_AccelerateAlongRail.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMoveConfig_AccelerateAlongRail.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x06027CFD RID: 163069 RVA: 0x009FB26D File Offset: 0x009F946D
		public SMotorRailMoveConfig_AccelerateAlongRail()
		{
		}

		// Token: 0x06027CFE RID: 163070 RVA: 0x009FB275 File Offset: 0x009F9475
		public SMotorRailMoveConfig_AccelerateAlongRail(SMotorRailMove_CommonConfig CommonConfig, SMotorRailMove_LinearMove LinearMove)
		{
			this.CommonConfig = CommonConfig;
			this.LinearMove = LinearMove;
		}

		// Token: 0x06027CFF RID: 163071 RVA: 0x009FB28B File Offset: 0x009F948B
		protected override IntPtr GetUStructPtr()
		{
			return SMotorRailMoveConfig_AccelerateAlongRail.StaticStruct();
		}

		// Token: 0x06027D00 RID: 163072 RVA: 0x009FB297 File Offset: 0x009F9497
		[NullableContext(2)]
		public SMotorRailMoveConfig_AccelerateAlongRail(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027D01 RID: 163073 RVA: 0x009FB2A1 File Offset: 0x009F94A1
		public SMotorRailMoveConfig_AccelerateAlongRail(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027D02 RID: 163074 RVA: 0x009FB2AC File Offset: 0x009F94AC
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMotorRailMoveConfig_AccelerateAlongRail(Pointer, false, true);
		}

		// Token: 0x06027D03 RID: 163075 RVA: 0x009FB2B6 File Offset: 0x009F94B6
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMotorRailMoveConfig_AccelerateAlongRail(Pointer, MemoryOwner);
		}

		// Token: 0x04014E3A RID: 85562
		public const string __ObjectPath = "/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMoveConfig_AccelerateAlongRail.SMotorRailMoveConfig_AccelerateAlongRail";

		// Token: 0x04014E3B RID: 85563
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014E3C RID: 85564
		internal static int __PropertyOffset_0;

		// Token: 0x04014E3D RID: 85565
		[Nullable(2)]
		private SMotorRailMove_CommonConfig _CommonConfig;

		// Token: 0x04014E3E RID: 85566
		internal static int __PropertyOffset_1;
	}
}
