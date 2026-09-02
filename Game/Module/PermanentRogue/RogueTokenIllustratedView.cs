using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.RogueBattle;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x020056AE RID: 22190
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueTokenIllustratedView : UiViewBase
	{
		// Token: 0x060387AA RID: 231338 RVA: 0x00E4F716 File Offset: 0x00E4D916
		public RogueTokenIllustratedView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x060387AB RID: 231339 RVA: 0x00E4F72C File Offset: 0x00E4D92C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIExtendToggle))
			};
		}

		// Token: 0x060387AC RID: 231340 RVA: 0x00E4F79C File Offset: 0x00E4D99C
		protected override void OnStart()
		{
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			this.InitTabComponent();
			this.InitExtendToggle();
		}

		// Token: 0x060387AD RID: 231341 RVA: 0x00E4F7BD File Offset: 0x00E4D9BD
		protected override void OnBeforeShow()
		{
			this.RefreshTabListAsync();
		}

		// Token: 0x060387AE RID: 231342 RVA: 0x00E4F7C6 File Offset: 0x00E4D9C6
		protected override void OnBeforeDestroy()
		{
			if (this.TabComponent != null)
			{
				this.TabComponent.Destroy(null);
				this.TabComponent = null;
			}
		}

		// Token: 0x060387AF RID: 231343 RVA: 0x00E4F7E3 File Offset: 0x00E4D9E3
		private void OnCloseClicked()
		{
			base.CloseMe(null);
		}

		// Token: 0x060387B0 RID: 231344 RVA: 0x00E4F7EC File Offset: 0x00E4D9EC
		protected void InitTabComponent()
		{
			CommonTabComponentData<CommonTabItem> data = new CommonTabComponentData<CommonTabItem>(new Func<UUIItem, int?, CommonTabItem>(this.ProxyCreate), new Action<int>(this.ToggleCallBack), new Func<int, CommonTabData>(this.GetCommonData));
			this.TabComponent = new TabComponentWithCaptionItem<CommonTabItem>(base.GetItem(0), data, new Action(this.OnCloseClicked), false);
			this.LastClickTime = null;
			this.TabComponent.SetHelpButtonShowState(false);
			this.TabComponent.SetCanChange(new Func<int, bool?, bool>(this.CanToggleChange));
			this.TabViewComponentInstance = new TabViewComponent<RogueIllustratedTabData>(base.GetItem(1), EKeyMode.Default);
		}

		// Token: 0x060387B1 RID: 231345 RVA: 0x00E4F888 File Offset: 0x00E4DA88
		protected void InitExtendToggle()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(3);
			EToggleState state = (ModelBase<RogueBattleModel>.Instance.DescMode == EDescModel.DETAIL) ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked;
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(state, false, false, false);
			}
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.OnStateChange.Add(new Action<EToggleState>(this.OnExtendToggleStateChange));
		}

		// Token: 0x060387B2 RID: 231346 RVA: 0x00E4F8DC File Offset: 0x00E4DADC
		private UniTask RefreshTabListAsync()
		{
			RogueTokenIllustratedView.<RefreshTabListAsync>d__13 <RefreshTabListAsync>d__;
			<RefreshTabListAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshTabListAsync>d__.<>4__this = this;
			<RefreshTabListAsync>d__.<>1__state = -1;
			<RefreshTabListAsync>d__.<>t__builder.Start<RogueTokenIllustratedView.<RefreshTabListAsync>d__13>(ref <RefreshTabListAsync>d__);
			return <RefreshTabListAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060387B3 RID: 231347 RVA: 0x00E4F920 File Offset: 0x00E4DB20
		private List<CommonTabItemData> GetTabItemData(List<RogueIllustratedTabData> tabData)
		{
			int count = tabData.Count;
			List<CommonTabItemData> list = this.TabComponent.CreateTabItemDataByLength(count);
			for (int i = 0; i < count; i++)
			{
				RogueIllustratedTabData rogueIllustratedTabData = tabData[i];
				if (rogueIllustratedTabData != null)
				{
					list[i].RedDotName = new ERedDotName?(ERedDotName.RogueResIllustratedTokenTab);
					list[i].RedDotUid = new int?((rogueIllustratedTabData.Config != null) ? rogueIllustratedTabData.Config.Value.Id : 0);
				}
			}
			return list;
		}

		// Token: 0x060387B4 RID: 231348 RVA: 0x00E4F9A4 File Offset: 0x00E4DBA4
		private CommonTabData GetCommonData(int index)
		{
			RogueIllustratedTabData rogueIllustratedTabData = this.TabDataList[index];
			return new CommonTabData(rogueIllustratedTabData.Icon, new CommonTabTitleData(rogueIllustratedTabData.TabName, Array.Empty<object>()), null);
		}

		// Token: 0x060387B5 RID: 231349 RVA: 0x00E4F9DC File Offset: 0x00E4DBDC
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

		// Token: 0x060387B6 RID: 231350 RVA: 0x00E4FA62 File Offset: 0x00E4DC62
		private CommonTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
		{
			return new CommonTabItem();
		}

		// Token: 0x060387B7 RID: 231351 RVA: 0x00E4FA6C File Offset: 0x00E4DC6C
		private void ToggleCallBack(int index)
		{
			this.LastClickTime = new double?(Singleton<Time>.Instance.Now);
			RogueIllustratedTabData rogueIllustratedTabData = this.TabDataList[index];
			EUiTabViewName tabViewName = this.GetTabViewName();
			CommonTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(index);
			EToggleState toggleState = base.GetExtendToggle(3).GetToggleState();
			this.TabViewComponentInstance.ToggleCallBack(rogueIllustratedTabData, tabViewName, tabItemByIndex, toggleState, null);
			this.CurSelectSeason = ((rogueIllustratedTabData.Config != null) ? rogueIllustratedTabData.Config.Value.Id : 0);
		}

		// Token: 0x060387B8 RID: 231352 RVA: 0x00E4FB04 File Offset: 0x00E4DD04
		private void OnExtendToggleStateChange(EToggleState newState)
		{
			ModelBase<RogueBattleModel>.Instance.ChangeDescMode();
		}

		// Token: 0x060387B9 RID: 231353 RVA: 0x00E4FB10 File Offset: 0x00E4DD10
		private EUiTabViewName GetTabViewName()
		{
			List<UiDynamicTab> viewTabList = ConfigBase<DynamicTabConfig>.Instance.GetViewTabList(EUiViewName.RogueTokenIllustratedView);
			if (viewTabList.Count == 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.Activity, ELogAuthor.WHJ, "Missing Rogue Illustrated View Config, Use Default", default(ReadOnlySpan<ValueTuple<string, object>>));
				return EUiTabViewName.RogueIllustratedTokenTabView;
			}
			return (EUiTabViewName)viewTabList[0].ChildViewName;
		}

		// Token: 0x060387BA RID: 231354 RVA: 0x00E4FB74 File Offset: 0x00E4DD74
		private List<RogueIllustratedTabData> GetIllustratedTabData()
		{
			List<RogueIllustratedTabData> list = new List<RogueIllustratedTabData>();
			List<UiDynamicTab> viewTabList = ConfigBase<DynamicTabConfig>.Instance.GetViewTabList(EUiViewName.RogueTokenIllustratedView);
			if (viewTabList.Count == 0)
			{
				return list;
			}
			UiDynamicTab uiDynamicTab = viewTabList[0];
			list.Add(new RogueIllustratedTabData
			{
				TabType = ERogueHandbookType.Token,
				Icon = uiDynamicTab.Icon,
				TabName = uiDynamicTab.TabName,
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
					TabType = ERogueHandbookType.Token,
					Icon = configList[i].Icon,
					TabName = configList[i].Name,
					Config = new RogueResTheme?(configList[i]),
					Index = i + 2
				});
			}
			return list;
		}

		// Token: 0x04020414 RID: 132116
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected TabComponentWithCaptionItem<CommonTabItem> TabComponent;

		// Token: 0x04020415 RID: 132117
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected TabViewComponent<RogueIllustratedTabData> TabViewComponentInstance;

		// Token: 0x04020416 RID: 132118
		private double? LastClickTime;

		// Token: 0x04020417 RID: 132119
		protected List<RogueIllustratedTabData> TabDataList = new List<RogueIllustratedTabData>();

		// Token: 0x04020418 RID: 132120
		private int CurSelectSeason;
	}
}
