using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Skin;
using UnrealEngine;

// Token: 0x020019DC RID: 6620
public class MediumItemGridRoleHeadComponent : MediumItemGridComponent
{
	// Token: 0x0600BDDC RID: 48604 RVA: 0x00324BD0 File Offset: 0x00322DD0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BDDD RID: 48605 RVA: 0x00324C5A File Offset: 0x00322E5A
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemRole";
	}

	// Token: 0x0600BDDE RID: 48606 RVA: 0x00324C64 File Offset: 0x00322E64
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		RoleHeadInfo roleHeadInfo = data as RoleHeadInfo;
		if (roleHeadInfo == null)
		{
			return;
		}
		UUITexture roleHeadTexture = base.GetTexture(0);
		if (!string.IsNullOrEmpty(roleHeadInfo.RoleIconPath))
		{
			UUITexture roleHeadTexture4 = roleHeadTexture;
			if (roleHeadTexture4 != null)
			{
				roleHeadTexture4.SetUIActive(false);
			}
			base.SetTextureByPath(roleHeadInfo.RoleIconPath, roleHeadTexture, null, delegate(bool _)
			{
				UUITexture roleHeadTexture3 = roleHeadTexture;
				if (roleHeadTexture3 == null)
				{
					return;
				}
				roleHeadTexture3.SetUIActive(true);
			});
			UUISprite sprite = base.GetSprite(1);
			if (sprite != null)
			{
				sprite.SetUIActive(roleHeadInfo.IsLightVisible.GetValueOrDefault());
			}
			this.SetActive(true);
			return;
		}
		int? roleConfigId = roleHeadInfo.RoleConfigId;
		if (roleConfigId == null)
		{
			this.SetActive(false);
			return;
		}
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleConfigId.Value, true);
		if (roleDataById == null)
		{
			this.SetActive(false);
			return;
		}
		int roleSkinId = roleDataById.GetRoleSkinId();
		RoleSkin? roleSkinConfig = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(roleSkinId);
		string text = (roleSkinConfig != null) ? roleSkinConfig.GetValueOrDefault().Card : null;
		if (string.IsNullOrEmpty(text))
		{
			this.SetActive(false);
			return;
		}
		UUITexture roleHeadTexture2 = roleHeadTexture;
		if (roleHeadTexture2 != null)
		{
			roleHeadTexture2.SetUIActive(false);
		}
		base.SetRoleSkinIcon(text, roleHeadTexture, roleSkinId, null, delegate(bool _)
		{
			UUITexture roleHeadTexture3 = roleHeadTexture;
			if (roleHeadTexture3 == null)
			{
				return;
			}
			roleHeadTexture3.SetUIActive(true);
		});
		UUISprite sprite2 = base.GetSprite(1);
		if (sprite2 != null)
		{
			sprite2.SetUIActive(roleHeadInfo.IsLightVisible.GetValueOrDefault());
		}
		this.SetActive(true);
	}

	// Token: 0x02007CCE RID: 31950
	private class EChildType
	{
		// Token: 0x0402A987 RID: 174471
		public const int RoleHeadTexture = 0;

		// Token: 0x0402A988 RID: 174472
		public const int LightSprite = 1;

		// Token: 0x0402A989 RID: 174473
		public const int SpriteBg = 2;
	}
}
