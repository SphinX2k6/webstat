using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020031AE RID: 12718
[NullableContext(1)]
[Nullable(0)]
public class NpcVehicleInfo
{
	// Token: 0x0601A5F1 RID: 108017 RVA: 0x007C5D77 File Offset: 0x007C3F77
	public NpcVehicleInfo(int entityId, int seatCount)
	{
		this.VehicleEntityId = entityId;
		this.SeatCount = seatCount;
	}

	// Token: 0x0601A5F2 RID: 108018 RVA: 0x007C5D98 File Offset: 0x007C3F98
	public List<int> RemoveInvalidNpcInfos()
	{
		List<int> list = new List<int>();
		for (int i = this.NpcSeatInfoList.Count - 1; i >= 0; i--)
		{
			int npcEntityId = this.NpcSeatInfoList[i].NpcEntityId;
			Entity entity = Singleton<EntitySystem>.Instance.Get(npcEntityId);
			if (entity == null || !entity.Active)
			{
				this.NpcSeatInfoList.RemoveAt(i);
				list.Add(npcEntityId);
			}
		}
		return list;
	}

	// Token: 0x0601A5F3 RID: 108019 RVA: 0x007C5E02 File Offset: 0x007C4002
	public bool HasAvailableSeat()
	{
		return this.NpcSeatInfoList.Count < this.SeatCount;
	}

