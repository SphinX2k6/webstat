using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001C73 RID: 7283
public class FloroRanchTerrainTipItem : UiPanelBase
{
	// Token: 0x0600D48F RID: 54415 RVA: 0x0038BD00 File Offset: 0x00389F00
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D490 RID: 54416 RVA: 0x0038BD6C File Offset: 0x00389F6C
	protected override void OnStart()
	{
		ITermExplanationRegistryParam param = new TermExplanationRegistryParam
		{
			UiText = base.GetText(1),
			ViewType = ETermExplanationViewType.Center,
			ReportType = ETermExplanationReportType.FloroRanch,
			Style = new ETermExplanationViewStyle?(ETermExplanationViewStyle.FloroRanch)
		};
		ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
	}

	// Token: 0x0600D491 RID: 54417 RVA: 0x0038BDB2 File Offset: 0x00389FB2
	protected override void OnBeforeDestroy()
	{
		ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(base.GetText(1));
	}

	// Token: 0x0600D492 RID: 54418 RVA: 0x0038BDC5 File Offset: 0x00389FC5
	[NullableContext(1)]
	public void RefreshInfoTipByEntity(FloroRanchEntityBase terrainEntity)
	{
		this.RefreshTerrainTip(terrainEntity);
	}

	// Token: 0x0600D493 RID: 54419 RVA: 0x0038BDD0 File Offset: 0x00389FD0
	[NullableContext(1)]
	private void RefreshTerrainTip(FloroRanchEntityBase terrainEntity)
	{
		if (terrainEntity == null)
		{
			UUIItem rootItem = base.GetRootItem();
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetUIActive(false);
			return;
		}
		else
		{
			FloroRanchTerrainDataComponent floroRanchTerrainDataComponent = terrainEntity.CheckGetComponent<FloroRanchTerrainDataComponent>();
			FloroRanchTerrainData floroRanchTerrainData = (floroRanchTerrainDataComponent != null) ? floroRanchTerrainDataComponent.TerrainData : null;
			if (floroRanchTerrainData == null)
			{
				UUIItem rootItem2 = base.GetRootItem();
				if (rootItem2 == null)
				{
					return;
				}
				rootItem2.SetUIActive(false);
				return;
			}
			else
			{
				UUIText text = base.GetText(0);
				if (text != null)
				{
					text.SetText(floroRanchTerrainData.Name, true);
				}
				UUIText text2 = base.GetText(1);
				if (text2 != null)
				{
					text2.SetText(floroRanchTerrainData.Desc, true);
				}
				UUIItem rootItem3 = base.GetRootItem();
				if (rootItem3 == null)
				{
					return;
				}
				rootItem3.SetUIActive(true);
				return;
			}
		}
	}

	// Token: 0x02007FA1 RID: 32673
	private class EComponentDefine
	{
		// Token: 0x0402B72E RID: 177966
		public const int TerrainName = 0;

		// Token: 0x0402B72F RID: 177967
		public const int TerrainDesc = 1;
	}
}
