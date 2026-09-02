using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006821 RID: 26657
	public class FishingQuestItemChildItem : GridProxyAbstract<int>
	{
		// Token: 0x06042761 RID: 272225 RVA: 0x0110C6D0 File Offset: 0x0110A8D0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 17;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06042762 RID: 272226 RVA: 0x0110C970 File Offset: 0x0110AB70
		protected override void OnStart()
		{
			this.OnAddEventListener();
			base.GetSprite(11).SetUIActive(false);
			base.GetItem(12).SetUIActive(false);
			base.GetItem(10).SetUIActive(false);
			base.GetItem(13).SetUIActive(false);
			base.GetExtendToggle(4).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x06042763 RID: 272227 RVA: 0x0110C9CC File Offset: 0x0110ABCC
		protected override void OnBeforeDestroy()
		{
			this.OnRemoveEventListener();
		}

		// Token: 0x06042764 RID: 272228 RVA: 0x0110C9D4 File Offset: 0x0110ABD4
		protected void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<bool, int?>(EEventName.FishingRefreshQuestView, new Action<bool, int?>(this.FishingRefreshQuestView));
		}

		// Token: 0x06042765 RID: 272229 RVA: 0x0110C9F2 File Offset: 0x0110ABF2
		protected void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<bool, int?>(EEventName.FishingRefreshQuestView, new Action<bool, int?>(this.FishingRefreshQuestView));
		}

		// Token: 0x06042766 RID: 272230 RVA: 0x0110CA10 File Offset: 0x0110AC10
		private void FishingRefreshQuestView(bool keepSelect, int? i = null)
		{
			if (keepSelect)
			{
				this.RefreshItem();
			}
		}

		// Token: 0x06042767 RID: 272231 RVA: 0x0110CA1B File Offset: 0x0110AC1B
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.EntrustId = data;
			this.RefreshItem();
		}

		// Token: 0x06042768 RID: 272232 RVA: 0x0110CA2C File Offset: 0x0110AC2C
		public void RefreshItem()
		{
			if (this.EntrustId == -1)
			{
				this.ShowNullItem();
				return;
			}
			FishingEntrust? fishingEntrust = ConfigBase<FishingConfig>.Instance.GetFishingEntrust(this.EntrustId);
			if (fishingEntrust == null)
			{
				return;
			}
			base.GetText(15).SetUIActive(false);
			base.GetText(2).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), fishingEntrust.Value.Name, Array.Empty<object>());
			base.GetItem(0).SetUIActive(this.EntrustId == ModelBase<FishingQuestModel>.Instance.CurrentTraceEntrust);
			base.GetItem(5).SetColor(FColor.FromHex(FishingDefine.fishingQuestPoolColorText[fishingEntrust.Value.EntrustPool]));
			if (fishingEntrust.Value.EntrustType == 0 || fishingEntrust.Value.EntrustType == 1)
			{
				Dictionary<int, int> dictionary = fishingEntrust.Value.EntrustTarget();
				int num = 0;
				int num2 = 0;
				foreach (KeyValuePair<int, int> keyValuePair in dictionary)
				{
					int num3;
					int num4;
					keyValuePair.Deconstruct(out num3, out num4);
					int itemId = num3;
					int num5 = num4;
					int itemCountByItemId = ModelBase<DockyardModel>.Instance.GetItemCountByItemId(itemId);
					num += num5;
					num2 += Math.Min(itemCountByItemId, num5);
				}
				UUIText text = base.GetText(9);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(num2);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num);
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			else if (fishingEntrust.Value.EntrustType == 2)
			{
				base.GetText(9).SetUIActive(false);
			}
			base.GetItem(16).SetUIActive(fishingEntrust.Value.IsNight);
			this.RefreshStateAbout();
		}

		// Token: 0x06042769 RID: 272233 RVA: 0x0110CC10 File Offset: 0x0110AE10
		private void RefreshStateAbout()
		{
			if (this.EntrustId == -1)
			{
				return;
			}
			FishingEntrust? fishingEntrust = ConfigBase<FishingConfig>.Instance.GetFishingEntrust(this.EntrustId);
			if (fishingEntrust == null)
			{
				return;
			}
			bool flag = fishingEntrust.Value.EntrustPool == 2;
			bool entrustsLockState = ModelBase<FishingQuestModel>.Instance.GetEntrustsLockState(this.EntrustId);
			if (!flag)
			{
				base.GetText(3).SetUIActive(true);
				int star = fishingEntrust.Value.Star;
				this.RefreshStarCount(star);
				this.RefreshStateText();
			}
			else
			{
				base.GetItem(1).SetUIActive(entrustsLockState);
				base.GetText(9).SetUIActive(!entrustsLockState);
				base.GetItem(6).SetUIActive(false);
				base.GetText(3).SetUIActive(false);
				foreach (UUIItem uuiitem in this.StarList)
				{
					uuiitem.SetUIActive(false);
				}
			}
			this.RefreshTime(flag);
			base.GetItem(1).SetUIActive(entrustsLockState);
			base.GetText(9).SetUIActive(!entrustsLockState);
		}

		// Token: 0x0604276A RID: 272234 RVA: 0x0110CD3C File Offset: 0x0110AF3C
		public void RefreshStateText()
		{
			EFishingEntrustState efishingEntrustState;
			if (ModelBase<FishingQuestModel>.Instance.CurrentEntrusts.TryGetValue(this.EntrustId, out efishingEntrustState))
			{
				efishingEntrustState = efishingEntrustState;
			}
			else
			{
				efishingEntrustState = EFishingEntrustState.UnAcceptable;
			}
			base.GetText(3).SetUIActive(true);
			if (base.GetExtendToggle(4).GetToggleState() != EToggleState.ETT_Checked)
			{
				base.GetText(3).SetColor(FColor.FromHex(FishingDefine.fishingStateColorText[(int)efishingEntrustState]));
			}
			else
			{
				base.GetText(3).SetColor(FColor.FromHex(FishingDefine.fishingSelectStateColorText[(int)efishingEntrustState]));
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), FishingDefine.fishingStateText[(int)efishingEntrustState], Array.Empty<object>());
			base.GetItem(6).SetUIActive(efishingEntrustState == EFishingEntrustState.Deliverable);
		}

		// Token: 0x0604276B RID: 272235 RVA: 0x0110CDF0 File Offset: 0x0110AFF0
		private void ShowNullItem()
		{
			base.GetText(15).SetUIActive(true);
			base.GetText(2).SetUIActive(false);
			base.GetItem(0).SetUIActive(false);
			base.GetText(3).SetUIActive(false);
			base.GetItem(1).SetUIActive(false);
			base.GetText(9).SetUIActive(false);
			base.GetText(14).SetUIActive(false);
			base.GetItem(16).SetUIActive(false);
			base.GetItem(6).SetUIActive(false);
			base.GetItem(5).SetColor(FColor.FromHex(FishingDefine.fishingQuestPoolColorText[4]));
			foreach (UUIItem uuiitem in this.StarList)
			{
				uuiitem.SetUIActive(false);
			}
		}

		// Token: 0x0604276C RID: 272236 RVA: 0x0110CED8 File Offset: 0x0110B0D8
		private void RefreshStarCount(int count)
		{
			foreach (UUIItem uuiitem in this.StarList)
			{
				uuiitem.SetUIActive(false);
			}
			for (int i = 0; i < count; i++)
			{
				UUIItem item = base.GetItem(8);
				if (i + 1 > this.StarList.Count)
				{
					UUIItem uuiitem2 = Singleton<LguiUtil>.Instance.CopyItem(base.GetItem(13), item);
					uuiitem2.SetUIActive(true);
					this.StarList.Add(uuiitem2);
				}
				else
				{
					this.StarList[i].SetUIActive(true);
				}
			}
		}

		// Token: 0x0604276D RID: 272237 RVA: 0x0110CF88 File Offset: 0x0110B188
		private void OnClickToggle(EToggleState toggleState)
		{
			Action<int, UUIExtendToggle, Action> onClickTaskCallBack = this.OnClickTaskCallBack;
			if (onClickTaskCallBack != null)
			{
				onClickTaskCallBack(this.EntrustId, base.GetExtendToggle(4), new Action(this.OnUnSelect));
			}
			EFishingEntrustState efishingEntrustState;
			if (ModelBase<FishingQuestModel>.Instance.CurrentEntrusts.TryGetValue(this.EntrustId, out efishingEntrustState))
			{
				efishingEntrustState = efishingEntrustState;
			}
			else
			{
				efishingEntrustState = EFishingEntrustState.UnAcceptable;
			}
			base.GetText(3).SetColor(FColor.FromHex(FishingDefine.fishingSelectStateColorText[(int)efishingEntrustState]));
		}

		// Token: 0x0604276E RID: 272238 RVA: 0x0110CFFC File Offset: 0x0110B1FC
		public void SelectToggle()
		{
			base.GetExtendToggle(4).SetToggleStateForce(EToggleState.ETT_Checked, false, true, false);
			Action<int, UUIExtendToggle, Action> onClickTaskCallBack = this.OnClickTaskCallBack;
			if (onClickTaskCallBack != null)
			{
				onClickTaskCallBack(this.EntrustId, base.GetExtendToggle(4), new Action(this.OnUnSelect));
			}
			EFishingEntrustState efishingEntrustState;
			if (ModelBase<FishingQuestModel>.Instance.CurrentEntrusts.TryGetValue(this.EntrustId, out efishingEntrustState))
			{
				efishingEntrustState = efishingEntrustState;
			}
			else
			{
				efishingEntrustState = EFishingEntrustState.UnAcceptable;
			}
			base.GetText(3).SetColor(FColor.FromHex(FishingDefine.fishingSelectStateColorText[(int)efishingEntrustState]));
		}

		// Token: 0x0604276F RID: 272239 RVA: 0x0110D080 File Offset: 0x0110B280
		private void OnUnSelect()
		{
			EFishingEntrustState efishingEntrustState;
			if (ModelBase<FishingQuestModel>.Instance.CurrentEntrusts.TryGetValue(this.EntrustId, out efishingEntrustState))
			{
				efishingEntrustState = efishingEntrustState;
			}
			else
			{
				efishingEntrustState = EFishingEntrustState.UnAcceptable;
			}
			base.GetText(3).SetColor(FColor.FromHex(FishingDefine.fishingStateColorText[(int)efishingEntrustState]));
		}

		// Token: 0x06042770 RID: 272240 RVA: 0x0110D0C8 File Offset: 0x0110B2C8
		private void RefreshTime(bool isShow)
		{
			if (!isShow)
			{
				base.GetText(14).SetUIActive(false);
				return;
			}
			base.GetText(14).SetUIActive(true);
			double nextDayTimeStamp = Singleton<TimeUtil>.Instance.GetNextDayTimeStamp();
			double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
			int num = (int)Math.Ceiling((nextDayTimeStamp - serverTimeStamp) * Singleton<TimeUtil>.Instance.Millisecond / Singleton<TimeUtil>.Instance.Hour);
			if (num <= 1)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(14), "FishingEntrustRefreshRemainTimeInOneHour", new <>z__ReadOnlySingleElementList<object>(num));
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(14), "FishingEntrustRefreshRemainTime", new <>z__ReadOnlySingleElementList<object>(num));
		}

		// Token: 0x04024FF3 RID: 151539
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Action<int, UUIExtendToggle, Action> OnClickTaskCallBack;

		// Token: 0x04024FF4 RID: 151540
		private int EntrustId;

		// Token: 0x04024FF5 RID: 151541
		[Nullable(1)]
		private readonly List<UUIItem> StarList = new List<UUIItem>();

		// Token: 0x0200C85C RID: 51292
		private class EComponentDefine
		{
			// Token: 0x0403DA85 RID: 252549
			public const int TraceItem = 0;

			// Token: 0x0403DA86 RID: 252550
			public const int LockItem = 1;

			// Token: 0x0403DA87 RID: 252551
			public const int NameText = 2;

			// Token: 0x0403DA88 RID: 252552
			public const int StateText = 3;

			// Token: 0x0403DA89 RID: 252553
			public const int Toggle = 4;

			// Token: 0x0403DA8A RID: 252554
			public const int QualityColorItem = 5;

			// Token: 0x0403DA8B RID: 252555
			public const int RedDotItem = 6;

			// Token: 0x0403DA8C RID: 252556
			public const int CircleSprite = 7;

			// Token: 0x0403DA8D RID: 252557
			public const int StarPanelItem = 8;

			// Token: 0x0403DA8E RID: 252558
			public const int TargetText = 9;

			// Token: 0x0403DA8F RID: 252559
			public const int IconItem = 10;

			// Token: 0x0403DA90 RID: 252560
			public const int IconSprite = 11;

			// Token: 0x0403DA91 RID: 252561
			public const int TagItem = 12;

			// Token: 0x0403DA92 RID: 252562
			public const int StarItem = 13;

			// Token: 0x0403DA93 RID: 252563
			public const int RefreshTimeText = 14;

			// Token: 0x0403DA94 RID: 252564
			public const int LockText = 15;

			// Token: 0x0403DA95 RID: 252565
			public const int NightItem = 16;
		}
	}
}
