using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200514C RID: 20812
	[NullableContext(2)]
	[Nullable(0)]
	public class CommonSelectView : RogueSelectBaseView
	{
		// Token: 0x06035910 RID: 219408 RVA: 0x00D72BFE File Offset: 0x00D70DFE
		[NullableContext(1)]
		public CommonSelectView(UiViewInfo Info) : base(Info)
		{
		}

		// Token: 0x06035911 RID: 219409 RVA: 0x00D72C10 File Offset: 0x00D70E10
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035912 RID: 219410 RVA: 0x00D72D64 File Offset: 0x00D70F64
		private void ConfirmBtn(int _)
		{
			CommonSelectItem commonSelectItem = this.GetCommonSelectItem();
			if (commonSelectItem == null)
			{
				return;
			}
			ModelBase<RoguelikeModel>.Instance.CurrentRogueGainEntry = commonSelectItem.RogueGainEntry;
			ControllerBase<RoguelikeController>.Instance.RogueChooseDataResultRequest(EPerkType.Phantom);
		}

		// Token: 0x06035913 RID: 219411 RVA: 0x00D72D98 File Offset: 0x00D70F98
		private void RefreshBtn(int _)
		{
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			if (serverTime - this.LastRefreshTime < 1.0 && this.LastRefreshTime != 0.0)
			{
				return;
			}
			this.LastRefreshTime = serverTime;
			ControllerBase<RoguelikeController>.Instance.RoguelikeRefreshGainRequest(this.RoguelikeChooseData.Index);
		}

		// Token: 0x06035914 RID: 219412 RVA: 0x00D72DF4 File Offset: 0x00D70FF4
		private CommonSelectItem GetCommonSelectItem()
		{
			foreach (CommonSelectItem commonSelectItem in this.CommonSelectItemLayout.GetLayoutItemList())
			{
				if (commonSelectItem.IsSelect())
				{
					return commonSelectItem;
				}
			}
			return null;
		}

		// Token: 0x06035915 RID: 219413 RVA: 0x00D72E54 File Offset: 0x00D71054
		protected override UniTask OnBeforeStartAsync()
		{
			CommonSelectView.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CommonSelectView.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035916 RID: 219414 RVA: 0x00D72E98 File Offset: 0x00D71098
		protected unsafe override void OnStart()
		{
			ModelBase<RoguelikeModel>.Instance.CurrentRogueGainEntry = null;
			this.RoguelikeChooseData = (this.OpenParam as RoguelikeChooseData);
			this.TopPanel.CloseCallback = new Action(base.CloseMySelf);
			this.PhantomInfoPanel.Update(ModelBase<RoguelikeModel>.Instance.RogueInfo.PhantomEntry);
			this.ButtonItem = new ButtonItem(base.GetButton(5).GetRootComponent());
			this.ButtonItem.SetFunction(new Action<int>(this.ConfirmBtn));
			this.RefreshButtonItem = new ButtonItem(base.GetButton(6).GetRootComponent());
			this.RefreshButtonItem.SetFunction(new Action<int>(this.RefreshBtn));
			this.CommonSelectItemLayout = new GenericLayout<CommonSelectItem, RogueGainEntry>(base.GetHorizontalLayout(2), new Func<CommonSelectItem>(this.CreateCommonSelectItem), null, false, true);
			TopPanel topPanel = this.TopPanel;
			if (topPanel != null)
			{
				int num = 1;
				List<int> list = new List<int>(num);
				CollectionsMarshal.SetCount<int>(list, num);
				Span<int> span = CollectionsMarshal.AsSpan<int>(list);
				int index = 0;
				*span[index] = 80100000;
				topPanel.RefreshCurrency(list);
			}
			this.Refresh();
		}

		// Token: 0x06035917 RID: 219415 RVA: 0x00D72FAD File Offset: 0x00D711AD
		protected override void OnBeforeShow()
		{
			if (!this.IsFirstOpen)
			{
				TopPanel topPanel = this.TopPanel;
				if (topPanel != null)
				{
					topPanel.RefreshTabBtn();
				}
				this.OnDescModelChange();
				return;
			}
			this.IsFirstOpen = false;
		}

		// Token: 0x06035918 RID: 219416 RVA: 0x00D72FD6 File Offset: 0x00D711D6
		[NullableContext(1)]
		protected CommonSelectItem CreateCommonSelectItem()
		{
			CommonSelectItem commonSelectItem = new CommonSelectItem();
			commonSelectItem.SetClickCallBack(new Action<CommonSelectItem>(this.RefreshPreview));
			return commonSelectItem;
		}

		// Token: 0x06035919 RID: 219417 RVA: 0x00D72FEF File Offset: 0x00D711EF
		protected override void OnBeforeDestroy()
		{
			this.TopPanel.Destroy(null);
			this.ElementPanel.Destroy(null);
			this.PhantomInfoPanel.Destroy(null);
		}

		// Token: 0x0603591A RID: 219418 RVA: 0x00D73018 File Offset: 0x00D71218
		[NullableContext(1)]
		protected override void RoguelikeChooseDataResult(RogueGainEntry newRogueGainEntry, RogueGainEntry oldRogueGainEntry, bool isSuccess, int bindId, RoguelikeChooseDataResultResponse response)
		{
			if (isSuccess)
			{
				RoguelikeChooseData roguelikeChooseData = this.RoguelikeChooseData;
				int? num = (roguelikeChooseData != null) ? new int?(roguelikeChooseData.Index) : null;
				if (bindId == num.GetValueOrDefault() & num != null)
				{
					CommonSelectItem commonSelectItem = this.GetCommonSelectItem();
					if (commonSelectItem == null)
					{
						return;
					}
					RogueSelectResult rogueSelectResult = new RogueSelectResult(newRogueGainEntry, oldRogueGainEntry, commonSelectItem.RogueGainEntry, false);
					bool flag = response.ExtraRogueGainEntrys.Count > 0;
					if (flag)
					{
						rogueSelectResult.IsShowCommon = true;
						using (IEnumerator<RogueGainEntry> enumerator = response.ExtraRogueGainEntrys.GetEnumerator())
						{
							if (enumerator.MoveNext())
							{
								RogueGainEntry rogueGainEntry = enumerator.Current;
								rogueSelectResult.ExtraRogueGainEntry = new RogueGainEntry(rogueGainEntry, null);
							}
						}
					}
					if (rogueSelectResult.GetNewUnlockAffixEntry().Count <= 0 && !flag)
					{
						Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
						return;
					}
					Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonSelectResultView, rogueSelectResult, delegate(bool _, int _)
					{
						base.CloseMe(null);
					});
					return;
				}
			}
		}

		// Token: 0x0603591B RID: 219419 RVA: 0x00D73130 File Offset: 0x00D71330
		protected override void OnDescModelChange()
		{
			foreach (CommonSelectItem commonSelectItem in this.CommonSelectItemLayout.GetLayoutItemList())
			{
				commonSelectItem.RefreshPanel();
			}
			this.RefreshPreview(this.CurSelectItem);
		}

		// Token: 0x0603591C RID: 219420 RVA: 0x00D73194 File Offset: 0x00D71394
		protected override void RoguelikeRefreshGain(int index)
		{
			ModelBase<RoguelikeModel>.Instance.CurrentRogueGainEntry = null;
			RoguelikeChooseData roguelikeChooseDataById = ModelBase<RoguelikeModel>.Instance.GetRoguelikeChooseDataById(index);
			this.RoguelikeChooseData = roguelikeChooseDataById;
			this.Refresh();
		}

		// Token: 0x0603591D RID: 219421 RVA: 0x00D731C5 File Offset: 0x00D713C5
		private void Refresh()
		{
			this.RefreshPhantomSelectItemList();
			this.RefreshTopPanel();
			this.RefreshElementPanel();
			this.RefreshPhantomInfoPanel();
			this.RefreshPreview(this.CurSelectItem);
			this.RefreshBtnText();
			this.RefreshRefreshBtnText();
		}

		// Token: 0x0603591E RID: 219422 RVA: 0x00D731F7 File Offset: 0x00D713F7
		protected void RefreshPhantomSelectItemList()
		{
			this.CommonSelectItemLayout.RefreshByData(this.RoguelikeChooseData.RogueGainEntryList ?? new List<RogueGainEntry>(), delegate
			{
				GenericLayout<CommonSelectItem, RogueGainEntry> commonSelectItemLayout = this.CommonSelectItemLayout;
				if (commonSelectItemLayout == null)
				{
					return;
				}
				UUIInturnAnimController uiAnimController = commonSelectItemLayout.GetUiAnimController();
				if (uiAnimController == null)
				{
					return;
				}
				uiAnimController.Play("", -1, false);
			}, false);
		}

		// Token: 0x0603591F RID: 219423 RVA: 0x00D73228 File Offset: 0x00D71428
		protected void RefreshTopPanel()
		{
			bool flag = false;
			foreach (RogueGainEntry rogueGainEntry in this.RoguelikeChooseData.RogueGainEntryList)
			{
				RogueBuffPool? rogueBuffConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueBuffConfig(rogueGainEntry.ConfigId);
				if (rogueBuffConfig != null && rogueBuffConfig.GetValueOrDefault().PerkType == 5)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				this.TopPanel.RefreshTitle("RoguelikeView_11_Text");
				this.TopPanel.RefreshSelectTipsText("RoguelikeView_12_Text", false, Array.Empty<object>());
				return;
			}
			this.TopPanel.RefreshTitle("RoguelikeView_9_Text");
			this.TopPanel.RefreshSelectTipsText("RoguelikeView_10_Text", false, new object[]
			{
				ModelBase<SceneTeamModel>.Instance.GetTeamLength() - 1
			});
		}

		// Token: 0x06035920 RID: 219424 RVA: 0x00D73318 File Offset: 0x00D71518
		protected void RefreshElementPanel()
		{
			this.ElementPanel.Refresh(null);
		}

		// Token: 0x06035921 RID: 219425 RVA: 0x00D73326 File Offset: 0x00D71526
		protected void RefreshPhantomInfoPanel()
		{
			this.PhantomInfoPanel.Refresh();
		}

		// Token: 0x06035922 RID: 219426 RVA: 0x00D73333 File Offset: 0x00D71533
		protected void RefreshBtnText()
		{
			this.ButtonItem.SetShowText("RoguelikeView_13_Text");
		}

		// Token: 0x06035923 RID: 219427 RVA: 0x00D73348 File Offset: 0x00D71548
		protected void RefreshRefreshBtnText()
		{
			int? useTime = this.RoguelikeChooseData.UseTime;
			int? maxTime = this.RoguelikeChooseData.MaxTime;
			UiPanelBase refreshButtonItem = this.RefreshButtonItem;
			int? num = maxTime;
			int num2 = 0;
			refreshButtonItem.SetActive(num.GetValueOrDefault() > num2 & num != null);
			int? num3 = maxTime - useTime;
			int? num4 = num3;
			num2 = 0;
			if (num4.GetValueOrDefault() <= num2 & num4 != null)
			{
				this.RefreshButtonItem.SetLocalTextNew("RoguelikeView_29_Text", new object[]
				{
					num3,
					maxTime
				});
			}
			else
			{
				this.RefreshButtonItem.SetLocalTextNew("RoguelikeView_28_Text", new object[]
				{
					num3,
					maxTime
				});
			}
			IReadOnlyList<NumItem> costCurrency = this.RoguelikeChooseData.CostCurrency;
			if (costCurrency.Count > 0)
			{
				NumItem numItem = costCurrency[0];
				bool flag = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(numItem.Id, 0) >= numItem.Count;
				string textStringId = flag ? "RogueSpecialRefreshCost" : "RogueSpecialRefreshCost_Not";
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), textStringId, new <>z__ReadOnlySingleElementList<object>(numItem.Count));
				ButtonItem refreshButtonItem2 = this.RefreshButtonItem;
				num4 = num3;
				num2 = 0;
				refreshButtonItem2.SetEnableClick((num4.GetValueOrDefault() > num2 & num4 != null) && flag);
				base.SetTextureByPath(ConfigBase<RoguelikeConfig>.Instance.GetRogueCurrencyConfig(numItem.Id).Value.IconSmall, base.GetTexture(7), null, null);
			}
		}

		// Token: 0x06035924 RID: 219428 RVA: 0x00D73510 File Offset: 0x00D71710
		protected void RefreshPreview(CommonSelectItem selectItem = null)
		{
			if (selectItem == null)
			{
				this.ButtonItem.SetEnableClick(false);
				this.PhantomInfoPanel.RefreshPhantomEntryItemRefreshPreview(null);
				this.ElementPanel.Refresh(null);
				return;
			}
			this.CurSelectItem = (selectItem.IsSelect() ? selectItem : null);
			this.ButtonItem.SetEnableClick(selectItem.IsSelect());
			RogueGainEntry rogueGainEntry = (selectItem != null) ? selectItem.RogueGainEntry : null;
			this.PhantomInfoPanel.RefreshPhantomEntryItemRefreshPreview((rogueGainEntry != null) ? rogueGainEntry.ElementDict : null);
			this.ElementPanel.Refresh(rogueGainEntry);
		}

		// Token: 0x06035925 RID: 219429 RVA: 0x00D73598 File Offset: 0x00D71798
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			int num;
			if (configParams.Length != 2 && int.TryParse(configParams[0], out num))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Guide;
				ELogAuthor author = ELogAuthor.JT;
				string message = "聚焦引导extraParam项配置有误";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configParams", configParams);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			UUIItem uuiitem = null;
			if (configParams[1] == "Attribute")
			{
				PhantomInfoPanel phantomInfoPanel = this.PhantomInfoPanel;
				uuiitem = ((phantomInfoPanel != null) ? phantomInfoPanel.GetAttributeItem(int.Parse(configParams[0])) : null);
			}
			else if (configParams[1] == "Cost")
			{
				TopPanel topPanel = this.TopPanel;
				uuiitem = ((topPanel != null) ? topPanel.GetCostItemByIndex(int.Parse(configParams[0])) : null);
			}
			if (uuiitem != null)
			{
				return new UUIItem[]
				{
					uuiitem,
					uuiitem
				};
			}
			return null;
		}

		// Token: 0x0401EC5D RID: 126045
		protected RoguelikeChooseData RoguelikeChooseData;

		// Token: 0x0401EC5E RID: 126046
		protected TopPanel TopPanel;

		// Token: 0x0401EC5F RID: 126047
		protected ElementPanel ElementPanel;

		// Token: 0x0401EC60 RID: 126048
		protected PhantomInfoPanel PhantomInfoPanel;

		// Token: 0x0401EC61 RID: 126049
		protected ButtonItem ButtonItem;

		// Token: 0x0401EC62 RID: 126050
		protected ButtonItem RefreshButtonItem;

		// Token: 0x0401EC63 RID: 126051
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericLayout<CommonSelectItem, RogueGainEntry> CommonSelectItemLayout;

		// Token: 0x0401EC64 RID: 126052
		protected CommonSelectItem CurSelectItem;

		// Token: 0x0401EC65 RID: 126053
		protected double LastRefreshTime;

		// Token: 0x0401EC66 RID: 126054
		protected bool IsFirstOpen = true;

		// Token: 0x0200B0EC RID: 45292
		[NullableContext(0)]
		private class ECommonSelectViewCom
		{
			// Token: 0x04036E10 RID: 224784
			public const int PhantomPanelItem = 0;

			// Token: 0x04036E11 RID: 224785
			public const int TopPanelItem = 1;

			// Token: 0x04036E12 RID: 224786
			public const int CommonSelectItemListLayout = 2;

			// Token: 0x04036E13 RID: 224787
			public const int CommonSelectItem = 3;

			// Token: 0x04036E14 RID: 224788
			public const int ElementPanelItem = 4;

			// Token: 0x04036E15 RID: 224789
			public const int ConfirmBtn = 5;

			// Token: 0x04036E16 RID: 224790
			public const int RefreshBtn = 6;

			// Token: 0x04036E17 RID: 224791
			public const int RefreshCostTexture = 7;

			// Token: 0x04036E18 RID: 224792
			public const int RefreshCostText = 8;
		}
	}
}
