using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialContainer
{
	// Token: 0x02003D8C RID: 15756
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/MaterialContainer/SCharacterBodySpecifiedStruct.SCharacterBodySpecifiedStruct")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class SCharacterBodySpecifiedStruct : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026744 RID: 157508 RVA: 0x009D83B8 File Offset: 0x009D65B8
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCharacterBodySpecifiedStruct._ScriptStructPtr != 0) ? SCharacterBodySpecifiedStruct._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Character/MaterialContainer/SCharacterBodySpecifiedStruct.SCharacterBodySpecifiedStruct", ref SCharacterBodySpecifiedStruct._ScriptStructPtr);
		}

		// Token: 0x17005770 RID: 22384
		// (get) Token: 0x06026745 RID: 157509 RVA: 0x009D83DC File Offset: 0x009D65DC
		// (set) Token: 0x06026746 RID: 157510 RVA: 0x009D83F0 File Offset: 0x009D65F0
		public unsafe TEnumAsByte<ECharacterBodySpecifiedType> SpecifiedType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterBodySpecifiedStruct.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterBodySpecifiedStruct.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005771 RID: 22385
		// (get) Token: 0x06026747 RID: 157511 RVA: 0x009D8408 File Offset: 0x009D6608
		// (set) Token: 0x06026748 RID: 157512 RVA: 0x009D844B File Offset: 0x009D664B
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<ECharacterBodyType>> BodyTypes
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<ECharacterBodyType>> result;
				if ((result = this._BodyTypes) == null)
				{
					result = (this._BodyTypes = new TArray<TEnumAsByte<ECharacterBodyType>>(base.NativePtr + (IntPtr)SCharacterBodySpecifiedStruct.__PropertyOffset_1, base.MemoryOwner ?? this));
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
				this.BodyTypes.CopyAssign(value);
			}
		}

		// Token: 0x06026749 RID: 157513 RVA: 0x009D8459 File Offset: 0x009D6659
		public SCharacterBodySpecifiedStruct()
		{
		}

		// Token: 0x0602674A RID: 157514 RVA: 0x009D8461 File Offset: 0x009D6661
		public SCharacterBodySpecifiedStruct(TEnumAsByte<ECharacterBodySpecifiedType> SpecifiedType, [Nullable(new byte[]
		{
			1,
			0
		})] TArray<TEnumAsByte<ECharacterBodyType>> BodyTypes)
		{
			this.SpecifiedType = SpecifiedType;
			this.BodyTypes = BodyTypes;
		}

		// Token: 0x0602674B RID: 157515 RVA: 0x009D8477 File Offset: 0x009D6677
		protected override IntPtr GetUStructPtr()
		{
			return SCharacterBodySpecifiedStruct.StaticStruct();
		}

		// Token: 0x0602674C RID: 157516 RVA: 0x009D8483 File Offset: 0x009D6683
		[NullableContext(2)]
		public SCharacterBodySpecifiedStruct(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602674D RID: 157517 RVA: 0x009D848D File Offset: 0x009D668D
		public SCharacterBodySpecifiedStruct(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602674E RID: 157518 RVA: 0x009D8498 File Offset: 0x009D6698
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCharacterBodySpecifiedStruct(Pointer, false, true);
		}

		// Token: 0x0602674F RID: 157519 RVA: 0x009D84A2 File Offset: 0x009D66A2
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCharacterBodySpecifiedStruct(Pointer, MemoryOwner);
		}

		// Token: 0x04013FAB RID: 81835
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/MaterialContainer/SCharacterBodySpecifiedStruct.SCharacterBodySpecifiedStruct";

		// Token: 0x04013FAC RID: 81836
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04013FAD RID: 81837
		internal static int __PropertyOffset_0;

		// Token: 0x04013FAE RID: 81838
		internal static int __PropertyOffset_1;

		// Token: 0x04013FAF RID: 81839
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<ECharacterBodyType>> _BodyTypes;
	}
}
