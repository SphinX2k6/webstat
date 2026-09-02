using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001471 RID: 5233
public class ActivityNewPlayerSupportRewardRoleItem : GridProxyAbstract<int>
{
	// Token: 0x06009267 RID: 37479 RVA: 0x00269EA7 File Offset: 0x002680A7
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUISprite))
		};
	}

	// Token: 0x06009268 RID: 37480 RVA: 0x00269EE0 File Offset: 0x002680E0
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		TrialRoleConfig instance = ConfigBase<TrialRoleConfig>.Instance;
		TrialRoleInfo? trialRoleInfo = (instance != null) ? instance.GetTrialRoleConfig(data) : null;
		int parentId = trialRoleInfo.Value.ParentId;
		UUITexture texture = base.GetTexture(0);
		string card = ConfigBase<RoleConfig>.Instance.GetRoleConfig(parentId).Value.Card;
		base.SetRoleIcon(card, texture, parentId, null, null);
		string trialRoleLabelIconByType = RoleUtils.GetTrialRoleLabelIconByType((ETrialRoleType)trialRoleInfo.Value.Type);
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(trialRoleLabelIconByType);
		this.SetSpriteByPath(resourcePath, base.GetSprite(1), false, null, null);
	}

	// Token: 0x02007872 RID: 30834
	private static class EComponentType
	{
		// Token: 0x040296CC RID: 169676
		public const int RoleTex = 0;

		// Token: 0x040296CD RID: 169677
		public const int IconSprite = 1;
	}
}
