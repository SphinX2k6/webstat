using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200163C RID: 5692
public class WheelTowerBossHandBookButtonItem : UiPanelBase
{
	// Token: 0x0600A02E RID: 41006 RVA: 0x0029E40C File Offset: 0x0029C60C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBossHandBookBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A02F RID: 41007 RVA: 0x0029E4B4 File Offset: 0x0029C6B4
	public void RefreshRedDot()
	{
		bool uiactive = ModelBase<WheelTowerModel>.Instance.ActivityData.HasBossHandBookRedDot();
		UUISprite sprite = base.GetSprite(1);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(uiactive);
	}

	// Token: 0x0600A030 RID: 41008 RVA: 0x0029E4E3 File Offset: 0x0029C6E3
	public void SetJumpInfo(int waveId, int teamRound, bool isEndless)
	{
		this.JumpWaveConfigId = waveId;
		this.JumpTeamRound = teamRound;
		this.JumpEndless = isEndless;
	}

	// Token: 0x0600A031 RID: 41009 RVA: 0x0029E4FC File Offset: 0x0029C6FC
	private void OnBossHandBookBtnClick()
	{
		NewTowerWave? waveConfigById = ConfigBase<WheelTowerConfig>.Instance.GetWaveConfigById(this.JumpWaveConfigId);
		if (waveConfigById == null)
		{
			return;
		}
		WheelTowerBossHandBookViewData param = new WheelTowerBossHandBookViewData
		{
			IsEndless = this.JumpEndless,
			BossId = waveConfigById.Value.MonsterId,
			BossRound = waveConfigById.Value.Round,
			TeamRound = (this.JumpEndless ? this.JumpTeamRound : 0)
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerBossHandBookView, param, null);
		ModelBase<WheelTowerModel>.Instance.ActivityData.RecordOpenBossHandBook();
		this.RefreshRedDot();
	}

	// Token: 0x040049A9 RID: 18857
	private int JumpWaveConfigId;

	// Token: 0x040049AA RID: 18858
	private int JumpTeamRound;

	// Token: 0x040049AB RID: 18859
	private bool JumpEndless;
}
