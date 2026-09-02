using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.WaterInteraction;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Interaction
{
	// Token: 0x02003C8A RID: 15498
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Interaction/PDA_InteractionPlayerConfig.PDA_InteractionPlayerConfig_C")]
	[UnrealStructLayout(136, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 136)]
	public class PDA_InteractionPlayerConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060241A7 RID: 147879 RVA: 0x00994E4D File Offset: 0x0099304D
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_InteractionPlayerConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Interaction/PDA_InteractionPlayerConfig.PDA_InteractionPlayerConfig_C");
			}
			return PDA_InteractionPlayerConfig_C._ClassPtr;
		}

		// Token: 0x060241A8 RID: 147880 RVA: 0x00994E74 File Offset: 0x00993074
		public PDA_InteractionPlayerConfig_C() : this(BuiltinUtils.AllocNativeUObject(PDA_InteractionPlayerConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060241A9 RID: 147881 RVA: 0x00994E9C File Offset: 0x0099309C
		[NullableContext(1)]
		public PDA_InteractionPlayerConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_InteractionPlayerConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004A04 RID: 18948
		// (get) Token: 0x060241AA RID: 147882 RVA: 0x00994ECF File Offset: 0x009930CF
		// (set) Token: 0x060241AB RID: 147883 RVA: 0x00994EDF File Offset: 0x009930DF
		public unsafe bool 启用植被交互
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionPlayerConfig_C.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionPlayerConfig_C.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004A05 RID: 18949
		// (get) Token: 0x060241AC RID: 147884 RVA: 0x00994EF0 File Offset: 0x009930F0
		// (set) Token: 0x060241AD RID: 147885 RVA: 0x00994F00 File Offset: 0x00993100
		public unsafe float 植被交互半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionPlayerConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionPlayerConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17004A06 RID: 18950
		// (get) Token: 0x060241AE RID: 147886 RVA: 0x00994F11 File Offset: 0x00993111
		// (set) Token: 0x060241AF RID: 147887 RVA: 0x00994F21 File Offset: 0x00993121
		public unsafe bool 启用水面交互
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionPlayerConfig_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionPlayerConfig_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004A07 RID: 18951
		// (get) Token: 0x060241B0 RID: 147888 RVA: 0x00994F32 File Offset: 0x00993132
		// (set) Token: 0x060241B1 RID: 147889 RVA: 0x00994F46 File Offset: 0x00993146
		public unsafe PDA_WaterEffectConfigs_C 水特效
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_WaterEffectConfigs_C>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_InteractionPlayerConfig_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_InteractionPlayerConfig_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004A08 RID: 18952
		// (get) Token: 0x060241B2 RID: 147890 RVA: 0x00994F5B File Offset: 0x0099315B
		// (set) Token: 0x060241B3 RID: 147891 RVA: 0x00994F6B File Offset: 0x0099316B
		public unsafe float 射线向下延长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionPlayerConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionPlayerConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004A09 RID: 18953
		// (get) Token: 0x060241B4 RID: 147892 RVA: 0x00994F7C File Offset: 0x0099317C
		// (set) Token: 0x060241B5 RID: 147893 RVA: 0x00994F8C File Offset: 0x0099318C
		public unsafe bool 自动草集群
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionPlayerConfig_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionPlayerConfig_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004A0A RID: 18954
		// (get) Token: 0x060241B6 RID: 147894 RVA: 0x00994F9D File Offset: 0x0099319D
		// (set) Token: 0x060241B7 RID: 147895 RVA: 0x00994FB1 File Offset: 0x009931B1
		public unsafe UClusteredStuffDataAsset 草集群特效
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UClusteredStuffDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_InteractionPlayerConfig_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_InteractionPlayerConfig_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004A0B RID: 18955
		// (get) Token: 0x060241B8 RID: 147896 RVA: 0x00994FC6 File Offset: 0x009931C6
		// (set) Token: 0x060241B9 RID: 147897 RVA: 0x00994FD6 File Offset: 0x009931D6
		public unsafe bool 启用简易水面交互
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionPlayerConfig_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionPlayerConfig_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004A0C RID: 18956
		// (get) Token: 0x060241BA RID: 147898 RVA: 0x00994FE7 File Offset: 0x009931E7
		// (set) Token: 0x060241BB RID: 147899 RVA: 0x00994FFB File Offset: 0x009931FB
		public unsafe FVector 植被交互相对位置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionPlayerConfig_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionPlayerConfig_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x060241BC RID: 147900 RVA: 0x00995010 File Offset: 0x00993210
		protected PDA_InteractionPlayerConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012761 RID: 75617
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Interaction/PDA_InteractionPlayerConfig.PDA_InteractionPlayerConfig_C";

		// Token: 0x04012762 RID: 75618
		private static IntPtr _ClassPtr;

		// Token: 0x04012763 RID: 75619
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012764 RID: 75620
		internal static int __PropertyOffset_0;

		// Token: 0x04012765 RID: 75621
		internal static int __PropertyOffset_1;

		// Token: 0x04012766 RID: 75622
		internal static int __PropertyOffset_2;

		// Token: 0x04012767 RID: 75623
		internal static int __PropertyOffset_3;

		// Token: 0x04012768 RID: 75624
		internal static int __PropertyOffset_4;

		// Token: 0x04012769 RID: 75625
		internal static int __PropertyOffset_5;

		// Token: 0x0401276A RID: 75626
		internal static int __PropertyOffset_6;

		// Token: 0x0401276B RID: 75627
		internal static int __PropertyOffset_7;

		// Token: 0x0401276C RID: 75628
		internal static int __PropertyOffset_8;
	}
}
