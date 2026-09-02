using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Fight.Struct
{
	// Token: 0x02003EDC RID: 16092
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/Struct/SReBulletDataMain_ExcellTest.SReBulletDataMain_ExcellTest")]
	[UnrealStructLayout(1984, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 1984)]
	public class SReBulletDataMain_ExcellTest : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060280C1 RID: 164033 RVA: 0x00A011C4 File Offset: 0x009FF3C4
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SReBulletDataMain_ExcellTest._ScriptStructPtr != 0) ? SReBulletDataMain_ExcellTest._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/Struct/SReBulletDataMain_ExcellTest.SReBulletDataMain_ExcellTest", ref SReBulletDataMain_ExcellTest._ScriptStructPtr);
		}

		// Token: 0x17006035 RID: 24629
		// (get) Token: 0x060280C2 RID: 164034 RVA: 0x00A011E8 File Offset: 0x009FF3E8
		// (set) Token: 0x060280C3 RID: 164035 RVA: 0x00A011FC File Offset: 0x009FF3FC
		public unsafe FName 子弹名称
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataMain_ExcellTest.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataMain_ExcellTest.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17006036 RID: 24630
		// (get) Token: 0x060280C4 RID: 164036 RVA: 0x00A01211 File Offset: 0x009FF411
		// (set) Token: 0x060280C5 RID: 164037 RVA: 0x00A01225 File Offset: 0x009FF425
		public unsafe string 新增备注列
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SReBulletDataMain_ExcellTest.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SReBulletDataMain_ExcellTest.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x17006037 RID: 24631
		// (get) Token: 0x060280C6 RID: 164038 RVA: 0x00A0123C File Offset: 0x009FF43C
		// (set) Token: 0x060280C7 RID: 164039 RVA: 0x00A0127F File Offset: 0x009FF47F
		public SReBulletDataBase_ExcelTest 基础设置
		{
			get
			{
				base.FastCheckIsValid();
				SReBulletDataBase_ExcelTest result;
				if ((result = this._基础设置) == null)
				{
					result = (this._基础设置 = new SReBulletDataBase_ExcelTest(base.NativePtr + (IntPtr)SReBulletDataMain_ExcellTest.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SReBulletDataBase_ExcelTest.StaticStruct(), base.NativePtr + (IntPtr)SReBulletDataMain_ExcellTest.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006038 RID: 24632
		// (get) Token: 0x060280C8 RID: 164040 RVA: 0x00A012A0 File Offset: 0x009FF4A0
		// (set) Token: 0x060280C9 RID: 164041 RVA: 0x00A012E3 File Offset: 0x009FF4E3
		public SReBulletDataLogic 逻辑设置
		{
			get
			{
				base.FastCheckIsValid();
				SReBulletDataLogic result;
				if ((result = this._逻辑设置) == null)
				{
					result = (this._逻辑设置 = new SReBulletDataLogic(base.NativePtr + (IntPtr)SReBulletDataMain_ExcellTest.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SReBulletDataLogic.StaticStruct(), base.NativePtr + (IntPtr)SReBulletDataMain_ExcellTest.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006039 RID: 24633
		// (get) Token: 0x060280CA RID: 164042 RVA: 0x00A01304 File Offset: 0x009FF504
		// (set) Token: 0x060280CB RID: 164043 RVA: 0x00A01318 File Offset: 0x009FF518
		public unsafe SReBulletDataAimed 瞄准设置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataMain_ExcellTest.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataMain_ExcellTest.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700603A RID: 24634
		// (get) Token: 0x060280CC RID: 164044 RVA: 0x00A01330 File Offset: 0x009FF530
		// (set) Token: 0x060280CD RID: 164045 RVA: 0x00A01373 File Offset: 0x009FF573
		public SReBulletDataMove 移动设置
		{
			get
			{
				base.FastCheckIsValid();
				SReBulletDataMove result;
				if ((result = this._移动设置) == null)
				{
					result = (this._移动设置 = new SReBulletDataMove(base.NativePtr + (IntPtr)SReBulletDataMain_ExcellTest.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SReBulletDataMove.StaticStruct(), base.NativePtr + (IntPtr)SReBulletDataMain_ExcellTest.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700603B RID: 24635
		// (get) Token: 0x060280CE RID: 164046 RVA: 0x00A01394 File Offset: 0x009FF594
		// (set) Token: 0x060280CF RID: 164047 RVA: 0x00A013D7 File Offset: 0x009FF5D7
		public SReBulletDataPerformance 表现效果设置
		{
			get
			{
				base.FastCheckIsValid();
				SReBulletDataPerformance result;
				if ((result = this._表现效果设置) == null)
				{
					result = (this._表现效果设置 = new SReBulletDataPerformance(base.NativePtr + (IntPtr)SReBulletDataMain_ExcellTest.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SReBulletDataPerformance.StaticStruct(), base.NativePtr + (IntPtr)SReBulletDataMain_ExcellTest.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700603C RID: 24636
		// (get) Token: 0x060280D0 RID: 164048 RVA: 0x00A013F8 File Offset: 0x009FF5F8
		// (set) Token: 0x060280D1 RID: 164049 RVA: 0x00A0143B File Offset: 0x009FF63B
		public SReBulletDataTime 时间膨胀
		{
			get
			{
				base.FastCheckIsValid();
				SReBulletDataTime result;
				if ((result = this._时间膨胀) == null)
				{
					result = (this._时间膨胀 = new SReBulletDataTime(base.NativePtr + (IntPtr)SReBulletDataMain_ExcellTest.__PropertyOffset_7, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SReBulletDataTime.StaticStruct(), base.NativePtr + (IntPtr)SReBulletDataMain_ExcellTest.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700603D RID: 24637
		// (get) Token: 0x060280D2 RID: 164050 RVA: 0x00A0145C File Offset: 0x009FF65C
		// (set) Token: 0x060280D3 RID: 164051 RVA: 0x00A0149F File Offset: 0x009FF69F
		public SReBulletDataExe 执行逻辑
		{
			get
			{
				base.FastCheckIsValid();
				SReBulletDataExe result;
				if ((result = this._执行逻辑) == null)
				{
					result = (this._执行逻辑 = new SReBulletDataExe(base.NativePtr + (IntPtr)SReBulletDataMain_ExcellTest.__PropertyOffset_8, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SReBulletDataExe.StaticStruct(), base.NativePtr + (IntPtr)SReBulletDataMain_ExcellTest.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700603E RID: 24638
		// (get) Token: 0x060280D4 RID: 164052 RVA: 0x00A014C0 File Offset: 0x009FF6C0
		// (set) Token: 0x060280D5 RID: 164053 RVA: 0x00A01503 File Offset: 0x009FF703
		public SReBulletDataScale 缩放设置
		{
			get
			{
				base.FastCheckIsValid();
				SReBulletDataScale result;
				if ((result = this._缩放设置) == null)
				{
					result = (this._缩放设置 = new SReBulletDataScale(base.NativePtr + (IntPtr)SReBulletDataMain_ExcellTest.__PropertyOffset_9, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SReBulletDataScale.StaticStruct(), base.NativePtr + (IntPtr)SReBulletDataMain_ExcellTest.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700603F RID: 24639
		// (get) Token: 0x060280D6 RID: 164054 RVA: 0x00A01524 File Offset: 0x009FF724
		// (set) Token: 0x060280D7 RID: 164055 RVA: 0x00A01538 File Offset: 0x009FF738
		public unsafe SReBulletDataEntity 召唤实体
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataMain_ExcellTest.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataMain_ExcellTest.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17006040 RID: 24640
		// (get) Token: 0x060280D8 RID: 164056 RVA: 0x00A01550 File Offset: 0x009FF750
		// (set) Token: 0x060280D9 RID: 164057 RVA: 0x00A01593 File Offset: 0x009FF793
		public TArray<SReBulletDataChildren> 子子弹设置
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SReBulletDataChildren> result;
				if ((result = this._子子弹设置) == null)
				{
					result = (this._子子弹设置 = new TArray<SReBulletDataChildren>(base.NativePtr + (IntPtr)SReBulletDataMain_ExcellTest.__PropertyOffset_11, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.子子弹设置.CopyAssign(value);
			}
		}

		// Token: 0x17006041 RID: 24641
		// (get) Token: 0x060280DA RID: 164058 RVA: 0x00A015A1 File Offset: 0x009FF7A1
		// (set) Token: 0x060280DB RID: 164059 RVA: 0x00A015B5 File Offset: 0x009FF7B5
		public unsafe SReBulletDataObstacles 障碍检测
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataMain_ExcellTest.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataMain_ExcellTest.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17006042 RID: 24642
		// (get) Token: 0x060280DC RID: 164060 RVA: 0x00A015CC File Offset: 0x009FF7CC
		// (set) Token: 0x060280DD RID: 164061 RVA: 0x00A0160F File Offset: 0x009FF80F
		public SReBulletDataInteraction 环境交互
		{
			get
			{
				base.FastCheckIsValid();
				SReBulletDataInteraction result;
				if ((result = this._环境交互) == null)
				{
					result = (this._环境交互 = new SReBulletDataInteraction(base.NativePtr + (IntPtr)SReBulletDataMain_ExcellTest.__PropertyOffset_13, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SReBulletDataInteraction.StaticStruct(), base.NativePtr + (IntPtr)SReBulletDataMain_ExcellTest.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x060280DE RID: 164062 RVA: 0x00A01630 File Offset: 0x009FF830
		public SReBulletDataMain_ExcellTest()
		{
		}

		// Token: 0x060280DF RID: 164063 RVA: 0x00A01638 File Offset: 0x009FF838
		public SReBulletDataMain_ExcellTest(FName 子弹名称, string 新增备注列, SReBulletDataBase_ExcelTest 基础设置, SReBulletDataLogic 逻辑设置, SReBulletDataAimed 瞄准设置, SReBulletDataMove 移动设置, SReBulletDataPerformance 表现效果设置, SReBulletDataTime 时间膨胀, SReBulletDataExe 执行逻辑, SReBulletDataScale 缩放设置, SReBulletDataEntity 召唤实体, TArray<SReBulletDataChildren> 子子弹设置, SReBulletDataObstacles 障碍检测, SReBulletDataInteraction 环境交互)
		{
			this.子弹名称 = 子弹名称;
			this.新增备注列 = 新增备注列;
			this.基础设置 = 基础设置;
			this.逻辑设置 = 逻辑设置;
			this.瞄准设置 = 瞄准设置;
			this.移动设置 = 移动设置;
			this.表现效果设置 = 表现效果设置;
			this.时间膨胀 = 时间膨胀;
			this.执行逻辑 = 执行逻辑;
			this.缩放设置 = 缩放设置;
			this.召唤实体 = 召唤实体;
			this.子子弹设置 = 子子弹设置;
			this.障碍检测 = 障碍检测;
			this.环境交互 = 环境交互;
		}

		// Token: 0x060280E0 RID: 164064 RVA: 0x00A016B8 File Offset: 0x009FF8B8
		protected override IntPtr GetUStructPtr()
		{
			return SReBulletDataMain_ExcellTest.StaticStruct();
		}

		// Token: 0x060280E1 RID: 164065 RVA: 0x00A016C4 File Offset: 0x009FF8C4
		[NullableContext(2)]
		public SReBulletDataMain_ExcellTest(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060280E2 RID: 164066 RVA: 0x00A016CE File Offset: 0x009FF8CE
		public SReBulletDataMain_ExcellTest(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060280E3 RID: 164067 RVA: 0x00A016D9 File Offset: 0x009FF8D9
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SReBulletDataMain_ExcellTest(Pointer, false, true);
		}

		// Token: 0x060280E4 RID: 164068 RVA: 0x00A016E3 File Offset: 0x009FF8E3
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SReBulletDataMain_ExcellTest(Pointer, MemoryOwner);
		}

		// Token: 0x0401505B RID: 86107
		public const string __ObjectPath = "/Game/Aki/Data/Fight/Struct/SReBulletDataMain_ExcellTest.SReBulletDataMain_ExcellTest";

		// Token: 0x0401505C RID: 86108
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401505D RID: 86109
		internal static int __PropertyOffset_0;

		// Token: 0x0401505E RID: 86110
		internal static int __PropertyOffset_1;

		// Token: 0x0401505F RID: 86111
		internal static int __PropertyOffset_2;

		// Token: 0x04015060 RID: 86112
		[Nullable(2)]
		private SReBulletDataBase_ExcelTest _基础设置;

		// Token: 0x04015061 RID: 86113
		internal static int __PropertyOffset_3;

		// Token: 0x04015062 RID: 86114
		[Nullable(2)]
		private SReBulletDataLogic _逻辑设置;

		// Token: 0x04015063 RID: 86115
		internal static int __PropertyOffset_4;

		// Token: 0x04015064 RID: 86116
		internal static int __PropertyOffset_5;

		// Token: 0x04015065 RID: 86117
		[Nullable(2)]
		private SReBulletDataMove _移动设置;

		// Token: 0x04015066 RID: 86118
		internal static int __PropertyOffset_6;

		// Token: 0x04015067 RID: 86119
		[Nullable(2)]
		private SReBulletDataPerformance _表现效果设置;

		// Token: 0x04015068 RID: 86120
		internal static int __PropertyOffset_7;

		// Token: 0x04015069 RID: 86121
		[Nullable(2)]
		private SReBulletDataTime _时间膨胀;

		// Token: 0x0401506A RID: 86122
		internal static int __PropertyOffset_8;

		// Token: 0x0401506B RID: 86123
		[Nullable(2)]
		private SReBulletDataExe _执行逻辑;

		// Token: 0x0401506C RID: 86124
		internal static int __PropertyOffset_9;

		// Token: 0x0401506D RID: 86125
		[Nullable(2)]
		private SReBulletDataScale _缩放设置;

		// Token: 0x0401506E RID: 86126
		internal static int __PropertyOffset_10;

		// Token: 0x0401506F RID: 86127
		internal static int __PropertyOffset_11;

		// Token: 0x04015070 RID: 86128
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SReBulletDataChildren> _子子弹设置;

		// Token: 0x04015071 RID: 86129
		internal static int __PropertyOffset_12;

		// Token: 0x04015072 RID: 86130
		internal static int __PropertyOffset_13;

		// Token: 0x04015073 RID: 86131
		[Nullable(2)]
		private SReBulletDataInteraction _环境交互;
	}
}
