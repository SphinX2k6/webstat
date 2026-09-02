using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Qte
{
	// Token: 0x02003E3F RID: 15935
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Qte/SBattleQte.SBattleQte")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 56)]
	public class SBattleQte : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602741C RID: 160796 RVA: 0x009ED6F8 File Offset: 0x009EB8F8
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBattleQte._ScriptStructPtr != 0) ? SBattleQte._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Qte/SBattleQte.SBattleQte", ref SBattleQte._ScriptStructPtr);
		}

		// Token: 0x17005BDA RID: 23514
		// (get) Token: 0x0602741D RID: 160797 RVA: 0x009ED71C File Offset: 0x009EB91C
		// (set) Token: 0x0602741E RID: 160798 RVA: 0x009ED72C File Offset: 0x009EB92C
		public unsafe int QteId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBattleQte.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBattleQte.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005BDB RID: 23515
		// (get) Token: 0x0602741F RID: 160799 RVA: 0x009ED73D File Offset: 0x009EB93D
		// (set) Token: 0x06027420 RID: 160800 RVA: 0x009ED751 File Offset: 0x009EB951
		public unsafe string Desc
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SBattleQte.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SBattleQte.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x17005BDC RID: 23516
		// (get) Token: 0x06027421 RID: 160801 RVA: 0x009ED768 File Offset: 0x009EB968
		// (set) Token: 0x06027422 RID: 160802 RVA: 0x009ED7AB File Offset: 0x009EB9AB
		public TArray<SBattleQteAction> SuccessActions
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SBattleQteAction> result;
				if ((result = this._SuccessActions) == null)
				{
					result = (this._SuccessActions = new TArray<SBattleQteAction>(base.NativePtr + (IntPtr)SBattleQte.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SuccessActions.CopyAssign(value);
			}
		}

		// Token: 0x17005BDD RID: 23517
		// (get) Token: 0x06027423 RID: 160803 RVA: 0x009ED7BC File Offset: 0x009EB9BC
		// (set) Token: 0x06027424 RID: 160804 RVA: 0x009ED7FF File Offset: 0x009EB9FF
		public TArray<SBattleQteAction> FailActions
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SBattleQteAction> result;
				if ((result = this._FailActions) == null)
				{
					result = (this._FailActions = new TArray<SBattleQteAction>(base.NativePtr + (IntPtr)SBattleQte.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.FailActions.CopyAssign(value);
			}
		}

		// Token: 0x06027425 RID: 160805 RVA: 0x009ED80D File Offset: 0x009EBA0D
		public SBattleQte()
		{
		}

		// Token: 0x06027426 RID: 160806 RVA: 0x009ED815 File Offset: 0x009EBA15
		public SBattleQte(int QteId, string Desc, TArray<SBattleQteAction> SuccessActions, TArray<SBattleQteAction> FailActions)
		{
			this.QteId = QteId;
			this.Desc = Desc;
			this.SuccessActions = SuccessActions;
			this.FailActions = FailActions;
		}

		// Token: 0x06027427 RID: 160807 RVA: 0x009ED83A File Offset: 0x009EBA3A
		protected override IntPtr GetUStructPtr()
		{
			return SBattleQte.StaticStruct();
		}

		// Token: 0x06027428 RID: 160808 RVA: 0x009ED846 File Offset: 0x009EBA46
		[NullableContext(2)]
		public SBattleQte(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027429 RID: 160809 RVA: 0x009ED850 File Offset: 0x009EBA50
		public SBattleQte(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602742A RID: 160810 RVA: 0x009ED85B File Offset: 0x009EBA5B
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBattleQte(Pointer, false, true);
		}

		// Token: 0x0602742B RID: 160811 RVA: 0x009ED865 File Offset: 0x009EBA65
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBattleQte(Pointer, MemoryOwner);
		}

		// Token: 0x040148DA RID: 84186
		public const string __ObjectPath = "/Game/Aki/Data/Qte/SBattleQte.SBattleQte";

		// Token: 0x040148DB RID: 84187
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040148DC RID: 84188
		internal static int __PropertyOffset_0;

		// Token: 0x040148DD RID: 84189
		internal static int __PropertyOffset_1;

		// Token: 0x040148DE RID: 84190
		internal static int __PropertyOffset_2;

		// Token: 0x040148DF RID: 84191
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SBattleQteAction> _SuccessActions;

		// Token: 0x040148E0 RID: 84192
		internal static int __PropertyOffset_3;

		// Token: 0x040148E1 RID: 84193
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SBattleQteAction> _FailActions;
	}
}
