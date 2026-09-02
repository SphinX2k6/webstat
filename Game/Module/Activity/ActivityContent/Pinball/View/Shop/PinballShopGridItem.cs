using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Shop
{
	// Token: 0x020065AF RID: 26031
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballShopGridItem : PinballShopItem, IGridProxy<PinballShopItemProxy>
	{
		// Token: 0x17009ED5 RID: 40661
		// (get) Token: 0x060410A7 RID: 266407 RVA: 0x010B04C9 File Offset: 0x010AE6C9
		// (set) Token: 0x060410A8 RID: 266408 RVA: 0x010B04D1 File Offset: 0x010AE6D1
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		public IScrollViewDelegate<IGridProxy<PinballShopItemProxy>, PinballShopItemProxy> ScrollViewDelegate { [return: Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})] set; }

		// Token: 0x17009ED6 RID: 40662
		// (get) Token: 0x060410A9 RID: 266409 RVA: 0x010B04DA File Offset: 0x010AE6DA
		// (set) Token: 0x060410AA RID: 266410 RVA: 0x010B04E2 File Offset: 0x010AE6E2
		public int GridIndex { get; set; }

		// Token: 0x17009ED7 RID: 40663
		// (get) Token: 0x060410AB RID: 266411 RVA: 0x010B04EB File Offset: 0x010AE6EB
		// (set) Token: 0x060410AC RID: 266412 RVA: 0x010B04F3 File Offset: 0x010AE6F3
		public int DisplayIndex { get; set; }

		// Token: 0x060410AD RID: 266413 RVA: 0x010B04FC File Offset: 0x010AE6FC
		public void Refresh(PinballShopItemProxy data, bool isSelected, int gridIndex)
		{
			base.RefreshByData(data);
		}

		// Token: 0x060410AE RID: 266414 RVA: 0x010B0505 File Offset: 0x010AE705
		public void Clear()
		{
		}

		// Token: 0x060410AF RID: 266415 RVA: 0x010B0507 File Offset: 0x010AE707
		public void OnSelected(bool fireEvent)
		{
		}

		// Token: 0x060410B0 RID: 266416 RVA: 0x010B0509 File Offset: 0x010AE709
		public void OnDeselected(bool fireEvent)
		{
		}

		// Token: 0x060410B1 RID: 266417 RVA: 0x010B050B File Offset: 0x010AE70B
		public object GetKey(PinballShopItemProxy data, int gridIndex)
		{
			return gridIndex;
		}
	}
}
