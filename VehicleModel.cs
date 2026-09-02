using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02003292 RID: 12946
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class VehicleModel : ModelBase<VehicleModel>
{
	// Token: 0x0601B1C6 RID: 111046 RVA: 0x00821870 File Offset: 0x0081FA70
	protected override bool OnChangeMode()
	{
		foreach (ScenePlayerVehicleInfo scenePlayerVehicleInfo in this.PlayerVehicleInfo.Values)
		{
			ScenePlayerVehicleInfo scenePlayerVehicleInfo2 = scenePlayerVehicleInfo.DeepCopy();
			scenePlayerVehicleInfo2.VehicleCreatureId = 0L;
			scenePlayerVehicleInfo2.ExitType = ELeaveVehicleType.StandUp;
			this.UpdatePlayerVehicleData(scenePlayerVehicleInfo2);
			this.PassengerVehicleMap.Remove(scenePlayerVehicleInfo2.EntityCreatureId);
		}
		this.PlayerVehicleInfo.Clear();
		this.VehiclePlayerInfo.Clear();
		this.RideSharingInfoMap.Clear();
		this.IsReadyRiderSharing = false;
		this.IsForbidRiderSharing = false;
		return true;
	}

	// Token: 0x0601B1C7 RID: 111047 RVA: 0x00821920 File Offset: 0x0081FB20
	protected override bool OnClear()
	{
		this.MaterialControllerHandles.Clear();
		return true;
	}

	// Token: 0x0601B1C8 RID: 111048 RVA: 0x00821930 File Offset: 0x0081FB30
	public unsafe void UpdateAllPlayerVehicleData(IReadOnlyList<ScenePlayerInformation> playerInfoList)
	{
		this.PlayerVehicleInfo.Clear();
		this.VehiclePlayerInfo.Clear();
		this.PostUpdateAllVehicleEntityData();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Vehicle;
		ELogAuthor author = ELogAuthor.YJX;
		string message = "[VehicleModel.UpdateAllPlayerVehicleData] 开始刷新全量载具数据";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PlayerNum", playerInfoList.Count);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		foreach (ScenePlayerInformation scenePlayerInformation in playerInfoList)
		{
			ScenePlayerVehicleInfo scenePlayerVehicleInfo = new ScenePlayerVehicleInfo();
			scenePlayerVehicleInfo.PlayerId = scenePlayerInformation.PlayerId;
			this.PlayerVehicleInfo[scenePlayerInformation.PlayerId] = scenePlayerVehicleInfo;
			if (scenePlayerInformation.VehicleInfoPb != null)
			{
				SceneTeamPlayer teamPlayerData = ModelBase<SceneTeamModel>.Instance.GetTeamPlayerData(scenePlayerVehicleInfo.PlayerId);
				long? num;
				if (teamPlayerData == null)
				{
					num = null;
				}
				else
				{
					SceneTeamGroup currentGroup = teamPlayerData.GetCurrentGroup();
					if (currentGroup == null)
					{
						num = null;
					}
					else
					{
						SceneTeamRole currentRole = currentGroup.GetCurrentRole();
						num = ((currentRole != null) ? new long?(currentRole.CreatureDataId) : null);
					}
				}
				long? num2 = num;
				if (num2 == null)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Vehicle;
					ELogAuthor author2 = ELogAuthor.YJX;
					string message2 = "[VehicleModel.UpdateAllPlayerVehicleData] 刷新载具全量数据时无法获取对应PlayerId的CreatureId";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PlayerId", scenePlayerInformation.PlayerId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("VehicleId", Singleton<MathUtils>.Instance.LongToNumber(scenePlayerInformation.VehicleInfoPb.EntityId));
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Seat", scenePlayerInformation.VehicleInfoPb.SeatId);
					instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				}
				else
				{
					scenePlayerVehicleInfo.EntityCreatureId = num2.Value;
					scenePlayerVehicleInfo.VehicleCreatureId = Singleton<MathUtils>.Instance.LongToNumber(scenePlayerInformation.VehicleInfoPb.EntityId);
					scenePlayerVehicleInfo.Seat = scenePlayerInformation.VehicleInfoPb.SeatId;
					this.UpdatePlayerVehicleData(scenePlayerVehicleInfo);
				}
			}
		}
	}

	// Token: 0x0601B1C9 RID: 111049 RVA: 0x00821B50 File Offset: 0x0081FD50
	public void AddOtherPlayerVehicleData(int playerId)
	{
		ScenePlayerVehicleInfo scenePlayerVehicleInfo = new ScenePlayerVehicleInfo();
		scenePlayerVehicleInfo.PlayerId = playerId;
		this.PlayerVehicleInfo[playerId] = scenePlayerVehicleInfo;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Vehicle;
		ELogAuthor author = ELogAuthor.YJX;
		string message = "[VehicleModel.AddOtherPlayerVehicleData] 添加玩家载具信息";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PlayerId", playerId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0601B1CA RID: 111050 RVA: 0x00821BA8 File Offset: 0x0081FDA8
	public unsafe void RemoveOtherPlayerVehicleData(int playerId)
	{
		ScenePlayerVehicleInfo scenePlayerVehicleInfo = null;
		this.PlayerVehicleInfo.TryGetValue(playerId, out scenePlayerVehicleInfo);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Vehicle;
		ELogAuthor author = ELogAuthor.YJX;
		string message = "[VehicleModel.RemoveOtherPlayerVehicleData] 移除玩家载具信息";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PlayerId", (scenePlayerVehicleInfo != null) ? new int?(scenePlayerVehicleInfo.PlayerId) : null);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PlayerCreatureId", (scenePlayerVehicleInfo != null) ? new long?(scenePlayerVehicleInfo.EntityCreatureId) : null);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("VehicleCreatureId", (scenePlayerVehicleInfo != null) ? new long?(scenePlayerVehicleInfo.VehicleCreatureId) : null);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Seat", (scenePlayerVehicleInfo != null) ? new int?(scenePlayerVehicleInfo.Seat) : null);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		if (scenePlayerVehicleInfo != null && scenePlayerVehicleInfo.VehicleCreatureId != 0L)
		{
			ScenePlayerVehicleInfo scenePlayerVehicleInfo2 = new ScenePlayerVehicleInfo();
			scenePlayerVehicleInfo2.PlayerId = scenePlayerVehicleInfo.PlayerId;
			scenePlayerVehicleInfo2.EntityCreatureId = scenePlayerVehicleInfo.EntityCreatureId;
			scenePlayerVehicleInfo2.VehicleCreatureId = 0L;
			scenePlayerVehicleInfo2.Seat = scenePlayerVehicleInfo.Seat;
			this.UpdatePlayerVehicleData(scenePlayerVehicleInfo);
		}
		this.PlayerVehicleInfo.Remove(playerId);
	}

	// Token: 0x0601B1CB RID: 111051 RVA: 0x00821D10 File Offset: 0x0081FF10
	public unsafe void UpdatePlayerVehicleData(ScenePlayerVehicleInfo context)
	{
		ScenePlayerVehicleInfo scenePlayerVehicleInfo = this.PlayerVehicleInfo.GetValueOrDefault(context.PlayerId);
		if (scenePlayerVehicleInfo == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Vehicle;
			ELogAuthor author = ELogAuthor.YJX;
			string message = "[VehicleModel] 没有数据默认不在船上";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PlayerId", context.PlayerId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Seat", context.Seat);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			scenePlayerVehicleInfo = new ScenePlayerVehicleInfo();
			scenePlayerVehicleInfo.PlayerId = context.PlayerId;
			scenePlayerVehicleInfo.EntityCreatureId = context.EntityCreatureId;
			scenePlayerVehicleInfo.VehicleCreatureId = 0L;
			scenePlayerVehicleInfo.Seat = context.Seat;
			this.PlayerVehicleInfo[context.PlayerId] = scenePlayerVehicleInfo;
		}
		bool flag = context.VehicleCreatureId != 0L;
		if (!flag)
		{
			context.VehicleCreatureId = scenePlayerVehicleInfo.VehicleCreatureId;
			context.Seat = -1;
		}
		if (!flag && scenePlayerVehicleInfo.VehicleCreatureId == 0L)
		{
			return;
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Vehicle;
		ELogAuthor author2 = ELogAuthor.YJX;
		string message2 = "[VehicleModel.UpdateVehicleData] 更新载具数据";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("PlayerId", context.PlayerId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("PlayerCreatureId", context.EntityCreatureId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("VehicleCreatureId", context.VehicleCreatureId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("Seat", context.Seat);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
		this.UpdateVehiclePlayerInfo(context);
		this.UpdatePlayerVehicleInfo(context);
		this.UpdateEntityVehicleData(context);
	}

	// Token: 0x0601B1CC RID: 111052 RVA: 0x00821ED4 File Offset: 0x008200D4
	private unsafe void UpdateVehiclePlayerInfo(ScenePlayerVehicleInfo context)
	{
		bool flag = context.Seat != -1;
		HashSet<int> hashSet = this.VehiclePlayerInfo.GetValueOrDefault(context.VehicleCreatureId);
		if (flag)
		{
			if (hashSet == null)
			{
				hashSet = new HashSet<int>();
				this.VehiclePlayerInfo[context.VehicleCreatureId] = hashSet;
			}
			hashSet.Add(context.PlayerId);
			return;
		}
		if (hashSet == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Vehicle;
			ELogAuthor author = ELogAuthor.YJX;
			string message = "[VehicleModel.UpdateVehiclePlayerInfo] 更新载具数据失败，重复退出载具";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PlayerId", context.PlayerId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PlayerCreatureId", context.EntityCreatureId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("VehicleCreatureId", context.VehicleCreatureId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		hashSet.Remove(context.PlayerId);
		if (hashSet.Count == 0)
		{
			this.VehiclePlayerInfo.Remove(context.VehicleCreatureId);
		}
	}

	// Token: 0x0601B1CD RID: 111053 RVA: 0x00821FE4 File Offset: 0x008201E4
	private void UpdatePlayerVehicleInfo(ScenePlayerVehicleInfo context)
	{
		bool flag = context.Seat != -1;
		ScenePlayerVehicleInfo scenePlayerVehicleInfo = this.PlayerVehicleInfo[context.PlayerId];
		if (flag && scenePlayerVehicleInfo.VehicleCreatureId != 0L && (scenePlayerVehicleInfo.EntityCreatureId != context.EntityCreatureId || scenePlayerVehicleInfo.VehicleCreatureId != context.VehicleCreatureId))
		{
			ScenePlayerVehicleInfo scenePlayerVehicleInfo2 = scenePlayerVehicleInfo.DeepCopy();
			scenePlayerVehicleInfo2.Seat = -1;
			scenePlayerVehicleInfo2.ExitType = ELeaveVehicleType.StandUp;
			this.UpdateVehiclePlayerInfo(scenePlayerVehicleInfo2);
		}
		scenePlayerVehicleInfo.EntityCreatureId = context.EntityCreatureId;
		scenePlayerVehicleInfo.VehicleCreatureId = (flag ? context.VehicleCreatureId : 0L);
		scenePlayerVehicleInfo.Seat = context.Seat;
		scenePlayerVehicleInfo.ExitType = context.ExitType;
	}

	// Token: 0x0601B1CE RID: 111054 RVA: 0x0082208C File Offset: 0x0082028C
	public void UpdateEntityVehicleData(EntityVehicleInfo context)
	{
		long entityCreatureId = context.EntityCreatureId;
		EntityVehicleInfo valueOrDefault = this.PassengerVehicleMap.GetValueOrDefault(entityCreatureId);
		if (context.Seat == -1)
		{
			bool flag;
			if (valueOrDefault == null)
			{
				flag = true;
			}
			else
			{
				long vehicleCreatureId = valueOrDefault.VehicleCreatureId;
				flag = false;
			}
			if (flag || valueOrDefault.VehicleCreatureId == 0L)
			{
				return;
			}
			context.VehicleCreatureId = valueOrDefault.VehicleCreatureId;
		}
		this.UpdateVehicleEntityInfo(context);
		this.UpdateEntityVehicleInfo(context);
	}

	// Token: 0x0601B1CF RID: 111055 RVA: 0x008220F0 File Offset: 0x008202F0
	public void UpdateEntityVehicleInfo(EntityVehicleInfo context)
	{
		bool flag = context.Seat != -1;
		EntityVehicleInfo entityVehicleInfo = this.PassengerVehicleMap.GetValueOrDefault(context.EntityCreatureId);
		if (entityVehicleInfo == null)
		{
			entityVehicleInfo = new EntityVehicleInfo();
			this.PassengerVehicleMap[context.EntityCreatureId] = entityVehicleInfo;
		}
		else if (flag && entityVehicleInfo.VehicleCreatureId != 0L && entityVehicleInfo.VehicleCreatureId != context.VehicleCreatureId)
		{
			EntityVehicleInfo entityVehicleInfo2 = entityVehicleInfo.DeepCopy();
			entityVehicleInfo2.Seat = -1;
			entityVehicleInfo2.ExitType = ELeaveVehicleType.StandUp;
			this.UpdateVehicleEntityInfo(entityVehicleInfo2);
		}
		entityVehicleInfo.EntityCreatureId = context.EntityCreatureId;
		entityVehicleInfo.VehicleCreatureId = (flag ? context.VehicleCreatureId : 0L);
		entityVehicleInfo.Seat = context.Seat;
		entityVehicleInfo.ExitType = context.ExitType;
		this.PassengerVehicleMap[context.EntityCreatureId] = context;
	}

	// Token: 0x0601B1D0 RID: 111056 RVA: 0x008221B8 File Offset: 0x008203B8
	public unsafe void UpdateVehicleEntityInfo(EntityVehicleInfo context)
	{
		bool flag = context.Seat != -1;
		Dictionary<long, EntityVehicleInfo> dictionary = this.VehiclePassengerMap.GetValueOrDefault(context.VehicleCreatureId);
		if (flag)
		{
			if (dictionary == null)
			{
				dictionary = new Dictionary<long, EntityVehicleInfo>();
				this.VehiclePassengerMap[context.VehicleCreatureId] = dictionary;
			}
			dictionary[context.EntityCreatureId] = context;
			return;
		}
		if (dictionary == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Vehicle;
			ELogAuthor author = ELogAuthor.YJX;
			string message = "[VehicleModel.UpdateVehicleEntityInfo] 更新载具数据失败，重复退出载具";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityCreatureId", context.EntityCreatureId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("VehicleCreatureId", context.VehicleCreatureId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		dictionary.Remove(context.EntityCreatureId);
		if (dictionary.Count == 0)
		{
			this.VehiclePlayerInfo.Remove(context.VehicleCreatureId);
		}
	}

	// Token: 0x0601B1D1 RID: 111057 RVA: 0x008222A4 File Offset: 0x008204A4
	public void PostUpdateAllVehicleEntityData()
	{
		foreach (EntityVehicleInfo context in this.PassengerVehicleMap.Values)
		{
			this.PostUpdateVehicleEntityData(context);
		}
	}

	// Token: 0x0601B1D2 RID: 111058 RVA: 0x008222FC File Offset: 0x008204FC
	public void PostUpdateVehicleEntityData(EntityVehicleInfo context)
	{
		if (context.Seat != -1)
		{
			return;
		}
		Dictionary<long, EntityVehicleInfo> valueOrDefault = this.VehiclePassengerMap.GetValueOrDefault(context.EntityCreatureId);
		if (valueOrDefault != null)
		{
			valueOrDefault.Remove(context.EntityCreatureId);
		}
		if (valueOrDefault == null || valueOrDefault.Count == 0)
		{
			this.VehiclePassengerMap.Remove(context.VehicleCreatureId);
		}
		this.PassengerVehicleMap.Remove(context.EntityCreatureId);
	}

	// Token: 0x0601B1D3 RID: 111059 RVA: 0x0082236C File Offset: 0x0082056C
	public List<ScenePlayerVehicleInfo> GetVehiclePlayerData(long vehicleCreatureId)
	{
		List<ScenePlayerVehicleInfo> list = new List<ScenePlayerVehicleInfo>();
		HashSet<int> valueOrDefault = this.VehiclePlayerInfo.GetValueOrDefault(vehicleCreatureId);
		if (valueOrDefault == null)
		{
			return list;
		}
		foreach (int key in valueOrDefault)
		{
			list.Add(this.PlayerVehicleInfo[key]);
		}
		return list;
	}

	// Token: 0x0601B1D4 RID: 111060 RVA: 0x008223E0 File Offset: 0x008205E0
	[NullableContext(2)]
	public ScenePlayerVehicleInfo GetPlayerVehicleData(int playerId)
	{
		return this.PlayerVehicleInfo.GetValueOrDefault(playerId);
	}

	// Token: 0x0601B1D5 RID: 111061 RVA: 0x008223F0 File Offset: 0x008205F0
	public List<EntityVehicleInfo> GetVehicleEntityData(long creatureId)
	{
		List<EntityVehicleInfo> list = new List<EntityVehicleInfo>();
		Dictionary<long, EntityVehicleInfo> valueOrDefault = this.VehiclePassengerMap.GetValueOrDefault(creatureId);
		if (valueOrDefault == null)
		{
			return list;
		}
		foreach (KeyValuePair<long, EntityVehicleInfo> keyValuePair in valueOrDefault)
		{
			list.Add(keyValuePair.Value);
		}
		return list;
	}

	// Token: 0x0601B1D6 RID: 111062 RVA: 0x00822460 File Offset: 0x00820660
	[NullableContext(2)]
	public EntityVehicleInfo GetEntityVehicleData(long creatureId)
	{
		return this.PassengerVehicleMap.GetValueOrDefault(creatureId);
	}

	// Token: 0x0601B1D7 RID: 111063 RVA: 0x00822470 File Offset: 0x00820670
	public void UpdateKeepDrivingInfo(float delta, VehicleMoveComponent moveComp)
	{
		if (this.KeepDrivingInfoList == null)
		{
			return;
		}
		foreach (KeyValuePair<int, KeepDrivingInfo> keyValuePair in this.KeepDrivingInfoList)
		{
			if ((keyValuePair.Value.CheckCondition == null || keyValuePair.Value.CheckCondition()) && keyValuePair.Value.UpdateDrivingInfo(delta, moveComp) && keyValuePair.Value.RunAction != null)
			{
				keyValuePair.Value.RunAction();
			}
		}
	}

	// Token: 0x0601B1D8 RID: 111064 RVA: 0x00822518 File Offset: 0x00820718
	public int AddKeepDrivingInfo(KeepDrivingInfo info)
	{
		if (this.KeepDrivingInfoList == null)
		{
			this.KeepDrivingInfoList = new Dictionary<int, KeepDrivingInfo>();
		}
		this.Uid++;
		this.KeepDrivingInfoList[this.Uid] = info;
		return this.Uid;
	}

	// Token: 0x0601B1D9 RID: 111065 RVA: 0x00822553 File Offset: 0x00820753
	public void RemoveKeepDrivingInfo(int index)
	{
		Dictionary<int, KeepDrivingInfo> keepDrivingInfoList = this.KeepDrivingInfoList;
		if (keepDrivingInfoList != null && keepDrivingInfoList.ContainsKey(index))
		{
			this.KeepDrivingInfoList.Remove(index);
		}
	}

	// Token: 0x0400DCA2 RID: 56482
	public Dictionary<int, ScenePlayerVehicleInfo> PlayerVehicleInfo = new Dictionary<int, ScenePlayerVehicleInfo>();

	// Token: 0x0400DCA3 RID: 56483
	public Dictionary<long, HashSet<int>> VehiclePlayerInfo = new Dictionary<long, HashSet<int>>();

	// Token: 0x0400DCA4 RID: 56484
	public Dictionary<long, EntityVehicleInfo> PassengerVehicleMap = new Dictionary<long, EntityVehicleInfo>();

	// Token: 0x0400DCA5 RID: 56485
	public Dictionary<long, Dictionary<long, EntityVehicleInfo>> VehiclePassengerMap = new Dictionary<long, Dictionary<long, EntityVehicleInfo>>();

	// Token: 0x0400DCA6 RID: 56486
	public bool IsReadyRiderSharing;

	// Token: 0x0400DCA7 RID: 56487
	public bool IsForbidRiderSharing;

	// Token: 0x0400DCA8 RID: 56488
	public Dictionary<int, VehicleRideSharingInfo> RideSharingInfoMap = new Dictionary<int, VehicleRideSharingInfo>();

	// Token: 0x0400DCA9 RID: 56489
	public HashSet<int> MaterialControllerHandles = new HashSet<int>();

	// Token: 0x0400DCAA RID: 56490
	private int Uid;

	// Token: 0x0400DCAB RID: 56491
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, KeepDrivingInfo> KeepDrivingInfoList;
}
