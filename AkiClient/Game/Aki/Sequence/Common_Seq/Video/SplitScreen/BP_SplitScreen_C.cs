using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Sequence.Common_Seq.Video.SplitScreen
{
	// Token: 0x020043A2 RID: 17314
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Sequence/Common_Seq/Video/SplitScreen/BP_SplitScreen.BP_SplitScreen_C")]
	[UnrealStructLayout(1400, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1400)]
	public class BP_SplitScreen_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DFB0 RID: 188336 RVA: 0x00AD34EE File Offset: 0x00AD16EE
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SplitScreen_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Sequence/Common_Seq/Video/SplitScreen/BP_SplitScreen.BP_SplitScreen_C");
			}
			return BP_SplitScreen_C._ClassPtr;
		}

		// Token: 0x0602DFB1 RID: 188337 RVA: 0x00AD3514 File Offset: 0x00AD1714
		public BP_SplitScreen_C() : this(BuiltinUtils.AllocNativeUObject(BP_SplitScreen_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DFB2 RID: 188338 RVA: 0x00AD353C File Offset: 0x00AD173C
		[NullableContext(1)]
		public BP_SplitScreen_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SplitScreen_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007E51 RID: 32337
		// (get) Token: 0x0602DFB3 RID: 188339 RVA: 0x00AD3570 File Offset: 0x00AD1770
		// (set) Token: 0x0602DFB4 RID: 188340 RVA: 0x00AD35A9 File Offset: 0x00AD17A9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007E52 RID: 32338
		// (get) Token: 0x0602DFB5 RID: 188341 RVA: 0x00AD35CA File Offset: 0x00AD17CA
		// (set) Token: 0x0602DFB6 RID: 188342 RVA: 0x00AD35DE File Offset: 0x00AD17DE
		public unsafe UPointLightComponent PointLight3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007E53 RID: 32339
		// (get) Token: 0x0602DFB7 RID: 188343 RVA: 0x00AD35F3 File Offset: 0x00AD17F3
		// (set) Token: 0x0602DFB8 RID: 188344 RVA: 0x00AD3607 File Offset: 0x00AD1807
		public unsafe UPointLightComponent PointLight2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17007E54 RID: 32340
		// (get) Token: 0x0602DFB9 RID: 188345 RVA: 0x00AD361C File Offset: 0x00AD181C
		// (set) Token: 0x0602DFBA RID: 188346 RVA: 0x00AD3630 File Offset: 0x00AD1830
		public unsafe UPointLightComponent PointLight1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17007E55 RID: 32341
		// (get) Token: 0x0602DFBB RID: 188347 RVA: 0x00AD3645 File Offset: 0x00AD1845
		// (set) Token: 0x0602DFBC RID: 188348 RVA: 0x00AD3659 File Offset: 0x00AD1859
		public unsafe UChildActorComponent CharacterActor_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17007E56 RID: 32342
		// (get) Token: 0x0602DFBD RID: 188349 RVA: 0x00AD366E File Offset: 0x00AD186E
		// (set) Token: 0x0602DFBE RID: 188350 RVA: 0x00AD3682 File Offset: 0x00AD1882
		public unsafe UChildActorComponent CharacterActor_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17007E57 RID: 32343
		// (get) Token: 0x0602DFBF RID: 188351 RVA: 0x00AD3697 File Offset: 0x00AD1897
		// (set) Token: 0x0602DFC0 RID: 188352 RVA: 0x00AD36AB File Offset: 0x00AD18AB
		public unsafe UChildActorComponent CharacterActor_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17007E58 RID: 32344
		// (get) Token: 0x0602DFC1 RID: 188353 RVA: 0x00AD36C0 File Offset: 0x00AD18C0
		// (set) Token: 0x0602DFC2 RID: 188354 RVA: 0x00AD36D4 File Offset: 0x00AD18D4
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17007E59 RID: 32345
		// (get) Token: 0x0602DFC3 RID: 188355 RVA: 0x00AD36E9 File Offset: 0x00AD18E9
		// (set) Token: 0x0602DFC4 RID: 188356 RVA: 0x00AD36FD File Offset: 0x00AD18FD
		public unsafe UMaterialParameterCollection MPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17007E5A RID: 32346
		// (get) Token: 0x0602DFC5 RID: 188357 RVA: 0x00AD3712 File Offset: 0x00AD1912
		// (set) Token: 0x0602DFC6 RID: 188358 RVA: 0x00AD3726 File Offset: 0x00AD1926
		public unsafe FName Angle_LinePosition__LineDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17007E5B RID: 32347
		// (get) Token: 0x0602DFC7 RID: 188359 RVA: 0x00AD373B File Offset: 0x00AD193B
		// (set) Token: 0x0602DFC8 RID: 188360 RVA: 0x00AD374B File Offset: 0x00AD194B
		public unsafe float E_LinkPos_1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17007E5C RID: 32348
		// (get) Token: 0x0602DFC9 RID: 188361 RVA: 0x00AD375C File Offset: 0x00AD195C
		// (set) Token: 0x0602DFCA RID: 188362 RVA: 0x00AD376C File Offset: 0x00AD196C
		public unsafe float E_LinkPos_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17007E5D RID: 32349
		// (get) Token: 0x0602DFCB RID: 188363 RVA: 0x00AD377D File Offset: 0x00AD197D
		// (set) Token: 0x0602DFCC RID: 188364 RVA: 0x00AD378D File Offset: 0x00AD198D
		public unsafe float E_LinkPos_3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17007E5E RID: 32350
		// (get) Token: 0x0602DFCD RID: 188365 RVA: 0x00AD379E File Offset: 0x00AD199E
		// (set) Token: 0x0602DFCE RID: 188366 RVA: 0x00AD37B2 File Offset: 0x00AD19B2
		public unsafe FVector PointLight1_Location
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17007E5F RID: 32351
		// (get) Token: 0x0602DFCF RID: 188367 RVA: 0x00AD37C7 File Offset: 0x00AD19C7
		// (set) Token: 0x0602DFD0 RID: 188368 RVA: 0x00AD37DB File Offset: 0x00AD19DB
		public unsafe FVector PointLight2_Location
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17007E60 RID: 32352
		// (get) Token: 0x0602DFD1 RID: 188369 RVA: 0x00AD37F0 File Offset: 0x00AD19F0
		// (set) Token: 0x0602DFD2 RID: 188370 RVA: 0x00AD3804 File Offset: 0x00AD1A04
		public unsafe FVector PointLight3_Location
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17007E61 RID: 32353
		// (get) Token: 0x0602DFD3 RID: 188371 RVA: 0x00AD3819 File Offset: 0x00AD1A19
		// (set) Token: 0x0602DFD4 RID: 188372 RVA: 0x00AD382D File Offset: 0x00AD1A2D
		public unsafe FLinearColor PointLight1_ToonLightColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17007E62 RID: 32354
		// (get) Token: 0x0602DFD5 RID: 188373 RVA: 0x00AD3842 File Offset: 0x00AD1A42
		// (set) Token: 0x0602DFD6 RID: 188374 RVA: 0x00AD3856 File Offset: 0x00AD1A56
		public unsafe FLinearColor PointLight2_ToonLightColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17007E63 RID: 32355
		// (get) Token: 0x0602DFD7 RID: 188375 RVA: 0x00AD386B File Offset: 0x00AD1A6B
		// (set) Token: 0x0602DFD8 RID: 188376 RVA: 0x00AD387F File Offset: 0x00AD1A7F
		public unsafe FLinearColor PointLight3_ToonLightColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17007E64 RID: 32356
		// (get) Token: 0x0602DFD9 RID: 188377 RVA: 0x00AD3894 File Offset: 0x00AD1A94
		// (set) Token: 0x0602DFDA RID: 188378 RVA: 0x00AD38A8 File Offset: 0x00AD1AA8
		public unsafe FLinearColor EyeLightSimulation_TongKong1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17007E65 RID: 32357
		// (get) Token: 0x0602DFDB RID: 188379 RVA: 0x00AD38BD File Offset: 0x00AD1ABD
		// (set) Token: 0x0602DFDC RID: 188380 RVA: 0x00AD38D1 File Offset: 0x00AD1AD1
		public unsafe FLinearColor EyeLightSimulation_TongKong2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17007E66 RID: 32358
		// (get) Token: 0x0602DFDD RID: 188381 RVA: 0x00AD38E6 File Offset: 0x00AD1AE6
		// (set) Token: 0x0602DFDE RID: 188382 RVA: 0x00AD38FA File Offset: 0x00AD1AFA
		public unsafe FLinearColor EyeLightSimulation_TongKong3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17007E67 RID: 32359
		// (get) Token: 0x0602DFDF RID: 188383 RVA: 0x00AD390F File Offset: 0x00AD1B0F
		// (set) Token: 0x0602DFE0 RID: 188384 RVA: 0x00AD3923 File Offset: 0x00AD1B23
		public unsafe FLinearColor EyeLightSimulation_YanBai1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17007E68 RID: 32360
		// (get) Token: 0x0602DFE1 RID: 188385 RVA: 0x00AD3938 File Offset: 0x00AD1B38
		// (set) Token: 0x0602DFE2 RID: 188386 RVA: 0x00AD394C File Offset: 0x00AD1B4C
		public unsafe FLinearColor EyeLightSimulation_YanBai2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17007E69 RID: 32361
		// (get) Token: 0x0602DFE3 RID: 188387 RVA: 0x00AD3961 File Offset: 0x00AD1B61
		// (set) Token: 0x0602DFE4 RID: 188388 RVA: 0x00AD3975 File Offset: 0x00AD1B75
		public unsafe FLinearColor EyeLightSimulation_YanBai3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17007E6A RID: 32362
		// (get) Token: 0x0602DFE5 RID: 188389 RVA: 0x00AD398A File Offset: 0x00AD1B8A
		// (set) Token: 0x0602DFE6 RID: 188390 RVA: 0x00AD399E File Offset: 0x00AD1B9E
		public unsafe FLinearColor EyeLightSimulation_Color1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17007E6B RID: 32363
		// (get) Token: 0x0602DFE7 RID: 188391 RVA: 0x00AD39B3 File Offset: 0x00AD1BB3
		// (set) Token: 0x0602DFE8 RID: 188392 RVA: 0x00AD39C7 File Offset: 0x00AD1BC7
		public unsafe FLinearColor EyeLightSimulation_Color2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17007E6C RID: 32364
		// (get) Token: 0x0602DFE9 RID: 188393 RVA: 0x00AD39DC File Offset: 0x00AD1BDC
		// (set) Token: 0x0602DFEA RID: 188394 RVA: 0x00AD39F0 File Offset: 0x00AD1BF0
		public unsafe FLinearColor EyeLightSimulation_Color3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17007E6D RID: 32365
		// (get) Token: 0x0602DFEB RID: 188395 RVA: 0x00AD3A05 File Offset: 0x00AD1C05
		// (set) Token: 0x0602DFEC RID: 188396 RVA: 0x00AD3A15 File Offset: 0x00AD1C15
		public unsafe byte MeshPart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17007E6E RID: 32366
		// (get) Token: 0x0602DFED RID: 188397 RVA: 0x00AD3A26 File Offset: 0x00AD1C26
		// (set) Token: 0x0602DFEE RID: 188398 RVA: 0x00AD3A36 File Offset: 0x00AD1C36
		public unsafe int Handle1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17007E6F RID: 32367
		// (get) Token: 0x0602DFEF RID: 188399 RVA: 0x00AD3A47 File Offset: 0x00AD1C47
		// (set) Token: 0x0602DFF0 RID: 188400 RVA: 0x00AD3A57 File Offset: 0x00AD1C57
		public unsafe int Handle2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17007E70 RID: 32368
		// (get) Token: 0x0602DFF1 RID: 188401 RVA: 0x00AD3A68 File Offset: 0x00AD1C68
		// (set) Token: 0x0602DFF2 RID: 188402 RVA: 0x00AD3A78 File Offset: 0x00AD1C78
		public unsafe int Handle3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17007E71 RID: 32369
		// (get) Token: 0x0602DFF3 RID: 188403 RVA: 0x00AD3A89 File Offset: 0x00AD1C89
		// (set) Token: 0x0602DFF4 RID: 188404 RVA: 0x00AD3A9D File Offset: 0x00AD1C9D
		public unsafe UKuroMaterialControllerComponent KuroMaterialControllerComponent1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroMaterialControllerComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_C.__PropertyOffset_32);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_C.__PropertyOffset_32, value);
			}
		}

		// Token: 0x17007E72 RID: 32370
		// (get) Token: 0x0602DFF5 RID: 188405 RVA: 0x00AD3AB2 File Offset: 0x00AD1CB2
		// (set) Token: 0x0602DFF6 RID: 188406 RVA: 0x00AD3AC6 File Offset: 0x00AD1CC6
		public unsafe UKuroMaterialControllerComponent KuroMaterialControllerComponent2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroMaterialControllerComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_C.__PropertyOffset_33);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x17007E73 RID: 32371
		// (get) Token: 0x0602DFF7 RID: 188407 RVA: 0x00AD3ADB File Offset: 0x00AD1CDB
		// (set) Token: 0x0602DFF8 RID: 188408 RVA: 0x00AD3AEF File Offset: 0x00AD1CEF
		public unsafe UKuroMaterialControllerComponent KuroMaterialControllerComponent3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroMaterialControllerComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_C.__PropertyOffset_34);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_C.__PropertyOffset_34, value);
			}
		}

		// Token: 0x0602DFF9 RID: 188409 RVA: 0x00AD3B04 File Offset: 0x00AD1D04
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Reset()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplitScreen_C.__Reset_NativeFunctionPtr, null);
		}

		// Token: 0x0602DFFA RID: 188410 RVA: 0x00AD3B18 File Offset: 0x00AD1D18
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InitKuroMaterialController(UKuroMaterialControllerComponent KuroMaterialControllerComponent, UChildActorComponent CharacterActorComponent, UPointLightComponent PointLightComponent, FVector PointLight_Location, FLinearColor PointLight_ToonLightColor, FLinearColor EyeLightSimulation_TongKong, FLinearColor EyeLightSimulation_YanBai, FLinearColor EyeLightSimulation_Color, float E_LinkPos, bool Channel0, bool Channel1, bool Channel2, ref int returnHandle)
		{
			BP_SplitScreen_C.__InitKuroMaterialController_FunctionParams* ptr = stackalloc BP_SplitScreen_C.__InitKuroMaterialController_FunctionParams[(UIntPtr)335] + 15L / (long)sizeof(BP_SplitScreen_C.__InitKuroMaterialController_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplitScreen_C.__InitKuroMaterialController_NativeFunctionPtr, (void*)ptr, 1);
			ptr->KuroMaterialControllerComponent = ((KuroMaterialControllerComponent != null) ? KuroMaterialControllerComponent.NativePtr : IntPtr.Zero);
			ptr->CharacterActorComponent = ((CharacterActorComponent != null) ? CharacterActorComponent.NativePtr : IntPtr.Zero);
			ptr->PointLightComponent = ((PointLightComponent != null) ? PointLightComponent.NativePtr : IntPtr.Zero);
			ptr->PointLight_Location = PointLight_Location;
			ptr->PointLight_ToonLightColor = PointLight_ToonLightColor;
			ptr->EyeLightSimulation_TongKong = EyeLightSimulation_TongKong;
			ptr->EyeLightSimulation_YanBai = EyeLightSimulation_YanBai;
			ptr->EyeLightSimulation_Color = EyeLightSimulation_Color;
			ptr->E_LinkPos = E_LinkPos;
			ptr->Channel0 = Channel0;
			ptr->Channel1 = Channel1;
			ptr->Channel2 = Channel2;
			ptr->returnHandle = returnHandle;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplitScreen_C.__InitKuroMaterialController_NativeFunctionPtr, (void*)ptr);
			returnHandle = ptr->returnHandle;
		}

		// Token: 0x0602DFFB RID: 188411 RVA: 0x00AD3BF6 File Offset: 0x00AD1DF6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void End()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplitScreen_C.__End_NativeFunctionPtr, null);
		}

		// Token: 0x0602DFFC RID: 188412 RVA: 0x00AD3C0A File Offset: 0x00AD1E0A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Start()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplitScreen_C.__Start_NativeFunctionPtr, null);
		}

		// Token: 0x0602DFFD RID: 188413 RVA: 0x00AD3C1E File Offset: 0x00AD1E1E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplitScreen_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602DFFE RID: 188414 RVA: 0x00AD3C32 File Offset: 0x00AD1E32
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplitScreen_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602DFFF RID: 188415 RVA: 0x00AD3C48 File Offset: 0x00AD1E48
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SplitScreen_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SplitScreen_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SplitScreen_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplitScreen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplitScreen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602E000 RID: 188416 RVA: 0x00AD3C90 File Offset: 0x00AD1E90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SplitScreen_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SplitScreen_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SplitScreen_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplitScreen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplitScreen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602E001 RID: 188417 RVA: 0x00AD3CD8 File Offset: 0x00AD1ED8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SplitScreen(int EntryPoint)
		{
			BP_SplitScreen_C.__ExecuteUbergraph_BP_SplitScreen_FunctionParams* ptr = stackalloc BP_SplitScreen_C.__ExecuteUbergraph_BP_SplitScreen_FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(BP_SplitScreen_C.__ExecuteUbergraph_BP_SplitScreen_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplitScreen_C.__ExecuteUbergraph_BP_SplitScreen_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplitScreen_C.__ExecuteUbergraph_BP_SplitScreen_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602E002 RID: 188418 RVA: 0x00AD3D1F File Offset: 0x00AD1F1F
		protected BP_SplitScreen_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019FC2 RID: 106434
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Sequence/Common_Seq/Video/SplitScreen/BP_SplitScreen.BP_SplitScreen_C";

		// Token: 0x04019FC3 RID: 106435
		private static IntPtr _ClassPtr;

		// Token: 0x04019FC4 RID: 106436
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019FC5 RID: 106437
		internal static int __PropertyOffset_0;

		// Token: 0x04019FC6 RID: 106438
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04019FC7 RID: 106439
		internal static int __PropertyOffset_1;

		// Token: 0x04019FC8 RID: 106440
		internal static int __PropertyOffset_2;

		// Token: 0x04019FC9 RID: 106441
		internal static int __PropertyOffset_3;

		// Token: 0x04019FCA RID: 106442
		internal static int __PropertyOffset_4;

		// Token: 0x04019FCB RID: 106443
		internal static int __PropertyOffset_5;

		// Token: 0x04019FCC RID: 106444
		internal static int __PropertyOffset_6;

		// Token: 0x04019FCD RID: 106445
		internal static int __PropertyOffset_7;

		// Token: 0x04019FCE RID: 106446
		internal static int __PropertyOffset_8;

		// Token: 0x04019FCF RID: 106447
		internal static int __PropertyOffset_9;

		// Token: 0x04019FD0 RID: 106448
		internal static int __PropertyOffset_10;

		// Token: 0x04019FD1 RID: 106449
		internal static int __PropertyOffset_11;

		// Token: 0x04019FD2 RID: 106450
		internal static int __PropertyOffset_12;

		// Token: 0x04019FD3 RID: 106451
		internal static int __PropertyOffset_13;

		// Token: 0x04019FD4 RID: 106452
		internal static int __PropertyOffset_14;

		// Token: 0x04019FD5 RID: 106453
		internal static int __PropertyOffset_15;

		// Token: 0x04019FD6 RID: 106454
		internal static int __PropertyOffset_16;

		// Token: 0x04019FD7 RID: 106455
		internal static int __PropertyOffset_17;

		// Token: 0x04019FD8 RID: 106456
		internal static int __PropertyOffset_18;

		// Token: 0x04019FD9 RID: 106457
		internal static int __PropertyOffset_19;

		// Token: 0x04019FDA RID: 106458
		internal static int __PropertyOffset_20;

		// Token: 0x04019FDB RID: 106459
		internal static int __PropertyOffset_21;

		// Token: 0x04019FDC RID: 106460
		internal static int __PropertyOffset_22;

		// Token: 0x04019FDD RID: 106461
		internal static int __PropertyOffset_23;

		// Token: 0x04019FDE RID: 106462
		internal static int __PropertyOffset_24;

		// Token: 0x04019FDF RID: 106463
		internal static int __PropertyOffset_25;

		// Token: 0x04019FE0 RID: 106464
		internal static int __PropertyOffset_26;

		// Token: 0x04019FE1 RID: 106465
		internal static int __PropertyOffset_27;

		// Token: 0x04019FE2 RID: 106466
		internal static int __PropertyOffset_28;

		// Token: 0x04019FE3 RID: 106467
		internal static int __PropertyOffset_29;

		// Token: 0x04019FE4 RID: 106468
		internal static int __PropertyOffset_30;

		// Token: 0x04019FE5 RID: 106469
		internal static int __PropertyOffset_31;

		// Token: 0x04019FE6 RID: 106470
		internal static int __PropertyOffset_32;

		// Token: 0x04019FE7 RID: 106471
		internal static int __PropertyOffset_33;

		// Token: 0x04019FE8 RID: 106472
		internal static int __PropertyOffset_34;

		// Token: 0x04019FE9 RID: 106473
		private static IntPtr __Reset_NativeFunctionPtr;

		// Token: 0x04019FEA RID: 106474
		private static IntPtr __InitKuroMaterialController_NativeFunctionPtr;

		// Token: 0x04019FEB RID: 106475
		private static IntPtr __End_NativeFunctionPtr;

		// Token: 0x04019FEC RID: 106476
		private static IntPtr __Start_NativeFunctionPtr;

		// Token: 0x04019FED RID: 106477
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04019FEE RID: 106478
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04019FEF RID: 106479
		private static IntPtr __ExecuteUbergraph_BP_SplitScreen_NativeFunctionPtr;

		// Token: 0x0200A604 RID: 42500
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 320)]
		protected ref struct __InitKuroMaterialController_FunctionParams
		{
			// Token: 0x040335B7 RID: 210359
			[FieldOffset(0)]
			public IntPtr KuroMaterialControllerComponent;

			// Token: 0x040335B8 RID: 210360
			[FieldOffset(8)]
			public IntPtr CharacterActorComponent;

			// Token: 0x040335B9 RID: 210361
			[FieldOffset(16)]
			public IntPtr PointLightComponent;

			// Token: 0x040335BA RID: 210362
			[FieldOffset(24)]
			public FVector PointLight_Location;

			// Token: 0x040335BB RID: 210363
			[FieldOffset(36)]
			public FLinearColor PointLight_ToonLightColor;

			// Token: 0x040335BC RID: 210364
			[FieldOffset(52)]
			public FLinearColor EyeLightSimulation_TongKong;

			// Token: 0x040335BD RID: 210365
			[FieldOffset(68)]
			public FLinearColor EyeLightSimulation_YanBai;

			// Token: 0x040335BE RID: 210366
			[FieldOffset(84)]
			public FLinearColor EyeLightSimulation_Color;

			// Token: 0x040335BF RID: 210367
			[FieldOffset(100)]
			public float E_LinkPos;

			// Token: 0x040335C0 RID: 210368
			[FieldOffset(104)]
			public bool Channel0;

			// Token: 0x040335C1 RID: 210369
			[FieldOffset(105)]
			public bool Channel1;

			// Token: 0x040335C2 RID: 210370
			[FieldOffset(106)]
			public bool Channel2;

			// Token: 0x040335C3 RID: 210371
			[FieldOffset(108)]
			public int returnHandle;
		}

		// Token: 0x0200A605 RID: 42501
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040335C4 RID: 210372
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A606 RID: 42502
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __ExecuteUbergraph_BP_SplitScreen_FunctionParams
		{
			// Token: 0x040335C5 RID: 210373
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
