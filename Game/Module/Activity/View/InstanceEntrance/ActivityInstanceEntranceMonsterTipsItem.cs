using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.View.InstanceEntrance
{
	// Token: 0x020061EB RID: 25067
	public class ActivityInstanceEntranceMonsterTipsItem : UiPanelBase
	{
		// Token: 0x0603F3F7 RID: 259063 RVA: 0x0103B63C File Offset: 0x0103983C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickBtnMonster));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603F3F8 RID: 259064 RVA: 0x0103B6E4 File Offset: 0x010398E4
		[NullableContext(1)]
		public void RefreshView(ActivityInstanceEntranceData data)
		{
			this.CurrentData = data;
			int selectDataIndex = this.CurrentData.GetActivityEntranceSelectItemData().GetCurrentSelectData().GetSelectDataIndex();
			ActivityEntranceMonsterPreviewData activityEntranceMonsterPreviewData = this.CurrentData.GetActivityEntranceMonsterPreviewData();
			string monsterTips = activityEntranceMonsterPreviewData.GetMonsterTips(selectDataIndex);
			bool monsterPreviewState = activityEntranceMonsterPreviewData.GetMonsterPreviewState(selectDataIndex);
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.SetText(monsterTips, true);
			}
			UUIButtonComponent button = base.GetButton(1);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(monsterPreviewState);
		}

		// Token: 0x0603F3F9 RID: 259065 RVA: 0x0103B75C File Offset: 0x0103995C
		private void OnClickBtnMonster()
		{
			int selectDataIndex = this.CurrentData.GetActivityEntranceSelectItemData().GetCurrentSelectData().GetSelectDataIndex();
			Action<int> previewCallBack = this.CurrentData.GetActivityEntranceMonsterPreviewData().GetPreviewCallBack();
			if (previewCallBack != null)
			{
				previewCallBack(selectDataIndex);
			}
		}

		// Token: 0x0402382C RID: 145452
		[Nullable(2)]
		private ActivityInstanceEntranceData CurrentData;

		// Token: 0x0200C32C RID: 49964
		private enum EComponent
		{
			// Token: 0x0403C26E RID: 246382
			BuffText,
			// Token: 0x0403C26F RID: 246383
			BtnMonsterPreView
		}
	}
}
