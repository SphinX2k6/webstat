using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200423E RID: 16958
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SBulletDataBase.SBulletDataBase")]
	[UnrealStructLayout(216, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 210)]
	public class SBulletDataBase : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CDD3 RID: 183763 RVA: 0x00AB1DFE File Offset: 0x00AAFFFE
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBulletDataBase._ScriptStructPtr != 0) ? SBulletDataBase._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SBulletDataBase.SBulletDataBase", ref SBulletDataBase._ScriptStructPtr);
		}

		// Token: 0x17007966 RID: 31078
		// (get) Token: 0x0602CDD4 RID: 183764 RVA: 0x00AB1E22 File Offset: 0x00AB0022
		// (set) Token: 0x0602CDD5 RID: 183765 RVA: 0x00AB1E36 File Offset: 0x00AB0036
		public unsafe TEnumAsByte<EBulletShape> 子弹形状
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007967 RID: 31079
		// (get) Token: 0x0602CDD6 RID: 183766 RVA: 0x00AB1E4B File Offset: 0x00AB004B
		// (set) Token: 0x0602CDD7 RID: 183767 RVA: 0x00AB1E6A File Offset: 0x00AB006A
		[Nullable(1)]
		public TSoftObjectPtr<UStaticMesh> 子弹模型
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<UStaticMesh>(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_1, base.MemoryOwner ?? this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17007968 RID: 31080
		// (get) Token: 0x0602CDD8 RID: 183768 RVA: 0x00AB1E8F File Offset: 0x00AB008F
		// (set) Token: 0x0602CDD9 RID: 183769 RVA: 0x00AB1EA3 File Offset: 0x00AB00A3
		public unsafe FVector 初始大小
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007969 RID: 31081
		// (get) Token: 0x0602CDDA RID: 183770 RVA: 0x00AB1EB8 File Offset: 0x00AB00B8
		// (set) Token: 0x0602CDDB RID: 183771 RVA: 0x00AB1ECC File Offset: 0x00AB00CC
		public unsafe FVector 初始位置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700796A RID: 31082
		// (get) Token: 0x0602CDDC RID: 183772 RVA: 0x00AB1EE1 File Offset: 0x00AB00E1
		// (set) Token: 0x0602CDDD RID: 183773 RVA: 0x00AB1EF5 File Offset: 0x00AB00F5
		public unsafe FVector 初始旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700796B RID: 31083
		// (get) Token: 0x0602CDDE RID: 183774 RVA: 0x00AB1F0A File Offset: 0x00AB010A
		// (set) Token: 0x0602CDDF RID: 183775 RVA: 0x00AB1F1A File Offset: 0x00AB011A
		public unsafe float 持续时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700796C RID: 31084
		// (get) Token: 0x0602CDE0 RID: 183776 RVA: 0x00AB1F2B File Offset: 0x00AB012B
		// (set) Token: 0x0602CDE1 RID: 183777 RVA: 0x00AB1F3B File Offset: 0x00AB013B
		public unsafe int 命中个数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700796D RID: 31085
		// (get) Token: 0x0602CDE2 RID: 183778 RVA: 0x00AB1F4C File Offset: 0x00AB014C
		// (set) Token: 0x0602CDE3 RID: 183779 RVA: 0x00AB1F5C File Offset: 0x00AB015C
		public unsafe int 作用次数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700796E RID: 31086
		// (get) Token: 0x0602CDE4 RID: 183780 RVA: 0x00AB1F6D File Offset: 0x00AB016D
		// (set) Token: 0x0602CDE5 RID: 183781 RVA: 0x00AB1F7D File Offset: 0x00AB017D
		public unsafe bool 被极限闪避后销毁
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700796F RID: 31087
		// (get) Token: 0x0602CDE6 RID: 183782 RVA: 0x00AB1F8E File Offset: 0x00AB018E
		// (set) Token: 0x0602CDE7 RID: 183783 RVA: 0x00AB1FA2 File Offset: 0x00AB01A2
		public unsafe FName 被击效果
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17007970 RID: 31088
		// (get) Token: 0x0602CDE8 RID: 183784 RVA: 0x00AB1FB7 File Offset: 0x00AB01B7
		// (set) Token: 0x0602CDE9 RID: 183785 RVA: 0x00AB1FC7 File Offset: 0x00AB01C7
		public unsafe float 作用间隔
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17007971 RID: 31089
		// (get) Token: 0x0602CDEA RID: 183786 RVA: 0x00AB1FD8 File Offset: 0x00AB01D8
		// (set) Token: 0x0602CDEB RID: 183787 RVA: 0x00AB1FEC File Offset: 0x00AB01EC
		public unsafe TEnumAsByte<EBulletRelativeDir> 受击类型
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17007972 RID: 31090
		// (get) Token: 0x0602CDEC RID: 183788 RVA: 0x00AB2001 File Offset: 0x00AB0201
		// (set) Token: 0x0602CDED RID: 183789 RVA: 0x00AB2011 File Offset: 0x00AB0211
		public unsafe int 执行效果ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17007973 RID: 31091
		// (get) Token: 0x0602CDEE RID: 183790 RVA: 0x00AB2022 File Offset: 0x00AB0222
		// (set) Token: 0x0602CDEF RID: 183791 RVA: 0x00AB2036 File Offset: 0x00AB0236
		public unsafe FRotator 子弹攻击方向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17007974 RID: 31092
		// (get) Token: 0x0602CDF0 RID: 183792 RVA: 0x00AB204B File Offset: 0x00AB024B
		// (set) Token: 0x0602CDF1 RID: 183793 RVA: 0x00AB205B File Offset: 0x00AB025B
		public unsafe bool 技能结束是否销毁子弹
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007975 RID: 31093
		// (get) Token: 0x0602CDF2 RID: 183794 RVA: 0x00AB206C File Offset: 0x00AB026C
		// (set) Token: 0x0602CDF3 RID: 183795 RVA: 0x00AB207C File Offset: 0x00AB027C
		public unsafe int 伤害类型
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17007976 RID: 31094
		// (get) Token: 0x0602CDF4 RID: 183796 RVA: 0x00AB208D File Offset: 0x00AB028D
		// (set) Token: 0x0602CDF5 RID: 183797 RVA: 0x00AB209D File Offset: 0x00AB029D
		public unsafe bool 是否可以触发极限闪避
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007977 RID: 31095
		// (get) Token: 0x0602CDF6 RID: 183798 RVA: 0x00AB20AE File Offset: 0x00AB02AE
		// (set) Token: 0x0602CDF7 RID: 183799 RVA: 0x00AB20BE File Offset: 0x00AB02BE
		public unsafe bool 是否触发拼刀
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007978 RID: 31096
		// (get) Token: 0x0602CDF8 RID: 183800 RVA: 0x00AB20CF File Offset: 0x00AB02CF
		// (set) Token: 0x0602CDF9 RID: 183801 RVA: 0x00AB20EE File Offset: 0x00AB02EE
		[Nullable(1)]
		public TSoftClassPtr<UMatineeCameraShake> 攻击者震屏
		{
			[NullableContext(1)]
			get
			{
				return new TSoftClassPtr<UMatineeCameraShake>(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_18, base.MemoryOwner ?? this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_18, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17007979 RID: 31097
		// (get) Token: 0x0602CDFA RID: 183802 RVA: 0x00AB2113 File Offset: 0x00AB0313
		// (set) Token: 0x0602CDFB RID: 183803 RVA: 0x00AB2127 File Offset: 0x00AB0327
		public unsafe TEnumAsByte<EBulletType> 子弹类型
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x1700797A RID: 31098
		// (get) Token: 0x0602CDFC RID: 183804 RVA: 0x00AB213C File Offset: 0x00AB033C
		// (set) Token: 0x0602CDFD RID: 183805 RVA: 0x00AB2150 File Offset: 0x00AB0350
		public unsafe TEnumAsByte<EBulletHitDirectionType> 受击角度判定类型
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataBase.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x0602CDFE RID: 183806 RVA: 0x00AB2165 File Offset: 0x00AB0365
		public SBulletDataBase()
		{
		}

		// Token: 0x0602CDFF RID: 183807 RVA: 0x00AB2170 File Offset: 0x00AB0370
		public SBulletDataBase(TEnumAsByte<EBulletShape> 子弹形状, [Nullable(1)] TSoftObjectPtr<UStaticMesh> 子弹模型, FVector 初始大小, FVector 初始位置, FVector 初始旋转, float 持续时间, int 命中个数, int 作用次数, bool 被极限闪避后销毁, FName 被击效果, float 作用间隔, TEnumAsByte<EBulletRelativeDir> 受击类型, int 执行效果ID, FRotator 子弹攻击方向, bool 技能结束是否销毁子弹, int 伤害类型, bool 是否可以触发极限闪避, bool 是否触发拼刀, [Nullable(1)] TSoftClassPtr<UMatineeCameraShake> 攻击者震屏, TEnumAsByte<EBulletType> 子弹类型, TEnumAsByte<EBulletHitDirectionType> 受击角度判定类型)
		{
			this.子弹形状 = 子弹形状;
			this.子弹模型 = 子弹模型;
			this.初始大小 = 初始大小;
			this.初始位置 = 初始位置;
			this.初始旋转 = 初始旋转;
			this.持续时间 = 持续时间;
			this.命中个数 = 命中个数;
			this.作用次数 = 作用次数;
			this.被极限闪避后销毁 = 被极限闪避后销毁;
			this.被击效果 = 被击效果;
			this.作用间隔 = 作用间隔;
			this.受击类型 = 受击类型;
			this.执行效果ID = 执行效果ID;
			this.子弹攻击方向 = 子弹攻击方向;
			this.技能结束是否销毁子弹 = 技能结束是否销毁子弹;
			this.伤害类型 = 伤害类型;
			this.是否可以触发极限闪避 = 是否可以触发极限闪避;
			this.是否触发拼刀 = 是否触发拼刀;
			this.攻击者震屏 = 攻击者震屏;
			this.子弹类型 = 子弹类型;
			this.受击角度判定类型 = 受击角度判定类型;
		}

		// Token: 0x0602CE00 RID: 183808 RVA: 0x00AB2228 File Offset: 0x00AB0428
		protected override IntPtr GetUStructPtr()
		{
			return SBulletDataBase.StaticStruct();
		}

		// Token: 0x0602CE01 RID: 183809 RVA: 0x00AB2234 File Offset: 0x00AB0434
		[NullableContext(2)]
		public SBulletDataBase(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CE02 RID: 183810 RVA: 0x00AB223E File Offset: 0x00AB043E
		public SBulletDataBase(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CE03 RID: 183811 RVA: 0x00AB2249 File Offset: 0x00AB0449
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBulletDataBase(Pointer, false, true);
		}

		// Token: 0x0602CE04 RID: 183812 RVA: 0x00AB2253 File Offset: 0x00AB0453
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBulletDataBase(Pointer, MemoryOwner);
		}

		// Token: 0x040192C3 RID: 103107
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SBulletDataBase.SBulletDataBase";

		// Token: 0x040192C4 RID: 103108
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040192C5 RID: 103109
		internal static int __PropertyOffset_0;

		// Token: 0x040192C6 RID: 103110
		internal static int __PropertyOffset_1;

		// Token: 0x040192C7 RID: 103111
		internal static int __PropertyOffset_2;

		// Token: 0x040192C8 RID: 103112
		internal static int __PropertyOffset_3;

		// Token: 0x040192C9 RID: 103113
		internal static int __PropertyOffset_4;

		// Token: 0x040192CA RID: 103114
		internal static int __PropertyOffset_5;

		// Token: 0x040192CB RID: 103115
		internal static int __PropertyOffset_6;

		// Token: 0x040192CC RID: 103116
		internal static int __PropertyOffset_7;

		// Token: 0x040192CD RID: 103117
		internal static int __PropertyOffset_8;

		// Token: 0x040192CE RID: 103118
		internal static int __PropertyOffset_9;

		// Token: 0x040192CF RID: 103119
		internal static int __PropertyOffset_10;

		// Token: 0x040192D0 RID: 103120
		internal static int __PropertyOffset_11;

		// Token: 0x040192D1 RID: 103121
		internal static int __PropertyOffset_12;

		// Token: 0x040192D2 RID: 103122
		internal static int __PropertyOffset_13;

		// Token: 0x040192D3 RID: 103123
		internal static int __PropertyOffset_14;

		// Token: 0x040192D4 RID: 103124
		internal static int __PropertyOffset_15;

		// Token: 0x040192D5 RID: 103125
		internal static int __PropertyOffset_16;

		// Token: 0x040192D6 RID: 103126
		internal static int __PropertyOffset_17;

		// Token: 0x040192D7 RID: 103127
		internal static int __PropertyOffset_18;

		// Token: 0x040192D8 RID: 103128
		internal static int __PropertyOffset_19;

		// Token: 0x040192D9 RID: 103129
		internal static int __PropertyOffset_20;
	}
}
