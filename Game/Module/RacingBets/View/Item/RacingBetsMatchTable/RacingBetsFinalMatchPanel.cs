using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RacingBets.Data;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RacingBets.View.Item.RacingBetsMatchTable
{
	// Token: 0x0200529D RID: 21149
	public class RacingBetsFinalMatchPanel : UiPanelBase
	{
		// Token: 0x06036159 RID: 221529 RVA: 0x00D9DD84 File Offset: 0x00D9BF84
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUITexture)),
				new ValueTuple<int, Type>(11, typeof(UUISprite)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(14, typeof(UUIText)),
				new ValueTuple<int, Type>(15, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(13, new Action(this.OnReplayClick))
			};
		}

		// Token: 0x0603615A RID: 221530 RVA: 0x00D9DF11 File Offset: 0x00D9C111
		protected override void OnBeforeCreate()
		{
			this.UiLevelSequence = new UiBehaviorLevelSequence(this);
			base.AddUiBehavior(this.UiLevelSequence);
		}

		// Token: 0x0603615B RID: 221531 RVA: 0x00D9DF2C File Offset: 0x00D9C12C
		protected override UniTask OnBeforeStartAsync()
		{
			RacingBetsFinalMatchPanel.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RacingBetsFinalMatchPanel.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603615C RID: 221532 RVA: 0x00D9DF70 File Offset: 0x00D9C170
		protected override void OnBeforeShow()
		{
			RacingBetsLegMatchData racingBetsLegMatchData = this.MatchData.GetLegMatchList()[0];
			UUIButtonComponent button = base.GetButton(13);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(racingBetsLegMatchData.IsLegMatchFinished());
			}
			UUIText text = base.GetText(14);
			if (text != null)
			{
				text.SetText(Singleton<TimeUtil>.Instance.DateFormat6String(racingBetsLegMatchData.MatchStartTime), true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(15), racingBetsLegMatchData.Name, Array.Empty<object>());
			RacingBetsLegMatchData curLegMatchData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData().GetCurLegMatchData();
			if (curLegMatchData != null)
			{
				UUIItem item = base.GetItem(12);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(curLegMatchData.Id == racingBetsLegMatchData.Id);
			}
		}

		// Token: 0x0603615D RID: 221533 RVA: 0x00D9E02C File Offset: 0x00D9C22C
		private void OnReplayClick()
		{
			RacingBetsSeasonData racingBetsSeasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
			RacingBetsLegMatchData racingBetsLegMatchData = this.MatchData.GetLegMatchList()[0];
			ControllerBase<RacingBetsController>.Instance.RacingBetMatchActionRequest(racingBetsSeasonData.Id, racingBetsLegMatchData.Id);
		}

		// Token: 0x0603615E RID: 221534 RVA: 0x00D9E06C File Offset: 0x00D9C26C
		public void PlayAnim()
		{
			UiBehaviorLevelSequence uiLevelSequence = this.UiLevelSequence;
			if (uiLevelSequence != null)
			{
				uiLevelSequence.PlaySequence("Start", false, null);
			}
			GenericLayout<RacingBetsMatchTableDangoItem, IRacingBetsMatchTableDangoItemData> dangoLayout = this.DangoLayout;
			if (dangoLayout == null)
			{
				return;
			}
			dangoLayout.PlayGridAnim();
		}

		// Token: 0x0401F12B RID: 127275
		[Nullable(1)]
		private RacingBetsGroupMatchData MatchData;

		// Token: 0x0401F12C RID: 127276
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RacingBetsMatchTableDangoItem, IRacingBetsMatchTableDangoItemData> DangoLayout;

		// Token: 0x0401F12D RID: 127277
		[Nullable(2)]
		public UiBehaviorLevelSequence UiLevelSequence;

		// Token: 0x0200B20B RID: 45579
		private class EComponent
		{
			// Token: 0x0403730F RID: 226063
			public const int ItemLine1 = 0;

			// Token: 0x04037310 RID: 226064
			public const int ItemLine2 = 1;

			// Token: 0x04037311 RID: 226065
			public const int ItemLine3 = 2;

			// Token: 0x04037312 RID: 226066
			public const int ItemLine4 = 3;

			// Token: 0x04037313 RID: 226067
			public const int ItemLine5 = 4;

			// Token: 0x04037314 RID: 226068
			public const int ItemLine6 = 5;

			// Token: 0x04037315 RID: 226069
			public const int ItemLineMid = 6;

			// Token: 0x04037316 RID: 226070
			public const int LayoutDango = 7;

			// Token: 0x04037317 RID: 226071
			public const int ItemDango = 8;

			// Token: 0x04037318 RID: 226072
			public const int ItemWinnerPanel = 9;

			// Token: 0x04037319 RID: 226073
			public const int TextureIcon = 10;

			// Token: 0x0403731A RID: 226074
			public const int SpriteEmpty = 11;

			// Token: 0x0403731B RID: 226075
			public const int ItemRacing = 12;

			// Token: 0x0403731C RID: 226076
			public const int BtnReplay = 13;

			// Token: 0x0403731D RID: 226077
			public const int TextDate = 14;

			// Token: 0x0403731E RID: 226078
			public const int TextLegMatchName = 15;
		}
	}
}
