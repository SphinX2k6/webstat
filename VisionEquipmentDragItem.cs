using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020024F9 RID: 9465
[NullableContext(2)]
[Nullable(0)]
public class VisionEquipmentDragItem : UiPanelBase
{
	// Token: 0x06012623 RID: 75299 RVA: 0x0050E157 File Offset: 0x0050C357
	[NullableContext(1)]
	public VisionEquipmentDragItem(UUIItem uiItem)
	{
		this.SourceItem = uiItem;
	}

	// Token: 0x06012624 RID: 75300 RVA: 0x0050E168 File Offset: 0x0050C368
	public UniTask Init()
	{
		VisionEquipmentDragItem.<Init>d__4 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<VisionEquipmentDragItem.<Init>d__4>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x06012625 RID: 75301 RVA: 0x0050E1AC File Offset: 0x0050C3AC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIDraggableComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x06012626 RID: 75302 RVA: 0x0050E21C File Offset: 0x0050C41C
	protected override UniTask OnBeforeStartAsync()
	{
		VisionEquipmentDragItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionEquipmentDragItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012627 RID: 75303 RVA: 0x0050E25F File Offset: 0x0050C45F
	protected override void OnStart()
	{
	}

	// Token: 0x06012628 RID: 75304 RVA: 0x0050E261 File Offset: 0x0050C461
	public UUIDraggableComponent GetDragComponent()
	{
		return base.GetDraggable(2);
	}

	// Token: 0x06012629 RID: 75305 RVA: 0x0050E26C File Offset: 0x0050C46C
	[NullableContext(1)]
	public void UpdateItem(PhantomDataBase data)
	{
		int quality = data.GetQuality();
		string phantomQualityBgSprite = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomQualityBgSprite(quality);
		PhantomFetterGroup fetterGroupConfig = data.GetFetterGroupConfig();
		this.VisionFetterSuitItem.Update(new PhantomFetterGroup?(fetterGroupConfig));
		this.SetSpriteByPath(phantomQualityBgSprite, base.GetSprite(0), false, null, null);
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(data.GetConfigId(true));
		base.SetTextureByPath(itemConfigData.IconMiddle, base.GetTexture(1), null, null);
	}

	// Token: 0x04008F63 RID: 36707
	private readonly UUIItem SourceItem;

	// Token: 0x04008F64 RID: 36708
	private VisionFetterSuitItem VisionFetterSuitItem;

	// Token: 0x02008812 RID: 34834
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402DF6E RID: 188270
		BgSprite,
		// Token: 0x0402DF6F RID: 188271
		Texture,
		// Token: 0x0402DF70 RID: 188272
		DragComponent,
		// Token: 0x0402DF71 RID: 188273
		SuitElementItem
	}
}
