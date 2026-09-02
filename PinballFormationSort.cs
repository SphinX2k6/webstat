using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x0200193D RID: 6461
public class PinballFormationSort : CommonSort<EPinballFormation>
{
	// Token: 0x0600B997 RID: 47511 RVA: 0x00316B80 File Offset: 0x00314D80
	[NullableContext(1)]
	private int SortQuality(object a, object b, bool isAscending, params object[] parameters)
	{
		int num = (int)a;
		int num2 = (int)b;
		int selectRoleFormationNumber = ModelBase<PinballModel>.Instance.GetSelectRoleFormationNumber(num);
		int selectRoleFormationNumber2 = ModelBase<PinballModel>.Instance.GetSelectRoleFormationNumber(num2);
		bool flag = selectRoleFormationNumber != 0;
		bool flag2 = selectRoleFormationNumber2 != 0;
		if (flag || flag2)
		{
			if (flag != flag2)
			{
				int num3 = (flag > false) ? 1 : 0;
				return ((flag2 > false) ? 1 : 0) - num3;
			}
			return selectRoleFormationNumber - selectRoleFormationNumber2;
		}
		else
		{
			int num4 = (ModelBase<PinballModel>.Instance.IsRecommendRole(num) > false) ? 1 : 0;
			int num5 = (ModelBase<PinballModel>.Instance.IsRecommendRole(num2) > false) ? 1 : 0;
			if (num4 != num5)
			{
				return (num4 - num5) * (isAscending ? 1 : -1);
			}
			int roleId = ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigById(num).Value.RoleId;
			int qualityId = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId).Value.QualityId;
			int roleId2 = ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigById(num2).Value.RoleId;
			int qualityId2 = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId2).Value.QualityId;
			if (qualityId != qualityId2)
			{
				return (qualityId - qualityId2) * (isAscending ? 1 : -1);
			}
			int roleLevel = ModelBase<PinballModel>.Instance.GetRoleLevel(num);
			int roleLevel2 = ModelBase<PinballModel>.Instance.GetRoleLevel(num2);
			if (roleLevel != roleLevel2)
			{
				return (roleLevel2 - roleLevel) * (isAscending ? 1 : -1);
			}
			return (num - num2) * (isAscending ? 1 : -1);
		}
	}

	// Token: 0x0600B998 RID: 47512 RVA: 0x00316CDF File Offset: 0x00314EDF
	protected override void OnInitSortMap()
	{
		this.SortMap[EPinballFormation.Quality] = new TSortResult(this.SortQuality);
	}
}
