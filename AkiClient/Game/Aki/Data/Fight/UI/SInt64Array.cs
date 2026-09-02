using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.UI
{
	// Token: 0x02003EBC RID: 16060
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/UI/SInt64Array.SInt64Array")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SInt64Array : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027DFD RID: 163325 RVA: 0x009FCD24 File Offset: 0x009FAF24
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SInt64Array._ScriptStructPtr != 0) ? SInt64Array._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/UI/SInt64Array.SInt64Array", ref SInt64Array._ScriptStructPtr);
		}

		// Token: 0x17005F4D RID: 24397
		// (get) Token: 0x06027DFE RID: 163326 RVA: 0x009FCD48 File Offset: 0x009FAF48
		// (set) Token: 0x06027DFF RID: 163327 RVA: 0x009FCD8B File Offset: 0x009FAF8B
		public TArray<long> Value
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._Value) == null)
				{
					result = (this._Value = new TArray<long>(base.NativePtr + (IntPtr)SInt64Array.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Value.CopyAssign(value);
			}
		}

		// Token: 0x06027E00 RID: 163328 RVA: 0x009FCD99 File Offset: 0x009FAF99
		public SInt64Array()
		{
		}

		// Token: 0x06027E01 RID: 163329 RVA: 0x009FCDA1 File Offset: 0x009FAFA1
		public SInt64Array(TArray<long> Value)
		{
			this.Value = Value;
		}

		// Token: 0x06027E02 RID: 163330 RVA: 0x009FCDB0 File Offset: 0x009FAFB0
		protected override IntPtr GetUStructPtr()
		{
			return SInt64Array.StaticStruct();
		}

		// Token: 0x06027E03 RID: 163331 RVA: 0x009FCDBC File Offset: 0x009FAFBC
		[NullableContext(2)]
		public SInt64Array(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027E04 RID: 163332 RVA: 0x009FCDC6 File Offset: 0x009FAFC6
		public SInt64Array(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027E05 RID: 163333 RVA: 0x009FCDD1 File Offset: 0x009FAFD1
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SInt64Array(Pointer, false, true);
		}

		// Token: 0x06027E06 RID: 163334 RVA: 0x009FCDDB File Offset: 0x009FAFDB
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SInt64Array(Pointer, MemoryOwner);
		}

		// Token: 0x04014EED RID: 85741
		public const string __ObjectPath = "/Game/Aki/Data/Fight/UI/SInt64Array.SInt64Array";

		// Token: 0x04014EEE RID: 85742
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014EEF RID: 85743
		internal static int __PropertyOffset_0;

		// Token: 0x04014EF0 RID: 85744
		[Nullable(2)]
		private TArray<long> _Value;
	}
}
