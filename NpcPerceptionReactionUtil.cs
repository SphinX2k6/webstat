using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game;
using CSharpScript.Game.Module.Plot.Flow;

// Token: 0x020031CB RID: 12747
[NullableContext(1)]
[Nullable(0)]
public class NpcPerceptionReactionUtil
{
	// Token: 0x0601A6C1 RID: 108225 RVA: 0x007CB338 File Offset: 0x007C9538
	public static void TurnToPlayer(Entity entity)
	{
		BaseCharacterComponent component = entity.GetComponent<BaseCharacterComponent>();
		global::Vector actorLocationProxy = component.ActorLocationProxy;
		global::Vector actorLocationProxy2 = Global.BaseCharacter.CharacterActorComponent.ActorLocationProxy;
		global::Vector vector = global::Vector.Create();
		actorLocationProxy2.Subtraction(actorLocationProxy, vector);
		vector.Z = 0.0;
		vector.Normalize(9.99999993922529E-09);
		Rotator rotator = Rotator.Create();
		vector.ToOrientationRotator(rotator);
		BaseMoveComponent component2 = entity.GetComponent<BaseMoveComponent>();
		if (component2 != null)
		{
			component2.SmoothCharacterRotation(rotator, 20000f, Singleton<Time>.Instance.DeltaTimeSeconds, false, "Movement.SmoothCharacterRotation", true);
			return;
		}
		component.SetActorRotation(rotator.ToUeRotator(), "NpcPerformUnderAttackState.TurnToPlayer", true);
	}

	// Token: 0x0601A6C2 RID: 108226 RVA: 0x007CB3DC File Offset: 0x007C95DC
	public static void ShowHeadDialog(Entity entity, float bubbleRate, IBubbleIndex flow)
	{
		if (Singleton<MathUtils>.Instance.GetRandomFloatNumber(0f, 100f) > bubbleRate)
		{
			return;
		}
		PawnHeadInfoComponent component = entity.GetComponent<PawnHeadInfoComponent>();
		if (component == null)
		{
			return;
		}
		ShowTalk randomFlow = ConfigBase<FlowConfig>.Instance.GetRandomFlow(flow.FlowListName, flow.FlowId, entity.GetComponent<BaseCharacterComponent>().Actor.GetName(), flow.StateId);
		if (randomFlow == null || randomFlow.TalkItems.Count == 0)
		{
			return;
		}
		ITalkItem talkItem = randomFlow.TalkItems[0];
		if (StringUtils.IsEmpty(talkItem.TidTalk))
		{
			return;
		}
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(talkItem.TidTalk, null);
		if (talkItem.WaitTime != null)
		{
			float? waitTime = talkItem.WaitTime;
			float num = 0f;
			if (waitTime.GetValueOrDefault() > num & waitTime != null)
			{
				component.SetDialogueText(localTextNew, talkItem.WaitTime.Value, false);
				return;
			}
		}
		component.SetDialogueText(localTextNew, 3f, false);
	}

	// Token: 0x0400D551 RID: 54609
	private const int BUBBLE_RANDOM_MAX = 100;

	// Token: 0x0400D552 RID: 54610
	private const int TURN_SPEED = 20000;

	// Token: 0x0400D553 RID: 54611
	private const int BUBBLE_TIME = 3;
}
