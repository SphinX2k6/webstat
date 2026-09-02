using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001426 RID: 5158
[NullableContext(1)]
[Nullable(0)]
public class MowingTowerBuffView : UiViewBase
{
	// Token: 0x06008F7C RID: 36732 RVA: 0x0025AAC1 File Offset: 0x00258CC1
	public MowingTowerBuffView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06008F7D RID: 36733 RVA: 0x0025AAD8 File Offset: 0x00258CD8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickConfirmButton))
		};
	}

	// Token: 0x06008F7E RID: 36734 RVA: 0x0025AB84 File Offset: 0x00258D84
	protected override void OnStart()
	{
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(delegate
		{
			base.CloseMe(null);
		});
		this.CaptionItem.SetTitleByTextIdAndArgNew("MowingTowerBuffViewTitle", Array.Empty<object>());
		this.LoopScrollView = new LoopScrollView<BuffGridItem, BuffGridItemData>(base.GetLoopScrollViewComponent(1), base.GetItem(4).GetOwner() as AUIBaseActor, new Func<BuffGridItem>(this.CreateLoopItem), false);
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x06008F7F RID: 36735 RVA: 0x0025AC10 File Offset: 0x00258E10
	private BuffGridItem CreateLoopItem()
	{
		return new BuffGridItem();
	}

	// Token: 0x06008F80 RID: 36736 RVA: 0x0025AC18 File Offset: 0x00258E18
	private void OnClickConfirmButton()
	{
		List<MowingTowerBuffInfo> list = new List<MowingTowerBuffInfo>();
		int num = 1;
		for (int i = 0; i < this.CurrentSelectableBuffData.Count; i++)
		{
			BuffScrollItemData buffScrollItemData = this.CurrentSelectableBuffData[i];
			if (buffScrollItemData.Selected)
			{
				MowingTowerBuffInfo mowingTowerBuffInfo = new MowingTowerBuffInfo();
				mowingTowerBuffInfo.BuffId = buffScrollItemData.BuffId;
				mowingTowerBuffInfo.ChangeAble = true;
				mowingTowerBuffInfo.Slot = num;
				num++;
				list.Add(mowingTowerBuffInfo);
			}
		}
		int currentSelectCount = this.GetCurrentSelectCount();
		if (currentSelectCount < this.CurrentTeamInfo.GetBuffMaxCount())
		{
			for (int j = currentSelectCount; j < this.CurrentTeamInfo.GetBuffMaxCount(); j++)
			{
				MowingTowerBuffInfo indexPrepareSelectBuff = this.CurrentTeamInfo.GetIndexPrepareSelectBuff(j);
				MowingTowerBuffInfo mowingTowerBuffInfo2 = new MowingTowerBuffInfo();
				mowingTowerBuffInfo2.BuffId = 0;
				mowingTowerBuffInfo2.ChangeAble = (indexPrepareSelectBuff == null || indexPrepareSelectBuff.ChangeAble);
				mowingTowerBuffInfo2.Slot = num;
				num++;
				list.Add(mowingTowerBuffInfo2);
			}
		}
		this.CurrentTeamInfo.SetPrepareSelectBuff(list.ToArray());
		Singleton<EventSystem>.Instance.Emit(EEventName.ChangeMowingTowerBuff);
		base.CloseMe(null);
	}

	// Token: 0x06008F81 RID: 36737 RVA: 0x0025AD2C File Offset: 0x00258F2C
	protected override void OnBeforeShow()
	{
		this.TryShowAnimation();
		this.CurrentTeamInfo = ModelBase<MowingTowerModel>.Instance.CurrentTeamInfo;
		this.CurrentSelectableBuffData = new List<BuffScrollItemData>();
		List<MowingTowerBuffInfo> optionBuff = this.CurrentTeamInfo.GetOptionBuff();
		List<MowingTowerBuffInfo> prepareSelectBuff = this.CurrentTeamInfo.GetPrepareSelectBuff();
		for (int i = 0; i < optionBuff.Count; i++)
		{
			MowingTowerBuffInfo mowingTowerBuffInfo = optionBuff[i];
			BuffScrollItemData buffScrollItemData = new BuffScrollItemData();
			buffScrollItemData.BuffId = mowingTowerBuffInfo.BuffId;
			bool selected = false;
			for (int j = 0; j < prepareSelectBuff.Count; j++)
			{
				if (prepareSelectBuff[j].BuffId == mowingTowerBuffInfo.BuffId)
				{
					selected = true;
					break;
				}
			}
			buffScrollItemData.Selected = selected;
			buffScrollItemData.SelectedAtStart = buffScrollItemData.Selected;
			buffScrollItemData.OnClickToggle = new Action<BuffScrollItemData>(this.OnClickToggle);
			buffScrollItemData.CheckClickAble = new Func<BuffScrollItemData, bool>(this.CheckClickAble);
			this.CurrentSelectableBuffData.Add(buffScrollItemData);
		}
		this.RefreshScrollView();
		this.RefreshCountText();
		this.IsBuffMaxCountOne = (this.CurrentTeamInfo.LevelInfo.GetMaxBuffCount() == 1);
	}

	// Token: 0x06008F82 RID: 36738 RVA: 0x0025AE48 File Offset: 0x00259048
	private void TryShowAnimation()
	{
		string sequenceName = "Start";
		if (ModelBase<MowingTowerModel>.Instance.PlayBackAnimation)
		{
			sequenceName = "ShowView";
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.PlaySequencePurely(sequenceName, false, false, null, null, false);
		}
		ModelBase<MowingTowerModel>.Instance.PlayBackAnimation = false;
	}

	// Token: 0x06008F83 RID: 36739 RVA: 0x0025AE98 File Offset: 0x00259098
	private void OnClickToggle(BuffScrollItemData data)
	{
		if (this.IsBuffMaxCountOne && !data.Selected)
		{
			for (int i = 0; i < this.CurrentSelectableBuffData.Count; i++)
			{
				this.CurrentSelectableBuffData[i].Selected = false;
			}
		}
		data.Selected = !data.Selected;
		this.RefreshScrollView();
		this.RefreshCountText();
	}

	// Token: 0x06008F84 RID: 36740 RVA: 0x0025AEF8 File Offset: 0x002590F8
	private bool CheckClickAble(BuffScrollItemData data)
	{
		return this.FirstRefresh || data.Selected || this.CheckIfStillCanSelectBuff();
	}

	// Token: 0x06008F85 RID: 36741 RVA: 0x0025AF1C File Offset: 0x0025911C
	private bool CheckIfStillCanSelectBuff()
	{
		if (this.FirstRefresh)
		{
			return true;
		}
		if (this.IsBuffMaxCountOne || this.CurrentTeamInfo.LevelInfo.GetMaxBuffCount() > this.GetCurrentSelectCount())
		{
			return true;
		}
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("BossRushMaxBuffText", Array.Empty<object>());
		return false;
	}

	// Token: 0x06008F86 RID: 36742 RVA: 0x0025AF6C File Offset: 0x0025916C
	private int GetCurrentSelectCount()
	{
		int num = 0;
		for (int i = 0; i < this.CurrentSelectableBuffData.Count; i++)
		{
			if (this.CurrentSelectableBuffData[i].Selected)
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x06008F87 RID: 36743 RVA: 0x0025AFAC File Offset: 0x002591AC
	private void RefreshScrollView()
	{
		if (this.LoopScrollView != null)
		{
			List<BuffGridItemData> list = new List<BuffGridItemData>();
			this.FirstRefresh = true;
			for (int i = 0; i < this.CurrentSelectableBuffData.Count; i += 2)
			{
				BuffGridItemData buffGridItemData = new BuffGridItemData();
				buffGridItemData.BuffScrollItemData1 = this.CurrentSelectableBuffData[i];
				if (i + 1 >= this.CurrentSelectableBuffData.Count)
				{
					list.Add(buffGridItemData);
					break;
				}
				buffGridItemData.BuffScrollItemData2 = this.CurrentSelectableBuffData[i + 1];
				list.Add(buffGridItemData);
			}
			this.LoopScrollView.RefreshByData(list, false, delegate
			{
				this.FirstRefresh = false;
			}, false);
			base.GetLoopScrollViewComponent(1).RootUIComp.Get().SetUIActive(list.Count > 0);
		}
	}

	// Token: 0x06008F88 RID: 36744 RVA: 0x0025B06F File Offset: 0x0025926F
	protected override void OnBeforeHide()
	{
		LoopScrollView<BuffGridItem, BuffGridItemData> loopScrollView = this.LoopScrollView;
		if (loopScrollView == null)
		{
			return;
		}
		loopScrollView.ClearGridProxies();
	}

	// Token: 0x06008F89 RID: 36745 RVA: 0x0025B081 File Offset: 0x00259281
	private void RefreshCountText()
	{
		UUIText text = base.GetText(2);
		if (text == null)
		{
			return;
		}
		text.SetUIActive(false);
	}

	// Token: 0x04004289 RID: 17033
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400428A RID: 17034
	[Nullable(2)]
	private MowingTowerTeamInfo CurrentTeamInfo;

	// Token: 0x0400428B RID: 17035
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<BuffScrollItemData> CurrentSelectableBuffData;

	// Token: 0x0400428C RID: 17036
	private bool FirstRefresh = true;

	// Token: 0x0400428D RID: 17037
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<BuffGridItem, BuffGridItemData> LoopScrollView;

	// Token: 0x0400428E RID: 17038
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400428F RID: 17039
	private bool IsBuffMaxCountOne = true;

	// Token: 0x0200782B RID: 30763
	[NullableContext(0)]
	private static class EComponent
	{
		// Token: 0x0402953D RID: 169277
		public const int CaptionItem = 0;

		// Token: 0x0402953E RID: 169278
		public const int LoopScrollView = 1;

		// Token: 0x0402953F RID: 169279
		public const int SelectCountText = 2;

		// Token: 0x04029540 RID: 169280
		public const int ConfirmButton = 3;

		// Token: 0x04029541 RID: 169281
		public const int LoopItem = 4;
	}
}
