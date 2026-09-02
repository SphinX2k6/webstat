using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Quest.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Quest.Structures
{
	// Token: 0x02003E30 RID: 15920
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Quest/Structures/SQuestStep.SQuestStep")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 157)]
	public class SQuestStep : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060273E6 RID: 160742 RVA: 0x009ED20A File Offset: 0x009EB40A
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SQuestStep._ScriptStructPtr != 0) ? SQuestStep._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Quest/Structures/SQuestStep.SQuestStep", ref SQuestStep._ScriptStructPtr);
		}

		// Token: 0x17005BC3 RID: 23491
		// (get) Token: 0x060273E7 RID: 160743 RVA: 0x009ED22E File Offset: 0x009EB42E
		// (set) Token: 0x060273E8 RID: 160744 RVA: 0x009ED23E File Offset: 0x009EB43E
		public unsafe int 步骤ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005BC4 RID: 23492
		// (get) Token: 0x060273E9 RID: 160745 RVA: 0x009ED250 File Offset: 0x009EB450
		// (set) Token: 0x060273EA RID: 160746 RVA: 0x009ED293 File Offset: 0x009EB493
		public TArray<int> 承接步骤ID
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._承接步骤ID) == null)
				{
					result = (this._承接步骤ID = new TArray<int>(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.承接步骤ID.CopyAssign(value);
			}
		}

		// Token: 0x17005BC5 RID: 23493
		// (get) Token: 0x060273EB RID: 160747 RVA: 0x009ED2A1 File Offset: 0x009EB4A1
		// (set) Token: 0x060273EC RID: 160748 RVA: 0x009ED2B5 File Offset: 0x009EB4B5
		[Nullable(0)]
		public unsafe TEnumAsByte<EQuestStepOrder> 步骤连接类型
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_2);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005BC6 RID: 23494
		// (get) Token: 0x060273ED RID: 160749 RVA: 0x009ED2CA File Offset: 0x009EB4CA
		// (set) Token: 0x060273EE RID: 160750 RVA: 0x009ED2DE File Offset: 0x009EB4DE
		[Nullable(0)]
		public unsafe TEnumAsByte<EQuestStepState> 步骤状态
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_3);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005BC7 RID: 23495
		// (get) Token: 0x060273EF RID: 160751 RVA: 0x009ED2F3 File Offset: 0x009EB4F3
		// (set) Token: 0x060273F0 RID: 160752 RVA: 0x009ED307 File Offset: 0x009EB507
		[Nullable(0)]
		public unsafe TEnumAsByte<EQuestStepType> 步骤类型
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_4);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005BC8 RID: 23496
		// (get) Token: 0x060273F1 RID: 160753 RVA: 0x009ED31C File Offset: 0x009EB51C
		// (set) Token: 0x060273F2 RID: 160754 RVA: 0x009ED32C File Offset: 0x009EB52C
		public unsafe int 追踪文本
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005BC9 RID: 23497
		// (get) Token: 0x060273F3 RID: 160755 RVA: 0x009ED33D File Offset: 0x009EB53D
		// (set) Token: 0x060273F4 RID: 160756 RVA: 0x009ED34D File Offset: 0x009EB54D
		public unsafe int 步骤进度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005BCA RID: 23498
		// (get) Token: 0x060273F5 RID: 160757 RVA: 0x009ED35E File Offset: 0x009EB55E
		// (set) Token: 0x060273F6 RID: 160758 RVA: 0x009ED372 File Offset: 0x009EB572
		public unsafe string 剧情ID
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SQuestStep.__PropertyOffset_7)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SQuestStep.__PropertyOffset_7)), value);
			}
		}

		// Token: 0x17005BCB RID: 23499
		// (get) Token: 0x060273F7 RID: 160759 RVA: 0x009ED388 File Offset: 0x009EB588
		// (set) Token: 0x060273F8 RID: 160760 RVA: 0x009ED3CB File Offset: 0x009EB5CB
		public FSoftObjectPath 剧情资源
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._剧情资源) == null)
				{
					result = (this._剧情资源 = new FSoftObjectPath(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_8, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005BCC RID: 23500
		// (get) Token: 0x060273F9 RID: 160761 RVA: 0x009ED3EC File Offset: 0x009EB5EC
		// (set) Token: 0x060273FA RID: 160762 RVA: 0x009ED3FC File Offset: 0x009EB5FC
		public unsafe bool 自动触发
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005BCD RID: 23501
		// (get) Token: 0x060273FB RID: 160763 RVA: 0x009ED40D File Offset: 0x009EB60D
		// (set) Token: 0x060273FC RID: 160764 RVA: 0x009ED41D File Offset: 0x009EB61D
		public unsafe bool 是否需要全部承接步骤完成
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005BCE RID: 23502
		// (get) Token: 0x060273FD RID: 160765 RVA: 0x009ED42E File Offset: 0x009EB62E
		// (set) Token: 0x060273FE RID: 160766 RVA: 0x009ED43E File Offset: 0x009EB63E
		public unsafe bool 是否显示追踪标记
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005BCF RID: 23503
		// (get) Token: 0x060273FF RID: 160767 RVA: 0x009ED44F File Offset: 0x009EB64F
		// (set) Token: 0x06027400 RID: 160768 RVA: 0x009ED45F File Offset: 0x009EB65F
		public unsafe int 地图标记配置ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17005BD0 RID: 23504
		// (get) Token: 0x06027401 RID: 160769 RVA: 0x009ED470 File Offset: 0x009EB670
		// (set) Token: 0x06027402 RID: 160770 RVA: 0x009ED480 File Offset: 0x009EB680
		public unsafe int 触发条件组ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17005BD1 RID: 23505
		// (get) Token: 0x06027403 RID: 160771 RVA: 0x009ED491 File Offset: 0x009EB691
		// (set) Token: 0x06027404 RID: 160772 RVA: 0x009ED4A1 File Offset: 0x009EB6A1
		public unsafe int 触发事件组ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17005BD2 RID: 23506
		// (get) Token: 0x06027405 RID: 160773 RVA: 0x009ED4B2 File Offset: 0x009EB6B2
		// (set) Token: 0x06027406 RID: 160774 RVA: 0x009ED4C2 File Offset: 0x009EB6C2
		public unsafe int 完成条件组ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17005BD3 RID: 23507
		// (get) Token: 0x06027407 RID: 160775 RVA: 0x009ED4D3 File Offset: 0x009EB6D3
		// (set) Token: 0x06027408 RID: 160776 RVA: 0x009ED4E3 File Offset: 0x009EB6E3
		public unsafe int 完成事件组ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17005BD4 RID: 23508
		// (get) Token: 0x06027409 RID: 160777 RVA: 0x009ED4F4 File Offset: 0x009EB6F4
		// (set) Token: 0x0602740A RID: 160778 RVA: 0x009ED504 File Offset: 0x009EB704
		public unsafe int 失败条件组ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17005BD5 RID: 23509
		// (get) Token: 0x0602740B RID: 160779 RVA: 0x009ED515 File Offset: 0x009EB715
		// (set) Token: 0x0602740C RID: 160780 RVA: 0x009ED525 File Offset: 0x009EB725
		public unsafe int 失败事件组ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17005BD6 RID: 23510
		// (get) Token: 0x0602740D RID: 160781 RVA: 0x009ED536 File Offset: 0x009EB736
		// (set) Token: 0x0602740E RID: 160782 RVA: 0x009ED546 File Offset: 0x009EB746
		public unsafe int 步骤奖励组ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17005BD7 RID: 23511
		// (get) Token: 0x0602740F RID: 160783 RVA: 0x009ED558 File Offset: 0x009EB758
		// (set) Token: 0x06027410 RID: 160784 RVA: 0x009ED59B File Offset: 0x009EB79B
		public TArray<AActor> Triggers
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._Triggers) == null)
				{
					result = (this._Triggers = new TArray<AActor>(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_20, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Triggers.CopyAssign(value);
			}
		}

		// Token: 0x17005BD8 RID: 23512
		// (get) Token: 0x06027411 RID: 160785 RVA: 0x009ED5A9 File Offset: 0x009EB7A9
		// (set) Token: 0x06027412 RID: 160786 RVA: 0x009ED5BD File Offset: 0x009EB7BD
		public unsafe FVector TrackPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17005BD9 RID: 23513
		// (get) Token: 0x06027413 RID: 160787 RVA: 0x009ED5D2 File Offset: 0x009EB7D2
		// (set) Token: 0x06027414 RID: 160788 RVA: 0x009ED5E2 File Offset: 0x009EB7E2
		public unsafe bool 是否添加地图标记
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQuestStep.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x06027415 RID: 160789 RVA: 0x009ED5F3 File Offset: 0x009EB7F3
		public SQuestStep()
		{
		}

		// Token: 0x06027416 RID: 160790 RVA: 0x009ED5FC File Offset: 0x009EB7FC
		public SQuestStep(int 步骤ID, TArray<int> 承接步骤ID, [Nullable(0)] TEnumAsByte<EQuestStepOrder> 步骤连接类型, [Nullable(0)] TEnumAsByte<EQuestStepState> 步骤状态, [Nullable(0)] TEnumAsByte<EQuestStepType> 步骤类型, int 追踪文本, int 步骤进度, string 剧情ID, FSoftObjectPath 剧情资源, bool 自动触发, bool 是否需要全部承接步骤完成, bool 是否显示追踪标记, int 地图标记配置ID, int 触发条件组ID, int 触发事件组ID, int 完成条件组ID, int 完成事件组ID, int 失败条件组ID, int 失败事件组ID, int 步骤奖励组ID, TArray<AActor> Triggers, FVector TrackPosition, bool 是否添加地图标记)
		{
			this.步骤ID = 步骤ID;
			this.承接步骤ID = 承接步骤ID;
			this.步骤连接类型 = 步骤连接类型;
			this.步骤状态 = 步骤状态;
			this.步骤类型 = 步骤类型;
			this.追踪文本 = 追踪文本;
			this.步骤进度 = 步骤进度;
			this.剧情ID = 剧情ID;
			this.剧情资源 = 剧情资源;
			this.自动触发 = 自动触发;
			this.是否需要全部承接步骤完成 = 是否需要全部承接步骤完成;
			this.是否显示追踪标记 = 是否显示追踪标记;
			this.地图标记配置ID = 地图标记配置ID;
			this.触发条件组ID = 触发条件组ID;
			this.触发事件组ID = 触发事件组ID;
			this.完成条件组ID = 完成条件组ID;
			this.完成事件组ID = 完成事件组ID;
			this.失败条件组ID = 失败条件组ID;
			this.失败事件组ID = 失败事件组ID;
			this.步骤奖励组ID = 步骤奖励组ID;
			this.Triggers = Triggers;
			this.TrackPosition = TrackPosition;
			this.是否添加地图标记 = 是否添加地图标记;
		}

		// Token: 0x06027417 RID: 160791 RVA: 0x009ED6C4 File Offset: 0x009EB8C4
		protected override IntPtr GetUStructPtr()
		{
			return SQuestStep.StaticStruct();
		}

		// Token: 0x06027418 RID: 160792 RVA: 0x009ED6D0 File Offset: 0x009EB8D0
		[NullableContext(2)]
		public SQuestStep(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027419 RID: 160793 RVA: 0x009ED6DA File Offset: 0x009EB8DA
		public SQuestStep(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602741A RID: 160794 RVA: 0x009ED6E5 File Offset: 0x009EB8E5
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SQuestStep(Pointer, false, true);
		}

		// Token: 0x0602741B RID: 160795 RVA: 0x009ED6EF File Offset: 0x009EB8EF
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SQuestStep(Pointer, MemoryOwner);
		}

		// Token: 0x04014847 RID: 84039
		public const string __ObjectPath = "/Game/Aki/Data/Quest/Structures/SQuestStep.SQuestStep";

		// Token: 0x04014848 RID: 84040
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014849 RID: 84041
		internal static int __PropertyOffset_0;

		// Token: 0x0401484A RID: 84042
		internal static int __PropertyOffset_1;

		// Token: 0x0401484B RID: 84043
		[Nullable(2)]
		private TArray<int> _承接步骤ID;

		// Token: 0x0401484C RID: 84044
		internal static int __PropertyOffset_2;

		// Token: 0x0401484D RID: 84045
		internal static int __PropertyOffset_3;

		// Token: 0x0401484E RID: 84046
		internal static int __PropertyOffset_4;

		// Token: 0x0401484F RID: 84047
		internal static int __PropertyOffset_5;

		// Token: 0x04014850 RID: 84048
		internal static int __PropertyOffset_6;

		// Token: 0x04014851 RID: 84049
		internal static int __PropertyOffset_7;

		// Token: 0x04014852 RID: 84050
		internal static int __PropertyOffset_8;

		// Token: 0x04014853 RID: 84051
		[Nullable(2)]
		private FSoftObjectPath _剧情资源;

		// Token: 0x04014854 RID: 84052
		internal static int __PropertyOffset_9;

		// Token: 0x04014855 RID: 84053
		internal static int __PropertyOffset_10;

		// Token: 0x04014856 RID: 84054
		internal static int __PropertyOffset_11;

		// Token: 0x04014857 RID: 84055
		internal static int __PropertyOffset_12;

		// Token: 0x04014858 RID: 84056
		internal static int __PropertyOffset_13;

		// Token: 0x04014859 RID: 84057
		internal static int __PropertyOffset_14;

		// Token: 0x0401485A RID: 84058
		internal static int __PropertyOffset_15;

		// Token: 0x0401485B RID: 84059
		internal static int __PropertyOffset_16;

		// Token: 0x0401485C RID: 84060
		internal static int __PropertyOffset_17;

		// Token: 0x0401485D RID: 84061
		internal static int __PropertyOffset_18;

		// Token: 0x0401485E RID: 84062
		internal static int __PropertyOffset_19;

		// Token: 0x0401485F RID: 84063
		internal static int __PropertyOffset_20;

		// Token: 0x04014860 RID: 84064
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _Triggers;

		// Token: 0x04014861 RID: 84065
		internal static int __PropertyOffset_21;

		// Token: 0x04014862 RID: 84066
		internal static int __PropertyOffset_22;
	}
}
