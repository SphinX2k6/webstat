using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.Cipher
{
	// Token: 0x02006F40 RID: 28480
	[NullableContext(1)]
	[Nullable(0)]
	public class CipherCircleItem : AutoAttachExhibitionItemAbstract
	{
		// Token: 0x06044F07 RID: 282375 RVA: 0x011F1C5B File Offset: 0x011EFE5B
		public CipherCircleItem(AActor uiItem) : base(uiItem)
		{
		}

		// Token: 0x06044F08 RID: 282376 RVA: 0x011F1C94 File Offset: 0x011EFE94
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText))
			};
		}

		// Token: 0x06044F09 RID: 282377 RVA: 0x011F1CB8 File Offset: 0x011EFEB8
		public override void RefreshItem(int showItemIndex)
		{
			this.CurrentNumber = new int?(this.Data[base.GetShowItemIndex()]);
			if (this.CurrentNumber == null)
			{
				return;
			}
			base.GetText(0).SetText(this.CurrentNumber.Value.ToString(), true);
		}

		// Token: 0x06044F0A RID: 282378 RVA: 0x011F1D0C File Offset: 0x011EFF0C
		public override void OnSelect()
		{
			base.OnSelect();
			ModelBase<CipherModel>.Instance.SetCurPassword(this.OwnerId, this.CurrentNumber.Value);
			base.GetText(0).useChangeColor = false;
			if (this.ItemSelectedCallback == null)
			{
				return;
			}
			this.ItemSelectedCallback(this.CurrentNumber.Value);
		}

		// Token: 0x06044F0B RID: 282379 RVA: 0x011F1D66 File Offset: 0x011EFF66
		public override void OnUnSelect()
		{
			base.OnUnSelect();
			base.GetText(0).SetColor(this.NormalColor);
			base.GetText(0).useChangeColor = true;
		}

		// Token: 0x06044F0C RID: 282380 RVA: 0x011F1D8D File Offset: 0x011EFF8D
		public override void SetData(object param)
		{
			this.Data = (param as int[]);
		}

		// Token: 0x06044F0D RID: 282381 RVA: 0x011F1D9B File Offset: 0x011EFF9B
		public void InitItem(int ownerId, Action<int> cb)
		{
			this.OwnerId = ownerId;
			this.ItemSelectedCallback = cb;
		}

		// Token: 0x06044F0E RID: 282382 RVA: 0x011F1DAC File Offset: 0x011EFFAC
		public void HandleConfirm(bool result)
		{
			FColor color = this.WrongColor;
			if (result)
			{
				color = this.RightColor;
			}
			base.GetText(0).SetColor(color);
		}

		// Token: 0x06044F0F RID: 282383 RVA: 0x011F1DD7 File Offset: 0x011EFFD7
		public int? GetNumber()
		{
			return this.CurrentNumber;
		}

		// Token: 0x04026704 RID: 157444
		private const string WRONG_COLOR = "BB5C58";

		// Token: 0x04026705 RID: 157445
		private const string RIGHT_COLOR = "F6D03F";

		// Token: 0x04026706 RID: 157446
		private const string NORMAL_COLOR = "FFFFFF";

		// Token: 0x04026707 RID: 157447
		private int OwnerId;

		// Token: 0x04026708 RID: 157448
		private int? CurrentNumber;

		// Token: 0x04026709 RID: 157449
		[Nullable(2)]
		private int[] Data;

		// Token: 0x0402670A RID: 157450
		private readonly FColor WrongColor = FColor.FromHex("BB5C58");

		// Token: 0x0402670B RID: 157451
		private readonly FColor RightColor = FColor.FromHex("F6D03F");

		// Token: 0x0402670C RID: 157452
		private readonly FColor NormalColor = FColor.FromHex("FFFFFF");

		// Token: 0x0402670D RID: 157453
		[Nullable(2)]
		private Action<int> ItemSelectedCallback;

		// Token: 0x0200CBE0 RID: 52192
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403E869 RID: 256105
			public const int TextNum = 0;
		}
	}
}
