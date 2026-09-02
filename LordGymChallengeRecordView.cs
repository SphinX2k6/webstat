using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020021F5 RID: 8693
[NullableContext(1)]
[Nullable(0)]
public class LordGymChallengeRecordView : UiViewBase
{
	// Token: 0x06010643 RID: 67139 RVA: 0x0047A84B File Offset: 0x00478A4B
	public LordGymChallengeRecordView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010644 RID: 67140 RVA: 0x0047A878 File Offset: 0x00478A78
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickPrevDifficulty)),
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickNextDifficulty))
		};
	}

	// Token: 0x06010645 RID: 67141 RVA: 0x0047A994 File Offset: 0x00478B94
	protected override UniTask OnBeforeStartAsync()
	{
		LordGymChallengeRecordView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<LordGymChallengeRecordView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010646 RID: 67142 RVA: 0x0047A9D8 File Offset: 0x00478BD8
	protected override void OnStart()
	{
		int defaultTabIndex = this.GetDefaultTabIndex();
		this.SelectedFilterTypeId = ((this.FilterTypeList.Count > 0) ? this.FilterTypeList[defaultTabIndex].Id : 0);
		if (this.DefaultDifficulty > 0)
		{
			this.SelectedDifficulty = this.DefaultDifficulty;
		}
		this.RefreshAllTabToggleState();
		this.RefreshDifficultyState();
		this.UpdateRecordScrollView();
	}

	// Token: 0x06010647 RID: 67143 RVA: 0x0047AA40 File Offset: 0x00478C40
	private void RefreshAllTabToggleState()
	{
		GenericScrollViewNew<LordGymFilterTypeTabItem, LordGymFilterType> tabScroll = this.TabScroll;
		foreach (LordGymFilterTypeTabItem lordGymFilterTypeTabItem in (((tabScroll != null) ? tabScroll.GetScrollItemList() : null) ?? new List<LordGymFilterTypeTabItem>()))
		{
			lordGymFilterTypeTabItem.SetToggleActive(lordGymFilterTypeTabItem.GetFilterTypeId() == this.SelectedFilterTypeId);
		}
	}

	// Token: 0x06010648 RID: 67144 RVA: 0x0047AAB4 File Offset: 0x00478CB4
	protected override void OnBeforeDestroy()
	{
		this.TabScroll = null;
		this.RecordScroll = null;
		this.CaptionItem = null;
		this.SeqPlayer = null;
	}

	// Token: 0x06010649 RID: 67145 RVA: 0x0047AAD4 File Offset: 0x00478CD4
	private void PlaySwitchSequence()
	{
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer != null)
		{
			seqPlayer.StopSequenceByKey(this.SwitchSequenceName, false, false);
		}
		LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
		if (seqPlayer2 == null)
		{
			return;
		}
		seqPlayer2.PlayLevelSequenceByName(this.SwitchSequenceName, false, null, false);
	}

	// Token: 0x0601064A RID: 67146 RVA: 0x0047AB1C File Offset: 0x00478D1C
	private int GetDefaultTabIndex()
	{
		if (this.FilterTypeList.Count == 0)
		{
			return 0;
		}
		if (this.DefaultLordEntranceId > 0)
		{
			LordGymConfig instance = ConfigBase<LordGymConfig>.Instance;
			int[] lordGymEntranceLordList = instance.GetLordGymEntranceLordList(this.DefaultLordEntranceId);
			if (lordGymEntranceLordList != null)
			{
				foreach (int lordId in lordGymEntranceLordList)
				{
					LordGym? lordGymConfig = instance.GetLordGymConfig(lordId);
					if (lordGymConfig != null)
					{
						int filterType = lordGymConfig.Value.FilterType;
						for (int j = 0; j < this.FilterTypeList.Count; j++)
						{
							if (this.FilterTypeList[j].Id == filterType)
							{
								return j;
							}
						}
					}
				}
			}
		}
		return 0;
	}

	// Token: 0x0601064B RID: 67147 RVA: 0x0047ABCC File Offset: 0x00478DCC
	private bool MatchesSelectedFilter(LordGym config)
	{
		return config.FilterType == this.SelectedFilterTypeId;
	}

	// Token: 0x0601064C RID: 67148 RVA: 0x0047ABDD File Offset: 0x00478DDD
	private void OnCloseBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0601064D RID: 67149 RVA: 0x0047ABE6 File Offset: 0x00478DE6
	private void OnSelectTab(int filterTypeId)
	{
		if (this.SelectedFilterTypeId == filterTypeId)
		{
			this.RefreshAllTabToggleState();
			return;
		}
		this.SelectedFilterTypeId = filterTypeId;
		this.RefreshAllTabToggleState();
		this.RefreshDifficultyState();
		this.UpdateRecordScrollView();
		this.PlaySwitchSequence();
	}

	// Token: 0x0601064E RID: 67150 RVA: 0x0047AC18 File Offset: 0x00478E18
	private void OnClickPrevDifficulty()
	{
		int num = this.AvailableDifficulties.IndexOf(this.SelectedDifficulty);
		if (num <= 0)
		{
			return;
		}
		this.SelectedDifficulty = this.AvailableDifficulties[num - 1];
		this.UpdateDifficultyLabel();
		this.UpdateRecordScrollView();
		this.PlaySwitchSequence();
	}

	// Token: 0x0601064F RID: 67151 RVA: 0x0047AC64 File Offset: 0x00478E64
	private void OnClickNextDifficulty()
	{
		int num = this.AvailableDifficulties.IndexOf(this.SelectedDifficulty);
		if (num < 0 || num >= this.AvailableDifficulties.Count - 1)
		{
			return;
		}
		this.SelectedDifficulty = this.AvailableDifficulties[num + 1];
		this.UpdateDifficultyLabel();
		this.UpdateRecordScrollView();
		this.PlaySwitchSequence();
	}

	// Token: 0x06010650 RID: 67152 RVA: 0x0047ACC0 File Offset: 0x00478EC0
	private void RefreshDifficultyState()
	{
		this.AvailableDifficulties = this.ComputeAvailableDifficulties();
		if (this.AvailableDifficulties.Count > 0)
		{
			if (!this.AvailableDifficulties.Contains(this.SelectedDifficulty))
			{
				this.SelectedDifficulty = this.AvailableDifficulties[0];
			}
		}
		else
		{
			this.SelectedDifficulty = 0;
		}
		this.UpdateDifficultyLabel();
		this.UpdateDifficultyButtons();
	}

	// Token: 0x06010651 RID: 67153 RVA: 0x0047AD24 File Offset: 0x00478F24
	private List<int> ComputeAvailableDifficulties()
	{
		List<int> list = new List<int>();
		if (this.SelectedFilterTypeId == 0)
		{
			return list;
		}
		IReadOnlyList<LordGym> lordGymAllConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymAllConfig();
		if (lordGymAllConfig == null)
		{
			return list;
		}
		HashSet<int> hashSet = new HashSet<int>();
		foreach (LordGym config in lordGymAllConfig)
		{
			if (!config.IsDebug && this.MatchesSelectedFilter(config) && ModelBase<LordGymModel>.Instance.GetLordGymIsUnLock(config.Id))
			{
				hashSet.Add(config.Difficulty);
			}
		}
		list.AddRange(hashSet);
		list.Sort((int a, int b) => a - b);
		return list;
	}

	// Token: 0x06010652 RID: 67154 RVA: 0x0047ADF0 File Offset: 0x00478FF0
	private void UpdateDifficultyLabel()
	{
		UUIText text = base.GetText(5);
		if (text == null)
		{
			return;
		}
		if (this.SelectedDifficulty == 0)
		{
			text.SetUIActive(false);
			return;
		}
		text.SetUIActive(true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "LordGymDifficulty", new <>z__ReadOnlySingleElementList<object>(this.SelectedDifficulty));
	}

	// Token: 0x06010653 RID: 67155 RVA: 0x0047AE40 File Offset: 0x00479040
	private void UpdateDifficultyButtons()
	{
		bool uiactive = this.AvailableDifficulties.Count > 1;
		UUIButtonComponent button = base.GetButton(3);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(uiactive);
		}
		UUIButtonComponent button2 = base.GetButton(4);
		if (button2 == null)
		{
			return;
		}
		button2.RootUIComp.Get().SetUIActive(uiactive);
	}

	// Token: 0x06010654 RID: 67156 RVA: 0x0047AE9C File Offset: 0x0047909C
	private List<LordGym> GetLordList()
	{
		List<LordGym> list = new List<LordGym>();
		if (this.SelectedFilterTypeId == 0 || this.SelectedDifficulty == 0)
		{
			return list;
		}
		IReadOnlyList<LordGym> lordGymAllConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymAllConfig();
		if (lordGymAllConfig == null)
		{
			return list;
		}
		foreach (LordGym lordGym in lordGymAllConfig)
		{
			if (!lordGym.IsDebug && this.MatchesSelectedFilter(lordGym) && lordGym.Difficulty == this.SelectedDifficulty && ModelBase<LordGymModel>.Instance.GetLordGymIsUnLock(lordGym.Id))
			{
				list.Add(lordGym);
			}
		}
		list.Sort((LordGym a, LordGym b) => a.Id - b.Id);
		return list;
	}

	// Token: 0x06010655 RID: 67157 RVA: 0x0047AF68 File Offset: 0x00479168
	private void UpdateRecordScrollView()
	{
		List<LordGym> lordList = this.GetLordList();
		this.RecordScroll.RefreshByData(lordList, null, false);
		UUIItem item = base.GetItem(8);
		if (item != null)
		{
			item.SetUIActive(lordList.Count == 0);
		}
		this.RecordScroll.SetActive(lordList.Count > 0);
	}

	// Token: 0x06010656 RID: 67158 RVA: 0x0047AFB9 File Offset: 0x004791B9
	private LordGymFilterTypeTabItem CreateTabItem()
	{
		return new LordGymFilterTypeTabItem(new Action<int>(this.OnSelectTab));
	}

	// Token: 0x06010657 RID: 67159 RVA: 0x0047AFCC File Offset: 0x004791CC
	private LordGymRecordItem CreateRecordItem()
	{
		return new LordGymRecordItem();
	}

	// Token: 0x04008141 RID: 33089
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04008142 RID: 33090
	private int DefaultLordEntranceId;

	// Token: 0x04008143 RID: 33091
	private int DefaultDifficulty;

	// Token: 0x04008144 RID: 33092
	private int SelectedFilterTypeId;

	// Token: 0x04008145 RID: 33093
	private int SelectedDifficulty;

	// Token: 0x04008146 RID: 33094
	private List<int> AvailableDifficulties = new List<int>();

	// Token: 0x04008147 RID: 33095
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<LordGymFilterTypeTabItem, LordGymFilterType> TabScroll;

	// Token: 0x04008148 RID: 33096
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<LordGymRecordItem, LordGym> RecordScroll;

	// Token: 0x04008149 RID: 33097
	private List<LordGymFilterType> FilterTypeList = new List<LordGymFilterType>();

	// Token: 0x0400814A RID: 33098
	[Nullable(2)]
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x0400814B RID: 33099
	private readonly string SwitchSequenceName = "switch";

	// Token: 0x020084B6 RID: 33974
	[NullableContext(0)]
	private class EChallengeRecordComponents
	{
		// Token: 0x0402CF65 RID: 184165
		public const int Caption = 0;

		// Token: 0x0402CF66 RID: 184166
		public const int SvTabLordGym = 1;

		// Token: 0x0402CF67 RID: 184167
		public const int PnlTab = 2;

		// Token: 0x0402CF68 RID: 184168
		public const int BtnFunctionL = 3;

		// Token: 0x0402CF69 RID: 184169
		public const int BtnFunctionR = 4;

		// Token: 0x0402CF6A RID: 184170
		public const int TxtDifficult = 5;

		// Token: 0x0402CF6B RID: 184171
		public const int ScrollView = 6;

		// Token: 0x0402CF6C RID: 184172
		public const int PnlList = 7;

		// Token: 0x0402CF6D RID: 184173
		public const int UiItemEmpty = 8;
	}
}
