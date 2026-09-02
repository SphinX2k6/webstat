using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Structures;
using CSharpScript.Game.Input;

// Token: 0x02000F78 RID: 3960
[NullableContext(2)]
[Nullable(0)]
public class PotatoInputLayer : InputLayer
{
	// Token: 0x06006472 RID: 25714 RVA: 0x00192DA7 File Offset: 0x00190FA7
	public override EInputLayer GetLayerType()
	{
		return EInputLayer.Potato;
	}

	// Token: 0x06006473 RID: 25715 RVA: 0x00192DAB File Offset: 0x00190FAB
	public override SInputCommand HandlePress(EInputAction action, float time)
	{
		if (5 == action)
		{
			this.ExecSkillDodge();
		}
		return InputLayer.GetSwallowCommand();
	}

	// Token: 0x06006474 RID: 25716 RVA: 0x00192DC1 File Offset: 0x00190FC1
	public override SInputCommand HandleRelease(EInputAction action, float time)
	{
		return InputLayer.GetSwallowCommand();
	}

	// Token: 0x06006475 RID: 25717 RVA: 0x00192DC8 File Offset: 0x00190FC8
	public override SInputCommand HandleHold(EInputAction action, float time)
	{
		return InputLayer.GetSwallowCommand();
	}

	// Token: 0x06006476 RID: 25718 RVA: 0x00192DD0 File Offset: 0x00190FD0
	private void ExecSkillDodge()
	{
		KscSubControllerBase curSubController = ControllerBase<KuroSimpleCombatController>.Instance.CurSubController;
		if (curSubController == null || !(curSubController is PotatoSubController))
		{
			return;
		}
		((PotatoSubController)curSubController).ExecSkillDodge();
	}
}
