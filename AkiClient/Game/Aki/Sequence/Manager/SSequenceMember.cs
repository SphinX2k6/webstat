using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Sequence.Manager
{
	// Token: 0x020043AC RID: 17324
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Sequence/Manager/SSequenceMember.SSequenceMember")]
	[UnrealStructLayout(88, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 88)]
	public class SSequenceMember : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602E138 RID: 188728 RVA: 0x00AD6262 File Offset: 0x00AD4462
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSequenceMember._ScriptStructPtr != 0) ? SSequenceMember._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Sequence/Manager/SSequenceMember.SSequenceMember", ref SSequenceMember._ScriptStructPtr);
		}

		// Token: 0x17007EE7 RID: 32487
		// (get) Token: 0x0602E139 RID: 188729 RVA: 0x00AD6286 File Offset: 0x00AD4486
		// (set) Token: 0x0602E13A RID: 188730 RVA: 0x00AD6296 File Offset: 0x00AD4496
		public unsafe int SpeakerId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSequenceMember.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSequenceMember.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007EE8 RID: 32488
		// (get) Token: 0x0602E13B RID: 188731 RVA: 0x00AD62A8 File Offset: 0x00AD44A8
		// (set) Token: 0x0602E13C RID: 188732 RVA: 0x00AD62EB File Offset: 0x00AD44EB
		public TMap<string, TSoftClassPtr<UObject>> Bp
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, TSoftClassPtr<UObject>> result;
				if ((result = this._Bp) == null)
				{
					result = (this._Bp = new TMap<string, TSoftClassPtr<UObject>>(base.NativePtr + (IntPtr)SSequenceMember.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Bp.CopyAssign(value);
			}
		}

		// Token: 0x0602E13D RID: 188733 RVA: 0x00AD62F9 File Offset: 0x00AD44F9
		public SSequenceMember()
		{
		}

		// Token: 0x0602E13E RID: 188734 RVA: 0x00AD6301 File Offset: 0x00AD4501
		public SSequenceMember(int SpeakerId, TMap<string, TSoftClassPtr<UObject>> Bp)
		{
			this.SpeakerId = SpeakerId;
			this.Bp = Bp;
		}

		// Token: 0x0602E13F RID: 188735 RVA: 0x00AD6317 File Offset: 0x00AD4517
		protected override IntPtr GetUStructPtr()
		{
			return SSequenceMember.StaticStruct();
		}

		// Token: 0x0602E140 RID: 188736 RVA: 0x00AD6323 File Offset: 0x00AD4523
		[NullableContext(2)]
		public SSequenceMember(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602E141 RID: 188737 RVA: 0x00AD632D File Offset: 0x00AD452D
		public SSequenceMember(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602E142 RID: 188738 RVA: 0x00AD6338 File Offset: 0x00AD4538
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSequenceMember(Pointer, false, true);
		}

		// Token: 0x0602E143 RID: 188739 RVA: 0x00AD6342 File Offset: 0x00AD4542
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSequenceMember(Pointer, MemoryOwner);
		}

		// Token: 0x0401A0BD RID: 106685
		public const string __ObjectPath = "/Game/Aki/Sequence/Manager/SSequenceMember.SSequenceMember";

		// Token: 0x0401A0BE RID: 106686
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401A0BF RID: 106687
		internal static int __PropertyOffset_0;

		// Token: 0x0401A0C0 RID: 106688
		internal static int __PropertyOffset_1;

		// Token: 0x0401A0C1 RID: 106689
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private TMap<string, TSoftClassPtr<UObject>> _Bp;
	}
}
