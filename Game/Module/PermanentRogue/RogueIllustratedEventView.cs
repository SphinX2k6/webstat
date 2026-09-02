using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x0200567E RID: 22142
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueIllustratedEventView : UiViewBase
	{
		// Token: 0x060386A3 RID: 231075 RVA: 0x00E49AA5 File Offset: 0x00E47CA5
		public RogueIllustratedEventView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x060386A4 RID: 231076 RVA: 0x00E49AC0 File Offset: 0x00E47CC0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x060386A5 RID: 231077 RVA: 0x00E49AFC File Offset: 0x00E47CFC
		protected override UniTask OnBeforeStartAsync()
		{
			RogueIllustratedEventView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueIllustratedEventView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060386A6 RID: 231078 RVA: 0x00E49B37 File Offset: 0x00E47D37
		protected override void OnStart()
		{
			this.IsNormalEvent = (bool)this.OpenParam;
			this.InitTabComponent();
		}

		// Token: 0x060386A7 RID: 231079 RVA: 0x00E49B50 File Offset: 0x00E47D50
		protected override void OnBeforeShow()
		{
			this.RefreshTabListAsync();
		}

		// Token: 0x060386A8 RID: 231080 RVA: 0x00E49B59 File Offset: 0x00E47D59
		protected override void OnBeforeDestroy()
		{
			this.TabComponent = null;
		}

		// Token: 0x060386A9 RID: 231081 RVA: 0x00E49B64 File Offset: 0x00E47D64
		protected void InitTabComponent()
		{
			this.TabComponent = new TabComponentWithCaptionItem<CommonTabItem>(base.GetItem(0), new CommonTabComponentData<CommonTabItem>(new Func<UUIItem, int?, CommonTabItem>(this.ProxyCreate), new Action<int>(this.ToggleCallBack), new Func<int, CommonTabData>(this.GetCommonData)), new Action(this.OnCloseClicked), false);
			this.LastClickTime = null;
			this.TabComponent.SetCanChange(new Func<int, bool?, bool>(this.CanToggleChange));
			this.TabComponent.SetHelpButtonShowState(false);
			this.TabViewComponentInstance = new TabViewComponent<RogueIllustratedTabData>(base.GetItem(1), EKeyMode.Default);
		}

		// Token: 0x060386AA RID: 231082 RVA: 0x00E49BFB File Offset: 0x00E47DFB
		private void OnCloseClicked()
		{
			base.CloseMe(null);
		}

		// Token: 0x060386AB RID: 231083 RVA: 0x00E49C04 File Offset: 0x00E47E04
		protected bool CanToggleChange(int index, bool? _)
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				return true;
			}
			int? intConfig = ConfigCommonParamById.GetIntConfig("panel_interval_time");
			if (this.LastClickTime != null)
			{
				double num = Singleton<Time>.Instance.Now - this.LastClickTime.Value;
				int? num2 = intConfig;
				double? num3 = (num2 != null) ? new double?((double)num2.GetValueOrDefault()) : null;
				if (!(num >= num3.GetValueOrDefault() & num3 != null))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060386AC RID: 231084 RVA: 0x00E49C8A File Offset: 0x00E47E8A
		private CommonTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
		{
			return new CommonTabItem();
		}

		// Token: 0x060386AD RID: 231085 RVA: 0x00E49C94 File Offset: 0x00E47E94
		private void ToggleCallBack(int index)
		{
			this.LastClickTime = new double?(Singleton<Time>.Instance.Now);
			RogueIllustratedTabData rogueIllustratedTabData = this.TabDataList[index];
			EUiTabViewName tabViewName = this.GetTabViewName();
			CommonTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(index);
			this.TabViewComponentInstance.ToggleCallBack(rogueIllustratedTabData, tabViewName, tabItemByIndex, this.IsNormalEvent, null);
			this.CurSelectSeason = ((rogueIllustratedTabData.Config != null) ? rogueIllustratedTabData.Config.Value.Id : 0);
		}

		// Token: 0x060386AE RID: 231086 RVA: 0x00E49D24 File Offset: 0x00E47F24
		private CommonTabData GetCommonData(int index)
		{
			RogueIllustratedTabData rogueIllustratedTabData = this.TabDataList[index];
			return new CommonTabData(rogueIllustratedTabData.Icon, new CommonTabTitleData(rogueIllustratedTabData.TabName, Array.Empty<object>()), null);
		}

		// Token: 0x060386AF RID: 231087 RVA: 0x00E49D5C File Offset: 0x00E47F5C
		private UniTask RefreshTabListAsync()
		{
			RogueIllustratedEventView.<RefreshTabListAsync>d__18 <RefreshTabListAsync>d__;
			<RefreshTabListAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshTabListAsync>d__.<>4__this = this;
			<RefreshTabListAsync>d__.<>1__state = -1;
			<RefreshTabListAsync>d__.<>t__builder.Start<RogueIllustratedEventView.<RefreshTabListAsync>d__18>(ref <RefreshTabListAsync>d__);
			return <RefreshTabListAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060386B0 RID: 231088 RVA: 0x00E49DA0 File Offset: 0x00E47FA0
		private EUiTabViewName GetTabViewName()
		{
			return (EUiTabViewName)ConfigBase<DynamicTabConfig>.Instance.GetViewTabList(EUiViewName.RogueEventIllustratedView)[0].ChildViewName;
		}

		// Token: 0x060386B1 RID: 231089 RVA: 0x00E49DD4 File Offset: 0x00E47FD4
		private List<CommonTabItemData> GetTabItemData(List<RogueIllustratedTabData> tabData)
		{
			int count = tabData.Count;
			List<CommonTabItemData> list = this.TabComponent.CreateTabItemDataByLength(count);
			for (int i = 0; i < count; i++)
			{
				RogueIllustratedTabData rogueIllustratedTabData = tabData[i];
				if (rogueIllustratedTabData != null)
				{
					list[i].RedDotName = new ERedDotName?(this.IsNormalEvent ? ERedDotName.RogueResIllustratedNormalTab : ERedDotName.RogueResIllustratedMapTab);
					CommonTabItemData commonTabItemData = list[i];
					RogueIllustratedTabData rogueIllustratedTabData2 = rogueIllustratedTabData;
					commonTabItemData.RedDotUid = new int?((rogueIllustratedTabData2.Config != null) ? rogueIllustratedTabData2.Config.GetValueOrDefault().Id : 0);
				}
			}
			return list;
		}

		// Token: 0x060386B2 RID: 231090 RVA: 0x00E49E64 File Offset: 0x00E48064
		private List<RogueIllustratedTabData> GetIllustratedTabData()
		{
			List<RogueIllustratedTabData> list = new List<RogueIllustratedTabData>();
			List<UiDynamicTab> viewTabList = ConfigBase<DynamicTabConfig>.Instance.GetViewTabList(EUiViewName.RogueEventIllustratedView);
			if (viewTabList.Count == 0)
			{
				return list;
			}
			UiDynamicTab uiDynamicTab = viewTabList[0];
			list.Add(new RogueIllustratedTabData
			{
				TabType = (this.IsNormalEvent ? ERogueHandbookType.NormalEvent : ERogueHandbookType.MapEvent),
				Icon = uiDynamicTab.Icon,
				TabName = (this.IsNormalEvent ? "UiDynamicTab_114_TabName_Normal" : "UiDynamicTab_114_TabName_Map"),
				Index = uiDynamicTab.TabIndex,
				Config = null
			});
			IReadOnlyList<RogueResTheme> configList = ConfigRogueResThemeAll.GetConfigList(true);
			if (configList == null)
			{
				return list;
			}
			for (int i = 0; i < configList.Count; i++)
			{
				list.Add(new RogueIllustratedTabData
				{
					TabType = (this.IsNormalEvent ? ERogueHandbookType.NormalEvent : ERogueHandbookType.MapEvent),
					Icon = configList[i].Icon,
					TabName = configList[i].Name,
					Config = new RogueResTheme?(configList[i]),
					Index = i + 2
				});
			}
			return list;
		}

		// Token: 0x04020308 RID: 131848
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected TabComponentWithCaptionItem<CommonTabItem> TabComponent;

		// Token: 0x04020309 RID: 131849
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected TabViewComponent<RogueIllustratedTabData> TabViewComponentInstance;

		// Token: 0x0402030A RID: 131850
		private double? LastClickTime;

		// Token: 0x0402030B RID: 131851
		protected List<RogueIllustratedTabData> TabDataList = new List<RogueIllustratedTabData>();

		// Token: 0x0402030C RID: 131852
		protected bool IsNormalEvent = true;

		// Token: 0x0402030D RID: 131853
		private int CurSelectSeason;
	}
}
