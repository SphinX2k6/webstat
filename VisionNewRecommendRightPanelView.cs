using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x0200253B RID: 9531
[NullableContext(1)]
[Nullable(0)]
public class VisionNewRecommendRightPanelView : UiPanelBase
{
	// Token: 0x060128B1 RID: 75953 RVA: 0x0051BE3C File Offset: 0x0051A03C
	public VisionNewRecommendRightPanelView(VisionNewRecommendProxy proxy)
	{
		this.Proxy = proxy;
		this.Proxy.RefreshSelectedRecommendDetail = new Action<Action>(this.RefreshSelectedRecommendDetail);
	}

	// Token: 0x060128B2 RID: 75954 RVA: 0x0051BE70 File Offset: 0x0051A070
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUILayoutBase)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickGuideBtn)),
			new ValueTuple<int, Delegate>(6, new Action(this.OnClickTrackBtn))
		};
	}

	// Token: 0x060128B3 RID: 75955 RVA: 0x0051BF89 File Offset: 0x0051A189
	protected override void OnStart()
	{
		this.InitAllLayouts();
	}

	// Token: 0x060128B4 RID: 75956 RVA: 0x0051BF94 File Offset: 0x0051A194
	private void InitAllLayouts()
	{
		this.FetterDescLayout = new GenericScrollViewNew<VisionNewRecommendFetterDescItem, VisionNewRecommendFetterDescItemData>(base.GetScrollViewWithScrollbar(1), new Func<VisionNewRecommendFetterDescItem>(this.InitFetterDescItem), base.GetItem(2).GetOwner() as AUIBaseActor, false, null);
		this.FirstVisionLayout = new GenericLayout<VisionNewRecommendVisionView, VisionNewRecommendVisionItemData>(base.GetLayoutBase(3), new Func<VisionNewRecommendVisionView>(this.InitVisionItem), null, false, true);
	}

	// Token: 0x060128B5 RID: 75957 RVA: 0x0051BFF3 File Offset: 0x0051A1F3
	private VisionNewRecommendVisionView InitVisionItem()
	{
		return new VisionNewRecommendVisionView
		{
			OnSelectedCallback = new Action<int, VisionNewRecommendVisionItemData>(this.OnVisionItemSelected)
		};
	}

	// Token: 0x060128B6 RID: 75958 RVA: 0x0051C00C File Offset: 0x0051A20C
	private void OnVisionItemSelected(int index, VisionNewRecommendVisionItemData data)
	{
		IReadOnlyList<PhantomItem> phantomItemByMonsterId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemByMonsterId(data.VisionMonsterId);
		if (phantomItemByMonsterId == null || phantomItemByMonsterId.Count == 0)
		{
			return;
		}
		PhantomItem phantomItem = phantomItemByMonsterId[0];
		GenericLayout<VisionNewRecommendVisionView, VisionNewRecommendVisionItemData> firstVisionLayout = this.FirstVisionLayout;
		if (firstVisionLayout != null)
		{
			firstVisionLayout.SelectGridProxy(index, false);
		}
		this.Proxy.CurrentSelectFirstVisionMonsterId = data.VisionMonsterId;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), phantomItem.MonsterName, Array.Empty<object>());
		this.CurrentSkillId = phantomItem.SkillId;
		this.RefreshSkillDesc();
	}

	// Token: 0x060128B7 RID: 75959 RVA: 0x0051C094 File Offset: 0x0051A294
	private void RefreshSkillDesc()
	{
		if (this.CurrentSkillId == 0)
		{
			return;
		}
		UUIText text = base.GetText(8);
		PhantomSkill? phantomSkillBySkillId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSkillBySkillId(this.CurrentSkillId);
		if (this.Proxy.IsSimpleMode)
		{
			if (!StringUtils.IsEmpty((phantomSkillBySkillId != null) ? phantomSkillBySkillId.GetValueOrDefault().SimplyDescription : null))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, phantomSkillBySkillId.Value.SimplyDescription, Array.Empty<object>());
				return;
			}
			if (text != null)
			{
				text.SetText("", true);
				return;
			}
		}
		else
		{
			string[] phantomSkillDescExBySkillIdAndQuality = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSkillDescExBySkillIdAndQuality(phantomSkillBySkillId.Value.Id, 2);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, phantomSkillBySkillId.Value.DescriptionEx, phantomSkillDescExBySkillIdAndQuality);
		}
	}

	// Token: 0x060128B8 RID: 75960 RVA: 0x0051C158 File Offset: 0x0051A358
	[NullableContext(2)]
	private void RefreshSelectedRecommendDetail(Action callback = null)
	{
		VisionFetterRecommendInfo currentSelectRecommendInfo = this.Proxy.GetCurrentSelectRecommendInfo();
		if (currentSelectRecommendInfo == null)
		{
			return;
		}
		this.FetterDataList.Clear();
		foreach (IVisionFetterCount fetterData in currentSelectRecommendInfo.GetFetterCountList())
		{
			this.FetterDataList.Add(new VisionNewRecommendFetterDescItemData
			{
				FetterData = fetterData,
				IsNeedLine = false
			});
		}
		this.FetterDataList.Sort(delegate(VisionNewRecommendFetterDescItemData a, VisionNewRecommendFetterDescItemData b)
		{
			PhantomFetterGroup fetterGroupById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(a.FetterData.GroupId);
			PhantomFetterGroup fetterGroupById2 = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(b.FetterData.GroupId);
			if (fetterGroupById.FetterType != fetterGroupById2.FetterType)
			{
				return fetterGroupById2.FetterType - fetterGroupById.FetterType;
			}
			return b.FetterData.GroupId - a.FetterData.GroupId;
		});
		for (int i = 0; i < this.FetterDataList.Count; i++)
		{
			this.FetterDataList[i].IsNeedLine = (i < this.FetterDataList.Count - 1);
		}
		GenericScrollViewNew<VisionNewRecommendFetterDescItem, VisionNewRecommendFetterDescItemData> fetterDescLayout = this.FetterDescLayout;
		if (fetterDescLayout != null)
		{
			fetterDescLayout.RefreshByData(this.FetterDataList, null, false);
		}
		int count = 2;
		List<VisionNewRecommendVisionItemData> data = currentSelectRecommendInfo.GetMainPhantomList().Take(count).ToList<MainPhantomRecommendInfo>().Select(delegate(MainPhantomRecommendInfo info)
		{
			int monsterId = info.GetMonsterId();
			IReadOnlyList<PhantomItem> phantomItemByMonsterId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemByMonsterId(monsterId);
			PhantomItem? phantomItem = (phantomItemByMonsterId != null && phantomItemByMonsterId.Count > 0) ? new PhantomItem?(phantomItemByMonsterId[0]) : null;
			int rareId = (phantomItem != null) ? phantomItem.GetValueOrDefault().Rarity : 0;
			PhantomRarity? phantomRareConfig = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomRareConfig(rareId);
			int cost = (phantomRareConfig != null) ? phantomRareConfig.Value.Cost : 0;
			return new VisionNewRecommendVisionItemData
			{
				VisionMonsterId = monsterId,
				FetterGroupId = info.GetFetterGroupId(),
				Cost = cost,
				Obtained = ModelBase<PhantomBattleModel>.Instance.GetIfHasMonsterInInventory(monsterId),
				Usage = info.GetUsage()
			};
		}).ToList<VisionNewRecommendVisionItemData>();
		GenericLayout<VisionNewRecommendVisionView, VisionNewRecommendVisionItemData> firstVisionLayout = this.FirstVisionLayout;
		if (firstVisionLayout == null)
		{
			return;
		}
		firstVisionLayout.RefreshByData(data, delegate
		{
			if (this.Proxy.IsFromRoleDevFirstSelect)
			{
				GenericLayout<VisionNewRecommendVisionView, VisionNewRecommendVisionItemData> firstVisionLayout2 = this.FirstVisionLayout;
				if (firstVisionLayout2 != null)
				{
					firstVisionLayout2.SelectGridProxyByKey(this.Proxy.GetSelectedFirstVisionMonsterIdCallBack(this.Proxy.CurrentSelectRoleId), true);
				}
				this.Proxy.IsFromRoleDevFirstSelect = false;
				return;
			}
			GenericLayout<VisionNewRecommendVisionView, VisionNewRecommendVisionItemData> firstVisionLayout3 = this.FirstVisionLayout;
			if (firstVisionLayout3 == null)
			{
				return;
			}
			firstVisionLayout3.SelectGridProxy(0, true);
		}, false);
	}

	// Token: 0x060128B9 RID: 75961 RVA: 0x0051C2BC File Offset: 0x0051A4BC
	private VisionNewRecommendFetterDescItem InitFetterDescItem()
	{
		VisionNewRecommendFetterDescItem visionNewRecommendFetterDescItem = new VisionNewRecommendFetterDescItem();
		visionNewRecommendFetterDescItem.SetSimpleMode(this.Proxy.IsSimpleMode);
		return visionNewRecommendFetterDescItem;
	}

	// Token: 0x060128BA RID: 75962 RVA: 0x0051C2D4 File Offset: 0x0051A4D4
	public void RefreshSimpleMode()
	{
		GenericScrollViewNew<VisionNewRecommendFetterDescItem, VisionNewRecommendFetterDescItemData> fetterDescLayout = this.FetterDescLayout;
		foreach (VisionNewRecommendFetterDescItem visionNewRecommendFetterDescItem in (((fetterDescLayout != null) ? fetterDescLayout.GetScrollItemList() : null) ?? new List<VisionNewRecommendFetterDescItem>()))
		{
			visionNewRecommendFetterDescItem.SetSimpleMode(this.Proxy.IsSimpleMode);
		}
		this.RefreshSkillDesc();
	}

	// Token: 0x060128BB RID: 75963 RVA: 0x0051C34C File Offset: 0x0051A54C
	private void OnClickGuideBtn()
	{
		VisionFetterRecommendInfo currentSelectRecommendInfo = this.Proxy.GetCurrentSelectRecommendInfo();
		if (currentSelectRecommendInfo == null)
		{
			return;
		}
		bool showFastFilter = ModelBase<RoleModel>.Instance.IsRoleOwned(this.Proxy.CurrentSelectRoleId);
		ControllerBase<PhantomBattleController>.Instance.OpenPhantomBattleFetterView(currentSelectRecommendInfo.GetRecommendFetterGroupId(), this.Proxy.CurrentSelectRoleId, showFastFilter, currentSelectRecommendInfo.BuildFetterList()).Forget();
	}

	// Token: 0x060128BC RID: 75964 RVA: 0x0051C3A6 File Offset: 0x0051A5A6
	private void OnClickTrackBtn()
	{
		ControllerBase<CalabashController>.Instance.JumpToCalabashCollectTabView(this.Proxy.CurrentSelectFirstVisionMonsterId);
	}

	// Token: 0x04009083 RID: 36995
	private readonly VisionNewRecommendProxy Proxy;

	// Token: 0x04009084 RID: 36996
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<VisionNewRecommendFetterDescItem, VisionNewRecommendFetterDescItemData> FetterDescLayout;

	// Token: 0x04009085 RID: 36997
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<VisionNewRecommendVisionView, VisionNewRecommendVisionItemData> FirstVisionLayout;

	// Token: 0x04009086 RID: 36998
	private readonly List<VisionNewRecommendFetterDescItemData> FetterDataList = new List<VisionNewRecommendFetterDescItemData>();

	// Token: 0x04009087 RID: 36999
	private int CurrentSkillId;

	// Token: 0x02008861 RID: 34913
	[NullableContext(0)]
	private enum EComp
	{
		// Token: 0x0402E10B RID: 188683
		GuideBtn,
		// Token: 0x0402E10C RID: 188684
		FetterScroll,
		// Token: 0x0402E10D RID: 188685
		FetterItem,
		// Token: 0x0402E10E RID: 188686
		FirstVisionLayout,
		// Token: 0x0402E10F RID: 188687
		FirstVisionItem,
		// Token: 0x0402E110 RID: 188688
		VisionName,
		// Token: 0x0402E111 RID: 188689
		TrackBtn,
		// Token: 0x0402E112 RID: 188690
		VisionSkillScroll,
		// Token: 0x0402E113 RID: 188691
		VisionSkillDesc
	}
}
