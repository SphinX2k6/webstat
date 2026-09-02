using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A9C RID: 15004
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_ToonShadowDecal.BP_ToonShadowDecal_C")]
	[UnrealStructLayout(1248, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1244)]
	public class BP_ToonShadowDecal_C : ADecalActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601FADA RID: 129754 RVA: 0x00917E34 File Offset: 0x00916034
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ToonShadowDecal_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_ToonShadowDecal.BP_ToonShadowDecal_C");
			}
			return BP_ToonShadowDecal_C._ClassPtr;
		}

		// Token: 0x0601FADB RID: 129755 RVA: 0x00917E58 File Offset: 0x00916058
		public BP_ToonShadowDecal_C() : this(BuiltinUtils.AllocNativeUObject(BP_ToonShadowDecal_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601FADC RID: 129756 RVA: 0x00917E80 File Offset: 0x00916080
		[NullableContext(1)]
		public BP_ToonShadowDecal_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ToonShadowDecal_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003150 RID: 12624
		// (get) Token: 0x0601FADD RID: 129757 RVA: 0x00917EB4 File Offset: 0x009160B4
		// (set) Token: 0x0601FADE RID: 129758 RVA: 0x00917EED File Offset: 0x009160ED
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003151 RID: 12625
		// (get) Token: 0x0601FADF RID: 129759 RVA: 0x00917F0E File Offset: 0x0091610E
		// (set) Token: 0x0601FAE0 RID: 129760 RVA: 0x00917F22 File Offset: 0x00916122
		public unsafe UKuroGameBudgetComponent KuroGameBudget
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroGameBudgetComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ToonShadowDecal_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ToonShadowDecal_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003152 RID: 12626
		// (get) Token: 0x0601FAE1 RID: 129761 RVA: 0x00917F37 File Offset: 0x00916137
		// (set) Token: 0x0601FAE2 RID: 129762 RVA: 0x00917F4B File Offset: 0x0091614B
		public unsafe UStaticMeshComponent Plane
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ToonShadowDecal_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ToonShadowDecal_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003153 RID: 12627
		// (get) Token: 0x0601FAE3 RID: 129763 RVA: 0x00917F60 File Offset: 0x00916160
		// (set) Token: 0x0601FAE4 RID: 129764 RVA: 0x00917F74 File Offset: 0x00916174
		public unsafe UMaterialInstanceDynamic DYMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ToonShadowDecal_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ToonShadowDecal_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003154 RID: 12628
		// (get) Token: 0x0601FAE5 RID: 129765 RVA: 0x00917F89 File Offset: 0x00916189
		// (set) Token: 0x0601FAE6 RID: 129766 RVA: 0x00917F9D File Offset: 0x0091619D
		public unsafe UTexture2D ShadowTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ToonShadowDecal_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ToonShadowDecal_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003155 RID: 12629
		// (get) Token: 0x0601FAE7 RID: 129767 RVA: 0x00917FB2 File Offset: 0x009161B2
		// (set) Token: 0x0601FAE8 RID: 129768 RVA: 0x00917FC2 File Offset: 0x009161C2
		public unsafe float ShadowIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003156 RID: 12630
		// (get) Token: 0x0601FAE9 RID: 129769 RVA: 0x00917FD3 File Offset: 0x009161D3
		// (set) Token: 0x0601FAEA RID: 129770 RVA: 0x00917FE3 File Offset: 0x009161E3
		public unsafe float InvShadow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003157 RID: 12631
		// (get) Token: 0x0601FAEB RID: 129771 RVA: 0x00917FF4 File Offset: 0x009161F4
		// (set) Token: 0x0601FAEC RID: 129772 RVA: 0x00918004 File Offset: 0x00916204
		public unsafe float MobileShadowIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003158 RID: 12632
		// (get) Token: 0x0601FAED RID: 129773 RVA: 0x00918015 File Offset: 0x00916215
		// (set) Token: 0x0601FAEE RID: 129774 RVA: 0x00918025 File Offset: 0x00916225
		public unsafe float WindIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003159 RID: 12633
		// (get) Token: 0x0601FAEF RID: 129775 RVA: 0x00918036 File Offset: 0x00916236
		// (set) Token: 0x0601FAF0 RID: 129776 RVA: 0x00918046 File Offset: 0x00916246
		public unsafe float WindSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700315A RID: 12634
		// (get) Token: 0x0601FAF1 RID: 129777 RVA: 0x00918057 File Offset: 0x00916257
		// (set) Token: 0x0601FAF2 RID: 129778 RVA: 0x00918067 File Offset: 0x00916267
		public unsafe float WindDir_X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700315B RID: 12635
		// (get) Token: 0x0601FAF3 RID: 129779 RVA: 0x00918078 File Offset: 0x00916278
		// (set) Token: 0x0601FAF4 RID: 129780 RVA: 0x00918088 File Offset: 0x00916288
		public unsafe float WindDir_Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x1700315C RID: 12636
		// (get) Token: 0x0601FAF5 RID: 129781 RVA: 0x00918099 File Offset: 0x00916299
		// (set) Token: 0x0601FAF6 RID: 129782 RVA: 0x009180A9 File Offset: 0x009162A9
		public unsafe float StrenghtAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x1700315D RID: 12637
		// (get) Token: 0x0601FAF7 RID: 129783 RVA: 0x009180BA File Offset: 0x009162BA
		// (set) Token: 0x0601FAF8 RID: 129784 RVA: 0x009180CA File Offset: 0x009162CA
		public unsafe float WindRandomSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x1700315E RID: 12638
		// (get) Token: 0x0601FAF9 RID: 129785 RVA: 0x009180DB File Offset: 0x009162DB
		// (set) Token: 0x0601FAFA RID: 129786 RVA: 0x009180EB File Offset: 0x009162EB
		public unsafe float WindRandomIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700315F RID: 12639
		// (get) Token: 0x0601FAFB RID: 129787 RVA: 0x009180FC File Offset: 0x009162FC
		// (set) Token: 0x0601FAFC RID: 129788 RVA: 0x0091810C File Offset: 0x0091630C
		public unsafe bool DEBUG
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003160 RID: 12640
		// (get) Token: 0x0601FAFD RID: 129789 RVA: 0x0091811D File Offset: 0x0091631D
		// (set) Token: 0x0601FAFE RID: 129790 RVA: 0x0091812D File Offset: 0x0091632D
		public unsafe bool PreMulColorMode
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003161 RID: 12641
		// (get) Token: 0x0601FAFF RID: 129791 RVA: 0x0091813E File Offset: 0x0091633E
		// (set) Token: 0x0601FB00 RID: 129792 RVA: 0x00918152 File Offset: 0x00916352
		public unsafe FLinearColor PreMulColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17003162 RID: 12642
		// (get) Token: 0x0601FB01 RID: 129793 RVA: 0x00918167 File Offset: 0x00916367
		// (set) Token: 0x0601FB02 RID: 129794 RVA: 0x00918177 File Offset: 0x00916377
		public unsafe float PreMulBaseColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17003163 RID: 12643
		// (get) Token: 0x0601FB03 RID: 129795 RVA: 0x00918188 File Offset: 0x00916388
		// (set) Token: 0x0601FB04 RID: 129796 RVA: 0x00918198 File Offset: 0x00916398
		public unsafe float UVPosition_X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17003164 RID: 12644
		// (get) Token: 0x0601FB05 RID: 129797 RVA: 0x009181A9 File Offset: 0x009163A9
		// (set) Token: 0x0601FB06 RID: 129798 RVA: 0x009181B9 File Offset: 0x009163B9
		public unsafe float UVPosition_Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17003165 RID: 12645
		// (get) Token: 0x0601FB07 RID: 129799 RVA: 0x009181CA File Offset: 0x009163CA
		// (set) Token: 0x0601FB08 RID: 129800 RVA: 0x009181DA File Offset: 0x009163DA
		public unsafe float UVScale_X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17003166 RID: 12646
		// (get) Token: 0x0601FB09 RID: 129801 RVA: 0x009181EB File Offset: 0x009163EB
		// (set) Token: 0x0601FB0A RID: 129802 RVA: 0x009181FB File Offset: 0x009163FB
		public unsafe float UVScale_Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17003167 RID: 12647
		// (get) Token: 0x0601FB0B RID: 129803 RVA: 0x0091820C File Offset: 0x0091640C
		// (set) Token: 0x0601FB0C RID: 129804 RVA: 0x0091821C File Offset: 0x0091641C
		public unsafe float Only_R
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17003168 RID: 12648
		// (get) Token: 0x0601FB0D RID: 129805 RVA: 0x0091822D File Offset: 0x0091642D
		// (set) Token: 0x0601FB0E RID: 129806 RVA: 0x0091823D File Offset: 0x0091643D
		public unsafe float hard
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17003169 RID: 12649
		// (get) Token: 0x0601FB0F RID: 129807 RVA: 0x0091824E File Offset: 0x0091644E
		// (set) Token: 0x0601FB10 RID: 129808 RVA: 0x0091825E File Offset: 0x0091645E
		public unsafe float Desaturation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x1700316A RID: 12650
		// (get) Token: 0x0601FB11 RID: 129809 RVA: 0x0091826F File Offset: 0x0091646F
		// (set) Token: 0x0601FB12 RID: 129810 RVA: 0x0091827F File Offset: 0x0091647F
		public unsafe float Opacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x1700316B RID: 12651
		// (get) Token: 0x0601FB13 RID: 129811 RVA: 0x00918290 File Offset: 0x00916490
		// (set) Token: 0x0601FB14 RID: 129812 RVA: 0x009182A0 File Offset: 0x009164A0
		public unsafe float ShadowUVPosition_X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x1700316C RID: 12652
		// (get) Token: 0x0601FB15 RID: 129813 RVA: 0x009182B1 File Offset: 0x009164B1
		// (set) Token: 0x0601FB16 RID: 129814 RVA: 0x009182C1 File Offset: 0x009164C1
		public unsafe float ShadowUVPosition_Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x1700316D RID: 12653
		// (get) Token: 0x0601FB17 RID: 129815 RVA: 0x009182D2 File Offset: 0x009164D2
		// (set) Token: 0x0601FB18 RID: 129816 RVA: 0x009182E2 File Offset: 0x009164E2
		public unsafe float ShadowUVScale_X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x1700316E RID: 12654
		// (get) Token: 0x0601FB19 RID: 129817 RVA: 0x009182F3 File Offset: 0x009164F3
		// (set) Token: 0x0601FB1A RID: 129818 RVA: 0x00918303 File Offset: 0x00916503
		public unsafe float ShadowUVScale_Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x1700316F RID: 12655
		// (get) Token: 0x0601FB1B RID: 129819 RVA: 0x00918314 File Offset: 0x00916514
		// (set) Token: 0x0601FB1C RID: 129820 RVA: 0x00918324 File Offset: 0x00916524
		public unsafe float hard_Shadow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17003170 RID: 12656
		// (get) Token: 0x0601FB1D RID: 129821 RVA: 0x00918335 File Offset: 0x00916535
		// (set) Token: 0x0601FB1E RID: 129822 RVA: 0x00918345 File Offset: 0x00916545
		public unsafe bool UseScreenUV
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_32) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_32) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003171 RID: 12657
		// (get) Token: 0x0601FB1F RID: 129823 RVA: 0x00918356 File Offset: 0x00916556
		// (set) Token: 0x0601FB20 RID: 129824 RVA: 0x00918366 File Offset: 0x00916566
		public unsafe float Rotator
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17003172 RID: 12658
		// (get) Token: 0x0601FB21 RID: 129825 RVA: 0x00918377 File Offset: 0x00916577
		// (set) Token: 0x0601FB22 RID: 129826 RVA: 0x0091838B File Offset: 0x0091658B
		public unsafe UMaterialInstanceDynamic DebugDYM
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ToonShadowDecal_C.__PropertyOffset_34);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ToonShadowDecal_C.__PropertyOffset_34, value);
			}
		}

		// Token: 0x17003173 RID: 12659
		// (get) Token: 0x0601FB23 RID: 129827 RVA: 0x009183A0 File Offset: 0x009165A0
		// (set) Token: 0x0601FB24 RID: 129828 RVA: 0x009183B0 File Offset: 0x009165B0
		public unsafe float ShadowOpacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ToonShadowDecal_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x0601FB25 RID: 129829 RVA: 0x009183C1 File Offset: 0x009165C1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TickFunction()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ToonShadowDecal_C.__TickFunction_NativeFunctionPtr, null);
		}

		// Token: 0x0601FB26 RID: 129830 RVA: 0x009183D5 File Offset: 0x009165D5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DEBUGPlane()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ToonShadowDecal_C.__DEBUGPlane_NativeFunctionPtr, null);
		}

		// Token: 0x0601FB27 RID: 129831 RVA: 0x009183E9 File Offset: 0x009165E9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ToonShadowDecal_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601FB28 RID: 129832 RVA: 0x009183FD File Offset: 0x009165FD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ToonShadowDecal_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FB29 RID: 129833 RVA: 0x00918412 File Offset: 0x00916612
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ToonShadowDecal_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601FB2A RID: 129834 RVA: 0x00918426 File Offset: 0x00916626
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ToonShadowDecal_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FB2B RID: 129835 RVA: 0x0091843C File Offset: 0x0091663C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_ToonShadowDecal_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ToonShadowDecal_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ToonShadowDecal_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ToonShadowDecal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ToonShadowDecal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FB2C RID: 129836 RVA: 0x00918484 File Offset: 0x00916684
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_ToonShadowDecal_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ToonShadowDecal_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ToonShadowDecal_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ToonShadowDecal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ToonShadowDecal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FB2D RID: 129837 RVA: 0x009184CC File Offset: 0x009166CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_ToonShadowDecal(int EntryPoint)
		{
			BP_ToonShadowDecal_C.__ExecuteUbergraph_BP_ToonShadowDecal_FunctionParams* ptr = stackalloc BP_ToonShadowDecal_C.__ExecuteUbergraph_BP_ToonShadowDecal_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_ToonShadowDecal_C.__ExecuteUbergraph_BP_ToonShadowDecal_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ToonShadowDecal_C.__ExecuteUbergraph_BP_ToonShadowDecal_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ToonShadowDecal_C.__ExecuteUbergraph_BP_ToonShadowDecal_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FB2E RID: 129838 RVA: 0x00918513 File Offset: 0x00916713
		protected BP_ToonShadowDecal_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FC15 RID: 64533
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_ToonShadowDecal.BP_ToonShadowDecal_C";

		// Token: 0x0400FC16 RID: 64534
		private static IntPtr _ClassPtr;

		// Token: 0x0400FC17 RID: 64535
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FC18 RID: 64536
		internal static int __PropertyOffset_0;

		// Token: 0x0400FC19 RID: 64537
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FC1A RID: 64538
		internal static int __PropertyOffset_1;

		// Token: 0x0400FC1B RID: 64539
		internal static int __PropertyOffset_2;

		// Token: 0x0400FC1C RID: 64540
		internal static int __PropertyOffset_3;

		// Token: 0x0400FC1D RID: 64541
		internal static int __PropertyOffset_4;

		// Token: 0x0400FC1E RID: 64542
		internal static int __PropertyOffset_5;

		// Token: 0x0400FC1F RID: 64543
		internal static int __PropertyOffset_6;

		// Token: 0x0400FC20 RID: 64544
		internal static int __PropertyOffset_7;

		// Token: 0x0400FC21 RID: 64545
		internal static int __PropertyOffset_8;

		// Token: 0x0400FC22 RID: 64546
		internal static int __PropertyOffset_9;

		// Token: 0x0400FC23 RID: 64547
		internal static int __PropertyOffset_10;

		// Token: 0x0400FC24 RID: 64548
		internal static int __PropertyOffset_11;

		// Token: 0x0400FC25 RID: 64549
		internal static int __PropertyOffset_12;

		// Token: 0x0400FC26 RID: 64550
		internal static int __PropertyOffset_13;

		// Token: 0x0400FC27 RID: 64551
		internal static int __PropertyOffset_14;

		// Token: 0x0400FC28 RID: 64552
		internal static int __PropertyOffset_15;

		// Token: 0x0400FC29 RID: 64553
		internal static int __PropertyOffset_16;

		// Token: 0x0400FC2A RID: 64554
		internal static int __PropertyOffset_17;

		// Token: 0x0400FC2B RID: 64555
		internal static int __PropertyOffset_18;

		// Token: 0x0400FC2C RID: 64556
		internal static int __PropertyOffset_19;

		// Token: 0x0400FC2D RID: 64557
		internal static int __PropertyOffset_20;

		// Token: 0x0400FC2E RID: 64558
		internal static int __PropertyOffset_21;

		// Token: 0x0400FC2F RID: 64559
		internal static int __PropertyOffset_22;

		// Token: 0x0400FC30 RID: 64560
		internal static int __PropertyOffset_23;

		// Token: 0x0400FC31 RID: 64561
		internal static int __PropertyOffset_24;

		// Token: 0x0400FC32 RID: 64562
		internal static int __PropertyOffset_25;

		// Token: 0x0400FC33 RID: 64563
		internal static int __PropertyOffset_26;

		// Token: 0x0400FC34 RID: 64564
		internal static int __PropertyOffset_27;

		// Token: 0x0400FC35 RID: 64565
		internal static int __PropertyOffset_28;

		// Token: 0x0400FC36 RID: 64566
		internal static int __PropertyOffset_29;

		// Token: 0x0400FC37 RID: 64567
		internal static int __PropertyOffset_30;

		// Token: 0x0400FC38 RID: 64568
		internal static int __PropertyOffset_31;

		// Token: 0x0400FC39 RID: 64569
		internal static int __PropertyOffset_32;

		// Token: 0x0400FC3A RID: 64570
		internal static int __PropertyOffset_33;

		// Token: 0x0400FC3B RID: 64571
		internal static int __PropertyOffset_34;

		// Token: 0x0400FC3C RID: 64572
		internal static int __PropertyOffset_35;

		// Token: 0x0400FC3D RID: 64573
		private static IntPtr __TickFunction_NativeFunctionPtr;

		// Token: 0x0400FC3E RID: 64574
		private static IntPtr __DEBUGPlane_NativeFunctionPtr;

		// Token: 0x0400FC3F RID: 64575
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FC40 RID: 64576
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FC41 RID: 64577
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FC42 RID: 64578
		private static IntPtr __ExecuteUbergraph_BP_ToonShadowDecal_NativeFunctionPtr;

		// Token: 0x02009915 RID: 39189
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F74 RID: 204660
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009916 RID: 39190
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_ToonShadowDecal_FunctionParams
		{
			// Token: 0x04031F75 RID: 204661
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
