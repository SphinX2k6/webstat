using System;
using Aki.Config;

// Token: 0x02001EE8 RID: 7912
public class HonamiStoryTechNodeData
{
	// Token: 0x0600EA70 RID: 60016 RVA: 0x003F9A62 File Offset: 0x003F7C62
	public HonamiStoryTechNodeData(HonamiStoryTalent config)
	{
		this.Config = config;
	}

	// Token: 0x0600EA71 RID: 60017 RVA: 0x003F9A71 File Offset: 0x003F7C71
	public void SetNodeStatus(int status)
	{
		if (status == 1)
		{
			this.NodeStatus = ENodeStatus.CanActive;
			return;
		}
		if (status == 2)
		{
			this.NodeStatus = ENodeStatus.IsActive;
		}
	}

	// Token: 0x17001214 RID: 4628
	// (get) Token: 0x0600EA72 RID: 60018 RVA: 0x003F9A8A File Offset: 0x003F7C8A
	public ENodeStatus GetNodeStatus
	{
		get
		{
			return this.NodeStatus;
		}
	}

	// Token: 0x17001215 RID: 4629
	// (get) Token: 0x0600EA73 RID: 60019 RVA: 0x003F9A94 File Offset: 0x003F7C94
	public bool PreNodeIsActive
	{
		get
		{
			foreach (int id in this.Config.PreId())
			{
				HonamiStoryTechNodeData techNodeData = ModelBase<HonamiStoryModel>.Instance.GetTechNodeData(id);
				if (techNodeData == null || techNodeData.GetNodeStatus != ENodeStatus.IsActive)
				{
					return false;
				}
			}
			return true;
		}
	}

	// Token: 0x17001216 RID: 4630
	// (get) Token: 0x0600EA74 RID: 60020 RVA: 0x003F9ADA File Offset: 0x003F7CDA
	public int Id
	{
		get
		{
			return this.Config.Id;
		}
	}

	// Token: 0x17001217 RID: 4631
	// (get) Token: 0x0600EA75 RID: 60021 RVA: 0x003F9AE7 File Offset: 0x003F7CE7
	public HonamiStoryTalent GetConfig
	{
		get
		{
			return this.Config;
		}
	}

	// Token: 0x04007105 RID: 28933
	private HonamiStoryTalent Config;

	// Token: 0x04007106 RID: 28934
	private ENodeStatus NodeStatus;
}
