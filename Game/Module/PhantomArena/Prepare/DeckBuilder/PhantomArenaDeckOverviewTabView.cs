using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x0200550E RID: 21774
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaDeckOverviewTabView : PhantomArenaChildViewBase
	{
		// Token: 0x17008F22 RID: 36642
		// (get) Token: 0x06037871 RID: 227441 RVA: 0x00E157B1 File Offset: 0x00E139B1
		// (set) Token: 0x06037872 RID: 227442 RVA: 0x00E157BE File Offset: 0x00E139BE
		public new IPhantomArenaDeckOverviewTabViewModel ViewModel
		{
			get
			{
				return this.ViewModel as IPhantomArenaDeckOverviewTabViewModel;
			}
			set
			{
				this.ViewModel = value;
			}
		}

		// Token: 0x06037873 RID: 227443 RVA: 0x00E157C8 File Offset: 0x00E139C8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(2, new Action(this.OnDeleteBtnClick)),
				new ValueTuple<int, Delegate>(3, new Action(this.OnEditDeckBtnClick)),
				new ValueTuple<int, Delegate>(4, new Action(this.OnConfirmBtnClick))
			};
		}

		// Token: 0x06037874 RID: 227444 RVA: 0x00E158E3 File Offset: 0x00E13AE3
		protected override void OnStart()
		{
			base.OnStart();
			this.DeckLoopScroll = new LoopScrollView<PhantomArenaDeckOverviewItem, DeckInfo>(base.GetLoopScrollViewComponent(0), base.GetItem(1).GetOwner() as AUIBaseActor, new Func<PhantomArenaDeckOverviewItem>(this.CreateDeckItem), true);
		}

		// Token: 0x06037875 RID: 227445 RVA: 0x00E1591C File Offset: 0x00E13B1C
		protected override void OnBeforeShow()
		{
			this.ViewModel.SetViewTitle("PhantomArenaDeckOverviewTabView_Name");
			int obj = ModelBase<PhantomArenaModel>.Instance.IsNewPhantomArenaActivity(base.ActivityId) ? 481 : 336;
			this.ViewModel.SetViewHelpId(obj);
			this.ViewModel.SetViewHelpBtnActive(true);
			this.ViewModel.SetViewIcon("SP_IconSoundRemnantArena3");
			IPhantomArenaDeckOverviewTabViewModel viewModel = this.ViewModel;
			if (viewModel != null)
			{
				viewModel.HideRoleTexture(true);
			}
			this.RefreshDeckInfoLayout();
			this.RefreshButtonAndTip();
			if (this.ViewModel != null)
			{
				this.ViewModel.SetOverrideCloseFunc(new Action(this.OnCloseBtnClick));
			}
		}

		// Token: 0x06037876 RID: 227446 RVA: 0x00E159D6 File Offset: 0x00E13BD6
		protected void RefreshDeckInfoLayout()
		{
			this.DeckLoopScroll.RefreshByData(this.ViewModel.EditableDeckList, false, delegate
			{
				this.DeckLoopScroll.ScrollToGridIndex(this.ViewModel.SelectedDeckIndex, false);
				this.DeckLoopScroll.SelectGridProxy(this.ViewModel.SelectedDeckIndex, false);
			}, false);
		}

		// Token: 0x06037877 RID: 227447 RVA: 0x00E159FC File Offset: 0x00E13BFC
		protected void RefreshButtonAndTip()
		{
			IPhantomArenaDeckOverviewTabViewModel viewModel = this.ViewModel;
			bool flag = ((viewModel != null) ? viewModel.RecommendDeck : null) != null;
			UUIItem uuiitem = base.GetButton(4).RootUIComp.Get();
			IPhantomArenaDeckOverviewTabViewModel viewModel2 = this.ViewModel;
			uuiitem.SetUIActive(viewModel2 != null && viewModel2.CanShowSelectBtnInDeckOverviewTabView && !flag);
			string textStringId = flag ? "PhantomBattle_1140" : "PrefabTextItem_1635688567_Text";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), textStringId, Array.Empty<object>());
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(!flag);
			}
			UUIItem item2 = base.GetItem(6);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(flag);
		}

		// Token: 0x06037878 RID: 227448 RVA: 0x00E15AA2 File Offset: 0x00E13CA2
		protected void SelectDeckByIndex(int index)
		{
			if (index < 0 || index >= this.ViewModel.EditableDeckList.Count)
			{
				return;
			}
			this.ViewModel.SelectedDeckIndex = index;
			this.DeckLoopScroll.SelectGridProxy(index, false);
		}

		// Token: 0x06037879 RID: 227449 RVA: 0x00E15AD5 File Offset: 0x00E13CD5
		private PhantomArenaDeckOverviewItem CreateDeckItem()
		{
			return new PhantomArenaDeckOverviewItem
			{
				OnToggleSelect = new Action<int>(this.OnItemToggleSelect),
				ActivityId = base.ActivityId
			};
		}

		// Token: 0x0603787A RID: 227450 RVA: 0x00E15AFA File Offset: 0x00E13CFA
		private void OnItemToggleSelect(int gridIndex)
		{
			this.SelectDeckByIndex(gridIndex);
		}

		// Token: 0x0603787B RID: 227451 RVA: 0x00E15B04 File Offset: 0x00E13D04
		private void OnDeleteBtnClick()
		{
			DeckInfo selectedDeck = this.ViewModel.EditableDeckList[this.ViewModel.SelectedDeckIndex];
			if (selectedDeck.GetDeckServerId() < 0)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomBattle_1070", Array.Empty<object>());
				return;
			}
			if (this.ViewModel == null)
			{
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PhantomArenaDeleteDeckConfirm);
			Action<int> <>9__1;
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				int deckServerId = selectedDeck.GetDeckServerId();
				PhantomArenaController instance = ControllerBase<PhantomArenaController>.Instance;
				int deckServerId2 = deckServerId;
				int activityId = this.ActivityId;
				Action<int> successCallBack;
				if ((successCallBack = <>9__1) == null)
				{
					successCallBack = (<>9__1 = delegate(int deleteIndex)
					{
						int usedDeckIndex = this.ViewModel.UsedDeckIndex;
						if (usedDeckIndex >= 0)
						{
							if (usedDeckIndex == deleteIndex)
							{
								this.ViewModel.UsedDeckIndex = -1;
							}
							else if (usedDeckIndex > deleteIndex)
							{
								IPhantomArenaDeckOverviewTabViewModel viewModel = this.ViewModel;
								int usedDeckIndex2 = viewModel.UsedDeckIndex;
								viewModel.UsedDeckIndex = usedDeckIndex2 - 1;
							}
						}
						IPhantomArenaDeckOverviewTabViewModel viewModel2 = this.ViewModel;
						if (viewModel2 != null)
						{
							viewModel2.UpdateEditableDeckList();
						}
						this.RefreshDeckInfoLayout();
						this.ViewModel.ReportDeckDelete(selectedDeck);
					});
				}
				instance.CardGroupDeleteRequest(deckServerId2, activityId, successCallBack);
			};
			bool isNew = ModelBase<PhantomArenaModel>.Instance.IsNewPhantomArenaActivity(base.ActivityId);
			ControllerBase<PhantomArenaController>.Instance.OpenPhantomArenaConfirmBoxView(confirmBoxDataNew, isNew);
		}

		// Token: 0x0603787C RID: 227452 RVA: 0x00E15BAC File Offset: 0x00E13DAC
		private void OnEditDeckBtnClick()
		{
			IPhantomArenaDeckOverviewTabViewModel viewModel = this.ViewModel;
			if (((viewModel != null) ? viewModel.RecommendDeck : null) != null)
			{
				this.SaveRecommendDeck(this.ViewModel.RecommendDeck);
				return;
			}
			EPhantomArenaChildViewName viewName = ModelBase<PhantomArenaModel>.Instance.IsNewPhantomArenaActivity(base.ActivityId) ? EPhantomArenaChildViewName.PhantomArenaNewDeckBuilderTabView : EPhantomArenaChildViewName.PhantomArenaDeckBuilderTabView;
			DeckInfo deckInfo = this.ViewModel.EditableDeckList[this.ViewModel.SelectedDeckIndex];
			if (deckInfo == null)
			{
				IPhantomArenaDeckOverviewTabViewModel viewModel2 = this.ViewModel;
				DeckInfo deckInfo2 = (viewModel2 != null) ? viewModel2.CreateEmptyTempDeck() : null;
				if (deckInfo2 != null)
				{
					IPhantomArenaDeckOverviewTabViewModel viewModel3 = this.ViewModel;
					if (viewModel3 != null)
					{
						viewModel3.StartEditDeck(deckInfo2);
					}
					base.OpenChildView(viewName);
				}
				return;
			}
			IPhantomArenaDeckOverviewTabViewModel viewModel4 = this.ViewModel;
			DeckInfo deckInfo3 = (viewModel4 != null) ? viewModel4.CreateTempDeckFromDeck(deckInfo) : null;
			if (deckInfo3 != null)
			{
				IPhantomArenaDeckOverviewTabViewModel viewModel5 = this.ViewModel;
				if (viewModel5 != null)
				{
					viewModel5.StartEditDeck(deckInfo3);
				}
				base.OpenChildView(viewName);
			}
		}

		// Token: 0x0603787D RID: 227453 RVA: 0x00E15C78 File Offset: 0x00E13E78
		private void SaveRecommendDeck(DeckInfo deckInfo)
		{
			DeckInfo deckInfo2 = this.ViewModel.EditableDeckList[this.ViewModel.SelectedDeckIndex];
			int deckServerId = deckInfo2.GetDeckServerId();
			if (deckServerId >= 0)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PhantomArenaRecommendOverrideOriginal);
				confirmBoxDataNew.FunctionMap[2] = delegate()
				{
					this.SaveDeckInternal(deckInfo, deckServerId);
				};
				bool isNew = ModelBase<PhantomArenaModel>.Instance.IsNewPhantomArenaActivity(base.ActivityId);
				ControllerBase<PhantomArenaController>.Instance.OpenPhantomArenaConfirmBoxView(confirmBoxDataNew, isNew);
				return;
			}
			this.SaveDeckInternal(deckInfo, deckServerId);
		}

		// Token: 0x0603787E RID: 227454 RVA: 0x00E15D20 File Offset: 0x00E13F20
		private void SaveDeckInternal(DeckInfo deckInfo, int deckServerId)
		{
			Action callback = delegate()
			{
				IPhantomArenaDeckOverviewTabViewModel viewModel = this.ViewModel;
				if (viewModel != null)
				{
					viewModel.UpdateEditableDeckList();
				}
				this.ViewModel.RecommendDeck = null;
				this.RefreshDeckInfoLayout();
				this.RefreshButtonAndTip();
			};
			if (deckServerId < 0)
			{
				ControllerBase<PhantomArenaController>.Instance.CardGroupAddRequest(deckInfo.GetName(), deckInfo.CoverToCardIdList().ToArray(), base.ActivityId, delegate(int _)
				{
					callback();
					if (deckInfo != null)
					{
						this.ViewModel.ReportDeckCreate(deckInfo);
					}
				});
				return;
			}
			List<int> list = deckInfo.CoverToCardIdList();
			ControllerBase<PhantomArenaController>.Instance.CardGroupUpdateRequest(deckServerId, list.ToArray(), base.ActivityId, delegate(int _)
			{
				callback();
				if (deckInfo != null)
				{
					this.ViewModel.ReportDeckCover(deckInfo);
				}
			});
		}

		// Token: 0x0603787F RID: 227455 RVA: 0x00E15DC0 File Offset: 0x00E13FC0
		private void OnConfirmBtnClick()
		{
			DeckInfo deckInfo = this.ViewModel.EditableDeckList[this.ViewModel.SelectedDeckIndex];
			if (deckInfo.GetDeckServerId() < 0 || deckInfo.GetTotalCardCount() <= 0)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomBattle_1069", Array.Empty<object>());
				return;
			}
			this.ViewModel.DeckSelectedConfirmFlag = true;
			this.ViewModel.UsedDeckIndex = this.ViewModel.SelectedDeckIndex;
			base.CloseMe();
		}

		// Token: 0x06037880 RID: 227456 RVA: 0x00E15E38 File Offset: 0x00E14038
		private void OnCloseBtnClick()
		{
			this.ViewModel.RecommendDeck = null;
			base.BackToLastView();
			this.ViewModel.ResetOverrideCloseFunc();
		}

		// Token: 0x06037881 RID: 227457 RVA: 0x00E15E58 File Offset: 0x00E14058
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
			if (!(configParams[0] == "FirstDeck"))
			{
				return null;
			}
			LoopScrollView<PhantomArenaDeckOverviewItem, DeckInfo> deckLoopScroll = this.DeckLoopScroll;
			UUIItem uuiitem = (deckLoopScroll != null) ? deckLoopScroll.GetGridByDisplayIndex(0) : null;
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

		// Token: 0x0401FDA1 RID: 130465
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<PhantomArenaDeckOverviewItem, DeckInfo> DeckLoopScroll;

		// Token: 0x0200B490 RID: 46224
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037E57 RID: 228951
			public const int DeckLoopScrollView = 0;

			// Token: 0x04037E58 RID: 228952
			public const int DeckItem = 1;

			// Token: 0x04037E59 RID: 228953
			public const int DeleteBtn = 2;

			// Token: 0x04037E5A RID: 228954
			public const int EditDeckBtn = 3;

			// Token: 0x04037E5B RID: 228955
			public const int ConfirmBtn = 4;

			// Token: 0x04037E5C RID: 228956
			public const int ItemDeletePanel = 5;

			// Token: 0x04037E5D RID: 228957
			public const int ItemSaveTip = 6;

			// Token: 0x04037E5E RID: 228958
			public const int TextButton = 7;
		}
	}
}
