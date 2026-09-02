using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FeathersInteraction
{
	// Token: 0x02003D1A RID: 15642
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FeathersInteraction/BP_FeathersInteraction.BP_FeathersInteraction_C")]
	[UnrealStructLayout(1272, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1268)]
	public class BP_FeathersInteraction_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025C6B RID: 154731 RVA: 0x009C4D04 File Offset: 0x009C2F04
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FeathersInteraction_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/FeathersInteraction/BP_FeathersInteraction.BP_FeathersInteraction_C");
			}
			return BP_FeathersInteraction_C._ClassPtr;
		}

		// Token: 0x06025C6C RID: 154732 RVA: 0x009C4D28 File Offset: 0x009C2F28
		public BP_FeathersInteraction_C() : this(BuiltinUtils.AllocNativeUObject(BP_FeathersInteraction_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025C6D RID: 154733 RVA: 0x009C4D50 File Offset: 0x009C2F50
		[NullableContext(1)]
		public BP_FeathersInteraction_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FeathersInteraction_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170053A7 RID: 21415
		// (get) Token: 0x06025C6E RID: 154734 RVA: 0x009C4D84 File Offset: 0x009C2F84
		// (set) Token: 0x06025C6F RID: 154735 RVA: 0x009C4DBD File Offset: 0x009C2FBD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170053A8 RID: 21416
		// (get) Token: 0x06025C70 RID: 154736 RVA: 0x009C4DDE File Offset: 0x009C2FDE
		// (set) Token: 0x06025C71 RID: 154737 RVA: 0x009C4DF2 File Offset: 0x009C2FF2
		public unsafe UBoxComponent AreaBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FeathersInteraction_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FeathersInteraction_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170053A9 RID: 21417
		// (get) Token: 0x06025C72 RID: 154738 RVA: 0x009C4E07 File Offset: 0x009C3007
		// (set) Token: 0x06025C73 RID: 154739 RVA: 0x009C4E1B File Offset: 0x009C301B
		public unsafe UNiagaraComponent NS_FX_FeathersInteraction
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FeathersInteraction_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FeathersInteraction_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170053AA RID: 21418
		// (get) Token: 0x06025C74 RID: 154740 RVA: 0x009C4E30 File Offset: 0x009C3030
		// (set) Token: 0x06025C75 RID: 154741 RVA: 0x009C4E44 File Offset: 0x009C3044
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FeathersInteraction_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FeathersInteraction_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170053AB RID: 21419
		// (get) Token: 0x06025C76 RID: 154742 RVA: 0x009C4E59 File Offset: 0x009C3059
		// (set) Token: 0x06025C77 RID: 154743 RVA: 0x009C4E6D File Offset: 0x009C306D
		public unsafe FVector FieldSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170053AC RID: 21420
		// (get) Token: 0x06025C78 RID: 154744 RVA: 0x009C4E82 File Offset: 0x009C3082
		// (set) Token: 0x06025C79 RID: 154745 RVA: 0x009C4E92 File Offset: 0x009C3092
		public unsafe int Resolution
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170053AD RID: 21421
		// (get) Token: 0x06025C7A RID: 154746 RVA: 0x009C4EA3 File Offset: 0x009C30A3
		// (set) Token: 0x06025C7B RID: 154747 RVA: 0x009C4EB7 File Offset: 0x009C30B7
		public unsafe FVector Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170053AE RID: 21422
		// (get) Token: 0x06025C7C RID: 154748 RVA: 0x009C4ECC File Offset: 0x009C30CC
		// (set) Token: 0x06025C7D RID: 154749 RVA: 0x009C4EE0 File Offset: 0x009C30E0
		public unsafe USkeletalMeshComponent Weapon
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FeathersInteraction_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FeathersInteraction_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170053AF RID: 21423
		// (get) Token: 0x06025C7E RID: 154750 RVA: 0x009C4EF5 File Offset: 0x009C30F5
		// (set) Token: 0x06025C7F RID: 154751 RVA: 0x009C4F09 File Offset: 0x009C3109
		public unsafe FVector LastWeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170053B0 RID: 21424
		// (get) Token: 0x06025C80 RID: 154752 RVA: 0x009C4F1E File Offset: 0x009C311E
		// (set) Token: 0x06025C81 RID: 154753 RVA: 0x009C4F32 File Offset: 0x009C3132
		public unsafe FVector WeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170053B1 RID: 21425
		// (get) Token: 0x06025C82 RID: 154754 RVA: 0x009C4F47 File Offset: 0x009C3147
		// (set) Token: 0x06025C83 RID: 154755 RVA: 0x009C4F5B File Offset: 0x009C315B
		public unsafe FVector WeaponVelocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170053B2 RID: 21426
		// (get) Token: 0x06025C84 RID: 154756 RVA: 0x009C4F70 File Offset: 0x009C3170
		// (set) Token: 0x06025C85 RID: 154757 RVA: 0x009C4F84 File Offset: 0x009C3184
		public unsafe UMaterialParameterCollection Global_MPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FeathersInteraction_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FeathersInteraction_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x170053B3 RID: 21427
		// (get) Token: 0x06025C86 RID: 154758 RVA: 0x009C4F99 File Offset: 0x009C3199
		// (set) Token: 0x06025C87 RID: 154759 RVA: 0x009C4FA9 File Offset: 0x009C31A9
		public unsafe bool isClear
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x170053B4 RID: 21428
		// (get) Token: 0x06025C88 RID: 154760 RVA: 0x009C4FBA File Offset: 0x009C31BA
		// (set) Token: 0x06025C89 RID: 154761 RVA: 0x009C4FCE File Offset: 0x009C31CE
		public unsafe FLinearColor GlobalWorldPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170053B5 RID: 21429
		// (get) Token: 0x06025C8A RID: 154762 RVA: 0x009C4FE3 File Offset: 0x009C31E3
		// (set) Token: 0x06025C8B RID: 154763 RVA: 0x009C4FF3 File Offset: 0x009C31F3
		public unsafe float PlayerSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170053B6 RID: 21430
		// (get) Token: 0x06025C8C RID: 154764 RVA: 0x009C5004 File Offset: 0x009C3204
		// (set) Token: 0x06025C8D RID: 154765 RVA: 0x009C5014 File Offset: 0x009C3214
		public unsafe float WeaponSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170053B7 RID: 21431
		// (get) Token: 0x06025C8E RID: 154766 RVA: 0x009C5025 File Offset: 0x009C3225
		// (set) Token: 0x06025C8F RID: 154767 RVA: 0x009C5039 File Offset: 0x009C3239
		public unsafe FVector DepthCapturePosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170053B8 RID: 21432
		// (get) Token: 0x06025C90 RID: 154768 RVA: 0x009C504E File Offset: 0x009C324E
		// (set) Token: 0x06025C91 RID: 154769 RVA: 0x009C5062 File Offset: 0x009C3262
		public unsafe UTexture DepthTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FeathersInteraction_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FeathersInteraction_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x170053B9 RID: 21433
		// (get) Token: 0x06025C92 RID: 154770 RVA: 0x009C5077 File Offset: 0x009C3277
		// (set) Token: 0x06025C93 RID: 154771 RVA: 0x009C5087 File Offset: 0x009C3287
		public unsafe int LeavesIDStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170053BA RID: 21434
		// (get) Token: 0x06025C94 RID: 154772 RVA: 0x009C5098 File Offset: 0x009C3298
		// (set) Token: 0x06025C95 RID: 154773 RVA: 0x009C50A8 File Offset: 0x009C32A8
		public unsafe int LeavesIDEnd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170053BB RID: 21435
		// (get) Token: 0x06025C96 RID: 154774 RVA: 0x009C50B9 File Offset: 0x009C32B9
		// (set) Token: 0x06025C97 RID: 154775 RVA: 0x009C50C9 File Offset: 0x009C32C9
		public unsafe int LeavesNum
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170053BC RID: 21436
		// (get) Token: 0x06025C98 RID: 154776 RVA: 0x009C50DA File Offset: 0x009C32DA
		// (set) Token: 0x06025C99 RID: 154777 RVA: 0x009C50EA File Offset: 0x009C32EA
		public unsafe float BoxSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x170053BD RID: 21437
		// (get) Token: 0x06025C9A RID: 154778 RVA: 0x009C50FB File Offset: 0x009C32FB
		// (set) Token: 0x06025C9B RID: 154779 RVA: 0x009C510B File Offset: 0x009C330B
		public unsafe float LeavesScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x170053BE RID: 21438
		// (get) Token: 0x06025C9C RID: 154780 RVA: 0x009C511C File Offset: 0x009C331C
		// (set) Token: 0x06025C9D RID: 154781 RVA: 0x009C512C File Offset: 0x009C332C
		public unsafe int LUTIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x170053BF RID: 21439
		// (get) Token: 0x06025C9E RID: 154782 RVA: 0x009C513D File Offset: 0x009C333D
		// (set) Token: 0x06025C9F RID: 154783 RVA: 0x009C514D File Offset: 0x009C334D
		public unsafe float LeavesRoughness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x170053C0 RID: 21440
		// (get) Token: 0x06025CA0 RID: 154784 RVA: 0x009C515E File Offset: 0x009C335E
		// (set) Token: 0x06025CA1 RID: 154785 RVA: 0x009C516E File Offset: 0x009C336E
		public unsafe float LeavesAO
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x170053C1 RID: 21441
		// (get) Token: 0x06025CA2 RID: 154786 RVA: 0x009C517F File Offset: 0x009C337F
		// (set) Token: 0x06025CA3 RID: 154787 RVA: 0x009C518F File Offset: 0x009C338F
		public unsafe float LutProbabilityPower
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x170053C2 RID: 21442
		// (get) Token: 0x06025CA4 RID: 154788 RVA: 0x009C51A0 File Offset: 0x009C33A0
		// (set) Token: 0x06025CA5 RID: 154789 RVA: 0x009C51B4 File Offset: 0x009C33B4
		public unsafe UTexture LeavesMaskTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FeathersInteraction_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FeathersInteraction_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x170053C3 RID: 21443
		// (get) Token: 0x06025CA6 RID: 154790 RVA: 0x009C51C9 File Offset: 0x009C33C9
		// (set) Token: 0x06025CA7 RID: 154791 RVA: 0x009C51D9 File Offset: 0x009C33D9
		public unsafe bool UseLUT
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x170053C4 RID: 21444
		// (get) Token: 0x06025CA8 RID: 154792 RVA: 0x009C51EA File Offset: 0x009C33EA
		// (set) Token: 0x06025CA9 RID: 154793 RVA: 0x009C51FA File Offset: 0x009C33FA
		public unsafe float Transparency
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x170053C5 RID: 21445
		// (get) Token: 0x06025CAA RID: 154794 RVA: 0x009C520B File Offset: 0x009C340B
		// (set) Token: 0x06025CAB RID: 154795 RVA: 0x009C521B File Offset: 0x009C341B
		public unsafe float GenerationHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x170053C6 RID: 21446
		// (get) Token: 0x06025CAC RID: 154796 RVA: 0x009C522C File Offset: 0x009C342C
		// (set) Token: 0x06025CAD RID: 154797 RVA: 0x009C523C File Offset: 0x009C343C
		public unsafe float PercentageInTheAir
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x170053C7 RID: 21447
		// (get) Token: 0x06025CAE RID: 154798 RVA: 0x009C524D File Offset: 0x009C344D
		// (set) Token: 0x06025CAF RID: 154799 RVA: 0x009C525D File Offset: 0x009C345D
		public unsafe float StayTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FeathersInteraction_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x06025CB0 RID: 154800 RVA: 0x009C526E File Offset: 0x009C346E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetLeavesParameters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FeathersInteraction_C.__SetLeavesParameters_NativeFunctionPtr, null);
		}

		// Token: 0x06025CB1 RID: 154801 RVA: 0x009C5282 File Offset: 0x009C3482
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Debug()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FeathersInteraction_C.__Debug_NativeFunctionPtr, null);
		}

		// Token: 0x06025CB2 RID: 154802 RVA: 0x009C5298 File Offset: 0x009C3498
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Choose_Available_Point(FVectorDouble CollisionPoint, FVectorDouble WeaponPoint, BP_SceneBattleInteract_C ConfigDA, ref FVectorDouble AvailblePoint)
		{
			BP_FeathersInteraction_C.__Choose_Available_Point_FunctionParams* ptr = stackalloc BP_FeathersInteraction_C.__Choose_Available_Point_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_FeathersInteraction_C.__Choose_Available_Point_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FeathersInteraction_C.__Choose_Available_Point_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CollisionPoint = CollisionPoint;
			ptr->WeaponPoint = WeaponPoint;
			ptr->ConfigDA = ((ConfigDA != null) ? ConfigDA.NativePtr : IntPtr.Zero);
			ptr->AvailblePoint = AvailblePoint;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FeathersInteraction_C.__Choose_Available_Point_NativeFunctionPtr, (void*)ptr);
			AvailblePoint = ptr->AvailblePoint;
		}

		// Token: 0x06025CB3 RID: 154803 RVA: 0x009C5315 File Offset: 0x009C3515
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void WeaponData()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FeathersInteraction_C.__WeaponData_NativeFunctionPtr, null);
		}

		// Token: 0x06025CB4 RID: 154804 RVA: 0x009C532C File Offset: 0x009C352C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateParam(float dt)
		{
			BP_FeathersInteraction_C.__UpdateParam_FunctionParams* ptr = stackalloc BP_FeathersInteraction_C.__UpdateParam_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_FeathersInteraction_C.__UpdateParam_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FeathersInteraction_C.__UpdateParam_NativeFunctionPtr, (void*)ptr, 1);
			ptr->dt = dt;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FeathersInteraction_C.__UpdateParam_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025CB5 RID: 154805 RVA: 0x009C5372 File Offset: 0x009C3572
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FeathersInteraction_C.__InitParam_NativeFunctionPtr, null);
		}

		// Token: 0x06025CB6 RID: 154806 RVA: 0x009C5386 File Offset: 0x009C3586
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FeathersInteraction_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06025CB7 RID: 154807 RVA: 0x009C539A File Offset: 0x009C359A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FeathersInteraction_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025CB8 RID: 154808 RVA: 0x009C53B0 File Offset: 0x009C35B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_FeathersInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FeathersInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FeathersInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FeathersInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FeathersInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025CB9 RID: 154809 RVA: 0x009C53F8 File Offset: 0x009C35F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_FeathersInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FeathersInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FeathersInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FeathersInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FeathersInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025CBA RID: 154810 RVA: 0x009C543F File Offset: 0x009C363F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FeathersInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06025CBB RID: 154811 RVA: 0x009C5453 File Offset: 0x009C3653
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FeathersInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025CBC RID: 154812 RVA: 0x009C5468 File Offset: 0x009C3668
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_FeathersInteraction_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_FeathersInteraction_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_FeathersInteraction_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FeathersInteraction_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FeathersInteraction_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025CBD RID: 154813 RVA: 0x009C54CC File Offset: 0x009C36CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_FeathersInteraction(int EntryPoint)
		{
			BP_FeathersInteraction_C.__ExecuteUbergraph_BP_FeathersInteraction_FunctionParams* ptr = stackalloc BP_FeathersInteraction_C.__ExecuteUbergraph_BP_FeathersInteraction_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_FeathersInteraction_C.__ExecuteUbergraph_BP_FeathersInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FeathersInteraction_C.__ExecuteUbergraph_BP_FeathersInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FeathersInteraction_C.__ExecuteUbergraph_BP_FeathersInteraction_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025CBE RID: 154814 RVA: 0x009C5513 File Offset: 0x009C3713
		protected BP_FeathersInteraction_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401384B RID: 79947
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FeathersInteraction/BP_FeathersInteraction.BP_FeathersInteraction_C";

		// Token: 0x0401384C RID: 79948
		private static IntPtr _ClassPtr;

		// Token: 0x0401384D RID: 79949
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401384E RID: 79950
		internal static int __PropertyOffset_0;

		// Token: 0x0401384F RID: 79951
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013850 RID: 79952
		internal static int __PropertyOffset_1;

		// Token: 0x04013851 RID: 79953
		internal static int __PropertyOffset_2;

		// Token: 0x04013852 RID: 79954
		internal static int __PropertyOffset_3;

		// Token: 0x04013853 RID: 79955
		internal static int __PropertyOffset_4;

		// Token: 0x04013854 RID: 79956
		internal static int __PropertyOffset_5;

		// Token: 0x04013855 RID: 79957
		internal static int __PropertyOffset_6;

		// Token: 0x04013856 RID: 79958
		internal static int __PropertyOffset_7;

		// Token: 0x04013857 RID: 79959
		internal static int __PropertyOffset_8;

		// Token: 0x04013858 RID: 79960
		internal static int __PropertyOffset_9;

		// Token: 0x04013859 RID: 79961
		internal static int __PropertyOffset_10;

		// Token: 0x0401385A RID: 79962
		internal static int __PropertyOffset_11;

		// Token: 0x0401385B RID: 79963
		internal static int __PropertyOffset_12;

		// Token: 0x0401385C RID: 79964
		internal static int __PropertyOffset_13;

		// Token: 0x0401385D RID: 79965
		internal static int __PropertyOffset_14;

		// Token: 0x0401385E RID: 79966
		internal static int __PropertyOffset_15;

		// Token: 0x0401385F RID: 79967
		internal static int __PropertyOffset_16;

		// Token: 0x04013860 RID: 79968
		internal static int __PropertyOffset_17;

		// Token: 0x04013861 RID: 79969
		internal static int __PropertyOffset_18;

		// Token: 0x04013862 RID: 79970
		internal static int __PropertyOffset_19;

		// Token: 0x04013863 RID: 79971
		internal static int __PropertyOffset_20;

		// Token: 0x04013864 RID: 79972
		internal static int __PropertyOffset_21;

		// Token: 0x04013865 RID: 79973
		internal static int __PropertyOffset_22;

		// Token: 0x04013866 RID: 79974
		internal static int __PropertyOffset_23;

		// Token: 0x04013867 RID: 79975
		internal static int __PropertyOffset_24;

		// Token: 0x04013868 RID: 79976
		internal static int __PropertyOffset_25;

		// Token: 0x04013869 RID: 79977
		internal static int __PropertyOffset_26;

		// Token: 0x0401386A RID: 79978
		internal static int __PropertyOffset_27;

		// Token: 0x0401386B RID: 79979
		internal static int __PropertyOffset_28;

		// Token: 0x0401386C RID: 79980
		internal static int __PropertyOffset_29;

		// Token: 0x0401386D RID: 79981
		internal static int __PropertyOffset_30;

		// Token: 0x0401386E RID: 79982
		internal static int __PropertyOffset_31;

		// Token: 0x0401386F RID: 79983
		internal static int __PropertyOffset_32;

		// Token: 0x04013870 RID: 79984
		private static IntPtr __SetLeavesParameters_NativeFunctionPtr;

		// Token: 0x04013871 RID: 79985
		private static IntPtr __Debug_NativeFunctionPtr;

		// Token: 0x04013872 RID: 79986
		private static IntPtr __Choose_Available_Point_NativeFunctionPtr;

		// Token: 0x04013873 RID: 79987
		private static IntPtr __WeaponData_NativeFunctionPtr;

		// Token: 0x04013874 RID: 79988
		private static IntPtr __UpdateParam_NativeFunctionPtr;

		// Token: 0x04013875 RID: 79989
		private static IntPtr __InitParam_NativeFunctionPtr;

		// Token: 0x04013876 RID: 79990
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04013877 RID: 79991
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013878 RID: 79992
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04013879 RID: 79993
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x0401387A RID: 79994
		private static IntPtr __ExecuteUbergraph_BP_FeathersInteraction_NativeFunctionPtr;

		// Token: 0x02009FAE RID: 40878
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __Choose_Available_Point_FunctionParams
		{
			// Token: 0x04032B5F RID: 207711
			[FieldOffset(0)]
			public FVectorDouble CollisionPoint;

			// Token: 0x04032B60 RID: 207712
			[FieldOffset(24)]
			public FVectorDouble WeaponPoint;

			// Token: 0x04032B61 RID: 207713
			[FieldOffset(48)]
			public IntPtr ConfigDA;

			// Token: 0x04032B62 RID: 207714
			[FieldOffset(56)]
			public FVectorDouble AvailblePoint;
		}

		// Token: 0x02009FAF RID: 40879
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __UpdateParam_FunctionParams
		{
			// Token: 0x04032B63 RID: 207715
			[FieldOffset(0)]
			public float dt;
		}

		// Token: 0x02009FB0 RID: 40880
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032B64 RID: 207716
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009FB1 RID: 40881
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x04032B65 RID: 207717
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x04032B66 RID: 207718
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04032B67 RID: 207719
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009FB2 RID: 40882
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __ExecuteUbergraph_BP_FeathersInteraction_FunctionParams
		{
			// Token: 0x04032B68 RID: 207720
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
