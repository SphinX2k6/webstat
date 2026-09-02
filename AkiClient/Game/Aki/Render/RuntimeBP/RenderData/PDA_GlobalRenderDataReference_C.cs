using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.DecalShadow;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.LensFlare;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.RenderData
{
	// Token: 0x02003B35 RID: 15157
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/RenderData/PDA_GlobalRenderDataReference.PDA_GlobalRenderDataReference_C")]
	[UnrealStructLayout(168, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 168)]
	public class PDA_GlobalRenderDataReference_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020B88 RID: 134024 RVA: 0x009350A0 File Offset: 0x009332A0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_GlobalRenderDataReference_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/RenderData/PDA_GlobalRenderDataReference.PDA_GlobalRenderDataReference_C");
			}
			return PDA_GlobalRenderDataReference_C._ClassPtr;
		}

		// Token: 0x06020B89 RID: 134025 RVA: 0x009350C4 File Offset: 0x009332C4
		public PDA_GlobalRenderDataReference_C() : this(BuiltinUtils.AllocNativeUObject(PDA_GlobalRenderDataReference_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020B8A RID: 134026 RVA: 0x009350EC File Offset: 0x009332EC
		[NullableContext(1)]
		public PDA_GlobalRenderDataReference_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_GlobalRenderDataReference_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170036E1 RID: 14049
		// (get) Token: 0x06020B8B RID: 134027 RVA: 0x0093511F File Offset: 0x0093331F
		// (set) Token: 0x06020B8C RID: 134028 RVA: 0x00935133 File Offset: 0x00933333
		public unsafe UMaterialParameterCollection GlobalShaderParameters
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_GlobalRenderDataReference_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_GlobalRenderDataReference_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170036E2 RID: 14050
		// (get) Token: 0x06020B8D RID: 134029 RVA: 0x00935148 File Offset: 0x00933348
		// (set) Token: 0x06020B8E RID: 134030 RVA: 0x0093515C File Offset: 0x0093335C
		public unsafe UMaterialParameterCollection SceneInteractionShaderParameters
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_GlobalRenderDataReference_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_GlobalRenderDataReference_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170036E3 RID: 14051
		// (get) Token: 0x06020B8F RID: 134031 RVA: 0x00935171 File Offset: 0x00933371
		// (set) Token: 0x06020B90 RID: 134032 RVA: 0x00935185 File Offset: 0x00933385
		public unsafe PDA_ModelLensFlareConfig_C GlobalLensFlareConfig
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_ModelLensFlareConfig_C>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_GlobalRenderDataReference_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_GlobalRenderDataReference_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170036E4 RID: 14052
		// (get) Token: 0x06020B91 RID: 134033 RVA: 0x0093519A File Offset: 0x0093339A
		// (set) Token: 0x06020B92 RID: 134034 RVA: 0x009351AE File Offset: 0x009333AE
		public unsafe UMaterialParameterCollection MPC_ShowBrightness
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_GlobalRenderDataReference_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_GlobalRenderDataReference_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170036E5 RID: 14053
		// (get) Token: 0x06020B93 RID: 134035 RVA: 0x009351C3 File Offset: 0x009333C3
		// (set) Token: 0x06020B94 RID: 134036 RVA: 0x009351D7 File Offset: 0x009333D7
		public unsafe PDA_DecalShadowConfig_C DefaultDecalShadow
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_DecalShadowConfig_C>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_GlobalRenderDataReference_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_GlobalRenderDataReference_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170036E6 RID: 14054
		// (get) Token: 0x06020B95 RID: 134037 RVA: 0x009351EC File Offset: 0x009333EC
		// (set) Token: 0x06020B96 RID: 134038 RVA: 0x00935200 File Offset: 0x00933400
		public unsafe UMaterialParameterCollection EyesParameters
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_GlobalRenderDataReference_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_GlobalRenderDataReference_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170036E7 RID: 14055
		// (get) Token: 0x06020B97 RID: 134039 RVA: 0x00935215 File Offset: 0x00933415
		// (set) Token: 0x06020B98 RID: 134040 RVA: 0x00935229 File Offset: 0x00933429
		public unsafe UMaterialInterface EmptyMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_GlobalRenderDataReference_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_GlobalRenderDataReference_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170036E8 RID: 14056
		// (get) Token: 0x06020B99 RID: 134041 RVA: 0x0093523E File Offset: 0x0093343E
		// (set) Token: 0x06020B9A RID: 134042 RVA: 0x00935252 File Offset: 0x00933452
		public unsafe UMaterialParameterCollection MPC_ShowColorSetting
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_GlobalRenderDataReference_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_GlobalRenderDataReference_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170036E9 RID: 14057
		// (get) Token: 0x06020B9B RID: 134043 RVA: 0x00935267 File Offset: 0x00933467
		// (set) Token: 0x06020B9C RID: 134044 RVA: 0x0093527B File Offset: 0x0093347B
		public unsafe UMaterialParameterCollection MPC_GroundFogMask
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_GlobalRenderDataReference_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_GlobalRenderDataReference_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170036EA RID: 14058
		// (get) Token: 0x06020B9D RID: 134045 RVA: 0x00935290 File Offset: 0x00933490
		// (set) Token: 0x06020B9E RID: 134046 RVA: 0x009352A4 File Offset: 0x009334A4
		public unsafe UMaterialParameterCollection MPC_SceneCaptureParameter
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_GlobalRenderDataReference_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_GlobalRenderDataReference_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x170036EB RID: 14059
		// (get) Token: 0x06020B9F RID: 134047 RVA: 0x009352B9 File Offset: 0x009334B9
		// (set) Token: 0x06020BA0 RID: 134048 RVA: 0x009352CD File Offset: 0x009334CD
		public unsafe UMaterialParameterCollection MPC_ForGameplayParameter
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_GlobalRenderDataReference_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_GlobalRenderDataReference_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x06020BA1 RID: 134049 RVA: 0x009352E2 File Offset: 0x009334E2
		protected PDA_GlobalRenderDataReference_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010653 RID: 67155
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/RenderData/PDA_GlobalRenderDataReference.PDA_GlobalRenderDataReference_C";

		// Token: 0x04010654 RID: 67156
		private static IntPtr _ClassPtr;

		// Token: 0x04010655 RID: 67157
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010656 RID: 67158
		internal static int __PropertyOffset_0;

		// Token: 0x04010657 RID: 67159
		internal static int __PropertyOffset_1;

		// Token: 0x04010658 RID: 67160
		internal static int __PropertyOffset_2;

		// Token: 0x04010659 RID: 67161
		internal static int __PropertyOffset_3;

		// Token: 0x0401065A RID: 67162
		internal static int __PropertyOffset_4;

		// Token: 0x0401065B RID: 67163
		internal static int __PropertyOffset_5;

		// Token: 0x0401065C RID: 67164
		internal static int __PropertyOffset_6;

		// Token: 0x0401065D RID: 67165
		internal static int __PropertyOffset_7;

		// Token: 0x0401065E RID: 67166
		internal static int __PropertyOffset_8;

		// Token: 0x0401065F RID: 67167
		internal static int __PropertyOffset_9;

		// Token: 0x04010660 RID: 67168
		internal static int __PropertyOffset_10;
	}
}
