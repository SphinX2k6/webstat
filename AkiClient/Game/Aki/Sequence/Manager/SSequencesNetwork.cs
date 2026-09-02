using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Sequence.Manager
{
	// Token: 0x020043AE RID: 17326
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Sequence/Manager/SSequencesNetwork.SSequencesNetwork")]
	[UnrealStructLayout(128, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 128)]
	public class SSequencesNetwork : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602E158 RID: 188760 RVA: 0x00AD65D6 File Offset: 0x00AD47D6
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSequencesNetwork._ScriptStructPtr != 0) ? SSequencesNetwork._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Sequence/Manager/SSequencesNetwork.SSequencesNetwork", ref SSequencesNetwork._ScriptStructPtr);
		}

		// Token: 0x17007EEF RID: 32495
		// (get) Token: 0x0602E159 RID: 188761 RVA: 0x00AD65FC File Offset: 0x00AD47FC
		// (set) Token: 0x0602E15A RID: 188762 RVA: 0x00AD663F File Offset: 0x00AD483F
		public SSequencesNetwrokNode StartSequence
		{
			get
			{
				base.FastCheckIsValid();
				SSequencesNetwrokNode result;
				if ((result = this._StartSequence) == null)
				{
					result = (this._StartSequence = new SSequencesNetwrokNode(base.NativePtr + (IntPtr)SSequencesNetwork.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SSequencesNetwrokNode.StaticStruct(), base.NativePtr + (IntPtr)SSequencesNetwork.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007EF0 RID: 32496
		// (get) Token: 0x0602E15B RID: 188763 RVA: 0x00AD6660 File Offset: 0x00AD4860
		// (set) Token: 0x0602E15C RID: 188764 RVA: 0x00AD66A3 File Offset: 0x00AD48A3
		public TArray<SSequencesNetwrokNode> ProcessSequences
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SSequencesNetwrokNode> result;
				if ((result = this._ProcessSequences) == null)
				{
					result = (this._ProcessSequences = new TArray<SSequencesNetwrokNode>(base.NativePtr + (IntPtr)SSequencesNetwork.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ProcessSequences.CopyAssign(value);
			}
		}

		// Token: 0x17007EF1 RID: 32497
		// (get) Token: 0x0602E15D RID: 188765 RVA: 0x00AD66B4 File Offset: 0x00AD48B4
		// (set) Token: 0x0602E15E RID: 188766 RVA: 0x00AD66F7 File Offset: 0x00AD48F7
		public TArray<SSequencesNetwrokNode> EndSequences
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SSequencesNetwrokNode> result;
				if ((result = this._EndSequences) == null)
				{
					result = (this._EndSequences = new TArray<SSequencesNetwrokNode>(base.NativePtr + (IntPtr)SSequencesNetwork.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.EndSequences.CopyAssign(value);
			}
		}

		// Token: 0x0602E15F RID: 188767 RVA: 0x00AD6705 File Offset: 0x00AD4905
		public SSequencesNetwork()
		{
		}

		// Token: 0x0602E160 RID: 188768 RVA: 0x00AD670D File Offset: 0x00AD490D
		public SSequencesNetwork(SSequencesNetwrokNode StartSequence, TArray<SSequencesNetwrokNode> ProcessSequences, TArray<SSequencesNetwrokNode> EndSequences)
		{
			this.StartSequence = StartSequence;
			this.ProcessSequences = ProcessSequences;
			this.EndSequences = EndSequences;
		}

		// Token: 0x0602E161 RID: 188769 RVA: 0x00AD672A File Offset: 0x00AD492A
		protected override IntPtr GetUStructPtr()
		{
			return SSequencesNetwork.StaticStruct();
		}

		// Token: 0x0602E162 RID: 188770 RVA: 0x00AD6736 File Offset: 0x00AD4936
		[NullableContext(2)]
		public SSequencesNetwork(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602E163 RID: 188771 RVA: 0x00AD6740 File Offset: 0x00AD4940
		public SSequencesNetwork(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602E164 RID: 188772 RVA: 0x00AD674B File Offset: 0x00AD494B
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSequencesNetwork(Pointer, false, true);
		}

		// Token: 0x0602E165 RID: 188773 RVA: 0x00AD6755 File Offset: 0x00AD4955
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSequencesNetwork(Pointer, MemoryOwner);
		}

		// Token: 0x0401A0D0 RID: 106704
		public const string __ObjectPath = "/Game/Aki/Sequence/Manager/SSequencesNetwork.SSequencesNetwork";

		// Token: 0x0401A0D1 RID: 106705
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401A0D2 RID: 106706
		internal static int __PropertyOffset_0;

		// Token: 0x0401A0D3 RID: 106707
		[Nullable(2)]
		private SSequencesNetwrokNode _StartSequence;

		// Token: 0x0401A0D4 RID: 106708
		internal static int __PropertyOffset_1;

		// Token: 0x0401A0D5 RID: 106709
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SSequencesNetwrokNode> _ProcessSequences;

		// Token: 0x0401A0D6 RID: 106710
		internal static int __PropertyOffset_2;

		// Token: 0x0401A0D7 RID: 106711
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SSequencesNetwrokNode> _EndSequences;
	}
}
