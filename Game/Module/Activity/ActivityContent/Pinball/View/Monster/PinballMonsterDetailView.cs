using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Monster
{
	// Token: 0x020065EC RID: 26092
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballMonsterDetailView : UiViewBase
	{
		// Token: 0x060412F9 RID: 267001 RVA: 0x010B8FDC File Offset: 0x010B71DC
		public PinballMonsterDetailView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060412FA RID: 267002 RVA: 0x010B8FE8 File Offset: 0x010B71E8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 15;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIMultiTemplateScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(USpineSkeletonAnimationComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060412FB RID: 267003 RVA: 0x010B9208 File Offset: 0x010B7408
		protected override UniTask OnBeforeStartAsync()
		{
			PinballMonsterDetailView.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballMonsterDetailView.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060412FC RID: 267004 RVA: 0x010B924C File Offset: 0x010B744C
		protected override void OnBeforeShow()
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PlayOrReplaySequenceByName("Switch01", false, null);
		}

		// Token: 0x060412FD RID: 267005 RVA: 0x010B9278 File Offset: 0x010B7478
		public void UpdateGridDataList()
		{
			HashSet<int> hashSet = ModelBase<PinballModel>.Instance.CollectMonsterTypesByLevel(this.LevelId);
			PinballMonsterMultiTemplateGridData selectedGridData = this.SelectedGridData;
			int num = (selectedGridData != null) ? selectedGridData.Data.ItemData.Id : 0;
			foreach (int num2 in hashSet)
			{
				EPinballMonsterRiskType riskType = (EPinballMonsterRiskType)ConfigBase<PinballConfig>.Instance.GetPinballMonsterTypeConfigById(num2).Value.RiskType;
				if (!this.TitleDataMap.ContainsKey(riskType))
				{
					PinballMonsterRiskTypeTitleGridData value = new PinballMonsterRiskTypeTitleGridData(ConfigBase<PinballConfig>.Instance.GetPinballMonsterRiskTypeConfigById((int)riskType).Value);
					this.TitleDataMap[riskType] = value;
				}
				List<PinballMonsterMultiTemplateGridData> list;
				if (!this.MonsterDataMap.TryGetValue(riskType, out list))
				{
					list = new List<PinballMonsterMultiTemplateGridData>();
					this.MonsterDataMap[riskType] = list;
				}
				PinballItemDataMonster itemData = new PinballItemDataMonster
				{
					Type = EPinballItemType.Monster,
					Id = num2
				};
				PinballMonsterMultiTemplateGridData item = new PinballMonsterMultiTemplateGridData(new PinballItemSyncMonsterGridViewData
				{
					ItemData = itemData,
					IsSelected = (num2 == num),
					OnStateChangeDelegate = new Action<IPinballItemToggleCallback>(this.OnMonsterGridStateChange)
				});
				list.Add(item);
			}
			using (Dictionary<EPinballMonsterRiskType, List<PinballMonsterMultiTemplateGridData>>.ValueCollection.Enumerator enumerator2 = this.MonsterDataMap.Values.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					enumerator2.Current.Sort((PinballMonsterMultiTemplateGridData a, PinballMonsterMultiTemplateGridData b) => a.Data.ItemData.Id - b.Data.ItemData.Id);
				}
			}
			List<EPinballMonsterRiskType> list2 = new List<EPinballMonsterRiskType>(this.TitleDataMap.Keys);
			list2.Sort((EPinballMonsterRiskType a, EPinballMonsterRiskType b) => b - a);
			foreach (EPinballMonsterRiskType key in list2)
			{
				List<PinballMonsterMultiTemplateGridData> collection = this.MonsterDataMap[key];
				PinballMonsterRiskTypeTitleGridData item2 = this.TitleDataMap[key];
				this.GridDataList.Add(item2);
				this.GridDataList.AddRange(collection);
			}
		}

		// Token: 0x060412FE RID: 267006 RVA: 0x010B94C8 File Offset: 0x010B76C8
		public void SetSelectedGridData(int index)
		{
			if (index < 0 || index >= this.GridDataList.Count)
			{
				return;
			}
			PinballMonsterMultiTemplateGridData selectedGridData = this.SelectedGridData;
			if (selectedGridData != null)
			{
				selectedGridData.Data.IsSelected = false;
			}
			this.SelectedGridIndex = index;
			PinballMonsterMultiTemplateGridData pinballMonsterMultiTemplateGridData = (PinballMonsterMultiTemplateGridData)this.GridDataList[index];
			this.SelectedGridData = pinballMonsterMultiTemplateGridData;
			pinballMonsterMultiTemplateGridData.Data.IsSelected = true;
			this.SelectedSkillIndex = -1;
			int id = pinballMonsterMultiTemplateGridData.Data.ItemData.Id;
			this.SelectedMonsterTypeConfig = ConfigBase<PinballConfig>.Instance.GetPinballMonsterTypeConfigById(id);
			this.UpdateSkillDataList();
			this.SetSelectedSkillIndex(0);
		}

		// Token: 0x060412FF RID: 267007 RVA: 0x010B9560 File Offset: 0x010B7760
		public void UpdateSkillDataList()
		{
			if (this.SelectedGridData == null || this.SelectedMonsterTypeConfig == null)
			{
				return;
			}
			this.SkillConfigList.Clear();
			this.SkillTabItemDataList.Clear();
			int[] array = this.SelectedMonsterTypeConfig.Value.DisplayedSkillList();
			if (array.Length < 0)
			{
				return;
			}
			for (int i = 0; i < array.Length; i++)
			{
				int id = array[i];
				PinballMonsterSkillDisplay? pinballMonsterSkillDisplayConfigById = ConfigBase<PinballConfig>.Instance.GetPinballMonsterSkillDisplayConfigById(id);
				this.SkillConfigList.Add(pinballMonsterSkillDisplayConfigById.Value);
				PinballMonsterSkillTabItemData item = new PinballMonsterSkillTabItemData
				{
					IsSelected = (i == this.SelectedSkillIndex),
					Name = this.SkillTabNameList[i],
					OnSelected = new Action<int>(this.OnSkillTabItemSelected)
				};
				this.SkillTabItemDataList.Add(item);
			}
		}

		// Token: 0x06041300 RID: 267008 RVA: 0x010B9628 File Offset: 0x010B7828
		public void SetSelectedSkillIndex(int index)
		{
			if (index < 0 || index >= this.SkillTabItemDataList.Count)
			{
				return;
			}
			int selectedSkillIndex = this.SelectedSkillIndex;
			if (selectedSkillIndex != -1)
			{
				this.SkillTabItemDataList[selectedSkillIndex].IsSelected = false;
			}
			this.SelectedSkillIndex = index;
			this.SkillTabItemDataList[index].IsSelected = true;
		}

		// Token: 0x06041301 RID: 267009 RVA: 0x010B9680 File Offset: 0x010B7880
		public void RefreshGrids()
		{
			MultiTemplateScrollViewRefreshContext context = new MultiTemplateScrollViewRefreshContext(this.GridDataList);
			MultiTemplateScrollView gridScrollView = this.GridScrollView;
			if (gridScrollView == null)
			{
				return;
			}
			gridScrollView.RefreshByData(context);
		}

		// Token: 0x06041302 RID: 267010 RVA: 0x010B96AC File Offset: 0x010B78AC
		public void SelectGrid(int index)
		{
			int selectedGridIndex = this.SelectedGridIndex;
			if (selectedGridIndex == index)
			{
				return;
			}
			this.SetSelectedGridData(index);
			if (selectedGridIndex != -1)
			{
				MultiTemplateScrollView gridScrollView = this.GridScrollView;
				(((gridScrollView != null) ? gridScrollView.GetProxyByGridIndex(selectedGridIndex) : null) as PinballItemSyncMonsterGridView).RefreshToggleState(false);
			}
			MultiTemplateScrollView gridScrollView2 = this.GridScrollView;
			(((gridScrollView2 != null) ? gridScrollView2.GetProxyByGridIndex(index) : null) as PinballItemSyncMonsterGridView).RefreshToggleState(false);
			this.RefreshMonsterInfo();
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PlayOrReplaySequenceByName("Switch01", false, null);
		}

		// Token: 0x06041303 RID: 267011 RVA: 0x010B9734 File Offset: 0x010B7934
		public void SelectSkill(int index)
		{
			if (index < 0 || index >= this.SkillConfigList.Count)
			{
				return;
			}
			int selectedSkillIndex = this.SelectedSkillIndex;
			this.SetSelectedSkillIndex(index);
			if (selectedSkillIndex != -1)
			{
				GenericLayout<PinballMonsterSkillTabItem, IPinballMonsterSkillTabItemData> skillLayout = this.SkillLayout;
				if (skillLayout != null)
				{
					PinballMonsterSkillTabItem layoutItemByIndex = skillLayout.GetLayoutItemByIndex(selectedSkillIndex);
					if (layoutItemByIndex != null)
					{
						layoutItemByIndex.RefreshToggle(false);
					}
				}
			}
			GenericLayout<PinballMonsterSkillTabItem, IPinballMonsterSkillTabItemData> skillLayout2 = this.SkillLayout;
			if (skillLayout2 != null)
			{
				PinballMonsterSkillTabItem layoutItemByIndex2 = skillLayout2.GetLayoutItemByIndex(index);
				if (layoutItemByIndex2 != null)
				{
					layoutItemByIndex2.RefreshToggle(false);
				}
			}
			this.SkillInfoDirty = true;
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PlayOrReplaySequenceByName("Switch02", false, null);
		}

		// Token: 0x06041304 RID: 267012 RVA: 0x010B97C8 File Offset: 0x010B79C8
		public void RefreshMonsterInfo()
		{
			if (this.SelectedGridData == null || this.SelectedMonsterTypeConfig == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), this.SelectedMonsterTypeConfig.Value.Name, Array.Empty<object>());
			this.SetSpriteByPath(ConfigBase<PinballConfig>.Instance.GetPinballMonsterRiskTypeConfigById(this.SelectedMonsterTypeConfig.Value.RiskType).Value.Icon1, base.GetSprite(14), false, null, null);
			int recommendBd = this.SelectedMonsterTypeConfig.Value.RecommendBd;
			if (recommendBd != 0)
			{
				this.BdItem.SetUiActive(true);
				PinballBdConfig? pinballBdConfigById = ConfigBase<PinballConfig>.Instance.GetPinballBdConfigById(recommendBd);
				PinballRoleClassItemData data = new PinballRoleClassItemData
				{
					Name = pinballBdConfigById.Value.BdName,
					IconPath = pinballBdConfigById.Value.Icon,
					BgColor = pinballBdConfigById.Value.BgColor
				};
				this.BdItem.Refresh(data, false, 0);
			}
			else
			{
				this.BdItem.SetUiActive(false);
			}
			bool flag = this.SkillConfigList.Count > 0;
			base.GetLayoutBase(6).RootUIComp.Get().SetUIActive(flag);
			base.GetItem(8).SetUIActive(!flag);
			base.GetTexture(11).SetUIActive(flag);
			if (flag)
			{
				GenericLayout<PinballMonsterSkillTabItem, IPinballMonsterSkillTabItemData> skillLayout = this.SkillLayout;
				if (skillLayout != null)
				{
					skillLayout.RefreshByData(this.SkillTabItemDataList, null, false);
				}
				this.RefreshSkillInfo();
				return;
			}
			this.RefreshNormalMonsterInfo();
		}

		// Token: 0x06041305 RID: 267013 RVA: 0x010B9964 File Offset: 0x010B7B64
		public void RefreshSkillInfo()
		{
			if (this.SelectedGridData == null)
			{
				return;
			}
			PinballMonsterSkillDisplay pinballMonsterSkillDisplay = this.SkillConfigList[this.SelectedSkillIndex];
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(13), pinballMonsterSkillDisplay.Desc, Array.Empty<object>());
			this.MediaPlayer.PlayVideo(pinballMonsterSkillDisplay.VideoName, pinballMonsterSkillDisplay.VideoPath, true);
		}

		// Token: 0x06041306 RID: 267014 RVA: 0x010B99C4 File Offset: 0x010B7BC4
		public void RefreshNormalMonsterInfo()
		{
			if (this.SelectedGridData == null || this.SelectedMonsterTypeConfig == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(13), this.SelectedMonsterTypeConfig.Value.Desc, Array.Empty<object>());
			USpineSkeletonAnimationComponent spine = base.GetSpine(10);
			base.SetSpineAssetByPath(this.SelectedMonsterTypeConfig.Value.SpineAtlasPath, this.SelectedMonsterTypeConfig.Value.SpineSkeletonDataPath, spine).Forget();
			base.SetTextureByPath(this.SelectedMonsterTypeConfig.Value.SpineBg, base.GetTexture(9), null, null);
		}

		// Token: 0x06041307 RID: 267015 RVA: 0x010B9A78 File Offset: 0x010B7C78
		private void OnMonsterGridStateChange(IPinballItemToggleCallback callbackParameter)
		{
			if (callbackParameter.State == EToggleState.ETT_Checked)
			{
				PinballItemSyncMonsterGridView pinballItemSyncMonsterGridView = callbackParameter.View as PinballItemSyncMonsterGridView;
				this.SelectGrid(pinballItemSyncMonsterGridView.GridIndex);
			}
		}

		// Token: 0x06041308 RID: 267016 RVA: 0x010B9AA6 File Offset: 0x010B7CA6
		private void OnSkillTabItemSelected(int gridIndex)
		{
			this.SelectSkill(gridIndex);
		}

		// Token: 0x06041309 RID: 267017 RVA: 0x010B9AAF File Offset: 0x010B7CAF
		private PinballMonsterSkillTabItem CreateSkillItem()
		{
			return new PinballMonsterSkillTabItem();
		}

		// Token: 0x0604130A RID: 267018 RVA: 0x010B9AB6 File Offset: 0x010B7CB6
		private void OnClickClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x0604130B RID: 267019 RVA: 0x010B9ABF File Offset: 0x010B7CBF
		private void OnEventSequence(string sequenceName, string eventName)
		{
			if (sequenceName == "Switch02" && eventName == "Switch02" && this.SkillInfoDirty)
			{
				this.RefreshSkillInfo();
				this.SkillInfoDirty = false;
			}
		}

		// Token: 0x0604130C RID: 267020 RVA: 0x010B9AF0 File Offset: 0x010B7CF0
		protected override void OnBeforeDestroy()
		{
			MediaPlayer mediaPlayer = this.MediaPlayer;
			if (mediaPlayer != null)
			{
				mediaPlayer.Clear();
			}
			this.MediaPlayer = null;
		}

		// Token: 0x040247F3 RID: 149491
		protected int LevelId;

		// Token: 0x040247F4 RID: 149492
		protected int SelectedGridIndex;

		// Token: 0x040247F5 RID: 149493
		[Nullable(2)]
		protected PinballMonsterMultiTemplateGridData SelectedGridData;

		// Token: 0x040247F6 RID: 149494
		protected PinballMonsterType? SelectedMonsterTypeConfig;

		// Token: 0x040247F7 RID: 149495
		protected int SelectedSkillIndex;

		// Token: 0x040247F8 RID: 149496
		protected List<IMultiTemplateGridData> GridDataList;

		// Token: 0x040247F9 RID: 149497
		protected Dictionary<EPinballMonsterRiskType, PinballMonsterRiskTypeTitleGridData> TitleDataMap;

		// Token: 0x040247FA RID: 149498
		protected Dictionary<EPinballMonsterRiskType, List<PinballMonsterMultiTemplateGridData>> MonsterDataMap;

		// Token: 0x040247FB RID: 149499
		protected List<IPinballMonsterSkillTabItemData> SkillTabItemDataList;

		// Token: 0x040247FC RID: 149500
		protected List<PinballMonsterSkillDisplay> SkillConfigList;

		// Token: 0x040247FD RID: 149501
		private string[] SkillTabNameList;

		// Token: 0x040247FE RID: 149502
		[Nullable(2)]
		private MediaPlayer MediaPlayer;

		// Token: 0x040247FF RID: 149503
		[Nullable(2)]
		protected MultiTemplateScrollView GridScrollView;

		// Token: 0x04024800 RID: 149504
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericLayout<PinballMonsterSkillTabItem, IPinballMonsterSkillTabItemData> SkillLayout;

		// Token: 0x04024801 RID: 149505
		[Nullable(2)]
		protected PinballRoleClassItem BdItem;

		// Token: 0x04024802 RID: 149506
		[Nullable(2)]
		protected PopupCaptionItem CaptionItem;

		// Token: 0x04024803 RID: 149507
		private bool SkillInfoDirty;

		// Token: 0x0200C5F5 RID: 50677
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x0403CEF3 RID: 249587
			CaptionItem,
			// Token: 0x0403CEF4 RID: 249588
			MultiTemplateScrollView,
			// Token: 0x0403CEF5 RID: 249589
			TitleTemplateItem,
			// Token: 0x0403CEF6 RID: 249590
			MonsterGridTemplateItem,
			// Token: 0x0403CEF7 RID: 249591
			NameText,
			// Token: 0x0403CEF8 RID: 249592
			BdItem,
			// Token: 0x0403CEF9 RID: 249593
			SkillLayout,
			// Token: 0x0403CEFA RID: 249594
			SkillItem,
			// Token: 0x0403CEFB RID: 249595
			MonsterSpineRootItem,
			// Token: 0x0403CEFC RID: 249596
			MonsterBgTexture,
			// Token: 0x0403CEFD RID: 249597
			MonsterSpine,
			// Token: 0x0403CEFE RID: 249598
			CGTexture,
			// Token: 0x0403CEFF RID: 249599
			InfoScrollView,
			// Token: 0x0403CF00 RID: 249600
			DescText,
			// Token: 0x0403CF01 RID: 249601
			TypeIconSprite
		}
	}
}
