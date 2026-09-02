using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AutoAttach;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.Cipher
{
	// Token: 0x02006F3F RID: 28479
	[NullableContext(1)]
	[Nullable(0)]
	public class CipherCircleAttachItem : AutoAttachItem<int>
	{
		// Token: 0x06044EFE RID: 282366 RVA: 0x011F1AD5 File Offset: 0x011EFCD5
		[NullableContext(2)]
		public CipherCircleAttachItem(AActor uiItem = null) : base(uiItem)
		{
		}

		// Token: 0x06044EFF RID: 282367 RVA: 0x011F1B0E File Offset: 0x011EFD0E
		protected override void OnMoveItem()
		{
		}

		// Token: 0x06044F00 RID: 282368 RVA: 0x011F1B10 File Offset: 0x011EFD10
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText))
			};
		}

		// Token: 0x06044F01 RID: 282369 RVA: 0x011F1B34 File Offset: 0x011EFD34
		protected override void OnRefreshItem(int data)
		{
			this.CurrentNumber = new int?(data);
			if (this.CurrentNumber == null)
			{
				return;
			}
			base.GetText(0).SetText(this.CurrentNumber.Value.ToString(), true);
		}

		// Token: 0x06044F02 RID: 282370 RVA: 0x011F1B7C File Offset: 0x011EFD7C
		public override void OnSelect()
		{
			ModelBase<CipherModel>.Instance.SetCurPassword(this.OwnerId, this.CurrentNumber.Value);
			UUIText text = base.GetText(0);
			UUIItem uuiitem = text;
			bool bUseChangeColor = false;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			if (this.ItemSelectedCallback == null)
			{
				return;
			}
			this.ItemSelectedCallback(this.CurrentNumber.Value);
		}

		// Token: 0x06044F03 RID: 282371 RVA: 0x011F1BE0 File Offset: 0x011EFDE0
		protected override void OnUnSelect()
		{
			UUIText text = base.GetText(0);
			text.SetColor(this.NormalColor);
			UUIItem uuiitem = text;
			bool bUseChangeColor = true;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		}

		// Token: 0x06044F04 RID: 282372 RVA: 0x011F1C16 File Offset: 0x011EFE16
		[NullableContext(2)]
		public void InitData(int ownerId, Action<int> cb)
		{
			this.OwnerId = ownerId;
			this.ItemSelectedCallback = cb;
		}

		// Token: 0x06044F05 RID: 282373 RVA: 0x011F1C28 File Offset: 0x011EFE28
		public void HandleConfirm(bool result)
		{
			FColor color = this.WrongColor;
			if (result)
			{
				color = this.RightColor;
			}
			base.GetText(0).SetColor(color);
		}

		// Token: 0x06044F06 RID: 282374 RVA: 0x011F1C53 File Offset: 0x011EFE53
		public int? GetNumber()
		{
			return this.CurrentNumber;
		}

		// Token: 0x040266FB RID: 157435
		private const string WRONG_COLOR = "BB5C58";

		// Token: 0x040266FC RID: 157436
		private const string RIGHT_COLOR = "F6D03F";

		// Token: 0x040266FD RID: 157437
		private const string NORMAL_COLOR = "FFFFFF";

		// Token: 0x040266FE RID: 157438
		private int OwnerId;

		// Token: 0x040266FF RID: 157439
		private int? CurrentNumber;

		// Token: 0x04026700 RID: 157440
		private readonly FColor WrongColor = FColor.FromHex("BB5C58");

		// Token: 0x04026701 RID: 157441
		private readonly FColor RightColor = FColor.FromHex("F6D03F");

		// Token: 0x04026702 RID: 157442
		private readonly FColor NormalColor = FColor.FromHex("FFFFFF");

		// Token: 0x04026703 RID: 157443
		[Nullable(2)]
		private Action<int> ItemSelectedCallback;

		// Token: 0x0200CBDF RID: 52191
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403E868 RID: 256104
			public const int TextNum = 0;
		}
	}
}
