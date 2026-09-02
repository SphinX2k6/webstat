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
	// Token: 0x02003C64 RID: 15460
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/LeavesInteraction/BP_LeavesInteraction_SDF.BP_LeavesInteraction_SDF_C")]
	[UnrealStructLayout(1584, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1582)]
	public class BP_LeavesInteraction_SDF_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023C84 RID: 146564 RVA: 0x0098C00B File Offset: 0x0098A20B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_LeavesInteraction_SDF_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/LeavesInteraction/BP_LeavesInteraction_SDF.BP_LeavesInteraction_SDF_C");
			}
			return BP_LeavesInteraction_SDF_C._ClassPtr;
		}

		// Token: 0x06023C85 RID: 146565 RVA: 0x0098C030 File Offset: 0x0098A230
		public BP_LeavesInteraction_SDF_C() : this(BuiltinUtils.AllocNativeUObject(BP_LeavesInteraction_SDF_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023C86 RID: 146566 RVA: 0x0098C058 File Offset: 0x0098A258
		[NullableContext(1)]
		public BP_LeavesInteraction_SDF_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_LeavesInteraction_SDF_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700484A RID: 18506
		// (get) Token: 0x06023C87 RID: 146567 RVA: 0x0098C08C File Offset: 0x0098A28C
		// (set) Token: 0x06023C88 RID: 146568 RVA: 0x0098C0C5 File Offset: 0x0098A2C5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700484B RID: 18507
		// (get) Token: 0x06023C89 RID: 146569 RVA: 0x0098C0E6 File Offset: 0x0098A2E6
		// (set) Token: 0x06023C8A RID: 146570 RVA: 0x0098C0FA File Offset: 0x0098A2FA
		public unsafe UBoxComponent AreaBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_SDF_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_SDF_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700484C RID: 18508
		// (get) Token: 0x06023C8B RID: 146571 RVA: 0x0098C10F File Offset: 0x0098A30F
		// (set) Token: 0x06023C8C RID: 146572 RVA: 0x0098C123 File Offset: 0x0098A323
		public unsafe UNiagaraComponent NS_FX_LeavesInteraction
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_SDF_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_SDF_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700484D RID: 18509
		// (get) Token: 0x06023C8D RID: 146573 RVA: 0x0098C138 File Offset: 0x0098A338
		// (set) Token: 0x06023C8E RID: 146574 RVA: 0x0098C14C File Offset: 0x0098A34C
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_SDF_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_SDF_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700484E RID: 18510
		// (get) Token: 0x06023C8F RID: 146575 RVA: 0x0098C161 File Offset: 0x0098A361
		// (set) Token: 0x06023C90 RID: 146576 RVA: 0x0098C175 File Offset: 0x0098A375
		public unsafe FVector FieldSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700484F RID: 18511
		// (get) Token: 0x06023C91 RID: 146577 RVA: 0x0098C18A File Offset: 0x0098A38A
		// (set) Token: 0x06023C92 RID: 146578 RVA: 0x0098C19A File Offset: 0x0098A39A
		public unsafe int Resolution
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17004850 RID: 18512
		// (get) Token: 0x06023C93 RID: 146579 RVA: 0x0098C1AB File Offset: 0x0098A3AB
		// (set) Token: 0x06023C94 RID: 146580 RVA: 0x0098C1BF File Offset: 0x0098A3BF
		public unsafe FVector Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004851 RID: 18513
		// (get) Token: 0x06023C95 RID: 146581 RVA: 0x0098C1D4 File Offset: 0x0098A3D4
		// (set) Token: 0x06023C96 RID: 146582 RVA: 0x0098C1E8 File Offset: 0x0098A3E8
		public unsafe USkeletalMeshComponent Weapon
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_SDF_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_SDF_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004852 RID: 18514
		// (get) Token: 0x06023C97 RID: 146583 RVA: 0x0098C1FD File Offset: 0x0098A3FD
		// (set) Token: 0x06023C98 RID: 146584 RVA: 0x0098C211 File Offset: 0x0098A411
		public unsafe FVector LastWeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004853 RID: 18515
		// (get) Token: 0x06023C99 RID: 146585 RVA: 0x0098C226 File Offset: 0x0098A426
		// (set) Token: 0x06023C9A RID: 146586 RVA: 0x0098C23A File Offset: 0x0098A43A
		public unsafe FVector WeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004854 RID: 18516
		// (get) Token: 0x06023C9B RID: 146587 RVA: 0x0098C24F File Offset: 0x0098A44F
		// (set) Token: 0x06023C9C RID: 146588 RVA: 0x0098C263 File Offset: 0x0098A463
		public unsafe FVector WeaponVelocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17004855 RID: 18517
		// (get) Token: 0x06023C9D RID: 146589 RVA: 0x0098C278 File Offset: 0x0098A478
		// (set) Token: 0x06023C9E RID: 146590 RVA: 0x0098C28C File Offset: 0x0098A48C
		public unsafe UMaterialParameterCollection Global_MPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_SDF_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_SDF_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17004856 RID: 18518
		// (get) Token: 0x06023C9F RID: 146591 RVA: 0x0098C2A1 File Offset: 0x0098A4A1
		// (set) Token: 0x06023CA0 RID: 146592 RVA: 0x0098C2B1 File Offset: 0x0098A4B1
		public unsafe bool isClear
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004857 RID: 18519
		// (get) Token: 0x06023CA1 RID: 146593 RVA: 0x0098C2C2 File Offset: 0x0098A4C2
		// (set) Token: 0x06023CA2 RID: 146594 RVA: 0x0098C2D6 File Offset: 0x0098A4D6
		public unsafe FLinearColor GlobalWorldPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17004858 RID: 18520
		// (get) Token: 0x06023CA3 RID: 146595 RVA: 0x0098C2EB File Offset: 0x0098A4EB
		// (set) Token: 0x06023CA4 RID: 146596 RVA: 0x0098C2FB File Offset: 0x0098A4FB
		public unsafe float PlayerSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004859 RID: 18521
		// (get) Token: 0x06023CA5 RID: 146597 RVA: 0x0098C30C File Offset: 0x0098A50C
		// (set) Token: 0x06023CA6 RID: 146598 RVA: 0x0098C31C File Offset: 0x0098A51C
		public unsafe float WeaponSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700485A RID: 18522
		// (get) Token: 0x06023CA7 RID: 146599 RVA: 0x0098C32D File Offset: 0x0098A52D
		// (set) Token: 0x06023CA8 RID: 146600 RVA: 0x0098C341 File Offset: 0x0098A541
		public unsafe FVector DepthCapturePosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x1700485B RID: 18523
		// (get) Token: 0x06023CA9 RID: 146601 RVA: 0x0098C356 File Offset: 0x0098A556
		// (set) Token: 0x06023CAA RID: 146602 RVA: 0x0098C36A File Offset: 0x0098A56A
		public unsafe UTexture DepthTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_SDF_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_SDF_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x1700485C RID: 18524
		// (get) Token: 0x06023CAB RID: 146603 RVA: 0x0098C37F File Offset: 0x0098A57F
		// (set) Token: 0x06023CAC RID: 146604 RVA: 0x0098C38F File Offset: 0x0098A58F
		public unsafe int LeavesIDStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700485D RID: 18525
		// (get) Token: 0x06023CAD RID: 146605 RVA: 0x0098C3A0 File Offset: 0x0098A5A0
		// (set) Token: 0x06023CAE RID: 146606 RVA: 0x0098C3B0 File Offset: 0x0098A5B0
		public unsafe int LeavesIDEnd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x1700485E RID: 18526
		// (get) Token: 0x06023CAF RID: 146607 RVA: 0x0098C3C1 File Offset: 0x0098A5C1
		// (set) Token: 0x06023CB0 RID: 146608 RVA: 0x0098C3D1 File Offset: 0x0098A5D1
		public unsafe int LeavesNum
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x1700485F RID: 18527
		// (get) Token: 0x06023CB1 RID: 146609 RVA: 0x0098C3E2 File Offset: 0x0098A5E2
		// (set) Token: 0x06023CB2 RID: 146610 RVA: 0x0098C3F2 File Offset: 0x0098A5F2
		public unsafe float BoxSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17004860 RID: 18528
		// (get) Token: 0x06023CB3 RID: 146611 RVA: 0x0098C403 File Offset: 0x0098A603
		// (set) Token: 0x06023CB4 RID: 146612 RVA: 0x0098C413 File Offset: 0x0098A613
		public unsafe float LeavesScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17004861 RID: 18529
		// (get) Token: 0x06023CB5 RID: 146613 RVA: 0x0098C424 File Offset: 0x0098A624
		// (set) Token: 0x06023CB6 RID: 146614 RVA: 0x0098C434 File Offset: 0x0098A634
		public unsafe int LUTIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17004862 RID: 18530
		// (get) Token: 0x06023CB7 RID: 146615 RVA: 0x0098C445 File Offset: 0x0098A645
		// (set) Token: 0x06023CB8 RID: 146616 RVA: 0x0098C455 File Offset: 0x0098A655
		public unsafe float LeavesRoughness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17004863 RID: 18531
		// (get) Token: 0x06023CB9 RID: 146617 RVA: 0x0098C466 File Offset: 0x0098A666
		// (set) Token: 0x06023CBA RID: 146618 RVA: 0x0098C476 File Offset: 0x0098A676
		public unsafe float LeavesAO
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17004864 RID: 18532
		// (get) Token: 0x06023CBB RID: 146619 RVA: 0x0098C487 File Offset: 0x0098A687
		// (set) Token: 0x06023CBC RID: 146620 RVA: 0x0098C497 File Offset: 0x0098A697
		public unsafe float LutProbabilityPower
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17004865 RID: 18533
		// (get) Token: 0x06023CBD RID: 146621 RVA: 0x0098C4A8 File Offset: 0x0098A6A8
		// (set) Token: 0x06023CBE RID: 146622 RVA: 0x0098C4BC File Offset: 0x0098A6BC
		public unsafe UTexture LeavesMaskTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_SDF_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_SDF_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x17004866 RID: 18534
		// (get) Token: 0x06023CBF RID: 146623 RVA: 0x0098C4D1 File Offset: 0x0098A6D1
		// (set) Token: 0x06023CC0 RID: 146624 RVA: 0x0098C4E1 File Offset: 0x0098A6E1
		public unsafe bool UseLUT
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004867 RID: 18535
		// (get) Token: 0x06023CC1 RID: 146625 RVA: 0x0098C4F2 File Offset: 0x0098A6F2
		// (set) Token: 0x06023CC2 RID: 146626 RVA: 0x0098C502 File Offset: 0x0098A702
		public unsafe float OffsetDis
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17004868 RID: 18536
		// (get) Token: 0x06023CC3 RID: 146627 RVA: 0x0098C513 File Offset: 0x0098A713
		// (set) Token: 0x06023CC4 RID: 146628 RVA: 0x0098C527 File Offset: 0x0098A727
		public unsafe FVector BPPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17004869 RID: 18537
		// (get) Token: 0x06023CC5 RID: 146629 RVA: 0x0098C53C File Offset: 0x0098A73C
		// (set) Token: 0x06023CC6 RID: 146630 RVA: 0x0098C54C File Offset: 0x0098A74C
		public unsafe float CullingHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x1700486A RID: 18538
		// (get) Token: 0x06023CC7 RID: 146631 RVA: 0x0098C55D File Offset: 0x0098A75D
		// (set) Token: 0x06023CC8 RID: 146632 RVA: 0x0098C571 File Offset: 0x0098A771
		public unsafe FVector RuntimeDepthCapturePos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x1700486B RID: 18539
		// (get) Token: 0x06023CC9 RID: 146633 RVA: 0x0098C586 File Offset: 0x0098A786
		// (set) Token: 0x06023CCA RID: 146634 RVA: 0x0098C59A File Offset: 0x0098A79A
		public unsafe UTexture RuntimeDepthTex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_SDF_C.__PropertyOffset_33);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesInteraction_SDF_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x1700486C RID: 18540
		// (get) Token: 0x06023CCB RID: 146635 RVA: 0x0098C5AF File Offset: 0x0098A7AF
		// (set) Token: 0x06023CCC RID: 146636 RVA: 0x0098C5C3 File Offset: 0x0098A7C3
		public unsafe FVector RuntimeDepthCaptureBoxSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x1700486D RID: 18541
		// (get) Token: 0x06023CCD RID: 146637 RVA: 0x0098C5D8 File Offset: 0x0098A7D8
		// (set) Token: 0x06023CCE RID: 146638 RVA: 0x0098C5E8 File Offset: 0x0098A7E8
		public unsafe bool UseRuntimeCapture
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_35) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_35) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700486E RID: 18542
		// (get) Token: 0x06023CCF RID: 146639 RVA: 0x0098C5F9 File Offset: 0x0098A7F9
		// (set) Token: 0x06023CD0 RID: 146640 RVA: 0x0098C609 File Offset: 0x0098A809
		public unsafe bool bHideInLowQuality
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_36) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesInteraction_SDF_C.__PropertyOffset_36) = (value ? 1 : 0);
			}
		}

		// Token: 0x06023CD1 RID: 146641 RVA: 0x0098C61A File Offset: 0x0098A81A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetLeavesParameters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesInteraction_SDF_C.__SetLeavesParameters_NativeFunctionPtr, null);
		}

		// Token: 0x06023CD2 RID: 146642 RVA: 0x0098C62E File Offset: 0x0098A82E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Debug()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesInteraction_SDF_C.__Debug_NativeFunctionPtr, null);
		}

		// Token: 0x06023CD3 RID: 146643 RVA: 0x0098C644 File Offset: 0x0098A844
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Choose_Available_Point(FVectorDouble CollisionPoint, FVectorDouble WeaponPoint, BP_SceneBattleInteract_C ConfigDA, ref FVectorDouble AvailblePoint)
		{
			BP_LeavesInteraction_SDF_C.__Choose_Available_Point_FunctionParams* ptr = stackalloc BP_LeavesInteraction_SDF_C.__Choose_Available_Point_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_LeavesInteraction_SDF_C.__Choose_Available_Point_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LeavesInteraction_SDF_C.__Choose_Available_Point_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CollisionPoint = CollisionPoint;
			ptr->WeaponPoint = WeaponPoint;
			ptr->ConfigDA = ((ConfigDA != null) ? ConfigDA.NativePtr : IntPtr.Zero);
			ptr->AvailblePoint = AvailblePoint;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesInteraction_SDF_C.__Choose_Available_Point_NativeFunctionPtr, (void*)ptr);
			AvailblePoint = ptr->AvailblePoint;
		}

		// Token: 0x06023CD4 RID: 146644 RVA: 0x0098C6C1 File Offset: 0x0098A8C1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void WeaponData()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesInteraction_SDF_C.__WeaponData_NativeFunctionPtr, null);
		}

		// Token: 0x06023CD5 RID: 146645 RVA: 0x0098C6D8 File Offset: 0x0098A8D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateParam(float dt)
		{
			BP_LeavesInteraction_SDF_C.__UpdateParam_FunctionParams* ptr = stackalloc BP_LeavesInteraction_SDF_C.__UpdateParam_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(BP_LeavesInteraction_SDF_C.__UpdateParam_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LeavesInteraction_SDF_C.__UpdateParam_NativeFunctionPtr, (void*)ptr, 1);
			ptr->dt = dt;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesInteraction_SDF_C.__UpdateParam_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023CD6 RID: 146646 RVA: 0x0098C71E File Offset: 0x0098A91E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesInteraction_SDF_C.__InitParam_NativeFunctionPtr, null);
		}

		// Token: 0x06023CD7 RID: 146647 RVA: 0x0098C732 File Offset: 0x0098A932
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesInteraction_SDF_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023CD8 RID: 146648 RVA: 0x0098C746 File Offset: 0x0098A946
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LeavesInteraction_SDF_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023CD9 RID: 146649 RVA: 0x0098C75C File Offset: 0x0098A95C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_LeavesInteraction_SDF_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LeavesInteraction_SDF_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LeavesInteraction_SDF_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LeavesInteraction_SDF_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesInteraction_SDF_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023CDA RID: 146650 RVA: 0x0098C7A4 File Offset: 0x0098A9A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_LeavesInteraction_SDF_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LeavesInteraction_SDF_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LeavesInteraction_SDF_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LeavesInteraction_SDF_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LeavesInteraction_SDF_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023CDB RID: 146651 RVA: 0x0098C7EB File Offset: 0x0098A9EB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesInteraction_SDF_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023CDC RID: 146652 RVA: 0x0098C7FF File Offset: 0x0098A9FF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LeavesInteraction_SDF_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023CDD RID: 146653 RVA: 0x0098C814 File Offset: 0x0098AA14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_LeavesInteraction_SDF_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_LeavesInteraction_SDF_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_LeavesInteraction_SDF_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LeavesInteraction_SDF_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesInteraction_SDF_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023CDE RID: 146654 RVA: 0x0098C877 File Offset: 0x0098AA77
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateQualitySwitch()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesInteraction_SDF_C.__UpdateQualitySwitch_NativeFunctionPtr, null);
		}

		// Token: 0x06023CDF RID: 146655 RVA: 0x0098C88C File Offset: 0x0098AA8C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_LeavesInteraction_SDF(int EntryPoint)
		{
			BP_LeavesInteraction_SDF_C.__ExecuteUbergraph_BP_LeavesInteraction_SDF_FunctionParams* ptr = stackalloc BP_LeavesInteraction_SDF_C.__ExecuteUbergraph_BP_LeavesInteraction_SDF_FunctionParams[(UIntPtr)135] + 15L / (long)sizeof(BP_LeavesInteraction_SDF_C.__ExecuteUbergraph_BP_LeavesInteraction_SDF_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LeavesInteraction_SDF_C.__ExecuteUbergraph_BP_LeavesInteraction_SDF_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LeavesInteraction_SDF_C.__ExecuteUbergraph_BP_LeavesInteraction_SDF_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023CE0 RID: 146656 RVA: 0x0098C8D6 File Offset: 0x0098AAD6
		protected BP_LeavesInteraction_SDF_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401243A RID: 74810
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/LeavesInteraction/BP_LeavesInteraction_SDF.BP_LeavesInteraction_SDF_C";

		// Token: 0x0401243B RID: 74811
		private static IntPtr _ClassPtr;

		// Token: 0x0401243C RID: 74812
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401243D RID: 74813
		internal static int __PropertyOffset_0;

		// Token: 0x0401243E RID: 74814
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401243F RID: 74815
		internal static int __PropertyOffset_1;

		// Token: 0x04012440 RID: 74816
		internal static int __PropertyOffset_2;

		// Token: 0x04012441 RID: 74817
		internal static int __PropertyOffset_3;

		// Token: 0x04012442 RID: 74818
		internal static int __PropertyOffset_4;

		// Token: 0x04012443 RID: 74819
		internal static int __PropertyOffset_5;

		// Token: 0x04012444 RID: 74820
		internal static int __PropertyOffset_6;

		// Token: 0x04012445 RID: 74821
		internal static int __PropertyOffset_7;

		// Token: 0x04012446 RID: 74822
		internal static int __PropertyOffset_8;

		// Token: 0x04012447 RID: 74823
		internal static int __PropertyOffset_9;

		// Token: 0x04012448 RID: 74824
		internal static int __PropertyOffset_10;

		// Token: 0x04012449 RID: 74825
		internal static int __PropertyOffset_11;

		// Token: 0x0401244A RID: 74826
		internal static int __PropertyOffset_12;

		// Token: 0x0401244B RID: 74827
		internal static int __PropertyOffset_13;

		// Token: 0x0401244C RID: 74828
		internal static int __PropertyOffset_14;

		// Token: 0x0401244D RID: 74829
		internal static int __PropertyOffset_15;

		// Token: 0x0401244E RID: 74830
		internal static int __PropertyOffset_16;

		// Token: 0x0401244F RID: 74831
		internal static int __PropertyOffset_17;

		// Token: 0x04012450 RID: 74832
		internal static int __PropertyOffset_18;

		// Token: 0x04012451 RID: 74833
		internal static int __PropertyOffset_19;

		// Token: 0x04012452 RID: 74834
		internal static int __PropertyOffset_20;

		// Token: 0x04012453 RID: 74835
		internal static int __PropertyOffset_21;

		// Token: 0x04012454 RID: 74836
		internal static int __PropertyOffset_22;

		// Token: 0x04012455 RID: 74837
		internal static int __PropertyOffset_23;

		// Token: 0x04012456 RID: 74838
		internal static int __PropertyOffset_24;

		// Token: 0x04012457 RID: 74839
		internal static int __PropertyOffset_25;

		// Token: 0x04012458 RID: 74840
		internal static int __PropertyOffset_26;

		// Token: 0x04012459 RID: 74841
		internal static int __PropertyOffset_27;

		// Token: 0x0401245A RID: 74842
		internal static int __PropertyOffset_28;

		// Token: 0x0401245B RID: 74843
		internal static int __PropertyOffset_29;

		// Token: 0x0401245C RID: 74844
		internal static int __PropertyOffset_30;

		// Token: 0x0401245D RID: 74845
		internal static int __PropertyOffset_31;

		// Token: 0x0401245E RID: 74846
		internal static int __PropertyOffset_32;

		// Token: 0x0401245F RID: 74847
		internal static int __PropertyOffset_33;

		// Token: 0x04012460 RID: 74848
		internal static int __PropertyOffset_34;

		// Token: 0x04012461 RID: 74849
		internal static int __PropertyOffset_35;

		// Token: 0x04012462 RID: 74850
		internal static int __PropertyOffset_36;

		// Token: 0x04012463 RID: 74851
		private static IntPtr __SetLeavesParameters_NativeFunctionPtr;

		// Token: 0x04012464 RID: 74852
		private static IntPtr __Debug_NativeFunctionPtr;

		// Token: 0x04012465 RID: 74853
		private static IntPtr __Choose_Available_Point_NativeFunctionPtr;

		// Token: 0x04012466 RID: 74854
		private static IntPtr __WeaponData_NativeFunctionPtr;

		// Token: 0x04012467 RID: 74855
		private static IntPtr __UpdateParam_NativeFunctionPtr;

		// Token: 0x04012468 RID: 74856
		private static IntPtr __InitParam_NativeFunctionPtr;

		// Token: 0x04012469 RID: 74857
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401246A RID: 74858
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401246B RID: 74859
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401246C RID: 74860
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x0401246D RID: 74861
		private static IntPtr __UpdateQualitySwitch_NativeFunctionPtr;

		// Token: 0x0401246E RID: 74862
		private static IntPtr __ExecuteUbergraph_BP_LeavesInteraction_SDF_NativeFunctionPtr;

		// Token: 0x02009D3F RID: 40255
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __Choose_Available_Point_FunctionParams
		{
			// Token: 0x04032716 RID: 206614
			[FieldOffset(0)]
			public FVectorDouble CollisionPoint;

			// Token: 0x04032717 RID: 206615
			[FieldOffset(24)]
			public FVectorDouble WeaponPoint;

			// Token: 0x04032718 RID: 206616
			[FieldOffset(48)]
			public IntPtr ConfigDA;

			// Token: 0x04032719 RID: 206617
			[FieldOffset(56)]
			public FVectorDouble AvailblePoint;
		}

		// Token: 0x02009D40 RID: 40256
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __UpdateParam_FunctionParams
		{
			// Token: 0x0403271A RID: 206618
			[FieldOffset(0)]
			public float dt;
		}

		// Token: 0x02009D41 RID: 40257
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403271B RID: 206619
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D42 RID: 40258
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x0403271C RID: 206620
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x0403271D RID: 206621
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x0403271E RID: 206622
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009D43 RID: 40259
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 120)]
		protected ref struct __ExecuteUbergraph_BP_LeavesInteraction_SDF_FunctionParams
		{
			// Token: 0x0403271F RID: 206623
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
