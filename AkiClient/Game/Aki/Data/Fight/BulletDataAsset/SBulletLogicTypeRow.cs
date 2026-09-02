using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Fight.BulletDataAsset
{
	// Token: 0x02003EEA RID: 16106
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Fight/BulletDataAsset/SBulletLogicTypeRow.SBulletLogicTypeRow")]
	[UnrealStructLayout(8, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 8)]
	public class SBulletLogicTypeRow : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028191 RID: 164241 RVA: 0x00A02550 File Offset: 0x00A00750
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBulletLogicTypeRow._ScriptStructPtr != 0) ? SBulletLogicTypeRow._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/BulletDataAsset/SBulletLogicTypeRow.SBulletLogicTypeRow", ref SBulletLogicTypeRow._ScriptStructPtr);
		}

		// Token: 0x17006083 RID: 24707
		// (get) Token: 0x06028192 RID: 164242 RVA: 0x00A02574 File Offset: 0x00A00774
		// (set) Token: 0x06028193 RID: 164243 RVA: 0x00A02588 File Offset: 0x00A00788
		[Nullable(2)]
		public unsafe BulletLogicType_C Ref
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BulletLogicType_C>(base.NativePtr / (IntPtr)sizeof(void*) + SBulletLogicTypeRow.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SBulletLogicTypeRow.__PropertyOffset_0, value);
			}
		}

		// Token: 0x06028194 RID: 164244 RVA: 0x00A0259D File Offset: 0x00A0079D
		public SBulletLogicTypeRow()
		{
		}

		// Token: 0x06028195 RID: 164245 RVA: 0x00A025A5 File Offset: 0x00A007A5
		[NullableContext(1)]
		public SBulletLogicTypeRow(BulletLogicType_C Ref)
		{
			this.Ref = Ref;
		}

		// Token: 0x06028196 RID: 164246 RVA: 0x00A025B4 File Offset: 0x00A007B4
		protected override IntPtr GetUStructPtr()
		{
			return SBulletLogicTypeRow.StaticStruct();
		}

		// Token: 0x06028197 RID: 164247 RVA: 0x00A025C0 File Offset: 0x00A007C0
		[NullableContext(2)]
		public SBulletLogicTypeRow(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028198 RID: 164248 RVA: 0x00A025CA File Offset: 0x00A007CA
		public SBulletLogicTypeRow(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028199 RID: 164249 RVA: 0x00A025D5 File Offset: 0x00A007D5
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBulletLogicTypeRow(Pointer, false, true);
		}

		// Token: 0x0602819A RID: 164250 RVA: 0x00A025DF File Offset: 0x00A007DF
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBulletLogicTypeRow(Pointer, MemoryOwner);
		}

		// Token: 0x040150EE RID: 86254
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/Fight/BulletDataAsset/SBulletLogicTypeRow.SBulletLogicTypeRow";

		// Token: 0x040150EF RID: 86255
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040150F0 RID: 86256
		internal static int __PropertyOffset_0;
	}
}
