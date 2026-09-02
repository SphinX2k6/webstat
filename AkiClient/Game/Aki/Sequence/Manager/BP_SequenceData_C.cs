using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Sequence.Manager
{
	// Token: 0x020043A6 RID: 17318
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Sequence/Manager/BP_SequenceData.BP_SequenceData_C")]
	[UnrealStructLayout(368, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 368)]
	public class BP_SequenceData_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602E0C8 RID: 188616 RVA: 0x00AD57EC File Offset: 0x00AD39EC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SequenceData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Sequence/Manager/BP_SequenceData.BP_SequenceData_C");
			}
			return BP_SequenceData_C._ClassPtr;
		}

		// Token: 0x0602E0C9 RID: 188617 RVA: 0x00AD5810 File Offset: 0x00AD3A10
		public BP_SequenceData_C() : this(BuiltinUtils.AllocNativeUObject(BP_SequenceData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602E0CA RID: 188618 RVA: 0x00AD5838 File Offset: 0x00AD3A38
		public BP_SequenceData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SequenceData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007EB8 RID: 32440
		// (get) Token: 0x0602E0CB RID: 188619 RVA: 0x00AD586B File Offset: 0x00AD3A6B
		// (set) Token: 0x0602E0CC RID: 188620 RVA: 0x00AD587F File Offset: 0x00AD3A7F
		[Nullable(0)]
		public unsafe TEnumAsByte<EPlotSequenceType> 类型
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_0);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007EB9 RID: 32441
		// (get) Token: 0x0602E0CD RID: 188621 RVA: 0x00AD5894 File Offset: 0x00AD3A94
		// (set) Token: 0x0602E0CE RID: 188622 RVA: 0x00AD58CD File Offset: 0x00AD3ACD
		public TArray<ULevelSequence> 剧情资源
		{
			get
			{
				base.FastCheckIsValid();
				TArray<ULevelSequence> result;
				if ((result = this._剧情资源) == null)
				{
					result = (this._剧情资源 = new TArray<ULevelSequence>(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.剧情资源.CopyAssign(value);
			}
		}

		// Token: 0x17007EBA RID: 32442
		// (get) Token: 0x0602E0CF RID: 188623 RVA: 0x00AD58DB File Offset: 0x00AD3ADB
		// (set) Token: 0x0602E0D0 RID: 188624 RVA: 0x00AD58EF File Offset: 0x00AD3AEF
		public unsafe string 文本资源ID
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_SequenceData_C.__PropertyOffset_2)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_SequenceData_C.__PropertyOffset_2)), value);
			}
		}

		// Token: 0x17007EBB RID: 32443
		// (get) Token: 0x0602E0D1 RID: 188625 RVA: 0x00AD5904 File Offset: 0x00AD3B04
		// (set) Token: 0x0602E0D2 RID: 188626 RVA: 0x00AD593D File Offset: 0x00AD3B3D
		public TArray<FName> 绑定角色标签
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._绑定角色标签) == null)
				{
					result = (this._绑定角色标签 = new TArray<FName>(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.绑定角色标签.CopyAssign(value);
			}
		}

		// Token: 0x17007EBC RID: 32444
		// (get) Token: 0x0602E0D3 RID: 188627 RVA: 0x00AD594B File Offset: 0x00AD3B4B
		// (set) Token: 0x0602E0D4 RID: 188628 RVA: 0x00AD595F File Offset: 0x00AD3B5F
		public unsafe string 绑定起始点标签
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_SequenceData_C.__PropertyOffset_4)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_SequenceData_C.__PropertyOffset_4)), value);
			}
		}

		// Token: 0x17007EBD RID: 32445
		// (get) Token: 0x0602E0D5 RID: 188629 RVA: 0x00AD5974 File Offset: 0x00AD3B74
		// (set) Token: 0x0602E0D6 RID: 188630 RVA: 0x00AD5984 File Offset: 0x00AD3B84
		public unsafe bool 是否固定起始点
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007EBE RID: 32446
		// (get) Token: 0x0602E0D7 RID: 188631 RVA: 0x00AD5995 File Offset: 0x00AD3B95
		// (set) Token: 0x0602E0D8 RID: 188632 RVA: 0x00AD59A5 File Offset: 0x00AD3BA5
		public unsafe bool NeedSwitchMainCharacter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007EBF RID: 32447
		// (get) Token: 0x0602E0D9 RID: 188633 RVA: 0x00AD59B6 File Offset: 0x00AD3BB6
		// (set) Token: 0x0602E0DA RID: 188634 RVA: 0x00AD59C6 File Offset: 0x00AD3BC6
		public unsafe bool IsTransformOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007EC0 RID: 32448
		// (get) Token: 0x0602E0DB RID: 188635 RVA: 0x00AD59D7 File Offset: 0x00AD3BD7
		// (set) Token: 0x0602E0DC RID: 188636 RVA: 0x00AD59EB File Offset: 0x00AD3BEB
		public unsafe FTransform OverrideTransform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17007EC1 RID: 32449
		// (get) Token: 0x0602E0DD RID: 188637 RVA: 0x00AD5A00 File Offset: 0x00AD3C00
		// (set) Token: 0x0602E0DE RID: 188638 RVA: 0x00AD5A10 File Offset: 0x00AD3C10
		public unsafe float AnimationBlendInTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17007EC2 RID: 32450
		// (get) Token: 0x0602E0DF RID: 188639 RVA: 0x00AD5A21 File Offset: 0x00AD3C21
		// (set) Token: 0x0602E0E0 RID: 188640 RVA: 0x00AD5A31 File Offset: 0x00AD3C31
		public unsafe float AnimationBlendOutTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17007EC3 RID: 32451
		// (get) Token: 0x0602E0E1 RID: 188641 RVA: 0x00AD5A42 File Offset: 0x00AD3C42
		// (set) Token: 0x0602E0E2 RID: 188642 RVA: 0x00AD5A52 File Offset: 0x00AD3C52
		public unsafe float CameraBlendInTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17007EC4 RID: 32452
		// (get) Token: 0x0602E0E3 RID: 188643 RVA: 0x00AD5A63 File Offset: 0x00AD3C63
		// (set) Token: 0x0602E0E4 RID: 188644 RVA: 0x00AD5A73 File Offset: 0x00AD3C73
		public unsafe float CameraBlendOutTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17007EC5 RID: 32453
		// (get) Token: 0x0602E0E5 RID: 188645 RVA: 0x00AD5A84 File Offset: 0x00AD3C84
		// (set) Token: 0x0602E0E6 RID: 188646 RVA: 0x00AD5A94 File Offset: 0x00AD3C94
		public unsafe bool MovementSync
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007EC6 RID: 32454
		// (get) Token: 0x0602E0E7 RID: 188647 RVA: 0x00AD5AA5 File Offset: 0x00AD3CA5
		// (set) Token: 0x0602E0E8 RID: 188648 RVA: 0x00AD5AB5 File Offset: 0x00AD3CB5
		public unsafe bool SaveFinalTransform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007EC7 RID: 32455
		// (get) Token: 0x0602E0E9 RID: 188649 RVA: 0x00AD5AC6 File Offset: 0x00AD3CC6
		// (set) Token: 0x0602E0EA RID: 188650 RVA: 0x00AD5AD6 File Offset: 0x00AD3CD6
		public unsafe bool 标识为演出制作中
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007EC8 RID: 32456
		// (get) Token: 0x0602E0EB RID: 188651 RVA: 0x00AD5AE7 File Offset: 0x00AD3CE7
		// (set) Token: 0x0602E0EC RID: 188652 RVA: 0x00AD5AF7 File Offset: 0x00AD3CF7
		public unsafe bool HidePlayer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007EC9 RID: 32457
		// (get) Token: 0x0602E0ED RID: 188653 RVA: 0x00AD5B08 File Offset: 0x00AD3D08
		// (set) Token: 0x0602E0EE RID: 188654 RVA: 0x00AD5B1C File Offset: 0x00AD3D1C
		[Nullable(2)]
		public unsafe BP_SequenceData_Generated_C GeneratedData
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_SequenceData_Generated_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceData_C.__PropertyOffset_17);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceData_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17007ECA RID: 32458
		// (get) Token: 0x0602E0EF RID: 188655 RVA: 0x00AD5B31 File Offset: 0x00AD3D31
		// (set) Token: 0x0602E0F0 RID: 188656 RVA: 0x00AD5B41 File Offset: 0x00AD3D41
		public unsafe int 葫芦状态
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17007ECB RID: 32459
		// (get) Token: 0x0602E0F1 RID: 188657 RVA: 0x00AD5B52 File Offset: 0x00AD3D52
		// (set) Token: 0x0602E0F2 RID: 188658 RVA: 0x00AD5B66 File Offset: 0x00AD3D66
		public unsafe string GraphName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_SequenceData_C.__PropertyOffset_19)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_SequenceData_C.__PropertyOffset_19)), value);
			}
		}

		// Token: 0x17007ECC RID: 32460
		// (get) Token: 0x0602E0F3 RID: 188659 RVA: 0x00AD5B7B File Offset: 0x00AD3D7B
		// (set) Token: 0x0602E0F4 RID: 188660 RVA: 0x00AD5B8B File Offset: 0x00AD3D8B
		public unsafe bool bIsForceFinalTrans
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007ECD RID: 32461
		// (get) Token: 0x0602E0F5 RID: 188661 RVA: 0x00AD5B9C File Offset: 0x00AD3D9C
		// (set) Token: 0x0602E0F6 RID: 188662 RVA: 0x00AD5BAC File Offset: 0x00AD3DAC
		public unsafe bool CollectExtraTexture
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007ECE RID: 32462
		// (get) Token: 0x0602E0F7 RID: 188663 RVA: 0x00AD5BBD File Offset: 0x00AD3DBD
		// (set) Token: 0x0602E0F8 RID: 188664 RVA: 0x00AD5BCD File Offset: 0x00AD3DCD
		public unsafe float 相机过渡时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17007ECF RID: 32463
		// (get) Token: 0x0602E0F9 RID: 188665 RVA: 0x00AD5BDE File Offset: 0x00AD3DDE
		// (set) Token: 0x0602E0FA RID: 188666 RVA: 0x00AD5BEE File Offset: 0x00AD3DEE
		public unsafe bool 约束宽高比
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007ED0 RID: 32464
		// (get) Token: 0x0602E0FB RID: 188667 RVA: 0x00AD5BFF File Offset: 0x00AD3DFF
		// (set) Token: 0x0602E0FC RID: 188668 RVA: 0x00AD5C0F File Offset: 0x00AD3E0F
		public unsafe bool IsEnableDynamicStreamingSource
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007ED1 RID: 32465
		// (get) Token: 0x0602E0FD RID: 188669 RVA: 0x00AD5C20 File Offset: 0x00AD3E20
		// (set) Token: 0x0602E0FE RID: 188670 RVA: 0x00AD5C30 File Offset: 0x00AD3E30
		public unsafe bool 使用UI黑边
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_25) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_25) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007ED2 RID: 32466
		// (get) Token: 0x0602E0FF RID: 188671 RVA: 0x00AD5C41 File Offset: 0x00AD3E41
		// (set) Token: 0x0602E100 RID: 188672 RVA: 0x00AD5C51 File Offset: 0x00AD3E51
		public unsafe bool EnableStartTransformBlend
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_26) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_26) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007ED3 RID: 32467
		// (get) Token: 0x0602E101 RID: 188673 RVA: 0x00AD5C62 File Offset: 0x00AD3E62
		// (set) Token: 0x0602E102 RID: 188674 RVA: 0x00AD5C72 File Offset: 0x00AD3E72
		public unsafe float StartTransformBlendTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17007ED4 RID: 32468
		// (get) Token: 0x0602E103 RID: 188675 RVA: 0x00AD5C83 File Offset: 0x00AD3E83
		// (set) Token: 0x0602E104 RID: 188676 RVA: 0x00AD5C93 File Offset: 0x00AD3E93
		public unsafe bool 混入到相机首帧
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007ED5 RID: 32469
		// (get) Token: 0x0602E105 RID: 188677 RVA: 0x00AD5CA4 File Offset: 0x00AD3EA4
		// (set) Token: 0x0602E106 RID: 188678 RVA: 0x00AD5CB4 File Offset: 0x00AD3EB4
		public unsafe bool IsForceStreamSceneActor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_29) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_29) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007ED6 RID: 32470
		// (get) Token: 0x0602E107 RID: 188679 RVA: 0x00AD5CC8 File Offset: 0x00AD3EC8
		// (set) Token: 0x0602E108 RID: 188680 RVA: 0x00AD5D01 File Offset: 0x00AD3F01
		public TMap<int, FName> 实体说话人ID
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, FName> result;
				if ((result = this._实体说话人ID) == null)
				{
					result = (this._实体说话人ID = new TMap<int, FName>(base.NativePtr + (IntPtr)BP_SequenceData_C.__PropertyOffset_30, this));
				}
				return result;
			}
			set
			{
				this.实体说话人ID.CopyAssign(value);
			}
		}

		// Token: 0x0602E109 RID: 188681 RVA: 0x00AD5D0F File Offset: 0x00AD3F0F
		protected BP_SequenceData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401A06D RID: 106605
		public new const string __ObjectPath = "/Game/Aki/Sequence/Manager/BP_SequenceData.BP_SequenceData_C";

		// Token: 0x0401A06E RID: 106606
		private static IntPtr _ClassPtr;

		// Token: 0x0401A06F RID: 106607
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401A070 RID: 106608
		internal static int __PropertyOffset_0;

		// Token: 0x0401A071 RID: 106609
		internal static int __PropertyOffset_1;

		// Token: 0x0401A072 RID: 106610
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<ULevelSequence> _剧情资源;

		// Token: 0x0401A073 RID: 106611
		internal static int __PropertyOffset_2;

		// Token: 0x0401A074 RID: 106612
		internal static int __PropertyOffset_3;

		// Token: 0x0401A075 RID: 106613
		[Nullable(2)]
		private TArray<FName> _绑定角色标签;

		// Token: 0x0401A076 RID: 106614
		internal static int __PropertyOffset_4;

		// Token: 0x0401A077 RID: 106615
		internal static int __PropertyOffset_5;

		// Token: 0x0401A078 RID: 106616
		internal static int __PropertyOffset_6;

		// Token: 0x0401A079 RID: 106617
		internal static int __PropertyOffset_7;

		// Token: 0x0401A07A RID: 106618
		internal static int __PropertyOffset_8;

		// Token: 0x0401A07B RID: 106619
		internal static int __PropertyOffset_9;

		// Token: 0x0401A07C RID: 106620
		internal static int __PropertyOffset_10;

		// Token: 0x0401A07D RID: 106621
		internal static int __PropertyOffset_11;

		// Token: 0x0401A07E RID: 106622
		internal static int __PropertyOffset_12;

		// Token: 0x0401A07F RID: 106623
		internal static int __PropertyOffset_13;

		// Token: 0x0401A080 RID: 106624
		internal static int __PropertyOffset_14;

		// Token: 0x0401A081 RID: 106625
		internal static int __PropertyOffset_15;

		// Token: 0x0401A082 RID: 106626
		internal static int __PropertyOffset_16;

		// Token: 0x0401A083 RID: 106627
		internal static int __PropertyOffset_17;

		// Token: 0x0401A084 RID: 106628
		internal static int __PropertyOffset_18;

		// Token: 0x0401A085 RID: 106629
		internal static int __PropertyOffset_19;

		// Token: 0x0401A086 RID: 106630
		internal static int __PropertyOffset_20;

		// Token: 0x0401A087 RID: 106631
		internal static int __PropertyOffset_21;

		// Token: 0x0401A088 RID: 106632
		internal static int __PropertyOffset_22;

		// Token: 0x0401A089 RID: 106633
		internal static int __PropertyOffset_23;

		// Token: 0x0401A08A RID: 106634
		internal static int __PropertyOffset_24;

		// Token: 0x0401A08B RID: 106635
		internal static int __PropertyOffset_25;

		// Token: 0x0401A08C RID: 106636
		internal static int __PropertyOffset_26;

		// Token: 0x0401A08D RID: 106637
		internal static int __PropertyOffset_27;

		// Token: 0x0401A08E RID: 106638
		internal static int __PropertyOffset_28;

		// Token: 0x0401A08F RID: 106639
		internal static int __PropertyOffset_29;

		// Token: 0x0401A090 RID: 106640
		internal static int __PropertyOffset_30;

		// Token: 0x0401A091 RID: 106641
		[Nullable(2)]
		private TMap<int, FName> _实体说话人ID;
	}
}
