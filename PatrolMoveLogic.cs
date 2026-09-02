using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x020030E2 RID: 12514
[NullableContext(1)]
[Nullable(0)]
public class PatrolMoveLogic
{
	// Token: 0x06019DD6 RID: 105942 RVA: 0x0078E88F File Offset: 0x0078CA8F
	public void Init(Entity entity)
	{
		this.Entity = entity;
		this.ActorComp = entity.CheckGetComponent<CharacterActorComponent>();
		this.AnimComp = entity.CheckGetComponent<CharacterAnimationComponent>();
		this.StateComp = entity.GetComponent<BaseUnifiedStateComponent>();
	}

	// Token: 0x06019DD7 RID: 105943 RVA: 0x0078E8BC File Offset: 0x0078CABC
	[NullableContext(2)]
	public Vector GetMovePoint(int index)
	{
		if (index >= 0 && index < this.MovePoint.Count)
		{
			return this.MovePoint[index];
		}
		return null;
	}

	// Token: 0x06019DD8 RID: 105944 RVA: 0x0078E8DE File Offset: 0x0078CADE
	public void UpdateMovePath(List<Vector> path, bool fly, float turnSpeed, float distance)
	{
		this.MovePoint.Clear();
		this.MovePoint.AddRange(path);
		this.Distance = distance;
		this.IsFly = fly;
		this.TurnSpeed = turnSpeed;
		this.CurrentIndex = 0;
		this.UpdateMovePoint(1);
	}

	// Token: 0x06019DD9 RID: 105945 RVA: 0x0078E91B File Offset: 0x0078CB1B
	public void StopMove()
	{
		this.MovePoint.Clear();
		this.PreviousIndex = 0;
		this.CurrentIndex = 0;
	}

	// Token: 0x06019DDA RID: 105946 RVA: 0x0078E938 File Offset: 0x0078CB38
	public bool UpdateMove(float deltaSeconds)
	{
		if (this.GetMovePoint(this.CurrentIndex) == null)
		{
			this.StopMove();
			return false;
		}
		if (GlobalData.IsPlayInEditor && MoveToLocationController.DebugDraw)
		{
			this.DrawDebug();
		}
		this.UpdateCurrentTargetVector();
		int num = 0;
		while (this.CheckExceedTargetPoint() && num < 2)
		{
			num++;
			if (this.CurrentIndex == this.MovePoint.Count - 1)
			{
				return false;
			}
			this.UpdateMovePoint(this.CurrentIndex + 1);
		}
		this.DirectionVector.Normalize(9.99999993922529E-09);
		BaseUnifiedStateComponent stateComp = this.StateComp;
		if (stateComp != null && stateComp.PositionState == ECharPositionState.Climb)
		{
			this.CacheQuat.DeepCopy(this.ActorComp.ActorQuatProxy);
			this.CacheQuat.Inverse(this.CacheQuat);
			this.CacheQuat.RotateVector(this.DirectionVector, this.DirectionVector);
			float num2 = (float)this.DirectionVector.X;
			this.DirectionVector.X = this.DirectionVector.Z;
			this.DirectionVector.Z = (double)num2;
			this.ActorComp.SetInputDirect(this.DirectionVector, false);
			return true;
		}
		this.ActorComp.SetOverrideTurnSpeed(new float?(this.TurnSpeed));
		if (this.IsFly)
		{
			this.ActorComp.SetInputDirect(this.ActorComp.ActorForwardProxy, false);
		}
		else
		{
			this.ActorComp.SetInputDirect(this.DirectionVector, false);
		}
		AiControllerLibrary.TurnToDirect(this.ActorComp, this.DirectionVector, this.TurnSpeed, this.IsFly, 0f);
		return true;
	}

	// Token: 0x06019DDB RID: 105947 RVA: 0x0078EADA File Offset: 0x0078CCDA
	private void UpdateMovePoint(int newIndex)
	{
		this.PreviousIndex = this.CurrentIndex;
		this.CurrentIndex = newIndex;
		this.CurrentToLocation = this.MovePoint[this.CurrentIndex];
		this.UpdateCurrentTargetVector();
	}

