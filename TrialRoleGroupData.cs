using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.RoleUi;
using Google.Protobuf.Collections;

// Token: 0x020028F0 RID: 10480
[NullableContext(2)]
[Nullable(0)]
public class TrialRoleGroupData
{
	// Token: 0x17001B4F RID: 6991
	// (get) Token: 0x06014D0F RID: 85263 RVA: 0x005C3FB0 File Offset: 0x005C21B0
	public int RealRoleId
	{
		get
		{
			if (this.ActivatedRoleConfigInternal == null)
			{
				return 0;
			}
			return this.ActivatedRoleConfigInternal.GetValueOrDefault().ParentId;
		}
	}

	// Token: 0x17001B50 RID: 6992
	// (get) Token: 0x06014D10 RID: 85264 RVA: 0x005C3FDC File Offset: 0x005C21DC
	public int TrialRoleId
	{
		get
		{
			if (this.ActivatedRoleConfigInternal == null)
			{
				return 0;
			}
			return this.ActivatedRoleConfigInternal.GetValueOrDefault().Id;
		}
	}

	// Token: 0x17001B51 RID: 6993
	// (get) Token: 0x06014D11 RID: 85265 RVA: 0x005C4008 File Offset: 0x005C2208
	public int TrialRoleGroupId
	{
		get
		{
			if (this.ActivatedRoleConfigInternal == null)
			{
				return 0;
			}
			return this.ActivatedRoleConfigInternal.GetValueOrDefault().GroupId;
		}
	}

	// Token: 0x17001B52 RID: 6994
	// (get) Token: 0x06014D12 RID: 85266 RVA: 0x005C4033 File Offset: 0x005C2233
	public ETrialRoleStatus Status
	{
		get
		{
			return this.StatusInternal;
		}
	}

	// Token: 0x17001B53 RID: 6995
	// (get) Token: 0x06014D13 RID: 85267 RVA: 0x005C403B File Offset: 0x005C223B
	public TrialRoleInfo TrialRoleConfig
	{
		get
		{
			return this.ActivatedRoleConfigInternal.Value;
		}
	}

	// Token: 0x17001B54 RID: 6996
	// (get) Token: 0x06014D14 RID: 85268 RVA: 0x005C4048 File Offset: 0x005C2248
	public RoleSpecialRobotData TrialRoleData
	{
		get
		{
			return this.ActivatedRoleDataInternal;
		}
	}

	// Token: 0x17001B55 RID: 6997
	// (get) Token: 0x06014D15 RID: 85269 RVA: 0x005C4050 File Offset: 0x005C2250
	public ETrialRoleType TrialRoleType
	{
		get
		{
			return (ETrialRoleType)this.ActivatedRoleConfigInternal.Value.Type;
		}
	}

	// Token: 0x06014D16 RID: 85270 RVA: 0x005C4070 File Offset: 0x005C2270
	public TrialRoleGroupData(int trialRoleId)
	{
		TrialRoleConfig instance = ConfigBase<CSharpScript.Game.Module.RoleUi.TrialRoleConfig>.Instance;
		this.ActivatedRoleConfigInternal = ((instance != null) ? instance.GetTrialRoleConfig(trialRoleId) : null);
		if (this.ActivatedRoleConfigInternal != null)
		{
			TrialRoleConfig instance2 = ConfigBase<CSharpScript.Game.Module.RoleUi.TrialRoleConfig>.Instance;
			IReadOnlyList<TrialRoleInfo> readonlyArray = (instance2 != null) ? instance2.GetTrialRoleConfigsByGroupId(this.ActivatedRoleConfigInternal.Value.GroupId) : null;
			this.TrialRoleGroupConfigs = ConfigCommon.ToList<TrialRoleInfo>(readonlyArray);
			List<TrialRoleInfo> trialRoleGroupConfigs = this.TrialRoleGroupConfigs;
			if (trialRoleGroupConfigs == null)
			{
				return;
			}
			trialRoleGroupConfigs.Sort((TrialRoleInfo a, TrialRoleInfo b) => a.WorldLevel - b.WorldLevel);
		}
	}

