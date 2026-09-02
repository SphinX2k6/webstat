using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001B8C RID: 7052
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MapAreaRewardItem : GridProxyAbstract<DailyActivityDefine.IActivityGoalData>
{
	// Token: 0x17001090 RID: 4240
	// (get) Token: 0x0600CCF6 RID: 52470 RVA: 0x00368F1D File Offset: 0x0036711D
	// (set) Token: 0x0600CCF7 RID: 52471 RVA: 0x00368F25 File Offset: 0x00367125
	public EDailyActiveState? DailyActiveState { get; set; }

	// Token: 0x0600CCF8 RID: 52472 RVA: 0x00368F2E File Offset: 0x0036712E
	public MapAreaRewardItem(Action getRewardCallback, Action<RewardPopupData> openRewardCallback)
	{
		this.GetRewardCallback = getRewardCallback;
		this.OpenRewardCallback = openRewardCallback;
	}

	// Token: 0x0600CCF9 RID: 52473 RVA: 0x00368F44 File Offset: 0x00367144
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUINiagara));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUINiagara));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.ClickRewardButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600CCFA RID: 52474 RVA: 0x003690D2 File Offset: 0x003672D2
	protected override void OnStart()
	{
		base.GetUiNiagara(6).SetAlpha(0f);
		base.GetUiNiagara(7).SetUIActive(false);
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600CCFB RID: 52475 RVA: 0x00369103 File Offset: 0x00367303
	protected override void OnBeforeDestroy()
	{
	}

	// Token: 0x0600CCFC RID: 52476 RVA: 0x00369108 File Offset: 0x00367308
	public override void Refresh(DailyActivityDefine.IActivityGoalData data, bool isSelected, int gridIndex)
	{
		this.RewardData = data;
		this.SetRewardGoalValue(data.Goal);
		EDailyActiveState? dailyActiveState = this.DailyActiveState;
		EDailyActiveState state = data.State;
		if (!(dailyActiveState.GetValueOrDefault() == state & dailyActiveState != null))
		{
			this.RefreshRewardState(data.State, this.DailyActiveState == null);
		}
		else if (this.DailyActiveState.GetValueOrDefault() == EDailyActiveState.FinishedAndTaken)
		{
			base.GetUiNiagara(7).SetUIActive(false);
		}
		bool flag = data.State != EDailyActiveState.Unfinished;
		UUIText text = base.GetText(0);
		UUIItem uuiitem = text;
		bool bUseChangeColor = flag;
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
	}

	// Token: 0x0600CCFD RID: 52477 RVA: 0x003691B2 File Offset: 0x003673B2
	public void RefreshSelf()
	{
		this.Refresh(this.RewardData, false, 0);
	}

	// Token: 0x0600CCFE RID: 52478 RVA: 0x003691C2 File Offset: 0x003673C2
	public void SetRewardGoalValue(int value)
	{
		base.GetText(0).SetText(value.ToString(), true);
	}

	// Token: 0x0600CCFF RID: 52479 RVA: 0x003691D8 File Offset: 0x003673D8
	public void RefreshRewardState(EDailyActiveState state, bool isInit)
	{
		List<UUISprite> list = new List<UUISprite>
		{
			base.GetSprite(4),
			base.GetSprite(2),
			base.GetSprite(3)
		};
		for (int i = 0; i < list.Count; i++)
		{
			list[i].SetUIActive(i + EDailyActiveState.FinishedAndNotTaken == state);
		}
		base.GetItem(8).SetUIActive(state == EDailyActiveState.FinishedAndNotTaken);
		base.GetUiNiagara(6).SetAlpha(state == EDailyActiveState.FinishedAndNotTaken);
		if (state == EDailyActiveState.FinishedAndNotTaken && isInit)
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName("Activate", false, null, false);
		}
		FColor color = FColor.FromHex((state == EDailyActiveState.Unfinished) ? "00000033" : "F3EAAB1E");
		base.GetSprite(5).SetColor(color);
		this.DailyActiveState = new EDailyActiveState?(state);
	}

	// Token: 0x0600CD00 RID: 52480 RVA: 0x003692A8 File Offset: 0x003674A8
	private void ClickRewardButton()
	{
		EDailyActiveState? dailyActiveState = this.DailyActiveState;
		if (dailyActiveState != null)
		{
			switch (dailyActiveState.GetValueOrDefault())
			{
			case EDailyActiveState.FinishedAndNotTaken:
			{
				Action getRewardCallback = this.GetRewardCallback;
				if (getRewardCallback == null)
				{
					return;
				}
				getRewardCallback();
				return;
			}
			case EDailyActiveState.Unfinished:
				this.RefreshRewardPopup(false);
				return;
			case EDailyActiveState.FinishedAndTaken:
				this.RefreshRewardPopup(true);
				break;
			default:
				return;
			}
		}
	}

	// Token: 0x0600CD01 RID: 52481 RVA: 0x00369304 File Offset: 0x00367504
	private void RefreshRewardPopup(bool isClaimed)
	{
		List<TItem> rewards = this.RewardData.Rewards;
		List<DailyActivityDefine.RewardTuple> list = new List<DailyActivityDefine.RewardTuple>();
		foreach (TItem titem in rewards)
		{
			DailyActivityDefine.RewardTuple item = new DailyActivityDefine.RewardTuple
			{
				Id = titem.ItemData.ItemId,
				Num = titem.Count,
				Received = isClaimed
			};
			list.Add(item);
		}
		RewardPopupData obj = new RewardPopupData
		{
			RewardLists = list,
			MountItem = base.GetButton(1).RootUIComp,
			PosBias = new FVector?(new FVector(0f, -20f, 0f))
		};
		Action<RewardPopupData> openRewardCallback = this.OpenRewardCallback;
		if (openRewardCallback == null)
		{
			return;
		}
		openRewardCallback(obj);
	}

	// Token: 0x040061F2 RID: 25074
	private DailyActivityDefine.IActivityGoalData RewardData;

	// Token: 0x040061F4 RID: 25076
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040061F5 RID: 25077
	private readonly Action GetRewardCallback;

	// Token: 0x040061F6 RID: 25078
	private readonly Action<RewardPopupData> OpenRewardCallback;

	// Token: 0x02007E70 RID: 32368
	[NullableContext(0)]
	private enum ERewardItemNode
	{
		// Token: 0x0402B119 RID: 176409
		TxtValue,
		// Token: 0x0402B11A RID: 176410
		BtnReward,
		// Token: 0x0402B11B RID: 176411
		SpriteUnfinished,
		// Token: 0x0402B11C RID: 176412
		SpriteClaimed,
		// Token: 0x0402B11D RID: 176413
		SpriteFinished,
		// Token: 0x0402B11E RID: 176414
		SpriteBackground,
		// Token: 0x0402B11F RID: 176415
		NiagaraWait,
		// Token: 0x0402B120 RID: 176416
		NiagaraGet,
		// Token: 0x0402B121 RID: 176417
		RedDot
	}
}
