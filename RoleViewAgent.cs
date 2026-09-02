using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020028F7 RID: 10487
[NullableContext(1)]
[Nullable(0)]
public class RoleViewAgent
{
	// Token: 0x06014D43 RID: 85315 RVA: 0x005C4E13 File Offset: 0x005C3013
	public void Init(List<int> roleIdList, int selectRoleId, EUiTabViewName? selectTabName, ERoleViewSource source = ERoleViewSource.Normal)
	{
		this.RoleIdList = roleIdList;
		this.CurSelectRoleId = selectRoleId;
		this.CurSelectTabName = selectTabName;
		this.Source = source;
	}

	// Token: 0x06014D44 RID: 85316 RVA: 0x005C4E32 File Offset: 0x005C3032
	public IReadOnlyList<int> GetRoleIdList()
	{
		if (this.RoleIdList.Count <= 0)
		{
			return ModelBase<RoleModel>.Instance.GetRoleSystemRoleList(true);
		}
		return this.RoleIdList;
	}

	// Token: 0x06014D45 RID: 85317 RVA: 0x005C4E54 File Offset: 0x005C3054
	public void CheckMainRoleToIdList(int mainRoleId)
	{
		if (this.RoleIdList.Count == 0)
		{
			return;
		}
		if (this.RoleIdList.IndexOf(mainRoleId) >= 0)
		{
			return;
		}
		if (!ModelBase<RoleModel>.Instance.IsMainRole(mainRoleId))
		{
			return;
		}
		int num = -1;
		for (int i = 0; i < this.RoleIdList.Count; i++)
		{
			if (ModelBase<RoleModel>.Instance.IsMainRole(this.RoleIdList[i]))
			{
				num = i;
				break;
			}
		}
		if (num != -1)
		{
			this.RoleIdList[num] = mainRoleId;
		}
	}

	// Token: 0x06014D46 RID: 85318 RVA: 0x005C4ED4 File Offset: 0x005C30D4
	public int GetCurSelectRoleId()
	{
		bool flag = this.GetRoleIdList().IndexOf(this.CurSelectRoleId) >= 0;
		if (this.CurSelectRoleId <= 0 || !flag)
		{
			this.CurSelectRoleId = this.GetDefaultSelectRoleId();
		}
		return this.CurSelectRoleId;
	}

