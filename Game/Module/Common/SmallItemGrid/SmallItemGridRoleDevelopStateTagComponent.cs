using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;
using UnrealEngine;

namespace CSharpScript.Game.Module.Common.SmallItemGrid
{
	// Token: 0x02005E4C RID: 24140
	public class SmallItemGridRoleDevelopStateTagComponent : SmallItemGridComponent
	{
		// Token: 0x0603CBEA RID: 248810 RVA: 0x00F6CEA0 File Offset: 0x00F6B0A0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603CBEB RID: 248811 RVA: 0x00F6CEE8 File Offset: 0x00F6B0E8
		[NullableContext(1)]
		protected override string GetResourceId()
		{
			return "UiItem_ItemBRoleDevelopTag";
		}

		// Token: 0x0603CBEC RID: 248812 RVA: 0x00F6CEEF File Offset: 0x00F6B0EF
		public override EItemGridComponentLayoutLevel GetLayoutLevel()
		{
			return EItemGridComponentLayoutLevel.Top;
		}

		// Token: 0x0603CBED RID: 248813 RVA: 0x00F6CEF4 File Offset: 0x00F6B0F4
		[NullableContext(2)]
		protected override void OnRefresh(object data)
		{
			if (data is ERoleDevelopStateTagType)
			{
				string path;
				switch ((ERoleDevelopStateTagType)data)
				{
				case ERoleDevelopStateTagType.Lack:
					path = "/Game/Aki/UI/UIResources/Common/Image/Com/T_RoleDevelopTag2.T_RoleDevelopTag2";
					break;
				case ERoleDevelopStateTagType.CanBeFilled:
					path = "/Game/Aki/UI/UIResources/Common/Image/Com/T_RoleDevelopTag4.T_RoleDevelopTag4";
					break;
				case ERoleDevelopStateTagType.Completed:
					path = "/Game/Aki/UI/UIResources/Common/Image/Com/T_RoleDevelopTag1.T_RoleDevelopTag1";
					break;
				default:
					this.SetActive(false);
					return;
				}
				base.SetTextureByPath(path, base.GetTexture(0), null, null);
				this.SetActive(true);
				return;
			}
			this.SetActive(false);
		}

		// Token: 0x0200BE74 RID: 48756
		private class EChildType
		{
			// Token: 0x0403AA46 RID: 240198
			public const int TexIcon = 0;
		}
	}
}
