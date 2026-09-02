using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.BP
{
	// Token: 0x02003CC7 RID: 15559
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_SingleCloud.BP_SingleCloud_C")]
	[UnrealStructLayout(1608, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1608)]
	public class BP_SingleCloud_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024FFD RID: 151549 RVA: 0x009AE338 File Offset: 0x009AC538
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SingleCloud_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_SingleCloud.BP_SingleCloud_C");
			}
			return BP_SingleCloud_C._ClassPtr;
		}

		// Token: 0x06024FFE RID: 151550 RVA: 0x009AE35C File Offset: 0x009AC55C
		public BP_SingleCloud_C() : this(BuiltinUtils.AllocNativeUObject(BP_SingleCloud_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024FFF RID: 151551 RVA: 0x009AE384 File Offset: 0x009AC584
		[NullableContext(1)]
		public BP_SingleCloud_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SingleCloud_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004EF7 RID: 20215
		// (get) Token: 0x06025000 RID: 151552 RVA: 0x009AE3B8 File Offset: 0x009AC5B8
		// (set) Token: 0x06025001 RID: 151553 RVA: 0x009AE3F1 File Offset: 0x009AC5F1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004EF8 RID: 20216
		// (get) Token: 0x06025002 RID: 151554 RVA: 0x009AE412 File Offset: 0x009AC612
		// (set) Token: 0x06025003 RID: 151555 RVA: 0x009AE426 File Offset: 0x009AC626
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SingleCloud_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SingleCloud_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004EF9 RID: 20217
		// (get) Token: 0x06025004 RID: 151556 RVA: 0x009AE43B File Offset: 0x009AC63B
		// (set) Token: 0x06025005 RID: 151557 RVA: 0x009AE44F File Offset: 0x009AC64F
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SingleCloud_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SingleCloud_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004EFA RID: 20218
		// (get) Token: 0x06025006 RID: 151558 RVA: 0x009AE464 File Offset: 0x009AC664
		// (set) Token: 0x06025007 RID: 151559 RVA: 0x009AE478 File Offset: 0x009AC678
		public unsafe UTexture2D CloudMask
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SingleCloud_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SingleCloud_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004EFB RID: 20219
		// (get) Token: 0x06025008 RID: 151560 RVA: 0x009AE48D File Offset: 0x009AC68D
		// (set) Token: 0x06025009 RID: 151561 RVA: 0x009AE49D File Offset: 0x009AC69D
		public unsafe float CloudHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004EFC RID: 20220
		// (get) Token: 0x0602500A RID: 151562 RVA: 0x009AE4AE File Offset: 0x009AC6AE
		// (set) Token: 0x0602500B RID: 151563 RVA: 0x009AE4C2 File Offset: 0x009AC6C2
		public unsafe UMaterialInstanceConstant MaterialNoRotate_CustomLighting
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceConstant>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SingleCloud_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SingleCloud_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004EFD RID: 20221
		// (get) Token: 0x0602500C RID: 151564 RVA: 0x009AE4D7 File Offset: 0x009AC6D7
		// (set) Token: 0x0602500D RID: 151565 RVA: 0x009AE4EB File Offset: 0x009AC6EB
		public unsafe UMaterialInstanceConstant MaterialNoRotate
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceConstant>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SingleCloud_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SingleCloud_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004EFE RID: 20222
		// (get) Token: 0x0602500E RID: 151566 RVA: 0x009AE500 File Offset: 0x009AC700
		// (set) Token: 0x0602500F RID: 151567 RVA: 0x009AE510 File Offset: 0x009AC710
		public unsafe bool bTowardCamera
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004EFF RID: 20223
		// (get) Token: 0x06025010 RID: 151568 RVA: 0x009AE521 File Offset: 0x009AC721
		// (set) Token: 0x06025011 RID: 151569 RVA: 0x009AE531 File Offset: 0x009AC731
		public unsafe float FadeWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004F00 RID: 20224
		// (get) Token: 0x06025012 RID: 151570 RVA: 0x009AE542 File Offset: 0x009AC742
		// (set) Token: 0x06025013 RID: 151571 RVA: 0x009AE552 File Offset: 0x009AC752
		public unsafe float MinDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004F01 RID: 20225
		// (get) Token: 0x06025014 RID: 151572 RVA: 0x009AE563 File Offset: 0x009AC763
		// (set) Token: 0x06025015 RID: 151573 RVA: 0x009AE573 File Offset: 0x009AC773
		public unsafe float MaxDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17004F02 RID: 20226
		// (get) Token: 0x06025016 RID: 151574 RVA: 0x009AE584 File Offset: 0x009AC784
		// (set) Token: 0x06025017 RID: 151575 RVA: 0x009AE598 File Offset: 0x009AC798
		public unsafe UStaticMesh CustomMesh_Y_Aix
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SingleCloud_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SingleCloud_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17004F03 RID: 20227
		// (get) Token: 0x06025018 RID: 151576 RVA: 0x009AE5AD File Offset: 0x009AC7AD
		// (set) Token: 0x06025019 RID: 151577 RVA: 0x009AE5BD File Offset: 0x009AC7BD
		public unsafe float NoiseStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17004F04 RID: 20228
		// (get) Token: 0x0602501A RID: 151578 RVA: 0x009AE5CE File Offset: 0x009AC7CE
		// (set) Token: 0x0602501B RID: 151579 RVA: 0x009AE5DE File Offset: 0x009AC7DE
		public unsafe float NoiseTilling
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17004F05 RID: 20229
		// (get) Token: 0x0602501C RID: 151580 RVA: 0x009AE5EF File Offset: 0x009AC7EF
		// (set) Token: 0x0602501D RID: 151581 RVA: 0x009AE5FF File Offset: 0x009AC7FF
		public unsafe float NoiseSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004F06 RID: 20230
		// (get) Token: 0x0602501E RID: 151582 RVA: 0x009AE610 File Offset: 0x009AC810
		// (set) Token: 0x0602501F RID: 151583 RVA: 0x009AE620 File Offset: 0x009AC820
		public unsafe float Opacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17004F07 RID: 20231
		// (get) Token: 0x06025020 RID: 151584 RVA: 0x009AE631 File Offset: 0x009AC831
		// (set) Token: 0x06025021 RID: 151585 RVA: 0x009AE645 File Offset: 0x009AC845
		public unsafe UMaterialInstanceConstant MaterialNoRotateFog_CustomLighting
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceConstant>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SingleCloud_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SingleCloud_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17004F08 RID: 20232
		// (get) Token: 0x06025022 RID: 151586 RVA: 0x009AE65A File Offset: 0x009AC85A
		// (set) Token: 0x06025023 RID: 151587 RVA: 0x009AE66E File Offset: 0x009AC86E
		public unsafe UMaterialInstanceConstant MaterialNoRotateFog
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceConstant>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SingleCloud_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SingleCloud_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17004F09 RID: 20233
		// (get) Token: 0x06025024 RID: 151588 RVA: 0x009AE683 File Offset: 0x009AC883
		// (set) Token: 0x06025025 RID: 151589 RVA: 0x009AE693 File Offset: 0x009AC893
		public unsafe bool bWithFog
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004F0A RID: 20234
		// (get) Token: 0x06025026 RID: 151590 RVA: 0x009AE6A4 File Offset: 0x009AC8A4
		// (set) Token: 0x06025027 RID: 151591 RVA: 0x009AE6B4 File Offset: 0x009AC8B4
		public unsafe bool bInverseFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004F0B RID: 20235
		// (get) Token: 0x06025028 RID: 151592 RVA: 0x009AE6C5 File Offset: 0x009AC8C5
		// (set) Token: 0x06025029 RID: 151593 RVA: 0x009AE6D5 File Offset: 0x009AC8D5
		public unsafe bool bEditor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004F0C RID: 20236
		// (get) Token: 0x0602502A RID: 151594 RVA: 0x009AE6E6 File Offset: 0x009AC8E6
		// (set) Token: 0x0602502B RID: 151595 RVA: 0x009AE6F6 File Offset: 0x009AC8F6
		public unsafe bool bTowardCameraPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004F0D RID: 20237
		// (get) Token: 0x0602502C RID: 151596 RVA: 0x009AE707 File Offset: 0x009AC907
		// (set) Token: 0x0602502D RID: 151597 RVA: 0x009AE71B File Offset: 0x009AC91B
		public unsafe FVector boundCenter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17004F0E RID: 20238
		// (get) Token: 0x0602502E RID: 151598 RVA: 0x009AE730 File Offset: 0x009AC930
		// (set) Token: 0x0602502F RID: 151599 RVA: 0x009AE744 File Offset: 0x009AC944
		public unsafe FVectorDouble CameraPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17004F0F RID: 20239
		// (get) Token: 0x06025030 RID: 151600 RVA: 0x009AE759 File Offset: 0x009AC959
		// (set) Token: 0x06025031 RID: 151601 RVA: 0x009AE76D File Offset: 0x009AC96D
		public unsafe FRotator CameraRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17004F10 RID: 20240
		// (get) Token: 0x06025032 RID: 151602 RVA: 0x009AE782 File Offset: 0x009AC982
		// (set) Token: 0x06025033 RID: 151603 RVA: 0x009AE792 File Offset: 0x009AC992
		public unsafe double DistanceFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17004F11 RID: 20241
		// (get) Token: 0x06025034 RID: 151604 RVA: 0x009AE7A3 File Offset: 0x009AC9A3
		// (set) Token: 0x06025035 RID: 151605 RVA: 0x009AE7B7 File Offset: 0x009AC9B7
		public unsafe FRotator CloudRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17004F12 RID: 20242
		// (get) Token: 0x06025036 RID: 151606 RVA: 0x009AE7CC File Offset: 0x009AC9CC
		// (set) Token: 0x06025037 RID: 151607 RVA: 0x009AE7E0 File Offset: 0x009AC9E0
		public unsafe FVectorDouble ToBoundDir
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17004F13 RID: 20243
		// (get) Token: 0x06025038 RID: 151608 RVA: 0x009AE7F5 File Offset: 0x009AC9F5
		// (set) Token: 0x06025039 RID: 151609 RVA: 0x009AE805 File Offset: 0x009ACA05
		public unsafe bool bCustomLighting
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004F14 RID: 20244
		// (get) Token: 0x0602503A RID: 151610 RVA: 0x009AE816 File Offset: 0x009ACA16
		// (set) Token: 0x0602503B RID: 151611 RVA: 0x009AE82A File Offset: 0x009ACA2A
		public unsafe FLinearColor BaseColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17004F15 RID: 20245
		// (get) Token: 0x0602503C RID: 151612 RVA: 0x009AE83F File Offset: 0x009ACA3F
		// (set) Token: 0x0602503D RID: 151613 RVA: 0x009AE853 File Offset: 0x009ACA53
		public unsafe FLinearColor DarkColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17004F16 RID: 20246
		// (get) Token: 0x0602503E RID: 151614 RVA: 0x009AE868 File Offset: 0x009ACA68
		// (set) Token: 0x0602503F RID: 151615 RVA: 0x009AE87C File Offset: 0x009ACA7C
		public unsafe FLinearColor EmissiveColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17004F17 RID: 20247
		// (get) Token: 0x06025040 RID: 151616 RVA: 0x009AE891 File Offset: 0x009ACA91
		// (set) Token: 0x06025041 RID: 151617 RVA: 0x009AE8A5 File Offset: 0x009ACAA5
		public unsafe FLinearColor LightColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17004F18 RID: 20248
		// (get) Token: 0x06025042 RID: 151618 RVA: 0x009AE8BA File Offset: 0x009ACABA
		// (set) Token: 0x06025043 RID: 151619 RVA: 0x009AE8CA File Offset: 0x009ACACA
		public unsafe float AtmoLightScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17004F19 RID: 20249
		// (get) Token: 0x06025044 RID: 151620 RVA: 0x009AE8DB File Offset: 0x009ACADB
		// (set) Token: 0x06025045 RID: 151621 RVA: 0x009AE8EB File Offset: 0x009ACAEB
		public unsafe float CloudUseFogFarColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17004F1A RID: 20250
		// (get) Token: 0x06025046 RID: 151622 RVA: 0x009AE8FC File Offset: 0x009ACAFC
		// (set) Token: 0x06025047 RID: 151623 RVA: 0x009AE90C File Offset: 0x009ACB0C
		public unsafe float Exp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x06025048 RID: 151624 RVA: 0x009AE91D File Offset: 0x009ACB1D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateCloudRotation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SingleCloud_C.__UpdateCloudRotation_NativeFunctionPtr, null);
		}

		// Token: 0x06025049 RID: 151625 RVA: 0x009AE931 File Offset: 0x009ACB31
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateDistanceFade()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SingleCloud_C.__UpdateDistanceFade_NativeFunctionPtr, null);
		}

		// Token: 0x0602504A RID: 151626 RVA: 0x009AE945 File Offset: 0x009ACB45
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateCameraPosition()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SingleCloud_C.__UpdateCameraPosition_NativeFunctionPtr, null);
		}

		// Token: 0x0602504B RID: 151627 RVA: 0x009AE95C File Offset: 0x009ACB5C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateMaterialParams(UMaterialInstanceDynamic MID)
		{
			BP_SingleCloud_C.__UpdateMaterialParams_FunctionParams* ptr = stackalloc BP_SingleCloud_C.__UpdateMaterialParams_FunctionParams[(UIntPtr)599] + 15L / (long)sizeof(BP_SingleCloud_C.__UpdateMaterialParams_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SingleCloud_C.__UpdateMaterialParams_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MID = ((MID != null) ? MID.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SingleCloud_C.__UpdateMaterialParams_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602504C RID: 151628 RVA: 0x009AE9B4 File Offset: 0x009ACBB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SingleCloud_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602504D RID: 151629 RVA: 0x009AE9C8 File Offset: 0x009ACBC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SingleCloud_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602504E RID: 151630 RVA: 0x009AE9E0 File Offset: 0x009ACBE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_SingleCloud_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SingleCloud_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SingleCloud_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SingleCloud_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SingleCloud_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602504F RID: 151631 RVA: 0x009AEA28 File Offset: 0x009ACC28
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_SingleCloud_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SingleCloud_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SingleCloud_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SingleCloud_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SingleCloud_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025050 RID: 151632 RVA: 0x009AEA6F File Offset: 0x009ACC6F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SingleCloud_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06025051 RID: 151633 RVA: 0x009AEA83 File Offset: 0x009ACC83
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SingleCloud_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025052 RID: 151634 RVA: 0x009AEA98 File Offset: 0x009ACC98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SingleCloud_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SingleCloud_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SingleCloud_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SingleCloud_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SingleCloud_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025053 RID: 151635 RVA: 0x009AEAE0 File Offset: 0x009ACCE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SingleCloud_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SingleCloud_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SingleCloud_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SingleCloud_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SingleCloud_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025054 RID: 151636 RVA: 0x009AEB28 File Offset: 0x009ACD28
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SingleCloud(int EntryPoint)
		{
			BP_SingleCloud_C.__ExecuteUbergraph_BP_SingleCloud_FunctionParams* ptr = stackalloc BP_SingleCloud_C.__ExecuteUbergraph_BP_SingleCloud_FunctionParams[(UIntPtr)415] + 15L / (long)sizeof(BP_SingleCloud_C.__ExecuteUbergraph_BP_SingleCloud_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SingleCloud_C.__ExecuteUbergraph_BP_SingleCloud_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SingleCloud_C.__ExecuteUbergraph_BP_SingleCloud_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025055 RID: 151637 RVA: 0x009AEB72 File Offset: 0x009ACD72
		protected BP_SingleCloud_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401303D RID: 77885
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_SingleCloud.BP_SingleCloud_C";

		// Token: 0x0401303E RID: 77886
		private static IntPtr _ClassPtr;

		// Token: 0x0401303F RID: 77887
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013040 RID: 77888
		internal static int __PropertyOffset_0;

		// Token: 0x04013041 RID: 77889
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013042 RID: 77890
		internal static int __PropertyOffset_1;

		// Token: 0x04013043 RID: 77891
		internal static int __PropertyOffset_2;

		// Token: 0x04013044 RID: 77892
		internal static int __PropertyOffset_3;

		// Token: 0x04013045 RID: 77893
		internal static int __PropertyOffset_4;

		// Token: 0x04013046 RID: 77894
		internal static int __PropertyOffset_5;

		// Token: 0x04013047 RID: 77895
		internal static int __PropertyOffset_6;

		// Token: 0x04013048 RID: 77896
		internal static int __PropertyOffset_7;

		// Token: 0x04013049 RID: 77897
		internal static int __PropertyOffset_8;

		// Token: 0x0401304A RID: 77898
		internal static int __PropertyOffset_9;

		// Token: 0x0401304B RID: 77899
		internal static int __PropertyOffset_10;

		// Token: 0x0401304C RID: 77900
		internal static int __PropertyOffset_11;

		// Token: 0x0401304D RID: 77901
		internal static int __PropertyOffset_12;

		// Token: 0x0401304E RID: 77902
		internal static int __PropertyOffset_13;

		// Token: 0x0401304F RID: 77903
		internal static int __PropertyOffset_14;

		// Token: 0x04013050 RID: 77904
		internal static int __PropertyOffset_15;

		// Token: 0x04013051 RID: 77905
		internal static int __PropertyOffset_16;

		// Token: 0x04013052 RID: 77906
		internal static int __PropertyOffset_17;

		// Token: 0x04013053 RID: 77907
		internal static int __PropertyOffset_18;

		// Token: 0x04013054 RID: 77908
		internal static int __PropertyOffset_19;

		// Token: 0x04013055 RID: 77909
		internal static int __PropertyOffset_20;

		// Token: 0x04013056 RID: 77910
		internal static int __PropertyOffset_21;

		// Token: 0x04013057 RID: 77911
		internal static int __PropertyOffset_22;

		// Token: 0x04013058 RID: 77912
		internal static int __PropertyOffset_23;

		// Token: 0x04013059 RID: 77913
		internal static int __PropertyOffset_24;

		// Token: 0x0401305A RID: 77914
		internal static int __PropertyOffset_25;

		// Token: 0x0401305B RID: 77915
		internal static int __PropertyOffset_26;

		// Token: 0x0401305C RID: 77916
		internal static int __PropertyOffset_27;

		// Token: 0x0401305D RID: 77917
		internal static int __PropertyOffset_28;

		// Token: 0x0401305E RID: 77918
		internal static int __PropertyOffset_29;

		// Token: 0x0401305F RID: 77919
		internal static int __PropertyOffset_30;

		// Token: 0x04013060 RID: 77920
		internal static int __PropertyOffset_31;

		// Token: 0x04013061 RID: 77921
		internal static int __PropertyOffset_32;

		// Token: 0x04013062 RID: 77922
		internal static int __PropertyOffset_33;

		// Token: 0x04013063 RID: 77923
		internal static int __PropertyOffset_34;

		// Token: 0x04013064 RID: 77924
		internal static int __PropertyOffset_35;

		// Token: 0x04013065 RID: 77925
		private static IntPtr __UpdateCloudRotation_NativeFunctionPtr;

		// Token: 0x04013066 RID: 77926
		private static IntPtr __UpdateDistanceFade_NativeFunctionPtr;

		// Token: 0x04013067 RID: 77927
		private static IntPtr __UpdateCameraPosition_NativeFunctionPtr;

		// Token: 0x04013068 RID: 77928
		private static IntPtr __UpdateMaterialParams_NativeFunctionPtr;

		// Token: 0x04013069 RID: 77929
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401306A RID: 77930
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401306B RID: 77931
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401306C RID: 77932
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401306D RID: 77933
		private static IntPtr __ExecuteUbergraph_BP_SingleCloud_NativeFunctionPtr;

		// Token: 0x02009EB5 RID: 40629
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 584)]
		protected ref struct __UpdateMaterialParams_FunctionParams
		{
			// Token: 0x04032979 RID: 207225
			[FieldOffset(0)]
			public IntPtr MID;
		}

		// Token: 0x02009EB6 RID: 40630
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x0403297A RID: 207226
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009EB7 RID: 40631
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403297B RID: 207227
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009EB8 RID: 40632
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 400)]
		protected ref struct __ExecuteUbergraph_BP_SingleCloud_FunctionParams
		{
			// Token: 0x0403297C RID: 207228
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
