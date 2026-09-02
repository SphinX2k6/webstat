using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A9E RID: 15006
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricConeLightShaftSeq.BP_VolumetricConeLightShaftSeq_C")]
	[UnrealStructLayout(1672, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1672)]
	public class BP_VolumetricConeLightShaftSeq_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601FBD3 RID: 130003 RVA: 0x00919373 File Offset: 0x00917573
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VolumetricConeLightShaftSeq_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricConeLightShaftSeq.BP_VolumetricConeLightShaftSeq_C");
			}
			return BP_VolumetricConeLightShaftSeq_C._ClassPtr;
		}

		// Token: 0x0601FBD4 RID: 130004 RVA: 0x00919398 File Offset: 0x00917598
		public BP_VolumetricConeLightShaftSeq_C() : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricConeLightShaftSeq_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601FBD5 RID: 130005 RVA: 0x009193C0 File Offset: 0x009175C0
		[NullableContext(1)]
		public BP_VolumetricConeLightShaftSeq_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricConeLightShaftSeq_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170031BD RID: 12733
		// (get) Token: 0x0601FBD6 RID: 130006 RVA: 0x009193F4 File Offset: 0x009175F4
		// (set) Token: 0x0601FBD7 RID: 130007 RVA: 0x0091942D File Offset: 0x0091762D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170031BE RID: 12734
		// (get) Token: 0x0601FBD8 RID: 130008 RVA: 0x0091944E File Offset: 0x0091764E
		// (set) Token: 0x0601FBD9 RID: 130009 RVA: 0x00919462 File Offset: 0x00917662
		public unsafe UBillboardComponent Billboard
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170031BF RID: 12735
		// (get) Token: 0x0601FBDA RID: 130010 RVA: 0x00919477 File Offset: 0x00917677
		// (set) Token: 0x0601FBDB RID: 130011 RVA: 0x0091948B File Offset: 0x0091768B
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170031C0 RID: 12736
		// (get) Token: 0x0601FBDC RID: 130012 RVA: 0x009194A0 File Offset: 0x009176A0
		// (set) Token: 0x0601FBDD RID: 130013 RVA: 0x009194B4 File Offset: 0x009176B4
		public unsafe UStaticMesh StaticMeshCone
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170031C1 RID: 12737
		// (get) Token: 0x0601FBDE RID: 130014 RVA: 0x009194C9 File Offset: 0x009176C9
		// (set) Token: 0x0601FBDF RID: 130015 RVA: 0x009194DD File Offset: 0x009176DD
		public unsafe UMaterialInstance MaterialInstance
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170031C2 RID: 12738
		// (get) Token: 0x0601FBE0 RID: 130016 RVA: 0x009194F2 File Offset: 0x009176F2
		// (set) Token: 0x0601FBE1 RID: 130017 RVA: 0x00919506 File Offset: 0x00917706
		public unsafe UMaterialInstance MaterialInstanceB
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170031C3 RID: 12739
		// (get) Token: 0x0601FBE2 RID: 130018 RVA: 0x0091951B File Offset: 0x0091771B
		// (set) Token: 0x0601FBE3 RID: 130019 RVA: 0x0091952F File Offset: 0x0091772F
		public unsafe FVector VolumetriConeScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170031C4 RID: 12740
		// (get) Token: 0x0601FBE4 RID: 130020 RVA: 0x00919544 File Offset: 0x00917744
		// (set) Token: 0x0601FBE5 RID: 130021 RVA: 0x00919554 File Offset: 0x00917754
		public unsafe bool EnableBottomColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x170031C5 RID: 12741
		// (get) Token: 0x0601FBE6 RID: 130022 RVA: 0x00919565 File Offset: 0x00917765
		// (set) Token: 0x0601FBE7 RID: 130023 RVA: 0x00919575 File Offset: 0x00917775
		public unsafe bool IsWholeDay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x170031C6 RID: 12742
		// (get) Token: 0x0601FBE8 RID: 130024 RVA: 0x00919586 File Offset: 0x00917786
		// (set) Token: 0x0601FBE9 RID: 130025 RVA: 0x00919596 File Offset: 0x00917796
		public unsafe bool EnableFlickent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x170031C7 RID: 12743
		// (get) Token: 0x0601FBEA RID: 130026 RVA: 0x009195A7 File Offset: 0x009177A7
		// (set) Token: 0x0601FBEB RID: 130027 RVA: 0x009195B7 File Offset: 0x009177B7
		public unsafe float ConeSin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170031C8 RID: 12744
		// (get) Token: 0x0601FBEC RID: 130028 RVA: 0x009195C8 File Offset: 0x009177C8
		// (set) Token: 0x0601FBED RID: 130029 RVA: 0x009195D8 File Offset: 0x009177D8
		public unsafe float RadFallOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170031C9 RID: 12745
		// (get) Token: 0x0601FBEE RID: 130030 RVA: 0x009195E9 File Offset: 0x009177E9
		// (set) Token: 0x0601FBEF RID: 130031 RVA: 0x009195F9 File Offset: 0x009177F9
		public unsafe float TopClip
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170031CA RID: 12746
		// (get) Token: 0x0601FBF0 RID: 130032 RVA: 0x0091960A File Offset: 0x0091780A
		// (set) Token: 0x0601FBF1 RID: 130033 RVA: 0x0091961A File Offset: 0x0091781A
		public unsafe float TopColorLerp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170031CB RID: 12747
		// (get) Token: 0x0601FBF2 RID: 130034 RVA: 0x0091962B File Offset: 0x0091782B
		// (set) Token: 0x0601FBF3 RID: 130035 RVA: 0x0091963F File Offset: 0x0091783F
		public unsafe FLinearColor TopColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170031CC RID: 12748
		// (get) Token: 0x0601FBF4 RID: 130036 RVA: 0x00919654 File Offset: 0x00917854
		// (set) Token: 0x0601FBF5 RID: 130037 RVA: 0x00919668 File Offset: 0x00917868
		public unsafe FLinearColor BottomColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170031CD RID: 12749
		// (get) Token: 0x0601FBF6 RID: 130038 RVA: 0x0091967D File Offset: 0x0091787D
		// (set) Token: 0x0601FBF7 RID: 130039 RVA: 0x0091968D File Offset: 0x0091788D
		public unsafe float SkyLightInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170031CE RID: 12750
		// (get) Token: 0x0601FBF8 RID: 130040 RVA: 0x0091969E File Offset: 0x0091789E
		// (set) Token: 0x0601FBF9 RID: 130041 RVA: 0x009196AE File Offset: 0x009178AE
		public unsafe float SkyLightOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170031CF RID: 12751
		// (get) Token: 0x0601FBFA RID: 130042 RVA: 0x009196BF File Offset: 0x009178BF
		// (set) Token: 0x0601FBFB RID: 130043 RVA: 0x009196CF File Offset: 0x009178CF
		public unsafe float BrightLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170031D0 RID: 12752
		// (get) Token: 0x0601FBFC RID: 130044 RVA: 0x009196E0 File Offset: 0x009178E0
		// (set) Token: 0x0601FBFD RID: 130045 RVA: 0x009196F0 File Offset: 0x009178F0
		public unsafe float FlickerTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170031D1 RID: 12753
		// (get) Token: 0x0601FBFE RID: 130046 RVA: 0x00919701 File Offset: 0x00917901
		// (set) Token: 0x0601FBFF RID: 130047 RVA: 0x00919711 File Offset: 0x00917911
		public unsafe float DepthFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170031D2 RID: 12754
		// (get) Token: 0x0601FC00 RID: 130048 RVA: 0x00919722 File Offset: 0x00917922
		// (set) Token: 0x0601FC01 RID: 130049 RVA: 0x00919732 File Offset: 0x00917932
		public unsafe float ViewTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x170031D3 RID: 12755
		// (get) Token: 0x0601FC02 RID: 130050 RVA: 0x00919743 File Offset: 0x00917943
		// (set) Token: 0x0601FC03 RID: 130051 RVA: 0x00919757 File Offset: 0x00917957
		public unsafe FVector LightShaftScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x170031D4 RID: 12756
		// (get) Token: 0x0601FC04 RID: 130052 RVA: 0x0091976C File Offset: 0x0091796C
		// (set) Token: 0x0601FC05 RID: 130053 RVA: 0x00919780 File Offset: 0x00917980
		public unsafe UStaticMesh LightShaftStaticMeshCone
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x170031D5 RID: 12757
		// (get) Token: 0x0601FC06 RID: 130054 RVA: 0x00919795 File Offset: 0x00917995
		// (set) Token: 0x0601FC07 RID: 130055 RVA: 0x009197A9 File Offset: 0x009179A9
		public unsafe UMaterialInstance LightShaftCone
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x170031D6 RID: 12758
		// (get) Token: 0x0601FC08 RID: 130056 RVA: 0x009197BE File Offset: 0x009179BE
		// (set) Token: 0x0601FC09 RID: 130057 RVA: 0x009197D2 File Offset: 0x009179D2
		public unsafe UTexture2D Mask
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x170031D7 RID: 12759
		// (get) Token: 0x0601FC0A RID: 130058 RVA: 0x009197E7 File Offset: 0x009179E7
		// (set) Token: 0x0601FC0B RID: 130059 RVA: 0x009197FB File Offset: 0x009179FB
		public unsafe FLinearColor FallOff_ColorTint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x170031D8 RID: 12760
		// (get) Token: 0x0601FC0C RID: 130060 RVA: 0x00919810 File Offset: 0x00917A10
		// (set) Token: 0x0601FC0D RID: 130061 RVA: 0x00919820 File Offset: 0x00917A20
		public unsafe float FallOff_DepthFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x170031D9 RID: 12761
		// (get) Token: 0x0601FC0E RID: 130062 RVA: 0x00919831 File Offset: 0x00917A31
		// (set) Token: 0x0601FC0F RID: 130063 RVA: 0x00919841 File Offset: 0x00917A41
		public unsafe float ScreenFadeFrom
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x170031DA RID: 12762
		// (get) Token: 0x0601FC10 RID: 130064 RVA: 0x00919852 File Offset: 0x00917A52
		// (set) Token: 0x0601FC11 RID: 130065 RVA: 0x00919862 File Offset: 0x00917A62
		public unsafe float Opacity_CenterPower
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x170031DB RID: 12763
		// (get) Token: 0x0601FC12 RID: 130066 RVA: 0x00919873 File Offset: 0x00917A73
		// (set) Token: 0x0601FC13 RID: 130067 RVA: 0x00919883 File Offset: 0x00917A83
		public unsafe float ScreenFadeDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x170031DC RID: 12764
		// (get) Token: 0x0601FC14 RID: 130068 RVA: 0x00919894 File Offset: 0x00917A94
		// (set) Token: 0x0601FC15 RID: 130069 RVA: 0x009198A4 File Offset: 0x00917AA4
		public unsafe float ShaftTopClip
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x170031DD RID: 12765
		// (get) Token: 0x0601FC16 RID: 130070 RVA: 0x009198B5 File Offset: 0x00917AB5
		// (set) Token: 0x0601FC17 RID: 130071 RVA: 0x009198C9 File Offset: 0x00917AC9
		public unsafe FLinearColor UVScaleAndAdd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x170031DE RID: 12766
		// (get) Token: 0x0601FC18 RID: 130072 RVA: 0x009198DE File Offset: 0x00917ADE
		// (set) Token: 0x0601FC19 RID: 130073 RVA: 0x009198F2 File Offset: 0x00917AF2
		public unsafe UStaticMesh LightMaskStaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_33);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x170031DF RID: 12767
		// (get) Token: 0x0601FC1A RID: 130074 RVA: 0x00919907 File Offset: 0x00917B07
		// (set) Token: 0x0601FC1B RID: 130075 RVA: 0x00919917 File Offset: 0x00917B17
		public unsafe float LightMaskZaxis
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x170031E0 RID: 12768
		// (get) Token: 0x0601FC1C RID: 130076 RVA: 0x00919928 File Offset: 0x00917B28
		// (set) Token: 0x0601FC1D RID: 130077 RVA: 0x0091993C File Offset: 0x00917B3C
		public unsafe UMaterialInstance LightMaskMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_35);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_35, value);
			}
		}

		// Token: 0x170031E1 RID: 12769
		// (get) Token: 0x0601FC1E RID: 130078 RVA: 0x00919951 File Offset: 0x00917B51
		// (set) Token: 0x0601FC1F RID: 130079 RVA: 0x00919965 File Offset: 0x00917B65
		public unsafe FVector LightMaskScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x170031E2 RID: 12770
		// (get) Token: 0x0601FC20 RID: 130080 RVA: 0x0091997A File Offset: 0x00917B7A
		// (set) Token: 0x0601FC21 RID: 130081 RVA: 0x0091998E File Offset: 0x00917B8E
		public unsafe FLinearColor LightMaskColorTint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x170031E3 RID: 12771
		// (get) Token: 0x0601FC22 RID: 130082 RVA: 0x009199A3 File Offset: 0x00917BA3
		// (set) Token: 0x0601FC23 RID: 130083 RVA: 0x009199B7 File Offset: 0x00917BB7
		public unsafe UTexture2D LightMaskTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_38);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_38, value);
			}
		}

		// Token: 0x170031E4 RID: 12772
		// (get) Token: 0x0601FC24 RID: 130084 RVA: 0x009199CC File Offset: 0x00917BCC
		// (set) Token: 0x0601FC25 RID: 130085 RVA: 0x009199DC File Offset: 0x00917BDC
		public unsafe float ColorIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x170031E5 RID: 12773
		// (get) Token: 0x0601FC26 RID: 130086 RVA: 0x009199ED File Offset: 0x00917BED
		// (set) Token: 0x0601FC27 RID: 130087 RVA: 0x009199FD File Offset: 0x00917BFD
		public unsafe float Opacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x170031E6 RID: 12774
		// (get) Token: 0x0601FC28 RID: 130088 RVA: 0x00919A0E File Offset: 0x00917C0E
		// (set) Token: 0x0601FC29 RID: 130089 RVA: 0x00919A1E File Offset: 0x00917C1E
		public unsafe float FadeDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x170031E7 RID: 12775
		// (get) Token: 0x0601FC2A RID: 130090 RVA: 0x00919A2F File Offset: 0x00917C2F
		// (set) Token: 0x0601FC2B RID: 130091 RVA: 0x00919A3F File Offset: 0x00917C3F
		public unsafe float FlankInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x170031E8 RID: 12776
		// (get) Token: 0x0601FC2C RID: 130092 RVA: 0x00919A50 File Offset: 0x00917C50
		// (set) Token: 0x0601FC2D RID: 130093 RVA: 0x00919A60 File Offset: 0x00917C60
		public unsafe float Power
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x170031E9 RID: 12777
		// (get) Token: 0x0601FC2E RID: 130094 RVA: 0x00919A71 File Offset: 0x00917C71
		// (set) Token: 0x0601FC2F RID: 130095 RVA: 0x00919A81 File Offset: 0x00917C81
		public unsafe float RightSideInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x170031EA RID: 12778
		// (get) Token: 0x0601FC30 RID: 130096 RVA: 0x00919A92 File Offset: 0x00917C92
		// (set) Token: 0x0601FC31 RID: 130097 RVA: 0x00919AA6 File Offset: 0x00917CA6
		public unsafe UMaterialInstanceDynamic DynamicMaterialVolumetricCone
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_45);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_45, value);
			}
		}

		// Token: 0x170031EB RID: 12779
		// (get) Token: 0x0601FC32 RID: 130098 RVA: 0x00919ABB File Offset: 0x00917CBB
		// (set) Token: 0x0601FC33 RID: 130099 RVA: 0x00919ACF File Offset: 0x00917CCF
		public unsafe UMaterialInstanceDynamic LightShaftConeDynamicMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_46);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_46, value);
			}
		}

		// Token: 0x170031EC RID: 12780
		// (get) Token: 0x0601FC34 RID: 130100 RVA: 0x00919AE4 File Offset: 0x00917CE4
		// (set) Token: 0x0601FC35 RID: 130101 RVA: 0x00919AF8 File Offset: 0x00917CF8
		public unsafe UMaterialInstanceDynamic LightMaskDynamicMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_47);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_47, value);
			}
		}

		// Token: 0x170031ED RID: 12781
		// (get) Token: 0x0601FC36 RID: 130102 RVA: 0x00919B0D File Offset: 0x00917D0D
		// (set) Token: 0x0601FC37 RID: 130103 RVA: 0x00919B21 File Offset: 0x00917D21
		public unsafe UStaticMeshComponent LightShaftComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_48);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_48, value);
			}
		}

		// Token: 0x170031EE RID: 12782
		// (get) Token: 0x0601FC38 RID: 130104 RVA: 0x00919B36 File Offset: 0x00917D36
		// (set) Token: 0x0601FC39 RID: 130105 RVA: 0x00919B46 File Offset: 0x00917D46
		public unsafe float HeighFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_49);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_49) = value;
			}
		}

		// Token: 0x170031EF RID: 12783
		// (get) Token: 0x0601FC3A RID: 130106 RVA: 0x00919B57 File Offset: 0x00917D57
		// (set) Token: 0x0601FC3B RID: 130107 RVA: 0x00919B67 File Offset: 0x00917D67
		public unsafe float HeighFadeHard
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_50);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaftSeq_C.__PropertyOffset_50) = value;
			}
		}

		// Token: 0x0601FC3C RID: 130108 RVA: 0x00919B78 File Offset: 0x00917D78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaftSeq_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601FC3D RID: 130109 RVA: 0x00919B8C File Offset: 0x00917D8C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaftSeq_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FC3E RID: 130110 RVA: 0x00919BA1 File Offset: 0x00917DA1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaftSeq_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601FC3F RID: 130111 RVA: 0x00919BB5 File Offset: 0x00917DB5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaftSeq_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FC40 RID: 130112 RVA: 0x00919BCC File Offset: 0x00917DCC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_VolumetricConeLightShaftSeq_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaftSeq_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricConeLightShaftSeq_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaftSeq_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaftSeq_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FC41 RID: 130113 RVA: 0x00919C14 File Offset: 0x00917E14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_VolumetricConeLightShaftSeq_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaftSeq_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricConeLightShaftSeq_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaftSeq_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaftSeq_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FC42 RID: 130114 RVA: 0x00919C5C File Offset: 0x00917E5C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_VolumetricConeLightShaftSeq_C.__EditorTick_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaftSeq_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricConeLightShaftSeq_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaftSeq_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaftSeq_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FC43 RID: 130115 RVA: 0x00919CA4 File Offset: 0x00917EA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_VolumetricConeLightShaftSeq_C.__EditorTick_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaftSeq_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricConeLightShaftSeq_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaftSeq_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaftSeq_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FC44 RID: 130116 RVA: 0x00919CEC File Offset: 0x00917EEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_VolumetricConeLightShaftSeq(int EntryPoint)
		{
			BP_VolumetricConeLightShaftSeq_C.__ExecuteUbergraph_BP_VolumetricConeLightShaftSeq_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaftSeq_C.__ExecuteUbergraph_BP_VolumetricConeLightShaftSeq_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_VolumetricConeLightShaftSeq_C.__ExecuteUbergraph_BP_VolumetricConeLightShaftSeq_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaftSeq_C.__ExecuteUbergraph_BP_VolumetricConeLightShaftSeq_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaftSeq_C.__ExecuteUbergraph_BP_VolumetricConeLightShaftSeq_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FC45 RID: 130117 RVA: 0x00919D33 File Offset: 0x00917F33
		protected BP_VolumetricConeLightShaftSeq_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FC9D RID: 64669
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricConeLightShaftSeq.BP_VolumetricConeLightShaftSeq_C";

		// Token: 0x0400FC9E RID: 64670
		private static IntPtr _ClassPtr;

		// Token: 0x0400FC9F RID: 64671
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FCA0 RID: 64672
		internal static int __PropertyOffset_0;

		// Token: 0x0400FCA1 RID: 64673
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FCA2 RID: 64674
		internal static int __PropertyOffset_1;

		// Token: 0x0400FCA3 RID: 64675
		internal static int __PropertyOffset_2;

		// Token: 0x0400FCA4 RID: 64676
		internal static int __PropertyOffset_3;

		// Token: 0x0400FCA5 RID: 64677
		internal static int __PropertyOffset_4;

		// Token: 0x0400FCA6 RID: 64678
		internal static int __PropertyOffset_5;

		// Token: 0x0400FCA7 RID: 64679
		internal static int __PropertyOffset_6;

		// Token: 0x0400FCA8 RID: 64680
		internal static int __PropertyOffset_7;

		// Token: 0x0400FCA9 RID: 64681
		internal static int __PropertyOffset_8;

		// Token: 0x0400FCAA RID: 64682
		internal static int __PropertyOffset_9;

		// Token: 0x0400FCAB RID: 64683
		internal static int __PropertyOffset_10;

		// Token: 0x0400FCAC RID: 64684
		internal static int __PropertyOffset_11;

		// Token: 0x0400FCAD RID: 64685
		internal static int __PropertyOffset_12;

		// Token: 0x0400FCAE RID: 64686
		internal static int __PropertyOffset_13;

		// Token: 0x0400FCAF RID: 64687
		internal static int __PropertyOffset_14;

		// Token: 0x0400FCB0 RID: 64688
		internal static int __PropertyOffset_15;

		// Token: 0x0400FCB1 RID: 64689
		internal static int __PropertyOffset_16;

		// Token: 0x0400FCB2 RID: 64690
		internal static int __PropertyOffset_17;

		// Token: 0x0400FCB3 RID: 64691
		internal static int __PropertyOffset_18;

		// Token: 0x0400FCB4 RID: 64692
		internal static int __PropertyOffset_19;

		// Token: 0x0400FCB5 RID: 64693
		internal static int __PropertyOffset_20;

		// Token: 0x0400FCB6 RID: 64694
		internal static int __PropertyOffset_21;

		// Token: 0x0400FCB7 RID: 64695
		internal static int __PropertyOffset_22;

		// Token: 0x0400FCB8 RID: 64696
		internal static int __PropertyOffset_23;

		// Token: 0x0400FCB9 RID: 64697
		internal static int __PropertyOffset_24;

		// Token: 0x0400FCBA RID: 64698
		internal static int __PropertyOffset_25;

		// Token: 0x0400FCBB RID: 64699
		internal static int __PropertyOffset_26;

		// Token: 0x0400FCBC RID: 64700
		internal static int __PropertyOffset_27;

		// Token: 0x0400FCBD RID: 64701
		internal static int __PropertyOffset_28;

		// Token: 0x0400FCBE RID: 64702
		internal static int __PropertyOffset_29;

		// Token: 0x0400FCBF RID: 64703
		internal static int __PropertyOffset_30;

		// Token: 0x0400FCC0 RID: 64704
		internal static int __PropertyOffset_31;

		// Token: 0x0400FCC1 RID: 64705
		internal static int __PropertyOffset_32;

		// Token: 0x0400FCC2 RID: 64706
		internal static int __PropertyOffset_33;

		// Token: 0x0400FCC3 RID: 64707
		internal static int __PropertyOffset_34;

		// Token: 0x0400FCC4 RID: 64708
		internal static int __PropertyOffset_35;

		// Token: 0x0400FCC5 RID: 64709
		internal static int __PropertyOffset_36;

		// Token: 0x0400FCC6 RID: 64710
		internal static int __PropertyOffset_37;

		// Token: 0x0400FCC7 RID: 64711
		internal static int __PropertyOffset_38;

		// Token: 0x0400FCC8 RID: 64712
		internal static int __PropertyOffset_39;

		// Token: 0x0400FCC9 RID: 64713
		internal static int __PropertyOffset_40;

		// Token: 0x0400FCCA RID: 64714
		internal static int __PropertyOffset_41;

		// Token: 0x0400FCCB RID: 64715
		internal static int __PropertyOffset_42;

		// Token: 0x0400FCCC RID: 64716
		internal static int __PropertyOffset_43;

		// Token: 0x0400FCCD RID: 64717
		internal static int __PropertyOffset_44;

		// Token: 0x0400FCCE RID: 64718
		internal static int __PropertyOffset_45;

		// Token: 0x0400FCCF RID: 64719
		internal static int __PropertyOffset_46;

		// Token: 0x0400FCD0 RID: 64720
		internal static int __PropertyOffset_47;

		// Token: 0x0400FCD1 RID: 64721
		internal static int __PropertyOffset_48;

		// Token: 0x0400FCD2 RID: 64722
		internal static int __PropertyOffset_49;

		// Token: 0x0400FCD3 RID: 64723
		internal static int __PropertyOffset_50;

		// Token: 0x0400FCD4 RID: 64724
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FCD5 RID: 64725
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FCD6 RID: 64726
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FCD7 RID: 64727
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400FCD8 RID: 64728
		private static IntPtr __ExecuteUbergraph_BP_VolumetricConeLightShaftSeq_NativeFunctionPtr;

		// Token: 0x0200991B RID: 39195
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F7A RID: 204666
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200991C RID: 39196
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031F7B RID: 204667
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200991D RID: 39197
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __ExecuteUbergraph_BP_VolumetricConeLightShaftSeq_FunctionParams
		{
			// Token: 0x04031F7C RID: 204668
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
