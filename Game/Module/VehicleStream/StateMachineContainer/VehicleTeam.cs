using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.VehicleStream.StateMachineContainer
{
	// Token: 0x02004C59 RID: 19545
	[NullableContext(1)]
	[Nullable(0)]
	public class VehicleTeam : StateMachineContainer
	{
		// Token: 0x06032EC3 RID: 208579 RVA: 0x00CC1F33 File Offset: 0x00CC0133
		public VehicleTeam(int teamId)
		{
		}

		// Token: 0x17008775 RID: 34677
		// (get) Token: 0x06032EC4 RID: 208580 RVA: 0x00CC1F4D File Offset: 0x00CC014D
		public override EStateContainerType Type
		{
			get
			{
				return EStateContainerType.VehicleTeam;
			}
		}

		// Token: 0x17008776 RID: 34678
		// (get) Token: 0x06032EC5 RID: 208581 RVA: 0x00CC1F50 File Offset: 0x00CC0150
		public override int Id
		{
			get
			{
				return this.TeamId;
			}
		}

		// Token: 0x17008777 RID: 34679
		// (get) Token: 0x06032EC6 RID: 208582 RVA: 0x00CC1F58 File Offset: 0x00CC0158
		public int TeamId { get; } = teamId;

		// Token: 0x06032EC7 RID: 208583 RVA: 0x00CC1F60 File Offset: 0x00CC0160
		[NullableContext(2)]
		public VehicleTeamMember GetVehicleMember(long creatureDataId)
		{
			VehicleTeamMember result;
			this.MemberList.TryGetValue(creatureDataId, out result);
			return result;
		}

		// Token: 0x06032EC8 RID: 208584 RVA: 0x00CC1F7D File Offset: 0x00CC017D
		public void AddVehicleMember(long creatureDataId, VehicleTeamMember member)
		{
			this.MemberList[creatureDataId] = member;
			ModelBase<VehicleStreamModel>.Instance.OnAddVehicleTeamMember(creatureDataId, member);
		}

		// Token: 0x06032EC9 RID: 208585 RVA: 0x00CC1F98 File Offset: 0x00CC0198
		public void RemoveVehicleMember(long creatureDataId)
		{
			this.MemberList.Remove(creatureDataId);
			ModelBase<VehicleStreamModel>.Instance.OnRemoveVehicleTeamMember(creatureDataId);
		}

		// Token: 0x0401DA56 RID: 121430
		private readonly Dictionary<long, VehicleTeamMember> MemberList = new Dictionary<long, VehicleTeamMember>();
	}
}
