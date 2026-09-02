using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Gameplay.MotorRailMove.Struct
{
	// Token: 0x02003EA6 RID: 16038
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMoveConfig_Basic.SMotorRailMoveConfig_Basic")]
	[UnrealStructLayout(816, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 816)]
	public class SMotorRailMoveConfig_Basic : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027D04 RID: 163076 RVA: 0x009FB2BF File Offset: 0x009F94BF
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMotorRailMoveConfig_Basic._ScriptStructPtr != 0) ? SMotorRailMoveConfig_Basic._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMoveConfig_Basic.SMotorRailMoveConfig_Basic", ref SMotorRailMoveConfig_Basic._ScriptStructPtr);
		}

		// Token: 0x17005F16 RID: 24342
		// (get) Token: 0x06027D05 RID: 163077 RVA: 0x009FB2E3 File Offset: 0x009F94E3
		// (set) Token: 0x06027D06 RID: 163078 RVA: 0x009FB2F3 File Offset: 0x009F94F3
		public unsafe float MaxDeltaTimeForMoveUpdate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMoveConfig_Basic.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMoveConfig_Basic.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005F17 RID: 24343
		// (get) Token: 0x06027D07 RID: 163079 RVA: 0x009FB304 File Offset: 0x009F9504
		// (set) Token: 0x06027D08 RID: 163080 RVA: 0x009FB314 File Offset: 0x009F9514
		public unsafe float DefaultMoveSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMoveConfig_Basic.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMoveConfig_Basic.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005F18 RID: 24344
		// (get) Token: 0x06027D09 RID: 163081 RVA: 0x009FB328 File Offset: 0x009F9528
		// (set) Token: 0x06027D0A RID: 163082 RVA: 0x009FB36B File Offset: 0x009F956B
		public TSet<int> AllowUseSkillIds
		{
			get
			{
				base.FastCheckIsValid();
				TSet<int> result;
				if ((result = this._AllowUseSkillIds) == null)
				{
					result = (this._AllowUseSkillIds = new TSet<int>(base.NativePtr + (IntPtr)SMotorRailMoveConfig_Basic.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.AllowUseSkillIds.CopyAssign(value);
			}
		}

		// Token: 0x17005F19 RID: 24345
		// (get) Token: 0x06027D0B RID: 163083 RVA: 0x009FB379 File Offset: 0x009F9579
		// (set) Token: 0x06027D0C RID: 163084 RVA: 0x009FB389 File Offset: 0x009F9589
		public unsafe float AutoEnterRailCdAfterLeaveRailMove
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMoveConfig_Basic.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMoveConfig_Basic.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005F1A RID: 24346
		// (get) Token: 0x06027D0D RID: 163085 RVA: 0x009FB39A File Offset: 0x009F959A
		// (set) Token: 0x06027D0E RID: 163086 RVA: 0x009FB3AA File Offset: 0x009F95AA
		public unsafe float AutoEnterRailCdAfterLeaveRail
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMoveConfig_Basic.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMoveConfig_Basic.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005F1B RID: 24347
		// (get) Token: 0x06027D0F RID: 163087 RVA: 0x009FB3BC File Offset: 0x009F95BC
		// (set) Token: 0x06027D10 RID: 163088 RVA: 0x009FB3FF File Offset: 0x009F95FF
		public TMap<FGameplayTag, SMotorRailMove_EventHandler> ClientEventHandlers
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, SMotorRailMove_EventHandler> result;
				if ((result = this._ClientEventHandlers) == null)
				{
					result = (this._ClientEventHandlers = new TMap<FGameplayTag, SMotorRailMove_EventHandler>(base.NativePtr + (IntPtr)SMotorRailMoveConfig_Basic.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ClientEventHandlers.CopyAssign(value);
			}
		}

		// Token: 0x17005F1C RID: 24348
		// (get) Token: 0x06027D11 RID: 163089 RVA: 0x009FB410 File Offset: 0x009F9610
		// (set) Token: 0x06027D12 RID: 163090 RVA: 0x009FB453 File Offset: 0x009F9653
		public TMap<FGameplayTag, bool> ModifyVehicleTagsOnEnterRail
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, bool> result;
				if ((result = this._ModifyVehicleTagsOnEnterRail) == null)
				{
					result = (this._ModifyVehicleTagsOnEnterRail = new TMap<FGameplayTag, bool>(base.NativePtr + (IntPtr)SMotorRailMoveConfig_Basic.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ModifyVehicleTagsOnEnterRail.CopyAssign(value);
			}
		}

		// Token: 0x17005F1D RID: 24349
		// (get) Token: 0x06027D13 RID: 163091 RVA: 0x009FB464 File Offset: 0x009F9664
		// (set) Token: 0x06027D14 RID: 163092 RVA: 0x009FB4A7 File Offset: 0x009F96A7
		public TMap<FGameplayTag, bool> ModifyVehicleTagsOnLeaveRail
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, bool> result;
				if ((result = this._ModifyVehicleTagsOnLeaveRail) == null)
				{
					result = (this._ModifyVehicleTagsOnLeaveRail = new TMap<FGameplayTag, bool>(base.NativePtr + (IntPtr)SMotorRailMoveConfig_Basic.__PropertyOffset_7, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ModifyVehicleTagsOnLeaveRail.CopyAssign(value);
			}
		}

		// Token: 0x17005F1E RID: 24350
		// (get) Token: 0x06027D15 RID: 163093 RVA: 0x009FB4B8 File Offset: 0x009F96B8
		// (set) Token: 0x06027D16 RID: 163094 RVA: 0x009FB4FB File Offset: 0x009F96FB
		public TMap<long, bool> ModifyVehicleBuffsOnEnterRail
		{
			get
			{
				base.FastCheckIsValid();
				TMap<long, bool> result;
				if ((result = this._ModifyVehicleBuffsOnEnterRail) == null)
				{
					result = (this._ModifyVehicleBuffsOnEnterRail = new TMap<long, bool>(base.NativePtr + (IntPtr)SMotorRailMoveConfig_Basic.__PropertyOffset_8, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ModifyVehicleBuffsOnEnterRail.CopyAssign(value);
			}
		}

		// Token: 0x17005F1F RID: 24351
		// (get) Token: 0x06027D17 RID: 163095 RVA: 0x009FB50C File Offset: 0x009F970C
		// (set) Token: 0x06027D18 RID: 163096 RVA: 0x009FB54F File Offset: 0x009F974F
		public TMap<long, bool> ModifyVehicleBuffsOnLeaveRail
		{
			get
			{
				base.FastCheckIsValid();
				TMap<long, bool> result;
				if ((result = this._ModifyVehicleBuffsOnLeaveRail) == null)
				{
					result = (this._ModifyVehicleBuffsOnLeaveRail = new TMap<long, bool>(base.NativePtr + (IntPtr)SMotorRailMoveConfig_Basic.__PropertyOffset_9, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ModifyVehicleBuffsOnLeaveRail.CopyAssign(value);
			}
		}

		// Token: 0x17005F20 RID: 24352
		// (get) Token: 0x06027D19 RID: 163097 RVA: 0x009FB560 File Offset: 0x009F9760
		// (set) Token: 0x06027D1A RID: 163098 RVA: 0x009FB5A3 File Offset: 0x009F97A3
		public TMap<FGameplayTag, bool> ModifyDriverPlayerTagsOnEnterRail
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, bool> result;
				if ((result = this._ModifyDriverPlayerTagsOnEnterRail) == null)
				{
					result = (this._ModifyDriverPlayerTagsOnEnterRail = new TMap<FGameplayTag, bool>(base.NativePtr + (IntPtr)SMotorRailMoveConfig_Basic.__PropertyOffset_10, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ModifyDriverPlayerTagsOnEnterRail.CopyAssign(value);
			}
		}

		// Token: 0x17005F21 RID: 24353
		// (get) Token: 0x06027D1B RID: 163099 RVA: 0x009FB5B4 File Offset: 0x009F97B4
		// (set) Token: 0x06027D1C RID: 163100 RVA: 0x009FB5F7 File Offset: 0x009F97F7
		public TMap<FGameplayTag, bool> ModifyDriverPlayerTagsOnLeaveRail
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, bool> result;
				if ((result = this._ModifyDriverPlayerTagsOnLeaveRail) == null)
				{
					result = (this._ModifyDriverPlayerTagsOnLeaveRail = new TMap<FGameplayTag, bool>(base.NativePtr + (IntPtr)SMotorRailMoveConfig_Basic.__PropertyOffset_11, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ModifyDriverPlayerTagsOnLeaveRail.CopyAssign(value);
			}
		}

		// Token: 0x17005F22 RID: 24354
		// (get) Token: 0x06027D1D RID: 163101 RVA: 0x009FB608 File Offset: 0x009F9808
		// (set) Token: 0x06027D1E RID: 163102 RVA: 0x009FB64B File Offset: 0x009F984B
		public TMap<long, bool> ModifyDriverBuffsOnEnterRail
		{
			get
			{
				base.FastCheckIsValid();
				TMap<long, bool> result;
				if ((result = this._ModifyDriverBuffsOnEnterRail) == null)
				{
					result = (this._ModifyDriverBuffsOnEnterRail = new TMap<long, bool>(base.NativePtr + (IntPtr)SMotorRailMoveConfig_Basic.__PropertyOffset_12, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ModifyDriverBuffsOnEnterRail.CopyAssign(value);
			}
		}

		// Token: 0x17005F23 RID: 24355
		// (get) Token: 0x06027D1F RID: 163103 RVA: 0x009FB65C File Offset: 0x009F985C
		// (set) Token: 0x06027D20 RID: 163104 RVA: 0x009FB69F File Offset: 0x009F989F
		public TMap<long, bool> ModifyDriverBuffsOnLeaveRail
		{
			get
			{
				base.FastCheckIsValid();
				TMap<long, bool> result;
				if ((result = this._ModifyDriverBuffsOnLeaveRail) == null)
				{
					result = (this._ModifyDriverBuffsOnLeaveRail = new TMap<long, bool>(base.NativePtr + (IntPtr)SMotorRailMoveConfig_Basic.__PropertyOffset_13, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ModifyDriverBuffsOnLeaveRail.CopyAssign(value);
			}
		}

		// Token: 0x06027D21 RID: 163105 RVA: 0x009FB6AD File Offset: 0x009F98AD
		public SMotorRailMoveConfig_Basic()
		{
		}

		// Token: 0x06027D22 RID: 163106 RVA: 0x009FB6B8 File Offset: 0x009F98B8
		public SMotorRailMoveConfig_Basic(float MaxDeltaTimeForMoveUpdate, float DefaultMoveSpeed, TSet<int> AllowUseSkillIds, float AutoEnterRailCdAfterLeaveRailMove, float AutoEnterRailCdAfterLeaveRail, TMap<FGameplayTag, SMotorRailMove_EventHandler> ClientEventHandlers, TMap<FGameplayTag, bool> ModifyVehicleTagsOnEnterRail, TMap<FGameplayTag, bool> ModifyVehicleTagsOnLeaveRail, TMap<long, bool> ModifyVehicleBuffsOnEnterRail, TMap<long, bool> ModifyVehicleBuffsOnLeaveRail, TMap<FGameplayTag, bool> ModifyDriverPlayerTagsOnEnterRail, TMap<FGameplayTag, bool> ModifyDriverPlayerTagsOnLeaveRail, TMap<long, bool> ModifyDriverBuffsOnEnterRail, TMap<long, bool> ModifyDriverBuffsOnLeaveRail)
		{
			this.MaxDeltaTimeForMoveUpdate = MaxDeltaTimeForMoveUpdate;
			this.DefaultMoveSpeed = DefaultMoveSpeed;
			this.AllowUseSkillIds = AllowUseSkillIds;
			this.AutoEnterRailCdAfterLeaveRailMove = AutoEnterRailCdAfterLeaveRailMove;
			this.AutoEnterRailCdAfterLeaveRail = AutoEnterRailCdAfterLeaveRail;
			this.ClientEventHandlers = ClientEventHandlers;
			this.ModifyVehicleTagsOnEnterRail = ModifyVehicleTagsOnEnterRail;
			this.ModifyVehicleTagsOnLeaveRail = ModifyVehicleTagsOnLeaveRail;
			this.ModifyVehicleBuffsOnEnterRail = ModifyVehicleBuffsOnEnterRail;
			this.ModifyVehicleBuffsOnLeaveRail = ModifyVehicleBuffsOnLeaveRail;
			this.ModifyDriverPlayerTagsOnEnterRail = ModifyDriverPlayerTagsOnEnterRail;
			this.ModifyDriverPlayerTagsOnLeaveRail = ModifyDriverPlayerTagsOnLeaveRail;
			this.ModifyDriverBuffsOnEnterRail = ModifyDriverBuffsOnEnterRail;
			this.ModifyDriverBuffsOnLeaveRail = ModifyDriverBuffsOnLeaveRail;
		}

		// Token: 0x06027D23 RID: 163107 RVA: 0x009FB738 File Offset: 0x009F9938
		protected override IntPtr GetUStructPtr()
		{
			return SMotorRailMoveConfig_Basic.StaticStruct();
		}

		// Token: 0x06027D24 RID: 163108 RVA: 0x009FB744 File Offset: 0x009F9944
		[NullableContext(2)]
		public SMotorRailMoveConfig_Basic(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027D25 RID: 163109 RVA: 0x009FB74E File Offset: 0x009F994E
		public SMotorRailMoveConfig_Basic(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027D26 RID: 163110 RVA: 0x009FB759 File Offset: 0x009F9959
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMotorRailMoveConfig_Basic(Pointer, false, true);
		}

		// Token: 0x06027D27 RID: 163111 RVA: 0x009FB763 File Offset: 0x009F9963
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMotorRailMoveConfig_Basic(Pointer, MemoryOwner);
		}

		// Token: 0x04014E3F RID: 85567
		public const string __ObjectPath = "/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMoveConfig_Basic.SMotorRailMoveConfig_Basic";

		// Token: 0x04014E40 RID: 85568
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014E41 RID: 85569
		internal static int __PropertyOffset_0;

		// Token: 0x04014E42 RID: 85570
		internal static int __PropertyOffset_1;

		// Token: 0x04014E43 RID: 85571
		internal static int __PropertyOffset_2;

		// Token: 0x04014E44 RID: 85572
		[Nullable(2)]
		private TSet<int> _AllowUseSkillIds;

		// Token: 0x04014E45 RID: 85573
		internal static int __PropertyOffset_3;

		// Token: 0x04014E46 RID: 85574
		internal static int __PropertyOffset_4;

		// Token: 0x04014E47 RID: 85575
		internal static int __PropertyOffset_5;

		// Token: 0x04014E48 RID: 85576
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FGameplayTag, SMotorRailMove_EventHandler> _ClientEventHandlers;

		// Token: 0x04014E49 RID: 85577
		internal static int __PropertyOffset_6;

		// Token: 0x04014E4A RID: 85578
		[Nullable(2)]
		private TMap<FGameplayTag, bool> _ModifyVehicleTagsOnEnterRail;

		// Token: 0x04014E4B RID: 85579
		internal static int __PropertyOffset_7;

		// Token: 0x04014E4C RID: 85580
		[Nullable(2)]
		private TMap<FGameplayTag, bool> _ModifyVehicleTagsOnLeaveRail;

		// Token: 0x04014E4D RID: 85581
		internal static int __PropertyOffset_8;

		// Token: 0x04014E4E RID: 85582
		[Nullable(2)]
		private TMap<long, bool> _ModifyVehicleBuffsOnEnterRail;

		// Token: 0x04014E4F RID: 85583
		internal static int __PropertyOffset_9;

		// Token: 0x04014E50 RID: 85584
		[Nullable(2)]
		private TMap<long, bool> _ModifyVehicleBuffsOnLeaveRail;

		// Token: 0x04014E51 RID: 85585
		internal static int __PropertyOffset_10;

		// Token: 0x04014E52 RID: 85586
		[Nullable(2)]
		private TMap<FGameplayTag, bool> _ModifyDriverPlayerTagsOnEnterRail;

		// Token: 0x04014E53 RID: 85587
		internal static int __PropertyOffset_11;

		// Token: 0x04014E54 RID: 85588
		[Nullable(2)]
		private TMap<FGameplayTag, bool> _ModifyDriverPlayerTagsOnLeaveRail;

		// Token: 0x04014E55 RID: 85589
		internal static int __PropertyOffset_12;

		// Token: 0x04014E56 RID: 85590
		[Nullable(2)]
		private TMap<long, bool> _ModifyDriverBuffsOnEnterRail;

		// Token: 0x04014E57 RID: 85591
		internal static int __PropertyOffset_13;

		// Token: 0x04014E58 RID: 85592
		[Nullable(2)]
		private TMap<long, bool> _ModifyDriverBuffsOnLeaveRail;
	}
}
