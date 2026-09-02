using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200516B RID: 20843
	[NullableContext(2)]
	[Nullable(0)]
	public class PhantomSelectView : RogueSelectBaseView
	{
		// Token: 0x06035A31 RID: 219697 RVA: 0x00D78EE9 File Offset: 0x00D770E9
		[NullableContext(1)]
		public PhantomSelectView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x17008C83 RID: 35971
		// (get) Token: 0x06035A33 RID: 219699 RVA: 0x00D78F33 File Offset: 0x00D77133
		// (set) Token: 0x06035A32 RID: 219698 RVA: 0x00D78EFC File Offset: 0x00D770FC
		private int SelectIndex
		{
			get
			{
				return this.SelectIndexInternal;
			}
			set
			{
				this.SelectIndexInternal = value;
				int configId = this.RoguelikeChooseData.RogueGainEntryList[value].ConfigId;
				LocalStorage.SetPlayer<int>(ELocalStoragePlayerKey.RoguelikeSelectPhantomId, configId);
			}
		}

		// Token: 0x06035A34 RID: 219700 RVA: 0x00D78F3C File Offset: 0x00D7713C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickBtnLeft));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickBtnRight));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035A35 RID: 219701 RVA: 0x00D790F0 File Offset: 0x00D772F0
		private void OnClickBtnLeft()
		{
			this.PhantomSelectItemLayout.DeselectCurrentGridProxy();
			if (this.SelectIndex - 1 < 0)
			{
				this.SelectIndex = this.RoguelikeChooseData.RogueGainEntryList.Count - 1;
			}
			else
			{
				int selectIndex = this.SelectIndex;
				this.SelectIndex = selectIndex - 1;
			}
			this.PhantomSelectItemLayout.SelectGridProxy(this.SelectIndex, false);
			this.RefreshPhantom(true);
			this.RefreshBtnEnableClick();
		}

		// Token: 0x06035A36 RID: 219702 RVA: 0x00D7915C File Offset: 0x00D7735C
		private void OnClickBtnRight()
		{
			this.PhantomSelectItemLayout.DeselectCurrentGridProxy();
			if (this.SelectIndex + 1 >= this.RoguelikeChooseData.RogueGainEntryList.Count)
			{
				this.SelectIndex = 0;
			}
			else
			{
				int selectIndex = this.SelectIndex;
				this.SelectIndex = selectIndex + 1;
			}
			this.PhantomSelectItemLayout.SelectGridProxy(this.SelectIndex, false);
			this.RefreshPhantom(true);
			this.RefreshBtnEnableClick();
		}

		// Token: 0x06035A37 RID: 219703 RVA: 0x00D791C8 File Offset: 0x00D773C8
		protected virtual void ConfirmBtn(int _)
		{
			if (this.SelectIndex < 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.Roguelike, ELogAuthor.ZJC, "当前没有选中的声骸", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			RogueGainEntry currentRogueGainEntry = this.RoguelikeChooseData.RogueGainEntryList[this.SelectIndex];
			ModelBase<RoguelikeModel>.Instance.CurrentRogueGainEntry = currentRogueGainEntry;
			ControllerBase<RoguelikeController>.Instance.RogueChooseDataResultRequest(EPerkType.Phantom);
		}

		// Token: 0x06035A38 RID: 219704 RVA: 0x00D7922C File Offset: 0x00D7742C
		protected virtual void RefreshBtnEnableClick()
		{
			RogueGainEntry rogueGainEntry = this.RoguelikeChooseData.RogueGainEntryList[this.SelectIndex];
			if (!rogueGainEntry.IsValid)
			{
				RoguePokemon? roguePhantomConfig = ConfigBase<RoguelikeConfig>.Instance.GetRoguePhantomConfig(rogueGainEntry.ConfigId);
				this.ButtonItem.SetUiActive(false);
				this.LockItem.SetTextByTextId(roguePhantomConfig.Value.UnlockTips, Array.Empty<string>());
				this.LockItem.SetUiActive(true);
				return;
			}
			this.ButtonItem.SetUiActive(true);
			this.LockItem.SetUiActive(false);
		}

		// Token: 0x06035A39 RID: 219705 RVA: 0x00D792BC File Offset: 0x00D774BC
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomSelectView.<OnBeforeStartAsync>d__19 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomSelectView.<OnBeforeStartAsync>d__19>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035A3A RID: 219706 RVA: 0x00D79300 File Offset: 0x00D77500
		protected override void OnStart()
		{
			this.SelectIndexInternal = this.GetCacheSelectIndex().GetValueOrDefault();
			this.PhantomSelectItemLayout.SelectGridProxy(this.SelectIndex, true);
		}

		// Token: 0x06035A3B RID: 219707 RVA: 0x00D79334 File Offset: 0x00D77534
		private int? GetCacheSelectIndex()
		{
			int player = LocalStorage.GetPlayer<int>(ELocalStoragePlayerKey.RoguelikeSelectPhantomId, 0);
			if (player != 0)
			{
				int num = -1;
				for (int i = 0; i < this.RoguelikeChooseData.RogueGainEntryList.Count; i++)
				{
					if (this.RoguelikeChooseData.RogueGainEntryList[i].ConfigId == player)
					{
						num = i;
						break;
					}
				}
				if (num >= 0)
				{
					return new int?(num);
				}
			}
			return null;
		}

		// Token: 0x06035A3C RID: 219708 RVA: 0x00D7939E File Offset: 0x00D7759E
		protected override void OnBeforeShow()
		{
			this.Refresh();
		}

		// Token: 0x06035A3D RID: 219709 RVA: 0x00D793A6 File Offset: 0x00D775A6
		protected override void OnBeforeDestroy()
		{
			this.TopPanel.Destroy(null);
			this.ElementPanel.Destroy(null);
			base.RecycleUiPoolActor();
		}

		// Token: 0x06035A3E RID: 219710 RVA: 0x00D793C6 File Offset: 0x00D775C6
		private bool CanToggleStateChange(bool bState)
		{
			return false;
		}

		// Token: 0x06035A3F RID: 219711 RVA: 0x00D793C9 File Offset: 0x00D775C9
		[NullableContext(1)]
		private RoguelikePhantomSelectDragItem CreatePhantomSelectDragItem()
		{
			return new RoguelikePhantomSelectDragItem
			{
				OnSelectCallback = new Action<IPhantomSelectItemData, bool>(this.OnSelectItem)
			};
		}

		// Token: 0x06035A40 RID: 219712 RVA: 0x00D793E2 File Offset: 0x00D775E2
		[NullableContext(1)]
		private void OnSelectItem(IPhantomSelectItemData entry, bool isSelected)
		{
			if (!isSelected)
			{
				return;
			}
			this.PhantomSelectItemLayout.DeselectCurrentGridProxy();
			this.SelectIndex = entry.Index;
			this.PhantomSelectItemLayout.SelectGridProxy(this.SelectIndex, false);
			this.RefreshPhantom(true);
			this.RefreshBtnEnableClick();
		}

		// Token: 0x06035A41 RID: 219713 RVA: 0x00D79420 File Offset: 0x00D77620
		[NullableContext(1)]
		protected override void RoguelikeChooseDataResult(RogueGainEntry newRogueGainEntry, RogueGainEntry oldRogueGainEntry, bool isSuccess, int bindId, RoguelikeChooseDataResultResponse response)
		{
			if (isSuccess)
			{
				RoguelikeChooseData roguelikeChooseData = this.RoguelikeChooseData;
				int? num = (roguelikeChooseData != null) ? new int?(roguelikeChooseData.Index) : null;
				if (bindId == num.GetValueOrDefault() & num != null)
				{
					if (this.IsShowChooseTips)
					{
						RogueGainEntry selectRogueGainEntry = this.RoguelikeChooseData.RogueGainEntryList[this.SelectIndex];
						Singleton<UiManager>.Instance.CloseAndOpenView(this.ViewInfo.Name, EUiViewName.RoguePhantomSelectResultView, new RogueSelectResult(newRogueGainEntry, oldRogueGainEntry, selectRogueGainEntry, false), null, true);
						return;
					}
					Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
					return;
				}
			}
		}

		// Token: 0x06035A42 RID: 219714 RVA: 0x00D794C1 File Offset: 0x00D776C1
		protected override void OnDescModelChange()
		{
			this.Refresh();
		}

		// Token: 0x06035A43 RID: 219715 RVA: 0x00D794C9 File Offset: 0x00D776C9
		private void Refresh()
		{
			this.RefreshTopPanel();
			this.RefreshPhantom(false);
			this.RefreshElementPanel();
			this.RefreshBtnEnableClick();
		}

		// Token: 0x06035A44 RID: 219716 RVA: 0x00D794E4 File Offset: 0x00D776E4
		protected virtual void RefreshTopPanel()
		{
			this.TopPanel.RefreshTitle("RoguelikeView_5_Text");
			this.TopPanel.RefreshSelectTipsText("RoguelikeView_6_Text", false, Array.Empty<object>());
			this.TopPanel.RefreshTabBtn();
		}

		// Token: 0x06035A45 RID: 219717 RVA: 0x00D79518 File Offset: 0x00D77718
		private void RefreshPhantom(bool animSwitch = false)
		{
			RogueGainEntry rogueGainEntry = this.RoguelikeChooseData.RogueGainEntryList[this.SelectIndex];
			PhantomSelectItemContextData data = new PhantomSelectItemContextData
			{
				RogueGainEntry = rogueGainEntry,
				RoguelikeInfo = ModelBase<RoguelikeModel>.Instance.RogueInfo
			};
			this.PhantomSelectItem.Update(data);
			if (animSwitch)
			{
				this.PhantomSelectItem.PlaySequenceByName("Start");
			}
			base.GetItem(8).SetUIActive(!rogueGainEntry.IsValid);
		}

		// Token: 0x06035A46 RID: 219718 RVA: 0x00D7958D File Offset: 0x00D7778D
		protected void RefreshElementPanel()
		{
			this.ElementPanel.Refresh(null);
		}

		// Token: 0x06035A47 RID: 219719 RVA: 0x00D7959C File Offset: 0x00D7779C
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
			PhantomSelectItem phantomSelectItem = this.PhantomSelectItem;
			if (phantomSelectItem != null)
			{
				if (configParams[1] == "All")
				{
					return new UUIItem[]
					{
						phantomSelectItem.GetRootItem(),
						phantomSelectItem.GetRootItem()
					};
				}
				if (configParams[1] == "Sub")
				{
					PhantomSelectItem phantomSelectItem2 = this.PhantomSelectItem;
					UUIItem uuiitem = (phantomSelectItem2 != null) ? phantomSelectItem2.GetSubItem() : null;
					if (uuiitem != null)
					{
						return new UUIItem[]
						{
							uuiitem,
							uuiitem
						};
					}
				}
			}
			return null;
		}

		// Token: 0x0401ECCB RID: 126155
		protected RoguelikeChooseData RoguelikeChooseData;

		// Token: 0x0401ECCC RID: 126156
		protected TopPanel TopPanel;

		// Token: 0x0401ECCD RID: 126157
		protected ElementPanel ElementPanel;

		// Token: 0x0401ECCE RID: 126158
		protected ButtonItem ButtonItem;

		// Token: 0x0401ECCF RID: 126159
		private PhantomSelectItem PhantomSelectItem;

		// Token: 0x0401ECD0 RID: 126160
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoguelikePhantomSelectDragItem, IPhantomSelectItemData> PhantomSelectItemLayout;

		// Token: 0x0401ECD1 RID: 126161
		private RoguelikePhantomLockItem LockItem;

		// Token: 0x0401ECD2 RID: 126162
		protected bool IsShowChooseTips;

		// Token: 0x0401ECD3 RID: 126163
		private int SelectIndexInternal = -1;

		// Token: 0x0200B119 RID: 45337
		[NullableContext(0)]
		private class EPhantomSelectViewCom
		{
			// Token: 0x04036EEE RID: 225006
			public const int TopPanelItem = 0;

			// Token: 0x04036EEF RID: 225007
			public const int PhantomLayout = 1;

			// Token: 0x04036EF0 RID: 225008
			public const int ConfirmBtn = 2;

			// Token: 0x04036EF1 RID: 225009
			public const int ElementPanelItem = 3;

			// Token: 0x04036EF2 RID: 225010
			public const int BtnLeft = 4;

			// Token: 0x04036EF3 RID: 225011
			public const int BtnRight = 5;

			// Token: 0x04036EF4 RID: 225012
			public const int PanelLock = 6;

			// Token: 0x04036EF5 RID: 225013
			public const int PhantomItem = 7;

			// Token: 0x04036EF6 RID: 225014
			public const int PhantomItemLock = 8;
		}
	}
}
