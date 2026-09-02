using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200609F RID: 24735
	[NullableContext(2)]
	[Nullable(0)]
	public class BattleUiHoverTipsD : BattleChildView
	{
		// Token: 0x0603E729 RID: 255785 RVA: 0x00FF5D8C File Offset: 0x00FF3F8C
		protected override UniTask InitializeAsync(object param = null)
		{
			BattleUiHoverTipsD.<InitializeAsync>d__6 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<BattleUiHoverTipsD.<InitializeAsync>d__6>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E72A RID: 255786 RVA: 0x00FF5DD0 File Offset: 0x00FF3FD0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E72B RID: 255787 RVA: 0x00FF5E5C File Offset: 0x00FF405C
		protected override void OnStart()
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetAnchorHAlign(UIAnchorHorizontalAlign.Center);
			}
			UUIItem rootItem2 = this.RootItem;
			if (rootItem2 != null)
			{
				rootItem2.SetAnchorVAlign(UIAnchorVerticalAlign.Top);
			}
			UUIItem rootItem3 = this.RootItem;
			if (rootItem3 != null)
			{
				rootItem3.SetAnchorOffsetX(0f);
			}
			UUIItem rootItem4 = this.RootItem;
			if (rootItem4 != null)
			{
				rootItem4.SetAnchorOffsetY(0f);
			}
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(delegate(string sequenceName)
			{
				if (sequenceName == "Close")
				{
					this.SetActive(false);
				}
			}, false);
		}

		// Token: 0x0603E72C RID: 255788 RVA: 0x00FF5EE4 File Offset: 0x00FF40E4
		[NullableContext(1)]
		public void CreateAndShow(UUIItem parent, IBattleUiHoverTipsD info)
		{
			string resourceId = "UiItem_HoverTipsD";
			if (this.Created)
			{
				this.UpdateInfo(info);
				this.SetActive(true);
				this.StartCountdown();
				return;
			}
			base.NewByResourceId(parent, resourceId, false, null).ContinueWith(delegate()
			{
				this.Created = true;
				this.UpdateInfo(info);
				this.StartCountdown();
			}).Forget();
		}

		// Token: 0x0603E72D RID: 255789 RVA: 0x00FF5F50 File Offset: 0x00FF4150
		protected override void OnShowBattleChildView()
		{
			this.LevelSequencePlayer.StopCurrentSequence(false, false);
			this.LevelSequencePlayer.PlaySequencePurely("Start", false, false, null, null, false);
		}

		// Token: 0x0603E72E RID: 255790 RVA: 0x00FF5F88 File Offset: 0x00FF4188
		[NullableContext(1)]
		public void UpdateInfo(IBattleUiHoverTipsD info)
		{
			this.Info = info;
			if (!this.Created)
			{
				return;
			}
			BattleUiHoverTipsD.BattleUiInfoItem infoItem = this.InfoItem;
			if (infoItem != null)
			{
				infoItem.Refresh(this.Info);
			}
			if (!string.IsNullOrEmpty(this.Info.DescTitleKey))
			{
				UUIText text = base.GetText(2);
				if (text == null)
				{
					return;
				}
				text.ShowTextNew(this.Info.DescTitleKey);
			}
		}

		// Token: 0x0603E72F RID: 255791 RVA: 0x00FF5FEA File Offset: 0x00FF41EA
		private void StartCountdown()
		{
			this.TimerHandle = TimerSystem.Instance.Delay(new TTimerAction(this.OnTimerEnd), 8000f, null, null, true, 1f);
		}

		// Token: 0x0603E730 RID: 255792 RVA: 0x00FF6018 File Offset: 0x00FF4218
		public void EndShow()
		{
			if (this.TimerHandle != null)
			{
				TimerSystem.Instance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 == null)
			{
				return;
			}
			levelSequencePlayer2.PlayLevelSequenceByName("Close", false, null, false);
		}

		// Token: 0x0603E731 RID: 255793 RVA: 0x00FF6078 File Offset: 0x00FF4278
		private void OnTimerEnd(float _ = 0f)
		{
			if (this.TimerHandle == null)
			{
				return;
			}
			this.EndShow();
			Singleton<EventSystem>.Instance.Emit(EEventName.BattleUiToggleShipTowerBuffInfo);
		}

		// Token: 0x0603E732 RID: 255794 RVA: 0x00FF6099 File Offset: 0x00FF4299
		protected override void OnBeforeDestroy()
		{
			this.OnTimerEnd(0f);
		}

		// Token: 0x0402302B RID: 143403
		private bool Created;

		// Token: 0x0402302C RID: 143404
		private TimerHandle TimerHandle;

		// Token: 0x0402302D RID: 143405
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0402302E RID: 143406
		private IBattleUiHoverTipsD Info;

		// Token: 0x0402302F RID: 143407
		private BattleUiHoverTipsD.BattleUiInfoItem InfoItem;

		// Token: 0x0200C1A8 RID: 49576
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BA1C RID: 244252
			SpriteBg,
			// Token: 0x0403BA1D RID: 244253
			ItemInfo,
			// Token: 0x0403BA1E RID: 244254
			TxtDescTitle
		}

		// Token: 0x0200C1A9 RID: 49577
		[NullableContext(0)]
		public class BattleUiInfoItem : UiPanelBase
		{
			// Token: 0x0604E551 RID: 320849 RVA: 0x015B4D28 File Offset: 0x015B2F28
			protected unsafe override void OnRegisterComponent()
			{
				int num = 5;
				List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
				CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
				Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
				int num2 = 0;
				*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
				this.ComponentRegisterInfos = list;
			}

			// Token: 0x0604E552 RID: 320850 RVA: 0x015B4DF4 File Offset: 0x015B2FF4
			protected override UniTask OnBeforeStartAsync()
			{
				BattleUiHoverTipsD.BattleUiInfoItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
				<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<OnBeforeStartAsync>d__.<>4__this = this;
				<OnBeforeStartAsync>d__.<>1__state = -1;
				<OnBeforeStartAsync>d__.<>t__builder.Start<BattleUiHoverTipsD.BattleUiInfoItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
				return <OnBeforeStartAsync>d__.<>t__builder.Task;
			}

			// Token: 0x0604E553 RID: 320851 RVA: 0x015B4E37 File Offset: 0x015B3037
			[NullableContext(1)]
			private static BattleUiHoverTipsD.BattleUiDescInfoItem CreateItem()
			{
				return new BattleUiHoverTipsD.BattleUiDescInfoItem();
			}

			// Token: 0x0604E554 RID: 320852 RVA: 0x015B4E40 File Offset: 0x015B3040
			[NullableContext(1)]
			public void Refresh(IBattleUiHoverTipsD info)
			{
				SmallItemGrid iconItem = this.IconItem;
				if (iconItem != null)
				{
					iconItem.Apply<IMediumItemGridBase>(info.ItemInfo);
				}
				SmallItemGrid iconItem2 = this.IconItem;
				if (iconItem2 != null)
				{
					iconItem2.SetToggleInteractive(false);
				}
				this.ContentLayout.RefreshByData(info.DescInfoList, null, false);
				UUIText text = base.GetText(0);
				if (!string.IsNullOrEmpty(info.SubTitleKey))
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text, info.SubTitleKey, Array.Empty<object>());
				}
				else if (text != null)
				{
					text.SetText(string.Empty, true);
				}
				UUIText text2 = base.GetText(4);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, info.TitleKey, Array.Empty<object>());
				if (info.TitleColor != null && text2 != null)
				{
					text2.SetColor(info.TitleColor.Value);
				}
			}

			// Token: 0x0403BA1F RID: 244255
			[Nullable(2)]
			private SmallItemGrid IconItem;

			// Token: 0x0403BA20 RID: 244256
			[Nullable(new byte[]
			{
				2,
				1,
				1
			})]
			private GenericLayout<BattleUiHoverTipsD.BattleUiDescInfoItem, IBattleUiHoverTipsDescInfo> ContentLayout;

			// Token: 0x0200CF5E RID: 53086
			private enum EItemChildType
			{
				// Token: 0x0403FDF9 RID: 261625
				TxtSubTitle,
				// Token: 0x0403FDFA RID: 261626
				ItemGrid,
				// Token: 0x0403FDFB RID: 261627
				VLayoutContent,
				// Token: 0x0403FDFC RID: 261628
				ItemDescInfo,
				// Token: 0x0403FDFD RID: 261629
				TxtTitle
			}

			// Token: 0x0200CF5F RID: 53087
			[CompilerGenerated]
			private static class <>O
			{
				// Token: 0x0403FDFE RID: 261630
				[Nullable(new byte[]
				{
					0,
					1
				})]
				public static Func<BattleUiHoverTipsD.BattleUiDescInfoItem> <0>__CreateItem;
			}
		}

		// Token: 0x0200C1AA RID: 49578
		[NullableContext(1)]
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public class BattleUiDescInfoItem : GridProxyAbstract<IBattleUiHoverTipsDescInfo>
		{
			// Token: 0x0604E556 RID: 320854 RVA: 0x015B4F14 File Offset: 0x015B3114
			protected unsafe override void OnRegisterComponent()
			{
				int num = 5;
				List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
				CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
				Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
				int num2 = 0;
				*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
				this.ComponentRegisterInfos = list;
			}

			// Token: 0x0604E557 RID: 320855 RVA: 0x015B4FE0 File Offset: 0x015B31E0
			public override void Refresh(IBattleUiHoverTipsDescInfo data, bool isSelected, int gridIndex)
			{
				UUIText text = base.GetText(2);
				UUIText text2 = base.GetText(1);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.DescKey, Array.Empty<object>());
				if (text != null)
				{
					UUIItem uuiitem = text;
					bool valueOrDefault = data.DescUseChangeColor.GetValueOrDefault();
					FColor? fcolor = new FColor?(text.changeColor);
					uuiitem.SetChangeColor(valueOrDefault, fcolor);
				}
				base.GetItem(4).SetUIActive(data.IsShowState.GetValueOrDefault());
				if (data.IsShowState.GetValueOrDefault())
				{
					bool valueOrDefault2 = data.IsUnlock.GetValueOrDefault();
					FColor color = FColor.FromHex(valueOrDefault2 ? "adfb5aff" : "adadadff");
					if (text2 != null)
					{
						text2.SetColor(color);
					}
					base.GetSprite(0).SetUIActive(valueOrDefault2);
					base.GetSprite(3).SetUIActive(!valueOrDefault2);
					if (!string.IsNullOrEmpty(data.StateTitleKey))
					{
						Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, data.StateTitleKey, Array.Empty<object>());
					}
				}
			}

			// Token: 0x0403BA21 RID: 244257
			private const string EGridCompleteHexColor_Done = "adfb5aff";

			// Token: 0x0403BA22 RID: 244258
			private const string EGridCompleteHexColor_NotDone = "adadadff";

			// Token: 0x0200CF61 RID: 53089
			[NullableContext(0)]
			private enum EDescChildType
			{
				// Token: 0x0403FE05 RID: 261637
				SpriteUnlock,
				// Token: 0x0403FE06 RID: 261638
				TxtState,
				// Token: 0x0403FE07 RID: 261639
				TxtDesc,
				// Token: 0x0403FE08 RID: 261640
				SpriteLock,
				// Token: 0x0403FE09 RID: 261641
				ItemStateRoot
			}
		}
	}
}
