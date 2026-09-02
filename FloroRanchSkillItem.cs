using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001C6B RID: 7275
public class FloroRanchSkillItem : UiPanelBase
{
	// Token: 0x0600D45A RID: 54362 RVA: 0x0038A838 File Offset: 0x00388A38
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D45B RID: 54363 RVA: 0x0038A964 File Offset: 0x00388B64
	public void Refresh(int skillId)
	{
		UUITexture texture = base.GetTexture(0);
		if (texture != null)
		{
			texture.SetUIActive(skillId != 0);
		}
		UUISprite sprite = base.GetSprite(1);
		if (sprite != null)
		{
			sprite.SetUIActive(skillId != 0);
		}
		UUISprite sprite2 = base.GetSprite(3);
		if (sprite2 != null)
		{
			sprite2.SetUIActive(skillId == 0);
		}
		this.RefreshRedDot();
		if (skillId == 0)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "FloroRanchSelectSkill", Array.Empty<object>());
			return;
		}
		FloroRanchSkillData floroRanchSkillData = ModelBase<FloroRanchModel>.Instance.GetFloroRanchSkillData(skillId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), floroRanchSkillData.Name, Array.Empty<object>());
		base.SetTextureByPath(floroRanchSkillData.Icon, base.GetTexture(0), null, null);
	}

	// Token: 0x0600D45C RID: 54364 RVA: 0x0038AA20 File Offset: 0x00388C20
	public void RefreshRedDot()
	{
		bool uiactive = ModelBase<FloroRanchModel>.Instance.GetActivityData(this.ActivityDataType, true).IsSkillHasRedDot();
		UUIItem item = base.GetItem(5);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(uiactive);
	}

	// Token: 0x0600D45D RID: 54365 RVA: 0x0038AA58 File Offset: 0x00388C58
	private void OnButtonClick()
	{
		if (ModelBase<FloroRanchModel>.Instance.GetActivityData(this.ActivityDataType, true).HasUnFinishedSubIns())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Farm_SkillBlock", Array.Empty<object>());
			return;
		}
		FloroRanchSkillViewParam floroRanchSkillViewParam = new FloroRanchSkillViewParam
		{
			CanSelect = true,
			ActivityDataType = this.ActivityDataType
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FloroRanchSkillView, floroRanchSkillViewParam, null);
	}

	// Token: 0x0400650B RID: 25867
	public EFloroRanchActivityDataType ActivityDataType;

	// Token: 0x02007F93 RID: 32659
	private class EComponentDefine
	{
		// Token: 0x0402B6F1 RID: 177905
		public const int TextureIcon = 0;

		// Token: 0x0402B6F2 RID: 177906
		public const int SpriteSwitch = 1;

		// Token: 0x0402B6F3 RID: 177907
		public const int TextName = 2;

		// Token: 0x0402B6F4 RID: 177908
		public const int SpriteAdd = 3;

		// Token: 0x0402B6F5 RID: 177909
		public const int Button = 4;

		// Token: 0x0402B6F6 RID: 177910
		public const int ItemRedDot = 5;
	}
}
