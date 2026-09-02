using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.RoleUi;
using UnrealEngine;

// Token: 0x020019E9 RID: 6633
public class MediumItemGridTrialRoleRightBottomTag : MediumItemGridComponent
{
	// Token: 0x0600BE15 RID: 48661 RVA: 0x003257D4 File Offset: 0x003239D4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BE16 RID: 48662 RVA: 0x0032581C File Offset: 0x00323A1C
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_TagRoleTrial";
	}

	// Token: 0x0600BE17 RID: 48663 RVA: 0x00325824 File Offset: 0x00323A24
	[NullableContext(2)]
	protected override void OnRefresh(object obj)
	{
		MediumTrialRoleRightBottomTag mediumTrialRoleRightBottomTag = obj as MediumTrialRoleRightBottomTag;
		if (mediumTrialRoleRightBottomTag == null)
		{
			return;
		}
		if (mediumTrialRoleRightBottomTag.IsTrialRole)
		{
			int trialRoleId = mediumTrialRoleRightBottomTag.TrialRoleId;
			string trailRoleLabelIconById = RoleUtils.GetTrailRoleLabelIconById(mediumTrialRoleRightBottomTag.TrialRoleId);
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(trailRoleLabelIconById);
			UUISprite icon = base.GetSprite(0);
			icon.SetUIActive(false);
			this.SetSpriteByPath(resourcePath, icon, false, null, delegate(bool isSuccess)
			{
				icon.SetUIActive(true);
			});
			this.SetActive(true);
			return;
		}
		this.SetActive(false);
	}

	// Token: 0x02007CDA RID: 31962
	private class EChildType
	{
		// Token: 0x0402A998 RID: 174488
		public const int IconImg = 0;
	}
}
