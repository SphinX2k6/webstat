using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AutoAttach;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.Cipher
{
	// Token: 0x02006F42 RID: 28482
	[NullableContext(2)]
	[Nullable(0)]
	public class CipherKey : UiPanelBase
	{
		// Token: 0x06044F13 RID: 282387 RVA: 0x011F1E54 File Offset: 0x011F0054
		[NullableContext(1)]
		public CipherKey(UUIItem uiItem, int index)
		{
			this.KeyIndex = index;
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x06044F14 RID: 282388 RVA: 0x011F1E70 File Offset: 0x011F0070
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x06044F15 RID: 282389 RVA: 0x011F1EAC File Offset: 0x011F00AC
		protected override void OnStart()
		{
			this.AllNumber = new int[10];
			for (int i = 0; i < 10; i++)
			{
				this.AllNumber[i] = i;
			}
			this.CircleItemList = new List<CipherCircleAttachItem>();
			this.OnKeyItemSelectedHandle = new Action<int>(this.KeyItemSelectedHandle);
			CircleAttachView<int, CipherCircleAttachItem> circleExhibitionView = this.CircleExhibitionView;
			if (circleExhibitionView != null)
			{
				circleExhibitionView.Clear();
			}
			this.CircleExhibitionView = null;
			this.CircleExhibitionView = new CircleAttachView<int, CipherCircleAttachItem>(base.GetItem(0).GetOwner() as AUIBaseActor, false);
			this.CircleExhibitionView.SetAudioEvent("ui_cipher_picker_tick");
			this.CircleExhibitionView.CreateItems(base.GetItem(1).GetOwner() as AUIBaseActor, 0f, new Func<AActor, int, int, CipherCircleAttachItem>(this.CreateCircleItem), EAttachDirection.Vertical);
			base.GetItem(1).SetUIActive(false);
			this.CircleExhibitionView.ReloadView(10, this.AllNumber, 0);
			this.CircleExhibitionView.AttachToIndex(0, false);
			this.AddEvent();
		}

		// Token: 0x06044F16 RID: 282390 RVA: 0x011F1FA0 File Offset: 0x011F01A0
		protected override void OnBeforeDestroy()
		{
			this.RemoveEvent();
			this.CircleExhibitionView.Clear();
		}

		// Token: 0x06044F17 RID: 282391 RVA: 0x011F1FB3 File Offset: 0x011F01B3
		public void AddEvent()
		{
		}

		// Token: 0x06044F18 RID: 282392 RVA: 0x011F1FB5 File Offset: 0x011F01B5
		public void RemoveEvent()
		{
		}

		// Token: 0x06044F19 RID: 282393 RVA: 0x011F1FB7 File Offset: 0x011F01B7
		public void InitKey(Action<int, int> cb)
		{
			this.KeySelectedCallback = cb;
		}

		// Token: 0x06044F1A RID: 282394 RVA: 0x011F1FC0 File Offset: 0x011F01C0
		[NullableContext(1)]
		private CipherCircleAttachItem CreateCircleItem(AActor actor, int index, int showNum)
		{
			CipherCircleAttachItem cipherCircleAttachItem = new CipherCircleAttachItem(actor);
			cipherCircleAttachItem.InitData(this.KeyIndex, this.OnKeyItemSelectedHandle);
			this.CircleItemList.Add(cipherCircleAttachItem);
			return cipherCircleAttachItem;
		}

		// Token: 0x06044F1B RID: 282395 RVA: 0x011F1FF3 File Offset: 0x011F01F3
		private void KeyItemSelectedHandle(int value)
		{
			this.SelectedItemValue = value;
			if (this.KeySelectedCallback == null)
			{
				return;
			}
			this.KeySelectedCallback(this.KeyIndex, value);
		}

		// Token: 0x06044F1C RID: 282396 RVA: 0x011F2018 File Offset: 0x011F0218
		public void HandleConfirm(bool result)
		{
			foreach (CipherCircleAttachItem cipherCircleAttachItem in this.CircleItemList)
			{
				int? number = cipherCircleAttachItem.GetNumber();
				int selectedItemValue = this.SelectedItemValue;
				if (number.GetValueOrDefault() == selectedItemValue & number != null)
				{
					cipherCircleAttachItem.HandleConfirm(result);
					break;
				}
			}
		}

		// Token: 0x06044F1D RID: 282397 RVA: 0x011F2090 File Offset: 0x011F0290
		public void HandleRest()
		{
			this.CircleExhibitionView.ReloadView(10, this.AllNumber, 0);
			this.CircleExhibitionView.AttachToIndex(0, false);
		}

		// Token: 0x0402670E RID: 157454
		private const int INITGP = 0;

		// Token: 0x0402670F RID: 157455
		private const int LEN = 10;

		// Token: 0x04026710 RID: 157456
		public int KeyIndex;

		// Token: 0x04026711 RID: 157457
		private Action<int, int> KeySelectedCallback;

		// Token: 0x04026712 RID: 157458
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private CircleAttachView<int, CipherCircleAttachItem> CircleExhibitionView;

		// Token: 0x04026713 RID: 157459
		private int[] AllNumber;

		// Token: 0x04026714 RID: 157460
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<CipherCircleAttachItem> CircleItemList;

		// Token: 0x04026715 RID: 157461
		private Action<int> OnKeyItemSelectedHandle;

		// Token: 0x04026716 RID: 157462
		private int SelectedItemValue;

		// Token: 0x0200CBE1 RID: 52193
		[NullableContext(0)]
		private class ECipherKey
		{
			// Token: 0x0403E86A RID: 256106
			public const int DragCipherList = 0;

			// Token: 0x0403E86B RID: 256107
			public const int CipherCircleItem = 1;
		}
	}
}
