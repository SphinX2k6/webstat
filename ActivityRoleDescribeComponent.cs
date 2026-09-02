using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020015F9 RID: 5625
public class ActivityRoleDescribeComponent : UiPanelBase
{
	// Token: 0x06009E88 RID: 40584 RVA: 0x00297B94 File Offset: 0x00295D94
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009E89 RID: 40585 RVA: 0x00297C84 File Offset: 0x00295E84
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.LevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		this.StarLayout = new SimpleGenericLayout(base.GetHorizontalLayout(2));
		UUITexture texture = base.GetTexture(3);
		if (texture != null)
		{
			texture.SetUIActive(true);
		}
		UUISprite sprite = base.GetSprite(5);
		if (sprite != null)
		{
			sprite.SetUIActive(false);
		}
		base.GetItem(1).SetUIActive(false);
	}

	// Token: 0x06009E8A RID: 40586 RVA: 0x00297D04 File Offset: 0x00295F04
	public void Update(int roleId)
	{
		this.RoleId = roleId;
		RoleInfo? roleInfoById = ConfigBase<GachaConfig>.Instance.GetRoleInfoById(this.RoleId);
		if (roleInfoById == null)
		{
			return;
		}
		base.GetText(0).ShowTextNew(roleInfoById.Value.Name);
		ElementInfo? elementConfig = ConfigBase<CommonConfig>.Instance.GetElementConfig(roleInfoById.Value.ElementId);
		UUITexture texture = base.GetTexture(3);
		UUISprite sprite = base.GetSprite(4);
		base.SetTextureByPath(elementConfig.Value.Icon, texture, null, null);
		this.SetSpriteByPath(elementConfig.Value.GachaElementBgSpritePath, sprite, false, null, null);
		this.UpdateQuality(roleInfoById.Value.QualityId);
	}

	// Token: 0x06009E8B RID: 40587 RVA: 0x00297DD5 File Offset: 0x00295FD5
	private void UpdateQuality(int quality)
	{
		this.StarLayout.RebuildLayout(quality);
	}

	// Token: 0x040048EA RID: 18666
	private int RoleId;

	// Token: 0x040048EB RID: 18667
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040048EC RID: 18668
	[Nullable(2)]
	private SimpleGenericLayout StarLayout;

	// Token: 0x020079B9 RID: 31161
	private class EComponent
	{
		// Token: 0x04029CC0 RID: 171200
		public const int RoleNameText = 0;

		// Token: 0x04029CC1 RID: 171201
		public const int UpItem = 1;

		// Token: 0x04029CC2 RID: 171202
		public const int StarLayout = 2;

		// Token: 0x04029CC3 RID: 171203
		public const int AttrTexture = 3;

		// Token: 0x04029CC4 RID: 171204
		public const int AttrBgSprite = 4;

		// Token: 0x04029CC5 RID: 171205
		public const int AttrSprite = 5;
	}
}
