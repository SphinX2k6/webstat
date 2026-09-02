using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006037 RID: 24631
	public class BattleHonamiStoryMapLevelHoverItem : UiPanelBase
	{
		// Token: 0x0603E21D RID: 254493 RVA: 0x00FDBBC4 File Offset: 0x00FD9DC4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E21E RID: 254494 RVA: 0x00FDBC30 File Offset: 0x00FD9E30
		protected override UniTask OnBeforeStartAsync()
		{
			BattleHonamiStoryMapLevelHoverItem.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BattleHonamiStoryMapLevelHoverItem.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E21F RID: 254495 RVA: 0x00FDBC74 File Offset: 0x00FD9E74
		protected override void OnStart()
		{
			UUIItem rootItem = this.RootItem;
			rootItem.SetAnchorHAlign(UIAnchorHorizontalAlign.Center);
			rootItem.SetAnchorVAlign(UIAnchorVerticalAlign.Top);
			rootItem.SetAnchorOffsetX(0f);
			rootItem.SetAnchorOffsetY(0f);
			this.SequencePlayer = new UiSequencePlayer(rootItem);
		}

		// Token: 0x0603E220 RID: 254496 RVA: 0x00FDBCB8 File Offset: 0x00FD9EB8
		protected override void OnBeforeShow()
		{
			this.SequencePlayer.StopPrevSequence(false, true);
			this.SequencePlayer.PlaySequencePurely("Start", false, false);
			this.TimerHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.TimerHandle = null;
				UiSequencePlayer sequencePlayer = this.SequencePlayer;
				if (sequencePlayer != null)
				{
					sequencePlayer.StopPrevSequence(false, true);
				}
				this.SetActive(false);
				Action onAutoClose = this.OnAutoClose;
				if (onAutoClose == null)
				{
					return;
				}
				onAutoClose();
			}, 8000f, null, null, true, 1f);
		}

		// Token: 0x0603E221 RID: 254497 RVA: 0x00FDBD10 File Offset: 0x00FD9F10
		protected override UniTask OnBeforeHideAsync()
		{
			BattleHonamiStoryMapLevelHoverItem.<OnBeforeHideAsync>d__13 <OnBeforeHideAsync>d__;
			<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeHideAsync>d__.<>4__this = this;
			<OnBeforeHideAsync>d__.<>1__state = -1;
			<OnBeforeHideAsync>d__.<>t__builder.Start<BattleHonamiStoryMapLevelHoverItem.<OnBeforeHideAsync>d__13>(ref <OnBeforeHideAsync>d__);
			return <OnBeforeHideAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E222 RID: 254498 RVA: 0x00FDBD53 File Offset: 0x00FD9F53
		public void Refresh()
		{
			BattleHonamiStoryMapLevelHoverItem.HonamiStoryHoverInfoItem infoItem = this.InfoItem;
			if (infoItem == null)
			{
				return;
			}
			infoItem.Refresh();
		}

		// Token: 0x0603E223 RID: 254499 RVA: 0x00FDBD65 File Offset: 0x00FD9F65
		[NullableContext(1)]
		public void RegisterOnAutoClose(Action onAutoClose)
		{
			this.OnAutoClose = onAutoClose;
		}

		// Token: 0x04022D4B RID: 142667
		[Nullable(2)]
		private BattleHonamiStoryMapLevelHoverItem.HonamiStoryHoverInfoItem InfoItem;

		// Token: 0x04022D4C RID: 142668
		[Nullable(2)]
		private UiSequencePlayer SequencePlayer;

		// Token: 0x04022D4D RID: 142669
		[Nullable(2)]
		private TimerHandle TimerHandle;

		// Token: 0x04022D4E RID: 142670
		[Nullable(2)]
		private Action OnAutoClose;

		// Token: 0x0200C0EE RID: 49390
		private enum EHoverItemType
		{
			// Token: 0x0403B69D RID: 243357
			SpriteBg,
			// Token: 0x0403B69E RID: 243358
			ItemInfo
		}

		// Token: 0x0200C0EF RID: 49391
		private enum EInfoItemType
		{
			// Token: 0x0403B6A0 RID: 243360
			TxtTitle,
			// Token: 0x0403B6A1 RID: 243361
			ItemDescInfo,
			// Token: 0x0403B6A2 RID: 243362
			LayoutContent
		}

		// Token: 0x0200C0F0 RID: 49392
		private enum EDescItemType
		{
			// Token: 0x0403B6A4 RID: 243364
			TitleText,
			// Token: 0x0403B6A5 RID: 243365
			DescText
		}

		// Token: 0x0200C0F1 RID: 49393
		public class HonamiStoryHoverDescItem : UiPanelBase
		{
			// Token: 0x0604E456 RID: 320598 RVA: 0x015AA9A4 File Offset: 0x015A8BA4
			protected unsafe override void OnRegisterComponent()
			{
				int num = 2;
				List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
				CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
				Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
				int num2 = 0;
				*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
				this.ComponentRegisterInfos = list;
			}

			// Token: 0x0604E457 RID: 320599 RVA: 0x015AAA0D File Offset: 0x015A8C0D
			protected override void OnStart()
			{
				base.GetText(0).SetUIActive(false);
			}

			// Token: 0x0604E458 RID: 320600 RVA: 0x015AAA1C File Offset: 0x015A8C1C
			public void Refresh()
			{
				int pollutionLevel = ModelBase<HonamiStoryModel>.Instance.PollutionLevel;
				Dictionary<int, IHonamiStoryPollution> pollutionLevelMap = ModelBase<HonamiStoryModel>.Instance.PollutionLevelMap;
				IHonamiStoryPollution honamiStoryPollution = (pollutionLevelMap != null) ? pollutionLevelMap.GetValueOrDefault(pollutionLevel) : null;
				int num = (int)Math.Floor(0.5 + (double)((float)((honamiStoryPollution != null) ? honamiStoryPollution.PersistMilliseconds : 0) * 0.001f));
				int num2 = (honamiStoryPollution != null) ? honamiStoryPollution.MonsterEnhanceLevel : 0;
				if (HonamiStoryUtil.CheckInHonamiStoryTopTower())
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "HonamiStory_PollutionTowerLevelTips", new <>z__ReadOnlyArray<object>(new object[]
					{
						pollutionLevel,
						num2
					}));
					return;
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "HonamiStory_PollutionLevelTips", new <>z__ReadOnlyArray<object>(new object[]
				{
					pollutionLevel,
					num,
					num2
				}));
			}
		}

		// Token: 0x0200C0F2 RID: 49394
		public class HonamiStoryHoverInfoItem : UiPanelBase
		{
			// Token: 0x0604E45A RID: 320602 RVA: 0x015AAB00 File Offset: 0x015A8D00
			protected unsafe override void OnRegisterComponent()
			{
				int num = 3;
				List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
				CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
				Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
				int num2 = 0;
				*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(2, typeof(UUILayoutBase));
				this.ComponentRegisterInfos = list;
			}

			// Token: 0x0604E45B RID: 320603 RVA: 0x015AAB8C File Offset: 0x015A8D8C
			protected override UniTask OnBeforeStartAsync()
			{
				BattleHonamiStoryMapLevelHoverItem.HonamiStoryHoverInfoItem.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
				<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<OnBeforeStartAsync>d__.<>4__this = this;
				<OnBeforeStartAsync>d__.<>1__state = -1;
				<OnBeforeStartAsync>d__.<>t__builder.Start<BattleHonamiStoryMapLevelHoverItem.HonamiStoryHoverInfoItem.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
				return <OnBeforeStartAsync>d__.<>t__builder.Task;
			}

			// Token: 0x0604E45C RID: 320604 RVA: 0x015AABCF File Offset: 0x015A8DCF
			protected override void OnStart()
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "HonamiStory_PollutionLevel", Array.Empty<object>());
			}

			// Token: 0x0604E45D RID: 320605 RVA: 0x015AABEC File Offset: 0x015A8DEC
			protected override void OnBeforeShow()
			{
				this.Refresh();
			}

			// Token: 0x0604E45E RID: 320606 RVA: 0x015AABF4 File Offset: 0x015A8DF4
			public void Refresh()
			{
				BattleHonamiStoryMapLevelHoverItem.HonamiStoryHoverDescItem descItem = this.DescItem;
				if (descItem == null)
				{
					return;
				}
				descItem.Refresh();
			}

			// Token: 0x0403B6A6 RID: 243366
			[Nullable(2)]
			private BattleHonamiStoryMapLevelHoverItem.HonamiStoryHoverDescItem DescItem;
		}
	}
}
