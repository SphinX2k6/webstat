using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063F7 RID: 25591
	public static class RoverlikeOutsideLayout
	{
		// Token: 0x0402406D RID: 147565
		[TupleElementNames(new string[]
		{
			"Slot",
			"Type"
		})]
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		[StaticVariableRuleIgnore]
		private static readonly IReadOnlyList<ValueTuple<EOutsideSlot, Type>> RoleColumn = new ValueTuple<EOutsideSlot, Type>[]
		{
			new ValueTuple<EOutsideSlot, Type>(EOutsideSlot.PnlRole, typeof(UUIItem)),
			new ValueTuple<EOutsideSlot, Type>(EOutsideSlot.SvRole, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<EOutsideSlot, Type>(EOutsideSlot.TogRole, typeof(UUIExtendToggle)),
			new ValueTuple<EOutsideSlot, Type>(EOutsideSlot.PnlRoleEmpty, typeof(UUIItem))
		};

		// Token: 0x0402406E RID: 147566
		[TupleElementNames(new string[]
		{
			"Slot",
			"Type"
		})]
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		[StaticVariableRuleIgnore]
		private static readonly IReadOnlyList<ValueTuple<EOutsideSlot, Type>> MainBody = new ValueTuple<EOutsideSlot, Type>[]
		{
			new ValueTuple<EOutsideSlot, Type>(EOutsideSlot.PnlItem, typeof(UUIItem)),
			new ValueTuple<EOutsideSlot, Type>(EOutsideSlot.SvMulti, typeof(UUIMultiTemplateScrollViewComponent)),
			new ValueTuple<EOutsideSlot, Type>(EOutsideSlot.PnlTitle, typeof(UUIItem)),
			new ValueTuple<EOutsideSlot, Type>(EOutsideSlot.ItemBaseGrid, typeof(UUIItem)),
			new ValueTuple<EOutsideSlot, Type>(EOutsideSlot.PnlProgress, typeof(UUIItem)),
			new ValueTuple<EOutsideSlot, Type>(EOutsideSlot.TxtProgress, typeof(UUIText)),
			new ValueTuple<EOutsideSlot, Type>(EOutsideSlot.ItemBlessDetail, typeof(UUIItem)),
			new ValueTuple<EOutsideSlot, Type>(EOutsideSlot.ItemPropDetail, typeof(UUIItem)),
			new ValueTuple<EOutsideSlot, Type>(EOutsideSlot.ItemReinforceDetail, typeof(UUIItem)),
			new ValueTuple<EOutsideSlot, Type>(EOutsideSlot.PnlRoleLock, typeof(UUIItem)),
			new ValueTuple<EOutsideSlot, Type>(EOutsideSlot.PnlRight, typeof(UUIItem)),
			new ValueTuple<EOutsideSlot, Type>(EOutsideSlot.PnlToggle, typeof(UUIItem)),
			new ValueTuple<EOutsideSlot, Type>(EOutsideSlot.ToggleTick, typeof(UUIExtendToggle))
		};

		// Token: 0x0402406F RID: 147567
		[TupleElementNames(new string[]
		{
			"Slot",
			"Type"
		})]
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		[StaticVariableRuleIgnore]
		public static readonly IReadOnlyList<ValueTuple<EOutsideSlot, Type>> WithRole = RoverlikeOutsideLayout.RoleColumn.Concat(RoverlikeOutsideLayout.MainBody).ToList<ValueTuple<EOutsideSlot, Type>>();

		// Token: 0x04024070 RID: 147568
		[TupleElementNames(new string[]
		{
			"Slot",
			"Type"
		})]
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		[StaticVariableRuleIgnore]
		public static readonly IReadOnlyList<ValueTuple<EOutsideSlot, Type>> Compact = RoverlikeOutsideLayout.MainBody;
	}
}
