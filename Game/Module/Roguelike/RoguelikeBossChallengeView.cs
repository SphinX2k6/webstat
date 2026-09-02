using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200514A RID: 20810
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeBossChallengeView : UiViewBase
	{
		// Token: 0x060358E9 RID: 219369 RVA: 0x00D71CBB File Offset: 0x00D6FEBB
		public RoguelikeBossChallengeView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060358EA RID: 219370 RVA: 0x00D71CDC File Offset: 0x00D6FEDC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060358EB RID: 219371 RVA: 0x00D71DCC File Offset: 0x00D6FFCC
		protected override UniTask OnBeforeStartAsync()
		{
			RoguelikeBossChallengeView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoguelikeBossChallengeView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060358EC RID: 219372 RVA: 0x00D71E10 File Offset: 0x00D70010
		protected override void OnStart()
		{
			this.BossSwitchPanel.SetOnBossChangedCallback(new Action<ERoguelikeBossChallengeSwitchDirection>(this.OnBossIndexChanged));
			this.TexBossActor = (base.GetTexture(0).GetOwner() as AUIBaseActor);
			this.TexBossActor.OnSequencePlayEvent.Bind(new Action<string, string>(this.OnBossSequenceEvent));
			this.InitBossData();
		}

		// Token: 0x060358ED RID: 219373 RVA: 0x00D71E6D File Offset: 0x00D7006D
		protected override void OnBeforeDestroy()
		{
			AUIBaseActor texBossActor = this.TexBossActor;
			if (texBossActor != null)
			{
				texBossActor.OnSequencePlayEvent.Unbind();
			}
			this.TexBossActor = null;
		}

		// Token: 0x060358EE RID: 219374 RVA: 0x00D71E8C File Offset: 0x00D7008C
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RoguelikeDataUpdate, new Action(this.OnDescModelChange));
		}

		// Token: 0x060358EF RID: 219375 RVA: 0x00D71EAA File Offset: 0x00D700AA
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RoguelikeDataUpdate, new Action(this.OnDescModelChange));
		}

		// Token: 0x060358F0 RID: 219376 RVA: 0x00D71EC8 File Offset: 0x00D700C8
		private void InitBossData()
		{
			List<RogueTowerTrialBossInfo> list = this.OpenParam as List<RogueTowerTrialBossInfo>;
			if (list == null || list.Count == 0)
			{
				return;
			}
			int instanceId = ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId;
			RoguelikeConfig instance = ConfigBase<RoguelikeConfig>.Instance;
			RogueInst? rogueInst = (instance != null) ? instance.GetRogueInstConfig(instanceId) : null;
			bool flag;
			if (rogueInst == null)
			{
				flag = false;
			}
			else
			{
				int specialBossIndex = rogueInst.GetValueOrDefault().SpecialBossIndex;
				flag = true;
			}
			int num = flag ? (rogueInst.Value.SpecialBossIndex - 1) : -1;
			List<RoguelikeBossChallengeBossData> list2 = new List<RoguelikeBossChallengeBossData>();
			for (int i = 0; i < list.Count; i++)
			{
				RogueTowerTrialBossInfo rogueTowerTrialBossInfo = list[i];
				list2.Add(new RoguelikeBossChallengeBossData
				{
					Id = rogueTowerTrialBossInfo.Id,
					State = RoguelikeBossChallengeDefine.ConvertProtoToBossState(rogueTowerTrialBossInfo.State),
					IsSpecial = (i == num)
				});
			}
			this.SortedBossDataList = RoguelikeBossChallengeDefine.SortBossDataListStable(list2);
			this.SelectableBossIds = new List<int>();
			foreach (RoguelikeBossChallengeBossData roguelikeBossChallengeBossData in this.SortedBossDataList)
			{
				if (roguelikeBossChallengeBossData.State == ERoguelikeBossChallengeBossState.Processing)
				{
					this.SelectableBossIds.Add(roguelikeBossChallengeBossData.Id);
				}
			}
			this.FinishedBossCount = 0;
			using (List<RoguelikeBossChallengeBossData>.Enumerator enumerator = this.SortedBossDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.State == ERoguelikeBossChallengeBossState.Finished)
					{
						this.FinishedBossCount++;
					}
				}
			}
			this.BossSwitchPanel.RefreshBossList(this.SelectableBossIds);
			this.RefreshBossListBySelectedBoss();
			this.RefreshCurrentBossDisplayNoAnim();
		}

		// Token: 0x060358F1 RID: 219377 RVA: 0x00D72098 File Offset: 0x00D70298
		private List<RoguelikeBossChallengeBossData> BuildDisplayBossDataList(int selectedBossId)
		{
			List<RoguelikeBossChallengeBossData> list = new List<RoguelikeBossChallengeBossData>();
			foreach (RoguelikeBossChallengeBossData roguelikeBossChallengeBossData in this.SortedBossDataList)
			{
				if (roguelikeBossChallengeBossData.State == ERoguelikeBossChallengeBossState.Finished)
				{
					list.Add(roguelikeBossChallengeBossData);
				}
			}
			foreach (RoguelikeBossChallengeBossData roguelikeBossChallengeBossData2 in this.SortedBossDataList)
			{
				if (roguelikeBossChallengeBossData2.State == ERoguelikeBossChallengeBossState.Processing && roguelikeBossChallengeBossData2.Id == selectedBossId)
				{
					list.Add(roguelikeBossChallengeBossData2);
					break;
				}
			}
			foreach (RoguelikeBossChallengeBossData roguelikeBossChallengeBossData3 in this.SortedBossDataList)
			{
				if (roguelikeBossChallengeBossData3.State != ERoguelikeBossChallengeBossState.Finished && (roguelikeBossChallengeBossData3.State != ERoguelikeBossChallengeBossState.Processing || roguelikeBossChallengeBossData3.Id != selectedBossId))
				{
					list.Add(new RoguelikeBossChallengeBossData
					{
						Id = roguelikeBossChallengeBossData3.Id,
						State = ERoguelikeBossChallengeBossState.Locked,
						IsSpecial = roguelikeBossChallengeBossData3.IsSpecial
					});
				}
			}
			return list;
		}

		// Token: 0x060358F2 RID: 219378 RVA: 0x00D721DC File Offset: 0x00D703DC
		private void RefreshBossListBySelectedBoss()
		{
			RoguelikeBossChallengeSwitchItem bossSwitchPanel = this.BossSwitchPanel;
			int num = (bossSwitchPanel != null) ? bossSwitchPanel.GetCurrentBossId() : 0;
			List<RoguelikeBossChallengeBossData> dataList = this.BuildDisplayBossDataList(num);
			this.BossListPanel.RefreshBossList(dataList, num);
		}

		// Token: 0x060358F3 RID: 219379 RVA: 0x00D72214 File Offset: 0x00D70414
		private void RefreshCurrentBossDisplayNoAnim()
		{
			RoguelikeBossChallengeSwitchItem bossSwitchPanel = this.BossSwitchPanel;
			int num = (bossSwitchPanel != null) ? bossSwitchPanel.GetCurrentBossId() : 0;
			if (num == 0)
			{
				return;
			}
			this.RefreshBossTexture(new int?(num));
			this.RefreshDebuffList(num);
		}

		// Token: 0x060358F4 RID: 219380 RVA: 0x00D7224C File Offset: 0x00D7044C
		private void RefreshCurrentBossDisplayWithAnim(ERoguelikeBossChallengeSwitchDirection direction)
		{
			RoguelikeBossChallengeSwitchItem bossSwitchPanel = this.BossSwitchPanel;
			int num = (bossSwitchPanel != null) ? bossSwitchPanel.GetCurrentBossId() : 0;
			if (num == 0)
			{
				return;
			}
			if (this.IsBossSwitchSequencePlaying())
			{
				this.StopCurrentBossSwitchSequence();
				this.RefreshBossTexture(this.PendingBossId);
			}
			this.PlayBossSwitchSequence(direction, num);
			this.RefreshDebuffList(num);
		}

		// Token: 0x060358F5 RID: 219381 RVA: 0x00D7229C File Offset: 0x00D7049C
		private void PlayBossSwitchSequence(ERoguelikeBossChallengeSwitchDirection direction, int bossId)
		{
			string bossSwitchSequenceName = this.GetBossSwitchSequenceName(direction);
			this.PendingBossId = new int?(bossId);
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PlayOrReplaySequenceByName(bossSwitchSequenceName, true, null);
		}

		// Token: 0x060358F6 RID: 219382 RVA: 0x00D722D8 File Offset: 0x00D704D8
		private void RefreshBossTexture(int? bossId)
		{
			if (bossId == null)
			{
				return;
			}
			this.PendingBossId = null;
			RoguelikeConfig instance = ConfigBase<RoguelikeConfig>.Instance;
			RogueTower? rogueTower = (instance != null) ? instance.GetRogueTowerConfig(bossId.Value) : null;
			if (rogueTower == null || string.IsNullOrEmpty(rogueTower.Value.Stand))
			{
				return;
			}
			base.SetTextureByPath(rogueTower.Value.Stand, base.GetTexture(0), null, null);
		}

		// Token: 0x060358F7 RID: 219383 RVA: 0x00D72364 File Offset: 0x00D70564
		private void RefreshDebuffList(int currentBossId)
		{
			List<RoguelikeBossChallengeBuffData> list = new List<RoguelikeBossChallengeBuffData>();
			int num = this.FinishedBossCount - 1;
			for (int i = this.SortedBossDataList.Count - 1; i >= 0; i--)
			{
				RoguelikeBossChallengeBossData roguelikeBossChallengeBossData = this.SortedBossDataList[i];
				if (roguelikeBossChallengeBossData.State != ERoguelikeBossChallengeBossState.Locked)
				{
					if (roguelikeBossChallengeBossData.State == ERoguelikeBossChallengeBossState.Finished)
					{
						RoguelikeConfig instance = ConfigBase<RoguelikeConfig>.Instance;
						RogueTower? rogueTower = (instance != null) ? instance.GetRogueTowerConfig(roguelikeBossChallengeBossData.Id) : null;
						int? num2 = null;
						if (((rogueTower != null) ? rogueTower.GetValueOrDefault().Buffs() : null) != null && num < rogueTower.Value.BuffsLength)
						{
							num2 = new int?(rogueTower.Value.Buffs()[num]);
						}
						if (num2 != null)
						{
							int? num3 = num2;
							int num4 = 0;
							if (!(num3.GetValueOrDefault() == num4 & num3 != null))
							{
								list.Add(new RoguelikeBossChallengeBuffData
								{
									BossId = roguelikeBossChallengeBossData.Id,
									Id = num2.Value,
									IsNew = false
								});
							}
						}
						num--;
					}
					if (roguelikeBossChallengeBossData.State == ERoguelikeBossChallengeBossState.Processing && roguelikeBossChallengeBossData.Id == currentBossId)
					{
						RoguelikeConfig instance2 = ConfigBase<RoguelikeConfig>.Instance;
						RogueTower? rogueTower2 = (instance2 != null) ? instance2.GetRogueTowerConfig(roguelikeBossChallengeBossData.Id) : null;
						int? num5 = null;
						if (((rogueTower2 != null) ? rogueTower2.GetValueOrDefault().Buffs() : null) != null && this.FinishedBossCount < rogueTower2.Value.BuffsLength)
						{
							num5 = new int?(rogueTower2.Value.Buffs()[this.FinishedBossCount]);
						}
						if (num5 != null)
						{
							int? num3 = num5;
							int num4 = 0;
							if (!(num3.GetValueOrDefault() == num4 & num3 != null))
							{
								list.Add(new RoguelikeBossChallengeBuffData
								{
									BossId = roguelikeBossChallengeBossData.Id,
									Id = num5.Value,
									IsNew = true
								});
							}
						}
					}
				}
			}
			RoguelikeBossChallengeDebuffListItem debuffListPanel = this.DebuffListPanel;
			if (debuffListPanel == null)
			{
				return;
			}
			debuffListPanel.RefreshDebuffList(list, currentBossId);
		}

		// Token: 0x060358F8 RID: 219384 RVA: 0x00D72590 File Offset: 0x00D70790
		private string GetBossSwitchSequenceName(ERoguelikeBossChallengeSwitchDirection direction)
		{
			if (direction != ERoguelikeBossChallengeSwitchDirection.Left)
			{
				return "SwitchR";
			}
			return "SwitchL";
		}

		// Token: 0x060358F9 RID: 219385 RVA: 0x00D725A0 File Offset: 0x00D707A0
		private bool IsBossSwitchSequencePlaying()
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null || !uiViewSequence.HasSequenceNameInPlaying("SwitchL"))
			{
				UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
				return uiViewSequence2 != null && uiViewSequence2.HasSequenceNameInPlaying("SwitchR");
			}
			return true;
		}

		// Token: 0x060358FA RID: 219386 RVA: 0x00D725D4 File Offset: 0x00D707D4
		private bool StopCurrentBossSwitchSequence()
		{
			bool result = false;
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence != null && uiViewSequence.HasSequenceNameInPlaying("SwitchL"))
			{
				UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
				if (uiViewSequence2 != null)
				{
					uiViewSequence2.StopSequenceByKey("SwitchL", false, true);
				}
				result = true;
			}
			UiBehaviorLevelSequence uiViewSequence3 = this.UiViewSequence;
			if (uiViewSequence3 != null && uiViewSequence3.HasSequenceNameInPlaying("SwitchR"))
			{
				UiBehaviorLevelSequence uiViewSequence4 = this.UiViewSequence;
				if (uiViewSequence4 != null)
				{
					uiViewSequence4.StopSequenceByKey("SwitchR", false, true);
				}
				result = true;
			}
			return result;
		}

		// Token: 0x060358FB RID: 219387 RVA: 0x00D7264A File Offset: 0x00D7084A
		private void OnBossSequenceEvent(string sequenceName, string eventName)
		{
			this.RefreshBossTexture(this.PendingBossId);
		}

		// Token: 0x060358FC RID: 219388 RVA: 0x00D72658 File Offset: 0x00D70858
		private void OnBossIndexChanged(ERoguelikeBossChallengeSwitchDirection direction)
		{
			this.RefreshBossListBySelectedBoss();
			this.RefreshCurrentBossDisplayWithAnim(direction);
		}

		// Token: 0x060358FD RID: 219389 RVA: 0x00D72667 File Offset: 0x00D70867
		private void OnCloseClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x060358FE RID: 219390 RVA: 0x00D72670 File Offset: 0x00D70870
		private void OnConfirmClick(int _)
		{
			RoguelikeBossChallengeSwitchItem bossSwitchPanel = this.BossSwitchPanel;
			int num = (bossSwitchPanel != null) ? bossSwitchPanel.GetCurrentBossId() : 0;
			if (num == 0)
			{
				return;
			}
			ControllerBase<RoguelikeController>.Instance.RoguelikeBossChallengeSelectBossRequest(num, delegate(bool success)
			{
				if (success)
				{
					base.CloseMe(null);
				}
			});
		}

		// Token: 0x060358FF RID: 219391 RVA: 0x00D726AB File Offset: 0x00D708AB
		private void OnDescModelChange()
		{
			RoguelikeBossChallengeDebuffListItem debuffListPanel = this.DebuffListPanel;
			if (debuffListPanel == null)
			{
				return;
			}
			debuffListPanel.OnDescModelChange();
		}

		// Token: 0x06035900 RID: 219392 RVA: 0x00D726C0 File Offset: 0x00D708C0
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (!(((configParams.Length != 0) ? configParams[0] : null) == "RogueLikeBossChallengeDebuffDetail"))
			{
				return null;
			}
			int index;
			int.TryParse((configParams.Length > 1) ? configParams[1] : null, out index);
			RoguelikeBossChallengeDebuffListItem debuffListPanel = this.DebuffListPanel;
			if (debuffListPanel == null)
			{
				return null;
			}
			RoguelikeBossChallengeDebuffItem uiItemByIndex = debuffListPanel.GetUiItemByIndex(index);
			if (uiItemByIndex == null)
			{
				return null;
			}
			UUIButtonComponent detailBtn = uiItemByIndex.GetDetailBtn();
			UUIItem uuiitem = (detailBtn != null) ? detailBtn.GetRootComponent() : null;
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}

		// Token: 0x0401EC4D RID: 126029
		private const string SWITCH_LEFT_SEQUENCE_NAME = "SwitchL";

		// Token: 0x0401EC4E RID: 126030
		private const string SWITCH_RIGHT_SEQUENCE_NAME = "SwitchR";

		// Token: 0x0401EC4F RID: 126031
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x0401EC50 RID: 126032
		[Nullable(2)]
		private RoguelikeBossChallengeSwitchItem BossSwitchPanel;

		// Token: 0x0401EC51 RID: 126033
		[Nullable(2)]
		private RoguelikeBossChallengeListItem BossListPanel;

		// Token: 0x0401EC52 RID: 126034
		[Nullable(2)]
		private RoguelikeBossChallengeDebuffListItem DebuffListPanel;

		// Token: 0x0401EC53 RID: 126035
		[Nullable(2)]
		private ButtonItem ConfirmButtonItem;

		// Token: 0x0401EC54 RID: 126036
		private List<RoguelikeBossChallengeBossData> SortedBossDataList = new List<RoguelikeBossChallengeBossData>();

		// Token: 0x0401EC55 RID: 126037
		private List<int> SelectableBossIds = new List<int>();

		// Token: 0x0401EC56 RID: 126038
		private int FinishedBossCount;

		// Token: 0x0401EC57 RID: 126039
		private int? PendingBossId;

		// Token: 0x0401EC58 RID: 126040
		[Nullable(2)]
		private AUIBaseActor TexBossActor;

		// Token: 0x0200B0E9 RID: 45289
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x04036DFC RID: 224764
			public const int TexBoss = 0;

			// Token: 0x04036DFD RID: 224765
			public const int CaptionItem = 1;

			// Token: 0x04036DFE RID: 224766
			public const int BossSwitchItem = 2;

			// Token: 0x04036DFF RID: 224767
			public const int BossListItem = 3;

			// Token: 0x04036E00 RID: 224768
			public const int DebuffListItem = 4;

			// Token: 0x04036E01 RID: 224769
			public const int ConfirmButtonItem = 5;
		}
	}
}
