using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x02002873 RID: 10355
public class RoleFavorBaseInfoComponent : RoleFavorViewComponentBase
{
	// Token: 0x0601481D RID: 83997 RVA: 0x005B0A80 File Offset: 0x005AEC80
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUINiagara))
		};
	}

	// Token: 0x0601481E RID: 83998 RVA: 0x005B0B48 File Offset: 0x005AED48
	[NullableContext(1)]
	protected override void OnSetData(RoleFavorContentDataBase contentData)
	{
		this.RoleId = new int?(contentData.RoleId);
	}

	// Token: 0x0601481F RID: 83999 RVA: 0x005B0B5C File Offset: 0x005AED5C
	protected override void OnRefreshView()
	{
		if (this.RoleId != null)
		{
			int? roleId = this.RoleId;
			int num = 0;
			if (!(roleId.GetValueOrDefault() == num & roleId != null))
			{
				UUIText text = base.GetText(0);
				FavorRoleInfo? favorRoleInfoConfig = ConfigBase<RoleFavorConfig>.Instance.GetFavorRoleInfoConfig(this.RoleId.Value);
				if (favorRoleInfoConfig == null)
				{
					return;
				}
				Singleton<LguiUtil>.Instance.SetLocalText(text, "FavorBaseInfo", Array.Empty<object>());
				UUIText text2 = base.GetText(2);
				if (text2 != null)
				{
					text2.SetUIActive(false);
				}
				UUIText text3 = base.GetText(3);
				if (text3 != null)
				{
					text3.ShowTextNew(favorRoleInfoConfig.Value.Sex);
				}
				UUIText text4 = base.GetText(4);
				if (text4 != null)
				{
					text4.ShowTextNew(favorRoleInfoConfig.Value.Country);
				}
				UUIText text5 = base.GetText(5);
				if (text5 != null)
				{
					text5.ShowTextNew(favorRoleInfoConfig.Value.Influence);
				}
				UUIText text6 = base.GetText(6);
				if (text6 == null)
				{
					return;
				}
				text6.ShowTextNew(favorRoleInfoConfig.Value.Info);
				return;
			}
		}
	}

	// Token: 0x06014820 RID: 84000 RVA: 0x005B0C6C File Offset: 0x005AEE6C
	protected override void OnStart()
	{
		UUIText text = base.GetText(6);
		if (!ControllerBase<TermExplanationController>.Instance.IsUiTextRegistered(text))
		{
			ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlink(text, ETermExplanationViewType.Side, ETermExplanationReportType.RoleInfo, ETermExplanationViewAttachDirection.Left, null, null, null, ETermExplanationGroup.Default, 0, ETermExplanationViewStyle.Default);
		}
	}

	// Token: 0x06014821 RID: 84001 RVA: 0x005B0CAC File Offset: 0x005AEEAC
	protected override void OnBeforeDestroy()
	{
		this.RoleId = null;
		UUIText text = base.GetText(6);
		if (ControllerBase<TermExplanationController>.Instance.IsUiTextRegistered(text))
		{
			ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(text);
		}
	}

	// Token: 0x04009E8F RID: 40591
	private int? RoleId = new int?(0);
}
