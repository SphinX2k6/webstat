using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc
{
	// Token: 0x02003D69 RID: 15721
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Npc/PD_NpcSetupData.PD_NpcSetupData_C")]
	[UnrealStructLayout(560, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 560)]
	public class PD_NpcSetupData_C : UKuroNpcDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060263FD RID: 156669 RVA: 0x009D2C5E File Offset: 0x009D0E5E
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_NpcSetupData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Character/Npc/PD_NpcSetupData.PD_NpcSetupData_C");
			}
			return PD_NpcSetupData_C._ClassPtr;
		}

		// Token: 0x060263FE RID: 156670 RVA: 0x009D2C84 File Offset: 0x009D0E84
		public PD_NpcSetupData_C() : this(BuiltinUtils.AllocNativeUObject(PD_NpcSetupData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060263FF RID: 156671 RVA: 0x009D2CAC File Offset: 0x009D0EAC
		public PD_NpcSetupData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_NpcSetupData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005635 RID: 22069
		// (get) Token: 0x06026400 RID: 156672 RVA: 0x009D2CE0 File Offset: 0x009D0EE0
		// (set) Token: 0x06026401 RID: 156673 RVA: 0x009D2D19 File Offset: 0x009D0F19
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005636 RID: 22070
		// (get) Token: 0x06026402 RID: 156674 RVA: 0x009D2D3A File Offset: 0x009D0F3A
		// (set) Token: 0x06026403 RID: 156675 RVA: 0x009D2D4E File Offset: 0x009D0F4E
		[Nullable(2)]
		public unsafe USkeletalMesh Skel_Hair
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + PD_NpcSetupData_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_NpcSetupData_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005637 RID: 22071
		// (get) Token: 0x06026404 RID: 156676 RVA: 0x009D2D63 File Offset: 0x009D0F63
		// (set) Token: 0x06026405 RID: 156677 RVA: 0x009D2D77 File Offset: 0x009D0F77
		public unsafe FColor Skel_Hair_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005638 RID: 22072
		// (get) Token: 0x06026406 RID: 156678 RVA: 0x009D2D8C File Offset: 0x009D0F8C
		// (set) Token: 0x06026407 RID: 156679 RVA: 0x009D2DA0 File Offset: 0x009D0FA0
		[Nullable(2)]
		public unsafe USkeletalMesh Skel_Face
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + PD_NpcSetupData_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_NpcSetupData_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17005639 RID: 22073
		// (get) Token: 0x06026408 RID: 156680 RVA: 0x009D2DB5 File Offset: 0x009D0FB5
		// (set) Token: 0x06026409 RID: 156681 RVA: 0x009D2DC9 File Offset: 0x009D0FC9
		[Nullable(2)]
		public unsafe USkeletalMesh Skel_BodyUp
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + PD_NpcSetupData_C.__PropertyOffset_4);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_NpcSetupData_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700563A RID: 22074
		// (get) Token: 0x0602640A RID: 156682 RVA: 0x009D2DDE File Offset: 0x009D0FDE
		// (set) Token: 0x0602640B RID: 156683 RVA: 0x009D2DF2 File Offset: 0x009D0FF2
		public unsafe FColor Skel_BodyUp_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700563B RID: 22075
		// (get) Token: 0x0602640C RID: 156684 RVA: 0x009D2E07 File Offset: 0x009D1007
		// (set) Token: 0x0602640D RID: 156685 RVA: 0x009D2E1B File Offset: 0x009D101B
		[Nullable(2)]
		public unsafe USkeletalMesh Skel_BodyDown
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + PD_NpcSetupData_C.__PropertyOffset_6);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_NpcSetupData_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x1700563C RID: 22076
		// (get) Token: 0x0602640E RID: 156686 RVA: 0x009D2E30 File Offset: 0x009D1030
		// (set) Token: 0x0602640F RID: 156687 RVA: 0x009D2E44 File Offset: 0x009D1044
		public unsafe FColor Skel_BodyDown_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700563D RID: 22077
		// (get) Token: 0x06026410 RID: 156688 RVA: 0x009D2E59 File Offset: 0x009D1059
		// (set) Token: 0x06026411 RID: 156689 RVA: 0x009D2E6D File Offset: 0x009D106D
		[Nullable(2)]
		public unsafe USkeletalMesh Skel_Body
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + PD_NpcSetupData_C.__PropertyOffset_8);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_NpcSetupData_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x1700563E RID: 22078
		// (get) Token: 0x06026412 RID: 156690 RVA: 0x009D2E82 File Offset: 0x009D1082
		// (set) Token: 0x06026413 RID: 156691 RVA: 0x009D2E92 File Offset: 0x009D1092
		public unsafe bool bDyeColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700563F RID: 22079
		// (get) Token: 0x06026414 RID: 156692 RVA: 0x009D2EA3 File Offset: 0x009D10A3
		// (set) Token: 0x06026415 RID: 156693 RVA: 0x009D2EB7 File Offset: 0x009D10B7
		public unsafe FLinearColor SkinDyeColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005640 RID: 22080
		// (get) Token: 0x06026416 RID: 156694 RVA: 0x009D2ECC File Offset: 0x009D10CC
		// (set) Token: 0x06026417 RID: 156695 RVA: 0x009D2EE0 File Offset: 0x009D10E0
		[Nullable(0)]
		public unsafe TEnumAsByte<ENpcSetupType> NpcSetupType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_11);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17005641 RID: 22081
		// (get) Token: 0x06026418 RID: 156696 RVA: 0x009D2EF5 File Offset: 0x009D10F5
		// (set) Token: 0x06026419 RID: 156697 RVA: 0x009D2F09 File Offset: 0x009D1109
		[Nullable(2)]
		public unsafe USkeletalMesh Skel_Main
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + PD_NpcSetupData_C.__PropertyOffset_12);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_NpcSetupData_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17005642 RID: 22082
		// (get) Token: 0x0602641A RID: 156698 RVA: 0x009D2F20 File Offset: 0x009D1120
		// (set) Token: 0x0602641B RID: 156699 RVA: 0x009D2F59 File Offset: 0x009D1159
		public TArray<SNpcHookPart> Hook_Arm
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SNpcHookPart> result;
				if ((result = this._Hook_Arm) == null)
				{
					result = (this._Hook_Arm = new TArray<SNpcHookPart>(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				this.Hook_Arm.CopyAssign(value);
			}
		}

		// Token: 0x17005643 RID: 22083
		// (get) Token: 0x0602641C RID: 156700 RVA: 0x009D2F67 File Offset: 0x009D1167
		// (set) Token: 0x0602641D RID: 156701 RVA: 0x009D2F7B File Offset: 0x009D117B
		public unsafe FName Hook_Arm_Socket
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17005644 RID: 22084
		// (get) Token: 0x0602641E RID: 156702 RVA: 0x009D2F90 File Offset: 0x009D1190
		// (set) Token: 0x0602641F RID: 156703 RVA: 0x009D2FC9 File Offset: 0x009D11C9
		public TArray<SNpcHookPart> Hook_Waist
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SNpcHookPart> result;
				if ((result = this._Hook_Waist) == null)
				{
					result = (this._Hook_Waist = new TArray<SNpcHookPart>(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				this.Hook_Waist.CopyAssign(value);
			}
		}

		// Token: 0x17005645 RID: 22085
		// (get) Token: 0x06026420 RID: 156704 RVA: 0x009D2FD7 File Offset: 0x009D11D7
		// (set) Token: 0x06026421 RID: 156705 RVA: 0x009D2FEB File Offset: 0x009D11EB
		public unsafe FName Hook_Waist_Socket
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17005646 RID: 22086
		// (get) Token: 0x06026422 RID: 156706 RVA: 0x009D3000 File Offset: 0x009D1200
		// (set) Token: 0x06026423 RID: 156707 RVA: 0x009D3039 File Offset: 0x009D1239
		public TArray<SNpcHookPart> Hook_Back
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SNpcHookPart> result;
				if ((result = this._Hook_Back) == null)
				{
					result = (this._Hook_Back = new TArray<SNpcHookPart>(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				this.Hook_Back.CopyAssign(value);
			}
		}

		// Token: 0x17005647 RID: 22087
		// (get) Token: 0x06026424 RID: 156708 RVA: 0x009D3047 File Offset: 0x009D1247
		// (set) Token: 0x06026425 RID: 156709 RVA: 0x009D305B File Offset: 0x009D125B
		public unsafe FName Hook_Back_Socket
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17005648 RID: 22088
		// (get) Token: 0x06026426 RID: 156710 RVA: 0x009D3070 File Offset: 0x009D1270
		// (set) Token: 0x06026427 RID: 156711 RVA: 0x009D30A9 File Offset: 0x009D12A9
		public TArray<SNpcHookPart> Hook_Weapon
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SNpcHookPart> result;
				if ((result = this._Hook_Weapon) == null)
				{
					result = (this._Hook_Weapon = new TArray<SNpcHookPart>(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				this.Hook_Weapon.CopyAssign(value);
			}
		}

		// Token: 0x17005649 RID: 22089
		// (get) Token: 0x06026428 RID: 156712 RVA: 0x009D30B7 File Offset: 0x009D12B7
		// (set) Token: 0x06026429 RID: 156713 RVA: 0x009D30CB File Offset: 0x009D12CB
		public unsafe FName Hook_Weapon_Socket
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x1700564A RID: 22090
		// (get) Token: 0x0602642A RID: 156714 RVA: 0x009D30E0 File Offset: 0x009D12E0
		// (set) Token: 0x0602642B RID: 156715 RVA: 0x009D3119 File Offset: 0x009D1319
		public TArray<SNpcHookPart> Hook_Leg
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SNpcHookPart> result;
				if ((result = this._Hook_Leg) == null)
				{
					result = (this._Hook_Leg = new TArray<SNpcHookPart>(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_21, this));
				}
				return result;
			}
			set
			{
				this.Hook_Leg.CopyAssign(value);
			}
		}

		// Token: 0x1700564B RID: 22091
		// (get) Token: 0x0602642C RID: 156716 RVA: 0x009D3127 File Offset: 0x009D1327
		// (set) Token: 0x0602642D RID: 156717 RVA: 0x009D313B File Offset: 0x009D133B
		public unsafe FName Hook_Leg_Socket
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x1700564C RID: 22092
		// (get) Token: 0x0602642E RID: 156718 RVA: 0x009D3150 File Offset: 0x009D1350
		// (set) Token: 0x0602642F RID: 156719 RVA: 0x009D3164 File Offset: 0x009D1364
		public unsafe FColor Body_Dyecolor01
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x1700564D RID: 22093
		// (get) Token: 0x06026430 RID: 156720 RVA: 0x009D3179 File Offset: 0x009D1379
		// (set) Token: 0x06026431 RID: 156721 RVA: 0x009D318D File Offset: 0x009D138D
		public unsafe FColor Body_Dyecolor02
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x1700564E RID: 22094
		// (get) Token: 0x06026432 RID: 156722 RVA: 0x009D31A4 File Offset: 0x009D13A4
		// (set) Token: 0x06026433 RID: 156723 RVA: 0x009D31DD File Offset: 0x009D13DD
		public TArray<SNpcHookPart> Hook_Head
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SNpcHookPart> result;
				if ((result = this._Hook_Head) == null)
				{
					result = (this._Hook_Head = new TArray<SNpcHookPart>(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				this.Hook_Head.CopyAssign(value);
			}
		}

		// Token: 0x1700564F RID: 22095
		// (get) Token: 0x06026434 RID: 156724 RVA: 0x009D31EB File Offset: 0x009D13EB
		// (set) Token: 0x06026435 RID: 156725 RVA: 0x009D31FF File Offset: 0x009D13FF
		public unsafe FName Hook_Head_Socket
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17005650 RID: 22096
		// (get) Token: 0x06026436 RID: 156726 RVA: 0x009D3214 File Offset: 0x009D1414
		// (set) Token: 0x06026437 RID: 156727 RVA: 0x009D3228 File Offset: 0x009D1428
		[Nullable(2)]
		public unsafe UMaterialInstance Hair_Mat
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + PD_NpcSetupData_C.__PropertyOffset_27);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_NpcSetupData_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x17005651 RID: 22097
		// (get) Token: 0x06026438 RID: 156728 RVA: 0x009D323D File Offset: 0x009D143D
		// (set) Token: 0x06026439 RID: 156729 RVA: 0x009D3251 File Offset: 0x009D1451
		[Nullable(2)]
		public unsafe UMaterialInstance Skel_BodyUp_Mat
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + PD_NpcSetupData_C.__PropertyOffset_28);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_NpcSetupData_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x17005652 RID: 22098
		// (get) Token: 0x0602643A RID: 156730 RVA: 0x009D3266 File Offset: 0x009D1466
		// (set) Token: 0x0602643B RID: 156731 RVA: 0x009D327A File Offset: 0x009D147A
		[Nullable(2)]
		public unsafe UMaterialInstance Skel_BodyDown_Mat
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + PD_NpcSetupData_C.__PropertyOffset_29);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_NpcSetupData_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x17005653 RID: 22099
		// (get) Token: 0x0602643C RID: 156732 RVA: 0x009D328F File Offset: 0x009D148F
		// (set) Token: 0x0602643D RID: 156733 RVA: 0x009D32A3 File Offset: 0x009D14A3
		[Nullable(2)]
		public unsafe UMaterialInstance Skel_Body_Mat
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + PD_NpcSetupData_C.__PropertyOffset_30);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_NpcSetupData_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x17005654 RID: 22100
		// (get) Token: 0x0602643E RID: 156734 RVA: 0x009D32B8 File Offset: 0x009D14B8
		// (set) Token: 0x0602643F RID: 156735 RVA: 0x009D32F1 File Offset: 0x009D14F1
		public TArray<UMaterialInstance> Skel_Body_Mat_Extra
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstance> result;
				if ((result = this._Skel_Body_Mat_Extra) == null)
				{
					result = (this._Skel_Body_Mat_Extra = new TArray<UMaterialInstance>(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_31, this));
				}
				return result;
			}
			set
			{
				this.Skel_Body_Mat_Extra.CopyAssign(value);
			}
		}

		// Token: 0x17005655 RID: 22101
		// (get) Token: 0x06026440 RID: 156736 RVA: 0x009D3300 File Offset: 0x009D1500
		// (set) Token: 0x06026441 RID: 156737 RVA: 0x009D3339 File Offset: 0x009D1539
		public TArray<UMaterialInstance> Hair_Mat_Extra
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstance> result;
				if ((result = this._Hair_Mat_Extra) == null)
				{
					result = (this._Hair_Mat_Extra = new TArray<UMaterialInstance>(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_32, this));
				}
				return result;
			}
			set
			{
				this.Hair_Mat_Extra.CopyAssign(value);
			}
		}

		// Token: 0x17005656 RID: 22102
		// (get) Token: 0x06026442 RID: 156738 RVA: 0x009D3347 File Offset: 0x009D1547
		// (set) Token: 0x06026443 RID: 156739 RVA: 0x009D335B File Offset: 0x009D155B
		[Nullable(2)]
		public unsafe UMaterialInstance Face_Mat
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + PD_NpcSetupData_C.__PropertyOffset_33);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_NpcSetupData_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x17005657 RID: 22103
		// (get) Token: 0x06026444 RID: 156740 RVA: 0x009D3370 File Offset: 0x009D1570
		// (set) Token: 0x06026445 RID: 156741 RVA: 0x009D33A9 File Offset: 0x009D15A9
		public TArray<UMaterialInstance> Face_Mat_Extra
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstance> result;
				if ((result = this._Face_Mat_Extra) == null)
				{
					result = (this._Face_Mat_Extra = new TArray<UMaterialInstance>(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_34, this));
				}
				return result;
			}
			set
			{
				this.Face_Mat_Extra.CopyAssign(value);
			}
		}

		// Token: 0x17005658 RID: 22104
		// (get) Token: 0x06026446 RID: 156742 RVA: 0x009D33B8 File Offset: 0x009D15B8
		// (set) Token: 0x06026447 RID: 156743 RVA: 0x009D33F1 File Offset: 0x009D15F1
		public TArray<UMaterialInstance> Skel_BodyUp_Mat_Extra
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstance> result;
				if ((result = this._Skel_BodyUp_Mat_Extra) == null)
				{
					result = (this._Skel_BodyUp_Mat_Extra = new TArray<UMaterialInstance>(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_35, this));
				}
				return result;
			}
			set
			{
				this.Skel_BodyUp_Mat_Extra.CopyAssign(value);
			}
		}

		// Token: 0x17005659 RID: 22105
		// (get) Token: 0x06026448 RID: 156744 RVA: 0x009D3400 File Offset: 0x009D1600
		// (set) Token: 0x06026449 RID: 156745 RVA: 0x009D3439 File Offset: 0x009D1639
		public TArray<UMaterialInstance> Skel_BodyDown_Mat_Extra
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstance> result;
				if ((result = this._Skel_BodyDown_Mat_Extra) == null)
				{
					result = (this._Skel_BodyDown_Mat_Extra = new TArray<UMaterialInstance>(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_36, this));
				}
				return result;
			}
			set
			{
				this.Skel_BodyDown_Mat_Extra.CopyAssign(value);
			}
		}

		// Token: 0x1700565A RID: 22106
		// (get) Token: 0x0602644A RID: 156746 RVA: 0x009D3448 File Offset: 0x009D1648
		// (set) Token: 0x0602644B RID: 156747 RVA: 0x009D3481 File Offset: 0x009D1681
		public TArray<UMaterialInterface> ReferencedOulineMaterials
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInterface> result;
				if ((result = this._ReferencedOulineMaterials) == null)
				{
					result = (this._ReferencedOulineMaterials = new TArray<UMaterialInterface>(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_37, this));
				}
				return result;
			}
			set
			{
				this.ReferencedOulineMaterials.CopyAssign(value);
			}
		}

		// Token: 0x1700565B RID: 22107
		// (get) Token: 0x0602644C RID: 156748 RVA: 0x009D3490 File Offset: 0x009D1690
		// (set) Token: 0x0602644D RID: 156749 RVA: 0x009D34C9 File Offset: 0x009D16C9
		public TArray<SNpcChildPart> ChildParts
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SNpcChildPart> result;
				if ((result = this._ChildParts) == null)
				{
					result = (this._ChildParts = new TArray<SNpcChildPart>(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_38, this));
				}
				return result;
			}
			set
			{
				this.ChildParts.CopyAssign(value);
			}
		}

		// Token: 0x1700565C RID: 22108
		// (get) Token: 0x0602644E RID: 156750 RVA: 0x009D34D8 File Offset: 0x009D16D8
		// (set) Token: 0x0602644F RID: 156751 RVA: 0x009D3511 File Offset: 0x009D1711
		public TArray<FName> HideParentBoneNames
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._HideParentBoneNames) == null)
				{
					result = (this._HideParentBoneNames = new TArray<FName>(base.NativePtr + (IntPtr)PD_NpcSetupData_C.__PropertyOffset_39, this));
				}
				return result;
			}
			set
			{
				this.HideParentBoneNames.CopyAssign(value);
			}
		}

		// Token: 0x06026450 RID: 156752 RVA: 0x009D3520 File Offset: 0x009D1720
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void IsSeq(ref bool bSeq)
		{
			PD_NpcSetupData_C.__IsSeq_FunctionParams* ptr = stackalloc PD_NpcSetupData_C.__IsSeq_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(PD_NpcSetupData_C.__IsSeq_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PD_NpcSetupData_C.__IsSeq_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bSeq = bSeq;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PD_NpcSetupData_C.__IsSeq_NativeFunctionPtr, (void*)ptr);
			bSeq = ptr->bSeq;
		}

		// Token: 0x06026451 RID: 156753 RVA: 0x009D356F File Offset: 0x009D176F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetOLReference()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PD_NpcSetupData_C.__SetOLReference_NativeFunctionPtr, null);
		}

		// Token: 0x06026452 RID: 156754 RVA: 0x009D3584 File Offset: 0x009D1784
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetOutlineReference(bool bSeq, USkeletalMesh Skel, UMaterialInterface mat, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<UMaterialInterface> mat_extra, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<UMaterialInterface> OutOLMat)
		{
			PD_NpcSetupData_C.__GetOutlineReference_FunctionParams* ptr = stackalloc PD_NpcSetupData_C.__GetOutlineReference_FunctionParams[(UIntPtr)463] + 15L / (long)sizeof(PD_NpcSetupData_C.__GetOutlineReference_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PD_NpcSetupData_C.__GetOutlineReference_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bSeq = bSeq;
			ptr->Skel = ((Skel != null) ? Skel.NativePtr : IntPtr.Zero);
			ptr->mat = ((mat != null) ? mat.NativePtr : IntPtr.Zero);
			TArray<UMaterialInterface> tarray = mat_extra;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->mat_extra);
			}
			TArray<UMaterialInterface> tarray2 = OutOLMat;
			if (tarray2 != null)
			{
				tarray2.MoveTo(&ptr->OutOLMat);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PD_NpcSetupData_C.__GetOutlineReference_NativeFunctionPtr, (void*)ptr);
			TArray<UMaterialInterface> tarray3 = mat_extra;
			if (tarray3 != null)
			{
				tarray3.MoveAssign(&ptr->mat_extra);
			}
			TArray<UMaterialInterface> tarray4 = OutOLMat;
			if (tarray4 != null)
			{
				tarray4.MoveAssign(&ptr->OutOLMat);
			}
			UnrealReflectionUtils.DestroyStruct(PD_NpcSetupData_C.__GetOutlineReference_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06026453 RID: 156755 RVA: 0x009D365E File Offset: 0x009D185E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FixNPCOutline()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PD_NpcSetupData_C.__FixNPCOutline_NativeFunctionPtr, null);
		}

		// Token: 0x06026454 RID: 156756 RVA: 0x009D3674 File Offset: 0x009D1874
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Set_Single_Override(ref USkeletalMesh skel_mesh, ref UMaterialInstance mat, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<UMaterialInstance> mat_extra)
		{
			PD_NpcSetupData_C.__Set_Single_Override_FunctionParams* ptr = stackalloc PD_NpcSetupData_C.__Set_Single_Override_FunctionParams[(UIntPtr)431] + 15L / (long)sizeof(PD_NpcSetupData_C.__Set_Single_Override_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PD_NpcSetupData_C.__Set_Single_Override_NativeFunctionPtr, (void*)ptr, 1);
			ref PD_NpcSetupData_C.__Set_Single_Override_FunctionParams ptr2 = ref *ptr;
			USkeletalMesh uskeletalMesh = skel_mesh;
			ptr2.skel_mesh = ((uskeletalMesh != null) ? uskeletalMesh.NativePtr : IntPtr.Zero);
			ref PD_NpcSetupData_C.__Set_Single_Override_FunctionParams ptr3 = ref *ptr;
			UMaterialInstance umaterialInstance = mat;
			ptr3.mat = ((umaterialInstance != null) ? umaterialInstance.NativePtr : IntPtr.Zero);
			TArray<UMaterialInstance> tarray = mat_extra;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->mat_extra);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PD_NpcSetupData_C.__Set_Single_Override_NativeFunctionPtr, (void*)ptr);
			skel_mesh = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMesh>(ptr->skel_mesh);
			mat = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMaterialInstance>(ptr->mat);
			TArray<UMaterialInstance> tarray2 = mat_extra;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->mat_extra);
			}
			UnrealReflectionUtils.DestroyStruct(PD_NpcSetupData_C.__Set_Single_Override_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06026455 RID: 156757 RVA: 0x009D3739 File Offset: 0x009D1939
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_Override()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PD_NpcSetupData_C.__Set_Override_NativeFunctionPtr, null);
		}

		// Token: 0x06026456 RID: 156758 RVA: 0x009D3750 File Offset: 0x009D1950
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetAllPartMaterials([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<UMaterialInstance> Results)
		{
			PD_NpcSetupData_C.__GetAllPartMaterials_FunctionParams* ptr = stackalloc PD_NpcSetupData_C.__GetAllPartMaterials_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(PD_NpcSetupData_C.__GetAllPartMaterials_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PD_NpcSetupData_C.__GetAllPartMaterials_NativeFunctionPtr, (void*)ptr, 1);
			TArray<UMaterialInstance> tarray = Results;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->Results);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PD_NpcSetupData_C.__GetAllPartMaterials_NativeFunctionPtr, (void*)ptr);
			TArray<UMaterialInstance> tarray2 = Results;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->Results);
			}
			UnrealReflectionUtils.DestroyStruct(PD_NpcSetupData_C.__GetAllPartMaterials_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06026457 RID: 156759 RVA: 0x009D37C8 File Offset: 0x009D19C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetAllParts([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<USkeletalMesh> OutParts)
		{
			PD_NpcSetupData_C.__GetAllParts_FunctionParams* ptr = stackalloc PD_NpcSetupData_C.__GetAllParts_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(PD_NpcSetupData_C.__GetAllParts_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PD_NpcSetupData_C.__GetAllParts_NativeFunctionPtr, (void*)ptr, 1);
			TArray<USkeletalMesh> tarray = OutParts;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->OutParts);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PD_NpcSetupData_C.__GetAllParts_NativeFunctionPtr, (void*)ptr);
			TArray<USkeletalMesh> tarray2 = OutParts;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->OutParts);
			}
			UnrealReflectionUtils.DestroyStruct(PD_NpcSetupData_C.__GetAllParts_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06026458 RID: 156760 RVA: 0x009D3840 File Offset: 0x009D1A40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void HasSkelBody(ref bool Result)
		{
			PD_NpcSetupData_C.__HasSkelBody_FunctionParams* ptr = stackalloc PD_NpcSetupData_C.__HasSkelBody_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(PD_NpcSetupData_C.__HasSkelBody_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PD_NpcSetupData_C.__HasSkelBody_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Result = Result;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PD_NpcSetupData_C.__HasSkelBody_NativeFunctionPtr, (void*)ptr);
			Result = ptr->Result;
		}

		// Token: 0x06026459 RID: 156761 RVA: 0x009D3890 File Offset: 0x009D1A90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void HasSkelBodyDown(ref bool Result)
		{
			PD_NpcSetupData_C.__HasSkelBodyDown_FunctionParams* ptr = stackalloc PD_NpcSetupData_C.__HasSkelBodyDown_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(PD_NpcSetupData_C.__HasSkelBodyDown_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PD_NpcSetupData_C.__HasSkelBodyDown_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Result = Result;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PD_NpcSetupData_C.__HasSkelBodyDown_NativeFunctionPtr, (void*)ptr);
			Result = ptr->Result;
		}

		// Token: 0x0602645A RID: 156762 RVA: 0x009D38E0 File Offset: 0x009D1AE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void HasSkelBodyUp(ref bool Result)
		{
			PD_NpcSetupData_C.__HasSkelBodyUp_FunctionParams* ptr = stackalloc PD_NpcSetupData_C.__HasSkelBodyUp_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(PD_NpcSetupData_C.__HasSkelBodyUp_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PD_NpcSetupData_C.__HasSkelBodyUp_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Result = Result;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PD_NpcSetupData_C.__HasSkelBodyUp_NativeFunctionPtr, (void*)ptr);
			Result = ptr->Result;
		}

		// Token: 0x0602645B RID: 156763 RVA: 0x009D3930 File Offset: 0x009D1B30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void HasSkelFace(ref bool Result)
		{
			PD_NpcSetupData_C.__HasSkelFace_FunctionParams* ptr = stackalloc PD_NpcSetupData_C.__HasSkelFace_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(PD_NpcSetupData_C.__HasSkelFace_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PD_NpcSetupData_C.__HasSkelFace_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Result = Result;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PD_NpcSetupData_C.__HasSkelFace_NativeFunctionPtr, (void*)ptr);
			Result = ptr->Result;
		}

		// Token: 0x0602645C RID: 156764 RVA: 0x009D3980 File Offset: 0x009D1B80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void HasSkelHair(ref bool Result)
		{
			PD_NpcSetupData_C.__HasSkelHair_FunctionParams* ptr = stackalloc PD_NpcSetupData_C.__HasSkelHair_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(PD_NpcSetupData_C.__HasSkelHair_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PD_NpcSetupData_C.__HasSkelHair_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Result = Result;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PD_NpcSetupData_C.__HasSkelHair_NativeFunctionPtr, (void*)ptr);
			Result = ptr->Result;
		}

		// Token: 0x0602645D RID: 156765 RVA: 0x009D39D0 File Offset: 0x009D1BD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void HasSkelMain(ref bool Result)
		{
			PD_NpcSetupData_C.__HasSkelMain_FunctionParams* ptr = stackalloc PD_NpcSetupData_C.__HasSkelMain_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(PD_NpcSetupData_C.__HasSkelMain_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PD_NpcSetupData_C.__HasSkelMain_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Result = Result;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PD_NpcSetupData_C.__HasSkelMain_NativeFunctionPtr, (void*)ptr);
			Result = ptr->Result;
		}

		// Token: 0x0602645E RID: 156766 RVA: 0x009D3A20 File Offset: 0x009D1C20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void IsEmpty(ref bool Result)
		{
			PD_NpcSetupData_C.__IsEmpty_FunctionParams* ptr = stackalloc PD_NpcSetupData_C.__IsEmpty_FunctionParams[(UIntPtr)28] + 15L / (long)sizeof(PD_NpcSetupData_C.__IsEmpty_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PD_NpcSetupData_C.__IsEmpty_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Result = Result;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PD_NpcSetupData_C.__IsEmpty_NativeFunctionPtr, (void*)ptr);
			Result = ptr->Result;
		}

		// Token: 0x0602645F RID: 156767 RVA: 0x009D3A6F File Offset: 0x009D1C6F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnPreSave()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PD_NpcSetupData_C.__OnPreSave_NativeFunctionPtr, null);
		}

		// Token: 0x06026460 RID: 156768 RVA: 0x009D3A83 File Offset: 0x009D1C83
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void OnPreSave_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, PD_NpcSetupData_C.__OnPreSave_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06026461 RID: 156769 RVA: 0x009D3A98 File Offset: 0x009D1C98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_PD_NpcSetupData(int EntryPoint)
		{
			PD_NpcSetupData_C.__ExecuteUbergraph_PD_NpcSetupData_FunctionParams* ptr = stackalloc PD_NpcSetupData_C.__ExecuteUbergraph_PD_NpcSetupData_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(PD_NpcSetupData_C.__ExecuteUbergraph_PD_NpcSetupData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PD_NpcSetupData_C.__ExecuteUbergraph_PD_NpcSetupData_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, PD_NpcSetupData_C.__ExecuteUbergraph_PD_NpcSetupData_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026462 RID: 156770 RVA: 0x009D3ADF File Offset: 0x009D1CDF
		protected PD_NpcSetupData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013D54 RID: 81236
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/Npc/PD_NpcSetupData.PD_NpcSetupData_C";

		// Token: 0x04013D55 RID: 81237
		private static IntPtr _ClassPtr;

		// Token: 0x04013D56 RID: 81238
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013D57 RID: 81239
		internal static int __PropertyOffset_0;

		// Token: 0x04013D58 RID: 81240
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013D59 RID: 81241
		internal static int __PropertyOffset_1;

		// Token: 0x04013D5A RID: 81242
		internal static int __PropertyOffset_2;

		// Token: 0x04013D5B RID: 81243
		internal static int __PropertyOffset_3;

		// Token: 0x04013D5C RID: 81244
		internal static int __PropertyOffset_4;

		// Token: 0x04013D5D RID: 81245
		internal static int __PropertyOffset_5;

		// Token: 0x04013D5E RID: 81246
		internal static int __PropertyOffset_6;

		// Token: 0x04013D5F RID: 81247
		internal static int __PropertyOffset_7;

		// Token: 0x04013D60 RID: 81248
		internal static int __PropertyOffset_8;

		// Token: 0x04013D61 RID: 81249
		internal static int __PropertyOffset_9;

		// Token: 0x04013D62 RID: 81250
		internal static int __PropertyOffset_10;

		// Token: 0x04013D63 RID: 81251
		internal static int __PropertyOffset_11;

		// Token: 0x04013D64 RID: 81252
		internal static int __PropertyOffset_12;

		// Token: 0x04013D65 RID: 81253
		internal static int __PropertyOffset_13;

		// Token: 0x04013D66 RID: 81254
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SNpcHookPart> _Hook_Arm;

		// Token: 0x04013D67 RID: 81255
		internal static int __PropertyOffset_14;

		// Token: 0x04013D68 RID: 81256
		internal static int __PropertyOffset_15;

		// Token: 0x04013D69 RID: 81257
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SNpcHookPart> _Hook_Waist;

		// Token: 0x04013D6A RID: 81258
		internal static int __PropertyOffset_16;

		// Token: 0x04013D6B RID: 81259
		internal static int __PropertyOffset_17;

		// Token: 0x04013D6C RID: 81260
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SNpcHookPart> _Hook_Back;

		// Token: 0x04013D6D RID: 81261
		internal static int __PropertyOffset_18;

		// Token: 0x04013D6E RID: 81262
		internal static int __PropertyOffset_19;

		// Token: 0x04013D6F RID: 81263
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SNpcHookPart> _Hook_Weapon;

		// Token: 0x04013D70 RID: 81264
		internal static int __PropertyOffset_20;

		// Token: 0x04013D71 RID: 81265
		internal static int __PropertyOffset_21;

		// Token: 0x04013D72 RID: 81266
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SNpcHookPart> _Hook_Leg;

		// Token: 0x04013D73 RID: 81267
		internal static int __PropertyOffset_22;

		// Token: 0x04013D74 RID: 81268
		internal static int __PropertyOffset_23;

		// Token: 0x04013D75 RID: 81269
		internal static int __PropertyOffset_24;

		// Token: 0x04013D76 RID: 81270
		internal static int __PropertyOffset_25;

		// Token: 0x04013D77 RID: 81271
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SNpcHookPart> _Hook_Head;

		// Token: 0x04013D78 RID: 81272
		internal static int __PropertyOffset_26;

		// Token: 0x04013D79 RID: 81273
		internal static int __PropertyOffset_27;

		// Token: 0x04013D7A RID: 81274
		internal static int __PropertyOffset_28;

		// Token: 0x04013D7B RID: 81275
		internal static int __PropertyOffset_29;

		// Token: 0x04013D7C RID: 81276
		internal static int __PropertyOffset_30;

		// Token: 0x04013D7D RID: 81277
		internal static int __PropertyOffset_31;

		// Token: 0x04013D7E RID: 81278
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstance> _Skel_Body_Mat_Extra;

		// Token: 0x04013D7F RID: 81279
		internal static int __PropertyOffset_32;

		// Token: 0x04013D80 RID: 81280
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstance> _Hair_Mat_Extra;

		// Token: 0x04013D81 RID: 81281
		internal static int __PropertyOffset_33;

		// Token: 0x04013D82 RID: 81282
		internal static int __PropertyOffset_34;

		// Token: 0x04013D83 RID: 81283
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstance> _Face_Mat_Extra;

		// Token: 0x04013D84 RID: 81284
		internal static int __PropertyOffset_35;

		// Token: 0x04013D85 RID: 81285
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstance> _Skel_BodyUp_Mat_Extra;

		// Token: 0x04013D86 RID: 81286
		internal static int __PropertyOffset_36;

		// Token: 0x04013D87 RID: 81287
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstance> _Skel_BodyDown_Mat_Extra;

		// Token: 0x04013D88 RID: 81288
		internal static int __PropertyOffset_37;

		// Token: 0x04013D89 RID: 81289
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInterface> _ReferencedOulineMaterials;

		// Token: 0x04013D8A RID: 81290
		internal static int __PropertyOffset_38;

		// Token: 0x04013D8B RID: 81291
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SNpcChildPart> _ChildParts;

		// Token: 0x04013D8C RID: 81292
		internal static int __PropertyOffset_39;

		// Token: 0x04013D8D RID: 81293
		[Nullable(2)]
		private TArray<FName> _HideParentBoneNames;

		// Token: 0x04013D8E RID: 81294
		private static IntPtr __IsSeq_NativeFunctionPtr;

		// Token: 0x04013D8F RID: 81295
		private static IntPtr __SetOLReference_NativeFunctionPtr;

		// Token: 0x04013D90 RID: 81296
		private static IntPtr __GetOutlineReference_NativeFunctionPtr;

		// Token: 0x04013D91 RID: 81297
		private static IntPtr __FixNPCOutline_NativeFunctionPtr;

		// Token: 0x04013D92 RID: 81298
		private static IntPtr __Set_Single_Override_NativeFunctionPtr;

		// Token: 0x04013D93 RID: 81299
		private static IntPtr __Set_Override_NativeFunctionPtr;

		// Token: 0x04013D94 RID: 81300
		private static IntPtr __GetAllPartMaterials_NativeFunctionPtr;

		// Token: 0x04013D95 RID: 81301
		private static IntPtr __GetAllParts_NativeFunctionPtr;

		// Token: 0x04013D96 RID: 81302
		private static IntPtr __HasSkelBody_NativeFunctionPtr;

		// Token: 0x04013D97 RID: 81303
		private static IntPtr __HasSkelBodyDown_NativeFunctionPtr;

		// Token: 0x04013D98 RID: 81304
		private static IntPtr __HasSkelBodyUp_NativeFunctionPtr;

		// Token: 0x04013D99 RID: 81305
		private static IntPtr __HasSkelFace_NativeFunctionPtr;

		// Token: 0x04013D9A RID: 81306
		private static IntPtr __HasSkelHair_NativeFunctionPtr;

		// Token: 0x04013D9B RID: 81307
		private static IntPtr __HasSkelMain_NativeFunctionPtr;

		// Token: 0x04013D9C RID: 81308
		private static IntPtr __IsEmpty_NativeFunctionPtr;

		// Token: 0x04013D9D RID: 81309
		private static IntPtr __OnPreSave_NativeFunctionPtr;

		// Token: 0x04013D9E RID: 81310
		private static IntPtr __ExecuteUbergraph_PD_NpcSetupData_NativeFunctionPtr;

		// Token: 0x0200A03D RID: 41021
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __IsSeq_FunctionParams
		{
			// Token: 0x04032C79 RID: 207993
			[FieldOffset(0)]
			public bool bSeq;
		}

		// Token: 0x0200A03E RID: 41022
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 448)]
		protected ref struct __GetOutlineReference_FunctionParams
		{
			// Token: 0x04032C7A RID: 207994
			[FieldOffset(0)]
			public bool bSeq;

			// Token: 0x04032C7B RID: 207995
			[FieldOffset(8)]
			public IntPtr Skel;

			// Token: 0x04032C7C RID: 207996
			[FieldOffset(16)]
			public IntPtr mat;

			// Token: 0x04032C7D RID: 207997
			[FieldOffset(24)]
			public byte mat_extra;

			// Token: 0x04032C7E RID: 207998
			[FieldOffset(40)]
			public byte OutOLMat;
		}

		// Token: 0x0200A03F RID: 41023
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 416)]
		protected ref struct __Set_Single_Override_FunctionParams
		{
			// Token: 0x04032C7F RID: 207999
			[FieldOffset(0)]
			public IntPtr skel_mesh;

			// Token: 0x04032C80 RID: 208000
			[FieldOffset(8)]
			public IntPtr mat;

			// Token: 0x04032C81 RID: 208001
			[FieldOffset(16)]
			public byte mat_extra;
		}

		// Token: 0x0200A040 RID: 41024
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __GetAllPartMaterials_FunctionParams
		{
			// Token: 0x04032C82 RID: 208002
			[FieldOffset(0)]
			public byte Results;
		}

		// Token: 0x0200A041 RID: 41025
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __GetAllParts_FunctionParams
		{
			// Token: 0x04032C83 RID: 208003
			[FieldOffset(0)]
			public byte OutParts;
		}

		// Token: 0x0200A042 RID: 41026
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __HasSkelBody_FunctionParams
		{
			// Token: 0x04032C84 RID: 208004
			[FieldOffset(0)]
			public bool Result;
		}

		// Token: 0x0200A043 RID: 41027
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __HasSkelBodyDown_FunctionParams
		{
			// Token: 0x04032C85 RID: 208005
			[FieldOffset(0)]
			public bool Result;
		}

		// Token: 0x0200A044 RID: 41028
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __HasSkelBodyUp_FunctionParams
		{
			// Token: 0x04032C86 RID: 208006
			[FieldOffset(0)]
			public bool Result;
		}

		// Token: 0x0200A045 RID: 41029
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __HasSkelFace_FunctionParams
		{
			// Token: 0x04032C87 RID: 208007
			[FieldOffset(0)]
			public bool Result;
		}

		// Token: 0x0200A046 RID: 41030
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __HasSkelHair_FunctionParams
		{
			// Token: 0x04032C88 RID: 208008
			[FieldOffset(0)]
			public bool Result;
		}

		// Token: 0x0200A047 RID: 41031
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __HasSkelMain_FunctionParams
		{
			// Token: 0x04032C89 RID: 208009
			[FieldOffset(0)]
			public bool Result;
		}

		// Token: 0x0200A048 RID: 41032
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 13)]
		protected ref struct __IsEmpty_FunctionParams
		{
			// Token: 0x04032C8A RID: 208010
			[FieldOffset(0)]
			public bool Result;
		}

		// Token: 0x0200A049 RID: 41033
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_PD_NpcSetupData_FunctionParams
		{
			// Token: 0x04032C8B RID: 208011
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
