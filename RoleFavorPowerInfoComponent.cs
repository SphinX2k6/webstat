using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x02002879 RID: 10361
public class RoleFavorPowerInfoComponent : RoleFavorViewComponentBase
{
	// Token: 0x06014836 RID: 84022 RVA: 0x005B11E4 File Offset: 0x005AF3E4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUINiagara)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText))
		};
	}

	// Token: 0x06014837 RID: 84023 RVA: 0x005B1280 File Offset: 0x005AF480
	[NullableContext(1)]
	protected override void OnSetData(RoleFavorContentDataBase contentData)
	{
		if (contentData.FavorContentType != EFavorContentType.ExperienceFile)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "不支持的好感度类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("favorTabType", contentData.FavorContentType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.FavorRoleInfoConfig = new FavorRoleInfo?(((RoleFavorRoleInfoContentData)contentData).ConfigData);
	}

	// Token: 0x06014838 RID: 84024 RVA: 0x005B12E0 File Offset: 0x005AF4E0
	protected override void OnRefreshView()
	{
		if (this.FavorRoleInfoConfig == null)
		{
			return;
		}
		UUIText text = base.GetText(0);
		Singleton<LguiUtil>.Instance.SetLocalText(text, "FavorPowerFile", Array.Empty<object>());
		UUIText text2 = base.GetText(3);
		if (text2 != null)
		{
			text2.ShowTextNew(this.FavorRoleInfoConfig.Value.TalentName);
		}
		UUIText text3 = base.GetText(4);
		if (text3 != null)
		{
			text3.ShowTextNew(this.FavorRoleInfoConfig.Value.TalentDoc);
		}
		UUIText text4 = base.GetText(5);
		if (text4 == null)
		{
			return;
		}
		text4.ShowTextNew(this.FavorRoleInfoConfig.Value.TalentCertification);
	}

	// Token: 0x06014839 RID: 84025 RVA: 0x005B1388 File Offset: 0x005AF588
	protected override void OnStart()
	{
		UUIText text = base.GetText(3);
		if (!ControllerBase<TermExplanationController>.Instance.IsUiTextRegistered(text))
		{
			ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlink(text, ETermExplanationViewType.Side, ETermExplanationReportType.RoleInfo, ETermExplanationViewAttachDirection.Left, null, null, null, ETermExplanationGroup.Default, 0, ETermExplanationViewStyle.Default);
		}
		UUIText text2 = base.GetText(4);
		if (!ControllerBase<TermExplanationController>.Instance.IsUiTextRegistered(text2))
		{
			ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlink(text2, ETermExplanationViewType.Side, ETermExplanationReportType.RoleInfo, ETermExplanationViewAttachDirection.Left, null, null, null, ETermExplanationGroup.Default, 0, ETermExplanationViewStyle.Default);
		}
		UUIText text3 = base.GetText(5);
		if (!ControllerBase<TermExplanationController>.Instance.IsUiTextRegistered(text3))
		{
			ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlink(text3, ETermExplanationViewType.Side, ETermExplanationReportType.RoleInfo, ETermExplanationViewAttachDirection.Left, null, null, null, ETermExplanationGroup.Default, 0, ETermExplanationViewStyle.Default);
		}
	}

	// Token: 0x0601483A RID: 84026 RVA: 0x005B142C File Offset: 0x005AF62C
	protected override void OnBeforeDestroy()
	{
		this.FavorRoleInfoConfig = null;
		UUIText text = base.GetText(3);
		if (ControllerBase<TermExplanationController>.Instance.IsUiTextRegistered(text))
		{
			ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(text);
		}
		UUIText text2 = base.GetText(4);
		if (ControllerBase<TermExplanationController>.Instance.IsUiTextRegistered(text2))
		{
			ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(text2);
		}
		UUIText text3 = base.GetText(5);
		if (ControllerBase<TermExplanationController>.Instance.IsUiTextRegistered(text3))
		{
			ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(text3);
		}
	}

	// Token: 0x04009EA4 RID: 40612
	private FavorRoleInfo? FavorRoleInfoConfig;
}
