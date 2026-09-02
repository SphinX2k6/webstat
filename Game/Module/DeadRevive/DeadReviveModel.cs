using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.DeadRevive
{
	// Token: 0x02005DC6 RID: 24006
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class DeadReviveModel : ModelBase<DeadReviveModel>
	{
		// Token: 0x170098C6 RID: 39110
		// (get) Token: 0x0603C6EB RID: 247531 RVA: 0x00F57FD8 File Offset: 0x00F561D8
		public bool SkipFallInjure
		{
			get
			{
				using (Dictionary<ESkipFallInjureReason, bool>.ValueCollection.Enumerator enumerator = this.SkipFallInjureMap.Values.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		// Token: 0x0603C6EC RID: 247532 RVA: 0x00F58034 File Offset: 0x00F56234
		public unsafe void SetSkipFallInjure(ESkipFallInjureReason reason, bool skip)
		{
			this.SkipFallInjureMap[reason] = skip;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CK;
			string message = "防跌落伤害状态变更";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Skip", skip);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Result", this.SkipFallInjure);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}

		// Token: 0x0603C6ED RID: 247533 RVA: 0x00F580D0 File Offset: 0x00F562D0
		public void InitReviveConfig(int reviveId)
		{
			if (this.ReviveConfig == null || this.ReviveConfig.Value.Id != reviveId)
			{
				this.ReviveConfig = ConfigReviveById.GetConfig(reviveId, true);
			}
		}

		// Token: 0x0603C6EE RID: 247534 RVA: 0x00F5810D File Offset: 0x00F5630D
		protected override bool OnClear()
		{
			this.ClearAll();
			return true;
		}

		// Token: 0x0603C6EF RID: 247535 RVA: 0x00F58116 File Offset: 0x00F56316
		protected override bool OnLeaveLevel()
		{
			this.ClearAll();
			return true;
		}

		// Token: 0x0603C6F0 RID: 247536 RVA: 0x00F5811F File Offset: 0x00F5631F
		protected override bool OnChangeMode()
		{
			this.ClearAll();
			return true;
		}

		// Token: 0x0603C6F1 RID: 247537 RVA: 0x00F58128 File Offset: 0x00F56328
		private void ClearAll()
		{
			this.ClearReviveData();
			this.ClearExternalHandles();
			this.ReviveMode = EReviveMode.Common;
			this.CurrentShareReviveTimes = 0;
			this.MaxShareReviveTimes = 0;
			this.RevivePosition = null;
			this.ReviveRotator = null;
			this.ReviveGravity = null;
			this.ReviveFlowIncId = 0L;
			this.BlockAllInput = false;
			this.ChangeRoleIdAfterRevive = 0;
			foreach (KeyValuePair<long, ReviveCooldownData> keyValuePair in this.ReviveCooldownCreatureMap)
			{
				long num;
				ReviveCooldownData reviveCooldownData;
				keyValuePair.Deconstruct(out num, out reviveCooldownData);
				long creatureDataId = num;
				ReviveCooldownData data = reviveCooldownData;
				this.EndCooldown(creatureDataId, data);
			}
			this.ReviveCooldownCreatureMap.Clear();
			this.SkipFallInjureMap.Clear();
		}

		// Token: 0x0603C6F2 RID: 247538 RVA: 0x00F581FC File Offset: 0x00F563FC
		public void ClearReviveData()
		{
			this.ReviveLimitTime = 0f;
			this.IsShowRevive = false;
			this.IsAutoRevive = false;
			if (this.DeadDelayTimer != null)
			{
				this.DeadDelayTimer.Remove();
				this.DeadDelayTimer = null;
			}
		}

		// Token: 0x0603C6F3 RID: 247539 RVA: 0x00F58232 File Offset: 0x00F56432
		public void ClearExternalHandles()
		{
			this.HandleOnClickGiveUpExternal = null;
		}

		// Token: 0x0603C6F4 RID: 247540 RVA: 0x00F5823C File Offset: 0x00F5643C
		public void RegisterCooldown(long creatureDataId, long cdMilliseconds)
		{
			if (this.ReviveCooldownCreatureMap.ContainsKey(creatureDataId))
			{
				return;
			}
			SceneTeamItem teamItem = ModelBase<SceneTeamModel>.Instance.GetTeamItem(creatureDataId, new GetTeamItemOptions
			{
				ParamType = ETeamParamType.CreatureDataId
			});
			if (teamItem == null)
			{
				return;
			}
			int playerId = teamItem.GetPlayerId();
			BattleUiFormationPanelData formationPanelData = ModelBase<BattleUiModel>.Instance.FormationPanelData;
			int? num = (formationPanelData != null) ? new int?(formationPanelData.GetRolePosition(playerId, teamItem.GetConfigId)) : null;
			if (num != null)
			{
				int? num2 = num;
				int num3 = 1;
				if (!(num2.GetValueOrDefault() < num3 & num2 != null))
				{
					float cdSeconds = (float)cdMilliseconds * 0.001f;
					int index = num.Value - 1;
					TimerHandle handle = null;
					handle = TimerSystem.GameplayTimeInstance.Forever(delegate(float delta)
					{
						ReviveCooldownData reviveCooldownData = null;
						this.ReviveCooldownCreatureMap.TryGetValue(creatureDataId, out reviveCooldownData);
						if (reviveCooldownData == null)
						{
							Singleton<EventSystem>.Instance.Emit<int, int, float?, float?>(EEventName.OnRefreshFormationCooldownExternalInBattleView, playerId, teamItem.GetConfigId, null, null);
							Singleton<EventSystem>.Instance.Emit<long, float>(EEventName.OnRoleReviveCooldownChange, creatureDataId, 0f);
							TimerHandle handle = handle;
							if (handle == null)
							{
								return;
							}
							handle.Remove();
							return;
						}
						else
						{
							double serverStopTimeStamp = Singleton<Time>.Instance.ServerStopTimeStamp;
							double num4 = serverStopTimeStamp - reviveCooldownData.LastServerStopTimeStamp;
							reviveCooldownData.LastServerStopTimeStamp = serverStopTimeStamp;
							double num5 = reviveCooldownData.RemainMilliseconds - num4;
							if (num5 <= 0.0)
							{
								this.UnRegisterCooldown(creatureDataId);
								return;
							}
							reviveCooldownData.RemainMilliseconds = num5;
							float num6 = (float)num5 * 0.001f;
							Singleton<EventSystem>.Instance.Emit<int, int, float?, float?>(EEventName.OnRefreshFormationCooldownExternalInBattleView, playerId, teamItem.GetConfigId, new float?(num6), new float?(cdSeconds));
							Singleton<EventSystem>.Instance.Emit<long, float>(EEventName.OnRoleReviveCooldownChange, creatureDataId, num6);
							return;
						}
					}, 100f, 1f, null, null, true);
					if (handle != null)
					{
						ReviveCooldownData value = new ReviveCooldownData
						{
							Index = index,
							RemainMilliseconds = (double)cdMilliseconds,
							TimerHandle = handle,
							LastServerStopTimeStamp = Singleton<Time>.Instance.ServerStopTimeStamp
						};
						this.ReviveCooldownCreatureMap[creatureDataId] = value;
					}
					return;
				}
			}
		}

		// Token: 0x0603C6F5 RID: 247541 RVA: 0x00F5839C File Offset: 0x00F5659C
		public void UnRegisterCooldown(long creatureDataId)
		{
			ReviveCooldownData data;
			if (this.ReviveCooldownCreatureMap.TryGetValue(creatureDataId, out data))
			{
				this.EndCooldown(creatureDataId, data);
				this.ReviveCooldownCreatureMap.Remove(creatureDataId);
			}
		}

		// Token: 0x0603C6F6 RID: 247542 RVA: 0x00F583D0 File Offset: 0x00F565D0
		private void EndCooldown(long creatureDataId, ReviveCooldownData data)
		{
			TimerHandle timerHandle = data.TimerHandle;
			if (timerHandle != null)
			{
				timerHandle.Remove();
			}
			SceneTeamItem teamItem = ModelBase<SceneTeamModel>.Instance.GetTeamItem(creatureDataId, new GetTeamItemOptions
			{
				ParamType = ETeamParamType.CreatureDataId
			});
			if (teamItem != null)
			{
				Singleton<EventSystem>.Instance.Emit<int, int, float?, float?>(EEventName.OnRefreshFormationCooldownExternalInBattleView, teamItem.GetPlayerId(), teamItem.GetConfigId, null, null);
			}
			Singleton<EventSystem>.Instance.Emit<long, float>(EEventName.OnRoleReviveCooldownChange, creatureDataId, 0f);
		}

		// Token: 0x04021F97 RID: 139159
		public EReviveMode ReviveMode;

		// Token: 0x04021F98 RID: 139160
		public bool IsAutoRevive;

		// Token: 0x04021F99 RID: 139161
		public bool IsShowRevive;

		// Token: 0x04021F9A RID: 139162
		public float ReviveLimitTime;

		// Token: 0x04021F9B RID: 139163
		public FVectorDouble? RevivePosition;

		// Token: 0x04021F9C RID: 139164
		public FRotator? ReviveRotator;

		// Token: 0x04021F9D RID: 139165
		[Nullable(2)]
		public global::Vector ReviveGravity;

		// Token: 0x04021F9E RID: 139166
		public Revive? ReviveConfig;

		// Token: 0x04021F9F RID: 139167
		[Nullable(2)]
		public TimerHandle DeadDelayTimer;

		// Token: 0x04021FA0 RID: 139168
		public Dictionary<long, ReviveCooldownData> ReviveCooldownCreatureMap = new Dictionary<long, ReviveCooldownData>();

		// Token: 0x04021FA1 RID: 139169
		public int CurrentShareReviveTimes;

		// Token: 0x04021FA2 RID: 139170
		public int MaxShareReviveTimes;

		// Token: 0x04021FA3 RID: 139171
		public int ChangeRoleIdAfterRevive;

		// Token: 0x04021FA4 RID: 139172
		public EUiViewName? OpenedViewName;

		// Token: 0x04021FA5 RID: 139173
		public bool BlockAllInput;

		// Token: 0x04021FA6 RID: 139174
		private Dictionary<ESkipFallInjureReason, bool> SkipFallInjureMap = new Dictionary<ESkipFallInjureReason, bool>();

		// Token: 0x04021FA7 RID: 139175
		public bool SkipDeathAnim;

		// Token: 0x04021FA8 RID: 139176
		public long ReviveFlowIncId;

		// Token: 0x04021FA9 RID: 139177
		[Nullable(2)]
		public Action HandleOnClickGiveUpExternal;
	}
}
