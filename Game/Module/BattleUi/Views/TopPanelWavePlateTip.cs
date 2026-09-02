using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006119 RID: 24857
	public class TopPanelWavePlateTip : BattleVisibleChildView
	{
		// Token: 0x0603ECAD RID: 257197 RVA: 0x0101470C File Offset: 0x0101290C
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

		// Token: 0x0603ECAE RID: 257198 RVA: 0x01014775 File Offset: 0x01012975
		protected override void OnBeforeCreate()
		{
			this.UiLevelSequence = new UiBehaviorLevelSequence(this);
			base.AddUiBehavior(this.UiLevelSequence);
		}

		// Token: 0x0603ECAF RID: 257199 RVA: 0x0101478F File Offset: 0x0101298F
		[NullableContext(2)]
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			base.InitChildType(EBattleUiChild.MiniMap);
			base.SetVisible(0, true);
		}

		// Token: 0x0603ECB0 RID: 257200 RVA: 0x010147A8 File Offset: 0x010129A8
		protected override void OnShowBattleChildView()
		{
			if (this.IsRefresh)
			{
				Singleton<Log>.Instance.Info(ELogModule.PowerModule, ELogAuthor.BB, "TopPanelWavePlateTip-OnShow Return", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (!ModelBase<PowerModel>.Instance.GetCanShowPowerTip())
			{
				Singleton<Log>.Instance.Info(ELogModule.PowerModule, ELogAuthor.BB, "TopPanelWavePlateTip-Hide", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.SetVisible(0, false);
				return;
			}
			this.IsRefresh = true;
			base.SetVisible(0, true);
			PowerData powerDataById = ModelBase<PowerModel>.Instance.GetPowerDataById(5);
			PowerData powerDataById2 = ModelBase<PowerModel>.Instance.GetPowerDataById(6);
			UUIText text = base.GetText(1);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(powerDataById.GetCurrentPower());
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(powerDataById.GetPowerLimit());
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			base.GetText(0).SetText(powerDataById2.GetCurrentPower().ToString(), true);
			int value = ConfigCommonParamById.GetIntConfig("PowerTipShowTime").Value;
			ModelBase<PowerModel>.Instance.SetCanShowPowerTip(false);
			Singleton<Log>.Instance.Info(ELogModule.PowerModule, ELogAuthor.BB, "TopPanelWavePlateTip-PlaySequence Show", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.UiLevelSequence.PlaySequence("Show", false, null);
			TimerSystem.Instance.Delay(delegate(float _)
			{
				UiBehaviorLevelSequence uiLevelSequence = this.UiLevelSequence;
				if (uiLevelSequence != null)
				{
					uiLevelSequence.PlaySequence("Hide", false, null);
				}
				Singleton<Log>.Instance.Info(ELogModule.PowerModule, ELogAuthor.BB, "TopPanelWavePlateTip-PlaySequence Hide", default(ReadOnlySpan<ValueTuple<string, object>>));
			}, (float)value, null, null, true, 1f);
		}

		// Token: 0x0603ECB1 RID: 257201 RVA: 0x01014908 File Offset: 0x01012B08
		protected override void OnHideBattleChildView()
		{
			Singleton<Log>.Instance.Info(ELogModule.PowerModule, ELogAuthor.BB, "TopPanelWavePlateTip-OnHide", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.IsRefresh = false;
		}

		// Token: 0x04023385 RID: 144261
		[Nullable(2)]
		private UiBehaviorLevelSequence UiLevelSequence;

		// Token: 0x04023386 RID: 144262
		private bool IsRefresh;

		// Token: 0x0200C2A3 RID: 49827
		private enum EComponent
		{
			// Token: 0x0403C01E RID: 245790
			WavePlateCrystalCount,
			// Token: 0x0403C01F RID: 245791
			WavePlateCount
		}
	}
}
