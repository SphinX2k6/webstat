using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Fight.CommonGB
{
	// Token: 0x02003EE7 RID: 16103
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Fight/CommonGB/SAllKuroBpDataGroup.SAllKuroBpDataGroup")]
	[UnrealStructLayout(8, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 8)]
	public class SAllKuroBpDataGroup : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028173 RID: 164211 RVA: 0x00A02335 File Offset: 0x00A00535
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SAllKuroBpDataGroup._ScriptStructPtr != 0) ? SAllKuroBpDataGroup._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/CommonGB/SAllKuroBpDataGroup.SAllKuroBpDataGroup", ref SAllKuroBpDataGroup._ScriptStructPtr);
		}

		// Token: 0x17006080 RID: 24704
		// (get) Token: 0x06028174 RID: 164212 RVA: 0x00A02359 File Offset: 0x00A00559
		// (set) Token: 0x06028175 RID: 164213 RVA: 0x00A0236D File Offset: 0x00A0056D
		[Nullable(2)]
		public unsafe UKuroBpDataAssetGroup DataRef
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroBpDataAssetGroup>(base.NativePtr / (IntPtr)sizeof(void*) + SAllKuroBpDataGroup.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SAllKuroBpDataGroup.__PropertyOffset_0, value);
			}
		}

		// Token: 0x06028176 RID: 164214 RVA: 0x00A02382 File Offset: 0x00A00582
		public SAllKuroBpDataGroup()
		{
		}

		// Token: 0x06028177 RID: 164215 RVA: 0x00A0238A File Offset: 0x00A0058A
		[NullableContext(1)]
		public SAllKuroBpDataGroup(UKuroBpDataAssetGroup DataRef)
		{
			this.DataRef = DataRef;
		}

		// Token: 0x06028178 RID: 164216 RVA: 0x00A02399 File Offset: 0x00A00599
		protected override IntPtr GetUStructPtr()
		{
			return SAllKuroBpDataGroup.StaticStruct();
		}

		// Token: 0x06028179 RID: 164217 RVA: 0x00A023A5 File Offset: 0x00A005A5
		[NullableContext(2)]
		public SAllKuroBpDataGroup(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602817A RID: 164218 RVA: 0x00A023AF File Offset: 0x00A005AF
		public SAllKuroBpDataGroup(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602817B RID: 164219 RVA: 0x00A023BA File Offset: 0x00A005BA
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SAllKuroBpDataGroup(Pointer, false, true);
		}

		// Token: 0x0602817C RID: 164220 RVA: 0x00A023C4 File Offset: 0x00A005C4
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SAllKuroBpDataGroup(Pointer, MemoryOwner);
		}

		// Token: 0x040150E3 RID: 86243
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/Fight/CommonGB/SAllKuroBpDataGroup.SAllKuroBpDataGroup";

		// Token: 0x040150E4 RID: 86244
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040150E5 RID: 86245
		internal static int __PropertyOffset_0;
	}
}
