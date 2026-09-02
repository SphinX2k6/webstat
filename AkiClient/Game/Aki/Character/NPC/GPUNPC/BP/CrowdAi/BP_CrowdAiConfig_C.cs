using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.GPUNPC.BP.CrowdAi
{
	// Token: 0x020040E5 RID: 16613
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/GPUNPC/BP/CrowdAi/BP_CrowdAiConfig.BP_CrowdAiConfig_C")]
	[UnrealStructLayout(200, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 196)]
	public class BP_CrowdAiConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602BC4B RID: 179275 RVA: 0x00A88A47 File Offset: 0x00A86C47
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CrowdAiConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/GPUNPC/BP/CrowdAi/BP_CrowdAiConfig.BP_CrowdAiConfig_C");
			}
			return BP_CrowdAiConfig_C._ClassPtr;
		}

		// Token: 0x0602BC4C RID: 179276 RVA: 0x00A88A6C File Offset: 0x00A86C6C
		public BP_CrowdAiConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_CrowdAiConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602BC4D RID: 179277 RVA: 0x00A88A94 File Offset: 0x00A86C94
		public BP_CrowdAiConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CrowdAiConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700740B RID: 29707
		// (get) Token: 0x0602BC4E RID: 179278 RVA: 0x00A88AC7 File Offset: 0x00A86CC7
		// (set) Token: 0x0602BC4F RID: 179279 RVA: 0x00A88AD7 File Offset: 0x00A86CD7
		public unsafe bool 启用Navmesh贴地修正
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700740C RID: 29708
		// (get) Token: 0x0602BC50 RID: 179280 RVA: 0x00A88AE8 File Offset: 0x00A86CE8
		// (set) Token: 0x0602BC51 RID: 179281 RVA: 0x00A88AF8 File Offset: 0x00A86CF8
		public unsafe float 分组最大距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700740D RID: 29709
		// (get) Token: 0x0602BC52 RID: 179282 RVA: 0x00A88B0C File Offset: 0x00A86D0C
		// (set) Token: 0x0602BC53 RID: 179283 RVA: 0x00A88B45 File Offset: 0x00A86D45
		public TArray<BP_Struct_CrowdAiBoidConfig> Boid种类配置
		{
			get
			{
				base.FastCheckIsValid();
				TArray<BP_Struct_CrowdAiBoidConfig> result;
				if ((result = this._Boid种类配置) == null)
				{
					result = (this._Boid种类配置 = new TArray<BP_Struct_CrowdAiBoidConfig>(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.Boid种类配置.CopyAssign(value);
			}
		}

		// Token: 0x1700740E RID: 29710
		// (get) Token: 0x0602BC54 RID: 179284 RVA: 0x00A88B53 File Offset: 0x00A86D53
		// (set) Token: 0x0602BC55 RID: 179285 RVA: 0x00A88B63 File Offset: 0x00A86D63
		public unsafe bool 启用传送
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700740F RID: 29711
		// (get) Token: 0x0602BC56 RID: 179286 RVA: 0x00A88B74 File Offset: 0x00A86D74
		// (set) Token: 0x0602BC57 RID: 179287 RVA: 0x00A88B84 File Offset: 0x00A86D84
		public unsafe float 传送最小计数时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007410 RID: 29712
		// (get) Token: 0x0602BC58 RID: 179288 RVA: 0x00A88B95 File Offset: 0x00A86D95
		// (set) Token: 0x0602BC59 RID: 179289 RVA: 0x00A88BA5 File Offset: 0x00A86DA5
		public unsafe float 传送最大计数时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007411 RID: 29713
		// (get) Token: 0x0602BC5A RID: 179290 RVA: 0x00A88BB6 File Offset: 0x00A86DB6
		// (set) Token: 0x0602BC5B RID: 179291 RVA: 0x00A88BC6 File Offset: 0x00A86DC6
		public unsafe float 传送目标最大半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17007412 RID: 29714
		// (get) Token: 0x0602BC5C RID: 179292 RVA: 0x00A88BD7 File Offset: 0x00A86DD7
		// (set) Token: 0x0602BC5D RID: 179293 RVA: 0x00A88BE7 File Offset: 0x00A86DE7
		public unsafe float 传送目标最小半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17007413 RID: 29715
		// (get) Token: 0x0602BC5E RID: 179294 RVA: 0x00A88BF8 File Offset: 0x00A86DF8
		// (set) Token: 0x0602BC5F RID: 179295 RVA: 0x00A88C08 File Offset: 0x00A86E08
		public unsafe float 玩家移动半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17007414 RID: 29716
		// (get) Token: 0x0602BC60 RID: 179296 RVA: 0x00A88C19 File Offset: 0x00A86E19
		// (set) Token: 0x0602BC61 RID: 179297 RVA: 0x00A88C29 File Offset: 0x00A86E29
		public unsafe float 玩家待机半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17007415 RID: 29717
		// (get) Token: 0x0602BC62 RID: 179298 RVA: 0x00A88C3A File Offset: 0x00A86E3A
		// (set) Token: 0x0602BC63 RID: 179299 RVA: 0x00A88C4A File Offset: 0x00A86E4A
		public unsafe float 玩家半径变化时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17007416 RID: 29718
		// (get) Token: 0x0602BC64 RID: 179300 RVA: 0x00A88C5B File Offset: 0x00A86E5B
		// (set) Token: 0x0602BC65 RID: 179301 RVA: 0x00A88C6B File Offset: 0x00A86E6B
		public unsafe bool 启用跟随区域限制
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007417 RID: 29719
		// (get) Token: 0x0602BC66 RID: 179302 RVA: 0x00A88C7C File Offset: 0x00A86E7C
		// (set) Token: 0x0602BC67 RID: 179303 RVA: 0x00A88C8C File Offset: 0x00A86E8C
		public unsafe float 停驻最小目标距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17007418 RID: 29720
		// (get) Token: 0x0602BC68 RID: 179304 RVA: 0x00A88C9D File Offset: 0x00A86E9D
		// (set) Token: 0x0602BC69 RID: 179305 RVA: 0x00A88CAD File Offset: 0x00A86EAD
		public unsafe float 触发传送最小垂直距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17007419 RID: 29721
		// (get) Token: 0x0602BC6A RID: 179306 RVA: 0x00A88CBE File Offset: 0x00A86EBE
		// (set) Token: 0x0602BC6B RID: 179307 RVA: 0x00A88CCE File Offset: 0x00A86ECE
		public unsafe float 触发传送最小水平距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700741A RID: 29722
		// (get) Token: 0x0602BC6C RID: 179308 RVA: 0x00A88CDF File Offset: 0x00A86EDF
		// (set) Token: 0x0602BC6D RID: 179309 RVA: 0x00A88CEF File Offset: 0x00A86EEF
		public unsafe float 暂停传送最大水平速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700741B RID: 29723
		// (get) Token: 0x0602BC6E RID: 179310 RVA: 0x00A88D00 File Offset: 0x00A86F00
		// (set) Token: 0x0602BC6F RID: 179311 RVA: 0x00A88D10 File Offset: 0x00A86F10
		public unsafe int 最大尝试寻点次数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x1700741C RID: 29724
		// (get) Token: 0x0602BC70 RID: 179312 RVA: 0x00A88D21 File Offset: 0x00A86F21
		// (set) Token: 0x0602BC71 RID: 179313 RVA: 0x00A88D31 File Offset: 0x00A86F31
		public unsafe float 跟随扇形区域夹角
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x1700741D RID: 29725
		// (get) Token: 0x0602BC72 RID: 179314 RVA: 0x00A88D42 File Offset: 0x00A86F42
		// (set) Token: 0x0602BC73 RID: 179315 RVA: 0x00A88D52 File Offset: 0x00A86F52
		public unsafe float 跟随扇形区域两边长度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700741E RID: 29726
		// (get) Token: 0x0602BC74 RID: 179316 RVA: 0x00A88D63 File Offset: 0x00A86F63
		// (set) Token: 0x0602BC75 RID: 179317 RVA: 0x00A88D73 File Offset: 0x00A86F73
		public unsafe float 跟随扇形区域底边半长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x1700741F RID: 29727
		// (get) Token: 0x0602BC76 RID: 179318 RVA: 0x00A88D84 File Offset: 0x00A86F84
		// (set) Token: 0x0602BC77 RID: 179319 RVA: 0x00A88D94 File Offset: 0x00A86F94
		public unsafe float 跟随扇形区域底边距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17007420 RID: 29728
		// (get) Token: 0x0602BC78 RID: 179320 RVA: 0x00A88DA5 File Offset: 0x00A86FA5
		// (set) Token: 0x0602BC79 RID: 179321 RVA: 0x00A88DB5 File Offset: 0x00A86FB5
		public unsafe float 停驻计时时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17007421 RID: 29729
		// (get) Token: 0x0602BC7A RID: 179322 RVA: 0x00A88DC6 File Offset: 0x00A86FC6
		// (set) Token: 0x0602BC7B RID: 179323 RVA: 0x00A88DD6 File Offset: 0x00A86FD6
		public unsafe float 停驻最大速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17007422 RID: 29730
		// (get) Token: 0x0602BC7C RID: 179324 RVA: 0x00A88DE7 File Offset: 0x00A86FE7
		// (set) Token: 0x0602BC7D RID: 179325 RVA: 0x00A88DF7 File Offset: 0x00A86FF7
		public unsafe float 出生最大随机延迟时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17007423 RID: 29731
		// (get) Token: 0x0602BC7E RID: 179326 RVA: 0x00A88E08 File Offset: 0x00A87008
		// (set) Token: 0x0602BC7F RID: 179327 RVA: 0x00A88E18 File Offset: 0x00A87018
		public unsafe float 销毁最大随机延迟时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17007424 RID: 29732
		// (get) Token: 0x0602BC80 RID: 179328 RVA: 0x00A88E29 File Offset: 0x00A87029
		// (set) Token: 0x0602BC81 RID: 179329 RVA: 0x00A88E39 File Offset: 0x00A87039
		public unsafe float 组寻路间隔
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CrowdAiConfig_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x0602BC82 RID: 179330 RVA: 0x00A88E4A File Offset: 0x00A8704A
		protected BP_CrowdAiConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040181D2 RID: 98770
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/GPUNPC/BP/CrowdAi/BP_CrowdAiConfig.BP_CrowdAiConfig_C";

		// Token: 0x040181D3 RID: 98771
		private static IntPtr _ClassPtr;

		// Token: 0x040181D4 RID: 98772
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040181D5 RID: 98773
		internal static int __PropertyOffset_0;

		// Token: 0x040181D6 RID: 98774
		internal static int __PropertyOffset_1;

		// Token: 0x040181D7 RID: 98775
		internal static int __PropertyOffset_2;

		// Token: 0x040181D8 RID: 98776
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BP_Struct_CrowdAiBoidConfig> _Boid种类配置;

		// Token: 0x040181D9 RID: 98777
		internal static int __PropertyOffset_3;

		// Token: 0x040181DA RID: 98778
		internal static int __PropertyOffset_4;

		// Token: 0x040181DB RID: 98779
		internal static int __PropertyOffset_5;

		// Token: 0x040181DC RID: 98780
		internal static int __PropertyOffset_6;

		// Token: 0x040181DD RID: 98781
		internal static int __PropertyOffset_7;

		// Token: 0x040181DE RID: 98782
		internal static int __PropertyOffset_8;

		// Token: 0x040181DF RID: 98783
		internal static int __PropertyOffset_9;

		// Token: 0x040181E0 RID: 98784
		internal static int __PropertyOffset_10;

		// Token: 0x040181E1 RID: 98785
		internal static int __PropertyOffset_11;

		// Token: 0x040181E2 RID: 98786
		internal static int __PropertyOffset_12;

		// Token: 0x040181E3 RID: 98787
		internal static int __PropertyOffset_13;

		// Token: 0x040181E4 RID: 98788
		internal static int __PropertyOffset_14;

		// Token: 0x040181E5 RID: 98789
		internal static int __PropertyOffset_15;

		// Token: 0x040181E6 RID: 98790
		internal static int __PropertyOffset_16;

		// Token: 0x040181E7 RID: 98791
		internal static int __PropertyOffset_17;

		// Token: 0x040181E8 RID: 98792
		internal static int __PropertyOffset_18;

		// Token: 0x040181E9 RID: 98793
		internal static int __PropertyOffset_19;

		// Token: 0x040181EA RID: 98794
		internal static int __PropertyOffset_20;

		// Token: 0x040181EB RID: 98795
		internal static int __PropertyOffset_21;

		// Token: 0x040181EC RID: 98796
		internal static int __PropertyOffset_22;

		// Token: 0x040181ED RID: 98797
		internal static int __PropertyOffset_23;

		// Token: 0x040181EE RID: 98798
		internal static int __PropertyOffset_24;

		// Token: 0x040181EF RID: 98799
		internal static int __PropertyOffset_25;
	}
}
