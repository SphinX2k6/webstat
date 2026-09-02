using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020028D6 RID: 10454
public class RoleTagDetailItem : GridProxyAbstract<int>
{
	// Token: 0x06014C4B RID: 85067 RVA: 0x005C190C File Offset: 0x005BFB0C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x06014C4C RID: 85068 RVA: 0x005C1994 File Offset: 0x005BFB94
	public override void Refresh(int tagId, bool isSelected, int gridIndex)
	{
		RoleTag? roleTagConfig = ConfigBase<RoleConfig>.Instance.GetRoleTagConfig(tagId);
		if (roleTagConfig == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.BB;
			string message = "RoleTagSmallIconItem无效tagId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TagId", tagId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		base.GetItem(0).SetUIActive(gridIndex % 2 == 0);
		base.GetItem(4).SetUIActive(gridIndex % 2 == 1);
		UUISprite sprite = base.GetSprite(1);
		this.SetSpriteByPath(roleTagConfig.Value.TagIcon, sprite, false, null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), roleTagConfig.Value.TagName, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), roleTagConfig.Value.TagDesc, Array.Empty<object>());
	}

	// Token: 0x02008C31 RID: 35889
	private enum EComponent
	{
		// Token: 0x0402F397 RID: 193431
		BackGroundItem,
		// Token: 0x0402F398 RID: 193432
		TagIcon,
		// Token: 0x0402F399 RID: 193433
		TagName,
		// Token: 0x0402F39A RID: 193434
		TagDesc,
		// Token: 0x0402F39B RID: 193435
		BackGroundItem2
	}
}
