using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005969 RID: 22889
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRogueRewardView : UiViewBase
	{
		// Token: 0x0603A00B RID: 237579 RVA: 0x00EAD60F File Offset: 0x00EAB80F
		public MapRogueRewardView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603A00C RID: 237580 RVA: 0x00EAD620 File Offset: 0x00EAB820
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(4, new Action(this.OnGiveUpBtnClick))
			};
		}

		// Token: 0x0603A00D RID: 237581 RVA: 0x00EAD6E0 File Offset: 0x00EAB8E0
		protected override UniTask OnBeforeStartAsync()
		{
			MapRogueRewardView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MapRogueRewardView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A00E RID: 237582 RVA: 0x00EAD724 File Offset: 0x00EAB924
		protected override void OnStart()
		{
			this.OpIncId = (int)this.OpenParam;
			this.RewardLayout = new GenericLayout<RewardItemToggle, MapRogueRewardItemData>(base.GetHorizontalLayout(2), new Func<RewardItemToggle>(this.OnCreateRewardItem), null, false, true);
			this.OpData = (ModelBase<MapRogueModel>.Instance.GetOpData(this.OpIncId) as MapRogueOpSelectView);
			this.OpData.CloseViewFunc = new Action(this.CloseSelf);
			this.OpData.UpdateViewFunc = new Action(this.Refresh);
			IList<RogueResGainData> gainDataList = this.OpData.GetGainDataList();
			this.IsAllSelect = (gainDataList.Count == this.OpData.MaxSelectCount);
		}

		// Token: 0x0603A00F RID: 237583 RVA: 0x00EAD7D2 File Offset: 0x00EAB9D2
		protected override void OnBeforeShow()
		{
			this.Refresh();
		}

		// Token: 0x0603A010 RID: 237584 RVA: 0x00EAD7DA File Offset: 0x00EAB9DA
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		}

		// Token: 0x0603A011 RID: 237585 RVA: 0x00EAD7F8 File Offset: 0x00EAB9F8
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		}

		// Token: 0x0603A012 RID: 237586 RVA: 0x00EAD818 File Offset: 0x00EABA18
		protected void Refresh()
		{
			if (this.OpData == null)
			{
				return;
			}
			if (this.CurrentSelectIndex >= 0)
			{
				RewardItemToggle layoutItemByKey = this.RewardLayout.GetLayoutItemByKey(this.CurrentSelectIndex);
				if (layoutItemByKey != null)
				{
					layoutItemByKey.SetToggleState(false, true);
				}
			}
			if (this.IsAllSelect)
			{
				base.GetButton(4).RootUIComp.Get().SetUIActive(false);
				ButtonItem btnConfirmInstance = this.BtnConfirmInstance;
				if (btnConfirmInstance != null)
				{
					btnConfirmInstance.SetLocalTextNew("RogueRes_FightGetAllItem_Desc", Array.Empty<object>());
				}
				ButtonItem btnConfirmInstance2 = this.BtnConfirmInstance;
				if (btnConfirmInstance2 != null)
				{
					btnConfirmInstance2.SetEnableClick(true);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "RogueRes_FightBooty_Desc", Array.Empty<object>());
			}
			else
			{
				base.GetButton(4).RootUIComp.Get().SetUIActive(this.OpData.CanGiveUp);
				base.GetButton(4).SetSelfInteractive(!this.OpData.IsMax);
				ButtonItem btnConfirmInstance3 = this.BtnConfirmInstance;
				if (btnConfirmInstance3 != null)
				{
					btnConfirmInstance3.SetLocalTextNew("RogueRes_FightGetItem_Desc", Array.Empty<object>());
				}
				ButtonItem btnConfirmInstance4 = this.BtnConfirmInstance;
				if (btnConfirmInstance4 != null)
				{
					btnConfirmInstance4.SetEnableClick(false);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "RogueRes_Event_Rewards_3", new <>z__ReadOnlyArray<object>(new object[]
				{
					this.OpData.CurrentSelectCount,
					this.OpData.MaxSelectCount
				}));
			}
			this.RefreshLayout();
		}

		// Token: 0x0603A013 RID: 237587 RVA: 0x00EAD984 File Offset: 0x00EABB84
		private void RefreshLayout()
		{
			if (this.OpData == null)
			{
				return;
			}
			List<MapRogueRewardItemData> data = this.CreateRewardItemDataList();
			this.RewardLayout.RefreshByData(data, null, true);
		}

		// Token: 0x0603A014 RID: 237588 RVA: 0x00EAD9AF File Offset: 0x00EABBAF
		private void OnActivitySequenceEmitEvent(string param)
		{
			if ("InturnPlay" == param)
			{
				this.RefreshLayout();
			}
		}

		// Token: 0x0603A015 RID: 237589 RVA: 0x00EAD9C4 File Offset: 0x00EABBC4
		private int SortRewardData(MapRogueRewardItemData a, MapRogueRewardItemData b)
		{
			int num = (a.IsRole > false) ? 1 : 0;
			int num2 = (b.IsRole > false) ? 1 : 0;
			if (num != num2)
			{
				return num2 - num;
			}
			if (num == 1 && num2 == 1)
			{
				return 0;
			}
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(a.ConfigId);
			ItemConfig itemConfigData2 = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(b.ConfigId);
			if (itemConfigData.QualityId != itemConfigData2.QualityId)
			{
				return itemConfigData2.QualityId - itemConfigData.QualityId;
			}
			return 0;
		}

		// Token: 0x0603A016 RID: 237590 RVA: 0x00EADA36 File Offset: 0x00EABC36
		private RewardItemToggle OnCreateRewardItem()
		{
			return new RewardItemToggle
			{
				IsAllSelect = this.IsAllSelect,
				OnExtendToggleClicked = new Action<bool, MapRogueRewardItemData>(this.OnExtendToggleClicked),
				OnCanExecuteChangeFunc = new Func<bool, MapRogueRewardItemData, bool>(this.OnCanExecuteChangeFunc)
			};
		}

		// Token: 0x0603A017 RID: 237591 RVA: 0x00EADA6D File Offset: 0x00EABC6D
		public override void CloseSelf()
		{
			if (this.OpData != null)
			{
				this.OpData.CloseViewFunc = null;
				this.OpData.UpdateViewFunc = null;
			}
			base.CloseMe(null);
		}

		// Token: 0x0603A018 RID: 237592 RVA: 0x00EADA98 File Offset: 0x00EABC98
		private void OnGiveUpBtnClick()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.MapRogueGiveUpReward);
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				this.OpData.Select(-2);
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603A019 RID: 237593 RVA: 0x00EADAD4 File Offset: 0x00EABCD4
		private void OnConfirmBtnClick(int _)
		{
			if (this.IsAllSelect)
			{
				List<MapRogueRewardItemData> list = this.CreateRewardItemDataList();
				List<int> list2 = new List<int>();
				foreach (MapRogueRewardItemData mapRogueRewardItemData in list)
				{
					list2.Add(mapRogueRewardItemData.Index);
				}
				this.OpData.SelectAll(list2);
				return;
			}
			this.OpData.Select(this.CurrentSelectIndex);
		}

		// Token: 0x0603A01A RID: 237594 RVA: 0x00EADB58 File Offset: 0x00EABD58
		private List<MapRogueRewardItemData> CreateRewardItemDataList()
		{
			IList<RogueResGainData> gainDataList = this.OpData.GetGainDataList();
			List<MapRogueRewardItemData> list = new List<MapRogueRewardItemData>();
			for (int i = 0; i < gainDataList.Count; i++)
			{
				RogueResComplex rogueResComplex = gainDataList[i].RogueResComplex;
				if (rogueResComplex != null)
				{
					MapRogueRewardItemData item = new MapRogueRewardItemData
					{
						Index = i,
						ConfigId = rogueResComplex.ItemId,
						Count = rogueResComplex.Count,
						IsSelect = (!this.IsAllSelect && rogueResComplex.IsSelect),
						IsRole = rogueResComplex.IsRole
					};
					list.Add(item);
				}
			}
			list.Sort(new Comparison<MapRogueRewardItemData>(this.SortRewardData));
			return list;
		}

		// Token: 0x0603A01B RID: 237595 RVA: 0x00EADBFC File Offset: 0x00EABDFC
		private void UnSelect()
		{
			this.CurrentSelectIndex = -1;
			base.GetButton(5).SetSelfInteractive(false);
		}

		// Token: 0x0603A01C RID: 237596 RVA: 0x00EADC14 File Offset: 0x00EABE14
		private void Select(MapRogueRewardItemData data)
		{
			if (this.CurrentSelectIndex >= 0)
			{
				RewardItemToggle layoutItemByKey = this.RewardLayout.GetLayoutItemByKey(this.CurrentSelectIndex);
				if (layoutItemByKey != null)
				{
					layoutItemByKey.SetToggleState(false, false);
				}
			}
			this.CurrentSelectIndex = data.Index;
			base.GetButton(5).SetSelfInteractive(!data.IsSelect);
		}

		// Token: 0x0603A01D RID: 237597 RVA: 0x00EADC6E File Offset: 0x00EABE6E
		private void OnExtendToggleClicked(bool state, MapRogueRewardItemData data)
		{
			if (state)
			{
				this.Select(data);
				return;
			}
			if (this.CurrentSelectIndex == data.Index)
			{
				this.UnSelect();
			}
		}

		// Token: 0x0603A01E RID: 237598 RVA: 0x00EADC8F File Offset: 0x00EABE8F
		private bool OnCanExecuteChangeFunc(bool state, MapRogueRewardItemData data)
		{
			return state || !this.OpData.IsMax;
		}

		// Token: 0x04020E0C RID: 134668
		private const string START_ANIM_EVENT = "InturnPlay";

		// Token: 0x04020E0D RID: 134669
		private int OpIncId;

		// Token: 0x04020E0E RID: 134670
		[Nullable(2)]
		protected MapRoguePopupBase BgItem;

		// Token: 0x04020E0F RID: 134671
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericLayout<RewardItemToggle, MapRogueRewardItemData> RewardLayout;

		// Token: 0x04020E10 RID: 134672
		[Nullable(2)]
		protected ButtonItem BtnConfirmInstance;

		// Token: 0x04020E11 RID: 134673
		[Nullable(2)]
		protected MapRogueOpSelectView OpData;

		// Token: 0x04020E12 RID: 134674
		protected int CurrentSelectIndex = -1;

		// Token: 0x04020E13 RID: 134675
		private bool IsAllSelect;
	}
}
