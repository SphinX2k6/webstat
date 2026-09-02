using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Tuanzi.CommonConfig
{
	// Token: 0x020040DC RID: 16604
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Tuanzi/CommonConfig/BP_DangoGlobalConfig.BP_DangoGlobalConfig_C")]
	[UnrealStructLayout(336, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 336)]
	public class BP_DangoGlobalConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B77D RID: 178045 RVA: 0x00A7D844 File Offset: 0x00A7BA44
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DangoGlobalConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Tuanzi/CommonConfig/BP_DangoGlobalConfig.BP_DangoGlobalConfig_C");
			}
			return BP_DangoGlobalConfig_C._ClassPtr;
		}

		// Token: 0x0602B77E RID: 178046 RVA: 0x00A7D868 File Offset: 0x00A7BA68
		public BP_DangoGlobalConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_DangoGlobalConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B77F RID: 178047 RVA: 0x00A7D890 File Offset: 0x00A7BA90
		[NullableContext(1)]
		public BP_DangoGlobalConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DangoGlobalConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007204 RID: 29188
		// (get) Token: 0x0602B780 RID: 178048 RVA: 0x00A7D8C3 File Offset: 0x00A7BAC3
		// (set) Token: 0x0602B781 RID: 178049 RVA: 0x00A7D8D3 File Offset: 0x00A7BAD3
		public unsafe int 跳跃前摇时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007205 RID: 29189
		// (get) Token: 0x0602B782 RID: 178050 RVA: 0x00A7D8E4 File Offset: 0x00A7BAE4
		// (set) Token: 0x0602B783 RID: 178051 RVA: 0x00A7D8F4 File Offset: 0x00A7BAF4
		public unsafe int 跳跃移动时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007206 RID: 29190
		// (get) Token: 0x0602B784 RID: 178052 RVA: 0x00A7D905 File Offset: 0x00A7BB05
		// (set) Token: 0x0602B785 RID: 178053 RVA: 0x00A7D915 File Offset: 0x00A7BB15
		public unsafe int 跳跃后摇时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007207 RID: 29191
		// (get) Token: 0x0602B786 RID: 178054 RVA: 0x00A7D926 File Offset: 0x00A7BB26
		// (set) Token: 0x0602B787 RID: 178055 RVA: 0x00A7D936 File Offset: 0x00A7BB36
		public unsafe int 跳跃旋转速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007208 RID: 29192
		// (get) Token: 0x0602B788 RID: 178056 RVA: 0x00A7D947 File Offset: 0x00A7BB47
		// (set) Token: 0x0602B789 RID: 178057 RVA: 0x00A7D957 File Offset: 0x00A7BB57
		public unsafe int 跳跃高度偏移基准
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007209 RID: 29193
		// (get) Token: 0x0602B78A RID: 178058 RVA: 0x00A7D968 File Offset: 0x00A7BB68
		// (set) Token: 0x0602B78B RID: 178059 RVA: 0x00A7D978 File Offset: 0x00A7BB78
		public unsafe int 跳跃上升偏移曲线高度范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700720A RID: 29194
		// (get) Token: 0x0602B78C RID: 178060 RVA: 0x00A7D989 File Offset: 0x00A7BB89
		// (set) Token: 0x0602B78D RID: 178061 RVA: 0x00A7D999 File Offset: 0x00A7BB99
		public unsafe int 跳跃下降偏移曲线高度范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700720B RID: 29195
		// (get) Token: 0x0602B78E RID: 178062 RVA: 0x00A7D9AA File Offset: 0x00A7BBAA
		// (set) Token: 0x0602B78F RID: 178063 RVA: 0x00A7D9BE File Offset: 0x00A7BBBE
		public unsafe UCurveFloat 跳跃上升偏移曲线
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DangoGlobalConfig_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DangoGlobalConfig_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x1700720C RID: 29196
		// (get) Token: 0x0602B790 RID: 178064 RVA: 0x00A7D9D3 File Offset: 0x00A7BBD3
		// (set) Token: 0x0602B791 RID: 178065 RVA: 0x00A7D9E7 File Offset: 0x00A7BBE7
		public unsafe UCurveFloat 跳跃下降偏移曲线
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DangoGlobalConfig_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DangoGlobalConfig_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x1700720D RID: 29197
		// (get) Token: 0x0602B792 RID: 178066 RVA: 0x00A7D9FC File Offset: 0x00A7BBFC
		// (set) Token: 0x0602B793 RID: 178067 RVA: 0x00A7DA0C File Offset: 0x00A7BC0C
		public unsafe int 跳跃中镜头臂长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700720E RID: 29198
		// (get) Token: 0x0602B794 RID: 178068 RVA: 0x00A7DA1D File Offset: 0x00A7BC1D
		// (set) Token: 0x0602B795 RID: 178069 RVA: 0x00A7DA2D File Offset: 0x00A7BC2D
		public unsafe int 跳跃中镜头追踪时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700720F RID: 29199
		// (get) Token: 0x0602B796 RID: 178070 RVA: 0x00A7DA3E File Offset: 0x00A7BC3E
		// (set) Token: 0x0602B797 RID: 178071 RVA: 0x00A7DA4E File Offset: 0x00A7BC4E
		public unsafe float 跳跃中镜头FOV
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17007210 RID: 29200
		// (get) Token: 0x0602B798 RID: 178072 RVA: 0x00A7DA60 File Offset: 0x00A7BC60
		// (set) Token: 0x0602B799 RID: 178073 RVA: 0x00A7DA99 File Offset: 0x00A7BC99
		[Nullable(1)]
		public SBaseCurve 跳跃中镜头曲线
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				SBaseCurve result;
				if ((result = this._跳跃中镜头曲线) == null)
				{
					result = (this._跳跃中镜头曲线 = new SBaseCurve(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_12, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SBaseCurve.StaticStruct(), base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007211 RID: 29201
		// (get) Token: 0x0602B79A RID: 178074 RVA: 0x00A7DABA File Offset: 0x00A7BCBA
		// (set) Token: 0x0602B79B RID: 178075 RVA: 0x00A7DACA File Offset: 0x00A7BCCA
		public unsafe int 跳跃前镜头死区距离基准
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17007212 RID: 29202
		// (get) Token: 0x0602B79C RID: 178076 RVA: 0x00A7DADB File Offset: 0x00A7BCDB
		// (set) Token: 0x0602B79D RID: 178077 RVA: 0x00A7DAEB File Offset: 0x00A7BCEB
		public unsafe int 跳跃前镜头臂长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17007213 RID: 29203
		// (get) Token: 0x0602B79E RID: 178078 RVA: 0x00A7DAFC File Offset: 0x00A7BCFC
		// (set) Token: 0x0602B79F RID: 178079 RVA: 0x00A7DB10 File Offset: 0x00A7BD10
		public unsafe FInt32Range 跳跃前镜头近距离基准范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17007214 RID: 29204
		// (get) Token: 0x0602B7A0 RID: 178080 RVA: 0x00A7DB25 File Offset: 0x00A7BD25
		// (set) Token: 0x0602B7A1 RID: 178081 RVA: 0x00A7DB39 File Offset: 0x00A7BD39
		public unsafe FInt32Range 跳跃前镜头近距离追踪时间范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17007215 RID: 29205
		// (get) Token: 0x0602B7A2 RID: 178082 RVA: 0x00A7DB4E File Offset: 0x00A7BD4E
		// (set) Token: 0x0602B7A3 RID: 178083 RVA: 0x00A7DB5E File Offset: 0x00A7BD5E
		public unsafe int 跳跃前镜头远距离基准
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17007216 RID: 29206
		// (get) Token: 0x0602B7A4 RID: 178084 RVA: 0x00A7DB6F File Offset: 0x00A7BD6F
		// (set) Token: 0x0602B7A5 RID: 178085 RVA: 0x00A7DB7F File Offset: 0x00A7BD7F
		public unsafe int 跳跃前镜头远距离追踪时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17007217 RID: 29207
		// (get) Token: 0x0602B7A6 RID: 178086 RVA: 0x00A7DB90 File Offset: 0x00A7BD90
		// (set) Token: 0x0602B7A7 RID: 178087 RVA: 0x00A7DBA0 File Offset: 0x00A7BDA0
		public unsafe float 跳跃前镜头FOV
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17007218 RID: 29208
		// (get) Token: 0x0602B7A8 RID: 178088 RVA: 0x00A7DBB4 File Offset: 0x00A7BDB4
		// (set) Token: 0x0602B7A9 RID: 178089 RVA: 0x00A7DBED File Offset: 0x00A7BDED
		[Nullable(1)]
		public SBaseCurve 跳跃前镜头曲线
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				SBaseCurve result;
				if ((result = this._跳跃前镜头曲线) == null)
				{
					result = (this._跳跃前镜头曲线 = new SBaseCurve(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_20, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SBaseCurve.StaticStruct(), base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_20, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007219 RID: 29209
		// (get) Token: 0x0602B7AA RID: 178090 RVA: 0x00A7DC10 File Offset: 0x00A7BE10
		// (set) Token: 0x0602B7AB RID: 178091 RVA: 0x00A7DC49 File Offset: 0x00A7BE49
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<EDangoPerformType>, SDangoPerformData> 动作表现
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
				TMap<TEnumAsByte<EDangoPerformType>, SDangoPerformData> result;
				if ((result = this._动作表现) == null)
				{
					result = (this._动作表现 = new TMap<TEnumAsByte<EDangoPerformType>, SDangoPerformData>(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_21, this));
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
				this.动作表现.CopyAssign(value);
			}
		}

		// Token: 0x1700721A RID: 29210
		// (get) Token: 0x0602B7AC RID: 178092 RVA: 0x00A7DC57 File Offset: 0x00A7BE57
		// (set) Token: 0x0602B7AD RID: 178093 RVA: 0x00A7DC6B File Offset: 0x00A7BE6B
		public unsafe FName 堆叠绑定骨骼名称
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x1700721B RID: 29211
		// (get) Token: 0x0602B7AE RID: 178094 RVA: 0x00A7DC80 File Offset: 0x00A7BE80
		// (set) Token: 0x0602B7AF RID: 178095 RVA: 0x00A7DC90 File Offset: 0x00A7BE90
		public unsafe int 堆叠间隔
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DangoGlobalConfig_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x1700721C RID: 29212
		// (get) Token: 0x0602B7B0 RID: 178096 RVA: 0x00A7DCA1 File Offset: 0x00A7BEA1
		// (set) Token: 0x0602B7B1 RID: 178097 RVA: 0x00A7DCB5 File Offset: 0x00A7BEB5
		public unsafe UCurveFloat 黑洞下降偏移曲线
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DangoGlobalConfig_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DangoGlobalConfig_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x0602B7B2 RID: 178098 RVA: 0x00A7DCCA File Offset: 0x00A7BECA
		protected BP_DangoGlobalConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017DBC RID: 97724
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Tuanzi/CommonConfig/BP_DangoGlobalConfig.BP_DangoGlobalConfig_C";

		// Token: 0x04017DBD RID: 97725
		private static IntPtr _ClassPtr;

		// Token: 0x04017DBE RID: 97726
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017DBF RID: 97727
		internal static int __PropertyOffset_0;

		// Token: 0x04017DC0 RID: 97728
		internal static int __PropertyOffset_1;

		// Token: 0x04017DC1 RID: 97729
		internal static int __PropertyOffset_2;

		// Token: 0x04017DC2 RID: 97730
		internal static int __PropertyOffset_3;

		// Token: 0x04017DC3 RID: 97731
		internal static int __PropertyOffset_4;

		// Token: 0x04017DC4 RID: 97732
		internal static int __PropertyOffset_5;

		// Token: 0x04017DC5 RID: 97733
		internal static int __PropertyOffset_6;

		// Token: 0x04017DC6 RID: 97734
		internal static int __PropertyOffset_7;

		// Token: 0x04017DC7 RID: 97735
		internal static int __PropertyOffset_8;

		// Token: 0x04017DC8 RID: 97736
		internal static int __PropertyOffset_9;

		// Token: 0x04017DC9 RID: 97737
		internal static int __PropertyOffset_10;

		// Token: 0x04017DCA RID: 97738
		internal static int __PropertyOffset_11;

		// Token: 0x04017DCB RID: 97739
		internal static int __PropertyOffset_12;

		// Token: 0x04017DCC RID: 97740
		private SBaseCurve _跳跃中镜头曲线;

		// Token: 0x04017DCD RID: 97741
		internal static int __PropertyOffset_13;

		// Token: 0x04017DCE RID: 97742
		internal static int __PropertyOffset_14;

		// Token: 0x04017DCF RID: 97743
		internal static int __PropertyOffset_15;

		// Token: 0x04017DD0 RID: 97744
		internal static int __PropertyOffset_16;

		// Token: 0x04017DD1 RID: 97745
		internal static int __PropertyOffset_17;

		// Token: 0x04017DD2 RID: 97746
		internal static int __PropertyOffset_18;

		// Token: 0x04017DD3 RID: 97747
		internal static int __PropertyOffset_19;

		// Token: 0x04017DD4 RID: 97748
		internal static int __PropertyOffset_20;

		// Token: 0x04017DD5 RID: 97749
		private SBaseCurve _跳跃前镜头曲线;

		// Token: 0x04017DD6 RID: 97750
		internal static int __PropertyOffset_21;

		// Token: 0x04017DD7 RID: 97751
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EDangoPerformType>, SDangoPerformData> _动作表现;

		// Token: 0x04017DD8 RID: 97752
		internal static int __PropertyOffset_22;

		// Token: 0x04017DD9 RID: 97753
		internal static int __PropertyOffset_23;

		// Token: 0x04017DDA RID: 97754
		internal static int __PropertyOffset_24;
	}
}
