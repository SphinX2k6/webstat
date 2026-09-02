using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Sequence.Manager.Structures
{
	// Token: 0x020043B1 RID: 17329
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Sequence/Manager/Structures/SSeqCharacterBlendGroup.SSeqCharacterBlendGroup")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SSeqCharacterBlendGroup : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602E19A RID: 188826 RVA: 0x00AD6BC6 File Offset: 0x00AD4DC6
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSeqCharacterBlendGroup._ScriptStructPtr != 0) ? SSeqCharacterBlendGroup._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Sequence/Manager/Structures/SSeqCharacterBlendGroup.SSeqCharacterBlendGroup", ref SSeqCharacterBlendGroup._ScriptStructPtr);
		}

		// Token: 0x17007F04 RID: 32516
		// (get) Token: 0x0602E19B RID: 188827 RVA: 0x00AD6BEC File Offset: 0x00AD4DEC
		// (set) Token: 0x0602E19C RID: 188828 RVA: 0x00AD6C2F File Offset: 0x00AD4E2F
		public TArray<SSeqCharacterBlend> BlendGroup
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SSeqCharacterBlend> result;
				if ((result = this._BlendGroup) == null)
				{
					result = (this._BlendGroup = new TArray<SSeqCharacterBlend>(base.NativePtr + (IntPtr)SSeqCharacterBlendGroup.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.BlendGroup.CopyAssign(value);
			}
		}

		// Token: 0x0602E19D RID: 188829 RVA: 0x00AD6C3D File Offset: 0x00AD4E3D
		public SSeqCharacterBlendGroup()
		{
		}

		// Token: 0x0602E19E RID: 188830 RVA: 0x00AD6C45 File Offset: 0x00AD4E45
		public SSeqCharacterBlendGroup(TArray<SSeqCharacterBlend> BlendGroup)
		{
			this.BlendGroup = BlendGroup;
		}

		// Token: 0x0602E19F RID: 188831 RVA: 0x00AD6C54 File Offset: 0x00AD4E54
		protected override IntPtr GetUStructPtr()
		{
			return SSeqCharacterBlendGroup.StaticStruct();
		}

		// Token: 0x0602E1A0 RID: 188832 RVA: 0x00AD6C60 File Offset: 0x00AD4E60
		[NullableContext(2)]
		public SSeqCharacterBlendGroup(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602E1A1 RID: 188833 RVA: 0x00AD6C6A File Offset: 0x00AD4E6A
		public SSeqCharacterBlendGroup(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602E1A2 RID: 188834 RVA: 0x00AD6C75 File Offset: 0x00AD4E75
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSeqCharacterBlendGroup(Pointer, false, true);
		}

		// Token: 0x0602E1A3 RID: 188835 RVA: 0x00AD6C7F File Offset: 0x00AD4E7F
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSeqCharacterBlendGroup(Pointer, MemoryOwner);
		}

		// Token: 0x0401A0F0 RID: 106736
		public const string __ObjectPath = "/Game/Aki/Sequence/Manager/Structures/SSeqCharacterBlendGroup.SSeqCharacterBlendGroup";

		// Token: 0x0401A0F1 RID: 106737
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401A0F2 RID: 106738
		internal static int __PropertyOffset_0;

		// Token: 0x0401A0F3 RID: 106739
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SSeqCharacterBlend> _BlendGroup;
	}
}
