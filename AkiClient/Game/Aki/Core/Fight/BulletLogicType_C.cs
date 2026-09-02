using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F4F RID: 16207
	[UnrealObjectPath("/Game/Aki/Core/Fight/BulletLogicType.BulletLogicType_C")]
	[UnrealStructLayout(168, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 163)]
	public class BulletLogicType_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602882D RID: 165933 RVA: 0x00A0D9E1 File Offset: 0x00A0BBE1
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BulletLogicType_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Core/Fight/BulletLogicType.BulletLogicType_C");
			}
			return BulletLogicType_C._ClassPtr;
		}

		// Token: 0x0602882E RID: 165934 RVA: 0x00A0DA08 File Offset: 0x00A0BC08
		public BulletLogicType_C() : this(BuiltinUtils.AllocNativeUObject(BulletLogicType_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602882F RID: 165935 RVA: 0x00A0DA30 File Offset: 0x00A0BC30
		[NullableContext(1)]
		public BulletLogicType_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BulletLogicType_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700629B RID: 25243
		// (get) Token: 0x06028830 RID: 165936 RVA: 0x00A0DA63 File Offset: 0x00A0BC63
		// (set) Token: 0x06028831 RID: 165937 RVA: 0x00A0DA73 File Offset: 0x00A0BC73
		public unsafe bool 次数为0时销毁
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700629C RID: 25244
		// (get) Token: 0x06028832 RID: 165938 RVA: 0x00A0DA84 File Offset: 0x00A0BC84
		// (set) Token: 0x06028833 RID: 165939 RVA: 0x00A0DA94 File Offset: 0x00A0BC94
		public unsafe bool 是否可以触发拼刀
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700629D RID: 25245
		// (get) Token: 0x06028834 RID: 165940 RVA: 0x00A0DAA5 File Offset: 0x00A0BCA5
		// (set) Token: 0x06028835 RID: 165941 RVA: 0x00A0DAB5 File Offset: 0x00A0BCB5
		public unsafe bool 是否可以触发极限闪避
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700629E RID: 25246
		// (get) Token: 0x06028836 RID: 165942 RVA: 0x00A0DAC6 File Offset: 0x00A0BCC6
		// (set) Token: 0x06028837 RID: 165943 RVA: 0x00A0DAD6 File Offset: 0x00A0BCD6
		public unsafe bool 拼刀忽略距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700629F RID: 25247
		// (get) Token: 0x06028838 RID: 165944 RVA: 0x00A0DAE7 File Offset: 0x00A0BCE7
		// (set) Token: 0x06028839 RID: 165945 RVA: 0x00A0DAF7 File Offset: 0x00A0BCF7
		public unsafe bool 拼刀忽略角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x170062A0 RID: 25248
		// (get) Token: 0x0602883A RID: 165946 RVA: 0x00A0DB08 File Offset: 0x00A0BD08
		// (set) Token: 0x0602883B RID: 165947 RVA: 0x00A0DB18 File Offset: 0x00A0BD18
		public unsafe bool 触发前摇拼刀
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x170062A1 RID: 25249
		// (get) Token: 0x0602883C RID: 165948 RVA: 0x00A0DB29 File Offset: 0x00A0BD29
		// (set) Token: 0x0602883D RID: 165949 RVA: 0x00A0DB39 File Offset: 0x00A0BD39
		public unsafe bool 是否可以触发对策
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x170062A2 RID: 25250
		// (get) Token: 0x0602883E RID: 165950 RVA: 0x00A0DB4A File Offset: 0x00A0BD4A
		// (set) Token: 0x0602883F RID: 165951 RVA: 0x00A0DB5E File Offset: 0x00A0BD5E
		public unsafe FName 子弹碰撞预设
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170062A3 RID: 25251
		// (get) Token: 0x06028840 RID: 165952 RVA: 0x00A0DB73 File Offset: 0x00A0BD73
		// (set) Token: 0x06028841 RID: 165953 RVA: 0x00A0DB83 File Offset: 0x00A0BD83
		public unsafe bool 子弹碰撞障碍销毁
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x170062A4 RID: 25252
		// (get) Token: 0x06028842 RID: 165954 RVA: 0x00A0DB94 File Offset: 0x00A0BD94
		// (set) Token: 0x06028843 RID: 165955 RVA: 0x00A0DBA4 File Offset: 0x00A0BDA4
		public unsafe bool 子弹碰撞单位销毁
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x170062A5 RID: 25253
		// (get) Token: 0x06028844 RID: 165956 RVA: 0x00A0DBB5 File Offset: 0x00A0BDB5
		// (set) Token: 0x06028845 RID: 165957 RVA: 0x00A0DBC9 File Offset: 0x00A0BDC9
		public unsafe TEnumAsByte<AkiClient.Game.Aki.Character.BaseCharacter.EBulletType> 子弹类型
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170062A6 RID: 25254
		// (get) Token: 0x06028846 RID: 165958 RVA: 0x00A0DBDE File Offset: 0x00A0BDDE
		// (set) Token: 0x06028847 RID: 165959 RVA: 0x00A0DBF2 File Offset: 0x00A0BDF2
		public unsafe TEnumAsByte<AkiClient.Game.Aki.Character.BaseCharacter.EBulletHitDirectionType> 子弹受击类型角度判断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170062A7 RID: 25255
		// (get) Token: 0x06028848 RID: 165960 RVA: 0x00A0DC07 File Offset: 0x00A0BE07
		// (set) Token: 0x06028849 RID: 165961 RVA: 0x00A0DC17 File Offset: 0x00A0BE17
		public unsafe int 弹反通道
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170062A8 RID: 25256
		// (get) Token: 0x0602884A RID: 165962 RVA: 0x00A0DC28 File Offset: 0x00A0BE28
		// (set) Token: 0x0602884B RID: 165963 RVA: 0x00A0DC38 File Offset: 0x00A0BE38
		public unsafe bool 开启水面交互
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x170062A9 RID: 25257
		// (get) Token: 0x0602884C RID: 165964 RVA: 0x00A0DC4C File Offset: 0x00A0BE4C
		// (set) Token: 0x0602884D RID: 165965 RVA: 0x00A0DC85 File Offset: 0x00A0BE85
		[Nullable(1)]
		public FGameplayTagContainer 预设标签
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._预设标签) == null)
				{
					result = (this._预设标签 = new FGameplayTagContainer(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_14, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_14, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170062AA RID: 25258
		// (get) Token: 0x0602884E RID: 165966 RVA: 0x00A0DCA6 File Offset: 0x00A0BEA6
		// (set) Token: 0x0602884F RID: 165967 RVA: 0x00A0DCBA File Offset: 0x00A0BEBA
		[Nullable(1)]
		public unsafe string 只碰撞胶囊体
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BulletLogicType_C.__PropertyOffset_15)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BulletLogicType_C.__PropertyOffset_15)), value);
			}
		}

		// Token: 0x170062AB RID: 25259
		// (get) Token: 0x06028850 RID: 165968 RVA: 0x00A0DCCF File Offset: 0x00A0BECF
		// (set) Token: 0x06028851 RID: 165969 RVA: 0x00A0DCDF File Offset: 0x00A0BEDF
		public unsafe bool 忽略水体
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x170062AC RID: 25260
		// (get) Token: 0x06028852 RID: 165970 RVA: 0x00A0DCF0 File Offset: 0x00A0BEF0
		// (set) Token: 0x06028853 RID: 165971 RVA: 0x00A0DD00 File Offset: 0x00A0BF00
		public unsafe bool 冰冻时销毁
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x170062AD RID: 25261
		// (get) Token: 0x06028854 RID: 165972 RVA: 0x00A0DD11 File Offset: 0x00A0BF11
		// (set) Token: 0x06028855 RID: 165973 RVA: 0x00A0DD21 File Offset: 0x00A0BF21
		public unsafe bool 开启空气墙交互
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BulletLogicType_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x06028856 RID: 165974 RVA: 0x00A0DD32 File Offset: 0x00A0BF32
		protected BulletLogicType_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401551D RID: 87325
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Core/Fight/BulletLogicType.BulletLogicType_C";

		// Token: 0x0401551E RID: 87326
		private static IntPtr _ClassPtr;

		// Token: 0x0401551F RID: 87327
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015520 RID: 87328
		internal static int __PropertyOffset_0;

		// Token: 0x04015521 RID: 87329
		internal static int __PropertyOffset_1;

		// Token: 0x04015522 RID: 87330
		internal static int __PropertyOffset_2;

		// Token: 0x04015523 RID: 87331
		internal static int __PropertyOffset_3;

		// Token: 0x04015524 RID: 87332
		internal static int __PropertyOffset_4;

		// Token: 0x04015525 RID: 87333
		internal static int __PropertyOffset_5;

		// Token: 0x04015526 RID: 87334
		internal static int __PropertyOffset_6;

		// Token: 0x04015527 RID: 87335
		internal static int __PropertyOffset_7;

		// Token: 0x04015528 RID: 87336
		internal static int __PropertyOffset_8;

		// Token: 0x04015529 RID: 87337
		internal static int __PropertyOffset_9;

		// Token: 0x0401552A RID: 87338
		internal static int __PropertyOffset_10;

		// Token: 0x0401552B RID: 87339
		internal static int __PropertyOffset_11;

		// Token: 0x0401552C RID: 87340
		internal static int __PropertyOffset_12;

		// Token: 0x0401552D RID: 87341
		internal static int __PropertyOffset_13;

		// Token: 0x0401552E RID: 87342
		internal static int __PropertyOffset_14;

		// Token: 0x0401552F RID: 87343
		[Nullable(2)]
		private FGameplayTagContainer _预设标签;

		// Token: 0x04015530 RID: 87344
		internal static int __PropertyOffset_15;

		// Token: 0x04015531 RID: 87345
		internal static int __PropertyOffset_16;

		// Token: 0x04015532 RID: 87346
		internal static int __PropertyOffset_17;

		// Token: 0x04015533 RID: 87347
		internal static int __PropertyOffset_18;
	}
}
