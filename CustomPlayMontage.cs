using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Character.Npc.Logics;
using UnrealEngine;

// Token: 0x02002EAA RID: 11946
[NullableContext(2)]
[Nullable(0)]
public class CustomPlayMontage : CustomActionBase
{
	// Token: 0x0601883D RID: 100413 RVA: 0x006DFFD8 File Offset: 0x006DE1D8
	public CustomPlayMontage(BasePerformComponent performComp, [Nullable(1)] CharacterAnimationComponent animComp, [Nullable(1)] string path, IAnimStateParam state = null, Action onPlayMontage = null, Action onStopMontage = null, Action callback = null)
	{
		this.PerformComp = performComp;
		this.AnimComp = animComp;
		this.Path = path;
		this.State = state;
		this.OnPlayMontage = onPlayMontage;
		this.OnStopMontage = onStopMontage;
		this.Callback = callback;
	}

	// Token: 0x0601883E RID: 100414 RVA: 0x006E0028 File Offset: 0x006DE228
	protected override void OnRunAction()
	{
		CustomPlayMontage.<>c__DisplayClass8_0 CS$<>8__locals1 = new CustomPlayMontage.<>c__DisplayClass8_0();
		CS$<>8__locals1.<>4__this = this;
		if (this.AnimComp == null)
		{
			base.Finish(false);
			return;
		}
		CS$<>8__locals1.playMontage = delegate()
		{
			Action onPlayMontage2 = CS$<>8__locals1.<>4__this.OnPlayMontage;
			if (onPlayMontage2 == null)
			{
				return;
			}
			onPlayMontage2();
		};
		Action<UAnimMontage> onPlay = delegate(UAnimMontage _)
		{
			CS$<>8__locals1.playMontage();
		};
		Action<PlayingMontageInfo> onPlayMontage = delegate(PlayingMontageInfo _)
		{
			CS$<>8__locals1.playMontage();
		};
		CustomPlayMontage.<>c__DisplayClass8_0 CS$<>8__locals2 = CS$<>8__locals1;
		NpcPerformComponent npcPerformComponent = this.PerformComp as NpcPerformComponent;
		CS$<>8__locals2.lastAnimState = ((npcPerformComponent != null) ? npcPerformComponent.CurAnimState : -1);
		CS$<>8__locals1.stopMontage = delegate()
		{
			if (CS$<>8__locals1.<>4__this.CheckFinish(0f))
			{
				return;
			}
			Action onStopMontage2 = CS$<>8__locals1.<>4__this.OnStopMontage;
			if (onStopMontage2 != null)
			{
				onStopMontage2();
			}
			CS$<>8__locals1.<>4__this.Finish(true);
			if (CS$<>8__locals1.<>4__this.PerformComp != null)
			{
				NpcPerformComponent npcPerformComponent2 = CS$<>8__locals1.<>4__this.PerformComp as NpcPerformComponent;
				if (npcPerformComponent2 == null)
				{
					return;
				}
				npcPerformComponent2.SwitchAnimState(new SwitchState
				{
					TargetStateName = (CS$<>8__locals1.<>4__this.PerformComp as NpcPerformComponent).GetAnimStateName(CS$<>8__locals1.lastAnimState),
					Context = "[CustomAction][CustomPlayMontage]切回之前的状态"
				});
			}
		};
		Action<UAnimMontage, bool> onEnd = delegate(UAnimMontage _, bool _)
		{
			CS$<>8__locals1.stopMontage();
		};
		Action<PlayingMontageInfo> onStopMontage = delegate(PlayingMontageInfo _)
		{
			CS$<>8__locals1.stopMontage();
		};
		if (this.PerformComp != null)
		{
			this.PlayMontageId = this.PerformComp.VolatileMontagePlayByLoad(EPerformMode.Action, this.Path, this.State, onPlay, onEnd, new float?(0f), new float?(0f), new bool?(false), new bool?(false), new bool?(false));
		}
		else
		{
			this.PlayMontageId = Singleton<PlayMontageUtils>.Instance.LoadAndPlayMontage(this.AnimComp, this.Path, new PlayMontageConfig(0, 0.0, false, false), onPlayMontage, onStopMontage, null);
		}
		if (this.PlayMontageId < 0)
		{
			base.Finish(false);
		}
	}

	// Token: 0x0601883F RID: 100415 RVA: 0x006E015C File Offset: 0x006DE35C
	protected override void OnAbort()
	{
		if (this.PlayMontageId < 0)
		{
			return;
		}
		if (this.PerformComp != null)
		{
			this.PerformComp.VolatileMontageStopByLoad(EPerformMode.Ecology, this.PlayMontageId, EStopMethod.BlendOut);
			return;
		}
		Singleton<PlayMontageUtils>.Instance.ClearAndStopMontage(this.PlayMontageId, this.AnimComp, 0f);
	}

	// Token: 0x0400BD3B RID: 48443
	private readonly BasePerformComponent PerformComp;

	// Token: 0x0400BD3C RID: 48444
	[Nullable(1)]
	private readonly CharacterAnimationComponent AnimComp;

	// Token: 0x0400BD3D RID: 48445
	[Nullable(1)]
	private readonly string Path;

	// Token: 0x0400BD3E RID: 48446
	private readonly IAnimStateParam State;

	// Token: 0x0400BD3F RID: 48447
	private readonly Action OnPlayMontage;

	// Token: 0x0400BD40 RID: 48448
	private readonly Action OnStopMontage;

	// Token: 0x0400BD41 RID: 48449
	private int PlayMontageId = -1;
}
