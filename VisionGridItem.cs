using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200182B RID: 6187
public class VisionGridItem : GridProxyAbstract<int>
{
	// Token: 0x0600B0A5 RID: 45221 RVA: 0x002F2A79 File Offset: 0x002F0C79
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem))
		};
	}

	// Token: 0x0600B0A6 RID: 45222 RVA: 0x002F2A9C File Offset: 0x002F0C9C
	protected override UniTask OnBeforeStartAsync()
	{
		VisionGridItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionGridItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600B0A7 RID: 45223 RVA: 0x002F2AE0 File Offset: 0x002F0CE0
	private UniTask CreateItemGrid()
	{
		VisionGridItem.<CreateItemGrid>d__4 <CreateItemGrid>d__;
		<CreateItemGrid>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateItemGrid>d__.<>4__this = this;
		<CreateItemGrid>d__.<>1__state = -1;
		<CreateItemGrid>d__.<>t__builder.Start<VisionGridItem.<CreateItemGrid>d__4>(ref <CreateItemGrid>d__);
		return <CreateItemGrid>d__.<>t__builder.Task;
	}

	// Token: 0x0600B0A8 RID: 45224 RVA: 0x002F2B24 File Offset: 0x002F0D24
	private void RefreshPrivate(int itemId)
	{
		PhantomItem? phantomItemById = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemById(itemId);
		CalabashDevelopReward? calabashDevelopRewardByMonsterId = ConfigBase<CalabashConfig>.Instance.GetCalabashDevelopRewardByMonsterId(phantomItemById.Value.MonsterId);
		MonsterInfo? monsterInfoConfig = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterInfoConfig(calabashDevelopRewardByMonsterId.Value.MonsterInfoId);
		InventoryConfig instance = ConfigBase<InventoryConfig>.Instance;
		ItemConfig itemConfig = (instance != null) ? instance.GetItemConfigData(itemId) : null;
		string phantomQualityBgSprite = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomQualityBgSprite(itemConfig.QualityId);
		PropMediumItemGrid parameters = new PropMediumItemGrid
		{
			Data = itemId,
			ItemConfigId = new int?(itemId),
			IconPath = monsterInfoConfig.Value.Icon,
			QualityIcon = phantomQualityBgSprite
		};
		this.ItemGrid.Apply<PropMediumItemGrid>(parameters);
	}

	// Token: 0x0600B0A9 RID: 45225 RVA: 0x002F2BE2 File Offset: 0x002F0DE2
	public override void Refresh(int itemId, bool isSelected, int gridIndex)
	{
		this.RefreshPrivate(itemId);
	}

	// Token: 0x0600B0AA RID: 45226 RVA: 0x002F2BEB File Offset: 0x002F0DEB
	public void RefreshByData(int itemId)
	{
		this.RefreshPrivate(itemId);
	}

	// Token: 0x040053A7 RID: 21415
	[Nullable(2)]
	private MediumItemGrid ItemGrid;

	// Token: 0x02007BC3 RID: 31683
	private class EComponentDefine
	{
		// Token: 0x0402A4D0 RID: 173264
		public const int ItemGrid = 0;
	}
}
