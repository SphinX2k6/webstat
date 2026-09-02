using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;
using UnrealEngine;

// Token: 0x020019DB RID: 6619
public class MediumItemGridRoleDevTagComponent : MediumItemGridComponent
{
	// Token: 0x0600BDD7 RID: 48599 RVA: 0x00324AC4 File Offset: 0x00322CC4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BDD8 RID: 48600 RVA: 0x00324B2D File Offset: 0x00322D2D
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_RoleDevelopTag";
	}

	// Token: 0x0600BDD9 RID: 48601 RVA: 0x00324B34 File Offset: 0x00322D34
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		if (data is ERoleDevelopHotRoleTag)
		{
			ERoleDevelopHotRoleTag eroleDevelopHotRoleTag = (ERoleDevelopHotRoleTag)data;
			bool flag = true;
			this.SetActive(flag);
			if (flag)
			{
				string textStringId;
				if (eroleDevelopHotRoleTag == ERoleDevelopHotRoleTag.Forecast)
				{
					textStringId = "RoleProject_Prospect";
				}
				else if (eroleDevelopHotRoleTag == ERoleDevelopHotRoleTag.Rerun)
				{
					textStringId = "RoleProject_Review";
				}
				else
				{
					if (eroleDevelopHotRoleTag != ERoleDevelopHotRoleTag.Summon)
					{
						this.SetActive(false);
						return;
					}
					textStringId = "RoleProject_Popular";
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, Array.Empty<object>());
				base.GetTexture(0).SetColor(FColor.FromHex(RoleDevelopDefine.roleDevelopHotRoleTagColor[eroleDevelopHotRoleTag]));
			}
			return;
		}
	}

	// Token: 0x0600BDDA RID: 48602 RVA: 0x00324BC3 File Offset: 0x00322DC3
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Bottom;
	}

	// Token: 0x02007CCD RID: 31949
	private class EChildType
	{
		// Token: 0x0402A985 RID: 174469
		public const int TexBg = 0;

		// Token: 0x0402A986 RID: 174470
		public const int TxtTagState = 1;
	}
}
