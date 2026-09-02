using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Render;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.FindSunSprite.Performance.Level
{
	// Token: 0x02006EBE RID: 28350
	[NullableContext(1)]
	[Nullable(0)]
	public class FindSunSpiritLevelModifier
	{
		// Token: 0x06044B94 RID: 281492 RVA: 0x011DDD98 File Offset: 0x011DBF98
		public UniTask RefreshAsync(string levelPrefabPath, bool isSelected, Vector location, Rotator rotation)
		{
			FindSunSpiritLevelModifier.<RefreshAsync>d__7 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.levelPrefabPath = levelPrefabPath;
			<RefreshAsync>d__.isSelected = isSelected;
			<RefreshAsync>d__.location = location;
			<RefreshAsync>d__.rotation = rotation;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<FindSunSpiritLevelModifier.<RefreshAsync>d__7>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06044B95 RID: 281493 RVA: 0x011DDDFC File Offset: 0x011DBFFC
		public void Clear()
		{
			TimerHandle triggerHandle = this.TriggerHandle;
			if (triggerHandle != null)
			{
				triggerHandle.Remove();
			}
			this.TriggerHandle = null;
			SceneInteractionManager.Get().DestroySceneInteraction(this.LevelHandleId);
		}

		// Token: 0x06044B96 RID: 281494 RVA: 0x011DDE28 File Offset: 0x011DC028
		public void ResetState(bool isSelected)
		{
			TimerHandle triggerHandle = this.TriggerHandle;
			if (triggerHandle != null)
			{
				triggerHandle.Remove();
			}
			this.TriggerHandle = null;
			this.UpdateState(isSelected ? EModifierStateType.Selected : EModifierStateType.Common);
		}

		// Token: 0x06044B97 RID: 281495 RVA: 0x011DDE50 File Offset: 0x011DC050
		public void UpdateSelect(bool isSelected)
		{
			EModifierStateType emodifierStateType = isSelected ? EModifierStateType.Selected : EModifierStateType.Common;
			if (this.CurrentState == EModifierStateType.Trigger)
			{
				this.LastStateCache = new EModifierStateType?(emodifierStateType);
				return;
			}
			this.UpdateState(emodifierStateType);
		}

		// Token: 0x06044B98 RID: 281496 RVA: 0x011DDE82 File Offset: 0x011DC082
		public void Trigger(int duration)
		{
			if (this.CurrentState == EModifierStateType.Trigger)
			{
				return;
			}
			this.UpdateState(EModifierStateType.Trigger);
			this.TriggerHandle = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.TriggerHandle = null;
				if (this.LastStateCache != null)
				{
					this.UpdateState(this.LastStateCache.Value);
					this.LastStateCache = null;
					return;
				}
				this.UpdateState(EModifierStateType.Selected);
			}, (float)duration, null, null, true, 1f);
		}

		// Token: 0x06044B99 RID: 281497 RVA: 0x011DDEBB File Offset: 0x011DC0BB
		private void UpdateState(EModifierStateType type)
		{
			this.CurrentState = type;
			SceneInteractionManager.Get().SwitchSceneInteractionToState(this.LevelHandleId, this.GetLevelState(type), false, false, false);
		}

		// Token: 0x06044B9A RID: 281498 RVA: 0x011DDEDF File Offset: 0x011DC0DF
		private EKuroSceneInteractionState GetLevelState(EModifierStateType type)
		{
			switch (type)
			{
			case EModifierStateType.Common:
				return EKuroSceneInteractionState.State1;
			case EModifierStateType.Selected:
				return EKuroSceneInteractionState.State2;
			case EModifierStateType.Trigger:
				return EKuroSceneInteractionState.State3;
			default:
				return EKuroSceneInteractionState.State1;
			}
		}

		// Token: 0x0402643D RID: 156733
		private string PrefabPath = "";

		// Token: 0x0402643E RID: 156734
		private int LevelHandleId;

		// Token: 0x0402643F RID: 156735
		private readonly Vector Location = Vector.Create();

		// Token: 0x04026440 RID: 156736
		private readonly Rotator Rotation = Rotator.Create();

		// Token: 0x04026441 RID: 156737
		private EModifierStateType CurrentState;

		// Token: 0x04026442 RID: 156738
		private EModifierStateType? LastStateCache;

		// Token: 0x04026443 RID: 156739
		[Nullable(2)]
		private TimerHandle TriggerHandle;
	}
}
