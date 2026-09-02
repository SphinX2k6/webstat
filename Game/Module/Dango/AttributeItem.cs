using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Dango
{
	// Token: 0x02005DE5 RID: 24037
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class AttributeItem : GridProxyAbstract<AttributeItemData>
	{
		// Token: 0x0603C7EF RID: 247791 RVA: 0x00F5D38C File Offset: 0x00F5B58C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUITexture))
			};
		}

		// Token: 0x0603C7F0 RID: 247792 RVA: 0x00F5D3E8 File Offset: 0x00F5B5E8
		[NullableContext(1)]
		public override void Refresh(AttributeItemData data, bool isSelected, int gridIndex)
		{
			if (data.DangoRoleData == null)
			{
				return;
			}
			AbyssDangoRoleData dangoRoleData = data.DangoRoleData;
			string skillCastTypeName = dangoRoleData.GetSkillCastTypeName();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), skillCastTypeName, Array.Empty<object>());
			string skillCastTypeIconPath = dangoRoleData.GetSkillCastTypeIconPath();
			base.SetTextureByPath(skillCastTypeIconPath, base.GetTexture(2), null, null);
		}

		// Token: 0x0200BE39 RID: 48697
		private enum EAttributeItemComponent
		{
			// Token: 0x0403A902 RID: 239874
			SpriteBg,
			// Token: 0x0403A903 RID: 239875
			NameText,
			// Token: 0x0403A904 RID: 239876
			Texture
		}
	}
}
