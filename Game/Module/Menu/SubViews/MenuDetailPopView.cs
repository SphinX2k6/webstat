using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x02005789 RID: 22409
	[NullableContext(2)]
	[Nullable(0)]
	public class MenuDetailPopView : UiViewBase
	{
		// Token: 0x0603902B RID: 233515 RVA: 0x00E72551 File Offset: 0x00E70751
		[NullableContext(1)]
		public MenuDetailPopView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603902C RID: 233516 RVA: 0x00E72568 File Offset: 0x00E70768
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUITexture)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUITexture)),
				new ValueTuple<int, Type>(9, typeof(UUIText))
			};
		}

		// Token: 0x0603902D RID: 233517 RVA: 0x00E72660 File Offset: 0x00E70860
		protected override UniTask OnBeforeStartAsync()
		{
			MenuDetailPopView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MenuDetailPopView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603902E RID: 233518 RVA: 0x00E726A3 File Offset: 0x00E708A3
		protected override void OnStart()
		{
			this.Refresh(this.Data);
		}

		// Token: 0x0603902F RID: 233519 RVA: 0x00E726B4 File Offset: 0x00E708B4
		[NullableContext(1)]
		private UniTask CreateItems(MenuDetailPopData viewData)
		{
			MenuDetailPopView.<CreateItems>d__9 <CreateItems>d__;
			<CreateItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateItems>d__.<>4__this = this;
			<CreateItems>d__.viewData = viewData;
			<CreateItems>d__.<>1__state = -1;
			<CreateItems>d__.<>t__builder.Start<MenuDetailPopView.<CreateItems>d__9>(ref <CreateItems>d__);
			return <CreateItems>d__.<>t__builder.Task;
		}

		// Token: 0x06039030 RID: 233520 RVA: 0x00E72700 File Offset: 0x00E70900
		[NullableContext(1)]
		private void Refresh(MenuDetailPopData viewData)
		{
			bool isMulti = viewData.IsMulti;
			bool flag = viewData.ItemList.Count > 0 && viewData.ItemList[0].ShowType == EMenuDetailItemShowType.WideVideo;
			base.GetItem(1).SetUIActive(isMulti);
			base.GetItem(3).SetUIActive(!isMulti && !flag);
			base.GetItem(7).SetUIActive(!isMulti && flag);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), viewData.Title, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), viewData.Description, Array.Empty<object>());
			if (isMulti)
			{
				for (int i = 0; i < viewData.ItemList.Count; i++)
				{
					if (i < this.ItemList.Count)
					{
						MenuDetailPopViewItemPanel menuDetailPopViewItemPanel = this.ItemList[i];
						if (menuDetailPopViewItemPanel != null)
						{
							menuDetailPopViewItemPanel.RefreshByData(viewData.ItemList[i]);
						}
					}
				}
				base.GetItem(1).SetUIActive(true);
				return;
			}
			if (flag)
			{
				MenuDetailPopViewItemView singleWideVideoView = this.SingleWideVideoView;
				if (singleWideVideoView != null)
				{
					singleWideVideoView.RefreshByData(viewData.ItemList[0]);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), viewData.ItemList[0].Title, Array.Empty<object>());
				return;
			}
			MenuDetailPopViewItemView singleGridView = this.SingleGridView;
			if (singleGridView == null)
			{
				return;
			}
			singleGridView.RefreshByData(viewData.ItemList[0]);
		}

		// Token: 0x06039031 RID: 233521 RVA: 0x00E72864 File Offset: 0x00E70A64
		private void Close()
		{
			base.CloseMe(null);
		}

		// Token: 0x06039032 RID: 233522 RVA: 0x00E72870 File Offset: 0x00E70A70
		private MenuDetailPopData LoadDataFromConfig(int popViewId)
		{
			MenuDetailPop? menuDetailPopConfigById = ConfigBase<MenuBaseConfig>.Instance.GetMenuDetailPopConfigById(popViewId);
			if (menuDetailPopConfigById == null)
			{
				return null;
			}
			MenuDetailPopData menuDetailPopData = new MenuDetailPopData();
			menuDetailPopData.Title = menuDetailPopConfigById.Value.Title;
			menuDetailPopData.Description = menuDetailPopConfigById.Value.Description;
			menuDetailPopData.ItemList = new List<MenuDetailPopItemData>();
			for (int i = 0; i < menuDetailPopConfigById.Value.ItemListLength; i++)
			{
				int configId = menuDetailPopConfigById.Value.ItemList(i);
				MenuDetailPopItemData menuDetailPopItemData = new MenuDetailPopItemData();
				MenuDetailPopItem? menuDetailPopItemConfigById = ConfigBase<MenuBaseConfig>.Instance.GetMenuDetailPopItemConfigById(configId);
				if (menuDetailPopItemConfigById == null)
				{
					menuDetailPopData.ItemList.Add(menuDetailPopItemData);
				}
				else
				{
					menuDetailPopItemData.Title = menuDetailPopItemConfigById.Value.Title;
					menuDetailPopItemData.ShowType = (EMenuDetailItemShowType)menuDetailPopItemConfigById.Value.ShowType;
					menuDetailPopItemData.ResourcePath = menuDetailPopItemConfigById.Value.ResourcePath;
					menuDetailPopData.ItemList.Add(menuDetailPopItemData);
				}
			}
			menuDetailPopData.IsMulti = (menuDetailPopData.ItemList.Count > 1);
			return menuDetailPopData;
		}

		// Token: 0x06039033 RID: 233523 RVA: 0x00E72995 File Offset: 0x00E70B95
		protected override void OnBeforeDestroy()
		{
			MenuDetailPopViewItemView singleGridView = this.SingleGridView;
			if (singleGridView != null)
			{
				singleGridView.Clear();
			}
			this.SingleGridView = null;
			MenuDetailPopViewItemView singleWideVideoView = this.SingleWideVideoView;
			if (singleWideVideoView != null)
			{
				singleWideVideoView.Clear();
			}
			this.SingleWideVideoView = null;
		}

		// Token: 0x04020768 RID: 132968
		private PopupCaptionItem Caption;

		// Token: 0x04020769 RID: 132969
		private MenuDetailPopData Data;

		// Token: 0x0402076A RID: 132970
		private MenuDetailPopViewItemView SingleGridView;

		// Token: 0x0402076B RID: 132971
		private MenuDetailPopViewItemView SingleWideVideoView;

		// Token: 0x0402076C RID: 132972
		[Nullable(1)]
		private readonly List<MenuDetailPopViewItemPanel> ItemList = new List<MenuDetailPopViewItemPanel>();
	}
}
