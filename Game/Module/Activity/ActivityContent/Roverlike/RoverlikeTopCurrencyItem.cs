using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006407 RID: 25607
	public class RoverlikeTopCurrencyItem : UiPanelBase
	{
		// Token: 0x06040497 RID: 263319 RVA: 0x01079F80 File Offset: 0x01078180
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBtnCurrencyClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06040498 RID: 263320 RVA: 0x0107A068 File Offset: 0x01078268
		public void SetBtnEnable(bool bEnable)
		{
			UUIButtonComponent button = base.GetButton(0);
			if (button == null)
			{
				return;
			}
			button.SetSelfInteractive(bEnable);
		}

		// Token: 0x06040499 RID: 263321 RVA: 0x0107A07C File Offset: 0x0107827C
		private void Refresh(bool emitAnim = false)
		{
			int gold = ModelBase<RoverlikeModel>.Instance.Gold;
			base.GetText(1).SetText(gold.ToString(), true);
			if (emitAnim)
			{
				this.ShowAddNumAnim(gold - this.TempCurrencyCount);
			}
			this.TempCurrencyCount = gold;
		}

		// Token: 0x0604049A RID: 263322 RVA: 0x0107A0C0 File Offset: 0x010782C0
		private void ShowAddNumAnim(int delta)
		{
			if (delta == 0)
			{
				return;
			}
			UUIText text = base.GetText(2);
			UUIText uuitext = text;
			string newText;
			if (delta <= 0)
			{
				newText = delta.ToString();
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("+");
				defaultInterpolatedStringHandler.AppendFormatted<int>(delta);
				newText = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			uuitext.SetText(newText, true);
			UUIItem uuiitem = text;
			bool bUseChangeColor = delta < 0;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			text.SetUIActive(true);
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayOrReplaySequenceByName("Up", false, null);
		}

		// Token: 0x0604049B RID: 263323 RVA: 0x0107A14F File Offset: 0x0107834F
		[NullableContext(1)]
		private void OnAddNumAnimFinish(string sequenceName)
		{
			if (sequenceName != "Up")
			{
				return;
			}
			UUIText text = base.GetText(2);
			if (text == null)
			{
				return;
			}
			text.SetUIActive(false);
		}

		// Token: 0x0604049C RID: 263324 RVA: 0x0107A174 File Offset: 0x01078374
		private void OnCurrencyChange(int itemId)
		{
			RoverlikeModel instance = ModelBase<RoverlikeModel>.Instance;
			if (instance.InstanceData != null)
			{
				int? goldItemId = instance.GoldItemId;
				if (itemId == goldItemId.GetValueOrDefault() & goldItemId != null)
				{
					this.Refresh(true);
					return;
				}
			}
		}

		// Token: 0x0604049D RID: 263325 RVA: 0x0107A1B2 File Offset: 0x010783B2
		private void OnBtnCurrencyClick()
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.CurrencyItemId, true, null);
		}

		// Token: 0x0604049E RID: 263326 RVA: 0x0107A1C6 File Offset: 0x010783C6
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnAddNumAnimFinish), false);
			this.InitCurrency();
		}

		// Token: 0x0604049F RID: 263327 RVA: 0x0107A1F8 File Offset: 0x010783F8
		public void InitCurrency()
		{
			RoverlikeModel instance = ModelBase<RoverlikeModel>.Instance;
			this.CurrencyItemId = instance.GoldItemId.GetValueOrDefault();
			if (this.CurrencyItemId != 0)
			{
				base.SetItemIcon(base.GetTexture(3), this.CurrencyItemId, null, null);
			}
			base.GetText(2).SetUIActive(false);
			this.Refresh(false);
		}

		// Token: 0x060404A0 RID: 263328 RVA: 0x0107A258 File Offset: 0x01078458
		public void BeginShow()
		{
			this.Refresh(false);
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPlayerCurrencyChange, new Action<int>(this.OnCurrencyChange));
		}

		// Token: 0x060404A1 RID: 263329 RVA: 0x0107A27D File Offset: 0x0107847D
		public void BeginHide()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnPlayerCurrencyChange, new Action<int>(this.OnCurrencyChange));
		}

		// Token: 0x060404A2 RID: 263330 RVA: 0x0107A29B File Offset: 0x0107849B
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
		}

		// Token: 0x04024091 RID: 147601
		private int TempCurrencyCount;

		// Token: 0x04024092 RID: 147602
		private int CurrencyItemId;

		// Token: 0x04024093 RID: 147603
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200C46E RID: 50286
		private class EComponents
		{
			// Token: 0x0403C76C RID: 247660
			public const int BtnCurrency = 0;

			// Token: 0x0403C76D RID: 247661
			public const int TxtNum = 1;

			// Token: 0x0403C76E RID: 247662
			public const int TxtAddNum = 2;

			// Token: 0x0403C76F RID: 247663
			public const int TexIcon = 3;
		}
	}
}
