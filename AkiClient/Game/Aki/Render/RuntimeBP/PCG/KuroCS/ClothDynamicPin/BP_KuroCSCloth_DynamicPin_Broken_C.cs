using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.PCG.PBD_PhysicBridge.BP;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroCS.ClothDynamicPin
{
	// Token: 0x02003C06 RID: 15366
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroCS/ClothDynamicPin/BP_KuroCSCloth_DynamicPin_Broken.BP_KuroCSCloth_DynamicPin_Broken_C")]
	[UnrealStructLayout(2016, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2004)]
	public class BP_KuroCSCloth_DynamicPin_Broken_C : AKuroCS_Cloth_DynamicPin, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022D71 RID: 142705 RVA: 0x00970B23 File Offset: 0x0096ED23
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroCSCloth_DynamicPin_Broken_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/ClothDynamicPin/BP_KuroCSCloth_DynamicPin_Broken.BP_KuroCSCloth_DynamicPin_Broken_C");
			}
			return BP_KuroCSCloth_DynamicPin_Broken_C._ClassPtr;
		}

		// Token: 0x06022D72 RID: 142706 RVA: 0x00970B48 File Offset: 0x0096ED48
		public BP_KuroCSCloth_DynamicPin_Broken_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroCSCloth_DynamicPin_Broken_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022D73 RID: 142707 RVA: 0x00970B70 File Offset: 0x0096ED70
		[NullableContext(1)]
		public BP_KuroCSCloth_DynamicPin_Broken_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroCSCloth_DynamicPin_Broken_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004302 RID: 17154
		// (get) Token: 0x06022D74 RID: 142708 RVA: 0x00970BA4 File Offset: 0x0096EDA4
		// (set) Token: 0x06022D75 RID: 142709 RVA: 0x00970BDD File Offset: 0x0096EDDD
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004303 RID: 17155
		// (get) Token: 0x06022D76 RID: 142710 RVA: 0x00970BFE File Offset: 0x0096EDFE
		// (set) Token: 0x06022D77 RID: 142711 RVA: 0x00970C12 File Offset: 0x0096EE12
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004304 RID: 17156
		// (get) Token: 0x06022D78 RID: 142712 RVA: 0x00970C27 File Offset: 0x0096EE27
		// (set) Token: 0x06022D79 RID: 142713 RVA: 0x00970C3B File Offset: 0x0096EE3B
		public unsafe UStaticMeshComponent MobileProxy
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004305 RID: 17157
		// (get) Token: 0x06022D7A RID: 142714 RVA: 0x00970C50 File Offset: 0x0096EE50
		// (set) Token: 0x06022D7B RID: 142715 RVA: 0x00970C64 File Offset: 0x0096EE64
		public unsafe UStaticMeshComponent MeshXZ
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004306 RID: 17158
		// (get) Token: 0x06022D7C RID: 142716 RVA: 0x00970C79 File Offset: 0x0096EE79
		// (set) Token: 0x06022D7D RID: 142717 RVA: 0x00970C8D File Offset: 0x0096EE8D
		public unsafe USceneComponent PinnedLB
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004307 RID: 17159
		// (get) Token: 0x06022D7E RID: 142718 RVA: 0x00970CA2 File Offset: 0x0096EEA2
		// (set) Token: 0x06022D7F RID: 142719 RVA: 0x00970CB6 File Offset: 0x0096EEB6
		public unsafe USceneComponent PinnedLT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004308 RID: 17160
		// (get) Token: 0x06022D80 RID: 142720 RVA: 0x00970CCB File Offset: 0x0096EECB
		// (set) Token: 0x06022D81 RID: 142721 RVA: 0x00970CDF File Offset: 0x0096EEDF
		public unsafe USceneComponent PinnedRB
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004309 RID: 17161
		// (get) Token: 0x06022D82 RID: 142722 RVA: 0x00970CF4 File Offset: 0x0096EEF4
		// (set) Token: 0x06022D83 RID: 142723 RVA: 0x00970D08 File Offset: 0x0096EF08
		public unsafe USceneComponent PinnedRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x1700430A RID: 17162
		// (get) Token: 0x06022D84 RID: 142724 RVA: 0x00970D1D File Offset: 0x0096EF1D
		// (set) Token: 0x06022D85 RID: 142725 RVA: 0x00970D31 File Offset: 0x0096EF31
		public unsafe UTextureRenderTarget2D RTPos
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x1700430B RID: 17163
		// (get) Token: 0x06022D86 RID: 142726 RVA: 0x00970D46 File Offset: 0x0096EF46
		// (set) Token: 0x06022D87 RID: 142727 RVA: 0x00970D56 File Offset: 0x0096EF56
		public unsafe bool bSyncToBindPoint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700430C RID: 17164
		// (get) Token: 0x06022D88 RID: 142728 RVA: 0x00970D67 File Offset: 0x0096EF67
		// (set) Token: 0x06022D89 RID: 142729 RVA: 0x00970D7B File Offset: 0x0096EF7B
		public unsafe BP_BridgeModels_Broken_C bindBrige
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_BridgeModels_Broken_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x1700430D RID: 17165
		// (get) Token: 0x06022D8A RID: 142730 RVA: 0x00970D90 File Offset: 0x0096EF90
		// (set) Token: 0x06022D8B RID: 142731 RVA: 0x00970DA4 File Offset: 0x0096EFA4
		public unsafe BP_CPP_bridge_doubleChain_realModel_Broken_C BindBridgeChain
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_CPP_bridge_doubleChain_realModel_Broken_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x1700430E RID: 17166
		// (get) Token: 0x06022D8C RID: 142732 RVA: 0x00970DB9 File Offset: 0x0096EFB9
		// (set) Token: 0x06022D8D RID: 142733 RVA: 0x00970DC9 File Offset: 0x0096EFC9
		public unsafe int linkIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x1700430F RID: 17167
		// (get) Token: 0x06022D8E RID: 142734 RVA: 0x00970DDA File Offset: 0x0096EFDA
		// (set) Token: 0x06022D8F RID: 142735 RVA: 0x00970DEA File Offset: 0x0096EFEA
		public unsafe bool bEditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004310 RID: 17168
		// (get) Token: 0x06022D90 RID: 142736 RVA: 0x00970DFB File Offset: 0x0096EFFB
		// (set) Token: 0x06022D91 RID: 142737 RVA: 0x00970E0F File Offset: 0x0096F00F
		public unsafe FVector PosOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004311 RID: 17169
		// (get) Token: 0x06022D92 RID: 142738 RVA: 0x00970E24 File Offset: 0x0096F024
		// (set) Token: 0x06022D93 RID: 142739 RVA: 0x00970E5D File Offset: 0x0096F05D
		[Nullable(1)]
		public TArray<UMaterialInstanceDynamic> Mats
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._Mats) == null)
				{
					result = (this._Mats = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_15, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Mats.CopyAssign(value);
			}
		}

		// Token: 0x17004312 RID: 17170
		// (get) Token: 0x06022D94 RID: 142740 RVA: 0x00970E6B File Offset: 0x0096F06B
		// (set) Token: 0x06022D95 RID: 142741 RVA: 0x00970E7B File Offset: 0x0096F07B
		public unsafe bool bDrawDebug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004313 RID: 17171
		// (get) Token: 0x06022D96 RID: 142742 RVA: 0x00970E8C File Offset: 0x0096F08C
		// (set) Token: 0x06022D97 RID: 142743 RVA: 0x00970EA0 File Offset: 0x0096F0A0
		public unsafe UChildActorComponent editorTicker
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17004314 RID: 17172
		// (get) Token: 0x06022D98 RID: 142744 RVA: 0x00970EB5 File Offset: 0x0096F0B5
		// (set) Token: 0x06022D99 RID: 142745 RVA: 0x00970EC5 File Offset: 0x0096F0C5
		public unsafe bool bEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004315 RID: 17173
		// (get) Token: 0x06022D9A RID: 142746 RVA: 0x00970ED6 File Offset: 0x0096F0D6
		// (set) Token: 0x06022D9B RID: 142747 RVA: 0x00970EE6 File Offset: 0x0096F0E6
		public unsafe int Substep_Count
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17004316 RID: 17174
		// (get) Token: 0x06022D9C RID: 142748 RVA: 0x00970EF7 File Offset: 0x0096F0F7
		// (set) Token: 0x06022D9D RID: 142749 RVA: 0x00970F07 File Offset: 0x0096F107
		public unsafe bool InitOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004317 RID: 17175
		// (get) Token: 0x06022D9E RID: 142750 RVA: 0x00970F18 File Offset: 0x0096F118
		// (set) Token: 0x06022D9F RID: 142751 RVA: 0x00970F28 File Offset: 0x0096F128
		public unsafe bool bFadeOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004318 RID: 17176
		// (get) Token: 0x06022DA0 RID: 142752 RVA: 0x00970F39 File Offset: 0x0096F139
		// (set) Token: 0x06022DA1 RID: 142753 RVA: 0x00970F49 File Offset: 0x0096F149
		public unsafe float FadeOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17004319 RID: 17177
		// (get) Token: 0x06022DA2 RID: 142754 RVA: 0x00970F5A File Offset: 0x0096F15A
		// (set) Token: 0x06022DA3 RID: 142755 RVA: 0x00970F6A File Offset: 0x0096F16A
		public unsafe bool bStopSim
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700431A RID: 17178
		// (get) Token: 0x06022DA4 RID: 142756 RVA: 0x00970F7B File Offset: 0x0096F17B
		// (set) Token: 0x06022DA5 RID: 142757 RVA: 0x00970F8B File Offset: 0x0096F18B
		public unsafe bool bInit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700431B RID: 17179
		// (get) Token: 0x06022DA6 RID: 142758 RVA: 0x00970F9C File Offset: 0x0096F19C
		// (set) Token: 0x06022DA7 RID: 142759 RVA: 0x00970FD5 File Offset: 0x0096F1D5
		[Nullable(1)]
		public TMap<FName, float> Scalar_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._Scalar_Parameters) == null)
				{
					result = (this._Scalar_Parameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_25, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Scalar_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x1700431C RID: 17180
		// (get) Token: 0x06022DA8 RID: 142760 RVA: 0x00970FE4 File Offset: 0x0096F1E4
		// (set) Token: 0x06022DA9 RID: 142761 RVA: 0x0097101D File Offset: 0x0096F21D
		[Nullable(1)]
		public TMap<FName, FLinearColor> Vector_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._Vector_Parameters) == null)
				{
					result = (this._Vector_Parameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_26, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Vector_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x1700431D RID: 17181
		// (get) Token: 0x06022DAA RID: 142762 RVA: 0x0097102C File Offset: 0x0096F22C
		// (set) Token: 0x06022DAB RID: 142763 RVA: 0x00971065 File Offset: 0x0096F265
		[Nullable(1)]
		public TMap<FName, UTexture> Texture_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, UTexture> result;
				if ((result = this._Texture_Parameters) == null)
				{
					result = (this._Texture_Parameters = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_27, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Texture_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x1700431E RID: 17182
		// (get) Token: 0x06022DAC RID: 142764 RVA: 0x00971073 File Offset: 0x0096F273
		// (set) Token: 0x06022DAD RID: 142765 RVA: 0x00971087 File Offset: 0x0096F287
		public unsafe FTransformDouble Transform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x1700431F RID: 17183
		// (get) Token: 0x06022DAE RID: 142766 RVA: 0x0097109C File Offset: 0x0096F29C
		// (set) Token: 0x06022DAF RID: 142767 RVA: 0x009710AC File Offset: 0x0096F2AC
		public unsafe int Substep_CountRaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_Broken_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x06022DB0 RID: 142768 RVA: 0x009710BD File Offset: 0x0096F2BD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateMaterialParams()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_Broken_C.__UpdateMaterialParams_NativeFunctionPtr, null);
		}

		// Token: 0x06022DB1 RID: 142769 RVA: 0x009710D1 File Offset: 0x0096F2D1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StopSim()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_Broken_C.__StopSim_NativeFunctionPtr, null);
		}

		// Token: 0x06022DB2 RID: 142770 RVA: 0x009710E5 File Offset: 0x0096F2E5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartSim()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_Broken_C.__StartSim_NativeFunctionPtr, null);
		}

		// Token: 0x06022DB3 RID: 142771 RVA: 0x009710F9 File Offset: 0x0096F2F9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitRT()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_Broken_C.__InitRT_NativeFunctionPtr, null);
		}

		// Token: 0x06022DB4 RID: 142772 RVA: 0x0097110D File Offset: 0x0096F30D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitMats()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_Broken_C.__InitMats_NativeFunctionPtr, null);
		}

		// Token: 0x06022DB5 RID: 142773 RVA: 0x00971121 File Offset: 0x0096F321
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FitToBridge()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_Broken_C.__FitToBridge_NativeFunctionPtr, null);
		}

		// Token: 0x06022DB6 RID: 142774 RVA: 0x00971135 File Offset: 0x0096F335
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DrawDeformPoints()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_Broken_C.__DrawDeformPoints_NativeFunctionPtr, null);
		}

		// Token: 0x06022DB7 RID: 142775 RVA: 0x0097114C File Offset: 0x0096F34C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SyncPos(USceneComponent From, USceneComponent To)
		{
			BP_KuroCSCloth_DynamicPin_Broken_C.__SyncPos_FunctionParams* ptr = stackalloc BP_KuroCSCloth_DynamicPin_Broken_C.__SyncPos_FunctionParams[(UIntPtr)215] + 15L / (long)sizeof(BP_KuroCSCloth_DynamicPin_Broken_C.__SyncPos_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_DynamicPin_Broken_C.__SyncPos_NativeFunctionPtr, (void*)ptr, 1);
			ptr->From = ((From != null) ? From.NativePtr : IntPtr.Zero);
			ptr->To = ((To != null) ? To.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_Broken_C.__SyncPos_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022DB8 RID: 142776 RVA: 0x009711BA File Offset: 0x0096F3BA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SyncToBindPin()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_Broken_C.__SyncToBindPin_NativeFunctionPtr, null);
		}

		// Token: 0x06022DB9 RID: 142777 RVA: 0x009711CE File Offset: 0x0096F3CE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DrawAndSetPin()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_Broken_C.__DrawAndSetPin_NativeFunctionPtr, null);
		}

		// Token: 0x06022DBA RID: 142778 RVA: 0x009711E2 File Offset: 0x0096F3E2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_Broken_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022DBB RID: 142779 RVA: 0x009711F6 File Offset: 0x0096F3F6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_Broken_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022DBC RID: 142780 RVA: 0x0097120B File Offset: 0x0096F40B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_Broken_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x06022DBD RID: 142781 RVA: 0x00971220 File Offset: 0x0096F420
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KuroCSCloth_DynamicPin_Broken_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroCSCloth_DynamicPin_Broken_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCSCloth_DynamicPin_Broken_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_DynamicPin_Broken_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_Broken_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022DBE RID: 142782 RVA: 0x00971268 File Offset: 0x0096F468
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KuroCSCloth_DynamicPin_Broken_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroCSCloth_DynamicPin_Broken_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCSCloth_DynamicPin_Broken_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_DynamicPin_Broken_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_Broken_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022DBF RID: 142783 RVA: 0x009712AF File Offset: 0x0096F4AF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_Broken_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022DC0 RID: 142784 RVA: 0x009712C3 File Offset: 0x0096F4C3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_Broken_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022DC1 RID: 142785 RVA: 0x009712D8 File Offset: 0x0096F4D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_KuroCSCloth_DynamicPin_Broken_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_KuroCSCloth_DynamicPin_Broken_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroCSCloth_DynamicPin_Broken_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_DynamicPin_Broken_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_Broken_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022DC2 RID: 142786 RVA: 0x00971324 File Offset: 0x0096F524
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_KuroCSCloth_DynamicPin_Broken_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_KuroCSCloth_DynamicPin_Broken_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroCSCloth_DynamicPin_Broken_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_DynamicPin_Broken_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_Broken_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022DC3 RID: 142787 RVA: 0x00971370 File Offset: 0x0096F570
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_KuroCSCloth_DynamicPin_Broken_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_KuroCSCloth_DynamicPin_Broken_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_KuroCSCloth_DynamicPin_Broken_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_DynamicPin_Broken_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_Broken_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022DC4 RID: 142788 RVA: 0x0097142C File Offset: 0x0096F62C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_KuroCSCloth_DynamicPin_Broken_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_KuroCSCloth_DynamicPin_Broken_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_KuroCSCloth_DynamicPin_Broken_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_DynamicPin_Broken_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_Broken_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022DC5 RID: 142789 RVA: 0x009714B5 File Offset: 0x0096F6B5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomBoxCheckTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_Broken_C.__CustomBoxCheckTick_NativeFunctionPtr, null);
		}

		// Token: 0x06022DC6 RID: 142790 RVA: 0x009714CC File Offset: 0x0096F6CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroCSCloth_DynamicPin_Broken(int EntryPoint)
		{
			BP_KuroCSCloth_DynamicPin_Broken_C.__ExecuteUbergraph_BP_KuroCSCloth_DynamicPin_Broken_FunctionParams* ptr = stackalloc BP_KuroCSCloth_DynamicPin_Broken_C.__ExecuteUbergraph_BP_KuroCSCloth_DynamicPin_Broken_FunctionParams[(UIntPtr)1663] + 15L / (long)sizeof(BP_KuroCSCloth_DynamicPin_Broken_C.__ExecuteUbergraph_BP_KuroCSCloth_DynamicPin_Broken_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_DynamicPin_Broken_C.__ExecuteUbergraph_BP_KuroCSCloth_DynamicPin_Broken_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_Broken_C.__ExecuteUbergraph_BP_KuroCSCloth_DynamicPin_Broken_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022DC7 RID: 142791 RVA: 0x00971516 File Offset: 0x0096F716
		protected BP_KuroCSCloth_DynamicPin_Broken_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011AEF RID: 72431
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/ClothDynamicPin/BP_KuroCSCloth_DynamicPin_Broken.BP_KuroCSCloth_DynamicPin_Broken_C";

		// Token: 0x04011AF0 RID: 72432
		private static IntPtr _ClassPtr;

		// Token: 0x04011AF1 RID: 72433
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011AF2 RID: 72434
		internal static int __PropertyOffset_0;

		// Token: 0x04011AF3 RID: 72435
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011AF4 RID: 72436
		internal static int __PropertyOffset_1;

		// Token: 0x04011AF5 RID: 72437
		internal static int __PropertyOffset_2;

		// Token: 0x04011AF6 RID: 72438
		internal static int __PropertyOffset_3;

		// Token: 0x04011AF7 RID: 72439
		internal static int __PropertyOffset_4;

		// Token: 0x04011AF8 RID: 72440
		internal static int __PropertyOffset_5;

		// Token: 0x04011AF9 RID: 72441
		internal static int __PropertyOffset_6;

		// Token: 0x04011AFA RID: 72442
		internal static int __PropertyOffset_7;

		// Token: 0x04011AFB RID: 72443
		internal static int __PropertyOffset_8;

		// Token: 0x04011AFC RID: 72444
		internal static int __PropertyOffset_9;

		// Token: 0x04011AFD RID: 72445
		internal static int __PropertyOffset_10;

		// Token: 0x04011AFE RID: 72446
		internal static int __PropertyOffset_11;

		// Token: 0x04011AFF RID: 72447
		internal static int __PropertyOffset_12;

		// Token: 0x04011B00 RID: 72448
		internal static int __PropertyOffset_13;

		// Token: 0x04011B01 RID: 72449
		internal static int __PropertyOffset_14;

		// Token: 0x04011B02 RID: 72450
		internal static int __PropertyOffset_15;

		// Token: 0x04011B03 RID: 72451
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _Mats;

		// Token: 0x04011B04 RID: 72452
		internal static int __PropertyOffset_16;

		// Token: 0x04011B05 RID: 72453
		internal static int __PropertyOffset_17;

		// Token: 0x04011B06 RID: 72454
		internal static int __PropertyOffset_18;

		// Token: 0x04011B07 RID: 72455
		internal static int __PropertyOffset_19;

		// Token: 0x04011B08 RID: 72456
		internal static int __PropertyOffset_20;

		// Token: 0x04011B09 RID: 72457
		internal static int __PropertyOffset_21;

		// Token: 0x04011B0A RID: 72458
		internal static int __PropertyOffset_22;

		// Token: 0x04011B0B RID: 72459
		internal static int __PropertyOffset_23;

		// Token: 0x04011B0C RID: 72460
		internal static int __PropertyOffset_24;

		// Token: 0x04011B0D RID: 72461
		internal static int __PropertyOffset_25;

		// Token: 0x04011B0E RID: 72462
		private TMap<FName, float> _Scalar_Parameters;

		// Token: 0x04011B0F RID: 72463
		internal static int __PropertyOffset_26;

		// Token: 0x04011B10 RID: 72464
		private TMap<FName, FLinearColor> _Vector_Parameters;

		// Token: 0x04011B11 RID: 72465
		internal static int __PropertyOffset_27;

		// Token: 0x04011B12 RID: 72466
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Texture_Parameters;

		// Token: 0x04011B13 RID: 72467
		internal static int __PropertyOffset_28;

		// Token: 0x04011B14 RID: 72468
		internal static int __PropertyOffset_29;

		// Token: 0x04011B15 RID: 72469
		private static IntPtr __UpdateMaterialParams_NativeFunctionPtr;

		// Token: 0x04011B16 RID: 72470
		private static IntPtr __StopSim_NativeFunctionPtr;

		// Token: 0x04011B17 RID: 72471
		private static IntPtr __StartSim_NativeFunctionPtr;

		// Token: 0x04011B18 RID: 72472
		private static IntPtr __InitRT_NativeFunctionPtr;

		// Token: 0x04011B19 RID: 72473
		private static IntPtr __InitMats_NativeFunctionPtr;

		// Token: 0x04011B1A RID: 72474
		private static IntPtr __FitToBridge_NativeFunctionPtr;

		// Token: 0x04011B1B RID: 72475
		private static IntPtr __DrawDeformPoints_NativeFunctionPtr;

		// Token: 0x04011B1C RID: 72476
		private static IntPtr __SyncPos_NativeFunctionPtr;

		// Token: 0x04011B1D RID: 72477
		private static IntPtr __SyncToBindPin_NativeFunctionPtr;

		// Token: 0x04011B1E RID: 72478
		private static IntPtr __DrawAndSetPin_NativeFunctionPtr;

		// Token: 0x04011B1F RID: 72479
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011B20 RID: 72480
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04011B21 RID: 72481
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011B22 RID: 72482
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011B23 RID: 72483
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04011B24 RID: 72484
		private static IntPtr __BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011B25 RID: 72485
		private static IntPtr __BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011B26 RID: 72486
		private static IntPtr __CustomBoxCheckTick_NativeFunctionPtr;

		// Token: 0x04011B27 RID: 72487
		private static IntPtr __ExecuteUbergraph_BP_KuroCSCloth_DynamicPin_Broken_NativeFunctionPtr;

		// Token: 0x02009C38 RID: 39992
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 200)]
		protected ref struct __SyncPos_FunctionParams
		{
			// Token: 0x040324CB RID: 206027
			[FieldOffset(0)]
			public IntPtr From;

			// Token: 0x040324CC RID: 206028
			[FieldOffset(8)]
			public IntPtr To;
		}

		// Token: 0x02009C39 RID: 39993
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040324CD RID: 206029
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C3A RID: 39994
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x040324CE RID: 206030
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009C3B RID: 39995
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040324CF RID: 206031
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040324D0 RID: 206032
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040324D1 RID: 206033
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040324D2 RID: 206034
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040324D3 RID: 206035
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040324D4 RID: 206036
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009C3C RID: 39996
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040324D5 RID: 206037
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040324D6 RID: 206038
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040324D7 RID: 206039
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040324D8 RID: 206040
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009C3D RID: 39997
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1648)]
		protected ref struct __ExecuteUbergraph_BP_KuroCSCloth_DynamicPin_Broken_FunctionParams
		{
			// Token: 0x040324D9 RID: 206041
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
