using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002D38 RID: 11576
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WeeklyRogueRolePosItem : GridProxyAbstract<IWeeklyRogueRolePosInfo>
{
	// Token: 0x060175C0 RID: 95680 RVA: 0x00679ECC File Offset: 0x006780CC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnBtnClick))
		};
	}

	// Token: 0x060175C1 RID: 95681 RVA: 0x00679F60 File Offset: 0x00678160
	public override void Refresh(IWeeklyRogueRolePosInfo info, bool isSelected, int gridIndex)
	{
		this.Info = info;
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		if (info.Data == null)
		{
			this.SetRoleShow(false);
			base.GetItem(2).SetUIActive(false);
			return;
		}
		RoleDataBase data = info.Data;
		RoleInfo roleConfig = data.GetRoleConfig();
		int itemId = (data.GetRoleSkinId() > 0) ? data.GetRoleSkinId() : roleConfig.SkinId;
		RoleSkin? roleSkinConfig = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(itemId);
		if (roleSkinConfig == null)
		{
			return;
		}
		base.SetTextureShowUntilLoaded(roleSkinConfig.Value.RoleHeadIconCircle, base.GetTexture(1), null);
		base.GetItem(2).SetUIActive(info.IsRecommend.GetValueOrDefault());
		int roleSkillBranchIndexInCurrentGamePlay = ModelBase<RoleModel>.Instance.GetRoleSkillBranchIndexInCurrentGamePlay(data.GetRoleId());
		UUIItem item2 = base.GetItem(3);
		if (item2 != null)
		{
			item2.SetUIActive(roleSkillBranchIndexInCurrentGamePlay > -1);
		}
		if (roleSkillBranchIndexInCurrentGamePlay > -1)
		{
			this.SetSkillBranchIconToLeft(roleSkillBranchIndexInCurrentGamePlay == 0);
		}
	}

	// Token: 0x060175C2 RID: 95682 RVA: 0x0067A053 File Offset: 0x00678253
	private void SetRoleShow(bool bShow)
	{
		base.GetTexture(1).SetUIActive(bShow);
	}

	// Token: 0x060175C3 RID: 95683 RVA: 0x0067A062 File Offset: 0x00678262
	private void OnBtnClick()
	{
		Action<RoleDataBase> onBtnClickFunc = this.OnBtnClickFunc;
		if (onBtnClickFunc == null)
		{
			return;
		}
		onBtnClickFunc(this.Info.Data);
	}

	// Token: 0x060175C4 RID: 95684 RVA: 0x0067A080 File Offset: 0x00678280
	private void SetSkillBranchIconToLeft(bool isLeft)
	{
		UUIItem item = base.GetItem(3);
		FVector fvector = new FVector(0f, (float)(isLeft ? 0 : 180), 0f);
		FRotator frotator = FRotator.MakeFromEuler(fvector);
		if (item == null)
		{
			return;
		}
		item.SetUIRelativeRotation(frotator);
	}

	// Token: 0x0400B363 RID: 45923
	private IWeeklyRogueRolePosInfo Info;

	// Token: 0x0400B364 RID: 45924
	[Nullable(2)]
	public Action<RoleDataBase> OnBtnClickFunc;

	// Token: 0x02008FFA RID: 36858
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x040304ED RID: 197869
		BtnSelf,
		// Token: 0x040304EE RID: 197870
		TexRole,
		// Token: 0x040304EF RID: 197871
		UpItem,
		// Token: 0x040304F0 RID: 197872
		ItemSkillBranch
	}
}
