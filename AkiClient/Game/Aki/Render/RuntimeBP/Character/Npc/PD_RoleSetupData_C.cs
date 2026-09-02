using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc
{
	// Token: 0x02003D6A RID: 15722
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Npc/PD_RoleSetupData.PD_RoleSetupData_C")]
	[UnrealStructLayout(552, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 552)]
	public class PD_RoleSetupData_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026463 RID: 156771 RVA: 0x009D3AE8 File Offset: 0x009D1CE8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_RoleSetupData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Character/Npc/PD_RoleSetupData.PD_RoleSetupData_C");
			}
			return PD_RoleSetupData_C._ClassPtr;
		}

		// Token: 0x06026464 RID: 156772 RVA: 0x009D3B0C File Offset: 0x009D1D0C
		public PD_RoleSetupData_C() : this(BuiltinUtils.AllocNativeUObject(PD_RoleSetupData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026465 RID: 156773 RVA: 0x009D3B34 File Offset: 0x009D1D34
		public PD_RoleSetupData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_RoleSetupData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700565D RID: 22109
		// (get) Token: 0x06026466 RID: 156774 RVA: 0x009D3B67 File Offset: 0x009D1D67
		// (set) Token: 0x06026467 RID: 156775 RVA: 0x009D3B7B File Offset: 0x009D1D7B
		[Nullable(2)]
		public unsafe USkeletalMesh Skel_Hair
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + PD_RoleSetupData_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_RoleSetupData_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x1700565E RID: 22110
		// (get) Token: 0x06026468 RID: 156776 RVA: 0x009D3B90 File Offset: 0x009D1D90
		// (set) Token: 0x06026469 RID: 156777 RVA: 0x009D3BA4 File Offset: 0x009D1DA4
		public unsafe FColor Skel_Hair_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700565F RID: 22111
		// (get) Token: 0x0602646A RID: 156778 RVA: 0x009D3BB9 File Offset: 0x009D1DB9
		// (set) Token: 0x0602646B RID: 156779 RVA: 0x009D3BCD File Offset: 0x009D1DCD
		[Nullable(2)]
		public unsafe USkeletalMesh Skel_Face
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + PD_RoleSetupData_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_RoleSetupData_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005660 RID: 22112
		// (get) Token: 0x0602646C RID: 156780 RVA: 0x009D3BE2 File Offset: 0x009D1DE2
		// (set) Token: 0x0602646D RID: 156781 RVA: 0x009D3BF6 File Offset: 0x009D1DF6
		[Nullable(2)]
		public unsafe USkeletalMesh Skel_BodyUp
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + PD_RoleSetupData_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_RoleSetupData_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17005661 RID: 22113
		// (get) Token: 0x0602646E RID: 156782 RVA: 0x009D3C0B File Offset: 0x009D1E0B
		// (set) Token: 0x0602646F RID: 156783 RVA: 0x009D3C1F File Offset: 0x009D1E1F
		public unsafe FColor Skel_BodyUp_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005662 RID: 22114
		// (get) Token: 0x06026470 RID: 156784 RVA: 0x009D3C34 File Offset: 0x009D1E34
		// (set) Token: 0x06026471 RID: 156785 RVA: 0x009D3C48 File Offset: 0x009D1E48
		[Nullable(2)]
		public unsafe USkeletalMesh Skel_BodyDown
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + PD_RoleSetupData_C.__PropertyOffset_5);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_RoleSetupData_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17005663 RID: 22115
		// (get) Token: 0x06026472 RID: 156786 RVA: 0x009D3C5D File Offset: 0x009D1E5D
		// (set) Token: 0x06026473 RID: 156787 RVA: 0x009D3C71 File Offset: 0x009D1E71
		public unsafe FColor Skel_BodyDown_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005664 RID: 22116
		// (get) Token: 0x06026474 RID: 156788 RVA: 0x009D3C86 File Offset: 0x009D1E86
		// (set) Token: 0x06026475 RID: 156789 RVA: 0x009D3C9A File Offset: 0x009D1E9A
		[Nullable(2)]
		public unsafe USkeletalMesh Skel_Body
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + PD_RoleSetupData_C.__PropertyOffset_7);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_RoleSetupData_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17005665 RID: 22117
		// (get) Token: 0x06026476 RID: 156790 RVA: 0x009D3CAF File Offset: 0x009D1EAF
		// (set) Token: 0x06026477 RID: 156791 RVA: 0x009D3CBF File Offset: 0x009D1EBF
		public unsafe bool bDyeColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005666 RID: 22118
		// (get) Token: 0x06026478 RID: 156792 RVA: 0x009D3CD0 File Offset: 0x009D1ED0
		// (set) Token: 0x06026479 RID: 156793 RVA: 0x009D3CE4 File Offset: 0x009D1EE4
		public unsafe FLinearColor SkinDyeColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005667 RID: 22119
		// (get) Token: 0x0602647A RID: 156794 RVA: 0x009D3CF9 File Offset: 0x009D1EF9
		// (set) Token: 0x0602647B RID: 156795 RVA: 0x009D3D0D File Offset: 0x009D1F0D
		[Nullable(0)]
		public unsafe TEnumAsByte<ERoleSetupType> RoleSetupType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_10);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005668 RID: 22120
		// (get) Token: 0x0602647C RID: 156796 RVA: 0x009D3D22 File Offset: 0x009D1F22
		// (set) Token: 0x0602647D RID: 156797 RVA: 0x009D3D36 File Offset: 0x009D1F36
		[Nullable(2)]
		public unsafe USkeletalMesh Skel_Main
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + PD_RoleSetupData_C.__PropertyOffset_11);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_RoleSetupData_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17005669 RID: 22121
		// (get) Token: 0x0602647E RID: 156798 RVA: 0x009D3D4C File Offset: 0x009D1F4C
		// (set) Token: 0x0602647F RID: 156799 RVA: 0x009D3D85 File Offset: 0x009D1F85
		public TArray<SRoleHookPart> Hook_Arm
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SRoleHookPart> result;
				if ((result = this._Hook_Arm) == null)
				{
					result = (this._Hook_Arm = new TArray<SRoleHookPart>(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				this.Hook_Arm.CopyAssign(value);
			}
		}

		// Token: 0x1700566A RID: 22122
		// (get) Token: 0x06026480 RID: 156800 RVA: 0x009D3D93 File Offset: 0x009D1F93
		// (set) Token: 0x06026481 RID: 156801 RVA: 0x009D3DA7 File Offset: 0x009D1FA7
		public unsafe FName Hook_Arm_Socket
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x1700566B RID: 22123
		// (get) Token: 0x06026482 RID: 156802 RVA: 0x009D3DBC File Offset: 0x009D1FBC
		// (set) Token: 0x06026483 RID: 156803 RVA: 0x009D3DF5 File Offset: 0x009D1FF5
		public TArray<SRoleHookPart> Hook_Waist
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SRoleHookPart> result;
				if ((result = this._Hook_Waist) == null)
				{
					result = (this._Hook_Waist = new TArray<SRoleHookPart>(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				this.Hook_Waist.CopyAssign(value);
			}
		}

		// Token: 0x1700566C RID: 22124
		// (get) Token: 0x06026484 RID: 156804 RVA: 0x009D3E03 File Offset: 0x009D2003
		// (set) Token: 0x06026485 RID: 156805 RVA: 0x009D3E17 File Offset: 0x009D2017
		public unsafe FName Hook_Waist_Socket
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700566D RID: 22125
		// (get) Token: 0x06026486 RID: 156806 RVA: 0x009D3E2C File Offset: 0x009D202C
		// (set) Token: 0x06026487 RID: 156807 RVA: 0x009D3E65 File Offset: 0x009D2065
		public TArray<SRoleHookPart> Hook_Back
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SRoleHookPart> result;
				if ((result = this._Hook_Back) == null)
				{
					result = (this._Hook_Back = new TArray<SRoleHookPart>(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				this.Hook_Back.CopyAssign(value);
			}
		}

		// Token: 0x1700566E RID: 22126
		// (get) Token: 0x06026488 RID: 156808 RVA: 0x009D3E73 File Offset: 0x009D2073
		// (set) Token: 0x06026489 RID: 156809 RVA: 0x009D3E87 File Offset: 0x009D2087
		public unsafe FName Hook_Back_Socket
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x1700566F RID: 22127
		// (get) Token: 0x0602648A RID: 156810 RVA: 0x009D3E9C File Offset: 0x009D209C
		// (set) Token: 0x0602648B RID: 156811 RVA: 0x009D3ED5 File Offset: 0x009D20D5
		public TArray<SRoleHookPart> Hook_Weapon
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SRoleHookPart> result;
				if ((result = this._Hook_Weapon) == null)
				{
					result = (this._Hook_Weapon = new TArray<SRoleHookPart>(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				this.Hook_Weapon.CopyAssign(value);
			}
		}

		// Token: 0x17005670 RID: 22128
		// (get) Token: 0x0602648C RID: 156812 RVA: 0x009D3EE3 File Offset: 0x009D20E3
		// (set) Token: 0x0602648D RID: 156813 RVA: 0x009D3EF7 File Offset: 0x009D20F7
		public unsafe FName Hook_Weapon_Socket
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17005671 RID: 22129
		// (get) Token: 0x0602648E RID: 156814 RVA: 0x009D3F0C File Offset: 0x009D210C
		// (set) Token: 0x0602648F RID: 156815 RVA: 0x009D3F45 File Offset: 0x009D2145
		public TArray<SRoleHookPart> Hook_Leg
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SRoleHookPart> result;
				if ((result = this._Hook_Leg) == null)
				{
					result = (this._Hook_Leg = new TArray<SRoleHookPart>(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				this.Hook_Leg.CopyAssign(value);
			}
		}

		// Token: 0x17005672 RID: 22130
		// (get) Token: 0x06026490 RID: 156816 RVA: 0x009D3F53 File Offset: 0x009D2153
		// (set) Token: 0x06026491 RID: 156817 RVA: 0x009D3F67 File Offset: 0x009D2167
		public unsafe FName Hook_Leg_Socket
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17005673 RID: 22131
		// (get) Token: 0x06026492 RID: 156818 RVA: 0x009D3F7C File Offset: 0x009D217C
		// (set) Token: 0x06026493 RID: 156819 RVA: 0x009D3F90 File Offset: 0x009D2190
		public unsafe FColor Body_Dyecolor01
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17005674 RID: 22132
		// (get) Token: 0x06026494 RID: 156820 RVA: 0x009D3FA5 File Offset: 0x009D21A5
		// (set) Token: 0x06026495 RID: 156821 RVA: 0x009D3FB9 File Offset: 0x009D21B9
		public unsafe FColor Body_Dyecolor02
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17005675 RID: 22133
		// (get) Token: 0x06026496 RID: 156822 RVA: 0x009D3FD0 File Offset: 0x009D21D0
		// (set) Token: 0x06026497 RID: 156823 RVA: 0x009D4009 File Offset: 0x009D2209
		public TArray<SRoleHookPart> Hook_Head
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SRoleHookPart> result;
				if ((result = this._Hook_Head) == null)
				{
					result = (this._Hook_Head = new TArray<SRoleHookPart>(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_24, this));
				}
				return result;
			}
			set
			{
				this.Hook_Head.CopyAssign(value);
			}
		}

		// Token: 0x17005676 RID: 22134
		// (get) Token: 0x06026498 RID: 156824 RVA: 0x009D4017 File Offset: 0x009D2217
		// (set) Token: 0x06026499 RID: 156825 RVA: 0x009D402B File Offset: 0x009D222B
		public unsafe FName Hook_Head_Socket
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17005677 RID: 22135
		// (get) Token: 0x0602649A RID: 156826 RVA: 0x009D4040 File Offset: 0x009D2240
		// (set) Token: 0x0602649B RID: 156827 RVA: 0x009D4054 File Offset: 0x009D2254
		[Nullable(2)]
		public unsafe UMaterialInstance Hair_Mat
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + PD_RoleSetupData_C.__PropertyOffset_26);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_RoleSetupData_C.__PropertyOffset_26, value);
			}
		}

		// Token: 0x17005678 RID: 22136
		// (get) Token: 0x0602649C RID: 156828 RVA: 0x009D4069 File Offset: 0x009D2269
		// (set) Token: 0x0602649D RID: 156829 RVA: 0x009D407D File Offset: 0x009D227D
		[Nullable(2)]
		public unsafe UMaterialInstance Face_Mat
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + PD_RoleSetupData_C.__PropertyOffset_27);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_RoleSetupData_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x17005679 RID: 22137
		// (get) Token: 0x0602649E RID: 156830 RVA: 0x009D4092 File Offset: 0x009D2292
		// (set) Token: 0x0602649F RID: 156831 RVA: 0x009D40A6 File Offset: 0x009D22A6
		[Nullable(2)]
		public unsafe UMaterialInstance Skel_BodyUp_Mat
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + PD_RoleSetupData_C.__PropertyOffset_28);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_RoleSetupData_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x1700567A RID: 22138
		// (get) Token: 0x060264A0 RID: 156832 RVA: 0x009D40BB File Offset: 0x009D22BB
		// (set) Token: 0x060264A1 RID: 156833 RVA: 0x009D40CF File Offset: 0x009D22CF
		[Nullable(2)]
		public unsafe UMaterialInstance Skel_BodyDown_Mat
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + PD_RoleSetupData_C.__PropertyOffset_29);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_RoleSetupData_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x1700567B RID: 22139
		// (get) Token: 0x060264A2 RID: 156834 RVA: 0x009D40E4 File Offset: 0x009D22E4
		// (set) Token: 0x060264A3 RID: 156835 RVA: 0x009D40F8 File Offset: 0x009D22F8
		[Nullable(2)]
		public unsafe UMaterialInstance Skel_Body_Mat
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + PD_RoleSetupData_C.__PropertyOffset_30);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_RoleSetupData_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x1700567C RID: 22140
		// (get) Token: 0x060264A4 RID: 156836 RVA: 0x009D4110 File Offset: 0x009D2310
		// (set) Token: 0x060264A5 RID: 156837 RVA: 0x009D4149 File Offset: 0x009D2349
		public TArray<UMaterialInstance> Skel_Body_Mat_Extra
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstance> result;
				if ((result = this._Skel_Body_Mat_Extra) == null)
				{
					result = (this._Skel_Body_Mat_Extra = new TArray<UMaterialInstance>(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_31, this));
				}
				return result;
			}
			set
			{
				this.Skel_Body_Mat_Extra.CopyAssign(value);
			}
		}

		// Token: 0x1700567D RID: 22141
		// (get) Token: 0x060264A6 RID: 156838 RVA: 0x009D4158 File Offset: 0x009D2358
		// (set) Token: 0x060264A7 RID: 156839 RVA: 0x009D4191 File Offset: 0x009D2391
		public TArray<UMaterialInstance> Hair_Mat_Extra
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstance> result;
				if ((result = this._Hair_Mat_Extra) == null)
				{
					result = (this._Hair_Mat_Extra = new TArray<UMaterialInstance>(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_32, this));
				}
				return result;
			}
			set
			{
				this.Hair_Mat_Extra.CopyAssign(value);
			}
		}

		// Token: 0x1700567E RID: 22142
		// (get) Token: 0x060264A8 RID: 156840 RVA: 0x009D41A0 File Offset: 0x009D23A0
		// (set) Token: 0x060264A9 RID: 156841 RVA: 0x009D41D9 File Offset: 0x009D23D9
		public TArray<UMaterialInstance> Face_Mat_Extra
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstance> result;
				if ((result = this._Face_Mat_Extra) == null)
				{
					result = (this._Face_Mat_Extra = new TArray<UMaterialInstance>(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_33, this));
				}
				return result;
			}
			set
			{
				this.Face_Mat_Extra.CopyAssign(value);
			}
		}

		// Token: 0x1700567F RID: 22143
		// (get) Token: 0x060264AA RID: 156842 RVA: 0x009D41E8 File Offset: 0x009D23E8
		// (set) Token: 0x060264AB RID: 156843 RVA: 0x009D4221 File Offset: 0x009D2421
		public TArray<UMaterialInstance> Skel_BodyUp_Mat_Extra
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstance> result;
				if ((result = this._Skel_BodyUp_Mat_Extra) == null)
				{
					result = (this._Skel_BodyUp_Mat_Extra = new TArray<UMaterialInstance>(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_34, this));
				}
				return result;
			}
			set
			{
				this.Skel_BodyUp_Mat_Extra.CopyAssign(value);
			}
		}

		// Token: 0x17005680 RID: 22144
		// (get) Token: 0x060264AC RID: 156844 RVA: 0x009D4230 File Offset: 0x009D2430
		// (set) Token: 0x060264AD RID: 156845 RVA: 0x009D4269 File Offset: 0x009D2469
		public TArray<UMaterialInstance> Skel_BodyDown_Mat_Extra
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstance> result;
				if ((result = this._Skel_BodyDown_Mat_Extra) == null)
				{
					result = (this._Skel_BodyDown_Mat_Extra = new TArray<UMaterialInstance>(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_35, this));
				}
				return result;
			}
			set
			{
				this.Skel_BodyDown_Mat_Extra.CopyAssign(value);
			}
		}

		// Token: 0x17005681 RID: 22145
		// (get) Token: 0x060264AE RID: 156846 RVA: 0x009D4277 File Offset: 0x009D2477
		// (set) Token: 0x060264AF RID: 156847 RVA: 0x009D428B File Offset: 0x009D248B
		[Nullable(2)]
		public unsafe USkeletalMesh CharacterMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + PD_RoleSetupData_C.__PropertyOffset_36);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_RoleSetupData_C.__PropertyOffset_36, value);
			}
		}

		// Token: 0x17005682 RID: 22146
		// (get) Token: 0x060264B0 RID: 156848 RVA: 0x009D42A0 File Offset: 0x009D24A0
		// (set) Token: 0x060264B1 RID: 156849 RVA: 0x009D42D9 File Offset: 0x009D24D9
		public TArray<USkeletalMesh> WeaponCase
		{
			get
			{
				base.FastCheckIsValid();
				TArray<USkeletalMesh> result;
				if ((result = this._WeaponCase) == null)
				{
					result = (this._WeaponCase = new TArray<USkeletalMesh>(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_37, this));
				}
				return result;
			}
			set
			{
				this.WeaponCase.CopyAssign(value);
			}
		}

		// Token: 0x17005683 RID: 22147
		// (get) Token: 0x060264B2 RID: 156850 RVA: 0x009D42E8 File Offset: 0x009D24E8
		// (set) Token: 0x060264B3 RID: 156851 RVA: 0x009D4321 File Offset: 0x009D2521
		public TArray<SRoleOtherCasePart> OtherCase
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SRoleOtherCasePart> result;
				if ((result = this._OtherCase) == null)
				{
					result = (this._OtherCase = new TArray<SRoleOtherCasePart>(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_38, this));
				}
				return result;
			}
			set
			{
				this.OtherCase.CopyAssign(value);
			}
		}

		// Token: 0x17005684 RID: 22148
		// (get) Token: 0x060264B4 RID: 156852 RVA: 0x009D432F File Offset: 0x009D252F
		// (set) Token: 0x060264B5 RID: 156853 RVA: 0x009D4343 File Offset: 0x009D2543
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public unsafe TSubclassOf<UAnimInstance> 动画实例
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return *(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_39);
			}
			[param: Nullable(new byte[]
			{
				0,
				1
			})]
			set
			{
				*(base.NativePtr + (IntPtr)PD_RoleSetupData_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17005685 RID: 22149
		// (get) Token: 0x060264B6 RID: 156854 RVA: 0x009D4358 File Offset: 0x009D2558
		// (set) Token: 0x060264B7 RID: 156855 RVA: 0x009D436C File Offset: 0x009D256C
		[Nullable(2)]
		public unsafe UAnimSequence 动画序列
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAnimSequence>(base.NativePtr / (IntPtr)sizeof(void*) + PD_RoleSetupData_C.__PropertyOffset_40);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_RoleSetupData_C.__PropertyOffset_40, value);
			}
		}

		// Token: 0x060264B8 RID: 156856 RVA: 0x009D4384 File Offset: 0x009D2584
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetAllPartMaterials([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<UMaterialInstance> Results)
		{
			PD_RoleSetupData_C.__GetAllPartMaterials_FunctionParams* ptr = stackalloc PD_RoleSetupData_C.__GetAllPartMaterials_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(PD_RoleSetupData_C.__GetAllPartMaterials_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PD_RoleSetupData_C.__GetAllPartMaterials_NativeFunctionPtr, (void*)ptr, 1);
			TArray<UMaterialInstance> tarray = Results;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->Results);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PD_RoleSetupData_C.__GetAllPartMaterials_NativeFunctionPtr, (void*)ptr);
			TArray<UMaterialInstance> tarray2 = Results;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->Results);
			}
			UnrealReflectionUtils.DestroyStruct(PD_RoleSetupData_C.__GetAllPartMaterials_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060264B9 RID: 156857 RVA: 0x009D43FC File Offset: 0x009D25FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetAllParts([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<USkeletalMesh> OutParts)
		{
			PD_RoleSetupData_C.__GetAllParts_FunctionParams* ptr = stackalloc PD_RoleSetupData_C.__GetAllParts_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(PD_RoleSetupData_C.__GetAllParts_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PD_RoleSetupData_C.__GetAllParts_NativeFunctionPtr, (void*)ptr, 1);
			TArray<USkeletalMesh> tarray = OutParts;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->OutParts);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PD_RoleSetupData_C.__GetAllParts_NativeFunctionPtr, (void*)ptr);
			TArray<USkeletalMesh> tarray2 = OutParts;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->OutParts);
			}
			UnrealReflectionUtils.DestroyStruct(PD_RoleSetupData_C.__GetAllParts_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060264BA RID: 156858 RVA: 0x009D4474 File Offset: 0x009D2674
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void HasSkelBody(ref bool Result)
		{
			PD_RoleSetupData_C.__HasSkelBody_FunctionParams* ptr = stackalloc PD_RoleSetupData_C.__HasSkelBody_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(PD_RoleSetupData_C.__HasSkelBody_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PD_RoleSetupData_C.__HasSkelBody_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Result = Result;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PD_RoleSetupData_C.__HasSkelBody_NativeFunctionPtr, (void*)ptr);
			Result = ptr->Result;
		}

		// Token: 0x060264BB RID: 156859 RVA: 0x009D44C4 File Offset: 0x009D26C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void HasSkelBodyDown(ref bool Result)
		{
			PD_RoleSetupData_C.__HasSkelBodyDown_FunctionParams* ptr = stackalloc PD_RoleSetupData_C.__HasSkelBodyDown_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(PD_RoleSetupData_C.__HasSkelBodyDown_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PD_RoleSetupData_C.__HasSkelBodyDown_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Result = Result;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PD_RoleSetupData_C.__HasSkelBodyDown_NativeFunctionPtr, (void*)ptr);
			Result = ptr->Result;
		}

		// Token: 0x060264BC RID: 156860 RVA: 0x009D4514 File Offset: 0x009D2714
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void HasSkelBodyUp(ref bool Result)
		{
			PD_RoleSetupData_C.__HasSkelBodyUp_FunctionParams* ptr = stackalloc PD_RoleSetupData_C.__HasSkelBodyUp_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(PD_RoleSetupData_C.__HasSkelBodyUp_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PD_RoleSetupData_C.__HasSkelBodyUp_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Result = Result;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PD_RoleSetupData_C.__HasSkelBodyUp_NativeFunctionPtr, (void*)ptr);
			Result = ptr->Result;
		}

		// Token: 0x060264BD RID: 156861 RVA: 0x009D4564 File Offset: 0x009D2764
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void HasSkelFace(ref bool Result)
		{
			PD_RoleSetupData_C.__HasSkelFace_FunctionParams* ptr = stackalloc PD_RoleSetupData_C.__HasSkelFace_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(PD_RoleSetupData_C.__HasSkelFace_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PD_RoleSetupData_C.__HasSkelFace_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Result = Result;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PD_RoleSetupData_C.__HasSkelFace_NativeFunctionPtr, (void*)ptr);
			Result = ptr->Result;
		}

		// Token: 0x060264BE RID: 156862 RVA: 0x009D45B4 File Offset: 0x009D27B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void HasSkelHair(ref bool Result)
		{
			PD_RoleSetupData_C.__HasSkelHair_FunctionParams* ptr = stackalloc PD_RoleSetupData_C.__HasSkelHair_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(PD_RoleSetupData_C.__HasSkelHair_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PD_RoleSetupData_C.__HasSkelHair_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Result = Result;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PD_RoleSetupData_C.__HasSkelHair_NativeFunctionPtr, (void*)ptr);
			Result = ptr->Result;
		}

		// Token: 0x060264BF RID: 156863 RVA: 0x009D4604 File Offset: 0x009D2804
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void HasSkelMain(ref bool Result)
		{
			PD_RoleSetupData_C.__HasSkelMain_FunctionParams* ptr = stackalloc PD_RoleSetupData_C.__HasSkelMain_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(PD_RoleSetupData_C.__HasSkelMain_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PD_RoleSetupData_C.__HasSkelMain_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Result = Result;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PD_RoleSetupData_C.__HasSkelMain_NativeFunctionPtr, (void*)ptr);
			Result = ptr->Result;
		}

		// Token: 0x060264C0 RID: 156864 RVA: 0x009D4654 File Offset: 0x009D2854
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void IsEmpty(ref bool Result)
		{
			PD_RoleSetupData_C.__IsEmpty_FunctionParams* ptr = stackalloc PD_RoleSetupData_C.__IsEmpty_FunctionParams[(UIntPtr)28] + 15L / (long)sizeof(PD_RoleSetupData_C.__IsEmpty_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PD_RoleSetupData_C.__IsEmpty_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Result = Result;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PD_RoleSetupData_C.__IsEmpty_NativeFunctionPtr, (void*)ptr);
			Result = ptr->Result;
		}

		// Token: 0x060264C1 RID: 156865 RVA: 0x009D46A3 File Offset: 0x009D28A3
		protected PD_RoleSetupData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013D9F RID: 81311
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/Npc/PD_RoleSetupData.PD_RoleSetupData_C";

		// Token: 0x04013DA0 RID: 81312
		private static IntPtr _ClassPtr;

		// Token: 0x04013DA1 RID: 81313
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013DA2 RID: 81314
		internal static int __PropertyOffset_0;

		// Token: 0x04013DA3 RID: 81315
		internal static int __PropertyOffset_1;

		// Token: 0x04013DA4 RID: 81316
		internal static int __PropertyOffset_2;

		// Token: 0x04013DA5 RID: 81317
		internal static int __PropertyOffset_3;

		// Token: 0x04013DA6 RID: 81318
		internal static int __PropertyOffset_4;

		// Token: 0x04013DA7 RID: 81319
		internal static int __PropertyOffset_5;

		// Token: 0x04013DA8 RID: 81320
		internal static int __PropertyOffset_6;

		// Token: 0x04013DA9 RID: 81321
		internal static int __PropertyOffset_7;

		// Token: 0x04013DAA RID: 81322
		internal static int __PropertyOffset_8;

		// Token: 0x04013DAB RID: 81323
		internal static int __PropertyOffset_9;

		// Token: 0x04013DAC RID: 81324
		internal static int __PropertyOffset_10;

		// Token: 0x04013DAD RID: 81325
		internal static int __PropertyOffset_11;

		// Token: 0x04013DAE RID: 81326
		internal static int __PropertyOffset_12;

		// Token: 0x04013DAF RID: 81327
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SRoleHookPart> _Hook_Arm;

		// Token: 0x04013DB0 RID: 81328
		internal static int __PropertyOffset_13;

		// Token: 0x04013DB1 RID: 81329
		internal static int __PropertyOffset_14;

		// Token: 0x04013DB2 RID: 81330
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SRoleHookPart> _Hook_Waist;

		// Token: 0x04013DB3 RID: 81331
		internal static int __PropertyOffset_15;

		// Token: 0x04013DB4 RID: 81332
		internal static int __PropertyOffset_16;

		// Token: 0x04013DB5 RID: 81333
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SRoleHookPart> _Hook_Back;

		// Token: 0x04013DB6 RID: 81334
		internal static int __PropertyOffset_17;

		// Token: 0x04013DB7 RID: 81335
		internal static int __PropertyOffset_18;

		// Token: 0x04013DB8 RID: 81336
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SRoleHookPart> _Hook_Weapon;

		// Token: 0x04013DB9 RID: 81337
		internal static int __PropertyOffset_19;

		// Token: 0x04013DBA RID: 81338
		internal static int __PropertyOffset_20;

		// Token: 0x04013DBB RID: 81339
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SRoleHookPart> _Hook_Leg;

		// Token: 0x04013DBC RID: 81340
		internal static int __PropertyOffset_21;

		// Token: 0x04013DBD RID: 81341
		internal static int __PropertyOffset_22;

		// Token: 0x04013DBE RID: 81342
		internal static int __PropertyOffset_23;

		// Token: 0x04013DBF RID: 81343
		internal static int __PropertyOffset_24;

		// Token: 0x04013DC0 RID: 81344
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SRoleHookPart> _Hook_Head;

		// Token: 0x04013DC1 RID: 81345
		internal static int __PropertyOffset_25;

		// Token: 0x04013DC2 RID: 81346
		internal static int __PropertyOffset_26;

		// Token: 0x04013DC3 RID: 81347
		internal static int __PropertyOffset_27;

		// Token: 0x04013DC4 RID: 81348
		internal static int __PropertyOffset_28;

		// Token: 0x04013DC5 RID: 81349
		internal static int __PropertyOffset_29;

		// Token: 0x04013DC6 RID: 81350
		internal static int __PropertyOffset_30;

		// Token: 0x04013DC7 RID: 81351
		internal static int __PropertyOffset_31;

		// Token: 0x04013DC8 RID: 81352
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstance> _Skel_Body_Mat_Extra;

		// Token: 0x04013DC9 RID: 81353
		internal static int __PropertyOffset_32;

		// Token: 0x04013DCA RID: 81354
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstance> _Hair_Mat_Extra;

		// Token: 0x04013DCB RID: 81355
		internal static int __PropertyOffset_33;

		// Token: 0x04013DCC RID: 81356
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstance> _Face_Mat_Extra;

		// Token: 0x04013DCD RID: 81357
		internal static int __PropertyOffset_34;

		// Token: 0x04013DCE RID: 81358
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstance> _Skel_BodyUp_Mat_Extra;

		// Token: 0x04013DCF RID: 81359
		internal static int __PropertyOffset_35;

		// Token: 0x04013DD0 RID: 81360
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstance> _Skel_BodyDown_Mat_Extra;

		// Token: 0x04013DD1 RID: 81361
		internal static int __PropertyOffset_36;

		// Token: 0x04013DD2 RID: 81362
		internal static int __PropertyOffset_37;

		// Token: 0x04013DD3 RID: 81363
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<USkeletalMesh> _WeaponCase;

		// Token: 0x04013DD4 RID: 81364
		internal static int __PropertyOffset_38;

		// Token: 0x04013DD5 RID: 81365
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SRoleOtherCasePart> _OtherCase;

		// Token: 0x04013DD6 RID: 81366
		internal static int __PropertyOffset_39;

		// Token: 0x04013DD7 RID: 81367
		internal static int __PropertyOffset_40;

		// Token: 0x04013DD8 RID: 81368
		private static IntPtr __GetAllPartMaterials_NativeFunctionPtr;

		// Token: 0x04013DD9 RID: 81369
		private static IntPtr __GetAllParts_NativeFunctionPtr;

		// Token: 0x04013DDA RID: 81370
		private static IntPtr __HasSkelBody_NativeFunctionPtr;

		// Token: 0x04013DDB RID: 81371
		private static IntPtr __HasSkelBodyDown_NativeFunctionPtr;

		// Token: 0x04013DDC RID: 81372
		private static IntPtr __HasSkelBodyUp_NativeFunctionPtr;

		// Token: 0x04013DDD RID: 81373
		private static IntPtr __HasSkelFace_NativeFunctionPtr;

		// Token: 0x04013DDE RID: 81374
		private static IntPtr __HasSkelHair_NativeFunctionPtr;

		// Token: 0x04013DDF RID: 81375
		private static IntPtr __HasSkelMain_NativeFunctionPtr;

		// Token: 0x04013DE0 RID: 81376
		private static IntPtr __IsEmpty_NativeFunctionPtr;

		// Token: 0x0200A04A RID: 41034
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __GetAllPartMaterials_FunctionParams
		{
			// Token: 0x04032C8C RID: 208012
			[FieldOffset(0)]
			public byte Results;
		}

		// Token: 0x0200A04B RID: 41035
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __GetAllParts_FunctionParams
		{
			// Token: 0x04032C8D RID: 208013
			[FieldOffset(0)]
			public byte OutParts;
		}

		// Token: 0x0200A04C RID: 41036
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __HasSkelBody_FunctionParams
		{
			// Token: 0x04032C8E RID: 208014
			[FieldOffset(0)]
			public bool Result;
		}

		// Token: 0x0200A04D RID: 41037
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __HasSkelBodyDown_FunctionParams
		{
			// Token: 0x04032C8F RID: 208015
			[FieldOffset(0)]
			public bool Result;
		}

		// Token: 0x0200A04E RID: 41038
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __HasSkelBodyUp_FunctionParams
		{
			// Token: 0x04032C90 RID: 208016
			[FieldOffset(0)]
			public bool Result;
		}

		// Token: 0x0200A04F RID: 41039
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __HasSkelFace_FunctionParams
		{
			// Token: 0x04032C91 RID: 208017
			[FieldOffset(0)]
			public bool Result;
		}

		// Token: 0x0200A050 RID: 41040
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __HasSkelHair_FunctionParams
		{
			// Token: 0x04032C92 RID: 208018
			[FieldOffset(0)]
			public bool Result;
		}

		// Token: 0x0200A051 RID: 41041
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __HasSkelMain_FunctionParams
		{
			// Token: 0x04032C93 RID: 208019
			[FieldOffset(0)]
			public bool Result;
		}

		// Token: 0x0200A052 RID: 41042
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 13)]
		protected ref struct __IsEmpty_FunctionParams
		{
			// Token: 0x04032C94 RID: 208020
			[FieldOffset(0)]
			public bool Result;
		}
	}
}
