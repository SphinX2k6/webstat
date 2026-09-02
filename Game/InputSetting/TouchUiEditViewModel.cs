using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x0200701A RID: 28698
	[NullableContext(1)]
	[Nullable(0)]
	public class TouchUiEditViewModel : IStaticVariableResetter
	{
		// Token: 0x060457AF RID: 284591 RVA: 0x01229D25 File Offset: 0x01227F25
		static TouchUiEditViewModel()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(TouchUiEditViewModel.CreateStaticDefaultValue), new Action(TouchUiEditViewModel.ResetStaticDefaultValue));
		}

		// Token: 0x060457B0 RID: 284592 RVA: 0x01229D44 File Offset: 0x01227F44
		[NullableContext(2)]
		public static void SetCurrentSelectedItem(ITouchUiEditItem item)
		{
			TouchUiEditViewModel.CurrentSelectedItem = item;
			if (item != null)
			{
				TouchUiEditViewModel.NotifySelectedItemChange(item);
			}
		}

		// Token: 0x060457B1 RID: 284593 RVA: 0x01229D55 File Offset: 0x01227F55
		[NullableContext(2)]
		public static ITouchUiEditItem GetCurrentSelectedItem()
		{
			return TouchUiEditViewModel.CurrentSelectedItem;
		}

		// Token: 0x060457B2 RID: 284594 RVA: 0x01229D5C File Offset: 0x01227F5C
		public static void AddTouchFingerData(TouchFingerData touchFingerData)
		{
			EFingerIndex fingerIndex = touchFingerData.GetFingerIndex();
			TouchUiEditViewModel.TouchFingerDataMap[(int)fingerIndex] = touchFingerData;
		}

		// Token: 0x060457B3 RID: 284595 RVA: 0x01229D7C File Offset: 0x01227F7C
		public static void RemoveTouchFingerData(TouchFingerData touchFingerData)
		{
			EFingerIndex fingerIndex = touchFingerData.GetFingerIndex();
			TouchUiEditViewModel.TouchFingerDataMap.Remove((int)fingerIndex);
		}

		// Token: 0x060457B4 RID: 284596 RVA: 0x01229D9C File Offset: 0x01227F9C
		[NullableContext(2)]
		public static TouchFingerData GetTouchFingerData(int fingerIndex)
		{
			return TouchUiEditViewModel.TouchFingerDataMap.GetValueOrDefault(fingerIndex);
		}

		// Token: 0x060457B5 RID: 284597 RVA: 0x01229DA9 File Offset: 0x01227FA9
		public static int GetTouchFingerDataCount()
		{
			return TouchUiEditViewModel.TouchFingerDataMap.Count;
		}

		// Token: 0x060457B6 RID: 284598 RVA: 0x01229DB5 File Offset: 0x01227FB5
		public static void SetRootItem(UUIItem rootItem)
		{
			TouchUiEditViewModel.RootItem = rootItem;
		}

		// Token: 0x060457B7 RID: 284599 RVA: 0x01229DBD File Offset: 0x01227FBD
		[NullableContext(2)]
		public static UUIItem GetRootItem()
		{
			return TouchUiEditViewModel.RootItem;
		}

		// Token: 0x060457B8 RID: 284600 RVA: 0x01229DC4 File Offset: 0x01227FC4
		public static void AddDelegateOnSelectedItemChange(Action<ITouchUiEditItem> delegate_)
		{
			TouchUiEditViewModel.DelegatesOnSelectedItemChange.Add(delegate_);
		}

		// Token: 0x060457B9 RID: 284601 RVA: 0x01229DD4 File Offset: 0x01227FD4
		public static void RemoveDelegateOnSelectedItemChange(Action<ITouchUiEditItem> delegate_)
		{
			int num = TouchUiEditViewModel.DelegatesOnSelectedItemChange.IndexOf(delegate_);
			if (num != -1)
			{
				TouchUiEditViewModel.DelegatesOnSelectedItemChange.RemoveAt(num);
			}
		}

		// Token: 0x060457BA RID: 284602 RVA: 0x01229DFC File Offset: 0x01227FFC
		public static void NotifySelectedItemChange(ITouchUiEditItem item)
		{
			if (TouchUiEditViewModel.CurrentSelectedItem != item)
			{
				return;
			}
			foreach (Action<ITouchUiEditItem> action in TouchUiEditViewModel.DelegatesOnSelectedItemChange)
			{
				action(item);
			}
		}

		// Token: 0x060457BB RID: 284603 RVA: 0x01229E58 File Offset: 0x01228058
		public static void CreateStaticDefaultValue()
		{
			TouchUiEditViewModel.CurrentSelectedItem = null;
			TouchUiEditViewModel.RootItem = null;
			TouchUiEditViewModel.TouchFingerDataMap = new Dictionary<int, TouchFingerData>();
			TouchUiEditViewModel.DelegatesOnSelectedItemChange = new List<Action<ITouchUiEditItem>>();
		}

		// Token: 0x060457BC RID: 284604 RVA: 0x01229E7A File Offset: 0x0122807A
		public static void ResetStaticDefaultValue()
		{
			TouchUiEditViewModel.CurrentSelectedItem = null;
			TouchUiEditViewModel.RootItem = null;
			TouchUiEditViewModel.TouchFingerDataMap = null;
			TouchUiEditViewModel.DelegatesOnSelectedItemChange = null;
		}

		// Token: 0x04026D13 RID: 158995
		[Nullable(2)]
		private static ITouchUiEditItem CurrentSelectedItem;

		// Token: 0x04026D14 RID: 158996
		[Nullable(2)]
		private static UUIItem RootItem;

		// Token: 0x04026D15 RID: 158997
		private static Dictionary<int, TouchFingerData> TouchFingerDataMap;

		// Token: 0x04026D16 RID: 158998
		private static List<Action<ITouchUiEditItem>> DelegatesOnSelectedItemChange;
	}
}