	// Token: 0x06014D17 RID: 85271 RVA: 0x005C4110 File Offset: 0x005C2310
	public void SetIsUnlocked(bool isUnlocked)
	{
		this.StatusInternal = (isUnlocked ? ETrialRoleStatus.Unlocked : ETrialRoleStatus.Locked);
		if (isUnlocked && this.ActivatedRoleDataInternal == null)
		{
			RoleModel instance = ModelBase<RoleModel>.Instance;
			this.ActivatedRoleDataInternal = (((instance != null) ? instance.GetRoleDataById(this.TrialRoleId, true) : null) as RoleSpecialRobotData);
			if (this.ActivatedRoleDataInternal != null)
			{
				this.ActivatedRoleDataInternal.SetIsVisibleInFormation(false);
				this.ActivatedRoleDataInternal.SetIsVisibleInRoleSystem(false);
			}
		}
		RoleSpecialRobotData activatedRoleDataInternal = this.ActivatedRoleDataInternal;
		if (activatedRoleDataInternal != null)
		{
			activatedRoleDataInternal.SetIsUnlock(isUnlocked);
		}
		if (this.VisibleInFormationHandle != null)
		{
			RoleSpecialRobotData activatedRoleDataInternal2 = this.ActivatedRoleDataInternal;
			if (activatedRoleDataInternal2 != null)
			{
				activatedRoleDataInternal2.SetIsVisibleInFormation(this.VisibleInFormationHandle.Value);
			}
			this.VisibleInFormationHandle = null;
		}
	}

	// Token: 0x06014D18 RID: 85272 RVA: 0x005C41BF File Offset: 0x005C23BF
	public void SetIsVisibleInFormation(bool isVisible)
	{
		if (this.ActivatedRoleDataInternal == null)
		{
			this.VisibleInFormationHandle = new bool?(isVisible);
			return;
		}
		this.ActivatedRoleDataInternal.SetIsVisibleInFormation(isVisible);
	}

	// Token: 0x06014D19 RID: 85273 RVA: 0x005C41E2 File Offset: 0x005C23E2
	public void SetIsVisibleInRoleSystem(bool isVisible)
	{
		RoleSpecialRobotData activatedRoleDataInternal = this.ActivatedRoleDataInternal;
		if (activatedRoleDataInternal == null)
		{
			return;
		}
		activatedRoleDataInternal.SetIsVisibleInRoleSystem(isVisible);
	}

	// Token: 0x06014D1A RID: 85274 RVA: 0x005C41F8 File Offset: 0x005C23F8
	public void SetActivatedTrialRoleId(int trialRoleId)
	{
		RoleSpecialRobotData activatedRoleDataInternal = this.ActivatedRoleDataInternal;
		TrialRoleConfig instance = ConfigBase<CSharpScript.Game.Module.RoleUi.TrialRoleConfig>.Instance;
		this.ActivatedRoleConfigInternal = ((instance != null) ? instance.GetTrialRoleConfig(trialRoleId) : null);
		RoleModel instance2 = ModelBase<RoleModel>.Instance;
		this.ActivatedRoleDataInternal = (((instance2 != null) ? instance2.GetRoleDataById(trialRoleId, true) : null) as RoleSpecialRobotData);
		if (activatedRoleDataInternal != null && activatedRoleDataInternal != this.ActivatedRoleDataInternal)
		{
			activatedRoleDataInternal.SetIsVisibleInFormation(false);
			activatedRoleDataInternal.SetIsVisibleInRoleSystem(false);
		}
	}

	// Token: 0x06014D1B RID: 85275 RVA: 0x005C4264 File Offset: 0x005C2464
	public bool IsLocked()
	{
		return this.StatusInternal == ETrialRoleStatus.Locked;
	}

	// Token: 0x06014D1C RID: 85276 RVA: 0x005C426F File Offset: 0x005C246F
	public bool IsUnlocked()
	{
		return this.StatusInternal == ETrialRoleStatus.Unlocked;
	}

	// Token: 0x06014D1D RID: 85277 RVA: 0x005C427A File Offset: 0x005C247A
	public bool CanUpgrade()
	{
		return this.IsUnlocked() && this.IsReachUpgradeCondition();
	}

