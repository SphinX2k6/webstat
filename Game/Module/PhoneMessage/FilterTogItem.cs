using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhoneMessage
{
	// Token: 0x0200545B RID: 21595
	[NullableContext(2)]
	[Nullable(0)]
	internal class FilterTogItem : GridProxyAbstract<int>
	{
		// Token: 0x06037034 RID: 225332 RVA: 0x00DF6A51 File Offset: 0x00DF4C51
		public void SetOnFilterTogItemClick(Action<int, bool> callback)
		{
			this.OnFilterTogItemClick = callback;
		}

		// Token: 0x06037035 RID: 225333 RVA: 0x00DF6A5A File Offset: 0x00DF4C5A
		public void SetIsFilterSelected(Func<int, bool> callback)
		{
			this.IsFilterSelected = callback;
		}

		// Token: 0x06037036 RID: 225334 RVA: 0x00DF6A64 File Offset: 0x00DF4C64
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(2, typeof(UUITexture))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnTogItemClick))
			};
		}

		// Token: 0x06037037 RID: 225335 RVA: 0x00DF6AE4 File Offset: 0x00DF4CE4
		public override void Refresh(int filterId, bool isSelected, int gridIndex)
		{
			this.Id = new int?(filterId);
			ChatPartnerFilter? chatPartnerFilterConfig = ConfigBase<PhoneMsgConfig>.Instance.GetChatPartnerFilterConfig(filterId);
			if (chatPartnerFilterConfig == null)
			{
				return;
			}
			UUIText text = base.GetText(0);
			if (text != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, chatPartnerFilterConfig.Value.Name, Array.Empty<object>());
			}
			base.SetTextureByPath(chatPartnerFilterConfig.Value.Icon, base.GetTexture(2), null, null);
			bool flag = this.IsFilterSelected != null && this.Id != null && this.IsFilterSelected(this.Id.Value);
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle != null)
			{
				extendToggle.SetToggleStateForce(flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			}
		}

		// Token: 0x06037038 RID: 225336 RVA: 0x00DF6BB0 File Offset: 0x00DF4DB0
		private void OnTogItemClick(EToggleState state)
		{
			if (this.Id == null)
			{
				return;
			}
			bool arg = state == EToggleState.ETT_Checked;
			Action<int, bool> onFilterTogItemClick = this.OnFilterTogItemClick;
			if (onFilterTogItemClick == null)
			{
				return;
			}
			onFilterTogItemClick(this.Id.Value, arg);
		}

		// Token: 0x06037039 RID: 225337 RVA: 0x00DF6BEC File Offset: 0x00DF4DEC
		public override void Clear()
		{
		}

		// Token: 0x0401FA6A RID: 129642
		private int? Id;

		// Token: 0x0401FA6B RID: 129643
		private Action<int, bool> OnFilterTogItemClick;

		// Token: 0x0401FA6C RID: 129644
		private Func<int, bool> IsFilterSelected;
	}
}
