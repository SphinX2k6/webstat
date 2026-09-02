using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.DecalShadow
{
	// Token: 0x02003D4E RID: 15694
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/DecalShadow/PDA_DecalShadowConfig.PDA_DecalShadowConfig_C")]
	[UnrealStructLayout(104, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 104)]
	public class PDA_DecalShadowConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602619D RID: 156061 RVA: 0x009CDFC0 File Offset: 0x009CC1C0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_DecalShadowConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/DecalShadow/PDA_DecalShadowConfig.PDA_DecalShadowConfig_C");
			}
			return PDA_DecalShadowConfig_C._ClassPtr;
		}

		// Token: 0x0602619E RID: 156062 RVA: 0x009CDFE4 File Offset: 0x009CC1E4
		public PDA_DecalShadowConfig_C() : this(BuiltinUtils.AllocNativeUObject(PDA_DecalShadowConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602619F RID: 156063 RVA: 0x009CE00C File Offset: 0x009CC20C
		[NullableContext(1)]
		public PDA_DecalShadowConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_DecalShadowConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005579 RID: 21881
		// (get) Token: 0x060261A0 RID: 156064 RVA: 0x009CE03F File Offset: 0x009CC23F
		// (set) Token: 0x060261A1 RID: 156065 RVA: 0x009CE053 File Offset: 0x009CC253
		[Nullable(2)]
		public unsafe UMaterialInterface DecalShadowMaterial
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_DecalShadowConfig_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_DecalShadowConfig_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x1700557A RID: 21882
		// (get) Token: 0x060261A2 RID: 156066 RVA: 0x009CE068 File Offset: 0x009CC268
		// (set) Token: 0x060261A3 RID: 156067 RVA: 0x009CE078 File Offset: 0x009CC278
		public unsafe float DecalBoxScaleHori
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_DecalShadowConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_DecalShadowConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700557B RID: 21883
		// (get) Token: 0x060261A4 RID: 156068 RVA: 0x009CE089 File Offset: 0x009CC289
		// (set) Token: 0x060261A5 RID: 156069 RVA: 0x009CE099 File Offset: 0x009CC299
		public unsafe float DecalBoxScaleVerti
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_DecalShadowConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_DecalShadowConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700557C RID: 21884
		// (get) Token: 0x060261A6 RID: 156070 RVA: 0x009CE0AA File Offset: 0x009CC2AA
		// (set) Token: 0x060261A7 RID: 156071 RVA: 0x009CE0BA File Offset: 0x009CC2BA
		public unsafe float ZDistanceFadeFactor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_DecalShadowConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_DecalShadowConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700557D RID: 21885
		// (get) Token: 0x060261A8 RID: 156072 RVA: 0x009CE0CB File Offset: 0x009CC2CB
		// (set) Token: 0x060261A9 RID: 156073 RVA: 0x009CE0DB File Offset: 0x009CC2DB
		public unsafe float ZDistanceFadePower
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_DecalShadowConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_DecalShadowConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x060261AA RID: 156074 RVA: 0x009CE0EC File Offset: 0x009CC2EC
		protected PDA_DecalShadowConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013BB9 RID: 80825
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/DecalShadow/PDA_DecalShadowConfig.PDA_DecalShadowConfig_C";

		// Token: 0x04013BBA RID: 80826
		private static IntPtr _ClassPtr;

		// Token: 0x04013BBB RID: 80827
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013BBC RID: 80828
		internal static int __PropertyOffset_0;

		// Token: 0x04013BBD RID: 80829
		internal static int __PropertyOffset_1;

		// Token: 0x04013BBE RID: 80830
		internal static int __PropertyOffset_2;

		// Token: 0x04013BBF RID: 80831
		internal static int __PropertyOffset_3;

		// Token: 0x04013BC0 RID: 80832
		internal static int __PropertyOffset_4;
	}
}
