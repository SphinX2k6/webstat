using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054C5 RID: 21701
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DropDownItem : DropDownItemBase<GymChallengeData>
	{
		// Token: 0x0603747F RID: 226431 RVA: 0x00E069D8 File Offset: 0x00E04BD8
		public DropDownItem(UUIItem uiItem) : base(uiItem)
		{
		}

		// Token: 0x06037480 RID: 226432 RVA: 0x00E069E1 File Offset: 0x00E04BE1
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x06037481 RID: 226433 RVA: 0x00E06A1A File Offset: 0x00E04C1A
		[NullableContext(2)]
		protected override UUIExtendToggle GetDropDownToggle()
		{
			return base.GetExtendToggle(0);
		}

		// Token: 0x06037482 RID: 226434 RVA: 0x00E06A24 File Offset: 0x00E04C24
		protected override void OnShowDropDownItemBase(GymChallengeData data)
		{
			this.Data = data;
			string textStringId = this.Data.IsLast ? "PhantomBattle_1115" : "PhantomBattle_1114";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, Array.Empty<object>());
			if (data.State == EChallengeState.Lock)
			{
				this.GetDropDownToggle().OnUndeterminedClicked.Add(new Action(this.OnClickedLock));
				this.GetDropDownToggle().SetToggleStateForce(EToggleState.ETT_UnDetermined, false, false, false);
			}
		}

		// Token: 0x06037483 RID: 226435 RVA: 0x00E06A9C File Offset: 0x00E04C9C
		private void OnClickedLock()
		{
			GymChallengeData data = this.Data;
			if (data != null && data.State == EChallengeState.Lock)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomBattle_1112", Array.Empty<object>());
			}
		}

		// Token: 0x0401FC57 RID: 130135
		[Nullable(2)]
		private GymChallengeData Data;

		// Token: 0x0200B430 RID: 46128
		[NullableContext(0)]
		private class EDropDownItemComponent
		{
			// Token: 0x04037C47 RID: 228423
			public const int Toggle = 0;

			// Token: 0x04037C48 RID: 228424
			public const int Content = 1;
		}
	}
}
