using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020011B1 RID: 4529
public class ArtemisSubView : ActivitySubViewBase
{
	// Token: 0x06007743 RID: 30531 RVA: 0x001F3480 File Offset: 0x001F1680
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIArtText)),
			new ValueTuple<int, Type>(1, typeof(UUIArtText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem))
		};
	}

	// Token: 0x06007744 RID: 30532 RVA: 0x001F35A4 File Offset: 0x001F17A4
	protected override UniTask OnBeforeStartAsync()
	{
		ArtemisSubView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ArtemisSubView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007745 RID: 30533 RVA: 0x001F35E7 File Offset: 0x001F17E7
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnArtemisStateRefresh, new Action(this.RefreshAircraftStatus));
	}

	// Token: 0x06007746 RID: 30534 RVA: 0x001F3605 File Offset: 0x001F1805
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnArtemisStateRefresh, new Action(this.RefreshAircraftStatus));
	}

	// Token: 0x06007747 RID: 30535 RVA: 0x001F3623 File Offset: 0x001F1823
	protected override void OnBeforeShow()
	{
		this.RefreshAircraftStatus();
	}

	// Token: 0x06007748 RID: 30536 RVA: 0x001F362B File Offset: 0x001F182B
	protected override void OnBeforeDestroy()
	{
		AUIBaseActor rootActor = this.RootActor;
		if (rootActor == null)
		{
			return;
		}
		rootActor.OnSequencePlayEvent.Unbind();
	}

	// Token: 0x06007749 RID: 30537 RVA: 0x001F3644 File Offset: 0x001F1844
	[NullableContext(1)]
	private void OnPlaySequenceEvent(string sequenceName, string eventName)
	{
		if (eventName == "Loop_Stop")
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopSequenceByKey("Loop", false, false);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 != null)
			{
				levelSequencePlayer2.StopSequenceByKey("Loop_Last", false, false);
			}
			UUIItem item = base.GetItem(11);
			if (item != null)
			{
				item.SetUIActive(!this.FullPlaneVisible);
			}
			UUITexture texture = base.GetTexture(3);
			if (texture != null)
			{
				texture.SetUIActive(this.FullPlaneVisible);
			}
		}
		if (eventName == "Loop_Play")
		{
			LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
			if (levelSequencePlayer3 != null)
			{
				levelSequencePlayer3.PlaySequencePurely(this.FullPlaneVisible ? "Loop_Last" : "Loop", false, false, null, null, false);
			}
		}
		if (eventName == "Day_Start")
		{
			ArtemisActivityData artemisActivityData = this.ActivityBaseData as ArtemisActivityData;
			if (artemisActivityData != null && artemisActivityData.GetRewardedIndex > 0 && !this.AlreadyPlayedPlaneAnim(artemisActivityData.GetRewardedIndex))
			{
				LevelSequencePlayer levelSequencePlayer4 = this.LevelSequencePlayer;
				if (levelSequencePlayer4 != null)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Day");
					defaultInterpolatedStringHandler.AppendFormatted<int>(artemisActivityData.GetRewardedIndex);
					levelSequencePlayer4.PlaySequencePurely(defaultInterpolatedStringHandler.ToStringAndClear(), false, false, null, null, false);
				}
				this.SetPlayedPlaneAnim(artemisActivityData.GetRewardedIndex);
			}
		}
	}

	// Token: 0x0600774A RID: 30538 RVA: 0x001F3788 File Offset: 0x001F1988
	private void ClickCommonInfo()
	{
		ArtemisActivityData artemisActivityData = this.ActivityBaseData as ArtemisActivityData;
		int artemisDefaultOpenIndex = artemisActivityData.GetArtemisDefaultOpenIndex();
		ArtemisActivityRoleChatViewParams param = new ArtemisActivityRoleChatViewParams
		{
			Data = artemisActivityData,
			DefaultIndex = artemisDefaultOpenIndex
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ArtemisActivityRoleChatView, param, null);
	}

	// Token: 0x0600774B RID: 30539 RVA: 0x001F37D0 File Offset: 0x001F19D0
	private void RefreshAircraftStatus()
	{
		ArtemisActivityData artemisActivityData = this.ActivityBaseData as ArtemisActivityData;
		if (artemisActivityData != null)
		{
			IReadOnlyList<Artemis> artemisGroupByActivityId = ConfigBase<ArtemisActivityConfig>.Instance.GetArtemisGroupByActivityId(artemisActivityData.GetCacheActivityId);
			this.MaxDay = ((artemisGroupByActivityId != null) ? artemisGroupByActivityId.Count : 0);
			this.FullPlaneVisible = (artemisActivityData.GetRewardedIndex >= this.MaxDay);
			this.SetPlaneVisibleVisible(artemisActivityData.GetRewardedIndex);
			UUIArtText artText = base.GetArtText(0);
			if (artText != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("0");
				defaultInterpolatedStringHandler.AppendFormatted<int>(artemisActivityData.GetRewardedIndex);
				artText.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			UUIArtText artText2 = base.GetArtText(1);
			if (artText2 != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("0");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.MaxDay);
				artText2.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			bool canReceive = artemisActivityData.GetCanReceive();
			ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
			if (commonInfoPanel != null)
			{
				commonInfoPanel.SetBtnText("FarmGoldEnterText", Array.Empty<object>());
			}
			ActivitySubViewGeneralInfo commonInfoPanel2 = this.CommonInfoPanel;
			if (commonInfoPanel2 == null)
			{
				return;
			}
			commonInfoPanel2.SetFunctionRedDotVisible(canReceive);
		}
	}

	// Token: 0x0600774C RID: 30540 RVA: 0x001F38E0 File Offset: 0x001F1AE0
	private void SetPlaneVisibleVisible(int targetIndex)
	{
		int num = this.AlreadyPlayedPlaneAnim(targetIndex) ? targetIndex : (targetIndex - 1);
		for (int i = 0; i < this.MaxDay; i++)
		{
			bool flag = num > i;
			UUIItem item = base.GetItem(4 + i);
			if (item != null)
			{
				item.SetAlpha(flag > false);
			}
		}
	}

	// Token: 0x0600774D RID: 30541 RVA: 0x001F392C File Offset: 0x001F1B2C
	private bool AlreadyPlayedPlaneAnim(int index)
	{
		ArtemisActivityData artemisActivityData = this.ActivityBaseData as ArtemisActivityData;
		if (artemisActivityData == null)
		{
			return false;
		}
		int getCacheActivityId = artemisActivityData.GetCacheActivityId;
		Dictionary<int, int> player = LocalStorage.GetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.FirstPlayArtemisPlaneAnimMap, null);
		int num;
		return player != null && player.TryGetValue(getCacheActivityId, out num) && num >= index;
	}

	// Token: 0x0600774E RID: 30542 RVA: 0x001F3974 File Offset: 0x001F1B74
	private void SetPlayedPlaneAnim(int index)
	{
		ArtemisActivityData artemisActivityData = this.ActivityBaseData as ArtemisActivityData;
		if (artemisActivityData == null)
		{
			return;
		}
		int getCacheActivityId = artemisActivityData.GetCacheActivityId;
		Dictionary<int, int> dictionary = LocalStorage.GetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.FirstPlayArtemisPlaneAnimMap, null) ?? new Dictionary<int, int>();
		dictionary[getCacheActivityId] = index;
		LocalStorage.SetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.FirstPlayArtemisPlaneAnimMap, dictionary);
	}

	// Token: 0x0400399B RID: 14747
	[Nullable(2)]
	protected ActivitySubViewGeneralInfo CommonInfoPanel;

	// Token: 0x0400399C RID: 14748
	private bool FullPlaneVisible;

	// Token: 0x0400399D RID: 14749
	private int MaxDay;

	// Token: 0x0200750D RID: 29965
	private class EComponent
	{
		// Token: 0x04028695 RID: 165525
		public const int CurrentDayText = 0;

		// Token: 0x04028696 RID: 165526
		public const int TargetDayText = 1;

		// Token: 0x04028697 RID: 165527
		public const int ActivityInfoUiItem = 2;

		// Token: 0x04028698 RID: 165528
		public const int AircraftTexture = 3;

		// Token: 0x04028699 RID: 165529
		public const int AirPoint1Item = 4;

		// Token: 0x0402869A RID: 165530
		public const int AirPoint2Item = 5;

		// Token: 0x0402869B RID: 165531
		public const int AirPoint3Item = 6;

		// Token: 0x0402869C RID: 165532
		public const int AirPoint4Item = 7;

		// Token: 0x0402869D RID: 165533
		public const int AirPoint5Item = 8;

		// Token: 0x0402869E RID: 165534
		public const int AirPoint6Item = 9;

		// Token: 0x0402869F RID: 165535
		public const int AirPoint7Item = 10;

		// Token: 0x040286A0 RID: 165536
		public const int GitchItem = 11;
	}
}
