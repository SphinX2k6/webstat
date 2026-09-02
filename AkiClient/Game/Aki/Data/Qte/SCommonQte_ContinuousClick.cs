using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Qte
{
	// Token: 0x02003E47 RID: 15943
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Qte/SCommonQte_ContinuousClick.SCommonQte_ContinuousClick")]
	[UnrealStructLayout(224, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 220)]
	public class SCommonQte_ContinuousClick : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060274C9 RID: 160969 RVA: 0x009EE940 File Offset: 0x009ECB40
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCommonQte_ContinuousClick._ScriptStructPtr != 0) ? SCommonQte_ContinuousClick._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Qte/SCommonQte_ContinuousClick.SCommonQte_ContinuousClick", ref SCommonQte_ContinuousClick._ScriptStructPtr);
		}

		// Token: 0x17005C11 RID: 23569
		// (get) Token: 0x060274CA RID: 160970 RVA: 0x009EE964 File Offset: 0x009ECB64
		// (set) Token: 0x060274CB RID: 160971 RVA: 0x009EE978 File Offset: 0x009ECB78
		public unsafe TEnumAsByte<ECommonQteViewType_SingleButtonContinuousClick> ViewType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005C12 RID: 23570
		// (get) Token: 0x060274CC RID: 160972 RVA: 0x009EE990 File Offset: 0x009ECB90
		// (set) Token: 0x060274CD RID: 160973 RVA: 0x009EE9D3 File Offset: 0x009ECBD3
		[Nullable(1)]
		public SCommonQteButton UIConfig
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				SCommonQteButton result;
				if ((result = this._UIConfig) == null)
				{
					result = (this._UIConfig = new SCommonQteButton(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCommonQteButton.StaticStruct(), base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005C13 RID: 23571
		// (get) Token: 0x060274CE RID: 160974 RVA: 0x009EE9F4 File Offset: 0x009ECBF4
		// (set) Token: 0x060274CF RID: 160975 RVA: 0x009EEA08 File Offset: 0x009ECC08
		public unsafe TEnumAsByte<ECommonQteInteractiveTiming> InteractiveTiming
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005C14 RID: 23572
		// (get) Token: 0x060274D0 RID: 160976 RVA: 0x009EEA1D File Offset: 0x009ECC1D
		// (set) Token: 0x060274D1 RID: 160977 RVA: 0x009EEA2D File Offset: 0x009ECC2D
		public unsafe bool IsShowBorder
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005C15 RID: 23573
		// (get) Token: 0x060274D2 RID: 160978 RVA: 0x009EEA3E File Offset: 0x009ECC3E
		// (set) Token: 0x060274D3 RID: 160979 RVA: 0x009EEA4E File Offset: 0x009ECC4E
		public unsafe bool IsShowTip
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005C16 RID: 23574
		// (get) Token: 0x060274D4 RID: 160980 RVA: 0x009EEA5F File Offset: 0x009ECC5F
		// (set) Token: 0x060274D5 RID: 160981 RVA: 0x009EEA73 File Offset: 0x009ECC73
		[Nullable(1)]
		public unsafe string TipTextId
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_5)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_5)), value);
			}
		}

		// Token: 0x17005C17 RID: 23575
		// (get) Token: 0x060274D6 RID: 160982 RVA: 0x009EEA88 File Offset: 0x009ECC88
		// (set) Token: 0x060274D7 RID: 160983 RVA: 0x009EEA98 File Offset: 0x009ECC98
		public unsafe float InitialEnergyPercent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005C18 RID: 23576
		// (get) Token: 0x060274D8 RID: 160984 RVA: 0x009EEAA9 File Offset: 0x009ECCA9
		// (set) Token: 0x060274D9 RID: 160985 RVA: 0x009EEAB9 File Offset: 0x009ECCB9
		public unsafe float TargetEnergyPercent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005C19 RID: 23577
		// (get) Token: 0x060274DA RID: 160986 RVA: 0x009EEACA File Offset: 0x009ECCCA
		// (set) Token: 0x060274DB RID: 160987 RVA: 0x009EEADA File Offset: 0x009ECCDA
		public unsafe float DeltaEnergyPercentPerSecond
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005C1A RID: 23578
		// (get) Token: 0x060274DC RID: 160988 RVA: 0x009EEAEB File Offset: 0x009ECCEB
		// (set) Token: 0x060274DD RID: 160989 RVA: 0x009EEAFB File Offset: 0x009ECCFB
		public unsafe float DeltaEnergyPercentPerClick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005C1B RID: 23579
		// (get) Token: 0x060274DE RID: 160990 RVA: 0x009EEB0C File Offset: 0x009ECD0C
		// (set) Token: 0x060274DF RID: 160991 RVA: 0x009EEB1C File Offset: 0x009ECD1C
		public unsafe float PerformInterpSpeedForEnergyPercent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005C1C RID: 23580
		// (get) Token: 0x060274E0 RID: 160992 RVA: 0x009EEB2D File Offset: 0x009ECD2D
		// (set) Token: 0x060274E1 RID: 160993 RVA: 0x009EEB3D File Offset: 0x009ECD3D
		public unsafe bool IsAttachToActor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005C1D RID: 23581
		// (get) Token: 0x060274E2 RID: 160994 RVA: 0x009EEB4E File Offset: 0x009ECD4E
		// (set) Token: 0x060274E3 RID: 160995 RVA: 0x009EEB62 File Offset: 0x009ECD62
		public unsafe SCommonQte_Attach AttachConfig
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17005C1E RID: 23582
		// (get) Token: 0x060274E4 RID: 160996 RVA: 0x009EEB77 File Offset: 0x009ECD77
		// (set) Token: 0x060274E5 RID: 160997 RVA: 0x009EEB87 File Offset: 0x009ECD87
		public unsafe bool HideProgressBar
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005C1F RID: 23583
		// (get) Token: 0x060274E6 RID: 160998 RVA: 0x009EEB98 File Offset: 0x009ECD98
		// (set) Token: 0x060274E7 RID: 160999 RVA: 0x009EEBA8 File Offset: 0x009ECDA8
		public unsafe bool ProgressOnBegin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005C20 RID: 23584
		// (get) Token: 0x060274E8 RID: 161000 RVA: 0x009EEBB9 File Offset: 0x009ECDB9
		// (set) Token: 0x060274E9 RID: 161001 RVA: 0x009EEBC9 File Offset: 0x009ECDC9
		public unsafe float MaxComboInterval
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17005C21 RID: 23585
		// (get) Token: 0x060274EA RID: 161002 RVA: 0x009EEBDA File Offset: 0x009ECDDA
		// (set) Token: 0x060274EB RID: 161003 RVA: 0x009EEBEA File Offset: 0x009ECDEA
		public unsafe float InterpSpeedForEnergyPercent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_ContinuousClick.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x060274EC RID: 161004 RVA: 0x009EEBFB File Offset: 0x009ECDFB
		public SCommonQte_ContinuousClick()
		{
		}

		// Token: 0x060274ED RID: 161005 RVA: 0x009EEC04 File Offset: 0x009ECE04
		public SCommonQte_ContinuousClick(TEnumAsByte<ECommonQteViewType_SingleButtonContinuousClick> ViewType, [Nullable(1)] SCommonQteButton UIConfig, TEnumAsByte<ECommonQteInteractiveTiming> InteractiveTiming, bool IsShowBorder, bool IsShowTip, [Nullable(1)] string TipTextId, float InitialEnergyPercent, float TargetEnergyPercent, float DeltaEnergyPercentPerSecond, float DeltaEnergyPercentPerClick, float PerformInterpSpeedForEnergyPercent, bool IsAttachToActor, SCommonQte_Attach AttachConfig, bool HideProgressBar, bool ProgressOnBegin, float MaxComboInterval, float InterpSpeedForEnergyPercent)
		{
			this.ViewType = ViewType;
			this.UIConfig = UIConfig;
			this.InteractiveTiming = InteractiveTiming;
			this.IsShowBorder = IsShowBorder;
			this.IsShowTip = IsShowTip;
			this.TipTextId = TipTextId;
			this.InitialEnergyPercent = InitialEnergyPercent;
			this.TargetEnergyPercent = TargetEnergyPercent;
			this.DeltaEnergyPercentPerSecond = DeltaEnergyPercentPerSecond;
			this.DeltaEnergyPercentPerClick = DeltaEnergyPercentPerClick;
			this.PerformInterpSpeedForEnergyPercent = PerformInterpSpeedForEnergyPercent;
			this.IsAttachToActor = IsAttachToActor;
			this.AttachConfig = AttachConfig;
			this.HideProgressBar = HideProgressBar;
			this.ProgressOnBegin = ProgressOnBegin;
			this.MaxComboInterval = MaxComboInterval;
			this.InterpSpeedForEnergyPercent = InterpSpeedForEnergyPercent;
		}

		// Token: 0x060274EE RID: 161006 RVA: 0x009EEC9C File Offset: 0x009ECE9C
		protected override IntPtr GetUStructPtr()
		{
			return SCommonQte_ContinuousClick.StaticStruct();
		}

		// Token: 0x060274EF RID: 161007 RVA: 0x009EECA8 File Offset: 0x009ECEA8
		[NullableContext(2)]
		public SCommonQte_ContinuousClick(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060274F0 RID: 161008 RVA: 0x009EECB2 File Offset: 0x009ECEB2
		public SCommonQte_ContinuousClick(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060274F1 RID: 161009 RVA: 0x009EECBD File Offset: 0x009ECEBD
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCommonQte_ContinuousClick(Pointer, false, true);
		}

		// Token: 0x060274F2 RID: 161010 RVA: 0x009EECC7 File Offset: 0x009ECEC7
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCommonQte_ContinuousClick(Pointer, MemoryOwner);
		}

		// Token: 0x04014936 RID: 84278
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/Qte/SCommonQte_ContinuousClick.SCommonQte_ContinuousClick";

		// Token: 0x04014937 RID: 84279
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014938 RID: 84280
		internal static int __PropertyOffset_0;

		// Token: 0x04014939 RID: 84281
		internal static int __PropertyOffset_1;

		// Token: 0x0401493A RID: 84282
		[Nullable(2)]
		private SCommonQteButton _UIConfig;

		// Token: 0x0401493B RID: 84283
		internal static int __PropertyOffset_2;

		// Token: 0x0401493C RID: 84284
		internal static int __PropertyOffset_3;

		// Token: 0x0401493D RID: 84285
		internal static int __PropertyOffset_4;

		// Token: 0x0401493E RID: 84286
		internal static int __PropertyOffset_5;

		// Token: 0x0401493F RID: 84287
		internal static int __PropertyOffset_6;

		// Token: 0x04014940 RID: 84288
		internal static int __PropertyOffset_7;

		// Token: 0x04014941 RID: 84289
		internal static int __PropertyOffset_8;

		// Token: 0x04014942 RID: 84290
		internal static int __PropertyOffset_9;

		// Token: 0x04014943 RID: 84291
		internal static int __PropertyOffset_10;

		// Token: 0x04014944 RID: 84292
		internal static int __PropertyOffset_11;

		// Token: 0x04014945 RID: 84293
		internal static int __PropertyOffset_12;

		// Token: 0x04014946 RID: 84294
		internal static int __PropertyOffset_13;

		// Token: 0x04014947 RID: 84295
		internal static int __PropertyOffset_14;

		// Token: 0x04014948 RID: 84296
		internal static int __PropertyOffset_15;

		// Token: 0x04014949 RID: 84297
		internal static int __PropertyOffset_16;
	}
}
