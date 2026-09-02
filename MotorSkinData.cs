using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Skin;

// Token: 0x02002A29 RID: 10793
[NullableContext(1)]
[Nullable(0)]
public class MotorSkinData
{
	// Token: 0x060158D0 RID: 88272 RVA: 0x005F940C File Offset: 0x005F760C
	public MotorSkinData(int itemId)
	{
		this.ItemId = itemId;
		this.MotorSkinShow = ConfigBase<SkinConfig>.Instance.GetMotorSkinShowConfig(this.ItemId);
	}

	// Token: 0x060158D1 RID: 88273 RVA: 0x005F9434 File Offset: 0x005F7634
	public string GetName()
	{
		return ((this.MotorSkinShow != null) ? this.MotorSkinShow.GetValueOrDefault().Name : null) ?? "";
	}

	// Token: 0x060158D2 RID: 88274 RVA: 0x005F9469 File Offset: 0x005F7669
	public int GetItemId()
	{
		return this.ItemId;
	}

	// Token: 0x060158D3 RID: 88275 RVA: 0x005F9471 File Offset: 0x005F7671
	public int GetQualityA()
	{
		return 1;
	}

	// Token: 0x060158D4 RID: 88276 RVA: 0x005F9474 File Offset: 0x005F7674
	public int GetQualityB()
	{
		return 1;
	}

	// Token: 0x060158D5 RID: 88277 RVA: 0x005F9477 File Offset: 0x005F7677
	public MotorSkinShow? GetMotorSkinShow()
	{
		return this.MotorSkinShow;
	}

	// Token: 0x060158D6 RID: 88278 RVA: 0x005F9480 File Offset: 0x005F7680
	public string GetPreviewTextureInPayShop()
	{
		return ((this.MotorSkinShow != null) ? this.MotorSkinShow.GetValueOrDefault().Icon : null) ?? "";
	}

	// Token: 0x060158D7 RID: 88279 RVA: 0x005F94B5 File Offset: 0x005F76B5
	public bool GetHasNewFlag()
	{
		return ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.RoleSkinRedDot, this.GetItemId());
	}

	// Token: 0x0400A5EF RID: 42479
	public readonly int ItemId;

	// Token: 0x0400A5F0 RID: 42480
	private readonly MotorSkinShow? MotorSkinShow;
}
