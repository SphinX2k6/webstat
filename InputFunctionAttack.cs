using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Blueprints;
using AkiClient.Game.Aki.Character.Input.Enum;
using AkiClient.Game.Aki.Character.Input.Structures;
using CSharpScript.Game;

// Token: 0x02003090 RID: 12432
[NullableContext(1)]
[Nullable(0)]
public static class InputFunctionAttack
{
	// Token: 0x06019A14 RID: 104980 RVA: 0x00772FC4 File Offset: 0x007711C4
	[return: Nullable(2)]
	private static SInputCommand AttackFunction(float time, BP_InputComponent_C bpInputComp)
	{
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		if (baseCharacter == null)
		{
			return null;
		}
		CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
		Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
		if (entity == null)
		{
			return null;
		}
		BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
		if (component == null || !component.Valid)
		{
			return null;
		}
		bpInputComp.通用_攻击按下 = false;
		SInputCommand sinputCommand = InputFunctionCommon.CreateInputCommandFromDataTable(entity.Id, EInputAction.攻击, EInputState.Press);
		if (sinputCommand != null)
		{
			bpInputComp.通用_攻击按下 = true;
			return sinputCommand;
		}
		return null;
	}

	// Token: 0x06019A15 RID: 104981 RVA: 0x00773030 File Offset: 0x00771230
	[return: Nullable(2)]
	public static SInputCommand AttackOnPress(float time, BP_InputComponent_C bpInputComp)
	{
		return InputFunctionAttack.AttackFunction(time, bpInputComp);
	}

	// Token: 0x06019A16 RID: 104982 RVA: 0x00773039 File Offset: 0x00771239
	[return: Nullable(2)]
	public static SInputCommand AttackOnRelease(float time, BP_InputComponent_C bpInputComp)
	{
		return null;
	}
}
