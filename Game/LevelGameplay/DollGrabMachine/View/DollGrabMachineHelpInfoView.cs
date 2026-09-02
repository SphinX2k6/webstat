using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.View
{
	// Token: 0x02006EF7 RID: 28407
	[NullableContext(1)]
	[Nullable(0)]
	public class DollGrabMachineHelpInfoView : UiViewBase
	{
		// Token: 0x06044D7C RID: 281980 RVA: 0x011E9CAF File Offset: 0x011E7EAF
		public DollGrabMachineHelpInfoView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06044D7D RID: 281981 RVA: 0x011E9CCC File Offset: 0x011E7ECC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIMultiTemplateScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06044D7E RID: 281982 RVA: 0x011E9D98 File Offset: 0x011E7F98
		protected override UniTask OnBeforeStartAsync()
		{
			DollGrabMachineHelpInfoView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DollGrabMachineHelpInfoView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06044D7F RID: 281983 RVA: 0x011E9DDB File Offset: 0x011E7FDB
		protected override void OnBeforeShow()
		{
			this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
			UUIItem item = base.GetItem(0);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(true);
		}

		// Token: 0x06044D80 RID: 281984 RVA: 0x011E9E00 File Offset: 0x011E8000
		private TabItem CreateTabItem()
		{
			TabItem tabItem = new TabItem();
			tabItem.SetTabClickCallback(new Action<int>(this.OnClickTab));
			return tabItem;
		}

		// Token: 0x06044D81 RID: 281985 RVA: 0x011E9E1C File Offset: 0x011E801C
		private void OnClickTab(int tabIndex)
		{
			if (this.SelectedTabIndex == tabIndex)
			{
				return;
			}
			this.SelectedTabIndex = tabIndex;
			GenericLayout<TabItem, int> tabLayout = this.TabLayout;
			if (tabLayout != null)
			{
				tabLayout.SelectGridProxy(tabIndex, false);
			}
			this.RefreshDescriptionScroll();
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlayLevelSequenceByName("Switch", false, null, false);
		}

		// Token: 0x06044D82 RID: 281986 RVA: 0x011E9E74 File Offset: 0x011E8074
		private void RefreshDescriptionScroll()
		{
			this.InitScrollViewData();
			MultiTemplateScrollViewRefreshContext multiTemplateScrollViewRefreshContext = new MultiTemplateScrollViewRefreshContext(this.ScrollDataList);
			multiTemplateScrollViewRefreshContext.ScrollToGridIndex = 0;
			MultiTemplateScrollView setMultiTemplateScrollView = this.SetMultiTemplateScrollView;
			if (setMultiTemplateScrollView == null)
			{
				return;
			}
			setMultiTemplateScrollView.RefreshByData(multiTemplateScrollViewRefreshContext);
		}

		// Token: 0x06044D83 RID: 281987 RVA: 0x011E9EAC File Offset: 0x011E80AC
		private void InitScrollViewData()
		{
			this.ScrollDataList = new List<IMultiTemplateGridData>();
			if (this.SelectedTabIndex == 0)
			{
				IReadOnlyList<DollGrabMachineHelpInfo> configList = ConfigDollGrabMachineHelpInfoAll.GetConfigList(true);
				if (configList == null)
				{
					return;
				}
				using (IEnumerator<DollGrabMachineHelpInfo> enumerator = configList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						DollGrabMachineHelpInfo dollGrabMachineHelpInfo = enumerator.Current;
						IDollDescriptionItemData data = new DollDescriptionItemData
						{
							IconPath = dollGrabMachineHelpInfo.IconPath,
							TextTitle = dollGrabMachineHelpInfo.Name,
							TextContent = dollGrabMachineHelpInfo.Description
						};
						DollDescriptionItemTemplateData dollDescriptionItemTemplateData = new DollDescriptionItemTemplateData();
						dollDescriptionItemTemplateData.Data = data;
						this.ScrollDataList.Add(dollDescriptionItemTemplateData);
					}
					return;
				}
			}
			IDollDescriptionItemData data2 = new DollDescriptionItemData
			{
				IconPath = "",
				TextTitle = "KClawIntro_Title",
				TextContent = "KClawIntro_Desc"
			};
			DollPlayDescriptionItemTemplateData dollPlayDescriptionItemTemplateData = new DollPlayDescriptionItemTemplateData();
			dollPlayDescriptionItemTemplateData.Data = data2;
			this.ScrollDataList.Add(dollPlayDescriptionItemTemplateData);
			IDollDescriptionItemData data3 = new DollDescriptionItemData
			{
				IconPath = "",
				TextTitle = "KClawRule_Title",
				TextContent = "KClawRule_Desc"
			};
			DollPlayDescriptionItemTemplateData dollPlayDescriptionItemTemplateData2 = new DollPlayDescriptionItemTemplateData();
			dollPlayDescriptionItemTemplateData2.Data = data3;
			this.ScrollDataList.Add(dollPlayDescriptionItemTemplateData2);
		}

		// Token: 0x0402659E RID: 157086
		[Nullable(2)]
		private DollGrabMachineHelpInfoCaptionPanel CaptionPanel;

		// Token: 0x0402659F RID: 157087
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<TabItem, int> TabLayout;

		// Token: 0x040265A0 RID: 157088
		[Nullable(2)]
		private MultiTemplateScrollView SetMultiTemplateScrollView;

		// Token: 0x040265A1 RID: 157089
		private int SelectedTabIndex = -1;

		// Token: 0x040265A2 RID: 157090
		private List<IMultiTemplateGridData> ScrollDataList = new List<IMultiTemplateGridData>();

		// Token: 0x040265A3 RID: 157091
		[Nullable(2)]
		private LevelSequencePlayer SequencePlayer;
	}
}
