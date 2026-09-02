using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.Struct
{
	// Token: 0x02003EC9 RID: 16073
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/Struct/SCharacterFightInfo.SCharacterFightInfo")]
	[UnrealStructLayout(736, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 736)]
	public class SCharacterFightInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027EE5 RID: 163557 RVA: 0x009FE3A0 File Offset: 0x009FC5A0
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCharacterFightInfo._ScriptStructPtr != 0) ? SCharacterFightInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/Struct/SCharacterFightInfo.SCharacterFightInfo", ref SCharacterFightInfo._ScriptStructPtr);
		}

		// Token: 0x17005F92 RID: 24466
		// (get) Token: 0x06027EE6 RID: 163558 RVA: 0x009FE3C4 File Offset: 0x009FC5C4
		// (set) Token: 0x06027EE7 RID: 163559 RVA: 0x009FE3E3 File Offset: 0x009FC5E3
		public TSoftObjectPtr<UDataTable> SkillDataTable
		{
			get
			{
				return new TSoftObjectPtr<UDataTable>(base.NativePtr + (IntPtr)SCharacterFightInfo.__PropertyOffset_0, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCharacterFightInfo.__PropertyOffset_0, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005F93 RID: 24467
		// (get) Token: 0x06027EE8 RID: 163560 RVA: 0x009FE408 File Offset: 0x009FC608
		// (set) Token: 0x06027EE9 RID: 163561 RVA: 0x009FE427 File Offset: 0x009FC627
		public TSoftObjectPtr<UDataTable> BulletDataTable
		{
			get
			{
				return new TSoftObjectPtr<UDataTable>(base.NativePtr + (IntPtr)SCharacterFightInfo.__PropertyOffset_1, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCharacterFightInfo.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005F94 RID: 24468
		// (get) Token: 0x06027EEA RID: 163562 RVA: 0x009FE44C File Offset: 0x009FC64C
		// (set) Token: 0x06027EEB RID: 163563 RVA: 0x009FE46B File Offset: 0x009FC66B
		public TSoftObjectPtr<UPrimaryDataAsset> PartHitEffect
		{
			get
			{
				return new TSoftObjectPtr<UPrimaryDataAsset>(base.NativePtr + (IntPtr)SCharacterFightInfo.__PropertyOffset_2, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCharacterFightInfo.__PropertyOffset_2, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005F95 RID: 24469
		// (get) Token: 0x06027EEC RID: 163564 RVA: 0x009FE490 File Offset: 0x009FC690
		// (set) Token: 0x06027EED RID: 163565 RVA: 0x009FE4AF File Offset: 0x009FC6AF
		public TSoftObjectPtr<UDataTable> HitEffectTable
		{
			get
			{
				return new TSoftObjectPtr<UDataTable>(base.NativePtr + (IntPtr)SCharacterFightInfo.__PropertyOffset_3, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCharacterFightInfo.__PropertyOffset_3, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005F96 RID: 24470
		// (get) Token: 0x06027EEE RID: 163566 RVA: 0x009FE4D4 File Offset: 0x009FC6D4
		// (set) Token: 0x06027EEF RID: 163567 RVA: 0x009FE517 File Offset: 0x009FC717
		[Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})]
		public TMap<TEnumAsByte<ECharacterLoadType>, TSoftObjectPtr<UDataTable>> SkillDataTableMap
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<ECharacterLoadType>, TSoftObjectPtr<UDataTable>> result;
				if ((result = this._SkillDataTableMap) == null)
				{
					result = (this._SkillDataTableMap = new TMap<TEnumAsByte<ECharacterLoadType>, TSoftObjectPtr<UDataTable>>(base.NativePtr + (IntPtr)SCharacterFightInfo.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1,
				1
			})]
			set
			{
				this.SkillDataTableMap.CopyAssign(value);
			}
		}

		// Token: 0x17005F97 RID: 24471
		// (get) Token: 0x06027EF0 RID: 163568 RVA: 0x009FE528 File Offset: 0x009FC728
		// (set) Token: 0x06027EF1 RID: 163569 RVA: 0x009FE56B File Offset: 0x009FC76B
		[Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})]
		public TMap<TEnumAsByte<ECharacterLoadType>, TSoftObjectPtr<UDataTable>> BulletDataTableMap
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<ECharacterLoadType>, TSoftObjectPtr<UDataTable>> result;
				if ((result = this._BulletDataTableMap) == null)
				{
					result = (this._BulletDataTableMap = new TMap<TEnumAsByte<ECharacterLoadType>, TSoftObjectPtr<UDataTable>>(base.NativePtr + (IntPtr)SCharacterFightInfo.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1,
				1
			})]
			set
			{
				this.BulletDataTableMap.CopyAssign(value);
			}
		}

		// Token: 0x17005F98 RID: 24472
		// (get) Token: 0x06027EF2 RID: 163570 RVA: 0x009FE57C File Offset: 0x009FC77C
		// (set) Token: 0x06027EF3 RID: 163571 RVA: 0x009FE5BF File Offset: 0x009FC7BF
		[Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})]
		public TMap<TEnumAsByte<ECharacterLoadType>, TSoftObjectPtr<UDataTable>> HitEffectTableMap
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<ECharacterLoadType>, TSoftObjectPtr<UDataTable>> result;
				if ((result = this._HitEffectTableMap) == null)
				{
					result = (this._HitEffectTableMap = new TMap<TEnumAsByte<ECharacterLoadType>, TSoftObjectPtr<UDataTable>>(base.NativePtr + (IntPtr)SCharacterFightInfo.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1,
				1
			})]
			set
			{
				this.HitEffectTableMap.CopyAssign(value);
			}
		}

		// Token: 0x17005F99 RID: 24473
		// (get) Token: 0x06027EF4 RID: 163572 RVA: 0x009FE5D0 File Offset: 0x009FC7D0
		// (set) Token: 0x06027EF5 RID: 163573 RVA: 0x009FE613 File Offset: 0x009FC813
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<ECharacterLoadType>, FSoftClassPath> BpInputMap
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
				TMap<TEnumAsByte<ECharacterLoadType>, FSoftClassPath> result;
				if ((result = this._BpInputMap) == null)
				{
					result = (this._BpInputMap = new TMap<TEnumAsByte<ECharacterLoadType>, FSoftClassPath>(base.NativePtr + (IntPtr)SCharacterFightInfo.__PropertyOffset_7, base.MemoryOwner ?? this));
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
				this.BpInputMap.CopyAssign(value);
			}
		}

		// Token: 0x17005F9A RID: 24474
		// (get) Token: 0x06027EF6 RID: 163574 RVA: 0x009FE621 File Offset: 0x009FC821
		// (set) Token: 0x06027EF7 RID: 163575 RVA: 0x009FE640 File Offset: 0x009FC840
		public TSoftClassPtr<TsBaseCharacter> LinkCharacter
		{
			get
			{
				return new TSoftClassPtr<TsBaseCharacter>(base.NativePtr + (IntPtr)SCharacterFightInfo.__PropertyOffset_8, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCharacterFightInfo.__PropertyOffset_8, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005F9B RID: 24475
		// (get) Token: 0x06027EF8 RID: 163576 RVA: 0x009FE665 File Offset: 0x009FC865
		// (set) Token: 0x06027EF9 RID: 163577 RVA: 0x009FE684 File Offset: 0x009FC884
		public TSoftObjectPtr<UDataTable> CustomParamTable
		{
			get
			{
				return new TSoftObjectPtr<UDataTable>(base.NativePtr + (IntPtr)SCharacterFightInfo.__PropertyOffset_9, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCharacterFightInfo.__PropertyOffset_9, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005F9C RID: 24476
		// (get) Token: 0x06027EFA RID: 163578 RVA: 0x009FE6AC File Offset: 0x009FC8AC
		// (set) Token: 0x06027EFB RID: 163579 RVA: 0x009FE6EF File Offset: 0x009FC8EF
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<EMorphType>, SCharacterMorphInfo> MorphModelInfoMap
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
				TMap<TEnumAsByte<EMorphType>, SCharacterMorphInfo> result;
				if ((result = this._MorphModelInfoMap) == null)
				{
					result = (this._MorphModelInfoMap = new TMap<TEnumAsByte<EMorphType>, SCharacterMorphInfo>(base.NativePtr + (IntPtr)SCharacterFightInfo.__PropertyOffset_10, base.MemoryOwner ?? this));
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
				this.MorphModelInfoMap.CopyAssign(value);
			}
		}

		// Token: 0x17005F9D RID: 24477
		// (get) Token: 0x06027EFC RID: 163580 RVA: 0x009FE6FD File Offset: 0x009FC8FD
		// (set) Token: 0x06027EFD RID: 163581 RVA: 0x009FE71C File Offset: 0x009FC91C
		public TSoftObjectPtr<UDataTable> KuroBulletDataTable
		{
			get
			{
				return new TSoftObjectPtr<UDataTable>(base.NativePtr + (IntPtr)SCharacterFightInfo.__PropertyOffset_11, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCharacterFightInfo.__PropertyOffset_11, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x06027EFE RID: 163582 RVA: 0x009FE741 File Offset: 0x009FC941
		public SCharacterFightInfo()
		{
		}

		// Token: 0x06027EFF RID: 163583 RVA: 0x009FE74C File Offset: 0x009FC94C
		public SCharacterFightInfo(TSoftObjectPtr<UDataTable> SkillDataTable, TSoftObjectPtr<UDataTable> BulletDataTable, TSoftObjectPtr<UPrimaryDataAsset> PartHitEffect, TSoftObjectPtr<UDataTable> HitEffectTable, [Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})] TMap<TEnumAsByte<ECharacterLoadType>, TSoftObjectPtr<UDataTable>> SkillDataTableMap, [Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})] TMap<TEnumAsByte<ECharacterLoadType>, TSoftObjectPtr<UDataTable>> BulletDataTableMap, [Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})] TMap<TEnumAsByte<ECharacterLoadType>, TSoftObjectPtr<UDataTable>> HitEffectTableMap, [Nullable(new byte[]
		{
			1,
			0,
			1
		})] TMap<TEnumAsByte<ECharacterLoadType>, FSoftClassPath> BpInputMap, TSoftClassPtr<TsBaseCharacter> LinkCharacter, TSoftObjectPtr<UDataTable> CustomParamTable, [Nullable(new byte[]
		{
			1,
			0,
			1
		})] TMap<TEnumAsByte<EMorphType>, SCharacterMorphInfo> MorphModelInfoMap, TSoftObjectPtr<UDataTable> KuroBulletDataTable)
		{
			this.SkillDataTable = SkillDataTable;
			this.BulletDataTable = BulletDataTable;
			this.PartHitEffect = PartHitEffect;
			this.HitEffectTable = HitEffectTable;
			this.SkillDataTableMap = SkillDataTableMap;
			this.BulletDataTableMap = BulletDataTableMap;
			this.HitEffectTableMap = HitEffectTableMap;
			this.BpInputMap = BpInputMap;
			this.LinkCharacter = LinkCharacter;
			this.CustomParamTable = CustomParamTable;
			this.MorphModelInfoMap = MorphModelInfoMap;
			this.KuroBulletDataTable = KuroBulletDataTable;
		}

		// Token: 0x06027F00 RID: 163584 RVA: 0x009FE7BC File Offset: 0x009FC9BC
		protected override IntPtr GetUStructPtr()
		{
			return SCharacterFightInfo.StaticStruct();
		}

		// Token: 0x06027F01 RID: 163585 RVA: 0x009FE7C8 File Offset: 0x009FC9C8
		[NullableContext(2)]
		public SCharacterFightInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027F02 RID: 163586 RVA: 0x009FE7D2 File Offset: 0x009FC9D2
		public SCharacterFightInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027F03 RID: 163587 RVA: 0x009FE7DD File Offset: 0x009FC9DD
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCharacterFightInfo(Pointer, false, true);
		}

		// Token: 0x06027F04 RID: 163588 RVA: 0x009FE7E7 File Offset: 0x009FC9E7
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCharacterFightInfo(Pointer, MemoryOwner);
		}

		// Token: 0x04014F6A RID: 85866
		public const string __ObjectPath = "/Game/Aki/Data/Fight/Struct/SCharacterFightInfo.SCharacterFightInfo";

		// Token: 0x04014F6B RID: 85867
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014F6C RID: 85868
		internal static int __PropertyOffset_0;

		// Token: 0x04014F6D RID: 85869
		internal static int __PropertyOffset_1;

		// Token: 0x04014F6E RID: 85870
		internal static int __PropertyOffset_2;

		// Token: 0x04014F6F RID: 85871
		internal static int __PropertyOffset_3;

		// Token: 0x04014F70 RID: 85872
		internal static int __PropertyOffset_4;

		// Token: 0x04014F71 RID: 85873
		[Nullable(new byte[]
		{
			2,
			0,
			1,
			1
		})]
		private TMap<TEnumAsByte<ECharacterLoadType>, TSoftObjectPtr<UDataTable>> _SkillDataTableMap;

		// Token: 0x04014F72 RID: 85874
		internal static int __PropertyOffset_5;

		// Token: 0x04014F73 RID: 85875
		[Nullable(new byte[]
		{
			2,
			0,
			1,
			1
		})]
		private TMap<TEnumAsByte<ECharacterLoadType>, TSoftObjectPtr<UDataTable>> _BulletDataTableMap;

		// Token: 0x04014F74 RID: 85876
		internal static int __PropertyOffset_6;

		// Token: 0x04014F75 RID: 85877
		[Nullable(new byte[]
		{
			2,
			0,
			1,
			1
		})]
		private TMap<TEnumAsByte<ECharacterLoadType>, TSoftObjectPtr<UDataTable>> _HitEffectTableMap;

		// Token: 0x04014F76 RID: 85878
		internal static int __PropertyOffset_7;

		// Token: 0x04014F77 RID: 85879
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<ECharacterLoadType>, FSoftClassPath> _BpInputMap;

		// Token: 0x04014F78 RID: 85880
		internal static int __PropertyOffset_8;

		// Token: 0x04014F79 RID: 85881
		internal static int __PropertyOffset_9;

		// Token: 0x04014F7A RID: 85882
		internal static int __PropertyOffset_10;

		// Token: 0x04014F7B RID: 85883
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EMorphType>, SCharacterMorphInfo> _MorphModelInfoMap;

		// Token: 0x04014F7C RID: 85884
		internal static int __PropertyOffset_11;
	}
}
