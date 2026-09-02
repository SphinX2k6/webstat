using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F6E RID: 16238
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/SReBulletDataBase.SReBulletDataBase")]
	[UnrealStructLayout(512, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 508)]
	public class SReBulletDataBase : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060288A9 RID: 166057 RVA: 0x00A0E71E File Offset: 0x00A0C91E
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SReBulletDataBase._ScriptStructPtr != 0) ? SReBulletDataBase._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Core/Fight/SReBulletDataBase.SReBulletDataBase", ref SReBulletDataBase._ScriptStructPtr);
		}

		// Token: 0x170062BC RID: 25276
		// (get) Token: 0x060288AA RID: 166058 RVA: 0x00A0E742 File Offset: 0x00A0C942
		// (set) Token: 0x060288AB RID: 166059 RVA: 0x00A0E756 File Offset: 0x00A0C956
		[Nullable(0)]
		public unsafe TEnumAsByte<AkiClient.Game.Aki.Character.BaseCharacter.EBulletShape> 子弹形状
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_0);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170062BD RID: 25277
		// (get) Token: 0x060288AC RID: 166060 RVA: 0x00A0E76B File Offset: 0x00A0C96B
		// (set) Token: 0x060288AD RID: 166061 RVA: 0x00A0E77F File Offset: 0x00A0C97F
		public unsafe FVector 初始大小
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170062BE RID: 25278
		// (get) Token: 0x060288AE RID: 166062 RVA: 0x00A0E794 File Offset: 0x00A0C994
		// (set) Token: 0x060288AF RID: 166063 RVA: 0x00A0E7D7 File Offset: 0x00A0C9D7
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
					result = (this._特殊参数 = new TMap<TEnumAsByte<EBulletBaseSpecificParam>, string>(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_2, base.MemoryOwner ?? this));
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

		// Token: 0x170062BF RID: 25279
		// (get) Token: 0x060288B0 RID: 166064 RVA: 0x00A0E7E5 File Offset: 0x00A0C9E5
		// (set) Token: 0x060288B1 RID: 166065 RVA: 0x00A0E7F9 File Offset: 0x00A0C9F9
		[Nullable(0)]
		public unsafe TEnumAsByte<EPositionStandard> 出生位置基准
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_3);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170062C0 RID: 25280
		// (get) Token: 0x060288B2 RID: 166066 RVA: 0x00A0E80E File Offset: 0x00A0CA0E
		// (set) Token: 0x060288B3 RID: 166067 RVA: 0x00A0E822 File Offset: 0x00A0CA22
		public unsafe string 攻击者黑板Key值
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SReBulletDataBase.__PropertyOffset_4)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SReBulletDataBase.__PropertyOffset_4)), value);
			}
		}

		// Token: 0x170062C1 RID: 25281
		// (get) Token: 0x060288B4 RID: 166068 RVA: 0x00A0E837 File Offset: 0x00A0CA37
		// (set) Token: 0x060288B5 RID: 166069 RVA: 0x00A0E84B File Offset: 0x00A0CA4B
		public unsafe FVector 出生位置偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170062C2 RID: 25282
		// (get) Token: 0x060288B6 RID: 166070 RVA: 0x00A0E860 File Offset: 0x00A0CA60
		// (set) Token: 0x060288B7 RID: 166071 RVA: 0x00A0E874 File Offset: 0x00A0CA74
		public unsafe FVector 中心位置偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170062C3 RID: 25283
		// (get) Token: 0x060288B8 RID: 166072 RVA: 0x00A0E889 File Offset: 0x00A0CA89
		// (set) Token: 0x060288B9 RID: 166073 RVA: 0x00A0E89D File Offset: 0x00A0CA9D
		public unsafe FVector 出生位置随机
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170062C4 RID: 25284
		// (get) Token: 0x060288BA RID: 166074 RVA: 0x00A0E8B2 File Offset: 0x00A0CAB2
		// (set) Token: 0x060288BB RID: 166075 RVA: 0x00A0E8C6 File Offset: 0x00A0CAC6
		public unsafe FRotator 初始旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170062C5 RID: 25285
		// (get) Token: 0x060288BC RID: 166076 RVA: 0x00A0E8DB File Offset: 0x00A0CADB
		// (set) Token: 0x060288BD RID: 166077 RVA: 0x00A0E8EF File Offset: 0x00A0CAEF
		public unsafe FVector 限制生成距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170062C6 RID: 25286
		// (get) Token: 0x060288BE RID: 166078 RVA: 0x00A0E904 File Offset: 0x00A0CB04
		// (set) Token: 0x060288BF RID: 166079 RVA: 0x00A0E914 File Offset: 0x00A0CB14
		public unsafe float 持续时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170062C7 RID: 25287
		// (get) Token: 0x060288C0 RID: 166080 RVA: 0x00A0E925 File Offset: 0x00A0CB25
		// (set) Token: 0x060288C1 RID: 166081 RVA: 0x00A0E935 File Offset: 0x00A0CB35
		public unsafe float 碰撞判定时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170062C8 RID: 25288
		// (get) Token: 0x060288C2 RID: 166082 RVA: 0x00A0E946 File Offset: 0x00A0CB46
		// (set) Token: 0x060288C3 RID: 166083 RVA: 0x00A0E956 File Offset: 0x00A0CB56
		public unsafe float 碰撞判定延迟
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170062C9 RID: 25289
		// (get) Token: 0x060288C4 RID: 166084 RVA: 0x00A0E967 File Offset: 0x00A0CB67
		// (set) Token: 0x060288C5 RID: 166085 RVA: 0x00A0E97B File Offset: 0x00A0CB7B
		[Nullable(0)]
		public unsafe TEnumAsByte<EHitType> 命中判定类型
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_13);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170062CA RID: 25290
		// (get) Token: 0x060288C6 RID: 166086 RVA: 0x00A0E990 File Offset: 0x00A0CB90
		// (set) Token: 0x060288C7 RID: 166087 RVA: 0x00A0E9AF File Offset: 0x00A0CBAF
		public TSoftObjectPtr<BulletCampType_C> 命中判定类型预设
		{
			get
			{
				return new TSoftObjectPtr<BulletCampType_C>(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_14, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_14, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x170062CB RID: 25291
		// (get) Token: 0x060288C8 RID: 166088 RVA: 0x00A0E9D4 File Offset: 0x00A0CBD4
		// (set) Token: 0x060288C9 RID: 166089 RVA: 0x00A0E9E8 File Offset: 0x00A0CBE8
		public unsafe FGameplayTag 命中判定Tag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170062CC RID: 25292
		// (get) Token: 0x060288CA RID: 166090 RVA: 0x00A0E9FD File Offset: 0x00A0CBFD
		// (set) Token: 0x060288CB RID: 166091 RVA: 0x00A0EA11 File Offset: 0x00A0CC11
		public unsafe FGameplayTag 禁止命中Tag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170062CD RID: 25293
		// (get) Token: 0x060288CC RID: 166092 RVA: 0x00A0EA26 File Offset: 0x00A0CC26
		// (set) Token: 0x060288CD RID: 166093 RVA: 0x00A0EA36 File Offset: 0x00A0CC36
		public unsafe bool IsRandomVictim
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x170062CE RID: 25294
		// (get) Token: 0x060288CE RID: 166094 RVA: 0x00A0EA47 File Offset: 0x00A0CC47
		// (set) Token: 0x060288CF RID: 166095 RVA: 0x00A0EA57 File Offset: 0x00A0CC57
		public unsafe int 命中个数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170062CF RID: 25295
		// (get) Token: 0x060288D0 RID: 166096 RVA: 0x00A0EA68 File Offset: 0x00A0CC68
		// (set) Token: 0x060288D1 RID: 166097 RVA: 0x00A0EA78 File Offset: 0x00A0CC78
		public unsafe int 每个单位总作用次数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170062D0 RID: 25296
		// (get) Token: 0x060288D2 RID: 166098 RVA: 0x00A0EA89 File Offset: 0x00A0CC89
		// (set) Token: 0x060288D3 RID: 166099 RVA: 0x00A0EA99 File Offset: 0x00A0CC99
		public unsafe int 总作用次数限制
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170062D1 RID: 25297
		// (get) Token: 0x060288D4 RID: 166100 RVA: 0x00A0EAAA File Offset: 0x00A0CCAA
		// (set) Token: 0x060288D5 RID: 166101 RVA: 0x00A0EABA File Offset: 0x00A0CCBA
		public unsafe float 作用间隔
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x170062D2 RID: 25298
		// (get) Token: 0x060288D6 RID: 166102 RVA: 0x00A0EACB File Offset: 0x00A0CCCB
		// (set) Token: 0x060288D7 RID: 166103 RVA: 0x00A0EADB File Offset: 0x00A0CCDB
		public unsafe bool 作用间隔基于个体
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x170062D3 RID: 25299
		// (get) Token: 0x060288D8 RID: 166104 RVA: 0x00A0EAEC File Offset: 0x00A0CCEC
		// (set) Token: 0x060288D9 RID: 166105 RVA: 0x00A0EAFC File Offset: 0x00A0CCFC
		public unsafe bool 共享父子弹次数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x170062D4 RID: 25300
		// (get) Token: 0x060288DA RID: 166106 RVA: 0x00A0EB0D File Offset: 0x00A0CD0D
		// (set) Token: 0x060288DB RID: 166107 RVA: 0x00A0EB21 File Offset: 0x00A0CD21
		public unsafe FName 被击效果
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x170062D5 RID: 25301
		// (get) Token: 0x060288DC RID: 166108 RVA: 0x00A0EB38 File Offset: 0x00A0CD38
		// (set) Token: 0x060288DD RID: 166109 RVA: 0x00A0EB7B File Offset: 0x00A0CD7B
		public TArray<FName> 多被击效果
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._多被击效果) == null)
				{
					result = (this._多被击效果 = new TArray<FName>(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_25, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.多被击效果.CopyAssign(value);
			}
		}

		// Token: 0x170062D6 RID: 25302
		// (get) Token: 0x060288DE RID: 166110 RVA: 0x00A0EB89 File Offset: 0x00A0CD89
		// (set) Token: 0x060288DF RID: 166111 RVA: 0x00A0EB9D File Offset: 0x00A0CD9D
		public unsafe FName 弱点被击效果
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x170062D7 RID: 25303
		// (get) Token: 0x060288E0 RID: 166112 RVA: 0x00A0EBB4 File Offset: 0x00A0CDB4
		// (set) Token: 0x060288E1 RID: 166113 RVA: 0x00A0EBF7 File Offset: 0x00A0CDF7
		public TArray<FName> 多弱点被击效果
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._多弱点被击效果) == null)
				{
					result = (this._多弱点被击效果 = new TArray<FName>(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_27, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.多弱点被击效果.CopyAssign(value);
			}
		}

		// Token: 0x170062D8 RID: 25304
		// (get) Token: 0x060288E2 RID: 166114 RVA: 0x00A0EC05 File Offset: 0x00A0CE05
		// (set) Token: 0x060288E3 RID: 166115 RVA: 0x00A0EC19 File Offset: 0x00A0CE19
		[Nullable(0)]
		public unsafe TEnumAsByte<AkiClient.Game.Aki.Character.BaseCharacter.EBulletRelativeDir> 子弹受击方向
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_28);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x170062D9 RID: 25305
		// (get) Token: 0x060288E4 RID: 166116 RVA: 0x00A0EC2E File Offset: 0x00A0CE2E
		// (set) Token: 0x060288E5 RID: 166117 RVA: 0x00A0EC3E File Offset: 0x00A0CE3E
		public unsafe long 伤害ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x170062DA RID: 25306
		// (get) Token: 0x060288E6 RID: 166118 RVA: 0x00A0EC50 File Offset: 0x00A0CE50
		// (set) Token: 0x060288E7 RID: 166119 RVA: 0x00A0EC93 File Offset: 0x00A0CE93
		public TArray<long> 多伤害ID
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._多伤害ID) == null)
				{
					result = (this._多伤害ID = new TArray<long>(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_30, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.多伤害ID.CopyAssign(value);
			}
		}

		// Token: 0x170062DB RID: 25307
		// (get) Token: 0x060288E8 RID: 166120 RVA: 0x00A0ECA1 File Offset: 0x00A0CEA1
		// (set) Token: 0x060288E9 RID: 166121 RVA: 0x00A0ECB5 File Offset: 0x00A0CEB5
		public unsafe FRotator 子弹攻击方向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x170062DC RID: 25308
		// (get) Token: 0x060288EA RID: 166122 RVA: 0x00A0ECCA File Offset: 0x00A0CECA
		// (set) Token: 0x060288EB RID: 166123 RVA: 0x00A0ECDA File Offset: 0x00A0CEDA
		public unsafe bool 技能结束是否销毁子弹
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_32) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_32) = (value ? 1 : 0);
			}
		}

		// Token: 0x170062DD RID: 25309
		// (get) Token: 0x060288EC RID: 166124 RVA: 0x00A0ECEC File Offset: 0x00A0CEEC
		// (set) Token: 0x060288ED RID: 166125 RVA: 0x00A0ED2F File Offset: 0x00A0CF2F
		public FGameplayTagContainer 子弹允许生成Tag
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._子弹允许生成Tag) == null)
				{
					result = (this._子弹允许生成Tag = new FGameplayTagContainer(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_33, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_33, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170062DE RID: 25310
		// (get) Token: 0x060288EE RID: 166126 RVA: 0x00A0ED50 File Offset: 0x00A0CF50
		// (set) Token: 0x060288EF RID: 166127 RVA: 0x00A0ED93 File Offset: 0x00A0CF93
		public FGameplayTagContainer 子弹禁止生成Tag
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._子弹禁止生成Tag) == null)
				{
					result = (this._子弹禁止生成Tag = new FGameplayTagContainer(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_34, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_34, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170062DF RID: 25311
		// (get) Token: 0x060288F0 RID: 166128 RVA: 0x00A0EDB4 File Offset: 0x00A0CFB4
		// (set) Token: 0x060288F1 RID: 166129 RVA: 0x00A0EDC4 File Offset: 0x00A0CFC4
		public unsafe bool 是否持续碰撞
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_35) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_35) = (value ? 1 : 0);
			}
		}

		// Token: 0x170062E0 RID: 25312
		// (get) Token: 0x060288F2 RID: 166130 RVA: 0x00A0EDD5 File Offset: 0x00A0CFD5
		// (set) Token: 0x060288F3 RID: 166131 RVA: 0x00A0EDE5 File Offset: 0x00A0CFE5
		public unsafe bool 是否贴地子弹
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_36) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_36) = (value ? 1 : 0);
			}
		}

		// Token: 0x170062E1 RID: 25313
		// (get) Token: 0x060288F4 RID: 166132 RVA: 0x00A0EDF6 File Offset: 0x00A0CFF6
		// (set) Token: 0x060288F5 RID: 166133 RVA: 0x00A0EE06 File Offset: 0x00A0D006
		public unsafe bool 是否贴水面
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_37) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_37) = (value ? 1 : 0);
			}
		}

		// Token: 0x170062E2 RID: 25314
		// (get) Token: 0x060288F6 RID: 166134 RVA: 0x00A0EE17 File Offset: 0x00A0D017
		// (set) Token: 0x060288F7 RID: 166135 RVA: 0x00A0EE27 File Offset: 0x00A0D027
		public unsafe bool 不跟随移动平台
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_38) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_38) = (value ? 1 : 0);
			}
		}

		// Token: 0x170062E3 RID: 25315
		// (get) Token: 0x060288F8 RID: 166136 RVA: 0x00A0EE38 File Offset: 0x00A0D038
		// (set) Token: 0x060288F9 RID: 166137 RVA: 0x00A0EE48 File Offset: 0x00A0D048
		public unsafe bool 不适配坡度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_39) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_39) = (value ? 1 : 0);
			}
		}

		// Token: 0x170062E4 RID: 25316
		// (get) Token: 0x060288FA RID: 166138 RVA: 0x00A0EE59 File Offset: 0x00A0D059
		// (set) Token: 0x060288FB RID: 166139 RVA: 0x00A0EE69 File Offset: 0x00A0D069
		public unsafe float 贴地探测距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x170062E5 RID: 25317
		// (get) Token: 0x060288FC RID: 166140 RVA: 0x00A0EE7A File Offset: 0x00A0D07A
		// (set) Token: 0x060288FD RID: 166141 RVA: 0x00A0EE8E File Offset: 0x00A0D08E
		[Nullable(0)]
		public unsafe TEnumAsByte<EBulletSyncType> 网络同步类型
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_41);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x170062E6 RID: 25318
		// (get) Token: 0x060288FE RID: 166142 RVA: 0x00A0EEA3 File Offset: 0x00A0D0A3
		// (set) Token: 0x060288FF RID: 166143 RVA: 0x00A0EEB7 File Offset: 0x00A0D0B7
		public unsafe FGameplayTag 子弹标签
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x170062E7 RID: 25319
		// (get) Token: 0x06028900 RID: 166144 RVA: 0x00A0EECC File Offset: 0x00A0D0CC
		// (set) Token: 0x06028901 RID: 166145 RVA: 0x00A0EEDC File Offset: 0x00A0D0DC
		public unsafe bool 是否响应材质受击音效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_43) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_43) = (value ? 1 : 0);
			}
		}

		// Token: 0x170062E8 RID: 25320
		// (get) Token: 0x06028902 RID: 166146 RVA: 0x00A0EEED File Offset: 0x00A0D0ED
		// (set) Token: 0x06028903 RID: 166147 RVA: 0x00A0EEFD File Offset: 0x00A0D0FD
		public unsafe bool Debug显示子弹进度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_44) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_44) = (value ? 1 : 0);
			}
		}

		// Token: 0x170062E9 RID: 25321
		// (get) Token: 0x06028904 RID: 166148 RVA: 0x00A0EF0E File Offset: 0x00A0D10E
		// (set) Token: 0x06028905 RID: 166149 RVA: 0x00A0EF1E File Offset: 0x00A0D11E
		public unsafe bool 大范围子弹对场景物件生效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_45) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_45) = (value ? 1 : 0);
			}
		}

		// Token: 0x170062EA RID: 25322
		// (get) Token: 0x06028906 RID: 166150 RVA: 0x00A0EF2F File Offset: 0x00A0D12F
		// (set) Token: 0x06028907 RID: 166151 RVA: 0x00A0EF43 File Offset: 0x00A0D143
		[Nullable(0)]
		public unsafe TEnumAsByte<EHitActorType> 命中实体类型
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_46);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x170062EB RID: 25323
		// (get) Token: 0x06028908 RID: 166152 RVA: 0x00A0EF58 File Offset: 0x00A0D158
		// (set) Token: 0x06028909 RID: 166153 RVA: 0x00A0EF68 File Offset: 0x00A0D168
		public unsafe int 大范围子弹检测方式
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataBase.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x0602890A RID: 166154 RVA: 0x00A0EF79 File Offset: 0x00A0D179
		public SReBulletDataBase()
		{
		}

		// Token: 0x0602890B RID: 166155 RVA: 0x00A0EF84 File Offset: 0x00A0D184
		public SReBulletDataBase([Nullable(0)] TEnumAsByte<AkiClient.Game.Aki.Character.BaseCharacter.EBulletShape> 子弹形状, FVector 初始大小, [Nullable(new byte[]
		{
			1,
			0,
			1
		})] TMap<TEnumAsByte<EBulletBaseSpecificParam>, string> 特殊参数, [Nullable(0)] TEnumAsByte<EPositionStandard> 出生位置基准, string 攻击者黑板Key值, FVector 出生位置偏移, FVector 中心位置偏移, FVector 出生位置随机, FRotator 初始旋转, FVector 限制生成距离, float 持续时间, float 碰撞判定时长, float 碰撞判定延迟, [Nullable(0)] TEnumAsByte<EHitType> 命中判定类型, TSoftObjectPtr<BulletCampType_C> 命中判定类型预设, FGameplayTag 命中判定Tag, FGameplayTag 禁止命中Tag, bool IsRandomVictim, int 命中个数, int 每个单位总作用次数, int 总作用次数限制, float 作用间隔, bool 作用间隔基于个体, bool 共享父子弹次数, FName 被击效果, TArray<FName> 多被击效果, FName 弱点被击效果, TArray<FName> 多弱点被击效果, [Nullable(0)] TEnumAsByte<AkiClient.Game.Aki.Character.BaseCharacter.EBulletRelativeDir> 子弹受击方向, long 伤害ID, TArray<long> 多伤害ID, FRotator 子弹攻击方向, bool 技能结束是否销毁子弹, FGameplayTagContainer 子弹允许生成Tag, FGameplayTagContainer 子弹禁止生成Tag, bool 是否持续碰撞, bool 是否贴地子弹, bool 是否贴水面, bool 不跟随移动平台, bool 不适配坡度, float 贴地探测距离, [Nullable(0)] TEnumAsByte<EBulletSyncType> 网络同步类型, FGameplayTag 子弹标签, bool 是否响应材质受击音效, bool Debug显示子弹进度, bool 大范围子弹对场景物件生效, [Nullable(0)] TEnumAsByte<EHitActorType> 命中实体类型, int 大范围子弹检测方式)
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
			this.持续时间 = 持续时间;
			this.碰撞判定时长 = 碰撞判定时长;
			this.碰撞判定延迟 = 碰撞判定延迟;
			this.命中判定类型 = 命中判定类型;
			this.命中判定类型预设 = 命中判定类型预设;
			this.命中判定Tag = 命中判定Tag;
			this.禁止命中Tag = 禁止命中Tag;
			this.IsRandomVictim = IsRandomVictim;
			this.命中个数 = 命中个数;
			this.每个单位总作用次数 = 每个单位总作用次数;
			this.总作用次数限制 = 总作用次数限制;
			this.作用间隔 = 作用间隔;
			this.作用间隔基于个体 = 作用间隔基于个体;
			this.共享父子弹次数 = 共享父子弹次数;
			this.被击效果 = 被击效果;
			this.多被击效果 = 多被击效果;
			this.弱点被击效果 = 弱点被击效果;
			this.多弱点被击效果 = 多弱点被击效果;
			this.子弹受击方向 = 子弹受击方向;
			this.伤害ID = 伤害ID;
			this.多伤害ID = 多伤害ID;
			this.子弹攻击方向 = 子弹攻击方向;
			this.技能结束是否销毁子弹 = 技能结束是否销毁子弹;
			this.子弹允许生成Tag = 子弹允许生成Tag;
			this.子弹禁止生成Tag = 子弹禁止生成Tag;
			this.是否持续碰撞 = 是否持续碰撞;
			this.是否贴地子弹 = 是否贴地子弹;
			this.是否贴水面 = 是否贴水面;
			this.不跟随移动平台 = 不跟随移动平台;
			this.不适配坡度 = 不适配坡度;
			this.贴地探测距离 = 贴地探测距离;
			this.网络同步类型 = 网络同步类型;
			this.子弹标签 = 子弹标签;
			this.是否响应材质受击音效 = 是否响应材质受击音效;
			this.Debug显示子弹进度 = Debug显示子弹进度;
			this.大范围子弹对场景物件生效 = 大范围子弹对场景物件生效;
			this.命中实体类型 = 命中实体类型;
			this.大范围子弹检测方式 = 大范围子弹检测方式;
		}

		// Token: 0x0602890C RID: 166156 RVA: 0x00A0F114 File Offset: 0x00A0D314
		protected override IntPtr GetUStructPtr()
		{
			return SReBulletDataBase.StaticStruct();
		}

		// Token: 0x0602890D RID: 166157 RVA: 0x00A0F120 File Offset: 0x00A0D320
		[NullableContext(2)]
		public SReBulletDataBase(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602890E RID: 166158 RVA: 0x00A0F12A File Offset: 0x00A0D32A
		public SReBulletDataBase(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602890F RID: 166159 RVA: 0x00A0F135 File Offset: 0x00A0D335
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SReBulletDataBase(Pointer, false, true);
		}

		// Token: 0x06028910 RID: 166160 RVA: 0x00A0F13F File Offset: 0x00A0D33F
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SReBulletDataBase(Pointer, MemoryOwner);
		}

		// Token: 0x04015615 RID: 87573
		public const string __ObjectPath = "/Game/Aki/Core/Fight/SReBulletDataBase.SReBulletDataBase";

		// Token: 0x04015616 RID: 87574
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015617 RID: 87575
		internal static int __PropertyOffset_0;

		// Token: 0x04015618 RID: 87576
		internal static int __PropertyOffset_1;

		// Token: 0x04015619 RID: 87577
		internal static int __PropertyOffset_2;

		// Token: 0x0401561A RID: 87578
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EBulletBaseSpecificParam>, string> _特殊参数;

		// Token: 0x0401561B RID: 87579
		internal static int __PropertyOffset_3;

		// Token: 0x0401561C RID: 87580
		internal static int __PropertyOffset_4;

		// Token: 0x0401561D RID: 87581
		internal static int __PropertyOffset_5;

		// Token: 0x0401561E RID: 87582
		internal static int __PropertyOffset_6;

		// Token: 0x0401561F RID: 87583
		internal static int __PropertyOffset_7;

		// Token: 0x04015620 RID: 87584
		internal static int __PropertyOffset_8;

		// Token: 0x04015621 RID: 87585
		internal static int __PropertyOffset_9;

		// Token: 0x04015622 RID: 87586
		internal static int __PropertyOffset_10;

		// Token: 0x04015623 RID: 87587
		internal static int __PropertyOffset_11;

		// Token: 0x04015624 RID: 87588
		internal static int __PropertyOffset_12;

		// Token: 0x04015625 RID: 87589
		internal static int __PropertyOffset_13;

		// Token: 0x04015626 RID: 87590
		internal static int __PropertyOffset_14;

		// Token: 0x04015627 RID: 87591
		internal static int __PropertyOffset_15;

		// Token: 0x04015628 RID: 87592
		internal static int __PropertyOffset_16;

		// Token: 0x04015629 RID: 87593
		internal static int __PropertyOffset_17;

		// Token: 0x0401562A RID: 87594
		internal static int __PropertyOffset_18;

		// Token: 0x0401562B RID: 87595
		internal static int __PropertyOffset_19;

		// Token: 0x0401562C RID: 87596
		internal static int __PropertyOffset_20;

		// Token: 0x0401562D RID: 87597
		internal static int __PropertyOffset_21;

		// Token: 0x0401562E RID: 87598
		internal static int __PropertyOffset_22;

		// Token: 0x0401562F RID: 87599
		internal static int __PropertyOffset_23;

		// Token: 0x04015630 RID: 87600
		internal static int __PropertyOffset_24;

		// Token: 0x04015631 RID: 87601
		internal static int __PropertyOffset_25;

		// Token: 0x04015632 RID: 87602
		[Nullable(2)]
		private TArray<FName> _多被击效果;

		// Token: 0x04015633 RID: 87603
		internal static int __PropertyOffset_26;

		// Token: 0x04015634 RID: 87604
		internal static int __PropertyOffset_27;

		// Token: 0x04015635 RID: 87605
		[Nullable(2)]
		private TArray<FName> _多弱点被击效果;

		// Token: 0x04015636 RID: 87606
		internal static int __PropertyOffset_28;

		// Token: 0x04015637 RID: 87607
		internal static int __PropertyOffset_29;

		// Token: 0x04015638 RID: 87608
		internal static int __PropertyOffset_30;

		// Token: 0x04015639 RID: 87609
		[Nullable(2)]
		private TArray<long> _多伤害ID;

		// Token: 0x0401563A RID: 87610
		internal static int __PropertyOffset_31;

		// Token: 0x0401563B RID: 87611
		internal static int __PropertyOffset_32;

		// Token: 0x0401563C RID: 87612
		internal static int __PropertyOffset_33;

		// Token: 0x0401563D RID: 87613
		[Nullable(2)]
		private FGameplayTagContainer _子弹允许生成Tag;

		// Token: 0x0401563E RID: 87614
		internal static int __PropertyOffset_34;

		// Token: 0x0401563F RID: 87615
		[Nullable(2)]
		private FGameplayTagContainer _子弹禁止生成Tag;

		// Token: 0x04015640 RID: 87616
		internal static int __PropertyOffset_35;

		// Token: 0x04015641 RID: 87617
		internal static int __PropertyOffset_36;

		// Token: 0x04015642 RID: 87618
		internal static int __PropertyOffset_37;

		// Token: 0x04015643 RID: 87619
		internal static int __PropertyOffset_38;

		// Token: 0x04015644 RID: 87620
		internal static int __PropertyOffset_39;

		// Token: 0x04015645 RID: 87621
		internal static int __PropertyOffset_40;

		// Token: 0x04015646 RID: 87622
		internal static int __PropertyOffset_41;

		// Token: 0x04015647 RID: 87623
		internal static int __PropertyOffset_42;

		// Token: 0x04015648 RID: 87624
		internal static int __PropertyOffset_43;

		// Token: 0x04015649 RID: 87625
		internal static int __PropertyOffset_44;

		// Token: 0x0401564A RID: 87626
		internal static int __PropertyOffset_45;

		// Token: 0x0401564B RID: 87627
		internal static int __PropertyOffset_46;

		// Token: 0x0401564C RID: 87628
		internal static int __PropertyOffset_47;
	}
}
