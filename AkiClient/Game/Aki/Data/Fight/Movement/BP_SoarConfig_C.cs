using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Fight.Movement
{
	// Token: 0x02003EDE RID: 16094
	[UnrealObjectPath("/Game/Aki/Data/Fight/Movement/BP_SoarConfig.BP_SoarConfig_C")]
	[UnrealStructLayout(248, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 241)]
	public class BP_SoarConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060280F5 RID: 164085 RVA: 0x00A0184B File Offset: 0x009FFA4B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SoarConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Fight/Movement/BP_SoarConfig.BP_SoarConfig_C");
			}
			return BP_SoarConfig_C._ClassPtr;
		}

		// Token: 0x060280F6 RID: 164086 RVA: 0x00A01870 File Offset: 0x009FFA70
		public BP_SoarConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_SoarConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060280F7 RID: 164087 RVA: 0x00A01898 File Offset: 0x009FFA98
		[NullableContext(1)]
		public BP_SoarConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SoarConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006047 RID: 24647
		// (get) Token: 0x060280F8 RID: 164088 RVA: 0x00A018CB File Offset: 0x009FFACB
		// (set) Token: 0x060280F9 RID: 164089 RVA: 0x00A018DB File Offset: 0x009FFADB
		public unsafe float 阻挡面角度极限最小值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17006048 RID: 24648
		// (get) Token: 0x060280FA RID: 164090 RVA: 0x00A018EC File Offset: 0x009FFAEC
		// (set) Token: 0x060280FB RID: 164091 RVA: 0x00A018FC File Offset: 0x009FFAFC
		public unsafe float 阻挡面角度极限最大值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17006049 RID: 24649
		// (get) Token: 0x060280FC RID: 164092 RVA: 0x00A0190D File Offset: 0x009FFB0D
		// (set) Token: 0x060280FD RID: 164093 RVA: 0x00A0191D File Offset: 0x009FFB1D
		public unsafe float 空气阻力面系数最小值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700604A RID: 24650
		// (get) Token: 0x060280FE RID: 164094 RVA: 0x00A0192E File Offset: 0x009FFB2E
		// (set) Token: 0x060280FF RID: 164095 RVA: 0x00A0193E File Offset: 0x009FFB3E
		public unsafe float 空气阻力面系数最大值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700604B RID: 24651
		// (get) Token: 0x06028100 RID: 164096 RVA: 0x00A0194F File Offset: 0x009FFB4F
		// (set) Token: 0x06028101 RID: 164097 RVA: 0x00A0195F File Offset: 0x009FFB5F
		public unsafe float 阻挡面最小值对应速度值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700604C RID: 24652
		// (get) Token: 0x06028102 RID: 164098 RVA: 0x00A01970 File Offset: 0x009FFB70
		// (set) Token: 0x06028103 RID: 164099 RVA: 0x00A01984 File Offset: 0x009FFB84
		public unsafe FVector 满抬升输入时平衡速度向量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700604D RID: 24653
		// (get) Token: 0x06028104 RID: 164100 RVA: 0x00A01999 File Offset: 0x009FFB99
		// (set) Token: 0x06028105 RID: 164101 RVA: 0x00A019A9 File Offset: 0x009FFBA9
		public unsafe float 满抬升输入判定阈值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700604E RID: 24654
		// (get) Token: 0x06028106 RID: 164102 RVA: 0x00A019BA File Offset: 0x009FFBBA
		// (set) Token: 0x06028107 RID: 164103 RVA: 0x00A019CA File Offset: 0x009FFBCA
		public unsafe float 平衡用最小加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700604F RID: 24655
		// (get) Token: 0x06028108 RID: 164104 RVA: 0x00A019DB File Offset: 0x009FFBDB
		// (set) Token: 0x06028109 RID: 164105 RVA: 0x00A019EB File Offset: 0x009FFBEB
		public unsafe float 平衡用最大加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17006050 RID: 24656
		// (get) Token: 0x0602810A RID: 164106 RVA: 0x00A019FC File Offset: 0x009FFBFC
		// (set) Token: 0x0602810B RID: 164107 RVA: 0x00A01A0C File Offset: 0x009FFC0C
		public unsafe float 平衡使用最大值对应速度差
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17006051 RID: 24657
		// (get) Token: 0x0602810C RID: 164108 RVA: 0x00A01A1D File Offset: 0x009FFC1D
		// (set) Token: 0x0602810D RID: 164109 RVA: 0x00A01A2D File Offset: 0x009FFC2D
		public unsafe float 满抬升输入平衡开启速度阈值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17006052 RID: 24658
		// (get) Token: 0x0602810E RID: 164110 RVA: 0x00A01A3E File Offset: 0x009FFC3E
		// (set) Token: 0x0602810F RID: 164111 RVA: 0x00A01A4E File Offset: 0x009FFC4E
		public unsafe float 非满抬升输入平衡速度值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17006053 RID: 24659
		// (get) Token: 0x06028110 RID: 164112 RVA: 0x00A01A5F File Offset: 0x009FFC5F
		// (set) Token: 0x06028111 RID: 164113 RVA: 0x00A01A6F File Offset: 0x009FFC6F
		public unsafe float 非满抬升输入平衡开启速度阈值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17006054 RID: 24660
		// (get) Token: 0x06028112 RID: 164114 RVA: 0x00A01A80 File Offset: 0x009FFC80
		// (set) Token: 0x06028113 RID: 164115 RVA: 0x00A01A90 File Offset: 0x009FFC90
		public unsafe float 阻挡面转速第一段线性
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17006055 RID: 24661
		// (get) Token: 0x06028114 RID: 164116 RVA: 0x00A01AA1 File Offset: 0x009FFCA1
		// (set) Token: 0x06028115 RID: 164117 RVA: 0x00A01AB1 File Offset: 0x009FFCB1
		public unsafe float 阻挡面转速第二段比例
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17006056 RID: 24662
		// (get) Token: 0x06028116 RID: 164118 RVA: 0x00A01AC2 File Offset: 0x009FFCC2
		// (set) Token: 0x06028117 RID: 164119 RVA: 0x00A01AD2 File Offset: 0x009FFCD2
		public unsafe float 面向转速第一段线性
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17006057 RID: 24663
		// (get) Token: 0x06028118 RID: 164120 RVA: 0x00A01AE3 File Offset: 0x009FFCE3
		// (set) Token: 0x06028119 RID: 164121 RVA: 0x00A01AF3 File Offset: 0x009FFCF3
		public unsafe float 面向转速第二段比例
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17006058 RID: 24664
		// (get) Token: 0x0602811A RID: 164122 RVA: 0x00A01B04 File Offset: 0x009FFD04
		// (set) Token: 0x0602811B RID: 164123 RVA: 0x00A01B14 File Offset: 0x009FFD14
		public unsafe float 阻挡面最大值对应速度值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17006059 RID: 24665
		// (get) Token: 0x0602811C RID: 164124 RVA: 0x00A01B25 File Offset: 0x009FFD25
		// (set) Token: 0x0602811D RID: 164125 RVA: 0x00A01B35 File Offset: 0x009FFD35
		public unsafe float 阻挡面最小角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700605A RID: 24666
		// (get) Token: 0x0602811E RID: 164126 RVA: 0x00A01B46 File Offset: 0x009FFD46
		// (set) Token: 0x0602811F RID: 164127 RVA: 0x00A01B56 File Offset: 0x009FFD56
		public unsafe float 阻挡面最大角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x1700605B RID: 24667
		// (get) Token: 0x06028120 RID: 164128 RVA: 0x00A01B67 File Offset: 0x009FFD67
		// (set) Token: 0x06028121 RID: 164129 RVA: 0x00A01B77 File Offset: 0x009FFD77
		public unsafe float 无输入时阻挡面转速
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x1700605C RID: 24668
		// (get) Token: 0x06028122 RID: 164130 RVA: 0x00A01B88 File Offset: 0x009FFD88
		// (set) Token: 0x06028123 RID: 164131 RVA: 0x00A01B98 File Offset: 0x009FFD98
		public unsafe float 空气阻力
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x1700605D RID: 24669
		// (get) Token: 0x06028124 RID: 164132 RVA: 0x00A01BA9 File Offset: 0x009FFDA9
		// (set) Token: 0x06028125 RID: 164133 RVA: 0x00A01BB9 File Offset: 0x009FFDB9
		public unsafe float 最大速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x1700605E RID: 24670
		// (get) Token: 0x06028126 RID: 164134 RVA: 0x00A01BCA File Offset: 0x009FFDCA
		// (set) Token: 0x06028127 RID: 164135 RVA: 0x00A01BDA File Offset: 0x009FFDDA
		public unsafe float Boost阻挡面转速第一段线性
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x1700605F RID: 24671
		// (get) Token: 0x06028128 RID: 164136 RVA: 0x00A01BEB File Offset: 0x009FFDEB
		// (set) Token: 0x06028129 RID: 164137 RVA: 0x00A01BFB File Offset: 0x009FFDFB
		public unsafe float Boost阻挡面转速第二段比例
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17006060 RID: 24672
		// (get) Token: 0x0602812A RID: 164138 RVA: 0x00A01C0C File Offset: 0x009FFE0C
		// (set) Token: 0x0602812B RID: 164139 RVA: 0x00A01C1C File Offset: 0x009FFE1C
		public unsafe float Boost加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17006061 RID: 24673
		// (get) Token: 0x0602812C RID: 164140 RVA: 0x00A01C2D File Offset: 0x009FFE2D
		// (set) Token: 0x0602812D RID: 164141 RVA: 0x00A01C3D File Offset: 0x009FFE3D
		public unsafe float 重力加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17006062 RID: 24674
		// (get) Token: 0x0602812E RID: 164142 RVA: 0x00A01C4E File Offset: 0x009FFE4E
		// (set) Token: 0x0602812F RID: 164143 RVA: 0x00A01C5E File Offset: 0x009FFE5E
		public unsafe float 撞墙结束时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17006063 RID: 24675
		// (get) Token: 0x06028130 RID: 164144 RVA: 0x00A01C6F File Offset: 0x009FFE6F
		// (set) Token: 0x06028131 RID: 164145 RVA: 0x00A01C7F File Offset: 0x009FFE7F
		public unsafe float 风道最小速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17006064 RID: 24676
		// (get) Token: 0x06028132 RID: 164146 RVA: 0x00A01C90 File Offset: 0x009FFE90
		// (set) Token: 0x06028133 RID: 164147 RVA: 0x00A01CA0 File Offset: 0x009FFEA0
		public unsafe float 风道最大加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17006065 RID: 24677
		// (get) Token: 0x06028134 RID: 164148 RVA: 0x00A01CB1 File Offset: 0x009FFEB1
		// (set) Token: 0x06028135 RID: 164149 RVA: 0x00A01CC1 File Offset: 0x009FFEC1
		public unsafe float 风道输入对应偏转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17006066 RID: 24678
		// (get) Token: 0x06028136 RID: 164150 RVA: 0x00A01CD2 File Offset: 0x009FFED2
		// (set) Token: 0x06028137 RID: 164151 RVA: 0x00A01CE2 File Offset: 0x009FFEE2
		public unsafe float 风道中线拉回最小速对应距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17006067 RID: 24679
		// (get) Token: 0x06028138 RID: 164152 RVA: 0x00A01CF3 File Offset: 0x009FFEF3
		// (set) Token: 0x06028139 RID: 164153 RVA: 0x00A01D03 File Offset: 0x009FFF03
		public unsafe float 风道中线拉回最大速对应距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17006068 RID: 24680
		// (get) Token: 0x0602813A RID: 164154 RVA: 0x00A01D14 File Offset: 0x009FFF14
		// (set) Token: 0x0602813B RID: 164155 RVA: 0x00A01D24 File Offset: 0x009FFF24
		public unsafe float 风道中线拉回最小速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17006069 RID: 24681
		// (get) Token: 0x0602813C RID: 164156 RVA: 0x00A01D35 File Offset: 0x009FFF35
		// (set) Token: 0x0602813D RID: 164157 RVA: 0x00A01D45 File Offset: 0x009FFF45
		public unsafe float 风道中线拉回最大速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x1700606A RID: 24682
		// (get) Token: 0x0602813E RID: 164158 RVA: 0x00A01D56 File Offset: 0x009FFF56
		// (set) Token: 0x0602813F RID: 164159 RVA: 0x00A01D66 File Offset: 0x009FFF66
		public unsafe float 风道无输入面向修正速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x1700606B RID: 24683
		// (get) Token: 0x06028140 RID: 164160 RVA: 0x00A01D77 File Offset: 0x009FFF77
		// (set) Token: 0x06028141 RID: 164161 RVA: 0x00A01D87 File Offset: 0x009FFF87
		public unsafe float 风道有输入面向修正速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x1700606C RID: 24684
		// (get) Token: 0x06028142 RID: 164162 RVA: 0x00A01D98 File Offset: 0x009FFF98
		// (set) Token: 0x06028143 RID: 164163 RVA: 0x00A01DA8 File Offset: 0x009FFFA8
		public unsafe float 风道转向第二段比例
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x1700606D RID: 24685
		// (get) Token: 0x06028144 RID: 164164 RVA: 0x00A01DB9 File Offset: 0x009FFFB9
		// (set) Token: 0x06028145 RID: 164165 RVA: 0x00A01DC9 File Offset: 0x009FFFC9
		public unsafe bool DebugDraw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_38) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SoarConfig_C.__PropertyOffset_38) = (value ? 1 : 0);
			}
		}

		// Token: 0x06028146 RID: 164166 RVA: 0x00A01DDA File Offset: 0x009FFFDA
		protected BP_SoarConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401507A RID: 86138
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/Fight/Movement/BP_SoarConfig.BP_SoarConfig_C";

		// Token: 0x0401507B RID: 86139
		private static IntPtr _ClassPtr;

		// Token: 0x0401507C RID: 86140
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401507D RID: 86141
		internal static int __PropertyOffset_0;

		// Token: 0x0401507E RID: 86142
		internal static int __PropertyOffset_1;

		// Token: 0x0401507F RID: 86143
		internal static int __PropertyOffset_2;

		// Token: 0x04015080 RID: 86144
		internal static int __PropertyOffset_3;

		// Token: 0x04015081 RID: 86145
		internal static int __PropertyOffset_4;

		// Token: 0x04015082 RID: 86146
		internal static int __PropertyOffset_5;

		// Token: 0x04015083 RID: 86147
		internal static int __PropertyOffset_6;

		// Token: 0x04015084 RID: 86148
		internal static int __PropertyOffset_7;

		// Token: 0x04015085 RID: 86149
		internal static int __PropertyOffset_8;

		// Token: 0x04015086 RID: 86150
		internal static int __PropertyOffset_9;

		// Token: 0x04015087 RID: 86151
		internal static int __PropertyOffset_10;

		// Token: 0x04015088 RID: 86152
		internal static int __PropertyOffset_11;

		// Token: 0x04015089 RID: 86153
		internal static int __PropertyOffset_12;

		// Token: 0x0401508A RID: 86154
		internal static int __PropertyOffset_13;

		// Token: 0x0401508B RID: 86155
		internal static int __PropertyOffset_14;

		// Token: 0x0401508C RID: 86156
		internal static int __PropertyOffset_15;

		// Token: 0x0401508D RID: 86157
		internal static int __PropertyOffset_16;

		// Token: 0x0401508E RID: 86158
		internal static int __PropertyOffset_17;

		// Token: 0x0401508F RID: 86159
		internal static int __PropertyOffset_18;

		// Token: 0x04015090 RID: 86160
		internal static int __PropertyOffset_19;

		// Token: 0x04015091 RID: 86161
		internal static int __PropertyOffset_20;

		// Token: 0x04015092 RID: 86162
		internal static int __PropertyOffset_21;

		// Token: 0x04015093 RID: 86163
		internal static int __PropertyOffset_22;

		// Token: 0x04015094 RID: 86164
		internal static int __PropertyOffset_23;

		// Token: 0x04015095 RID: 86165
		internal static int __PropertyOffset_24;

		// Token: 0x04015096 RID: 86166
		internal static int __PropertyOffset_25;

		// Token: 0x04015097 RID: 86167
		internal static int __PropertyOffset_26;

		// Token: 0x04015098 RID: 86168
		internal static int __PropertyOffset_27;

		// Token: 0x04015099 RID: 86169
		internal static int __PropertyOffset_28;

		// Token: 0x0401509A RID: 86170
		internal static int __PropertyOffset_29;

		// Token: 0x0401509B RID: 86171
		internal static int __PropertyOffset_30;

		// Token: 0x0401509C RID: 86172
		internal static int __PropertyOffset_31;

		// Token: 0x0401509D RID: 86173
		internal static int __PropertyOffset_32;

		// Token: 0x0401509E RID: 86174
		internal static int __PropertyOffset_33;

		// Token: 0x0401509F RID: 86175
		internal static int __PropertyOffset_34;

		// Token: 0x040150A0 RID: 86176
		internal static int __PropertyOffset_35;

		// Token: 0x040150A1 RID: 86177
		internal static int __PropertyOffset_36;

		// Token: 0x040150A2 RID: 86178
		internal static int __PropertyOffset_37;

		// Token: 0x040150A3 RID: 86179
		internal static int __PropertyOffset_38;
	}
}
