using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002B31 RID: 11057
public class SurvivorsRoleTabDetail : UiPanelBase
{
	// Token: 0x060160FA RID: 90362 RVA: 0x0061F3C4 File Offset: 0x0061D5C4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickMoreBtn))
		};
	}

	// Token: 0x060160FB RID: 90363 RVA: 0x0061F470 File Offset: 0x0061D670
	protected override void OnStart()
	{
		this.RoleVisionAttribute = new SurvivorsRoleVisionAttribute(base.GetItem(1));
		this.RoleVisionAttribute.Init();
		TermExplanationRegistryParam param = new TermExplanationRegistryParam
		{
			UiText = base.GetText(3),
			ViewType = ETermExplanationViewType.Center,
			ReportType = ETermExplanationReportType.SurvivorsRogue
		};
		ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
	}

	// Token: 0x060160FC RID: 90364 RVA: 0x0061F4C8 File Offset: 0x0061D6C8
	public void Refresh(int cfgId, bool playGridAnim = false, int showAttrNum = 4)
	{
		SurvivorsRole value = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsRole(cfgId).Value;
		int trialRoleId = value.TrialRoleId;
		this.CurrentRoleId = cfgId;
		IEnumerable<int> recommendPropertyArray = value.GetRecommendPropertyArray();
		int[] propertyListArray = value.GetPropertyListArray();
		List<int> list = new List<int>(recommendPropertyArray);
		if (list.Count > showAttrNum)
		{
			list = list.GetRange(0, showAttrNum);
		}
		if (list.Count < showAttrNum)
		{
			foreach (int item in propertyListArray)
			{
				if (!list.Contains(item))
				{
					list.Add(item);
					if (list.Count == showAttrNum)
					{
						break;
					}
				}
			}
		}
		List<ISurvivorsAttributeUiData> roleDefaultAttributeList = ModelBase<SurvivorsRogueModel>.Instance.GetRoleDefaultAttributeList(cfgId, list);
		SurvivorsRoleVisionAttribute roleVisionAttribute = this.RoleVisionAttribute;
		if (roleVisionAttribute != null)
		{
			roleVisionAttribute.Refresh(roleDefaultAttributeList, playGridAnim);
		}
		SurvivorsRoleEvolve value2 = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsRoleDefaultEvolve(cfgId).Value;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), value2.Describe, Array.Empty<object>());
		RoleInfo value3 = ConfigBase<RoleConfig>.Instance.GetRoleConfig(trialRoleId).Value;
		UUIText text = base.GetText(0);
		if (text == null)
		{
			return;
		}
		text.ShowTextNew(value3.Name);
	}

	// Token: 0x060160FD RID: 90365 RVA: 0x0061F5DF File Offset: 0x0061D7DF
	public void RefreshFourAttr(int cfgId, bool playGridAnim = false)
	{
		this.Refresh(cfgId, playGridAnim, 4);
	}

	// Token: 0x060160FE RID: 90366 RVA: 0x0061F5EC File Offset: 0x0061D7EC
	private void OnClickMoreBtn()
	{
		if (this.CurrentRoleId == 0)
		{
			return;
		}
		SurvivorsRole value = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsRole(this.CurrentRoleId).Value;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SurvivorsAttributeDetailView, ModelBase<SurvivorsRogueModel>.Instance.GetRoleDefaultAttributeList(this.CurrentRoleId, value.GetPropertyListArray()), null);
	}

	// Token: 0x0400A9DC RID: 43484
	[Nullable(2)]
	private SurvivorsRoleVisionAttribute RoleVisionAttribute;

	// Token: 0x0400A9DD RID: 43485
	private int CurrentRoleId;

	// Token: 0x0400A9DE RID: 43486
	private const int DEFAULT_SHOW_ATTRIBUTE_NUM = 4;
}
