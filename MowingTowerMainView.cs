using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001437 RID: 5175
[NullableContext(2)]
[Nullable(0)]
public class MowingTowerMainView : UiViewBase
{
	// Token: 0x06008FFD RID: 36861 RVA: 0x0025D223 File Offset: 0x0025B423
	[NullableContext(1)]
	public MowingTowerMainView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06008FFE RID: 36862 RVA: 0x0025D22C File Offset: 0x0025B42C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUITexture)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIText)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIText)),
			new ValueTuple<int, Type>(15, typeof(UUIText)),
			new ValueTuple<int, Type>(16, typeof(UUIText)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(19, typeof(UUIItem)),
			new ValueTuple<int, Type>(20, typeof(UUIItem)),
			new ValueTuple<int, Type>(21, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(22, typeof(UUIItem)),
			new ValueTuple<int, Type>(23, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(24, typeof(UUIText)),
			new ValueTuple<int, Type>(25, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickSelectViewRewardBtn)),
			new ValueTuple<int, Delegate>(21, new Action(this.OnClickLevelViewConfirmBtn)),
			new ValueTuple<int, Delegate>(23, new Action(this.OnClickLevelViewMonsterBtn))
		};
	}

	// Token: 0x06008FFF RID: 36863 RVA: 0x0025D4E6 File Offset: 0x0025B6E6
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.ChangeMowingTowerMainView, new Action<int>(this.OnChangeMowingTowerMainView));
		Singleton<EventSystem>.Instance.Add(EEventName.ChangeMowingTowerBuff, new Action(this.OnSelectBuff));
	}

	// Token: 0x06009000 RID: 36864 RVA: 0x0025D520 File Offset: 0x0025B720
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.ChangeMowingTowerMainView, new Action<int>(this.OnChangeMowingTowerMainView));
		Singleton<EventSystem>.Instance.Remove(EEventName.ChangeMowingTowerBuff, new Action(this.OnSelectBuff));
	}

	// Token: 0x06009001 RID: 36865 RVA: 0x0025D55C File Offset: 0x0025B75C
	protected override UniTask OnBeforeStartAsync()
	{
		MowingTowerMainView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MowingTowerMainView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009002 RID: 36866 RVA: 0x0025D5A0 File Offset: 0x0025B7A0
	protected override void OnStart()
	{
		ModelBase<MowingTowerModel>.Instance.CurrentSelectActivityId = (int)this.OpenParam;
		MowingTowerData mowingTowerData = ModelBase<ActivityModel>.Instance.GetActivityById(ModelBase<MowingTowerModel>.Instance.CurrentSelectActivityId) as MowingTowerData;
		this.MowingTowerData = mowingTowerData;
		this.CaptionItem.SetCloseCallBack(delegate
		{
			if (this.CurrentShowView != EMowingTowerSubViewName.SelectView)
			{
				this.CurrentShowView = EMowingTowerSubViewName.SelectView;
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null)
				{
					levelSequencePlayer.PlaySequencePurely("SwitchOut", false, false, null, null, false);
				}
				this.RefreshSubView(false);
				return;
			}
			if (ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon();
				return;
			}
			base.CloseMe(null);
		});
		this.CurrentShowView = EMowingTowerSubViewName.SelectView;
		this.RefreshSubView(true);
	}

	// Token: 0x06009003 RID: 36867 RVA: 0x0025D608 File Offset: 0x0025B808
	protected override void OnBeforeShow()
	{
		if (this.CurrentShowView == EMowingTowerSubViewName.LevelView)
		{
			this.RefreshBuffEntry();
		}
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.MowingTowerReward, base.GetItem(25), null, this.MowingTowerData.Id);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshMowingTowerRewardRedDot, this.MowingTowerData.Id);
	}

	// Token: 0x06009004 RID: 36868 RVA: 0x0025D662 File Offset: 0x0025B862
	protected override void OnBeforeHide()
	{
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.MowingTowerReward, base.GetItem(25), this.MowingTowerData.Id);
	}

	// Token: 0x06009005 RID: 36869 RVA: 0x0025D688 File Offset: 0x0025B888
	private void RefreshSelectLevelView(bool scrollToUnFinishItem = false)
	{
		this.CaptionItem.SetTitleByTextIdAndArgNew("MowingTowerSelectViewTitle", Array.Empty<object>());
		List<MowingTowerLevelDetailInfo> data = new List<MowingTowerLevelDetailInfo>(this.MowingTowerData.GetMowingTowerLevelDetailInfo());
		GenericScrollViewNew<MowingTowerMainLevelItem, MowingTowerLevelDetailInfo> levelScrollView = this.LevelScrollView;
		if (levelScrollView != null)
		{
			levelScrollView.RefreshByData(data, null, false);
		}
		UUIText text = base.GetText(2);
		if (text == null)
		{
			return;
		}
		text.SetText(this.MowingTowerData.GetFullScore().ToString() ?? "", true);
	}

	// Token: 0x06009006 RID: 36870 RVA: 0x0025D700 File Offset: 0x0025B900
	private void RefreshLevelView()
	{
		this.CaptionItem.SetTitleByTextIdAndArgNew("MowingTowerLevelViewTitle", Array.Empty<object>());
		this.CurrentTeamInfo = ModelBase<MowingTowerModel>.Instance.CurrentTeamInfo;
		TeamListItem firstPartTeamListItem = this.FirstPartTeamListItem;
		if (firstPartTeamListItem != null)
		{
			firstPartTeamListItem.RefreshTeamRole(this.CurrentTeamInfo, ETeamBelong.FirstPart);
		}
		TeamListItem lowPartTeamListItem = this.LowPartTeamListItem;
		if (lowPartTeamListItem != null)
		{
			lowPartTeamListItem.RefreshTeamRole(this.CurrentTeamInfo, ETeamBelong.LowPart);
		}
		MowingTowerLevelDetailInfo currentSelectLevel = this.CurrentTeamInfo.GetCurrentSelectLevel();
		this.RefreshLevelViewScore(currentSelectLevel);
		this.RefreshLevelViewTexture(currentSelectLevel);
		this.RefreshLevelViewMonsterDes(currentSelectLevel);
		this.RefreshBuffEntry();
		this.RefreshLowLevelTips();
	}

	// Token: 0x06009007 RID: 36871 RVA: 0x0025D790 File Offset: 0x0025B990
	[NullableContext(1)]
	private void RefreshLevelViewTexture(MowingTowerLevelDetailInfo data)
	{
		base.SetTextureByPath(data.GetNormalTexturePath(), base.GetTexture(6), null, null);
		bool isInfinite = data.GetIsInfinite();
		if (data.GetId() % 2 == 0 || isInfinite)
		{
			UUIItem item = base.GetItem(7);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(8);
			if (item2 != null)
			{
				item2.SetUIActive(true);
			}
		}
		else
		{
			UUIItem item3 = base.GetItem(7);
			if (item3 != null)
			{
				item3.SetUIActive(true);
			}
			UUIItem item4 = base.GetItem(8);
			if (item4 != null)
			{
				item4.SetUIActive(false);
			}
		}
		if (isInfinite)
		{
			UUIItem item5 = base.GetItem(9);
			if (item5 != null)
			{
				item5.SetColor(MowingTowerColors.bgInfiniteMowingTowerColor.Value);
			}
			UUIText text = base.GetText(10);
			if (text != null)
			{
				text.SetColor(MowingTowerColors.infiniteMowingTowerColor.Value);
			}
			UUIItem item6 = base.GetItem(7);
			if (item6 != null)
			{
				item6.SetColor(MowingTowerColors.infiniteMowingTowerColor.Value);
			}
			UUIItem item7 = base.GetItem(8);
			if (item7 == null)
			{
				return;
			}
			item7.SetColor(MowingTowerColors.infiniteMowingTowerColor.Value);
			return;
		}
		else
		{
			UUIItem item8 = base.GetItem(9);
			if (item8 != null)
			{
				item8.SetColor(MowingTowerColors.bgNormalMowingTowerColor.Value);
			}
			UUIText text2 = base.GetText(10);
			if (text2 != null)
			{
				text2.SetColor(MowingTowerColors.normalMowingTowerColor.Value);
			}
			UUIItem item9 = base.GetItem(7);
			if (item9 != null)
			{
				item9.SetColor(MowingTowerColors.normalMowingTowerColor.Value);
			}
			UUIItem item10 = base.GetItem(8);
			if (item10 == null)
			{
				return;
			}
			item10.SetColor(MowingTowerColors.normalMowingTowerColor.Value);
			return;
		}
	}

	// Token: 0x06009008 RID: 36872 RVA: 0x0025D904 File Offset: 0x0025BB04
	[NullableContext(1)]
	private void RefreshLevelViewScore(MowingTowerLevelDetailInfo data)
	{
		int score = data.GetScore();
		bool flag = score > 0;
		UUIText text = base.GetText(12);
		text.SetUIActive(flag);
		text.SetText(score.ToString(), true);
		base.GetItem(13).SetUIActive(!flag);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), data.GetLevelDesc(), Array.Empty<object>());
		UUIText text2 = base.GetText(14);
		if (text2 != null)
		{
			text2.SetText(data.GetFirstScore().ToString() ?? "", true);
		}
		UUIText text3 = base.GetText(15);
		if (text3 != null)
		{
			text3.SetText(data.GetLowScore().ToString() ?? "", true);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(16), data.GetLevelTips() ?? "", Array.Empty<object>());
	}

	// Token: 0x06009009 RID: 36873 RVA: 0x0025D9E4 File Offset: 0x0025BBE4
	private void RefreshLowLevelTips()
	{
		bool ifLevelTooLow = this.CurrentTeamInfo.GetIfLevelTooLow();
		base.GetItem(20).SetUIActive(ifLevelTooLow);
	}

	// Token: 0x0600900A RID: 36874 RVA: 0x0025DA0B File Offset: 0x0025BC0B
	private void OnSelectBuff()
	{
		this.RefreshBuffEntry();
	}

	// Token: 0x0600900B RID: 36875 RVA: 0x0025DA14 File Offset: 0x0025BC14
	private void RefreshBuffEntry()
	{
		List<MowingTowerBuffInfo> prepareSelectBuff = this.CurrentTeamInfo.GetPrepareSelectBuff();
		MowingBuffEntry buffEntryItem = this.BuffEntryItem;
		if (buffEntryItem == null)
		{
			return;
		}
		buffEntryItem.Refresh(prepareSelectBuff[0]);
	}

	// Token: 0x0600900C RID: 36876 RVA: 0x0025DA44 File Offset: 0x0025BC44
	[NullableContext(1)]
	private void RefreshLevelViewMonsterDes(MowingTowerLevelDetailInfo data)
	{
		MowTowerLevelsRe? mowTowerLevelsRe;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(24), "MowingTowerMonsterTimes", new <>z__ReadOnlySingleElementList<object>((data.GetConfig() != null) ? mowTowerLevelsRe.GetValueOrDefault().MonsterDes : null));
	}

	// Token: 0x0600900D RID: 36877 RVA: 0x0025DA90 File Offset: 0x0025BC90
	private void RefreshSubView(bool scrollToUnFinishItem = false)
	{
		if (this.CurrentShowView == EMowingTowerSubViewName.SelectView)
		{
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIItem item2 = base.GetItem(22);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			this.RefreshSelectLevelView(scrollToUnFinishItem);
		}
		if (this.CurrentShowView == EMowingTowerSubViewName.LevelView)
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlaySequencePurely("SwitchIn", false, false, null, null, false);
			}
			UUIItem item3 = base.GetItem(5);
			if (item3 != null)
			{
				item3.SetUIActive(false);
			}
			UUIItem item4 = base.GetItem(22);
			if (item4 != null)
			{
				item4.SetUIActive(true);
			}
			this.RefreshLevelView();
		}
	}

	// Token: 0x0600900E RID: 36878 RVA: 0x0025DB2C File Offset: 0x0025BD2C
	[NullableContext(1)]
	private MowingTowerMainLevelItem OnCreateItem()
	{
		return new MowingTowerMainLevelItem();
	}

	// Token: 0x0600900F RID: 36879 RVA: 0x0025DB33 File Offset: 0x0025BD33
	private void OnChangeMowingTowerMainView(int view)
	{
		this.CurrentShowView = (EMowingTowerSubViewName)view;
		this.RefreshSubView(false);
	}

	// Token: 0x06009010 RID: 36880 RVA: 0x0025DB43 File Offset: 0x0025BD43
	private void OnClickSelectViewRewardBtn()
	{
		if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.MowingTowerRewardView))
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MowingTowerRewardView, null, null);
		}
	}

	// Token: 0x06009011 RID: 36881 RVA: 0x0025DB68 File Offset: 0x0025BD68
	private void OnClickLevelViewConfirmBtn()
	{
		MowingTowerTeamInfo currentTeamInfo = this.CurrentTeamInfo;
		ValueTuple<List<int>, List<int>> valueTuple = (currentTeamInfo != null) ? currentTeamInfo.GetCurrentTeamMembers() : new ValueTuple<List<int>, List<int>>(new List<int>(), new List<int>());
		if (valueTuple.Item1.Count != 3 || valueTuple.Item2.Count != 3 || valueTuple.Item1.Contains(0) || valueTuple.Item2.Contains(0))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("MowingTowerNeedThreeRole", Array.Empty<object>());
			return;
		}
		ControllerBase<MowingTowerController>.Instance.RequestStartMowingTowerByTeamData(this.CurrentTeamInfo);
	}

	// Token: 0x06009012 RID: 36882 RVA: 0x0025DBF8 File Offset: 0x0025BDF8
	private void OnClickLevelViewMonsterBtn()
	{
		UiManager instance = Singleton<UiManager>.Instance;
		EUiViewName instanceDungeonMonsterPreView = EUiViewName.InstanceDungeonMonsterPreView;
		MowingTowerTeamInfo currentTeamInfo = this.CurrentTeamInfo;
		int? num;
		if (currentTeamInfo == null)
		{
			num = null;
		}
		else
		{
			MowingTowerLevelDetailInfo currentSelectLevel = currentTeamInfo.GetCurrentSelectLevel();
			num = ((currentSelectLevel != null) ? new int?(currentSelectLevel.GetInstanceDungeonId()) : null);
		}
		instance.OpenView(instanceDungeonMonsterPreView, num, null);
	}

	// Token: 0x040042C6 RID: 17094
	private MowingTowerData MowingTowerData;

	// Token: 0x040042C7 RID: 17095
	private MowingTowerTeamInfo CurrentTeamInfo;

	// Token: 0x040042C8 RID: 17096
	private EMowingTowerSubViewName CurrentShowView;

	// Token: 0x040042C9 RID: 17097
	private PopupCaptionItem CaptionItem;

	// Token: 0x040042CA RID: 17098
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<MowingTowerMainLevelItem, MowingTowerLevelDetailInfo> LevelScrollView;

	// Token: 0x040042CB RID: 17099
	private MowingBuffEntry BuffEntryItem;

	// Token: 0x040042CC RID: 17100
	private TeamListItem FirstPartTeamListItem;

	// Token: 0x040042CD RID: 17101
	private TeamListItem LowPartTeamListItem;

	// Token: 0x040042CE RID: 17102
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040042CF RID: 17103
	private const int ROLE_TEAM_SIZE = 3;

	// Token: 0x02007836 RID: 30774
	[NullableContext(0)]
	private static class EComponent
	{
		// Token: 0x0402956D RID: 169325
		public const int CaptionItem = 0;

		// Token: 0x0402956E RID: 169326
		public const int SelectViewRewardBtn = 1;

		// Token: 0x0402956F RID: 169327
		public const int SelectViewScoreText = 2;

		// Token: 0x04029570 RID: 169328
		public const int SelectViewLevelScrollView = 3;

		// Token: 0x04029571 RID: 169329
		public const int SelectViewLevelItem = 4;

		// Token: 0x04029572 RID: 169330
		public const int SelectViewRootItem = 5;

		// Token: 0x04029573 RID: 169331
		public const int LevelViewLevelTexture = 6;

		// Token: 0x04029574 RID: 169332
		public const int LevelViewSingleItem = 7;

		// Token: 0x04029575 RID: 169333
		public const int LevelViewDoubleItem = 8;

		// Token: 0x04029576 RID: 169334
		public const int LevelViewBgItem = 9;

		// Token: 0x04029577 RID: 169335
		public const int LevelViewLevelText = 10;

		// Token: 0x04029578 RID: 169336
		public const int LevelViewHaveScoreItem = 11;

		// Token: 0x04029579 RID: 169337
		public const int LevelViewScoreText = 12;

		// Token: 0x0402957A RID: 169338
		public const int LevelViewUnFinishScoreItem = 13;

		// Token: 0x0402957B RID: 169339
		public const int LevelViewFirstHalfScoreText = 14;

		// Token: 0x0402957C RID: 169340
		public const int LevelViewLowerHalfScoreText = 15;

		// Token: 0x0402957D RID: 169341
		public const int LevelViewLevelDesText = 16;

		// Token: 0x0402957E RID: 169342
		public const int LevelViewLevelBuffItem = 17;

		// Token: 0x0402957F RID: 169343
		public const int LevelViewFormationItem1 = 18;

		// Token: 0x04029580 RID: 169344
		public const int LevelViewFormationItem2 = 19;

		// Token: 0x04029581 RID: 169345
		public const int LevelViewLowLevelTipItem = 20;

		// Token: 0x04029582 RID: 169346
		public const int LevelViewConfirmBtn = 21;

		// Token: 0x04029583 RID: 169347
		public const int LevelViewRootItem = 22;

		// Token: 0x04029584 RID: 169348
		public const int LevelViewMonsterBtn = 23;

		// Token: 0x04029585 RID: 169349
		public const int LevelViewMonsterText = 24;

		// Token: 0x04029586 RID: 169350
		public const int SelectViewRewardRedDotItem = 25;
	}
}
