using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialContainer
{
	// Token: 0x02003D8D RID: 15757
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/MaterialContainer/SCharacterSlotSpecifiedStruct.SCharacterSlotSpecifiedStruct")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class SCharacterSlotSpecifiedStruct : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026750 RID: 157520 RVA: 0x009D84AB File Offset: 0x009D66AB
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCharacterSlotSpecifiedStruct._ScriptStructPtr != 0) ? SCharacterSlotSpecifiedStruct._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Character/MaterialContainer/SCharacterSlotSpecifiedStruct.SCharacterSlotSpecifiedStruct", ref SCharacterSlotSpecifiedStruct._ScriptStructPtr);
		}

		// Token: 0x17005772 RID: 22386
		// (get) Token: 0x06026751 RID: 157521 RVA: 0x009D84CF File Offset: 0x009D66CF
		// (set) Token: 0x06026752 RID: 157522 RVA: 0x009D84E3 File Offset: 0x009D66E3
		public unsafe TEnumAsByte<ECharacterSlotSpecifiedType> SlotSpecifiedType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterSlotSpecifiedStruct.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterSlotSpecifiedStruct.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005773 RID: 22387
		// (get) Token: 0x06026753 RID: 157523 RVA: 0x009D84F8 File Offset: 0x009D66F8
		// (set) Token: 0x06026754 RID: 157524 RVA: 0x009D853B File Offset: 0x009D673B
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<ECharacterSlotType>> SlotTypes
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<ECharacterSlotType>> result;
				if ((result = this._SlotTypes) == null)
				{
					result = (this._SlotTypes = new TArray<TEnumAsByte<ECharacterSlotType>>(base.NativePtr + (IntPtr)SCharacterSlotSpecifiedStruct.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.SlotTypes.CopyAssign(value);
			}
		}

		// Token: 0x06026755 RID: 157525 RVA: 0x009D8549 File Offset: 0x009D6749
		public SCharacterSlotSpecifiedStruct()
		{
		}

		// Token: 0x06026756 RID: 157526 RVA: 0x009D8551 File Offset: 0x009D6751
		public SCharacterSlotSpecifiedStruct(TEnumAsByte<ECharacterSlotSpecifiedType> SlotSpecifiedType, [Nullable(new byte[]
		{
			1,
			0
		})] TArray<TEnumAsByte<ECharacterSlotType>> SlotTypes)
		{
			this.SlotSpecifiedType = SlotSpecifiedType;
			this.SlotTypes = SlotTypes;
		}

		// Token: 0x06026757 RID: 157527 RVA: 0x009D8567 File Offset: 0x009D6767
		protected override IntPtr GetUStructPtr()
		{
			return SCharacterSlotSpecifiedStruct.StaticStruct();
		}

		// Token: 0x06026758 RID: 157528 RVA: 0x009D8573 File Offset: 0x009D6773
		[NullableContext(2)]
		public SCharacterSlotSpecifiedStruct(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026759 RID: 157529 RVA: 0x009D857D File Offset: 0x009D677D
		public SCharacterSlotSpecifiedStruct(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602675A RID: 157530 RVA: 0x009D8588 File Offset: 0x009D6788
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCharacterSlotSpecifiedStruct(Pointer, false, true);
		}

		// Token: 0x0602675B RID: 157531 RVA: 0x009D8592 File Offset: 0x009D6792
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCharacterSlotSpecifiedStruct(Pointer, MemoryOwner);
		}

		// Token: 0x04013FB0 RID: 81840
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/MaterialContainer/SCharacterSlotSpecifiedStruct.SCharacterSlotSpecifiedStruct";

		// Token: 0x04013FB1 RID: 81841
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04013FB2 RID: 81842
		internal static int __PropertyOffset_0;

		// Token: 0x04013FB3 RID: 81843
		internal static int __PropertyOffset_1;

		// Token: 0x04013FB4 RID: 81844
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<ECharacterSlotType>> _SlotTypes;
	}
}
