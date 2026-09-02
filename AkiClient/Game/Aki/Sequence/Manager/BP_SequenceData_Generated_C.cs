using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Sequence.Manager
{
	// Token: 0x020043A7 RID: 17319
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Sequence/Manager/BP_SequenceData_Generated.BP_SequenceData_Generated_C")]
	[UnrealStructLayout(456, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 456)]
	public class BP_SequenceData_Generated_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602E10A RID: 188682 RVA: 0x00AD5D18 File Offset: 0x00AD3F18
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SequenceData_Generated_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Sequence/Manager/BP_SequenceData_Generated.BP_SequenceData_Generated_C");
			}
			return BP_SequenceData_Generated_C._ClassPtr;
		}

		// Token: 0x0602E10B RID: 188683 RVA: 0x00AD5D3C File Offset: 0x00AD3F3C
		public BP_SequenceData_Generated_C() : this(BuiltinUtils.AllocNativeUObject(BP_SequenceData_Generated_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602E10C RID: 188684 RVA: 0x00AD5D64 File Offset: 0x00AD3F64
		public BP_SequenceData_Generated_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SequenceData_Generated_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007ED7 RID: 32471
		// (get) Token: 0x0602E10D RID: 188685 RVA: 0x00AD5D98 File Offset: 0x00AD3F98
		// (set) Token: 0x0602E10E RID: 188686 RVA: 0x00AD5DD1 File Offset: 0x00AD3FD1
		public TArray<SSequencesKeyFrames> KeyFrames
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SSequencesKeyFrames> result;
				if ((result = this._KeyFrames) == null)
				{
					result = (this._KeyFrames = new TArray<SSequencesKeyFrames>(base.NativePtr + (IntPtr)BP_SequenceData_Generated_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.KeyFrames.CopyAssign(value);
			}
		}

		// Token: 0x17007ED8 RID: 32472
		// (get) Token: 0x0602E10F RID: 188687 RVA: 0x00AD5DE0 File Offset: 0x00AD3FE0
		// (set) Token: 0x0602E110 RID: 188688 RVA: 0x00AD5E19 File Offset: 0x00AD4019
		public TArray<FTransform> FinalPos
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FTransform> result;
				if ((result = this._FinalPos) == null)
				{
					result = (this._FinalPos = new TArray<FTransform>(base.NativePtr + (IntPtr)BP_SequenceData_Generated_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.FinalPos.CopyAssign(value);
			}
		}

		// Token: 0x17007ED9 RID: 32473
		// (get) Token: 0x0602E111 RID: 188689 RVA: 0x00AD5E28 File Offset: 0x00AD4028
		// (set) Token: 0x0602E112 RID: 188690 RVA: 0x00AD5E61 File Offset: 0x00AD4061
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TArray<TSubclassOf<AActor>> BindingBP
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TSubclassOf<AActor>> result;
				if ((result = this._BindingBP) == null)
				{
					result = (this._BindingBP = new TArray<TSubclassOf<AActor>>(base.NativePtr + (IntPtr)BP_SequenceData_Generated_C.__PropertyOffset_2, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.BindingBP.CopyAssign(value);
			}
		}

		// Token: 0x17007EDA RID: 32474
		// (get) Token: 0x0602E113 RID: 188691 RVA: 0x00AD5E70 File Offset: 0x00AD4070
		// (set) Token: 0x0602E114 RID: 188692 RVA: 0x00AD5EA9 File Offset: 0x00AD40A9
		public TArray<bool> IsFadeEnd
		{
			get
			{
				base.FastCheckIsValid();
				TArray<bool> result;
				if ((result = this._IsFadeEnd) == null)
				{
					result = (this._IsFadeEnd = new TArray<bool>(base.NativePtr + (IntPtr)BP_SequenceData_Generated_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.IsFadeEnd.CopyAssign(value);
			}
		}

		// Token: 0x17007EDB RID: 32475
		// (get) Token: 0x0602E115 RID: 188693 RVA: 0x00AD5EB7 File Offset: 0x00AD40B7
		// (set) Token: 0x0602E116 RID: 188694 RVA: 0x00AD5ECB File Offset: 0x00AD40CB
		public unsafe FName BlendInTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceData_Generated_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceData_Generated_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007EDC RID: 32476
		// (get) Token: 0x0602E117 RID: 188695 RVA: 0x00AD5EE0 File Offset: 0x00AD40E0
		// (set) Token: 0x0602E118 RID: 188696 RVA: 0x00AD5F19 File Offset: 0x00AD4119
		public TArray<FName> BlendInTags
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._BlendInTags) == null)
				{
					result = (this._BlendInTags = new TArray<FName>(base.NativePtr + (IntPtr)BP_SequenceData_Generated_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				this.BlendInTags.CopyAssign(value);
			}
		}

		// Token: 0x17007EDD RID: 32477
		// (get) Token: 0x0602E119 RID: 188697 RVA: 0x00AD5F27 File Offset: 0x00AD4127
		// (set) Token: 0x0602E11A RID: 188698 RVA: 0x00AD5F3B File Offset: 0x00AD413B
		public unsafe FName BlendOutTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceData_Generated_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceData_Generated_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17007EDE RID: 32478
		// (get) Token: 0x0602E11B RID: 188699 RVA: 0x00AD5F50 File Offset: 0x00AD4150
		// (set) Token: 0x0602E11C RID: 188700 RVA: 0x00AD5F89 File Offset: 0x00AD4189
		public TArray<FName> BlendOutTags
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._BlendOutTags) == null)
				{
					result = (this._BlendOutTags = new TArray<FName>(base.NativePtr + (IntPtr)BP_SequenceData_Generated_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				this.BlendOutTags.CopyAssign(value);
			}
		}

		// Token: 0x17007EDF RID: 32479
		// (get) Token: 0x0602E11D RID: 188701 RVA: 0x00AD5F98 File Offset: 0x00AD4198
		// (set) Token: 0x0602E11E RID: 188702 RVA: 0x00AD5FD1 File Offset: 0x00AD41D1
		public TArray<string> PreloadUiArray
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._PreloadUiArray) == null)
				{
					result = (this._PreloadUiArray = new TArray<string>(base.NativePtr + (IntPtr)BP_SequenceData_Generated_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				this.PreloadUiArray.CopyAssign(value);
			}
		}

		// Token: 0x17007EE0 RID: 32480
		// (get) Token: 0x0602E11F RID: 188703 RVA: 0x00AD5FDF File Offset: 0x00AD41DF
		// (set) Token: 0x0602E120 RID: 188704 RVA: 0x00AD5FEF File Offset: 0x00AD41EF
		public unsafe bool IsCustomizedFinalPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceData_Generated_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceData_Generated_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007EE1 RID: 32481
		// (get) Token: 0x0602E121 RID: 188705 RVA: 0x00AD6000 File Offset: 0x00AD4200
		// (set) Token: 0x0602E122 RID: 188706 RVA: 0x00AD6015 File Offset: 0x00AD4215
		public TSoftClassPtr<AActor> MalePlayerBP
		{
			get
			{
				return new TSoftClassPtr<AActor>(base.NativePtr + (IntPtr)BP_SequenceData_Generated_C.__PropertyOffset_10, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_SequenceData_Generated_C.__PropertyOffset_10, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17007EE2 RID: 32482
		// (get) Token: 0x0602E123 RID: 188707 RVA: 0x00AD603A File Offset: 0x00AD423A
		// (set) Token: 0x0602E124 RID: 188708 RVA: 0x00AD604F File Offset: 0x00AD424F
		public TSoftClassPtr<AActor> FemalePlayerBP
		{
			get
			{
				return new TSoftClassPtr<AActor>(base.NativePtr + (IntPtr)BP_SequenceData_Generated_C.__PropertyOffset_11, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_SequenceData_Generated_C.__PropertyOffset_11, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17007EE3 RID: 32483
		// (get) Token: 0x0602E125 RID: 188709 RVA: 0x00AD6074 File Offset: 0x00AD4274
		// (set) Token: 0x0602E126 RID: 188710 RVA: 0x00AD6089 File Offset: 0x00AD4289
		public TSoftObjectPtr<USkeletalMesh> MaleMesh
		{
			get
			{
				return new TSoftObjectPtr<USkeletalMesh>(base.NativePtr + (IntPtr)BP_SequenceData_Generated_C.__PropertyOffset_12, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_SequenceData_Generated_C.__PropertyOffset_12, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17007EE4 RID: 32484
		// (get) Token: 0x0602E127 RID: 188711 RVA: 0x00AD60AE File Offset: 0x00AD42AE
		// (set) Token: 0x0602E128 RID: 188712 RVA: 0x00AD60C3 File Offset: 0x00AD42C3
		public TSoftObjectPtr<USkeletalMesh> FemaleMesh
		{
			get
			{
				return new TSoftObjectPtr<USkeletalMesh>(base.NativePtr + (IntPtr)BP_SequenceData_Generated_C.__PropertyOffset_13, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_SequenceData_Generated_C.__PropertyOffset_13, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17007EE5 RID: 32485
		// (get) Token: 0x0602E129 RID: 188713 RVA: 0x00AD60E8 File Offset: 0x00AD42E8
		// (set) Token: 0x0602E12A RID: 188714 RVA: 0x00AD6121 File Offset: 0x00AD4321
		public TArray<int> QteId
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._QteId) == null)
				{
					result = (this._QteId = new TArray<int>(base.NativePtr + (IntPtr)BP_SequenceData_Generated_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				this.QteId.CopyAssign(value);
			}
		}

		// Token: 0x17007EE6 RID: 32486
		// (get) Token: 0x0602E12B RID: 188715 RVA: 0x00AD6130 File Offset: 0x00AD4330
		// (set) Token: 0x0602E12C RID: 188716 RVA: 0x00AD6169 File Offset: 0x00AD4369
		public TArray<FSoftObjectPath> ActorRefs
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FSoftObjectPath> result;
				if ((result = this._ActorRefs) == null)
				{
					result = (this._ActorRefs = new TArray<FSoftObjectPath>(base.NativePtr + (IntPtr)BP_SequenceData_Generated_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				this.ActorRefs.CopyAssign(value);
			}
		}

		// Token: 0x0602E12D RID: 188717 RVA: 0x00AD6177 File Offset: 0x00AD4377
		protected BP_SequenceData_Generated_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401A092 RID: 106642
		public new const string __ObjectPath = "/Game/Aki/Sequence/Manager/BP_SequenceData_Generated.BP_SequenceData_Generated_C";

		// Token: 0x0401A093 RID: 106643
		private static IntPtr _ClassPtr;

		// Token: 0x0401A094 RID: 106644
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401A095 RID: 106645
		internal static int __PropertyOffset_0;

		// Token: 0x0401A096 RID: 106646
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SSequencesKeyFrames> _KeyFrames;

		// Token: 0x0401A097 RID: 106647
		internal static int __PropertyOffset_1;

		// Token: 0x0401A098 RID: 106648
		[Nullable(2)]
		private TArray<FTransform> _FinalPos;

		// Token: 0x0401A099 RID: 106649
		internal static int __PropertyOffset_2;

		// Token: 0x0401A09A RID: 106650
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TArray<TSubclassOf<AActor>> _BindingBP;

		// Token: 0x0401A09B RID: 106651
		internal static int __PropertyOffset_3;

		// Token: 0x0401A09C RID: 106652
		[Nullable(2)]
		private TArray<bool> _IsFadeEnd;

		// Token: 0x0401A09D RID: 106653
		internal static int __PropertyOffset_4;

		// Token: 0x0401A09E RID: 106654
		internal static int __PropertyOffset_5;

		// Token: 0x0401A09F RID: 106655
		[Nullable(2)]
		private TArray<FName> _BlendInTags;

		// Token: 0x0401A0A0 RID: 106656
		internal static int __PropertyOffset_6;

		// Token: 0x0401A0A1 RID: 106657
		internal static int __PropertyOffset_7;

		// Token: 0x0401A0A2 RID: 106658
		[Nullable(2)]
		private TArray<FName> _BlendOutTags;

		// Token: 0x0401A0A3 RID: 106659
		internal static int __PropertyOffset_8;

		// Token: 0x0401A0A4 RID: 106660
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _PreloadUiArray;

		// Token: 0x0401A0A5 RID: 106661
		internal static int __PropertyOffset_9;

		// Token: 0x0401A0A6 RID: 106662
		internal static int __PropertyOffset_10;

		// Token: 0x0401A0A7 RID: 106663
		internal static int __PropertyOffset_11;

		// Token: 0x0401A0A8 RID: 106664
		internal static int __PropertyOffset_12;

		// Token: 0x0401A0A9 RID: 106665
		internal static int __PropertyOffset_13;

		// Token: 0x0401A0AA RID: 106666
		internal static int __PropertyOffset_14;

		// Token: 0x0401A0AB RID: 106667
		[Nullable(2)]
		private TArray<int> _QteId;

		// Token: 0x0401A0AC RID: 106668
		internal static int __PropertyOffset_15;

		// Token: 0x0401A0AD RID: 106669
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FSoftObjectPath> _ActorRefs;
	}
}
