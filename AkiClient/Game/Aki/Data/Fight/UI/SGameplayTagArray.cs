using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.UI
{
	// Token: 0x02003EBB RID: 16059
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/UI/SGameplayTagArray.SGameplayTagArray")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SGameplayTagArray : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027DF3 RID: 163315 RVA: 0x009FCC64 File Offset: 0x009FAE64
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SGameplayTagArray._ScriptStructPtr != 0) ? SGameplayTagArray._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/UI/SGameplayTagArray.SGameplayTagArray", ref SGameplayTagArray._ScriptStructPtr);
		}

		// Token: 0x17005F4C RID: 24396
		// (get) Token: 0x06027DF4 RID: 163316 RVA: 0x009FCC88 File Offset: 0x009FAE88
		// (set) Token: 0x06027DF5 RID: 163317 RVA: 0x009FCCCB File Offset: 0x009FAECB
		public TArray<FGameplayTag> Value
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FGameplayTag> result;
				if ((result = this._Value) == null)
				{
					result = (this._Value = new TArray<FGameplayTag>(base.NativePtr + (IntPtr)SGameplayTagArray.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Value.CopyAssign(value);
			}
		}

		// Token: 0x06027DF6 RID: 163318 RVA: 0x009FCCD9 File Offset: 0x009FAED9
		public SGameplayTagArray()
		{
		}

		// Token: 0x06027DF7 RID: 163319 RVA: 0x009FCCE1 File Offset: 0x009FAEE1
		public SGameplayTagArray(TArray<FGameplayTag> Value)
		{
			this.Value = Value;
		}

		// Token: 0x06027DF8 RID: 163320 RVA: 0x009FCCF0 File Offset: 0x009FAEF0
		protected override IntPtr GetUStructPtr()
		{
			return SGameplayTagArray.StaticStruct();
		}

		// Token: 0x06027DF9 RID: 163321 RVA: 0x009FCCFC File Offset: 0x009FAEFC
		[NullableContext(2)]
		public SGameplayTagArray(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027DFA RID: 163322 RVA: 0x009FCD06 File Offset: 0x009FAF06
		public SGameplayTagArray(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027DFB RID: 163323 RVA: 0x009FCD11 File Offset: 0x009FAF11
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SGameplayTagArray(Pointer, false, true);
		}

		// Token: 0x06027DFC RID: 163324 RVA: 0x009FCD1B File Offset: 0x009FAF1B
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SGameplayTagArray(Pointer, MemoryOwner);
		}

		// Token: 0x04014EE9 RID: 85737
		public const string __ObjectPath = "/Game/Aki/Data/Fight/UI/SGameplayTagArray.SGameplayTagArray";

		// Token: 0x04014EEA RID: 85738
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014EEB RID: 85739
		internal static int __PropertyOffset_0;

		// Token: 0x04014EEC RID: 85740
		[Nullable(2)]
		private TArray<FGameplayTag> _Value;
	}
}
