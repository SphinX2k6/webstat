using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhantomArena.Prepare.DeckDetail;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x02005506 RID: 21766
	[NullableContext(1)]
	[Nullable(0)]
	public class DeckBuilderQuicklyBuildView : UiViewBase
	{
		// Token: 0x060377B9 RID: 227257 RVA: 0x00E11A2E File Offset: 0x00E0FC2E
		public DeckBuilderQuicklyBuildView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x060377BA RID: 227258 RVA: 0x00E11A44 File Offset: 0x00E0FC44
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(3, new Action(this.OnConfirmButtonClick)),
				new ValueTuple<int, Delegate>(2, new Action(this.OnCheckButtonClick))
			};
		}

		// Token: 0x060377BB RID: 227259 RVA: 0x00E11AEF File Offset: 0x00E0FCEF
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaCardUnlock, new Action<int>(this.OnPhantomArenaCardUnlock));
		}

		// Token: 0x060377BC RID: 227260 RVA: 0x00E11B0D File Offset: 0x00E0FD0D
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaCardUnlock, new Action<int>(this.OnPhantomArenaCardUnlock));
		}

		// Token: 0x060377BD RID: 227261 RVA: 0x00E11B2C File Offset: 0x00E0FD2C
		protected override UniTask OnBeforeStartAsync()
		{
			DeckBuilderQuicklyBuildView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DeckBuilderQuicklyBuildView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060377BE RID: 227262 RVA: 0x00E11B6F File Offset: 0x00E0FD6F
		protected void SelectDeckByIndex(int index)
		{
			this.DeckLayout.SelectGridProxy(index, false);
		}

		// Token: 0x060377BF RID: 227263 RVA: 0x00E11B7E File Offset: 0x00E0FD7E
		private DeckBuilderQuicklyBuildItem CreateDeckItem()
		{
			return new DeckBuilderQuicklyBuildItem
			{
				OnToggleStateChange = new Action<int>(this.OnItemToggleStateChange)
			};
		}

		// Token: 0x060377C0 RID: 227264 RVA: 0x00E11B97 File Offset: 0x00E0FD97
		private void OnItemToggleStateChange(int gridIndex)
		{
			this.SelectDeckByIndex(gridIndex);
		}

		// Token: 0x060377C1 RID: 227265 RVA: 0x00E11BA0 File Offset: 0x00E0FDA0
		private void OnConfirmButtonClick()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PhantomArenaQuicklyBuildConfirm);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				int selectedGridIndex = this.DeckLayout.GetSelectedGridIndex();
				if (selectedGridIndex < 0)
				{
					return;
				}
				DeckInfo obj = this.DeckList[selectedGridIndex];
				IDeckBuilderQuicklyBuildViewData data = this.Data;
				if (data != null)
				{
					data.ConfirmCallback(obj);
				}
				base.CloseMe(null);
			};
			bool isNew = ModelBase<PhantomArenaModel>.Instance.IsNewPhantomArenaActivity(this.Data.ActivityId);
			ControllerBase<PhantomArenaController>.Instance.OpenPhantomArenaConfirmBoxView(confirmBoxDataNew, isNew);
		}

		// Token: 0x060377C2 RID: 227266 RVA: 0x00E11BF4 File Offset: 0x00E0FDF4
		private void OnCheckButtonClick()
		{
			int selectedGridIndex = this.DeckLayout.GetSelectedGridIndex();
			if (selectedGridIndex < 0)
			{
				return;
			}
			DeckInfo deckInfo = this.DeckList[selectedGridIndex];
			PhantomArenaDeckDetailViewData param = new PhantomArenaDeckDetailViewData
			{
				DeckInfo = deckInfo,
				ShowLocked = true,
				ActivityId = this.Data.ActivityId
			};
			EUiViewName name = ModelBase<PhantomArenaModel>.Instance.IsNewPhantomArenaActivity(this.Data.ActivityId) ? EUiViewName.PhantomArenaDeckDetailViewNew : EUiViewName.PhantomArenaDeckDetailView;
			Singleton<UiManager>.Instance.OpenView(name, param, null);
		}

		// Token: 0x060377C3 RID: 227267 RVA: 0x00E11C75 File Offset: 0x00E0FE75
		private void OnPhantomArenaCardUnlock(int cardId)
		{
			this.DeckLayout.GetLayoutItemList().ToList<DeckBuilderQuicklyBuildItem>().ForEach(delegate(DeckBuilderQuicklyBuildItem item)
			{
				item.RefreshCountText();
			});
		}

		// Token: 0x060377C4 RID: 227268 RVA: 0x00E11CAC File Offset: 0x00E0FEAC
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
			if (!(configParams[0] == "Group"))
			{
				return null;
			}
			int index = int.Parse(configParams[1]);
			GenericLayout<DeckBuilderQuicklyBuildItem, DeckInfo> deckLayout = this.DeckLayout;
			UUIItem uuiitem;
			if (deckLayout == null)
			{
				uuiitem = null;
			}
			else
			{
				DeckBuilderQuicklyBuildItem layoutItemByIndex = deckLayout.GetLayoutItemByIndex(index);
				uuiitem = ((layoutItemByIndex != null) ? layoutItemByIndex.GetRootItem() : null);
			}
			UUIItem uuiitem2 = uuiitem;
			if (uuiitem2 == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem2,
				uuiitem2
			};
		}

		// Token: 0x0401FD5D RID: 130397
		[Nullable(2)]
		private IDeckBuilderQuicklyBuildViewData Data;

		// Token: 0x0401FD5E RID: 130398
		protected List<DeckInfo> DeckList = new List<DeckInfo>();

		// Token: 0x0401FD5F RID: 130399
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericLayout<DeckBuilderQuicklyBuildItem, DeckInfo> DeckLayout;

		// Token: 0x0200B47C RID: 46204
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037DF9 RID: 228857
			public const int DeckLayout = 0;

			// Token: 0x04037DFA RID: 228858
			public const int DeckGridItem = 1;

			// Token: 0x04037DFB RID: 228859
			public const int CheckButton = 2;

			// Token: 0x04037DFC RID: 228860
			public const int ConfirmButton = 3;
		}
	}
}
