using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common
{
	// Token: 0x02003FF6 RID: 16374
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/ABP_BaseRole_bakup.ABP_BaseRole_bakup_C")]
	[UnrealStructLayout(4480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 4472)]
	public class ABP_BaseRole_bakup_C : UKuroAnimInstanceRole, IUnrealUObject, IUnrealObject, IBPI_Animation_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x060296E4 RID: 169700 RVA: 0x00A2DFC7 File Offset: 0x00A2C1C7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_BaseRole_bakup_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/ABP_BaseRole_bakup.ABP_BaseRole_bakup_C");
			}
			return ABP_BaseRole_bakup_C._ClassPtr;
		}

		// Token: 0x060296E5 RID: 169701 RVA: 0x00A2DFEC File Offset: 0x00A2C1EC
		public ABP_BaseRole_bakup_C() : this(BuiltinUtils.AllocNativeUObject(ABP_BaseRole_bakup_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060296E6 RID: 169702 RVA: 0x00A2E014 File Offset: 0x00A2C214
		[NullableContext(1)]
		public ABP_BaseRole_bakup_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_BaseRole_bakup_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700670A RID: 26378
		// (get) Token: 0x060296E7 RID: 169703 RVA: 0x00A2E048 File Offset: 0x00A2C248
		// (set) Token: 0x060296E8 RID: 169704 RVA: 0x00A2E081 File Offset: 0x00A2C281
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700670B RID: 26379
		// (get) Token: 0x060296E9 RID: 169705 RVA: 0x00A2E0A4 File Offset: 0x00A2C2A4
		// (set) Token: 0x060296EA RID: 169706 RVA: 0x00A2E0DD File Offset: 0x00A2C2DD
		[Nullable(1)]
		public FAnimNode_Root AnimGraphNode_Root
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_1, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700670C RID: 26380
		// (get) Token: 0x060296EB RID: 169707 RVA: 0x00A2E0FE File Offset: 0x00A2C2FE
		// (set) Token: 0x060296EC RID: 169708 RVA: 0x00A2E112 File Offset: 0x00A2C312
		[Nullable(2)]
		public unsafe TsBaseCharacter 角色蓝图
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRole_bakup_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRole_bakup_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700670D RID: 26381
		// (get) Token: 0x060296ED RID: 169709 RVA: 0x00A2E127 File Offset: 0x00A2C327
		// (set) Token: 0x060296EE RID: 169710 RVA: 0x00A2E137 File Offset: 0x00A2C337
		public unsafe float 跳跃速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700670E RID: 26382
		// (get) Token: 0x060296EF RID: 169711 RVA: 0x00A2E148 File Offset: 0x00A2C348
		// (set) Token: 0x060296F0 RID: 169712 RVA: 0x00A2E15C File Offset: 0x00A2C35C
		public unsafe FVector 整体偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700670F RID: 26383
		// (get) Token: 0x060296F1 RID: 169713 RVA: 0x00A2E171 File Offset: 0x00A2C371
		// (set) Token: 0x060296F2 RID: 169714 RVA: 0x00A2E185 File Offset: 0x00A2C385
		[Nullable(2)]
		public unsafe USkeletalMeshComponent 角色Mesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRole_bakup_C.__PropertyOffset_5);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRole_bakup_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17006710 RID: 26384
		// (get) Token: 0x060296F3 RID: 169715 RVA: 0x00A2E19A File Offset: 0x00A2C39A
		// (set) Token: 0x060296F4 RID: 169716 RVA: 0x00A2E1AE File Offset: 0x00A2C3AE
		public unsafe FVector 整体偏移_实际使用_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17006711 RID: 26385
		// (get) Token: 0x060296F5 RID: 169717 RVA: 0x00A2E1C3 File Offset: 0x00A2C3C3
		// (set) Token: 0x060296F6 RID: 169718 RVA: 0x00A2E1D3 File Offset: 0x00A2C3D3
		public unsafe bool 是否眩晕
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006712 RID: 26386
		// (get) Token: 0x060296F7 RID: 169719 RVA: 0x00A2E1E4 File Offset: 0x00A2C3E4
		// (set) Token: 0x060296F8 RID: 169720 RVA: 0x00A2E1F4 File Offset: 0x00A2C3F4
		public unsafe bool 是否壁上跳跃
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006713 RID: 26387
		// (get) Token: 0x060296F9 RID: 169721 RVA: 0x00A2E208 File Offset: 0x00A2C408
		// (set) Token: 0x060296FA RID: 169722 RVA: 0x00A2E241 File Offset: 0x00A2C441
		[Nullable(1)]
		public FHitResult 左脚探测结果
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FHitResult result;
				if ((result = this._左脚探测结果) == null)
				{
					result = (this._左脚探测结果 = new FHitResult(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_9, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006714 RID: 26388
		// (get) Token: 0x060296FB RID: 169723 RVA: 0x00A2E264 File Offset: 0x00A2C464
		// (set) Token: 0x060296FC RID: 169724 RVA: 0x00A2E29D File Offset: 0x00A2C49D
		[Nullable(1)]
		public FHitResult 右脚探测结果
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FHitResult result;
				if ((result = this._右脚探测结果) == null)
				{
					result = (this._右脚探测结果 = new FHitResult(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_10, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006715 RID: 26389
		// (get) Token: 0x060296FD RID: 169725 RVA: 0x00A2E2BE File Offset: 0x00A2C4BE
		// (set) Token: 0x060296FE RID: 169726 RVA: 0x00A2E2CE File Offset: 0x00A2C4CE
		public unsafe bool 是否右手进入攀爬
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006716 RID: 26390
		// (get) Token: 0x060296FF RID: 169727 RVA: 0x00A2E2DF File Offset: 0x00A2C4DF
		// (set) Token: 0x06029700 RID: 169728 RVA: 0x00A2E2EF File Offset: 0x00A2C4EF
		public unsafe bool FASLE
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006717 RID: 26391
		// (get) Token: 0x06029701 RID: 169729 RVA: 0x00A2E300 File Offset: 0x00A2C500
		// (set) Token: 0x06029702 RID: 169730 RVA: 0x00A2E310 File Offset: 0x00A2C510
		public unsafe float 钩索启动角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17006718 RID: 26392
		// (get) Token: 0x06029703 RID: 169731 RVA: 0x00A2E321 File Offset: 0x00A2C521
		// (set) Token: 0x06029704 RID: 169732 RVA: 0x00A2E331 File Offset: 0x00A2C531
		public unsafe byte 反斜登顶退出
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17006719 RID: 26393
		// (get) Token: 0x06029705 RID: 169733 RVA: 0x00A2E342 File Offset: 0x00A2C542
		// (set) Token: 0x06029706 RID: 169734 RVA: 0x00A2E352 File Offset: 0x00A2C552
		public unsafe float 巨物拉取角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700671A RID: 26394
		// (get) Token: 0x06029707 RID: 169735 RVA: 0x00A2E363 File Offset: 0x00A2C563
		// (set) Token: 0x06029708 RID: 169736 RVA: 0x00A2E373 File Offset: 0x00A2C573
		public unsafe float 跳跃速率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x1700671B RID: 26395
		// (get) Token: 0x06029709 RID: 169737 RVA: 0x00A2E384 File Offset: 0x00A2C584
		// (set) Token: 0x0602970A RID: 169738 RVA: 0x00A2E394 File Offset: 0x00A2C594
		public unsafe bool 状态_XA
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700671C RID: 26396
		// (get) Token: 0x0602970B RID: 169739 RVA: 0x00A2E3A5 File Offset: 0x00A2C5A5
		// (set) Token: 0x0602970C RID: 169740 RVA: 0x00A2E3B5 File Offset: 0x00A2C5B5
		public unsafe float XA_UD混合
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700671D RID: 26397
		// (get) Token: 0x0602970D RID: 169741 RVA: 0x00A2E3C6 File Offset: 0x00A2C5C6
		// (set) Token: 0x0602970E RID: 169742 RVA: 0x00A2E3D6 File Offset: 0x00A2C5D6
		public unsafe float XA_RL混合
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x1700671E RID: 26398
		// (get) Token: 0x0602970F RID: 169743 RVA: 0x00A2E3E8 File Offset: 0x00A2C5E8
		// (set) Token: 0x06029710 RID: 169744 RVA: 0x00A2E421 File Offset: 0x00A2C621
		[Nullable(1)]
		public FPoseSnapshot CachePose
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPoseSnapshot result;
				if ((result = this._CachePose) == null)
				{
					result = (this._CachePose = new FPoseSnapshot(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_20, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseSnapshot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_20, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700671F RID: 26399
		// (get) Token: 0x06029711 RID: 169745 RVA: 0x00A2E442 File Offset: 0x00A2C642
		// (set) Token: 0x06029712 RID: 169746 RVA: 0x00A2E452 File Offset: 0x00A2C652
		public unsafe bool EnableSwitchPose
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006720 RID: 26400
		// (get) Token: 0x06029713 RID: 169747 RVA: 0x00A2E463 File Offset: 0x00A2C663
		// (set) Token: 0x06029714 RID: 169748 RVA: 0x00A2E473 File Offset: 0x00A2C673
		public unsafe float SwitchPoseTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17006721 RID: 26401
		// (get) Token: 0x06029715 RID: 169749 RVA: 0x00A2E484 File Offset: 0x00A2C684
		// (set) Token: 0x06029716 RID: 169750 RVA: 0x00A2E494 File Offset: 0x00A2C694
		public unsafe float 上坡前倾
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17006722 RID: 26402
		// (get) Token: 0x06029717 RID: 169751 RVA: 0x00A2E4A5 File Offset: 0x00A2C6A5
		// (set) Token: 0x06029718 RID: 169752 RVA: 0x00A2E4B5 File Offset: 0x00A2C6B5
		public unsafe float 上坡削弱IK
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17006723 RID: 26403
		// (get) Token: 0x06029719 RID: 169753 RVA: 0x00A2E4C6 File Offset: 0x00A2C6C6
		// (set) Token: 0x0602971A RID: 169754 RVA: 0x00A2E4D6 File Offset: 0x00A2C6D6
		public unsafe bool 状态_空中_风筝
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_25) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_25) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006724 RID: 26404
		// (get) Token: 0x0602971B RID: 169755 RVA: 0x00A2E4E7 File Offset: 0x00A2C6E7
		// (set) Token: 0x0602971C RID: 169756 RVA: 0x00A2E4F7 File Offset: 0x00A2C6F7
		public unsafe bool IsVehicleImpact
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_26) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_26) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006725 RID: 26405
		// (get) Token: 0x0602971D RID: 169757 RVA: 0x00A2E508 File Offset: 0x00A2C708
		// (set) Token: 0x0602971E RID: 169758 RVA: 0x00A2E518 File Offset: 0x00A2C718
		public unsafe float VehicleCollisionStrength_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17006726 RID: 26406
		// (get) Token: 0x0602971F RID: 169759 RVA: 0x00A2E529 File Offset: 0x00A2C729
		// (set) Token: 0x06029720 RID: 169760 RVA: 0x00A2E539 File Offset: 0x00A2C739
		public unsafe float VehicleCollisionAngle_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17006727 RID: 26407
		// (get) Token: 0x06029721 RID: 169761 RVA: 0x00A2E54A File Offset: 0x00A2C74A
		// (set) Token: 0x06029722 RID: 169762 RVA: 0x00A2E55A File Offset: 0x00A2C75A
		public unsafe float VehicleCollisionAlpha_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17006728 RID: 26408
		// (get) Token: 0x06029723 RID: 169763 RVA: 0x00A2E56B File Offset: 0x00A2C76B
		// (set) Token: 0x06029724 RID: 169764 RVA: 0x00A2E57F File Offset: 0x00A2C77F
		public unsafe FVector4 VehicleCollisionMix_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17006729 RID: 26409
		// (get) Token: 0x06029725 RID: 169765 RVA: 0x00A2E594 File Offset: 0x00A2C794
		// (set) Token: 0x06029726 RID: 169766 RVA: 0x00A2E5A8 File Offset: 0x00A2C7A8
		public unsafe FRotator VehicleSeatRot_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x1700672A RID: 26410
		// (get) Token: 0x06029727 RID: 169767 RVA: 0x00A2E5BD File Offset: 0x00A2C7BD
		// (set) Token: 0x06029728 RID: 169768 RVA: 0x00A2E5CD File Offset: 0x00A2C7CD
		public unsafe bool TestCollision
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_32) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_32) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700672B RID: 26411
		// (get) Token: 0x06029729 RID: 169769 RVA: 0x00A2E5DE File Offset: 0x00A2C7DE
		// (set) Token: 0x0602972A RID: 169770 RVA: 0x00A2E5F2 File Offset: 0x00A2C7F2
		public unsafe FVector4 VehicleSuddenMoveMix_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x1700672C RID: 26412
		// (get) Token: 0x0602972B RID: 169771 RVA: 0x00A2E607 File Offset: 0x00A2C807
		// (set) Token: 0x0602972C RID: 169772 RVA: 0x00A2E617 File Offset: 0x00A2C817
		public unsafe float LastForwardSpeed_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x1700672D RID: 26413
		// (get) Token: 0x0602972D RID: 169773 RVA: 0x00A2E628 File Offset: 0x00A2C828
		// (set) Token: 0x0602972E RID: 169774 RVA: 0x00A2E638 File Offset: 0x00A2C838
		public unsafe float CurForwardSpeed_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x1700672E RID: 26414
		// (get) Token: 0x0602972F RID: 169775 RVA: 0x00A2E649 File Offset: 0x00A2C849
		// (set) Token: 0x06029730 RID: 169776 RVA: 0x00A2E659 File Offset: 0x00A2C859
		public unsafe float LastSeatRoll
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x1700672F RID: 26415
		// (get) Token: 0x06029731 RID: 169777 RVA: 0x00A2E66A File Offset: 0x00A2C86A
		// (set) Token: 0x06029732 RID: 169778 RVA: 0x00A2E67A File Offset: 0x00A2C87A
		public unsafe float CurSeatRoll
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17006730 RID: 26416
		// (get) Token: 0x06029733 RID: 169779 RVA: 0x00A2E68B File Offset: 0x00A2C88B
		// (set) Token: 0x06029734 RID: 169780 RVA: 0x00A2E69B File Offset: 0x00A2C89B
		public unsafe float SuddenMoveCd_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17006731 RID: 26417
		// (get) Token: 0x06029735 RID: 169781 RVA: 0x00A2E6AC File Offset: 0x00A2C8AC
		// (set) Token: 0x06029736 RID: 169782 RVA: 0x00A2E6BC File Offset: 0x00A2C8BC
		public unsafe bool SuddenMoveTrigger
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_39) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_39) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006732 RID: 26418
		// (get) Token: 0x06029737 RID: 169783 RVA: 0x00A2E6CD File Offset: 0x00A2C8CD
		// (set) Token: 0x06029738 RID: 169784 RVA: 0x00A2E6DD File Offset: 0x00A2C8DD
		public unsafe bool SuddenStopTrigger
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_40) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_40) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006733 RID: 26419
		// (get) Token: 0x06029739 RID: 169785 RVA: 0x00A2E6EE File Offset: 0x00A2C8EE
		// (set) Token: 0x0602973A RID: 169786 RVA: 0x00A2E702 File Offset: 0x00A2C902
		public unsafe FVector 相对空中速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x17006734 RID: 26420
		// (get) Token: 0x0602973B RID: 169787 RVA: 0x00A2E717 File Offset: 0x00A2C917
		// (set) Token: 0x0602973C RID: 169788 RVA: 0x00A2E727 File Offset: 0x00A2C927
		public unsafe bool 状态_滑轨
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_42) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_42) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006735 RID: 26421
		// (get) Token: 0x0602973D RID: 169789 RVA: 0x00A2E738 File Offset: 0x00A2C938
		// (set) Token: 0x0602973E RID: 169790 RVA: 0x00A2E748 File Offset: 0x00A2C948
		public unsafe bool 状态_滑轨_空中
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_43) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_43) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006736 RID: 26422
		// (get) Token: 0x0602973F RID: 169791 RVA: 0x00A2E759 File Offset: 0x00A2C959
		// (set) Token: 0x06029740 RID: 169792 RVA: 0x00A2E769 File Offset: 0x00A2C969
		public unsafe bool 滑轨落地动画
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_44) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_44) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006737 RID: 26423
		// (get) Token: 0x06029741 RID: 169793 RVA: 0x00A2E77A File Offset: 0x00A2C97A
		// (set) Token: 0x06029742 RID: 169794 RVA: 0x00A2E78A File Offset: 0x00A2C98A
		public unsafe bool 状态_滑轨_空中_右侧
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_45) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_45) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006738 RID: 26424
		// (get) Token: 0x06029743 RID: 169795 RVA: 0x00A2E79B File Offset: 0x00A2C99B
		// (set) Token: 0x06029744 RID: 169796 RVA: 0x00A2E7AB File Offset: 0x00A2C9AB
		public unsafe bool 状态_牵手_牵手中
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_46) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_46) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006739 RID: 26425
		// (get) Token: 0x06029745 RID: 169797 RVA: 0x00A2E7BC File Offset: 0x00A2C9BC
		// (set) Token: 0x06029746 RID: 169798 RVA: 0x00A2E7CC File Offset: 0x00A2C9CC
		public unsafe bool 状态_牵手_被牵手中
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_47) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_47) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700673A RID: 26426
		// (get) Token: 0x06029747 RID: 169799 RVA: 0x00A2E7DD File Offset: 0x00A2C9DD
		// (set) Token: 0x06029748 RID: 169800 RVA: 0x00A2E7ED File Offset: 0x00A2C9ED
		public unsafe bool 状态_牵手_范围内
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_48) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_48) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700673B RID: 26427
		// (get) Token: 0x06029749 RID: 169801 RVA: 0x00A2E7FE File Offset: 0x00A2C9FE
		// (set) Token: 0x0602974A RID: 169802 RVA: 0x00A2E80E File Offset: 0x00A2CA0E
		public unsafe bool IsInPlotBlend
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_49) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_49) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700673C RID: 26428
		// (get) Token: 0x0602974B RID: 169803 RVA: 0x00A2E81F File Offset: 0x00A2CA1F
		// (set) Token: 0x0602974C RID: 169804 RVA: 0x00A2E82F File Offset: 0x00A2CA2F
		public unsafe float 移动平台IKAlpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_50);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_50) = value;
			}
		}

		// Token: 0x1700673D RID: 26429
		// (get) Token: 0x0602974D RID: 169805 RVA: 0x00A2E840 File Offset: 0x00A2CA40
		// (set) Token: 0x0602974E RID: 169806 RVA: 0x00A2E850 File Offset: 0x00A2CA50
		public unsafe bool 移动平台移动中
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_51) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_51) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700673E RID: 26430
		// (get) Token: 0x0602974F RID: 169807 RVA: 0x00A2E861 File Offset: 0x00A2CA61
		// (set) Token: 0x06029750 RID: 169808 RVA: 0x00A2E871 File Offset: 0x00A2CA71
		public unsafe bool 状态_基础移动替换
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_52) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_52) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700673F RID: 26431
		// (get) Token: 0x06029751 RID: 169809 RVA: 0x00A2E882 File Offset: 0x00A2CA82
		// (set) Token: 0x06029752 RID: 169810 RVA: 0x00A2E892 File Offset: 0x00A2CA92
		public unsafe bool 状态_样条跑墙
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_53) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_53) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006740 RID: 26432
		// (get) Token: 0x06029753 RID: 169811 RVA: 0x00A2E8A3 File Offset: 0x00A2CAA3
		// (set) Token: 0x06029754 RID: 169812 RVA: 0x00A2E8B3 File Offset: 0x00A2CAB3
		public unsafe bool 状态_上坡动画替换
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_54) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_54) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006741 RID: 26433
		// (get) Token: 0x06029755 RID: 169813 RVA: 0x00A2E8C4 File Offset: 0x00A2CAC4
		// (set) Token: 0x06029756 RID: 169814 RVA: 0x00A2E8D4 File Offset: 0x00A2CAD4
		public unsafe bool 状态_强制更新源姿势
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_55) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_55) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006742 RID: 26434
		// (get) Token: 0x06029757 RID: 169815 RVA: 0x00A2E8E5 File Offset: 0x00A2CAE5
		// (set) Token: 0x06029758 RID: 169816 RVA: 0x00A2E8F5 File Offset: 0x00A2CAF5
		public unsafe bool 状态_地区运动模式
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_56) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_56) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006743 RID: 26435
		// (get) Token: 0x06029759 RID: 169817 RVA: 0x00A2E906 File Offset: 0x00A2CB06
		// (set) Token: 0x0602975A RID: 169818 RVA: 0x00A2E916 File Offset: 0x00A2CB16
		public unsafe bool 状态_载具驾驶_摩托
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_57) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_57) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006744 RID: 26436
		// (get) Token: 0x0602975B RID: 169819 RVA: 0x00A2E927 File Offset: 0x00A2CB27
		// (set) Token: 0x0602975C RID: 169820 RVA: 0x00A2E937 File Offset: 0x00A2CB37
		public unsafe bool 状态_地区动作保留
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_58) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_58) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006745 RID: 26437
		// (get) Token: 0x0602975D RID: 169821 RVA: 0x00A2E948 File Offset: 0x00A2CB48
		// (set) Token: 0x0602975E RID: 169822 RVA: 0x00A2E958 File Offset: 0x00A2CB58
		public unsafe bool 状态_强制关闭IK
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_59) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_59) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006746 RID: 26438
		// (get) Token: 0x0602975F RID: 169823 RVA: 0x00A2E969 File Offset: 0x00A2CB69
		// (set) Token: 0x06029760 RID: 169824 RVA: 0x00A2E979 File Offset: 0x00A2CB79
		public unsafe float SightLockYawMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_60);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_60) = value;
			}
		}

		// Token: 0x17006747 RID: 26439
		// (get) Token: 0x06029761 RID: 169825 RVA: 0x00A2E98A File Offset: 0x00A2CB8A
		// (set) Token: 0x06029762 RID: 169826 RVA: 0x00A2E99A File Offset: 0x00A2CB9A
		public unsafe float SightLockYawMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_61);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_61) = value;
			}
		}

		// Token: 0x17006748 RID: 26440
		// (get) Token: 0x06029763 RID: 169827 RVA: 0x00A2E9AB File Offset: 0x00A2CBAB
		// (set) Token: 0x06029764 RID: 169828 RVA: 0x00A2E9BB File Offset: 0x00A2CBBB
		public unsafe float SightLockPitchMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_62);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_62) = value;
			}
		}

		// Token: 0x17006749 RID: 26441
		// (get) Token: 0x06029765 RID: 169829 RVA: 0x00A2E9CC File Offset: 0x00A2CBCC
		// (set) Token: 0x06029766 RID: 169830 RVA: 0x00A2E9DC File Offset: 0x00A2CBDC
		public unsafe float SightLockPitchMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_63);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_63) = value;
			}
		}

		// Token: 0x1700674A RID: 26442
		// (get) Token: 0x06029767 RID: 169831 RVA: 0x00A2E9ED File Offset: 0x00A2CBED
		// (set) Token: 0x06029768 RID: 169832 RVA: 0x00A2E9FD File Offset: 0x00A2CBFD
		public unsafe float SightLockAssitLimit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_64);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_64) = value;
			}
		}

		// Token: 0x1700674B RID: 26443
		// (get) Token: 0x06029769 RID: 169833 RVA: 0x00A2EA0E File Offset: 0x00A2CC0E
		// (set) Token: 0x0602976A RID: 169834 RVA: 0x00A2EA1E File Offset: 0x00A2CC1E
		public unsafe bool 状态_关闭FB受击
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_65) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_65) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700674C RID: 26444
		// (get) Token: 0x0602976B RID: 169835 RVA: 0x00A2EA2F File Offset: 0x00A2CC2F
		// (set) Token: 0x0602976C RID: 169836 RVA: 0x00A2EA3F File Offset: 0x00A2CC3F
		public unsafe float 普通运动转基础移动BlendTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_66);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_66) = value;
			}
		}

		// Token: 0x1700674D RID: 26445
		// (get) Token: 0x0602976D RID: 169837 RVA: 0x00A2EA50 File Offset: 0x00A2CC50
		// (set) Token: 0x0602976E RID: 169838 RVA: 0x00A2EA60 File Offset: 0x00A2CC60
		public unsafe float 基础移动转普通运动BlendTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_67);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_67) = value;
			}
		}

		// Token: 0x1700674E RID: 26446
		// (get) Token: 0x0602976F RID: 169839 RVA: 0x00A2EA71 File Offset: 0x00A2CC71
		// (set) Token: 0x06029770 RID: 169840 RVA: 0x00A2EA81 File Offset: 0x00A2CC81
		public unsafe bool 滑轨启用定制动作
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_68) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_68) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700674F RID: 26447
		// (get) Token: 0x06029771 RID: 169841 RVA: 0x00A2EA92 File Offset: 0x00A2CC92
		// (set) Token: 0x06029772 RID: 169842 RVA: 0x00A2EAA2 File Offset: 0x00A2CCA2
		public unsafe bool 状态_滑轨_空中_前向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_69) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_69) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006750 RID: 26448
		// (get) Token: 0x06029773 RID: 169843 RVA: 0x00A2EAB3 File Offset: 0x00A2CCB3
		// (set) Token: 0x06029774 RID: 169844 RVA: 0x00A2EAC7 File Offset: 0x00A2CCC7
		public unsafe FVector SightDirectInSightBone
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_70);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_70) = value;
			}
		}

		// Token: 0x17006751 RID: 26449
		// (get) Token: 0x06029775 RID: 169845 RVA: 0x00A2EADC File Offset: 0x00A2CCDC
		// (set) Token: 0x06029776 RID: 169846 RVA: 0x00A2EAF0 File Offset: 0x00A2CCF0
		public unsafe FVector UpAxisInSightBone
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_71);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_bakup_C.__PropertyOffset_71) = value;
			}
		}

		// Token: 0x06029777 RID: 169847 RVA: 0x00A2EB08 File Offset: 0x00A2CD08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceJumpPressed(ref float Speed)
		{
			ABP_BaseRole_bakup_C.__InterfaceJumpPressed_FunctionParams* ptr = stackalloc ABP_BaseRole_bakup_C.__InterfaceJumpPressed_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(ABP_BaseRole_bakup_C.__InterfaceJumpPressed_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_bakup_C.__InterfaceJumpPressed_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Speed = Speed;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__InterfaceJumpPressed_NativeFunctionPtr, (void*)ptr);
			Speed = ptr->Speed;
		}

		// Token: 0x06029778 RID: 169848 RVA: 0x00A2EB58 File Offset: 0x00A2CD58
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_BaseRole_bakup_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_BaseRole_bakup_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_BaseRole_bakup_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_bakup_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x06029779 RID: 169849 RVA: 0x00A2EBDF File Offset: 0x00A2CDDF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新载具信息()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__更新载具信息_NativeFunctionPtr, null);
		}

		// Token: 0x0602977A RID: 169850 RVA: 0x00A2EBF3 File Offset: 0x00A2CDF3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 风筝移动更新()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__风筝移动更新_NativeFunctionPtr, null);
		}

		// Token: 0x0602977B RID: 169851 RVA: 0x00A2EC07 File Offset: 0x00A2CE07
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 移动平台和上坡IK削弱()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__移动平台和上坡IK削弱_NativeFunctionPtr, null);
		}

		// Token: 0x0602977C RID: 169852 RVA: 0x00A2EC1B File Offset: 0x00A2CE1B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 落地速度切割初始化()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__落地速度切割初始化_NativeFunctionPtr, null);
		}

		// Token: 0x0602977D RID: 169853 RVA: 0x00A2EC30 File Offset: 0x00A2CE30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void VelocityBlendLerp(FVeloctiyBlend From, FVeloctiyBlend To, float Alpha, ref FVeloctiyBlend Out)
		{
			ABP_BaseRole_bakup_C.__VelocityBlendLerp_FunctionParams* ptr = stackalloc ABP_BaseRole_bakup_C.__VelocityBlendLerp_FunctionParams[(UIntPtr)99] + 15L / (long)sizeof(ABP_BaseRole_bakup_C.__VelocityBlendLerp_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_bakup_C.__VelocityBlendLerp_NativeFunctionPtr, (void*)ptr, 1);
			ptr->From = From;
			ptr->To = To;
			ptr->Alpha = Alpha;
			ptr->Out = Out;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__VelocityBlendLerp_NativeFunctionPtr, (void*)ptr);
			Out = ptr->Out;
		}

		// Token: 0x0602977E RID: 169854 RVA: 0x00A2EC9E File Offset: 0x00A2CE9E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void XA状态更新()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__XA状态更新_NativeFunctionPtr, null);
		}

		// Token: 0x0602977F RID: 169855 RVA: 0x00A2ECB4 File Offset: 0x00A2CEB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 设置跳跃速率(float 新速率)
		{
			ABP_BaseRole_bakup_C.__设置跳跃速率_FunctionParams* ptr = stackalloc ABP_BaseRole_bakup_C.__设置跳跃速率_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseRole_bakup_C.__设置跳跃速率_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_bakup_C.__设置跳跃速率_NativeFunctionPtr, (void*)ptr, 1);
			ptr->新速率 = 新速率;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__设置跳跃速率_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06029780 RID: 169856 RVA: 0x00A2ECFA File Offset: 0x00A2CEFA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 冰冻结束事件()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__冰冻结束事件_NativeFunctionPtr, null);
		}

		// Token: 0x06029781 RID: 169857 RVA: 0x00A2ED10 File Offset: 0x00A2CF10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 计算跳跃混合(float 速度, ref float 混合)
		{
			ABP_BaseRole_bakup_C.__计算跳跃混合_FunctionParams* ptr = stackalloc ABP_BaseRole_bakup_C.__计算跳跃混合_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(ABP_BaseRole_bakup_C.__计算跳跃混合_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_bakup_C.__计算跳跃混合_NativeFunctionPtr, (void*)ptr, 1);
			ptr->速度 = 速度;
			ptr->混合 = 混合;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__计算跳跃混合_NativeFunctionPtr, (void*)ptr);
			混合 = ptr->混合;
		}

		// Token: 0x06029782 RID: 169858 RVA: 0x00A2ED66 File Offset: 0x00A2CF66
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CleanAnimVariable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__CleanAnimVariable_NativeFunctionPtr, null);
		}

		// Token: 0x06029783 RID: 169859 RVA: 0x00A2ED7C File Offset: 0x00A2CF7C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void True布尔序列输出(ref TArray<bool> ValArrt_Bool, ref int Out)
		{
			ABP_BaseRole_bakup_C.__True布尔序列输出_FunctionParams* ptr = stackalloc ABP_BaseRole_bakup_C.__True布尔序列输出_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(ABP_BaseRole_bakup_C.__True布尔序列输出_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_bakup_C.__True布尔序列输出_NativeFunctionPtr, (void*)ptr, 1);
			TArray<bool> tarray = ValArrt_Bool;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->ValArrt_Bool);
			}
			ptr->Out = Out;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__True布尔序列输出_NativeFunctionPtr, (void*)ptr);
			TArray<bool> tarray2 = ValArrt_Bool;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->ValArrt_Bool);
			}
			Out = ptr->Out;
			UnrealReflectionUtils.DestroyStruct(ABP_BaseRole_bakup_C.__True布尔序列输出_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06029784 RID: 169860 RVA: 0x00A2EE04 File Offset: 0x00A2D004
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新上传()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__更新上传_NativeFunctionPtr, null);
		}

		// Token: 0x06029785 RID: 169861 RVA: 0x00A2EE18 File Offset: 0x00A2D018
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 初始化Tag()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__初始化Tag_NativeFunctionPtr, null);
		}

		// Token: 0x06029786 RID: 169862 RVA: 0x00A2EE2C File Offset: 0x00A2D02C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 替换角色时同步动作数据(ABP_BaseRole_C 切出角色AnimIns)
		{
			ABP_BaseRole_bakup_C.__替换角色时同步动作数据_FunctionParams* ptr = stackalloc ABP_BaseRole_bakup_C.__替换角色时同步动作数据_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(ABP_BaseRole_bakup_C.__替换角色时同步动作数据_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_bakup_C.__替换角色时同步动作数据_NativeFunctionPtr, (void*)ptr, 1);
			ptr->切出角色AnimIns = ((切出角色AnimIns != null) ? 切出角色AnimIns.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__替换角色时同步动作数据_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06029787 RID: 169863 RVA: 0x00A2EE84 File Offset: 0x00A2D084
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 设置头部转向状态(SightLockMode SightMode)
		{
			ABP_BaseRole_bakup_C.__设置头部转向状态_FunctionParams* ptr = stackalloc ABP_BaseRole_bakup_C.__设置头部转向状态_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(ABP_BaseRole_bakup_C.__设置头部转向状态_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_bakup_C.__设置头部转向状态_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SightMode = SightMode;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__设置头部转向状态_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06029788 RID: 169864 RVA: 0x00A2EECA File Offset: 0x00A2D0CA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BlueprintInitializeAnimation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null);
		}

		// Token: 0x06029789 RID: 169865 RVA: 0x00A2EEDE File Offset: 0x00A2D0DE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BlueprintInitializeAnimation_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602978A RID: 169866 RVA: 0x00A2EEF4 File Offset: 0x00A2D0F4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 播放动画(SDynamicMontageParams 播放动画)
		{
			ABP_BaseRole_bakup_C.__播放动画_FunctionParams* ptr = stackalloc ABP_BaseRole_bakup_C.__播放动画_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_BaseRole_bakup_C.__播放动画_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_bakup_C.__播放动画_NativeFunctionPtr, (void*)ptr, 1);
			if (播放动画 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SDynamicMontageParams.StaticStruct(), &ptr->播放动画, 播放动画.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__播放动画_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602978B RID: 169867 RVA: 0x00A2EF55 File Offset: 0x00A2D155
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_停止动画()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__AnimNotify_停止动画_NativeFunctionPtr, null);
		}

		// Token: 0x0602978C RID: 169868 RVA: 0x00A2EF69 File Offset: 0x00A2D169
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_进入攀爬()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__AnimNotify_进入攀爬_NativeFunctionPtr, null);
		}

		// Token: 0x0602978D RID: 169869 RVA: 0x00A2EF7D File Offset: 0x00A2D17D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_退出攀爬()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__AnimNotify_退出攀爬_NativeFunctionPtr, null);
		}

		// Token: 0x0602978E RID: 169870 RVA: 0x00A2EF91 File Offset: 0x00A2D191
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_爬下位移完成()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__AnimNotify_爬下位移完成_NativeFunctionPtr, null);
		}

		// Token: 0x0602978F RID: 169871 RVA: 0x00A2EFA5 File Offset: 0x00A2D1A5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_完成登上()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__AnimNotify_完成登上_NativeFunctionPtr, null);
		}

		// Token: 0x06029790 RID: 169872 RVA: 0x00A2EFB9 File Offset: 0x00A2D1B9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_翻滚落地()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__AnimNotify_翻滚落地_NativeFunctionPtr, null);
		}

		// Token: 0x06029791 RID: 169873 RVA: 0x00A2EFCD File Offset: 0x00A2D1CD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_进入疾跑()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__AnimNotify_进入疾跑_NativeFunctionPtr, null);
		}

		// Token: 0x06029792 RID: 169874 RVA: 0x00A2EFE1 File Offset: 0x00A2D1E1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClimbDash()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__ClimbDash_NativeFunctionPtr, null);
		}

		// Token: 0x06029793 RID: 169875 RVA: 0x00A2EFF5 File Offset: 0x00A2D1F5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_EnterStand()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__AnimNotify_EnterStand_NativeFunctionPtr, null);
		}

		// Token: 0x06029794 RID: 169876 RVA: 0x00A2F009 File Offset: 0x00A2D209
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_结束受击()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__AnimNotify_结束受击_NativeFunctionPtr, null);
		}

		// Token: 0x06029795 RID: 169877 RVA: 0x00A2F01D File Offset: 0x00A2D21D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TestFk()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__TestFk_NativeFunctionPtr, null);
		}

		// Token: 0x06029796 RID: 169878 RVA: 0x00A2F034 File Offset: 0x00A2D234
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void BlueprintUpdateAnimation(float DeltaTimeX)
		{
			ABP_BaseRole_bakup_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_BaseRole_bakup_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseRole_bakup_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_bakup_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06029797 RID: 169879 RVA: 0x00A2F07C File Offset: 0x00A2D27C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BlueprintUpdateAnimation_Implementation(float DeltaTimeX)
		{
			ABP_BaseRole_bakup_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_BaseRole_bakup_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseRole_bakup_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_bakup_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029798 RID: 169880 RVA: 0x00A2F0C4 File Offset: 0x00A2D2C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceControlPoint(FVector Offset)
		{
			ABP_BaseRole_bakup_C.__InterfaceControlPoint_FunctionParams* ptr = stackalloc ABP_BaseRole_bakup_C.__InterfaceControlPoint_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_BaseRole_bakup_C.__InterfaceControlPoint_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_bakup_C.__InterfaceControlPoint_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Offset = Offset;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__InterfaceControlPoint_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06029799 RID: 169881 RVA: 0x00A2F10A File Offset: 0x00A2D30A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_开始登上()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__AnimNotify_开始登上_NativeFunctionPtr, null);
		}

		// Token: 0x0602979A RID: 169882 RVA: 0x00A2F11E File Offset: 0x00A2D31E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_进入待机表演()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__AnimNotify_进入待机表演_NativeFunctionPtr, null);
		}

		// Token: 0x0602979B RID: 169883 RVA: 0x00A2F132 File Offset: 0x00A2D332
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_退出待机表演()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__AnimNotify_退出待机表演_NativeFunctionPtr, null);
		}

		// Token: 0x0602979C RID: 169884 RVA: 0x00A2F146 File Offset: 0x00A2D346
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_RHand()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__AnimNotify_RHand_NativeFunctionPtr, null);
		}

		// Token: 0x0602979D RID: 169885 RVA: 0x00A2F15A File Offset: 0x00A2D35A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_LHand()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__AnimNotify_LHand_NativeFunctionPtr, null);
		}

		// Token: 0x0602979E RID: 169886 RVA: 0x00A2F16E File Offset: 0x00A2D36E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnComponentStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__OnComponentStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602979F RID: 169887 RVA: 0x00A2F182 File Offset: 0x00A2D382
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnComponentStart_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__OnComponentStart_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060297A0 RID: 169888 RVA: 0x00A2F198 File Offset: 0x00A2D398
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceSimulateJump(float Speed)
		{
			ABP_BaseRole_bakup_C.__InterfaceSimulateJump_FunctionParams* ptr = stackalloc ABP_BaseRole_bakup_C.__InterfaceSimulateJump_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseRole_bakup_C.__InterfaceSimulateJump_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_bakup_C.__InterfaceSimulateJump_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Speed = Speed;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__InterfaceSimulateJump_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060297A1 RID: 169889 RVA: 0x00A2F1E0 File Offset: 0x00A2D3E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceFixHookDirect(FVector Offset)
		{
			ABP_BaseRole_bakup_C.__InterfaceFixHookDirect_FunctionParams* ptr = stackalloc ABP_BaseRole_bakup_C.__InterfaceFixHookDirect_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_BaseRole_bakup_C.__InterfaceFixHookDirect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_bakup_C.__InterfaceFixHookDirect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Offset = Offset;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__InterfaceFixHookDirect_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060297A2 RID: 169890 RVA: 0x00A2F226 File Offset: 0x00A2D426
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClearClimbDash()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__ClearClimbDash_NativeFunctionPtr, null);
		}

		// Token: 0x060297A3 RID: 169891 RVA: 0x00A2F23A File Offset: 0x00A2D43A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_反斜退出()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__AnimNotify_反斜退出_NativeFunctionPtr, null);
		}

		// Token: 0x060297A4 RID: 169892 RVA: 0x00A2F24E File Offset: 0x00A2D44E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_冲刺跨越远退出()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__AnimNotify_冲刺跨越远退出_NativeFunctionPtr, null);
		}

		// Token: 0x060297A5 RID: 169893 RVA: 0x00A2F264 File Offset: 0x00A2D464
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceManipulateInteractDirection(float 角度)
		{
			ABP_BaseRole_bakup_C.__InterfaceManipulateInteractDirection_FunctionParams* ptr = stackalloc ABP_BaseRole_bakup_C.__InterfaceManipulateInteractDirection_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseRole_bakup_C.__InterfaceManipulateInteractDirection_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_bakup_C.__InterfaceManipulateInteractDirection_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角度 = 角度;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__InterfaceManipulateInteractDirection_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060297A6 RID: 169894 RVA: 0x00A2F2AA File Offset: 0x00A2D4AA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PlotBlendIn()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__PlotBlendIn_NativeFunctionPtr, null);
		}

		// Token: 0x060297A7 RID: 169895 RVA: 0x00A2F2BE File Offset: 0x00A2D4BE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void NoExpose()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__NoExpose_NativeFunctionPtr, null);
		}

		// Token: 0x060297A8 RID: 169896 RVA: 0x00A2F2D2 File Offset: 0x00A2D4D2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_LeftStartSwing()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__AnimNotify_LeftStartSwing_NativeFunctionPtr, null);
		}

		// Token: 0x060297A9 RID: 169897 RVA: 0x00A2F2E6 File Offset: 0x00A2D4E6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_LeftEndSwing()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__AnimNotify_LeftEndSwing_NativeFunctionPtr, null);
		}

		// Token: 0x060297AA RID: 169898 RVA: 0x00A2F2FA File Offset: 0x00A2D4FA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_LeftLoopSwing()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__AnimNotify_LeftLoopSwing_NativeFunctionPtr, null);
		}

		// Token: 0x060297AB RID: 169899 RVA: 0x00A2F310 File Offset: 0x00A2D510
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetSightLockConfig(float YawMin, float YawMax, float PitchMin, float PitchMax, float AssitLimit, FVector SightDirectInSightBone, FVector UpAxisInSightBone)
		{
			ABP_BaseRole_bakup_C.__SetSightLockConfig_FunctionParams* ptr = stackalloc ABP_BaseRole_bakup_C.__SetSightLockConfig_FunctionParams[(UIntPtr)59] + 15L / (long)sizeof(ABP_BaseRole_bakup_C.__SetSightLockConfig_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_bakup_C.__SetSightLockConfig_NativeFunctionPtr, (void*)ptr, 1);
			ptr->YawMin = YawMin;
			ptr->YawMax = YawMax;
			ptr->PitchMin = PitchMin;
			ptr->PitchMax = PitchMax;
			ptr->AssitLimit = AssitLimit;
			ptr->SightDirectInSightBone = SightDirectInSightBone;
			ptr->UpAxisInSightBone = UpAxisInSightBone;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__SetSightLockConfig_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060297AC RID: 169900 RVA: 0x00A2F384 File Offset: 0x00A2D584
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_壁上跳跃完全混合()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__AnimNotify_壁上跳跃完全混合_NativeFunctionPtr, null);
		}

		// Token: 0x060297AD RID: 169901 RVA: 0x00A2F398 File Offset: 0x00A2D598
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_BaseRole_bakup(int EntryPoint)
		{
			ABP_BaseRole_bakup_C.__ExecuteUbergraph_ABP_BaseRole_bakup_FunctionParams* ptr = stackalloc ABP_BaseRole_bakup_C.__ExecuteUbergraph_ABP_BaseRole_bakup_FunctionParams[(UIntPtr)2095] + 15L / (long)sizeof(ABP_BaseRole_bakup_C.__ExecuteUbergraph_ABP_BaseRole_bakup_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_bakup_C.__ExecuteUbergraph_ABP_BaseRole_bakup_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseRole_bakup_C.__ExecuteUbergraph_ABP_BaseRole_bakup_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060297AE RID: 169902 RVA: 0x00A2F3E2 File Offset: 0x00A2D5E2
		protected ABP_BaseRole_bakup_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04016127 RID: 90407
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/ABP_BaseRole_bakup.ABP_BaseRole_bakup_C";

		// Token: 0x04016128 RID: 90408
		private static IntPtr _ClassPtr;

		// Token: 0x04016129 RID: 90409
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401612A RID: 90410
		internal static int __PropertyOffset_0;

		// Token: 0x0401612B RID: 90411
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401612C RID: 90412
		internal static int __PropertyOffset_1;

		// Token: 0x0401612D RID: 90413
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x0401612E RID: 90414
		internal static int __PropertyOffset_2;

		// Token: 0x0401612F RID: 90415
		internal static int __PropertyOffset_3;

		// Token: 0x04016130 RID: 90416
		internal static int __PropertyOffset_4;

		// Token: 0x04016131 RID: 90417
		internal static int __PropertyOffset_5;

		// Token: 0x04016132 RID: 90418
		internal static int __PropertyOffset_6;

		// Token: 0x04016133 RID: 90419
		internal static int __PropertyOffset_7;

		// Token: 0x04016134 RID: 90420
		internal static int __PropertyOffset_8;

		// Token: 0x04016135 RID: 90421
		internal static int __PropertyOffset_9;

		// Token: 0x04016136 RID: 90422
		[Nullable(2)]
		private FHitResult _左脚探测结果;

		// Token: 0x04016137 RID: 90423
		internal static int __PropertyOffset_10;

		// Token: 0x04016138 RID: 90424
		[Nullable(2)]
		private FHitResult _右脚探测结果;

		// Token: 0x04016139 RID: 90425
		internal static int __PropertyOffset_11;

		// Token: 0x0401613A RID: 90426
		internal static int __PropertyOffset_12;

		// Token: 0x0401613B RID: 90427
		internal static int __PropertyOffset_13;

		// Token: 0x0401613C RID: 90428
		internal static int __PropertyOffset_14;

		// Token: 0x0401613D RID: 90429
		internal static int __PropertyOffset_15;

		// Token: 0x0401613E RID: 90430
		internal static int __PropertyOffset_16;

		// Token: 0x0401613F RID: 90431
		internal static int __PropertyOffset_17;

		// Token: 0x04016140 RID: 90432
		internal static int __PropertyOffset_18;

		// Token: 0x04016141 RID: 90433
		internal static int __PropertyOffset_19;

		// Token: 0x04016142 RID: 90434
		internal static int __PropertyOffset_20;

		// Token: 0x04016143 RID: 90435
		[Nullable(2)]
		private FPoseSnapshot _CachePose;

		// Token: 0x04016144 RID: 90436
		internal static int __PropertyOffset_21;

		// Token: 0x04016145 RID: 90437
		internal static int __PropertyOffset_22;

		// Token: 0x04016146 RID: 90438
		internal static int __PropertyOffset_23;

		// Token: 0x04016147 RID: 90439
		internal static int __PropertyOffset_24;

		// Token: 0x04016148 RID: 90440
		internal static int __PropertyOffset_25;

		// Token: 0x04016149 RID: 90441
		internal static int __PropertyOffset_26;

		// Token: 0x0401614A RID: 90442
		internal static int __PropertyOffset_27;

		// Token: 0x0401614B RID: 90443
		internal static int __PropertyOffset_28;

		// Token: 0x0401614C RID: 90444
		internal static int __PropertyOffset_29;

		// Token: 0x0401614D RID: 90445
		internal static int __PropertyOffset_30;

		// Token: 0x0401614E RID: 90446
		internal static int __PropertyOffset_31;

		// Token: 0x0401614F RID: 90447
		internal static int __PropertyOffset_32;

		// Token: 0x04016150 RID: 90448
		internal static int __PropertyOffset_33;

		// Token: 0x04016151 RID: 90449
		internal static int __PropertyOffset_34;

		// Token: 0x04016152 RID: 90450
		internal static int __PropertyOffset_35;

		// Token: 0x04016153 RID: 90451
		internal static int __PropertyOffset_36;

		// Token: 0x04016154 RID: 90452
		internal static int __PropertyOffset_37;

		// Token: 0x04016155 RID: 90453
		internal static int __PropertyOffset_38;

		// Token: 0x04016156 RID: 90454
		internal static int __PropertyOffset_39;

		// Token: 0x04016157 RID: 90455
		internal static int __PropertyOffset_40;

		// Token: 0x04016158 RID: 90456
		internal static int __PropertyOffset_41;

		// Token: 0x04016159 RID: 90457
		internal static int __PropertyOffset_42;

		// Token: 0x0401615A RID: 90458
		internal static int __PropertyOffset_43;

		// Token: 0x0401615B RID: 90459
		internal static int __PropertyOffset_44;

		// Token: 0x0401615C RID: 90460
		internal static int __PropertyOffset_45;

		// Token: 0x0401615D RID: 90461
		internal static int __PropertyOffset_46;

		// Token: 0x0401615E RID: 90462
		internal static int __PropertyOffset_47;

		// Token: 0x0401615F RID: 90463
		internal static int __PropertyOffset_48;

		// Token: 0x04016160 RID: 90464
		internal static int __PropertyOffset_49;

		// Token: 0x04016161 RID: 90465
		internal static int __PropertyOffset_50;

		// Token: 0x04016162 RID: 90466
		internal static int __PropertyOffset_51;

		// Token: 0x04016163 RID: 90467
		internal static int __PropertyOffset_52;

		// Token: 0x04016164 RID: 90468
		internal static int __PropertyOffset_53;

		// Token: 0x04016165 RID: 90469
		internal static int __PropertyOffset_54;

		// Token: 0x04016166 RID: 90470
		internal static int __PropertyOffset_55;

		// Token: 0x04016167 RID: 90471
		internal static int __PropertyOffset_56;

		// Token: 0x04016168 RID: 90472
		internal static int __PropertyOffset_57;

		// Token: 0x04016169 RID: 90473
		internal static int __PropertyOffset_58;

		// Token: 0x0401616A RID: 90474
		internal static int __PropertyOffset_59;

		// Token: 0x0401616B RID: 90475
		internal static int __PropertyOffset_60;

		// Token: 0x0401616C RID: 90476
		internal static int __PropertyOffset_61;

		// Token: 0x0401616D RID: 90477
		internal static int __PropertyOffset_62;

		// Token: 0x0401616E RID: 90478
		internal static int __PropertyOffset_63;

		// Token: 0x0401616F RID: 90479
		internal static int __PropertyOffset_64;

		// Token: 0x04016170 RID: 90480
		internal static int __PropertyOffset_65;

		// Token: 0x04016171 RID: 90481
		internal static int __PropertyOffset_66;

		// Token: 0x04016172 RID: 90482
		internal static int __PropertyOffset_67;

		// Token: 0x04016173 RID: 90483
		internal static int __PropertyOffset_68;

		// Token: 0x04016174 RID: 90484
		internal static int __PropertyOffset_69;

		// Token: 0x04016175 RID: 90485
		internal static int __PropertyOffset_70;

		// Token: 0x04016176 RID: 90486
		internal static int __PropertyOffset_71;

		// Token: 0x04016177 RID: 90487
		private static IntPtr __InterfaceJumpPressed_NativeFunctionPtr;

		// Token: 0x04016178 RID: 90488
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x04016179 RID: 90489
		private static IntPtr __更新载具信息_NativeFunctionPtr;

		// Token: 0x0401617A RID: 90490
		private static IntPtr __风筝移动更新_NativeFunctionPtr;

		// Token: 0x0401617B RID: 90491
		private static IntPtr __移动平台和上坡IK削弱_NativeFunctionPtr;

		// Token: 0x0401617C RID: 90492
		private static IntPtr __落地速度切割初始化_NativeFunctionPtr;

		// Token: 0x0401617D RID: 90493
		private static IntPtr __VelocityBlendLerp_NativeFunctionPtr;

		// Token: 0x0401617E RID: 90494
		private static IntPtr __XA状态更新_NativeFunctionPtr;

		// Token: 0x0401617F RID: 90495
		private static IntPtr __设置跳跃速率_NativeFunctionPtr;

		// Token: 0x04016180 RID: 90496
		private static IntPtr __冰冻结束事件_NativeFunctionPtr;

		// Token: 0x04016181 RID: 90497
		private static IntPtr __计算跳跃混合_NativeFunctionPtr;

		// Token: 0x04016182 RID: 90498
		private static IntPtr __CleanAnimVariable_NativeFunctionPtr;

		// Token: 0x04016183 RID: 90499
		private static IntPtr __True布尔序列输出_NativeFunctionPtr;

		// Token: 0x04016184 RID: 90500
		private static IntPtr __更新上传_NativeFunctionPtr;

		// Token: 0x04016185 RID: 90501
		private static IntPtr __初始化Tag_NativeFunctionPtr;

		// Token: 0x04016186 RID: 90502
		private static IntPtr __替换角色时同步动作数据_NativeFunctionPtr;

		// Token: 0x04016187 RID: 90503
		private static IntPtr __设置头部转向状态_NativeFunctionPtr;

		// Token: 0x04016188 RID: 90504
		private static IntPtr __BlueprintInitializeAnimation_NativeFunctionPtr;

		// Token: 0x04016189 RID: 90505
		private static IntPtr __播放动画_NativeFunctionPtr;

		// Token: 0x0401618A RID: 90506
		private static IntPtr __AnimNotify_停止动画_NativeFunctionPtr;

		// Token: 0x0401618B RID: 90507
		private static IntPtr __AnimNotify_进入攀爬_NativeFunctionPtr;

		// Token: 0x0401618C RID: 90508
		private static IntPtr __AnimNotify_退出攀爬_NativeFunctionPtr;

		// Token: 0x0401618D RID: 90509
		private static IntPtr __AnimNotify_爬下位移完成_NativeFunctionPtr;

		// Token: 0x0401618E RID: 90510
		private static IntPtr __AnimNotify_完成登上_NativeFunctionPtr;

		// Token: 0x0401618F RID: 90511
		private static IntPtr __AnimNotify_翻滚落地_NativeFunctionPtr;

		// Token: 0x04016190 RID: 90512
		private static IntPtr __AnimNotify_进入疾跑_NativeFunctionPtr;

		// Token: 0x04016191 RID: 90513
		private static IntPtr __ClimbDash_NativeFunctionPtr;

		// Token: 0x04016192 RID: 90514
		private static IntPtr __AnimNotify_EnterStand_NativeFunctionPtr;

		// Token: 0x04016193 RID: 90515
		private static IntPtr __AnimNotify_结束受击_NativeFunctionPtr;

		// Token: 0x04016194 RID: 90516
		private static IntPtr __TestFk_NativeFunctionPtr;

		// Token: 0x04016195 RID: 90517
		private static IntPtr __BlueprintUpdateAnimation_NativeFunctionPtr;

		// Token: 0x04016196 RID: 90518
		private static IntPtr __InterfaceControlPoint_NativeFunctionPtr;

		// Token: 0x04016197 RID: 90519
		private static IntPtr __AnimNotify_开始登上_NativeFunctionPtr;

		// Token: 0x04016198 RID: 90520
		private static IntPtr __AnimNotify_进入待机表演_NativeFunctionPtr;

		// Token: 0x04016199 RID: 90521
		private static IntPtr __AnimNotify_退出待机表演_NativeFunctionPtr;

		// Token: 0x0401619A RID: 90522
		private static IntPtr __AnimNotify_RHand_NativeFunctionPtr;

		// Token: 0x0401619B RID: 90523
		private static IntPtr __AnimNotify_LHand_NativeFunctionPtr;

		// Token: 0x0401619C RID: 90524
		private static IntPtr __OnComponentStart_NativeFunctionPtr;

		// Token: 0x0401619D RID: 90525
		private static IntPtr __InterfaceSimulateJump_NativeFunctionPtr;

		// Token: 0x0401619E RID: 90526
		private static IntPtr __InterfaceFixHookDirect_NativeFunctionPtr;

		// Token: 0x0401619F RID: 90527
		private static IntPtr __ClearClimbDash_NativeFunctionPtr;

		// Token: 0x040161A0 RID: 90528
		private static IntPtr __AnimNotify_反斜退出_NativeFunctionPtr;

		// Token: 0x040161A1 RID: 90529
		private static IntPtr __AnimNotify_冲刺跨越远退出_NativeFunctionPtr;

		// Token: 0x040161A2 RID: 90530
		private static IntPtr __InterfaceManipulateInteractDirection_NativeFunctionPtr;

		// Token: 0x040161A3 RID: 90531
		private static IntPtr __PlotBlendIn_NativeFunctionPtr;

		// Token: 0x040161A4 RID: 90532
		private static IntPtr __NoExpose_NativeFunctionPtr;

		// Token: 0x040161A5 RID: 90533
		private static IntPtr __AnimNotify_LeftStartSwing_NativeFunctionPtr;

		// Token: 0x040161A6 RID: 90534
		private static IntPtr __AnimNotify_LeftEndSwing_NativeFunctionPtr;

		// Token: 0x040161A7 RID: 90535
		private static IntPtr __AnimNotify_LeftLoopSwing_NativeFunctionPtr;

		// Token: 0x040161A8 RID: 90536
		private static IntPtr __SetSightLockConfig_NativeFunctionPtr;

		// Token: 0x040161A9 RID: 90537
		private static IntPtr __AnimNotify_壁上跳跃完全混合_NativeFunctionPtr;

		// Token: 0x040161AA RID: 90538
		private static IntPtr __ExecuteUbergraph_ABP_BaseRole_bakup_NativeFunctionPtr;

		// Token: 0x0200A20D RID: 41485
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InterfaceJumpPressed_FunctionParams
		{
			// Token: 0x04032F76 RID: 208758
			[FieldOffset(0)]
			public float Speed;
		}

		// Token: 0x0200A20E RID: 41486
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x04032F77 RID: 208759
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A20F RID: 41487
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 84)]
		protected ref struct __VelocityBlendLerp_FunctionParams
		{
			// Token: 0x04032F78 RID: 208760
			[FieldOffset(0)]
			public FVeloctiyBlend From;

			// Token: 0x04032F79 RID: 208761
			[FieldOffset(16)]
			public FVeloctiyBlend To;

			// Token: 0x04032F7A RID: 208762
			[FieldOffset(32)]
			public float Alpha;

			// Token: 0x04032F7B RID: 208763
			[FieldOffset(36)]
			public FVeloctiyBlend Out;
		}

		// Token: 0x0200A210 RID: 41488
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __设置跳跃速率_FunctionParams
		{
			// Token: 0x04032F7C RID: 208764
			[FieldOffset(0)]
			public float 新速率;
		}

		// Token: 0x0200A211 RID: 41489
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __计算跳跃混合_FunctionParams
		{
			// Token: 0x04032F7D RID: 208765
			[FieldOffset(0)]
			public float 速度;

			// Token: 0x04032F7E RID: 208766
			[FieldOffset(4)]
			public float 混合;
		}

		// Token: 0x0200A212 RID: 41490
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __True布尔序列输出_FunctionParams
		{
			// Token: 0x04032F7F RID: 208767
			[FieldOffset(0)]
			public byte ValArrt_Bool;

			// Token: 0x04032F80 RID: 208768
			[FieldOffset(16)]
			public int Out;
		}

		// Token: 0x0200A213 RID: 41491
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __替换角色时同步动作数据_FunctionParams
		{
			// Token: 0x04032F81 RID: 208769
			[FieldOffset(0)]
			public IntPtr 切出角色AnimIns;
		}

		// Token: 0x0200A214 RID: 41492
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __设置头部转向状态_FunctionParams
		{
			// Token: 0x04032F82 RID: 208770
			[FieldOffset(0)]
			public SightLockMode SightMode;
		}

		// Token: 0x0200A215 RID: 41493
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __播放动画_FunctionParams
		{
			// Token: 0x04032F83 RID: 208771
			[FieldOffset(0)]
			public byte 播放动画;
		}

		// Token: 0x0200A216 RID: 41494
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __BlueprintUpdateAnimation_FunctionParams
		{
			// Token: 0x04032F84 RID: 208772
			[FieldOffset(0)]
			public float DeltaTimeX;
		}

		// Token: 0x0200A217 RID: 41495
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __InterfaceControlPoint_FunctionParams
		{
			// Token: 0x04032F85 RID: 208773
			[FieldOffset(0)]
			public FVector Offset;
		}

		// Token: 0x0200A218 RID: 41496
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __InterfaceSimulateJump_FunctionParams
		{
			// Token: 0x04032F86 RID: 208774
			[FieldOffset(0)]
			public float Speed;
		}

		// Token: 0x0200A219 RID: 41497
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __InterfaceFixHookDirect_FunctionParams
		{
			// Token: 0x04032F87 RID: 208775
			[FieldOffset(0)]
			public FVector Offset;
		}

		// Token: 0x0200A21A RID: 41498
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __InterfaceManipulateInteractDirection_FunctionParams
		{
			// Token: 0x04032F88 RID: 208776
			[FieldOffset(0)]
			public float 角度;
		}

		// Token: 0x0200A21B RID: 41499
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 44)]
		protected ref struct __SetSightLockConfig_FunctionParams
		{
			// Token: 0x04032F89 RID: 208777
			[FieldOffset(0)]
			public float YawMin;

			// Token: 0x04032F8A RID: 208778
			[FieldOffset(4)]
			public float YawMax;

			// Token: 0x04032F8B RID: 208779
			[FieldOffset(8)]
			public float PitchMin;

			// Token: 0x04032F8C RID: 208780
			[FieldOffset(12)]
			public float PitchMax;

			// Token: 0x04032F8D RID: 208781
			[FieldOffset(16)]
			public float AssitLimit;

			// Token: 0x04032F8E RID: 208782
			[FieldOffset(20)]
			public FVector SightDirectInSightBone;

			// Token: 0x04032F8F RID: 208783
			[FieldOffset(32)]
			public FVector UpAxisInSightBone;
		}

		// Token: 0x0200A21C RID: 41500
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2080)]
		protected ref struct __ExecuteUbergraph_ABP_BaseRole_bakup_FunctionParams
		{
			// Token: 0x04032F90 RID: 208784
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
