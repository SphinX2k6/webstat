using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Fight.BulletCampAsset
{
	// Token: 0x02003EEC RID: 16108
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Fight/BulletCampAsset/SBulletCampRow.SBulletCampRow")]
	[UnrealStructLayout(8, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 8)]
	public class SBulletCampRow : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060281A5 RID: 164261 RVA: 0x00A026A8 File Offset: 0x00A008A8
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBulletCampRow._ScriptStructPtr != 0) ? SBulletCampRow._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/BulletCampAsset/SBulletCampRow.SBulletCampRow", ref SBulletCampRow._ScriptStructPtr);
		}

		// Token: 0x17006085 RID: 24709
		// (get) Token: 0x060281A6 RID: 164262 RVA: 0x00A026CC File Offset: 0x00A008CC
		// (set) Token: 0x060281A7 RID: 164263 RVA: 0x00A026E0 File Offset: 0x00A008E0
		[Nullable(2)]
		public unsafe BulletCampType_C Ref
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BulletCampType_C>(base.NativePtr / (IntPtr)sizeof(void*) + SBulletCampRow.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SBulletCampRow.__PropertyOffset_0, value);
			}
		}

		// Token: 0x060281A8 RID: 164264 RVA: 0x00A026F5 File Offset: 0x00A008F5
		public SBulletCampRow()
		{
		}

		// Token: 0x060281A9 RID: 164265 RVA: 0x00A026FD File Offset: 0x00A008FD
		[NullableContext(1)]
		public SBulletCampRow(BulletCampType_C Ref)
		{
			this.Ref = Ref;
		}

		// Token: 0x060281AA RID: 164266 RVA: 0x00A0270C File Offset: 0x00A0090C
		protected override IntPtr GetUStructPtr()
		{
			return SBulletCampRow.StaticStruct();
		}

		// Token: 0x060281AB RID: 164267 RVA: 0x00A02718 File Offset: 0x00A00918
		[NullableContext(2)]
		public SBulletCampRow(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060281AC RID: 164268 RVA: 0x00A02722 File Offset: 0x00A00922
		public SBulletCampRow(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060281AD RID: 164269 RVA: 0x00A0272D File Offset: 0x00A0092D
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBulletCampRow(Pointer, false, true);
		}

		// Token: 0x060281AE RID: 164270 RVA: 0x00A02737 File Offset: 0x00A00937
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBulletCampRow(Pointer, MemoryOwner);
		}

		// Token: 0x040150F5 RID: 86261
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/Fight/BulletCampAsset/SBulletCampRow.SBulletCampRow";

		// Token: 0x040150F6 RID: 86262
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040150F7 RID: 86263
		internal static int __PropertyOffset_0;
	}
}
