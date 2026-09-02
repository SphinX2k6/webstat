using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020010CB RID: 4299
public class GolemHackingCodeIconItem : GridProxyAbstract<EGolemHackingBarState>
{
	// Token: 0x06006FE7 RID: 28647 RVA: 0x001D25F4 File Offset: 0x001D07F4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06006FE8 RID: 28648 RVA: 0x001D263C File Offset: 0x001D083C
	public override void Refresh(EGolemHackingBarState data, bool isSelected, int gridIndex)
	{
		string text;
		string resourceId = GolemHackingCodeIconItem.ResourceIdMap.TryGetValue(gridIndex, out text) ? text : "";
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		this.SetSpriteByPath(resourcePath, base.GetSprite(0), false, null, null);
		this.UpdateState(data);
	}

	// Token: 0x06006FE9 RID: 28649 RVA: 0x001D2690 File Offset: 0x001D0890
	public void UpdateState(EGolemHackingBarState state)
	{
		if (state == EGolemHackingBarState.Default)
		{
			UUISprite sprite = base.GetSprite(0);
			if (sprite == null)
			{
				return;
			}
			sprite.SetColor(this.DefaultColor);
			return;
		}
		else if (state == EGolemHackingBarState.Success)
		{
			UUISprite sprite2 = base.GetSprite(0);
			if (sprite2 == null)
			{
				return;
			}
			sprite2.SetColor(this.SuccessColor);
			return;
		}
		else
		{
			UUISprite sprite3 = base.GetSprite(0);
			if (sprite3 == null)
			{
				return;
			}
			sprite3.SetColor(this.FailColor);
			return;
		}
	}

	// Token: 0x040035D9 RID: 13785
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly Dictionary<int, string> ResourceIdMap = new Dictionary<int, string>
	{
		{
			0,
			"SP_GolemHackingArrowLevel1"
		},
		{
			1,
			"SP_GolemHackingArrowLevel2"
		},
		{
			2,
			"SP_GolemHackingArrowLevel3"
		},
		{
			3,
			"SP_GolemHackingArrowLevel4"
		}
	};

	// Token: 0x040035DA RID: 13786
	private readonly FColor DefaultColor = FColor.FromHex("DFFF5E");

	// Token: 0x040035DB RID: 13787
	private readonly FColor SuccessColor = FColor.FromHex("0B4F2E");

	// Token: 0x040035DC RID: 13788
	private readonly FColor FailColor = FColor.FromHex("9C1414");

	// Token: 0x0200745A RID: 29786
	private enum EDefine
	{
		// Token: 0x04028383 RID: 164739
		Sprite
	}
}
