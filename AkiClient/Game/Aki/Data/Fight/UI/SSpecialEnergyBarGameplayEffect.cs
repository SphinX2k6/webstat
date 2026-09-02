using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.UI
{
	// Token: 0x02003EC2 RID: 16066
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/UI/SSpecialEnergyBarGameplayEffect.SSpecialEnergyBarGameplayEffect")]
	[UnrealStructLayout(104, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 104)]
	public class SSpecialEnergyBarGameplayEffect : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027E8D RID: 163469 RVA: 0x009FDAEE File Offset: 0x009FBCEE
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSpecialEnergyBarGameplayEffect._ScriptStructPtr != 0) ? SSpecialEnergyBarGameplayEffect._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/UI/SSpecialEnergyBarGameplayEffect.SSpecialEnergyBarGameplayEffect", ref SSpecialEnergyBarGameplayEffect._ScriptStructPtr);
		}

		// Token: 0x17005F7D RID: 24445
		// (get) Token: 0x06027E8E RID: 163470 RVA: 0x009FDB12 File Offset: 0x009FBD12
		// (set) Token: 0x06027E8F RID: 163471 RVA: 0x009FDB26 File Offset: 0x009FBD26
		public unsafe FGameplayTag Tag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSpecialEnergyBarGameplayEffect.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSpecialEnergyBarGameplayEffect.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005F7E RID: 24446
		// (get) Token: 0x06027E90 RID: 163472 RVA: 0x009FDB3B File Offset: 0x009FBD3B
		// (set) Token: 0x06027E91 RID: 163473 RVA: 0x009FDB4B File Offset: 0x009FBD4B
		public unsafe long BuffId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSpecialEnergyBarGameplayEffect.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSpecialEnergyBarGameplayEffect.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005F7F RID: 24447
		// (get) Token: 0x06027E92 RID: 163474 RVA: 0x009FDB5C File Offset: 0x009FBD5C
		// (set) Token: 0x06027E93 RID: 163475 RVA: 0x009FDB9F File Offset: 0x009FBD9F
		public TMap<int, SIntArray> SizeMap
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, SIntArray> result;
				if ((result = this._SizeMap) == null)
				{
					result = (this._SizeMap = new TMap<int, SIntArray>(base.NativePtr + (IntPtr)SSpecialEnergyBarGameplayEffect.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SizeMap.CopyAssign(value);
			}
		}

		// Token: 0x06027E94 RID: 163476 RVA: 0x009FDBAD File Offset: 0x009FBDAD
		public SSpecialEnergyBarGameplayEffect()
		{
		}

		// Token: 0x06027E95 RID: 163477 RVA: 0x009FDBB5 File Offset: 0x009FBDB5
		public SSpecialEnergyBarGameplayEffect(FGameplayTag Tag, long BuffId, TMap<int, SIntArray> SizeMap)
		{
			this.Tag = Tag;
			this.BuffId = BuffId;
			this.SizeMap = SizeMap;
		}

		// Token: 0x06027E96 RID: 163478 RVA: 0x009FDBD2 File Offset: 0x009FBDD2
		protected override IntPtr GetUStructPtr()
		{
			return SSpecialEnergyBarGameplayEffect.StaticStruct();
		}

		// Token: 0x06027E97 RID: 163479 RVA: 0x009FDBDE File Offset: 0x009FBDDE
		[NullableContext(2)]
		public SSpecialEnergyBarGameplayEffect(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027E98 RID: 163480 RVA: 0x009FDBE8 File Offset: 0x009FBDE8
		public SSpecialEnergyBarGameplayEffect(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027E99 RID: 163481 RVA: 0x009FDBF3 File Offset: 0x009FBDF3
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSpecialEnergyBarGameplayEffect(Pointer, false, true);
		}

		// Token: 0x06027E9A RID: 163482 RVA: 0x009FDBFD File Offset: 0x009FBDFD
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSpecialEnergyBarGameplayEffect(Pointer, MemoryOwner);
		}

		// Token: 0x04014F36 RID: 85814
		public const string __ObjectPath = "/Game/Aki/Data/Fight/UI/SSpecialEnergyBarGameplayEffect.SSpecialEnergyBarGameplayEffect";

		// Token: 0x04014F37 RID: 85815
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014F38 RID: 85816
		internal static int __PropertyOffset_0;

		// Token: 0x04014F39 RID: 85817
		internal static int __PropertyOffset_1;

		// Token: 0x04014F3A RID: 85818
		internal static int __PropertyOffset_2;

		// Token: 0x04014F3B RID: 85819
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<int, SIntArray> _SizeMap;
	}
}
