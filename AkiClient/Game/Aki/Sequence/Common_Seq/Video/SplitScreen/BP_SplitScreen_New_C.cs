using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Sequence.Common_Seq.Video.SplitScreen
{
	// Token: 0x020043A3 RID: 17315
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Sequence/Common_Seq/Video/SplitScreen/BP_SplitScreen_New.BP_SplitScreen_New_C")]
	[UnrealStructLayout(1784, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1780)]
	public class BP_SplitScreen_New_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602E003 RID: 188419 RVA: 0x00AD3D28 File Offset: 0x00AD1F28
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SplitScreen_New_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Sequence/Common_Seq/Video/SplitScreen/BP_SplitScreen_New.BP_SplitScreen_New_C");
			}
			return BP_SplitScreen_New_C._ClassPtr;
		}

		// Token: 0x0602E004 RID: 188420 RVA: 0x00AD3D4C File Offset: 0x00AD1F4C
		public BP_SplitScreen_New_C() : this(BuiltinUtils.AllocNativeUObject(BP_SplitScreen_New_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602E005 RID: 188421 RVA: 0x00AD3D74 File Offset: 0x00AD1F74
		[NullableContext(1)]
		public BP_SplitScreen_New_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SplitScreen_New_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007E74 RID: 32372
		// (get) Token: 0x0602E006 RID: 188422 RVA: 0x00AD3DA8 File Offset: 0x00AD1FA8
		// (set) Token: 0x0602E007 RID: 188423 RVA: 0x00AD3DE1 File Offset: 0x00AD1FE1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007E75 RID: 32373
		// (get) Token: 0x0602E008 RID: 188424 RVA: 0x00AD3E02 File Offset: 0x00AD2002
		// (set) Token: 0x0602E009 RID: 188425 RVA: 0x00AD3E16 File Offset: 0x00AD2016
		public unsafe UChildActorComponent CharacterActor_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007E76 RID: 32374
		// (get) Token: 0x0602E00A RID: 188426 RVA: 0x00AD3E2B File Offset: 0x00AD202B
		// (set) Token: 0x0602E00B RID: 188427 RVA: 0x00AD3E3F File Offset: 0x00AD203F
		public unsafe USceneComponent Character3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17007E77 RID: 32375
		// (get) Token: 0x0602E00C RID: 188428 RVA: 0x00AD3E54 File Offset: 0x00AD2054
		// (set) Token: 0x0602E00D RID: 188429 RVA: 0x00AD3E68 File Offset: 0x00AD2068
		public unsafe UChildActorComponent CharacterActor_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17007E78 RID: 32376
		// (get) Token: 0x0602E00E RID: 188430 RVA: 0x00AD3E7D File Offset: 0x00AD207D
		// (set) Token: 0x0602E00F RID: 188431 RVA: 0x00AD3E91 File Offset: 0x00AD2091
		public unsafe USceneComponent Character2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17007E79 RID: 32377
		// (get) Token: 0x0602E010 RID: 188432 RVA: 0x00AD3EA6 File Offset: 0x00AD20A6
		// (set) Token: 0x0602E011 RID: 188433 RVA: 0x00AD3EBA File Offset: 0x00AD20BA
		public unsafe UChildActorComponent CharacterActor_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17007E7A RID: 32378
		// (get) Token: 0x0602E012 RID: 188434 RVA: 0x00AD3ECF File Offset: 0x00AD20CF
		// (set) Token: 0x0602E013 RID: 188435 RVA: 0x00AD3EE3 File Offset: 0x00AD20E3
		public unsafe USceneComponent Character1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17007E7B RID: 32379
		// (get) Token: 0x0602E014 RID: 188436 RVA: 0x00AD3EF8 File Offset: 0x00AD20F8
		// (set) Token: 0x0602E015 RID: 188437 RVA: 0x00AD3F0C File Offset: 0x00AD210C
		public unsafe UPointLightComponent PointLight3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17007E7C RID: 32380
		// (get) Token: 0x0602E016 RID: 188438 RVA: 0x00AD3F21 File Offset: 0x00AD2121
		// (set) Token: 0x0602E017 RID: 188439 RVA: 0x00AD3F35 File Offset: 0x00AD2135
		public unsafe UPointLightComponent PointLight2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17007E7D RID: 32381
		// (get) Token: 0x0602E018 RID: 188440 RVA: 0x00AD3F4A File Offset: 0x00AD214A
		// (set) Token: 0x0602E019 RID: 188441 RVA: 0x00AD3F5E File Offset: 0x00AD215E
		public unsafe UPointLightComponent PointLight1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17007E7E RID: 32382
		// (get) Token: 0x0602E01A RID: 188442 RVA: 0x00AD3F73 File Offset: 0x00AD2173
		// (set) Token: 0x0602E01B RID: 188443 RVA: 0x00AD3F87 File Offset: 0x00AD2187
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17007E7F RID: 32383
		// (get) Token: 0x0602E01C RID: 188444 RVA: 0x00AD3F9C File Offset: 0x00AD219C
		// (set) Token: 0x0602E01D RID: 188445 RVA: 0x00AD3FB0 File Offset: 0x00AD21B0
		public unsafe UMaterialParameterCollection MPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17007E80 RID: 32384
		// (get) Token: 0x0602E01E RID: 188446 RVA: 0x00AD3FC5 File Offset: 0x00AD21C5
		// (set) Token: 0x0602E01F RID: 188447 RVA: 0x00AD3FD9 File Offset: 0x00AD21D9
		public unsafe FName Angle_LinePosition__LineDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17007E81 RID: 32385
		// (get) Token: 0x0602E020 RID: 188448 RVA: 0x00AD3FEE File Offset: 0x00AD21EE
		// (set) Token: 0x0602E021 RID: 188449 RVA: 0x00AD3FFE File Offset: 0x00AD21FE
		public unsafe float E_LinkPos_1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17007E82 RID: 32386
		// (get) Token: 0x0602E022 RID: 188450 RVA: 0x00AD400F File Offset: 0x00AD220F
		// (set) Token: 0x0602E023 RID: 188451 RVA: 0x00AD401F File Offset: 0x00AD221F
		public unsafe float E_LinkPos_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17007E83 RID: 32387
		// (get) Token: 0x0602E024 RID: 188452 RVA: 0x00AD4030 File Offset: 0x00AD2230
		// (set) Token: 0x0602E025 RID: 188453 RVA: 0x00AD4040 File Offset: 0x00AD2240
		public unsafe float E_LinkPos_3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17007E84 RID: 32388
		// (get) Token: 0x0602E026 RID: 188454 RVA: 0x00AD4051 File Offset: 0x00AD2251
		// (set) Token: 0x0602E027 RID: 188455 RVA: 0x00AD4061 File Offset: 0x00AD2261
		public unsafe float LightYaw1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17007E85 RID: 32389
		// (get) Token: 0x0602E028 RID: 188456 RVA: 0x00AD4072 File Offset: 0x00AD2272
		// (set) Token: 0x0602E029 RID: 188457 RVA: 0x00AD4082 File Offset: 0x00AD2282
		public unsafe float LightYaw2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17007E86 RID: 32390
		// (get) Token: 0x0602E02A RID: 188458 RVA: 0x00AD4093 File Offset: 0x00AD2293
		// (set) Token: 0x0602E02B RID: 188459 RVA: 0x00AD40A3 File Offset: 0x00AD22A3
		public unsafe float LightYaw3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17007E87 RID: 32391
		// (get) Token: 0x0602E02C RID: 188460 RVA: 0x00AD40B4 File Offset: 0x00AD22B4
		// (set) Token: 0x0602E02D RID: 188461 RVA: 0x00AD40C4 File Offset: 0x00AD22C4
		public unsafe float FaceLightYaw1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17007E88 RID: 32392
		// (get) Token: 0x0602E02E RID: 188462 RVA: 0x00AD40D5 File Offset: 0x00AD22D5
		// (set) Token: 0x0602E02F RID: 188463 RVA: 0x00AD40E5 File Offset: 0x00AD22E5
		public unsafe float FaceLightYaw2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17007E89 RID: 32393
		// (get) Token: 0x0602E030 RID: 188464 RVA: 0x00AD40F6 File Offset: 0x00AD22F6
		// (set) Token: 0x0602E031 RID: 188465 RVA: 0x00AD4106 File Offset: 0x00AD2306
		public unsafe float FaceLightYaw3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17007E8A RID: 32394
		// (get) Token: 0x0602E032 RID: 188466 RVA: 0x00AD4117 File Offset: 0x00AD2317
		// (set) Token: 0x0602E033 RID: 188467 RVA: 0x00AD412B File Offset: 0x00AD232B
		public unsafe FVector PointLight1_Location
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17007E8B RID: 32395
		// (get) Token: 0x0602E034 RID: 188468 RVA: 0x00AD4140 File Offset: 0x00AD2340
		// (set) Token: 0x0602E035 RID: 188469 RVA: 0x00AD4154 File Offset: 0x00AD2354
		public unsafe FVector PointLight2_Location
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17007E8C RID: 32396
		// (get) Token: 0x0602E036 RID: 188470 RVA: 0x00AD4169 File Offset: 0x00AD2369
		// (set) Token: 0x0602E037 RID: 188471 RVA: 0x00AD417D File Offset: 0x00AD237D
		public unsafe FVector PointLight3_Location
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17007E8D RID: 32397
		// (get) Token: 0x0602E038 RID: 188472 RVA: 0x00AD4192 File Offset: 0x00AD2392
		// (set) Token: 0x0602E039 RID: 188473 RVA: 0x00AD41A6 File Offset: 0x00AD23A6
		public unsafe FLinearColor PointLight1_ToonLightColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17007E8E RID: 32398
		// (get) Token: 0x0602E03A RID: 188474 RVA: 0x00AD41BB File Offset: 0x00AD23BB
		// (set) Token: 0x0602E03B RID: 188475 RVA: 0x00AD41CF File Offset: 0x00AD23CF
		public unsafe FLinearColor PointLight2_ToonLightColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17007E8F RID: 32399
		// (get) Token: 0x0602E03C RID: 188476 RVA: 0x00AD41E4 File Offset: 0x00AD23E4
		// (set) Token: 0x0602E03D RID: 188477 RVA: 0x00AD41F8 File Offset: 0x00AD23F8
		public unsafe FLinearColor PointLight3_ToonLightColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17007E90 RID: 32400
		// (get) Token: 0x0602E03E RID: 188478 RVA: 0x00AD420D File Offset: 0x00AD240D
		// (set) Token: 0x0602E03F RID: 188479 RVA: 0x00AD4221 File Offset: 0x00AD2421
		public unsafe FLinearColor EyeLightSimulation_TongKong1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17007E91 RID: 32401
		// (get) Token: 0x0602E040 RID: 188480 RVA: 0x00AD4236 File Offset: 0x00AD2436
		// (set) Token: 0x0602E041 RID: 188481 RVA: 0x00AD424A File Offset: 0x00AD244A
		public unsafe FLinearColor EyeLightSimulation_TongKong2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17007E92 RID: 32402
		// (get) Token: 0x0602E042 RID: 188482 RVA: 0x00AD425F File Offset: 0x00AD245F
		// (set) Token: 0x0602E043 RID: 188483 RVA: 0x00AD4273 File Offset: 0x00AD2473
		public unsafe FLinearColor EyeLightSimulation_TongKong3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17007E93 RID: 32403
		// (get) Token: 0x0602E044 RID: 188484 RVA: 0x00AD4288 File Offset: 0x00AD2488
		// (set) Token: 0x0602E045 RID: 188485 RVA: 0x00AD429C File Offset: 0x00AD249C
		public unsafe FLinearColor EyeLightSimulation_YanBai1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17007E94 RID: 32404
		// (get) Token: 0x0602E046 RID: 188486 RVA: 0x00AD42B1 File Offset: 0x00AD24B1
		// (set) Token: 0x0602E047 RID: 188487 RVA: 0x00AD42C5 File Offset: 0x00AD24C5
		public unsafe FLinearColor EyeLightSimulation_YanBai2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17007E95 RID: 32405
		// (get) Token: 0x0602E048 RID: 188488 RVA: 0x00AD42DA File Offset: 0x00AD24DA
		// (set) Token: 0x0602E049 RID: 188489 RVA: 0x00AD42EE File Offset: 0x00AD24EE
		public unsafe FLinearColor EyeLightSimulation_YanBai3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17007E96 RID: 32406
		// (get) Token: 0x0602E04A RID: 188490 RVA: 0x00AD4303 File Offset: 0x00AD2503
		// (set) Token: 0x0602E04B RID: 188491 RVA: 0x00AD4317 File Offset: 0x00AD2517
		public unsafe FLinearColor EyeLightSimulation_Color1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17007E97 RID: 32407
		// (get) Token: 0x0602E04C RID: 188492 RVA: 0x00AD432C File Offset: 0x00AD252C
		// (set) Token: 0x0602E04D RID: 188493 RVA: 0x00AD4340 File Offset: 0x00AD2540
		public unsafe FLinearColor EyeLightSimulation_Color2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x17007E98 RID: 32408
		// (get) Token: 0x0602E04E RID: 188494 RVA: 0x00AD4355 File Offset: 0x00AD2555
		// (set) Token: 0x0602E04F RID: 188495 RVA: 0x00AD4369 File Offset: 0x00AD2569
		public unsafe FLinearColor EyeLightSimulation_Color3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17007E99 RID: 32409
		// (get) Token: 0x0602E050 RID: 188496 RVA: 0x00AD437E File Offset: 0x00AD257E
		// (set) Token: 0x0602E051 RID: 188497 RVA: 0x00AD438E File Offset: 0x00AD258E
		public unsafe byte MeshPart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17007E9A RID: 32410
		// (get) Token: 0x0602E052 RID: 188498 RVA: 0x00AD439F File Offset: 0x00AD259F
		// (set) Token: 0x0602E053 RID: 188499 RVA: 0x00AD43AF File Offset: 0x00AD25AF
		public unsafe int Handle1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17007E9B RID: 32411
		// (get) Token: 0x0602E054 RID: 188500 RVA: 0x00AD43C0 File Offset: 0x00AD25C0
		// (set) Token: 0x0602E055 RID: 188501 RVA: 0x00AD43D0 File Offset: 0x00AD25D0
		public unsafe int Handle2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17007E9C RID: 32412
		// (get) Token: 0x0602E056 RID: 188502 RVA: 0x00AD43E1 File Offset: 0x00AD25E1
		// (set) Token: 0x0602E057 RID: 188503 RVA: 0x00AD43F1 File Offset: 0x00AD25F1
		public unsafe int Handle3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x17007E9D RID: 32413
		// (get) Token: 0x0602E058 RID: 188504 RVA: 0x00AD4402 File Offset: 0x00AD2602
		// (set) Token: 0x0602E059 RID: 188505 RVA: 0x00AD4416 File Offset: 0x00AD2616
		public unsafe UKuroMaterialControllerComponent KuroMaterialControllerComponent1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroMaterialControllerComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_41);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_41, value);
			}
		}

		// Token: 0x17007E9E RID: 32414
		// (get) Token: 0x0602E05A RID: 188506 RVA: 0x00AD442B File Offset: 0x00AD262B
		// (set) Token: 0x0602E05B RID: 188507 RVA: 0x00AD443F File Offset: 0x00AD263F
		public unsafe UKuroMaterialControllerComponent KuroMaterialControllerComponent2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroMaterialControllerComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_42);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_42, value);
			}
		}

		// Token: 0x17007E9F RID: 32415
		// (get) Token: 0x0602E05C RID: 188508 RVA: 0x00AD4454 File Offset: 0x00AD2654
		// (set) Token: 0x0602E05D RID: 188509 RVA: 0x00AD4468 File Offset: 0x00AD2668
		public unsafe UKuroMaterialControllerComponent KuroMaterialControllerComponent3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroMaterialControllerComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_43);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreen_New_C.__PropertyOffset_43, value);
			}
		}

		// Token: 0x17007EA0 RID: 32416
		// (get) Token: 0x0602E05E RID: 188510 RVA: 0x00AD447D File Offset: 0x00AD267D
		// (set) Token: 0x0602E05F RID: 188511 RVA: 0x00AD448D File Offset: 0x00AD268D
		public unsafe float textX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x17007EA1 RID: 32417
		// (get) Token: 0x0602E060 RID: 188512 RVA: 0x00AD449E File Offset: 0x00AD269E
		// (set) Token: 0x0602E061 RID: 188513 RVA: 0x00AD44AE File Offset: 0x00AD26AE
		public unsafe float textY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x17007EA2 RID: 32418
		// (get) Token: 0x0602E062 RID: 188514 RVA: 0x00AD44BF File Offset: 0x00AD26BF
		// (set) Token: 0x0602E063 RID: 188515 RVA: 0x00AD44CF File Offset: 0x00AD26CF
		public unsafe float Width
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_46);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x17007EA3 RID: 32419
		// (get) Token: 0x0602E064 RID: 188516 RVA: 0x00AD44E0 File Offset: 0x00AD26E0
		// (set) Token: 0x0602E065 RID: 188517 RVA: 0x00AD44F4 File Offset: 0x00AD26F4
		public unsafe FVector LinkCameraLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x17007EA4 RID: 32420
		// (get) Token: 0x0602E066 RID: 188518 RVA: 0x00AD4509 File Offset: 0x00AD2709
		// (set) Token: 0x0602E067 RID: 188519 RVA: 0x00AD451D File Offset: 0x00AD271D
		public unsafe FVector LinkCameraRelativeLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x17007EA5 RID: 32421
		// (get) Token: 0x0602E068 RID: 188520 RVA: 0x00AD4532 File Offset: 0x00AD2732
		// (set) Token: 0x0602E069 RID: 188521 RVA: 0x00AD4542 File Offset: 0x00AD2742
		public unsafe bool IsThree
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_49) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_49) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007EA6 RID: 32422
		// (get) Token: 0x0602E06A RID: 188522 RVA: 0x00AD4553 File Offset: 0x00AD2753
		// (set) Token: 0x0602E06B RID: 188523 RVA: 0x00AD4563 File Offset: 0x00AD2763
		public unsafe int RoleId1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_50);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_50) = value;
			}
		}

		// Token: 0x17007EA7 RID: 32423
		// (get) Token: 0x0602E06C RID: 188524 RVA: 0x00AD4574 File Offset: 0x00AD2774
		// (set) Token: 0x0602E06D RID: 188525 RVA: 0x00AD4584 File Offset: 0x00AD2784
		public unsafe int RoleId2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x17007EA8 RID: 32424
		// (get) Token: 0x0602E06E RID: 188526 RVA: 0x00AD4595 File Offset: 0x00AD2795
		// (set) Token: 0x0602E06F RID: 188527 RVA: 0x00AD45A5 File Offset: 0x00AD27A5
		public unsafe int RoleId3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_52);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreen_New_C.__PropertyOffset_52) = value;
			}
		}

		// Token: 0x0602E070 RID: 188528 RVA: 0x00AD45B8 File Offset: 0x00AD27B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetLightDirection(USkeletalMeshComponent Mesh, float LightYaw, float FaceLightYaw)
		{
			BP_SplitScreen_New_C.__SetLightDirection_FunctionParams* ptr = stackalloc BP_SplitScreen_New_C.__SetLightDirection_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(BP_SplitScreen_New_C.__SetLightDirection_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplitScreen_New_C.__SetLightDirection_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Mesh = ((Mesh != null) ? Mesh.NativePtr : IntPtr.Zero);
			ptr->LightYaw = LightYaw;
			ptr->FaceLightYaw = FaceLightYaw;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplitScreen_New_C.__SetLightDirection_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602E071 RID: 188529 RVA: 0x00AD461C File Offset: 0x00AD281C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual FVector EulerToForward(float Pitch, float Yaw)
		{
			BP_SplitScreen_New_C.__EulerToForward_FunctionParams* ptr = stackalloc BP_SplitScreen_New_C.__EulerToForward_FunctionParams[(UIntPtr)35] + 15L / (long)sizeof(BP_SplitScreen_New_C.__EulerToForward_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplitScreen_New_C.__EulerToForward_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Pitch = Pitch;
			ptr->Yaw = Yaw;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplitScreen_New_C.__EulerToForward_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602E072 RID: 188530 RVA: 0x00AD466F File Offset: 0x00AD286F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetPosByViewSize()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplitScreen_New_C.__SetPosByViewSize_NativeFunctionPtr, null);
		}

		// Token: 0x0602E073 RID: 188531 RVA: 0x00AD4683 File Offset: 0x00AD2883
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Reset()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplitScreen_New_C.__Reset_NativeFunctionPtr, null);
		}

		// Token: 0x0602E074 RID: 188532 RVA: 0x00AD4698 File Offset: 0x00AD2898
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InitKuroMaterialController(UKuroMaterialControllerComponent KuroMaterialControllerComponent, UChildActorComponent CharacterActorComponent, UPointLightComponent PointLightComponent, FVector PointLight_Location, FLinearColor PointLight_ToonLightColor, FLinearColor EyeLightSimulation_TongKong, FLinearColor EyeLightSimulation_YanBai, FLinearColor EyeLightSimulation_Color, float E_LinkPos, bool Channel0, bool Channel1, bool Channel2, float LightYaw, float FaceLightYaw, int RoleId, ref int returnHandle)
		{
			BP_SplitScreen_New_C.__InitKuroMaterialController_FunctionParams* ptr = stackalloc BP_SplitScreen_New_C.__InitKuroMaterialController_FunctionParams[(UIntPtr)359] + 15L / (long)sizeof(BP_SplitScreen_New_C.__InitKuroMaterialController_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplitScreen_New_C.__InitKuroMaterialController_NativeFunctionPtr, (void*)ptr, 1);
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
			ptr->LightYaw = LightYaw;
			ptr->FaceLightYaw = FaceLightYaw;
			ptr->RoleId = RoleId;
			ptr->returnHandle = returnHandle;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplitScreen_New_C.__InitKuroMaterialController_NativeFunctionPtr, (void*)ptr);
			returnHandle = ptr->returnHandle;
		}

		// Token: 0x0602E075 RID: 188533 RVA: 0x00AD478E File Offset: 0x00AD298E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void End()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplitScreen_New_C.__End_NativeFunctionPtr, null);
		}

		// Token: 0x0602E076 RID: 188534 RVA: 0x00AD47A2 File Offset: 0x00AD29A2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Start()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplitScreen_New_C.__Start_NativeFunctionPtr, null);
		}

		// Token: 0x0602E077 RID: 188535 RVA: 0x00AD47B6 File Offset: 0x00AD29B6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplitScreen_New_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602E078 RID: 188536 RVA: 0x00AD47CA File Offset: 0x00AD29CA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplitScreen_New_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602E079 RID: 188537 RVA: 0x00AD47E0 File Offset: 0x00AD29E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SplitScreen_New_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SplitScreen_New_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SplitScreen_New_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplitScreen_New_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplitScreen_New_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602E07A RID: 188538 RVA: 0x00AD4828 File Offset: 0x00AD2A28
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SplitScreen_New_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SplitScreen_New_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SplitScreen_New_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplitScreen_New_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplitScreen_New_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602E07B RID: 188539 RVA: 0x00AD4870 File Offset: 0x00AD2A70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_SplitScreen_New_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SplitScreen_New_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SplitScreen_New_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplitScreen_New_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplitScreen_New_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602E07C RID: 188540 RVA: 0x00AD48B8 File Offset: 0x00AD2AB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_SplitScreen_New_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SplitScreen_New_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SplitScreen_New_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplitScreen_New_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplitScreen_New_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602E07D RID: 188541 RVA: 0x00AD4900 File Offset: 0x00AD2B00
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SplitScreen_New(int EntryPoint)
		{
			BP_SplitScreen_New_C.__ExecuteUbergraph_BP_SplitScreen_New_FunctionParams* ptr = stackalloc BP_SplitScreen_New_C.__ExecuteUbergraph_BP_SplitScreen_New_FunctionParams[(UIntPtr)143] + 15L / (long)sizeof(BP_SplitScreen_New_C.__ExecuteUbergraph_BP_SplitScreen_New_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplitScreen_New_C.__ExecuteUbergraph_BP_SplitScreen_New_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplitScreen_New_C.__ExecuteUbergraph_BP_SplitScreen_New_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602E07E RID: 188542 RVA: 0x00AD494A File Offset: 0x00AD2B4A
		protected BP_SplitScreen_New_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019FF0 RID: 106480
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Sequence/Common_Seq/Video/SplitScreen/BP_SplitScreen_New.BP_SplitScreen_New_C";

		// Token: 0x04019FF1 RID: 106481
		private static IntPtr _ClassPtr;

		// Token: 0x04019FF2 RID: 106482
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019FF3 RID: 106483
		internal static int __PropertyOffset_0;

		// Token: 0x04019FF4 RID: 106484
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04019FF5 RID: 106485
		internal static int __PropertyOffset_1;

		// Token: 0x04019FF6 RID: 106486
		internal static int __PropertyOffset_2;

		// Token: 0x04019FF7 RID: 106487
		internal static int __PropertyOffset_3;

		// Token: 0x04019FF8 RID: 106488
		internal static int __PropertyOffset_4;

		// Token: 0x04019FF9 RID: 106489
		internal static int __PropertyOffset_5;

		// Token: 0x04019FFA RID: 106490
		internal static int __PropertyOffset_6;

		// Token: 0x04019FFB RID: 106491
		internal static int __PropertyOffset_7;

		// Token: 0x04019FFC RID: 106492
		internal static int __PropertyOffset_8;

		// Token: 0x04019FFD RID: 106493
		internal static int __PropertyOffset_9;

		// Token: 0x04019FFE RID: 106494
		internal static int __PropertyOffset_10;

		// Token: 0x04019FFF RID: 106495
		internal static int __PropertyOffset_11;

		// Token: 0x0401A000 RID: 106496
		internal static int __PropertyOffset_12;

		// Token: 0x0401A001 RID: 106497
		internal static int __PropertyOffset_13;

		// Token: 0x0401A002 RID: 106498
		internal static int __PropertyOffset_14;

		// Token: 0x0401A003 RID: 106499
		internal static int __PropertyOffset_15;

		// Token: 0x0401A004 RID: 106500
		internal static int __PropertyOffset_16;

		// Token: 0x0401A005 RID: 106501
		internal static int __PropertyOffset_17;

		// Token: 0x0401A006 RID: 106502
		internal static int __PropertyOffset_18;

		// Token: 0x0401A007 RID: 106503
		internal static int __PropertyOffset_19;

		// Token: 0x0401A008 RID: 106504
		internal static int __PropertyOffset_20;

		// Token: 0x0401A009 RID: 106505
		internal static int __PropertyOffset_21;

		// Token: 0x0401A00A RID: 106506
		internal static int __PropertyOffset_22;

		// Token: 0x0401A00B RID: 106507
		internal static int __PropertyOffset_23;

		// Token: 0x0401A00C RID: 106508
		internal static int __PropertyOffset_24;

		// Token: 0x0401A00D RID: 106509
		internal static int __PropertyOffset_25;

		// Token: 0x0401A00E RID: 106510
		internal static int __PropertyOffset_26;

		// Token: 0x0401A00F RID: 106511
		internal static int __PropertyOffset_27;

		// Token: 0x0401A010 RID: 106512
		internal static int __PropertyOffset_28;

		// Token: 0x0401A011 RID: 106513
		internal static int __PropertyOffset_29;

		// Token: 0x0401A012 RID: 106514
		internal static int __PropertyOffset_30;

		// Token: 0x0401A013 RID: 106515
		internal static int __PropertyOffset_31;

		// Token: 0x0401A014 RID: 106516
		internal static int __PropertyOffset_32;

		// Token: 0x0401A015 RID: 106517
		internal static int __PropertyOffset_33;

		// Token: 0x0401A016 RID: 106518
		internal static int __PropertyOffset_34;

		// Token: 0x0401A017 RID: 106519
		internal static int __PropertyOffset_35;

		// Token: 0x0401A018 RID: 106520
		internal static int __PropertyOffset_36;

		// Token: 0x0401A019 RID: 106521
		internal static int __PropertyOffset_37;

		// Token: 0x0401A01A RID: 106522
		internal static int __PropertyOffset_38;

		// Token: 0x0401A01B RID: 106523
		internal static int __PropertyOffset_39;

		// Token: 0x0401A01C RID: 106524
		internal static int __PropertyOffset_40;

		// Token: 0x0401A01D RID: 106525
		internal static int __PropertyOffset_41;

		// Token: 0x0401A01E RID: 106526
		internal static int __PropertyOffset_42;

		// Token: 0x0401A01F RID: 106527
		internal static int __PropertyOffset_43;

		// Token: 0x0401A020 RID: 106528
		internal static int __PropertyOffset_44;

		// Token: 0x0401A021 RID: 106529
		internal static int __PropertyOffset_45;

		// Token: 0x0401A022 RID: 106530
		internal static int __PropertyOffset_46;

		// Token: 0x0401A023 RID: 106531
		internal static int __PropertyOffset_47;

		// Token: 0x0401A024 RID: 106532
		internal static int __PropertyOffset_48;

		// Token: 0x0401A025 RID: 106533
		internal static int __PropertyOffset_49;

		// Token: 0x0401A026 RID: 106534
		internal static int __PropertyOffset_50;

		// Token: 0x0401A027 RID: 106535
		internal static int __PropertyOffset_51;

		// Token: 0x0401A028 RID: 106536
		internal static int __PropertyOffset_52;

		// Token: 0x0401A029 RID: 106537
		private static IntPtr __SetLightDirection_NativeFunctionPtr;

		// Token: 0x0401A02A RID: 106538
		private static IntPtr __EulerToForward_NativeFunctionPtr;

		// Token: 0x0401A02B RID: 106539
		private static IntPtr __SetPosByViewSize_NativeFunctionPtr;

		// Token: 0x0401A02C RID: 106540
		private static IntPtr __Reset_NativeFunctionPtr;

		// Token: 0x0401A02D RID: 106541
		private static IntPtr __InitKuroMaterialController_NativeFunctionPtr;

		// Token: 0x0401A02E RID: 106542
		private static IntPtr __End_NativeFunctionPtr;

		// Token: 0x0401A02F RID: 106543
		private static IntPtr __Start_NativeFunctionPtr;

		// Token: 0x0401A030 RID: 106544
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401A031 RID: 106545
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401A032 RID: 106546
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401A033 RID: 106547
		private static IntPtr __ExecuteUbergraph_BP_SplitScreen_New_NativeFunctionPtr;

		// Token: 0x0200A607 RID: 42503
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __SetLightDirection_FunctionParams
		{
			// Token: 0x040335C6 RID: 210374
			[FieldOffset(0)]
			public IntPtr Mesh;

			// Token: 0x040335C7 RID: 210375
			[FieldOffset(8)]
			public float LightYaw;

			// Token: 0x040335C8 RID: 210376
			[FieldOffset(12)]
			public float FaceLightYaw;
		}

		// Token: 0x0200A608 RID: 42504
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 20)]
		protected ref struct __EulerToForward_FunctionParams
		{
			// Token: 0x040335C9 RID: 210377
			[FieldOffset(0)]
			public float Pitch;

			// Token: 0x040335CA RID: 210378
			[FieldOffset(4)]
			public float Yaw;

			// Token: 0x040335CB RID: 210379
			[FieldOffset(8)]
			public FVector __Result;
		}

		// Token: 0x0200A609 RID: 42505
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 344)]
		protected ref struct __InitKuroMaterialController_FunctionParams
		{
			// Token: 0x040335CC RID: 210380
			[FieldOffset(0)]
			public IntPtr KuroMaterialControllerComponent;

			// Token: 0x040335CD RID: 210381
			[FieldOffset(8)]
			public IntPtr CharacterActorComponent;

			// Token: 0x040335CE RID: 210382
			[FieldOffset(16)]
			public IntPtr PointLightComponent;

			// Token: 0x040335CF RID: 210383
			[FieldOffset(24)]
			public FVector PointLight_Location;

			// Token: 0x040335D0 RID: 210384
			[FieldOffset(36)]
			public FLinearColor PointLight_ToonLightColor;

			// Token: 0x040335D1 RID: 210385
			[FieldOffset(52)]
			public FLinearColor EyeLightSimulation_TongKong;

			// Token: 0x040335D2 RID: 210386
			[FieldOffset(68)]
			public FLinearColor EyeLightSimulation_YanBai;

			// Token: 0x040335D3 RID: 210387
			[FieldOffset(84)]
			public FLinearColor EyeLightSimulation_Color;

			// Token: 0x040335D4 RID: 210388
			[FieldOffset(100)]
			public float E_LinkPos;

			// Token: 0x040335D5 RID: 210389
			[FieldOffset(104)]
			public bool Channel0;

			// Token: 0x040335D6 RID: 210390
			[FieldOffset(105)]
			public bool Channel1;

			// Token: 0x040335D7 RID: 210391
			[FieldOffset(106)]
			public bool Channel2;

			// Token: 0x040335D8 RID: 210392
			[FieldOffset(108)]
			public float LightYaw;

			// Token: 0x040335D9 RID: 210393
			[FieldOffset(112)]
			public float FaceLightYaw;

			// Token: 0x040335DA RID: 210394
			[FieldOffset(116)]
			public int RoleId;

			// Token: 0x040335DB RID: 210395
			[FieldOffset(120)]
			public int returnHandle;
		}

		// Token: 0x0200A60A RID: 42506
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040335DC RID: 210396
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A60B RID: 42507
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040335DD RID: 210397
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A60C RID: 42508
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 128)]
		protected ref struct __ExecuteUbergraph_BP_SplitScreen_New_FunctionParams
		{
			// Token: 0x040335DE RID: 210398
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
