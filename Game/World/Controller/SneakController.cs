using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.World.Controller
{
	// Token: 0x020046E8 RID: 18152
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class SneakController : ControllerBase<SneakController>
	{
		// Token: 0x0602F36D RID: 193389 RVA: 0x00B30714 File Offset: 0x00B2E914
		public void StartSneaking()
		{
			this.InSneakGameplay = true;
			this.AddOrRemoveSneakBuff(true);
			this.AddSneakEvent();
			Singleton<EventSystem>.Instance.Emit(EEventName.SneakStart);
		}

		// Token: 0x0602F36E RID: 193390 RVA: 0x00B3073A File Offset: 0x00B2E93A
		public void EndSneaking()
		{
			this.InSneakGameplay = false;
			this.AddOrRemoveSneakBuff(false);
			this.RemoveSneakEvent();
			Singleton<EventSystem>.Instance.Emit(EEventName.SneakEnd);
		}

		// Token: 0x17008145 RID: 33093
		// (get) Token: 0x0602F36F RID: 193391 RVA: 0x00B30760 File Offset: 0x00B2E960
		public bool IsSneaking
		{
			get
			{
				return this.InSneakGameplay;
			}
		}

		// Token: 0x0602F370 RID: 193392 RVA: 0x00B30768 File Offset: 0x00B2E968
		private void AddSneakEvent()
		{
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
		}

		// Token: 0x0602F371 RID: 193393 RVA: 0x00B30786 File Offset: 0x00B2E986
		private void RemoveSneakEvent()
		{
			if (Singleton<EventSystem>.Instance.Has<bool>(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged)))
			{
				Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
			}
		}

		// Token: 0x0602F372 RID: 193394 RVA: 0x00B307C1 File Offset: 0x00B2E9C1
		private void OnBattleStateChanged(bool isInBattleState)
		{
			this.AddOrRemoveSneakBuff(!isInBattleState);
			if (isInBattleState == this.SneakState)
			{
				return;
			}
			this.SneakState = isInBattleState;
			Singleton<EventSystem>.Instance.Emit<bool, long>(EEventName.OnSneakFoundChange, this.SneakState, 0L);
		}

		// Token: 0x0602F373 RID: 193395 RVA: 0x00B307F8 File Offset: 0x00B2E9F8
		private void AddOrRemoveSneakBuff(bool isAdd)
		{
			CharacterBuffComponent component = Global.BaseCharacter.GetEntityNoBlueprint().GetComponent<CharacterBuffComponent>();
			if (component == null || !component.Valid)
			{
				return;
			}
			if (isAdd)
			{
				component.AddBuff(70000049L, new AddBuffParam
				{
					InstigatorId = component.CreatureDataId,
					Reason = "SneakController"
				});
				return;
			}
			component.RemoveBuff(70000049L, -1, "SneakController", null, null, null);
		}

		// Token: 0x0401AE6F RID: 110191
		private bool InSneakGameplay;

		// Token: 0x0401AE70 RID: 110192
		private bool SneakState;
	}
}
