using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Choose
{
	// Token: 0x020055D0 RID: 21968
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaChooseCardPanel : UiPanelBase
	{
		// Token: 0x06037F6F RID: 229231 RVA: 0x00E2CC6C File Offset: 0x00E2AE6C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(3, new Action(this.OnConfirmBtnClick)),
				new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.OnVisibleToggleClick)),
				new ValueTuple<int, Delegate>(5, new Action(this.OnEmptyClick))
			};
		}

		// Token: 0x06037F70 RID: 229232 RVA: 0x00E2CD71 File Offset: 0x00E2AF71
		protected override void OnStart()
		{
			this.Layout = new GenericLayout<PhantomArenaChooseCardItem, PhantomCardData>(base.GetLayoutBase(0), new Func<PhantomArenaChooseCardItem>(this.InitItem), base.GetItem(1).GetOwner() as AUIBaseActor, false, true);
		}

		// Token: 0x06037F71 RID: 229233 RVA: 0x00E2CDA4 File Offset: 0x00E2AFA4
		protected override UniTask OnBeforeShowAsyncImplement()
		{
			PhantomArenaChooseCardPanel.<OnBeforeShowAsyncImplement>d__10 <OnBeforeShowAsyncImplement>d__;
			<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowAsyncImplement>d__.<>4__this = this;
			<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
			<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<PhantomArenaChooseCardPanel.<OnBeforeShowAsyncImplement>d__10>(ref <OnBeforeShowAsyncImplement>d__);
			return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06037F72 RID: 229234 RVA: 0x00E2CDE8 File Offset: 0x00E2AFE8
		protected override void OnAfterHide()
		{
			base.GetItem(2).SetUIActive(true);
			this.ViewProxy.HideCardTips();
			this.ViewProxy.SetCaptionItemActive(true);
			this.ViewProxy.UnRegisterCantDragReason(EPhantomArenaCantDragReason.ChooseCardSkillInteract);
			this.ViewProxy.SetIsMainInVisible(true);
			this.ViewProxy.SetInPanelInteractType(EPhantomArenaBattlePanelInteractType.MainView);
		}

		// Token: 0x06037F73 RID: 229235 RVA: 0x00E2CE3D File Offset: 0x00E2B03D
		protected override void OnAfterShow()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnPhantomArenaChooseCardPanelShow);
		}

		// Token: 0x06037F74 RID: 229236 RVA: 0x00E2CE4F File Offset: 0x00E2B04F
		private PhantomArenaChooseCardItem InitItem()
		{
			return new PhantomArenaChooseCardItem
			{
				ClickCallback = new Action<PhantomCardData, bool>(this.CardClick)
			};
		}

		// Token: 0x06037F75 RID: 229237 RVA: 0x00E2CE68 File Offset: 0x00E2B068
		private void OnVisibleToggleClick(EToggleState state)
		{
			bool flag = state != EToggleState.ETT_Checked;
			this.ViewProxy.SetIsMainInVisible(!flag);
			this.ViewProxy.HideCardTips();
			base.GetItem(2).SetUIActive(flag);
		}

		// Token: 0x06037F76 RID: 229238 RVA: 0x00E2CEA4 File Offset: 0x00E2B0A4
		private void OnConfirmBtnClick()
		{
			this.Data.ConfirmFunc(new List<int>(this.SelectedIdSet)).ContinueWith(delegate()
			{
				if (this.Data.GuideType != null)
				{
					this.ViewProxy.GuideManager.TryFinishGuideByType(this.Data.GuideType.Value, Array.Empty<object>());
				}
			});
		}

		// Token: 0x06037F77 RID: 229239 RVA: 0x00E2CED3 File Offset: 0x00E2B0D3
		private void OnEmptyClick()
		{
			this.CancelSelectState();
		}

		// Token: 0x06037F78 RID: 229240 RVA: 0x00E2CEDC File Offset: 0x00E2B0DC
		private void CardClick(PhantomCardData data, bool isSelected)
		{
			this.HandleSelectState(data.CardId);
			if (isSelected && this.Data.GuideType != null && !this.ViewProxy.GuideManager.CheckCanExecuteAndShowFailTips(this.Data.GuideType.Value, new object[]
			{
				data.ConfigId
			}))
			{
				return;
			}
			if (isSelected && this.SelectedIdSet.Count >= this.LimitCount)
			{
				if (this.LimitCount > 1)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomBattle_1079", Array.Empty<object>());
					return;
				}
				this.CancelChooseLastState();
			}
			this.HandleChooseState(data.CardId, isSelected);
			this.RefreshConfirmInteractive();
			this.RefreshTitle();
		}

		// Token: 0x06037F79 RID: 229241 RVA: 0x00E2CF9C File Offset: 0x00E2B19C
		private void HandleChooseState(int selectId, bool isSelected)
		{
			PhantomArenaChooseCardItem layoutItemByKey = this.Layout.GetLayoutItemByKey(selectId);
			if (layoutItemByKey != null)
			{
				layoutItemByKey.SetChooseState(isSelected);
			}
			if (isSelected)
			{
				this.SelectedIdSet.Add(selectId);
				return;
			}
			this.SelectedIdSet.Remove(selectId);
		}

		// Token: 0x06037F7A RID: 229242 RVA: 0x00E2CFE4 File Offset: 0x00E2B1E4
		private void CancelChooseLastState()
		{
			if (this.SelectedIdSet.Count <= 0)
			{
				return;
			}
			int num = this.SelectedIdSet.First<int>();
			if (num != 0)
			{
				this.HandleChooseState(num, false);
				this.ResetToggleState(num);
			}
		}

		// Token: 0x06037F7B RID: 229243 RVA: 0x00E2D020 File Offset: 0x00E2B220
		private void HandleSelectState(int selectId)
		{
			if (this.CurrentSelectId == selectId)
			{
				return;
			}
			if (this.CurrentSelectId != -1)
			{
				PhantomArenaChooseCardItem layoutItemByKey = this.Layout.GetLayoutItemByKey(this.CurrentSelectId);
				if (layoutItemByKey != null)
				{
					layoutItemByKey.SetSelectState(false);
				}
			}
			PhantomArenaChooseCardItem layoutItemByKey2 = this.Layout.GetLayoutItemByKey(selectId);
			if (layoutItemByKey2 != null)
			{
				layoutItemByKey2.SetSelectState(true);
				this.ViewProxy.ShowCardTips(layoutItemByKey2.Card.Data, false);
			}
			this.CurrentSelectId = selectId;
		}

		// Token: 0x06037F7C RID: 229244 RVA: 0x00E2D09C File Offset: 0x00E2B29C
		private void CancelSelectState()
		{
			if (this.CurrentSelectId == -1)
			{
				return;
			}
			PhantomArenaChooseCardItem layoutItemByKey = this.Layout.GetLayoutItemByKey(this.CurrentSelectId);
			if (layoutItemByKey != null)
			{
				layoutItemByKey.SetSelectState(false);
			}
			this.CurrentSelectId = -1;
			this.ViewProxy.HideCardTips();
		}

		// Token: 0x06037F7D RID: 229245 RVA: 0x00E2D0DC File Offset: 0x00E2B2DC
		private void ResetToggleState(int selectId)
		{
			PhantomArenaChooseCardItem layoutItemByKey = this.Layout.GetLayoutItemByKey(selectId);
			if (layoutItemByKey == null)
			{
				return;
			}
			layoutItemByKey.Card.SetToggleState(EToggleState.ETT_UnChecked, false);
		}

		// Token: 0x06037F7E RID: 229246 RVA: 0x00E2D100 File Offset: 0x00E2B300
		private void RefreshConfirmInteractive()
		{
			base.GetButton(3).SetSelfInteractive(this.SelectedIdSet.Count >= this.LimitCount);
		}

		// Token: 0x06037F7F RID: 229247 RVA: 0x00E2D124 File Offset: 0x00E2B324
		private void RefreshTitle()
		{
			UUIText text = base.GetText(6);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "PhantomBattle_1124", new <>z__ReadOnlyArray<object>(new object[]
			{
				this.SelectedIdSet.Count,
				this.LimitCount
			}));
		}

		// Token: 0x06037F80 RID: 229248 RVA: 0x00E2D175 File Offset: 0x00E2B375
		public void RegisterViewProxy(PhantomArenaBattleProxy proxy)
		{
			this.ViewProxy = proxy;
		}

		// Token: 0x06037F81 RID: 229249 RVA: 0x00E2D17E File Offset: 0x00E2B37E
		public void SetChooseCardData(IChooseCardPanelData data)
		{
			this.Data = data;
		}

		// Token: 0x06037F82 RID: 229250 RVA: 0x00E2D188 File Offset: 0x00E2B388
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			if (configParams[0] == "BattleCardChooseById")
			{
				int num = int.Parse(configParams[1]);
				foreach (PhantomArenaChooseCardItem phantomArenaChooseCardItem in this.Layout.GetLayoutItemList())
				{
					if (phantomArenaChooseCardItem.Card.Data.ConfigId == num)
					{
						UUIItem rootItem = phantomArenaChooseCardItem.Card.GetRootItem();
						if (rootItem != null)
						{
							return new UUIItem[]
							{
								rootItem,
								rootItem
							};
						}
					}
				}
			}
			return null;
		}

		// Token: 0x0402000A RID: 131082
		protected IChooseCardPanelData Data;

		// Token: 0x0402000B RID: 131083
		protected PhantomArenaBattleProxy ViewProxy;

		// Token: 0x0402000C RID: 131084
		protected HashSet<int> SelectedIdSet = new HashSet<int>();

		// Token: 0x0402000D RID: 131085
		protected int LimitCount;

		// Token: 0x0402000E RID: 131086
		protected GenericLayout<PhantomArenaChooseCardItem, PhantomCardData> Layout;

		// Token: 0x0402000F RID: 131087
		protected int CurrentSelectId = -1;

		// Token: 0x04020010 RID: 131088
		public Action ConfirmFunc;

		// Token: 0x0200B5C1 RID: 46529
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x040383D7 RID: 230359
			public const int Layout = 0;

			// Token: 0x040383D8 RID: 230360
			public const int LayoutItem = 1;

			// Token: 0x040383D9 RID: 230361
			public const int ContentItem = 2;

			// Token: 0x040383DA RID: 230362
			public const int ConfirmBtn = 3;

			// Token: 0x040383DB RID: 230363
			public const int VisibleToggle = 4;

			// Token: 0x040383DC RID: 230364
			public const int EmptyBtn = 5;

			// Token: 0x040383DD RID: 230365
			public const int Title = 6;
		}
	}
}
