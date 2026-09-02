using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.ABP_Gameplay
{
	// Token: 0x0200406E RID: 16494
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/ABP_Gameplay/ABP_BaseRole_Gameplay_Motor.ABP_BaseRole_Gameplay_Motor_C")]
	[UnrealStructLayout(8016, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 8009)]
	public class ABP_BaseRole_Gameplay_Motor_C : UKuroAnimInstance, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AB93 RID: 174995 RVA: 0x00A61F73 File Offset: 0x00A60173
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_BaseRole_Gameplay_Motor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/ABP_Gameplay/ABP_BaseRole_Gameplay_Motor.ABP_BaseRole_Gameplay_Motor_C");
			}
			return ABP_BaseRole_Gameplay_Motor_C._ClassPtr;
		}

		// Token: 0x0602AB94 RID: 174996 RVA: 0x00A61F98 File Offset: 0x00A60198
		public ABP_BaseRole_Gameplay_Motor_C() : this(BuiltinUtils.AllocNativeUObject(ABP_BaseRole_Gameplay_Motor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AB95 RID: 174997 RVA: 0x00A61FC0 File Offset: 0x00A601C0
		public ABP_BaseRole_Gameplay_Motor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_BaseRole_Gameplay_Motor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006F25 RID: 28453
		// (get) Token: 0x0602AB96 RID: 174998 RVA: 0x00A61FF4 File Offset: 0x00A601F4
		// (set) Token: 0x0602AB97 RID: 174999 RVA: 0x00A6202D File Offset: 0x00A6022D
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F26 RID: 28454
		// (get) Token: 0x0602AB98 RID: 175000 RVA: 0x00A62050 File Offset: 0x00A60250
		// (set) Token: 0x0602AB99 RID: 175001 RVA: 0x00A62089 File Offset: 0x00A60289
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F27 RID: 28455
		// (get) Token: 0x0602AB9A RID: 175002 RVA: 0x00A620AC File Offset: 0x00A602AC
		// (set) Token: 0x0602AB9B RID: 175003 RVA: 0x00A620E5 File Offset: 0x00A602E5
		public FAnimNode_ExtraFollowAnims AnimGraphNode_ExtraFollowAnims
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ExtraFollowAnims result;
				if ((result = this._AnimGraphNode_ExtraFollowAnims) == null)
				{
					result = (this._AnimGraphNode_ExtraFollowAnims = new FAnimNode_ExtraFollowAnims(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ExtraFollowAnims.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F28 RID: 28456
		// (get) Token: 0x0602AB9C RID: 175004 RVA: 0x00A62108 File Offset: 0x00A60308
		// (set) Token: 0x0602AB9D RID: 175005 RVA: 0x00A62141 File Offset: 0x00A60341
		public FAnimNode_ApplyAdditive AnimGraphNode_ApplyAdditive
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ApplyAdditive result;
				if ((result = this._AnimGraphNode_ApplyAdditive) == null)
				{
					result = (this._AnimGraphNode_ApplyAdditive = new FAnimNode_ApplyAdditive(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ApplyAdditive.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F29 RID: 28457
		// (get) Token: 0x0602AB9E RID: 175006 RVA: 0x00A62164 File Offset: 0x00A60364
		// (set) Token: 0x0602AB9F RID: 175007 RVA: 0x00A6219D File Offset: 0x00A6039D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_4) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_4 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F2A RID: 28458
		// (get) Token: 0x0602ABA0 RID: 175008 RVA: 0x00A621C0 File Offset: 0x00A603C0
		// (set) Token: 0x0602ABA1 RID: 175009 RVA: 0x00A621F9 File Offset: 0x00A603F9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_3) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_3 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F2B RID: 28459
		// (get) Token: 0x0602ABA2 RID: 175010 RVA: 0x00A6221C File Offset: 0x00A6041C
		// (set) Token: 0x0602ABA3 RID: 175011 RVA: 0x00A62255 File Offset: 0x00A60455
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_2) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_2 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F2C RID: 28460
		// (get) Token: 0x0602ABA4 RID: 175012 RVA: 0x00A62278 File Offset: 0x00A60478
		// (set) Token: 0x0602ABA5 RID: 175013 RVA: 0x00A622B1 File Offset: 0x00A604B1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_1) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_1 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F2D RID: 28461
		// (get) Token: 0x0602ABA6 RID: 175014 RVA: 0x00A622D4 File Offset: 0x00A604D4
		// (set) Token: 0x0602ABA7 RID: 175015 RVA: 0x00A6230D File Offset: 0x00A6050D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F2E RID: 28462
		// (get) Token: 0x0602ABA8 RID: 175016 RVA: 0x00A62330 File Offset: 0x00A60530
		// (set) Token: 0x0602ABA9 RID: 175017 RVA: 0x00A62369 File Offset: 0x00A60569
		public FAnimNode_MultiWayBlend AnimGraphNode_MultiWayBlend
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_MultiWayBlend result;
				if ((result = this._AnimGraphNode_MultiWayBlend) == null)
				{
					result = (this._AnimGraphNode_MultiWayBlend = new FAnimNode_MultiWayBlend(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_MultiWayBlend.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F2F RID: 28463
		// (get) Token: 0x0602ABAA RID: 175018 RVA: 0x00A6238C File Offset: 0x00A6058C
		// (set) Token: 0x0602ABAB RID: 175019 RVA: 0x00A623C5 File Offset: 0x00A605C5
		public FAnimNode_StateResult AnimGraphNode_StateResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult) == null)
				{
					result = (this._AnimGraphNode_StateResult = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F30 RID: 28464
		// (get) Token: 0x0602ABAC RID: 175020 RVA: 0x00A623E8 File Offset: 0x00A605E8
		// (set) Token: 0x0602ABAD RID: 175021 RVA: 0x00A62421 File Offset: 0x00A60621
		public FAnimNode_StateMachine AnimGraphNode_StateMachine
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine) == null)
				{
					result = (this._AnimGraphNode_StateMachine = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F31 RID: 28465
		// (get) Token: 0x0602ABAE RID: 175022 RVA: 0x00A62442 File Offset: 0x00A60642
		// (set) Token: 0x0602ABAF RID: 175023 RVA: 0x00A62452 File Offset: 0x00A60652
		public unsafe int VehicleEntityId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17006F32 RID: 28466
		// (get) Token: 0x0602ABB0 RID: 175024 RVA: 0x00A62464 File Offset: 0x00A60664
		// (set) Token: 0x0602ABB1 RID: 175025 RVA: 0x00A6249D File Offset: 0x00A6069D
		public TArray<float> 撞击混合
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._撞击混合) == null)
				{
					result = (this._撞击混合 = new TArray<float>(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				this.撞击混合.CopyAssign(value);
			}
		}

		// Token: 0x17006F33 RID: 28467
		// (get) Token: 0x0602ABB2 RID: 175026 RVA: 0x00A624AB File Offset: 0x00A606AB
		// (set) Token: 0x0602ABB3 RID: 175027 RVA: 0x00A624BB File Offset: 0x00A606BB
		public unsafe float 撞击倒计时
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17006F34 RID: 28468
		// (get) Token: 0x0602ABB4 RID: 175028 RVA: 0x00A624CC File Offset: 0x00A606CC
		// (set) Token: 0x0602ABB5 RID: 175029 RVA: 0x00A624E0 File Offset: 0x00A606E0
		[Nullable(2)]
		public unsafe AActor Vehicle
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_15);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17006F35 RID: 28469
		// (get) Token: 0x0602ABB6 RID: 175030 RVA: 0x00A624F5 File Offset: 0x00A606F5
		// (set) Token: 0x0602ABB7 RID: 175031 RVA: 0x00A62509 File Offset: 0x00A60709
		[Nullable(2)]
		public unsafe TsBaseCharacter 角色蓝图
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_16);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17006F36 RID: 28470
		// (get) Token: 0x0602ABB8 RID: 175032 RVA: 0x00A6251E File Offset: 0x00A6071E
		// (set) Token: 0x0602ABB9 RID: 175033 RVA: 0x00A6252E File Offset: 0x00A6072E
		public unsafe bool 禁用碰撞
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Motor_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602ABBA RID: 175034 RVA: 0x00A62540 File Offset: 0x00A60740
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_BaseRole_Gameplay_Motor_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_BaseRole_Gameplay_Motor_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_BaseRole_Gameplay_Motor_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_Gameplay_Motor_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Motor_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0602ABBB RID: 175035 RVA: 0x00A625C8 File Offset: 0x00A607C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 去掉HitNormal的Down(FVector HitNormal, ref FVector Result)
		{
			ABP_BaseRole_Gameplay_Motor_C.__去掉HitNormal的Down_FunctionParams* ptr = stackalloc ABP_BaseRole_Gameplay_Motor_C.__去掉HitNormal的Down_FunctionParams[(UIntPtr)99] + 15L / (long)sizeof(ABP_BaseRole_Gameplay_Motor_C.__去掉HitNormal的Down_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_Gameplay_Motor_C.__去掉HitNormal的Down_NativeFunctionPtr, (void*)ptr, 1);
			ptr->HitNormal = HitNormal;
			ptr->Result = Result;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Motor_C.__去掉HitNormal的Down_NativeFunctionPtr, (void*)ptr);
			Result = ptr->Result;
		}

		// Token: 0x0602ABBC RID: 175036 RVA: 0x00A62628 File Offset: 0x00A60828
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 计算碰撞反馈(float DeltaTime)
		{
			ABP_BaseRole_Gameplay_Motor_C.__计算碰撞反馈_FunctionParams* ptr = stackalloc ABP_BaseRole_Gameplay_Motor_C.__计算碰撞反馈_FunctionParams[(UIntPtr)511] + 15L / (long)sizeof(ABP_BaseRole_Gameplay_Motor_C.__计算碰撞反馈_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_Gameplay_Motor_C.__计算碰撞反馈_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Motor_C.__计算碰撞反馈_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602ABBD RID: 175037 RVA: 0x00A62674 File Offset: 0x00A60874
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetVehicle(int entityId)
		{
			ABP_BaseRole_Gameplay_Motor_C.__SetVehicle_FunctionParams* ptr = stackalloc ABP_BaseRole_Gameplay_Motor_C.__SetVehicle_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(ABP_BaseRole_Gameplay_Motor_C.__SetVehicle_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_Gameplay_Motor_C.__SetVehicle_NativeFunctionPtr, (void*)ptr, 1);
			ptr->entityId = entityId;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Motor_C.__SetVehicle_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602ABBE RID: 175038 RVA: 0x00A626BA File Offset: 0x00A608BA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Motor_AnimGraphNode_ApplyAdditive_D796E43F4FA99E38F4F5418E107C32F8()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Motor_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Motor_AnimGraphNode_ApplyAdditive_D796E43F4FA99E38F4F5418E107C32F8_NativeFunctionPtr, null);
		}

		// Token: 0x0602ABBF RID: 175039 RVA: 0x00A626D0 File Offset: 0x00A608D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void BlueprintUpdateAnimation(float DeltaTimeX)
		{
			ABP_BaseRole_Gameplay_Motor_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_BaseRole_Gameplay_Motor_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseRole_Gameplay_Motor_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_Gameplay_Motor_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Motor_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602ABC0 RID: 175040 RVA: 0x00A62718 File Offset: 0x00A60918
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BlueprintUpdateAnimation_Implementation(float DeltaTimeX)
		{
			ABP_BaseRole_Gameplay_Motor_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_BaseRole_Gameplay_Motor_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseRole_Gameplay_Motor_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_Gameplay_Motor_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Motor_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602ABC1 RID: 175041 RVA: 0x00A6275F File Offset: 0x00A6095F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BlueprintInitializeAnimation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Motor_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null);
		}

		// Token: 0x0602ABC2 RID: 175042 RVA: 0x00A62773 File Offset: 0x00A60973
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BlueprintInitializeAnimation_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Motor_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602ABC3 RID: 175043 RVA: 0x00A62788 File Offset: 0x00A60988
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_BaseRole_Gameplay_Motor(int EntryPoint)
		{
			ABP_BaseRole_Gameplay_Motor_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_Motor_FunctionParams* ptr = stackalloc ABP_BaseRole_Gameplay_Motor_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_Motor_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(ABP_BaseRole_Gameplay_Motor_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_Motor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_Gameplay_Motor_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_Motor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Motor_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_Motor_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602ABC4 RID: 175044 RVA: 0x00A627CF File Offset: 0x00A609CF
		protected ABP_BaseRole_Gameplay_Motor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401745D RID: 95325
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/ABP_Gameplay/ABP_BaseRole_Gameplay_Motor.ABP_BaseRole_Gameplay_Motor_C";

		// Token: 0x0401745E RID: 95326
		private static IntPtr _ClassPtr;

		// Token: 0x0401745F RID: 95327
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017460 RID: 95328
		internal static int __PropertyOffset_0;

		// Token: 0x04017461 RID: 95329
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017462 RID: 95330
		internal static int __PropertyOffset_1;

		// Token: 0x04017463 RID: 95331
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x04017464 RID: 95332
		internal static int __PropertyOffset_2;

		// Token: 0x04017465 RID: 95333
		[Nullable(2)]
		private FAnimNode_ExtraFollowAnims _AnimGraphNode_ExtraFollowAnims;

		// Token: 0x04017466 RID: 95334
		internal static int __PropertyOffset_3;

		// Token: 0x04017467 RID: 95335
		[Nullable(2)]
		private FAnimNode_ApplyAdditive _AnimGraphNode_ApplyAdditive;

		// Token: 0x04017468 RID: 95336
		internal static int __PropertyOffset_4;

		// Token: 0x04017469 RID: 95337
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_4;

		// Token: 0x0401746A RID: 95338
		internal static int __PropertyOffset_5;

		// Token: 0x0401746B RID: 95339
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_3;

		// Token: 0x0401746C RID: 95340
		internal static int __PropertyOffset_6;

		// Token: 0x0401746D RID: 95341
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_2;

		// Token: 0x0401746E RID: 95342
		internal static int __PropertyOffset_7;

		// Token: 0x0401746F RID: 95343
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_1;

		// Token: 0x04017470 RID: 95344
		internal static int __PropertyOffset_8;

		// Token: 0x04017471 RID: 95345
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x04017472 RID: 95346
		internal static int __PropertyOffset_9;

		// Token: 0x04017473 RID: 95347
		[Nullable(2)]
		private FAnimNode_MultiWayBlend _AnimGraphNode_MultiWayBlend;

		// Token: 0x04017474 RID: 95348
		internal static int __PropertyOffset_10;

		// Token: 0x04017475 RID: 95349
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult;

		// Token: 0x04017476 RID: 95350
		internal static int __PropertyOffset_11;

		// Token: 0x04017477 RID: 95351
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine;

		// Token: 0x04017478 RID: 95352
		internal static int __PropertyOffset_12;

		// Token: 0x04017479 RID: 95353
		internal static int __PropertyOffset_13;

		// Token: 0x0401747A RID: 95354
		[Nullable(2)]
		private TArray<float> _撞击混合;

		// Token: 0x0401747B RID: 95355
		internal static int __PropertyOffset_14;

		// Token: 0x0401747C RID: 95356
		internal static int __PropertyOffset_15;

		// Token: 0x0401747D RID: 95357
		internal static int __PropertyOffset_16;

		// Token: 0x0401747E RID: 95358
		internal static int __PropertyOffset_17;

		// Token: 0x0401747F RID: 95359
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x04017480 RID: 95360
		private static IntPtr __去掉HitNormal的Down_NativeFunctionPtr;

		// Token: 0x04017481 RID: 95361
		private static IntPtr __计算碰撞反馈_NativeFunctionPtr;

		// Token: 0x04017482 RID: 95362
		private static IntPtr __SetVehicle_NativeFunctionPtr;

		// Token: 0x04017483 RID: 95363
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Motor_AnimGraphNode_ApplyAdditive_D796E43F4FA99E38F4F5418E107C32F8_NativeFunctionPtr;

		// Token: 0x04017484 RID: 95364
		private static IntPtr __BlueprintUpdateAnimation_NativeFunctionPtr;

		// Token: 0x04017485 RID: 95365
		private static IntPtr __BlueprintInitializeAnimation_NativeFunctionPtr;

		// Token: 0x04017486 RID: 95366
		private static IntPtr __ExecuteUbergraph_ABP_BaseRole_Gameplay_Motor_NativeFunctionPtr;

		// Token: 0x0200A256 RID: 41558
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x04032FFF RID: 208895
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A257 RID: 41559
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 84)]
		protected ref struct __去掉HitNormal的Down_FunctionParams
		{
			// Token: 0x04033000 RID: 208896
			[FieldOffset(0)]
			public FVector HitNormal;

			// Token: 0x04033001 RID: 208897
			[FieldOffset(12)]
			public FVector Result;
		}

		// Token: 0x0200A258 RID: 41560
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 496)]
		protected ref struct __计算碰撞反馈_FunctionParams
		{
			// Token: 0x04033002 RID: 208898
			[FieldOffset(0)]
			public float DeltaTime;
		}

		// Token: 0x0200A259 RID: 41561
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __SetVehicle_FunctionParams
		{
			// Token: 0x04033003 RID: 208899
			[FieldOffset(0)]
			public int entityId;
		}

		// Token: 0x0200A25A RID: 41562
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __BlueprintUpdateAnimation_FunctionParams
		{
			// Token: 0x04033004 RID: 208900
			[FieldOffset(0)]
			public float DeltaTimeX;
		}

		// Token: 0x0200A25B RID: 41563
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __ExecuteUbergraph_ABP_BaseRole_Gameplay_Motor_FunctionParams
		{
			// Token: 0x04033005 RID: 208901
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