	// Token: 0x06019DDC RID: 105948 RVA: 0x0078EB0C File Offset: 0x0078CD0C
	private void UpdateCurrentTargetVector()
	{
		this.DirectionVector.DeepCopy(this.CurrentToLocation);
		this.DirectionVector.SubtractionEqual(this.ActorComp.ActorLocationProxy);
		this.CurrentToTargetVector.DeepCopy(this.DirectionVector);
		BaseUnifiedStateComponent stateComp = this.StateComp;
		if (stateComp != null && stateComp.PositionState == ECharPositionState.Climb)
		{
			this.CacheVector.DeepCopy(this.DirectionVector);
			float num = (float)this.CacheVector.DotProduct(this.ActorComp.ActorForwardProxy);
			this.CacheVector.DeepCopy(this.ActorComp.ActorForwardProxy);
			this.CacheVector.MultiplyEqual((double)num);
			this.CacheVector.UnaryNegation(this.CacheVector);
			this.CacheVector.AdditionEqual(this.DirectionVector);
			this.DirectionVector.DeepCopy(this.CacheVector);
		}
		else if (!this.IsFly)
		{
			this.DirectionVector.Z = 0.0;
		}
		this.CurrentDistance = (float)(this.IsFly ? this.CurrentToTargetVector.Size() : this.CurrentToTargetVector.Size2D());
	}

	// Token: 0x06019DDD RID: 105949 RVA: 0x0078EC34 File Offset: 0x0078CE34
	private bool CheckExceedTargetPoint()
	{
		if (this.PreviousIndex == this.CurrentIndex || this.CurrentDistance <= this.Distance)
		{
			this.ResetActorLocation();
			return true;
		}
		this.CurrentToLocation.Subtraction(this.MovePoint[this.PreviousIndex], this.CacheVector);
		Singleton<GravityUtils>.Instance.SetZnInGravityForActor(this.ActorComp, this.CacheVector, 0.0);
		this.CacheVector2.DeepCopy(this.CurrentToTargetVector);
		Singleton<GravityUtils>.Instance.SetZnInGravityForActor(this.ActorComp, this.CacheVector2, 0.0);
		float num = (float)this.CacheVector2.DotProduct(this.CacheVector);
		if (num < 0f || this.CurrentDistance < this.Distance)
		{
			this.ResetActorLocation();
		}
		return num < 0f || this.CurrentDistance < this.Distance;
	}

	// Token: 0x06019DDE RID: 105950 RVA: 0x0078ED1C File Offset: 0x0078CF1C
	private void ResetActorLocation()
	{
		this.LastPatrolPoint.DeepCopy(this.CurrentToLocation);
	}

	// Token: 0x06019DDF RID: 105951 RVA: 0x0078ED30 File Offset: 0x0078CF30
	public bool ResetLastPointCondition()
	{
		if (this.LastPatrolPoint.Size() < 1.0)
		{
			return false;
		}
		if (Vector.Dist2D(this.LastPatrolPoint, this.ActorComp.ActorLocationProxy) < (double)(this.Distance + 10f))
		{
			this.LastPatrolPoint.Set(0.0, 0.0, 0.0);
			return false;
		}
		return true;
	}

	// Token: 0x06019DE0 RID: 105952 RVA: 0x0078EDA4 File Offset: 0x0078CFA4
	public void ResetLastPatrolPoint(float deltaSeconds)
	{
		CharacterAnimationComponent animComp = this.AnimComp;
		if (animComp != null)
		{
			UAnimInstance mainAnimInstance = animComp.MainAnimInstance;
			if (mainAnimInstance != null)
			{
				mainAnimInstance.ConsumeExtractedRootMotion(1f);
			}
		}
		this.ActorComp.ClearInput(false, true);
		if (this.AnimComp != null && this.Entity.GetTickInterval() > 1)
		{
			FTransformDouble meshTransform = this.AnimComp.GetMeshTransform();
			this.SetLocationAndRotation();
			this.AnimComp.SetModelBuffer(meshTransform, deltaSeconds * 1000f * ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
		}
		else
		{
			this.SetLocationAndRotation();
		}
		this.LastPatrolPoint.Set(0.0, 0.0, 0.0);
	}

	// Token: 0x06019DE1 RID: 105953 RVA: 0x0078EE54 File Offset: 0x0078D054
	private unsafe void SetLocationAndRotation()
	{
		if (this.IsFly)
		{
			this.ActorComp.SetActorLocation(this.LastPatrolPoint.ToUeVector(false), "拉回目标点设置坐标", false);
			return;
		}
		if (!this.ActorComp.FixBornLocation("拉回目标点地面修正", true, this.LastPatrolPoint, false, true, true))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "未能检测到地面，没设置拉回目标点";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", this.Entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PbDataId", this.ActorComp.CreatureData.GetPbDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("LastPatrolPoint", this.LastPatrolPoint);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("ActorLocation", this.ActorComp.ActorLocationProxy);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
	}

	// Token: 0x06019DE2 RID: 105954 RVA: 0x0078EF5C File Offset: 0x0078D15C
	private void DrawDebug()
	{
		if (this.MovePoint.Count == 0 || !GlobalData.IsPlayInEditor)
		{
			return;
		}
		for (int i = this.MovePoint.Count - 1; i > -1; i--)
		{
			Vector vector = this.MovePoint[i];
			UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.World, vector.ToUeVector(false), 35f, 10, new FLinearColor?((i == this.CurrentIndex) ? ColorUtils.LinearRed : ColorUtils.LinearGreen), 1f, 0f);
		}
	}

