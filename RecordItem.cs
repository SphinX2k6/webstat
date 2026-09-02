using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020016EF RID: 5871
internal class RecordItem : UiPanelBase
{
	// Token: 0x0600A2DB RID: 41691 RVA: 0x002AFBDC File Offset: 0x002ADDDC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A2DC RID: 41692 RVA: 0x002AFC87 File Offset: 0x002ADE87
	protected override void OnStart()
	{
		this.ScoreItem = new WheelTowerScoreItem(this, base.GetItem(3));
	}

	// Token: 0x0600A2DD RID: 41693 RVA: 0x002AFC9C File Offset: 0x002ADE9C
	public void Refresh(bool isRoundTotal)
	{
		WheelTowerModel instance = ModelBase<WheelTowerModel>.Instance;
		int selectedRound = instance.SelectedRound;
		bool flag = isRoundTotal ? instance.HasChallengeAnyRound(null) : instance.IsRoundChallenged(selectedRound, null);
		UUIHorizontalLayout horizontalLayout = base.GetHorizontalLayout(0);
		if (horizontalLayout != null)
		{
			UUIItem uuiitem = horizontalLayout.RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(flag);
			}
		}
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(!flag);
		}
		if (!flag)
		{
			return;
		}
		int score = isRoundTotal ? instance.GetRoundTotalScore(selectedRound) : instance.GetRoundScore(selectedRound);
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.SetText(score.ToString(), true);
		}
		EScoreLevel scoreLevel = isRoundTotal ? instance.GetTotalScoreLevel(score, null, null) : instance.GetRoundScoreLevel(score);
		WheelTowerScoreItem scoreItem = this.ScoreItem;
		if (scoreItem == null)
		{
			return;
		}
		scoreItem.Refresh(scoreLevel);
	}

	// Token: 0x04004D4E RID: 19790
	[Nullable(2)]
	private WheelTowerScoreItem ScoreItem;
}
