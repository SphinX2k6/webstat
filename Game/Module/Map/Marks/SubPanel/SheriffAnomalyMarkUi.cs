using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Sheriff;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.SubPanel
{
	// Token: 0x02005836 RID: 22582
	public class SheriffAnomalyMarkUi : UiPanelBase
	{
		// Token: 0x0603967A RID: 235130 RVA: 0x00E93180 File Offset: 0x00E91380
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603967B RID: 235131 RVA: 0x00E932AF File Offset: 0x00E914AF
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new UiSequencePlayer(this.RootItem);
			UUIText text = base.GetText(7);
			if (text == null)
			{
				return;
			}
			text.SetText("?", true);
		}

		// Token: 0x0603967C RID: 235132 RVA: 0x00E932D9 File Offset: 0x00E914D9
		protected override void OnAfterShow()
		{
		}

		// Token: 0x0603967D RID: 235133 RVA: 0x00E932DC File Offset: 0x00E914DC
		public void SetData(int markId)
		{
			SheriffAnomaly? anomalyConfigByMarkId = ConfigBase<SheriffConfig>.Instance.GetAnomalyConfigByMarkId(markId);
			SheriffAnomalyInfo anomalyInfo = ModelBase<SheriffModel>.Instance.GetAnomalyInfo(anomalyConfigByMarkId.Value.Id);
			int currentProgress = (anomalyInfo != null) ? anomalyInfo.Progress : 0;
			ESheriffAnomalyState currentState = (anomalyInfo != null) ? anomalyInfo.State : ESheriffAnomalyState.Lock;
			this.MarkId = markId;
			this.CurrentProgress = currentProgress;
			this.CurrentState = currentState;
			this.RefreshUi();
		}

		// Token: 0x0603967E RID: 235134 RVA: 0x00E93344 File Offset: 0x00E91544
		private void RefreshUi()
		{
			SheriffAnomaly? anomalyConfigByMarkId = ConfigBase<SheriffConfig>.Instance.GetAnomalyConfigByMarkId(this.MarkId);
			if (anomalyConfigByMarkId == null)
			{
				return;
			}
			bool flag = this.CurrentState == ESheriffAnomalyState.Completed;
			bool flag2 = ModelBase<SheriffModel>.Instance.GetCriminalInfo(anomalyConfigByMarkId.Value.CriminalId).State >= ESheriffCriminalState.Confirmed;
			this.RefreshCriminal(flag2, anomalyConfigByMarkId.Value);
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(!flag2);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 != null)
			{
				item2.SetUIActive(flag);
			}
			this.RefreshName(flag, anomalyConfigByMarkId.Value);
			this.RefreshProgress(flag, anomalyConfigByMarkId.Value);
			this.RefreshBg(flag);
		}

		// Token: 0x0603967F RID: 235135 RVA: 0x00E933F8 File Offset: 0x00E915F8
		private void RefreshCriminal(bool isKnown, SheriffAnomaly config)
		{
			if (isKnown)
			{
				base.TrySetSpriteByPath(this.GetMarkIcon(config), base.GetSprite(1), false, null, null);
				return;
			}
			UUISprite sprite = base.GetSprite(1);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(false);
		}

		// Token: 0x06039680 RID: 235136 RVA: 0x00E9343C File Offset: 0x00E9163C
		private void RefreshName(bool isCompleted, SheriffAnomaly config)
		{
			bool flag = ModelBase<WorldMapModel>.Instance.MapScale * 100f > (float)config.TextVisibleScale;
			if (isCompleted || !flag)
			{
				UUIText text = base.GetText(4);
				if (text == null)
				{
					return;
				}
				text.SetUIActive(false);
				return;
			}
			else
			{
				if (this.CurrentState == ESheriffAnomalyState.UnActivated)
				{
					Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(4), "Sheriff_Unknow_1", Array.Empty<object>());
					return;
				}
				Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(4), config.Name, Array.Empty<object>());
				return;
			}
		}

		// Token: 0x06039681 RID: 235137 RVA: 0x00E934C0 File Offset: 0x00E916C0
		private void RefreshProgress(bool isCompleted, SheriffAnomaly config)
		{
			bool flag = ModelBase<WorldMapModel>.Instance.MapScale * 100f > (float)config.TextVisibleScale;
			if (this.CurrentState == ESheriffAnomalyState.UnActivated || isCompleted || !flag)
			{
				UUIText text = base.GetText(5);
				if (text == null)
				{
					return;
				}
				text.SetUIActive(false);
				return;
			}
			else
			{
				if (this.CurrentState == ESheriffAnomalyState.UnOpened)
				{
					Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(5), "FunctionMap_Content_14", Array.Empty<object>());
					return;
				}
				UUIText text2 = base.GetText(5);
				if (text2 != null)
				{
					text2.SetUIActive(true);
				}
				UUIText text3 = base.GetText(5);
				if (text3 == null)
				{
					return;
				}
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.CurrentProgress);
				defaultInterpolatedStringHandler.AppendLiteral("%");
				text3.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				return;
			}
		}

		// Token: 0x06039682 RID: 235138 RVA: 0x00E93580 File Offset: 0x00E91780
		private void RefreshBg(bool isCompleted)
		{
			string resourceId = isCompleted ? "SP_SkyEyeMapDone" : "SP_SkyEyeMapUndone";
			base.TrySetSpriteByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId), base.GetSprite(6), false, null, null);
		}

		// Token: 0x06039683 RID: 235139 RVA: 0x00E935C0 File Offset: 0x00E917C0
		[NullableContext(2)]
		private string GetMarkIcon(SheriffAnomaly anomaly)
		{
			SheriffCriminalInfo criminalInfo = ModelBase<SheriffModel>.Instance.GetCriminalInfo(anomaly.CriminalId);
			if (criminalInfo == null)
			{
				return null;
			}
			SheriffIdentity? identityConfigById = ConfigBase<SheriffConfig>.Instance.GetIdentityConfigById(criminalInfo.Identity);
			if (identityConfigById == null)
			{
				return null;
			}
			return identityConfigById.GetValueOrDefault().MarkIcon;
		}

		// Token: 0x06039684 RID: 235140 RVA: 0x00E9360F File Offset: 0x00E9180F
		protected override void OnBeforeDestroyImplement()
		{
			UiSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.Clear();
		}

		// Token: 0x04020A3A RID: 133690
		[Nullable(2)]
		private UiSequencePlayer LevelSequencePlayer;

		// Token: 0x04020A3B RID: 133691
		private int MarkId;

		// Token: 0x04020A3C RID: 133692
		private ESheriffAnomalyState CurrentState;

		// Token: 0x04020A3D RID: 133693
		private int CurrentProgress;

		// Token: 0x0200B8A9 RID: 47273
		private static class EComponent
		{
			// Token: 0x0403917B RID: 233851
			public const int Item = 0;

			// Token: 0x0403917C RID: 233852
			public const int SprCriminal = 1;

			// Token: 0x0403917D RID: 233853
			public const int PnlDone = 2;

			// Token: 0x0403917E RID: 233854
			public const int PnlLock = 3;

			// Token: 0x0403917F RID: 233855
			public const int TextName = 4;

			// Token: 0x04039180 RID: 233856
			public const int TextProgress = 5;

			// Token: 0x04039181 RID: 233857
			public const int SprBg = 6;

			// Token: 0x04039182 RID: 233858
			public const int TextUnknown = 7;
		}
	}
}
