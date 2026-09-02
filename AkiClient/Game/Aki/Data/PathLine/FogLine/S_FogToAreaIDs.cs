using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.PathLine.FogLine
{
	// Token: 0x02003E57 RID: 15959
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/PathLine/FogLine/S_FogToAreaIDs.S_FogToAreaIDs")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 18)]
	public class S_FogToAreaIDs : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602763C RID: 161340 RVA: 0x009F0C5E File Offset: 0x009EEE5E
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (S_FogToAreaIDs._ScriptStructPtr != 0) ? S_FogToAreaIDs._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/PathLine/FogLine/S_FogToAreaIDs.S_FogToAreaIDs", ref S_FogToAreaIDs._ScriptStructPtr);
		}

		// Token: 0x17005C86 RID: 23686
		// (get) Token: 0x0602763D RID: 161341 RVA: 0x009F0C84 File Offset: 0x009EEE84
		// (set) Token: 0x0602763E RID: 161342 RVA: 0x009F0CC7 File Offset: 0x009EEEC7
		public TArray<int> AreaFogIDs
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._AreaFogIDs) == null)
				{
					result = (this._AreaFogIDs = new TArray<int>(base.NativePtr + (IntPtr)S_FogToAreaIDs.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.AreaFogIDs.CopyAssign(value);
			}
		}

		// Token: 0x17005C87 RID: 23687
		// (get) Token: 0x0602763F RID: 161343 RVA: 0x009F0CD5 File Offset: 0x009EEED5
		// (set) Token: 0x06027640 RID: 161344 RVA: 0x009F0CE5 File Offset: 0x009EEEE5
		public unsafe bool IsFogP1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_FogToAreaIDs.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_FogToAreaIDs.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005C88 RID: 23688
		// (get) Token: 0x06027641 RID: 161345 RVA: 0x009F0CF6 File Offset: 0x009EEEF6
		// (set) Token: 0x06027642 RID: 161346 RVA: 0x009F0D06 File Offset: 0x009EEF06
		public unsafe bool IsFogP2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_FogToAreaIDs.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_FogToAreaIDs.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x06027643 RID: 161347 RVA: 0x009F0D17 File Offset: 0x009EEF17
		public S_FogToAreaIDs()
		{
		}

		// Token: 0x06027644 RID: 161348 RVA: 0x009F0D1F File Offset: 0x009EEF1F
		public S_FogToAreaIDs(TArray<int> AreaFogIDs, bool IsFogP1, bool IsFogP2)
		{
			this.AreaFogIDs = AreaFogIDs;
			this.IsFogP1 = IsFogP1;
			this.IsFogP2 = IsFogP2;
		}

		// Token: 0x06027645 RID: 161349 RVA: 0x009F0D3C File Offset: 0x009EEF3C
		protected override IntPtr GetUStructPtr()
		{
			return S_FogToAreaIDs.StaticStruct();
		}

		// Token: 0x06027646 RID: 161350 RVA: 0x009F0D48 File Offset: 0x009EEF48
		[NullableContext(2)]
		public S_FogToAreaIDs(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027647 RID: 161351 RVA: 0x009F0D52 File Offset: 0x009EEF52
		public S_FogToAreaIDs(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027648 RID: 161352 RVA: 0x009F0D5D File Offset: 0x009EEF5D
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new S_FogToAreaIDs(Pointer, false, true);
		}

		// Token: 0x06027649 RID: 161353 RVA: 0x009F0D67 File Offset: 0x009EEF67
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new S_FogToAreaIDs(Pointer, MemoryOwner);
		}

		// Token: 0x040149FD RID: 84477
		public const string __ObjectPath = "/Game/Aki/Data/PathLine/FogLine/S_FogToAreaIDs.S_FogToAreaIDs";

		// Token: 0x040149FE RID: 84478
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040149FF RID: 84479
		internal static int __PropertyOffset_0;

		// Token: 0x04014A00 RID: 84480
		[Nullable(2)]
		private TArray<int> _AreaFogIDs;

		// Token: 0x04014A01 RID: 84481
		internal static int __PropertyOffset_1;

		// Token: 0x04014A02 RID: 84482
		internal static int __PropertyOffset_2;
	}
}
