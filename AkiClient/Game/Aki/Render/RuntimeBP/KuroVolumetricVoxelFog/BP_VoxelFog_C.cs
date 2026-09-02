using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.KuroVolumetricVoxelFog
{
	// Token: 0x02003C6A RID: 15466
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/KuroVolumetricVoxelFog/BP_VoxelFog.BP_VoxelFog_C")]
	[UnrealStructLayout(1160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1156)]
	public class BP_VoxelFog_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023D55 RID: 146773 RVA: 0x0098D79C File Offset: 0x0098B99C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VoxelFog_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/KuroVolumetricVoxelFog/BP_VoxelFog.BP_VoxelFog_C");
			}
			return BP_VoxelFog_C._ClassPtr;
		}

		// Token: 0x06023D56 RID: 146774 RVA: 0x0098D7C0 File Offset: 0x0098B9C0
		public BP_VoxelFog_C() : this(BuiltinUtils.AllocNativeUObject(BP_VoxelFog_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023D57 RID: 146775 RVA: 0x0098D7E8 File Offset: 0x0098B9E8
		[NullableContext(1)]
		public BP_VoxelFog_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VoxelFog_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700488D RID: 18573
		// (get) Token: 0x06023D58 RID: 146776 RVA: 0x0098D81B File Offset: 0x0098BA1B
		// (set) Token: 0x06023D59 RID: 146777 RVA: 0x0098D82F File Offset: 0x0098BA2F
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VoxelFog_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VoxelFog_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x1700488E RID: 18574
		// (get) Token: 0x06023D5A RID: 146778 RVA: 0x0098D844 File Offset: 0x0098BA44
		// (set) Token: 0x06023D5B RID: 146779 RVA: 0x0098D858 File Offset: 0x0098BA58
		public unsafe UStaticMesh FogMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VoxelFog_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VoxelFog_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700488F RID: 18575
		// (get) Token: 0x06023D5C RID: 146780 RVA: 0x0098D86D File Offset: 0x0098BA6D
		// (set) Token: 0x06023D5D RID: 146781 RVA: 0x0098D87D File Offset: 0x0098BA7D
		public unsafe int FogXYScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17004890 RID: 18576
		// (get) Token: 0x06023D5E RID: 146782 RVA: 0x0098D88E File Offset: 0x0098BA8E
		// (set) Token: 0x06023D5F RID: 146783 RVA: 0x0098D89E File Offset: 0x0098BA9E
		public unsafe int FogZScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17004891 RID: 18577
		// (get) Token: 0x06023D60 RID: 146784 RVA: 0x0098D8AF File Offset: 0x0098BAAF
		// (set) Token: 0x06023D61 RID: 146785 RVA: 0x0098D8C3 File Offset: 0x0098BAC3
		public unsafe UMaterialInstance M_VoxelFog
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VoxelFog_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VoxelFog_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004892 RID: 18578
		// (get) Token: 0x06023D62 RID: 146786 RVA: 0x0098D8D8 File Offset: 0x0098BAD8
		// (set) Token: 0x06023D63 RID: 146787 RVA: 0x0098D8E8 File Offset: 0x0098BAE8
		public unsafe float BaseNoiseCtrl
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17004893 RID: 18579
		// (get) Token: 0x06023D64 RID: 146788 RVA: 0x0098D8F9 File Offset: 0x0098BAF9
		// (set) Token: 0x06023D65 RID: 146789 RVA: 0x0098D909 File Offset: 0x0098BB09
		public unsafe float BaseNoiseTill
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004894 RID: 18580
		// (get) Token: 0x06023D66 RID: 146790 RVA: 0x0098D91A File Offset: 0x0098BB1A
		// (set) Token: 0x06023D67 RID: 146791 RVA: 0x0098D92E File Offset: 0x0098BB2E
		public unsafe UTexture2D BaseNoiseTex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VoxelFog_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VoxelFog_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004895 RID: 18581
		// (get) Token: 0x06023D68 RID: 146792 RVA: 0x0098D943 File Offset: 0x0098BB43
		// (set) Token: 0x06023D69 RID: 146793 RVA: 0x0098D953 File Offset: 0x0098BB53
		public unsafe float SideFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004896 RID: 18582
		// (get) Token: 0x06023D6A RID: 146794 RVA: 0x0098D964 File Offset: 0x0098BB64
		// (set) Token: 0x06023D6B RID: 146795 RVA: 0x0098D974 File Offset: 0x0098BB74
		public unsafe float Flatten
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004897 RID: 18583
		// (get) Token: 0x06023D6C RID: 146796 RVA: 0x0098D985 File Offset: 0x0098BB85
		// (set) Token: 0x06023D6D RID: 146797 RVA: 0x0098D995 File Offset: 0x0098BB95
		public unsafe float Opacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17004898 RID: 18584
		// (get) Token: 0x06023D6E RID: 146798 RVA: 0x0098D9A6 File Offset: 0x0098BBA6
		// (set) Token: 0x06023D6F RID: 146799 RVA: 0x0098D9B6 File Offset: 0x0098BBB6
		public unsafe float WindDirectionX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17004899 RID: 18585
		// (get) Token: 0x06023D70 RID: 146800 RVA: 0x0098D9C7 File Offset: 0x0098BBC7
		// (set) Token: 0x06023D71 RID: 146801 RVA: 0x0098D9D7 File Offset: 0x0098BBD7
		public unsafe float WindDirectionY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x1700489A RID: 18586
		// (get) Token: 0x06023D72 RID: 146802 RVA: 0x0098D9E8 File Offset: 0x0098BBE8
		// (set) Token: 0x06023D73 RID: 146803 RVA: 0x0098D9FC File Offset: 0x0098BBFC
		public unsafe UTexture2D ShapeTex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VoxelFog_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VoxelFog_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x1700489B RID: 18587
		// (get) Token: 0x06023D74 RID: 146804 RVA: 0x0098DA11 File Offset: 0x0098BC11
		// (set) Token: 0x06023D75 RID: 146805 RVA: 0x0098DA25 File Offset: 0x0098BC25
		public unsafe FColor FogTopColorOne
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700489C RID: 18588
		// (get) Token: 0x06023D76 RID: 146806 RVA: 0x0098DA3A File Offset: 0x0098BC3A
		// (set) Token: 0x06023D77 RID: 146807 RVA: 0x0098DA4E File Offset: 0x0098BC4E
		public unsafe FColor FogTopColorTwo
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700489D RID: 18589
		// (get) Token: 0x06023D78 RID: 146808 RVA: 0x0098DA63 File Offset: 0x0098BC63
		// (set) Token: 0x06023D79 RID: 146809 RVA: 0x0098DA77 File Offset: 0x0098BC77
		public unsafe FColor FogBottomColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x1700489E RID: 18590
		// (get) Token: 0x06023D7A RID: 146810 RVA: 0x0098DA8C File Offset: 0x0098BC8C
		// (set) Token: 0x06023D7B RID: 146811 RVA: 0x0098DA9C File Offset: 0x0098BC9C
		public unsafe float DetailNoiseCtrl
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x1700489F RID: 18591
		// (get) Token: 0x06023D7C RID: 146812 RVA: 0x0098DAAD File Offset: 0x0098BCAD
		// (set) Token: 0x06023D7D RID: 146813 RVA: 0x0098DABD File Offset: 0x0098BCBD
		public unsafe float DetailSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170048A0 RID: 18592
		// (get) Token: 0x06023D7E RID: 146814 RVA: 0x0098DACE File Offset: 0x0098BCCE
		// (set) Token: 0x06023D7F RID: 146815 RVA: 0x0098DADE File Offset: 0x0098BCDE
		public unsafe float DetailTilling
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170048A1 RID: 18593
		// (get) Token: 0x06023D80 RID: 146816 RVA: 0x0098DAEF File Offset: 0x0098BCEF
		// (set) Token: 0x06023D81 RID: 146817 RVA: 0x0098DB03 File Offset: 0x0098BD03
		public unsafe UTexture2D DetailNoiseTex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VoxelFog_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VoxelFog_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x170048A2 RID: 18594
		// (get) Token: 0x06023D82 RID: 146818 RVA: 0x0098DB18 File Offset: 0x0098BD18
		// (set) Token: 0x06023D83 RID: 146819 RVA: 0x0098DB28 File Offset: 0x0098BD28
		public unsafe float ColorGradient
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x170048A3 RID: 18595
		// (get) Token: 0x06023D84 RID: 146820 RVA: 0x0098DB39 File Offset: 0x0098BD39
		// (set) Token: 0x06023D85 RID: 146821 RVA: 0x0098DB49 File Offset: 0x0098BD49
		public unsafe float EmssiveInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x170048A4 RID: 18596
		// (get) Token: 0x06023D86 RID: 146822 RVA: 0x0098DB5A File Offset: 0x0098BD5A
		// (set) Token: 0x06023D87 RID: 146823 RVA: 0x0098DB6A File Offset: 0x0098BD6A
		public unsafe float ShapeTexTill
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x170048A5 RID: 18597
		// (get) Token: 0x06023D88 RID: 146824 RVA: 0x0098DB7B File Offset: 0x0098BD7B
		// (set) Token: 0x06023D89 RID: 146825 RVA: 0x0098DB8B File Offset: 0x0098BD8B
		public unsafe float ShapeMoveX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x170048A6 RID: 18598
		// (get) Token: 0x06023D8A RID: 146826 RVA: 0x0098DB9C File Offset: 0x0098BD9C
		// (set) Token: 0x06023D8B RID: 146827 RVA: 0x0098DBAC File Offset: 0x0098BDAC
		public unsafe float ShapeMoveY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VoxelFog_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x06023D8C RID: 146828 RVA: 0x0098DBBD File Offset: 0x0098BDBD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VoxelFog_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023D8D RID: 146829 RVA: 0x0098DBD1 File Offset: 0x0098BDD1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VoxelFog_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023D8E RID: 146830 RVA: 0x0098DBE6 File Offset: 0x0098BDE6
		protected BP_VoxelFog_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040124B6 RID: 74934
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/KuroVolumetricVoxelFog/BP_VoxelFog.BP_VoxelFog_C";

		// Token: 0x040124B7 RID: 74935
		private static IntPtr _ClassPtr;

		// Token: 0x040124B8 RID: 74936
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040124B9 RID: 74937
		internal static int __PropertyOffset_0;

		// Token: 0x040124BA RID: 74938
		internal static int __PropertyOffset_1;

		// Token: 0x040124BB RID: 74939
		internal static int __PropertyOffset_2;

		// Token: 0x040124BC RID: 74940
		internal static int __PropertyOffset_3;

		// Token: 0x040124BD RID: 74941
		internal static int __PropertyOffset_4;

		// Token: 0x040124BE RID: 74942
		internal static int __PropertyOffset_5;

		// Token: 0x040124BF RID: 74943
		internal static int __PropertyOffset_6;

		// Token: 0x040124C0 RID: 74944
		internal static int __PropertyOffset_7;

		// Token: 0x040124C1 RID: 74945
		internal static int __PropertyOffset_8;

		// Token: 0x040124C2 RID: 74946
		internal static int __PropertyOffset_9;

		// Token: 0x040124C3 RID: 74947
		internal static int __PropertyOffset_10;

		// Token: 0x040124C4 RID: 74948
		internal static int __PropertyOffset_11;

		// Token: 0x040124C5 RID: 74949
		internal static int __PropertyOffset_12;

		// Token: 0x040124C6 RID: 74950
		internal static int __PropertyOffset_13;

		// Token: 0x040124C7 RID: 74951
		internal static int __PropertyOffset_14;

		// Token: 0x040124C8 RID: 74952
		internal static int __PropertyOffset_15;

		// Token: 0x040124C9 RID: 74953
		internal static int __PropertyOffset_16;

		// Token: 0x040124CA RID: 74954
		internal static int __PropertyOffset_17;

		// Token: 0x040124CB RID: 74955
		internal static int __PropertyOffset_18;

		// Token: 0x040124CC RID: 74956
		internal static int __PropertyOffset_19;

		// Token: 0x040124CD RID: 74957
		internal static int __PropertyOffset_20;

		// Token: 0x040124CE RID: 74958
		internal static int __PropertyOffset_21;

		// Token: 0x040124CF RID: 74959
		internal static int __PropertyOffset_22;

		// Token: 0x040124D0 RID: 74960
		internal static int __PropertyOffset_23;

		// Token: 0x040124D1 RID: 74961
		internal static int __PropertyOffset_24;

		// Token: 0x040124D2 RID: 74962
		internal static int __PropertyOffset_25;

		// Token: 0x040124D3 RID: 74963
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;
	}
}
