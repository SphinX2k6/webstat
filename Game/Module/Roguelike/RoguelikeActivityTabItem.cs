using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200517F RID: 20863
	public class RoguelikeActivityTabItem : UiPanelBase
	{
		// Token: 0x06035AE3 RID: 219875 RVA: 0x00D7C092 File Offset: 0x00D7A292
		public RoguelikeActivityTabItem(int seasonId, int index)
		{
			this.SeasonId = seasonId;
			this.Index = index;
		}

		// Token: 0x06035AE4 RID: 219876 RVA: 0x00D7C0A8 File Offset: 0x00D7A2A8
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035AE5 RID: 219877 RVA: 0x00D7C16F File Offset: 0x00D7A36F
		protected override void OnStart()
		{
			this.Update(this.SeasonId);
		}

		// Token: 0x06035AE6 RID: 219878 RVA: 0x00D7C17D File Offset: 0x00D7A37D
		protected void OnClickToggle(EToggleState _)
		{
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.RoguelikeSelectSeason, this.SeasonId, this.Index);
		}

		// Token: 0x06035AE7 RID: 219879 RVA: 0x00D7C19B File Offset: 0x00D7A39B
		public void SetToggleState(EToggleState state)
		{
			base.GetExtendToggle(0).SetToggleState(state, false, false, false);
		}

		// Token: 0x06035AE8 RID: 219880 RVA: 0x00D7C1B0 File Offset: 0x00D7A3B0
		protected void Update(int seasonId)
		{
			this.SeasonId = seasonId;
			RogueSeason? rogueSeasonConfigById = ConfigBase<RoguelikeConfig>.Instance.GetRogueSeasonConfigById(seasonId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), rogueSeasonConfigById.Value.SeasonName, Array.Empty<object>());
			this.SetSpriteByPath(rogueSeasonConfigById.Value.TabIcon, base.GetSprite(2), false, null, null);
		}

		// Token: 0x0401ED01 RID: 126209
		public int SeasonId;

		// Token: 0x0401ED02 RID: 126210
		public int Index;

		// Token: 0x0200B137 RID: 45367
		private class ERoguelikeActivityTabItemDefine
		{
			// Token: 0x04036F64 RID: 225124
			public const int Toggle = 0;

			// Token: 0x04036F65 RID: 225125
			public const int TxtName = 1;

			// Token: 0x04036F66 RID: 225126
			public const int SpriteIcon = 2;
		}
	}
}
