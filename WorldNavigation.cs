using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.Map;
using UnrealEngine;

// Token: 0x02001A7C RID: 6780
[NullableContext(1)]
[Nullable(0)]
public static class WorldNavigation
{
	// Token: 0x0600C210 RID: 49680 RVA: 0x00331E3B File Offset: 0x0033003B
	public static void SetEnableDebug(bool enable)
	{
		WorldNavigation.EnableDebug = enable;
	}

	// Token: 0x0600C211 RID: 49681 RVA: 0x00331E44 File Offset: 0x00330044
	public static void FindPath(IWorldNavigationConfig config)
	{
		NavigationFindPathRequest navigationFindPathRequest = NavigationFindPathRequest.Create();
		navigationFindPathRequest.StartPos = new Aki.Protocol.Vector
		{
			X = (float)config.SourcePosition.X,
			Y = (float)config.SourcePosition.Y,
			Z = (float)config.SourcePosition.Z
		};
		navigationFindPathRequest.EndPos = new Aki.Protocol.Vector
		{
			X = (float)config.DestPosition.X,
			Y = (float)config.DestPosition.Y,
			Z = (float)config.DestPosition.Z
		};
		navigationFindPathRequest.MapId = config.MapId;
		Singleton<Net>.Instance.Call<NavigationFindPathResponse>(ERequestMessageId.NavigationFindPathRequest, navigationFindPathRequest, delegate(NavigationFindPathResponse response, Net.CallbackStatus _)
		{
			bool flag = response != null && response.ErrorCode == ErrorCode.Success;
			if (flag)
			{
				WorldNavigation.DoFindPath(response, config);
			}
			if (config.Callback != null)
			{
				config.Callback(flag);
			}
		}, 0);
	}

	// Token: 0x0600C212 RID: 49682 RVA: 0x00331F34 File Offset: 0x00330134
	private static void DoFindPath([Nullable(2)] NavigationFindPathResponse data, IWorldNavigationConfig config)
	{
		List<MoveCharacterPoint> list = new List<MoveCharacterPoint>();
		List<global::Vector> list2 = new List<global::Vector>();
		if (data != null)
		{
			for (int i = 0; i < data.PosList.Count; i++)
			{
				Aki.Protocol.Vector vector = data.PosList[i];
				global::Vector vector2 = new global::Vector((double)vector.X, (double)vector.Y, (double)vector.Z);
				MoveCharacterPoint item = new MoveCharacterPoint
				{
					Index = i,
					Position = vector2
				};
				list.Add(item);
				list2.Add(vector2);
			}
			WorldNavigation.DrawNavigationPoint(list2);
			WorldNavigation.GoNextPoint(config, list, 0, 3);
		}
	}

	// Token: 0x0600C213 RID: 49683 RVA: 0x00331FC4 File Offset: 0x003301C4
	private static void GoNextPoint(IWorldNavigationConfig config, List<MoveCharacterPoint> movePointList, int startIndex, int endIndex)
	{
		List<MoveCharacterPoint> range;
		if (endIndex >= movePointList.Count - 1)
		{
			range = movePointList.GetRange(startIndex, movePointList.Count - startIndex);
		}
		else
		{
			range = movePointList.GetRange(startIndex, endIndex - startIndex);
		}
		MoveCharacterConfig config2 = new MoveCharacterConfig
		{
			Points = range,
			Navigation = true,
			ReturnFalseWhenNavigationFailed = true,
			IsFly = false,
			DebugMode = true,
			Loop = false,
			Callback = delegate(ELevelEventState state)
			{
				if (endIndex >= movePointList.Count)
				{
					WorldNavigation.CheckIsCloseEnoughToDest(config);
					return;
				}
				WorldNavigation.GoNextPoint(config, movePointList, endIndex, endIndex + 3);
			}
		};
		BaseMoveComponent moveComponent = config.MoveComponent;
		if (moveComponent == null)
		{
			return;
		}
		moveComponent.MoveAlongPath(config2, null);
	}

