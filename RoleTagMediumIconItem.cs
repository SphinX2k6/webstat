using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020028D8 RID: 10456
public class RoleTagMediumIconItem : GridProxyAbstract<int>
{
	// Token: 0x06014C53 RID: 85075 RVA: 0x005C1BFC File Offset: 0x005BFDFC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUISprite))
		};
	}

	// Token: 0x06014C54 RID: 85076 RVA: 0x005C1C58 File Offset: 0x005BFE58
	public override void Refresh(int tagId, bool isSelected, int gridIndex)
	{
		RoleTag? roleTagConfig = ConfigBase<RoleConfig>.Instance.GetRoleTagConfig(tagId);
		if (roleTagConfig == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.BB;
			string message = "RoleTagMediumIconItem无效tagId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TagId", tagId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		UUISprite sprite = base.GetSprite(2);
		UUIText text = base.GetText(1);
		UUISprite sprite2 = sprite;
		if (sprite2 != null)
		{
			sprite2.SetUIActive(false);
		}
		this.SetSpriteByPath(roleTagConfig.Value.TagIcon, sprite, false, null, delegate(bool _)
		{
			sprite.SetUIActive(true);
		});
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, roleTagConfig.Value.TagName, Array.Empty<object>());
		FColor color = FColor.FromHex(roleTagConfig.Value.TagNameColor);
		base.GetSprite(0).SetColor(color);
		sprite.SetColor(color);
		text.SetColor(color);
	}

	// Token: 0x02008C33 RID: 35891
	private enum EComponent
	{
		// Token: 0x0402F3A2 RID: 193442
		TagBg,
		// Token: 0x0402F3A3 RID: 193443
		TagName,
		// Token: 0x0402F3A4 RID: 193444
		TagIcon
	}
}
