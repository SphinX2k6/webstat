using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001632 RID: 5682
public class WheelTowerCoverRecordResetScoreItem : UiPanelBase
{
	// Token: 0x0600A012 RID: 40978 RVA: 0x0029DAFC File Offset: 0x0029BCFC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A013 RID: 40979 RVA: 0x0029DBC8 File Offset: 0x0029BDC8
	[NullableContext(1)]
	public void Refresh(IWheelTowerCoverRecordData oldData, IWheelTowerCoverRecordData newData)
	{
		int totalScore = oldData.TotalScore;
		int totalScore2 = newData.TotalScore;
		EScoreLevel totalScoreLevel = ModelBase<WheelTowerModel>.Instance.GetTotalScoreLevel(totalScore, null, null);
		EScoreLevel totalScoreLevel2 = ModelBase<WheelTowerModel>.Instance.GetTotalScoreLevel(totalScore2, null, null);
		NewTowerScoreLevel? scoreLevelConfigById = ConfigBase<WheelTowerConfig>.Instance.GetScoreLevelConfigById((int)totalScoreLevel);
		NewTowerScoreLevel? scoreLevelConfigById2 = ConfigBase<WheelTowerConfig>.Instance.GetScoreLevelConfigById((int)totalScoreLevel2);
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.SetText(totalScore.ToString(), true);
		}
		UUIText text2 = base.GetText(3);
		if (text2 != null)
		{
			text2.SetText(totalScore2.ToString(), true);
		}
		if (scoreLevelConfigById != null)
		{
			base.SetTextureByPath(scoreLevelConfigById.Value.IconSettlement, base.GetTexture(2), null, null);
		}
		if (scoreLevelConfigById2 != null)
		{
			base.SetTextureByPath(scoreLevelConfigById2.Value.IconSettlement, base.GetTexture(4), null, null);
		}
	}
}
