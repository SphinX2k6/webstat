using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Qte
{
	// Token: 0x02003E42 RID: 15938
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Qte/SCommonQteButton.SCommonQteButton")]
	[UnrealStructLayout(96, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 96)]
	public class SCommonQteButton : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602745A RID: 160858 RVA: 0x009EDDC1 File Offset: 0x009EBFC1
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCommonQteButton._ScriptStructPtr != 0) ? SCommonQteButton._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Qte/SCommonQteButton.SCommonQteButton", ref SCommonQteButton._ScriptStructPtr);
		}

		// Token: 0x17005BED RID: 23533
		// (get) Token: 0x0602745B RID: 160859 RVA: 0x009EDDE5 File Offset: 0x009EBFE5
		// (set) Token: 0x0602745C RID: 160860 RVA: 0x009EDDF5 File Offset: 0x009EBFF5
		public unsafe int ActionId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQteButton.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQteButton.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005BEE RID: 23534
		// (get) Token: 0x0602745D RID: 160861 RVA: 0x009EDE06 File Offset: 0x009EC006
		// (set) Token: 0x0602745E RID: 160862 RVA: 0x009EDE1A File Offset: 0x009EC01A
		[Nullable(0)]
		public unsafe TEnumAsByte<ECommonQteInputAction> Action
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQteButton.__PropertyOffset_1);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQteButton.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005BEF RID: 23535
		// (get) Token: 0x0602745F RID: 160863 RVA: 0x009EDE2F File Offset: 0x009EC02F
		// (set) Token: 0x06027460 RID: 160864 RVA: 0x009EDE4E File Offset: 0x009EC04E
		public TSoftObjectPtr<ULGUITexturePackerSpriteData> Icon
		{
			get
			{
				return new TSoftObjectPtr<ULGUITexturePackerSpriteData>(base.NativePtr + (IntPtr)SCommonQteButton.__PropertyOffset_2, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCommonQteButton.__PropertyOffset_2, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005BF0 RID: 23536
		// (get) Token: 0x06027461 RID: 160865 RVA: 0x009EDE73 File Offset: 0x009EC073
		// (set) Token: 0x06027462 RID: 160866 RVA: 0x009EDE83 File Offset: 0x009EC083
		public unsafe UIAnchorHorizontalAlign AnchorHAlign
		{
			get
			{
				return (UIAnchorHorizontalAlign)(*(base.NativePtr + (IntPtr)SCommonQteButton.__PropertyOffset_3));
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQteButton.__PropertyOffset_3) = (byte)value;
			}
		}

		// Token: 0x17005BF1 RID: 23537
		// (get) Token: 0x06027463 RID: 160867 RVA: 0x009EDE94 File Offset: 0x009EC094
		// (set) Token: 0x06027464 RID: 160868 RVA: 0x009EDEA4 File Offset: 0x009EC0A4
		public unsafe UIAnchorVerticalAlign AnchorVAlign
		{
			get
			{
				return (UIAnchorVerticalAlign)(*(base.NativePtr + (IntPtr)SCommonQteButton.__PropertyOffset_4));
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQteButton.__PropertyOffset_4) = (byte)value;
			}
		}

		// Token: 0x17005BF2 RID: 23538
		// (get) Token: 0x06027465 RID: 160869 RVA: 0x009EDEB5 File Offset: 0x009EC0B5
		// (set) Token: 0x06027466 RID: 160870 RVA: 0x009EDEC9 File Offset: 0x009EC0C9
		public unsafe FVector2D AnchorOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQteButton.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQteButton.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005BF3 RID: 23539
		// (get) Token: 0x06027467 RID: 160871 RVA: 0x009EDEDE File Offset: 0x009EC0DE
		// (set) Token: 0x06027468 RID: 160872 RVA: 0x009EDEF2 File Offset: 0x009EC0F2
		public unsafe FRotator AnchorRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQteButton.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQteButton.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005BF4 RID: 23540
		// (get) Token: 0x06027469 RID: 160873 RVA: 0x009EDF07 File Offset: 0x009EC107
		// (set) Token: 0x0602746A RID: 160874 RVA: 0x009EDF1B File Offset: 0x009EC11B
		public unsafe string TextId
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCommonQteButton.__PropertyOffset_7)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCommonQteButton.__PropertyOffset_7)), value);
			}
		}

		// Token: 0x0602746B RID: 160875 RVA: 0x009EDF30 File Offset: 0x009EC130
		public SCommonQteButton()
		{
		}

		// Token: 0x0602746C RID: 160876 RVA: 0x009EDF38 File Offset: 0x009EC138
		public SCommonQteButton(int ActionId, [Nullable(0)] TEnumAsByte<ECommonQteInputAction> Action, TSoftObjectPtr<ULGUITexturePackerSpriteData> Icon, UIAnchorHorizontalAlign AnchorHAlign, UIAnchorVerticalAlign AnchorVAlign, FVector2D AnchorOffset, FRotator AnchorRotation, string TextId)
		{
			this.ActionId = ActionId;
			this.Action = Action;
			this.Icon = Icon;
			this.AnchorHAlign = AnchorHAlign;
			this.AnchorVAlign = AnchorVAlign;
			this.AnchorOffset = AnchorOffset;
			this.AnchorRotation = AnchorRotation;
			this.TextId = TextId;
		}

		// Token: 0x0602746D RID: 160877 RVA: 0x009EDF88 File Offset: 0x009EC188
		protected override IntPtr GetUStructPtr()
		{
			return SCommonQteButton.StaticStruct();
		}

		// Token: 0x0602746E RID: 160878 RVA: 0x009EDF94 File Offset: 0x009EC194
		[NullableContext(2)]
		public SCommonQteButton(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602746F RID: 160879 RVA: 0x009EDF9E File Offset: 0x009EC19E
		public SCommonQteButton(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027470 RID: 160880 RVA: 0x009EDFA9 File Offset: 0x009EC1A9
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCommonQteButton(Pointer, false, true);
		}

		// Token: 0x06027471 RID: 160881 RVA: 0x009EDFB3 File Offset: 0x009EC1B3
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCommonQteButton(Pointer, MemoryOwner);
		}

		// Token: 0x040148FE RID: 84222
		public const string __ObjectPath = "/Game/Aki/Data/Qte/SCommonQteButton.SCommonQteButton";

		// Token: 0x040148FF RID: 84223
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014900 RID: 84224
		internal static int __PropertyOffset_0;

		// Token: 0x04014901 RID: 84225
		internal static int __PropertyOffset_1;

		// Token: 0x04014902 RID: 84226
		internal static int __PropertyOffset_2;

		// Token: 0x04014903 RID: 84227
		internal static int __PropertyOffset_3;

		// Token: 0x04014904 RID: 84228
		internal static int __PropertyOffset_4;

		// Token: 0x04014905 RID: 84229
		internal static int __PropertyOffset_5;

		// Token: 0x04014906 RID: 84230
		internal static int __PropertyOffset_6;

		// Token: 0x04014907 RID: 84231
		internal static int __PropertyOffset_7;
	}
}
