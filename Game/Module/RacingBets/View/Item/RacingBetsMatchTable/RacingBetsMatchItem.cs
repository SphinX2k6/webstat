using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RacingBets.Data;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RacingBets.View.Item.RacingBetsMatchTable
{
	// Token: 0x0200529F RID: 21151
	[NullableContext(1)]
	[Nullable(0)]
	public class RacingBetsMatchItem : RacingBetsMatchItemBase
	{
		// Token: 0x06036168 RID: 221544 RVA: 0x00D9E33C File Offset: 0x00D9C53C
		static RacingBetsMatchItem()
		{
			Dictionary<ERacingBetsMatchType, string> dictionary = new Dictionary<ERacingBetsMatchType, string>();
			dictionary[ERacingBetsMatchType.Normal] = "/Game/Aki/UI/UIResources/UiActivity/Image/ActivityRacehorse/T_MatchTableBgA.T_MatchTableBgA";
			dictionary[ERacingBetsMatchType.Failure] = "/Game/Aki/UI/UIResources/UiActivity/Image/ActivityRacehorse/T_MatchTableBgD.T_MatchTableBgD";
			dictionary[ERacingBetsMatchType.Farewell] = "/Game/Aki/UI/UIResources/UiActivity/Image/ActivityRacehorse/T_MatchTableBgC.T_MatchTableBgC";
			RacingBetsMatchItem.TypeToBgPath = dictionary;
			Dictionary<ERacingBetsMatchType, string> dictionary2 = new Dictionary<ERacingBetsMatchType, string>();
			dictionary2[ERacingBetsMatchType.Normal] = "/Game/Aki/UI/UIResources/UiActivity/Atlas/ActivityRacehorse/SP_StateIconA.SP_StateIconA";
			dictionary2[ERacingBetsMatchType.Failure] = "/Game/Aki/UI/UIResources/UiActivity/Atlas/ActivityRacehorse/SP_StateIconD.SP_StateIconD";
			dictionary2[ERacingBetsMatchType.Farewell] = "/Game/Aki/UI/UIResources/UiActivity/Atlas/ActivityRacehorse/SP_StateIconC.SP_StateIconC";
			RacingBetsMatchItem.TypeToEmojiPath = dictionary2;
		}

		// Token: 0x06036169 RID: 221545 RVA: 0x00D9E3A8 File Offset: 0x00D9C5A8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(8, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUIText)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(14, typeof(UUIText)),
				new ValueTuple<int, Type>(15, typeof(UUIText)),
				new ValueTuple<int, Type>(16, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(17, typeof(UUIText)),
				new ValueTuple<int, Type>(18, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(13, new Action(this.OnFirstHalfMatchReplayClick)),
				new ValueTuple<int, Delegate>(16, new Action(this.OnSecondHalfMatchReplayClick)),
				new ValueTuple<int, Delegate>(7, new Action(this.OnFirstHalfMatchReplayClick))
			};
		}

		// Token: 0x0603616A RID: 221546 RVA: 0x00D9E5AC File Offset: 0x00D9C7AC
		protected override UniTask OnBeforeStartAsync()
		{
			RacingBetsMatchItem.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RacingBetsMatchItem.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603616B RID: 221547 RVA: 0x00D9E5F0 File Offset: 0x00D9C7F0
		protected override void OnBeforeShow()
		{
			base.OnBeforeShow();
			string path;
			if (RacingBetsMatchItem.TypeToBgPath.TryGetValue(this.MatchType, out path))
			{
				base.SetTextureByPath(path, base.GetTexture(0), null, null);
			}
			string path2;
			if (RacingBetsMatchItem.TypeToEmojiPath.TryGetValue(this.MatchType, out path2))
			{
				this.SetSpriteByPath(path2, base.GetSprite(1), false, null, null);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), this.MatchData.Name, Array.Empty<object>());
			List<RacingBetsLegMatchData> legMatchList = this.MatchData.GetLegMatchList();
			RacingBetsLegMatchData racingBetsLegMatchData = legMatchList[0];
			RacingBetsLegMatchData racingBetsLegMatchData2 = (legMatchList.Count > 1) ? legMatchList[1] : null;
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(racingBetsLegMatchData2 == null);
			}
			UUIItem item2 = base.GetItem(10);
			if (item2 != null)
			{
				item2.SetUIActive(racingBetsLegMatchData2 != null);
			}
			UUIText text = base.GetText(9);
			if (text != null)
			{
				text.SetText(Singleton<TimeUtil>.Instance.DateFormat6String(racingBetsLegMatchData.MatchStartTime), true);
			}
			UUIText text2 = base.GetText(15);
			if (text2 != null)
			{
				text2.SetText(Singleton<TimeUtil>.Instance.DateFormat6String(racingBetsLegMatchData.MatchStartTime), true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), racingBetsLegMatchData.SimpleName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(14), racingBetsLegMatchData.SimpleName, Array.Empty<object>());
			if (racingBetsLegMatchData2 != null)
			{
				UUIText text3 = base.GetText(18);
				if (text3 != null)
				{
					text3.SetText(Singleton<TimeUtil>.Instance.DateFormat6String(racingBetsLegMatchData2.MatchStartTime), true);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(17), racingBetsLegMatchData2.SimpleName, Array.Empty<object>());
			}
			this.RefreshStatus();
		}

		// Token: 0x0603616C RID: 221548 RVA: 0x00D9E7A8 File Offset: 0x00D9C9A8
		public void RefreshStatus()
		{
			List<RacingBetsLegMatchData> legMatchList = this.MatchData.GetLegMatchList();
			RacingBetsLegMatchData racingBetsLegMatchData = legMatchList[0];
			RacingBetsLegMatchData racingBetsLegMatchData2 = (legMatchList.Count > 1) ? legMatchList[1] : null;
			RacingBetsLegMatchData curLegMatchData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData().GetCurLegMatchData();
			if (curLegMatchData != null)
			{
				UUIItem item = base.GetItem(6);
				if (item != null)
				{
					item.SetUIActive(curLegMatchData.Id == racingBetsLegMatchData.Id);
				}
				UUIItem item2 = base.GetItem(11);
				if (item2 != null)
				{
					item2.SetUIActive(curLegMatchData.Id == racingBetsLegMatchData.Id);
				}
				UUIItem item3 = base.GetItem(12);
				if (item3 != null)
				{
					item3.SetUIActive(racingBetsLegMatchData2 != null && curLegMatchData.Id == racingBetsLegMatchData2.Id);
				}
			}
			UUIButtonComponent button = base.GetButton(7);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(racingBetsLegMatchData.IsLegMatchFinished());
			}
			UUIButtonComponent button2 = base.GetButton(13);
			if (button2 != null)
			{
				button2.RootUIComp.Get().SetUIActive(racingBetsLegMatchData.IsLegMatchFinished());
			}
			UUIButtonComponent button3 = base.GetButton(16);
			if (button3 == null)
			{
				return;
			}
			button3.RootUIComp.Get().SetUIActive(racingBetsLegMatchData2 != null && racingBetsLegMatchData2.IsLegMatchFinished());
		}

		// Token: 0x0603616D RID: 221549 RVA: 0x00D9E8D1 File Offset: 0x00D9CAD1
		public void SetMatchId(int matchId)
		{
			this.GroupMatchId = matchId;
			this.MatchData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsGroupMatchData(this.GroupMatchId);
		}

		// Token: 0x0603616E RID: 221550 RVA: 0x00D9E8F0 File Offset: 0x00D9CAF0
		private void OnFirstHalfMatchReplayClick()
		{
			RacingBetsSeasonData racingBetsSeasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
			RacingBetsLegMatchData racingBetsLegMatchData = this.MatchData.GetLegMatchList()[0];
			ControllerBase<RacingBetsController>.Instance.RacingBetMatchActionRequest(racingBetsSeasonData.Id, racingBetsLegMatchData.Id);
		}

		// Token: 0x0603616F RID: 221551 RVA: 0x00D9E930 File Offset: 0x00D9CB30
		private void OnSecondHalfMatchReplayClick()
		{
			RacingBetsSeasonData racingBetsSeasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
			List<RacingBetsLegMatchData> legMatchList = this.MatchData.GetLegMatchList();
			if (legMatchList.Count > 1)
			{
				RacingBetsLegMatchData racingBetsLegMatchData = legMatchList[1];
				ControllerBase<RacingBetsController>.Instance.RacingBetMatchActionRequest(racingBetsSeasonData.Id, racingBetsLegMatchData.Id);
			}
		}

		// Token: 0x0401F132 RID: 127282
		private static readonly Dictionary<ERacingBetsMatchType, string> TypeToBgPath;

		// Token: 0x0401F133 RID: 127283
		private static readonly Dictionary<ERacingBetsMatchType, string> TypeToEmojiPath;

		// Token: 0x0401F134 RID: 127284
		public int GroupMatchId;

		// Token: 0x0401F135 RID: 127285
		public ERacingBetsMatchType MatchType;

		// Token: 0x0401F136 RID: 127286
		private RacingBetsGroupMatchData MatchData;

		// Token: 0x0200B213 RID: 45587
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403733E RID: 226110
			public const int TextureBg = 0;

			// Token: 0x0403733F RID: 226111
			public const int SpriteEmoji = 1;

			// Token: 0x04037340 RID: 226112
			public const int TextName = 2;

			// Token: 0x04037341 RID: 226113
			public const int LayoutDango = 3;

			// Token: 0x04037342 RID: 226114
			public const int ItemRole = 4;

			// Token: 0x04037343 RID: 226115
			public const int ItemOneLegMatchPanel = 5;

			// Token: 0x04037344 RID: 226116
			public const int ItemOneLegMatchRacing = 6;

			// Token: 0x04037345 RID: 226117
			public const int BtnOneLegMatchReplay = 7;

			// Token: 0x04037346 RID: 226118
			public const int TextLegMatchName = 8;

			// Token: 0x04037347 RID: 226119
			public const int TextDate = 9;

			// Token: 0x04037348 RID: 226120
			public const int ItemTwoLegMatchPanel = 10;

			// Token: 0x04037349 RID: 226121
			public const int ItemFirstHaltMatchRacing = 11;

			// Token: 0x0403734A RID: 226122
			public const int ItemSecondHaltMatchRacing = 12;

			// Token: 0x0403734B RID: 226123
			public const int BtnFirstHaltMatchReplay = 13;

			// Token: 0x0403734C RID: 226124
			public const int TextFirstHaltName = 14;

			// Token: 0x0403734D RID: 226125
			public const int TextFirstHaltDate = 15;

			// Token: 0x0403734E RID: 226126
			public const int BtnSecondHaltMatchReplay = 16;

			// Token: 0x0403734F RID: 226127
			public const int TextSecondHaltName = 17;

			// Token: 0x04037350 RID: 226128
			public const int TextSecondHaltDate = 18;
		}
	}
}
