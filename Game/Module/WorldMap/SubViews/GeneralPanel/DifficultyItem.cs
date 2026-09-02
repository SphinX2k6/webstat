using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.MingSu;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.GeneralPanel
{
	// Token: 0x02004BBA RID: 19386
	[NullableContext(1)]
	[Nullable(0)]
	public class DifficultyItem : UiPanelBase, IGridProxy<DarkCoastDeliveryLevelData>
	{
		// Token: 0x170086F2 RID: 34546
		// (get) Token: 0x060329B6 RID: 207286 RVA: 0x00CAD1CD File Offset: 0x00CAB3CD
		// (set) Token: 0x060329B7 RID: 207287 RVA: 0x00CAD1D5 File Offset: 0x00CAB3D5
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		public IScrollViewDelegate<IGridProxy<DarkCoastDeliveryLevelData>, DarkCoastDeliveryLevelData> ScrollViewDelegate { [return: Nullable(new byte[]
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

		// Token: 0x170086F3 RID: 34547
		// (get) Token: 0x060329B8 RID: 207288 RVA: 0x00CAD1DE File Offset: 0x00CAB3DE
		// (set) Token: 0x060329B9 RID: 207289 RVA: 0x00CAD1E6 File Offset: 0x00CAB3E6
		public int GridIndex { get; set; }

		// Token: 0x170086F4 RID: 34548
		// (get) Token: 0x060329BA RID: 207290 RVA: 0x00CAD1EF File Offset: 0x00CAB3EF
		// (set) Token: 0x060329BB RID: 207291 RVA: 0x00CAD1F7 File Offset: 0x00CAB3F7
		public int DisplayIndex { get; set; }

		// Token: 0x060329BC RID: 207292 RVA: 0x00CAD200 File Offset: 0x00CAB400
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060329BD RID: 207293 RVA: 0x00CAD2AC File Offset: 0x00CAB4AC
		public void Refresh(DarkCoastDeliveryLevelData data, bool isSelected, int gridIndex)
		{
			string resourceId = (data.GetDarkCoastDeliveryGuardState() == MingSuDefine.EDarkCoastDeliveryLevelDataState.Received) ? "T_MapDifficultyTick" : "T_MapDifficultyEmpty";
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			if (!string.IsNullOrEmpty(resourcePath))
			{
				base.SetTextureByPath(resourcePath, base.GetTexture(1), null, null);
			}
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.SetUIActive(true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "DarkShoreBossFirst_Text", Array.Empty<object>());
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIText text2 = base.GetText(3);
			if (text2 != null)
			{
				text2.SetUIActive(true);
			}
			UUIText text3 = base.GetText(3);
			if (text3 == null)
			{
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.Config.RewardCount);
			defaultInterpolatedStringHandler.AppendLiteral("x");
			text3.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x060329BE RID: 207294 RVA: 0x00CAD393 File Offset: 0x00CAB593
		public void Clear()
		{
		}

		// Token: 0x060329BF RID: 207295 RVA: 0x00CAD395 File Offset: 0x00CAB595
		public void OnSelected(bool fireEvent)
		{
		}

		// Token: 0x060329C0 RID: 207296 RVA: 0x00CAD397 File Offset: 0x00CAB597
		public void OnDeselected(bool fireEvent)
		{
		}

		// Token: 0x060329C1 RID: 207297 RVA: 0x00CAD399 File Offset: 0x00CAB599
		public object GetKey(DarkCoastDeliveryLevelData data, int gridIndex)
		{
			return this.GridIndex;
		}
	}
}
