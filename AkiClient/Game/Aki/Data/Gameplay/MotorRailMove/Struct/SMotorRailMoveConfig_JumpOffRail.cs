using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Gameplay.MotorRailMove.Struct
{
	// Token: 0x02003EA9 RID: 16041
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMoveConfig_JumpOffRail.SMotorRailMoveConfig_JumpOffRail")]
	[UnrealStructLayout(192, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 192)]
	public class SMotorRailMoveConfig_JumpOffRail : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027D46 RID: 163142 RVA: 0x009FB9F3 File Offset: 0x009F9BF3
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMotorRailMoveConfig_JumpOffRail._ScriptStructPtr != 0) ? SMotorRailMoveConfig_JumpOffRail._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMoveConfig_JumpOffRail.SMotorRailMoveConfig_JumpOffRail", ref SMotorRailMoveConfig_JumpOffRail._ScriptStructPtr);
		}

		// Token: 0x17005F2B RID: 24363
		// (get) Token: 0x06027D47 RID: 163143 RVA: 0x009FBA18 File Offset: 0x009F9C18
		// (set) Token: 0x06027D48 RID: 163144 RVA: 0x009FBA5B File Offset: 0x009F9C5B
		public SMotorRailMove_CommonConfig CommonConfig
		{
			get
			{
				base.FastCheckIsValid();
				SMotorRailMove_CommonConfig result;
				if ((result = this._CommonConfig) == null)
				{
					result = (this._CommonConfig = new SMotorRailMove_CommonConfig(base.NativePtr + (IntPtr)SMotorRailMoveConfig_JumpOffRail.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMotorRailMove_CommonConfig.StaticStruct(), base.NativePtr + (IntPtr)SMotorRailMoveConfig_JumpOffRail.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005F2C RID: 24364
		// (get) Token: 0x06027D49 RID: 163145 RVA: 0x009FBA7C File Offset: 0x009F9C7C
		// (set) Token: 0x06027D4A RID: 163146 RVA: 0x009FBA8C File Offset: 0x009F9C8C
		public unsafe int SkillId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMoveConfig_JumpOffRail.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMoveConfig_JumpOffRail.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005F2D RID: 24365
		// (get) Token: 0x06027D4B RID: 163147 RVA: 0x009FBA9D File Offset: 0x009F9C9D
		// (set) Token: 0x06027D4C RID: 163148 RVA: 0x009FBAAD File Offset: 0x009F9CAD
		public unsafe float SideOffsetAbs
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMoveConfig_JumpOffRail.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMoveConfig_JumpOffRail.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005F2E RID: 24366
		// (get) Token: 0x06027D4D RID: 163149 RVA: 0x009FBABE File Offset: 0x009F9CBE
		// (set) Token: 0x06027D4E RID: 163150 RVA: 0x009FBAD2 File Offset: 0x009F9CD2
		public unsafe SMotorRailMove_ParabolaMove ParabolaMove
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMoveConfig_JumpOffRail.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMoveConfig_JumpOffRail.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x06027D4F RID: 163151 RVA: 0x009FBAE7 File Offset: 0x009F9CE7
		public SMotorRailMoveConfig_JumpOffRail()
		{
		}

		// Token: 0x06027D50 RID: 163152 RVA: 0x009FBAEF File Offset: 0x009F9CEF
		public SMotorRailMoveConfig_JumpOffRail(SMotorRailMove_CommonConfig CommonConfig, int SkillId, float SideOffsetAbs, SMotorRailMove_ParabolaMove ParabolaMove)
		{
			this.CommonConfig = CommonConfig;
			this.SkillId = SkillId;
			this.SideOffsetAbs = SideOffsetAbs;
			this.ParabolaMove = ParabolaMove;
		}

		// Token: 0x06027D51 RID: 163153 RVA: 0x009FBB14 File Offset: 0x009F9D14
		protected override IntPtr GetUStructPtr()
		{
			return SMotorRailMoveConfig_JumpOffRail.StaticStruct();
		}

		// Token: 0x06027D52 RID: 163154 RVA: 0x009FBB20 File Offset: 0x009F9D20
		[NullableContext(2)]
		public SMotorRailMoveConfig_JumpOffRail(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027D53 RID: 163155 RVA: 0x009FBB2A File Offset: 0x009F9D2A
		public SMotorRailMoveConfig_JumpOffRail(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027D54 RID: 163156 RVA: 0x009FBB35 File Offset: 0x009F9D35
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMotorRailMoveConfig_JumpOffRail(Pointer, false, true);
		}

		// Token: 0x06027D55 RID: 163157 RVA: 0x009FBB3F File Offset: 0x009F9D3F
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMotorRailMoveConfig_JumpOffRail(Pointer, MemoryOwner);
		}

		// Token: 0x04014E66 RID: 85606
		public const string __ObjectPath = "/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMoveConfig_JumpOffRail.SMotorRailMoveConfig_JumpOffRail";

		// Token: 0x04014E67 RID: 85607
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014E68 RID: 85608
		internal static int __PropertyOffset_0;

		// Token: 0x04014E69 RID: 85609
		[Nullable(2)]
		private SMotorRailMove_CommonConfig _CommonConfig;

		// Token: 0x04014E6A RID: 85610
		internal static int __PropertyOffset_1;

		// Token: 0x04014E6B RID: 85611
		internal static int __PropertyOffset_2;

		// Token: 0x04014E6C RID: 85612
		internal static int __PropertyOffset_3;
	}
}
