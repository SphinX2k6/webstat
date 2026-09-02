using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F4C RID: 8012
public class HonamiStoryQuestFinishView : UiViewBase
{
	// Token: 0x0600EFE4 RID: 61412 RVA: 0x00418B90 File Offset: 0x00416D90
	[NullableContext(1)]
	public HonamiStoryQuestFinishView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600EFE5 RID: 61413 RVA: 0x00418B9C File Offset: 0x00416D9C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600EFE6 RID: 61414 RVA: 0x00418C05 File Offset: 0x00416E05
	protected override void OnStart()
	{
		this.QuestData = (HonamiStorySubQuestData)this.OpenParam;
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.AddSequenceFinishEvent("Start", delegate(string _)
		{
			TimerSystem.GameplayTimeInstance.Next(delegate(float _)
			{
				base.CloseMe(null);
			}, null, null);
		}, false);
	}

	// Token: 0x0600EFE7 RID: 61415 RVA: 0x00418C3A File Offset: 0x00416E3A
	protected override void OnBeforeShow()
	{
		this.RefreshView();
	}

	// Token: 0x0600EFE8 RID: 61416 RVA: 0x00418C44 File Offset: 0x00416E44
	private void RefreshView()
	{
		HonamiStorySubQuestData questData = this.QuestData;
		if (questData == null)
		{
			return;
		}
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(questData.GetNameKey(), null);
		UUIText text = base.GetText(1);
		string newText;
		if (questData.Config.Value.TaskType != 1)
		{
			if (text != null)
			{
				text.SetRichText(false);
			}
			newText = localTextNew;
		}
		else
		{
			if (text != null)
			{
				text.SetRichText(true);
			}
			newText = StringUtils.Format("<color=#b3dffa>{0}</color>", new string[]
			{
				localTextNew
			});
		}
		if (text != null)
		{
			text.SetText(newText, true);
		}
	}

	// Token: 0x04007356 RID: 29526
	[Nullable(2)]
	private HonamiStorySubQuestData QuestData;

	// Token: 0x020082D3 RID: 33491
	private enum EHonamiStoryQuestComponents
	{
		// Token: 0x0402C5B9 RID: 181689
		TextTitle,
		// Token: 0x0402C5BA RID: 181690
		TextQuestName
	}
}
