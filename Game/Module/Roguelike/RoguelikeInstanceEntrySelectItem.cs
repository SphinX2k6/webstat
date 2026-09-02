using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200518A RID: 20874
	public class RoguelikeInstanceEntrySelectItem : GridProxyAbstract<RougePopularEntrie>
	{
		// Token: 0x06035B49 RID: 219977 RVA: 0x00D7E460 File Offset: 0x00D7C660
		public override void Refresh(RougePopularEntrie data, bool isSelected, int gridIndex)
		{
			this.DataId = data.Id;
			bool flag = RoguelikeInstanceEntrySelectView.SelectIndexList.Contains(data.Id);
			UUIExtendToggle extendToggle = base.GetExtendToggle(4);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			}
			UUIExtendToggle extendToggle2 = base.GetExtendToggle(4);
			if (extendToggle2 == null || !extendToggle2.CanExecuteChange.IsBound())
			{
				UUIExtendToggle extendToggle3 = base.GetExtendToggle(4);
				if (extendToggle3 != null)
				{
					extendToggle3.CanExecuteChange.Unbind();
				}
			}
			UUIExtendToggle extendToggle4 = base.GetExtendToggle(4);
			if (extendToggle4 != null)
			{
				extendToggle4.CanExecuteChange.Bind(() => this.CheckCanExecuteChange == null || this.CheckCanExecuteChange(base.GetExtendToggle(4)));
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.Title, Array.Empty<object>());
			if (data.Category == 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "Roguelike_Instance_Entry_Buff_Number", new <>z__ReadOnlySingleElementList<object>(Math.Abs(data.Rate / 100).ToString()));
			}
			else if (data.Category == 1)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "Roguelike_Instance_Entry_DeBuff_Number", new <>z__ReadOnlySingleElementList<object>(Math.Abs(data.Rate / 100).ToString()));
			}
			base.SetTextureByPath(data.Icon, base.GetTexture(0), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), data.Describe, data.DescriptionParam());
		}

		// Token: 0x06035B4A RID: 219978 RVA: 0x00D7E5D4 File Offset: 0x00D7C7D4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIExtendToggle));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035B4B RID: 219979 RVA: 0x00D7E6A0 File Offset: 0x00D7C8A0
		protected override void OnStart()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(4);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChange));
		}

		// Token: 0x06035B4C RID: 219980 RVA: 0x00D7E6C4 File Offset: 0x00D7C8C4
		protected void OnToggleStateChange(EToggleState state)
		{
			if (this.OnSelectBuff != null)
			{
				this.OnSelectBuff(this.DataId, state == EToggleState.ETT_Checked, base.GetExtendToggle(4));
			}
		}

		// Token: 0x06035B4D RID: 219981 RVA: 0x00D7E6EA File Offset: 0x00D7C8EA
		public bool IsToggleSelected()
		{
			return base.GetExtendToggle(4).GetToggleState() == EToggleState.ETT_Checked;
		}

		// Token: 0x06035B4E RID: 219982 RVA: 0x00D7E6FB File Offset: 0x00D7C8FB
		public void SetToggleInteractive(bool isInteractive)
		{
			base.GetExtendToggle(4).SetSelfInteractive(isInteractive);
		}

		// Token: 0x0401ED1D RID: 126237
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<int, bool, UUIExtendToggle> OnSelectBuff;

		// Token: 0x0401ED1E RID: 126238
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<UUIExtendToggle, bool> CheckCanExecuteChange;

		// Token: 0x0401ED1F RID: 126239
		public int DataId;

		// Token: 0x0200B14C RID: 45388
		public class ERoguelikeInstanceEntrySelectItem
		{
			// Token: 0x04036FBF RID: 225215
			public const int TextureIcon = 0;

			// Token: 0x04036FC0 RID: 225216
			public const int TxtTitle = 1;

			// Token: 0x04036FC1 RID: 225217
			public const int TxtBuffNumber = 2;

			// Token: 0x04036FC2 RID: 225218
			public const int TxtDescription = 3;

			// Token: 0x04036FC3 RID: 225219
			public const int ExtendToggle = 4;
		}
	}
}
