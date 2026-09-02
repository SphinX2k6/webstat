using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Gameplay.MotorRailMove.Struct
{
	// Token: 0x02003EAA RID: 16042
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMoveConfig_JumpToRail.SMotorRailMoveConfig_JumpToRail")]
	[UnrealStructLayout(208, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 208)]
	public class SMotorRailMoveConfig_JumpToRail : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027D56 RID: 163158 RVA: 0x009FBB48 File Offset: 0x009F9D48
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMotorRailMoveConfig_JumpToRail._ScriptStructPtr != 0) ? SMotorRailMoveConfig_JumpToRail._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMoveConfig_JumpToRail.SMotorRailMoveConfig_JumpToRail", ref SMotorRailMoveConfig_JumpToRail._ScriptStructPtr);
		}

		// Token: 0x17005F2F RID: 24367
		// (get) Token: 0x06027D57 RID: 163159 RVA: 0x009FBB6C File Offset: 0x009F9D6C
		// (set) Token: 0x06027D58 RID: 163160 RVA: 0x009FBBAF File Offset: 0x009F9DAF
		public SMotorRailMove_CommonConfig CommonConfig
		{
			get
			{
				base.FastCheckIsValid();
				SMotorRailMove_CommonConfig result;
				if ((result = this._CommonConfig) == null)
				{
					result = (this._CommonConfig = new SMotorRailMove_CommonConfig(base.NativePtr + (IntPtr)SMotorRailMoveConfig_JumpToRail.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMotorRailMove_CommonConfig.StaticStruct(), base.NativePtr + (IntPtr)SMotorRailMoveConfig_JumpToRail.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005F30 RID: 24368
		// (get) Token: 0x06027D59 RID: 163161 RVA: 0x009FBBD0 File Offset: 0x009F9DD0
		// (set) Token: 0x06027D5A RID: 163162 RVA: 0x009FBBE0 File Offset: 0x009F9DE0
		public unsafe int SkillId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMoveConfig_JumpToRail.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMoveConfig_JumpToRail.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005F31 RID: 24369
		// (get) Token: 0x06027D5B RID: 163163 RVA: 0x009FBBF1 File Offset: 0x009F9DF1
		// (set) Token: 0x06027D5C RID: 163164 RVA: 0x009FBC05 File Offset: 0x009F9E05
		public unsafe SMotorRailMove_EnterRailCondition EnterCondition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMoveConfig_JumpToRail.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMoveConfig_JumpToRail.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005F32 RID: 24370
		// (get) Token: 0x06027D5D RID: 163165 RVA: 0x009FBC1A File Offset: 0x009F9E1A
		// (set) Token: 0x06027D5E RID: 163166 RVA: 0x009FBC2E File Offset: 0x009F9E2E
		public unsafe SMotorRailMove_ParabolaMove ParabolaMove
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMoveConfig_JumpToRail.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMoveConfig_JumpToRail.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x06027D5F RID: 163167 RVA: 0x009FBC43 File Offset: 0x009F9E43
		public SMotorRailMoveConfig_JumpToRail()
		{
		}

		// Token: 0x06027D60 RID: 163168 RVA: 0x009FBC4B File Offset: 0x009F9E4B
		public SMotorRailMoveConfig_JumpToRail(SMotorRailMove_CommonConfig CommonConfig, int SkillId, SMotorRailMove_EnterRailCondition EnterCondition, SMotorRailMove_ParabolaMove ParabolaMove)
		{
			this.CommonConfig = CommonConfig;
			this.SkillId = SkillId;
			this.EnterCondition = EnterCondition;
			this.ParabolaMove = ParabolaMove;
		}

		// Token: 0x06027D61 RID: 163169 RVA: 0x009FBC70 File Offset: 0x009F9E70
		protected override IntPtr GetUStructPtr()
		{
			return SMotorRailMoveConfig_JumpToRail.StaticStruct();
		}

		// Token: 0x06027D62 RID: 163170 RVA: 0x009FBC7C File Offset: 0x009F9E7C
		[NullableContext(2)]
		public SMotorRailMoveConfig_JumpToRail(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027D63 RID: 163171 RVA: 0x009FBC86 File Offset: 0x009F9E86
		public SMotorRailMoveConfig_JumpToRail(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027D64 RID: 163172 RVA: 0x009FBC91 File Offset: 0x009F9E91
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMotorRailMoveConfig_JumpToRail(Pointer, false, true);
		}

		// Token: 0x06027D65 RID: 163173 RVA: 0x009FBC9B File Offset: 0x009F9E9B
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMotorRailMoveConfig_JumpToRail(Pointer, MemoryOwner);
		}

		// Token: 0x04014E6D RID: 85613
		public const string __ObjectPath = "/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMoveConfig_JumpToRail.SMotorRailMoveConfig_JumpToRail";

		// Token: 0x04014E6E RID: 85614
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014E6F RID: 85615
		internal static int __PropertyOffset_0;

		// Token: 0x04014E70 RID: 85616
		[Nullable(2)]
		private SMotorRailMove_CommonConfig _CommonConfig;

		// Token: 0x04014E71 RID: 85617
		internal static int __PropertyOffset_1;

		// Token: 0x04014E72 RID: 85618
		internal static int __PropertyOffset_2;

		// Token: 0x04014E73 RID: 85619
		internal static int __PropertyOffset_3;
	}
}
