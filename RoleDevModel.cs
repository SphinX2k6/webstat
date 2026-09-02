using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;
using Google.Protobuf.Collections;

// Token: 0x02002819 RID: 10265
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class RoleDevModel : ModelBase<RoleDevModel>
{
	// Token: 0x17001A25 RID: 6693
	// (get) Token: 0x06014444 RID: 83012 RVA: 0x005A45F5 File Offset: 0x005A27F5
	// (set) Token: 0x06014445 RID: 83013 RVA: 0x005A45FD File Offset: 0x005A27FD
	public string Version
	{
		get
		{
			return this.VersionInternal;
		}
		set
		{
			this.VersionInternal = value;
		}
	}

	// Token: 0x06014446 RID: 83014 RVA: 0x005A4606 File Offset: 0x005A2806
	public RoleDevModel()
	{
		this.HotRoleDataListInternal = new List<RoleDisplayModelBase>();
	}

	// Token: 0x06014447 RID: 83015 RVA: 0x005A4624 File Offset: 0x005A2824
	public void UpdateRoleDevConfig(RoleDevelopConfigs configs)
	{
		RepeatedField<RoleDevPropsConfig> devPropsList = configs.DevPropsList;
		if (devPropsList != null && devPropsList.Count > 0)
		{
			ConfigBase<RoleDevConfig>.Instance.UpdateDevProsListConfig(devPropsList);
		}
		if (configs.DevTargetRole > 0)
		{
			this.DevTargetRoleIdInternal = configs.DevTargetRole;
		}
		RepeatedField<RoleDevPropsProjectConfig> devPropsProjectList = configs.DevPropsProjectList;
		if (devPropsProjectList != null && devPropsProjectList.Count > 0)
		{
			ConfigBase<RoleDevConfig>.Instance.UpdateDevPropsProjectConfig(devPropsProjectList);
		}
		if (!string.IsNullOrEmpty(configs.Version))
		{
			this.Version = configs.Version;
		}
	}

	// Token: 0x06014448 RID: 83016 RVA: 0x005A469B File Offset: 0x005A289B
	public void UpdateDevTargetRoleId(int roleId)
	{
		this.DevTargetRoleIdInternal = roleId;
	}

	// Token: 0x17001A26 RID: 6694
	// (get) Token: 0x06014449 RID: 83017 RVA: 0x005A46A4 File Offset: 0x005A28A4
	public int DevTargetRoleId
	{
		get
		{
			return this.DevTargetRoleIdInternal;
		}
	}

	// Token: 0x0601444A RID: 83018 RVA: 0x005A46AC File Offset: 0x005A28AC
	[NullableContext(2)]
	public IRoleDevProsConfig GetRoleDevPropsConfig(int configId)
	{
		foreach (IRoleDevProsConfig roleDevProsConfig in (ConfigBase<RoleDevConfig>.Instance.GetAllRoleDevProsListConfig() ?? Array.Empty<IRoleDevProsConfig>()))
		{
			if (roleDevProsConfig.Id == configId)
			{
				return roleDevProsConfig;
			}
		}
		return null;
	}

	// Token: 0x17001A27 RID: 6695
	// (get) Token: 0x0601444B RID: 83019 RVA: 0x005A4710 File Offset: 0x005A2910
	public bool IsConfigDataInitialized
	{
		get
		{
			return (ConfigBase<RoleDevConfig>.Instance.GetAllRoleDevProsListConfig() ?? Array.Empty<IRoleDevProsConfig>()).Count > 0;
		}
	}

	// Token: 0x17001A28 RID: 6696
	// (get) Token: 0x0601444C RID: 83020 RVA: 0x005A472D File Offset: 0x005A292D
	public List<RoleDisplayModelBase> HotRoleDataList
	{
		get
		{
			return this.HotRoleDataListInternal;
		}
	}

	// Token: 0x04009D9A RID: 40346
	private readonly List<RoleDisplayModelBase> HotRoleDataListInternal;

	// Token: 0x04009D9B RID: 40347
	private int DevTargetRoleIdInternal;

	// Token: 0x04009D9C RID: 40348
	private string VersionInternal = string.Empty;
}
