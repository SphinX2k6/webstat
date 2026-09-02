using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Sequence.SeqSubtitle
{
	// Token: 0x020043A1 RID: 17313
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Sequence/SeqSubtitle/SSubtitleText.SSubtitleText")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 48)]
	public class SSubtitleText : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602DFA2 RID: 188322 RVA: 0x00AD3398 File Offset: 0x00AD1598
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSubtitleText._ScriptStructPtr != 0) ? SSubtitleText._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Sequence/SeqSubtitle/SSubtitleText.SSubtitleText", ref SSubtitleText._ScriptStructPtr);
		}

		// Token: 0x17007E4E RID: 32334
		// (get) Token: 0x0602DFA3 RID: 188323 RVA: 0x00AD33BC File Offset: 0x00AD15BC
		// (set) Token: 0x0602DFA4 RID: 188324 RVA: 0x00AD33FF File Offset: 0x00AD15FF
		public unsafe FText CharacterName
		{
			get
			{
				base.FastCheckIsValid();
				FText result;
				if ((result = this._CharacterName) == null)
				{
					result = (this._CharacterName = new FText(base.NativePtr + (IntPtr)SSubtitleText.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				FText.NativeCopy((void*)(base.NativePtr + (byte*)((IntPtr)SSubtitleText.__PropertyOffset_0)), value.NativePtr, 1);
			}
		}

		// Token: 0x17007E4F RID: 32335
		// (get) Token: 0x0602DFA5 RID: 188325 RVA: 0x00AD341A File Offset: 0x00AD161A
		// (set) Token: 0x0602DFA6 RID: 188326 RVA: 0x00AD342E File Offset: 0x00AD162E
		[Nullable(0)]
		public unsafe TEnumAsByte<ESubtitleType> SubtitleType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SSubtitleText.__PropertyOffset_1);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SSubtitleText.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007E50 RID: 32336
		// (get) Token: 0x0602DFA7 RID: 188327 RVA: 0x00AD3444 File Offset: 0x00AD1644
		// (set) Token: 0x0602DFA8 RID: 188328 RVA: 0x00AD3487 File Offset: 0x00AD1687
		public TArray<FText> Subtitles
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FText> result;
				if ((result = this._Subtitles) == null)
				{
					result = (this._Subtitles = new TArray<FText>(base.NativePtr + (IntPtr)SSubtitleText.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Subtitles.CopyAssign(value);
			}
		}

		// Token: 0x0602DFA9 RID: 188329 RVA: 0x00AD3495 File Offset: 0x00AD1695
		public SSubtitleText()
		{
		}

		// Token: 0x0602DFAA RID: 188330 RVA: 0x00AD349D File Offset: 0x00AD169D
		public SSubtitleText(FText CharacterName, [Nullable(0)] TEnumAsByte<ESubtitleType> SubtitleType, TArray<FText> Subtitles)
		{
			this.CharacterName = CharacterName;
			this.SubtitleType = SubtitleType;
			this.Subtitles = Subtitles;
		}

		// Token: 0x0602DFAB RID: 188331 RVA: 0x00AD34BA File Offset: 0x00AD16BA
		protected override IntPtr GetUStructPtr()
		{
			return SSubtitleText.StaticStruct();
		}

		// Token: 0x0602DFAC RID: 188332 RVA: 0x00AD34C6 File Offset: 0x00AD16C6
		[NullableContext(2)]
		public SSubtitleText(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602DFAD RID: 188333 RVA: 0x00AD34D0 File Offset: 0x00AD16D0
		public SSubtitleText(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602DFAE RID: 188334 RVA: 0x00AD34DB File Offset: 0x00AD16DB
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSubtitleText(Pointer, false, true);
		}

		// Token: 0x0602DFAF RID: 188335 RVA: 0x00AD34E5 File Offset: 0x00AD16E5
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSubtitleText(Pointer, MemoryOwner);
		}

		// Token: 0x04019FBB RID: 106427
		public const string __ObjectPath = "/Game/Aki/Sequence/SeqSubtitle/SSubtitleText.SSubtitleText";

		// Token: 0x04019FBC RID: 106428
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019FBD RID: 106429
		internal static int __PropertyOffset_0;

		// Token: 0x04019FBE RID: 106430
		[Nullable(2)]
		private FText _CharacterName;

		// Token: 0x04019FBF RID: 106431
		internal static int __PropertyOffset_1;

		// Token: 0x04019FC0 RID: 106432
		internal static int __PropertyOffset_2;

		// Token: 0x04019FC1 RID: 106433
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FText> _Subtitles;
	}
}
