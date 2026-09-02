using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.BP
{
	// Token: 0x02003CC0 RID: 15552
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_CloudPrefab.BP_CloudPrefab_C")]
	[UnrealStructLayout(1792, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1785)]
	public class BP_CloudPrefab_C : AKuroCloudPrefabActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024D60 RID: 150880 RVA: 0x009A998F File Offset: 0x009A7B8F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CloudPrefab_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_CloudPrefab.BP_CloudPrefab_C");
			}
			return BP_CloudPrefab_C._ClassPtr;
		}

		// Token: 0x06024D61 RID: 150881 RVA: 0x009A99B4 File Offset: 0x009A7BB4
		public BP_CloudPrefab_C() : this(BuiltinUtils.AllocNativeUObject(BP_CloudPrefab_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024D62 RID: 150882 RVA: 0x009A99DC File Offset: 0x009A7BDC
		[NullableContext(1)]
		public BP_CloudPrefab_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CloudPrefab_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004E33 RID: 20019
		// (get) Token: 0x06024D63 RID: 150883 RVA: 0x009A9A10 File Offset: 0x009A7C10
		// (set) Token: 0x06024D64 RID: 150884 RVA: 0x009A9A49 File Offset: 0x009A7C49
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004E34 RID: 20020
		// (get) Token: 0x06024D65 RID: 150885 RVA: 0x009A9A6A File Offset: 0x009A7C6A
		// (set) Token: 0x06024D66 RID: 150886 RVA: 0x009A9A7E File Offset: 0x009A7C7E
		public unsafe UStaticMeshComponent Cloud_Top
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004E35 RID: 20021
		// (get) Token: 0x06024D67 RID: 150887 RVA: 0x009A9A93 File Offset: 0x009A7C93
		// (set) Token: 0x06024D68 RID: 150888 RVA: 0x009A9AA7 File Offset: 0x009A7CA7
		public unsafe UStaticMeshComponent Mountain
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004E36 RID: 20022
		// (get) Token: 0x06024D69 RID: 150889 RVA: 0x009A9ABC File Offset: 0x009A7CBC
		// (set) Token: 0x06024D6A RID: 150890 RVA: 0x009A9AD0 File Offset: 0x009A7CD0
		public unsafe UStaticMeshComponent Cloud_BigShape
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004E37 RID: 20023
		// (get) Token: 0x06024D6B RID: 150891 RVA: 0x009A9AE5 File Offset: 0x009A7CE5
		// (set) Token: 0x06024D6C RID: 150892 RVA: 0x009A9AF9 File Offset: 0x009A7CF9
		public unsafe UStaticMeshComponent Cloud_Cover
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004E38 RID: 20024
		// (get) Token: 0x06024D6D RID: 150893 RVA: 0x009A9B0E File Offset: 0x009A7D0E
		// (set) Token: 0x06024D6E RID: 150894 RVA: 0x009A9B22 File Offset: 0x009A7D22
		public unsafe UStaticMeshComponent Parent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004E39 RID: 20025
		// (get) Token: 0x06024D6F RID: 150895 RVA: 0x009A9B37 File Offset: 0x009A7D37
		// (set) Token: 0x06024D70 RID: 150896 RVA: 0x009A9B4B File Offset: 0x009A7D4B
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004E3A RID: 20026
		// (get) Token: 0x06024D71 RID: 150897 RVA: 0x009A9B60 File Offset: 0x009A7D60
		// (set) Token: 0x06024D72 RID: 150898 RVA: 0x009A9B74 File Offset: 0x009A7D74
		public unsafe UTexture CloudColorMap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004E3B RID: 20027
		// (get) Token: 0x06024D73 RID: 150899 RVA: 0x009A9B89 File Offset: 0x009A7D89
		// (set) Token: 0x06024D74 RID: 150900 RVA: 0x009A9B9D File Offset: 0x009A7D9D
		public unsafe UTexture CloudMaskMap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17004E3C RID: 20028
		// (get) Token: 0x06024D75 RID: 150901 RVA: 0x009A9BB2 File Offset: 0x009A7DB2
		// (set) Token: 0x06024D76 RID: 150902 RVA: 0x009A9BC2 File Offset: 0x009A7DC2
		public unsafe float ChangeSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004E3D RID: 20029
		// (get) Token: 0x06024D77 RID: 150903 RVA: 0x009A9BD3 File Offset: 0x009A7DD3
		// (set) Token: 0x06024D78 RID: 150904 RVA: 0x009A9BE3 File Offset: 0x009A7DE3
		public unsafe float CloudRotateSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17004E3E RID: 20030
		// (get) Token: 0x06024D79 RID: 150905 RVA: 0x009A9BF4 File Offset: 0x009A7DF4
		// (set) Token: 0x06024D7A RID: 150906 RVA: 0x009A9C04 File Offset: 0x009A7E04
		public unsafe float Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17004E3F RID: 20031
		// (get) Token: 0x06024D7B RID: 150907 RVA: 0x009A9C15 File Offset: 0x009A7E15
		// (set) Token: 0x06024D7C RID: 150908 RVA: 0x009A9C25 File Offset: 0x009A7E25
		public unsafe bool change
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004E40 RID: 20032
		// (get) Token: 0x06024D7D RID: 150909 RVA: 0x009A9C36 File Offset: 0x009A7E36
		// (set) Token: 0x06024D7E RID: 150910 RVA: 0x009A9C46 File Offset: 0x009A7E46
		public unsafe bool Stop
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004E41 RID: 20033
		// (get) Token: 0x06024D7F RID: 150911 RVA: 0x009A9C57 File Offset: 0x009A7E57
		// (set) Token: 0x06024D80 RID: 150912 RVA: 0x009A9C67 File Offset: 0x009A7E67
		public unsafe bool Farward
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004E42 RID: 20034
		// (get) Token: 0x06024D81 RID: 150913 RVA: 0x009A9C78 File Offset: 0x009A7E78
		// (set) Token: 0x06024D82 RID: 150914 RVA: 0x009A9CB1 File Offset: 0x009A7EB1
		[Nullable(1)]
		public TArray<UMaterialInstanceDynamic> DMI
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._DMI) == null)
				{
					result = (this._DMI = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_15, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.DMI.CopyAssign(value);
			}
		}

		// Token: 0x17004E43 RID: 20035
		// (get) Token: 0x06024D83 RID: 150915 RVA: 0x009A9CBF File Offset: 0x009A7EBF
		// (set) Token: 0x06024D84 RID: 150916 RVA: 0x009A9CCF File Offset: 0x009A7ECF
		public unsafe float Delta_Seconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17004E44 RID: 20036
		// (get) Token: 0x06024D85 RID: 150917 RVA: 0x009A9CE0 File Offset: 0x009A7EE0
		// (set) Token: 0x06024D86 RID: 150918 RVA: 0x009A9CF0 File Offset: 0x009A7EF0
		public unsafe bool TimerInit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004E45 RID: 20037
		// (get) Token: 0x06024D87 RID: 150919 RVA: 0x009A9D01 File Offset: 0x009A7F01
		// (set) Token: 0x06024D88 RID: 150920 RVA: 0x009A9D11 File Offset: 0x009A7F11
		public unsafe bool ColoredCloud_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004E46 RID: 20038
		// (get) Token: 0x06024D89 RID: 150921 RVA: 0x009A9D22 File Offset: 0x009A7F22
		// (set) Token: 0x06024D8A RID: 150922 RVA: 0x009A9D32 File Offset: 0x009A7F32
		public unsafe float CloudSaturation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17004E47 RID: 20039
		// (get) Token: 0x06024D8B RID: 150923 RVA: 0x009A9D43 File Offset: 0x009A7F43
		// (set) Token: 0x06024D8C RID: 150924 RVA: 0x009A9D53 File Offset: 0x009A7F53
		public unsafe float CurrentOpacity___别改我__
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17004E48 RID: 20040
		// (get) Token: 0x06024D8D RID: 150925 RVA: 0x009A9D64 File Offset: 0x009A7F64
		// (set) Token: 0x06024D8E RID: 150926 RVA: 0x009A9D78 File Offset: 0x009A7F78
		public unsafe UMaterialInstanceDynamic DMI_Top
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17004E49 RID: 20041
		// (get) Token: 0x06024D8F RID: 150927 RVA: 0x009A9D8D File Offset: 0x009A7F8D
		// (set) Token: 0x06024D90 RID: 150928 RVA: 0x009A9DA1 File Offset: 0x009A7FA1
		public unsafe UMaterialInstanceDynamic DMI_Cover
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x17004E4A RID: 20042
		// (get) Token: 0x06024D91 RID: 150929 RVA: 0x009A9DB6 File Offset: 0x009A7FB6
		// (set) Token: 0x06024D92 RID: 150930 RVA: 0x009A9DCA File Offset: 0x009A7FCA
		public unsafe UMaterialInstanceDynamic DMI_Anomalies
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x17004E4B RID: 20043
		// (get) Token: 0x06024D93 RID: 150931 RVA: 0x009A9DDF File Offset: 0x009A7FDF
		// (set) Token: 0x06024D94 RID: 150932 RVA: 0x009A9DF3 File Offset: 0x009A7FF3
		public unsafe UMaterialInstanceDynamic DMI_BigShape
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x17004E4C RID: 20044
		// (get) Token: 0x06024D95 RID: 150933 RVA: 0x009A9E08 File Offset: 0x009A8008
		// (set) Token: 0x06024D96 RID: 150934 RVA: 0x009A9E1C File Offset: 0x009A801C
		public unsafe UMaterialInstanceDynamic DMI_Mountain
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x17004E4D RID: 20045
		// (get) Token: 0x06024D97 RID: 150935 RVA: 0x009A9E31 File Offset: 0x009A8031
		// (set) Token: 0x06024D98 RID: 150936 RVA: 0x009A9E41 File Offset: 0x009A8041
		public unsafe float CloudInitialZAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17004E4E RID: 20046
		// (get) Token: 0x06024D99 RID: 150937 RVA: 0x009A9E52 File Offset: 0x009A8052
		// (set) Token: 0x06024D9A RID: 150938 RVA: 0x009A9E62 File Offset: 0x009A8062
		public unsafe bool UpdatePerFourFrame01
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004E4F RID: 20047
		// (get) Token: 0x06024D9B RID: 150939 RVA: 0x009A9E73 File Offset: 0x009A8073
		// (set) Token: 0x06024D9C RID: 150940 RVA: 0x009A9E83 File Offset: 0x009A8083
		public unsafe bool UpdatePerFourFrame02
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004E50 RID: 20048
		// (get) Token: 0x06024D9D RID: 150941 RVA: 0x009A9E94 File Offset: 0x009A8094
		// (set) Token: 0x06024D9E RID: 150942 RVA: 0x009A9EA4 File Offset: 0x009A80A4
		public unsafe bool SetCoverMaterial
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_29) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_29) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004E51 RID: 20049
		// (get) Token: 0x06024D9F RID: 150943 RVA: 0x009A9EB5 File Offset: 0x009A80B5
		// (set) Token: 0x06024DA0 RID: 150944 RVA: 0x009A9EC9 File Offset: 0x009A80C9
		public unsafe UMaterialInterface Cloud_Cover_Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_30);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudPrefab_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x17004E52 RID: 20050
		// (get) Token: 0x06024DA1 RID: 150945 RVA: 0x009A9EDE File Offset: 0x009A80DE
		// (set) Token: 0x06024DA2 RID: 150946 RVA: 0x009A9EEE File Offset: 0x009A80EE
		public unsafe int TransSortNumber
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17004E53 RID: 20051
		// (get) Token: 0x06024DA3 RID: 150947 RVA: 0x009A9F00 File Offset: 0x009A8100
		// (set) Token: 0x06024DA4 RID: 150948 RVA: 0x009A9F39 File Offset: 0x009A8139
		[Nullable(1)]
		public TArray<UStaticMeshComponent> MeshArray
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMeshComponent> result;
				if ((result = this._MeshArray) == null)
				{
					result = (this._MeshArray = new TArray<UStaticMeshComponent>(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_32, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.MeshArray.CopyAssign(value);
			}
		}

		// Token: 0x17004E54 RID: 20052
		// (get) Token: 0x06024DA5 RID: 150949 RVA: 0x009A9F48 File Offset: 0x009A8148
		// (set) Token: 0x06024DA6 RID: 150950 RVA: 0x009A9F81 File Offset: 0x009A8181
		[Nullable(1)]
		public TArray<UMaterialInstanceDynamic> DMIArray
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._DMIArray) == null)
				{
					result = (this._DMIArray = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_33, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.DMIArray.CopyAssign(value);
			}
		}

		// Token: 0x17004E55 RID: 20053
		// (get) Token: 0x06024DA7 RID: 150951 RVA: 0x009A9F8F File Offset: 0x009A818F
		// (set) Token: 0x06024DA8 RID: 150952 RVA: 0x009A9F9F File Offset: 0x009A819F
		public unsafe float Random
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17004E56 RID: 20054
		// (get) Token: 0x06024DA9 RID: 150953 RVA: 0x009A9FB0 File Offset: 0x009A81B0
		// (set) Token: 0x06024DAA RID: 150954 RVA: 0x009A9FE9 File Offset: 0x009A81E9
		[Nullable(1)]
		public TArray<int> Trans
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._Trans) == null)
				{
					result = (this._Trans = new TArray<int>(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_35, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Trans.CopyAssign(value);
			}
		}

		// Token: 0x17004E57 RID: 20055
		// (get) Token: 0x06024DAB RID: 150955 RVA: 0x009A9FF7 File Offset: 0x009A81F7
		// (set) Token: 0x06024DAC RID: 150956 RVA: 0x009AA007 File Offset: 0x009A8207
		public unsafe float SDFTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17004E58 RID: 20056
		// (get) Token: 0x06024DAD RID: 150957 RVA: 0x009AA018 File Offset: 0x009A8218
		// (set) Token: 0x06024DAE RID: 150958 RVA: 0x009AA028 File Offset: 0x009A8228
		public unsafe bool bFollowChar
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_37) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_37) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004E59 RID: 20057
		// (get) Token: 0x06024DAF RID: 150959 RVA: 0x009AA039 File Offset: 0x009A8239
		// (set) Token: 0x06024DB0 RID: 150960 RVA: 0x009AA049 File Offset: 0x009A8249
		public unsafe bool bFollowCamera
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_38) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_38) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004E5A RID: 20058
		// (get) Token: 0x06024DB1 RID: 150961 RVA: 0x009AA05A File Offset: 0x009A825A
		// (set) Token: 0x06024DB2 RID: 150962 RVA: 0x009AA06A File Offset: 0x009A826A
		public unsafe float SmoothWidth_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17004E5B RID: 20059
		// (get) Token: 0x06024DB3 RID: 150963 RVA: 0x009AA07B File Offset: 0x009A827B
		// (set) Token: 0x06024DB4 RID: 150964 RVA: 0x009AA08B File Offset: 0x009A828B
		public unsafe bool bOverrideCloudOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_40) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_40) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004E5C RID: 20060
		// (get) Token: 0x06024DB5 RID: 150965 RVA: 0x009AA09C File Offset: 0x009A829C
		// (set) Token: 0x06024DB6 RID: 150966 RVA: 0x009AA0AC File Offset: 0x009A82AC
		public unsafe float CloudSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x17004E5D RID: 20061
		// (get) Token: 0x06024DB7 RID: 150967 RVA: 0x009AA0BD File Offset: 0x009A82BD
		// (set) Token: 0x06024DB8 RID: 150968 RVA: 0x009AA0CD File Offset: 0x009A82CD
		public unsafe float CloudOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x17004E5E RID: 20062
		// (get) Token: 0x06024DB9 RID: 150969 RVA: 0x009AA0DE File Offset: 0x009A82DE
		// (set) Token: 0x06024DBA RID: 150970 RVA: 0x009AA0EE File Offset: 0x009A82EE
		public unsafe bool IsReversed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_43) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_43) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004E5F RID: 20063
		// (get) Token: 0x06024DBB RID: 150971 RVA: 0x009AA0FF File Offset: 0x009A82FF
		// (set) Token: 0x06024DBC RID: 150972 RVA: 0x009AA10F File Offset: 0x009A830F
		public unsafe bool IsReversedTemp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_44) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_44) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004E60 RID: 20064
		// (get) Token: 0x06024DBD RID: 150973 RVA: 0x009AA120 File Offset: 0x009A8320
		// (set) Token: 0x06024DBE RID: 150974 RVA: 0x009AA130 File Offset: 0x009A8330
		public unsafe float ReversedZHeightBias
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x17004E61 RID: 20065
		// (get) Token: 0x06024DBF RID: 150975 RVA: 0x009AA141 File Offset: 0x009A8341
		// (set) Token: 0x06024DC0 RID: 150976 RVA: 0x009AA151 File Offset: 0x009A8351
		public unsafe bool CoverNoiseParameters
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_46) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_46) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004E62 RID: 20066
		// (get) Token: 0x06024DC1 RID: 150977 RVA: 0x009AA162 File Offset: 0x009A8362
		// (set) Token: 0x06024DC2 RID: 150978 RVA: 0x009AA172 File Offset: 0x009A8372
		public unsafe float NoiseSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x17004E63 RID: 20067
		// (get) Token: 0x06024DC3 RID: 150979 RVA: 0x009AA183 File Offset: 0x009A8383
		// (set) Token: 0x06024DC4 RID: 150980 RVA: 0x009AA193 File Offset: 0x009A8393
		public unsafe float NoiseTilling
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x17004E64 RID: 20068
		// (get) Token: 0x06024DC5 RID: 150981 RVA: 0x009AA1A4 File Offset: 0x009A83A4
		// (set) Token: 0x06024DC6 RID: 150982 RVA: 0x009AA1B4 File Offset: 0x009A83B4
		public unsafe float NoiseStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_49);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_49) = value;
			}
		}

		// Token: 0x17004E65 RID: 20069
		// (get) Token: 0x06024DC7 RID: 150983 RVA: 0x009AA1C5 File Offset: 0x009A83C5
		// (set) Token: 0x06024DC8 RID: 150984 RVA: 0x009AA1D5 File Offset: 0x009A83D5
		public unsafe float ChangeProgress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_50);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_50) = value;
			}
		}

		// Token: 0x17004E66 RID: 20070
		// (get) Token: 0x06024DC9 RID: 150985 RVA: 0x009AA1E6 File Offset: 0x009A83E6
		// (set) Token: 0x06024DCA RID: 150986 RVA: 0x009AA1F6 File Offset: 0x009A83F6
		public unsafe bool EnableSequence
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_51) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_51) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004E67 RID: 20071
		// (get) Token: 0x06024DCB RID: 150987 RVA: 0x009AA207 File Offset: 0x009A8407
		// (set) Token: 0x06024DCC RID: 150988 RVA: 0x009AA217 File Offset: 0x009A8417
		public unsafe float CurveTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_52);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_52) = value;
			}
		}

		// Token: 0x17004E68 RID: 20072
		// (get) Token: 0x06024DCD RID: 150989 RVA: 0x009AA228 File Offset: 0x009A8428
		// (set) Token: 0x06024DCE RID: 150990 RVA: 0x009AA238 File Offset: 0x009A8438
		public unsafe bool CurveStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_53) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_53) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004E69 RID: 20073
		// (get) Token: 0x06024DCF RID: 150991 RVA: 0x009AA24C File Offset: 0x009A844C
		// (set) Token: 0x06024DD0 RID: 150992 RVA: 0x009AA285 File Offset: 0x009A8485
		[Nullable(1)]
		public FKuroCurveFloat ProgressCurve
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._ProgressCurve) == null)
				{
					result = (this._ProgressCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_54, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_54, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004E6A RID: 20074
		// (get) Token: 0x06024DD1 RID: 150993 RVA: 0x009AA2A6 File Offset: 0x009A84A6
		// (set) Token: 0x06024DD2 RID: 150994 RVA: 0x009AA2B6 File Offset: 0x009A84B6
		public unsafe bool bInstantHide
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_55) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudPrefab_C.__PropertyOffset_55) = (value ? 1 : 0);
			}
		}

		// Token: 0x06024DD3 RID: 150995 RVA: 0x009AA2C8 File Offset: 0x009A84C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OverrideMountainMeshAndMaterial(UMaterialInstance MaterialInstance, UStaticMesh Mesh)
		{
			BP_CloudPrefab_C.__OverrideMountainMeshAndMaterial_FunctionParams* ptr = stackalloc BP_CloudPrefab_C.__OverrideMountainMeshAndMaterial_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_CloudPrefab_C.__OverrideMountainMeshAndMaterial_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudPrefab_C.__OverrideMountainMeshAndMaterial_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MaterialInstance = ((MaterialInstance != null) ? MaterialInstance.NativePtr : IntPtr.Zero);
			ptr->Mesh = ((Mesh != null) ? Mesh.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudPrefab_C.__OverrideMountainMeshAndMaterial_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024DD4 RID: 150996 RVA: 0x009AA334 File Offset: 0x009A8534
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CurveProgress(ref bool stop)
		{
			BP_CloudPrefab_C.__CurveProgress_FunctionParams* ptr = stackalloc BP_CloudPrefab_C.__CurveProgress_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_CloudPrefab_C.__CurveProgress_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudPrefab_C.__CurveProgress_NativeFunctionPtr, (void*)ptr, 1);
			ptr->stop = stop;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudPrefab_C.__CurveProgress_NativeFunctionPtr, (void*)ptr);
			stop = ptr->stop;
		}

		// Token: 0x06024DD5 RID: 150997 RVA: 0x009AA384 File Offset: 0x009A8584
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OverrideCloudTopMaterial(UMaterialInstance MaterialInstance)
		{
			BP_CloudPrefab_C.__OverrideCloudTopMaterial_FunctionParams* ptr = stackalloc BP_CloudPrefab_C.__OverrideCloudTopMaterial_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_CloudPrefab_C.__OverrideCloudTopMaterial_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudPrefab_C.__OverrideCloudTopMaterial_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MaterialInstance = ((MaterialInstance != null) ? MaterialInstance.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudPrefab_C.__OverrideCloudTopMaterial_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024DD6 RID: 150998 RVA: 0x009AA3DC File Offset: 0x009A85DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OverrideBigShapeMaterial(UMaterialInstance MaterialInstance)
		{
			BP_CloudPrefab_C.__OverrideBigShapeMaterial_FunctionParams* ptr = stackalloc BP_CloudPrefab_C.__OverrideBigShapeMaterial_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_CloudPrefab_C.__OverrideBigShapeMaterial_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudPrefab_C.__OverrideBigShapeMaterial_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MaterialInstance = ((MaterialInstance != null) ? MaterialInstance.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudPrefab_C.__OverrideBigShapeMaterial_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024DD7 RID: 150999 RVA: 0x009AA434 File Offset: 0x009A8634
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ShouldCloudMove(FVectorDouble InLocation, ref bool bMove, ref FVectorDouble NewLocation)
		{
			BP_CloudPrefab_C.__ShouldCloudMove_FunctionParams* ptr = stackalloc BP_CloudPrefab_C.__ShouldCloudMove_FunctionParams[(UIntPtr)231] + 15L / (long)sizeof(BP_CloudPrefab_C.__ShouldCloudMove_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudPrefab_C.__ShouldCloudMove_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InLocation = InLocation;
			ptr->bMove = bMove;
			ptr->NewLocation = NewLocation;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudPrefab_C.__ShouldCloudMove_NativeFunctionPtr, (void*)ptr);
			bMove = ptr->bMove;
			NewLocation = ptr->NewLocation;
		}

		// Token: 0x06024DD8 RID: 151000 RVA: 0x009AA4A8 File Offset: 0x009A86A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Single_POICloud_Parameters_Initial(UMaterialInstanceDynamic DMI, UStaticMeshComponent Mesh, FPOICloudParameters CloudStructParameter, int TransSortNumber)
		{
			BP_CloudPrefab_C.__Single_POICloud_Parameters_Initial_FunctionParams* ptr = stackalloc BP_CloudPrefab_C.__Single_POICloud_Parameters_Initial_FunctionParams[(UIntPtr)303] + 15L / (long)sizeof(BP_CloudPrefab_C.__Single_POICloud_Parameters_Initial_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudPrefab_C.__Single_POICloud_Parameters_Initial_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DMI = ((DMI != null) ? DMI.NativePtr : IntPtr.Zero);
			ptr->Mesh = ((Mesh != null) ? Mesh.NativePtr : IntPtr.Zero);
			if (CloudStructParameter != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPOICloudParameters.StaticStruct(), &ptr->CloudStructParameter, CloudStructParameter.NativePtr, 1, false);
			}
			ptr->TransSortNumber = TransSortNumber;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudPrefab_C.__Single_POICloud_Parameters_Initial_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024DD9 RID: 151001 RVA: 0x009AA540 File Offset: 0x009A8740
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Single_Building_Parameters_Initial(UMaterialInstanceDynamic DMI, UStaticMeshComponent Mesh, FAnomaliesParameters CloudStructParameter, int TransSortNumber)
		{
			BP_CloudPrefab_C.__Single_Building_Parameters_Initial_FunctionParams* ptr = stackalloc BP_CloudPrefab_C.__Single_Building_Parameters_Initial_FunctionParams[(UIntPtr)271] + 15L / (long)sizeof(BP_CloudPrefab_C.__Single_Building_Parameters_Initial_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudPrefab_C.__Single_Building_Parameters_Initial_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DMI = ((DMI != null) ? DMI.NativePtr : IntPtr.Zero);
			ptr->Mesh = ((Mesh != null) ? Mesh.NativePtr : IntPtr.Zero);
			if (CloudStructParameter != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnomaliesParameters.StaticStruct(), &ptr->CloudStructParameter, CloudStructParameter.NativePtr, 1, false);
			}
			ptr->TransSortNumber = TransSortNumber;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudPrefab_C.__Single_Building_Parameters_Initial_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024DDA RID: 151002 RVA: 0x009AA5D8 File Offset: 0x009A87D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdatePerFourFrame()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudPrefab_C.__UpdatePerFourFrame_NativeFunctionPtr, null);
		}

		// Token: 0x06024DDB RID: 151003 RVA: 0x009AA5EC File Offset: 0x009A87EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Single_Cloud_Parameters_Initial(UMaterialInstanceDynamic DMI, UStaticMeshComponent Mesh, FCloudParameters CloudStructParameter, int TransSortNumber)
		{
			BP_CloudPrefab_C.__Single_Cloud_Parameters_Initial_FunctionParams* ptr = stackalloc BP_CloudPrefab_C.__Single_Cloud_Parameters_Initial_FunctionParams[(UIntPtr)431] + 15L / (long)sizeof(BP_CloudPrefab_C.__Single_Cloud_Parameters_Initial_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudPrefab_C.__Single_Cloud_Parameters_Initial_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DMI = ((DMI != null) ? DMI.NativePtr : IntPtr.Zero);
			ptr->Mesh = ((Mesh != null) ? Mesh.NativePtr : IntPtr.Zero);
			if (CloudStructParameter != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FCloudParameters.StaticStruct(), &ptr->CloudStructParameter, CloudStructParameter.NativePtr, 1, false);
			}
			ptr->TransSortNumber = TransSortNumber;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudPrefab_C.__Single_Cloud_Parameters_Initial_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_CloudPrefab_C.__Single_Cloud_Parameters_Initial_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06024DDC RID: 151004 RVA: 0x009AA695 File Offset: 0x009A8895
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Cloud_Initial()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudPrefab_C.__Cloud_Initial_NativeFunctionPtr, null);
		}

		// Token: 0x06024DDD RID: 151005 RVA: 0x009AA6AC File Offset: 0x009A88AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Timer(bool Forward, float DeltaTime, float Speed, ref float time, ref bool Stop)
		{
			BP_CloudPrefab_C.__Timer_FunctionParams* ptr = stackalloc BP_CloudPrefab_C.__Timer_FunctionParams[(UIntPtr)51] + 15L / (long)sizeof(BP_CloudPrefab_C.__Timer_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudPrefab_C.__Timer_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Forward = Forward;
			ptr->DeltaTime = DeltaTime;
			ptr->Speed = Speed;
			ptr->time = time;
			ptr->Stop = Stop;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudPrefab_C.__Timer_NativeFunctionPtr, (void*)ptr);
			time = ptr->time;
			Stop = ptr->Stop;
		}

		// Token: 0x06024DDE RID: 151006 RVA: 0x009AA724 File Offset: 0x009A8924
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AddCloudRotation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudPrefab_C.__AddCloudRotation_NativeFunctionPtr, null);
		}

		// Token: 0x06024DDF RID: 151007 RVA: 0x009AA738 File Offset: 0x009A8938
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Hidden(bool InstantHide)
		{
			BP_CloudPrefab_C.__Hidden_FunctionParams* ptr = stackalloc BP_CloudPrefab_C.__Hidden_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_CloudPrefab_C.__Hidden_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudPrefab_C.__Hidden_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InstantHide = InstantHide;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudPrefab_C.__Hidden_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024DE0 RID: 151008 RVA: 0x009AA780 File Offset: 0x009A8980
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Active(bool bInstantHide)
		{
			BP_CloudPrefab_C.__Active_FunctionParams* ptr = stackalloc BP_CloudPrefab_C.__Active_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_CloudPrefab_C.__Active_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudPrefab_C.__Active_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bInstantHide = bInstantHide;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudPrefab_C.__Active_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024DE1 RID: 151009 RVA: 0x009AA7C6 File Offset: 0x009A89C6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudPrefab_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06024DE2 RID: 151010 RVA: 0x009AA7DA File Offset: 0x009A89DA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CloudPrefab_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024DE3 RID: 151011 RVA: 0x009AA7F0 File Offset: 0x009A89F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_CloudPrefab_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CloudPrefab_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CloudPrefab_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudPrefab_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudPrefab_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024DE4 RID: 151012 RVA: 0x009AA838 File Offset: 0x009A8A38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_CloudPrefab_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CloudPrefab_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CloudPrefab_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudPrefab_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CloudPrefab_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024DE5 RID: 151013 RVA: 0x009AA880 File Offset: 0x009A8A80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CloudPrefab_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CloudPrefab_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CloudPrefab_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudPrefab_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudPrefab_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024DE6 RID: 151014 RVA: 0x009AA8C8 File Offset: 0x009A8AC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CloudPrefab_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CloudPrefab_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CloudPrefab_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudPrefab_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CloudPrefab_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024DE7 RID: 151015 RVA: 0x009AA90F File Offset: 0x009A8B0F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudPrefab_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024DE8 RID: 151016 RVA: 0x009AA923 File Offset: 0x009A8B23
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CloudPrefab_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024DE9 RID: 151017 RVA: 0x009AA938 File Offset: 0x009A8B38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CloudPrefab(int EntryPoint)
		{
			BP_CloudPrefab_C.__ExecuteUbergraph_BP_CloudPrefab_FunctionParams* ptr = stackalloc BP_CloudPrefab_C.__ExecuteUbergraph_BP_CloudPrefab_FunctionParams[(UIntPtr)887] + 15L / (long)sizeof(BP_CloudPrefab_C.__ExecuteUbergraph_BP_CloudPrefab_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudPrefab_C.__ExecuteUbergraph_BP_CloudPrefab_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CloudPrefab_C.__ExecuteUbergraph_BP_CloudPrefab_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024DEA RID: 151018 RVA: 0x009AA982 File Offset: 0x009A8B82
		protected BP_CloudPrefab_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012E6E RID: 77422
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_CloudPrefab.BP_CloudPrefab_C";

		// Token: 0x04012E6F RID: 77423
		private static IntPtr _ClassPtr;

		// Token: 0x04012E70 RID: 77424
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012E71 RID: 77425
		internal static int __PropertyOffset_0;

		// Token: 0x04012E72 RID: 77426
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012E73 RID: 77427
		internal static int __PropertyOffset_1;

		// Token: 0x04012E74 RID: 77428
		internal static int __PropertyOffset_2;

		// Token: 0x04012E75 RID: 77429
		internal static int __PropertyOffset_3;

		// Token: 0x04012E76 RID: 77430
		internal static int __PropertyOffset_4;

		// Token: 0x04012E77 RID: 77431
		internal static int __PropertyOffset_5;

		// Token: 0x04012E78 RID: 77432
		internal static int __PropertyOffset_6;

		// Token: 0x04012E79 RID: 77433
		internal static int __PropertyOffset_7;

		// Token: 0x04012E7A RID: 77434
		internal static int __PropertyOffset_8;

		// Token: 0x04012E7B RID: 77435
		internal static int __PropertyOffset_9;

		// Token: 0x04012E7C RID: 77436
		internal static int __PropertyOffset_10;

		// Token: 0x04012E7D RID: 77437
		internal static int __PropertyOffset_11;

		// Token: 0x04012E7E RID: 77438
		internal static int __PropertyOffset_12;

		// Token: 0x04012E7F RID: 77439
		internal static int __PropertyOffset_13;

		// Token: 0x04012E80 RID: 77440
		internal static int __PropertyOffset_14;

		// Token: 0x04012E81 RID: 77441
		internal static int __PropertyOffset_15;

		// Token: 0x04012E82 RID: 77442
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _DMI;

		// Token: 0x04012E83 RID: 77443
		internal static int __PropertyOffset_16;

		// Token: 0x04012E84 RID: 77444
		internal static int __PropertyOffset_17;

		// Token: 0x04012E85 RID: 77445
		internal static int __PropertyOffset_18;

		// Token: 0x04012E86 RID: 77446
		internal static int __PropertyOffset_19;

		// Token: 0x04012E87 RID: 77447
		internal static int __PropertyOffset_20;

		// Token: 0x04012E88 RID: 77448
		internal static int __PropertyOffset_21;

		// Token: 0x04012E89 RID: 77449
		internal static int __PropertyOffset_22;

		// Token: 0x04012E8A RID: 77450
		internal static int __PropertyOffset_23;

		// Token: 0x04012E8B RID: 77451
		internal static int __PropertyOffset_24;

		// Token: 0x04012E8C RID: 77452
		internal static int __PropertyOffset_25;

		// Token: 0x04012E8D RID: 77453
		internal static int __PropertyOffset_26;

		// Token: 0x04012E8E RID: 77454
		internal static int __PropertyOffset_27;

		// Token: 0x04012E8F RID: 77455
		internal static int __PropertyOffset_28;

		// Token: 0x04012E90 RID: 77456
		internal static int __PropertyOffset_29;

		// Token: 0x04012E91 RID: 77457
		internal static int __PropertyOffset_30;

		// Token: 0x04012E92 RID: 77458
		internal static int __PropertyOffset_31;

		// Token: 0x04012E93 RID: 77459
		internal static int __PropertyOffset_32;

		// Token: 0x04012E94 RID: 77460
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMeshComponent> _MeshArray;

		// Token: 0x04012E95 RID: 77461
		internal static int __PropertyOffset_33;

		// Token: 0x04012E96 RID: 77462
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _DMIArray;

		// Token: 0x04012E97 RID: 77463
		internal static int __PropertyOffset_34;

		// Token: 0x04012E98 RID: 77464
		internal static int __PropertyOffset_35;

		// Token: 0x04012E99 RID: 77465
		private TArray<int> _Trans;

		// Token: 0x04012E9A RID: 77466
		internal static int __PropertyOffset_36;

		// Token: 0x04012E9B RID: 77467
		internal static int __PropertyOffset_37;

		// Token: 0x04012E9C RID: 77468
		internal static int __PropertyOffset_38;

		// Token: 0x04012E9D RID: 77469
		internal static int __PropertyOffset_39;

		// Token: 0x04012E9E RID: 77470
		internal static int __PropertyOffset_40;

		// Token: 0x04012E9F RID: 77471
		internal static int __PropertyOffset_41;

		// Token: 0x04012EA0 RID: 77472
		internal static int __PropertyOffset_42;

		// Token: 0x04012EA1 RID: 77473
		internal static int __PropertyOffset_43;

		// Token: 0x04012EA2 RID: 77474
		internal static int __PropertyOffset_44;

		// Token: 0x04012EA3 RID: 77475
		internal static int __PropertyOffset_45;

		// Token: 0x04012EA4 RID: 77476
		internal static int __PropertyOffset_46;

		// Token: 0x04012EA5 RID: 77477
		internal static int __PropertyOffset_47;

		// Token: 0x04012EA6 RID: 77478
		internal static int __PropertyOffset_48;

		// Token: 0x04012EA7 RID: 77479
		internal static int __PropertyOffset_49;

		// Token: 0x04012EA8 RID: 77480
		internal static int __PropertyOffset_50;

		// Token: 0x04012EA9 RID: 77481
		internal static int __PropertyOffset_51;

		// Token: 0x04012EAA RID: 77482
		internal static int __PropertyOffset_52;

		// Token: 0x04012EAB RID: 77483
		internal static int __PropertyOffset_53;

		// Token: 0x04012EAC RID: 77484
		internal static int __PropertyOffset_54;

		// Token: 0x04012EAD RID: 77485
		private FKuroCurveFloat _ProgressCurve;

		// Token: 0x04012EAE RID: 77486
		internal static int __PropertyOffset_55;

		// Token: 0x04012EAF RID: 77487
		private static IntPtr __OverrideMountainMeshAndMaterial_NativeFunctionPtr;

		// Token: 0x04012EB0 RID: 77488
		private static IntPtr __CurveProgress_NativeFunctionPtr;

		// Token: 0x04012EB1 RID: 77489
		private static IntPtr __OverrideCloudTopMaterial_NativeFunctionPtr;

		// Token: 0x04012EB2 RID: 77490
		private static IntPtr __OverrideBigShapeMaterial_NativeFunctionPtr;

		// Token: 0x04012EB3 RID: 77491
		private static IntPtr __ShouldCloudMove_NativeFunctionPtr;

		// Token: 0x04012EB4 RID: 77492
		private static IntPtr __Single_POICloud_Parameters_Initial_NativeFunctionPtr;

		// Token: 0x04012EB5 RID: 77493
		private static IntPtr __Single_Building_Parameters_Initial_NativeFunctionPtr;

		// Token: 0x04012EB6 RID: 77494
		private static IntPtr __UpdatePerFourFrame_NativeFunctionPtr;

		// Token: 0x04012EB7 RID: 77495
		private static IntPtr __Single_Cloud_Parameters_Initial_NativeFunctionPtr;

		// Token: 0x04012EB8 RID: 77496
		private static IntPtr __Cloud_Initial_NativeFunctionPtr;

		// Token: 0x04012EB9 RID: 77497
		private static IntPtr __Timer_NativeFunctionPtr;

		// Token: 0x04012EBA RID: 77498
		private static IntPtr __AddCloudRotation_NativeFunctionPtr;

		// Token: 0x04012EBB RID: 77499
		private static IntPtr __Hidden_NativeFunctionPtr;

		// Token: 0x04012EBC RID: 77500
		private static IntPtr __Active_NativeFunctionPtr;

		// Token: 0x04012EBD RID: 77501
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012EBE RID: 77502
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04012EBF RID: 77503
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012EC0 RID: 77504
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012EC1 RID: 77505
		private static IntPtr __ExecuteUbergraph_BP_CloudPrefab_NativeFunctionPtr;

		// Token: 0x02009E80 RID: 40576
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OverrideMountainMeshAndMaterial_FunctionParams
		{
			// Token: 0x040328FA RID: 207098
			[FieldOffset(0)]
			public IntPtr MaterialInstance;

			// Token: 0x040328FB RID: 207099
			[FieldOffset(8)]
			public IntPtr Mesh;
		}

		// Token: 0x02009E81 RID: 40577
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __CurveProgress_FunctionParams
		{
			// Token: 0x040328FC RID: 207100
			[FieldOffset(0)]
			public bool stop;
		}

		// Token: 0x02009E82 RID: 40578
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __OverrideCloudTopMaterial_FunctionParams
		{
			// Token: 0x040328FD RID: 207101
			[FieldOffset(0)]
			public IntPtr MaterialInstance;
		}

		// Token: 0x02009E83 RID: 40579
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __OverrideBigShapeMaterial_FunctionParams
		{
			// Token: 0x040328FE RID: 207102
			[FieldOffset(0)]
			public IntPtr MaterialInstance;
		}

		// Token: 0x02009E84 RID: 40580
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 216)]
		protected ref struct __ShouldCloudMove_FunctionParams
		{
			// Token: 0x040328FF RID: 207103
			[FieldOffset(0)]
			public FVectorDouble InLocation;

			// Token: 0x04032900 RID: 207104
			[FieldOffset(24)]
			public bool bMove;

			// Token: 0x04032901 RID: 207105
			[FieldOffset(32)]
			public FVectorDouble NewLocation;
		}

		// Token: 0x02009E85 RID: 40581
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 288)]
		protected ref struct __Single_POICloud_Parameters_Initial_FunctionParams
		{
			// Token: 0x04032902 RID: 207106
			[FieldOffset(0)]
			public IntPtr DMI;

			// Token: 0x04032903 RID: 207107
			[FieldOffset(8)]
			public IntPtr Mesh;

			// Token: 0x04032904 RID: 207108
			[FieldOffset(16)]
			public byte CloudStructParameter;

			// Token: 0x04032905 RID: 207109
			[FieldOffset(80)]
			public int TransSortNumber;
		}

		// Token: 0x02009E86 RID: 40582
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 256)]
		protected ref struct __Single_Building_Parameters_Initial_FunctionParams
		{
			// Token: 0x04032906 RID: 207110
			[FieldOffset(0)]
			public IntPtr DMI;

			// Token: 0x04032907 RID: 207111
			[FieldOffset(8)]
			public IntPtr Mesh;

			// Token: 0x04032908 RID: 207112
			[FieldOffset(16)]
			public byte CloudStructParameter;

			// Token: 0x04032909 RID: 207113
			[FieldOffset(72)]
			public int TransSortNumber;
		}

		// Token: 0x02009E87 RID: 40583
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 416)]
		protected ref struct __Single_Cloud_Parameters_Initial_FunctionParams
		{
			// Token: 0x0403290A RID: 207114
			[FieldOffset(0)]
			public IntPtr DMI;

			// Token: 0x0403290B RID: 207115
			[FieldOffset(8)]
			public IntPtr Mesh;

			// Token: 0x0403290C RID: 207116
			[FieldOffset(16)]
			public byte CloudStructParameter;

			// Token: 0x0403290D RID: 207117
			[FieldOffset(216)]
			public int TransSortNumber;
		}

		// Token: 0x02009E88 RID: 40584
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 36)]
		protected ref struct __Timer_FunctionParams
		{
			// Token: 0x0403290E RID: 207118
			[FieldOffset(0)]
			public bool Forward;

			// Token: 0x0403290F RID: 207119
			[FieldOffset(4)]
			public float DeltaTime;

			// Token: 0x04032910 RID: 207120
			[FieldOffset(8)]
			public float Speed;

			// Token: 0x04032911 RID: 207121
			[FieldOffset(12)]
			public float time;

			// Token: 0x04032912 RID: 207122
			[FieldOffset(16)]
			public bool Stop;
		}

		// Token: 0x02009E89 RID: 40585
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __Hidden_FunctionParams
		{
			// Token: 0x04032913 RID: 207123
			[FieldOffset(0)]
			public bool InstantHide;
		}

		// Token: 0x02009E8A RID: 40586
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __Active_FunctionParams
		{
			// Token: 0x04032914 RID: 207124
			[FieldOffset(0)]
			public bool bInstantHide;
		}

		// Token: 0x02009E8B RID: 40587
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032915 RID: 207125
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E8C RID: 40588
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032916 RID: 207126
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E8D RID: 40589
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 872)]
		protected ref struct __ExecuteUbergraph_BP_CloudPrefab_FunctionParams
		{
			// Token: 0x04032917 RID: 207127
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
