using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EBB RID: 24251
	[NullableContext(1)]
	[Nullable(0)]
	public class CiacconaGalStepChoiceList : UiPanelBase
	{
		// Token: 0x0603CF49 RID: 249673 RVA: 0x00F7B20C File Offset: 0x00F7940C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603CF4A RID: 249674 RVA: 0x00F7B275 File Offset: 0x00F79475
		protected override void OnStart()
		{
			this.LayoutList = new GenericLayout<GridProxyAbstract<CiacconaGalChoiceData>, CiacconaGalChoiceData>(base.GetVerticalLayout(0), new Func<GridProxyAbstract<CiacconaGalChoiceData>>(this.GetChoiceItem), null, false, true);
			Singleton<EventSystem>.Instance.Add(EEventName.OnCiacconaChapterDataUpdate, new Action(this.OnDataUpdate));
		}

		// Token: 0x0603CF4B RID: 249675 RVA: 0x00F7B2B4 File Offset: 0x00F794B4
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCiacconaChapterDataUpdate, new Action(this.OnDataUpdate));
		}

		// Token: 0x0603CF4C RID: 249676 RVA: 0x00F7B2D4 File Offset: 0x00F794D4
		public void Refresh(CiacconaGalStepData stepData)
		{
			this.StepData = stepData;
			this.ChoicesDataList.Clear();
			bool flag = false;
			foreach (int id in stepData.ChoiceIds)
			{
				CiacconaGalChoiceData choiceDataById = ModelBase<CiacconaGalModel>.Instance.GetChoiceDataById(id);
				this.ChoicesDataList.Add(choiceDataById);
				if (choiceDataById.NeedInspiration)
				{
					flag = true;
				}
			}
			if (flag)
			{
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnCiacconaAvgInspirationChoiceShow, true);
			}
			this.LayoutList.RefreshByData(this.ChoicesDataList, null, false);
		}

		// Token: 0x0603CF4D RID: 249677 RVA: 0x00F7B35A File Offset: 0x00F7955A
		private CiacconaGalStepChoiceItem GetChoiceItem()
		{
			return new CiacconaGalStepChoiceItem();
		}

		// Token: 0x0603CF4E RID: 249678 RVA: 0x00F7B361 File Offset: 0x00F79561
		private void OnDataUpdate()
		{
			if (this.StepData != null)
			{
				this.Refresh(this.StepData);
			}
		}

		// Token: 0x0603CF4F RID: 249679 RVA: 0x00F7B378 File Offset: 0x00F79578
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			if (configParams[0] == "FirstChoice" && this.ChoicesDataList.Count > 1)
			{
				GenericLayout<GridProxyAbstract<CiacconaGalChoiceData>, CiacconaGalChoiceData> layoutList = this.LayoutList;
				UUIItem uuiitem = (layoutList != null) ? layoutList.GetGridByDisplayIndex(0) : null;
				if (uuiitem != null)
				{
					return new UUIItem[]
					{
						uuiitem,
						uuiitem
					};
				}
			}
			return null;
		}

		// Token: 0x04022374 RID: 140148
		private List<CiacconaGalChoiceData> ChoicesDataList = new List<CiacconaGalChoiceData>();

		// Token: 0x04022375 RID: 140149
		[Nullable(2)]
		private CiacconaGalStepData StepData;

		// Token: 0x04022376 RID: 140150
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private GenericLayout<GridProxyAbstract<CiacconaGalChoiceData>, CiacconaGalChoiceData> LayoutList;

		// Token: 0x0200BEAB RID: 48811
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403AB21 RID: 240417
			public const int LayoutList = 0;

			// Token: 0x0403AB22 RID: 240418
			public const int ItemChoice = 1;
		}
	}
}
