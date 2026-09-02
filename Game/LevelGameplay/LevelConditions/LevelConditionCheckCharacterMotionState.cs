using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CCA RID: 27850
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelConditionCheckCharacterMotionState : LevelConditionBase, IStaticVariableResetter
	{
		// Token: 0x060443A8 RID: 279464 RVA: 0x011B781C File Offset: 0x011B5A1C
		static LevelConditionCheckCharacterMotionState()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(LevelConditionCheckCharacterMotionState.CreateStaticDefaultValue), new Action(LevelConditionCheckCharacterMotionState.ResetStaticDefaultValue));
		}

		// Token: 0x060443A9 RID: 279465 RVA: 0x011B783B File Offset: 0x011B5A3B
		public static void CreateStaticDefaultValue()
		{
			LevelConditionCheckCharacterMotionState.RegisteredCallbacks = new Dictionary<TMotionStateCallback, LevelConditionCheckCharacterMotionState.CallbackAdapters>();
			LevelConditionCheckCharacterMotionState.SubscribedEntity = null;
		}

		// Token: 0x060443AA RID: 279466 RVA: 0x011B784D File Offset: 0x011B5A4D
		public static void ResetStaticDefaultValue()
		{
			LevelConditionCheckCharacterMotionState.RegisteredCallbacks = null;
			LevelConditionCheckCharacterMotionState.SubscribedEntity = null;
		}

		// Token: 0x060443AB RID: 279467 RVA: 0x011B785B File Offset: 0x011B5A5B
		private List<string> ParseModes([Nullable(2)] string raw)
		{
			if (string.IsNullOrEmpty(raw))
			{
				return new List<string>();
			}
			return raw.TrimStart('[').TrimEnd(']').Split(',', StringSplitOptions.None).ToList<string>();
		}

		// Token: 0x060443AC RID: 279468 RVA: 0x011B7888 File Offset: 0x011B5A88
		private List<string> GetModes(Condition inConditionInfo)
		{
			List<string> list;
			if (!this.ModeCache.TryGetValue(inConditionInfo.Id, out list))
			{
				list = this.ParseModes(inConditionInfo.GetLimitParams("MotionState"));
				this.ModeCache[inConditionInfo.Id] = list;
			}
			return list;
		}

		// Token: 0x060443AD RID: 279469 RVA: 0x011B78D4 File Offset: 0x011B5AD4
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity == null)
			{
				Singleton<Log>.Instance.Warn(ELogModule.LevelCondition, ELogAuthor.CB, "[CheckPlayerMotionState]无法获取当前角色", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			CharacterUnifiedStateComponent component = getCurrentEntity.Entity.GetComponent<CharacterUnifiedStateComponent>();
			if (component == null)
			{
				Singleton<Log>.Instance.Warn(ELogModule.LevelCondition, ELogAuthor.CB, "[CheckPlayerMotionState]无法获取当前角色UnifiedState组件", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			List<string> modes = this.GetModes(inConditionInfo);
			if (modes.Count == 0)
			{
				return false;
			}
			bool flag = false;
			bool flag2 = false;
			foreach (string text in modes)
			{
				if (text == null)
				{
					goto IL_2F2;
				}
				switch (text.Length)
				{
				case 3:
					if (!(text == "Air"))
					{
						goto IL_2F2;
					}
					flag = (component.PositionState == ECharPositionState.Air);
					break;
				case 4:
				case 8:
					goto IL_2F2;
				case 5:
				{
					char c = text[0];
					if (c != 'C')
					{
						if (c != 'W')
						{
							goto IL_2F2;
						}
						if (!(text == "Water"))
						{
							goto IL_2F2;
						}
						flag = (component.PositionState == ECharPositionState.Water);
					}
					else
					{
						if (!(text == "Climb"))
						{
							goto IL_2F2;
						}
						flag = (component.PositionState == ECharPositionState.Climb);
					}
					break;
				}
				case 6:
					if (!(text == "Ground"))
					{
						goto IL_2F2;
					}
					flag = (component.PositionState == ECharPositionState.Ground && component.PositionSubState == ECharPositionSubState.None);
					break;
				case 7:
					if (!(text == "Soaring"))
					{
						goto IL_2F2;
					}
					flag = (component.PositionState == ECharPositionState.Air && component.MoveState == ECharMoveState.Soar);
					break;
				case 9:
				{
					char c = text[0];
					if (c != 'F')
					{
						if (c != 'G')
						{
							goto IL_2F2;
						}
						if (!(text == "Gongduola"))
						{
							goto IL_2F2;
						}
						flag = (component.PositionState == ECharPositionState.Ride && component.MoveState == ECharMoveState.Gongduola);
					}
					else
					{
						if (!(text == "FallInAir"))
						{
							goto IL_2F2;
						}
						flag = (component.PositionState == ECharPositionState.Air && component.MoveState == ECharMoveState.Other);
					}
					break;
				}
				case 10:
				{
					char c = text[0];
					if (c != 'G')
					{
						if (c != 'O')
						{
							goto IL_2F2;
						}
						if (!(text == "OnClimbing"))
						{
							goto IL_2F2;
						}
						flag = (component.PositionState == ECharPositionState.Climb && (component.MoveState == ECharMoveState.Other || component.MoveState == ECharMoveState.NormalClimb || component.MoveState == ECharMoveState.FastClimb));
					}
					else
					{
						if (!(text == "GlideInAir"))
						{
							goto IL_2F2;
						}
						flag = (component.PositionState == ECharPositionState.Air && component.MoveState == ECharMoveState.Glide);
					}
					break;
				}
				case 11:
					if (!(text == "WalkOnWater"))
					{
						goto IL_2F2;
					}
					flag = (component.PositionState == ECharPositionState.Ground && component.PositionSubState == ECharPositionSubState.WaterSurface);
					break;
				default:
					goto IL_2F2;
				}
				IL_2F5:
				if (flag2)
				{
					BaseTagComponent component2 = getCurrentEntity.Entity.GetComponent<BaseTagComponent>();
					if (component2 == null)
					{
						Singleton<Log>.Instance.Warn(ELogModule.LevelCondition, ELogAuthor.CB, "[CheckPlayerMotionState]无法获取当前角色CharacterGameplayTag组件", default(ReadOnlySpan<ValueTuple<string, object>>));
						return false;
					}
					if (!(text == "SwitchSkill"))
					{
						if (!(text == "UltimateDodge"))
						{
							if (text == "UltimateSkill")
							{
								flag = component2.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.大招"]);
							}
						}
						else
						{
							flag = component2.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.极限闪避"]);
						}
					}
					else
					{
						flag = component2.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.QTE"]);
					}
				}
				if (flag)
				{
					break;
				}
				continue;
				IL_2F2:
				flag2 = true;
				goto IL_2F5;
			}
			string text2 = inConditionInfo.GetLimitParamsOpe("MotionState") ?? "";
			bool result = false;
			if (!(text2 == "!="))
			{
				if (!(text2 == "="))
				{
					if (text2 == null)
					{
						return result;
					}
					if (text2.Length != 0)
					{
						return result;
					}
				}
				result = flag;
			}
			else
			{
				result = !flag;
			}
			return result;
		}

		// Token: 0x060443AE RID: 279470 RVA: 0x011B7D20 File Offset: 0x011B5F20
		public static void RegisterEvents(TMotionStateCallback callback)
		{
			if (LevelConditionCheckCharacterMotionState.RegisteredCallbacks.ContainsKey(callback))
			{
				return;
			}
			if (LevelConditionCheckCharacterMotionState.RegisteredCallbacks.Count == 0)
			{
				EventSystem instance = Singleton<EventSystem>.Instance;
				EEventName name = EEventName.OnChangeRole;
				Action<EntityHandle, EntityHandle> handle;
				if ((handle = LevelConditionCheckCharacterMotionState.<>O.<0>__OnChangeRole) == null)
				{
					handle = (LevelConditionCheckCharacterMotionState.<>O.<0>__OnChangeRole = new Action<EntityHandle, EntityHandle>(LevelConditionCheckCharacterMotionState.OnChangeRole));
				}
				instance.Add(name, handle);
				SceneTeamModel instance2 = ModelBase<SceneTeamModel>.Instance;
				WorldEntity subscribedEntity;
				if (instance2 == null)
				{
					subscribedEntity = null;
				}
				else
				{
					EntityHandle getCurrentEntity = instance2.GetCurrentEntity;
					subscribedEntity = ((getCurrentEntity != null) ? getCurrentEntity.Entity : null);
				}
				LevelConditionCheckCharacterMotionState.SubscribedEntity = subscribedEntity;
			}
			LevelConditionCheckCharacterMotionState.CallbackAdapters callbackAdapters = new LevelConditionCheckCharacterMotionState.CallbackAdapters
			{
				MoveState = delegate(ECharMoveState oldState, ECharMoveState newState)
				{
					callback(new object[]
					{
						oldState,
						newState
					});
				},
				PositionState = delegate(ECharPositionState oldState, ECharPositionState newState)
				{
					callback(new object[]
					{
						oldState,
						newState
					});
				},
				PositionSubState = delegate(ECharPositionSubState oldState, ECharPositionSubState newState)
				{
					callback(new object[]
					{
						oldState,
						newState
					});
				}
			};
			LevelConditionCheckCharacterMotionState.RegisteredCallbacks[callback] = callbackAdapters;
			LevelConditionCheckCharacterMotionState.SubscribeCallback(callbackAdapters);
		}

		// Token: 0x060443AF RID: 279471 RVA: 0x011B7DFC File Offset: 0x011B5FFC
		public static void UnRegisterEvents(TMotionStateCallback callback)
		{
			LevelConditionCheckCharacterMotionState.CallbackAdapters adapters;
			if (!LevelConditionCheckCharacterMotionState.RegisteredCallbacks.TryGetValue(callback, out adapters))
			{
				return;
			}
			LevelConditionCheckCharacterMotionState.RegisteredCallbacks.Remove(callback);
			LevelConditionCheckCharacterMotionState.UnsubscribeCallback(adapters);
			if (LevelConditionCheckCharacterMotionState.RegisteredCallbacks.Count == 0)
			{
				EventSystem instance = Singleton<EventSystem>.Instance;
				EEventName name = EEventName.OnChangeRole;
				Action<EntityHandle, EntityHandle> handle;
				if ((handle = LevelConditionCheckCharacterMotionState.<>O.<0>__OnChangeRole) == null)
				{
					handle = (LevelConditionCheckCharacterMotionState.<>O.<0>__OnChangeRole = new Action<EntityHandle, EntityHandle>(LevelConditionCheckCharacterMotionState.OnChangeRole));
				}
				instance.Remove(name, handle);
				LevelConditionCheckCharacterMotionState.SubscribedEntity = null;
			}
		}

		// Token: 0x060443B0 RID: 279472 RVA: 0x011B7E68 File Offset: 0x011B6068
		private static void OnChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
		{
			foreach (LevelConditionCheckCharacterMotionState.CallbackAdapters adapters in LevelConditionCheckCharacterMotionState.RegisteredCallbacks.Values)
			{
				LevelConditionCheckCharacterMotionState.UnsubscribeCallback(adapters);
			}
			LevelConditionCheckCharacterMotionState.SubscribedEntity = ((newEntity != null) ? newEntity.Entity : null);
			foreach (LevelConditionCheckCharacterMotionState.CallbackAdapters adapters2 in LevelConditionCheckCharacterMotionState.RegisteredCallbacks.Values)
			{
				LevelConditionCheckCharacterMotionState.SubscribeCallback(adapters2);
			}
		}

		// Token: 0x060443B1 RID: 279473 RVA: 0x011B7F10 File Offset: 0x011B6110
		private static void SubscribeCallback(LevelConditionCheckCharacterMotionState.CallbackAdapters adapters)
		{
			WorldEntity subscribedEntity = LevelConditionCheckCharacterMotionState.SubscribedEntity;
			if (subscribedEntity == null)
			{
				return;
			}
			Singleton<EventSystem>.Instance.AddWithTarget<ECharMoveState, ECharMoveState>(subscribedEntity, EEventName.CharOnUnifiedMoveStateChanged, adapters.MoveState);
			Singleton<EventSystem>.Instance.AddWithTarget<ECharPositionState, ECharPositionState>(subscribedEntity, EEventName.CharOnPositionStateChanged, adapters.PositionState);
			Singleton<EventSystem>.Instance.AddWithTarget<ECharPositionSubState, ECharPositionSubState>(subscribedEntity, EEventName.CharOnPositionSubStateChanged, adapters.PositionSubState);
		}

		// Token: 0x060443B2 RID: 279474 RVA: 0x011B7F6C File Offset: 0x011B616C
		private static void UnsubscribeCallback(LevelConditionCheckCharacterMotionState.CallbackAdapters adapters)
		{
			WorldEntity subscribedEntity = LevelConditionCheckCharacterMotionState.SubscribedEntity;
			if (subscribedEntity == null)
			{
				return;
			}
			Singleton<EventSystem>.Instance.RemoveWithTarget<ECharMoveState, ECharMoveState>(subscribedEntity, EEventName.CharOnUnifiedMoveStateChanged, adapters.MoveState);
			Singleton<EventSystem>.Instance.RemoveWithTarget<ECharPositionState, ECharPositionState>(subscribedEntity, EEventName.CharOnPositionStateChanged, adapters.PositionState);
			Singleton<EventSystem>.Instance.RemoveWithTarget<ECharPositionSubState, ECharPositionSubState>(subscribedEntity, EEventName.CharOnPositionSubStateChanged, adapters.PositionSubState);
		}

		// Token: 0x040260C8 RID: 155848
		private readonly Dictionary<int, List<string>> ModeCache = new Dictionary<int, List<string>>();

		// Token: 0x040260C9 RID: 155849
		private static Dictionary<TMotionStateCallback, LevelConditionCheckCharacterMotionState.CallbackAdapters> RegisteredCallbacks;

		// Token: 0x040260CA RID: 155850
		[Nullable(2)]
		private static WorldEntity SubscribedEntity;

		// Token: 0x0200CB17 RID: 51991
		[Nullable(0)]
		[RequiredMember]
		private sealed class CallbackAdapters
		{
			// Token: 0x0604F75C RID: 325468 RVA: 0x016253F3 File Offset: 0x016235F3
			[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
			[CompilerFeatureRequired("RequiredMembers")]
			public CallbackAdapters()
			{
			}

			// Token: 0x0403E57B RID: 255355
			[RequiredMember]
			public Action<ECharMoveState, ECharMoveState> MoveState;

			// Token: 0x0403E57C RID: 255356
			[RequiredMember]
			public Action<ECharPositionState, ECharPositionState> PositionState;

			// Token: 0x0403E57D RID: 255357
			[RequiredMember]
			public Action<ECharPositionSubState, ECharPositionSubState> PositionSubState;
		}

		// Token: 0x0200CB18 RID: 51992
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403E57E RID: 255358
			[Nullable(new byte[]
			{
				0,
				1,
				2
			})]
			public static Action<EntityHandle, EntityHandle> <0>__OnChangeRole;
		}
	}
}
