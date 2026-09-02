using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialContainer
{
	// Token: 0x02003D8B RID: 15755
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/MaterialContainer/PD_CharacterMaterialContainerData.PD_CharacterMaterialContainerData_C")]
	[UnrealStructLayout(304, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 304)]
	public class PD_CharacterMaterialContainerData_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026734 RID: 157492 RVA: 0x009D817E File Offset: 0x009D637E
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_CharacterMaterialContainerData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Character/MaterialContainer/PD_CharacterMaterialContainerData.PD_CharacterMaterialContainerData_C");
			}
			return PD_CharacterMaterialContainerData_C._ClassPtr;
		}

		// Token: 0x06026735 RID: 157493 RVA: 0x009D81A4 File Offset: 0x009D63A4
		public PD_CharacterMaterialContainerData_C() : this(BuiltinUtils.AllocNativeUObject(PD_CharacterMaterialContainerData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026736 RID: 157494 RVA: 0x009D81CC File Offset: 0x009D63CC
		public PD_CharacterMaterialContainerData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_CharacterMaterialContainerData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700576A RID: 22378
		// (get) Token: 0x06026737 RID: 157495 RVA: 0x009D8200 File Offset: 0x009D6400
		// (set) Token: 0x06026738 RID: 157496 RVA: 0x009D8239 File Offset: 0x009D6439
		public TArray<FName> BodyNames
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._BodyNames) == null)
				{
					result = (this._BodyNames = new TArray<FName>(base.NativePtr + (IntPtr)PD_CharacterMaterialContainerData_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.BodyNames.CopyAssign(value);
			}
		}

		// Token: 0x1700576B RID: 22379
		// (get) Token: 0x06026739 RID: 157497 RVA: 0x009D8248 File Offset: 0x009D6448
		// (set) Token: 0x0602673A RID: 157498 RVA: 0x009D8281 File Offset: 0x009D6481
		public TArray<FName> WeaponNames
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._WeaponNames) == null)
				{
					result = (this._WeaponNames = new TArray<FName>(base.NativePtr + (IntPtr)PD_CharacterMaterialContainerData_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.WeaponNames.CopyAssign(value);
			}
		}

		// Token: 0x1700576C RID: 22380
		// (get) Token: 0x0602673B RID: 157499 RVA: 0x009D8290 File Offset: 0x009D6490
		// (set) Token: 0x0602673C RID: 157500 RVA: 0x009D82C9 File Offset: 0x009D64C9
		public TArray<FName> HuluNames
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._HuluNames) == null)
				{
					result = (this._HuluNames = new TArray<FName>(base.NativePtr + (IntPtr)PD_CharacterMaterialContainerData_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.HuluNames.CopyAssign(value);
			}
		}

		// Token: 0x1700576D RID: 22381
		// (get) Token: 0x0602673D RID: 157501 RVA: 0x009D82D8 File Offset: 0x009D64D8
		// (set) Token: 0x0602673E RID: 157502 RVA: 0x009D8311 File Offset: 0x009D6511
		public TArray<FName> OtherNames
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._OtherNames) == null)
				{
					result = (this._OtherNames = new TArray<FName>(base.NativePtr + (IntPtr)PD_CharacterMaterialContainerData_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.OtherNames.CopyAssign(value);
			}
		}

		// Token: 0x1700576E RID: 22382
		// (get) Token: 0x0602673F RID: 157503 RVA: 0x009D8320 File Offset: 0x009D6520
		// (set) Token: 0x06026740 RID: 157504 RVA: 0x009D8359 File Offset: 0x009D6559
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<ECharacterBodySpecifiedType>, SCharacterBodySpecifiedStruct> BodySpecifiedTypes
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<ECharacterBodySpecifiedType>, SCharacterBodySpecifiedStruct> result;
				if ((result = this._BodySpecifiedTypes) == null)
				{
					result = (this._BodySpecifiedTypes = new TMap<TEnumAsByte<ECharacterBodySpecifiedType>, SCharacterBodySpecifiedStruct>(base.NativePtr + (IntPtr)PD_CharacterMaterialContainerData_C.__PropertyOffset_4, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.BodySpecifiedTypes.CopyAssign(value);
			}
		}

		// Token: 0x1700576F RID: 22383
		// (get) Token: 0x06026741 RID: 157505 RVA: 0x009D8368 File Offset: 0x009D6568
		// (set) Token: 0x06026742 RID: 157506 RVA: 0x009D83A1 File Offset: 0x009D65A1
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<ECharacterSlotSpecifiedType>, SCharacterSlotSpecifiedStruct> SlotSpecifiedTypes
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<ECharacterSlotSpecifiedType>, SCharacterSlotSpecifiedStruct> result;
				if ((result = this._SlotSpecifiedTypes) == null)
				{
					result = (this._SlotSpecifiedTypes = new TMap<TEnumAsByte<ECharacterSlotSpecifiedType>, SCharacterSlotSpecifiedStruct>(base.NativePtr + (IntPtr)PD_CharacterMaterialContainerData_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.SlotSpecifiedTypes.CopyAssign(value);
			}
		}

		// Token: 0x06026743 RID: 157507 RVA: 0x009D83AF File Offset: 0x009D65AF
		protected PD_CharacterMaterialContainerData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013F9C RID: 81820
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/MaterialContainer/PD_CharacterMaterialContainerData.PD_CharacterMaterialContainerData_C";

		// Token: 0x04013F9D RID: 81821
		private static IntPtr _ClassPtr;

		// Token: 0x04013F9E RID: 81822
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013F9F RID: 81823
		internal static int __PropertyOffset_0;

		// Token: 0x04013FA0 RID: 81824
		[Nullable(2)]
		private TArray<FName> _BodyNames;

		// Token: 0x04013FA1 RID: 81825
		internal static int __PropertyOffset_1;

		// Token: 0x04013FA2 RID: 81826
		[Nullable(2)]
		private TArray<FName> _WeaponNames;

		// Token: 0x04013FA3 RID: 81827
		internal static int __PropertyOffset_2;

		// Token: 0x04013FA4 RID: 81828
		[Nullable(2)]
		private TArray<FName> _HuluNames;

		// Token: 0x04013FA5 RID: 81829
		internal static int __PropertyOffset_3;

		// Token: 0x04013FA6 RID: 81830
		[Nullable(2)]
		private TArray<FName> _OtherNames;

		// Token: 0x04013FA7 RID: 81831
		internal static int __PropertyOffset_4;

		// Token: 0x04013FA8 RID: 81832
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<ECharacterBodySpecifiedType>, SCharacterBodySpecifiedStruct> _BodySpecifiedTypes;

		// Token: 0x04013FA9 RID: 81833
		internal static int __PropertyOffset_5;

		// Token: 0x04013FAA RID: 81834
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<ECharacterSlotSpecifiedType>, SCharacterSlotSpecifiedStruct> _SlotSpecifiedTypes;
	}
}
