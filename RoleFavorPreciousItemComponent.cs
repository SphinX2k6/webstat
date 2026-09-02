using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x0200287C RID: 10364
[NullableContext(2)]
[Nullable(0)]
public class RoleFavorPreciousItemComponent : RoleFavorViewComponentBase
{
	// Token: 0x0601483C RID: 84028 RVA: 0x005B14B0 File Offset: 0x005AF6B0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUINiagara)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x0601483D RID: 84029 RVA: 0x005B1536 File Offset: 0x005AF736
	protected override void OnBeforeDestroy()
	{
		this.FavorGoods = null;
		this.Icon = null;
		this.LockItem = null;
		this.InActiveBgItem = null;
		this.ActiveBgItem = null;
	}

	// Token: 0x0601483E RID: 84030 RVA: 0x005B1560 File Offset: 0x005AF760
	[NullableContext(1)]
	protected override void OnSetData(RoleFavorContentDataBase contentData)
	{
		if (contentData.FavorContentType != EFavorContentType.PreciousItem)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "不支持的好感度类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("favorTabType", contentData.FavorContentType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.FavorGoods = new FavorGoods?(((RoleFavorPreciousItemContentData)contentData).ConfigData);
	}

	// Token: 0x0601483F RID: 84031 RVA: 0x005B15C0 File Offset: 0x005AF7C0
	protected override void OnRefreshView()
	{
		if (this.FavorGoods == null)
		{
			return;
		}
		this.Icon = base.GetTexture(0);
		this.LockItem = base.GetItem(2);
		this.InActiveBgItem = base.GetItem(3);
		this.ActiveBgItem = base.GetItem(4);
		base.SetTextureByPath(this.FavorGoods.Value.Pic, this.Icon, null, null);
	}

	// Token: 0x06014840 RID: 84032 RVA: 0x005B1638 File Offset: 0x005AF838
	public void SetLockState(bool isLock)
	{
		if (this.Icon == null)
		{
			return;
		}
		if (isLock)
		{
			this.Icon.SetColor(FColor.FromHex("8F8F8FFF"));
		}
		else
		{
			this.Icon.SetColor(FColor.FromHex("FFFFFFFF"));
		}
		this.Icon.SetUIActive(!isLock);
		UUIItem lockItem = this.LockItem;
		if (lockItem != null)
		{
			lockItem.SetUIActive(false);
		}
		UUIItem inActiveBgItem = this.InActiveBgItem;
		if (inActiveBgItem != null)
		{
			inActiveBgItem.SetUIActive(false);
		}
		UUIItem activeBgItem = this.ActiveBgItem;
		if (activeBgItem == null)
		{
			return;
		}
		activeBgItem.SetUIActive(false);
	}

	// Token: 0x04009EAD RID: 40621
	private FavorGoods? FavorGoods;

	// Token: 0x04009EAE RID: 40622
	private UUITexture Icon;

	// Token: 0x04009EAF RID: 40623
	private UUIItem LockItem;

	// Token: 0x04009EB0 RID: 40624
	private UUIItem InActiveBgItem;

	// Token: 0x04009EB1 RID: 40625
	private UUIItem ActiveBgItem;
}
