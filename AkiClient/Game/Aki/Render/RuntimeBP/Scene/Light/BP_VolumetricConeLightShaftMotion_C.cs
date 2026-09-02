using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A9D RID: 15005
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricConeLightShaftMotion.BP_VolumetricConeLightShaftMotion_C")]
	[UnrealStructLayout(2480, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2476)]
	public class BP_VolumetricConeLightShaftMotion_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject, IInterface_KuroLightBP, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0601FB2F RID: 129839 RVA: 0x0091851C File Offset: 0x0091671C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VolumetricConeLightShaftMotion_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricConeLightShaftMotion.BP_VolumetricConeLightShaftMotion_C");
			}
			return BP_VolumetricConeLightShaftMotion_C._ClassPtr;
		}

		// Token: 0x0601FB30 RID: 129840 RVA: 0x00918540 File Offset: 0x00916740
		int IInterface_KuroLightBP.InterfaceOffset()
		{
			return BP_VolumetricConeLightShaftMotion_C.__InterfaceOffset_IInterface_KuroLightBP;
		}

		// Token: 0x0601FB31 RID: 129841 RVA: 0x00918548 File Offset: 0x00916748
		public BP_VolumetricConeLightShaftMotion_C() : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricConeLightShaftMotion_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601FB32 RID: 129842 RVA: 0x00918570 File Offset: 0x00916770
		[NullableContext(1)]
		public BP_VolumetricConeLightShaftMotion_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricConeLightShaftMotion_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003174 RID: 12660
		// (get) Token: 0x0601FB33 RID: 129843 RVA: 0x009185A4 File Offset: 0x009167A4
		// (set) Token: 0x0601FB34 RID: 129844 RVA: 0x009185DD File Offset: 0x009167DD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003175 RID: 12661
		// (get) Token: 0x0601FB35 RID: 129845 RVA: 0x009185FE File Offset: 0x009167FE
		// (set) Token: 0x0601FB36 RID: 129846 RVA: 0x00918612 File Offset: 0x00916812
		public unsafe USpotLightComponent SpotLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpotLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003176 RID: 12662
		// (get) Token: 0x0601FB37 RID: 129847 RVA: 0x00918627 File Offset: 0x00916827
		// (set) Token: 0x0601FB38 RID: 129848 RVA: 0x0091863B File Offset: 0x0091683B
		public unsafe UStaticMeshComponent SM_Ird_Lig_03AS
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003177 RID: 12663
		// (get) Token: 0x0601FB39 RID: 129849 RVA: 0x00918650 File Offset: 0x00916850
		// (set) Token: 0x0601FB3A RID: 129850 RVA: 0x00918664 File Offset: 0x00916864
		public unsafe UStaticMeshComponent SM_Lightshaft02
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003178 RID: 12664
		// (get) Token: 0x0601FB3B RID: 129851 RVA: 0x00918679 File Offset: 0x00916879
		// (set) Token: 0x0601FB3C RID: 129852 RVA: 0x0091868D File Offset: 0x0091688D
		public unsafe UStaticMeshComponent SM_LightFlare
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003179 RID: 12665
		// (get) Token: 0x0601FB3D RID: 129853 RVA: 0x009186A2 File Offset: 0x009168A2
		// (set) Token: 0x0601FB3E RID: 129854 RVA: 0x009186B6 File Offset: 0x009168B6
		public unsafe UStaticMeshComponent Sphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700317A RID: 12666
		// (get) Token: 0x0601FB3F RID: 129855 RVA: 0x009186CB File Offset: 0x009168CB
		// (set) Token: 0x0601FB40 RID: 129856 RVA: 0x009186DF File Offset: 0x009168DF
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x1700317B RID: 12667
		// (get) Token: 0x0601FB41 RID: 129857 RVA: 0x009186F4 File Offset: 0x009168F4
		// (set) Token: 0x0601FB42 RID: 129858 RVA: 0x00918704 File Offset: 0x00916904
		public unsafe bool EnableSpotLight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700317C RID: 12668
		// (get) Token: 0x0601FB43 RID: 129859 RVA: 0x00918715 File Offset: 0x00916915
		// (set) Token: 0x0601FB44 RID: 129860 RVA: 0x00918729 File Offset: 0x00916929
		public unsafe UMaterialInstance MaterialInstance
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x1700317D RID: 12669
		// (get) Token: 0x0601FB45 RID: 129861 RVA: 0x0091873E File Offset: 0x0091693E
		// (set) Token: 0x0601FB46 RID: 129862 RVA: 0x00918752 File Offset: 0x00916952
		public unsafe UMaterialInstance MaterialInstanceB
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x1700317E RID: 12670
		// (get) Token: 0x0601FB47 RID: 129863 RVA: 0x00918767 File Offset: 0x00916967
		// (set) Token: 0x0601FB48 RID: 129864 RVA: 0x0091877B File Offset: 0x0091697B
		public unsafe UMaterialInstance MaterialInstanceBT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x1700317F RID: 12671
		// (get) Token: 0x0601FB49 RID: 129865 RVA: 0x00918790 File Offset: 0x00916990
		// (set) Token: 0x0601FB4A RID: 129866 RVA: 0x009187A4 File Offset: 0x009169A4
		public unsafe UMaterialInstance MaterialInstanceT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17003180 RID: 12672
		// (get) Token: 0x0601FB4B RID: 129867 RVA: 0x009187B9 File Offset: 0x009169B9
		// (set) Token: 0x0601FB4C RID: 129868 RVA: 0x009187CD File Offset: 0x009169CD
		public unsafe FVector MainScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003181 RID: 12673
		// (get) Token: 0x0601FB4D RID: 129869 RVA: 0x009187E2 File Offset: 0x009169E2
		// (set) Token: 0x0601FB4E RID: 129870 RVA: 0x009187F6 File Offset: 0x009169F6
		public unsafe FVector VolumetriConeScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003182 RID: 12674
		// (get) Token: 0x0601FB4F RID: 129871 RVA: 0x0091880B File Offset: 0x00916A0B
		// (set) Token: 0x0601FB50 RID: 129872 RVA: 0x0091881B File Offset: 0x00916A1B
		public unsafe bool EnableBottomColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003183 RID: 12675
		// (get) Token: 0x0601FB51 RID: 129873 RVA: 0x0091882C File Offset: 0x00916A2C
		// (set) Token: 0x0601FB52 RID: 129874 RVA: 0x0091883C File Offset: 0x00916A3C
		public unsafe bool IsWholeDay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003184 RID: 12676
		// (get) Token: 0x0601FB53 RID: 129875 RVA: 0x0091884D File Offset: 0x00916A4D
		// (set) Token: 0x0601FB54 RID: 129876 RVA: 0x0091885D File Offset: 0x00916A5D
		public unsafe bool EnableFlickent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003185 RID: 12677
		// (get) Token: 0x0601FB55 RID: 129877 RVA: 0x0091886E File Offset: 0x00916A6E
		// (set) Token: 0x0601FB56 RID: 129878 RVA: 0x0091887E File Offset: 0x00916A7E
		public unsafe float ConeSin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17003186 RID: 12678
		// (get) Token: 0x0601FB57 RID: 129879 RVA: 0x0091888F File Offset: 0x00916A8F
		// (set) Token: 0x0601FB58 RID: 129880 RVA: 0x0091889F File Offset: 0x00916A9F
		public unsafe float RadFallOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17003187 RID: 12679
		// (get) Token: 0x0601FB59 RID: 129881 RVA: 0x009188B0 File Offset: 0x00916AB0
		// (set) Token: 0x0601FB5A RID: 129882 RVA: 0x009188C0 File Offset: 0x00916AC0
		public unsafe float TopClip
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17003188 RID: 12680
		// (get) Token: 0x0601FB5B RID: 129883 RVA: 0x009188D1 File Offset: 0x00916AD1
		// (set) Token: 0x0601FB5C RID: 129884 RVA: 0x009188E1 File Offset: 0x00916AE1
		public unsafe float TopColorLerp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17003189 RID: 12681
		// (get) Token: 0x0601FB5D RID: 129885 RVA: 0x009188F2 File Offset: 0x00916AF2
		// (set) Token: 0x0601FB5E RID: 129886 RVA: 0x00918906 File Offset: 0x00916B06
		public unsafe FLinearColor TopColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x1700318A RID: 12682
		// (get) Token: 0x0601FB5F RID: 129887 RVA: 0x0091891B File Offset: 0x00916B1B
		// (set) Token: 0x0601FB60 RID: 129888 RVA: 0x0091892F File Offset: 0x00916B2F
		public unsafe FLinearColor BottomColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x1700318B RID: 12683
		// (get) Token: 0x0601FB61 RID: 129889 RVA: 0x00918944 File Offset: 0x00916B44
		// (set) Token: 0x0601FB62 RID: 129890 RVA: 0x00918954 File Offset: 0x00916B54
		public unsafe float SkyLightInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x1700318C RID: 12684
		// (get) Token: 0x0601FB63 RID: 129891 RVA: 0x00918965 File Offset: 0x00916B65
		// (set) Token: 0x0601FB64 RID: 129892 RVA: 0x00918975 File Offset: 0x00916B75
		public unsafe float SkyLightOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x1700318D RID: 12685
		// (get) Token: 0x0601FB65 RID: 129893 RVA: 0x00918986 File Offset: 0x00916B86
		// (set) Token: 0x0601FB66 RID: 129894 RVA: 0x00918996 File Offset: 0x00916B96
		public unsafe float BrightLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x1700318E RID: 12686
		// (get) Token: 0x0601FB67 RID: 129895 RVA: 0x009189A7 File Offset: 0x00916BA7
		// (set) Token: 0x0601FB68 RID: 129896 RVA: 0x009189B7 File Offset: 0x00916BB7
		public unsafe float FlickerTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x1700318F RID: 12687
		// (get) Token: 0x0601FB69 RID: 129897 RVA: 0x009189C8 File Offset: 0x00916BC8
		// (set) Token: 0x0601FB6A RID: 129898 RVA: 0x009189D8 File Offset: 0x00916BD8
		public unsafe float DepthFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17003190 RID: 12688
		// (get) Token: 0x0601FB6B RID: 129899 RVA: 0x009189E9 File Offset: 0x00916BE9
		// (set) Token: 0x0601FB6C RID: 129900 RVA: 0x009189F9 File Offset: 0x00916BF9
		public unsafe float ViewTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17003191 RID: 12689
		// (get) Token: 0x0601FB6D RID: 129901 RVA: 0x00918A0A File Offset: 0x00916C0A
		// (set) Token: 0x0601FB6E RID: 129902 RVA: 0x00918A1E File Offset: 0x00916C1E
		public unsafe FVector LightShaftScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17003192 RID: 12690
		// (get) Token: 0x0601FB6F RID: 129903 RVA: 0x00918A33 File Offset: 0x00916C33
		// (set) Token: 0x0601FB70 RID: 129904 RVA: 0x00918A47 File Offset: 0x00916C47
		public unsafe UMaterialInstance LightShaftCone
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_30);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x17003193 RID: 12691
		// (get) Token: 0x0601FB71 RID: 129905 RVA: 0x00918A5C File Offset: 0x00916C5C
		// (set) Token: 0x0601FB72 RID: 129906 RVA: 0x00918A70 File Offset: 0x00916C70
		public unsafe UTexture2D Mask
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_31);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_31, value);
			}
		}

		// Token: 0x17003194 RID: 12692
		// (get) Token: 0x0601FB73 RID: 129907 RVA: 0x00918A85 File Offset: 0x00916C85
		// (set) Token: 0x0601FB74 RID: 129908 RVA: 0x00918A99 File Offset: 0x00916C99
		public unsafe FLinearColor FallOff_ColorTint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17003195 RID: 12693
		// (get) Token: 0x0601FB75 RID: 129909 RVA: 0x00918AAE File Offset: 0x00916CAE
		// (set) Token: 0x0601FB76 RID: 129910 RVA: 0x00918ABE File Offset: 0x00916CBE
		public unsafe float FallOff_DepthFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17003196 RID: 12694
		// (get) Token: 0x0601FB77 RID: 129911 RVA: 0x00918ACF File Offset: 0x00916CCF
		// (set) Token: 0x0601FB78 RID: 129912 RVA: 0x00918ADF File Offset: 0x00916CDF
		public unsafe float ScreenFadeFrom
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17003197 RID: 12695
		// (get) Token: 0x0601FB79 RID: 129913 RVA: 0x00918AF0 File Offset: 0x00916CF0
		// (set) Token: 0x0601FB7A RID: 129914 RVA: 0x00918B00 File Offset: 0x00916D00
		public unsafe float Opacity_CenterPower
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x17003198 RID: 12696
		// (get) Token: 0x0601FB7B RID: 129915 RVA: 0x00918B11 File Offset: 0x00916D11
		// (set) Token: 0x0601FB7C RID: 129916 RVA: 0x00918B21 File Offset: 0x00916D21
		public unsafe float ScreenFadeDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17003199 RID: 12697
		// (get) Token: 0x0601FB7D RID: 129917 RVA: 0x00918B32 File Offset: 0x00916D32
		// (set) Token: 0x0601FB7E RID: 129918 RVA: 0x00918B42 File Offset: 0x00916D42
		public unsafe float ShaftTopClip
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x1700319A RID: 12698
		// (get) Token: 0x0601FB7F RID: 129919 RVA: 0x00918B53 File Offset: 0x00916D53
		// (set) Token: 0x0601FB80 RID: 129920 RVA: 0x00918B67 File Offset: 0x00916D67
		public unsafe FLinearColor UVScaleAndAdd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x1700319B RID: 12699
		// (get) Token: 0x0601FB81 RID: 129921 RVA: 0x00918B7C File Offset: 0x00916D7C
		// (set) Token: 0x0601FB82 RID: 129922 RVA: 0x00918B8C File Offset: 0x00916D8C
		public unsafe float LightMaskZaxis
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x1700319C RID: 12700
		// (get) Token: 0x0601FB83 RID: 129923 RVA: 0x00918B9D File Offset: 0x00916D9D
		// (set) Token: 0x0601FB84 RID: 129924 RVA: 0x00918BB1 File Offset: 0x00916DB1
		public unsafe UMaterialInstance LightMaskMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_40);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_40, value);
			}
		}

		// Token: 0x1700319D RID: 12701
		// (get) Token: 0x0601FB85 RID: 129925 RVA: 0x00918BC6 File Offset: 0x00916DC6
		// (set) Token: 0x0601FB86 RID: 129926 RVA: 0x00918BDA File Offset: 0x00916DDA
		public unsafe FVector LightMaskScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x1700319E RID: 12702
		// (get) Token: 0x0601FB87 RID: 129927 RVA: 0x00918BEF File Offset: 0x00916DEF
		// (set) Token: 0x0601FB88 RID: 129928 RVA: 0x00918C03 File Offset: 0x00916E03
		public unsafe FLinearColor LightMaskColorTint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x1700319F RID: 12703
		// (get) Token: 0x0601FB89 RID: 129929 RVA: 0x00918C18 File Offset: 0x00916E18
		// (set) Token: 0x0601FB8A RID: 129930 RVA: 0x00918C2C File Offset: 0x00916E2C
		public unsafe UTexture2D LightMaskTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_43);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_43, value);
			}
		}

		// Token: 0x170031A0 RID: 12704
		// (get) Token: 0x0601FB8B RID: 129931 RVA: 0x00918C41 File Offset: 0x00916E41
		// (set) Token: 0x0601FB8C RID: 129932 RVA: 0x00918C51 File Offset: 0x00916E51
		public unsafe float ColorIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x170031A1 RID: 12705
		// (get) Token: 0x0601FB8D RID: 129933 RVA: 0x00918C62 File Offset: 0x00916E62
		// (set) Token: 0x0601FB8E RID: 129934 RVA: 0x00918C72 File Offset: 0x00916E72
		public unsafe float Opacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x170031A2 RID: 12706
		// (get) Token: 0x0601FB8F RID: 129935 RVA: 0x00918C83 File Offset: 0x00916E83
		// (set) Token: 0x0601FB90 RID: 129936 RVA: 0x00918C93 File Offset: 0x00916E93
		public unsafe float FadeDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_46);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x170031A3 RID: 12707
		// (get) Token: 0x0601FB91 RID: 129937 RVA: 0x00918CA4 File Offset: 0x00916EA4
		// (set) Token: 0x0601FB92 RID: 129938 RVA: 0x00918CB4 File Offset: 0x00916EB4
		public unsafe float FlankInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x170031A4 RID: 12708
		// (get) Token: 0x0601FB93 RID: 129939 RVA: 0x00918CC5 File Offset: 0x00916EC5
		// (set) Token: 0x0601FB94 RID: 129940 RVA: 0x00918CD5 File Offset: 0x00916ED5
		public unsafe float Power
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x170031A5 RID: 12709
		// (get) Token: 0x0601FB95 RID: 129941 RVA: 0x00918CE6 File Offset: 0x00916EE6
		// (set) Token: 0x0601FB96 RID: 129942 RVA: 0x00918CF6 File Offset: 0x00916EF6
		public unsafe float RightSideInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_49);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_49) = value;
			}
		}

		// Token: 0x170031A6 RID: 12710
		// (get) Token: 0x0601FB97 RID: 129943 RVA: 0x00918D07 File Offset: 0x00916F07
		// (set) Token: 0x0601FB98 RID: 129944 RVA: 0x00918D17 File Offset: 0x00916F17
		public unsafe float Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_50);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_50) = value;
			}
		}

		// Token: 0x170031A7 RID: 12711
		// (get) Token: 0x0601FB99 RID: 129945 RVA: 0x00918D28 File Offset: 0x00916F28
		// (set) Token: 0x0601FB9A RID: 129946 RVA: 0x00918D38 File Offset: 0x00916F38
		public unsafe float AnimationSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x170031A8 RID: 12712
		// (get) Token: 0x0601FB9B RID: 129947 RVA: 0x00918D49 File Offset: 0x00916F49
		// (set) Token: 0x0601FB9C RID: 129948 RVA: 0x00918D59 File Offset: 0x00916F59
		public unsafe float AnimationAmount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_52);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_52) = value;
			}
		}

		// Token: 0x170031A9 RID: 12713
		// (get) Token: 0x0601FB9D RID: 129949 RVA: 0x00918D6A File Offset: 0x00916F6A
		// (set) Token: 0x0601FB9E RID: 129950 RVA: 0x00918D7A File Offset: 0x00916F7A
		public unsafe bool Tickable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_53) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_53) = (value ? 1 : 0);
			}
		}

		// Token: 0x170031AA RID: 12714
		// (get) Token: 0x0601FB9F RID: 129951 RVA: 0x00918D8B File Offset: 0x00916F8B
		// (set) Token: 0x0601FBA0 RID: 129952 RVA: 0x00918D9B File Offset: 0x00916F9B
		public unsafe float AnimationBias
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_54);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_54) = value;
			}
		}

		// Token: 0x170031AB RID: 12715
		// (get) Token: 0x0601FBA1 RID: 129953 RVA: 0x00918DAC File Offset: 0x00916FAC
		// (set) Token: 0x0601FBA2 RID: 129954 RVA: 0x00918DBC File Offset: 0x00916FBC
		public unsafe bool IsPC_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_55) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_55) = (value ? 1 : 0);
			}
		}

		// Token: 0x170031AC RID: 12716
		// (get) Token: 0x0601FBA3 RID: 129955 RVA: 0x00918DCD File Offset: 0x00916FCD
		// (set) Token: 0x0601FBA4 RID: 129956 RVA: 0x00918DDD File Offset: 0x00916FDD
		public unsafe bool UseNoiseTex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_56) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_56) = (value ? 1 : 0);
			}
		}

		// Token: 0x170031AD RID: 12717
		// (get) Token: 0x0601FBA5 RID: 129957 RVA: 0x00918DEE File Offset: 0x00916FEE
		// (set) Token: 0x0601FBA6 RID: 129958 RVA: 0x00918E02 File Offset: 0x00917002
		public unsafe UTexture MainNoiseTex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_57);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_57, value);
			}
		}

		// Token: 0x170031AE RID: 12718
		// (get) Token: 0x0601FBA7 RID: 129959 RVA: 0x00918E17 File Offset: 0x00917017
		// (set) Token: 0x0601FBA8 RID: 129960 RVA: 0x00918E2B File Offset: 0x0091702B
		public unsafe UTexture SecondNoiseTex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_58);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_58, value);
			}
		}

		// Token: 0x170031AF RID: 12719
		// (get) Token: 0x0601FBA9 RID: 129961 RVA: 0x00918E40 File Offset: 0x00917040
		// (set) Token: 0x0601FBAA RID: 129962 RVA: 0x00918E54 File Offset: 0x00917054
		public unsafe FLinearColor MainNoiseTexUVControl
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_59);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_59) = value;
			}
		}

		// Token: 0x170031B0 RID: 12720
		// (get) Token: 0x0601FBAB RID: 129963 RVA: 0x00918E69 File Offset: 0x00917069
		// (set) Token: 0x0601FBAC RID: 129964 RVA: 0x00918E7D File Offset: 0x0091707D
		public unsafe FLinearColor SecondNoiseTexUVControl
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_60);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_60) = value;
			}
		}

		// Token: 0x170031B1 RID: 12721
		// (get) Token: 0x0601FBAD RID: 129965 RVA: 0x00918E92 File Offset: 0x00917092
		// (set) Token: 0x0601FBAE RID: 129966 RVA: 0x00918EA2 File Offset: 0x009170A2
		public unsafe float MainUVAddStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_61);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_61) = value;
			}
		}

		// Token: 0x170031B2 RID: 12722
		// (get) Token: 0x0601FBAF RID: 129967 RVA: 0x00918EB3 File Offset: 0x009170B3
		// (set) Token: 0x0601FBB0 RID: 129968 RVA: 0x00918EC7 File Offset: 0x009170C7
		public unsafe FLinearColor MainNoiseColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_62);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_62) = value;
			}
		}

		// Token: 0x170031B3 RID: 12723
		// (get) Token: 0x0601FBB1 RID: 129969 RVA: 0x00918EDC File Offset: 0x009170DC
		// (set) Token: 0x0601FBB2 RID: 129970 RVA: 0x00918EF0 File Offset: 0x009170F0
		public unsafe FLinearColor SecondNoiseColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_63);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_63) = value;
			}
		}

		// Token: 0x170031B4 RID: 12724
		// (get) Token: 0x0601FBB3 RID: 129971 RVA: 0x00918F05 File Offset: 0x00917105
		// (set) Token: 0x0601FBB4 RID: 129972 RVA: 0x00918F19 File Offset: 0x00917119
		public unsafe UMaterialInstance LightShaftMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_64);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_64, value);
			}
		}

		// Token: 0x170031B5 RID: 12725
		// (get) Token: 0x0601FBB5 RID: 129973 RVA: 0x00918F2E File Offset: 0x0091712E
		// (set) Token: 0x0601FBB6 RID: 129974 RVA: 0x00918F42 File Offset: 0x00917142
		public unsafe UMaterialInstance LightShaftMaterial_InStage
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_65);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_65, value);
			}
		}

		// Token: 0x170031B6 RID: 12726
		// (get) Token: 0x0601FBB7 RID: 129975 RVA: 0x00918F58 File Offset: 0x00917158
		// (set) Token: 0x0601FBB8 RID: 129976 RVA: 0x00918F91 File Offset: 0x00917191
		[Nullable(1)]
		public TMap<FName, UTexture> LightShaftCone_Textures
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, UTexture> result;
				if ((result = this._LightShaftCone_Textures) == null)
				{
					result = (this._LightShaftCone_Textures = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_66, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.LightShaftCone_Textures.CopyAssign(value);
			}
		}

		// Token: 0x170031B7 RID: 12727
		// (get) Token: 0x0601FBB9 RID: 129977 RVA: 0x00918FA0 File Offset: 0x009171A0
		// (set) Token: 0x0601FBBA RID: 129978 RVA: 0x00918FD9 File Offset: 0x009171D9
		[Nullable(1)]
		public TMap<FName, float> LightShaftCone_Scalars
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._LightShaftCone_Scalars) == null)
				{
					result = (this._LightShaftCone_Scalars = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_67, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.LightShaftCone_Scalars.CopyAssign(value);
			}
		}

		// Token: 0x170031B8 RID: 12728
		// (get) Token: 0x0601FBBB RID: 129979 RVA: 0x00918FE8 File Offset: 0x009171E8
		// (set) Token: 0x0601FBBC RID: 129980 RVA: 0x00919021 File Offset: 0x00917221
		[Nullable(1)]
		public TMap<FName, FLinearColor> LightShaftCone_Vectors
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._LightShaftCone_Vectors) == null)
				{
					result = (this._LightShaftCone_Vectors = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_68, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.LightShaftCone_Vectors.CopyAssign(value);
			}
		}

		// Token: 0x170031B9 RID: 12729
		// (get) Token: 0x0601FBBD RID: 129981 RVA: 0x0091902F File Offset: 0x0091722F
		// (set) Token: 0x0601FBBE RID: 129982 RVA: 0x00919043 File Offset: 0x00917243
		public unsafe UMaterialInstanceDynamic LightShaftMaterial_DY
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_69);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_69, value);
			}
		}

		// Token: 0x170031BA RID: 12730
		// (get) Token: 0x0601FBBF RID: 129983 RVA: 0x00919058 File Offset: 0x00917258
		// (set) Token: 0x0601FBC0 RID: 129984 RVA: 0x00919068 File Offset: 0x00917268
		public unsafe bool 启用曲线
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_70) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_70) = (value ? 1 : 0);
			}
		}

		// Token: 0x170031BB RID: 12731
		// (get) Token: 0x0601FBC1 RID: 129985 RVA: 0x0091907C File Offset: 0x0091727C
		// (set) Token: 0x0601FBC2 RID: 129986 RVA: 0x009190B5 File Offset: 0x009172B5
		[Nullable(1)]
		public FKuroCurveVector 摆动曲线
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FKuroCurveVector result;
				if ((result = this._摆动曲线) == null)
				{
					result = (this._摆动曲线 = new FKuroCurveVector(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_71, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveVector.StaticStruct(), base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_71, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170031BC RID: 12732
		// (get) Token: 0x0601FBC3 RID: 129987 RVA: 0x009190D6 File Offset: 0x009172D6
		// (set) Token: 0x0601FBC4 RID: 129988 RVA: 0x009190E6 File Offset: 0x009172E6
		public unsafe float 曲线周期
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_72);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftMotion_C.__PropertyOffset_72) = value;
			}
		}

		// Token: 0x0601FBC5 RID: 129989 RVA: 0x009190F8 File Offset: 0x009172F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual int GetPlacementSortOrder()
		{
			BP_VolumetricConeLightShaftMotion_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaftMotion_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricConeLightShaftMotion_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaftMotion_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaftMotion_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601FBC6 RID: 129990 RVA: 0x00919140 File Offset: 0x00917340
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual int GetPlacementSortOrder_Implementation()
		{
			BP_VolumetricConeLightShaftMotion_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaftMotion_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricConeLightShaftMotion_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaftMotion_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaftMotion_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601FBC7 RID: 129991 RVA: 0x00919186 File Offset: 0x00917386
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update_in_Stage_Material()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaftMotion_C.__Update_in_Stage_Material_NativeFunctionPtr, null);
		}

		// Token: 0x0601FBC8 RID: 129992 RVA: 0x0091919A File Offset: 0x0091739A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 重置旋转()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaftMotion_C.__重置旋转_NativeFunctionPtr, null);
		}

		// Token: 0x0601FBC9 RID: 129993 RVA: 0x009191AE File Offset: 0x009173AE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaftMotion_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601FBCA RID: 129994 RVA: 0x009191C2 File Offset: 0x009173C2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaftMotion_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FBCB RID: 129995 RVA: 0x009191D7 File Offset: 0x009173D7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaftMotion_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601FBCC RID: 129996 RVA: 0x009191EB File Offset: 0x009173EB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaftMotion_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FBCD RID: 129997 RVA: 0x00919200 File Offset: 0x00917400
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_VolumetricConeLightShaftMotion_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaftMotion_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricConeLightShaftMotion_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaftMotion_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaftMotion_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FBCE RID: 129998 RVA: 0x00919248 File Offset: 0x00917448
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_VolumetricConeLightShaftMotion_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaftMotion_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricConeLightShaftMotion_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaftMotion_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaftMotion_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FBCF RID: 129999 RVA: 0x00919290 File Offset: 0x00917490
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_VolumetricConeLightShaftMotion_C.__EditorTick_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaftMotion_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricConeLightShaftMotion_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaftMotion_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaftMotion_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FBD0 RID: 130000 RVA: 0x009192D8 File Offset: 0x009174D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_VolumetricConeLightShaftMotion_C.__EditorTick_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaftMotion_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricConeLightShaftMotion_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaftMotion_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaftMotion_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FBD1 RID: 130001 RVA: 0x00919320 File Offset: 0x00917520
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_VolumetricConeLightShaftMotion(int EntryPoint)
		{
			BP_VolumetricConeLightShaftMotion_C.__ExecuteUbergraph_BP_VolumetricConeLightShaftMotion_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaftMotion_C.__ExecuteUbergraph_BP_VolumetricConeLightShaftMotion_FunctionParams[(UIntPtr)467] + 15L / (long)sizeof(BP_VolumetricConeLightShaftMotion_C.__ExecuteUbergraph_BP_VolumetricConeLightShaftMotion_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaftMotion_C.__ExecuteUbergraph_BP_VolumetricConeLightShaftMotion_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaftMotion_C.__ExecuteUbergraph_BP_VolumetricConeLightShaftMotion_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FBD2 RID: 130002 RVA: 0x0091936A File Offset: 0x0091756A
		protected BP_VolumetricConeLightShaftMotion_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FC43 RID: 64579
		internal static int __InterfaceOffset_IInterface_KuroLightBP;

		// Token: 0x0400FC44 RID: 64580
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricConeLightShaftMotion.BP_VolumetricConeLightShaftMotion_C";

		// Token: 0x0400FC45 RID: 64581
		private static IntPtr _ClassPtr;

		// Token: 0x0400FC46 RID: 64582
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FC47 RID: 64583
		internal static int __PropertyOffset_0;

		// Token: 0x0400FC48 RID: 64584
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FC49 RID: 64585
		internal static int __PropertyOffset_1;

		// Token: 0x0400FC4A RID: 64586
		internal static int __PropertyOffset_2;

		// Token: 0x0400FC4B RID: 64587
		internal static int __PropertyOffset_3;

		// Token: 0x0400FC4C RID: 64588
		internal static int __PropertyOffset_4;

		// Token: 0x0400FC4D RID: 64589
		internal static int __PropertyOffset_5;

		// Token: 0x0400FC4E RID: 64590
		internal static int __PropertyOffset_6;

		// Token: 0x0400FC4F RID: 64591
		internal static int __PropertyOffset_7;

		// Token: 0x0400FC50 RID: 64592
		internal static int __PropertyOffset_8;

		// Token: 0x0400FC51 RID: 64593
		internal static int __PropertyOffset_9;

		// Token: 0x0400FC52 RID: 64594
		internal static int __PropertyOffset_10;

		// Token: 0x0400FC53 RID: 64595
		internal static int __PropertyOffset_11;

		// Token: 0x0400FC54 RID: 64596
		internal static int __PropertyOffset_12;

		// Token: 0x0400FC55 RID: 64597
		internal static int __PropertyOffset_13;

		// Token: 0x0400FC56 RID: 64598
		internal static int __PropertyOffset_14;

		// Token: 0x0400FC57 RID: 64599
		internal static int __PropertyOffset_15;

		// Token: 0x0400FC58 RID: 64600
		internal static int __PropertyOffset_16;

		// Token: 0x0400FC59 RID: 64601
		internal static int __PropertyOffset_17;

		// Token: 0x0400FC5A RID: 64602
		internal static int __PropertyOffset_18;

		// Token: 0x0400FC5B RID: 64603
		internal static int __PropertyOffset_19;

		// Token: 0x0400FC5C RID: 64604
		internal static int __PropertyOffset_20;

		// Token: 0x0400FC5D RID: 64605
		internal static int __PropertyOffset_21;

		// Token: 0x0400FC5E RID: 64606
		internal static int __PropertyOffset_22;

		// Token: 0x0400FC5F RID: 64607
		internal static int __PropertyOffset_23;

		// Token: 0x0400FC60 RID: 64608
		internal static int __PropertyOffset_24;

		// Token: 0x0400FC61 RID: 64609
		internal static int __PropertyOffset_25;

		// Token: 0x0400FC62 RID: 64610
		internal static int __PropertyOffset_26;

		// Token: 0x0400FC63 RID: 64611
		internal static int __PropertyOffset_27;

		// Token: 0x0400FC64 RID: 64612
		internal static int __PropertyOffset_28;

		// Token: 0x0400FC65 RID: 64613
		internal static int __PropertyOffset_29;

		// Token: 0x0400FC66 RID: 64614
		internal static int __PropertyOffset_30;

		// Token: 0x0400FC67 RID: 64615
		internal static int __PropertyOffset_31;

		// Token: 0x0400FC68 RID: 64616
		internal static int __PropertyOffset_32;

		// Token: 0x0400FC69 RID: 64617
		internal static int __PropertyOffset_33;

		// Token: 0x0400FC6A RID: 64618
		internal static int __PropertyOffset_34;

		// Token: 0x0400FC6B RID: 64619
		internal static int __PropertyOffset_35;

		// Token: 0x0400FC6C RID: 64620
		internal static int __PropertyOffset_36;

		// Token: 0x0400FC6D RID: 64621
		internal static int __PropertyOffset_37;

		// Token: 0x0400FC6E RID: 64622
		internal static int __PropertyOffset_38;

		// Token: 0x0400FC6F RID: 64623
		internal static int __PropertyOffset_39;

		// Token: 0x0400FC70 RID: 64624
		internal static int __PropertyOffset_40;

		// Token: 0x0400FC71 RID: 64625
		internal static int __PropertyOffset_41;

		// Token: 0x0400FC72 RID: 64626
		internal static int __PropertyOffset_42;

		// Token: 0x0400FC73 RID: 64627
		internal static int __PropertyOffset_43;

		// Token: 0x0400FC74 RID: 64628
		internal static int __PropertyOffset_44;

		// Token: 0x0400FC75 RID: 64629
		internal static int __PropertyOffset_45;

		// Token: 0x0400FC76 RID: 64630
		internal static int __PropertyOffset_46;

		// Token: 0x0400FC77 RID: 64631
		internal static int __PropertyOffset_47;

		// Token: 0x0400FC78 RID: 64632
		internal static int __PropertyOffset_48;

		// Token: 0x0400FC79 RID: 64633
		internal static int __PropertyOffset_49;

		// Token: 0x0400FC7A RID: 64634
		internal static int __PropertyOffset_50;

		// Token: 0x0400FC7B RID: 64635
		internal static int __PropertyOffset_51;

		// Token: 0x0400FC7C RID: 64636
		internal static int __PropertyOffset_52;

		// Token: 0x0400FC7D RID: 64637
		internal static int __PropertyOffset_53;

		// Token: 0x0400FC7E RID: 64638
		internal static int __PropertyOffset_54;

		// Token: 0x0400FC7F RID: 64639
		internal static int __PropertyOffset_55;

		// Token: 0x0400FC80 RID: 64640
		internal static int __PropertyOffset_56;

		// Token: 0x0400FC81 RID: 64641
		internal static int __PropertyOffset_57;

		// Token: 0x0400FC82 RID: 64642
		internal static int __PropertyOffset_58;

		// Token: 0x0400FC83 RID: 64643
		internal static int __PropertyOffset_59;

		// Token: 0x0400FC84 RID: 64644
		internal static int __PropertyOffset_60;

		// Token: 0x0400FC85 RID: 64645
		internal static int __PropertyOffset_61;

		// Token: 0x0400FC86 RID: 64646
		internal static int __PropertyOffset_62;

		// Token: 0x0400FC87 RID: 64647
		internal static int __PropertyOffset_63;

		// Token: 0x0400FC88 RID: 64648
		internal static int __PropertyOffset_64;

		// Token: 0x0400FC89 RID: 64649
		internal static int __PropertyOffset_65;

		// Token: 0x0400FC8A RID: 64650
		internal static int __PropertyOffset_66;

		// Token: 0x0400FC8B RID: 64651
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _LightShaftCone_Textures;

		// Token: 0x0400FC8C RID: 64652
		internal static int __PropertyOffset_67;

		// Token: 0x0400FC8D RID: 64653
		private TMap<FName, float> _LightShaftCone_Scalars;

		// Token: 0x0400FC8E RID: 64654
		internal static int __PropertyOffset_68;

		// Token: 0x0400FC8F RID: 64655
		private TMap<FName, FLinearColor> _LightShaftCone_Vectors;

		// Token: 0x0400FC90 RID: 64656
		internal static int __PropertyOffset_69;

		// Token: 0x0400FC91 RID: 64657
		internal static int __PropertyOffset_70;

		// Token: 0x0400FC92 RID: 64658
		internal static int __PropertyOffset_71;

		// Token: 0x0400FC93 RID: 64659
		private FKuroCurveVector _摆动曲线;

		// Token: 0x0400FC94 RID: 64660
		internal static int __PropertyOffset_72;

		// Token: 0x0400FC95 RID: 64661
		private static IntPtr __GetPlacementSortOrder_NativeFunctionPtr;

		// Token: 0x0400FC96 RID: 64662
		private static IntPtr __Update_in_Stage_Material_NativeFunctionPtr;

		// Token: 0x0400FC97 RID: 64663
		private static IntPtr __重置旋转_NativeFunctionPtr;

		// Token: 0x0400FC98 RID: 64664
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FC99 RID: 64665
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FC9A RID: 64666
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FC9B RID: 64667
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400FC9C RID: 64668
		private static IntPtr __ExecuteUbergraph_BP_VolumetricConeLightShaftMotion_NativeFunctionPtr;

		// Token: 0x02009917 RID: 39191
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetPlacementSortOrder_FunctionParams
		{
			// Token: 0x04031F76 RID: 204662
			[FieldOffset(0)]
			public int __Result;
		}

		// Token: 0x02009918 RID: 39192
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F77 RID: 204663
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009919 RID: 39193
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031F78 RID: 204664
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200991A RID: 39194
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 452)]
		protected ref struct __ExecuteUbergraph_BP_VolumetricConeLightShaftMotion_FunctionParams
		{
			// Token: 0x04031F79 RID: 204665
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
