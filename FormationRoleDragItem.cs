using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02001B57 RID: 6999
public class FormationRoleDragItem : UiPanelBase
{
	// Token: 0x0600CA80 RID: 51840 RVA: 0x0035E5B0 File Offset: 0x0035C7B0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(USpineSkeletonAnimationComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600CA81 RID: 51841 RVA: 0x0035E61C File Offset: 0x0035C81C
	public void RefreshRoleIcon(int configId, int roleSkinId)
	{
		FormationRoleDragItem.<>c__DisplayClass2_0 CS$<>8__locals1 = new FormationRoleDragItem.<>c__DisplayClass2_0();
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(configId);
		RoleSkin? roleSkin = (roleSkinId != 0) ? ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(roleSkinId) : null;
		if (roleConfig == null)
		{
			return;
		}
		CS$<>8__locals1.roleItem = base.GetItem(3);
		CS$<>8__locals1.roleSpine = base.GetSpine(2);
		string atlasPath = (roleSkin != null) ? roleSkin.Value.FormationSpineAtlas : roleConfig.Value.FormationSpineAtlas;
		string skeletonPath = (roleSkin != null) ? roleSkin.Value.FormationSpineSkeletonData : roleConfig.Value.FormationSpineSkeletonData;
		FormationRoleDragItem.<>c__DisplayClass2_0 CS$<>8__locals2 = CS$<>8__locals1;
		float[] param;
		if (roleSkin == null)
		{
			(param = new float[3])[2] = 1f;
		}
		else
		{
			param = roleSkin.Value.SpineParam();
		}
		CS$<>8__locals2.param = param;
		base.SetSpineAssetByPath(atlasPath, skeletonPath, CS$<>8__locals1.roleSpine).ContinueWith(delegate()
		{
			CS$<>8__locals1.roleItem.SetAlpha(1f);
			CS$<>8__locals1.roleSpine.SetAnimation(0, ESpineAnimation.Idle.ToString(), true);
			CS$<>8__locals1.roleItem.SetAnchorOffsetX(CS$<>8__locals1.param[0]);
			CS$<>8__locals1.roleItem.SetAnchorOffsetY(CS$<>8__locals1.param[1]);
			CS$<>8__locals1.roleItem.SetUIItemScale(new FVector(CS$<>8__locals1.param[2], CS$<>8__locals1.param[2], CS$<>8__locals1.param[2]));
		});
	}

	// Token: 0x02007E3C RID: 32316
	private enum EChildType
	{
		// Token: 0x0402AFFE RID: 176126
		RoleIconSpine = 2,
		// Token: 0x0402AFFF RID: 176127
		RoleItem
	}
}
