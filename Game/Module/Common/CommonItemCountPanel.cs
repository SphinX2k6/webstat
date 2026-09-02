using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Common
{
	// Token: 0x02005E41 RID: 24129
	[NullableContext(1)]
	[Nullable(0)]
	public class CommonItemCountPanel : UiPanelBase
	{
		// Token: 0x1700992F RID: 39215
		// (get) Token: 0x0603CB82 RID: 248706 RVA: 0x00F6B93A File Offset: 0x00F69B3A
		// (set) Token: 0x0603CB83 RID: 248707 RVA: 0x00F6B942 File Offset: 0x00F69B42
		private string Count
		{
			get
			{
				return this.CountString;
			}
			set
			{
				this.CountString = value;
				base.GetText(0).SetText(this.CountString, true);
				base.GetInteractionGroup(4).SetInteractable(this.CountString.Length > 0);
			}
		}

		// Token: 0x0603CB84 RID: 248708 RVA: 0x00F6B978 File Offset: 0x00F69B78
		protected unsafe override void OnRegisterComponent()
		{
			int num = 16;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIInteractionGroup));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClose));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnConfirm));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnDel));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603CB85 RID: 248709 RVA: 0x00F6BC3C File Offset: 0x00F69E3C
		protected override void OnStart()
		{
			this.NumButtons = new UUIButtonComponent[10];
			for (int j = 0; j <= 9; j++)
			{
				UUIButtonComponent button = base.GetButton(5 + j);
				this.NumButtons[j] = button;
			}
			int i;
			Action <>9__0;
			int i2;
			for (i = 0; i <= 9; i = i2 + 1)
			{
				FLGUIButtonDynamicDelegate onClickCallBack = this.NumButtons[i].OnClickCallBack;
				Action callback;
				if ((callback = <>9__0) == null)
				{
					callback = (<>9__0 = delegate()
					{
						if (this.Count.Length < 4)
						{
							this.Count += i.ToString();
							return;
						}
						this.Count = "9999";
					});
				}
				onClickCallBack.Bind(callback);
				i2 = i;
			}
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.SequenceEvent), false);
		}

		// Token: 0x0603CB86 RID: 248710 RVA: 0x00F6BD07 File Offset: 0x00F69F07
		private void SequenceEvent(string sequenceName)
		{
			if (sequenceName == "Close")
			{
				this.SetActive(false);
			}
		}

		// Token: 0x0603CB87 RID: 248711 RVA: 0x00F6BD20 File Offset: 0x00F69F20
		protected override void OnBeforeDestroy()
		{
			this.LevelSequencePlayer.Clear();
			this.LevelSequencePlayer = null;
			UUIButtonComponent[] numButtons = this.NumButtons;
			for (int i = 0; i < numButtons.Length; i++)
			{
				numButtons[i].OnClickCallBack.Unbind();
			}
		}

		// Token: 0x0603CB88 RID: 248712 RVA: 0x00F6BD61 File Offset: 0x00F69F61
		public void UpdateView(int itemCount)
		{
			this.Count = itemCount.ToString();
			this.RootItem.SetUIActive(true);
			this.RootItem.SetAsLastHierarchy();
		}

		// Token: 0x0603CB89 RID: 248713 RVA: 0x00F6BD87 File Offset: 0x00F69F87
		private void OnClose()
		{
			this.PlayCloseSequence();
		}

		// Token: 0x0603CB8A RID: 248714 RVA: 0x00F6BD8F File Offset: 0x00F69F8F
		private void OnConfirm()
		{
			Action<int> confirmFunction = this.ConfirmFunction;
			if (confirmFunction != null)
			{
				confirmFunction(int.Parse(this.Count));
			}
			this.PlayCloseSequence();
		}

		// Token: 0x0603CB8B RID: 248715 RVA: 0x00F6BDB3 File Offset: 0x00F69FB3
		private void OnDel()
		{
			this.Count = this.Count.Substring(0, this.Count.Length - 1);
		}

		// Token: 0x0603CB8C RID: 248716 RVA: 0x00F6BDD4 File Offset: 0x00F69FD4
		public void SetTitleText(string text)
		{
			base.GetText(15).SetText(text, true);
		}

		// Token: 0x0603CB8D RID: 248717 RVA: 0x00F6BDE8 File Offset: 0x00F69FE8
		public void PlayStartSequence(int itemCount)
		{
			this.SetActive(true);
			this.LevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
			this.UpdateView(itemCount);
		}

		// Token: 0x0603CB8E RID: 248718 RVA: 0x00F6BE20 File Offset: 0x00F6A020
		public void PlayCloseSequence()
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
		}

		// Token: 0x0603CB8F RID: 248719 RVA: 0x00F6BE48 File Offset: 0x00F6A048
		public void SetConfirmFunction(Action<int> callback)
		{
			this.ConfirmFunction = callback;
		}

		// Token: 0x0402217E RID: 139646
		private const int MAX_DIGIT = 4;

		// Token: 0x0402217F RID: 139647
		private const string MAX_NUMBER = "9999";

		// Token: 0x04022180 RID: 139648
		private const int KEYCOUNT = 9;

		// Token: 0x04022181 RID: 139649
		private string CountString = "";

		// Token: 0x04022182 RID: 139650
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private UUIButtonComponent[] NumButtons;

		// Token: 0x04022183 RID: 139651
		[Nullable(2)]
		private Action<int> ConfirmFunction;

		// Token: 0x04022184 RID: 139652
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200BE70 RID: 48752
		[NullableContext(0)]
		private class ECommonItemCountPanelDefine
		{
			// Token: 0x0403AA2D RID: 240173
			public const int CountText = 0;

			// Token: 0x0403AA2E RID: 240174
			public const int Close = 1;

			// Token: 0x0403AA2F RID: 240175
			public const int Del = 2;

			// Token: 0x0403AA30 RID: 240176
			public const int Yes = 3;

			// Token: 0x0403AA31 RID: 240177
			public const int YesGroup = 4;

			// Token: 0x0403AA32 RID: 240178
			public const int ZeroButton = 5;

			// Token: 0x0403AA33 RID: 240179
			public const int OneButton = 6;

			// Token: 0x0403AA34 RID: 240180
			public const int TwoButton = 7;

			// Token: 0x0403AA35 RID: 240181
			public const int ThreeButton = 8;

			// Token: 0x0403AA36 RID: 240182
			public const int FourButton = 9;

			// Token: 0x0403AA37 RID: 240183
			public const int FiveButton = 10;

			// Token: 0x0403AA38 RID: 240184
			public const int SixButton = 11;

			// Token: 0x0403AA39 RID: 240185
			public const int SevenButton = 12;

			// Token: 0x0403AA3A RID: 240186
			public const int EightButton = 13;

			// Token: 0x0403AA3B RID: 240187
			public const int NineButton = 14;

			// Token: 0x0403AA3C RID: 240188
			public const int TitleText = 15;
		}
	}
}
