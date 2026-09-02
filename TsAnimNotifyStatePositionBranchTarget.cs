using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D65 RID: 3429
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStatePositionBranchTarget.TsAnimNotifyStatePositionBranchTarget_C")]
public class TsAnimNotifyStatePositionBranchTarget : TsAnimNotifyStateBase, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x0600499C RID: 18844 RVA: 0x0009EC63 File Offset: 0x0009CE63
	static TsAnimNotifyStatePositionBranchTarget()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsAnimNotifyStatePositionBranchTarget.CreateStaticDefaultValue), new Action(TsAnimNotifyStatePositionBranchTarget.ResetStaticDefaultValue));
	}

	// Token: 0x0600499D RID: 18845 RVA: 0x0009EC82 File Offset: 0x0009CE82
	public static void CreateStaticDefaultValue()
	{
		TsAnimNotifyStatePositionBranchTarget._paramPool = new List<PositionBranchTargetParams>();
		TsAnimNotifyStatePositionBranchTarget._paramMap = new Dictionary<int, PositionBranchTargetParams>();
	}

	// Token: 0x0600499E RID: 18846 RVA: 0x0009EC98 File Offset: 0x0009CE98
	public static void ResetStaticDefaultValue()
	{
		TsAnimNotifyStatePositionBranchTarget._paramPool = null;
		TsAnimNotifyStatePositionBranchTarget._paramMap = null;
	}

	// Token: 0x1700040B RID: 1035
	// (get) Token: 0x0600499F RID: 18847 RVA: 0x0009ECA6 File Offset: 0x0009CEA6
	// (set) Token: 0x060049A0 RID: 18848 RVA: 0x0009ECBA File Offset: 0x0009CEBA
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UCurveFloat MoveCurve
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_MoveCurve);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_MoveCurve, value);
		}
	}

	// Token: 0x1700040C RID: 1036
	// (get) Token: 0x060049A1 RID: 18849 RVA: 0x0009ECCF File Offset: 0x0009CECF
	// (set) Token: 0x060049A2 RID: 18850 RVA: 0x0009ECDF File Offset: 0x0009CEDF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Distance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_Distance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_Distance) = value;
		}
	}

	// Token: 0x1700040D RID: 1037
	// (get) Token: 0x060049A3 RID: 18851 RVA: 0x0009ECF0 File Offset: 0x0009CEF0
	// (set) Token: 0x060049A4 RID: 18852 RVA: 0x0009ED00 File Offset: 0x0009CF00
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MaxSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_MaxSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_MaxSpeed) = value;
		}
	}

	// Token: 0x1700040E RID: 1038
	// (get) Token: 0x060049A5 RID: 18853 RVA: 0x0009ED11 File Offset: 0x0009CF11
	// (set) Token: 0x060049A6 RID: 18854 RVA: 0x0009ED21 File Offset: 0x0009CF21
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 是否永远面向目标
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_是否永远面向目标) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_是否永远面向目标) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700040F RID: 1039
	// (get) Token: 0x060049A7 RID: 18855 RVA: 0x0009ED32 File Offset: 0x0009CF32
	// (set) Token: 0x060049A8 RID: 18856 RVA: 0x0009ED42 File Offset: 0x0009CF42
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 忽略Z轴方向
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_忽略Z轴方向) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_忽略Z轴方向) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000410 RID: 1040
	// (get) Token: 0x060049A9 RID: 18857 RVA: 0x0009ED53 File Offset: 0x0009CF53
	// (set) Token: 0x060049AA RID: 18858 RVA: 0x0009ED63 File Offset: 0x0009CF63
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 忽略水平方向
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_忽略水平方向) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_忽略水平方向) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000411 RID: 1041
	// (get) Token: 0x060049AB RID: 18859 RVA: 0x0009ED74 File Offset: 0x0009CF74
	// (set) Token: 0x060049AC RID: 18860 RVA: 0x0009ED84 File Offset: 0x0009CF84
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 永远修正Z轴
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_永远修正Z轴) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_永远修正Z轴) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000412 RID: 1042
	// (get) Token: 0x060049AD RID: 18861 RVA: 0x0009ED95 File Offset: 0x0009CF95
	// (set) Token: 0x060049AE RID: 18862 RVA: 0x0009EDA5 File Offset: 0x0009CFA5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 忽略双方半径
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_忽略双方半径) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_忽略双方半径) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000413 RID: 1043
	// (get) Token: 0x060049AF RID: 18863 RVA: 0x0009EDB6 File Offset: 0x0009CFB6
	// (set) Token: 0x060049B0 RID: 18864 RVA: 0x0009EDC6 File Offset: 0x0009CFC6
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsShareTarget
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_IsShareTarget) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_IsShareTarget) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000414 RID: 1044
	// (get) Token: 0x060049B1 RID: 18865 RVA: 0x0009EDD7 File Offset: 0x0009CFD7
	// (set) Token: 0x060049B2 RID: 18866 RVA: 0x0009EDEB File Offset: 0x0009CFEB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector TargetOffset
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_TargetOffset);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_TargetOffset) = value;
		}
	}

	// Token: 0x17000415 RID: 1045
	// (get) Token: 0x060049B3 RID: 18867 RVA: 0x0009EE00 File Offset: 0x0009D000
	// (set) Token: 0x060049B4 RID: 18868 RVA: 0x0009EE14 File Offset: 0x0009D014
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FRotator TargetRotation
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_TargetRotation);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_TargetRotation) = value;
		}
	}

	// Token: 0x17000416 RID: 1046
	// (get) Token: 0x060049B5 RID: 18869 RVA: 0x0009EE29 File Offset: 0x0009D029
	// (set) Token: 0x060049B6 RID: 18870 RVA: 0x0009EE39 File Offset: 0x0009D039
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool OffsetByOrientation
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_OffsetByOrientation) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_OffsetByOrientation) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000417 RID: 1047
	// (get) Token: 0x060049B7 RID: 18871 RVA: 0x0009EE4A File Offset: 0x0009D04A
	// (set) Token: 0x060049B8 RID: 18872 RVA: 0x0009EE5A File Offset: 0x0009D05A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool OffsetByAbsolute
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_OffsetByAbsolute) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_OffsetByAbsolute) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000418 RID: 1048
	// (get) Token: 0x060049B9 RID: 18873 RVA: 0x0009EE6B File Offset: 0x0009D06B
	// (set) Token: 0x060049BA RID: 18874 RVA: 0x0009EE7B File Offset: 0x0009D07B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MinHeightFromTargetFloor
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_MinHeightFromTargetFloor);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_MinHeightFromTargetFloor) = value;
		}
	}

	// Token: 0x17000419 RID: 1049
	// (get) Token: 0x060049BB RID: 18875 RVA: 0x0009EE8C File Offset: 0x0009D08C
	// (set) Token: 0x060049BC RID: 18876 RVA: 0x0009EE9C File Offset: 0x0009D09C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 允许反向移动
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_允许反向移动) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_允许反向移动) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700041A RID: 1050
	// (get) Token: 0x060049BD RID: 18877 RVA: 0x0009EEAD File Offset: 0x0009D0AD
	// (set) Token: 0x060049BE RID: 18878 RVA: 0x0009EEBD File Offset: 0x0009D0BD
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 允许正向移动
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_允许正向移动) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_允许正向移动) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700041B RID: 1051
	// (get) Token: 0x060049BF RID: 18879 RVA: 0x0009EECE File Offset: 0x0009D0CE
	// (set) Token: 0x060049C0 RID: 18880 RVA: 0x0009EEDE File Offset: 0x0009D0DE
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EAnsBranchTargetBlackboardType 黑板类型
	{
		get
		{
			return (EAnsBranchTargetBlackboardType)(*(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_黑板类型));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_黑板类型) = (byte)value;
		}
	}

	// Token: 0x1700041C RID: 1052
	// (get) Token: 0x060049C1 RID: 18881 RVA: 0x0009EEEF File Offset: 0x0009D0EF
	// (set) Token: 0x060049C2 RID: 18882 RVA: 0x0009EF03 File Offset: 0x0009D103
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string 黑板值
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_黑板值)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_黑板值)), value);
		}
	}

	// Token: 0x1700041D RID: 1053
	// (get) Token: 0x060049C3 RID: 18883 RVA: 0x0009EF18 File Offset: 0x0009D118
	// (set) Token: 0x060049C4 RID: 18884 RVA: 0x0009EF2C File Offset: 0x0009D12C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string 黑板目标Socket
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_黑板目标Socket)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_黑板目标Socket)), value);
		}
	}

	// Token: 0x1700041E RID: 1054
	// (get) Token: 0x060049C5 RID: 18885 RVA: 0x0009EF41 File Offset: 0x0009D141
	// (set) Token: 0x060049C6 RID: 18886 RVA: 0x0009EF51 File Offset: 0x0009D151
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 最小吸附距离
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_最小吸附距离);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_最小吸附距离) = value;
		}
	}

	// Token: 0x1700041F RID: 1055
	// (get) Token: 0x060049C7 RID: 18887 RVA: 0x0009EF62 File Offset: 0x0009D162
	// (set) Token: 0x060049C8 RID: 18888 RVA: 0x0009EF72 File Offset: 0x0009D172
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 最大吸附距离
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_最大吸附距离);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionBranchTarget.__PropertyOffset_最大吸附距离) = value;
		}
	}

	// Token: 0x060049C9 RID: 18889 RVA: 0x0009EF84 File Offset: 0x0009D184
	private void Initialize()
	{
		if (this.IsInitialize && !GlobalData.IsPlayInEditor)
		{
			return;
		}
		this.IsInitialize = true;
		this.TsMoveCurve = this.MoveCurve;
		this.TsDistance = this.Distance;
		this.TsMaxDistance = this.最大吸附距离;
		this.TsMinDistance = this.最小吸附距离;
		this.TsMaxSpeed = this.MaxSpeed;
		this.TsLookAtTarget = this.是否永远面向目标;
		this.TsIgnoreZ = this.忽略Z轴方向;
		this.TsIgnoreHorizontal = this.忽略水平方向;
		this.TsAlwaysMoveZ = this.永远修正Z轴;
		this.TsIgnoreRadius = this.忽略双方半径;
		this.TsIsShareTarget = this.IsShareTarget;
		this.TsAllowReverseMovement = this.允许反向移动;
		this.TsAllowForwardMovement = this.允许正向移动;
		this.TsBlackboardKey = this.黑板值;
		this.TsBlackboardType = this.黑板类型;
		this.TsBlackboardSocket = this.黑板目标Socket;
		this.TsTargetOffset = Vector.Create(this.TargetOffset);
		this.TmpRotator = Rotator.Create();
		Rotator tmpRotator = this.TmpRotator;
		FRotator targetRotation = this.TargetRotation;
		tmpRotator.DeepCopy(targetRotation);
		this.TmpQuat.Reset();
		this.TmpRotator.Quaternion(this.TmpQuat);
		this.TmpQuat.RotateVector(this.TsTargetOffset, this.TsTargetOffset);
		this.TsMinHeightFromTargetFloor = this.MinHeightFromTargetFloor;
		this.TargetPos.Reset();
		this.TmpVector.Reset();
		this.TmpVector2.Reset();
	}

	// Token: 0x060049CA RID: 18890 RVA: 0x0009F100 File Offset: 0x0009D300
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyBegin(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyBegin"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->TotalDuration = totalDuration;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x060049CB RID: 18891 RVA: 0x0009F1A8 File Offset: 0x0009D3A8
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		this.Initialize();
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter) && !(owner is TsBaseVehicle))
		{
			return false;
		}
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		object obj;
		if (tsBaseCharacter == null)
		{
			obj = null;
		}
		else
		{
			Entity entityNoBlueprint = tsBaseCharacter.GetEntityNoBlueprint();
			obj = ((entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<BaseActorComponent>() : null);
		}
		object obj2;
		if ((obj2 = obj) == null)
		{
			TsBaseVehicle tsBaseVehicle = owner as TsBaseVehicle;
			if (tsBaseVehicle == null)
			{
				obj2 = null;
			}
			else
			{
				Entity entityNoBlueprint2 = tsBaseVehicle.GetEntityNoBlueprint();
				obj2 = ((entityNoBlueprint2 != null) ? entityNoBlueprint2.GetComponent<BaseActorComponent>() : null);
			}
		}
		BaseActorComponent baseActorComponent = obj2;
		if (baseActorComponent == null)
		{
			return false;
		}
		BaseSkillComponent component = baseActorComponent.Entity.GetComponent<BaseSkillComponent>();
		BaseSkillComponent baseSkillComponent;
		if (this.TsIsShareTarget)
		{
			CreatureDataComponent component2 = baseActorComponent.Entity.GetComponent<CreatureDataComponent>();
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(component2.GetSummonerId());
			WorldEntity worldEntity = (entity != null) ? entity.Entity : null;
			baseSkillComponent = ((worldEntity != null) ? worldEntity.GetComponent<BaseSkillComponent>() : null);
			if (baseSkillComponent == null)
			{
				baseSkillComponent = component;
			}
		}
		else
		{
			baseSkillComponent = component;
		}
		if (baseSkillComponent == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "No SkillComponent";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor", baseActorComponent.Owner);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		if (TsAnimNotifyStatePositionBranchTarget._paramPool == null || TsAnimNotifyStatePositionBranchTarget._paramMap == null)
		{
			return false;
		}
		PositionBranchTargetParams positionBranchTargetParams;
		if (!TsAnimNotifyStatePositionBranchTarget._paramMap.TryGetValue(baseActorComponent.Entity.Id, out positionBranchTargetParams) || positionBranchTargetParams == null)
		{
			if (TsAnimNotifyStatePositionBranchTarget._paramPool.Count > 0)
			{
				positionBranchTargetParams = TsAnimNotifyStatePositionBranchTarget._paramPool[TsAnimNotifyStatePositionBranchTarget._paramPool.Count - 1];
				TsAnimNotifyStatePositionBranchTarget._paramPool.RemoveAt(TsAnimNotifyStatePositionBranchTarget._paramPool.Count - 1);
			}
			else
			{
				positionBranchTargetParams = new PositionBranchTargetParams();
			}
		}
		positionBranchTargetParams.BaseActorComp = baseActorComponent;
		positionBranchTargetParams.BaseUnifiedComp = baseActorComponent.Entity.GetComponent<BaseUnifiedStateComponent>();
		positionBranchTargetParams.BaseSkillComp = baseSkillComponent;
		positionBranchTargetParams.NowTime = 0f;
		positionBranchTargetParams.TotalTime = totalDuration;
		if (!positionBranchTargetParams.RefreshTarget(this.TsBlackboardKey, this.TsBlackboardType, this.TsBlackboardSocket))
		{
			return true;
		}
		TsBaseCharacter tsBaseCharacter2 = owner as TsBaseCharacter;
		int key = (tsBaseCharacter2 != null) ? tsBaseCharacter2.GetEntityIdNoBlueprint() : (owner as TsBaseVehicle).GetEntityIdNoBlueprint();
		TsAnimNotifyStatePositionBranchTarget._paramMap[key] = positionBranchTargetParams;
		return true;
	}

	// Token: 0x060049CC RID: 18892 RVA: 0x0009F398 File Offset: 0x0009D598
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyTick(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->FrameDeltaTime = frameDeltaTime;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x060049CD RID: 18893 RVA: 0x0009F440 File Offset: 0x0009D640
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		if ((double)frameDeltaTime < 0.0001)
		{
			return false;
		}
		AActor owner = meshComp.GetOwner();
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		TsBaseVehicle tsBaseVehicle = owner as TsBaseVehicle;
		if (tsBaseCharacter == null && tsBaseVehicle == null)
		{
			return false;
		}
		int key = (tsBaseCharacter != null) ? tsBaseCharacter.GetEntityIdNoBlueprint() : tsBaseVehicle.GetEntityIdNoBlueprint();
		if (TsAnimNotifyStatePositionBranchTarget._paramMap == null)
		{
			return false;
		}
		PositionBranchTargetParams positionBranchTargetParams;
		if (!TsAnimNotifyStatePositionBranchTarget._paramMap.TryGetValue(key, out positionBranchTargetParams) || positionBranchTargetParams == null)
		{
			return false;
		}
		if (positionBranchTargetParams.RefreshTarget(this.TsBlackboardKey, this.TsBlackboardType, this.TsBlackboardSocket))
		{
			this.MoveToTarget(frameDeltaTime, positionBranchTargetParams);
			positionBranchTargetParams.LastLocation.DeepCopy(positionBranchTargetParams.BaseActorComp.ActorLocationProxy);
		}
		positionBranchTargetParams.NowTime += frameDeltaTime;
		return true;
	}

	// Token: 0x060049CE RID: 18894 RVA: 0x0009F4F0 File Offset: 0x0009D6F0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyEnd(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyEnd"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x060049CF RID: 18895 RVA: 0x0009F590 File Offset: 0x0009D790
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		if (TsAnimNotifyStatePositionBranchTarget._paramPool == null || TsAnimNotifyStatePositionBranchTarget._paramMap == null)
		{
			return false;
		}
		PositionBranchTargetParams positionBranchTargetParams;
		if (!TsAnimNotifyStatePositionBranchTarget._paramMap.TryGetValue(characterActorComponent.Entity.Id, out positionBranchTargetParams) || positionBranchTargetParams == null)
		{
			return false;
		}
		TsAnimNotifyStatePositionBranchTarget._paramMap.Remove(characterActorComponent.Entity.Id);
		positionBranchTargetParams.Clear();
		TsAnimNotifyStatePositionBranchTarget._paramPool.Add(positionBranchTargetParams);
		return true;
	}

	// Token: 0x060049D0 RID: 18896 RVA: 0x0009F60C File Offset: 0x0009D80C
	private void GetTargetPos(PositionBranchTargetParams @params, Vector outVector)
	{
		if (@params.TargetPos != null)
		{
			outVector.DeepCopy(@params.TargetPos);
			if (this.OffsetByAbsolute)
			{
				this.TmpVector.DeepCopy(this.TsTargetOffset);
			}
			else
			{
				if (this.OffsetByOrientation)
				{
					outVector.Subtraction(@params.BaseActorComp.ActorLocationProxy, this.TmpVector);
				}
				else
				{
					@params.BaseActorComp.ActorLocationProxy.Subtraction(outVector, this.TmpVector);
				}
				this.TmpVector.ToOrientationQuat(this.TmpQuat);
				this.TmpQuat.RotateVector(this.TsTargetOffset, this.TmpVector);
			}
			outVector.AdditionEqual(this.TmpVector);
			return;
		}
		if (!string.IsNullOrEmpty(@params.SocketName))
		{
			CharacterActorComponent targetCharActorComp = @params.TargetCharActorComp;
			if (((targetCharActorComp != null) ? targetCharActorComp.Actor : null) != null)
			{
				FName inSocketName = FNameUtil.GetDynamicFName(@params.SocketName) ?? FName.NAME_None;
				FVectorDouble fvectorDouble = @params.TargetCharActorComp.Actor.Mesh.D_GetSocketLocation(inSocketName);
				outVector.FromUeVector(fvectorDouble);
			}
			else
			{
				outVector.DeepCopy(@params.TargetBaseActorComp.ActorLocationProxy);
			}
		}
		else
		{
			outVector.DeepCopy(@params.TargetBaseActorComp.ActorLocationProxy);
		}
		if (this.OffsetByAbsolute)
		{
			this.TmpVector.DeepCopy(this.TsTargetOffset);
		}
		else if (this.OffsetByOrientation)
		{
			outVector.Subtraction(@params.BaseActorComp.ActorLocationProxy, this.TmpVector);
			this.TmpVector.ToOrientationQuat(this.TmpQuat);
			this.TmpQuat.RotateVector(this.TsTargetOffset, this.TmpVector);
		}
		else
		{
			@params.TargetBaseActorComp.ActorQuatProxy.RotateVector(this.TsTargetOffset, this.TmpVector);
		}
		outVector.AdditionEqual(this.TmpVector);
		if (@params.TargetCharActorComp != null)
		{
			double num = Singleton<GravityUtils>.Instance.GetZnInGravityForActor(@params.TargetBaseActorComp, @params.TargetCharActorComp.FloorLocation) + (double)this.TsMinHeightFromTargetFloor;
			double znInGravityForActor = Singleton<GravityUtils>.Instance.GetZnInGravityForActor(@params.TargetBaseActorComp, outVector);
			if (num > znInGravityForActor)
			{
				Singleton<GravityUtils>.Instance.AddZnInGravityForActor(@params.TargetBaseActorComp, outVector, num - znInGravityForActor);
			}
		}
	}

	// Token: 0x060049D1 RID: 18897 RVA: 0x0009F82C File Offset: 0x0009DA2C
	private double GetTowardVector(PositionBranchTargetParams @params, Vector outVector)
	{
		this.GetTargetPos(@params, this.TargetPos);
		this.TargetPos.Subtraction(@params.BaseActorComp.ActorLocationProxy, this.TmpVector);
		this.TargetPos.Subtraction(@params.LastLocation, this.TmpVector2);
		double num = this.TmpVector.DotProduct(this.TmpVector2);
		outVector.DeepCopy(this.TmpVector);
		if (this.TsIgnoreZ)
		{
			Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(@params.BaseActorComp, outVector);
			if (num >= 0.0)
			{
				return outVector.Size();
			}
			return -1.0;
		}
		else if (this.TsIgnoreHorizontal)
		{
			Singleton<GravityUtils>.Instance.ConvertToVerticalVectorForActor(@params.BaseActorComp, outVector);
			if (num >= 0.0)
			{
				return outVector.Size();
			}
			return -1.0;
		}
		else
		{
			if (num >= 0.0)
			{
				return Math.Sqrt(Singleton<GravityUtils>.Instance.GetPlanarSizeSquared2dForActor(@params.BaseActorComp, outVector));
			}
			return -1.0;
		}
	}

	// Token: 0x060049D2 RID: 18898 RVA: 0x0009F934 File Offset: 0x0009DB34
	private double GetRate(float delta, PositionBranchTargetParams @params)
	{
		float num = @params.NowTime + delta;
		double result;
		if (@params.TotalTime <= num)
		{
			result = 1.0;
		}
		else if (this.TsMoveCurve != null)
		{
			float floatValue = this.TsMoveCurve.GetFloatValue(@params.NowTime / @params.TotalTime);
			float floatValue2 = this.TsMoveCurve.GetFloatValue(num / @params.TotalTime);
			if (floatValue >= 1f)
			{
				return 0.0;
			}
			result = (double)((floatValue2 - floatValue) / (1f - floatValue));
		}
		else
		{
			double cubicValue = Singleton<MathUtils>.Instance.GetCubicValue((double)(@params.NowTime / @params.TotalTime));
			double cubicValue2 = Singleton<MathUtils>.Instance.GetCubicValue((double)(num / @params.TotalTime));
			if (cubicValue >= 1.0)
			{
				return 0.0;
			}
			result = (cubicValue2 - cubicValue) / (1.0 - cubicValue);
		}
		return result;
	}

	// Token: 0x060049D3 RID: 18899 RVA: 0x0009FA1C File Offset: 0x0009DC1C
	private unsafe void MoveToTarget(float delta, PositionBranchTargetParams @params)
	{
		double towardVector = this.GetTowardVector(@params, this.TmpVector);
		if (this.TsMinDistance > 0f && towardVector < (double)this.TsMinDistance)
		{
			return;
		}
		if (this.TsMaxDistance > 0f && towardVector > (double)this.TsMaxDistance)
		{
			return;
		}
		double num = (double)this.TsDistance;
		if (!this.TsIgnoreRadius)
		{
			num += (double)@params.BaseActorComp.ScaledRadius;
			if (@params.TargetCharActorComp != null && string.IsNullOrEmpty(@params.SocketName))
			{
				num += (double)@params.TargetCharActorComp.ScaledRadius;
			}
		}
		if (towardVector > 0.0001 && ((num < towardVector && this.TsAllowForwardMovement) || (num > towardVector && this.TsAllowReverseMovement)))
		{
			if (this.TsMaxSpeed <= 0f)
			{
				return;
			}
			double rate = this.GetRate(delta, @params);
			if (rate <= 0.0)
			{
				return;
			}
			double num2 = this.TmpVector.Size();
			double num3 = Singleton<MathUtils>.Instance.Clamp((num2 - num) * rate, (double)(-(double)this.TsMaxSpeed * delta), (double)(this.TsMaxSpeed * delta));
			this.TmpVector.MultiplyEqual(num3 / num2);
		}
		else
		{
			@params.LastLocation.Subtraction(@params.BaseActorComp.ActorLocationProxy, this.TmpVector);
			if (this.TsAlwaysMoveZ && !this.TsIgnoreZ)
			{
				double rate2 = this.GetRate(delta, @params);
				this.TargetPos.Subtraction(@params.BaseActorComp.ActorLocationProxy, this.TmpVector2);
				double newZ = Singleton<MathUtils>.Instance.Clamp(Singleton<GravityUtils>.Instance.GetZnInGravityForActor(@params.BaseActorComp, this.TmpVector2) * rate2, (double)(-(double)this.TsMaxSpeed * delta), (double)(this.TsMaxSpeed * delta));
				Singleton<GravityUtils>.Instance.SetZnInGravityForActor(@params.BaseActorComp, this.TmpVector, newZ);
			}
			else
			{
				Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(@params.BaseActorComp, this.TmpVector);
			}
			if (this.TmpVector.SizeSquared() > 4000000.0)
			{
				this.TmpVector.Reset();
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.LCZ;
				string message = "LastLocation太远，很危险，无视掉";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
				string item = "Actor";
				BaseActorComponent baseActorComp = @params.BaseActorComp;
				ptr = new ValueTuple<string, object>(item, (baseActorComp != null) ? baseActorComp.Owner : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Last", @params.LastLocation);
				ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
				string item2 = "ActorLast";
				BaseActorComponent baseActorComp2 = @params.BaseActorComp;
				ptr2 = new ValueTuple<string, object>(item2, (baseActorComp2 != null) ? baseActorComp2.LastActorLocation : null);
				ref ValueTuple<string, object> ptr3 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3);
				string item3 = "Now";
				BaseActorComponent baseActorComp3 = @params.BaseActorComp;
				ptr3 = new ValueTuple<string, object>(item3, (baseActorComp3 != null) ? baseActorComp3.ActorLocationProxy : null);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			}
		}
		BaseActorComponent baseActorComp4 = @params.BaseActorComp;
		BaseMoveComponent baseMoveComponent = (baseActorComp4 != null) ? baseActorComp4.MoveComp : null;
		if (baseMoveComponent != null)
		{
			baseMoveComponent.MoveCharacter(this.TmpVector, delta, "TsAnimNotifyStatePositionBranchTarget");
			if (this.TsLookAtTarget)
			{
				this.TargetPos.Subtraction(@params.BaseActorComp.ActorLocationProxy, this.TmpVector);
				Vector gravityUp = baseMoveComponent.GravityUp;
				Singleton<MathUtils>.Instance.LookRotationUpFirst(this.TmpVector, gravityUp, this.TmpQuat);
				this.TmpQuat.Rotator(this.TmpRotator);
				@params.BaseActorComp.SetActorRotation(this.TmpRotator.ToUeRotator(), "TsAnimNotifyStatePositionBranchTarget", false);
				return;
			}
		}
		else
		{
			this.TmpVector.AdditionEqual(@params.BaseActorComp.ActorLocationProxy);
			if (this.TsLookAtTarget)
			{
				BaseActorComponent baseActorComp5 = @params.BaseActorComp;
				Vector vector;
				if (baseActorComp5 == null)
				{
					vector = null;
				}
				else
				{
					VehicleMoveComponent vehicleMoveComp = baseActorComp5.VehicleMoveComp;
					vector = ((vehicleMoveComp != null) ? vehicleMoveComp.GravityUp : null);
				}
				Vector up = vector ?? Vector.UpVectorProxy;
				Singleton<MathUtils>.Instance.LookRotationUpFirst(this.TmpVector, up, this.TmpQuat);
				this.TmpQuat.Rotator(this.TmpRotator);
				BaseActorComponent baseActorComp6 = @params.BaseActorComp;
				if (baseActorComp6 == null)
				{
					return;
				}
				baseActorComp6.SetActorLocationAndRotation(this.TmpVector.ToUeVector(false), this.TmpRotator.ToUeRotator(), "TsAnimNotifyStatePositionBranchTarget", true, null);
				return;
			}
			else
			{
				BaseActorComponent baseActorComp7 = @params.BaseActorComp;
				if (baseActorComp7 == null)
				{
					return;
				}
				baseActorComp7.SetActorLocation(this.TmpVector.ToUeVector(false), "TsAnimNotifyStatePositionBranchTarget", true);
			}
		}
	}

	// Token: 0x060049D4 RID: 18900 RVA: 0x0009FE58 File Offset: 0x0009E058
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotifyState.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotifyState.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotifyState.__GetNotifyName_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		string result = FString.ToString((void*)(&ptr2->__Result));
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x060049D5 RID: 18901 RVA: 0x0009FED3 File Offset: 0x0009E0D3
	protected override string GetNotifyName_Implementation()
	{
		return "位移吸附到目标位置";
	}

	// Token: 0x060049D6 RID: 18902 RVA: 0x0009FEDA File Offset: 0x0009E0DA
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStatePositionBranchTarget._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStatePositionBranchTarget.TsAnimNotifyStatePositionBranchTarget_C");
		}
		return TsAnimNotifyStatePositionBranchTarget._ClassPtr;
	}

	// Token: 0x060049D7 RID: 18903 RVA: 0x0009FF00 File Offset: 0x0009E100
	public TsAnimNotifyStatePositionBranchTarget() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStatePositionBranchTarget.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060049D8 RID: 18904 RVA: 0x0009FF28 File Offset: 0x0009E128
	public TsAnimNotifyStatePositionBranchTarget(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStatePositionBranchTarget.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060049D9 RID: 18905 RVA: 0x0009FF5C File Offset: 0x0009E15C
	protected TsAnimNotifyStatePositionBranchTarget(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060049DA RID: 18906 RVA: 0x0009FFE4 File Offset: 0x0009E1E4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x060049DB RID: 18907 RVA: 0x000A0020 File Offset: 0x0009E220
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x060049DC RID: 18908 RVA: 0x000A005C File Offset: 0x0009E25C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060049DD RID: 18909 RVA: 0x000A008F File Offset: 0x0009E28F
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040014A9 RID: 5289
	private const double INVALID_LAST_LOCATION_THRESHOLD_SQUARED = 4000000.0;

	// Token: 0x040014AA RID: 5290
	private bool IsInitialize;

	// Token: 0x040014AB RID: 5291
	[Nullable(2)]
	private UCurveFloat TsMoveCurve;

	// Token: 0x040014AC RID: 5292
	private float TsDistance;

	// Token: 0x040014AD RID: 5293
	private float TsMaxDistance;

	// Token: 0x040014AE RID: 5294
	private float TsMinDistance;

	// Token: 0x040014AF RID: 5295
	private float TsMaxSpeed;

	// Token: 0x040014B0 RID: 5296
	private bool TsLookAtTarget;

	// Token: 0x040014B1 RID: 5297
	private bool TsIgnoreZ;

	// Token: 0x040014B2 RID: 5298
	private bool TsIgnoreHorizontal;

	// Token: 0x040014B3 RID: 5299
	private bool TsAlwaysMoveZ;

	// Token: 0x040014B4 RID: 5300
	private bool TsIgnoreRadius;

	// Token: 0x040014B5 RID: 5301
	private bool TsIsShareTarget;

	// Token: 0x040014B6 RID: 5302
	private Vector TsTargetOffset = Vector.Create();

	// Token: 0x040014B7 RID: 5303
	private float TsMinHeightFromTargetFloor;

	// Token: 0x040014B8 RID: 5304
	private readonly Vector TargetPos = Vector.Create();

	// Token: 0x040014B9 RID: 5305
	private readonly Vector TmpVector = Vector.Create();

	// Token: 0x040014BA RID: 5306
	private readonly Vector TmpVector2 = Vector.Create();

	// Token: 0x040014BB RID: 5307
	private Rotator TmpRotator = Rotator.Create();

	// Token: 0x040014BC RID: 5308
	private readonly Quat TmpQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x040014BD RID: 5309
	private bool TsAllowReverseMovement;

	// Token: 0x040014BE RID: 5310
	private bool TsAllowForwardMovement = true;

	// Token: 0x040014BF RID: 5311
	private string TsBlackboardKey = "";

	// Token: 0x040014C0 RID: 5312
	private string TsBlackboardSocket = "";

	// Token: 0x040014C1 RID: 5313
	private EAnsBranchTargetBlackboardType TsBlackboardType;

	// Token: 0x040014C2 RID: 5314
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static List<PositionBranchTargetParams> _paramPool;

	// Token: 0x040014C3 RID: 5315
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Dictionary<int, PositionBranchTargetParams> _paramMap;

	// Token: 0x040014C4 RID: 5316
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStatePositionBranchTarget.TsAnimNotifyStatePositionBranchTarget_C";

	// Token: 0x040014C5 RID: 5317
	private static IntPtr _ClassPtr;

	// Token: 0x040014C6 RID: 5318
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040014C7 RID: 5319
	private static int __PropertyOffset_MoveCurve;

	// Token: 0x040014C8 RID: 5320
	private static int __PropertyOffset_Distance;

	// Token: 0x040014C9 RID: 5321
	private static int __PropertyOffset_MaxSpeed;

	// Token: 0x040014CA RID: 5322
	private static int __PropertyOffset_是否永远面向目标;

	// Token: 0x040014CB RID: 5323
	private static int __PropertyOffset_忽略Z轴方向;

	// Token: 0x040014CC RID: 5324
	private static int __PropertyOffset_忽略水平方向;

	// Token: 0x040014CD RID: 5325
	private static int __PropertyOffset_永远修正Z轴;

	// Token: 0x040014CE RID: 5326
	private static int __PropertyOffset_忽略双方半径;

	// Token: 0x040014CF RID: 5327
	private static int __PropertyOffset_IsShareTarget;

	// Token: 0x040014D0 RID: 5328
	private static int __PropertyOffset_TargetOffset;

	// Token: 0x040014D1 RID: 5329
	private static int __PropertyOffset_TargetRotation;

	// Token: 0x040014D2 RID: 5330
	private static int __PropertyOffset_OffsetByOrientation;

	// Token: 0x040014D3 RID: 5331
	private static int __PropertyOffset_OffsetByAbsolute;

	// Token: 0x040014D4 RID: 5332
	private static int __PropertyOffset_MinHeightFromTargetFloor;

	// Token: 0x040014D5 RID: 5333
	private static int __PropertyOffset_允许反向移动;

	// Token: 0x040014D6 RID: 5334
	private static int __PropertyOffset_允许正向移动;

	// Token: 0x040014D7 RID: 5335
	private static int __PropertyOffset_黑板类型;

	// Token: 0x040014D8 RID: 5336
	private static int __PropertyOffset_黑板值;

	// Token: 0x040014D9 RID: 5337
	private static int __PropertyOffset_黑板目标Socket;

	// Token: 0x040014DA RID: 5338
	private static int __PropertyOffset_最小吸附距离;

	// Token: 0x040014DB RID: 5339
	private static int __PropertyOffset_最大吸附距离;
}
