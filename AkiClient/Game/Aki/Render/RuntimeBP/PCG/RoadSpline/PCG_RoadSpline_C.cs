using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.PCG.RoadSpline.Structure;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.RoadSpline
{
	// Token: 0x02003B99 RID: 15257
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/PCG_RoadSpline.PCG_RoadSpline_C")]
	[UnrealStructLayout(1608, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1608)]
	public class PCG_RoadSpline_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021DA3 RID: 138659 RVA: 0x0095594E File Offset: 0x00953B4E
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PCG_RoadSpline_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/PCG_RoadSpline.PCG_RoadSpline_C");
			}
			return PCG_RoadSpline_C._ClassPtr;
		}

		// Token: 0x06021DA4 RID: 138660 RVA: 0x00955974 File Offset: 0x00953B74
		public PCG_RoadSpline_C() : this(BuiltinUtils.AllocNativeUObject(PCG_RoadSpline_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021DA5 RID: 138661 RVA: 0x0095599C File Offset: 0x00953B9C
		[NullableContext(1)]
		public PCG_RoadSpline_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PCG_RoadSpline_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003D5B RID: 15707
		// (get) Token: 0x06021DA6 RID: 138662 RVA: 0x009559D0 File Offset: 0x00953BD0
		// (set) Token: 0x06021DA7 RID: 138663 RVA: 0x00955A09 File Offset: 0x00953C09
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003D5C RID: 15708
		// (get) Token: 0x06021DA8 RID: 138664 RVA: 0x00955A2A File Offset: 0x00953C2A
		// (set) Token: 0x06021DA9 RID: 138665 RVA: 0x00955A3E File Offset: 0x00953C3E
		public unsafe UInstancedStaticMeshComponent InstancedStaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UInstancedStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003D5D RID: 15709
		// (get) Token: 0x06021DAA RID: 138666 RVA: 0x00955A53 File Offset: 0x00953C53
		// (set) Token: 0x06021DAB RID: 138667 RVA: 0x00955A67 File Offset: 0x00953C67
		public unsafe USplineComponent Spline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003D5E RID: 15710
		// (get) Token: 0x06021DAC RID: 138668 RVA: 0x00955A7C File Offset: 0x00953C7C
		// (set) Token: 0x06021DAD RID: 138669 RVA: 0x00955A90 File Offset: 0x00953C90
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003D5F RID: 15711
		// (get) Token: 0x06021DAE RID: 138670 RVA: 0x00955AA5 File Offset: 0x00953CA5
		// (set) Token: 0x06021DAF RID: 138671 RVA: 0x00955AB5 File Offset: 0x00953CB5
		public unsafe float 吸附偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003D60 RID: 15712
		// (get) Token: 0x06021DB0 RID: 138672 RVA: 0x00955AC6 File Offset: 0x00953CC6
		// (set) Token: 0x06021DB1 RID: 138673 RVA: 0x00955ADA File Offset: 0x00953CDA
		public unsafe AActor SplineActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003D61 RID: 15713
		// (get) Token: 0x06021DB2 RID: 138674 RVA: 0x00955AEF File Offset: 0x00953CEF
		// (set) Token: 0x06021DB3 RID: 138675 RVA: 0x00955AFF File Offset: 0x00953CFF
		public unsafe bool 启用
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003D62 RID: 15714
		// (get) Token: 0x06021DB4 RID: 138676 RVA: 0x00955B10 File Offset: 0x00953D10
		// (set) Token: 0x06021DB5 RID: 138677 RVA: 0x00955B20 File Offset: 0x00953D20
		public unsafe bool 低内存设备禁用
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003D63 RID: 15715
		// (get) Token: 0x06021DB6 RID: 138678 RVA: 0x00955B31 File Offset: 0x00953D31
		// (set) Token: 0x06021DB7 RID: 138679 RVA: 0x00955B41 File Offset: 0x00953D41
		public unsafe bool 开启投影
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003D64 RID: 15716
		// (get) Token: 0x06021DB8 RID: 138680 RVA: 0x00955B52 File Offset: 0x00953D52
		// (set) Token: 0x06021DB9 RID: 138681 RVA: 0x00955B62 File Offset: 0x00953D62
		public unsafe bool 开启自定义深度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003D65 RID: 15717
		// (get) Token: 0x06021DBA RID: 138682 RVA: 0x00955B74 File Offset: 0x00953D74
		// (set) Token: 0x06021DBB RID: 138683 RVA: 0x00955BAD File Offset: 0x00953DAD
		[Nullable(1)]
		public FCollisionProfileName 添加碰撞__测试_
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FCollisionProfileName result;
				if ((result = this._添加碰撞__测试_) == null)
				{
					result = (this._添加碰撞__测试_ = new FCollisionProfileName(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_10, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FCollisionProfileName.StaticStruct(), base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003D66 RID: 15718
		// (get) Token: 0x06021DBC RID: 138684 RVA: 0x00955BCE File Offset: 0x00953DCE
		// (set) Token: 0x06021DBD RID: 138685 RVA: 0x00955BE2 File Offset: 0x00953DE2
		public unsafe FVector UpDirection__测试_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003D67 RID: 15719
		// (get) Token: 0x06021DBE RID: 138686 RVA: 0x00955BF7 File Offset: 0x00953DF7
		// (set) Token: 0x06021DBF RID: 138687 RVA: 0x00955C07 File Offset: 0x00953E07
		public unsafe bool 顶点旋转同步
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003D68 RID: 15720
		// (get) Token: 0x06021DC0 RID: 138688 RVA: 0x00955C18 File Offset: 0x00953E18
		// (set) Token: 0x06021DC1 RID: 138689 RVA: 0x00955C51 File Offset: 0x00953E51
		[Nullable(1)]
		public SPCG_RoadPropertyBased 属性列表
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				SPCG_RoadPropertyBased result;
				if ((result = this._属性列表) == null)
				{
					result = (this._属性列表 = new SPCG_RoadPropertyBased(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_13, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SPCG_RoadPropertyBased.StaticStruct(), base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003D69 RID: 15721
		// (get) Token: 0x06021DC2 RID: 138690 RVA: 0x00955C72 File Offset: 0x00953E72
		// (set) Token: 0x06021DC3 RID: 138691 RVA: 0x00955C86 File Offset: 0x00953E86
		public unsafe UStaticMesh 封口模型
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17003D6A RID: 15722
		// (get) Token: 0x06021DC4 RID: 138692 RVA: 0x00955C9B File Offset: 0x00953E9B
		// (set) Token: 0x06021DC5 RID: 138693 RVA: 0x00955CAF File Offset: 0x00953EAF
		public unsafe FVector 封口偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17003D6B RID: 15723
		// (get) Token: 0x06021DC6 RID: 138694 RVA: 0x00955CC4 File Offset: 0x00953EC4
		// (set) Token: 0x06021DC7 RID: 138695 RVA: 0x00955CD4 File Offset: 0x00953ED4
		public unsafe float 封口旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17003D6C RID: 15724
		// (get) Token: 0x06021DC8 RID: 138696 RVA: 0x00955CE5 File Offset: 0x00953EE5
		// (set) Token: 0x06021DC9 RID: 138697 RVA: 0x00955CF5 File Offset: 0x00953EF5
		public unsafe bool VertexCompress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003D6D RID: 15725
		// (get) Token: 0x06021DCA RID: 138698 RVA: 0x00955D06 File Offset: 0x00953F06
		// (set) Token: 0x06021DCB RID: 138699 RVA: 0x00955D1A File Offset: 0x00953F1A
		public unsafe ASkeletalMeshActor 骨骼动画对象
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ASkeletalMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17003D6E RID: 15726
		// (get) Token: 0x06021DCC RID: 138700 RVA: 0x00955D2F File Offset: 0x00953F2F
		// (set) Token: 0x06021DCD RID: 138701 RVA: 0x00955D43 File Offset: 0x00953F43
		public unsafe ALevelSequenceActor 序列帧对象
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ALevelSequenceActor>(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x17003D6F RID: 15727
		// (get) Token: 0x06021DCE RID: 138702 RVA: 0x00955D58 File Offset: 0x00953F58
		// (set) Token: 0x06021DCF RID: 138703 RVA: 0x00955D68 File Offset: 0x00953F68
		public unsafe float 动画帧数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17003D70 RID: 15728
		// (get) Token: 0x06021DD0 RID: 138704 RVA: 0x00955D79 File Offset: 0x00953F79
		// (set) Token: 0x06021DD1 RID: 138705 RVA: 0x00955D8D File Offset: 0x00953F8D
		public unsafe FName 骨骼名称
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17003D71 RID: 15729
		// (get) Token: 0x06021DD2 RID: 138706 RVA: 0x00955DA2 File Offset: 0x00953FA2
		// (set) Token: 0x06021DD3 RID: 138707 RVA: 0x00955DB2 File Offset: 0x00953FB2
		public unsafe bool Tick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003D72 RID: 15730
		// (get) Token: 0x06021DD4 RID: 138708 RVA: 0x00955DC3 File Offset: 0x00953FC3
		// (set) Token: 0x06021DD5 RID: 138709 RVA: 0x00955DD3 File Offset: 0x00953FD3
		public unsafe float Frame
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17003D73 RID: 15731
		// (get) Token: 0x06021DD6 RID: 138710 RVA: 0x00955DE4 File Offset: 0x00953FE4
		// (set) Token: 0x06021DD7 RID: 138711 RVA: 0x00955DF8 File Offset: 0x00953FF8
		public unsafe FVectorDouble LastPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17003D74 RID: 15732
		// (get) Token: 0x06021DD8 RID: 138712 RVA: 0x00955E0D File Offset: 0x0095400D
		// (set) Token: 0x06021DD9 RID: 138713 RVA: 0x00955E1D File Offset: 0x0095401D
		public unsafe float 最小采样距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17003D75 RID: 15733
		// (get) Token: 0x06021DDA RID: 138714 RVA: 0x00955E2E File Offset: 0x0095402E
		// (set) Token: 0x06021DDB RID: 138715 RVA: 0x00955E3E File Offset: 0x0095403E
		public unsafe bool IsSequence
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_26) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_26) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003D76 RID: 15734
		// (get) Token: 0x06021DDC RID: 138716 RVA: 0x00955E4F File Offset: 0x0095404F
		// (set) Token: 0x06021DDD RID: 138717 RVA: 0x00955E63 File Offset: 0x00954063
		public unsafe ULevelSequencePlayer Sequence_Player
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ULevelSequencePlayer>(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x17003D77 RID: 15735
		// (get) Token: 0x06021DDE RID: 138718 RVA: 0x00955E78 File Offset: 0x00954078
		// (set) Token: 0x06021DDF RID: 138719 RVA: 0x00955E8C File Offset: 0x0095408C
		public unsafe FVectorDouble FirstPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17003D78 RID: 15736
		// (get) Token: 0x06021DE0 RID: 138720 RVA: 0x00955EA1 File Offset: 0x009540A1
		// (set) Token: 0x06021DE1 RID: 138721 RVA: 0x00955EB1 File Offset: 0x009540B1
		public unsafe int 基于分段数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17003D79 RID: 15737
		// (get) Token: 0x06021DE2 RID: 138722 RVA: 0x00955EC2 File Offset: 0x009540C2
		// (set) Token: 0x06021DE3 RID: 138723 RVA: 0x00955ED2 File Offset: 0x009540D2
		public unsafe float 基于分段长度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x06021DE4 RID: 138724 RVA: 0x00955EE3 File Offset: 0x009540E3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 追踪动画轨迹()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PCG_RoadSpline_C.__追踪动画轨迹_NativeFunctionPtr, null);
		}

		// Token: 0x06021DE5 RID: 138725 RVA: 0x00955EF8 File Offset: 0x009540F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetRoadWidth(bool IgnoreScale, ref float Width)
		{
			PCG_RoadSpline_C.__GetRoadWidth_FunctionParams* ptr = stackalloc PCG_RoadSpline_C.__GetRoadWidth_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(PCG_RoadSpline_C.__GetRoadWidth_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PCG_RoadSpline_C.__GetRoadWidth_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IgnoreScale = IgnoreScale;
			ptr->Width = Width;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PCG_RoadSpline_C.__GetRoadWidth_NativeFunctionPtr, (void*)ptr);
			Width = ptr->Width;
		}

		// Token: 0x06021DE6 RID: 138726 RVA: 0x00955F50 File Offset: 0x00954150
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetRoadMesh(ref UStaticMesh 基础模型)
		{
			PCG_RoadSpline_C.__GetRoadMesh_FunctionParams* ptr = stackalloc PCG_RoadSpline_C.__GetRoadMesh_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(PCG_RoadSpline_C.__GetRoadMesh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PCG_RoadSpline_C.__GetRoadMesh_NativeFunctionPtr, (void*)ptr, 1);
			ref PCG_RoadSpline_C.__GetRoadMesh_FunctionParams ptr2 = ref *ptr;
			UStaticMesh ustaticMesh = 基础模型;
			ptr2.基础模型 = ((ustaticMesh != null) ? ustaticMesh.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PCG_RoadSpline_C.__GetRoadMesh_NativeFunctionPtr, (void*)ptr);
			基础模型 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UStaticMesh>(ptr->基础模型);
		}

		// Token: 0x06021DE7 RID: 138727 RVA: 0x00955FB4 File Offset: 0x009541B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CopyToSplineActor()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PCG_RoadSpline_C.__CopyToSplineActor_NativeFunctionPtr, null);
		}

		// Token: 0x06021DE8 RID: 138728 RVA: 0x00955FC8 File Offset: 0x009541C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CopySplineActor()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PCG_RoadSpline_C.__CopySplineActor_NativeFunctionPtr, null);
		}

		// Token: 0x06021DE9 RID: 138729 RVA: 0x00955FDC File Offset: 0x009541DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 向下吸附到地形()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PCG_RoadSpline_C.__向下吸附到地形_NativeFunctionPtr, null);
		}

		// Token: 0x06021DEA RID: 138730 RVA: 0x00955FF0 File Offset: 0x009541F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void GenerateEndCaps()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PCG_RoadSpline_C.__GenerateEndCaps_NativeFunctionPtr, null);
		}

		// Token: 0x06021DEB RID: 138731 RVA: 0x00956004 File Offset: 0x00954204
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GenerateMesh(bool ByPoint)
		{
			PCG_RoadSpline_C.__GenerateMesh_FunctionParams* ptr = stackalloc PCG_RoadSpline_C.__GenerateMesh_FunctionParams[(UIntPtr)959] + 15L / (long)sizeof(PCG_RoadSpline_C.__GenerateMesh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PCG_RoadSpline_C.__GenerateMesh_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ByPoint = ByPoint;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PCG_RoadSpline_C.__GenerateMesh_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021DEC RID: 138732 RVA: 0x0095604D File Offset: 0x0095424D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PCG_RoadSpline_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021DED RID: 138733 RVA: 0x00956061 File Offset: 0x00954261
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, PCG_RoadSpline_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021DEE RID: 138734 RVA: 0x00956078 File Offset: 0x00954278
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			PCG_RoadSpline_C.__EditorTick_FunctionParams* ptr = stackalloc PCG_RoadSpline_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(PCG_RoadSpline_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PCG_RoadSpline_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PCG_RoadSpline_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021DEF RID: 138735 RVA: 0x009560C0 File Offset: 0x009542C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			PCG_RoadSpline_C.__EditorTick_FunctionParams* ptr = stackalloc PCG_RoadSpline_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(PCG_RoadSpline_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PCG_RoadSpline_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, PCG_RoadSpline_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021DF0 RID: 138736 RVA: 0x00956108 File Offset: 0x00954308
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_PCG_RoadSpline(int EntryPoint)
		{
			PCG_RoadSpline_C.__ExecuteUbergraph_PCG_RoadSpline_FunctionParams* ptr = stackalloc PCG_RoadSpline_C.__ExecuteUbergraph_PCG_RoadSpline_FunctionParams[(UIntPtr)215] + 15L / (long)sizeof(PCG_RoadSpline_C.__ExecuteUbergraph_PCG_RoadSpline_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PCG_RoadSpline_C.__ExecuteUbergraph_PCG_RoadSpline_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, PCG_RoadSpline_C.__ExecuteUbergraph_PCG_RoadSpline_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021DF1 RID: 138737 RVA: 0x00956152 File Offset: 0x00954352
		protected PCG_RoadSpline_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011167 RID: 69991
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/PCG_RoadSpline.PCG_RoadSpline_C";

		// Token: 0x04011168 RID: 69992
		private static IntPtr _ClassPtr;

		// Token: 0x04011169 RID: 69993
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401116A RID: 69994
		internal static int __PropertyOffset_0;

		// Token: 0x0401116B RID: 69995
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401116C RID: 69996
		internal static int __PropertyOffset_1;

		// Token: 0x0401116D RID: 69997
		internal static int __PropertyOffset_2;

		// Token: 0x0401116E RID: 69998
		internal static int __PropertyOffset_3;

		// Token: 0x0401116F RID: 69999
		internal static int __PropertyOffset_4;

		// Token: 0x04011170 RID: 70000
		internal static int __PropertyOffset_5;

		// Token: 0x04011171 RID: 70001
		internal static int __PropertyOffset_6;

		// Token: 0x04011172 RID: 70002
		internal static int __PropertyOffset_7;

		// Token: 0x04011173 RID: 70003
		internal static int __PropertyOffset_8;

		// Token: 0x04011174 RID: 70004
		internal static int __PropertyOffset_9;

		// Token: 0x04011175 RID: 70005
		internal static int __PropertyOffset_10;

		// Token: 0x04011176 RID: 70006
		private FCollisionProfileName _添加碰撞__测试_;

		// Token: 0x04011177 RID: 70007
		internal static int __PropertyOffset_11;

		// Token: 0x04011178 RID: 70008
		internal static int __PropertyOffset_12;

		// Token: 0x04011179 RID: 70009
		internal static int __PropertyOffset_13;

		// Token: 0x0401117A RID: 70010
		private SPCG_RoadPropertyBased _属性列表;

		// Token: 0x0401117B RID: 70011
		internal static int __PropertyOffset_14;

		// Token: 0x0401117C RID: 70012
		internal static int __PropertyOffset_15;

		// Token: 0x0401117D RID: 70013
		internal static int __PropertyOffset_16;

		// Token: 0x0401117E RID: 70014
		internal static int __PropertyOffset_17;

		// Token: 0x0401117F RID: 70015
		internal static int __PropertyOffset_18;

		// Token: 0x04011180 RID: 70016
		internal static int __PropertyOffset_19;

		// Token: 0x04011181 RID: 70017
		internal static int __PropertyOffset_20;

		// Token: 0x04011182 RID: 70018
		internal static int __PropertyOffset_21;

		// Token: 0x04011183 RID: 70019
		internal static int __PropertyOffset_22;

		// Token: 0x04011184 RID: 70020
		internal static int __PropertyOffset_23;

		// Token: 0x04011185 RID: 70021
		internal static int __PropertyOffset_24;

		// Token: 0x04011186 RID: 70022
		internal static int __PropertyOffset_25;

		// Token: 0x04011187 RID: 70023
		internal static int __PropertyOffset_26;

		// Token: 0x04011188 RID: 70024
		internal static int __PropertyOffset_27;

		// Token: 0x04011189 RID: 70025
		internal static int __PropertyOffset_28;

		// Token: 0x0401118A RID: 70026
		internal static int __PropertyOffset_29;

		// Token: 0x0401118B RID: 70027
		internal static int __PropertyOffset_30;

		// Token: 0x0401118C RID: 70028
		private static IntPtr __追踪动画轨迹_NativeFunctionPtr;

		// Token: 0x0401118D RID: 70029
		private static IntPtr __GetRoadWidth_NativeFunctionPtr;

		// Token: 0x0401118E RID: 70030
		private static IntPtr __GetRoadMesh_NativeFunctionPtr;

		// Token: 0x0401118F RID: 70031
		private static IntPtr __CopyToSplineActor_NativeFunctionPtr;

		// Token: 0x04011190 RID: 70032
		private static IntPtr __CopySplineActor_NativeFunctionPtr;

		// Token: 0x04011191 RID: 70033
		private static IntPtr __向下吸附到地形_NativeFunctionPtr;

		// Token: 0x04011192 RID: 70034
		private static IntPtr __GenerateEndCaps_NativeFunctionPtr;

		// Token: 0x04011193 RID: 70035
		private static IntPtr __GenerateMesh_NativeFunctionPtr;

		// Token: 0x04011194 RID: 70036
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011195 RID: 70037
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04011196 RID: 70038
		private static IntPtr __ExecuteUbergraph_PCG_RoadSpline_NativeFunctionPtr;

		// Token: 0x02009B66 RID: 39782
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __GetRoadWidth_FunctionParams
		{
			// Token: 0x04032357 RID: 205655
			[FieldOffset(0)]
			public bool IgnoreScale;

			// Token: 0x04032358 RID: 205656
			[FieldOffset(4)]
			public float Width;
		}

		// Token: 0x02009B67 RID: 39783
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __GetRoadMesh_FunctionParams
		{
			// Token: 0x04032359 RID: 205657
			[FieldOffset(0)]
			public IntPtr 基础模型;
		}

		// Token: 0x02009B68 RID: 39784
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 944)]
		protected ref struct __GenerateMesh_FunctionParams
		{
			// Token: 0x0403235A RID: 205658
			[FieldOffset(0)]
			public bool ByPoint;
		}

		// Token: 0x02009B69 RID: 39785
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x0403235B RID: 205659
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B6A RID: 39786
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 200)]
		protected ref struct __ExecuteUbergraph_PCG_RoadSpline_FunctionParams
		{
			// Token: 0x0403235C RID: 205660
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
