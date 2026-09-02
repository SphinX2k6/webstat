using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Effect.Struct
{
	// Token: 0x02003F02 RID: 16130
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Effect/Struct/SEffectSpecDataExport.SEffectSpecDataExport")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SEffectSpecDataExport : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060282D6 RID: 164566 RVA: 0x00A0478B File Offset: 0x00A0298B
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SEffectSpecDataExport._ScriptStructPtr != 0) ? SEffectSpecDataExport._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Effect/Struct/SEffectSpecDataExport.SEffectSpecDataExport", ref SEffectSpecDataExport._ScriptStructPtr);
		}

		// Token: 0x170060F1 RID: 24817
		// (get) Token: 0x060282D7 RID: 164567 RVA: 0x00A047B0 File Offset: 0x00A029B0
		// (set) Token: 0x060282D8 RID: 164568 RVA: 0x00A047F3 File Offset: 0x00A029F3
		public TArray<SEffectSpec> EffectSpecs
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SEffectSpec> result;
				if ((result = this._EffectSpecs) == null)
				{
					result = (this._EffectSpecs = new TArray<SEffectSpec>(base.NativePtr + (IntPtr)SEffectSpecDataExport.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.EffectSpecs.CopyAssign(value);
			}
		}

		// Token: 0x060282D9 RID: 164569 RVA: 0x00A04801 File Offset: 0x00A02A01
		public SEffectSpecDataExport()
		{
		}

		// Token: 0x060282DA RID: 164570 RVA: 0x00A04809 File Offset: 0x00A02A09
		public SEffectSpecDataExport(TArray<SEffectSpec> EffectSpecs)
		{
			this.EffectSpecs = EffectSpecs;
		}

		// Token: 0x060282DB RID: 164571 RVA: 0x00A04818 File Offset: 0x00A02A18
		protected override IntPtr GetUStructPtr()
		{
			return SEffectSpecDataExport.StaticStruct();
		}

		// Token: 0x060282DC RID: 164572 RVA: 0x00A04824 File Offset: 0x00A02A24
		[NullableContext(2)]
		public SEffectSpecDataExport(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060282DD RID: 164573 RVA: 0x00A0482E File Offset: 0x00A02A2E
		public SEffectSpecDataExport(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060282DE RID: 164574 RVA: 0x00A04839 File Offset: 0x00A02A39
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SEffectSpecDataExport(Pointer, false, true);
		}

		// Token: 0x060282DF RID: 164575 RVA: 0x00A04843 File Offset: 0x00A02A43
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SEffectSpecDataExport(Pointer, MemoryOwner);
		}

		// Token: 0x040151ED RID: 86509
		public const string __ObjectPath = "/Game/Aki/Data/Effect/Struct/SEffectSpecDataExport.SEffectSpecDataExport";

		// Token: 0x040151EE RID: 86510
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040151EF RID: 86511
		internal static int __PropertyOffset_0;

		// Token: 0x040151F0 RID: 86512
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SEffectSpec> _EffectSpecs;
	}
}
