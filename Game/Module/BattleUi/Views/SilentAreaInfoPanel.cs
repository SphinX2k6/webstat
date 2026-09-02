using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060A3 RID: 24739
	[NullableContext(2)]
	[Nullable(0)]
	public class SilentAreaInfoPanel : BattleChildView
	{
		// Token: 0x0603E74D RID: 255821 RVA: 0x00FF667C File Offset: 0x00FF487C
		protected override UniTask InitializeAsync(object param = null)
		{
			SilentAreaInfoPanel.<InitializeAsync>d__6 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<SilentAreaInfoPanel.<InitializeAsync>d__6>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E74E RID: 255822 RVA: 0x00FF66C0 File Offset: 0x00FF48C0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E74F RID: 255823 RVA: 0x00FF672C File Offset: 0x00FF492C
		protected override void OnStart()
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetAnchorOffsetX(0f);
			}
			UUIItem rootItem2 = this.RootItem;
			if (rootItem2 != null)
			{
				rootItem2.SetAnchorOffsetY(0f);
			}
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(delegate(string sequenceName)
			{
				if (sequenceName == "Close")
				{
					this.SetActive(false);
				}
			}, false);
		}

		// Token: 0x0603E750 RID: 255824 RVA: 0x00FF6790 File Offset: 0x00FF4990
		[NullableContext(1)]
		public void CreateAndShow(string resourceId, UUIItem parent, [Nullable(2)] SilentAreaShowInfo silentAreaInfo)
		{
			if (this.Created)
			{
				this.UpdateInfo(silentAreaInfo);
				this.SetActive(true);
				this.StartCountdown();
				return;
			}
			base.NewByResourceId(parent, resourceId, false, null).ContinueWith(delegate()
			{
				this.Created = true;
				this.UpdateInfo(silentAreaInfo);
				this.StartCountdown();
			}).Forget();
		}

		// Token: 0x0603E751 RID: 255825 RVA: 0x00FF67F4 File Offset: 0x00FF49F4
		protected override void OnShowBattleChildView()
		{
			this.LevelSequencePlayer.StopCurrentSequence(false, false);
			this.LevelSequencePlayer.PlaySequencePurely("Start", false, false, null, null, false);
		}

		// Token: 0x0603E752 RID: 255826 RVA: 0x00FF682B File Offset: 0x00FF4A2B
		public void UpdateInfo(SilentAreaShowInfo silentAreaInfo)
		{
			this.SilentAreaInfo = silentAreaInfo;
			if (!this.Created)
			{
				return;
			}
			this.UpdateItems();
		}

		// Token: 0x0603E753 RID: 255827 RVA: 0x00FF6844 File Offset: 0x00FF4A44
		[NullableContext(1)]
		private unsafe List<ILevelPlayInformation> GetInfoInformationConfig()
		{
			if (this.SilentAreaInfo == null)
			{
				return new List<ILevelPlayInformation>();
			}
			if (this.SilentAreaInfo.ShowInfo.Type == EInformationViewType.LevelPlay)
			{
				return ((ILevelPlayInformationView)this.SilentAreaInfo.ShowInfo).InformationConfig;
			}
			if (this.SilentAreaInfo.ShowInfo.Type != EInformationViewType.BossRushBuffInfo)
			{
				return new List<ILevelPlayInformation>();
			}
			int instanceId = ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId;
			int bossRushSelectedBuffId = ControllerBase<BossRushController>.Instance.GetBossRushSelectedBuffId(instanceId);
			BossRushBuff? bossRushBuffConfigById = ConfigBase<BossRushConfig>.Instance.GetBossRushBuffConfigById(bossRushSelectedBuffId);
			if (bossRushBuffConfigById == null)
			{
				return new List<ILevelPlayInformation>();
			}
			IInformationSubTitle informationSubTitle = new IInformationSubTitle
			{
				TidTitle = bossRushBuffConfigById.Value.BuffTitle,
				TidContent = bossRushBuffConfigById.Value.BuffDesc
			};
			ILevelPlayInformation levelPlayInformation = new ILevelPlayInformation();
			levelPlayInformation.TidMainTitle = "BossRushBuffDesc";
			int num = 1;
			List<IInformationSubTitle> list = new List<IInformationSubTitle>(num);
			CollectionsMarshal.SetCount<IInformationSubTitle>(list, num);
			Span<IInformationSubTitle> span = CollectionsMarshal.AsSpan<IInformationSubTitle>(list);
			int num2 = 0;
			*span[num2] = informationSubTitle;
			levelPlayInformation.SubTitles = list;
			ILevelPlayInformation levelPlayInformation2 = levelPlayInformation;
			num2 = 1;
			List<ILevelPlayInformation> list2 = new List<ILevelPlayInformation>(num2);
			CollectionsMarshal.SetCount<ILevelPlayInformation>(list2, num2);
			Span<ILevelPlayInformation> span2 = CollectionsMarshal.AsSpan<ILevelPlayInformation>(list2);
			num = 0;
			*span2[num] = levelPlayInformation2;
			return list2;
		}

		// Token: 0x0603E754 RID: 255828 RVA: 0x00FF6974 File Offset: 0x00FF4B74
		private void UpdateItems()
		{
			if (this.SilentAreaInfo == null)
			{
				return;
			}
			List<ILevelPlayInformation> infoInformationConfig = this.GetInfoInformationConfig();
			for (int i = 0; i < infoInformationConfig.Count; i++)
			{
				ILevelPlayInformation config = infoInformationConfig[i];
				if (i < this.Items.Count)
				{
					SilentAreaInfoItem silentAreaInfoItem = this.Items[i];
					silentAreaInfoItem.SetCurrentShowType(this.SilentAreaInfo.ShowInfo.Type);
					silentAreaInfoItem.UpdateItem(config);
				}
				else
				{
					UUIItem uuiitem = Singleton<LguiUtil>.Instance.CopyItem(base.GetItem(1), base.GetItem(0));
					SilentAreaInfoItem silentAreaInfoItem = new SilentAreaInfoItem();
					silentAreaInfoItem.SetCurrentShowType(this.SilentAreaInfo.ShowInfo.Type);
					silentAreaInfoItem.Initialize(uuiitem.GetOwner(), config);
					this.Items.Add(silentAreaInfoItem);
				}
			}
			for (int j = 0; j < this.Items.Count; j++)
			{
				this.Items[j].SetActive(j < infoInformationConfig.Count);
			}
		}

		// Token: 0x0603E755 RID: 255829 RVA: 0x00FF6A70 File Offset: 0x00FF4C70
		private void StartCountdown()
		{
			this.TimerHandle = TimerSystem.Instance.Delay(new TTimerAction(this.OnTimerEnd), 8000f, null, null, true, 1f);
		}

		// Token: 0x0603E756 RID: 255830 RVA: 0x00FF6A9C File Offset: 0x00FF4C9C
		public void EndShow()
		{
			if (this.TimerHandle != null)
			{
				TimerSystem.Instance.Remove(this.TimerHandle);
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 == null)
			{
				return;
			}
			levelSequencePlayer2.PlayLevelSequenceByName("Close", false, null, false);
		}

		// Token: 0x0603E757 RID: 255831 RVA: 0x00FF6AF5 File Offset: 0x00FF4CF5
		private void OnTimerEnd(float _)
		{
			this.EndShow();
			Singleton<EventSystem>.Instance.Emit(EEventName.BattleUiToggleSilentAreaInfoView);
		}

		// Token: 0x04023033 RID: 143411
		private bool Created;

		// Token: 0x04023034 RID: 143412
		private SilentAreaShowInfo SilentAreaInfo;

		// Token: 0x04023035 RID: 143413
		private TimerHandle TimerHandle;

		// Token: 0x04023036 RID: 143414
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04023037 RID: 143415
		[Nullable(1)]
		private readonly List<SilentAreaInfoItem> Items = new List<SilentAreaInfoItem>();

		// Token: 0x0200C1B3 RID: 49587
		[NullableContext(0)]
		private enum EChildComponent
		{
			// Token: 0x0403BA3D RID: 244285
			ItemsRoot,
			// Token: 0x0403BA3E RID: 244286
			InfoItem
		}
	}
}
