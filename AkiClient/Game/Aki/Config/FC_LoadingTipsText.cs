using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Config
{
	// Token: 0x02003F85 RID: 16261
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Config/FC_LoadingTipsText.FC_LoadingTipsText")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 48)]
	public class FC_LoadingTipsText : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028AC0 RID: 166592 RVA: 0x00A12412 File Offset: 0x00A10612
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (FC_LoadingTipsText._ScriptStructPtr != 0) ? FC_LoadingTipsText._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Config/FC_LoadingTipsText.FC_LoadingTipsText", ref FC_LoadingTipsText._ScriptStructPtr);
		}

		// Token: 0x17006364 RID: 25444
		// (get) Token: 0x06028AC1 RID: 166593 RVA: 0x00A12436 File Offset: 0x00A10636
		// (set) Token: 0x06028AC2 RID: 166594 RVA: 0x00A12446 File Offset: 0x00A10646
		public unsafe int KuroRowId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)FC_LoadingTipsText.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)FC_LoadingTipsText.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17006365 RID: 25445
		// (get) Token: 0x06028AC3 RID: 166595 RVA: 0x00A12457 File Offset: 0x00A10657
		// (set) Token: 0x06028AC4 RID: 166596 RVA: 0x00A12467 File Offset: 0x00A10667
		public unsafe int Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)FC_LoadingTipsText.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)FC_LoadingTipsText.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17006366 RID: 25446
		// (get) Token: 0x06028AC5 RID: 166597 RVA: 0x00A12478 File Offset: 0x00A10678
		// (set) Token: 0x06028AC6 RID: 166598 RVA: 0x00A12488 File Offset: 0x00A10688
		public unsafe int Weight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)FC_LoadingTipsText.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)FC_LoadingTipsText.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17006367 RID: 25447
		// (get) Token: 0x06028AC7 RID: 166599 RVA: 0x00A12499 File Offset: 0x00A10699
		// (set) Token: 0x06028AC8 RID: 166600 RVA: 0x00A124AD File Offset: 0x00A106AD
		public unsafe string TipsText
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)FC_LoadingTipsText.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)FC_LoadingTipsText.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x17006368 RID: 25448
		// (get) Token: 0x06028AC9 RID: 166601 RVA: 0x00A124C2 File Offset: 0x00A106C2
		// (set) Token: 0x06028ACA RID: 166602 RVA: 0x00A124D6 File Offset: 0x00A106D6
		public unsafe string Title
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)FC_LoadingTipsText.__PropertyOffset_4)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)FC_LoadingTipsText.__PropertyOffset_4)), value);
			}
		}

		// Token: 0x06028ACB RID: 166603 RVA: 0x00A124EB File Offset: 0x00A106EB
		public FC_LoadingTipsText()
		{
		}

		// Token: 0x06028ACC RID: 166604 RVA: 0x00A124F3 File Offset: 0x00A106F3
		public FC_LoadingTipsText(int KuroRowId, int Id, int Weight, string TipsText, string Title)
		{
			this.KuroRowId = KuroRowId;
			this.Id = Id;
			this.Weight = Weight;
			this.TipsText = TipsText;
			this.Title = Title;
		}

		// Token: 0x06028ACD RID: 166605 RVA: 0x00A12520 File Offset: 0x00A10720
		protected override IntPtr GetUStructPtr()
		{
			return FC_LoadingTipsText.StaticStruct();
		}

		// Token: 0x06028ACE RID: 166606 RVA: 0x00A1252C File Offset: 0x00A1072C
		[NullableContext(2)]
		public FC_LoadingTipsText(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028ACF RID: 166607 RVA: 0x00A12536 File Offset: 0x00A10736
		public FC_LoadingTipsText(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028AD0 RID: 166608 RVA: 0x00A12541 File Offset: 0x00A10741
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new FC_LoadingTipsText(Pointer, false, true);
		}

		// Token: 0x06028AD1 RID: 166609 RVA: 0x00A1254B File Offset: 0x00A1074B
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new FC_LoadingTipsText(Pointer, MemoryOwner);
		}

		// Token: 0x04015738 RID: 87864
		public const string __ObjectPath = "/Game/Aki/Config/FC_LoadingTipsText.FC_LoadingTipsText";

		// Token: 0x04015739 RID: 87865
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401573A RID: 87866
		internal static int __PropertyOffset_0;

		// Token: 0x0401573B RID: 87867
		internal static int __PropertyOffset_1;

		// Token: 0x0401573C RID: 87868
		internal static int __PropertyOffset_2;

		// Token: 0x0401573D RID: 87869
		internal static int __PropertyOffset_3;

		// Token: 0x0401573E RID: 87870
		internal static int __PropertyOffset_4;
	}
}
