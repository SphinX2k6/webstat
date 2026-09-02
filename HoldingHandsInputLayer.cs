using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Structures;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;

// Token: 0x020030A3 RID: 12451
[NullableContext(2)]
[Nullable(0)]
public class HoldingHandsInputLayer : InputLayer
{
	// Token: 0x06019A85 RID: 105093 RVA: 0x00776115 File Offset: 0x00774315
	[NullableContext(1)]
	public void Init(CharacterHoldingHandsComponent holdingComp)
	{
		this.HoldingHandsComp = holdingComp;
		this.LongHoldLeaveTime = holdingComp.Params.LongPressDuration;
	}

	// Token: 0x06019A86 RID: 105094 RVA: 0x0077612F File Offset: 0x0077432F
	public override void Clear()
	{
		this.HoldingHandsComp = null;
		this.HoldingActionMap.Clear();
	}

	// Token: 0x06019A87 RID: 105095 RVA: 0x00776143 File Offset: 0x00774343
	public override EInputLayer GetLayerType()
	{
		return EInputLayer.HoldingHands;
	}

	// Token: 0x06019A88 RID: 105096 RVA: 0x00776147 File Offset: 0x00774347
	public bool GetIsHoldingHands()
	{
		return this.HoldingHandsComp.GetRoleState() > EHoldingHandsRoleState.None;
	}

	// Token: 0x06019A89 RID: 105097 RVA: 0x00776157 File Offset: 0x00774357
	public override SInputCommand HandlePress(EInputAction action, float time)
	{
		if (action == 6)
		{
			return InputLayer.GetSwallowCommand();
		}
		return null;
	}

	// Token: 0x06019A8A RID: 105098 RVA: 0x0077616C File Offset: 0x0077436C
	public override SInputCommand HandleHold(EInputAction action, float time)
	{
		if (action == 6)
		{
			if (this.GetIsHoldingHands())
			{
				if (!this.HoldingActionMap.ContainsKey(action))
				{
					Singleton<EventSystem>.Instance.Emit<EInputAction>(EEventName.SkillLongPressStart, action);
				}
				if ((double)time > this.LongHoldLeaveTime)
				{
					CharacterHoldingHandsComponent holdingHandsComp = this.HoldingHandsComp;
					if (holdingHandsComp != null)
					{
						holdingHandsComp.ReleaseAllHands("长按技能键", true, true);
					}
					Singleton<EventSystem>.Instance.Emit<EInputAction>(EEventName.SkillLongPressEnd, action);
				}
				this.HoldingActionMap[action] = true;
			}
			return InputLayer.GetSwallowCommand();
		}
		return null;
	}

	// Token: 0x06019A8B RID: 105099 RVA: 0x007761F0 File Offset: 0x007743F0
	public override SInputCommand HandleRelease(EInputAction action, float time)
	{
		this.HoldingActionMap.Remove(action);
		if (action == 6)
		{
			Singleton<EventSystem>.Instance.Emit<EInputAction>(EEventName.SkillLongPressEnd, action);
			return InputLayer.GetSwallowCommand();
		}
		return null;
	}

	// Token: 0x06019A8C RID: 105100 RVA: 0x00776220 File Offset: 0x00774420
	public bool IsHoldingAction(EInputAction action)
	{
		return this.HoldingActionMap.ContainsKey(action);
	}

	// Token: 0x0400CC52 RID: 52306
	public double LongHoldLeaveTime = 1.0;

	// Token: 0x0400CC53 RID: 52307
	private CharacterHoldingHandsComponent HoldingHandsComp;

	// Token: 0x0400CC54 RID: 52308
	[Nullable(1)]
	private readonly Dictionary<EInputAction, bool> HoldingActionMap = new Dictionary<EInputAction, bool>();
}
