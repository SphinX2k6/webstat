using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.PCG.Physics_Actor;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.SwingInteraction
{
	// Token: 0x02003A44 RID: 14916
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/SwingInteraction/BP_SwingLightpipe.BP_SwingLightpipe_C")]
	[UnrealStructLayout(1680, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1676)]
	public class BP_SwingLightpipe_C : BP_PhysicsActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EDB1 RID: 126385 RVA: 0x00900434 File Offset: 0x008FE634
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SwingLightpipe_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/SwingInteraction/BP_SwingLightpipe.BP_SwingLightpipe_C");
			}
			return BP_SwingLightpipe_C._ClassPtr;
		}

		// Token: 0x0601EDB2 RID: 126386 RVA: 0x00900458 File Offset: 0x008FE658
		public BP_SwingLightpipe_C() : this(BuiltinUtils.AllocNativeUObject(BP_SwingLightpipe_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EDB3 RID: 126387 RVA: 0x00900480 File Offset: 0x008FE680
		[NullableContext(1)]
		public BP_SwingLightpipe_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SwingLightpipe_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002CD1 RID: 11473
		// (get) Token: 0x0601EDB4 RID: 126388 RVA: 0x009004B4 File Offset: 0x008FE6B4
		// (set) Token: 0x0601EDB5 RID: 126389 RVA: 0x009004ED File Offset: 0x008FE6ED
		[Nullable(1)]
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002CD2 RID: 11474
		// (get) Token: 0x0601EDB6 RID: 126390 RVA: 0x0090050E File Offset: 0x008FE70E
		// (set) Token: 0x0601EDB7 RID: 126391 RVA: 0x00900522 File Offset: 0x008FE722
		public unsafe UStaticMeshComponent SM_Ins_Lig_02AS
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingLightpipe_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingLightpipe_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002CD3 RID: 11475
		// (get) Token: 0x0601EDB8 RID: 126392 RVA: 0x00900537 File Offset: 0x008FE737
		// (set) Token: 0x0601EDB9 RID: 126393 RVA: 0x0090054B File Offset: 0x008FE74B
		public unsafe UStaticMeshComponent StaticMeshOri
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingLightpipe_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingLightpipe_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002CD4 RID: 11476
		// (get) Token: 0x0601EDBA RID: 126394 RVA: 0x00900560 File Offset: 0x008FE760
		// (set) Token: 0x0601EDBB RID: 126395 RVA: 0x00900574 File Offset: 0x008FE774
		public unsafe UStaticMeshComponent SM_SwingSingleRopeR
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingLightpipe_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingLightpipe_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002CD5 RID: 11477
		// (get) Token: 0x0601EDBC RID: 126396 RVA: 0x00900589 File Offset: 0x008FE789
		// (set) Token: 0x0601EDBD RID: 126397 RVA: 0x0090059D File Offset: 0x008FE79D
		public unsafe UStaticMeshComponent SM_SwingSingleRopeL
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingLightpipe_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingLightpipe_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002CD6 RID: 11478
		// (get) Token: 0x0601EDBE RID: 126398 RVA: 0x009005B2 File Offset: 0x008FE7B2
		// (set) Token: 0x0601EDBF RID: 126399 RVA: 0x009005C6 File Offset: 0x008FE7C6
		public unsafe UStaticMeshComponent SM_SwingTop
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingLightpipe_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingLightpipe_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17002CD7 RID: 11479
		// (get) Token: 0x0601EDC0 RID: 126400 RVA: 0x009005DB File Offset: 0x008FE7DB
		// (set) Token: 0x0601EDC1 RID: 126401 RVA: 0x009005EF File Offset: 0x008FE7EF
		public unsafe UStaticMeshComponent StaticMesh_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingLightpipe_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingLightpipe_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17002CD8 RID: 11480
		// (get) Token: 0x0601EDC2 RID: 126402 RVA: 0x00900604 File Offset: 0x008FE804
		// (set) Token: 0x0601EDC3 RID: 126403 RVA: 0x00900614 File Offset: 0x008FE814
		public unsafe bool debugDraw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002CD9 RID: 11481
		// (get) Token: 0x0601EDC4 RID: 126404 RVA: 0x00900625 File Offset: 0x008FE825
		// (set) Token: 0x0601EDC5 RID: 126405 RVA: 0x00900635 File Offset: 0x008FE835
		public unsafe bool bUseConstantDt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002CDA RID: 11482
		// (get) Token: 0x0601EDC6 RID: 126406 RVA: 0x00900646 File Offset: 0x008FE846
		// (set) Token: 0x0601EDC7 RID: 126407 RVA: 0x00900656 File Offset: 0x008FE856
		public unsafe float Pipelength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002CDB RID: 11483
		// (get) Token: 0x0601EDC8 RID: 126408 RVA: 0x00900667 File Offset: 0x008FE867
		// (set) Token: 0x0601EDC9 RID: 126409 RVA: 0x00900677 File Offset: 0x008FE877
		public unsafe float FakeWireLengthMulti
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002CDC RID: 11484
		// (get) Token: 0x0601EDCA RID: 126410 RVA: 0x00900688 File Offset: 0x008FE888
		// (set) Token: 0x0601EDCB RID: 126411 RVA: 0x00900698 File Offset: 0x008FE898
		public unsafe float ConstantDt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17002CDD RID: 11485
		// (get) Token: 0x0601EDCC RID: 126412 RVA: 0x009006A9 File Offset: 0x008FE8A9
		// (set) Token: 0x0601EDCD RID: 126413 RVA: 0x009006B9 File Offset: 0x008FE8B9
		public unsafe float GroundHeightOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17002CDE RID: 11486
		// (get) Token: 0x0601EDCE RID: 126414 RVA: 0x009006CA File Offset: 0x008FE8CA
		// (set) Token: 0x0601EDCF RID: 126415 RVA: 0x009006DE File Offset: 0x008FE8DE
		public unsafe FVector LeftPosOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17002CDF RID: 11487
		// (get) Token: 0x0601EDD0 RID: 126416 RVA: 0x009006F3 File Offset: 0x008FE8F3
		// (set) Token: 0x0601EDD1 RID: 126417 RVA: 0x00900707 File Offset: 0x008FE907
		public unsafe FVector StartOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17002CE0 RID: 11488
		// (get) Token: 0x0601EDD2 RID: 126418 RVA: 0x0090071C File Offset: 0x008FE91C
		// (set) Token: 0x0601EDD3 RID: 126419 RVA: 0x00900730 File Offset: 0x008FE930
		public unsafe FVector RuntimeOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17002CE1 RID: 11489
		// (get) Token: 0x0601EDD4 RID: 126420 RVA: 0x00900745 File Offset: 0x008FE945
		// (set) Token: 0x0601EDD5 RID: 126421 RVA: 0x00900755 File Offset: 0x008FE955
		public unsafe int particleCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17002CE2 RID: 11490
		// (get) Token: 0x0601EDD6 RID: 126422 RVA: 0x00900766 File Offset: 0x008FE966
		// (set) Token: 0x0601EDD7 RID: 126423 RVA: 0x00900776 File Offset: 0x008FE976
		public unsafe float linkDis
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17002CE3 RID: 11491
		// (get) Token: 0x0601EDD8 RID: 126424 RVA: 0x00900787 File Offset: 0x008FE987
		// (set) Token: 0x0601EDD9 RID: 126425 RVA: 0x0090079B File Offset: 0x008FE99B
		public unsafe FVector accel_ext
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17002CE4 RID: 11492
		// (get) Token: 0x0601EDDA RID: 126426 RVA: 0x009007B0 File Offset: 0x008FE9B0
		// (set) Token: 0x0601EDDB RID: 126427 RVA: 0x009007C0 File Offset: 0x008FE9C0
		public unsafe float collisionR
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17002CE5 RID: 11493
		// (get) Token: 0x0601EDDC RID: 126428 RVA: 0x009007D1 File Offset: 0x008FE9D1
		// (set) Token: 0x0601EDDD RID: 126429 RVA: 0x009007E1 File Offset: 0x008FE9E1
		public unsafe float volDamping
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17002CE6 RID: 11494
		// (get) Token: 0x0601EDDE RID: 126430 RVA: 0x009007F2 File Offset: 0x008FE9F2
		// (set) Token: 0x0601EDDF RID: 126431 RVA: 0x00900806 File Offset: 0x008FEA06
		public unsafe FVector startPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17002CE7 RID: 11495
		// (get) Token: 0x0601EDE0 RID: 126432 RVA: 0x0090081B File Offset: 0x008FEA1B
		// (set) Token: 0x0601EDE1 RID: 126433 RVA: 0x0090082F File Offset: 0x008FEA2F
		public unsafe FVector endPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17002CE8 RID: 11496
		// (get) Token: 0x0601EDE2 RID: 126434 RVA: 0x00900844 File Offset: 0x008FEA44
		// (set) Token: 0x0601EDE3 RID: 126435 RVA: 0x0090087D File Offset: 0x008FEA7D
		[Nullable(1)]
		public TArray<FName> NameList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._NameList) == null)
				{
					result = (this._NameList = new TArray<FName>(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_23, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.NameList.CopyAssign(value);
			}
		}

		// Token: 0x17002CE9 RID: 11497
		// (get) Token: 0x0601EDE4 RID: 126436 RVA: 0x0090088B File Offset: 0x008FEA8B
		// (set) Token: 0x0601EDE5 RID: 126437 RVA: 0x0090089F File Offset: 0x008FEA9F
		public unsafe FVector leftPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17002CEA RID: 11498
		// (get) Token: 0x0601EDE6 RID: 126438 RVA: 0x009008B4 File Offset: 0x008FEAB4
		// (set) Token: 0x0601EDE7 RID: 126439 RVA: 0x009008C8 File Offset: 0x008FEAC8
		public unsafe FVector rightPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17002CEB RID: 11499
		// (get) Token: 0x0601EDE8 RID: 126440 RVA: 0x009008DD File Offset: 0x008FEADD
		// (set) Token: 0x0601EDE9 RID: 126441 RVA: 0x009008F1 File Offset: 0x008FEAF1
		public unsafe FVector leftNorm
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17002CEC RID: 11500
		// (get) Token: 0x0601EDEA RID: 126442 RVA: 0x00900908 File Offset: 0x008FEB08
		// (set) Token: 0x0601EDEB RID: 126443 RVA: 0x00900941 File Offset: 0x008FEB41
		[Nullable(1)]
		public TArray<FParticle_QiuQian> particleArr
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FParticle_QiuQian> result;
				if ((result = this._particleArr) == null)
				{
					result = (this._particleArr = new TArray<FParticle_QiuQian>(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_27, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.particleArr.CopyAssign(value);
			}
		}

		// Token: 0x17002CED RID: 11501
		// (get) Token: 0x0601EDEC RID: 126444 RVA: 0x0090094F File Offset: 0x008FEB4F
		// (set) Token: 0x0601EDED RID: 126445 RVA: 0x00900963 File Offset: 0x008FEB63
		public unsafe FVector rightNorm
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17002CEE RID: 11502
		// (get) Token: 0x0601EDEE RID: 126446 RVA: 0x00900978 File Offset: 0x008FEB78
		// (set) Token: 0x0601EDEF RID: 126447 RVA: 0x00900988 File Offset: 0x008FEB88
		public unsafe float pushStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17002CEF RID: 11503
		// (get) Token: 0x0601EDF0 RID: 126448 RVA: 0x00900999 File Offset: 0x008FEB99
		// (set) Token: 0x0601EDF1 RID: 126449 RVA: 0x009009A9 File Offset: 0x008FEBA9
		public unsafe float endParticleMassScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17002CF0 RID: 11504
		// (get) Token: 0x0601EDF2 RID: 126450 RVA: 0x009009BA File Offset: 0x008FEBBA
		// (set) Token: 0x0601EDF3 RID: 126451 RVA: 0x009009CA File Offset: 0x008FEBCA
		public unsafe float debugDrawDuration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17002CF1 RID: 11505
		// (get) Token: 0x0601EDF4 RID: 126452 RVA: 0x009009DC File Offset: 0x008FEBDC
		// (set) Token: 0x0601EDF5 RID: 126453 RVA: 0x00900A15 File Offset: 0x008FEC15
		[Nullable(1)]
		public TArray<USplineMeshComponent> SplineMesh
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<USplineMeshComponent> result;
				if ((result = this._SplineMesh) == null)
				{
					result = (this._SplineMesh = new TArray<USplineMeshComponent>(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_32, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SplineMesh.CopyAssign(value);
			}
		}

		// Token: 0x17002CF2 RID: 11506
		// (get) Token: 0x0601EDF6 RID: 126454 RVA: 0x00900A24 File Offset: 0x008FEC24
		// (set) Token: 0x0601EDF7 RID: 126455 RVA: 0x00900A5D File Offset: 0x008FEC5D
		[Nullable(1)]
		public TArray<USplineMeshComponent> SplineMeshR
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<USplineMeshComponent> result;
				if ((result = this._SplineMeshR) == null)
				{
					result = (this._SplineMeshR = new TArray<USplineMeshComponent>(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_33, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SplineMeshR.CopyAssign(value);
			}
		}

		// Token: 0x17002CF3 RID: 11507
		// (get) Token: 0x0601EDF8 RID: 126456 RVA: 0x00900A6B File Offset: 0x008FEC6B
		// (set) Token: 0x0601EDF9 RID: 126457 RVA: 0x00900A7B File Offset: 0x008FEC7B
		public unsafe bool IsEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_34) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_34) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002CF4 RID: 11508
		// (get) Token: 0x0601EDFA RID: 126458 RVA: 0x00900A8C File Offset: 0x008FEC8C
		// (set) Token: 0x0601EDFB RID: 126459 RVA: 0x00900A9C File Offset: 0x008FEC9C
		public unsafe bool IsPC
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_35) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_35) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002CF5 RID: 11509
		// (get) Token: 0x0601EDFC RID: 126460 RVA: 0x00900AAD File Offset: 0x008FECAD
		// (set) Token: 0x0601EDFD RID: 126461 RVA: 0x00900AC1 File Offset: 0x008FECC1
		public unsafe UMaterialInstanceDynamic DMI_RopeL
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingLightpipe_C.__PropertyOffset_36);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingLightpipe_C.__PropertyOffset_36, value);
			}
		}

		// Token: 0x17002CF6 RID: 11510
		// (get) Token: 0x0601EDFE RID: 126462 RVA: 0x00900AD6 File Offset: 0x008FECD6
		// (set) Token: 0x0601EDFF RID: 126463 RVA: 0x00900AEA File Offset: 0x008FECEA
		public unsafe UMaterialInstanceDynamic DMI_RopeR
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingLightpipe_C.__PropertyOffset_37);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingLightpipe_C.__PropertyOffset_37, value);
			}
		}

		// Token: 0x17002CF7 RID: 11511
		// (get) Token: 0x0601EE00 RID: 126464 RVA: 0x00900AFF File Offset: 0x008FECFF
		// (set) Token: 0x0601EE01 RID: 126465 RVA: 0x00900B0F File Offset: 0x008FED0F
		public unsafe float CurrentAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17002CF8 RID: 11512
		// (get) Token: 0x0601EE02 RID: 126466 RVA: 0x00900B20 File Offset: 0x008FED20
		// (set) Token: 0x0601EE03 RID: 126467 RVA: 0x00900B30 File Offset: 0x008FED30
		public unsafe float AngularVelocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17002CF9 RID: 11513
		// (get) Token: 0x0601EE04 RID: 126468 RVA: 0x00900B41 File Offset: 0x008FED41
		// (set) Token: 0x0601EE05 RID: 126469 RVA: 0x00900B51 File Offset: 0x008FED51
		public unsafe float TargetAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x17002CFA RID: 11514
		// (get) Token: 0x0601EE06 RID: 126470 RVA: 0x00900B62 File Offset: 0x008FED62
		// (set) Token: 0x0601EE07 RID: 126471 RVA: 0x00900B72 File Offset: 0x008FED72
		public unsafe float SpringK
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x17002CFB RID: 11515
		// (get) Token: 0x0601EE08 RID: 126472 RVA: 0x00900B83 File Offset: 0x008FED83
		// (set) Token: 0x0601EE09 RID: 126473 RVA: 0x00900B93 File Offset: 0x008FED93
		public unsafe float DampingC
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SwingLightpipe_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x0601EE0A RID: 126474 RVA: 0x00900BA4 File Offset: 0x008FEDA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitializeParticleArr()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SwingLightpipe_C.__InitializeParticleArr_NativeFunctionPtr, null);
		}

		// Token: 0x0601EE0B RID: 126475 RVA: 0x00900BB8 File Offset: 0x008FEDB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetDMIOffsetEnable(bool OffsetEnable)
		{
			BP_SwingLightpipe_C.__SetDMIOffsetEnable_FunctionParams* ptr = stackalloc BP_SwingLightpipe_C.__SetDMIOffsetEnable_FunctionParams[(UIntPtr)20] + 15L / (long)sizeof(BP_SwingLightpipe_C.__SetDMIOffsetEnable_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SwingLightpipe_C.__SetDMIOffsetEnable_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OffsetEnable = OffsetEnable;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SwingLightpipe_C.__SetDMIOffsetEnable_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EE0C RID: 126476 RVA: 0x00900BFE File Offset: 0x008FEDFE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateaDMI()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SwingLightpipe_C.__UpdateaDMI_NativeFunctionPtr, null);
		}

		// Token: 0x0601EE0D RID: 126477 RVA: 0x00900C12 File Offset: 0x008FEE12
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitializeDMI()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SwingLightpipe_C.__InitializeDMI_NativeFunctionPtr, null);
		}

		// Token: 0x0601EE0E RID: 126478 RVA: 0x00900C28 File Offset: 0x008FEE28
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void solve(bool isPinned, FVector pos, FVector linkPos, float targetLen, FVector emitterOriginPos, ref FVector pos_new)
		{
			BP_SwingLightpipe_C.__solve_FunctionParams* ptr = stackalloc BP_SwingLightpipe_C.__solve_FunctionParams[(UIntPtr)131] + 15L / (long)sizeof(BP_SwingLightpipe_C.__solve_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SwingLightpipe_C.__solve_NativeFunctionPtr, (void*)ptr, 1);
			ptr->isPinned = isPinned;
			ptr->pos = pos;
			ptr->linkPos = linkPos;
			ptr->targetLen = targetLen;
			ptr->emitterOriginPos = emitterOriginPos;
			ptr->pos_new = pos_new;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SwingLightpipe_C.__solve_NativeFunctionPtr, (void*)ptr);
			pos_new = ptr->pos_new;
		}

		// Token: 0x0601EE0F RID: 126479 RVA: 0x00900CA9 File Offset: 0x008FEEA9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SwingLightpipe_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601EE10 RID: 126480 RVA: 0x00900CBD File Offset: 0x008FEEBD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SwingLightpipe_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EE11 RID: 126481 RVA: 0x00900CD2 File Offset: 0x008FEED2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SwingLightpipe_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601EE12 RID: 126482 RVA: 0x00900CE6 File Offset: 0x008FEEE6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SwingLightpipe_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EE13 RID: 126483 RVA: 0x00900CFC File Offset: 0x008FEEFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SwingLightpipe_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SwingLightpipe_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SwingLightpipe_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SwingLightpipe_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SwingLightpipe_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EE14 RID: 126484 RVA: 0x00900D44 File Offset: 0x008FEF44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SwingLightpipe_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SwingLightpipe_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SwingLightpipe_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SwingLightpipe_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SwingLightpipe_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EE15 RID: 126485 RVA: 0x00900D8B File Offset: 0x008FEF8B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void place_plank_event()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SwingLightpipe_C.__place_plank_event_NativeFunctionPtr, null);
		}

		// Token: 0x0601EE16 RID: 126486 RVA: 0x00900D9F File Offset: 0x008FEF9F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicEnable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SwingLightpipe_C.__OnLogicEnable_NativeFunctionPtr, null);
		}

		// Token: 0x0601EE17 RID: 126487 RVA: 0x00900DB3 File Offset: 0x008FEFB3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void OnLogicEnable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SwingLightpipe_C.__OnLogicEnable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EE18 RID: 126488 RVA: 0x00900DC8 File Offset: 0x008FEFC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicDisable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SwingLightpipe_C.__OnLogicDisable_NativeFunctionPtr, null);
		}

		// Token: 0x0601EE19 RID: 126489 RVA: 0x00900DDC File Offset: 0x008FEFDC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void OnLogicDisable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SwingLightpipe_C.__OnLogicDisable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EE1A RID: 126490 RVA: 0x00900DF4 File Offset: 0x008FEFF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_SwingLightpipe_SM_Ins_Lig_02AS_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_SwingLightpipe_C.__BndEvt__BP_SwingLightpipe_SM_Ins_Lig_02AS_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_SwingLightpipe_C.__BndEvt__BP_SwingLightpipe_SM_Ins_Lig_02AS_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_SwingLightpipe_C.__BndEvt__BP_SwingLightpipe_SM_Ins_Lig_02AS_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SwingLightpipe_C.__BndEvt__BP_SwingLightpipe_SM_Ins_Lig_02AS_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SwingLightpipe_C.__BndEvt__BP_SwingLightpipe_SM_Ins_Lig_02AS_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EE1B RID: 126491 RVA: 0x00900EB0 File Offset: 0x008FF0B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_SwingLightpipe_SM_Ins_Lig_02AS_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapBlockSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_SwingLightpipe_C.__BndEvt__BP_SwingLightpipe_SM_Ins_Lig_02AS_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapBlockSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_SwingLightpipe_C.__BndEvt__BP_SwingLightpipe_SM_Ins_Lig_02AS_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapBlockSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_SwingLightpipe_C.__BndEvt__BP_SwingLightpipe_SM_Ins_Lig_02AS_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapBlockSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SwingLightpipe_C.__BndEvt__BP_SwingLightpipe_SM_Ins_Lig_02AS_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapBlockSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SwingLightpipe_C.__BndEvt__BP_SwingLightpipe_SM_Ins_Lig_02AS_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapBlockSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EE1C RID: 126492 RVA: 0x00900F6C File Offset: 0x008FF16C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SwingLightpipe(int EntryPoint)
		{
			BP_SwingLightpipe_C.__ExecuteUbergraph_BP_SwingLightpipe_FunctionParams* ptr = stackalloc BP_SwingLightpipe_C.__ExecuteUbergraph_BP_SwingLightpipe_FunctionParams[(UIntPtr)3215] + 15L / (long)sizeof(BP_SwingLightpipe_C.__ExecuteUbergraph_BP_SwingLightpipe_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SwingLightpipe_C.__ExecuteUbergraph_BP_SwingLightpipe_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SwingLightpipe_C.__ExecuteUbergraph_BP_SwingLightpipe_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EE1D RID: 126493 RVA: 0x00900FB6 File Offset: 0x008FF1B6
		protected BP_SwingLightpipe_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F3DE RID: 62430
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/SwingInteraction/BP_SwingLightpipe.BP_SwingLightpipe_C";

		// Token: 0x0400F3DF RID: 62431
		private static IntPtr _ClassPtr;

		// Token: 0x0400F3E0 RID: 62432
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F3E1 RID: 62433
		internal new static int __PropertyOffset_0;

		// Token: 0x0400F3E2 RID: 62434
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F3E3 RID: 62435
		internal new static int __PropertyOffset_1;

		// Token: 0x0400F3E4 RID: 62436
		internal static int __PropertyOffset_2;

		// Token: 0x0400F3E5 RID: 62437
		internal static int __PropertyOffset_3;

		// Token: 0x0400F3E6 RID: 62438
		internal static int __PropertyOffset_4;

		// Token: 0x0400F3E7 RID: 62439
		internal static int __PropertyOffset_5;

		// Token: 0x0400F3E8 RID: 62440
		internal static int __PropertyOffset_6;

		// Token: 0x0400F3E9 RID: 62441
		internal static int __PropertyOffset_7;

		// Token: 0x0400F3EA RID: 62442
		internal static int __PropertyOffset_8;

		// Token: 0x0400F3EB RID: 62443
		internal static int __PropertyOffset_9;

		// Token: 0x0400F3EC RID: 62444
		internal static int __PropertyOffset_10;

		// Token: 0x0400F3ED RID: 62445
		internal static int __PropertyOffset_11;

		// Token: 0x0400F3EE RID: 62446
		internal static int __PropertyOffset_12;

		// Token: 0x0400F3EF RID: 62447
		internal static int __PropertyOffset_13;

		// Token: 0x0400F3F0 RID: 62448
		internal static int __PropertyOffset_14;

		// Token: 0x0400F3F1 RID: 62449
		internal static int __PropertyOffset_15;

		// Token: 0x0400F3F2 RID: 62450
		internal static int __PropertyOffset_16;

		// Token: 0x0400F3F3 RID: 62451
		internal static int __PropertyOffset_17;

		// Token: 0x0400F3F4 RID: 62452
		internal static int __PropertyOffset_18;

		// Token: 0x0400F3F5 RID: 62453
		internal static int __PropertyOffset_19;

		// Token: 0x0400F3F6 RID: 62454
		internal static int __PropertyOffset_20;

		// Token: 0x0400F3F7 RID: 62455
		internal static int __PropertyOffset_21;

		// Token: 0x0400F3F8 RID: 62456
		internal static int __PropertyOffset_22;

		// Token: 0x0400F3F9 RID: 62457
		internal static int __PropertyOffset_23;

		// Token: 0x0400F3FA RID: 62458
		private TArray<FName> _NameList;

		// Token: 0x0400F3FB RID: 62459
		internal static int __PropertyOffset_24;

		// Token: 0x0400F3FC RID: 62460
		internal static int __PropertyOffset_25;

		// Token: 0x0400F3FD RID: 62461
		internal static int __PropertyOffset_26;

		// Token: 0x0400F3FE RID: 62462
		internal static int __PropertyOffset_27;

		// Token: 0x0400F3FF RID: 62463
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FParticle_QiuQian> _particleArr;

		// Token: 0x0400F400 RID: 62464
		internal static int __PropertyOffset_28;

		// Token: 0x0400F401 RID: 62465
		internal static int __PropertyOffset_29;

		// Token: 0x0400F402 RID: 62466
		internal static int __PropertyOffset_30;

		// Token: 0x0400F403 RID: 62467
		internal static int __PropertyOffset_31;

		// Token: 0x0400F404 RID: 62468
		internal static int __PropertyOffset_32;

		// Token: 0x0400F405 RID: 62469
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<USplineMeshComponent> _SplineMesh;

		// Token: 0x0400F406 RID: 62470
		internal static int __PropertyOffset_33;

		// Token: 0x0400F407 RID: 62471
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<USplineMeshComponent> _SplineMeshR;

		// Token: 0x0400F408 RID: 62472
		internal static int __PropertyOffset_34;

		// Token: 0x0400F409 RID: 62473
		internal static int __PropertyOffset_35;

		// Token: 0x0400F40A RID: 62474
		internal static int __PropertyOffset_36;

		// Token: 0x0400F40B RID: 62475
		internal static int __PropertyOffset_37;

		// Token: 0x0400F40C RID: 62476
		internal static int __PropertyOffset_38;

		// Token: 0x0400F40D RID: 62477
		internal static int __PropertyOffset_39;

		// Token: 0x0400F40E RID: 62478
		internal static int __PropertyOffset_40;

		// Token: 0x0400F40F RID: 62479
		internal static int __PropertyOffset_41;

		// Token: 0x0400F410 RID: 62480
		internal static int __PropertyOffset_42;

		// Token: 0x0400F411 RID: 62481
		private static IntPtr __InitializeParticleArr_NativeFunctionPtr;

		// Token: 0x0400F412 RID: 62482
		private static IntPtr __SetDMIOffsetEnable_NativeFunctionPtr;

		// Token: 0x0400F413 RID: 62483
		private static IntPtr __UpdateaDMI_NativeFunctionPtr;

		// Token: 0x0400F414 RID: 62484
		private static IntPtr __InitializeDMI_NativeFunctionPtr;

		// Token: 0x0400F415 RID: 62485
		private static IntPtr __solve_NativeFunctionPtr;

		// Token: 0x0400F416 RID: 62486
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F417 RID: 62487
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F418 RID: 62488
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F419 RID: 62489
		private static IntPtr __place_plank_event_NativeFunctionPtr;

		// Token: 0x0400F41A RID: 62490
		private static IntPtr __OnLogicEnable_NativeFunctionPtr;

		// Token: 0x0400F41B RID: 62491
		private static IntPtr __OnLogicDisable_NativeFunctionPtr;

		// Token: 0x0400F41C RID: 62492
		private static IntPtr __BndEvt__BP_SwingLightpipe_SM_Ins_Lig_02AS_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400F41D RID: 62493
		private static IntPtr __BndEvt__BP_SwingLightpipe_SM_Ins_Lig_02AS_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapBlockSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400F41E RID: 62494
		private static IntPtr __ExecuteUbergraph_BP_SwingLightpipe_NativeFunctionPtr;

		// Token: 0x02009810 RID: 38928
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 5)]
		protected ref struct __SetDMIOffsetEnable_FunctionParams
		{
			// Token: 0x04031E19 RID: 204313
			[FieldOffset(0)]
			public bool OffsetEnable;
		}

		// Token: 0x02009811 RID: 38929
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 116)]
		protected ref struct __solve_FunctionParams
		{
			// Token: 0x04031E1A RID: 204314
			[FieldOffset(0)]
			public bool isPinned;

			// Token: 0x04031E1B RID: 204315
			[FieldOffset(4)]
			public FVector pos;

			// Token: 0x04031E1C RID: 204316
			[FieldOffset(16)]
			public FVector linkPos;

			// Token: 0x04031E1D RID: 204317
			[FieldOffset(28)]
			public float targetLen;

			// Token: 0x04031E1E RID: 204318
			[FieldOffset(32)]
			public FVector emitterOriginPos;

			// Token: 0x04031E1F RID: 204319
			[FieldOffset(44)]
			public FVector pos_new;
		}

		// Token: 0x02009812 RID: 38930
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031E20 RID: 204320
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009813 RID: 38931
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_SwingLightpipe_SM_Ins_Lig_02AS_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04031E21 RID: 204321
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04031E22 RID: 204322
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04031E23 RID: 204323
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04031E24 RID: 204324
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04031E25 RID: 204325
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04031E26 RID: 204326
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009814 RID: 38932
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_SwingLightpipe_SM_Ins_Lig_02AS_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapBlockSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04031E27 RID: 204327
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04031E28 RID: 204328
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04031E29 RID: 204329
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04031E2A RID: 204330
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04031E2B RID: 204331
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04031E2C RID: 204332
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009815 RID: 38933
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 3200)]
		protected ref struct __ExecuteUbergraph_BP_SwingLightpipe_FunctionParams
		{
			// Token: 0x04031E2D RID: 204333
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
