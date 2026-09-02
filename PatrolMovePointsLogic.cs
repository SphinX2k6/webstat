using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.LevelGamePlay;
using UnrealEngine;

// Token: 0x020030E3 RID: 12515
[NullableContext(1)]
[Nullable(0)]
public class PatrolMovePointsLogic
{
	// Token: 0x06019DE5 RID: 105957 RVA: 0x0078F136 File Offset: 0x0078D336
	public void Init(CharacterActorComponent actorComp)
	{
		this.ActorComp = actorComp;
	}

	// Token: 0x06019DE6 RID: 105958 RVA: 0x0078F13F File Offset: 0x0078D33F
	public void Reset()
	{
		this.TargetIndex = 0;
		this.PreviousIndex = -1;
	}

	// Token: 0x06019DE7 RID: 105959 RVA: 0x0078F14F File Offset: 0x0078D34F
	public bool CheckMoveLastPoint()
	{
		return !this.IsLoop && this.TargetIndex == this.MovePoint.Count - 1;
	}

	// Token: 0x06019DE8 RID: 105960 RVA: 0x0078F170 File Offset: 0x0078D370
	[NullableContext(2)]
	public global::Vector GetPreviousLocation()
	{
		if (this.PreviousIndex < 0)
		{
			return null;
		}
		return this.MovePoint[this.PreviousIndex].Position;
	}

	// Token: 0x06019DE9 RID: 105961 RVA: 0x0078F194 File Offset: 0x0078D394
	public unsafe void UpdateMovePoints(MoveCharacterConfig config)
	{
		IList<MoveCharacterPoint> list;
		if (config.Points.IsT2)
		{
			list = config.Points.AsT2;
		}
		else
		{
			list = new MoveCharacterPoint[]
			{
				config.Points.AsT1
			};
		}
		bool flag = true;
		if (!this.IsPathEqual(this.MovePoint, list))
		{
			this.PreviousIndex = -1;
			if (config.Loop && !config.CircleMove.GetValueOrDefault() && config.StartWithInversePath != null)
			{
				this.InversePath = config.StartWithInversePath.Value;
			}
		}
		else
		{
			flag = false;
		}
		this.MovePoint = list;
		this.IsLoop = config.Loop;
		this.IsCircle = config.CircleMove.GetValueOrDefault();
		if (config.StartIndex != null)
		{
			int? startIndex = config.StartIndex;
			int num = 0;
			if (startIndex.GetValueOrDefault() >= num & startIndex != null)
			{
				startIndex = config.StartIndex;
				num = this.MovePoint.Count;
				if (startIndex.GetValueOrDefault() < num & startIndex != null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.AI;
					ELogAuthor author = ELogAuthor.YJX;
					string message = "使用起始点移动";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("实体ID", this.ActorComp.CreatureData.GetPbDataId());
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("初始点Index", config.StartIndex);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("TargetIndex", this.TargetIndex);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					this.UpdateMoveTarget(config.StartIndex.Value);
					return;
				}
			}
		}
		if (config.UsePreviousIndex.GetValueOrDefault() && this.PreviousIndex >= 0 && this.PreviousIndex < this.MovePoint.Count)
		{
			this.UpdateMoveTarget(this.PreviousIndex);
			if (this.GetNextPoint() < this.MovePoint.Count)
			{
				this.UpdateMoveTarget(this.GetNextPoint());
				return;
			}
		}
		else
		{
			if (config.UseNearestPoint.GetValueOrDefault() && flag)
			{
				this.UpdateNearestPoint();
				return;
			}
			this.UpdateMoveTarget(0);
		}
	}

	// Token: 0x06019DEA RID: 105962 RVA: 0x0078F3C0 File Offset: 0x0078D5C0
	public bool ChangeToNextPoint()
	{
		return this.UpdateMoveIndex(this.GetNextPoint());
	}

