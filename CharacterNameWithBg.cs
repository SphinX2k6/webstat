using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020013BD RID: 5053
public class CharacterNameWithBg : GridProxyAbstract<int>
{
	// Token: 0x06008B75 RID: 35701 RVA: 0x0024B91A File Offset: 0x00249B1A
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x06008B76 RID: 35702 RVA: 0x0024B954 File Offset: 0x00249B54
	public override void Refresh(int characterId, bool isSelected, int gridIndex)
	{
		Character characterConfig = ConfigBase<BusinessConfig>.Instance.GetCharacterConfig(characterId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), characterConfig.Name, Array.Empty<object>());
		base.GetSprite(0).SetColor(FColor.FromHex(characterConfig.Color));
	}

	// Token: 0x02007788 RID: 30600
	private static class EComponentDefine
	{
		// Token: 0x0402925A RID: 168538
		public const int Sprite = 0;

		// Token: 0x0402925B RID: 168539
		public const int Name = 1;
	}
}
