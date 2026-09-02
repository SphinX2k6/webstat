using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003AA4 RID: 15012
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricLightMonitor.BP_VolumetricLightMonitor_C")]
	[UnrealStructLayout(1552, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1552)]
	public class BP_VolumetricLightMonitor_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601FDBB RID: 130491 RVA: 0x0091C20C File Offset: 0x0091A40C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VolumetricLightMonitor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricLightMonitor.BP_VolumetricLightMonitor_C");
			}
			return BP_VolumetricLightMonitor_C._ClassPtr;
		}

		// Token: 0x0601FDBC RID: 130492 RVA: 0x0091C230 File Offset: 0x0091A430
		public BP_VolumetricLightMonitor_C() : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricLightMonitor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601FDBD RID: 130493 RVA: 0x0091C258 File Offset: 0x0091A458
		[NullableContext(1)]
		public BP_VolumetricLightMonitor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricLightMonitor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003281 RID: 12929
		// (get) Token: 0x0601FDBE RID: 130494 RVA: 0x0091C28C File Offset: 0x0091A48C
		// (set) Token: 0x0601FDBF RID: 130495 RVA: 0x0091C2C5 File Offset: 0x0091A4C5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003282 RID: 12930
		// (get) Token: 0x0601FDC0 RID: 130496 RVA: 0x0091C2E6 File Offset: 0x0091A4E6
		// (set) Token: 0x0601FDC1 RID: 130497 RVA: 0x0091C2FA File Offset: 0x0091A4FA
		public unsafe UBillboardComponent Billboard
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLightMonitor_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLightMonitor_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003283 RID: 12931
		// (get) Token: 0x0601FDC2 RID: 130498 RVA: 0x0091C30F File Offset: 0x0091A50F
		// (set) Token: 0x0601FDC3 RID: 130499 RVA: 0x0091C323 File Offset: 0x0091A523
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLightMonitor_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLightMonitor_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003284 RID: 12932
		// (get) Token: 0x0601FDC4 RID: 130500 RVA: 0x0091C338 File Offset: 0x0091A538
		// (set) Token: 0x0601FDC5 RID: 130501 RVA: 0x0091C34C File Offset: 0x0091A54C
		public unsafe UStaticMesh StaticMeshCone
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLightMonitor_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLightMonitor_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003285 RID: 12933
		// (get) Token: 0x0601FDC6 RID: 130502 RVA: 0x0091C361 File Offset: 0x0091A561
		// (set) Token: 0x0601FDC7 RID: 130503 RVA: 0x0091C375 File Offset: 0x0091A575
		public unsafe UMaterialInstance MaterialInstanceB
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLightMonitor_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLightMonitor_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003286 RID: 12934
		// (get) Token: 0x0601FDC8 RID: 130504 RVA: 0x0091C38A File Offset: 0x0091A58A
		// (set) Token: 0x0601FDC9 RID: 130505 RVA: 0x0091C39E File Offset: 0x0091A59E
		public unsafe UMaterialInstance MaterialInstanceBT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLightMonitor_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLightMonitor_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003287 RID: 12935
		// (get) Token: 0x0601FDCA RID: 130506 RVA: 0x0091C3B3 File Offset: 0x0091A5B3
		// (set) Token: 0x0601FDCB RID: 130507 RVA: 0x0091C3C3 File Offset: 0x0091A5C3
		public unsafe bool EnableBottomColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003288 RID: 12936
		// (get) Token: 0x0601FDCC RID: 130508 RVA: 0x0091C3D4 File Offset: 0x0091A5D4
		// (set) Token: 0x0601FDCD RID: 130509 RVA: 0x0091C3E4 File Offset: 0x0091A5E4
		public unsafe bool IsWholeDay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003289 RID: 12937
		// (get) Token: 0x0601FDCE RID: 130510 RVA: 0x0091C3F5 File Offset: 0x0091A5F5
		// (set) Token: 0x0601FDCF RID: 130511 RVA: 0x0091C405 File Offset: 0x0091A605
		public unsafe bool EnableFlickent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700328A RID: 12938
		// (get) Token: 0x0601FDD0 RID: 130512 RVA: 0x0091C416 File Offset: 0x0091A616
		// (set) Token: 0x0601FDD1 RID: 130513 RVA: 0x0091C426 File Offset: 0x0091A626
		public unsafe float ConeSin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700328B RID: 12939
		// (get) Token: 0x0601FDD2 RID: 130514 RVA: 0x0091C437 File Offset: 0x0091A637
		// (set) Token: 0x0601FDD3 RID: 130515 RVA: 0x0091C447 File Offset: 0x0091A647
		public unsafe float RadFallOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700328C RID: 12940
		// (get) Token: 0x0601FDD4 RID: 130516 RVA: 0x0091C458 File Offset: 0x0091A658
		// (set) Token: 0x0601FDD5 RID: 130517 RVA: 0x0091C468 File Offset: 0x0091A668
		public unsafe float TopClip
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x1700328D RID: 12941
		// (get) Token: 0x0601FDD6 RID: 130518 RVA: 0x0091C479 File Offset: 0x0091A679
		// (set) Token: 0x0601FDD7 RID: 130519 RVA: 0x0091C489 File Offset: 0x0091A689
		public unsafe float TopColorLerp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x1700328E RID: 12942
		// (get) Token: 0x0601FDD8 RID: 130520 RVA: 0x0091C49A File Offset: 0x0091A69A
		// (set) Token: 0x0601FDD9 RID: 130521 RVA: 0x0091C4AE File Offset: 0x0091A6AE
		public unsafe FLinearColor TopColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x1700328F RID: 12943
		// (get) Token: 0x0601FDDA RID: 130522 RVA: 0x0091C4C3 File Offset: 0x0091A6C3
		// (set) Token: 0x0601FDDB RID: 130523 RVA: 0x0091C4D7 File Offset: 0x0091A6D7
		public unsafe FLinearColor BottomColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17003290 RID: 12944
		// (get) Token: 0x0601FDDC RID: 130524 RVA: 0x0091C4EC File Offset: 0x0091A6EC
		// (set) Token: 0x0601FDDD RID: 130525 RVA: 0x0091C4FC File Offset: 0x0091A6FC
		public unsafe float SkyLightInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17003291 RID: 12945
		// (get) Token: 0x0601FDDE RID: 130526 RVA: 0x0091C50D File Offset: 0x0091A70D
		// (set) Token: 0x0601FDDF RID: 130527 RVA: 0x0091C51D File Offset: 0x0091A71D
		public unsafe float SkyLightOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17003292 RID: 12946
		// (get) Token: 0x0601FDE0 RID: 130528 RVA: 0x0091C52E File Offset: 0x0091A72E
		// (set) Token: 0x0601FDE1 RID: 130529 RVA: 0x0091C53E File Offset: 0x0091A73E
		public unsafe float BrightLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17003293 RID: 12947
		// (get) Token: 0x0601FDE2 RID: 130530 RVA: 0x0091C54F File Offset: 0x0091A74F
		// (set) Token: 0x0601FDE3 RID: 130531 RVA: 0x0091C55F File Offset: 0x0091A75F
		public unsafe float FlickerTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17003294 RID: 12948
		// (get) Token: 0x0601FDE4 RID: 130532 RVA: 0x0091C570 File Offset: 0x0091A770
		// (set) Token: 0x0601FDE5 RID: 130533 RVA: 0x0091C580 File Offset: 0x0091A780
		public unsafe float DepthFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17003295 RID: 12949
		// (get) Token: 0x0601FDE6 RID: 130534 RVA: 0x0091C591 File Offset: 0x0091A791
		// (set) Token: 0x0601FDE7 RID: 130535 RVA: 0x0091C5A1 File Offset: 0x0091A7A1
		public unsafe float ViewTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17003296 RID: 12950
		// (get) Token: 0x0601FDE8 RID: 130536 RVA: 0x0091C5B2 File Offset: 0x0091A7B2
		// (set) Token: 0x0601FDE9 RID: 130537 RVA: 0x0091C5C2 File Offset: 0x0091A7C2
		public unsafe float LightStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17003297 RID: 12951
		// (get) Token: 0x0601FDEA RID: 130538 RVA: 0x0091C5D3 File Offset: 0x0091A7D3
		// (set) Token: 0x0601FDEB RID: 130539 RVA: 0x0091C5E3 File Offset: 0x0091A7E3
		public unsafe float NearFadeStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17003298 RID: 12952
		// (get) Token: 0x0601FDEC RID: 130540 RVA: 0x0091C5F4 File Offset: 0x0091A7F4
		// (set) Token: 0x0601FDED RID: 130541 RVA: 0x0091C604 File Offset: 0x0091A804
		public unsafe float FullIntLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17003299 RID: 12953
		// (get) Token: 0x0601FDEE RID: 130542 RVA: 0x0091C615 File Offset: 0x0091A815
		// (set) Token: 0x0601FDEF RID: 130543 RVA: 0x0091C625 File Offset: 0x0091A825
		public unsafe float FarFadeLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x1700329A RID: 12954
		// (get) Token: 0x0601FDF0 RID: 130544 RVA: 0x0091C636 File Offset: 0x0091A836
		// (set) Token: 0x0601FDF1 RID: 130545 RVA: 0x0091C64A File Offset: 0x0091A84A
		public unsafe UMaterialInstanceDynamic DynamicVolumetricShaftMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLightMonitor_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLightMonitor_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x1700329B RID: 12955
		// (get) Token: 0x0601FDF2 RID: 130546 RVA: 0x0091C65F File Offset: 0x0091A85F
		// (set) Token: 0x0601FDF3 RID: 130547 RVA: 0x0091C673 File Offset: 0x0091A873
		public unsafe UMaterialInstance DecalLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLightMonitor_C.__PropertyOffset_26);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLightMonitor_C.__PropertyOffset_26, value);
			}
		}

		// Token: 0x1700329C RID: 12956
		// (get) Token: 0x0601FDF4 RID: 130548 RVA: 0x0091C688 File Offset: 0x0091A888
		// (set) Token: 0x0601FDF5 RID: 130549 RVA: 0x0091C698 File Offset: 0x0091A898
		public unsafe float LightDecalZoFFSET
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x1700329D RID: 12957
		// (get) Token: 0x0601FDF6 RID: 130550 RVA: 0x0091C6A9 File Offset: 0x0091A8A9
		// (set) Token: 0x0601FDF7 RID: 130551 RVA: 0x0091C6B9 File Offset: 0x0091A8B9
		public unsafe float DecalHigh
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x1700329E RID: 12958
		// (get) Token: 0x0601FDF8 RID: 130552 RVA: 0x0091C6CA File Offset: 0x0091A8CA
		// (set) Token: 0x0601FDF9 RID: 130553 RVA: 0x0091C6DA File Offset: 0x0091A8DA
		public unsafe float Radius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x1700329F RID: 12959
		// (get) Token: 0x0601FDFA RID: 130554 RVA: 0x0091C6EB File Offset: 0x0091A8EB
		// (set) Token: 0x0601FDFB RID: 130555 RVA: 0x0091C6FB File Offset: 0x0091A8FB
		public unsafe float InSideInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x170032A0 RID: 12960
		// (get) Token: 0x0601FDFC RID: 130556 RVA: 0x0091C70C File Offset: 0x0091A90C
		// (set) Token: 0x0601FDFD RID: 130557 RVA: 0x0091C720 File Offset: 0x0091A920
		public unsafe FLinearColor InSideColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x170032A1 RID: 12961
		// (get) Token: 0x0601FDFE RID: 130558 RVA: 0x0091C735 File Offset: 0x0091A935
		// (set) Token: 0x0601FDFF RID: 130559 RVA: 0x0091C745 File Offset: 0x0091A945
		public unsafe float OutSideInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x170032A2 RID: 12962
		// (get) Token: 0x0601FE00 RID: 130560 RVA: 0x0091C756 File Offset: 0x0091A956
		// (set) Token: 0x0601FE01 RID: 130561 RVA: 0x0091C76A File Offset: 0x0091A96A
		public unsafe FLinearColor OutSideColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightMonitor_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x170032A3 RID: 12963
		// (get) Token: 0x0601FE02 RID: 130562 RVA: 0x0091C77F File Offset: 0x0091A97F
		// (set) Token: 0x0601FE03 RID: 130563 RVA: 0x0091C793 File Offset: 0x0091A993
		public unsafe UMaterialInstanceDynamic DynamicDecalMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLightMonitor_C.__PropertyOffset_34);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLightMonitor_C.__PropertyOffset_34, value);
			}
		}

		// Token: 0x170032A4 RID: 12964
		// (get) Token: 0x0601FE04 RID: 130564 RVA: 0x0091C7A8 File Offset: 0x0091A9A8
		// (set) Token: 0x0601FE05 RID: 130565 RVA: 0x0091C7BC File Offset: 0x0091A9BC
		public unsafe UDecalComponent decalcomponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDecalComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLightMonitor_C.__PropertyOffset_35);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLightMonitor_C.__PropertyOffset_35, value);
			}
		}

		// Token: 0x0601FE06 RID: 130566 RVA: 0x0091C7D1 File Offset: 0x0091A9D1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricLightMonitor_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601FE07 RID: 130567 RVA: 0x0091C7E5 File Offset: 0x0091A9E5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricLightMonitor_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FE08 RID: 130568 RVA: 0x0091C7FC File Offset: 0x0091A9FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_VolumetricLightMonitor_C.__EditorTick_FunctionParams* ptr = stackalloc BP_VolumetricLightMonitor_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricLightMonitor_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricLightMonitor_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricLightMonitor_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FE09 RID: 130569 RVA: 0x0091C844 File Offset: 0x0091AA44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_VolumetricLightMonitor_C.__EditorTick_FunctionParams* ptr = stackalloc BP_VolumetricLightMonitor_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricLightMonitor_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricLightMonitor_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricLightMonitor_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FE0A RID: 130570 RVA: 0x0091C88C File Offset: 0x0091AA8C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_VolumetricLightMonitor_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VolumetricLightMonitor_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricLightMonitor_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricLightMonitor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricLightMonitor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FE0B RID: 130571 RVA: 0x0091C8D4 File Offset: 0x0091AAD4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_VolumetricLightMonitor_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VolumetricLightMonitor_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricLightMonitor_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricLightMonitor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricLightMonitor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FE0C RID: 130572 RVA: 0x0091C91C File Offset: 0x0091AB1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_VolumetricLightMonitor(int EntryPoint)
		{
			BP_VolumetricLightMonitor_C.__ExecuteUbergraph_BP_VolumetricLightMonitor_FunctionParams* ptr = stackalloc BP_VolumetricLightMonitor_C.__ExecuteUbergraph_BP_VolumetricLightMonitor_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_VolumetricLightMonitor_C.__ExecuteUbergraph_BP_VolumetricLightMonitor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricLightMonitor_C.__ExecuteUbergraph_BP_VolumetricLightMonitor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricLightMonitor_C.__ExecuteUbergraph_BP_VolumetricLightMonitor_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FE0D RID: 130573 RVA: 0x0091C963 File Offset: 0x0091AB63
		protected BP_VolumetricLightMonitor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FDB3 RID: 64947
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricLightMonitor.BP_VolumetricLightMonitor_C";

		// Token: 0x0400FDB4 RID: 64948
		private static IntPtr _ClassPtr;

		// Token: 0x0400FDB5 RID: 64949
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FDB6 RID: 64950
		internal static int __PropertyOffset_0;

		// Token: 0x0400FDB7 RID: 64951
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FDB8 RID: 64952
		internal static int __PropertyOffset_1;

		// Token: 0x0400FDB9 RID: 64953
		internal static int __PropertyOffset_2;

		// Token: 0x0400FDBA RID: 64954
		internal static int __PropertyOffset_3;

		// Token: 0x0400FDBB RID: 64955
		internal static int __PropertyOffset_4;

		// Token: 0x0400FDBC RID: 64956
		internal static int __PropertyOffset_5;

		// Token: 0x0400FDBD RID: 64957
		internal static int __PropertyOffset_6;

		// Token: 0x0400FDBE RID: 64958
		internal static int __PropertyOffset_7;

		// Token: 0x0400FDBF RID: 64959
		internal static int __PropertyOffset_8;

		// Token: 0x0400FDC0 RID: 64960
		internal static int __PropertyOffset_9;

		// Token: 0x0400FDC1 RID: 64961
		internal static int __PropertyOffset_10;

		// Token: 0x0400FDC2 RID: 64962
		internal static int __PropertyOffset_11;

		// Token: 0x0400FDC3 RID: 64963
		internal static int __PropertyOffset_12;

		// Token: 0x0400FDC4 RID: 64964
		internal static int __PropertyOffset_13;

		// Token: 0x0400FDC5 RID: 64965
		internal static int __PropertyOffset_14;

		// Token: 0x0400FDC6 RID: 64966
		internal static int __PropertyOffset_15;

		// Token: 0x0400FDC7 RID: 64967
		internal static int __PropertyOffset_16;

		// Token: 0x0400FDC8 RID: 64968
		internal static int __PropertyOffset_17;

		// Token: 0x0400FDC9 RID: 64969
		internal static int __PropertyOffset_18;

		// Token: 0x0400FDCA RID: 64970
		internal static int __PropertyOffset_19;

		// Token: 0x0400FDCB RID: 64971
		internal static int __PropertyOffset_20;

		// Token: 0x0400FDCC RID: 64972
		internal static int __PropertyOffset_21;

		// Token: 0x0400FDCD RID: 64973
		internal static int __PropertyOffset_22;

		// Token: 0x0400FDCE RID: 64974
		internal static int __PropertyOffset_23;

		// Token: 0x0400FDCF RID: 64975
		internal static int __PropertyOffset_24;

		// Token: 0x0400FDD0 RID: 64976
		internal static int __PropertyOffset_25;

		// Token: 0x0400FDD1 RID: 64977
		internal static int __PropertyOffset_26;

		// Token: 0x0400FDD2 RID: 64978
		internal static int __PropertyOffset_27;

		// Token: 0x0400FDD3 RID: 64979
		internal static int __PropertyOffset_28;

		// Token: 0x0400FDD4 RID: 64980
		internal static int __PropertyOffset_29;

		// Token: 0x0400FDD5 RID: 64981
		internal static int __PropertyOffset_30;

		// Token: 0x0400FDD6 RID: 64982
		internal static int __PropertyOffset_31;

		// Token: 0x0400FDD7 RID: 64983
		internal static int __PropertyOffset_32;

		// Token: 0x0400FDD8 RID: 64984
		internal static int __PropertyOffset_33;

		// Token: 0x0400FDD9 RID: 64985
		internal static int __PropertyOffset_34;

		// Token: 0x0400FDDA RID: 64986
		internal static int __PropertyOffset_35;

		// Token: 0x0400FDDB RID: 64987
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FDDC RID: 64988
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400FDDD RID: 64989
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FDDE RID: 64990
		private static IntPtr __ExecuteUbergraph_BP_VolumetricLightMonitor_NativeFunctionPtr;

		// Token: 0x0200992F RID: 39215
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031F8E RID: 204686
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009930 RID: 39216
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F8F RID: 204687
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009931 RID: 39217
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_VolumetricLightMonitor_FunctionParams
		{
			// Token: 0x04031F90 RID: 204688
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