	// Token: 0x06019DE3 RID: 105955 RVA: 0x0078EFE0 File Offset: 0x0078D1E0
	public void ForceSetToLastPatrolPoint(Vector targetLocation, float deltaSeconds)
	{
		this.LastPatrolPoint.DeepCopy(targetLocation);
		CharacterAnimationComponent animComp = this.AnimComp;
		if (animComp != null)
		{
			UAnimInstance mainAnimInstance = animComp.MainAnimInstance;
			if (mainAnimInstance != null)
			{
				mainAnimInstance.ConsumeExtractedRootMotion(1f);
			}
		}
		this.ActorComp.ClearInput(false, true);
		if (this.AnimComp != null && this.Entity.GetTickInterval() > 1)
		{
			FTransformDouble meshTransform = this.AnimComp.GetMeshTransform();
			this.SetLocationAndRotation();
			this.AnimComp.SetModelBuffer(meshTransform, deltaSeconds * 1000f * ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
		}
		else
		{
			this.SetLocationAndRotation();
		}
		this.LastPatrolPoint.Set(0.0, 0.0, 0.0);
	}

	// Token: 0x0400CEF1 RID: 52977
	private const int WHILE_UPDATE_MOVE_POINT_COUNT = 2;

	// Token: 0x0400CEF2 RID: 52978
	private const float RESET_LOCATION_TOLERANCE = 10f;

	// Token: 0x0400CEF3 RID: 52979
	[Nullable(2)]
	protected Entity Entity;

	// Token: 0x0400CEF4 RID: 52980
	[Nullable(2)]
	private CharacterActorComponent ActorComp;

	// Token: 0x0400CEF5 RID: 52981
	[Nullable(2)]
	private CharacterAnimationComponent AnimComp;

	// Token: 0x0400CEF6 RID: 52982
	[Nullable(2)]
	private BaseUnifiedStateComponent StateComp;

	// Token: 0x0400CEF7 RID: 52983
	private bool IsFly;

	// Token: 0x0400CEF8 RID: 52984
	private float TurnSpeed;

	// Token: 0x0400CEF9 RID: 52985
	private float Distance;

	// Token: 0x0400CEFA RID: 52986
	private readonly Vector CacheVector = Vector.Create();

	// Token: 0x0400CEFB RID: 52987
	private readonly Vector CacheVector2 = Vector.Create();

	// Token: 0x0400CEFC RID: 52988
	private readonly Quat CacheQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400CEFD RID: 52989
	private float CurrentDistance;

	// Token: 0x0400CEFE RID: 52990
	private readonly Vector DirectionVector = Vector.Create();

	// Token: 0x0400CEFF RID: 52991
	private readonly Vector CurrentToTargetVector = Vector.Create();

	// Token: 0x0400CF00 RID: 52992
	private readonly Vector LastPatrolPoint = Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x0400CF01 RID: 52993
	private int PreviousIndex;

	// Token: 0x0400CF02 RID: 52994
	private int CurrentIndex;

	// Token: 0x0400CF03 RID: 52995
	private Vector CurrentToLocation = Vector.Create();

	// Token: 0x0400CF04 RID: 52996
	private readonly List<Vector> MovePoint = new List<Vector>();
}
