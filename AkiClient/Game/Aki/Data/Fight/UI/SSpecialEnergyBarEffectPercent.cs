using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.UI
{
	// Token: 0x02003EC1 RID: 16065
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Fight/UI/SSpecialEnergyBarEffectPercent.SSpecialEnergyBarEffectPercent")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 32)]
	public class SSpecialEnergyBarEffectPercent : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027E7B RID: 163451 RVA: 0x009FD9B4 File Offset: 0x009FBBB4
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSpecialEnergyBarEffectPercent._ScriptStructPtr != 0) ? SSpecialEnergyBarEffectPercent._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/UI/SSpecialEnergyBarEffectPercent.SSpecialEnergyBarEffectPercent", ref SSpecialEnergyBarEffectPercent._ScriptStructPtr);
		}

		// Token: 0x17005F78 RID: 24440
		// (get) Token: 0x06027E7C RID: 163452 RVA: 0x009FD9D8 File Offset: 0x009FBBD8
		// (set) Token: 0x06027E7D RID: 163453 RVA: 0x009FD9E8 File Offset: 0x009FBBE8
		public unsafe int MinPercent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSpecialEnergyBarEffectPercent.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSpecialEnergyBarEffectPercent.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005F79 RID: 24441
		// (get) Token: 0x06027E7E RID: 163454 RVA: 0x009FD9F9 File Offset: 0x009FBBF9
		// (set) Token: 0x06027E7F RID: 163455 RVA: 0x009FDA09 File Offset: 0x009FBC09
		public unsafe int MaxPercent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSpecialEnergyBarEffectPercent.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSpecialEnergyBarEffectPercent.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005F7A RID: 24442
		// (get) Token: 0x06027E80 RID: 163456 RVA: 0x009FDA1A File Offset: 0x009FBC1A
		// (set) Token: 0x06027E81 RID: 163457 RVA: 0x009FDA2A File Offset: 0x009FBC2A
		public unsafe float MinValue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSpecialEnergyBarEffectPercent.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSpecialEnergyBarEffectPercent.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005F7B RID: 24443
		// (get) Token: 0x06027E82 RID: 163458 RVA: 0x009FDA3B File Offset: 0x009FBC3B
		// (set) Token: 0x06027E83 RID: 163459 RVA: 0x009FDA4B File Offset: 0x009FBC4B
		public unsafe float MaxValue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSpecialEnergyBarEffectPercent.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSpecialEnergyBarEffectPercent.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005F7C RID: 24444
		// (get) Token: 0x06027E84 RID: 163460 RVA: 0x009FDA5C File Offset: 0x009FBC5C
		// (set) Token: 0x06027E85 RID: 163461 RVA: 0x009FDA70 File Offset: 0x009FBC70
		public unsafe string FloatParameterName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SSpecialEnergyBarEffectPercent.__PropertyOffset_4)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SSpecialEnergyBarEffectPercent.__PropertyOffset_4)), value);
			}
		}

		// Token: 0x06027E86 RID: 163462 RVA: 0x009FDA85 File Offset: 0x009FBC85
		public SSpecialEnergyBarEffectPercent()
		{
		}

		// Token: 0x06027E87 RID: 163463 RVA: 0x009FDA8D File Offset: 0x009FBC8D
		public SSpecialEnergyBarEffectPercent(int MinPercent, int MaxPercent, float MinValue, float MaxValue, string FloatParameterName)
		{
			this.MinPercent = MinPercent;
			this.MaxPercent = MaxPercent;
			this.MinValue = MinValue;
			this.MaxValue = MaxValue;
			this.FloatParameterName = FloatParameterName;
		}

		// Token: 0x06027E88 RID: 163464 RVA: 0x009FDABA File Offset: 0x009FBCBA
		protected override IntPtr GetUStructPtr()
		{
			return SSpecialEnergyBarEffectPercent.StaticStruct();
		}

		// Token: 0x06027E89 RID: 163465 RVA: 0x009FDAC6 File Offset: 0x009FBCC6
		[NullableContext(2)]
		public SSpecialEnergyBarEffectPercent(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027E8A RID: 163466 RVA: 0x009FDAD0 File Offset: 0x009FBCD0
		public SSpecialEnergyBarEffectPercent(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027E8B RID: 163467 RVA: 0x009FDADB File Offset: 0x009FBCDB
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSpecialEnergyBarEffectPercent(Pointer, false, true);
		}

		// Token: 0x06027E8C RID: 163468 RVA: 0x009FDAE5 File Offset: 0x009FBCE5
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSpecialEnergyBarEffectPercent(Pointer, MemoryOwner);
		}

		// Token: 0x04014F2F RID: 85807
		public const string __ObjectPath = "/Game/Aki/Data/Fight/UI/SSpecialEnergyBarEffectPercent.SSpecialEnergyBarEffectPercent";

		// Token: 0x04014F30 RID: 85808
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014F31 RID: 85809
		internal static int __PropertyOffset_0;

		// Token: 0x04014F32 RID: 85810
		internal static int __PropertyOffset_1;

		// Token: 0x04014F33 RID: 85811
		internal static int __PropertyOffset_2;

		// Token: 0x04014F34 RID: 85812
		internal static int __PropertyOffset_3;

		// Token: 0x04014F35 RID: 85813
		internal static int __PropertyOffset_4;
	}
}
