using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Fight.Struct
{
	// Token: 0x02003EDB RID: 16091
	[UnrealObjectPath("/Game/Aki/Data/Fight/Struct/SReBulletDataBase_ExcelTest.SReBulletDataBase_ExcelTest")]
	[UnrealStructLayout(488, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 482)]
	public class SReBulletDataBase_ExcelTest : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028067 RID: 163943 RVA: 0x00A00911 File Offset: 0x009FEB11
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SReBulletDataBase_ExcelTest._ScriptStructPtr != 0) ? SReBulletDataBase_ExcelTest._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/Struct/SReBulletDataBase_ExcelTest.SReBulletDataBase_ExcelTest", ref SReBulletDataBase_ExcelTest._ScriptStructPtr);
		}

		// Token: 0x1700600C RID: 24588
		// (get) Token: 0x06028068 RID: 163944 RVA: 0x00A00935 File Offset: 0x009FEB35
		// (set) Token: 0x06028069 RID: 163945 RVA: 0x00A00949 File Offset: 0x009FEB49
		public unsafe TEnumAsByte<AkiClient.Game.Aki.Character.BaseCharacter.EBulletShape> 子弹形状
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x1700600D RID: 24589
		// (get) Token: 0x0602806A RID: 163946 RVA: 0x00A0095E File Offset: 0x009FEB5E
		// (set) Token: 0x0602806B RID: 163947 RVA: 0x00A00972 File Offset: 0x009FEB72
		public unsafe FVector 初始大小
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700600E RID: 24590
		// (get) Token: 0x0602806C RID: 163948 RVA: 0x00A00988 File Offset: 0x009FEB88
		// (set) Token: 0x0602806D RID: 163949 RVA: 0x00A009CB File Offset: 0x009FEBCB
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<EBulletBaseSpecificParam>, string> 特殊参数
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EBulletBaseSpecificParam>, string> result;
				if ((result = this._特殊参数) == null)
				{
					result = (this._特殊参数 = new TMap<TEnumAsByte<EBulletBaseSpecificParam>, string>(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.特殊参数.CopyAssign(value);
			}
		}

		// Token: 0x1700600F RID: 24591
		// (get) Token: 0x0602806E RID: 163950 RVA: 0x00A009D9 File Offset: 0x009FEBD9
		// (set) Token: 0x0602806F RID: 163951 RVA: 0x00A009ED File Offset: 0x009FEBED
		public unsafe TEnumAsByte<EPositionStandard> 出生位置基准
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17006010 RID: 24592
		// (get) Token: 0x06028070 RID: 163952 RVA: 0x00A00A02 File Offset: 0x009FEC02
		// (set) Token: 0x06028071 RID: 163953 RVA: 0x00A00A16 File Offset: 0x009FEC16
		[Nullable(1)]
		public unsafe string 攻击者黑板Key值
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_4)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_4)), value);
			}
		}

		// Token: 0x17006011 RID: 24593
		// (get) Token: 0x06028072 RID: 163954 RVA: 0x00A00A2B File Offset: 0x009FEC2B
		// (set) Token: 0x06028073 RID: 163955 RVA: 0x00A00A3F File Offset: 0x009FEC3F
		public unsafe FVector 出生位置偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17006012 RID: 24594
		// (get) Token: 0x06028074 RID: 163956 RVA: 0x00A00A54 File Offset: 0x009FEC54
		// (set) Token: 0x06028075 RID: 163957 RVA: 0x00A00A68 File Offset: 0x009FEC68
		public unsafe FVector 中心位置偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17006013 RID: 24595
		// (get) Token: 0x06028076 RID: 163958 RVA: 0x00A00A7D File Offset: 0x009FEC7D
		// (set) Token: 0x06028077 RID: 163959 RVA: 0x00A00A91 File Offset: 0x009FEC91
		public unsafe FVector 出生位置随机
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17006014 RID: 24596
		// (get) Token: 0x06028078 RID: 163960 RVA: 0x00A00AA6 File Offset: 0x009FECA6
		// (set) Token: 0x06028079 RID: 163961 RVA: 0x00A00ABA File Offset: 0x009FECBA
		public unsafe FRotator 初始旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17006015 RID: 24597
		// (get) Token: 0x0602807A RID: 163962 RVA: 0x00A00ACF File Offset: 0x009FECCF
		// (set) Token: 0x0602807B RID: 163963 RVA: 0x00A00AE3 File Offset: 0x009FECE3
		public unsafe FVector 限制生成距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17006016 RID: 24598
		// (get) Token: 0x0602807C RID: 163964 RVA: 0x00A00AF8 File Offset: 0x009FECF8
		// (set) Token: 0x0602807D RID: 163965 RVA: 0x00A00B08 File Offset: 0x009FED08
		public unsafe float 持续时间字段改名
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17006017 RID: 24599
		// (get) Token: 0x0602807E RID: 163966 RVA: 0x00A00B19 File Offset: 0x009FED19
		// (set) Token: 0x0602807F RID: 163967 RVA: 0x00A00B29 File Offset: 0x009FED29
		public unsafe float 碰撞判定时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17006018 RID: 24600
		// (get) Token: 0x06028080 RID: 163968 RVA: 0x00A00B3A File Offset: 0x009FED3A
		// (set) Token: 0x06028081 RID: 163969 RVA: 0x00A00B4A File Offset: 0x009FED4A
		public unsafe float 碰撞判定延迟
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17006019 RID: 24601
		// (get) Token: 0x06028082 RID: 163970 RVA: 0x00A00B5B File Offset: 0x009FED5B
		// (set) Token: 0x06028083 RID: 163971 RVA: 0x00A00B6F File Offset: 0x009FED6F
		public unsafe TEnumAsByte<EHitType> 命中判定类型
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x1700601A RID: 24602
		// (get) Token: 0x06028084 RID: 163972 RVA: 0x00A00B84 File Offset: 0x009FED84
		// (set) Token: 0x06028085 RID: 163973 RVA: 0x00A00BA3 File Offset: 0x009FEDA3
		[Nullable(1)]
		public TSoftObjectPtr<BulletCampType_C> 命中判定类型预设
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<BulletCampType_C>(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_14, base.MemoryOwner ?? this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_14, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x1700601B RID: 24603
		// (get) Token: 0x06028086 RID: 163974 RVA: 0x00A00BC8 File Offset: 0x009FEDC8
		// (set) Token: 0x06028087 RID: 163975 RVA: 0x00A00BDC File Offset: 0x009FEDDC
		public unsafe FGameplayTag 命中判定Tag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700601C RID: 24604
		// (get) Token: 0x06028088 RID: 163976 RVA: 0x00A00BF1 File Offset: 0x009FEDF1
		// (set) Token: 0x06028089 RID: 163977 RVA: 0x00A00C05 File Offset: 0x009FEE05
		public unsafe FGameplayTag 禁止命中Tag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x1700601D RID: 24605
		// (get) Token: 0x0602808A RID: 163978 RVA: 0x00A00C1A File Offset: 0x009FEE1A
		// (set) Token: 0x0602808B RID: 163979 RVA: 0x00A00C2A File Offset: 0x009FEE2A
		public unsafe int 命中个数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x1700601E RID: 24606
		// (get) Token: 0x0602808C RID: 163980 RVA: 0x00A00C3B File Offset: 0x009FEE3B
		// (set) Token: 0x0602808D RID: 163981 RVA: 0x00A00C4B File Offset: 0x009FEE4B
		public unsafe int 每个单位总作用次数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700601F RID: 24607
		// (get) Token: 0x0602808E RID: 163982 RVA: 0x00A00C5C File Offset: 0x009FEE5C
		// (set) Token: 0x0602808F RID: 163983 RVA: 0x00A00C6C File Offset: 0x009FEE6C
		public unsafe int 总作用次数限制
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17006020 RID: 24608
		// (get) Token: 0x06028090 RID: 163984 RVA: 0x00A00C7D File Offset: 0x009FEE7D
		// (set) Token: 0x06028091 RID: 163985 RVA: 0x00A00C8D File Offset: 0x009FEE8D
		public unsafe float 作用间隔
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17006021 RID: 24609
		// (get) Token: 0x06028092 RID: 163986 RVA: 0x00A00C9E File Offset: 0x009FEE9E
		// (set) Token: 0x06028093 RID: 163987 RVA: 0x00A00CAE File Offset: 0x009FEEAE
		public unsafe bool 作用间隔基于个体
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006022 RID: 24610
		// (get) Token: 0x06028094 RID: 163988 RVA: 0x00A00CBF File Offset: 0x009FEEBF
		// (set) Token: 0x06028095 RID: 163989 RVA: 0x00A00CCF File Offset: 0x009FEECF
		public unsafe bool 共享父子弹次数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006023 RID: 24611
		// (get) Token: 0x06028096 RID: 163990 RVA: 0x00A00CE0 File Offset: 0x009FEEE0
		// (set) Token: 0x06028097 RID: 163991 RVA: 0x00A00CF4 File Offset: 0x009FEEF4
		public unsafe FName 被击效果
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17006024 RID: 24612
		// (get) Token: 0x06028098 RID: 163992 RVA: 0x00A00D09 File Offset: 0x009FEF09
		// (set) Token: 0x06028099 RID: 163993 RVA: 0x00A00D1D File Offset: 0x009FEF1D
		public unsafe FName 弱点被击效果
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17006025 RID: 24613
		// (get) Token: 0x0602809A RID: 163994 RVA: 0x00A00D32 File Offset: 0x009FEF32
		// (set) Token: 0x0602809B RID: 163995 RVA: 0x00A00D46 File Offset: 0x009FEF46
		public unsafe TEnumAsByte<AkiClient.Game.Aki.Character.BaseCharacter.EBulletRelativeDir> 子弹受击方向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17006026 RID: 24614
		// (get) Token: 0x0602809C RID: 163996 RVA: 0x00A00D5B File Offset: 0x009FEF5B
		// (set) Token: 0x0602809D RID: 163997 RVA: 0x00A00D6B File Offset: 0x009FEF6B
		public unsafe long 伤害ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17006027 RID: 24615
		// (get) Token: 0x0602809E RID: 163998 RVA: 0x00A00D7C File Offset: 0x009FEF7C
		// (set) Token: 0x0602809F RID: 163999 RVA: 0x00A00D90 File Offset: 0x009FEF90
		public unsafe FRotator 子弹攻击方向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17006028 RID: 24616
		// (get) Token: 0x060280A0 RID: 164000 RVA: 0x00A00DA5 File Offset: 0x009FEFA5
		// (set) Token: 0x060280A1 RID: 164001 RVA: 0x00A00DB5 File Offset: 0x009FEFB5
		public unsafe bool 技能结束是否销毁子弹
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006029 RID: 24617
		// (get) Token: 0x060280A2 RID: 164002 RVA: 0x00A00DC8 File Offset: 0x009FEFC8
		// (set) Token: 0x060280A3 RID: 164003 RVA: 0x00A00E0B File Offset: 0x009FF00B
		[Nullable(1)]
		public FGameplayTagContainer 子弹允许生成Tag
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._子弹允许生成Tag) == null)
				{
					result = (this._子弹允许生成Tag = new FGameplayTagContainer(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_29, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_29, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700602A RID: 24618
		// (get) Token: 0x060280A4 RID: 164004 RVA: 0x00A00E2C File Offset: 0x009FF02C
		// (set) Token: 0x060280A5 RID: 164005 RVA: 0x00A00E6F File Offset: 0x009FF06F
		[Nullable(1)]
		public FGameplayTagContainer 子弹禁止生成Tag
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._子弹禁止生成Tag) == null)
				{
					result = (this._子弹禁止生成Tag = new FGameplayTagContainer(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_30, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_30, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700602B RID: 24619
		// (get) Token: 0x060280A6 RID: 164006 RVA: 0x00A00E90 File Offset: 0x009FF090
		// (set) Token: 0x060280A7 RID: 164007 RVA: 0x00A00EA0 File Offset: 0x009FF0A0
		public unsafe bool 是否持续碰撞
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_31) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_31) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700602C RID: 24620
		// (get) Token: 0x060280A8 RID: 164008 RVA: 0x00A00EB1 File Offset: 0x009FF0B1
		// (set) Token: 0x060280A9 RID: 164009 RVA: 0x00A00EC1 File Offset: 0x009FF0C1
		public unsafe bool 是否贴地子弹
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_32) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_32) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700602D RID: 24621
		// (get) Token: 0x060280AA RID: 164010 RVA: 0x00A00ED2 File Offset: 0x009FF0D2
		// (set) Token: 0x060280AB RID: 164011 RVA: 0x00A00EE2 File Offset: 0x009FF0E2
		public unsafe bool 不适配坡度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_33) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_33) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700602E RID: 24622
		// (get) Token: 0x060280AC RID: 164012 RVA: 0x00A00EF3 File Offset: 0x009FF0F3
		// (set) Token: 0x060280AD RID: 164013 RVA: 0x00A00F03 File Offset: 0x009FF103
		public unsafe float 贴地探测距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x1700602F RID: 24623
		// (get) Token: 0x060280AE RID: 164014 RVA: 0x00A00F14 File Offset: 0x009FF114
		// (set) Token: 0x060280AF RID: 164015 RVA: 0x00A00F28 File Offset: 0x009FF128
		public unsafe TEnumAsByte<AkiClient.Game.Aki.Core.Fight.EBulletSyncType> 网络同步类型
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x17006030 RID: 24624
		// (get) Token: 0x060280B0 RID: 164016 RVA: 0x00A00F3D File Offset: 0x009FF13D
		// (set) Token: 0x060280B1 RID: 164017 RVA: 0x00A00F51 File Offset: 0x009FF151
		public unsafe FGameplayTag 子弹标签
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17006031 RID: 24625
		// (get) Token: 0x060280B2 RID: 164018 RVA: 0x00A00F66 File Offset: 0x009FF166
		// (set) Token: 0x060280B3 RID: 164019 RVA: 0x00A00F76 File Offset: 0x009FF176
		public unsafe bool 是否响应材质受击音效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_37) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_37) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006032 RID: 24626
		// (get) Token: 0x060280B4 RID: 164020 RVA: 0x00A00F88 File Offset: 0x009FF188
		// (set) Token: 0x060280B5 RID: 164021 RVA: 0x00A00FCB File Offset: 0x009FF1CB
		[Nullable(1)]
		public SReBullDataBase_SubStructTest 新结构体
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				SReBullDataBase_SubStructTest result;
				if ((result = this._新结构体) == null)
				{
					result = (this._新结构体 = new SReBullDataBase_SubStructTest(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_38, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SReBullDataBase_SubStructTest.StaticStruct(), base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_38, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006033 RID: 24627
		// (get) Token: 0x060280B6 RID: 164022 RVA: 0x00A00FEC File Offset: 0x009FF1EC
		// (set) Token: 0x060280B7 RID: 164023 RVA: 0x00A00FFC File Offset: 0x009FF1FC
		public unsafe bool Debug显示子弹进度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_39) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_39) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006034 RID: 24628
		// (get) Token: 0x060280B8 RID: 164024 RVA: 0x00A0100D File Offset: 0x009FF20D
		// (set) Token: 0x060280B9 RID: 164025 RVA: 0x00A0101D File Offset: 0x009FF21D
		public unsafe bool 再新增一个布尔
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_40) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase_ExcelTest.__PropertyOffset_40) = (value ? 1 : 0);
			}
		}

		// Token: 0x060280BA RID: 164026 RVA: 0x00A0102E File Offset: 0x009FF22E
		public SReBulletDataBase_ExcelTest()
		{
		}

		// Token: 0x060280BB RID: 164027 RVA: 0x00A01038 File Offset: 0x009FF238
		public SReBulletDataBase_ExcelTest(TEnumAsByte<AkiClient.Game.Aki.Character.BaseCharacter.EBulletShape> 子弹形状, FVector 初始大小, [Nullable(new byte[]
		{
			1,
			0,
			1
		})] TMap<TEnumAsByte<EBulletBaseSpecificParam>, string> 特殊参数, TEnumAsByte<EPositionStandard> 出生位置基准, [Nullable(1)] string 攻击者黑板Key值, FVector 出生位置偏移, FVector 中心位置偏移, FVector 出生位置随机, FRotator 初始旋转, FVector 限制生成距离, float 持续时间字段改名, float 碰撞判定时长, float 碰撞判定延迟, TEnumAsByte<EHitType> 命中判定类型, [Nullable(1)] TSoftObjectPtr<BulletCampType_C> 命中判定类型预设, FGameplayTag 命中判定Tag, FGameplayTag 禁止命中Tag, int 命中个数, int 每个单位总作用次数, int 总作用次数限制, float 作用间隔, bool 作用间隔基于个体, bool 共享父子弹次数, FName 被击效果, FName 弱点被击效果, TEnumAsByte<AkiClient.Game.Aki.Character.BaseCharacter.EBulletRelativeDir> 子弹受击方向, long 伤害ID, FRotator 子弹攻击方向, bool 技能结束是否销毁子弹, [Nullable(1)] FGameplayTagContainer 子弹允许生成Tag, [Nullable(1)] FGameplayTagContainer 子弹禁止生成Tag, bool 是否持续碰撞, bool 是否贴地子弹, bool 不适配坡度, float 贴地探测距离, TEnumAsByte<AkiClient.Game.Aki.Core.Fight.EBulletSyncType> 网络同步类型, FGameplayTag 子弹标签, bool 是否响应材质受击音效, [Nullable(1)] SReBullDataBase_SubStructTest 新结构体, bool Debug显示子弹进度, bool 再新增一个布尔)
		{
			this.子弹形状 = 子弹形状;
			this.初始大小 = 初始大小;
			this.特殊参数 = 特殊参数;
			this.出生位置基准 = 出生位置基准;
			this.攻击者黑板Key值 = 攻击者黑板Key值;
			this.出生位置偏移 = 出生位置偏移;
			this.中心位置偏移 = 中心位置偏移;
			this.出生位置随机 = 出生位置随机;
			this.初始旋转 = 初始旋转;
			this.限制生成距离 = 限制生成距离;
			this.持续时间字段改名 = 持续时间字段改名;
			this.碰撞判定时长 = 碰撞判定时长;
			this.碰撞判定延迟 = 碰撞判定延迟;
			this.命中判定类型 = 命中判定类型;
			this.命中判定类型预设 = 命中判定类型预设;
			this.命中判定Tag = 命中判定Tag;
			this.禁止命中Tag = 禁止命中Tag;
			this.命中个数 = 命中个数;
			this.每个单位总作用次数 = 每个单位总作用次数;
			this.总作用次数限制 = 总作用次数限制;
			this.作用间隔 = 作用间隔;
			this.作用间隔基于个体 = 作用间隔基于个体;
			this.共享父子弹次数 = 共享父子弹次数;
			this.被击效果 = 被击效果;
			this.弱点被击效果 = 弱点被击效果;
			this.子弹受击方向 = 子弹受击方向;
			this.伤害ID = 伤害ID;
			this.子弹攻击方向 = 子弹攻击方向;
			this.技能结束是否销毁子弹 = 技能结束是否销毁子弹;
			this.子弹允许生成Tag = 子弹允许生成Tag;
			this.子弹禁止生成Tag = 子弹禁止生成Tag;
			this.是否持续碰撞 = 是否持续碰撞;
			this.是否贴地子弹 = 是否贴地子弹;
			this.不适配坡度 = 不适配坡度;
			this.贴地探测距离 = 贴地探测距离;
			this.网络同步类型 = 网络同步类型;
			this.子弹标签 = 子弹标签;
			this.是否响应材质受击音效 = 是否响应材质受击音效;
			this.新结构体 = 新结构体;
			this.Debug显示子弹进度 = Debug显示子弹进度;
			this.再新增一个布尔 = 再新增一个布尔;
		}

		// Token: 0x060280BC RID: 164028 RVA: 0x00A01190 File Offset: 0x009FF390
		protected override IntPtr GetUStructPtr()
		{
			return SReBulletDataBase_ExcelTest.StaticStruct();
		}

		// Token: 0x060280BD RID: 164029 RVA: 0x00A0119C File Offset: 0x009FF39C
		[NullableContext(2)]
		public SReBulletDataBase_ExcelTest(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060280BE RID: 164030 RVA: 0x00A011A6 File Offset: 0x009FF3A6
		public SReBulletDataBase_ExcelTest(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060280BF RID: 164031 RVA: 0x00A011B1 File Offset: 0x009FF3B1
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SReBulletDataBase_ExcelTest(Pointer, false, true);
		}

		// Token: 0x060280C0 RID: 164032 RVA: 0x00A011BB File Offset: 0x009FF3BB
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SReBulletDataBase_ExcelTest(Pointer, MemoryOwner);
		}

		// Token: 0x0401502C RID: 86060
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/Fight/Struct/SReBulletDataBase_ExcelTest.SReBulletDataBase_ExcelTest";

		// Token: 0x0401502D RID: 86061
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401502E RID: 86062
		internal static int __PropertyOffset_0;

		// Token: 0x0401502F RID: 86063
		internal static int __PropertyOffset_1;

		// Token: 0x04015030 RID: 86064
		internal static int __PropertyOffset_2;

		// Token: 0x04015031 RID: 86065
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EBulletBaseSpecificParam>, string> _特殊参数;

		// Token: 0x04015032 RID: 86066
		internal static int __PropertyOffset_3;

		// Token: 0x04015033 RID: 86067
		internal static int __PropertyOffset_4;

		// Token: 0x04015034 RID: 86068
		internal static int __PropertyOffset_5;

		// Token: 0x04015035 RID: 86069
		internal static int __PropertyOffset_6;

		// Token: 0x04015036 RID: 86070
		internal static int __PropertyOffset_7;

		// Token: 0x04015037 RID: 86071
		internal static int __PropertyOffset_8;

		// Token: 0x04015038 RID: 86072
		internal static int __PropertyOffset_9;

		// Token: 0x04015039 RID: 86073
		internal static int __PropertyOffset_10;

		// Token: 0x0401503A RID: 86074
		internal static int __PropertyOffset_11;

		// Token: 0x0401503B RID: 86075
		internal static int __PropertyOffset_12;

		// Token: 0x0401503C RID: 86076
		internal static int __PropertyOffset_13;

		// Token: 0x0401503D RID: 86077
		internal static int __PropertyOffset_14;

		// Token: 0x0401503E RID: 86078
		internal static int __PropertyOffset_15;

		// Token: 0x0401503F RID: 86079
		internal static int __PropertyOffset_16;

		// Token: 0x04015040 RID: 86080
		internal static int __PropertyOffset_17;

		// Token: 0x04015041 RID: 86081
		internal static int __PropertyOffset_18;

		// Token: 0x04015042 RID: 86082
		internal static int __PropertyOffset_19;

		// Token: 0x04015043 RID: 86083
		internal static int __PropertyOffset_20;

		// Token: 0x04015044 RID: 86084
		internal static int __PropertyOffset_21;

		// Token: 0x04015045 RID: 86085
		internal static int __PropertyOffset_22;

		// Token: 0x04015046 RID: 86086
		internal static int __PropertyOffset_23;

		// Token: 0x04015047 RID: 86087
		internal static int __PropertyOffset_24;

		// Token: 0x04015048 RID: 86088
		internal static int __PropertyOffset_25;

		// Token: 0x04015049 RID: 86089
		internal static int __PropertyOffset_26;

		// Token: 0x0401504A RID: 86090
		internal static int __PropertyOffset_27;

		// Token: 0x0401504B RID: 86091
		internal static int __PropertyOffset_28;

		// Token: 0x0401504C RID: 86092
		internal static int __PropertyOffset_29;

		// Token: 0x0401504D RID: 86093
		[Nullable(2)]
		private FGameplayTagContainer _子弹允许生成Tag;

		// Token: 0x0401504E RID: 86094
		internal static int __PropertyOffset_30;

		// Token: 0x0401504F RID: 86095
		[Nullable(2)]
		private FGameplayTagContainer _子弹禁止生成Tag;

		// Token: 0x04015050 RID: 86096
		internal static int __PropertyOffset_31;

		// Token: 0x04015051 RID: 86097
		internal static int __PropertyOffset_32;

		// Token: 0x04015052 RID: 86098
		internal static int __PropertyOffset_33;

		// Token: 0x04015053 RID: 86099
		internal static int __PropertyOffset_34;

		// Token: 0x04015054 RID: 86100
		internal static int __PropertyOffset_35;

		// Token: 0x04015055 RID: 86101
		internal static int __PropertyOffset_36;

		// Token: 0x04015056 RID: 86102
		internal static int __PropertyOffset_37;

		// Token: 0x04015057 RID: 86103
		internal static int __PropertyOffset_38;

		// Token: 0x04015058 RID: 86104
		[Nullable(2)]
		private SReBullDataBase_SubStructTest _新结构体;

		// Token: 0x04015059 RID: 86105
		internal static int __PropertyOffset_39;

		// Token: 0x0401505A RID: 86106
		internal static int __PropertyOffset_40;
	}
}
