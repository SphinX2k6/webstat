using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200519C RID: 20892
	[NullableContext(2)]
	[Nullable(0)]
	public class RoguelikeSelectSpecialView : RogueSelectBaseView
	{
		// Token: 0x06035BB8 RID: 220088 RVA: 0x00D81623 File Offset: 0x00D7F823
		[NullableContext(1)]
		public RoguelikeSelectSpecialView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06035BB9 RID: 220089 RVA: 0x00D8162C File Offset: 0x00D7F82C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickRefreshButton));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickConfirmButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035BBA RID: 220090 RVA: 0x00D817BC File Offset: 0x00D7F9BC
		protected override UniTask OnBeforeStartAsync()
		{
			RoguelikeSelectSpecialView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoguelikeSelectSpecialView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035BBB RID: 220091 RVA: 0x00D81800 File Offset: 0x00D7FA00
		protected override void OnStart()
		{
			this.RoguelikeChooseData = (this.OpenParam as RoguelikeChooseData);
			if (this.RoguelikeChooseData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Roguelike, ELogAuthor.BB, "RoguelikeSelectSpecialView无效输入", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.SpecialItemLayout = new GenericLayout<RoguelikeSelectSpecialItem, RogueGainEntry>(base.GetHorizontalLayout(2), new Func<RoguelikeSelectSpecialItem>(this.CreateSpecialItem), null, false, true);
			ModelBase<RoguelikeModel>.Instance.CurrentRogueGainEntry = null;
			this.TopPanel.CloseCallback = new Action(base.CloseMySelf);
			this.RefreshUi();
		}

		// Token: 0x06035BBC RID: 220092 RVA: 0x00D8188F File Offset: 0x00D7FA8F
		private void RefreshUi()
		{
			this.RefreshElementPanel();
			this.RefreshSpecialItemLayout();
			this.RefreshBottomPanel();
		}

		// Token: 0x06035BBD RID: 220093 RVA: 0x00D818A4 File Offset: 0x00D7FAA4
		private void RefreshSpecialItemLayout()
		{
			List<RogueGainEntry> rogueGainEntryList = this.RoguelikeChooseData.RogueGainEntryList;
			this.SpecialItemLayout.RefreshByData(rogueGainEntryList, null, true);
		}

		// Token: 0x06035BBE RID: 220094 RVA: 0x00D818CB File Offset: 0x00D7FACB
		private void RefreshElementPanel()
		{
			this.ElementPanel.Refresh(null);
		}

		// Token: 0x06035BBF RID: 220095 RVA: 0x00D818DC File Offset: 0x00D7FADC
		private void RefreshBottomPanel()
		{
			int value = this.RoguelikeChooseData.MaxTime.Value;
			int num = value - this.RoguelikeChooseData.UseTime.Value;
			UUIText text = base.GetText(7);
			if (num <= 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RoguelikeView_29_Text", new <>z__ReadOnlyArray<object>(new object[]
				{
					num,
					value
				}));
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RoguelikeView_28_Text", new <>z__ReadOnlyArray<object>(new object[]
				{
					num,
					value
				}));
			}
			base.GetButton(3).RootUIComp.Get().SetUIActive(value > 0);
			base.GetButton(4).SetSelfInteractive(this.CurRogueGainEntry != null);
			IReadOnlyList<NumItem> costCurrency = this.RoguelikeChooseData.CostCurrency;
			if (costCurrency.Count > 0)
			{
				NumItem numItem = costCurrency[0];
				bool flag = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(numItem.Id, 0) >= numItem.Count;
				string textStringId = flag ? "RogueSpecialRefreshCost" : "RogueSpecialRefreshCost_Not";
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), textStringId, new <>z__ReadOnlySingleElementList<object>(numItem.Count));
				base.SetTextureByPath(ConfigBase<RoguelikeConfig>.Instance.GetRogueCurrencyConfig(numItem.Id).Value.IconSmall, base.GetTexture(5), null, null);
				base.GetButton(3).SetSelfInteractive(num > 0 && flag);
			}
		}

		// Token: 0x06035BC0 RID: 220096 RVA: 0x00D81A6D File Offset: 0x00D7FC6D
		protected override void OnDescModelChange()
		{
			this.RefreshSpecialItemLayout();
		}

		// Token: 0x06035BC1 RID: 220097 RVA: 0x00D81A75 File Offset: 0x00D7FC75
		[NullableContext(1)]
		private RoguelikeSelectSpecialItem CreateSpecialItem()
		{
			return new RoguelikeSelectSpecialItem(new Action<RoguelikeSelectSpecialItem, RogueGainEntry>(this.OnClickRoguelikeSpecialItem));
		}

		// Token: 0x06035BC2 RID: 220098 RVA: 0x00D81A88 File Offset: 0x00D7FC88
		private void OnClickRefreshButton()
		{
			if (this.RoguelikeChooseData.UseTime.Value >= this.RoguelikeChooseData.MaxTime.Value)
			{
				return;
			}
			ControllerBase<RoguelikeController>.Instance.RoguelikeRefreshGainRequest(this.RoguelikeChooseData.Index);
		}

		// Token: 0x06035BC3 RID: 220099 RVA: 0x00D81AC2 File Offset: 0x00D7FCC2
		private void OnClickConfirmButton()
		{
			ModelBase<RoguelikeModel>.Instance.CurrentRogueGainEntry = this.CurRogueGainEntry;
			ControllerBase<RoguelikeController>.Instance.RogueChooseDataResultRequest(EPerkType.Special);
		}

		// Token: 0x06035BC4 RID: 220100 RVA: 0x00D81AE0 File Offset: 0x00D7FCE0
		[NullableContext(1)]
		private void OnClickRoguelikeSpecialItem(RoguelikeSelectSpecialItem item, RogueGainEntry data)
		{
			if (this.CurChooseSpecialItem == item)
			{
				this.CurChooseSpecialItem = null;
				item.SetSelect(false);
				this.CurRogueGainEntry = null;
				RogueGainEntry rogueGainEntry = null;
				this.ElementPanel.Refresh(rogueGainEntry);
				this.RefreshBottomPanel();
				return;
			}
			if (this.CurChooseSpecialItem != null)
			{
				this.CurChooseSpecialItem.SetSelect(false);
			}
			this.CurChooseSpecialItem = item;
			item.SetSelect(true);
			this.CurRogueGainEntry = data;
			this.ElementPanel.Refresh(data);
			this.RefreshBottomPanel();
		}

		// Token: 0x06035BC5 RID: 220101 RVA: 0x00D81B5C File Offset: 0x00D7FD5C
		[NullableContext(1)]
		protected override void RoguelikeChooseDataResult(RogueGainEntry newRogueGainEntry, RogueGainEntry oldRogueGainEntry, bool isSuccess, int bindId, RoguelikeChooseDataResultResponse response)
		{
			if (isSuccess)
			{
				RoguelikeChooseData roguelikeChooseData = this.RoguelikeChooseData;
				int? num = (roguelikeChooseData != null) ? new int?(roguelikeChooseData.Index) : null;
				if (bindId == num.GetValueOrDefault() & num != null)
				{
					Singleton<UiManager>.Instance.CloseAndOpenView(this.ViewInfo.Name, EUiViewName.RoguelikeSpecialDetailView, new object[]
					{
						newRogueGainEntry,
						ControllerBase<RoguelikeController>.Instance.CreateCloseViewCallBack(response, delegate(bool? _)
						{
							RogueSelectResult rogueSelectResult = new RogueSelectResult(ModelBase<RoguelikeModel>.Instance.RogueInfo.PhantomEntry, oldRogueGainEntry, null, false);
							if (rogueSelectResult.GetNewUnlockAffixEntry().Count <= 0)
							{
								return;
							}
							Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonSelectResultView, rogueSelectResult, null);
						})
					}, null, true);
					return;
				}
			}
		}

		// Token: 0x06035BC6 RID: 220102 RVA: 0x00D81BF0 File Offset: 0x00D7FDF0
		protected override void RoguelikeRefreshGain(int index)
		{
			ModelBase<RoguelikeModel>.Instance.CurrentRogueGainEntry = null;
			RoguelikeChooseData roguelikeChooseDataById = ModelBase<RoguelikeModel>.Instance.GetRoguelikeChooseDataById(index);
			this.RoguelikeChooseData = roguelikeChooseDataById;
			this.CurChooseSpecialItem = null;
			this.CurRogueGainEntry = null;
			this.RefreshUi();
		}

		// Token: 0x0401ED60 RID: 126304
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoguelikeSelectSpecialItem, RogueGainEntry> SpecialItemLayout;

		// Token: 0x0401ED61 RID: 126305
		private RoguelikeSelectSpecialItem CurChooseSpecialItem;

		// Token: 0x0401ED62 RID: 126306
		private RogueGainEntry CurRogueGainEntry;

		// Token: 0x0401ED63 RID: 126307
		private RoguelikeChooseData RoguelikeChooseData;

		// Token: 0x0401ED64 RID: 126308
		private TopPanel TopPanel;

		// Token: 0x0401ED65 RID: 126309
		private ElementPanel ElementPanel;

		// Token: 0x0200B166 RID: 45414
		[NullableContext(0)]
		private static class EComponent
		{
			// Token: 0x04037031 RID: 225329
			public const int TopPanelItem = 0;

			// Token: 0x04037032 RID: 225330
			public const int ElementPanelItem = 1;

			// Token: 0x04037033 RID: 225331
			public const int SpecialItemLayout = 2;

			// Token: 0x04037034 RID: 225332
			public const int RefreshButton = 3;

			// Token: 0x04037035 RID: 225333
			public const int ConfirmButton = 4;

			// Token: 0x04037036 RID: 225334
			public const int RefreshCostTexture = 5;

			// Token: 0x04037037 RID: 225335
			public const int RefreshCostText = 6;

			// Token: 0x04037038 RID: 225336
			public const int RefreshTimeText = 7;
		}
	}
}
