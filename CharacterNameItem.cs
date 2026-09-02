using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020013BC RID: 5052
[Nullable(new byte[]
{
	0,
	1
})]
public class CharacterNameItem : GridProxyAbstract<CharacterData>
{
	// Token: 0x06008B70 RID: 35696 RVA: 0x0024B814 File Offset: 0x00249A14
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06008B71 RID: 35697 RVA: 0x0024B86E File Offset: 0x00249A6E
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x06008B72 RID: 35698 RVA: 0x0024B884 File Offset: 0x00249A84
	[NullableContext(1)]
	public override void Refresh(CharacterData data, bool isSelected, int gridIndex)
	{
		Character characterConfig = ConfigBase<BusinessConfig>.Instance.GetCharacterConfig(data.Id);
		if (data.UseScoreName)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), characterConfig.ScoreName, Array.Empty<object>());
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), characterConfig.Name, Array.Empty<object>());
		}
		base.GetSprite(1).SetColor(FColor.FromHex(characterConfig.Color));
	}

	// Token: 0x06008B73 RID: 35699 RVA: 0x0024B8FE File Offset: 0x00249AFE
	public void SetGoodItemActive(bool value)
	{
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(value);
	}

	// Token: 0x02007787 RID: 30599
	private static class EComponentDefine
	{
		// Token: 0x04029257 RID: 168535
		public const int Name = 0;

		// Token: 0x04029258 RID: 168536
		public const int Sprite = 1;

		// Token: 0x04029259 RID: 168537
		public const int GoodItem = 2;
	}
}
