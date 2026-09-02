using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200640B RID: 25611
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeBattleTopPanel : UiPanelBase
	{
		// Token: 0x060404BF RID: 263359 RVA: 0x0107A9D4 File Offset: 0x01078BD4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnDetailClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnBlessClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnBtnBackClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060404C0 RID: 263360 RVA: 0x0107AB68 File Offset: 0x01078D68
		protected override UniTask OnBeforeStartAsync()
		{
			RoverlikeBattleTopPanel.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoverlikeBattleTopPanel.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060404C1 RID: 263361 RVA: 0x0107ABAC File Offset: 0x01078DAC
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnPanelSequenceClose), false);
			this.BlessingLayout = new GenericLayout<RoverlikeBlessingSlotItem, IRoverlikeBlessingSlotItemData>(base.GetHorizontalLayout(2), () => new RoverlikeBlessingSlotItem(), null, false, true);
			this.RefreshBlessingLayout();
		}

		// Token: 0x060404C2 RID: 263362 RVA: 0x0107AC1C File Offset: 0x01078E1C
		public void SetCurrencyEnableClick(bool bEnable)
		{
			RoverlikeTopCurrencyItem currencyItem = this.CurrencyItem;
			if (currencyItem == null)
			{
				return;
			}
			currencyItem.SetBtnEnable(bEnable);
		}

		// Token: 0x060404C3 RID: 263363 RVA: 0x0107AC2F File Offset: 0x01078E2F
		public void SetRefreshEnabled(bool bEnable)
		{
			this.RefreshEnabled = bEnable;
		}

		// Token: 0x060404C4 RID: 263364 RVA: 0x0107AC38 File Offset: 0x01078E38
		public void StartShow()
		{
			this.RefreshBlessingLayout();
			RoverlikeTopCurrencyItem currencyItem = this.CurrencyItem;
			if (currencyItem != null)
			{
				currencyItem.BeginShow();
			}
			if (this.RefreshEnabled)
			{
				Singleton<EventSystem>.Instance.Add(EEventName.RoverlikeGainDataUpdate, new Action(this.OnGainDataUpdate));
			}
			Singleton<EventSystem>.Instance.Add(EEventName.ActivityDataInitComplete, new Action(this.OnActivityDataInitComplete));
		}

		// Token: 0x060404C5 RID: 263365 RVA: 0x0107AC9C File Offset: 0x01078E9C
		public void EndShow()
		{
			RoverlikeTopCurrencyItem currencyItem = this.CurrencyItem;
			if (currencyItem != null)
			{
				currencyItem.BeginHide();
			}
			if (this.RefreshEnabled)
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.RoverlikeGainDataUpdate, new Action(this.OnGainDataUpdate));
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.ActivityDataInitComplete, new Action(this.OnActivityDataInitComplete));
		}

		// Token: 0x060404C6 RID: 263366 RVA: 0x0107ACFC File Offset: 0x01078EFC
		private void InitBlessingSlot()
		{
			RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
			RoverlikeActivityData roverlikeActivityData = (instance != null) ? instance.GetCurrentActivityData() : null;
			RoverRogueActivity? roverRogueActivity = (roverlikeActivityData != null) ? roverlikeActivityData.GetParamConfig() : null;
			this.BlessSlotIds = ((roverRogueActivity != null) ? roverRogueActivity.Value.SlotList().ToList<int>() : new List<int>());
		}

		// Token: 0x060404C7 RID: 263367 RVA: 0x0107AD5C File Offset: 0x01078F5C
		private void RefreshBlessingLayout()
		{
			IBlessingDisplayDiff blessingDisplayDiff = this.ComputeDisplayDiff();
			bool flag = blessingDisplayDiff.ChangedSlots.Count > 0 || blessingDisplayDiff.Count > this.CachedPassiveCount;
			if (this.RefreshEnabled && this.AnimInitialized && flag)
			{
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer == null || !levelSequencePlayer.IsPlayingSequence("Trail"))
				{
					LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
					if (levelSequencePlayer2 == null)
					{
						return;
					}
					levelSequencePlayer2.PlayOrReplaySequenceByName("Trail", false, null);
				}
				return;
			}
			this.ApplyDisplay(false);
			this.AnimInitialized = true;
		}

		// Token: 0x060404C8 RID: 263368 RVA: 0x0107ADEC File Offset: 0x01078FEC
		private void ApplyDisplay(bool playAnim)
		{
			IBlessingDisplayDiff blessingDisplayDiff = this.ComputeDisplayDiff();
			this.BlessingLayout.RefreshByData(blessingDisplayDiff.DataList, null, false);
			UUIText text = base.GetText(4);
			if (blessingDisplayDiff.Count > 0)
			{
				UUIText uuitext = text;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("+");
				defaultInterpolatedStringHandler.AppendFormatted<int>(blessingDisplayDiff.Count);
				uuitext.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				text.SetUIActive(true);
			}
			else
			{
				text.SetUIActive(false);
			}
			if (playAnim)
			{
				foreach (int num in blessingDisplayDiff.ChangedSlots)
				{
					GenericLayout<RoverlikeBlessingSlotItem, IRoverlikeBlessingSlotItemData> blessingLayout = this.BlessingLayout;
					if (blessingLayout != null)
					{
						RoverlikeBlessingSlotItem layoutItemByKey = blessingLayout.GetLayoutItemByKey(num);
						if (layoutItemByKey != null)
						{
							layoutItemByKey.PlaySelectAnim();
						}
					}
				}
				if (blessingDisplayDiff.Count > this.CachedPassiveCount)
				{
					LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
					if (levelSequencePlayer != null)
					{
						levelSequencePlayer.PlayOrReplaySequenceByName("Num", false, null);
					}
				}
			}
			foreach (IRoverlikeBlessingSlotItemData roverlikeBlessingSlotItemData in blessingDisplayDiff.DataList)
			{
				this.CachedSlotBlessMap[roverlikeBlessingSlotItemData.SlotId] = roverlikeBlessingSlotItemData.Id;
			}
			this.CachedPassiveCount = blessingDisplayDiff.Count;
		}

		// Token: 0x060404C9 RID: 263369 RVA: 0x0107AF60 File Offset: 0x01079160
		private IBlessingDisplayDiff ComputeDisplayDiff()
		{
			RoverlikeInstanceData instanceData = ModelBase<RoverlikeModel>.Instance.InstanceData;
			List<RoverlikeGainEntry> list = ((instanceData != null) ? instanceData.GetBlessList() : null) ?? new List<RoverlikeGainEntry>();
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			foreach (RoverlikeGainEntry roverlikeGainEntry in list)
			{
				RoverRogueBless? blessConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessConfig(roverlikeGainEntry.ConfigId);
				if (blessConfig != null && this.BlessSlotIds.Contains(blessConfig.Value.SlotId))
				{
					dictionary[blessConfig.Value.SlotId] = roverlikeGainEntry.ConfigId;
				}
			}
			List<IRoverlikeBlessingSlotItemData> list2 = new List<IRoverlikeBlessingSlotItemData>();
			List<int> list3 = new List<int>();
			foreach (int num in this.BlessSlotIds)
			{
				int num3;
				int num2 = dictionary.TryGetValue(num, out num3) ? num3 : 0;
				int num5;
				int num4 = this.CachedSlotBlessMap.TryGetValue(num, out num5) ? num5 : 0;
				if (num2 != num4)
				{
					list3.Add(num);
				}
				RoverlikeBlessingSlotItemData item = new RoverlikeBlessingSlotItemData
				{
					Id = num2,
					SlotId = num
				};
				list2.Add(item);
			}
			return new BlessingDisplayDiff
			{
				DataList = list2,
				ChangedSlots = list3,
				Count = this.ComputePassiveCount()
			};
		}

		// Token: 0x060404CA RID: 263370 RVA: 0x0107B0E4 File Offset: 0x010792E4
		private int ComputePassiveCount()
		{
			RoverlikeInstanceData instanceData = ModelBase<RoverlikeModel>.Instance.InstanceData;
			int num = 0;
			foreach (RoverlikeGainEntry roverlikeGainEntry in (((instanceData != null) ? instanceData.GetBlessList() : null) ?? new List<RoverlikeGainEntry>()))
			{
				RoverRogueBless? blessConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessConfig(roverlikeGainEntry.ConfigId);
				if (blessConfig != null && !this.BlessSlotIds.Contains(blessConfig.Value.SlotId))
				{
					num++;
				}
			}
			using (List<RoverlikeGainEntry>.Enumerator enumerator = (((instanceData != null) ? instanceData.GetItemList() : null) ?? new List<RoverlikeGainEntry>()).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.ItemRemainingRooms > 0)
					{
						num++;
					}
				}
			}
			num += ((instanceData != null) ? instanceData.GetRoleEnhanceList().Count : 0);
			return num;
		}

		// Token: 0x060404CB RID: 263371 RVA: 0x0107B1F4 File Offset: 0x010793F4
		private void OnPanelSequenceClose(string sequenceName)
		{
			if (sequenceName != "Trail")
			{
				return;
			}
			this.ApplyDisplay(true);
			this.AnimInitialized = true;
		}

		// Token: 0x060404CC RID: 263372 RVA: 0x0107B212 File Offset: 0x01079412
		private void OnActivityDataInitComplete()
		{
			RoverlikeTopCurrencyItem currencyItem = this.CurrencyItem;
			if (currencyItem != null)
			{
				currencyItem.InitCurrency();
			}
			this.InitBlessingSlot();
			this.RefreshBlessingLayout();
		}

		// Token: 0x060404CD RID: 263373 RVA: 0x0107B231 File Offset: 0x01079431
		private void OnGainDataUpdate()
		{
			this.RefreshBlessingLayout();
		}

		// Token: 0x060404CE RID: 263374 RVA: 0x0107B23C File Offset: 0x0107943C
		private void OnDetailClick()
		{
			ControllerBase<RoverlikeController>.Instance.OpenGameInfoView(null);
		}

		// Token: 0x060404CF RID: 263375 RVA: 0x0107B25C File Offset: 0x0107945C
		private void OnBlessClick()
		{
			ControllerBase<RoverlikeController>.Instance.OpenGameInfoView(new EUiTabViewName?(EUiTabViewName.RoverlikeDetailBlessTabView));
		}

		// Token: 0x060404D0 RID: 263376 RVA: 0x0107B272 File Offset: 0x01079472
		private void OnBtnBackClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikePauseView, null, null);
		}

		// Token: 0x060404D1 RID: 263377 RVA: 0x0107B288 File Offset: 0x01079488
		public void SetHighlightByBlessId(int blessId)
		{
			this.ClearHighlight();
			RoverRogueBless? blessConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessConfig(blessId);
			if (blessConfig == null)
			{
				return;
			}
			GenericLayout<RoverlikeBlessingSlotItem, IRoverlikeBlessingSlotItemData> blessingLayout = this.BlessingLayout;
			if (blessingLayout == null)
			{
				return;
			}
			RoverlikeBlessingSlotItem layoutItemByKey = blessingLayout.GetLayoutItemByKey(blessConfig.Value.SlotId);
			if (layoutItemByKey == null)
			{
				return;
			}
			layoutItemByKey.SetSelectOn(true);
		}

		// Token: 0x060404D2 RID: 263378 RVA: 0x0107B2E0 File Offset: 0x010794E0
		public void ClearHighlight()
		{
			GenericLayout<RoverlikeBlessingSlotItem, IRoverlikeBlessingSlotItemData> blessingLayout = this.BlessingLayout;
			foreach (RoverlikeBlessingSlotItem roverlikeBlessingSlotItem in (((blessingLayout != null) ? blessingLayout.GetLayoutItemList() : null) ?? new List<RoverlikeBlessingSlotItem>()))
			{
				roverlikeBlessingSlotItem.SetSelectOn(false);
			}
		}

		// Token: 0x0402409E RID: 147614
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoverlikeBlessingSlotItem, IRoverlikeBlessingSlotItemData> BlessingLayout;

		// Token: 0x0402409F RID: 147615
		[Nullable(2)]
		protected RoverlikeTopCurrencyItem CurrencyItem;

		// Token: 0x040240A0 RID: 147616
		private List<int> BlessSlotIds = new List<int>();

		// Token: 0x040240A1 RID: 147617
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x040240A2 RID: 147618
		private bool RefreshEnabled;

		// Token: 0x040240A3 RID: 147619
		private bool AnimInitialized;

		// Token: 0x040240A4 RID: 147620
		private int CachedPassiveCount;

		// Token: 0x040240A5 RID: 147621
		private readonly Dictionary<int, int> CachedSlotBlessMap = new Dictionary<int, int>();

		// Token: 0x0200C471 RID: 50289
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C77A RID: 247674
			public const int BtnCommon = 0;

			// Token: 0x0403C77B RID: 247675
			public const int ButtonLayout = 1;

			// Token: 0x0403C77C RID: 247676
			public const int BlessSlotLayout = 2;

			// Token: 0x0403C77D RID: 247677
			public const int BlessingItem = 3;

			// Token: 0x0403C77E RID: 247678
			public const int TxtPassiveBlessCount = 4;

			// Token: 0x0403C77F RID: 247679
			public const int ItemCurrency = 5;

			// Token: 0x0403C780 RID: 247680
			public const int BtnBack = 6;
		}
	}
}
