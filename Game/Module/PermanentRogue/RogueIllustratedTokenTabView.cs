using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x02005686 RID: 22150
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueIllustratedTokenTabView : UiTabViewBase
	{
		// Token: 0x060386D3 RID: 231123 RVA: 0x00E4AA04 File Offset: 0x00E48C04
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUITexture)),
				new ValueTuple<int, Type>(10, typeof(UUINiagara))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(2, new Action(this.OnClickGetAllReward)),
				new ValueTuple<int, Delegate>(6, new Action(delegate()
				{
					this.OnClickGetReward(null);
				}))
			};
		}

		// Token: 0x060386D4 RID: 231124 RVA: 0x00E4AB4C File Offset: 0x00E48D4C
		protected override UniTask OnBeforeStartAsync()
		{
			RogueIllustratedTokenTabView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueIllustratedTokenTabView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060386D5 RID: 231125 RVA: 0x00E4AB8F File Offset: 0x00E48D8F
		protected override void OnBeforeShow()
		{
			this.RefreshItemData();
		}

		// Token: 0x060386D6 RID: 231126 RVA: 0x00E4AB97 File Offset: 0x00E48D97
		protected override void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.PermanentRogueRewardUpdate, new Action(this.OnGetRewardUpdate));
		}

		// Token: 0x060386D7 RID: 231127 RVA: 0x00E4ABB5 File Offset: 0x00E48DB5
		protected override void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.PermanentRogueRewardUpdate, new Action(this.OnGetRewardUpdate));
		}

		// Token: 0x060386D8 RID: 231128 RVA: 0x00E4ABD3 File Offset: 0x00E48DD3
		protected override void OnStart()
		{
			this.RefreshGetAllRewardBtn();
		}

		// Token: 0x060386D9 RID: 231129 RVA: 0x00E4ABDB File Offset: 0x00E48DDB
		protected override void OnBeforeDestroy()
		{
			this.SelectedItemViewData = null;
			this.ItemScrollView = null;
			this.RewardItemBtn = null;
		}

		// Token: 0x060386DA RID: 231130 RVA: 0x00E4ABF2 File Offset: 0x00E48DF2
		private void InitializeItemScrollView()
		{
			this.ItemScrollView = new LoopScrollView<RogueIllustratedTokenMediumItemGrid, RogueTokenViewData>(base.GetLoopScrollViewComponent(0), base.GetItem(7).GetOwner() as AUIBaseActor, new Func<RogueIllustratedTokenMediumItemGrid>(this.OnGridProxyCreate), false);
		}

		// Token: 0x060386DB RID: 231131 RVA: 0x00E4AC24 File Offset: 0x00E48E24
		private void RefreshItemData()
		{
			RogueResTheme? config = ((RogueIllustratedTabData)this.Params).Config;
			this.ItemViewDataList = this.GenerateTokenViewData(config);
			this.ItemScrollView.RefreshByData(this.ItemViewDataList, false, delegate
			{
				this.OnItemButtonClicked(this.ItemViewDataList[0]);
			}, true);
			int[] tokenCount = ModelBase<ActivityPermanentRogueModel>.Instance.GetTokenCount((config != null) ? config.GetValueOrDefault().Id : 0);
			LguiUtil instance = Singleton<LguiUtil>.Instance;
			UUIText text = base.GetText(3);
			string textStringId = "RogueRes_UnlockProgress";
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(tokenCount[0]);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(tokenCount[1]);
			instance.SetLocalTextNew(text, textStringId, new <>z__ReadOnlySingleElementList<object>(defaultInterpolatedStringHandler.ToStringAndClear()));
		}

		// Token: 0x060386DC RID: 231132 RVA: 0x00E4ACDF File Offset: 0x00E48EDF
		private RogueIllustratedTokenMediumItemGrid OnGridProxyCreate()
		{
			RogueIllustratedTokenMediumItemGrid rogueIllustratedTokenMediumItemGrid = new RogueIllustratedTokenMediumItemGrid();
			rogueIllustratedTokenMediumItemGrid.BindOnItemButtonClickedCallback(new Action<RogueTokenViewData>(this.OnItemButtonClicked));
			return rogueIllustratedTokenMediumItemGrid;
		}

		// Token: 0x060386DD RID: 231133 RVA: 0x00E4ACF8 File Offset: 0x00E48EF8
		private void OnItemButtonClicked(RogueTokenViewData data)
		{
			if (this.SelectedItemViewData == data)
			{
				int gridIndex = this.ItemViewDataList.IndexOf(data);
				this.ItemScrollView.DeselectCurrentGridProxy(false);
				this.ItemScrollView.SelectGridProxy(gridIndex, false);
				return;
			}
			this.SelectedItem(data);
		}

		// Token: 0x060386DE RID: 231134 RVA: 0x00E4AD3C File Offset: 0x00E48F3C
		private void OnClickGetAllReward()
		{
			RogueResTheme? config = ((RogueIllustratedTabData)this.Params).Config;
			HashSet<int> tokenIndexSet = ModelBase<ActivityPermanentRogueModel>.Instance.GetTokenIndexSet(config);
			List<int> list = new List<int>();
			foreach (int num in tokenIndexSet)
			{
				if (ModelBase<ActivityPermanentRogueModel>.Instance.GetCollectItemState(num) == SignState.Unlock)
				{
					list.Add(num);
				}
			}
			(ActivityManager.GetActivityController(ActivityType.RogueRes) as ActivityPermanentRogueController).RequestIllustrationAward(list.ToArray());
		}

		// Token: 0x060386DF RID: 231135 RVA: 0x00E4ADD0 File Offset: 0x00E48FD0
		private void OnClickGetReward(MediumItemGridExtendCallback _)
		{
			if (this.SelectedItemViewData == null)
			{
				return;
			}
			if (ModelBase<ActivityPermanentRogueModel>.Instance.GetCollectItemState(this.SelectedItemViewData.GetCollectionIndex()) != SignState.Unlock)
			{
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.CurRewardItemId, true, null);
				return;
			}
			(ActivityManager.GetActivityController(ActivityType.RogueRes) as ActivityPermanentRogueController).RequestIllustrationAward(new int[]
			{
				this.SelectedItemViewData.GetCollectionIndex()
			});
		}

		// Token: 0x060386E0 RID: 231136 RVA: 0x00E4AE38 File Offset: 0x00E49038
		private List<RogueTokenViewData> GenerateTokenViewData(RogueResTheme? config)
		{
			IEnumerable<int> tokenIndexSet = ModelBase<ActivityPermanentRogueModel>.Instance.GetTokenIndexSet(config);
			List<RogueTokenViewData> list = new List<RogueTokenViewData>();
			List<int> list2 = new List<int>(tokenIndexSet);
			list2.Sort(delegate(int a, int b)
			{
				int num = RogueIllustratedTokenTabView.<GenerateTokenViewData>g__stateSwitch|19_0(ModelBase<ActivityPermanentRogueModel>.Instance.GetCollectItemState(a));
				int num2 = RogueIllustratedTokenTabView.<GenerateTokenViewData>g__stateSwitch|19_0(ModelBase<ActivityPermanentRogueModel>.Instance.GetCollectItemState(b));
				if (num != num2)
				{
					return num - num2;
				}
				RogueResCollection? config2 = ConfigRogueResCollectionByIdKey.GetConfig(a, true);
				RogueResCollection? config3 = ConfigRogueResCollectionByIdKey.GetConfig(b, true);
				RogueResBuffPool? config4 = ConfigRogueResBuffPoolById.GetConfig(config2.Value.Id, true);
				RogueResBuffPool? config5 = ConfigRogueResBuffPoolById.GetConfig(config3.Value.Id, true);
				int? num3 = (config4 != null) ? new int?(config4.GetValueOrDefault().Quality) : null;
				int? num4 = (config5 != null) ? new int?(config5.GetValueOrDefault().Quality) : null;
				if (!(num3.GetValueOrDefault() == num4.GetValueOrDefault() & num3 != null == (num4 != null)))
				{
					return config5.Value.Quality - config4.Value.Quality;
				}
				if (config2.Value.SortId != config3.Value.SortId)
				{
					return config2.Value.SortId - config3.Value.SortId;
				}
				return config2.Value.Id - config3.Value.Id;
			});
			foreach (int indexId in list2)
			{
				RogueTokenViewData item = this.CreateTokenViewData(indexId);
				list.Add(item);
			}
			return list;
		}

		// Token: 0x060386E1 RID: 231137 RVA: 0x00E4AECC File Offset: 0x00E490CC
		[NullableContext(2)]
		private void SelectedItem(RogueTokenViewData data)
		{
			if (data == null)
			{
				return;
			}
			this.RefreshSelectedItemView(data);
		}

		// Token: 0x060386E2 RID: 231138 RVA: 0x00E4AEDC File Offset: 0x00E490DC
		private void RefreshSelectedItemView(RogueTokenViewData itemViewData)
		{
			if (this.SelectedItemViewData != null)
			{
				this.ItemScrollView.DeselectCurrentGridProxy(false);
			}
			int gridIndex = this.ItemViewDataList.IndexOf(itemViewData);
			if (!this.ItemScrollView.IsGridDisplaying(gridIndex))
			{
				this.ItemScrollView.ScrollToGridIndex(gridIndex, true);
			}
			this.SelectedItemViewData = itemViewData;
			this.ItemScrollView.SelectGridProxy(gridIndex, true);
			this.ItemScrollView.RefreshGridProxy(gridIndex);
			this.RefreshItemTipsComp(itemViewData);
			RogueResCollection? config = ConfigRogueResCollectionByIdKey.GetConfig(itemViewData.GetCollectionIndex(), true);
			SignState collectItemState = ModelBase<ActivityPermanentRogueModel>.Instance.GetCollectItemState(config.Value.IdKey);
			UUIItem item = base.GetItem(5);
			if (collectItemState == SignState.IsReceive)
			{
				item.SetUIActive(false);
				return;
			}
			item.SetUIActive(this.RefreshRewardItemGrid(config.Value.Award, collectItemState == SignState.Lock));
		}

		// Token: 0x060386E3 RID: 231139 RVA: 0x00E4AFA8 File Offset: 0x00E491A8
		public void RefreshItemTipsComp(RogueTokenViewData itemViewData)
		{
			RogueResGainData tokenTipsData = ModelBase<ActivityPermanentRogueModel>.Instance.GetTokenTipsData(itemViewData.GetConfigId());
			RogueIllustratedTokenItem infoItem = this.InfoItem;
			if (infoItem == null)
			{
				return;
			}
			infoItem.Refresh(tokenTipsData, true, 0);
		}

		// Token: 0x060386E4 RID: 231140 RVA: 0x00E4AFDC File Offset: 0x00E491DC
		private RogueTokenViewData CreateTokenViewData(int indexId)
		{
			RogueResCollection? config = ConfigRogueResCollectionByIdKey.GetConfig(indexId, true);
			ActivityPermanentRogueModel instance = ModelBase<ActivityPermanentRogueModel>.Instance;
			SignState? signState = (instance != null) ? new SignState?(instance.GetCollectItemState(indexId)) : null;
			IllustratedTokenDataInfo illustratedTokenDataInfo = new IllustratedTokenDataInfo();
			illustratedTokenDataInfo.ConfigId = config.Value.Id;
			illustratedTokenDataInfo.CollectionIndex = indexId;
			SignState? signState2 = signState;
			SignState signState3 = SignState.Lock;
			illustratedTokenDataInfo.IsLock = (signState2.GetValueOrDefault() == signState3 & signState2 != null);
			illustratedTokenDataInfo.HasRedDot = (signState.GetValueOrDefault() == SignState.Unlock);
			illustratedTokenDataInfo.IsSelectOn = false;
			return new RogueTokenViewData(illustratedTokenDataInfo);
		}

		// Token: 0x060386E5 RID: 231141 RVA: 0x00E4B06C File Offset: 0x00E4926C
		private bool RefreshRewardItemGrid(int rewardId, bool isLock)
		{
			DropPackage? dropPackage = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(rewardId);
			if (dropPackage == null)
			{
				return false;
			}
			using (IEnumerator<DicIntInt> enumerator = dropPackage.Value.DropPreviewIter().GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					DicIntInt dicIntInt = enumerator.Current;
					PropSmallItemGrid parameters = new PropSmallItemGrid
					{
						Data = null,
						ItemConfigId = new int?(dicIntInt.Key),
						BottomText = dicIntInt.Value.ToString()
					};
					this.CurRewardItemId = dicIntInt.Key;
					this.RewardItemBtn.Apply<PropSmallItemGrid>(parameters);
					this.RewardItemBtn.SetLockBlackVisible(isLock);
					this.RewardItemBtn.SetReceivableVisible(!isLock);
				}
			}
			string textStringId = isLock ? "RogueRes_Lock" : "RogueRes_Unlock";
			FColor changeColor = base.GetTexture(9).changeColor;
			UUIItem texture = base.GetTexture(9);
			bool bUseChangeColor = !isLock;
			FColor? fcolor = new FColor?(changeColor);
			texture.SetChangeColor(bUseChangeColor, fcolor);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), textStringId, Array.Empty<object>());
			UUIButtonComponent button = base.GetButton(6);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(!isLock);
			}
			if (base.GetUiNiagara(10).GetIsActive() && !isLock)
			{
				base.GetUiNiagara(10).ActivateSystem(true);
			}
			else
			{
				base.GetUiNiagara(10).SetUIActive(!isLock);
			}
			return true;
		}

		// Token: 0x060386E6 RID: 231142 RVA: 0x00E4B1EC File Offset: 0x00E493EC
		private void RefreshGetAllRewardBtn()
		{
			RogueResTheme? config = ((RogueIllustratedTabData)this.Params).Config;
			bool haveTokenAward = ModelBase<ActivityPermanentRogueModel>.Instance.GetHaveTokenAward((config != null) ? config.GetValueOrDefault().Id : 0);
			UUIButtonComponent button = base.GetButton(2);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(haveTokenAward);
		}

		// Token: 0x060386E7 RID: 231143 RVA: 0x00E4B250 File Offset: 0x00E49450
		private void OnGetRewardUpdate()
		{
			this.RefreshGetAllRewardBtn();
			RogueResTheme? config = ((RogueIllustratedTabData)this.Params).Config;
			RogueTokenViewData selectedItemViewData = this.SelectedItemViewData;
			int? num = (selectedItemViewData != null) ? new int?(selectedItemViewData.GetConfigId()) : null;
			this.ItemViewDataList = this.GenerateTokenViewData(config);
			foreach (RogueTokenViewData rogueTokenViewData in this.ItemViewDataList)
			{
				int? num2 = num;
				int configId = rogueTokenViewData.GetConfigId();
				if (num2.GetValueOrDefault() == configId & num2 != null)
				{
					this.SelectedItemViewData = rogueTokenViewData;
					break;
				}
			}
			this.ItemScrollView.UpdateData(this.ItemViewDataList);
			this.RefreshSelectedItemView(this.SelectedItemViewData);
		}

		// Token: 0x060386EB RID: 231147 RVA: 0x00E4B358 File Offset: 0x00E49558
		[CompilerGenerated]
		internal static int <GenerateTokenViewData>g__stateSwitch|19_0(SignState a)
		{
			if (a == SignState.Lock)
			{
				return 2;
			}
			if (a != SignState.Unlock)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x0402033B RID: 131899
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<RogueIllustratedTokenMediumItemGrid, RogueTokenViewData> ItemScrollView;

		// Token: 0x0402033C RID: 131900
		private List<RogueTokenViewData> ItemViewDataList = new List<RogueTokenViewData>();

		// Token: 0x0402033D RID: 131901
		[Nullable(2)]
		private RogueTokenViewData SelectedItemViewData;

		// Token: 0x0402033E RID: 131902
		private int CurRewardItemId;

		// Token: 0x0402033F RID: 131903
		[Nullable(2)]
		private RogueIllustratedTokenItem InfoItem;

		// Token: 0x04020340 RID: 131904
		[Nullable(2)]
		private SmallItemGrid RewardItemBtn;
	}
}
