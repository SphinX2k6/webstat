using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003AA9 RID: 15017
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricSphereLight.BP_VolumetricSphereLight_C")]
	[UnrealStructLayout(1416, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1413)]
	public class BP_VolumetricSphereLight_C : AKuroLightActorBase, IUnrealUObject, IUnrealObject, IInterface_KuroLightBP, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0601FF09 RID: 130825 RVA: 0x0091DF4C File Offset: 0x0091C14C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VolumetricSphereLight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricSphereLight.BP_VolumetricSphereLight_C");
			}
			return BP_VolumetricSphereLight_C._ClassPtr;
		}

		// Token: 0x0601FF0A RID: 130826 RVA: 0x0091DF70 File Offset: 0x0091C170
		int IInterface_KuroLightBP.InterfaceOffset()
		{
			return BP_VolumetricSphereLight_C.__InterfaceOffset_IInterface_KuroLightBP;
		}

		// Token: 0x0601FF0B RID: 130827 RVA: 0x0091DF78 File Offset: 0x0091C178
		public BP_VolumetricSphereLight_C() : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricSphereLight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601FF0C RID: 130828 RVA: 0x0091DFA0 File Offset: 0x0091C1A0
		[NullableContext(1)]
		public BP_VolumetricSphereLight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricSphereLight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700330C RID: 13068
		// (get) Token: 0x0601FF0D RID: 130829 RVA: 0x0091DFD4 File Offset: 0x0091C1D4
		// (set) Token: 0x0601FF0E RID: 130830 RVA: 0x0091E00D File Offset: 0x0091C20D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700330D RID: 13069
		// (get) Token: 0x0601FF0F RID: 130831 RVA: 0x0091E02E File Offset: 0x0091C22E
		// (set) Token: 0x0601FF10 RID: 130832 RVA: 0x0091E042 File Offset: 0x0091C242
		public unsafe UBillboardComponent Billboard
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700330E RID: 13070
		// (get) Token: 0x0601FF11 RID: 130833 RVA: 0x0091E057 File Offset: 0x0091C257
		// (set) Token: 0x0601FF12 RID: 130834 RVA: 0x0091E06B File Offset: 0x0091C26B
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700330F RID: 13071
		// (get) Token: 0x0601FF13 RID: 130835 RVA: 0x0091E080 File Offset: 0x0091C280
		// (set) Token: 0x0601FF14 RID: 130836 RVA: 0x0091E094 File Offset: 0x0091C294
		public unsafe UStaticMesh SphereLightStaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003310 RID: 13072
		// (get) Token: 0x0601FF15 RID: 130837 RVA: 0x0091E0A9 File Offset: 0x0091C2A9
		// (set) Token: 0x0601FF16 RID: 130838 RVA: 0x0091E0BD File Offset: 0x0091C2BD
		public unsafe UMaterialInstanceDynamic MaterialInstanceDynamic
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003311 RID: 13073
		// (get) Token: 0x0601FF17 RID: 130839 RVA: 0x0091E0D2 File Offset: 0x0091C2D2
		// (set) Token: 0x0601FF18 RID: 130840 RVA: 0x0091E0E6 File Offset: 0x0091C2E6
		public unsafe UMaterialInstance SphereLightMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003312 RID: 13074
		// (get) Token: 0x0601FF19 RID: 130841 RVA: 0x0091E0FB File Offset: 0x0091C2FB
		// (set) Token: 0x0601FF1A RID: 130842 RVA: 0x0091E10B File Offset: 0x0091C30B
		public unsafe bool IsReverseCulling
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003313 RID: 13075
		// (get) Token: 0x0601FF1B RID: 130843 RVA: 0x0091E11C File Offset: 0x0091C31C
		// (set) Token: 0x0601FF1C RID: 130844 RVA: 0x0091E12C File Offset: 0x0091C32C
		public unsafe bool BlackDown
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003314 RID: 13076
		// (get) Token: 0x0601FF1D RID: 130845 RVA: 0x0091E13D File Offset: 0x0091C33D
		// (set) Token: 0x0601FF1E RID: 130846 RVA: 0x0091E14D File Offset: 0x0091C34D
		public unsafe bool IsWholeDay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003315 RID: 13077
		// (get) Token: 0x0601FF1F RID: 130847 RVA: 0x0091E15E File Offset: 0x0091C35E
		// (set) Token: 0x0601FF20 RID: 130848 RVA: 0x0091E16E File Offset: 0x0091C36E
		public unsafe bool OutDistanceFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003316 RID: 13078
		// (get) Token: 0x0601FF21 RID: 130849 RVA: 0x0091E17F File Offset: 0x0091C37F
		// (set) Token: 0x0601FF22 RID: 130850 RVA: 0x0091E18F File Offset: 0x0091C38F
		public unsafe bool ApplyFog
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003317 RID: 13079
		// (get) Token: 0x0601FF23 RID: 130851 RVA: 0x0091E1A0 File Offset: 0x0091C3A0
		// (set) Token: 0x0601FF24 RID: 130852 RVA: 0x0091E1B0 File Offset: 0x0091C3B0
		public unsafe float FogInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003318 RID: 13080
		// (get) Token: 0x0601FF25 RID: 130853 RVA: 0x0091E1C1 File Offset: 0x0091C3C1
		// (set) Token: 0x0601FF26 RID: 130854 RVA: 0x0091E1D1 File Offset: 0x0091C3D1
		public unsafe float FogPower
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003319 RID: 13081
		// (get) Token: 0x0601FF27 RID: 130855 RVA: 0x0091E1E2 File Offset: 0x0091C3E2
		// (set) Token: 0x0601FF28 RID: 130856 RVA: 0x0091E1F2 File Offset: 0x0091C3F2
		public unsafe float SkyLightInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x1700331A RID: 13082
		// (get) Token: 0x0601FF29 RID: 130857 RVA: 0x0091E203 File Offset: 0x0091C403
		// (set) Token: 0x0601FF2A RID: 130858 RVA: 0x0091E213 File Offset: 0x0091C413
		public unsafe float SkyLightOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700331B RID: 13083
		// (get) Token: 0x0601FF2B RID: 130859 RVA: 0x0091E224 File Offset: 0x0091C424
		// (set) Token: 0x0601FF2C RID: 130860 RVA: 0x0091E238 File Offset: 0x0091C438
		public unsafe FLinearColor InsideColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700331C RID: 13084
		// (get) Token: 0x0601FF2D RID: 130861 RVA: 0x0091E24D File Offset: 0x0091C44D
		// (set) Token: 0x0601FF2E RID: 130862 RVA: 0x0091E261 File Offset: 0x0091C461
		public unsafe FLinearColor OutSideColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x1700331D RID: 13085
		// (get) Token: 0x0601FF2F RID: 130863 RVA: 0x0091E276 File Offset: 0x0091C476
		// (set) Token: 0x0601FF30 RID: 130864 RVA: 0x0091E286 File Offset: 0x0091C486
		public unsafe float SphereRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x1700331E RID: 13086
		// (get) Token: 0x0601FF31 RID: 130865 RVA: 0x0091E297 File Offset: 0x0091C497
		// (set) Token: 0x0601FF32 RID: 130866 RVA: 0x0091E2A7 File Offset: 0x0091C4A7
		public unsafe float LightStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700331F RID: 13087
		// (get) Token: 0x0601FF33 RID: 130867 RVA: 0x0091E2B8 File Offset: 0x0091C4B8
		// (set) Token: 0x0601FF34 RID: 130868 RVA: 0x0091E2C8 File Offset: 0x0091C4C8
		public unsafe float NearFadeStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17003320 RID: 13088
		// (get) Token: 0x0601FF35 RID: 130869 RVA: 0x0091E2D9 File Offset: 0x0091C4D9
		// (set) Token: 0x0601FF36 RID: 130870 RVA: 0x0091E2E9 File Offset: 0x0091C4E9
		public unsafe float FullIntLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17003321 RID: 13089
		// (get) Token: 0x0601FF37 RID: 130871 RVA: 0x0091E2FA File Offset: 0x0091C4FA
		// (set) Token: 0x0601FF38 RID: 130872 RVA: 0x0091E30A File Offset: 0x0091C50A
		public unsafe float FarFadeLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17003322 RID: 13090
		// (get) Token: 0x0601FF39 RID: 130873 RVA: 0x0091E31B File Offset: 0x0091C51B
		// (set) Token: 0x0601FF3A RID: 130874 RVA: 0x0091E32F File Offset: 0x0091C52F
		public unsafe UMaterialInstance SphereLightMatWithOutDF
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x17003323 RID: 13091
		// (get) Token: 0x0601FF3B RID: 130875 RVA: 0x0091E344 File Offset: 0x0091C544
		// (set) Token: 0x0601FF3C RID: 130876 RVA: 0x0091E358 File Offset: 0x0091C558
		public unsafe UMaterialInstance SphereLightMatWithOutFog
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x17003324 RID: 13092
		// (get) Token: 0x0601FF3D RID: 130877 RVA: 0x0091E36D File Offset: 0x0091C56D
		// (set) Token: 0x0601FF3E RID: 130878 RVA: 0x0091E381 File Offset: 0x0091C581
		public unsafe UMaterialInstance SphereLightMatWithOutDFWithOutFog
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x17003325 RID: 13093
		// (get) Token: 0x0601FF3F RID: 130879 RVA: 0x0091E396 File Offset: 0x0091C596
		// (set) Token: 0x0601FF40 RID: 130880 RVA: 0x0091E3AA File Offset: 0x0091C5AA
		public unsafe UMaterialInstance SphereLightBlackDown
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x17003326 RID: 13094
		// (get) Token: 0x0601FF41 RID: 130881 RVA: 0x0091E3BF File Offset: 0x0091C5BF
		// (set) Token: 0x0601FF42 RID: 130882 RVA: 0x0091E3D3 File Offset: 0x0091C5D3
		public unsafe UMaterialInstance SphereLightBlackDownWithOutDF
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_26);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_26, value);
			}
		}

		// Token: 0x17003327 RID: 13095
		// (get) Token: 0x0601FF43 RID: 130883 RVA: 0x0091E3E8 File Offset: 0x0091C5E8
		// (set) Token: 0x0601FF44 RID: 130884 RVA: 0x0091E3F8 File Offset: 0x0091C5F8
		public unsafe bool Editor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003328 RID: 13096
		// (get) Token: 0x0601FF45 RID: 130885 RVA: 0x0091E409 File Offset: 0x0091C609
		// (set) Token: 0x0601FF46 RID: 130886 RVA: 0x0091E41D File Offset: 0x0091C61D
		public unsafe FVectorDouble CameraPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17003329 RID: 13097
		// (get) Token: 0x0601FF47 RID: 130887 RVA: 0x0091E432 File Offset: 0x0091C632
		// (set) Token: 0x0601FF48 RID: 130888 RVA: 0x0091E446 File Offset: 0x0091C646
		public unsafe UStaticMeshComponent MeshComp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_29);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x1700332A RID: 13098
		// (get) Token: 0x0601FF49 RID: 130889 RVA: 0x0091E45B File Offset: 0x0091C65B
		// (set) Token: 0x0601FF4A RID: 130890 RVA: 0x0091E46B File Offset: 0x0091C66B
		public unsafe float DistanceFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x1700332B RID: 13099
		// (get) Token: 0x0601FF4B RID: 130891 RVA: 0x0091E47C File Offset: 0x0091C67C
		// (set) Token: 0x0601FF4C RID: 130892 RVA: 0x0091E48C File Offset: 0x0091C68C
		public unsafe bool bUseCPUDitanceFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_31) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_31) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700332C RID: 13100
		// (get) Token: 0x0601FF4D RID: 130893 RVA: 0x0091E49D File Offset: 0x0091C69D
		// (set) Token: 0x0601FF4E RID: 130894 RVA: 0x0091E4AD File Offset: 0x0091C6AD
		public unsafe int TranslucentSortPriority
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x1700332D RID: 13101
		// (get) Token: 0x0601FF4F RID: 130895 RVA: 0x0091E4BE File Offset: 0x0091C6BE
		// (set) Token: 0x0601FF50 RID: 130896 RVA: 0x0091E4CE File Offset: 0x0091C6CE
		public unsafe bool UseNoiseFog
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_33) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_33) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700332E RID: 13102
		// (get) Token: 0x0601FF51 RID: 130897 RVA: 0x0091E4DF File Offset: 0x0091C6DF
		// (set) Token: 0x0601FF52 RID: 130898 RVA: 0x0091E4F3 File Offset: 0x0091C6F3
		public unsafe UTexture MainNoiseTex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_34);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_34, value);
			}
		}

		// Token: 0x1700332F RID: 13103
		// (get) Token: 0x0601FF53 RID: 130899 RVA: 0x0091E508 File Offset: 0x0091C708
		// (set) Token: 0x0601FF54 RID: 130900 RVA: 0x0091E51C File Offset: 0x0091C71C
		public unsafe UTexture SecondNoiseTex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_35);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_35, value);
			}
		}

		// Token: 0x17003330 RID: 13104
		// (get) Token: 0x0601FF55 RID: 130901 RVA: 0x0091E531 File Offset: 0x0091C731
		// (set) Token: 0x0601FF56 RID: 130902 RVA: 0x0091E545 File Offset: 0x0091C745
		public unsafe FLinearColor MainNoiseTexUVControl
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17003331 RID: 13105
		// (get) Token: 0x0601FF57 RID: 130903 RVA: 0x0091E55A File Offset: 0x0091C75A
		// (set) Token: 0x0601FF58 RID: 130904 RVA: 0x0091E56E File Offset: 0x0091C76E
		public unsafe FLinearColor SecondNoiseTexUVControl
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17003332 RID: 13106
		// (get) Token: 0x0601FF59 RID: 130905 RVA: 0x0091E583 File Offset: 0x0091C783
		// (set) Token: 0x0601FF5A RID: 130906 RVA: 0x0091E593 File Offset: 0x0091C793
		public unsafe float MainUVAddStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17003333 RID: 13107
		// (get) Token: 0x0601FF5B RID: 130907 RVA: 0x0091E5A4 File Offset: 0x0091C7A4
		// (set) Token: 0x0601FF5C RID: 130908 RVA: 0x0091E5B8 File Offset: 0x0091C7B8
		public unsafe FLinearColor MainNoiseColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17003334 RID: 13108
		// (get) Token: 0x0601FF5D RID: 130909 RVA: 0x0091E5CD File Offset: 0x0091C7CD
		// (set) Token: 0x0601FF5E RID: 130910 RVA: 0x0091E5E1 File Offset: 0x0091C7E1
		public unsafe FLinearColor SecondNoiseColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x17003335 RID: 13109
		// (get) Token: 0x0601FF5F RID: 130911 RVA: 0x0091E5F6 File Offset: 0x0091C7F6
		// (set) Token: 0x0601FF60 RID: 130912 RVA: 0x0091E60A File Offset: 0x0091C80A
		public unsafe UMaterialInstance SphereLightMat_NF
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_41);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_41, value);
			}
		}

		// Token: 0x17003336 RID: 13110
		// (get) Token: 0x0601FF61 RID: 130913 RVA: 0x0091E61F File Offset: 0x0091C81F
		// (set) Token: 0x0601FF62 RID: 130914 RVA: 0x0091E633 File Offset: 0x0091C833
		public unsafe UMaterialInstance SphereLightMatWithOutDF_NF
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_42);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_42, value);
			}
		}

		// Token: 0x17003337 RID: 13111
		// (get) Token: 0x0601FF63 RID: 130915 RVA: 0x0091E648 File Offset: 0x0091C848
		// (set) Token: 0x0601FF64 RID: 130916 RVA: 0x0091E65C File Offset: 0x0091C85C
		public unsafe UMaterialInstance SphereLightMatWithOutFog_NF
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_43);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_43, value);
			}
		}

		// Token: 0x17003338 RID: 13112
		// (get) Token: 0x0601FF65 RID: 130917 RVA: 0x0091E671 File Offset: 0x0091C871
		// (set) Token: 0x0601FF66 RID: 130918 RVA: 0x0091E685 File Offset: 0x0091C885
		public unsafe UMaterialInstance SphereLightMatWithOutDFWithOutFog_NF
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_44);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_44, value);
			}
		}

		// Token: 0x17003339 RID: 13113
		// (get) Token: 0x0601FF67 RID: 130919 RVA: 0x0091E69A File Offset: 0x0091C89A
		// (set) Token: 0x0601FF68 RID: 130920 RVA: 0x0091E6AE File Offset: 0x0091C8AE
		public unsafe UMaterialInstance SphereLightBlackDown_NF
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_45);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_45, value);
			}
		}

		// Token: 0x1700333A RID: 13114
		// (get) Token: 0x0601FF69 RID: 130921 RVA: 0x0091E6C3 File Offset: 0x0091C8C3
		// (set) Token: 0x0601FF6A RID: 130922 RVA: 0x0091E6D7 File Offset: 0x0091C8D7
		public unsafe UMaterialInstance SphereLightBlackDownWithOutDF_NF
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_46);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_C.__PropertyOffset_46, value);
			}
		}

		// Token: 0x1700333B RID: 13115
		// (get) Token: 0x0601FF6B RID: 130923 RVA: 0x0091E6EC File Offset: 0x0091C8EC
		// (set) Token: 0x0601FF6C RID: 130924 RVA: 0x0091E6FC File Offset: 0x0091C8FC
		public unsafe int FrameCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x1700333C RID: 13116
		// (get) Token: 0x0601FF6D RID: 130925 RVA: 0x0091E70D File Offset: 0x0091C90D
		// (set) Token: 0x0601FF6E RID: 130926 RVA: 0x0091E721 File Offset: 0x0091C921
		[Nullable(0)]
		public unsafe TEnumAsByte<ELightQualityType> Quality
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_48);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x1700333D RID: 13117
		// (get) Token: 0x0601FF6F RID: 130927 RVA: 0x0091E736 File Offset: 0x0091C936
		// (set) Token: 0x0601FF70 RID: 130928 RVA: 0x0091E746 File Offset: 0x0091C946
		public unsafe int CurrentQuality
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_49);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_49) = value;
			}
		}

		// Token: 0x1700333E RID: 13118
		// (get) Token: 0x0601FF71 RID: 130929 RVA: 0x0091E757 File Offset: 0x0091C957
		// (set) Token: 0x0601FF72 RID: 130930 RVA: 0x0091E767 File Offset: 0x0091C967
		public unsafe bool bMobileVRS
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_50) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_C.__PropertyOffset_50) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601FF73 RID: 130931 RVA: 0x0091E778 File Offset: 0x0091C978
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual int GetPlacementSortOrder()
		{
			BP_VolumetricSphereLight_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_VolumetricSphereLight_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricSphereLight_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricSphereLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricSphereLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601FF74 RID: 130932 RVA: 0x0091E7C0 File Offset: 0x0091C9C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual int GetPlacementSortOrder_Implementation()
		{
			BP_VolumetricSphereLight_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_VolumetricSphereLight_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricSphereLight_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricSphereLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricSphereLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601FF75 RID: 130933 RVA: 0x0091E806 File Offset: 0x0091CA06
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetQuality()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricSphereLight_C.__SetQuality_NativeFunctionPtr, null);
		}

		// Token: 0x0601FF76 RID: 130934 RVA: 0x0091E81A File Offset: 0x0091CA1A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateVolumetricSphereLight()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricSphereLight_C.__UpdateVolumetricSphereLight_NativeFunctionPtr, null);
		}

		// Token: 0x0601FF77 RID: 130935 RVA: 0x0091E82E File Offset: 0x0091CA2E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricSphereLight_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601FF78 RID: 130936 RVA: 0x0091E842 File Offset: 0x0091CA42
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricSphereLight_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FF79 RID: 130937 RVA: 0x0091E857 File Offset: 0x0091CA57
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricSphereLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601FF7A RID: 130938 RVA: 0x0091E86B File Offset: 0x0091CA6B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricSphereLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FF7B RID: 130939 RVA: 0x0091E880 File Offset: 0x0091CA80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void Update(float DeltaSeconds)
		{
			BP_VolumetricSphereLight_C.__Update_FunctionParams* ptr = stackalloc BP_VolumetricSphereLight_C.__Update_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricSphereLight_C.__Update_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricSphereLight_C.__Update_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricSphereLight_C.__Update_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FF7C RID: 130940 RVA: 0x0091E8C8 File Offset: 0x0091CAC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void Update_Implementation(float DeltaSeconds)
		{
			BP_VolumetricSphereLight_C.__Update_FunctionParams* ptr = stackalloc BP_VolumetricSphereLight_C.__Update_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricSphereLight_C.__Update_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricSphereLight_C.__Update_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricSphereLight_C.__Update_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FF7D RID: 130941 RVA: 0x0091E910 File Offset: 0x0091CB10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void SetLightIntensityScale(float ScaleFactor)
		{
			BP_VolumetricSphereLight_C.__SetLightIntensityScale_FunctionParams* ptr = stackalloc BP_VolumetricSphereLight_C.__SetLightIntensityScale_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricSphereLight_C.__SetLightIntensityScale_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricSphereLight_C.__SetLightIntensityScale_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ScaleFactor = ScaleFactor;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricSphereLight_C.__SetLightIntensityScale_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FF7E RID: 130942 RVA: 0x0091E958 File Offset: 0x0091CB58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void SetLightIntensityScale_Implementation(float ScaleFactor)
		{
			BP_VolumetricSphereLight_C.__SetLightIntensityScale_FunctionParams* ptr = stackalloc BP_VolumetricSphereLight_C.__SetLightIntensityScale_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricSphereLight_C.__SetLightIntensityScale_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricSphereLight_C.__SetLightIntensityScale_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ScaleFactor = ScaleFactor;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricSphereLight_C.__SetLightIntensityScale_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FF7F RID: 130943 RVA: 0x0091E99F File Offset: 0x0091CB9F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateQualitySwitch()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricSphereLight_C.__UpdateQualitySwitch_NativeFunctionPtr, null);
		}

		// Token: 0x0601FF80 RID: 130944 RVA: 0x0091E9B4 File Offset: 0x0091CBB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_VolumetricSphereLight(int EntryPoint)
		{
			BP_VolumetricSphereLight_C.__ExecuteUbergraph_BP_VolumetricSphereLight_FunctionParams* ptr = stackalloc BP_VolumetricSphereLight_C.__ExecuteUbergraph_BP_VolumetricSphereLight_FunctionParams[(UIntPtr)295] + 15L / (long)sizeof(BP_VolumetricSphereLight_C.__ExecuteUbergraph_BP_VolumetricSphereLight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricSphereLight_C.__ExecuteUbergraph_BP_VolumetricSphereLight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricSphereLight_C.__ExecuteUbergraph_BP_VolumetricSphereLight_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FF81 RID: 130945 RVA: 0x0091E9FE File Offset: 0x0091CBFE
		protected BP_VolumetricSphereLight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FE68 RID: 65128
		internal static int __InterfaceOffset_IInterface_KuroLightBP;

		// Token: 0x0400FE69 RID: 65129
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricSphereLight.BP_VolumetricSphereLight_C";

		// Token: 0x0400FE6A RID: 65130
		private static IntPtr _ClassPtr;

		// Token: 0x0400FE6B RID: 65131
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FE6C RID: 65132
		internal static int __PropertyOffset_0;

		// Token: 0x0400FE6D RID: 65133
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FE6E RID: 65134
		internal static int __PropertyOffset_1;

		// Token: 0x0400FE6F RID: 65135
		internal static int __PropertyOffset_2;

		// Token: 0x0400FE70 RID: 65136
		internal static int __PropertyOffset_3;

		// Token: 0x0400FE71 RID: 65137
		internal static int __PropertyOffset_4;

		// Token: 0x0400FE72 RID: 65138
		internal static int __PropertyOffset_5;

		// Token: 0x0400FE73 RID: 65139
		internal static int __PropertyOffset_6;

		// Token: 0x0400FE74 RID: 65140
		internal static int __PropertyOffset_7;

		// Token: 0x0400FE75 RID: 65141
		internal static int __PropertyOffset_8;

		// Token: 0x0400FE76 RID: 65142
		internal static int __PropertyOffset_9;

		// Token: 0x0400FE77 RID: 65143
		internal static int __PropertyOffset_10;

		// Token: 0x0400FE78 RID: 65144
		internal static int __PropertyOffset_11;

		// Token: 0x0400FE79 RID: 65145
		internal static int __PropertyOffset_12;

		// Token: 0x0400FE7A RID: 65146
		internal static int __PropertyOffset_13;

		// Token: 0x0400FE7B RID: 65147
		internal static int __PropertyOffset_14;

		// Token: 0x0400FE7C RID: 65148
		internal static int __PropertyOffset_15;

		// Token: 0x0400FE7D RID: 65149
		internal static int __PropertyOffset_16;

		// Token: 0x0400FE7E RID: 65150
		internal static int __PropertyOffset_17;

		// Token: 0x0400FE7F RID: 65151
		internal static int __PropertyOffset_18;

		// Token: 0x0400FE80 RID: 65152
		internal static int __PropertyOffset_19;

		// Token: 0x0400FE81 RID: 65153
		internal static int __PropertyOffset_20;

		// Token: 0x0400FE82 RID: 65154
		internal static int __PropertyOffset_21;

		// Token: 0x0400FE83 RID: 65155
		internal static int __PropertyOffset_22;

		// Token: 0x0400FE84 RID: 65156
		internal static int __PropertyOffset_23;

		// Token: 0x0400FE85 RID: 65157
		internal static int __PropertyOffset_24;

		// Token: 0x0400FE86 RID: 65158
		internal static int __PropertyOffset_25;

		// Token: 0x0400FE87 RID: 65159
		internal static int __PropertyOffset_26;

		// Token: 0x0400FE88 RID: 65160
		internal static int __PropertyOffset_27;

		// Token: 0x0400FE89 RID: 65161
		internal static int __PropertyOffset_28;

		// Token: 0x0400FE8A RID: 65162
		internal static int __PropertyOffset_29;

		// Token: 0x0400FE8B RID: 65163
		internal static int __PropertyOffset_30;

		// Token: 0x0400FE8C RID: 65164
		internal static int __PropertyOffset_31;

		// Token: 0x0400FE8D RID: 65165
		internal static int __PropertyOffset_32;

		// Token: 0x0400FE8E RID: 65166
		internal static int __PropertyOffset_33;

		// Token: 0x0400FE8F RID: 65167
		internal static int __PropertyOffset_34;

		// Token: 0x0400FE90 RID: 65168
		internal static int __PropertyOffset_35;

		// Token: 0x0400FE91 RID: 65169
		internal static int __PropertyOffset_36;

		// Token: 0x0400FE92 RID: 65170
		internal static int __PropertyOffset_37;

		// Token: 0x0400FE93 RID: 65171
		internal static int __PropertyOffset_38;

		// Token: 0x0400FE94 RID: 65172
		internal static int __PropertyOffset_39;

		// Token: 0x0400FE95 RID: 65173
		internal static int __PropertyOffset_40;

		// Token: 0x0400FE96 RID: 65174
		internal static int __PropertyOffset_41;

		// Token: 0x0400FE97 RID: 65175
		internal static int __PropertyOffset_42;

		// Token: 0x0400FE98 RID: 65176
		internal static int __PropertyOffset_43;

		// Token: 0x0400FE99 RID: 65177
		internal static int __PropertyOffset_44;

		// Token: 0x0400FE9A RID: 65178
		internal static int __PropertyOffset_45;

		// Token: 0x0400FE9B RID: 65179
		internal static int __PropertyOffset_46;

		// Token: 0x0400FE9C RID: 65180
		internal static int __PropertyOffset_47;

		// Token: 0x0400FE9D RID: 65181
		internal static int __PropertyOffset_48;

		// Token: 0x0400FE9E RID: 65182
		internal static int __PropertyOffset_49;

		// Token: 0x0400FE9F RID: 65183
		internal static int __PropertyOffset_50;

		// Token: 0x0400FEA0 RID: 65184
		private static IntPtr __GetPlacementSortOrder_NativeFunctionPtr;

		// Token: 0x0400FEA1 RID: 65185
		private static IntPtr __SetQuality_NativeFunctionPtr;

		// Token: 0x0400FEA2 RID: 65186
		private static IntPtr __UpdateVolumetricSphereLight_NativeFunctionPtr;

		// Token: 0x0400FEA3 RID: 65187
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FEA4 RID: 65188
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FEA5 RID: 65189
		private static IntPtr __Update_NativeFunctionPtr;

		// Token: 0x0400FEA6 RID: 65190
		private static IntPtr __SetLightIntensityScale_NativeFunctionPtr;

		// Token: 0x0400FEA7 RID: 65191
		private static IntPtr __UpdateQualitySwitch_NativeFunctionPtr;

		// Token: 0x0400FEA8 RID: 65192
		private static IntPtr __ExecuteUbergraph_BP_VolumetricSphereLight_NativeFunctionPtr;

		// Token: 0x02009939 RID: 39225
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetPlacementSortOrder_FunctionParams
		{
			// Token: 0x04031F98 RID: 204696
			[FieldOffset(0)]
			public int __Result;
		}

		// Token: 0x0200993A RID: 39226
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __Update_FunctionParams
		{
			// Token: 0x04031F99 RID: 204697
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200993B RID: 39227
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __SetLightIntensityScale_FunctionParams
		{
			// Token: 0x04031F9A RID: 204698
			[FieldOffset(0)]
			public float ScaleFactor;
		}

		// Token: 0x0200993C RID: 39228
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 280)]
		protected ref struct __ExecuteUbergraph_BP_VolumetricSphereLight_FunctionParams
		{
			// Token: 0x04031F9B RID: 204699
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
