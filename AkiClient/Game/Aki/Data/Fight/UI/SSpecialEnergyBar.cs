using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.UI
{
	// Token: 0x02003EC0 RID: 16064
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/UI/SSpecialEnergyBar.SSpecialEnergyBar")]
	[UnrealStructLayout(424, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 424)]
	public class SSpecialEnergyBar : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027E49 RID: 163401 RVA: 0x009FD46A File Offset: 0x009FB66A
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSpecialEnergyBar._ScriptStructPtr != 0) ? SSpecialEnergyBar._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/UI/SSpecialEnergyBar.SSpecialEnergyBar", ref SSpecialEnergyBar._ScriptStructPtr);
		}

		// Token: 0x17005F63 RID: 24419
		// (get) Token: 0x06027E4A RID: 163402 RVA: 0x009FD48E File Offset: 0x009FB68E
		// (set) Token: 0x06027E4B RID: 163403 RVA: 0x009FD4A2 File Offset: 0x009FB6A2
		public unsafe string Name
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SSpecialEnergyBar.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SSpecialEnergyBar.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17005F64 RID: 24420
		// (get) Token: 0x06027E4C RID: 163404 RVA: 0x009FD4B7 File Offset: 0x009FB6B7
		// (set) Token: 0x06027E4D RID: 163405 RVA: 0x009FD4CB File Offset: 0x009FB6CB
		[Nullable(0)]
		public unsafe TEnumAsByte<ESpecialEnergyBarPrefabType> PrefabType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_1);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005F65 RID: 24421
		// (get) Token: 0x06027E4E RID: 163406 RVA: 0x009FD4E0 File Offset: 0x009FB6E0
		// (set) Token: 0x06027E4F RID: 163407 RVA: 0x009FD4F0 File Offset: 0x009FB6F0
		public unsafe int ExtraType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005F66 RID: 24422
		// (get) Token: 0x06027E50 RID: 163408 RVA: 0x009FD501 File Offset: 0x009FB701
		// (set) Token: 0x06027E51 RID: 163409 RVA: 0x009FD511 File Offset: 0x009FB711
		public unsafe int SlotNum
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005F67 RID: 24423
		// (get) Token: 0x06027E52 RID: 163410 RVA: 0x009FD524 File Offset: 0x009FB724
		// (set) Token: 0x06027E53 RID: 163411 RVA: 0x009FD567 File Offset: 0x009FB767
		public TArray<float> ExtraFloatParams
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._ExtraFloatParams) == null)
				{
					result = (this._ExtraFloatParams = new TArray<float>(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ExtraFloatParams.CopyAssign(value);
			}
		}

		// Token: 0x17005F68 RID: 24424
		// (get) Token: 0x06027E54 RID: 163412 RVA: 0x009FD575 File Offset: 0x009FB775
		// (set) Token: 0x06027E55 RID: 163413 RVA: 0x009FD594 File Offset: 0x009FB794
		public TSoftObjectPtr<UPrefabAsset> PrefabPath
		{
			get
			{
				return new TSoftObjectPtr<UPrefabAsset>(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_5, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_5, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005F69 RID: 24425
		// (get) Token: 0x06027E56 RID: 163414 RVA: 0x009FD5B9 File Offset: 0x009FB7B9
		// (set) Token: 0x06027E57 RID: 163415 RVA: 0x009FD5C9 File Offset: 0x009FB7C9
		public unsafe int AttributeId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005F6A RID: 24426
		// (get) Token: 0x06027E58 RID: 163416 RVA: 0x009FD5DA File Offset: 0x009FB7DA
		// (set) Token: 0x06027E59 RID: 163417 RVA: 0x009FD5EA File Offset: 0x009FB7EA
		public unsafe int MaxAttributeId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005F6B RID: 24427
		// (get) Token: 0x06027E5A RID: 163418 RVA: 0x009FD5FB File Offset: 0x009FB7FB
		// (set) Token: 0x06027E5B RID: 163419 RVA: 0x009FD60B File Offset: 0x009FB80B
		public unsafe long BuffId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005F6C RID: 24428
		// (get) Token: 0x06027E5C RID: 163420 RVA: 0x009FD61C File Offset: 0x009FB81C
		// (set) Token: 0x06027E5D RID: 163421 RVA: 0x009FD65F File Offset: 0x009FB85F
		public TMap<FGameplayTag, int> TagEnergyBarIdMap
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, int> result;
				if ((result = this._TagEnergyBarIdMap) == null)
				{
					result = (this._TagEnergyBarIdMap = new TMap<FGameplayTag, int>(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_9, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.TagEnergyBarIdMap.CopyAssign(value);
			}
		}

		// Token: 0x17005F6D RID: 24429
		// (get) Token: 0x06027E5E RID: 163422 RVA: 0x009FD66D File Offset: 0x009FB86D
		// (set) Token: 0x06027E5F RID: 163423 RVA: 0x009FD681 File Offset: 0x009FB881
		public unsafe string EffectColor
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SSpecialEnergyBar.__PropertyOffset_10)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SSpecialEnergyBar.__PropertyOffset_10)), value);
			}
		}

		// Token: 0x17005F6E RID: 24430
		// (get) Token: 0x06027E60 RID: 163424 RVA: 0x009FD696 File Offset: 0x009FB896
		// (set) Token: 0x06027E61 RID: 163425 RVA: 0x009FD6AA File Offset: 0x009FB8AA
		public unsafe string PointColor
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SSpecialEnergyBar.__PropertyOffset_11)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SSpecialEnergyBar.__PropertyOffset_11)), value);
			}
		}

		// Token: 0x17005F6F RID: 24431
		// (get) Token: 0x06027E62 RID: 163426 RVA: 0x009FD6BF File Offset: 0x009FB8BF
		// (set) Token: 0x06027E63 RID: 163427 RVA: 0x009FD6DE File Offset: 0x009FB8DE
		public TSoftObjectPtr<UTexture2D> TexturePath
		{
			get
			{
				return new TSoftObjectPtr<UTexture2D>(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_12, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_12, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005F70 RID: 24432
		// (get) Token: 0x06027E64 RID: 163428 RVA: 0x009FD703 File Offset: 0x009FB903
		// (set) Token: 0x06027E65 RID: 163429 RVA: 0x009FD722 File Offset: 0x009FB922
		public TSoftObjectPtr<UTexture2D> EnableTexturePath
		{
			get
			{
				return new TSoftObjectPtr<UTexture2D>(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_13, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_13, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005F71 RID: 24433
		// (get) Token: 0x06027E66 RID: 163430 RVA: 0x009FD747 File Offset: 0x009FB947
		// (set) Token: 0x06027E67 RID: 163431 RVA: 0x009FD766 File Offset: 0x009FB966
		public TSoftObjectPtr<UTexture2D> FrontTexturePath
		{
			get
			{
				return new TSoftObjectPtr<UTexture2D>(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_14, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_14, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005F72 RID: 24434
		// (get) Token: 0x06027E68 RID: 163432 RVA: 0x009FD78C File Offset: 0x009FB98C
		// (set) Token: 0x06027E69 RID: 163433 RVA: 0x009FD7CF File Offset: 0x009FB9CF
		public TArray<TSoftObjectPtr<UNiagaraSystem>> NiagaraList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<TSoftObjectPtr<UNiagaraSystem>> result;
				if ((result = this._NiagaraList) == null)
				{
					result = (this._NiagaraList = new TArray<TSoftObjectPtr<UNiagaraSystem>>(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_15, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.NiagaraList.CopyAssign(value);
			}
		}

		// Token: 0x17005F73 RID: 24435
		// (get) Token: 0x06027E6A RID: 163434 RVA: 0x009FD7DD File Offset: 0x009FB9DD
		// (set) Token: 0x06027E6B RID: 163435 RVA: 0x009FD7ED File Offset: 0x009FB9ED
		public unsafe int KeyEnableNiagaraIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17005F74 RID: 24436
		// (get) Token: 0x06027E6C RID: 163436 RVA: 0x009FD7FE File Offset: 0x009FB9FE
		// (set) Token: 0x06027E6D RID: 163437 RVA: 0x009FD80E File Offset: 0x009FBA0E
		public unsafe int KeyType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17005F75 RID: 24437
		// (get) Token: 0x06027E6E RID: 163438 RVA: 0x009FD81F File Offset: 0x009FBA1F
		// (set) Token: 0x06027E6F RID: 163439 RVA: 0x009FD82F File Offset: 0x009FBA2F
		public unsafe int DisableKeyOnPercent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17005F76 RID: 24438
		// (get) Token: 0x06027E70 RID: 163440 RVA: 0x009FD840 File Offset: 0x009FBA40
		// (set) Token: 0x06027E71 RID: 163441 RVA: 0x009FD854 File Offset: 0x009FBA54
		public unsafe FGameplayTag KeyEnableTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17005F77 RID: 24439
		// (get) Token: 0x06027E72 RID: 163442 RVA: 0x009FD86C File Offset: 0x009FBA6C
		// (set) Token: 0x06027E73 RID: 163443 RVA: 0x009FD8AF File Offset: 0x009FBAAF
		public TArray<SSpecialEnergyBarKey> KeyInfoList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SSpecialEnergyBarKey> result;
				if ((result = this._KeyInfoList) == null)
				{
					result = (this._KeyInfoList = new TArray<SSpecialEnergyBarKey>(base.NativePtr + (IntPtr)SSpecialEnergyBar.__PropertyOffset_20, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.KeyInfoList.CopyAssign(value);
			}
		}

		// Token: 0x06027E74 RID: 163444 RVA: 0x009FD8BD File Offset: 0x009FBABD
		public SSpecialEnergyBar()
		{
		}

		// Token: 0x06027E75 RID: 163445 RVA: 0x009FD8C8 File Offset: 0x009FBAC8
		public SSpecialEnergyBar(string Name, [Nullable(0)] TEnumAsByte<ESpecialEnergyBarPrefabType> PrefabType, int ExtraType, int SlotNum, TArray<float> ExtraFloatParams, TSoftObjectPtr<UPrefabAsset> PrefabPath, int AttributeId, int MaxAttributeId, long BuffId, TMap<FGameplayTag, int> TagEnergyBarIdMap, string EffectColor, string PointColor, TSoftObjectPtr<UTexture2D> TexturePath, TSoftObjectPtr<UTexture2D> EnableTexturePath, TSoftObjectPtr<UTexture2D> FrontTexturePath, TArray<TSoftObjectPtr<UNiagaraSystem>> NiagaraList, int KeyEnableNiagaraIndex, int KeyType, int DisableKeyOnPercent, FGameplayTag KeyEnableTag, TArray<SSpecialEnergyBarKey> KeyInfoList)
		{
			this.Name = Name;
			this.PrefabType = PrefabType;
			this.ExtraType = ExtraType;
			this.SlotNum = SlotNum;
			this.ExtraFloatParams = ExtraFloatParams;
			this.PrefabPath = PrefabPath;
			this.AttributeId = AttributeId;
			this.MaxAttributeId = MaxAttributeId;
			this.BuffId = BuffId;
			this.TagEnergyBarIdMap = TagEnergyBarIdMap;
			this.EffectColor = EffectColor;
			this.PointColor = PointColor;
			this.TexturePath = TexturePath;
			this.EnableTexturePath = EnableTexturePath;
			this.FrontTexturePath = FrontTexturePath;
			this.NiagaraList = NiagaraList;
			this.KeyEnableNiagaraIndex = KeyEnableNiagaraIndex;
			this.KeyType = KeyType;
			this.DisableKeyOnPercent = DisableKeyOnPercent;
			this.KeyEnableTag = KeyEnableTag;
			this.KeyInfoList = KeyInfoList;
		}

		// Token: 0x06027E76 RID: 163446 RVA: 0x009FD980 File Offset: 0x009FBB80
		protected override IntPtr GetUStructPtr()
		{
			return SSpecialEnergyBar.StaticStruct();
		}

		// Token: 0x06027E77 RID: 163447 RVA: 0x009FD98C File Offset: 0x009FBB8C
		[NullableContext(2)]
		public SSpecialEnergyBar(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027E78 RID: 163448 RVA: 0x009FD996 File Offset: 0x009FBB96
		public SSpecialEnergyBar(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027E79 RID: 163449 RVA: 0x009FD9A1 File Offset: 0x009FBBA1
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSpecialEnergyBar(Pointer, false, true);
		}

		// Token: 0x06027E7A RID: 163450 RVA: 0x009FD9AB File Offset: 0x009FBBAB
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSpecialEnergyBar(Pointer, MemoryOwner);
		}

		// Token: 0x04014F14 RID: 85780
		public const string __ObjectPath = "/Game/Aki/Data/Fight/UI/SSpecialEnergyBar.SSpecialEnergyBar";

		// Token: 0x04014F15 RID: 85781
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014F16 RID: 85782
		internal static int __PropertyOffset_0;

		// Token: 0x04014F17 RID: 85783
		internal static int __PropertyOffset_1;

		// Token: 0x04014F18 RID: 85784
		internal static int __PropertyOffset_2;

		// Token: 0x04014F19 RID: 85785
		internal static int __PropertyOffset_3;

		// Token: 0x04014F1A RID: 85786
		internal static int __PropertyOffset_4;

		// Token: 0x04014F1B RID: 85787
		[Nullable(2)]
		private TArray<float> _ExtraFloatParams;

		// Token: 0x04014F1C RID: 85788
		internal static int __PropertyOffset_5;

		// Token: 0x04014F1D RID: 85789
		internal static int __PropertyOffset_6;

		// Token: 0x04014F1E RID: 85790
		internal static int __PropertyOffset_7;

		// Token: 0x04014F1F RID: 85791
		internal static int __PropertyOffset_8;

		// Token: 0x04014F20 RID: 85792
		internal static int __PropertyOffset_9;

		// Token: 0x04014F21 RID: 85793
		[Nullable(2)]
		private TMap<FGameplayTag, int> _TagEnergyBarIdMap;

		// Token: 0x04014F22 RID: 85794
		internal static int __PropertyOffset_10;

		// Token: 0x04014F23 RID: 85795
		internal static int __PropertyOffset_11;

		// Token: 0x04014F24 RID: 85796
		internal static int __PropertyOffset_12;

		// Token: 0x04014F25 RID: 85797
		internal static int __PropertyOffset_13;

		// Token: 0x04014F26 RID: 85798
		internal static int __PropertyOffset_14;

		// Token: 0x04014F27 RID: 85799
		internal static int __PropertyOffset_15;

		// Token: 0x04014F28 RID: 85800
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TArray<TSoftObjectPtr<UNiagaraSystem>> _NiagaraList;

		// Token: 0x04014F29 RID: 85801
		internal static int __PropertyOffset_16;

		// Token: 0x04014F2A RID: 85802
		internal static int __PropertyOffset_17;

		// Token: 0x04014F2B RID: 85803
		internal static int __PropertyOffset_18;

		// Token: 0x04014F2C RID: 85804
		internal static int __PropertyOffset_19;

		// Token: 0x04014F2D RID: 85805
		internal static int __PropertyOffset_20;

		// Token: 0x04014F2E RID: 85806
		[Nullable(2)]
		private TArray<SSpecialEnergyBarKey> _KeyInfoList;
	}
}
