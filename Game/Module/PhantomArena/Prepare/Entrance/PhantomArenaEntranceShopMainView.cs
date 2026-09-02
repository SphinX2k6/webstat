using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054C9 RID: 21705
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaEntranceShopMainView : UiTickViewBase
	{
		// Token: 0x060374A2 RID: 226466 RVA: 0x00E06F32 File Offset: 0x00E05132
		public PhantomArenaEntranceShopMainView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x060374A3 RID: 226467 RVA: 0x00E06F54 File Offset: 0x00E05154
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIText))
			};
		}

		// Token: 0x060374A4 RID: 226468 RVA: 0x00E06FB0 File Offset: 0x00E051B0
		protected override void OnStart()
		{
			BattleShopViewOpenParam battleShopViewOpenParam = this.OpenParam as BattleShopViewOpenParam;
			this.CurSelectTabView = new EUiTabViewName?(battleShopViewOpenParam.TabViewName);
			this.ActivityId = battleShopViewOpenParam.ActivityId;
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.SetUIActive(true);
			}
			this.InitTabComponent();
			this.CurrencyId = ModelBase<PhantomArenaModel>.Instance.GetCurrencyId(this.ActivityId);
			if (this.CurrencyId > 0)
			{
				TabComponentWithCaptionItem<PhantomArenaEntranceShopTabItem> tabComponent = this.TabComponent;
				if (tabComponent != null)
				{
					tabComponent.SetCurrencyItemList(new List<int>
					{
						this.CurrencyId
					});
				}
			}
			this.RemainTimeText = (ConfigBase<TextConfig>.Instance.GetMultiTextByKey("ActivityRemainingTime") ?? "");
			this.RefreshTime();
		}

		// Token: 0x060374A5 RID: 226469 RVA: 0x00E07068 File Offset: 0x00E05268
		protected override UniTask OnBeforeShowAsyncImplementImplement()
		{
			PhantomArenaEntranceShopMainView.<OnBeforeShowAsyncImplementImplement>d__12 <OnBeforeShowAsyncImplementImplement>d__;
			<OnBeforeShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowAsyncImplementImplement>d__.<>4__this = this;
			<OnBeforeShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Start<PhantomArenaEntranceShopMainView.<OnBeforeShowAsyncImplementImplement>d__12>(ref <OnBeforeShowAsyncImplementImplement>d__);
			return <OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x060374A6 RID: 226470 RVA: 0x00E070AB File Offset: 0x00E052AB
		protected override void OnTick(float delta)
		{
			this.RefreshTime();
		}

		// Token: 0x060374A7 RID: 226471 RVA: 0x00E070B3 File Offset: 0x00E052B3
		protected override void OnBeforeDestroy()
		{
			if (this.TabComponent != null)
			{
				this.TabComponent.Destroy(null);
				this.TabComponent = null;
			}
		}

		// Token: 0x060374A8 RID: 226472 RVA: 0x00E070D0 File Offset: 0x00E052D0
		private void OnCloseClicked()
		{
			base.CloseMe(null);
		}

		// Token: 0x060374A9 RID: 226473 RVA: 0x00E070DC File Offset: 0x00E052DC
		protected void InitTabComponent()
		{
			CommonTabComponentData<PhantomArenaEntranceShopTabItem> data = new CommonTabComponentData<PhantomArenaEntranceShopTabItem>(new Func<UUIItem, int?, PhantomArenaEntranceShopTabItem>(this.ProxyCreate), new Action<int>(this.ToggleCallBack), new Func<int, CommonTabData>(this.GetCommonData));
			this.TabComponent = new TabComponentWithCaptionItem<PhantomArenaEntranceShopTabItem>(base.GetItem(0), data, new Action(this.OnCloseClicked), false);
			this.TabComponent.SetHelpButtonShowState(true);
			this.TabComponent.SetHelpButtonCallBack(new Action(this.OnClickedHelp));
			this.LastClickTime = null;
			this.TabComponent.SetCanChange(new Func<int, bool?, bool>(this.CanToggleChange));
			this.TabViewComponent = new TabViewComponent<UiDynamicTab>(base.GetItem(1), EKeyMode.Default);
		}

		// Token: 0x060374AA RID: 226474 RVA: 0x00E0718C File Offset: 0x00E0538C
		private UniTask RefreshTabListAsync()
		{
			PhantomArenaEntranceShopMainView.<RefreshTabListAsync>d__17 <RefreshTabListAsync>d__;
			<RefreshTabListAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshTabListAsync>d__.<>4__this = this;
			<RefreshTabListAsync>d__.<>1__state = -1;
			<RefreshTabListAsync>d__.<>t__builder.Start<PhantomArenaEntranceShopMainView.<RefreshTabListAsync>d__17>(ref <RefreshTabListAsync>d__);
			return <RefreshTabListAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060374AB RID: 226475 RVA: 0x00E071D0 File Offset: 0x00E053D0
		private PhantomArenaEntranceShopTabData GetCommonData(int index)
		{
			UiDynamicTab uiDynamicTab = this.TabDataList[index];
			return new PhantomArenaEntranceShopTabData(uiDynamicTab.Icon, new CommonTabTitleData("PhantomBattle_1098", Array.Empty<object>()), uiDynamicTab.TabName, (EUiTabViewName)uiDynamicTab.ChildViewName);
		}

		// Token: 0x060374AC RID: 226476 RVA: 0x00E07218 File Offset: 0x00E05418
		protected bool CanToggleChange(int index, bool? _)
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				return true;
			}
			int? intConfig = ConfigCommonParamById.GetIntConfig("panel_interval_time");
			if (this.LastClickTime != null)
			{
				double? num = Singleton<Time>.Instance.Now - this.LastClickTime;
				int? num2 = intConfig;
				double? num3 = (num2 != null) ? new double?((double)num2.GetValueOrDefault()) : null;
				if (!(num.GetValueOrDefault() >= num3.GetValueOrDefault() & (num != null & num3 != null)))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060374AD RID: 226477 RVA: 0x00E072D3 File Offset: 0x00E054D3
		private PhantomArenaEntranceShopTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
		{
			return new PhantomArenaEntranceShopTabItem();
		}

		// Token: 0x060374AE RID: 226478 RVA: 0x00E072DC File Offset: 0x00E054DC
		private void ToggleCallBack(int index)
		{
			this.LastClickTime = new double?(Singleton<Time>.Instance.Now);
			UiDynamicTab data = this.TabDataList[index];
			EUiTabViewName euiTabViewName = (EUiTabViewName)data.ChildViewName;
			PhantomArenaEntranceShopTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(index);
			this.TabViewComponent.ToggleCallBack(data, euiTabViewName, tabItemByIndex, this.ActivityId, null);
			this.CurSelectTabView = new EUiTabViewName?(euiTabViewName);
		}

		// Token: 0x060374AF RID: 226479 RVA: 0x00E07353 File Offset: 0x00E05553
		private void OnClickedHelp()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(335);
		}

		// Token: 0x060374B0 RID: 226480 RVA: 0x00E07364 File Offset: 0x00E05564
		private ERedDotName? GetRedDotNameByTabId(EUiTabViewName tab)
		{
			if (tab == EUiTabViewName.PhantomArenaEntranceTaskTabView)
			{
				return new ERedDotName?(ERedDotName.RedDotPhantomArenaTaskReward);
			}
			if (tab == EUiTabViewName.PhantomArenaEntranceShopTabView)
			{
				return new ERedDotName?(ERedDotName.RedDotPhantomArenaShopUpdate);
			}
			return null;
		}

		// Token: 0x060374B1 RID: 226481 RVA: 0x00E073AC File Offset: 0x00E055AC
		private void RefreshTime()
		{
			ValueTuple<bool, string> valueTuple = ModelBase<PhantomArenaModel>.Instance.IsInLimitTime(this.ActivityId, this.RemainTimeText);
			bool item = valueTuple.Item1;
			string item2 = valueTuple.Item2;
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.SetUIActive(item);
			}
			UUIText text2 = base.GetText(2);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(item2, true);
		}

		// Token: 0x0401FC5C RID: 130140
		protected int ActivityId;

		// Token: 0x0401FC5D RID: 130141
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected TabComponentWithCaptionItem<PhantomArenaEntranceShopTabItem> TabComponent;

		// Token: 0x0401FC5E RID: 130142
		[Nullable(2)]
		protected TabViewComponent<UiDynamicTab> TabViewComponent;

		// Token: 0x0401FC5F RID: 130143
		private double? LastClickTime;

		// Token: 0x0401FC60 RID: 130144
		protected List<UiDynamicTab> TabDataList = new List<UiDynamicTab>();

		// Token: 0x0401FC61 RID: 130145
		private EUiTabViewName? CurSelectTabView;

		// Token: 0x0401FC62 RID: 130146
		private int CurrencyId;

		// Token: 0x0401FC63 RID: 130147
		private string RemainTimeText = "";

		// Token: 0x0200B432 RID: 46130
		[NullableContext(0)]
		private class EChildComponentType
		{
			// Token: 0x04037C4D RID: 228429
			public const int CaptionItem = 0;

			// Token: 0x04037C4E RID: 228430
			public const int InfoContent = 1;

			// Token: 0x04037C4F RID: 228431
			public const int TxtTime = 2;
		}
	}
}