	// Token: 0x0600C214 RID: 49684 RVA: 0x00332094 File Offset: 0x00330294
	private static void CheckIsCloseEnoughToDest(IWorldNavigationConfig config)
	{
		if (config.DistanceThreshold != null && config.TryFindPathTimes != null)
		{
			int? num = config.TryFindPathTimes;
			int num2 = 0;
			if (!(num.GetValueOrDefault() <= num2 & num != null))
			{
				config.TryFindPathTimes--;
				BaseMoveComponent moveComponent = config.MoveComponent;
				FVectorDouble? fvectorDouble;
				if (moveComponent == null)
				{
					fvectorDouble = null;
				}
				else
				{
					CharacterActorComponent actorComp = moveComponent.ActorComp;
					fvectorDouble = ((actorComp != null) ? new FVectorDouble?(actorComp.ActorLocation) : null);
				}
				FVectorDouble? fvectorDouble2 = fvectorDouble;
				if (fvectorDouble2 != null)
				{
					FVectorDouble value = fvectorDouble2.Value;
					FVectorDouble fvectorDouble3 = config.DestPosition.ToUeVector(false);
					double num3 = FVectorDouble.Dist(value, fvectorDouble3);
					num = config.DistanceThreshold;
					double? num4 = (num != null) ? new double?((double)num.GetValueOrDefault()) : null;
					if (num3 > num4.GetValueOrDefault() & num4 != null)
					{
						config.SourcePosition = new global::Vector(fvectorDouble2.Value.X, fvectorDouble2.Value.Y, fvectorDouble2.Value.Z);
						WorldNavigation.FindPath(config);
					}
				}
				return;
			}
		}
	}

	// Token: 0x0600C215 RID: 49685 RVA: 0x003321EC File Offset: 0x003303EC
	public static void TestFindPath(global::Vector worldPosition, TWorldNavigationCallback callback)
	{
		if (!WorldNavigation.EnableDebug)
		{
			return;
		}
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		BaseMoveComponent baseMoveComponent;
		if (getCurrentEntity == null)
		{
			baseMoveComponent = null;
		}
		else
		{
			WorldEntity entity = getCurrentEntity.Entity;
			baseMoveComponent = ((entity != null) ? entity.GetComponent<BaseMoveComponent>() : null);
		}
		BaseMoveComponent moveComponent = baseMoveComponent;
		EntityHandle getCurrentEntity2 = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		object obj;
		if (getCurrentEntity2 == null)
		{
			obj = null;
		}
		else
		{
			WorldEntity entity2 = getCurrentEntity2.Entity;
			obj = ((entity2 != null) ? entity2.GetComponent<CharacterActorComponent>() : null);
		}
		object obj2 = obj;
		FVectorDouble? fvectorDouble = (obj2 != null) ? new FVectorDouble?(obj2.ActorLocation) : null;
		if (fvectorDouble == null)
		{
			return;
		}
		WorldNavigation.FindPath(new WorldNavigationConfig
		{
			SourcePosition = new global::Vector(fvectorDouble.Value.X, fvectorDouble.Value.Y, fvectorDouble.Value.Z),
			DestPosition = worldPosition,
			MapId = ModelBase<MapModel>.Instance.CurrentWorldMapConfigId,
			MoveComponent = moveComponent,
			DistanceThreshold = new int?(2000),
			TryFindPathTimes = new int?(5),
			Callback = callback
		});
	}

	// Token: 0x0600C216 RID: 49686 RVA: 0x003322E4 File Offset: 0x003304E4
	private static void DrawNavigationPoint(List<global::Vector> posList)
	{
		int num = 30;
		int num2 = 180;
		FLinearColor value = new FLinearColor(1f, 0f, 0f, 0f);
		foreach (global::Vector vector in posList)
		{
			UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.World, vector.ToUeVector(false), (float)num, 30, new FLinearColor?(value), (float)num2, 0f);
		}
	}

	// Token: 0x04005AED RID: 23277
	private const int DEBUG_SPHERE_DEFAULT_RADIUS = 30;

	// Token: 0x04005AEE RID: 23278
	private const int DEBUG_SPHERE_DEFAULT_SEGMENTS = 30;

	// Token: 0x04005AEF RID: 23279
	private const int DEBUG_SPHERE_DEFAULT_DURATION = 180;

	// Token: 0x04005AF0 RID: 23280
	[StaticVariableRuleIgnore]
	public static bool EnableDebug;
}
