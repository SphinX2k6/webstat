using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054C6 RID: 21702
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DropDownTitle : TitleItemBase<GymChallengeData>
	{
		// Token: 0x06037484 RID: 226436 RVA: 0x00E06AC9 File Offset: 0x00E04CC9
		public DropDownTitle(UUIItem uiItem) : base(uiItem)
		{
		}

		// Token: 0x06037485 RID: 226437 RVA: 0x00E06AD2 File Offset: 0x00E04CD2
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText))
			};
		}

		// Token: 0x06037486 RID: 226438 RVA: 0x00E06AF8 File Offset: 0x00E04CF8
		public override void ShowTemp(GymChallengeData data, DropDownItemBase<GymChallengeData> selectedItemObj)
		{
			string textStringId = data.IsLast ? "PhantomBattle_1115" : "PhantomBattle_1114";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textStringId, Array.Empty<object>());
		}
	}
}
