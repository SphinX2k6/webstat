using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003AA8 RID: 15016
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricSphereLightSuperFar.BP_VolumetricSphereLightSuperFar_C")]
	[UnrealStructLayout(1520, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1516)]
	public class BP_VolumetricSphereLightSuperFar_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject, IInterface_KuroLightBP, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0601FEAF RID: 130735 RVA: 0x0091D6E8 File Offset: 0x0091B8E8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VolumetricSphereLightSuperFar_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricSphereLightSuperFar.BP_VolumetricSphereLightSuperFar_C");
			}
			return BP_VolumetricSphereLightSuperFar_C._ClassPtr;
		}

		// Token: 0x0601FEB0 RID: 130736 RVA: 0x0091D70C File Offset: 0x0091B90C
		int IInterface_KuroLightBP.InterfaceOffset()
		{
			return BP_VolumetricSphereLightSuperFar_C.__InterfaceOffset_IInterface_KuroLightBP;
		}

		// Token: 0x0601FEB1 RID: 130737 RVA: 0x0091D714 File Offset: 0x0091B914
		public BP_VolumetricSphereLightSuperFar_C() : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricSphereLightSuperFar_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601FEB2 RID: 130738 RVA: 0x0091D73C File Offset: 0x0091B93C
		[NullableContext(1)]
		public BP_VolumetricSphereLightSuperFar_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricSphereLightSuperFar_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170032E9 RID: 13033
		// (get) Token: 0x0601FEB3 RID: 130739 RVA: 0x0091D770 File Offset: 0x0091B970
		// (set) Token: 0x0601FEB4 RID: 130740 RVA: 0x0091D7A9 File Offset: 0x0091B9A9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170032EA RID: 13034
		// (get) Token: 0x0601FEB5 RID: 130741 RVA: 0x0091D7CA File Offset: 0x0091B9CA
		// (set) Token: 0x0601FEB6 RID: 130742 RVA: 0x0091D7DE File Offset: 0x0091B9DE
		public unsafe UBillboardComponent Billboard
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170032EB RID: 13035
		// (get) Token: 0x0601FEB7 RID: 130743 RVA: 0x0091D7F3 File Offset: 0x0091B9F3
		// (set) Token: 0x0601FEB8 RID: 130744 RVA: 0x0091D807 File Offset: 0x0091BA07
		public unsafe UStaticMeshComponent StaticMeshComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170032EC RID: 13036
		// (get) Token: 0x0601FEB9 RID: 130745 RVA: 0x0091D81C File Offset: 0x0091BA1C
		// (set) Token: 0x0601FEBA RID: 130746 RVA: 0x0091D830 File Offset: 0x0091BA30
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170032ED RID: 13037
		// (get) Token: 0x0601FEBB RID: 130747 RVA: 0x0091D845 File Offset: 0x0091BA45
		// (set) Token: 0x0601FEBC RID: 130748 RVA: 0x0091D859 File Offset: 0x0091BA59
		public unsafe UStaticMesh SphereLightStaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170032EE RID: 13038
		// (get) Token: 0x0601FEBD RID: 130749 RVA: 0x0091D86E File Offset: 0x0091BA6E
		// (set) Token: 0x0601FEBE RID: 130750 RVA: 0x0091D882 File Offset: 0x0091BA82
		public unsafe UMaterialInstanceDynamic MaterialInstanceDynamic
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170032EF RID: 13039
		// (get) Token: 0x0601FEBF RID: 130751 RVA: 0x0091D897 File Offset: 0x0091BA97
		// (set) Token: 0x0601FEC0 RID: 130752 RVA: 0x0091D8AB File Offset: 0x0091BAAB
		public unsafe UMaterialInstance SphereLightMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170032F0 RID: 13040
		// (get) Token: 0x0601FEC1 RID: 130753 RVA: 0x0091D8C0 File Offset: 0x0091BAC0
		// (set) Token: 0x0601FEC2 RID: 130754 RVA: 0x0091D8D0 File Offset: 0x0091BAD0
		public unsafe bool IsReverseCulling
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x170032F1 RID: 13041
		// (get) Token: 0x0601FEC3 RID: 130755 RVA: 0x0091D8E1 File Offset: 0x0091BAE1
		// (set) Token: 0x0601FEC4 RID: 130756 RVA: 0x0091D8F1 File Offset: 0x0091BAF1
		public unsafe bool IsWholeDay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x170032F2 RID: 13042
		// (get) Token: 0x0601FEC5 RID: 130757 RVA: 0x0091D902 File Offset: 0x0091BB02
		// (set) Token: 0x0601FEC6 RID: 130758 RVA: 0x0091D912 File Offset: 0x0091BB12
		public unsafe bool OutDistanceFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x170032F3 RID: 13043
		// (get) Token: 0x0601FEC7 RID: 130759 RVA: 0x0091D923 File Offset: 0x0091BB23
		// (set) Token: 0x0601FEC8 RID: 130760 RVA: 0x0091D933 File Offset: 0x0091BB33
		public unsafe bool ApplyFog
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x170032F4 RID: 13044
		// (get) Token: 0x0601FEC9 RID: 130761 RVA: 0x0091D944 File Offset: 0x0091BB44
		// (set) Token: 0x0601FECA RID: 130762 RVA: 0x0091D954 File Offset: 0x0091BB54
		public unsafe bool IsTickIntenisty
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x170032F5 RID: 13045
		// (get) Token: 0x0601FECB RID: 130763 RVA: 0x0091D965 File Offset: 0x0091BB65
		// (set) Token: 0x0601FECC RID: 130764 RVA: 0x0091D975 File Offset: 0x0091BB75
		public unsafe bool ShoulderRenderInLowQuality
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x170032F6 RID: 13046
		// (get) Token: 0x0601FECD RID: 130765 RVA: 0x0091D986 File Offset: 0x0091BB86
		// (set) Token: 0x0601FECE RID: 130766 RVA: 0x0091D996 File Offset: 0x0091BB96
		public unsafe float NearDestroyDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170032F7 RID: 13047
		// (get) Token: 0x0601FECF RID: 130767 RVA: 0x0091D9A7 File Offset: 0x0091BBA7
		// (set) Token: 0x0601FED0 RID: 130768 RVA: 0x0091D9B7 File Offset: 0x0091BBB7
		public unsafe float FogInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170032F8 RID: 13048
		// (get) Token: 0x0601FED1 RID: 130769 RVA: 0x0091D9C8 File Offset: 0x0091BBC8
		// (set) Token: 0x0601FED2 RID: 130770 RVA: 0x0091D9D8 File Offset: 0x0091BBD8
		public unsafe float FogPower
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170032F9 RID: 13049
		// (get) Token: 0x0601FED3 RID: 130771 RVA: 0x0091D9E9 File Offset: 0x0091BBE9
		// (set) Token: 0x0601FED4 RID: 130772 RVA: 0x0091D9F9 File Offset: 0x0091BBF9
		public unsafe float SkyLightInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170032FA RID: 13050
		// (get) Token: 0x0601FED5 RID: 130773 RVA: 0x0091DA0A File Offset: 0x0091BC0A
		// (set) Token: 0x0601FED6 RID: 130774 RVA: 0x0091DA1A File Offset: 0x0091BC1A
		public unsafe float SkyLightOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170032FB RID: 13051
		// (get) Token: 0x0601FED7 RID: 130775 RVA: 0x0091DA2B File Offset: 0x0091BC2B
		// (set) Token: 0x0601FED8 RID: 130776 RVA: 0x0091DA3F File Offset: 0x0091BC3F
		public unsafe FLinearColor InsideColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170032FC RID: 13052
		// (get) Token: 0x0601FED9 RID: 130777 RVA: 0x0091DA54 File Offset: 0x0091BC54
		// (set) Token: 0x0601FEDA RID: 130778 RVA: 0x0091DA68 File Offset: 0x0091BC68
		public unsafe FLinearColor OutSideColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170032FD RID: 13053
		// (get) Token: 0x0601FEDB RID: 130779 RVA: 0x0091DA7D File Offset: 0x0091BC7D
		// (set) Token: 0x0601FEDC RID: 130780 RVA: 0x0091DA8D File Offset: 0x0091BC8D
		public unsafe float SphereRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170032FE RID: 13054
		// (get) Token: 0x0601FEDD RID: 130781 RVA: 0x0091DA9E File Offset: 0x0091BC9E
		// (set) Token: 0x0601FEDE RID: 130782 RVA: 0x0091DAAE File Offset: 0x0091BCAE
		public unsafe float LightStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x170032FF RID: 13055
		// (get) Token: 0x0601FEDF RID: 130783 RVA: 0x0091DABF File Offset: 0x0091BCBF
		// (set) Token: 0x0601FEE0 RID: 130784 RVA: 0x0091DACF File Offset: 0x0091BCCF
		public unsafe float NearFadeStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17003300 RID: 13056
		// (get) Token: 0x0601FEE1 RID: 130785 RVA: 0x0091DAE0 File Offset: 0x0091BCE0
		// (set) Token: 0x0601FEE2 RID: 130786 RVA: 0x0091DAF0 File Offset: 0x0091BCF0
		public unsafe float FullIntLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17003301 RID: 13057
		// (get) Token: 0x0601FEE3 RID: 130787 RVA: 0x0091DB01 File Offset: 0x0091BD01
		// (set) Token: 0x0601FEE4 RID: 130788 RVA: 0x0091DB11 File Offset: 0x0091BD11
		public unsafe float FarFadeLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17003302 RID: 13058
		// (get) Token: 0x0601FEE5 RID: 130789 RVA: 0x0091DB22 File Offset: 0x0091BD22
		// (set) Token: 0x0601FEE6 RID: 130790 RVA: 0x0091DB36 File Offset: 0x0091BD36
		public unsafe UMaterialInstance SphereLightMatWithOutDF
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x17003303 RID: 13059
		// (get) Token: 0x0601FEE7 RID: 130791 RVA: 0x0091DB4B File Offset: 0x0091BD4B
		// (set) Token: 0x0601FEE8 RID: 130792 RVA: 0x0091DB5F File Offset: 0x0091BD5F
		public unsafe UMaterialInstance SphereLightMatWithOutFog
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_26);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_26, value);
			}
		}

		// Token: 0x17003304 RID: 13060
		// (get) Token: 0x0601FEE9 RID: 130793 RVA: 0x0091DB74 File Offset: 0x0091BD74
		// (set) Token: 0x0601FEEA RID: 130794 RVA: 0x0091DB88 File Offset: 0x0091BD88
		public unsafe UMaterialInstance SphereLightMatWithOutDFWithOutFog
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x17003305 RID: 13061
		// (get) Token: 0x0601FEEB RID: 130795 RVA: 0x0091DB9D File Offset: 0x0091BD9D
		// (set) Token: 0x0601FEEC RID: 130796 RVA: 0x0091DBB1 File Offset: 0x0091BDB1
		public unsafe UMaterialInstance SphereLightMat_LR
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x17003306 RID: 13062
		// (get) Token: 0x0601FEED RID: 130797 RVA: 0x0091DBC6 File Offset: 0x0091BDC6
		// (set) Token: 0x0601FEEE RID: 130798 RVA: 0x0091DBDA File Offset: 0x0091BDDA
		public unsafe UMaterialInstance SphereLightMatWithOutDF_LR
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_29);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x17003307 RID: 13063
		// (get) Token: 0x0601FEEF RID: 130799 RVA: 0x0091DBEF File Offset: 0x0091BDEF
		// (set) Token: 0x0601FEF0 RID: 130800 RVA: 0x0091DC03 File Offset: 0x0091BE03
		public unsafe UMaterialInstance SphereLightMatWithOutFog_LR
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_30);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x17003308 RID: 13064
		// (get) Token: 0x0601FEF1 RID: 130801 RVA: 0x0091DC18 File Offset: 0x0091BE18
		// (set) Token: 0x0601FEF2 RID: 130802 RVA: 0x0091DC2C File Offset: 0x0091BE2C
		public unsafe UMaterialInstance SphereLightMatWithOutDFWithOutFog_LR
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_31);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_31, value);
			}
		}

		// Token: 0x17003309 RID: 13065
		// (get) Token: 0x0601FEF3 RID: 130803 RVA: 0x0091DC41 File Offset: 0x0091BE41
		// (set) Token: 0x0601FEF4 RID: 130804 RVA: 0x0091DC51 File Offset: 0x0091BE51
		public unsafe int FrameCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x1700330A RID: 13066
		// (get) Token: 0x0601FEF5 RID: 130805 RVA: 0x0091DC62 File Offset: 0x0091BE62
		// (set) Token: 0x0601FEF6 RID: 130806 RVA: 0x0091DC76 File Offset: 0x0091BE76
		[Nullable(0)]
		public unsafe TEnumAsByte<ELightQualityType> Quality
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_33);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x1700330B RID: 13067
		// (get) Token: 0x0601FEF7 RID: 130807 RVA: 0x0091DC8B File Offset: 0x0091BE8B
		// (set) Token: 0x0601FEF8 RID: 130808 RVA: 0x0091DC9B File Offset: 0x0091BE9B
		public unsafe int CurrentQuality
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightSuperFar_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x0601FEF9 RID: 130809 RVA: 0x0091DCAC File Offset: 0x0091BEAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual int GetPlacementSortOrder()
		{
			BP_VolumetricSphereLightSuperFar_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_VolumetricSphereLightSuperFar_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricSphereLightSuperFar_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricSphereLightSuperFar_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricSphereLightSuperFar_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601FEFA RID: 130810 RVA: 0x0091DCF4 File Offset: 0x0091BEF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual int GetPlacementSortOrder_Implementation()
		{
			BP_VolumetricSphereLightSuperFar_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_VolumetricSphereLightSuperFar_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricSphereLightSuperFar_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricSphereLightSuperFar_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricSphereLightSuperFar_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601FEFB RID: 130811 RVA: 0x0091DD3A File Offset: 0x0091BF3A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetQuality()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricSphereLightSuperFar_C.__SetQuality_NativeFunctionPtr, null);
		}

		// Token: 0x0601FEFC RID: 130812 RVA: 0x0091DD4E File Offset: 0x0091BF4E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateFogInt()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricSphereLightSuperFar_C.__UpdateFogInt_NativeFunctionPtr, null);
		}

		// Token: 0x0601FEFD RID: 130813 RVA: 0x0091DD62 File Offset: 0x0091BF62
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateVolumetricSphereLight()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricSphereLightSuperFar_C.__UpdateVolumetricSphereLight_NativeFunctionPtr, null);
		}

		// Token: 0x0601FEFE RID: 130814 RVA: 0x0091DD76 File Offset: 0x0091BF76
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricSphereLightSuperFar_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601FEFF RID: 130815 RVA: 0x0091DD8A File Offset: 0x0091BF8A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricSphereLightSuperFar_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FF00 RID: 130816 RVA: 0x0091DD9F File Offset: 0x0091BF9F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricSphereLightSuperFar_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601FF01 RID: 130817 RVA: 0x0091DDB3 File Offset: 0x0091BFB3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricSphereLightSuperFar_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FF02 RID: 130818 RVA: 0x0091DDC8 File Offset: 0x0091BFC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_VolumetricSphereLightSuperFar_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VolumetricSphereLightSuperFar_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricSphereLightSuperFar_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricSphereLightSuperFar_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricSphereLightSuperFar_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FF03 RID: 130819 RVA: 0x0091DE10 File Offset: 0x0091C010
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_VolumetricSphereLightSuperFar_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VolumetricSphereLightSuperFar_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricSphereLightSuperFar_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricSphereLightSuperFar_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricSphereLightSuperFar_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FF04 RID: 130820 RVA: 0x0091DE58 File Offset: 0x0091C058
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_VolumetricSphereLightSuperFar_C.__EditorTick_FunctionParams* ptr = stackalloc BP_VolumetricSphereLightSuperFar_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricSphereLightSuperFar_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricSphereLightSuperFar_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricSphereLightSuperFar_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FF05 RID: 130821 RVA: 0x0091DEA0 File Offset: 0x0091C0A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_VolumetricSphereLightSuperFar_C.__EditorTick_FunctionParams* ptr = stackalloc BP_VolumetricSphereLightSuperFar_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricSphereLightSuperFar_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricSphereLightSuperFar_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricSphereLightSuperFar_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FF06 RID: 130822 RVA: 0x0091DEE7 File Offset: 0x0091C0E7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateQualitySwitch()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricSphereLightSuperFar_C.__UpdateQualitySwitch_NativeFunctionPtr, null);
		}

		// Token: 0x0601FF07 RID: 130823 RVA: 0x0091DEFC File Offset: 0x0091C0FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_VolumetricSphereLightSuperFar(int EntryPoint)
		{
			BP_VolumetricSphereLightSuperFar_C.__ExecuteUbergraph_BP_VolumetricSphereLightSuperFar_FunctionParams* ptr = stackalloc BP_VolumetricSphereLightSuperFar_C.__ExecuteUbergraph_BP_VolumetricSphereLightSuperFar_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_VolumetricSphereLightSuperFar_C.__ExecuteUbergraph_BP_VolumetricSphereLightSuperFar_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricSphereLightSuperFar_C.__ExecuteUbergraph_BP_VolumetricSphereLightSuperFar_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricSphereLightSuperFar_C.__ExecuteUbergraph_BP_VolumetricSphereLightSuperFar_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FF08 RID: 130824 RVA: 0x0091DF43 File Offset: 0x0091C143
		protected BP_VolumetricSphereLightSuperFar_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FE36 RID: 65078
		internal static int __InterfaceOffset_IInterface_KuroLightBP;

		// Token: 0x0400FE37 RID: 65079
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricSphereLightSuperFar.BP_VolumetricSphereLightSuperFar_C";

		// Token: 0x0400FE38 RID: 65080
		private static IntPtr _ClassPtr;

		// Token: 0x0400FE39 RID: 65081
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FE3A RID: 65082
		internal static int __PropertyOffset_0;

		// Token: 0x0400FE3B RID: 65083
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FE3C RID: 65084
		internal static int __PropertyOffset_1;

		// Token: 0x0400FE3D RID: 65085
		internal static int __PropertyOffset_2;

		// Token: 0x0400FE3E RID: 65086
		internal static int __PropertyOffset_3;

		// Token: 0x0400FE3F RID: 65087
		internal static int __PropertyOffset_4;

		// Token: 0x0400FE40 RID: 65088
		internal static int __PropertyOffset_5;

		// Token: 0x0400FE41 RID: 65089
		internal static int __PropertyOffset_6;

		// Token: 0x0400FE42 RID: 65090
		internal static int __PropertyOffset_7;

		// Token: 0x0400FE43 RID: 65091
		internal static int __PropertyOffset_8;

		// Token: 0x0400FE44 RID: 65092
		internal static int __PropertyOffset_9;

		// Token: 0x0400FE45 RID: 65093
		internal static int __PropertyOffset_10;

		// Token: 0x0400FE46 RID: 65094
		internal static int __PropertyOffset_11;

		// Token: 0x0400FE47 RID: 65095
		internal static int __PropertyOffset_12;

		// Token: 0x0400FE48 RID: 65096
		internal static int __PropertyOffset_13;

		// Token: 0x0400FE49 RID: 65097
		internal static int __PropertyOffset_14;

		// Token: 0x0400FE4A RID: 65098
		internal static int __PropertyOffset_15;

		// Token: 0x0400FE4B RID: 65099
		internal static int __PropertyOffset_16;

		// Token: 0x0400FE4C RID: 65100
		internal static int __PropertyOffset_17;

		// Token: 0x0400FE4D RID: 65101
		internal static int __PropertyOffset_18;

		// Token: 0x0400FE4E RID: 65102
		internal static int __PropertyOffset_19;

		// Token: 0x0400FE4F RID: 65103
		internal static int __PropertyOffset_20;

		// Token: 0x0400FE50 RID: 65104
		internal static int __PropertyOffset_21;

		// Token: 0x0400FE51 RID: 65105
		internal static int __PropertyOffset_22;

		// Token: 0x0400FE52 RID: 65106
		internal static int __PropertyOffset_23;

		// Token: 0x0400FE53 RID: 65107
		internal static int __PropertyOffset_24;

		// Token: 0x0400FE54 RID: 65108
		internal static int __PropertyOffset_25;

		// Token: 0x0400FE55 RID: 65109
		internal static int __PropertyOffset_26;

		// Token: 0x0400FE56 RID: 65110
		internal static int __PropertyOffset_27;

		// Token: 0x0400FE57 RID: 65111
		internal static int __PropertyOffset_28;

		// Token: 0x0400FE58 RID: 65112
		internal static int __PropertyOffset_29;

		// Token: 0x0400FE59 RID: 65113
		internal static int __PropertyOffset_30;

		// Token: 0x0400FE5A RID: 65114
		internal static int __PropertyOffset_31;

		// Token: 0x0400FE5B RID: 65115
		internal static int __PropertyOffset_32;

		// Token: 0x0400FE5C RID: 65116
		internal static int __PropertyOffset_33;

		// Token: 0x0400FE5D RID: 65117
		internal static int __PropertyOffset_34;

		// Token: 0x0400FE5E RID: 65118
		private static IntPtr __GetPlacementSortOrder_NativeFunctionPtr;

		// Token: 0x0400FE5F RID: 65119
		private static IntPtr __SetQuality_NativeFunctionPtr;

		// Token: 0x0400FE60 RID: 65120
		private static IntPtr __UpdateFogInt_NativeFunctionPtr;

		// Token: 0x0400FE61 RID: 65121
		private static IntPtr __UpdateVolumetricSphereLight_NativeFunctionPtr;

		// Token: 0x0400FE62 RID: 65122
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FE63 RID: 65123
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FE64 RID: 65124
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FE65 RID: 65125
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400FE66 RID: 65126
		private static IntPtr __UpdateQualitySwitch_NativeFunctionPtr;

		// Token: 0x0400FE67 RID: 65127
		private static IntPtr __ExecuteUbergraph_BP_VolumetricSphereLightSuperFar_NativeFunctionPtr;

		// Token: 0x02009935 RID: 39221
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetPlacementSortOrder_FunctionParams
		{
			// Token: 0x04031F94 RID: 204692
			[FieldOffset(0)]
			public int __Result;
		}

		// Token: 0x02009936 RID: 39222
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F95 RID: 204693
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009937 RID: 39223
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031F96 RID: 204694
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009938 RID: 39224
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __ExecuteUbergraph_BP_VolumetricSphereLightSuperFar_FunctionParams
		{
			// Token: 0x04031F97 RID: 204695
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
