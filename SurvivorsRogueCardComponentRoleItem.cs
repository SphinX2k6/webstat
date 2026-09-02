using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002AD5 RID: 10965
[NullableContext(2)]
[Nullable(0)]
public class SurvivorsRogueCardComponentRoleItem : SurvivorsRogueCardComponent
{
	// Token: 0x06015EBD RID: 89789 RVA: 0x00616D7B File Offset: 0x00614F7B
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06015EBE RID: 89790 RVA: 0x00616DB4 File Offset: 0x00614FB4
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsRogueCardComponentRoleItem.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsRogueCardComponentRoleItem.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015EBF RID: 89791 RVA: 0x00616DF7 File Offset: 0x00614FF7
	protected override string OnGetResourceId()
	{
		return "UiItem_SurvivorsCardRole";
	}

	// Token: 0x06015EC0 RID: 89792 RVA: 0x00616DFE File Offset: 0x00614FFE
	public override ECardMountPos GetLayoutLevel()
	{
		return ECardMountPos.Center;
	}

	// Token: 0x06015EC1 RID: 89793 RVA: 0x00616E04 File Offset: 0x00615004
	protected override void OnRefresh([Nullable(new byte[]
	{
		1,
		2
	})] params object[] params_)
	{
		int roleId = (params_.Length != 0 && params_[0] != null) ? ((int)params_[0]) : 0;
		int? num = (params_.Length > 1 && params_[1] != null) ? ((int?)params_[1]) : null;
		SurvivorsRole? survivorsRole = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsRole(roleId);
		if (survivorsRole == null)
		{
			this.SetActive(false);
			return;
		}
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(survivorsRole.Value.TrialRoleId, true);
		RoleInfo? roleInfo = (roleDataById != null) ? new RoleInfo?(roleDataById.GetRoleConfig()) : null;
		if (roleInfo == null)
		{
			this.SetActive(false);
			return;
		}
		base.SetRoleIcon(roleInfo.Value.RoleHeadIconCircle, base.GetTexture(0), roleId, null, null);
		base.GetTexture(0).SetUIActive(true);
		if (num != null)
		{
			SurvivorsProperty? propertyConfig = ConfigBase<SurvivorsRogueConfig>.Instance.GetPropertyConfig(num.Value);
			this.AttributeItem.SetTextureIcon((propertyConfig != null) ? propertyConfig.GetValueOrDefault().Icon : null);
		}
		this.AttributeItem.SetActive(num != null);
		this.SetActive(true);
	}

	// Token: 0x0400A873 RID: 43123
	private SurvivorsRogueCardAttributeItem AttributeItem;
}
