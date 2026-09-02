using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.PhantomInteract;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roulette.View
{
	// Token: 0x02005011 RID: 20497
	[NullableContext(2)]
	[Nullable(0)]
	public class RouletteAssemblyTips : UiPanelBase
	{
		// Token: 0x06034D44 RID: 216388 RVA: 0x00D4348C File Offset: 0x00D4168C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 15;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OpenHelpView));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06034D45 RID: 216389 RVA: 0x00D436E8 File Offset: 0x00D418E8
		protected override UniTask OnBeforeStartAsync()
		{
			RouletteAssemblyTips.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RouletteAssemblyTips.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034D46 RID: 216390 RVA: 0x00D4372C File Offset: 0x00D4192C
		protected override void OnStart()
		{
			UUIItem item = base.GetItem(9);
			this.TipsGetWayPanel = new TipsGetWayPanel(item);
		}

		// Token: 0x06034D47 RID: 216391 RVA: 0x00D43750 File Offset: 0x00D41950
		protected override void OnBeforeDestroy()
		{
			if (this.TipsGetWayPanel != null)
			{
				this.TipsGetWayPanel.Destroy(null);
				this.TipsGetWayPanel = null;
			}
			if (this.ItemPanel1 != null)
			{
				this.ItemPanel1.Destroy(null);
				this.ItemPanel1 = null;
			}
			if (this.ItemPanel2 != null)
			{
				this.ItemPanel2.Destroy(null);
				this.ItemPanel2 = null;
			}
		}

		// Token: 0x06034D48 RID: 216392 RVA: 0x00D437B0 File Offset: 0x00D419B0
		[NullableContext(1)]
		public void Refresh(AssemblyTipsData data)
		{
			this.Data = data;
			this.RefreshTitle();
			this.RefreshHelpBtn();
			this.RefreshBg();
			this.RefreshDescription();
			this.RefreshIcon();
			this.RefreshGetWay();
			this.RefreshSetItem();
			this.RefreshNeedItemPanel();
			this.RefreshAuthorizationItemPanel();
			this.RefreshPhantomInteractEquipmentPanel();
		}

		// Token: 0x06034D49 RID: 216393 RVA: 0x00D43800 File Offset: 0x00D41A00
		private void RefreshTitle()
		{
			base.GetText(3).ShowTextNew(this.Data.Title);
		}

		// Token: 0x06034D4A RID: 216394 RVA: 0x00D4381C File Offset: 0x00D41A1C
		private void OpenHelpView()
		{
			int helpId = this.Data.HelpId;
			if (helpId != 0)
			{
				ControllerBase<HelpController>.Instance.OpenHelpById(helpId);
			}
		}

		// Token: 0x06034D4B RID: 216395 RVA: 0x00D43844 File Offset: 0x00D41A44
		private void RefreshHelpBtn()
		{
			int helpId = this.Data.HelpId;
			base.GetButton(4).RootUIComp.Get().SetUIActive(helpId != 0);
		}

		// Token: 0x06034D4C RID: 216396 RVA: 0x00D4387C File Offset: 0x00D41A7C
		private void RefreshBg()
		{
			UUITexture texture = base.GetTexture(0);
			base.SetTextureByPath(ConfigBase<InventoryConfig>.Instance.GetItemQualityConfig((int)this.Data.BgQuality).Value.RouletteTipsQualityTexPath, texture, null, null);
		}

		// Token: 0x06034D4D RID: 216397 RVA: 0x00D438C8 File Offset: 0x00D41AC8
		private void RefreshDescription()
		{
			bool flag = this.Data.TextMain != "" && this.Data.TextMain != null;
			base.GetText(5).SetUIActive(flag);
			if (flag)
			{
				base.GetText(5).ShowTextNew(this.Data.TextMain);
			}
			bool flag2 = this.Data.TextSub != "" && this.Data.TextSub != null;
			base.GetItem(6).SetUIActive(flag2);
			if (flag2)
			{
				base.GetText(7).ShowTextNew(this.Data.TextSub);
			}
		}

		// Token: 0x06034D4E RID: 216398 RVA: 0x00D43978 File Offset: 0x00D41B78
		private void RefreshIcon()
		{
			UUITexture textureIcon = base.GetTexture(2);
			textureIcon.SetUIActive(false);
			UUISprite spriteIcon = base.GetSprite(1);
			spriteIcon.SetUIActive(false);
			if (this.Data.GridType == ERouletteGridType.EquipItem)
			{
				base.SetItemIcon(textureIcon, this.Data.GridId, null, delegate(bool _)
				{
					textureIcon.SetUIActive(true);
				});
				return;
			}
			if (this.Data.IconPath == "")
			{
				return;
			}
			if (this.Data.IsIconTexture)
			{
				base.SetTextureByPath(this.Data.IconPath, textureIcon, null, delegate(bool _)
				{
					textureIcon.SetUIActive(true);
				});
				return;
			}
			this.SetSpriteByPath(this.Data.IconPath, spriteIcon, false, null, delegate(bool _)
			{
				spriteIcon.SetUIActive(true);
			});
		}

		// Token: 0x06034D4F RID: 216399 RVA: 0x00D43A78 File Offset: 0x00D41C78
		private void RefreshGetWay()
		{
			List<IGetWayItemData> getWayData = this.Data.GetWayData;
			this.TipsGetWayPanel.SetActive(getWayData.Count > 0);
			if (getWayData != null)
			{
				this.TipsGetWayPanel.Refresh(getWayData.ToArray());
			}
		}

		// Token: 0x06034D50 RID: 216400 RVA: 0x00D43ABC File Offset: 0x00D41CBC
		private void RefreshSetItem()
		{
			int item = this.Data.CanSetItemNum.Item1;
			int item2 = this.Data.CanSetItemNum.Item2;
			base.GetItem(12).SetUIActive(item2 != 0);
			if (item2 == 0)
			{
				return;
			}
			string item3 = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("Text_CollectProgress_Text", null), new string[]
			{
				item.ToString(),
				item2.ToString()
			});
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(13), "Explore_Count", new <>z__ReadOnlySingleElementList<object>(item3));
		}

		// Token: 0x06034D51 RID: 216401 RVA: 0x00D43B48 File Offset: 0x00D41D48
		private void RefreshNeedItemPanel()
		{
			Dictionary<int, int> needItemMap = this.Data.NeedItemMap;
			this.ItemPanel1.SetActive(needItemMap.Count != 0);
			if (needItemMap.Count == 0)
			{
				return;
			}
			List<ItemRefreshData> list = new List<ItemRefreshData>();
			foreach (KeyValuePair<int, int> keyValuePair in needItemMap)
			{
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(key, 0);
				string text = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("Text_CollectProgress_Text", null), new string[]
				{
					itemCountByConfigId.ToString(),
					value.ToString()
				});
				ItemRefreshData item = new ItemRefreshData
				{
					ItemId = key,
					NeedLock = false,
					Text = text
				};
				list.Add(item);
			}
			this.ItemPanel1.RefreshItemPanel(list);
		}

		// Token: 0x06034D52 RID: 216402 RVA: 0x00D43C40 File Offset: 0x00D41E40
		private void RefreshAuthorizationItemPanel()
		{
			List<int> authorization = this.Data.Authorization;
			this.ItemPanel2.SetActive(authorization.Count > 0);
			if (authorization.Count == 0)
			{
				return;
			}
			List<ItemRefreshData> list = new List<ItemRefreshData>();
			foreach (int num in authorization)
			{
				int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(num, 0);
				ItemRefreshData item = new ItemRefreshData
				{
					ItemId = num,
					NeedLock = (itemCountByConfigId <= 0)
				};
				list.Add(item);
			}
			this.ItemPanel2.RefreshItemPanel(list);
		}

		// Token: 0x06034D53 RID: 216403 RVA: 0x00D43CF4 File Offset: 0x00D41EF4
		public void RefreshPhantomInteractEquipmentPanel()
		{
			AssemblyTipsData data = this.Data;
			if (data == null || !data.ShowPhantomInteractEquipment)
			{
				this.PhantomInteractRouletteTipsPanel.SetUiActive(false);
				return;
			}
			this.PhantomInteractRouletteTipsPanel.SetUiActive(true);
			this.PhantomInteractRouletteTipsPanel.Refresh();
		}

		// Token: 0x0401E740 RID: 124736
		private AssemblyTipsData Data;

		// Token: 0x0401E741 RID: 124737
		private TipsGetWayPanel TipsGetWayPanel;

		// Token: 0x0401E742 RID: 124738
		private RouletteTipsItemPanel ItemPanel1;

		// Token: 0x0401E743 RID: 124739
		private RouletteTipsItemPanel ItemPanel2;

		// Token: 0x0401E744 RID: 124740
		private PhantomInteractRouletteTipsPanel PhantomInteractRouletteTipsPanel;
	}
}
