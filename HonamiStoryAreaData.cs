using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.HonamiStory;

// Token: 0x02001ED0 RID: 7888
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryAreaData
{
	// Token: 0x0600E95D RID: 59741 RVA: 0x003F4CD0 File Offset: 0x003F2ED0
	public HonamiStoryAreaData(int areaId)
	{
		this.AreaId = areaId;
		this.AreaStateInternal = EHonamiStoryAreaState.Lock;
	}

	// Token: 0x0600E95E RID: 59742 RVA: 0x003F4CE8 File Offset: 0x003F2EE8
	public void UpdateData(HonamiStoryAreaInfo areaInfo)
	{
		this.SecretStateInternal = (EHonamiStoryCollectState)areaInfo.SecreteStatus;
		EHonamiStoryAreaState status = (EHonamiStoryAreaState)areaInfo.Status;
		if (this.AreaStateInternal == EHonamiStoryAreaState.Lock && status == EHonamiStoryAreaState.UnLock)
		{
			int areaId = this.AreaId;
			if (this.Config.Value.UnLockTips.Length > 0)
			{
				Dictionary<int, bool> player = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.HonamiStorySelectLvAreaUnLockTips, new Dictionary<int, bool>());
				if (!player.ContainsKey(areaId))
				{
					player[areaId] = true;
					LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.HonamiStorySelectLvAreaUnLockTips, player);
				}
			}
		}
		this.AreaStateInternal = status;
	}

	// Token: 0x0600E95F RID: 59743 RVA: 0x003F4D71 File Offset: 0x003F2F71
	public void UpdateCollectMascotState(EHonamiStoryCollectState state)
	{
		this.SecretStateInternal = state;
	}

	// Token: 0x170011E2 RID: 4578
	// (get) Token: 0x0600E960 RID: 59744 RVA: 0x003F4D7A File Offset: 0x003F2F7A
	public EHonamiStoryCollectState CollectMascotState
	{
		get
		{
			return this.SecretStateInternal;
		}
	}

	// Token: 0x170011E3 RID: 4579
	// (get) Token: 0x0600E961 RID: 59745 RVA: 0x003F4D82 File Offset: 0x003F2F82
	public HonamiStoryArea? Config
	{
		get
		{
			return ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryAreaConfig(this.AreaId);
		}
	}

	// Token: 0x170011E4 RID: 4580
	// (get) Token: 0x0600E962 RID: 59746 RVA: 0x003F4D94 File Offset: 0x003F2F94
	public int Id
	{
		get
		{
			return this.AreaId;
		}
	}

	// Token: 0x170011E5 RID: 4581
	// (get) Token: 0x0600E963 RID: 59747 RVA: 0x003F4D9C File Offset: 0x003F2F9C
	public string Name
	{
		get
		{
			return this.Config.Value.Name;
		}
	}

	// Token: 0x170011E6 RID: 4582
	// (get) Token: 0x0600E964 RID: 59748 RVA: 0x003F4DC0 File Offset: 0x003F2FC0
	public string Desc
	{
		get
		{
			return this.Config.Value.Desc;
		}
	}

	// Token: 0x170011E7 RID: 4583
	// (get) Token: 0x0600E965 RID: 59749 RVA: 0x003F4DE4 File Offset: 0x003F2FE4
	public int DropId
	{
		get
		{
			return this.Config.Value.DropId;
		}
	}

	// Token: 0x170011E8 RID: 4584
	// (get) Token: 0x0600E966 RID: 59750 RVA: 0x003F4E07 File Offset: 0x003F3007
	public bool IsAreaUnlock
	{
		get
		{
			return this.AreaStateInternal > EHonamiStoryAreaState.Lock;
		}
	}

	// Token: 0x170011E9 RID: 4585
	// (get) Token: 0x0600E967 RID: 59751 RVA: 0x003F4E12 File Offset: 0x003F3012
	public EHonamiStoryAreaState GetAreaState
	{
		get
		{
			return this.AreaStateInternal;
		}
	}

	// Token: 0x170011EA RID: 4586
	// (get) Token: 0x0600E968 RID: 59752 RVA: 0x003F4E1A File Offset: 0x003F301A
	public bool IsAreaCanEnter
	{
		get
		{
			return this.AreaStateInternal > EHonamiStoryAreaState.Lock;
		}
	}

	// Token: 0x170011EB RID: 4587
	// (get) Token: 0x0600E969 RID: 59753 RVA: 0x003F4E25 File Offset: 0x003F3025
	public bool IsSecretFinished
	{
		get
		{
			return this.SecretStateInternal == EHonamiStoryCollectState.Finished;
		}
	}

	// Token: 0x170011EC RID: 4588
	// (get) Token: 0x0600E96A RID: 59754 RVA: 0x003F4E30 File Offset: 0x003F3030
	public int LevelPlayId
	{
		get
		{
			return this.Config.Value.MainBTId;
		}
	}

	// Token: 0x0400709B RID: 28827
	private readonly int AreaId;

	// Token: 0x0400709C RID: 28828
	private EHonamiStoryCollectState SecretStateInternal;

	// Token: 0x0400709D RID: 28829
	private EHonamiStoryAreaState AreaStateInternal;
}
