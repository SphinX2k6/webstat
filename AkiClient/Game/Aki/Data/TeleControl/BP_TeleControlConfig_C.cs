using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.TeleControl
{
	// Token: 0x02003E03 RID: 15875
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/TeleControl/BP_TeleControlConfig.BP_TeleControlConfig_C")]
	[UnrealStructLayout(792, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 792)]
	public class BP_TeleControlConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602714B RID: 160075 RVA: 0x009E9751 File Offset: 0x009E7951
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_TeleControlConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/TeleControl/BP_TeleControlConfig.BP_TeleControlConfig_C");
			}
			return BP_TeleControlConfig_C._ClassPtr;
		}

		// Token: 0x0602714C RID: 160076 RVA: 0x009E9778 File Offset: 0x009E7978
		public BP_TeleControlConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_TeleControlConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602714D RID: 160077 RVA: 0x009E97A0 File Offset: 0x009E79A0
		public BP_TeleControlConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_TeleControlConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005AED RID: 23277
		// (get) Token: 0x0602714E RID: 160078 RVA: 0x009E97D3 File Offset: 0x009E79D3
		// (set) Token: 0x0602714F RID: 160079 RVA: 0x009E97E3 File Offset: 0x009E79E3
		public unsafe float 读条时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005AEE RID: 23278
		// (get) Token: 0x06027150 RID: 160080 RVA: 0x009E97F4 File Offset: 0x009E79F4
		// (set) Token: 0x06027151 RID: 160081 RVA: 0x009E9804 File Offset: 0x009E7A04
		public unsafe bool 未锁定目标时不可投掷
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005AEF RID: 23279
		// (get) Token: 0x06027152 RID: 160082 RVA: 0x009E9815 File Offset: 0x009E7A15
		// (set) Token: 0x06027153 RID: 160083 RVA: 0x009E9825 File Offset: 0x009E7A25
		public unsafe float 摆动频率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005AF0 RID: 23280
		// (get) Token: 0x06027154 RID: 160084 RVA: 0x009E9836 File Offset: 0x009E7A36
		// (set) Token: 0x06027155 RID: 160085 RVA: 0x009E9846 File Offset: 0x009E7A46
		public unsafe float 吸取延迟
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005AF1 RID: 23281
		// (get) Token: 0x06027156 RID: 160086 RVA: 0x009E9857 File Offset: 0x009E7A57
		// (set) Token: 0x06027157 RID: 160087 RVA: 0x009E9867 File Offset: 0x009E7A67
		public unsafe float 线性阻尼
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005AF2 RID: 23282
		// (get) Token: 0x06027158 RID: 160088 RVA: 0x009E9878 File Offset: 0x009E7A78
		// (set) Token: 0x06027159 RID: 160089 RVA: 0x009E9888 File Offset: 0x009E7A88
		public unsafe float 角刚度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005AF3 RID: 23283
		// (get) Token: 0x0602715A RID: 160090 RVA: 0x009E9899 File Offset: 0x009E7A99
		// (set) Token: 0x0602715B RID: 160091 RVA: 0x009E98A9 File Offset: 0x009E7AA9
		public unsafe float 线性刚度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005AF4 RID: 23284
		// (get) Token: 0x0602715C RID: 160092 RVA: 0x009E98BA File Offset: 0x009E7ABA
		// (set) Token: 0x0602715D RID: 160093 RVA: 0x009E98CA File Offset: 0x009E7ACA
		public unsafe float 角度阻尼
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005AF5 RID: 23285
		// (get) Token: 0x0602715E RID: 160094 RVA: 0x009E98DB File Offset: 0x009E7ADB
		// (set) Token: 0x0602715F RID: 160095 RVA: 0x009E98EB File Offset: 0x009E7AEB
		public unsafe float 吸取时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005AF6 RID: 23286
		// (get) Token: 0x06027160 RID: 160096 RVA: 0x009E98FC File Offset: 0x009E7AFC
		// (set) Token: 0x06027161 RID: 160097 RVA: 0x009E990C File Offset: 0x009E7B0C
		public unsafe float 对齐时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005AF7 RID: 23287
		// (get) Token: 0x06027162 RID: 160098 RVA: 0x009E991D File Offset: 0x009E7B1D
		// (set) Token: 0x06027163 RID: 160099 RVA: 0x009E992D File Offset: 0x009E7B2D
		public unsafe float 牵引高度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005AF8 RID: 23288
		// (get) Token: 0x06027164 RID: 160100 RVA: 0x009E993E File Offset: 0x009E7B3E
		// (set) Token: 0x06027165 RID: 160101 RVA: 0x009E994E File Offset: 0x009E7B4E
		public unsafe float 角速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17005AF9 RID: 23289
		// (get) Token: 0x06027166 RID: 160102 RVA: 0x009E995F File Offset: 0x009E7B5F
		// (set) Token: 0x06027167 RID: 160103 RVA: 0x009E996F File Offset: 0x009E7B6F
		public unsafe float 摆动范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17005AFA RID: 23290
		// (get) Token: 0x06027168 RID: 160104 RVA: 0x009E9980 File Offset: 0x009E7B80
		// (set) Token: 0x06027169 RID: 160105 RVA: 0x009E9994 File Offset: 0x009E7B94
		public unsafe FVector 旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17005AFB RID: 23291
		// (get) Token: 0x0602716A RID: 160106 RVA: 0x009E99A9 File Offset: 0x009E7BA9
		// (set) Token: 0x0602716B RID: 160107 RVA: 0x009E99BD File Offset: 0x009E7BBD
		public unsafe FVector 一级偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17005AFC RID: 23292
		// (get) Token: 0x0602716C RID: 160108 RVA: 0x009E99D2 File Offset: 0x009E7BD2
		// (set) Token: 0x0602716D RID: 160109 RVA: 0x009E99E6 File Offset: 0x009E7BE6
		public unsafe FVector 二级偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17005AFD RID: 23293
		// (get) Token: 0x0602716E RID: 160110 RVA: 0x009E99FB File Offset: 0x009E7BFB
		// (set) Token: 0x0602716F RID: 160111 RVA: 0x009E9A0F File Offset: 0x009E7C0F
		public unsafe FGameplayTag 控物保持镜头
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17005AFE RID: 23294
		// (get) Token: 0x06027170 RID: 160112 RVA: 0x009E9A24 File Offset: 0x009E7C24
		// (set) Token: 0x06027171 RID: 160113 RVA: 0x009E9A38 File Offset: 0x009E7C38
		public unsafe FGameplayTag 读条镜头
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17005AFF RID: 23295
		// (get) Token: 0x06027172 RID: 160114 RVA: 0x009E9A4D File Offset: 0x009E7C4D
		// (set) Token: 0x06027173 RID: 160115 RVA: 0x009E9A61 File Offset: 0x009E7C61
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public unsafe TSubclassOf<UMatineeCameraShake> 读条震屏
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_18);
			}
			[param: Nullable(new byte[]
			{
				0,
				1
			})]
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17005B00 RID: 23296
		// (get) Token: 0x06027174 RID: 160116 RVA: 0x009E9A76 File Offset: 0x009E7C76
		// (set) Token: 0x06027175 RID: 160117 RVA: 0x009E9A86 File Offset: 0x009E7C86
		public unsafe float 被控制CD
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17005B01 RID: 23297
		// (get) Token: 0x06027176 RID: 160118 RVA: 0x009E9A97 File Offset: 0x009E7C97
		// (set) Token: 0x06027177 RID: 160119 RVA: 0x009E9AAB File Offset: 0x009E7CAB
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public unsafe TSubclassOf<UMatineeCameraShake> 控物保持震屏
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_20);
			}
			[param: Nullable(new byte[]
			{
				0,
				1
			})]
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17005B02 RID: 23298
		// (get) Token: 0x06027178 RID: 160120 RVA: 0x009E9AC0 File Offset: 0x009E7CC0
		// (set) Token: 0x06027179 RID: 160121 RVA: 0x009E9AD4 File Offset: 0x009E7CD4
		public unsafe FGameplayTag 吸取飞行镜头
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17005B03 RID: 23299
		// (get) Token: 0x0602717A RID: 160122 RVA: 0x009E9AE9 File Offset: 0x009E7CE9
		// (set) Token: 0x0602717B RID: 160123 RVA: 0x009E9AFD File Offset: 0x009E7CFD
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public unsafe TSubclassOf<UMatineeCameraShake> 吸取飞行震屏
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_22);
			}
			[param: Nullable(new byte[]
			{
				0,
				1
			})]
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17005B04 RID: 23300
		// (get) Token: 0x0602717C RID: 160124 RVA: 0x009E9B12 File Offset: 0x009E7D12
		// (set) Token: 0x0602717D RID: 160125 RVA: 0x009E9B22 File Offset: 0x009E7D22
		public unsafe bool 打开速度Log
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005B05 RID: 23301
		// (get) Token: 0x0602717E RID: 160126 RVA: 0x009E9B33 File Offset: 0x009E7D33
		// (set) Token: 0x0602717F RID: 160127 RVA: 0x009E9B43 File Offset: 0x009E7D43
		public unsafe float 可再被控速度最小值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17005B06 RID: 23302
		// (get) Token: 0x06027180 RID: 160128 RVA: 0x009E9B54 File Offset: 0x009E7D54
		// (set) Token: 0x06027181 RID: 160129 RVA: 0x009E9B64 File Offset: 0x009E7D64
		public unsafe float 被感知范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17005B07 RID: 23303
		// (get) Token: 0x06027182 RID: 160130 RVA: 0x009E9B78 File Offset: 0x009E7D78
		// (set) Token: 0x06027183 RID: 160131 RVA: 0x009E9BB1 File Offset: 0x009E7DB1
		public TMap<float, float> 被感知角度权重
		{
			get
			{
				base.FastCheckIsValid();
				TMap<float, float> result;
				if ((result = this._被感知角度权重) == null)
				{
					result = (this._被感知角度权重 = new TMap<float, float>(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_26, this));
				}
				return result;
			}
			set
			{
				this.被感知角度权重.CopyAssign(value);
			}
		}

		// Token: 0x17005B08 RID: 23304
		// (get) Token: 0x06027184 RID: 160132 RVA: 0x009E9BBF File Offset: 0x009E7DBF
		// (set) Token: 0x06027185 RID: 160133 RVA: 0x009E9BD3 File Offset: 0x009E7DD3
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public unsafe TSubclassOf<UMatineeCameraShake> 投掷震屏
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_27);
			}
			[param: Nullable(new byte[]
			{
				0,
				1
			})]
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17005B09 RID: 23305
		// (get) Token: 0x06027186 RID: 160134 RVA: 0x009E9BE8 File Offset: 0x009E7DE8
		// (set) Token: 0x06027187 RID: 160135 RVA: 0x009E9BF8 File Offset: 0x009E7DF8
		public unsafe bool 随速度调整朝向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005B0A RID: 23306
		// (get) Token: 0x06027188 RID: 160136 RVA: 0x009E9C09 File Offset: 0x009E7E09
		// (set) Token: 0x06027189 RID: 160137 RVA: 0x009E9C19 File Offset: 0x009E7E19
		public unsafe bool 控物保持使用物理
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_29) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_29) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005B0B RID: 23307
		// (get) Token: 0x0602718A RID: 160138 RVA: 0x009E9C2A File Offset: 0x009E7E2A
		// (set) Token: 0x0602718B RID: 160139 RVA: 0x009E9C3A File Offset: 0x009E7E3A
		public unsafe float 无锁状态附加仰角
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17005B0C RID: 23308
		// (get) Token: 0x0602718C RID: 160140 RVA: 0x009E9C4C File Offset: 0x009E7E4C
		// (set) Token: 0x0602718D RID: 160141 RVA: 0x009E9C85 File Offset: 0x009E7E85
		public TArray<FGameplayTag> 控物保持标签
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FGameplayTag> result;
				if ((result = this._控物保持标签) == null)
				{
					result = (this._控物保持标签 = new TArray<FGameplayTag>(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_31, this));
				}
				return result;
			}
			set
			{
				this.控物保持标签.CopyAssign(value);
			}
		}

		// Token: 0x17005B0D RID: 23309
		// (get) Token: 0x0602718E RID: 160142 RVA: 0x009E9C93 File Offset: 0x009E7E93
		// (set) Token: 0x0602718F RID: 160143 RVA: 0x009E9CA7 File Offset: 0x009E7EA7
		public unsafe FVector 被感知坐标偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17005B0E RID: 23310
		// (get) Token: 0x06027190 RID: 160144 RVA: 0x009E9CBC File Offset: 0x009E7EBC
		// (set) Token: 0x06027191 RID: 160145 RVA: 0x009E9CCC File Offset: 0x009E7ECC
		public unsafe float 物体质量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17005B0F RID: 23311
		// (get) Token: 0x06027192 RID: 160146 RVA: 0x009E9CDD File Offset: 0x009E7EDD
		// (set) Token: 0x06027193 RID: 160147 RVA: 0x009E9CED File Offset: 0x009E7EED
		public unsafe float 物体线性阻尼
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17005B10 RID: 23312
		// (get) Token: 0x06027194 RID: 160148 RVA: 0x009E9CFE File Offset: 0x009E7EFE
		// (set) Token: 0x06027195 RID: 160149 RVA: 0x009E9D0E File Offset: 0x009E7F0E
		public unsafe float 物体角速度阻尼
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x17005B11 RID: 23313
		// (get) Token: 0x06027196 RID: 160150 RVA: 0x009E9D1F File Offset: 0x009E7F1F
		// (set) Token: 0x06027197 RID: 160151 RVA: 0x009E9D33 File Offset: 0x009E7F33
		public unsafe string 控物准星资源ID
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_TeleControlConfig_C.__PropertyOffset_36)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_TeleControlConfig_C.__PropertyOffset_36)), value);
			}
		}

		// Token: 0x17005B12 RID: 23314
		// (get) Token: 0x06027198 RID: 160152 RVA: 0x009E9D48 File Offset: 0x009E7F48
		// (set) Token: 0x06027199 RID: 160153 RVA: 0x009E9D58 File Offset: 0x009E7F58
		public unsafe bool 角色是否随相机旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_37) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_37) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005B13 RID: 23315
		// (get) Token: 0x0602719A RID: 160154 RVA: 0x009E9D69 File Offset: 0x009E7F69
		// (set) Token: 0x0602719B RID: 160155 RVA: 0x009E9D7D File Offset: 0x009E7F7D
		public unsafe FName 待机状态碰撞预设
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17005B14 RID: 23316
		// (get) Token: 0x0602719C RID: 160156 RVA: 0x009E9D92 File Offset: 0x009E7F92
		// (set) Token: 0x0602719D RID: 160157 RVA: 0x009E9DA6 File Offset: 0x009E7FA6
		public unsafe FName 吸取状态碰撞预设
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17005B15 RID: 23317
		// (get) Token: 0x0602719E RID: 160158 RVA: 0x009E9DBB File Offset: 0x009E7FBB
		// (set) Token: 0x0602719F RID: 160159 RVA: 0x009E9DCF File Offset: 0x009E7FCF
		public unsafe FName 保持状态碰撞预设
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x17005B16 RID: 23318
		// (get) Token: 0x060271A0 RID: 160160 RVA: 0x009E9DE4 File Offset: 0x009E7FE4
		// (set) Token: 0x060271A1 RID: 160161 RVA: 0x009E9DF8 File Offset: 0x009E7FF8
		public unsafe FName 投掷状态碰撞预设
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x17005B17 RID: 23319
		// (get) Token: 0x060271A2 RID: 160162 RVA: 0x009E9E0D File Offset: 0x009E800D
		// (set) Token: 0x060271A3 RID: 160163 RVA: 0x009E9E21 File Offset: 0x009E8021
		[Nullable(2)]
		public unsafe UCurveVector 投掷运动轨迹曲线
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveVector>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TeleControlConfig_C.__PropertyOffset_42);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TeleControlConfig_C.__PropertyOffset_42, value);
			}
		}

		// Token: 0x17005B18 RID: 23320
		// (get) Token: 0x060271A4 RID: 160164 RVA: 0x009E9E36 File Offset: 0x009E8036
		// (set) Token: 0x060271A5 RID: 160165 RVA: 0x009E9E46 File Offset: 0x009E8046
		public unsafe bool 抛物瞄准射线Debug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_43) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_43) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005B19 RID: 23321
		// (get) Token: 0x060271A6 RID: 160166 RVA: 0x009E9E57 File Offset: 0x009E8057
		// (set) Token: 0x060271A7 RID: 160167 RVA: 0x009E9E67 File Offset: 0x009E8067
		public unsafe bool 抛物瞄准模式开关
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_44) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_44) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005B1A RID: 23322
		// (get) Token: 0x060271A8 RID: 160168 RVA: 0x009E9E78 File Offset: 0x009E8078
		// (set) Token: 0x060271A9 RID: 160169 RVA: 0x009E9E88 File Offset: 0x009E8088
		public unsafe float 抛物瞄准模式仰角
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x17005B1B RID: 23323
		// (get) Token: 0x060271AA RID: 160170 RVA: 0x009E9E99 File Offset: 0x009E8099
		// (set) Token: 0x060271AB RID: 160171 RVA: 0x009E9EA9 File Offset: 0x009E80A9
		public unsafe float 抛物瞄准模式初速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_46);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x17005B1C RID: 23324
		// (get) Token: 0x060271AC RID: 160172 RVA: 0x009E9EBA File Offset: 0x009E80BA
		// (set) Token: 0x060271AD RID: 160173 RVA: 0x009E9ECA File Offset: 0x009E80CA
		public unsafe float 抛物瞄准射线检测半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x17005B1D RID: 23325
		// (get) Token: 0x060271AE RID: 160174 RVA: 0x009E9EDB File Offset: 0x009E80DB
		// (set) Token: 0x060271AF RID: 160175 RVA: 0x009E9EEF File Offset: 0x009E80EF
		public unsafe FGameplayTag 抛物瞄准模式镜头
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x17005B1E RID: 23326
		// (get) Token: 0x060271B0 RID: 160176 RVA: 0x009E9F04 File Offset: 0x009E8104
		// (set) Token: 0x060271B1 RID: 160177 RVA: 0x009E9F3D File Offset: 0x009E813D
		public FSoftObjectPath 抛物瞄准模式样条特效
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._抛物瞄准模式样条特效) == null)
				{
					result = (this._抛物瞄准模式样条特效 = new FSoftObjectPath(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_49, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_49, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005B1F RID: 23327
		// (get) Token: 0x060271B2 RID: 160178 RVA: 0x009E9F60 File Offset: 0x009E8160
		// (set) Token: 0x060271B3 RID: 160179 RVA: 0x009E9F99 File Offset: 0x009E8199
		public FSoftObjectPath 抛物瞄准模式终点特效
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._抛物瞄准模式终点特效) == null)
				{
					result = (this._抛物瞄准模式终点特效 = new FSoftObjectPath(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_50, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_50, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005B20 RID: 23328
		// (get) Token: 0x060271B4 RID: 160180 RVA: 0x009E9FBA File Offset: 0x009E81BA
		// (set) Token: 0x060271B5 RID: 160181 RVA: 0x009E9FCA File Offset: 0x009E81CA
		public unsafe float 抛物瞄准模式重力加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x17005B21 RID: 23329
		// (get) Token: 0x060271B6 RID: 160182 RVA: 0x009E9FDB File Offset: 0x009E81DB
		// (set) Token: 0x060271B7 RID: 160183 RVA: 0x009E9FEB File Offset: 0x009E81EB
		public unsafe float 投掷锁定范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_52);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_52) = value;
			}
		}

		// Token: 0x17005B22 RID: 23330
		// (get) Token: 0x060271B8 RID: 160184 RVA: 0x009E9FFC File Offset: 0x009E81FC
		// (set) Token: 0x060271B9 RID: 160185 RVA: 0x009EA035 File Offset: 0x009E8235
		public FSoftObjectPath 归位消失特效
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._归位消失特效) == null)
				{
					result = (this._归位消失特效 = new FSoftObjectPath(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_53, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_53, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005B23 RID: 23331
		// (get) Token: 0x060271BA RID: 160186 RVA: 0x009EA058 File Offset: 0x009E8258
		// (set) Token: 0x060271BB RID: 160187 RVA: 0x009EA091 File Offset: 0x009E8291
		public TMap<int, float> 投掷状态CueId
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, float> result;
				if ((result = this._投掷状态CueId) == null)
				{
					result = (this._投掷状态CueId = new TMap<int, float>(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_54, this));
				}
				return result;
			}
			set
			{
				this.投掷状态CueId.CopyAssign(value);
			}
		}

		// Token: 0x17005B24 RID: 23332
		// (get) Token: 0x060271BC RID: 160188 RVA: 0x009EA09F File Offset: 0x009E829F
		// (set) Token: 0x060271BD RID: 160189 RVA: 0x009EA0B3 File Offset: 0x009E82B3
		[Nullable(2)]
		public unsafe UPhysicalMaterial 物体物理材质
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicalMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TeleControlConfig_C.__PropertyOffset_55);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TeleControlConfig_C.__PropertyOffset_55, value);
			}
		}

		// Token: 0x17005B25 RID: 23333
		// (get) Token: 0x060271BE RID: 160190 RVA: 0x009EA0C8 File Offset: 0x009E82C8
		// (set) Token: 0x060271BF RID: 160191 RVA: 0x009EA0DD File Offset: 0x009E82DD
		public TSoftObjectPtr<UKuroForceFeedbackEffect> 吸取飞行手柄震动
		{
			get
			{
				return new TSoftObjectPtr<UKuroForceFeedbackEffect>(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_56, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_56, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005B26 RID: 23334
		// (get) Token: 0x060271C0 RID: 160192 RVA: 0x009EA102 File Offset: 0x009E8302
		// (set) Token: 0x060271C1 RID: 160193 RVA: 0x009EA117 File Offset: 0x009E8317
		public TSoftObjectPtr<UKuroForceFeedbackEffect> 投掷手柄震动
		{
			get
			{
				return new TSoftObjectPtr<UKuroForceFeedbackEffect>(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_57, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_TeleControlConfig_C.__PropertyOffset_57, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x060271C2 RID: 160194 RVA: 0x009EA13C File Offset: 0x009E833C
		protected BP_TeleControlConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040146BE RID: 83646
		public new const string __ObjectPath = "/Game/Aki/Data/TeleControl/BP_TeleControlConfig.BP_TeleControlConfig_C";

		// Token: 0x040146BF RID: 83647
		private static IntPtr _ClassPtr;

		// Token: 0x040146C0 RID: 83648
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040146C1 RID: 83649
		internal static int __PropertyOffset_0;

		// Token: 0x040146C2 RID: 83650
		internal static int __PropertyOffset_1;

		// Token: 0x040146C3 RID: 83651
		internal static int __PropertyOffset_2;

		// Token: 0x040146C4 RID: 83652
		internal static int __PropertyOffset_3;

		// Token: 0x040146C5 RID: 83653
		internal static int __PropertyOffset_4;

		// Token: 0x040146C6 RID: 83654
		internal static int __PropertyOffset_5;

		// Token: 0x040146C7 RID: 83655
		internal static int __PropertyOffset_6;

		// Token: 0x040146C8 RID: 83656
		internal static int __PropertyOffset_7;

		// Token: 0x040146C9 RID: 83657
		internal static int __PropertyOffset_8;

		// Token: 0x040146CA RID: 83658
		internal static int __PropertyOffset_9;

		// Token: 0x040146CB RID: 83659
		internal static int __PropertyOffset_10;

		// Token: 0x040146CC RID: 83660
		internal static int __PropertyOffset_11;

		// Token: 0x040146CD RID: 83661
		internal static int __PropertyOffset_12;

		// Token: 0x040146CE RID: 83662
		internal static int __PropertyOffset_13;

		// Token: 0x040146CF RID: 83663
		internal static int __PropertyOffset_14;

		// Token: 0x040146D0 RID: 83664
		internal static int __PropertyOffset_15;

		// Token: 0x040146D1 RID: 83665
		internal static int __PropertyOffset_16;

		// Token: 0x040146D2 RID: 83666
		internal static int __PropertyOffset_17;

		// Token: 0x040146D3 RID: 83667
		internal static int __PropertyOffset_18;

		// Token: 0x040146D4 RID: 83668
		internal static int __PropertyOffset_19;

		// Token: 0x040146D5 RID: 83669
		internal static int __PropertyOffset_20;

		// Token: 0x040146D6 RID: 83670
		internal static int __PropertyOffset_21;

		// Token: 0x040146D7 RID: 83671
		internal static int __PropertyOffset_22;

		// Token: 0x040146D8 RID: 83672
		internal static int __PropertyOffset_23;

		// Token: 0x040146D9 RID: 83673
		internal static int __PropertyOffset_24;

		// Token: 0x040146DA RID: 83674
		internal static int __PropertyOffset_25;

		// Token: 0x040146DB RID: 83675
		internal static int __PropertyOffset_26;

		// Token: 0x040146DC RID: 83676
		[Nullable(2)]
		private TMap<float, float> _被感知角度权重;

		// Token: 0x040146DD RID: 83677
		internal static int __PropertyOffset_27;

		// Token: 0x040146DE RID: 83678
		internal static int __PropertyOffset_28;

		// Token: 0x040146DF RID: 83679
		internal static int __PropertyOffset_29;

		// Token: 0x040146E0 RID: 83680
		internal static int __PropertyOffset_30;

		// Token: 0x040146E1 RID: 83681
		internal static int __PropertyOffset_31;

		// Token: 0x040146E2 RID: 83682
		[Nullable(2)]
		private TArray<FGameplayTag> _控物保持标签;

		// Token: 0x040146E3 RID: 83683
		internal static int __PropertyOffset_32;

		// Token: 0x040146E4 RID: 83684
		internal static int __PropertyOffset_33;

		// Token: 0x040146E5 RID: 83685
		internal static int __PropertyOffset_34;

		// Token: 0x040146E6 RID: 83686
		internal static int __PropertyOffset_35;

		// Token: 0x040146E7 RID: 83687
		internal static int __PropertyOffset_36;

		// Token: 0x040146E8 RID: 83688
		internal static int __PropertyOffset_37;

		// Token: 0x040146E9 RID: 83689
		internal static int __PropertyOffset_38;

		// Token: 0x040146EA RID: 83690
		internal static int __PropertyOffset_39;

		// Token: 0x040146EB RID: 83691
		internal static int __PropertyOffset_40;

		// Token: 0x040146EC RID: 83692
		internal static int __PropertyOffset_41;

		// Token: 0x040146ED RID: 83693
		internal static int __PropertyOffset_42;

		// Token: 0x040146EE RID: 83694
		internal static int __PropertyOffset_43;

		// Token: 0x040146EF RID: 83695
		internal static int __PropertyOffset_44;

		// Token: 0x040146F0 RID: 83696
		internal static int __PropertyOffset_45;

		// Token: 0x040146F1 RID: 83697
		internal static int __PropertyOffset_46;

		// Token: 0x040146F2 RID: 83698
		internal static int __PropertyOffset_47;

		// Token: 0x040146F3 RID: 83699
		internal static int __PropertyOffset_48;

		// Token: 0x040146F4 RID: 83700
		internal static int __PropertyOffset_49;

		// Token: 0x040146F5 RID: 83701
		[Nullable(2)]
		private FSoftObjectPath _抛物瞄准模式样条特效;

		// Token: 0x040146F6 RID: 83702
		internal static int __PropertyOffset_50;

		// Token: 0x040146F7 RID: 83703
		[Nullable(2)]
		private FSoftObjectPath _抛物瞄准模式终点特效;

		// Token: 0x040146F8 RID: 83704
		internal static int __PropertyOffset_51;

		// Token: 0x040146F9 RID: 83705
		internal static int __PropertyOffset_52;

		// Token: 0x040146FA RID: 83706
		internal static int __PropertyOffset_53;

		// Token: 0x040146FB RID: 83707
		[Nullable(2)]
		private FSoftObjectPath _归位消失特效;

		// Token: 0x040146FC RID: 83708
		internal static int __PropertyOffset_54;

		// Token: 0x040146FD RID: 83709
		[Nullable(2)]
		private TMap<int, float> _投掷状态CueId;

		// Token: 0x040146FE RID: 83710
		internal static int __PropertyOffset_55;

		// Token: 0x040146FF RID: 83711
		internal static int __PropertyOffset_56;

		// Token: 0x04014700 RID: 83712
		internal static int __PropertyOffset_57;
	}
}
