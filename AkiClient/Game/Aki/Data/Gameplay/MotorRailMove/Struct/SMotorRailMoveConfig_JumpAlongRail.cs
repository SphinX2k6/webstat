using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Gameplay.MotorRailMove.Struct
{
	// Token: 0x02003EA8 RID: 16040
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMoveConfig_JumpAlongRail.SMotorRailMoveConfig_JumpAlongRail")]
	[UnrealStructLayout(192, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 188)]
	public class SMotorRailMoveConfig_JumpAlongRail : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027D38 RID: 163128 RVA: 0x009FB8C8 File Offset: 0x009F9AC8
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMotorRailMoveConfig_JumpAlongRail._ScriptStructPtr != 0) ? SMotorRailMoveConfig_JumpAlongRail._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMoveConfig_JumpAlongRail.SMotorRailMoveConfig_JumpAlongRail", ref SMotorRailMoveConfig_JumpAlongRail._ScriptStructPtr);
		}

		// Token: 0x17005F28 RID: 24360
		// (get) Token: 0x06027D39 RID: 163129 RVA: 0x009FB8EC File Offset: 0x009F9AEC
		// (set) Token: 0x06027D3A RID: 163130 RVA: 0x009FB92F File Offset: 0x009F9B2F
		public SMotorRailMove_CommonConfig CommonConfig
		{
			get
			{
				base.FastCheckIsValid();
				SMotorRailMove_CommonConfig result;
				if ((result = this._CommonConfig) == null)
				{
					result = (this._CommonConfig = new SMotorRailMove_CommonConfig(base.NativePtr + (IntPtr)SMotorRailMoveConfig_JumpAlongRail.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMotorRailMove_CommonConfig.StaticStruct(), base.NativePtr + (IntPtr)SMotorRailMoveConfig_JumpAlongRail.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005F29 RID: 24361
		// (get) Token: 0x06027D3B RID: 163131 RVA: 0x009FB950 File Offset: 0x009F9B50
		// (set) Token: 0x06027D3C RID: 163132 RVA: 0x009FB960 File Offset: 0x009F9B60
		public unsafe int SkillId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMoveConfig_JumpAlongRail.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMoveConfig_JumpAlongRail.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005F2A RID: 24362
		// (get) Token: 0x06027D3D RID: 163133 RVA: 0x009FB971 File Offset: 0x009F9B71
		// (set) Token: 0x06027D3E RID: 163134 RVA: 0x009FB985 File Offset: 0x009F9B85
		public unsafe SMotorRailMove_ParabolaMove ParabolaMove
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMoveConfig_JumpAlongRail.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMoveConfig_JumpAlongRail.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x06027D3F RID: 163135 RVA: 0x009FB99A File Offset: 0x009F9B9A
		public SMotorRailMoveConfig_JumpAlongRail()
		{
		}

		// Token: 0x06027D40 RID: 163136 RVA: 0x009FB9A2 File Offset: 0x009F9BA2
		public SMotorRailMoveConfig_JumpAlongRail(SMotorRailMove_CommonConfig CommonConfig, int SkillId, SMotorRailMove_ParabolaMove ParabolaMove)
		{
			this.CommonConfig = CommonConfig;
			this.SkillId = SkillId;
			this.ParabolaMove = ParabolaMove;
		}

		// Token: 0x06027D41 RID: 163137 RVA: 0x009FB9BF File Offset: 0x009F9BBF
		protected override IntPtr GetUStructPtr()
		{
			return SMotorRailMoveConfig_JumpAlongRail.StaticStruct();
		}

		// Token: 0x06027D42 RID: 163138 RVA: 0x009FB9CB File Offset: 0x009F9BCB
		[NullableContext(2)]
		public SMotorRailMoveConfig_JumpAlongRail(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027D43 RID: 163139 RVA: 0x009FB9D5 File Offset: 0x009F9BD5
		public SMotorRailMoveConfig_JumpAlongRail(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027D44 RID: 163140 RVA: 0x009FB9E0 File Offset: 0x009F9BE0
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMotorRailMoveConfig_JumpAlongRail(Pointer, false, true);
		}

		// Token: 0x06027D45 RID: 163141 RVA: 0x009FB9EA File Offset: 0x009F9BEA
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMotorRailMoveConfig_JumpAlongRail(Pointer, MemoryOwner);
		}

		// Token: 0x04014E60 RID: 85600
		public const string __ObjectPath = "/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMoveConfig_JumpAlongRail.SMotorRailMoveConfig_JumpAlongRail";

		// Token: 0x04014E61 RID: 85601
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014E62 RID: 85602
		internal static int __PropertyOffset_0;

		// Token: 0x04014E63 RID: 85603
		[Nullable(2)]
		private SMotorRailMove_CommonConfig _CommonConfig;

		// Token: 0x04014E64 RID: 85604
		internal static int __PropertyOffset_1;

		// Token: 0x04014E65 RID: 85605
		internal static int __PropertyOffset_2;
	}
}
