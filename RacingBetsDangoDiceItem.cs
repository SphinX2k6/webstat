using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RacingBets;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002719 RID: 10009
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RacingBetsDangoDiceItem : GridProxyAbstract<DangoIdToDiceNum>
{
	// Token: 0x06013BE4 RID: 80868 RVA: 0x0057EAC0 File Offset: 0x0057CCC0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x06013BE5 RID: 80869 RVA: 0x0057EB46 File Offset: 0x0057CD46
	protected override void OnBeforeCreateImplement()
	{
		this.UiLevelSequence = new UiBehaviorLevelSequence(this);
		base.AddUiBehavior(this.UiLevelSequence);
	}

	// Token: 0x06013BE6 RID: 80870 RVA: 0x0057EB60 File Offset: 0x0057CD60
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRacingBetsDangoRoundStart, new Action<int>(this.OnRacingBetsDangoRoundStart));
		Singleton<EventSystem>.Instance.Add<int, IReadOnlyList<DangoIdToDiceNum>, CustomPromise>(EEventName.OnRacingBetsDangoOrderRefresh, new Action<int, IReadOnlyList<DangoIdToDiceNum>, CustomPromise>(this.OnRacingBetsDangoOrderRefresh));
	}

	// Token: 0x06013BE7 RID: 80871 RVA: 0x0057EB9C File Offset: 0x0057CD9C
	public override void Refresh(DangoIdToDiceNum diceInfo, bool isSelected, int gridIndex)
	{
		this.DiceInfo = diceInfo;
		DangoData dangoData = Singleton<DangoManager>.Instance.GetDangoData(diceInfo.DangoId);
		base.SetTextureShowUntilLoaded(dangoData.DangoConfig.Value.IconSmall, base.GetTexture(3), null);
		RacingBetsDungeonDangoInfo dungeonDangoInfo = ModelBase<RacingBetsModel>.Instance.GetDungeonDangoInfo(diceInfo.DangoId);
		if (dungeonDangoInfo == null)
		{
			return;
		}
		string diceIcon = dungeonDangoInfo.GetDiceIcon(diceInfo.Num);
		Dice? diceConfig = dungeonDangoInfo.GetDiceConfig();
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		base.SetTextureShowUntilLoaded(diceIcon, base.GetTexture(1), null);
		if (diceConfig != null)
		{
			base.SetTextureShowUntilLoaded(diceConfig.Value.DiceBackgroundIcon, base.GetTexture(0), null);
		}
	}

	// Token: 0x06013BE8 RID: 80872 RVA: 0x0057EC55 File Offset: 0x0057CE55
	protected override void OnAfterHide()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRacingBetsDangoRoundStart, new Action<int>(this.OnRacingBetsDangoRoundStart));
		Singleton<EventSystem>.Instance.Remove<int, IReadOnlyList<DangoIdToDiceNum>, CustomPromise>(EEventName.OnRacingBetsDangoOrderRefresh, new Action<int, IReadOnlyList<DangoIdToDiceNum>, CustomPromise>(this.OnRacingBetsDangoOrderRefresh));
	}

	// Token: 0x06013BE9 RID: 80873 RVA: 0x0057EC90 File Offset: 0x0057CE90
	private void OnRacingBetsDangoRoundStart(int dangoId)
	{
		if (this.DiceInfo.DangoId == dangoId)
		{
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UiBehaviorLevelSequence uiLevelSequence = this.UiLevelSequence;
			if (uiLevelSequence == null)
			{
				return;
			}
			uiLevelSequence.PlaySequence("Select", false, null);
			return;
		}
		else
		{
			UUIItem item2 = base.GetItem(4);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UiBehaviorLevelSequence uiLevelSequence2 = this.UiLevelSequence;
			if (uiLevelSequence2 == null)
			{
				return;
			}
			uiLevelSequence2.StopPrevSequence(false, true);
			return;
		}
	}

	// Token: 0x06013BEA RID: 80874 RVA: 0x0057ED03 File Offset: 0x0057CF03
	private void OnRacingBetsDangoOrderRefresh(int _1, IReadOnlyList<DangoIdToDiceNum> _2, CustomPromise _3)
	{
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UiBehaviorLevelSequence uiLevelSequence = this.UiLevelSequence;
		if (uiLevelSequence == null)
		{
			return;
		}
		uiLevelSequence.StopPrevSequence(false, true);
	}

	// Token: 0x040099CA RID: 39370
	private DangoIdToDiceNum DiceInfo;

	// Token: 0x040099CB RID: 39371
	[Nullable(2)]
	public UiBehaviorLevelSequence UiLevelSequence;

	// Token: 0x02008AB9 RID: 35513
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402EC65 RID: 191589
		DiceTexture,
		// Token: 0x0402EC66 RID: 191590
		DiceNumTexture,
		// Token: 0x0402EC67 RID: 191591
		DangoBgTexture,
		// Token: 0x0402EC68 RID: 191592
		DangoTexture,
		// Token: 0x0402EC69 RID: 191593
		ArrowItem
	}
}
