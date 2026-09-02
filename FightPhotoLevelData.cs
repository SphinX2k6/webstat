using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;

// Token: 0x0200131D RID: 4893
[NullableContext(1)]
[Nullable(0)]
public class FightPhotoLevelData
{
	// Token: 0x0600855C RID: 34140 RVA: 0x002321D5 File Offset: 0x002303D5
	public FightPhotoLevelData(PhotoFightActivity config)
	{
		this.Config = config;
	}

	// Token: 0x17000B44 RID: 2884
	// (get) Token: 0x0600855E RID: 34142 RVA: 0x002321F8 File Offset: 0x002303F8
	// (set) Token: 0x0600855D RID: 34141 RVA: 0x002321EF File Offset: 0x002303EF
	public bool IsUnLock
	{
		get
		{
			return this.LevelGroupData.IsUnLock && this.IsUnLockInternal;
		}
		set
		{
			this.IsUnLockInternal = value;
		}
	}

	// Token: 0x17000B45 RID: 2885
	// (get) Token: 0x06008560 RID: 34144 RVA: 0x00232218 File Offset: 0x00230418
	// (set) Token: 0x0600855F RID: 34143 RVA: 0x0023220F File Offset: 0x0023040F
	public bool IsFinished
	{
		get
		{
			return this.IsFinishedInternal;
		}
		set
		{
			this.IsFinishedInternal = value;
		}
	}

	// Token: 0x17000B46 RID: 2886
	// (get) Token: 0x06008562 RID: 34146 RVA: 0x00232229 File Offset: 0x00230429
	// (set) Token: 0x06008561 RID: 34145 RVA: 0x00232220 File Offset: 0x00230420
	public FightPhotoLevelGroupData LevelGroupData
	{
		get
		{
			return this.LevelGroupDataInternal;
		}
		set
		{
			this.LevelGroupDataInternal = value;
		}
	}

	// Token: 0x06008563 RID: 34147 RVA: 0x00232231 File Offset: 0x00230431
	public void SetRoleIdList(List<int> roleIdList)
	{
		if (roleIdList.Count == 0)
		{
			this.RoleIdList = this.Config.PreSelectRoleList().ToList<int>();
			return;
		}
		this.RoleIdList = roleIdList;
	}

	// Token: 0x06008564 RID: 34148 RVA: 0x00232259 File Offset: 0x00230459
	public List<int> GetRoleIdList()
	{
		return this.RoleIdList;
	}

	// Token: 0x06008565 RID: 34149 RVA: 0x00232264 File Offset: 0x00230464
	public List<int> GetRoleIdListIncludeZero()
	{
		List<int> list = new List<int>(this.RoleIdList);
		while (list.Count < 3)
		{
			list.Add(0);
		}
		return list;
	}

