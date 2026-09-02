using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Overview
{
	// Token: 0x02005AA0 RID: 23200
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoTabMainView : UiViewBase
	{
		// Token: 0x0603AB10 RID: 240400 RVA: 0x00EE00B0 File Offset: 0x00EDE2B0
		public KurotatoTabMainView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603AB11 RID: 240401 RVA: 0x00EE00C4 File Offset: 0x00EDE2C4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603AB12 RID: 240402 RVA: 0x00EE0150 File Offset: 0x00EDE350
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoTabMainView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoTabMainView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AB13 RID: 240403 RVA: 0x00EE0194 File Offset: 0x00EDE394
		private UniTask CreateCaptionItem()
		{
			KurotatoTabMainView.<CreateCaptionItem>d__11 <CreateCaptionItem>d__;
			<CreateCaptionItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateCaptionItem>d__.<>4__this = this;
			<CreateCaptionItem>d__.<>1__state = -1;
			<CreateCaptionItem>d__.<>t__builder.Start<KurotatoTabMainView.<CreateCaptionItem>d__11>(ref <CreateCaptionItem>d__);
			return <CreateCaptionItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603AB14 RID: 240404 RVA: 0x00EE01D8 File Offset: 0x00EDE3D8
		private UniTask CreateArchiveButton()
		{
			KurotatoTabMainView.<CreateArchiveButton>d__12 <CreateArchiveButton>d__;
			<CreateArchiveButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateArchiveButton>d__.<>4__this = this;
			<CreateArchiveButton>d__.<>1__state = -1;
			<CreateArchiveButton>d__.<>t__builder.Start<KurotatoTabMainView.<CreateArchiveButton>d__12>(ref <CreateArchiveButton>d__);
			return <CreateArchiveButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603AB15 RID: 240405 RVA: 0x00EE021B File Offset: 0x00EDE41B
		private CommonTabItem TabItemProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
		{
			return new KurotatoTabItem();
		}

		// Token: 0x0603AB16 RID: 240406 RVA: 0x00EE0224 File Offset: 0x00EDE424
		private void ToggleCallBack(int index)
		{
			this.CurrentTabIndex = index;
			TabData tabData = this.TabDataList[index];
			CommonTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(index);
			KurotatoInstInfo currentSaveInstInfo = this.GetCurrentSaveInstInfo();
			this.TabViewComponent.ToggleCallBack(tabData, tabData.ViewName, tabItemByIndex, currentSaveInstInfo, null);
		}

		// Token: 0x0603AB17 RID: 240407 RVA: 0x00EE0278 File Offset: 0x00EDE478
		private CommonTabData GetCommonData(int index)
		{
			TabData tabData = this.TabDataList[index];
			return new CommonTabData(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(tabData.IconResourceId), new CommonTabTitleData(tabData.TitleId, Array.Empty<object>()), null);
		}

		// Token: 0x0603AB18 RID: 240408 RVA: 0x00EE02B8 File Offset: 0x00EDE4B8
		protected override void OnBeforeShow()
		{
			bool flag = this.SaveParam != null && this.SaveParam.InstInfos.Count > 1;
			ButtonItem archiveButton = this.ArchiveButton;
			if (archiveButton != null)
			{
				archiveButton.SetActive(flag);
			}
			if (flag)
			{
				this.RefreshArchiveButtonText();
			}
			TabComponentWithCaptionItem<CommonTabItem> tabComponent = this.TabComponent;
			if (tabComponent == null)
			{
				return;
			}
			tabComponent.SelectToggleByIndex(0, true);
		}

		// Token: 0x0603AB19 RID: 240409 RVA: 0x00EE0311 File Offset: 0x00EDE511
		private void RefreshArchiveButtonText()
		{
			ButtonItem archiveButton = this.ArchiveButton;
			if (archiveButton == null)
			{
				return;
			}
			archiveButton.SetLocalTextNew((this.CurrentSaveIndex == 0) ? "Kurotato_Save_Old" : "Kurotato_Save_New", Array.Empty<object>());
		}

		// Token: 0x0603AB1A RID: 240410 RVA: 0x00EE033C File Offset: 0x00EDE53C
		[NullableContext(2)]
		private KurotatoInstInfo GetCurrentSaveInstInfo()
		{
			if (this.SaveParam == null)
			{
				return null;
			}
			return this.SaveParam.InstInfos[this.CurrentSaveIndex];
		}

		// Token: 0x0603AB1B RID: 240411 RVA: 0x00EE035E File Offset: 0x00EDE55E
		private void OnClickBackBtn()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603AB1C RID: 240412 RVA: 0x00EE0367 File Offset: 0x00EDE567
		private void OnBtnArchiveClick()
		{
			if (this.SaveParam == null)
			{
				return;
			}
			this.CurrentSaveIndex = ((this.CurrentSaveIndex == 0) ? 1 : 0);
			this.RefreshArchiveButtonText();
			this.ToggleCallBack(this.CurrentTabIndex);
		}

		// Token: 0x0603AB1D RID: 240413 RVA: 0x00EE0394 File Offset: 0x00EDE594
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length < 2 || configParams[0] != "DetailTab")
			{
				return null;
			}
			int num;
			if (!int.TryParse(configParams[1], out num))
			{
				return null;
			}
			int num2 = num - 1;
			if (num2 < 0)
			{
				return null;
			}
			TabComponentWithCaptionItem<CommonTabItem> tabComponent = this.TabComponent;
			CommonTabItem commonTabItem = (tabComponent != null) ? tabComponent.GetTabItemByIndex(num2) : null;
			UUIItem uuiitem = (commonTabItem != null) ? commonTabItem.GetRootItem() : null;
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}

		// Token: 0x040212F7 RID: 135927
		private List<TabData> TabDataList = new List<TabData>();

		// Token: 0x040212F8 RID: 135928
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TabComponentWithCaptionItem<CommonTabItem> TabComponent;

		// Token: 0x040212F9 RID: 135929
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected TabViewComponent<TabData> TabViewComponent;

		// Token: 0x040212FA RID: 135930
		[Nullable(2)]
		private IKurotatoSaveViewOpenParam SaveParam;

		// Token: 0x040212FB RID: 135931
		private int CurrentSaveIndex;

		// Token: 0x040212FC RID: 135932
		private int CurrentTabIndex;

		// Token: 0x040212FD RID: 135933
		[Nullable(2)]
		private ButtonItem ArchiveButton;

		// Token: 0x0200BA9D RID: 47773
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x040399E9 RID: 236009
			CaptionList,
			// Token: 0x040399EA RID: 236010
			Content,
			// Token: 0x040399EB RID: 236011
			BtnArchive
		}
	}
}
