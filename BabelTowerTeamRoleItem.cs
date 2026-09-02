using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001248 RID: 4680
public class BabelTowerTeamRoleItem : GridProxyAbstract<int>
{
	// Token: 0x06007CC4 RID: 31940 RVA: 0x0020D7F8 File Offset: 0x0020B9F8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06007CC5 RID: 31941 RVA: 0x0020D8A4 File Offset: 0x0020BAA4
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.RoleId = data;
		if (data == 0)
		{
			base.GetTexture(2).SetUIActive(false);
			base.GetSprite(3).SetUIActive(false);
			return;
		}
		RoleModel instance = ModelBase<RoleModel>.Instance;
		RoleDataBase roleDataBase = (instance != null) ? instance.GetRoleDataById(data, true) : null;
		if (roleDataBase != null)
		{
			int roleSkinId = roleDataBase.GetRoleSkinId();
			string roleHeadIconCircle;
			if (roleSkinId > 0)
			{
				roleHeadIconCircle = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(roleSkinId).Value.RoleHeadIconCircle;
			}
			else
			{
				roleHeadIconCircle = roleDataBase.GetRoleConfig().RoleHeadIconCircle;
			}
			base.SetTextureShowUntilLoaded(roleHeadIconCircle, base.GetTexture(2), null);
		}
		this.RefreshSkillBranchIcon();
	}

	// Token: 0x06007CC6 RID: 31942 RVA: 0x0020D93C File Offset: 0x0020BB3C
	public void RefreshSkillBranchIcon()
	{
		int roleSkillBranchIndexInCurrentGamePlay = ModelBase<RoleModel>.Instance.GetRoleSkillBranchIndexInCurrentGamePlay(this.RoleId);
		bool flag = roleSkillBranchIndexInCurrentGamePlay > -1;
		base.GetSprite(3).SetUIActive(flag);
		if (!flag)
		{
			return;
		}
		bool flag2 = roleSkillBranchIndexInCurrentGamePlay == 0;
		FVector fvector = new FVector(0f, (float)(flag2 ? 0 : 180), 0f);
		FRotator frotator = FRotator.MakeFromEuler(fvector);
		base.GetSprite(3).SetUIRelativeRotation(frotator);
	}

	// Token: 0x04003BAD RID: 15277
	private int RoleId;

	// Token: 0x020075C1 RID: 30145
	private class EComponentDefine
	{
		// Token: 0x040289FB RID: 166395
		public const int Button = 0;

		// Token: 0x040289FC RID: 166396
		public const int BgSprite = 1;

		// Token: 0x040289FD RID: 166397
		public const int RoleTexture = 2;

		// Token: 0x040289FE RID: 166398
		public const int TagSprite = 3;
	}
}
