using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020031AF RID: 12719
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class NpcVehicleRiderModel : ModelBase<NpcVehicleRiderModel>
{
	// Token: 0x0601A601 RID: 108033 RVA: 0x007C643D File Offset: 0x007C463D
	protected override bool OnClear()
	{
		this.FreeVehicleSet.Clear();
		this.VehicleToNpcInfoMap.Clear();
		this.TmpNpcEntityIdList.Clear();
		return true;
	}

	// Token: 0x0601A602 RID: 108034 RVA: 0x007C6461 File Offset: 0x007C4661
	public void AddFreeVehicle(int vehicleEntityId, int seatCount)
	{
		this.RegisterVehicle(vehicleEntityId, seatCount);
	}

	// Token: 0x0601A603 RID: 108035 RVA: 0x007C646B File Offset: 0x007C466B
	public void RegisterVehicle(int vehicleEntityId, int seatCount)
	{
		if (vehicleEntityId == 0)
		{
			return;
		}
		this.CreateVehicleInfo(vehicleEntityId, seatCount).SeatCount = seatCount;
		this.RefreshVehicleFreeState(vehicleEntityId);
	}

	// Token: 0x0601A604 RID: 108036 RVA: 0x007C6486 File Offset: 0x007C4686
	public void RemoveFreeVehicle(int vehicleEntityId)
	{
		this.RemoveVehicle(vehicleEntityId);
	}

	// Token: 0x0601A605 RID: 108037 RVA: 0x007C6490 File Offset: 0x007C4690
	private NpcVehicleInfo CreateVehicleInfo(int vehicleEntityId, int seatCount)
	{
		NpcVehicleInfo npcVehicleInfo = this.VehicleToNpcInfoMap.GetValueOrDefault(vehicleEntityId);
		if (npcVehicleInfo == null)
		{
			npcVehicleInfo = new NpcVehicleInfo(vehicleEntityId, seatCount);
			this.VehicleToNpcInfoMap[vehicleEntityId] = npcVehicleInfo;
		}
		else
		{
			npcVehicleInfo.SeatCount = seatCount;
		}
		return npcVehicleInfo;
	}

	// Token: 0x0601A606 RID: 108038 RVA: 0x007C64CC File Offset: 0x007C46CC
	private void AddFreeVehicleInternal(int vehicleEntityId)
	{
		if (this.FreeVehicleSet.Contains(vehicleEntityId))
		{
			return;
		}
		this.FreeVehicleSet.Add(vehicleEntityId);
	}

	// Token: 0x0601A607 RID: 108039 RVA: 0x007C64EC File Offset: 0x007C46EC
	public unsafe int? TryReserveVehicleSeat(int npcEntityId, int vehicleEntityId)
	{
		if (npcEntityId == 0 || vehicleEntityId == 0)
		{
			return null;
		}
		int? ridingVehicle = this.GetRidingVehicle(npcEntityId);
		if (ridingVehicle != null)
		{
			int? num = ridingVehicle;
			if (!(num.GetValueOrDefault() == vehicleEntityId & num != null))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Vehicle;
				ELogAuthor author = ELogAuthor.ZJL;
				string message = "[NpcVehicleRiderModel] NPC在已经预占或乘坐一个载具的情况下, 尝试预占另一个载具";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("NpcEntityId", npcEntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("OldVehicleEntityId", ridingVehicle);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("NewVehicleEntityId", vehicleEntityId);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return null;
			}
		}
		NpcVehicleInfo valueOrDefault = this.VehicleToNpcInfoMap.GetValueOrDefault(vehicleEntityId);
		if (valueOrDefault == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Vehicle;
			ELogAuthor author2 = ELogAuthor.ZJL;
			string message2 = "[NpcVehicleRiderModel] 预占载具失败, 载具未注册";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("NpcEntityId", npcEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("VehicleEntityId", vehicleEntityId);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return null;
		}
		int? num2 = valueOrDefault.ReserveNpc(npcEntityId);
		if (num2 == null)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Vehicle;
			ELogAuthor author3 = ELogAuthor.ZJL;
			string message3 = "[NpcVehicleRiderModel] 预占载具失败, 载具没有可用座位但仍Free状态, 可能数据异常";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("NpcEntityId", npcEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("VehicleEntityId", vehicleEntityId);
			instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
			this.RefreshVehicleFreeState(vehicleEntityId);
			return null;
		}
		this.RefreshVehicleFreeState(vehicleEntityId);
		Log instance4 = Singleton<Log>.Instance;
		ELogModule module4 = ELogModule.Vehicle;
		ELogAuthor author4 = ELogAuthor.ZJL;
		string message4 = "[NpcVehicleRiderModel] 预占NPC与载具座位成功";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("NpcEntityId", npcEntityId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("VehicleEntityId", vehicleEntityId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 2) = new ValueTuple<string, object>("Seat", num2);
		instance4.Info(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 3));
		return num2;
	}

	// Token: 0x0601A608 RID: 108040 RVA: 0x007C6748 File Offset: 0x007C4948
	public bool ReserveVehicle(int npcEntityId, int vehicleEntityId)
	{
		return this.TryReserveVehicleSeat(npcEntityId, vehicleEntityId) != null;
	}

	// Token: 0x0601A609 RID: 108041 RVA: 0x007C6768 File Offset: 0x007C4968
	public unsafe int? ReleaseVehicle(int npcEntityId, int vehicleEntityId = 0)
	{
		NpcVehicleInfo npcVehicleInfo = (vehicleEntityId != 0) ? this.VehicleToNpcInfoMap.GetValueOrDefault(vehicleEntityId) : this.FindVehicleInfoByNpc(npcEntityId);
		if (npcVehicleInfo == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Vehicle;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "[NpcVehicleRiderModel] 释放载具失败, NPC没有预占或乘坐任何载具";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("NpcEntityId", npcEntityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		int? num = npcVehicleInfo.UnregisterNpc(npcEntityId);
		if (num == null)
		{
			return null;
		}
		this.RefreshVehicleFreeState(npcVehicleInfo.VehicleEntityId);
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Vehicle;
		ELogAuthor author2 = ELogAuthor.ZJL;
		string message2 = "[NpcVehicleRiderModel] 解绑NPC与载具成功";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("NpcEntityId", npcEntityId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("VehicleEntityId", npcVehicleInfo.VehicleEntityId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Seat", num);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		return num;
	}

	// Token: 0x0601A60A RID: 108042 RVA: 0x007C6878 File Offset: 0x007C4A78
	public unsafe List<int> RemoveVehicle(int vehicleEntityId)
	{
		List<int> list = new List<int>();
		NpcVehicleInfo valueOrDefault = this.VehicleToNpcInfoMap.GetValueOrDefault(vehicleEntityId);
		if (valueOrDefault != null)
		{
			valueOrDefault.GetAllNpcEntityIds(this.TmpNpcEntityIdList);
			foreach (int num in this.TmpNpcEntityIdList)
			{
				list.Add(num);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Vehicle;
				ELogAuthor author = ELogAuthor.ZJL;
				string message = "[NpcVehicleRiderModel] 移除载具，自动解绑NPC";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("NpcEntityId", num);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("VehicleEntityId", vehicleEntityId);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}
		this.VehicleToNpcInfoMap.Remove(vehicleEntityId);
		this.RemoveFreeVehicleInternal(vehicleEntityId);
		return list;
	}

	// Token: 0x0601A60B RID: 108043 RVA: 0x007C6968 File Offset: 0x007C4B68
	public int? GetRidingVehicle(int npcEntityId)
	{
		NpcVehicleInfo npcVehicleInfo = this.FindVehicleInfoByNpc(npcEntityId);
		if (npcVehicleInfo == null)
		{
			return null;
		}
		return new int?(npcVehicleInfo.VehicleEntityId);
	}

	// Token: 0x0601A60C RID: 108044 RVA: 0x007C6994 File Offset: 0x007C4B94
	public int? GetRideSeat(int npcEntityId, int vehicleEntityId = 0)
	{
		if (vehicleEntityId != 0)
		{
			NpcVehicleInfo valueOrDefault = this.VehicleToNpcInfoMap.GetValueOrDefault(vehicleEntityId);
			if (valueOrDefault == null)
			{
				return null;
			}
			return valueOrDefault.GetSeatByNpc(npcEntityId);
		}
		else
		{
			NpcVehicleInfo npcVehicleInfo = this.FindVehicleInfoByNpc(npcEntityId);
			if (npcVehicleInfo == null)
			{
				return null;
			}
			return npcVehicleInfo.GetSeatByNpc(npcEntityId);
		}
	}

	// Token: 0x0601A60D RID: 108045 RVA: 0x007C69E0 File Offset: 0x007C4BE0
	public bool SetNpcVehicleRideState(int npcEntityId, ENpcVehicleRideState state)
	{
		if (state == ENpcVehicleRideState.None)
		{
			return this.ReleaseVehicle(npcEntityId, 0) != null;
		}
		NpcVehicleInfo npcVehicleInfo = this.FindVehicleInfoByNpc(npcEntityId);
		if (npcVehicleInfo == null || !npcVehicleInfo.SetNpcRideState(npcEntityId, state))
		{
			return false;
		}
		this.RefreshVehicleFreeState(npcVehicleInfo.VehicleEntityId);
		return true;
	}

	// Token: 0x0601A60E RID: 108046 RVA: 0x007C6A2B File Offset: 0x007C4C2B
	public ENpcVehicleRideState GetNpcVehicleRideState(int npcEntityId)
	{
		NpcVehicleInfo npcVehicleInfo = this.FindVehicleInfoByNpc(npcEntityId);
		if (npcVehicleInfo == null)
		{
			return ENpcVehicleRideState.None;
		}
		return npcVehicleInfo.GetNpcRideState(npcEntityId);
	}

	// Token: 0x0601A60F RID: 108047 RVA: 0x007C6A40 File Offset: 0x007C4C40
	public bool SetNpcTargetSplinePbDataId(int npcEntityId, int splinePbDataId)
	{
		NpcVehicleInfo npcVehicleInfo = this.FindVehicleInfoByNpc(npcEntityId);
		return npcVehicleInfo != null && npcVehicleInfo.SetNpcTargetSplinePbDataId(npcEntityId, splinePbDataId);
	}

	// Token: 0x0601A610 RID: 108048 RVA: 0x007C6A58 File Offset: 0x007C4C58
	public int? GetNpcTargetSplinePbDataId(int npcEntityId)
	{
		NpcVehicleInfo npcVehicleInfo = this.FindVehicleInfoByNpc(npcEntityId);
		if (npcVehicleInfo == null)
		{
			return null;
		}
		return npcVehicleInfo.GetNpcTargetSplinePbDataId(npcEntityId);
	}

	// Token: 0x0601A611 RID: 108049 RVA: 0x007C6A80 File Offset: 0x007C4C80
	public bool GetVehicleIsWaitingNpc(int vehicleEntityId, int checkState)
	{
		NpcVehicleInfo valueOrDefault = this.VehicleToNpcInfoMap.GetValueOrDefault(vehicleEntityId);
		if (valueOrDefault == null)
		{
			return false;
		}
		foreach (NpcSeatInfo npcSeatInfo in valueOrDefault.NpcSeatInfoList)
		{
			if (npcSeatInfo.RideState == ENpcVehicleRideState.MoveToVehicle && checkState == 0)
			{
				return true;
			}
			if (npcSeatInfo.RideState == ENpcVehicleRideState.WaitingToDismount && checkState == 1)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0601A612 RID: 108050 RVA: 0x007C6B04 File Offset: 0x007C4D04
	public bool IsVehicleMovingToTarget(int vehicleEntityId)
	{
		NpcVehicleInfo valueOrDefault = this.VehicleToNpcInfoMap.GetValueOrDefault(vehicleEntityId);
		return valueOrDefault != null && valueOrDefault.IsMovingToTarget();
	}

	// Token: 0x0601A613 RID: 108051 RVA: 0x007C6B20 File Offset: 0x007C4D20
	public int? GetAvailableRouteNpc(int vehicleEntityId)
	{
		NpcVehicleInfo valueOrDefault = this.VehicleToNpcInfoMap.GetValueOrDefault(vehicleEntityId);
		if (valueOrDefault == null)
		{
			return null;
		}
		return valueOrDefault.GetAvailableRouteNpcEntityId();
	}

	// Token: 0x0601A614 RID: 108052 RVA: 0x007C6B4C File Offset: 0x007C4D4C
	public unsafe int? ActivateNpcRouteBySpline(int vehicleEntityId, int splinePbDataId)
	{
		NpcVehicleInfo valueOrDefault = this.VehicleToNpcInfoMap.GetValueOrDefault(vehicleEntityId);
		if (valueOrDefault == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Vehicle;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "[NpcVehicleRiderModel] 激活样条路线失败, 载具未注册";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("VehicleEntityId", vehicleEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SplinePbDataId", splinePbDataId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		int? npcEntityIdBySplinePbDataId = valueOrDefault.GetNpcEntityIdBySplinePbDataId(splinePbDataId);
		if (npcEntityIdBySplinePbDataId == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Vehicle;
			ELogAuthor author2 = ELogAuthor.ZJL;
			string message2 = "[NpcVehicleRiderModel] 激活样条路线失败, 该样条在载具上无对应乘客";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("VehicleEntityId", vehicleEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("SplinePbDataId", splinePbDataId);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return null;
		}
		if (!valueOrDefault.SetNpcRideState(npcEntityIdBySplinePbDataId.Value, ENpcVehicleRideState.MoveToTargetPoint))
		{
			return null;
		}
		this.RefreshVehicleFreeState(vehicleEntityId);
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module3 = ELogModule.Vehicle;
		ELogAuthor author3 = ELogAuthor.ZJL;
		string message3 = "[NpcVehicleRiderModel] 激活样条路线, NPC进入前往目标点状态";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("NpcEntityId", npcEntityIdBySplinePbDataId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("VehicleEntityId", vehicleEntityId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("SplinePbDataId", splinePbDataId);
		instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
		return npcEntityIdBySplinePbDataId;
	}

	// Token: 0x0601A615 RID: 108053 RVA: 0x007C6CF0 File Offset: 0x007C4EF0
	public unsafe void RefreshVehicleRuntimeInfo(int vehicleEntityId)
	{
		NpcVehicleInfo valueOrDefault = this.VehicleToNpcInfoMap.GetValueOrDefault(vehicleEntityId);
		if (valueOrDefault == null)
		{
			this.RemoveFreeVehicleInternal(vehicleEntityId);
			return;
		}
		foreach (int num in valueOrDefault.RemoveInvalidNpcInfos())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Vehicle;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "[NpcVehicleRiderModel] 刷新载具时移除失效NPC占位";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("NpcEntityId", num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("VehicleEntityId", vehicleEntityId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		this.RefreshVehicleFreeState(vehicleEntityId);
	}

	// Token: 0x0601A616 RID: 108054 RVA: 0x007C6DBC File Offset: 0x007C4FBC
	public void RefreshAllVehicleRuntimeInfo()
	{
		foreach (int vehicleEntityId in this.VehicleToNpcInfoMap.Keys)
		{
			this.RefreshVehicleRuntimeInfo(vehicleEntityId);
		}
	}

	// Token: 0x0601A617 RID: 108055 RVA: 0x007C6E14 File Offset: 0x007C5014
	private void RefreshVehicleFreeState(int vehicleEntityId)
	{
		NpcVehicleInfo valueOrDefault = this.VehicleToNpcInfoMap.GetValueOrDefault(vehicleEntityId);
		if (valueOrDefault == null || !valueOrDefault.HasAvailableSeat())
		{
			this.RemoveFreeVehicleInternal(vehicleEntityId);
			return;
		}
		this.AddFreeVehicleInternal(vehicleEntityId);
	}

	// Token: 0x0601A618 RID: 108056 RVA: 0x007C6E48 File Offset: 0x007C5048
	private void RemoveFreeVehicleInternal(int vehicleEntityId)
	{
		this.FreeVehicleSet.Remove(vehicleEntityId);
	}

	// Token: 0x0601A619 RID: 108057 RVA: 0x007C6E58 File Offset: 0x007C5058
	public void GetCurrentFreeVehicleList(List<int> outList)
	{
		outList.Clear();
		foreach (int item in this.FreeVehicleSet)
		{
			outList.Add(item);
		}
	}

	// Token: 0x0601A61A RID: 108058 RVA: 0x007C6EB4 File Offset: 0x007C50B4
	public bool CheckVehicleIsFree(int vehicleEntityId)
	{
		NpcVehicleInfo valueOrDefault = this.VehicleToNpcInfoMap.GetValueOrDefault(vehicleEntityId);
		return valueOrDefault == null || valueOrDefault.HasAvailableSeat();
	}

	// Token: 0x0601A61B RID: 108059 RVA: 0x007C6EDC File Offset: 0x007C50DC
	[NullableContext(2)]
	private NpcVehicleInfo FindVehicleInfoByNpc(int npcEntityId)
	{
		foreach (NpcVehicleInfo npcVehicleInfo in this.VehicleToNpcInfoMap.Values)
		{
			if (npcVehicleInfo.GetSeatByNpc(npcEntityId) != null)
			{
				return npcVehicleInfo;
			}
		}
		return null;
	}

	// Token: 0x0400D4D1 RID: 54481
	private readonly HashSet<int> FreeVehicleSet = new HashSet<int>();

	// Token: 0x0400D4D2 RID: 54482
	private readonly Dictionary<int, NpcVehicleInfo> VehicleToNpcInfoMap = new Dictionary<int, NpcVehicleInfo>();

	// Token: 0x0400D4D3 RID: 54483
	private readonly List<int> TmpNpcEntityIdList = new List<int>();
}
