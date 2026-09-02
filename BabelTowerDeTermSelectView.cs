using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200120E RID: 4622
[NullableContext(1)]
[Nullable(0)]
public class BabelTowerDeTermSelectView : UiViewBase
{
	// Token: 0x06007A4E RID: 31310 RVA: 0x001FDBD6 File Offset: 0x001FBDD6
	public BabelTowerDeTermSelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06007A4F RID: 31311 RVA: 0x001FDBEC File Offset: 0x001FBDEC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 21;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIArtText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 4;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(17, new Action(this.OnClickConfirmBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickClearBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(16, new Action(this.OnClickQuestBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickLevelDetailBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007A50 RID: 31312 RVA: 0x001FDF80 File Offset: 0x001FC180
	protected override UniTask OnBeforeStartAsync()
	{
		BabelTowerDeTermSelectView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BabelTowerDeTermSelectView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007A51 RID: 31313 RVA: 0x001FDFC4 File Offset: 0x001FC1C4
	protected override void OnStart()
	{
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.BabelTowerQuestRedDot, base.GetItem(20), null, 0);
		this.LevelId = (int)(this.OpenParam ?? 0);
		base.GetText(9).SetUIActive(false);
		ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo.Clear();
		ModelBase<BabelTowerModel>.Instance.DeTermSelectIndex = 0;
		this.InitDeTermScrollView();
		UUIInturnAnimController uuiinturnAnimController = base.GetScrollViewWithScrollbar(2).Content.Get().GetComponentByClass(UUIInturnAnimController.StaticClass()) as UUIInturnAnimController;
		if (uuiinturnAnimController != null)
		{
			uuiinturnAnimController.Play("", -1, false);
		}
		UUIInturnAnimController uuiinturnAnimController2 = base.GetScrollViewWithScrollbar(5).Content.Get().GetComponentByClass(UUIInturnAnimController.StaticClass()) as UUIInturnAnimController;
		if (uuiinturnAnimController2 != null)
		{
			uuiinturnAnimController2.Play("", -1, false);
		}
		ModelBase<BabelTowerModel>.Instance.CurrentSelectLevel = this.LevelId;
	}

	// Token: 0x06007A52 RID: 31314 RVA: 0x001FE0B7 File Offset: 0x001FC2B7
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.BabelTowerRefreshLevelInfo, new Action(this.BabelTowerRefreshLevelInfo));
	}

	// Token: 0x06007A53 RID: 31315 RVA: 0x001FE0D5 File Offset: 0x001FC2D5
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.BabelTowerRefreshLevelInfo, new Action(this.BabelTowerRefreshLevelInfo));
	}

	// Token: 0x06007A54 RID: 31316 RVA: 0x001FE0F3 File Offset: 0x001FC2F3
	protected override void OnBeforeShow()
	{
		this.RefreshView();
	}

