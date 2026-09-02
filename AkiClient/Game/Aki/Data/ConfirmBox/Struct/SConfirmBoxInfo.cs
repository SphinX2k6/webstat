using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.ConfirmBox.Struct
{
	// Token: 0x02003F03 RID: 16131
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/ConfirmBox/Struct/SConfirmBoxInfo.SConfirmBoxInfo")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 56)]
	public class SConfirmBoxInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060282E0 RID: 164576 RVA: 0x00A0484C File Offset: 0x00A02A4C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SConfirmBoxInfo._ScriptStructPtr != 0) ? SConfirmBoxInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/ConfirmBox/Struct/SConfirmBoxInfo.SConfirmBoxInfo", ref SConfirmBoxInfo._ScriptStructPtr);
		}

		// Token: 0x170060F2 RID: 24818
		// (get) Token: 0x060282E1 RID: 164577 RVA: 0x00A04870 File Offset: 0x00A02A70
		// (set) Token: 0x060282E2 RID: 164578 RVA: 0x00A04884 File Offset: 0x00A02A84
		public unsafe FName Name
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SConfirmBoxInfo.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SConfirmBoxInfo.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170060F3 RID: 24819
		// (get) Token: 0x060282E3 RID: 164579 RVA: 0x00A04899 File Offset: 0x00A02A99
		// (set) Token: 0x060282E4 RID: 164580 RVA: 0x00A048AD File Offset: 0x00A02AAD
		public unsafe FName Title
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SConfirmBoxInfo.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SConfirmBoxInfo.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170060F4 RID: 24820
		// (get) Token: 0x060282E5 RID: 164581 RVA: 0x00A048C2 File Offset: 0x00A02AC2
		// (set) Token: 0x060282E6 RID: 164582 RVA: 0x00A048D6 File Offset: 0x00A02AD6
		public unsafe FName Content
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SConfirmBoxInfo.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SConfirmBoxInfo.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170060F5 RID: 24821
		// (get) Token: 0x060282E7 RID: 164583 RVA: 0x00A048EC File Offset: 0x00A02AEC
		// (set) Token: 0x060282E8 RID: 164584 RVA: 0x00A0492F File Offset: 0x00A02B2F
		public TArray<FName> Options
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._Options) == null)
				{
					result = (this._Options = new TArray<FName>(base.NativePtr + (IntPtr)SConfirmBoxInfo.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Options.CopyAssign(value);
			}
		}

		// Token: 0x060282E9 RID: 164585 RVA: 0x00A0493D File Offset: 0x00A02B3D
		public SConfirmBoxInfo()
		{
		}

		// Token: 0x060282EA RID: 164586 RVA: 0x00A04945 File Offset: 0x00A02B45
		public SConfirmBoxInfo(FName Name, FName Title, FName Content, TArray<FName> Options)
		{
			this.Name = Name;
			this.Title = Title;
			this.Content = Content;
			this.Options = Options;
		}

		// Token: 0x060282EB RID: 164587 RVA: 0x00A0496A File Offset: 0x00A02B6A
		protected override IntPtr GetUStructPtr()
		{
			return SConfirmBoxInfo.StaticStruct();
		}

		// Token: 0x060282EC RID: 164588 RVA: 0x00A04976 File Offset: 0x00A02B76
		[NullableContext(2)]
		public SConfirmBoxInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060282ED RID: 164589 RVA: 0x00A04980 File Offset: 0x00A02B80
		public SConfirmBoxInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060282EE RID: 164590 RVA: 0x00A0498B File Offset: 0x00A02B8B
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SConfirmBoxInfo(Pointer, false, true);
		}

		// Token: 0x060282EF RID: 164591 RVA: 0x00A04995 File Offset: 0x00A02B95
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SConfirmBoxInfo(Pointer, MemoryOwner);
		}

		// Token: 0x040151F1 RID: 86513
		public const string __ObjectPath = "/Game/Aki/Data/ConfirmBox/Struct/SConfirmBoxInfo.SConfirmBoxInfo";

		// Token: 0x040151F2 RID: 86514
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040151F3 RID: 86515
		internal static int __PropertyOffset_0;

		// Token: 0x040151F4 RID: 86516
		internal static int __PropertyOffset_1;

		// Token: 0x040151F5 RID: 86517
		internal static int __PropertyOffset_2;

		// Token: 0x040151F6 RID: 86518
		internal static int __PropertyOffset_3;

		// Token: 0x040151F7 RID: 86519
		[Nullable(2)]
		private TArray<FName> _Options;
	}
}
