using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Item
{
	// Token: 0x02005B77 RID: 23415
	[NullableContext(2)]
	[Nullable(0)]
	public class RoleDescribeComponent : UiPanelBase
	{
		// Token: 0x0603B331 RID: 242481 RVA: 0x00EFAFBC File Offset: 0x00EF91BC
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

		// Token: 0x0603B332 RID: 242482 RVA: 0x00EFB0AC File Offset: 0x00EF92AC
		protected override void OnStart()
		{
			this.LevelSequencePlayerInstance = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayerInstance.PlayLevelSequenceByName("Start", false, null, false);
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

		// Token: 0x0603B333 RID: 242483 RVA: 0x00EFB12C File Offset: 0x00EF932C
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

		// Token: 0x0603B334 RID: 242484 RVA: 0x00EFB1FD File Offset: 0x00EF93FD
		private void UpdateQuality(int quality)
		{
			this.StarLayout.RebuildLayout(quality);
		}

		// Token: 0x040215FB RID: 136699
		private int RoleId;

		// Token: 0x040215FC RID: 136700
		private LevelSequencePlayer LevelSequencePlayerInstance;

		// Token: 0x040215FD RID: 136701
		private SimpleGenericLayout StarLayout;
	}
}
