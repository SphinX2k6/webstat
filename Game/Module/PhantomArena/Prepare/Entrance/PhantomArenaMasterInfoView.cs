using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AutoAttach;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054DC RID: 21724
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaMasterInfoView : UiViewBase
	{
		// Token: 0x06037588 RID: 226696 RVA: 0x00E0B4B4 File Offset: 0x00E096B4
		public PhantomArenaMasterInfoView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06037589 RID: 226697 RVA: 0x00E0B4C4 File Offset: 0x00E096C4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUITexture)),
				new ValueTuple<int, Type>(4, typeof(UUITexture)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(13, typeof(UUIItem)),
				new ValueTuple<int, Type>(14, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(12, new Action(this.OnClickTake))
			};
		}

		// Token: 0x0603758A RID: 226698 RVA: 0x00E0B650 File Offset: 0x00E09850
		protected override void OnStart()
		{
			this.ActivityId = (int)this.OpenParam;
			this.CaptionItem = new PopupCaptionItem(base.GetItem(13));
			this.CaptionItem.SetHelpCallBack(new Action(this.OnClickHelp));
			this.CaptionItem.SetCloseCallBack(new Action(this.OnClickClose));
			this.LevelAttachView = new NoCircleAttachView<MasterLevelData, MasterLevelItem>(base.GetItem(0).GetOwner(), false);
			UUIItem item = base.GetItem(1);
			item.SetUIActive(false);
			this.LevelAttachView.CreateItems(item.GetOwner(), 0f, new Func<AActor, int, int, MasterLevelItem>(this.CreateLevelItem), EAttachDirection.Horizontal);
			this.RewardLayout = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetHorizontalLayout(8), new Func<CommonItemSmallItemGrid>(this.CreateRewardItem), null, false, true);
			this.ScrollDesc = new GenericScrollViewNew<MasterLevelDescItem, MasterLevelDescData>(base.GetScrollViewWithScrollbar(6), new Func<MasterLevelDescItem>(this.CreateDescItem), null, false, null);
		}

		// Token: 0x0603758B RID: 226699 RVA: 0x00E0B73C File Offset: 0x00E0993C
		protected override UniTask OnCreateAsync()
		{
			PhantomArenaMasterInfoView.<OnCreateAsync>d__10 <OnCreateAsync>d__;
			<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnCreateAsync>d__.<>1__state = -1;
			<OnCreateAsync>d__.<>t__builder.Start<PhantomArenaMasterInfoView.<OnCreateAsync>d__10>(ref <OnCreateAsync>d__);
			return <OnCreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603758C RID: 226700 RVA: 0x00E0B777 File Offset: 0x00E09977
		private MasterLevelItem CreateLevelItem(AActor actor, int index, int showNum)
		{
			MasterLevelItem masterLevelItem = new MasterLevelItem();
			masterLevelItem.CreateThenShowByActor(actor, null);
			masterLevelItem.CallbackOnSelect = new Action<int, MasterLevelItem>(this.OnSelectLevel);
			masterLevelItem.ActivityId = this.ActivityId;
			return masterLevelItem;
		}

		// Token: 0x0603758D RID: 226701 RVA: 0x00E0B7A4 File Offset: 0x00E099A4
		private CommonItemSmallItemGrid CreateRewardItem()
		{
			return new CommonItemSmallItemGrid
			{
				ShowReceivedCallBack = new Func<TItem, bool>(this.OnCheckItemTaken)
			};
		}

		// Token: 0x0603758E RID: 226702 RVA: 0x00E0B7BD File Offset: 0x00E099BD
		private MasterLevelDescItem CreateDescItem()
		{
			return new MasterLevelDescItem();
		}

		// Token: 0x0603758F RID: 226703 RVA: 0x00E0B7C4 File Offset: 0x00E099C4
		protected override void OnBeforeShow()
		{
			this.RefreshLevelView(new bool?(true));
			this.RefreshTitle();
			this.RefreshReward();
		}

		// Token: 0x06037590 RID: 226704 RVA: 0x00E0B7DE File Offset: 0x00E099DE
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaMasterInfoUpdate, new Action(this.OnMasterInfoUpdate));
		}

		// Token: 0x06037591 RID: 226705 RVA: 0x00E0B7FC File Offset: 0x00E099FC
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaMasterInfoUpdate, new Action(this.OnMasterInfoUpdate));
		}

		// Token: 0x06037592 RID: 226706 RVA: 0x00E0B81C File Offset: 0x00E09A1C
		private void RefreshAll()
		{
			this.RefreshLevelView(null);
			this.RefreshTitle();
			this.RefreshDesc();
			this.RefreshReward();
		}

		// Token: 0x06037593 RID: 226707 RVA: 0x00E0B84C File Offset: 0x00E09A4C
		private void RefreshLevelView(bool? isInit = null)
		{
			List<MasterLevelData> masterLevelData = ModelBase<PhantomArenaModel>.Instance.GetMasterLevelData(this.ActivityId);
			int masterLevel = ModelBase<PhantomArenaModel>.Instance.GetMasterLevel(this.ActivityId);
			if (isInit.GetValueOrDefault())
			{
				this.LevelAttachView.ReloadView(masterLevelData.Count, masterLevelData.ToArray(), 0);
				this.LevelAttachView.AttachToIndex(masterLevel - 1, true);
				return;
			}
			foreach (MasterLevelItem masterLevelItem in this.LevelAttachView.GetItems())
			{
				masterLevelItem.SetData(masterLevelData.ToArray());
				masterLevelItem.RefreshItem();
			}
		}

		// Token: 0x06037594 RID: 226708 RVA: 0x00E0B900 File Offset: 0x00E09B00
		private void RefreshTitle()
		{
			PhantomArenaModel instance = ModelBase<PhantomArenaModel>.Instance;
			int masterLevel = instance.GetMasterLevel(this.ActivityId);
			PhantomBattleMasterLevel? masterLevelConfig = instance.GetMasterLevelConfig(masterLevel, this.ActivityId);
			if (masterLevelConfig == null)
			{
				return;
			}
			int titleId = masterLevelConfig.Value.TitleId;
			PhantomBattleMasterTitle phantomBattleMasterTitleById = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleMasterTitleById(titleId);
			base.SetTextureByPath(phantomBattleMasterTitleById.Icon, base.GetTexture(3), null, null);
			base.SetTextureByPath(phantomBattleMasterTitleById.IconBg, base.GetTexture(4), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), phantomBattleMasterTitleById.Name, Array.Empty<object>());
			string text = instance.GetMasterExpNextNeed(this.ActivityId).ToString();
			string text2 = instance.GetMasterExpNow(this.ActivityId, null).ToString();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "TowerDefence_LV", new <>z__ReadOnlyArray<object>(new object[]
			{
				text2,
				text
			}));
		}

		// Token: 0x06037595 RID: 226709 RVA: 0x00E0BA14 File Offset: 0x00E09C14
		private void RefreshDesc()
		{
			List<MasterLevelDescData> masterLevelDescData = ModelBase<PhantomArenaModel>.Instance.GetMasterLevelDescData(this.SelectLevel, this.ActivityId);
			GenericScrollViewNew<MasterLevelDescItem, MasterLevelDescData> scrollDesc = this.ScrollDesc;
			if (scrollDesc == null)
			{
				return;
			}
			scrollDesc.RefreshByData(masterLevelDescData, null, false);
		}

		// Token: 0x06037596 RID: 226710 RVA: 0x00E0BA4C File Offset: 0x00E09C4C
		private void RefreshReward()
		{
			List<TItem> masterLevelRewardList = ModelBase<PhantomArenaModel>.Instance.GetMasterLevelRewardList(this.SelectLevel, this.ActivityId);
			this.RewardLayout.RefreshByData(masterLevelRewardList, null, false);
			bool flag = masterLevelRewardList.Count == 0;
			bool masterLevelRewardIfTaken = ModelBase<PhantomArenaModel>.Instance.GetMasterLevelRewardIfTaken(this.SelectLevel, this.ActivityId);
			bool masterLevelRewardCanTake = ModelBase<PhantomArenaModel>.Instance.GetMasterLevelRewardCanTake(this.SelectLevel, this.ActivityId);
			base.GetItem(10).SetUIActive(masterLevelRewardIfTaken && !flag);
			base.GetItem(11).SetUIActive(!masterLevelRewardIfTaken && !masterLevelRewardCanTake && !flag);
			base.SetButtonUiActive(12, !masterLevelRewardIfTaken && masterLevelRewardCanTake && !flag);
			base.GetItem(14).SetUIActive(!flag);
		}

		// Token: 0x06037597 RID: 226711 RVA: 0x00E0BB10 File Offset: 0x00E09D10
		private void OnClickTake()
		{
			int[] array = (from item in ModelBase<PhantomArenaModel>.Instance.GetMasterLevelData(this.ActivityId)
			where ModelBase<PhantomArenaModel>.Instance.GetMasterLevelRewardCanTake(item.Level, this.ActivityId)
			select item.Level).ToArray<int>();
			if (array.Length != 0)
			{
				ControllerBase<PhantomArenaController>.Instance.MasterLevelMultiRewardRequest(array, this.ActivityId);
			}
		}

		// Token: 0x06037598 RID: 226712 RVA: 0x00E0BB7D File Offset: 0x00E09D7D
		private void OnSelectLevel(int level, MasterLevelItem levelItem)
		{
			if (this.SelectLevel == level)
			{
				return;
			}
			this.SelectLevel = level;
			if (this.LevelAttachView.GetCurrentSelectIndex() != level - 1)
			{
				this.LevelAttachView.AttachToIndex(level - 1, false);
			}
			this.OnSelectedLevelChange();
		}

		// Token: 0x06037599 RID: 226713 RVA: 0x00E0BBB5 File Offset: 0x00E09DB5
		private void OnSelectedLevelChange()
		{
			this.RefreshAll();
		}

		// Token: 0x0603759A RID: 226714 RVA: 0x00E0BBBD File Offset: 0x00E09DBD
		private void OnMasterInfoUpdate()
		{
			this.RefreshAll();
		}

		// Token: 0x0603759B RID: 226715 RVA: 0x00E0BBC5 File Offset: 0x00E09DC5
		private void OnClickHelp()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(341);
		}

		// Token: 0x0603759C RID: 226716 RVA: 0x00E0BBD6 File Offset: 0x00E09DD6
		private void OnClickClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603759D RID: 226717 RVA: 0x00E0BBDF File Offset: 0x00E09DDF
		private bool OnCheckItemTaken(TItem item)
		{
			return ModelBase<PhantomArenaModel>.Instance.GetMasterLevelRewardIfTaken(this.SelectLevel, this.ActivityId);
		}

		// Token: 0x0401FC9C RID: 130204
		protected int ActivityId;

		// Token: 0x0401FC9D RID: 130205
		private int SelectLevel = -1;

		// Token: 0x0401FC9E RID: 130206
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private NoCircleAttachView<MasterLevelData, MasterLevelItem> LevelAttachView;

		// Token: 0x0401FC9F RID: 130207
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x0401FCA0 RID: 130208
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected GenericLayout<CommonItemSmallItemGrid, TItem> RewardLayout;

		// Token: 0x0401FCA1 RID: 130209
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<MasterLevelDescItem, MasterLevelDescData> ScrollDesc;

		// Token: 0x0200B454 RID: 46164
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04037CFF RID: 228607
			public const int PanelLevel = 0;

			// Token: 0x04037D00 RID: 228608
			public const int ItemLevel = 1;

			// Token: 0x04037D01 RID: 228609
			public const int TextExp = 2;

			// Token: 0x04037D02 RID: 228610
			public const int IconTitle = 3;

			// Token: 0x04037D03 RID: 228611
			public const int IconTitleBg = 4;

			// Token: 0x04037D04 RID: 228612
			public const int TextTitle = 5;

			// Token: 0x04037D05 RID: 228613
			public const int ScrollDesc = 6;

			// Token: 0x04037D06 RID: 228614
			public const int ItemDesc = 7;

			// Token: 0x04037D07 RID: 228615
			public const int LayoutReward = 8;

			// Token: 0x04037D08 RID: 228616
			public const int ItemReward = 9;

			// Token: 0x04037D09 RID: 228617
			public const int PanelTaken = 10;

			// Token: 0x04037D0A RID: 228618
			public const int PanelPending = 11;

			// Token: 0x04037D0B RID: 228619
			public const int BtnTake = 12;

			// Token: 0x04037D0C RID: 228620
			public const int ItemCaption = 13;

			// Token: 0x04037D0D RID: 228621
			public const int PanelReward = 14;
		}
	}
}
