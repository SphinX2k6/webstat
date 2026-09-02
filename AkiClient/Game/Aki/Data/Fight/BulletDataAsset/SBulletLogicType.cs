using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.BulletDataAsset
{
	// Token: 0x02003EE9 RID: 16105
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/BulletDataAsset/SBulletLogicType.SBulletLogicType")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SBulletLogicType : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028187 RID: 164231 RVA: 0x00A02490 File Offset: 0x00A00690
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBulletLogicType._ScriptStructPtr != 0) ? SBulletLogicType._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/BulletDataAsset/SBulletLogicType.SBulletLogicType", ref SBulletLogicType._ScriptStructPtr);
		}

		// Token: 0x17006082 RID: 24706
		// (get) Token: 0x06028188 RID: 164232 RVA: 0x00A024B4 File Offset: 0x00A006B4
		// (set) Token: 0x06028189 RID: 164233 RVA: 0x00A024F7 File Offset: 0x00A006F7
		public TArray<BulletLogicType_C> AllBulletLogicType
		{
			get
			{
				base.FastCheckIsValid();
				TArray<BulletLogicType_C> result;
				if ((result = this._AllBulletLogicType) == null)
				{
					result = (this._AllBulletLogicType = new TArray<BulletLogicType_C>(base.NativePtr + (IntPtr)SBulletLogicType.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.AllBulletLogicType.CopyAssign(value);
			}
		}

		// Token: 0x0602818A RID: 164234 RVA: 0x00A02505 File Offset: 0x00A00705
		public SBulletLogicType()
		{
		}

		// Token: 0x0602818B RID: 164235 RVA: 0x00A0250D File Offset: 0x00A0070D
		public SBulletLogicType(TArray<BulletLogicType_C> AllBulletLogicType)
		{
			this.AllBulletLogicType = AllBulletLogicType;
		}

		// Token: 0x0602818C RID: 164236 RVA: 0x00A0251C File Offset: 0x00A0071C
		protected override IntPtr GetUStructPtr()
		{
			return SBulletLogicType.StaticStruct();
		}

		// Token: 0x0602818D RID: 164237 RVA: 0x00A02528 File Offset: 0x00A00728
		[NullableContext(2)]
		public SBulletLogicType(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602818E RID: 164238 RVA: 0x00A02532 File Offset: 0x00A00732
		public SBulletLogicType(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602818F RID: 164239 RVA: 0x00A0253D File Offset: 0x00A0073D
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBulletLogicType(Pointer, false, true);
		}

		// Token: 0x06028190 RID: 164240 RVA: 0x00A02547 File Offset: 0x00A00747
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBulletLogicType(Pointer, MemoryOwner);
		}

		// Token: 0x040150EA RID: 86250
		public const string __ObjectPath = "/Game/Aki/Data/Fight/BulletDataAsset/SBulletLogicType.SBulletLogicType";

		// Token: 0x040150EB RID: 86251
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040150EC RID: 86252
		internal static int __PropertyOffset_0;

		// Token: 0x040150ED RID: 86253
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BulletLogicType_C> _AllBulletLogicType;
	}
}