	// Token: 0x17000B47 RID: 2887
	// (get) Token: 0x06008566 RID: 34150 RVA: 0x00232290 File Offset: 0x00230490
	public bool HasRedDot
	{
		get
		{
			return this.IsUnLock && !this.IsFinished && !(LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.FightPhotoLevelRedDot, null) ?? new HashSet<int>()).Contains(this.LevelId);
		}
	}

	// Token: 0x06008567 RID: 34151 RVA: 0x002322C8 File Offset: 0x002304C8
	public void ReadRedDot()
	{
		HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.FightPhotoLevelRedDot, null) ?? new HashSet<int>();
		hashSet.Add(this.LevelId);
		LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.FightPhotoLevelRedDot, hashSet);
	}

	// Token: 0x17000B48 RID: 2888
	// (get) Token: 0x06008568 RID: 34152 RVA: 0x00232303 File Offset: 0x00230503
	public int LevelId
	{
		get
		{
			return this.Config.Id;
		}
	}

	// Token: 0x17000B49 RID: 2889
	// (get) Token: 0x06008569 RID: 34153 RVA: 0x00232310 File Offset: 0x00230510
	public string Name
	{
		get
		{
			return this.Config.LevelName;
		}
	}

	// Token: 0x17000B4A RID: 2890
	// (get) Token: 0x0600856A RID: 34154 RVA: 0x0023231D File Offset: 0x0023051D
	public string LevelSimpleName
	{
		get
		{
			return this.Config.LevelSimpleName;
		}
	}

	// Token: 0x17000B4B RID: 2891
	// (get) Token: 0x0600856B RID: 34155 RVA: 0x0023232C File Offset: 0x0023052C
	public string PreLevelName
	{
		get
		{
			PhotoFightActivity? config = ConfigPhotoFightActivityById.GetConfig(this.Config.PreInstId, true);
			if (config != null)
			{
				return config.Value.LevelName;
			}
			return string.Empty;
		}
	}

	// Token: 0x17000B4C RID: 2892
	// (get) Token: 0x0600856C RID: 34156 RVA: 0x00232369 File Offset: 0x00230569
	public bool IsDifficulty
	{
		get
		{
			return this.Config.IsDifficulty;
		}
	}

	// Token: 0x17000B4D RID: 2893
	// (get) Token: 0x0600856D RID: 34157 RVA: 0x00232376 File Offset: 0x00230576
	public string RoleBigTexture
	{
		get
		{
			return this.Config.RoleBigTexture;
		}
	}

	// Token: 0x17000B4E RID: 2894
	// (get) Token: 0x0600856E RID: 34158 RVA: 0x00232383 File Offset: 0x00230583
	public string[] TaskTargetText
	{
		get
		{
			return this.Config.TaskDescriptionText();
		}
	}

	// Token: 0x17000B4F RID: 2895
	// (get) Token: 0x0600856F RID: 34159 RVA: 0x00232390 File Offset: 0x00230590
	[Nullable(0)]
	public Span<int> TrialRoleList
	{
		[NullableContext(0)]
		get
		{
			return this.Config.GetTrailRoleBytes();
		}
	}

	// Token: 0x17000B50 RID: 2896
	// (get) Token: 0x06008570 RID: 34160 RVA: 0x0023239D File Offset: 0x0023059D
	public int InstanceId
	{
		get
		{
			return this.Config.InstId;
		}
	}

	// Token: 0x17000B51 RID: 2897
	// (get) Token: 0x06008571 RID: 34161 RVA: 0x002323AA File Offset: 0x002305AA
	public string NpcHeadIcon
	{
		get
		{
			return this.Config.NpcHeadIcon;
		}
	}

	// Token: 0x17000B52 RID: 2898
	// (get) Token: 0x06008572 RID: 34162 RVA: 0x002323B7 File Offset: 0x002305B7
	public string NpcDialogue
	{
		get
		{
			return this.Config.NpcDialogue;
		}
	}

	// Token: 0x17000B53 RID: 2899
	// (get) Token: 0x06008573 RID: 34163 RVA: 0x002323C4 File Offset: 0x002305C4
	public int LoadingId
	{
		get
		{
			return this.Config.LoadingId;
		}
	}

	// Token: 0x17000B54 RID: 2900
	// (get) Token: 0x06008574 RID: 34164 RVA: 0x002323D1 File Offset: 0x002305D1
	public List<int> TargetRoles
	{
		get
		{
			return this.Config.TargetRoles().ToList<int>();
		}
	}

	// Token: 0x04003F22 RID: 16162
	private PhotoFightActivity Config;

	// Token: 0x04003F23 RID: 16163
	private List<int> RoleIdList = new List<int>();

	// Token: 0x04003F24 RID: 16164
	private FightPhotoLevelGroupData LevelGroupDataInternal;

	// Token: 0x04003F25 RID: 16165
	private bool IsUnLockInternal;

	// Token: 0x04003F26 RID: 16166
	private bool IsFinishedInternal;
}
