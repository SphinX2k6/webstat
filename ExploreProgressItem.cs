using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001B8A RID: 7050
public class ExploreProgressItem : UiPanelBase
{
	// Token: 0x0600CCE9 RID: 52457 RVA: 0x00368890 File Offset: 0x00366A90
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnMissionButtonClicked));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnTipsButtonClicked));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600CCEA RID: 52458 RVA: 0x00368A1F File Offset: 0x00366C1F
	private void OnMissionButtonClicked()
	{
		if (this.ExploreAreaItemData == null)
		{
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ExploreMissionView, this.ExploreAreaItemData.AreaId, null);
	}

	// Token: 0x0600CCEB RID: 52459 RVA: 0x00368A4C File Offset: 0x00366C4C
	private void OnTipsButtonClicked()
	{
		ExploreAreaItemData exploreAreaItemData = this.ExploreAreaItemData;
		int? num = (exploreAreaItemData != null) ? exploreAreaItemData.GetPhantomSkillHelpId() : null;
		if (num == null)
		{
			return;
		}
		ControllerBase<HelpController>.Instance.OpenHelpById(num.Value);
	}

	// Token: 0x0600CCEC RID: 52460 RVA: 0x00368A90 File Offset: 0x00366C90
	[NullableContext(1)]
	public void Refresh(ExploreAreaItemData data)
	{
		this.ExploreAreaItemData = data;
		float num = (float)data.GetProgress();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.GetNameId(), Array.Empty<object>());
		base.GetSprite(2).SetFillAmount(num / 100f);
		if (data.IsPercent())
		{
			UUIText text = base.GetText(1);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendFormatted<double>(Math.Floor((double)num));
			defaultInterpolatedStringHandler.AppendLiteral("%");
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		else
		{
			UUIText text2 = base.GetText(1);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.GetCurrentCount());
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.GetTotalCount());
			text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		base.GetItem(3).SetUIActive(data.ExploreType == EExploreType.AreaMission);
		if (data.IsCompleted())
		{
			base.GetItem(5).SetUIActive(false);
			return;
		}
		bool uiactive = data.HasPhantomSkill();
		base.GetItem(5).SetUIActive(uiactive);
		UUIText text3 = base.GetText(7);
		string text4;
		if (data.GetIsPhantomSkillUnlock())
		{
			UUIItem uuiitem = text3;
			bool bUseChangeColor = false;
			FColor? fcolor = null;
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			text4 = data.GetUnlockTextId();
		}
		else
		{
			UUIItem uuiitem2 = text3;
			bool bUseChangeColor2 = true;
			FColor? fcolor = new FColor?(text3.changeColor);
			uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
			text4 = data.GetLockTextId();
		}
		if (!string.IsNullOrEmpty(text4))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text3, text4, Array.Empty<object>());
		}
	}

	// Token: 0x040061ED RID: 25069
	[Nullable(2)]
	private ExploreAreaItemData ExploreAreaItemData;

	// Token: 0x02007E6E RID: 32366
	private enum EChildType
	{
		// Token: 0x0402B109 RID: 176393
		NameText,
		// Token: 0x0402B10A RID: 176394
		ProgressText,
		// Token: 0x0402B10B RID: 176395
		ProgressBarSprite,
		// Token: 0x0402B10C RID: 176396
		MissionButtonItem,
		// Token: 0x0402B10D RID: 176397
		MissionButton,
		// Token: 0x0402B10E RID: 176398
		TipsItem,
		// Token: 0x0402B10F RID: 176399
		TipsButton,
		// Token: 0x0402B110 RID: 176400
		TipsText
	}
}
