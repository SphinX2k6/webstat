using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002ADE RID: 10974
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SurvivorsRogueCardShopItem : GridProxyAbstract<GoodsDetail>
{
	// Token: 0x06015F19 RID: 89881 RVA: 0x006183E8 File Offset: 0x006165E8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickBtnPurchase))
		};
	}

	// Token: 0x06015F1A RID: 89882 RVA: 0x00618500 File Offset: 0x00616700
	private void OnClickBtnPurchase()
	{
		if (this.HasImportantNode())
		{
			this.SetAnimOn(true);
			this.PlayImportantNodeAnim().ContinueWith(delegate()
			{
				Action<GoodsDetail> onPurchaseBtnClickCallback2 = this.OnPurchaseBtnClickCallback;
				if (onPurchaseBtnClickCallback2 == null)
				{
					return;
				}
				onPurchaseBtnClickCallback2(this.Data);
			});
			return;
		}
		Action<GoodsDetail> onPurchaseBtnClickCallback = this.OnPurchaseBtnClickCallback;
		if (onPurchaseBtnClickCallback == null)
		{
			return;
		}
		onPurchaseBtnClickCallback(this.Data);
	}

	// Token: 0x06015F1B RID: 89883 RVA: 0x00618540 File Offset: 0x00616740
	private void OnClickLock(ISurvivorsRogueCardBase data, bool bLock)
	{
		Action<GoodsDetail, bool> onClickLockCallback = this.OnClickLockCallback;
		if (onClickLockCallback == null)
		{
			return;
		}
		onClickLockCallback(this.Data, bLock);
	}

	// Token: 0x06015F1C RID: 89884 RVA: 0x00618559 File Offset: 0x00616759
	private void OnStateChange(ISurvivorsRogueCardBase data, EToggleState state)
	{
		Action<GoodsDetail, bool> onStateChangeCallback = this.OnStateChangeCallback;
		if (onStateChangeCallback == null)
		{
			return;
		}
		onStateChangeCallback(this.Data, state == EToggleState.ETT_Checked);
	}

	// Token: 0x06015F1D RID: 89885 RVA: 0x00618575 File Offset: 0x00616775
	private void OnHover(ISurvivorsRogueCardBase data, EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			return;
		}
		this.RefreshSelected(true, true);
	}

	// Token: 0x06015F1E RID: 89886 RVA: 0x00618584 File Offset: 0x00616784
	private void OnUnHover(ISurvivorsRogueCardBase data, EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			return;
		}
		this.RefreshSelected(false, true);
	}

	// Token: 0x06015F1F RID: 89887 RVA: 0x00618594 File Offset: 0x00616794
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsRogueCardShopItem.<OnBeforeStartAsync>d__19 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsRogueCardShopItem.<OnBeforeStartAsync>d__19>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015F20 RID: 89888 RVA: 0x006185D7 File Offset: 0x006167D7
	protected override void OnBeforeShow()
	{
		ModelBase<SurvivorsRogueModel>.Instance.BattleData.BehaviorDelegate.AddTreeVarUpdateDelegate(ESurvivorsRougeSystemVarType.Gold.ToEnumString(), new TTreeVarUpdateDelegate(this.RefreshPrice));
	}

	// Token: 0x06015F21 RID: 89889 RVA: 0x006185FF File Offset: 0x006167FF
	protected override void OnBeforeDestroy()
	{
		ModelBase<SurvivorsRogueModel>.Instance.BattleData.BehaviorDelegate.RemoveTreeVarUpdateDelegate(ESurvivorsRougeSystemVarType.Gold.ToEnumString(), new TTreeVarUpdateDelegate(this.RefreshPrice));
		this.RootActor.OnSequencePlayEvent.Unbind();
	}

	// Token: 0x06015F22 RID: 89890 RVA: 0x00618637 File Offset: 0x00616837
	private SurvivorsRogueLvNode CreateLvNode()
	{
		return new SurvivorsRogueLvNode();
	}

	// Token: 0x06015F23 RID: 89891 RVA: 0x00618640 File Offset: 0x00616840
	public override UniTask RefreshAsync(GoodsDetail data, bool isSelected, int gridIndex)
	{
		SurvivorsRogueCardShopItem.<RefreshAsync>d__23 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.data = data;
		<RefreshAsync>d__.isSelected = isSelected;
		<RefreshAsync>d__.gridIndex = gridIndex;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<SurvivorsRogueCardShopItem.<RefreshAsync>d__23>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015F24 RID: 89892 RVA: 0x0061869C File Offset: 0x0061689C
	private void OnEventSequence(string sequenceName, string eventName)
	{
		if (sequenceName == "None" && eventName == "PlayStart")
		{
			if (this.Data == null)
			{
				return;
			}
			if (this.Data.IsLock)
			{
				return;
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayOrReplaySequenceByName("Start", false, null);
		}
	}

	// Token: 0x06015F25 RID: 89893 RVA: 0x006186FC File Offset: 0x006168FC
	private List<ISurvivorsLvNodeData> GetLvNodeDataList(int maxLevel, List<int> importantNodeLevel, int curLevel, int upLevel)
	{
		this.HighlightNodeLvList.Clear();
		if (curLevel >= maxLevel)
		{
			return new List<ISurvivorsLvNodeData>();
		}
		List<ISurvivorsLvNodeData> list = new List<ISurvivorsLvNodeData>();
		for (int i = 1; i <= maxLevel; i++)
		{
			ESurvivorsLvState state = ESurvivorsLvState.Inactive;
			if (i <= curLevel)
			{
				state = ESurvivorsLvState.Activated;
			}
			else if (i <= curLevel + upLevel)
			{
				this.HighlightNodeLvList.Add(i);
			}
			SurvivorsLvNodeData item = new SurvivorsLvNodeData
			{
				Lv = i,
				IsImportant = importantNodeLevel.Contains(i),
				State = state
			};
			list.Add(item);
		}
		list.Reverse();
		return list;
	}

	// Token: 0x06015F26 RID: 89894 RVA: 0x0061877C File Offset: 0x0061697C
	private void RefreshPrice(VarDefinePb lastVarDefine, VarDefinePb newVarDefine)
	{
		this.RefreshPrice();
	}

	// Token: 0x06015F27 RID: 89895 RVA: 0x00618784 File Offset: 0x00616984
	private void RefreshPrice()
	{
		if (this.Data == null)
		{
			return;
		}
		bool selfInteractive = ModelBase<SurvivorsRogueModel>.Instance.BattleData.GetCurrencyCount() >= this.Data.CurPrice;
		SurvivorsRogueCardBase cardItem = this.CardItem;
		if (cardItem != null)
		{
			cardItem.RefreshCost(new int?(this.Data.CurPrice), false, !this.Data.IsSell);
		}
		base.GetButton(1).SetSelfInteractive(selfInteractive);
	}

	// Token: 0x06015F28 RID: 89896 RVA: 0x006187F8 File Offset: 0x006169F8
	public void RefreshPurchased(bool isPurchased)
	{
		base.GetItem(6).SetUIActive(isPurchased);
		base.GetItem(7).SetUIActive(isPurchased);
		base.GetButton(1).RootUIComp.Get().SetUIActive(!isPurchased);
		base.GetItem(2).SetUIActive(!isPurchased && this.NeedLvInfo);
		base.GetItem(8).SetUIActive(!isPurchased && this.NeedLvInfo);
	}

	// Token: 0x06015F29 RID: 89897 RVA: 0x0061886C File Offset: 0x00616A6C
	private void RefreshSelected(bool bSelected, bool preSelect = false)
	{
		if (!preSelect)
		{
			this.CardItem.SetSelected(bSelected, false, false);
		}
		if (this.Data.IsSell)
		{
			base.GetItem(9).SetUIActive(false);
			return;
		}
		bool flag = false;
		foreach (int num in this.HighlightNodeLvList)
		{
			ESurvivorsLvState state = bSelected ? ESurvivorsLvState.Highlight : ESurvivorsLvState.Inactive;
			SurvivorsRogueLvNode layoutItemByKey = this.LvNodeLayout.GetLayoutItemByKey(num);
			if (layoutItemByKey != null)
			{
				layoutItemByKey.RefreshState(state);
			}
			if (layoutItemByKey != null && layoutItemByKey.Data.IsImportant)
			{
				flag = true;
			}
		}
		int? num2 = (this.HighlightNodeLvList.Count > 0) ? new int?(this.HighlightNodeLvList[this.HighlightNodeLvList.Count - 1]) : null;
		if (num2 != null)
		{
			UUIItem itemByKey = this.LvNodeLayout.GetItemByKey(num2.Value);
			if (itemByKey != null)
			{
				base.GetItem(5).SetAnchorOffsetY(itemByKey.GetAnchorOffsetY());
			}
		}
		base.GetItem(9).SetUIActive(!preSelect && bSelected && flag);
		this.SetAnimOn(bSelected);
	}

	// Token: 0x06015F2A RID: 89898 RVA: 0x006189B4 File Offset: 0x00616BB4
	private void SetAnimOn(bool bOn)
	{
		if (bOn == this.AnimState)
		{
			return;
		}
		this.AnimState = bOn;
		this.ArrowSequencePlayer.StopPlayingSequence(false, true);
		base.GetItem(5).SetUIActive(true);
		this.ArrowSequencePlayer.PlayLevelSequenceByName(bOn ? "Start" : "Close", false, null, false);
	}

	// Token: 0x06015F2B RID: 89899 RVA: 0x00618A14 File Offset: 0x00616C14
	public bool HasImportantNode()
	{
		foreach (int num in this.HighlightNodeLvList)
		{
			SurvivorsRogueLvNode layoutItemByKey = this.LvNodeLayout.GetLayoutItemByKey(num);
			if (layoutItemByKey != null && layoutItemByKey.Data.IsImportant)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06015F2C RID: 89900 RVA: 0x00618A8C File Offset: 0x00616C8C
	private UniTask PlayImportantNodeAnim()
	{
		SurvivorsRogueCardShopItem.<PlayImportantNodeAnim>d__32 <PlayImportantNodeAnim>d__;
		<PlayImportantNodeAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayImportantNodeAnim>d__.<>4__this = this;
		<PlayImportantNodeAnim>d__.<>1__state = -1;
		<PlayImportantNodeAnim>d__.<>t__builder.Start<SurvivorsRogueCardShopItem.<PlayImportantNodeAnim>d__32>(ref <PlayImportantNodeAnim>d__);
		return <PlayImportantNodeAnim>d__.<>t__builder.Task;
	}

	// Token: 0x06015F2D RID: 89901 RVA: 0x00618ACF File Offset: 0x00616CCF
	public override void OnSelected(bool fireEvent)
	{
		this.RefreshSelected(true, false);
	}

	// Token: 0x06015F2E RID: 89902 RVA: 0x00618AD9 File Offset: 0x00616CD9
	public override void OnDeselected(bool fireEvent)
	{
		this.RefreshSelected(false, false);
	}

	// Token: 0x06015F2F RID: 89903 RVA: 0x00618AE3 File Offset: 0x00616CE3
	public override object GetKey(GoodsDetail data, int displayIndex)
	{
		return data.SurvivorsGainData.IncId;
	}

	// Token: 0x06015F30 RID: 89904 RVA: 0x00618AF8 File Offset: 0x00616CF8
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length == 0)
		{
			return null;
		}
		if (!(configParams[0] == "EvolveBar"))
		{
			return null;
		}
		UUIVerticalLayout verticalLayout = base.GetVerticalLayout(3);
		UUIItem uuiitem = (verticalLayout != null) ? verticalLayout.GetRootComponent() : null;
		if (uuiitem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uuiitem,
			uuiitem
		};
	}

	// Token: 0x0400A8A2 RID: 43170
	private const string SEQ_LIGHT = "Start";

	// Token: 0x0400A8A3 RID: 43171
	private const string SEQ_CLOSE = "Close";

	// Token: 0x0400A8A4 RID: 43172
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400A8A5 RID: 43173
	[Nullable(2)]
	private LevelSequencePlayer ArrowSequencePlayer;

	// Token: 0x0400A8A6 RID: 43174
	[Nullable(2)]
	public SurvivorsRogueCardBase CardItem;

	// Token: 0x0400A8A7 RID: 43175
	private GoodsDetail Data;

	// Token: 0x0400A8A8 RID: 43176
	private bool NeedLvInfo;

	// Token: 0x0400A8A9 RID: 43177
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<SurvivorsRogueLvNode, ISurvivorsLvNodeData> LvNodeLayout;

	// Token: 0x0400A8AA RID: 43178
	private readonly List<int> HighlightNodeLvList = new List<int>();

	// Token: 0x0400A8AB RID: 43179
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<GoodsDetail> OnPurchaseBtnClickCallback;

	// Token: 0x0400A8AC RID: 43180
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<GoodsDetail, bool> OnClickLockCallback;

	// Token: 0x0400A8AD RID: 43181
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<GoodsDetail, bool> OnStateChangeCallback;

	// Token: 0x0400A8AE RID: 43182
	private bool AnimState;
}
