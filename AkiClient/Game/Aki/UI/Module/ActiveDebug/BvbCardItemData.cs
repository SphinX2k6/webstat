using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.UI.Module.ActiveDebug
{
	// Token: 0x02003987 RID: 14727
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/UI/Module/ActiveDebug/BvbCardItemData.BvbCardItemData")]
	[UnrealStructLayout(96, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 96)]
	public class BvbCardItemData : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0601DACC RID: 121548 RVA: 0x008DD090 File Offset: 0x008DB290
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (BvbCardItemData._ScriptStructPtr != 0) ? BvbCardItemData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/UI/Module/ActiveDebug/BvbCardItemData.BvbCardItemData", ref BvbCardItemData._ScriptStructPtr);
		}

		// Token: 0x17002720 RID: 10016
		// (get) Token: 0x0601DACD RID: 121549 RVA: 0x008DD0B4 File Offset: 0x008DB2B4
		// (set) Token: 0x0601DACE RID: 121550 RVA: 0x008DD0C8 File Offset: 0x008DB2C8
		public unsafe string CardName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BvbCardItemData.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BvbCardItemData.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17002721 RID: 10017
		// (get) Token: 0x0601DACF RID: 121551 RVA: 0x008DD0DD File Offset: 0x008DB2DD
		// (set) Token: 0x0601DAD0 RID: 121552 RVA: 0x008DD0F1 File Offset: 0x008DB2F1
		public unsafe string Cost
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BvbCardItemData.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BvbCardItemData.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x17002722 RID: 10018
		// (get) Token: 0x0601DAD1 RID: 121553 RVA: 0x008DD106 File Offset: 0x008DB306
		// (set) Token: 0x0601DAD2 RID: 121554 RVA: 0x008DD11A File Offset: 0x008DB31A
		public unsafe string Element
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BvbCardItemData.__PropertyOffset_2)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BvbCardItemData.__PropertyOffset_2)), value);
			}
		}

		// Token: 0x17002723 RID: 10019
		// (get) Token: 0x0601DAD3 RID: 121555 RVA: 0x008DD12F File Offset: 0x008DB32F
		// (set) Token: 0x0601DAD4 RID: 121556 RVA: 0x008DD143 File Offset: 0x008DB343
		public unsafe string Power
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BvbCardItemData.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BvbCardItemData.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x17002724 RID: 10020
		// (get) Token: 0x0601DAD5 RID: 121557 RVA: 0x008DD158 File Offset: 0x008DB358
		// (set) Token: 0x0601DAD6 RID: 121558 RVA: 0x008DD16C File Offset: 0x008DB36C
		public unsafe string CardDesc
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BvbCardItemData.__PropertyOffset_4)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BvbCardItemData.__PropertyOffset_4)), value);
			}
		}

		// Token: 0x17002725 RID: 10021
		// (get) Token: 0x0601DAD7 RID: 121559 RVA: 0x008DD184 File Offset: 0x008DB384
		// (set) Token: 0x0601DAD8 RID: 121560 RVA: 0x008DD1C7 File Offset: 0x008DB3C7
		public TArray<BvbEffectItemData> EffectList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<BvbEffectItemData> result;
				if ((result = this._EffectList) == null)
				{
					result = (this._EffectList = new TArray<BvbEffectItemData>(base.NativePtr + (IntPtr)BvbCardItemData.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.EffectList.CopyAssign(value);
			}
		}

		// Token: 0x0601DAD9 RID: 121561 RVA: 0x008DD1D5 File Offset: 0x008DB3D5
		public BvbCardItemData()
		{
		}

		// Token: 0x0601DADA RID: 121562 RVA: 0x008DD1DD File Offset: 0x008DB3DD
		public BvbCardItemData(string CardName, string Cost, string Element, string Power, string CardDesc, TArray<BvbEffectItemData> EffectList)
		{
			this.CardName = CardName;
			this.Cost = Cost;
			this.Element = Element;
			this.Power = Power;
			this.CardDesc = CardDesc;
			this.EffectList = EffectList;
		}

		// Token: 0x0601DADB RID: 121563 RVA: 0x008DD212 File Offset: 0x008DB412
		protected override IntPtr GetUStructPtr()
		{
			return BvbCardItemData.StaticStruct();
		}

		// Token: 0x0601DADC RID: 121564 RVA: 0x008DD21E File Offset: 0x008DB41E
		[NullableContext(2)]
		public BvbCardItemData(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DADD RID: 121565 RVA: 0x008DD228 File Offset: 0x008DB428
		public BvbCardItemData(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DADE RID: 121566 RVA: 0x008DD233 File Offset: 0x008DB433
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new BvbCardItemData(Pointer, false, true);
		}

		// Token: 0x0601DADF RID: 121567 RVA: 0x008DD23D File Offset: 0x008DB43D
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new BvbCardItemData(Pointer, MemoryOwner);
		}

		// Token: 0x0400E880 RID: 59520
		public const string __ObjectPath = "/Game/Aki/UI/Module/ActiveDebug/BvbCardItemData.BvbCardItemData";

		// Token: 0x0400E881 RID: 59521
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400E882 RID: 59522
		internal static int __PropertyOffset_0;

		// Token: 0x0400E883 RID: 59523
		internal static int __PropertyOffset_1;

		// Token: 0x0400E884 RID: 59524
		internal static int __PropertyOffset_2;

		// Token: 0x0400E885 RID: 59525
		internal static int __PropertyOffset_3;

		// Token: 0x0400E886 RID: 59526
		internal static int __PropertyOffset_4;

		// Token: 0x0400E887 RID: 59527
		internal static int __PropertyOffset_5;

		// Token: 0x0400E888 RID: 59528
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BvbEffectItemData> _EffectList;
	}
}
