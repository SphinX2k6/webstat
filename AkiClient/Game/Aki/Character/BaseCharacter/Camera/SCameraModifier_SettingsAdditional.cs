using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x02004313 RID: 17171
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/SCameraModifier_SettingsAdditional.SCameraModifier_SettingsAdditional")]
	[UnrealStructLayout(168, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 168)]
	public class SCameraModifier_SettingsAdditional : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D82D RID: 186413 RVA: 0x00AC2390 File Offset: 0x00AC0590
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCameraModifier_SettingsAdditional._ScriptStructPtr != 0) ? SCameraModifier_SettingsAdditional._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Camera/SCameraModifier_SettingsAdditional.SCameraModifier_SettingsAdditional", ref SCameraModifier_SettingsAdditional._ScriptStructPtr);
		}

		// Token: 0x17007C80 RID: 31872
		// (get) Token: 0x0602D82E RID: 186414 RVA: 0x00AC23B4 File Offset: 0x00AC05B4
		// (set) Token: 0x0602D82F RID: 186415 RVA: 0x00AC23C8 File Offset: 0x00AC05C8
		public unsafe string Name
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17007C81 RID: 31873
		// (get) Token: 0x0602D830 RID: 186416 RVA: 0x00AC23DD File Offset: 0x00AC05DD
		// (set) Token: 0x0602D831 RID: 186417 RVA: 0x00AC23ED File Offset: 0x00AC05ED
		public unsafe bool IsUseArmLengthFloatCurve
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C82 RID: 31874
		// (get) Token: 0x0602D832 RID: 186418 RVA: 0x00AC2400 File Offset: 0x00AC0600
		// (set) Token: 0x0602D833 RID: 186419 RVA: 0x00AC2443 File Offset: 0x00AC0643
		public SFloatCurve ArmLengthFloatCurve
		{
			get
			{
				base.FastCheckIsValid();
				SFloatCurve result;
				if ((result = this._ArmLengthFloatCurve) == null)
				{
					result = (this._ArmLengthFloatCurve = new SFloatCurve(base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SFloatCurve.StaticStruct(), base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007C83 RID: 31875
		// (get) Token: 0x0602D834 RID: 186420 RVA: 0x00AC2464 File Offset: 0x00AC0664
		// (set) Token: 0x0602D835 RID: 186421 RVA: 0x00AC2474 File Offset: 0x00AC0674
		public unsafe bool IsUseArmRotationFloatCurve
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C84 RID: 31876
		// (get) Token: 0x0602D836 RID: 186422 RVA: 0x00AC2488 File Offset: 0x00AC0688
		// (set) Token: 0x0602D837 RID: 186423 RVA: 0x00AC24CB File Offset: 0x00AC06CB
		public SFloatCurve ArmRotationFloatCurve
		{
			get
			{
				base.FastCheckIsValid();
				SFloatCurve result;
				if ((result = this._ArmRotationFloatCurve) == null)
				{
					result = (this._ArmRotationFloatCurve = new SFloatCurve(base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SFloatCurve.StaticStruct(), base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007C85 RID: 31877
		// (get) Token: 0x0602D838 RID: 186424 RVA: 0x00AC24EC File Offset: 0x00AC06EC
		// (set) Token: 0x0602D839 RID: 186425 RVA: 0x00AC24FC File Offset: 0x00AC06FC
		public unsafe bool IsUseFovFloatCurve
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C86 RID: 31878
		// (get) Token: 0x0602D83A RID: 186426 RVA: 0x00AC2510 File Offset: 0x00AC0710
		// (set) Token: 0x0602D83B RID: 186427 RVA: 0x00AC2553 File Offset: 0x00AC0753
		public SFloatCurve FovFloatCurve
		{
			get
			{
				base.FastCheckIsValid();
				SFloatCurve result;
				if ((result = this._FovFloatCurve) == null)
				{
					result = (this._FovFloatCurve = new SFloatCurve(base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SFloatCurve.StaticStruct(), base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007C87 RID: 31879
		// (get) Token: 0x0602D83C RID: 186428 RVA: 0x00AC2574 File Offset: 0x00AC0774
		// (set) Token: 0x0602D83D RID: 186429 RVA: 0x00AC2584 File Offset: 0x00AC0784
		public unsafe bool IsModifiedCameraLens
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C88 RID: 31880
		// (get) Token: 0x0602D83E RID: 186430 RVA: 0x00AC2595 File Offset: 0x00AC0795
		// (set) Token: 0x0602D83F RID: 186431 RVA: 0x00AC25A5 File Offset: 0x00AC07A5
		public unsafe bool IsUseLensFloatCurve
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C89 RID: 31881
		// (get) Token: 0x0602D840 RID: 186432 RVA: 0x00AC25B8 File Offset: 0x00AC07B8
		// (set) Token: 0x0602D841 RID: 186433 RVA: 0x00AC25FB File Offset: 0x00AC07FB
		public SFloatCurve LensFloatCurve
		{
			get
			{
				base.FastCheckIsValid();
				SFloatCurve result;
				if ((result = this._LensFloatCurve) == null)
				{
					result = (this._LensFloatCurve = new SFloatCurve(base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_9, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SFloatCurve.StaticStruct(), base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007C8A RID: 31882
		// (get) Token: 0x0602D842 RID: 186434 RVA: 0x00AC261C File Offset: 0x00AC081C
		// (set) Token: 0x0602D843 RID: 186435 RVA: 0x00AC2630 File Offset: 0x00AC0830
		public unsafe SCameraModifier_Lens CameraLens
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17007C8B RID: 31883
		// (get) Token: 0x0602D844 RID: 186436 RVA: 0x00AC2645 File Offset: 0x00AC0845
		// (set) Token: 0x0602D845 RID: 186437 RVA: 0x00AC2655 File Offset: 0x00AC0855
		public unsafe bool IsUseCameraOffsetFloatCurve
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C8C RID: 31884
		// (get) Token: 0x0602D846 RID: 186438 RVA: 0x00AC2668 File Offset: 0x00AC0868
		// (set) Token: 0x0602D847 RID: 186439 RVA: 0x00AC26AB File Offset: 0x00AC08AB
		public SFloatCurve CameraOffsetFloatCurve
		{
			get
			{
				base.FastCheckIsValid();
				SFloatCurve result;
				if ((result = this._CameraOffsetFloatCurve) == null)
				{
					result = (this._CameraOffsetFloatCurve = new SFloatCurve(base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_12, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SFloatCurve.StaticStruct(), base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007C8D RID: 31885
		// (get) Token: 0x0602D848 RID: 186440 RVA: 0x00AC26CC File Offset: 0x00AC08CC
		// (set) Token: 0x0602D849 RID: 186441 RVA: 0x00AC26DC File Offset: 0x00AC08DC
		public unsafe bool IsModifiedArmOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C8E RID: 31886
		// (get) Token: 0x0602D84A RID: 186442 RVA: 0x00AC26ED File Offset: 0x00AC08ED
		// (set) Token: 0x0602D84B RID: 186443 RVA: 0x00AC2701 File Offset: 0x00AC0901
		public unsafe FVector ArmOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17007C8F RID: 31887
		// (get) Token: 0x0602D84C RID: 186444 RVA: 0x00AC2716 File Offset: 0x00AC0916
		// (set) Token: 0x0602D84D RID: 186445 RVA: 0x00AC2726 File Offset: 0x00AC0926
		public unsafe bool IsUseArmOffsetFloatCurve
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C90 RID: 31888
		// (get) Token: 0x0602D84E RID: 186446 RVA: 0x00AC2738 File Offset: 0x00AC0938
		// (set) Token: 0x0602D84F RID: 186447 RVA: 0x00AC277B File Offset: 0x00AC097B
		public SFloatCurve ArmOffsetFloatCurve
		{
			get
			{
				base.FastCheckIsValid();
				SFloatCurve result;
				if ((result = this._ArmOffsetFloatCurve) == null)
				{
					result = (this._ArmOffsetFloatCurve = new SFloatCurve(base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_16, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SFloatCurve.StaticStruct(), base.NativePtr + (IntPtr)SCameraModifier_SettingsAdditional.__PropertyOffset_16, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602D850 RID: 186448 RVA: 0x00AC279C File Offset: 0x00AC099C
		public SCameraModifier_SettingsAdditional()
		{
		}

		// Token: 0x0602D851 RID: 186449 RVA: 0x00AC27A4 File Offset: 0x00AC09A4
		public SCameraModifier_SettingsAdditional(string Name, bool IsUseArmLengthFloatCurve, SFloatCurve ArmLengthFloatCurve, bool IsUseArmRotationFloatCurve, SFloatCurve ArmRotationFloatCurve, bool IsUseFovFloatCurve, SFloatCurve FovFloatCurve, bool IsModifiedCameraLens, bool IsUseLensFloatCurve, SFloatCurve LensFloatCurve, SCameraModifier_Lens CameraLens, bool IsUseCameraOffsetFloatCurve, SFloatCurve CameraOffsetFloatCurve, bool IsModifiedArmOffset, FVector ArmOffset, bool IsUseArmOffsetFloatCurve, SFloatCurve ArmOffsetFloatCurve)
		{
			this.Name = Name;
			this.IsUseArmLengthFloatCurve = IsUseArmLengthFloatCurve;
			this.ArmLengthFloatCurve = ArmLengthFloatCurve;
			this.IsUseArmRotationFloatCurve = IsUseArmRotationFloatCurve;
			this.ArmRotationFloatCurve = ArmRotationFloatCurve;
			this.IsUseFovFloatCurve = IsUseFovFloatCurve;
			this.FovFloatCurve = FovFloatCurve;
			this.IsModifiedCameraLens = IsModifiedCameraLens;
			this.IsUseLensFloatCurve = IsUseLensFloatCurve;
			this.LensFloatCurve = LensFloatCurve;
			this.CameraLens = CameraLens;
			this.IsUseCameraOffsetFloatCurve = IsUseCameraOffsetFloatCurve;
			this.CameraOffsetFloatCurve = CameraOffsetFloatCurve;
			this.IsModifiedArmOffset = IsModifiedArmOffset;
			this.ArmOffset = ArmOffset;
			this.IsUseArmOffsetFloatCurve = IsUseArmOffsetFloatCurve;
			this.ArmOffsetFloatCurve = ArmOffsetFloatCurve;
		}

		// Token: 0x0602D852 RID: 186450 RVA: 0x00AC283C File Offset: 0x00AC0A3C
		protected override IntPtr GetUStructPtr()
		{
			return SCameraModifier_SettingsAdditional.StaticStruct();
		}

		// Token: 0x0602D853 RID: 186451 RVA: 0x00AC2848 File Offset: 0x00AC0A48
		[NullableContext(2)]
		public SCameraModifier_SettingsAdditional(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D854 RID: 186452 RVA: 0x00AC2852 File Offset: 0x00AC0A52
		public SCameraModifier_SettingsAdditional(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D855 RID: 186453 RVA: 0x00AC285D File Offset: 0x00AC0A5D
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCameraModifier_SettingsAdditional(Pointer, false, true);
		}

		// Token: 0x0602D856 RID: 186454 RVA: 0x00AC2867 File Offset: 0x00AC0A67
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCameraModifier_SettingsAdditional(Pointer, MemoryOwner);
		}

		// Token: 0x04019A95 RID: 105109
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/SCameraModifier_SettingsAdditional.SCameraModifier_SettingsAdditional";

		// Token: 0x04019A96 RID: 105110
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019A97 RID: 105111
		internal static int __PropertyOffset_0;

		// Token: 0x04019A98 RID: 105112
		internal static int __PropertyOffset_1;

		// Token: 0x04019A99 RID: 105113
		internal static int __PropertyOffset_2;

		// Token: 0x04019A9A RID: 105114
		[Nullable(2)]
		private SFloatCurve _ArmLengthFloatCurve;

		// Token: 0x04019A9B RID: 105115
		internal static int __PropertyOffset_3;

		// Token: 0x04019A9C RID: 105116
		internal static int __PropertyOffset_4;

		// Token: 0x04019A9D RID: 105117
		[Nullable(2)]
		private SFloatCurve _ArmRotationFloatCurve;

		// Token: 0x04019A9E RID: 105118
		internal static int __PropertyOffset_5;

		// Token: 0x04019A9F RID: 105119
		internal static int __PropertyOffset_6;

		// Token: 0x04019AA0 RID: 105120
		[Nullable(2)]
		private SFloatCurve _FovFloatCurve;

		// Token: 0x04019AA1 RID: 105121
		internal static int __PropertyOffset_7;

		// Token: 0x04019AA2 RID: 105122
		internal static int __PropertyOffset_8;

		// Token: 0x04019AA3 RID: 105123
		internal static int __PropertyOffset_9;

		// Token: 0x04019AA4 RID: 105124
		[Nullable(2)]
		private SFloatCurve _LensFloatCurve;

		// Token: 0x04019AA5 RID: 105125
		internal static int __PropertyOffset_10;

		// Token: 0x04019AA6 RID: 105126
		internal static int __PropertyOffset_11;

		// Token: 0x04019AA7 RID: 105127
		internal static int __PropertyOffset_12;

		// Token: 0x04019AA8 RID: 105128
		[Nullable(2)]
		private SFloatCurve _CameraOffsetFloatCurve;

		// Token: 0x04019AA9 RID: 105129
		internal static int __PropertyOffset_13;

		// Token: 0x04019AAA RID: 105130
		internal static int __PropertyOffset_14;

		// Token: 0x04019AAB RID: 105131
		internal static int __PropertyOffset_15;

		// Token: 0x04019AAC RID: 105132
		internal static int __PropertyOffset_16;

		// Token: 0x04019AAD RID: 105133
		[Nullable(2)]
		private SFloatCurve _ArmOffsetFloatCurve;
	}
}
