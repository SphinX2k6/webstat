using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk
{
	// Token: 0x0200697F RID: 27007
	[NullableContext(1)]
	[Nullable(0)]
	public class CyberPunkEntranceItem : UiPanelBase
	{
		// Token: 0x06043032 RID: 274482 RVA: 0x01134DC4 File Offset: 0x01132FC4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06043033 RID: 274483 RVA: 0x01134EF0 File Offset: 0x011330F0
		protected override void OnBeforeDestroy()
		{
			foreach (ERedDotName name in this.RedDotNames)
			{
				ControllerBase<RedDotController>.Instance.UnBindGivenUi(name, base.GetItem(5), 0);
			}
			this.RedDotNames.Clear();
			this.RedDotStates.Clear();
		}

		// Token: 0x06043034 RID: 274484 RVA: 0x01134F68 File Offset: 0x01133168
		public void SetOnClick(Action callback)
		{
			this.ClickCallback = callback;
		}

		// Token: 0x06043035 RID: 274485 RVA: 0x01134F71 File Offset: 0x01133171
		public void SetOnLockClick(Action callback)
		{
			this.LockClickCallback = callback;
		}

		// Token: 0x06043036 RID: 274486 RVA: 0x01134F7A File Offset: 0x0113317A
		public void SetConfig(EdgeRunnerUnlock config)
		{
			this.ConfigId = config.Id;
		}

		// Token: 0x06043037 RID: 274487 RVA: 0x01134F89 File Offset: 0x01133189
		public int GetConfigId()
		{
			return this.ConfigId;
		}

		// Token: 0x06043038 RID: 274488 RVA: 0x01134F91 File Offset: 0x01133191
		public void SetLocked(bool locked)
		{
			this.IsLocked = locked;
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(locked);
			}
			this.UpdateIconVisibility();
		}

		// Token: 0x06043039 RID: 274489 RVA: 0x01134FB4 File Offset: 0x011331B4
		public void SetNumText(string text)
		{
			UUIText text2 = base.GetText(4);
			if (text2 == null)
			{
				return;
			}
			string[] array = text.Split('/', StringSplitOptions.None);
			if (array.Length != 2)
			{
				text2.SetText(text, true);
				return;
			}
			string text3 = array[0];
			string text4 = array[1];
			int num = int.Parse(text3);
			int num2 = int.Parse(text4);
			string value = EProgressTextColorHelper.ToColorString(EProgressTextColor.InProgress);
			if (num == 0)
			{
				value = EProgressTextColorHelper.ToColorString(EProgressTextColor.Zero);
			}
			else if (num == num2)
			{
				value = EProgressTextColorHelper.ToColorString(EProgressTextColor.Completed);
				this.SetFinished(true);
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 3);
			defaultInterpolatedStringHandler.AppendLiteral("<color=#");
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral(">");
			defaultInterpolatedStringHandler.AppendFormatted(text3);
			defaultInterpolatedStringHandler.AppendLiteral("</color>/");
			defaultInterpolatedStringHandler.AppendFormatted(text4);
			string newText = defaultInterpolatedStringHandler.ToStringAndClear();
			text2.SetText(newText, true);
		}

		// Token: 0x0604303A RID: 274490 RVA: 0x01135082 File Offset: 0x01133282
		public void SetFinished(bool finished)
		{
			this.IsFinished = finished;
			this.UpdateIconVisibility();
		}

		// Token: 0x0604303B RID: 274491 RVA: 0x01135091 File Offset: 0x01133291
		public void Refresh(bool locked, string numText)
		{
			this.SetLocked(locked);
			this.SetNumText(numText);
		}

		// Token: 0x0604303C RID: 274492 RVA: 0x011350A4 File Offset: 0x011332A4
		public void BindRedDot(ERedDotName redDotName)
		{
			if (this.RedDotNames.Contains(redDotName))
			{
				return;
			}
			this.RedDotNames.Add(redDotName);
			this.RedDotStates[redDotName] = false;
			ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, base.GetItem(5), delegate(bool state, int _)
			{
				this.RedDotStates[redDotName] = state;
				this.UpdateRedDotVisibility();
			}, 0);
		}

		// Token: 0x0604303D RID: 274493 RVA: 0x01135120 File Offset: 0x01133320
		private void UpdateRedDotVisibility()
		{
			bool uiactive = false;
			using (Dictionary<ERedDotName, bool>.ValueCollection.Enumerator enumerator = this.RedDotStates.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current)
					{
						uiactive = true;
						break;
					}
				}
			}
			UUIItem item = base.GetItem(5);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(uiactive);
		}

		// Token: 0x0604303E RID: 274494 RVA: 0x0113518C File Offset: 0x0113338C
		private void UpdateIconVisibility()
		{
			if (this.IsLocked)
			{
				UUIItem item = base.GetItem(1);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				UUIItem item2 = base.GetItem(2);
				if (item2 != null)
				{
					item2.SetUIActive(false);
				}
				UUIItem item3 = base.GetItem(3);
				if (item3 == null)
				{
					return;
				}
				item3.SetUIActive(false);
				return;
			}
			else if (this.IsFinished)
			{
				UUIItem item4 = base.GetItem(1);
				if (item4 != null)
				{
					item4.SetUIActive(false);
				}
				UUIItem item5 = base.GetItem(2);
				if (item5 != null)
				{
					item5.SetUIActive(true);
				}
				UUIItem item6 = base.GetItem(3);
				if (item6 == null)
				{
					return;
				}
				item6.SetUIActive(true);
				return;
			}
			else
			{
				UUIItem item7 = base.GetItem(1);
				if (item7 != null)
				{
					item7.SetUIActive(false);
				}
				UUIItem item8 = base.GetItem(2);
				if (item8 != null)
				{
					item8.SetUIActive(true);
				}
				UUIItem item9 = base.GetItem(3);
				if (item9 == null)
				{
					return;
				}
				item9.SetUIActive(false);
				return;
			}
		}

		// Token: 0x0604303F RID: 274495 RVA: 0x01135253 File Offset: 0x01133453
		private void OnClickButton()
		{
			if (this.IsLocked)
			{
				Action lockClickCallback = this.LockClickCallback;
				if (lockClickCallback == null)
				{
					return;
				}
				lockClickCallback();
				return;
			}
			else
			{
				Action clickCallback = this.ClickCallback;
				if (clickCallback == null)
				{
					return;
				}
				clickCallback();
				return;
			}
		}

		// Token: 0x04025525 RID: 152869
		[Nullable(2)]
		private Action ClickCallback;

		// Token: 0x04025526 RID: 152870
		[Nullable(2)]
		private Action LockClickCallback;

		// Token: 0x04025527 RID: 152871
		private readonly List<ERedDotName> RedDotNames = new List<ERedDotName>();

		// Token: 0x04025528 RID: 152872
		private readonly Dictionary<ERedDotName, bool> RedDotStates = new Dictionary<ERedDotName, bool>();

		// Token: 0x04025529 RID: 152873
		private bool IsLocked;

		// Token: 0x0402552A RID: 152874
		private bool IsFinished;

		// Token: 0x0402552B RID: 152875
		private int ConfigId;

		// Token: 0x0200C92C RID: 51500
		[NullableContext(0)]
		private static class EEntranceComponent
		{
			// Token: 0x0403DE0D RID: 253453
			public const int Button = 0;

			// Token: 0x0403DE0E RID: 253454
			public const int LockIcon = 1;

			// Token: 0x0403DE0F RID: 253455
			public const int UnLockIcon = 2;

			// Token: 0x0403DE10 RID: 253456
			public const int FinishedIcon = 3;

			// Token: 0x0403DE11 RID: 253457
			public const int TxtNum = 4;

			// Token: 0x0403DE12 RID: 253458
			public const int RedDot = 5;
		}
	}
}