	// Token: 0x06014D1E RID: 85278 RVA: 0x005C428C File Offset: 0x005C248C
	public int GetCurWorldLevel()
	{
		if (this.ActivatedRoleConfigInternal == null)
		{
			return 0;
		}
		return this.ActivatedRoleConfigInternal.GetValueOrDefault().WorldLevel;
	}

	// Token: 0x06014D1F RID: 85279 RVA: 0x005C42B8 File Offset: 0x005C24B8
	public int GetNextWorldLevel()
	{
		if (this.TrialRoleGroupConfigs == null)
		{
			return -1;
		}
		int num = -1;
		for (int i = 0; i < this.TrialRoleGroupConfigs.Count; i++)
		{
			if (this.TrialRoleGroupConfigs[i].Id == this.TrialRoleId)
			{
				num = i;
				break;
			}
		}
		if (num >= 0 && num + 1 < this.TrialRoleGroupConfigs.Count)
		{
			return this.TrialRoleGroupConfigs[num + 1].WorldLevel;
		}
		return -1;
	}

	// Token: 0x06014D20 RID: 85280 RVA: 0x005C4337 File Offset: 0x005C2537
	public bool IsMaxLevel()
	{
		return this.GetNextWorldLevel() < 0;
	}

	// Token: 0x06014D21 RID: 85281 RVA: 0x005C4344 File Offset: 0x005C2544
	public bool IsReachUpgradeCondition()
	{
		if (this.IsMaxLevel())
		{
			return false;
		}
		int nextWorldLevel = this.GetNextWorldLevel();
		return nextWorldLevel >= 0 && ModelBase<WorldLevelModel>.Instance.OriginWorldLevel >= nextWorldLevel;
	}

	// Token: 0x06014D22 RID: 85282 RVA: 0x005C4378 File Offset: 0x005C2578
	public int GetPreviewTrialRoleId()
	{
		if (this.IsUnlocked())
		{
			return this.TrialRoleId;
		}
		int originWorldLevel = ModelBase<WorldLevelModel>.Instance.OriginWorldLevel;
		int result = this.TrialRoleId;
		if (this.TrialRoleGroupConfigs != null)
		{
			foreach (TrialRoleInfo trialRoleInfo in this.TrialRoleGroupConfigs)
			{
				if (trialRoleInfo.WorldLevel > originWorldLevel)
				{
					break;
				}
				result = trialRoleInfo.Id;
			}
		}
		return result;
	}

	// Token: 0x06014D23 RID: 85283 RVA: 0x005C4404 File Offset: 0x005C2604
	[NullableContext(1)]
	public void SetActivatedRoleAttr(RepeatedField<ArrayIntInt> baseAttr, RepeatedField<ArrayIntInt> addAttr)
	{
		if (this.ActivatedRoleDataInternal == null)
		{
			return;
		}
		RoleAttributeData attributeData = this.ActivatedRoleDataInternal.GetAttributeData();
		attributeData.ClearRoleBaseAttr();
		foreach (ArrayIntInt arrayIntInt in baseAttr)
		{
			attributeData.SetRoleBaseAttr(arrayIntInt.Key, arrayIntInt.Value);
		}
		attributeData.ClearRoleAddAttr();
		foreach (ArrayIntInt arrayIntInt2 in addAttr)
		{
			attributeData.SetRoleAddAttr(arrayIntInt2.Key, arrayIntInt2.Value);
		}
	}

	// Token: 0x0400A033 RID: 41011
	private TrialRoleInfo? ActivatedRoleConfigInternal;

	// Token: 0x0400A034 RID: 41012
	private RoleSpecialRobotData ActivatedRoleDataInternal;

	// Token: 0x0400A035 RID: 41013
	private ETrialRoleStatus StatusInternal;

	// Token: 0x0400A036 RID: 41014
	private readonly List<TrialRoleInfo> TrialRoleGroupConfigs;

	// Token: 0x0400A037 RID: 41015
	private bool? VisibleInFormationHandle;
}
