using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.GI;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Volumetrics
{
	// Token: 0x02003CFE RID: 15614
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Volumetrics/BP_VolumeSmokeContainer.BP_VolumeSmokeContainer_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_VolumeSmokeContainer_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060259C4 RID: 154052 RVA: 0x009BEDDB File Offset: 0x009BCFDB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VolumeSmokeContainer_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Volumetrics/BP_VolumeSmokeContainer.BP_VolumeSmokeContainer_C");
			}
			return BP_VolumeSmokeContainer_C._ClassPtr;
		}

		// Token: 0x060259C5 RID: 154053 RVA: 0x009BEE00 File Offset: 0x009BD000
		public BP_VolumeSmokeContainer_C() : this(BuiltinUtils.AllocNativeUObject(BP_VolumeSmokeContainer_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060259C6 RID: 154054 RVA: 0x009BEE28 File Offset: 0x009BD028
		[NullableContext(1)]
		public BP_VolumeSmokeContainer_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VolumeSmokeContainer_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170052D7 RID: 21207
		// (get) Token: 0x060259C7 RID: 154055 RVA: 0x009BEE5C File Offset: 0x009BD05C
		// (set) Token: 0x060259C8 RID: 154056 RVA: 0x009BEE95 File Offset: 0x009BD095
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170052D8 RID: 21208
		// (get) Token: 0x060259C9 RID: 154057 RVA: 0x009BEEB6 File Offset: 0x009BD0B6
		// (set) Token: 0x060259CA RID: 154058 RVA: 0x009BEECA File Offset: 0x009BD0CA
		public unsafe VolumeSmokeComponent_C VolumeSmokeComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<VolumeSmokeComponent_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeSmokeContainer_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeSmokeContainer_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170052D9 RID: 21209
		// (get) Token: 0x060259CB RID: 154059 RVA: 0x009BEEDF File Offset: 0x009BD0DF
		// (set) Token: 0x060259CC RID: 154060 RVA: 0x009BEEF3 File Offset: 0x009BD0F3
		public unsafe UMaterialBillboardComponent EditorIcon
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeSmokeContainer_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeSmokeContainer_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170052DA RID: 21210
		// (get) Token: 0x060259CD RID: 154061 RVA: 0x009BEF08 File Offset: 0x009BD108
		// (set) Token: 0x060259CE RID: 154062 RVA: 0x009BEF1C File Offset: 0x009BD11C
		public unsafe UBoxComponent VolumeVisualizeBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeSmokeContainer_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeSmokeContainer_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170052DB RID: 21211
		// (get) Token: 0x060259CF RID: 154063 RVA: 0x009BEF31 File Offset: 0x009BD131
		// (set) Token: 0x060259D0 RID: 154064 RVA: 0x009BEF45 File Offset: 0x009BD145
		public unsafe UStaticMeshComponent DepthSlicer
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeSmokeContainer_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeSmokeContainer_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170052DC RID: 21212
		// (get) Token: 0x060259D1 RID: 154065 RVA: 0x009BEF5A File Offset: 0x009BD15A
		// (set) Token: 0x060259D2 RID: 154066 RVA: 0x009BEF6E File Offset: 0x009BD16E
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeSmokeContainer_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeSmokeContainer_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170052DD RID: 21213
		// (get) Token: 0x060259D3 RID: 154067 RVA: 0x009BEF83 File Offset: 0x009BD183
		// (set) Token: 0x060259D4 RID: 154068 RVA: 0x009BEF93 File Offset: 0x009BD193
		public unsafe float ObjScaleInv
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170052DE RID: 21214
		// (get) Token: 0x060259D5 RID: 154069 RVA: 0x009BEFA4 File Offset: 0x009BD1A4
		// (set) Token: 0x060259D6 RID: 154070 RVA: 0x009BEFB4 File Offset: 0x009BD1B4
		public unsafe float FadeWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170052DF RID: 21215
		// (get) Token: 0x060259D7 RID: 154071 RVA: 0x009BEFC5 File Offset: 0x009BD1C5
		// (set) Token: 0x060259D8 RID: 154072 RVA: 0x009BEFD5 File Offset: 0x009BD1D5
		public unsafe bool DirectlySetMaterialByNinja
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x170052E0 RID: 21216
		// (get) Token: 0x060259D9 RID: 154073 RVA: 0x009BEFE6 File Offset: 0x009BD1E6
		// (set) Token: 0x060259DA RID: 154074 RVA: 0x009BEFF6 File Offset: 0x009BD1F6
		public unsafe bool DirectlySetPositionAndScaleByNinja
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x170052E1 RID: 21217
		// (get) Token: 0x060259DB RID: 154075 RVA: 0x009BF007 File Offset: 0x009BD207
		// (set) Token: 0x060259DC RID: 154076 RVA: 0x009BF017 File Offset: 0x009BD217
		public unsafe bool UseInputRT
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x170052E2 RID: 21218
		// (get) Token: 0x060259DD RID: 154077 RVA: 0x009BF028 File Offset: 0x009BD228
		// (set) Token: 0x060259DE RID: 154078 RVA: 0x009BF038 File Offset: 0x009BD238
		public unsafe bool AnchorVolume
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x170052E3 RID: 21219
		// (get) Token: 0x060259DF RID: 154079 RVA: 0x009BF049 File Offset: 0x009BD249
		// (set) Token: 0x060259E0 RID: 154080 RVA: 0x009BF05D File Offset: 0x009BD25D
		public unsafe FName ActorTagToGetDirectlyIdentifiedByNinja
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170052E4 RID: 21220
		// (get) Token: 0x060259E1 RID: 154081 RVA: 0x009BF072 File Offset: 0x009BD272
		// (set) Token: 0x060259E2 RID: 154082 RVA: 0x009BF086 File Offset: 0x009BD286
		public unsafe FName NullTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170052E5 RID: 21221
		// (get) Token: 0x060259E3 RID: 154083 RVA: 0x009BF09B File Offset: 0x009BD29B
		// (set) Token: 0x060259E4 RID: 154084 RVA: 0x009BF0AF File Offset: 0x009BD2AF
		public unsafe UTextureRenderTarget2D InputRenderTarget
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeSmokeContainer_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeSmokeContainer_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x170052E6 RID: 21222
		// (get) Token: 0x060259E5 RID: 154085 RVA: 0x009BF0C4 File Offset: 0x009BD2C4
		// (set) Token: 0x060259E6 RID: 154086 RVA: 0x009BF0D8 File Offset: 0x009BD2D8
		public unsafe FVector VolumeSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170052E7 RID: 21223
		// (get) Token: 0x060259E7 RID: 154087 RVA: 0x009BF0ED File Offset: 0x009BD2ED
		// (set) Token: 0x060259E8 RID: 154088 RVA: 0x009BF101 File Offset: 0x009BD301
		public unsafe UMaterialInterface VolumeSmokeMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeSmokeContainer_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeSmokeContainer_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x170052E8 RID: 21224
		// (get) Token: 0x060259E9 RID: 154089 RVA: 0x009BF116 File Offset: 0x009BD316
		// (set) Token: 0x060259EA RID: 154090 RVA: 0x009BF12A File Offset: 0x009BD32A
		public unsafe UMaterialInstance VolumeSmokeMaterialNoInput
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeSmokeContainer_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeSmokeContainer_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x170052E9 RID: 21225
		// (get) Token: 0x060259EB RID: 154091 RVA: 0x009BF13F File Offset: 0x009BD33F
		// (set) Token: 0x060259EC RID: 154092 RVA: 0x009BF153 File Offset: 0x009BD353
		public unsafe AActor TrackThisActorAsPointLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeSmokeContainer_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeSmokeContainer_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x170052EA RID: 21226
		// (get) Token: 0x060259ED RID: 154093 RVA: 0x009BF168 File Offset: 0x009BD368
		// (set) Token: 0x060259EE RID: 154094 RVA: 0x009BF178 File Offset: 0x009BD378
		public unsafe bool LockLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x170052EB RID: 21227
		// (get) Token: 0x060259EF RID: 154095 RVA: 0x009BF189 File Offset: 0x009BD389
		// (set) Token: 0x060259F0 RID: 154096 RVA: 0x009BF199 File Offset: 0x009BD399
		public unsafe bool LockRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x170052EC RID: 21228
		// (get) Token: 0x060259F1 RID: 154097 RVA: 0x009BF1AA File Offset: 0x009BD3AA
		// (set) Token: 0x060259F2 RID: 154098 RVA: 0x009BF1BA File Offset: 0x009BD3BA
		public unsafe bool CameraFacing
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x170052ED RID: 21229
		// (get) Token: 0x060259F3 RID: 154099 RVA: 0x009BF1CB File Offset: 0x009BD3CB
		// (set) Token: 0x060259F4 RID: 154100 RVA: 0x009BF1DB File Offset: 0x009BD3DB
		public unsafe bool CameraFacingLockY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x170052EE RID: 21230
		// (get) Token: 0x060259F5 RID: 154101 RVA: 0x009BF1EC File Offset: 0x009BD3EC
		// (set) Token: 0x060259F6 RID: 154102 RVA: 0x009BF1FC File Offset: 0x009BD3FC
		public unsafe bool UseLegacyCameraFacing
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x170052EF RID: 21231
		// (get) Token: 0x060259F7 RID: 154103 RVA: 0x009BF20D File Offset: 0x009BD40D
		// (set) Token: 0x060259F8 RID: 154104 RVA: 0x009BF221 File Offset: 0x009BD421
		public unsafe FVector PositionOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x170052F0 RID: 21232
		// (get) Token: 0x060259F9 RID: 154105 RVA: 0x009BF236 File Offset: 0x009BD436
		// (set) Token: 0x060259FA RID: 154106 RVA: 0x009BF24A File Offset: 0x009BD44A
		public unsafe FVector PointLightPositionOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x170052F1 RID: 21233
		// (get) Token: 0x060259FB RID: 154107 RVA: 0x009BF25F File Offset: 0x009BD45F
		// (set) Token: 0x060259FC RID: 154108 RVA: 0x009BF26F File Offset: 0x009BD46F
		public unsafe float VolumeSizeMultiplier
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x170052F2 RID: 21234
		// (get) Token: 0x060259FD RID: 154109 RVA: 0x009BF280 File Offset: 0x009BD480
		// (set) Token: 0x060259FE RID: 154110 RVA: 0x009BF290 File Offset: 0x009BD490
		public unsafe float VolumeSideRatio
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x170052F3 RID: 21235
		// (get) Token: 0x060259FF RID: 154111 RVA: 0x009BF2A1 File Offset: 0x009BD4A1
		// (set) Token: 0x06025A00 RID: 154112 RVA: 0x009BF2B5 File Offset: 0x009BD4B5
		public unsafe UMaterialInstanceDynamic DynamicMaterialInstance
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeSmokeContainer_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeSmokeContainer_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x170052F4 RID: 21236
		// (get) Token: 0x06025A01 RID: 154113 RVA: 0x009BF2CA File Offset: 0x009BD4CA
		// (set) Token: 0x06025A02 RID: 154114 RVA: 0x009BF2DE File Offset: 0x009BD4DE
		public unsafe FRotator InitialRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x170052F5 RID: 21237
		// (get) Token: 0x06025A03 RID: 154115 RVA: 0x009BF2F3 File Offset: 0x009BD4F3
		// (set) Token: 0x06025A04 RID: 154116 RVA: 0x009BF303 File Offset: 0x009BD503
		public unsafe bool bIsVisible
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_30) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_30) = (value ? 1 : 0);
			}
		}

		// Token: 0x170052F6 RID: 21238
		// (get) Token: 0x06025A05 RID: 154117 RVA: 0x009BF314 File Offset: 0x009BD514
		// (set) Token: 0x06025A06 RID: 154118 RVA: 0x009BF328 File Offset: 0x009BD528
		public unsafe BP_GlobalGI_C GlobalGI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_GlobalGI_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeSmokeContainer_C.__PropertyOffset_31);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeSmokeContainer_C.__PropertyOffset_31, value);
			}
		}

		// Token: 0x170052F7 RID: 21239
		// (get) Token: 0x06025A07 RID: 154119 RVA: 0x009BF33D File Offset: 0x009BD53D
		// (set) Token: 0x06025A08 RID: 154120 RVA: 0x009BF34D File Offset: 0x009BD54D
		public unsafe int CachedQuality
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x170052F8 RID: 21240
		// (get) Token: 0x06025A09 RID: 154121 RVA: 0x009BF35E File Offset: 0x009BD55E
		// (set) Token: 0x06025A0A RID: 154122 RVA: 0x009BF36E File Offset: 0x009BD56E
		public unsafe bool bIsValid
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_33) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_33) = (value ? 1 : 0);
			}
		}

		// Token: 0x170052F9 RID: 21241
		// (get) Token: 0x06025A0B RID: 154123 RVA: 0x009BF37F File Offset: 0x009BD57F
		// (set) Token: 0x06025A0C RID: 154124 RVA: 0x009BF393 File Offset: 0x009BD593
		public unsafe FVectorDouble ValidBoxLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumeSmokeContainer_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x06025A0D RID: 154125 RVA: 0x009BF3A8 File Offset: 0x009BD5A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CheckQuality(ref bool IsValid)
		{
			BP_VolumeSmokeContainer_C.__CheckQuality_FunctionParams* ptr = stackalloc BP_VolumeSmokeContainer_C.__CheckQuality_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_VolumeSmokeContainer_C.__CheckQuality_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumeSmokeContainer_C.__CheckQuality_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsValid = IsValid;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumeSmokeContainer_C.__CheckQuality_NativeFunctionPtr, (void*)ptr);
			IsValid = ptr->IsValid;
		}

		// Token: 0x06025A0E RID: 154126 RVA: 0x009BF3F7 File Offset: 0x009BD5F7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitializeMaterial()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumeSmokeContainer_C.__InitializeMaterial_NativeFunctionPtr, null);
		}

		// Token: 0x06025A0F RID: 154127 RVA: 0x009BF40B File Offset: 0x009BD60B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumeSmokeContainer_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06025A10 RID: 154128 RVA: 0x009BF41F File Offset: 0x009BD61F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumeSmokeContainer_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025A11 RID: 154129 RVA: 0x009BF434 File Offset: 0x009BD634
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumeSmokeContainer_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06025A12 RID: 154130 RVA: 0x009BF448 File Offset: 0x009BD648
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumeSmokeContainer_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025A13 RID: 154131 RVA: 0x009BF460 File Offset: 0x009BD660
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_VolumeSmokeContainer_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VolumeSmokeContainer_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumeSmokeContainer_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumeSmokeContainer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumeSmokeContainer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025A14 RID: 154132 RVA: 0x009BF4A8 File Offset: 0x009BD6A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_VolumeSmokeContainer_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VolumeSmokeContainer_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumeSmokeContainer_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumeSmokeContainer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumeSmokeContainer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025A15 RID: 154133 RVA: 0x009BF4F0 File Offset: 0x009BD6F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_VolumeSmokeContainer(int EntryPoint)
		{
			BP_VolumeSmokeContainer_C.__ExecuteUbergraph_BP_VolumeSmokeContainer_FunctionParams* ptr = stackalloc BP_VolumeSmokeContainer_C.__ExecuteUbergraph_BP_VolumeSmokeContainer_FunctionParams[(UIntPtr)743] + 15L / (long)sizeof(BP_VolumeSmokeContainer_C.__ExecuteUbergraph_BP_VolumeSmokeContainer_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumeSmokeContainer_C.__ExecuteUbergraph_BP_VolumeSmokeContainer_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumeSmokeContainer_C.__ExecuteUbergraph_BP_VolumeSmokeContainer_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025A16 RID: 154134 RVA: 0x009BF53A File Offset: 0x009BD73A
		protected BP_VolumeSmokeContainer_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013674 RID: 79476
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Volumetrics/BP_VolumeSmokeContainer.BP_VolumeSmokeContainer_C";

		// Token: 0x04013675 RID: 79477
		private static IntPtr _ClassPtr;

		// Token: 0x04013676 RID: 79478
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013677 RID: 79479
		internal static int __PropertyOffset_0;

		// Token: 0x04013678 RID: 79480
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013679 RID: 79481
		internal static int __PropertyOffset_1;

		// Token: 0x0401367A RID: 79482
		internal static int __PropertyOffset_2;

		// Token: 0x0401367B RID: 79483
		internal static int __PropertyOffset_3;

		// Token: 0x0401367C RID: 79484
		internal static int __PropertyOffset_4;

		// Token: 0x0401367D RID: 79485
		internal static int __PropertyOffset_5;

		// Token: 0x0401367E RID: 79486
		internal static int __PropertyOffset_6;

		// Token: 0x0401367F RID: 79487
		internal static int __PropertyOffset_7;

		// Token: 0x04013680 RID: 79488
		internal static int __PropertyOffset_8;

		// Token: 0x04013681 RID: 79489
		internal static int __PropertyOffset_9;

		// Token: 0x04013682 RID: 79490
		internal static int __PropertyOffset_10;

		// Token: 0x04013683 RID: 79491
		internal static int __PropertyOffset_11;

		// Token: 0x04013684 RID: 79492
		internal static int __PropertyOffset_12;

		// Token: 0x04013685 RID: 79493
		internal static int __PropertyOffset_13;

		// Token: 0x04013686 RID: 79494
		internal static int __PropertyOffset_14;

		// Token: 0x04013687 RID: 79495
		internal static int __PropertyOffset_15;

		// Token: 0x04013688 RID: 79496
		internal static int __PropertyOffset_16;

		// Token: 0x04013689 RID: 79497
		internal static int __PropertyOffset_17;

		// Token: 0x0401368A RID: 79498
		internal static int __PropertyOffset_18;

		// Token: 0x0401368B RID: 79499
		internal static int __PropertyOffset_19;

		// Token: 0x0401368C RID: 79500
		internal static int __PropertyOffset_20;

		// Token: 0x0401368D RID: 79501
		internal static int __PropertyOffset_21;

		// Token: 0x0401368E RID: 79502
		internal static int __PropertyOffset_22;

		// Token: 0x0401368F RID: 79503
		internal static int __PropertyOffset_23;

		// Token: 0x04013690 RID: 79504
		internal static int __PropertyOffset_24;

		// Token: 0x04013691 RID: 79505
		internal static int __PropertyOffset_25;

		// Token: 0x04013692 RID: 79506
		internal static int __PropertyOffset_26;

		// Token: 0x04013693 RID: 79507
		internal static int __PropertyOffset_27;

		// Token: 0x04013694 RID: 79508
		internal static int __PropertyOffset_28;

		// Token: 0x04013695 RID: 79509
		internal static int __PropertyOffset_29;

		// Token: 0x04013696 RID: 79510
		internal static int __PropertyOffset_30;

		// Token: 0x04013697 RID: 79511
		internal static int __PropertyOffset_31;

		// Token: 0x04013698 RID: 79512
		internal static int __PropertyOffset_32;

		// Token: 0x04013699 RID: 79513
		internal static int __PropertyOffset_33;

		// Token: 0x0401369A RID: 79514
		internal static int __PropertyOffset_34;

		// Token: 0x0401369B RID: 79515
		private static IntPtr __CheckQuality_NativeFunctionPtr;

		// Token: 0x0401369C RID: 79516
		private static IntPtr __InitializeMaterial_NativeFunctionPtr;

		// Token: 0x0401369D RID: 79517
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401369E RID: 79518
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401369F RID: 79519
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040136A0 RID: 79520
		private static IntPtr __ExecuteUbergraph_BP_VolumeSmokeContainer_NativeFunctionPtr;

		// Token: 0x02009F3A RID: 40762
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __CheckQuality_FunctionParams
		{
			// Token: 0x04032A6B RID: 207467
			[FieldOffset(0)]
			public bool IsValid;
		}

		// Token: 0x02009F3B RID: 40763
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032A6C RID: 207468
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009F3C RID: 40764
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 728)]
		protected ref struct __ExecuteUbergraph_BP_VolumeSmokeContainer_FunctionParams
		{
			// Token: 0x04032A6D RID: 207469
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
