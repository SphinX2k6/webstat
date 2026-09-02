using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Common.Struct
{
	// Token: 0x02003F0B RID: 16139
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Common/Struct/SVectorArray.SVectorArray")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SVectorArray : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028343 RID: 164675 RVA: 0x00A052B8 File Offset: 0x00A034B8
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SVectorArray._ScriptStructPtr != 0) ? SVectorArray._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Common/Struct/SVectorArray.SVectorArray", ref SVectorArray._ScriptStructPtr);
		}

		// Token: 0x1700610A RID: 24842
		// (get) Token: 0x06028344 RID: 164676 RVA: 0x00A052DC File Offset: 0x00A034DC
		// (set) Token: 0x06028345 RID: 164677 RVA: 0x00A0531F File Offset: 0x00A0351F
		public TArray<FVectorDouble> Vectors
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVectorDouble> result;
				if ((result = this._Vectors) == null)
				{
					result = (this._Vectors = new TArray<FVectorDouble>(base.NativePtr + (IntPtr)SVectorArray.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Vectors.CopyAssign(value);
			}
		}

		// Token: 0x06028346 RID: 164678 RVA: 0x00A0532D File Offset: 0x00A0352D
		public SVectorArray()
		{
		}

		// Token: 0x06028347 RID: 164679 RVA: 0x00A05335 File Offset: 0x00A03535
		public SVectorArray(TArray<FVectorDouble> Vectors)
		{
			this.Vectors = Vectors;
		}

		// Token: 0x06028348 RID: 164680 RVA: 0x00A05344 File Offset: 0x00A03544
		protected override IntPtr GetUStructPtr()
		{
			return SVectorArray.StaticStruct();
		}

		// Token: 0x06028349 RID: 164681 RVA: 0x00A05350 File Offset: 0x00A03550
		[NullableContext(2)]
		public SVectorArray(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602834A RID: 164682 RVA: 0x00A0535A File Offset: 0x00A0355A
		public SVectorArray(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602834B RID: 164683 RVA: 0x00A05365 File Offset: 0x00A03565
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SVectorArray(Pointer, false, true);
		}

		// Token: 0x0602834C RID: 164684 RVA: 0x00A0536F File Offset: 0x00A0356F
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SVectorArray(Pointer, MemoryOwner);
		}

		// Token: 0x0401522E RID: 86574
		public const string __ObjectPath = "/Game/Aki/Data/Common/Struct/SVectorArray.SVectorArray";

		// Token: 0x0401522F RID: 86575
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015230 RID: 86576
		internal static int __PropertyOffset_0;

		// Token: 0x04015231 RID: 86577
		[Nullable(2)]
		private TArray<FVectorDouble> _Vectors;
	}
}
