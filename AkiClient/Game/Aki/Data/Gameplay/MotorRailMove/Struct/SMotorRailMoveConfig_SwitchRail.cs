using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Gameplay.MotorRailMove.Struct
{
	// Token: 0x02003EAB RID: 16043
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMoveConfig_SwitchRail.SMotorRailMoveConfig_SwitchRail")]
	[UnrealStructLayout(208, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 208)]
	public class SMotorRailMoveConfig_SwitchRail : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027D66 RID: 163174 RVA: 0x009FBCA4 File Offset: 0x009F9EA4
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMotorRailMoveConfig_SwitchRail._ScriptStructPtr != 0) ? SMotorRailMoveConfig_SwitchRail._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMoveConfig_SwitchRail.SMotorRailMoveConfig_SwitchRail", ref SMotorRailMoveConfig_SwitchRail._ScriptStructPtr);
		}

		// Token: 0x17005F33 RID: 24371
		// (get) Token: 0x06027D67 RID: 163175 RVA: 0x009FBCC8 File Offset: 0x009F9EC8
		// (set) Token: 0x06027D68 RID: 163176 RVA: 0x009FBD0B File Offset: 0x009F9F0B
		public SMotorRailMove_CommonConfig CommonConfig
		{
			get
			{
				base.FastCheckIsValid();
				SMotorRailMove_CommonConfig result;
				if ((result = this._CommonConfig) == null)
				{
					result = (this._CommonConfig = new SMotorRailMove_CommonConfig(base.NativePtr + (IntPtr)SMotorRailMoveConfig_SwitchRail.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMotorRailMove_CommonConfig.StaticStruct(), base.NativePtr + (IntPtr)SMotorRailMoveConfig_SwitchRail.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005F34 RID: 24372
		// (get) Token: 0x06027D69 RID: 163177 RVA: 0x009FBD2C File Offset: 0x009F9F2C
		// (set) Token: 0x06027D6A RID: 163178 RVA: 0x009FBD3C File Offset: 0x009F9F3C
		public unsafe int SkillId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMoveConfig_SwitchRail.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMoveConfig_SwitchRail.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005F35 RID: 24373
		// (get) Token: 0x06027D6B RID: 163179 RVA: 0x009FBD4D File Offset: 0x009F9F4D
		// (set) Token: 0x06027D6C RID: 163180 RVA: 0x009FBD61 File Offset: 0x009F9F61
		public unsafe SMotorRailMove_EnterRailCondition EnterCondition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMoveConfig_SwitchRail.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMoveConfig_SwitchRail.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005F36 RID: 24374
		// (get) Token: 0x06027D6D RID: 163181 RVA: 0x009FBD76 File Offset: 0x009F9F76
		// (set) Token: 0x06027D6E RID: 163182 RVA: 0x009FBD8A File Offset: 0x009F9F8A
		public unsafe SMotorRailMove_ParabolaMove ParabolaMove
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMoveConfig_SwitchRail.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMoveConfig_SwitchRail.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x06027D6F RID: 163183 RVA: 0x009FBD9F File Offset: 0x009F9F9F
		public SMotorRailMoveConfig_SwitchRail()
		{
		}

		// Token: 0x06027D70 RID: 163184 RVA: 0x009FBDA7 File Offset: 0x009F9FA7
		public SMotorRailMoveConfig_SwitchRail(SMotorRailMove_CommonConfig CommonConfig, int SkillId, SMotorRailMove_EnterRailCondition EnterCondition, SMotorRailMove_ParabolaMove ParabolaMove)
		{
			this.CommonConfig = CommonConfig;
			this.SkillId = SkillId;
			this.EnterCondition = EnterCondition;
			this.ParabolaMove = ParabolaMove;
		}

		// Token: 0x06027D71 RID: 163185 RVA: 0x009FBDCC File Offset: 0x009F9FCC
		protected override IntPtr GetUStructPtr()
		{
			return SMotorRailMoveConfig_SwitchRail.StaticStruct();
		}

		// Token: 0x06027D72 RID: 163186 RVA: 0x009FBDD8 File Offset: 0x009F9FD8
		[NullableContext(2)]
		public SMotorRailMoveConfig_SwitchRail(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027D73 RID: 163187 RVA: 0x009FBDE2 File Offset: 0x009F9FE2
		public SMotorRailMoveConfig_SwitchRail(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027D74 RID: 163188 RVA: 0x009FBDED File Offset: 0x009F9FED
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMotorRailMoveConfig_SwitchRail(Pointer, false, true);
		}

		// Token: 0x06027D75 RID: 163189 RVA: 0x009FBDF7 File Offset: 0x009F9FF7
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMotorRailMoveConfig_SwitchRail(Pointer, MemoryOwner);
		}

		// Token: 0x04014E74 RID: 85620
		public const string __ObjectPath = "/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMoveConfig_SwitchRail.SMotorRailMoveConfig_SwitchRail";

		// Token: 0x04014E75 RID: 85621
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014E76 RID: 85622
		internal static int __PropertyOffset_0;

		// Token: 0x04014E77 RID: 85623
		[Nullable(2)]
		private SMotorRailMove_CommonConfig _CommonConfig;

		// Token: 0x04014E78 RID: 85624
		internal static int __PropertyOffset_1;

		// Token: 0x04014E79 RID: 85625
		internal static int __PropertyOffset_2;

		// Token: 0x04014E7A RID: 85626
		internal static int __PropertyOffset_3;
	}
}
