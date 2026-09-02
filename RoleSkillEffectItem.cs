using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002905 RID: 10501
[NullableContext(1)]
[Nullable(0)]
public class RoleSkillEffectItem : UiPanelBase
{
	// Token: 0x06014DB6 RID: 85430 RVA: 0x005C725E File Offset: 0x005C545E
	public RoleSkillEffectItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x06014DB7 RID: 85431 RVA: 0x005C7274 File Offset: 0x005C5474
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x06014DB8 RID: 85432 RVA: 0x005C72D0 File Offset: 0x005C54D0
	public void UpdateItem(OneSkillEffect currentValue, OneSkillEffect nextValue)
	{
		SkillDescription? roleSkillDescriptionConfigById = ConfigBase<RoleSkillConfig>.Instance.GetRoleSkillDescriptionConfigById(currentValue.Id);
		if (roleSkillDescriptionConfigById == null)
		{
			return;
		}
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(roleSkillDescriptionConfigById.Value.AttributeName, null);
		base.GetText(0).SetText(localTextNew ?? "", true);
		base.GetText(1).SetText(this.GetAttrValueStr(roleSkillDescriptionConfigById.Value, currentValue), true);
		base.GetText(2).SetText(this.GetAttrValueStr(roleSkillDescriptionConfigById.Value, nextValue), true);
	}

	// Token: 0x06014DB9 RID: 85433 RVA: 0x005C735C File Offset: 0x005C555C
	public string GetAttrValueStr(SkillDescription skillDescription, OneSkillEffect value)
	{
		string result;
		if (!string.IsNullOrEmpty(skillDescription.Description))
		{
			string format = ConfigMultiTextLang.GetLocalTextNew(skillDescription.Description, null) ?? "";
			object[] args = value.Desc.ToArray();
			result = string.Format(format, args);
		}
		else
		{
			StringBuilder stringBuilder = new StringBuilder();
			int count = value.Desc.Count;
			for (int i = 0; i < count; i++)
			{
				stringBuilder.Append(value.Desc[i]);
			}
			result = stringBuilder.ToString();
		}
		return result;
	}

	// Token: 0x02008C50 RID: 35920
	[NullableContext(0)]
	private enum ERoleSkillEffectItemDefine
	{
		// Token: 0x0402F423 RID: 193571
		EffectText,
		// Token: 0x0402F424 RID: 193572
		EffectCurrentValue,
		// Token: 0x0402F425 RID: 193573
		EffectNextValue
	}
}
