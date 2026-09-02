using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050D2 RID: 20690
	public class RoleDevelopTagItem : UiPanelBase
	{
		// Token: 0x0603550E RID: 218382 RVA: 0x00D60764 File Offset: 0x00D5E964
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

		// Token: 0x0603550F RID: 218383 RVA: 0x00D607D0 File Offset: 0x00D5E9D0
		public void RefreshByData(ERoleDevelopHotRoleTag tagType)
		{
			if (tagType == ERoleDevelopHotRoleTag.None)
			{
				base.SetUiActive(false);
				return;
			}
			string textStringId;
			if (tagType == ERoleDevelopHotRoleTag.Summon)
			{
				textStringId = "RoleProject_Popular";
			}
			else if (tagType == ERoleDevelopHotRoleTag.Forecast)
			{
				textStringId = "RoleProject_Prospect";
			}
			else
			{
				if (tagType != ERoleDevelopHotRoleTag.Rerun)
				{
					base.SetUiActive(false);
					return;
				}
				textStringId = "RoleProject_Review";
			}
			base.SetUiActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, Array.Empty<object>());
			base.GetTexture(0).SetColor(FColor.FromHex(RoleDevelopDefine.roleDevelopHotRoleTagColor[tagType]));
		}

		// Token: 0x0200B071 RID: 45169
		public static class EComponentType
		{
			// Token: 0x04036BFF RID: 224255
			public const int BgTex = 0;

			// Token: 0x04036C00 RID: 224256
			public const int TagStateTxt = 1;
		}
	}
}
