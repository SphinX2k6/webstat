using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.UI.Module.ActiveDebug
{
	// Token: 0x0200398B RID: 14731
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/UI/Module/ActiveDebug/BvbEffectItemData.BvbEffectItemData")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 64)]
	public class BvbEffectItemData : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0601DB2E RID: 121646 RVA: 0x008DDC64 File Offset: 0x008DBE64
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (BvbEffectItemData._ScriptStructPtr != 0) ? BvbEffectItemData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/UI/Module/ActiveDebug/BvbEffectItemData.BvbEffectItemData", ref BvbEffectItemData._ScriptStructPtr);
		}

		// Token: 0x1700273F RID: 10047
		// (get) Token: 0x0601DB2F RID: 121647 RVA: 0x008DDC88 File Offset: 0x008DBE88
		// (set) Token: 0x0601DB30 RID: 121648 RVA: 0x008DDC9C File Offset: 0x008DBE9C
		public unsafe string Title
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BvbEffectItemData.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BvbEffectItemData.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17002740 RID: 10048
		// (get) Token: 0x0601DB31 RID: 121649 RVA: 0x008DDCB1 File Offset: 0x008DBEB1
		// (set) Token: 0x0601DB32 RID: 121650 RVA: 0x008DDCC5 File Offset: 0x008DBEC5
		public unsafe string Desc
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BvbEffectItemData.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BvbEffectItemData.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x17002741 RID: 10049
		// (get) Token: 0x0601DB33 RID: 121651 RVA: 0x008DDCDC File Offset: 0x008DBEDC
		// (set) Token: 0x0601DB34 RID: 121652 RVA: 0x008DDD1F File Offset: 0x008DBF1F
		public TArray<string> ChildTitleList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._ChildTitleList) == null)
				{
					result = (this._ChildTitleList = new TArray<string>(base.NativePtr + (IntPtr)BvbEffectItemData.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ChildTitleList.CopyAssign(value);
			}
		}

		// Token: 0x17002742 RID: 10050
		// (get) Token: 0x0601DB35 RID: 121653 RVA: 0x008DDD30 File Offset: 0x008DBF30
		// (set) Token: 0x0601DB36 RID: 121654 RVA: 0x008DDD73 File Offset: 0x008DBF73
		public TArray<string> ChildDescList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._ChildDescList) == null)
				{
					result = (this._ChildDescList = new TArray<string>(base.NativePtr + (IntPtr)BvbEffectItemData.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ChildDescList.CopyAssign(value);
			}
		}

		// Token: 0x0601DB37 RID: 121655 RVA: 0x008DDD81 File Offset: 0x008DBF81
		public BvbEffectItemData()
		{
		}

		// Token: 0x0601DB38 RID: 121656 RVA: 0x008DDD89 File Offset: 0x008DBF89
		public BvbEffectItemData(string Title, string Desc, TArray<string> ChildTitleList, TArray<string> ChildDescList)
		{
			this.Title = Title;
			this.Desc = Desc;
			this.ChildTitleList = ChildTitleList;
			this.ChildDescList = ChildDescList;
		}

		// Token: 0x0601DB39 RID: 121657 RVA: 0x008DDDAE File Offset: 0x008DBFAE
		protected override IntPtr GetUStructPtr()
		{
			return BvbEffectItemData.StaticStruct();
		}

		// Token: 0x0601DB3A RID: 121658 RVA: 0x008DDDBA File Offset: 0x008DBFBA
		[NullableContext(2)]
		public BvbEffectItemData(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DB3B RID: 121659 RVA: 0x008DDDC4 File Offset: 0x008DBFC4
		public BvbEffectItemData(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DB3C RID: 121660 RVA: 0x008DDDCF File Offset: 0x008DBFCF
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new BvbEffectItemData(Pointer, false, true);
		}

		// Token: 0x0601DB3D RID: 121661 RVA: 0x008DDDD9 File Offset: 0x008DBFD9
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new BvbEffectItemData(Pointer, MemoryOwner);
		}

		// Token: 0x0400E8C0 RID: 59584
		public const string __ObjectPath = "/Game/Aki/UI/Module/ActiveDebug/BvbEffectItemData.BvbEffectItemData";

		// Token: 0x0400E8C1 RID: 59585
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400E8C2 RID: 59586
		internal static int __PropertyOffset_0;

		// Token: 0x0400E8C3 RID: 59587
		internal static int __PropertyOffset_1;

		// Token: 0x0400E8C4 RID: 59588
		internal static int __PropertyOffset_2;

		// Token: 0x0400E8C5 RID: 59589
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _ChildTitleList;

		// Token: 0x0400E8C6 RID: 59590
		internal static int __PropertyOffset_3;

		// Token: 0x0400E8C7 RID: 59591
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _ChildDescList;
	}
}
