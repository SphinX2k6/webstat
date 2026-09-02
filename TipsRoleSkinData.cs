using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Skin;

// Token: 0x02001991 RID: 6545
public class TipsRoleSkinData : TipsMaterialData
{
	// Token: 0x0600BBFB RID: 48123 RVA: 0x0031EC08 File Offset: 0x0031CE08
	[NullableContext(1)]
	public TipsRoleSkinData(ItemTipsParam data) : base(data)
	{
		this.ItemType = EItemTipsType.RoleSkin;
		this.Title = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(data.ItemId).Value.TitleName;
	}
}
