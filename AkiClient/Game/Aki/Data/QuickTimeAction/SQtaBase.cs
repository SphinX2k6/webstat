using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using AkiClient.Game.Aki.Data.Qte;
using AkiClient.Game.Aki.Data.QuickTimeAction.Customization;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.QuickTimeAction
{
	// Token: 0x02003E1D RID: 15901
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/QuickTimeAction/SQtaBase.SQtaBase")]
	[UnrealStructLayout(176, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 176)]
	public class SQtaBase : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060272DE RID: 160478 RVA: 0x009EBAC4 File Offset: 0x009E9CC4
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SQtaBase._ScriptStructPtr != 0) ? SQtaBase._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/QuickTimeAction/SQtaBase.SQtaBase", ref SQtaBase._ScriptStructPtr);
		}

		// Token: 0x17005B7D RID: 23421
		// (get) Token: 0x060272DF RID: 160479 RVA: 0x009EBAE8 File Offset: 0x009E9CE8
		// (set) Token: 0x060272E0 RID: 160480 RVA: 0x009EBAF8 File Offset: 0x009E9CF8
		public unsafe bool IsBlockFightInput
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaBase.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaBase.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005B7E RID: 23422
		// (get) Token: 0x060272E1 RID: 160481 RVA: 0x009EBB09 File Offset: 0x009E9D09
		// (set) Token: 0x060272E2 RID: 160482 RVA: 0x009EBB19 File Offset: 0x009E9D19
		public unsafe bool EnableInputDistributeFilter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaBase.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaBase.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005B7F RID: 23423
		// (get) Token: 0x060272E3 RID: 160483 RVA: 0x009EBB2C File Offset: 0x009E9D2C
		// (set) Token: 0x060272E4 RID: 160484 RVA: 0x009EBB6F File Offset: 0x009E9D6F
		public SQtaInputDistribute InputDistributeFilterConfig
		{
			get
			{
				base.FastCheckIsValid();
				SQtaInputDistribute result;
				if ((result = this._InputDistributeFilterConfig) == null)
				{
					result = (this._InputDistributeFilterConfig = new SQtaInputDistribute(base.NativePtr + (IntPtr)SQtaBase.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SQtaInputDistribute.StaticStruct(), base.NativePtr + (IntPtr)SQtaBase.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005B80 RID: 23424
		// (get) Token: 0x060272E5 RID: 160485 RVA: 0x009EBB90 File Offset: 0x009E9D90
		// (set) Token: 0x060272E6 RID: 160486 RVA: 0x009EBBA0 File Offset: 0x009E9DA0
		public unsafe bool HideAllBattleUi
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaBase.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaBase.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005B81 RID: 23425
		// (get) Token: 0x060272E7 RID: 160487 RVA: 0x009EBBB1 File Offset: 0x009E9DB1
		// (set) Token: 0x060272E8 RID: 160488 RVA: 0x009EBBC1 File Offset: 0x009E9DC1
		public unsafe bool HideAllBattleUiInMobile
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaBase.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaBase.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005B82 RID: 23426
		// (get) Token: 0x060272E9 RID: 160489 RVA: 0x009EBBD4 File Offset: 0x009E9DD4
		// (set) Token: 0x060272EA RID: 160490 RVA: 0x009EBC17 File Offset: 0x009E9E17
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<EBattleUIChild>> HideUiElement
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
				if ((result = this._HideUiElement) == null)
				{
					result = (this._HideUiElement = new TArray<TEnumAsByte<EBattleUIChild>>(base.NativePtr + (IntPtr)SQtaBase.__PropertyOffset_5, base.MemoryOwner ?? this));
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
				this.HideUiElement.CopyAssign(value);
			}
		}

		// Token: 0x17005B83 RID: 23427
		// (get) Token: 0x060272EB RID: 160491 RVA: 0x009EBC28 File Offset: 0x009E9E28
		// (set) Token: 0x060272EC RID: 160492 RVA: 0x009EBC6B File Offset: 0x009E9E6B
		public TArray<SCommonQteButton> InputConfig
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SCommonQteButton> result;
				if ((result = this._InputConfig) == null)
				{
					result = (this._InputConfig = new TArray<SCommonQteButton>(base.NativePtr + (IntPtr)SQtaBase.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.InputConfig.CopyAssign(value);
			}
		}

		// Token: 0x17005B84 RID: 23428
		// (get) Token: 0x060272ED RID: 160493 RVA: 0x009EBC79 File Offset: 0x009E9E79
		// (set) Token: 0x060272EE RID: 160494 RVA: 0x009EBC89 File Offset: 0x009E9E89
		public unsafe float Duration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaBase.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaBase.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005B85 RID: 23429
		// (get) Token: 0x060272EF RID: 160495 RVA: 0x009EBC9A File Offset: 0x009E9E9A
		// (set) Token: 0x060272F0 RID: 160496 RVA: 0x009EBCAA File Offset: 0x009E9EAA
		public unsafe float LeastDuration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaBase.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaBase.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005B86 RID: 23430
		// (get) Token: 0x060272F1 RID: 160497 RVA: 0x009EBCBB File Offset: 0x009E9EBB
		// (set) Token: 0x060272F2 RID: 160498 RVA: 0x009EBCCB File Offset: 0x009E9ECB
		public unsafe float TimeDilation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaBase.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaBase.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005B87 RID: 23431
		// (get) Token: 0x060272F3 RID: 160499 RVA: 0x009EBCDC File Offset: 0x009E9EDC
		// (set) Token: 0x060272F4 RID: 160500 RVA: 0x009EBD1F File Offset: 0x009E9F1F
		public FGameplayTagContainer ActiveTags
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._ActiveTags) == null)
				{
					result = (this._ActiveTags = new FGameplayTagContainer(base.NativePtr + (IntPtr)SQtaBase.__PropertyOffset_10, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SQtaBase.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005B88 RID: 23432
		// (get) Token: 0x060272F5 RID: 160501 RVA: 0x009EBD40 File Offset: 0x009E9F40
		// (set) Token: 0x060272F6 RID: 160502 RVA: 0x009EBD54 File Offset: 0x009E9F54
		[Nullable(0)]
		public unsafe TEnumAsByte<EQtaType> QtaType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaBase.__PropertyOffset_11);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SQtaBase.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17005B89 RID: 23433
		// (get) Token: 0x060272F7 RID: 160503 RVA: 0x009EBD6C File Offset: 0x009E9F6C
		// (set) Token: 0x060272F8 RID: 160504 RVA: 0x009EBDAF File Offset: 0x009E9FAF
		public SQtaCustomization CustomizationConfig
		{
			get
			{
				base.FastCheckIsValid();
				SQtaCustomization result;
				if ((result = this._CustomizationConfig) == null)
				{
					result = (this._CustomizationConfig = new SQtaCustomization(base.NativePtr + (IntPtr)SQtaBase.__PropertyOffset_12, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SQtaCustomization.StaticStruct(), base.NativePtr + (IntPtr)SQtaBase.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x060272F9 RID: 160505 RVA: 0x009EBDD0 File Offset: 0x009E9FD0
		public SQtaBase()
		{
		}

		// Token: 0x060272FA RID: 160506 RVA: 0x009EBDD8 File Offset: 0x009E9FD8
		public SQtaBase(bool IsBlockFightInput, bool EnableInputDistributeFilter, SQtaInputDistribute InputDistributeFilterConfig, bool HideAllBattleUi, bool HideAllBattleUiInMobile, [Nullable(new byte[]
		{
			1,
			0
		})] TArray<TEnumAsByte<EBattleUIChild>> HideUiElement, TArray<SCommonQteButton> InputConfig, float Duration, float LeastDuration, float TimeDilation, FGameplayTagContainer ActiveTags, [Nullable(0)] TEnumAsByte<EQtaType> QtaType, SQtaCustomization CustomizationConfig)
		{
			this.IsBlockFightInput = IsBlockFightInput;
			this.EnableInputDistributeFilter = EnableInputDistributeFilter;
			this.InputDistributeFilterConfig = InputDistributeFilterConfig;
			this.HideAllBattleUi = HideAllBattleUi;
			this.HideAllBattleUiInMobile = HideAllBattleUiInMobile;
			this.HideUiElement = HideUiElement;
			this.InputConfig = InputConfig;
			this.Duration = Duration;
			this.LeastDuration = LeastDuration;
			this.TimeDilation = TimeDilation;
			this.ActiveTags = ActiveTags;
			this.QtaType = QtaType;
			this.CustomizationConfig = CustomizationConfig;
		}

		// Token: 0x060272FB RID: 160507 RVA: 0x009EBE50 File Offset: 0x009EA050
		protected override IntPtr GetUStructPtr()
		{
			return SQtaBase.StaticStruct();
		}

		// Token: 0x060272FC RID: 160508 RVA: 0x009EBE5C File Offset: 0x009EA05C
		[NullableContext(2)]
		public SQtaBase(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060272FD RID: 160509 RVA: 0x009EBE66 File Offset: 0x009EA066
		public SQtaBase(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060272FE RID: 160510 RVA: 0x009EBE71 File Offset: 0x009EA071
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SQtaBase(Pointer, false, true);
		}

		// Token: 0x060272FF RID: 160511 RVA: 0x009EBE7B File Offset: 0x009EA07B
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SQtaBase(Pointer, MemoryOwner);
		}

		// Token: 0x040147C1 RID: 83905
		public const string __ObjectPath = "/Game/Aki/Data/QuickTimeAction/SQtaBase.SQtaBase";

		// Token: 0x040147C2 RID: 83906
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040147C3 RID: 83907
		internal static int __PropertyOffset_0;

		// Token: 0x040147C4 RID: 83908
		internal static int __PropertyOffset_1;

		// Token: 0x040147C5 RID: 83909
		internal static int __PropertyOffset_2;

		// Token: 0x040147C6 RID: 83910
		[Nullable(2)]
		private SQtaInputDistribute _InputDistributeFilterConfig;

		// Token: 0x040147C7 RID: 83911
		internal static int __PropertyOffset_3;

		// Token: 0x040147C8 RID: 83912
		internal static int __PropertyOffset_4;

		// Token: 0x040147C9 RID: 83913
		internal static int __PropertyOffset_5;

		// Token: 0x040147CA RID: 83914
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<EBattleUIChild>> _HideUiElement;

		// Token: 0x040147CB RID: 83915
		internal static int __PropertyOffset_6;

		// Token: 0x040147CC RID: 83916
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SCommonQteButton> _InputConfig;

		// Token: 0x040147CD RID: 83917
		internal static int __PropertyOffset_7;

		// Token: 0x040147CE RID: 83918
		internal static int __PropertyOffset_8;

		// Token: 0x040147CF RID: 83919
		internal static int __PropertyOffset_9;

		// Token: 0x040147D0 RID: 83920
		internal static int __PropertyOffset_10;

		// Token: 0x040147D1 RID: 83921
		[Nullable(2)]
		private FGameplayTagContainer _ActiveTags;

		// Token: 0x040147D2 RID: 83922
		internal static int __PropertyOffset_11;

		// Token: 0x040147D3 RID: 83923
		internal static int __PropertyOffset_12;

		// Token: 0x040147D4 RID: 83924
		[Nullable(2)]
		private SQtaCustomization _CustomizationConfig;
	}
}
