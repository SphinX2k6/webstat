using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.QuickTimeAction.Customization
{
	// Token: 0x02003E2D RID: 15917
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/QuickTimeAction/Customization/SQtaCustomization_LimitedHold.SQtaCustomization_LimitedHold")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 64)]
	public class SQtaCustomization_LimitedHold : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060273A6 RID: 160678 RVA: 0x009ECCBA File Offset: 0x009EAEBA
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SQtaCustomization_LimitedHold._ScriptStructPtr != 0) ? SQtaCustomization_LimitedHold._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/QuickTimeAction/Customization/SQtaCustomization_LimitedHold.SQtaCustomization_LimitedHold", ref SQtaCustomization_LimitedHold._ScriptStructPtr);
		}

		// Token: 0x17005BAF RID: 23471
		// (get) Token: 0x060273A7 RID: 160679 RVA: 0x009ECCDE File Offset: 0x009EAEDE
		// (set) Token: 0x060273A8 RID: 160680 RVA: 0x009ECCEE File Offset: 0x009EAEEE
		public unsafe float TimeoutOnPress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaCustomization_LimitedHold.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaCustomization_LimitedHold.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005BB0 RID: 23472
		// (get) Token: 0x060273A9 RID: 160681 RVA: 0x009ECCFF File Offset: 0x009EAEFF
		// (set) Token: 0x060273AA RID: 160682 RVA: 0x009ECD0F File Offset: 0x009EAF0F
		public unsafe float TimeoutOnIdle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaCustomization_LimitedHold.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaCustomization_LimitedHold.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005BB1 RID: 23473
		// (get) Token: 0x060273AB RID: 160683 RVA: 0x009ECD20 File Offset: 0x009EAF20
		// (set) Token: 0x060273AC RID: 160684 RVA: 0x009ECD30 File Offset: 0x009EAF30
		public unsafe int TimesLimit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaCustomization_LimitedHold.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaCustomization_LimitedHold.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005BB2 RID: 23474
		// (get) Token: 0x060273AD RID: 160685 RVA: 0x009ECD41 File Offset: 0x009EAF41
		// (set) Token: 0x060273AE RID: 160686 RVA: 0x009ECD55 File Offset: 0x009EAF55
		[Nullable(0)]
		public unsafe TEnumAsByte<EQtaCustomization_ProgressResetType> MainProgressResetType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaCustomization_LimitedHold.__PropertyOffset_3);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SQtaCustomization_LimitedHold.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005BB3 RID: 23475
		// (get) Token: 0x060273AF RID: 160687 RVA: 0x009ECD6C File Offset: 0x009EAF6C
		// (set) Token: 0x060273B0 RID: 160688 RVA: 0x009ECDAF File Offset: 0x009EAFAF
		public SQtaCustomizationParam_Progress MainProgress
		{
			get
			{
				base.FastCheckIsValid();
				SQtaCustomizationParam_Progress result;
				if ((result = this._MainProgress) == null)
				{
					result = (this._MainProgress = new SQtaCustomizationParam_Progress(base.NativePtr + (IntPtr)SQtaCustomization_LimitedHold.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SQtaCustomizationParam_Progress.StaticStruct(), base.NativePtr + (IntPtr)SQtaCustomization_LimitedHold.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005BB4 RID: 23476
		// (get) Token: 0x060273B1 RID: 160689 RVA: 0x009ECDD0 File Offset: 0x009EAFD0
		// (set) Token: 0x060273B2 RID: 160690 RVA: 0x009ECE13 File Offset: 0x009EB013
		public TArray<SQtaCustomizationParam_BgBar> ProgressList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SQtaCustomizationParam_BgBar> result;
				if ((result = this._ProgressList) == null)
				{
					result = (this._ProgressList = new TArray<SQtaCustomizationParam_BgBar>(base.NativePtr + (IntPtr)SQtaCustomization_LimitedHold.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ProgressList.CopyAssign(value);
			}
		}

		// Token: 0x17005BB5 RID: 23477
		// (get) Token: 0x060273B3 RID: 160691 RVA: 0x009ECE24 File Offset: 0x009EB024
		// (set) Token: 0x060273B4 RID: 160692 RVA: 0x009ECE67 File Offset: 0x009EB067
		public TArray<SQtaCustomizationParam_Event> SpeedTriggerList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SQtaCustomizationParam_Event> result;
				if ((result = this._SpeedTriggerList) == null)
				{
					result = (this._SpeedTriggerList = new TArray<SQtaCustomizationParam_Event>(base.NativePtr + (IntPtr)SQtaCustomization_LimitedHold.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SpeedTriggerList.CopyAssign(value);
			}
		}

		// Token: 0x060273B5 RID: 160693 RVA: 0x009ECE75 File Offset: 0x009EB075
		public SQtaCustomization_LimitedHold()
		{
		}

		// Token: 0x060273B6 RID: 160694 RVA: 0x009ECE7D File Offset: 0x009EB07D
		public SQtaCustomization_LimitedHold(float TimeoutOnPress, float TimeoutOnIdle, int TimesLimit, [Nullable(0)] TEnumAsByte<EQtaCustomization_ProgressResetType> MainProgressResetType, SQtaCustomizationParam_Progress MainProgress, TArray<SQtaCustomizationParam_BgBar> ProgressList, TArray<SQtaCustomizationParam_Event> SpeedTriggerList)
		{
			this.TimeoutOnPress = TimeoutOnPress;
			this.TimeoutOnIdle = TimeoutOnIdle;
			this.TimesLimit = TimesLimit;
			this.MainProgressResetType = MainProgressResetType;
			this.MainProgress = MainProgress;
			this.ProgressList = ProgressList;
			this.SpeedTriggerList = SpeedTriggerList;
		}

		// Token: 0x060273B7 RID: 160695 RVA: 0x009ECEBA File Offset: 0x009EB0BA
		protected override IntPtr GetUStructPtr()
		{
			return SQtaCustomization_LimitedHold.StaticStruct();
		}

		// Token: 0x060273B8 RID: 160696 RVA: 0x009ECEC6 File Offset: 0x009EB0C6
		[NullableContext(2)]
		public SQtaCustomization_LimitedHold(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060273B9 RID: 160697 RVA: 0x009ECED0 File Offset: 0x009EB0D0
		public SQtaCustomization_LimitedHold(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060273BA RID: 160698 RVA: 0x009ECEDB File Offset: 0x009EB0DB
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SQtaCustomization_LimitedHold(Pointer, false, true);
		}

		// Token: 0x060273BB RID: 160699 RVA: 0x009ECEE5 File Offset: 0x009EB0E5
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SQtaCustomization_LimitedHold(Pointer, MemoryOwner);
		}

		// Token: 0x0401482A RID: 84010
		public const string __ObjectPath = "/Game/Aki/Data/QuickTimeAction/Customization/SQtaCustomization_LimitedHold.SQtaCustomization_LimitedHold";

		// Token: 0x0401482B RID: 84011
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401482C RID: 84012
		internal static int __PropertyOffset_0;

		// Token: 0x0401482D RID: 84013
		internal static int __PropertyOffset_1;

		// Token: 0x0401482E RID: 84014
		internal static int __PropertyOffset_2;

		// Token: 0x0401482F RID: 84015
		internal static int __PropertyOffset_3;

		// Token: 0x04014830 RID: 84016
		internal static int __PropertyOffset_4;

		// Token: 0x04014831 RID: 84017
		[Nullable(2)]
		private SQtaCustomizationParam_Progress _MainProgress;

		// Token: 0x04014832 RID: 84018
		internal static int __PropertyOffset_5;

		// Token: 0x04014833 RID: 84019
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SQtaCustomizationParam_BgBar> _ProgressList;

		// Token: 0x04014834 RID: 84020
		internal static int __PropertyOffset_6;

		// Token: 0x04014835 RID: 84021
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SQtaCustomizationParam_Event> _SpeedTriggerList;
	}
}
