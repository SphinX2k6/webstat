using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Structures;
using CSharpScript.Game.Input;

// Token: 0x0200309F RID: 12447
public class AceAntiCheatInputLayer : InputLayer
{
	// Token: 0x06019A57 RID: 105047 RVA: 0x00774B2A File Offset: 0x00772D2A
	public override EInputLayer GetLayerType()
	{
		return EInputLayer.AceAntiCheat;
	}

	// Token: 0x06019A58 RID: 105048 RVA: 0x00774B2E File Offset: 0x00772D2E
	[NullableContext(2)]
	public override SInputCommand HandlePress(EInputAction action, float time)
	{
		ControllerBase<AceAntiCheatController>.Instance.HandlePress(action, time);
		return null;
	}
}
