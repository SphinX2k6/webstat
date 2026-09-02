using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Skin;
using UnrealEngine;

// Token: 0x020019F0 RID: 6640
[NullableContext(1)]
[Nullable(0)]
public class MediumItemGridVisionRoleHeadComponent : MediumItemGridComponent
{
	// Token: 0x0600BE2C RID: 48684 RVA: 0x00325AA4 File Offset: 0x00323CA4
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

	// Token: 0x0600BE2D RID: 48685 RVA: 0x00325B2E File Offset: 0x00323D2E
	protected override string GetResourceId()
	{
		return "UiItem_ItemRole";
	}

	// Token: 0x0600BE2E RID: 48686 RVA: 0x00325B38 File Offset: 0x00323D38
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		VisionRoleHeadInfo visionRoleHeadInfo = data as VisionRoleHeadInfo;
		if (visionRoleHeadInfo == null)
		{
			return;
		}
		int? roleConfigId = visionRoleHeadInfo.RoleConfigId;
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
		UUITexture roleHeadTexture = base.GetTexture(0);
		int roleSkinId = roleDataById.GetRoleSkinId();
		RoleSkin? roleSkinConfig = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(roleSkinId);
		string text = (roleSkinConfig != null) ? roleSkinConfig.GetValueOrDefault().Card : null;
		if (string.IsNullOrEmpty(text))
		{
			this.SetActive(false);
			return;
		}
		UUITexture roleHeadTexture3 = roleHeadTexture;
		if (roleHeadTexture3 != null)
		{
			roleHeadTexture3.SetUIActive(false);
		}
		base.SetRoleSkinIcon(text, roleHeadTexture, roleSkinId, null, delegate(bool _)
		{
			UUITexture roleHeadTexture2 = roleHeadTexture;
			if (roleHeadTexture2 == null)
			{
				return;
			}
			roleHeadTexture2.SetUIActive(true);
		});
		this.RefreshSpriteBg(visionRoleHeadInfo);
		this.RefreshLightBg(visionRoleHeadInfo);
		this.SetActive(true);
	}

	// Token: 0x0600BE2F RID: 48687 RVA: 0x00325C2C File Offset: 0x00323E2C
	private void RefreshSpriteBg(VisionRoleHeadInfo roleHeadInfo)
	{
		int? visionUniqueId = roleHeadInfo.VisionUniqueId;
		if (ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(visionUniqueId.Value) != null)
		{
			string path;
			if (ModelBase<PhantomBattleModel>.Instance.CheckPhantomIsMain(visionUniqueId.Value))
			{
				path = ConfigBase<PhantomBattleConfig>.Instance.GetVisionHeadSprBgB();
			}
			else
			{
				path = ConfigBase<PhantomBattleConfig>.Instance.GetVisionHeadSprBgA();
			}
			this.SetSpriteByPath(path, base.GetSprite(2), false, null, null);
		}
		UUISprite sprite = base.GetSprite(2);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(true);
	}

	// Token: 0x0600BE30 RID: 48688 RVA: 0x00325CAC File Offset: 0x00323EAC
	private void RefreshLightBg(VisionRoleHeadInfo roleHeadInfo)
	{
		int? visionUniqueId = roleHeadInfo.VisionUniqueId;
		if (ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(visionUniqueId.Value) != null)
		{
			string path;
			if (ModelBase<PhantomBattleModel>.Instance.CheckPhantomIsMain(visionUniqueId.Value))
			{
				path = ConfigBase<PhantomBattleConfig>.Instance.GetVisionHeadLightBgB();
			}
			else
			{
				path = ConfigBase<PhantomBattleConfig>.Instance.GetVisionHeadLightBgA();
			}
			this.SetSpriteByPath(path, base.GetSprite(1), false, null, null);
		}
		UUISprite sprite = base.GetSprite(1);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(true);
	}

	// Token: 0x02007CDE RID: 31966
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402A9A0 RID: 174496
		public const int RoleHeadTexture = 0;

		// Token: 0x0402A9A1 RID: 174497
		public const int LightSprite = 1;

		// Token: 0x0402A9A2 RID: 174498
		public const int SpriteBg = 2;
	}
}
