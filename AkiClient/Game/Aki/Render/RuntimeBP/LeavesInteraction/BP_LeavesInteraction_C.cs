using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.LeavesInteraction
{
	// Token: 0x02003C63 RID: 15459
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/LeavesInteraction/BP_LeavesInteraction.BP_LeavesInteraction_C")]
	[UnrealStructLayout(1608, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1608)]
	public class BP_LeavesInteraction_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023C20 RID: 146464 RVA: 0x0098B6A8 File Offset: 0x009898A8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_LeavesInteraction_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/LeavesInteraction/BP_LeavesInteraction.BP_LeavesInteraction_C");
			}
			return BP_LeavesInteraction_C._ClassPtr;
		}

		// Token: 0x06023C21 RID: 146465 RVA: 0x0098B6CC File Offset: 0x009898CC
		public BP_LeavesInteraction_C() : this(BuiltinUtils.AllocNativeUObject(BP_LeavesInteraction_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023C22 RID: 146466 RVA: 0x0098B6F4 File Offset: 0x009898F4
		[NullableContext(1)]
		public BP_LeavesInteraction_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_LeavesInteraction_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004822 RID: 18466
		// (get) Token: 0x06023C23 RID: 146467 RVA: 0x0098B728 File Offset: 0x00989928
		// (set) Token: 0x06023C24 RID: 146468 RVA: 0x0098B761 File Offset: 0x00989961
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004823 RID: 18467
		// (get) Token: 0x06023C25 RID: 146469 RVA: 0x0098B782 File Offset: 0x00989982
		// (set) Token: 0x06023C26 RID: 146470 RVA: 0x0098B796 File Offset: 0x00989996
		public unsafe UBoxComponent AreaBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004824 RID: 18468
		// (get) Token: 0x06023C27 RID: 146471 RVA: 0x0098B7AB File Offset: 0x009899AB
		// (set) Token: 0x06023C28 RID: 146472 RVA: 0x0098B7BF File Offset: 0x009899BF
		public unsafe UNiagaraComponent NS_FX_LeavesInteraction
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004825 RID: 18469
		// (get) Token: 0x06023C29 RID: 146473 RVA: 0x0098B7D4 File Offset: 0x009899D4
		// (set) Token: 0x06023C2A RID: 146474 RVA: 0x0098B7E8 File Offset: 0x009899E8
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004826 RID: 18470
		// (get) Token: 0x06023C2B RID: 146475 RVA: 0x0098B7FD File Offset: 0x009899FD
		// (set) Token: 0x06023C2C RID: 146476 RVA: 0x0098B811 File Offset: 0x00989A11
		public unsafe FVector FieldSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004827 RID: 18471
		// (get) Token: 0x06023C2D RID: 146477 RVA: 0x0098B826 File Offset: 0x00989A26
		// (set) Token: 0x06023C2E RID: 146478 RVA: 0x0098B836 File Offset: 0x00989A36
		public unsafe int Resolution
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17004828 RID: 18472
		// (get) Token: 0x06023C2F RID: 146479 RVA: 0x0098B847 File Offset: 0x00989A47
		// (set) Token: 0x06023C30 RID: 146480 RVA: 0x0098B85B File Offset: 0x00989A5B
		public unsafe FVector Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004829 RID: 18473
		// (get) Token: 0x06023C31 RID: 146481 RVA: 0x0098B870 File Offset: 0x00989A70
		// (set) Token: 0x06023C32 RID: 146482 RVA: 0x0098B884 File Offset: 0x00989A84
		public unsafe USkeletalMeshComponent Weapon
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x1700482A RID: 18474
		// (get) Token: 0x06023C33 RID: 146483 RVA: 0x0098B899 File Offset: 0x00989A99
		// (set) Token: 0x06023C34 RID: 146484 RVA: 0x0098B8AD File Offset: 0x00989AAD
		public unsafe FVector LastWeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700482B RID: 18475
		// (get) Token: 0x06023C35 RID: 146485 RVA: 0x0098B8C2 File Offset: 0x00989AC2
		// (set) Token: 0x06023C36 RID: 146486 RVA: 0x0098B8D6 File Offset: 0x00989AD6
		public unsafe FVector WeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700482C RID: 18476
		// (get) Token: 0x06023C37 RID: 146487 RVA: 0x0098B8EB File Offset: 0x00989AEB
		// (set) Token: 0x06023C38 RID: 146488 RVA: 0x0098B8FF File Offset: 0x00989AFF
		public unsafe FVector WeaponVelocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700482D RID: 18477
		// (get) Token: 0x06023C39 RID: 146489 RVA: 0x0098B914 File Offset: 0x00989B14
		// (set) Token: 0x06023C3A RID: 146490 RVA: 0x0098B928 File Offset: 0x00989B28
		public unsafe UMaterialParameterCollection Global_MPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x1700482E RID: 18478
		// (get) Token: 0x06023C3B RID: 146491 RVA: 0x0098B93D File Offset: 0x00989B3D
		// (set) Token: 0x06023C3C RID: 146492 RVA: 0x0098B94D File Offset: 0x00989B4D
		public unsafe bool isClear
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700482F RID: 18479
		// (get) Token: 0x06023C3D RID: 146493 RVA: 0x0098B95E File Offset: 0x00989B5E
		// (set) Token: 0x06023C3E RID: 146494 RVA: 0x0098B972 File Offset: 0x00989B72
		public unsafe FLinearColor GlobalWorldPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17004830 RID: 18480
		// (get) Token: 0x06023C3F RID: 146495 RVA: 0x0098B987 File Offset: 0x00989B87
		// (set) Token: 0x06023C40 RID: 146496 RVA: 0x0098B997 File Offset: 0x00989B97
		public unsafe float PlayerSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004831 RID: 18481
		// (get) Token: 0x06023C41 RID: 146497 RVA: 0x0098B9A8 File Offset: 0x00989BA8
		// (set) Token: 0x06023C42 RID: 146498 RVA: 0x0098B9B8 File Offset: 0x00989BB8
		public unsafe float WeaponSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17004832 RID: 18482
		// (get) Token: 0x06023C43 RID: 146499 RVA: 0x0098B9C9 File Offset: 0x00989BC9
		// (set) Token: 0x06023C44 RID: 146500 RVA: 0x0098B9DD File Offset: 0x00989BDD
		public unsafe FVector DepthCapturePosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17004833 RID: 18483
		// (get) Token: 0x06023C45 RID: 146501 RVA: 0x0098B9F2 File Offset: 0x00989BF2
		// (set) Token: 0x06023C46 RID: 146502 RVA: 0x0098BA06 File Offset: 0x00989C06
		public unsafe UTexture DepthTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17004834 RID: 18484
		// (get) Token: 0x06023C47 RID: 146503 RVA: 0x0098BA1B File Offset: 0x00989C1B
		// (set) Token: 0x06023C48 RID: 146504 RVA: 0x0098BA2B File Offset: 0x00989C2B
		public unsafe int LeavesIDStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17004835 RID: 18485
		// (get) Token: 0x06023C49 RID: 146505 RVA: 0x0098BA3C File Offset: 0x00989C3C
		// (set) Token: 0x06023C4A RID: 146506 RVA: 0x0098BA4C File Offset: 0x00989C4C
		public unsafe int LeavesIDEnd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17004836 RID: 18486
		// (get) Token: 0x06023C4B RID: 146507 RVA: 0x0098BA5D File Offset: 0x00989C5D
		// (set) Token: 0x06023C4C RID: 146508 RVA: 0x0098BA6D File Offset: 0x00989C6D
		public unsafe int LeavesNum
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17004837 RID: 18487
		// (get) Token: 0x06023C4D RID: 146509 RVA: 0x0098BA7E File Offset: 0x00989C7E
		// (set) Token: 0x06023C4E RID: 146510 RVA: 0x0098BA8E File Offset: 0x00989C8E
		public unsafe float BoxSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17004838 RID: 18488
		// (get) Token: 0x06023C4F RID: 146511 RVA: 0x0098BA9F File Offset: 0x00989C9F
		// (set) Token: 0x06023C50 RID: 146512 RVA: 0x0098BAAF File Offset: 0x00989CAF
		public unsafe float LeavesScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17004839 RID: 18489
		// (get) Token: 0x06023C51 RID: 146513 RVA: 0x0098BAC0 File Offset: 0x00989CC0
		// (set) Token: 0x06023C52 RID: 146514 RVA: 0x0098BAD0 File Offset: 0x00989CD0
		public unsafe int LUTIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x1700483A RID: 18490
		// (get) Token: 0x06023C53 RID: 146515 RVA: 0x0098BAE1 File Offset: 0x00989CE1
		// (set) Token: 0x06023C54 RID: 146516 RVA: 0x0098BAF1 File Offset: 0x00989CF1
		public unsafe float LeavesRoughness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x1700483B RID: 18491
		// (get) Token: 0x06023C55 RID: 146517 RVA: 0x0098BB02 File Offset: 0x00989D02
		// (set) Token: 0x06023C56 RID: 146518 RVA: 0x0098BB12 File Offset: 0x00989D12
		public unsafe float LeavesAO
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x1700483C RID: 18492
		// (get) Token: 0x06023C57 RID: 146519 RVA: 0x0098BB23 File Offset: 0x00989D23
		// (set) Token: 0x06023C58 RID: 146520 RVA: 0x0098BB33 File Offset: 0x00989D33
		public unsafe float LutProbabilityPower
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x1700483D RID: 18493
		// (get) Token: 0x06023C59 RID: 146521 RVA: 0x0098BB44 File Offset: 0x00989D44
		// (set) Token: 0x06023C5A RID: 146522 RVA: 0x0098BB58 File Offset: 0x00989D58
		public unsafe UTexture LeavesMaskTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x1700483E RID: 18494
		// (get) Token: 0x06023C5B RID: 146523 RVA: 0x0098BB6D File Offset: 0x00989D6D
		// (set) Token: 0x06023C5C RID: 146524 RVA: 0x0098BB7D File Offset: 0x00989D7D
		public unsafe bool UseLUT
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700483F RID: 18495
		// (get) Token: 0x06023C5D RID: 146525 RVA: 0x0098BB8E File Offset: 0x00989D8E
		// (set) Token: 0x06023C5E RID: 146526 RVA: 0x0098BB9E File Offset: 0x00989D9E
		public unsafe float OffsetDis
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17004840 RID: 18496
		// (get) Token: 0x06023C5F RID: 146527 RVA: 0x0098BBAF File Offset: 0x00989DAF
		// (set) Token: 0x06023C60 RID: 146528 RVA: 0x0098BBC3 File Offset: 0x00989DC3
		public unsafe FVector BPPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17004841 RID: 18497
		// (get) Token: 0x06023C61 RID: 146529 RVA: 0x0098BBD8 File Offset: 0x00989DD8
		// (set) Token: 0x06023C62 RID: 146530 RVA: 0x0098BBE8 File Offset: 0x00989DE8
		public unsafe float CullingHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17004842 RID: 18498
		// (get) Token: 0x06023C63 RID: 146531 RVA: 0x0098BBF9 File Offset: 0x00989DF9
		// (set) Token: 0x06023C64 RID: 146532 RVA: 0x0098BC0D File Offset: 0x00989E0D
		public unsafe FVector RuntimeDepthCapturePos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17004843 RID: 18499
		// (get) Token: 0x06023C65 RID: 146533 RVA: 0x0098BC22 File Offset: 0x00989E22
		// (set) Token: 0x06023C66 RID: 146534 RVA: 0x0098BC36 File Offset: 0x00989E36
		public unsafe UTexture RuntimeDepthTex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_C.__PropertyOffset_33);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x17004844 RID: 18500
		// (get) Token: 0x06023C67 RID: 146535 RVA: 0x0098BC4B File Offset: 0x00989E4B
		// (set) Token: 0x06023C68 RID: 146536 RVA: 0x0098BC5F File Offset: 0x00989E5F
		public unsafe FVector RuntimeDepthCaptureBoxSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17004845 RID: 18501
		// (get) Token: 0x06023C69 RID: 146537 RVA: 0x0098BC74 File Offset: 0x00989E74
		// (set) Token: 0x06023C6A RID: 146538 RVA: 0x0098BC84 File Offset: 0x00989E84
		public unsafe bool UseRuntimeCapture
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_35) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_35) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004846 RID: 18502
		// (get) Token: 0x06023C6B RID: 146539 RVA: 0x0098BC95 File Offset: 0x00989E95
		// (set) Token: 0x06023C6C RID: 146540 RVA: 0x0098BCA5 File Offset: 0x00989EA5
		public unsafe bool bHideInLowQuality
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_36) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_C.__PropertyOffset_36) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004847 RID: 18503
		// (get) Token: 0x06023C6D RID: 146541 RVA: 0x0098BCB6 File Offset: 0x00989EB6
		// (set) Token: 0x06023C6E RID: 146542 RVA: 0x0098BCCA File Offset: 0x00989ECA
		public unsafe UMaterialInterface LeavesMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_C.__PropertyOffset_37);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_C.__PropertyOffset_37, value);
			}
		}

		// Token: 0x17004848 RID: 18504
		// (get) Token: 0x06023C6F RID: 146543 RVA: 0x0098BCDF File Offset: 0x00989EDF
		// (set) Token: 0x06023C70 RID: 146544 RVA: 0x0098BCF3 File Offset: 0x00989EF3
		public unsafe UTexture LeavesIDBaseColorMap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_C.__PropertyOffset_38);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_C.__PropertyOffset_38, value);
			}
		}

		// Token: 0x17004849 RID: 18505
		// (get) Token: 0x06023C71 RID: 146545 RVA: 0x0098BD08 File Offset: 0x00989F08
		// (set) Token: 0x06023C72 RID: 146546 RVA: 0x0098BD1C File Offset: 0x00989F1C
		public unsafe UTexture LeavesIDNormalMap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_C.__PropertyOffset_39);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_C.__PropertyOffset_39, value);
			}
		}

		// Token: 0x06023C73 RID: 146547 RVA: 0x0098BD31 File Offset: 0x00989F31
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetMaterialParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesInteraction_C.__SetMaterialParam_NativeFunctionPtr, null);
		}

		// Token: 0x06023C74 RID: 146548 RVA: 0x0098BD45 File Offset: 0x00989F45
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetLeavesParameters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesInteraction_C.__SetLeavesParameters_NativeFunctionPtr, null);
		}

		// Token: 0x06023C75 RID: 146549 RVA: 0x0098BD59 File Offset: 0x00989F59
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Debug()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesInteraction_C.__Debug_NativeFunctionPtr, null);
		}

		// Token: 0x06023C76 RID: 146550 RVA: 0x0098BD70 File Offset: 0x00989F70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Choose_Available_Point(FVectorDouble CollisionPoint, FVectorDouble WeaponPoint, BP_SceneBattleInteract_C ConfigDA, ref FVectorDouble AvailblePoint)
		{
			BP_LeavesInteraction_C.__Choose_Available_Point_FunctionParams* ptr = stackalloc BP_LeavesInteraction_C.__Choose_Available_Point_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_LeavesInteraction_C.__Choose_Available_Point_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LeavesInteraction_C.__Choose_Available_Point_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CollisionPoint = CollisionPoint;
			ptr->WeaponPoint = WeaponPoint;
			ptr->ConfigDA = ((ConfigDA != null) ? ConfigDA.NativePtr : IntPtr.Zero);
			ptr->AvailblePoint = AvailblePoint;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesInteraction_C.__Choose_Available_Point_NativeFunctionPtr, (void*)ptr);
			AvailblePoint = ptr->AvailblePoint;
		}

		// Token: 0x06023C77 RID: 146551 RVA: 0x0098BDED File Offset: 0x00989FED
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void WeaponData()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesInteraction_C.__WeaponData_NativeFunctionPtr, null);
		}

		// Token: 0x06023C78 RID: 146552 RVA: 0x0098BE04 File Offset: 0x0098A004
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateParam(float dt)
		{
			BP_LeavesInteraction_C.__UpdateParam_FunctionParams* ptr = stackalloc BP_LeavesInteraction_C.__UpdateParam_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LeavesInteraction_C.__UpdateParam_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LeavesInteraction_C.__UpdateParam_NativeFunctionPtr, (void*)ptr, 1);
			ptr->dt = dt;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesInteraction_C.__UpdateParam_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023C79 RID: 146553 RVA: 0x0098BE4A File Offset: 0x0098A04A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesInteraction_C.__InitParam_NativeFunctionPtr, null);
		}

		// Token: 0x06023C7A RID: 146554 RVA: 0x0098BE5E File Offset: 0x0098A05E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesInteraction_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023C7B RID: 146555 RVA: 0x0098BE72 File Offset: 0x0098A072
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LeavesInteraction_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023C7C RID: 146556 RVA: 0x0098BE88 File Offset: 0x0098A088
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_LeavesInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LeavesInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LeavesInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LeavesInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023C7D RID: 146557 RVA: 0x0098BED0 File Offset: 0x0098A0D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_LeavesInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LeavesInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LeavesInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LeavesInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LeavesInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023C7E RID: 146558 RVA: 0x0098BF17 File Offset: 0x0098A117
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023C7F RID: 146559 RVA: 0x0098BF2B File Offset: 0x0098A12B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LeavesInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023C80 RID: 146560 RVA: 0x0098BF40 File Offset: 0x0098A140
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_LeavesInteraction_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_LeavesInteraction_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_LeavesInteraction_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LeavesInteraction_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesInteraction_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023C81 RID: 146561 RVA: 0x0098BFA3 File Offset: 0x0098A1A3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateQualitySwitch()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesInteraction_C.__UpdateQualitySwitch_NativeFunctionPtr, null);
		}

		// Token: 0x06023C82 RID: 146562 RVA: 0x0098BFB8 File Offset: 0x0098A1B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_LeavesInteraction(int EntryPoint)
		{
			BP_LeavesInteraction_C.__ExecuteUbergraph_BP_LeavesInteraction_FunctionParams* ptr = stackalloc BP_LeavesInteraction_C.__ExecuteUbergraph_BP_LeavesInteraction_FunctionParams[(UIntPtr)135] + 15L / (long)sizeof(BP_LeavesInteraction_C.__ExecuteUbergraph_BP_LeavesInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LeavesInteraction_C.__ExecuteUbergraph_BP_LeavesInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LeavesInteraction_C.__ExecuteUbergraph_BP_LeavesInteraction_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023C83 RID: 146563 RVA: 0x0098C002 File Offset: 0x0098A202
		protected BP_LeavesInteraction_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012401 RID: 74753
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/LeavesInteraction/BP_LeavesInteraction.BP_LeavesInteraction_C";

		// Token: 0x04012402 RID: 74754
		private static IntPtr _ClassPtr;

		// Token: 0x04012403 RID: 74755
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012404 RID: 74756
		internal static int __PropertyOffset_0;

		// Token: 0x04012405 RID: 74757
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012406 RID: 74758
		internal static int __PropertyOffset_1;

		// Token: 0x04012407 RID: 74759
		internal static int __PropertyOffset_2;

		// Token: 0x04012408 RID: 74760
		internal static int __PropertyOffset_3;

		// Token: 0x04012409 RID: 74761
		internal static int __PropertyOffset_4;

		// Token: 0x0401240A RID: 74762
		internal static int __PropertyOffset_5;

		// Token: 0x0401240B RID: 74763
		internal static int __PropertyOffset_6;

		// Token: 0x0401240C RID: 74764
		internal static int __PropertyOffset_7;

		// Token: 0x0401240D RID: 74765
		internal static int __PropertyOffset_8;

		// Token: 0x0401240E RID: 74766
		internal static int __PropertyOffset_9;

		// Token: 0x0401240F RID: 74767
		internal static int __PropertyOffset_10;

		// Token: 0x04012410 RID: 74768
		internal static int __PropertyOffset_11;

		// Token: 0x04012411 RID: 74769
		internal static int __PropertyOffset_12;

		// Token: 0x04012412 RID: 74770
		internal static int __PropertyOffset_13;

		// Token: 0x04012413 RID: 74771
		internal static int __PropertyOffset_14;

		// Token: 0x04012414 RID: 74772
		internal static int __PropertyOffset_15;

		// Token: 0x04012415 RID: 74773
		internal static int __PropertyOffset_16;

		// Token: 0x04012416 RID: 74774
		internal static int __PropertyOffset_17;

		// Token: 0x04012417 RID: 74775
		internal static int __PropertyOffset_18;

		// Token: 0x04012418 RID: 74776
		internal static int __PropertyOffset_19;

		// Token: 0x04012419 RID: 74777
		internal static int __PropertyOffset_20;

		// Token: 0x0401241A RID: 74778
		internal static int __PropertyOffset_21;

		// Token: 0x0401241B RID: 74779
		internal static int __PropertyOffset_22;

		// Token: 0x0401241C RID: 74780
		internal static int __PropertyOffset_23;

		// Token: 0x0401241D RID: 74781
		internal static int __PropertyOffset_24;

		// Token: 0x0401241E RID: 74782
		internal static int __PropertyOffset_25;

		// Token: 0x0401241F RID: 74783
		internal static int __PropertyOffset_26;

		// Token: 0x04012420 RID: 74784
		internal static int __PropertyOffset_27;

		// Token: 0x04012421 RID: 74785
		internal static int __PropertyOffset_28;

		// Token: 0x04012422 RID: 74786
		internal static int __PropertyOffset_29;

		// Token: 0x04012423 RID: 74787
		internal static int __PropertyOffset_30;

		// Token: 0x04012424 RID: 74788
		internal static int __PropertyOffset_31;

		// Token: 0x04012425 RID: 74789
		internal static int __PropertyOffset_32;

		// Token: 0x04012426 RID: 74790
		internal static int __PropertyOffset_33;

		// Token: 0x04012427 RID: 74791
		internal static int __PropertyOffset_34;

		// Token: 0x04012428 RID: 74792
		internal static int __PropertyOffset_35;

		// Token: 0x04012429 RID: 74793
		internal static int __PropertyOffset_36;

		// Token: 0x0401242A RID: 74794
		internal static int __PropertyOffset_37;

		// Token: 0x0401242B RID: 74795
		internal static int __PropertyOffset_38;

		// Token: 0x0401242C RID: 74796
		internal static int __PropertyOffset_39;

		// Token: 0x0401242D RID: 74797
		private static IntPtr __SetMaterialParam_NativeFunctionPtr;

		// Token: 0x0401242E RID: 74798
		private static IntPtr __SetLeavesParameters_NativeFunctionPtr;

		// Token: 0x0401242F RID: 74799
		private static IntPtr __Debug_NativeFunctionPtr;

		// Token: 0x04012430 RID: 74800
		private static IntPtr __Choose_Available_Point_NativeFunctionPtr;

		// Token: 0x04012431 RID: 74801
		private static IntPtr __WeaponData_NativeFunctionPtr;

		// Token: 0x04012432 RID: 74802
		private static IntPtr __UpdateParam_NativeFunctionPtr;

		// Token: 0x04012433 RID: 74803
		private static IntPtr __InitParam_NativeFunctionPtr;

		// Token: 0x04012434 RID: 74804
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012435 RID: 74805
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012436 RID: 74806
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012437 RID: 74807
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x04012438 RID: 74808
		private static IntPtr __UpdateQualitySwitch_NativeFunctionPtr;

		// Token: 0x04012439 RID: 74809
		private static IntPtr __ExecuteUbergraph_BP_LeavesInteraction_NativeFunctionPtr;

		// Token: 0x02009D3A RID: 40250
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __Choose_Available_Point_FunctionParams
		{
			// Token: 0x0403270C RID: 206604
			[FieldOffset(0)]
			public FVectorDouble CollisionPoint;

			// Token: 0x0403270D RID: 206605
			[FieldOffset(24)]
			public FVectorDouble WeaponPoint;

			// Token: 0x0403270E RID: 206606
			[FieldOffset(48)]
			public IntPtr ConfigDA;

			// Token: 0x0403270F RID: 206607
			[FieldOffset(56)]
			public FVectorDouble AvailblePoint;
		}

		// Token: 0x02009D3B RID: 40251
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __UpdateParam_FunctionParams
		{
			// Token: 0x04032710 RID: 206608
			[FieldOffset(0)]
			public float dt;
		}

		// Token: 0x02009D3C RID: 40252
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032711 RID: 206609
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D3D RID: 40253
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x04032712 RID: 206610
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x04032713 RID: 206611
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04032714 RID: 206612
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009D3E RID: 40254
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 120)]
		protected ref struct __ExecuteUbergraph_BP_LeavesInteraction_FunctionParams
		{
			// Token: 0x04032715 RID: 206613
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
