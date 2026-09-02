using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.UI.Module.ActiveDebug
{
	// Token: 0x0200398D RID: 14733
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/UI/Module/ActiveDebug/BvbPlayerItemData.BvbPlayerItemData")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 48)]
	public class BvbPlayerItemData : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0601DB56 RID: 121686 RVA: 0x008DE178 File Offset: 0x008DC378
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (BvbPlayerItemData._ScriptStructPtr != 0) ? BvbPlayerItemData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/UI/Module/ActiveDebug/BvbPlayerItemData.BvbPlayerItemData", ref BvbPlayerItemData._ScriptStructPtr);
		}

		// Token: 0x1700274A RID: 10058
		// (get) Token: 0x0601DB57 RID: 121687 RVA: 0x008DE19C File Offset: 0x008DC39C
		// (set) Token: 0x0601DB58 RID: 121688 RVA: 0x008DE1DF File Offset: 0x008DC3DF
		public TArray<BvbCardItemData> CardsOnField
		{
			get
			{
				base.FastCheckIsValid();
				TArray<BvbCardItemData> result;
				if ((result = this._CardsOnField) == null)
				{
					result = (this._CardsOnField = new TArray<BvbCardItemData>(base.NativePtr + (IntPtr)BvbPlayerItemData.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.CardsOnField.CopyAssign(value);
			}
		}

		// Token: 0x1700274B RID: 10059
		// (get) Token: 0x0601DB59 RID: 121689 RVA: 0x008DE1F0 File Offset: 0x008DC3F0
		// (set) Token: 0x0601DB5A RID: 121690 RVA: 0x008DE233 File Offset: 0x008DC433
		public TArray<BvbCardItemData> CardsOnHand
		{
			get
			{
				base.FastCheckIsValid();
				TArray<BvbCardItemData> result;
				if ((result = this._CardsOnHand) == null)
				{
					result = (this._CardsOnHand = new TArray<BvbCardItemData>(base.NativePtr + (IntPtr)BvbPlayerItemData.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.CardsOnHand.CopyAssign(value);
			}
		}

		// Token: 0x1700274C RID: 10060
		// (get) Token: 0x0601DB5B RID: 121691 RVA: 0x008DE244 File Offset: 0x008DC444
		// (set) Token: 0x0601DB5C RID: 121692 RVA: 0x008DE287 File Offset: 0x008DC487
		public TArray<BvbCardItemData> CardsInLibrary
		{
			get
			{
				base.FastCheckIsValid();
				TArray<BvbCardItemData> result;
				if ((result = this._CardsInLibrary) == null)
				{
					result = (this._CardsInLibrary = new TArray<BvbCardItemData>(base.NativePtr + (IntPtr)BvbPlayerItemData.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.CardsInLibrary.CopyAssign(value);
			}
		}

		// Token: 0x0601DB5D RID: 121693 RVA: 0x008DE295 File Offset: 0x008DC495
		public BvbPlayerItemData()
		{
		}

		// Token: 0x0601DB5E RID: 121694 RVA: 0x008DE29D File Offset: 0x008DC49D
		public BvbPlayerItemData(TArray<BvbCardItemData> CardsOnField, TArray<BvbCardItemData> CardsOnHand, TArray<BvbCardItemData> CardsInLibrary)
		{
			this.CardsOnField = CardsOnField;
			this.CardsOnHand = CardsOnHand;
			this.CardsInLibrary = CardsInLibrary;
		}

		// Token: 0x0601DB5F RID: 121695 RVA: 0x008DE2BA File Offset: 0x008DC4BA
		protected override IntPtr GetUStructPtr()
		{
			return BvbPlayerItemData.StaticStruct();
		}

		// Token: 0x0601DB60 RID: 121696 RVA: 0x008DE2C6 File Offset: 0x008DC4C6
		[NullableContext(2)]
		public BvbPlayerItemData(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DB61 RID: 121697 RVA: 0x008DE2D0 File Offset: 0x008DC4D0
		public BvbPlayerItemData(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DB62 RID: 121698 RVA: 0x008DE2DB File Offset: 0x008DC4DB
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new BvbPlayerItemData(Pointer, false, true);
		}

		// Token: 0x0601DB63 RID: 121699 RVA: 0x008DE2E5 File Offset: 0x008DC4E5
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new BvbPlayerItemData(Pointer, MemoryOwner);
		}

		// Token: 0x0400E8DA RID: 59610
		public const string __ObjectPath = "/Game/Aki/UI/Module/ActiveDebug/BvbPlayerItemData.BvbPlayerItemData";

		// Token: 0x0400E8DB RID: 59611
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400E8DC RID: 59612
		internal static int __PropertyOffset_0;

		// Token: 0x0400E8DD RID: 59613
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BvbCardItemData> _CardsOnField;

		// Token: 0x0400E8DE RID: 59614
		internal static int __PropertyOffset_1;

		// Token: 0x0400E8DF RID: 59615
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BvbCardItemData> _CardsOnHand;

		// Token: 0x0400E8E0 RID: 59616
		internal static int __PropertyOffset_2;

		// Token: 0x0400E8E1 RID: 59617
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BvbCardItemData> _CardsInLibrary;
	}
}
