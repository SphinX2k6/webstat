using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Gameplay.MotorRailMove.Struct
{
	// Token: 0x02003EA7 RID: 16039
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMoveConfig_DirectlyEnterRail.SMotorRailMoveConfig_DirectlyEnterRail")]
	[UnrealStructLayout(200, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 200)]
	public class SMotorRailMoveConfig_DirectlyEnterRail : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027D28 RID: 163112 RVA: 0x009FB76C File Offset: 0x009F996C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMotorRailMoveConfig_DirectlyEnterRail._ScriptStructPtr != 0) ? SMotorRailMoveConfig_DirectlyEnterRail._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMoveConfig_DirectlyEnterRail.SMotorRailMoveConfig_DirectlyEnterRail", ref SMotorRailMoveConfig_DirectlyEnterRail._ScriptStructPtr);
		}

		// Token: 0x17005F24 RID: 24356
		// (get) Token: 0x06027D29 RID: 163113 RVA: 0x009FB790 File Offset: 0x009F9990
		// (set) Token: 0x06027D2A RID: 163114 RVA: 0x009FB7D3 File Offset: 0x009F99D3
		public SMotorRailMove_CommonConfig CommonConfig
		{
			get
			{
				base.FastCheckIsValid();
				SMotorRailMove_CommonConfig result;
				if ((result = this._CommonConfig) == null)
				{
					result = (this._CommonConfig = new SMotorRailMove_CommonConfig(base.NativePtr + (IntPtr)SMotorRailMoveConfig_DirectlyEnterRail.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMotorRailMove_CommonConfig.StaticStruct(), base.NativePtr + (IntPtr)SMotorRailMoveConfig_DirectlyEnterRail.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005F25 RID: 24357
		// (get) Token: 0x06027D2B RID: 163115 RVA: 0x009FB7F4 File Offset: 0x009F99F4
		// (set) Token: 0x06027D2C RID: 163116 RVA: 0x009FB804 File Offset: 0x009F9A04
		public unsafe float MaxAbsorbDist
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMoveConfig_DirectlyEnterRail.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMoveConfig_DirectlyEnterRail.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005F26 RID: 24358
		// (get) Token: 0x06027D2D RID: 163117 RVA: 0x009FB815 File Offset: 0x009F9A15
		// (set) Token: 0x06027D2E RID: 163118 RVA: 0x009FB829 File Offset: 0x009F9A29
		public unsafe SMotorRailMove_EnterRailCondition EnterCondition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMoveConfig_DirectlyEnterRail.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMoveConfig_DirectlyEnterRail.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005F27 RID: 24359
		// (get) Token: 0x06027D2F RID: 163119 RVA: 0x009FB83E File Offset: 0x009F9A3E
		// (set) Token: 0x06027D30 RID: 163120 RVA: 0x009FB852 File Offset: 0x009F9A52
		public unsafe SMotorRailMove_LinearMove LinearMove
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMoveConfig_DirectlyEnterRail.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMoveConfig_DirectlyEnterRail.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x06027D31 RID: 163121 RVA: 0x009FB867 File Offset: 0x009F9A67
		public SMotorRailMoveConfig_DirectlyEnterRail()
		{
		}

		// Token: 0x06027D32 RID: 163122 RVA: 0x009FB86F File Offset: 0x009F9A6F
		public SMotorRailMoveConfig_DirectlyEnterRail(SMotorRailMove_CommonConfig CommonConfig, float MaxAbsorbDist, SMotorRailMove_EnterRailCondition EnterCondition, SMotorRailMove_LinearMove LinearMove)
		{
			this.CommonConfig = CommonConfig;
			this.MaxAbsorbDist = MaxAbsorbDist;
			this.EnterCondition = EnterCondition;
			this.LinearMove = LinearMove;
		}

		// Token: 0x06027D33 RID: 163123 RVA: 0x009FB894 File Offset: 0x009F9A94
		protected override IntPtr GetUStructPtr()
		{
			return SMotorRailMoveConfig_DirectlyEnterRail.StaticStruct();
		}

		// Token: 0x06027D34 RID: 163124 RVA: 0x009FB8A0 File Offset: 0x009F9AA0
		[NullableContext(2)]
		public SMotorRailMoveConfig_DirectlyEnterRail(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027D35 RID: 163125 RVA: 0x009FB8AA File Offset: 0x009F9AAA
		public SMotorRailMoveConfig_DirectlyEnterRail(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027D36 RID: 163126 RVA: 0x009FB8B5 File Offset: 0x009F9AB5
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMotorRailMoveConfig_DirectlyEnterRail(Pointer, false, true);
		}

		// Token: 0x06027D37 RID: 163127 RVA: 0x009FB8BF File Offset: 0x009F9ABF
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMotorRailMoveConfig_DirectlyEnterRail(Pointer, MemoryOwner);
		}

		// Token: 0x04014E59 RID: 85593
		public const string __ObjectPath = "/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMoveConfig_DirectlyEnterRail.SMotorRailMoveConfig_DirectlyEnterRail";

		// Token: 0x04014E5A RID: 85594
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014E5B RID: 85595
		internal static int __PropertyOffset_0;

		// Token: 0x04014E5C RID: 85596
		[Nullable(2)]
		private SMotorRailMove_CommonConfig _CommonConfig;

		// Token: 0x04014E5D RID: 85597
		internal static int __PropertyOffset_1;

		// Token: 0x04014E5E RID: 85598
		internal static int __PropertyOffset_2;

		// Token: 0x04014E5F RID: 85599
		internal static int __PropertyOffset_3;
	}
}
