using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Structures;
using CSharpScript.Game.Input;

// Token: 0x020030A6 RID: 12454
[NullableContext(2)]
[Nullable(0)]
public class OverShoulderInputLayer : InputLayer
{
	// Token: 0x06019AA0 RID: 105120 RVA: 0x007766D5 File Offset: 0x007748D5
	[NullableContext(1)]
	public void Init(Entity entity)
	{
		this.InputComp = entity.GetComponent<CharacterInputComponent>();
	}

	// Token: 0x06019AA1 RID: 105121 RVA: 0x007766E3 File Offset: 0x007748E3
	public override void Clear()
	{
		this.InputComp = null;
	}

	// Token: 0x06019AA2 RID: 105122 RVA: 0x007766EC File Offset: 0x007748EC
	public override EInputLayer GetLayerType()
	{
		return EInputLayer.OverShoulder;
	}

	// Token: 0x06019AA3 RID: 105123 RVA: 0x007766F0 File Offset: 0x007748F0
	public override SInputCommand HandlePress(EInputAction action, float time)
	{
		if (action == 5)
		{
			CharacterInputComponent inputComp = this.InputComp;
			if (inputComp != null)
			{
				inputComp.TrySwitchOverShoulderSprintMode();
			}
			return InputLayer.GetSwallowCommand();
		}
		return null;
	}

	// Token: 0x06019AA4 RID: 105124 RVA: 0x00776713 File Offset: 0x00774913
	public override SInputCommand HandleHold(EInputAction action, float time)
	{
		if (action == 5)
		{
			return InputLayer.GetSwallowCommand();
		}
		return null;
	}

	// Token: 0x06019AA5 RID: 105125 RVA: 0x00776725 File Offset: 0x00774925
	public override SInputCommand HandleRelease(EInputAction action, float time)
	{
		if (action == 5)
		{
			return InputLayer.GetSwallowCommand();
		}
		return null;
	}

	// Token: 0x0400CC5F RID: 52319
	protected CharacterInputComponent InputComp;
}