	// Token: 0x06019DEB RID: 105963 RVA: 0x0078F3D0 File Offset: 0x0078D5D0
	public int GetNextPoint()
	{
		int result;
		if (this.IsLoop)
		{
			if (this.IsCircle)
			{
				result = (this.TargetIndex + 1) % this.MovePoint.Count;
			}
			else if (this.InversePath)
			{
				if (this.TargetIndex == 0)
				{
					this.InversePath = false;
					result = 0;
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.AI;
					ELogAuthor author = ELogAuthor.YJX;
					string message = "往返式巡逻：回到起点";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PbDataID", this.ActorComp.CreatureData.GetPbDataId());
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					EntityPatrolChangeDirRequest message2 = new EntityPatrolChangeDirRequest
					{
						EntityId = Singleton<MathUtils>.Instance.NumberToLong(this.ActorComp.CreatureData.GetCreatureDataId()),
						Dir = true
					};
					Singleton<Net>.Instance.Call<EntityPatrolChangeDirResponse>(ERequestMessageId.EntityPatrolChangeDirRequest, message2, delegate(EntityPatrolChangeDirResponse response, Net.CallbackStatus _)
					{
					}, 0);
				}
				else
				{
					result = this.TargetIndex - 1;
				}
			}
			else if (this.TargetIndex == this.MovePoint.Count - 1)
			{
				this.InversePath = true;
				result = this.MovePoint.Count - 2;
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.AI;
				ELogAuthor author2 = ELogAuthor.YJX;
				string message3 = "往返式巡逻：走到终点";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("PbDataID", this.ActorComp.CreatureData.GetPbDataId());
				instance2.Info(module2, author2, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				EntityPatrolChangeDirRequest message4 = new EntityPatrolChangeDirRequest
				{
					EntityId = Singleton<MathUtils>.Instance.NumberToLong(this.ActorComp.CreatureData.GetCreatureDataId()),
					Dir = false
				};
				Singleton<Net>.Instance.Call<EntityPatrolChangeDirResponse>(ERequestMessageId.EntityPatrolChangeDirRequest, message4, delegate(EntityPatrolChangeDirResponse response, Net.CallbackStatus _)
				{
				}, 0);
			}
			else
			{
				result = this.TargetIndex + 1;
			}
		}
		else
		{
			result = this.TargetIndex + 1;
		}
		return result;
	}

	// Token: 0x06019DEC RID: 105964 RVA: 0x0078F5B4 File Offset: 0x0078D7B4
	public void OnArriveMovePoint()
	{
		MoveCharacterPoint targetPoint = this.TargetPoint;
		if (targetPoint != null && targetPoint.Index == -1)
		{
			return;
		}
		if (((targetPoint != null) ? targetPoint.Actions : null) != null && targetPoint.Actions.Count > 0)
		{
			ControllerBase<LevelGeneralController>.Instance.ExecuteActionsNew(targetPoint.Actions, EntityContext.Create(this.ActorComp.Entity.Id, null), null);
		}
		if (targetPoint != null)
		{
			Action callback = targetPoint.Callback;
			if (callback != null)
			{
				callback();
			}
		}
		if (targetPoint != null && targetPoint.IsHide.GetValueOrDefault())
		{
			this.SetMoveHide(targetPoint);
		}
	}

	// Token: 0x06019DED RID: 105965 RVA: 0x0078F64C File Offset: 0x0078D84C
	private void SetMoveHide(MoveCharacterPoint curPoint)
	{
		USkeletalMeshComponent skeletalMesh = this.ActorComp.SkeletalMesh;
		if (skeletalMesh != null)
		{
			bool? isHide = curPoint.IsHide;
			bool flag = false;
			skeletalMesh.SetVisibility(isHide.GetValueOrDefault() == flag & isHide != null, false);
		}
		BaseTagComponent component = this.ActorComp.Entity.GetComponent<BaseTagComponent>();
		if (component == null)
		{
			return;
		}
		int num = GameplayTagDefine.EGameplayTagId["怪物.common.状态标识.巡逻中隐身"];
		if (curPoint.IsHide.GetValueOrDefault())
		{
			if (!component.HasTag(num))
			{
				component.AddTag(new int?(num));
				return;
			}
		}
		else if (component.HasTag(num))
		{
			component.RemoveTag(new int?(num));
		}
	}

	// Token: 0x06019DEE RID: 105966 RVA: 0x0078F6EC File Offset: 0x0078D8EC
	public int UpdatePreIndex()
	{
		if (this.PreviousIndex < 0)
		{
			if (!this.InversePath)
			{
				this.PreviousIndex = Math.Max(0, this.TargetIndex - 1);
			}
			else
			{
				this.PreviousIndex = Math.Min(this.MovePoint.Count, this.TargetIndex + 1);
			}
		}
		return this.PreviousIndex;
	}

	// Token: 0x06019DEF RID: 105967 RVA: 0x0078F744 File Offset: 0x0078D944
	private bool IsPointEqual(MoveCharacterPoint point, MoveCharacterPoint otherPoint)
	{
		return point == otherPoint || (point != null && otherPoint != null && point.Index == otherPoint.Index && point.Position.Equals(otherPoint.Position, 9.999999747378752E-05));
	}

	// Token: 0x06019DF0 RID: 105968 RVA: 0x0078F784 File Offset: 0x0078D984
	private bool IsPathEqual(IList<MoveCharacterPoint> path, IList<MoveCharacterPoint> otherPath)
	{
		if (path == otherPath)
		{
			return true;
		}
		if (path == null || otherPath == null)
		{
			return false;
		}
		if (path.Count != otherPath.Count)
		{
			return false;
		}
		int count = path.Count;
		for (int i = 0; i < count; i++)
		{
			if (!this.IsPointEqual(path[i], otherPath[i]))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06019DF1 RID: 105969 RVA: 0x0078F7DB File Offset: 0x0078D9DB
	private bool UpdateMoveIndex(int newIndex)
	{
		this.PreviousIndex = this.TargetIndex;
		return this.UpdateMoveTarget(newIndex);
	}

	// Token: 0x06019DF2 RID: 105970 RVA: 0x0078F7F0 File Offset: 0x0078D9F0
	private bool UpdateMoveTarget(int newIndex)
	{
		this.TargetIndex = newIndex;
		if (this.TargetIndex < this.MovePoint.Count)
		{
			this.TargetPoint = this.MovePoint[this.TargetIndex];
			return true;
		}
		this.TargetPoint = null;
		return false;
	}

	// Token: 0x06019DF3 RID: 105971 RVA: 0x0078F830 File Offset: 0x0078DA30
	private void UpdateNearestPoint()
	{
		int nearestPatrolPointIndex = this.GetNearestPatrolPointIndex();
		this.TargetIndex = ((nearestPatrolPointIndex - 1 >= 0) ? (nearestPatrolPointIndex - 1) : 0);
		this.UpdateMoveTarget(nearestPatrolPointIndex);
	}

	// Token: 0x06019DF4 RID: 105972 RVA: 0x0078F860 File Offset: 0x0078DA60
	private int GetNearestPatrolPointIndex()
	{
		int num = 0;
		float num2 = float.MaxValue;
		global::Vector actorLocationProxy = this.ActorComp.ActorLocationProxy;
		for (int i = 0; i < this.MovePoint.Count; i++)
		{
			MoveCharacterPoint moveCharacterPoint = this.MovePoint[i];
			if (moveCharacterPoint.Index >= 0)
			{
				float num3 = (float)global::Vector.Dist(actorLocationProxy, moveCharacterPoint.Position);
				if (num3 < num2)
				{
					num2 = num3;
					num = i;
				}
			}
		}
		if (num == 0 || (num == this.MovePoint.Count - 1 && num2 < 200f && global::Vector.Dist(this.MovePoint[0].Position, this.MovePoint[this.MovePoint.Count - 1].Position) < 200.0))
		{
			return 0;
		}
		for (int j = 0; j < this.MovePoint.Count - 1; j++)
		{
			global::Vector position = this.MovePoint[j].Position;
			global::Vector position2 = this.MovePoint[j + 1].Position;
			this.CacheVector.Set(position2.X, position2.Y, position2.Z);
			this.CacheVector.Subtraction(position, this.CacheVector);
			float num4 = (float)this.CacheVector.Size();
			this.CacheVector2.Set(actorLocationProxy.X, actorLocationProxy.Y, actorLocationProxy.Z);
			this.CacheVector2.Subtraction(position2, this.CacheVector2);
			if (this.CacheVector.DotProduct(this.CacheVector2) <= 0.0)
			{
				this.CacheVector2.Set(actorLocationProxy.X, actorLocationProxy.Y, actorLocationProxy.Z);
				this.CacheVector2.Subtraction(position, this.CacheVector2);
				if (this.CacheVector.DotProduct(this.CacheVector2) >= 0.0)
				{
					this.CacheVector.CrossProduct(this.CacheVector2, this.CacheVector);
					float num5 = (float)this.CacheVector.Size() / num4;
					if (num5 < num2)
					{
						num2 = num5;
						num = (this.InversePath ? j : (j + 1));
					}
				}
			}
		}
		return num;
	}

	// Token: 0x06019DF5 RID: 105973 RVA: 0x0078FA94 File Offset: 0x0078DC94
	public bool FindNearestPointOnPath(global::Vector outVector)
	{
		if (this.TargetIndex == -1)
		{
			return false;
		}
		if (this.PreviousIndex == -1)
		{
			outVector.DeepCopy(this.MovePoint[this.TargetIndex].Position);
			return true;
		}
		this.MovePoint[this.TargetIndex].Position.Subtraction(this.MovePoint[this.PreviousIndex].Position, this.CacheVector2);
		if (!this.CacheVector2.Normalize(9.99999993922529E-09))
		{
			outVector.DeepCopy(this.MovePoint[this.TargetIndex].Position);
			return true;
		}
		this.ActorComp.ActorLocationProxy.Subtraction(this.MovePoint[this.PreviousIndex].Position, this.CacheVector);
		this.CacheVector2.MultiplyEqual(this.CacheVector.DotProduct(this.CacheVector2));
		this.MovePoint[this.PreviousIndex].Position.Addition(this.CacheVector2, outVector);
		return true;
	}

	// Token: 0x0400CF05 RID: 52997
	[Nullable(2)]
	private CharacterActorComponent ActorComp;

	// Token: 0x0400CF06 RID: 52998
	private bool IsLoop;

	// Token: 0x0400CF07 RID: 52999
	private bool IsCircle;

	// Token: 0x0400CF08 RID: 53000
	private bool InversePath;

	// Token: 0x0400CF09 RID: 53001
	private int PreviousIndex = -1;

	// Token: 0x0400CF0A RID: 53002
	public int TargetIndex;

	// Token: 0x0400CF0B RID: 53003
	[Nullable(2)]
	public MoveCharacterPoint TargetPoint;

	// Token: 0x0400CF0C RID: 53004
	public IList<MoveCharacterPoint> MovePoint = Array.Empty<MoveCharacterPoint>();

	// Token: 0x0400CF0D RID: 53005
	private readonly global::Vector CacheVector = global::Vector.Create();

	// Token: 0x0400CF0E RID: 53006
	private readonly global::Vector CacheVector2 = global::Vector.Create();

	// Token: 0x0400CF0F RID: 53007
	private const float MAX_DISTANCE = 200f;
}
