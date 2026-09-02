using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Utils;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D3B RID: 3387
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateCurveMove.TsAnimNotifyStateCurveMove_C")]
public class TsAnimNotifyStateCurveMove : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000394 RID: 916
	// (get) Token: 0x060046A7 RID: 18087 RVA: 0x0008FA8C File Offset: 0x0008DC8C
	// (set) Token: 0x060046A8 RID: 18088 RVA: 0x0008FA9C File Offset: 0x0008DC9C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DebugMode
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_DebugMode) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_DebugMode) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000395 RID: 917
	// (get) Token: 0x060046A9 RID: 18089 RVA: 0x0008FAB0 File Offset: 0x0008DCB0
	// (set) Token: 0x060046AA RID: 18090 RVA: 0x0008FAE9 File Offset: 0x0008DCE9
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<SSkillBehaviorCondition> 技能条件
	{
		get
		{
			base.FastCheckIsValid();
			TArray<SSkillBehaviorCondition> result;
			if ((result = this._技能条件) == null)
			{
				result = (this._技能条件 = new TArray<SSkillBehaviorCondition>(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_技能条件, this));
			}
			return result;
		}
		set
		{
			this.技能条件.CopyAssign(value);
		}
	}

	// Token: 0x17000396 RID: 918
	// (get) Token: 0x060046AB RID: 18091 RVA: 0x0008FAF7 File Offset: 0x0008DCF7
	// (set) Token: 0x060046AC RID: 18092 RVA: 0x0008FB0B File Offset: 0x0008DD0B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName 技能条件公式
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_技能条件公式);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_技能条件公式) = value;
		}
	}

	// Token: 0x17000397 RID: 919
	// (get) Token: 0x060046AD RID: 18093 RVA: 0x0008FB20 File Offset: 0x0008DD20
	// (set) Token: 0x060046AE RID: 18094 RVA: 0x0008FB30 File Offset: 0x0008DD30
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 无视障碍阻挡
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_无视障碍阻挡) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_无视障碍阻挡) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000398 RID: 920
	// (get) Token: 0x060046AF RID: 18095 RVA: 0x0008FB44 File Offset: 0x0008DD44
	// (set) Token: 0x060046B0 RID: 18096 RVA: 0x0008FB7D File Offset: 0x0008DD7D
	[UProperty(EPropertyFlags.CPF_None)]
	public FSoftObjectPath 运动轨迹曲线
	{
		get
		{
			base.FastCheckIsValid();
			FSoftObjectPath result;
			if ((result = this._运动轨迹曲线) == null)
			{
				result = (this._运动轨迹曲线 = new FSoftObjectPath(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_运动轨迹曲线, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_运动轨迹曲线, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x17000399 RID: 921
	// (get) Token: 0x060046B1 RID: 18097 RVA: 0x0008FBA5 File Offset: 0x0008DDA5
	// (set) Token: 0x060046B2 RID: 18098 RVA: 0x0008FBB5 File Offset: 0x0008DDB5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 持续更新目标位置
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_持续更新目标位置) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_持续更新目标位置) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700039A RID: 922
	// (get) Token: 0x060046B3 RID: 18099 RVA: 0x0008FBC6 File Offset: 0x0008DDC6
	// (set) Token: 0x060046B4 RID: 18100 RVA: 0x0008FBD6 File Offset: 0x0008DDD6
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EPositionDatumTarget 位置基准目标
	{
		get
		{
			return (EPositionDatumTarget)(*(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_位置基准目标));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_位置基准目标) = (byte)value;
		}
	}

	// Token: 0x1700039B RID: 923
	// (get) Token: 0x060046B5 RID: 18101 RVA: 0x0008FBE7 File Offset: 0x0008DDE7
	// (set) Token: 0x060046B6 RID: 18102 RVA: 0x0008FBFB File Offset: 0x0008DDFB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName 基于目标骨骼位置
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_基于目标骨骼位置);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_基于目标骨骼位置) = value;
		}
	}

	// Token: 0x1700039C RID: 924
	// (get) Token: 0x060046B7 RID: 18103 RVA: 0x0008FC10 File Offset: 0x0008DE10
	// (set) Token: 0x060046B8 RID: 18104 RVA: 0x0008FC24 File Offset: 0x0008DE24
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName 目标参数
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_目标参数);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_目标参数) = value;
		}
	}

	// Token: 0x1700039D RID: 925
	// (get) Token: 0x060046B9 RID: 18105 RVA: 0x0008FC39 File Offset: 0x0008DE39
	// (set) Token: 0x060046BA RID: 18106 RVA: 0x0008FC49 File Offset: 0x0008DE49
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe ECurveMoveTargetBlackboardType 目标参数类型
	{
		get
		{
			return (ECurveMoveTargetBlackboardType)(*(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_目标参数类型));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_目标参数类型) = (byte)value;
		}
	}

	// Token: 0x1700039E RID: 926
	// (get) Token: 0x060046BB RID: 18107 RVA: 0x0008FC5A File Offset: 0x0008DE5A
	// (set) Token: 0x060046BC RID: 18108 RVA: 0x0008FC6A File Offset: 0x0008DE6A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EOffsetDirectionDatum 偏移方向基准
	{
		get
		{
			return (EOffsetDirectionDatum)(*(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_偏移方向基准));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_偏移方向基准) = (byte)value;
		}
	}

	// Token: 0x1700039F RID: 927
	// (get) Token: 0x060046BD RID: 18109 RVA: 0x0008FC7B File Offset: 0x0008DE7B
	// (set) Token: 0x060046BE RID: 18110 RVA: 0x0008FC8B File Offset: 0x0008DE8B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 偏移基准消除重力分量
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_偏移基准消除重力分量) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_偏移基准消除重力分量) = (value ? 1 : 0);
		}
	}

	// Token: 0x170003A0 RID: 928
	// (get) Token: 0x060046BF RID: 18111 RVA: 0x0008FC9C File Offset: 0x0008DE9C
	// (set) Token: 0x060046C0 RID: 18112 RVA: 0x0008FCB0 File Offset: 0x0008DEB0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector 目标位置偏移
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_目标位置偏移);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_目标位置偏移) = value;
		}
	}

	// Token: 0x170003A1 RID: 929
	// (get) Token: 0x060046C1 RID: 18113 RVA: 0x0008FCC5 File Offset: 0x0008DEC5
	// (set) Token: 0x060046C2 RID: 18114 RVA: 0x0008FCD5 File Offset: 0x0008DED5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 位置修正
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_位置修正) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_位置修正) = (value ? 1 : 0);
		}
	}

	// Token: 0x170003A2 RID: 930
	// (get) Token: 0x060046C3 RID: 18115 RVA: 0x0008FCE8 File Offset: 0x0008DEE8
	// (set) Token: 0x060046C4 RID: 18116 RVA: 0x0008FD21 File Offset: 0x0008DF21
	[UProperty(EPropertyFlags.CPF_None)]
	public SSkillBehaviorAction 位置修正配置
	{
		get
		{
			base.FastCheckIsValid();
			SSkillBehaviorAction result;
			if ((result = this._位置修正配置) == null)
			{
				result = (this._位置修正配置 = new SSkillBehaviorAction(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_位置修正配置, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(SSkillBehaviorAction.StaticStruct(), base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_位置修正配置, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170003A3 RID: 931
	// (get) Token: 0x060046C5 RID: 18117 RVA: 0x0008FD49 File Offset: 0x0008DF49
	// (set) Token: 0x060046C6 RID: 18118 RVA: 0x0008FD5D File Offset: 0x0008DF5D
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UCurveFloat 运动位置曲线
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateCurveMove.__PropertyOffset_运动位置曲线);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateCurveMove.__PropertyOffset_运动位置曲线, value);
		}
	}

	// Token: 0x170003A4 RID: 932
	// (get) Token: 0x060046C7 RID: 18119 RVA: 0x0008FD72 File Offset: 0x0008DF72
	// (set) Token: 0x060046C8 RID: 18120 RVA: 0x0008FD82 File Offset: 0x0008DF82
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EMovementProcessDirection 运动过程朝向
	{
		get
		{
			return (EMovementProcessDirection)(*(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_运动过程朝向));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_运动过程朝向) = (byte)value;
		}
	}

	// Token: 0x170003A5 RID: 933
	// (get) Token: 0x060046C9 RID: 18121 RVA: 0x0008FD93 File Offset: 0x0008DF93
	// (set) Token: 0x060046CA RID: 18122 RVA: 0x0008FDA3 File Offset: 0x0008DFA3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 自动更新运动轨迹曲线关键点
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_自动更新运动轨迹曲线关键点) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_自动更新运动轨迹曲线关键点) = (value ? 1 : 0);
		}
	}

	// Token: 0x170003A6 RID: 934
	// (get) Token: 0x060046CB RID: 18123 RVA: 0x0008FDB4 File Offset: 0x0008DFB4
	// (set) Token: 0x060046CC RID: 18124 RVA: 0x0008FDED File Offset: 0x0008DFED
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<FSplinePoint> 运动轨迹曲线关键点
	{
		get
		{
			base.FastCheckIsValid();
			TArray<FSplinePoint> result;
			if ((result = this._运动轨迹曲线关键点) == null)
			{
				result = (this._运动轨迹曲线关键点 = new TArray<FSplinePoint>(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_运动轨迹曲线关键点, this));
			}
			return result;
		}
		set
		{
			this.运动轨迹曲线关键点.CopyAssign(value);
		}
	}

	// Token: 0x170003A7 RID: 935
	// (get) Token: 0x060046CD RID: 18125 RVA: 0x0008FDFC File Offset: 0x0008DFFC
	// (set) Token: 0x060046CE RID: 18126 RVA: 0x0008FE35 File Offset: 0x0008E035
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<FInterpCurvePointFloat> 运动轨迹曲线插值ReparamTable
	{
		get
		{
			base.FastCheckIsValid();
			TArray<FInterpCurvePointFloat> result;
			if ((result = this._运动轨迹曲线插值ReparamTable) == null)
			{
				result = (this._运动轨迹曲线插值ReparamTable = new TArray<FInterpCurvePointFloat>(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_运动轨迹曲线插值ReparamTable, this));
			}
			return result;
		}
		set
		{
			this.运动轨迹曲线插值ReparamTable.CopyAssign(value);
		}
	}

	// Token: 0x170003A8 RID: 936
	// (get) Token: 0x060046CF RID: 18127 RVA: 0x0008FE43 File Offset: 0x0008E043
	// (set) Token: 0x060046D0 RID: 18128 RVA: 0x0008FE53 File Offset: 0x0008E053
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 终点贴地检测
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_终点贴地检测) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_终点贴地检测) = (value ? 1 : 0);
		}
	}

	// Token: 0x170003A9 RID: 937
	// (get) Token: 0x060046D1 RID: 18129 RVA: 0x0008FE64 File Offset: 0x0008E064
	// (set) Token: 0x060046D2 RID: 18130 RVA: 0x0008FE74 File Offset: 0x0008E074
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 终点贴地检测距离
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_终点贴地检测距离);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_终点贴地检测距离) = value;
		}
	}

	// Token: 0x170003AA RID: 938
	// (get) Token: 0x060046D3 RID: 18131 RVA: 0x0008FE85 File Offset: 0x0008E085
	// (set) Token: 0x060046D4 RID: 18132 RVA: 0x0008FE95 File Offset: 0x0008E095
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 最大位移距离
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_最大位移距离);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_最大位移距离) = value;
		}
	}

	// Token: 0x170003AB RID: 939
	// (get) Token: 0x060046D5 RID: 18133 RVA: 0x0008FEA6 File Offset: 0x0008E0A6
	// (set) Token: 0x060046D6 RID: 18134 RVA: 0x0008FEB6 File Offset: 0x0008E0B6
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 最大移动速度
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_最大移动速度);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCurveMove.__PropertyOffset_最大移动速度) = value;
		}
	}

	// Token: 0x060046D7 RID: 18135 RVA: 0x0008FEC7 File Offset: 0x0008E0C7
	private void EditorUpdateSplineCurve()
	{
	}

	// Token: 0x060046D8 RID: 18136 RVA: 0x0008FECC File Offset: 0x0008E0CC
	private void Initialize()
	{
		this.SkillBehaviorCondition = this.技能条件;
		this.SkillBehaviorConditionFormula = (this.技能条件公式.ToString() ?? "");
		this.IgnoreObstacle = this.无视障碍阻挡;
		this.ContinuallyUpdateTargetPosition = this.持续更新目标位置;
		this.PositionDatumTarget = this.位置基准目标;
		this.TargetSocketPosition = (this.基于目标骨骼位置.ToString() ?? "None");
		this.TargetParam = (this.目标参数.ToString() ?? "None");
		this.TargetParamType = this.目标参数类型;
		this.OffsetDirectionDatum = this.偏移方向基准;
		this.ProjectionGravityDirection = this.偏移基准消除重力分量;
		this.MakePositionCorrection = this.位置修正;
		this.PositionCorrectionConfig = this.位置修正配置;
		this.MovementPositionCurve = this.运动位置曲线;
		this.MovementProcessDirection = this.运动过程朝向;
		this.EndLocationDetection = this.终点贴地检测;
		this.EndLocationDetectionDist = this.终点贴地检测距离;
		this.MaxMoveDistance = this.最大位移距离;
		this.MaxMoveSpeed = this.最大移动速度;
		if (this.运动轨迹曲线关键点 != null && this.SplineCurves == null)
		{
			this.SplineCurves = new SplineCurve(10);
		}
		FVector 目标位置偏移 = this.目标位置偏移;
		if (this.TargetPositionOffset != null)
		{
			global::Vector targetPositionOffset = this.TargetPositionOffset;
			FVector 目标位置偏移2 = this.目标位置偏移;
			FVectorDouble fvectorDouble = 目标位置偏移2;
			targetPositionOffset.DeepCopy(fvectorDouble);
			return;
		}
		FVector 目标位置偏移3 = this.目标位置偏移;
		this.TargetPositionOffset = global::Vector.Create(this.目标位置偏移);
	}

	// Token: 0x060046D9 RID: 18137 RVA: 0x0009005C File Offset: 0x0008E25C
	private void InitCacheVariable()
	{
		if (this.InitCacheVar)
		{
			return;
		}
		this.InitCacheVar = true;
		this.TmpVector = global::Vector.Create();
		this.TmpVector2 = global::Vector.Create();
		this.TmpVector3 = global::Vector.Create();
		this.TmpVector4 = global::Vector.Create();
		this.TmpRotator = global::Rotator.Create();
		this.TmpQuat = Quat.Create(0f, 0f, 0f, 1f);
		this.TmpQuat2 = Quat.Create(0f, 0f, 0f, 1f);
		this.TmpTransform = global::Transform.Create();
		this.ParamMap = new Dictionary<int, CurveMoveParams>();
		this.ParamPool = new List<CurveMoveParams>();
	}

	// Token: 0x060046DA RID: 18138 RVA: 0x00090110 File Offset: 0x0008E310
	[return: Nullable(2)]
	private CurveMoveParams InitCharacterParam(CharacterActorComponent actorComp, double totalDuration)
	{
		CharacterSkillComponent component = actorComp.Entity.GetComponent<CharacterSkillComponent>();
		if (component == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "TsAnimNotifyStateCurveMove.InitCharacterParam没有技能组件";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor", actorComp.Actor.GetName());
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		CurveMoveParams curveMoveParams;
		if (!this.ParamMap.TryGetValue(actorComp.Entity.Id, out curveMoveParams))
		{
			curveMoveParams = ((this.ParamPool.Count > 0) ? this.ParamPool[this.ParamPool.Count - 1] : new CurveMoveParams());
			if (this.ParamPool.Count > 0)
			{
				this.ParamPool.RemoveAt(this.ParamPool.Count - 1);
			}
		}
		curveMoveParams.InitLocation.DeepCopy(actorComp.ActorLocationProxy);
		curveMoveParams.CharActorComp = actorComp;
		curveMoveParams.CharUnifiedComp = actorComp.Entity.GetComponent<CharacterUnifiedStateComponent>();
		curveMoveParams.CharSkillComp = component;
		curveMoveParams.RefreshTarget(this.TargetParam, this.TargetSocketPosition, this.PositionDatumTarget, new ECurveMoveTargetBlackboardType?(this.TargetParamType));
		curveMoveParams.LastSplineDistance = 0f;
		curveMoveParams.NowTime = 0.0;
		curveMoveParams.TotalTime = totalDuration;
		CurveMoveParams curveMoveParams2 = curveMoveParams;
		UCharacterMovementComponent characterMovement = curveMoveParams.CharActorComp.MoveComp.CharacterMovement;
		bool flyingMove;
		if (((characterMovement != null) ? new TEnumAsByte<EMovementMode>?(characterMovement.MovementMode) : null) != EMovementMode.MOVE_Walking)
		{
			UCharacterMovementComponent characterMovement2 = curveMoveParams.CharActorComp.MoveComp.CharacterMovement;
			flyingMove = (((characterMovement2 != null) ? new TEnumAsByte<EMovementMode>?(characterMovement2.MovementMode) : null) != EMovementMode.MOVE_NavWalking);
		}
		else
		{
			flyingMove = false;
		}
		curveMoveParams2.FlyingMove = flyingMove;
		this.ParamMap.Add(actorComp.Entity.Id, curveMoveParams);
		if (curveMoveParams.TargetActorComp == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Movement, ELogAuthor.CWZ, "TsAnimNotifyStateCurveMove.InitCharacterParam没有目标", default(ReadOnlySpan<ValueTuple<string, object>>));
			return curveMoveParams;
		}
		return curveMoveParams;
	}

	// Token: 0x060046DB RID: 18139 RVA: 0x00090328 File Offset: 0x0008E528
	private bool CheckUseCondition(TsBaseCharacter owner)
	{
		TArray<SSkillBehaviorCondition> skillBehaviorCondition = this.SkillBehaviorCondition;
		if (skillBehaviorCondition == null || skillBehaviorCondition.Num() == 0)
		{
			return true;
		}
		Entity entity = owner.CharacterActorComponent.Entity;
		CharacterSkillComponent component = entity.GetComponent<CharacterSkillComponent>();
		CharacterSkillComponent component2 = entity.GetComponent<CharacterSkillComponent>();
		Skill skill = (component2 != null) ? component2.CurrentSkill : null;
		if (component == null || skill == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Movement, ELogAuthor.CWZ, "TsAnimNotifyStateCurveMove.CheckUseCondition没有技能组件", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		BeginSkillBehaviorConditionParam param = new BeginSkillBehaviorConditionParam
		{
			Entity = entity,
			SkillComponent = component,
			Skill = skill
		};
		if (!global::SkillBehaviorCondition.SatisfyGroup(this.SkillBehaviorCondition, this.SkillBehaviorConditionFormula, param))
		{
			Singleton<Log>.Instance.Warn(ELogModule.Movement, ELogAuthor.CWZ, "TsAnimNotifyStateCurveMove.CheckUseCondition不满足使用条件", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		return true;
	}

	// Token: 0x060046DC RID: 18140 RVA: 0x000903E8 File Offset: 0x0008E5E8
	[NullableContext(2)]
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

	// Token: 0x060046DD RID: 18141 RVA: 0x00090490 File Offset: 0x0008E690
	[NullableContext(2)]
	protected unsafe virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		if (GlobalData.GameInstance == null)
		{
			this.EditorUpdateSplineCurve();
			return false;
		}
		this.InitCacheVariable();
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		if (characterActorComponent == null)
		{
			return false;
		}
		this.Initialize();
		CurveMoveParams curveMoveParams = this.InitCharacterParam(characterActorComponent, (double)totalDuration);
		if (curveMoveParams == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Movement, ELogAuthor.CWZ, "TsAnimNotifyStateCurveMove初始化角色参数失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		if (curveMoveParams.AllowMovement)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Movement, ELogAuthor.CWZ, "TsAnimNotifyStateCurveMove正在移动中", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		SplineCurve splineCurves = this.SplineCurves;
		if (splineCurves != null)
		{
			splineCurves.Init(this.运动轨迹曲线关键点, this.运动轨迹曲线插值ReparamTable, null, null);
		}
		if (this.SkillBehaviorCondition != null && !this.CheckUseCondition(owner as TsBaseCharacter))
		{
			Singleton<Log>.Instance.Warn(ELogModule.Movement, ELogAuthor.CWZ, "TsAnimNotifyStateCurveMove不满足技能使用条件", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		global::Vector targetOffset = curveMoveParams.TargetOffset;
		FVector 目标位置偏移 = this.目标位置偏移;
		FVectorDouble fvectorDouble = 目标位置偏移;
		targetOffset.DeepCopy(fvectorDouble);
		this.GetTargetPos(curveMoveParams, curveMoveParams.TargetPos);
		curveMoveParams.LastTargetPos.DeepCopy(curveMoveParams.TargetPos);
		double towardVector = this.GetTowardVector(curveMoveParams, curveMoveParams.TargetVec);
		if (towardVector < 50.0 || curveMoveParams.TargetVec.SizeSquared2D() < 2500.0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "TsAnimNotifyStateCurveMove距离异常，不移动";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CurrentLocation", curveMoveParams.CharActorComp.ActorLocationProxy);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TargetPos", curveMoveParams.TargetPos);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("dist", towardVector);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("distSquared2D", curveMoveParams.TargetVec.SizeSquared2D());
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			return false;
		}
		if (this.IgnoreObstacle)
		{
			CharacterMoveComponent component = characterActorComponent.Entity.GetComponent<CharacterMoveComponent>();
			if (component != null)
			{
				component.SetStepHeight(curveMoveParams.CharActorComp.HalfHeight);
			}
		}
		if (this.运动轨迹曲线关键点 != null && this.SplineCurves != null && this.InitSplineTransform(curveMoveParams))
		{
			curveMoveParams.AlongStraightLine = false;
			curveMoveParams.AllowMovement = true;
			return true;
		}
		curveMoveParams.AlongStraightLine = true;
		curveMoveParams.AllowMovement = true;
		return true;
	}

	// Token: 0x060046DE RID: 18142 RVA: 0x000906FC File Offset: 0x0008E8FC
	[NullableContext(2)]
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

	// Token: 0x060046DF RID: 18143 RVA: 0x000907A4 File Offset: 0x0008E9A4
	[NullableContext(2)]
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		if ((double)frameDeltaTime < 0.0001)
		{
			return false;
		}
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		CurveMoveParams valueOrDefault = this.ParamMap.GetValueOrDefault(characterActorComponent.Entity.Id);
		if (valueOrDefault == null || !valueOrDefault.AllowMovement)
		{
			return false;
		}
		CharacterSkillComponent charSkillComp = valueOrDefault.CharSkillComp;
		if (charSkillComp != null && charSkillComp.IsSkillMontageInvalid(animation.GetName()))
		{
			return false;
		}
		valueOrDefault.CanSetActorTargetPos = false;
		if (this.SplineCurves != null && !valueOrDefault.AlongStraightLine)
		{
			valueOrDefault.RefreshTarget(this.TargetParam, this.TargetSocketPosition, this.PositionDatumTarget, new ECurveMoveTargetBlackboardType?(this.TargetParamType));
			if (valueOrDefault.TargetActorComp != null)
			{
				this.MoveToTargetAlongSpline((double)frameDeltaTime, valueOrDefault);
				valueOrDefault.LastLocation.DeepCopy(valueOrDefault.CharActorComp.ActorLocationProxy);
			}
			valueOrDefault.NowTime += (double)frameDeltaTime;
			if (this.DebugMode)
			{
				int splinePointsNum = this.SplineCurves.GetSplinePointsNum();
				for (int i = 0; i < splinePointsNum; i++)
				{
					this.SplineCurves.GetWorldLocationAtSplinePoint(i, this.TmpVector);
					this.DebugDraw(this.TmpVector.ToUeVector(false), ColorUtils.LinearYellow, 30f, 5);
				}
			}
			return true;
		}
		if (valueOrDefault.AlongStraightLine)
		{
			valueOrDefault.RefreshTarget(this.TargetParam, this.TargetSocketPosition, this.PositionDatumTarget, new ECurveMoveTargetBlackboardType?(this.TargetParamType));
			if (valueOrDefault.TargetActorComp != null)
			{
				this.MoveToTarget((double)frameDeltaTime, valueOrDefault);
				valueOrDefault.LastLocation.DeepCopy(valueOrDefault.CharActorComp.ActorLocationProxy);
			}
			valueOrDefault.NowTime += (double)frameDeltaTime;
			return true;
		}
		return false;
	}

	// Token: 0x060046E0 RID: 18144 RVA: 0x0009094C File Offset: 0x0008EB4C
	[NullableContext(2)]
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

	// Token: 0x060046E1 RID: 18145 RVA: 0x000909EC File Offset: 0x0008EBEC
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		CurveMoveParams valueOrDefault = this.ParamMap.GetValueOrDefault(characterActorComponent.Entity.Id);
		if (valueOrDefault == null)
		{
			return false;
		}
		if (this.IgnoreObstacle)
		{
			CharacterMoveComponent component = characterActorComponent.Entity.GetComponent<CharacterMoveComponent>();
			if (component != null)
			{
				component.ResetStepHeight();
			}
		}
		valueOrDefault.AllowMovement = false;
		if (this.IgnoreObstacle)
		{
			if (valueOrDefault.CanSetActorTargetPos && global::Vector.Dist(valueOrDefault.TargetPos, valueOrDefault.CharActorComp.ActorLocationProxy) > 50.0)
			{
				valueOrDefault.CharActorComp.SetActorLocation(valueOrDefault.TargetPos.ToUeVector(false), "TsAnimNotifyStateCurveMove.技能曲线移动穿越障碍物结束", false);
				Singleton<Log>.Instance.Warn(ELogModule.Movement, ELogAuthor.CWZ, "技能曲线移动穿越障碍物结束SetActorLocation到终点", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			valueOrDefault.CanSetActorTargetPos = false;
		}
		this.ParamMap.Remove(characterActorComponent.Entity.Id);
		valueOrDefault.Clear();
		this.ParamPool.Add(valueOrDefault);
		return true;
	}

	// Token: 0x060046E2 RID: 18146 RVA: 0x00090AF4 File Offset: 0x0008ECF4
	private unsafe bool InitSplineTransform(CurveMoveParams @params)
	{
		SplineCurve splineCurves = this.SplineCurves;
		float? num = (splineCurves != null) ? new float?(splineCurves.GetSplineLength()) : null;
		if (num != null)
		{
			float? num2 = num;
			float num3 = 0f;
			if (!(num2.GetValueOrDefault() <= num3 & num2 != null))
			{
				double num4 = @params.TargetVec.Size();
				int splinePointsNum = this.SplineCurves.GetSplinePointsNum();
				this.SplineCurves.GetWorldLocationAtSplinePoint(0, this.TmpVector3);
				this.SplineCurves.GetWorldLocationAtSplinePoint(splinePointsNum - 1, this.TmpVector2);
				this.TmpVector3.SubtractionEqual(this.TmpVector2);
				double num5 = this.TmpVector3.Size();
				num2 = num;
				num3 = 100f;
				if ((num2.GetValueOrDefault() < num3 & num2 != null) || num4 < 100.0 || num5 < 1.0)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Movement;
					ELogAuthor author = ELogAuthor.CWZ;
					string message = "TsAnimNotifyStateCurveMove.样条总长度太短";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("splineLen", num);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("distance", num4);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("splineLineLength", num5);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					return false;
				}
				this.TmpVector.DeepCopy(global::Vector.ForwardVectorProxy);
				Singleton<MathUtils>.Instance.LookRotationForwardFirst(@params.TargetVec, global::Vector.UpVectorProxy, this.TmpQuat);
				Singleton<MathUtils>.Instance.LookRotationForwardFirst(this.TmpVector3, global::Vector.UpVectorProxy, this.TmpQuat2);
				this.TmpQuat2.Inverse(this.TmpQuat2);
				this.TmpQuat.RotateVector(this.TmpVector, this.TmpVector);
				this.TmpQuat2.RotateVector(this.TmpVector, this.TmpVector);
				this.TmpVector.UnaryNegation(this.TmpVector);
				this.TmpVector.Z = -this.TmpVector.Z;
				this.TmpVector.ToOrientationQuat(this.TmpQuat2);
				double num6 = num4 / num5;
				this.TmpVector2.DeepCopy(this.SplineCurves.SplineTransform.GetScale3D());
				if (num6 > 0.0001)
				{
					this.TmpVector2.MultiplyEqual(num6);
				}
				if (this.DebugMode)
				{
					int num7 = 30;
					this.DebugDraw(@params.TargetPos.ToUeVector(false), ColorUtils.LinearBlack, (float)(num7 + 10), 5);
				}
				this.TmpTransform.Set(@params.InitLocation, this.TmpQuat2, this.TmpVector2);
				this.SplineCurves.SetSplineTransform(this.TmpTransform, false);
				this.SplineCurves.GetWorldLocationAtSplinePoint(0, this.TmpVector);
				double num8 = global::Vector.DistSquared(this.TmpVector, @params.InitLocation);
				double num9 = global::Vector.DistSquared(this.TmpVector, @params.CharActorComp.ActorLocationProxy);
				if (num8 > 10000.0 || num9 > 10000.0)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Movement;
					ELogAuthor author2 = ELogAuthor.CWZ;
					string message2 = "初始点位置和样条第一个点位置距离太远了。";
					<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("样条点和初始点距离Squared", num8);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("样条点和当前坐标距离Squared", num9);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("startLocation", this.TmpVector);
					ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3);
					string item = "ActorLocation";
					CharacterActorComponent charActorComp = @params.CharActorComp;
					ptr = new ValueTuple<string, object>(item, (charActorComp != null) ? charActorComp.ActorLocationProxy : null);
					instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
					return false;
				}
				return true;
			}
		}
		return false;
	}

	// Token: 0x060046E3 RID: 18147 RVA: 0x00090EB4 File Offset: 0x0008F0B4
	private unsafe void GetTargetPos(CurveMoveParams @params, global::Vector outVector)
	{
		if (this.TargetParamType == ECurveMoveTargetBlackboardType.LocationVector)
		{
			Aki.Protocol.Vector vectorValueByEntity = ControllerBase<BlackboardController>.Instance.GetVectorValueByEntity(@params.CharActorComp.Entity.Id, this.TargetParam);
			if (vectorValueByEntity == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.CWZ;
				string message = "TsAnimNotifyStateCurveMove 传入目标黑板类型为坐标点，但是黑板里没有这个Vector";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", @params.CharActorComp.Entity.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Key", this.TargetParam);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Value", vectorValueByEntity);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				outVector.DeepCopy(@params.CharActorComp.ActorLocationProxy);
				return;
			}
			outVector.Set((double)vectorValueByEntity.X, (double)vectorValueByEntity.Y, (double)vectorValueByEntity.Z);
		}
		else
		{
			if (!@params.RefreshTarget(this.TargetParam, this.TargetSocketPosition, this.PositionDatumTarget, new ECurveMoveTargetBlackboardType?(this.TargetParamType)))
			{
				outVector.DeepCopy(@params.CharActorComp.ActorLocationProxy);
				return;
			}
			if (@params.SocketName != null && @params.SocketName.Length > 0)
			{
				CharacterActorComponent targetCharActorComp = @params.TargetCharActorComp;
				if (((targetCharActorComp != null) ? targetCharActorComp.Actor : null) != null)
				{
					FVectorDouble fvectorDouble = @params.TargetCharActorComp.Actor.Mesh.D_GetSocketLocation(FNameUtil.GetDynamicFName(@params.SocketName).Value);
					outVector.FromUeVector(fvectorDouble);
				}
				else
				{
					outVector.DeepCopy(@params.TargetActorComp.ActorLocationProxy);
				}
			}
			else
			{
				outVector.DeepCopy(@params.TargetActorComp.ActorLocationProxy);
			}
		}
		if (this.TargetPositionOffset == null)
		{
			return;
		}
		if (this.DebugMode)
		{
			this.DebugDraw(outVector.ToUeVector(false), new FLinearColor(1f, 0.5f, 0f, 0f), 30f, 5);
		}
		@params.TargetOffset.DeepCopy(this.TargetPositionOffset);
		this.TmpVector.Reset();
		switch (this.OffsetDirectionDatum)
		{
		case EOffsetDirectionDatum.User:
			if (@params.CharActorComp != null)
			{
				this.TmpVector.DeepCopy(@params.CharActorComp.ActorForwardProxy);
			}
			break;
		case EOffsetDirectionDatum.TargetPosition:
			if (this.TargetParamType == ECurveMoveTargetBlackboardType.LocationVector)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Movement;
				ELogAuthor author2 = ELogAuthor.CWZ;
				string message2 = "TsAnimNotifyStateCurveMove 传入目标黑板类型为坐标点，偏移方向基准不应该选TargetPosition";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityId", @params.CharActorComp.Entity.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Key", this.TargetParam);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			}
			else if (@params.TargetActorComp != null)
			{
				this.TmpVector.DeepCopy(@params.TargetActorComp.ActorForwardProxy);
			}
			break;
		case EOffsetDirectionDatum.UserToTarget:
			if (@params.CharActorComp != null)
			{
				if (this.TargetParamType == ECurveMoveTargetBlackboardType.LocationVector)
				{
					this.TmpVector.DeepCopy(outVector);
					this.TmpVector.SubtractionEqual(@params.CharActorComp.ActorLocationProxy);
				}
				else if (@params.TargetActorComp != null)
				{
					this.TmpVector.DeepCopy(@params.TargetActorComp.ActorLocationProxy);
					this.TmpVector.SubtractionEqual(@params.CharActorComp.ActorLocationProxy);
				}
			}
			break;
		}
		if (!this.TmpVector.IsNearlyZero(9.999999747378752E-05))
		{
			if (this.ProjectionGravityDirection)
			{
				Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(@params.CharActorComp, this.TmpVector);
			}
			this.TmpVector.Normalize(9.99999993922529E-09);
			this.TmpVector.Rotation(this.TmpRotator);
			this.TmpRotator.Quaternion(this.TmpQuat);
			this.TmpQuat.RotateVector(@params.TargetOffset, @params.TargetOffset);
		}
		outVector.AdditionEqual(@params.TargetOffset);
		if (this.EndLocationDetection && @params.CharActorComp != null)
		{
			this.DetectFloor(@params.CharActorComp, outVector);
		}
	}

	// Token: 0x060046E4 RID: 18148 RVA: 0x000912C0 File Offset: 0x0008F4C0
	private bool DetectFloor(CharacterActorComponent actor, global::Vector @out)
	{
		UTraceSphereElement actorTrace = ModelBase<TraceElementModel>.Instance.GetActorTrace();
		actorTrace.WorldContextObject = actor.Actor;
		actorTrace.Radius = actor.ScaledRadius;
		if (this.DebugMode)
		{
			actorTrace.SetDrawDebugTrace(EDrawDebugTrace.ForDuration);
		}
		actorTrace.ActorsToIgnore.Empty(true);
		actorTrace.ActorsToIgnore.Add(actor.Actor);
		foreach (AActor value in ModelBase<WorldModel>.Instance.ActorsToIgnoreSet)
		{
			actorTrace.ActorsToIgnore.Add(value);
		}
		this.TmpVector.DeepCopy(@out);
		Singleton<TraceElementCommon>.Instance.SetStartLocation(actorTrace, this.TmpVector);
		this.TmpVector.DeepCopy(@out);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(actor, this.TmpVector, (double)(-(double)this.EndLocationDetectionDist));
		Singleton<TraceElementCommon>.Instance.SetEndLocation(actorTrace, this.TmpVector);
		if (Singleton<TraceElementCommon>.Instance.ShapeTrace(actor.Actor.CapsuleComponent, actorTrace, "TsAnimNotifyStateCurveMove", "TsAnimNotifyStateCurveMove"))
		{
			Singleton<TraceElementCommon>.Instance.GetHitLocation(actorTrace.HitResult, 0, @out);
			Singleton<GravityUtils>.Instance.AddZnInGravityForActor(actor, @out, (double)actor.ScaledHalfHeight);
			if (this.DebugMode)
			{
				this.DebugDraw(@out.ToUeVector(false), ColorUtils.LinearCyan, 30f, 5);
				actorTrace.SetDrawDebugTrace(EDrawDebugTrace.None);
			}
			return true;
		}
		if (this.DebugMode)
		{
			actorTrace.SetDrawDebugTrace(EDrawDebugTrace.None);
		}
		return false;
	}

	// Token: 0x060046E5 RID: 18149 RVA: 0x00091440 File Offset: 0x0008F640
	private void PositionCorrection(CurveMoveParams @params, global::Vector targetPos, global::Vector outPos)
	{
		if (!this.MakePositionCorrection || this.PositionCorrectionConfig == null || this.PositionCorrectionConfig.ActionType != ESkillBehaviorActionType.设置位置)
		{
			return;
		}
		CharacterActorComponent charActorComp = @params.CharActorComp;
		FVectorDouble to = targetPos.ToUeVector(false);
		FVectorDouble fvectorDouble = charActorComp.ActorForward;
		global::Vector tmpVector = this.TmpVector2;
		tmpVector.DeepCopy(to);
		FVector locationOffset = this.PositionCorrectionConfig.LocationOffset;
		FVector fvector = this.PositionCorrectionConfig.LocationOffset;
		if (!fvector.IsNearlyZero(0.0001f))
		{
			switch (this.PositionCorrectionConfig.LocationType)
			{
			case 1:
				if (!(!@params.CharSkillComp) && @params.CharSkillComp.SkillTarget != null)
				{
					ValueTuple<FVectorDouble, FVectorDouble> locationAndDirection = SkillBehaviorMisc.GetLocationAndDirection(@params.CharSkillComp.SkillTarget.Entity.GetComponent<BaseActorComponent>().Owner);
					to = locationAndDirection.Item1;
					fvectorDouble = locationAndDirection.Item2;
					to = @params.CharSkillComp.GetTargetTransform().GetLocation();
				}
				break;
			case 2:
			{
				EntityHandle currentTarget = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Entity.GetComponent<CharacterLockOnComponent>().GetCurrentTarget();
				if (currentTarget != null)
				{
					ValueTuple<FVectorDouble, FVectorDouble> locationAndDirection2 = SkillBehaviorMisc.GetLocationAndDirection(currentTarget.Entity.GetComponent<BaseActorComponent>().Owner);
					to = locationAndDirection2.Item1;
					fvectorDouble = locationAndDirection2.Item2;
				}
				break;
			}
			case 3:
			{
				ValueTuple<FVectorDouble, FVectorDouble> locationAndDirection3 = SkillBehaviorMisc.GetLocationAndDirection(Global.BaseCharacter);
				to = locationAndDirection3.Item1;
				fvectorDouble = locationAndDirection3.Item2;
				break;
			}
			case 4:
				if (@params.CharActorComp != null)
				{
					EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(@params.CharActorComp.Entity.GetComponent<CreatureDataComponent>().GetSummonerId());
					BaseActorComponent baseActorComponent;
					if (entity == null)
					{
						baseActorComponent = null;
					}
					else
					{
						WorldEntity entity2 = entity.Entity;
						baseActorComponent = ((entity2 != null) ? entity2.GetComponent<BaseActorComponent>() : null);
					}
					ValueTuple<FVectorDouble, FVectorDouble> locationAndDirection4 = SkillBehaviorMisc.GetLocationAndDirection(baseActorComponent.Owner);
					to = locationAndDirection4.Item1;
					fvectorDouble = locationAndDirection4.Item2;
				}
				break;
			case 5:
			{
				ValueTuple<FVectorDouble, FVectorDouble> locationAndDirection5 = SkillBehaviorMisc.GetLocationAndDirection(ModelBase<CameraModel>.Instance.MainModel.FightCamera.GetComponent<FightCameraDisplayComponent>().CameraActor);
				to = locationAndDirection5.Item1;
				fvectorDouble = locationAndDirection5.Item2;
				break;
			}
			case 6:
				if (@params.CharActorComp != null)
				{
					to = WorldGlobal.ToUeVector(ControllerBase<BlackboardController>.Instance.GetVectorValueByEntity(@params.CharActorComp.Entity.Id, this.TargetParam));
				}
				break;
			case 7:
				if (@params.CharActorComp != null)
				{
					int? intValueByEntity = ControllerBase<BlackboardController>.Instance.GetIntValueByEntity(@params.CharActorComp.Entity.Id, this.TargetParam);
					Entity entity3 = Singleton<EntitySystem>.Instance.Get(intValueByEntity.Value);
					if (entity3 != null && entity3.Valid)
					{
						ValueTuple<FVectorDouble, FVectorDouble> locationAndDirection6 = SkillBehaviorMisc.GetLocationAndDirection(entity3.GetComponent<BulletActorComponent>().Owner);
						to = locationAndDirection6.Item1;
						fvectorDouble = locationAndDirection6.Item2;
					}
				}
				break;
			}
			switch (this.PositionCorrectionConfig.LocationForwardType)
			{
			case 1:
				fvectorDouble = charActorComp.Actor.D_GetActorForwardVector();
				break;
			case 2:
			{
				FVectorDouble fvectorDouble2 = charActorComp.ActorLocation;
				FVectorDouble fvectorDouble3 = fvectorDouble2 - to;
				fvectorDouble.Set(fvectorDouble3.X, fvectorDouble3.Y, 0.0);
				break;
			}
			case 3:
			{
				FVectorDouble fvectorDouble2 = Global.CharacterCameraManager.D_GetCameraLocation();
				FVectorDouble fvectorDouble4 = to - fvectorDouble2;
				fvectorDouble.Set(fvectorDouble4.X, fvectorDouble4.Y, 0.0);
				break;
			}
			}
			tmpVector.DeepCopy(to);
			FRotator frotator = fvectorDouble.Rotation();
			fvector = global::Vector.OneVectorDouble;
			FTransformDouble ftransformDouble = new FTransformDouble(ref frotator, ref to, ref fvector);
			FVectorDouble fvectorDouble5 = UKismetMathLibrary.Conv_VectorToVectorDouble(this.PositionCorrectionConfig.LocationOffset);
			to = ftransformDouble.TransformPositionNoScale(fvectorDouble5);
			bool debugMode = this.DebugMode;
		}
		if (this.PositionCorrectionConfig.Restrict)
		{
			FVectorDouble from = charActorComp.ActorLocation;
			switch (this.PositionCorrectionConfig.RestrictType)
			{
			case 0:
				from = Global.BaseCharacter.D_K2_GetActorLocation();
				break;
			case 2:
				if (charActorComp.Entity.GetComponent<CreatureDataComponent>().IsMonster())
				{
					Aki.Protocol.Vector initLocation = charActorComp.GetInitLocation();
					from.Set((double)initLocation.X, (double)initLocation.Y, (double)initLocation.Z);
				}
				break;
			}
			FVectorDouble fvectorDouble2 = to - from;
			double num = fvectorDouble2.Size();
			if (num > (double)this.PositionCorrectionConfig.RestrictDistance)
			{
				double num2 = (double)this.PositionCorrectionConfig.RestrictDistance / num;
				Singleton<MathUtils>.Instance.LerpVector(from, to, (float)num2, ref to);
				bool debugMode2 = this.DebugMode;
			}
		}
		global::Vector vector = this.TmpVector3;
		vector.DeepCopy(to);
		if (this.PositionCorrectionConfig.BestSpot)
		{
			byte b = this.PositionCorrectionConfig.Strategy;
			if (b != 0)
			{
				if (b == 2)
				{
					bool flag = false;
					this.TmpVector4.Reset();
					global::Vector tmpVector2 = this.TmpVector;
					global::Vector tmpVector3 = this.TmpVector4;
					vector.Subtraction(tmpVector, tmpVector2);
					foreach (int num3 in TsAnimNotifyStateCurveMove.angles)
					{
						tmpVector2.RotateAngleAxis((double)num3, global::Vector.UpVectorProxy, tmpVector3);
						tmpVector.Addition(tmpVector3, vector);
						ValueTuple<UKuroHitResult, global::Vector>? valueTuple = SkillBehaviorMisc.TraceWall(charActorComp, tmpVector, vector, this.PositionCorrectionConfig.DebugTrace);
						if (valueTuple == null)
						{
							return;
						}
						if (valueTuple.Value.Item1 == null)
						{
							flag = true;
							vector = valueTuple.Value.Item2;
							break;
						}
					}
					if (!flag)
					{
						return;
					}
				}
			}
			else
			{
				ValueTuple<UKuroHitResult, global::Vector>? valueTuple2 = SkillBehaviorMisc.TraceWall(charActorComp, tmpVector, vector, this.PositionCorrectionConfig.DebugTrace);
				if (valueTuple2 == null)
				{
					return;
				}
				vector = valueTuple2.Value.Item2;
			}
			ValueTuple<bool, global::Vector> valueTuple3 = SkillBehaviorMisc.TraceGroundWithGravity(charActorComp, vector, this.PositionCorrectionConfig.DebugTrace, 2500f);
			if (!valueTuple3.Item1)
			{
				return;
			}
			vector = valueTuple3.Item2;
			@params.CanSetActorTargetPos = true;
			bool debugMode3 = this.DebugMode;
		}
		to = vector.ToUeVector(false);
		FVectorDouble queryExtent = new FVectorDouble();
		if (this.PositionCorrectionConfig.Navigation > 0 && !UNavigationSystemV1.D_K2_ProjectPointToNavigation(GlobalData.World, to, ref queryExtent, null, null, queryExtent, -1.0))
		{
			FVectorDouble fvectorDouble6 = new FVectorDouble();
			if (UNavigationSystemV1.D_K2_GetRandomLocationInNavigableRadius(GlobalData.World, to, ref fvectorDouble6, (float)this.PositionCorrectionConfig.Navigation, null, default(TSubclassOf<UNavigationQueryFilter>)))
			{
				outPos.DeepCopy(fvectorDouble6);
			}
			@params.CanSetActorTargetPos = true;
			return;
		}
		this.TmpVector.DeepCopy(to);
		this.TmpVector.SubtractionEqual(tmpVector);
		targetPos.Addition(this.TmpVector, outPos);
		bool debugMode4 = this.DebugMode;
	}

	// Token: 0x060046E6 RID: 18150 RVA: 0x00091AD0 File Offset: 0x0008FCD0
	private unsafe double GetTowardVector(CurveMoveParams @params, global::Vector outVector)
	{
		if (this.MakePositionCorrection && this.PositionCorrectionConfig != null)
		{
			if (this.DebugMode)
			{
				int num = 30;
				this.DebugDraw(@params.TargetPos.ToUeVector(false), new FLinearColor(1f, 0.5f, 1f, 0f), (float)(num + 5), 5);
			}
			this.PositionCorrection(@params, @params.LastTargetPos, @params.TargetPos);
		}
		CharacterUnifiedStateComponent charUnifiedComp = @params.CharUnifiedComp;
		if (charUnifiedComp != null && charUnifiedComp.PositionState == global::ECharPositionState.Ground && global::Vector.DistSquared2D(@params.TargetPos, @params.CharActorComp.ActorLocationProxy) < 1.0)
		{
			return -1.0;
		}
		if (this.DebugMode)
		{
			int num2 = 30;
			this.DebugDraw(@params.TargetPos.ToUeVector(false), ColorUtils.LinearRed, (float)(num2 + 10), 5);
		}
		@params.TargetPos.Subtraction(@params.CharActorComp.ActorLocationProxy, this.TmpVector);
		@params.TargetPos.Subtraction(@params.LastLocation, this.TmpVector2);
		double num3 = this.TmpVector.DotProduct(this.TmpVector2);
		double num4 = this.TmpVector.Size();
		if (num4 > (double)this.MaxMoveDistance)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "目标点距离太远了，不动";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("dist", num4);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("current", @params.CharActorComp.ActorLocationProxy);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("TargetPos", @params.TargetPos);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return -1.0;
		}
		outVector.DeepCopy(this.TmpVector);
		if (num3 < 0.0)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Movement, ELogAuthor.CWZ, "和上一次移动相比在后退", default(ReadOnlySpan<ValueTuple<string, object>>));
			return -1.0;
		}
		return num4;
	}

	// Token: 0x060046E7 RID: 18151 RVA: 0x00091CD8 File Offset: 0x0008FED8
	private unsafe double GetRate(double delta, CurveMoveParams @params)
	{
		double num = @params.NowTime + delta;
		double num2;
		if (@params.TotalTime <= num)
		{
			num2 = 1.0;
		}
		else if (this.MovementPositionCurve != null)
		{
			num2 = (double)this.MovementPositionCurve.GetFloatValue((float)(@params.NowTime / @params.TotalTime));
		}
		else
		{
			num2 = Singleton<MathUtils>.Instance.GetCubicValue(@params.NowTime / @params.TotalTime);
		}
		if (num2 > 1.0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "rate > 1";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("params.NowTime", @params.NowTime);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("params.TotalTime", @params.TotalTime);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return 1.0;
		}
		return num2;
	}

	// Token: 0x060046E8 RID: 18152 RVA: 0x00091DC8 File Offset: 0x0008FFC8
	private unsafe void MoveToTarget(double delta, CurveMoveParams @params)
	{
		@params.TargetPos.DeepCopy(@params.LastTargetPos);
		if (this.ContinuallyUpdateTargetPosition)
		{
			@params.LastTargetPos.DeepCopy(@params.TargetPos);
			this.GetTargetPos(@params, @params.TargetPos);
		}
		double towardVector = this.GetTowardVector(@params, @params.TargetVec);
		double rate = this.GetRate(delta, @params);
		if (rate <= 0.0 || towardVector < 0.0 || @params.TargetVec.IsNearlyZero(9.999999747378752E-05))
		{
			return;
		}
		global::Vector.Lerp(@params.InitLocation, @params.TargetPos, rate, @params.TargetVec);
		@params.TargetVec.Subtraction(@params.CharActorComp.ActorLocationProxy, this.TmpVector3);
		if (this.DebugMode)
		{
			UKismetSystemLibrary.D_DrawDebugArrow(GlobalData.World, @params.CharActorComp.ActorLocation, @params.TargetVec.ToUeVector(false), (float)this.TmpVector3.Size(), ColorUtils.LinearWhite, 0f, 0f);
		}
		@params.TargetVec.DeepCopy(this.TmpVector3);
		double num = @params.TargetVec.Size();
		if ((double)this.MaxMoveSpeed > 0.0001)
		{
			num = Math.Min(num, delta * (double)this.MaxMoveSpeed);
		}
		CharacterUnifiedStateComponent charUnifiedComp = @params.CharUnifiedComp;
		if (charUnifiedComp != null && charUnifiedComp.PositionState == global::ECharPositionState.Ground && num < 1.0)
		{
			return;
		}
		this.TmpVector3.Normalize(9.99999993922529E-09);
		this.TmpVector3.MultiplyEqual(num);
		@params.LastLocation.Subtraction(@params.CharActorComp.ActorLocationProxy, this.TmpVector);
		if (this.TmpVector.SizeSquared() > 1000000.0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "LastLocation太远，很危险，无视掉";
			<>y__InlineArray7<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray7<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "Actor";
			CharacterActorComponent charActorComp = @params.CharActorComp;
			object item2;
			if (charActorComp == null)
			{
				item2 = null;
			}
			else
			{
				TsBaseCharacter actor = charActorComp.Actor;
				item2 = ((actor != null) ? actor.GetName() : null);
			}
			ptr = new ValueTuple<string, object>(item, item2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Last", @params.LastLocation);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
			string item3 = "ActorLast";
			CharacterActorComponent charActorComp2 = @params.CharActorComp;
			ptr2 = new ValueTuple<string, object>(item3, (charActorComp2 != null) ? charActorComp2.LastActorLocation : null);
			ref ValueTuple<string, object> ptr3 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3);
			string item4 = "Now";
			CharacterActorComponent charActorComp3 = @params.CharActorComp;
			ptr3 = new ValueTuple<string, object>(item4, (charActorComp3 != null) ? charActorComp3.ActorLocationProxy : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("TargetVec", @params.TargetVec);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("TmpVector", this.TmpVector);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("TmpVector3", this.TmpVector3);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 7));
			this.TmpVector3.Reset();
		}
		if (this.DebugMode)
		{
			this.TmpVector2.DeepCopy(@params.CharActorComp.ActorLocationProxy);
			this.TmpVector2.AdditionEqual(this.TmpVector3);
			this.DebugDraw(this.TmpVector2.ToUeVector(false), ColorUtils.LinearWhite, 30f, 5);
		}
		this.TmpVector.DeepCopy(this.TmpVector3);
		@params.CharActorComp.MoveComp.ClampOffsetByChain(this.TmpVector);
		if (!@params.FlyingMove)
		{
			@params.CharActorComp.MoveComp.MoveCharacter(this.TmpVector, (float)delta, "TsAnimNotifyStateCurveMove直线移动");
		}
		else
		{
			@params.CharActorComp.AddActorWorldOffset(this.TmpVector.ToUeVector(false), "TsAnimNotifyStateCurveMove直线移动.AddActorWorldOffset", true);
			@params.CharActorComp.ResetAllCachedTime();
		}
		if (rate == 1.0)
		{
			return;
		}
		EMovementProcessDirection movementProcessDirection = this.MovementProcessDirection;
		if (movementProcessDirection != EMovementProcessDirection.AlongTrack)
		{
			if (movementProcessDirection == EMovementProcessDirection.TowardsTarget)
			{
				@params.TargetPos.Subtraction(@params.CharActorComp.ActorLocationProxy, this.TmpVector);
				Singleton<MathUtils>.Instance.LookRotationUpFirst(this.TmpVector, global::Vector.UpVectorProxy, this.TmpQuat);
				this.TmpQuat.Rotator(this.TmpRotator);
				@params.CharActorComp.SetActorRotation(this.TmpRotator.ToUeRotator(), "TsAnimNotifyStateCurveMove.TowardsTarget", false);
				return;
			}
		}
		else
		{
			@params.TargetPos.Subtraction(@params.InitLocation, this.TmpVector);
			Singleton<MathUtils>.Instance.LookRotationUpFirst(this.TmpVector, global::Vector.UpVectorProxy, this.TmpQuat);
			this.TmpQuat.Rotator(this.TmpRotator);
			@params.CharActorComp.SetActorRotation(this.TmpRotator.ToUeRotator(), "TsAnimNotifyStateCurveMove.AlongTrack", false);
		}
	}

	// Token: 0x060046E9 RID: 18153 RVA: 0x00092260 File Offset: 0x00090460
	private unsafe void MoveToTargetAlongSpline(double delta, CurveMoveParams @params)
	{
		@params.TargetPos.DeepCopy(@params.LastTargetPos);
		if (this.ContinuallyUpdateTargetPosition)
		{
			@params.LastTargetPos.DeepCopy(@params.TargetPos);
			this.GetTargetPos(@params, @params.TargetPos);
		}
		double towardVector = this.GetTowardVector(@params, @params.TargetVec);
		double rate = this.GetRate(delta, @params);
		if (rate <= 0.0 || towardVector < 0.0)
		{
			return;
		}
		if (this.ContinuallyUpdateTargetPosition && rate > 0.0)
		{
			int splinePointsNum = this.SplineCurves.GetSplinePointsNum();
			this.SplineCurves.GetWorldLocationAtSplinePoint(splinePointsNum - 1, this.TmpVector);
			double num = global::Vector.DistSquared(this.TmpVector, @params.TargetPos);
			if (num > 100.0 && num < 1000000.0)
			{
				this.SplineCurves.SetLocationAtSplinePoint(splinePointsNum - 1, @params.TargetPos, ESplineCoordinateSpace.World, true);
				bool debugMode = this.DebugMode;
			}
		}
		double num2 = (double)this.SplineCurves.GetSplineLength() * rate;
		double num3 = delta * (double)this.MaxMoveSpeed;
		@params.LastSplineDistance = (float)num2;
		if (num3 > 0.0001)
		{
			double val = (double)@params.LastSplineDistance + num3;
			@params.LastSplineDistance = (float)Math.Min(num2, val);
		}
		this.SplineCurves.GetTransformAtDistanceAlongSpline(Math.Min(@params.LastSplineDistance, this.SplineCurves.GetSplineLength() - 1f), ESplineCoordinateSpace.World, this.TmpTransform);
		global::Vector location = this.TmpTransform.GetLocation();
		this.TmpVector.DeepCopy(location);
		this.TmpVector.SubtractionEqual(@params.CharActorComp.ActorLocationProxy);
		if (this.DebugMode)
		{
			UKismetSystemLibrary.D_DrawDebugArrow(GlobalData.World, @params.CharActorComp.ActorLocation, location.ToUeVector(false), (float)this.TmpVector.Size(), ColorUtils.LinearWhite, 0f, 0f);
		}
		double num4 = this.TmpVector.Size();
		if (num3 > 0.0001)
		{
			num4 = Math.Min(num4, num3);
		}
		CharacterUnifiedStateComponent charUnifiedComp = @params.CharUnifiedComp;
		if (charUnifiedComp != null && charUnifiedComp.PositionState == global::ECharPositionState.Ground && num4 < 1.0)
		{
			return;
		}
		this.TmpVector.Normalize(9.99999993922529E-09);
		this.TmpVector.MultiplyEqual(num4);
		if (this.DebugMode)
		{
			this.DebugDraw(location.ToUeVector(false), ColorUtils.LinearWhite, 30f, 5);
		}
		@params.LastLocation.Subtraction(@params.CharActorComp.ActorLocationProxy, this.TmpVector2);
		if (this.TmpVector2.SizeSquared() > 1000000.0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "LastLocation太远，很危险，无视掉";
			<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "Actor";
			CharacterActorComponent charActorComp = @params.CharActorComp;
			object item2;
			if (charActorComp == null)
			{
				item2 = null;
			}
			else
			{
				TsBaseCharacter actor = charActorComp.Actor;
				item2 = ((actor != null) ? actor.GetName() : null);
			}
			ptr = new ValueTuple<string, object>(item, item2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Last", @params.LastLocation);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
			string item3 = "ActorLast";
			CharacterActorComponent charActorComp2 = @params.CharActorComp;
			ptr2 = new ValueTuple<string, object>(item3, (charActorComp2 != null) ? charActorComp2.LastActorLocation : null);
			ref ValueTuple<string, object> ptr3 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3);
			string item4 = "Now";
			CharacterActorComponent charActorComp3 = @params.CharActorComp;
			ptr3 = new ValueTuple<string, object>(item4, (charActorComp3 != null) ? charActorComp3.ActorLocationProxy : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("TargetVec", @params.TargetVec);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("TmpVector", this.TmpVector);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
			this.TmpVector.Reset();
		}
		@params.CharActorComp.MoveComp.ClampOffsetByChain(this.TmpVector);
		if (!@params.FlyingMove)
		{
			@params.CharActorComp.MoveComp.MoveCharacter(this.TmpVector, (float)delta, "TsAnimNotifyStateCurveMove沿样条移动");
		}
		else
		{
			@params.CharActorComp.AddActorWorldOffset(this.TmpVector.ToUeVector(false), "TsAnimNotifyStateCurveMove沿样条移动.AddActorWorldOffset", true);
			@params.CharActorComp.ResetAllCachedTime();
		}
		if (rate == 1.0)
		{
			return;
		}
		EMovementProcessDirection movementProcessDirection = this.MovementProcessDirection;
		if (movementProcessDirection != EMovementProcessDirection.AlongTrack)
		{
			if (movementProcessDirection == EMovementProcessDirection.TowardsTarget)
			{
				@params.TargetPos.Subtraction(@params.CharActorComp.ActorLocationProxy, this.TmpVector);
				Singleton<MathUtils>.Instance.LookRotationUpFirst(this.TmpVector, @params.CharActorComp.ActorUpProxy, this.TmpQuat);
				this.TmpQuat.Rotator(this.TmpRotator);
				@params.CharActorComp.SetActorRotation(this.TmpRotator.ToUeRotator(), "TsAnimNotifyStateCurveMove.TowardsTarget", false);
				return;
			}
		}
		else
		{
			this.TmpQuat.FromUeQuat(this.TmpTransform.GetRotation());
			this.TmpRotator.DeepCopy(this.TmpQuat.Rotator(null));
			@params.CharActorComp.SetActorRotation(this.TmpRotator.ToUeRotator(), "TsAnimNotifyStateCurveMove.AlongTrack", false);
		}
	}

	// Token: 0x060046EA RID: 18154 RVA: 0x0009274A File Offset: 0x0009094A
	private void DebugDraw(FVectorDouble location, FLinearColor color, float radius = 30f, int duration = 5)
	{
		UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.World, location, radius, 10, new FLinearColor?(color), (float)duration, 0f);
	}

	// Token: 0x060046EB RID: 18155 RVA: 0x00092768 File Offset: 0x00090968
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

	// Token: 0x060046EC RID: 18156 RVA: 0x000927E3 File Offset: 0x000909E3
	protected override string GetNotifyName_Implementation()
	{
		return "曲线定点位移";
	}

	// Token: 0x060046ED RID: 18157 RVA: 0x000927EA File Offset: 0x000909EA
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateCurveMove._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateCurveMove.TsAnimNotifyStateCurveMove_C");
		}
		return TsAnimNotifyStateCurveMove._ClassPtr;
	}

	// Token: 0x060046EE RID: 18158 RVA: 0x00092810 File Offset: 0x00090A10
	public TsAnimNotifyStateCurveMove() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateCurveMove.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060046EF RID: 18159 RVA: 0x00092838 File Offset: 0x00090A38
	public TsAnimNotifyStateCurveMove(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateCurveMove.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060046F0 RID: 18160 RVA: 0x0009286C File Offset: 0x00090A6C
	protected TsAnimNotifyStateCurveMove(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060046F1 RID: 18161 RVA: 0x000928C4 File Offset: 0x00090AC4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x060046F2 RID: 18162 RVA: 0x00092900 File Offset: 0x00090B00
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x060046F3 RID: 18163 RVA: 0x0009293C File Offset: 0x00090B3C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060046F4 RID: 18164 RVA: 0x0009296F File Offset: 0x00090B6F
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001332 RID: 4914
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public TArray<SSkillBehaviorCondition> SkillBehaviorCondition;

	// Token: 0x04001333 RID: 4915
	public string SkillBehaviorConditionFormula = "";

	// Token: 0x04001334 RID: 4916
	public bool IgnoreObstacle;

	// Token: 0x04001335 RID: 4917
	[Nullable(2)]
	public SplineCurve SplineCurves;

	// Token: 0x04001336 RID: 4918
	public bool ContinuallyUpdateTargetPosition;

	// Token: 0x04001337 RID: 4919
	public EPositionDatumTarget PositionDatumTarget;

	// Token: 0x04001338 RID: 4920
	public string TargetSocketPosition = "None";

	// Token: 0x04001339 RID: 4921
	public string TargetParam = "None";

	// Token: 0x0400133A RID: 4922
	public ECurveMoveTargetBlackboardType TargetParamType;

	// Token: 0x0400133B RID: 4923
	public EOffsetDirectionDatum OffsetDirectionDatum;

	// Token: 0x0400133C RID: 4924
	public bool ProjectionGravityDirection;

	// Token: 0x0400133D RID: 4925
	[Nullable(2)]
	public global::Vector TargetPositionOffset;

	// Token: 0x0400133E RID: 4926
	public bool MakePositionCorrection;

	// Token: 0x0400133F RID: 4927
	[Nullable(2)]
	public SSkillBehaviorAction PositionCorrectionConfig;

	// Token: 0x04001340 RID: 4928
	[Nullable(2)]
	public UCurveFloat MovementPositionCurve;

	// Token: 0x04001341 RID: 4929
	public EMovementProcessDirection MovementProcessDirection;

	// Token: 0x04001342 RID: 4930
	public bool EndLocationDetection;

	// Token: 0x04001343 RID: 4931
	public float EndLocationDetectionDist = 1000f;

	// Token: 0x04001344 RID: 4932
	public float MaxMoveDistance = 3000f;

	// Token: 0x04001345 RID: 4933
	public float MaxMoveSpeed = -1f;

	// Token: 0x04001346 RID: 4934
	[Nullable(2)]
	private global::Vector TmpVector;

	// Token: 0x04001347 RID: 4935
	[Nullable(2)]
	private global::Vector TmpVector2;

	// Token: 0x04001348 RID: 4936
	[Nullable(2)]
	private global::Vector TmpVector3;

	// Token: 0x04001349 RID: 4937
	[Nullable(2)]
	private global::Vector TmpVector4;

	// Token: 0x0400134A RID: 4938
	[Nullable(2)]
	private global::Rotator TmpRotator;

	// Token: 0x0400134B RID: 4939
	[Nullable(2)]
	private Quat TmpQuat;

	// Token: 0x0400134C RID: 4940
	[Nullable(2)]
	private Quat TmpQuat2;

	// Token: 0x0400134D RID: 4941
	[Nullable(2)]
	private global::Transform TmpTransform;

	// Token: 0x0400134E RID: 4942
	private bool InitCacheVar;

	// Token: 0x0400134F RID: 4943
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<CurveMoveParams> ParamPool;

	// Token: 0x04001350 RID: 4944
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, CurveMoveParams> ParamMap;

	// Token: 0x04001351 RID: 4945
	[StaticVariableRuleIgnore]
	public static readonly int[] angles = new int[]
	{
		0,
		270,
		90,
		180
	};

	// Token: 0x04001352 RID: 4946
	private const float MIN_MOVE_DISTANCE = 50f;

	// Token: 0x04001353 RID: 4947
	private const float MIN_MOVE_DISTANCE_SQUARED = 2500f;

	// Token: 0x04001354 RID: 4948
	private const float MIN_UPDATE_SPLINE_LENGTH = 100f;

	// Token: 0x04001355 RID: 4949
	private const float MIN_UPDATE_SPLINE_LENGTH_SQUARED = 10000f;

	// Token: 0x04001356 RID: 4950
	private const string PROFILE_KEY = "TsAnimNotifyStateCurveMove";

	// Token: 0x04001357 RID: 4951
	private const float INVALID_LAST_LOCATION_THRESHOLD_SQUARED = 1000000f;

	// Token: 0x04001358 RID: 4952
	private const float DEBUG_RADIUS = 30f;

	// Token: 0x04001359 RID: 4953
	private const int DEBUG_DURATION = 5;

	// Token: 0x0400135A RID: 4954
	private const int DEBUG_SEGMENTS = 10;

	// Token: 0x0400135B RID: 4955
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateCurveMove.TsAnimNotifyStateCurveMove_C";

	// Token: 0x0400135C RID: 4956
	private static IntPtr _ClassPtr;

	// Token: 0x0400135D RID: 4957
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400135E RID: 4958
	private static int __PropertyOffset_DebugMode;

	// Token: 0x0400135F RID: 4959
	private static int __PropertyOffset_技能条件;

	// Token: 0x04001360 RID: 4960
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<SSkillBehaviorCondition> _技能条件;

	// Token: 0x04001361 RID: 4961
	private static int __PropertyOffset_技能条件公式;

	// Token: 0x04001362 RID: 4962
	private static int __PropertyOffset_无视障碍阻挡;

	// Token: 0x04001363 RID: 4963
	private static int __PropertyOffset_运动轨迹曲线;

	// Token: 0x04001364 RID: 4964
	[Nullable(2)]
	private FSoftObjectPath _运动轨迹曲线;

	// Token: 0x04001365 RID: 4965
	private static int __PropertyOffset_持续更新目标位置;

	// Token: 0x04001366 RID: 4966
	private static int __PropertyOffset_位置基准目标;

	// Token: 0x04001367 RID: 4967
	private static int __PropertyOffset_基于目标骨骼位置;

	// Token: 0x04001368 RID: 4968
	private static int __PropertyOffset_目标参数;

	// Token: 0x04001369 RID: 4969
	private static int __PropertyOffset_目标参数类型;

	// Token: 0x0400136A RID: 4970
	private static int __PropertyOffset_偏移方向基准;

	// Token: 0x0400136B RID: 4971
	private static int __PropertyOffset_偏移基准消除重力分量;

	// Token: 0x0400136C RID: 4972
	private static int __PropertyOffset_目标位置偏移;

	// Token: 0x0400136D RID: 4973
	private static int __PropertyOffset_位置修正;

	// Token: 0x0400136E RID: 4974
	private static int __PropertyOffset_位置修正配置;

	// Token: 0x0400136F RID: 4975
	[Nullable(2)]
	private SSkillBehaviorAction _位置修正配置;

	// Token: 0x04001370 RID: 4976
	private static int __PropertyOffset_运动位置曲线;

	// Token: 0x04001371 RID: 4977
	private static int __PropertyOffset_运动过程朝向;

	// Token: 0x04001372 RID: 4978
	private static int __PropertyOffset_自动更新运动轨迹曲线关键点;

	// Token: 0x04001373 RID: 4979
	private static int __PropertyOffset_运动轨迹曲线关键点;

	// Token: 0x04001374 RID: 4980
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<FSplinePoint> _运动轨迹曲线关键点;

	// Token: 0x04001375 RID: 4981
	private static int __PropertyOffset_运动轨迹曲线插值ReparamTable;

	// Token: 0x04001376 RID: 4982
	[Nullable(2)]
	private TArray<FInterpCurvePointFloat> _运动轨迹曲线插值ReparamTable;

	// Token: 0x04001377 RID: 4983
	private static int __PropertyOffset_终点贴地检测;

	// Token: 0x04001378 RID: 4984
	private static int __PropertyOffset_终点贴地检测距离;

	// Token: 0x04001379 RID: 4985
	private static int __PropertyOffset_最大位移距离;

	// Token: 0x0400137A RID: 4986
	private static int __PropertyOffset_最大移动速度;
}
