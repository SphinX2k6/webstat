using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054CF RID: 21711
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PhantomArenaEntranceView : PhantomArenaRootViewBase<PhantomArenaEntranceViewModel>
	{
		// Token: 0x060374D9 RID: 226521 RVA: 0x00E07C63 File Offset: 0x00E05E63
		public PhantomArenaEntranceView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x060374DA RID: 226522 RVA: 0x00E07C6C File Offset: 0x00E05E6C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUISprite)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUITexture)),
				new ValueTuple<int, Type>(11, typeof(UUITexture)),
				new ValueTuple<int, Type>(12, typeof(UUIText)),
				new ValueTuple<int, Type>(13, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(13, new Action(this.OnClickedLevel))
			};
		}

		// Token: 0x060374DB RID: 226523 RVA: 0x00E07DE1 File Offset: 0x00E05FE1
		protected override void OnRegisterDefaultChildView()
		{
			this.DefaultChildViewName = new EPhantomArenaChildViewName?(EPhantomArenaChildViewName.PhantomArenaEntranceGymTabView);
		}

		// Token: 0x060374DC RID: 226524 RVA: 0x00E07DEF File Offset: 0x00E05FEF
		protected override void OnRegisterContentItem()
		{
			this.ContentItem = base.GetItem(7);
		}

		// Token: 0x060374DD RID: 226525 RVA: 0x00E07DFE File Offset: 0x00E05FFE
		protected override void OnRegisterViewData()
		{
			this.ViewModel = new PhantomArenaEntranceViewModel();
			this.ViewModel.Bind(new Action<EViewData>(this.OnViewModelUpdate));
		}

		// Token: 0x060374DE RID: 226526 RVA: 0x00E07E24 File Offset: 0x00E06024
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaEntranceView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaEntranceView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060374DF RID: 226527 RVA: 0x00E07E68 File Offset: 0x00E06068
		private UniTask InitTab()
		{
			PhantomArenaEntranceView.<InitTab>d__12 <InitTab>d__;
			<InitTab>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTab>d__.<>4__this = this;
			<InitTab>d__.<>1__state = -1;
			<InitTab>d__.<>t__builder.Start<PhantomArenaEntranceView.<InitTab>d__12>(ref <InitTab>d__);
			return <InitTab>d__.<>t__builder.Task;
		}

		// Token: 0x060374E0 RID: 226528 RVA: 0x00E07EAB File Offset: 0x00E060AB
		protected override void OnStart()
		{
			base.GetItem(8).SetUIActive(false);
			this.UiViewSequence.AddSequenceFinishEvent("MatchStart", new Action<string>(this.OnMatchStartFinish), false);
		}

		// Token: 0x060374E1 RID: 226529 RVA: 0x00E07ED7 File Offset: 0x00E060D7
		protected override void OnBeforeShow()
		{
			this.RefreshInfo();
			this.BindRedDot();
		}

		// Token: 0x060374E2 RID: 226530 RVA: 0x00E07EE5 File Offset: 0x00E060E5
		protected override void OnBeforeHide()
		{
			this.UnbindRedDot();
		}

		// Token: 0x060374E3 RID: 226531 RVA: 0x00E07EF0 File Offset: 0x00E060F0
		protected override void OnBeforeDestroy()
		{
			this.ViewModel.UnBind(new Action<EViewData>(this.OnViewModelUpdate));
			TabViewComponent<UiDynamicTab> tabViewComponent = this.TabViewComponent;
			if (tabViewComponent != null)
			{
				tabViewComponent.DestroyTabViewComponent();
			}
			this.TabViewComponent = null;
			if (this.TimeHandle != null)
			{
				if (TimerSystem.RealTimeInstance.Has(this.TimeHandle))
				{
					TimerSystem.RealTimeInstance.Remove(this.TimeHandle);
				}
				this.TimeHandle = null;
			}
		}

		// Token: 0x060374E4 RID: 226532 RVA: 0x00E07F60 File Offset: 0x00E06160
		private void RefreshInfo()
		{
			PhantomArenaModel instance = ModelBase<PhantomArenaModel>.Instance;
			int masterLevel = instance.GetMasterLevel(this.ActivityId);
			base.GetText(1).SetText(masterLevel.ToString(), true);
			string newText = StringUtils.Format("/{0}", new string[]
			{
				instance.GetMasterExpNextNeed(this.ActivityId).ToString()
			});
			base.GetText(5).SetText(newText, true);
			int masterExpNow = instance.GetMasterExpNow(this.ActivityId, null);
			base.GetText(4).SetText(masterExpNow.ToString(), true);
			PhantomBattleMasterLevel? masterLevelConfig = instance.GetMasterLevelConfig(masterLevel, this.ActivityId);
			if (masterLevelConfig == null)
			{
				return;
			}
			int titleId = masterLevelConfig.Value.TitleId;
			PhantomBattleMasterTitle phantomBattleMasterTitleById = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleMasterTitleById(titleId);
			base.SetTextureByPath(phantomBattleMasterTitleById.Icon, base.GetTexture(10), null, null);
			base.SetTextureByPath(phantomBattleMasterTitleById.IconBg, base.GetTexture(11), null, null);
			float fillAmount = (float)(masterExpNow - masterLevelConfig.Value.ExpNeed) / (float)masterLevelConfig.Value.ExpNext;
			base.GetSprite(6).SetFillAmount(fillAmount);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), phantomBattleMasterTitleById.Name, Array.Empty<object>());
			ValueTuple<bool, string> valueTuple = ModelBase<PhantomArenaModel>.Instance.IsInLimitTime(this.ActivityId, null);
			bool item = valueTuple.Item1;
			string item2 = valueTuple.Item2;
			ActivityButtonItem btnMission = this.BtnMission;
			if (btnMission != null)
			{
				btnMission.SetUiActive(item);
			}
			if (item)
			{
				this.TimeHandle = TimerSystem.RealTimeInstance.Forever(new TTimerAction(this.OnTimerRefresh), (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
				ActivityButtonItem btnMission2 = this.BtnMission;
				if (btnMission2 != null)
				{
					btnMission2.SetText(item2);
				}
			}
			int masterLevelMax = instance.GetMasterLevelMax(this.ActivityId);
			ActivityButtonItem btnLevel = this.BtnLevel;
			if (btnLevel == null)
			{
				return;
			}
			btnLevel.SetLocalTextNew("PhantomBattle_1025", new object[]
			{
				masterLevel,
				masterLevelMax
			});
		}

		// Token: 0x060374E5 RID: 226533 RVA: 0x00E08178 File Offset: 0x00E06378
		private void RefreshMatchView()
		{
			base.GetItem(8).SetUIActive(true);
			this.UiViewSequence.PlaySequence("MatchStart", false, null);
		}

		// Token: 0x060374E6 RID: 226534 RVA: 0x00E081AC File Offset: 0x00E063AC
		private void OnMatchStartFinish(string _)
		{
			int repeatChallenge = this.ViewModel.GetRepeatChallenge();
			EPhantomArenaChildViewName openView = ModelBase<PhantomArenaModel>.Instance.IsNewPhantomArenaActivity(this.ActivityId) ? EPhantomArenaChildViewName.PhantomArenaChallengeDetailTabViewNew : EPhantomArenaChildViewName.PhantomArenaChallengeDetailTabView;
			PhantomArenaMainViewOpenParam param = new PhantomArenaMainViewOpenParam
			{
				ChallengeId = repeatChallenge,
				OpenView = openView,
				ActivityId = this.ActivityId
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomArenaMainView, param, delegate(bool _, int _)
			{
				base.GetItem(8).SetUIActive(false);
			});
		}

		// Token: 0x060374E7 RID: 226535 RVA: 0x00E08218 File Offset: 0x00E06418
		private void OnClickBtnBack()
		{
			base.Back();
		}

		// Token: 0x060374E8 RID: 226536 RVA: 0x00E08220 File Offset: 0x00E06420
		private void OnClickedMission()
		{
			BattleShopViewOpenParam param = new BattleShopViewOpenParam
			{
				TabViewName = EUiTabViewName.PhantomArenaEntranceTaskTabView,
				ActivityId = this.ActivityId
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomArenaEntranceShopMainView, param, null);
		}

		// Token: 0x060374E9 RID: 226537 RVA: 0x00E0825B File Offset: 0x00E0645B
		private void OnClickedLevel()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomArenaMasterInfoView, this.ActivityId, null);
		}

		// Token: 0x060374EA RID: 226538 RVA: 0x00E08278 File Offset: 0x00E06478
		private void OnClickedHelp()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomArenaHelpView, 334, null);
		}

		// Token: 0x060374EB RID: 226539 RVA: 0x00E08294 File Offset: 0x00E06494
		private void OnViewModelUpdate(EViewData data)
		{
			if (data == EViewData.TabViewName)
			{
				EPhantomArenaChildViewName tabView = this.ViewModel.GetTabView();
				base.OpenChildView(tabView);
				return;
			}
			if (data == EViewData.RepeatChallengeId)
			{
				this.RefreshMatchView();
			}
		}

		// Token: 0x060374EC RID: 226540 RVA: 0x00E082C2 File Offset: 0x00E064C2
		private CommonTabItem TabItemProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
		{
			return new CommonTabItem();
		}

		// Token: 0x060374ED RID: 226541 RVA: 0x00E082C9 File Offset: 0x00E064C9
		private void ToggleCallBack(int index)
		{
		}

		// Token: 0x060374EE RID: 226542 RVA: 0x00E082CB File Offset: 0x00E064CB
		private CommonTabData GetCommonData(int index)
		{
			return new CommonTabData("", null, null);
		}

		// Token: 0x060374EF RID: 226543 RVA: 0x00E082D9 File Offset: 0x00E064D9
		private void BindRedDot()
		{
			ActivityButtonItem btnMission = this.BtnMission;
			if (btnMission != null)
			{
				btnMission.BindRedDot(ERedDotName.RedDotPhantomArenaLimitReward, this.ActivityId);
			}
			ActivityButtonItem btnLevel = this.BtnLevel;
			if (btnLevel == null)
			{
				return;
			}
			btnLevel.BindRedDot(ERedDotName.RedDotPhantomArenaLevelReward, this.ActivityId);
		}

		// Token: 0x060374F0 RID: 226544 RVA: 0x00E08312 File Offset: 0x00E06512
		private void UnbindRedDot()
		{
			ActivityButtonItem btnMission = this.BtnMission;
			if (btnMission != null)
			{
				btnMission.UnBindRedDot();
			}
			ActivityButtonItem btnLevel = this.BtnLevel;
			if (btnLevel == null)
			{
				return;
			}
			btnLevel.UnBindRedDot();
		}

		// Token: 0x060374F1 RID: 226545 RVA: 0x00E08338 File Offset: 0x00E06538
		private void OnTimerRefresh(float gap)
		{
			ValueTuple<bool, string> valueTuple = ModelBase<PhantomArenaModel>.Instance.IsInLimitTime(this.ActivityId, null);
			bool item = valueTuple.Item1;
			string item2 = valueTuple.Item2;
			ActivityButtonItem btnMission = this.BtnMission;
			if (btnMission != null)
			{
				btnMission.SetUiActive(item);
			}
			if (item)
			{
				ActivityButtonItem btnMission2 = this.BtnMission;
				if (btnMission2 == null)
				{
					return;
				}
				btnMission2.SetText(item2);
			}
		}

		// Token: 0x060374F2 RID: 226546 RVA: 0x00E08389 File Offset: 0x00E06589
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams == null || configParams.Length == 0)
			{
				return null;
			}
			if (!(configParams[0] == "GuideHook"))
			{
				return null;
			}
			if (configParams.Length < 2)
			{
				return null;
			}
			PhantomArenaChildViewBase curChildView = base.GetCurChildView();
			if (curChildView == null)
			{
				return null;
			}
			return curChildView.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x0401FC72 RID: 130162
		[Nullable(2)]
		protected TabViewComponent<UiDynamicTab> TabViewComponent;

		// Token: 0x0401FC73 RID: 130163
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected TabComponentWithCaptionItem<CommonTabItem> TabComponent;

		// Token: 0x0401FC74 RID: 130164
		[Nullable(2)]
		private ActivityButtonItem BtnMission;

		// Token: 0x0401FC75 RID: 130165
		[Nullable(2)]
		private ActivityButtonItem BtnLevel;

		// Token: 0x0401FC76 RID: 130166
		[Nullable(2)]
		private TimerHandle TimeHandle;

		// Token: 0x0200B43A RID: 46138
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04037C6D RID: 228461
			public const int ItemCaption = 0;

			// Token: 0x04037C6E RID: 228462
			public const int TextLevel = 1;

			// Token: 0x04037C6F RID: 228463
			public const int ItemBtnMission = 2;

			// Token: 0x04037C70 RID: 228464
			public const int ItemBtnLevel = 3;

			// Token: 0x04037C71 RID: 228465
			public const int TextExpNow = 4;

			// Token: 0x04037C72 RID: 228466
			public const int TextExpMax = 5;

			// Token: 0x04037C73 RID: 228467
			public const int SpriteExp = 6;

			// Token: 0x04037C74 RID: 228468
			public const int ItemContent = 7;

			// Token: 0x04037C75 RID: 228469
			public const int PanelMatch = 8;

			// Token: 0x04037C76 RID: 228470
			public const int PanelMatchTips = 9;

			// Token: 0x04037C77 RID: 228471
			public const int IconTitle = 10;

			// Token: 0x04037C78 RID: 228472
			public const int IconTitleBg = 11;

			// Token: 0x04037C79 RID: 228473
			public const int TextTitle = 12;

			// Token: 0x04037C7A RID: 228474
			public const int BtnLevel = 13;
		}
	}
}
