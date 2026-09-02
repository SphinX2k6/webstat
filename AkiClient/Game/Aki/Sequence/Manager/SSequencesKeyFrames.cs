using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Sequence.Manager
{
	// Token: 0x020043AD RID: 17325
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Sequence/Manager/SSequencesKeyFrames.SSequencesKeyFrames")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 160)]
	public class SSequencesKeyFrames : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602E144 RID: 188740 RVA: 0x00AD634B File Offset: 0x00AD454B
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSequencesKeyFrames._ScriptStructPtr != 0) ? SSequencesKeyFrames._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Sequence/Manager/SSequencesKeyFrames.SSequencesKeyFrames", ref SSequencesKeyFrames._ScriptStructPtr);
		}

		// Token: 0x17007EE9 RID: 32489
		// (get) Token: 0x0602E145 RID: 188741 RVA: 0x00AD6370 File Offset: 0x00AD4570
		// (set) Token: 0x0602E146 RID: 188742 RVA: 0x00AD63B3 File Offset: 0x00AD45B3
		public TArray<int> SubtitleStartFrames
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._SubtitleStartFrames) == null)
				{
					result = (this._SubtitleStartFrames = new TArray<int>(base.NativePtr + (IntPtr)SSequencesKeyFrames.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SubtitleStartFrames.CopyAssign(value);
			}
		}

		// Token: 0x17007EEA RID: 32490
		// (get) Token: 0x0602E147 RID: 188743 RVA: 0x00AD63C4 File Offset: 0x00AD45C4
		// (set) Token: 0x0602E148 RID: 188744 RVA: 0x00AD6407 File Offset: 0x00AD4607
		public TArray<int> SubtitleEndFrames
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._SubtitleEndFrames) == null)
				{
					result = (this._SubtitleEndFrames = new TArray<int>(base.NativePtr + (IntPtr)SSequencesKeyFrames.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SubtitleEndFrames.CopyAssign(value);
			}
		}

		// Token: 0x17007EEB RID: 32491
		// (get) Token: 0x0602E149 RID: 188745 RVA: 0x00AD6418 File Offset: 0x00AD4618
		// (set) Token: 0x0602E14A RID: 188746 RVA: 0x00AD645B File Offset: 0x00AD465B
		public TArray<int> ShotStartFrames
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._ShotStartFrames) == null)
				{
					result = (this._ShotStartFrames = new TArray<int>(base.NativePtr + (IntPtr)SSequencesKeyFrames.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ShotStartFrames.CopyAssign(value);
			}
		}

		// Token: 0x17007EEC RID: 32492
		// (get) Token: 0x0602E14B RID: 188747 RVA: 0x00AD646C File Offset: 0x00AD466C
		// (set) Token: 0x0602E14C RID: 188748 RVA: 0x00AD64AF File Offset: 0x00AD46AF
		public TArray<int> ShotEndFrames
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._ShotEndFrames) == null)
				{
					result = (this._ShotEndFrames = new TArray<int>(base.NativePtr + (IntPtr)SSequencesKeyFrames.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ShotEndFrames.CopyAssign(value);
			}
		}

		// Token: 0x17007EED RID: 32493
		// (get) Token: 0x0602E14D RID: 188749 RVA: 0x00AD64C0 File Offset: 0x00AD46C0
		// (set) Token: 0x0602E14E RID: 188750 RVA: 0x00AD6503 File Offset: 0x00AD4703
		public TMap<string, int> FrameEventFrames
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, int> result;
				if ((result = this._FrameEventFrames) == null)
				{
					result = (this._FrameEventFrames = new TMap<string, int>(base.NativePtr + (IntPtr)SSequencesKeyFrames.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.FrameEventFrames.CopyAssign(value);
			}
		}

		// Token: 0x17007EEE RID: 32494
		// (get) Token: 0x0602E14F RID: 188751 RVA: 0x00AD6514 File Offset: 0x00AD4714
		// (set) Token: 0x0602E150 RID: 188752 RVA: 0x00AD6557 File Offset: 0x00AD4757
		public TArray<int> KeyFrames
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._KeyFrames) == null)
				{
					result = (this._KeyFrames = new TArray<int>(base.NativePtr + (IntPtr)SSequencesKeyFrames.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.KeyFrames.CopyAssign(value);
			}
		}

		// Token: 0x0602E151 RID: 188753 RVA: 0x00AD6565 File Offset: 0x00AD4765
		public SSequencesKeyFrames()
		{
		}

		// Token: 0x0602E152 RID: 188754 RVA: 0x00AD656D File Offset: 0x00AD476D
		public SSequencesKeyFrames(TArray<int> SubtitleStartFrames, TArray<int> SubtitleEndFrames, TArray<int> ShotStartFrames, TArray<int> ShotEndFrames, TMap<string, int> FrameEventFrames, TArray<int> KeyFrames)
		{
			this.SubtitleStartFrames = SubtitleStartFrames;
			this.SubtitleEndFrames = SubtitleEndFrames;
			this.ShotStartFrames = ShotStartFrames;
			this.ShotEndFrames = ShotEndFrames;
			this.FrameEventFrames = FrameEventFrames;
			this.KeyFrames = KeyFrames;
		}

		// Token: 0x0602E153 RID: 188755 RVA: 0x00AD65A2 File Offset: 0x00AD47A2
		protected override IntPtr GetUStructPtr()
		{
			return SSequencesKeyFrames.StaticStruct();
		}

		// Token: 0x0602E154 RID: 188756 RVA: 0x00AD65AE File Offset: 0x00AD47AE
		[NullableContext(2)]
		public SSequencesKeyFrames(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602E155 RID: 188757 RVA: 0x00AD65B8 File Offset: 0x00AD47B8
		public SSequencesKeyFrames(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602E156 RID: 188758 RVA: 0x00AD65C3 File Offset: 0x00AD47C3
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSequencesKeyFrames(Pointer, false, true);
		}

		// Token: 0x0602E157 RID: 188759 RVA: 0x00AD65CD File Offset: 0x00AD47CD
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSequencesKeyFrames(Pointer, MemoryOwner);
		}

		// Token: 0x0401A0C2 RID: 106690
		public const string __ObjectPath = "/Game/Aki/Sequence/Manager/SSequencesKeyFrames.SSequencesKeyFrames";

		// Token: 0x0401A0C3 RID: 106691
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401A0C4 RID: 106692
		internal static int __PropertyOffset_0;

		// Token: 0x0401A0C5 RID: 106693
		[Nullable(2)]
		private TArray<int> _SubtitleStartFrames;

		// Token: 0x0401A0C6 RID: 106694
		internal static int __PropertyOffset_1;

		// Token: 0x0401A0C7 RID: 106695
		[Nullable(2)]
		private TArray<int> _SubtitleEndFrames;

		// Token: 0x0401A0C8 RID: 106696
		internal static int __PropertyOffset_2;

		// Token: 0x0401A0C9 RID: 106697
		[Nullable(2)]
		private TArray<int> _ShotStartFrames;

		// Token: 0x0401A0CA RID: 106698
		internal static int __PropertyOffset_3;

		// Token: 0x0401A0CB RID: 106699
		[Nullable(2)]
		private TArray<int> _ShotEndFrames;

		// Token: 0x0401A0CC RID: 106700
		internal static int __PropertyOffset_4;

		// Token: 0x0401A0CD RID: 106701
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<string, int> _FrameEventFrames;

		// Token: 0x0401A0CE RID: 106702
		internal static int __PropertyOffset_5;

		// Token: 0x0401A0CF RID: 106703
		[Nullable(2)]
		private TArray<int> _KeyFrames;
	}
}
