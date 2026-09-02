using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor
{
	// Token: 0x0200665B RID: 26203
	[NullableContext(1)]
	[Nullable(0)]
	public class MultiMotorMainView : UiTickViewBase
	{
		// Token: 0x060416DB RID: 267995 RVA: 0x010CA217 File Offset: 0x010C8417
		public MultiMotorMainView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x060416DC RID: 267996 RVA: 0x010CA238 File Offset: 0x010C8438
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060416DD RID: 267997 RVA: 0x010CA3AC File Offset: 0x010C85AC
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.MultiMotorRankInfoRefresh, new Action(this.OnMultiMotorLevelRankBattleUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.MultiMotorStart, new Action(this.ShowAfterMatchStart));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.MultiMotorPassLine, new Action<int>(this.OnMultiMotorPassLine));
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.MultiMotorBuffRefresh, new Action<int, int>(this.OnMultiMotorBuffRefresh));
		}

		// Token: 0x060416DE RID: 267998 RVA: 0x010CA42C File Offset: 0x010C862C
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.MultiMotorRankInfoRefresh, new Action(this.OnMultiMotorLevelRankBattleUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.MultiMotorStart, new Action(this.ShowAfterMatchStart));
			Singleton<EventSystem>.Instance.Remove(EEventName.MultiMotorPassLine, new Action<int>(this.OnMultiMotorPassLine));
			Singleton<EventSystem>.Instance.Remove(EEventName.MultiMotorBuffRefresh, new Action<int, int>(this.OnMultiMotorBuffRefresh));
		}

		// Token: 0x060416DF RID: 267999 RVA: 0x010CA4AC File Offset: 0x010C86AC
		protected override UniTask OnBeforeStartAsync()
		{
			MultiMotorMainView.<OnBeforeStartAsync>d__18 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MultiMotorMainView.<OnBeforeStartAsync>d__18>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060416E0 RID: 268000 RVA: 0x010CA4EF File Offset: 0x010C86EF
		protected override void OnBeforeDestroy()
		{
			this.ClearBroadcastTimer();
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.DriveMotorcycle, new <>z__ReadOnlyArray<EBattleUiChild>(new EBattleUiChild[]
			{
				EBattleUiChild.Mission,
				EBattleUiChild.MiniMap,
				EBattleUiChild.Formation,
				EBattleUiChild.GamepadFormation,
				EBattleUiChild.TopButton,
				EBattleUiChild.HomeButton,
				EBattleUiChild.RoleState
			}), true, true, 0);
		}

		// Token: 0x060416E1 RID: 268001 RVA: 0x010CA524 File Offset: 0x010C8724
		private UniTask InitMoveCurve()
		{
			MultiMotorMainView.<InitMoveCurve>d__20 <InitMoveCurve>d__;
			<InitMoveCurve>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitMoveCurve>d__.<>4__this = this;
			<InitMoveCurve>d__.<>1__state = -1;
			<InitMoveCurve>d__.<>t__builder.Start<MultiMotorMainView.<InitMoveCurve>d__20>(ref <InitMoveCurve>d__);
			return <InitMoveCurve>d__.<>t__builder.Task;
		}

		// Token: 0x060416E2 RID: 268002 RVA: 0x010CA568 File Offset: 0x010C8768
		private UniTask InitLayout()
		{
			MultiMotorMainView.<InitLayout>d__21 <InitLayout>d__;
			<InitLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitLayout>d__.<>4__this = this;
			<InitLayout>d__.<>1__state = -1;
			<InitLayout>d__.<>t__builder.Start<MultiMotorMainView.<InitLayout>d__21>(ref <InitLayout>d__);
			return <InitLayout>d__.<>t__builder.Task;
		}

		// Token: 0x060416E3 RID: 268003 RVA: 0x010CA5AB File Offset: 0x010C87AB
		private void InitGridItemHeight()
		{
			this.GridItemHeight = (int)base.GetItem(4).Height;
		}

		// Token: 0x060416E4 RID: 268004 RVA: 0x010CA5C0 File Offset: 0x010C87C0
		private UniTask CreateRankItem(int playerId, int index)
		{
			MultiMotorMainView.<CreateRankItem>d__23 <CreateRankItem>d__;
			<CreateRankItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateRankItem>d__.<>4__this = this;
			<CreateRankItem>d__.playerId = playerId;
			<CreateRankItem>d__.index = index;
			<CreateRankItem>d__.<>1__state = -1;
			<CreateRankItem>d__.<>t__builder.Start<MultiMotorMainView.<CreateRankItem>d__23>(ref <CreateRankItem>d__);
			return <CreateRankItem>d__.<>t__builder.Task;
		}

		// Token: 0x060416E5 RID: 268005 RVA: 0x010CA614 File Offset: 0x010C8814
		private UUIItem CreateItemActor()
		{
			UUIItem item = base.GetItem(4);
			return Singleton<LguiUtil>.Instance.CopyItem(item, base.GetItem(3));
		}

		// Token: 0x060416E6 RID: 268006 RVA: 0x010CA63B File Offset: 0x010C883B
		protected override void OnStart()
		{
			base.GetItem(5).SetUIActive(false);
			base.GetItem(4).SetUIActive(false);
			this.ShowBeforeMatchStart();
			ModelBase<MoonTogetherModel>.Instance.IsInMoonTogether = true;
		}

		// Token: 0x060416E7 RID: 268007 RVA: 0x010CA668 File Offset: 0x010C8868
		protected override void OnBeforeShow()
		{
			MultiMotorController instance = ControllerBase<MultiMotorController>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.OnMultiMotorMainViewOpened();
		}

		// Token: 0x060416E8 RID: 268008 RVA: 0x010CA67C File Offset: 0x010C887C
		private void ShowBeforeMatchStart()
		{
			Singleton<Log>.Instance.Info(ELogModule.MotorParkour, ELogAuthor.LJQ, "ShowBeforeMatchStart", default(ReadOnlySpan<ValueTuple<string, object>>));
			base.GetItem(9).SetUIActive(false);
			base.GetItem(8).SetUIActive(false);
		}

		// Token: 0x060416E9 RID: 268009 RVA: 0x010CA6C4 File Offset: 0x010C88C4
		private void ShowAfterMatchStart()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MotorParkour;
			ELogAuthor author = ELogAuthor.LJQ;
			string message = "ShowAfterMatchStart";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("StartFlowTime", ModelBase<MultiMotorModel>.Instance.StartFlowTime);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.GetItem(9).SetUIActive(true);
			base.GetItem(8).SetUIActive(true);
			this.ShowBroadcast(1);
			this.StartFlowTime = ModelBase<MultiMotorModel>.Instance.StartFlowTime;
		}

		// Token: 0x060416EA RID: 268010 RVA: 0x010CA73C File Offset: 0x010C893C
		private void OnMultiMotorPassLine(int playerId)
		{
			Dictionary<int, int> levelRankBattleMap = ModelBase<MultiMotorModel>.Instance.GetLevelRankBattleMap();
			int num;
			int key = (levelRankBattleMap != null && levelRankBattleMap.TryGetValue(playerId, out num)) ? num : 0;
			EMultiMotorBroadcastGroup emultiMotorBroadcastGroup;
			int broadcastGroup = (int)(MultiMotorDefine.MultiMotorRankToBroadcastGroup.TryGetValue(key, out emultiMotorBroadcastGroup) ? emultiMotorBroadcastGroup : EMultiMotorBroadcastGroup.MatchPassLine);
			this.ShowBroadcast(broadcastGroup);
		}

		// Token: 0x060416EB RID: 268011 RVA: 0x010CA784 File Offset: 0x010C8984
		private void OnMultiMotorBuffRefresh(int playerId, int buffId)
		{
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			if (!(playerId == id.GetValueOrDefault() & id != null))
			{
				return;
			}
			MotorOnlineBuff? motorBuffById = ConfigBase<MultiMotorConfig>.Instance.GetMotorBuffById(buffId);
			if (motorBuffById == null || motorBuffById.Value.BroadcastGroup == 0)
			{
				return;
			}
			this.ShowBroadcast(motorBuffById.Value.BroadcastGroup);
		}

		// Token: 0x060416EC RID: 268012 RVA: 0x010CA7F0 File Offset: 0x010C89F0
		private void RefreshRankInfo()
		{
			Dictionary<int, int> levelRankBattleMap = ModelBase<MultiMotorModel>.Instance.GetLevelRankBattleMap();
			if (levelRankBattleMap == null)
			{
				return;
			}
			foreach (KeyValuePair<int, int> keyValuePair in levelRankBattleMap)
			{
				int playerId = keyValuePair.Key;
				int rankNumber = keyValuePair.Value;
				MultiMotorRankItem multiMotorRankItem;
				if (!this.RankItemMap.TryGetValue(playerId, out multiMotorRankItem) && !this.CreatingRankItemSet.Contains(playerId))
				{
					this.CreatingRankItemSet.Add(playerId);
					int index = this.RankItemMap.Count + this.CreatingRankItemSet.Count - 1;
					this.CreateRankItem(playerId, index).ContinueWith(delegate()
					{
						this.CreatingRankItemSet.Remove(playerId);
						MultiMotorRankItem multiMotorRankItem2;
						if (this.RankItemMap.TryGetValue(playerId, out multiMotorRankItem2))
						{
							multiMotorRankItem2.RefreshRankNumber(rankNumber);
							float offsetY2 = this.DefaultOffsetY - (float)((rankNumber - 1) * (this.GridItemHeight + 20));
							multiMotorRankItem2.RefreshOffsetY(offsetY2);
						}
					});
				}
				else
				{
					if (multiMotorRankItem != null)
					{
						multiMotorRankItem.RefreshRankNumber(rankNumber);
					}
					float offsetY = this.DefaultOffsetY - (float)((rankNumber - 1) * (this.GridItemHeight + 20));
					if (multiMotorRankItem != null)
					{
						multiMotorRankItem.RefreshOffsetY(offsetY);
					}
				}
			}
		}

		// Token: 0x060416ED RID: 268013 RVA: 0x010CA924 File Offset: 0x010C8B24
		private void OnMultiMotorLevelRankBattleUpdate()
		{
			this.RefreshRankInfo();
		}

		// Token: 0x060416EE RID: 268014 RVA: 0x010CA92C File Offset: 0x010C8B2C
		protected override void OnTick(float delta)
		{
			this.MapItem.UpdatePlayerPosition();
			this.RefreshTimeText();
			foreach (KeyValuePair<int, MultiMotorRankItem> keyValuePair in this.RankItemMap)
			{
				keyValuePair.Value.TickAccelerateCountdown(delta);
			}
		}

		// Token: 0x060416EF RID: 268015 RVA: 0x010CA998 File Offset: 0x010C8B98
		public void ShowBroadcast(int broadcastGroup)
		{
			IReadOnlyList<OnlineMotorBroadcast> motorBroadcastByGroup = ConfigBase<MultiMotorConfig>.Instance.GetMotorBroadcastByGroup(broadcastGroup);
			if (motorBroadcastByGroup == null || motorBroadcastByGroup.Count <= 0)
			{
				return;
			}
			OnlineMotorBroadcast onlineMotorBroadcast = motorBroadcastByGroup[(int)Singleton<MathUtils>.Instance.GetRandomRange(0.0, (double)(motorBroadcastByGroup.Count - 1))];
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), onlineMotorBroadcast.Speaker, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), onlineMotorBroadcast.Content, Array.Empty<object>());
			base.GetItem(5).SetUIActive(true);
			this.BroadcastSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
			this.ClearBroadcastTimer();
			this.BroadcastTimerHandle = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.BroadcastTimerHandle = null;
				this.BroadcastSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
			}, 5000f, null, null, true, 1f);
		}

		// Token: 0x060416F0 RID: 268016 RVA: 0x010CAA73 File Offset: 0x010C8C73
		private void OnBroadcastSequenceClose(string sequenceName)
		{
			if (sequenceName == "Close")
			{
				base.GetItem(5).SetUIActive(false);
			}
		}

		// Token: 0x060416F1 RID: 268017 RVA: 0x010CAA8F File Offset: 0x010C8C8F
		private void ClearBroadcastTimer()
		{
			if (this.BroadcastTimerHandle != null)
			{
				this.BroadcastTimerHandle.Remove();
				this.BroadcastTimerHandle = null;
			}
		}

		// Token: 0x060416F2 RID: 268018 RVA: 0x010CAAAC File Offset: 0x010C8CAC
		private void RefreshTimeText()
		{
			if (this.StartFlowTime == 0L)
			{
				return;
			}
			double num = (Singleton<TimeUtil>.Instance.GetServerTimeStamp() - (double)this.StartFlowTime) * Singleton<TimeUtil>.Instance.Millisecond;
			if (Singleton<Time>.Instance.FlowTimeDilation == 0f)
			{
				return;
			}
			long num2 = (long)Math.Floor(num % Singleton<TimeUtil>.Instance.Hour / Singleton<TimeUtil>.Instance.Minute);
			string value = ((num2 < 10L) ? "0" : "") + num2.ToString();
			long num3 = (long)Math.Floor(num % Singleton<TimeUtil>.Instance.Minute);
			string value2 = ((num3 < 10L) ? "0" : "") + num3.ToString();
			long num4 = (long)Math.Floor((num - Math.Floor(num)) * 100.0);
			string value3 = ((num4 < 10L) ? "0" : "") + num4.ToString();
			UUIText text = base.GetText(2);
			if (text == null)
			{
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral(":");
			defaultInterpolatedStringHandler.AppendFormatted(value2);
			defaultInterpolatedStringHandler.AppendLiteral(":");
			defaultInterpolatedStringHandler.AppendFormatted(value3);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x0402495B RID: 149851
		private const float TWEEN_DURATION = 0.3f;

		// Token: 0x0402495C RID: 149852
		private const int ITEM_HEIGHT_INTERVAL = 20;

		// Token: 0x0402495D RID: 149853
		private const int BROADCAST_TIME = 5000;

		// Token: 0x0402495E RID: 149854
		private MultiMotorLevelData LevelData;

		// Token: 0x0402495F RID: 149855
		private readonly Dictionary<int, MultiMotorRankItem> RankItemMap = new Dictionary<int, MultiMotorRankItem>();

		// Token: 0x04024960 RID: 149856
		private readonly HashSet<int> CreatingRankItemSet = new HashSet<int>();

		// Token: 0x04024961 RID: 149857
		protected UCurveFloat LerpCurve;

		// Token: 0x04024962 RID: 149858
		protected float DefaultOffsetY;

		// Token: 0x04024963 RID: 149859
		protected int GridItemHeight;

		// Token: 0x04024964 RID: 149860
		private MultiMotorParkourMapItem MapItem;

		// Token: 0x04024965 RID: 149861
		private long StartFlowTime;

		// Token: 0x04024966 RID: 149862
		private LevelSequencePlayer BroadcastSequencePlayer;

		// Token: 0x04024967 RID: 149863
		[Nullable(2)]
		private TimerHandle BroadcastTimerHandle;

		// Token: 0x0200C678 RID: 50808
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D1B4 RID: 250292
			public const int TopMapItem = 0;

			// Token: 0x0403D1B5 RID: 250293
			public const int LapCountText = 1;

			// Token: 0x0403D1B6 RID: 250294
			public const int TimeText = 2;

			// Token: 0x0403D1B7 RID: 250295
			public const int ContentItem = 3;

			// Token: 0x0403D1B8 RID: 250296
			public const int RankTempItem = 4;

			// Token: 0x0403D1B9 RID: 250297
			public const int BroadcastItem = 5;

			// Token: 0x0403D1BA RID: 250298
			public const int BroadcastTitleText = 6;

			// Token: 0x0403D1BB RID: 250299
			public const int BroadcastDesText = 7;

			// Token: 0x0403D1BC RID: 250300
			public const int MissionItem = 8;

			// Token: 0x0403D1BD RID: 250301
			public const int TimeItem = 9;
		}
	}
}
