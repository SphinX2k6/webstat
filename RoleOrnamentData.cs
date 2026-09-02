using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x0200234F RID: 9039
[NullableContext(1)]
[Nullable(0)]
public class RoleOrnamentData
{
	// Token: 0x0601144D RID: 70733 RVA: 0x004BFBDE File Offset: 0x004BDDDE
	public RoleOrnamentData(int id)
	{
		this.Id = id;
	}

	// Token: 0x0601144E RID: 70734 RVA: 0x004BFBF0 File Offset: 0x004BDDF0
	public Ornament GetOrnamentConfig()
	{
		return ConfigBase<RoleConfig>.Instance.GetOrnamentConfig(this.Id).Value;
	}

	// Token: 0x0601144F RID: 70735 RVA: 0x004BFC15 File Offset: 0x004BDE15
	public ItemConfig GetItemConfig()
	{
		return ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.Id);
	}

	// Token: 0x06011450 RID: 70736 RVA: 0x004BFC27 File Offset: 0x004BDE27
	public int GetId()
	{
		return this.Id;
	}

	// Token: 0x06011451 RID: 70737 RVA: 0x004BFC30 File Offset: 0x004BDE30
	public int[] GetRoleSkinIds()
	{
		return this.GetOrnamentConfig().RoleSkinIdsIter().ToArray<int>();
	}

	// Token: 0x06011452 RID: 70738 RVA: 0x004BFC50 File Offset: 0x004BDE50
	public int GetGroupId()
	{
		return this.GetOrnamentConfig().OrGroupId;
	}

	// Token: 0x06011453 RID: 70739 RVA: 0x004BFC6B File Offset: 0x004BDE6B
	public string GetName()
	{
		return this.GetItemConfig().Name;
	}

	// Token: 0x06011454 RID: 70740 RVA: 0x004BFC78 File Offset: 0x004BDE78
	public string GetTitleName()
	{
		return this.GetName();
	}

	// Token: 0x06011455 RID: 70741 RVA: 0x004BFC80 File Offset: 0x004BDE80
	public string GetTypeDescription()
	{
		return this.GetItemConfig().TypeDescription;
	}

	// Token: 0x06011456 RID: 70742 RVA: 0x004BFC90 File Offset: 0x004BDE90
	public string GetSubTitle()
	{
		return this.GetOrnamentConfig().ShopPreviewSubTitle;
	}

	// Token: 0x06011457 RID: 70743 RVA: 0x004BFCAB File Offset: 0x004BDEAB
	public string GetBgDescription()
	{
		return this.GetItemConfig().BgDescription ?? "";
	}

	// Token: 0x06011458 RID: 70744 RVA: 0x004BFCC1 File Offset: 0x004BDEC1
	public int GetQuality()
	{
		return this.GetItemConfig().QualityId;
	}

	// Token: 0x06011459 RID: 70745 RVA: 0x004BFCCE File Offset: 0x004BDECE
	public bool IsOwn()
	{
		return ModelBase<RoleOrnamentModel>.Instance.IsOwnOrnament(this.Id);
	}

	// Token: 0x0601145A RID: 70746 RVA: 0x004BFCE0 File Offset: 0x004BDEE0
	public int GetSortIndex()
	{
		return this.GetItemConfig().SortIndex;
	}

	// Token: 0x0601145B RID: 70747 RVA: 0x004BFCF0 File Offset: 0x004BDEF0
	public string GetBuyPreviewQualityBgPath()
	{
		return ConfigQualityInfoById.GetConfig(this.GetQuality(), true).Value.RoleSkinQualityBg;
	}

	// Token: 0x0601145C RID: 70748 RVA: 0x004BFD1C File Offset: 0x004BDF1C
	public string GetPreviewTextureInBuyView()
	{
		return this.GetOrnamentConfig().PreviewTextureInBuyView;
	}

	// Token: 0x0601145D RID: 70749 RVA: 0x004BFD38 File Offset: 0x004BDF38
	public string GetPreviewTextureInPayShop()
	{
		return this.GetOrnamentConfig().PreviewTextureInPayShop;
	}

	// Token: 0x0601145E RID: 70750 RVA: 0x004BFD54 File Offset: 0x004BDF54
	public string GetPreviewTextureInPop()
	{
		return this.GetOrnamentConfig().PopPreviewTexture;
	}

	// Token: 0x0400879F RID: 34719
	private readonly int Id;
}
