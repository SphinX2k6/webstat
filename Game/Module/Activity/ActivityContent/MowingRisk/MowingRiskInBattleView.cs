using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x020066A6 RID: 26278
	public class MowingRiskInBattleView : BattleVisibleChildView
	{
		// Token: 0x060419FA RID: 268794 RVA: 0x010D3990 File Offset: 0x010D1B90
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060419FB RID: 268795 RVA: 0x010D3A57 File Offset: 0x010D1C57
		[NullableContext(2)]
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			base.InitChildType(EBattleUiChild.MiniMap);
			base.SetVisible(1, false);
			this.AddEventListeners();
		}

		// Token: 0x060419FC RID: 268796 RVA: 0x010D3A75 File Offset: 0x010D1C75
		public override void Reset()
		{
			base.Reset();
			this.RemoveEventListeners();
		}

		// Token: 0x060419FD RID: 268797 RVA: 0x010D3A83 File Offset: 0x010D1C83
		protected override void OnStart()
		{
			UUISprite sprite = base.GetSprite(2);
			if (sprite != null)
			{
				sprite.SetUIActive(true);
			}
			this.Player = new UiSequencePlayer(base.GetRootItem());
			this.Player.LiteJumpToEnd("Start");
		}

		// Token: 0x060419FE RID: 268798 RVA: 0x010D3AB9 File Offset: 0x010D1CB9
		protected override void OnBeforeDestroy()
		{
			UiSequencePlayer player = this.Player;
			if (player != null)
			{
				player.LiteExit();
			}
			this.Player = null;
		}

		// Token: 0x060419FF RID: 268799 RVA: 0x010D3AD3 File Offset: 0x010D1CD3
		private void OnClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MowingBuffView, EMowingBuffViewUsage.InBattle, null);
		}

		// Token: 0x06041A00 RID: 268800 RVA: 0x010D3AEB File Offset: 0x010D1CEB
		[NullableContext(1)]
		private void OnInputBuffAction(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification _)
		{
			if (actionType != InputDistributeDefine.EActionType.Release)
			{
				return;
			}
			if (ControllerBase<ActivityMowingRiskController>.Instance.CheckInInstanceDungeon())
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.MowingBuffView, EMowingBuffViewUsage.InBattle, null);
			}
		}

		// Token: 0x06041A01 RID: 268801 RVA: 0x010D3B14 File Offset: 0x010D1D14
		private void AddEventListeners()
		{
			Singleton<EventSystem>.Instance.Add<IMowingRiskInBattleRootData>(EEventName.MowingRiskInBattleRootUpdate, new Action<IMowingRiskInBattleRootData>(this.HandleMowingRiskInBattleRootUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.MowingRiskOnNeedPlayLevelUpSequence, new Action(this.HandleMowingRiskOnNeedPlayLevelUpSequence));
			ControllerBase<InputDistributeController>.Instance.BindAction("割草BUFF信息", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputBuffAction));
			ControllerBase<InputDistributeController>.Instance.BindAction("割草BUFF信息PC触摸板", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputBuffAction));
		}

		// Token: 0x06041A02 RID: 268802 RVA: 0x010D3B90 File Offset: 0x010D1D90
		private void RemoveEventListeners()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.MowingRiskInBattleRootUpdate, new Action<IMowingRiskInBattleRootData>(this.HandleMowingRiskInBattleRootUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.MowingRiskOnNeedPlayLevelUpSequence, new Action(this.HandleMowingRiskOnNeedPlayLevelUpSequence));
			ControllerBase<InputDistributeController>.Instance.UnBindAction("割草BUFF信息", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputBuffAction));
			ControllerBase<InputDistributeController>.Instance.UnBindAction("割草BUFF信息PC触摸板", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputBuffAction));
		}

		// Token: 0x06041A03 RID: 268803 RVA: 0x010D3C0B File Offset: 0x010D1E0B
		public void CustomSetActive(bool active)
		{
			base.SetVisible(1, active);
		}

		// Token: 0x06041A04 RID: 268804 RVA: 0x010D3C15 File Offset: 0x010D1E15
		[NullableContext(1)]
		public void RefreshByCustomData(IMowingRiskInBattleRootData data)
		{
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.SetText(data.LevelText, true);
			}
			UUISprite sprite = base.GetSprite(2);
			if (sprite == null)
			{
				return;
			}
			sprite.SetFillAmount(data.ProgressPercentage);
		}

		// Token: 0x06041A05 RID: 268805 RVA: 0x010D3C47 File Offset: 0x010D1E47
		[NullableContext(1)]
		private void HandleMowingRiskInBattleRootUpdate(IMowingRiskInBattleRootData data)
		{
			this.RefreshByCustomData(data);
		}

		// Token: 0x06041A06 RID: 268806 RVA: 0x010D3C50 File Offset: 0x010D1E50
		private void HandleMowingRiskOnNeedPlayLevelUpSequence()
		{
			UiSequencePlayer player = this.Player;
			if (player == null)
			{
				return;
			}
			player.LitePlayAsync("Start", false, false);
		}

		// Token: 0x04024A3E RID: 150078
		[Nullable(2)]
		private UiSequencePlayer Player;

		// Token: 0x0200C6C9 RID: 50889
		private static class EComponent
		{
			// Token: 0x0403D34F RID: 250703
			public const int Button = 0;

			// Token: 0x0403D350 RID: 250704
			public const int LevelText = 1;

			// Token: 0x0403D351 RID: 250705
			public const int ProgressSprite = 2;
		}

		// Token: 0x0200C6CA RID: 50890
		private static class EVisibleReason
		{
			// Token: 0x0403D352 RID: 250706
			public const int Default = 1;
		}
	}
}
