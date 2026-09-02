using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.GPUNPC.BP.CrowdAi
{
	// Token: 0x020040E6 RID: 16614
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/GPUNPC/BP/CrowdAi/BP_Struct_CrowdAiBoidConfig.BP_Struct_CrowdAiBoidConfig")]
	[UnrealStructLayout(320, 16, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 312)]
	public class BP_Struct_CrowdAiBoidConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602BC83 RID: 179331 RVA: 0x00A88E53 File Offset: 0x00A87053
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (BP_Struct_CrowdAiBoidConfig._ScriptStructPtr != 0) ? BP_Struct_CrowdAiBoidConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/NPC/GPUNPC/BP/CrowdAi/BP_Struct_CrowdAiBoidConfig.BP_Struct_CrowdAiBoidConfig", ref BP_Struct_CrowdAiBoidConfig._ScriptStructPtr);
		}

		// Token: 0x17007425 RID: 29733
		// (get) Token: 0x0602BC84 RID: 179332 RVA: 0x00A88E77 File Offset: 0x00A87077
		// (set) Token: 0x0602BC85 RID: 179333 RVA: 0x00A88E87 File Offset: 0x00A87087
		public unsafe float 半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007426 RID: 29734
		// (get) Token: 0x0602BC86 RID: 179334 RVA: 0x00A88E98 File Offset: 0x00A87098
		// (set) Token: 0x0602BC87 RID: 179335 RVA: 0x00A88EA8 File Offset: 0x00A870A8
		public unsafe float 半高
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007427 RID: 29735
		// (get) Token: 0x0602BC88 RID: 179336 RVA: 0x00A88EB9 File Offset: 0x00A870B9
		// (set) Token: 0x0602BC89 RID: 179337 RVA: 0x00A88ECD File Offset: 0x00A870CD
		public unsafe FTransform 相对变换
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007428 RID: 29736
		// (get) Token: 0x0602BC8A RID: 179338 RVA: 0x00A88EE2 File Offset: 0x00A870E2
		// (set) Token: 0x0602BC8B RID: 179339 RVA: 0x00A88EF2 File Offset: 0x00A870F2
		public unsafe float 最大速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007429 RID: 29737
		// (get) Token: 0x0602BC8C RID: 179340 RVA: 0x00A88F03 File Offset: 0x00A87103
		// (set) Token: 0x0602BC8D RID: 179341 RVA: 0x00A88F13 File Offset: 0x00A87113
		public unsafe float 最大加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700742A RID: 29738
		// (get) Token: 0x0602BC8E RID: 179342 RVA: 0x00A88F24 File Offset: 0x00A87124
		// (set) Token: 0x0602BC8F RID: 179343 RVA: 0x00A88F34 File Offset: 0x00A87134
		public unsafe float 移动半径缩放系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700742B RID: 29739
		// (get) Token: 0x0602BC90 RID: 179344 RVA: 0x00A88F45 File Offset: 0x00A87145
		// (set) Token: 0x0602BC91 RID: 179345 RVA: 0x00A88F55 File Offset: 0x00A87155
		public unsafe float 地面转向摩擦力
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700742C RID: 29740
		// (get) Token: 0x0602BC92 RID: 179346 RVA: 0x00A88F66 File Offset: 0x00A87166
		// (set) Token: 0x0602BC93 RID: 179347 RVA: 0x00A88F76 File Offset: 0x00A87176
		public unsafe float 转向插值速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700742D RID: 29741
		// (get) Token: 0x0602BC94 RID: 179348 RVA: 0x00A88F87 File Offset: 0x00A87187
		// (set) Token: 0x0602BC95 RID: 179349 RVA: 0x00A88F97 File Offset: 0x00A87197
		public unsafe float 移动表现阈值速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700742E RID: 29742
		// (get) Token: 0x0602BC96 RID: 179350 RVA: 0x00A88FA8 File Offset: 0x00A871A8
		// (set) Token: 0x0602BC97 RID: 179351 RVA: 0x00A88FB8 File Offset: 0x00A871B8
		public unsafe float 待机表现阈值速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700742F RID: 29743
		// (get) Token: 0x0602BC98 RID: 179352 RVA: 0x00A88FC9 File Offset: 0x00A871C9
		// (set) Token: 0x0602BC99 RID: 179353 RVA: 0x00A88FD9 File Offset: 0x00A871D9
		public unsafe float 斥力额外半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17007430 RID: 29744
		// (get) Token: 0x0602BC9A RID: 179354 RVA: 0x00A88FEA File Offset: 0x00A871EA
		// (set) Token: 0x0602BC9B RID: 179355 RVA: 0x00A88FFA File Offset: 0x00A871FA
		public unsafe float 移动斥力额外半径缩放系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17007431 RID: 29745
		// (get) Token: 0x0602BC9C RID: 179356 RVA: 0x00A8900B File Offset: 0x00A8720B
		// (set) Token: 0x0602BC9D RID: 179357 RVA: 0x00A8901B File Offset: 0x00A8721B
		public unsafe float 临近目标减速距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17007432 RID: 29746
		// (get) Token: 0x0602BC9E RID: 179358 RVA: 0x00A8902C File Offset: 0x00A8722C
		// (set) Token: 0x0602BC9F RID: 179359 RVA: 0x00A8903C File Offset: 0x00A8723C
		public unsafe float 边界空气墙距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17007433 RID: 29747
		// (get) Token: 0x0602BCA0 RID: 179360 RVA: 0x00A8904D File Offset: 0x00A8724D
		// (set) Token: 0x0602BCA1 RID: 179361 RVA: 0x00A8905D File Offset: 0x00A8725D
		public unsafe float 额外探测距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17007434 RID: 29748
		// (get) Token: 0x0602BCA2 RID: 179362 RVA: 0x00A8906E File Offset: 0x00A8726E
		// (set) Token: 0x0602BCA3 RID: 179363 RVA: 0x00A8907E File Offset: 0x00A8727E
		public unsafe float 待机表演最小冷却时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17007435 RID: 29749
		// (get) Token: 0x0602BCA4 RID: 179364 RVA: 0x00A8908F File Offset: 0x00A8728F
		// (set) Token: 0x0602BCA5 RID: 179365 RVA: 0x00A8909F File Offset: 0x00A8729F
		public unsafe float 待机表演最大冷却时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17007436 RID: 29750
		// (get) Token: 0x0602BCA6 RID: 179366 RVA: 0x00A890B0 File Offset: 0x00A872B0
		// (set) Token: 0x0602BCA7 RID: 179367 RVA: 0x00A890C0 File Offset: 0x00A872C0
		public unsafe float 待机表演最大比例
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17007437 RID: 29751
		// (get) Token: 0x0602BCA8 RID: 179368 RVA: 0x00A890D4 File Offset: 0x00A872D4
		// (set) Token: 0x0602BCA9 RID: 179369 RVA: 0x00A89117 File Offset: 0x00A87317
		public TMap<int, EKuroCrowdAiBoidAnimState> 状态配置
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, EKuroCrowdAiBoidAnimState> result;
				if ((result = this._状态配置) == null)
				{
					result = (this._状态配置 = new TMap<int, EKuroCrowdAiBoidAnimState>(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_18, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.状态配置.CopyAssign(value);
			}
		}

		// Token: 0x17007438 RID: 29752
		// (get) Token: 0x0602BCAA RID: 179370 RVA: 0x00A89128 File Offset: 0x00A87328
		// (set) Token: 0x0602BCAB RID: 179371 RVA: 0x00A8916B File Offset: 0x00A8736B
		public TArray<FKuroCrowdAiAnimSequenceConfig> 动画配置
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FKuroCrowdAiAnimSequenceConfig> result;
				if ((result = this._动画配置) == null)
				{
					result = (this._动画配置 = new TArray<FKuroCrowdAiAnimSequenceConfig>(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_19, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.动画配置.CopyAssign(value);
			}
		}

		// Token: 0x17007439 RID: 29753
		// (get) Token: 0x0602BCAC RID: 179372 RVA: 0x00A8917C File Offset: 0x00A8737C
		// (set) Token: 0x0602BCAD RID: 179373 RVA: 0x00A891BF File Offset: 0x00A873BF
		public TMap<UKuroMaterialControllerDataAsset, int> 材质贴图DA配置
		{
			get
			{
				base.FastCheckIsValid();
				TMap<UKuroMaterialControllerDataAsset, int> result;
				if ((result = this._材质贴图DA配置) == null)
				{
					result = (this._材质贴图DA配置 = new TMap<UKuroMaterialControllerDataAsset, int>(base.NativePtr + (IntPtr)BP_Struct_CrowdAiBoidConfig.__PropertyOffset_20, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.材质贴图DA配置.CopyAssign(value);
			}
		}

		// Token: 0x1700743A RID: 29754
		// (get) Token: 0x0602BCAE RID: 179374 RVA: 0x00A891CD File Offset: 0x00A873CD
		// (set) Token: 0x0602BCAF RID: 179375 RVA: 0x00A891E1 File Offset: 0x00A873E1
		[Nullable(2)]
		public unsafe GPUNPCData_C GpuNpcDa
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<GPUNPCData_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Struct_CrowdAiBoidConfig.__PropertyOffset_21);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Struct_CrowdAiBoidConfig.__PropertyOffset_21, value);
			}
		}

		// Token: 0x0602BCB0 RID: 179376 RVA: 0x00A891F6 File Offset: 0x00A873F6
		public BP_Struct_CrowdAiBoidConfig()
		{
		}

		// Token: 0x0602BCB1 RID: 179377 RVA: 0x00A89200 File Offset: 0x00A87400
		public BP_Struct_CrowdAiBoidConfig(float 半径, float 半高, FTransform 相对变换, float 最大速度, float 最大加速度, float 移动半径缩放系数, float 地面转向摩擦力, float 转向插值速度, float 移动表现阈值速度, float 待机表现阈值速度, float 斥力额外半径, float 移动斥力额外半径缩放系数, float 临近目标减速距离, float 边界空气墙距离, float 额外探测距离, float 待机表演最小冷却时间, float 待机表演最大冷却时间, float 待机表演最大比例, TMap<int, EKuroCrowdAiBoidAnimState> 状态配置, TArray<FKuroCrowdAiAnimSequenceConfig> 动画配置, TMap<UKuroMaterialControllerDataAsset, int> 材质贴图DA配置, GPUNPCData_C GpuNpcDa)
		{
			this.半径 = 半径;
			this.半高 = 半高;
			this.相对变换 = 相对变换;
			this.最大速度 = 最大速度;
			this.最大加速度 = 最大加速度;
			this.移动半径缩放系数 = 移动半径缩放系数;
			this.地面转向摩擦力 = 地面转向摩擦力;
			this.转向插值速度 = 转向插值速度;
			this.移动表现阈值速度 = 移动表现阈值速度;
			this.待机表现阈值速度 = 待机表现阈值速度;
			this.斥力额外半径 = 斥力额外半径;
			this.移动斥力额外半径缩放系数 = 移动斥力额外半径缩放系数;
			this.临近目标减速距离 = 临近目标减速距离;
			this.边界空气墙距离 = 边界空气墙距离;
			this.额外探测距离 = 额外探测距离;
			this.待机表演最小冷却时间 = 待机表演最小冷却时间;
			this.待机表演最大冷却时间 = 待机表演最大冷却时间;
			this.待机表演最大比例 = 待机表演最大比例;
			this.状态配置 = 状态配置;
			this.动画配置 = 动画配置;
			this.材质贴图DA配置 = 材质贴图DA配置;
			this.GpuNpcDa = GpuNpcDa;
		}

		// Token: 0x0602BCB2 RID: 179378 RVA: 0x00A892C0 File Offset: 0x00A874C0
		protected override IntPtr GetUStructPtr()
		{
			return BP_Struct_CrowdAiBoidConfig.StaticStruct();
		}

		// Token: 0x0602BCB3 RID: 179379 RVA: 0x00A892CC File Offset: 0x00A874CC
		[NullableContext(2)]
		public BP_Struct_CrowdAiBoidConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602BCB4 RID: 179380 RVA: 0x00A892D6 File Offset: 0x00A874D6
		public BP_Struct_CrowdAiBoidConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602BCB5 RID: 179381 RVA: 0x00A892E1 File Offset: 0x00A874E1
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new BP_Struct_CrowdAiBoidConfig(Pointer, false, true);
		}

		// Token: 0x0602BCB6 RID: 179382 RVA: 0x00A892EB File Offset: 0x00A874EB
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new BP_Struct_CrowdAiBoidConfig(Pointer, MemoryOwner);
		}

		// Token: 0x040181F0 RID: 98800
		public const string __ObjectPath = "/Game/Aki/Character/NPC/GPUNPC/BP/CrowdAi/BP_Struct_CrowdAiBoidConfig.BP_Struct_CrowdAiBoidConfig";

		// Token: 0x040181F1 RID: 98801
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040181F2 RID: 98802
		internal static int __PropertyOffset_0;

		// Token: 0x040181F3 RID: 98803
		internal static int __PropertyOffset_1;

		// Token: 0x040181F4 RID: 98804
		internal static int __PropertyOffset_2;

		// Token: 0x040181F5 RID: 98805
		internal static int __PropertyOffset_3;

		// Token: 0x040181F6 RID: 98806
		internal static int __PropertyOffset_4;

		// Token: 0x040181F7 RID: 98807
		internal static int __PropertyOffset_5;

		// Token: 0x040181F8 RID: 98808
		internal static int __PropertyOffset_6;

		// Token: 0x040181F9 RID: 98809
		internal static int __PropertyOffset_7;

		// Token: 0x040181FA RID: 98810
		internal static int __PropertyOffset_8;

		// Token: 0x040181FB RID: 98811
		internal static int __PropertyOffset_9;

		// Token: 0x040181FC RID: 98812
		internal static int __PropertyOffset_10;

		// Token: 0x040181FD RID: 98813
		internal static int __PropertyOffset_11;

		// Token: 0x040181FE RID: 98814
		internal static int __PropertyOffset_12;

		// Token: 0x040181FF RID: 98815
		internal static int __PropertyOffset_13;

		// Token: 0x04018200 RID: 98816
		internal static int __PropertyOffset_14;

		// Token: 0x04018201 RID: 98817
		internal static int __PropertyOffset_15;

		// Token: 0x04018202 RID: 98818
		internal static int __PropertyOffset_16;

		// Token: 0x04018203 RID: 98819
		internal static int __PropertyOffset_17;

		// Token: 0x04018204 RID: 98820
		internal static int __PropertyOffset_18;

		// Token: 0x04018205 RID: 98821
		[Nullable(2)]
		private TMap<int, EKuroCrowdAiBoidAnimState> _状态配置;

		// Token: 0x04018206 RID: 98822
		internal static int __PropertyOffset_19;

		// Token: 0x04018207 RID: 98823
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FKuroCrowdAiAnimSequenceConfig> _动画配置;

		// Token: 0x04018208 RID: 98824
		internal static int __PropertyOffset_20;

		// Token: 0x04018209 RID: 98825
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<UKuroMaterialControllerDataAsset, int> _材质贴图DA配置;

		// Token: 0x0401820A RID: 98826
		internal static int __PropertyOffset_21;
	}
}
