using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200268A RID: 9866
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class QuestReviewNodeItem : GridProxyAbstract<QuestReviewNodeParam>
{
	// Token: 0x17001865 RID: 6245
	// (get) Token: 0x0601375B RID: 79707 RVA: 0x0056C163 File Offset: 0x0056A363
	// (set) Token: 0x0601375C RID: 79708 RVA: 0x0056C16B File Offset: 0x0056A36B
	private TimerHandle Timer
	{
		get
		{
			return this.TimerInternal;
		}
		set
		{
			if (this.TimerInternal != null && TimerSystem.Instance.Has(this.TimerInternal))
			{
				TimerSystem.Instance.Remove(this.TimerInternal);
			}
			this.TimerInternal = value;
		}
	}

	// Token: 0x0601375D RID: 79709 RVA: 0x0056C1A0 File Offset: 0x0056A3A0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0601375E RID: 79710 RVA: 0x0056C290 File Offset: 0x0056A490
	protected override UniTask OnBeforeStartAsync()
	{
		QuestReviewNodeItem.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<QuestReviewNodeItem.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601375F RID: 79711 RVA: 0x0056C2D3 File Offset: 0x0056A4D3
	protected override void OnStart()
	{
		this.SeqPlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceEndEvent), false);
		Singleton<EventSystem>.Instance.Add(EEventName.OnQuestReviewMainViewBeforeHide, new Action(this.OnMainViewBeforeHide));
	}

	// Token: 0x06013760 RID: 79712 RVA: 0x0056C309 File Offset: 0x0056A509
	protected override void OnBeforeDestroy()
	{
		this.Timer = null;
		Singleton<EventSystem>.Instance.Remove(EEventName.OnQuestReviewMainViewBeforeHide, new Action(this.OnMainViewBeforeHide));
	}

	// Token: 0x06013761 RID: 79713 RVA: 0x0056C330 File Offset: 0x0056A530
	public override void Refresh(QuestReviewNodeParam param, bool isSelected, int gridIndex)
	{
		this.Param = param;
		if (param == null)
		{
			this.ItemNormal.SetUiActive(false);
			this.ItemDestroy.SetUiActive(false);
			this.ItemStar.SetUiActive(false);
			this.ItemStarDestroy.SetUiActive(false);
			base.GetRootItem().SetAlpha(0f);
			return;
		}
		this.ItemNormal.SetUiActive(this.ShouldShowNormal(param));
		this.ItemDestroy.SetUiActive(this.ShouldShowDestroy(param));
		this.ItemStar.SetUiActive(this.ShouldShowStar(param));
		this.ItemStarDestroy.SetUiActive(this.ShouldShowStarDestroy(param));
		if (param.ShouldHide)
		{
			base.GetRootItem().SetAlpha(0f);
			return;
		}
		base.GetRootItem().SetAlpha(1f);
		if (this.ShouldShowNormal(param))
		{
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer != null)
			{
				seqPlayer.PlayLevelSequenceByName("Flame", false, null, false);
			}
			LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
			if (seqPlayer2 != null)
			{
				seqPlayer2.StopCurrentSequence(false, false);
			}
			this.ItemNormal.Refresh(param);
		}
		if (this.ShouldShowDestroy(param))
		{
			this.ItemDestroy.Refresh(param);
		}
		if (this.ShouldShowStar(param))
		{
			this.ItemStar.Refresh(param);
		}
		if (this.ShouldShowStarDestroy(param))
		{
			this.ItemStarDestroy.Refresh(param);
		}
		this.HandleAnim(param);
	}

	// Token: 0x06013762 RID: 79714 RVA: 0x0056C488 File Offset: 0x0056A688
	private void HandleAnim(IQuestReviewNodeParam param)
	{
		QuestReviewLineData questReviewLineDataById = ModelBase<QuestReviewModel>.Instance.GetQuestReviewLineDataById(param.LineId);
		if (questReviewLineDataById != null && questReviewLineDataById.SkipAnim)
		{
			return;
		}
		if (!this.ShouldShowNormal(param))
		{
			if (this.ShouldShowDestroy(param))
			{
				if (questReviewLineDataById == null || !questReviewLineDataById.IsDestroy || questReviewLineDataById == null || !questReviewLineDataById.IsFirstTimeDestroy)
				{
					this.SeqPlayer.PlayLevelSequenceByName("ActivateStartC", false, null, false);
					return;
				}
				this.PlayFirstLineDestroyAnim(param);
				QuestReviewNodeData data = param.Data;
				if (data != null && data.IsFirstTimeShow)
				{
					param.Data.IsFirstTimeShow = false;
					return;
				}
			}
			else if (this.ShouldShowStar(param))
			{
				bool flag = param.LineId == 3200;
				bool flag2 = ModelBase<QuestReviewModel>.Instance.HasQuestLineFused();
				if (flag && !flag2)
				{
					QuestReviewNodeStarItem itemStar = this.ItemStar;
					if (itemStar != null)
					{
						itemStar.SetUiActive(false);
					}
					this.Timer = TimerSystem.Instance.Delay(delegate(float _)
					{
						QuestReviewNodeStarItem itemStar2 = this.ItemStar;
						if (itemStar2 != null)
						{
							itemStar2.SetUiActive(true);
						}
						this.SeqPlayer.PlayLevelSequenceByName("UnTrigger", false, null, false);
					}, 20f, null, null, true, 1f);
					return;
				}
				this.SeqPlayer.PlayLevelSequenceByName("NotStart", false, null, false);
				return;
			}
			else if (this.ShouldShowStarDestroy(param))
			{
				if (questReviewLineDataById != null && questReviewLineDataById.IsDestroy && questReviewLineDataById != null && questReviewLineDataById.IsFirstTimeDestroy)
				{
					this.PlayFirstLineStarAnim(param);
					QuestReviewNodeData data2 = param.Data;
					if (data2 != null && data2.IsFirstTimeShow)
					{
						param.Data.IsFirstTimeShow = false;
						return;
					}
				}
				else
				{
					this.SeqPlayer.PlayLevelSequenceByName("NotStartB", false, null, false);
				}
			}
			return;
		}
		if (ModelBase<QuestReviewModel>.Instance.IsFirstEntry())
		{
			this.PlayFirstEntryNodeAnim(param);
			QuestReviewNodeData data3 = param.Data;
			if (data3 != null && data3.IsFirstTimeShow)
			{
				param.Data.IsFirstTimeShow = false;
			}
			if (questReviewLineDataById != null && questReviewLineDataById.IsFirstTimeShow)
			{
				questReviewLineDataById.IsFirstTimeShow = false;
			}
			return;
		}
		if (questReviewLineDataById != null && questReviewLineDataById.IsShow && questReviewLineDataById != null && questReviewLineDataById.IsFirstTimeShow)
		{
			this.PlayFirstShowAnim(param);
			QuestReviewNodeData data4 = param.Data;
			if (data4 != null && data4.IsFirstTimeShow)
			{
				param.Data.IsFirstTimeShow = false;
			}
		}
		QuestReviewNodeData data5 = param.Data;
		if (data5 != null && data5.IsFirstTimeShow)
		{
			this.PlayFirstShowAnim(param);
			param.Data.IsFirstTimeShow = false;
			return;
		}
		this.SeqPlayer.PlayLevelSequenceByName("ActivateStart", false, null, false);
	}

	// Token: 0x06013763 RID: 79715 RVA: 0x0056C6D0 File Offset: 0x0056A8D0
	private bool ShouldShowNormal(IQuestReviewNodeParam param)
	{
		if (param == null)
		{
			return false;
		}
		QuestReviewModel instance = ModelBase<QuestReviewModel>.Instance;
		QuestReviewNodeData data = param.Data;
		QuestReviewNodeData predecessorNodeByNodeId = instance.GetPredecessorNodeByNodeId((data != null) ? data.Id : 0);
		return param.Data != null && param.Data.State != EQuestReviewNodeState.Locked && !param.IsDestroy && (param.Data.ShowOnceUnlock || predecessorNodeByNodeId == null || (predecessorNodeByNodeId != null && predecessorNodeByNodeId.State == EQuestReviewNodeState.Finished));
	}

	// Token: 0x06013764 RID: 79716 RVA: 0x0056C73E File Offset: 0x0056A93E
	private bool ShouldShowDestroy(IQuestReviewNodeParam param)
	{
		return param != null && param.Data != null && param.IsDestroy;
	}

	// Token: 0x06013765 RID: 79717 RVA: 0x0056C758 File Offset: 0x0056A958
	private bool ShouldShowStar(IQuestReviewNodeParam param)
	{
		if (param == null)
		{
			return false;
		}
		QuestReviewModel instance = ModelBase<QuestReviewModel>.Instance;
		QuestReviewNodeData data = param.Data;
		QuestReviewNodeData predecessorNodeByNodeId = instance.GetPredecessorNodeByNodeId((data != null) ? data.Id : 0);
		return (param.Data == null || param.Data.State == EQuestReviewNodeState.Locked || (!param.Data.ShowOnceUnlock && predecessorNodeByNodeId != null && predecessorNodeByNodeId.State < EQuestReviewNodeState.Finished)) && !param.IsDestroy;
	}

	// Token: 0x06013766 RID: 79718 RVA: 0x0056C7C0 File Offset: 0x0056A9C0
	private bool ShouldShowStarDestroy(IQuestReviewNodeParam param)
	{
		if (param == null)
		{
			return false;
		}
		QuestReviewModel instance = ModelBase<QuestReviewModel>.Instance;
		QuestReviewNodeData data = param.Data;
		QuestReviewNodeData predecessorNodeByNodeId = instance.GetPredecessorNodeByNodeId((data != null) ? data.Id : 0);
		return (param.Data == null || param.Data.State == EQuestReviewNodeState.Locked || (!param.Data.ShowOnceUnlock && predecessorNodeByNodeId != null && predecessorNodeByNodeId.State < EQuestReviewNodeState.Finished)) && param.IsDestroy;
	}

	// Token: 0x06013767 RID: 79719 RVA: 0x0056C828 File Offset: 0x0056AA28
	private void PlayFirstShowAnim(IQuestReviewNodeParam param)
	{
		QuestReviewNodeNormalItem itemNormal = this.ItemNormal;
		if (itemNormal != null)
		{
			itemNormal.SetUiActive(false);
		}
		QuestReviewNodeStarItem itemStar = this.ItemStar;
		if (itemStar != null)
		{
			itemStar.SetUiActive(true);
		}
		QuestReviewNodeStarItem itemStar2 = this.ItemStar;
		if (itemStar2 != null)
		{
			itemStar2.Refresh(param);
		}
		this.SeqPlayer.PlayLevelSequenceByName("NotStart", false, null, false);
		QuestReviewLineData lineData = ModelBase<QuestReviewModel>.Instance.GetQuestReviewLineDataById(param.LineId);
		this.Timer = TimerSystem.Instance.Delay(delegate(float _)
		{
			QuestReviewNodeNormalItem itemNormal2 = this.ItemNormal;
			if (itemNormal2 != null)
			{
				itemNormal2.SetUiActive(true);
			}
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer == null)
			{
				return;
			}
			seqPlayer.PlayLevelSequenceByName(lineData.ShowSeqName, false, null, false);
		}, 20f, null, null, true, 1f);
	}

	// Token: 0x06013768 RID: 79720 RVA: 0x0056C8D4 File Offset: 0x0056AAD4
	private void PlayFirstEntryNodeAnim(IQuestReviewNodeParam param)
	{
		QuestReviewNodeNormalItem itemNormal = this.ItemNormal;
		if (itemNormal != null)
		{
			itemNormal.SetUiActive(false);
		}
		QuestReviewNodeStarItem itemStar = this.ItemStar;
		if (itemStar != null)
		{
			itemStar.SetUiActive(true);
		}
		QuestReviewNodeStarItem itemStar2 = this.ItemStar;
		if (itemStar2 != null)
		{
			itemStar2.Refresh(param);
		}
		QuestReviewLineData lineData = ModelBase<QuestReviewModel>.Instance.GetQuestReviewLineDataById(param.LineId);
		this.Timer = TimerSystem.Instance.Delay(delegate(float _)
		{
			QuestReviewNodeNormalItem itemNormal2 = this.ItemNormal;
			if (itemNormal2 != null)
			{
				itemNormal2.SetUiActive(true);
			}
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer == null)
			{
				return;
			}
			seqPlayer.PlayLevelSequenceByName(lineData.NodeFirstActivateSeqName, false, null, false);
		}, 1800f, null, null, true, 1f);
	}

	// Token: 0x06013769 RID: 79721 RVA: 0x0056C964 File Offset: 0x0056AB64
	private UniTask PlayFirstLineDestroyAnim(IQuestReviewNodeParam param)
	{
		QuestReviewNodeItem.<PlayFirstLineDestroyAnim>d__22 <PlayFirstLineDestroyAnim>d__;
		<PlayFirstLineDestroyAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayFirstLineDestroyAnim>d__.<>4__this = this;
		<PlayFirstLineDestroyAnim>d__.param = param;
		<PlayFirstLineDestroyAnim>d__.<>1__state = -1;
		<PlayFirstLineDestroyAnim>d__.<>t__builder.Start<QuestReviewNodeItem.<PlayFirstLineDestroyAnim>d__22>(ref <PlayFirstLineDestroyAnim>d__);
		return <PlayFirstLineDestroyAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0601376A RID: 79722 RVA: 0x0056C9B0 File Offset: 0x0056ABB0
	private UniTask PlayFirstLineStarAnim(IQuestReviewNodeParam param)
	{
		QuestReviewNodeItem.<PlayFirstLineStarAnim>d__23 <PlayFirstLineStarAnim>d__;
		<PlayFirstLineStarAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayFirstLineStarAnim>d__.<>4__this = this;
		<PlayFirstLineStarAnim>d__.param = param;
		<PlayFirstLineStarAnim>d__.<>1__state = -1;
		<PlayFirstLineStarAnim>d__.<>t__builder.Start<QuestReviewNodeItem.<PlayFirstLineStarAnim>d__23>(ref <PlayFirstLineStarAnim>d__);
		return <PlayFirstLineStarAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0601376B RID: 79723 RVA: 0x0056C9FC File Offset: 0x0056ABFC
	private void OnMainViewBeforeHide()
	{
		string sequenceName = "ActivateClose";
		if (this.ShouldShowNormal(this.Param))
		{
			sequenceName = "ActivateClose";
		}
		else if (this.ShouldShowDestroy(this.Param))
		{
			sequenceName = "ActivateCloseC";
		}
		else if (this.ShouldShowStar(this.Param))
		{
			sequenceName = "NotClose";
		}
		else if (this.ShouldShowStarDestroy(this.Param))
		{
			sequenceName = "NotCloseB";
		}
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer == null)
		{
			return;
		}
		seqPlayer.PlayLevelSequenceByName(sequenceName, false, null, false);
	}

	// Token: 0x0601376C RID: 79724 RVA: 0x0056CA84 File Offset: 0x0056AC84
	private void OnSequenceEndEvent(string seqName)
	{
		if (!base.GetRootActor().IsValid())
		{
			return;
		}
		if (seqName == "Flame")
		{
			QuestReviewNodeNormalItem itemNormal = this.ItemNormal;
			if (itemNormal != null)
			{
				itemNormal.SetUiActive(false);
			}
			QuestReviewNodeNormalItem itemNormal2 = this.ItemNormal;
			if (itemNormal2 != null)
			{
				itemNormal2.SetToggleInteractive(true);
			}
			ControllerBase<QuestReviewController>.Instance.SetBurnFinish();
		}
		if (seqName == "Change")
		{
			QuestReviewNodeNormalItem itemNormal3 = this.ItemNormal;
			if (itemNormal3 != null)
			{
				itemNormal3.SetUiActive(false);
			}
			QuestReviewNodeNormalItem itemNormal4 = this.ItemNormal;
			if (itemNormal4 != null)
			{
				itemNormal4.SetToggleInteractive(true);
			}
		}
		if (seqName == "Trigger")
		{
			ControllerBase<QuestReviewController>.Instance.SetNewTabUnlockFinish();
		}
	}

	// Token: 0x040097AA RID: 38826
	private QuestReviewNodeNormalItem ItemNormal;

	// Token: 0x040097AB RID: 38827
	private QuestReviewNodeDestroyItem ItemDestroy;

	// Token: 0x040097AC RID: 38828
	private QuestReviewNodeStarItem ItemStar;

	// Token: 0x040097AD RID: 38829
	private QuestReviewNodeStarDestroyItem ItemStarDestroy;

	// Token: 0x040097AE RID: 38830
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x040097AF RID: 38831
	private TimerHandle TimerInternal;

	// Token: 0x040097B0 RID: 38832
	private QuestReviewNodeParam Param;

	// Token: 0x02008A2C RID: 35372
	[NullableContext(0)]
	private class ENodeComponentDefine
	{
		// Token: 0x0402E981 RID: 190849
		public const int ItemSelf = 0;

		// Token: 0x0402E982 RID: 190850
		public const int ItemNormal = 1;

		// Token: 0x0402E983 RID: 190851
		public const int ItemDestroy = 2;

		// Token: 0x0402E984 RID: 190852
		public const int ItemStar = 3;

		// Token: 0x0402E985 RID: 190853
		public const int ItemStarDestroy = 4;

		// Token: 0x0402E986 RID: 190854
		public const int ItemRedDot = 5;
	}
}
