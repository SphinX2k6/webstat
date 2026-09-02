using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.Piano
{
	// Token: 0x02003AE3 RID: 15075
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/Piano/BP_DecorativePiano.BP_DecorativePiano_C")]
	[UnrealStructLayout(1696, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1689)]
	public class BP_DecorativePiano_C : AKuroGameBudgetBlueprintActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060204D6 RID: 132310 RVA: 0x009281FE File Offset: 0x009263FE
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DecorativePiano_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/Piano/BP_DecorativePiano.BP_DecorativePiano_C");
			}
			return BP_DecorativePiano_C._ClassPtr;
		}

		// Token: 0x060204D7 RID: 132311 RVA: 0x00928224 File Offset: 0x00926424
		public BP_DecorativePiano_C() : this(BuiltinUtils.AllocNativeUObject(BP_DecorativePiano_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060204D8 RID: 132312 RVA: 0x0092824C File Offset: 0x0092644C
		[NullableContext(1)]
		public BP_DecorativePiano_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DecorativePiano_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170034E2 RID: 13538
		// (get) Token: 0x060204D9 RID: 132313 RVA: 0x00928280 File Offset: 0x00926480
		// (set) Token: 0x060204DA RID: 132314 RVA: 0x009282B9 File Offset: 0x009264B9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_DecorativePiano_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_DecorativePiano_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170034E3 RID: 13539
		// (get) Token: 0x060204DB RID: 132315 RVA: 0x009282DA File Offset: 0x009264DA
		// (set) Token: 0x060204DC RID: 132316 RVA: 0x009282EE File Offset: 0x009264EE
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170034E4 RID: 13540
		// (get) Token: 0x060204DD RID: 132317 RVA: 0x00928303 File Offset: 0x00926503
		// (set) Token: 0x060204DE RID: 132318 RVA: 0x00928317 File Offset: 0x00926517
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170034E5 RID: 13541
		// (get) Token: 0x060204DF RID: 132319 RVA: 0x0092832C File Offset: 0x0092652C
		// (set) Token: 0x060204E0 RID: 132320 RVA: 0x00928340 File Offset: 0x00926540
		public unsafe UChildActorComponent Key_C4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170034E6 RID: 13542
		// (get) Token: 0x060204E1 RID: 132321 RVA: 0x00928355 File Offset: 0x00926555
		// (set) Token: 0x060204E2 RID: 132322 RVA: 0x00928369 File Offset: 0x00926569
		public unsafe USceneComponent Group3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170034E7 RID: 13543
		// (get) Token: 0x060204E3 RID: 132323 RVA: 0x0092837E File Offset: 0x0092657E
		// (set) Token: 0x060204E4 RID: 132324 RVA: 0x00928392 File Offset: 0x00926592
		public unsafe USceneComponent Group2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170034E8 RID: 13544
		// (get) Token: 0x060204E5 RID: 132325 RVA: 0x009283A7 File Offset: 0x009265A7
		// (set) Token: 0x060204E6 RID: 132326 RVA: 0x009283BB File Offset: 0x009265BB
		public unsafe USceneComponent Group1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170034E9 RID: 13545
		// (get) Token: 0x060204E7 RID: 132327 RVA: 0x009283D0 File Offset: 0x009265D0
		// (set) Token: 0x060204E8 RID: 132328 RVA: 0x009283E4 File Offset: 0x009265E4
		public unsafe UChildActorComponent Key_ASharp2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170034EA RID: 13546
		// (get) Token: 0x060204E9 RID: 132329 RVA: 0x009283F9 File Offset: 0x009265F9
		// (set) Token: 0x060204EA RID: 132330 RVA: 0x0092840D File Offset: 0x0092660D
		public unsafe UChildActorComponent Key_A3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170034EB RID: 13547
		// (get) Token: 0x060204EB RID: 132331 RVA: 0x00928422 File Offset: 0x00926622
		// (set) Token: 0x060204EC RID: 132332 RVA: 0x00928436 File Offset: 0x00926636
		public unsafe UChildActorComponent Key_GSharp2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x170034EC RID: 13548
		// (get) Token: 0x060204ED RID: 132333 RVA: 0x0092844B File Offset: 0x0092664B
		// (set) Token: 0x060204EE RID: 132334 RVA: 0x0092845F File Offset: 0x0092665F
		public unsafe UChildActorComponent Key_G3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x170034ED RID: 13549
		// (get) Token: 0x060204EF RID: 132335 RVA: 0x00928474 File Offset: 0x00926674
		// (set) Token: 0x060204F0 RID: 132336 RVA: 0x00928488 File Offset: 0x00926688
		public unsafe UChildActorComponent Key_FSharp2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x170034EE RID: 13550
		// (get) Token: 0x060204F1 RID: 132337 RVA: 0x0092849D File Offset: 0x0092669D
		// (set) Token: 0x060204F2 RID: 132338 RVA: 0x009284B1 File Offset: 0x009266B1
		public unsafe UChildActorComponent Key_F3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x170034EF RID: 13551
		// (get) Token: 0x060204F3 RID: 132339 RVA: 0x009284C6 File Offset: 0x009266C6
		// (set) Token: 0x060204F4 RID: 132340 RVA: 0x009284DA File Offset: 0x009266DA
		public unsafe UChildActorComponent Key_E3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x170034F0 RID: 13552
		// (get) Token: 0x060204F5 RID: 132341 RVA: 0x009284EF File Offset: 0x009266EF
		// (set) Token: 0x060204F6 RID: 132342 RVA: 0x00928503 File Offset: 0x00926703
		public unsafe UChildActorComponent Key_DSharp2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x170034F1 RID: 13553
		// (get) Token: 0x060204F7 RID: 132343 RVA: 0x00928518 File Offset: 0x00926718
		// (set) Token: 0x060204F8 RID: 132344 RVA: 0x0092852C File Offset: 0x0092672C
		public unsafe UChildActorComponent Key_D3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x170034F2 RID: 13554
		// (get) Token: 0x060204F9 RID: 132345 RVA: 0x00928541 File Offset: 0x00926741
		// (set) Token: 0x060204FA RID: 132346 RVA: 0x00928555 File Offset: 0x00926755
		public unsafe UChildActorComponent Key_CSharp2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x170034F3 RID: 13555
		// (get) Token: 0x060204FB RID: 132347 RVA: 0x0092856A File Offset: 0x0092676A
		// (set) Token: 0x060204FC RID: 132348 RVA: 0x0092857E File Offset: 0x0092677E
		public unsafe UChildActorComponent Key_B3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x170034F4 RID: 13556
		// (get) Token: 0x060204FD RID: 132349 RVA: 0x00928593 File Offset: 0x00926793
		// (set) Token: 0x060204FE RID: 132350 RVA: 0x009285A7 File Offset: 0x009267A7
		public unsafe UChildActorComponent Key_C3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x170034F5 RID: 13557
		// (get) Token: 0x060204FF RID: 132351 RVA: 0x009285BC File Offset: 0x009267BC
		// (set) Token: 0x06020500 RID: 132352 RVA: 0x009285D0 File Offset: 0x009267D0
		public unsafe UChildActorComponent Key_ASharp1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x170034F6 RID: 13558
		// (get) Token: 0x06020501 RID: 132353 RVA: 0x009285E5 File Offset: 0x009267E5
		// (set) Token: 0x06020502 RID: 132354 RVA: 0x009285F9 File Offset: 0x009267F9
		public unsafe UChildActorComponent Key_A2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x170034F7 RID: 13559
		// (get) Token: 0x06020503 RID: 132355 RVA: 0x0092860E File Offset: 0x0092680E
		// (set) Token: 0x06020504 RID: 132356 RVA: 0x00928622 File Offset: 0x00926822
		public unsafe UChildActorComponent Key_GSharp1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x170034F8 RID: 13560
		// (get) Token: 0x06020505 RID: 132357 RVA: 0x00928637 File Offset: 0x00926837
		// (set) Token: 0x06020506 RID: 132358 RVA: 0x0092864B File Offset: 0x0092684B
		public unsafe UChildActorComponent Key_CSharp1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x170034F9 RID: 13561
		// (get) Token: 0x06020507 RID: 132359 RVA: 0x00928660 File Offset: 0x00926860
		// (set) Token: 0x06020508 RID: 132360 RVA: 0x00928674 File Offset: 0x00926874
		public unsafe UChildActorComponent Key_FSharp1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x170034FA RID: 13562
		// (get) Token: 0x06020509 RID: 132361 RVA: 0x00928689 File Offset: 0x00926889
		// (set) Token: 0x0602050A RID: 132362 RVA: 0x0092869D File Offset: 0x0092689D
		public unsafe UChildActorComponent Key_B2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x170034FB RID: 13563
		// (get) Token: 0x0602050B RID: 132363 RVA: 0x009286B2 File Offset: 0x009268B2
		// (set) Token: 0x0602050C RID: 132364 RVA: 0x009286C6 File Offset: 0x009268C6
		public unsafe UChildActorComponent Key_E2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x170034FC RID: 13564
		// (get) Token: 0x0602050D RID: 132365 RVA: 0x009286DB File Offset: 0x009268DB
		// (set) Token: 0x0602050E RID: 132366 RVA: 0x009286EF File Offset: 0x009268EF
		public unsafe UChildActorComponent Key_DSharp1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_26);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_26, value);
			}
		}

		// Token: 0x170034FD RID: 13565
		// (get) Token: 0x0602050F RID: 132367 RVA: 0x00928704 File Offset: 0x00926904
		// (set) Token: 0x06020510 RID: 132368 RVA: 0x00928718 File Offset: 0x00926918
		public unsafe UChildActorComponent Key_D2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x170034FE RID: 13566
		// (get) Token: 0x06020511 RID: 132369 RVA: 0x0092872D File Offset: 0x0092692D
		// (set) Token: 0x06020512 RID: 132370 RVA: 0x00928741 File Offset: 0x00926941
		public unsafe UChildActorComponent Key_G2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x170034FF RID: 13567
		// (get) Token: 0x06020513 RID: 132371 RVA: 0x00928756 File Offset: 0x00926956
		// (set) Token: 0x06020514 RID: 132372 RVA: 0x0092876A File Offset: 0x0092696A
		public unsafe UChildActorComponent Key_C2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_29);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x17003500 RID: 13568
		// (get) Token: 0x06020515 RID: 132373 RVA: 0x0092877F File Offset: 0x0092697F
		// (set) Token: 0x06020516 RID: 132374 RVA: 0x00928793 File Offset: 0x00926993
		public unsafe UChildActorComponent Key_F2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_30);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x17003501 RID: 13569
		// (get) Token: 0x06020517 RID: 132375 RVA: 0x009287A8 File Offset: 0x009269A8
		// (set) Token: 0x06020518 RID: 132376 RVA: 0x009287BC File Offset: 0x009269BC
		public unsafe UChildActorComponent Key_B1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_31);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_31, value);
			}
		}

		// Token: 0x17003502 RID: 13570
		// (get) Token: 0x06020519 RID: 132377 RVA: 0x009287D1 File Offset: 0x009269D1
		// (set) Token: 0x0602051A RID: 132378 RVA: 0x009287E5 File Offset: 0x009269E5
		public unsafe UChildActorComponent Key_ASharp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_32);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_32, value);
			}
		}

		// Token: 0x17003503 RID: 13571
		// (get) Token: 0x0602051B RID: 132379 RVA: 0x009287FA File Offset: 0x009269FA
		// (set) Token: 0x0602051C RID: 132380 RVA: 0x0092880E File Offset: 0x00926A0E
		public unsafe UChildActorComponent Key_A1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_33);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x17003504 RID: 13572
		// (get) Token: 0x0602051D RID: 132381 RVA: 0x00928823 File Offset: 0x00926A23
		// (set) Token: 0x0602051E RID: 132382 RVA: 0x00928837 File Offset: 0x00926A37
		public unsafe UChildActorComponent Key_GSharp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_34);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_34, value);
			}
		}

		// Token: 0x17003505 RID: 13573
		// (get) Token: 0x0602051F RID: 132383 RVA: 0x0092884C File Offset: 0x00926A4C
		// (set) Token: 0x06020520 RID: 132384 RVA: 0x00928860 File Offset: 0x00926A60
		public unsafe UChildActorComponent Key_G1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_35);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_35, value);
			}
		}

		// Token: 0x17003506 RID: 13574
		// (get) Token: 0x06020521 RID: 132385 RVA: 0x00928875 File Offset: 0x00926A75
		// (set) Token: 0x06020522 RID: 132386 RVA: 0x00928889 File Offset: 0x00926A89
		public unsafe UChildActorComponent Key_C1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_36);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_36, value);
			}
		}

		// Token: 0x17003507 RID: 13575
		// (get) Token: 0x06020523 RID: 132387 RVA: 0x0092889E File Offset: 0x00926A9E
		// (set) Token: 0x06020524 RID: 132388 RVA: 0x009288B2 File Offset: 0x00926AB2
		public unsafe UChildActorComponent Key_F1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_37);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_37, value);
			}
		}

		// Token: 0x17003508 RID: 13576
		// (get) Token: 0x06020525 RID: 132389 RVA: 0x009288C7 File Offset: 0x00926AC7
		// (set) Token: 0x06020526 RID: 132390 RVA: 0x009288DB File Offset: 0x00926ADB
		public unsafe UChildActorComponent Key_E1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_38);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_38, value);
			}
		}

		// Token: 0x17003509 RID: 13577
		// (get) Token: 0x06020527 RID: 132391 RVA: 0x009288F0 File Offset: 0x00926AF0
		// (set) Token: 0x06020528 RID: 132392 RVA: 0x00928904 File Offset: 0x00926B04
		public unsafe UChildActorComponent Key_DSharp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_39);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_39, value);
			}
		}

		// Token: 0x1700350A RID: 13578
		// (get) Token: 0x06020529 RID: 132393 RVA: 0x00928919 File Offset: 0x00926B19
		// (set) Token: 0x0602052A RID: 132394 RVA: 0x0092892D File Offset: 0x00926B2D
		public unsafe UChildActorComponent Key_D1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_40);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_40, value);
			}
		}

		// Token: 0x1700350B RID: 13579
		// (get) Token: 0x0602052B RID: 132395 RVA: 0x00928942 File Offset: 0x00926B42
		// (set) Token: 0x0602052C RID: 132396 RVA: 0x00928956 File Offset: 0x00926B56
		public unsafe UChildActorComponent Key_CSharp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_41);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_41, value);
			}
		}

		// Token: 0x1700350C RID: 13580
		// (get) Token: 0x0602052D RID: 132397 RVA: 0x0092896B File Offset: 0x00926B6B
		// (set) Token: 0x0602052E RID: 132398 RVA: 0x0092897F File Offset: 0x00926B7F
		public unsafe UChildActorComponent Key_FSharp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_42);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_42, value);
			}
		}

		// Token: 0x1700350D RID: 13581
		// (get) Token: 0x0602052F RID: 132399 RVA: 0x00928994 File Offset: 0x00926B94
		// (set) Token: 0x06020530 RID: 132400 RVA: 0x009289A8 File Offset: 0x00926BA8
		public unsafe USceneComponent Key
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_43);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_43, value);
			}
		}

		// Token: 0x1700350E RID: 13582
		// (get) Token: 0x06020531 RID: 132401 RVA: 0x009289C0 File Offset: 0x00926BC0
		// (set) Token: 0x06020532 RID: 132402 RVA: 0x009289F9 File Offset: 0x00926BF9
		[Nullable(1)]
		public TArray<BP_PianoKey_C> BPKeyArray
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<BP_PianoKey_C> result;
				if ((result = this._BPKeyArray) == null)
				{
					result = (this._BPKeyArray = new TArray<BP_PianoKey_C>(base.NativePtr + (IntPtr)BP_DecorativePiano_C.__PropertyOffset_44, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.BPKeyArray.CopyAssign(value);
			}
		}

		// Token: 0x1700350F RID: 13583
		// (get) Token: 0x06020533 RID: 132403 RVA: 0x00928A08 File Offset: 0x00926C08
		// (set) Token: 0x06020534 RID: 132404 RVA: 0x00928A41 File Offset: 0x00926C41
		[Nullable(1)]
		public MoveNote MoveNote
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				MoveNote result;
				if ((result = this._MoveNote) == null)
				{
					result = (this._MoveNote = new MoveNote(base.NativePtr + (IntPtr)BP_DecorativePiano_C.__PropertyOffset_45, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_DecorativePiano_C.__PropertyOffset_45, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17003510 RID: 13584
		// (get) Token: 0x06020535 RID: 132405 RVA: 0x00928A62 File Offset: 0x00926C62
		// (set) Token: 0x06020536 RID: 132406 RVA: 0x00928A76 File Offset: 0x00926C76
		public unsafe UAkAudioEvent WwiseEvent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_46);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DecorativePiano_C.__PropertyOffset_46, value);
			}
		}

		// Token: 0x17003511 RID: 13585
		// (get) Token: 0x06020537 RID: 132407 RVA: 0x00928A8B File Offset: 0x00926C8B
		// (set) Token: 0x06020538 RID: 132408 RVA: 0x00928A9B File Offset: 0x00926C9B
		public unsafe byte MIDIStartIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DecorativePiano_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DecorativePiano_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x06020539 RID: 132409 RVA: 0x00928AAC File Offset: 0x00926CAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitKeyRefArray()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DecorativePiano_C.__InitKeyRefArray_NativeFunctionPtr, null);
		}

		// Token: 0x0602053A RID: 132410 RVA: 0x00928AC0 File Offset: 0x00926CC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void PlayAudio(PianoKeyEnum KeyType)
		{
			BP_DecorativePiano_C.__PlayAudio_FunctionParams* ptr = stackalloc BP_DecorativePiano_C.__PlayAudio_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_DecorativePiano_C.__PlayAudio_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DecorativePiano_C.__PlayAudio_NativeFunctionPtr, (void*)ptr, 1);
			ptr->KeyType = KeyType;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DecorativePiano_C.__PlayAudio_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602053B RID: 132411 RVA: 0x00928B0B File Offset: 0x00926D0B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DecorativePiano_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602053C RID: 132412 RVA: 0x00928B1F File Offset: 0x00926D1F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DecorativePiano_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602053D RID: 132413 RVA: 0x00928B34 File Offset: 0x00926D34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_DecorativePiano_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_DecorativePiano_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DecorativePiano_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DecorativePiano_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DecorativePiano_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602053E RID: 132414 RVA: 0x00928B7C File Offset: 0x00926D7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_DecorativePiano_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_DecorativePiano_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DecorativePiano_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DecorativePiano_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DecorativePiano_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602053F RID: 132415 RVA: 0x00928BC4 File Offset: 0x00926DC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CustomEvent_0(bool Overlap, PianoKeyEnum KeyType)
		{
			BP_DecorativePiano_C.__CustomEvent_0_FunctionParams* ptr = stackalloc BP_DecorativePiano_C.__CustomEvent_0_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(BP_DecorativePiano_C.__CustomEvent_0_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DecorativePiano_C.__CustomEvent_0_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Overlap = Overlap;
			ptr->KeyType = KeyType;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DecorativePiano_C.__CustomEvent_0_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020540 RID: 132416 RVA: 0x00928C18 File Offset: 0x00926E18
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_DecorativePiano_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_DecorativePiano_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_DecorativePiano_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DecorativePiano_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DecorativePiano_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020541 RID: 132417 RVA: 0x00928C64 File Offset: 0x00926E64
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_DecorativePiano_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_DecorativePiano_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_DecorativePiano_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DecorativePiano_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DecorativePiano_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020542 RID: 132418 RVA: 0x00928CB0 File Offset: 0x00926EB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_DecorativePiano(int EntryPoint)
		{
			BP_DecorativePiano_C.__ExecuteUbergraph_BP_DecorativePiano_FunctionParams* ptr = stackalloc BP_DecorativePiano_C.__ExecuteUbergraph_BP_DecorativePiano_FunctionParams[(UIntPtr)135] + 15L / (long)sizeof(BP_DecorativePiano_C.__ExecuteUbergraph_BP_DecorativePiano_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DecorativePiano_C.__ExecuteUbergraph_BP_DecorativePiano_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DecorativePiano_C.__ExecuteUbergraph_BP_DecorativePiano_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020543 RID: 132419 RVA: 0x00928CFA File Offset: 0x00926EFA
		protected BP_DecorativePiano_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040101EA RID: 66026
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/Piano/BP_DecorativePiano.BP_DecorativePiano_C";

		// Token: 0x040101EB RID: 66027
		private static IntPtr _ClassPtr;

		// Token: 0x040101EC RID: 66028
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040101ED RID: 66029
		public static IntPtr __MoveNote__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040101EE RID: 66030
		internal static int __PropertyOffset_0;

		// Token: 0x040101EF RID: 66031
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040101F0 RID: 66032
		internal static int __PropertyOffset_1;

		// Token: 0x040101F1 RID: 66033
		internal static int __PropertyOffset_2;

		// Token: 0x040101F2 RID: 66034
		internal static int __PropertyOffset_3;

		// Token: 0x040101F3 RID: 66035
		internal static int __PropertyOffset_4;

		// Token: 0x040101F4 RID: 66036
		internal static int __PropertyOffset_5;

		// Token: 0x040101F5 RID: 66037
		internal static int __PropertyOffset_6;

		// Token: 0x040101F6 RID: 66038
		internal static int __PropertyOffset_7;

		// Token: 0x040101F7 RID: 66039
		internal static int __PropertyOffset_8;

		// Token: 0x040101F8 RID: 66040
		internal static int __PropertyOffset_9;

		// Token: 0x040101F9 RID: 66041
		internal static int __PropertyOffset_10;

		// Token: 0x040101FA RID: 66042
		internal static int __PropertyOffset_11;

		// Token: 0x040101FB RID: 66043
		internal static int __PropertyOffset_12;

		// Token: 0x040101FC RID: 66044
		internal static int __PropertyOffset_13;

		// Token: 0x040101FD RID: 66045
		internal static int __PropertyOffset_14;

		// Token: 0x040101FE RID: 66046
		internal static int __PropertyOffset_15;

		// Token: 0x040101FF RID: 66047
		internal static int __PropertyOffset_16;

		// Token: 0x04010200 RID: 66048
		internal static int __PropertyOffset_17;

		// Token: 0x04010201 RID: 66049
		internal static int __PropertyOffset_18;

		// Token: 0x04010202 RID: 66050
		internal static int __PropertyOffset_19;

		// Token: 0x04010203 RID: 66051
		internal static int __PropertyOffset_20;

		// Token: 0x04010204 RID: 66052
		internal static int __PropertyOffset_21;

		// Token: 0x04010205 RID: 66053
		internal static int __PropertyOffset_22;

		// Token: 0x04010206 RID: 66054
		internal static int __PropertyOffset_23;

		// Token: 0x04010207 RID: 66055
		internal static int __PropertyOffset_24;

		// Token: 0x04010208 RID: 66056
		internal static int __PropertyOffset_25;

		// Token: 0x04010209 RID: 66057
		internal static int __PropertyOffset_26;

		// Token: 0x0401020A RID: 66058
		internal static int __PropertyOffset_27;

		// Token: 0x0401020B RID: 66059
		internal static int __PropertyOffset_28;

		// Token: 0x0401020C RID: 66060
		internal static int __PropertyOffset_29;

		// Token: 0x0401020D RID: 66061
		internal static int __PropertyOffset_30;

		// Token: 0x0401020E RID: 66062
		internal static int __PropertyOffset_31;

		// Token: 0x0401020F RID: 66063
		internal static int __PropertyOffset_32;

		// Token: 0x04010210 RID: 66064
		internal static int __PropertyOffset_33;

		// Token: 0x04010211 RID: 66065
		internal static int __PropertyOffset_34;

		// Token: 0x04010212 RID: 66066
		internal static int __PropertyOffset_35;

		// Token: 0x04010213 RID: 66067
		internal static int __PropertyOffset_36;

		// Token: 0x04010214 RID: 66068
		internal static int __PropertyOffset_37;

		// Token: 0x04010215 RID: 66069
		internal static int __PropertyOffset_38;

		// Token: 0x04010216 RID: 66070
		internal static int __PropertyOffset_39;

		// Token: 0x04010217 RID: 66071
		internal static int __PropertyOffset_40;

		// Token: 0x04010218 RID: 66072
		internal static int __PropertyOffset_41;

		// Token: 0x04010219 RID: 66073
		internal static int __PropertyOffset_42;

		// Token: 0x0401021A RID: 66074
		internal static int __PropertyOffset_43;

		// Token: 0x0401021B RID: 66075
		internal static int __PropertyOffset_44;

		// Token: 0x0401021C RID: 66076
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BP_PianoKey_C> _BPKeyArray;

		// Token: 0x0401021D RID: 66077
		internal static int __PropertyOffset_45;

		// Token: 0x0401021E RID: 66078
		private MoveNote _MoveNote;

		// Token: 0x0401021F RID: 66079
		internal static int __PropertyOffset_46;

		// Token: 0x04010220 RID: 66080
		internal static int __PropertyOffset_47;

		// Token: 0x04010221 RID: 66081
		private static IntPtr __InitKeyRefArray_NativeFunctionPtr;

		// Token: 0x04010222 RID: 66082
		private static IntPtr __PlayAudio_NativeFunctionPtr;

		// Token: 0x04010223 RID: 66083
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010224 RID: 66084
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010225 RID: 66085
		private static IntPtr __CustomEvent_0_NativeFunctionPtr;

		// Token: 0x04010226 RID: 66086
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04010227 RID: 66087
		private static IntPtr __ExecuteUbergraph_BP_DecorativePiano_NativeFunctionPtr;

		// Token: 0x02009991 RID: 39313
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __PlayAudio_FunctionParams
		{
			// Token: 0x04032017 RID: 204823
			[FieldOffset(0)]
			public TEnumAsByte<PianoKeyEnum> KeyType;
		}

		// Token: 0x02009992 RID: 39314
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032018 RID: 204824
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009993 RID: 39315
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __CustomEvent_0_FunctionParams
		{
			// Token: 0x04032019 RID: 204825
			[FieldOffset(0)]
			public bool Overlap;

			// Token: 0x0403201A RID: 204826
			[FieldOffset(1)]
			public TEnumAsByte<PianoKeyEnum> KeyType;
		}

		// Token: 0x02009994 RID: 39316
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x0403201B RID: 204827
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009995 RID: 39317
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 120)]
		protected ref struct __ExecuteUbergraph_BP_DecorativePiano_FunctionParams
		{
			// Token: 0x0403201C RID: 204828
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