	// Token: 0x06014D47 RID: 85319 RVA: 0x005C4F18 File Offset: 0x005C3118
	public int GetDefaultSelectRoleId()
	{
		if (this.RoleIdList.Count > 0)
		{
			return this.RoleIdList[0];
		}
		int? battleTeamFirstRoleId = ModelBase<RoleModel>.Instance.GetBattleTeamFirstRoleId();
		List<int> roleSystemRoleList = ModelBase<RoleModel>.Instance.GetRoleSystemRoleList(true);
		if (battleTeamFirstRoleId != null && roleSystemRoleList.IndexOf(battleTeamFirstRoleId.Value) >= 0)
		{
			return battleTeamFirstRoleId.Value;
		}
		if (roleSystemRoleList.Count <= 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.Role, ELogAuthor.BB, "取不到角色数据！", default(ReadOnlySpan<ValueTuple<string, object>>));
			return 0;
		}
		return roleSystemRoleList[0];
	}

	// Token: 0x06014D48 RID: 85320 RVA: 0x005C4FA6 File Offset: 0x005C31A6
	public void SetCurSelectRoleId(int roleId)
	{
		this.CurSelectRoleId = roleId;
	}

	// Token: 0x06014D49 RID: 85321 RVA: 0x005C4FB0 File Offset: 0x005C31B0
	[NullableContext(2)]
	public RoleDataBase GetCurSelectRoleData()
	{
		int curSelectRoleId = this.GetCurSelectRoleId();
		return ModelBase<RoleModel>.Instance.GetRoleDataById(curSelectRoleId, true);
	}

	// Token: 0x17001B5A RID: 7002
	// (get) Token: 0x06014D4A RID: 85322 RVA: 0x005C4FD0 File Offset: 0x005C31D0
	// (set) Token: 0x06014D4B RID: 85323 RVA: 0x005C4FD8 File Offset: 0x005C31D8
	public ERoleViewState RoleViewState
	{
		get
		{
			return this.RoleViewStateInternal;
		}
		set
		{
			this.RoleViewStateInternal = value;
		}
	}

	// Token: 0x06014D4C RID: 85324 RVA: 0x005C4FE4 File Offset: 0x005C31E4
	public virtual ERoleSystemMode GetRoleSystemMode()
	{
		RoleDataBase curSelectRoleData = this.GetCurSelectRoleData();
		if (!curSelectRoleData.IsTrialRole())
		{
			return ERoleSystemMode.Normal;
		}
		if (!RoleUtils.IsSpecialTrialRole(curSelectRoleData.GetDataId()))
		{
			return ERoleSystemMode.Trial;
		}
		return ERoleSystemMode.SpecialTrial;
	}

	// Token: 0x06014D4D RID: 85325 RVA: 0x005C5014 File Offset: 0x005C3214
	public IRoleSystemUiParams GetRoleSystemUiParams()
	{
		ERoleSystemMode roleSystemMode = this.GetRoleSystemMode();
		return RoleUiDefine.roleSystemModeUiParam[roleSystemMode];
	}

	// Token: 0x06014D4E RID: 85326 RVA: 0x005C5033 File Offset: 0x005C3233
	public void SetCurSelectTabName(EUiTabViewName tabName)
	{
		this.CurSelectTabName = new EUiTabViewName?(tabName);
	}

	// Token: 0x06014D4F RID: 85327 RVA: 0x005C5041 File Offset: 0x005C3241
	public EUiTabViewName? GetCurSelectTabName()
	{
		return this.CurSelectTabName;
	}

	// Token: 0x06014D50 RID: 85328 RVA: 0x005C5049 File Offset: 0x005C3249
	public void SetPreSelectTabName(EUiTabViewName? tabName)
	{
		this.PreSelectTabName = tabName;
	}

	// Token: 0x06014D51 RID: 85329 RVA: 0x005C5052 File Offset: 0x005C3252
	public EUiTabViewName? GetPreSelectTabName()
	{
		return this.PreSelectTabName;
	}

	// Token: 0x06014D52 RID: 85330 RVA: 0x005C505C File Offset: 0x005C325C
	public List<UiDynamicTab> GetRoleTabDataList()
	{
		ERoleSystemMode roleSystemMode = this.GetRoleSystemMode();
		return new List<UiDynamicTab>(ModelBase<RoleModel>.Instance.GetRoleTabListByUiParam(roleSystemMode));
	}

	// Token: 0x06014D53 RID: 85331 RVA: 0x005C5080 File Offset: 0x005C3280
	public int GetCurRoleResonanceGroupIndex()
	{
		RoleDataBase curSelectRoleData = this.GetCurSelectRoleData();
		return ModelBase<RoleModel>.Instance.GetRoleResonanceGroupIndex(curSelectRoleData);
	}

	// Token: 0x06014D54 RID: 85332 RVA: 0x005C50A0 File Offset: 0x005C32A0
	[NullableContext(2)]
	public List<ResonantChain> GetCurRoleResonanceConfigList()
	{
		RoleDataBase curSelectRoleData = this.GetCurSelectRoleData();
		return ModelBase<RoleModel>.Instance.GetRoleResonanceConfigList(curSelectRoleData);
	}

	// Token: 0x0400A040 RID: 41024
	protected List<int> RoleIdList;

	// Token: 0x0400A041 RID: 41025
	protected EUiTabViewName? CurSelectTabName;

	// Token: 0x0400A042 RID: 41026
	protected int CurSelectRoleId;

	// Token: 0x0400A043 RID: 41027
	protected ERoleViewState RoleViewStateInternal;

	// Token: 0x0400A044 RID: 41028
	public ETeamPositionType? TeamPositionType;

	// Token: 0x0400A045 RID: 41029
	protected EUiTabViewName? PreSelectTabName;

	// Token: 0x0400A046 RID: 41030
	public ERoleViewSource Source;
}
