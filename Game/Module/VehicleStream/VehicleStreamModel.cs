using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.VehicleStream.StateMachineContainer;
using UnrealEngine;

namespace CSharpScript.Game.Module.VehicleStream
{
	// Token: 0x02004C4B RID: 19531
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class VehicleStreamModel : ModelBase<VehicleStreamModel>
	{
		// Token: 0x06032E33 RID: 208435 RVA: 0x00CBEA74 File Offset: 0x00CBCC74
		protected override bool OnLeaveLevel()
		{
			this.TransportSystemInitDone = false;
			this.Intersections.Clear();
			this.RoadwayId2IntersectionId.Clear();
			this.CrossingRoadway.Clear();
			this.VehiclesInRoadways.Clear();
			this.WaitTransportInitVehicles.Clear();
			return true;
		}

		// Token: 0x06032E34 RID: 208436 RVA: 0x00CBEAC0 File Offset: 0x00CBCCC0
		public Dictionary<int, CSharpScript.Game.Module.VehicleStream.StateMachineContainer.VehicleTeam> GetAllVehicleTeam()
		{
			return this.VehicleTeamMap;
		}

		// Token: 0x06032E35 RID: 208437 RVA: 0x00CBEAC8 File Offset: 0x00CBCCC8
		[NullableContext(2)]
		public CSharpScript.Game.Module.VehicleStream.StateMachineContainer.VehicleTeam GetVehicleTeam(int teamId)
		{
			CSharpScript.Game.Module.VehicleStream.StateMachineContainer.VehicleTeam result;
			this.VehicleTeamMap.TryGetValue(teamId, out result);
			return result;
		}

		// Token: 0x06032E36 RID: 208438 RVA: 0x00CBEAE5 File Offset: 0x00CBCCE5
		public void AddVehicleTeam(int teamId, CSharpScript.Game.Module.VehicleStream.StateMachineContainer.VehicleTeam team)
		{
			this.VehicleTeamMap[teamId] = team;
		}

		// Token: 0x06032E37 RID: 208439 RVA: 0x00CBEAF4 File Offset: 0x00CBCCF4
		public bool RemoveTeamMember(long vehicleCreatureDataId)
		{
			VehicleTeamMember vehicleTeamMember = this.GetVehicleTeamMember(vehicleCreatureDataId);
			if (vehicleTeamMember == null)
			{
				return false;
			}
			CSharpScript.Game.Module.VehicleStream.StateMachineContainer.VehicleTeam vehicleTeam = this.GetVehicleTeam(vehicleTeamMember.TeamId);
			if (vehicleTeam != null)
			{
				vehicleTeam.RemoveVehicleMember(vehicleCreatureDataId);
			}
			vehicleTeamMember.Destroy();
			return true;
		}

		// Token: 0x06032E38 RID: 208440 RVA: 0x00CBEB30 File Offset: 0x00CBCD30
		[NullableContext(2)]
		public VehicleTeamMember GetVehicleTeamMember(long vehicleCreatureDataId)
		{
			VehicleTeamMember result;
			this.VehicleTeamMemberDict.TryGetValue(vehicleCreatureDataId, out result);
			return result;
		}

		// Token: 0x06032E39 RID: 208441 RVA: 0x00CBEB50 File Offset: 0x00CBCD50
		public void OnAddVehicleTeamMember(long vehicleCreatureDataId, VehicleTeamMember member)
		{
			VehicleTeamMember vehicleTeamMember;
			if (this.VehicleTeamMemberDict.TryGetValue(vehicleCreatureDataId, out vehicleTeamMember))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.VehicleStream;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "[VehicleStream]VehicleStreamModel.OnAddVehicleTeamMember:同一个载具重复添加";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("vehicleCreatureDataId", vehicleCreatureDataId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.VehicleTeamMemberDict[vehicleCreatureDataId] = member;
		}

		// Token: 0x06032E3A RID: 208442 RVA: 0x00CBEBAA File Offset: 0x00CBCDAA
		public void OnRemoveVehicleTeamMember(long vehicleCreatureDataId)
		{
			this.VehicleTeamMemberDict.Remove(vehicleCreatureDataId);
		}

		// Token: 0x06032E3B RID: 208443 RVA: 0x00CBEBBC File Offset: 0x00CBCDBC
		public bool AddIntersection(int intersectionId, TArray<int> inRoadways)
		{
			if (this.Intersections.ContainsKey(intersectionId))
			{
				return false;
			}
			int[] array = new int[inRoadways.Num()];
			for (int i = 0; i < inRoadways.Num(); i++)
			{
				int num = inRoadways[i];
				this.RoadwayId2IntersectionId[num] = intersectionId;
				array[i] = num;
			}
			this.Intersections[intersectionId] = array;
			return true;
		}

		// Token: 0x06032E3C RID: 208444 RVA: 0x00CBEC20 File Offset: 0x00CBCE20
		public bool RecordCrossingRoadways(int roadwayId, TArray<int> inCrossingRoadways)
		{
			if (this.CrossingRoadway.ContainsKey(roadwayId))
			{
				return false;
			}
			int[] array = new int[inCrossingRoadways.Num()];
			for (int i = 0; i < inCrossingRoadways.Num(); i++)
			{
				int num = inCrossingRoadways[i];
				array[i] = num;
			}
			this.CrossingRoadway[roadwayId] = array;
			return true;
		}

		// Token: 0x06032E3D RID: 208445 RVA: 0x00CBEC74 File Offset: 0x00CBCE74
		[NullableContext(2)]
		public global::Vector GetRelativePosition(int teamConfigId, int teamMemberIndex)
		{
			if (teamConfigId <= 0)
			{
				return null;
			}
			Aki.Config.VehicleTeam? config = ConfigVehicleTeamById.GetConfig(teamConfigId, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.VehicleStream;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "[VehicleStream]VehicleStreamModel.GetRelativePosition:找不到车队配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", teamConfigId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return global::Vector.Create((config != null) ? config.GetValueOrDefault().PositionList(teamMemberIndex) : null);
		}

		// Token: 0x06032E3E RID: 208446 RVA: 0x00CBECF4 File Offset: 0x00CBCEF4
		public void EnterRoadway(int roadwayId, long vehicleCreatureDataId)
		{
			HashSet<long> hashSet;
			if (!this.VehiclesInRoadways.TryGetValue(roadwayId, out hashSet))
			{
				hashSet = new HashSet<long>();
				this.VehiclesInRoadways[roadwayId] = hashSet;
			}
			hashSet.Add(vehicleCreatureDataId);
		}

		// Token: 0x06032E3F RID: 208447 RVA: 0x00CBED2C File Offset: 0x00CBCF2C
		public void ExitRoadway(int roadwayId, long vehicleCreatureDataId)
		{
			HashSet<long> hashSet;
			if (!this.VehiclesInRoadways.TryGetValue(roadwayId, out hashSet) || hashSet.Count == 0)
			{
				return;
			}
			hashSet.Remove(vehicleCreatureDataId);
		}

		// Token: 0x06032E40 RID: 208448 RVA: 0x00CBED5C File Offset: 0x00CBCF5C
		[NullableContext(2)]
		public HashSet<long> GetAllVehicleInRoadway(int roadwayId)
		{
			HashSet<long> result;
			this.VehiclesInRoadways.TryGetValue(roadwayId, out result);
			return result;
		}

		// Token: 0x06032E41 RID: 208449 RVA: 0x00CBED7C File Offset: 0x00CBCF7C
		public bool CheckIntersectionRoadwayOccupied(int inRoadwayId)
		{
			HashSet<long> hashSet;
			if (this.EnableInteractionSinglePass && this.VehiclesInRoadways.TryGetValue(inRoadwayId, out hashSet) && hashSet.Count > 0)
			{
				return true;
			}
			int intersectionId = this.GetIntersectionId(inRoadwayId);
			int[] array;
			if (!this.Intersections.TryGetValue(intersectionId, out array))
			{
				return false;
			}
			foreach (int num in array)
			{
				HashSet<long> hashSet2;
				if (num != inRoadwayId && this.VehiclesInRoadways.TryGetValue(num, out hashSet2) && hashSet2.Count > 0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06032E42 RID: 208450 RVA: 0x00CBEE03 File Offset: 0x00CBD003
		public void AddWaitTransportInitVehicle(long creatureDataId, IRegisterVehicleData data)
		{
			this.WaitTransportInitVehicles[creatureDataId] = data;
		}

		// Token: 0x06032E43 RID: 208451 RVA: 0x00CBEE12 File Offset: 0x00CBD012
		public Dictionary<long, IRegisterVehicleData> GetWaitTransportInitVehicles()
		{
			return this.WaitTransportInitVehicles;
		}

		// Token: 0x06032E44 RID: 208452 RVA: 0x00CBEE1C File Offset: 0x00CBD01C
		public int GetIntersectionId(int roadwayId)
		{
			int result;
			if (!this.RoadwayId2IntersectionId.TryGetValue(roadwayId, out result))
			{
				return 0;
			}
			return result;
		}

		// Token: 0x0401D9F2 RID: 121330
		public readonly bool EnableDebug;

		// Token: 0x0401D9F3 RID: 121331
		public readonly bool EnableInteractionSinglePass;

		// Token: 0x0401D9F4 RID: 121332
		public readonly bool EnableRotationOptimize = true;

		// Token: 0x0401D9F5 RID: 121333
		public bool TransportSystemInitDone;

		// Token: 0x0401D9F6 RID: 121334
		public readonly global::Vector SplineLocation = global::Vector.Create();

		// Token: 0x0401D9F7 RID: 121335
		public readonly Rotator SplineRotation = Rotator.Create();

		// Token: 0x0401D9F8 RID: 121336
		public readonly global::Vector BasisForwardVector = global::Vector.Create();

		// Token: 0x0401D9F9 RID: 121337
		public readonly global::Vector BasisUpVector = global::Vector.Create();

		// Token: 0x0401D9FA RID: 121338
		public readonly global::Vector BasisRightVector = global::Vector.Create();

		// Token: 0x0401D9FB RID: 121339
		public readonly global::Vector CacheVector = global::Vector.Create();

		// Token: 0x0401D9FC RID: 121340
		private readonly Dictionary<int, CSharpScript.Game.Module.VehicleStream.StateMachineContainer.VehicleTeam> VehicleTeamMap = new Dictionary<int, CSharpScript.Game.Module.VehicleStream.StateMachineContainer.VehicleTeam>();

		// Token: 0x0401D9FD RID: 121341
		private readonly Dictionary<long, VehicleTeamMember> VehicleTeamMemberDict = new Dictionary<long, VehicleTeamMember>();

		// Token: 0x0401D9FE RID: 121342
		private readonly Dictionary<int, int[]> Intersections = new Dictionary<int, int[]>();

		// Token: 0x0401D9FF RID: 121343
		private readonly Dictionary<int, int> RoadwayId2IntersectionId = new Dictionary<int, int>();

		// Token: 0x0401DA00 RID: 121344
		private readonly Dictionary<int, int[]> CrossingRoadway = new Dictionary<int, int[]>();

		// Token: 0x0401DA01 RID: 121345
		private readonly Dictionary<int, HashSet<long>> VehiclesInRoadways = new Dictionary<int, HashSet<long>>();

		// Token: 0x0401DA02 RID: 121346
		private readonly Dictionary<long, IRegisterVehicleData> WaitTransportInitVehicles = new Dictionary<long, IRegisterVehicleData>();
	}
}
