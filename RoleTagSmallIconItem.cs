using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020028D9 RID: 10457
public class RoleTagSmallIconItem : GridProxyAbstract<int>
{
	// Token: 0x06014C56 RID: 85078 RVA: 0x005C1D65 File Offset: 0x005BFF65
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite))
		};
	}

	// Token: 0x06014C57 RID: 85079 RVA: 0x005C1D88 File Offset: 0x005BFF88
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
		UUISprite sprite = base.GetSprite(0);
		this.SetActive(false);
		this.SetSpriteByPath(roleTagConfig.Value.TagIcon, sprite, false, null, delegate(bool _)
		{
			this.SetActive(true);
		});
	}

	// Token: 0x02008C35 RID: 35893
	private enum EComponent
	{
		// Token: 0x0402F3A7 RID: 193447
		TagIcon
	}
}
