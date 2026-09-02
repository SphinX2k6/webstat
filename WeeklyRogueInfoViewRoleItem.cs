using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002D2E RID: 11566
public class WeeklyRogueInfoViewRoleItem : GridProxyAbstract<int>
{
	// Token: 0x06017589 RID: 95625 RVA: 0x00678F50 File Offset: 0x00677150
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIExtendToggle))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.OnClick))
		};
	}

	// Token: 0x0601758A RID: 95626 RVA: 0x00679010 File Offset: 0x00677210
	public override void Refresh(int roleConfigId, bool isSelected, int gridIndex)
	{
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleConfigId, true);
		if (roleDataById == null)
		{
			return;
		}
		base.SetRoleSkinIcon(roleDataById.GetRoleConfig().RoleHeadIconBig, base.GetTexture(0), roleDataById.GetRoleSkinId(), null, null);
		int qualityId = roleDataById.GetRoleConfig().QualityId;
		UUISprite sprite = base.GetSprite(1);
		UUISprite sprite2 = base.GetSprite(2);
		UUISprite sprite3 = base.GetSprite(3);
		UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 1);
		defaultInterpolatedStringHandler.AppendLiteral("SP_RoleIconBgUnCheckedUnHover");
		defaultInterpolatedStringHandler.AppendFormatted<int>(qualityId);
		string resourcePath = instance.GetResourcePath(defaultInterpolatedStringHandler.ToStringAndClear());
		this.SetSpriteByPath(resourcePath, sprite3, false, null, null);
		UiResourceConfig instance2 = ConfigBase<UiResourceConfig>.Instance;
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 1);
		defaultInterpolatedStringHandler.AppendLiteral("SP_RoleIconBgUnCheckedHover");
		defaultInterpolatedStringHandler.AppendFormatted<int>(qualityId);
		string resourcePath2 = instance2.GetResourcePath(defaultInterpolatedStringHandler.ToStringAndClear());
		this.SetSpriteByPath(resourcePath2, sprite2, false, null, null);
		UiResourceConfig instance3 = ConfigBase<UiResourceConfig>.Instance;
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
		defaultInterpolatedStringHandler.AppendLiteral("SP_RoleIconBgChecked");
		defaultInterpolatedStringHandler.AppendFormatted<int>(qualityId);
		string resourcePath3 = instance3.GetResourcePath(defaultInterpolatedStringHandler.ToStringAndClear());
		this.SetSpriteByPath(resourcePath3, sprite, false, null, null);
		this.RefreshSkillBranch(roleConfigId);
	}

	// Token: 0x0601758B RID: 95627 RVA: 0x0067915E File Offset: 0x0067735E
	private void OnClick(EToggleState toggleState)
	{
		Action<int> onSelectedCallback = this.OnSelectedCallback;
		if (onSelectedCallback == null)
		{
			return;
		}
		onSelectedCallback(base.GridIndex);
	}

	// Token: 0x0601758C RID: 95628 RVA: 0x00679176 File Offset: 0x00677376
	public override void OnSelected(bool fireEvent)
	{
		base.GetExtendToggle(5).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		if (fireEvent)
		{
			Action<int> onSelectedCallback = this.OnSelectedCallback;
			if (onSelectedCallback == null)
			{
				return;
			}
			onSelectedCallback(base.GridIndex);
		}
	}

	// Token: 0x0601758D RID: 95629 RVA: 0x006791A2 File Offset: 0x006773A2
	public override void OnDeselected(bool fireEvent)
	{
		base.GetExtendToggle(5).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0601758E RID: 95630 RVA: 0x006791B8 File Offset: 0x006773B8
	public void RefreshSkillBranch(int roleId)
	{
		UUIItem item = base.GetItem(4);
		int roleCurrentBranchIndex = ModelBase<RoleModel>.Instance.GetRoleCurrentBranchIndex(roleId);
		if (roleCurrentBranchIndex < 0)
		{
			item.SetUIActive(false);
			return;
		}
		item.SetUIActive(true);
		int num = roleCurrentBranchIndex * 180;
		FVector fvector = new FVector(0f, 0f, (float)num);
		FRotator frotator = FRotator.MakeFromEuler(fvector);
		item.SetUIRelativeRotation(frotator);
	}

	// Token: 0x0400B34A RID: 45898
	[Nullable(2)]
	public Action<int> OnSelectedCallback;

	// Token: 0x02008FF3 RID: 36851
	private enum EWeeklyRogueInfoViewRoleItemDefine
	{
		// Token: 0x040304CE RID: 197838
		TextureIcon,
		// Token: 0x040304CF RID: 197839
		SpriteSelect,
		// Token: 0x040304D0 RID: 197840
		SpriteHover,
		// Token: 0x040304D1 RID: 197841
		SpriteNormal,
		// Token: 0x040304D2 RID: 197842
		ItemSkillBranch,
		// Token: 0x040304D3 RID: 197843
		ExtendToggle
	}
}
