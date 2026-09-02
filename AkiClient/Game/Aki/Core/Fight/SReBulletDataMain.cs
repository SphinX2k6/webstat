using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F74 RID: 16244
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/SReBulletDataMain.SReBulletDataMain")]
	[UnrealStructLayout(1992, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 1992)]
	public class SReBulletDataMain : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028962 RID: 166242 RVA: 0x00A0F8E5 File Offset: 0x00A0DAE5
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SReBulletDataMain._ScriptStructPtr != 0) ? SReBulletDataMain._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Core/Fight/SReBulletDataMain.SReBulletDataMain", ref SReBulletDataMain._ScriptStructPtr);
		}

		// Token: 0x17006301 RID: 25345
		// (get) Token: 0x06028963 RID: 166243 RVA: 0x00A0F909 File Offset: 0x00A0DB09
		// (set) Token: 0x06028964 RID: 166244 RVA: 0x00A0F91D File Offset: 0x00A0DB1D
		public unsafe FName 子弹名称
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataMain.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataMain.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17006302 RID: 25346
		// (get) Token: 0x06028965 RID: 166245 RVA: 0x00A0F934 File Offset: 0x00A0DB34
		// (set) Token: 0x06028966 RID: 166246 RVA: 0x00A0F977 File Offset: 0x00A0DB77
		public SReBulletDataBase 基础设置
		{
			get
			{
				base.FastCheckIsValid();
				SReBulletDataBase result;
				if ((result = this._基础设置) == null)
				{
					result = (this._基础设置 = new SReBulletDataBase(base.NativePtr + (IntPtr)SReBulletDataMain.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SReBulletDataBase.StaticStruct(), base.NativePtr + (IntPtr)SReBulletDataMain.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006303 RID: 25347
		// (get) Token: 0x06028967 RID: 166247 RVA: 0x00A0F998 File Offset: 0x00A0DB98
		// (set) Token: 0x06028968 RID: 166248 RVA: 0x00A0F9DB File Offset: 0x00A0DBDB
		public SReBulletDataLogic 逻辑设置
		{
			get
			{
				base.FastCheckIsValid();
				SReBulletDataLogic result;
				if ((result = this._逻辑设置) == null)
				{
					result = (this._逻辑设置 = new SReBulletDataLogic(base.NativePtr + (IntPtr)SReBulletDataMain.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SReBulletDataLogic.StaticStruct(), base.NativePtr + (IntPtr)SReBulletDataMain.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006304 RID: 25348
		// (get) Token: 0x06028969 RID: 166249 RVA: 0x00A0F9FC File Offset: 0x00A0DBFC
		// (set) Token: 0x0602896A RID: 166250 RVA: 0x00A0FA10 File Offset: 0x00A0DC10
		public unsafe SReBulletDataAimed 瞄准设置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataMain.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataMain.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17006305 RID: 25349
		// (get) Token: 0x0602896B RID: 166251 RVA: 0x00A0FA28 File Offset: 0x00A0DC28
		// (set) Token: 0x0602896C RID: 166252 RVA: 0x00A0FA6B File Offset: 0x00A0DC6B
		public SReBulletDataMove 移动设置
		{
			get
			{
				base.FastCheckIsValid();
				SReBulletDataMove result;
				if ((result = this._移动设置) == null)
				{
					result = (this._移动设置 = new SReBulletDataMove(base.NativePtr + (IntPtr)SReBulletDataMain.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SReBulletDataMove.StaticStruct(), base.NativePtr + (IntPtr)SReBulletDataMain.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006306 RID: 25350
		// (get) Token: 0x0602896D RID: 166253 RVA: 0x00A0FA8C File Offset: 0x00A0DC8C
		// (set) Token: 0x0602896E RID: 166254 RVA: 0x00A0FACF File Offset: 0x00A0DCCF
		public SReBulletDataPerformance 表现效果设置
		{
			get
			{
				base.FastCheckIsValid();
				SReBulletDataPerformance result;
				if ((result = this._表现效果设置) == null)
				{
					result = (this._表现效果设置 = new SReBulletDataPerformance(base.NativePtr + (IntPtr)SReBulletDataMain.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SReBulletDataPerformance.StaticStruct(), base.NativePtr + (IntPtr)SReBulletDataMain.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006307 RID: 25351
		// (get) Token: 0x0602896F RID: 166255 RVA: 0x00A0FAF0 File Offset: 0x00A0DCF0
		// (set) Token: 0x06028970 RID: 166256 RVA: 0x00A0FB33 File Offset: 0x00A0DD33
		public SReBulletDataTime 时间膨胀
		{
			get
			{
				base.FastCheckIsValid();
				SReBulletDataTime result;
				if ((result = this._时间膨胀) == null)
				{
					result = (this._时间膨胀 = new SReBulletDataTime(base.NativePtr + (IntPtr)SReBulletDataMain.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SReBulletDataTime.StaticStruct(), base.NativePtr + (IntPtr)SReBulletDataMain.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006308 RID: 25352
		// (get) Token: 0x06028971 RID: 166257 RVA: 0x00A0FB54 File Offset: 0x00A0DD54
		// (set) Token: 0x06028972 RID: 166258 RVA: 0x00A0FB97 File Offset: 0x00A0DD97
		public SReBulletDataExe 执行逻辑
		{
			get
			{
				base.FastCheckIsValid();
				SReBulletDataExe result;
				if ((result = this._执行逻辑) == null)
				{
					result = (this._执行逻辑 = new SReBulletDataExe(base.NativePtr + (IntPtr)SReBulletDataMain.__PropertyOffset_7, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SReBulletDataExe.StaticStruct(), base.NativePtr + (IntPtr)SReBulletDataMain.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006309 RID: 25353
		// (get) Token: 0x06028973 RID: 166259 RVA: 0x00A0FBB8 File Offset: 0x00A0DDB8
		// (set) Token: 0x06028974 RID: 166260 RVA: 0x00A0FBFB File Offset: 0x00A0DDFB
		public SReBulletDataScale 缩放设置
		{
			get
			{
				base.FastCheckIsValid();
				SReBulletDataScale result;
				if ((result = this._缩放设置) == null)
				{
					result = (this._缩放设置 = new SReBulletDataScale(base.NativePtr + (IntPtr)SReBulletDataMain.__PropertyOffset_8, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SReBulletDataScale.StaticStruct(), base.NativePtr + (IntPtr)SReBulletDataMain.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700630A RID: 25354
		// (get) Token: 0x06028975 RID: 166261 RVA: 0x00A0FC1C File Offset: 0x00A0DE1C
		// (set) Token: 0x06028976 RID: 166262 RVA: 0x00A0FC30 File Offset: 0x00A0DE30
		public unsafe SReBulletDataEntity 召唤实体
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataMain.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataMain.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700630B RID: 25355
		// (get) Token: 0x06028977 RID: 166263 RVA: 0x00A0FC48 File Offset: 0x00A0DE48
		// (set) Token: 0x06028978 RID: 166264 RVA: 0x00A0FC8B File Offset: 0x00A0DE8B
		public TArray<SReBulletDataChildren> 子子弹设置
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SReBulletDataChildren> result;
				if ((result = this._子子弹设置) == null)
				{
					result = (this._子子弹设置 = new TArray<SReBulletDataChildren>(base.NativePtr + (IntPtr)SReBulletDataMain.__PropertyOffset_10, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.子子弹设置.CopyAssign(value);
			}
		}

		// Token: 0x1700630C RID: 25356
		// (get) Token: 0x06028979 RID: 166265 RVA: 0x00A0FC99 File Offset: 0x00A0DE99
		// (set) Token: 0x0602897A RID: 166266 RVA: 0x00A0FCAD File Offset: 0x00A0DEAD
		public unsafe SReBulletDataObstacles 障碍检测
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataMain.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataMain.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x1700630D RID: 25357
		// (get) Token: 0x0602897B RID: 166267 RVA: 0x00A0FCC4 File Offset: 0x00A0DEC4
		// (set) Token: 0x0602897C RID: 166268 RVA: 0x00A0FD07 File Offset: 0x00A0DF07
		public SReBulletDataInteraction 环境交互
		{
			get
			{
				base.FastCheckIsValid();
				SReBulletDataInteraction result;
				if ((result = this._环境交互) == null)
				{
					result = (this._环境交互 = new SReBulletDataInteraction(base.NativePtr + (IntPtr)SReBulletDataMain.__PropertyOffset_12, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SReBulletDataInteraction.StaticStruct(), base.NativePtr + (IntPtr)SReBulletDataMain.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602897D RID: 166269 RVA: 0x00A0FD28 File Offset: 0x00A0DF28
		public SReBulletDataMain()
		{
		}

		// Token: 0x0602897E RID: 166270 RVA: 0x00A0FD30 File Offset: 0x00A0DF30
		public SReBulletDataMain(FName 子弹名称, SReBulletDataBase 基础设置, SReBulletDataLogic 逻辑设置, SReBulletDataAimed 瞄准设置, SReBulletDataMove 移动设置, SReBulletDataPerformance 表现效果设置, SReBulletDataTime 时间膨胀, SReBulletDataExe 执行逻辑, SReBulletDataScale 缩放设置, SReBulletDataEntity 召唤实体, TArray<SReBulletDataChildren> 子子弹设置, SReBulletDataObstacles 障碍检测, SReBulletDataInteraction 环境交互)
		{
			this.子弹名称 = 子弹名称;
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

		// Token: 0x0602897F RID: 166271 RVA: 0x00A0FDA8 File Offset: 0x00A0DFA8
		protected override IntPtr GetUStructPtr()
		{
			return SReBulletDataMain.StaticStruct();
		}

		// Token: 0x06028980 RID: 166272 RVA: 0x00A0FDB4 File Offset: 0x00A0DFB4
		[NullableContext(2)]
		public SReBulletDataMain(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028981 RID: 166273 RVA: 0x00A0FDBE File Offset: 0x00A0DFBE
		public SReBulletDataMain(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028982 RID: 166274 RVA: 0x00A0FDC9 File Offset: 0x00A0DFC9
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SReBulletDataMain(Pointer, false, true);
		}

		// Token: 0x06028983 RID: 166275 RVA: 0x00A0FDD3 File Offset: 0x00A0DFD3
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SReBulletDataMain(Pointer, MemoryOwner);
		}

		// Token: 0x04015674 RID: 87668
		public const string __ObjectPath = "/Game/Aki/Core/Fight/SReBulletDataMain.SReBulletDataMain";

		// Token: 0x04015675 RID: 87669
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015676 RID: 87670
		internal static int __PropertyOffset_0;

		// Token: 0x04015677 RID: 87671
		internal static int __PropertyOffset_1;

		// Token: 0x04015678 RID: 87672
		[Nullable(2)]
		private SReBulletDataBase _基础设置;

		// Token: 0x04015679 RID: 87673
		internal static int __PropertyOffset_2;

		// Token: 0x0401567A RID: 87674
		[Nullable(2)]
		private SReBulletDataLogic _逻辑设置;

		// Token: 0x0401567B RID: 87675
		internal static int __PropertyOffset_3;

		// Token: 0x0401567C RID: 87676
		internal static int __PropertyOffset_4;

		// Token: 0x0401567D RID: 87677
		[Nullable(2)]
		private SReBulletDataMove _移动设置;

		// Token: 0x0401567E RID: 87678
		internal static int __PropertyOffset_5;

		// Token: 0x0401567F RID: 87679
		[Nullable(2)]
		private SReBulletDataPerformance _表现效果设置;

		// Token: 0x04015680 RID: 87680
		internal static int __PropertyOffset_6;

		// Token: 0x04015681 RID: 87681
		[Nullable(2)]
		private SReBulletDataTime _时间膨胀;

		// Token: 0x04015682 RID: 87682
		internal static int __PropertyOffset_7;

		// Token: 0x04015683 RID: 87683
		[Nullable(2)]
		private SReBulletDataExe _执行逻辑;

		// Token: 0x04015684 RID: 87684
		internal static int __PropertyOffset_8;

		// Token: 0x04015685 RID: 87685
		[Nullable(2)]
		private SReBulletDataScale _缩放设置;

		// Token: 0x04015686 RID: 87686
		internal static int __PropertyOffset_9;

		// Token: 0x04015687 RID: 87687
		internal static int __PropertyOffset_10;

		// Token: 0x04015688 RID: 87688
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SReBulletDataChildren> _子子弹设置;

		// Token: 0x04015689 RID: 87689
		internal static int __PropertyOffset_11;

		// Token: 0x0401568A RID: 87690
		internal static int __PropertyOffset_12;

		// Token: 0x0401568B RID: 87691
		[Nullable(2)]
		private SReBulletDataInteraction _环境交互;
	}
}
