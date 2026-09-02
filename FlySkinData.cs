using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Skin;

// Token: 0x02002A27 RID: 10791
[NullableContext(1)]
[Nullable(0)]
public class FlySkinData
{
	// Token: 0x060158AA RID: 88234 RVA: 0x005F9094 File Offset: 0x005F7294
	public FlySkinData(int itemId)
	{
		this.ItemId = itemId;
		this.FlySkinConfig = ConfigBase<SkinConfig>.Instance.GetFlySkinConfig(this.ItemId).Value;
	}

	// Token: 0x060158AB RID: 88235 RVA: 0x005F90D3 File Offset: 0x005F72D3
	[NullableContext(2)]
	public ItemConfig GetItemConfig()
	{
		return ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.ItemId);
	}

	// Token: 0x060158AC RID: 88236 RVA: 0x005F90E5 File Offset: 0x005F72E5
	public int GetItemId()
	{
		return this.ItemId;
	}

	// Token: 0x060158AD RID: 88237 RVA: 0x005F90ED File Offset: 0x005F72ED
	public string GetName()
	{
		return this.GetItemConfig().Name;
	}

	// Token: 0x060158AE RID: 88238 RVA: 0x005F90FA File Offset: 0x005F72FA
	public string GetDesc()
	{
		return this.GetItemConfig().BgDescription;
	}

	// Token: 0x060158AF RID: 88239 RVA: 0x005F9107 File Offset: 0x005F7307
	public int GetQuality()
	{
		return this.GetItemConfig().QualityId;
	}

	// Token: 0x060158B0 RID: 88240 RVA: 0x005F9114 File Offset: 0x005F7314
	public bool IsLocked()
	{
		return this.IsLock;
	}

	// Token: 0x060158B1 RID: 88241 RVA: 0x005F911C File Offset: 0x005F731C
	public void UnlockSkin()
	{
		this.IsLock = false;
	}

	// Token: 0x060158B2 RID: 88242 RVA: 0x005F9125 File Offset: 0x005F7325
	public int GetItemCount()
	{
		return (!this.IsLocked()) ? 1 : 0;
	}

	// Token: 0x060158B3 RID: 88243 RVA: 0x005F9130 File Offset: 0x005F7330
	public FlySkinConfig GetFlySkinConfig()
	{
		return this.FlySkinConfig;
	}

	// Token: 0x060158B4 RID: 88244 RVA: 0x005F9138 File Offset: 0x005F7338
	public int GetUiMeshId()
	{
		return this.FlySkinConfig.ModelId;
	}

	// Token: 0x060158B5 RID: 88245 RVA: 0x005F9154 File Offset: 0x005F7354
	public string GetTitleName()
	{
		return this.GetFlySkinConfig().Name;
	}

	// Token: 0x060158B6 RID: 88246 RVA: 0x005F9170 File Offset: 0x005F7370
	public string GetSubTitle()
	{
		return this.GetFlySkinConfig().TypeDescription;
	}

	// Token: 0x060158B7 RID: 88247 RVA: 0x005F918C File Offset: 0x005F738C
	public int GetSkinGrade()
	{
		return this.GetFlySkinConfig().SkinGrade;
	}

	// Token: 0x060158B8 RID: 88248 RVA: 0x005F91A8 File Offset: 0x005F73A8
	public string GetPreviewTextureInPayShop()
	{
		return this.GetFlySkinConfig().PreviewTextureInPayShop;
	}

	// Token: 0x060158B9 RID: 88249 RVA: 0x005F91C4 File Offset: 0x005F73C4
	public string GetPreviewTextureInBuyView()
	{
		return this.GetFlySkinConfig().PreviewTextureInBuyView;
	}

	// Token: 0x060158BA RID: 88250 RVA: 0x005F91E0 File Offset: 0x005F73E0
	public string GetPreviewTextureInPop()
	{
		return this.GetFlySkinConfig().PreviewTextureInPop;
	}

	// Token: 0x060158BB RID: 88251 RVA: 0x005F91FC File Offset: 0x005F73FC
	public string GetBuyPreviewQualityBgPath()
	{
		return ConfigQualityInfoById.GetConfig(this.GetQuality(), true).Value.RoleSkinQualityBg;
	}

	// Token: 0x060158BC RID: 88252 RVA: 0x005F9228 File Offset: 0x005F7428
	public string GetObtainFrameColor1()
	{
		return this.GetFlySkinConfig().SkinObtainColor1;
	}

	// Token: 0x060158BD RID: 88253 RVA: 0x005F9244 File Offset: 0x005F7444
	public string GetObtainFrameColor2()
	{
		return this.GetFlySkinConfig().SkinObtainColor2;
	}

	// Token: 0x060158BE RID: 88254 RVA: 0x005F9260 File Offset: 0x005F7460
	public string GetTextureInSkinObtainView()
	{
		return this.GetFlySkinConfig().SkinObtainImage;
	}

	// Token: 0x060158BF RID: 88255 RVA: 0x005F927B File Offset: 0x005F747B
	public bool GetHasNewFlag()
	{
		return ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.RoleSkinRedDot, this.GetItemId());
	}

	// Token: 0x0400A5E8 RID: 42472
	public readonly int ItemId;

	// Token: 0x0400A5E9 RID: 42473
	private readonly FlySkinConfig FlySkinConfig;

	// Token: 0x0400A5EA RID: 42474
	private bool IsLock = true;
}
