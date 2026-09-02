using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.BulletCampAsset
{
	// Token: 0x02003EEB RID: 16107
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/BulletCampAsset/SBulletCamp.SBulletCamp")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SBulletCamp : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602819B RID: 164251 RVA: 0x00A025E8 File Offset: 0x00A007E8
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBulletCamp._ScriptStructPtr != 0) ? SBulletCamp._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/BulletCampAsset/SBulletCamp.SBulletCamp", ref SBulletCamp._ScriptStructPtr);
		}

		// Token: 0x17006084 RID: 24708
		// (get) Token: 0x0602819C RID: 164252 RVA: 0x00A0260C File Offset: 0x00A0080C
		// (set) Token: 0x0602819D RID: 164253 RVA: 0x00A0264F File Offset: 0x00A0084F
		public TArray<BulletCampType_C> AllType
		{
			get
			{
				base.FastCheckIsValid();
				TArray<BulletCampType_C> result;
				if ((result = this._AllType) == null)
				{
					result = (this._AllType = new TArray<BulletCampType_C>(base.NativePtr + (IntPtr)SBulletCamp.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.AllType.CopyAssign(value);
			}
		}

		// Token: 0x0602819E RID: 164254 RVA: 0x00A0265D File Offset: 0x00A0085D
		public SBulletCamp()
		{
		}

		// Token: 0x0602819F RID: 164255 RVA: 0x00A02665 File Offset: 0x00A00865
		public SBulletCamp(TArray<BulletCampType_C> AllType)
		{
			this.AllType = AllType;
		}

		// Token: 0x060281A0 RID: 164256 RVA: 0x00A02674 File Offset: 0x00A00874
		protected override IntPtr GetUStructPtr()
		{
			return SBulletCamp.StaticStruct();
		}

		// Token: 0x060281A1 RID: 164257 RVA: 0x00A02680 File Offset: 0x00A00880
		[NullableContext(2)]
		public SBulletCamp(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060281A2 RID: 164258 RVA: 0x00A0268A File Offset: 0x00A0088A
		public SBulletCamp(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060281A3 RID: 164259 RVA: 0x00A02695 File Offset: 0x00A00895
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBulletCamp(Pointer, false, true);
		}

		// Token: 0x060281A4 RID: 164260 RVA: 0x00A0269F File Offset: 0x00A0089F
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBulletCamp(Pointer, MemoryOwner);
		}

		// Token: 0x040150F1 RID: 86257
		public const string __ObjectPath = "/Game/Aki/Data/Fight/BulletCampAsset/SBulletCamp.SBulletCamp";

		// Token: 0x040150F2 RID: 86258
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040150F3 RID: 86259
		internal static int __PropertyOffset_0;

		// Token: 0x040150F4 RID: 86260
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BulletCampType_C> _AllType;
	}
}
