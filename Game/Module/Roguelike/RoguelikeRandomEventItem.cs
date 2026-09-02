using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200518F RID: 20879
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoguelikeRandomEventItem : GridProxyAbstract<RogueGainEntry>
	{
		// Token: 0x06035B60 RID: 220000 RVA: 0x00D7EFE8 File Offset: 0x00D7D1E8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035B61 RID: 220001 RVA: 0x00D7F072 File Offset: 0x00D7D272
		protected override void OnStart()
		{
			base.GetExtendToggle(0).OnStateChange.Clear();
			base.GetExtendToggle(0).OnStateChange.Add(new Action<EToggleState>(this.OnClickEvent));
		}

		// Token: 0x06035B62 RID: 220002 RVA: 0x00D7F0A2 File Offset: 0x00D7D2A2
		protected void OnClickEvent(EToggleState toggleState)
		{
			ModelBase<RoguelikeModel>.Instance.CurrentRogueGainEntry = ((toggleState == EToggleState.ETT_Checked) ? this.Data : null);
			if (this.OnSelectHandle != null)
			{
				this.OnSelectHandle(this, toggleState);
			}
		}

		// Token: 0x06035B63 RID: 220003 RVA: 0x00D7F0D0 File Offset: 0x00D7D2D0
		public void SetButtonState(bool isSelected)
		{
			base.GetExtendToggle(0).SetSelfInteractive(isSelected);
		}

		// Token: 0x06035B64 RID: 220004 RVA: 0x00D7F0DF File Offset: 0x00D7D2DF
		public void SetToggleState(bool isSelected)
		{
			base.GetExtendToggle(0).SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x06035B65 RID: 220005 RVA: 0x00D7F0F8 File Offset: 0x00D7D2F8
		public EToggleState GetToggleState()
		{
			return base.GetExtendToggle(0).GetToggleState();
		}

		// Token: 0x06035B66 RID: 220006 RVA: 0x00D7F108 File Offset: 0x00D7D308
		public override void Refresh(RogueGainEntry entry, bool isSelected, int gridIndex)
		{
			this.Data = entry;
			RogueEvent? rogueEventConfigById = ConfigBase<RoguelikeConfig>.Instance.GetRogueEventConfigById(entry.ConfigId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), ((rogueEventConfigById != null) ? rogueEventConfigById.GetValueOrDefault().Title : null) ?? "", Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), ((rogueEventConfigById != null) ? rogueEventConfigById.GetValueOrDefault().TextId : null) ?? "", Array.Empty<object>());
			bool flag = entry.IsSell ?? (ModelBase<RoguelikeModel>.Instance.GetRoguelikeCurrency(80100000) >= entry.Cost);
			this.SetButtonState(!entry.IsSelect && flag);
		}

		// Token: 0x0401ED2C RID: 126252
		public RogueGainEntry Data;

		// Token: 0x0401ED2D RID: 126253
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<RoguelikeRandomEventItem, EToggleState> OnSelectHandle;

		// Token: 0x0200B14F RID: 45391
		[NullableContext(0)]
		private class ERoguelikeRandomEventItemDefine
		{
			// Token: 0x04036FD0 RID: 225232
			public const int BtnEvent = 0;

			// Token: 0x04036FD1 RID: 225233
			public const int TxtTitle = 1;

			// Token: 0x04036FD2 RID: 225234
			public const int TxtDesc = 2;
		}
	}
}
