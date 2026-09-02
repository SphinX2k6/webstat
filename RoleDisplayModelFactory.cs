using System;
using System.Runtime.CompilerServices;

// Token: 0x0200281B RID: 10267
[NullableContext(1)]
[Nullable(0)]
public class RoleDisplayModelFactory : IStaticVariableResetter
{
	// Token: 0x0601446A RID: 83050 RVA: 0x005A54F4 File Offset: 0x005A36F4
	static RoleDisplayModelFactory()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(RoleDisplayModelFactory.CreateStaticDefaultValue), new Action(RoleDisplayModelFactory.ResetStaticDefaultValue));
	}

	// Token: 0x17001A29 RID: 6697
	// (get) Token: 0x0601446B RID: 83051 RVA: 0x005A5513 File Offset: 0x005A3713
	public static RoleDisplayModelFactory Instance
	{
		get
		{
			if (RoleDisplayModelFactory.InstanceInternal == null)
			{
				RoleDisplayModelFactory.InstanceInternal = new RoleDisplayModelFactory();
			}
			return RoleDisplayModelFactory.InstanceInternal;
		}
	}

	// Token: 0x0601446C RID: 83052 RVA: 0x005A552B File Offset: 0x005A372B
	public static void CreateStaticDefaultValue()
	{
		RoleDisplayModelFactory.InstanceInternal = null;
	}

	// Token: 0x0601446D RID: 83053 RVA: 0x005A5533 File Offset: 0x005A3733
	public static void ResetStaticDefaultValue()
	{
		RoleDisplayModelFactory.InstanceInternal = null;
	}

	// Token: 0x0601446E RID: 83054 RVA: 0x005A553C File Offset: 0x005A373C
	public RoleDisplayModelBase BuildRoleDisplayModel(int roleId, bool forceRuntime = false)
	{
		if (RoleDevUtils.GetRoleTypeTagByRoleId(roleId) == ERoleTypeTag.Forecast)
		{
			ForecastRoleDisplayModel forecastRoleDisplayModel = new ForecastRoleDisplayModel();
			forecastRoleDisplayModel.InitByRoleId(roleId);
			return forecastRoleDisplayModel;
		}
		RuntimeRoleDisplayModel runtimeRoleDisplayModel = new RuntimeRoleDisplayModel();
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
		if (roleDataById != null)
		{
			runtimeRoleDisplayModel.InitByRoleData(roleDataById);
		}
		else
		{
			runtimeRoleDisplayModel.InitByRoleId(roleId);
		}
		return runtimeRoleDisplayModel;
	}

	// Token: 0x04009D9D RID: 40349
	[Nullable(2)]
	private static RoleDisplayModelFactory InstanceInternal;
}
