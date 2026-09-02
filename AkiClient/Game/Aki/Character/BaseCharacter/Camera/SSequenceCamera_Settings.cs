using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x0200431D RID: 17181
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/SSequenceCamera_Settings.SSequenceCamera_Settings")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 66)]
	public class SSequenceCamera_Settings : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D92A RID: 186666 RVA: 0x00AC3B8D File Offset: 0x00AC1D8D
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSequenceCamera_Settings._ScriptStructPtr != 0) ? SSequenceCamera_Settings._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Camera/SSequenceCamera_Settings.SSequenceCamera_Settings", ref SSequenceCamera_Settings._ScriptStructPtr);
		}

		// Token: 0x17007CD7 RID: 31959
		// (get) Token: 0x0602D92B RID: 186667 RVA: 0x00AC3BB1 File Offset: 0x00AC1DB1
		// (set) Token: 0x0602D92C RID: 186668 RVA: 0x00AC3BC1 File Offset: 0x00AC1DC1
		public unsafe float BlendInTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSequenceCamera_Settings.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSequenceCamera_Settings.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007CD8 RID: 31960
		// (get) Token: 0x0602D92D RID: 186669 RVA: 0x00AC3BD2 File Offset: 0x00AC1DD2
		// (set) Token: 0x0602D92E RID: 186670 RVA: 0x00AC3BE2 File Offset: 0x00AC1DE2
		public unsafe float BlendOutTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSequenceCamera_Settings.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSequenceCamera_Settings.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007CD9 RID: 31961
		// (get) Token: 0x0602D92F RID: 186671 RVA: 0x00AC3BF3 File Offset: 0x00AC1DF3
		// (set) Token: 0x0602D930 RID: 186672 RVA: 0x00AC3C07 File Offset: 0x00AC1E07
		[Nullable(2)]
		public unsafe ULevelSequence CameraSequence
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ULevelSequence>(base.NativePtr / (IntPtr)sizeof(void*) + SSequenceCamera_Settings.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SSequenceCamera_Settings.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17007CDA RID: 31962
		// (get) Token: 0x0602D931 RID: 186673 RVA: 0x00AC3C1C File Offset: 0x00AC1E1C
		// (set) Token: 0x0602D932 RID: 186674 RVA: 0x00AC3C2C File Offset: 0x00AC1E2C
		public unsafe bool IsHideHud
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSequenceCamera_Settings.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSequenceCamera_Settings.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007CDB RID: 31963
		// (get) Token: 0x0602D933 RID: 186675 RVA: 0x00AC3C40 File Offset: 0x00AC1E40
		// (set) Token: 0x0602D934 RID: 186676 RVA: 0x00AC3C83 File Offset: 0x00AC1E83
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<EBattleUIChild>> VisibleChild
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<EBattleUIChild>> result;
				if ((result = this._VisibleChild) == null)
				{
					result = (this._VisibleChild = new TArray<TEnumAsByte<EBattleUIChild>>(base.NativePtr + (IntPtr)SSequenceCamera_Settings.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.VisibleChild.CopyAssign(value);
			}
		}

		// Token: 0x17007CDC RID: 31964
		// (get) Token: 0x0602D935 RID: 186677 RVA: 0x00AC3C91 File Offset: 0x00AC1E91
		// (set) Token: 0x0602D936 RID: 186678 RVA: 0x00AC3CA1 File Offset: 0x00AC1EA1
		public unsafe float HideHudTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSequenceCamera_Settings.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSequenceCamera_Settings.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007CDD RID: 31965
		// (get) Token: 0x0602D937 RID: 186679 RVA: 0x00AC3CB2 File Offset: 0x00AC1EB2
		// (set) Token: 0x0602D938 RID: 186680 RVA: 0x00AC3CC2 File Offset: 0x00AC1EC2
		public unsafe bool EnableSpecificSequenceTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSequenceCamera_Settings.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSequenceCamera_Settings.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007CDE RID: 31966
		// (get) Token: 0x0602D939 RID: 186681 RVA: 0x00AC3CD3 File Offset: 0x00AC1ED3
		// (set) Token: 0x0602D93A RID: 186682 RVA: 0x00AC3CE3 File Offset: 0x00AC1EE3
		public unsafe float SpecificSequenceTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSequenceCamera_Settings.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSequenceCamera_Settings.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17007CDF RID: 31967
		// (get) Token: 0x0602D93B RID: 186683 RVA: 0x00AC3CF4 File Offset: 0x00AC1EF4
		// (set) Token: 0x0602D93C RID: 186684 RVA: 0x00AC3D04 File Offset: 0x00AC1F04
		public unsafe bool NeedWaitInPlot
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSequenceCamera_Settings.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSequenceCamera_Settings.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007CE0 RID: 31968
		// (get) Token: 0x0602D93D RID: 186685 RVA: 0x00AC3D15 File Offset: 0x00AC1F15
		// (set) Token: 0x0602D93E RID: 186686 RVA: 0x00AC3D29 File Offset: 0x00AC1F29
		public unsafe SFrameAbstractData FrameAbstract
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSequenceCamera_Settings.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSequenceCamera_Settings.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17007CE1 RID: 31969
		// (get) Token: 0x0602D93F RID: 186687 RVA: 0x00AC3D3E File Offset: 0x00AC1F3E
		// (set) Token: 0x0602D940 RID: 186688 RVA: 0x00AC3D4E File Offset: 0x00AC1F4E
		public unsafe bool IsStopModify
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSequenceCamera_Settings.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSequenceCamera_Settings.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007CE2 RID: 31970
		// (get) Token: 0x0602D941 RID: 186689 RVA: 0x00AC3D5F File Offset: 0x00AC1F5F
		// (set) Token: 0x0602D942 RID: 186690 RVA: 0x00AC3D6F File Offset: 0x00AC1F6F
		public unsafe bool IsFinishBySkillInterrupt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSequenceCamera_Settings.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSequenceCamera_Settings.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602D943 RID: 186691 RVA: 0x00AC3D80 File Offset: 0x00AC1F80
		public SSequenceCamera_Settings()
		{
		}

		// Token: 0x0602D944 RID: 186692 RVA: 0x00AC3D88 File Offset: 0x00AC1F88
		[NullableContext(1)]
		public SSequenceCamera_Settings(float BlendInTime, float BlendOutTime, ULevelSequence CameraSequence, bool IsHideHud, [Nullable(new byte[]
		{
			1,
			0
		})] TArray<TEnumAsByte<EBattleUIChild>> VisibleChild, float HideHudTime, bool EnableSpecificSequenceTime, float SpecificSequenceTime, bool NeedWaitInPlot, SFrameAbstractData FrameAbstract, bool IsStopModify, bool IsFinishBySkillInterrupt)
		{
			this.BlendInTime = BlendInTime;
			this.BlendOutTime = BlendOutTime;
			this.CameraSequence = CameraSequence;
			this.IsHideHud = IsHideHud;
			this.VisibleChild = VisibleChild;
			this.HideHudTime = HideHudTime;
			this.EnableSpecificSequenceTime = EnableSpecificSequenceTime;
			this.SpecificSequenceTime = SpecificSequenceTime;
			this.NeedWaitInPlot = NeedWaitInPlot;
			this.FrameAbstract = FrameAbstract;
			this.IsStopModify = IsStopModify;
			this.IsFinishBySkillInterrupt = IsFinishBySkillInterrupt;
		}

		// Token: 0x0602D945 RID: 186693 RVA: 0x00AC3DF8 File Offset: 0x00AC1FF8
		protected override IntPtr GetUStructPtr()
		{
			return SSequenceCamera_Settings.StaticStruct();
		}

		// Token: 0x0602D946 RID: 186694 RVA: 0x00AC3E04 File Offset: 0x00AC2004
		[NullableContext(2)]
		public SSequenceCamera_Settings(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D947 RID: 186695 RVA: 0x00AC3E0E File Offset: 0x00AC200E
		public SSequenceCamera_Settings(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D948 RID: 186696 RVA: 0x00AC3E19 File Offset: 0x00AC2019
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSequenceCamera_Settings(Pointer, false, true);
		}

		// Token: 0x0602D949 RID: 186697 RVA: 0x00AC3E23 File Offset: 0x00AC2023
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSequenceCamera_Settings(Pointer, MemoryOwner);
		}

		// Token: 0x04019B15 RID: 105237
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/SSequenceCamera_Settings.SSequenceCamera_Settings";

		// Token: 0x04019B16 RID: 105238
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019B17 RID: 105239
		internal static int __PropertyOffset_0;

		// Token: 0x04019B18 RID: 105240
		internal static int __PropertyOffset_1;

		// Token: 0x04019B19 RID: 105241
		internal static int __PropertyOffset_2;

		// Token: 0x04019B1A RID: 105242
		internal static int __PropertyOffset_3;

		// Token: 0x04019B1B RID: 105243
		internal static int __PropertyOffset_4;

		// Token: 0x04019B1C RID: 105244
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<EBattleUIChild>> _VisibleChild;

		// Token: 0x04019B1D RID: 105245
		internal static int __PropertyOffset_5;

		// Token: 0x04019B1E RID: 105246
		internal static int __PropertyOffset_6;

		// Token: 0x04019B1F RID: 105247
		internal static int __PropertyOffset_7;

		// Token: 0x04019B20 RID: 105248
		internal static int __PropertyOffset_8;

		// Token: 0x04019B21 RID: 105249
		internal static int __PropertyOffset_9;

		// Token: 0x04019B22 RID: 105250
		internal static int __PropertyOffset_10;

		// Token: 0x04019B23 RID: 105251
		internal static int __PropertyOffset_11;
	}
}
