using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.RoleUi;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020021F8 RID: 8696
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RoleItem : LoopScrollSmallItemGrid<RoleBrief>
{
	// Token: 0x06010670 RID: 67184 RVA: 0x0047B550 File Offset: 0x00479750
	protected override UniTask OnCreateAsync()
	{
		RoleItem.<OnCreateAsync>d__1 <OnCreateAsync>d__;
		<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnCreateAsync>d__.<>4__this = this;
		<OnCreateAsync>d__.<>1__state = -1;
		<OnCreateAsync>d__.<>t__builder.Start<RoleItem.<OnCreateAsync>d__1>(ref <OnCreateAsync>d__);
		return <OnCreateAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010671 RID: 67185 RVA: 0x0047B594 File Offset: 0x00479794
	protected override void OnRefresh(RoleBrief data, bool isSelected, int gridIndex)
	{
		int roleId = data.RoleId;
		if (roleId > 0)
		{
			UUIItem noneRoleUi = this.NoneRoleUi;
			if (noneRoleUi != null)
			{
				noneRoleUi.SetUIActive(false);
			}
			RoleInfo value = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId).Value;
			CharacterSmallItemGrid parameters = new CharacterSmallItemGrid
			{
				Data = data,
				ElementId = new int?(value.ElementId),
				ItemConfigId = new int?(value.Id),
				QualityId = new int?(value.QualityId)
			};
			base.Apply<CharacterSmallItemGrid>(parameters);
			return;
		}
		base.ApplyEmptyWithoutAddSmallItemGrid(new EmptySmallItemGrid());
		UUIItem noneRoleUi2 = this.NoneRoleUi;
		if (noneRoleUi2 == null)
		{
			return;
		}
		noneRoleUi2.SetUIActive(true);
	}

	// Token: 0x04008152 RID: 33106
	[Nullable(2)]
	private UUIItem NoneRoleUi;
}