	// Token: 0x06007A55 RID: 31317 RVA: 0x001FE0FB File Offset: 0x001FC2FB
	protected override void OnBeforeDestroy()
	{
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.BabelTowerQuestRedDot, base.GetItem(20), 0);
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
	}

	// Token: 0x06007A56 RID: 31318 RVA: 0x001FE130 File Offset: 0x001FC330
	private void RefreshView()
	{
		BabelTowerLevel babelTowerLevelConfig = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(this.LevelId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), babelTowerLevelConfig.NameText, Array.Empty<object>());
		base.GetItem(19).SetUIActive(babelTowerLevelConfig.IsDifficult);
		if (babelTowerLevelConfig.IsDifficult)
		{
			BabelActivityLevelInfo babelActivityLevelInfo;
			int num = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData().HardLevelDataMap.TryGetValue(this.LevelId, out babelActivityLevelInfo) ? babelActivityLevelInfo.PassStar : 0;
			base.GetText(10).SetText(num.ToString() ?? "", true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(18), "BabelTowerHardStar", Array.Empty<object>());
			return;
		}
		base.GetText(10).SetText(babelTowerLevelConfig.PassStar.ToString() ?? "", true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(18), "BabelTowerNormalStar", Array.Empty<object>());
	}

	// Token: 0x06007A57 RID: 31319 RVA: 0x001FE230 File Offset: 0x001FC430
	private void InitDeTermScrollView()
	{
		BabelTowerLevel babelTowerLevelConfig = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(this.LevelId);
		this.DeTermScrollViewDataList.Clear();
		BabelTowerData babelTowerData = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData();
		List<int> dailyDeTerm = babelTowerData.GetDailyLevel().Contains(this.LevelId) ? babelTowerData.GetDailyDeTerm() : new List<int>();
		if (babelTowerLevelConfig.FixBabelDeTermdsLength > 0)
		{
			List<int> list = new List<int>();
			for (int i = 0; i < babelTowerLevelConfig.FixBabelDeTermdsLength; i++)
			{
				int num = babelTowerLevelConfig.FixBabelDeTermds(i);
				BabelTowerDeTerm babelTowerDeTerm = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerDeTerm(num);
				int j = 1;
				while (babelTowerDeTerm.Star > j)
				{
					list.Add(0);
					j++;
				}
				list.Add(num);
				for (j++; j <= 3; j++)
				{
					list.Add(0);
				}
				BabelTowerSelectInfo babelTowerSelectInfo = new BabelTowerSelectInfo();
				babelTowerSelectInfo.State = EBabelTowerDeTermState.StaticSelect;
				BabelTowerModel instance = ModelBase<BabelTowerModel>.Instance;
				int deTermSelectIndex = instance.DeTermSelectIndex;
				instance.DeTermSelectIndex = deTermSelectIndex + 1;
				babelTowerSelectInfo.SelectIndex = deTermSelectIndex;
				BabelTowerSelectInfo value = babelTowerSelectInfo;
				ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo[num] = value;
			}
			BabelTowerDeTermSelectItemInfo item = new BabelTowerDeTermSelectItemInfo
			{
				IsNecessary = true,
				AllDeTerm = list,
				DailyDeTerm = dailyDeTerm,
				OnChangeSelectDeTerm = new Action<int>(this.OnChangeDeTerm)
			};
			this.DeTermScrollViewDataList.Add(item);
		}
		List<int> list2 = new List<int>();
		for (int k = 0; k < babelTowerLevelConfig.BabelTowerDeTermMutexArrayLength; k++)
		{
			int id = babelTowerLevelConfig.BabelTowerDeTermMutexArray(k);
			list2 = new List<int>();
			BabelTowerDeTermMutex babelTowerDeTermMutual = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerDeTermMutual(id);
			for (int l = 0; l < babelTowerDeTermMutual.MutexDeTermGroupLength; l++)
			{
				int groupId = babelTowerDeTermMutual.MutexDeTermGroup(l);
				list2.AddRange(this.GetDeTermListByGroupId(groupId));
			}
			BabelTowerDeTermSelectItemInfo item2 = new BabelTowerDeTermSelectItemInfo
			{
				IsNecessary = false,
				AllDeTerm = list2,
				DailyDeTerm = dailyDeTerm,
				OnChangeSelectDeTerm = new Action<int>(this.OnChangeDeTerm)
			};
			this.DeTermScrollViewDataList.Add(item2);
		}
		GenericScrollViewNew<BabelTowerDeTermSelectItem, IBabelTowerDeTermSelectItemInfo> deTermScrollView = this.DeTermScrollView;
		if (deTermScrollView != null)
		{
			deTermScrollView.RefreshByData(this.DeTermScrollViewDataList, null, false);
		}
		this.RefreshDesScrollView(null);
	}

	// Token: 0x06007A58 RID: 31320 RVA: 0x001FE464 File Offset: 0x001FC664
	private List<int> GetDeTermListByGroupId(int groupId)
	{
		BabelTowerData babelTowerData = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData();
		List<int> list = new List<int>();
		List<BabelTowerDeTerm> list2 = new List<BabelTowerDeTerm>(ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerDeTermByGroupId(groupId));
		list2.Sort(delegate(BabelTowerDeTerm a, BabelTowerDeTerm b)
		{
			if (a.Line != b.Line)
			{
				return a.Line - b.Line;
			}
			return a.Star - b.Star;
		});
		int num = 1;
		int num2 = 1;
		using (List<BabelTowerDeTerm>.Enumerator enumerator = list2.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				BabelTowerDeTerm babelTowerDeTerm = enumerator.Current;
				if (num2 != babelTowerDeTerm.Line)
				{
					num2 = babelTowerDeTerm.Line;
					num = 1;
				}
				while (babelTowerDeTerm.Star > num)
				{
					list.Add(0);
					num++;
				}
				list.Add(babelTowerDeTerm.Id);
				if (babelTowerData.GetDeTermIsLock(babelTowerDeTerm.Id))
				{
					BabelTowerSelectInfo babelTowerSelectInfo = new BabelTowerSelectInfo();
					babelTowerSelectInfo.State = EBabelTowerDeTermState.Lock;
					BabelTowerModel instance = ModelBase<BabelTowerModel>.Instance;
					int deTermSelectIndex = instance.DeTermSelectIndex;
					instance.DeTermSelectIndex = deTermSelectIndex + 1;
					babelTowerSelectInfo.SelectIndex = deTermSelectIndex;
					BabelTowerSelectInfo value = babelTowerSelectInfo;
					ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo[babelTowerDeTerm.Id] = value;
				}
				else if (babelTowerData.GetDeTermIsUse(this.LevelId, babelTowerDeTerm.Id))
				{
					BabelTowerSelectInfo babelTowerSelectInfo2 = new BabelTowerSelectInfo();
					babelTowerSelectInfo2.State = EBabelTowerDeTermState.Select;
					BabelTowerModel instance2 = ModelBase<BabelTowerModel>.Instance;
					int deTermSelectIndex = instance2.DeTermSelectIndex;
					instance2.DeTermSelectIndex = deTermSelectIndex + 1;
					babelTowerSelectInfo2.SelectIndex = deTermSelectIndex;
					BabelTowerSelectInfo value2 = babelTowerSelectInfo2;
					ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo[babelTowerDeTerm.Id] = value2;
				}
				else
				{
					BabelTowerSelectInfo babelTowerSelectInfo3 = new BabelTowerSelectInfo();
					babelTowerSelectInfo3.State = EBabelTowerDeTermState.Select;
					BabelTowerModel instance3 = ModelBase<BabelTowerModel>.Instance;
					int deTermSelectIndex = instance3.DeTermSelectIndex;
					instance3.DeTermSelectIndex = deTermSelectIndex + 1;
					babelTowerSelectInfo3.SelectIndex = deTermSelectIndex;
					BabelTowerSelectInfo value3 = babelTowerSelectInfo3;
					ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo[babelTowerDeTerm.Id] = value3;
				}
				num++;
			}
			goto IL_1B9;
		}
		IL_1AE:
		list.Add(0);
		num++;
		IL_1B9:
		if (num > 3)
		{
			return list;
		}
		goto IL_1AE;
	}

	// Token: 0x06007A59 RID: 31321 RVA: 0x001FE64C File Offset: 0x001FC84C
	private void OnClickConfirmBtn()
	{
		List<int> selectDeTermList = new List<int>();
		Dictionary<int, IBabelTowerSelectInfo> deTermSelectInfo = ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo;
		int currentStar = 0;
		foreach (KeyValuePair<int, IBabelTowerSelectInfo> keyValuePair in deTermSelectInfo)
		{
			if (keyValuePair.Value.State == EBabelTowerDeTermState.Select)
			{
				selectDeTermList.Add(keyValuePair.Key);
			}
			if (keyValuePair.Value.State == EBabelTowerDeTermState.Select || keyValuePair.Value.State == EBabelTowerDeTermState.StaticSelect)
			{
				BabelTowerDeTerm babelTowerDeTerm = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerDeTerm(keyValuePair.Key);
				currentStar += babelTowerDeTerm.Star;
			}
		}
		BabelTowerLevel babelTowerLevelConfig = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(this.LevelId);
		if (currentStar >= babelTowerLevelConfig.PassStar)
		{
			this.RequestDeTermChose(selectDeTermList, currentStar).Forget();
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.BabelTowerLowStarConfirm);
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			this.RequestDeTermChose(selectDeTermList, currentStar).Forget();
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06007A5A RID: 31322 RVA: 0x001FE790 File Offset: 0x001FC990
	private UniTask RequestDeTermChose(List<int> selectDeTermList, int currentStar)
	{
		BabelTowerDeTermSelectView.<RequestDeTermChose>d__20 <RequestDeTermChose>d__;
		<RequestDeTermChose>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestDeTermChose>d__.<>4__this = this;
		<RequestDeTermChose>d__.selectDeTermList = selectDeTermList;
		<RequestDeTermChose>d__.currentStar = currentStar;
		<RequestDeTermChose>d__.<>1__state = -1;
		<RequestDeTermChose>d__.<>t__builder.Start<BabelTowerDeTermSelectView.<RequestDeTermChose>d__20>(ref <RequestDeTermChose>d__);
		return <RequestDeTermChose>d__.<>t__builder.Task;
	}

	// Token: 0x06007A5B RID: 31323 RVA: 0x001FE7E3 File Offset: 0x001FC9E3
	private void OnClickQuestBtn()
	{
		if (!ControllerBase<BabelTowerController>.Instance.GetBabelTowerData().CheckIfInOpenTime())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BabelTowerIsNotOpen", Array.Empty<object>());
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerQuestView, null, null);
	}

	// Token: 0x06007A5C RID: 31324 RVA: 0x001FE81C File Offset: 0x001FCA1C
	private void OnClickLevelDetailBtn()
	{
		BabelTowerLevel babelTowerLevelConfig = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(this.LevelId);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.InstanceDungeonMonsterPreView, babelTowerLevelConfig.InstId, null);
	}

	// Token: 0x06007A5D RID: 31325 RVA: 0x001FE858 File Offset: 0x001FCA58
	private void OnClickClearBtn()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.BabelTowerClearDeTerm);
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			ControllerBase<BabelTowerController>.Instance.SelectBabelActivityDeTermRequest(this.LevelId, new List<int>()).Forget<bool>();
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06007A5E RID: 31326 RVA: 0x001FE894 File Offset: 0x001FCA94
	private BabelTowerDeTermSelectItem InitDeTermItem()
	{
		return new BabelTowerDeTermSelectItem();
	}

	// Token: 0x06007A5F RID: 31327 RVA: 0x001FE89B File Offset: 0x001FCA9B
	private BabelTowerDeTermSelectDesItem InitDesItem()
	{
		return new BabelTowerDeTermSelectDesItem
		{
			OnClickCallBack = new Action<int>(this.OnClickDesBtn)
		};
	}

	// Token: 0x06007A60 RID: 31328 RVA: 0x001FE8B4 File Offset: 0x001FCAB4
	private void OnChangeDeTerm(int deTerm)
	{
		this.RefreshDesScrollView(new int?(deTerm));
	}

	// Token: 0x06007A61 RID: 31329 RVA: 0x001FE8C4 File Offset: 0x001FCAC4
	private void RefreshDesScrollView(int? deTerm = null)
	{
		List<int> list = new List<int>();
		Dictionary<int, IBabelTowerSelectInfo> map = ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo;
		int num = 0;
		foreach (KeyValuePair<int, IBabelTowerSelectInfo> keyValuePair in map)
		{
			if (keyValuePair.Key != 0 && (keyValuePair.Value.State == EBabelTowerDeTermState.Select || keyValuePair.Value.State == EBabelTowerDeTermState.StaticSelect))
			{
				list.Add(keyValuePair.Key);
				BabelTowerDeTerm babelTowerDeTerm = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerDeTerm(keyValuePair.Key);
				num += babelTowerDeTerm.Star;
			}
		}
		list.Sort((int a, int b) => map[b].SelectIndex - map[a].SelectIndex);
		GenericScrollViewNew<BabelTowerDeTermSelectDesItem, int> desScrollView = this.DesScrollView;
		if (desScrollView != null)
		{
			desScrollView.RefreshByData(list, delegate
			{
				if (deTerm == null)
				{
					return;
				}
				foreach (BabelTowerDeTermSelectDesItem babelTowerDeTermSelectDesItem in this.DesScrollView.GetScrollItemList())
				{
					int deTermId = babelTowerDeTermSelectDesItem.DeTermId;
					int? deTerm2 = deTerm;
					if (deTermId == deTerm2.GetValueOrDefault() & deTerm2 != null)
					{
						GenericScrollViewNew<BabelTowerDeTermSelectDesItem, int> desScrollView2 = this.DesScrollView;
						if (desScrollView2 != null)
						{
							desScrollView2.LateScrollTo(babelTowerDeTermSelectDesItem.GetRootItem(), null, false);
						}
						babelTowerDeTermSelectDesItem.PlayChoseSequence();
					}
				}
			}, false);
		}
		base.GetArtText(13).SetText(((num < 10) ? "0" : "") + num.ToString());
		BabelTowerLevel babelTowerLevelConfig = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(this.LevelId);
		bool uiactive = num < babelTowerLevelConfig.PassStar;
		base.GetItem(11).SetUIActive(uiactive);
		base.GetItem(7).SetUIActive(list.Count <= 0);
		BabelTowerDifficulty? babelTowerDifficulty = ModelBase<BabelTowerModel>.Instance.CalculateDifficultyConfigByStarNum(babelTowerLevelConfig.ActivityId, num);
		if (babelTowerDifficulty == null)
		{
			return;
		}
		if (this.LastDiff < 2 && babelTowerDifficulty.Value.DifficultyId >= 2)
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlaySequencePurely("Highest", false, false, null, null, false);
			}
		}
		else if (this.LastDiff >= 2 && babelTowerDifficulty.Value.DifficultyId < 2)
		{
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 != null)
			{
				levelSequencePlayer2.PlaySequencePurely("HighestClose", false, false, null, null, false);
			}
		}
		this.LastDiff = babelTowerDifficulty.Value.DifficultyId;
		FColor color = FColor.FromHex(babelTowerDifficulty.Value.TextBgColor);
		base.GetItem(14).SetColor(color);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(15), babelTowerDifficulty.Value.DifficultyTextKey, Array.Empty<object>());
	}

	// Token: 0x06007A62 RID: 31330 RVA: 0x001FEB34 File Offset: 0x001FCD34
	private void OnClickDesBtn(int deTerm)
	{
		for (int i = 0; i < this.DeTermScrollViewDataList.Count; i++)
		{
			if (this.DeTermScrollViewDataList[i].AllDeTerm.Contains(deTerm))
			{
				UUIItem itemByIndex = this.DeTermScrollView.GetItemByIndex(i);
				this.DeTermScrollView.ScrollTo(itemByIndex, false);
				BabelTowerDeTermSelectItem scrollItemByIndex = this.DeTermScrollView.GetScrollItemByIndex(i);
				if (scrollItemByIndex != null)
				{
					scrollItemByIndex.PlayPositionSequence(deTerm);
				}
			}
		}
	}

	// Token: 0x06007A63 RID: 31331 RVA: 0x001FEBA4 File Offset: 0x001FCDA4
	private void BabelTowerRefreshLevelInfo()
	{
		foreach (BabelTowerDeTermSelectItem babelTowerDeTermSelectItem in this.DeTermScrollView.GetScrollItemList())
		{
			babelTowerDeTermSelectItem.ClearSelect();
		}
		this.InitDeTermScrollView();
	}

	// Token: 0x04003AC0 RID: 15040
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04003AC1 RID: 15041
	private int LevelId;

	// Token: 0x04003AC2 RID: 15042
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<BabelTowerDeTermSelectItem, IBabelTowerDeTermSelectItemInfo> DeTermScrollView;

	// Token: 0x04003AC3 RID: 15043
	private List<IBabelTowerDeTermSelectItemInfo> DeTermScrollViewDataList = new List<IBabelTowerDeTermSelectItemInfo>();

	// Token: 0x04003AC4 RID: 15044
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<BabelTowerDeTermSelectDesItem, int> DesScrollView;

	// Token: 0x04003AC5 RID: 15045
	private int LastDiff;

	// Token: 0x04003AC6 RID: 15046
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x02007556 RID: 30038
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x040287CC RID: 165836
		public const int CaptionItem = 0;

		// Token: 0x040287CD RID: 165837
		public const int LevelDetailBtn = 1;

		// Token: 0x040287CE RID: 165838
		public const int DeTermScrollView = 2;

		// Token: 0x040287CF RID: 165839
		public const int DeTermScrollItem = 3;

		// Token: 0x040287D0 RID: 165840
		public const int ClearBtn = 4;

		// Token: 0x040287D1 RID: 165841
		public const int DesScrollView = 5;

		// Token: 0x040287D2 RID: 165842
		public const int DesScrollItem = 6;

		// Token: 0x040287D3 RID: 165843
		public const int DesNoneItem = 7;

		// Token: 0x040287D4 RID: 165844
		public const int NameText = 8;

		// Token: 0x040287D5 RID: 165845
		public const int DesText = 9;

		// Token: 0x040287D6 RID: 165846
		public const int TargetStarText = 10;

		// Token: 0x040287D7 RID: 165847
		public const int LowStarItem = 11;

		// Token: 0x040287D8 RID: 165848
		public const int LowStarText = 12;

		// Token: 0x040287D9 RID: 165849
		public const int CurrentStarText = 13;

		// Token: 0x040287DA RID: 165850
		public const int HardItem = 14;

		// Token: 0x040287DB RID: 165851
		public const int HardText = 15;

		// Token: 0x040287DC RID: 165852
		public const int QuestBtn = 16;

		// Token: 0x040287DD RID: 165853
		public const int ConfirmBtn = 17;

		// Token: 0x040287DE RID: 165854
		public const int TargetDesText = 18;

		// Token: 0x040287DF RID: 165855
		public const int DifficultyEffectItem = 19;

		// Token: 0x040287E0 RID: 165856
		public const int QuestBtnRedDotItem = 20;
	}
}
