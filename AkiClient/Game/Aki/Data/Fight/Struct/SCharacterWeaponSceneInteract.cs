using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.Struct
{
	// Token: 0x02003ECB RID: 16075
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/Struct/SCharacterWeaponSceneInteract.SCharacterWeaponSceneInteract")]
	[UnrealStructLayout(240, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 240)]
	public class SCharacterWeaponSceneInteract : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027F1F RID: 163615 RVA: 0x009FEB4C File Offset: 0x009FCD4C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCharacterWeaponSceneInteract._ScriptStructPtr != 0) ? SCharacterWeaponSceneInteract._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/Struct/SCharacterWeaponSceneInteract.SCharacterWeaponSceneInteract", ref SCharacterWeaponSceneInteract._ScriptStructPtr);
		}

		// Token: 0x17005FA7 RID: 24487
		// (get) Token: 0x06027F20 RID: 163616 RVA: 0x009FEB70 File Offset: 0x009FCD70
		// (set) Token: 0x06027F21 RID: 163617 RVA: 0x009FEB8F File Offset: 0x009FCD8F
		public TSoftClassPtr<AActor> RoleBp
		{
			get
			{
				return new TSoftClassPtr<AActor>(base.NativePtr + (IntPtr)SCharacterWeaponSceneInteract.__PropertyOffset_0, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCharacterWeaponSceneInteract.__PropertyOffset_0, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005FA8 RID: 24488
		// (get) Token: 0x06027F22 RID: 163618 RVA: 0x009FEBB4 File Offset: 0x009FCDB4
		// (set) Token: 0x06027F23 RID: 163619 RVA: 0x009FEBF7 File Offset: 0x009FCDF7
		public TArray<TSoftObjectPtr<UObject>> ObjectArray
		{
			get
			{
				base.FastCheckIsValid();
				TArray<TSoftObjectPtr<UObject>> result;
				if ((result = this._ObjectArray) == null)
				{
					result = (this._ObjectArray = new TArray<TSoftObjectPtr<UObject>>(base.NativePtr + (IntPtr)SCharacterWeaponSceneInteract.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ObjectArray.CopyAssign(value);
			}
		}

		// Token: 0x17005FA9 RID: 24489
		// (get) Token: 0x06027F24 RID: 163620 RVA: 0x009FEC08 File Offset: 0x009FCE08
		// (set) Token: 0x06027F25 RID: 163621 RVA: 0x009FEC4B File Offset: 0x009FCE4B
		public TArray<TSoftObjectPtr<BP_SceneBattleInteract_C>> DaArray
		{
			get
			{
				base.FastCheckIsValid();
				TArray<TSoftObjectPtr<BP_SceneBattleInteract_C>> result;
				if ((result = this._DaArray) == null)
				{
					result = (this._DaArray = new TArray<TSoftObjectPtr<BP_SceneBattleInteract_C>>(base.NativePtr + (IntPtr)SCharacterWeaponSceneInteract.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.DaArray.CopyAssign(value);
			}
		}

		// Token: 0x17005FAA RID: 24490
		// (get) Token: 0x06027F26 RID: 163622 RVA: 0x009FEC5C File Offset: 0x009FCE5C
		// (set) Token: 0x06027F27 RID: 163623 RVA: 0x009FEC9F File Offset: 0x009FCE9F
		public TMap<string, int> OtherCaseMap
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, int> result;
				if ((result = this._OtherCaseMap) == null)
				{
					result = (this._OtherCaseMap = new TMap<string, int>(base.NativePtr + (IntPtr)SCharacterWeaponSceneInteract.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.OtherCaseMap.CopyAssign(value);
			}
		}

		// Token: 0x17005FAB RID: 24491
		// (get) Token: 0x06027F28 RID: 163624 RVA: 0x009FECB0 File Offset: 0x009FCEB0
		// (set) Token: 0x06027F29 RID: 163625 RVA: 0x009FECF3 File Offset: 0x009FCEF3
		public TMap<string, FName> OtherCaseParentMap
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, FName> result;
				if ((result = this._OtherCaseParentMap) == null)
				{
					result = (this._OtherCaseParentMap = new TMap<string, FName>(base.NativePtr + (IntPtr)SCharacterWeaponSceneInteract.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.OtherCaseParentMap.CopyAssign(value);
			}
		}

		// Token: 0x06027F2A RID: 163626 RVA: 0x009FED01 File Offset: 0x009FCF01
		public SCharacterWeaponSceneInteract()
		{
		}

		// Token: 0x06027F2B RID: 163627 RVA: 0x009FED09 File Offset: 0x009FCF09
		public SCharacterWeaponSceneInteract(TSoftClassPtr<AActor> RoleBp, TArray<TSoftObjectPtr<UObject>> ObjectArray, TArray<TSoftObjectPtr<BP_SceneBattleInteract_C>> DaArray, TMap<string, int> OtherCaseMap, TMap<string, FName> OtherCaseParentMap)
		{
			this.RoleBp = RoleBp;
			this.ObjectArray = ObjectArray;
			this.DaArray = DaArray;
			this.OtherCaseMap = OtherCaseMap;
			this.OtherCaseParentMap = OtherCaseParentMap;
		}

		// Token: 0x06027F2C RID: 163628 RVA: 0x009FED36 File Offset: 0x009FCF36
		protected override IntPtr GetUStructPtr()
		{
			return SCharacterWeaponSceneInteract.StaticStruct();
		}

		// Token: 0x06027F2D RID: 163629 RVA: 0x009FED42 File Offset: 0x009FCF42
		[NullableContext(2)]
		public SCharacterWeaponSceneInteract(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027F2E RID: 163630 RVA: 0x009FED4C File Offset: 0x009FCF4C
		public SCharacterWeaponSceneInteract(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027F2F RID: 163631 RVA: 0x009FED57 File Offset: 0x009FCF57
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCharacterWeaponSceneInteract(Pointer, false, true);
		}

		// Token: 0x06027F30 RID: 163632 RVA: 0x009FED61 File Offset: 0x009FCF61
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCharacterWeaponSceneInteract(Pointer, MemoryOwner);
		}

		// Token: 0x04014F8D RID: 85901
		public const string __ObjectPath = "/Game/Aki/Data/Fight/Struct/SCharacterWeaponSceneInteract.SCharacterWeaponSceneInteract";

		// Token: 0x04014F8E RID: 85902
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014F8F RID: 85903
		internal static int __PropertyOffset_0;

		// Token: 0x04014F90 RID: 85904
		internal static int __PropertyOffset_1;

		// Token: 0x04014F91 RID: 85905
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TArray<TSoftObjectPtr<UObject>> _ObjectArray;

		// Token: 0x04014F92 RID: 85906
		internal static int __PropertyOffset_2;

		// Token: 0x04014F93 RID: 85907
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TArray<TSoftObjectPtr<BP_SceneBattleInteract_C>> _DaArray;

		// Token: 0x04014F94 RID: 85908
		internal static int __PropertyOffset_3;

		// Token: 0x04014F95 RID: 85909
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<string, int> _OtherCaseMap;

		// Token: 0x04014F96 RID: 85910
		internal static int __PropertyOffset_4;

		// Token: 0x04014F97 RID: 85911
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<string, FName> _OtherCaseParentMap;
	}
}
