using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Qte
{
	// Token: 0x02003E4C RID: 15948
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Qte/SCommonQte_SingleClick.SCommonQte_SingleClick")]
	[UnrealStructLayout(192, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 188)]
	public class SCommonQte_SingleClick : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027569 RID: 161129 RVA: 0x009EF751 File Offset: 0x009ED951
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCommonQte_SingleClick._ScriptStructPtr != 0) ? SCommonQte_SingleClick._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Qte/SCommonQte_SingleClick.SCommonQte_SingleClick", ref SCommonQte_SingleClick._ScriptStructPtr);
		}

		// Token: 0x17005C4D RID: 23629
		// (get) Token: 0x0602756A RID: 161130 RVA: 0x009EF775 File Offset: 0x009ED975
		// (set) Token: 0x0602756B RID: 161131 RVA: 0x009EF789 File Offset: 0x009ED989
		public unsafe TEnumAsByte<ECommonQteViewType_SingleButton> ViewType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_SingleClick.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_SingleClick.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005C4E RID: 23630
		// (get) Token: 0x0602756C RID: 161132 RVA: 0x009EF7A0 File Offset: 0x009ED9A0
		// (set) Token: 0x0602756D RID: 161133 RVA: 0x009EF7E3 File Offset: 0x009ED9E3
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
					result = (this._UIConfig = new SCommonQteButton(base.NativePtr + (IntPtr)SCommonQte_SingleClick.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCommonQteButton.StaticStruct(), base.NativePtr + (IntPtr)SCommonQte_SingleClick.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005C4F RID: 23631
		// (get) Token: 0x0602756E RID: 161134 RVA: 0x009EF804 File Offset: 0x009EDA04
		// (set) Token: 0x0602756F RID: 161135 RVA: 0x009EF818 File Offset: 0x009EDA18
		public unsafe TEnumAsByte<ECommonQteInteractiveTiming> InteractiveTiming
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_SingleClick.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_SingleClick.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005C50 RID: 23632
		// (get) Token: 0x06027570 RID: 161136 RVA: 0x009EF82D File Offset: 0x009EDA2D
		// (set) Token: 0x06027571 RID: 161137 RVA: 0x009EF83D File Offset: 0x009EDA3D
		public unsafe bool IsShowBorder
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_SingleClick.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_SingleClick.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005C51 RID: 23633
		// (get) Token: 0x06027572 RID: 161138 RVA: 0x009EF84E File Offset: 0x009EDA4E
		// (set) Token: 0x06027573 RID: 161139 RVA: 0x009EF85E File Offset: 0x009EDA5E
		public unsafe bool IsAttachToActor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_SingleClick.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_SingleClick.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005C52 RID: 23634
		// (get) Token: 0x06027574 RID: 161140 RVA: 0x009EF86F File Offset: 0x009EDA6F
		// (set) Token: 0x06027575 RID: 161141 RVA: 0x009EF883 File Offset: 0x009EDA83
		public unsafe SCommonQte_Attach AttachConfig
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_SingleClick.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_SingleClick.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005C53 RID: 23635
		// (get) Token: 0x06027576 RID: 161142 RVA: 0x009EF898 File Offset: 0x009EDA98
		// (set) Token: 0x06027577 RID: 161143 RVA: 0x009EF8A8 File Offset: 0x009EDAA8
		public unsafe UIAnchorHorizontalAlign ButtonAnchorHAlign
		{
			get
			{
				return (UIAnchorHorizontalAlign)(*(base.NativePtr + (IntPtr)SCommonQte_SingleClick.__PropertyOffset_6));
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_SingleClick.__PropertyOffset_6) = (byte)value;
			}
		}

		// Token: 0x17005C54 RID: 23636
		// (get) Token: 0x06027578 RID: 161144 RVA: 0x009EF8B9 File Offset: 0x009EDAB9
		// (set) Token: 0x06027579 RID: 161145 RVA: 0x009EF8C9 File Offset: 0x009EDAC9
		public unsafe UIAnchorVerticalAlign ButtonAnchorVAlign
		{
			get
			{
				return (UIAnchorVerticalAlign)(*(base.NativePtr + (IntPtr)SCommonQte_SingleClick.__PropertyOffset_7));
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_SingleClick.__PropertyOffset_7) = (byte)value;
			}
		}

		// Token: 0x17005C55 RID: 23637
		// (get) Token: 0x0602757A RID: 161146 RVA: 0x009EF8DA File Offset: 0x009EDADA
		// (set) Token: 0x0602757B RID: 161147 RVA: 0x009EF8EE File Offset: 0x009EDAEE
		public unsafe FVector2D ButtonOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_SingleClick.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_SingleClick.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005C56 RID: 23638
		// (get) Token: 0x0602757C RID: 161148 RVA: 0x009EF903 File Offset: 0x009EDB03
		// (set) Token: 0x0602757D RID: 161149 RVA: 0x009EF913 File Offset: 0x009EDB13
		public unsafe float ProgressResponseStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_SingleClick.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_SingleClick.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005C57 RID: 23639
		// (get) Token: 0x0602757E RID: 161150 RVA: 0x009EF924 File Offset: 0x009EDB24
		// (set) Token: 0x0602757F RID: 161151 RVA: 0x009EF934 File Offset: 0x009EDB34
		public unsafe float ProgressResponseEnd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_SingleClick.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_SingleClick.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x06027580 RID: 161152 RVA: 0x009EF945 File Offset: 0x009EDB45
		public SCommonQte_SingleClick()
		{
		}

		// Token: 0x06027581 RID: 161153 RVA: 0x009EF950 File Offset: 0x009EDB50
		public SCommonQte_SingleClick(TEnumAsByte<ECommonQteViewType_SingleButton> ViewType, [Nullable(1)] SCommonQteButton UIConfig, TEnumAsByte<ECommonQteInteractiveTiming> InteractiveTiming, bool IsShowBorder, bool IsAttachToActor, SCommonQte_Attach AttachConfig, UIAnchorHorizontalAlign ButtonAnchorHAlign, UIAnchorVerticalAlign ButtonAnchorVAlign, FVector2D ButtonOffset, float ProgressResponseStart, float ProgressResponseEnd)
		{
			this.ViewType = ViewType;
			this.UIConfig = UIConfig;
			this.InteractiveTiming = InteractiveTiming;
			this.IsShowBorder = IsShowBorder;
			this.IsAttachToActor = IsAttachToActor;
			this.AttachConfig = AttachConfig;
			this.ButtonAnchorHAlign = ButtonAnchorHAlign;
			this.ButtonAnchorVAlign = ButtonAnchorVAlign;
			this.ButtonOffset = ButtonOffset;
			this.ProgressResponseStart = ProgressResponseStart;
			this.ProgressResponseEnd = ProgressResponseEnd;
		}

		// Token: 0x06027582 RID: 161154 RVA: 0x009EF9B8 File Offset: 0x009EDBB8
		protected override IntPtr GetUStructPtr()
		{
			return SCommonQte_SingleClick.StaticStruct();
		}

		// Token: 0x06027583 RID: 161155 RVA: 0x009EF9C4 File Offset: 0x009EDBC4
		[NullableContext(2)]
		public SCommonQte_SingleClick(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027584 RID: 161156 RVA: 0x009EF9CE File Offset: 0x009EDBCE
		public SCommonQte_SingleClick(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027585 RID: 161157 RVA: 0x009EF9D9 File Offset: 0x009EDBD9
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCommonQte_SingleClick(Pointer, false, true);
		}

		// Token: 0x06027586 RID: 161158 RVA: 0x009EF9E3 File Offset: 0x009EDBE3
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCommonQte_SingleClick(Pointer, MemoryOwner);
		}

		// Token: 0x04014981 RID: 84353
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/Qte/SCommonQte_SingleClick.SCommonQte_SingleClick";

		// Token: 0x04014982 RID: 84354
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014983 RID: 84355
		internal static int __PropertyOffset_0;

		// Token: 0x04014984 RID: 84356
		internal static int __PropertyOffset_1;

		// Token: 0x04014985 RID: 84357
		[Nullable(2)]
		private SCommonQteButton _UIConfig;

		// Token: 0x04014986 RID: 84358
		internal static int __PropertyOffset_2;

		// Token: 0x04014987 RID: 84359
		internal static int __PropertyOffset_3;

		// Token: 0x04014988 RID: 84360
		internal static int __PropertyOffset_4;

		// Token: 0x04014989 RID: 84361
		internal static int __PropertyOffset_5;

		// Token: 0x0401498A RID: 84362
		internal static int __PropertyOffset_6;

		// Token: 0x0401498B RID: 84363
		internal static int __PropertyOffset_7;

		// Token: 0x0401498C RID: 84364
		internal static int __PropertyOffset_8;

		// Token: 0x0401498D RID: 84365
		internal static int __PropertyOffset_9;

		// Token: 0x0401498E RID: 84366
		internal static int __PropertyOffset_10;
	}
}
