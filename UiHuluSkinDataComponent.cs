using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Utils;

// Token: 0x02002C9B RID: 11419
[NullableContext(1)]
[Nullable(0)]
public class UiHuluSkinDataComponent : UiModelComponentBase
{
	// Token: 0x06016EA7 RID: 93863 RVA: 0x0065A6B3 File Offset: 0x006588B3
	public void RefreshCurrentSkinData(int roleId)
	{
		if (ModelBase<RoleModel>.Instance.IsMainRole(roleId))
		{
			this.SetSkinId(roleId, ModelBase<CalabashSkinModel>.Instance.GetCurrentEquipSkinId());
			return;
		}
		this.SetSkinId(roleId, 0);
	}

	// Token: 0x06016EA8 RID: 93864 RVA: 0x0065A6DC File Offset: 0x006588DC
	public void SetSkinId(int roleId, int skinId)
	{
		this.SkinIdInternal = skinId;
		if (this.SkinIdInternal != 0)
		{
			this.ModelIdInternal = ConfigBase<SkinConfig>.Instance.GetCalabashSkinConfig(this.SkinIdInternal).ModelId;
			return;
		}
		this.ModelIdInternal = CharacterUtils.GetHuluModelId(ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId).Value.PartyId);
	}

	// Token: 0x17001E2F RID: 7727
	// (get) Token: 0x06016EA9 RID: 93865 RVA: 0x0065A73D File Offset: 0x0065893D
	public int ModelId
	{
		get
		{
			return this.ModelIdInternal;
		}
	}

	// Token: 0x17001E30 RID: 7728
	// (get) Token: 0x06016EAA RID: 93866 RVA: 0x0065A748 File Offset: 0x00658948
	public int TransformId
	{
		get
		{
			if (this.SkinIdInternal != 0)
			{
				return ConfigBase<SkinConfig>.Instance.GetCalabashSkinConfig(this.SkinIdInternal).TransformId;
			}
			return this.ModelIdInternal;
		}
	}

	// Token: 0x17001E31 RID: 7729
	// (get) Token: 0x06016EAB RID: 93867 RVA: 0x0065A77C File Offset: 0x0065897C
	public string EffectPath
	{
		get
		{
			if (this.SkinIdInternal != 0)
			{
				return ConfigBase<SkinConfig>.Instance.GetCalabashSkinConfig(this.SkinIdInternal).SwitchEffect;
			}
			return EffectUtil.GetEffectPath("CalabashSwitchEffect");
		}
	}

	// Token: 0x0400B0BE RID: 45246
	private int ModelIdInternal;

	// Token: 0x0400B0BF RID: 45247
	private int SkinIdInternal;
}
