using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020024D7 RID: 9431
public class PhantomInteractListItemSkillTagPanel : UiPanelBase
{
	// Token: 0x060124EB RID: 74987 RVA: 0x005087BE File Offset: 0x005069BE
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite))
		};
	}

	// Token: 0x060124EC RID: 74988 RVA: 0x005087E4 File Offset: 0x005069E4
	public void Refresh(EMediumItemGridPhantomSpecialSkill specialSkill)
	{
		bool flag = specialSkill > EMediumItemGridPhantomSpecialSkill.Hide;
		UUIItem rootItem = this.RootItem;
		if (rootItem != null)
		{
			rootItem.SetUIActive(flag);
		}
		if (flag)
		{
			string path;
			if (specialSkill == EMediumItemGridPhantomSpecialSkill.ShowAvailable)
			{
				path = "/Game/Aki/UI/UIResources/Common/Atlas/SP_ItemVision.SP_ItemVision";
			}
			else
			{
				path = "/Game/Aki/UI/UIResources/Common/Atlas/SP_ItemVisionB.SP_ItemVisionB";
			}
			UUISprite sprite = base.GetSprite(0);
			this.SetSpriteByPath(path, sprite, false, null, null);
		}
	}

	// Token: 0x020087E4 RID: 34788
	private enum EComponent
	{
		// Token: 0x0402DE97 RID: 188055
		SpriteTag
	}
}
