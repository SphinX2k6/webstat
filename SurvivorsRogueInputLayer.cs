using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Structures;
using CSharpScript.Game.Input;

// Token: 0x02000F7B RID: 3963
[NullableContext(2)]
[Nullable(0)]
public class SurvivorsRogueInputLayer : InputLayer
{
	// Token: 0x06006483 RID: 25731 RVA: 0x001930BD File Offset: 0x001912BD
	public override EInputLayer GetLayerType()
	{
		return EInputLayer.SurvivorsRogue;
	}

	// Token: 0x06006484 RID: 25732 RVA: 0x001930C4 File Offset: 0x001912C4
	public override SInputCommand HandlePress(EInputAction action, float time)
	{
		switch (action)
		{
		case 3:
		case 5:
			return null;
		case 6:
			this.ExecSkillAction();
			return InputLayer.GetSwallowCommand();
		}
		return InputLayer.GetSwallowCommand();
	}

	// Token: 0x06006485 RID: 25733 RVA: 0x00193105 File Offset: 0x00191305
	public override SInputCommand HandleRelease(EInputAction action, float time)
	{
		return InputLayer.GetSwallowCommand();
	}

	// Token: 0x06006486 RID: 25734 RVA: 0x0019310C File Offset: 0x0019130C
	public override SInputCommand HandleHold(EInputAction action, float time)
	{
		return InputLayer.GetSwallowCommand();
	}

	// Token: 0x06006487 RID: 25735 RVA: 0x00193114 File Offset: 0x00191314
	private void ExecSkillAction()
	{
		KscSubControllerBase curSubController = ControllerBase<KuroSimpleCombatController>.Instance.CurSubController;
		if (curSubController == null)
		{
			return;
		}
		((SurvivorsRogueSubController)curSubController).ExecSkillAction();
	}
}
