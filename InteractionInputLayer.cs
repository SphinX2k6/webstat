using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Structures;
using CSharpScript.Game.Input;

// Token: 0x020030A4 RID: 12452
[NullableContext(2)]
[Nullable(0)]
public class InteractionInputLayer : InputLayer
{
	// Token: 0x06019A8E RID: 105102 RVA: 0x00776250 File Offset: 0x00774450
	[NullableContext(1)]
	public void Init(Func<EInputAction?> getTriggerAction, Action onPress, Action onRelease)
	{
		this.GetTriggerAction = getTriggerAction;
		this.OnPress = onPress;
		this.OnRelease = onRelease;
	}

	// Token: 0x06019A8F RID: 105103 RVA: 0x00776267 File Offset: 0x00774467
	public override void Clear()
	{
		this.GetTriggerAction = null;
		this.OnPress = null;
		this.OnRelease = null;
		this.PressedAction = EInputAction.None;
	}

	// Token: 0x06019A90 RID: 105104 RVA: 0x00776289 File Offset: 0x00774489
	public override EInputLayer GetLayerType()
	{
		return EInputLayer.Interaction;
	}

	// Token: 0x06019A91 RID: 105105 RVA: 0x0077628C File Offset: 0x0077448C
	private bool Matches(EInputAction action)
	{
		if (action == EInputAction.None)
		{
			return false;
		}
		Func<EInputAction?> getTriggerAction = this.GetTriggerAction;
		return getTriggerAction != null && getTriggerAction() == action;
	}

	// Token: 0x06019A92 RID: 105106 RVA: 0x007762D4 File Offset: 0x007744D4
	public override SInputCommand HandlePress(EInputAction action, float time)
	{
		if (this.Matches(action))
		{
			this.PressedAction = action;
			Action onPress = this.OnPress;
			if (onPress != null)
			{
				onPress();
			}
			return InputLayer.GetSwallowCommand();
		}
		return null;
	}

	// Token: 0x06019A93 RID: 105107 RVA: 0x00776300 File Offset: 0x00774500
	public override SInputCommand HandleRelease(EInputAction action, float time)
	{
		if (this.PressedAction != EInputAction.None && action == this.PressedAction)
		{
			this.PressedAction = EInputAction.None;
			Action onRelease = this.OnRelease;
			if (onRelease != null)
			{
				onRelease();
			}
			return InputLayer.GetSwallowCommand();
		}
		return null;
	}

	// Token: 0x06019A94 RID: 105108 RVA: 0x00776350 File Offset: 0x00774550
	public override SInputCommand HandleHold(EInputAction action, float time)
	{
		if (this.PressedAction != EInputAction.None && action == this.PressedAction)
		{
			return InputLayer.GetSwallowCommand();
		}
		return null;
	}

	// Token: 0x0400CC55 RID: 52309
	private Func<EInputAction?> GetTriggerAction;

	// Token: 0x0400CC56 RID: 52310
	private Action OnPress;

	// Token: 0x0400CC57 RID: 52311
	private Action OnRelease;

	// Token: 0x0400CC58 RID: 52312
	private EInputAction PressedAction = EInputAction.None;
}
