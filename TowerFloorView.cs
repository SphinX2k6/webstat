using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002BF6 RID: 11254
[NullableContext(1)]
[Nullable(0)]
public class TowerFloorView : UiViewBase
{
	// Token: 0x06016748 RID: 91976 RVA: 0x0063CAC8 File Offset: 0x0063ACC8
	public TowerFloorView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06016749 RID: 91977 RVA: 0x0063CAE4 File Offset: 0x0063ACE4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 15;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIGridLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickResetBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickChallengeBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0601674A RID: 91978 RVA: 0x0063CD61 File Offset: 0x0063AF61
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnTowerRefresh, new Action(this.RefreshTower));
	}

	// Token: 0x0601674B RID: 91979 RVA: 0x0063CD7F File Offset: 0x0063AF7F
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnTowerRefresh, new Action(this.RefreshTower));
	}

	// Token: 0x0601674C RID: 91980 RVA: 0x0063CDA0 File Offset: 0x0063AFA0
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		int currentSelectDifficulties = ModelBase<TowerModel>.Instance.CurrentSelectDifficulties;
		this.TowerFloorLayout = new GenericLayout<TowerFloorItem, int>(base.GetVerticalLayout(1), new Func<TowerFloorItem>(this.InitFloorItem), null, false, true);
		ModelBase<TowerModel>.Instance.DefaultFloor = -1;
		int[] difficultyAreaAllFloor = ModelBase<TowerModel>.Instance.GetDifficultyAreaAllFloor(currentSelectDifficulties, (int)this.OpenParam);
		if (ModelBase<TowerModel>.Instance.NeedOpenConfirmView)
		{
			ModelBase<TowerModel>.Instance.DefaultFloor = ModelBase<TowerModel>.Instance.NeedOpenConfirmViewTowerId;
		}
		else
		{
			foreach (int num in difficultyAreaAllFloor)
			{
				if (!ModelBase<TowerModel>.Instance.GetHaveChallengeFloorAndFormation(num))
				{
					ModelBase<TowerModel>.Instance.DefaultFloor = num;
					break;
				}
			}
			if (ModelBase<TowerModel>.Instance.DefaultFloor == -1 && difficultyAreaAllFloor.Length != 0)
			{
				ModelBase<TowerModel>.Instance.DefaultFloor = difficultyAreaAllFloor[0];
			}
		}
		this.TowerFloorLayout.RefreshByData(difficultyAreaAllFloor.ToList<int>(), null, false);
		this.BuffShowLayout = new GenericLayout<TowerBuffShowItem, long>(base.GetVerticalLayout(2), new Func<TowerBuffShowItem>(this.InitBuffItem), null, false, true);
		this.TargetStarLayout = new GenericLayout<TowerStarsComplexItem, ValueTuple<bool, TowerTarget>>(base.GetVerticalLayout(3), new Func<TowerStarsComplexItem>(this.InitTargetStarItem), null, false, true);
		this.MonsterLayout = new GenericLayout<TowerMonsterItem, int>(base.GetGridLayout(4), new Func<TowerMonsterItem>(this.InitMonsterItem), null, false, true);
		this.TitleItem = new TowerTitleItem(base.GetItem(0), delegate()
		{
			UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.TowerNormalView);
			UiViewBase viewByName2 = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.TowerVariationView);
			if (!ModelBase<TowerModel>.Instance.CheckInTower())
			{
				base.CloseMe(null);
				return;
			}
			if (viewByName == null && viewByName2 == null)
			{
				ControllerBase<TowerController>.Instance.BackToTowerView(delegate
				{
					base.CloseMe(null);
				});
				return;
			}
			base.CloseMe(null);
		});
		this.ElementLayout = new GenericLayout<TowerElementItem, int>(base.GetHorizontalLayout(13), new Func<TowerElementItem>(this.InitElementItem), null, false, true);
		string text = null;
		if (currentSelectDifficulties == 1)
		{
			text = "Text_LowRisk_Text";
		}
		else if (currentSelectDifficulties == 2)
		{
			text = "Text_HighRisk_Text";
		}
		else if (currentSelectDifficulties == 3)
		{
			text = "Text_Variation_Text";
		}
		else if (currentSelectDifficulties == 4)
		{
			text = "Text_OverLock_Text";
		}
		string towerAreaName = ConfigBase<TowerClimbConfig>.Instance.GetTowerAreaName((difficultyAreaAllFloor.Length != 0) ? difficultyAreaAllFloor[0] : 0);
		this.TitleItem.RefreshText(text ?? "", new string[]
		{
			towerAreaName
		});
		this.RefreshView(ModelBase<TowerModel>.Instance.DefaultFloor, false);
		if (ModelBase<TowerModel>.Instance.NeedOpenConfirmView)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TowerApplyFloorDataView, null, null);
		}
		this.AddHomeBtnExtraCallback();
	}

	// Token: 0x0601674D RID: 91981 RVA: 0x0063CFD3 File Offset: 0x0063B1D3
	private void AddHomeBtnExtraCallback()
	{
		UiBehaviourHomeBtn uiBehaviourHomeBtn = this.UiBehaviourHomeBtn;
		if (uiBehaviourHomeBtn == null)
		{
			return;
		}
		uiBehaviourHomeBtn.AddExtraAsyncCallback(delegate
		{
			TowerFloorView.<>c.<<AddHomeBtnExtraCallback>b__15_0>d <<AddHomeBtnExtraCallback>b__15_0>d;
			<<AddHomeBtnExtraCallback>b__15_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<AddHomeBtnExtraCallback>b__15_0>d.<>1__state = -1;
			<<AddHomeBtnExtraCallback>b__15_0>d.<>t__builder.Start<TowerFloorView.<>c.<<AddHomeBtnExtraCallback>b__15_0>d>(ref <<AddHomeBtnExtraCallback>b__15_0>d);
			return <<AddHomeBtnExtraCallback>b__15_0>d.<>t__builder.Task;
		});
	}

	// Token: 0x0601674E RID: 91982 RVA: 0x0063D004 File Offset: 0x0063B204
	private void RefreshTower()
	{
		this.RefreshView(this.TowerId, !ModelBase<TowerModel>.Instance.GetFloorIsUnlock(this.TowerId));
		int[] difficultyAreaAllFloor = ModelBase<TowerModel>.Instance.GetDifficultyAreaAllFloor(ModelBase<TowerModel>.Instance.CurrentSelectDifficulties, (int)this.OpenParam);
		ModelBase<TowerModel>.Instance.DefaultFloor = this.TowerId;
		this.TowerFloorLayout.RefreshByData(difficultyAreaAllFloor.ToList<int>(), null, false);
	}

	// Token: 0x0601674F RID: 91983 RVA: 0x0063D074 File Offset: 0x0063B274
	protected override void OnBeforeDestroy()
	{
		this.TowerFloorLayout = null;
		this.BuffShowLayout = null;
		this.TargetStarLayout = null;
		this.MonsterLayout = null;
		TowerTitleItem titleItem = this.TitleItem;
		if (titleItem != null)
		{
			titleItem.Destroy(null);
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
		ModelBase<TowerModel>.Instance.CurrentSelectFloor = -1;
	}

	// Token: 0x06016750 RID: 91984 RVA: 0x0063D0D2 File Offset: 0x0063B2D2
	private TowerFloorItem InitFloorItem()
	{
		TowerFloorItem towerFloorItem = new TowerFloorItem();
		towerFloorItem.BindOnClickToggle(new Action<int, bool>(this.RefreshView));
		return towerFloorItem;
	}

	// Token: 0x06016751 RID: 91985 RVA: 0x0063D0EB File Offset: 0x0063B2EB
	private TowerBuffShowItem InitBuffItem()
	{
		return new TowerBuffShowItem();
	}

	// Token: 0x06016752 RID: 91986 RVA: 0x0063D0F2 File Offset: 0x0063B2F2
	private TowerStarsComplexItem InitTargetStarItem()
	{
		return new TowerStarsComplexItem();
	}

	// Token: 0x06016753 RID: 91987 RVA: 0x0063D0F9 File Offset: 0x0063B2F9
	private TowerMonsterItem InitMonsterItem()
	{
		return new TowerMonsterItem();
	}

	// Token: 0x06016754 RID: 91988 RVA: 0x0063D100 File Offset: 0x0063B300
	private TowerElementItem InitElementItem()
	{
		return new TowerElementItem();
	}

	// Token: 0x06016755 RID: 91989 RVA: 0x0063D108 File Offset: 0x0063B308
	private void RefreshView(int towerId, bool isLock)
	{
		this.TowerId = towerId;
		ModelBase<TowerModel>.Instance.CurrentSelectFloor = towerId;
		TowerConfig value = ConfigBase<TowerClimbConfig>.Instance.GetTowerInfo(towerId).Value;
		this.BuffShowLayout.RefreshByData(value.ShowBuffs().ToList<long>(), null, false);
		this.MonsterLayout.RefreshByData(value.ShowMonsters().ToList<int>(), delegate
		{
			base.GetItem(14).SetAnchorOffsetY(0f);
		}, false);
		if (value.RecommendElement() != null && value.RecommendElement().Length != 0)
		{
			UUIItem item = base.GetItem(12);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			this.ElementLayout.RefreshByData(value.RecommendElement().ToList<int>(), null, false);
		}
		else
		{
			UUIItem item2 = base.GetItem(12);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
		}
		List<ValueTuple<bool, TowerTarget>> list = new List<ValueTuple<bool, TowerTarget>>();
		List<int> floorStarsIndex = ModelBase<TowerModel>.Instance.GetFloorStarsIndex(towerId);
		IReadOnlyList<int> readOnlyList = value.TargetConfig();
		for (int i = 0; i < 3; i++)
		{
			if (i < readOnlyList.Count)
			{
				TowerTarget? targetConfig = ConfigBase<TowerClimbConfig>.Instance.GetTargetConfig(readOnlyList[i]);
				ValueTuple<bool, TowerTarget> item3 = new ValueTuple<bool, TowerTarget>(floorStarsIndex != null && floorStarsIndex.Contains(i), targetConfig.Value);
				list.Add(item3);
			}
		}
		this.TargetStarLayout.RefreshByData(list, null, false);
		base.GetText(5).SetText(value.Cost.ToString(), true);
		base.GetItem(9).SetUIActive(!isLock);
		base.GetItem(10).SetUIActive(isLock);
		base.SetTextureByPath(value.BgPath, base.GetTexture(8), null, null);
		TowerFloorInfo floorData = ModelBase<TowerModel>.Instance.GetFloorData(this.TowerId);
		if (floorData == null || floorData.Formation.Count == 0)
		{
			base.GetButton(6).RootUIComp.Get().SetUIActive(false);
		}
		else
		{
			base.GetButton(6).RootUIComp.Get().SetUIActive(true);
		}
		bool haveChallengeFloor = ModelBase<TowerModel>.Instance.GetHaveChallengeFloor(this.TowerId);
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, true);
		}
		if (!this.HavePlaySwitchSequence.Contains(this.TowerId) && !haveChallengeFloor)
		{
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 != null)
			{
				levelSequencePlayer2.PlayLevelSequenceByName("BuffShow", false, null, false);
			}
			this.HavePlaySwitchSequence.Add(this.TowerId);
		}
		LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
		if (levelSequencePlayer3 != null)
		{
			levelSequencePlayer3.PlayLevelSequenceByName("Switch", false, null, false);
		}
		base.GetItem(15).SetUIActive(floorData != null && floorData.IsQuickPass);
	}

	// Token: 0x06016756 RID: 91990 RVA: 0x0063D3AC File Offset: 0x0063B5AC
	private void OnClickResetBtn()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.TowerResetView, this.TowerId, null);
	}

	// Token: 0x06016757 RID: 91991 RVA: 0x0063D3C9 File Offset: 0x0063B5C9
	private void OnClickChallengeBtn()
	{
		ModelBase<TowerModel>.Instance.OpenTowerFormationView(this.TowerId);
	}

	// Token: 0x0400ADD6 RID: 44502
	private int TowerId = -1;

	// Token: 0x0400ADD7 RID: 44503
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<TowerFloorItem, int> TowerFloorLayout;

	// Token: 0x0400ADD8 RID: 44504
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<TowerBuffShowItem, long> BuffShowLayout;

	// Token: 0x0400ADD9 RID: 44505
	[Nullable(new byte[]
	{
		2,
		1,
		0
	})]
	private GenericLayout<TowerStarsComplexItem, ValueTuple<bool, TowerTarget>> TargetStarLayout;

	// Token: 0x0400ADDA RID: 44506
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<TowerMonsterItem, int> MonsterLayout;

	// Token: 0x0400ADDB RID: 44507
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<TowerElementItem, int> ElementLayout;

	// Token: 0x0400ADDC RID: 44508
	[Nullable(2)]
	private TowerTitleItem TitleItem;

	// Token: 0x0400ADDD RID: 44509
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400ADDE RID: 44510
	private readonly List<int> HavePlaySwitchSequence = new List<int>();

	// Token: 0x02008EEC RID: 36588
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x04030022 RID: 196642
		TitleItem,
		// Token: 0x04030023 RID: 196643
		TowerFloorLayout,
		// Token: 0x04030024 RID: 196644
		ShowBuffLayout,
		// Token: 0x04030025 RID: 196645
		TargetStarLayout,
		// Token: 0x04030026 RID: 196646
		MonsterLayout,
		// Token: 0x04030027 RID: 196647
		CostText,
		// Token: 0x04030028 RID: 196648
		ResetBtn,
		// Token: 0x04030029 RID: 196649
		ChallengeBtn,
		// Token: 0x0403002A RID: 196650
		BgTexture,
		// Token: 0x0403002B RID: 196651
		BtnPanelItem,
		// Token: 0x0403002C RID: 196652
		LockItem,
		// Token: 0x0403002D RID: 196653
		ElementItem = 12,
		// Token: 0x0403002E RID: 196654
		ElementLayout,
		// Token: 0x0403002F RID: 196655
		FloorContentItem,
		// Token: 0x04030030 RID: 196656
		QuickPassItem
	}
}
