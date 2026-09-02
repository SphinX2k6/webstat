using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.CloudCard
{
	// Token: 0x02003CE8 RID: 15592
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/CloudCard/BP_CloudCards.BP_CloudCards_C")]
	[UnrealStructLayout(1288, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1284)]
	public class BP_CloudCards_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025305 RID: 152325 RVA: 0x009B3113 File Offset: 0x009B1313
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CloudCards_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/CloudCard/BP_CloudCards.BP_CloudCards_C");
			}
			return BP_CloudCards_C._ClassPtr;
		}

		// Token: 0x06025306 RID: 152326 RVA: 0x009B3138 File Offset: 0x009B1338
		public BP_CloudCards_C() : this(BuiltinUtils.AllocNativeUObject(BP_CloudCards_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025307 RID: 152327 RVA: 0x009B3160 File Offset: 0x009B1360
		public BP_CloudCards_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CloudCards_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005016 RID: 20502
		// (get) Token: 0x06025308 RID: 152328 RVA: 0x009B3193 File Offset: 0x009B1393
		// (set) Token: 0x06025309 RID: 152329 RVA: 0x009B31A7 File Offset: 0x009B13A7
		[Nullable(2)]
		public unsafe UBillboardComponent Billboard
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudCards_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudCards_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17005017 RID: 20503
		// (get) Token: 0x0602530A RID: 152330 RVA: 0x009B31BC File Offset: 0x009B13BC
		// (set) Token: 0x0602530B RID: 152331 RVA: 0x009B31D0 File Offset: 0x009B13D0
		[Nullable(2)]
		public unsafe USceneComponent Root
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudCards_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudCards_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005018 RID: 20504
		// (get) Token: 0x0602530C RID: 152332 RVA: 0x009B31E5 File Offset: 0x009B13E5
		// (set) Token: 0x0602530D RID: 152333 RVA: 0x009B31F9 File Offset: 0x009B13F9
		[Nullable(2)]
		public unsafe UStaticMeshComponent Plane
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudCards_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudCards_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005019 RID: 20505
		// (get) Token: 0x0602530E RID: 152334 RVA: 0x009B320E File Offset: 0x009B140E
		// (set) Token: 0x0602530F RID: 152335 RVA: 0x009B3222 File Offset: 0x009B1422
		public unsafe FRotator InitRot
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700501A RID: 20506
		// (get) Token: 0x06025310 RID: 152336 RVA: 0x009B3237 File Offset: 0x009B1437
		// (set) Token: 0x06025311 RID: 152337 RVA: 0x009B3247 File Offset: 0x009B1447
		public unsafe float Dist
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700501B RID: 20507
		// (get) Token: 0x06025312 RID: 152338 RVA: 0x009B3258 File Offset: 0x009B1458
		// (set) Token: 0x06025313 RID: 152339 RVA: 0x009B3268 File Offset: 0x009B1468
		public unsafe float DistScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700501C RID: 20508
		// (get) Token: 0x06025314 RID: 152340 RVA: 0x009B3279 File Offset: 0x009B1479
		// (set) Token: 0x06025315 RID: 152341 RVA: 0x009B328D File Offset: 0x009B148D
		public unsafe FVector2D ScaleXY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700501D RID: 20509
		// (get) Token: 0x06025316 RID: 152342 RVA: 0x009B32A2 File Offset: 0x009B14A2
		// (set) Token: 0x06025317 RID: 152343 RVA: 0x009B32B2 File Offset: 0x009B14B2
		public unsafe float Height
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700501E RID: 20510
		// (get) Token: 0x06025318 RID: 152344 RVA: 0x009B32C4 File Offset: 0x009B14C4
		// (set) Token: 0x06025319 RID: 152345 RVA: 0x009B32FD File Offset: 0x009B14FD
		public TArray<UStaticMeshComponent> CloudCardMeshComps
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMeshComponent> result;
				if ((result = this._CloudCardMeshComps) == null)
				{
					result = (this._CloudCardMeshComps = new TArray<UStaticMeshComponent>(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				this.CloudCardMeshComps.CopyAssign(value);
			}
		}

		// Token: 0x1700501F RID: 20511
		// (get) Token: 0x0602531A RID: 152346 RVA: 0x009B330B File Offset: 0x009B150B
		// (set) Token: 0x0602531B RID: 152347 RVA: 0x009B331B File Offset: 0x009B151B
		public unsafe float InitAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005020 RID: 20512
		// (get) Token: 0x0602531C RID: 152348 RVA: 0x009B332C File Offset: 0x009B152C
		// (set) Token: 0x0602531D RID: 152349 RVA: 0x009B333C File Offset: 0x009B153C
		public unsafe float AngleSpace
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005021 RID: 20513
		// (get) Token: 0x0602531E RID: 152350 RVA: 0x009B334D File Offset: 0x009B154D
		// (set) Token: 0x0602531F RID: 152351 RVA: 0x009B335D File Offset: 0x009B155D
		public unsafe int RandomSeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17005022 RID: 20514
		// (get) Token: 0x06025320 RID: 152352 RVA: 0x009B3370 File Offset: 0x009B1570
		// (set) Token: 0x06025321 RID: 152353 RVA: 0x009B33A9 File Offset: 0x009B15A9
		public TArray<UMaterialInstanceDynamic> CloudMIDs
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._CloudMIDs) == null)
				{
					result = (this._CloudMIDs = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				this.CloudMIDs.CopyAssign(value);
			}
		}

		// Token: 0x17005023 RID: 20515
		// (get) Token: 0x06025322 RID: 152354 RVA: 0x009B33B7 File Offset: 0x009B15B7
		// (set) Token: 0x06025323 RID: 152355 RVA: 0x009B33C7 File Offset: 0x009B15C7
		public unsafe float RotSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17005024 RID: 20516
		// (get) Token: 0x06025324 RID: 152356 RVA: 0x009B33D8 File Offset: 0x009B15D8
		// (set) Token: 0x06025325 RID: 152357 RVA: 0x009B3411 File Offset: 0x009B1611
		public FTimerHandle TimerHandle
		{
			get
			{
				base.FastCheckIsValid();
				FTimerHandle result;
				if ((result = this._TimerHandle) == null)
				{
					result = (this._TimerHandle = new FTimerHandle(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FTimerHandle.StaticStruct(), base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_14, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005025 RID: 20517
		// (get) Token: 0x06025326 RID: 152358 RVA: 0x009B3434 File Offset: 0x009B1634
		// (set) Token: 0x06025327 RID: 152359 RVA: 0x009B346D File Offset: 0x009B166D
		public TArray<float> CloudAngles
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._CloudAngles) == null)
				{
					result = (this._CloudAngles = new TArray<float>(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				this.CloudAngles.CopyAssign(value);
			}
		}

		// Token: 0x17005026 RID: 20518
		// (get) Token: 0x06025328 RID: 152360 RVA: 0x009B347B File Offset: 0x009B167B
		// (set) Token: 0x06025329 RID: 152361 RVA: 0x009B348F File Offset: 0x009B168F
		[Nullable(2)]
		public unsafe UMaterialInterface CloudMat
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudCards_C.__PropertyOffset_16);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudCards_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17005027 RID: 20519
		// (get) Token: 0x0602532A RID: 152362 RVA: 0x009B34A4 File Offset: 0x009B16A4
		// (set) Token: 0x0602532B RID: 152363 RVA: 0x009B34DD File Offset: 0x009B16DD
		public TArray<UTexture2D> CloudTextures
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UTexture2D> result;
				if ((result = this._CloudTextures) == null)
				{
					result = (this._CloudTextures = new TArray<UTexture2D>(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				this.CloudTextures.CopyAssign(value);
			}
		}

		// Token: 0x17005028 RID: 20520
		// (get) Token: 0x0602532C RID: 152364 RVA: 0x009B34EB File Offset: 0x009B16EB
		// (set) Token: 0x0602532D RID: 152365 RVA: 0x009B34FB File Offset: 0x009B16FB
		public unsafe float CloudLit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17005029 RID: 20521
		// (get) Token: 0x0602532E RID: 152366 RVA: 0x009B350C File Offset: 0x009B170C
		// (set) Token: 0x0602532F RID: 152367 RVA: 0x009B351C File Offset: 0x009B171C
		public unsafe float AtmoLightScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x1700502A RID: 20522
		// (get) Token: 0x06025330 RID: 152368 RVA: 0x009B352D File Offset: 0x009B172D
		// (set) Token: 0x06025331 RID: 152369 RVA: 0x009B353D File Offset: 0x009B173D
		public unsafe float GammaExp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x1700502B RID: 20523
		// (get) Token: 0x06025332 RID: 152370 RVA: 0x009B354E File Offset: 0x009B174E
		// (set) Token: 0x06025333 RID: 152371 RVA: 0x009B355E File Offset: 0x009B175E
		public unsafe float Contrast
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x1700502C RID: 20524
		// (get) Token: 0x06025334 RID: 152372 RVA: 0x009B356F File Offset: 0x009B176F
		// (set) Token: 0x06025335 RID: 152373 RVA: 0x009B357F File Offset: 0x009B177F
		public unsafe float Brightness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x1700502D RID: 20525
		// (get) Token: 0x06025336 RID: 152374 RVA: 0x009B3590 File Offset: 0x009B1790
		// (set) Token: 0x06025337 RID: 152375 RVA: 0x009B35A0 File Offset: 0x009B17A0
		public unsafe float Translucency
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x1700502E RID: 20526
		// (get) Token: 0x06025338 RID: 152376 RVA: 0x009B35B1 File Offset: 0x009B17B1
		// (set) Token: 0x06025339 RID: 152377 RVA: 0x009B35C1 File Offset: 0x009B17C1
		public unsafe float SkyBlend
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x1700502F RID: 20527
		// (get) Token: 0x0602533A RID: 152378 RVA: 0x009B35D2 File Offset: 0x009B17D2
		// (set) Token: 0x0602533B RID: 152379 RVA: 0x009B35E2 File Offset: 0x009B17E2
		public unsafe float Disortion
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17005030 RID: 20528
		// (get) Token: 0x0602533C RID: 152380 RVA: 0x009B35F3 File Offset: 0x009B17F3
		// (set) Token: 0x0602533D RID: 152381 RVA: 0x009B3603 File Offset: 0x009B1803
		public unsafe float LitOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17005031 RID: 20529
		// (get) Token: 0x0602533E RID: 152382 RVA: 0x009B3614 File Offset: 0x009B1814
		// (set) Token: 0x0602533F RID: 152383 RVA: 0x009B3624 File Offset: 0x009B1824
		public unsafe float HorizonFalloff
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17005032 RID: 20530
		// (get) Token: 0x06025340 RID: 152384 RVA: 0x009B3635 File Offset: 0x009B1835
		// (set) Token: 0x06025341 RID: 152385 RVA: 0x009B3645 File Offset: 0x009B1845
		public unsafe float HorizonOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17005033 RID: 20531
		// (get) Token: 0x06025342 RID: 152386 RVA: 0x009B3656 File Offset: 0x009B1856
		// (set) Token: 0x06025343 RID: 152387 RVA: 0x009B366A File Offset: 0x009B186A
		public unsafe FVector2D DisortionSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17005034 RID: 20532
		// (get) Token: 0x06025344 RID: 152388 RVA: 0x009B367F File Offset: 0x009B187F
		// (set) Token: 0x06025345 RID: 152389 RVA: 0x009B3693 File Offset: 0x009B1893
		public unsafe FLinearColor LightColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17005035 RID: 20533
		// (get) Token: 0x06025346 RID: 152390 RVA: 0x009B36A8 File Offset: 0x009B18A8
		// (set) Token: 0x06025347 RID: 152391 RVA: 0x009B36BC File Offset: 0x009B18BC
		public unsafe FLinearColor DarkColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17005036 RID: 20534
		// (get) Token: 0x06025348 RID: 152392 RVA: 0x009B36D1 File Offset: 0x009B18D1
		// (set) Token: 0x06025349 RID: 152393 RVA: 0x009B36E5 File Offset: 0x009B18E5
		public unsafe FLinearColor BaseColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudCards_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x0602534A RID: 152394 RVA: 0x009B36FC File Offset: 0x009B18FC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetupCloudMesh(UStaticMeshComponent MeshComp, UTexture2D CloudTex, float RotAngle, int RandSeed)
		{
			BP_CloudCards_C.__SetupCloudMesh_FunctionParams* ptr = stackalloc BP_CloudCards_C.__SetupCloudMesh_FunctionParams[(UIntPtr)511] + 15L / (long)sizeof(BP_CloudCards_C.__SetupCloudMesh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudCards_C.__SetupCloudMesh_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->CloudTex = ((CloudTex != null) ? CloudTex.NativePtr : IntPtr.Zero);
			ptr->RotAngle = RotAngle;
			ptr->RandSeed = RandSeed;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudCards_C.__SetupCloudMesh_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602534B RID: 152395 RVA: 0x009B377C File Offset: 0x009B197C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateCloudPos(float TimeOfDay, FVector SunDir)
		{
			BP_CloudCards_C.__UpdateCloudPos_FunctionParams* ptr = stackalloc BP_CloudCards_C.__UpdateCloudPos_FunctionParams[(UIntPtr)367] + 15L / (long)sizeof(BP_CloudCards_C.__UpdateCloudPos_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudCards_C.__UpdateCloudPos_NativeFunctionPtr, (void*)ptr, 1);
			ptr->TimeOfDay = TimeOfDay;
			ptr->SunDir = SunDir;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudCards_C.__UpdateCloudPos_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602534C RID: 152396 RVA: 0x009B37CC File Offset: 0x009B19CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudCards_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602534D RID: 152397 RVA: 0x009B37E0 File Offset: 0x009B19E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CloudCards_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602534E RID: 152398 RVA: 0x009B37F5 File Offset: 0x009B19F5
		protected BP_CloudCards_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013258 RID: 78424
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/CloudCard/BP_CloudCards.BP_CloudCards_C";

		// Token: 0x04013259 RID: 78425
		private static IntPtr _ClassPtr;

		// Token: 0x0401325A RID: 78426
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401325B RID: 78427
		internal static int __PropertyOffset_0;

		// Token: 0x0401325C RID: 78428
		internal static int __PropertyOffset_1;

		// Token: 0x0401325D RID: 78429
		internal static int __PropertyOffset_2;

		// Token: 0x0401325E RID: 78430
		internal static int __PropertyOffset_3;

		// Token: 0x0401325F RID: 78431
		internal static int __PropertyOffset_4;

		// Token: 0x04013260 RID: 78432
		internal static int __PropertyOffset_5;

		// Token: 0x04013261 RID: 78433
		internal static int __PropertyOffset_6;

		// Token: 0x04013262 RID: 78434
		internal static int __PropertyOffset_7;

		// Token: 0x04013263 RID: 78435
		internal static int __PropertyOffset_8;

		// Token: 0x04013264 RID: 78436
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMeshComponent> _CloudCardMeshComps;

		// Token: 0x04013265 RID: 78437
		internal static int __PropertyOffset_9;

		// Token: 0x04013266 RID: 78438
		internal static int __PropertyOffset_10;

		// Token: 0x04013267 RID: 78439
		internal static int __PropertyOffset_11;

		// Token: 0x04013268 RID: 78440
		internal static int __PropertyOffset_12;

		// Token: 0x04013269 RID: 78441
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _CloudMIDs;

		// Token: 0x0401326A RID: 78442
		internal static int __PropertyOffset_13;

		// Token: 0x0401326B RID: 78443
		internal static int __PropertyOffset_14;

		// Token: 0x0401326C RID: 78444
		[Nullable(2)]
		private FTimerHandle _TimerHandle;

		// Token: 0x0401326D RID: 78445
		internal static int __PropertyOffset_15;

		// Token: 0x0401326E RID: 78446
		[Nullable(2)]
		private TArray<float> _CloudAngles;

		// Token: 0x0401326F RID: 78447
		internal static int __PropertyOffset_16;

		// Token: 0x04013270 RID: 78448
		internal static int __PropertyOffset_17;

		// Token: 0x04013271 RID: 78449
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UTexture2D> _CloudTextures;

		// Token: 0x04013272 RID: 78450
		internal static int __PropertyOffset_18;

		// Token: 0x04013273 RID: 78451
		internal static int __PropertyOffset_19;

		// Token: 0x04013274 RID: 78452
		internal static int __PropertyOffset_20;

		// Token: 0x04013275 RID: 78453
		internal static int __PropertyOffset_21;

		// Token: 0x04013276 RID: 78454
		internal static int __PropertyOffset_22;

		// Token: 0x04013277 RID: 78455
		internal static int __PropertyOffset_23;

		// Token: 0x04013278 RID: 78456
		internal static int __PropertyOffset_24;

		// Token: 0x04013279 RID: 78457
		internal static int __PropertyOffset_25;

		// Token: 0x0401327A RID: 78458
		internal static int __PropertyOffset_26;

		// Token: 0x0401327B RID: 78459
		internal static int __PropertyOffset_27;

		// Token: 0x0401327C RID: 78460
		internal static int __PropertyOffset_28;

		// Token: 0x0401327D RID: 78461
		internal static int __PropertyOffset_29;

		// Token: 0x0401327E RID: 78462
		internal static int __PropertyOffset_30;

		// Token: 0x0401327F RID: 78463
		internal static int __PropertyOffset_31;

		// Token: 0x04013280 RID: 78464
		internal static int __PropertyOffset_32;

		// Token: 0x04013281 RID: 78465
		private static IntPtr __SetupCloudMesh_NativeFunctionPtr;

		// Token: 0x04013282 RID: 78466
		private static IntPtr __UpdateCloudPos_NativeFunctionPtr;

		// Token: 0x04013283 RID: 78467
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x02009EC3 RID: 40643
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 496)]
		protected ref struct __SetupCloudMesh_FunctionParams
		{
			// Token: 0x0403298E RID: 207246
			[FieldOffset(0)]
			public IntPtr MeshComp;

			// Token: 0x0403298F RID: 207247
			[FieldOffset(8)]
			public IntPtr CloudTex;

			// Token: 0x04032990 RID: 207248
			[FieldOffset(16)]
			public float RotAngle;

			// Token: 0x04032991 RID: 207249
			[FieldOffset(20)]
			public int RandSeed;
		}

		// Token: 0x02009EC4 RID: 40644
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 352)]
		protected ref struct __UpdateCloudPos_FunctionParams
		{
			// Token: 0x04032992 RID: 207250
			[FieldOffset(0)]
			public float TimeOfDay;

			// Token: 0x04032993 RID: 207251
			[FieldOffset(4)]
			public FVector SunDir;
		}
	}
}
