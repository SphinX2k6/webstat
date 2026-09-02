using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.BossPiling.View.Item
{
	// Token: 0x02005F08 RID: 24328
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class BossPilingBuffItem : SyncGridProxyAbstract<BossPilingBuffCountInfo>
	{
		// Token: 0x0603D1AE RID: 250286 RVA: 0x00F85374 File Offset: 0x00F83574
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D1AF RID: 250287 RVA: 0x00F854C8 File Offset: 0x00F836C8
		protected override void OnStart()
		{
			base.GetExtendToggle(6).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			base.GetExtendToggle(6).bLockStateOnSelect = true;
			base.GetExtendToggle(6).OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChange));
			this.CountItem = new BossPilingBuffCountItem();
			this.CountItem.CreateByResourceIdAsync("UiItem_ItemAMult", base.GetItem(4), false).ContinueWith(delegate()
			{
				if (this.CurInfo.Count > 0)
				{
					this.CountItem.Refresh(this.CurInfo.Count);
				}
			});
		}

		// Token: 0x0603D1B0 RID: 250288 RVA: 0x00F85548 File Offset: 0x00F83748
		public override void Refresh(BossPilingBuffCountInfo data)
		{
			this.CurInfo = data;
			if (this.CountItem.IsShowOrShowing)
			{
				this.CountItem.Refresh(data.Count);
			}
			BossPilingBuff value = ConfigBase<BossPilingConfig>.Instance.GetBuffInfo(data.BuffId).Value;
			base.SetQualityIconById(base.GetSprite(0), value.Quality, null, null, null);
			base.SetTextureByPath(value.Icon, base.GetTexture(1), null, null);
			base.GetText(2).ShowTextNew(value.Name);
			if (this.IsSelectedCb != null)
			{
				this.SetSelected(this.IsSelectedCb(data.BuffId));
			}
		}

		// Token: 0x0603D1B1 RID: 250289 RVA: 0x00F8560C File Offset: 0x00F8380C
		protected void SetSelected(bool isSelected)
		{
			EToggleState state = isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			UUIExtendToggle extendToggle = base.GetExtendToggle(6);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(state, false, false, false);
		}

		// Token: 0x0603D1B2 RID: 250290 RVA: 0x00F85637 File Offset: 0x00F83837
		private void OnToggleStateChange(EToggleState _)
		{
			if (this.OnToggleClicked != null)
			{
				this.OnToggleClicked(this.CurInfo);
			}
		}

		// Token: 0x0402244F RID: 140367
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<BossPilingBuffCountInfo> OnToggleClicked;

		// Token: 0x04022450 RID: 140368
		[Nullable(2)]
		public Func<int, bool> IsSelectedCb;

		// Token: 0x04022451 RID: 140369
		[Nullable(2)]
		protected BossPilingBuffCountItem CountItem;

		// Token: 0x04022452 RID: 140370
		protected BossPilingBuffCountInfo CurInfo;

		// Token: 0x0200BF08 RID: 48904
		[NullableContext(0)]
		private enum EBuff
		{
			// Token: 0x0403ACB9 RID: 240825
			QualitySprite,
			// Token: 0x0403ACBA RID: 240826
			ItemTexture,
			// Token: 0x0403ACBB RID: 240827
			BottomText,
			// Token: 0x0403ACBC RID: 240828
			BottomTextBgSprite,
			// Token: 0x0403ACBD RID: 240829
			TopAdditionItem,
			// Token: 0x0403ACBE RID: 240830
			BottomAdditionItem,
			// Token: 0x0403ACBF RID: 240831
			ExtendToggle,
			// Token: 0x0403ACC0 RID: 240832
			UnderTextAdditionItem,
			// Token: 0x0403ACC1 RID: 240833
			SkinQualitySprite
		}
	}
}
