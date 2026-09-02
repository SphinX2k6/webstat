using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrainingDegree
{
	// Token: 0x02004E79 RID: 20089
	[NullableContext(1)]
	[Nullable(0)]
	public class TrainingView
	{
		// Token: 0x06033E7D RID: 212605 RVA: 0x00CFD75C File Offset: 0x00CFB95C
		public void Show(UUILayoutBase layout, [Nullable(new byte[]
		{
			2,
			1
		})] IReadOnlyList<TrainingData> inDataList = null)
		{
			if (layout == null)
			{
				return;
			}
			UUIItem uuiitem = layout.RootUIComp.Get();
			IReadOnlyList<TrainingData> readOnlyList = inDataList ?? ModelBase<TrainingDegreeModel>.Instance.GetTrainingDataList();
			if (readOnlyList == null && uuiitem != null)
			{
				uuiitem.SetUIActive(false);
			}
			this.GenericLayout = new GenericLayoutNew<TrainingItem>(layout, new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<TrainingItem>(this.InitTrainingItem), null);
			this.GenericLayout.RebuildLayoutByDataNew<TrainingData>(readOnlyList, null);
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(true);
			}
		}

		// Token: 0x06033E7E RID: 212606 RVA: 0x00CFD7D4 File Offset: 0x00CFB9D4
		private ILayoutItem<TrainingItem> InitTrainingItem(object data, UUIItem uiItem, int index)
		{
			TrainingItem trainingItem = new TrainingItem(uiItem);
			trainingItem.SetData((TrainingData)data);
			return new LayoutItem<TrainingItem>
			{
				Key = index,
				Value = trainingItem
			};
		}

		// Token: 0x06033E7F RID: 212607 RVA: 0x00CFD80C File Offset: 0x00CFBA0C
		public void Clear()
		{
			if (this.GenericLayout != null)
			{
				this.GenericLayout.ClearChildren();
			}
			this.GenericLayout = null;
		}

		// Token: 0x0401E04A RID: 122954
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayoutNew<TrainingItem> GenericLayout;
	}
}
