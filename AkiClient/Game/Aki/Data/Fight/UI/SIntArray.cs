using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.UI
{
	// Token: 0x02003EBD RID: 16061
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/UI/SIntArray.SIntArray")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SIntArray : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027E07 RID: 163335 RVA: 0x009FCDE4 File Offset: 0x009FAFE4
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SIntArray._ScriptStructPtr != 0) ? SIntArray._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/UI/SIntArray.SIntArray", ref SIntArray._ScriptStructPtr);
		}

		// Token: 0x17005F4E RID: 24398
		// (get) Token: 0x06027E08 RID: 163336 RVA: 0x009FCE08 File Offset: 0x009FB008
		// (set) Token: 0x06027E09 RID: 163337 RVA: 0x009FCE4B File Offset: 0x009FB04B
		public TArray<int> IntArray
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._IntArray) == null)
				{
					result = (this._IntArray = new TArray<int>(base.NativePtr + (IntPtr)SIntArray.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.IntArray.CopyAssign(value);
			}
		}

		// Token: 0x06027E0A RID: 163338 RVA: 0x009FCE59 File Offset: 0x009FB059
		public SIntArray()
		{
		}

		// Token: 0x06027E0B RID: 163339 RVA: 0x009FCE61 File Offset: 0x009FB061
		public SIntArray(TArray<int> IntArray)
		{
			this.IntArray = IntArray;
		}

		// Token: 0x06027E0C RID: 163340 RVA: 0x009FCE70 File Offset: 0x009FB070
		protected override IntPtr GetUStructPtr()
		{
			return SIntArray.StaticStruct();
		}

		// Token: 0x06027E0D RID: 163341 RVA: 0x009FCE7C File Offset: 0x009FB07C
		[NullableContext(2)]
		public SIntArray(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027E0E RID: 163342 RVA: 0x009FCE86 File Offset: 0x009FB086
		public SIntArray(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027E0F RID: 163343 RVA: 0x009FCE91 File Offset: 0x009FB091
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SIntArray(Pointer, false, true);
		}

		// Token: 0x06027E10 RID: 163344 RVA: 0x009FCE9B File Offset: 0x009FB09B
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SIntArray(Pointer, MemoryOwner);
		}

		// Token: 0x04014EF1 RID: 85745
		public const string __ObjectPath = "/Game/Aki/Data/Fight/UI/SIntArray.SIntArray";

		// Token: 0x04014EF2 RID: 85746
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014EF3 RID: 85747
		internal static int __PropertyOffset_0;

		// Token: 0x04014EF4 RID: 85748
		[Nullable(2)]
		private TArray<int> _IntArray;
	}
}
