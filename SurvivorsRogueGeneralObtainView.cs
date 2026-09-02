using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002B7F RID: 11135
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueGeneralObtainView : UiViewBase, ISurvivorsRogueCommandView
{
	// Token: 0x060162AA RID: 90794 RVA: 0x00626AC5 File Offset: 0x00624CC5
	public SurvivorsRogueGeneralObtainView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x17001CE0 RID: 7392
	// (get) Token: 0x060162AB RID: 90795 RVA: 0x00626ACE File Offset: 0x00624CCE
	SurvivorsRogueCommandBase ISurvivorsRogueCommandView.Command
	{
		get
		{
			return this.Command;
		}
	}

	// Token: 0x17001CE1 RID: 7393
	// (get) Token: 0x060162AC RID: 90796 RVA: 0x00626AD6 File Offset: 0x00624CD6
	int ISurvivorsRogueCommandView.CommandIncId
	{
		get
		{
			return this.CommandIncId;
		}
	}

	// Token: 0x060162AD RID: 90797 RVA: 0x00626AE0 File Offset: 0x00624CE0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickBtnConfirm))
		};
	}

	// Token: 0x060162AE RID: 90798 RVA: 0x00626B89 File Offset: 0x00624D89
	public void CloseView()
	{
		base.CloseMe(null);
	}

	// Token: 0x060162AF RID: 90799 RVA: 0x00626B94 File Offset: 0x00624D94
	private void OnClickBtnConfirm()
	{
		if (this.ViewInfo == null)
		{
			return;
		}
		ESurvivorsObtainMode obtainMode = this.ViewInfo.ChooseData.ObtainMode;
		if (obtainMode != ESurvivorsObtainMode.SingleSelect)
		{
			if (obtainMode == ESurvivorsObtainMode.All)
			{
				List<int> list = new List<int>();
				for (int i = 0; i < this.ViewInfo.GoodsList.Count; i++)
				{
					GoodsDetail goodsDetail = this.ViewInfo.GoodsList[i];
					if (goodsDetail.SurvivorsGainData != null)
					{
						list.Add(goodsDetail.SurvivorsGainData.IncId);
					}
				}
				this.Command.SelectIds = list;
			}
		}
		else
		{
			this.Command.SelectIds = new List<int>
			{
				this.SelectIncId
			};
		}
		this.Command.Execute();
	}

	// Token: 0x060162B0 RID: 90800 RVA: 0x00626C48 File Offset: 0x00624E48
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsRogueGeneralObtainView.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsRogueGeneralObtainView.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060162B1 RID: 90801 RVA: 0x00626C8B File Offset: 0x00624E8B
	protected override void OnBeforeCreate()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.SurvivorsRebindCommandView, new Action<int>(this.OnSurvivorsRebindCommandView));
	}

	// Token: 0x060162B2 RID: 90802 RVA: 0x00626CA9 File Offset: 0x00624EA9
	protected override void OnAddEventListener()
	{
		if (!Singleton<EventSystem>.Instance.Has(EEventName.SurvivorsRebindCommandView, new Action<int>(this.OnSurvivorsRebindCommandView)))
		{
			Singleton<EventSystem>.Instance.Add(EEventName.SurvivorsRebindCommandView, new Action<int>(this.OnSurvivorsRebindCommandView));
		}
	}

	// Token: 0x060162B3 RID: 90803 RVA: 0x00626CE4 File Offset: 0x00624EE4
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.SurvivorsRebindCommandView, new Action<int>(this.OnSurvivorsRebindCommandView));
	}

	// Token: 0x060162B4 RID: 90804 RVA: 0x00626D02 File Offset: 0x00624F02
	protected override void OnBeforeDestroy()
	{
		SurvivorsRogueCommandBaseObtain command = this.Command;
		if (command == null)
		{
			return;
		}
		command.BindView(null);
	}

	// Token: 0x060162B5 RID: 90805 RVA: 0x00626D15 File Offset: 0x00624F15
	private void SeqStartFinished(string s)
	{
		Action onSeqStartFinished = this.OnSeqStartFinished;
		if (onSeqStartFinished == null)
		{
			return;
		}
		onSeqStartFinished();
	}

	// Token: 0x060162B6 RID: 90806 RVA: 0x00626D27 File Offset: 0x00624F27
	private SurvivorsRogueCardObtainItem CreateCardItem()
	{
		SurvivorsRogueCardObtainItem survivorsRogueCardObtainItem = new SurvivorsRogueCardObtainItem();
		survivorsRogueCardObtainItem.BindOnStateChangeCallback(new Action<ISurvivorsRogueCardBase, EToggleState>(this.OnStateChangeCallback));
		survivorsRogueCardObtainItem.BindOnCanExecuteChangeCallback(new Func<ISurvivorsRogueCardBase, EToggleState, bool>(this.OnCanExecuteChangeCallback));
		return survivorsRogueCardObtainItem;
	}

	// Token: 0x060162B7 RID: 90807 RVA: 0x00626D54 File Offset: 0x00624F54
	private void OnStateChangeCallback(ISurvivorsRogueCardBase data, EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.SetConfirmButtonInteract(true);
		}
		this.DeselectLast();
		ESurvivorsObtainMode obtainMode = this.ViewInfo.ChooseData.ObtainMode;
		if (obtainMode != ESurvivorsObtainMode.SingleSelect)
		{
			return;
		}
		this.SelectIncId = data.IncId.GetValueOrDefault();
		Action<int, bool> onGoodsSelected = this.OnGoodsSelected;
		if (onGoodsSelected == null)
		{
			return;
		}
		onGoodsSelected(this.SelectIncId, true);
	}

	// Token: 0x060162B8 RID: 90808 RVA: 0x00626DB8 File Offset: 0x00624FB8
	private void DeselectLast()
	{
		if (this.SelectIncId != 0)
		{
			SurvivorsRogueCardObtainItem layoutItemByKey = this.CardList.GetLayoutItemByKey(this.SelectIncId);
			if (layoutItemByKey != null)
			{
				layoutItemByKey.SetSelected(false, false, true);
			}
			Action<int, bool> onGoodsSelected = this.OnGoodsSelected;
			if (onGoodsSelected != null)
			{
				onGoodsSelected(this.SelectIncId, false);
			}
		}
		this.SelectIncId = 0;
	}

	// Token: 0x060162B9 RID: 90809 RVA: 0x00626E10 File Offset: 0x00625010
	private bool OnCanExecuteChangeCallback(ISurvivorsRogueCardBase data, EToggleState state)
	{
		if (this.ViewInfo == null)
		{
			return false;
		}
		ESurvivorsObtainMode obtainMode = this.ViewInfo.ChooseData.ObtainMode;
		if (obtainMode != ESurvivorsObtainMode.SingleSelect)
		{
			return obtainMode != ESurvivorsObtainMode.All && false;
		}
		return state != EToggleState.ETT_Checked;
	}

	// Token: 0x060162BA RID: 90810 RVA: 0x00626E4C File Offset: 0x0062504C
	private void SetConfirmButtonInteract(bool bInteractive)
	{
		base.GetButton(3).SetSelfInteractive(bInteractive);
	}

	// Token: 0x060162BB RID: 90811 RVA: 0x00626E5C File Offset: 0x0062505C
	private void OnSurvivorsRebindCommandView(int commandId)
	{
		SurvivorsRogueCommandBase commandByIncId = ModelBase<SurvivorsRogueModel>.Instance.CommandQueue.GetCommandByIncId(commandId);
		if (commandByIncId == null)
		{
			return;
		}
		ESurvivorsRogueCommandType type = commandByIncId.Type;
		if (type <= ESurvivorsRogueCommandType.WeaponSelect || type == ESurvivorsRogueCommandType.AdditionRewardGot)
		{
			this.Command.BindView(null);
			this.OnGoodsSelected = null;
			this.OnSeqStartFinished = null;
			this.CommandIncId = commandId;
			this.Command = (SurvivorsRogueCommandBaseObtain)commandByIncId;
			this.Refresh();
			this.Command.BindView(this);
			if (this.UiViewSequence.HasSequenceNameInPlaying("Switch"))
			{
				this.UiViewSequence.ReplaySequence("Switch");
				return;
			}
			this.UiViewSequence.PlaySequence("Switch", false, null);
		}
	}

	// Token: 0x060162BC RID: 90812 RVA: 0x00626F0C File Offset: 0x0062510C
	public void Refresh()
	{
		UiAsyncTask task = new UiAsyncTask("SurvivorsRogueGeneralObtainView.Refresh", delegate()
		{
			SurvivorsRogueGeneralObtainView.<<Refresh>b__28_0>d <<Refresh>b__28_0>d;
			<<Refresh>b__28_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<Refresh>b__28_0>d.<>4__this = this;
			<<Refresh>b__28_0>d.<>1__state = -1;
			<<Refresh>b__28_0>d.<>t__builder.Start<SurvivorsRogueGeneralObtainView.<<Refresh>b__28_0>d>(ref <<Refresh>b__28_0>d);
			return <<Refresh>b__28_0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task);
	}

	// Token: 0x060162BD RID: 90813 RVA: 0x00626F39 File Offset: 0x00625139
	[NullableContext(2)]
	public SurvivorsRogueRoleStatePanel GetRoleStatePanel()
	{
		return this.BaseItem.RoleStatePanel;
	}

	// Token: 0x060162BE RID: 90814 RVA: 0x00626F48 File Offset: 0x00625148
	private UniTask RefreshAsync()
	{
		SurvivorsRogueGeneralObtainView.<RefreshAsync>d__30 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<SurvivorsRogueGeneralObtainView.<RefreshAsync>d__30>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060162BF RID: 90815 RVA: 0x00626F8C File Offset: 0x0062518C
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
		if (configParams[0] == "WeaponEvolve")
		{
			GenericLayout<SurvivorsRogueCardObtainItem, GoodsDetail> cardList = this.CardList;
			List<SurvivorsRogueCardObtainItem> list = ((cardList != null) ? cardList.GetLayoutItemList() : null) ?? new List<SurvivorsRogueCardObtainItem>();
			for (int i = 0; i < list.Count; i++)
			{
				SurvivorsRogueCardObtainItem survivorsRogueCardObtainItem = list[i];
				if (survivorsRogueCardObtainItem.HasBondInfo())
				{
					return survivorsRogueCardObtainItem.GetGuideUiItemAndUiItemForShowEx(configParams);
				}
			}
		}
		return null;
	}

	// Token: 0x0400AB85 RID: 43909
	public int CommandIncId;

	// Token: 0x0400AB86 RID: 43910
	public SurvivorsRogueCommandBaseObtain Command;

	// Token: 0x0400AB87 RID: 43911
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericLayout<SurvivorsRogueCardObtainItem, GoodsDetail> CardList;

	// Token: 0x0400AB88 RID: 43912
	[Nullable(2)]
	private SurvivorsRogueViewBase BaseItem;

	// Token: 0x0400AB89 RID: 43913
	[Nullable(2)]
	private new ISurvivorsObtainViewInfo ViewInfo;

	// Token: 0x0400AB8A RID: 43914
	private int SelectIncId;

	// Token: 0x0400AB8B RID: 43915
	[Nullable(2)]
	public Action<int, bool> OnGoodsSelected;

	// Token: 0x0400AB8C RID: 43916
	[Nullable(2)]
	public Action OnSeqStartFinished;
}