	// Token: 0x0601A5F4 RID: 108020 RVA: 0x007C5E18 File Offset: 0x007C4018
	public unsafe int? ReserveNpc(int npcEntityId)
	{
		NpcSeatInfo npcSeatInfo = this.GetNpcSeatInfo(npcEntityId);
		if (npcSeatInfo != null)
		{
			return new int?(npcSeatInfo.Seat);
		}
		int validSeat = this.GetValidSeat();
		if (validSeat == -1)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Vehicle;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "[NpcVehicleInfo] 获取载具座位失败, 载具没有可用座位";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("VehicleEntityId", this.VehicleEntityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		this.NpcSeatInfoList.Add(new NpcSeatInfo(npcEntityId, validSeat));
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Vehicle;
		ELogAuthor author2 = ELogAuthor.ZJL;
		string message2 = "[NpcVehicleInfo] 注册NPC到载具成功";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("NpcEntityId", npcEntityId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("VehicleEntityId", this.VehicleEntityId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Seat", validSeat);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		return new int?(validSeat);
	}

	// Token: 0x0601A5F5 RID: 108021 RVA: 0x007C5F20 File Offset: 0x007C4120
	public unsafe int? UnregisterNpc(int npcEntityId)
	{
		int num = this.NpcSeatInfoList.FindIndex((NpcSeatInfo npcInfo) => npcInfo.NpcEntityId == npcEntityId);
		if (num == -1)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Vehicle;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "[NpcVehicleInfo] 从载具注销NPC失败, NPC不在队列中";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("NpcEntityId", npcEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("VehicleEntityId", this.VehicleEntityId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		int seat = this.NpcSeatInfoList[num].Seat;
		this.NpcSeatInfoList.RemoveAt(num);
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Vehicle;
		ELogAuthor author2 = ELogAuthor.ZJL;
		string message2 = "[NpcVehicleInfo] 从载具注销NPC成功";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("NpcEntityId", npcEntityId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("VehicleEntityId", this.VehicleEntityId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Seat", seat);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		return new int?(seat);
	}

	// Token: 0x0601A5F6 RID: 108022 RVA: 0x007C6078 File Offset: 0x007C4278
	public unsafe bool SetNpcRideState(int npcEntityId, ENpcVehicleRideState state)
	{
		NpcSeatInfo npcSeatInfo = this.GetNpcSeatInfo(npcEntityId);
		if (npcSeatInfo == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Vehicle;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "[NpcVehicleInfo] 设置NPC载具状态失败, NPC不在队列中";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("NpcEntityId", npcEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("VehicleEntityId", this.VehicleEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("State", state);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		npcSeatInfo.RideState = state;
		return true;
	}

	// Token: 0x0601A5F7 RID: 108023 RVA: 0x007C611F File Offset: 0x007C431F
	public ENpcVehicleRideState GetNpcRideState(int npcEntityId)
	{
		NpcSeatInfo npcSeatInfo = this.GetNpcSeatInfo(npcEntityId);
		if (npcSeatInfo == null)
		{
			return ENpcVehicleRideState.None;
		}
		return npcSeatInfo.RideState;
	}

	// Token: 0x0601A5F8 RID: 108024 RVA: 0x007C6134 File Offset: 0x007C4334
	public unsafe bool SetNpcTargetSplinePbDataId(int npcEntityId, int splinePbDataId)
	{
		NpcSeatInfo npcSeatInfo = this.GetNpcSeatInfo(npcEntityId);
		if (npcSeatInfo == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Vehicle;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "[NpcVehicleInfo] 设置NPC目标样条PbDataId失败, NPC不在队列中";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("NpcEntityId", npcEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("VehicleEntityId", this.VehicleEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("SplinePbDataId", splinePbDataId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		npcSeatInfo.TargetSplinePbDataId = new int?(splinePbDataId);
		return true;
	}

	// Token: 0x0601A5F9 RID: 108025 RVA: 0x007C61E0 File Offset: 0x007C43E0
	public int? GetNpcTargetSplinePbDataId(int npcEntityId)
	{
		NpcSeatInfo npcSeatInfo = this.GetNpcSeatInfo(npcEntityId);
		if (npcSeatInfo == null)
		{
			return null;
		}
		return npcSeatInfo.TargetSplinePbDataId;
	}

	// Token: 0x0601A5FA RID: 108026 RVA: 0x007C6208 File Offset: 0x007C4408
	public int? GetSeatByNpc(int npcEntityId)
	{
		NpcSeatInfo npcSeatInfo = this.GetNpcSeatInfo(npcEntityId);
		if (npcSeatInfo == null)
		{
			return null;
		}
		return new int?(npcSeatInfo.Seat);
	}

	// Token: 0x0601A5FB RID: 108027 RVA: 0x007C6234 File Offset: 0x007C4434
	public int? GetNpcEntityIdBySplinePbDataId(int splinePbDataId)
	{
		if (splinePbDataId == 0)
		{
			return null;
		}
		NpcSeatInfo npcSeatInfo = this.NpcSeatInfoList.Find(delegate(NpcSeatInfo npcInfo)
		{
			int? targetSplinePbDataId = npcInfo.TargetSplinePbDataId;
			int splinePbDataId2 = splinePbDataId;
			return targetSplinePbDataId.GetValueOrDefault() == splinePbDataId2 & targetSplinePbDataId != null;
		});
		if (npcSeatInfo == null)
		{
			return null;
		}
		return new int?(npcSeatInfo.NpcEntityId);
	}

	// Token: 0x0601A5FC RID: 108028 RVA: 0x007C628F File Offset: 0x007C448F
	public bool IsMovingToTarget()
	{
		return this.NpcSeatInfoList.Exists((NpcSeatInfo npcInfo) => npcInfo.RideState == ENpcVehicleRideState.MoveToTargetPoint);
	}

	// Token: 0x0601A5FD RID: 108029 RVA: 0x007C62BC File Offset: 0x007C44BC
	public int? GetAvailableRouteNpcEntityId()
	{
		if (this.NpcSeatInfoList.Exists((NpcSeatInfo npcInfo) => npcInfo.RideState == ENpcVehicleRideState.WaitingToDismount))
		{
			return null;
		}
		NpcSeatInfo npcSeatInfo = this.NpcSeatInfoList.Find(delegate(NpcSeatInfo npcInfo)
		{
			if (npcInfo.RideState == ENpcVehicleRideState.OnVehicleWaiting && npcInfo.TargetSplinePbDataId != null)
			{
				int? targetSplinePbDataId = npcInfo.TargetSplinePbDataId;
				int num = 0;
				return targetSplinePbDataId.GetValueOrDefault() > num & targetSplinePbDataId != null;
			}
			return false;
		});
		if (npcSeatInfo == null)
		{
			return null;
		}
		return new int?(npcSeatInfo.NpcEntityId);
	}

	// Token: 0x0601A5FE RID: 108030 RVA: 0x007C6344 File Offset: 0x007C4544
	public void GetAllNpcEntityIds(List<int> outList)
	{
		outList.Clear();
		foreach (NpcSeatInfo npcSeatInfo in this.NpcSeatInfoList)
		{
			outList.Add(npcSeatInfo.NpcEntityId);
		}
	}

	// Token: 0x0601A5FF RID: 108031 RVA: 0x007C63A4 File Offset: 0x007C45A4
	[NullableContext(2)]
	private NpcSeatInfo GetNpcSeatInfo(int npcEntityId)
	{
		return this.NpcSeatInfoList.Find((NpcSeatInfo npcInfo) => npcInfo.NpcEntityId == npcEntityId);
	}

	// Token: 0x0601A600 RID: 108032 RVA: 0x007C63D8 File Offset: 0x007C45D8
	private int GetValidSeat()
	{
		if (!this.HasAvailableSeat())
		{
			return -1;
		}
		int seat;
		int seat2;
		for (seat = 0; seat < this.SeatCount; seat = seat2 + 1)
		{
			if (!this.NpcSeatInfoList.Exists((NpcSeatInfo npcInfo) => npcInfo.Seat == seat))
			{
				return seat;
			}
			seat2 = seat;
		}
		return -1;
	}

	// Token: 0x0400D4CE RID: 54478
	public int VehicleEntityId;

	// Token: 0x0400D4CF RID: 54479
	public int SeatCount;

	// Token: 0x0400D4D0 RID: 54480
	public readonly List<NpcSeatInfo> NpcSeatInfoList = new List<NpcSeatInfo>();
}
